using System;
using System.Collections.Generic;
using AWSPowerShellGenerator.ServiceConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml;
using AWSPowerShellGenerator;
using AWSPowerShellGenerator.Generators;
using Microsoft.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class YamlExampleGeneratorTests
    {
        [TestMethod]
        public void ValidYamlNoError()
        {
            var yamlGenerator = new YamlExampleGenerator(exampleMetadataRelativePaths: new string[] { "Valid/metadata" });
            yamlGenerator.Generate();
            Assert.AreEqual(yamlGenerator.ExamplesCache.Count, 3);
        }

        [TestMethod]
        public void InvalidCmdletNameInMetadataFileNameError()
        {
            YamlExampleGenerator yamlGenerator = new YamlExampleGenerator(exampleMetadataRelativePaths: new string[] { "InvalidCmdletNameinFileName/metadata" });
            try
            {
                yamlGenerator.Generate();
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("The cmdletname should be of Verb-Noun format but got NounVerb"));
            }
        }

        [TestMethod]
        public void InvalidMetadataFileNameError()
        {
            YamlExampleGenerator yamlGenerator = new YamlExampleGenerator(exampleMetadataRelativePaths: new string[] { "InvalidFileName/metadata" });
            try
            {
                yamlGenerator.Generate();
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("The following metadata file name is invalid"));
            }

        }

        [TestMethod]
        public void InvalidMetadataInvalidSchema()
        {
            YamlExampleGenerator yamlGenerator = new YamlExampleGenerator(exampleMetadataRelativePaths: new string[] { "InvalidSchema/metadata" });
            try
            {
                yamlGenerator.Generate();
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("Encountered 2 errors during generation"));
                Assert.IsTrue(e.Message.Contains("Invalid excerpt. Expected excerpt description to contain Example followed by a number or have '<emphasis role=\"bold\">Output:' or snippet_files"));
                Assert.IsTrue(e.Message.Contains("Invalid excerpt. First excerpt must be an example"));

            }
        }

        [TestMethod]
        [Ignore]
        // This is useful for viewing the generated xml for yaml.
        // Ignoring this since this is used for debugging only.
        public void ExportGeneratedExampleXml()
        {
            var yamlGenerator = new YamlExampleGenerator(rootPath: @"C:\git\ps-two\");
            yamlGenerator.Generate();
            Console.WriteLine(yamlGenerator.ExamplesCache.Count);
            var generatedXmlDirectory = @"C:\git\ps-one\ExampleXMLs\";
            foreach (var exampleXmlKV in yamlGenerator.ExamplesCache)
            {
                var fileName = exampleXmlKV.Key + ".xml";
                var filePath = Path.Combine(generatedXmlDirectory, fileName);
                var xmlDoc = exampleXmlKV.Value;

                using var sw = new StreamWriter(filePath, false, Encoding.UTF8);
                xmlDoc.Save(sw);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        [Ignore]
        // This is useful for viewing the generated xml for a single file.
        // Ignoring this since this is used for debugging only.
        public void DebugSingleFileYaml()
        {
            var yamlGenerator = new YamlExampleGenerator(rootPath: @"ps-two", exampleMetadataFiles: new List<string> { @"ec2_New-EC2InstanceExportTask_metadata.yaml" });
            yamlGenerator.Generate();
            Assert.IsTrue(yamlGenerator.ExamplesCache.Count == 1);
        }

    }

    internal class YamlExampleGenerator : HelpGeneratorBase
    {
        public new Dictionary<string, XmlDocument> ExamplesCache => base.ExamplesCache;
        public bool Verbose { set { base.Options.Verbose = false; } }

        public YamlExampleGenerator(string rootPath = @"./YamlData", string[] exampleMetadataRelativePaths = null, List<string> exampleMetadataFiles = null)
        {
            Options = new GeneratorOptions();
            Options.Verbose = false;
            if (rootPath != null)
                Options.RootPath = Path.GetFullPath(rootPath);


            if (exampleMetadataRelativePaths != null)
                ExampleMetadataRelativePaths = exampleMetadataRelativePaths;

            if (exampleMetadataFiles != null)
                ExampleMetadataFiles = exampleMetadataFiles;
        }

        protected override void GenerateHelper()
        {
            if (!ExampleMetadataFiles.Any())
                base.LoadExampleMetadataFiles();

            base.LoadExamplesCache();
        }
    }
}
