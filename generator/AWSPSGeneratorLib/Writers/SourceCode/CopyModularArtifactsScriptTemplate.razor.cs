using AWSPowerShellGenerator.ServiceConfig;
using System.Collections.Generic;
using System.Linq;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class CopyModularArtifactsScriptTemplate : RazorTemplateBase<CopyModularArtifactsScriptTemplate>
    {
        protected List<ConfigModel> Projects { get; private set; }

        public static string Generate(IEnumerable<ConfigModel> services)
        {
            var generator = CreateGenerator();
            generator.Projects = services
                .Where(service => !string.IsNullOrWhiteSpace(service.ServiceModuleGuid))
                .OrderBy(service => service.AssemblyName)
                .ToList();
            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
