﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Management.Automation;
using System.IO;
using AWSPowerShellGenerator.Utils;
using AWSPowerShellGenerator.Writers;

namespace AWSPowerShellGenerator.Generators
{
    public class PsHelpGenerator : HelpGeneratorBase
    {
        #region Public properties

        public static string PsHelpFilenameTail = ".dll-Help.xml";

        #endregion

        #region Public methods

        protected override void GenerateHelper()
        {
            Console.WriteLine("Generating Native PowerShell help (Get-Help) documentation file");
            base.GenerateHelper();

            var buildLogsPath = Path.Combine(this.Options.RootPath, "logs");
            if (!Directory.Exists(buildLogsPath))
                Directory.CreateDirectory(buildLogsPath);

            var logFilename = Path.Combine(buildLogsPath, Name + ".dll-Help.log");
            var oldWriter = Console.Out;
            try
            {
                using (var consoleWriter = new StreamWriter(File.OpenWrite(logFilename)))
                {
                    Console.SetOut(consoleWriter);
                    var outputFile = Path.Combine(this.OutputFolder, Name + PsHelpFilenameTail);

                    var settings = new XmlWriterSettings
                    {
                        Indent = true
                    };

                    using (var psHelpWriter = new XmlTextWriter(outputFile, Encoding.UTF8))
                    {
                        psHelpWriter.Formatting = Formatting.Indented;

                        psHelpWriter.WriteStartElement("helpItems");
                        psHelpWriter.WriteAttributeString("schema", "maml");

                        foreach (var cmdletType in CmdletTypes)
                        {
                            InspectCmdletAttributes(cmdletType);

                            string synopsis = null;
                            if (AWSCmdletAttribute == null)
                            {
                                Console.WriteLine("Unable to find AWSCmdletAttribute for type " + cmdletType.FullName);
                            }
                            else
                            {
                                var cmdletReturnAttributeType = AWSCmdletAttribute.GetType();
                                synopsis = cmdletReturnAttributeType.GetProperty("Synopsis").GetValue(AWSCmdletAttribute, null) as string;
                            }

                            foreach (var cmdletAttribute in CmdletAttributes)
                            {
                                psHelpWriter.WriteStartElement("command");
                                psHelpWriter.WriteAttributeString("xmlns", "maml", null, "http://schemas.microsoft.com/maml/2004/10");
                                psHelpWriter.WriteAttributeString("xmlns", "command", null, "http://schemas.microsoft.com/maml/dev/command/2004/10");
                                psHelpWriter.WriteAttributeString("xmlns", "dev", null, "http://schemas.microsoft.com/maml/dev/2004/10");
                                {
                                    var hasDynamicParams = DynamicParamsType.IsAssignableFrom(cmdletType);

                                    var typeDocumentation = DocumentationUtils.GetTypeDocumentation(cmdletType, AssemblyDocumentation);
                                    typeDocumentation = DocumentationUtils.FormatXMLForPowershell(typeDocumentation);
                                    Console.WriteLine("Cmdlet = {0}", cmdletType.FullName);
                                    if (hasDynamicParams)
                                        Console.WriteLine("This cmdlet has dynamic parameters!");
                                    Console.WriteLine("Documentation = {0}", typeDocumentation);

                                    var cmdletName = cmdletAttribute.VerbName + "-" + cmdletAttribute.NounName;

                                    var allProperties = GetRootSimpleProperties(cmdletType);
                                    var parameterPartitioning = new CmdletParameterSetPartitions(allProperties, cmdletAttribute.DefaultParameterSetName);

                                    var serviceAbbreviation = GetServiceAbbreviation(cmdletType);

                                    WriteDetails(psHelpWriter, cmdletAttribute, typeDocumentation, cmdletName, synopsis);
                                    WriteSyntax(psHelpWriter, cmdletName, parameterPartitioning);
                                    WriteParameters(psHelpWriter, cmdletName, allProperties);
                                    WriteReturnValues(psHelpWriter, AWSCmdletOutputAttributes);
                                    WriteRelatedLinks(psHelpWriter, serviceAbbreviation, cmdletName);
                                    WriteExamples(psHelpWriter, cmdletName);
                                }
                                psHelpWriter.WriteEndElement();
                            }
                        }

                        psHelpWriter.WriteEndElement();
                    }

                    Console.WriteLine("Verifying help file {0} using XmlDocument...", outputFile);
                    try
                    {
                        var document = new XmlDocument();
                        document.Load(outputFile);
                    }
                    catch (Exception e)
                    {
                        Logger.LogError(e, "Error when loading file {0} as XmlDocument", outputFile);
                    }
                }
            }
            finally
            {
                Console.SetOut(oldWriter);
            }
        }

