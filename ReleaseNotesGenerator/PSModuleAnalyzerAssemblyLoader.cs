using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyModel;

namespace PSReleaseNotesGenerator
{
    /// <summary>
    /// An isolated <see cref="AssemblyLoadContext"/> meant to support See <see cref="PSModuleAnalyzer"/>.
    /// </summary>
    /// <remarks>
    /// Documentation on assembly resolution sequence:
    /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext.loadfromassemblyname?view=netcore-2.1
    /// </remarks>
    public class PSModuleAnalyzerAssemblyLoader : AssemblyLoadContext
    {
        private readonly string _assemblyFolder;

        public PSModuleAnalyzerAssemblyLoader(string assemblyPath)
        {
            _assemblyFolder = Path.GetDirectoryName(assemblyPath);
        }

        /// <remarks>
        /// return null to continue the assembly load sequance
        /// </remarks>
        protected override Assembly Load(AssemblyName assemblyName)
        {
            if (null == assemblyName?.Name)
                return null;

            // avoid loading *.resources dlls, because of: https://github.com/dotnet/coreclr/issues/8416
            if (assemblyName.Name.EndsWith("resources"))
            {
                return null;
            }

            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateLibrary(library, assemblyName))
                {
                    return null;
                }
            }

            var foundDlls = Directory.GetFileSystemEntries(new FileInfo(_assemblyFolder).FullName, assemblyName.Name + ".dll", SearchOption.AllDirectories);
            if (foundDlls.Any())
            {
                return base.LoadFromAssemblyPath(foundDlls[0]);
            }

            return null;
        }

        private static bool IsCandidateLibrary(RuntimeLibrary library, AssemblyName assemblyName)
        {
            return (library.Name == (assemblyName.Name))
                   || (library.Dependencies.Any(d => d.Name.StartsWith(assemblyName.Name)));
        }
    }
}