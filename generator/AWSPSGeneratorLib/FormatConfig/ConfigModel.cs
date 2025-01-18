using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

using AWSPowerShellGenerator.Utils;

namespace AWSPowerShellGenerator.FormatConfig
{
    [XmlRoot]
    public class ConfigModelCollection
    {
        /// <summary>
        /// By default all namespaces are scanned for model types, except those in
        /// namespaces containing '.Internal.'. This list allows additional namespaces
        /// to be excluded from the scan.
        /// </summary>
        [XmlArray]
        [XmlArrayItem("Namespace")]
        public List<string> NamespacesToExclude { get; set; }

        private HashSet<string> _namespaceExclusionSet;
        internal HashSet<string> NamespaceExclusionSet
        {
            get
            {
                if (_namespaceExclusionSet == null)
                {
                    _namespaceExclusionSet = new HashSet<string>();
                    if (NamespacesToExclude.Any())
                    {
                        foreach (var n in NamespacesToExclude)
                        {
                            _namespaceExclusionSet.Add(n);
                        }
                    }
                }

                return _namespaceExclusionSet;
            }
        }
            
        /// <summary>
        /// Specific types to add to the emitted formats.
        /// </summary>
        [XmlArray]
        [XmlArrayItem("Type")]
        public List<string> TypesToInclude { get; set; }

        private HashSet<string> _typeInclusionSet;
        internal HashSet<string> TypeInclusionSet
        {
            get
            {
                if (_typeInclusionSet == null)
                {
                    _typeInclusionSet = new HashSet<string>();
                    if (TypesToInclude.Any())
                    {
                        foreach (var t in TypesToInclude)
                        {
                            _typeInclusionSet.Add(t);
                        }
                    }
                }

                return _typeInclusionSet;
            }
        }

        /// <summary>
        /// Specific types to exclude from the emitted formats. This list will be
        /// automatically extended to include any types found in custom format files.
        /// </summary>
        [XmlArray]
        [XmlArrayItem("Type")]
        public List<string> TypesToExclude { get; set; }

        private HashSet<string> _typeExclusionSet;
        internal HashSet<string> TypeExclusionSet
        {
            get
            {
                if (_typeExclusionSet == null)
                {
                    _typeExclusionSet = new HashSet<string>();
                    if (TypesToExclude.Any())
                    {
                        foreach (var t in TypesToExclude)
                        {
                            _typeExclusionSet.Add(t);
                        }
                    }
                }

                return _typeExclusionSet;
            }
        }

        private List<XmlDocument> _customFormatDocuments; 
        internal IEnumerable<XmlDocument> CustomFormatDocuments
        {
            get { return _customFormatDocuments; }
        }

        /// <summary>
        /// Loads custom format files to include in the final master set. Any type names found 
        /// in a custom formats file are added to the TypesToExclude set so that no duplication 
        /// occurs. Custom format files should be standalone ps1xml files located in the 
        /// .\FormatConfig\CustomFormats folder.
        /// </summary>
        internal IEnumerable<XmlDocument> LoadCustomFormatDocuments(string configurationsFolderRoot, string filter)
        {
            if (_customFormatDocuments == null)
            {
                _customFormatDocuments = new List<XmlDocument>();
                var customFormatsFolder = Path.Combine(configurationsFolderRoot, "CustomFormats");
                if (filter != null)
                {
                    customFormatsFolder = Path.Combine(customFormatsFolder, filter);
                }
                if (Directory.Exists(customFormatsFolder))
                {
                    var customFormatFiles = Directory.GetFiles(customFormatsFolder, "*.ps1xml", SearchOption.AllDirectories);
                    foreach (var customFormatFile in customFormatFiles)
                    {
                        var doc = new XmlDocument();
                        doc.Load(customFormatFile);
                        _customFormatDocuments.Add(doc);
                    }
                }
            }

            return CustomFormatDocuments;
        }

        [XmlElement]
        public List<ConfigModel> Configs { get; set; }

