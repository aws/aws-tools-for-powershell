using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;

namespace PSReleaseNotesGenerator
{
    public class PSModuleAnalyzer
    {
        private readonly string _assemblyPath;

        private readonly EmptyAssemblyLoadContext _assemblyLoadContext;

        public PSModuleAnalyzer(string path)
        {
            _assemblyPath = path;

            var assemblyFolder = Path.GetDirectoryName(path);

            // use an isolated load context so that multiple instances of the Analyzer (hopefully)
            // wont interfere with each other if, for example, there are different versions of an assembly getting loaded
            _assemblyLoadContext = new EmptyAssemblyLoadContext();

            _assemblyLoadContext.Resolving += (context, name) =>
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

                var foundDlls = Directory.GetFileSystemEntries(new FileInfo(assemblyFolder).FullName, name.Name + ".dll", SearchOption.AllDirectories);
                if (foundDlls.Any())
                {
                    return context.LoadFromAssemblyPath(foundDlls[0]);
                }

                return context.LoadFromAssemblyName(name);
            };
        }

        private static bool IsCandidateLibrary(RuntimeLibrary library, AssemblyName assemblyName)
        {
            return (library.Name == (assemblyName.Name))
                   || (library.Dependencies.Any(d => d.Name.StartsWith(assemblyName.Name)));
        }

        public IDictionary<string, Cmdlet> Analyze()
        {
            var assembly = _assemblyLoadContext.LoadFromAssemblyPath(_assemblyPath);

            var cmdlets = 
                assembly
                    .GetTypes()
                    .Where(type => type.GetCustomAttributes<CmdletAttribute>().Any())
                    .Select(type => new Cmdlet(type))
                    .ToDictionary(cmdlet => cmdlet.Name, cmdlet => cmdlet);

            return new ReadOnlyDictionary<string, Cmdlet>(cmdlets);
        }
    }

    /// <summary>
    /// An isolated <see cref="AssemblyLoadContext"/> inspired by the .net core 3.0 version
    /// <see cref="AssemblyLoadContext"/> which supports new-ing up a <see cref="AssemblyLoadContext"/>
    /// directly.
    /// <para />
    /// Exclusively meant to support See <see cref="PSModuleAnalyzer"/>.
    /// </summary>
    /// <remarks>
    /// Documentation on assembly resolution sequence:
    /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext.loadfromassemblyname?view=netcore-2.1
    /// </remarks>
    internal class EmptyAssemblyLoadContext : AssemblyLoadContext
    {
        public EmptyAssemblyLoadContext(){}

        protected override Assembly Load(AssemblyName assemblyName)
        {
            // return null to continue the assembly resolution sequence.
            return null;
        }
    }
}
