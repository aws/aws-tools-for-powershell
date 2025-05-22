using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Security;
using System.Text;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Generators.ParamEmitters;
using System.Web;
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

        private readonly ConfigModel ServiceConfig;
        private readonly ServiceOperation Operation;
        private readonly OperationAnalyzer MethodAnalysis;

        private readonly static char[] Vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };

        /// <summary>
        /// Initializes the cmdlet source writer.
        /// </summary>
        /// <param name="analyzer"></param>
        /// <param name="serviceDisplayName"></param>
        /// <param name="options"></param>
        public CmdletSourceWriter(OperationAnalyzer analyzer,
                                  GeneratorOptions options)
        {
            MethodAnalysis = analyzer;
            ServiceConfig = analyzer.CurrentModel;
            Operation = analyzer.CurrentOperation;

            Options = options;
        }

        /// <summary>
        /// Writes the source code file for the cmdlet implementing a service operation.
        /// </summary>
        /// <param name="writer"></param>
        public void Write(IndentedTextWriter writer)
        {
            var analyzedResult = MethodAnalysis.AnalyzedResult;
            var autoIteration = MethodAnalysis.AutoIterateSettings;

            var customParamEmitters = new List<IParamEmitter>();

            var methodInfo = MethodAnalysis.Method;
            var methodDocumentation = DocumentationUtils.GetMethodDocumentation(methodInfo.DeclaringType, Operation.MethodName, MethodAnalysis.AssemblyDocumentation);

            if (autoIteration != null)
            {
                methodDocumentation +=
                    $"<br/><br/>{(Operation.LegacyPagination == ServiceOperation.LegacyPaginationType.DisablePagination ? $"In the AWS.Tools.{ServiceConfig.AssemblyName} module, t" : "T")}his cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.";

                if (autoIteration.SupportLegacyAutoIterationMode)
                {
                    methodDocumentation += " This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.";
                }
            }

            if (GetOperationObsoleteMessage(methodInfo) != null)
                methodDocumentation += "<br/><br/>This operation is deprecated.";

            var commentedTypeDocumentation = DocumentationUtils.CommentDocumentation(methodDocumentation);

            WriteSourceLicenseHeader(writer);
            WriteNamespaces(writer, ServiceConfig.ServiceNamespace);

            writer.WriteLine();

            // Adds pragma warning to all files to disable deprecated and obsolete compiler warning similar to .net sdk. 
            writer.WriteLine("#pragma warning disable CS0618, CS0612");
            writer.WriteLine($"namespace Amazon.PowerShell.Cmdlets.{ServiceConfig.ServiceNounPrefix}");
            writer.OpenRegion();
            {
                writer.WriteLine(commentedTypeDocumentation);
                writer.WriteLine($"[Cmdlet(\"{Operation.SelectedVerb}\", \"{Operation.SelectedNoun}\"{(MethodAnalysis.RequiresShouldProcessPromt ? $", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.{MethodAnalysis.ConfirmImpactSetting}" : "")}{(Operation.DefaultParameterSet != null ? $", DefaultParameterSetName=\"{Operation.DefaultParameterSet}\"" : "")})]");

                // Define the output type so that running Get-Command on the cmdlet has a populated OutputType
                // value (this is independant of help). Use the string format of the attr so we don't risk
                // namespace collisions on collection members (eg EMR and PowerShell both have 'Job' classes)
                if (analyzedResult.ReturnType != null)
                {
                    WriteOutputTypeAttribute(writer, OperationAnalyzer.FormatTypeName(analyzedResult.ReturnType));
                }
                else
                {
                    WriteOutputTypeAttribute(writer, "None");
                }

                // the AWSCmdlet* attribs are used for help generation
                WriteAWSCmdletAttributes(writer);

                WriteObsoleteOperationAttribute(writer, methodInfo);

                writer.WriteLine($"public partial class {Operation.SelectedVerb}{Operation.SelectedNoun}Cmdlet : {ServiceConfig.GetServiceCmdletClassName(Operation.RequiresAnonymousAuthentication)}Cmdlet, IExecutor");
                writer.OpenRegion();
                {
                    writer.WriteLine();

                    WriteGeneratedCmdletFlag(writer);

                    writer.WriteLine("private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();");

                    // create cmdlet parameters

                    // we emit the 'real' parameters in alpha order to allow for consistent tabbing
                    // and comparison of changes, but put metadata/paging properties at the end so
                    // they don't come before the real parameters at the console
                    var paramProperties = MethodAnalysis.AnalyzedParameters.Count() > 1
                                              ? OrderParamsForSourceFile()
                                              : MethodAnalysis.AnalyzedParameters;
                    foreach (var property in paramProperties)
                    {
                        var paramCustomization = MethodAnalysis.GetParameterCustomization(property.AnalyzedName);
                        if (paramCustomization != null && paramCustomization.Exclude)
                            continue;

                        // wrap the parameter in a region so that if we need to parse the raw source
                        // file we can easily find them
                        writer.WriteLine();
                        writer.WriteLine($"{ParameterRegionMarker} {property.CmdletParameterName}");
                        var p = FindCustomEmitterForParam(property);
                        if (p == null)
                            WriteParam(writer, property, paramCustomization);
                        else
                        {
                            customParamEmitters.Add(p);
                            p.WriteParams(writer, MethodAnalysis, property, paramCustomization);
                        }
                        writer.WriteLine("#endregion");
                    }

                    // Execute any global parameter emitters for this cmdlet
                    var globalParamEmitters = FindGlobalParamEmitters();
                    foreach (var paramEmitter in globalParamEmitters)
                    {
                        writer.WriteLine();
                        customParamEmitters.Add(paramEmitter);
                        paramEmitter.WriteParams(writer, MethodAnalysis, null, null);
                    }

                    WriteSelectParam(writer);
                    WriteAnonymousCredentialsProperty(writer);
                    WriteForceSwitchParam(writer);
                    WriteNoAutoIterationSwitchParam(writer);

                    writer.WriteLine();

                    writer.WriteLine("protected override void StopProcessing()");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("base.StopProcessing();");
                        writer.WriteLine("_cancellationTokenSource.Cancel();");
                    }
                    writer.CloseRegion();

                    writer.WriteLine("protected override void ProcessRecord()");
                    writer.OpenRegion();
                    {
                        if (Operation.AnonymousAuthentication == ServiceOperation.AnonymousAuthenticationMode.Optional)
                            writer.WriteLine("this._ExecuteWithAnonymousCredentials = this.UseAnonymousCredentials;");

                        writer.WriteLine("base.ProcessRecord();");
                        writer.WriteLine();

                        if (MethodAnalysis.RequiresShouldProcessPromt)
                            WriteShouldProcessConfirmationCalls(writer);

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

                    if (autoIteration != null)
                    {
                        switch (Operation.LegacyPagination)
                        {
                            case ServiceOperation.LegacyPaginationType.DisablePagination:
                                writer.WriteLine("#if MODULAR");
                                WriteIExecutorIterPattern1(writer);
                                writer.WriteLine("#else");
                                WriteIExecutor(writer);
                                writer.WriteLine("#endif");
                                break;
                            case ServiceOperation.LegacyPaginationType.UseEmitLimit:
                                writer.WriteLine("#if MODULAR");
                                WriteIExecutorIterPattern1(writer);
                                writer.WriteLine("#else");
                                WriteIExecutorIterPattern2(writer);
                                writer.WriteLine("#endif");
                                break;
                            case ServiceOperation.LegacyPaginationType.Default:
                                WriteIExecutorIterPattern1(writer);
                                break;
                        }
                    }
                    else
                    {
                        WriteIExecutor(writer);
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
                    WriteContextClass(writer);
                    writer.WriteLine();
                }
                writer.CloseRegion();
            }
            writer.CloseRegion();
        }

        private void WriteGeneratedCmdletFlag(IndentedTextWriter writer)
        {
            writer.WriteLine("protected override bool IsGeneratedCmdlet { get; set; } = true;");
        }

        private void WriteConverters(IndentedTextWriter writer, SimplePropertyInfo property, Param paramCustomization)
        {
            if (paramCustomization?.AutoConvert == Param.AutoConversion.ToBase64)
            {
                writer.WriteLine($"[Amazon.PowerShell.Common.Base64{(property.IsMemoryStreamType ? "Stream" : "String")}ParameterConverter]");
            }
            else if (property.IsMemoryStreamType)
            {
                writer.WriteLine("[Amazon.PowerShell.Common.MemoryStreamParameterConverter]");
            }
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

            writer.WriteLine($"private {MethodAnalysis.ResponseType} CallAWSServiceOperation({ServiceConfig.ServiceClientInterface} client, {MethodAnalysis.RequestType} request)");
            writer.OpenRegion();

            writer.WriteLine($"Utils.Common.WriteVerboseEndpointMessage(this, client.Config, \"{ServiceConfig.ServiceName}\", \"{Operation.MethodName}\");");

            writer.WriteLine("try");
            writer.OpenRegion();

            writer.WriteLine($"return client.{Operation.MethodName}Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();");

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
        private static void WriteOutputTypeAttribute(IndentedTextWriter writer, params string[] typeNames)
        {
            writer.WriteLine($"[OutputType({string.Join(",", typeNames.Select(t => ($"\"{t}\"")))})]");
        }

        private void WriteObsoleteOperationAttribute(IndentedTextWriter writer, MethodInfo methodInfo)
        {
            var obsoleteMessage = GetOperationObsoleteMessage(methodInfo);
            if (obsoleteMessage != null)
            {
                writer.WriteLine($"[System.ObsoleteAttribute({EscapeString(obsoleteMessage)})]");
            }
        }

        private String GetOperationObsoleteMessage(MethodInfo methodInfo)
        {
            return Operation.ReplacementObsoleteMessage ??
                methodInfo.GetCustomAttributes(typeof(ObsoleteAttribute), false).Cast<ObsoleteAttribute>().FirstOrDefault()?.Message;
        }

        private void WriteAWSCmdletAttributes(IndentedTextWriter writer)
        {
            var synopsis = new StringBuilder();
            synopsis.Append($"Calls the {ServiceConfig.ServiceName} {Operation.MethodName} API operation.");
            if (Operation.RequiresAnonymousAuthentication)
                synopsis.Append(" This operation uses anonymous authentication and does not require credential parameters to be supplied.");

            writer.WriteLine($"[AWSCmdlet(\"{synopsis}\", Operation = new[] {{\"{Operation.MethodName}\"}}, SelectReturnType = typeof({MethodAnalysis.ResponseType.FullName}){(string.IsNullOrEmpty(Operation.LegacyAlias) ? "" : $", LegacyAlias=\"{Operation.LegacyAlias}\"")})]");

            var analyzedResult = MethodAnalysis.AnalyzedResult;
            string returnTypeName;
            if (analyzedResult.ReturnType != null)
            {
                returnTypeName = OperationAnalyzer.FormatTypeName(analyzedResult.ReturnType);
                if (analyzedResult.ReturnType != MethodAnalysis.ResponseType)
                {
                    returnTypeName += " or " + OperationAnalyzer.FormatTypeName(MethodAnalysis.ResponseType);
                }
            }
            else
            {
                returnTypeName = "None or " + OperationAnalyzer.FormatTypeName(MethodAnalysis.ResponseType);
            }

            writer.WriteLine($"[AWSCmdletOutput(\"{returnTypeName}\",");
            writer.IncreaseIndent();
            {
                if (analyzedResult.ReturnType == null)
                {
                    writer.WriteLine("\"This cmdlet does not generate any output.\" +");
                }

                if (Operation.OutputProperty == null)
                {
                    var type = SecurityElement.Escape(OperationAnalyzer.GetValidTypeName(MethodAnalysis.ResponseType, ServiceConfig));
                    writer.WriteLine($"\"The service response (type {type}) be returned by specifying '-Select *'.\"");
                }
                else if (Operation.OutputProperty == "*")
                {
                    var type = SecurityElement.Escape(OperationAnalyzer.GetValidTypeName(analyzedResult.ReturnType, ServiceConfig));
                    writer.WriteLine($"\"This cmdlet returns {GetIndefiniteArticle(type)} {type} object containing multiple properties.\"");
                }
                else
                {
                    if (analyzedResult.SingleResultProperty.GenericCollectionTypes != null)
                    {
                        writer.WriteLine($"\"This cmdlet returns a collection of {OperationAnalyzer.GetValidTypeName(analyzedResult.ReturnType, ServiceConfig)} objects.\",");
                    }
                    else
                    {
                        var returnType = OperationAnalyzer.GetValidTypeName(analyzedResult.ReturnType, ServiceConfig);
                        writer.WriteLine($"\"This cmdlet returns {GetIndefiniteArticle(returnType)} {returnType} object.\",");
                    }

                    var type = SecurityElement.Escape(OperationAnalyzer.GetValidTypeName(MethodAnalysis.ResponseType, ServiceConfig));
                    writer.Write($"\"The service call response (type {type}) can be returned by specifying '-Select *'.\"");

                    writer.WriteLine();
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
        private void WriteShouldProcessConfirmationCalls(IndentedTextWriter writer)
        {
            if (!string.IsNullOrEmpty(Operation.ShouldProcessTarget))
            {
                var targetParameter = MethodAnalysis.AnalyzedParameters.Where(parameter => parameter.AnalyzedName == Operation.ShouldProcessTarget).Single();

                writer.WriteLine($"var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.{targetParameter.CmdletParameterName}), MyInvocation.BoundParameters);");
            }
            else
            {
                writer.WriteLine("var resourceIdentifiersText = string.Empty;");
            }
            writer.WriteLine($"if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, \"{MethodAnalysis.FormattedOperationForConfirmationMsg}\"))");
            writer.OpenRegion();
            writer.WriteLine("return;");
            writer.CloseRegion();
            writer.WriteLine();
        }

        /// <summary>
        /// Writes documentation + attributed property field for a parameter. Returns the positional
        /// placement of the parameter, if applied.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="property"></param>
        /// <param name="paramCustomization"></param>
        /// <param name="usedPositionalCount"></param>
        public void WriteParam(IndentedTextWriter writer,
                               SimplePropertyInfo property,
                               Param paramCustomization)
        {
            var paramDoc = paramCustomization?.ParameterReplacementDocumentation ?? property.MemberDocumentation;
            if (MethodAnalysis.AutoIterateSettings?.Start == property.Name)
            {
                paramDoc += Environment.NewLine + "<para>" +
                            Environment.NewLine + $"<br/><b>Note:</b> {(Operation.LegacyPagination == ServiceOperation.LegacyPaginationType.DisablePagination ? "In the AWS.Tools." + ServiceConfig.AssemblyName + " module, t" : "T")}his parameter is only used if you are manually controlling output pagination of the service API call." +
                            Environment.NewLine + $"<br/>'{property.CmdletParameterName}' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-{property.CmdletParameterName}' to null for the first call then set the '{property.CmdletParameterName}' using the same property output from the previous call for subsequent calls." +
                            Environment.NewLine + "</para>";
            }
            else if (MethodAnalysis.AutoIterateSettings?.EmitLimit == property.Name)
            {
                paramDoc += Environment.NewLine + "<para>" +
                            Environment.NewLine + "<br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet." +
                            Environment.NewLine + "<br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call." +
                            Environment.NewLine + "<br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned." +
                            Environment.NewLine + "</para>";
            }

            if (paramCustomization?.AutoConvert == Param.AutoConversion.ToBase64)
            {
                paramDoc += Environment.NewLine + "<para>The cmdlet will automatically convert the supplied parameter to Base64 before supplying to the service.</para>";
            }

            if (property.IsStreamType)
            {
                if (property.IsMemoryStreamType)
                {
                    paramDoc += Environment.NewLine + "<para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>";
                }
                else
                {
                    paramDoc += Environment.NewLine + "<para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>";
                }
            }

            if (!string.IsNullOrEmpty(property?.DefaultValue))
            {
                paramDoc += Environment.NewLine + $"<para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>{property.DefaultValue}</b>'.</para>";
            }

            if (property.IsDeprecated)
            {
                paramDoc += Environment.NewLine + "<para>This parameter is deprecated.</para>";
            }

            writer.WriteLine(DocumentationUtils.CommentDocumentation(paramDoc));
            WriteParamProperty(writer, property, paramCustomization);
        }

        /// <summary>
        /// For cmdlets that have the ShouldSupportProcess attribution, adds a standard 'Force' switch
        /// parameter so the user can override the confirmation prompting
        /// </summary>
        /// <param name="writer"></param>
        public void WriteForceSwitchParam(IndentedTextWriter writer)
        {
            if (!MethodAnalysis.RequiresShouldProcessPromt)
            {
                return;
            }

            // wrap the parameter in a region so that if we need to parse the raw source
            // file we can easily find them
            writer.WriteLine();
            writer.WriteLine("#region Parameter Force");
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// This parameter overrides confirmation prompts to force ");
            writer.WriteLine("/// the cmdlet to continue its operation. This parameter should always");
            writer.WriteLine("/// be used with caution.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]");
            writer.WriteLine("public SwitchParameter Force { get; set; }");
            writer.WriteLine("#endregion");
        }

        public void WriteNoAutoIterationSwitchParam(IndentedTextWriter writer)
        {
            var autoIteration = MethodAnalysis.AutoIterateSettings;

            if (autoIteration == null)
            {
                return;
            }

            var startProperty = MethodAnalysis.RequestProperties
                .Where(simpleProperty => simpleProperty.Name == MethodAnalysis.AutoIterateSettings.Start)
                .SingleOrDefault();

            // wrap the parameter in a region so that if we need to parse the raw source
            // file we can easily find them
            writer.WriteLine();
            writer.WriteLine("#region Parameter NoAutoIteration");
            if (Operation.LegacyPagination == ServiceOperation.LegacyPaginationType.DisablePagination)
            {
                writer.WriteLine("#if MODULAR");
            }
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple");
            writer.WriteLine($"/// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of {startProperty.CmdletParameterName}");
            writer.WriteLine("/// as the start point.");
            if (autoIteration.SupportLegacyAutoIterationMode)
            {
                writer.WriteLine("/// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.");
            }

            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]");
            writer.WriteLine("public SwitchParameter NoAutoIteration { get; set; }");
            if (Operation.LegacyPagination == ServiceOperation.LegacyPaginationType.DisablePagination)
            {
                writer.WriteLine("#endif");
            }
            writer.WriteLine("#endregion");
        }

        public void WriteSelectParam(IndentedTextWriter writer)
        {
            // wrap the parameter in a region so that if we need to parse the raw source
            // file we can easily find them
            writer.WriteLine();
            writer.WriteLine("#region Parameter Select");
            writer.WriteLine("/// <summary>");
            if (Operation.OutputProperty != null)
            {
                writer.WriteLine($"/// Use the -Select parameter to control the cmdlet output. The default value is '{Operation.OutputProperty}'.");
            }
            else // if the operation result has no properties, the cmdlet returns void by default, instead of the response. This allow changing
            {    // the OutputProperty later if properties are added to the result class.
                writer.WriteLine($"/// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.");
            }
            writer.WriteLine($"/// Specifying -Select '*' will result in the cmdlet returning the whole service response ({MethodAnalysis.ResponseType.FullName}).");
            if (Operation.OutputProperty != null)
            {
                writer.WriteLine($"/// Specifying the name of a property of type {MethodAnalysis.ResponseType.FullName} will result in that property being returned.");
            }
            writer.WriteLine($"/// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]");
            writer.WriteLine($"public string Select {{ get; set; }} = \"{Operation.OutputProperty ?? "*"}\";");
            writer.WriteLine("#endregion");
        }

        /// <summary>
        /// Adds a "UseAnonymousCredentials" parameter to cmdlets which support
        /// anonymous calls.
        /// </summary>
        /// <param name="writer"></param>
        private void WriteAnonymousCredentialsProperty(IndentedTextWriter writer)
        {
            if (Operation.AnonymousAuthentication != ServiceOperation.AnonymousAuthenticationMode.Optional)
            {
                return;
            }

            // not the same semantics as the 'Anonymous' attribute - this adds a specific parameter the
            // user can employ to force anonymous auth on cmdlets that support both modes. The Anonymous
            // attribute is used to mark cmdlets that are always anonymous.

            // wrap the parameter in a region so that if we need to parse the raw source
            // file we can easily find them
            writer.WriteLine();
            writer.WriteLine("#region Parameter UseAnonymousCredentials");
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// If set, the cmdlet calls the service operation using anonymous credentials.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]");
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
        public void WriteParamProperty(IndentedTextWriter writer, SimplePropertyInfo property, Param paramCustomization)
        {
            WriteParamAttribute(writer, MethodAnalysis, property, paramCustomization);
            WriteParamAliases(writer, MethodAnalysis, property);
            WriteConverters(writer, property, paramCustomization);

            if (property.IsConstrainedToSet)
            {
                // apply our marker attribute so that if the cmdlet ever becomes hand-maintained the
                // generator can detect and update the argument completer for the set members by simple
                // text parsing
                writer.WriteLine($"[{AWSConstantClassSourceAttributeName}(\"{property.PropertyTypeName}\")]");
            }

            if (property.CollectionType == SimplePropertyInfo.PropertyCollectionType.NoCollection || property.GenericCollectionTypes == null)
            {
                writer.WriteLine($"public {GetPropertyTypeToEmit(property)}{(property.UseParameterValueOnlyIfBound ? "?" : "")} {property.CmdletParameterName} {{ get; set; }}");
            }
            else
            {
                // simplest to always emit types with full name, especially as some SDK types can collide with framework
                switch (property.CollectionType)
                {
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericList:
                        {
                            writer.WriteLine($"public {property.GenericCollectionTypes[0].FullName}[] {property.CmdletParameterName} {{ get; set; }}");
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary:
                        {
                            // HashTable is the underlying hash type for PS and more convenient to emit as the param
                            // type as users can then use inline hash syntax @{key=value, key=value} to populate
                            writer.WriteLine($"public System.Collections.Hashtable {property.CmdletParameterName} {{ get; set; }}");
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericList:
                        {
                            writer.WriteLine($"public {property.GenericCollectionTypes[0].FullName}[][] {property.CmdletParameterName} {{ get; set; }}");
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericList:
                        {
                            writer.WriteLine($"public {property.GenericCollectionTypes[0].FullName}[][][] {property.CmdletParameterName} {{ get; set; }}");
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericListOfGenericList:
                        {
                            writer.WriteLine($"public {property.GenericCollectionTypes[0].FullName}[][][][] {property.CmdletParameterName} {{ get; set; }}");
                        }
                        break;
                    case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericDictionary:
                        {
                            writer.WriteLine($"public System.Collections.Hashtable[] {property.CmdletParameterName} {{ get; set; }}");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// The Alias attribute can only be applied only once to a parameter, so gather up all
        /// the aliases, then sort into alpha-order for easier comparison of changes in subsequent
        /// releases before building the attribute declaration
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        /// <param name="property"></param>
        internal static void WriteParamAliases(IndentedTextWriter writer, OperationAnalyzer methodAnalysis, SimplePropertyInfo property)
        {
            var aliases = methodAnalysis.GetAllParameterAliases(property);

            if (aliases.Count > 0)
            {
                // sort the aliases into ascending order so that it's easier to spot
                // changes in version control
                var aliasesString = string.Join(",", aliases
                    .OrderBy(a => a)
                    .Select(a => $"\"{a}\""));
                writer.WriteLine($"[Alias({aliasesString})]");
            }
        }

        /// <summary>
        /// Writes the ParameterAttribute declaration for a parameter.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        /// <param name="property"></param>
        /// <param name="paramCustomization"></param>
        /// <param name="usedPositionalCount"></param>
        public static void WriteParamAttribute(IndentedTextWriter writer, OperationAnalyzer methodAnalysis, SimplePropertyInfo property, Param paramCustomization)
        {
            var paramAttrib = new List<string>();
            var parameterSetNames = new List<string>();

            int paramPos = methodAnalysis.GetParameterPositionData(property.AnalyzedName);

            if (paramPos != -1)
            {
                paramAttrib.Add($"Position = {paramPos}");
            }

            paramAttrib.Add("ValueFromPipelineByPropertyName = true");

            if (methodAnalysis.CanAcceptValueFromPipeline(property.AnalyzedName))
            {
                paramAttrib.Add("ValueFromPipeline = true");
            }

            if (!string.IsNullOrWhiteSpace(paramCustomization?.ParameterSetName))
            {
                parameterSetNames = paramCustomization.ParameterSetName.Split(';').Where(p => !string.IsNullOrWhiteSpace(p)).ToList();
            }

            if (paramCustomization?.Mandatory ?? false && property.DefaultValue == null)
            {
                paramAttrib.Add("Mandatory = true");
            }

            if (property.IsRecursivelyRequired && !(paramCustomization?.Mandatory ?? false) && property.DefaultValue == null)
            {
                writer.WriteLine("#if !MODULAR");
                WriteParamAttributeWithParameterSetNames(writer, paramAttrib, parameterSetNames);
                writer.WriteLine("#else");
                paramAttrib.Add("Mandatory = true");
                WriteParamAttributeWithParameterSetNames(writer, paramAttrib, parameterSetNames);
                if (property.PropertyType == typeof(string))
                {
                    writer.WriteLine("[System.Management.Automation.AllowEmptyString]");
                }
                else if (property.CollectionType != SimplePropertyInfo.PropertyCollectionType.NoCollection)
                {
                    writer.WriteLine("[System.Management.Automation.AllowEmptyCollection]");
                }
                writer.WriteLine("[System.Management.Automation.AllowNull]");
                writer.WriteLine("#endif");
                writer.WriteLine("[Amazon.PowerShell.Common.AWSRequiredParameter]");
            }
            else
            {
                WriteParamAttributeWithParameterSetNames(writer, paramAttrib, parameterSetNames);
            }

            var deprecationMessage = paramCustomization?.ReplacementObsoleteMessage ?? property.DeprecationMessage;

            if (property.IsDeprecated)
                writer.WriteLine($"[System.ObsoleteAttribute({EscapeString(deprecationMessage)})]");
        }

        private static void WriteParamAttributeWithParameterSetNames(IndentedTextWriter writer, List<string> paramAttrib, List<string> parameterSetNames)
        {
            if (parameterSetNames == null || parameterSetNames.Count == 0)
            {
                writer.WriteLine($"[System.Management.Automation.Parameter({string.Join(", ", paramAttrib)})]");
            }
            else
            {
                foreach (string parameterSetName in parameterSetNames)
                {
                    string parameterSetNameValue = $"ParameterSetName = \"{parameterSetName}\"";
                    paramAttrib.Add(parameterSetNameValue);
                    writer.WriteLine($"[System.Management.Automation.Parameter({string.Join(", ", paramAttrib)})]");
                    paramAttrib.RemoveAt(paramAttrib.Count - 1);
                }
            }
        }

        private static string EscapeString(string originalString)
        {
            return "\"" + HttpUtility.JavaScriptStringEncode(originalString) + "\"";
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
            writer.WriteLine("var context = new CmdletContext();");
            writer.WriteLine();
            writer.WriteLine("// allow for manipulation of parameters prior to loading into context");
            writer.WriteLine("PreExecutionContextLoad(context);");
            writer.WriteLine();
            writer.WriteLine("if (ParameterWasBound(nameof(this.Select)))");
            writer.OpenRegion();
            {
                writer.WriteLine($"context.Select = CreateSelectDelegate<{MethodAnalysis.ResponseType}, {Operation.SelectedVerb}{Operation.SelectedNoun}Cmdlet>(Select) ??");
                writer.IncreaseIndent();
                writer.WriteLine("throw new System.ArgumentException(\"Invalid value for -Select parameter.\", nameof(this.Select));");
                writer.DecreaseIndent();
            }
            writer.CloseRegion();

            foreach (var property in allProperties)
            {
                if (OperationAnalyzer.IsExcludedParameter(property.AnalyzedName, ServiceConfig, Operation))
                    continue;

                var customEmitter = FindCustomEmitterForParam(property);
                if (customEmitter == null)
                {
                    if (property.IsDeprecated)
                    {
                        writer.WriteLine("#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute");
                    }
                    if (property.CollectionType == SimplePropertyInfo.PropertyCollectionType.NoCollection || property.GenericCollectionTypes == null)
                    {
                        var paramCustomization = FindParameterCustomization(property.AnalyzedName);

                        writer.WriteLine($"context.{property.CmdletParameterName} = this.{property.CmdletParameterName};");

                        if (!string.IsNullOrEmpty(property.DefaultValue))
                        {
                            if (property.Name == MethodAnalysis.AutoIterateSettings?.EmitLimit)
                            {
                                //Default values for EmitLimit are handled during iteration for the legacy iteration pattern.
                                writer.WriteLine("#if MODULAR");
                            }
                            writer.WriteLine($"if (!ParameterWasBound(nameof(this.{property.CmdletParameterName})))");
                            writer.OpenRegion();
                            {
                                writer.WriteLine($"WriteVerbose(\"{property.CmdletParameterName} parameter unset, using default value of '{property.DefaultValue}'\");");
                                switch (property.PropertyTypeName)
                                {
                                    case "System.String":
                                    case "string":
                                        {
                                            writer.WriteLine($"context.{property.CmdletParameterName} = \"{property.DefaultValue}\";");
                                        }
                                        break;
                                    default:
                                        {
                                            writer.WriteLine($"context.{property.CmdletParameterName} = {property.DefaultValue};");
                                        }
                                        break;
                                }
                            }
                            writer.CloseRegion();
                            if (property.Name == MethodAnalysis.AutoIterateSettings?.EmitLimit)
                            {
                                writer.WriteLine("#endif");
                            }
                        }

                        /* If we have public Is<PropertyName>Set available (we could have <ParentProperty>_Is<ChildProperty>Set as well) and 
                         * have the corresponding PropertyName (Collection type), just set the context Is<PropertyName>Set property to true.
                         * 
                         * EXAMPLES (using AnalyzedName):
                         * 
                         * IsReplicationConfigurationTemplateIDsSet -> ReplicationConfigurationTemplateIDs
                         * IsLayersSet -> Layers
                         * IsFileSystemConfigsSet -> FileSystemConfigs
                         * Environment_IsVariablesSet -> Environment_Variables
                         * ImageConfig_IsCommandSet -> ImageConfig_Command
                         * ImageConfig_IsEntryPointSet -> ImageConfig_EntryPoint
                         * VpcConfig_IsSecurityGroupIdsSet -> VpcConfig_SecurityGroupIds
                         * VpcConfig_IsSubnetIdsSet -> VpcConfig_SubnetIds
                         */
                        var propertyParts = property.AnalyzedName.Split('_');
                        if (propertyParts[propertyParts.Length - 1].StartsWith("Is") && propertyParts[propertyParts.Length - 1].EndsWith("Set") && property.PropertyTypeName == "System.Boolean")
                        {
                            // Modify the last part to remove Is (from beginning) and Set (from end).
                            propertyParts[propertyParts.Length - 1] = propertyParts[propertyParts.Length - 1].Substring(2, propertyParts[propertyParts.Length - 1].Length - 5);

                            string desiredCorrespondingPropertyName = String.Join('_', propertyParts);
                            var correspondingProperty = allProperties.Where(spi => spi.AnalyzedName == desiredCorrespondingPropertyName).FirstOrDefault();

                            if (correspondingProperty != null && correspondingProperty.CollectionType != SimplePropertyInfo.PropertyCollectionType.NoCollection)
                            {
                                // Make sure to set the context Is<PropertyName>Set property to true only if it was not explicitly set by user and the corresponding property is not set to null (else it could clear the service collection in some scenarios).
                                writer.WriteLine($"if (!ParameterWasBound(nameof(this.{property.CmdletParameterName})) && this.{correspondingProperty.CmdletParameterName} != null)");
                                writer.OpenRegion();
                                writer.WriteLine($"context.{property.CmdletParameterName} = true;");
                                writer.CloseRegion();
                            }
                        }
                    }
                    else
                    {
                        switch (property.CollectionType)
                        {
                            case SimplePropertyInfo.PropertyCollectionType.IsGenericList:
                                {
                                    // cannot pass null to List<T> ctor :-(
                                    writer.WriteLine($"if (this.{property.CmdletParameterName} != null)");
                                    writer.OpenRegion();
                                    writer.WriteLine($"context.{property.CmdletParameterName} = new {property.PropertyTypeName}(this.{property.CmdletParameterName});");
                                    writer.CloseRegion();
                                }
                                break;

                            case SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary:
                                {
                                    writer.WriteLine($"if (this.{property.CmdletParameterName} != null)");
                                    writer.OpenRegion();
                                    {
                                        writer.WriteLine($"context.{property.CmdletParameterName} = new {property.PropertyTypeName}({(property.GenericCollectionTypes[0] == typeof(string) ? "StringComparer.Ordinal" : "")});");
                                        writer.WriteLine($"foreach (var hashKey in this.{property.CmdletParameterName}.Keys)");
                                        writer.OpenRegion();
                                        {
                                            // this handles List<T> where T is a simple type. List<T> where T is a generic dictionary
                                            // is handled in the IsGenericListOfGenericDictionary switch case. We must hope the Hashtable
                                            // value is enumerable
                                            if (!property.GenericCollectionTypes[1].Name.StartsWith("List`", StringComparison.Ordinal))
                                            {
                                                var keyTypeName = property.GenericCollectionTypes[0].Name;
                                                var valueTypeName = property.GenericCollectionTypes[1].GetTypeFullCodeName();

                                                if (valueTypeName == SimplePropertyInfo.DocumentTypeFullName)
                                                {
                                                    writer.WriteLine($"context.{property.CmdletParameterName}.Add(({keyTypeName})hashKey, Amazon.PowerShell.Common.DocumentHelper.ToDocument(this.{property.CmdletParameterName}[hashKey]));");
                                                }
                                                else
                                                {
                                                    writer.WriteLine($"context.{property.CmdletParameterName}.Add(({keyTypeName})hashKey, ({valueTypeName})(this.{property.CmdletParameterName}[hashKey]));");
                                                }
                                            }
                                            else
                                            {
                                                // need to do some clunky manipulation with non-genericized IEnumerable though, cast to
                                                // IEnumerable<T> yields exception on hashValue
                                                writer.WriteLine($"object hashValue = this.{property.CmdletParameterName}[hashKey];");
                                                // have to dig deeper to get the real type, and not "List`1"
                                                string valueSetItemType = ((property.GenericCollectionTypes[1]).GetGenericArguments())[0].FullName;

                                                writer.WriteLine("if (hashValue == null)");
                                                writer.OpenRegion();
                                                {
                                                    writer.WriteLine($"context.{property.CmdletParameterName}.Add(({property.GenericCollectionTypes[0].Name})hashKey, null);");
                                                    writer.WriteLine("continue;");
                                                }
                                                writer.CloseRegion();

                                                writer.WriteLine("var enumerable = SafeEnumerable(hashValue);");
                                                writer.WriteLine($"var valueSet = new List<{valueSetItemType}>();");
                                                writer.WriteLine("foreach (var s in enumerable)");
                                                writer.OpenRegion();
                                                {
                                                    writer.WriteLine($"valueSet.Add(({valueSetItemType})s);");
                                                }
                                                writer.CloseRegion();
                                                writer.WriteLine($"context.{property.CmdletParameterName}.Add(({property.GenericCollectionTypes[0].Name})hashKey, valueSet);");
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
                                    writer.WriteLine($"if (this.{property.CmdletParameterName} != null)");
                                    writer.OpenRegion();
                                    {
                                        // simple property info ctor has already dived down to get the inner types for us
                                        var innerDictionaryTypes = property.GenericCollectionTypes;

                                        writer.WriteLine($"context.{property.CmdletParameterName} = new {property.PropertyTypeName}();");
                                        writer.WriteLine($"foreach (var innerList in this.{property.CmdletParameterName})");
                                        writer.OpenRegion();
                                        {
                                            writer.WriteLine($"context.{property.CmdletParameterName}.Add(new List<{innerDictionaryTypes[0].FullName}>(innerList));");
                                        }
                                        writer.CloseRegion();
                                    }
                                    writer.CloseRegion();
                                }
                                break;

                            case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericList:
                                {
                                    /* generates code pattern of:
                                        context.PROPERTY = new List<List<List<T>>>();
                                        foreach (var innerList in this.PROPERTY)
                                        {
                                            var innerListCopy = new List<List<T>();
                                            context.PROPERTY.Add(innerListCopy);

                                            foreach (var innermostList in innerList)
                                            {
                                                var innermostListCopy = new List<T>(innermostList);
                                                innerListCopy.Add(innermostListCopy);
                                            }
                                        }
                                    */
                                    writer.WriteLine($"if (this.{property.CmdletParameterName} != null)");
                                    writer.OpenRegion();
                                    {
                                        // simple property info ctor has already dived down to get the inner types for us
                                        var innerDictionaryTypes = property.GenericCollectionTypes;

                                        writer.WriteLine($"context.{property.CmdletParameterName} = new {property.PropertyTypeName}();");
                                        writer.WriteLine($"foreach (var innerList in this.{property.CmdletParameterName})");
                                        writer.OpenRegion();
                                        {
                                            writer.WriteLine($"var innerListCopy = new List<List<{innerDictionaryTypes[0].FullName}>>();");
                                            writer.WriteLine($"context.{property.CmdletParameterName}.Add(innerListCopy);");

                                            writer.WriteLine("foreach (var innermostList in innerList)");
                                            writer.OpenRegion();
                                            {
                                                writer.WriteLine($"var innermostListCopy = new List<{innerDictionaryTypes[0].FullName}>(innermostList);");
                                                writer.WriteLine("innerListCopy.Add(innermostListCopy);");
                                            }
                                            writer.CloseRegion();
                                        }
                                        writer.CloseRegion();
                                    }
                                    writer.CloseRegion();
                                }
                                break;

                            case SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericListOfGenericList:
                                {
                                    /* generates code pattern of:
                                        context.PROPERTY = new List<List<List<List<T>>>>();
                                        foreach (var innerList in this.PROPERTY)
                                        {
                                            var innerListCopy = new List<List<List<T>>>();
                                            context.PROPERTY.Add(innerListCopy);

                                            foreach (var secondInnerList in innerList)
                                            {
                                                var secondInnerListCopy = new List<List<T>>();
                                                innerListCopy.Add(secondInnerListCopy);
                                                
                                                foreach (var innermostList in secondInnerList)
                                                {
                                                    var innermostListCopy = new List<T>(innermostList);
                                                    secondInnerListCopy.Add(innermostListCopy);
                                                }
                                            }
                                        }
                                    */

                                    writer.WriteLine($"if (this.{property.CmdletParameterName} != null)");
                                    writer.OpenRegion();
                                    {
                                        // simple property info ctor has already dived down to get the inner types for us
                                        var innerDictionaryTypes = property.GenericCollectionTypes;

                                        writer.WriteLine($"context.{property.CmdletParameterName} = new {property.PropertyTypeName}();");
                                        writer.WriteLine($"foreach (var innerList in this.{property.CmdletParameterName})");
                                        writer.OpenRegion();
                                        {
                                            writer.WriteLine($"var innerListCopy = new List<List<List<{innerDictionaryTypes[0].FullName}>>>();");
                                            writer.WriteLine($"context.{property.CmdletParameterName}.Add(innerListCopy);");

                                            writer.WriteLine("foreach (var secondInnerList in innerList)");
                                            writer.OpenRegion();
                                            {
                                                writer.WriteLine($"var secondInnerListCopy = new List<List<{innerDictionaryTypes[0].FullName}>>();");
                                                writer.WriteLine("innerListCopy.Add(secondInnerListCopy);");

                                                writer.WriteLine("foreach (var innermostList in secondInnerList)");
                                                writer.OpenRegion();
                                                {
                                                    writer.WriteLine($"var innermostListCopy = new List<{innerDictionaryTypes[0].FullName}>(innermostList);");
                                                    writer.WriteLine("secondInnerListCopy.Add(innermostListCopy);");
                                                }
                                                writer.CloseRegion();
                                            }
                                            writer.CloseRegion();
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
                                    writer.WriteLine($"if (this.{property.CmdletParameterName} != null)");
                                    writer.OpenRegion();
                                    {
                                        // simple property info ctor has already dived down to get the inner types for us
                                        var innerDictionaryTypes = property.GenericCollectionTypes;

                                        writer.WriteLine($"context.{property.CmdletParameterName} = new {property.PropertyTypeName}();");

                                        writer.WriteLine($"foreach (var hashTable in this.{property.CmdletParameterName})");
                                        writer.OpenRegion();
                                        {
                                            // handles Dictionary<T1, List<T2>>
                                            if (innerDictionaryTypes[1].IsGenericType && innerDictionaryTypes[1].Name.StartsWith("List`", StringComparison.Ordinal))
                                            {
                                                var innnerValueSetItemType =
                                                    ((innerDictionaryTypes[1]).GetGenericArguments())[0].FullName;

                                                writer.WriteLine($"var d = new Dictionary<{innerDictionaryTypes[0].FullName}, List<{innnerValueSetItemType}>>();");
                                            }
                                            else
                                            {
                                                writer.WriteLine($"var d = new Dictionary<{innerDictionaryTypes[0].FullName}, {innerDictionaryTypes[1].FullName}>();");
                                            }

                                            writer.WriteLine("foreach (var hashKey in hashTable.Keys)");
                                            writer.OpenRegion();
                                            {
                                                if (!innerDictionaryTypes[1].Name.StartsWith("List`", StringComparison.Ordinal))
                                                {
                                                    writer.WriteLine($"d.Add(({innerDictionaryTypes[0].Name})hashKey, ({innerDictionaryTypes[1].Name})(hashTable[hashKey]));");
                                                }
                                                else
                                                {
                                                    // need to do some clunky manipulation with non-genericized IEnumerable though, cast to
                                                    // IEnumerable<T> yields exception on hashValue
                                                    writer.WriteLine("object hashValue = hashTable[hashKey];");
                                                    // have to dig deeper to get the real type, and not "List`1"
                                                    string valueSetItemType = ((innerDictionaryTypes[1]).GetGenericArguments())[0].FullName;

                                                    writer.WriteLine("if (hashValue == null)");
                                                    writer.OpenRegion();
                                                    {
                                                        writer.WriteLine($"d.Add(({innerDictionaryTypes[0].Name})hashKey, null);");
                                                        writer.WriteLine("continue;");
                                                    }
                                                    writer.CloseRegion();

                                                    writer.WriteLine("var enumerable = SafeEnumerable(hashValue);");
                                                    writer.WriteLine($"var valueSet = new List<{valueSetItemType}>();");
                                                    writer.WriteLine("foreach (var s in enumerable)");
                                                    writer.OpenRegion();
                                                    {
                                                        writer.WriteLine($"valueSet.Add(({valueSetItemType})s);");
                                                    }
                                                    writer.CloseRegion();
                                                    writer.WriteLine($"d.Add(({innerDictionaryTypes[0].Name})hashKey, valueSet);");
                                                }
                                            }
                                            writer.CloseRegion();
                                        }

                                        writer.WriteLine($"context.{property.CmdletParameterName}.Add(d);");
                                        writer.CloseRegion();
                                    }
                                    writer.CloseRegion();
                                }
                                break;
                        }
                    }
                    if (property.IsRecursivelyRequired)
                    {
                        writer.WriteLine($"#if MODULAR");
                        writer.WriteLine($"if (this.{property.CmdletParameterName} == null && ParameterWasBound(nameof(this.{property.CmdletParameterName})))");
                        writer.OpenRegion();
                        writer.WriteLine($"WriteWarning(\"You are passing $null as a value for parameter {property.CmdletParameterName} which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.\");");
                        writer.CloseRegion();
                        writer.WriteLine($"#endif");
                    }
                    if (property.Name == MethodAnalysis.AutoIterateSettings?.EmitLimit)
                    {
                        writer.WriteLine($"#if !MODULAR");
                        writer.WriteLine($"if (ParameterWasBound(nameof(this.{property.CmdletParameterName})) && this.{property.CmdletParameterName}.HasValue)");
                        writer.OpenRegion();
                        writer.WriteLine($"WriteWarning(\"AWSPowerShell and AWSPowerShell.NetCore use the {property.CmdletParameterName} parameter to limit the total number of items returned by the cmdlet.\" +");
                        writer.IncreaseIndent();
                        writer.WriteLine("\" This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate\" +");
                        writer.WriteLine($"\" retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing {property.CmdletParameterName}\" +");
                        writer.WriteLine("\" to the service to specify how many items should be returned by each service call.\");");
                        writer.DecreaseIndent();
                        writer.CloseRegion();
                        writer.WriteLine($"#endif");
                    }
                    if (property.IsDeprecated)
                    {
                        writer.WriteLine("#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute");
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

        private void WriteContextClass(IndentedTextWriter writer)
        {
            writer.WriteLine("internal partial class CmdletContext : ExecutorContext");
            writer.OpenRegion();
            {
                // Note that the context class member types match the inner SDK request field types - remapping
                // from List<T> to T[] is only done at the cmdlet parameter level. This keeps the executor code
                // simpler. Properties that should only be populated if the associated parameter was specified
                // are emitted as nullable types.
                foreach (var property in MethodAnalysis.AnalyzedParameters.Where(property => !OperationAnalyzer.IsExcludedParameter(property.AnalyzedName, ServiceConfig, Operation)))
                {
                    if (property.IsDeprecated)
                    {
                        writer.WriteLine("[System.ObsoleteAttribute]");
                    }
                    writer.WriteLine($"public {GetPropertyTypeToEmit(property)}{(property.UseParameterValueOnlyIfBound ? "?" : "")} {property.CmdletParameterName} {{ get; set; }}");
                }

                writer.WriteLine($"public System.Func<{MethodAnalysis.ResponseType}, {Operation.SelectedVerb}{Operation.SelectedNoun}Cmdlet, object> Select {{ get; set; }} =");
                writer.IncreaseIndent();
                {
                    if (Operation.OutputProperty == null)
                    {
                        writer.WriteLine("(response, cmdlet) => null;");
                    }
                    else if (Operation.OutputProperty == "*")
                    {
                        writer.WriteLine("(response, cmdlet) => response;");
                    }
                    else
                    {
                        writer.WriteLine($"(response, cmdlet) => response.{Operation.OutputProperty};");
                    }
                }
                writer.DecreaseIndent();
            }
            writer.CloseRegion();
        }

        /// <summary>
        /// Writes an IExecutor implementation for a cmdlet that does not support iterable output.
        /// </summary>
        /// <param name="writer"></param>
        private void WriteIExecutor(IndentedTextWriter writer)
        {
            var requestType = MethodAnalysis.RequestType;

            writer.WriteLine("public object Execute(ExecutorContext context)");
            writer.OpenRegion();
            {
                bool tryGenerated = WriteMemoryStreamVariableInitializers(writer);
                {
                    writer.WriteLine("var cmdletContext = context as CmdletContext;");

                    writer.WriteLine("// create request");
                    writer.WriteLine($"var request = new {OperationAnalyzer.GetValidTypeName(requestType, ServiceConfig)}();");
                    writer.WriteLine();

                    foreach (var simpleProperty in MethodAnalysis.RequestProperties)
                    {
                        WriteContextObjectPopulation(writer, simpleProperty, "request." + simpleProperty.Name);
                    }

                    writer.WriteLine();
                    //writer.WriteLine("ServiceCalls.PushServiceRequest(request, this.MyInvocation);");
                    writer.WriteLine("CmdletOutput output;");

                    writer.WriteLine();
                    writer.WriteLine("// issue call");

                    if (Operation.RequiresAnonymousAuthentication)
                    {
                        writer.WriteLine("var client = Client ?? CreateClient(_RegionEndpoint);");
                    }
                    else
                    {
                        writer.WriteLine("var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);");
                    }

                    writer.WriteLine("try");
                    writer.OpenRegion();
                    writer.WriteLine("var response = CallAWSServiceOperation(client, request);");
                    WriteResultOutput(writer, false);
                    writer.CloseRegion();
                    writer.WriteLine("catch (Exception e)");
                    writer.OpenRegion();
                    writer.WriteLine("output = new CmdletOutput { ErrorResponse = e };");
                    writer.CloseRegion();

                    writer.WriteLine();
                    writer.WriteLine("return output;");
                }
                WriteMemoryStreamVariableCleanup(writer, tryGenerated);
            }

            writer.CloseRegion();
        }

        private void WritePipeParamToOutput(IndentedTextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("if (useParameterSelect)");
            writer.OpenRegion();
            {
                writer.WriteLine("WriteObject(cmdletContext.Select(null, this));");
            }
            writer.CloseRegion();
            writer.WriteLine();
        }

        /// <summary>
        /// Forms the member path starting at response class to the output fields.
        /// </summary>
        private string ComputeResponseMemberPath()
        {
            return string.IsNullOrEmpty(Operation.OutputWrapper) ? "response" : $"response.{Operation.OutputWrapper}";
        }

        /// <summary>
        /// Writes an IExecutor implementation compatible with auto-iteration pattern 1
        /// (use page marker tokens, iterate until the field referenced by 'Next' is empty;
        /// 'AutoIterate Start="NextToken" Next="NextToken"').
        /// </summary>
        /// <param name="writer"></param>
        private void WriteIExecutorIterPattern1(IndentedTextWriter writer)
        {
            var requestType = MethodAnalysis.RequestType;
            var autoIteration = MethodAnalysis.AutoIterateSettings;

            var responseMemberReferencePath = ComputeResponseMemberPath();

            writer.WriteLine("public object Execute(ExecutorContext context)");
            writer.OpenRegion();
            {
                writer.WriteLine("var cmdletContext = context as CmdletContext;");
                writer.WriteLine("var useParameterSelect = this.Select.StartsWith(\"^\");");
                writer.WriteLine();

                writer.WriteLine("// create request and set iteration invariants");
                writer.WriteLine($"var request = new {OperationAnalyzer.GetValidTypeName(requestType, ServiceConfig)}();");
                writer.WriteLine();

                SimplePropertyInfo starPaginationProperty = null;
                // emit non-iterator properties
                foreach (var simpleProperty in MethodAnalysis.RequestProperties)
                {
                    if (simpleProperty.Name == autoIteration.Start)
                    {
                        starPaginationProperty = simpleProperty;
                        continue;
                    }

                    WriteContextObjectPopulation(writer, simpleProperty, "request." + simpleProperty.Name);
                }

                writer.WriteLine();

                writer.WriteLine("// Initialize loop variant and commence piping");
                writer.WriteLine($"var _nextToken = cmdletContext.{starPaginationProperty.CmdletParameterName};");
                writer.WriteLine($"var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.{starPaginationProperty.CmdletParameterName}));");
                
                // disable auto-iteration for cmdlets that didn't have auto-iteration in v4 in legacy mode.
                if (autoIteration.SupportLegacyAutoIterationMode)
                {
                    writer.WriteLine(@$"var _shouldAutoIterate = !(SessionState.PSVariable.GetValue(""AWSPowerShell_AutoIteration_Mode"")?.ToString() == ""v4"");");
                }

                writer.WriteLine();

                if (Operation.RequiresAnonymousAuthentication)
                {
                    writer.WriteLine("var client = Client ?? CreateClient(_RegionEndpoint);");
                }
                else
                {
                    writer.WriteLine("var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);");
                }

                writer.WriteLine("do");
                writer.OpenRegion();
                {
                    writer.WriteLine($"request.{autoIteration.Start} = _nextToken;");
                    writer.WriteLine();

                    writer.WriteLine("CmdletOutput output;");

                    writer.WriteLine();
                    writer.WriteLine("try");
                    writer.OpenRegion();
                    {
                        //writer.WriteLine("ServiceCalls.PushServiceRequest(request, this.MyInvocation);");
                        writer.WriteLine();

                        writer.WriteLine("var response = CallAWSServiceOperation(client, request);");
                        writer.WriteLine();

                        WriteResultOutput(writer, true);

                        writer.WriteLine();
                        writer.WriteLine($"_nextToken = {responseMemberReferencePath}.{autoIteration.Next};");
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
                if (autoIteration.SupportLegacyAutoIterationMode)
                {
                    writer.CloseRegion("} while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));");
                }
                else
                {
                    writer.CloseRegion("} while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));");

                }

                WritePipeParamToOutput(writer);

                writer.WriteLine();
                writer.WriteLine("return null;");
            }

            writer.CloseRegion();
        }

        /// <summary>
        /// Writes an IExecutor implementation compatible with auto-iteration pattern 2
        /// (use page marker tokens and ability to control total data size; iterate until 'next token' is empty;
        /// 'AutoIterate EmitLimit="MaxRecords" Start="Marker" Next="Marker"')
        /// </summary>
        /// <param name="writer"></param>
        private void WriteIExecutorIterPattern2(IndentedTextWriter writer)
        {
            var requestType = MethodAnalysis.RequestType;
            var autoIteration = MethodAnalysis.AutoIterateSettings;
            long? maxPageSize = autoIteration.ServicePageSize != -1 ? autoIteration.ServicePageSize : (long?)null;
            long minPageSize = 1;

            var responseMemberReferencePath = ComputeResponseMemberPath();

            writer.WriteLine("public object Execute(ExecutorContext context)");
            writer.OpenRegion();
            {
                writer.WriteLine("var cmdletContext = context as CmdletContext;");
                writer.WriteLine("var useParameterSelect = this.Select.StartsWith(\"^\");");
                writer.WriteLine();

                writer.WriteLine("// create request and set iteration invariants");
                writer.WriteLine($"var request = new {OperationAnalyzer.GetValidTypeName(requestType, ServiceConfig)}();");

                var iteratorLimitType = string.Empty;
                var isPageSizeRequired = false;

                SimplePropertyInfo starPaginationProperty = null;
                SimplePropertyInfo limitPaginationProperty = null;

                // emit non-iterator properties
                foreach (var simpleProperty in MethodAnalysis.RequestProperties)
                {
                    if (simpleProperty.Name == autoIteration.Start)
                    {
                        starPaginationProperty = simpleProperty;
                    }
                    else if (simpleProperty.Name == autoIteration.EmitLimit)
                    {
                        limitPaginationProperty = simpleProperty;
                        iteratorLimitType = limitPaginationProperty.PropertyType.Name;
                        maxPageSize = maxPageSize ?? simpleProperty.MaxValue;
                        minPageSize = simpleProperty.MinValue ?? 1;
                        isPageSizeRequired = simpleProperty.IsRequired || autoIteration.PageSizeIsRequired;
                    }
                    else
                    {
                        WriteContextObjectPopulation(writer, simpleProperty, "request." + simpleProperty.Name);
                    }
                }

                writer.WriteLine();
                writer.WriteLine("// Initialize loop variants and commence piping");
                writer.WriteLine($"{starPaginationProperty.PropertyTypeName} _nextToken = null;");
                writer.WriteLine("int? _emitLimit = null;");
                writer.WriteLine("int _retrievedSoFar = 0;");

                writer.WriteLine($"if (AutoIterationHelpers.HasValue(cmdletContext.{starPaginationProperty.CmdletParameterName}))");
                writer.OpenRegion();
                {
                    writer.WriteLine($"_nextToken = cmdletContext.{starPaginationProperty.CmdletParameterName};");
                }
                writer.CloseRegion();
                writer.WriteLine($"if (cmdletContext.{limitPaginationProperty.CmdletParameterName}.HasValue)");
                writer.OpenRegion();
                {
                    if (maxPageSize.HasValue)
                    {
                        writer.WriteLine($"// The service has a maximum page size of {maxPageSize.Value}. If the user has");
                        writer.WriteLine("// asked for more items than page max, and there is no page size");
                        writer.WriteLine("// configured, we rely on the service ignoring the set maximum");
                        writer.WriteLine($"// and giving us {maxPageSize.Value} items back. If a page size is set, that will");
                        writer.WriteLine("// be used to configure the pagination.");
                        writer.WriteLine("// We'll make further calls to satisfy the user's request.");
                    }
                    writer.WriteLine($"_emitLimit = cmdletContext.{limitPaginationProperty.CmdletParameterName};");
                }
                writer.CloseRegion();

                writer.WriteLine($"var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.{starPaginationProperty.CmdletParameterName}));");

                writer.WriteLine();

                if (Operation.RequiresAnonymousAuthentication)
                {
                    writer.WriteLine("var client = Client ?? CreateClient(_RegionEndpoint);");
                }
                else
                {
                    writer.WriteLine("var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);");
                }

                writer.WriteLine("do");
                writer.OpenRegion();
                {
                    writer.WriteLine($"request.{autoIteration.Start} = _nextToken;");

                    if (maxPageSize.HasValue)
                    {
                        writer.WriteLine("if (_emitLimit.HasValue)");
                        writer.OpenRegion();
                        {
                            writer.WriteLine($"int correctPageSize = Math.Min({maxPageSize.Value}, _emitLimit.Value);");
                            writer.WriteLine($"request.{autoIteration.EmitLimit} = AutoIterationHelpers.ConvertEmitLimitTo{iteratorLimitType}(correctPageSize);");
                        }
                        writer.CloseRegion();
                        if (isPageSizeRequired && maxPageSize.HasValue)
                        {
                            writer.WriteLine($"else if (!ParameterWasBound(nameof(this.{limitPaginationProperty.CmdletParameterName})))");
                            writer.OpenRegion();
                            {
                                writer.WriteLine($"request.{autoIteration.EmitLimit} = AutoIterationHelpers.ConvertEmitLimitTo{iteratorLimitType}({maxPageSize.Value});");
                            }
                            writer.CloseRegion();
                        }
                        writer.WriteLine();
                    }
                    else
                    {
                        writer.WriteLine("if (_emitLimit.HasValue)");
                        writer.OpenRegion();
                        {
                            writer.WriteLine($"request.{autoIteration.EmitLimit} = AutoIterationHelpers.ConvertEmitLimitTo{iteratorLimitType}(_emitLimit.Value);");
                        }
                        writer.CloseRegion();
                        writer.WriteLine();
                    }

                    writer.WriteLine("CmdletOutput output;");

                    writer.WriteLine();
                    writer.WriteLine("try");
                    writer.OpenRegion();
                    {
                        writer.WriteLine();

                        writer.WriteLine("var response = CallAWSServiceOperation(client, request);");
                        WriteResultOutput(writer, true);

                        writer.WriteLine($"int _receivedThisCall = response.{Operation.LegacyPaginationCountParameter ?? (Operation.OutputProperty + "?.Count")} ?? 0;");

                        writer.WriteLine();
                        writer.WriteLine($"_nextToken = {responseMemberReferencePath}.{autoIteration.Next};");
                        writer.WriteLine("_retrievedSoFar += _receivedThisCall;");
                        writer.WriteLine("if (_emitLimit.HasValue)");
                        writer.OpenRegion();
                        {
                            writer.WriteLine("_emitLimit -= _receivedThisCall;");
                        }
                        writer.CloseRegion();
                    }
                    writer.CloseRegion();
                    writer.WriteLine("catch (Exception e)");
                    writer.OpenRegion();
                    {
                        writer.WriteLine("if (_retrievedSoFar == 0 || !_emitLimit.HasValue)");
                        writer.OpenRegion();
                        {
                            writer.WriteLine("output = new CmdletOutput { ErrorResponse = e };");
                        }
                        writer.CloseRegion();
                        writer.WriteLine("else");
                        writer.OpenRegion();
                        {
                            writer.WriteLine("break;");
                        }
                        writer.CloseRegion();
                    }
                    writer.CloseRegion();

                    writer.WriteLine();
                    writer.WriteLine("ProcessOutput(output);");
                }
                writer.CloseRegion($"}} while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= {minPageSize}));");
                writer.WriteLine();

                WritePipeParamToOutput(writer);

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
        /// <param name="responseMemberReferencePath"></param>
        private void WriteResultOutput(IndentedTextWriter writer, bool skipReturnIfUsingParameterSelect)
        {
            writer.WriteLine("object pipelineOutput = null;");
            if (skipReturnIfUsingParameterSelect)
            {
                writer.WriteLine("if (!useParameterSelect)");
                writer.OpenRegion();
            }
            writer.WriteLine("pipelineOutput = cmdletContext.Select(response, this);");
            if (skipReturnIfUsingParameterSelect)
            {
                writer.CloseRegion();
            }
            writer.WriteLine("output = new CmdletOutput");
            writer.OpenRegion();
            {
                writer.WriteLine("PipelineOutput = pipelineOutput,");
                writer.WriteLine("ServiceResponse = response");
            }
            writer.CloseRegion("};");
        }

        private void WriteContextObjectPopulation(IndentedTextWriter writer, SimplePropertyInfo property, string variableName, bool nestedProperty = false)
        {
            if (property.Children.Count == 0)
            {
                var paramCustomization = MethodAnalysis.GetParameterCustomization(property.AnalyzedName);

                if (MethodAnalysis.IsExcludedParameter(property.AnalyzedName))
                    return;

                var autoIteration = MethodAnalysis.AutoIterateSettings;
                var isEmitLimiter = property.Name == autoIteration?.EmitLimit;

                if (!nestedProperty && property.IsDeprecated)
                {
                    writer.WriteLine("#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute");
                }
                writer.WriteLine($"if (cmdletContext.{property.CmdletParameterName} != null)");
                writer.OpenRegion();
                {
                    if (paramCustomization != null)
                    {
                        foreach (var exclusiveParameter in paramCustomization.ExclusiveParameters)
                        {
                            writer.WriteLine($"if (cmdletContext.{exclusiveParameter} != null)");
                            writer.OpenRegion();
                            {
                                writer.WriteLine($"throw new System.ArgumentException(\"Parameters {property.CmdletParameterName} and {exclusiveParameter} are mutually exclusive.\", nameof(this.{property.CmdletParameterName}));");
                            }
                            writer.CloseRegion();
                        }
                    }

                    if (isEmitLimiter)
                    {
                        writer.WriteLine($"{variableName} = AutoIterationHelpers.ConvertEmitLimitToServiceType{property.PropertyType.Name}(cmdletContext.{property.CmdletParameterName}.Value);");
                    }
                    else if (property.IsStreamType)
                    {
                        var streamVariableName = BuildStreamVariableName(property);
                        if (property.IsMemoryStreamType)
                        {
                            writer.WriteLine($"{streamVariableName} = new System.IO.MemoryStream(cmdletContext.{property.CmdletParameterName});");
                        }
                        else
                        {
                            writer.WriteLine($"{streamVariableName} = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.{property.CmdletParameterName});");
                        }
                        writer.WriteLine($"{variableName} = {streamVariableName};");
                    }
                    else if (property.IsDocumentType)
                    {
                        writer.WriteLine($"{variableName} = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.{property.CmdletParameterName});");
                    }
                    else
                    {
                        writer.WriteLine($"{variableName} = cmdletContext.{property.CmdletParameterName}{(property.PropertyType.IsValueType ? ".Value" : "")};");
                    }
                }
                writer.CloseRegion();
                if (!nestedProperty && property.IsDeprecated)
                {
                    writer.WriteLine("#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute");
                }
            }
            else
            {
                // test for excluding a batch of parameters by common prefix
                if (MethodAnalysis.IsExcludedParameter(property.AnalyzedName + "_"))
                    return;

                writer.WriteLine();
                writer.WriteLine($" // populate {property.Name}");
                string usableVariableName = variableName.Replace(".", string.Empty);
                writer.WriteLine($"var {usableVariableName}IsNull = true;");
                writer.WriteLine($"{variableName} = new {MethodAnalysis.GetValidTypeName(property.PropertyType)}();");

                foreach (var child in property.Children.OrderBy(c => c.Children.Count))
                {
                    if (child.IsDeprecated)
                    {
                        writer.WriteLine("#pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute");
                    }

                    var childVariableName = usableVariableName + "_" + OperationAnalyzer.ToLowerCamelCase(child.CmdletParameterName);

                    var childPropertyType = MethodAnalysis.GetValidTypeName(child.PropertyType);
                    var nullableFlag = (child.UseParameterValueOnlyIfBound || child.IsDocumentType ? "?" : "");
                    var field = $"{childVariableName} = null;";
                    writer.WriteLine($"{childPropertyType}{nullableFlag} {field}");

                    WriteContextObjectPopulation(writer, child, childVariableName, true);

                    writer.WriteLine($"if ({childVariableName} != null)");
                    writer.OpenRegion();
                    writer.WriteLine($"{variableName}.{child.Name} = {childVariableName}{(child.PropertyType.IsValueType ? ".Value" : "")};");
                    writer.WriteLine($"{usableVariableName}IsNull = false;");
                    writer.CloseRegion();

                    if (child.IsDeprecated)
                    {
                        writer.WriteLine("#pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute");
                    }
                }

                writer.WriteLine($" // determine if {variableName} should be set to null");
                writer.WriteLine($"if ({usableVariableName}IsNull)");
                writer.OpenRegion();
                writer.WriteLine($"{variableName} = null;");
                writer.CloseRegion();
            }
        }

        /// <summary>
        /// Reorders the parameters for the source file so the 'real' parameters come first, in alpha
        /// order for consistency, and metadata/paging/deprecated properties come last so they dont't
        /// clutter tab expansion in the cli. Properties marked for exclusion are retained at this
        /// stage, we  exclude them during the actual write phase.
        /// </summary>
        /// <param name="allProperties"></param>
        /// <param name="serviceOperation"></param>
        /// <returns></returns>
        List<SimplePropertyInfo> OrderParamsForSourceFile()
        {
            var orderedParams = new List<SimplePropertyInfo>();
            var deferToEnd = new List<SimplePropertyInfo>();

            var autoIterateSettings = MethodAnalysis.AutoIterateSettings;

            Func<SimplePropertyInfo, bool> isMetadataOrDeprecatedProperty = p =>
                        MethodAnalysis.AllModels.MetadataParameterNames.Contains(p.AnalyzedName) ||
                        ServiceConfig.MetadataPropertyNames.Contains(p.AnalyzedName) ||
                        p.IsDeprecated ||
                        (autoIterateSettings?.IsIterationParameter(p.AnalyzedName) ?? false);

            var metadataOrDeprecatedProperties = MethodAnalysis.AnalyzedParameters.Where(isMetadataOrDeprecatedProperty).ToList();

            foreach (var property in MethodAnalysis.AnalyzedParameters.OrderBy(p => p.Name))
            {
                if (metadataOrDeprecatedProperties.Contains(property))
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

                var obj = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType("AWSPowerShellGenerator." + item.EmitterType));
                emitterInstances.Add((IParamEmitter)obj);
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
                var obj = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType("AWSPowerShellGenerator." + ServiceConfig.TypeSpecificParamEmitters[k]));
                return (IParamEmitter)obj;
            }

            // second stage lookup, more generic emitter based on type only (useful
            // for specific type smoothing, eg replace enums with strings etc)
            if (ServiceConfig.TypeSpecificParamEmitters.ContainsKey(property.PropertyType.FullName))
            {
                var obj = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType("AWSPowerShellGenerator." + ServiceConfig.TypeSpecificParamEmitters[property.PropertyType.FullName]));
                return (IParamEmitter)obj;
            }

            // third stage lookup, useful with List<T> types
            if (ServiceConfig.TypeSpecificParamEmitters.ContainsKey(property.PropertyTypeName))
            {
                var obj = Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType("AWSPowerShellGenerator." + ServiceConfig.TypeSpecificParamEmitters[property.PropertyTypeName]));
                return (IParamEmitter)obj;
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
                sb.Append($".{property.PropertyType.Name}<");
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
        /// Searches the operation local, then service global data, to determine if a parameter
        /// has a customization applied.
        /// </summary>
        /// <param name="propertyAnalyzedName">The name of the property backing the parameter</param>
        /// <returns>Null or customization data to apply</returns>
        Param FindParameterCustomization(string propertyAnalyzedName)
        {
            var paramCustomization = Operation.FindCustomParameterData(propertyAnalyzedName);
            if (paramCustomization != null)
                return paramCustomization;

            return ServiceConfig.FindCustomParameterData(propertyAnalyzedName);
        }

        /// <summary>
        /// If we detected MemoryStream parameter types for the cmdlet, outputs one
        /// stream variable for each parameter that we switched to be a byte[] type.
        /// It then enters an additional try closure so we can clean up the streams
        /// prior to exiting the cmdlet executor.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        bool WriteMemoryStreamVariableInitializers(IndentedTextWriter writer)
        {
            if (!MethodAnalysis.StreamParameters.Any())
                return false;

            foreach (var p in MethodAnalysis.StreamParameters)
            {
                writer.WriteLine($"System.IO.{(p.IsMemoryStreamType ? "Memory" : "")}Stream {BuildStreamVariableName(p)} = null;");
            }

            writer.WriteLine();

            writer.WriteLine("try");
            writer.OpenRegion();
            return true;
        }

        string BuildStreamVariableName(SimplePropertyInfo property)
        {
            return $"_{property.CmdletParameterName}Stream";
        }

        // pass generateNewFinallyBlock true to wrap the cleanup code inside a finally {} block. If false, the
        // generated code is assumed to already be housed inside such a block.
        void WriteMemoryStreamVariableCleanup(IndentedTextWriter writer, bool generateNewFinallyBlock)
        {
            if (!MethodAnalysis.StreamParameters.Any())
                return;

            if (generateNewFinallyBlock)
            {
                writer.CloseRegion();
                writer.WriteLine("finally");
                writer.OpenRegion();
            }

            foreach (var p in MethodAnalysis.StreamParameters)
            {
                var variableName = BuildStreamVariableName(p);
                writer.WriteLine($"if( {variableName} != null)");
                writer.OpenRegion();
                writer.WriteLine($"{variableName}.Dispose();");
                writer.CloseRegion();
            }

            if (generateNewFinallyBlock)
            {
                writer.CloseRegion();
            }
        }

        string GetPropertyTypeToEmit(SimplePropertyInfo property)
        {
            if (property.IsMemoryStreamType)
            {
                return "byte[]";
            }
            if (property.IsStreamType)
            {
                return "object";
            }

            if (property.IsDocumentType)
            {
                return typeof(PSObject).FullName;
            }
            return property.PropertyTypeName;
        }

        private object GetIndefiniteArticle(string type)
        {
            if (type == string.Empty || !Vowels.Contains(type[0]))
            {
                return "a";
            }

            return "an";
        }
    }
}
