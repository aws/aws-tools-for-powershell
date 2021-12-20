using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Utils;
using AWSPowerShellGenerator.Writers;
using AWSPowerShellGenerator.Writers.SourceCode;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace AWSPowerShellGenerator.Generators
{
    public abstract class Generator
    {
        internal BasicLogger Logger { get; private set; }

        public string OutputFolder { get; set; }

        public GeneratorOptions Options { get; set; }

        protected readonly StringBuilder _argumentCompletionScript = new StringBuilder();

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
            Logger = new BasicLogger(Options.Verbose);

            try
            {
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
        /// Contains the legacy aliases we encounter on service operations, to be
        /// emitted into the AWSPowerShellLegacyAliases.psm1 nested module.
        /// Outer key is the service name.
        /// In the inner dictionary, key is the alias and value is the true cmdlet
        /// name it maps to.
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, string>> LegacyAliases
            = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

        public static string ConfigurationFolderName => Path.Combine("generator", "AWSPSGeneratorLib", "Config");

        public static string ServiceConfigFoldername = "ServiceConfig";

        /// <summary>
        /// For use in the new generator, the current one emits json versions of the configs here
        /// </summary>
        public static string CmdletJsonConfigurationsFoldername => Path.Combine("generator", "AWSPSGeneratorLib", "ServiceConfig.json");

        public const string CmdletsOutputSubFoldername = "Cmdlets";
        public const string ArgumentCompletersSubFoldername = "ArgumentCompleters";
        public const string ArgumentCompleterScriptFileSuffix = "ArgumentCompleters.ps1";
        public const string GeneratedCmdletsFoldername = "Basic";

        public string Aliases
        {
            get
            {
                return AliasStore.Instance.Serialize();
            }
        }

        /// <summary>
        /// Returns the argument completer script ready for persisting into a script file.
        /// </summary>
        /// <returns></returns>
        public string GetArgumentCompletionScriptContent()
        {
            return _argumentCompletionScript.ToString();
        }

        public void AddLegacyAlias(string cmdletName, string aliasName)
        {
            if (LegacyAliases.TryGetValue(CurrentModel.AssemblyName, out var aliases))
            {
                if (aliases.TryGetValue(aliasName, out var existingCmdletName))
                {
                    AnalysisError.DuplicatedLegacyAlias(CurrentModel, aliasName, cmdletName, existingCmdletName);
                    return;
                }
            }
            else
            {
                aliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                LegacyAliases.Add(CurrentModel.AssemblyName, aliases);
            }
            aliases.Add(aliasName, cmdletName);
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
        const string AsyncSuffix = "Async";

        private ConfigModelCollection ModelCollection { get; set; }

        /// <summary>
        /// The path to the folder that will contain the generated cmdlets,
        /// organized into per-service subfolders.
        /// </summary>
        private string CmdletsOutputPath { get; set; }

        private readonly Dictionary<string, AdvancedCmdletInfo> CommonAdvancedCmdlets = new Dictionary<string, AdvancedCmdletInfo>();

        private Assembly CoreRuntimeAssembly;

        #endregion

        #region Public methods

        protected override void GenerateHelper()
        {
            CmdletsOutputPath = Path.Combine(OutputFolder, CmdletsOutputSubFoldername);
            var configurationsFolder = Path.Combine(Options.RootPath, ConfigurationFolderName);
            var serviceConfigurationsFolder = Path.Combine(configurationsFolder, ServiceConfigFoldername);

            XmlOverridesMerger.ApplyOverrides(Options.RootPath, serviceConfigurationsFolder);

            ModelCollection = ConfigModelCollection.LoadAllConfigs(configurationsFolder, Options.Verbose);

            SourceArtifacts = new GenerationSources(OutputFolder, SdkAssembliesFolder, Options.VersionNumber);
            LoadCoreSDKRuntimeMaterials();
            LoadSpecialServiceAssemblies();

            CheckForServicePrefixDuplication();

            if (!Options.SkipCmdletGeneration)
            {
                //We clean and setup service folders, some services share a folder, project and module, so we use distinct
                foreach (var project in ModelCollection.ConfigModels.Values
                    .Where(service => !service.SkipCmdletGeneration)
                    .GroupBy(folder => folder.AssemblyName))
                {
                    var modelsWithGuid = project.Where(model => !string.IsNullOrWhiteSpace(model.ServiceModuleGuid));
                    if (modelsWithGuid.Count() > 1)
                    {
                        AnalysisError.DuplicatedAssemblyName(modelsWithGuid);
                    }

                    SetupOutputDir(project.Key);
                }
            }
            
            foreach (var configModel in ModelCollection.ConfigModels.Values)
            {
                // hold some state to model under work so we can make use of
                // static helpers
                CurrentModel = configModel;

                try
                {
                    Logger.Log("=======================================================");
                    Logger.Log("Processing service: {0}", CurrentModel.ServiceName);

                    LoadCurrentService(CurrentModel);

                    if (!Options.SkipCmdletGeneration)
                    {
                        GenerateClientAndCmdlets();
                        // if the service contains any hand-maintained cmdlets, scan them to update the
                        // argument completers for any use of ConstantClass-derived types 
                        ScanAdvancedCmdletsForServices();
                        GenerateArgumentCompleters();
                        ProcessLegacyAliasesForCustomCmdlets();

                        CheckForCmdletNameDuplication();
                    }
                }
                catch (Exception e)
                {
                    AnalysisError.ExceptionWhileGeneratingForService(CurrentModel, e);
                }
            }

            var allFoundSdkAssemblies = GenerationSources.SDKFindAssemblyFilenames(SdkAssembliesFolder, Directory.EnumerateFiles);
            VerifyAllAssembliesHaveConfiguration(SdkVersionsUtils.ReadSdkVersionFile(SdkAssembliesFolder), ModelCollection, allFoundSdkAssemblies);

            if (!Options.SkipCmdletGeneration)
            {
                ScanAdvancedCmdletsForCommonModule();

                SourceArtifacts.WriteLegacyAliasesFile(LegacyAliases, ModelCollection.CommonModuleAliases);
                SourceArtifacts.WriteMonolithicCompletionScriptsFile(GetArgumentCompletionScriptContent());
                SourceArtifacts.WriteMonolithicProjectFile();
                SourceArtifacts.WriteMonolithicModuleFiles();
                SourceArtifacts.WriteAdditionalAliasesFiles(Aliases);

                SourceArtifacts.WriteModularSolution(ModelCollection.ConfigModels.Values);
                SourceArtifacts.WriteCopyModularArtifactsScript(ModelCollection.ConfigModels.Values);

                SourceArtifacts.WriteCmdletsList(ModelCollection.ConfigModels.Values);
                SourceArtifacts.WriteCommonModule(CommonAdvancedCmdlets.Keys, ModelCollection.CommonModuleAliases);
                SourceArtifacts.WriteCommonProjectFile();
                SourceArtifacts.WriteLegacyAliasesFileForCommonModule(ModelCollection.CommonModuleAliases);
                SourceArtifacts.WriteCommonCompletionScriptsFile();
                SourceArtifacts.WriteCommonModuleCmdletsList(ModelCollection.ConfigModels.Values);

                SourceArtifacts.WriteModularProjectFiles(ModelCollection.ConfigModels.Values);
                SourceArtifacts.WriteLegacyAliasesModularFiles(LegacyAliases, ModelCollection.ConfigModels.Values);
                SourceArtifacts.WriteCompletersModularFiles(ModelCollection.ConfigModels.Values);
                SourceArtifacts.WriteModularManifestFiles(ModelCollection.ConfigModels.Values, LegacyAliases);

                SourceArtifacts.WriteVersionFile();

                WriteConfigurationChanges();
            }

            foreach (var configModel in ModelCollection.ConfigModels.Values)
            {
                foreach (var error in configModel.AnalysisErrors.Concat(
                      configModel.ServiceOperationsList
                          .OrderBy(so => so.MethodName)
                          .SelectMany(operation => operation.AnalysisErrors)))
                {
                    Logger.LogError(error.ToString());
                }
            }
        }

        /// <summary>
        /// Verifies that all services included in the SDK's _sdk-version.json either have a
        /// PowerShell configuration or were intentionally omitted. Also ensures there is a 
        /// configuration for not yet released services.
        /// </summary>
        /// <param name="sdkAssembliesFolder">location of the SDK assemblies to generate against</param>
        /// <param name="modelCollection">PowerShell configuration, assumes ConfigModels and IncludeLibrariesList have been fully instantiated</param>
        /// <param name="allSdkAssemblyFilenames">A list of all the SDK assembly filenames in the net45 and netstandard2.0 folders</param>
        public static void VerifyAllAssembliesHaveConfiguration(JObject sdkVersionsJson, 
            ConfigModelCollection modelCollection, 
            IEnumerable<string> allSdkAssemblyFilenames)
        {
            var intentionallySkippedModules = new HashSet<string>();
            var configuredAssemblies = new HashSet<string>();

            foreach (var module in modelCollection.IncludeLibrariesList)
            {
                intentionallySkippedModules.Add(module.Name);
            }
            foreach (var configuredService in modelCollection.ConfigModels.Values)
            {
                configuredAssemblies.Add(configuredService.AssemblyName);
            }

            var sdkAssembliesNoConfig = new List<string>();

            //Check to ensure we have an configuration for each SDK service in _sdk-version.json.
            foreach (var service in sdkVersionsJson["ServiceVersions"])
            {
                var assemblyName = ((JProperty)service).Name;

                if (!configuredAssemblies.Contains(assemblyName) && !intentionallySkippedModules.Contains("AWSSDK." + assemblyName))
                {
                    sdkAssembliesNoConfig.Add(assemblyName);
                }
            }

            //Check to ensure we have a configuration for any SDK service sitting in the assemblies
            //folder. New services are not in the _sdk-version.json until release.
            if(allSdkAssemblyFilenames != null)
            {
                sdkAssembliesNoConfig.AddRange(
                    allSdkAssemblyFilenames.Where(name => !configuredAssemblies.Contains(name) && !intentionallySkippedModules.Contains("AWSSDK." + name))
                );
            }            

            //Return all assemblies missing a XML configuration.
            if (sdkAssembliesNoConfig.Any())
            {
                throw new Exception($"Missing XML configuration for: {string.Join(", ", sdkAssembliesNoConfig)}");
            }
        }

#endregion

#region Private client methods

        private void WriteConfigurationChanges()
        {
            XmlReportWriter.SerializeReport(Options.RootPath, ModelCollection.ConfigModels.Values);
        }

        private void CheckForServicePrefixDuplication()
        {
            //We count the distinct service namespaces because DDB has two clients but a single namespace.
            var duplicatedPrefixes = ModelCollection.ConfigModels.Values
                .GroupBy(service => service.ServiceNounPrefix, StringComparer.InvariantCultureIgnoreCase)
                .Where(group => group.Select(service => service.ServiceNamespace).Distinct().Count() > 1);

            foreach (var group in duplicatedPrefixes)
            {
                foreach (var service in group)
                {
                    AnalysisError.DuplicatedServicePrefix(service, group);
                }
            }
        }

        private void CheckForCmdletNameDuplication()
        {
            var duplicatedCmdletNames = CurrentModel.ServiceOperationsList
                .Where(operation => !operation.Exclude)
                .GroupBy(operation => $"{operation.SelectedVerb}-{operation.SelectedNoun}", StringComparer.InvariantCultureIgnoreCase)
                .Where(group => group.Count() > 1);

            foreach (var group in duplicatedCmdletNames)
            {
                foreach (var operation in group)
                {
                    AnalysisError.DuplicatedCmdletName(CurrentModel, operation, group);
                }
            }

            var advancedCmdletConflicts = CurrentModel.ServiceOperationsList
                .Where(operation => CurrentModel.AdvancedCmdlets.ContainsKey($"{operation.SelectedVerb}-{operation.SelectedNoun}"));

            foreach (var operation in advancedCmdletConflicts)
            {
                AnalysisError.AdvancedCmdletNameConflict(CurrentModel, operation);
            }
        }

        private void LoadCurrentService(ConfigModel configModel)
        {
            // infer sdk service assembly name from the namespace and load the artifacts into the store
            // and in-progress properties. We do this even if the config requests we skip cmdlet
            // generation, as we want the assembly loaded so we can emit argument completers.
            (CurrentServiceAssembly, CurrentServiceNDoc, configModel.SDKDependencies) = SourceArtifacts.Load("AWSSDK." + configModel.AssemblyName);
            configModel.Assembly = CurrentServiceAssembly;
        }

        private void GenerateClientAndCmdlets()
        {
            if (CurrentModel.SkipCmdletGeneration)
            {
                Logger.Log("...skipping cmdlet generation, ExcludeCmdletGeneration set true for service");
                return;
            }

            Logger.Log("...generating cmdlets against interface '{0}'", CurrentModel.ServiceClientInterface);

            var clientInterfaceTypeName = string.Format("{0}.{1}", CurrentModel.ServiceNamespace, CurrentModel.ServiceClientInterface);
            var clientInterfaceType = CurrentServiceAssembly.GetType(clientInterfaceTypeName);
            if (clientInterfaceType == null)
            {
                Logger.LogError("Cannot find target client " + clientInterfaceTypeName);
                return;
            }

            var outputRoot = Path.Combine(CmdletsOutputPath, CurrentModel.AssemblyName);

            try
            {
                using (var sw = new StringWriter())
                {
                    // if the service has operations requiring anonymous access, we'll generate two clients
                    // one for regular authenticated calls and one using anonymous credentials
                    using (var writer = new IndentedTextWriter(sw))
                    {
                        CmdletServiceClientWriter.Write(writer,
                                                        CurrentModel,
                                                        CurrentModel.ServiceName,
                                                        GetServiceVersion(CurrentModel.ServiceNamespace, CurrentModel.ServiceClient));
                    }

                    var fileContents = sw.ToString();
                    var fileName = CurrentModel.GetServiceCmdletClassName(false) + "Cmdlet.cs";
                    File.WriteAllText(Path.Combine(outputRoot, fileName), fileContents);
                }
            }
            catch (Exception e)
            {
                AnalysisError.ExceptionWhileWritingServiceClientCode(CurrentModel, e);
            }

            // process the methods in order to make debugging more convenient
            var methods = clientInterfaceType.GetMethods().OrderBy(m => m.Name).ToList();
            foreach (var method in methods)
            {
                if (ShouldEmitMethod(method))
                {
                    CreateCmdlet(method, CurrentModel);
                    CurrentOperation.Processed = true;
                }
                else
                {
                    if (CurrentModel.ServiceOperations.TryGetValue(method.Name, out var so))
                    {
                        so.Processed = true;
                    }
                }
            }

            foreach (var operation in CurrentModel.ServiceOperationsList.Where(operation => !operation.Processed))
            {
                AnalysisError.MissingSDKMethodForCmdletConfiguration(CurrentModel, operation);
            }

            // fuse the manually-declared custom aliases with the automatic set to go into awsaliases.ps1 
            // note that this file is deprecated and likely to get yanked as no-one uses it
            foreach (var cmdletKey in CurrentModel.CustomAliases.Keys)
            {
                AliasStore.Instance.AddAliases(cmdletKey, CurrentModel.CustomAliases[cmdletKey]);
            }
        }

        public void GenerateArgumentCompleters()
        {
            Logger.Log("...generating argument completers");

            // emit argument completion scripts for constantclass-derived fake enums
            var completionFunctions = CompletersFileTemplate.Generate(CurrentModel);
            if (!string.IsNullOrWhiteSpace(completionFunctions))
                _argumentCompletionScript.Append(completionFunctions);
        }

        /// <summary>
        /// Add any legacy aliases for hand-maintained non-generatable cmdlets if so declared into
        /// collection that eventually ends up in AWSPowerShellLegacyAliases.psm1
        /// </summary>
        /// <param name="configModel"></param>
        public void ProcessLegacyAliasesForCustomCmdlets()
        {
            Logger.Log("...checking for legacy aliases for custom cmdlets");

            var legacyAliases = CurrentModel.LegacyAliases;
            if (legacyAliases != null)
            {
                foreach (var aliasDefinition in legacyAliases)
                {
                    // there really should only be one alias, but if we screw up the name of
                    // a cmdlet enough times there is a use case for multiple entries :-)
                    foreach (var aliasName in aliasDefinition.Value)
                    {
                        AddLegacyAlias(aliasDefinition.Key, aliasName);
                    }
                }
            }
        }

        /// <summary>
        /// Scans for any hand-maintained cmdlets. For now this is just to find usage of ConstantClass-derived
        /// types so that we can add them to the argument completers.
        /// </summary>
        /// <param name="outputRoot">The root output folder for the service being generated.</param>
        private void ScanAdvancedCmdletsForServices()
        {
            var outputRoot = Path.Combine(CmdletsOutputPath, CurrentModel.AssemblyName);

            var advancedCmdletsFolder = Path.Combine(outputRoot, "Advanced");
            if (!Directory.Exists(advancedCmdletsFolder))
                return;

            var sourceFiles = Directory.GetFiles(advancedCmdletsFolder, "*.cs");
            var scanner = new AdvancedCmdletScanner(CurrentServiceAssembly);
            foreach (var sourceFile in sourceFiles)
            {
                scanner.Scan(sourceFile, CurrentModel.AdvancedCmdlets, CurrentModel.ArgumentCompleters);
            }
        }

        private void ScanAdvancedCmdletsForCommonModule()
        {
            var commonFolder = Path.Combine(OutputFolder, "Common");

            var sourceFiles = Directory.GetFiles(commonFolder, "*.cs");
            var scanner = new AdvancedCmdletScanner(CoreRuntimeAssembly);
            foreach (var sourceFile in sourceFiles)
            {
                scanner.Scan(sourceFile, CommonAdvancedCmdlets);
            }
        }

        // the set of subfolders in the final output directory for a service that will
        // not be erased when we copy over the generated content
        private static readonly HashSet<string> FoldersToIgnore = new HashSet<string>
        {
            "Advanced" + Path.DirectorySeparatorChar, "Model" + Path.DirectorySeparatorChar, ".svn" +  + Path.DirectorySeparatorChar
        };

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

            // operation config
            var serviceOperation = configModel.ServiceOperations[method.Name];
            CurrentOperation = serviceOperation;

            try
            {
                // capture the analyzer so we can serialize the config as json later
                serviceOperation.Analyzer = new OperationAnalyzer(ModelCollection, CurrentModel, CurrentOperation, CurrentServiceNDoc);
                serviceOperation.Analyzer.Analyze(this, method);
            }
            catch (Exception e)
            {
                AnalysisError.ExceptionWhileAnalyzingSDKLibrary(CurrentModel, CurrentOperation, e);
            }

            if (serviceOperation.AnalysisErrors.Count == 0)
            {
                // set file name and location
                var filePath = Path.Combine(configModel.AssemblyName, GeneratedCmdletsFoldername, $"{serviceOperation.SelectedVerb}-{serviceOperation.SelectedNoun}-Cmdlet.cs");

                try
                {
                    using (var sw = new StringWriter())
                    {
                        using (var writer = new IndentedTextWriter(sw))
                        {
                            new CmdletSourceWriter(serviceOperation.Analyzer, Options).Write(writer);
                        }

                        var fileContents = sw.ToString();
                        File.WriteAllText(Path.Combine(CmdletsOutputPath, filePath), fileContents);
                    }
                }
                catch (Exception e)
                {
                    AnalysisError.ExceptionWhileWritingCmdletCode(CurrentModel, CurrentOperation, e);
                }

                if (!method.Name.EndsWith(AsyncSuffix))
                    throw new ArgumentException($"Method {method.Name} name doesn't end with suffix {AsyncSuffix}");

                string methodName = method.Name.Substring(0, method.Name.Length - AsyncSuffix.Length);

                AliasStore.Instance.AddAlias(string.Format("{0}-{1}", serviceOperation.SelectedVerb, serviceOperation.SelectedNoun),
                                             string.Format("{0}-{1}", configModel.ServiceNounPrefix, methodName));
            }
        }

        private bool ShouldEmitMethod(MethodInfo method)
        {
            if (!method.Name.EndsWith(AsyncSuffix))
                return false;

            string methodName = method.Name.Substring(0, method.Name.Length - AsyncSuffix.Length);


            // we're looking for methods that have a single parameter that is
            // derived from the AmazonWebServiceRequest type -- all other methods
            // are convenience overloads
            var parameters = method.GetParameters();
            if (parameters.Count() == 2 && parameters[0].ParameterType.IsSubclassOf(SdkBaseRequestType) && parameters[1].ParameterType == typeof(CancellationToken))
            {
                if (CurrentModel.ServiceOperations.ContainsKey(method.Name))
                {
                    return !CurrentModel.ServiceOperations[method.Name].Exclude;
                }
                else if (!Options.CreateNewCmdlets)
                {
                    return false;
                }
                else
                {
                    // unknown operation, so have a stab at what it should be
                    Logger.Log("Method {0} has no ServiceOperation defined in model {1}, auto-generating", methodName, CurrentModel.ServiceNamespace);
                    var serviceOperation = new ServiceOperation
                    {
                        MethodName = methodName,
                        IsAutoConfiguring = true
                    };
                    CurrentModel.ServiceOperationsList.Add(serviceOperation);
                    CurrentModel.ServiceOperations.Add(method.Name, serviceOperation);

                    if (Options.BreakOnNewOperations)
                    {
                        Logger.LogError("Method {0} has no ServiceOperation defined in model {1}", methodName, CurrentModel.ServiceNamespace);
                    }

                    return true;
                }
            }
                
            return false;
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
            var clientDir = Path.Combine(CmdletsOutputPath, sourceRoot);

            // create client output dir
            if (!Directory.Exists(clientDir))
                Directory.CreateDirectory(clientDir);

            string autoOutDir = Path.Combine(clientDir, GeneratedCmdletsFoldername);
            if (Directory.Exists(autoOutDir))
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        Directory.Delete(autoOutDir, true);
                    }
                    catch
                    {
                        if (i < 10)
                            continue;
                        throw;
                    }
                    break;
                }
            }
            while (Directory.Exists(autoOutDir))
            {
                Thread.Sleep(100);
            }
            Directory.CreateDirectory(autoOutDir);
        }

        /// <summary>
        /// Loads the core runtime sdk assembly and ndoc
        /// </summary>
        private void LoadCoreSDKRuntimeMaterials()
        {
            (CoreRuntimeAssembly, _, _) = SourceArtifacts.Load(CoreSDKRuntimeAssemblyName);
            SdkBaseRequestType = CoreRuntimeAssembly.GetType("Amazon.Runtime.AmazonWebServiceRequest");
        }

        /// <summary>
        /// Ensures we know of references to sdk service assemblies that the generator does
        /// not process cmdlets for, but for which cmdlets exist (as handwritten versions).
        /// This ensures we take the assemblies into account when updating project and manifest
        /// files etc.
        /// </summary>
        private void LoadSpecialServiceAssemblies()
        {
            foreach (var a in ModelCollection.IncludeLibrariesList)
            {
                SourceArtifacts.Load(a.Name, a.AddAsReference);
            }
        }

#endregion
    }
}
