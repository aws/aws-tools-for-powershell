using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

namespace PSReleaseNotesGenerator
{
    class Program
    {
        private const string OldAssemblyPathOptionName = "old-assembly";
        private const string NewAssemblyPathOptionName = "new-assembly";
        private const string VersionFilePathOptionName = "version-file";
        private const string ModuleNameOptionName = "module-name";
        private const string DownloadFolderOptionName = "download-folder";
        private const string AssemblyFileNameOptionName = "assembly-file-name";
        private const string OutputFilePathOptionName = "out-file";
        private const string BreakingChangesOutputFilePathOptionName = "breaking-changes-out-file";
        private const string OverridesFilePathOptionName = "overrides-file";
        private const string RepositoryPathOptionName = "repository-path";
        private const string TargetServiceAssemblyNamesOptionName = "target-service-assembly-names";
        private const string PreviewLabelOptionName = "preview-label";
        private const string NewVersionOptionName = "new-version";



        private const string BreakingChangeText = "[Breaking Change]"; //The build system will look for this string in the output to validate the build


        [Option("-oa|--" + OldAssemblyPathOptionName + " <FILE_PATH>", Description = "Path of the older assembly version to compare")]
        public string OldAssemblyPath { get; set; }

        [Option("-na|--" + NewAssemblyPathOptionName + " <FILE_PATH>", Description = "Path of the newer assembly version to compare")]
        [Required]
        [FileExists]
        public string NewAssemblyPath { get; set; }

        [Option("-vf|--" + VersionFilePathOptionName + " <FILE_PATH>", Description = "Path of the _sdk-versions.json file related to the newer assembly")]
        [Required]
        [FileExists]
        public string VersionFilePath { get; set; }

        [Option("-mn|--" + ModuleNameOptionName + " <NAME>", Description = "Id of the PS Gallery module to download.")]
        public string ModuleName { get; set; } = "AWSPowerShell";

        [Option("-df|--" + DownloadFolderOptionName + " <FOLDER_PATH>", Description = "Folder where the module specified by " + ModuleNameOptionName + " will be extracted.")]
        public string DownloadFolder { get; set; }

        [Option("-an|--" + AssemblyFileNameOptionName + " <FILE_NAME>", Description = "Name of the assembly file to analyze from the module downloaded from PS Gallery.")]
        public string AssemblyFileName { get; set; } = "AWSPowerShell.dll";

        [Option("-of|--" + OutputFilePathOptionName + " <FILE_PATH>", Description = "Optional path to a file to write the release notes output to.")]
        public string OutputFilePath { get; set; }

        [Option("-bc|--" + BreakingChangesOutputFilePathOptionName + " <FILE_PATH>", Description = "Optional path to a file to write the breaking changes lookup output to.")]
        public string BreakingChangesLookupOutputFilePath { get; set; }

        [Option("-or|--" + OverridesFilePathOptionName + " <FILE_PATH>", Description = "Optional path to the overrides file.")]
        public string OverridesFilePath { get; set; }

        [Option("-rp|--" + RepositoryPathOptionName + " <DIRECTORY_PATH>", Description = "Path to the repository root. Used to locate the changelog (changelogs/CHANGELOG.ALL.md) whose top header is the previously published version.")]
        public string RepositoryPath { get; set; }

        [Option("-tsa|--" + TargetServiceAssemblyNamesOptionName + " <ASSEMBLY_NAMES>", Description = "Optional comma-separated list of service AssemblyNames (e.g. \"PrometheusService\") that this build targets. These services are flagged InOverrides=\"true\" in the breaking changes lookup file even when they are absent from the overrides file (e.g. a parameter change on an existing operation with an empty buildconfig). AssemblyName is used (not C2jFilename) because it is the reliable 1:1 identifier shared by .NET and PowerShell.")]
        public string TargetServiceAssemblyNames { get; set; }

        [Option("-pl|--" + PreviewLabelOptionName + " <NAME>", Description = "Preview Label.")]
        public string PreviewLabel { get; set; }

        [Option("-nv|--" + NewVersionOptionName + " <Z.Y.X.W>", Description = "Version of the new PS Module.")]
        public string NewVersion { get; set; }

