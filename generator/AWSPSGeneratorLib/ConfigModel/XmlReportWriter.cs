using AWSPowerShellGenerator.Analysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AWSPowerShellGenerator.ServiceConfig
{
    class XmlReportWriter
    {
        public static void SerializeReport(string folderPath, IEnumerable<ConfigModel> models, bool generateReportOnly)
        {
            var serviceNewOperationsMapping = new Dictionary<string, HashSet<string>>();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var overrides = XmlOverridesMerger.GetOverridesDescription(folderPath, out var errorMessage);

            var filename = Path.Combine(folderPath, "report.xml");
            try
            {
                var writerSettings = new XmlWriterSettings
                {
                    Encoding = new UTF8Encoding(false),
                    Indent = true,
                    IndentChars = "    "
                };

                //We only include services with errors, new operations or operations requiring a configuration update
                var configModelsToOutput = models.Where(configModel =>
                        configModel.AnalysisErrors.Any() ||
                        overrides.ContainsKey(configModel.C2jFilename) ||
                        configModel.ServiceOperationsList.Where(op => op.IsAutoConfiguring || op.AnalysisErrors.Any() || op.IsReservedParameterNameHandled).Any())
                    .ToArray();

                bool hasErrors = models.Any(configModel =>
                    configModel.AnalysisErrors.Any() ||
                    configModel.ServiceOperationsList.Any(op => op.AnalysisErrors.Any()));

                // This creates a file named 'buildConfigErrors'. It is used as a flag file 
                // for CDK to send trebuchet an approval for build config failures
                if (hasErrors)
                {
                    File.WriteAllText(Path.Combine(folderPath, "buildConfigErrors"), string.Empty);
                }

                bool hasNewOperations = models.Any(model => model.ServiceOperationsList.Any(op => op.IsAutoConfiguring));
                bool isReservedParameterNameHandled = models.Any(model => model.ServiceOperationsList.Any(op => op.IsReservedParameterNameHandled));

                var doc = new XDocument();

                using (var writer = doc.CreateWriter())
                {
                    writer.WriteStartElement("Overrides");
                    writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
                    writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xsi", "noNamespaceSchemaLocation", null, "https://raw.githubusercontent.com/aws/aws-tools-for-powershell/main/XmlSchemas/ConfigurationOverrides/overrides.xsd");

                    if (errorMessage != null)
                    {
                        writer.WriteComment($"ERROR - {errorMessage}");
                    }

                    foreach (var configModel in configModelsToOutput)
                    {
                        var xmlAttributeOverrides = new XmlAttributeOverrides();
                        xmlAttributeOverrides.Add(typeof(ConfigModel), new XmlAttributes() { XmlRoot = new XmlRootAttribute("Service") });
                        var serializer = new XmlSerializer(typeof(ConfigModel), xmlAttributeOverrides);
                        serializer.Serialize(writer, configModel);
                    }

                    writer.WriteEndElement(); //Overrides
                }

                foreach (var configModel in doc.Root.Elements().Zip(configModelsToOutput, (element, model) => (element, model)))
                {
                    List<XComment> serviceComments = new List<XComment>();

                    XmlOverridesMerger.OverrideDescription modelOverrides;
                    if (overrides.TryGetValue(configModel.model.C2jFilename, out modelOverrides) && modelOverrides.FileVersion != configModel.model.FileVersion)
                    {
                        AnalysisError.WrongFileVersionNumber(configModel.model);
                        modelOverrides = null;
                    }

                    serviceComments.Add(new XComment($"The current full configuration for this service is available at https://raw.githubusercontent.com/aws/aws-tools-for-powershell/main/generator/AWSPSGeneratorLib/Config/ServiceConfig/{configModel.model.C2jFilename}.xml."));

                    foreach (var error in configModel.model.AnalysisErrors)
                    {
                        serviceComments.Add(new XComment($"ERROR - {error.Message}"));
                    }

                    foreach (var serviceElement in configModel.element.Elements().ToArray())
                    {
                        switch (serviceElement.Name.LocalName)
                        {
                            case nameof(ConfigModel.C2jFilename):
                            case nameof(ConfigModel.ServiceOperations):
                            case nameof(ConfigModel.FileVersion):
                                //Preserve these elements
                                break;
                            case nameof(ConfigModel.SkipCmdletGeneration):
                            case nameof(ConfigModel.AssemblyName):
                            case nameof(ConfigModel.ServiceNounPrefix):
                            case nameof(ConfigModel.ServiceName):
                            case nameof(ConfigModel.ServiceClientInterface):
                            case nameof(ConfigModel.ServiceClient):
                            case nameof(ConfigModel.ServiceModuleGuid):
                                //Remove unless present in the override file
                                if (!(modelOverrides?.ElementNames.Contains(serviceElement.Name.LocalName) ?? false))
                                {
                                    serviceElement.Remove();
                                }
                                break;
                            default:
                                //Change into comments unless present in the override file
                                if (!(modelOverrides?.ElementNames.Contains(serviceElement.Name.LocalName) ?? false))
                                {
                                    serviceComments.Add(new XComment(serviceElement.ToString()));
                                    serviceElement.Remove();
                                }
                                break;
                        }
                    }

                    var serviceOperationsElement = configModel.element.Element("ServiceOperations");

                    serviceOperationsElement.AddBeforeSelf(serviceComments);

                    var operations = serviceOperationsElement.Elements()
                        .Join(configModel.model.ServiceOperationsList, element => element.Attribute("MethodName").Value, operation => operation.MethodName, (element, operation) => (element, operation))
                        .ToArray();

                    // If there are any new operations (IsAutoConfiguring=true) that are not excluded (Analyzer!=null), then store it in new operations map.
                    if (operations.Any(op => op.operation.IsAutoConfiguring && op.operation.Analyzer != null))
                    {
                        serviceNewOperationsMapping[configModel.model.C2jFilename] = new HashSet<string>(operations.Where(op => op.operation.IsAutoConfiguring && op.operation.Analyzer != null).Select(op => op.operation.MethodName));
                    }

                    foreach (var operation in operations)
                    {
                        var isConfigurationOverridden = modelOverrides?.MethodNames.Contains(operation.operation.MethodName) ?? false;

                        // We only include in the report new operations (IsAutoConfiguring=true) and operations requiring configuration updated (e.g. reserved parameter name handling).
                        // We also retain in the report any operation that was manually configured.
                        if (operation.operation.IsAutoConfiguring ||
                            operation.operation.AnalysisErrors.Any() ||
                            isConfigurationOverridden ||
                            operation.operation.IsReservedParameterNameHandled)
                        {
                            var firstOperationChildElement = operation.element.Elements().FirstOrDefault();

                            if (operation.operation.IsAutoConfiguring)
                            {
                                operation.element.AddFirst(new XComment($"INFO - This is a new cmdlet."));
                            }
                            if (isConfigurationOverridden)
                            {
                                operation.element.AddFirst(new XComment($"INFO - The configuration of this cmdlet is being changed through overrides."));
                            }
                            foreach (var error in operation.operation.AnalysisErrors)
                            {
                                operation.element.AddFirst(new XComment($"ERROR - {error.Message}"));
                            }
                            foreach (var info in operation.operation.InfoMessages)
                            {
                                operation.element.AddFirst(new XComment($"INFO - {info.Message}"));
                            }

                            try
                            {
                                //Excluded operations have Analyzer == null
                                if (operation.operation.Analyzer != null)
                                {
                                    if (operation.operation.Analyzer.AnalyzedParameters.Any())
                                    {
                                        // If reserved parameter name was handled, then we need to update or add Param element for the parameter customization in the report XML.
                                        var analyzedParametersWithCustomization = operation.operation.Analyzer.AnalyzedParameters.Where(p => p.Customization != null);
                                        if (operation.operation.IsReservedParameterNameHandled && analyzedParametersWithCustomization.Any())
                                        {
                                            var paramsElement = operation.element.Element("Params");
                                            if (paramsElement == null)
                                            {
                                                paramsElement = new XElement("Params");
                                                operation.element.Add(paramsElement);
                                            }

                                            foreach (var analyzedParameter in analyzedParametersWithCustomization)
                                            {
                                                var parameterElement = paramsElement.Elements("Param").FirstOrDefault(child => (string)child.Attribute("Name") == analyzedParameter.Customization.Name);
                                                if (parameterElement == null)
                                                {
                                                    parameterElement = new XElement("Param", new XAttribute("Name", analyzedParameter.Customization.Name));
                                                    paramsElement.Add(parameterElement);
                                                }

                                                parameterElement.SetAttributeValue("NewName", analyzedParameter.Customization.NewName);
                                                parameterElement.SetAttributeValue("AutoApplyAlias", analyzedParameter.Customization.AutoApplyAlias);

                                                // We can add a XML comment before Param element if customization is due to reserved parameter handling. But we cannot rely on analyzedParameter.Customization.Origin
                                                // as DuringGeneration since it could happen for other shortning scenarios. We are already adding info message if reserved parameter handling was done, which is good enough.
                                            }
                                        }

                                        // Add XML comment about parameters information.
                                        var parametersComments = operation.operation.Analyzer.AnalyzedParameters.Select(PropertyChangedEventArgs => GetParameterCommentForReport(PropertyChangedEventArgs, operation.operation.Analyzer));
                                        operation.element.Add(new XComment($"INFO - Parameters:\n            {string.Join(";\n            ", parametersComments)}."));
                                    }

                                    var returnTypeComment = GetReturnTypeComment(operation.operation.Analyzer);
                                    if (returnTypeComment != null)
                                    {
                                        operation.element.Add(new XComment($"INFO - {returnTypeComment}"));
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                operation.element.AddFirst(new XComment($"ERROR - Exception while generating operation report: {e.ToString()}"));
                            }
                        }
                        else
                        {
                            operation.element.Remove();
                        }
                    }
                }

                if (!generateReportOnly)
                {
                    doc.Save(filename);
                }
                else if (hasNewOperations && !hasErrors)
                {
                    Console.WriteLine("New operations were auto-configured without errors and saved in report.xml");
                    doc.Save(filename);
                }
                else if (isReservedParameterNameHandled && !hasErrors)
                {
                    Console.WriteLine("Operations had parameters which conflicted with reserved parameter name that were automatically resolved without errors and saved in report.xml");
                    doc.Save(filename);
                }
                else
                {
                    Console.WriteLine($"Skipping saving report: hasNewOperations:{hasNewOperations}, isReservedParameterNameHandled: {isReservedParameterNameHandled}, hasErrors: {hasErrors} ");
                }

                // Save service -> new operations mapping in a JSON file irrespective of errors. In case the mapping list is empty, we can serialize to file with no data.
                File.WriteAllText(Path.Combine(folderPath, "serviceNewOperationsMapping.json"), JsonSerializer.Serialize(serviceNewOperationsMapping, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception e)
            {
                throw new IOException("Unable to serialize report to " + filename, e);
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new Exception(errorMessage);
            }
        }
        private static string GetReturnTypeComment(OperationAnalyzer operationAnalyzer)
        {
            var returnType = operationAnalyzer.ReturnType;
            if (returnType != null)
            {
                var allOutputProperties = returnType
                    .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                    .ToArray();

                var returnTypeFields = "";
                if (returnType.Namespace.StartsWith("Amazon.") && allOutputProperties.Any())
                {
                    returnTypeFields = $" {{{Environment.NewLine}            {string.Join($";{Environment.NewLine}            ", allOutputProperties.Select(property => $"{OperationAnalyzer.FormatTypeName(property.PropertyType)} {property.Name}"))} }}";
                }

                return $"Operation result type: {OperationAnalyzer.FormatTypeName(returnType)}{returnTypeFields}.";
            }

            return null;
        }

        private static string GetParameterCommentForReport(Generators.SimplePropertyInfo property, OperationAnalyzer operationAnalyzer)
        {
            var comment = new StringBuilder();
            comment.Append($" {property.PropertyTypeName} {property.AnalyzedName}");
            if (property.AnalyzedName != property.CmdletParameterName)
            {
                comment.Append($" as {property.CmdletParameterName}");
                var aliases = operationAnalyzer.GetAllParameterAliases(property);
                if (aliases.Any())
                {
                    comment.Append($" (aliases: {string.Join(", ", aliases)})");
                }
            }
            if (property.IsRecursivelyRequired)
            {
                comment.Append(" [required]");
            }
            return comment.ToString();
        }


    }
}
