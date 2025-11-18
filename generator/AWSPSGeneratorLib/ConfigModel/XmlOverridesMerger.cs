using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AWSPowerShellGenerator.ServiceConfig
{
    public class XmlOverridesMerger
    {
        public class OverrideDescription
        {
            public HashSet<string> ElementNames = new HashSet<string>();
            public HashSet<string> MethodNames = new HashSet<string>();
            public int FileVersion;
        }

        public static Dictionary<string, OverrideDescription> GetOverridesDescription(string folderPath, out string errorMessage)
        {
            var serviceOverrides = ReadOverrides(folderPath, out errorMessage);
            var result = new Dictionary<string, OverrideDescription>();
            foreach (var serviceOverride in serviceOverrides)
            {
                var description = new OverrideDescription();
                result.Add(serviceOverride.Key, description);
                description.FileVersion = int.Parse(serviceOverride.Value.GetElementsByTagName(nameof(ConfigModel.FileVersion)).OfType<XmlElement>().Single().InnerXml);
                foreach (var overrideElementsByName in serviceOverride.Value.ChildNodes.OfType<XmlElement>())
                {
                    description.ElementNames.Add(overrideElementsByName.Name);
                }
                var serviceOperations = serviceOverride.Value.GetElementsByTagName(nameof(ConfigModel.ServiceOperations)).OfType<XmlElement>().Single();
                foreach (var serviceOperation in serviceOperations.ChildNodes.OfType<XmlElement>())
                {
                    description.MethodNames.Add(serviceOperation.GetAttribute(nameof(ServiceOperation.MethodName)));
                }
            }
            return result;
        }

        public static void ApplyOverrides(string folderPath, string configurationsFolder)
        {
            var serviceOverrides = ReadOverrides(folderPath, out var errorMessage);

            // If the error message is not empty, it means there was an issue when reading the overrides file (for example, invalid schema).
            // Throw an exception so that the generator does not proceed to the next step.
            if (!string.IsNullOrEmpty(errorMessage)) 
            {
                throw new InvalidOperationException(errorMessage);
            }

            foreach (var serviceOverride in serviceOverrides)
            {
                string configurationFilePath = Path.Combine(configurationsFolder, $"{serviceOverride.Key}.xml");
                ConfigModel serviceConfig = null;
                if (File.Exists(configurationFilePath))
                {
                    var currentConfig = new XmlDocument();
                    currentConfig.Load(configurationFilePath);
                    if (Merge(currentConfig.DocumentElement, serviceOverride.Value))
                    {
                        var serializer = new XmlSerializer(typeof(ConfigModel));
                        serviceConfig = (ConfigModel)serializer.Deserialize(new XmlNodeReader(currentConfig.DocumentElement));
                    }
                }
                else
                {
                    var overrides = new XmlAttributeOverrides();
                    overrides.Add(typeof(ConfigModel), new XmlAttributes() { XmlRoot = new XmlRootAttribute("Service") });
                    var serializer = new XmlSerializer(typeof(ConfigModel), overrides);
                    serviceConfig = (ConfigModel)serializer.Deserialize(new XmlNodeReader(serviceOverride.Value));
                }

                if (serviceConfig != null)
                {
                    serviceConfig.ServiceOperationsList = serviceConfig.ServiceOperationsList.OrderBy(so => so.MethodName).ToList();
                    serviceConfig.Serialize(configurationFilePath);
                }
            }
        }

        private static bool Merge(XmlElement serviceConfiguration, XmlElement serviceOverride)
        {
            foreach (var overrideElementsByName in serviceOverride.ChildNodes.OfType<XmlElement>().GroupBy(element => element.Name))
            {
                switch (overrideElementsByName.Key)
                {
                    case nameof(ConfigModel.FileVersion):
                        {
                            var currentFileVersion =  int.Parse(GetChildElementsByTagName(serviceConfiguration, nameof(ConfigModel.FileVersion)).SingleOrDefault()?.InnerXml ?? "0");
                            var overridesFileVersion = int.Parse(overrideElementsByName.Single().InnerXml);
                            if (currentFileVersion != overridesFileVersion)
                            {
                                return false;
                            }
                        }
                        break;
                    case nameof(ConfigModel.C2jFilename):
                        break;
                    case nameof(ConfigModel.SkipCmdletGeneration):
                    case nameof(ConfigModel.AssemblyName):
                    case nameof(ConfigModel.ServiceNounPrefix):
                    case nameof(ConfigModel.ServiceName):
                    case nameof(ConfigModel.ServiceClientInterface):
                    case nameof(ConfigModel.ServiceClient):
                    case nameof(ConfigModel.ServiceModuleGuid):
                        throw new NotSupportedException($"The {overrideElementsByName.Key} configuration cannot be changed through overrides");
                    case nameof(ConfigModel.ServiceOperations):
                        MergeOperations(GetChildElementsByTagName(serviceConfiguration, nameof(ConfigModel.ServiceOperations)).Single(),
                                        overrideElementsByName.SelectMany(overrideOperations => overrideOperations.ChildNodes.OfType<XmlElement>()));
                        break;
                    default:
                        foreach(var elementsToBeReplaced in GetChildElementsByTagName(serviceConfiguration, overrideElementsByName.Key).ToArray())
                        {
                            serviceConfiguration.RemoveChild(elementsToBeReplaced);
                        }
                        foreach(var overrideElement in overrideElementsByName)
                        {
                            serviceConfiguration.AppendChild(serviceConfiguration.OwnerDocument.ImportNode(overrideElement, true));
                        }
                        break;
                }
            }

            return true;
        }

        private static void MergeOperations(XmlElement destination, IEnumerable<XmlElement> overrides)
        {
            foreach (var operationOverride in overrides)
            {
                string methodName = operationOverride.GetAttribute(nameof(ServiceOperation.MethodName));
                foreach(var elementsToBeReplaced in destination.ChildNodes
                    .OfType<XmlElement>()
                    .Where(existingOperation => existingOperation.GetAttribute(nameof(ServiceOperation.MethodName)) == methodName)
                    .ToArray())
                {
                    destination.RemoveChild(elementsToBeReplaced);
                }
                var removeAttribute = operationOverride.GetAttribute("Remove");
                if (string.IsNullOrWhiteSpace(removeAttribute) || !bool.Parse(removeAttribute))
                {
                    destination.AppendChild(destination.OwnerDocument.ImportNode(operationOverride, true));
                }
            }
        }

        public static Dictionary<string, XmlElement> ReadOverrides(string folderPath, out string errorMessage)
        {
            errorMessage = null;
            var fileName = Path.Combine(folderPath, "overrides.xml");

            if (!File.Exists(fileName))
            {
                return new Dictionary<string, XmlElement>();
            }

            var schemaFileName = Path.Combine(folderPath, "XmlSchemas", "ConfigurationOverrides", "overrides.xsd");

            var validationMessages = new StringBuilder();
            bool hasErrors = false;
            try
            {
                var settings = new XmlReaderSettings();
                settings.Schemas.Add(null, schemaFileName);
                settings.ValidationType = ValidationType.Schema;                
                settings.ValidationEventHandler += new ValidationEventHandler((sender, e) =>
                {
                    hasErrors = hasErrors || e.Severity == XmlSeverityType.Error;
                    validationMessages.AppendLine($"{e.Severity}: {e.Message}");                    
                });

                var reader = XmlReader.Create(fileName, settings);
                var document = new XmlDocument();
                document.Load(reader);
                                
                if (hasErrors)
                {                    
                    errorMessage = $"Override file schema validation failed. The following errors need to be corrected:{Environment.NewLine}{validationMessages}";
                    TryWriteErrorFile(folderPath, errorMessage);
                    return new Dictionary<string, XmlElement>();
                }

                return document.DocumentElement.ChildNodes
                    .OfType<XmlElement>()
                    .ToDictionary(serviceElement => GetChildElementsByTagName(serviceElement, nameof(ConfigModel.C2jFilename)).Single().InnerText, serviceElement => serviceElement);
            }
            catch (Exception e)
            {
                errorMessage = $"Error deserializing the provided override file. {e.Message}";
                TryWriteErrorFile(folderPath, errorMessage);
                return new Dictionary<string, XmlElement>();
            }
        }

        private static IEnumerable<XmlElement> GetChildElementsByTagName(XmlElement element, string name)
        {
            return element.ChildNodes.OfType<XmlElement>().Where(child => child.Name == name);
        }

        // Creates a flag file 'buildConfigValidationErrors.txt' that is read by CDK to send approval notifications
        // for preview build failures caused by invalid build configuration files.
        private static void TryWriteErrorFile(string folderPath, string errorMessage)
        {
            try
            {
                var errorFilePath = Path.Combine(folderPath, "buildConfigValidationErrors.txt");        
                File.WriteAllText(errorFilePath, errorMessage);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to create or write to the file buildConfigValidationErrors.txt. Exception occurred: {ex.Message}");
            }
        }
    }
}
