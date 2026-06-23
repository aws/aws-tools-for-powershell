using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace Amazon.PowerShell.Installer.Tests
{
    internal static class Fixtures
    {
        /// <summary>
        /// Writes a minimal but valid AWS.Tools-style manifest at the given path.
        /// </summary>
        public static void WriteManifest(
            string path,
            string moduleName,
            string moduleVersion,
            string description = "Synthetic test module.",
            string author = "Amazon.com, Inc",
            string copyright = "Copyright Amazon.com, Inc.",
            string guid = "00000000-0000-0000-0000-000000000000",
            string? prerelease = null,
            string[]? cmdletsToExport = null,
            string[]? tags = null,
            (string Name, string Version)[]? requiredModules = null)
        {
            cmdletsToExport ??= Array.Empty<string>();
            tags ??= new[] { "AWS", "cloud" };
            requiredModules ??= Array.Empty<(string, string)>();

            string cmdlets = cmdletsToExport.Length == 0
                ? string.Empty
                : string.Join(", ", System.Linq.Enumerable.Select(cmdletsToExport, c => $"'{c}'"));
            string tagsLit = string.Join(", ", System.Linq.Enumerable.Select(tags, t => $"'{t}'"));
            string reqLit = requiredModules.Length == 0
                ? string.Empty
                : string.Join(", ", System.Linq.Enumerable.Select(requiredModules,
                    r => $"@{{ ModuleName = '{r.Name}'; ModuleVersion = '{r.Version}' }}"));
            string prereleaseLine = prerelease is null ? "" : $"Prerelease = '{prerelease}'";

            string content = $@"@{{
    ModuleVersion = '{moduleVersion}'
    GUID = '{guid}'
    Author = '{author}'
    CompanyName = 'Amazon.com, Inc'
    Description = '{description}'
    Copyright = '{copyright}'
    PowerShellVersion = '5.1'
    DotNetFrameworkVersion = '4.7.2'
    CmdletsToExport = @({cmdlets})
    RequiredModules = @({reqLit})
    PrivateData = @{{
        PSData = @{{
            Tags = @({tagsLit})
            LicenseUri = 'https://aws.amazon.com/apache-2-0/'
            ProjectUri = 'https://github.com/aws/aws-tools-for-powershell'
            IconUri = 'https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png'
            ReleaseNotes = 'Test release notes.'
            {prereleaseLine}
        }}
    }}
}}";

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, content);
        }

        /// <summary>
        /// Builds a synthetic AWS.Tools.zip in <paramref name="zipPath"/> containing each
        /// (module, version) pair as <c>{module}/{version}/{module}.psd1</c> plus a placeholder
        /// payload file. Returns the zip path for chaining.
        /// </summary>
        public static string BuildSyntheticZip(string zipPath, params (string Module, string Version)[] modules)
        {
            string stagingRoot = Path.Combine(Path.GetTempPath(), "fixture-stage-" + Guid.NewGuid().ToString("N"));
            try
            {
                foreach (var (module, version) in modules)
                {
                    var versionDir = Path.Combine(stagingRoot, module, version);
                    Directory.CreateDirectory(versionDir);
                    WriteManifest(Path.Combine(versionDir, $"{module}.psd1"), module, version);
                    // Add a placeholder payload so the module dir isn't psd1-only.
                    File.WriteAllText(Path.Combine(versionDir, $"{module}.psm1"), "# placeholder");
                }
                if (File.Exists(zipPath)) File.Delete(zipPath);
                ZipFile.CreateFromDirectory(stagingRoot, zipPath);
                return zipPath;
            }
            finally
            {
                if (Directory.Exists(stagingRoot))
                    Directory.Delete(stagingRoot, recursive: true);
            }
        }

        /// <summary>
        /// Builds a synthetic AWS.Tools.zip whose entry names use BACKSLASHES instead
        /// of forward slashes. This simulates Windows PowerShell 5.1's Compress-Archive
        /// which emits backslashes, in violation of the zip spec. Used to assert that
        /// ExtractAndInstall accepts customer-built 5.1 zips alongside spec-compliant ones.
        /// </summary>
        public static string BuildSyntheticZipWithBackslashes(string zipPath, params (string Module, string Version)[] modules)
        {
            if (File.Exists(zipPath)) File.Delete(zipPath);
            using var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write);
            using var zip = new ZipArchive(fs, ZipArchiveMode.Create);
            foreach (var (module, version) in modules)
            {
                // Write the manifest body to a temp file so we can stream it into the entry.
                var tmp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".psd1");
                WriteManifest(tmp, module, version);
                try
                {
                    var psd1Entry = zip.CreateEntry($"{module}\\{version}\\{module}.psd1", CompressionLevel.NoCompression);
                    using (var es = psd1Entry.Open())
                    using (var src = File.OpenRead(tmp)) src.CopyTo(es);
                }
                finally { File.Delete(tmp); }

                var psm1Entry = zip.CreateEntry($"{module}\\{version}\\{module}.psm1", CompressionLevel.NoCompression);
                using (var w = new StreamWriter(psm1Entry.Open())) w.Write("# placeholder");
            }
            return zipPath;
        }

        public static string NewTempDir(string prefix)
        {
            var p = Path.Combine(Path.GetTempPath(), $"{prefix}-{Guid.NewGuid():N}");
            Directory.CreateDirectory(p);
            return p;
        }

        /// <summary>
        /// Builds a synthetic zip where ONE module's .psd1 is intentionally malformed
        /// (broken hashtable - won't parse). All other modules in <paramref name="modules"/>
        /// are written correctly. The malformed module is the first entry of the array.
        /// Used to assert the per-module warning behavior of ProcessExtractedModule.
        /// </summary>
        public static string BuildZipWithOneMalformedManifest(string zipPath, params (string Module, string Version)[] modules)
        {
            if (modules.Length < 2) throw new ArgumentException("Need at least 2 modules so one can be broken and others stay good.");
            string stagingRoot = Path.Combine(Path.GetTempPath(), "fixture-stage-" + Guid.NewGuid().ToString("N"));
            try
            {
                bool first = true;
                foreach (var (module, version) in modules)
                {
                    var versionDir = Path.Combine(stagingRoot, module, version);
                    Directory.CreateDirectory(versionDir);
                    var psd1Path = Path.Combine(versionDir, $"{module}.psd1");
                    if (first)
                    {
                        // Unclosed hashtable - PowerShell's parser will reject.
                        File.WriteAllText(psd1Path, "@{ ModuleVersion = '" + version + "'\n");
                        first = false;
                    }
                    else
                    {
                        WriteManifest(psd1Path, module, version);
                    }
                    File.WriteAllText(Path.Combine(versionDir, $"{module}.psm1"), "# placeholder");
                }
                if (File.Exists(zipPath)) File.Delete(zipPath);
                ZipFile.CreateFromDirectory(stagingRoot, zipPath);
                return zipPath;
            }
            finally
            {
                if (Directory.Exists(stagingRoot))
                    Directory.Delete(stagingRoot, recursive: true);
            }
        }

        /// <summary>
        /// Builds a zip where one module's version directory is present but contains NO .psd1
        /// (only a .psm1 placeholder). Used to assert that ProcessExtractedModule silently
        /// skips a version dir when its expected manifest is absent.
        /// </summary>
        /// <summary>
        /// Pre-creates a version-stamped module directory under <paramref name="targetPath"/>
        /// to simulate a prior install. Writes a minimal manifest and a PSGetModuleInfo.xml
        /// with the supplied content. On Windows, optionally sets the Hidden attribute on
        /// the xml file to mirror what PowerShellGet (and our own builder) would have done.
        /// </summary>
        public static void PreCreateInstalledVersion(
            string targetPath, string moduleName, string version,
            string psgetXmlContent, bool hideXml)
        {
            var versionDir = Path.Combine(targetPath, moduleName, version);
            Directory.CreateDirectory(versionDir);
            WriteManifest(Path.Combine(versionDir, $"{moduleName}.psd1"), moduleName, version);
            var xmlPath = Path.Combine(versionDir, "PSGetModuleInfo.xml");
            File.WriteAllText(xmlPath, psgetXmlContent);
            if (hideXml && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                File.SetAttributes(xmlPath, File.GetAttributes(xmlPath) | FileAttributes.Hidden);
        }

        public static string BuildZipWithMissingPsd1(string zipPath, string moduleName, string version)
        {
            string stagingRoot = Path.Combine(Path.GetTempPath(), "fixture-stage-" + Guid.NewGuid().ToString("N"));
            try
            {
                var versionDir = Path.Combine(stagingRoot, moduleName, version);
                Directory.CreateDirectory(versionDir);
                File.WriteAllText(Path.Combine(versionDir, $"{moduleName}.psm1"), "# placeholder, no psd1 next to me");
                if (File.Exists(zipPath)) File.Delete(zipPath);
                ZipFile.CreateFromDirectory(stagingRoot, zipPath);
                return zipPath;
            }
            finally
            {
                if (Directory.Exists(stagingRoot))
                    Directory.Delete(stagingRoot, recursive: true);
            }
        }
    }
}
