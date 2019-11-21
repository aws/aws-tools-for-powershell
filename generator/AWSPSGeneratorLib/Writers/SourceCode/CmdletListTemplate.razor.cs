using AWSPowerShellGenerator.ServiceConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class CmdletListTemplate : RazorTemplateBase<CmdletListTemplate>
    {
        protected IEnumerable<ConfigModel> ServiceConfigs { get; private set; }
        protected bool Modular { get; private set; }

        public static string Generate(IEnumerable<ConfigModel> serviceConfigs, bool modular)
        {
            var generator = CreateGenerator();
            generator.ServiceConfigs = serviceConfigs;
            generator.Modular = modular;

            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
