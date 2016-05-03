using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
using AWSPowerShellGenerator.Utils;
using System.IO;
using System.Diagnostics;
using AWSPowerShellGenerator.Writers;

namespace AWSPowerShellGenerator.CmdletConfig
{
    /// <summary>
    /// Collection of service ConfigModel objects
    /// </summary>
    public class ConfigModelCollection
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("VerbMappings")]
        public List<Map> VerbMappingsList = new List<Map>();

        Dictionary<string, string> _verbMappings;
        /// <summary>
        /// Cross-service verb remaps
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> VerbMappings
        {
            get
            {
                if (_verbMappings == null)
                    _verbMappings = VerbMappingsList.ToDictionary(m => m.From, m => m.To);

                return _verbMappings;
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
        /// Member types that we should not attempt to flatten to 'typename_membername' during
        /// codegen
        /// </summary>
        [XmlArray("TypesNotToFlatten")]
        [XmlArrayItem("Type")]
        public List<string> TypesNotToFlatten { get; set; }

        /// <summary>
        /// List of acceptable next-token property names; these will be added as notes to the
        /// service responses for users who want to do their own paging
        /// </summary>
        [XmlArray("MetadataProperties")]
        [XmlArrayItem("Property")]
        public List<string> MetadataPropertyNames { get; set; }

        /// <summary>
        /// Collection of xml config files that the generator should operate on
        /// </summary>
        [XmlArray]
        [XmlArrayItem("Path")]
        public List<string> Configs { get; set; }

        /// <summary>
        /// Collection of deserialized service configuration models
        /// </summary>
        [XmlIgnore]
        public List<ConfigModel> ConfigModels { get; set; }

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

        /// <summary>
        /// Global cmdlet verbs that should have 'SupportsShouldProcess' attributing and operation
        /// confirmation checks added automatically.
        /// </summary>
        [XmlArray("SupportsShouldProcessVerbs")]
        [XmlArrayItem("Verb")]
        public List<string> SupportsShouldProcessVerbsList { get; set; }

        HashSet<string> _supportsShouldProcessVerbs;
        [XmlIgnore]
        public HashSet<string> SupportsShouldProcessVerbs
        {
            get
            {
                if (_supportsShouldProcessVerbs == null)
                    _supportsShouldProcessVerbs = new HashSet<string>(SupportsShouldProcessVerbsList);
                return _supportsShouldProcessVerbs;
            }
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

            var manifestConfig = Deserialize<ConfigModelCollection>(manifestConfigFile);
            foreach (var c in manifestConfig.Configs.OrderBy(c => c))
            {
                var configFile = Path.GetFullPath(Path.Combine(configurationsFolder, c));
                
                if (verbose)
                    Console.WriteLine("...loading service configuration {0}", configFile);
    
                var configModel = Deserialize<ConfigModel>(configFile);
                manifestConfig.ConfigModels.Add(configModel);
            }

            return manifestConfig;
        }

        private static T Deserialize<T>(string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        return (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException("Unable to retrieve content for file " + fileName, e);
            }
        }

        private ConfigModelCollection()
        {
            TypesNotToFlatten = new List<string>();
            Configs = new List<string>();
            ConfigModels = new List<ConfigModel>();
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
        /// If specified, governs the subfolder beneath AWSPowerShell/Cmdlets
        /// where the generated source will be emitted. If not specified,
        /// the name of the service client is used instead.
        /// </summary>
        public string SourceGenerationRoot = string.Empty;

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
        public string ServiceNamespace = string.Empty;

        /// <summary>
        /// Default region to use for the cmdlets if Region isn't passed in.
        /// </summary>
        public string DefaultRegion = string.Empty;

        /// <summary>
        /// For S3 only, switch instructs generator to treat response object as result object.
        /// </summary>
        public bool IsS3
        {
            get
            {
                return string.Equals(ServiceClientInterface, "IAmazonS3", StringComparison.Ordinal);
            }
        }

        /// <summary>
        /// Cross-operation set of parameters, ;-delimited, that should have Position data emitted
        /// in order of definition (starting at 0) for each cmdlet that uses the parameter. PS
        /// recommendation is no more than 5 per cmdlet. This list will be suffixed with operation-
        /// specific sets of positional data.
        /// </summary>
        public string PositionalParameters = string.Empty;

        string[] _positionalParametersList;
        [XmlIgnore]
        public string[] PositionalParametersList
        {
            get { return _positionalParametersList ?? (_positionalParametersList = PositionalParameters.Split(';')); }
        }

        /// <summary>
        /// Optional name of a parameter across one or more cmdlets that we should apply
        /// PipelineParameter to, unless the service operation being generated has an
        /// override.
        /// </summary>
        public string PipelineParameter = string.Empty;

        public AutoIteration AutoIterate = null;

        /// <summary>
        /// Returns the defined source generation folder or service client name
        /// (less Client suffix) to use as the output folder for generated cmdlets
        /// </summary>
        [XmlIgnore]
        public string SourceGenerationFolder
        {
            get
            {
                if (string.IsNullOrEmpty(SourceGenerationRoot))
                {
                    SourceGenerationRoot = ServiceClient.EndsWith("Client", StringComparison.Ordinal) 
                        ? ServiceClient.Substring(0, ServiceClient.Length - 6) 
                        : ServiceClient;
                }

                return SourceGenerationRoot;
            }
        }

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
                    _customParameters = new Dictionary<string, Param>(StringComparer.Ordinal);
                    foreach (var cp in CustomParametersList)
                    {
                        _customParameters.Add(cp.Name, cp);
                    }
                }

                return _customParameters;
            }
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
        /// List of additional namespaces to be included as 'using' statements in the cmdlet
        /// and therefore assumed when referencing types. The service root namespace plus
        /// '.Model' variant will be automatically added to the namespaces defined in 
        /// this list.
        /// </summary>
        [XmlArrayItem("Namespace")]
        public List<string> AdditionalNamespaces = new List<string>();

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("CustomAliases")]
        [XmlArrayItem("AliasSet")]
        public List<AliasSet> CustomAliasesList = new List<AliasSet>();

        Dictionary<string, HashSet<string>> _customAliases;
        /// <summary>
        /// Additional aliases defined in the config, beyond the automatic aliases we generate.
        /// Key is the cmdlet name; value is the alias (including parameters)
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, HashSet<string>> CustomAliases
        {
            get { return _customAliases ?? (_customAliases = CustomAliasesList.ToDictionary(a => a.Cmdlet, a => a.Aliases)); }
        }

        /// <summary>
        /// List of acceptable next-token property names
        /// </summary>
        [XmlArray("MetadataProperties")]
        [XmlArrayItem("Property")]
        public List<string> MetadataPropertyNames { get; set; }

        /// <summary>
        /// List of property names that should be set as pipeline-able by property name
        /// (ValueFromPipelineByPropertyName=true gets added to the Parameter attribute
        /// for the property).
        /// </summary>
        [XmlArray("PipelineByValueProperties")]
        [XmlArrayItem("Property")]
        public List<string> PipelineByValuePropertyNamesList { get; set; }

        HashSet<string> _pipelineByValueProperties;

        [XmlIgnore]
        public HashSet<string> PipelineByValueProperties
        {
            get { return _pipelineByValueProperties ?? (_pipelineByValueProperties = new HashSet<string>(PipelineByValuePropertyNamesList)); }
        }

        public const string ParamEmitterComplexKeyFormat = "{0}#{1}"; // type#propname

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("ParamEmitters")]
        [XmlArrayItem("ParamEmitter")]
        public List<ParamEmitter> ParamEmittersList = new List<ParamEmitter>();

        Dictionary<string, string> _paramEmitters;
        /// <summary>
        /// Service-specific custom parameter emitters
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> ParamEmitters
        {
            get
            {
                if (_paramEmitters == null)
                    _paramEmitters = ParamEmittersList.ToDictionary
                        (p => (string.IsNullOrEmpty(p.ParamName) 
                                ? p.ParamType 
                                : string.Format(ParamEmitterComplexKeyFormat, p.ParamType, p.ParamName)), 
                         p => p.EmitterType);

                return _paramEmitters;
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("ServiceOperations")]
        [XmlArrayItem("ServiceOperation")]
        public List<ServiceOperation> ServiceOperationsList { get; set; }

        Dictionary<string, ServiceOperation> _serviceOperations;
        [XmlIgnore]
        public Dictionary<string, ServiceOperation> ServiceOperations
        {
            get
            {
                if (_serviceOperations == null)
                    _serviceOperations = ServiceOperationsList.ToDictionary(a => a.MethodName, a => a);
                return _serviceOperations;
            }
        }

        /// <summary>
        /// Service-specific definition of types our cmdlets can accept as 'InputObject' 
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

        /// <summary>
        /// Cmdlet verbs that should have 'SupportsShouldProcess' attributing and operation
        /// confirmation checks added automatically.
        /// </summary>
        [XmlArray("SupportsShouldProcessVerbs")]
        [XmlArrayItem("Verb")]
        public List<string> SupportsShouldProcessVerbsList { get; set; }

        HashSet<string> _supportsShouldProcessVerbs;
        [XmlIgnore]
        public HashSet<string> SupportsShouldProcessVerbs
        {
            get
            {
                if (_supportsShouldProcessVerbs == null)
                    _supportsShouldProcessVerbs = new HashSet<string>(SupportsShouldProcessVerbsList);
                return _supportsShouldProcessVerbs;
            }
        }

        public bool RequiresShouldSupportProcess(string selectedVerb)
        {
            return SupportsShouldProcessVerbs.Contains(selectedVerb);
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
        #endregion

        #region Generated Output Properties

        private readonly List<string> _singlePropertyResultOperations = new List<string>();
        private readonly List<string> _multiPropertyResultOperations = new List<string>();
        private readonly List<string> _emptyResultOperations = new List<string>();
        private readonly List<string> _createdFiles = new List<string>();
        
        [XmlIgnore]
        public List<string> SinglePropertyResultOperations 
        { 
            get { return _singlePropertyResultOperations; }
        }

        [XmlIgnore]
        public List<string> MultiPropertyResultOperations
        {
            get { return _multiPropertyResultOperations; }
        }

        [XmlIgnore]
        public List<string> EmptyResultOperations
        {
            get { return _emptyResultOperations; }
        }

        [XmlIgnore]
        public List<string> CreatedFiles
        {
            get { return _createdFiles; }
        }

        #endregion

        public ConfigModel() { }
    }

    /// <summary>
    /// Encapsulates all the generation info for a given service operation
    /// </summary>
    public class ServiceOperation
    {
        [XmlAttribute]
        public string MethodName = string.Empty;

        /// <summary>
        /// <para>
        /// Controls what output from the service call is emitted to the pipeline. If the
        /// inspection of the response object does not yield the same result as the
        /// configured output mode this can indicate a breaking change. By default
        /// service operations are configured to expect a response object containing
        /// a single logical property of interest to the user - this is done by not
        /// adding an Output attribute value.
        /// </para>
        /// <para>
        /// Note that if OutputWrapper is configured, these settings apply to the
        /// wrapping member type with the same semantics.
        /// </para>
        /// </summary>
        public enum OutputMode
        {
            /// <summary>
            /// The response from the service contains a single property; output that
            /// to the pipeline.
            /// </summary>
            Default = 0,

            /// <summary>
            /// The response from the service contains more than one property; output
            /// the entire response object to the pipeline.
            /// </summary>
            Response,

            /// <summary>
            /// The response from the service contains no useful data. Output nothing
            /// to the pipeline.
            /// </summary>
            Void
        }

        [XmlAttribute]
        public OutputMode Output = OutputMode.Default;

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
        public string OutputWrapper = string.Empty;

        /// <summary>
        /// The path to the properties contained in the service call output. Usually this
        /// is just 'response' but if the SDK wrapped the output in a nested class, we
        /// may have one more level to navigate.
        /// </summary>
        [XmlIgnore]
        public string ResponseMemberPath
        {
            get
            {
                // choosing not to cache but if generator perf gets affected
                // we have that option
                return string.IsNullOrEmpty(OutputWrapper)
                                ? "response"
                                : string.Concat("response.", OutputWrapper);
            }
        }

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
                    _customParameters = new Dictionary<string, Param>(StringComparer.Ordinal);
                    foreach (var cp in CustomParametersList)
                    {
                        _customParameters.Add(cp.Name, cp);                                                
                    }    
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
        public bool Exclude = false;

        /// <summary>
        /// Set true to suppresses generation of the SupportsShouldProcess 
        /// attribution and code pattern foir cmdlets that don't change
        /// system state but whose verb is not on the 'ignore' list.
        /// </summary>
        [XmlAttribute]
        public bool IgnoreSupportsShouldProcess = false;

        /// <summary>
        /// If the cmdlet verb is one that needs SupportsShouldProcess
        /// attributing and the request class has more than one property,
        /// indicates the name of the cmdlet property that we will prompt
        /// for confirmation on. 
        /// </summary>
        [XmlAttribute]
        public string ShouldProcessTarget = string.Empty;

        /// <summary>
        /// If the resources the cmdlet is going to operate on can't be
        /// identified to the point of being able to include them in a
        /// confirmation prompt, set this true to indicate that the
        /// generator should not error on the failure to have an explicit
        /// target be set in the config.
        /// </summary>
        [XmlAttribute]
        public bool AnonymousShouldProcessTarget = false;

        /// <summary>
        /// If the cmdlet verb is one that needs SupportsShouldProcess
        /// attributing, optionally contains a more readable display-format 
        /// noun for the type of object we are prompting for confirmation on 
        /// (eg 'Customer Gateway'). If not specified, the cmdlet noun is used 
        /// in any confirmation messages we generate.
        /// </summary>
        [XmlAttribute]
        public string ShouldProcessMsgNoun = string.Empty;

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
        public string PositionalParameters = string.Empty;

        string[] _positionalParametersList;
        [XmlIgnore]
        public string[] PositionalParametersList
        {
            get { return _positionalParametersList ?? (_positionalParametersList = PositionalParameters.Split(';')); }
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
        /// error due to a missing PipelineParameter attribute when more
        /// than one parameter exists.
        /// </summary>
        [XmlAttribute]
        public bool NoPipelineParameter = false;

        /// <summary>
        /// Set of response/result names, ;-delimited, that are considered metadata and will
        /// be ignored when evaluating how to simplify the output. The meta fields aren't
        /// lost, they will be attached as notes to the service response in the history stack.
        /// </summary>
        [XmlAttribute]
        public string MetadataProperties = string.Empty;

        string[] _metadataPropertiesList;
        [XmlIgnore]
        public string[] MetadataPropertiesList
        {
            get { return _metadataPropertiesList ?? (_metadataPropertiesList = MetadataProperties.Split(';')); }
        }

        /// <summary>
        /// Custom pass-thru expression override to use instead of automatically
        /// emitted the parameter marked for pipeline input to the output, for
        /// operations that have an output type of 'void'.
        /// </summary>
        public PassThruOverride PassThru { get; set; }

        /// <summary>
        /// Overrides the service level iteration settings for an operation, for
        /// services that use inconsistent markers etc across their apis
        /// </summary>
        public AutoIteration AutoIterate = null;

        #region Data constructed during generation

        /// <summary>
        /// The verb we decided, or were directed, to use for the cmdlet
        /// </summary>
        [XmlIgnore]
        public string SelectedVerb { get; set; }

        /// <summary>
        /// The noun we decided, or were directed, to use for the cmdlet
        /// </summary>
        [XmlIgnore]
        public string SelectedNoun { get; set; }

        /// <summary>
        /// The noun from the split-apart service method name; for use as 
        /// the noun in confirmation messages if the cmdlet needs to implement
        /// the ShouldSupportProcess pattern
        /// </summary>
        [XmlIgnore]
        public string OriginalNoun { get; set; }

        /// <summary>
        /// Set true once we've encountered the operation config and matched it
        /// with a method on the service client. If any operations are still false
        /// when we conclude the service generation, we emit a build fail since it
        /// indicates we could be building against an out-of-date sdk.
        /// </summary>
        [XmlIgnore]
        public bool Processed { get; set; }
        #endregion
    }

    /// <summary>
    /// Represents a configuration for a parameter emitted as part of a service operation.
    /// Parameters can be renamed, renamed with an alias, have just a set of aliases applied
    /// or be configured to be named 'as is' (ie no shortening or singularization)
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
        public CustomizationOrigin Origin { get; set; }

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
        public string NewName = string.Empty;

        /// <summary>
        /// If set false, the parameter will not be automatically renamed (by shortening
        /// and/or singularization); to change the parameter name in these cases
        /// a NewName attribute must be used otherwise the original analyzed name will
        /// be emitted.
        /// </summary>
        [XmlAttribute]
        public bool AutoRename = true;

        /// <summary>
        /// If set true, the parameter will be exluded from generation and will not be
        /// end-user visible.
        /// </summary>
        [XmlAttribute]
        public bool Exclude = false;

        /// <summary>
        /// If set false, an alias of the original name will not be applied to the 
        /// parameter (need a flag because an empty list doesn't uniquely define this
        /// case).
        /// </summary>
        [XmlAttribute]
        public bool AutoApplyAlias = true;

        /// <summary>
        /// If specified, contains a set of one or more aliases, ;-delimited, to apply 
        /// for the parameter that have been read from the configuration file. Access this
        /// collection via the Aliases property, do not modify this string.
        /// </summary>
        [XmlAttribute(AttributeName = "Alias")]
        public string AliasesList = string.Empty;

        private HashSet<string> _aliasesSet;
        
        /// <summary>
        /// The processed set of aliases for use when emitting code. This collection can
        /// be updated as we inspect the parameters for a cmdlet.
        /// </summary>
        [XmlIgnore]
        public HashSet<string> Aliases
        {
            get
            {
                if (_aliasesSet == null)
                {
                    _aliasesSet = new HashSet<string>(StringComparer.Ordinal);
                    if (!string.IsNullOrEmpty(AliasesList))
                    {
                        foreach (var a in AliasesList.Split(new [] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            _aliasesSet.Add(a);
                        }
                    }
                }

                return _aliasesSet;
            }
        }
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
        /// Indicates the codegen pattern to follow
        /// </summary>
        public enum AutoIteratePattern
        {
            None = 0,

            /// <summary>
            /// Only page marker tokens, iterate until Next is empty.
            /// 'AutoIterate Start="NextToken" Next="NextToken"'
            /// </summary>
            Pattern1,

            /// <summary>
            /// Page marker tokens and ability to control data size; iterate until Next is empty.
            /// 'AutoIterate EmitLimit="MaxRecords" Start="Marker" Next="Marker"'
            /// </summary>
            Pattern2,

            /// <summary>
            /// Page marker tokens and ability to control data size; iterate until Next is empty and also
            /// have Truncated to indicate more data. For generating iteration code, we treat pattern 3
            /// as pattern 2, since Truncated has no real bearing on the iteration loop.
            /// 'AutoIterate EmitLimit="MaxItems" Start="Marker" Next="Marker" Truncated="IsTruncated"'
            /// </summary>
            Pattern3
        }

        /// <summary>
        /// The field in the request class that indicates where the service
        /// should start returning results from
        /// </summary>
        [XmlAttribute]
        public string Start = String.Empty;

        /// <summary>
        /// The field in the response/result class that indicates where the
        /// next 'page' of results starts from
        /// </summary>
        [XmlAttribute]
        public string Next = String.Empty;

        /// <summary>
        /// For services that allow the user to set a max number of records
        /// to return; this can be more or less than the service's page size
        /// (if the service has one)
        /// </summary>
        [XmlAttribute]
        public string EmitLimit = String.Empty;

        /// <summary>
        /// Some services can use a 'IsTruncated' flag to indicate more data;
        /// we prefer to detect a non-empty 'next' marker
        /// </summary>
        [XmlAttribute]
        public string TruncatedFlag = String.Empty;

        /// <summary>
        /// The service's max records per call value; not all services have one
        /// </summary>
        [XmlAttribute]
        public int ServicePageSize = -1;

        /// <summary>
        /// The list of methods which, for whatever reason, we do not support
        /// autoiteration on. Goal = none :-).  ;-delimited list of operation names.
        /// </summary>
        [XmlAttribute]
        public string Exclusions = String.Empty;

        private HashSet<string> _exclusionSet;
        [XmlIgnore]
        public HashSet<string> ExclusionSet
        {
            get
            {
                if (_exclusionSet == null)
                    _exclusionSet = new HashSet<string>(Exclusions.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                return _exclusionSet;
            }
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
            if (String.Compare(propertyName, Start, StringComparison.InvariantCultureIgnoreCase) == 0)
                return true;
            if (String.Compare(propertyName, Next, StringComparison.InvariantCultureIgnoreCase) == 0)
                return true;
            if (String.Compare(propertyName, EmitLimit, StringComparison.InvariantCultureIgnoreCase) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Inspects the parameter token declarations to determine which
        /// codegen pattern we should look for.
        /// </summary>
        public AutoIteratePattern Pattern
        {
            get
            {
                var calculatedPattern = AutoIteratePattern.None;

                // page markers is a basic requirement for any iteration
                if (!String.IsNullOrEmpty(Start) && !String.IsNullOrEmpty(Next))
                {
                    if (!String.IsNullOrEmpty(EmitLimit) && String.IsNullOrEmpty(TruncatedFlag))
                        calculatedPattern = AutoIteratePattern.Pattern2;
                    else
                        if (!String.IsNullOrEmpty(EmitLimit) && !String.IsNullOrEmpty(TruncatedFlag))
                            calculatedPattern = AutoIteratePattern.Pattern3;
                        else
                            calculatedPattern = AutoIteratePattern.Pattern1;
                }

                return calculatedPattern;
            }
        }

        /// <summary>
        /// Returns the cross-service alias for the specified iteration parameter (start and max params
        /// only, 'itrnext' is an internal field) provided the parameter name isn't already the alias.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string GetIterationParameterAlias(string propertyName)
        {
            if (IsIterationParameter(propertyName))
            {
                if (String.Equals(propertyName, Start, StringComparison.OrdinalIgnoreCase)
                        && !String.Equals(propertyName, NextAlias, StringComparison.OrdinalIgnoreCase))
                    return NextAlias;

                if (String.Equals(propertyName, EmitLimit, StringComparison.OrdinalIgnoreCase)
                        && !String.Equals(propertyName, EmitLimitAlias, StringComparison.OrdinalIgnoreCase))
                    return EmitLimitAlias;
            }

            return null;
        }

        public bool IsEmitLimit(string propertyName)
        {
            if (IsIterationParameter(propertyName))
            {
                if (String.Equals(propertyName, EmitLimit, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
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
        /// <example>request.Tags</example>
        /// <example>cmdletContext.Tags</example>
        /// <example>GetTagOutputFromHere(cmdletContext.Tags)</example>
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
}
