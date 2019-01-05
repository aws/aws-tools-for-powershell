using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using NuGet.Configuration;
using NuGet.PackageManagement;
using NuGet.Packaging.Core;
using NuGet.ProjectManagement;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Resolver;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AWSPowerShellGenerator.Utils
{
    /// <summary>
    /// This class provides helper methods to download libraries from NuGet.
    /// </summary>
    class NuGetUtils
    {
        static readonly ResolutionContext ResolutionContext = new ResolutionContext(DependencyBehavior.Ignore, true, false, VersionConstraints.None);

        /// <summary>
        /// Downloads the latest version of a library from NuGet.
        /// </summary>
        /// <param name="baseName">Name of the NuGet package</param>
        /// <param name="nugetFolderPath">Path where the NuGet packages can be found or will be downloaded to</param>
        /// <param name="extractionFolderPath">Path where the library should be extracted</param>
        /// <param name="platformName">Name of the platorm, for example "net35" or "netstandard2.0'</param>
        internal static bool ExtractSourceLibrary(string packageName, string nugetFolderPath, string extractionFolderPath, string platformName)
        {
            var nugetFilePaths = Directory.GetFiles(nugetFolderPath, packageName + ".*.nupkg", SearchOption.TopDirectoryOnly).ToArray();
            if (nugetFilePaths.Length > 1)
                throw new Exception($"Multiple NuGet packages available for {packageName}");

            string nugetFilePath = nugetFilePaths.FirstOrDefault() ?? DownloadNugetPackageAsync(nugetFolderPath, packageName).Result;
            using (var archive = ZipFile.OpenRead(nugetFilePath))
            {
                Directory.CreateDirectory(extractionFolderPath);
                foreach (var fileName in new string[] { $"{packageName}.dll", $"{packageName}.xml" })
                {
                    string filePath = Path.Combine(extractionFolderPath, fileName);
                    if (!File.Exists(filePath))
                    {
                        var zipEntry = archive.GetEntry($"lib/{platformName}/{fileName}");
                        if (zipEntry == null)
                            return false;
                        zipEntry.ExtractToFile(filePath);

                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Downloads the latest version of a package from NuGet
        /// </summary>
        /// <param name="nugetFolderPath">Path where the NuGet packages will be downloaded to</param>
        /// <param name="baseName">Name of the NuGet package</param>
        /// <returns></returns>
        private static async Task<string> DownloadNugetPackageAsync(string nugetFolderPath, string packageName)
        {
            try
            {
                var downloadFullPath = Path.GetFullPath(nugetFolderPath);

                NuGetVersion version = await GetVersion(downloadFullPath, packageName);

                var packageIdentity = new PackageIdentity(packageName, version);
                var downloadContext = new PackageDownloadContext(ResolutionContext.SourceCacheContext, downloadFullPath, directDownload: true);
                var sourceRepository = GetResourceRepository(downloadFullPath, packageName);
                string path = $"{downloadFullPath}\\{packageIdentity}.nupkg";

                using (var result = await PackageDownloader.GetDownloadResourceResultAsync(sourceRepository, packageIdentity, downloadContext, downloadFullPath, new NullLogger(), CancellationToken.None))
                {
                    using (var fileStream = File.Create(path))
                    {
                        result.PackageStream.CopyTo(fileStream);
                    }
                }
                return path;
            }
            catch (Exception e)
            {
                throw new Exception($"Error while downloading package {packageName} from NuGet", e);
            }
        }

        private static async Task<NuGetVersion> GetVersion(string downloadFullPath, string packageName)
        {
            if (packageName.StartsWith("AWSSDK."))
            {
                string versionsFilePath = Path.Combine(downloadFullPath, @"..\_sdk-versions.json");
                try
                {
                    using (var jsonReader = new JsonTextReader(File.OpenText(versionsFilePath)))
                    {

                        var root = JObject.Load(jsonReader);
                        if (packageName == "AWSSDK.Core")
                        {
                            string version = (string)root["CoreVersion"];
                            return NuGetVersion.Parse(version);
                        }
                        else
                        {
                            var package = root["ServiceVersions"][packageName.Substring(7)];
                            if (package != null)
                            {
                                string version = (string)package["Version"];
                                return NuGetVersion.Parse(version);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while reading {packageName} entry from {versionsFilePath}", e);
                }
            }

            var project = new FolderNuGetProject(downloadFullPath);

            var sourceRepository = GetResourceRepository(downloadFullPath, packageName);
            var sourceRepositories = new List<SourceRepository>() { sourceRepository };

            var resolvedPackage = await NuGetPackageManager.GetLatestVersionAsync(packageName, project, ResolutionContext, sourceRepositories, new NullLogger(), CancellationToken.None);
            if (!resolvedPackage.Exists)
                return null;
            return resolvedPackage.LatestVersion;
        }

        private static SourceRepository GetResourceRepository(string downloadFullPath, string packageName)
        {
            var project = new FolderNuGetProject(downloadFullPath);

            var source = new PackageSource("https://api.nuget.org/v3/index.json");
            var resourceProviders = FactoryExtensionsV3.GetCoreV3(Repository.Provider);
            return new SourceRepository(source, resourceProviders, FeedType.Undefined);
        }
    }
}
