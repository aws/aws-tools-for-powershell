using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// This class provides helper methods to download libraries from NuGet.
    /// </summary>
    class SdkVersionsUtils
    {
        private const string SdkLibraryPrefix = "AWSSDK.";
        private static readonly string[] PowerShellExtensionPathPrefixes =
        {
            "extensions/CborProtocol/",
            "extensions/CloudFrontSigners/",
            "extensions/CrtIntegration/",
            "extensions/EC2DecryptPassword/"
        };

        // Windows PowerShell applies no binding redirects, so for each platform the modules ship the System.Memory and System.Buffers
        // versions that System.Text.Json in the SDK artifacts references. Newer references resolve to them through AWSModuleAssemblyInitializer,
        // and a copy of the same version in the GAC or already loaded in the session is the same assembly.
        private static readonly Dictionary<string, (string PackageId, string Version, string LibFolder)[]> SystemTextJsonDependencies =
            new Dictionary<string, (string PackageId, string Version, string LibFolder)[]>
        {
            { "net472", new[] { ("System.Memory", "4.5.5", "net461"), ("System.Buffers", "4.5.1", "net461") } },
            { "netstandard2.0", new[] { ("System.Memory", "4.5.5", "netstandard2.0") } }
        };

        private static HashSet<string> DownloadedSdkPlatforms = new HashSet<string>();
        private static HashSet<string> UpdatedSystemTextJsonDependencyPlatforms = new HashSet<string>();

        internal static IEnumerable<string> GetDependencies(string sdkAssembliesFolder, string packageName)
        {
            if (!packageName.StartsWith(SdkLibraryPrefix))
            {
                throw new ArgumentException($"{packageName} is not an AWS SDK library");
            }

            try
            {
                var root = ReadSdkVersionFile(sdkAssembliesFolder);
                if (packageName == "AWSSDK.Core")
                {
                    return new string[0];
                }
                else
                {
                    var package = root["ServiceVersions"][packageName.Substring(SdkLibraryPrefix.Length)];
                    if (package != null)
                    {
                        var sdkDependencies = package["Dependencies"].Children()
                            .OfType<JProperty>()
                            .Select(dep => dep.Name)
                            .Except(new string[] { "Core" })
                            .ToArray();
                        return sdkDependencies;
                    }
                    else
                    {
                        return new string[0];
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error while reading {packageName} entry from version file", e);
            }
        }

        internal static (Version Version, bool IsPreview, string PreviewLabel) GetSDKVersion(string sdkAssembliesFolder)
        {
            try
            {
                var root = ReadSdkVersionFile(sdkAssembliesFolder);
                var version = Version.Parse((string)root["ProductVersion"]);
                var previewLabel = "";
                var isPreview = bool.Parse((string)root["DefaultToPreview"]);
                if (isPreview)
                {
                    previewLabel = (string)root["PreviewLabel"];
                }

                return (version, isPreview, previewLabel);
            }
            catch (Exception e)
            {
                throw new Exception($"Error while reading ProductVersion from version file", e);
            }
        }

        /// <summary>
        /// Downloads the latest version of a library.
        /// </summary>
        /// <param name="packageName">Name of the NuGet package</param>
        /// <param name="sdkAssembliesFolder">Path where the library should be extracted</param>
        /// <param name="platformNames">Name of the platorm, for example "net472" or "netstandard2.0'</param>
        /// <returns>A list of other SDK libraries this library depends on</returns>
        internal static void EnsureSdkLibraryIsAvailable(string packageName, string sdkAssembliesFolder, IEnumerable<string> platformNames)
        {
            Directory.CreateDirectory(sdkAssembliesFolder);

            foreach (string platformName in platformNames)
            {
                var platformPath = Path.Combine(sdkAssembliesFolder, platformName);
                Directory.CreateDirectory(platformPath);
                foreach (var fileName in new string[] { $"{packageName}.dll", $"{packageName}.xml" })
                {
                    string filePath = Path.Combine(platformPath, fileName);
                    if (!File.Exists(filePath))
                    {
                        var (version, isPreview, previewLabel)  = SdkVersionsUtils.GetSDKVersion(sdkAssembliesFolder);
                        DownloadSDKAssembliesAsync(platformPath, platformName, version, isPreview, previewLabel).Wait();
                    }
                }

                if (UpdatedSystemTextJsonDependencyPlatforms.Add(platformPath))
                {
                    ReplaceSystemTextJsonDependenciesAsync(platformPath, platformName).Wait();
                }
            }
        }

        /// <summary>
        /// Replaces System.Memory and System.Buffers in the platform folder with the versions System.Text.Json references.
        /// Runs whether the SDK assemblies were downloaded here or staged by buildtools/Build.ps1.
        /// </summary>
        private static async Task ReplaceSystemTextJsonDependenciesAsync(string platformPath, string platformName)
        {
            if (!SystemTextJsonDependencies.TryGetValue(platformName, out var packages))
            {
                return;
            }

            foreach (var (packageId, version, libFolder) in packages)
            {
                var packageUri = $"https://api.nuget.org/v3-flatcontainer/{packageId.ToLowerInvariant()}/{version}/{packageId.ToLowerInvariant()}.{version}.nupkg";
                var entryName = $"lib/{libFolder}/{packageId}.dll";
                Console.WriteLine($"Replacing {packageId}.dll in {platformPath} with {entryName} from {packageUri}");

                try
                {
                    using (var client = new HttpClient())
                    using (var packageStream = new MemoryStream(await client.GetByteArrayAsync(packageUri)))
                    using (var archive = new ZipArchive(packageStream, ZipArchiveMode.Read))
                    {
                        var entry = archive.GetEntry(entryName) ?? throw new InvalidOperationException($"{entryName} not found in {packageUri}");
                        entry.ExtractToFile(Path.Combine(platformPath, $"{packageId}.dll"), true);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while downloading {packageUri}", e);
                }
            }
        }

        /// <summary>
        /// Downloads the required version/platform of the SDK assemblies
        /// </summary>
        private static async Task DownloadSDKAssembliesAsync(string platformPath, string platformName, Version sdkVersion, bool isPreview, string previewLabel)
        {
            if (DownloadedSdkPlatforms.Add(platformPath))
            {
                var sdkUri = $"https://sdk-for-net.amazonwebservices.com/releases/aws-sdk-{platformName}-{sdkVersion}{(isPreview ? $"-{previewLabel}" : "")}.zip";
                Console.WriteLine($"Downloading SDK at {sdkUri}");

                try
                {
                    var tempFile = Path.GetTempFileName();
                    try
                    {
                        using (var client = new HttpClient())
                        using (var fileStream = File.Create(tempFile))
                        using (var packageStream = await client.GetStreamAsync(sdkUri))
                        {
                            packageStream.CopyTo(fileStream);
                        }

                        using (var archive = ZipFile.OpenRead(tempFile))
                        {
                            var fullPlatformPath = Path.GetFullPath(platformPath + Path.DirectorySeparatorChar);
                            foreach (var entry in archive.Entries)
                            {
                                // Skip directory entries (they have an empty Name)
                                if (string.IsNullOrEmpty(entry.Name))
                                {
                                    continue;
                                }

                                // Only extract extensions artifacts if PowerShell actually needs them.
                                var isExtensionEntry = entry.FullName.StartsWith("extensions/", StringComparison.OrdinalIgnoreCase);
                                var shouldExtractEntry = !isExtensionEntry || PowerShellExtensionPathPrefixes.Any(prefix => entry.FullName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));

                                if (!shouldExtractEntry)
                                {
                                    continue;
                                }

                                // Flatten: extract all files directly into the platform root using just the filename
                                var filePath = Path.GetFullPath(Path.Combine(platformPath, entry.Name));
                                
                                // Zip-slip protection: ensure the resolved path stays within platformPath
                                if (!filePath.StartsWith(fullPlatformPath, StringComparison.OrdinalIgnoreCase))
                                {
                                    throw new InvalidOperationException($"Entry is outside the target directory: {entry.FullName}");
                                }

                                // Existing files in the folder are not overwritten!
                                if (!File.Exists(filePath))
                                {
                                    entry.ExtractToFile(filePath, false);
                                }
                            }
                        }
                    }
                    finally
                    {
                        File.Delete(tempFile);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while downloading {sdkUri}", e);
                }
            }
        }

        internal static JObject ReadSdkVersionFile(string sdkAssembliesFolder)
        {
            var versionsFilePath = Path.Combine(sdkAssembliesFolder, "..", "_sdk-versions.json");
            try
            {
                using (var jsonReader = new JsonTextReader(File.OpenText(versionsFilePath)))
                {
                    return JObject.Load(jsonReader);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error while reading from {versionsFilePath}", e);
            }
        }
    }
}
