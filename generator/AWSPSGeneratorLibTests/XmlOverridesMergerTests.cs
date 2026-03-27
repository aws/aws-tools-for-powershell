using AWSPowerShellGenerator.ServiceConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Xml;

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
    }
}
