using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSReleaseNotesGenerator;
using System.Collections.Generic;

namespace ReleaseNotesGeneratorTests
{
    [TestClass]
    public class BreakingChangesTests
    {
        const string emptyXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Services />";
        [TestMethod]
        public void TestCreateBreakingChangesLookup_Empty()
        {
            var breakingChanges = new BreakingChanges();
            var xml = breakingChanges.CreateLookupXML(new HashSet<string>());
            Assert.IsNotNull(xml);
            Assert.AreEqual(emptyXML, xml);
        }

        [TestMethod]
        public void TestCreateBreakingChangesLookup_NoOverrides()
        {
            var expectedXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Services>
  <ES InOverrides=""false"">
    <Reason Type=""CmdletRemoved"">[Breaking Change] the reason for the breaking change.</Reason>
  </ES>
</Services>";
            var breakingChanges = new BreakingChanges();
            breakingChanges.Add("ES", "[Breaking Change] the reason for the breaking change.", BreakingChangeType.CmdletRemoved);
            var xml = breakingChanges.CreateLookupXML(new HashSet<string>());
            Assert.IsNotNull(xml);
            Assert.AreEqual(expectedXML, xml);
        }

        [TestMethod]
        public void TestCreateBreakingChangesLookup_OneOverrideAndCoreBreaks()
        {
            var expectedXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Services>
  <" + BreakingChanges.SharedSourceCodeKey + @" InOverrides=""false"">
    <Reason Type=""ParameterRemoved"">[Breaking Change] the reason for the core breaking change.</Reason>
  </" + BreakingChanges.SharedSourceCodeKey + @">
  <ES InOverrides=""true"">
    <Reason Type=""CmdletRemoved"">[Breaking Change] the reason for the breaking change.</Reason>
    <Reason Type=""ParameterTypeChanged"">[Breaking Change] the 2nd reason for the breaking change.</Reason>
  </ES>
</Services>";
            var breakingChanges = new BreakingChanges();
            breakingChanges.Add("", "[Breaking Change] the reason for the core breaking change.", BreakingChangeType.ParameterRemoved);
            breakingChanges.Add("ES", "[Breaking Change] the reason for the breaking change.", BreakingChangeType.CmdletRemoved);
            breakingChanges.Add("ES", "[Breaking Change] the 2nd reason for the breaking change.", BreakingChangeType.ParameterTypeChanged);
            var xml = breakingChanges.CreateLookupXML(new HashSet<string>() { "ES" });
            Assert.IsNotNull(xml);
            Assert.AreEqual(expectedXML, xml);
        }

        /// <summary>
        /// Reproduces the empty-buildconfig scenario (PowerShell-498): a parameter change on an
        /// existing operation of an existing service (BAR / Bedrock Agent Runtime) is detected but
        /// the service is absent from overrides.xml. Passing the service's C2jFilename as a build
        /// target resolves it to its ServiceNounPrefix (BAR) and flags it InOverrides="true" so the
        /// breaking change is surfaced, while an unrelated service whose SDK model also shifted (EC2)
        /// stays InOverrides="false" and is not surfaced.
        /// </summary>
        [TestMethod]
        public void TestCreateBreakingChangesLookup_TargetServiceFlaggedWhenNotInOverrides()
        {
            var expectedXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Services>
  <BAR InOverrides=""true"">
    <Reason Type=""ParameterRemoved"">[Breaking Change] Modified cmdlet Invoke-BARRetrieve: removed parameter NoAutoIteration.</Reason>
  </BAR>
  <EC2 InOverrides=""false"">
    <Reason Type=""ParameterRemoved"">[Breaking Change] Modified cmdlet Get-EC2Something: removed parameter Unrelated.</Reason>
  </EC2>
</Services>";
            var breakingChanges = new BreakingChanges();
            breakingChanges.Add("BAR", "[Breaking Change] Modified cmdlet Invoke-BARRetrieve: removed parameter NoAutoIteration.", BreakingChangeType.ParameterRemoved);
            breakingChanges.Add("EC2", "[Breaking Change] Modified cmdlet Get-EC2Something: removed parameter Unrelated.", BreakingChangeType.ParameterRemoved);

            var barConfig = @"<?xml version=""1.0"" encoding=""utf-8""?>
<ConfigModel>
    <C2jFilename>bedrock-agent-runtime</C2jFilename>
    <ServiceNounPrefix>BAR</ServiceNounPrefix>
</ConfigModel>";

            // overrides.xml is empty (no service keys); the build targets the bedrock-agent-runtime
            // C2jFilename, which is resolved to its ServiceNounPrefix (BAR).
            var serviceKeys = new HashSet<string>();
            var targetC2jFilenames = Overrides.ParseTargetServiceC2jFilenames("bedrock-agent-runtime");
            foreach (var nounPrefix in Overrides.ResolveServiceNounPrefixes(targetC2jFilenames, (filetitle) => barConfig))
            {
                serviceKeys.Add(nounPrefix);
            }

            var xml = breakingChanges.CreateLookupXML(serviceKeys);
            Assert.IsNotNull(xml);
            Assert.AreEqual(expectedXML, xml);
        }
    }
}
