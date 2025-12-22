using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.Analysis;
using System.ComponentModel;
using AWSPowerShellGenerator.Generators;
using System.Management.Automation;

namespace AWSPowerShellGenerator.ServiceConfig
{
    /// <summary>
    /// Collection of service ConfigModel objects
    /// </summary>
    public class ConfigModelCollection
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("VerbMappings")]
        public List<ServiceOperationVerb> VerbMappingsList = new List<ServiceOperationVerb>();

        Dictionary<string, List<VerbMapping>> _verbMappings;
        /// <summary>
        /// Unified verb mappings with priority-based conflict resolution using historical usage data
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, List<VerbMapping>> VerbMappings
        {
            get
            {
                if (_verbMappings == null)
                {
                    _verbMappings = new Dictionary<string, List<VerbMapping>>(StringComparer.OrdinalIgnoreCase);
                    
                    foreach (var serviceVerb in VerbMappingsList)
                    {
                        var mappings = new List<VerbMapping>();
                        
                        // Add mappings with Default="true" first (highest priority), then by weight
                        var defaultMappings = serviceVerb.Mappings.Where(m => m.Default).OrderByDescending(m => m.Weight);
                        var nonDefaultMappings = serviceVerb.Mappings.Where(m => !m.Default).OrderByDescending(m => m.Weight);
                        
                        foreach (var mapping in defaultMappings.Concat(nonDefaultMappings))
                        {
                            // Skip duplicates
                            if (!mappings.Any(m => string.Equals(m.Verb, mapping.Verb, StringComparison.OrdinalIgnoreCase)))
                            {
                                mappings.Add(new VerbMapping { Verb = mapping.Verb, Weight = mapping.Weight, IsDefault = mapping.Default });
                            }
                        }
                        
                        if (mappings.Any())
                        {
                            _verbMappings[serviceVerb.Name] = mappings;
                        }
                    }
                }
                return _verbMappings;
            }
        }

        /// <summary>
        /// Gets the highest priority verb for the given service operation verb.
        /// Returns the default verb if available, otherwise the verb with the highest usage count.
        /// </summary>
        /// <param name="serviceOperationVerb">The original service operation verb</param>
        /// <returns>The highest priority verb, or null if no mapping found</returns>
        public string GetPriorityVerb(string serviceOperationVerb)
        {
            if (string.IsNullOrEmpty(serviceOperationVerb))
                return null;

            if (VerbMappings.TryGetValue(serviceOperationVerb, out var mappings) && mappings.Any())
            {
                return mappings.First().Verb; // Already sorted by priority
            }

            return null;
        }

        /// <summary>
        /// Gets all available verb mappings for a service operation verb, ordered by priority.
        /// Used for conflict resolution when the preferred verb is already in use.
        /// </summary>
        /// <param name="serviceOperationVerb">The service operation verb to get mappings for</param>
        /// <returns>List of verb mappings ordered by priority (default first, then by usage count)</returns>
        public List<VerbMapping> GetAllVerbMappings(string serviceOperationVerb)
        {
            if (string.IsNullOrEmpty(serviceOperationVerb))
                return new List<VerbMapping>();

            if (VerbMappings.TryGetValue(serviceOperationVerb, out var mappings))
                return new List<VerbMapping>(mappings); // Return copy to prevent modification

            return new List<VerbMapping>();
        }

        /// <summary>
        /// Gets verb mappings in priority order as an enumerator.
        /// First checks service-level explicit mappings, then yields priority-based mappings.
        /// This provides a clean way to iterate through verb options for conflict resolution.
        /// </summary>
        /// <param name="serviceOperationVerb">The service operation verb to get mappings for</param>
        /// <param name="currentModel">The current service model to check for service-level mappings</param>
        /// <returns>Enumerator that yields verb mappings in priority order</returns>
        public IEnumerable<VerbMapping> GetVerbMappingsInPriorityOrder(string serviceOperationVerb, ConfigModel currentModel = null)
        {
            // First priority: Check explicit service-level mappings
            if (currentModel?.VerbMappings.ContainsKey(serviceOperationVerb) == true)
            {
                yield return new VerbMapping 
                { 
                    Verb = currentModel.VerbMappings[serviceOperationVerb], 
                    Weight = int.MaxValue, // Highest priority
                    IsDefault = true 
                };
            }

            // Second priority: Check global priority-based mappings
            if (VerbMappings.TryGetValue(serviceOperationVerb, out var mappings))
            {
                foreach (var mapping in mappings)
                {
                    // Skip if we already yielded this verb from service-level mappings
                    if (currentModel?.VerbMappings.ContainsKey(serviceOperationVerb) == true &&
                        string.Equals(mapping.Verb, currentModel.VerbMappings[serviceOperationVerb], StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    yield return mapping;
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("OperationNameMappings")]
        public List<Map> OperationNameMappingsList = new List<Map>();

        Dictionary<string, string> _operationNameMappings;
        /// <summary>
        /// Cross-service operation name remaps
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> OperationNameMappings
        {
            get
            {
                if (_operationNameMappings == null)
                    _operationNameMappings = OperationNameMappingsList.ToDictionary(m => m.From, m => m.To);

                return _operationNameMappings;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("ReservedParameterNameMappings")]
        public List<Map> ReservedParameterNameMappingsList = new List<Map>();

        Dictionary<string, string> _reservedParameterNameMappings;
        /// <summary>
        /// Reserved parameter name remaps
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> ReservedParameterNameMappings
        {
            get
            {
                if (_reservedParameterNameMappings == null)
                    _reservedParameterNameMappings = ReservedParameterNameMappingsList.ToDictionary(m => m.From, m => m.To);

                return _reservedParameterNameMappings;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("NounMappings")]
        public List<Map> NounMappingsList = new List<Map>();

        Dictionary<string, string> _nounMappings;
        /// <summary>
        /// Cross-service noun remaps
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> NounMappings
        {
            get
            {
                if (_nounMappings == null)
                    _nounMappings = NounMappingsList.ToDictionary(m => m.From, m => m.To);

                return _nounMappings;
            }
        }

        /// <summary>
        /// Global list of member types that we should not attempt to flatten to 'typename_membername' during
        /// codegen. The global list should really be restricted to just types external to AWS services - 
        /// non-flatting types at the service level can be declared in the service config files, and are fused
        /// with this collection automatically.
        /// </summary>
        [XmlArray("TypesNotToFlatten")]
        [XmlArrayItem("Type")]
        public List<string> TypesNotToFlatten { get; set; } = new List<string>();

        /// <summary>
        /// List of cmdlet output properties that are considered metadata, this is used to fill in the
        /// list of metadata properties for an operation during its first automated configuration.
        /// We include common pagination properties here in order to have them show up for in the configuration
        /// and help identifying cmdlets with misconfigured pagination
        /// </summary>
        [XmlArray("MetadataProperties")]
        [XmlArrayItem("Property")]
        public List<string> MetadataPropertyNames { get; set; }

        /// <summary>
        /// List of cmdlet parameters that are considered metadata and moved to the end of the parameters list
        /// </summary>
        [XmlArray("MetadataParameters")]
        [XmlArrayItem("Parameter")]
        public List<string> MetadataParameterNames { get; set; }

    /// <summary>
    /// Collection of xml config files that the generator should operate on
    /// </summary>
    [XmlArray]
    [XmlArrayItem("Path")]
    public List<string> Configs { get; set; } = new List<string>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("MethodPrefixModifiers")]
        [XmlArrayItem("Modifier")]
        public List<MethodPrefixModifier> MethodPrefixModifiersList = new List<MethodPrefixModifier>();

        Dictionary<string, MethodPrefixModifier> _methodPrefixModifiers;
        /// <summary>
        /// Method prefix modifiers configuration for handling prefixes and noun transformations
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, MethodPrefixModifier> MethodPrefixModifiers
        {
            get
            {
                if (_methodPrefixModifiers == null)
                    _methodPrefixModifiers = MethodPrefixModifiersList.ToDictionary(m => m.StartsWith, m => m, StringComparer.OrdinalIgnoreCase);

                return _methodPrefixModifiers;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("VerbNounTransformationPatterns")]
        [XmlArrayItem("Pattern")]
        public List<VerbTransformationPattern> VerbNounTransformationPatternsList = new List<VerbTransformationPattern>();

        Dictionary<string, VerbTransformationPattern> _verbNounTransformationPatterns;
        /// <summary>
        /// Verb transformation patterns for special operation naming patterns
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, VerbTransformationPattern> VerbNounTransformationPatterns
        {
            get
            {
                if (_verbNounTransformationPatterns == null)
                    _verbNounTransformationPatterns = VerbNounTransformationPatternsList.ToDictionary(p => p.Verb, p => p, StringComparer.OrdinalIgnoreCase);

                return _verbNounTransformationPatterns;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlElement("PluralNounRules")]
        public PluralNounRules PluralNounRulesList = new PluralNounRules();

        /// <summary>
        /// Plural noun rules configuration - applies Collection suffix only when singular/plural conflicts are detected
        /// </summary>
        [XmlIgnore]
        public PluralNounRules PluralNounRules => PluralNounRulesList;

        /// <summary>
        /// Collection of deserialized service configuration models indexed by C2jFilename
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, ConfigModel> ConfigModels { get; set; } = new Dictionary<string, ConfigModel>();

        /// <summary>
        /// Global definition of types our cmdlets can accept as 'InputObject' 
        /// from the pipeline and the type member to cmdlet parameter mapping(s) 
        /// that should be performed if the type is detected
        /// </summary>
        [XmlArray("InputObjectMappingRules")]
        [XmlArrayItem("InputObjectMapping")]
        public List<InputObjectMapping> InputObjectMappingRulesList { get; set; }

        Dictionary<string, InputObjectMapping> _inputObjectMappingRules;
        [XmlIgnore]
        public Dictionary<string, InputObjectMapping> InputObjectMappingRules
        {
            get
            {
                if (_inputObjectMappingRules == null)
                    _inputObjectMappingRules = InputObjectMappingRulesList.ToDictionary(a => a.MappingRefName, a => a);
                return _inputObjectMappingRules;
            }
        }

        [XmlArray("IncludeLibraries")]
        public List<Library> IncludeLibrariesList = new List<Library>();

        [XmlArray("CommonModuleAliases")]
        [XmlArrayItem("AliasSet")]
        public List<AliasSet> CommonModuleAliasesList = new List<AliasSet>();

        Dictionary<string, HashSet<string>> _commonModuleAliases;
        [XmlIgnore]
        public Dictionary<string, HashSet<string>> CommonModuleAliases
        {
            get { return _commonModuleAliases ?? (_commonModuleAliases = CommonModuleAliasesList.ToDictionary(a => a.Cmdlet, a => a.Aliases)); }
        }

        /// <summary>
        /// Loads the core config.xml file and the indicated service configuration files it contains.
        /// </summary>
        /// <param name="configurationsFolder"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public static ConfigModelCollection LoadAllConfigs(string configurationsFolder, bool verbose = false)
        {
            var manifestConfigFile = Path.GetFullPath(Path.Combine(configurationsFolder, "Configs.xml"));
            if (verbose)
                Console.WriteLine("...loading configuration manifest {0}", manifestConfigFile);
            var manifestConfig = DeserializeModelCollection(manifestConfigFile);

            var serviceConfigurationsFolder = Path.Combine(configurationsFolder, CmdletGenerator.ServiceConfigFoldername);
            var serviceConfigurations = Directory.GetFiles(serviceConfigurationsFolder, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (var configFile in serviceConfigurations.OrderBy(x => x))
            {
                if (verbose)
                    Console.WriteLine("...loading service configuration {0}", configFile);

                try
                {
                    var configModel = DeserializeModel(configFile);
                    manifestConfig.ConfigModels.Add(configModel.C2jFilename, configModel);
                }
                catch (Exception e)
                {
                    throw new Exception("Failed to deserialize config model " + configFile, e);
                }
            }

            return manifestConfig;
        }

        private static ConfigModelCollection DeserializeModelCollection(string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ConfigModelCollection));
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        return (ConfigModelCollection)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException("Unable to retrieve content for file " + fileName, e);
            }
        }

        private static ConfigModel DeserializeModel(string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ConfigModel));
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        return (ConfigModel)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException("Unable to retrieve content for file " + fileName, e);
            }
        }
    }

    /// <summary>
    /// Defines a single input object member to cmdlet parameter mapping rule
    /// </summary>
    public class MappingRule
    {
        /// <summary>
        /// The name of the member in the cast input object the cmdlet should extract
        /// </summary>
        [XmlAttribute]
        public string MemberName { get; set; }

        /// <summary>
        /// The cmdlet parameter to which the extracted member should be applied
        /// </summary>
        [XmlAttribute]
        public string ParamName { get; set; }

        /// <summary>
        /// InputObject parameter help documentation for this rule
        /// </summary>
        [XmlAttribute]
        public string HelpDescription { get; set; }
    }

    /// <summary>
    /// Defines type conversion mapping rules for a given type
    /// </summary>
    public class InputObjectMapping
    {
        /// <summary>
        /// Name that can be used to reference this type mapping from other config files
        /// </summary>
        [XmlAttribute("RefName")]
        public string MappingRefName { get; set; }

        /// <summary>
        /// Returns true if this entry is a reference to a global map entry via
        /// MappingRefName
        /// </summary>
        [XmlIgnore]
        public bool IsGlobalReference
        {
            get { return string.IsNullOrEmpty(this.TypeName); }
        }

        /// <summary>
        /// The CLR type that these map rules apply to
        /// </summary>
        [XmlAttribute("Type")]
        public string TypeName { get; set; }

        [XmlArray("MappingRules")]
        [XmlArrayItem("MappingRule")]
        public List<MappingRule> MappingRules { get; set; }

    }

    /// <summary>
    /// Defines the configuration for a given service model that is passed to the generator
    /// </summary>
    public class ConfigModel
    {
        #region Configuration Properties

        /// <summary>
        /// Manually increment this number in the xml configuration file when
        /// making heavy changes to the format or content of the configuration.
        /// It will prevent automatically applying overrides if they present
        /// an older version.
        /// </summary>
        public int FileVersion = 0;

        /// <summary>
        /// <para>
        /// If specified, allows us to skip reflecting over the service client
        /// to generate cmdlets but still process other data in the config 
        /// (eg legacy aliases). 
        /// </para>
        /// <remarks>
        /// We currently use this for CloudSearchDomain which has non-
        /// standard client constructors and all of its operations
        /// excluded from codegen. Due to originally having plural cmdlet
        /// names, we want to take advantage of alias processing but none
        /// of the rest of the generation process.
        /// </remarks>
        /// </summary>
        public bool SkipCmdletGeneration;

        /// <summary>
        /// Base name of the corresponding C2j file containing the api model. We
        /// only use this in transition to the new C2j-based PowerShell generator
        /// framework.
        /// </summary>
        public string C2jFilename;

        /// <summary>
        /// Assembly name the AWSSDK or AWSPowerShell prefix is not included
        /// </summary>
        public string AssemblyName = string.Empty;

        /// <summary>
        /// Service-specific 'tag' to be prefixed onto each noun and alias
        /// </summary>
        public string ServiceNounPrefix = string.Empty;

        /// <summary>
        /// The marketing name of the service.
        /// </summary>
        public string ServiceName = string.Empty;

        /// <summary>
        /// Typename of the interface implemented by the service client
        /// </summary>
        public string ServiceClientInterface = string.Empty;

        /// <summary>
        /// Typename of the service client type to be instantiated
        /// </summary>
        public string ServiceClient = string.Empty;

        public string ServiceClientConfig
        {
            get
            {
                var clientIndex = ServiceClient.LastIndexOf("Client");
                if (clientIndex < 0) 
                    throw new InvalidOperationException("Cannot determine config name for client " + ServiceClient);

                return (ServiceClient.Substring(0, clientIndex) + "Config");
            }
        }

        /// <summary>
        /// The root namespace of the service in the SDK, eg Amazon.EC2
        /// </summary>
        public string ServiceNamespace => "Amazon." + AssemblyName;

        /// <summary>
        /// The Guid assigned to the service module.
        /// </summary>
        public string ServiceModuleGuid = Guid.NewGuid().ToString();

        /// <summary>
        /// Default region to use for the cmdlets if Region isn't passed in.
        /// </summary>
        public string DefaultRegion;

        /// <summary>
        /// For S3 only, switch instructs generator to treat response object as result object.
        /// </summary>
        [XmlIgnore]
        public bool IsS3
        {
            get
            {
                return string.Equals(ServiceClientInterface, "IAmazonS3", StringComparison.Ordinal);
            }
        }

        /// <summary>
        /// Optional name of a parameter across one or more cmdlets that we should apply
        /// PipelineParameter to, unless the service operation being generated has an
        /// override.
        /// </summary>
        public string PipelineParameter = string.Empty;

        public AutoIteration AutoIterate = null;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("VerbMappings")]
        public List<Map> VerbMappingsList = new List<Map>();

        Dictionary<string, string> _verbMappings;
        /// <summary>
        /// Service-specific overrides of verb remaps
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> VerbMappings
        {
            get { return _verbMappings ?? (_verbMappings = VerbMappingsList.ToDictionary(m => m.From, m => m.To)); }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("NounMappings")]
        public List<Map> NounMappingsList = new List<Map>();

        Dictionary<string, string> _nounMappings;
        /// <summary>
        /// Service-specific noun remaps
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> NounMappings
        {
            get { return _nounMappings ?? (_nounMappings = NounMappingsList.ToDictionary(m => m.From, m => m.To)); }
        }

        /// <summary>
        /// Collection of service-global parameter customizations.
        /// </summary>
        [XmlArray("Params")]
        [XmlArrayItem("Param")]
        public List<Param> CustomParametersList = new List<Param>();

        private Dictionary<string, Param> _customParameters;

        [XmlIgnore]
        public IDictionary<string, Param> CustomParameters
        {
            get
            {
                if (_customParameters == null)
                {
                    _customParameters = CustomParametersList.ToDictionary(p => p.Name, p => p);
                }

                return _customParameters;
            }
        }
        public Param FindCustomParameterData(string parameterName)
        {
            if (CustomParameters.ContainsKey(parameterName))
                return CustomParameters[parameterName];

            return null;
        }

        public bool ShouldExcludeParameter(string parameterName)
        {
            return ShouldExcludeParameter(parameterName, CustomParameters);
        }

        internal static bool ShouldExcludeParameter(string parameterName, IDictionary<string, Param> customizedParameters)
        {
            if (customizedParameters == null)
                return false;

            // we use a convention of a trailing _ on the parameter name to 
            // allow us to exclude a group of parameters by common prefix
            foreach (var p in customizedParameters)
            {
                var param = p.Value;
                if (param.Exclude)
                {
                    if (param.Name.EndsWith("_", StringComparison.Ordinal)
                            && parameterName.StartsWith(param.Name, StringComparison.Ordinal))
                        return true;
                    
                    if (param.Name.Equals(parameterName, StringComparison.Ordinal))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Additional aliases defined in the config, beyond the automatic aliases we generate.
        /// These go into awsaliases.ps1.
        /// Key is the cmdlet name; value is the alias (including parameters)
        /// </summary>
        [XmlArray("CustomAliases")]
        [XmlArrayItem("AliasSet")]
        public List<AliasSet> CustomAliasesList = new List<AliasSet>();

        Dictionary<string, HashSet<string>> _customAliases;
        [XmlIgnore]
        public Dictionary<string, HashSet<string>> CustomAliases
        {
            get { return _customAliases ?? (_customAliases = CustomAliasesList.ToDictionary(a => a.Cmdlet, a => a.Aliases)); }
        }

        /// <summary>
        /// Legacy alias entries for custom, hand-maintained cmdlets for a service.
        /// These entries are used to ensure the aliases get emitted into the 
        /// AWSPowerShellLegacyAliases.psm1 file and the overall module manifest. Hand-
        /// maintained cmdlets that need a legacy alias should also have a LegacyAlias
        /// attribute entry added to their AWSCmdletAttribute - this ensures that an table
        /// of contents entry is generated for the alias in the web doc generator.
        /// NOTE: Only use this collection in config files to provide aliases for custom
        /// cmdlets. For generatable service operations, use the LegacyAlias attribute
        /// on the respective ServiceOperation element.
        /// Key is the current cmdlet name; value is the backwards-compatible alias
        /// (there should only ever be one alias)
        /// </summary>
        [XmlArray("LegacyAliases")]
        [XmlArrayItem("AliasSet")]
        public List<AliasSet> LegacyAliasesList = new List<AliasSet>();

        Dictionary<string, HashSet<string>> _legacyAliases;
        [XmlIgnore]
        public Dictionary<string, HashSet<string>> LegacyAliases
        {
            get { return _legacyAliases ?? (_legacyAliases = LegacyAliasesList.ToDictionary(a => a.Cmdlet, a => a.Aliases)); }
        }

        /// <summary>
        /// List of common service-specific output properties to be considered as metadata, this
        /// is used to fill in the list of metadata properties for an operation during its first
        /// automated configuration
        /// </summary>
        [XmlArray("MetadataProperties")]
        [XmlArrayItem("Property")]
        public List<string> MetadataPropertyNames { get; set; }

        public const string ParamEmitterComplexKeyFormat = "{0}#{1}"; // type#propname

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("ParamEmitters")]
        [XmlArrayItem("ParamEmitter")]
        public List<ParamEmitter> ParamEmittersList = new List<ParamEmitter>();

        Dictionary<string, string> _typeSpecificParamEmitters;
        /// <summary>
        /// Returns the service-specific custom parameter emitters that are tied to a 
        /// specific type. These parameters are only injected on cmdlets that have a
        /// parameter matching the specified type.
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> TypeSpecificParamEmitters
        {
            get
            {
                if (_typeSpecificParamEmitters == null)
                {
                    _typeSpecificParamEmitters = new Dictionary<string, string>();

                    foreach (var p in ParamEmittersList)
                    {
                        if (p.IsGlobalInjectionEmitter)
                            continue;

                        var key = !string.IsNullOrEmpty(p.ParamName)
                                ? string.Format(ParamEmitterComplexKeyFormat, p.ParamType, p.ParamName)
                                : p.ParamType;

                        _typeSpecificParamEmitters.Add(key, p.EmitterType);
                    }
                }

                return _typeSpecificParamEmitters;
            }
        }

        List<ParamEmitter> _globalInjectionParamEmitters;

        /// <summary>
        /// Returns the collection of param emitters that are configured globally
        /// for a service. These parameters are injected into every cmdlet unless
        /// the cmdlet is configured in the exclusion list for an emitter.
        /// </summary>
        [XmlIgnore]
        public List<ParamEmitter> GlobalInjectionParamEmitters
        {
            get
            {
                if (_globalInjectionParamEmitters == null)
                {
                    _globalInjectionParamEmitters = new List<ParamEmitter>();

                    foreach (var p in ParamEmittersList)
                    {
                        if (p.IsGlobalInjectionEmitter)
                            _globalInjectionParamEmitters.Add(p);
                    }
                }

                return _globalInjectionParamEmitters;
            }
        }

        private List<ServiceOperation> _serviceOperationsList = new List<ServiceOperation>();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("ServiceOperations")]
        [XmlArrayItem("ServiceOperation")]
        public List<ServiceOperation> ServiceOperationsList
        {
            get
            {
                return _serviceOperationsList;
            }
            set
            {
                _serviceOperationsList = value;
                _serviceOperations = null;
            }
        }

        Dictionary<string, ServiceOperation> _serviceOperations;
        [XmlIgnore]
        public Dictionary<string, ServiceOperation> ServiceOperations
        {
            get
            {
                if (_serviceOperations == null)
                    _serviceOperations = ServiceOperationsList.ToDictionary(a => a.MethodName + "Async", a => a);
                return _serviceOperations;
            }
        }

        public string GetServiceCmdletClassName(bool usingAnonymousAuth)
        {
            if (usingAnonymousAuth)
                return string.Concat("Anonymous", ServiceClient);

            return ServiceClient;
        }

        private bool? _requiresAnonymousServiceCmdletClass = null;
        [XmlIgnore]
        public bool RequiresAnonymousServiceCmdletClass
        {
            get
            {
                if (_requiresAnonymousServiceCmdletClass == null)
                {
                    _requiresAnonymousServiceCmdletClass = false;
                    foreach (var so in ServiceOperationsList)
                    {
                        if (so.RequiresAnonymousAuthentication)
                        {
                            _requiresAnonymousServiceCmdletClass = true;
                            break;
                        }
                    }
                }

                return _requiresAnonymousServiceCmdletClass.Value;
            }
        }

        /// <summary>
        /// Service-specific collection of type names that will not be flattened
        /// during parameter generation. This collection is fused with the global
        /// collection automatically during codegen.
        /// </summary>
        [XmlArray("TypesNotToFlatten")]
        [XmlArrayItem("Type")]
        public List<string> TypesNotToFlatten { get; set; } = new List<string>();

        #endregion

        #region Generated Output Properties

        [XmlIgnore]
        public ArgumentCompleterDetails ArgumentCompleters { get; } = new ArgumentCompleterDetails();

        [XmlIgnore]
        public Dictionary<string, AdvancedCmdletInfo> AdvancedCmdlets { get; } = new Dictionary<string, AdvancedCmdletInfo>(StringComparer.CurrentCultureIgnoreCase);

        [XmlIgnore]
        public IEnumerable<string> SDKDependencies { get; set; }

        [XmlIgnore]
        public readonly List<AnalysisError> AnalysisErrors = new List<AnalysisError>();

        [XmlIgnore]
        public System.Reflection.Assembly Assembly;

        #endregion

        public ConfigModel()
        {
        }

        public void Serialize(string filePath)
        {
            Console.WriteLine("Updating configuration file for service {0}, file {1}", ServiceName, filePath);
            try
            {
                var serializer = new XmlSerializer(typeof(ConfigModel));
                var writerSettings = new XmlWriterSettings
                {
                    Encoding = new UTF8Encoding(false),
                    Indent = true,
                    IndentChars = "    "
                };

                using (var writer = XmlWriter.Create(filePath, writerSettings))
                {
                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException("Unable to serialize updated model to " + filePath, e);
            }
        }
    }

    /// <summary>
    /// Information about handwritten cmdlets. These are filled in by AdvancedCmdletScanner
    /// </summary>
    public class AdvancedCmdletInfo
    {
        public List<string> OperationNames = new List<string>();
    }

    /// <summary>
    /// Encapsulates all the generation info for a given service operation
    /// </summary>
    public class ServiceOperation
    {
        [XmlAttribute]
        public string MethodName;

        /// <summary>
        /// The property of the operation's output class to be returned from the cmdlet
        /// (unless the user specifies differently using the -Select parameter).
        /// A value of null means that the operation doens't return any non-metadata
        /// property,.the cmdlet will return void to allow choosing a proper OutputProperty
        /// value at a later date without breaking backward compatibility (in case return
        /// properties are added to the operation).
        /// A value of "" means that the whole service response should be returned.
        /// </summary>
        [XmlAttribute]
        public string OutputProperty;

        /// <summary>
        /// Set to the name of a member of the response class that contains the true output
        /// of the call (happens when the SDK wraps the output into a nested member, instead
        /// of hosting it in the response class itself - it does this with some SWF response 
        /// types). The generator will use the indicated member when it does Output and
        /// auto-pagination inspection instead of using the outer response class. The
        /// semantics for 'Output' will therefore apply to the wrapping member, not the response
        /// class.
        /// </summary>
        [XmlAttribute]
        public string OutputWrapper;

        [XmlAttribute("Verb")] 
        public string RequestedVerb = string.Empty;

        [XmlAttribute("Noun")]
        public string RequestedNoun = string.Empty;

        [XmlArray("Params")]
        [XmlArrayItem("Param")]
        public List<Param> CustomParametersList = new List<Param>();

        private Dictionary<string, Param> _customParameters;
        
        [XmlIgnore]
        public IDictionary<string, Param> CustomParameters
        {
            get
            {
                if (_customParameters == null)
                {
                    _customParameters = CustomParametersList?.ToDictionary(param => param.Name, param => param) ?? new Dictionary<string, Param>();
                }

                return _customParameters;
            }
        }

        public bool ShouldExcludeParameter(string parameterName)
        {
            return ConfigModel.ShouldExcludeParameter(parameterName, CustomParameters);
        }

        public Param FindCustomParameterData(string parameterName)
        {
            if (CustomParameters.ContainsKey(parameterName))
                return CustomParameters[parameterName];

            return null;
        }

        /// <summary>
        /// If set, the operation is excluded from generation.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool Exclude;

        /// <summary>
        /// Set true to suppresses generation of the SupportsShouldProcess 
        /// attribution and code pattern foir cmdlets that don't change
        /// system state but whose verb is not on the 'ignore' list.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool IgnoreSupportsShouldProcess;

        /// <summary>
        /// If the cmdlet verb is one that needs SupportsShouldProcess
        /// attributing and the request class has more than one property,
        /// indicates the name of the cmdlet property that we will prompt
        /// for confirmation on. 
        /// </summary>
        [XmlAttribute]
        public string ShouldProcessTarget;

        /// <summary>
        /// If the resources the cmdlet is going to operate on can't be
        /// identified to the point of being able to include them in a
        /// confirmation prompt, set this true to indicate that the
        /// generator should not error on the failure to have an explicit
        /// target be set in the config.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool AnonymousShouldProcessTarget;

        /// <summary>
        /// If the cmdlet verb is one that needs SupportsShouldProcess
        /// attributing, optionally contains a more readable display-format 
        /// noun for the type of object we are prompting for confirmation on 
        /// (eg 'Customer Gateway'). If not specified, the cmdlet noun is used 
        /// in any confirmation messages we generate.
        /// </summary>
        [XmlAttribute]
        public string ShouldProcessMsgNoun;

        /// <summary>
        /// The type of anonymous authentication permitted for a given operation.
        /// Most operations require user authentication, some allow it to be optional
        /// (via an injected SwitchParameter that the user can specify) and others 
        /// always operate anonymously.
        /// </summary>
        public enum AnonymousAuthenticationMode
        {
            Never,
            Optional,
            Always
        }

        /// <summary>
        /// If set 'Always;, the operation is unauthenticated and will be generated to use a
        /// service cmdlet base class that is configured to use AnonymousCredentials (eventually 
        /// we could detect this from attribution on the operation in the SDK or C2j model).
        /// </summary>
        [XmlAttribute]
        [DefaultValue(AnonymousAuthenticationMode.Never)]
        public AnonymousAuthenticationMode AnonymousAuthentication = AnonymousAuthenticationMode.Never;

        [XmlIgnore]
        public bool RequiresAnonymousAuthentication
        {
            get
            {
                return AnonymousAuthentication == AnonymousAuthenticationMode.Always;
            }
        }

        /// <summary>
        /// Set of parameter names, ;-delimited, that should have Position data emitted
        /// in order of definition (starting at 0). PS recommendation is no more than 5 
        /// per cmdlet. This list will be  with prefixed with the cross-operation set
        /// of PositionalParameters.
        /// </summary>
        [XmlAttribute]
        public string PositionalParameters;

        [XmlIgnore]
        public string[] PositionalParametersList
        {
            get
            {
                return PositionalParameters?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
            }

            set
            {
                PositionalParameters = value == null ? null : string.Join(";", value);
            }
        }

        /// <summary>
        /// Name of the single parameter (single per PS convention) that should be 
        /// tagged as accepting pipeline input by value if the service global
        /// PipelineParameter setting does not apply.
        /// </summary>
        /// <remarks>
        /// This differs from pipeline input by matching property name, of which
        /// more than one param can be tagged.
        /// </remarks>
        [XmlAttribute]
        public string PipelineParameter = string.Empty;

        /// <summary>
        /// If set true, the cmdlet can be generated without triggering an
        /// error due to a missing PipelineParameter attribute.
        /// </summary>
        [XmlAttribute]
        public bool NoPipelineParameter;

        /// <summary>
        /// Custom pass-thru expression override to use instead of automatically
        /// emitted the parameter marked for pipeline input to the output, for
        /// operations that have an output type of 'void'.
        /// </summary>
        public PassThruOverride PassThru;

        /// <summary>
        /// Overrides the service level iteration settings for an operation, for
        /// services that use inconsistent markers etc across their apis
        /// </summary>
        public AutoIteration AutoIterate;

        /// <summary>
        /// This should not be set to true for new operations. 
        /// When set to true, auto-iteration defined in the config will be used.
        /// otherwise .NET SDK's Paginator attributes will be used.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool LegacyV4Pagination = false;

        public enum LegacyPaginationType
        {
            Default,
            DisablePagination,
            UseEmitLimit
        }

        /// <summary>
        /// For AWSPowerShell and AWSPowerShell.NetCore, emit legacy pagination code using EmitLimit
        /// </summary>
        [XmlAttribute]
        [DefaultValue(LegacyPaginationType.Default)]
        public LegacyPaginationType LegacyPagination;

        [XmlAttribute]
        public string LegacyPaginationCountParameter;

        /// <summary>
        /// <para>
        /// If specified, the legacy cmdlet name for which a Set-Alias entry will be added to
        /// the AWSPowerShellLegacyAliases.psm1 file during generation. 
        /// </para>
        /// <para>
        /// This mechanism allows us to rename cmdlets going forward without introducing a 
        /// breaking change (the psm1 file is auto-loaded when our module loads). The value 
        /// of the attribute is the old name of the cmdlet - this will be used as the -Name 
        /// value to the Set-Alias cmdlet. The -Value for Set-Alias will be the current name 
        /// of the cmdlet.
        /// </para>
        /// </summary>
        [XmlAttribute]
        public string LegacyAlias;

        /// <summary>
        /// Operation-specific collection of type names that will not be flattened
        /// during parameter generation. This collection is fused with the service and global
        /// collections automatically during codegen.
        /// </summary>
        [XmlArray("TypesNotToFlatten")]
        [XmlArrayItem("Type")]
        public List<string> TypesNotToFlatten { get; set; } = new List<string>();

        /// <summary>
        /// If set, this message is used for the Obsolete attribute.
        /// </summary>
        [XmlAttribute]
        public string ReplacementObsoleteMessage;

        /// <summary>
        /// Must be one of the values of System.Management.Automation.ConfirmImpact or null
        /// </summary>
        [XmlAttribute]
        public string ConfirmImpact;

        /// <summary>
        /// Default parameter set for the cmdlet.
        /// </summary>
        [XmlAttribute]
        public string DefaultParameterSet;


        #region Data constructed during generation

        /// <summary>
        /// The analyzer instance and its results for this op
        /// </summary>
        [XmlIgnore]
        public OperationAnalyzer Analyzer;

        /// <summary>
        /// The verb we decided, or were directed, to use for the cmdlet
        /// </summary>
        [XmlIgnore]
        public string SelectedVerb;

        /// <summary>
        /// The noun we decided, or were directed, to use for the cmdlet
        /// </summary>
        [XmlIgnore]
        public string SelectedNoun;

        /// <summary>
        /// The noun from the split-apart service method name; for use as 
        /// the noun in confirmation messages if the cmdlet needs to implement
        /// the ShouldSupportProcess pattern
        /// </summary>
        [XmlIgnore]
        public string OriginalNoun;


        /// <summary>
        /// The noun from the split-apart service method name; for use as 
        /// the noun in confirmation messages if the cmdlet needs to implement
        /// the ShouldSupportProcess pattern
        /// </summary>
        [XmlIgnore]
        public string OriginalVerb;

        /// <summary>
        /// The method prefix parsed from the method name (e.g., "Admin", "Batch")
        /// extracted during ParseVerbAndNoun processing
        /// </summary>
        [XmlIgnore]
        public string ParsedMethodPrefix;

        /// <summary>
        /// Returns true if the method name is a single word (no noun and no method prefix)
        /// </summary>
        [XmlIgnore]
        public bool IsMethodNameNounLess => string.IsNullOrEmpty(OriginalNoun);

        /// <summary>
        /// Set true once we've encountered the operation config and matched it
        /// with a method on the service client. If any operations are still false
        /// when we conclude the service generation, we emit a build fail since it
        /// indicates we could be building against an out-of-date sdk.
        /// </summary>
        [XmlIgnore]
        public bool Processed;

        /// <summary>
        /// Set when the generator detects a method that is not configured already.
        /// The generator will take a best-guess attempt to set up a service operation
        /// entry that can then be adjusted by hand if needed.
        /// </summary>
        [XmlIgnore]
        public bool IsAutoConfiguring;

        /// <summary>
        /// Set when the generator detects a parameter which conflicts with reserved parameter name.
        /// The generator will take a try to handle the reserved parameter name based on configured mappings.
        /// </summary>
        [XmlIgnore]
        public bool IsReservedParameterNameHandled;

        /// <summary>
        /// Set when the generator detects a circular dependency in nested types during parameter flattening.
        /// The generator will add the circular type to TypesNotToFlatten at service level.
        /// </summary>
        [XmlIgnore]
        public bool IsCircularDependencyDetected;

        /// <summary>
        /// Stores the VerbNounTransformationPattern that was applied during verb processing.
        /// Used to defer noun transformation to the AssignNoun method.
        /// </summary>
        [XmlIgnore]
        public VerbTransformationPattern AppliedVerbNounTransformationPattern;

        /// <summary>
        /// Stores the MethodPrefixModifier that was applied during parsing.
        /// Used to defer noun transformation to the AssignNoun method.
        /// </summary>
        [XmlIgnore]
        public MethodPrefixModifier AppliedMethodPrefixModifier;

        [XmlIgnore]
        public readonly List<AnalysisError> AnalysisErrors = new List<AnalysisError>();

        [XmlIgnore]
        public readonly List<InfoMessage> InfoMessages = new List<InfoMessage>();

        #endregion
    }

    /// <summary>
    /// Represents a configuration for a parameter emitted as part of a service operation.
    /// Parameters can be renamed, renamed with an alias, have just a set of aliases applied,
    /// be configured to be named 'as is' (ie no shortening or singularization) or have a default
    /// value available if the user skips the parameter.
    /// </summary>
    public class Param
    {
        /// <summary>
        /// Tells us where the customization originated.
        /// </summary>
        public enum CustomizationOrigin
        {
            FromConfig = 0,
            DuringGeneration
        }

        [XmlIgnore]
        public CustomizationOrigin Origin;

        /// <summary>
        /// The analyzed (and fully flattened) name of the parameter
        /// </summary>
        [XmlAttribute] 
        public string Name;

        /// <summary>
        /// If specified, contains the name that will be emitted for the parameter (ie
        /// this is the final user-visible name). If not set, the parameter will not be
        /// renamed.
        /// </summary>
        [XmlAttribute]
        public string NewName;

        /// <summary>
        /// If set false, the parameter will not be automatically renamed (by shortening
        /// and/or singularization); to change the parameter name in these cases
        /// a NewName attribute must be used otherwise the original analyzed name will
        /// be emitted.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(true)]
        public bool AutoRename = true;

        /// <summary>
        /// If set true, the parameter will be exluded from generation and will not be
        /// end-user visible.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool Exclude = false;

        /// <summary>
        /// If set false, an alias of the original name will not be applied to the 
        /// parameter (need a flag because an empty list doesn't uniquely define this
        /// case).
        /// </summary>
        [XmlAttribute]
        [DefaultValue(true)]
        public bool AutoApplyAlias = true;

        /// <summary>
        /// Sets a default value to be used if the user does not specify the parameter
        /// to the command. Supports string or scalar (int, float, double) parameters 
        /// only.
        /// During generation don't use this value, use SimplePropertyInfo.DefaultValue
        /// instead
        /// </summary>
        [XmlAttribute]
        public string DefaultValue;

        /// <summary>
        /// If specified, contains a set of one or more aliases, ;-delimited, to apply 
        /// for the parameter that have been read from the configuration file. Access this
        /// collection via the Aliases property, do not modify this string.
        /// </summary>
        [XmlAttribute(AttributeName = "Alias")]
        public string AliasesList;
       
        /// <summary>
        /// The processed set of aliases for use when emitting code. This collection can
        /// be updated as we inspect the parameters for a cmdlet.
        /// </summary>
        [XmlIgnore]
        public HashSet<string> Aliases
        {
            get
            {
                return AliasesList == null ? new HashSet<string>()
                                           : new HashSet<string>(AliasesList.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            }

            set
            {
                AliasesList = value == null ? null : string.Join(";", value);
            }
        }

        /// <summary>
        /// If specified, contains a set of one or more parameters, ;-delimited, that cannot
        /// be used together with the current one.
        /// </summary>
        [XmlAttribute(AttributeName = "ExclusiveParameters")]
        public string ExclusiveParametersList;

        /// <summary>
        /// The processed set of parameters that are not allowed when the current one is
        /// specified. This is used when emitting code.
        /// </summary>
        [XmlIgnore]
        public HashSet<string> ExclusiveParameters
        {
            get
            {
                return ExclusiveParametersList == null ? new HashSet<string>()
                                                       : new HashSet<string>(ExclusiveParametersList.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            }

            set
            {
                ExclusiveParametersList = value == null ? null : string.Join(";", value);
            }
        }

        public enum AutoConversion
        {
            None = 0,
            ToBase64 = 1
        }

        /// <summary>
        /// If set, the cmdlet automatically converts from the source type (string or
        /// byte array) to a base64 representation required by the service.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(AutoConversion.None)]
        public AutoConversion AutoConvert = AutoConversion.None;

        /// <summary>
        /// If set, this message is used for the Obsolete attribute.
        /// </summary>
        [XmlAttribute]
        public string ReplacementObsoleteMessage;

        /// <summary>
        /// The ParameterSetName to be used. This is for backward compatibility only.
        /// </summary>
        [XmlAttribute]
        public string ParameterSetName;

        /// <summary>
        /// The parameter is mandatory. This is for backward compatibility only.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool Mandatory;

        /// <summary>
        /// Replacement documentation for this parameter. This is for backward compatibility only.
        /// </summary>
        [XmlAttribute]
        [DefaultValue(null)]
        public string ParameterReplacementDocumentation;
    }

    public class AliasSet
    {
        [XmlAttribute]
        public string Cmdlet = string.Empty;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlText]
        public string AliasesField = string.Empty;

        [XmlIgnore]
        public HashSet<string> Aliases { get { return new HashSet<string>(AliasesField.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)); } }
    }

    public class AutoIteration
    {
        // set of aliases applied to paging tokens cross-services, to smooth
        // out service naming differences. We keep the parameter name to help 
        // users who either know the service api or want to reference 
        // documentation. The names are chosen to likely never interfere
        // with service names.
        private const string NextAlias = "NextToken";
        private const string EmitLimitAlias = "MaxItems";

        /// <summary>
        /// The field in the request class that indicates where the service
        /// should start returning results from
        /// </summary>
        [XmlAttribute]
        public string Start;

        /// <summary>
        /// The field in the response/result class that indicates where the
        /// next 'page' of results starts from
        /// </summary>
        [XmlAttribute]
        public string Next;

        /// <summary>
        /// For services that allow the user to set a max number of records
        /// to return; this can be more or less than the service's page size
        /// (if the service has one)
        /// </summary>
        [XmlAttribute]
        public string EmitLimit;

        /// <summary>
        /// The service's max records per call value; not all services have one
        /// </summary>
        [XmlAttribute]
        [DefaultValue(-1)]
        public int ServicePageSize = -1;

        /// <summary>
        /// The service requires EmitLimit to be set. The configuration of this
        /// value was set in order to maintain the existing behavior of the module.
        /// We have no idea what is the correct value for each service unless we
        /// test each operation!
        /// </summary>
        [XmlAttribute]
        [DefaultValue(false)]
        public bool PageSizeIsRequired;

        /// <summary>
        /// Returns the autoiteration settings, if any, for an operation by combining the service level
        /// settings and any operation-level overrides. For operation level overrides, not all settings
        /// need to be specified. For operations that have less fields than the service level, specify
        /// an empty string for the non-present fields otherwise the service level setting will be
        /// assumed.
        /// </summary>
        /// <param name="parentSettings">The service-level autoiteration settings, if any</param>
        /// <param name="childSettings">Service-operation overrides, if any</param>
        /// <returns>The combined iteration settings with child settings overriding parent settings where set</returns>
        public static AutoIteration Combine(AutoIteration parentSettings, AutoIteration childSettings)
        {
            var chosenSettings = childSettings ?? parentSettings;

            if (chosenSettings == null)
                return null;

            return new AutoIteration
            {
                Start = chosenSettings.Start,
                Next = chosenSettings.Next,
                ServicePageSize = chosenSettings.ServicePageSize,
                EmitLimit = chosenSettings.EmitLimit,
                PageSizeIsRequired = chosenSettings.PageSizeIsRequired
            };
        }

        /// <summary>
        /// Allows the generator to filter out properties related to iteration; note that the
        /// 'is truncated' property is allowed through, since it doesn't relate directly
        /// to paging/page sizes
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool IsIterationParameter(string propertyName)
        {
            return propertyName == Start || propertyName == EmitLimit;
        }

        /// <summary>
        /// Returns the cross-service alias for the specified iteration parameter (start and max params
        /// only, 'itrnext' is an internal field) provided the parameter name isn't already the alias.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string GetIterationParameterAlias(string propertyName)
        {
            if (propertyName == Start && propertyName != NextAlias)
                return NextAlias;

            if (propertyName == EmitLimit && propertyName != EmitLimitAlias)
                return EmitLimitAlias;

            return null;
        }
    }

    public class Mapping<K, V>
    {
        public K From = default(K);
        public V To = default(V);

        public Mapping() { }
        public Mapping(K from, V to)
        {
            From = from;
            To = to;
        }
    }

    public class Map
    {
        [XmlAttribute]
        public string From = string.Empty;
        [XmlAttribute]
        public string To = string.Empty;

        public Map() { }
        public Map(string from, string to)
        {
            From = from;
            To = to;
        }
    }

    /// <summary>
    /// Represents a service operation verb with its priority-based verb mappings
    /// </summary>
    public class ServiceOperationVerb
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray("Mappings")]
        [XmlArrayItem("Mapping")]
        public List<VerbMappingData> Mappings { get; set; } = new List<VerbMappingData>();
    }

    /// <summary>
    /// Represents a verb mapping with weight for XML serialization
    /// </summary>
    public class VerbMappingData
    {
        [XmlAttribute]
        public string Verb { get; set; }

        [XmlAttribute]
        public int Weight { get; set; }

        [XmlAttribute]
        public bool Default { get; set; }
    }

    /// <summary>
    /// Represents a verb mapping with priority information for runtime use
    /// </summary>
    public class VerbMapping
    {
        public string Verb { get; set; }
        public int Weight { get; set; }
        public bool IsDefault { get; set; }
    }

    /// <summary>
    /// Represents a method prefix modifier configuration for handling prefixes and noun transformations
    /// </summary>
    public class MethodPrefixModifier
    {
        /// <summary>
        /// The prefix that the operation name starts with (e.g., "Admin", "Batch")
        /// </summary>
        [XmlAttribute]
        public string StartsWith { get; set; }

        /// <summary>
        /// The noun transformation pattern using {Noun} placeholder (e.g., "Admin{Noun}", "{Noun}Batch")
        /// </summary>
        [XmlAttribute]
        public string NounTransformation { get; set; }

        /// <summary>
        /// Applies the noun transformation pattern to the given noun
        /// </summary>
        /// <param name="noun">The original noun to transform</param>
        /// <returns>The transformed noun</returns>
        public string TransformNoun(string noun)
        {
            if (string.IsNullOrEmpty(NounTransformation) || string.IsNullOrEmpty(noun))
                return noun;

            return NounTransformation.Replace("{Noun}", noun);
        }
    }

    /// <summary>
    /// Represents a verb transformation pattern for special operation naming patterns
    /// </summary>
    public class VerbTransformationPattern
    {
        /// <summary>
        /// The verb to match (e.g., "Filter", "Monitor", "Unmonitor")
        /// </summary>
        [XmlAttribute]
        public string Verb { get; set; }

        /// <summary>
        /// The target verb to transform to (e.g., "Get", "Start", "Stop")
        /// </summary>
        [XmlAttribute]
        public string TargetVerb { get; set; }

        /// <summary>
        /// The noun transformation pattern using {Noun} placeholder (e.g., "Filtered{Noun}", "{Noun}Monitoring")
        /// </summary>
        [XmlAttribute]
        public string NounTransformation { get; set; }

        /// <summary>
        /// Applies the noun transformation pattern to the given noun
        /// </summary>
        /// <param name="noun">The original noun to transform</param>
        /// <returns>The transformed noun</returns>
        public string TransformNoun(string noun)
        {
            if (string.IsNullOrEmpty(NounTransformation) || string.IsNullOrEmpty(noun))
                return noun;

            return NounTransformation.Replace("{Noun}", noun);
        }
    }

    /// <summary>
    /// Configuration for plural noun rules - applies Collection suffix only when singular/plural conflicts are detected
    /// </summary>
    public class PluralNounRules
    {
        /// <summary>
        /// The default suffix to apply when plural noun conflicts are detected (default: "Collection")
        /// </summary>
        [XmlAttribute]
        public string DefaultSuffix { get; set; } = "Collection";

        /// <summary>
        /// List of verbs for which plural noun rules should be applied
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("Rules")]
        [XmlArrayItem("Rule")]
        public List<PluralNounRule> RulesList { get; set; } = new List<PluralNounRule>();

        private HashSet<string> _verbs;

        /// <summary>
        /// Set of verbs for which plural noun rules should be applied
        /// </summary>
        [XmlIgnore]
        public HashSet<string> Verbs
        {
            get
            {
                if (_verbs == null)
                {
                    _verbs = new HashSet<string>(RulesList.Select(r => r.Verb), StringComparer.OrdinalIgnoreCase);
                }
                return _verbs;
            }
        }

        /// <summary>
        /// Checks if a verb has a plural noun rule configured
        /// </summary>
        /// <param name="verb">The verb to check</param>
        /// <returns>True if the verb has a plural noun rule, false otherwise</returns>
        public bool HasPluralNounRule(string verb)
        {
            return !string.IsNullOrEmpty(verb) && Verbs.Contains(verb);
        }
    }

    /// <summary>
    /// Represents a single plural noun rule for a specific verb
    /// </summary>
    public class PluralNounRule
    {
        /// <summary>
        /// The verb for which this rule applies
        /// </summary>
        [XmlAttribute]
        public string Verb { get; set; }
    }

    public class Library
    {
        [XmlAttribute]
        public string Name = string.Empty;
        [XmlAttribute]
        public bool AddAsReference = false;

        public Library() { }
        public Library(string name, bool addAsReference)
        {
            Name = name;
            AddAsReference = addAsReference;
        }
    }

    public class ParamEmitter
    {
        [XmlAttribute]
        public string ParamType = string.Empty;
        [XmlAttribute]
        public string ParamName = string.Empty;
        [XmlAttribute]
        public string EmitterType = string.Empty;
        [XmlAttribute]
        public string Exclude = string.Empty;

        /// <summary>
        /// Globally injected emitters are used to inject arbitrary parameters that don't map to
        /// model shape types. S3's UseAcceleratedEndpoint and UseDualstackEndpoint are
        /// examples of these; both are bools (so the type cannot be used as a key in the
        /// emitter dictionary) and both get added to multiple cmdlets.
        /// </summary>
        [XmlIgnore]
        public bool IsGlobalInjectionEmitter
        {
            get
            {
                return string.IsNullOrEmpty(ParamName) && string.IsNullOrEmpty(ParamType);
            }
        }

        public ParamEmitter() { }
        public ParamEmitter(string paramType, string emitterType) : this(paramType, string.Empty, emitterType) { }

        public ParamEmitter(string paramType, string paramName, string emitterType)
        {
            ParamType = paramType;
            ParamName = paramName;
            EmitterType = emitterType;
        }
    }

    /// <summary>
    /// Contains the custom code expression and documentation for the -PassThru parameter.
    /// <para>
    /// If not specified (the default) for a service operation that has an output type of
    /// 'void', the value passed to the parameter declared as the PipelineParameter will 
    /// be emitted (so long as the user sets the -PassThru switch). 
    /// </para>
    /// <para>
    /// If this customization is specified, the assignment to the CmdletOutput's PipelineOutput
    /// property in the cmdlet executor is done from the code expression supplied as
    /// Expression. This can be a reference to a request object field (e.g. 'request.Tags') or 
    /// a call to a custom method built as part of an extension class to the cmdlet.
    /// </para>
    /// </summary>
    public class PassThruOverride
    {
        /// <summary>
        /// The code expression that yields the output from the cmdlet. This can
        /// be a reference to a member of the SDK request object, or a member of the 
        /// cmdletContext instance or a call to a method implemented in an extension
        /// class for the cmdlet.
        /// </summary>
        /// <example>context.Tags</example>
        /// <example>GetTagOutputFromHere(context.Tags)</example>
        public string Expression { get; set; }

        /// <summary>
        /// The type of the object that is output (for collections, this should 
        /// be the collected object type). This is used to augment the OutputType
        /// attribute on the cmdlet.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 'One liner' documentation describing what is output. The generator will
        /// automatically append a 'By default, this cmdlet does not generate any output.'
        /// suffix to follow other cmdlet standards.
        /// </summary>
        public string Documentation { get; set; }
    }

    /// <summary>
    /// Tracks usage of SDK ConstantClass-derived types in parameters so that we
    /// can generate argument completers for a service.
    /// </summary>
    public class ArgumentCompleterDetails
    {
        /// <summary>
        /// Tracks the members of each ConstantClass-derived type
        /// </summary>
        private Dictionary<string, IEnumerable<string>> _constantClassMembers = new Dictionary<string, IEnumerable<string>>();

        /// <summary>
        /// Tracks the cmdlet references, by parameter name, for a given ConstantClass-derived type
        /// </summary>
        private Dictionary<string, ConstantClassReferences> _constantClassReferences = new Dictionary<string, ConstantClassReferences>();

        /// <summary>
        /// Returns the ordered collection of ConstantClass-derived type names that were
        /// found to be referenced during cmdlet generation or inspection of hand-maintained
        /// cmdlets.
        /// </summary>
        public IEnumerable<string> ReferencedClasses
        {
            get
            {
                var l = new List<string>(_constantClassReferences.Keys);
                l.Sort(); // return ordered so codegen'd file gets consistent layout
                return l;
            }
        }

        /// <summary>
        /// Returns the collection of parameter and cmdlet references for a ConstantClass-derived
        /// type.
        /// </summary>
        /// <param name="constantClassTypename"></param>
        /// <returns></returns>
        public ConstantClassReferences GetReferencesFor(string constantClassTypename)
        {
            ConstantClassReferences refs;
            if (_constantClassReferences.TryGetValue(constantClassTypename, out refs) && refs != null)
                return refs;

            throw new ArgumentException(string.Format("ConstantClass-derived type {0} has not been encountered during generation", constantClassTypename));
        }

        /// <summary>
        /// Returns the collection of members for a ConstantClass-derived type.
        /// </summary>
        /// <param name="constantClassTypename"></param>
        /// <returns></returns>
        public IEnumerable<string> GetConstantClassMembers(string constantClassTypename)
        {
            IEnumerable<string> members;
            if (_constantClassMembers.TryGetValue(constantClassTypename, out members) && members != null)
                return members;

            throw new ArgumentException(string.Format("ConstantClass-derived type {0} has not been encountered during generation", constantClassTypename));
        }

        /// <summary>
        /// Indicates if the members of the ConstantClass-derived type have already been registered.
        /// </summary>
        /// <param name="constantClassTypeName"></param>
        /// <returns></returns>
        public bool IsConstantClassRegistered(string constantClassTypeName)
        {
             return _constantClassMembers.ContainsKey(constantClassTypeName);
        }

        /// <summary>
        /// Registers the members of a ConstantClass-derived type so that we can generate
        /// an argument completer for the type.
        /// </summary>
        /// <param name="constantClassTypename"></param>
        /// <param name="setMembers"></param>
        public void AddConstantClass(string constantClassTypename, IEnumerable<string> setMembers)
        {
            if (_constantClassMembers.ContainsKey(constantClassTypename))
                return;

            _constantClassMembers.Add(constantClassTypename, setMembers);
        }

        /// <summary>
        /// Initializes or adds a new cmdlet parameter reference to a ConstantClass-derived
        /// SDK 'enum' type.
        /// </summary>
        /// <param name="constantClassTypename"></param>
        /// <param name="parameterName"></param>
        /// <param name="cmdletName"></param>
        public void AddConstantClassReference(string constantClassTypename, string parameterName, string cmdletName)
        {
            if (_constantClassReferences.ContainsKey(constantClassTypename))
            {
                var reference = _constantClassReferences[constantClassTypename];
                reference.AddReference(parameterName, cmdletName);
            }
            else
            {
                var reference = new ConstantClassReferences();
                reference.AddReference(parameterName, cmdletName);
                _constantClassReferences.Add(constantClassTypename, reference);
            }

        }
    }

    /// <summary>
    /// Tracks the cmdlets that reference an SDK ConstantClass-derived 'enum' type
    /// via the same-named parameter. Cmdlets that reference the same 'enum' type
    /// using a different parameter name will trigger a new ConstantClassReference
    /// instance.
    /// </summary>
    public class ConstantClassReferences
    {
        private SortedDictionary<string, HashSet<string>> _references = new SortedDictionary<string, HashSet<string>>();

        /// <summary>
        /// The set of parameter names that have been used to reference the
        /// ConstantClass-derived type. Ideally across a service their should
        /// be a consistent (and therefore single) name used, but we can't
        /// guarantee this.
        /// </summary>
        public IEnumerable<string> ParameterNames
        {
            get
            {
                var l = new List<string>(_references.Keys);
                l.Sort();
                return l;
            }
        }

        /// <summary>
        /// The names of the cmdlets that reference the SDK ConstantClass-derived
        /// type via a parameter of name parameterName. The names are returned in
        /// sorted order so we generate consistently ordered file contents.
        /// </summary>
        public IEnumerable<string> GetCmdletReferences(string parameterName)
        {
            if (!_references.ContainsKey(parameterName))
                throw new ArgumentException("No reference for specified parameter name");

            var refs = _references[parameterName];
            var ret = new List<string>(refs);
            ret.Sort();
            return ret;
        }

        /// <summary>
        /// Adds a reference from a cmdlet via the named parameter.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="cmdletName"></param>
        public void AddReference(string parameterName, string cmdletName)
        {
            if (_references.ContainsKey(parameterName))
            {
                var r = _references[parameterName];
                r.Add(cmdletName);
            }
            else
            {
                var r = new HashSet<string>();
                r.Add(cmdletName);
                _references.Add(parameterName, r);
            }
        }
    }
}
