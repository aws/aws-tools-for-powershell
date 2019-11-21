using AWSPowerShellGenerator.ServiceConfig;
using System.Collections.Generic;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class MonolithicProjectFileTemplate : RazorTemplateBase<MonolithicProjectFileTemplate>
    {
        protected IEnumerable<string> Assemblies { get; private set; }
        protected string Version { get; private set; }

        public static string Generate(IEnumerable<string> assemblies, string version)
        {
            var generator = CreateGenerator();
            generator.Assemblies = assemblies;
            generator.Version = version;
            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