        private static void WriteReturnValues(XmlTextWriter writer, IEnumerable<object> outputAttributes)
        {
            writer.WriteStartElement("returnValues");
            foreach (var outputAttribute in outputAttributes)
            {
                var attributeType = outputAttribute.GetType();
                writer.WriteStartElement("returnValue");
                {
                    writer.WriteStartElement("type");
                    {
                        var returnType = attributeType.GetProperty("ReturnType").GetValue(outputAttribute, null) as string;
                        writer.WriteElementString("name", returnType);
                        writer.WriteElementString("uri", string.Empty);
                        writer.WriteElementString("description", string.Empty);
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("description");
                    writer.WriteStartElement("para");
                    {
                        var description = attributeType.GetProperty("Description").GetValue(outputAttribute, null) as string;
                        writer.WriteString(description);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private static void WriteDetails(XmlTextWriter psHelpWriter, CmdletAttribute cmdletAttribute, string typeDocumentation, string cmdletName, string synopsis)
        {
            psHelpWriter.WriteStartElement("details");
            {
                psHelpWriter.WriteElementString("name", cmdletName);
                psHelpWriter.WriteStartElement("description");
                {
                    if (string.IsNullOrEmpty(synopsis))
                    {
                        synopsis = string.Format("{0}-{1}", cmdletAttribute.VerbName, cmdletAttribute.NounName);
                    }
                    psHelpWriter.WriteUnescapedElementString("para", synopsis);
                }
                psHelpWriter.WriteEndElement();

                psHelpWriter.WriteElementString("verb", cmdletAttribute.VerbName);
                psHelpWriter.WriteElementString("noun", cmdletAttribute.NounName);
                psHelpWriter.WriteStartElement("copyright");
                {
                    psHelpWriter.WriteElementString("para",
                                                    string.Format("&copy; Copyright 2012 - {0} Amazon.com, Inc.or its affiliates.All Rights Reserved.",
                                                                  DateTime.UtcNow.Year));
                }
                psHelpWriter.WriteEndElement();
            }
            psHelpWriter.WriteEndElement();

            psHelpWriter.WriteStartElement("description");
            {
                psHelpWriter.WriteUnescapedElementString("para", typeDocumentation);
            }
            psHelpWriter.WriteEndElement();
        }

        private static void WriteSyntax(XmlTextWriter writer, string cmdletName, CmdletParameterSetPartitions parameterSetPartitioning)
        {
            writer.WriteStartElement("syntax");
            if (parameterSetPartitioning.HasNamedParameterSets)
            {
                var sets = parameterSetPartitioning.NamedParameterSets;
                foreach (var set in sets)
                {
                    WriteSyntaxItem(writer, cmdletName, set, parameterSetPartitioning);
                }
            }
            else
            {
                WriteSyntaxItem(writer, cmdletName, CmdletParameterSetPartitions.AllSetsKey, parameterSetPartitioning);
            }
            writer.WriteEndElement();
        }

        private static void WriteSyntaxItem(XmlTextWriter writer, string cmdletName, string setName, CmdletParameterSetPartitions parameterSetPartitioning)
        {
            var isCustomNamedSet = !setName.Equals(CmdletParameterSetPartitions.AllSetsKey);
            var isDefaultSet = isCustomNamedSet && setName.Equals(parameterSetPartitioning.DefaultParameterSetName, StringComparison.Ordinal);
            var setParameterNames = parameterSetPartitioning.ParameterNamesForSet(setName, parameterSetPartitioning.HasNamedParameterSets);

            writer.WriteStartElement("syntaxItem");
            {
                writer.WriteElementString("name", cmdletName);

                var allParameters = parameterSetPartitioning.Parameters;
                // Microsoft cmdlets show params in syntax in defined but non-alpha order. Use the ordering we found
                // during reflection here in the hope the sdk has them in 'most important' order
                foreach (var parameter in allParameters)
                {
                    if (!setParameterNames.Contains(parameter.CmdletParameterName))
                        continue;

                    InspectParameter(parameter, out var isRequiredForParametersets, out var pipelineInput, out var position, out var aliases);
                    var isRequiredForCurrentParameterset = isRequiredForParametersets != null && (isRequiredForParametersets.Count == 0 || isRequiredForParametersets.Contains(setName));

                    writer.WriteStartElement("parameter");
                    {
                        writer.WriteAttributeString("required", isRequiredForCurrentParameterset.ToString());
                        writer.WriteAttributeString("variableLength", "false");
                        writer.WriteAttributeString("globbing", "false");
                        writer.WriteAttributeString("pipelineInput", pipelineInput);
                        writer.WriteAttributeString("position", position);

                        writer.WriteElementString("name", parameter.CmdletParameterName);
                        writer.WriteStartElement("description");
                        {
                            writer.WriteUnescapedElementString("para", parameter.PowershellDocumentation);
                        }
                        writer.WriteEndElement();

                        writer.WriteStartElement("parameterValue");
                        {
                            writer.WriteAttributeString("required", "true");
                            writer.WriteAttributeString("variableLength", "false");
                            writer.WriteString(parameter.PropertyTypeName);
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        private static void WriteParameters(XmlTextWriter writer, string cmdletName, IEnumerable<SimplePropertyInfo> allProperties)
        {
            writer.WriteStartElement("parameters");
            {
                // Microsoft cmdlets list the parameters in alpha order here, so do the same (leaving metadata/paging
                // params in the correct order)
                foreach (var property in allProperties.OrderBy(p => p.Name))
                {
                    writer.WriteStartElement("parameter");
                    {
                        InspectParameter(property, out var isRequiredForParametersets, out var pipelineInput, out var position, out var aliases);
                        var isRequiredForCurrentParameterset = isRequiredForParametersets?.Count == 0;

                        writer.WriteAttributeString("required", isRequiredForCurrentParameterset.ToString());
                        writer.WriteAttributeString("variableLength", "false");
                        writer.WriteAttributeString("globbing", "false");
                        writer.WriteAttributeString("pipelineInput", pipelineInput);
                        writer.WriteAttributeString("position", position);

                        writer.WriteElementString("name", property.Name);
                        writer.WriteStartElement("description");
                        {
                            writer.WriteUnescapedElementString("para", property.PowershellDocumentation);
                        }
                        writer.WriteEndElement();

                        writer.WriteStartElement("parameterValue");
                        {
                            writer.WriteAttributeString("required", "true");
                            writer.WriteAttributeString("variableLength", "false");
                            writer.WriteString(property.PropertyTypeName);
                        }
                        writer.WriteEndElement();

                        writer.WriteStartElement("type");
                        {
                            writer.WriteElementString("name", property.PropertyTypeName);
                            writer.WriteElementString("uri", string.Empty);
                        }
                        writer.WriteEndElement();

                        writer.WriteElementString("defaultValue", "None");
                    }
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        private void WriteRelatedLinks(XmlTextWriter writer, string serviceAbbreviation, string cmdletName)
        {
            var webrefLink 
                = string.Format("{0}/index.html?page={1}.html&tocid={1}",
                                WebApiReferenceBaseUrl,
                                cmdletName);

            writer.WriteStartElement("relatedLinks");

            // first link must always be to the online version so get-help -online works
            WriteRelatedHelpNavigationLink(writer, "Online version:", webrefLink);

            WriteRelatedHelpNavigationLink(writer,
                                            "Common credential and region parameters: ",
                                            string.Format("{0}/items/pstoolsref-commonparams.html", WebApiReferenceBaseUrl));

            // finish with any service api reference/user guide links
            XmlDocument document;
            if (LinksCache.TryGetValue(serviceAbbreviation, out document))
            {
                ConstructLinks(writer, document, "*");
                ConstructLinks(writer, document, cmdletName);
            }

            writer.WriteEndElement();
        }

        public void ConstructLinks(XmlTextWriter writer, XmlDocument document, string target)
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

                    WriteRelatedHelpNavigationLink(writer, displayname + ":", link.InnerText);
                }
            }
        }

        /// <summary>
        /// Emits a single navigation link to the help. 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="linkText">The 'display' text for the link</param>
        /// <param name="linkUri">The uri, if relevant</param>
        private static void WriteRelatedHelpNavigationLink(XmlTextWriter writer, string linkText, string linkUri)
        {
            writer.WriteStartElement("navigationLink");
            {
                writer.WriteElementString("linkText", linkText);
                writer.WriteElementString("uri", string.IsNullOrEmpty(linkUri) ? string.Empty : linkUri);
            }
            writer.WriteEndElement();
        }

        private const string exampleTitleFormat = "-------------------------- EXAMPLE {0} --------------------------";
        private const string remarksFormat = "<para>Description</para><para>-----------</para>{0}<para /><para />";
        private const string psCmdlinePrefix = "PS C:\\&gt;";
        
        private void WriteExamples(XmlTextWriter writer, string cmdletName)
        {
            XmlDocument document;
            if (!ExamplesCache.TryGetValue(cmdletName, out document))
            {
                Console.WriteLine("NO EXAMPLES - {0}", cmdletName);
                return;
            }

            var set = document.SelectSingleNode("examples");
            if (set == null || !set.HasChildNodes)
            {
                Console.WriteLine("NO EXAMPLES - {0} (file present but empty)", cmdletName);
                return;
            }

            writer.WriteStartElement("examples");
            {
                int exampleIndex = 1;
                var examples = set.SelectNodes("example");
                foreach (XmlNode example in examples)
                {
                    writer.WriteStartElement("example");
                    {
                        writer.WriteElementString("title", string.Format(exampleTitleFormat, exampleIndex));

                        writer.Formatting = Formatting.None;
                        {
                            // code tag CANNOT HAVE PARA TAGS
                            var code = example.SelectSingleNode("code");
                            if (code == null)
                            {
                                Logger.LogError("Unable to find examples <code> tag for cmdlet " + cmdletName);
                            }
                            // if the sample is a one-liner, auto-inject 'PS C:\>' at the start if not already
                            // present so we match what some other modules do
                            var codeSample = code.InnerXml;
                            if (codeSample.IndexOfAny(new [] {'\n', '\r'}) == -1)
                            {
                                if (!codeSample.StartsWith(psCmdlinePrefix))
                                    codeSample = string.Concat(psCmdlinePrefix, codeSample);
                            }

                            writer.WriteRawElementString("code", codeSample);

                            // remarks tag MUST HAVE PARA TAGS
                            var description = example.SelectSingleNode("description");
                            if (description == null)
                            {
                                Logger.LogError("Unable to find examples <description> tag for cmdlet " + cmdletName);
                            }
                            var correctedText = DocumentationUtils.ProcessLines(description.InnerXml, s => string.Format("<para>{0}</para>", s));
                            // we use br/ tags to format the description for webhelp, for native help we can replace
                            // with simple newlines
                            correctedText = correctedText.Replace("<br />", "\n"); // xml handler shows us <br/> as <br />
                            // <url>link</url> elements are stripped to leave the inner link text for the user to copy/paste
                            // (web help converts these to <a href="link" />)
                            correctedText = correctedText.Replace("<url>", "");
                            correctedText = correctedText.Replace("</url>", "");
                            var remarks = string.Format(remarksFormat, correctedText);
                            writer.WriteUnescapedElementString("remarks", remarks);
                        }
                        writer.Formatting = Formatting.Indented;
                    }
                    writer.WriteEndElement();
                    exampleIndex++;
                }
            }
            writer.WriteEndElement();
        }

        #endregion

    }
}
