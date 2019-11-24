using McMaster.Extensions.CommandLineUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSReleaseNotesGenerator
{
    class Program
    {
        private const string OldAssemblyPathOptionName = "old-assembly";
        private const string NewAssemblyPathOptionName = "new-assembly";
        private const string VersionFilePathOptionName = "version-file";
        private const string ModuleNameOptionName = "module-name";
        private const string ModuleVersionOptionName = "module-version";
        private const string DownloadFolderOptionName = "download-folder";
        private const string AssemblyFileNameOptionName = "assembly-file-name";

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

        [Option("-mv|--" + ModuleVersionOptionName + " <Z.Y.X.W>", Description = "Version of the PS Gallery module to download.")]
        public string ModuleVersion { get; set; }

        [Option("-df|--" + DownloadFolderOptionName + " <FOLDER_PATH>", Description = "Folder where the module specified by " + ModuleNameOptionName + " will be extracted.")]
        public string DownloadFolder { get; set; }

        [Option("-an|--" + AssemblyFileNameOptionName + " <FILE_NAME>", Description = "Name of the assembly file to analyze from the module downloaded from PS Gallery.")]
        public string AssemblyFileName { get; set; } = "AWSPowerShell.dll";

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
                newModule = PSModuleAnalyzer.Analyze(NewAssemblyPath);
            }
            catch (Exception e)
            {
                throw new Exception($"Error while opening new assembly", e);
            }

            if (string.IsNullOrWhiteSpace(OldAssemblyPath))
            {
                if (string.IsNullOrWhiteSpace(ModuleName) || string.IsNullOrWhiteSpace(AssemblyFileName) || string.IsNullOrWhiteSpace(DownloadFolder))
                    throw new Exception($"Either --{OldAssemblyPathOptionName} or --{ModuleNameOptionName}, --{DownloadFolderOptionName} and --{AssemblyFileNameOptionName} must be specified");

                try
                {
                    OldAssemblyPath = DownloadModule(ModuleName, string.IsNullOrWhiteSpace(ModuleVersion) ? null : ModuleVersion, AssemblyFileName, DownloadFolder);
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while downloading previous module version", e);
                }
            }

            IDictionary<string, Cmdlet> oldModule;
            try
            {
                oldModule = PSModuleAnalyzer.Analyze(OldAssemblyPath);
            }
            catch (Exception e)
            {
                throw new Exception($"Error while opening new assembly", e);
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

            CreateReleaseNotes(newModule, oldModule, sdkNewVersion);
        }

        private static void CreateReleaseNotes(IDictionary<string, Cmdlet> newModule, IDictionary<string, Cmdlet> oldModule, string sdkNewVersion)
        {
            Console.WriteLine($"  * AWS Tools for PowerShell now use AWS .NET SDK {sdkNewVersion} and leverage its new features and improvements. Please find a description of the changes at https://github.com/aws/aws-sdk-net/blob/master/SDK.CHANGELOG.md.");

            var newServices = newModule.Values.GroupBy(cmdlet => cmdlet.ServicePrefix).ToDictionary(service => service.Key ?? "", service => service);
            var oldServices = oldModule.Values.GroupBy(cmdlet => cmdlet.ServicePrefix).ToDictionary(service => service.Key ?? "", service => service);

            Func<KeyValuePair<string, IGrouping<string, Cmdlet>>, string> GetServiceName =
                (KeyValuePair<string, IGrouping<string, Cmdlet>> serviceConfigurations) => serviceConfigurations.Value.First().ServiceName;

            foreach (var oldService in oldServices.Where(service => !newServices.Keys.Contains(service.Key)).OrderBy(service => GetServiceName(service)))
            {
                Console.WriteLine($"  * {BreakingChangeText} Removed support for {GetServiceName(oldService)}");
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
                        PrintServiceHeader(newService.Key, ref IsServiceHeaderPrinted);
                        Console.WriteLine($"    * {BreakingChangeText} Removed cmdlet{(removedCmdlets.Length > 1 ? "s" : "")} {FormatCollection(removedCmdlets)}.");
                    }

                    var addedCmdlets = newCmdlets.Values.Where(cmdlet => !oldCmdlets.ContainsKey(cmdlet.Name)).OrderBy(cmdlet => cmdlet.Name).ToArray();
                    if (addedCmdlets.Length > 0)
                    {
                        PrintServiceHeader(GetServiceName(newService), ref IsServiceHeaderPrinted);
                        foreach (var addedCmdlet in addedCmdlets)
                        {
                            if (addedCmdlet.Operations.Count() > 0)
                            {
                                Console.WriteLine($"    * Added cmdlet {addedCmdlet.Name} leveraging the {FormatCollection(addedCmdlet.Operations)} service API{(addedCmdlet.Operations.Count() > 1 ? "s" : "")}.");
                            }
                            else
                            {
                                Console.WriteLine($"    * Added cmdlet {addedCmdlet.Name}.");
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
                                PrintServiceHeader(GetServiceName(newService), ref IsServiceHeaderPrinted);
                                Console.WriteLine($"    * {(cmdLetComparison.Any(comparison => comparison.IsBreakingChange) ? BreakingChangeText + " " : "")}Modified cmdlet {newCmdlet.Key}: {string.Join("; ", cmdLetComparison.Select(comparison => comparison.Message))}.");
                            }
                        }
                    }
                }
                else
                {
                    var servicePrefix = newService.Value.Select(cmdlet => cmdlet.ServicePrefix).Distinct().Single();
                    Console.WriteLine($"  * {newService.Value.First().ServiceName}. Added cmdlets to support the service. Cmdlets for the service have the noun prefix {servicePrefix} and can be listed using the command 'Get-AWSCmdletName -Service {servicePrefix}'.");
                }
            }
        }

        private static IEnumerable<(string Message, bool IsBreakingChange)> CompareCmdlet(Cmdlet newCmdlet, Cmdlet oldCmdlet)
        {
            if (newCmdlet.OutputTypes.Count() != oldCmdlet.OutputTypes.Count() || newCmdlet.OutputTypes.Intersect(oldCmdlet.OutputTypes).Count() != oldCmdlet.OutputTypes.Count())
                if (!oldCmdlet.OutputTypes.Contains("None"))
                    yield return ($"output changed from {FormatCollection(oldCmdlet.OutputTypes)} to {FormatCollection(newCmdlet.OutputTypes)}", true);

            if (newCmdlet.DefaultParameterSet != oldCmdlet.DefaultParameterSet)
                   yield return ($"default parameter set changed from {oldCmdlet.DefaultParameterSet ?? "null"} to {newCmdlet.DefaultParameterSet ?? "null"}", true);

            if (newCmdlet.SupportsShouldProcess != oldCmdlet.SupportsShouldProcess)
                yield return ($"default parameter set changed from {oldCmdlet.SupportsShouldProcess} to {newCmdlet.SupportsShouldProcess}", true);

            if (newCmdlet.ConfirmImpact != oldCmdlet.ConfirmImpact)
                yield return ($"default parameter set changed from {oldCmdlet.ConfirmImpact} to {newCmdlet.ConfirmImpact}", true);

            var removedParameters = oldCmdlet.Parameters
                .Where(oldParameter => FindMatchingParameter(oldParameter, newCmdlet.Parameters) == null)
                .Select(oldParameter => oldParameter.Name)
                .OrderBy(oldParameterName => oldParameterName)
                .ToArray();
            if (removedParameters.Length > 0)
                yield return ($"removed parameter{(removedParameters.Length > 1 ? "s" : "")} {FormatCollection(removedParameters)}", true);

            foreach (var newParameter in newCmdlet.Parameters.OrderBy(newParameter => newParameter.Name))
            {
                var oldParameter = FindMatchingParameter(oldCmdlet.Parameters, newParameter);
                if (oldParameter != null)
                {
                    if (newParameter.Mandatory && !oldParameter.Mandatory)
                        yield return ($"parameter {newParameter.Name} is now mandatory", true);
                    if (newParameter.Type != oldParameter.Type)
                        yield return ($"the type of parameter {newParameter.Name} changed from {oldParameter.Type} to {newParameter.Type}", true);
                    else if (!newParameter.Nullable && oldParameter.Nullable)
                        yield return ($"parameter {newParameter.Name} isn't nullable anymore", true);
                    if (!newParameter.ValueFromPipeline && oldParameter.ValueFromPipeline)
                        yield return ($"parameter {newParameter.Name} doesn't support pipeline ByValue anymore", true);
                    if (!newParameter.ValueFromPipelineByPropertyName && oldParameter.ValueFromPipelineByPropertyName)
                        yield return ($"parameter {newParameter.Name} doesn't support pipeline ByPropertyName anymore", true);
                    if (!newParameter.ValueFromRemainingArguments && oldParameter.ValueFromRemainingArguments)
                        yield return ($"parameter {newParameter.Name} cannot take value from remaining command line parameters anymore", true);
                    if (newParameter.Position < 0 && oldParameter.Position >= 0)
                        yield return ($"parameter {newParameter.Name} cannot be used positionally anymore", true);
                    if (newParameter.Position >= 0 && oldParameter.Position >= 0 && newParameter.Position != oldParameter.Position)
                        yield return ($"parameter {newParameter.Name} position changed from {oldParameter.Position} to {newParameter.Position}", true);
                }
            }

            var addedParameters = newCmdlet.Parameters
                .Where(newParameter => oldCmdlet.Parameters.All(oldParameter => FindMatchingParameter(oldCmdlet.Parameters, newParameter) == null))
                .Select(newParameter => newParameter.Name)
                .OrderBy(newParameterName => newParameterName)
                .ToArray();
            if (addedParameters.Length > 0)
            {
                yield return ($"added parameter{(addedParameters.Length > 1 ? "s" : "")} {FormatCollection(addedParameters)}", false);
            }

            foreach (var newParameter in newCmdlet.Parameters)
            {
                var oldParameter = FindMatchingParameter(oldCmdlet.Parameters, newParameter);
                if (oldParameter != null)
                {
                    if (!newParameter.Mandatory && oldParameter.Mandatory)
                        yield return ($"parameter {newParameter.Name} is not mandatory anymore", false);
                    //if (newParameter.ValueFromPipeline && !oldParameter.ValueFromPipeline)
                    //    yield return ($"parameter {newParameter.Name} now supports pipeline ByValue", false);
                    //if (newParameter.ValueFromPipelineByPropertyName && !oldParameter.ValueFromPipelineByPropertyName)
                    //    yield return ($"parameter {newParameter.Name} now supports pipeline ByPropertyName", false);
                    //if (newParameter.ValueFromRemainingArguments && !oldParameter.ValueFromRemainingArguments)
                    //    yield return ($"parameter {newParameter.Name} can now take value from remaining command line parameters", false);
                    //if (newParameter.Position != 0 && oldParameter.Position == 0)
                    //    yield return ($"parameter {newParameter.Name} can now be used positionally", false);
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

        private static void PrintServiceHeader(string serviceName, ref bool isPrinted)
        {
            if (!isPrinted)
            {
                if (serviceName == "")
                    serviceName = "AWSPowerShell cmdlets";
                Console.WriteLine($"  * {serviceName}");
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

        private string DownloadModule(string moduleName, string moduleVersion, string assemblyFileName, string downloadFolder)
        {
            var downloadFullPath = Path.GetFullPath(DownloadFolder);

            Directory.CreateDirectory(downloadFullPath);

            try
            {
                Directory.Delete(Path.Combine(downloadFullPath, moduleName), true);
            }
            catch (DirectoryNotFoundException) { }

            using (Process process = new Process())
            {
                string moduleVersionParameter = "";
                if (moduleVersion != null)
                {
                    moduleVersionParameter = $" -RequiredVersion '{moduleVersion}'";
                }

                process.StartInfo = new ProcessStartInfo
                {
                    FileName = "pwsh",
                    Arguments = $"-NonInteractive -NoProfile -Command $ErrorActionPreference='Stop'; Save-Module -Name '{moduleName}'{moduleVersionParameter} -Path '{downloadFolder}'",
                    UseShellExecute = false,
                    RedirectStandardError = true
                };
                process.Start();

                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Powershell invokation failed. Standard error: {error}");
                }
            }

            return Directory.GetFiles(Path.Combine(downloadFullPath, moduleName), assemblyFileName, SearchOption.AllDirectories).FirstOrDefault();
        }
    }
}
