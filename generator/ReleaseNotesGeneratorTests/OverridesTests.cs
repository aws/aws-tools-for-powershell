using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSReleaseNotesGenerator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReleaseNotesGeneratorTests
{
    [TestClass]
    public class OverridesTests
    {
        [TestMethod]
        public void ParsingNoServiceConfigOverrides()
        {
            var overridesXML = string.Empty;
            var serviceLookup = Overrides.ParseServiceNounPrefixes(overridesXML, null);
            Assert.IsNotNull(serviceLookup);
            Assert.AreEqual(0, serviceLookup.Count);
        }

        [TestMethod]
        public void ParsingMultipleServiceWithValidConfigs()
        {
            var overridesXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Overrides>
  <Service>
    <FileVersion>0</FileVersion>
    <C2jFilename>es</C2jFilename>
    <ServiceOperations>	  
    </ServiceOperations>
  </Service>
  <Service>
    <FileVersion>0</FileVersion>
    <C2jFilename>dynamodb</C2jFilename>
    <ServiceOperations>	  
    </ServiceOperations>
  </Service>
</Overrides>             
            ";

            var configs = new List<string>
            {
                @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <FileVersion>0</FileVersion>
    <SkipCmdletGeneration>false</SkipCmdletGeneration>
    <C2jFilename>es</C2jFilename>
    <AssemblyName>Elasticsearch</AssemblyName>
    <ServiceNounPrefix>ES</ServiceNounPrefix>
    <ServiceName>Amazon Elasticsearch</ServiceName>
</ConfigModel>
                ",
                @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <FileVersion>0</FileVersion>
    <SkipCmdletGeneration>false</SkipCmdletGeneration>
    <C2jFilename>dynamodb</C2jFilename>
    <AssemblyName>DynamoDBv2</AssemblyName>
    <ServiceNounPrefix>DDB</ServiceNounPrefix>
    <ServiceName>Amazon DynamoDB</ServiceName>
</ConfigModel>
                "
            };

            var configIndex = 0;
            var serviceLookup = Overrides.ParseServiceNounPrefixes(overridesXML, (filetitle) =>
            {
                return configs[configIndex++];
            });
            Assert.IsNotNull(serviceLookup);
            Assert.AreEqual(2, serviceLookup.Count);
            Assert.IsTrue(serviceLookup.Contains("ES"));
            Assert.IsTrue(serviceLookup.Contains("DDB"));
        }

        [TestMethod]        
        public void ParsingMultipleServicesWithInvalidConfigsThrowsException()
        {
            var overridesXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Overrides>
  <Service>
    <FileVersion>0</FileVersion>
    <C2jFilename>es</C2jFilename>
    <ServiceOperations>	  
    </ServiceOperations>
  </Service>
  <Service>
    <FileVersion>0</FileVersion>
    <C2jFilename>dynamodb</C2jFilename>
    <ServiceOperations>	  
    </ServiceOperations>
  </Service>
</Overrides>             
            ";

            var configs = new List<string>
            {
                @"NOT VALID XML",
                @"NOT VALID XML"
            };

            Exception expectedException = null;
            try
            {
                var configIndex = 0;
                var serviceLookup = Overrides.ParseServiceNounPrefixes(overridesXML, (filetitle) =>
                {
                    return configs[configIndex++];
                });
            }
            catch (Exception e)
            {
                expectedException = e;
            }

            Assert.IsNotNull(expectedException);
            Assert.IsInstanceOfType(expectedException, typeof(AggregateException));
            var expectedAggregateException = (AggregateException)expectedException;
            Assert.AreEqual("Error(s) occurred while processing service configurations. (Error processing 'es': Data at the root level is invalid. Line 1, position 1.) (Error processing 'dynamodb': Data at the root level is invalid. Line 1, position 1.)", expectedAggregateException.Message);
            Assert.IsNotNull(expectedAggregateException.InnerExceptions);
            Assert.AreEqual(2, expectedAggregateException.InnerExceptions.Count);
        }

        [TestMethod]
        public void ParseTargetServiceC2jFilenames_NullOrEmpty_ReturnsEmpty()
        {
            Assert.AreEqual(0, Overrides.ParseTargetServiceC2jFilenames(null).Count());
            Assert.AreEqual(0, Overrides.ParseTargetServiceC2jFilenames(string.Empty).Count());
            Assert.AreEqual(0, Overrides.ParseTargetServiceC2jFilenames("   ").Count());
        }

        [TestMethod]
        public void ParseTargetServiceC2jFilenames_SingleFilename()
        {
            var filenames = Overrides.ParseTargetServiceC2jFilenames("bedrock-agent-runtime").ToList();
            Assert.AreEqual(1, filenames.Count);
            Assert.AreEqual("bedrock-agent-runtime", filenames[0]);
        }

        [TestMethod]
        public void ParseTargetServiceC2jFilenames_MultipleFilenamesTrimmedAndEmptyEntriesIgnored()
        {
            var filenames = Overrides.ParseTargetServiceC2jFilenames(" bedrock-agent-runtime , ec2 ,,  s3 ").ToList();
            CollectionAssert.AreEqual(new List<string> { "bedrock-agent-runtime", "ec2", "s3" }, filenames);
        }

        [TestMethod]
        public void ResolveServiceNounPrefixes_ResolvesC2jFilenamesToNounPrefixes()
        {
            var config = @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <C2jFilename>bedrock-agent-runtime</C2jFilename>
    <AssemblyName>BedrockAgentRuntime</AssemblyName>
    <ServiceNounPrefix>BAR</ServiceNounPrefix>
    <ServiceName>Amazon Bedrock Agent Runtime</ServiceName>
</ConfigModel>";

            var nounPrefixes = Overrides.ResolveServiceNounPrefixes(
                new List<string> { "bedrock-agent-runtime" },
                (filetitle) => config);

            Assert.AreEqual(1, nounPrefixes.Count);
            Assert.IsTrue(nounPrefixes.Contains("BAR"));
        }
    }
}
