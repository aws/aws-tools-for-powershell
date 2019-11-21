using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Writers.Help
{
    internal class TOCCmdletEntry
    {
        public string CmdletName { get; set; }
        public string Synopsis { get; set; }
        public string TOCId { get; set; }
        public string LegacyAlias { get; set; }
    }

    internal class TOCModuleEntry
    {
        public string ModuleName { get; set; }
        public string ModuleTitle { get; set; }
        public bool UseTitle { get; set; }
        public List<TOCCmdletEntry> CmdletEntries { get; } = new List<TOCCmdletEntry>();
    }

    public class TOCWriter : BaseTemplateWriter
    {
        public const string CommonModuleName = "Common";
        public const string CommonTOCName = "Shell Configuration";
        public const string InstallerModuleName = "Installer";
        public const string InstallerTOCName = "Installation";

        readonly Dictionary<string, TOCModuleEntry> _cmdletsByService = new Dictionary<string, TOCModuleEntry>();

        public TOCWriter(GeneratorOptions options, string outputFolder)
            : base(options, outputFolder)
        {
        }

        public void AddFixedSection()
        {
            //This should be replaced with proper help generation for script cmdlets
            AddServiceCmdlet(InstallerModuleName, InstallerTOCName, "Install-AWSToolsModule", "Install-AWSToolsModule", "Installs AWS.Tools modules.", null);
            AddServiceCmdlet(InstallerModuleName, InstallerTOCName, "Uninstall-AWSToolsModule", "Uninstall-AWSToolsModule", "Uninstalls all currently installed AWS.Tools modules.", null);
            AddServiceCmdlet(InstallerModuleName, InstallerTOCName, "Update-AWSToolsModule", "Update-AWSToolsModule", "Updates all currently installed AWS.Tools modules.", null);
        }

        // target page is synthesized from the cmdlet name once we emit the overall TOC; we will also
        // generate a summary page of cmdlets with their synopsis for the service
        public void AddServiceCmdlet(string moduleName, string serviceName, string cmdletName, string tocId, string synopsis, string legacyAlias)
        {
            if (!_cmdletsByService.TryGetValue(moduleName, out var moduleEntry))
            {
                moduleEntry = new TOCModuleEntry
                {
                    ModuleName = moduleName,
                    ModuleTitle = serviceName,
                    UseTitle = moduleName == InstallerModuleName || moduleName == CommonModuleName
                };
                _cmdletsByService.Add(moduleName, moduleEntry);
            }

            // toc is updated in several loops, so skip dupe attempts to assist caller code
            if (moduleEntry.CmdletEntries.Count > 0)
            {
                if (moduleEntry.CmdletEntries.Any(tocCmdletEntry => string.Equals(cmdletName, tocCmdletEntry.CmdletName, StringComparison.OrdinalIgnoreCase)))
                    return;
            }

            moduleEntry.CmdletEntries.Add(new TOCCmdletEntry { CmdletName = cmdletName, TOCId = tocId, Synopsis = synopsis, LegacyAlias = legacyAlias });
        }

        protected override string GetTemplateName()
        {
            return "TOC.html";
        }

        protected override string ReplaceTokens(string templateBody)
        {
            var treeData = GenerateTree();
            var finalBody = templateBody.Replace("{TOC}", treeData);
            return finalBody;
        }

        string GenerateTree()
        {
            var writer = new StringWriter();
            writer.Write("<ul class=\"awstoc\">");

            // put the shell config out first, then service by service
            foreach (var module in this._cmdletsByService.Values.Where(x => x.UseTitle).OrderBy(x => x.ModuleTitle))
            {
                GenerateServiceTOCEntry(writer, module);
            }
            foreach (var module in this._cmdletsByService.Values.Where(x => !x.UseTitle).OrderBy(x => x.ModuleName))
            {
                GenerateServiceTOCEntry(writer, module);
            }
            writer.Write("</ul>");

            return writer.ToString();
        }

        void GenerateServiceTOCEntry(StringWriter writer, TOCModuleEntry module)
        {
            // want legacy aliases to come at the bottom for each service
            var deferredAliases = new List<TOCCmdletEntry>();

            // emit the summary page for the service
            var summaryPageWriter = new ServiceCmdletsPageWriter(Options, OutputFolder, module.ModuleName, module.ModuleTitle, module.CmdletEntries);
            summaryPageWriter.Write();

            writer.Write("<li class=\"nav\" id=\"{2}\" onclick=\"updateContentPane('./items/{0}')\"><a class=\"nav\" href=\"./items/{0}\" onclick=\"updateContentPane('./items/{0}')\" target=\"contentpane\">{1}</a>",
                         summaryPageWriter.GenerateFilename(),
                         module.UseTitle ? module.ModuleTitle : module.ModuleName, 
                         summaryPageWriter.GetTOCID());
            writer.Write("<ul>");

            foreach (var cmdlet in module.CmdletEntries.OrderBy(x => x.CmdletName))
            {
                var cmdletPage = string.Format("{0}.html", cmdlet.CmdletName.Replace(' ', '_'));
                writer.Write("<li id=\"{2}\" class=\"nav leaf\"><a class=\"nav\" href=\"./items/{0}\" onclick=\"updateContentPane('./items/{0}')\" target=\"contentpane\">{1}</a></li>", 
                             cmdletPage, 
                             cmdlet.CmdletName,
                             cmdlet.TOCId);

                if (!string.IsNullOrEmpty(cmdlet.LegacyAlias))
                    deferredAliases.Add(cmdlet);
            }

            foreach (var cmdlet in deferredAliases.OrderBy(x => x.LegacyAlias))
            {
                var cmdletPage = string.Format("{0}.html", cmdlet.CmdletName.Replace(' ', '_'));
                writer.Write("<li id=\"{2}_alias\" class=\"nav leaf\"><a class=\"nav\" href=\"./items/{0}\" onclick=\"updateContentPane('./items/{0}')\" target=\"contentpane\">[alias] {1}</a></li>",
                                cmdletPage,
                                cmdlet.LegacyAlias,
                                cmdlet.TOCId);
            }

            writer.Write("</ul></li>");
        }
    }
}
