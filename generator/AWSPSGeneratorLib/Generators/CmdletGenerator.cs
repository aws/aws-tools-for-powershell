using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.CmdletConfig;
using AWSPowerShellGenerator.Utils;
using AWSPowerShellGenerator.Writers;
using AWSPowerShellGenerator.Writers.SourceCode;

namespace AWSPowerShellGenerator.Generators
{
    public abstract class Generator
    {
        internal BasicLogger Logger { get; private set; }

        public string OutputFolder { get; set; }

        GeneratorOptions _options = new GeneratorOptions();

        public GeneratorOptions Options
        {
            get { return _options; }
            set { _options = value; }
        }

        internal string RootGeneratorNamespace
        {
            get
            {
                // compute so we don't have an embedded magic string we might fail
                // to update
                return GetType().Namespace.Split('.')[0];
            }
        }

        public void Generate()
        {
            try
            {
                InitializeLoggers();
                GenerateHelper();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Exception thrown in generate method");
            }

            if (Logger.HasErrors)
            {
                using (var sw = new StringWriter())
                {
                    Logger.Output(sw);
                    throw new Exception(sw.ToString());
                }
            }
        }

        protected virtual void InitializeLoggers()
        {
            Logger = new BasicLogger(Options.Verbose); 

            if (!string.IsNullOrEmpty(Options.AnalysisLog))
            {
                try
                {
                    if (File.Exists(Options.AnalysisLog))
                        File.Delete(Options.AnalysisLog);
                    else
                    {
                        var path = Path.GetDirectoryName(Options.AnalysisLog);
                        if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
                            Directory.CreateDirectory(path);
                    }
                }
                catch (IOException e)
                {
                    Logger.LogError(e, "Failed to create generation analysis log {0}", Options.AnalysisLog);
                    Options.AnalysisLog = string.Empty;
                }
            }
        }

        protected abstract void GenerateHelper();
    }

    public class CmdletGenerator : Generator
    {
        #region Public properties

        /// <summary>
        /// The location of the SDK assemblies to generate against; we also expect to
        /// find the assembly ndoc files here too
        /// </summary>
        public string SdkAssembliesFolder { get; set; }

        public Type SdkBaseRequestType { get; set; }

        public string CmdletsCsprojFragment
        {
            get
            {
                return ProjectFileFragmentStore.Instance.Serialize();
            }
        }

        /// <summary>
        /// The subfolder hierarchy beneath GeneratorOptions.RootPath that holds the
        /// service xml configuration files and generator manifest to process.
        /// </summary>
        public const string CmdletGeneratorConfigurationsFoldername = @"generator\AWSPSGeneratorLib\CmdletConfig";

        public const string CmdletsOutputSubFoldername = "Cmdlets";
        public const string GeneratedCmdletsFoldername = "Basic";

        public const string AWSPowerShellProjectFilename = "AWSPowerShell.csproj";
        public const string AWSPowerShellModuleManifestFilename = "AWSPowerShell.psd1";
        public const string AliasesFilename = "AWSAliases.ps1";

        public string Aliases
        {
            get
            {
                return AliasStore.Instance.Serialize();
            }
        }

        public string TypeExtensions
        {
            get
            {
                var sw = new StringWriter();
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sw.WriteLine("<Types>");
                sw.WriteLine(TypeExtensionsStore.Instance.Serialize());
                sw.WriteLine("</Types>");
                return sw.ToString();
            }
        }

        /// <summary>
        /// Contains the loaded sdk assemblies and ndoc files as the generator
        /// progresses.
        /// </summary>
        public GenerationSources SourceArtifacts { get; private set; }

        /// <summary>
        /// The assembly for the service currently being generated
        /// </summary>
        public Assembly CurrentServiceAssembly { get; private set; }

        /// <summary>
        /// The NDoc file corresponding to CurrentServiceAssembly
        /// </summary>
        public XmlDocument CurrentServiceNDoc { get; private set; }

        /// <summary>
        /// The configuration model being applied to CurrentServiceAssembly
        /// </summary>
        public ConfigModel CurrentModel { get; private set; }

        /// <summary>
        /// The operation being generated from CurrentModel
        /// </summary>
        public ServiceOperation CurrentOperation { get; private set; }

