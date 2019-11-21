using AWSPowerShellGenerator.ServiceConfig;
using System.Collections.Generic;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class ModularSolutionFileTemplate : RazorTemplateBase<ModularSolutionFileTemplate>
    {
        protected IEnumerable<ConfigModel> Services { get; private set; }

        public static string Generate(IEnumerable<ConfigModel> services)
        {
            var generator = CreateGenerator();
            generator.Services = services;
            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
