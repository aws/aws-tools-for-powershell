using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Data.Entity.Design;
using System.Xml;
using PowerShellGenLib.CmdletConfig;
using PowerShellGenLib.Generators;

namespace PowerShellGenLib.Utils
{
    /// <summary>
    /// Analyzes the properties on the request for an operation to determine
    /// the set of parameters that should be added to a cmdlet. The inspection
    /// performs name flattening (for nested request properties), shortening
    /// (to avoid excessively long flattened names) and last-word-fragment
    /// singularization (to follow community convention). Note that if the service 
    /// operation contains parameter customization, this turns off the automatic 
    /// analysis.
    /// </summary>
    internal class ParametersInspector
    {
        public ConfigModelCollection AllModels { get; set; }
        public ConfigModel CurrentModel { get; set; }
        public ServiceOperation CurrentOperation { get; set; }
        public BasicLogger Logger { get; set; }
        public XmlDocument AssemblyDocumentation { get; set; }

        private PluralizationService Pluralization { get; set; }

        /// <summary>
        /// The set of properties to be emitted as cmdlet parameters. Members of complex
        /// properties are flattened to individual parameters.
        /// </summary>
        public List<SimplePropertyInfo> AnalyzedParameters { get; private set; }

        /// <summary>
        /// The set of actual properties the cmdlet needs to deal with to populate
        /// a service request. Complex types are not flattened here.
        /// </summary>
        public List<SimplePropertyInfo> RequestProperties { get; private set; }

        /// <summary>
        /// Terminating word fragments shorter than this will not be made singular
        /// </summary>
        private const int MinLengthForSingularization = 3;

