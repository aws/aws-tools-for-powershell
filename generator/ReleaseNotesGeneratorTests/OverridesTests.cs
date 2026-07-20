using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSReleaseNotesGenerator;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void ParseTargetServiceAssemblyNames_NullOrEmpty_ReturnsEmpty()
        {
            Assert.AreEqual(0, Overrides.ParseTargetServiceAssemblyNames(null).Count());
            Assert.AreEqual(0, Overrides.ParseTargetServiceAssemblyNames(string.Empty).Count());
            Assert.AreEqual(0, Overrides.ParseTargetServiceAssemblyNames("   ").Count());
        }

        [TestMethod]
        public void ParseTargetServiceAssemblyNames_SingleAssemblyName()
        {
            var names = Overrides.ParseTargetServiceAssemblyNames("PrometheusService").ToList();
            Assert.AreEqual(1, names.Count);
            Assert.AreEqual("PrometheusService", names[0]);
        }

        [TestMethod]
        public void ParseTargetServiceAssemblyNames_MultipleNamesTrimmedAndEmptyEntriesIgnored()
        {
            var names = Overrides.ParseTargetServiceAssemblyNames(" PrometheusService , DynamoDBStreams ,,  EC2 ").ToList();
            CollectionAssert.AreEqual(new List<string> { "PrometheusService", "DynamoDBStreams", "EC2" }, names);
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

        [TestMethod]
        public void ResolveServiceNounPrefixesByAssemblyName_ResolvesByInternalAssemblyName()
        {
            // aps.xml: the .NET C2J model / assembly is "PrometheusService" but the PowerShell C2jFilename
            // is "aps", and dynamodbstreams.xml's file name differs from its internal <C2jFilename>. The
            // target path resolves by the internal <AssemblyName>, so both resolve.
            var tempDir = Path.Combine(Path.GetTempPath(), "rng-asm-test-" + Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            try
            {
                File.WriteAllText(Path.Combine(tempDir, "aps.xml"), @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <C2jFilename>aps</C2jFilename>
    <AssemblyName>PrometheusService</AssemblyName>
    <ServiceNounPrefix>PROM</ServiceNounPrefix>
</ConfigModel>");
                File.WriteAllText(Path.Combine(tempDir, "dynamodbstreams.xml"), @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <C2jFilename>streams.dynamodb</C2jFilename>
    <AssemblyName>DynamoDBStreams</AssemblyName>
    <ServiceNounPrefix>DDBS</ServiceNounPrefix>
</ConfigModel>");

                var nounPrefixes = Overrides.ResolveServiceNounPrefixesByAssemblyName(
                    new List<string> { "PrometheusService", "DynamoDBStreams" },
                    tempDir,
                    new HashSet<string>());

                Assert.AreEqual(2, nounPrefixes.Count);
                Assert.IsTrue(nounPrefixes.Contains("PROM"));
                Assert.IsTrue(nounPrefixes.Contains("DDBS"));
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ResolveServiceNounPrefixesByAssemblyName_MatchesAssemblyNameCaseInsensitively()
        {
            // The AssemblyName is user/build-supplied and travels through several build steps, so a
            // casing difference from the config's <AssemblyName> must not cause the target service to
            // be missed. AssemblyNames are unique even case-insensitively, so this cannot mis-match.
            var tempDir = Path.Combine(Path.GetTempPath(), "rng-asm-case-test-" + Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            try
            {
                File.WriteAllText(Path.Combine(tempDir, "aps.xml"), @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <C2jFilename>aps</C2jFilename>
    <AssemblyName>PrometheusService</AssemblyName>
    <ServiceNounPrefix>PROM</ServiceNounPrefix>
</ConfigModel>");

                var nounPrefixes = Overrides.ResolveServiceNounPrefixesByAssemblyName(
                    new List<string> { "prometheusservice" },
                    tempDir,
                    new HashSet<string>());

                Assert.AreEqual(1, nounPrefixes.Count);
                Assert.IsTrue(nounPrefixes.Contains("PROM"));
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ResolveServiceNounPrefixesByAssemblyName_NullEnumerable_ReturnsEmpty()
        {
            var nounPrefixes = Overrides.ResolveServiceNounPrefixesByAssemblyName(null, Path.GetTempPath(), new HashSet<string>());
            Assert.AreEqual(0, nounPrefixes.Count);
        }

        [TestMethod]
        public void ResolveServiceNounPrefixesByAssemblyName_SkippedService_WarnsAndSkipsWithoutThrowing()
        {
            // A target AssemblyName that has no service configuration but is intentionally skipped from
            // PowerShell (Configs.xml IncludeLibraries) has no cmdlets and no breaking changes, so it is
            // skipped without throwing; the configured service still resolves.
            var tempDir = Path.Combine(Path.GetTempPath(), "rng-asm-skip-test-" + Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            try
            {
                File.WriteAllText(Path.Combine(tempDir, "aps.xml"), @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <C2jFilename>aps</C2jFilename>
    <AssemblyName>PrometheusService</AssemblyName>
    <ServiceNounPrefix>PROM</ServiceNounPrefix>
</ConfigModel>");

                var nounPrefixes = Overrides.ResolveServiceNounPrefixesByAssemblyName(
                    new List<string> { "PrometheusService", "SimpleDB" },
                    tempDir,
                    new HashSet<string>(new[] { "SimpleDB" }, StringComparer.OrdinalIgnoreCase));

                Assert.AreEqual(1, nounPrefixes.Count);
                Assert.IsTrue(nounPrefixes.Contains("PROM"));
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ResolveServiceNounPrefixesByAssemblyName_UnexpectedAssemblyName_Throws()
        {
            // A target AssemblyName that resolves to neither a service configuration nor a skipped service
            // is unexpected and must throw so the mismatch is surfaced instead of silently hidden.
            var tempDir = Path.Combine(Path.GetTempPath(), "rng-asm-throw-test-" + Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            try
            {
                File.WriteAllText(Path.Combine(tempDir, "aps.xml"), @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <C2jFilename>aps</C2jFilename>
    <AssemblyName>PrometheusService</AssemblyName>
    <ServiceNounPrefix>PROM</ServiceNounPrefix>
</ConfigModel>");

                Assert.ThrowsException<Exception>(() =>
                    Overrides.ResolveServiceNounPrefixesByAssemblyName(
                        new List<string> { "PrometheusService", "NonexistentService" },
                        tempDir,
                        new HashSet<string>()));
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [TestMethod]
        public void ParseSkippedServiceAssemblyNames_ParsesIncludeLibrariesWithoutPrefix()
        {
            var configsXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModelCollection>
  <IncludeLibraries>
    <Library Name=""AWSSDK.CloudSearchDomain"" AddAsReference=""true"" />
    <Library Name=""AWSSDK.SimpleDB"" />
  </IncludeLibraries>
</ConfigModelCollection>";

            var skipped = Overrides.ParseSkippedServiceAssemblyNames(configsXml);

            Assert.AreEqual(2, skipped.Count);
            Assert.IsTrue(skipped.Contains("CloudSearchDomain"));
            Assert.IsTrue(skipped.Contains("SimpleDB"));
            // Matching is case-insensitive.
            Assert.IsTrue(skipped.Contains("simpledb"));
        }

        [TestMethod]
        public void ParseSkippedServiceAssemblyNames_NullOrEmpty_ReturnsEmpty()
        {
            Assert.AreEqual(0, Overrides.ParseSkippedServiceAssemblyNames(null).Count);
            Assert.AreEqual(0, Overrides.ParseSkippedServiceAssemblyNames(string.Empty).Count);
        }
    }
}