        public static int Main(string[] args)
        {
            try
            {
                return CommandLineApplication.Execute<Program>(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }
        }

        private void OnExecute()
        {
            IDictionary<string, Cmdlet> newModule;
            try
            {
                Console.WriteLine($"Start analysing new assembly: {NewAssemblyPath}");
                Console.WriteLine($"IsPreviewLabelNullorEmpty: {string.IsNullOrEmpty(PreviewLabel)} PreviewLabel: {PreviewLabel}");
                newModule = new PSModuleAnalyzer(NewAssemblyPath).Analyze();
            }
            catch (Exception e)
            {
                throw new Exception($"Error while opening new assembly", e);
            }

            if (string.IsNullOrWhiteSpace(OldAssemblyPath) && string.IsNullOrEmpty(PreviewLabel))
            {
                if (string.IsNullOrWhiteSpace(ModuleName) || string.IsNullOrWhiteSpace(AssemblyFileName) || string.IsNullOrWhiteSpace(DownloadFolder))
                    throw new Exception($"Either --{OldAssemblyPathOptionName} or --{ModuleNameOptionName}, --{DownloadFolderOptionName} and --{AssemblyFileNameOptionName} must be specified");

                if (string.IsNullOrWhiteSpace(NewVersion) || NewVersion == "0.0.0.0")
                    throw new Exception($"NewVersion cannot be empty or default value 0.0.0.0");

                // Download the exact previous version (changelog top header) from the immutable versioned path.
                var changeLogFile = GetChangeLogPath(RepositoryPath);
                var baselineVersion = GetPreviousPublishedVersion(changeLogFile);
                if (baselineVersion == null)
                    throw new Exception($"Could not determine the previous published version from the changelog at '{changeLogFile}'. Provide --{RepositoryPathOptionName} pointing at the repository root.");

                Console.WriteLine($"NewVersion: {NewVersion}, comparing against previously published version {baselineVersion}");
                try
                {
                    OldAssemblyPath = DownloadModuleVersion(ModuleName, baselineVersion, AssemblyFileName, DownloadFolder);
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while downloading previous module version", e);
                }
            }

            IDictionary<string, Cmdlet> oldModule = null;
            try
            {
                Console.WriteLine($"Start analysing old assembly: {OldAssemblyPath}");
                oldModule = new PSModuleAnalyzer(OldAssemblyPath).Analyze();
            }
            catch (Exception e)
            {
                // TODO: Better handle when new SDK versions have removed types that failed to resolve with old PowerShell Assembly.
                Console.WriteLine($"Error while opening old assembly: {e}");
            }

            string sdkNewVersion;
            try
            {
                sdkNewVersion = GetSDKVersion(VersionFilePath);
            }
            catch (Exception e)
            {
                throw new Exception($"Error while reading SDK version", e);
            }

            string report;
            var breakingChanges = new BreakingChanges();
            
            
            // powershell release notes generator compares the latest module in PowerShellGallery to current version.
            // during the first release, v5 will be compared with latest v4 and the generated release notes is extremely verbose
            // this should be set to false after the first GA release.
            bool previewReleaseNotes = false;

            if (!string.IsNullOrEmpty(PreviewLabel) || previewReleaseNotes)
            {
                report = CreatePreviewReleaseNotes(sdkNewVersion);
            }
            else if (oldModule != null)
            {
                report = CreateReleaseNotes(newModule, oldModule, sdkNewVersion, breakingChanges);
            }
            else
            {
                // If we failed to load the old powershell metadata then generate a default release notes.                
                report = CreateErrorReleaseNotes();
            }
            Console.WriteLine(report);

            if (!string.IsNullOrWhiteSpace(OutputFilePath))
            {
                var fullOutputPath = Path.GetFullPath(OutputFilePath);
                Console.WriteLine($"Writing report to {fullOutputPath}");
                // Normalize line endings to CRLF so output is the same on Windows and Linux.
                report = report.Replace("\r\n", "\n").Replace("\n", "\r\n");
                File.WriteAllText(fullOutputPath, report);
            }

            //Optionally write the breaking changes lookup file
            if (!string.IsNullOrWhiteSpace(BreakingChangesLookupOutputFilePath))
            {
                WriteBreakingChangesLookupFile(BreakingChangesLookupOutputFilePath, OverridesFilePath, TargetServiceAssemblyNames, breakingChanges);
            }
        }

        private static void WriteBreakingChangesLookupFile(string breakingChangesLookupOutputFilePath,
            string overridesFilePath,
            string targetServiceAssemblyNames,
            BreakingChanges breakingChanges)
        {
            var overridesXML = string.Empty;
            if (File.Exists(overridesFilePath))
            {
                overridesXML = File.ReadAllText(overridesFilePath);
            }

            var pathToConfigs = Path.Combine(
                Path.GetDirectoryName(overridesFilePath),
                "generator/AWSPSGeneratorLib/Config/ServiceConfig"
            );

            Func<string, string> serviceConfigLoader = (filetitle) =>
            {
                try
                {
                    return File.ReadAllText(Path.Combine(pathToConfigs, $"{filetitle}.xml"));
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed to load service configuration {filetitle}.xml", e);
                }
            };

            var serviceKeys = Overrides.ParseServiceNounPrefixes(overridesXML, serviceConfigLoader);

            //Flag the services this build explicitly targets so their breaking changes are surfaced
            //even when they are absent from the overrides file. This covers the empty-buildconfig case
            //where a parameter change on an existing operation would otherwise be marked InOverrides="false".
            //The target services are passed as AssemblyNames (the reliable 1:1 identifier shared by .NET
            //and PowerShell) and resolved to their ServiceNounPrefix by matching the <AssemblyName> element
            //of the service configurations, so they merge cleanly with the overrides service keys.
            var targetAssemblyNames = Overrides.ParseTargetServiceAssemblyNames(targetServiceAssemblyNames);
            var configsXmlPath = Path.Combine(Path.GetDirectoryName(pathToConfigs), "Configs.xml");
            var skippedServiceAssemblyNames = Overrides.ParseSkippedServiceAssemblyNames(
                File.Exists(configsXmlPath) ? File.ReadAllText(configsXmlPath) : string.Empty);
            foreach (var nounPrefix in Overrides.ResolveServiceNounPrefixesByAssemblyName(targetAssemblyNames, pathToConfigs, skippedServiceAssemblyNames))
            {
                serviceKeys.Add(nounPrefix);
            }

            var lookupReport = breakingChanges.CreateLookupXML(serviceKeys);
            var fullOutputPath = Path.GetFullPath(breakingChangesLookupOutputFilePath);
            Console.WriteLine($"Writing breaking changes lookup file to {fullOutputPath}");
            Console.WriteLine(lookupReport);
            // Normalize line endings to CRLF so output is the same on Windows and Linux.
            lookupReport = lookupReport.Replace("\r\n", "\n").Replace("\n", "\r\n");
            File.WriteAllText(fullOutputPath, lookupReport);
        }

        private static string CreateErrorReleaseNotes()
        {
            return "Unable to generate release notes. Release notes will need to be created manually.";
        }

        private static string CreatePreviewReleaseNotes(string sdkNewVersion)
        {
            return $"  * AWS Tools for PowerShell now use AWS .NET SDK {sdkNewVersion} and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.";
        }

        private static string CreateReleaseNotes(IDictionary<string, Cmdlet> newModule, 
            IDictionary<string, Cmdlet> oldModule, 
            string sdkNewVersion, 
            BreakingChanges breakingChanges)
        {
            var outputWriter = new StringWriter();

            outputWriter.WriteLine($"  * AWS Tools for PowerShell now use AWS .NET SDK {sdkNewVersion} and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/main/changelogs/SDK.CHANGELOG.ALL.md.");

            var newServices = newModule.Values.GroupBy(cmdlet => cmdlet.ServicePrefix).ToDictionary(service => service.Key ?? "", service => service);
            var oldServices = oldModule.Values.GroupBy(cmdlet => cmdlet.ServicePrefix).ToDictionary(service => service.Key ?? "", service => service);
                        
            var lineText = string.Empty;

            Func<KeyValuePair<string, IGrouping<string, Cmdlet>>, string> GetServiceName =
                (KeyValuePair<string, IGrouping<string, Cmdlet>> serviceConfigurations) => serviceConfigurations.Value.First().ServiceName;

            foreach (var oldService in oldServices.Where(service => !newServices.Keys.Contains(service.Key)).OrderBy(service => GetServiceName(service)))
            {
                lineText = $"{BreakingChangeText} Removed support for {GetServiceName(oldService)}";
                breakingChanges.Add(oldService.Key, lineText, BreakingChangeType.ServiceRemoved);
                outputWriter.WriteLine($"  * {lineText}");
            }

            foreach (var newService in newServices.OrderBy(service => GetServiceName(service)))
            {
                bool IsServiceHeaderPrinted = false;
                var newCmdlets = newService.Value.ToDictionary(cmdlet => cmdlet.Name, cmdlet => cmdlet);

                var oldCmdlets = new Dictionary<string, Cmdlet>();
                if (oldServices.TryGetValue(newService.Key, out var tmp))
                {
                    oldCmdlets = tmp.ToDictionary(cmdlet => cmdlet.Name, cmdlet => cmdlet);

                    var removedCmdlets = oldCmdlets.Keys.Where(cmdletName => !newCmdlets.ContainsKey(cmdletName)).OrderBy(cmdletName => cmdletName).ToArray();
                    if (removedCmdlets.Length > 0)
                    {
                        PrintServiceHeader(newService.Key, outputWriter, ref IsServiceHeaderPrinted);
                        lineText = $"{BreakingChangeText} Removed cmdlet{(removedCmdlets.Length > 1 ? "s" : "")} {FormatCollection(removedCmdlets)}.";
                        breakingChanges.Add(newService.Key, lineText, BreakingChangeType.CmdletRemoved);
                        outputWriter.WriteLine($"    * {lineText}");
                    }

                    var addedCmdlets = newCmdlets.Values.Where(cmdlet => !oldCmdlets.ContainsKey(cmdlet.Name)).OrderBy(cmdlet => cmdlet.Name).ToArray();
                    if (addedCmdlets.Length > 0)
                    {
                        PrintServiceHeader(GetServiceName(newService), outputWriter, ref IsServiceHeaderPrinted);
                        foreach (var addedCmdlet in addedCmdlets)
                        {
                            if (addedCmdlet.Operations.Count() > 0)
                            {
                                outputWriter.WriteLine($"    * Added cmdlet {addedCmdlet.Name} leveraging the {FormatCollection(addedCmdlet.Operations)} service API{(addedCmdlet.Operations.Count() > 1 ? "s" : "")}.");
                            }
                            else
                            {
                                outputWriter.WriteLine($"    * Added cmdlet {addedCmdlet.Name}.");
                            }
                        }
                    }

                    foreach(var newCmdlet in newCmdlets)
                    {
                        if (oldCmdlets.TryGetValue(newCmdlet.Key, out var oldCmdlet))
                        {
                            var cmdLetComparison = CompareCmdlet(newCmdlet.Value, oldCmdlet).ToArray();
                            if (cmdLetComparison.Length > 0)
                            {
                                PrintServiceHeader(GetServiceName(newService), outputWriter, ref IsServiceHeaderPrinted);
                                var isBreakingChange = cmdLetComparison.Any(comparison => comparison.IsBreakingChange);
                                lineText = $"{(isBreakingChange ? BreakingChangeText + " " : "")}" +
                                    $"Modified cmdlet {newCmdlet.Key}: " +
                                    $"{string.Join("; ", cmdLetComparison.Select(comparison => comparison.Message))}.";
                                if(isBreakingChange)
                                {
                                    var groupedByType = cmdLetComparison
                                        .Where(comparison => comparison.IsBreakingChange)
                                        .GroupBy(comparison => comparison.Type.Value);
                                    foreach (var group in groupedByType)
                                    {
                                        var groupText = $"{BreakingChangeText} Modified cmdlet {newCmdlet.Key}: " +
                                            $"{string.Join("; ", group.Select(comparison => comparison.Message))}.";
                                        breakingChanges.Add(newService.Key, groupText, group.Key);
                                    }
                                }

                                outputWriter.WriteLine($"    * {lineText}");
                            }
                        }
                    }
                }
                else
                {
                    var servicePrefix = newService.Value.Select(cmdlet => cmdlet.ServicePrefix).Distinct().Single();
                    outputWriter.WriteLine($"  * {newService.Value.First().ServiceName}. Added cmdlets to support the service. Cmdlets for the service have the noun prefix {servicePrefix} and can be listed using the command 'Get-AWSCmdletName -Service {servicePrefix}'.");
                }
            }

            outputWriter.Close();
            return outputWriter.ToString();
        }

        private static IEnumerable<(string Message, bool IsBreakingChange, BreakingChangeType? Type)> CompareCmdlet(Cmdlet newCmdlet, Cmdlet oldCmdlet)
        {
            if (newCmdlet.OutputTypes.Count() != oldCmdlet.OutputTypes.Count() || newCmdlet.OutputTypes.Intersect(oldCmdlet.OutputTypes).Count() != oldCmdlet.OutputTypes.Count())
                if (!oldCmdlet.OutputTypes.Contains("None"))
                    yield return ($"output changed from {FormatCollection(oldCmdlet.OutputTypes)} to {FormatCollection(newCmdlet.OutputTypes)}", true, BreakingChangeType.CmdletOutputTypeChanged);

            if (newCmdlet.DefaultParameterSet != oldCmdlet.DefaultParameterSet)
                   yield return ($"default parameter set changed from {oldCmdlet.DefaultParameterSet ?? "null"} to {newCmdlet.DefaultParameterSet ?? "null"}", true, BreakingChangeType.DefaultParameterSetChanged);

            if (newCmdlet.SupportsShouldProcess != oldCmdlet.SupportsShouldProcess)
                yield return ($"SupportsShouldProcess changed from {oldCmdlet.SupportsShouldProcess} to {newCmdlet.SupportsShouldProcess}", true, BreakingChangeType.SupportsShouldProcessChanged);

            if (newCmdlet.ConfirmImpact != oldCmdlet.ConfirmImpact)
                yield return ($"ConfirmImpact changed from {oldCmdlet.ConfirmImpact} to {newCmdlet.ConfirmImpact}", true, BreakingChangeType.ConfirmImpactChanged);

            var removedParameters = oldCmdlet.Parameters
                .Where(oldParameter => FindMatchingParameter(oldParameter, newCmdlet.Parameters) == null)
                .Select(oldParameter => oldParameter.Name)
                .OrderBy(oldParameterName => oldParameterName)
                .ToArray();
            if (removedParameters.Length > 0)
                yield return ($"removed parameter{(removedParameters.Length > 1 ? "s" : "")} {FormatCollection(removedParameters)}", true, BreakingChangeType.ParameterRemoved);

            foreach (var newParameter in newCmdlet.Parameters.OrderBy(newParameter => newParameter.Name))
            {
                var oldParameter = FindMatchingParameter(oldCmdlet.Parameters, newParameter);
                if (oldParameter != null)
                {
                    if (newParameter.Mandatory && !oldParameter.Mandatory)
                        yield return ($"parameter {newParameter.Name} is now mandatory", true, BreakingChangeType.ParameterBecameMandatory);
                    if (newParameter.Type != oldParameter.Type)
                        yield return ($"the type of parameter {newParameter.Name} changed from {oldParameter.Type} to {newParameter.Type}", true, BreakingChangeType.ParameterTypeChanged);
                    else if (!newParameter.Nullable && oldParameter.Nullable)
                        yield return ($"parameter {newParameter.Name} isn't nullable anymore", true, BreakingChangeType.ParameterNoLongerNullable);
                    if (!newParameter.ValueFromPipeline && oldParameter.ValueFromPipeline)
                        yield return ($"parameter {newParameter.Name} doesn't support pipeline ByValue anymore", true, BreakingChangeType.ParameterPipelineByValueRemoved);
                    if (!newParameter.ValueFromPipelineByPropertyName && oldParameter.ValueFromPipelineByPropertyName)
                        yield return ($"parameter {newParameter.Name} doesn't support pipeline ByPropertyName anymore", true, BreakingChangeType.ParameterPipelineByPropertyNameRemoved);
                    if (!newParameter.ValueFromRemainingArguments && oldParameter.ValueFromRemainingArguments)
                        yield return ($"parameter {newParameter.Name} cannot take value from remaining command line parameters anymore", true, BreakingChangeType.ParameterRemainingArgumentsRemoved);
                    if (newParameter.Position < 0 && oldParameter.Position >= 0)
                        yield return ($"parameter {newParameter.Name} cannot be used positionally anymore", true, BreakingChangeType.ParameterPositionalRemoved);
                    if (newParameter.Position >= 0 && oldParameter.Position >= 0 && newParameter.Position != oldParameter.Position)
                        yield return ($"parameter {newParameter.Name} position changed from {oldParameter.Position} to {newParameter.Position}", true, BreakingChangeType.ParameterPositionChanged);
                }
            }

            var addedParameters = newCmdlet.Parameters
                .Where(newParameter => oldCmdlet.Parameters.All(oldParameter => FindMatchingParameter(oldCmdlet.Parameters, newParameter) == null))
                .Select(newParameter => newParameter.Name)
                .OrderBy(newParameterName => newParameterName)
                .ToArray();
            if (addedParameters.Length > 0)
            {
                yield return ($"added parameter{(addedParameters.Length > 1 ? "s" : "")} {FormatCollection(addedParameters)}", false, null);
            }

            foreach (var newParameter in newCmdlet.Parameters)
            {
                var oldParameter = FindMatchingParameter(oldCmdlet.Parameters, newParameter);
                if (oldParameter != null)
                {
                    if (!newParameter.Mandatory && oldParameter.Mandatory)
                        yield return ($"parameter {newParameter.Name} is not mandatory anymore", false, null);
                    //if (newParameter.ValueFromPipeline && !oldParameter.ValueFromPipeline)
                    //    yield return ($"parameter {newParameter.Name} now supports pipeline ByValue", false, null);
                    //if (newParameter.ValueFromPipelineByPropertyName && !oldParameter.ValueFromPipelineByPropertyName)
                    //    yield return ($"parameter {newParameter.Name} now supports pipeline ByPropertyName", false, null);
                    //if (newParameter.ValueFromRemainingArguments && !oldParameter.ValueFromRemainingArguments)
                    //    yield return ($"parameter {newParameter.Name} can now take value from remaining command line parameters", false, null);
                    //if (newParameter.Position != 0 && oldParameter.Position == 0)
                    //    yield return ($"parameter {newParameter.Name} can now be used positionally", false, null);
                }
            }
        }

        private static CmdletParameter FindMatchingParameter(IEnumerable<CmdletParameter> oldParameters, CmdletParameter newParameter)
        {
            var matchingParameters = oldParameters
                .Where(oldParameter => newParameter.NameAndAliases.Intersect(oldParameter.NameAndAliases).Count() ==
                                       oldParameter.NameAndAliases.Count())
                .ToArray();
            //Rarely, if parameters were merged into one, there may be more than one match. Better to report no match in this case
            return matchingParameters.Length == 1 ? matchingParameters[0] : null;
        }

        private static CmdletParameter FindMatchingParameter(CmdletParameter oldParameter, IEnumerable<CmdletParameter> newParameters)
        {
            var matchingParameters = newParameters
                .Where(newParameter => newParameter.NameAndAliases.Intersect(oldParameter.NameAndAliases).Count() ==
                                       oldParameter.NameAndAliases.Count())
                .ToArray();
            //Rarely, if parameters were merged into one, there may be more than one match. Better to report no match in this case
            return matchingParameters.Length == 1 ? matchingParameters[0] : null;
        }

        private static void PrintServiceHeader(string serviceName, StringWriter outputWriter, ref bool isPrinted)
        {
            if (!isPrinted)
            {
                if (serviceName == "")
                    serviceName = "AWSPowerShell cmdlets";
                outputWriter.WriteLine($"  * {serviceName}");
                isPrinted = true;
            }
        }

        private static string FormatCollection(IEnumerable<string> values)
        {
            var result = new StringBuilder();

            string prevValue = null;
            bool first = true;
            foreach (var value in values)
            {
                if (prevValue != null)
                {
                    if (first == false)
                        result.Append(", ");
                    result.Append(prevValue);
                    first = false;
                }
                prevValue = value;
            }
            if (prevValue != null)
            {
                if (first == false)
                    result.Append(" and ");
                result.Append(prevValue);
            }

            return result.ToString();
        }

        private string GetSDKVersion(string versionFilePath)
        {
            using (StreamReader reader = File.OpenText(versionFilePath))
            {
                JObject jsonRoot = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                return jsonRoot["ProductVersion"].Value<string>();
            }
        }

        private const string ChangeLogDirectory = "changelogs";
        private const string ChangeLogAllName = "CHANGELOG.ALL.md";

        // Returns the aggregated changelog path under the repository root, or null when none is supplied.
        private static string GetChangeLogPath(string repositoryPath)
        {
            if (string.IsNullOrWhiteSpace(repositoryPath))
            {
                return null;
            }
            return Path.Combine(repositoryPath, ChangeLogDirectory, ChangeLogAllName);
        }

        // Returns the version from the changelog's top "### <version>" header, or null if not found.
        private static string GetPreviousPublishedVersion(string changeLogFile)
        {
            if (string.IsNullOrWhiteSpace(changeLogFile) || !File.Exists(changeLogFile))
            {
                return null;
            }

            foreach (var line in File.ReadLines(changeLogFile))
            {
                var match = System.Text.RegularExpressions.Regex.Match(line, @"^###\s+(\d+\.\d+\.\d+(\.\d+)?)\b");
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
            }
            return null;
        }

        // Downloads and extracts a specific published module version from the immutable CloudFront versioned path.
        private string DownloadModuleVersion(string moduleName, string version, string assemblyFileName, string downloadFolder)
        {
            var moduleUri = $"https://sdk-for-net.amazonwebservices.com/ps/releases/{moduleName}.{version}.zip";
            return DownloadAndExtract(moduleUri, moduleName, assemblyFileName, downloadFolder);
        }

        private string DownloadAndExtract(string moduleUri, string moduleName, string assemblyFileName, string downloadFolder)
        {
            var downloadFullPath = Path.GetFullPath(downloadFolder);
            var extractPath = Path.Combine(downloadFullPath, moduleName);

            Directory.CreateDirectory(downloadFullPath);

            try
            {
                Directory.Delete(extractPath, true);
            }
            catch (DirectoryNotFoundException) { }

            Console.WriteLine($"Downloading previous module from {moduleUri}");

            var tempFile = Path.GetTempFileName();
            try
            {
                DownloadFileWithRetry(moduleUri, tempFile);
                ZipFile.ExtractToDirectory(tempFile, extractPath);
            }
            finally
            {
                File.Delete(tempFile);
            }

            return Directory.GetFiles(extractPath, assemblyFileName, SearchOption.AllDirectories).FirstOrDefault();
        }

        private static void DownloadFileWithRetry(string uri, string destinationPath)
        {
            const int maxAttempts = 5;
            using (var client = new HttpClient())
            {
                for (int attempt = 1; ; attempt++)
                {
                    try
                    {
                        using (var responseStream = client.GetStreamAsync(uri).GetAwaiter().GetResult())
                        using (var fileStream = File.Create(destinationPath))
                        {
                            responseStream.CopyTo(fileStream);
                        }
                        return;
                    }
                    catch (Exception e) when (attempt < maxAttempts)
                    {
                        Console.WriteLine($"Download attempt {attempt} of {maxAttempts} failed: {e.Message}. Retrying.");
                        Thread.Sleep(TimeSpan.FromSeconds(Math.Pow(2, attempt)));
                    }
                }
            }
        }
    }
}
