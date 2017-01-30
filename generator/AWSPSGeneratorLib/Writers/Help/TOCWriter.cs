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

    public class TOCWriter : BaseTemplateWriter
    {
        public const string ShellConfigurationTOCName = "Shell Configuration";

        readonly Dictionary<string, List<TOCCmdletEntry>> _cmdletsByService = new Dictionary<string, List<TOCCmdletEntry>>();

        public TOCWriter(GeneratorOptions options, string outputFolder)
            : base(options, outputFolder)
        {
        }

        // target page is synthesized from the cmdlet name once we emit the overall TOC; we will also
        // generate a summary page of cmdlets with their synopsis for the service
        public void AddServiceCmdlet(string serviceName, string cmdletName, string tocId, string synopsis, string legacyAlias)
        {
            List<TOCCmdletEntry> cmdlets = null;

            if (_cmdletsByService.ContainsKey(serviceName))
                cmdlets = _cmdletsByService[serviceName];
            else
            {
                cmdlets = new List<TOCCmdletEntry>();
                _cmdletsByService.Add(serviceName, cmdlets);
            }

            // toc is updated in several loops, so skip dupe attempts to assist
            // caller code
            if (cmdlets.Count > 0)
            {
                if (cmdlets.Any(tocCmdletEntry => string.Equals(cmdletName, tocCmdletEntry.CmdletName, StringComparison.OrdinalIgnoreCase)))
                    return;
            }

            cmdlets.Add(new TOCCmdletEntry { CmdletName = cmdletName, TOCId = tocId, Synopsis = synopsis, LegacyAlias = legacyAlias });
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
            GenerateServiceTOCEntry(writer, "Shell Configuration");
            foreach (var serviceName in this._cmdletsByService.Keys.OrderBy(x => x))
            {
                if (serviceName.Equals(ShellConfigurationTOCName))
                    continue;

                GenerateServiceTOCEntry(writer, serviceName);
            }
            writer.Write("</ul>");

            return writer.ToString();
        }

        void GenerateServiceTOCEntry(StringWriter writer, string serviceName)
        {
            var cmdlets = _cmdletsByService[serviceName];

            // want legacy aliases to come at the bottom for each service
            var deferredAliases = new List<TOCCmdletEntry>();

            // emit the summary page for the service
            var summaryPageWriter = new ServiceCmdletsPageWriter(Options, OutputFolder, serviceName, cmdlets);
            summaryPageWriter.Write();

            writer.Write("<li class=\"nav\" id=\"{2}\" onclick=\"updateContentPane('./items/{0}')\"><a class=\"nav\" href=\"./items/{0}\" onclick=\"updateContentPane('./items/{0}')\" target=\"contentpane\">{1}</a>",
                         summaryPageWriter.GenerateFilename(), 
                         serviceName, 
                         summaryPageWriter.GetTOCID());
            writer.Write("<ul>");

            foreach (var cmdlet in cmdlets.OrderBy(x => x.CmdletName))
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
