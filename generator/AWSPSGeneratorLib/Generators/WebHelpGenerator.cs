using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Xml;

using AWSPowerShellGenerator.Utils;
using AWSPowerShellGenerator.Writers.Help;
using System.Reflection;

namespace AWSPowerShellGenerator.Generators
{
    public class WebHelpGenerator : HelpGeneratorBase
    {
        const int MAX_FILE_SIZE = 160; // matching sdk

        #region Public properties

        // the root path of the AWS .Net sdk docs; eg http://docs.aws.amazon.com/sdkfornet/v3/apidocs
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

        /// <summary>
        /// Html snippet that contains the documentation for the credential parameters
        /// that can be found on supporting cmdlets
        /// </summary>
        public string CredentialParametersSnippet { get; private set; }

        /// <summary>
        /// Html snipper that contains the documentation for the region parameter
        /// that can be found on supporting cmdlets
        /// </summary>
        public string RegionParametersSnippet { get; private set; }

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

        private const string CommonParametersSnippetMarker = "{COMMON_PARAM_SNIPPET}";

        /// <summary>
        /// Holds the base class type we derive cmdlets from, which indicates the cmdlet
        /// supports common credential and region parameters
        /// </summary>
        private Type ServiceCmdletBaseClass { get; set; }


        protected override void GenerateHelper()
        {
            base.GenerateHelper();

            if (string.IsNullOrEmpty(SDKHelpRoot))
                SDKHelpRoot = "http://docs.aws.amazon.com/sdkfornet/v3/apidocs/";
            else if (!SDKHelpRoot.EndsWith("/"))
                SDKHelpRoot = SDKHelpRoot + "/";

            Console.WriteLine("Generating web help documentation:");
            Console.WriteLine(".... SDK help base URI set to {0}", SDKHelpRoot);
            Console.WriteLine(".... writing doc output to {0}", OutputFolder);

            var buildLogsPath = Path.Combine(this.Options.RootPath, "logs");
            if (!Directory.Exists(buildLogsPath))
                Directory.CreateDirectory(buildLogsPath);

            LoadCommonParameterSnippets();
            ServiceCmdletBaseClass = CmdletAssembly.GetType("Amazon.PowerShell.Common.ServiceCmdlet");

            var logFile = Path.Combine(buildLogsPath, Name + ".dll-WebHelp.log");
            var oldWriter = Console.Out;
            
            try
            {
                using (var consoleWriter = new StreamWriter(File.OpenWrite(logFile)))
                {
                    Console.SetOut(consoleWriter);

                    CleanWebHelpOutputFolder(OutputFolder);
                    CopyWebHelpStaticFiles(OutputFolder);
                    CopyCommonParametersFile();
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

                            var parameterPartitioning = new CmdletParameterSetPartitions(allProperties, cmdletAttribute.DefaultParameterSetName);

                            var serviceAbbreviation = GetServiceAbbreviation(cmdletType);

                            var cmdletPageWriter = new CmdletPageWriter(Options, OutputFolder, owningService, cmdletName);

                            WriteDetails(cmdletPageWriter, cmdletAttribute, typeDocumentation, cmdletName, synopsis);
                            WriteSyntax(cmdletPageWriter, cmdletName, parameterPartitioning);
                            WriteParameters(cmdletPageWriter, cmdletName, allProperties);
                            WriteCommonParameters(cmdletPageWriter, cmdletType, cmdletName);
                            WriteInputs(cmdletPageWriter, allProperties);
                            WriteOutputs(cmdletPageWriter, AWSCmdletOutputAttributes);
                            WriteNotes(cmdletPageWriter);
                            WriteExamples(cmdletPageWriter, cmdletName);
                            WriteRelatedLinks(cmdletPageWriter, serviceAbbreviation, cmdletName);

                            cmdletPageWriter.Write();

                            var legacyAlias = ExtractLegacyAlias(AWSCmdletAttribute);
                            tocWriter.AddServiceCmdlet(owningService, cmdletName, cmdletPageWriter.GetTOCID(), synopsis, legacyAlias);
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

        private void WriteDetails(CmdletPageWriter writer, CmdletAttribute cmdletAttribute, string typeDocumentation, string cmdletName, string synopsis)
        {
            if (!string.IsNullOrEmpty(synopsis))
                writer.AddPageElement(CmdletPageWriter.SynopsisElementKey, synopsis);

            var doc = new StringBuilder();
            if (!string.IsNullOrEmpty(typeDocumentation))
                doc.Append(typeDocumentation);

            var legacyAlias = ExtractLegacyAlias(AWSCmdletAttribute);
            if (!string.IsNullOrEmpty(legacyAlias))
            {
                doc.AppendLine("<br/>");
                doc.AppendLine("<br/>");
                doc.AppendFormat("Note: For scripts written against earlier versions of this module this cmdlet can also be invoked with the alias, <i>{0}</i>.",
                                legacyAlias);
            }

            if (doc.Length > 0)
                writer.AddPageElement(CmdletPageWriter.DescriptionElementKey, doc.ToString());
        }

        private static void WriteSyntax(CmdletPageWriter writer, string cmdletName, CmdletParameterSetPartitions parameterSetPartitioning)
        {
            var sb = new StringBuilder();

            if (parameterSetPartitioning.HasNamedParameterSets)
            {
                var sets = parameterSetPartitioning.NamedParameterSets;
                foreach (var set in sets)
                {
                    AppendSyntaxChart(cmdletName,
                                      set, 
                                      parameterSetPartitioning, 
                                      sb);
                }
            }
            else
            {
                AppendSyntaxChart(cmdletName, CmdletParameterSetPartitions.AllSetsKey, parameterSetPartitioning, sb);
            }

            writer.AddPageElement(CmdletPageWriter.SyntaxElementKey, sb.ToString());
        }

        private static void AppendSyntaxChart(string cmdletName, string setName, CmdletParameterSetPartitions parameterSetPartitioning, StringBuilder sb)
        {
            var isCustomNamedSet = !setName.Equals(CmdletParameterSetPartitions.AllSetsKey);
            var isDefaultSet = isCustomNamedSet && setName.Equals(parameterSetPartitioning.DefaultParameterSetName, StringComparison.Ordinal);

            var setParameterNames = parameterSetPartitioning.ParameterNamesForSet(setName, parameterSetPartitioning.HasNamedParameterSets);

            if (isCustomNamedSet)
            {
                sb.AppendFormat(
                    isDefaultSet
                        ? "<div class=\"paramsetname\"><h4>{0} (Default)</h4>"
                        : "<div class=\"paramsetname\"><h4>{0}</h4>", setName);
            }

            sb.Append("<div class=\"syntaxblock\">");

            // Microsoft cmdlets show params in syntax in defined but non-alpha order. Use the ordering we found
            // during reflection here in the hope the sdk has them in 'most important' order. Also, if there is
            // four or less params, keep the syntax on one line.
            sb.AppendFormat("<div class=\"cmdlet\">{0}</div>", cmdletName);
            var allParameters = parameterSetPartitioning.Parameters;
            var paramCount = setParameterNames.Count;

            if (paramCount > 0)
            {
                sb.Append("<div class=\"paramlist\">");
                foreach (var p in allParameters)
                {
                    if (!setParameterNames.Contains(p.CmdletParameterName))
                        continue;

                    sb.AppendFormat("<div class=\"{0}\">-{1} &lt;{2}&gt;</div>",
                                    paramCount < 5 ? "inlineParam" : "wrappedParam",
                                    p.CmdletParameterName,
                                    GetTypeDisplayName(p.PropertyType, false));
                }
                sb.Append("</div>");
            }

            sb.Append("</div>");

            if (isCustomNamedSet)
            {
                sb.Append("</div>");
            }
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
                sb.Append("This cmdlet has no parameters specific to its operation.");

            writer.AddPageElement(CmdletPageWriter.ParametersElementKey, sb.ToString());
        }

        /// <summary>
        /// If the cmdlet is a service cmdlet, or is one of our common cmdlets that supports credential
        /// and/or region parameters, add in the relevant common parameters section
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="addCredentials"></param>
        /// <param name="addRegion"></param>
        private void WriteCommonParameters(CmdletPageWriter writer, Type cmdletType, string cmdletName)
        {
            if (cmdletType.IsSubclassOf(ServiceCmdletBaseClass))
            {
                var sb = new StringBuilder();

                sb.AppendLine("<div class=\"sectionbody\">");
                sb.AppendLine("<div class=\"parameters\">");

                sb.Append("<div class=\"commonparameters\">");
                // right now all service cmdlets have credential and region parameters
                sb.Append(CredentialParametersSnippet);
                sb.Append(RegionParametersSnippet);
                sb.Append("</div>");

                sb.AppendLine("</div>");
                sb.AppendLine("</div>");

                writer.AddPageElement(CmdletPageWriter.CommonParametersElementKey, sb.ToString());
            }
        }

        private void WriteInputs(CmdletPageWriter writer, IEnumerable<SimplePropertyInfo> allProperties)
        {
            var sb = new StringBuilder();

            foreach (var simplePropertyInfo in allProperties)
            {
                if (simplePropertyInfo.PsParameterAttribute != null && IsMarkedValueFromPipeline(simplePropertyInfo.PsParameterAttribute))
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
            var sb = new StringBuilder();

            // putting common credential and region parameters into a related link is the simplest
            // approach, but only do it for service cmdlets
            if (!serviceAbbreviation.Equals("Common", StringComparison.Ordinal))
            {
                XmlDocument document;
                if (LinksCache.TryGetValue(serviceAbbreviation, out document))
                {
                    ConstructLinks(sb, document, "*");
                    ConstructLinks(sb, document, cmdletName);
                }
            }

            // Add link for User Guide to all cmdlets
            AppendLink(sb, "AWS Tools for PowerShell User Guide", "http://docs.aws.amazon.com/powershell/latest/userguide/");

            writer.AddPageElement(CmdletPageWriter.RelatedLinksElementKey, sb.ToString());
        }

        public void ConstructLinks(StringBuilder sb, XmlDocument document, string target)
        {
            var links = GetRelatedLinks(document, target);
            if (links != null)
            {
                foreach (XmlNode link in links)
                {

                    string displayname = null;
                    try { displayname = link.Attributes["name"].InnerText; } catch { }

                    if (string.IsNullOrEmpty(displayname) || string.IsNullOrEmpty(link.InnerText))
                    {
                        Logger.LogError("Malformed link {0}, skipping" + link.OuterXml.ToString());
                    }
                    AppendLink(sb, displayname, link.InnerText);
                }
            }
        }

        private void AppendLink(StringBuilder sb, string linkText, string linkAddress)
        {
            sb.Append("<div class=\"relatedLink\">");
            sb.AppendFormat("<a href=\"{1}\" target=_blank>{0}</a>", linkText, linkAddress);
            sb.Append("</div>");
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
                    // as the sdk to avoid filepath limitations. Example SDK path:
                    // http://docs.aws.amazon.com/sdkfornet/v3/apidocs/index.html?page=EC2/TEC2ScheduledInstance.html&tocid=Amazon_EC2_Model_ScheduledInstance
                    // Note how the pages are arranged beneath an extra folder
                    var nameComponents = t.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    var serviceName = nameComponents[1];
                    if (ServiceNamespaceContractions.ContainsKey(serviceName))
                        serviceName = ServiceNamespaceContractions[serviceName];

                    var tName = nameComponents[nameComponents.Length - 1];
                     
                    var sdkTypePagePath = string.Format("T{0}{1}", serviceName, tName);
                    return string.Format("{0}index.html?page={1}/{2}.html&tocid={3}", 
                                         SDKHelpRoot, 
                                         serviceName,
                                         ShrinkSdkLongFilepath(sdkTypePagePath),
                                         t.Replace('.', '_'));
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
            var fixedUpName = name.Replace('.', '_');
            // don't use encoded <> in filename, as browsers re-encode it in links to %3C
            // and the link fails
            fixedUpName = fixedUpName.Replace("&lt;", "!").Replace("&gt;", "!");
            fixedUpName = fixedUpName.Replace("Amazon", "");
            fixedUpName = fixedUpName.Replace("_Model_", "");
            fixedUpName = fixedUpName.Replace("_Begin", "");
            fixedUpName = fixedUpName.Replace("_End", "");
            fixedUpName = fixedUpName.Replace("Client_", "");
            fixedUpName = fixedUpName.Replace("+", "");
            fixedUpName = fixedUpName.Replace("_", "");

            foreach (var k in ServiceNamespaceContractions.Keys)
            {
                fixedUpName = fixedUpName.Replace(k, ServiceNamespaceContractions[k]);
            }

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

        private void CopyCommonParametersFile()
        {
            var templateFilename = "pstoolsref-commonparams.html";

            // copy the common parameters template, replacing the inner marker with the snippet content
            // we loaded earlier
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AWSPowerShellGenerator.HelpMaterials.WebHelp.Templates." + templateFilename))
            using (var reader = new StreamReader(stream))
            {
                var templateBody = reader.ReadToEnd();

                var commonParams = string.Concat(CredentialParametersSnippet, RegionParametersSnippet);
                var finalBody = templateBody.Replace(CommonParametersSnippetMarker, commonParams);

                var filename = Path.Combine(OutputFolder, "items", templateFilename);
                using (var writer = new StreamWriter(filename))
                {
                    writer.Write(finalBody);
                }
            }
        }

        private void LoadCommonParameterSnippets()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AWSPowerShellGenerator.HelpMaterials.WebHelp.Templates.CredentialParametersSnippet.html"))
            using (var reader = new StreamReader(stream))
            {
                var templateBody = reader.ReadToEnd();
                CredentialParametersSnippet = templateBody;
            }

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AWSPowerShellGenerator.HelpMaterials.WebHelp.Templates.RegionParametersSnippet.html"))
            using (var reader = new StreamReader(stream))
            {
                var templateBody = reader.ReadToEnd();
                RegionParametersSnippet = templateBody;
            }

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

        private static string ExtractLegacyAlias(object awsCmdletAttribute)
        {
            if (awsCmdletAttribute == null)
                return null;

            var awsCmdletAttributeType = awsCmdletAttribute.GetType();
            return awsCmdletAttributeType.GetProperty("LegacyAlias").GetValue(awsCmdletAttribute, null) as string;
        }

    }
}