        /// <summary>
        /// Collection of terminating word fragments to retain as-is or manually
        /// update (for cases where the pluralization service gets it wrong).
        /// If the value for a key is empty, we do not alter the fragment otherwise
        /// we replace the fragment with a new value.
        /// </summary>
        private readonly Dictionary<string, string> _manualFragmentRenames = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "Data", null },           // pluralization turns it to 'Datum'
            { "Cookies", "Cookie" },    // pluralization service yields 'Cooky' 
            { "Iops", null },           // pluralization yields Iop
        };

        private string RenameLogfile { get; set; }

        public ParametersInspector(string renamesLog)
        {
            // doesn't appear to be a costly operation, so init per instance for now
            Pluralization = PluralizationService.CreateService(CultureInfo.CurrentCulture);
            RenameLogfile = renamesLog;
        }

        /// <summary>
        /// If true, the cmdlet parameters/request type contain properties corresponding
        /// to the autoiteration configuration settings in this model, so result iteration
        /// code needs to be emitted.
        /// </summary>
        public bool GenerateIterationCode { get; private set; }

        /// <summary>
        /// Analyzes the properties in the operation's request class to arrive at the
        /// set of parameters to be output for the cmdlet. The set, on output, will
        /// contain only the parameters to be generated complete with the final names
        /// and any relevant aliases (for backwards compatibility or so configured)
        /// attached the service operations parameter aliases maps.
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="responseType"></param>
        public void Analyze(Type requestType, Type responseType)
        {
            // first analyze the request members to get a flattened set of all
            // properties
            var allProperties = GetFlatProperties(requestType).ToList();

            // remove excluded properties, if any, from the flattened set
            var nonExcludedProperties 
                = allProperties.Where(prop => !IsExcludedParameter(prop.AnalyzedName, CurrentModel, CurrentOperation)).ToList();
            if (allProperties.Count > nonExcludedProperties.Count)
            {
                Console.WriteLine("Properties being removed, service = {0}, op = {1}",
                                    CurrentModel.ServiceNounPrefix,
                                    CurrentOperation.MethodName);
                allProperties = nonExcludedProperties;
            }

            // the remainder will now be the cmdlet parameters, on which we will detect autoiteration
            // and do some name shortening/singularization
            AnalyzedParameters = new List<SimplePropertyInfo>(allProperties);
            
            GenerateIterationCode = AutoIterateInspector.IsAutoIterable(CurrentModel.AutoIterate,
                                                                        CurrentOperation.MethodName,
                                                                        AnalyzedParameters,
                                                                        responseType);
            
            FinalizeParameterNames();

            // also gather the internal root (non-flattened) properties -- these are what the
            // cmdlet will bind the parameters to in the executor
            var rootProperties = GetRootSimpleProperties(requestType)
                                    .Where(simpleProperty => !IsExcludedParameter(simpleProperty.AnalyzedName, CurrentModel, CurrentOperation))
                                    .ToList();
            RequestProperties = new List<SimplePropertyInfo>(rootProperties);

            LogRenamedParameters();
        }

        /// <summary>
        /// Analyze the supplied properties to arrive at the final name that should be used.
        /// Names can be forced via configuration entries or by automatic analysis. Automatic
        /// analysis can shorten flattened structure names to just one _ component and make
        /// the final word fragment singular.
        /// </summary>
        private void FinalizeParameterNames()
        {
            // used to report collisions when we rename parameters
            var processedParameters = new Dictionary<string, SimplePropertyInfo>(StringComparer.Ordinal);

            // possible scenarios:
            //   param Name="foo" Alias="baz"                      => add alias, also auto-rename
            //   param Name="foo" Exclude="true"                   => do not emit parameter
            //   param Name="foo" NewName="bar"                    => rename param, no alias
            //   param Name="foo" NewName="bar" Alias="baz"        => rename param with alias
            //   param Name="foo" AutoRename="false"               => do not rename param
            //   param Name="foo" AutoRename="false" Alias="baz"   => do not rename but add alias

            foreach (var property in AnalyzedParameters)
            {
                var attemptAutoRename = true;
                var parameterCustomization = GetParameterCustomization(property.AnalyzedName);
                if (parameterCustomization != null)
                {
                    // wire up the analyzed parameter with its config customization - this
                    // is the earliest opportunity to do this
                    property.Customization = parameterCustomization;

                    if (parameterCustomization.Exclude)
                        continue;

                    if (!string.IsNullOrEmpty(parameterCustomization.NewName))
                    {
                        RecordParameterRename(property, 
                                              parameterCustomization.NewName,
                                              processedParameters);
                        attemptAutoRename = false;
                    }
                    else 
                        attemptAutoRename = parameterCustomization.AutoRename;
                }

                if (attemptAutoRename)
                {
                    // inspect the name to determine if it can be reduced in length if we flattened a deep
                    // property hierarchy
                    var alternateName = property.AnalyzedName;
                    var underscores = property.AnalyzedName.Count(c => c == '_');
                    if (underscores > 1)
                        alternateName = RebaseNameToFinalParent(alternateName);

                    var attemptToSingularize = property.IsValidForSingularization;
                    if (attemptToSingularize)
                    {
                        string namePrefix;
                        string finalFragment;
                        SplitName(alternateName, out namePrefix, out finalFragment);
                        alternateName = finalFragment != null 
                            ? string.Concat(namePrefix, SingularizeTerm(finalFragment)) 
                            : SingularizeTerm(alternateName);
                    }

                    if (alternateName.Length != property.AnalyzedName.Length)
                    {
                        RecordParameterRename(property, 
                                              alternateName, 
                                              processedParameters);
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to convert the supplied term to singular form provided
        /// it exceeds minimum length limits, it not a term marked as needing
        /// to not be singularized and is actually plural. If the term cannot
        /// be modified, the original value is returned.
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        private string SingularizeTerm(string term)
        {
            if (term.Length >= MinLengthForSingularization)
            {
                if (_manualFragmentRenames.ContainsKey(term))
                {
                    var replacement = _manualFragmentRenames[term];
                    return replacement ?? term;
                }

                if (Pluralization.IsPlural(term))
                    return Pluralization.Singularize(term);
            }

            return term;
        }

        /// <summary>
        /// Returns the last parent_property name combination from the supplied name
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        private static string RebaseNameToFinalParent(string fullName)
        {
            var index = fullName.LastIndexOf('_') - 1;
            if (index < 0)
                return fullName;

            index = fullName.LastIndexOf('_', index);
            return fullName.Substring(index+1);
        }

        /// <summary>
        /// Splits the parameter name into a prefix and a final fragment, determined
        /// by the last uppercase letter. If the name does not split, finalFragment
        /// is null.
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="prefix"></param>
        /// <param name="finalFragment"></param>
        private static void SplitName(string fullName, out string prefix, out string finalFragment)
        {
            var index = fullName.Length - 1;
            while (index > 0 && !char.IsUpper(fullName[index]))
            {
                index--;
            }

            if (index > 0)
            {
                prefix = fullName.Substring(0, index);
                finalFragment = fullName.Substring(index);
            }
            else
            {
                prefix = fullName;
                finalFragment = null;
            }
        }

        /// <summary>
        /// Records that the supplied parameter needs to be renamed, after first checking
        /// that the proposed name does not conflict with any parameters processed so far.
        /// An alias mapping to the original name is applied, regardless of whether the
        /// name was remapped automatically or via the config file, unless the config file
        /// suppresses this using AutoApplyAlias="false" .
        /// </summary>
        /// <param name="property"></param>
        /// <param name="newName"></param>
        /// <param name="processedParameters"></param>
        private void RecordParameterRename(SimplePropertyInfo property, 
                                           string newName, 
                                           IDictionary<string, SimplePropertyInfo> processedParameters)
        {
            if (processedParameters.ContainsKey(newName))
            {
                var msg = new StringBuilder();
                msg.AppendFormat("Operation '{0}' has a duplicate parameter name {1}: ", CurrentOperation.MethodName, property.AnalyzedName);
                msg.AppendFormat(property.Customization != null && property.Customization.Origin == Param.CustomizationOrigin.FromConfig
                                    ? "config file requested '{0}' but that name used by '{1}'."
                                    : "auto-rename yielded '{0}' but that name used by '{1}'.", 
                                    newName,
                                    processedParameters[newName].AnalyzedName);

                Logger.LogError(msg.ToString());
                return;
            }

            processedParameters.Add(newName, property);

            var customization = property.Customization;
            if (customization == null)
            {
                customization = new Param
                {
                    Origin = Param.CustomizationOrigin.DuringGeneration, 
                    Name = property.AnalyzedName
                };
                property.Customization = customization;
            }
            else
            {
                // if the customization came from the config but did not
                // specify an alternate name, reset it to record the name
                // was constructed automatically (generation time code
                // relies on this to determine the context member name)
                if (string.IsNullOrEmpty(customization.NewName))
                    customization.Origin = Param.CustomizationOrigin.DuringGeneration;
            }

            customization.NewName = newName;

            if (customization.AutoApplyAlias)
            {
                var aliasList = customization.Aliases;
                aliasList.Add(property.AnalyzedName);
            }
        }

        private readonly Dictionary<Type, List<SimplePropertyInfo>> _rootSimplePropertiesCache = new Dictionary<Type, List<SimplePropertyInfo>>();

        private IEnumerable<SimplePropertyInfo> GetRootSimpleProperties(Type requestType)
        {
            List<SimplePropertyInfo> simpleProperties;
            if (!_rootSimplePropertiesCache.TryGetValue(requestType, out simpleProperties))
            {
                var properties = requestType.GetProperties();
                simpleProperties = properties
                    .Select(p => CreateSimpleProperty(p, null))
                    .Where(sp => sp.IsReadWrite)
                    .ToList();
                _rootSimplePropertiesCache[requestType] = simpleProperties;
            }
            return simpleProperties;
        }

        private readonly Dictionary<Type, List<SimplePropertyInfo>> _flatPropertiesCache = new Dictionary<Type, List<SimplePropertyInfo>>();

        private IEnumerable<SimplePropertyInfo> GetFlatProperties(Type requestType)
        {
            List<SimplePropertyInfo> flatProperties;
            if (!_flatPropertiesCache.TryGetValue(requestType, out flatProperties))
            {
                var properties = GetRootSimpleProperties(requestType);
                flatProperties = properties
                    .SelectMany(FlattenProperties)
                    .ToList();
                _flatPropertiesCache[requestType] = flatProperties;
            }
            return flatProperties;
        }

        private static IEnumerable<SimplePropertyInfo> FlattenProperties(SimplePropertyInfo property)
        {
            if (property.Children.Count > 0)
            {
                foreach (var child in property.Children)
                {
                    if (child.Children.Count == 0)
                    {
                        yield return child;
                    }
                    else
                    {
                        foreach (var flatProperty in FlattenProperties(child))
                            yield return flatProperty;
                    }
                }
            }
            else
            {
                yield return property;
            }
        }

        public SimplePropertyInfo CreateSimpleProperty(PropertyInfo property, SimplePropertyInfo parent)
        {
            var shouldFlatten = true;

            string propertyTypeFullName;
            var collectionType = SimplePropertyInfo.PropertyCollectionType.NoCollection;
            Type[] genericCollectionTypes = null;

            // determine if property should be flattened based solely on its type, or is a generic List<T> we
            // can replace with T[] to follow PS parameter convention
            if (property.PropertyType.IsGenericType)
            {
                // if the property is a generic List, it would be more pleasant for users, and
                // more in line with PS convention, to remap it here to an array type - something
                // to consider. The change would affect the parameter but not the inner context
                // and (of course) the request object property. It would affect help though.
                if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("List`"))
                {
                    genericCollectionTypes = property.PropertyType.GetGenericArguments();
                    collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericList;
                }
                else if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("Dictionary`"))
                {
                    genericCollectionTypes = property.PropertyType.GetGenericArguments();
                    collectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary;
                }

                propertyTypeFullName = property.PropertyType.GetGenericTypeDefinition().FullName;
            }
            else
                propertyTypeFullName = property.PropertyType.FullName;

            if (AllModels.TypesNotToFlatten.Contains(propertyTypeFullName, StringComparer.Ordinal))
                shouldFlatten = false;

            var propertyTypeName = GetPropertyTypeName(property.Name, 
                                                       property.PropertyType);
            var simpleProperty = new SimplePropertyInfo(property,
                                                        parent,
                                                        propertyTypeName,
                                                        AssemblyDocumentation,
                                                        collectionType,
                                                        genericCollectionTypes);

            if (shouldFlatten)
            {
                var propertyTypeProperties = property.PropertyType.GetProperties().Where(p =>
                {
                    // skip properties that aren't read/write
                    if (!p.CanWrite || !p.CanRead)
                        return false;
                    // skip index properties
                    if (p.GetIndexParameters().Length > 0)
                        return false;
                    return true;
                }).ToArray();

                if (propertyTypeProperties.Length > 0)
                {
                    foreach (var childProperty 
                        in propertyTypeProperties.Select(propertyTypeProperty
                            => CreateSimpleProperty(propertyTypeProperty, simpleProperty)))
                    {
                        simpleProperty.Children.Add(childProperty);
                    }
                }
            }
            return simpleProperty;
        }

        private string GetPropertyTypeName(string propertyName, Type type)
        {
            if (IsEmitLimiter(propertyName))
                return "int?";
            return GetValidTypeNameNullable(type);
        }

        private bool IsEmitLimiter(string propertyName)
        {
            return IsEmitLimiter(propertyName, CurrentModel.AutoIterate, CurrentOperation.MethodName);
        }

        public static bool IsEmitLimiter(string propertyName, AutoIteration autoIterationSettings, string methodName)
        {
            if (autoIterationSettings == null)
                return false;

            var shouldAutoIterate = !autoIterationSettings.ExclusionSet.Contains(methodName);
            var isEmitLimit = autoIterationSettings.IsEmitLimit(propertyName);
            var isEmitLimiter = shouldAutoIterate && isEmitLimit;
            return isEmitLimiter;
        }

        private string GetValidTypeNameNullable(Type type)
        {
            return GetValidTypeNameNullable(type, CurrentModel);
        }

        public static string GetValidTypeNameNullable(Type type, ConfigModel currentModel)
        {
            string name = GetValidTypeName(type, currentModel);
            if (ShouldMakeNullable(type))
                name = name + "?";
            return name;
        }

        public static string ToLowerCamelCase(string name)
        {
            var sb = new StringBuilder(name);
            sb[0] = char.ToLowerInvariant(sb[0]);
            return sb.ToString();
        }

        public static bool ShouldMakeNullable(Type type)
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

        /// <summary>
        /// Returns true if the parameter (identified by fully flattened name) is tagged as excluded
        /// at either the operation or model level.
        /// </summary>
        /// <param name="analyzedName"></param>
        /// <param name="model"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static bool IsExcludedParameter(string analyzedName, ConfigModel model, ServiceOperation operation)
        {
            if (model.ShouldExcludeParameter(analyzedName))
                return true;

            return operation.ShouldExcludeParameter(analyzedName);
        }

        /// <summary>
        /// Returns the closest available parameter customization, null if the
        /// parameter has not been customized
        /// </summary>
        /// <param name="analyzedName"></param>
        /// <returns></returns>
        public Param GetParameterCustomization(string analyzedName)
        {
            return GetParameterCustomization(analyzedName, CurrentModel, CurrentOperation);
        }

        /// <summary>
        /// Returns the closest available parameter customization, null if the
        /// parameter has not been customized
        /// </summary>
        /// <param name="analyzedName"></param>
        /// <param name="model"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static Param GetParameterCustomization(string analyzedName, ConfigModel model, ServiceOperation operation)
        {
            if (operation.CustomParameters.ContainsKey(analyzedName))
                return operation.CustomParameters[analyzedName];

            if (model.CustomParameters.ContainsKey(analyzedName))
                return model.CustomParameters[analyzedName];

            return null;
        }

        public static string GetValidTypeName(Type type, ConfigModel currentModel)
        {
            if (type.IsArray)
                return GetValidTypeName(type.GetElementType(), currentModel) + "[]";

            if (type.IsGenericType)
            {
                var genericArguments = type.GetGenericArguments();
                var genericType = type.GetGenericTypeDefinition();

                if (genericType.IsAssignableFrom(typeof(List<>)))
                    return string.Format("List<{0}>", GetValidTypeName(genericArguments[0], currentModel));
                
                if (genericType.IsAssignableFrom(typeof(IEnumerable<>)))
                    return string.Format("IEnumerable<{0}>", GetValidTypeName(genericArguments[0], currentModel));
                
                if (genericType.IsAssignableFrom(typeof(Dictionary<,>)))
                    return string.Format("Dictionary<{0}, {1}>",
                                         GetValidTypeName(genericArguments[0], currentModel), 
                                         GetValidTypeName(genericArguments[1], currentModel));
                
                if (genericType.FullName.Equals("Amazon.S3.Model.Tuple`2", StringComparison.Ordinal))
                    return string.Format("Tuple<{0}, {1}>",
                                         GetValidTypeName(genericArguments[0], currentModel), 
                                         GetValidTypeName(genericArguments[1], currentModel));
                
                if (genericType.IsAssignableFrom(typeof(Nullable<>)))
                    return string.Format("{0}?", GetValidTypeName(genericArguments[0], currentModel));

                throw new Exception(string.Format("Can't determine generic type. Type = [{0}], GenericType = [{1}]", type.FullName, genericType.FullName));
            }

            // test if the type is within the scope of the namespaces added to the cmdlet and if so,
            // return the non-namespaced type name (unless we have instruction to retain the fully qualified
            // name to avoid name collisions)
            string scopedName = string.Format("{0}.{1}", type.Namespace, type.Name);
            if (!currentModel.RetainFullTypeNames.Contains(scopedName, StringComparer.Ordinal))
            {
                if ((string.Compare(type.Namespace, currentModel.ServiceNamespace, StringComparison.Ordinal) == 0)
                        || (string.Compare(type.Namespace, currentModel.ServiceNamespace + ".Model", StringComparison.Ordinal) == 0)
                        || CmdletGenerator.DefaultNamespaces.Contains<string>(type.Namespace, StringComparer.Ordinal)
                        || currentModel.AdditionalNamespaces.Contains(type.Namespace, StringComparer.Ordinal))
                    return type.Name;
            }

            return scopedName;
        }

        void LogRenamedParameters()
        {
            if (string.IsNullOrEmpty(RenameLogfile))
                return;

            var operationBannerOutput = false;
            using (var writer = new StreamWriter(RenameLogfile, true))
            {
                foreach (var p in AnalyzedParameters)
                {
                    if (p.Customization == null)
                        continue;

                    if (!operationBannerOutput)
                    {
                        operationBannerOutput = true;
                        writer.WriteLine("{0}:{1} Parameter Renaming", CurrentModel.ServiceNounPrefix, CurrentOperation.MethodName);
                    }

                    writer.WriteLine(
                        p.Customization.Origin == Param.CustomizationOrigin.FromConfig
                            ? "    cfg:  {0} <= {1}"
                            : "    auto: {0} <= {1}", p.CmdletParameterName, p.AnalyzedName);
                }
            }
        }
    }
}
