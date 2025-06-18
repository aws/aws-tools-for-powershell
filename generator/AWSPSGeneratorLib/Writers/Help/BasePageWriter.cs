using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Writers.Help
{
    /// <summary>
    /// Base class for all web help page output writers
    /// </summary>
    internal abstract class BasePageWriter
    {
        protected GeneratorOptions Options { get; private set; }

        protected string OutputFolder { get; private set; }

        protected string RelativePathToRoot { get; private set; }

        private const string FeedbackSection =
            "<!-- BEGIN-FEEDBACK-SECTION --><span class=\"feedback\">{0}</span><!-- END-FEEDBACK-SECTION -->";


        

        protected BasePageWriter(GeneratorOptions options, string outputFolder)
        {
            Options = options;
            OutputFolder = outputFolder;
        }

        protected abstract string GetTitle();
        protected abstract string GetService();
        protected abstract string GetName();
        protected abstract string GetMetaDescription();

        public abstract string GenerateFilename();
        public abstract string GetTOCID();

        protected abstract void WriteContent(TextWriter writer);

        public void Write()
        {
            var filename = Path.Combine(OutputFolder, "items", GenerateFilename());
            RelativePathToRoot = ComputeRelativeRootPath(OutputFolder, filename);

            var directory = new FileInfo(filename).Directory.FullName;

            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Creating Directory: {0}", directory);
                Directory.CreateDirectory(directory);
            }

            using (var writer = new StringWriter())
            {
                writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                        writer.WriteLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"/>");

                        writer.WriteLine("<meta name=\"guide-name\" content=\"Cmdlet Reference\"/>");
                        writer.WriteLine("<meta name=\"service-name\" content=\"AWS Tools for PowerShell\"/>");

                        writer.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}/resources/style.css\"/>", RelativePathToRoot);
                        writer.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}/resources/syntaxhighlighter/shCore.css\">", RelativePathToRoot);
                        writer.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}/resources/syntaxhighlighter/shThemeDefault.css\">", RelativePathToRoot);
                        writer.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}/resources/psstyle.css\"/>", RelativePathToRoot);

                        // every page needs a title, meta description and canonical url to satisfy indexing
                        writer.WriteLine("<meta name=\"description\" content=\"{0}\">", GetMetaDescription());
                        writer.WriteLine("<title>{0} | AWS Tools for PowerShell</title>", GetTitle());                        
                        writer.WriteLine("<script type=\"text/javascript\" src=\"/assets/js/awsdocs-boot.js\"></script>");
                        writer.WriteLine("<link rel=\"canonical\" href=\"http://docs.aws.amazon.com/powershell/v5/reference/index.html?page={0}&tocid={1}\"/>",
                                         this.GenerateFilename(),
                                         this.GetTOCID());

                    writer.WriteLine("</head>");

                    writer.WriteLine("<body>");

                        // every page needs two hidden divs giving the search indexer the product title and guide name
                        writer.WriteLine("<div id=\"product_name\">AWS Tools for Windows PowerShell</div>");
                        writer.WriteLine("<div id=\"guide_name\">Command Reference</div>");

                        this.WriteRegionDisclaimer(writer);

                        this.WriteHeader(writer);
                        this.WriteToolbar(writer);

                        writer.WriteLine("<div id=\"pageContent\">");
                            this.WriteContent(writer);
                        writer.WriteLine("</div>");

                        this.WriteFooter(writer);                        
                    writer.WriteLine("</body>");
                writer.WriteLine("</html>");

                var content = writer.ToString();

                using (var fileWriter = new StreamWriter(filename))
                {
                    fileWriter.Write(content);
                }
            }
        }

        protected virtual void WriteRegionDisclaimer(TextWriter writer)
        {
			// comment disclaimer is used by DCA pipeline only at present
            writer.WriteLine("<!--REGION_DISCLAIMER_DO_NOT_REMOVE-->");

            // The BJS disclaimer is handled using js/css, and is not (yet)
            // injected via a pipeline. It must not be present in the docs we
            // deploy to dca.
            writer.WriteLine("<!-- BEGIN-SECTION -->");
            writer.WriteLine("<div id=\"regionDisclaimer\">");
            writer.WriteLine("<p>{0}</p>", string.Format(WebHelpGenerator.CNNorth1RegionDisclaimerTemplate, Options.CNNorth1RegionDocsDomain));
            writer.WriteLine("</div>");
            writer.WriteLine("<!-- END-SECTION -->");
        }

        protected virtual void WriteHeader(TextWriter writer)
        {
            writer.WriteLine("<div id=\"pageHeader\">");
                writer.WriteLine("<div id=\"titles\">");
                    writer.WriteLine("<h1>{0}</h1>", this.GetName());
                    if (this.GetService() != null)
                        writer.WriteLine("<h2>{0}</h2>", this.GetService());
                writer.WriteLine("</div>");
            writer.WriteLine("</div>");
        }

        protected virtual void WriteToolbar(TextWriter writer)
        {
            writer.WriteLine("<div id=\"pageToolbar\">");
                writer.WriteLine("<!-- BEGIN-SECTION -->");
                writer.WriteLine("<div id=\"search\">");
                    writer.WriteLine("<form action=\"/search/doc-search.html\" target=\"_blank\" onsubmit=\"return AWSHelpObj.searchFormSubmit(this);\" method=\"get\">");
                        writer.WriteLine("<div id=\"sfrm\">");
                            writer.WriteLine("<span id=\"lbl\">");
                                writer.WriteLine("<label>Search: </label>");
                            writer.WriteLine("</span>");
                            writer.WriteLine("<select name=\"searchPath\" id=\"sel\">");
                                writer.WriteLine("<option value=\"all\">Entire Site</option>");
                                writer.WriteLine("<option value=\"articles\">Articles &amp; Tutorials</option>");
                                writer.WriteLine("<option value=\"documentation\">Documentation</option>");
                                writer.WriteLine("<option value=\"documentation-product\">Documentation - This Product</option>");
                                writer.WriteLine("<option selected=\"\" value=\"documentation-guide\">Documentation - This Guide</option>");
                                writer.WriteLine("<option value=\"releasenotes\">Release Notes</option>");
                                writer.WriteLine("<option value=\"code\">Sample Code &amp; Libraries</option>");
                            writer.WriteLine("</select>");
                            writer.WriteLine("<input type=\"text\" name=\"searchQuery\" id=\"sq\">");
                            writer.WriteLine("<input type=\"image\" alt=\"Go\" src=\"{0}/resources/search-button.png\" id=\"sb\">", RelativePathToRoot);
                        writer.WriteLine("</div>");
                        writer.WriteLine("<input id=\"this_doc_product\" type=\"hidden\" value=\"AWS Tools for Windows PowerShell\" name=\"this_doc_product\">");
                        writer.WriteLine("<input id=\"this_doc_guide\" type=\"hidden\" value=\"Command Reference\" name=\"this_doc_guide\">");
                        writer.WriteLine("<input type=\"hidden\" value=\"en_us\" name=\"doc_locale\">");
                    writer.WriteLine("</form>");
                writer.WriteLine("</div>");
                writer.WriteLine("<!-- END-SECTION -->");
            writer.WriteLine("</div>");
        }

        protected virtual void WriteFooter(TextWriter writer)
        {
            writer.WriteLine("<div id=\"pageFooter\">");
                writer.WriteLine("<span class=\"newline linkto\"><a href=\"javascript:void(0)\" onclick=\"AWSHelpObj.displayLink('{0}', '{1}')\">Link to this page</a></span>", 
                                 this.GenerateFilename(), 
                                 this.GetTOCID());
                writer.WriteLine("<span class=\"divider\">&nbsp;</span>");
                writer.WriteLine(FeedbackSection, GenerateFeedbackHTML());
                writer.WriteLine("<div id=\"awsdocs-legal-zone-copyright\"></div>");
            writer.WriteLine("</div>");
                
            WriteScriptFiles(writer);
        }

        private string GenerateFeedbackHTML()
        {
            string filename = Path.GetFileNameWithoutExtension(GenerateFilename());
            string baseUrl = "https://docs.aws.amazon.com/forms/aws-doc-feedback";
            string queryString = string.Format("?service_name={0}&amp;topic_url=https://docs.aws.amazon.com/powershell/v5/reference/items/{1}.html",
                "PowerShell-Ref",  // service_name
                filename   // guide_name
                );
            string fullUrl = baseUrl + queryString;

            string feedbackContentFormat = "<span class=\"feedbackLinks\">" +
                                            "<!-- BEGIN-FEEDBACK-SECTION -->" +
                                            "Did this page help you?&nbsp;&nbsp;" +
                                            "<a href=\"http://docs.aws.amazon.com/powershell/v5/reference/feedbackyes.html?topic_id={0}\" target=\"_parent\">Yes</a>&nbsp;&nbsp;" +
                                            "<a href=\"http://docs.aws.amazon.com/powershell/v5/reference/feedbackno.html?topic_id={0}\" target=\"_parent\">No</a>&nbsp;&nbsp;&nbsp;" +
                                            "<a href=\"{1}\" target=\"_parent\">Tell us about it...</a>" +
                                            "<!-- END-FEEDBACK-SECTION -->" +
                                            "</span>";
            string feedbackContent = string.Format(feedbackContentFormat, filename, fullUrl);
            return feedbackContent;
        }

        protected virtual void WriteScriptFiles(TextWriter writer)
        {
            writer.WriteLine("<script type=\"text/javascript\" src=\"{0}/resources/jquery.min.js\"></script>", RelativePathToRoot);
            writer.WriteLine("<script type=\"text/javascript\">jQuery.noConflict();</script>");
            writer.WriteLine("<script type=\"text/javascript\" src=\"{0}/resources/parseuri.js\"></script>", RelativePathToRoot);
            writer.WriteLine("<script type=\"text/javascript\" src=\"{0}/resources/pagescript.js\"></script>", RelativePathToRoot);
            writer.WriteLine("<!-- BEGIN-SECTION -->");
            writer.WriteLine("<script type=\"text/javascript\">");
            writer.WriteLine("jQuery(function ($) {");
            writer.WriteLine("var host = parseUri($(window.parent.location).attr('href')).host;");
            writer.WriteLine("if (AWSHelpObj.showRegionalDisclaimer(host)) {");
            writer.WriteLine("$(\"div#regionDisclaimer\").css(\"display\", \"block\");");
            writer.WriteLine("} else {");
            writer.WriteLine("$(\"div#regionDisclaimer\").remove();");
            writer.WriteLine("}");
            writer.WriteLine("AWSHelpObj.setAssemblyVersion();");            
            writer.WriteLine("});");
            writer.WriteLine("</script>");
            writer.WriteLine("<!-- END-SECTION -->");
            
            writer.WriteLine("<script type=\"text/javascript\" src=\"{0}/resources/syntaxhighlighter/shCore.js\"></script>", RelativePathToRoot);
            writer.WriteLine("<script type=\"text/javascript\" src=\"{0}/resources/syntaxhighlighter/shBrushCSharp.js\"></script>", RelativePathToRoot);
            writer.WriteLine("<script type=\"text/javascript\" src=\"{0}/resources/syntaxhighlighter/shBrushPlain.js\"></script>", RelativePathToRoot);
            writer.WriteLine("<script type=\"text/javascript\" src=\"{0}/resources/syntaxhighlighter/shBrushXml.js\"></script>", RelativePathToRoot);
            writer.WriteLine("<script type=\"text/javascript\">SyntaxHighlighter.all()</script>");

        }

        protected void AddMemberTableSectionHeader(TextWriter writer, string name, bool showIconColumn = true)
        {
            AddMemberTableSectionHeader(writer, name, showIconColumn, "Name", "Description");
        }

        protected void AddMemberTableSectionHeader(TextWriter writer, string name, bool showIconColumn, string nameColumnName, string descriptionColumnName)
        {
            writer.WriteLine("<div>");
                writer.WriteLine("<div>");
                    writer.WriteLine("<div class=\"collapsibleSection\">");
                        writer.WriteLine("<h2 id=\"{1}\" class=\"title\">{0}</h2>", name, name.ToLower());
                    writer.WriteLine("</div>");
                writer.WriteLine("</div>");

                writer.WriteLine("<div class=\"sectionbody\">");
                    writer.WriteLine("<table class=\"members\">");
                    writer.WriteLine("<tbody>");
                        writer.WriteLine("<tr>");
                            if(showIconColumn)
                                writer.WriteLine("<th class=\"iconColumn\">&nbsp;</th>");

                            writer.WriteLine("<th class=\"nameColumn\">{0}</th>", nameColumnName);
                            writer.WriteLine("<th class=\"descriptionColumn\">{0}</th>", descriptionColumnName);
                        writer.WriteLine("</tr>");
        }

        protected void AddMemberTableSectionClosing(TextWriter writer)
        {
                        writer.WriteLine("</tbody>");
                    writer.WriteLine("</table>");
                writer.WriteLine("</div>");
            writer.WriteLine("</div>");
        }

        protected void AddSectionHeader(TextWriter writer, string name)
        {
            writer.WriteLine("<div>");
                writer.WriteLine("<div>");
                    writer.WriteLine("<div class=\"collapsibleSection\">");
                        writer.WriteLine("<h2 id=\"{1}\" class=\"title\">{0}</h2>", name, name.ToLower());
                    writer.WriteLine("</div>");
                writer.WriteLine("</div>");

                writer.WriteLine("<div class=\"sectionbody\">");
        }

        protected void AddSectionClosing(TextWriter writer)
        {
                writer.WriteLine("</div>");
            writer.WriteLine("</div>");
        }

        protected string GetModuleAvailability(string moduleName)
        {
            var inMonolithic = moduleName != TOCWriter.InstallerModuleName;
            var inModular = !WebHelpGenerator.NonModularizedServices.Contains(moduleName);

            var text = new StringBuilder("Available in ");
            if (inModular)
            {
                text.Append($"<a href=\"https://www.powershellgallery.com/packages/AWS.Tools.{moduleName}/\" target=\"_blank\" rel=\"noopener noreferrer\">AWS.Tools.{moduleName}</a>");
            }
            if (inMonolithic)
            {
                text.Append(inModular ? ", " : string.Empty);
                text.Append($"<a href=\"https://www.powershellgallery.com/packages/AWSPowerShell.NetCore/\" target=\"_blank\" rel=\"noopener noreferrer\">AWSPowerShell.NetCore</a>");
                text.Append(" and ");
                text.Append($"<a href=\"https://www.powershellgallery.com/packages/AWSPowerShell/\" target=\"_blank\" rel=\"noopener noreferrer\">AWSPowerShell</a>");
            }
            return text.ToString();
        }

        // computes the relative distance from root of a filename and returns a ../ sequence
        // that can step back far enough to get to root
        private static string ComputeRelativeRootPath(string rootFolder, string filename)
        {
            var relativePath = new StringBuilder();

            var filepath = Path.GetDirectoryName(filename);
            while (!filepath.Equals(rootFolder, StringComparison.OrdinalIgnoreCase))
            {
                if (relativePath.Length > 0)
                    relativePath.Append("/");
                relativePath.Append("..");
                filepath = Path.GetDirectoryName(filepath);
            }

            return relativePath.ToString();
        }
    }
}
