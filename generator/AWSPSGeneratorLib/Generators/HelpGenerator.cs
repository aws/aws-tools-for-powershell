using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Management.Automation;
using System.IO;
using PowerShellGenLib.Utils;

namespace PowerShellGenLib.Generators
{
    public class HelpGenerator : Generator
    {
        #region Public properties

        public Assembly CmdletAssembly { get; set; }
        public XmlDocument AssemblyDocumentation { get; set; }
        public string Name { get; set; }
        public static string Copyright = "Copyright 2008-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.";

        #endregion

        #region Public methods

        protected override void GenerateHelper()
        {
            Type psCmdletType = typeof(PSCmdlet);
            Type dynamicParamsType = typeof(IDynamicParameters);
            var cmdletTypes = CmdletAssembly.GetTypes()
                .Where(t => psCmdletType.IsAssignableFrom(t) && t.IsPublic && !t.IsAbstract)
                .ToList();

            LoadExamplesCache();

            string logFile = Path.Combine(this.OutputDir, Name + ".dll-Help.log");
            var oldWriter = Console.Out;
            try
            {
                using (StreamWriter consoleWriter = new StreamWriter(File.OpenWrite(logFile)))
                {
                    Console.SetOut(consoleWriter);
                    string outputFile = Path.Combine(this.OutputDir, Name + ".dll-Help.xml");
                    XmlWriterSettings settings = new XmlWriterSettings
                    {
                        Indent = true
                    };
                    using (XmlTextWriter writer = new XmlTextWriter(outputFile, Encoding.UTF8))
                    {
                        writer.Formatting = Formatting.Indented;

                        writer.WriteStartElement("helpItems");
                        writer.WriteAttributeString("schema", "maml");

                        foreach (var cmdletType in cmdletTypes)
                        {
                            var customAttributes = cmdletType.GetCustomAttributes(true);
                            var cmdletAttributes = customAttributes.Select(att => att as CmdletAttribute).Where(catt => catt != null).ToList();
                            var awsCmdletAttribute = customAttributes.FirstOrDefault(att => string.Equals(att.GetType().FullName, "Amazon.PowerShell.Common.AWSCmdletAttribute", StringComparison.Ordinal));
                            var outputAttributes = customAttributes
                                .Where(att => string.Equals(att.GetType().FullName, "Amazon.PowerShell.Common.AWSCmdletOutputAttribute", StringComparison.Ordinal))
                                .ToList();

                            string synopsis = null;
                            if (awsCmdletAttribute == null)
                            {
                                Console.WriteLine("Unable to find AWSCmdletAttribute for type " + cmdletType.FullName);
                                //throw new InvalidDataException("Unable to find AWSCmdletAttribute for type " + cmdletType.FullName);
                            }
                            else
                            {
                                var cmdletReturnAttributeType = awsCmdletAttribute.GetType();
                                //responseType = cmdletReturnAttributeType.GetProperty("ResponseType").GetValue(awsCmdletAttribute, null) as Type;
                                //resultType = cmdletReturnAttributeType.GetProperty("ResultType").GetValue(awsCmdletAttribute, null) as Type;
                                synopsis = cmdletReturnAttributeType.GetProperty("Synopsis").GetValue(awsCmdletAttribute, null) as string;
                            }

                            //Console.WriteLine("Response = {0}, Result = {1}", responseType == null ? "null" : responseType.FullName, resultType == null ? "null" : resultType.FullName);

                            foreach (var cmdletAttribute in cmdletAttributes)
                            {
                                //var cmdletAttribute = customAttribute as CmdletAttribute;
                                //if (cmdletAttribute == null)
                                //    throw new InvalidOperationException("Attribute not CmdletAttribute type: " + customAttribute.GetType().FullName);

                                writer.WriteStartElement("command");
                                writer.WriteAttributeString("xmlns", "maml", null, "http://schemas.microsoft.com/maml/2004/10");
                                writer.WriteAttributeString("xmlns", "command", null, "http://schemas.microsoft.com/maml/dev/command/2004/10");
                                writer.WriteAttributeString("xmlns", "dev", null, "http://schemas.microsoft.com/maml/dev/2004/10");
                                {
                                    bool hasDynamicParams = dynamicParamsType.IsAssignableFrom(cmdletType);

                                    string typeDocumentation = DocumentationUtils.GetTypeDocumentation(cmdletType, AssemblyDocumentation);
                                    typeDocumentation = DocumentationUtils.FormatXMLForPowershell(typeDocumentation);
                                    Console.WriteLine("Cmdlet = {0}", cmdletType.FullName);
                                    if (hasDynamicParams)
                                        Console.WriteLine("This cmdlet has dynamic parameters!");
                                    Console.WriteLine("Documentation = {0}", typeDocumentation);
                                    string cmdletName = cmdletAttribute.VerbName + "-" + cmdletAttribute.NounName;
                                    var allProperties = GetRootSimpleProperties(cmdletType);
                                    var serviceAbbreviation = GetServiceAbbreviation(cmdletType);

                                    WriteDetails(writer, cmdletAttribute, typeDocumentation, cmdletName, synopsis);
                                    WriteSyntax(writer, cmdletName, allProperties);
                                    WriteParameters(writer, cmdletName, allProperties);
                                    WriteReturnValues(writer, outputAttributes);
                                    WriteRelatedLinks(writer);
                                    WriteExamples(writer, serviceAbbreviation, cmdletName);
                                }
                                writer.WriteEndElement();
                            }
                        }

                        writer.WriteEndElement();
                    }

                    Console.WriteLine("Opening help file in XmlDocument...");
                    XmlDocument document = new XmlDocument();
                    document.Load(outputFile);
                }
            }
            finally
            {
                Console.SetOut(oldWriter);
            }
        }

