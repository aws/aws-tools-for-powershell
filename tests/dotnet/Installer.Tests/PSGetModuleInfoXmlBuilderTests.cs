using System;
using System.IO;
using System.Linq;
using System.Xml;
using Xunit;

namespace Amazon.PowerShell.Installer.Tests
{
    public class PSGetModuleInfoXmlBuilderTests : IDisposable
    {
        private readonly string _tempRoot;

        public PSGetModuleInfoXmlBuilderTests()
        {
            _tempRoot = Fixtures.NewTempDir("psgmi-tests");
        }

        public void Dispose()
        {
            try { if (Directory.Exists(_tempRoot)) Directory.Delete(_tempRoot, recursive: true); }
            catch { }
        }

        private static string Generate(string psd1Path, string normalizedVersion, string installedLocation)
            => PSGetModuleInfoXmlBuilder.Generate(psd1Path, normalizedVersion, installedLocation);

        private static XmlNamespaceManager Ns(XmlDocument doc)
        {
            var nsm = new XmlNamespaceManager(doc.NameTable);
            nsm.AddNamespace("ps", "http://schemas.microsoft.com/powershell/2004/04");
            return nsm;
        }

        // ----- Critical scalar fields -----

        [Fact]
        public void Emits_CriticalScalarFields()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151",
                cmdletsToExport: new[] { "Get-S3Object" });

