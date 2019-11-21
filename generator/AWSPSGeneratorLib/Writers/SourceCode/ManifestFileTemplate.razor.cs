using AWSPowerShellGenerator.ServiceConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    public abstract class ManifestFileTemplate : RazorTemplateBase<ManifestFileTemplate>
    {
        public class DependencyModule
        {
            public readonly string Name;
            public readonly string Guid;

            public DependencyModule(string name, string guid)
            {
                Name = name;
                Guid = guid;
            }
        }

        protected IEnumerable<string> Assemblies { get; private set; }
        protected IEnumerable<string> TypesToProcessFiles { get; private set; }
        protected IEnumerable<string> FormatsToProcessFiles { get; private set; }
        protected IEnumerable<string> NestedModulesFiles { get; private set; }
        protected IEnumerable<string> FileList { get; private set; }
        protected int CompatiblePowerShellVersion { get; private set; }
        protected int CompatiblePowerShellMinorVersion { get; private set; }
        protected string CompatibleFrameworkVersion { get; private set; }
        protected bool NetStandard { get; private set; }
        protected IEnumerable<string> CmdletsToExport { get; private set; }
        protected IEnumerable<string> AliasesToExport { get; private set; }
        protected IEnumerable<DependencyModule> RequiredModules { get; private set; }
        protected IEnumerable<string> ScriptsToProcess { get; private set; }
        protected string PrereleaseTag { get; private set; }

        protected string Name { get; private set; }
        protected string RootModule { get; private set; }
        protected string Guid { get; private set; }
        protected string Version { get; private set; }
        protected string Description { get; private set; }

        protected bool RequiresPS51OrGreater { get; private set; }

        public static string Generate(
            string name,
            string rootModule,
            string guid,
            string version,
            string description,
            IEnumerable<string> assemblies = null,
            IEnumerable<string> typesToProcessFiles = null,
            IEnumerable<string> formatsToProcessFiles = null,
            IEnumerable<string> nestedModulesFiles = null,
            IEnumerable<string> fileList = null,
            int compatiblePowerShellVersion = 3,
            int compatiblePowerShellMinorVersion = 0,
            string compatibleFrameworkVersion = "4.7.2",
            bool netStandard = true,
            IEnumerable<string> cmdletsToExport = null,
            IEnumerable<string> aliasesToExport = null,
            IEnumerable<DependencyModule> requiredModules = null,
            IEnumerable<string> scriptsToProcess = null,
            string prereleaseTag = null)
        {
            var generator = CreateGenerator();
            generator.Name = name;
            generator.RootModule = rootModule;
            generator.Guid = guid;
            generator.Version = version;
            generator.Description = description;

            generator.Assemblies = assemblies ?? new string[0];
            generator.TypesToProcessFiles = typesToProcessFiles ?? new string[0];
            generator.FormatsToProcessFiles = formatsToProcessFiles ?? new string[0];
            generator.NestedModulesFiles = nestedModulesFiles ?? new string[0];
            generator.FileList = fileList ?? new string[0];
            generator.CompatiblePowerShellVersion = compatiblePowerShellVersion;
            generator.CompatiblePowerShellMinorVersion = compatiblePowerShellMinorVersion;
            generator.CompatibleFrameworkVersion = compatibleFrameworkVersion;
            generator.NetStandard = netStandard;
            generator.CmdletsToExport = cmdletsToExport;
            generator.AliasesToExport = aliasesToExport;
            generator.RequiredModules = requiredModules ?? new DependencyModule[0];
            generator.ScriptsToProcess = scriptsToProcess ?? new string[0];
            generator.PrereleaseTag = prereleaseTag;

            generator.RequiresPS51OrGreater = compatiblePowerShellVersion > 5 || (compatiblePowerShellVersion == 5 && compatiblePowerShellMinorVersion >= 1);

            var result = generator.RunAsync().Result;
            return result;
        }
    }
}
