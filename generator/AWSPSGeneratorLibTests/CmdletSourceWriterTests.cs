using System.Collections.Generic;
using AWSPowerShellGenerator.Writers.SourceCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class CmdletSourceWriterTests
    {
        private class FakeResponse
        {
            [Amazon.Runtime.Internal.AWSProperty(Sensitive = true)]
            public string EmbedUrl { get; set; }

            [Amazon.Runtime.Internal.AWSProperty(Sensitive = false)]
            public string Status { get; set; }

            [Amazon.Runtime.Internal.AWSProperty(Sensitive = true)]
            public Dictionary<string, string> Tags { get; set; }
        }

        [TestMethod]
        [DataRow(nameof(FakeResponse.EmbedUrl), "Amazon.PowerShell.Common.SensitiveOutput.RedactOnHost(response.EmbedUrl, cmdlet, \"EmbedUrl\")")]
        [DataRow(nameof(FakeResponse.Status), "response.Status")]
        [DataRow(nameof(FakeResponse.Tags), "Amazon.PowerShell.Common.SensitiveOutput.TagForHost(response.Tags, cmdlet, \"Tags\")")]
        public void DefaultSelect_WrapsOnlySensitiveProperties(string property, string expected)
        {
            Assert.AreEqual(expected, CmdletSourceWriter.GetDefaultSelectValue(property, typeof(FakeResponse).GetProperty(property)));
        }
    }
}
