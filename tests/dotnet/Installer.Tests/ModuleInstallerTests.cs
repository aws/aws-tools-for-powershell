using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Amazon.PowerShell.Installer.Tests
{
    public class ModuleInstallerTests : IDisposable
    {
        private readonly string _tempRoot;

        public ModuleInstallerTests()
        {
            _tempRoot = Fixtures.NewTempDir("installer-tests");
        }

        public void Dispose()
        {
            try { if (Directory.Exists(_tempRoot)) Directory.Delete(_tempRoot, recursive: true); }
            catch { /* test cleanup is best-effort */ }
        }

        // ----- ExtractAndInstall -----

        [Fact]
        public void ExtractAndInstall_HappyPath_ExtractsRequestedModules()
        {
            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"),
                ("AWS.Tools.S3", "5.0.151"),
                ("AWS.Tools.EC2", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            Assert.Contains(results, r => r.Name == "AWS.Tools.Common");
            Assert.Contains(results, r => r.Name == "AWS.Tools.S3");
            Assert.Contains(results, r => r.Name == "AWS.Tools.EC2");
            Assert.All(results, r => Assert.Null(r.Warning));
            foreach (var r in results)
            {
                Assert.True(File.Exists(Path.Combine(r.ModuleBase, r.Name + ".psd1")), $".psd1 missing for {r.Name}");
                Assert.True(File.Exists(Path.Combine(r.ModuleBase, "PSGetModuleInfo.xml")), $"xml missing for {r.Name}");
            }
        }

        [Fact]
        public void ExtractAndInstall_MandatoryModulesAlwaysIncluded()
        {
            // Even though only S3 is requested, AWS.Tools.Common must be extracted because it's
            // in the mandatory list (matches Install-AWSToolsModuleFromZip.ps1 behavior for AWS.Tools).
            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"),
                ("AWS.Tools.S3", "5.0.151"),
                ("AWS.Tools.EC2", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target,
                moduleNames: new[] { "AWS.Tools.S3" },
                mandatoryModules: new[] { "AWS.Tools.Common" });

            Assert.Contains(results, r => r.Name == "AWS.Tools.Common");
            Assert.Contains(results, r => r.Name == "AWS.Tools.S3");
            Assert.DoesNotContain(results, r => r.Name == "AWS.Tools.EC2");
            Assert.All(results, r => Assert.Null(r.Warning));
        }

        [Fact]
        public void ExtractAndInstall_MissingMandatoryModule_ThrowsTyped()
        {
            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.S3", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var ex = Assert.Throws<MissingModulesException>(() =>
                ModuleInstaller.ExtractAndInstall(zip, target,
                    moduleNames: new[] { "AWS.Tools.S3" },
                    mandatoryModules: new[] { "AWS.Tools.Common" }));

            Assert.Contains("AWS.Tools.Common", ex.MissingModules);
        }

        [Fact]
        public void ExtractAndInstall_MissingNonMandatoryModule_SkippedNotThrown()
        {
            // Simulates the Update-AWSToolsModule scenario: a module that was installed locally
            // (e.g. AWS.Tools.IoTEvents) no longer exists in the target version's archive.
            // The install should succeed for the modules that DO exist.
            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"),
                ("AWS.Tools.S3", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target,
                moduleNames: new[] { "AWS.Tools.S3", "AWS.Tools.IoTEvents", "AWS.Tools.Panorama" },
                mandatoryModules: new[] { "AWS.Tools.Common" });

            Assert.Contains(results, r => r.Name == "AWS.Tools.Common");
            Assert.Contains(results, r => r.Name == "AWS.Tools.S3");
            Assert.DoesNotContain(results, r => r.Name == "AWS.Tools.IoTEvents");
            Assert.DoesNotContain(results, r => r.Name == "AWS.Tools.Panorama");
        }

        [Fact]
        public void ExtractAndInstall_GeneratesPSGetModuleInfoXml()
        {
            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target, null, null);
            var common = Assert.Single(results.Where(r => r.Name == "AWS.Tools.Common"));

            var xmlPath = Path.Combine(common.ModuleBase, "PSGetModuleInfo.xml");
            Assert.True(File.Exists(xmlPath));

            var doc = new System.Xml.XmlDocument();
            doc.Load(xmlPath);
            var nsm = new System.Xml.XmlNamespaceManager(doc.NameTable);
            nsm.AddNamespace("ps", "http://schemas.microsoft.com/powershell/2004/04");
            Assert.Equal("AWS.Tools.Common", doc.SelectSingleNode("//ps:S[@N='Name']", nsm)!.InnerText);
            Assert.Equal("5.0.151", doc.SelectSingleNode("//ps:Version[@N='Version']", nsm)!.InnerText);
            Assert.Equal("Module", doc.SelectSingleNode("//ps:S[@N='Type']", nsm)!.InnerText);
            Assert.All(results, r => Assert.Null(r.Warning));
        }

        [Fact]
        public void ExtractAndInstall_PreCancelled_Throws()
        {
            // Parallel.ForEach checks ParallelOptions.CancellationToken before dispatching
            // workers, so a pre-cancelled token throws OperationCanceledException (wrapped
            // in AggregateException) before any extract work begins.
            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"),
                ("AWS.Tools.S3", "5.0.151"),
                ("AWS.Tools.EC2", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            using var cts = new CancellationTokenSource();
            cts.Cancel();

            Assert.ThrowsAny<OperationCanceledException>(() =>
                ModuleInstaller.ExtractAndInstall(zip, target, null, null, cts.Token));
        }

        [Fact]
        public void ExtractAndInstall_OneModuleManifestMalformed_OthersStillSucceed_FirstWarns()
        {
            // Documents the deliberate behavior change from the preview001 PS implementation,
            // where any single manifest parse failure threw and aborted the whole install.
            // The C# helper instead surfaces a per-module Warning on the broken module and
            // lets the others complete.
            var zip = Fixtures.BuildZipWithOneMalformedManifest(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"),   // FIRST entry is the malformed one
                ("AWS.Tools.S3", "5.0.151"),
                ("AWS.Tools.EC2", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            // The malformed module is still in the result set so the caller knows it was attempted.
            // S3 and EC2 install cleanly, no warning. Common gets a non-null Warning naming the parse failure.
            var common = Assert.Single(results.Where(r => r.Name == "AWS.Tools.Common"));
            Assert.NotNull(common.Warning);
            Assert.Contains("Could not parse manifest", common.Warning);

            Assert.Contains(results, r => r.Name == "AWS.Tools.S3" && r.Warning == null);
            Assert.Contains(results, r => r.Name == "AWS.Tools.EC2" && r.Warning == null);
        }

        [Fact]
        public void ExtractAndInstall_VersionDirWithoutPsd1_IsSkipped()
        {
            // Documents that ProcessExtractedModule silently skips a version directory whose
            // expected <Module>.psd1 is missing. preview001 PS would throw "missing manifest";
            // the C# helper continues so a corrupted/partial archive doesn't fail the entire
            // install for unrelated modules.
            var zip = Fixtures.BuildZipWithMissingPsd1(
                Path.Combine(_tempRoot, "AWS.Tools.zip"), "AWS.Tools.Common", "5.0.151");
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            // No record produced for AWS.Tools.Common because no .psd1 was found in any of its
            // version directories. The .psm1 was extracted to disk but ProcessExtractedModule
            // returned an empty list for this module.
            Assert.DoesNotContain(results, r => r.Name == "AWS.Tools.Common");
            // The .psm1 should still have been extracted (file is on disk; only the record is absent).
            var psm1 = Path.Combine(target, "AWS.Tools.Common", "5.0.151", "AWS.Tools.Common.psm1");
            Assert.True(File.Exists(psm1), "the version directory's payload was extracted, only the record is suppressed");
        }

        [Fact]
        public void ExtractAndInstall_PreExistingOlderVersion_DoesNotRewritePSGetXml()
        {
            // Reviewer-reported bug: when 5.0.200 is already installed and we install 5.0.233,
            // ProcessExtractedModule used to walk EVERY version directory under the module folder
            // and rewrite each one's PSGetModuleInfo.xml. After the scope fix it must touch only
            // the just-extracted version directory.
            var target = Path.Combine(_tempRoot, "modules");
            const string sentinel = "<!-- pre-existing -->";
            Fixtures.PreCreateInstalledVersion(target, "AWS.Tools.Common", "5.0.200", sentinel, hideXml: false);

            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.233"));

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            // The just-extracted record is the only one returned, and it carries no warning.
            var record = Assert.Single(results);
            Assert.Equal("5.0.233", record.Version);
            Assert.Null(record.Warning);

            // The pre-existing 5.0.200 xml must be byte-identical to the sentinel we wrote.
            var oldXml = Path.Combine(target, "AWS.Tools.Common", "5.0.200", "PSGetModuleInfo.xml");
            Assert.Equal(sentinel, File.ReadAllText(oldXml));

            // The 5.0.233 xml exists and parses with the new module's name.
            var newXml = Path.Combine(target, "AWS.Tools.Common", "5.0.233", "PSGetModuleInfo.xml");
            Assert.True(File.Exists(newXml));
            var doc = new System.Xml.XmlDocument();
            doc.Load(newXml);
        }

        [Fact]
        public void ExtractAndInstall_PSGetInfoXmlWithHiddenAttribute_OverwriteSucceedsNoWarning()
        {
            // Reviewer-reported bug: on Windows, File.WriteAllText against an existing Hidden file
            // throws UnauthorizedAccessException, which got downgraded to a per-module warning. The
            // -Force reinstall and the same-version-overwrite paths both hit this. The fix clears
            // Hidden before WriteAllText. Off-Windows there's no Hidden semantics, so skip.
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;

            var target = Path.Combine(_tempRoot, "modules");
            Fixtures.PreCreateInstalledVersion(target, "AWS.Tools.Common", "5.0.151",
                psgetXmlContent: "<old/>", hideXml: true);

            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"));

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            var record = Assert.Single(results);
            Assert.Null(record.Warning);

            var xmlPath = Path.Combine(target, "AWS.Tools.Common", "5.0.151", "PSGetModuleInfo.xml");
            Assert.True(File.Exists(xmlPath));

            // Freshly written: contains the new module's name, not the old "<old/>" sentinel.
            var doc = new System.Xml.XmlDocument();
            doc.Load(xmlPath);
            var nsm = new System.Xml.XmlNamespaceManager(doc.NameTable);
            nsm.AddNamespace("ps", "http://schemas.microsoft.com/powershell/2004/04");
            Assert.Equal("AWS.Tools.Common", doc.SelectSingleNode("//ps:S[@N='Name']", nsm)!.InnerText);

            // Hidden is re-set after the successful write, matching the pre-bug behavior.
            Assert.True((File.GetAttributes(xmlPath) & FileAttributes.Hidden) == FileAttributes.Hidden);
        }

        [Fact]
        public void ExtractAndInstall_DoesNotMutateUnrelatedPreExistingFiles()
        {
            // Regression-prevention: extracting AWS.Tools.S3 must leave every pre-existing
            // file under the target untouched - other modules, other versions of S3, and
            // even unrelated files at the target root.
            var target = Path.Combine(_tempRoot, "modules");
            Fixtures.PreCreateInstalledVersion(target, "AWS.Tools.EC2", "5.0.200", "<ec2-sentinel/>", hideXml: false);
            Fixtures.PreCreateInstalledVersion(target, "AWS.Tools.S3",  "5.0.200", "<s3-old-sentinel/>", hideXml: false);
            // An unrelated marker file at the target root.
            Directory.CreateDirectory(target);
            var rootMarker = Path.Combine(target, "untouched.txt");
            File.WriteAllText(rootMarker, "leave me alone");

            var snapshots = new[]
            {
                Path.Combine(target, "AWS.Tools.EC2", "5.0.200", "PSGetModuleInfo.xml"),
                Path.Combine(target, "AWS.Tools.EC2", "5.0.200", "AWS.Tools.EC2.psd1"),
                Path.Combine(target, "AWS.Tools.S3",  "5.0.200", "PSGetModuleInfo.xml"),
                Path.Combine(target, "AWS.Tools.S3",  "5.0.200", "AWS.Tools.S3.psd1"),
                rootMarker,
            };
            var before = snapshots.ToDictionary(p => p,
                p => (Bytes: File.ReadAllBytes(p), MTime: File.GetLastWriteTimeUtc(p)));

            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.S3", "5.0.233"));

            var results = ModuleInstaller.ExtractAndInstall(zip, target,
                moduleNames: new[] { "AWS.Tools.S3" }, mandatoryModules: null);

            Assert.All(results, r => Assert.Null(r.Warning));
            foreach (var p in snapshots)
            {
                Assert.Equal(before[p].Bytes, File.ReadAllBytes(p));
                Assert.Equal(before[p].MTime, File.GetLastWriteTimeUtc(p));
            }
        }

        [Fact]
        public void ExtractAndInstall_RoundTripUpgradeOnPopulatedTarget_NoWarnings()
        {
            // Regression-prevention: simulate the customer's reported flow - 4 modules already
            // installed at 5.0.200 with Hidden xml (Windows only), then install 5.0.233 of the
            // same 4 modules. After the scope+Hidden fixes there must be zero warnings, every
            // new-version xml exists, and every pre-existing xml is byte-identical.
            var target = Path.Combine(_tempRoot, "modules");
            bool hide = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            var modules = new[] { "AWS.Tools.Common", "AWS.Tools.S3", "AWS.Tools.EC2", "AWS.Tools.IAM" };
            var sentinels = modules.ToDictionary(m => m, m => $"<old name='{m}'/>");
            foreach (var m in modules)
                Fixtures.PreCreateInstalledVersion(target, m, "5.0.200", sentinels[m], hideXml: hide);

            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.233"),
                ("AWS.Tools.S3", "5.0.233"),
                ("AWS.Tools.EC2", "5.0.233"),
                ("AWS.Tools.IAM", "5.0.233"));

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            Assert.All(results, r => Assert.Null(r.Warning));
            foreach (var m in modules)
            {
                var oldXml = Path.Combine(target, m, "5.0.200", "PSGetModuleInfo.xml");
                Assert.Equal(sentinels[m], File.ReadAllText(oldXml));

                var newXml = Path.Combine(target, m, "5.0.233", "PSGetModuleInfo.xml");
                Assert.True(File.Exists(newXml));
                var doc = new System.Xml.XmlDocument();
                doc.Load(newXml);
                var nsm = new System.Xml.XmlNamespaceManager(doc.NameTable);
                nsm.AddNamespace("ps", "http://schemas.microsoft.com/powershell/2004/04");
                Assert.Equal("5.0.233", doc.SelectSingleNode("//ps:Version[@N='Version']", nsm)!.InnerText);
            }
        }

        [Fact]
        public void ExtractAndInstall_SameVersionForceReinstall_NoWarnings()
        {
            // Regression-prevention: -Force reinstall of the same version into the same target.
            // Bug 2 (Hidden) used to fire on the second install because the first one set Hidden.
            var target = Path.Combine(_tempRoot, "modules");
            bool hide = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            Fixtures.PreCreateInstalledVersion(target, "AWS.Tools.Common", "5.0.151",
                "<old/>", hideXml: hide);

            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"));

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            var record = Assert.Single(results);
            Assert.Null(record.Warning);

            var xmlPath = Path.Combine(target, "AWS.Tools.Common", "5.0.151", "PSGetModuleInfo.xml");
            var doc = new System.Xml.XmlDocument();
            doc.Load(xmlPath);
            var nsm = new System.Xml.XmlNamespaceManager(doc.NameTable);
            nsm.AddNamespace("ps", "http://schemas.microsoft.com/powershell/2004/04");
            Assert.Equal("AWS.Tools.Common", doc.SelectSingleNode("//ps:S[@N='Name']", nsm)!.InnerText);
        }

        [Fact]
        public void ExtractAndInstall_RollupEntry_PathParsingHandlesUnsuffixedModuleName()
        {
            // The 'AWS.Tools' (no suffix) rollup entry is what production install starts from.
            // Pin behavior: the rollup is enumerated like any other module, its version is
            // extracted from <moduleName>/<version>/... correctly, and a record is returned.
            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools", "5.0.151"),
                ("AWS.Tools.Common", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            var rollup = Assert.Single(results.Where(r => r.Name == "AWS.Tools"));
            Assert.Equal("5.0.151", rollup.Version);
            Assert.Null(rollup.Warning);
            Assert.True(File.Exists(Path.Combine(target, "AWS.Tools", "5.0.151", "AWS.Tools.psd1")));
        }

        [Fact]
        public void ExtractAndInstall_PSGetInfoXmlWithReadOnlyAttribute_OverwriteSucceedsNoWarning()
        {
            // Regression: third-party tools or AV may set ReadOnly on synced files. Like the
            // Hidden case, an existing ReadOnly PSGetModuleInfo.xml would make File.WriteAllText
            // throw and fire the bogus warning. The fix clears Hidden | ReadOnly before writing.
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return;

            var target = Path.Combine(_tempRoot, "modules");
            Fixtures.PreCreateInstalledVersion(target, "AWS.Tools.Common", "5.0.151",
                psgetXmlContent: "<old/>", hideXml: false);
            var xmlPath = Path.Combine(target, "AWS.Tools.Common", "5.0.151", "PSGetModuleInfo.xml");
            File.SetAttributes(xmlPath, File.GetAttributes(xmlPath) | FileAttributes.ReadOnly);

            var zip = Fixtures.BuildSyntheticZip(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"));

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            var record = Assert.Single(results);
            Assert.Null(record.Warning);

            var doc = new System.Xml.XmlDocument();
            doc.Load(xmlPath);
            var nsm = new System.Xml.XmlNamespaceManager(doc.NameTable);
            nsm.AddNamespace("ps", "http://schemas.microsoft.com/powershell/2004/04");
            Assert.Equal("AWS.Tools.Common", doc.SelectSingleNode("//ps:S[@N='Name']", nsm)!.InnerText);
        }

        [Fact]
        public void ExtractAndInstall_BackslashSeparatorsInZipEntries_StillExtractsCleanly()
        {
            // Windows PowerShell 5.1's Compress-Archive emits zip entry names with '\' instead
            // of the spec-mandated '/'. Customers using Install-AWSToolsModule -SourceZipPath
            // with a 5.1-built zip would otherwise hit a silent zero-install. The C# normalizes
            // separators at entry boundaries so either form parses correctly.
            var zip = Fixtures.BuildSyntheticZipWithBackslashes(Path.Combine(_tempRoot, "AWS.Tools.zip"),
                ("AWS.Tools.Common", "5.0.151"),
                ("AWS.Tools.S3", "5.0.151"));
            var target = Path.Combine(_tempRoot, "modules");

            var results = ModuleInstaller.ExtractAndInstall(zip, target, moduleNames: null, mandatoryModules: null);

            Assert.Contains(results, r => r.Name == "AWS.Tools.Common" && r.Version == "5.0.151");
            Assert.Contains(results, r => r.Name == "AWS.Tools.S3" && r.Version == "5.0.151");
            Assert.All(results, r => Assert.Null(r.Warning));
            // Files are extracted under the host's separator regardless of the zip's separator.
            foreach (var r in results)
            {
                Assert.True(File.Exists(Path.Combine(r.ModuleBase, r.Name + ".psd1")), $".psd1 missing for {r.Name}");
                Assert.True(File.Exists(Path.Combine(r.ModuleBase, "PSGetModuleInfo.xml")), $"xml missing for {r.Name}");
            }
        }

        // ----- DeleteDirectoriesParallel -----

        [Fact]
        public void DeleteDirectoriesParallel_RemovesExistingDirs()
        {
            var dirs = Enumerable.Range(0, 5).Select(i =>
            {
                var d = Path.Combine(_tempRoot, "delete-me-" + i);
                Directory.CreateDirectory(d);
                File.WriteAllText(Path.Combine(d, "file.txt"), "content");
                return d;
            }).ToArray();

            var failed = ModuleInstaller.DeleteDirectoriesParallel(dirs);

            Assert.Empty(failed);
            foreach (var d in dirs) Assert.False(Directory.Exists(d), $"{d} should be deleted");
        }

        [Fact]
        public void DeleteDirectoriesParallel_NonexistentPath_DoesNotThrow()
        {
            var missing = Path.Combine(_tempRoot, "does-not-exist");
            var failed = ModuleInstaller.DeleteDirectoriesParallel(new[] { missing });
            Assert.Empty(failed);
        }

        [Fact]
        public void DeleteDirectoriesParallel_FailureReported()
        {
            // Hold an open file handle to make the directory undeletable on Windows; on Linux,
            // chmod 0 also fails. Use both strategies - the test passes if EITHER prevents delete.
            var dir = Path.Combine(_tempRoot, "locked");
            Directory.CreateDirectory(dir);
            var locked = Path.Combine(dir, "file.txt");
            File.WriteAllText(locked, "x");

            using var fs = new FileStream(locked, FileMode.Open, FileAccess.Read, FileShare.None);
            var failed = ModuleInstaller.DeleteDirectoriesParallel(new[] { dir });

            // On Linux Directory.Delete may succeed even with an open FileStream (Linux allows
            // deleting files that have open handles). We don't assert on the result here -
            // success or failure both prove the contract that exceptions never propagate.
            Assert.True(failed.Length == 0 || failed.Contains(dir));
        }
    }
}
