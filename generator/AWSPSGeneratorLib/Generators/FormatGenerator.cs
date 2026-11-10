using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using AWSPowerShellGenerator.FormatConfig;
using System.IO;
using System.Xml;
using System.Management.Automation;
using AWSPowerShellGenerator.Utils;

namespace AWSPowerShellGenerator.Generators
{
    public class FormatGenerator : Generator
    {
        #region Public properties

        public List<Assembly> TargetAssemblies { get; set; }

        /// <summary>
        /// Set for the module that holds Amazon.PowerShell.Common (AWS.Tools.Common, or a monolithic module):
        /// adds the generic AWS.Tools.SensitiveData views, which every service module relies on.
        /// </summary>
        public bool IncludeSensitiveDataViews { get; set; }

        #endregion

        #region Private properties

        /// <summary>
        /// The subfolder hierarchy beneath GeneratorOptions.RootPath that holds the
        /// service xml configuration files and generator manifest to process.
        /// </summary>
        public string FormatGeneratorConfigurationsFoldername => Path.Combine("generator", "AWSPSGeneratorLib", "FormatConfig");

        private ConfigModelCollection ConfigCollection { get; set; }

        private const string AwsToolsPrefix = "AWS.Tools.";

        // Keep in sync with Amazon.PowerShell.Common.BaseCmdlet.SensitiveDataRedactionMessage
        // (separate assembly, so it cannot be shared directly).
        private const string SensitiveDataRedactionMessage = "*** sensitive data redacted from host ***";

        // Keep in sync with Amazon.PowerShell.Common.SensitiveOutput.TypeName.
        public const string SensitiveDataTypeName = "AWS.Tools.SensitiveData";

        private const string ShowSensitiveDataCondition =
            "(Test-Path variable:AWSPowerShell_Show_Sensitive_Data) -and $true.Equals((Get-Variable AWSPowerShell_Show_Sensitive_Data).Value)";

        // Generic views serve tagged values with no per-type view: dictionaries, Documents and streams. The tag also
        // sticks to the base object, so show mode renders entries or properties; formatting the base object would
        // select these views again. One line, because a table or wide cell shows only the first line.
        private const string GenericSensitiveValueScript =
            "if(" + ShowSensitiveDataCondition + "){$b = $_.PSObject.BaseObject; " +
            "if($b.GetType().FullName -eq 'Amazon.Runtime.Documents.Document' -and $b.IsDictionary()){$b = $b.AsDictionary()} " +
            "if($b -is [System.Collections.IDictionary]){($b.GetEnumerator() | ForEach-Object { \"$_\" }) -join ', '} " +
            "elseif($b -is [System.Collections.IEnumerable]){(@($b) | ForEach-Object { \"$_\" }) -join ', '} " +
            "else{($b.PSObject.Properties | ForEach-Object { '{0}: {1}' -f $_.Name, $_.Value }) -join ', '}} " +
            "else{'" + SensitiveDataRedactionMessage + "'}";

        private const string StringSensitiveValueScript =
            "if(" + ShowSensitiveDataCondition + "){$_.PSObject.BaseObject} else{'" + SensitiveDataRedactionMessage + "'}";
        #endregion


        #region Public methods