        /// <summary>
        /// Deserialize the configuration data for custom formats.
        /// </summary>
        /// <param name="configurationsFolder"></param>
        /// <param name="verbose"></param>
        /// <returns></returns>
        public static ConfigModelCollection LoadAllConfigs(string configurationsFolder, bool verbose = false)
        {
            var formatConfigsFile = Path.GetFullPath(Path.Combine(configurationsFolder, "Configs.xml"));
            if (verbose)
                Console.WriteLine("...loading formats configuration manifest {0}", formatConfigsFile);

            try
            {
                var serializer = new XmlSerializer(typeof(ConfigModelCollection));
                using (var fs = new FileStream(formatConfigsFile, FileMode.Open))
                {
                    using (var reader = new StreamReader(fs))
                    {
                        return serializer.Deserialize(reader) as ConfigModelCollection;
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException("Unable to retrieve content for formats manifest file " + formatConfigsFile, e);
            }
        }

        protected ConfigModelCollection()
        {
            NamespacesToExclude = new List<string>();
            TypesToInclude = new List<string>();
            TypesToExclude = new List<string>();
        }
    }

    public class ConfigModel
    {
        [XmlArray]
        [XmlArrayItem("Type")]
        public List<string> ApplicableTypes { get; set; }

        //public List<HeaderConfig> Headers { get; set; }
        
        public List<ColumnConfig> Columns { get; set; }

        public string PropertiesType { get; set; }
        
        [XmlArray]
        [XmlArrayItem("Property")]
        public List<string> SkipProperties { get; set; }

        [XmlIgnore]
        public bool ReflectOverType { get { return (!string.IsNullOrEmpty(PropertiesType)); } }

        public ConfigModel()
        {
            ApplicableTypes = new List<string>();
            //Headers = new List<HeaderConfig>();
            Columns = new List<ColumnConfig>();
            SkipProperties = new List<string>();
        }
    }

    public enum HeaderAlignment { None, Left, Right }

    //public class HeaderConfig
    //{
    //    [XmlAttribute]
    //    public string Label { get; set; }
    //    [XmlAttribute]
    //    public int Width { get; set; }
    //    [XmlAttribute]
    //    public HeaderAlignment Alignment { get; set; }
    //    [XmlAttribute]
    //    public int Order { get; set; }

    //    public HeaderConfig()
    //    {
    //        Label = null;
    //        Width = 0;
    //        Alignment = HeaderAlignment.None;
    //        Order = 0;
    //    }

    //    public void Merge(HeaderConfig other)
    //    {
    //        Label = other.Label != null ? other.Label : this.Label;
    //        Width = other.Width != 0 ? other.Width : this.Width;
    //        Alignment = other.Alignment != HeaderAlignment.None ? other.Alignment : this.Alignment;
    //        Order = other.Order != 0 ? other.Order : this.Order;
    //    }
    //}


    public class ColumnConfig
    {
        [XmlAttribute]
        public string HeaderLabel { get; set; }
        [XmlAttribute]
        public int HeaderWidth { get; set; }
        [XmlAttribute]
        public HeaderAlignment HeaderAlignment { get; set; }
        [XmlAttribute]
        public int HeaderOrder { get; set; }
        [XmlIgnore]
        public bool IsSensitive { get; set; }

        [XmlAttribute]
        public string ScriptBlock { get; set; }
        [XmlAttribute]
        public string PropertyName { get; set; }



        public ColumnConfig()
        {
            ScriptBlock = null;
            PropertyName = null;
            IsSensitive = false;

            HeaderLabel = null;
            HeaderWidth = 0;
            HeaderAlignment = FormatConfig.HeaderAlignment.None;
            HeaderOrder = 0;
        }

        public void Merge(ColumnConfig other)
        {
            HeaderLabel = other.HeaderLabel ?? this.HeaderLabel;
            HeaderWidth = other.HeaderWidth != 0 ? other.HeaderWidth : this.HeaderWidth;
            HeaderAlignment = other.HeaderAlignment != HeaderAlignment.None ? other.HeaderAlignment : this.HeaderAlignment;
            HeaderOrder = other.HeaderOrder != 0 ? other.HeaderOrder : this.HeaderOrder;
            IsSensitive = other.IsSensitive || this.IsSensitive;

            ScriptBlock = other.ScriptBlock ?? this.ScriptBlock;
            PropertyName = other.PropertyName ?? this.PropertyName;
        }
    }
}