        private const string namespacePrefix = "Amazon.PowerShell.Cmdlets.";
        private const string commonCmdletsNamespace = "Amazon.PowerShell.Common";
        private string GetServiceAbbreviation(Type cmdletType)
        {
            string ns = cmdletType.Namespace;
            if (string.Equals(ns, commonCmdletsNamespace, StringComparison.OrdinalIgnoreCase))
                return "Common";
            if (ns.IndexOf(namespacePrefix) != 0)
            {
                LogError("Cmdlet namespace \"{0}\" does not contain expected namespace prefix \"{1}\"", ns, namespacePrefix);
                return null;
            }
            ns = ns.Substring(namespacePrefix.Length);
            var components = ns.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            return components[0];
        }

        private const string examplesResourcePrefix = "PowerShellGenLib.HelpExamples.";
        private Dictionary<string, XmlDocument> examplesCache;
        private void LoadExamplesCache()
        {
            examplesCache = new Dictionary<string, XmlDocument>();
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames().Where(name => name.StartsWith(examplesResourcePrefix));
            foreach (var resource in resources)
            {
                var service = resource.Substring(examplesResourcePrefix.Length).Replace(".xml", string.Empty);
                var stream = assembly.GetManifestResourceStream(resource);
                XmlDocument document = new XmlDocument();
                document.Load(stream);
                examplesCache[service] = document;
            }
        }

