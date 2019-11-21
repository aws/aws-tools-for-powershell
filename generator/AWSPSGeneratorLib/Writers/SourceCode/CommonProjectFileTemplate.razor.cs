using AWSPowerShellGenerator.ServiceConfig;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class CommonProjectFileTemplate : RazorTemplateBase<CommonProjectFileTemplate>
    {
        protected string Version { get; private set; }

        public static string Generate(string version)
        {
            var generator = CreateGenerator();
            generator.Version = version;
            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
