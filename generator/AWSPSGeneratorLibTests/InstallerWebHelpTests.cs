using AWSPowerShellGenerator.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWSPSGeneratorLibTests
{
    /// <summary>
    /// Locks in the installer-docs versioning contract: the AWS.Tools.Installer reference docs
    /// are published to /powershell/installer/v{majorVersion}/reference/, where the version is
    /// read from the installer module manifest. These tests guard the parsing/derivation that
    /// makes the same implementation publish V1 today and V2 (once feature/installer-v2 merges)
    /// automatically, with no code change.
    /// </summary>
    [TestClass]
    public class InstallerWebHelpTests
    {
        [TestMethod]
        public void ExtractModuleVersion_ReadsTopLevelModuleVersion()
        {
            // Representative of modules/Installer/AWS.Tools.Installer.psd1 on mainline (V1).
            var manifest =
                "@{\r\n" +
                "    RootModule = 'AWS.Tools.Installer.psm1'\r\n" +
                "    ModuleVersion = '1.0.3'\r\n" +
                "}\r\n";

            Assert.AreEqual("1.0.3", WebHelpGenerator.ExtractModuleVersion(manifest));
        }

        [TestMethod]
        public void ExtractModuleVersion_PrefersTopLevelOverNestedRequiredModuleVersion()
        {
            // The manifest also contains a nested ModuleVersion inside RequiredModules; the
            // top-level declaration precedes it and must win.
            var manifest =
                "@{\r\n" +
                "    ModuleVersion = '1.0.3'\r\n" +
                "    RequiredModules = @(\r\n" +
                "        @{\r\n" +
                "            ModuleName = 'PowerShellGet';\r\n" +
                "            ModuleVersion = '2.2.1' }\r\n" +
                "    )\r\n" +
                "}\r\n";

            Assert.AreEqual("1.0.3", WebHelpGenerator.ExtractModuleVersion(manifest));
        }

        [TestMethod]
        public void ExtractModuleVersion_ReadsV2Manifest()
        {
            // feature/installer-v2 sets ModuleVersion = '2.0.1'; the same code must pick it up so
            // docs publish to installer/v2/reference/ on merge.
            var manifest = "@{\r\n    ModuleVersion = '2.0.1'\r\n}\r\n";

            Assert.AreEqual("2.0.1", WebHelpGenerator.ExtractModuleVersion(manifest));
        }

        [TestMethod]
        public void ExtractModuleVersion_ReturnsNullWhenMissingOrEmpty()
        {
            Assert.IsNull(WebHelpGenerator.ExtractModuleVersion("@{ RootModule = 'x.psm1' }"));
            Assert.IsNull(WebHelpGenerator.ExtractModuleVersion(""));
            Assert.IsNull(WebHelpGenerator.ExtractModuleVersion(null));
        }

        [TestMethod]
        public void GetInstallerMajorVersion_DerivesMajorSegment()
        {
            Assert.AreEqual("1", WebHelpGenerator.GetInstallerMajorVersion("1.0.3"));
            Assert.AreEqual("2", WebHelpGenerator.GetInstallerMajorVersion("2.0.1"));
            Assert.AreEqual("10", WebHelpGenerator.GetInstallerMajorVersion("10.2.0.0"));
            Assert.AreEqual(WebHelpGenerator.DefaultInstallerVersion.Split('.')[0],
                WebHelpGenerator.GetInstallerMajorVersion(WebHelpGenerator.DefaultInstallerVersion));
        }
    }
}
