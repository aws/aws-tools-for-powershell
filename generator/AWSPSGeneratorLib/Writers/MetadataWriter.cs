using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.ServiceConfig;

namespace AWSPowerShellGenerator.Writers
{
    public static partial class MetadataWriter
    {
        public static void WriteCmdletMetadata(
            IEnumerable<ConfigModel> services,
            Dictionary<string, AdvancedCmdletInfo> commonAdvancedCmdlets,
            string outputPath,
            string version,
            List<CommonParameterInfo> commonParameters = null)
        {
            var servicesDict = new SortedDictionary<string, object>();

            foreach (var service in services)
            {
                if (string.IsNullOrEmpty(service.ServiceModuleGuid))
                    continue;

                var cmdlets = new SortedDictionary<string, object>();

                foreach (var operation in service.ServiceOperationsList.Where(op => !op.Exclude))
                {
                    if (string.IsNullOrEmpty(operation.SelectedVerb) || string.IsNullOrEmpty(operation.SelectedNoun))
                        continue;

                    var cmdletName = $"{operation.SelectedVerb}-{operation.SelectedNoun}";
                    var cmdletData = BuildGeneratedCmdletData(operation, service);
                    if (cmdletData != null)
                        cmdlets[cmdletName] = cmdletData;
                }

                foreach (var kvp in service.AdvancedCmdlets)
                {
                    var cmdletData = BuildAdvancedCmdletData(kvp.Value);
                    cmdlets[kvp.Key] = cmdletData;
                }

                if (cmdlets.Count > 0)
                {
                    servicesDict[service.AssemblyName] = new Dictionary<string, object>
                    {
                        ["moduleName"] = $"AWS.Tools.{service.AssemblyName}",
                        ["nounPrefix"] = service.ServiceNounPrefix,
                        ["cmdlets"] = cmdlets
                    };
                }
            }

            if (commonAdvancedCmdlets.Count > 0)
            {
                var commonCmdlets = new SortedDictionary<string, object>();
                foreach (var kvp in commonAdvancedCmdlets)
                {
                    var cmdletData = BuildAdvancedCmdletData(kvp.Value);
                    commonCmdlets[kvp.Key] = cmdletData;
                }

                servicesDict["Common"] = new Dictionary<string, object>
                {
                    ["moduleName"] = "AWS.Tools.Common",
                    ["nounPrefix"] = "AWS",
                    ["cmdlets"] = commonCmdlets
                };
            }

            var root = new Dictionary<string, object>
            {
                ["version"] = version,
            };

            if (commonParameters != null && commonParameters.Count > 0)
            {
                root["commonParameters"] = BuildCommonParametersData(commonParameters);
            }

            root["services"] = servicesDict;

            var json = JsonSerializer.Serialize(root, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(outputPath, json);
        }

        public static void WriteConstantClasses(
            IEnumerable<ConfigModel> services,
            string outputPath,
            string version)
        {
            var classes = new SortedDictionary<string, object>();

            foreach (var service in services)
            {
                if (string.IsNullOrEmpty(service.ServiceModuleGuid))
                    continue;

                foreach (var operation in service.ServiceOperationsList.Where(op => !op.Exclude))
                {
                    if (operation.Analyzer?.AnalyzedParameters == null)
                        continue;

                    foreach (var param in operation.Analyzer.AnalyzedParameters)
                    {
                        if (param.IsConstrainedToSet && param.PropertyType != null)
                        {
                            var typeName = param.PropertyType.FullName;
                            if (!classes.ContainsKey(typeName))
                            {
                                try
                                {
                                    var members = SimplePropertyInfo.GetConstantClassMembers(param.PropertyType);
                                    classes[typeName] = members.ToArray();
                                }
                                catch
                                {
                                    // Skip types that can't be resolved
                                }
                            }
                        }
                    }
                }

                // Also collect from advanced cmdlets
                foreach (var kvp in service.AdvancedCmdlets)
                {
                    foreach (var param in kvp.Value.Parameters)
                    {
                        if (!string.IsNullOrEmpty(param.ConstantClass) && !classes.ContainsKey(param.ConstantClass))
                        {
                            try
                            {
                                var propertyType = service.Assembly?.GetType(param.ConstantClass);
                                if (propertyType != null)
                                {
                                    var members = SimplePropertyInfo.GetConstantClassMembers(propertyType);
                                    classes[param.ConstantClass] = members.ToArray();
                                }
                            }
                            catch
                            {
                                // Skip types that can't be resolved
                            }
                        }
                    }
                }
            }

            var root = new Dictionary<string, object>
            {
                ["version"] = version,
                ["classes"] = classes
            };

            var json = JsonSerializer.Serialize(root, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(outputPath, json);
        }

        private static Dictionary<string, object> BuildGeneratedCmdletData(ServiceOperation operation, ConfigModel service)
        {
            var data = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(operation.MethodName))
                data["apiOperation"] = operation.MethodName;

            var description = GetCmdletDescription(operation);
            if (!string.IsNullOrEmpty(description))
                data["description"] = description;

            var autoIterates = operation.Analyzer?.AutoIterateSettings;
            if (autoIterates != null)
                data["autoPaginates"] = true;

            if (!string.IsNullOrEmpty(operation.ReplacementObsoleteMessage))
                data["deprecated"] = true;

            var parameters = BuildParametersFromAnalyzer(operation, autoIterates);
            data["parameters"] = parameters;

            return data;
        }

        private static string GetCmdletDescription(ServiceOperation operation)
        {
            try
            {
                if (operation.Analyzer?.Method == null || operation.Analyzer.AssemblyDocumentation == null)
                    return null;

                var raw = DocumentationUtils.GetMethodDocumentation(
                    operation.Analyzer.Method.DeclaringType,
                    operation.MethodName,
                    operation.Analyzer.AssemblyDocumentation);

                if (string.IsNullOrEmpty(raw))
                    return null;

                return StripXmlTags(raw);
            }
            catch
            {
                return null;
            }
        }

        private static string StripXmlTags(string text)
        {
            var stripped = XmlTagRegex().Replace(text, " ");
            stripped = WhitespaceRegex().Replace(stripped, " ");
            return stripped.Trim();
        }

        [System.Text.RegularExpressions.GeneratedRegex(@"<[^>]+>")]
        private static partial Regex XmlTagRegex();

        [System.Text.RegularExpressions.GeneratedRegex(@"\s+")]
        private static partial Regex WhitespaceRegex();

        private static Dictionary<string, object> BuildAdvancedCmdletData(AdvancedCmdletInfo info)
        {
            var data = new Dictionary<string, object>();

            var nonEmptyOps = info.OperationNames.Where(op => !string.IsNullOrEmpty(op)).ToList();
            if (nonEmptyOps.Count == 1)
                data["apiOperation"] = nonEmptyOps[0];
            else if (nonEmptyOps.Count > 1)
                data["apiOperation"] = nonEmptyOps.ToArray();

            data["advanced"] = true;

            if (info.IsDeprecated)
                data["deprecated"] = true;

            var parameters = new SortedDictionary<string, object>();
            foreach (var param in info.Parameters)
            {
                var paramData = new Dictionary<string, object>();
                paramData["type"] = param.Type;

                if (param.Mandatory)
                    paramData["mandatory"] = true;
                if (!string.IsNullOrEmpty(param.ConstantClass))
                    paramData["constantClass"] = param.ConstantClass;
                if (param.Deprecated)
                    paramData["deprecated"] = true;
                if (param.Aliases.Count > 0)
                    paramData["aliases"] = param.Aliases.ToArray();

                parameters[param.Name] = paramData;
            }
            data["parameters"] = parameters;

            return data;
        }

        private static SortedDictionary<string, object> BuildParametersFromAnalyzer(ServiceOperation operation, AutoIteration autoIterates)
        {
            var parameters = new SortedDictionary<string, object>();

            if (operation.Analyzer?.AnalyzedParameters == null)
                return parameters;

            var autoIterationParams = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (autoIterates != null)
            {
                if (!string.IsNullOrEmpty(autoIterates.Start))
                    autoIterationParams.Add(autoIterates.Start);
                if (!string.IsNullOrEmpty(autoIterates.EmitLimit))
                    autoIterationParams.Add(autoIterates.EmitLimit);
            }

            foreach (var param in operation.Analyzer.AnalyzedParameters)
            {
                if (autoIterationParams.Contains(param.AnalyzedName))
                    continue;

                var paramData = new Dictionary<string, object>();
                paramData["type"] = param.PropertyTypeName;

                if (param.IsRecursivelyRequired)
                    paramData["mandatory"] = true;

                if (param.IsConstrainedToSet && param.PropertyType != null)
                    paramData["constantClass"] = param.PropertyType.FullName;

                if (param.IsDeprecated)
                    paramData["deprecated"] = true;

                var aliases = operation.Analyzer.GetAllParameterAliases(param);
                if (aliases.Count > 0)
                    paramData["aliases"] = aliases.ToArray();

                parameters[param.CmdletParameterName] = paramData;
            }

            return parameters;
        }

        private static SortedDictionary<string, object> BuildCommonParametersData(List<CommonParameterInfo> commonParameters)
        {
            var result = new SortedDictionary<string, object>();
            foreach (var param in commonParameters)
            {
                var paramData = new Dictionary<string, object>();
                paramData["type"] = param.Type;
                if (param.Aliases.Count > 0)
                    paramData["aliases"] = param.Aliases.ToArray();
                result[param.Name] = paramData;
            }
            return result;
        }

        /// <summary>
        /// Generates cmdlet-aliases.json by parsing AWSAliases.ps1 and AWSPowerShellLegacyAliases.psm1.
        /// Maps alias names to their canonical cmdlet names.
        /// </summary>
        public static void WriteCmdletAliases(string aliasesFilePath, string legacyAliasesFilePath, string outputPath, string version)
        {
            var aliases = new SortedDictionary<string, object>();

            ParseAliasFile(aliasesFilePath, aliases, "api");
            ParseAliasFile(legacyAliasesFilePath, aliases, "legacy");

            var root = new Dictionary<string, object>
            {
                ["version"] = version,
                ["aliases"] = aliases
            };

            var json = JsonSerializer.Serialize(root, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText(outputPath, json);
        }

        private static readonly Regex SetAliasRegex = new Regex(
            @"Set-Alias\s+-Name\s+(\S+)\s+-Value\s+(\S+)",
            RegexOptions.Compiled);

        private static void ParseAliasFile(string filePath, SortedDictionary<string, object> aliases, string type)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadLines(filePath))
            {
                var match = SetAliasRegex.Match(line);
                if (match.Success)
                {
                    var aliasName = match.Groups[1].Value;
                    var cmdletName = match.Groups[2].Value;
                    if (!aliases.ContainsKey(aliasName))
                    {
                        aliases[aliasName] = new Dictionary<string, object>
                        {
                            ["cmdlet"] = cmdletName,
                            ["type"] = type
                        };
                    }
                }
            }
        }
    }
}
