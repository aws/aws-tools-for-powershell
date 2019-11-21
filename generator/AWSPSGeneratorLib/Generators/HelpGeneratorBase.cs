using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Xml;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.Utils;
using AWSPowerShellGenerator.Writers.Help;

namespace AWSPowerShellGenerator.Generators
{
    public abstract class HelpGeneratorBase : Generator
    {
        #region Public properties

        public Assembly CmdletAssembly { get; set; }
        public XmlDocument AssemblyDocumentation { get; set; }
        public string Name { get; set; }

        #endregion

        public const string WebApiReferenceBaseUrl = "http://docs.aws.amazon.com/powershell/latest/reference";

        protected List<Type> CmdletTypes;

        // keyed by cmdlet name
        protected Dictionary<string, XmlDocument> ExamplesCache;

        protected Dictionary<string, XmlDocument> LinksCache;

        protected Type DynamicParamsType;

        protected List<CmdletAttribute> CmdletAttributes; // should actually only be one
        protected Attribute AWSCmdletAttribute;
        protected List<Attribute> AWSCmdletOutputAttributes;

        // lists cmdlets where we want to expose the dynamic parameters based on the 
        // AWSCredentialsArguments or AWSRegionArguments types as first-class parameters
        // for the cmdlet
        const string AWSCredentialsArgumentsFullTypename = "Amazon.PowerShell.Common.AWSCredentialsArgumentsFull";
        const string AWSRegionArgumentsTypename = "Amazon.PowerShell.Common.AWSRegionArguments";

        private readonly List<string> _dynamicParameterCmdlets = new List<string>
        {
            "Amazon.PowerShell.Common.SetCredentialCmdlet",
            "Amazon.PowerShell.Common.NewCredentialCmdlet",
            "Amazon.PowerShell.Common.SetDefaultRegionCmdlet",
            "Amazon.PowerShell.Common.InitializeDefaultConfigurationCmdlet",
        };

