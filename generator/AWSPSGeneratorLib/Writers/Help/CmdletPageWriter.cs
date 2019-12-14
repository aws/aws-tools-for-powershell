using System.Collections.Generic;
using System.IO;
using System.Text;
using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Writers.Help
{
    internal class CmdletPageWriter : BasePageWriter
    {
        private readonly string _serviceName;
        private readonly string _moduleName;
        private readonly string _cmdletName;
        private readonly Dictionary<string, string> _pageElements = new Dictionary<string,string>();

        public const string SynopsisElementKey = "Synopsis";
        public const string DescriptionElementKey = "Description";
        public const string SyntaxElementKey = "Syntax";
        public const string OutputsElementKey = "Outputs";
        public const string ParametersElementKey = "Parameters";
        public const string CommonParametersElementKey = "CommonParameters";
        public const string NotesElementKey = "Notes";
        public const string ExamplesElementKey = "Examples";
        public const string RelatedLinksElementKey = "RelatedLinks";

        public CmdletPageWriter(GeneratorOptions options, string outputFolder, string serviceName, string moduleName, string cmdletName)
            : base(options, outputFolder)
        {
            this._serviceName = serviceName;
            this._moduleName = moduleName;
            this._cmdletName = cmdletName;
        }

        public void AddPageElement(string elementKey, string elementContent)
        {
            if (_pageElements.ContainsKey(elementKey))
                _pageElements[elementKey] = elementContent;
            else
                _pageElements.Add(elementKey, elementContent);
        }

        public override string GetTOCID()
        {
            return this._cmdletName;
        }

        public override string GenerateFilename()
        {
            return string.Format("{0}.html", _cmdletName.Replace(' ', '_'));
        }

        protected override string GetTitle()
        {
            var serviceAbbreviation = _moduleName == "Common" ? _serviceName : _moduleName;
            return string.Format("{0}: {1}", serviceAbbreviation, GetName());
        }

        protected override string GetName()
        {
            return string.Format("{0} Cmdlet", _cmdletName);
        }

        protected override string GetService()
        {
            return $"<div>{_serviceName}</div>" + GetModuleAvailability(_moduleName);
        }

        protected override string GetMetaDescription()
        {
            return _pageElements.ContainsKey(SynopsisElementKey) ? _pageElements[SynopsisElementKey] : GetTitle();
        }

        protected override void WriteContent(TextWriter writer)
        {
            // output in the same order as Get-Help -Full
            AddSynopsis(writer);
            AddSyntax(writer);
            AddDescription(writer);
            AddParameterList(writer);
            AddCommonParameters(writer);
            AddOutputs(writer);
            AddNotes(writer);
            AddExamples(writer);
            AddRelatedLinks(writer);
            AddSupportedVersion(writer);
        }

        void AddSynopsis(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(SynopsisElementKey))
                return;

            AddSectionHeader(writer, "Synopsis");
            writer.WriteLine("<div class=\"synopsis\">{0}</div>", _pageElements[SynopsisElementKey]);
            AddSectionClosing(writer);
        }

        void AddDescription(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(DescriptionElementKey))
                return;

            AddSectionHeader(writer, "Description");
            writer.WriteLine("<div class=\"description\">{0}</div>", _pageElements[DescriptionElementKey]);
            AddSectionClosing(writer);
        }

        void AddSyntax(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(SyntaxElementKey))
                return;

            AddSectionHeader(writer, "Syntax");
            writer.WriteLine("<div class=\"syntax\"><pre>{0}</pre></div>", _pageElements[SyntaxElementKey]);
            AddSectionClosing(writer);
        }

        void AddParameterList(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(ParametersElementKey))
                return;

            AddSectionHeader(writer, "Parameters");
            writer.WriteLine("<div class=\"parameters\">{0}</div>", _pageElements[ParametersElementKey]);
            AddSectionClosing(writer);
        }

        void AddCommonParameters(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(CommonParametersElementKey))
                return;

            AddSectionHeader(writer, "Common Credential and Region Parameters");
            writer.WriteLine("<div class=\"parameters\">{0}</div>", _pageElements[CommonParametersElementKey]);
            AddSectionClosing(writer);
        }

        void AddOutputs(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(OutputsElementKey))
                return;

            AddSectionHeader(writer, "Outputs");
            writer.WriteLine("<div class=\"outputs\">{0}</div>", _pageElements[OutputsElementKey]);
            AddSectionClosing(writer);
        }

        void AddNotes(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(NotesElementKey))
                return;

            AddSectionHeader(writer, "Notes");
            writer.WriteLine("<div class=\"notes\">{0}</div>", _pageElements[NotesElementKey]);
            AddSectionClosing(writer);
        }

        void AddExamples(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(ExamplesElementKey))
                return;

            AddSectionHeader(writer, "Examples");
            writer.WriteLine("<div class=\"examples\">{0}</div>", _pageElements[ExamplesElementKey]);
            AddSectionClosing(writer);
        }

        void AddRelatedLinks(TextWriter writer)
        {
            if (!_pageElements.ContainsKey(RelatedLinksElementKey))
                return;

            AddSectionHeader(writer, "Related Links");
            writer.WriteLine("<div class=\"related\">{0}</div>", _pageElements[RelatedLinksElementKey]);
            AddSectionClosing(writer);
        }

        void AddSupportedVersion(TextWriter writer)
        {
            AddSectionHeader(writer, "Supported Version");
            
            var sb = new StringBuilder();
            sb.Append("<div class=\"versioninfo\">");
            sb.Append("<p><strong>AWS Tools for PowerShell: </strong><span id=\"assemblyVersion\">2.x.y.z</span></p>");
            sb.Append("</div");
            writer.WriteLine(sb);

            AddSectionClosing(writer);
        }
    }
}
