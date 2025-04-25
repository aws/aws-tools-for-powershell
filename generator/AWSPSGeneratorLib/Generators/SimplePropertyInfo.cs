using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Reflection;
using System.Xml;
using System.IO;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Utils;
using System.Collections.Concurrent;

#pragma warning disable CS0168
namespace AWSPowerShellGenerator.Generators
{
    public class SimplePropertyInfo
    {
        const string ConstantClassBaseTypeName = "Amazon.Runtime.ConstantClass";
        internal const string DocumentTypeFullName = "Amazon.Runtime.Documents.Document";

        #region Properties

        public enum PropertyCollectionType
        {
            NoCollection = 0,
            IsGenericList,
            IsGenericDictionary,
            IsGenericListOfGenericList,
            IsGenericListOfGenericListOfGenericList,
            IsGenericListOfGenericListOfGenericListOfGenericList,
            IsGenericListOfGenericDictionary
        }

        public PropertyInfo BaseProperty { get; private set; }

        public Type DeclaringType { get; private set; }
        public Type PropertyType { get; private set; }
        public String DeprecationMessage { get; private set; }
        public bool IsDeprecated { get { return DeprecationMessage != null; }  }
        public bool IsRequired { get; private set; }

        public long? MinValue { get; private set; }

        public long? MaxValue { get; private set; }

        /// <summary>
        /// <para>
        /// Returns true if we should check at runtime that the associated parameter has been bound 
        /// and is in the cmdlet's BoundParameters collection. 
        /// </para>
        /// <para>
        /// The execution context member for the parameter will be set to a nullable type to allow us 
        /// to employ use-if-present/ignore-if-absent semantics and avoid passing unintentional default 
        /// values to request class members  (ie 'false' for a bool that was never specified by the user, 
        /// which may have a different meaning to 'not specified').
        /// </para>
        /// </summary>
        public bool UseParameterValueOnlyIfBound { get; internal set; }

        public string PropertyTypeName { get; set; }
        public Type[] GenericCollectionTypes { get; internal set; }
        public PropertyCollectionType CollectionType { get; internal set; }

        public SimplePropertyInfo Parent { get; private set; }
        public SimplePropertyInfo RootParent
        {
            get
            {
                if (Parent == null)
                    return this;
                return Parent.RootParent;
            }
        }
        public List<SimplePropertyInfo> Children { get; private set; }

        /// <summary>
        /// Any customization applied to the parameter, either from a 
        /// config file entry or during generation as a result of
        /// automatic renaming. In the configuration file, parameters
        /// can be customized at the service operation level or globally
        /// for a service.
        /// </summary>
        public Param Customization { get; set; }

        /// <summary>
        /// The original property member name 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The full (potentially flattened) name of the property after
        /// reflection of the request hierarchy has completed. This
        /// uniquely identifies the property no matter the hierarchy.
        /// Parent property names are separated by '_' characters.
        /// </summary>
        public string AnalyzedName { get { return GetFullName(Name); } }

        /// <summary>
        /// The name of the parameter to expose to the user.
        /// </summary>
        public string CmdletParameterName
        {
            get
            {
                if (Customization != null && !string.IsNullOrEmpty(Customization.NewName))
                    return Customization.NewName;

                return AnalyzedName;
            }
        }

        // set when parsing properties on cmdlets, so we can extract positional,
        // pipeline-by-value and parameter set data for help purposes
        public ParameterAttribute[] PsParameterAttribute { get; private set; }

        // set when parsing properties on cmdlets, so that we can report aliases
        // in the web help
        public AliasAttribute PsAliasAttribute { get; private set; }

        // for help generation, this is retrieved from the Amazon.PowerShell.Common.AWSRequiredParameter
        // Null means the parameter is never required. An empty set means the parameter is always required.
        public HashSet<string> IsRequiredForParameterSets { get; private set; }

        /// <summary>
        /// Safely returns positional data for a cmdlet property. Parameters that
        /// are not positional are given a fake positional value that orders them
        /// after the real positionals; these parameters can only be specified with
        /// the parameter name.
        /// </summary>
        public int ParameterPosition
        {
            get
            {
                if (PsParameterAttribute != null)
                {
                    foreach (var p in PsParameterAttribute)
                    {
                        if (p.Position >= 0)
                            return p.Position;
                    }
                }

                return int.MaxValue;
            }    
        }

