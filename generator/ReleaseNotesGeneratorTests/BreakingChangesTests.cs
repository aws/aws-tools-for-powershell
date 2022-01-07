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
    <Reason>[Breaking Change] the reason for the breaking change.</Reason>
  </ES>
</Services>";
            var breakingChanges = new BreakingChanges();
            breakingChanges.Add("ES", "[Breaking Change] the reason for the breaking change.");
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
    <Reason>[Breaking Change] the reason for the core breaking change.</Reason>
  </" + BreakingChanges.SharedSourceCodeKey + @">
  <ES InOverrides=""true"">
    <Reason>[Breaking Change] the reason for the breaking change.</Reason>
    <Reason>[Breaking Change] the 2nd reason for the breaking change.</Reason>
  </ES>
</Services>";
            var breakingChanges = new BreakingChanges();
            breakingChanges.Add("", "[Breaking Change] the reason for the core breaking change.");
            breakingChanges.Add("ES", "[Breaking Change] the reason for the breaking change.");
            breakingChanges.Add("ES", "[Breaking Change] the 2nd reason for the breaking change.");
            var xml = breakingChanges.CreateLookupXML(new HashSet<string>() { "ES" });
            Assert.IsNotNull(xml);
            Assert.AreEqual(expectedXML, xml);
        }
    }
}
