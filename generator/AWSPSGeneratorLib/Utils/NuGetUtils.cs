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
    class NuGetUtils
    {
        private const int NugetHttpGetRetryCount = 5;

        /// <summary>
        /// Downloads the latest version of a library from NuGet.
        /// </summary>
        /// <param name="baseName">Name of the NuGet package</param>
        /// <param name="nugetFolderPath">Path where the NuGet packages can be found or will be downloaded to</param>
        /// <param name="extractionFolderPath">Path where the library should be extracted</param>
        /// <param name="platformName">Name of the platorm, for example "net35" or "netstandard2.0'</param>
        /// <returns>A list of other SDK libraries this library depends on</returns>
        internal static IEnumerable<string> ExtractSourceLibrary(string packageName, string nugetFolderPath, string extractionFolderPath, IEnumerable<string> platformNames)
        {
            Directory.CreateDirectory(nugetFolderPath);
            var nugetFilePaths = Directory.GetFiles(nugetFolderPath, packageName + ".*.nupkg", SearchOption.TopDirectoryOnly).ToArray();
            if (nugetFilePaths.Length > 1)
            {
                throw new Exception($"Multiple NuGet packages available for {packageName}");
            }

            string nugetFilePath = nugetFilePaths.FirstOrDefault();
            IEnumerable<string> sdkDependencies;
            if (nugetFilePath == null)
            {
                (nugetFilePath, sdkDependencies) = DownloadNugetPackageAsync(nugetFolderPath, packageName).Result;
            }
            else
            {
                var fullNugetFolderPath = Path.GetFullPath(nugetFolderPath);
                (_, sdkDependencies) = SdkVersionsUtils.GetVersionAndDependencies(fullNugetFolderPath, packageName);
            }

            using (var archive = ZipFile.OpenRead(nugetFilePath))
            {
                foreach (string platformName in platformNames)
                {
                    var platformPath = Path.Combine(extractionFolderPath, platformName);
                    Directory.CreateDirectory(platformPath);
                    foreach (var fileName in new string[] { $"{packageName}.dll", $"{packageName}.xml" })
                    {
                        string filePath = Path.Combine(platformPath, fileName);
                        if (!File.Exists(filePath))
                        {
                            var zipEntry = archive.GetEntry($"lib/{platformName}/{fileName}");
                            if (zipEntry != null)
                            {
                                zipEntry.ExtractToFile(filePath);
                            }
                        }
                    }
                }
            }
            return sdkDependencies;
        }

        /// <summary>
        /// Downloads the latest version of a package from NuGet
        /// </summary>
        /// <param name="nugetFolderPath">Path where the NuGet packages will be downloaded to</param>
        /// <param name="baseName">Name of the NuGet package</param>
        /// <returns></returns>
        private static async Task<(string Path, string[] SdkDependencies)> DownloadNugetPackageAsync(string nugetFolderPath, string packageName)
        {
            try
            {
                var normalizedPackageName  = packageName.ToLowerInvariant();

                var fullNugetFolderPath = Path.GetFullPath(nugetFolderPath);

                var (version, sdkDependencies) = SdkVersionsUtils.GetVersionAndDependencies(fullNugetFolderPath, packageName);
                var normalizedVersion = NormalizeNugetVersionNumber(version);

                string path = Path.Combine(fullNugetFolderPath, $"{packageName}.{version}.nupkg");

                using (var client = new HttpClient())
                {
                    for (int retryCount = 0; ; retryCount++)
                    {
                        using (var fileStream = File.Create(path))
                        {
                            try
                            {
                                using (var packageStream = await client.GetStreamAsync($"https://api.nuget.org/v3-flatcontainer/{normalizedPackageName}/{normalizedVersion}/{normalizedPackageName}.{normalizedVersion}.nupkg"))
                                {
                                    packageStream.CopyTo(fileStream);
                                }
                                return (path, sdkDependencies);
                            }
                            catch (Exception e)
                            {
                                if (retryCount >= NugetHttpGetRetryCount)
                                {
                                    throw;
                                }
                                await Task.Delay(500);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error while downloading package {packageName} from NuGet", e);
            }
        }

        private static string NormalizeNugetVersionNumber(string version)
        {
            var normalizedVersion = version.Split('.').Select(n => int.Parse(n)).ToList();

            while (normalizedVersion.Count > 3 && normalizedVersion.Last() == 0)
            {
                normalizedVersion.RemoveAt(normalizedVersion.Count - 1);
            }

            return string.Join(".", normalizedVersion);
        }
    }
}
