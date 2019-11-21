using AWSPowerShellGenerator.ServiceConfig;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class ServiceProjectFileTemplate : RazorTemplateBase<ServiceProjectFileTemplate>
    {
        protected ConfigModel ServiceConfig { get; private set; }
        protected string Version { get; private set; }

        public static string Generate(ConfigModel serviceConfig, string version)
        {
            var generator = CreateGenerator();
            generator.ServiceConfig = serviceConfig;
            generator.Version = version;
            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
