using AWSPowerShellGenerator.Analysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AWSPowerShellGenerator.ServiceConfig
{
    class XmlReportWriter
    {
        public static void SerializeReport(string folderPath, IEnumerable<ConfigModel> models)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

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
                        configModel.ServiceOperationsList.Where(op => op.IsAutoConfiguring || op.IsConfigurationOverridden || op.AnalysisErrors.Any()).Any())
                    .ToArray();

                var doc = new XDocument();

                using (var writer = doc.CreateWriter())
                {
                    writer.WriteStartElement("Overrides");
                    writer.WriteAttributeString("xmlns", "xsd", null, "http://www.w3.org/2001/XMLSchema");
                    writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                    writer.WriteAttributeString("xsi", "noNamespaceSchemaLocation", null, "https://raw.githubusercontent.com/aws/aws-tools-for-powershell/master/XmlSchemas/ConfigurationOverrides/overrides.xsd");

                    foreach (var configModel in configModelsToOutput)
                    {
                        var overrides = new XmlAttributeOverrides();
                        overrides.Add(typeof(ConfigModel), new XmlAttributes() { XmlRoot = new XmlRootAttribute("Service") });
                        var serializer = new XmlSerializer(typeof(ConfigModel), overrides);
                        serializer.Serialize(writer, configModel);
                    }

                    writer.WriteEndElement(); //Overrides
                }

                foreach (var configModel in doc.Root.Elements().Zip(configModelsToOutput, (element, model) => (element, model)))
                {
                    foreach (var error in configModel.model.AnalysisErrors)
                    {
                        configModel.element.AddFirst(new XComment($"ERROR - {error.Message}"));
                    }

                    var serviceOperationsElement = configModel.element.Element("ServiceOperations");

                    var operations = serviceOperationsElement.Elements()
                        .Join(configModel.model.ServiceOperationsList, element => element.Attribute("MethodName").Value, operation => operation.MethodName, (element, operation) => (element, operation))
                        .ToArray();

                    foreach (var operation in operations)
                    {
                        //We only include in the report new operations (IsAutoConfiguring=true) and operations requiring configuration updated. We also retain in the report
                        //any operation that was manually configured.
                        if (operation.operation.IsAutoConfiguring || operation.operation.IsConfigurationOverridden || operation.operation.AnalysisErrors.Any())
                        {
                            var firstOperationChildElement = operation.element.Elements().FirstOrDefault();

                            if (operation.operation.IsAutoConfiguring)
                            {
                                operation.element.AddFirst(new XComment($"INFO - This is a new cmdlet."));
                            }
                            if (operation.operation.IsConfigurationOverridden)
                            {
                                operation.element.AddFirst(new XComment($"INFO - The configuration of this cmdlet is being changed through overrides."));
                            }
                            foreach (var error in operation.operation.AnalysisErrors)
                            {
                                operation.element.AddFirst(new XComment($"ERROR - {error.Message}"));
                            }

                            try
                            {
                                //Excluded operations have Analyzer == null
                                if (operation.operation.Analyzer != null)
                                {
                                    if (operation.operation.Analyzer.AnalyzedParameters.Any())
                                    {
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

                doc.Save(filename);
            }
            catch (Exception e)
            {
                throw new IOException("Unable to serialize report to " + filename, e);
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
