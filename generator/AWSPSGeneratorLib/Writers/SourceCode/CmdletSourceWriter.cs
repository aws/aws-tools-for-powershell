using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.CmdletConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Generators.ParamEmitters;
using AWSPowerShellGenerator.Utils;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    /// <summary>
    /// Writer to emit the source code for a cmdlet for an analyzed
    /// service operation.
    /// </summary>
    internal class CmdletSourceWriter : BaseSourceCodeWriter
    {
        public const string AWSConstantClassSourceAttributeName = "AWSConstantClassSource";
        public const string ValidateSetAttributeName = "ValidateSet";
        public const string AllowEmptyStringAttributeName = "AllowEmptyString";

        public const string ParameterRegionMarker = "#region Parameter";
        public const string EndRegionMarker = "#endregion";

        private const string MemoryStreamSubstitutionType = "byte[]";

        public ConfigModel ServiceConfig { get; private set; }
        public ServiceOperation Operation { get; private set; }
        public OperationAnalyzer MethodAnalysis { get; private set; }
        public string ServiceDisplayName { get; private set; }
        public BasicLogger Logger { get; private set; }

        public XmlDocument AssemblyDocumentation { get; private set; }

        /// <summary>
        /// Initializes the cmdlet source writer.
        /// </summary>
        /// <param name="analyzer"></param>
        /// <param name="serviceDisplayName"></param>
        /// <param name="options"></param>
        public CmdletSourceWriter(OperationAnalyzer analyzer, 
                                  string serviceDisplayName,
                                  GeneratorOptions options)
        {
            MethodAnalysis = analyzer;
            ServiceDisplayName = serviceDisplayName;
            AssemblyDocumentation = analyzer.AssemblyDocumentation;
            Logger = analyzer.Logger;
            Options = options;
        }

        /// <summary>
        /// Writes the source code file for the cmdlet implementing a service operation.
        /// </summary>
        /// <param name="writer"></param>
        public void Write(IndentedTextWriter writer)
        {
            ServiceConfig = MethodAnalysis.CurrentModel;
            Operation = MethodAnalysis.CurrentOperation;
            var analyzedResult = MethodAnalysis.AnalyzedResult;

            var customParamEmitters = new List<IParamEmitter>();

            var methodInfo = MethodAnalysis.Method;
            var methodDocumentation = DocumentationUtils.GetMethodDocumentation(methodInfo.DeclaringType, methodInfo.Name, AssemblyDocumentation);

            if (MethodAnalysis.GenerateIterationCode)
                methodDocumentation += "<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.";

            var commentedTypeDocumentation = DocumentationUtils.CommentDocumentation(methodDocumentation);

            var requiresSupportsShouldProcess = MethodAnalysis.SupportsShouldProcessInspectionResult != null;

            WriteSourceLicenseHeader(writer);
            WriteNamespaces(writer, ServiceConfig.ServiceNamespace, ServiceConfig.AdditionalNamespaces);

            writer.WriteLine();

            writer.WriteLine("namespace Amazon.PowerShell.Cmdlets.{0}", ServiceConfig.ServiceNounPrefix);
            writer.OpenRegion();
            {
                writer.WriteLine(commentedTypeDocumentation);
                writer.WriteLine("[Cmdlet(\"{0}\", \"{1}\"{2})]",
                                 Operation.SelectedVerb,
                                 Operation.SelectedNoun,
                                 requiresSupportsShouldProcess
                                    ? string.Format(", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.{0}", MethodAnalysis.ConfirmImpactSetting)
                                    : "");

                // Define the output type so that running Get-Command on the cmdlet has a populated OutputType 
                // value (this is independant of help). Use the string format of the attr so we don't risk 
                // namespace collisions on collection members (eg EMR and PowerShell both have 'Job' classes)
                var returnTypeNames = new List<string>();
                if (analyzedResult.ReturnType != null)
                    returnTypeNames.Add(analyzedResult.ReturnType.FullName);
                else
                {
                    returnTypeNames.Add("None");
                    if (MethodAnalysis.RequiresPassThruGeneration)
                        returnTypeNames.Add(MethodAnalysis.PassThruTypeName);
                }
                WriteOutputTypeAttribute(writer, returnTypeNames);

                // the AWSCmdlet* attribs are used for help generation
                WriteAWSCmdletAttributes(writer);

                writer.WriteLine("public partial class {0}{1}Cmdlet : {2}Cmdlet, IExecutor",
                                        Operation.SelectedVerb,
                                        Operation.SelectedNoun,
                                        ServiceConfig.GetServiceCmdletClassName(Operation.RequiresAnonymousAuthentication));
                writer.OpenRegion();
                {
                    // create cmdlet parameters
                    var usedPositionalCount = 0;

                    // we emit the 'real' parameters in alpha order to allow for consistent tabbing
                    // and comparison of changes, but put metadata/paging properties at the end so
                    // they don't come before the real parameters at the console
                    var paramProperties = MethodAnalysis.AnalyzedParameters.Count() > 1
                                              ? OrderParamsForSourceFile(MethodAnalysis.AnalyzedParameters, Operation)
                                              : MethodAnalysis.AnalyzedParameters;
                    foreach (var property in paramProperties)
                    {
                        var paramCustomization = MethodAnalysis.GetParameterCustomization(property.AnalyzedName);
                        if (paramCustomization != null && paramCustomization.Exclude)
                            continue;

                        // wrap the parameter in a region so that if we need to parse the raw source
                        // file we can easily find them
                        writer.WriteLine();
                        writer.WriteLine("{0} {1}", ParameterRegionMarker, property.CmdletParameterName);
                        var p = FindCustomEmitterForParam(property);
                        if (p == null)
                            WriteParam(writer, property, paramCustomization, ref usedPositionalCount);
                        else
                        {
                            customParamEmitters.Add(p);
                            p.WriteParams(writer, MethodAnalysis, property, paramCustomization, ref usedPositionalCount);
                        }                        
                        writer.WriteLine("#endregion");
                    }

                    // Execute any global parameter emitters for this cmdlet
                    var globalParamEmitters = FindGlobalParamEmitters();
                    foreach (var paramEmitter in globalParamEmitters)
                    {
                        writer.WriteLine();
                        customParamEmitters.Add(paramEmitter);
                        paramEmitter.WriteParams(writer, MethodAnalysis, null, null, ref usedPositionalCount);
                        
                    }

                    if (MethodAnalysis.RequiresPassThruGeneration)
                        WritePassThruSwitchParam(writer, MethodAnalysis);

                    // not the same semantics as the 'Anonymous' attribute - this adds a specific parameter the 
                    // user can employ to force anonymous auth on cmdlets that support both modes. The Anonymous
                    // attribute is used to mark cmdlets that are always anonymous.
                    if (Operation.AnonymousAuthentication == ServiceOperation.AnonymousAuthenticationMode.Optional)
                        WriteAnonymousCredentialsProperty(writer);

                    if (requiresSupportsShouldProcess)
                        WriteForceSwitchParam(writer);

                    writer.WriteLine();

                    writer.WriteLine("protected override void ProcessRecord()");
                    writer.OpenRegion();
                    {
                        if (Operation.AnonymousAuthentication == ServiceOperation.AnonymousAuthenticationMode.Optional)
                            writer.WriteLine("this.ExecuteWithAnonymousCredentials = this.UseAnonymousCredentials;");

                        writer.WriteLine("base.ProcessRecord();");
                        writer.WriteLine();

                        if (requiresSupportsShouldProcess)
                            WriteShouldProcessConfirmationCalls(writer, MethodAnalysis);

                        // create context object
                        WriteSetContext(writer, MethodAnalysis.AnalyzedParameters);
                        writer.WriteLine();

                        // execute client call using the context
                        WriteExecuteCall(writer);
                    }
                    writer.CloseRegion();

                    // implement IExecutor.Execute depending on iteration pattern required
                    writer.WriteLine();
                    writer.WriteLine("#region IExecutor Members");
                    writer.WriteLine();

                    var rootSimpleProperties = MethodAnalysis.RequestProperties;

                    if (!MethodAnalysis.GenerateIterationCode)
                        WriteIExecutor(writer, MethodAnalysis, rootSimpleProperties);
                    else
                    {
                        switch (MethodAnalysis.IterationPattern)
                        {
                            case AutoIteration.AutoIteratePattern.Pattern1:
                                WriteIExecutorIterPattern1(writer, MethodAnalysis, rootSimpleProperties);
                                break;

                            // pattern 2 and 3 are essentially the same, just that for calls identified as
                            // p3 we have an extra 'is truncated' indicator - given we auto-iterate either
                            // all items or a subset for a user, we can ignore isTruncated and emit pattern2
                            case AutoIteration.AutoIteratePattern.Pattern2:
                            case AutoIteration.AutoIteratePattern.Pattern3:
                                WriteIExecutorIterPattern2(writer, MethodAnalysis, rootSimpleProperties);
                                break;
                        }
                    }

                    writer.WriteLine();
                    writer.WriteLine("public ExecutorContext CreateContext()");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("return new CmdletContext();");
                    }
                    writer.CloseRegion();

                    writer.WriteLine();
                    writer.WriteLine("#endregion");
                    writer.WriteLine();

                    WriteAWSServiceOperationCall(writer);

                    writer.WriteLine();
                    WriteContextClass(writer, MethodAnalysis.AnalyzedParameters);
                    writer.WriteLine();
                }
                writer.CloseRegion();
            }
            writer.CloseRegion();
        }

        /// <summary>
        /// Emits the code to call the service operation mapped to the cmdlet. For desktop PowerShell we
        /// will call the synchronous SDK method. For CoreCLR platforms, we will call the asynchronous
        /// method (synchronous is not available) and await the response.
        /// </summary>
        /// <param name="writer"></param>
        private void WriteAWSServiceOperationCall(IndentedTextWriter writer)
        {
            writer.WriteLine("#region AWS Service Operation Call");
            writer.WriteLine();

            writer.WriteLine("private {0} CallAWSServiceOperation({1} client, {2} request)",
                             MethodAnalysis.ResponseType,
                             MethodAnalysis.CurrentModel.ServiceClientInterface,
                             MethodAnalysis.RequestType);
            writer.OpenRegion();

                writer.WriteLine("Utils.Common.WriteVerboseEndpointMessage(this, client.Config, \"{0}\", \"{1}\");", 
                                 MethodAnalysis.CurrentModel.ServiceName,
                                 MethodAnalysis.CurrentOperation.MethodName);

                writer.WriteLine("try");
                writer.OpenRegion();

                    writer.WriteLine("#if DESKTOP");

                    writer.WriteLine("return client.{0}(request);", MethodAnalysis.CurrentOperation.MethodName);

                    writer.WriteLine("#elif CORECLR");

                    writer.WriteLine("// todo: handle AggregateException and extract true service exception for rethrow");
                    writer.WriteLine("var task = client.{0}Async(request);", MethodAnalysis.CurrentOperation.MethodName);
                    writer.WriteLine("return task.Result;");
            
                    writer.WriteLine("#else");
            
                    writer.WriteLine("        #error \"Unknown build edition\"");
            
                    writer.WriteLine("#endif");

                writer.CloseRegion();
                writer.WriteLine("catch (AmazonServiceException exc)");
                writer.OpenRegion();
                    writer.WriteLine("var webException = exc.InnerException as System.Net.WebException;");
                    writer.WriteLine("if (webException != null)");
                    writer.OpenRegion();
                        writer.WriteLine(
                            "throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);");
                    writer.CloseRegion();
                    writer.WriteLine("throw;");
                writer.CloseRegion();
            writer.CloseRegion();

            writer.WriteLine();
            writer.WriteLine("#endregion");
        }

        /// <summary>
        /// Writes a formatted OutputType attribute for the cmdlet. We use the 'params string[]'
        /// format for the attribute.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="typeNames"></param>
        private static void WriteOutputTypeAttribute(IndentedTextWriter writer, IEnumerable<string> typeNames)
        {
            var sb = new StringBuilder();
            foreach (var t in typeNames)
            {
                if (sb.Length > 0)
                    sb.Append(",");
                sb.AppendFormat("\"{0}\"", t);
            }
            writer.WriteLine("[OutputType({0})]", sb);
        }

        private void WriteAWSCmdletAttributes(IndentedTextWriter writer)
        {
            var synopsis = new StringBuilder();
            synopsis.AppendFormat("Invokes the {0} operation against {1}.", Operation.MethodName, ServiceDisplayName);
            if (Operation.RequiresAnonymousAuthentication)
                synopsis.Append(" This operation uses anonymous authentication and does not require credential parameters to be supplied.");

            var awsCmdletAttribute = new StringBuilder(); 
            awsCmdletAttribute.AppendFormat("AWSCmdlet(\"{0}\", Operation = new[] {{\"{1}\"}}", synopsis, Operation.MethodName);
            if (!string.IsNullOrEmpty(Operation.LegacyAlias))
            {
                awsCmdletAttribute.AppendFormat(", LegacyAlias=\"{0}\"", Operation.LegacyAlias);
            }
            awsCmdletAttribute.Append(")");

            writer.WriteLine("[{0}]", awsCmdletAttribute.ToString());

            var analyzedResult = MethodAnalysis.AnalyzedResult;
            string returnTypeName;
            if (analyzedResult.ReturnType != null)
                returnTypeName = analyzedResult.ReturnType.FullName;
            else
            {
                // emulate what other cmdlets do in terms of the wording
                returnTypeName = "None";
                if (MethodAnalysis.RequiresPassThruGeneration)
                {
                    var passThruTypeName = MethodAnalysis.PassThruTypeName;
                    if (!string.IsNullOrEmpty(passThruTypeName))
                        returnTypeName = returnTypeName + " or " + passThruTypeName;
                }
            }

            writer.WriteLine("[AWSCmdletOutput(\"{0}\",", SecurityElement.Escape(returnTypeName));
            writer.IncreaseIndent();
            {
                if (MethodAnalysis.RequiresPassThruGeneration)
                {
                    if (Operation.PassThru != null && !string.IsNullOrEmpty(Operation.PassThru.Documentation))
                    {
                        writer.WriteLine("\"{0} when you use the PassThru parameter. Otherwise, this cmdlet does not return any output. \" +",
                                     Operation.PassThru.Documentation);
                    }
                    else
                    {
                        writer.WriteLine("\"When you use the PassThru parameter, this cmdlet outputs the value supplied to the {0} parameter. Otherwise, this cmdlet does not return any output. \" +",
                                        MethodAnalysis.AnalyzedResult.PassThruParameter.CmdletParameterName);
                    }
                }
                else if (analyzedResult.ReturnType == null)
                    writer.WriteLine("\"This cmdlet does not generate any output. \" +");

                // if generating an iteration pattern, it's ok to leave the description of the output in 
                // terms of a collection of things. If the cmdlet has no output, the description here tells
                // the user how to get to the service response.
                var count = 1;
                foreach (var description in analyzedResult.ReturnTypeDescription)
                {
                    writer.WriteLine("\"{0}\"{1}", description, count < analyzedResult.ReturnTypeDescription.Length ? "," : "");
                    count++;
                }
            }

            writer.DecreaseIndent();
            writer.WriteLine(")]");
        }

        /// <summary>
        /// For cmdlets that are annotated with SupportsShouldProcess, implements a standard
        /// call pattern to invoke ShouldProcess and ShouldContinue to support the user specifying
        /// the -WhatIf or -Confirm parameters.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        private static void WriteShouldProcessConfirmationCalls(IndentedTextWriter writer, OperationAnalyzer analyzer)
        {
            string targetParameterReference = null;
            if (analyzer.SupportsShouldProcessInspectionResult.TargetParameter != null)
                targetParameterReference = analyzer.SupportsShouldProcessInspectionResult.TargetParameter.CmdletParameterName;

            if (!string.IsNullOrEmpty(targetParameterReference))
                writer.WriteLine("var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(\"{0}\", MyInvocation.BoundParameters);",
                                  targetParameterReference);
            else
                writer.WriteLine("var resourceIdentifiersText = string.Empty;");
            writer.WriteLine("if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, \"{0}\"))",
                             analyzer.FormattedOperationForConfirmationMsg);
            writer.OpenRegion();
            writer.WriteLine("return;");
            writer.CloseRegion();
            writer.WriteLine();

            // strobe -- choosing not to also issue ShouldContinue as it results in a second confirmation
            // prompt, which I just don't like and is also a breaking change
            /*
            string confirmMsg;
            if (inspectionResult.TargetParameter == null)
                confirmMsg = "\"Are you sure you want to perform the operation?\"";
            else
                confirmMsg = string.Format("string.Format(\"Are you sure you want to perform the operation on {0} '{{0}}'?\", {1})",
                                            analyzer.ConfirmationMessageNoun.ToLower(),
                                            inspectionResult.TargetParameter.CmdletParameterName);

            writer.WriteLine("// It is possible that the ProcessRecord method is called ");
            writer.WriteLine("// multiple times when objects are received as inputs from ");
            writer.WriteLine("// the pipeline. So to retain YesToAll and NoToAll input that ");
            writer.WriteLine("// the user may enter across multiple calls to this function, ");
            writer.WriteLine("// they are stored as private members of the cmdlet.");
            writer.WriteLine("if (!ShouldContinue({0}, this.MyInvocation.MyCommand.Name, ref yesToAll, ref noToAll)) return;", confirmMsg);
            writer.WriteLine();
            */
        }

        /// <summary>
        /// Writes documentation + attributed property field for a parameter. Returns the positional
        /// placement of the parameter, if applied.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="property"></param>
        /// <param name="param"></param>
        /// <param name="usedPositionalCount"></param>
        public void WriteParam(IndentedTextWriter writer,
                               SimplePropertyInfo property,
                               Param param,
                               ref int usedPositionalCount)
        {
            var paramDoc = property.MemberDocumentation;
            if (MethodAnalysis.AutoIterateSettings != null && MethodAnalysis.AutoIterateSettings.IsNextToken(property.Name))
            {
                paramDoc += "\r\n<para>"
                         + "\r\n<br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call."
                         + "\r\n</para>";
            }
            writer.WriteLine(DocumentationUtils.CommentDocumentation(paramDoc));
            WriteParamProperty(writer, property, param, ref usedPositionalCount);
        }

        /// <summary>
        /// For cmdlets that have the ShouldSupportProcess attribution, adds a standard 'Force' switch
        /// parameter so the user can override the confirmation prompting
        /// </summary>
        /// <param name="writer"></param>
        public static void WriteForceSwitchParam(IndentedTextWriter writer)
        {
            // wrap the parameter in a region so that if we need to parse the raw source
            // file we can easily find them
            writer.WriteLine();
            writer.WriteLine("#region Parameter Force");
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// This parameter overrides confirmation prompts to force ");
            writer.WriteLine("/// the cmdlet to continue its operation. This parameter should always");
            writer.WriteLine("/// be used with caution.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter]");
            writer.WriteLine("public SwitchParameter Force { get; set; }");
            writer.WriteLine("#endregion");
        }

        /// <summary>
        /// For cmdlets that have no output but can have a value piped to them,
        /// adds a -PassThru switch so that the pipelined object gets echoed to the 
        /// output. This allows pipelines to be constructed that don't abruptly
        /// terminate because a cmdlet lacks output.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="passThruParameterName"/>
        public void WritePassThruSwitchParam(IndentedTextWriter writer, OperationAnalyzer methodAnalysis)
        {
            string documentation;
            if (Operation.PassThru != null && !string.IsNullOrEmpty(Operation.PassThru.Documentation))
                documentation = string.Format("{0}.", Operation.PassThru.Documentation);
            else
            {
                if (methodAnalysis.AnalyzedResult.PassThruParameter == null)
                    Logger.LogError("Operation {0} marked for passthru with no custom override - no parameter name set to pass thru!", Operation.MethodName);

                documentation = string.Format("Returns the value passed to the {0} parameter.", methodAnalysis.AnalyzedResult.PassThruParameter.CmdletParameterName);
            }

            // wrap the parameter in a region so that if we need to parse the raw source
            // file we can easily find them
            writer.WriteLine();
            writer.WriteLine("#region Parameter PassThru");
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// {0}", documentation);
            writer.WriteLine("/// {0}", StringConstants.NoCmdletOutputText);
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter]");
            writer.WriteLine("public SwitchParameter PassThru { get; set; }");
            writer.WriteLine("#endregion");
        }

        /// <summary>
        /// Adds a "UseAnonymousCredentials" parameter to cmdlets which support
        /// anonymous calls.
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteAnonymousCredentialsProperty(IndentedTextWriter writer)
        {
            // wrap the parameter in a region so that if we need to parse the raw source
            // file we can easily find them
            writer.WriteLine();
            writer.WriteLine("#region Parameter UseAnonymousCredentials");
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// If set, the cmdlet calls the service operation using anonymous credentials.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter]");
            writer.WriteLine("public bool UseAnonymousCredentials { get; set; }");
            writer.WriteLine("#endregion");
        }

        /// <summary>
        /// Writes the attributed property field for a parameter. For generic collection types, we mutate the
        /// parameter from generic List to typed array to better fit with PS convention. Returns the positional
        /// value applied to the parameter, if any.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="property"></param>
        /// <param name="paramCustomization"></param>
        /// <param name="usedPositionalCount">How many parameters have been tagged as positional (PS recommends no more than 5)</param>
        public void WriteParamProperty(IndentedTextWriter writer,
                                       SimplePropertyInfo property,
                                       Param paramCustomization,
                                       ref int usedPositionalCount)
        {
            WriteParamAttribute(writer, MethodAnalysis, property, paramCustomization, ref usedPositionalCount);
            WriteParamAliases(writer, MethodAnalysis, property);

            if (property.IsConstrainedToSet)
            {
                // apply our marker attribute so that if the cmdlet ever becomes hand-maintained the
                // generator can detect and update the argument completer for the set members by simple 
                // text parsing
                writer.WriteLine("[{0}(\"{1}\")]", AWSConstantClassSourceAttributeName, property.PropertyTypeName);
            }

            if (property.CollectionType == SimplePropertyInfo.PropertyCollectionType.NoCollection || property.GenericCollectionTypes == null)
            {
                writer.WriteLine("public {0} {1} {{ get; set; }}", GetPropertyTypeToEmit(property), property.CmdletParameterName);
            }
            else
            {
                // simplest to always emit types with full name, especially as some SDK types can collide with framework
                switch (property.CollectionType)
                {
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericList:
                        {
                            writer.WriteLine("public {0}[] {1} {{ get; set; }}", property.GenericCollectionTypes[0].FullName, property.CmdletParameterName);
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary:
                        {
                            // HashTable is the underlying hash type for PS and more convenient to emit as the param
                            // type as users can then use inline hash syntax @{key=value, key=value} to populate
                            writer.WriteLine("public System.Collections.Hashtable {0} {{ get; set; }}", property.CmdletParameterName);
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericList:
                        {
                            writer.WriteLine("public {0}[][] {1} {{ get; set; }}", property.GenericCollectionTypes[0].FullName, property.CmdletParameterName);
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericDictionary:
                        {
                            writer.WriteLine("public System.Collections.Hashtable[] {0} {{ get; set; }}", property.CmdletParameterName);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Writes the ValidateSet, plus optional AllowEmptyString, parameters onto a
        /// parameter.
        /// </summary>
        /// <remarks>
        /// Currently disabled while we investigate other approaches that may allow us
        /// to generate the intellisense without forcing updates when new enumeration
        /// values get added.
        /// </remarks>
        internal static void AddValidateSetAttribution(IndentedTextWriter writer, IEnumerable<string> members)
        {/*
            var validateSetAttribute = BuildValidateSetAttribute(members);
            var hasEmptyStringMember = RequiresEmptyValueAttribution(members);

            writer.WriteLine(validateSetAttribute);
            if (hasEmptyStringMember)
                writer.WriteLine("[{0}]", AllowEmptyStringAttributeName);
        */}

        internal static bool RequiresEmptyValueAttribution(IEnumerable<string> setMembers)
        {
            foreach (var m in setMembers)
            {
                if (m == string.Empty) // this is usually arranged to be the first member btw
                    return true;
            }

            return false;
        }

        internal static string BuildValidateSetAttribute(IEnumerable<string> members)
        {
            var sb = new StringBuilder();

            foreach (var m in members)
            {
                if (sb.Length > 0)
                    sb.Append(",");
                sb.AppendFormat("\"{0}\"", m);
            }

            return string.Format("[{0}({1})]", ValidateSetAttributeName, sb);
        }

        /// <summary>
        /// The Alias attribute can only be applied only once to a parameter, so gather up all
        /// the aliases, then sort into alpha-order for easier comparison of changes in subsequent
        /// releases before building the attribute declaration
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        /// <param name="property"></param>
        internal static void WriteParamAliases(IndentedTextWriter writer,
                                               OperationAnalyzer analyzer,
                                               SimplePropertyInfo property)
        {
            var aliases = new HashSet<string>(StringComparer.Ordinal);

            // global aliasing; mainly for usability
            if (analyzer.CurrentModel.CustomParameters.ContainsKey(property.AnalyzedName))
            {
                var globalAliases = analyzer.CurrentModel.CustomParameters[property.AnalyzedName].Aliases;
                foreach (var a in globalAliases)
                {
                    aliases.Add(a);
                }
            }

            // operation-specific aliasing; mainly used to maintain compat between sdk versions
            // and backwards compat due to auto-name shortening/singularization
            if (property.Customization != null)
            {
                // these aliases come from config entries on a ServiceOperation in the 
                // config or are applied automatically during name inspection
                var propAliases = property.Customization.Aliases;
                foreach (var a in propAliases)
                {
                    aliases.Add(a);
                }
            }

            // apply a cross-service alias if it's an iteration parameter?
            var autoIteration = analyzer.AutoIterateSettings;
            if (autoIteration != null)
            {
                var iterAlias = autoIteration.GetIterationParameterAlias(property.AnalyzedName);
                if (!string.IsNullOrEmpty(iterAlias))
                    aliases.Add(iterAlias);
            }

            if (aliases.Count <= 0) return;

            // sort the aliases into ascending order so that it's easier to spot
            // changes in version control
            var aliasList = new List<string>(aliases);
            aliasList.Sort(StringComparer.Ordinal);

            // need to expand otherwise we get Linq output :-(
            var sb = new StringBuilder("[Alias(");
            for (var i = 0; i < aliasList.Count; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.AppendFormat("\"{0}\"", aliasList[i]);
            }
            sb.Append(")]");
            writer.WriteLine(sb);
        }

        /// <summary>
        /// Writes the ParameterAttribute declaration for a parameter.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        /// <param name="property"></param>
        /// <param name="paramCustomization"></param>
        /// <param name="usedPositionalCount"></param>
        public static void WriteParamAttribute(IndentedTextWriter writer,
                                               OperationAnalyzer analyzer, 
                                               SimplePropertyInfo property,
                                               Param paramCustomization,
                                               ref int usedPositionalCount)
        {
            var paramAttrib = new StringBuilder();

            int paramPos = -1;
            if (usedPositionalCount < 5)
                paramPos = analyzer.GetParameterPositionData(property.AnalyzedName);

            if (paramPos != -1)
            {
                paramAttrib.AppendFormat("Position = {0}", paramPos);
                usedPositionalCount++;
            }

            // after singularization, a parameter name may now match a member name in a structure
            // and its useful to allow binding by matching property name as it enables constructs
            // like Get-CWAlarm | Remove-CWAlarm. Both cmdlets have sdk request properties of 
            // AlarmNames which become AlarmName on output. The objects emitted by Get-CWAlarm
            // have a member called AlarmName -- thus we allow simple pipelining.
            if (analyzer.CurrentModel.PipelineByValueProperties.Contains(property.AnalyzedName)
                    || analyzer.CurrentModel.PipelineByValueProperties.Contains(property.CmdletParameterName))
            {
                if (paramAttrib.Length > 0)
                    paramAttrib.Append(", ");
                paramAttrib.Append("ValueFromPipelineByPropertyName = true");
            }

            if (analyzer.CanAcceptValueFromPipeline(property.AnalyzedName))
            {
                if (paramAttrib.Length > 0)
                    paramAttrib.Append(", ");
                paramAttrib.Append("ValueFromPipeline = true");
            }

            if (paramAttrib.Length > 0)
                writer.WriteLine("[System.Management.Automation.Parameter({0})]", paramAttrib.ToString());
            else
                writer.WriteLine("[System.Management.Automation.Parameter]");

        }

        private static void WriteExecuteCall(IndentedTextWriter writer)
        {
            // execute method and process output
            writer.WriteLine("var output = Execute(context) as CmdletOutput;");
            writer.WriteLine("ProcessOutput(output);");
        }

        private void WriteSetContext(IndentedTextWriter writer, IEnumerable<SimplePropertyInfo> allProperties)
        {
            // create context object
            writer.WriteLine("var context = new CmdletContext");
            writer.OpenRegion();
            writer.WriteLine("Region = this.Region,");
            if (!Operation.RequiresAnonymousAuthentication)
                writer.WriteLine("Credentials = this.CurrentCredentials");
            writer.CloseRegion("};");

            writer.WriteLine();
            writer.WriteLine("// allow for manipulation of parameters prior to loading into context");
            writer.WriteLine("PreExecutionContextLoad(context);");
            writer.WriteLine();

            foreach (var property in allProperties)
            {
                if (OperationAnalyzer.IsExcludedParameter(property.AnalyzedName, ServiceConfig, Operation))
                    continue;

                var customEmitter = FindCustomEmitterForParam(property);
                if (customEmitter == null)
                {
                    if (property.CollectionType == SimplePropertyInfo.PropertyCollectionType.NoCollection || property.GenericCollectionTypes == null)
                    {
                        // checking to see if a value type parameter was bound allows us to employ
                        // use-if-present/ignore-if-absent semantics and avoid passing unintentional
                        // default values to request class members (ie 'false' for a bool that was never
                        // specified by the user, which may have a different meaning to 'not specified').
                        if (property.UseParameterValueOnlyIfBound)
                        {
                            writer.WriteLine("if (ParameterWasBound(\"{0}\"))", property.CmdletParameterName);
                            writer.IncreaseIndent();
                        }
                        writer.WriteLine("context.{0} = this.{1};", property.ContextParameterName, property.CmdletParameterName);
                        if (property.UseParameterValueOnlyIfBound)
                            writer.DecreaseIndent();
                    }
                    else
                    {
                        switch (property.CollectionType)
                        {
                            case SimplePropertyInfo.PropertyCollectionType.IsGenericList:
                                {
                                    // cannot pass null to List<T> ctor :-(
                                    writer.WriteLine("if (this.{0} != null)", property.CmdletParameterName);
                                    writer.OpenRegion();
                                    writer.WriteLine("context.{0} = new {1}(this.{2});", property.ContextParameterName, property.PropertyTypeName, property.CmdletParameterName);
                                    writer.CloseRegion();
                                }
                                break;

                            case SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary:
                                {
                                    writer.WriteLine("if (this.{0} != null)", property.CmdletParameterName);
                                    writer.OpenRegion();
                                    {
                                        writer.WriteLine("context.{0} = new {1}({2});",
                                                         property.ContextParameterName,
                                                         property.PropertyTypeName,
                                                         property.GenericCollectionTypes[0].Name.Equals("string", StringComparison.OrdinalIgnoreCase)
                                                                ? "StringComparer.Ordinal" : "");
                                        writer.WriteLine("foreach (var hashKey in this.{0}.Keys)", property.CmdletParameterName);
                                        writer.OpenRegion();
                                        {
                                            // this handles List<T> where T is a simple type. List<T> where T is a generic dictionary
                                            // is handled in the IsGenericListOfGenericDictionary switch case. We must hope the Hashtable 
                                            // value is enumerable
                                            if (!property.GenericCollectionTypes[1].Name.StartsWith("List`", StringComparison.Ordinal))
                                            {
                                                writer.WriteLine("context.{0}.Add(({1})hashKey, ({2})(this.{3}[hashKey]));",
                                                                    property.ContextParameterName,
                                                                    property.GenericCollectionTypes[0].Name,
                                                                    property.GenericCollectionTypes[1].Name,
                                                                    property.CmdletParameterName);
                                            }
                                            else
                                            {
                                                // need to do some clunky manipulation with non-genericized IEnumerable though, cast to
                                                // IEnumerable<T> yields exception on hashValue
                                                writer.WriteLine("object hashValue = this.{0}[hashKey];", property.CmdletParameterName);
                                                // have to dig deeper to get the real type, and not "List`1"
                                                string valueSetItemType = ((property.GenericCollectionTypes[1]).GetGenericArguments())[0].Name;

                                                writer.WriteLine("if (hashValue == null)");
                                                writer.OpenRegion();
                                                {
                                                    writer.WriteLine("context.{0}.Add(({1})hashKey, null);",
                                                                        property.ContextParameterName,
                                                                        property.GenericCollectionTypes[0].Name);
                                                    writer.WriteLine("continue;");
                                                }
                                                writer.CloseRegion();

                                                writer.WriteLine("var enumerable = SafeEnumerable(hashValue);");
                                                writer.WriteLine("var valueSet = new List<{0}>();", valueSetItemType);
                                                writer.WriteLine("foreach (var s in enumerable)");
                                                writer.OpenRegion();
                                                {
                                                    writer.WriteLine("valueSet.Add(({0})s);", valueSetItemType);
                                                }
                                                writer.CloseRegion();
                                                writer.WriteLine("context.{0}.Add(({1})hashKey, valueSet);",
                                                                    property.ContextParameterName,
                                                                    property.GenericCollectionTypes[0].Name);
                                            }
                                        }
                                        writer.CloseRegion();
                                    }
                                    writer.CloseRegion();
                                }
                                break;

                            case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericList:
                                {
                                    /* generates code pattern of:
                                        context.PROPERTY = new List<List<T>>();
                                        foreach (var innerList in this.PROPERTY)
                                        {
                                            context.PROPERTY.Add(new List<T>(innerList));
                                        }
                                    */
                                    writer.WriteLine("if (this.{0} != null)", property.CmdletParameterName);
                                    writer.OpenRegion();
                                    {
                                        // simple property info ctor has already dived down to get the inner types for us
                                        var innerDictionaryTypes = property.GenericCollectionTypes;

                                        writer.WriteLine("context.{0} = new {1}();", property.ContextParameterName, property.PropertyTypeName);
                                        writer.WriteLine("foreach (var innerList in this.{0})", property.CmdletParameterName);
                                        writer.OpenRegion();
                                        {
                                            writer.WriteLine("context.{0}.Add(new List<{1}>(innerList));", property.ContextParameterName, innerDictionaryTypes[0].FullName);                                            
                                        }
                                        writer.CloseRegion();
                                    }
                                    writer.CloseRegion();
                                }
                                break;

                            case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericDictionary:
                                {
                                    /* generates code pattern of:
                                        context.PROPERTY = new List<Dictionary<T1,T2>();
                                        foreach (var hashTable in this.PROPERTY)
                                        {
                                            var d = new Dictionary<T1, T2>();
                                            foreach (var key in hashTable.Keys)
                                            {
                                                d.Add((T1)key, (T2)hashTable[key]);
                                            }

                                            context.PROPERTY.Add(d);
                                        }
                                    */
                                    writer.WriteLine("if (this.{0} != null)", property.CmdletParameterName);
                                    writer.OpenRegion();
                                    {
                                        // simple property info ctor has already dived down to get the inner types for us
                                        var innerDictionaryTypes = property.GenericCollectionTypes;

                                        writer.WriteLine("context.{0} = new {1}();", property.ContextParameterName, property.PropertyTypeName);

                                        writer.WriteLine("foreach (var hashTable in this.{0})", property.CmdletParameterName);
                                        writer.OpenRegion();
                                        {
                                            writer.WriteLine("var d = new Dictionary<{0}, {1}>();", innerDictionaryTypes[0].FullName, innerDictionaryTypes[1].FullName);

                                            writer.WriteLine("foreach (var hashKey in hashTable.Keys)");
                                            writer.OpenRegion();
                                            {
                                                if (!innerDictionaryTypes[1].Name.StartsWith("List`", StringComparison.Ordinal))
                                                {
                                                    writer.WriteLine("d.Add(({0})hashKey, ({1})(hashTable[hashKey]));",
                                                                     innerDictionaryTypes[0].Name,
                                                                     innerDictionaryTypes[1].Name);
                                                }
                                                else
                                                {
                                                    // need to do some clunky manipulation with non-genericized IEnumerable though, cast to
                                                    // IEnumerable<T> yields exception on hashValue
                                                    writer.WriteLine("object hashValue = hashTable[hashKey];");
                                                    // have to dig deeper to get the real type, and not "List`1"
                                                    string valueSetItemType = ((innerDictionaryTypes[1]).GetGenericArguments())[0].Name;

                                                    writer.WriteLine("if (hashValue == null)");
                                                    writer.OpenRegion();
                                                    {
                                                        writer.WriteLine("d.Add(({0})hashKey, null);", innerDictionaryTypes[0].Name);
                                                        writer.WriteLine("continue;");
                                                    }
                                                    writer.CloseRegion();

                                                    writer.WriteLine("var enumerable = SafeEnumerable(hashValue);");
                                                    writer.WriteLine("var valueSet = new List<{0}>();", valueSetItemType);
                                                    writer.WriteLine("foreach (var s in enumerable)");
                                                    writer.OpenRegion();
                                                    {
                                                        writer.WriteLine("valueSet.Add(({0})s);", valueSetItemType);
                                                    }
                                                    writer.CloseRegion();
                                                    writer.WriteLine("d.Add(({0})hashKey, valueSet);", innerDictionaryTypes[0].Name);
                                                }
                                            }
                                            writer.CloseRegion();
                                        }

                                        writer.WriteLine("context.{0}.Add(d);", property.ContextParameterName);
                                        writer.CloseRegion();
                                    }
                                    writer.CloseRegion();
                                }
                                break;
                        }
                    }
                }
                else
                {
                    Param paramCustomization = Operation.FindCustomParameterData(property.AnalyzedName);
                    customEmitter.WriteContextMembers(writer, "context", property, paramCustomization);
                }
            }

            writer.WriteLine();
            writer.WriteLine("// allow further manipulation of loaded context prior to processing");
            writer.WriteLine("PostExecutionContextLoad(context);");
        }

        private void WriteContextClass(IndentedTextWriter writer, IEnumerable<SimplePropertyInfo> properties)
        {
            writer.WriteLine("internal partial class CmdletContext : ExecutorContext");
            writer.OpenRegion();

            // Note that the context class member types match the inner SDK request field types - remapping
            // from List<T> to T[] is only done at the cmdlet parameter level. This keeps the executor code
            // simpler. Properties that should only be populated if the associated parameter was specified
            // are emitted as nullable types.
            foreach (var property in properties.Where(property => !OperationAnalyzer.IsExcludedParameter(property.AnalyzedName, ServiceConfig, Operation)))
            {
                writer.WriteLine("public {0}{1} {2} {{ get; set; }}", 
                                  GetPropertyTypeToEmit(property), 
                                  property.UseParameterValueOnlyIfBound ? "?" : "",
                                  property.ContextParameterName);
            }

            writer.CloseRegion();
        }

        /// <summary>
        /// Writes an IExecutor implementation for a cmdlet that does not support iterable output.
        /// This is the only writer that handles -PassThru generation if requested (since by definition 
        /// cmdlets that output iterable content do not require -PassThru).
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="operationAnalysis"></param>
        /// <param name="rootSimpleProperties"></param>
        private void WriteIExecutor(IndentedTextWriter writer,
                                    OperationAnalyzer operationAnalysis,
                                    IEnumerable<SimplePropertyInfo> rootSimpleProperties)
        {
            var methodName = operationAnalysis.MethodName;
            var requestType = operationAnalysis.RequestType;

            writer.WriteLine("public object Execute(ExecutorContext context)");
            writer.OpenRegion();
            {
                WriteMemoryStreamVariableInitializers(writer, operationAnalysis);

                {
                    writer.WriteLine("var cmdletContext = context as CmdletContext;");

                    writer.WriteLine("// create request");
                    writer.WriteLine("var request = new {0}();", OperationAnalyzer.GetValidTypeName(requestType, ServiceConfig));
                    writer.WriteLine();

                    foreach (var simpleProperty in rootSimpleProperties)
                    {
                        WriteContextObjectPopulation(writer, operationAnalysis, simpleProperty, "request." + simpleProperty.Name);
                    }

                    writer.WriteLine();
                    //writer.WriteLine("ServiceCalls.PushServiceRequest(request, this.MyInvocation);");
                    writer.WriteLine("CmdletOutput output;");

                    writer.WriteLine();
                    writer.WriteLine("// issue call");

                    if (Operation.RequiresAnonymousAuthentication)
                        writer.WriteLine("var client = Client ?? CreateClient(context.Region);");
                    else
                        writer.WriteLine("var client = Client ?? CreateClient(context.Credentials, context.Region);");

                    writer.WriteLine("try");
                    writer.OpenRegion();
                    writer.WriteLine("var response = CallAWSServiceOperation(client, request);");
                    WriteResultOutput(writer, operationAnalysis, Options.BreakOnOutputMismatchError);
                    writer.CloseRegion();
                    writer.WriteLine("catch (Exception e)");
                    writer.OpenRegion();
                    writer.WriteLine("output = new CmdletOutput { ErrorResponse = e };");
                    writer.CloseRegion();

                    writer.WriteLine();
                    writer.WriteLine("return output;");
                }

                WriteMemoryStreamVariableCleanup(writer, operationAnalysis, true);
            }

            writer.CloseRegion();
        }

        /// <summary>
        /// Writes an IExecutor implementation compatible with auto-iteration pattern 1
        /// (use page marker tokens, iterate until itrNext is empty; 
        /// 'AutoIterate StartMarker="NextToken" NextMarker="NextToken"').
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="operationAnalysis"></param>
        /// <param name="rootSimpleProperties"></param>
        private void WriteIExecutorIterPattern1(IndentedTextWriter writer, OperationAnalyzer operationAnalysis, IEnumerable<SimplePropertyInfo> rootSimpleProperties)
        {
            var methodName = operationAnalysis.MethodName;
            var analyzedResult = operationAnalysis.AnalyzedResult;
            var requestType = operationAnalysis.RequestType;
            var autoIteration = operationAnalysis.AutoIterateSettings;

            writer.WriteLine("public object Execute(ExecutorContext context)");
            writer.OpenRegion();
            {
                WriteMemoryStreamVariableInitializers(writer, operationAnalysis);

                {
                    writer.WriteLine("var cmdletContext = context as CmdletContext;");
                    writer.WriteLine();

                    writer.WriteLine("// create request and set iteration invariants");
                    writer.WriteLine("var request = new {0}();", OperationAnalyzer.GetValidTypeName(requestType, ServiceConfig));
                    writer.WriteLine();

                    string iteratorType = string.Empty;
                    // emit non-iterator properties
                    foreach (var simpleProperty in rootSimpleProperties)
                    {
                        if (simpleProperty.Name.Equals(autoIteration.Start, StringComparison.Ordinal))
                        {
                            iteratorType = simpleProperty.PropertyTypeName;
                            continue;
                        }

                        WriteContextObjectPopulation(writer, operationAnalysis, simpleProperty, "request." + simpleProperty.Name);
                    }

                    writer.WriteLine();

                    writer.WriteLine("// Initialize loop variant and commence piping");
                    writer.WriteLine("{0} _nextMarker = null;", iteratorType);
                    writer.WriteLine("bool _userControllingPaging = false;");
                    writer.WriteLine("if (AutoIterationHelpers.HasValue(cmdletContext.{0}))", autoIteration.Start);
                    writer.OpenRegion();
                    {
                        writer.WriteLine("_nextMarker = cmdletContext.{0};", autoIteration.Start);
                        writer.WriteLine("_userControllingPaging = true;");
                    }
                    writer.CloseRegion();
                    writer.WriteLine();

                    writer.WriteLine("try");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("do");
                        writer.OpenRegion();
                        {
                            writer.WriteLine("request.{0} = _nextMarker;", autoIteration.Start);
                            writer.WriteLine();

                            if (Operation.RequiresAnonymousAuthentication)
                                writer.WriteLine("var client = Client ?? CreateClient(context.Region);");
                            else
                                writer.WriteLine("var client = Client ?? CreateClient(context.Credentials, context.Region);");

                            writer.WriteLine("CmdletOutput output;");

                            writer.WriteLine();
                            writer.WriteLine("try");
                            writer.OpenRegion();
                            {
                                //writer.WriteLine("ServiceCalls.PushServiceRequest(request, this.MyInvocation);");
                                writer.WriteLine();

                                writer.WriteLine("var response = CallAWSServiceOperation(client, request);");
                                writer.WriteLine();

                                WriteResultOutput(writer, operationAnalysis, Options.BreakOnOutputMismatchError);

                                // Most if not all collections are marshalled as List<T>, so assume we have a Count
                                // property available (if not, compile will break post-generation and we can investigate).
                                // Note that we only emit progress indicators if we are manually paging which we detect
                                // by the presence of an input marker; PowerShell ISE has an issue where the repeated progress 
                                // output when in a tight loop in user script bogs down the environment to the point of 
                                // non-responsiveness (doesn't happen in console shell)
                                writer.WriteLine("if (_userControllingPaging)");
                                writer.OpenRegion();
                                writer.WriteLine("int _receivedThisCall = response.{0}.Count;", analyzedResult.SingleResultProperty.Name);
                                writer.WriteLine("WriteProgressRecord(\"Retrieving\", string.Format(\"Retrieved {{0}} records starting from marker '{{1}}'\", _receivedThisCall, request.{0}));",
                                                 autoIteration.Start);
                                writer.CloseRegion();

                                writer.WriteLine();
                                writer.WriteLine("_nextMarker = response.{0};", autoIteration.Next);
                            }
                            writer.CloseRegion();
                            writer.WriteLine("catch (Exception e)");
                            writer.OpenRegion();
                            {
                                writer.WriteLine("output = new CmdletOutput { ErrorResponse = e };");
                            }
                            writer.CloseRegion();

                            writer.WriteLine();
                            writer.WriteLine("ProcessOutput(output);");
                            writer.WriteLine();
                        }
                        writer.CloseRegion("} while (AutoIterationHelpers.HasValue(_nextMarker));");
                    }
                }
                writer.CloseRegion();

                writer.WriteLine("finally");
                writer.OpenRegion();
                {
                    writer.WriteLine("if (_userControllingPaging)");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("WriteProgressCompleteRecord(\"Retrieving\", \"Retrieved records\");");
                    }
                    writer.CloseRegion();

                    WriteMemoryStreamVariableCleanup(writer, operationAnalysis, false);
                }
                writer.CloseRegion();

                writer.WriteLine();
                writer.WriteLine("return null;");
            }

            writer.CloseRegion();
        }

        /// <summary>
        /// Writes an IExecutor implementation compatible with auto-iteration pattern 2
        /// (use page marker tokens and ability to control total data size; iterate until 'next token' is empty;
        /// 'AutoIterate EmitLimit="MaxRecords" StartMarker="Marker" NextMarker="Marker"')
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="operationAnalysis"></param>
        /// <param name="rootSimpleProperties"></param>
        private void WriteIExecutorIterPattern2(IndentedTextWriter writer, OperationAnalyzer operationAnalysis, IEnumerable<SimplePropertyInfo> rootSimpleProperties)
        {
            var methodName = operationAnalysis.MethodName;
            var analyzedResult = operationAnalysis.AnalyzedResult;
            var requestType = operationAnalysis.RequestType;
            var autoIteration = operationAnalysis.AutoIterateSettings;
            var pageSizeSet = (autoIteration.ServicePageSize != -1);

            writer.WriteLine("public object Execute(ExecutorContext context)");
            writer.OpenRegion();
            {
                WriteMemoryStreamVariableInitializers(writer, operationAnalysis);

                {
                    writer.WriteLine("var cmdletContext = context as CmdletContext;");
                    writer.WriteLine();

                    writer.WriteLine("// create request and set iteration invariants");
                    writer.WriteLine("var request = new {0}();", OperationAnalyzer.GetValidTypeName(requestType, ServiceConfig));

                    string iteratorType = string.Empty;
                    string iteratorLimitType = string.Empty;

                    // emit non-iterator properties
                    foreach (var simpleProperty in rootSimpleProperties)
                    {
                        if (simpleProperty.Name.Equals(autoIteration.Start, StringComparison.Ordinal))
                        {
                            iteratorType = simpleProperty.PropertyTypeName;
                            continue;
                        }

                        if (simpleProperty.Name.Equals(autoIteration.EmitLimit, StringComparison.Ordinal))
                        {
                            //iteratorLimitType = simpleProperty.PropertyTypeName;
                            //iteratorLimitType = iteratorLimitType.Trim('?');
                            iteratorLimitType = simpleProperty.PropertyType.Name;
                            continue;
                        }

                        WriteContextObjectPopulation(writer, operationAnalysis, simpleProperty, "request." + simpleProperty.Name);
                    }

                    writer.WriteLine();
                    writer.WriteLine("// Initialize loop variants and commence piping");
                    writer.WriteLine("{0} _nextMarker = null;", iteratorType);
                    writer.WriteLine("int? _emitLimit = null;");
                    writer.WriteLine("int _retrievedSoFar = 0;");
                    if (pageSizeSet)
                        writer.WriteLine("int? _pageSize = {0};", autoIteration.ServicePageSize.ToString());

                    //writer.WriteLine("{0}{1} _emitLimit = null;", iteratorLimitType, iteratorLimitType.EndsWith("?") ? string.Empty : "?");
                    //writer.WriteLine("{0} _retrievedSoFar = 0;", iteratorLimitType);
                    writer.WriteLine("if (AutoIterationHelpers.HasValue(cmdletContext.{0}))", autoIteration.Start);
                    writer.OpenRegion();
                    {
                        writer.WriteLine("_nextMarker = cmdletContext.{0};", autoIteration.Start);
                    }
                    writer.CloseRegion();
                    writer.WriteLine("if (AutoIterationHelpers.HasValue(cmdletContext.{0}))", autoIteration.EmitLimit);
                    writer.OpenRegion();
                    {
                        if (pageSizeSet)
                        {
                            writer.WriteLine("// The service has a maximum page size of {0}. If the user has", autoIteration.ServicePageSize);
                            writer.WriteLine("// asked for more items than page max, and there is no page size");
                            writer.WriteLine("// configured, we rely on the service ignoring the set maximum");
                            writer.WriteLine("// and giving us {0} items back. If a page size is set, that will", autoIteration.ServicePageSize);
                            writer.WriteLine("// be used to configure the pagination.");
                            writer.WriteLine("// We'll make further calls to satisfy the user's request.");
                        }
                        writer.WriteLine("_emitLimit = cmdletContext.{0};", autoIteration.EmitLimit);
                    }
                    writer.CloseRegion();

                    writer.WriteLine("bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.{0}) || AutoIterationHelpers.HasValue(cmdletContext.{1});",
                                     autoIteration.Start,
                                     autoIteration.EmitLimit);

                    writer.WriteLine("bool _continueIteration = true;"); // allows us to bomb out if we retrieve nothing
                    writer.WriteLine();

                    writer.WriteLine("try");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("do");
                        writer.OpenRegion();
                        {
                            writer.WriteLine("request.{0} = _nextMarker;", autoIteration.Start);
                            writer.WriteLine("if (AutoIterationHelpers.HasValue(_emitLimit))");
                            writer.OpenRegion();
                            {
                                writer.WriteLine("request.{0} = AutoIterationHelpers.ConvertEmitLimitTo{1}(_emitLimit.Value);",
                                                    autoIteration.EmitLimit,
                                                    iteratorLimitType);
                            }
                            writer.CloseRegion();
                            writer.WriteLine();

                            if (pageSizeSet)
                            {
                                writer.WriteLine("if (AutoIterationHelpers.HasValue(_pageSize))");
                                writer.OpenRegion();
                                {
                                    writer.WriteLine("int correctPageSize;");
                                    writer.WriteLine("if (AutoIterationHelpers.IsSet(request.{0}))", autoIteration.EmitLimit);
                                    writer.OpenRegion();
                                    {
                                        writer.WriteLine("correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.{0});", autoIteration.EmitLimit);
                                    }
                                    writer.CloseRegion();
                                    writer.WriteLine("else");
                                    writer.OpenRegion();
                                    {
                                        writer.WriteLine("correctPageSize = _pageSize.Value;", autoIteration.EmitLimit);
                                    }
                                    writer.CloseRegion();

                                    writer.WriteLine("request.{0} = AutoIterationHelpers.ConvertEmitLimitTo{1}(correctPageSize);", autoIteration.EmitLimit, iteratorLimitType);
                                }
                                writer.CloseRegion();
                                writer.WriteLine();
                            }

                            if (Operation.RequiresAnonymousAuthentication)
                                writer.WriteLine("var client = Client ?? CreateClient(context.Region);");
                            else
                                writer.WriteLine("var client = Client ?? CreateClient(context.Credentials, context.Region);");

                            writer.WriteLine("CmdletOutput output;");

                            writer.WriteLine();
                            writer.WriteLine("try");
                            writer.OpenRegion();
                            {
                                //writer.WriteLine("ServiceCalls.PushServiceRequest(request, this.MyInvocation);");
                                writer.WriteLine();

                                writer.WriteLine("var response = CallAWSServiceOperation(client, request);");
                                WriteResultOutput(writer, operationAnalysis, Options.BreakOnOutputMismatchError);

                                // most if not all collections are marshalled as List<T>, so assume we have a Count
                                // property available (if not, compile will break post-generation and we can investigate)
                                // Note that we only emit progress indicators if we are manually paging which we detect
                                // by the presence of an input marker or a max count; PowerShell ISE has an issue where 
                                // the repeated progress output when in a tight loop in user script bogs down the 
                                // environment to the point of  non-responsiveness (doesn't happen in console shell)
                                writer.WriteLine("int _receivedThisCall = response.{0}.Count;", analyzedResult.SingleResultProperty.Name);
                                writer.WriteLine("if (_userControllingPaging)");
                                writer.OpenRegion();
                                writer.WriteLine("WriteProgressRecord(\"Retrieving\", string.Format(\"Retrieved {{0}} records starting from marker '{{1}}'\", _receivedThisCall, request.{0}));",
                                                 autoIteration.Start);
                                writer.CloseRegion();

                                writer.WriteLine();
                                writer.WriteLine("_nextMarker = response.{0};", autoIteration.Next);

                                writer.WriteLine();
                                writer.WriteLine("_retrievedSoFar += _receivedThisCall;");

                                writer.WriteLine("if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))");
                                writer.OpenRegion();
                                {
                                    writer.WriteLine("_continueIteration = false;");
                                }
                                writer.CloseRegion();
                            }
                            writer.CloseRegion();
                            writer.WriteLine("catch (Exception e)");
                            writer.OpenRegion();
                            {
                                writer.WriteLine("output = new CmdletOutput { ErrorResponse = e };");
                            }
                            writer.CloseRegion();

                            writer.WriteLine();
                            writer.WriteLine("ProcessOutput(output);");

                            if (pageSizeSet)
                            {
                                writer.WriteLine("// The service has a maximum page size of {0} and the user has set a retrieval limit.", autoIteration.ServicePageSize);
                                writer.WriteLine("// Deduce what's left to fetch and if less than one page update _emitLimit to fetch just");
                                writer.WriteLine("// what's left to match the user's request.");
                                writer.WriteLine();
                                writer.WriteLine("var _remainingItems = _emitLimit - _retrievedSoFar;");
                                writer.WriteLine("if (_remainingItems < _pageSize)");
                                writer.OpenRegion();
                                {
                                    writer.WriteLine("_emitLimit = _remainingItems;");
                                }
                                writer.CloseRegion();
                            }
                        }
                        writer.CloseRegion("} while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));");
                    }

                    writer.WriteLine();
                }
                writer.CloseRegion();

                writer.WriteLine("finally");
                writer.OpenRegion();
                {
                    writer.WriteLine("if (_userControllingPaging)");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("WriteProgressCompleteRecord(\"Retrieving\", \"Retrieved records\");");
                    }
                    writer.CloseRegion();

                    WriteMemoryStreamVariableCleanup(writer, operationAnalysis, false);
                }
                writer.CloseRegion();

                writer.WriteLine();
                writer.WriteLine("return null;");
            }

            writer.CloseRegion();
        }

        /// <summary>
        /// Writes the cmdlet code to set up the output data in the executor, optionally
        /// inspecting for mismatch on the cmdlet output which may indicate a breaking
        /// api change
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="operationAnalysis"></param>
        /// <param name="errorOnAnalyzedResultMismatch"></param>
        private void WriteResultOutput(IndentedTextWriter writer, OperationAnalyzer operationAnalysis, bool errorOnAnalyzedResultMismatch)
        {
            var analyzedResult = operationAnalysis.AnalyzedResult;

            writer.WriteLine("Dictionary<string, object> notes = null;");

            switch (analyzedResult.OutputType)
            {
                case AnalyzedResult.ResultOutputTypes.Empty:
                    {
                        writer.WriteLine("object pipelineOutput = null;");
                        if (operationAnalysis.RequiresPassThruGeneration)
                        {
                            writer.WriteLine("if (this.PassThru.IsPresent)");
                            writer.IncreaseIndent();
                            var passThruExpression = operationAnalysis.CurrentOperation.PassThru != null
                                        ? operationAnalysis.CurrentOperation.PassThru.Expression 
                                        : string.Format("this.{0}", analyzedResult.PassThruParameter.CmdletParameterName);
                            writer.WriteLine("pipelineOutput = {0};", passThruExpression);
                            writer.DecreaseIndent();
                        }

                        if (errorOnAnalyzedResultMismatch)
                        {
                            if (Operation.Output != ServiceOperation.OutputMode.Void)
                            {
                                Logger.LogError(string.Format(
                                    "Method [{0} {1}]: the service response is empty but the ServiceOperation does not contain attribute 'Output=\"Void\"'. THIS MAY BE A BREAKING CHANGE - INVESTIGATE THIS.", 
                                    ServiceConfig.ServiceNounPrefix,
                                    operationAnalysis.MethodName));
                            }
                        }
                        else
                            ServiceConfig.EmptyResultOperations.Add(operationAnalysis.MethodName);
                    }
                    break;

                case AnalyzedResult.ResultOutputTypes.SingleProperty:
                    {
                        writer.WriteLine("object pipelineOutput = response.{0};", analyzedResult.SingleResultProperty.Name);
                        if (analyzedResult.MetadataProperties.Count != 0)
                        {
                            writer.WriteLine("notes = new Dictionary<string, object>();");
                            foreach (var prop in analyzedResult.MetadataProperties)
                            {
                                // still emit all markers in case someone is trying to
                                // do manual paging
                                writer.WriteLine("notes[\"{0}\"] = response.{0};", prop.Name);
                            }
                        }

                        if (errorOnAnalyzedResultMismatch)
                        {
                            if (Operation.Output != ServiceOperation.OutputMode.Default)
                            {
                                Logger.LogError(string.Format(
                                    "Method [{0} {1}]: the service response contains a single property but the ServiceOperation contains the 'Output' attribute with value 'Void' or 'Response'. THIS MAY BE A BREAKING CHANGE - INVESTIGATE THIS.",
                                    ServiceConfig.ServiceNounPrefix, operationAnalysis.MethodName));
                            }
                        }
                        else
                            ServiceConfig.SinglePropertyResultOperations.Add(operationAnalysis.MethodName);
                    }
                    break;

                case AnalyzedResult.ResultOutputTypes.MultiProperty:
                    {
                        writer.WriteLine("object pipelineOutput = response;");

                        if (errorOnAnalyzedResultMismatch)
                        {
                            if (Operation.Output != ServiceOperation.OutputMode.Response)
                            {
                                Logger.LogError(string.Format(
                                    "Method [{0} {1}]: the service response contains more than one property but the ServiceOperation does not contain the attribute 'Output=\"Response\"'. THIS MAY BE A BREAKING CHANGE - INVESTIGATE THIS.",
                                    ServiceConfig.ServiceNounPrefix, operationAnalysis.MethodName));
                            }
                        }
                        else
                            ServiceConfig.MultiPropertyResultOperations.Add(operationAnalysis.MethodName);
                    }
                    break;
            }

            writer.WriteLine("output = new CmdletOutput");
            writer.OpenRegion();
            {
                writer.WriteLine("PipelineOutput = pipelineOutput,");
                writer.WriteLine("ServiceResponse = response,");
                writer.WriteLine("Notes = notes");
            }
            writer.CloseRegion("};");
        }

        private void WriteContextObjectPopulation(IndentedTextWriter writer, OperationAnalyzer operationAnalyzer, SimplePropertyInfo property, string variableName)
        {
            if (property.Children.Count == 0)
            {
                if (operationAnalyzer.IsExcludedParameter(property.AnalyzedName))
                    return;

                var autoIteration = operationAnalyzer.AutoIterateSettings;
                bool isEmitLimiter = false;
                if (autoIteration != null && !autoIteration.ExclusionSet.Contains(operationAnalyzer.CurrentOperation.MethodName))
                    isEmitLimiter = autoIteration.IsEmitLimit(property.Name);

                writer.WriteLine("if (cmdletContext.{0} != null)", property.ContextParameterName);
                writer.OpenRegion();
                {
                    if (isEmitLimiter)
                    {
                        writer.WriteLine("{0} = AutoIterationHelpers.ConvertEmitLimitToServiceType{1}(cmdletContext.{2}.Value);",
                            variableName, property.PropertyType.Name, property.ContextParameterName);
                    }
                    else if (property.IsMemoryStreamType && operationAnalyzer.CurrentOperation.RemapMemoryStreamParameters)
                    {
                        var streamVariableName = BuildMemoryStreamVariableName(property.ContextParameterName);
                        writer.WriteLine("{0} = new System.IO.MemoryStream(cmdletContext.{1});",
                                         streamVariableName,
                                         property.ContextParameterName);
                        writer.WriteLine("{0} = {1};", variableName, streamVariableName);
                    }
                    else
                    {
                        writer.WriteLine(
                            property.PropertyType.IsValueType ? "{0} = cmdletContext.{1}.Value;" : "{0} = cmdletContext.{1};",
                            variableName, property.ContextParameterName);
                    }
                }
                writer.CloseRegion();
            }
            else
            {
                // test for excluding a batch of parameters by common prefix
                if (operationAnalyzer.IsExcludedParameter(property.AnalyzedName + "_"))
                    return;

                writer.WriteLine();
                writer.WriteLine(" // populate {0}", property.Name);
                string usableVariableName = variableName.Replace(".", string.Empty);
                writer.WriteLine("bool {0}IsNull = true;", usableVariableName);
                writer.WriteLine("{0} = new {1}();", variableName, operationAnalyzer.GetValidTypeName(property.PropertyType));

                foreach (var child in property.Children.OrderBy(c => c.Children.Count))
                {
                    var childVariableName = usableVariableName + "_" + OperationAnalyzer.ToLowerCamelCase(child.CmdletParameterName);

                    writer.WriteLine("{0}{1} {2} = null;",
                                     operationAnalyzer.GetValidTypeName(child.PropertyType),
                                     child.UseParameterValueOnlyIfBound ? "?" : "",
                                     childVariableName);
                    WriteContextObjectPopulation(writer, operationAnalyzer, child, childVariableName);

                    writer.WriteLine("if ({0} != null)", childVariableName);
                    writer.OpenRegion();
                    writer.WriteLine(child.PropertyType.IsValueType ? "{0}.{1} = {2}.Value;" : "{0}.{1} = {2};",
                                     variableName, child.Name, childVariableName);
                    writer.WriteLine("{0}IsNull = false;", usableVariableName);
                    writer.CloseRegion();
                }

                writer.WriteLine(" // determine if {0} should be set to null", variableName);
                writer.WriteLine("if ({0}IsNull)", usableVariableName);
                writer.OpenRegion();
                writer.WriteLine("{0} = null;", variableName);
                writer.CloseRegion();
            }
        }

        /// <summary>
        /// Reorders the parameters for the source file so the 'real' parameters come first, in alpha
        /// order for consistency, and metadata/paging properties come last so they dont't clutter tab
        /// expansion in the cli. Properties marked for exclusion are retained at this stage, we 
        /// exclude them during the actual write phase.
        /// </summary>
        /// <param name="allProperties"></param>
        /// <param name="serviceOperation"></param>
        /// <returns></returns>
        List<SimplePropertyInfo> OrderParamsForSourceFile(List<SimplePropertyInfo> allProperties, ServiceOperation serviceOperation)
        {
            var orderedParams = new List<SimplePropertyInfo>();
            var deferToEnd = new List<SimplePropertyInfo>();

            Func<SimplePropertyInfo, bool> isMetadataProperty = p =>
                        MethodAnalysis.AllModels.MetadataPropertyNames.Contains(p.Name) ||
                        ServiceConfig.MetadataPropertyNames.Contains(p.Name) ||
                        serviceOperation.MetadataPropertiesList.Contains(p.Name);
            var metadataProperties = allProperties.Where(isMetadataProperty).ToList();

            foreach (var property in allProperties.OrderBy(p => p.Name))
            {
                if (metadataProperties.Contains(property))
                {
                    deferToEnd.Add(property);
                    continue;
                }

                orderedParams.Add(property);
            }

            orderedParams.AddRange(deferToEnd.OrderBy(p => p.Name));
            return orderedParams;
        }

        IEnumerable<IParamEmitter> FindGlobalParamEmitters()
        {
            // Global param emitters do not have any mapping to param name or param type
            var emitters = ServiceConfig.GlobalInjectionParamEmitters;

            var emitterInstances = new List<IParamEmitter>();
            foreach (var item in emitters)
            {
                // Check if the emitter is excluded for the current cmdlet
                if (!string.IsNullOrEmpty(item.Exclude))
                {
                    var excludedMethods = item.Exclude.Split(';');
                    if (excludedMethods.Any(m => m.Equals(this.Operation.MethodName, StringComparison.Ordinal)))
                        continue;
                }

                var obj = Activator.CreateInstance(null, "AWSPowerShellGenerator." + item.EmitterType);
                emitterInstances.Add((IParamEmitter)obj.Unwrap());
            }
            return emitterInstances;
        }

        /// <summary>
        /// Queries the existence of a custom parameter emitter for the specified property,
        /// returning an instance of the emitter if one has been specified.
        /// </summary>
        /// <param name="property">The property parameter being generated</param>
        /// <returns>Null if no custom emitter has been specified, otherwise the emitter instance</returns>
        IParamEmitter FindCustomEmitterForParam(SimplePropertyInfo property)
        {
            // first stage lookup, for precise type and parameter naming (allows us
            // to handle custom emitters for properties like 'string BucketName'); 
            // we do need to drop the assembly info though for types
            string k = ConstructCustomParamEmitterKey(property);
            if (ServiceConfig.TypeSpecificParamEmitters.ContainsKey(k))
            {
                var obj = Activator.CreateInstance(null, "AWSPowerShellGenerator." + ServiceConfig.TypeSpecificParamEmitters[k]);
                return (IParamEmitter)obj.Unwrap();
            }

            // second stage lookup, more generic emitter based on type only (useful
            // for specific type smoothing, eg replace enums with strings etc)
            if (ServiceConfig.TypeSpecificParamEmitters.ContainsKey(property.PropertyType.FullName))
            {
                var obj = Activator.CreateInstance(null, "AWSPowerShellGenerator." + ServiceConfig.TypeSpecificParamEmitters[property.PropertyType.FullName]);
                return (IParamEmitter)obj.Unwrap();
            }

            // third stage lookup, useful with List<T> types
            if (ServiceConfig.TypeSpecificParamEmitters.ContainsKey(property.PropertyTypeName))
            {
                var obj = Activator.CreateInstance(null, "AWSPowerShellGenerator." + ServiceConfig.TypeSpecificParamEmitters[property.PropertyTypeName]);
                return (IParamEmitter)obj.Unwrap();
            }

            return null;
        }

        static string ConstructCustomParamEmitterKey(SimplePropertyInfo property)
        {
            string propertyTypeName;
            if (property.PropertyType.IsGenericType)
            {
                var genericTypes = property.PropertyType.GetGenericArguments();
                // right now all our emitters are single types, but allow for the case
                // we might want to detect multiple generic args in future
                var sb = new StringBuilder(property.PropertyType.Namespace);
                sb.AppendFormat(".{0}<", property.PropertyType.Name);
                for (var i = 0; i < genericTypes.Length; i++)
                {
                    if (i > 0)
                        sb.Append("#");
                    sb.Append(genericTypes[i].FullName);
                }
                sb.Append(">");
                propertyTypeName = sb.ToString();
            }
            else
            {
                propertyTypeName = property.PropertyType.FullName;
            }

            return string.Format(ConfigModel.ParamEmitterComplexKeyFormat, propertyTypeName, property.Name);
        }

        /// <summary>
        /// If we detected MemoryStream parameter types for the cmdlet, outputs one
        /// stream variable for each parameter that we switched to be a byte[] type.
        /// It then enters an additional try closure so we can clean up the streams
        /// prior to exiting the cmdlet executor.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        void WriteMemoryStreamVariableInitializers(IndentedTextWriter writer, OperationAnalyzer analyzer)
        {
            if (!analyzer.HasMemoryStreamParameters)
                return;

            foreach (var p in analyzer.MemoryStreamParameters)
            {
                writer.WriteLine("System.IO.MemoryStream {0} = null;", BuildMemoryStreamVariableName(p));
            }

            writer.WriteLine();

            writer.WriteLine("try");
            writer.OpenRegion();
        }

        string BuildMemoryStreamVariableName(string contextName)
        {
            return string.Format("_{0}Stream", contextName);
        }

        // pass generateNewFinallyBlock true to wrap the cleanup code inside a finally {} block. If false, the
        // generated code is assumed to already be housed inside such a block.
        void WriteMemoryStreamVariableCleanup(IndentedTextWriter writer, OperationAnalyzer analyzer, bool generateNewFinallyBlock)
        {
            if (!analyzer.HasMemoryStreamParameters)
                return;

            if (generateNewFinallyBlock)
            {
                writer.CloseRegion();
                writer.WriteLine("finally");
                writer.OpenRegion();
            }

            foreach (var p in analyzer.MemoryStreamParameters)
            {
                var variableName = BuildMemoryStreamVariableName(p);
                writer.WriteLine("if( {0} != null)", variableName);
                writer.OpenRegion();
                writer.WriteLine("{0}.Dispose();", variableName);
                writer.CloseRegion();
            }

            if (generateNewFinallyBlock)
            {
                writer.CloseRegion();
            }
        }

        string GetPropertyTypeToEmit(SimplePropertyInfo property)
        {
            return property.IsMemoryStreamType && MethodAnalysis.CurrentOperation.RemapMemoryStreamParameters
                ? MemoryStreamSubstitutionType : property.PropertyTypeName;
        }
    
    }
}