        #endregion

        #region Private properties

        const string CoreSDKRuntimeAssemblyName = "AWSSDK.Core";

        private ConfigModelCollection ModelCollection { get; set; }

        private string TempOutputDir { get; set; }

        /// <summary>
        /// The path to the folder that will contain the generated cmdlets,
        /// organized into per-service subfolders.
        /// </summary>
        private string CmdletsOutputPath { get; set; }

        #endregion

        #region Public methods

        protected override void GenerateHelper()
        {
            SourceArtifacts = new GenerationSources { SdkAssembliesFolder = this.SdkAssembliesFolder };
            LoadCoreSDKRuntimeMaterials();

            CmdletsOutputPath = Path.Combine(OutputFolder, CmdletsOutputSubFoldername);
            var configurationsFolder = Path.Combine(Options.RootPath, CmdletGeneratorConfigurationsFoldername);

            ModelCollection = ConfigModelCollection.LoadAllConfigs(configurationsFolder, Options.Verbose);

            foreach (var configModel in ModelCollection.ConfigModels)
            {
                Logger.Log();
                Logger.Log(new string('>', 20));
                if (Options.Services == null
                        || (Options.Services.Length != 0
                                && Options.Services.Contains(configModel.ServiceNounPrefix, StringComparer.InvariantCultureIgnoreCase)))
                {
                    // hold some state to model under work so we can make use of
                    // static helpers
                    CurrentModel = configModel;

                    Logger.Log("===========================================================");
                    Logger.Log("Generating for client: {0}", CurrentModel.ServiceClientInterface);

                    GenerateClientAndCmdlets(CurrentModel);

                    if (!Options.BreakOnOutputMismatchError)
                    {
                        Console.WriteLine("Processed client {0} ({1})", CurrentModel.ServiceClientInterface, CurrentModel.ServiceNounPrefix);
                        Console.WriteLine("    Single-property result operations: {0}", string.Join(", ", CurrentModel.SinglePropertyResultOperations));
                        Console.WriteLine("    Multi-property result operations: {0}", string.Join(", ", CurrentModel.MultiPropertyResultOperations));
                        Console.WriteLine("    Empty result operations: {0}", string.Join(", ", CurrentModel.EmptyResultOperations));
                    }
                }
                else
                {
                    Logger.Log("Skipping generation of service: {0}, client {1}", configModel.ServiceNounPrefix, configModel.ServiceClientInterface);
                }
                Logger.Log(new string('<', 20));
                Logger.Log();
            }

            var awspowershellProjectFile = Path.Combine(OutputFolder, AWSPowerShellProjectFilename);
            var awspowershellModuleManifestFile = Path.Combine(OutputFolder, AWSPowerShellModuleManifestFilename);

            SourceArtifacts.UpdateProjectReferences(awspowershellProjectFile);
            SourceArtifacts.UpdateManifestRequiredAssemblies(awspowershellProjectFile, awspowershellModuleManifestFile);

            Console.WriteLine("...updating aliases file");
            var aliasSourceFile = Path.Combine(OutputFolder, AliasesFilename);
            using (var sw = new StreamWriter(aliasSourceFile, false, new System.Text.UTF8Encoding(false)))
            {
                sw.WriteLine(Aliases);
            }
        }

        #endregion

        #region Private client methods

