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

        internal static (string Version, string[] SdkDependencies) GetVersionAndDependencies(string nugetFolderPath, string packageName)
        {
            if (!packageName.StartsWith(SdkLibraryPrefix))
            {
                throw new ArgumentException($"{packageName} is not an AWS SDK library");
            }

            try
            {
                var root = ReadSdkVersionFile(nugetFolderPath);
                if (packageName == "AWSSDK.Core")
                {
                    return ((string)root["CoreVersion"], new string[0]);
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
                        return ((string)package["Version"], sdkDependencies);
                    }
                    else
                    {
                        throw new Exception($"Couldn't find package {packageName} in versions file");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error while reading {packageName} entry from version file", e);
            }
        }

        private static JObject ReadSdkVersionFile(string nugetFolderPath)
        {
            var versionsFilePath = Path.Combine(nugetFolderPath, "..", "_sdk-versions.json");
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
