using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Utils;
using Newtonsoft.Json;

namespace AWSPSGeneratorLibTests
{
    [TestClass]
    public class GenerationSourcesTests
    {   
        /// <summary>
        /// Verifies that two lists of AWSSDK.*.dll files, one in net472 and one in netstandard2.0 will properly 
        /// union the two lists of files and return only the name of the service so that it may be matched against
        /// the configured PowerShell service list.
        /// </summary>
        [TestMethod]        
        public void FoundDistinctListOfServiceNames()
        {
            int call = 0;
            Func<string, string, SearchOption, IEnumerable<string>> enumerateFiles = (string path, string searchFilter, SearchOption options) => {
                
                //Call 0 will results in: AWSSDK.ServiceA.dll, AWSSDK.ServiceB.dll, AWSSDK.ServiceC.dll
                //Call 1 will results in: AWSSDK.ServiceA.dll, AWSSDK.ServiceB.dll, AWSSDK.ServiceD.dll                
                var files = new List<string>
                {
                    "AWSSDK.ServiceA.dll",
                    "AWSSDK.ServiceB.dll",
                    $"AWSSDK.Service{(call == 0 ? 'C': 'D')}.dll" 
                };

                call++;
                return files;
            };
                        
            var allFoundSdkAssemblies = GenerationSources.SDKFindAssemblyFilenames("test", enumerateFiles);

            //Ensure the two lists of files have been union to the distinct list: ServiceA, ServiceB, ServiceC, ServiceD
            CollectionAssert.AreEqual(new List<string> { "ServiceA", "ServiceB", "ServiceC", "ServiceD" }, 
                new List<string>(allFoundSdkAssemblies));
        }
        
    }

    [TestClass]
    public class DependencyGraphTests
    {
        private string _tempDir;

        [TestInitialize]
        public void Setup()
        {
            // Create a nested directory structure to simulate repo layout:
            // _tempDir acts as the repo root, and _moduleDir acts as modules/AWSPowerShell
            _tempDir = Path.Combine(Path.GetTempPath(), "DependencyGraphTests_" + Guid.NewGuid().ToString("N"), "modules", "AWSPowerShell");
            Directory.CreateDirectory(_tempDir);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up from the repo root level (three levels up: AWSPowerShell -> modules -> repoRoot)
            var repoRoot = Path.GetFullPath(Path.Combine(_tempDir, "..", ".."));
            if (Directory.Exists(repoRoot))
            {
                Directory.Delete(repoRoot, true);
            }
        }

        private ConfigModel CreateService(string assemblyName, string guid = null, IEnumerable<string> sdkDependencies = null)
        {
            var model = new ConfigModel
            {
                AssemblyName = assemblyName,
                ServiceModuleGuid = guid ?? Guid.NewGuid().ToString()
            };
            model.SDKDependencies = sdkDependencies ?? Array.Empty<string>();
            return model;
        }

        private GenerationSources CreateGenerationSources()
        {
            // Create minimal directory structure needed by GenerationSources constructor
            var sdkDir = Path.Combine(_tempDir, "sdk");
            Directory.CreateDirectory(sdkDir);
            return new GenerationSources(_tempDir, sdkDir, "5.0.9999", "");
        }

        private Dictionary<string, string[]> ReadDependencyGraph()
        {
            // WriteDependencyGraph writes to repo root (two levels up from AwsPowerShellModuleFolder)
            var repoRoot = Path.GetFullPath(Path.Combine(_tempDir, "..", ".."));
            var path = Path.Combine(repoRoot, "aws-tools-publish-dependency-graph.json");
            Assert.IsTrue(File.Exists(path), "aws-tools-publish-dependency-graph.json should be created");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);
        }

        [TestMethod]
        public void WriteDependencyGraph_CommonOnlyDependencies_AllModulesListCommonAsDep()
        {
            var sources = CreateGenerationSources();
            var services = new List<ConfigModel>
            {
                CreateService("S3"),
                CreateService("EC2"),
                CreateService("Lambda")
            };

            sources.WriteDependencyGraph(services);
            var graph = ReadDependencyGraph();

            Assert.AreEqual(3, graph.Count);
            Assert.IsTrue(graph.ContainsKey("AWS.Tools.S3"));
            Assert.IsTrue(graph.ContainsKey("AWS.Tools.EC2"));
            Assert.IsTrue(graph.ContainsKey("AWS.Tools.Lambda"));

            // Each should only have AWS.Tools.Common as dependency
            CollectionAssert.AreEqual(new[] { "AWS.Tools.Common" }, graph["AWS.Tools.S3"]);
            CollectionAssert.AreEqual(new[] { "AWS.Tools.Common" }, graph["AWS.Tools.EC2"]);
            CollectionAssert.AreEqual(new[] { "AWS.Tools.Common" }, graph["AWS.Tools.Lambda"]);
        }