        private void GenerateClientAndCmdlets(ConfigModel configModel)
        {
            // infer sdk service assembly name from the namespace and load the artifacts into the store
            // and in-progress properties
            var svcNamespaceParts = configModel.ServiceNamespace.Split('.');
            var svcAssemblyBasename = string.Concat("AWSSDK.", svcNamespaceParts[1]);

            Assembly svcAssembly;
            XmlDocument svcNdoc;
            SourceArtifacts.Load(svcAssemblyBasename, out svcAssembly, out svcNdoc);
            CurrentServiceAssembly = svcAssembly;
            CurrentServiceNDoc = svcNdoc;

            var clientInterfaceTypeName = string.Format("{0}.{1}", configModel.ServiceNamespace, configModel.ServiceClientInterface);
            var clientInterfaceType = CurrentServiceAssembly.GetType(clientInterfaceTypeName);
            if (clientInterfaceType == null)
            {
                Logger.LogError("Cannot find target client " + clientInterfaceTypeName);
                return;
            }

            TempOutputDir = Path.Combine(Path.GetTempPath(), "PSCmdletGen");
            SetupOutputDir(configModel.SourceGenerationFolder);

            var clientCmdletFilePath = string.Format(@"{0}\ClientCmdlet.cs", configModel.SourceGenerationFolder);
            if (!File.Exists(Path.Combine(TempOutputDir, clientCmdletFilePath)))
            {
                Logger.Log("Adding new client {0} to csproj file", clientCmdletFilePath);
                AddToCreatedFiles(Path.Combine(@"Cmdlets\", clientCmdletFilePath));
            }

            using (var sw = new StringWriter())
            {
                using (var writer = new IndentedTextWriter(sw))
                {
                    CmdletServiceClientWriter.Write(writer, 
                                                    CurrentModel, 
                                                    ModelCollection.ClientNameMappings[configModel.ServiceNounPrefix], 
                                                    GetServiceVersion(configModel.ServiceNamespace, configModel.ServiceClient));
                }

                var fileContents = sw.ToString();
                File.WriteAllText(Path.Combine(TempOutputDir, clientCmdletFilePath), fileContents);
            }

            var methods = clientInterfaceType.GetMethods();
            foreach (var method in methods.Where(ShouldEmitMethod))
            {
                CreateCmdlet(method, configModel);
            }

            // fuse the manually-declared custom aliases with the automatic set
            foreach (var cmdletKey in configModel.CustomAliases.Keys)
            {
                AliasStore.Instance.AddAliases(cmdletKey, configModel.CustomAliases[cmdletKey]);
            }

            CopyGeneratedCmdlets(Path.Combine(TempOutputDir, configModel.SourceGenerationFolder),
                                 Path.Combine(CmdletsOutputPath, configModel.SourceGenerationFolder));
        }

        // the set of subfolders in the final output directory for a service that will
        // not be erased when we copy over the generated content
        private static readonly HashSet<string> FoldersToIgnore = new HashSet<string>
        {
            "Advanced\\", "Model\\", ".svn\\"
        };

        private void CopyGeneratedCmdlets(string fromDir, string toDir)
        {
            fromDir = EnsureTrailingSlash(Path.GetFullPath(fromDir));
            toDir = EnsureTrailingSlash(Path.GetFullPath(toDir));

            // as a helper to devs, if the target folder doesn't exist, create it and the 
            // 'basic' subfolder where generated cmdlets are placed (note that devs are 
            // responsible for cleanup if they get the service name wrong!)
            if (!Directory.Exists(toDir))
            {
                Console.WriteLine("...creating folder hierarchy for service output at {0}", toDir);

                Directory.CreateDirectory(toDir);
                Directory.CreateDirectory(Path.Combine(toDir, GeneratedCmdletsFoldername));
            }

            var fromFiles = Directory.EnumerateFiles(fromDir, "*", SearchOption.AllDirectories)
                .Select(Path.GetFullPath)
                .ToList();
            var fromMap = fromFiles
                .ToDictionary(f => ToRelativePath(fromDir, f), f => f)
                .Where(t => !(FoldersToIgnore.Any(i => t.Key.Contains(i))))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var toFiles = Directory.EnumerateFiles(toDir, "*", SearchOption.AllDirectories)
                .Select(Path.GetFullPath)
                .ToList();
            var toMap = toFiles
                .ToDictionary(f => ToRelativePath(toDir, f), f => f)
                .Where(t => !(FoldersToIgnore.Any(i => t.Key.Contains(i))))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            // remove files that are in toDir but aren't in fromDir
            foreach (var kvp in toMap)
            {
                var to = kvp.Key;
                var toAbsolute = kvp.Value;

                string fromFull;
                if (!fromMap.TryGetValue(to, out fromFull))
                {
                    File.Delete(toAbsolute);
                }
            }

            // copy all files from fromDir
            foreach (var kvp in fromMap)
            {
                var from = kvp.Key;
                var fromAbsolute = kvp.Value;
                var toAbsolute = Path.Combine(toDir, from);
                File.Copy(fromAbsolute, toAbsolute, true);
            }
        }

        private static string EnsureTrailingSlash(string path)
        {
            return (path.EndsWith("\\") ? path : path + "\\");
        }

        private string ToRelativePath(string fromPath, string toPath)
        {
            if (string.IsNullOrEmpty(fromPath))
            {
                Logger.LogError("fromPath is null or empty");
                return null;
            }
            if (string.IsNullOrEmpty(toPath))
            {
                Logger.LogError("toPath is null or empty");
                return null;
            }

            var fromUri = new Uri(fromPath);
            var toUri = new Uri(toPath);

            var relativeUri = fromUri.MakeRelativeUri(toUri);
            var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            return relativePath.Replace('/', Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Extract the underlying service api version from the service's configuration class in the SDK
        /// </summary>
        /// <param name="clientNamespace"></param>
        /// <param name="clientName"></param>
        /// <returns></returns>
        private string GetServiceVersion(string clientNamespace, string clientName)
        {
            string version = null;
            var configClassPrefix = clientName.EndsWith("Client", StringComparison.Ordinal) ? clientName.Substring(0, clientName.Length - 6) : clientName;
            var configType = CurrentServiceAssembly.GetType(string.Format("{0}.{1}Config", clientNamespace, configClassPrefix));
            if (configType != null && configType.GetConstructor(System.Type.EmptyTypes) != null)
            {
                var config = Activator.CreateInstance(configType, null);
                var property = configType.GetProperty("ServiceVersion");
                if (property != null)
                {
                    version = property.GetValue(config, null) as string;
                }
            }
            if (string.IsNullOrEmpty(version))
                Logger.LogError("Unable to retrieve version for client " + clientName + " (" + string.Format("{0}.{1}Config", clientNamespace, configClassPrefix) + ")");
            return version;
        }

        #endregion

        #region Private cmdlet methods

        /// <summary>
        /// Analyzes the supplied method to determine the cmdlet that should be generated
        /// and the inputs/outputs for the cmdlet. Once analysis is complete, the cmdlet
        /// source file will be generated.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="configModel"></param>
        private void CreateCmdlet(MethodInfo method, ConfigModel configModel)
        {
            Logger.Log();
            Logger.Log("Analyzing method [{0}.{1}]", method.DeclaringType.FullName, method.Name);

            var methodName = method.Name;

            // operation config
            var serviceOperation = configModel.ServiceOperations[methodName];
            CurrentOperation = serviceOperation;

            var analyzer = new OperationAnalyzer(Options.AnalysisLog)
            {
                AllModels = ModelCollection,
                CurrentModel = CurrentModel,
                CurrentOperation = CurrentOperation,
                Logger = Logger,
                AssemblyDocumentation = CurrentServiceNDoc
            };

            analyzer.Analyze(this, method);

            // set file name and location
            var filePath = string.Format(@"{0}\Basic\{1}-{2}-Cmdlet.cs",
                                         configModel.SourceGenerationFolder,
                                         serviceOperation.SelectedVerb,
                                         serviceOperation.SelectedNoun);
            AddToCreatedFiles(Path.Combine(@"Cmdlets\", filePath));

            using (var sw = new StringWriter())
            {
                using (var writer = new IndentedTextWriter(sw))
                {
                    WriteCmdlet(writer, analyzer);
                }

                var fileContents = sw.ToString();
                File.WriteAllText(Path.Combine(TempOutputDir, filePath), fileContents);
            }

            AliasStore.Instance.AddAlias(string.Format("{0}-{1}", serviceOperation.SelectedVerb, serviceOperation.SelectedNoun),
                                         string.Format("{0}-{1}", configModel.ServiceNounPrefix, methodName));

            Logger.Log(">>>> Created cmdlet {0}-{1} for operation {2}",
                       serviceOperation.SelectedVerb,
                       serviceOperation.SelectedNoun,
                       methodName);
            Logger.Log();
        }

        /// <summary>
        /// Generates the source code for a cmdlet following inspection of the service operation.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        private void WriteCmdlet(IndentedTextWriter writer, OperationAnalyzer analyzer)
        {
            var currentModel = analyzer.CurrentModel;

            string serviceDisplayName;
            if (!ModelCollection.ClientNameMappings.TryGetValue(currentModel.ServiceNounPrefix, out serviceDisplayName))
            {
                Logger.LogError("Cannot find display name for service " + currentModel.ServiceNounPrefix);
                return;
            }

            if (analyzer.GenerateIterationCode)
            {
                var methodName = analyzer.Method.Name;
                var currentOperation = analyzer.CurrentOperation;
                var analyzedResult = analyzer.AnalyzedResult;

                Logger.Log("Method {0} (cmdlet {1}-{2}) assessed for iteration pattern '{3}'",
                           methodName,
                           currentOperation.SelectedVerb,
                           currentOperation.SelectedNoun,
                           Enum.GetName(typeof(AutoIteration.AutoIteratePattern), analyzer.IterationPattern));

                if (analyzedResult.SingleResultProperty == null)
                {
                    Logger.LogError("Method {0} is configured to produce iteration code, but SingleResultProperty is null (there are multiple properties being returned). This operation may need to be added to itrExclusions for the service.",
                                    methodName);
                    return;
                }
            }

            var cmdletWriter = new CmdletSourceWriter(analyzer, serviceDisplayName, Options);
            cmdletWriter.Write(writer);
        }

        private bool ShouldEmitMethod(MethodInfo method)
        {
            // note that this picks up async BeingXXX/EndXXX methods , don't want to error on those; if a service
            // implements an operation that uses these prefixes the SDK will break, so seems safe to inspect on
            // StartsWith basis
            if (method.Name.StartsWith("Begin") || method.Name.StartsWith("End"))
                return false;

            if (CurrentModel.ServiceOperations.ContainsKey(method.Name))
            {
                if (CurrentModel.ServiceOperations[method.Name].Exclude)
                    return false;

                // we're looking for methods that have a single parameter that is
                // derived from the AmazonWebServiceRequest type -- all other methods
                // are convenience overloads
                var parameters = method.GetParameters();
                return (parameters.Count() == 1 && parameters[0].ParameterType.IsSubclassOf(SdkBaseRequestType));
            }

            Logger.LogError("Method name {0} has no corresponding ServiceOperation definition in the current model {1}, INVESTIGATE", method.Name, CurrentModel.ServiceNamespace);
            return false; // not sure if we shouldn't throw instead
        }

        #endregion


        #region Misc/config methods

        /// <summary>
        /// Creates the generated output folder for the service, cleaning any existing
        /// generated content if the folder existed.
        /// </summary>
        /// <param name="sourceRoot"></param>
        private void SetupOutputDir(string sourceRoot)
        {
            // create root output dir
            if (!Directory.Exists(TempOutputDir))
                Directory.CreateDirectory(TempOutputDir);

            // create client output dir
            string clientDir = Path.Combine(TempOutputDir, sourceRoot);
            if (!Directory.Exists(clientDir))
                Directory.CreateDirectory(clientDir);

            string autoOutDir = Path.Combine(TempOutputDir, string.Format(@"{0}\Basic\", sourceRoot));
            if (!Directory.Exists(autoOutDir))
                Directory.CreateDirectory(autoOutDir);

            // clear client's auto-generated output dir
            foreach (var file in Directory.GetFiles(autoOutDir, "*", SearchOption.AllDirectories))
            {
                File.Delete(file);
            }
            foreach (var dir in Directory.GetDirectories(autoOutDir))
            {
                Directory.Delete(dir);
            }
        }

        private void AddToCreatedFiles(string filePath)
        {
            if (CurrentModel.CreatedFiles.Contains(filePath, StringComparer.OrdinalIgnoreCase))
                Logger.LogError("Same file created twice: " + filePath);
            CurrentModel.CreatedFiles.Add(filePath);
        }

        /// <summary>
        /// Loads the core runtime sdk assembly and ndoc
        /// </summary>
        private void LoadCoreSDKRuntimeMaterials()
        {
            Assembly coreRuntimeAssembly;
            XmlDocument coreRuntimeNDoc;

            SourceArtifacts.Load(CoreSDKRuntimeAssemblyName, out coreRuntimeAssembly, out coreRuntimeNDoc);
            SdkBaseRequestType = coreRuntimeAssembly.GetType("Amazon.Runtime.AmazonWebServiceRequest");
        }

        #endregion
    }
}
