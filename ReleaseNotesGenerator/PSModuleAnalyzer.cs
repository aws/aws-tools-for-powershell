using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace PSReleaseNotesGenerator
{
    public class PSModuleAnalyzer
    {
        static PSModuleAnalyzer()
        {
            AssemblyLoadContext.Default.Resolving += (context, name) =>
            {
                // avoid loading *.resources dlls, because of: https://github.com/dotnet/coreclr/issues/8416
                if (name.Name.EndsWith("resources"))
                {
                    return null;
                }

                var dependencies = DependencyContext.Default.RuntimeLibraries;
                foreach (var library in dependencies)
                {
                    if (IsCandidateLibrary(library, name))
                    {
                        return context.LoadFromAssemblyName(new AssemblyName(library.Name));
                    }
                }

                var foundDlls = Directory.GetFileSystemEntries(new FileInfo(AssemblyFolder).FullName, name.Name + ".dll", SearchOption.AllDirectories);
                if (foundDlls.Any())
                {
                    return context.LoadFromAssemblyPath(foundDlls[0]);
                }

                return context.LoadFromAssemblyName(name);
            };
        }

       private static object LockObject = new object();
       private static string AssemblyFolder = null;

        public static IDictionary<string, Cmdlet> Analyze(string path)
        {
            lock (LockObject)
            {
                try
                {
                    AssemblyFolder = Path.GetDirectoryName(path);

                    var assembly = Assembly.LoadFile(path);
                    var cmdlets = assembly.GetTypes()
                        .Where(type => type.GetCustomAttributes<CmdletAttribute>().Any())
                        .Select(type => new Cmdlet(type))
                        .ToDictionary(cmdlet => cmdlet.Name, cmdlet => cmdlet);
                    return new ReadOnlyDictionary<string, Cmdlet>(cmdlets);
                }
                finally
                {
                    AssemblyFolder = null;
                }
            }
        }

        private static bool IsCandidateLibrary(RuntimeLibrary library, AssemblyName assemblyName)
        {
            return (library.Name == (assemblyName.Name))
                    || (library.Dependencies.Any(d => d.Name.StartsWith(assemblyName.Name)));
        }
    }
}
