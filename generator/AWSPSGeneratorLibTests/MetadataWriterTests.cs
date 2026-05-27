using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Writers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class MetadataWriterTests
    {
        private string _tempDir;

        [TestInitialize]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDir);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Directory.Exists(_tempDir))
                Directory.Delete(_tempDir, true);
        }

        [TestMethod]
        public void WriteCmdletMetadata_EmptyServices_ProducesValidJson()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();
            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");

            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "0.0.0.0");

            Assert.IsTrue(File.Exists(outputPath));
            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            Assert.AreEqual("0.0.0.0", json.RootElement.GetProperty("version").GetString());
            Assert.AreEqual(0, json.RootElement.GetProperty("services").EnumerateObject().ToList().Count);
        }

        [TestMethod]
        public void WriteCmdletMetadata_VersionPassthrough()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();
            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");

            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "5.0.100.0");

            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            Assert.AreEqual("5.0.100.0", json.RootElement.GetProperty("version").GetString());
        }

        [TestMethod]
        public void WriteCmdletMetadata_AdvancedCmdlet_SingleOperation()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();

            var cmdletInfo = new AdvancedCmdletInfo();
            cmdletInfo.OperationNames.Add("DescribeCmdlets");
            cmdletInfo.Parameters.Add(new AdvancedParameterInfo
            {
                Name = "CmdletName",
                Type = "System.String",
                Mandatory = true
            });
            commonCmdlets["Get-AWSCmdletName"] = cmdletInfo;

            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");
            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "0.0.0.0");

            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            var common = json.RootElement.GetProperty("services").GetProperty("Common");
            Assert.AreEqual("AWS.Tools.Common", common.GetProperty("moduleName").GetString());

            var cmdlet = common.GetProperty("cmdlets").GetProperty("Get-AWSCmdletName");
            Assert.AreEqual("DescribeCmdlets", cmdlet.GetProperty("apiOperation").GetString());
            Assert.IsTrue(cmdlet.GetProperty("advanced").GetBoolean());

            var param = cmdlet.GetProperty("parameters").GetProperty("CmdletName");
            Assert.AreEqual("System.String", param.GetProperty("type").GetString());
            Assert.IsTrue(param.GetProperty("mandatory").GetBoolean());
        }

        [TestMethod]
        public void WriteCmdletMetadata_AdvancedCmdlet_MultipleOperations()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();

            var cmdletInfo = new AdvancedCmdletInfo();
            cmdletInfo.OperationNames.Add("PutObject");
            cmdletInfo.OperationNames.Add("InitiateMultipartUpload");
            cmdletInfo.OperationNames.Add("UploadPart");
            commonCmdlets["Write-S3Object"] = cmdletInfo;

            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");
            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "0.0.0.0");

            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            var cmdlet = json.RootElement.GetProperty("services").GetProperty("Common")
                .GetProperty("cmdlets").GetProperty("Write-S3Object");

            Assert.AreEqual(JsonValueKind.Array, cmdlet.GetProperty("apiOperation").ValueKind);
            Assert.AreEqual(3, cmdlet.GetProperty("apiOperation").GetArrayLength());
            Assert.AreEqual("PutObject", cmdlet.GetProperty("apiOperation")[0].GetString());
        }

        [TestMethod]
        public void WriteCmdletMetadata_AdvancedCmdlet_NoOperation()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();

            var cmdletInfo = new AdvancedCmdletInfo();
            cmdletInfo.Parameters.Add(new AdvancedParameterInfo
            {
                Name = "Region",
                Type = "System.String"
            });
            commonCmdlets["Set-DefaultAWSRegion"] = cmdletInfo;

            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");
            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "0.0.0.0");

            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            var cmdlet = json.RootElement.GetProperty("services").GetProperty("Common")
                .GetProperty("cmdlets").GetProperty("Set-DefaultAWSRegion");

            // apiOperation should be absent when there are no operations
            Assert.IsFalse(cmdlet.TryGetProperty("apiOperation", out _));
        }

        [TestMethod]
        public void WriteCmdletMetadata_AdvancedCmdlet_Deprecated()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();

            var cmdletInfo = new AdvancedCmdletInfo();
            cmdletInfo.IsDeprecated = true;
            cmdletInfo.OperationNames.Add("OldOperation");
            commonCmdlets["Get-OldCmdlet"] = cmdletInfo;

            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");
            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "0.0.0.0");

            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            var cmdlet = json.RootElement.GetProperty("services").GetProperty("Common")
                .GetProperty("cmdlets").GetProperty("Get-OldCmdlet");

            Assert.IsTrue(cmdlet.GetProperty("deprecated").GetBoolean());
        }

        [TestMethod]
        public void WriteCmdletMetadata_AdvancedCmdlet_ConstantClassParameter()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();

            var cmdletInfo = new AdvancedCmdletInfo();
            cmdletInfo.OperationNames.Add("DoSomething");
            cmdletInfo.Parameters.Add(new AdvancedParameterInfo
            {
                Name = "InstanceType",
                Type = "Amazon.EC2.InstanceType",
                ConstantClass = "Amazon.EC2.InstanceType"
            });
            commonCmdlets["Test-Cmdlet"] = cmdletInfo;

            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");
            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "0.0.0.0");

            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            var param = json.RootElement.GetProperty("services").GetProperty("Common")
                .GetProperty("cmdlets").GetProperty("Test-Cmdlet")
                .GetProperty("parameters").GetProperty("InstanceType");

            Assert.AreEqual("Amazon.EC2.InstanceType", param.GetProperty("constantClass").GetString());
        }

        [TestMethod]
        public void WriteCmdletMetadata_SparseFields_OmitsDefaults()
        {
            var services = new List<ConfigModel>();
            var commonCmdlets = new Dictionary<string, AdvancedCmdletInfo>();

            var cmdletInfo = new AdvancedCmdletInfo();
            cmdletInfo.OperationNames.Add("ListItems");
            cmdletInfo.Parameters.Add(new AdvancedParameterInfo
            {
                Name = "Filter",
                Type = "System.String"
            });
            commonCmdlets["Get-Items"] = cmdletInfo;

            var outputPath = Path.Combine(_tempDir, "cmdlet-metadata.json");
            MetadataWriter.WriteCmdletMetadata(services, commonCmdlets, outputPath, "0.0.0.0");

            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            var param = json.RootElement.GetProperty("services").GetProperty("Common")
                .GetProperty("cmdlets").GetProperty("Get-Items")
                .GetProperty("parameters").GetProperty("Filter");

            Assert.AreEqual("System.String", param.GetProperty("type").GetString());
            Assert.IsFalse(param.TryGetProperty("mandatory", out _));
            Assert.IsFalse(param.TryGetProperty("constantClass", out _));
            Assert.IsFalse(param.TryGetProperty("deprecated", out _));
        }

        [TestMethod]
        public void WriteConstantClasses_EmptyServices_ProducesValidJson()
        {
            var services = new List<ConfigModel>();
            var outputPath = Path.Combine(_tempDir, "constant-classes.json");

            MetadataWriter.WriteConstantClasses(services, outputPath, "0.0.0.0");

            Assert.IsTrue(File.Exists(outputPath));
            var json = JsonDocument.Parse(File.ReadAllText(outputPath));
            Assert.AreEqual("0.0.0.0", json.RootElement.GetProperty("version").GetString());
            Assert.AreEqual(0, json.RootElement.GetProperty("classes").EnumerateObject().ToList().Count);
        }
    }
}
