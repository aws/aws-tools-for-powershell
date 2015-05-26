using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Xml;

using AWSPowerShellGenerator.Utils;
using AWSPowerShellGenerator.Writers.Help;

namespace AWSPowerShellGenerator.Generators
{
    public class WebHelpGenerator : HelpGeneratorBase
    {
        const int MAX_FILE_SIZE = 160; // matching sdk

        #region Public properties

        // the root path of the AWS .Net sdk docs; eg http://docs.aws.amazon.com/sdkfornet/latest/apidocs
        public string SDKHelpRoot { get; set; }

        // the root path of the docs domain for cn-north-1 region
        public string CNNorth1RegionDocsDomain { get; set; }

        public static string CNNorth1RegionDisclaimerTemplate
                    = "AWS services or capabilities described in AWS Documentation may vary by region/location. "
                    + "Click <a href=\"https://{0}/en_us/aws/latest/userguide/services.html\">Getting Started with Amazon AWS</a> to see specific differences applicable to the China (Beijing) Region.";

        public string BJSRegionDisclaimer
        {
            get
            {
                return string.Format(CNNorth1RegionDisclaimerTemplate, CNNorth1RegionDocsDomain);
            }
        }

        #endregion

        protected static Dictionary<string, string> _msdnDocLinks = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "System.String", "http://msdn.microsoft.com/en-us/library/system.string.aspx"
            },
            {
                "System.Collections.Hashtable", "http://msdn.microsoft.com/en-us/library/system.collections.hashtable.aspx"
            }
        };

        protected override void GenerateHelper()
        {
            base.GenerateHelper();

            if (string.IsNullOrEmpty(SDKHelpRoot))
                SDKHelpRoot = "http://docs.aws.amazon.com/sdkfornet/latest/apidocs/";
            else if (!SDKHelpRoot.EndsWith("/"))
                SDKHelpRoot = SDKHelpRoot + "/";

            Console.WriteLine("Generating web help documentation, SDK help base URI set to {0}", SDKHelpRoot);

            var buildLogsPath = Path.Combine(this.Options.RootPath, "logs");
            if (!Directory.Exists(buildLogsPath))
                Directory.CreateDirectory(buildLogsPath);

            var logFile = Path.Combine(buildLogsPath, Name + ".dll-WebHelp.log");
            var oldWriter = Console.Out;
            
            try
            {
                using (var consoleWriter = new StreamWriter(File.OpenWrite(logFile)))
                {
                    Console.SetOut(consoleWriter);

                    CleanWebHelpOutputFolder(OutputFolder);
                    CopyWebHelpStaticFiles(OutputFolder);
                    CreateVersionInfoFile(Path.Combine(OutputFolder, "items"));

                    var tocWriter = new TOCWriter(Options, OutputFolder);

                    foreach (var cmdletType in CmdletTypes)
                    {
                        var owningService = DetermineCmdletServiceOwner(cmdletType);
                        InspectCmdletAttributes(cmdletType);

                        string synopsis = null;
                        if (AWSCmdletAttribute == null)
                        {
                            Console.WriteLine("Unable to find AWSCmdletAttribute for type " + cmdletType.FullName);
                        }
                        else
                        {
                            var cmdletReturnAttributeType = AWSCmdletAttribute.GetType();
                            synopsis =
                                cmdletReturnAttributeType.GetProperty("Synopsis").GetValue(AWSCmdletAttribute, null) as
                                string;
                        }

                        foreach (var cmdletAttribute in CmdletAttributes)
                        {
                            var hasDynamicParams = DynamicParamsType.IsAssignableFrom(cmdletType);

                            var typeDocumentation = DocumentationUtils.GetTypeDocumentation(cmdletType,
                                                                                            AssemblyDocumentation);
                            typeDocumentation = DocumentationUtils.FormatXMLForPowershell(typeDocumentation, true);
                            Console.WriteLine("Cmdlet = {0}", cmdletType.FullName);
                            if (hasDynamicParams)
                                Console.WriteLine("This cmdlet has dynamic parameters!");
                            Console.WriteLine("Documentation = {0}", typeDocumentation);

                            var cmdletName = cmdletAttribute.VerbName + "-" + cmdletAttribute.NounName;

                            var allProperties = GetRootSimpleProperties(cmdletType);
                            var serviceAbbreviation = GetServiceAbbreviation(cmdletType);

                            var cmdletPageWriter = new CmdletPageWriter(Options, OutputFolder, owningService, cmdletName);

                            WriteDetails(cmdletPageWriter, cmdletAttribute, typeDocumentation, cmdletName, synopsis);
                            WriteSyntax(cmdletPageWriter, cmdletName, allProperties);
                            WriteParameters(cmdletPageWriter, cmdletName, allProperties);
                            WriteInputs(cmdletPageWriter, allProperties);
                            WriteOutputs(cmdletPageWriter, AWSCmdletOutputAttributes);
                            WriteNotes(cmdletPageWriter);
                            WriteExamples(cmdletPageWriter, cmdletName);
                            WriteRelatedLinks(cmdletPageWriter, serviceAbbreviation, cmdletName);

                            cmdletPageWriter.Write();
                            tocWriter.AddServiceCmdlet(owningService, cmdletName, cmdletPageWriter.GetTOCID(), synopsis);
                        }
                    }

                    tocWriter.Write();
                }
            }
            finally
            {
                Console.SetOut(oldWriter);
            }
        }

        private static void WriteDetails(CmdletPageWriter writer, CmdletAttribute cmdletAttribute, string typeDocumentation, string cmdletName, string synopsis)
        {
            if (!string.IsNullOrEmpty(synopsis))
                writer.AddPageElement(CmdletPageWriter.SynopsisElementKey, synopsis);
            if (!string.IsNullOrEmpty(typeDocumentation))
                writer.AddPageElement(CmdletPageWriter.DescriptionElementKey, typeDocumentation);
        }

        private static void WriteSyntax(CmdletPageWriter writer, string cmdletName, IEnumerable<SimplePropertyInfo> allProperties)
        {
            var sb = new StringBuilder();

            // Microsoft cmdlets show params in syntax in defined but non-alpha order. Use the ordering we found
            // during reflection here in the hope the sdk has them in 'most important' order. Also, if there is
            // four or less params, keep the syntax on one line.
            sb.AppendFormat("<div class=\"cmdlet\">{0}</div>", cmdletName);
            var paramCount = allProperties.Count();
            if (paramCount > 0)
            {
                sb.Append("<div class=\"paramlist\">");
                for (var i = 0; i < paramCount; i++)
                {
                    var property = allProperties.ElementAt(i);
                    sb.AppendFormat("<div class=\"{0}\">-{1} &lt;{2}&gt;</div>",
                                    paramCount < 5 ? "inlineParam" : "wrappedParam",
                                    property.Name, 
                                    GetTypeDisplayName(property.PropertyType, false));
                }
                sb.Append("</div>");
            }

            writer.AddPageElement(CmdletPageWriter.SyntaxElementKey, sb.ToString());
        }

        private void WriteParameters(CmdletPageWriter writer, string cmdletName, IEnumerable<SimplePropertyInfo> allProperties)
        {
            var sb = new StringBuilder();

            // Microsoft cmdlets list the parameters in alpha order here, so do the same (leaving metadata/paging
            // params in the correct order)
            foreach (var property in allProperties.OrderBy(p => p.Name))
            {
                sb.Append("<div class=\"parameter\">");

                var typeName = GetTypeDisplayName(property.PropertyType, true);
                var inputTypeDocLink = PredictHtmlDocsLink(typeName);
                if (!string.IsNullOrEmpty(inputTypeDocLink))
                {
                    sb.AppendFormat("<div class=\"parameterName\">-{0} &lt;<a href=\"{1}\"{2}>{3}</a>&gt;</div>", 
                                        property.Name, 
                                        inputTypeDocLink,
                                        RequiresLinkTarget(typeName) ? " target=\"_blank\"" : "",
                                        GetTypeDisplayName(property.PropertyType, false));
                }
                else
                {
                    sb.AppendFormat("<div class=\"parameterName\">-{0} &lt;{1}&gt;</div>", 
                                    property.Name, 
                                    GetTypeDisplayName(property.PropertyType, false));
                }

                sb.AppendFormat("<div class=\"parameterDescription\">{0}</div>", property.PowershellWebDocumentation);

                bool isRequired;
                string pipelineInput;
                string position;
                InspectParameter(property, out isRequired, out pipelineInput, out position);

                sb.Append("<div class=\"parameterAttributes\"><table>");
                sb.AppendFormat("<tr><td class=\"col1\">Required?</td><td class=\"col2\">{0}</td></tr>", isRequired.ToString());
                sb.AppendFormat("<tr><td class=\"col1\">Position?</td><td class=\"col2\">{0}</td></tr>", position);
                //sb.AppendFormat("<tr><td class=\"col1\">Default value</td><td class=\"col2\">{0}</td></tr>", );
                sb.AppendFormat("<tr><td class=\"col1\">Accept pipeline input?</td><td class=\"col2\">{0}</td></tr>", pipelineInput);
                //sb.AppendFormat("<tr><td class=\"col1\">Accept wildcard characters?</td><td class=\"col2\">{0}</td></tr>", );
                sb.Append("</table></div>");

                sb.Append("</div>");
            }

            if (sb.Length == 0)
                sb.Append("This cmdlet has no parameters.");

            writer.AddPageElement(CmdletPageWriter.ParametersElementKey, sb.ToString());
        }

        private void WriteInputs(CmdletPageWriter writer, IEnumerable<SimplePropertyInfo> allProperties)
        {
            var sb = new StringBuilder();

            foreach (var simplePropertyInfo in allProperties)
            {
                if (simplePropertyInfo.PsParameterAttribute != null &&
                    simplePropertyInfo.PsParameterAttribute.ValueFromPipeline)
                {
                    // if the input type has a predictable sdk/msdn html address, construct the link
                    var inputTypeDocLink = PredictHtmlDocsLink(simplePropertyInfo.PropertyTypeName);

                    sb.Append("<div class=\"inputType\">");
                    if (!string.IsNullOrEmpty(inputTypeDocLink))
                        sb.AppendFormat("<a href=\"{0}\"{1}>{2}</a>", 
                                        inputTypeDocLink,
                                        RequiresLinkTarget(simplePropertyInfo.PropertyTypeName) ? " target=\"_blank\"" : "",
                                        simplePropertyInfo.PropertyTypeName);
                    else
                        sb.Append(simplePropertyInfo.PropertyTypeName);
                    sb.Append("</div>");
                    sb.AppendFormat("<div class=\"inputDescription\">You can pipe a {0} object to this cmdlet for the {1} parameter.</div>", 
                                    GetTypeDisplayName(simplePropertyInfo.PropertyType, false),
                                    simplePropertyInfo.CmdletParameterName);
                    break;
                }
            }

            if (sb.Length == 0)
                sb.Append("This cmdlet does not accept pipeline input.");

            writer.AddPageElement(CmdletPageWriter.InputsElementKey, sb.ToString());
        }

        private void WriteOutputs(CmdletPageWriter writer, IEnumerable<object> outputAttributes)
        {
            var sb = new StringBuilder();

            // attributing describing outputs means we don't need to worry about detecting sb.Length > 0 on exit
            foreach (var outputAttribute in outputAttributes)
            {
                var attributeType = outputAttribute.GetType();
                var returnType = attributeType.GetProperty("ReturnType").GetValue(outputAttribute, null) as string;
                var description = attributeType.GetProperty("Description").GetValue(outputAttribute, null) as string;

                sb.Append("<div class=\"output\">");
                if (!string.IsNullOrEmpty(returnType))
                {
                    // if the return type has a predictable sdk/msdn html address, construct the link
                    string returnTypeDocLink = null;
                    if (returnType != string.Empty)
                        returnTypeDocLink = PredictHtmlDocsLink(returnType);

                    sb.Append("<div class=\"outputType\">");
                    if (!string.IsNullOrEmpty(returnTypeDocLink))
                        sb.AppendFormat("<a href=\"{0}\"{1}>{2}</a>", 
                                        returnTypeDocLink, 
                                        RequiresLinkTarget(returnType) ? " target=\"_blank\"" : "",
                                        returnType);
                    else
                        sb.Append(returnType);
                    sb.Append("</div>");
                }
                sb.AppendFormat("<div class=\"outputDescription\">{0}</div>", description);
                sb.Append("</div>");
            }

            writer.AddPageElement(CmdletPageWriter.OutputsElementKey, sb.ToString());
        }

        private static void WriteNotes(CmdletPageWriter writer)
        {
            
        }

        private const string psCmdlinePrefix = "PS C:\\>";

        private void WriteExamples(CmdletPageWriter writer, string cmdletName)
        {
            XmlDocument document;

            // lack of examples will be reported in the logs by the native help generator
            if (!ExamplesCache.TryGetValue(cmdletName, out document))
                return;

            var set = document.SelectSingleNode("examples");
            if (set == null)
                return;

            var sb = new StringBuilder();

            int exampleIndex = 1;
            var examples = set.SelectNodes("example");
            foreach (XmlNode example in examples)
            {
                sb.AppendFormat("<h4>Example {0}</h4>", exampleIndex);
                sb.Append("<pre class=\"example\">");

                var code = example.SelectSingleNode("code");
                if (code == null)
                    Logger.LogError("Unable to find examples <code> tag for cmdlet " + cmdletName);

                var codeSample = code.InnerText.Trim('\r', '\n');
                if (codeSample.IndexOfAny(new [] { '\n', '\r' }) == -1)
                {
                    if (!codeSample.StartsWith(psCmdlinePrefix))
                        codeSample = string.Concat(psCmdlinePrefix, codeSample);
                }
                
                codeSample = codeSample.Replace("\r", "");
                codeSample = codeSample.Replace("\n", "<br/>");
                sb.AppendFormat("<div class=\"code\">{0}</div>", codeSample);

                var description = example.SelectSingleNode("description");
                if (description == null)
                    Logger.LogError("Unable to find examples <description> tag for cmdlet " + cmdletName);
                
                // use InnerXml here to allow for <br/> and other layout format tags, these get stripped 
                // if we use InnerText
                var innerXml = description.InnerXml;
                // convert <url>link</url> elements to anchors (pshelp strips the tags to leave the link)
                /*if (innerXml.Contains("<href>"))
                {
                }*/
                sb.AppendFormat("<div class=\"description\">{0}</div>", innerXml);

                sb.Append("</pre>");

                exampleIndex++;
            }

            writer.AddPageElement(CmdletPageWriter.ExamplesElementKey, sb.ToString());
        }

        private void WriteRelatedLinks(CmdletPageWriter writer, string serviceAbbreviation, string cmdletName)
        {
            // putting common credential and region parameters into a related link is the simplest
            // approach, but only do it for service cmdlets
            if (serviceAbbreviation.Equals("Common", StringComparison.Ordinal))
                return;

            var sb = new StringBuilder();

            sb.Append("<div class=\"relatedLink\">");
            sb.AppendFormat("<a href=\"{1}\" target=_blank>{0}</a>", "Common Credential and Region Parameters", "./pstoolsref-commonparams.html");
            sb.Append("</div>");

            XmlDocument document;
            if (LinksCache.TryGetValue(serviceAbbreviation, out document))
            {
                ConstructLinks(sb, document, "*");
                ConstructLinks(sb, document, cmdletName);
            }

            writer.AddPageElement(CmdletPageWriter.RelatedLinksElementKey, sb.ToString());
        }

        public void ConstructLinks(StringBuilder sb, XmlDocument document, string target)
        {
            var xpath = string.Format("links/set[@target='{0}']", target);
            var set = document.SelectSingleNode(xpath);
            if (set == null)
            {
                Console.WriteLine("Unable to find related links for target {0} in service {1}, probed xpath {2}", target, document.Name, xpath);
                return;
            }

            // to allow easier management over time of the link files, filter out sets who don't yet have
            // content but are present simply as templates, that way we don't need to comment out sections
            // of the file
            var firstLink = set.FirstChild;
            if (firstLink == null || string.IsNullOrEmpty(firstLink.InnerText))
            {
                Console.WriteLine("Skipping empty link set for target {0} in {1}", target, document.Name);
                return;
            }


            var links = set.SelectNodes("link");
            foreach (XmlNode link in links)
            {

                string displayname = null;
                try { displayname = link.Attributes["name"].InnerText; } catch {}

                if (string.IsNullOrEmpty(displayname) || string.IsNullOrEmpty(link.InnerText))
                {
                    Logger.LogError("Malformed link {0}, skipping" + link.OuterXml.ToString());
                }

                sb.Append("<div class=\"relatedLink\">");
                sb.AppendFormat("<a href=\"{1}\" target=_blank>{0}</a>", displayname, link.InnerText);
                sb.Append("</div>");
            }
        }

        /// <summary>
        /// Inspects supplied type name to see if it might have a predictable aws/msdn
        /// doc url.
        /// </summary>
        /// <param name="typeName"></param>
        private string PredictHtmlDocsLink(string typeName)
        {
            if (!typeName.Equals("None", StringComparison.Ordinal))
            {
                var t = typeName.TrimEnd(new char[] { '[', ']' });

                if (t.Equals("Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema", StringComparison.Ordinal))
                    return "Amazon_DynamoDB_TableSchema.html";

                if (t.StartsWith("Amazon.", StringComparison.Ordinal))
                {
                    // generate the old 'full' namepath and then shrink it down in the same way
                    // as the sdk to avoid filepath limitations. SDK 'long' pattern is 
                    // string.Format("T_{0}_{1}_{2}", type.Namespace, type.Name, version.ShortName)) + ".html";
                    var sdkTypePagePath = string.Format("T_{0}_NET3_5", t);
                    return string.Format("{0}items/{1}.html", SDKHelpRoot, ShrinkSdkLongFilepath(sdkTypePagePath));
                }

                // 'spot' some common types we see in external apis
                if (_msdnDocLinks.ContainsKey(t))
                    return _msdnDocLinks[t];
            }

            return null;
        }

        // copied from the sdk help generator - we should share this one day, or generate both
        // docs from one tool
        private static string ShrinkSdkLongFilepath(string name)
        {
            var fixedUpName = name.Replace('.', '_').Replace('<', '_').Replace('>', '_');
            fixedUpName = fixedUpName.Replace("Amazon", "");
            fixedUpName = fixedUpName.Replace("__", "");
            fixedUpName = fixedUpName.Replace("_Model_", "");
            fixedUpName = fixedUpName.Replace("_Begin", "");
            fixedUpName = fixedUpName.Replace("_End", "");
            fixedUpName = fixedUpName.Replace("Client_", "");
            fixedUpName = fixedUpName.Replace("ElasticLoadBalancing", "ELB");
            fixedUpName = fixedUpName.Replace("ElasticBeanstalk", "EB_");
            fixedUpName = fixedUpName.Replace("ElasticMapReduce", "EMR");
            fixedUpName = fixedUpName.Replace("ElasticTranscoder", "ETS");
            fixedUpName = fixedUpName.Replace("SimpleNotificationService", "SNS");

            if (fixedUpName.Length > MAX_FILE_SIZE)
            {
                throw new ApplicationException(string.Format("Filename: {0} is too long", fixedUpName));
            }

            return fixedUpName;
        }

        private static bool RequiresLinkTarget(string typeName)
        {
            // bit of a hack to make sure links to ps model types we might have
            // stay in the frame. sdk and msdn links go to a new tab.
            return !(typeName.StartsWith("Amazon.PowerShell.", StringComparison.Ordinal));
        }

        private static void CopyWebHelpStaticFiles(string webFilesRoot)
        {
            Console.WriteLine("Copying Web Help DocSet Static Resources");

            var sourceLocation = Directory.GetParent(typeof(PsHelpGenerator).Assembly.Location).FullName;
            IOUtils.DirectoryCopy(Path.Combine(sourceLocation, @"..\..\..\AWSPSGeneratorLib\HelpMaterials\WebHelp\StaticContent"), webFilesRoot, true);
        }

        private void CreateVersionInfoFile(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // write the json file containing the assembly version; this can then
            // be injected onto each page using load-time script
            var v = CmdletAssembly.GetName().Version.ToString();
            var assemblyVersionsContent = string.Format("{{ \"awspowershell.dll\" : \"{0}\" }}", v);

            File.WriteAllText(Path.Combine(path, "assemblyversions.json"), assemblyVersionsContent);
        }

        private static void CleanWebHelpOutputFolder(string outputFolder)
        {
            if (!Directory.Exists(outputFolder)) return;

            try
            {
                Console.WriteLine("Cleaning out web help output folder");
                Directory.Delete(outputFolder, true);
            }
            catch (IOException)
            {
                Console.WriteLine("WARNING: Failed to clean web help output folder '{0}'", outputFolder);
            }
        }

    }
}
