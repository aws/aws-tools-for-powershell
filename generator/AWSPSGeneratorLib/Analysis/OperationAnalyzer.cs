using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.CmdletConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Utils;
using AWSPowerShellGenerator.Writers.SourceCode;

namespace AWSPowerShellGenerator.Analysis
{
    /// <summary>
    /// Analyzes a service operation during translation to a cmdlet to determine
    /// the parameter names and other cmdlet information that should be emitted.
    /// </summary>
    /// <remarks>
    /// The analyzer determines the set of properties on the operation's request that 
    /// should be emitted as cmdlet parameters (together with applying naming rules so 
    /// that the cmdlet conforms to PowerShell naming guidelines) and whether to apply 
    /// the SupportsShouldProcess cmdlet attribute and processing to allow the -WhatIf, 
    /// -Confirm and -Force parameters.The inspection performs name flattening (for 
    /// nested request properties), shortening (to avoid excessively long flattened 
    /// names) and last-word-fragment singularization (to follow community convention). 
    /// Note that if the service operation contains parameter customization, this turns 
    /// off the automatic analysis for parameter renaming. The configuration can also
    /// bypass the automatic analysis for the SupportsShouldProcess attribute.
    /// </remarks>
    internal class OperationAnalyzer
    {
        #region Construction-time properties

        public ConfigModelCollection AllModels { get; set; }
        public ConfigModel CurrentModel { get; set; }
        public ServiceOperation CurrentOperation { get; set; }
        public BasicLogger Logger { get; set; }
        public XmlDocument AssemblyDocumentation { get; set; }

        #endregion

        #region Analysis result properties

        /// <summary>
        /// The set of properties to be emitted as cmdlet parameters. Members of complex
        /// properties are flattened to individual parameters.
        /// </summary>
        public List<SimplePropertyInfo> AnalyzedParameters { get; private set; }

        /// <summary>
        /// The set of actual properties the cmdlet needs to deal with to populate
        /// a service request. Complex types are not flattened here.
        /// </summary>
        public List<SimplePropertyInfo> RequestProperties { get; private set; }

        /// <summary>
        /// Returns any autoiteration settings that apply, defined at either the operation
        /// or service level.
        /// </summary>
        public AutoIteration AutoIterateSettings
        {
            get
            {
                return CurrentOperation.AutoIterate != null ? CurrentOperation.AutoIterate : CurrentModel.AutoIterate;
                //if (CurrentOperation.AutoIterate != null)
                //    return CurrentOperation.AutoIterate;

                //if (CurrentModel.AutoIterate != null && !CurrentModel.AutoIterate.ExclusionSet.Contains(CurrentOperation.MethodName))
                //    return CurrentModel.AutoIterate;

                //return null;
            }
        }

        /// <summary>
        /// Helper to indicate if codegen should emit an iteration pattern
        /// </summary>
        public bool GenerateIterationCode
        {
            get
            {
                var autoIteration = AutoIterateSettings;
                if (autoIteration == null)
                    return false;

                var pattern = autoIteration.Pattern;

                if (pattern == AutoIteration.AutoIteratePattern.None
                        || autoIteration.ExclusionSet.Contains(CurrentOperation.MethodName))
                    return false;

                switch (pattern)
                {
                    case AutoIteration.AutoIteratePattern.Pattern1:
                        return AreRequestFieldsPresent(AnalyzedParameters, autoIteration.Start)
                            && AreResultFieldsPresent(ReturnType, autoIteration.Next);

                    case AutoIteration.AutoIteratePattern.Pattern2:
                        return AreRequestFieldsPresent(AnalyzedParameters, autoIteration.Start, autoIteration.EmitLimit)
                            && AreResultFieldsPresent(ReturnType, autoIteration.Next);

                    case AutoIteration.AutoIteratePattern.Pattern3:
                        return AreRequestFieldsPresent(AnalyzedParameters, autoIteration.Start, autoIteration.EmitLimit)
                            && AreResultFieldsPresent(ReturnType, autoIteration.Next, autoIteration.TruncatedFlag);

                    default:
                        return false;
                }
            }
        }

        /// <summary>
        /// The iteration code pattern that should be generated for the operation, if any.
        /// </summary>
        public AutoIteration.AutoIteratePattern IterationPattern
        {
            get
            {
                var autoIteration = AutoIterateSettings;
                return autoIteration != null ? autoIteration.Pattern : AutoIteration.AutoIteratePattern.None;
            }
        }

        /// <summary>
        /// Helper to expose method name
        /// </summary>
        public string MethodName
        {
            get
            {
                return CurrentOperation == null ? string.Empty : CurrentOperation.MethodName;
            }
        }

        /// <summary>
        /// The request class that is passed to the operation
        /// </summary>
        public Type RequestType { get; private set; }

        /// <summary>
        /// The output type of the method that contains the actual result data
        /// </summary>
        public Type ReturnType { get; private set; }

        /// <summary>
        /// The results of the analysis of the output type for the cmdlet
        /// </summary>
        public AnalyzedResult AnalyzedResult { get; private set; }

        /// <summary>
        /// The results of the analysis to determine if the cmdlet should be
        /// annotated with the 'SupportsShouldProcess' attribute.
        /// </summary>
        public SupportsShouldProcessInspection SupportsShouldProcessInspectionResult { get; private set; }

        /// <summary>
        /// Currently an advisory message in the analysis log telling us that the
        /// pipeline-by-value parameter could be exposed as an array type.
        /// </summary>
        public string PromotePipelineParameterToCollection { get; set; }

        /// <summary>
        /// True if the cmdlet has no output but has a parameter that can be piped in; this
        /// can be echoed to the pipeline if the user supplies the -PassThru switch.
        /// </summary>
        public bool RequiresPassThruGeneration
        {
            get
            {
                return CurrentOperation.PassThru != null || AnalyzedResult.PassThruParameter != null;
            }                
        }

        /// <summary>
        /// Simple analysis log message indicating whether the pass thru value was set automatically
        /// or via a configuration file override.
        /// </summary>
        public string PassThruSource { get; set; }

