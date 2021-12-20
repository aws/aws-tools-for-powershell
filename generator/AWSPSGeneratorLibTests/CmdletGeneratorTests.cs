using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.ServiceConfig;

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
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel { AssemblyName = "ServiceA" });
            modelCollection.ConfigModels.Add("serviceB", new ConfigModel { AssemblyName = "ServiceB" });
            modelCollection.IncludeLibrariesList.Add(new Library("AWSSDK.SkippedService", false));

            CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection, null);
        }

        /// <summary>
        /// Verfies an exception is thrown when a service is missing its XML configuration
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "ServiceB was present in sdk_versions.json but not flagged as missing its configuration")]
        public void MissingServiceShouldThrowException()
        {
            var modelCollection = new ConfigModelCollection();
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel { AssemblyName = "ServiceA" });
            modelCollection.IncludeLibrariesList.Add(new Library("AWSSDK.SkippedService", false));

            try
            {
                CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection, null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Missing XML configuration for: ServiceB", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Verifies an exception is thrown when a service is missing and not intentionally omitted either
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "SkippedService was present in sdk_versions.json but not flagged as missing its configuration")]
        public void NotSkippedServiceShouldThrowException()
        {
            var modelCollection = new ConfigModelCollection();
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel { AssemblyName = "ServiceA" });
            modelCollection.ConfigModels.Add("serviceB", new ConfigModel { AssemblyName = "ServiceB" });

            try
            {
                CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection, null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Missing XML configuration for: SkippedService", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Verifies that an exception is not thrown when all services in _sdk-versions.json 
        /// are either configured or intentionally omitted and all services passed for verification
        /// are also either in the _sdk-version.json or intentionally omitted.
        /// </summary>
        [TestMethod]
        public void AllAssembliesConfiguredAndFoundShouldNotThrowException()
        {
            var modelCollection = new ConfigModelCollection();
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel { AssemblyName = "ServiceA" });
            modelCollection.ConfigModels.Add("serviceB", new ConfigModel { AssemblyName = "ServiceB" });
            modelCollection.IncludeLibrariesList.Add(new Library("AWSSDK.SkippedService", false));

            var foundServiceList = new string[]
            {
                "ServiceA",
                "ServiceB"
            };

            CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection, foundServiceList);
        }

        /// <summary>
        /// Verifies that an exception is thrown when a service is found that is not in the configuration.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception), "ServiceC on disk is missing its configuration and SkippedService is missing its configuration but is in sdk_versions.json.")]
        public void MissingServiceFoundShouldThrowException()
        {
            var modelCollection = new ConfigModelCollection();
            modelCollection.ConfigModels.Add("serviceA", new ConfigModel { AssemblyName = "ServiceA" });
            modelCollection.ConfigModels.Add("serviceB", new ConfigModel { AssemblyName = "ServiceB" });            

            var foundServiceList = new string[]
            {
                "ServiceA",
                "ServiceB",
                "ServiceC"
            };

            try
            {
                CmdletGenerator.VerifyAllAssembliesHaveConfiguration(_sdkVersionsJson, modelCollection, foundServiceList);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Missing XML configuration for: SkippedService, ServiceC", ex.Message);
                throw;
            }
        }
    }
}