        private static void WriteReturnValues(XmlTextWriter writer, List<object> outputAttributes)
        {
            writer.WriteStartElement("returnValues");
            foreach (var outputAttribute in outputAttributes)
            {
                var attributeType = outputAttribute.GetType();
                writer.WriteStartElement("returnValue");
                {
                    writer.WriteStartElement("type");
                    {
                        string returnType = attributeType.GetProperty("ReturnType").GetValue(outputAttribute, null) as string;
                        writer.WriteUnescapedElementString("name", returnType);
                        writer.WriteElementString("uri", string.Empty);
                        writer.WriteElementString("description", string.Empty);
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("description");
                    writer.WriteStartElement("para");
                    {
                        string description = attributeType.GetProperty("Description").GetValue(outputAttribute, null) as string;
                        writer.WriteRaw(description);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private static void WriteDetails(XmlTextWriter writer, CmdletAttribute cmdletAttribute, string typeDocumentation, string cmdletName, string synopsis)
        {
            writer.WriteStartElement("details");
            {
                writer.WriteElementString("name", cmdletName);
                writer.WriteStartElement("description");
                {
                    if (string.IsNullOrEmpty(synopsis))
                    {
                        synopsis = string.Format("{0}-{1}", cmdletAttribute.VerbName, cmdletAttribute.NounName);
                    }
                    writer.WriteUnescapedElementString("para", synopsis);
                }
                writer.WriteEndElement();

                writer.WriteElementString("verb", cmdletAttribute.VerbName);
                writer.WriteElementString("noun", cmdletAttribute.NounName);
                writer.WriteStartElement("copyright");
                {
                    writer.WriteElementString("para", Copyright);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("description");
            {
                writer.WriteUnescapedElementString("para", typeDocumentation);
            }
            writer.WriteEndElement();
        }

        private static void WriteSyntax(XmlTextWriter writer, string cmdletName, IEnumerable<SimplePropertyInfo> allProperties)
        {
            writer.WriteStartElement("syntax");
            writer.WriteStartElement("syntaxItem");
            {
                writer.WriteElementString("name", cmdletName);

                foreach (var property in allProperties)
                {
                    writer.WriteStartElement("parameter");
                    {
                        writer.WriteAttributeString("required", "false");
                        writer.WriteAttributeString("variableLength", "false");
                        writer.WriteAttributeString("globbing", "false");
                        writer.WriteAttributeString("pipelineInput", "false");
                        writer.WriteAttributeString("position", "named");

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
                    }
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private static void WriteParameters(XmlTextWriter writer, string cmdletName, IEnumerable<SimplePropertyInfo> allProperties)
        {
            writer.WriteStartElement("parameters");
            {
                foreach (var property in allProperties)
                {
                    writer.WriteStartElement("parameter");
                    {
                        bool isRequired = false;
                        string pipelineInput = "false";
                        string position = "named";
                        try
                        {
                            var paramAttribute 
                                = (property.BaseProperty.GetCustomAttributes(typeof(ParameterAttribute), false)[0]) as ParameterAttribute;

                            // 'Required? true | false'
                            isRequired = paramAttribute.Mandatory;

                            // 'Accept pipeline input?       true ([ByValue,] [ByPropertyName]) | false'
                            if (paramAttribute.ValueFromPipeline | paramAttribute.ValueFromPipelineByPropertyName)
                            {
                                pipelineInput = string.Format("true ({0}{1}{2})",
                                                              paramAttribute.ValueFromPipeline ? "ByValue" : "",
                                                              paramAttribute.ValueFromPipeline ? ", " : "",
                                                              paramAttribute.ValueFromPipelineByPropertyName ? "ByPropertyName" : "");
                            }

                            // 'Position named | ordinal' -- need to decide is standard is 0-based or 1-based
                            // position = paramAttribute.Position.ToString();
                        }
                        catch (Exception) {}

                        writer.WriteAttributeString("required", isRequired.ToString());
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

        private static void WriteRelatedLinks(XmlTextWriter writer)
        {
            writer.WriteStartElement("relatedLinks");
            writer.WriteStartElement("navigationLink");
            {
                writer.WriteElementString("linkText", "Online version:");
                writer.WriteElementString("uri", @"http://aws.amazon.com/documentation/");
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private const string exampleTitleFormat = "-------------------------- EXAMPLE {0} --------------------------";
        private const string remarksFormat = "<para>Description</para><para>-----------</para>{0}<para /><para />";
        private void WriteExamples(XmlTextWriter writer, string serviceAbbreviation, string cmdletName)
        {
            XmlDocument document;
            if (!examplesCache.TryGetValue(serviceAbbreviation, out document))
            {
                return;
            }

            string xpath = string.Format("examples/set[@target='{0}']", cmdletName);
            var set = document.SelectSingleNode(xpath);
            if (set == null)
            {
                Console.WriteLine("Unable to find examples for cmdlet {0}, expected at xpath {1}", cmdletName, xpath);
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
                                LogError("Unable to find examples <code> tag for cmdlet " + cmdletName);
                            }
                            writer.WriteUnescapedElementString("code", code.InnerXml);

                            // remarks tag MUST HAVE PARA TAGS
                            var description = example.SelectSingleNode("description");
                            if (description == null)
                            {
                                LogError("Unable to find examples <description> tag for cmdlet " + cmdletName);
                            }
                            var correctedText = DocumentationUtils.ProcessLines(description.InnerXml, s => string.Format("<para>{0}</para>", s));
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

        private IEnumerable<SimplePropertyInfo> GetRootSimpleProperties(Type requestType)
        {
            var properties = requestType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            var simpleProperties = properties
                .Select(p => CreateSimpleProperty(p, null))
                .Where(sp => sp.IsReadWrite)
                .ToList();
            //.OrderBy(sp => sp.Children.Count);
            return simpleProperties;
        }
        private SimplePropertyInfo CreateSimpleProperty(PropertyInfo property, SimplePropertyInfo parent)
        {
            // determine if property should be flattened based solely on its type
            string propertyFullName;
            if (property.PropertyType.IsGenericType)
                propertyFullName = property.PropertyType.GetGenericTypeDefinition().FullName;
            else
                propertyFullName = property.PropertyType.FullName;

            string propertyTypeName = GetValidTypeNameNullable(property.PropertyType);
            SimplePropertyInfo simpleProperty = new SimplePropertyInfo(property, parent, propertyTypeName, AssemblyDocumentation);
            return simpleProperty;
        }
        private string GetValidTypeNameNullable(Type type)
        {
            string name = GetValidTypeName(type);
            if (ShouldMakeNullable(type))
                name = name + "?";
            return name;
        }
        private static string ToLowerCamelCase(string name)
        {
            var sb = new StringBuilder(name);
            sb[0] = char.ToLowerInvariant(sb[0]);
            return sb.ToString();
        }
        private bool ShouldMakeNullable(Type type)
        {
            if (type.IsValueType)
            {
                if (type.IsGenericType)
                {
                    if (type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Nullable<>)))
                        return false;
                }
                return true;
            }
            return false;
        }
        private string GetValidTypeName(Type type)
        {
            if (type.IsArray)
                return GetValidTypeName(type.GetElementType()) + "[]";
            else if (type.IsGenericType)
            {
                var genericArguments = type.GetGenericArguments();
                var genericType = type.GetGenericTypeDefinition();

                if (genericType.IsAssignableFrom(typeof(List<>)))
                    return string.Format("List<{0}>", GetValidTypeName(genericArguments[0]));
                else if (genericType.IsAssignableFrom(typeof(IEnumerable<>)))
                    return string.Format("IEnumerable<{0}>", GetValidTypeName(genericArguments[0]));
                else if (genericType.IsAssignableFrom(typeof(Dictionary<,>)))
                    return string.Format("Dictionary<{0}, {1}>",
                        GetValidTypeName(genericArguments[0]), GetValidTypeName(genericArguments[1]));
                //else if (genericType.IsAssignableFrom(typeof(Amazon.S3.Model.Tuple<,>)))
                //    return string.Format("Tuple<{0}, {1}>",
                //        GetValidTypeName(genericArguments[0]), GetValidTypeName(genericArguments[1]));
                else if (string.Equals(genericType.FullName, "Amazon.S3.Model.Tuple`2", StringComparison.Ordinal))
                    return string.Format("Tuple<{0}, {1}>",
                        GetValidTypeName(genericArguments[0]), GetValidTypeName(genericArguments[1]));
                else if (genericType.IsAssignableFrom(typeof(Nullable<>)))
                    return string.Format("{0}?", GetValidTypeName(genericArguments[0]));
                else
                {
                    LogError("Can't determine generic type. Type = [{0}], GenericType = [{1}]", type.FullName, genericType.FullName);
                    return null;
                }
            }
            else
            {
                return type.Namespace + "." + type.Name;
            }
        }

    }

    internal static class XmlWriterExtensions
    {
        public static void WriteUnescapedElementString(this XmlTextWriter self, string localName, string value)
        {
            if (self == null) throw new ArgumentNullException("self");

            self.WriteStartElement(localName);
            self.WriteRaw(value);
            self.WriteEndElement();
        }
    }
}