        protected override void GenerateHelper()
        {
            var configurationsFolder = Path.Combine(Options.RootPath, FormatGeneratorConfigurationsFoldername);
            ConfigCollection = ConfigModelCollection.LoadAllConfigs(configurationsFolder, Options.Verbose);

            LoadCustomFormatDocuments(configurationsFolder);

            var types = new List<Type>();
            foreach (var assembly in TargetAssemblies)
            {
                var assemblyTypes = GetTypes(assembly);
                types.AddRange(assemblyTypes);

                var includeTypes = GetTypes(assembly, ConfigCollection.TypesToInclude.ToArray());
                types.AddRange(includeTypes);
            }

            var cmdletType = typeof(Cmdlet);
            var sensitiveOutputTypes = GetSensitiveOutputTypes(types.Where(t => t.IsSubclassOf(cmdletType)));
            types.RemoveAll(t =>
            {
                var isPrivate = !t.IsPublic || t.IsNestedPrivate;
                var shouldExclude = ConfigCollection.TypeExclusionSet.Contains(t.FullName);
                var isCmdlet = t.IsSubclassOf(cmdletType);

                var exclude = (isPrivate || shouldExclude || isCmdlet);
                if (exclude)
                    Logger.Log("Excluding type {0} from formats file", t.FullName);

                return exclude;
            });

            if (!Directory.Exists(OutputFolder))
                Directory.CreateDirectory(OutputFolder);

            var outputFile = Path.Combine(OutputFolder, Name + ".Format.ps1xml");
            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using (var stream = File.OpenWrite(outputFile))
            {
                var writerSettings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true
                };
                using (var writer = XmlWriter.Create(stream, writerSettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Configuration");
                    if (IncludeSensitiveDataViews)
                        WriteSensitiveDataDefaultSettings(writer);
                    writer.WriteStartElement("ViewDefinitions");

                    foreach (var type in types)
                    {
                        var config = GetConfig(type);

                        Logger.Log();
                        Logger.Log(new string('>', 20));
                        Logger.Log("Generating config: {0}", config);

                        GenerateView(config, writer, type);

                        Logger.Log(new string('<', 20));
                        Logger.Log();
                    }

                    foreach (var type in types.Where(sensitiveOutputTypes.Contains))
                    {
                        WriteSensitiveOutputViews(writer, type, GetProperties(GetConfig(type), type).Select(p => p.Name).ToList());
                    }

                    if (IncludeSensitiveDataViews)
                        WriteGenericSensitiveDataViews(writer);

                    foreach (var cfd in ConfigCollection.CustomFormatDocuments)
                    {
                        var viewDefinitions = cfd.SelectSingleNode("descendant::ViewDefinitions");
                        if (viewDefinitions == null)
                            continue;

                        foreach (var viewNode in viewDefinitions.ChildNodes)
                        {
                            var viewNodeXml = viewNode as XmlNode;
                            using (var reader = XmlReader.Create(new StringReader(viewNodeXml.OuterXml)))
                            {
                                writer.WriteNode(reader, false);
                            }
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
        }

        #endregion

        /// <summary>
        /// Returns the element types of the sensitive non-string properties of the cmdlets' response types. A cmdlet
        /// that returns one of these properties on its own tags each element, and only the tagged views apply to it,
        /// so a view for a property that is never returned on its own is unused.
        /// </summary>
        public static HashSet<Type> GetSensitiveOutputTypes(IEnumerable<Type> cmdletTypes)
        {
            var result = new HashSet<Type>();
            foreach (var cmdletType in cmdletTypes)
            {
                var responseType = cmdletType.GetCustomAttributesData()
                    .Where(a => a.AttributeType.FullName == "Amazon.PowerShell.Common.AWSCmdletAttribute")
                    .SelectMany(a => a.NamedArguments)
                    .Where(a => a.MemberName == "SelectReturnType")
                    .Select(a => a.TypedValue.Value as Type)
                    .FirstOrDefault();
                if (responseType == null)
                    continue;

                foreach (var property in responseType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
                {
                    if (property.PropertyType == typeof(string) || !property.IsSensitive())
                        continue;

                    var propertyType = property.PropertyType;
                    result.Add(propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>)
                        ? propertyType.GetGenericArguments()[0]
                        : propertyType);
                }
            }
            return result;
        }

        /// <summary>
        /// Writes table and list views for a tagged element type, default kind first. Every column is redacted:
        /// the SDK marks the response member as sensitive, not the element's own properties.
        /// </summary>
        public static void WriteSensitiveOutputViews(XmlWriter writer, Type type, IList<string> propertyNames)
        {
            if (propertyNames.Count == 0)
                return;

            var typeName = $"{SensitiveDataTypeName}#{type.FullName}";
            var isTableDefault = propertyNames.Count <= 4;
            foreach (var isTable in new[] { isTableDefault, !isTableDefault })
            {
                var columns = propertyNames.Select(name => (name, $"if({ShowSensitiveDataCondition}){{$_.{name}}} else{{'{SensitiveDataRedactionMessage}'}}"));
                WriteScriptView(writer, $"{(isTable ? "Table" : "List")} view node for {typeName}", typeName, isTable ? "Table" : "List", columns.ToList());
            }
        }

        /// <summary>
        /// Writes the string view, then the table, list, custom and wide views for AWS.Tools.SensitiveData.
        /// </summary>
        public static void WriteGenericSensitiveDataViews(XmlWriter writer)
        {
            // One custom view: out of band, it also renders Format-Table, Format-List, Format-Wide and a string mixed
            // with other objects (Get-Date; $u), and writes the whole value when redaction is off.
            var stringTypeName = $"{SensitiveDataTypeName}#{typeof(string).FullName}";
            var stringColumn = new List<(string, string)> { ("Value", StringSensitiveValueScript) };
            WriteScriptView(writer, $"Custom view node for {stringTypeName}", stringTypeName, "Custom", stringColumn, outOfBand: true);

            var column = new List<(string, string)> { ("Value", GenericSensitiveValueScript) };
            foreach (var kind in new[] { "Table", "List", "Custom", "Wide" })
            {
                WriteScriptView(writer, $"{kind} view node for {SensitiveDataTypeName}", SensitiveDataTypeName, kind, column);
            }
        }

        /// <summary>
        /// Dictionaries and Documents are IEnumerable; without CoreOnly the formatter unrolls them and never sees the tag.
        /// </summary>
        public static void WriteSensitiveDataDefaultSettings(XmlWriter writer)
        {
            writer.WriteStartElement("DefaultSettings");
            writer.WriteStartElement("EnumerableExpansions");
            writer.WriteStartElement("EnumerableExpansion");
            writer.WriteStartElement("EntrySelectedBy");
            writer.WriteElementString("TypeName", SensitiveDataTypeName);
            writer.WriteEndElement();
            writer.WriteElementString("Expand", "CoreOnly");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private static void WriteScriptView(XmlWriter writer, string viewName, string typeName, string kind, IList<(string Label, string Script)> columns, bool outOfBand = false)
        {
            writer.WriteStartElement("View");
            writer.WriteElementString("Name", viewName);
            writer.WriteStartElement("ViewSelectedBy");
            writer.WriteElementString("TypeName", typeName);
            writer.WriteEndElement();
            if (outOfBand)
                writer.WriteElementString("OutOfBand", string.Empty);
            writer.WriteStartElement(kind + "Control");
            switch (kind)
            {
                case "Table":
                    writer.WriteStartElement("TableHeaders");
                    foreach (var column in columns)
                    {
                        writer.WriteStartElement("TableColumnHeader");
                        writer.WriteElementString("Label", column.Label);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteStartElement("TableRowEntries");
                    writer.WriteStartElement("TableRowEntry");
                    writer.WriteStartElement("TableColumnItems");
                    foreach (var column in columns)
                    {
                        writer.WriteStartElement("TableColumnItem");
                        writer.WriteElementString("ScriptBlock", column.Script);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    break;
                case "List":
                    writer.WriteStartElement("ListEntries");
                    writer.WriteStartElement("ListEntry");
                    writer.WriteStartElement("ListItems");
                    foreach (var column in columns)
                    {
                        writer.WriteStartElement("ListItem");
                        writer.WriteElementString("Label", column.Label);
                        writer.WriteElementString("ScriptBlock", column.Script);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    break;
                case "Custom":
                    writer.WriteStartElement("CustomEntries");
                    writer.WriteStartElement("CustomEntry");
                    writer.WriteStartElement("CustomItem");
                    writer.WriteStartElement("ExpressionBinding");
                    writer.WriteElementString("ScriptBlock", columns[0].Script);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    break;
                case "Wide":
                    writer.WriteStartElement("WideEntries");
                    writer.WriteStartElement("WideEntry");
                    writer.WriteStartElement("WideItem");
                    writer.WriteElementString("ScriptBlock", columns[0].Script);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    break;
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void LoadCustomFormatDocuments(string configurationsFolderRoot)
        {
            string filter = null;
            if (Name.StartsWith(AwsToolsPrefix, StringComparison.OrdinalIgnoreCase))
            {
                filter = Name.Substring(AwsToolsPrefix.Length);
            }

            var customFormatDocs = ConfigCollection.LoadCustomFormatDocuments(configurationsFolderRoot, filter);
            foreach (var cfd in customFormatDocs)
            {
                var typeNameNodes = cfd.SelectNodes("descendant::TypeName");
                if (typeNameNodes == null)
                {
                    Logger.Log("Custom formats file {0} appears has no TypeName descendants", cfd);
                    continue;
                }

                foreach (var t in typeNameNodes)
                {
                    var xmlNode = t as XmlNode;
                    if (xmlNode != null)
                        ConfigCollection.TypeExclusionSet.Add(xmlNode.InnerText);
                }
            }
        }

        private void GenerateView(ConfigModel config, XmlWriter writer, Type type)
        {
            if (config.ReflectOverType)
            {
                var newConfig = new ConfigModel
                {
                    ApplicableTypes =
                        (config.ApplicableTypes == null || config.ApplicableTypes.Count == 0)
                            ? new List<string> {type.FullName}
                            : config.ApplicableTypes
                };

                foreach (var property in GetProperties(config, type))
                {
                    string name = property.Name;

                    var existingColumn = GetColumn(config, name);

                    existingColumn.Merge(new ColumnConfig
                    {
                        HeaderLabel = name,
                        PropertyName = name,
                        IsSensitive = property.IsSensitive()
                    });

                    newConfig.Columns.Add(existingColumn);
                }
                GenerateView_NonReflective(newConfig, writer, type);
            }
            else
            {
                GenerateView_NonReflective(config, writer, type);
            }
        }

        private ConfigModel GetConfig(Type targetType)
        {
            string typeName = targetType.FullName;
            var config = ConfigCollection.Configs.FirstOrDefault(c => string.Equals(c.PropertiesType, typeName));
            if (config == null)
                config = new ConfigModel
                {
                    PropertiesType = typeName,
                    ApplicableTypes = new List<string> { typeName },
                };
            return config;
        }
        private ColumnConfig GetColumn(ConfigModel config, string propertyName)
        {
            foreach (var column in config.Columns)
            {
                if (string.Equals(column.HeaderLabel, propertyName, StringComparison.Ordinal))
                    return column;
            }
            return new ColumnConfig();
        }

        private IEnumerable<PropertyInfo> GetProperties(ConfigModel config, Type type)
        {
            foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                if (!config.SkipProperties.Contains(property.Name) && property.CanRead)
                {
                    var attributes = property.GetCustomAttributes(true);
                    if (!attributes.Any(a => a is ObsoleteAttribute))
                        yield return property;
                }
            }
        }
        
        private IEnumerable<Type> GetTypes(Assembly assembly, params string[] typeNames)
        {
            return typeNames.Select(assembly.GetType).Where(type => type != null);
        }

        /// <summary>
        /// Returns all types from the specified assembly. Types contained in
        /// namespaces declared to be excluded are omitted from the returned 
        /// collection. Other types such as those marked private are filtered
        /// out later.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private IEnumerable<Type> GetTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            var exclusionPatterns = ConfigCollection.NamespacesToExclude.Select(np => new Regex(np)).ToList();

            foreach (var type in assembly.GetTypes())
            {
                var ns = type.Namespace;
                if (string.IsNullOrEmpty(ns))
                    continue;

                var collectType = true;
                foreach (var np in exclusionPatterns)
                {
                    if (np.IsMatch(ns))
                    {
                        collectType = false;
                        break;
                    }
                }

                if (collectType)
                    yield return type;
                else
                    Logger.Log("Excluding type {0} based on namespace exclusions", type.FullName);
            }
        }

        public static void GenerateView_NonReflective(ConfigModel config, XmlWriter writer, Type targetType)
        {
            if (config.Columns.Count == 0) return;
            bool isTableView = config.Columns.Count <= 4;

            // The first view written is the default display view, so keep it unchanged.
            WriteView(config, writer, targetType, isTableView, string.Format("View node for {0}", targetType.FullName));

            // Format-Table and Format-List only use a view of their own kind; without one they fall back to
            // displaying raw property values. When the type has sensitive properties, also emit the other view
            // kind so both cmdlets redact them.
            if (config.Columns.Any(column => column.IsSensitive))
            {
                WriteView(config, writer, targetType, !isTableView, string.Format("{0} view node for {1}", isTableView ? "List" : "Table", targetType.FullName));
            }
        }

        private static void WriteView(ConfigModel config, XmlWriter writer, Type targetType, bool isTableView, string viewName)
        {
            writer.WriteStartElement("View");
            {
                writer.WriteElementString("Name", viewName);

                writer.WriteStartElement("ViewSelectedBy");
                {
                    if (config.ApplicableTypes != null && config.ApplicableTypes.Count > 0)
                    {
                        foreach (var type in config.ApplicableTypes)
                        {
                            writer.WriteElementString("TypeName", type);
                        }
                    }
                    else
                    {
                        writer.WriteElementString("TypeName", targetType.FullName);
                    }
                }
                writer.WriteEndElement();

                writer.WriteStartElement(isTableView ? "TableControl" : "ListControl");
                {
                    if (isTableView)
                    {
                        writer.WriteStartElement("TableHeaders");
                        {
                            foreach (var header in config.Columns)
                            {
                                writer.WriteStartElement("TableColumnHeader");
                                {
                                    writer.WriteElementString("Label", header.HeaderLabel);
                                    if (header.HeaderWidth != 0)
                                        writer.WriteElementString("Width", header.HeaderWidth.ToString());
                                    if (header.HeaderAlignment != HeaderAlignment.None)
                                        writer.WriteElementString("Alignment", header.HeaderAlignment.ToString());
                                }
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                    }

                    writer.WriteStartElement(isTableView ? "TableRowEntries" : "ListEntries");
                    {
                        writer.WriteStartElement(isTableView ? "TableRowEntry" : "ListEntry");
                        {
                            writer.WriteStartElement(isTableView ? "TableColumnItems" : "ListItems");
                            {
                                foreach (var column in config.Columns)
                                {
                                    writer.WriteStartElement(isTableView ? "TableColumnItem" : "ListItem");
                                    {
                                        if (column.IsSensitive)
                                        {
                                            if (!isTableView)
                                                writer.WriteElementString("Label", column.PropertyName);

                                            string scriptBlockValue =
                                                $"if({ShowSensitiveDataCondition}){{$_.{column.PropertyName}}} else{{'{SensitiveDataRedactionMessage}'}}";
                                            writer.WriteElementString("ScriptBlock", scriptBlockValue);
                                        }
                                        else if (!string.IsNullOrEmpty(column.PropertyName))
                                            writer.WriteElementString("PropertyName", column.PropertyName);
                                        else if (!string.IsNullOrEmpty(column.ScriptBlock))
                                            writer.WriteElementString("ScriptBlock", column.ScriptBlock);
                                        else
                                            throw new InvalidDataException("PropertyName and ScriptBlock are not set");
                                    }
                                    writer.WriteEndElement();
                                }
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
