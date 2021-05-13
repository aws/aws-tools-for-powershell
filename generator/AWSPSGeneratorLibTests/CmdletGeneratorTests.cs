using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.ServiceConfig;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class CmdletGeneratorTests
    {
        static private JObject _sdkVersionsJson = JObject.Parse(@"
        {
            ""ServiceVersions"" : {
                ""ServiceA"" : { },
                ""ServiceB"" : { },
                ""SkippedService"" : { }
                }
        }");

        /// <summary>
        /// Verifies that an exception is not thrown when all services in _sdk-versions.json 
        /// are either configured or intentionally omitted
        /// </summary>
        [TestMethod]
        public void AllAssembliesConfiguredShouldNotThrowException()
        {
            var modelCollection = new ConfigModelCollection();
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel() { AssemblyName = "ServiceA" });
            modelCollection.ConfigModels.Add("serviceB", new ConfigModel() { AssemblyName = "ServiceB" });
            modelCollection.IncludeLibrariesList.Add(new Library("AWSSDK.SkippedService", false));

            CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection);
        }

        /// <summary>
        /// Verfies an exception is thrown when a service is missing its XML configuration
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "ServiceB was present in sdk_versions.json but not flagged as missing its configuration")]
        public void MissingServiceShouldThrowException()
        {
            var modelCollection = new ConfigModelCollection();
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel() { AssemblyName = "ServiceA" });
            modelCollection.IncludeLibrariesList.Add(new Library("AWSSDK.SkippedService", false));

            CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection);
        }

        /// <summary>
        /// Verifies an exception is thrown when a service is missing and not intentionally omitted either
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "SkippedService was present in sdk_versions.json but not flagged as missing its configuration")]
        public void NotSkippedServiceShouldThrowException()
        {
            var modelCollection = new ConfigModelCollection();
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel() { AssemblyName = "ServiceA" });
            modelCollection.ConfigModels.Add("serviceB", new ConfigModel() { AssemblyName = "ServiceB" });

            CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection);
        }
    }
}