        public bool CanPipelineByValue
        {
            get
            {
                if (PsParameterAttribute == null)
                {
                    foreach (var p in PsParameterAttribute)
                    {
                        if (p.ValueFromPipeline)
                            return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Wether the property is required. If the parent property is a class member, the parent
        /// mult also be a required property.
        /// </summary>
        public bool IsRecursivelyRequired
        {
            get
            {
                return IsRequired && (Parent?.IsRecursivelyRequired ?? true);
            }
        }



        /// <summary>
        /// If the parameter type is a switch/bool type, we only shorten and prefer to leave any
        /// pluralization in the termination fragment as-is, for better readability
        /// </summary>
        public bool IsValidForSingularization
        {
            get
            {
                // we don't currently use SwitchParameter types in the generated cmdlets, only nullable bools
                // but test in case this changes. I've noticed some variability in casing so do insensitive
                // check, plus we can see 'bool' and 'boolean' so match on prefix.
                var typesNotToSingularize = new[] {"bool", "switch"};
                return !typesNotToSingularize.Any(t => PropertyTypeName.StartsWith(t, StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// If true the parameter type derives from the SDK's ConstantClass
        /// enumeration type and an argument completer should be generated 
        /// for/referenced by the parameter.
        /// </summary>
        public bool IsConstrainedToSet
        {
            get; private set;
        }

        public bool IsReadWrite { get; private set; }
        public XmlDocument DocumentationSource { get; private set; }

        /// <summary>
        /// True if the type of the parameter/property is derived from
        /// a System.IO.MemoryStream type.
        /// </summary>
        public bool IsMemoryStreamType { get; private set; }

        /// <summary>
        /// True if the type of the parameter/property is derived from
        /// a System.IO.Stream type.
        /// </summary>
        public bool IsStreamType { get; private set; }

        /// <summary>
        /// True if the type of the parameter/property is Amazon.Runtime.Document
        /// </summary>
        public bool IsDocumentType { get; private set; }

        public string DefaultValue { get; internal set; }

        private static ConcurrentDictionary<Tuple<Type, string>, string> PowershellDocumentationCache = new ConcurrentDictionary<Tuple<Type, string>, string>();

        public string PowershellDocumentation
        {
            get
            {
                var key = new Tuple<Type, string>(DeclaringType, CmdletParameterName);
                var xml = PowershellDocumentationCache.GetOrAdd(key, (k) =>
                {
                    var documentation = MemberDocumentation; //FlattenedDocumentation;
                    return DocumentationUtils.FormatXMLForPowershell(documentation);
                });

                return xml;
            }
        }

        private static ConcurrentDictionary<Tuple<Type, string>, string> PowershellWebDocumentationCache = new ConcurrentDictionary<Tuple<Type, string>, string>();

        public string PowershellWebDocumentation
        {
            get
            {
                var key = new Tuple<Type, string>(DeclaringType, CmdletParameterName);
                var xml = PowershellWebDocumentationCache.GetOrAdd(key, (k) =>
                {
                    var documentation = MemberDocumentation; //FlattenedDocumentation;
                    return DocumentationUtils.FormatXMLForPowershell(documentation, true);
                });
                return xml;
            }
        }

        // Extracts just the member documentation for a parameter, ignoring the parent hierarchy
        // issues that using FlattenedDocumentation yields. In addition we strip the unnecessary
        // 'Gets and sets the...' opening sentence if present. If as a result of these changes
        // the member yields no documentation, we log it and put in a holding comment whilst we
        // chase up the service team (so the SDKs and other tools benefit too).
        public string MemberDocumentation
        {
            get
            {
                using (var writer = new StringWriter())
                {
                    var propertyDocumentation = DocumentationUtils.GetPropertyDocumentation(DeclaringType, Name, DocumentationSource);
                    // would like to make this a collection of regex's one day, to handle multiple cuts/replacements
                    var sentenceStart = propertyDocumentation.IndexOf("Gets and sets ", StringComparison.Ordinal);
                    if (sentenceStart != -1)
                    {
                        // roll forward to the start of the next sentence, if any
                        var sentenceEnd = propertyDocumentation.IndexOf('.', sentenceStart + 1);
                        if (sentenceEnd != -1)
                        {
                            sentenceEnd++;
                            while (sentenceEnd < propertyDocumentation.Length)
                            {
                                if (!Char.IsWhiteSpace(propertyDocumentation[sentenceEnd]))
                                    break;
                                sentenceEnd++;
                            }
                        }

                        // snip out the sentence, as this leaves any surrounding tags intact (which
                        // is safer)
                        if (sentenceEnd == -1 || sentenceEnd > propertyDocumentation.Length)
                            sentenceEnd = propertyDocumentation.Length;
                        var sentenceLength = sentenceEnd - sentenceStart;
                        propertyDocumentation = propertyDocumentation.Remove(sentenceStart, sentenceLength);
                    }

                    // do some cleaning up of excess newlines we sometimes see
                    if (!string.IsNullOrEmpty(propertyDocumentation))
                    {
                        propertyDocumentation = propertyDocumentation.TrimStart('\r', '\n');
                        propertyDocumentation = propertyDocumentation.Replace("<para>" + Environment.NewLine, "<para>");
                        propertyDocumentation = propertyDocumentation.Replace(Environment.NewLine + "</para>", "</para>");
                        propertyDocumentation = propertyDocumentation.Replace("<para></para>", "");
                        propertyDocumentation = propertyDocumentation.TrimEnd('\r', '\n');
                    }

                    if (propertyDocumentation.Length == 0)
                    {
                        propertyDocumentation = "The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.";
                        // Steve: turning this message off now I have the initial set of shape
                        // members that have no useful documentation. Will re-enable and make a build
                        // error once the doc team members I've contacted finish updating their models.
                        //Console.WriteLine("Warning: Missing parameter documentation: - sdk: {0} (parameter {1})", this.GetFullName(this.BaseProperty), this.CmdletParameterName);
                    }

                    // have some sdk docs that don't start with para tags, but use them internally and
                    // other mixes -- unless we have recognized start and end tags, we assume we have a
                    // mixed snippet and enclose everything.
                    writer.WriteLine("<para>");
                    writer.WriteLine(propertyDocumentation);
                    writer.WriteLine("</para>");

                    var finalDoc = writer.ToString();
                    return finalDoc.Trim();
                }
            }
        }

        /// <summary>
        /// Extracts the field values for a property that is derived from the SDK's ConstantClass
        /// enumeration type.
        /// </summary>
        /// <param name="propertyType">The ConstantClass-derived type to be inspected</param>
        /// <returns>Collection of strings representing the valid values</returns>
        public static IEnumerable<string> GetConstantClassMembers(Type propertyType)
        {
            if (!propertyType.BaseType.FullName.Equals(ConstantClassBaseTypeName, StringComparison.Ordinal))
                throw new ArgumentException(string.Format("GetConstantClassMembers: base type of {0} was {1}, expected {2}", 
                                                          propertyType.FullName, 
                                                          propertyType.BaseType.FullName,
                                                          ConstantClassBaseTypeName));

            // order the set to help user at command prompt; ignore case since PowerShell is case insensitive and
            // SDK member styling varies
            var memberSet = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);

            var fields = propertyType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField);
            foreach (var f in fields)
            {
                var v = f.GetValue(null).ToString();
                memberSet.Add(v);
            }

            return memberSet;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// This ctor is used by the help generator. At this point we don't care about collection type/contents or
        /// emit limiter status as the type data has already been determined.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="parent"></param>
        /// <param name="propertyTypeName"></param>
        /// <param name="documentationSource"></param>
        public SimplePropertyInfo(PropertyInfo propertyInfo, SimplePropertyInfo parent, string propertyTypeName, XmlDocument documentationSource)
            : this(propertyInfo, parent, propertyTypeName, documentationSource, PropertyCollectionType.NoCollection, null)
        {
        }

        /// <summary>
        /// This ctor should be used by anything that emits code. Emit limiters are always emitted
        /// as int types regardless of the wire type and as such a check will be made for the 
        /// parameter being bound before use. The check for all other parameters is done based on 
        /// whether they could be a nullable value type.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="parent"></param>
        /// <param name="propertyTypeName"></param>
        /// <param name="documentationSource"></param>
        /// <param name="collectionType"></param>
        /// <param name="genericCollectionTypes"></param>
        public SimplePropertyInfo(PropertyInfo propertyInfo, 
                                  SimplePropertyInfo parent, 
                                  string propertyTypeName, 
                                  XmlDocument documentationSource,
                                  PropertyCollectionType collectionType,
                                  Type[] genericCollectionTypes)
        {
            BaseProperty = propertyInfo;
            Name = propertyInfo.Name;

            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                PropertyType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
            }
            else
            {
                PropertyType = propertyInfo.PropertyType;
            }

            PropertyTypeName = propertyTypeName;
            DeclaringType = propertyInfo.DeclaringType;
            DeprecationMessage = propertyInfo.GetCustomAttributes(typeof(ObsoleteAttribute), false).Cast<ObsoleteAttribute>().FirstOrDefault()?.Message;
            
            dynamic awsPropertyAttribute = propertyInfo.GetCustomAttributes().Where(attribute => attribute.GetType().FullName == "Amazon.Runtime.Internal.AWSPropertyAttribute").SingleOrDefault();
            if (awsPropertyAttribute != null)
            {
                IsRequired = awsPropertyAttribute?.Required;
                MinValue = awsPropertyAttribute.IsMinSet ? awsPropertyAttribute.Min : null;
                MaxValue = awsPropertyAttribute.IsMaxSet ? awsPropertyAttribute.Max : null;
            }

            CollectionType = collectionType;
            GenericCollectionTypes = genericCollectionTypes;

            Parent = parent;
            Children = new List<SimplePropertyInfo>();
            IsReadWrite = propertyInfo.CanRead && propertyInfo.CanWrite;
            DocumentationSource = documentationSource;
            IsMemoryStreamType = typeof(System.IO.MemoryStream).IsAssignableFrom(PropertyType);
            IsStreamType = typeof(System.IO.Stream).IsAssignableFrom(PropertyType);
            IsDocumentType = PropertyType.FullName == DocumentTypeFullName;

            UseParameterValueOnlyIfBound = IsNullableValueType(propertyInfo.PropertyType);

            // if analysing properties on a cmdlet for help purposes, extract 
            // the Parameter, AWSRequiredParameter and Alias attributes info
            PsParameterAttribute
                = propertyInfo.GetCustomAttributes(typeof(ParameterAttribute), false) as ParameterAttribute[];
            PsAliasAttribute
                = propertyInfo.GetCustomAttributes(typeof(AliasAttribute), false).SingleOrDefault() as AliasAttribute;
            IsRequiredForParameterSets = GetRequiredHelpDescription(propertyInfo);

            IsConstrainedToSet = PropertyType.BaseType != null && PropertyType.BaseType.FullName.Equals(ConstantClassBaseTypeName, StringComparison.Ordinal);
        }

        #endregion

        #region Private members

        private static HashSet<string> GetRequiredHelpDescription(PropertyInfo propertyInfo)
        {
            dynamic awsRequiredParameter = propertyInfo.GetCustomAttributes().Where(attribute => attribute.GetType().FullName == "Amazon.PowerShell.Common.AWSRequiredParameterAttribute").SingleOrDefault();

            if (awsRequiredParameter == null)
            {
                return null;
            }
            string[] parameterSets = awsRequiredParameter.ParameterSets;
            if (parameterSets == null || parameterSets.Length == 0)
            {
                return new HashSet<string>();
            }

            return new HashSet<string>(parameterSets);
        }

        private static bool IsNullableValueType(Type type)
        {
            if (type == typeof(PSObject) || type.FullName == DocumentTypeFullName)
                return false;

            if (!type.IsValueType)
                return false;

            if (type.IsGenericType)
                return type.GetGenericTypeDefinition().IsAssignableFrom(typeof (Nullable<>));

            return true;
        }

        private string GetFullName(PropertyInfo propertyInfo)
        {
            string parentHierarchy = RootParent.DeclaringType.FullName;
            var parent = Parent;
            while (parent != null)
            {
                parentHierarchy = parentHierarchy + "." + parent.Name;
                parent = parent.Parent;
            }
            string propertyFullName = parentHierarchy + "." + Name;
            return propertyFullName;
        }

        private string GetFullName(string name)
        {
            string fullName;
            if (Parent != null)
                fullName = Parent.AnalyzedName + "_" + name;
            else
                fullName = name;
            return fullName;
        }

        #endregion

        public override string ToString()
        {
            return this.AnalyzedName;
        }
    }

    public static class DocumentationUtils
    {
        // cache member documentation summary
        private static ConcurrentDictionary<string, string> _memberDocumentationSummaryCache = new ConcurrentDictionary<string, string>();
        // these two strings get substituted when we have iteration parameters on a cmdlet but no doc
        private const string MissingNextTokenHelpText = "Indicates where to start fetching the next page of results when paginating manually.";
        private const string MissingMaxRecordsHelpText = "The maximum number of records to emit.";

        /// <summary>
        /// Contains substitute text for cmdlet parameters which yield in no documentation once
        /// the SDK doc (if any) has been cleaned of redundant information ("Gets and sets...").
        /// The intent is to have this be an empty collection eventually.... The dictionary is keyed
        /// off of the cmdlet parameter's property name, so entries can be re-used across multiple cmdlets.
        /// This collection is probed if a member-specific entry cannot be found in the
        /// SubstituteSDKTypeMemberDocumentation dictionary. 
        /// </summary>
        static readonly Dictionary<string, string> SubstituteParameterDocumentation = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            // iteration parameters
            { "NextToken", MissingNextTokenHelpText },
            { "Marker", MissingNextTokenHelpText },
            { "PageToken", MissingNextTokenHelpText },
            { "MaxRecords", MissingMaxRecordsHelpText },
            { "MaxItems", MissingMaxRecordsHelpText },
            { "MaxKeys", MissingMaxRecordsHelpText },
            { "MaxJobs", MissingMaxRecordsHelpText },
            { "Limit", MissingMaxRecordsHelpText },
            { "MaxResults", MissingMaxRecordsHelpText },
        };

        #region Cmdlet processing

        private const string SDKLeadingSpaces = "            ";
        private const string SDKTypeFirstLineStart = "Container for the parameters to the";
        private const string SDKTypeFirstLineEnd = "operation.";

        private static string CleanseSDKTypeDocumentation(string documentation)
        {
            bool isFirst = true;
            var modified = DocumentationUtils.ProcessLines(documentation, l =>
            {
                string t = l;
                if (t.StartsWith(SDKLeadingSpaces, StringComparison.Ordinal))
                {
                    t = t.Substring(SDKLeadingSpaces.Length);
                }

                if (isFirst)
                {
                    isFirst = false;
                    if (t.StartsWith(SDKTypeFirstLineStart, StringComparison.Ordinal) &&
                        t.EndsWith(SDKTypeFirstLineEnd, StringComparison.Ordinal))
                    {
                        return null;
                    }
                }
                return t;
            });

            string xml = RemoveOuterParaTag(modified);
            return xml;
        }
        private static string RemoveOuterParaTag(string text)
        {
            //Because most of the times text is not valid xml, this method wastes a lot
            //of build time by failing XmlDocument.LoadXml and catching the exception.
            //Let's at least return quickly if text doesn't start with a '<'.
            //TODO replace this whole method with a regular expression.
            if (!text.TrimStart().StartsWith('<'))
            {
                return text;
            }

            var doc = new XmlDocument();

            string newXml = text;
            try
            {
                //Adding an outer element because sometimes there are more elements than one in the xml block
                //and it would fail the parsing
                doc.LoadXml("<root>" + text + "</root>");
                var rootElement = doc.DocumentElement;
                if (rootElement.ChildNodes.Count == 1 && (rootElement.ChildNodes[0] as XmlElement)?.Name == "para")
                {
                    newXml = rootElement["para"].InnerXml.Trim();
                }
            }
            catch (Exception e)
            {
            }
            return newXml;
        }

        #endregion

        #region PowerShell processing

        //private static HashSet<string> XMLNodesToIgnore = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "b", "i", "c" };
        private static HashSet<string> XMLNodesToCopyAsIs = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "list", "see", "istruncated", "copy", "a", "br", "b", "i", "c", "p", "emphasis", "important", "code", "member", "title", "caution"
        };
        private static HashSet<string> XMLNodesToNewline = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "para", "note", "ul", "remarks", "ol"
        };
        private static HashSet<string> XMLNodesToRemove = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "enumvalues"
        };

        // temp replacement docs for ElastiCache's use of a table element in the
        // docs for NewAvailabilityZones
        private const string newAvailabilityZonesTableReplacement =  
@"

Scenarios  Pending Operation  New Request  Results

---------  -----------------  -----------  ------------------------------------

Scenario-1  Delete            Delete       The new delete, pending or immediate,

                                           replaces the pending delete.

Scenario-2  Delete            Create       The new create, pending or immediate,

                                           replaces the pending delete.

Scenario-3  Create            Delete       The new delete, pending or immediate,

                                           replaces the pending create.

Scenario-4  Create            Create       The new create is added to the pending

                                           create. Important: If the new create

                                           request is 'Apply Immediately - Yes',

                                           all creates are performed immediately.

                                           If the new create request is

                                           'Apply Immediately - No', all creates

                                           are pending.


";


        public static string FormatXMLForPowershell(string xml, bool forWebUse = false)
        {
            var sb = new StringBuilder();
            using (var reader = new XmlTextReader(xml, XmlNodeType.Element, null))
            {
                while (reader.Read())
                {
                    var type = reader.NodeType;
                    var name = reader.Name.ToLowerInvariant();
                    var value = reader.Value;

                    if (type == XmlNodeType.Element)
                    {
                        switch (name)
                        {
                            case "ul":
                            case "ol":
                                if (!forWebUse)
                                    sb.AppendLine();
                                else
                                    sb.AppendFormat("<{0}>", name);
                                break;

                            case "li":
                                if (!forWebUse)
                                {
                                    sb.AppendLine();
                                    sb.Append(" -");
                                }
                                else
                                    sb.AppendFormat("<{0}>", name);
                                break;

                            // very temp hack for ElastiCache in 2.3.5.0 release -- this is the only known set of table elements,
                            // we want them in web help but not maml docs
                            case "table":
                                if (!forWebUse)
                                {
                                    sb.Append(newAvailabilityZonesTableReplacement);
                                    do
                                    {
                                        reader.Read();
                                    } while (!reader.Name.Equals("table", StringComparison.OrdinalIgnoreCase));
                                }
                                else
                                    sb.AppendFormat("<{0}>", name);
                                break;

                            case "th":
                            case "tr":
                            case "td":
                            case "div":
                                if (forWebUse)
                                    sb.AppendFormat("<{0}>", name);
                                break;

                            case "dl":
                            case "dt":
                            case "dd":
                                if (forWebUse)
                                    sb.AppendFormat("<{0}>", name);
                                break;

                            case "strong":
                                if (forWebUse)
                                    sb.AppendFormat("<{0}>", name);
                                break;

                            case "pre":
                                if (forWebUse)
                                    sb.AppendFormat("<{0}>", name);
                                break;

                            case "link":
                            case "filename":
                            case "replaceable":
                            case "seealso":
                                break;

                            default:
                                if (!HandleElement(sb, reader, name, forWebUse))
                                {
                                    throw new InvalidOperationException("Unsupported node of type " + name + ". Full XML: " + xml);
                                }
                                break;
                        }
                    }
                    else if (type == XmlNodeType.EndElement)
                    {
                        switch (name)
                        {
                            case "li":
                                if (!forWebUse)
                                    sb.AppendLine();
                                else
                                    sb.AppendFormat("</{0}>", name);
                                break;

                            case "ul":
                            case "ol":
                                if (!forWebUse)
                                {
                                    sb.AppendLine();
                                    sb.AppendLine();
                                }
                                else
                                    sb.AppendFormat("</{0}>", name);
                                break;

                            // very temp hack for ElastiCache in 2.3.5.0 release -- this is the only known set of table elements,
                            // we want them in web help but not maml docs
                            case "table":
                                if (forWebUse)
                                    sb.AppendFormat("</{0}>", name);
                                break;

                            case "th":
                            case "tr":
                            case "td":
                            case "div":
                                if (forWebUse)
                                    sb.AppendFormat("</{0}>", name);
                                break;

                            case "dl":
                            case "dt":
                            case "dd":
                                if (forWebUse)
                                    sb.AppendFormat("</{0}>", name);
                                break;

                            case "strong":
                                if (forWebUse)
                                    sb.AppendFormat("</{0}>", name);
                                break;

                            case "pre":
                                if (forWebUse)
                                    sb.AppendFormat("</{0}>", name);
                                break;

                            case "link":
                            case "filename":
                            case "replaceable":
                            case "seealso":
                                break;

                            default:
                                if (!HandleEndElement(sb, name, forWebUse))
                                {
                                    throw new InvalidOperationException("Unsupported node of type " + name +
                                                                        ". Full XML: " + xml);
                                }
                                break;
                        }
                    }
                    else if (type == XmlNodeType.Text)
                    {
                        sb.Append(System.Net.WebUtility.HtmlEncode(value));
                    }
                }

                string composed = sb.ToString();
                string final = DocumentationUtils.ProcessLines(composed, l => l, compressConsequitiveNonemptyLines: true, compressConsequitiveEmptyLines: true, skipEmptyLines: true);
                return final;
            }
        }

        private static bool HandleElement(StringBuilder sb, XmlTextReader reader, string name, bool forWebUse)
        {
            if (XMLNodesToCopyAsIs.Contains(name) || XMLNodesToRemove.Contains(name))
            {
                using (var subReader = reader.ReadSubtree())
                {
                    var doc = new XmlDocument();
                    doc.Load(subReader);
                    var el = doc.DocumentElement;
                    if (!XMLNodesToRemove.Contains(name))
                    {
                        sb.Append(el.OuterXml);
                    }
                }
            }
            //else if (XMLNodesToIgnore.Contains(name))
            //{
            //    sb.AppendFormat("<{0}>", name);
            //}
            else if (XMLNodesToNewline.Contains(name))
            {
                if (!forWebUse)
                    sb.AppendLine();
            }
            else
            {
                return false;
            }
            return true;
        }
        private static bool HandleEndElement(StringBuilder sb, string name, bool forWebUse)
        {
            //if (XMLNodesToIgnore.Contains(name))
            //{
            //    sb.AppendFormat("</{0}>", name);
            //}
            if (XMLNodesToNewline.Contains(name))
            {
                if (!forWebUse)
                    sb.AppendLine();
            }
            else
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Documentation methods

        public static string CommentDocumentation(string documentation)
        {
            using (var writer = new StringWriter())
            {
                string commentedDocs = ProcessLines(documentation, l => "/// " + l);

                writer.WriteLine("/// <summary>");
                writer.WriteLine(commentedDocs);
                writer.Write("/// </summary>");

                string formattedDocumentation = writer.ToString();
                return formattedDocumentation;
            }
        }
        public static string GetTypeDocumentation(Type type, XmlDocument documentationSource)
        {
            string raw = GetRawTypeDocumentation(type, documentationSource);
            string clean = CleanseSDKTypeDocumentation(raw);
            return clean;
        }
        public static string GetMethodDocumentation(Type declaringType, string methodName, XmlDocument documentationSource)
        {
            string raw = GetRawMethodDocumentation(declaringType, methodName, documentationSource);
            string clean = CleanseSDKTypeDocumentation(raw);
            return clean;
        }
        public static string GetPropertyDocumentation(Type declaringType, string propertyName, XmlDocument documentationSource)
        {
            string raw = GetRawPropertyDocumentation(declaringType, propertyName, documentationSource);
            string clean = CleanseSDKTypeDocumentation(raw);
            return clean;
        }
        public static string ProcessLines(string text, Func<string, string> action, bool compressConsequitiveNonemptyLines = false, bool compressConsequitiveEmptyLines = false, bool skipEmptyLines = false)
        {
            var garbageChars = new char[]
            {
                '\u2028'
            };

            var builder = new StringBuilder();
            IEnumerable<string> lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            // remove leading and trailing empty lines (Reverse lines, SkipWhile empty, Reverse again)
            lines = lines.SkipWhile(s => string.IsNullOrEmpty(s.Trim())).Reverse().SkipWhile(s => string.IsNullOrEmpty(s.Trim())).Reverse();

            if (compressConsequitiveNonemptyLines)
                lines = CompressConsequitiveNonemptyLines(lines);
            if (compressConsequitiveEmptyLines)
                lines = CompressConsequitiveEmptyLines(lines);

            lines = lines.ToList();
            foreach (var line in lines)
            {
                var newLine = action(line);
                if (newLine != null && !(skipEmptyLines && newLine.IsEmpty())) // skip only null lines: empty lines stay
                {
                    if (builder.Length > 0)
                        builder.AppendLine();

                    // strip out any garbage characters that occur from time to time
                    foreach (var c in garbageChars)
                    {
                        newLine = newLine.Replace(c, ' ');
                    }
                    builder.Append(newLine);
                }
            }

            string formattedLines = builder.ToString();
            return formattedLines;
        }

        /// <summary>
        /// Caches documentation associated with an AWS assembly dll.
        /// GetRawTypeDocumentation, GetRawPropertyDocumentation are much faster when using this cache compared to Xpath queries
        /// </summary>
        public static void CacheMemberDocumentationSummary(XmlDocument documentationSource)
        {
            _memberDocumentationSummaryCache.Clear();
            var members = documentationSource.SelectNodes("doc/members/member");
            if (members != null)
            {
                foreach (XmlNode member in members)
                {
                    var nameAttr = member.Attributes?["name"];
                    if (nameAttr != null)
                    {
                        var summary = member.SelectSingleNode("summary");
                        _memberDocumentationSummaryCache[nameAttr.Value] = summary?.InnerXml;
                    }
                }
            }
        }
        #endregion

        #region Private methods

        private static string GetRawTypeDocumentation(Type type, XmlDocument documentationSource)
        {
            string typeFullName = type.FullName.Replace('+', '.');
            string key = "T:" + typeFullName;

            string xpath = string.Format("doc/members/member[@name='T:{0}']", typeFullName);

            if (_memberDocumentationSummaryCache.TryGetValue(key, out var cachedSummary))
            {
                if (cachedSummary == null)
                    throw new InvalidOperationException(string.Format(
                        "Unable to find summary node for type {0}, expected at xpath {1}/summary",
                        type.FullName, xpath));
                return cachedSummary;
            }

            Console.WriteLine("NO SDK DOCUMENTATION PRESENT FOR TYPE {0}, expected at xpath {1}", type.FullName, xpath);
            // emit just the name into help; the shouty warning looks bad
            return type.FullName;
        }
        private static string GetRawPropertyDocumentation(Type declaringType, string propertyName, XmlDocument documentationSource)
        {
            string propertyFullName = declaringType.FullName.Replace('+', '.') + "." + propertyName;
            string key = "P:" + propertyFullName;
            string xpath = string.Format("doc/members/member[@name='P:{0}']", propertyFullName);


            if (_memberDocumentationSummaryCache.TryGetValue(key, out var cachedSummary))
            {
                if (cachedSummary == null)
                    throw new InvalidOperationException(string.Format(
                        "Unable to find documentation for property {0} of type {1}, expected at xpath {2}/summary",
                        propertyName, declaringType.FullName, xpath));
                return cachedSummary;
            }

            // emit just the name into help unless its a pagination property we
            // recognise; the shouty warning looks bad
            return SubstituteParameterDocumentation.GetValueOrDefault(propertyName, propertyFullName);
        }
        private static string GetRawMethodDocumentation(Type declaringType, string methodName, XmlDocument documentationSource)
        {
            string methodFullName = declaringType.FullName.Replace('+', '.') + "." + methodName;
            string xpath = string.Format("doc/members/member[starts-with(@name, 'M:{0}Async(')]", methodFullName);
            var docNode = documentationSource.SelectSingleNode(xpath);
            if (docNode == null)
            {
                // emit just the name into help; the shouty warning looks bad
                return methodFullName;
            }
            var summary = docNode.SelectSingleNode("summary");
            if (summary == null)
                throw new InvalidOperationException(string.Format(
                    "Unable to find documentation for property {0} of type {1}, expected at xpath {2}/summary",
                    methodName, declaringType.FullName, xpath));
            string xml = summary.InnerXml;
            return xml;
        }

        private static IEnumerable<string> CompressConsequitiveEmptyLines(IEnumerable<string> lines)
        {
            int lastLineLength = 0;
            foreach (var line in lines)
            {
                int lineLength = line == null ? 0 : line.Trim().Length;
                if (lineLength > 0 || lastLineLength > 0)
                {
                    if (lineLength == 0)
                        yield return string.Empty;
                    else
                        yield return line;
                }
                lastLineLength = lineLength;
            }
        }
        private static IEnumerable<string> CompressConsequitiveNonemptyLines(IEnumerable<string> lines)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var line in lines)
            {
                if (line.IsEmpty())
                {
                    if (builder.Length > 0)
                    {
                        yield return builder.ToString();
                        builder.Clear();
                    }

                    yield return line;
                }
                else
                {
                    builder.AppendFormat("{0} ", line);
                }
            }

            if (builder.Length > 0)
                yield return builder.ToString();
        }

        private static bool IsEmpty(this string self)
        {
            if (string.IsNullOrEmpty(self))
                return true;
            if (string.IsNullOrEmpty(self.Trim()))
                return true;
            return false;
        }

        #endregion
    }
}