        /// <summary>
        /// Helper to return the type of the data that will be sent if the user adds the -PassThru
        /// parameter. This can be set explicitly in the service operation's PassThru child element
        /// or we can determine it automatically from a simple expression referencing either one of
        /// the cmdlet's parameters (Expression = this.XYZ) or the context member (Expression = cmdletContext.XYZ).
        /// </summary>
        public string PassThruTypeName
        {
            get
            {
                if (CurrentOperation == null)
                    return null;

                if (CurrentOperation.PassThru != null && !string.IsNullOrEmpty(CurrentOperation.PassThru.Type))
                    return CurrentOperation.PassThru.Type;

                SimplePropertyInfo passThruParameter = null;
                if (CurrentOperation.PassThru != null)
                {
                    string passThruParameterName = null;
                    var expression = CurrentOperation.PassThru.Expression;
                    if (expression.StartsWith("this.", StringComparison.Ordinal))
                    {
                        passThruParameterName = expression.Substring(5);
                        foreach (var p in AnalyzedParameters)
                        {
                            if (p.CmdletParameterName.Equals(passThruParameterName, StringComparison.Ordinal))
                            {
                                passThruParameter = p;
                                break;
                            } 
                        }
                    }
                    else if (expression.StartsWith("cmdletContext.", StringComparison.Ordinal))
                    {
                        passThruParameterName = expression.Substring(14);
                        foreach (var p in AnalyzedParameters)
                        {
                            if (p.AnalyzedName.Equals(passThruParameterName, StringComparison.Ordinal))
                            {
                                passThruParameter = p;
                                break;
                            }
                        }
                    }
                    else
                        Logger.LogError("{0} - PassThruTypeName helper unable to determine parameter to reference from expression {1}", CurrentOperation.MethodName, expression);
                }
                else
                    passThruParameter = AnalyzedResult.PassThruParameter;

                if (passThruParameter == null)
                    Logger.LogError("{0} - PassThru indicated for operation but cannot find parameter or PassThruOverride expression to determine type.", CurrentOperation.MethodName);

                switch (passThruParameter.CollectionType)
                {
                    case SimplePropertyInfo.PropertyCollectionType.NoCollection:
                        return passThruParameter.PropertyType.FullName;

                    case SimplePropertyInfo.PropertyCollectionType.IsGenericList:
                        return passThruParameter.PropertyType.GetGenericArguments()[0].FullName;

                    case SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary:
                        return passThruParameter.PropertyType.FullName;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the correct object noun to use in confirmation messages we generate
        /// for the ShouldContinue call (if the cmdlet is attributed with SupportsShouldProcess).
        /// Note that some operations do not have a noun at all, so we yield an empty string
        /// in that scenario (the confirmation messages we generate read ok with empty/non-empty
        /// noun values).
        /// </summary>
        /// <returns></returns>
        public string ConfirmationMessageNoun
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentOperation.ShouldProcessMsgNoun))
                    return CurrentOperation.ShouldProcessMsgNoun;

                return CurrentOperation.OriginalNoun ?? string.Empty;
            }
        }

        /// <summary>
        /// Returns the ConfirmImpact setting. If the shell's $ConfirmPreference 
        /// is equal to or lower than the cmdlet's declared impact, a prompt is output
        /// by the call to ShouldProcess. By default, the shell is at 'high' so only
        /// our deletion cmdlets issue a prompt. 
        /// </summary>
        public ConfirmImpact ConfirmImpactSetting
        {
            get
            {
                if (_highImpactVerbs.Contains(CurrentOperation.SelectedVerb))
                    return ConfirmImpact.High;

                return ConfirmImpact.Medium;
            }
        }

        /// <summary>
        /// Returns formatted string containing details of the operation to be performed
        /// for use in confirmation messages. 
        /// </summary>
        public string FormattedOperationForConfirmationMsg
        {
            get
            {
                return string.Format("{0}-{1} ({2})",
                                     CurrentOperation.SelectedVerb,
                                     CurrentOperation.SelectedNoun,
                                     CurrentOperation.MethodName);

            }
        }

        #endregion

        #region Private properties

        private PluralizationService Pluralization { get; set; }

        /// <summary>
        /// Terminating word fragments shorter than this will not be made singular
        /// </summary>
        private const int MinLengthForSingularization = 3;