        [TestMethod]
        public void WriteDependencyGraph_CrossServiceDependency_IncludesServiceAndCommon()
        {
            var sources = CreateGenerationSources();
            var services = new List<ConfigModel>
            {
                CreateService("SecurityToken"),
                CreateService("CognitoIdentity", sdkDependencies: new[] { "SecurityToken" }),
            };

            sources.WriteDependencyGraph(services);
            var graph = ReadDependencyGraph();

            Assert.AreEqual(2, graph.Count);

            // SecurityToken depends only on Common
            CollectionAssert.AreEqual(new[] { "AWS.Tools.Common" }, graph["AWS.Tools.SecurityToken"]);

            // CognitoIdentity depends on SecurityToken AND Common
            var cognitoDeps = graph["AWS.Tools.CognitoIdentity"];
            Assert.AreEqual(2, cognitoDeps.Length);
            Assert.IsTrue(cognitoDeps.Contains("AWS.Tools.SecurityToken"));
            Assert.IsTrue(cognitoDeps.Contains("AWS.Tools.Common"));
        }

        [TestMethod]
        public void WriteDependencyGraph_MultipleServiceDependencies_IncludesAllDeps()
        {
            var sources = CreateGenerationSources();
            var services = new List<ConfigModel>
            {
                CreateService("SimpleNotificationService"),
                CreateService("SQS"),
                CreateService("Glacier", sdkDependencies: new[] { "SimpleNotificationService", "SQS" }),
            };

            sources.WriteDependencyGraph(services);
            var graph = ReadDependencyGraph();

            Assert.AreEqual(3, graph.Count);

            var glacierDeps = graph["AWS.Tools.Glacier"];
            Assert.AreEqual(3, glacierDeps.Length);
            Assert.IsTrue(glacierDeps.Contains("AWS.Tools.SimpleNotificationService"));
            Assert.IsTrue(glacierDeps.Contains("AWS.Tools.SQS"));
            Assert.IsTrue(glacierDeps.Contains("AWS.Tools.Common"));
        }

        [TestMethod]
        public void WriteDependencyGraph_TransitiveDependency_OnlyDirectDepsIncluded()
        {
            var sources = CreateGenerationSources();
            // CognitoSync depends on CognitoIdentity, which depends on SecurityToken
            // But WriteDependencyGraph should only include direct SDK deps
            var services = new List<ConfigModel>
            {
                CreateService("SecurityToken"),
                CreateService("CognitoIdentity", sdkDependencies: new[] { "SecurityToken" }),
                CreateService("CognitoSync", sdkDependencies: new[] { "CognitoIdentity" }),
            };

            sources.WriteDependencyGraph(services);
            var graph = ReadDependencyGraph();

            // CognitoSync should list CognitoIdentity + Common, NOT SecurityToken (transitive)
            var syncDeps = graph["AWS.Tools.CognitoSync"];
            Assert.AreEqual(2, syncDeps.Length);
            Assert.IsTrue(syncDeps.Contains("AWS.Tools.CognitoIdentity"));
            Assert.IsTrue(syncDeps.Contains("AWS.Tools.Common"));
            Assert.IsFalse(syncDeps.Contains("AWS.Tools.SecurityToken"));
        }

        [TestMethod]
        public void WriteDependencyGraph_SkipsServicesWithoutModuleGuid()
        {
            var sources = CreateGenerationSources();
            var services = new List<ConfigModel>
            {
                CreateService("S3"),
                CreateService("InternalService", guid: ""),  // no guid = not a publishable module
            };

            sources.WriteDependencyGraph(services);
            var graph = ReadDependencyGraph();

            Assert.AreEqual(1, graph.Count);
            Assert.IsTrue(graph.ContainsKey("AWS.Tools.S3"));
            Assert.IsFalse(graph.ContainsKey("AWS.Tools.InternalService"));
        }

        [TestMethod]
        public void WriteDependencyGraph_NullSDKDependencies_TreatedAsNoDeps()
        {
            var sources = CreateGenerationSources();
            var model = new ConfigModel
            {
                AssemblyName = "S3",
                ServiceModuleGuid = Guid.NewGuid().ToString()
            };
            model.SDKDependencies = null;  // explicitly null

            sources.WriteDependencyGraph(new[] { model });
            var graph = ReadDependencyGraph();

            Assert.AreEqual(1, graph.Count);
            CollectionAssert.AreEqual(new[] { "AWS.Tools.Common" }, graph["AWS.Tools.S3"]);
        }

        [TestMethod]
        public void WriteDependencyGraph_EmptyServiceList_ProducesEmptyGraph()
        {
            var sources = CreateGenerationSources();
            sources.WriteDependencyGraph(Array.Empty<ConfigModel>());
            var graph = ReadDependencyGraph();

            Assert.AreEqual(0, graph.Count);
        }

        [TestMethod]
        public void WriteDependencyGraph_DependencyOnNonModuleService_ExcludedFromDeps()
        {
            var sources = CreateGenerationSources();
            // ServiceA depends on InternalService (no guid), should not appear in deps
            var services = new List<ConfigModel>
            {
                CreateService("ServiceA", sdkDependencies: new[] { "InternalService" }),
                CreateService("InternalService", guid: ""),  // no guid
            };

            sources.WriteDependencyGraph(services);
            var graph = ReadDependencyGraph();

            Assert.AreEqual(1, graph.Count);
            // InternalService should not appear as a dep since it has no module guid
            CollectionAssert.AreEqual(new[] { "AWS.Tools.Common" }, graph["AWS.Tools.ServiceA"]);
        }
    }
}
