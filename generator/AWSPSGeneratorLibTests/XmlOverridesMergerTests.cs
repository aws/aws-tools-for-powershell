using AWSPowerShellGenerator.ServiceConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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
            XmlOverridesMerger.ReadOverrides(Path.GetFullPath(".\\XMLTests\\InvalidXML"), out errorMessage);

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
            XmlOverridesMerger.ReadOverrides(Path.GetFullPath(".\\XMLTests\\InvalidSchema"), out errorMessage);

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
            XmlOverridesMerger.ReadOverrides(Path.GetFullPath(".\\XMLTests\\invalid"), out errorMessage);

            Assert.IsNull(errorMessage);
        }
    }
}
