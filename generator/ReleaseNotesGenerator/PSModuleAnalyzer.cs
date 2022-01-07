using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace PSReleaseNotesGenerator
{
    public class PSModuleAnalyzer
    {
        private readonly string _assemblyPath;

        private readonly PSModuleAnalyzerAssemblyLoader _assemblyLoadContext;

        public PSModuleAnalyzer(string path)
        {
            _assemblyPath = path;

            // use an isolated load context so that multiple instances of the Analyzer (hopefully)
            // wont interfere with each other if, for example, there are different versions of an assembly getting loaded
            _assemblyLoadContext = new PSModuleAnalyzerAssemblyLoader(_assemblyPath);
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
}
