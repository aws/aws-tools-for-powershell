using AWSPowerShellGenerator.ServiceConfig;
using System.Collections.Generic;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class AliasFileTemplate : RazorTemplateBase<AliasFileTemplate>
    {
        public class AliasFileSection
        {
            public readonly string Project;
            public readonly Dictionary<string, string> Aliases;

            public AliasFileSection(string project, Dictionary<string, string> aliases) => (Project, Aliases) = (project, aliases);
        }

        protected IEnumerable<AliasFileSection> ProjectAliases { get; private set; }

        public static string Generate(IEnumerable<AliasFileSection> projectAliases)
        {
            var generator = CreateGenerator();
            generator.ProjectAliases = projectAliases;
            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
