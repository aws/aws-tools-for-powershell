using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSReleaseNotesGenerator;
using System.Management.Automation;

namespace ReleaseNotesGeneratorTests
{
    [TestClass]
    public class CmdletServiceNameTests
    {
        [Cmdlet("Get", "TSTWidget")]
        [Amazon.PowerShell.Common.AWSClientCmdlet("AWS Lambda", "TST", "2015-03-31", "Lambda")]
        private class AwsPrefixedServiceCmdlet { }

        [Cmdlet("Get", "TSTGadget")]
        [Amazon.PowerShell.Common.AWSClientCmdlet("Amazon Simple Storage Service (S3)", "TST", "2006-03-01", "S3")]
        private class AmazonPrefixedServiceCmdlet { }

        [Cmdlet("Get", "TSTGizmo")]
        [Amazon.PowerShell.Common.AWSClientCmdlet("Managed Streaming for Kafka Connect", "TST", "2021-09-14", "KafkaConnect")]
        private class UnprefixedServiceCmdlet { }

        [DataTestMethod]
        [DataRow(typeof(AwsPrefixedServiceCmdlet), "AWS Lambda")]
        [DataRow(typeof(AmazonPrefixedServiceCmdlet), "Amazon Simple Storage Service (S3)")]
        [DataRow(typeof(UnprefixedServiceCmdlet), "Managed Streaming for Kafka Connect")]
        public void ServiceName_IsTheConfiguredName(System.Type cmdletType, string expectedServiceName)
        {
            var cmdlet = new PSReleaseNotesGenerator.Cmdlet(cmdletType);

            Assert.AreEqual(expectedServiceName, cmdlet.ServiceName);
            Assert.AreEqual("TST", cmdlet.ServicePrefix);
        }
    }
}

namespace Amazon.PowerShell.Common
{
    // Stand-in for the module's attribute: the release notes generator matches it by full type name.
    [System.AttributeUsage(System.AttributeTargets.Class)]
    internal class AWSClientCmdletAttribute : System.Attribute
    {
        public string ServiceName { get; }
        public string ServicePrefix { get; }
        public string Version { get; }
        public string ModuleName { get; }

        public AWSClientCmdletAttribute(string serviceName, string servicePrefix, string version, string moduleName)
        {
            ServiceName = serviceName;
            ServicePrefix = servicePrefix;
            Version = version;
            ModuleName = moduleName;
        }
    }
}
