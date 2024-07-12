using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using AWSPowerShellGenerator.Utils;

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
}