        /// <summary>
        /// Collection of terminating word fragments to retain as-is or manually
        /// update (for cases where the pluralization service gets it wrong).
        /// If the value for a key is empty, we do not alter the fragment otherwise
        /// we replace the fragment with a new value.
        /// </summary>
        private readonly Dictionary<string, string> _manualFragmentRenames = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "Data", null },           // pluralization turns it to 'Datum'
            { "Cookies", "Cookie" },    // pluralization service yields 'Cooky' 
            { "Iops", null },           // pluralization yields Iop
        };

        /// <summary>
        /// The collection of verbs that do not require the cmdlet to be attributed
        /// with 'SupportsShouldProcess'. From the PowerShell SDK docs - '...any cmdlet 
        /// that modifies the system' needs to be attributed.
        /// </summary>
        private readonly HashSet<string> _supportsShouldProcessVerbSuppressions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "get", "test", "find"
        };

        /// <summary>
        /// Ordered collection of parameter name suffixes that we will look for when
        /// attempting to auto-discover the parameter that should be used in the
        /// ShouldProcess test in ProcessRecord. If none of the parameters ends with
        /// one of these suffixes, or multiple parameters have the same suffix or
        /// multiple parameters exhibit more than one suffix, an error will be logged
        /// requiring the user to specify manual configuration using ShouldProcessTarget.
        /// </summary>
        private readonly List<string> _supportsShouldProcessParameterSuffixes = new List<string>
        {
            "Id", "Name", "Arn"
        };

        /// <summary>
        /// Collection of verbs for which the cmdlet's ConfirmImpact setting should be 'high'
        /// instead of our default of 'medium'.
        /// </summary>
        private readonly HashSet<string> _highImpactVerbs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "remove"
        };

        /// <summary>
        /// Path and name of the log file to which anlysis results for this method will be 
        /// appended.
        /// </summary>
        private string AnalysisLogfile { get; set; }

        /// <summary>
        /// The set of PowerShell approved verbs we can select from.
        /// </summary>
        private static readonly HashSet<string> ApprovedVerbs = GetApprovedVerbs();

        private readonly Dictionary<Type, List<SimplePropertyInfo>> _rootSimplePropertiesCache = new Dictionary<Type, List<SimplePropertyInfo>>();
        private readonly Dictionary<Type, List<SimplePropertyInfo>> _flatPropertiesCache = new Dictionary<Type, List<SimplePropertyInfo>>();

        #endregion

        public MethodInfo Method { get; private set; }

        public OperationAnalyzer(string analysisLog)
        {
            // Doesn't appear to be a costly operation, so init per instance for now. Invariant
            // culture is not supported (yields exception).
            Pluralization = PluralizationService.CreateService(new CultureInfo("en-US"));

            AnalysisLogfile = analysisLog;
            SupportsShouldProcessInspectionResult = null;
        }

        /// <summary>
        /// Analyzes the properties in the operation's request class to arrive at the
        /// set of parameters to be output for the cmdlet. The set, on output, will
        /// contain only the parameters to be generated complete with the final names
        /// and any relevant aliases (for backwards compatibility or so configured)
        /// attached the service operations parameter aliases maps.
        /// </summary>
        public void Analyze(CmdletGenerator generator, MethodInfo methodInfo)
        {
            // keep this since we can use it to recover documentation when we
            // write the cmdlet source code
            Method = methodInfo;

            RequestType = GetRequestType(methodInfo);
            ReturnType = methodInfo.ReturnType;

            // determine cmdlet verb/noun based on inspection or config directions
            if (!DetermineVerbAndNoun(generator))
            {
                Logger.LogError("Cannot determine verb-noun values for method " + CurrentOperation.MethodName);
                return;
            }

            DetermineParameters(generator);
            DeterminePipelineParameter(generator);
            DetermineSupportsShouldProcessRequirement(generator);
            DetermineResult(generator);
            DeterminePassThruRequirement(generator);
            TestForCollectablePipelineParameter(generator);

            LogAnalysisResults();
        }

        public SimplePropertyInfo CreateSimplePropertyFor(PropertyInfo property, SimplePropertyInfo parent)
        {
            var shouldFlatten = true;

            string propertyTypeFullName;
            var collectionType = SimplePropertyInfo.PropertyCollectionType.NoCollection;
            Type[] genericCollectionTypes = null;

            // determine if property should be flattened based solely on its type, or is a generic List<T> we
            // can replace with T[] to follow PS parameter convention
            if (property.PropertyType.IsGenericType)
            {
                // if the property is a generic List, it would be more pleasant for users, and
                // more in line with PS convention, to remap it here to an array type - something
                // to consider. The change would affect the parameter but not the inner context
                // and (of course) the request object property. It would affect help though.
                if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("List`"))
                {
                    genericCollectionTypes = property.PropertyType.GetGenericArguments();
                    collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericList;
                }
                else if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("Dictionary`"))
                {
                    genericCollectionTypes = property.PropertyType.GetGenericArguments();
                    collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary;
                }

                propertyTypeFullName = property.PropertyType.GetGenericTypeDefinition().FullName;
            }
            else
                propertyTypeFullName = property.PropertyType.FullName;

            if (AllModels.TypesNotToFlatten.Contains(propertyTypeFullName, StringComparer.Ordinal))
                shouldFlatten = false;

            var propertyTypeName = GetPropertyTypeName(property.Name, property.PropertyType);
            var simpleProperty = new SimplePropertyInfo(property,
                                                        parent,
                                                        propertyTypeName,
                                                        AssemblyDocumentation,
                                                        collectionType,
                                                        genericCollectionTypes,
                                                        IsEmitLimiter(property.Name));

            if (shouldFlatten)
            {
                var propertyTypeProperties = property.PropertyType.GetProperties().Where(p =>
                {
                    // skip properties that aren't read/write
                    if (!p.CanWrite || !p.CanRead)
                        return false;
                    // skip index properties
                    if (p.GetIndexParameters().Length > 0)
                        return false;
                    return true;
                }).ToArray();

                if (propertyTypeProperties.Length > 0)
                {
                    foreach (var childProperty 
                        in propertyTypeProperties.Select(propertyTypeProperty
                            => CreateSimplePropertyFor(propertyTypeProperty, simpleProperty)))
                    {
                        simpleProperty.Children.Add(childProperty);
                    }
                }
            }
            return simpleProperty;
        }

        public static bool IsEmitLimiter(string propertyName, AutoIteration autoIterationSettings, string methodName)
        {
            if (autoIterationSettings == null)
                return false;

            var shouldAutoIterate = !autoIterationSettings.ExclusionSet.Contains(methodName);
            var isEmitLimit = autoIterationSettings.IsEmitLimit(propertyName);
            var isEmitLimiter = shouldAutoIterate && isEmitLimit;
            return isEmitLimiter;
        }

        public static string ToLowerCamelCase(string name)
        {
            var sb = new StringBuilder(name);
            sb[0] = char.ToLowerInvariant(sb[0]);
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if the parameter (identified by fully flattened name) is tagged as excluded
        /// at either the operation or model level.
        /// </summary>
        /// <param name="analyzedName"></param>
        /// <returns></returns>
        public bool IsExcludedParameter(string analyzedName)
        {
            return IsExcludedParameter(analyzedName, CurrentModel, CurrentOperation);
        }

        /// <summary>
        /// Returns true if the parameter (identified by fully flattened name) is tagged as excluded
        /// at either the operation or model level.
        /// </summary>
        /// <param name="analyzedName"></param>
        /// <param name="model"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static bool IsExcludedParameter(string analyzedName, ConfigModel model, ServiceOperation operation)
        {
            if (model.ShouldExcludeParameter(analyzedName))
                return true;

            return operation.ShouldExcludeParameter(analyzedName);
        }

        /// <summary>
        /// Returns the closest available parameter customization, null if the
        /// parameter has not been customized
        /// </summary>
        /// <param name="analyzedName"></param>
        /// <returns></returns>
        public Param GetParameterCustomization(string analyzedName)
        {
            return GetParameterCustomization(analyzedName, CurrentModel, CurrentOperation);
        }

        /// <summary>
        /// Returns the closest available parameter customization, null if the
        /// parameter has not been customized
        /// </summary>
        /// <param name="analyzedName"></param>
        /// <param name="model"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static Param GetParameterCustomization(string analyzedName, ConfigModel model, ServiceOperation operation)
        {
            if (operation.CustomParameters.ContainsKey(analyzedName))
                return operation.CustomParameters[analyzedName];

            if (model.CustomParameters.ContainsKey(analyzedName))
                return model.CustomParameters[analyzedName];

            return null;
        }

        public string GetValidTypeName(Type type)
        {
            return GetValidTypeName(type, CurrentModel);
        }

        public static string GetValidTypeName(Type type, ConfigModel currentModel)
        {
            if (type.IsArray)
                return GetValidTypeName(type.GetElementType(), currentModel) + "[]";

            if (type.IsGenericType)
            {
                var genericArguments = type.GetGenericArguments();
                var genericType = type.GetGenericTypeDefinition();

                if (genericType.IsAssignableFrom(typeof(List<>)))
                    return string.Format("List<{0}>", GetValidTypeName(genericArguments[0], currentModel));

                if (genericType.IsAssignableFrom(typeof(IEnumerable<>)))
                    return string.Format("IEnumerable<{0}>", GetValidTypeName(genericArguments[0], currentModel));

                if (genericType.IsAssignableFrom(typeof(Dictionary<,>)))
                    return string.Format("Dictionary<{0}, {1}>",
                                         GetValidTypeName(genericArguments[0], currentModel),
                                         GetValidTypeName(genericArguments[1], currentModel));

                if (genericType.FullName.Equals("Amazon.S3.Model.Tuple`2", StringComparison.Ordinal))
                    return string.Format("Tuple<{0}, {1}>",
                                         GetValidTypeName(genericArguments[0], currentModel),
                                         GetValidTypeName(genericArguments[1], currentModel));

                // we'll mark the parameter later that we need to check the BoundParameters collection
                // before attempting to use
                if (genericType.IsAssignableFrom(typeof(Nullable<>)))
                    return string.Format("{0}", GetValidTypeName(genericArguments[0], currentModel));

                throw new Exception(string.Format("Can't determine generic type. Type = [{0}], GenericType = [{1}]", type.FullName, genericType.FullName));
            }

            // always return namespace-scoped type names to avoid cross-service conflicts
            string scopedName = string.Format("{0}.{1}", type.Namespace, type.Name);
            return scopedName;
        }

        /// <summary>
        /// Check if the parameter can be set by by-value pipeline input. If so, the parameter
        /// attribute for the parameter will include 'PipelineParameter = true'. Each service
        /// operation can supply an operation-specific value or we can fall back to a cross-
        /// operation setting for the service.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public bool CanAcceptValueFromPipeline(string paramName)
        {
            // only consider using service global definition if there is not a local operation override,
            // otherwise we can tag multiple parameters as value-from-pipeline for cmdlets who use service-global
            // parameter as a secondary parameter on the cmdlet
            if (!string.IsNullOrEmpty(CurrentOperation.PipelineParameter))
                return string.Compare(CurrentOperation.PipelineParameter, paramName, StringComparison.Ordinal) == 0;

            return string.Compare(CurrentModel.PipelineParameter, paramName, StringComparison.Ordinal) == 0;
        }

        /// <summary>
        /// Scans the set of service-global and operation-specific PositionalParameter lists
        /// to determine whether a Position value should be emitted for the specified parameter.
        /// The order is determined by the parameter names declared for the global and per-operation
        /// PositionalParameters lists.
        /// </summary>
        /// <param name="paramName">The name of the parameter being emitted (real name)</param>
        /// <returns>-1 if no Position data should be emitted, otherwise the position ordinal as declared in the config</returns>
        public int GetParameterPositionData(string paramName)
        {
            // If the operation did not override value-from-pipeline, the positional set is the
            // ordered union of service global value-from-pipeline + service specific positional params 
            // otherwise we use the ordered union of the operation's value-from-pipeline plus operation-
            // specific positional params.
            // To simplify the configuration and avoid data duplication, we rule that the pipelineable parameter 
            // is always position 0. A service configuration containing just positional data without a pipeline
            // value is technically invalid.
            if (string.IsNullOrEmpty(CurrentOperation.PipelineParameter))
            {
                if (paramName.Equals(CurrentModel.PipelineParameter, StringComparison.Ordinal))
                    return 0;
            }
            else
            {
                if (paramName.Equals(CurrentOperation.PipelineParameter, StringComparison.Ordinal))
                    return 0;
            }

            // we also allow the config to override value-from-pipeline but reuse service-global positional
            // data
            if (CurrentOperation.PositionalParametersList.Length > 0)
            {
                for (int i = 0; i < CurrentOperation.PositionalParametersList.Length; i++)
                {
                    if (paramName.Equals(CurrentOperation.PositionalParametersList[i], StringComparison.Ordinal))
                        return i + 1;
                }
            }
            else
            {
                for (int i = 0; i < CurrentModel.PositionalParametersList.Length; i++)
                {
                    if (paramName.Equals(CurrentModel.PositionalParametersList[i], StringComparison.Ordinal))
                        return i + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Returns the true number of parameters for an operation, disregarding any that
        /// have been declared as part of auto-iteration support.
        /// </summary>
        public int NonIterationParameterCount
        {
            get
            {
                var iterationSettings = AutoIterateSettings;
                if (iterationSettings == null)
                    return AnalyzedParameters.Count;

                return AnalyzedParameters.Count(p => !iterationSettings.IsIterationParameter(p.AnalyzedName));
            }
        }

        /// <summary>
        /// Inspects the api method and determines the verb/noun combination to use, unless directed otherwise
        /// by config data. Returns the selected verb/noun pair in the ServiceOperation
        /// </summary>
        /// <param name="generator"></param>
        /// <returns></returns>
        private bool DetermineVerbAndNoun(CmdletGenerator generator)
        {
            var methodName = CurrentOperation.MethodName;

            string noun = null;
            var verb = methodName;

            for (var i = 1; i < methodName.Length; i++)
            {
                if (Char.IsUpper(methodName[i]))
                {
                    verb = methodName.Substring(0, i);
                    noun = methodName.Substring(i);
                    break;
                }
            }

            // save the noun part of the split method name so we can potentially use it for the 'operation'
            // message if the cmdlet requires confirmation
            CurrentOperation.OriginalNoun = noun;

            if (!string.IsNullOrEmpty(CurrentOperation.RequestedVerb))
                verb = CurrentOperation.RequestedVerb;
            if (!string.IsNullOrEmpty(CurrentOperation.RequestedNoun))
                noun = CurrentOperation.RequestedNoun;

            if (verb.Length <= 2 || string.IsNullOrEmpty(noun))
                return false;

            var originalVerb = verb;
            var originalNoun = noun;

            var remapped = false;
            remapped |= AssignVerb(ref verb);
            remapped |= AssignNoun(ref noun);

            // append service prefix
            if (!string.IsNullOrEmpty(CurrentModel.ServiceNounPrefix))
            {
                noun = CurrentModel.ServiceNounPrefix + noun;
                originalNoun = CurrentModel.ServiceNounPrefix + originalNoun;
            }

            if (remapped)
            {
                AliasStore.Instance.AddAlias(string.Format("{0}-{1}", verb, noun),
                                             string.Format("{0}-{1}", originalVerb, originalNoun));
            }

            if (!ApprovedVerbs.Contains(verb))
                Logger.LogError("Unapproved verb [{0}] in operation [{1}]", verb, CurrentOperation.MethodName);

            CurrentOperation.SelectedVerb = verb;
            CurrentOperation.SelectedNoun = noun;

            return true;
        }

        /// <summary>
        /// Reflect over the request type properties, unrolling nested types, to obtain the 
        /// flattened set of properties to be exposed as parameters on the cmdlet.
        /// </summary>
        /// <param name="generator"></param>
        private void DetermineParameters(CmdletGenerator generator)
        {
            // analyze the request members to get a flattened set of all
            // properties
            var allProperties = GetFlatProperties(RequestType).ToList();

            // remove excluded properties, if any, from the flattened set
            var nonExcludedProperties
                = allProperties.Where(prop => !IsExcludedParameter(prop.AnalyzedName, CurrentModel, CurrentOperation)).ToList();
            if (allProperties.Count > nonExcludedProperties.Count)
            {
                Console.WriteLine("Properties being removed, service = {0}, op = {1}",
                                    CurrentModel.ServiceNounPrefix,
                                    CurrentOperation.MethodName);
                allProperties = nonExcludedProperties;
            }

            // the remainder will now be the cmdlet parameters, on which we will detect autoiteration
            // and do some name shortening/singularization
            AnalyzedParameters = new List<SimplePropertyInfo>(allProperties);

            FinalizeParameterNames();
            
            // also gather the internal root (non-flattened) properties -- these are what the
            // cmdlet will bind the parameters to in the executor
            var rootProperties = GetRootSimpleProperties(RequestType)
                                    .Where(simpleProperty => !IsExcludedParameter(simpleProperty.AnalyzedName, CurrentModel, CurrentOperation))
                                    .ToList();
            RequestProperties = new List<SimplePropertyInfo>(rootProperties);
        }

        /// <summary>
        /// If the operation has a single parameter that does not match any service-level
        /// declaration of PipelineParameter, and there is no PipelineParameter declaration
        /// on the service operation, then adopt the one and only parameter as being
        /// acceptable to be piped in.
        /// </summary>
        /// <param name="generator"></param>
        private void DeterminePipelineParameter(CmdletGenerator generator)
        {
            if (!AnalyzedParameters.Any() || CurrentOperation.NoPipelineParameter)
                return;

            if (!string.IsNullOrEmpty(CurrentOperation.PipelineParameter)
                    && !string.IsNullOrEmpty(CurrentModel.PipelineParameter)
                    && string.Equals(CurrentOperation.PipelineParameter, CurrentModel.PipelineParameter, StringComparison.Ordinal))
            {
                Logger.LogError("Redundant pipeline parameter configuration on service operation {0}:{1}, already set at model level",
                                CurrentModel.ServiceNounPrefix, CurrentOperation.MethodName);
            }

            var declaredPipelineParam = CurrentOperation.PipelineParameter;
            if (string.IsNullOrEmpty(declaredPipelineParam))
                declaredPipelineParam = CurrentModel.PipelineParameter;

            // If there is more than one parameter, but no pipeline parameter defined,
            // flag it as an error because it could be a breaking change. We may have
            // auto-assigned the pipeline parameter in prior releases due to their only
            // being one parameter, and now the presence of more than one could change
            // that.
            if (NonIterationParameterCount > 1)
            {
                if (string.IsNullOrEmpty(declaredPipelineParam))
                    Logger.LogError("No pipeline parameter has been declared for {0}:{1} but more than 1 parameter exists. THIS MAY BE A BREAKING CHANGE - INVESTIGATE THIS.",
                                    CurrentModel.ServiceNounPrefix, CurrentOperation.MethodName);
                return;
            }

            var parameter = AnalyzedParameters.First();

            // we could validate that it matches the single parameter; only really interested in
            // unnecessary attribution on service operation elements at this time
            if (!string.IsNullOrEmpty(CurrentOperation.PipelineParameter))
            {
                if (CurrentOperation.PipelineParameter.Equals(parameter.AnalyzedName, StringComparison.Ordinal))
                    Logger.LogError("Redundant pipeline parameter configuration for {0}:{1}, can be auto-assigned from single parameter", 
                                    CurrentModel.ServiceNounPrefix, CurrentOperation.MethodName);

                return;
            }

            // if the parameter matches the declaration at operation or service level, we're good
            if (!string.IsNullOrEmpty(declaredPipelineParam)
                    && parameter.AnalyzedName.Equals(declaredPipelineParam, StringComparison.Ordinal))
                return;

            CurrentOperation.PipelineParameter = parameter.AnalyzedName;
        }

        /// <summary>
        /// If the cmdlet changes system state, indicate that it must be attributed with 
        /// SupportsShouldProcess and determine by configuration or parameter name analysis 
        /// which parameter holds the identity of the resource that the shell will use when 
        /// it displays the confirmation/whatif message. The recorded target is the internal
        /// name of the parameter, not the singularized/shortened public name.
        /// </summary>
        /// <remarks>This inspection can be done any time after the parameters have been determined.</remarks>
        /// <param name="generator"></param>
        private void DetermineSupportsShouldProcessRequirement(CmdletGenerator generator)
        {
            if (_supportsShouldProcessVerbSuppressions.Contains(this.CurrentOperation.SelectedVerb))
                return;

            if (CurrentOperation.IgnoreSupportsShouldProcess)
                return;

            // if the cmdlet has no parameters, we have an 'anonymous' target and will only
            // prompt the user to show the operation to be performed
            if (AnalyzedParameters.Count == 0)
            {
                SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
                {
                    Status = SupportsShouldProcessInspection.InspectionStatus.AnonymousTarget,
                    AnalysisMessage = "No parameters, setting anonymous target",
                };
                return;
            }

            if (CurrentOperation.AnonymousShouldProcessTarget)
            {
                // this means no parameter is suitable so we should proceed as if the cmdlet had
                // no parameters and prompt based on just the operation
                SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
                {
                    Status = SupportsShouldProcessInspection.InspectionStatus.AnonymousTarget,
                    AnalysisMessage = "AnonymousShouldProcessTarget specified in config"
                };
                return;
            }

            if (AnalyzedParameters.Count == 1)
            {
                SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
                {
                    Status = SupportsShouldProcessInspection.InspectionStatus.TargetFromAnalysis,
                    TargetParameter = AnalyzedParameters[0],
                    AnalysisMessage = "Single parameter, auto-selected as target"
                };
                return;
            }

            // if the config specifies the parameter to use as the target then obey
            if (!string.IsNullOrEmpty(CurrentOperation.ShouldProcessTarget))
            {
                foreach (var parameter in AnalyzedParameters.Where(parameter => parameter.AnalyzedName.Equals(CurrentOperation.ShouldProcessTarget, StringComparison.Ordinal)))
                {
                    SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
                    {
                        Status = SupportsShouldProcessInspection.InspectionStatus.TargetFromConfig,
                        TargetParameter = parameter
                    };
                    return;
                }
            }

            // otherwise attempt auto-discovery based on parameter name suffixes - note
            // that we use the finalized names of the parameters here, since PowerShell
            // will introspect on them.
            var potentialTargets = new List<SimplePropertyInfo>();
            foreach (var suffix in _supportsShouldProcessParameterSuffixes)
            {
                potentialTargets.AddRange(from parameter in AnalyzedParameters 
                                          where parameter.CmdletParameterName.EndsWith(suffix) 
                                          select parameter);
            }

            switch (potentialTargets.Count)
            {
                case 0:
                    {
                        var pipelineParameter = AcceptsValueFromPipelineParameter;
                        if (pipelineParameter != null)
                        {
                            SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
                            {
                                Status = SupportsShouldProcessInspection.InspectionStatus.TargetFromAnalysis,
                                TargetParameter = pipelineParameter,
                                AnalysisMessage = "Auto-assigned from pipeline parameter (verify!)"
                            };
                            return;
                        }
                    }
                    break;

                case 1:
                    SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
                    {
                        Status = SupportsShouldProcessInspection.InspectionStatus.TargetFromAnalysis,
                        TargetParameter = potentialTargets[0],
                        AnalysisMessage = "Single parameter with recognized suffix"
                    };
                    return;

                default:
                    if (potentialTargets.Count > 1)
                    {
                        // When multiple targets exist, if one of them is the value-from-pipeline 
                        // parameter we can (probably) safely assume it should be the target (if this
                        // is wrong it can be safely rectified by adding a manual entry to the config
                        // for the operation).
                        var pipelineParameter = AcceptsValueFromPipelineParameter;
                        if (pipelineParameter != null)
                        {
                            foreach (var potentialTarget in potentialTargets)
                            {
                                if (potentialTarget.AnalyzedName.Equals(pipelineParameter.AnalyzedName, StringComparison.Ordinal))
                                {
                                    SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
                                    {
                                        Status = SupportsShouldProcessInspection.InspectionStatus.TargetFromAnalysis,
                                        TargetParameter = potentialTarget,
                                        AnalysisMessage = "Matched target parameter with value-from-pipeline configuration (verify!)"
                                    };
                                    return;
                                }
                            }
                        }
                    }
                    break;
            }

            var sb = new StringBuilder();
            sb.AppendFormat("Cannot determine target parameter - ");
            if (potentialTargets.Count == 0)
            {
                sb.AppendFormat("no parameter ends with a recognized suffix from set: {0}", string.Join(",", _supportsShouldProcessParameterSuffixes));
            }
            else
            {
                var targetNames = new StringBuilder();
                foreach (var pt in potentialTargets)
                {
                    if (targetNames.Length > 0)
                        targetNames.Append(",");
                    targetNames.Append(pt.AnalyzedName);
                }
                sb.AppendFormat("multiple possible targets exist (no pipeline-by-value match) - {0}", targetNames);
            }

            SupportsShouldProcessInspectionResult = new SupportsShouldProcessInspection
            {
                Status = SupportsShouldProcessInspection.InspectionStatus.ErrorMultipleTargetOptions,
                AnalysisMessage = sb.ToString()
            };

            Logger.LogError("{0} Method {1} SupportsShouldProcess inspection {2}", 
                            CurrentModel.ServiceNounPrefix,
                            CurrentOperation.MethodName, 
                            SupportsShouldProcessInspectionResult.AnalysisMessage);
        }

        /// <summary>
        /// Wraps the return type of the method.
        /// </summary>
        /// <param name="generator"></param>
        private void DetermineResult(CmdletGenerator generator)
        {
            AnalyzedResult = new AnalyzedResult(generator, this);
        }

        /// <summary>
        /// Phase 4 of the analysis: if the output from the cmdlet is void but an object can 
        /// be piped in, record that we should add the -PassThru switch parameter and if set
        /// by the user, echo the input object to the pipeline.
        /// </summary>
        /// <remarks>This inspection must be performed after the result has been analyzed.</remarks>
        /// <param name="generator"></param>
        private void DeterminePassThruRequirement(CmdletGenerator generator)
        {
            if (AnalyzedResult.OutputType != AnalyzedResult.ResultOutputTypes.Empty)
                return;

            if (CurrentOperation.PassThru != null)
            {
                PassThruSource = string.Format("Config override: {0}", CurrentOperation.PassThru.Expression);
                return;
            }

            var pipelineParameter = AcceptsValueFromPipelineParameter;

            if (pipelineParameter != null)
            {
                AnalyzedResult.PassThruParameter = pipelineParameter;
                PassThruSource = string.Format("Auto-assigned from pipeline parameter: {0}", pipelineParameter.CmdletParameterName);
            }
        }

        /// <summary>
        /// Tests the pipeline-by-value parameter, if set, to see if it could be exposed
        /// as an array. This PowerShell convention gives the user the freedom to either
        /// pipe in a collection (pipeline enumerates one by one, cmdlet receives one element
        /// at a time) or to pass a collection to the parameter (cmdlet receives the
        /// whole collection at once and enumerates itself over the elements).
        /// </summary>
        /// <param name="generator"></param>
        private void TestForCollectablePipelineParameter(CmdletGenerator generator)
        {
            var pipelineParameter = AcceptsValueFromPipelineParameter;
            if (pipelineParameter == null)
                return;

            if (!IsCollectionType(pipelineParameter.PropertyType))
            {
                PromotePipelineParameterToCollection = string.Format("Parameter '{0}' is of type '{1}', consider promoting to collection type.",
                                                                      pipelineParameter.CmdletParameterName,
                                                                      pipelineParameter.PropertyTypeName);
            }
        }

        /// <summary>
        /// Returns true if the type is a recognized collection type. Used
        /// primarily to detect non-collection pipeline-by-value parameter types
        /// that we can auto-promote to a collection.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsCollectionType(Type type)
        {
            if (type.IsArray)
                return true;

            // get false-positive out of the way early, as string is IEnumerable
            if (type.FullName.Equals("System.String", StringComparison.Ordinal))
                return false;

            return type.GetInterfaces().Any(x => x == typeof (System.Collections.IEnumerable));
        }

        private bool AssignVerb(ref string verb)
        {
            var oldVerb = verb;
            string newVerb = null;
            if (AllModels.VerbMappings.ContainsKey(verb))
            {
                newVerb = AllModels.VerbMappings[verb];
                Logger.Log("Replaced SDK verb [{0}] with Global PS verb [{1}]", oldVerb, newVerb);
            }

            if (newVerb == null && CurrentModel.VerbMappings.ContainsKey(verb))
            {
                newVerb = CurrentModel.VerbMappings[verb];
                Logger.Log("Replaced SDK verb [{0}] with PS verb [{1}]", oldVerb, newVerb);
            }

            if (newVerb == null)
                return false;

            verb = newVerb;
            return true;
        }

        private bool AssignNoun(ref string noun)
        {
            var oldNoun = noun;
            string newNoun = null;
            if (AllModels.NounMappings.ContainsKey(noun))
            {
                newNoun = AllModels.NounMappings[noun];
                Logger.Log("Replaced SDK noun [{0}] with Global PS noun [{1}]", oldNoun, newNoun);
            }

            if (newNoun == null && CurrentModel.NounMappings.ContainsKey(noun))
            {
                newNoun = CurrentModel.NounMappings[noun];
                Logger.Log("Replaced SDK noun [{0}] with PS noun [{1}]", oldNoun, newNoun);
            }

            if (newNoun == null)
                return false;

            noun = newNoun;
            return true;
        }

        /// <summary>
        /// Evaluate the analyzed parameters to find the one (if any) that matches the
        /// PipelineParameter declared for the operation or globally at the
        /// service config level. Null is returned if the cmdlet has no parameter that
        /// can be piped into.
        /// </summary>
        private SimplePropertyInfo AcceptsValueFromPipelineParameter
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentOperation.PipelineParameter))
                {
                    foreach (var parameter in AnalyzedParameters.Where(parameter => parameter.AnalyzedName.Equals(CurrentOperation.PipelineParameter)))
                    {
                        return parameter;
                    }
                }

                if (!string.IsNullOrEmpty(CurrentModel.PipelineParameter))
                {
                    return AnalyzedParameters.FirstOrDefault(parameter => parameter.AnalyzedName.Equals(CurrentModel.PipelineParameter));
                }

                return null;
            }
        }

        private Type GetRequestType(MethodInfo method)
        {
            var requestParameters = method.GetParameters();
            if (requestParameters.Length == 0)
                return null;
            if (requestParameters.Length != 1)
            {
                Logger.Log("Method {0} has {1} parameters, skipping", method.Name, requestParameters.Length);
                return null;
            }
            var requestType = requestParameters[0].ParameterType;
            if (requestType.IsInterface)
            {
                Logger.Log("Request type {0} is an interface, skipping", requestType.FullName);
                return null;
            }
            return requestType;
        }

        private static HashSet<string> GetApprovedVerbs()
        {
            var allVerbs = new HashSet<string>(StringComparer.Ordinal);
            AddVerbs(typeof(VerbsCommon), allVerbs);
            AddVerbs(typeof(VerbsCommunications), allVerbs);
            AddVerbs(typeof(VerbsData), allVerbs);
            AddVerbs(typeof(VerbsDiagnostic), allVerbs);
            AddVerbs(typeof(VerbsLifecycle), allVerbs);
            AddVerbs(typeof(VerbsOther), allVerbs);
            AddVerbs(typeof(VerbsSecurity), allVerbs);

            // remove "Resize" and "Optimize", as these are 3.0 verbs
            allVerbs.Remove("Resize");
            allVerbs.Remove("Optimize");

            // Should we have an assert here for the number of verbs? If we change the reference 
            // and get more verbs, that should cause a quick break.

            return allVerbs;
        }

        private static void AddVerbs(IReflect type, ISet<string> allVerbs)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var name in fields.Select(field => field.Name))
            {
                allVerbs.Add(name);
            }
        }

        /// <summary>
        /// Analyze the supplied properties to arrive at the final name that should be used.
        /// Names can be forced via configuration entries or by automatic analysis. Automatic
        /// analysis can shorten flattened structure names to just one _ component and make
        /// the final word fragment singular.
        /// </summary>
        private void FinalizeParameterNames()
        {
            // used to report collisions when we rename parameters
            var processedParameters = new Dictionary<string, SimplePropertyInfo>(StringComparer.Ordinal);

            // possible scenarios:
            //   param Name="foo" Alias="baz"                      => add alias, also auto-rename
            //   param Name="foo" Exclude="true"                   => do not emit parameter
            //   param Name="foo" NewName="bar"                    => rename param, no alias
            //   param Name="foo" NewName="bar" Alias="baz"        => rename param with alias
            //   param Name="foo" AutoRename="false"               => do not rename param
            //   param Name="foo" AutoRename="false" Alias="baz"   => do not rename but add alias

            foreach (var property in AnalyzedParameters)
            {
                var attemptAutoRename = true;
                var parameterCustomization = GetParameterCustomization(property.AnalyzedName);
                if (parameterCustomization != null)
                {
                    // wire up the analyzed parameter with its config customization - this
                    // is the earliest opportunity to do this
                    property.Customization = parameterCustomization;

                    // useful to throw an error here is Exclude is specified with other data?
                    if (parameterCustomization.Exclude)
                        continue;

                    if (!string.IsNullOrEmpty(parameterCustomization.NewName))
                    {
                        RecordParameterRename(property,
                                              parameterCustomization.NewName,
                                              processedParameters);
                        attemptAutoRename = false;
                    }
                    else
                        attemptAutoRename = parameterCustomization.AutoRename;
                }

                if (attemptAutoRename)
                {
                    // inspect the name to determine if it can be reduced in length if we flattened a deep
                    // property hierarchy
                    var alternateName = property.AnalyzedName;
                    var underscores = property.AnalyzedName.Count(c => c == '_');
                    if (underscores > 1)
                        alternateName = RebaseNameToFinalParent(alternateName);

                    var attemptToSingularize = property.IsValidForSingularization;
                    if (attemptToSingularize)
                    {
                        string namePrefix;
                        string finalFragment;
                        SplitName(alternateName, out namePrefix, out finalFragment);
                        alternateName = finalFragment != null
                            ? string.Concat(namePrefix, SingularizeTerm(finalFragment))
                            : SingularizeTerm(alternateName);
                    }

                    if (alternateName.Length != property.AnalyzedName.Length)
                    {
                        RecordParameterRename(property,
                                              alternateName,
                                              processedParameters);
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to convert the supplied term to singular form provided
        /// it exceeds minimum length limits, it not a term marked as needing
        /// to not be singularized and is actually plural. If the term cannot
        /// be modified, the original value is returned.
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        private string SingularizeTerm(string term)
        {
            if (term.Length >= MinLengthForSingularization)
            {
                if (_manualFragmentRenames.ContainsKey(term))
                {
                    var replacement = _manualFragmentRenames[term];
                    return replacement ?? term;
                }

                if (Pluralization.IsPlural(term))
                    return Pluralization.Singularize(term);
            }

            return term;
        }

        /// <summary>
        /// Returns the last parent_property name combination from the supplied name
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private static string RebaseNameToFinalParent(string fullName)
        {
            var index = fullName.LastIndexOf('_') - 1;
            if (index < 0)
                return fullName;

            index = fullName.LastIndexOf('_', index);
            return fullName.Substring(index + 1);
        }

        /// <summary>
        /// Splits the parameter name into a prefix and a final fragment, determined
        /// by the last uppercase letter. If the name does not split, finalFragment
        /// is null.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="prefix"></param>
        /// <param name="finalFragment"></param>
        private static void SplitName(string fullName, out string prefix, out string finalFragment)
        {
            var index = fullName.Length - 1;
            while (index > 0 && !char.IsUpper(fullName[index]))
            {
                index--;
            }

            if (index > 0)
            {
                prefix = fullName.Substring(0, index);
                finalFragment = fullName.Substring(index);
            }
            else
            {
                prefix = fullName;
                finalFragment = null;
            }
        }

        /// <summary>
        /// Records that the supplied parameter needs to be renamed, after first checking
        /// that the proposed name does not conflict with any parameters processed so far.
        /// An alias mapping to the original name is applied, regardless of whether the
        /// name was remapped automatically or via the config file, unless the config file
        /// suppresses this using AutoApplyAlias="false" .
        /// </summary>
        /// <param name="property"></param>
        /// <param name="newName"></param>
        /// <param name="processedParameters"></param>
        private void RecordParameterRename(SimplePropertyInfo property,
                                           string newName,
                                           IDictionary<string, SimplePropertyInfo> processedParameters)
        {
            if (processedParameters.ContainsKey(newName))
            {
                var msg = new StringBuilder();
                msg.AppendFormat("Operation '{0}' has a duplicate parameter name {1}: ", CurrentOperation.MethodName, property.AnalyzedName);
                msg.AppendFormat(property.Customization != null && property.Customization.Origin == Param.CustomizationOrigin.FromConfig
                                    ? "config file requested '{0}' but that name used by '{1}'."
                                    : "auto-rename yielded '{0}' but that name used by '{1}'.",
                                    newName,
                                    processedParameters[newName].AnalyzedName);

                Logger.LogError(msg.ToString());
                return;
            }

            processedParameters.Add(newName, property);

            var customization = property.Customization;
            if (customization == null)
            {
                customization = new Param
                {
                    Origin = Param.CustomizationOrigin.DuringGeneration,
                    Name = property.AnalyzedName
                };
                property.Customization = customization;
            }
            else
            {
                // if the customization came from the config but did not
                // specify an alternate name, reset it to record the name
                // was constructed automatically (generation time code
                // relies on this to determine the context member name)
                if (string.IsNullOrEmpty(customization.NewName))
                    customization.Origin = Param.CustomizationOrigin.DuringGeneration;
            }

            customization.NewName = newName;

            if (customization.AutoApplyAlias)
            {
                var aliasList = customization.Aliases;
                aliasList.Add(property.AnalyzedName);
            }
        }

        private IEnumerable<SimplePropertyInfo> GetRootSimpleProperties(Type requestType)
        {
            List<SimplePropertyInfo> simpleProperties;
            if (!_rootSimplePropertiesCache.TryGetValue(requestType, out simpleProperties))
            {
                var properties = requestType.GetProperties();
                simpleProperties = properties
                    .Select(p => CreateSimplePropertyFor(p, null))
                    .Where(sp => sp.IsReadWrite)
                    .ToList();
                _rootSimplePropertiesCache[requestType] = simpleProperties;
            }
            return simpleProperties;
        }

        private IEnumerable<SimplePropertyInfo> GetFlatProperties(Type requestType)
        {
            List<SimplePropertyInfo> flatProperties;
            if (!_flatPropertiesCache.TryGetValue(requestType, out flatProperties))
            {
                var properties = GetRootSimpleProperties(requestType);
                flatProperties = properties
                    .SelectMany(FlattenProperties)
                    .ToList();
                _flatPropertiesCache[requestType] = flatProperties;
            }
            return flatProperties;
        }

        private static IEnumerable<SimplePropertyInfo> FlattenProperties(SimplePropertyInfo property)
        {
            if (property.Children.Count > 0)
            {
                foreach (var child in property.Children)
                {
                    if (child.Children.Count == 0)
                    {
                        yield return child;
                    }
                    else
                    {
                        foreach (var flatProperty in FlattenProperties(child))
                            yield return flatProperty;
                    }
                }
            }
            else
            {
                yield return property;
            }
        }

        private string GetPropertyTypeName(string propertyName, Type type)
        {
            return IsEmitLimiter(propertyName) ? "int" : GetValidTypeName(type);
        }

        private bool IsEmitLimiter(string propertyName)
        {
            var autoIteration = AutoIterateSettings;
            if (autoIteration == null)
                return false;

            return IsEmitLimiter(propertyName, autoIteration, CurrentOperation.MethodName);
        }

        public static bool AreRequestFieldsPresent(IEnumerable<SimplePropertyInfo> requestProperties, params string[] fieldNames)
        {
            return fieldNames.All(fieldName
                        => requestProperties.FirstOrDefault(s => string.Compare(s.Name, fieldName, StringComparison.Ordinal) == 0) != null);
        }

        public static bool AreResultFieldsPresent(Type resultType, params string[] fieldNames)
        {
            // if the response type has a base class with matching prefix but ending
            // in 'Result', use that to get the real properties considered output. S3 does
            // not have this structure.
            var inspectedType = resultType;
            if (resultType.BaseType != null)
            {
                if (resultType.BaseType.Name.EndsWith("Result", StringComparison.Ordinal))
                    inspectedType = resultType.BaseType;
            }

            var props = inspectedType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            return fieldNames.All(fieldName => props.FirstOrDefault(p => string.Compare(p.Name, fieldName, StringComparison.Ordinal) == 0) != null);
        }

        private void LogAnalysisResults()
        {
            if (string.IsNullOrEmpty(AnalysisLogfile))
                return;

            using (var writer = new StreamWriter(AnalysisLogfile, true))
            {
                writer.WriteLine("{0} Method {1}", CurrentModel.ServiceNounPrefix, CurrentOperation.MethodName);
                writer.WriteLine("    Verb={0}, Noun={1}", CurrentOperation.SelectedVerb, CurrentOperation.SelectedNoun);

                if (this.AnalyzedResult.PassThruParameter != null)
                    writer.WriteLine("    PassThru support added, source = {0}", this.PassThruSource);

                if (this.SupportsShouldProcessInspectionResult != null)
                {
                    writer.WriteLine("    'SupportsShouldProcess' attribution required:");
                    string status;
                    switch (this.SupportsShouldProcessInspectionResult.Status)
                    {
                        case SupportsShouldProcessInspection.InspectionStatus.AnonymousTarget:
                            status = "no target needed";
                            break;
                        case SupportsShouldProcessInspection.InspectionStatus.TargetFromConfig:
                            status = "target set from config";
                            break;
                        case SupportsShouldProcessInspection.InspectionStatus.TargetFromAnalysis:
                            status = "target set from inspection";
                            break;
                        default:
                            status = "FAIL";
                            break;
                    }
                    writer.WriteLine("        Inspection status: {0}", status);
                    if (this.SupportsShouldProcessInspectionResult.Status == SupportsShouldProcessInspection.InspectionStatus.TargetFromConfig
                            || this.SupportsShouldProcessInspectionResult.Status == SupportsShouldProcessInspection.InspectionStatus.TargetFromAnalysis)
                        writer.WriteLine("        Target parameter: {0}", this.SupportsShouldProcessInspectionResult.TargetParameter.CmdletParameterName);
                    if (!string.IsNullOrEmpty(this.SupportsShouldProcessInspectionResult.AnalysisMessage))
                        writer.WriteLine("        Inspection message: {0}", this.SupportsShouldProcessInspectionResult.AnalysisMessage);
                }

                var paramRenamesHeaderOutput = false;

                foreach (var p in AnalyzedParameters)
                {
                    if (p.Customization == null)
                        continue;

                    if (!paramRenamesHeaderOutput)
                    {
                        paramRenamesHeaderOutput = true;
                        writer.WriteLine("    Renamed parameters:");
                    }

                    writer.WriteLine(
                        p.Customization.Origin == Param.CustomizationOrigin.FromConfig
                            ? "        Reason: config   {0} (was {1})"
                            : "        Reason: auto     {0} (was {1})", p.CmdletParameterName, p.AnalyzedName);
                }

                if (!string.IsNullOrEmpty(PromotePipelineParameterToCollection))
                    writer.WriteLine("    {0}", PromotePipelineParameterToCollection);

                writer.WriteLine();
            }
        }
    }
}
