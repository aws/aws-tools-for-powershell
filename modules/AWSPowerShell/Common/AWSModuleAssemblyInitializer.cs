using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Reflection;


namespace Amazon.PowerShell.Common
{
    public class AWSModuleAssemblyInitializer : IModuleAssemblyInitializer, IModuleAssemblyCleanup
    {
        private static readonly string _modulePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly HashSet<string> _transitiveDependencies = new HashSet<string> {
            "BouncyCastle.Cryptography.dll",
            "System.Buffers.dll",
            "System.Memory.dll",
            "System.Numerics.Vectors.dll",
            "System.Text.Json.dll",
            "System.Threading.Tasks.Extensions.dll",
            "Microsoft.Bcl.AsyncInterfaces.dll",
            "System.Runtime.CompilerServices.Unsafe.dll"
        };

        public void OnImport()
        {
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAWSDependencies;
        }

        public void OnRemove(PSModuleInfo psModuleInfo)
        {
            AppDomain.CurrentDomain.AssemblyResolve -= ResolveAWSDependencies;
        }

        public static Assembly ResolveAWSDependencies(object sender, ResolveEventArgs args)
        {
            var assemblyPath = (new AssemblyName(args.Name)).Name + ".dll";
            var fullPath = Path.Combine(_modulePath, assemblyPath);
            if (_transitiveDependencies.Contains(assemblyPath) && File.Exists(fullPath))
            {
                return Assembly.LoadFrom(fullPath);
            }
            return null;
        }
    }
}
