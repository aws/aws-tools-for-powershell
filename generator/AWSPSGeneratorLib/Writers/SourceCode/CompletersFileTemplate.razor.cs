using AWSPowerShellGenerator.ServiceConfig;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class CompletersFileTemplate : RazorTemplateBase<CompletersFileTemplate>
    {
        protected ConfigModel ServiceConfig { get; private set; }

        /// <summary>
        /// If the service's cmdlets made use of any ConstantClass-derived 'enum' types, generate
        /// argument completers that will display when the user types the parameter name (ISE)
        /// or presses the tab key (console). This gives us ValidateSet-style intellisense without
        /// the value validation. If a completer script is generated, the filename for the script
        /// is returned.
        /// </summary>
        public static string Generate(ConfigModel serviceConfig)
        {
            var generator = CreateGenerator();
            generator.ServiceConfig = serviceConfig;
            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
