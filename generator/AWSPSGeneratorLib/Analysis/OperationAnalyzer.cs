using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Utils;
using System.Text.RegularExpressions;
using Pluralize.NET.Core;

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
    public class OperationAnalyzer
    {
        //Parameter and alias names cannot collide with the following
        private static readonly HashSet<string> ReservedParameterNames = new HashSet<string>(new string[] {
                //From AWSRegionArguments and AWSCommonArguments
                "AK", "SK", "ST",
                "Region", "RegionToCall", "ProfileLocation", "AWSProfilesLocation", "ProfilesLocation", "AccessKey", "SecretKey", "SecretAccessKey", "SessionToken",
                "ProfileName", "StoredCredentials", "AWSProfileName", "ProfileLocation", "Credential", "NetworkCredential",
                //From AnonymousServiceCmdlet
                "EndpointUrl",
                //Common Powershell parameters
                "Force",
                //https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_commonparameters
                "Debug", "db", "ErrorAction", "ea", "ErrorVariable", "ev", "InformationAction", "infa", "InformationVariable", "iv", "OutVariable", "ov", "OutBuffer", "ob",
                "PipelineVariable", "pv", "Verbose", "vb", "WarningAction", "wa", "WarningVariable", "wv", "WhatIf", "wi", "Confirm", "cf",
                //Custom parameters added to every service cmdlet
                "Select"},
            StringComparer.OrdinalIgnoreCase);

        // Static cache to store paginator attributes per service assembly
        private static readonly Dictionary<Assembly, Dictionary<string, AutoIteration>> PaginatorAttributesCache =
            new Dictionary<Assembly, Dictionary<string, AutoIteration>>();

        #region Construction-time properties

        public ConfigModelCollection AllModels { get; set; }
        public ConfigModel CurrentModel { get; set; }
        public ServiceOperation CurrentOperation { get; set; }
        public XmlDocument AssemblyDocumentation { get; set; }

        #endregion

        #region Analysis result properties

        /// <summary>
        /// The set of properties to be emitted as cmdlet parameters. Members of complex
        /// properties are flattened to individual parameters.
        /// </summary>
        public List<SimplePropertyInfo> AnalyzedParameters { get; protected set; }

        /// <summary>
        /// The set of actual properties the cmdlet needs to deal with to populate
        /// a service request. Complex types are not flattened here.
        /// </summary>
        public List<SimplePropertyInfo> RequestProperties { get; private set; }

        /// <summary>
        /// Contains the context property names of parameters that are MemoryStream-based 
        /// in the underlying request. These parameters will instead be output as byte[]
        /// types and the requirement to load into a memory stream for the underlying
        /// sdk will be done by the cmdlet during execution.
        /// </summary>
        public HashSet<SimplePropertyInfo> StreamParameters { get; } = new HashSet<SimplePropertyInfo>();

        public HashSet<string> GetAllParameterAliases(SimplePropertyInfo property)
        {
            var aliases = new HashSet<string>();

            // global aliasing; mainly for usability
            if (CurrentModel.CustomParameters.ContainsKey(property.AnalyzedName))
            {
                var globalAliases = CurrentModel.CustomParameters[property.AnalyzedName].Aliases;
                foreach (var a in globalAliases)
                {
                    var aliasToUse = ResolveAliasWithReservedParameterName(a);

                    // If new alias is not equivalent to CmdLet parameter name that would be used, then add it to aliases list.
                    if (aliasToUse != property.CmdletParameterName)
                    {
                        aliases.Add(aliasToUse);
                    }
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
                    var aliasToUse = ResolveAliasWithReservedParameterName(a);

                    // If new alias is not equivalent to CmdLet parameter name that would be used, then add it to aliases list.
                    if (aliasToUse != property.CmdletParameterName)
                    {
                        aliases.Add(aliasToUse);
                    }
                }

                if (property.Customization.AutoApplyAlias && property.CmdletParameterName != property.AnalyzedName)
                {
                    aliases.Add(property.AnalyzedName);
                }
            }

            // apply a cross-service alias if it's an iteration parameter?
            var autoIteration = AutoIterateSettings;
            if (autoIteration != null)
            {
                var iterAlias = autoIteration.GetIterationParameterAlias(property.AnalyzedName);
                if (!string.IsNullOrEmpty(iterAlias))
                {
                    var aliasToUse = ResolveAliasWithReservedParameterName(iterAlias);

                    // If new alias is not equivalent to CmdLet parameter name that would be used, then add it to aliases list.
                    if (aliasToUse != property.CmdletParameterName)
                    {
                        aliases.Add(aliasToUse);
                    }
                }
            }

            return aliases;
        }

        /// <summary>
        /// Returns any autoiteration settings that apply, as a combination
        /// of settings defined at the global service level, overridden at the 
        /// operation level if needed or pagination attributes retrieved from .NET SDK.
        /// </summary>
        public virtual AutoIteration AutoIterateSettings
        {
            get
            {
                AutoIteration autoIteration;
                // If LegacyV4Pagination is false, try to use the .NET SDK's pagination attributes if available
                if (!CurrentOperation.LegacyV4Pagination)
                {
                    autoIteration = GetPaginatorAttributes();
                    if (!StreamParameters.Any() && IsValidAutoIteration(autoIteration))
                    {
                        return autoIteration;
                    }               
                }

                // Use the legacy approach with existing configuration
                autoIteration = AutoIteration.Combine(CurrentModel.AutoIterate, CurrentOperation.AutoIterate);

                if (IsValidAutoIteration(autoIteration))
                {
                    return ConfigureEmitLimit(autoIteration);
                }
                else
                {
                    // if legacy configuration is invalid then retrieve pagination attributes from .NET SDK if available
                    autoIteration = GetPaginatorAttributes();
                    if (!StreamParameters.Any() && IsValidAutoIteration(autoIteration))
                    {
                        // if paginators are valid then set support for legacy autoiteration mode
                        autoIteration.SupportLegacyAutoIterationMode = true;
                        return autoIteration;
                    }
                }

                return null;
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
        /// The SDK type holding the full response data from the api call.
        /// The true output will be either one or more members of this type
        /// or a nested type. The result analyzer will determine which should
        /// be used.
        /// </summary>
        public Type ResponseType { get; private set; }

        /// <summary>
        /// The output type of the method that contains the actual result data.
        /// Usually the same as ResponseType except for scenarios where the SDK
        /// generator has wrapped the true output into another type addressed
        /// by a member of ResponseType.
        /// </summary>
        public Type ReturnType { get; private set; }

        /// <summary>
        /// The results of the analysis of the output type for the cmdlet
        /// </summary>
        public AnalyzedResult AnalyzedResult { get; private set; }

        public static string FormatTypeName(Type type)
        {
            if (type.IsArray)
            {
                return $"{FormatTypeName(type.GetElementType())}[]";
            }
            else if (type.IsGenericType)
            {
                string typeName = type.FullName.Remove(type.FullName.IndexOf('`'));
                string genericArguments = string.Join(", ", type.GetGenericArguments().Select(genericArgument => FormatTypeName(genericArgument)));
                return $"{typeName}<{genericArguments}>";
            }

            return type.FullName;
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
                {
                    return CurrentOperation.ShouldProcessMsgNoun;
                }

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
                return CurrentOperation.ConfirmImpact == null ?
                    (_highImpactVerbs.Contains(CurrentOperation.SelectedVerb) ? ConfirmImpact.High : ConfirmImpact.Medium) :
                    Enum.Parse<ConfirmImpact>(CurrentOperation.ConfirmImpact);
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

        private Pluralizer Pluralizer { get; set; }

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
        private readonly Dictionary<string, string> _manualFragmentRenames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Cpus", "Cpu" },
            { "Data", null },           // pluralization turns it to 'Datum'
            { "Metadata", null },
            { "Efs", null },
            { "Information", null },
            { "Iops", null },           // pluralization yields Iop
            { "Media", null },
            { "Nfs", null },
            { "Status", null },
            { "Cookies", "Cookie" },    // pluralization service yields 'Cooky' 
            { "Lens", null }            // service incorrectly treats as plural
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
        private readonly List<string> _supportsShouldProcessParameterSuffixes = ["Id", "Name", "Arn", "Identifier"];

        /// <summary>
        /// Collection of verbs for which the cmdlet's ConfirmImpact setting should be 'high'
        /// instead of our default of 'medium'.
        /// </summary>
        private readonly HashSet<string> _highImpactVerbs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "remove"
        };

        /// <summary>
        /// The set of PowerShell approved verbs we can select from.
        /// </summary>
        private static readonly HashSet<string> ApprovedVerbs = GetApprovedVerbs();

        private readonly Dictionary<Type, List<SimplePropertyInfo>> _rootSimplePropertiesCache = new Dictionary<Type, List<SimplePropertyInfo>>();
        private readonly Dictionary<Type, List<SimplePropertyInfo>> _flatPropertiesCache = new Dictionary<Type, List<SimplePropertyInfo>>();

        #endregion

        public class UnexpectedPropertyTypeException : Exception
        {
            public UnexpectedPropertyTypeException(string message) : base(message) { }

            public UnexpectedPropertyTypeException(string message, Exception innerException) : base(message, innerException) { }
        }

        public MethodInfo Method { get; private set; }

        public OperationAnalyzer(ConfigModelCollection allModels, ConfigModel currentModel, ServiceOperation currentOperation, XmlDocument assemblyDocumentation)
        {
            // Doesn't appear to be a costly operation, so init per instance for now. Invariant
            // culture is not supported (yields exception).
            Pluralizer = new Pluralizer();

            AllModels = allModels;
            CurrentModel = currentModel;
            CurrentOperation = currentOperation;
            AssemblyDocumentation = assemblyDocumentation ?? new XmlDocument();
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

            if (methodInfo.ReturnType.BaseType != typeof(System.Threading.Tasks.Task))
            {
                throw new ArgumentException($"Method {methodInfo.Name} doesn't have Task<> as return value.");
            }

            RequestType = GetRequestType(methodInfo);
            ResponseType = methodInfo.ReturnType.GenericTypeArguments[0];

            if (string.IsNullOrEmpty(CurrentOperation.OutputWrapper))
            {
                ReturnType = ResponseType;
            }
            else
            {
                // the true return type exists as a nested member inside the
                // method response type so we must go one layer deeper to get
                // at the class containing the data to analyze for output
                var outputMember = ResponseType.GetMember(CurrentOperation.OutputWrapper).FirstOrDefault();
                if (outputMember != null && outputMember.MemberType == MemberTypes.Property)
                {
                    ReturnType = ((PropertyInfo)outputMember).PropertyType;
                }
                else
                {
                    AnalysisError.MissingOutputWrapperProperty(CurrentModel, CurrentOperation, CurrentOperation.OutputWrapper);
                    return;
                }
            }

            DetermineVerbAndNoun(generator);
            DetermineParameters(generator);
            DeterminePipelineParameter(generator);
            DetermineSupportsShouldProcessRequirement(generator);
            DetermineResult(generator);
            if (!string.IsNullOrEmpty(CurrentOperation.LegacyAlias))
            {
                generator.AddLegacyAlias($"{CurrentOperation.SelectedVerb}-{CurrentOperation.SelectedNoun}", CurrentOperation.LegacyAlias);
            }
        }

        /// <summary>
        /// Creates a simplified property for the specified request or response field.
        /// If the parameter type is a MemoryStream the parameter name is registered for replacement
        /// with a byte[] during cmdlet generation.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="parent"></param>
        /// <param name="isCmdletParameter">
        /// True if the simplified property will represent a parameter on the cmdlet.
        /// </param>
        /// <returns></returns>
        public SimplePropertyInfo CreateSimplePropertyFor(PropertyInfo property, SimplePropertyInfo parent, bool isCmdletParameter)
        {
            var shouldFlatten = true;

            string propertyTypeFullName;
            var collectionType = SimplePropertyInfo.PropertyCollectionType.NoCollection;
            Type[] genericCollectionTypes = null;

            string propertyTypeName;
            try
            {
                propertyTypeName = GetValidTypeName(property.PropertyType);
            }
            catch (UnexpectedPropertyTypeException)
            {
                return null;
            }

            // determine if property should be flattened based solely on its type, or is a generic List<T> we
            // can replace with T[] to follow PS parameter convention
            if (property.PropertyType.IsGenericType)
            {
                // if the property is a generic List, it would be more pleasant for users, and
                // more in line with PS convention, to remap it here to an array type - something
                // to consider. The change would affect the parameter but not the inner context
                // and (of course) the request object property. It would affect help though.
                // Note that some services also employ List<List<T>>, so we have to detect inner
                // case too.
                // Note services started using List<List<List<List<T>>>>.
                if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("List`"))
                {
                    genericCollectionTypes = property.PropertyType.GetGenericArguments();
                    if (genericCollectionTypes[0].Name.StartsWith("Dictionary`"))
                    {
                        genericCollectionTypes = genericCollectionTypes[0].GetGenericArguments();
                        collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericDictionary;
                    }
                    else if (genericCollectionTypes[0].Name.StartsWith("List`"))
                    {
                        if (genericCollectionTypes[0].GenericTypeArguments[0].Name.StartsWith("List`"))
                        {
                            if (genericCollectionTypes[0].GenericTypeArguments[0].GenericTypeArguments[0].Name.StartsWith("List`"))
                            {
                                if (genericCollectionTypes[0].GenericTypeArguments[0].GenericTypeArguments[0].GenericTypeArguments[0].Name.StartsWith("List`"))
                                {
                                    throw new UnexpectedPropertyTypeException($"Only four levels of List<T> are supported, detected five or more for property {property.Name}");
                                }
                                genericCollectionTypes = genericCollectionTypes[0].GenericTypeArguments[0].GenericTypeArguments[0].GetGenericArguments();
                                collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericListOfGenericList;
                            }
                            else
                            {
                                genericCollectionTypes = genericCollectionTypes[0].GenericTypeArguments[0].GetGenericArguments();
                                collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericList;
                            }
                        }
                        else
                        {
                            genericCollectionTypes = genericCollectionTypes[0].GetGenericArguments();
                            collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericList;
                        }
                    }
                    else
                    {
                        collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericList;
                    }
                }
                else if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("Dictionary`"))
                {
                    genericCollectionTypes = property.PropertyType.GetGenericArguments();
                    collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary;
                }

                propertyTypeFullName = property.PropertyType.GetGenericTypeDefinition().FullName;
            }
            else
            {
                propertyTypeFullName = property.PropertyType.FullName;
            }

            shouldFlatten = ShouldFlattenType(propertyTypeFullName);

            var simpleProperty = new SimplePropertyInfo(property,
                                                        parent,
                                                        propertyTypeName,
                                                        AssemblyDocumentation,
                                                        collectionType,
                                                        genericCollectionTypes);

            // if requiring substitution due to being a memory stream type,
            // add to the collection we'll iterate over when initializing one or
            // more memory streams during cmdlet execution
            if (isCmdletParameter && simpleProperty.IsStreamType)
            {
                StreamParameters.Add(simpleProperty);
            }

            if (shouldFlatten)
            {
                var propertyTypeProperties = property.PropertyType.GetProperties().Where(p =>
                    // skip properties that aren't read/write and index properties
                    p.CanWrite && p.CanRead && p.GetIndexParameters().Length == 0
                ).ToArray();

                if (propertyTypeProperties.Length > 0)
                {
                    foreach (var childProperty in propertyTypeProperties
                        .Select(propertyTypeProperty => CreateSimplePropertyFor(propertyTypeProperty, simpleProperty, isCmdletParameter))
                        .Where(sp => sp != null))
                    {
                        simpleProperty.Children.Add(childProperty);
                    }
                }
            }
            return simpleProperty;
        }

        /// <summary>
        /// Checks to see if the specified type has been designated as non-flattenable. By
        /// default we flatten all complex types to individual parameters during codegen.
        /// </summary>
        /// <param name="propertyTypeFullName">The full typename of the property being considered</param>
        /// <returns>True if the type can be flattened, false if we should emit a parameter of complex type.</returns>
        public bool ShouldFlattenType(string propertyTypeFullName)
        {
            return !CurrentOperation.TypesNotToFlatten.Contains(propertyTypeFullName) &&
                   !CurrentModel.TypesNotToFlatten.Contains(propertyTypeFullName) &&
                   !AllModels.TypesNotToFlatten.Contains(propertyTypeFullName);
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
            return model.ShouldExcludeParameter(analyzedName) || operation.ShouldExcludeParameter(analyzedName);
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
            {
                return operation.CustomParameters[analyzedName];
            }

            if (model.CustomParameters.ContainsKey(analyzedName))
            {
                return model.CustomParameters[analyzedName];
            }

            return null;
        }

        public string GetValidTypeName(Type type)
        {
            return GetValidTypeName(type, CurrentModel);
        }

        public static string GetValidTypeName(Type type, ConfigModel currentModel)
        {
            if (type.IsArray)
            {
                return GetValidTypeName(type.GetElementType(), currentModel) + "[]";
            }

            if (type.IsGenericType)
            {
                var genericArguments = type.GetGenericArguments();
                var genericType = type.GetGenericTypeDefinition();

                if (genericType.IsAssignableFrom(typeof(List<>)))
                {
                    return string.Format("List<{0}>", GetValidTypeName(genericArguments[0], currentModel));
                }

                if (genericType.IsAssignableFrom(typeof(IEnumerable<>)))
                {
                    return string.Format("IEnumerable<{0}>", GetValidTypeName(genericArguments[0], currentModel));
                }

                if (genericType.IsAssignableFrom(typeof(Dictionary<,>)))
                {
                    return string.Format("Dictionary<{0}, {1}>",
                                         GetValidTypeName(genericArguments[0], currentModel),
                                         GetValidTypeName(genericArguments[1], currentModel));
                }

                if (genericType.FullName.Equals("Amazon.S3.Model.Tuple`2"))
                {
                    return string.Format("Amazon.S3.Model.Tuple<{0}, {1}>",
                                         GetValidTypeName(genericArguments[0], currentModel),
                                         GetValidTypeName(genericArguments[1], currentModel));
                }

                // we'll mark the parameter later that we need to check the BoundParameters collection
                // before attempting to use
                if (genericType.IsAssignableFrom(typeof(Nullable<>)))
                {
                    return string.Format("{0}", GetValidTypeName(genericArguments[0], currentModel));
                }

                throw new UnexpectedPropertyTypeException($"Can't determine generic type. Type = [{type.FullName}], GenericType = [{genericType.FullName}]");
            }

            // always return namespace-scoped type names to avoid cross-service conflicts
            return string.Format("{0}.{1}", type.Namespace, type.Name);
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
            {
                return CurrentOperation.PipelineParameter == paramName;
            }

            return CurrentModel.PipelineParameter == paramName;
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
            if (paramName == CurrentOperation.PipelineParameter)
            {
                return 0;
            }

            // we also allow the config to override value-from-pipeline but reuse service-global positional
            // data
            for (int i = 0; i < CurrentOperation.PositionalParametersList.Length; i++)
            {
                if (paramName == CurrentOperation.PositionalParametersList[i])
                {
                    return i + 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Returns the true number of parameters for an operation, disregarding any that
        /// have been declared as part of auto-iteration support.
        /// </summary>
        public virtual IEnumerable<SimplePropertyInfo> NonIterationParameters
        {
            get
            {
                var iterationSettings = AutoIterateSettings;
                if (iterationSettings == null)
                {
                    return AnalyzedParameters;
                }

                return AnalyzedParameters.Where(p => !iterationSettings.IsIterationParameter(p.AnalyzedName));
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

            // Check for OperationNameMappings first - allows complete method name remapping
            AllModels.OperationNameMappings.TryGetValue(methodName, out var mappedMethodName);

            // Parse verb and noun using enhanced logic
            var (verb, noun, methodPrefix) = ParseVerbAndNoun(mappedMethodName ?? methodName);

            // save the noun part of the split method name so we can potentially use it for the 'operation'
            // message if the cmdlet requires confirmation
            CurrentOperation.OriginalNoun = noun;
            CurrentOperation.OriginalVerb = verb;
            // save the method prefix parsed from the method name
            CurrentOperation.ParsedMethodPrefix = methodPrefix;

            var originalVerb = verb;
            var originalNoun = noun;

            if (!string.IsNullOrEmpty(CurrentOperation.RequestedVerb))
            {
                verb = CurrentOperation.RequestedVerb;
            }
            else if (CurrentOperation.IsAutoConfiguring)
            {
                verb = AssignVerb(verb);
            }

            if (!string.IsNullOrEmpty(CurrentOperation.RequestedNoun))
            {
                if (!CheckNounIsSingular(CurrentOperation.RequestedNoun))
                {
                    AnalysisError.ConfiguredNounIsPlural(CurrentModel, CurrentOperation);
                }

                noun = CurrentOperation.RequestedNoun;
            }
            else if (CurrentOperation.IsAutoConfiguring)
            {
                noun = AssignNoun(noun);
            }

            if (verb.Length <= 2 || string.IsNullOrEmpty(noun))
            {
                AnalysisError.CannotDetermineVerbAndNoun(CurrentModel, CurrentOperation);
            }

            var nounWithPrefix = noun;
            var originalNounWithPrefix = noun;
            // prepend service prefix
            if (!string.IsNullOrEmpty(CurrentModel.ServiceNounPrefix))
            {
                nounWithPrefix = CurrentModel.ServiceNounPrefix + noun;
                originalNounWithPrefix = CurrentModel.ServiceNounPrefix + originalNoun;
            }

            if (verb != originalVerb || nounWithPrefix != originalNounWithPrefix)
            {
                AliasStore.Instance.AddAlias(string.Format("{0}-{1}", verb, nounWithPrefix),
                                             string.Format("{0}-{1}", originalVerb, originalNounWithPrefix));
            }
            if (verb != originalVerb && nounWithPrefix != originalNounWithPrefix)
            {
                AliasStore.Instance.AddAlias(string.Format("{0}-{1}", verb, nounWithPrefix),
                                             string.Format("{0}-{1}", originalVerb, nounWithPrefix));
            }

            if (!ApprovedVerbs.Contains(verb))
            {
                AnalysisError.UnapprovedVerb(CurrentModel, CurrentOperation, verb);
            }

            CurrentOperation.SelectedVerb = verb;
            CurrentOperation.SelectedNoun = nounWithPrefix;

            // Log the assigned verb and noun when AutoConfiguring
            if (CurrentOperation.IsAutoConfiguring)
            {
                Console.WriteLine($"Assigned Noun and Verb: Verb='{verb}', Noun='{nounWithPrefix}', ServiceOperation='{CurrentOperation.MethodName}', C2JFileName='{CurrentModel.C2jFilename}'");
            }

            if (CurrentOperation.RequestedVerb != verb || CurrentOperation.RequestedNoun != noun)
            {
                if (!CurrentOperation.IsAutoConfiguring)
                {
                    AnalysisError.MustUpdateVerbAndNoun(CurrentModel, CurrentOperation, verb, noun);
                }

                CurrentOperation.RequestedVerb = verb;
                CurrentOperation.RequestedNoun = noun;
            }
            return true;
        }

        /// <summary>
        /// Parses the method name to extract verb, noun, and methodPrefix by taking into account MethodPrefixModifiers.
        /// This method only performs parsing and does not apply any transformations.
        /// </summary>
        /// <param name="methodName">The method name to parse</param>
        /// <returns>A tuple containing the extracted verb, noun, and methodPrefix</returns>
        protected virtual (string verb, string noun, string methodPrefix) ParseVerbAndNoun(string methodName)
        {
            var currentMethodName = methodName;
            string methodPrefix = null;

            // Handle modifier patterns (Admin, Batch, etc.) - extract prefix but don't transform
            var modifierResult = TryParseModifierPattern(currentMethodName);
            if (modifierResult.HasValue)
            {
                methodPrefix = modifierResult.Value.prefix;
                currentMethodName = modifierResult.Value.remainingName;
            }

            // Standard verb/noun parsing
            var extractedVerb = currentMethodName;
            string extractedNoun = null;

            for (var i = 1; i < extractedVerb.Length; i++)
            {
                if (Char.IsUpper(extractedVerb[i]))
                {
                    extractedNoun = extractedVerb.Substring(i);
                    extractedVerb = extractedVerb.Substring(0, i);
                    break;
                }
            }

            // For single-word operations, return the word as verb with null noun
            // The transformation to "Invoke" will be handled in AssignVerb
            if (string.IsNullOrEmpty(extractedNoun) && string.IsNullOrEmpty(methodPrefix))
            {
                return (currentMethodName, null, null);
            }

            return (extractedVerb, extractedNoun, methodPrefix);
        }

        /// <summary>
        /// Attempts to parse modifier patterns like AdminVerbNoun or BatchVerbNoun.
        /// Returns the modifier prefix and remaining method name for further processing.
        /// Sets the AppliedMethodPrefixModifier flag when a modifier is found.
        /// </summary>
        /// <param name="methodName">The method name to parse</param>
        /// <returns>A tuple containing the modifier prefix and remaining name if a modifier pattern was found, null otherwise</returns>
        protected virtual (string prefix, string remainingName)? TryParseModifierPattern(string methodName)
        {
            foreach (var modifier in AllModels.MethodPrefixModifiers.Values)
            {
                if (methodName.StartsWith(modifier.StartsWith, StringComparison.OrdinalIgnoreCase) &&
                    methodName.Length > modifier.StartsWith.Length)
                {
                    var remainingName = methodName.Substring(modifier.StartsWith.Length);

                    // Set the flag to indicate which modifier was applied
                    CurrentOperation.AppliedMethodPrefixModifier = modifier;

                    return (modifier.StartsWith, remainingName);
                }
            }

            return null;
        }

        /// <summary>
        /// Attempts to parse verb transformation patterns using XML-driven configuration.
        /// </summary>
        /// <param name="methodName">The method name to parse</param>
        /// <returns>A tuple containing the extracted verb and noun if a transformation pattern was found, null otherwise</returns>
        protected virtual (string verb, string noun)? TryParseVerbTransformationPattern(string methodName)
        {
            foreach (var pattern in AllModels.VerbNounTransformationPatterns.Values)
            {
                if (methodName.StartsWith(pattern.Verb, StringComparison.OrdinalIgnoreCase) &&
                    methodName.Length > pattern.Verb.Length)
                {
                    var nounPart = methodName.Substring(pattern.Verb.Length);

                    if (!string.IsNullOrEmpty(nounPart))
                    {
                        // For patterns that need singularization (like Monitor/Unmonitor), singularize the noun
                        // This assumes that the noun is always singular as per the task requirements
                        var processedNoun = SingularizeNoun(nounPart);

                        // Apply the noun transformation pattern
                        var transformedNoun = pattern.TransformNoun(processedNoun);

                        return (pattern.TargetVerb, transformedNoun);
                    }
                }
            }

            return null;
        }

        // Called when auto-assigning a noun an operation. Returns the singularized noun
        // (singularizing the last portion only) or null if no change is needed.
        private string SingularizeNoun(string noun)
        {
            var nounArray = Regex.Split(noun, @"(?<!^)(?=[A-Z])");
            var nounTermination = nounArray[nounArray.Length - 1];
            // service yields some nounds as plural but they are not for cmdlet name purposes

            var singularizedNounTermination = SingularizeTerm(nounTermination);

            if (nounTermination != singularizedNounTermination)
            {
                var suggestedNoun = new StringBuilder();
                for (var i = 0; i < nounArray.Length - 1; i++)
                {
                    suggestedNoun.Append(nounArray[i]);
                }
                suggestedNoun.Append(singularizedNounTermination);
                return suggestedNoun.ToString();
            }

            return noun;
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
            AnalyzedParameters = allProperties
                .Where(prop => !IsExcludedParameter(prop.AnalyzedName, CurrentModel, CurrentOperation))
                .ToList();

            ApplyPropertyCustomization();

            FixPaginationParameters();

            FinalizeParameterNames();

            RegisterConstantClassReferences();

            ValidateParameterNamesDuplications();

            // also gather the internal root (non-flattened) properties -- these are what the
            // cmdlet will bind the parameters to in the executor
            var rootProperties = GetRootSimpleProperties(RequestType)
                                    .Where(simpleProperty => !IsExcludedParameter(simpleProperty.AnalyzedName, CurrentModel, CurrentOperation))
                                    .ToList();
            RequestProperties = new List<SimplePropertyInfo>(rootProperties);
        }

        private void ValidateParameterNamesDuplications()
        {
            var allParametersNames = AnalyzedParameters.Select(parameter => parameter.CmdletParameterName);
            var groupedParameterNames = allParametersNames.GroupBy(parameter => parameter, StringComparer.OrdinalIgnoreCase).ToArray();
            if (groupedParameterNames.Any(parameter => parameter.Count() > 1))
            {
                AnalysisError.DuplicatedParameterNames(CurrentModel, CurrentOperation,
                    groupedParameterNames.Where(parameter => parameter.Count() > 1).Select(parameter => parameter.Key));
                allParametersNames = groupedParameterNames.Select(parameter => parameter.Key).ToArray();
            }

            var allAliases = AnalyzedParameters.SelectMany(parameter => GetAllParameterAliases(parameter)).ToArray();
            var groupedAliases = allAliases.GroupBy(alias => alias, StringComparer.OrdinalIgnoreCase).ToArray();
            if (groupedAliases.Any(alias => alias.Count() > 1))
            {
                AnalysisError.DuplicatedAliasNames(CurrentModel, CurrentOperation,
                    groupedAliases.Where(parameter => parameter.Count() > 1).Select(parameter => parameter.Key));
                allAliases = groupedAliases.Select(alias => alias.Key).ToArray();
            }

            var invalidParameters = allParametersNames.Intersect(ReservedParameterNames, StringComparer.OrdinalIgnoreCase).ToArray();
            if (invalidParameters.Any())
            {
                AnalysisError.ReservedParameterNames(CurrentModel, CurrentOperation, invalidParameters);
            }

            var invalidAliases = allAliases.Intersect(ReservedParameterNames, StringComparer.OrdinalIgnoreCase).ToArray();
            if (invalidAliases.Any())
            {
                AnalysisError.ReservedAliasNames(CurrentModel, CurrentOperation, invalidAliases);
            }

            var aliasParameterConflicts = allParametersNames.Intersect(allAliases, StringComparer.OrdinalIgnoreCase).ToArray();
            if (aliasParameterConflicts.Any())
            {
                AnalysisError.AliasParameterConflicts(CurrentModel, CurrentOperation, aliasParameterConflicts);
            }
        }

        /// <summary>
        /// This fixes the properties of pagination parameters. This must be done after AnalyzedParameters
        /// is filled because the AutoIterateSettings property getter uses AnalyzedParameters.
        /// </summary>
        private void FixPaginationParameters()
        {
            var autoIterateSettings = AutoIterateSettings;

            if (autoIterateSettings != null)
            {
                if (StreamParameters.Any())
                {
                    AnalysisError.StreamParametersNotSupportedForPaginatedCmdlets(CurrentModel, CurrentOperation, StreamParameters);
                }

                foreach (var parameter in AnalyzedParameters)
                {
                    if (parameter.AnalyzedName == autoIterateSettings.EmitLimit)
                    {
                        parameter.UseParameterValueOnlyIfBound = true;
                        parameter.PropertyTypeName = "int";

                        if (autoIterateSettings.ServicePageSize != -1)
                        {
                            if ((parameter.MaxValue.HasValue && parameter.MaxValue < autoIterateSettings.ServicePageSize) ||
                                (parameter.MinValue.HasValue && parameter.MinValue > autoIterateSettings.ServicePageSize))
                            {
                                AnalysisError.InvalidServicePageSize(CurrentModel, CurrentOperation, autoIterateSettings.ServicePageSize, autoIterateSettings.EmitLimit, parameter.MinValue, parameter.MaxValue);
                            }
                        }
                        else if ((parameter.IsRequired || autoIterateSettings.PageSizeIsRequired) && !parameter.MaxValue.HasValue)
                        {
                            AnalysisError.ServicePageSizeIsRequired(CurrentModel, CurrentOperation, autoIterateSettings.EmitLimit);
                        }

                        if ((parameter.IsRequired || autoIterateSettings.PageSizeIsRequired) && parameter.DefaultValue == null)
                        {
                            parameter.DefaultValue = (autoIterateSettings.ServicePageSize != -1 ? autoIterateSettings.ServicePageSize : parameter.MaxValue ?? 99).ToString();
                        }
                    }
                }
            }
        }

        private void ApplyPropertyCustomization()
        {
            foreach (var parameter in AnalyzedParameters)
            {
                var customization = GetParameterCustomization(parameter.AnalyzedName);
                if (customization != null)
                {
                    parameter.DefaultValue = customization.DefaultValue;
                }
            }
        }

        /// <summary>
        /// If the operation has a single parameter that does not match any service-level
        /// declaration of PipelineParameter, and there is no PipelineParameter declaration
        /// on the service operation, then adopt the one and only parameter as being
        /// acceptable to be piped in.
        /// </summary>
        /// <param name="generator"></param>
        protected virtual void DeterminePipelineParameter(CmdletGenerator generator)
        {
            if (CurrentOperation.NoPipelineParameter && !string.IsNullOrEmpty(CurrentOperation.PipelineParameter))
            {
                AnalysisError.NoPipelineParameterAndPipelineParameterSpecified(CurrentModel, CurrentOperation);
            }
            if (!NonIterationParameters.Any() || CurrentOperation.NoPipelineParameter)
            {
                return;
            }

            if (!string.IsNullOrEmpty(CurrentOperation.PipelineParameter))
            {
                if (!NonIterationParameters.Any(param => param.AnalyzedName == CurrentOperation.PipelineParameter))
                {
                    AnalysisError.InvalidPipelineConfiguration(CurrentModel, CurrentOperation, CurrentOperation.PipelineParameter, NonIterationParameters);
                }
            }
            else
            {
                string pipelineParam = null;
                if (!string.IsNullOrEmpty(CurrentModel.PipelineParameter) && NonIterationParameters.Any(param => param.AnalyzedName == CurrentModel.PipelineParameter))
                {
                    pipelineParam = CurrentModel.PipelineParameter;
                }
                else
                {
                    var candidateParameters = SelectPreferredCandidateParameters(NonIterationParameters);
                    switch (candidateParameters.Count)
                    {
                        case 0:
                            // For new cmdlets with no candidate parameters, set NoPipelineParameter=true
                            CurrentOperation.NoPipelineParameter = true;
                            InfoMessage.NoPipelineParameterCandidates(CurrentModel, CurrentOperation);
                            return;
                        case 1:
                            pipelineParam = candidateParameters.First().AnalyzedName;
                            InfoMessage.SinglePipelineParameterCandidate(CurrentModel, CurrentOperation, candidateParameters.First());
                            break;
                        default:
                            // For new cmdlets with multiple candidate parameters, set NoPipelineParameter=true
                            CurrentOperation.NoPipelineParameter = true;
                            InfoMessage.MultiplePipelineParameterCandidates(CurrentModel, CurrentOperation, candidateParameters);
                            return;
                    }
                }

                if (CurrentOperation.IsAutoConfiguring)
                {
                    CurrentOperation.PipelineParameter = pipelineParam;
                }
                else
                {
                    AnalysisError.OutdatedPipelineConfiguration(CurrentModel, CurrentOperation, pipelineParam);
                }
            }
        }

        public bool RequiresShouldProcessPrompt =>
            !_supportsShouldProcessVerbSuppressions.Contains(CurrentOperation.SelectedVerb) &&
            !CurrentOperation.IgnoreSupportsShouldProcess;

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
            if (!RequiresShouldProcessPrompt ||
                CurrentOperation.AnonymousShouldProcessTarget)
            {
                if (!string.IsNullOrEmpty(CurrentOperation.ShouldProcessTarget))
                {
                    AnalysisError.ShouldProcessTargetMustBeEmpty(CurrentModel, CurrentOperation);
                }

                return;
            }

            if (!string.IsNullOrEmpty(CurrentOperation.ShouldProcessTarget))
            {
                // the config specifies the parameter(s) to use as the target then obey
                var targetParameterNames = CurrentOperation.ShouldProcessTarget.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(name => name.Trim())
                    .ToArray();

                // Validate that all specified parameters exist
                var missingParameters = new List<string>();
                foreach (var paramName in targetParameterNames)
                {
                    var target = NonIterationParameters.SingleOrDefault(parameter => parameter.AnalyzedName == paramName);
                    if (target == null)
                    {
                        missingParameters.Add(paramName);
                    }
                }

                if (missingParameters.Any())
                {
                    AnalysisError.InvalidShouldProcessTargetConfiguration(CurrentModel, CurrentOperation, NonIterationParameters);
                }
            }
            else if (!CurrentOperation.IsAutoConfiguring && AcceptsValueFromPipelineParameter != null && NonIterationParameters.Any())
            {
                // if this is an existing operation and ShouldProcessTarget is not set. Use the PipeLineParameter
                var existingPipelineParameter = NonIterationParameters
                    .SingleOrDefault(parameter => parameter.AnalyzedName == AcceptsValueFromPipelineParameter.AnalyzedName);
                CurrentOperation.ShouldProcessTarget = existingPipelineParameter?.AnalyzedName;

            }
            else if (CurrentOperation.IsAutoConfiguring)
            {
                // new operations
                DetermineSupportsShouldProcessParameter();
            }
            else if (NonIterationParameters.Any())
            {
                // if this is reached, this would be an error and the existing config was changed and is invalid.
                var suggestedParameters = SelectShouldProcessTargetCandidateParameters(NonIterationParameters, isRequiredParameter: false, isRootLevelParameter: false, excludeCollections: false);

                var targetParameterName = suggestedParameters.Count == 1
                    ? suggestedParameters.First().AnalyzedName
                    : string.Join(",", suggestedParameters.Select(p => p.AnalyzedName));
                AnalysisError.OutdatedShouldProcessTargetConfiguration(CurrentModel, CurrentOperation, targetParameterName);
            }
        }

        protected virtual void DetermineSupportsShouldProcessParameter()
        {
            // Apply enhanced parameter selection hierarchy to all parameters
            var targetParameters = SelectShouldProcessTarget();

            switch (targetParameters.Count)
            {
                case 0:
                case > 3:
                    // When no suitable target is found or too many candidates, set AnonymousShouldProcessTarget=true
                    CurrentOperation.AnonymousShouldProcessTarget = true;
                    CurrentOperation.ShouldProcessTarget = string.Empty;
                    InfoMessage.ShouldProcessTargetSetToAnonymous(CurrentModel, CurrentOperation);
                    break;

                case 1:
                    CurrentOperation.ShouldProcessTarget = targetParameters.First().AnalyzedName;
                    break;

                case >= 2 and <= 3:
                    // Multiple parameters - create comma-separated string
                    var parameterNames = string.Join(",", targetParameters.Select(param => param.AnalyzedName));
                    CurrentOperation.ShouldProcessTarget = parameterNames;
                    break;
            }
        }

        /// <summary>
        /// Selects ShouldProcessTarget using a priority-based parameter selection hierarchy.
        /// Uses a systematic approach to find the most appropriate parameter(s) for PowerShell confirmation messages.
        /// The hierarchy prioritizes exact matches first, then falls back to pattern-based matching and candidate filtering.
        /// </summary>
        /// <returns>List of selected parameters, empty list if no suitable parameters found</returns>
        protected virtual List<SimplePropertyInfo> SelectShouldProcessTarget()
        {
            // Get filtered parameter sets for different priority levels
            // Allow collections of primitive types since FormatParameterValuesForConfirmationMsg handles them well
            var allParameters = SelectShouldProcessTargetCandidateParameters(NonIterationParameters, isRequiredParameter: false, isRootLevelParameter: false, excludeCollections: false);
            var requiredParameters = SelectShouldProcessTargetCandidateParameters(NonIterationParameters, isRequiredParameter: true, isRootLevelParameter: false, excludeCollections: false);
            var requiredRootLevelParameters = requiredParameters.Where(p => p.Parent is null).ToList();

            // Early exit if no candidate parameters found
            if (allParameters.Count == 0)
            {
                InfoMessage.NoShouldProcessTargetParameters(CurrentModel, CurrentOperation, NonIterationParameters.Select(p => p.AnalyzedName));
                return [];
            }

            // Try single parameter selection first - handle the simplest cases
            var singleParameterResult = TrySelectIfSingleParameter(requiredRootLevelParameters, requiredParameters, allParameters);
            if (singleParameterResult.Any())
                return singleParameterResult;

            // Try exact noun matching - look for parameters that exactly match the method noun
            var exactNounMatchResult = TrySelectByExactNounMatch(allParameters);
            if (exactNounMatchResult.Any())
                return exactNounMatchResult;

            // Try single parameter with suffix selection
            var singleSuffixResult = TrySelectIfSingleParameter(requiredRootLevelParameters, requiredParameters, allParameters, requireSuffix: true);
            if (singleSuffixResult.Any())
                return singleSuffixResult;

            // Try noun prefix matching - parameters that start with noun and end with suffix
            var nounPrefixResult = TrySelectStartsWithNounEndsWithSuffix(requiredRootLevelParameters, requiredParameters, allParameters);
            if (nounPrefixResult.Any())
                return nounPrefixResult;

            // Handle multiple parameters with suffix - check for reasonable count for combination
            // For suffix-based filtering, exclude collections to focus on simple identifier parameters
            var suffixCandidates = GetParametersWithSuffixExcludingCollections(requiredRootLevelParameters);
            if (suffixCandidates.Count is >= 2 and <= 3)
            {
                InfoMessage.ShouldProcessTargetSelectedMultipleParameters(CurrentModel, CurrentOperation, suffixCandidates);
                return suffixCandidates;
            }

            // Fallback: Too many candidate parameters (>3)
            if (suffixCandidates.Count > 3)
            {
                InfoMessage.ShouldProcessTargetMultipleCandidatesFound(CurrentModel, CurrentOperation, suffixCandidates);
                return [];
            }

            return [];
        }

        /// <summary>
        /// Selects if there's exactly one parameter in a category.
        /// Can optionally filter by suffix for more specific matching.
        /// </summary>
        private List<SimplePropertyInfo> TrySelectIfSingleParameter(
            List<SimplePropertyInfo> requiredRootLevelParameters,
            List<SimplePropertyInfo> requiredParameters,
            List<SimplePropertyInfo> allParameters,
            bool requireSuffix = false)
        {
            var (rootLevelCandidates, requiredCandidates, allCandidates) = requireSuffix
                ? (GetParametersWithSuffix(requiredRootLevelParameters), GetParametersWithSuffix(requiredParameters), GetParametersWithSuffix(allParameters))
                : (requiredRootLevelParameters, requiredParameters, allParameters);

            // Only a single root level required parameter (with/without suffix)
            if (rootLevelCandidates.Count == 1)
            {
                var candidate = rootLevelCandidates.First();
                if (requireSuffix)
                {
                    InfoMessage.ShouldProcessTargetSelectedSuffixMatch(CurrentModel, CurrentOperation, candidate);
                }
                else
                {
                    InfoMessage.ShouldProcessTargetSelectedSingleParameter(CurrentModel, CurrentOperation, candidate);
                }
                return rootLevelCandidates;
            }

            // Only a single required parameter (with/without suffix)
            if (requiredCandidates.Count == 1)
            {
                var candidate = requiredCandidates.First();
                if (requireSuffix)
                {
                    InfoMessage.ShouldProcessTargetSelectedSuffixMatch(CurrentModel, CurrentOperation, candidate);
                }
                else
                {
                    InfoMessage.ShouldProcessTargetSelectedSingleParameter(CurrentModel, CurrentOperation, candidate);
                }
                return requiredCandidates;
            }

            // Only a single parameter (with/without suffix)
            if (allCandidates.Count == 1)
            {
                var candidate = allCandidates.First();
                if (requireSuffix)
                {
                    InfoMessage.ShouldProcessTargetSelectedSuffixMatch(CurrentModel, CurrentOperation, candidate);
                }
                else
                {
                    InfoMessage.ShouldProcessTargetSelectedSingleParameter(CurrentModel, CurrentOperation, candidate);
                }
                return allCandidates;
            }

            return [];
        }

        /// <summary>
        /// Handles Exact noun matching - find parameters that exactly match the method noun.
        /// </summary>
        private List<SimplePropertyInfo> TrySelectByExactNounMatch(List<SimplePropertyInfo> allParameters)
        {
            var methodNoun = CurrentOperation.OriginalNoun;

            if (methodNoun is null)
            {
                // OriginalNoun can be null when the OperationName is single word only
                return [];
            }
            // Look for exact match with method noun name. e.g. CreateResources method matches Resources parameter
            // AnalyzedName has the original parameter name
            var exactNounMatch = allParameters.FirstOrDefault(p =>
                string.Equals(p.AnalyzedName, methodNoun, StringComparison.OrdinalIgnoreCase));
            if (exactNounMatch != null)
            {
                InfoMessage.ShouldProcessTargetSelectedExactNounMatch(CurrentModel, CurrentOperation, exactNounMatch);
                return new List<SimplePropertyInfo> { exactNounMatch };
            }

            // Look for exact match with singularized method noun name.
            // e.g. CreateResources method matches Resource parameter
            // e.g. CreateResource method matches Resources parameter
            // CmdletParameterName has singular parameter name.

            var singularizedMethodNoun = SingularizeTerm(methodNoun);
            if (!string.Equals(methodNoun, singularizedMethodNoun, StringComparison.OrdinalIgnoreCase))
            {
                var singularizedNounMatch = allParameters.FirstOrDefault(p =>
                    string.Equals(p.CmdletParameterName, singularizedMethodNoun, StringComparison.OrdinalIgnoreCase));
                if (singularizedNounMatch != null)
                {
                    InfoMessage.ShouldProcessTargetSelectedSingularizedNounMatch(CurrentModel, CurrentOperation, singularizedNounMatch);
                    return [singularizedNounMatch];
                }
            }

            return [];
        }


        /// <summary>
        /// Noun prefix matching - returns parameters that start with noun (or singular noun) and end with suffix.
        /// </summary>
        private List<SimplePropertyInfo> TrySelectStartsWithNounEndsWithSuffix(
            List<SimplePropertyInfo> requiredRootLevelParameters,
            List<SimplePropertyInfo> requiredParameters,
            List<SimplePropertyInfo> allParameters)
        {
            var methodNoun = CurrentOperation.OriginalNoun;

            // Try root-level required parameters first
            var nounPrefixMatch = TryFindNounPrefixWithSuffix(requiredRootLevelParameters, methodNoun);
            if (nounPrefixMatch.HasValue)
            {
                InfoMessage.ShouldProcessTargetSelectedNounPrefixMatch(CurrentModel, CurrentOperation, nounPrefixMatch.Value.parameter);
                return [nounPrefixMatch.Value.parameter];
            }

            // Try required parameters
            nounPrefixMatch = TryFindNounPrefixWithSuffix(requiredParameters, methodNoun);
            if (nounPrefixMatch.HasValue)
            {
                InfoMessage.ShouldProcessTargetSelectedNounPrefixMatch(CurrentModel, CurrentOperation, nounPrefixMatch.Value.parameter);
                return [nounPrefixMatch.Value.parameter];
            }

            // Try all parameters
            nounPrefixMatch = TryFindNounPrefixWithSuffix(allParameters, methodNoun);
            if (nounPrefixMatch.HasValue)
            {
                InfoMessage.ShouldProcessTargetSelectedNounPrefixMatch(CurrentModel, CurrentOperation, nounPrefixMatch.Value.parameter);
                return [nounPrefixMatch.Value.parameter];
            }

            return [];
        }

        /// <summary>
        /// Helper method to find a parameter that starts with noun (or singular noun) and ends with suffix.
        /// </summary>
        private (SimplePropertyInfo parameter, string suffix)? TryFindNounPrefixWithSuffix(List<SimplePropertyInfo> parameters, string methodNoun)
        {
            if (string.IsNullOrEmpty(methodNoun))
                return null;

            // Try original method noun first
            foreach (var suffix in _supportsShouldProcessParameterSuffixes)
            {
                var nounPrefixMatch = parameters.FirstOrDefault(p =>
                    p.AnalyzedName.StartsWith(methodNoun, StringComparison.OrdinalIgnoreCase) &&
                    p.AnalyzedName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
                if (nounPrefixMatch != null)
                {
                    return (nounPrefixMatch, suffix);
                }
            }

            // Try singularized method noun
            var singularizedMethodNoun = SingularizeTerm(methodNoun);
            if (!string.Equals(methodNoun, singularizedMethodNoun, StringComparison.OrdinalIgnoreCase))
            {
                foreach (var suffix in _supportsShouldProcessParameterSuffixes)
                {
                    var nounPrefixSingularizedMatch = parameters.FirstOrDefault(p =>
                        p.AnalyzedName.StartsWith(singularizedMethodNoun, StringComparison.OrdinalIgnoreCase) &&
                        p.AnalyzedName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
                    if (nounPrefixSingularizedMatch != null)
                    {
                        return (nounPrefixSingularizedMatch, suffix);
                    }
                }
            }

            return null;
        }



        /// <summary>
        /// Gets parameters that end with any of the meaningful identifier suffixes.
        /// </summary>
        private List<SimplePropertyInfo> GetParametersWithSuffix(List<SimplePropertyInfo> parameters)
        {
            return _supportsShouldProcessParameterSuffixes.SelectMany(suffix =>
                parameters.Where(parameter => parameter.CmdletParameterName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }


        /// <summary>
        /// Gets parameters that end with any of the meaningful identifier suffixes, excluding collections.
        /// Used for suffix-based filtering where we want to focus on simple identifier parameters.
        /// </summary>
        private List<SimplePropertyInfo> GetParametersWithSuffixExcludingCollections(List<SimplePropertyInfo> parameters)
        {
            return _supportsShouldProcessParameterSuffixes.SelectMany(suffix =>
                parameters.Where(parameter =>
                    parameter.CmdletParameterName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) &&
                    (parameter.PropertyType == typeof(string) || !typeof(System.Collections.IEnumerable).IsAssignableFrom(parameter.PropertyType))))
                .ToList();
        }


        //If there are multiple candidates, try further restricting the list by only using required root parameters

        protected virtual List<SimplePropertyInfo> SelectPreferredCandidateParameters(IEnumerable<SimplePropertyInfo> parameters)
        {
            var autoIterateSettings = AutoIterateSettings;
            var result = parameters
                //Excluding collections
                .Where(param => param.PropertyType == typeof(string) ||
                                !typeof(System.Collections.IEnumerable).IsAssignableFrom(param.PropertyType))
                //Excluding metadata and deprecated properties
                .Where(param => !(AllModels.MetadataParameterNames.Contains(param.AnalyzedName) ||
                                 CurrentModel.MetadataPropertyNames.Contains(param.AnalyzedName) ||
                                 param.IsDeprecated ||
                                 (autoIterateSettings?.IsIterationParameter(param.AnalyzedName) ?? false)))
                .ToList();

            if (result.Count > 1)
            {
                var requiredParameters = result.Where(parameter => parameter.IsRecursivelyRequired).ToList();
                if (requiredParameters.Any())
                {
                    result = requiredParameters;
                }
            }

            if (result.Count > 1)
            {
                var rootParameters = result.Where(parameter => parameter.Parent == null).ToList();
                if (rootParameters.Any())
                {
                    result = rootParameters;
                }
            }

            return result;
        }

        /// <summary>
        /// Selects preferred candidate parameters for ShouldProcessTarget with support for primitive collections.
        /// This method allows collections of primitive types since FormatParameterValuesForConfirmationMsg handles them well.
        /// </summary>
        /// <param name="parameters">Parameters to filter</param>
        /// <param name="isRequiredParameter">Whether to prioritize required parameters</param>
        /// <param name="isRootLevelParameter">Whether to prioritize root-level parameters</param>
        /// <param name="excludeCollections">Whether to exclude collections (true for suffix-based filtering, false for general filtering)</param>
        /// <returns>Filtered list of candidate parameters</returns>
        protected virtual List<SimplePropertyInfo> SelectShouldProcessTargetCandidateParameters(IEnumerable<SimplePropertyInfo> parameters, bool isRequiredParameter = true, bool isRootLevelParameter = true, bool excludeCollections = false)
        {
            var autoIterateSettings = AutoIterateSettings;
            var result = parameters
                //Excluding collections based on excludeCollections parameter
                .Where(param =>
                {
                    if (param.PropertyType == typeof(string))
                        return true; // Always include strings

                    if (!typeof(System.Collections.IEnumerable).IsAssignableFrom(param.PropertyType))
                        return true; // Include non-collections

                    if (excludeCollections)
                        return false; // Exclude all collections when excludeCollections is true

                    // When excludeCollections is false, include collections of primitive types
                    return IsCollectionOfPrimitiveType(param.PropertyType);
                })
                //Excluding metadata and deprecated properties
                .Where(param => !(AllModels.MetadataParameterNames.Contains(param.AnalyzedName) ||
                                 CurrentModel.MetadataPropertyNames.Contains(param.AnalyzedName) ||
                                 param.IsDeprecated ||
                                 (autoIterateSettings?.IsIterationParameter(param.AnalyzedName) ?? false)))
                .ToList();

            if (result.Count > 1 && isRequiredParameter)
            {
                var requiredParameters = result.Where(parameter => parameter.IsRecursivelyRequired).ToList();
                if (requiredParameters.Any())
                {
                    result = requiredParameters;
                }
            }

            if (result.Count > 1 && isRootLevelParameter)
            {
                var rootParameters = result.Where(parameter => parameter.Parent == null).ToList();
                if (rootParameters.Any())
                {
                    result = rootParameters;
                }
            }

            return result;
        }

        /// <summary>
        /// Determines if a type is a collection of primitive types that can be formatted well by FormatParameterValuesForConfirmationMsg.
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>True if it's a collection of primitive types, false otherwise</returns>
        private bool IsCollectionOfPrimitiveType(Type type)
        {
            if (type == typeof(string))
                return false; // String is not considered a collection here

            if (!typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                return false; // Not a collection

            // Handle arrays
            if (type.IsArray)
            {
                var elementType = type.GetElementType();
                return IsPrimitiveOrFormattableType(elementType);
            }

            // Handle generic collections (List<T>, IEnumerable<T>, etc.)
            if (type.IsGenericType)
            {
                var genericArguments = type.GetGenericArguments();
                if (genericArguments.Length == 1)
                {
                    return IsPrimitiveOrFormattableType(genericArguments[0]);
                }
            }

            return false; // Unknown collection type, exclude to be safe
        }

        /// <summary>
        /// Determines if a type is primitive or has a meaningful ToString() implementation for confirmation messages.
        /// </summary>
        /// <param name="type">The type to check</param>
        /// <returns>True if the type can be formatted meaningfully, false otherwise</returns>
        private bool IsPrimitiveOrFormattableType(Type type)
        {
            // Handle nullable types
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            // Primitive types
            if (type.IsPrimitive)
                return true;

            // Common value types that format well
            if (type == typeof(string) ||
                type == typeof(decimal) ||
                type == typeof(DateTime) ||
                type == typeof(DateTimeOffset) ||
                type == typeof(TimeSpan) ||
                type == typeof(Guid))
                return true;

            // Enums format well (show enum name)
            if (type.IsEnum)
                return true;

            return false; // Complex types don't format well
        }

        /// <summary>
        /// Wraps the return type of the method.
        /// </summary>
        /// <param name="generator"></param>
        private void DetermineResult(CmdletGenerator generator)
        {
            var autoIterateSettings = AutoIterateSettings;

            var allOutputProperties = ResponseType
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes(false).Count(a => a is ObsoleteAttribute) == 0)
                .ToList();

            if (CurrentOperation.IsAutoConfiguring)
            {
                Func<PropertyInfo, bool> isNotMetadataProperty = p =>
                    !AllModels.MetadataPropertyNames.Contains(p.Name) &&
                    !CurrentModel.MetadataPropertyNames.Contains(p.Name) &&
                    autoIterateSettings?.Next != p.Name;

                var nonMetadataProperties = allOutputProperties.Where(isNotMetadataProperty).ToArray();

                if (CurrentOperation.IsAutoConfiguring)
                {
                    if (allOutputProperties.Count == 0) //We only make the cmdlet actually return void when the
                    {                                   //result has no properties at all (including metadata).
                        CurrentOperation.OutputProperty = null;
                    }
                    else if (nonMetadataProperties.Length == 1)
                    {
                        CurrentOperation.OutputProperty = nonMetadataProperties[0].Name;
                    }
                    else
                    {
                        CurrentOperation.OutputProperty = "*";
                    }
                }
            }
            else
            {
                if (CurrentOperation.OutputWrapper != null && (CurrentOperation.OutputProperty == null || (CurrentOperation.OutputProperty != CurrentOperation.OutputWrapper &&
                                                                                                           !CurrentOperation.OutputProperty.StartsWith(CurrentOperation.OutputWrapper + "."))))
                {
                    AnalysisError.OutputWrapperOutputPropertyConflict(CurrentModel, CurrentOperation);
                }
            }

            Type cmdletReturnType = null;
            SimplePropertyInfo singleResultProperty = null;
            if (allOutputProperties.Count == 0) //returns void
            {
                if (CurrentOperation.OutputProperty != null)
                {
                    AnalysisError.OutputTypeError(CurrentModel, CurrentOperation, 0);
                }
            }
            else if (CurrentOperation.OutputProperty == null)
            {
                AnalysisError.OutputTypeError(CurrentModel, CurrentOperation, allOutputProperties.Count);
            }
            else
            {
                if (CurrentOperation.OutputProperty == "*") //returns response
                {
                    cmdletReturnType = ResponseType;
                }
                else //returns a single property
                {
                    var identifiedOutputProperty = ResolveOutputProperty(ResponseType, CurrentOperation.OutputProperty);
                    if (identifiedOutputProperty == null)
                    {
                        AnalysisError.NonExistingOutputProperty(CurrentModel, CurrentOperation);
                    }
                    singleResultProperty = DetermineSingleResultProperty(identifiedOutputProperty);
                    cmdletReturnType = singleResultProperty.GenericCollectionTypes?[0] ?? singleResultProperty.PropertyType;
                }
            }

            AnalyzedResult = new AnalyzedResult(cmdletReturnType, singleResultProperty);
        }

        public PropertyInfo ResolveOutputProperty(Type type, string outputProperty)
        {
            PropertyInfo result = null;
            foreach (var property in outputProperty.Split('.'))
            {
                result = type.GetProperty(property, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                if (result == null)
                {
                    break;
                }
                type = result.PropertyType;
            }
            return result;
        }

        private SimplePropertyInfo DetermineSingleResultProperty(PropertyInfo property)
        {
            var singleResultProperty = CreateSimplePropertyFor(property, null, false);
            // if the output is a collection, extract the inner type so we report that as the cmdlet
            // output in help, not the List wrapper (grab the full name so we can be explicit in help)
            if (property.PropertyType.IsGenericType)
            {
                singleResultProperty.GenericCollectionTypes = property.PropertyType.GetGenericArguments();

                // evaluate List<T>
                if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("List`", StringComparison.Ordinal))
                {
                    var innerCollectionType = property.PropertyType.GetGenericArguments();

                    // evaluate List<List<T>>
                    if (innerCollectionType[0].Name.StartsWith("List`", StringComparison.Ordinal))
                    {
                        var additionalNested = innerCollectionType[0].GenericTypeArguments[0];

                        // evaluate List<List<List<T>>>
                        if (additionalNested.IsNested)
                        {
                            // evaluate List<List<List<List<T>>>>
                            if (additionalNested.GenericTypeArguments[0].IsNested)
                            {
                                // evaluate List<List<list<List<List<T>>>>>
                                if (additionalNested.GenericTypeArguments[0].GenericTypeArguments[0].IsNested)
                                {
                                    throw new UnexpectedPropertyTypeException($"Only four levels of List<T> are supported, detected five or more for property {property.Name}");
                                }
                                singleResultProperty.GenericCollectionTypes = new[] { additionalNested.GenericTypeArguments[0] };
                                singleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericListOfGenericList;
                            }
                            else
                            {
                                singleResultProperty.GenericCollectionTypes = new[] { additionalNested };
                                singleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericListOfGenericList;
                            }
                        }
                        else
                        {
                            singleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericList;
                        }
                    }
                    else if (innerCollectionType[0].Name.StartsWith("Dictionary`", StringComparison.Ordinal))
                    {
                        singleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericListOfGenericDictionary;
                    }
                    else
                    {
                        singleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericList;
                    }
                }
                else if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("Dictionary`", StringComparison.Ordinal))
                {
                    singleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary;
                }
            }

            return singleResultProperty;
        }

        /// <summary>
        /// Checks if a verb is already in use by other operations in the current service model.
        /// </summary>
        /// <param name="verb">The verb to check</param>
        /// <returns>True if the verb is already in use, false otherwise</returns>
        private bool IsVerbAlreadyInUse(string verb)
        {
            if (string.IsNullOrEmpty(verb))
                return false;

            foreach (var operationKvp in CurrentModel.ServiceOperations)
            {
                var operation = operationKvp.Value;

                // Skip the current operation we're processing
                if (operation == CurrentOperation)
                    continue;

                // Check if this verb is already selected/requested by another operation
                if (string.Equals(operation.SelectedVerb, verb, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(operation.RequestedVerb, verb, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        protected virtual string AssignVerb(string verb)
        {
            string newVerb = null;

            // Handle single-word operations first - transform to "Invoke"
            if (CurrentOperation.IsMethodNameNounLess)
            {
                InfoMessage.VerbAssignmentSingleWordOperation(CurrentModel, CurrentOperation, verb);
                return "Invoke";
            }

            // When verb is PowerShell-approved → use Verb-Noun
            if (ApprovedVerbs.Contains(verb))
            {
                InfoMessage.VerbAssignmentApprovedVerbUsed(CurrentModel, CurrentOperation, verb);
                return verb;
            }

            // First, check for VerbNounTransformationPatterns as per design document
            var transformedVerb = TryApplyVerbTransformationPattern(verb);
            if (!string.IsNullOrEmpty(transformedVerb))
            {
                // Return the transformed verb; noun transformation will be handled in AssignNoun
                InfoMessage.VerbAssignmentTransformationPatternApplied(CurrentModel, CurrentOperation, verb, transformedVerb);
                return transformedVerb;
            }

            // Use CurrentOperation.OriginalNoun for verb-noun uniqueness checking
            var originalNoun = CurrentOperation.OriginalNoun;

            // Use the enhanced enumerator to iterate through verb mappings in priority order
            // This now includes service-level mappings as the highest priority
            bool foundDefault = false;
            foreach (var mapping in AllModels.GetVerbMappingsInPriorityOrder(verb, CurrentModel))
            {
                // Check if this verb with original noun creates a unique combination
                if (!IsVerbNounCombinationInUse(mapping.Verb, originalNoun))
                {
                    newVerb = mapping.Verb;

                    // Log appropriate message if this is not the first (default) mapping
                    if (!foundDefault && !mapping.IsDefault)
                    {
                        // This is an alternative verb due to conflict with default
                        InfoMessage.VerbAssignmentAlternativePriorityVerbSelected(CurrentModel, CurrentOperation, verb, mapping.Verb, originalNoun);
                    }

                    break; // Found an available verb, exit the loop
                }

                // This verb-noun combination is already in use
                if (mapping.IsDefault)
                {
                    // The default priority verb conflicts, log this for visibility
                    InfoMessage.VerbAssignmentPriorityVerbConflictDetected(CurrentModel, CurrentOperation, mapping.Verb, originalNoun);
                    foundDefault = true;
                }
            }

            // If no suitable verb was found from mappings, generate an error
            if (string.IsNullOrEmpty(newVerb))
            {
                var allMappings = AllModels.GetAllVerbMappings(verb);
                if (allMappings.Any())
                {
                    var availableVerbs = allMappings.Select(m => m.Verb);
                    AnalysisError.NoPriorityVerbAvailable(CurrentModel, CurrentOperation, verb, availableVerbs);
                }
            }

            return newVerb ?? verb;
        }


        /// <summary>
        /// Checks if a verb-noun combination is already in use by other operations in the current service model.
        /// Since this is within the same service, ServiceNounPrefix is the same for all operations,
        /// so we need to check SelectedVerb, OriginalNoun, and ParsedMethodPrefix.
        /// </summary>
        /// <param name="verb">The verb to check</param>
        /// <param name="noun">The noun to check (without service prefix)</param>
        /// <returns>True if the verb-noun combination is already in use, false otherwise</returns>
        protected virtual bool IsVerbNounCombinationInUse(string verb, string noun)
        {
            if (string.IsNullOrEmpty(verb) || string.IsNullOrEmpty(noun))
                return false;
            var singularNoun = SingularizeNoun(noun);
            // In the AssignNoun, since the Noun transformations have not been applied, this is not perfect
            // the worst case is that there will be ERROR written in the buildconfig that same verb/noun is in use.
            if (ShouldApplyPluralNounRule(verb, noun, singularNoun))
            {
                return false;
            }

            foreach (var operationKvp in CurrentModel.ServiceOperations)
            {
                var operation = operationKvp.Value;

                // Skip the current operation we're processing
                if (operation == CurrentOperation)
                    continue;

                // Check if this verb-noun combination is already in use by another operation
                // Also check that the ParsedMethodPrefix matches for a true collision
                if (string.Equals(operation.SelectedVerb, verb, StringComparison.OrdinalIgnoreCase) &&
                    (string.Equals(operation.OriginalNoun, noun, StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(operation.OriginalNoun, singularNoun, StringComparison.OrdinalIgnoreCase)
                    ) &&
                    string.Equals(operation.ParsedMethodPrefix, CurrentOperation.ParsedMethodPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckNounIsSingular(string noun)
        {
            const string listSuffix = "List";

            if (noun.EndsWith(listSuffix) && noun.Length > listSuffix.Length)
            {
                noun = noun.Substring(0, noun.Length - listSuffix.Length);
            }

            return SingularizeNoun(noun) == noun;
        }

        /// <summary>
        /// Attempts to apply verb transformation patterns from the XML configuration.
        /// This method only assigns the verb and sets a flag indicating which pattern was matched.
        /// The actual noun transformation is handled later by AssignNoun.
        /// </summary>
        /// <param name="verb">The verb to check for transformation patterns</param>
        /// <returns>The target verb if a pattern matches, null otherwise</returns>
        protected virtual string TryApplyVerbTransformationPattern(string verb)
        {
            if (!AllModels.VerbNounTransformationPatterns.TryGetValue(verb, out var pattern)) return null;

            // Set the flag to indicate which transformation pattern was matched
            CurrentOperation.AppliedVerbNounTransformationPattern = pattern;

            // Return only the target verb
            return pattern.TargetVerb;

        }

        /// <summary>
        /// Transforms a noun using the applied MethodPrefixModifier's NounTransformation pattern.
        /// This method applies the transformation when method names start with certain prefixes (e.g., "Admin", "Batch").
        /// The transformation pattern is stored in CurrentOperation.AppliedMethodPrefixModifier.
        /// </summary>
        /// <param name="noun">The original noun to transform</param>
        /// <returns>The transformed noun, or the original noun if no modifier is applied</returns>
        protected virtual string TransformNounForMethodPrefix(string noun)
        {
            // Apply the noun transformation pattern from the applied modifier
            return CurrentOperation.AppliedMethodPrefixModifier.TransformNoun(noun);
        }

        protected virtual string AssignNoun(string noun)
        {
            string singularNoun = null;
            if (noun != null)
            {
                singularNoun = SingularizeNoun(noun);
            }

            // Create transformation context with original and singular nouns
            var context = new NounTransformationContext(noun, singularNoun);

            // Execute transformation pipeline
            var pipeline = new NounTransformationPipeline()
                .AddTransformation(ApplyBaseNounTransformation)
                .AddTransformation(ApplyPluralNounConflictResolution)
                .AddTransformation(ApplyMethodPrefixTransformation);

            return pipeline.Execute(context);
        }

        /// <summary>
        /// Context object that carries transformation state through the pipeline
        /// </summary>
        private class NounTransformationContext
        {
            public string OriginalNoun { get; }
            public string SingularNoun { get; }
            public string CurrentNoun { get; set; }

            public NounTransformationContext(string originalNoun, string singularNoun)
            {
                OriginalNoun = originalNoun;
                SingularNoun = singularNoun;
                CurrentNoun = singularNoun; // Start with singular noun as default
            }
        }

        /// <summary>
        /// Simple pipeline for noun transformations
        /// </summary>
        private class NounTransformationPipeline
        {
            private readonly List<Func<NounTransformationContext, string>> _transformations = new List<Func<NounTransformationContext, string>>();

            public NounTransformationPipeline AddTransformation(Func<NounTransformationContext, string> transformation)
            {
                _transformations.Add(transformation);
                return this;
            }

            public string Execute(NounTransformationContext context)
            {
                foreach (var transformation in _transformations)
                {
                    context.CurrentNoun = transformation(context);
                }
                return context.CurrentNoun;
            }
        }

        /// <summary>
        /// Applies the base noun transformation. Only one of these transformations will be applied,
        /// following a priority order: single-word operations, mappings, or transformation patterns.
        /// These transformations determine the fundamental noun form.
        /// </summary>
        private string ApplyBaseNounTransformation(NounTransformationContext context)
        {
            // Handle single-word operations first (highest priority). 
            if (CurrentOperation.IsMethodNameNounLess)
            {
                InfoMessage.NounAssignmentSingleWordOperation(CurrentModel, CurrentOperation, CurrentOperation.MethodName);
                return CurrentOperation.MethodName;
            }

            // Apply verb-noun transformation patterns
            if (CurrentOperation.AppliedVerbNounTransformationPattern != null)
            {
                var pattern = CurrentOperation.AppliedVerbNounTransformationPattern;
                var patternTransformedNoun = pattern.TransformNoun(context.SingularNoun);
                InfoMessage.NounAssignmentTransformationPatternApplied(CurrentModel, CurrentOperation, context.OriginalNoun, patternTransformedNoun, pattern.Verb);
                return patternTransformedNoun;
            }

            // Service Level and Global mappings are older mappings.
            if (CurrentModel.NounMappings.TryGetValue(context.OriginalNoun, out var serviceLevelMapping))
            {
                InfoMessage.NounAssignmentMappingApplied(CurrentModel, CurrentOperation, context.OriginalNoun, serviceLevelMapping, "Service-level");
                return serviceLevelMapping;
            }

            // Check global noun mappings (third priority)
            if (AllModels.NounMappings.TryGetValue(context.OriginalNoun, out var globalMapping))
            {
                InfoMessage.NounAssignmentMappingApplied(CurrentModel, CurrentOperation, context.OriginalNoun, globalMapping, "Global");
                return globalMapping;
            }

            // Default: return singularized noun if no other transformation applies
            return context.SingularNoun;
        }

        /// <summary>
        /// Applies plural noun conflict resolution rules when there are naming conflicts
        /// between singular and plural forms of the same noun with the same verb.
        /// </summary>
        private string ApplyPluralNounConflictResolution(NounTransformationContext context)
        {
            if (context.OriginalNoun is null)
            {
                return context.CurrentNoun;
            }

            // Apply plural noun rules if needed (for conflict detection)
            if (ShouldApplyPluralNounRule(CurrentOperation.OriginalVerb, context.OriginalNoun, context.SingularNoun))
            {
                var suffix = AllModels.PluralNounRules.DefaultSuffix;
                var conflictResolvedNoun = context.SingularNoun + suffix;
                InfoMessage.NounAssignmentPluralNounRuleApplied(CurrentModel, CurrentOperation, context.OriginalNoun, conflictResolvedNoun, CurrentOperation.OriginalVerb);
                return conflictResolvedNoun;
            }

            return context.CurrentNoun;
        }

        /// <summary>
        /// Applies method prefix transformation for operations that have special prefixes
        /// like "Admin", "Batch", etc.
        /// </summary>
        private string ApplyMethodPrefixTransformation(NounTransformationContext context)
        {
            if (context.OriginalNoun is null)
            {
                return context.CurrentNoun;
            }
            // Apply method prefix transformation if applicable
            if (CurrentOperation.AppliedMethodPrefixModifier is not null)
            {
                var prefixTransformedNoun = TransformNounForMethodPrefix(context.CurrentNoun);
                InfoMessage.NounAssignmentMethodPrefixTransformationApplied(CurrentModel, CurrentOperation, context.CurrentNoun, prefixTransformedNoun, CurrentOperation.AppliedMethodPrefixModifier.StartsWith);
                return prefixTransformedNoun;
            }

            return context.CurrentNoun;
        }

        /// <summary>
        /// Determines whether to apply plural noun rules (Collection suffix) based on conflict detection.
        /// Returns true when there are method names that have the same verb but with singular and plural nouns.
        /// e.g. DescribeStack and DescribeStacks
        /// </summary>
        /// <param name="verb">The selected verb for the current operation</param>
        /// <param name="originalNoun">The original plural noun</param>
        /// <param name="singularNoun">The singularized version of the noun</param>
        /// <returns>True if Collection suffix should be applied, false otherwise</returns>
        protected virtual bool ShouldApplyPluralNounRule(string verb, string originalNoun, string singularNoun)
        {
            if (singularNoun == originalNoun)
            {
                // Noun is singular
                return false;
            }

            // Check if the verb has a plural noun rule configured
            if (!AllModels.PluralNounRules.HasPluralNounRule(verb))
            {
                return false;
            }

            // Check if there are method names with the same verb but different noun forms (singular/plural)
            foreach (var operationKvp in CurrentModel.ServiceOperations)
            {
                var operation = operationKvp.Value;

                // Skip the current operation we're processing
                if (operation == CurrentOperation)
                    continue;

                // Check if this operation has the same verb
                if (!string.Equals(operation.OriginalVerb, verb, StringComparison.OrdinalIgnoreCase))
                    continue;

                var operationNoun = operation.OriginalNoun;
                if (string.IsNullOrEmpty(operationNoun))
                    continue;

                // Check if this operation uses the singular form of our noun
                if (string.Equals(operationNoun, singularNoun, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // Found same verb with singular noun
                }

                // Check if the singularized version of this operation's noun matches our singular noun
                var otherSingularized = SingularizeNoun(operationNoun);
                if (string.Equals(otherSingularized, singularNoun, StringComparison.OrdinalIgnoreCase) &&
                    otherSingularized != operationNoun)
                {
                    return true; // Found same verb with different plural form of the same noun
                }
            }

            return false;
        }

        /// <summary>
        /// Evaluate the analyzed parameters to find the one (if any) that matches the
        /// PipelineParameter declared for the operation or globally at the
        /// service config level. Null is returned if the cmdlet has no parameter that
        /// can be piped into.
        /// </summary>
        public SimplePropertyInfo AcceptsValueFromPipelineParameter
        {
            get
            {
                if (!string.IsNullOrEmpty(CurrentOperation.PipelineParameter))
                {
                    return AnalyzedParameters.FirstOrDefault(parameter => parameter.AnalyzedName == CurrentOperation.PipelineParameter);
                }

                return null;
            }
        }

        private Type GetRequestType(MethodInfo method)
        {
            var requestParameters = method.GetParameters();
            if (requestParameters.Length == 0)
            {
                return null;
            }
            if (requestParameters.Length != 2)
            {
                return null;
            }
            var requestType = requestParameters[0].ParameterType;
            if (requestType.IsInterface)
            {
                return null;
            }
            return requestType;
        }

        private static HashSet<string> GetApprovedVerbs()
        {
            var allVerbs = new HashSet<string>();
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

            // remove "Resize" and "Optimize", as these are 6.0 verbs and we are still supporting 5.1
            allVerbs.Remove("Build");
            allVerbs.Remove("Deploy");

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
            // possible scenarios:
            //   param Name="foo" Alias="baz"                      => add alias, also auto-rename
            //   param Name="foo" Exclude="true"                   => do not emit parameter
            //   param Name="foo" NewName="bar"                    => rename param, no alias
            //   param Name="foo" NewName="bar" Alias="baz"        => rename param with alias
            //   param Name="foo" AutoRename="false"               => do not rename param
            //   param Name="foo" AutoRename="false" Alias="baz"   => do not rename but add alias

            // To reduce parameter conflicts and reduce manual configuration, parameter shortening is being disabled.
            bool enableParameterShortening = false;

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
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(parameterCustomization.NewName))
                    {
                        RecordParameterRename(property, parameterCustomization.NewName);
                        attemptAutoRename = false;
                    }
                    else
                    {
                        attemptAutoRename = parameterCustomization.AutoRename;
                    }
                }

                // In auto-rename, we attempt to shorten the name. In case there is a new service where there are similar end properties
                // under different paths (e.g. EmailSettings_EmailMessage for Amplify Backend), then this could generate duplicate parameters.
                if (attemptAutoRename)
                {
                    // inspect the name to determine if it can be reduced in length if we flattened a deep
                    // property hierarchy
                    var alternateName = property.AnalyzedName;
                    var underscores = property.AnalyzedName.Count(c => c == '_');
                    if (underscores > 1 && enableParameterShortening)
                    {
                        alternateName = RebaseNameToFinalParent(alternateName);
                    }

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
                        RecordParameterRename(property, alternateName);
                    }
                }

                // Attempt to automatically resolve reserved parameter name conflicts. We should attempt auto rename if resolution was not done.
                if (ResolveReservedParameterName(property))
                {
                    CurrentOperation.IsReservedParameterNameHandled = true;
                    InfoMessage.ReservedParameterNameConflictResolved(CurrentModel, CurrentOperation, property);

                    // For new operations, the CurrentOperation.CustomParameters would not contain the resolved reserved parameter name. During report serialization, we should emit new parameter customization.
                }
            }
        }

        /// <summary>
        /// Automatically resolves reserved parameter name conflict.
        /// </summary>
        /// <param name="property">Property representing parameter.</param>
        /// <returns>Flag indicating if resolution was done.</returns>
        private bool ResolveReservedParameterName(SimplePropertyInfo property)
        {
            string parameterNameToResolve = property.Customization?.NewName ?? property.AnalyzedName;

            // Parameter Name conflicts with one of the reserved parameter names. We want to use reserved parameter name from existing list for proper casing.
            string reservedParameterName = ReservedParameterNames.FirstOrDefault(r => r.Equals(parameterNameToResolve, StringComparison.OrdinalIgnoreCase));
            if (reservedParameterName != null)
            {
                // We want to use reserved parameter name from existing list for proper casing.
                if (AllModels.ReservedParameterNameMappings.TryGetValue(reservedParameterName, out var newResolvedName))
                {
                    newResolvedName = newResolvedName.Replace("{Noun}", CurrentOperation.SelectedNoun).Replace("{Verb}", CurrentOperation.SelectedVerb);

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

                    property.Customization.NewName = newResolvedName;

                    // We should not auto apply alias since it would apply an alias of the original name which we have already transformed.
                    property.Customization.AutoApplyAlias = false;

                    // We should override this even if there was NewName specified in customization.
                    property.Customization.Origin = Param.CustomizationOrigin.DuringGeneration;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Automatically resolves alias reserved parameter name conflict.
        /// </summary>
        /// <param name="alias">Parameter alias.</param>
        /// <returns>Resolved alias.</returns>
        private string ResolveAliasWithReservedParameterName(string alias)
        {
            string newAlias = alias;

            if (!string.IsNullOrEmpty(alias))
            {
                // Alias conflicts with one of the reserved parameter names. We want to use reserved parameter name from existing list for proper casing.
                string reservedParameterName = ReservedParameterNames.FirstOrDefault(r => r.Equals(alias, StringComparison.OrdinalIgnoreCase));
                if (reservedParameterName != null)
                {
                    // We want to use reserved parameter name from existing list for proper casing.
                    if (AllModels.ReservedParameterNameMappings.TryGetValue(reservedParameterName, out var newResolvedName))
                    {
                        newAlias = newResolvedName.Replace("{Noun}", CurrentOperation.SelectedNoun).Replace("{Verb}", CurrentOperation.SelectedVerb);
                    }
                }
            }

            return newAlias;
        }

        /// <summary>
        /// Register fields derived from the SDK's ConstantClass 'enum' type
        /// used to emit an argument completer unless the field is a member of the result type.
        /// </summary>
        private void RegisterConstantClassReferences()
        {
            foreach (var property in AnalyzedParameters)
            {
                if (!property.IsConstrainedToSet) continue;

                if (!CurrentModel.ArgumentCompleters.IsConstantClassRegistered(property.PropertyTypeName))
                {
                    var setMembers = SimplePropertyInfo.GetConstantClassMembers(property.PropertyType);
                    CurrentModel.ArgumentCompleters.AddConstantClass(property.PropertyTypeName, setMembers);
                }

                CurrentModel.ArgumentCompleters.AddConstantClassReference(property.PropertyTypeName,
                    property.CmdletParameterName,
                    string.Format("{0}-{1}",
                        CurrentOperation.SelectedVerb,
                        CurrentOperation.SelectedNoun));
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

                return Pluralizer.Singularize(term) ?? term;
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
            {
                return fullName;
            }

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
        private void RecordParameterRename(SimplePropertyInfo property, string newName)
        {
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
                {
                    customization.Origin = Param.CustomizationOrigin.DuringGeneration;
                }
            }

            customization.NewName = newName;
        }

        private IEnumerable<SimplePropertyInfo> GetRootSimpleProperties(Type requestType)
        {
            List<SimplePropertyInfo> simpleProperties;
            if (!_rootSimplePropertiesCache.TryGetValue(requestType, out simpleProperties))
            {
                var properties = requestType.GetProperties();
                simpleProperties = properties
                    .Select(p => CreateSimplePropertyFor(p, null, true))
                    .Where(sp => sp != null && sp.IsReadWrite)
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
                        {
                            yield return flatProperty;
                        }
                    }
                }
            }
            else
            {
                yield return property;
            }
        }

        public static bool AreRequestFieldsPresent(IEnumerable<SimplePropertyInfo> requestProperties, params string[] fieldNames)
        {
            return fieldNames.All(fieldName
                        => requestProperties.FirstOrDefault(s => s.Name == fieldName) != null);
        }

        public static bool AreResultFieldsPresent(Type resultType, params string[] fieldNames)
        {
            // if the response type has a base class with matching prefix but ending
            // in 'Result', use that to get the real properties considered output. S3 does
            // not have this structure.
            var inspectedType = resultType;
            if (resultType.BaseType != null)
            {
                if (resultType.BaseType.Name.EndsWith("Result"))
                {
                    inspectedType = resultType.BaseType;
                }
            }

            var props = inspectedType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            return fieldNames.Intersect(props.Select(p => p.Name)).Count() == fieldNames.Count();
        }

        /// <summary>
        /// Gets pagination attributes from the .NET SDK Paginators attribute with caching.
        /// </summary>
        /// <returns>AutoIteration settings based on SDK pagination attributes</returns>
        private AutoIteration GetPaginatorAttributes()
        {
            try
            {
                // Check if paginator attributes are already cached for this assembly
                if (!PaginatorAttributesCache.TryGetValue(CurrentModel.Assembly, out var serviceCache))
                {
                    // If not, load and cache all paginator attributes for this service
                    serviceCache = LoadPaginatorAttributes();
                    PaginatorAttributesCache[CurrentModel.Assembly] = serviceCache;
                }

                // Look for the current operation in the cache
                if (serviceCache.TryGetValue(CurrentOperation.MethodName, out var autoIteration))
                {
                    return autoIteration;
                }
            }
            catch (Exception e)
            {
                // Add error to the analysis errors collection
                AnalysisError.ExceptionWhileGettingPaginatorAttributes(CurrentModel, CurrentOperation, e);
            }

            return null;
        }

        /// <summary>
        /// Loads all paginator attributes for the current service assembly.
        /// </summary>
        /// <returns>Dictionary mapping operation names to their paginator attributes</returns>
        private Dictionary<string, AutoIteration> LoadPaginatorAttributes()
        {
            var paginatorAttributes = new Dictionary<string, AutoIteration>(StringComparer.OrdinalIgnoreCase);

            try
            {
                // Format the paginator factory interface type name
                var pageFactoryInterfaceTypeName = string.Format("{0}.Model.I{1}PaginatorFactory",
                    CurrentModel.ServiceNamespace, CurrentModel.AssemblyName);

                // Get the paginator factory interface type
                var pageFactoryInterfaceType = CurrentModel.Assembly.GetType(pageFactoryInterfaceTypeName);

                if (pageFactoryInterfaceType != null)
                {
                    // Get all methods of the paginator factory interface
                    var pageFactoryInterfaceMethods = pageFactoryInterfaceType.GetMethods()
                        .OrderBy(m => m.Name).ToList();

                    // Process each method in the interface
                    foreach (var pageFactoryMethod in pageFactoryInterfaceMethods)
                    {
                        // Find the paginator attribute
                        dynamic awsPaginatorFactoryAttribute = pageFactoryMethod
                            .GetCustomAttributes()
                            .SingleOrDefault(attribute =>
                                attribute.GetType().FullName == "Amazon.Runtime.Internal.AWSPaginatorAttribute");

                        if (awsPaginatorFactoryAttribute != null)
                        {
                            string methodName = pageFactoryMethod.Name;

                            var autoIteration = new AutoIteration
                            {
                                Start = awsPaginatorFactoryAttribute.InputToken[0],
                                Next = awsPaginatorFactoryAttribute.OutputToken[0],
                                EmitLimit = awsPaginatorFactoryAttribute.LimitKey
                            };

                            // Add to cache
                            paginatorAttributes[methodName] = autoIteration;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Add error to the analysis errors collection
                AnalysisError.ExceptionWhileLoadingPaginatorAttributes(CurrentModel, e);
            }

            return paginatorAttributes;
        }

        /// <summary>
        /// Check if AutoIteration is valid by checking the request and response fields.
        /// </summary>
        private bool IsValidAutoIteration(AutoIteration iteration)
        {
            return iteration != null &&
                   !string.IsNullOrEmpty(iteration.Start) &&
                   !string.IsNullOrEmpty(iteration.Next) &&
                   AnalyzedParameters.Select(s => s.Name).Contains(iteration.Start) &&
                   AreResultFieldsPresent(ReturnType, iteration.Next);
        }

        private AutoIteration ConfigureEmitLimit(AutoIteration iteration)
        {
            if (string.IsNullOrEmpty(iteration.EmitLimit) ||
                CurrentOperation.LegacyPagination != ServiceOperation.LegacyPaginationType.UseEmitLimit ||
                !AnalyzedParameters.Select(s => s.Name).Contains(iteration.EmitLimit))
            {
                iteration.EmitLimit = null;
            }
            return iteration;
        }
    }
}
