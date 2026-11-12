using AWSPowerShellGenerator.ServiceConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class XmlOverridesMergerTests
    {
        /// <summary>
        /// Verifies that an overrides.xml that isn't valid XML results in an error
        /// </summary>
        [TestMethod]
        public void InvalidXMLReturnsError()
        {
            string errorMessage;
            XmlOverridesMerger.ReadOverrides(Path.GetFullPath("XmlTests/InvalidXML"), out errorMessage);

            Assert.IsNotNull(errorMessage);
            Assert.IsTrue(errorMessage.Contains("Error deserializing the provided override file"));
        }

        /// <summary>
        /// Verifies that an overrides.xml that fails schema validation results in an error
        /// </summary>
        [TestMethod]
        public void InvalidSchemaReturnsError()
        {
            string errorMessage;
            XmlOverridesMerger.ReadOverrides(Path.GetFullPath("XmlTests/InvalidSchema"), out errorMessage);

            Assert.IsNotNull(errorMessage);
            Assert.IsTrue(errorMessage.Contains("The required attribute 'PipelineParameter' is missing"));
        }

        /// <summary>
        /// Verifies that a valid overrides.xml doesn't result in an error
        /// </summary>
        [TestMethod]
        public void ValidOverridesNoError()
        {
            string errorMessage;
            XmlOverridesMerger.ReadOverrides(Path.GetFullPath("XmlTests/Valid"), out errorMessage);

            Assert.IsNull(errorMessage);
        }

        /// <summary>
        /// Verifies that RemoveMarkedOperations removes operations with Remove="true"
        /// and keeps operations without the attribute.
        /// </summary>
        [TestMethod]
        public void RemoveMarkedOperations_RemovesOperationsWithRemoveTrue()
        {
            var doc = new XmlDocument();
            doc.LoadXml(@"<Service>
                <ServiceOperations>
                    <ServiceOperation MethodName=""GetItem"" Verb=""Get"" Noun=""Item"" PipelineParameter="""" NoPipelineParameter=""true"" />
                    <ServiceOperation MethodName=""DeleteItem"" Verb=""Remove"" Noun=""Item"" PipelineParameter="""" NoPipelineParameter=""true"" Remove=""true"" />
                    <ServiceOperation MethodName=""CreateItem"" Verb=""New"" Noun=""Item"" PipelineParameter="""" NoPipelineParameter=""true"" />
                </ServiceOperations>
            </Service>");

            XmlOverridesMerger.RemoveMarkedOperations(doc.DocumentElement);

            var ops = doc.GetElementsByTagName("ServiceOperation").OfType<XmlElement>().ToList();
            Assert.AreEqual(2, ops.Count);
            Assert.AreEqual("GetItem", ops[0].GetAttribute("MethodName"));
            Assert.AreEqual("CreateItem", ops[1].GetAttribute("MethodName"));
        }

        /// <summary>
        /// Verifies that RemoveMarkedOperations does nothing when no operations have Remove="true".
        /// </summary>
        [TestMethod]
        public void RemoveMarkedOperations_KeepsAllWhenNoneMarked()
        {
            var doc = new XmlDocument();
            doc.LoadXml(@"<Service>
                <ServiceOperations>
                    <ServiceOperation MethodName=""GetItem"" Verb=""Get"" Noun=""Item"" PipelineParameter="""" NoPipelineParameter=""true"" />
                    <ServiceOperation MethodName=""CreateItem"" Verb=""New"" Noun=""Item"" PipelineParameter="""" NoPipelineParameter=""true"" />
                </ServiceOperations>
            </Service>");

            XmlOverridesMerger.RemoveMarkedOperations(doc.DocumentElement);

            var ops = doc.GetElementsByTagName("ServiceOperation").OfType<XmlElement>().ToList();
            Assert.AreEqual(2, ops.Count);
        }

        /// <summary>
        /// Verifies that RemoveMarkedOperations handles a service with no ServiceOperations element.
        /// </summary>
        [TestMethod]
        public void RemoveMarkedOperations_NoServiceOperationsElement_DoesNotThrow()
        {
            var doc = new XmlDocument();
            doc.LoadXml(@"<Service></Service>");

            XmlOverridesMerger.RemoveMarkedOperations(doc.DocumentElement);
        }

        private const string ServiceNameOverrideConfig = "eks-auth";

        /// <summary>
        /// Verifies that an override with only FileVersion, C2jFilename, ServiceName and an empty ServiceOperations
        /// updates the ServiceName of an existing service and leaves the rest of its configuration unchanged.
        /// </summary>
        [TestMethod]
        public void ApplyOverrides_ServiceName_UpdatesOnlyServiceName()
        {
            var folder = CreateServiceNameOverrideFolder(fileVersion: 0, extraElement: null);
            try
            {
                var configPath = Path.Combine(folder, "ServiceConfig", $"{ServiceNameOverrideConfig}.xml");
                var before = LoadConfig(configPath);
                var beforeLines = ReadLines(configPath);

                XmlOverridesMerger.ApplyOverrides(folder, Path.Combine(folder, "ServiceConfig"));

                var after = LoadConfig(configPath);
                Assert.AreEqual("AWS EKS Auth", after.ServiceName);
                before.ServiceName = after.ServiceName;
                before.ServiceOperationsList = before.ServiceOperationsList.OrderBy(so => so.MethodName).ToList();
                Assert.AreEqual(SerializeConfig(before), SerializeConfig(after));

                // The file itself changes on the ServiceName line only. Line endings are compared apart: the
                // serializer writes Environment.NewLine, so a CRLF config is rewritten as LF on Linux.
                var afterLines = ReadLines(configPath);
                Assert.AreEqual(beforeLines.Length, afterLines.Length);
                var changed = Enumerable.Range(0, beforeLines.Length).Where(i => beforeLines[i] != afterLines[i]).ToList();
                Assert.AreEqual(1, changed.Count);
                Assert.AreEqual("    <ServiceName>AWS EKS Auth</ServiceName>", afterLines[changed[0]]);
            }
            finally
            {
                Directory.Delete(folder, true);
            }
        }

        private static string[] ReadLines(string path)
        {
            return File.ReadAllText(path).Replace("\r\n", "\n").TrimEnd('\n').Split('\n');
        }

        /// <summary>
        /// Verifies that a ServiceName override is skipped, like any override, when its FileVersion doesn't match.
        /// </summary>
        [TestMethod]
        public void ApplyOverrides_ServiceNameWithOtherFileVersion_LeavesConfigUnchanged()
        {
            var folder = CreateServiceNameOverrideFolder(fileVersion: 1, extraElement: null);
            try
            {
                var configPath = Path.Combine(folder, "ServiceConfig", $"{ServiceNameOverrideConfig}.xml");
                var before = File.ReadAllBytes(configPath);

                XmlOverridesMerger.ApplyOverrides(folder, Path.Combine(folder, "ServiceConfig"));

                CollectionAssert.AreEqual(before, File.ReadAllBytes(configPath));
            }
            finally
            {
                Directory.Delete(folder, true);
            }
        }

        /// <summary>
        /// Verifies that the identifiers of an existing service still can't be changed through overrides.
        /// </summary>
        [TestMethod]
        public void ApplyOverrides_ServiceNounPrefix_IsStillRejected()
        {
            var folder = CreateServiceNameOverrideFolder(fileVersion: 0, extraElement: "<ServiceNounPrefix>EKSX</ServiceNounPrefix>");
            try
            {
                Assert.ThrowsException<NotSupportedException>(() =>
                    XmlOverridesMerger.ApplyOverrides(folder, Path.Combine(folder, "ServiceConfig")));
            }
            finally
            {
                Directory.Delete(folder, true);
            }
        }

        /// <summary>
        /// Creates a folder laid out like the generator's root: overrides.xml, the overrides schema, and
        /// ServiceConfig/ with a copy of a real service configuration.
        /// </summary>
        private static string CreateServiceNameOverrideFolder(int fileVersion, string extraElement)
        {
            var folder = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            CopyDirectory(Path.GetFullPath("XmlTests/Valid/XmlSchemas"), Path.Combine(folder, "XmlSchemas"));
            Directory.CreateDirectory(Path.Combine(folder, "ServiceConfig"));
            File.Copy(Path.GetFullPath($"XmlTests/ServiceNameOverride/{ServiceNameOverrideConfig}.xml"),
                      Path.Combine(folder, "ServiceConfig", $"{ServiceNameOverrideConfig}.xml"));
            File.WriteAllText(Path.Combine(folder, "overrides.xml"), $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Overrides>
  <Service>
    <FileVersion>{fileVersion}</FileVersion>
    <C2jFilename>{ServiceNameOverrideConfig}</C2jFilename>
    <ServiceName>AWS EKS Auth</ServiceName>
    {extraElement}
    <ServiceOperations />
  </Service>
</Overrides>");
            return folder;
        }

        private static void CopyDirectory(string source, string destination)
        {
            foreach (var file in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
            {
                var target = Path.Combine(destination, Path.GetRelativePath(source, file));
                Directory.CreateDirectory(Path.GetDirectoryName(target));
                File.Copy(file, target);
            }
        }

        private static ConfigModel LoadConfig(string path)
        {
            using (var reader = File.OpenRead(path))
            {
                return (ConfigModel)new XmlSerializer(typeof(ConfigModel)).Deserialize(reader);
            }
        }

        private static string SerializeConfig(ConfigModel config)
        {
            using (var writer = new StringWriter())
            {
                new XmlSerializer(typeof(ConfigModel)).Serialize(writer, config);
                return writer.ToString();
            }
        }
    }
}
