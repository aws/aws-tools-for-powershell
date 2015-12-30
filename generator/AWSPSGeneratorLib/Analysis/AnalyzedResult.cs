using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using AWSPowerShellGenerator.CmdletConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Writers;

namespace AWSPowerShellGenerator.Analysis
{
    internal class AnalyzedResult
    {
        /// <summary>
        /// The SDK type holding the full response data from the api call.
        /// The true output will be either one or more members of this type
        /// or a nested type. For most services and operations, this type
        /// is the same as ReturnType.
        /// </summary>
        public Type ResponseType { get; private set; }

        /// <summary>
        /// The output type of the method that contains the actual result data.
        /// Usually the same as ResponseType except for scenarios where the SDK
        /// generator has wrapped the true output into another type addressed
        /// by a member of ResponseType.
        /// </summary>
        public Type ReturnType { get; private set; }

        public enum ResultOutputTypes
        {
            Empty,
            SingleProperty,
            MultiProperty
        }

        public ResultOutputTypes OutputType { get; private set; }

        // analyzed outputs contained in the Response class
        private List<PropertyInfo> AllOutputProperties { get; set; }
        private List<PropertyInfo> NonMetadataProperties { get; set; }
        public List<PropertyInfo> MetadataProperties { get; private set; }

        // The inner property representing the true output for Response classes 
        // analyzed as a SinglePropertyResult output type
        public SimplePropertyInfo SingleResultProperty { get; private set; }

        public string[] ReturnTypeDescription { get; private set; }

        /// <summary>
        /// If not empty, this holds the parameter that can be piped into the
        /// cmdlet and which should be emitted to the pipeline if the -PassThru
        /// switch (which will be added if this is not empty) is set.
        /// </summary>
        public SimplePropertyInfo PassThruParameter { get; set; }

        public AnalyzedResult(CmdletGenerator generator, OperationAnalyzer operationAnalyzer)
        {
            // for most services, these are the same types. For some services (like SWF) the
            // SDK generates a wrapper class inside the response that contains the actual
            // return data. On exit from this analysis, ReturnType may update further if
            // the cmdlet returns a collection to represent the collection types, not the
            // type hosting the collection.
            ResponseType = operationAnalyzer.ResponseType;
            ReturnType = operationAnalyzer.ReturnType;

            OutputType = ResultOutputTypes.Empty;

            Func<PropertyInfo, bool> isMetadataProperty = p =>
                        operationAnalyzer.AllModels.MetadataPropertyNames.Contains(p.Name) ||
                        operationAnalyzer.CurrentModel.MetadataPropertyNames.Contains(p.Name) ||
                        operationAnalyzer.CurrentOperation.MetadataPropertiesList.Contains(p.Name);
            Func<PropertyInfo, bool> notMetadataProperty = p => !isMetadataProperty(p);

            // if the response type has a base class with matching prefix but ending
            // in 'Result', use that to get the real properties considered output. S3 does
            // not have this structure.
            var inspectedType = ReturnType;
            if (ResponseType.BaseType != null)
            {
                if (ResponseType.BaseType.Name.EndsWith("Result", StringComparison.Ordinal))
                    inspectedType = ResponseType.BaseType;
            }

            AllOutputProperties = inspectedType
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttributes(false).Count(a => a is ObsoleteAttribute) == 0)
                .ToList();
            NonMetadataProperties = AllOutputProperties.Where(notMetadataProperty).ToList();
            MetadataProperties = AllOutputProperties.Where(isMetadataProperty).ToList();

            if (this.NonMetadataProperties.Count == 1)
            {
                OutputType = ResultOutputTypes.SingleProperty;

                var property = NonMetadataProperties.First();
                SingleResultProperty = operationAnalyzer.CreateSimplePropertyFor(property, null);
                // if the output is a collection, extract the inner type so we report that as the cmdlet
                // output in help, not the List wrapper (grab the full name so we can be explicit in help)
                if (property.PropertyType.IsGenericType)
                {
                    SingleResultProperty.GenericCollectionTypes = property.PropertyType.GetGenericArguments();
                    if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("List`", StringComparison.Ordinal))
                        SingleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericList;
                    else if (property.PropertyType.GetGenericTypeDefinition().Name.StartsWith("Dictionary`", StringComparison.Ordinal))
                        SingleResultProperty.CollectionType = SimplePropertyInfo.PropertyCollectionType.IsGenericDictionary;
                }
            }
            else if (this.NonMetadataProperties.Count > 1)
                OutputType = ResultOutputTypes.MultiProperty;

            var returnTypeDescription = new List<string>();
            switch (OutputType)
            {
                case ResultOutputTypes.Empty:
                    {
                        // the 'standard' text declaring no output (except with -passthru) is added in the cmdlet source writer,
                        // as there are some variants
                        ReturnType = null;
                        returnTypeDescription.Add(string.Format(StringConstants.ServiceResponseFormatText, 
                                                                OperationAnalyzer.GetValidTypeName(ResponseType, operationAnalyzer.CurrentModel)));
                    }
                    break;
                case ResultOutputTypes.MultiProperty:
                    {
                        ReturnType = inspectedType;
                        returnTypeDescription.Add(string.Format(StringConstants.MultipleOutputPropertiesFormatText, 
                                                                OperationAnalyzer.GetValidTypeName(inspectedType, operationAnalyzer.CurrentModel)));
                    }
                    break;
                case ResultOutputTypes.SingleProperty:
                    {
                        var isEnumerableOutput = SingleResultProperty.GenericCollectionTypes != null;
                        ReturnType = isEnumerableOutput ? SingleResultProperty.GenericCollectionTypes[0] : SingleResultProperty.PropertyType;

                        // prefer the short name of the emitted type in the description, to make it more readable
                        returnTypeDescription.Add(isEnumerableOutput
                                                      ? string.Format("This cmdlet returns a collection of {0} objects.",
                                                                      SingleResultProperty.GenericCollectionTypes[0].Name)
                                                      : string.Format("This cmdlet returns a {0} object.",
                                                                      ReturnType.Name));
                        returnTypeDescription.Add(string.Format("The service call response (type {0}) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
                                                                OperationAnalyzer.GetValidTypeName(ResponseType, operationAnalyzer.CurrentModel)));

                        if (MetadataProperties.Count > 0)
                        {
                            var notes = "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: ";
                            notes += string.Join(", ", MetadataProperties
                                .Select(metadata => string.Format("{0} (type {1})",
                                                                  metadata.Name,
                                                                  OperationAnalyzer.GetValidTypeName(metadata.PropertyType, operationAnalyzer.CurrentModel))));
                            returnTypeDescription.Add(notes);
                        }
                    }
                    break;
            }

            ReturnTypeDescription = returnTypeDescription.Select(SecurityElement.Escape).ToArray();
        }
    }
}