            var xml = Generate(psd1, "5.0.151", "/install/AWS.Tools.S3/5.0.151");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            Assert.Equal("AWS.Tools.S3", doc.SelectSingleNode("//ps:S[@N='Name']", nsm)!.InnerText);
            Assert.Equal("5.0.151", doc.SelectSingleNode("//ps:Version[@N='Version']", nsm)!.InnerText);
            Assert.Equal("Module", doc.SelectSingleNode("//ps:S[@N='Type']", nsm)!.InnerText);
            Assert.Equal("Amazon.com Inc", doc.SelectSingleNode("//ps:S[@N='Author']", nsm)!.InnerText);
            Assert.Equal("aws-dotnet-sdk-team", doc.SelectSingleNode("//ps:S[@N='CompanyName']", nsm)!.InnerText);
            Assert.Equal("/install/AWS.Tools.S3/5.0.151", doc.SelectSingleNode("//ps:S[@N='InstalledLocation']", nsm)!.InnerText);
            Assert.Equal("PSGallery", doc.SelectSingleNode("//ps:S[@N='Repository']", nsm)!.InnerText);
            Assert.Equal("NuGet", doc.SelectSingleNode("//ps:S[@N='PackageManagementProvider']", nsm)!.InnerText);
        }

        [Fact]
        public void Emits_PSDataUris()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151");

            var xml = Generate(psd1, "5.0.151", "/x");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            Assert.Equal("https://aws.amazon.com/apache-2-0/",
                doc.SelectSingleNode("//ps:URI[@N='LicenseUri']", nsm)!.InnerText);
            Assert.Equal("https://github.com/aws/aws-tools-for-powershell",
                doc.SelectSingleNode("//ps:URI[@N='ProjectUri']", nsm)!.InnerText);
            Assert.Contains("AWSLogo128x128.png",
                doc.SelectSingleNode("//ps:URI[@N='IconUri']", nsm)!.InnerText);
        }

        // ----- Tags -----

        [Fact]
        public void Tags_IncludesPSDataTagsAndPSModule()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151",
                tags: new[] { "AWS", "cloud", "Custom" });

            var xml = Generate(psd1, "5.0.151", "/x");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            var tags = doc.SelectNodes("//ps:Obj[@N='Tags']/ps:LST/ps:S", nsm)!
                .Cast<XmlNode>().Select(n => n.InnerText).ToList();

            Assert.Contains("AWS", tags);
            Assert.Contains("cloud", tags);
            Assert.Contains("Custom", tags);
            Assert.Contains("PSModule", tags);
        }

        // ----- Includes/Cmdlet -----

        [Fact]
        public void Includes_ListsAllCmdlets()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151",
                cmdletsToExport: new[] { "Get-S3Object", "Set-S3Object", "Remove-S3Object" });

            var xml = Generate(psd1, "5.0.151", "/x");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            var cmdlets = doc.SelectNodes(
                "//ps:Obj[@N='Includes']/ps:DCT/ps:En[ps:S[@N='Key']/text()='Cmdlet']/ps:Obj/ps:LST/ps:S", nsm)!
                .Cast<XmlNode>().Select(n => n.InnerText).ToList();

            Assert.Contains("Get-S3Object", cmdlets);
            Assert.Contains("Set-S3Object", cmdlets);
            Assert.Contains("Remove-S3Object", cmdlets);
        }

        // ----- Dependencies -----

        [Fact]
        public void Dependencies_HashtableForm_EmitsNameVersionCanonicalId()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151",
                requiredModules: new[] { ("PowerShellGet", "2.2.1") });

            var xml = Generate(psd1, "5.0.151", "/x");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            var names = doc.SelectNodes(
                "//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En[ps:S[@N='Key']/text()='Name']/ps:S[@N='Value']", nsm)!
                .Cast<XmlNode>().Select(n => n.InnerText).ToList();
            var versions = doc.SelectNodes(
                "//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En[ps:S[@N='Key']/text()='RequiredVersion']/ps:S[@N='Value']", nsm)!
                .Cast<XmlNode>().Select(n => n.InnerText).ToList();
            var canonical = doc.SelectNodes(
                "//ps:Obj[@N='Dependencies']/ps:LST/ps:Obj/ps:DCT/ps:En[ps:S[@N='Key']/text()='CanonicalId']/ps:S[@N='Value']", nsm)!
                .Cast<XmlNode>().Select(n => n.InnerText).ToList();

            Assert.Contains("PowerShellGet", names);
            Assert.Contains("2.2.1", versions);
            Assert.Contains("nuget:PowerShellGet/[2.2.1]", canonical);
        }

        // ----- AdditionalMetadata -----

        [Fact]
        public void AdditionalMetadata_TagsString_HasPerCmdletEntries()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151",
                cmdletsToExport: new[] { "Get-S3Object" });

            var xml = Generate(psd1, "5.0.151", "/x");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            var tagsNode = doc.SelectSingleNode(
                "//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='tags']", nsm);
            Assert.NotNull(tagsNode);
            Assert.Contains("PSCmdlet_Get-S3Object", tagsNode!.InnerText);
            Assert.Contains("PSCommand_Get-S3Object", tagsNode.InnerText);
            Assert.Contains("PSIncludes_Cmdlet", tagsNode.InnerText);
            Assert.Contains("PSModule", tagsNode.InnerText);
        }

        [Fact]
        public void AdditionalMetadata_EmitsGuidAndNormalizedVersion()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151",
                guid: "11111111-2222-3333-4444-555555555555");

            var xml = Generate(psd1, "5.0.151", "/x");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            Assert.Equal("11111111-2222-3333-4444-555555555555",
                doc.SelectSingleNode("//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='GUID']", nsm)!.InnerText);
            Assert.Equal("5.0.151",
                doc.SelectSingleNode("//ps:Obj[@N='AdditionalMetadata']/ps:MS/ps:S[@N='NormalizedVersion']", nsm)!.InnerText);
        }

        // ----- Author normalization -----

        [Fact]
        public void Author_CommaIncSuffix_IsReplacedWithSpaceInc()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            Fixtures.WriteManifest(psd1, "AWS.Tools.S3", "5.0.151", author: "Amazon.com, Inc");

            var xml = Generate(psd1, "5.0.151", "/x");
            var doc = new XmlDocument(); doc.LoadXml(xml);
            var nsm = Ns(doc);

            Assert.Equal("Amazon.com Inc", doc.SelectSingleNode("//ps:S[@N='Author']", nsm)!.InnerText);
        }

        // ----- Description CRLF encoding -----

        [Fact]
        public void Description_CRLF_EncodedAsX000DX000A()
        {
            var psd1 = Path.Combine(_tempRoot, "AWS.Tools.S3.psd1");
            // Embed a literal CRLF in the description by using a here-string in the .psd1.
            File.WriteAllText(psd1, @"@{
    ModuleVersion = '5.0.151'
    GUID = '00000000-0000-0000-0000-000000000000'
    Author = 'Amazon'
    CompanyName = 'Amazon'
    Description = ""Line one`r`nLine two""
    Copyright = '(c)'
    CmdletsToExport = @()
    PrivateData = @{ PSData = @{ Tags = @('AWS') } }
}");
            var xml = Generate(psd1, "5.0.151", "/x");
            Assert.Contains("_x000D__x000A_", xml);
        }
    }
}
