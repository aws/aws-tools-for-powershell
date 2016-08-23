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

namespace AWSPowerShellGenerator.Generators
{
    public class FormatGenerator : Generator
    {
        #region Public properties

        public List<Assembly> TargetAssemblies { get; set; }
        public string Name { get; set; }

        #endregion

        #region Private properties

        /// <summary>
        /// The subfolder hierarchy beneath GeneratorOptions.RootPath that holds the
        /// service xml configuration files and generator manifest to process.
        /// </summary>
        public const string FormatGeneratorConfigurationsFoldername = @"generator\AWSPSGeneratorLib\FormatConfig";

        private ConfigModelCollection ConfigCollection { get; set; }

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

        private void LoadCustomFormatDocuments(string configurationsFolderRoot)
        {
            var customFormatDocs = ConfigCollection.LoadCustomFormatDocuments(configurationsFolderRoot);
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
                        PropertyName = name
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

        private void GenerateView_NonReflective(ConfigModel config, XmlWriter writer, Type targetType)
        {
            if (config.Columns.Count == 0) return;
            bool isTableView = config.Columns.Count <= 4;

            writer.WriteStartElement("View");
            {
                writer.WriteElementString("Name", string.Format("View node for {0}", targetType.FullName));

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
                                        if (!string.IsNullOrEmpty(column.PropertyName))
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