        // matchs same collection in the sdk, where we shorten paths to avoid issues with
        // Windows path lengths
        public static Dictionary<string, string> ServiceNamespaceContractions = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"ElasticLoadBalancing", "ELB"},
            {"ElasticBeanstalk", "EB"},
            {"ElasticMapReduce", "EMR"},
            {"ElasticTranscoder", "ETS"},
            {"SimpleNotificationService", "SNS"},
            {"IdentityManagement", "IAM"},
            {"DatabaseMigrationService", "DMS"},
            {"ApplicationDiscoveryService", "ADS"},
            {"SimpleSystemsManagement", "SSM"},
        };

        protected override void GenerateHelper()
        {
            var psCmdletType = typeof(PSCmdlet);
            DynamicParamsType = typeof(IDynamicParameters);
            CmdletTypes = CmdletAssembly.GetTypes()
                .Where(t => psCmdletType.IsAssignableFrom(t) && t.IsPublic && !t.IsAbstract)
                .ToList();

            LoadExamplesCache();
            LoadLinksCache();
        }

        protected void InspectCmdletAttributes(Type cmdletType)
        {
            var customAttributes = cmdletType.GetCustomAttributes(true).Cast<Attribute>();

            CmdletAttributes =
                customAttributes.Select(att => att as CmdletAttribute).Where(catt => catt != null).ToList();

            AWSCmdletAttribute =
                customAttributes.FirstOrDefault(
                    att => string.Equals(att.GetType().FullName, "Amazon.PowerShell.Common.AWSCmdletAttribute",
                        StringComparison.Ordinal));

            AWSCmdletOutputAttributes = customAttributes
                .Where(att => att.GetType().FullName == "Amazon.PowerShell.Common.AWSCmdletOutputAttribute")
                .ToList();
        }

        private void LoadExamplesCache()
        {
            var examplesPath = Path.Combine(Options.RootPath, "generator", "AWSPSGeneratorLib", "HelpMaterials", "Examples");
            Console.WriteLine("Loading example files from {0}", Path.GetFullPath(examplesPath));

            ExamplesCache = new Dictionary<string, XmlDocument>();
            var serviceSubFolders = Directory.GetDirectories(examplesPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var serviceFolder in serviceSubFolders)
            {
                var exampleFiles = Directory.GetFiles(serviceFolder, "*.xml");
                foreach (var exampleFile in exampleFiles)
                {
                    var document = new XmlDocument {PreserveWhitespace = true};
                    document.Load(exampleFile);
                    var cmdletName = Path.GetFileNameWithoutExtension(exampleFile);
                    ExamplesCache[cmdletName] = document;
                    Console.WriteLine("...loaded examples for {0}", cmdletName);
                }
            }

            Console.WriteLine();
        }

        private void LoadLinksCache()
        {
            var linkLibrariesPath = Path.Combine(Options.RootPath, "generator", "AWSPSGeneratorLib", "HelpMaterials", "LinkLibraries");
            Console.WriteLine("Loading link files from {0}", Path.GetFullPath(linkLibrariesPath));

            LinksCache = new Dictionary<string, XmlDocument>();
            var linkFiles = Directory.GetFiles(linkLibrariesPath, "*.xml");
            foreach (var linkFile in linkFiles)
            {
                if (Path.GetFileNameWithoutExtension(linkFile).Equals("Template", StringComparison.OrdinalIgnoreCase))
                    continue;

                var document = new XmlDocument {PreserveWhitespace = true};
                document.Load(linkFile);
                var servicePrefix = Path.GetFileNameWithoutExtension(linkFile);
                LinksCache[servicePrefix] = document;
                Console.WriteLine("...loaded links library for {0}", servicePrefix);
            }

            Console.WriteLine();
        }

        protected XmlNodeList GetRelatedLinks(XmlDocument document, string target)
        {
            var xpath = string.Format("links/set[@target='{0}']", target);
            var set = document.SelectSingleNode(xpath);
            if (set == null)
            {
                Console.WriteLine("Unable to find related links for target {0} in service {1}, probed xpath {2}", target,
                    document.Name, xpath);
                return null;
            }

            // to allow easier management over time of the link files, filter out sets who don't yet have
            // content but are present simply as templates, that way we don't need to comment out sections
            // of the file
            var firstLink = set.FirstChild;
            if (firstLink == null || string.IsNullOrEmpty(firstLink.InnerText))
            {
                Console.WriteLine("Skipping empty link set for target {0} in {1}", target, document.Name);
                return null;
            }


            return set.SelectNodes("link");
        }

        private const string namespacePrefix = "Amazon.PowerShell.Cmdlets.";
        private const string commonCmdletsNamespace = "Amazon.PowerShell.Common";

        protected string GetServiceAbbreviation(Type cmdletType)
        {
            string ns = cmdletType.Namespace;
            if (string.Equals(ns, commonCmdletsNamespace, StringComparison.OrdinalIgnoreCase))
                return "Common";
            if (ns.IndexOf(namespacePrefix) != 0)
            {
                Logger.LogError("Cmdlet namespace \"{0}\" does not contain expected namespace prefix \"{1}\"", ns,
                    namespacePrefix);
                return null;
            }
            ns = ns.Substring(namespacePrefix.Length);
            var components = ns.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
            return components[0];
        }

        private static IEnumerable<object> RecursiveGetCustomAttributes(Type type)
        {
            while (type != null)
            {
                foreach (var attribute in type.GetCustomAttributes())
                {
                    yield return attribute;
                }
                type = type.BaseType;
            }
        }

        protected static (string ModuleName, string ServiceName) DetermineCmdletServiceOwner(Type cmdletType)
        {
            dynamic attribute = RecursiveGetCustomAttributes(cmdletType).Where(attr => attr.GetType().FullName == "Amazon.PowerShell.Common.AWSClientCmdletAttribute").SingleOrDefault();

            if (attribute != null)
            {
                return (attribute.ModuleName, attribute.ServiceName);
            }

            // nope, declare it as a misc cmdlet
            return ("Common", TOCWriter.CommonTOCName);
        }

        protected IEnumerable<SimplePropertyInfo> GetRootSimpleProperties(Type requestType)
        {
            var properties = requestType
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .ToList();

            // mix in any parameters added dynamically to specific cmdlets (this way we don't spam all cmdlets
            // with credential parameters) yet still show the actual params where the user needs to see them
            if (_dynamicParameterCmdlets.Contains(requestType.FullName))
            {
                // create an instance of the cmdlet itself
                var cmdletInstance = Activator.CreateInstance(requestType);
                // assume it implements IDynamicParameters and get the dynamic parameters object
                var dynamicParamsObject = (cmdletInstance as IDynamicParameters)?.GetDynamicParameters();

                if (dynamicParamsObject != null)
                {
                    properties.AddRange(
                        dynamicParamsObject.GetType()
                            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(dynamicParamsProperty => dynamicParamsProperty
                                .GetCustomAttributes(false)
                                .Any(ca => ca.GetType() == typeof(ParameterAttribute))));
                }
            }

            var simpleProperties = properties
                .Select(p => CreateSimpleProperty(p, null))
                .Where(sp => sp.IsReadWrite)
                .OrderBy(sp => sp.ParameterPosition)
                .ToList();

            return simpleProperties;
        }

        protected static void InspectParameter(SimplePropertyInfo property, out HashSet<string> isRequiredForParameterSets,
            out string pipelineInput, out string position, out string[] aliases)
        {
            pipelineInput = "False";
            position = "Named";
            aliases = new string[0];

            // 'Required? true | false'
            isRequiredForParameterSets = property.IsRequiredForParameterSets;

            if (property.PsParameterAttribute == null)
                return;

            // 'Accept pipeline input?       true ([ByValue,] [ByPropertyName]) | false'
            var markedValueFromPipeline = IsMarkedValueFromPipeline(property.PsParameterAttribute);
            var markedValueFromPropertyName = IsMarkedValueFromPipelineByName(property.PsParameterAttribute);

            if (markedValueFromPipeline | markedValueFromPropertyName)
            {
                pipelineInput = string.Format("True ({0}{1}{2})",
                    markedValueFromPipeline ? "ByValue" : "",
                    markedValueFromPipeline && markedValueFromPropertyName ? ", " : "",
                    markedValueFromPropertyName ? "ByPropertyName" : "");
            }

            // 'Position named | ordinal'. Shell convention is to start indexing at 1, but we
            // start at 0 internally.
            var pos = HasPositionalData(property.PsParameterAttribute);
            if (pos >= 0)
                position = (pos + 1).ToString(CultureInfo.InvariantCulture);

            if (property.PsAliasAttribute != null)
            {
                aliases = property.PsAliasAttribute.AliasNames.ToArray();
            }
        }

        protected static bool IsMarkedValueFromPipeline(IEnumerable<ParameterAttribute> parameterAttributes)
        {
            // todo: need to confirm how built-in pshell help handles parameters
            // that are pipelinable in one set, not in another. For now, we scann
            // all sets
            var isMarked = false;
            if (parameterAttributes != null)
            {
                foreach (var pa in parameterAttributes)
                {
                    if (pa.ValueFromPipeline)
                        isMarked = true;
                }
            }

            return isMarked;
        }

        protected static bool IsMarkedValueFromPipelineByName(IEnumerable<ParameterAttribute> parameterAttributes)
        {
            // todo: need to confirm how built-in pshell help handles parameters
            // that are assignable in one set, not in another. For now, we scann
            // all sets
            var isMarked = false;
            if (parameterAttributes != null)
            {
                foreach (var pa in parameterAttributes)
                {
                    if (pa.ValueFromPipelineByPropertyName)
                        isMarked = true;
                }
            }

            return isMarked;
        }

        protected static int HasPositionalData(IEnumerable<ParameterAttribute> parameterAttributes)
        {
            // todo: need to confirm how built-in pshell help handles parameters
            // that have a position in one set, not in another. For now, we scann
            // all sets
            if (parameterAttributes != null)
            {
                foreach (var pa in parameterAttributes)
                {
                    if (pa.Position >= 0)
                        return pa.Position;
                }
            }

            return -1;
        }

        private SimplePropertyInfo CreateSimpleProperty(PropertyInfo property, SimplePropertyInfo parent)
        {
            var propertyTypeName = GetValidTypeName(property.PropertyType);
            var simpleProperty = new SimplePropertyInfo(property, parent, propertyTypeName, AssemblyDocumentation);
            return simpleProperty;
        }

        private string GetValidTypeName(Type type)
        {
            if (type.IsArray)
                return GetValidTypeName(type.GetElementType()) + "[]";
            
            if (type.IsGenericType)
            {
                var genericArguments = type.GetGenericArguments();
                var genericType = type.GetGenericTypeDefinition();

                if (genericType.IsAssignableFrom(typeof(List<>)))
                    return string.Format("List<{0}>", GetValidTypeName(genericArguments[0]));
                
                if (genericType.IsAssignableFrom(typeof(IEnumerable<>)))
                    return string.Format("IEnumerable<{0}>", GetValidTypeName(genericArguments[0]));
                
                if (genericType.IsAssignableFrom(typeof(Dictionary<,>)))
                    return string.Format("Dictionary<{0}, {1}>", GetValidTypeName(genericArguments[0]), GetValidTypeName(genericArguments[1]));
                
                if (string.Equals(genericType.FullName, "Amazon.S3.Model.Tuple`2", StringComparison.Ordinal))
                    return string.Format("Tuple<{0}, {1}>", GetValidTypeName(genericArguments[0]), GetValidTypeName(genericArguments[1]));

                if (genericType.IsAssignableFrom(typeof(Nullable<>)))
                    return string.Format("{0}", GetValidTypeName(genericArguments[0]));

                Logger.LogError("Can't determine generic type. Type = [{0}], GenericType = [{1}]", type.FullName, genericType.FullName);
                return null;
            }

            return type.Namespace + "." + type.Name;
        }

        public static string GetTypeDisplayName(Type propertyType, bool useFullName, bool stripNullable = true)
        {
            string name;
            if (propertyType.IsGenericParameter)
                name = propertyType.Name;
            else if (propertyType.IsGenericType)
            {
                if (stripNullable && propertyType.FullName.StartsWith("System.Nullable`"))
                {
                    return GetTypeDisplayName(propertyType.GetGenericArguments()[0], useFullName, false);
                }

                var baseName = useFullName ? propertyType.FullName : propertyType.Name;
                var pos = baseName.IndexOf('`');
                baseName = baseName.Substring(0, pos);

                var paramCount = propertyType.GetGenericArguments().Length;

                var pars = new StringBuilder();
                if (propertyType.IsGenericTypeDefinition)
                {
                    if (paramCount == 1)
                        pars.Append("T");
                    else
                    {
                        for (var i = 1; i <= paramCount; i++)
                        {
                            if (pars.Length > 0)
                                pars.Append(", ");

                            pars.AppendFormat("T{0}", i);
                        }
                    }
                }
                else
                {
                    foreach (var t in propertyType.GetGenericArguments())
                    {
                        if (pars.Length > 0)
                            pars.Append(", ");
                        pars.AppendFormat(GetTypeDisplayName(t, useFullName, false));
                    }
                }

                name = string.Format("{0}&lt;{1}&gt;", baseName, pars.ToString());
            }
            else
                name = useFullName ? propertyType.FullName : propertyType.Name;

            if (name == null)
                throw new ApplicationException(string.Format("Failed to resolve display for type {0}", propertyType.ToString()));

            return name;
        }
    }

    internal static class XmlWriterExtensions
    {
        public static void WriteUnescapedElementString(this XmlTextWriter self, string localName, string value)
        {
            if (self == null) throw new ArgumentNullException("self");

            self.WriteStartElement(localName);
            var escapedString = EscapeString(value);
            self.WriteRaw(escapedString);
            self.WriteEndElement();
        }

        public static void WriteRawElementString(this XmlTextWriter self, string localName, string value)
        {
            if (self == null) throw new ArgumentNullException("self");

            self.WriteStartElement(localName);
            self.WriteRaw(value);
            self.WriteEndElement();
        }

        private static string EscapeString(string value)
        {
            StringBuilder sb = new StringBuilder(value);
            sb.Replace("&", "&amp;");
            return sb.ToString();
        }
    }

    /// <summary>
    /// Class handling the partitioning of parameters into one or more parameter sets.
    /// At doc generation time, we use construct an instance per cmdlet and allow it
    /// to partition the declared parameters based on the presence or absence of a 
    /// parameter set declaration. We then use the instance to generate set-specific
    /// syntax diagrams in the native and web help materials.
    /// </summary>
    internal class CmdletParameterSetPartitions
    {
        public CmdletParameterSetPartitions(IEnumerable<SimplePropertyInfo> parameters, string defaultParameterSetName)
        {
            Parameters = parameters;
            DefaultParameterSetName = defaultParameterSetName;
            ParameterSets = PartitionParametersBySet();
        }

        /// <summary>
        /// The flat list of all parameters declared for a cmdlet.
        /// </summary>
        public IEnumerable<SimplePropertyInfo> Parameters { get; private set; }

        /// <summary>
        /// Name of the default parameter set for a cmdlet. If the cmdlet does not partition
        /// parameters into sets (ie has one global set) this is null. When we return the 
        /// sets for a cmdlet that has custom sets we return the default set first.
        /// </summary>
        public string DefaultParameterSetName { get; private set; }

        /// <summary>
        /// The cmdlet parameter names grouped by parameter set. Parameters not defined
        /// as belonging to a custom set or sets are found in the __AllParameterSets set, 
        /// which is the first set in the collection.
        /// </summary>
        /// <remarks>
        /// As we generate syntax charts by walking the declared parameters on a cmdlet
        /// in order, we only need to store the parameter name here - a simple lookup
        /// by name as we traverse the Parameters collection is all that's required to
        /// determine presence/absence in a set.
        /// </remarks>
        public Dictionary<string, HashSet<string>> ParameterSets { get; private set; }

        /// <summary>
        /// True if custom named parameter sets were found.
        /// </summary>
        public bool HasNamedParameterSets
        {
            get { return ParameterSets.Keys.Count > 1; }
        }

        /// <summary>
        /// Returns the collection of custom named parameter sets. The default set name
        /// is always the first in the returned collection.
        /// </summary>
        public IEnumerable<string> NamedParameterSets
        {
            get
            {
                if (!HasNamedParameterSets)
                    throw new InvalidOperationException("Cannot query custom named parameter sets when none exist");

                var l = new List<string>();

                if (!string.IsNullOrEmpty(DefaultParameterSetName))
                    l.Add(DefaultParameterSetName);

                foreach (var k in ParameterSets.Keys)
                {
                    if (k.Equals(AllSetsKey, StringComparison.Ordinal))
                        continue;

                    if (k.Equals(DefaultParameterSetName, StringComparison.Ordinal))
                        continue;

                    l.Add(k);
                }

                return l;
            }
        }

        /// <summary>
        /// Returns the collection of parameter names defined as belonging to the specified
        /// set. For syntax diagrams we also want the all parameters defined as belonging
        /// to the 'all sets' set.
        /// </summary>
        /// <param name="setName"></param>
        /// <param name="appendAllSets"></param>
        /// <returns></returns>
        public HashSet<string> ParameterNamesForSet(string setName, bool appendAllSets)
        {
            if (!ParameterSets.ContainsKey(setName))
                throw new ArgumentException("Parameter set is unknown: " + setName, setName);

            var parameters = new HashSet<string>(ParameterSets[setName]);
            if (appendAllSets && !setName.Equals(AllSetsKey, StringComparison.Ordinal))
            {
                var allSets = ParameterSets[AllSetsKey];
                parameters.UnionWith(allSets);
            }

            return parameters;
        }

        private Dictionary<string, HashSet<string>> PartitionParametersBySet()
        {
            var partitions = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase)
            {
                { AllSetsKey, new HashSet<string>() }
            };

            if (!string.IsNullOrEmpty(DefaultParameterSetName))
                partitions.Add(DefaultParameterSetName, new HashSet<string>());

            foreach (var p in Parameters)
            {
                if (p.PsParameterAttribute == null || p.PsParameterAttribute.Length == 0)
                    continue;

                foreach (var pa in p.PsParameterAttribute)
                {
                    if (pa.ParameterSetName.Equals(AllSetsKey))
                    {
                        partitions[AllSetsKey].Add(p.CmdletParameterName);
                    }
                    else
                    {
                        HashSet<string> parameterNames;
                        if (partitions.ContainsKey(pa.ParameterSetName))
                            parameterNames = partitions[pa.ParameterSetName];
                        else
                        {
                            parameterNames = new HashSet<string>();
                            partitions.Add(pa.ParameterSetName, parameterNames);
                        }

                        parameterNames.Add(p.CmdletParameterName);
                    }
                }
            }

            return partitions;
        }

        // The set name used in PowerShell to contain parameters that are not
        // marked as belonging to a particular set (or sets). This also covers
        // the scenario when no parameter sets are declared for a cmdlet.
        public const string AllSetsKey = "__AllParameterSets";
    }
}
