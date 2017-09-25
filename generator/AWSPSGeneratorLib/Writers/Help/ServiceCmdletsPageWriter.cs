using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Writers.Help
{
    internal class ServiceCmdletsPageWriter : BasePageWriter
    {
        readonly string _serviceName;
        private readonly IEnumerable<TOCCmdletEntry> _cmdlets;

        public ServiceCmdletsPageWriter(GeneratorOptions options, string outputFolder, string serviceName, IEnumerable<TOCCmdletEntry> cmdlets)
            : base(options, outputFolder)
        {
            this._serviceName = serviceName;
            this._cmdlets = cmdlets;
        }

        public override string GetTOCID()
        {
            return string.Format("{0}_cmdlets", _serviceName.Replace(' ', '_').Replace('/', '_'));
        }

        public override string GenerateFilename()
        {
            return string.Format("{0}_cmdlets.html", _serviceName.Replace(' ', '_').Replace('/', '_'));
        }

        protected override string GetTitle()
        {
            return _serviceName;
        }

        protected override string GetName()
        {
            return GetTitle();
        }

        protected override string GetService()
        {
            return null;
        }

        protected override string GetMetaDescription()
        {
            return string.Format("{0} Cmdlets", _serviceName);
        }

        protected override void WriteContent(System.IO.TextWriter writer)
        {
            AddCmdlets(writer);
        }

        void AddCmdlets(TextWriter writer)
        {
            var legacyAliases = new List<TOCCmdletEntry>();

            // might want sectioned output in future, eg to document type extensions
            AddMemberTableSectionHeader(writer, "Cmdlets", false);
            foreach (var cmdlet in _cmdlets.OrderBy(x => x.CmdletName))
            {
                AddRow(writer, cmdlet, "class");
                if (!string.IsNullOrEmpty(cmdlet.LegacyAlias))
                    legacyAliases.Add(cmdlet);
            }
            AddMemberTableSectionClosing(writer);

            if (legacyAliases.Count > 0)
            {
                AddMemberTableSectionHeader(writer, "Aliases", false);
                foreach (var cmdlet in legacyAliases.OrderBy(x => x.LegacyAlias))
                {
                    AddLegacyAliasRow(writer, cmdlet, "class");
                }
                AddMemberTableSectionClosing(writer);
            }
        }

        void AddRow(TextWriter writer, TOCCmdletEntry cmdlet, string cssImageClass)
        {
            writer.WriteLine("<tr>");

            writer.WriteLine("<td>");
            writer.WriteLine("<a href=\"./{0}.html\">{0}</a>", cmdlet.CmdletName);
            writer.WriteLine("</td>");

            writer.WriteLine("<td>");
            writer.WriteLine(cmdlet.Synopsis);
            writer.WriteLine("</td>");

            writer.WriteLine("</tr>");
        }

        void AddLegacyAliasRow(TextWriter writer, TOCCmdletEntry cmdlet, string cssImageClass)
        {
            writer.WriteLine("<tr>");

            writer.WriteLine("<td>");
            writer.WriteLine("<a href=\"./{0}.html\">{1}</a>", cmdlet.CmdletName, cmdlet.LegacyAlias);
            writer.WriteLine("</td>");

            writer.WriteLine("<td>");
            writer.WriteLine(cmdlet.Synopsis);
            writer.WriteLine("</td>");

            writer.WriteLine("</tr>");
        }
    }
}
