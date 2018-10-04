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
using System.Text;

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
        public const string CmdletConfigurationsFoldername = @"generator\AWSPSGeneratorLib\CmdletConfig";

        /// <summary>
        /// For use in the new generator, the current one emits json versions of the configs here
        /// </summary>
        public const string CmdletJsonConfigurationsFoldername = @"generator\AWSPSGeneratorLib\CmdletConfig.json";

        public const string CmdletsOutputSubFoldername = "Cmdlets";
        public const string ArgumentCompletersSubFoldername = "ArgumentCompleters";
        public const string ArgumentCompleterScriptFileSuffix = "ArgumentCompleters.ps1";
        public const string GeneratedCmdletsFoldername = "Basic";

        public const string AWSPowerShellProjectFilename = "AWSPowerShell.csproj";

        public const string AWSPowerShellDesktopModuleManifestFilename = "AWSPowerShell.psd1";
        public const string AWSPowerShellNetCoreModuleManifestFilename = "AWSPowerShell.NetCore.psd1";

		public const string ArgumentCompleterScriptModuleFilename = "AWSPowerShellCompleters.psm1";

        // the legacy aliases file is where we rename cmdlets without incurring breaking changes;
        // the module is auto-loaded when our main module loads
        public const string LegacyAliasesScriptModuleFilename = "AWSPowerShellLegacyAliases.psm1";

        // this aliases file maps from service_opname to cmdletname; it's not the same as the legacy
        // aliases file and is not loaded by default
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

        StringBuilder _argumentCompletionScript = new StringBuilder();

        /// <summary>
        /// Appends a new block of scripts to the completers. This has been proven to be
        /// a faster approach than one-file-per-service;
        /// </summary>
        /// <param name="serviceName">The name of the 'owning' service; used for a comment delimiter</param>
        /// <param name="scriptContent">The set of completer functions to be added</param>
        public void AddArgumentCompletionScript(string serviceName, string scriptContent)
        {
            if (_argumentCompletionScript.Length > 0)
                _argumentCompletionScript.AppendLine();

            _argumentCompletionScript.AppendFormat("# Argument completions for service {0}", serviceName);
            _argumentCompletionScript.AppendLine();

            _argumentCompletionScript.Append(scriptContent);
            _argumentCompletionScript.AppendLine();
        }

        /// <summary>
        /// Returns the argument completer script ready for persisting into a script file.
        /// </summary>
        /// <returns></returns>
        public string GetArgumentCompletionScriptContent()
        {
            return _argumentCompletionScript.ToString();
        }

        /// <summary>
        /// Contains the legacy aliases we encounter on service operations, to be
        /// emitted into the AWSPowerShellLegacyAliases.psm1 nested module.
        /// Outer key is the service name.
        /// In the inner dictionary, key is the alias and value is the true cmdlet
        /// name it maps to.
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, string>> _legacyAliases
            = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

        public void AddLegacyAlias(string serviceName, string cmdletName, string aliasName)
        {
            Dictionary<string, string> aliases;
            if (_legacyAliases.ContainsKey(serviceName))
                aliases = _legacyAliases[serviceName];
            else
            {
                aliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                _legacyAliases.Add(serviceName, aliases);
            }

            if (aliases.ContainsKey(aliasName))
                throw new ArgumentException(string.Format("Legacy alias '{0}' has been added already, mapped to '{1}' for service {2}", aliasName, cmdletName, serviceName));

            aliases.Add(aliasName, cmdletName);
        }

        /// <summary>
        /// Returns just the names of the legacy aliases, sorted, for use in the
        /// ExportedAliases property in the manifest
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetLegacyAliasNames()
        {
            var ret = new List<string>();

            ret.AddRange(_legacyShellConfigurationAliases.Keys);

            foreach (var serviceName in _legacyAliases.Keys)
            {
                var serviceAliases = _legacyAliases[serviceName];
                ret.AddRange(serviceAliases.Keys);
            }

            ret.Sort();
            return ret;
        }

        /// <summary>
        /// Returns the ordered set of Set-Alias commands to install our legacy
        /// aliases into the current shell when our main module loads.
        /// </summary>
        /// <returns></returns>
        public string GetLegacyAliasesFileContent()
        {
            var sb = new StringBuilder();

            sb.AppendLine("# Shell Configuration");
            var shellAliases = _legacyShellConfigurationAliases.Keys.ToList();
            shellAliases.Sort();
            foreach (var sa in shellAliases)
            {
                sb.AppendLine(string.Format("Set-Alias -Name {0} -Value {1}", sa, _legacyShellConfigurationAliases[sa]));
            }

            var serviceNames = _legacyAliases.Keys.ToList();
            serviceNames.Sort();

            foreach (var serviceName in serviceNames)
            {
                sb.AppendLine();

                sb.AppendLine(string.Format("# {0}", serviceName));

                var serviceAliases = _legacyAliases[serviceName];
                var serviceAliasNames = serviceAliases.Keys.ToList();
                serviceAliasNames.Sort();

                foreach (var aliasName in serviceAliasNames)
                {
                    sb.AppendLine(string.Format("Set-Alias -Name {0} -Value {1}", aliasName, serviceAliases[aliasName]));
                }
            }

            // Must export the aliases in this nested submodule for users on PSv3 or v4. If we don't,
            // the aliases will not be present afterward even though we have expliclty listed them in
            // the main module manifest. PS v5+ seems to have scoping changes that make this unnecessary,
            // but harmless.
            sb.AppendLine("Export-ModuleMember -Alias *");

            return sb.ToString();
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

        // new names and legacy aliases for the shell config cmdlets that we shipped
        // with plural names in earlier versions
        private readonly Dictionary<string, string> _legacyShellConfigurationAliases 
            = new Dictionary<string, string>
        {
            { "Set-AWSCredentials",     "Set-AWSCredential"                     },
            { "New-AWSCredentials",     "New-AWSCredential"                     },
            { "Clear-AWSCredentials",   "Clear-AWSCredential"                   },
            { "Get-AWSCredentials",     "Get-AWSCredential"                     },
            { "Initialize-AWSDefaults", "Initialize-AWSDefaultConfiguration"    },
            { "Clear-AWSDefaults",      "Clear-AWSDefaultConfiguration"         }
        };

        #endregion

        #region Public methods

        protected override void GenerateHelper()
        {
            SourceArtifacts = new GenerationSources { SdkAssembliesFolder = this.SdkAssembliesFolder };
            LoadCoreSDKRuntimeMaterials();
            LoadSpecialServiceAssemblies();

            CmdletsOutputPath = Path.Combine(OutputFolder, CmdletsOutputSubFoldername);
            var configurationsFolder = Path.Combine(Options.RootPath, CmdletConfigurationsFoldername);

            ModelCollection = ConfigModelCollection.LoadAllConfigs(configurationsFolder, Options.Verbose);

            foreach (var configModel in ModelCollection.ConfigModels)
            {
                Logger.Log();
                Logger.Log(new string('>', 20));
                if (Options.Services == null
                        || (Options.Services.Length != 0
                                && Options.Services.Contains(configModel.ServiceNounPrefix, StringComparer.InvariantCultureIgnoreCase)))
                {
                    if (Options.SkipCmdletGeneration)
                    {
#if DEBUG
                        configModel.SkipCmdletGeneration = true;
#else
                        Logger.LogError("SkipCmdletGeneration is supported only in Debug builds");
                        return;
#endif
                    }

                    // hold some state to model under work so we can make use of
                    // static helpers
                    CurrentModel = configModel;

                    Logger.Log("=======================================================");
                    Logger.Log("Processing service: {0}", CurrentModel.ServiceName);

                    GenerateClientAndCmdlets(CurrentModel);
                    GenerateArgumentCompleters(CurrentModel);
                    ProcessLegacyAliasesForCustomCmdlets(CurrentModel);

                    if (CurrentModel.ModelUpdated)
                    {
                        // for browsing convenience re-order the operations in case this was an existing service we 
                        // added new operations to
                        CurrentModel.ServiceOperationsList = CurrentModel.ServiceOperationsList.OrderBy(so => so.MethodName).ToList();
                        CurrentModel.Serialize(configurationsFolder);
                    }

                    // always serialize the json format, so we have reliable test data to work
                    // on in the new ps generator
                    new JsonPSConfigWriter(configModel, Options.RootPath, Logger).Serialize();

                    if (!Options.BreakOnOutputMismatchError)
                    {
                        Console.WriteLine("Completed processing for {0}", CurrentModel.ServiceName);
                        if (!CurrentModel.SkipCmdletGeneration)
                        {
                            Console.WriteLine("    Cmdlets generated for prefix: {0}", CurrentModel.ServiceNounPrefix);
                            Console.WriteLine("    Single-property result operations: {0}", string.Join(", ", CurrentModel.SinglePropertyResultOperations));
                            Console.WriteLine("    Multi-property result operations: {0}", string.Join(", ", CurrentModel.MultiPropertyResultOperations));
                            Console.WriteLine("    Empty result operations: {0}", string.Join(", ", CurrentModel.EmptyResultOperations));
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Logger.Log("Skipping generation of service: {0}, client {1}", configModel.ServiceNounPrefix, configModel.ServiceClientInterface);
                }

                Logger.Log(new string('<', 20));
                Logger.Log();
            }

            SourceArtifacts.UpdateReferencesAndExports(OutputFolder, GetLegacyAliasNames());

            Console.WriteLine("...updating script completers module");
            var argumentCompleterScriptModuleFile = Path.Combine(OutputFolder, ArgumentCompleterScriptModuleFilename);
            SourceArtifacts.WriteCompletionScriptsFile(argumentCompleterScriptModuleFile, GetArgumentCompletionScriptContent());

            Console.WriteLine("...updating legacy aliases module");
            var legacyAliasesScriptModuleFile = Path.Combine(OutputFolder, LegacyAliasesScriptModuleFilename);
            SourceArtifacts.WriteLegacyAliasesFile(legacyAliasesScriptModuleFile, GetLegacyAliasesFileContent());

            Console.WriteLine("...updating service_operation -> cmdlet name aliases file");
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
            // and in-progress properties. We do this even if the config requests we skip cmdlet
            // generation, as we want the assembly loaded so we can emit argument completers.
            var svcNamespaceParts = configModel.ServiceNamespace.Split('.');
            var svcAssemblyBasename = string.Concat("AWSSDK.", svcNamespaceParts[1]);

            Assembly svcAssembly;
            XmlDocument svcNdoc;
            SourceArtifacts.Load(svcAssemblyBasename, out svcAssembly, out svcNdoc);
            CurrentServiceAssembly = svcAssembly;
            CurrentServiceNDoc = svcNdoc;

            if (configModel.SkipCmdletGeneration)
            {
                Logger.Log("...skipping cmdlet generation, ExcludeCmdletGeneration set true for service");
                return;
            }

            Logger.Log("...generating cmdlets against interface '{0}'", CurrentModel.ServiceClientInterface);

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
                // if the service has operations requiring anonymous access, we'll generate two clients
                // one for regular authenticated calls and one using anonymous credentials
                using (var writer = new IndentedTextWriter(sw))
                {
                    CmdletServiceClientWriter.Write(writer, 
                                                    CurrentModel, 
                                                    CurrentModel.ServiceName, 
                                                    GetServiceVersion(configModel.ServiceNamespace, configModel.ServiceClient));
                }

                var fileContents = sw.ToString();
                File.WriteAllText(Path.Combine(TempOutputDir, clientCmdletFilePath), fileContents);
            }

            // process the methods in order to make debugging more convenient
            var methods = clientInterfaceType.GetMethods().OrderBy(m => m.Name).ToList();
            foreach (var method in methods)
            {
                if (ShouldEmitMethod(method))
                    CreateCmdlet(method, configModel);
                else
                {
                    ServiceOperation so;
                    if (configModel.ServiceOperations.TryGetValue(method.Name, out so))
                        so.Processed = true;
                }
            }

            foreach (var so in configModel.ServiceOperationsList)
            {
                if (so.Processed)
                    continue;

                if (Options.BreakOnUnknownOperationError)
                {
                    Logger.LogError("{0}: no SDK client method found for ServiceOperation {1}", configModel.ServiceName, so.MethodName);
                }
                else
                {
                    Logger.Log("Warning - {0}: no SDK client method found for ServiceOperation {1}. Skipping as BreakOnUnknownOperationError set false.",
                                configModel.ServiceName, 
                                so.MethodName);
                }
            }

            // fuse the manually-declared custom aliases with the automatic set to go into awsaliases.ps1 
            // note that this file is deprecated and likely to get yanked as no-one uses it
            foreach (var cmdletKey in configModel.CustomAliases.Keys)
            {
                AliasStore.Instance.AddAliases(cmdletKey, configModel.CustomAliases[cmdletKey]);
            }

            var outputRoot = Path.Combine(CmdletsOutputPath, configModel.SourceGenerationFolder);
            CopyGeneratedCmdlets(Path.Combine(TempOutputDir, configModel.SourceGenerationFolder), outputRoot);
        }

        public void GenerateArgumentCompleters(ConfigModel configModel)
        {
            Logger.Log("...generating argument completers");

            var outputRoot = Path.Combine(CmdletsOutputPath, configModel.SourceGenerationFolder);

            // if the service contains any hand-maintained cmdlets, scan them to update the
            // argument completers for any use of ConstantClass-derived types 
            ScanAdvancedCmdlets(outputRoot);

            // emit argument completion scripts for constantclass-derived fake enums
            var completionFunctions = GenerateArgumentCompleterScriptFunctions(configModel);
            if (!string.IsNullOrEmpty(completionFunctions))
                AddArgumentCompletionScript(configModel.ServiceName, completionFunctions);
        }

        /// <summary>
        /// Add any legacy aliases for hand-maintained non-generatable cmdlets if so declared into
        /// collection that eventually ends up in AWSPowerShellLegacyAliases.psm1
        /// </summary>
        /// <param name="configModel"></param>
        public void ProcessLegacyAliasesForCustomCmdlets(ConfigModel configModel)
        {
            Logger.Log("...checking for legacy aliases for custom cmdlets");

            var legacyAliases = configModel.LegacyAliases;
            if (legacyAliases != null)
            {
                foreach (var cmdletName in legacyAliases.Keys)
                {
                    var aliases = legacyAliases[cmdletName];
                    // there really should only be one alias, but if we screw up the name of
                    // a cmdlet enough times there is a use case for multiple entries :-)
                    foreach (var alias in aliases)
                    {
                        AddLegacyAlias(configModel.ServiceName, cmdletName, alias);
                    }
                }
            }
        }

        /// <summary>
        /// If the service's cmdlets made use of any ConstantClass-derived 'enum' types, generate
        /// argument completers that will display when the user types the parameter name (ISE)
        /// or presses the tab key (console). This gives us ValidateSet-style intellisense without
        /// the value validation. If a completer script is generated, the filename for the script
        /// is returned.
        /// </summary>
        /// <param name="configModel"></param>
        /// <returns>The generated script content, if any</returns>
        private string GenerateArgumentCompleterScriptFunctions(ConfigModel configModel)
        {
            if (!configModel.ArgumentCompleters.GenerateCompleters)
                return null;

            // Used to re-order the final map that we register, alpha order by parameter name.
            // We could do this with a second iteration of the registered completers by type,
            // but we'd still need to reorder by parameter so easier to process as we go.       
            var param2CmdletsMap = new SortedDictionary<string, List<string>>();
            string scriptContent = null;

            using (var sw = new StringWriter())
            {
                using (var writer = new IndentedTextWriter(sw))
                {
                    var functionName = string.Format("${0}_Completers", configModel.ServiceNounPrefix);
                    writer.WriteLine("{0} = {{", functionName);
                    writer.IncreaseIndent();
                    writer.WriteLine("param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)");
                    writer.WriteLine();

                    writer.WriteLine("switch ($(\"$commandName/$parameterName\"))");
                    writer.OpenRegion();

                    foreach (var rc in configModel.ArgumentCompleters.ReferencedClasses)
                    {
                        writer.WriteLine("# {0}", rc);

                        var usage = configModel.ArgumentCompleters.GetReferencesFor(rc);
                        var parameterNames = usage.ParameterNames;

                        // a ConstantClass-type can be referenced by multiple cmdlets using multiple
                        // parameter names. In this scenario we need to wrap the 'case' clause inside
                        // the switch in an expression.
                        var matchExpressions = new List<string>();

                        foreach (var p in parameterNames)
                        {
                            var cmdlets = usage.GetCmdletReferences(p);
                            foreach (var c in cmdlets)
                            {
                                matchExpressions.Add(string.Format("{0}/{1}", c, p));
                            }

                            if (param2CmdletsMap.ContainsKey(p))
                                param2CmdletsMap[p].AddRange(cmdlets);
                            else
                            {
                                var l = new List<string>(cmdlets);
                                param2CmdletsMap.Add(p, l);
                            }
                        }

                        var numExpressions = matchExpressions.Count();
                        if (numExpressions > 1)
                        {
                            var lastExpressionIndex = numExpressions - 1;
                            writer.OpenRegion();
                            for (var i = 0; i < numExpressions; i++)
                            {
                                writer.WriteLine("($_ -eq \"{0}\"){1}",
                                                 matchExpressions[i], 
                                                 i < lastExpressionIndex ? " -Or" : "");
                            }
                            writer.CloseRegion();
                        }
                        else
                            writer.WriteLine("\"{0}\"", matchExpressions[0]);

                        writer.OpenRegion();

                        var members = configModel.ArgumentCompleters.GetConstantClassMembers(rc);
                        var sb = new StringBuilder();
                        foreach (var m in members)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.AppendFormat("\"{0}\"", m);
                        }

                        writer.WriteLine("$v = {0}", sb.ToString());
                        writer.WriteLine("break");
                        writer.CloseRegion();
                        writer.WriteLine();
                    }

                    writer.CloseRegion();

                    writer.WriteLine();

                    writer.WriteLine("$v |");
                    writer.IncreaseIndent();
                    writer.WriteLine("Where-Object { $_ -like \"$wordToComplete*\" } |");
                    // the single-arg ctor doesn't give us the pop-up list behavior we want, so we have to use the
                    // 4 item ctor - it in turn doesn't work unless we provide values for all 4 args (giving an empty
                    // string for tooltip also doesn't seem to work)
                    writer.WriteLine("ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }");

                    writer.DecreaseIndent();
                    writer.DecreaseIndent();
                    writer.WriteLine("}");

                    writer.WriteLine();

                    // output the call to the registration function of all parameter names and
                    // owning cmdlets that will use this completer, by iterating again over the
                    // reference data
                    writer.WriteLine("${0}_map = @{{", configModel.ServiceNounPrefix);
                    writer.IncreaseIndent();
                    foreach (var p in param2CmdletsMap.Keys)
                    {
                        var cmdlets = param2CmdletsMap[p];
                        cmdlets.Sort();

                        var sb = new StringBuilder();
                        foreach (var c in cmdlets)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.AppendFormat("\"{0}\"", c);
                        }

                        writer.WriteLine("\"{0}\"=@({1})", p, sb.ToString());
                    }

                    writer.DecreaseIndent();
                    writer.WriteLine("}");
                    writer.WriteLine();
                    writer.WriteLine("_awsArgumentCompleterRegistration ${0}_Completers ${0}_map", configModel.ServiceNounPrefix);
                }

                scriptContent = sw.ToString();
            }

            return scriptContent;
        }

        /// <summary>
        /// Scans for any hand-maintained cmdlets. For now this is just to find usage of ConstantClass-derived
        /// types so that we can add them to the argument completers.
        /// </summary>
        /// <param name="outputRoot">The root output folder for the service being generated.</param>
        private void ScanAdvancedCmdlets(string outputRoot)
        {
            var advancedCmdletsFolder = Path.Combine(outputRoot, "Advanced");
            if (!Directory.Exists(advancedCmdletsFolder))
                return;

            var sourceFiles = Directory.GetFiles(advancedCmdletsFolder, "*.cs");
            foreach (var sourceFile in sourceFiles)
            {
                var scanner = new AdvancedCmdletScanner(sourceFile, CurrentModel, CurrentServiceAssembly, Logger);
                scanner.Scan();
            }
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
            // Filter out any hand written partial extension classes
            toFiles = toFiles.Where(
                f => !f.EndsWith(".extensions.cs", StringComparison.OrdinalIgnoreCase)).ToList();

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
            CurrentOperation.Processed = true;

            // capture the analyzer so we can serialize the config as json later
            serviceOperation.Analyzer = new OperationAnalyzer(Options.AnalysisLog)
            {
                AllModels = ModelCollection,
                CurrentModel = CurrentModel,
                CurrentOperation = CurrentOperation,
                Logger = Logger,
                AssemblyDocumentation = CurrentServiceNDoc
            };

            serviceOperation.Analyzer.Analyze(this, method);

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
                    WriteCmdlet(writer, serviceOperation.Analyzer);
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

            string serviceDisplayName = currentModel.ServiceName;

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
                    Logger.LogError("Method {0} is configured to produce iteration code, but SingleResultProperty is null (there are multiple properties being returned). This operation may need to be added to Exclusions for the service.",
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

            // we're looking for methods that have a single parameter that is
            // derived from the AmazonWebServiceRequest type -- all other methods
            // are convenience overloads
            var parameters = method.GetParameters();
            if (parameters.Count() == 1 && parameters[0].ParameterType.IsSubclassOf(SdkBaseRequestType))
            {
                if (CurrentModel.ServiceOperations.ContainsKey(method.Name))
                {
                    if (CurrentModel.ServiceOperations[method.Name].Exclude)
                        return false;
                }
                else
                {
                    // unknown operation, so have a stab at what it should be
                    Logger.Log("Method {0} has no ServiceOperation defined in model {1}, auto-generating", method.Name, CurrentModel.ServiceNamespace);
                    var serviceOperation = new ServiceOperation
                    {
                        MethodName = method.Name,
                        IsAutoConfiguring = true
                    };
                    CurrentModel.ServiceOperationsList.Add(serviceOperation);
                    CurrentModel.ServiceOperations.Add(method.Name, serviceOperation);

                    // this triggers the generator to write out the modified config file
                    // with the changes
                    CurrentModel.ModelUpdated = true;
                }

                //if (Options.BreakOnUnknownOperationError)
                //{
                //    Logger.LogError("Method {0} has no ServiceOperation definition in model {1}", method.Name, CurrentModel.ServiceNamespace);
                //}
                //else
                //{
                //    Logger.Log("Method {0} has no ServiceOperation definition in model {1}, IGNORING as BreakOnUnknownOperationError option FALSE", method.Name, CurrentModel.ServiceNamespace);
                //}

                return true;
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

        /// <summary>
        /// Ensures we know of references to sdk service assemblies that the generator does
        /// not process cmdlets for, but for which cmdlets exist (as handwritten versions).
        /// This ensures we take the assemblies into account when updating project and manifest
        /// files etc.
        /// </summary>
        private void LoadSpecialServiceAssemblies()
        {
            string[] specialAssemblies = {
                "AWSSDK.CloudSearchDomain",
                // no cmdlets for swf but internal teams want the dll available to script against
                "AWSSDK.SimpleWorkflow"      
            };

            Assembly assembly;
            XmlDocument assemblyNDoc;

            foreach (var a in specialAssemblies)
            {
                SourceArtifacts.Load(a, out assembly, out assemblyNDoc);
            }
        }

#endregion
    }
}
