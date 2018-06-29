using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.CmdletConfig;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AWSPowerShellGenerator.Generators
{
    /// <summary>
    /// Class to write PowerShell configurations for services in JSON format.
    /// Operation configurations also include results of the OperationAnalyzer.
    /// These configurations are saved to
    /// C:\Codebase\v3\AWSPowerShell\generator\AWSPSGeneratorLib\CmdletConfig.json
    /// (or it's equivalent on the build server) for informational purposes only, and
    /// have no bearing on the PowerShell cmdlets generated.
    /// </summary>
    internal class JsonPSConfigWriter : IDisposable
    {
        public ConfigModel Model { get; private set; }

        public string OutputPath { get; private set; }

        private StreamWriter _streamWriter;
        private JsonWriter _jsonWriter;

        /// <summary>
        /// Construct a JsonPSConfigWriter and write the beginning of the JSON file.
        /// </summary>
        /// <param name="configModel"></param>
        /// <param name="rootPath"></param>
        public JsonPSConfigWriter(ConfigModel configModel, string rootPath)
        {
            Model = configModel;
            var outputFolder = Path.Combine(Path.GetFullPath(rootPath), CmdletGenerator.CmdletJsonConfigurationsFoldername);
            OutputPath = Path.Combine(outputFolder, configModel.C2jFilename + ".powershell.json");
        }

        public void Serialize()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));
            _streamWriter = new StreamWriter(OutputPath);

            _jsonWriter = new JsonTextWriter(_streamWriter)
            {
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            _jsonWriter.WriteStartObject();

            // write the global service stuff
            WriteServiceGlobalValues();

            // write out the operations
            _jsonWriter.WritePropertyName("serviceOperations");
            _jsonWriter.WriteStartObject();

            foreach (var so in Model.ServiceOperationsList)
            {
                WriteOperation(so);
            }

            _jsonWriter.WriteEndObject();

            Close();
        }

        /// <summary>
        /// Write an object in the config file for the current
        /// operation that the analyzer has analyzed.
        /// </summary>
        /// <param name="operation"></param>
        internal void WriteOperation(ServiceOperation operation)
        {
            if (operation.Exclude)
            {
                _jsonWriter.WritePropertyName(operation.MethodName);
                _jsonWriter.WriteStartObject();
                WriteSimpleProperty("excludeFromGeneration", true);
                _jsonWriter.WriteEndObject();

                return;
            }

            var analyzer = operation.Analyzer;

            _jsonWriter.WritePropertyName(operation.MethodName);
            _jsonWriter.WriteStartObject();

            // put the all important verb and noun first, then output the rest in alpha order
            WriteSimpleProperty("verb", analyzer.CurrentOperation.SelectedVerb);
            WriteSimpleProperty("noun", analyzer.CurrentOperation.SelectedNoun.Substring(analyzer.CurrentModel.ServiceNounPrefix.Length));

            WriteSimpleProperty("anonymousAuthentication", analyzer.CurrentOperation.AnonymousAuthentication.ToString());

            WriteServiceOperationOutputSettings("cmdletOutput", analyzer.CurrentOperation);

            WriteObjectListProperty("parameterCustomizations", analyzer.CurrentOperation.CustomParametersList,
                (param) =>
                {
                    WriteSimpleProperty("originalName", param.Name);
                    WriteSimpleProperty("replacementName", param.NewName);
                    WriteStringListProperty("aliases", param.Aliases);
                    WriteSimpleProperty("autoApplOriginalNameAlias", param.AutoApplyAlias);
                    WriteSimpleProperty("disableAutoRename", !param.AutoRename);
                    WriteSimpleProperty("exclude", param.Exclude);
                });

            WriteServiceOperationLegacySettings("legacySettings", analyzer.CurrentOperation);

            WriteStringListProperty("outputMetadataMembers", analyzer.CurrentOperation.MetadataPropertiesList);

            WritePaginationSettings("pagination", analyzer.CurrentOperation.AutoIterate);
            WriteServiceOperationPipelineOverrides("pipeline", analyzer.CurrentOperation);

            WriteShouldProcessSettings("shouldProcess", analyzer.CurrentOperation);

            // these are transient in the move to the new generator, so keep at end
            WriteAnalyzerResults(analyzer);

            _jsonWriter.WriteEndObject();
        }

        private void WriteShouldProcessSettings(string propertyName, ServiceOperation operation)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("anonymousTargetParameter", operation.AnonymousShouldProcessTarget);
            WriteSimpleProperty("customMessageNoun", operation.ShouldProcessMsgNoun);
            WriteSimpleProperty("suppressShouldProcessConfirmation", operation.IgnoreSupportsShouldProcess);
            WriteSimpleProperty("targetParameter", operation.ShouldProcessTarget);
            _jsonWriter.WriteEndObject();

        }

        private void WriteServiceOperationOutputSettings(string propertyName, ServiceOperation operation)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("output", operation.Output.ToString());
            if (operation.Output == ServiceOperation.OutputMode.DefaultSingleMember)
                WriteSimpleProperty("outputMemberSelector", operation.Analyzer.AnalyzedResult.SingleResultProperty.Name);
            else
                WriteSimpleProperty("outputMemberSelector", "");
            WriteSimpleProperty("outputMemberWrapper", operation.OutputWrapper);
            WritePassThruObject(operation.PassThru);
            _jsonWriter.WriteEndObject();
        }

        private void WriteServiceOperationPipelineOverrides(string propertyName, ServiceOperation operation)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();

            if (operation.NoPipelineParameter)
            {
                WriteSimpleProperty("omitPipelineByValue", true);
            }
            else
            {
                // empty list causes us to defer to overall model settings
                WriteStringListProperty("byValueMembers", new[] { operation.PipelineParameter });
            }

            // this is always an empty construct in the current generator, the new generator has
            // the ability to annotate parameters that can be piped by matching parameter name.
            WriteStringListProperty("byNameMembers", new string[] { });

            _jsonWriter.WriteEndObject();
        }

        private void WriteServiceOperationLegacySettings(string propertyName, ServiceOperation operation)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("alias", operation.LegacyAlias);
            WriteStringListProperty("positionalParameters", operation.PositionalParametersList);
            WriteSimpleProperty("disableMemoryStreamTypeRemap", (!operation.RemapMemoryStreamParameters).ToString().ToLower());
            _jsonWriter.WriteEndObject();
        }

        /// <summary>
        /// Write the ending portion of the config file and close it.
        /// </summary>
        internal void Close()
        {
            // end the JSON config
            _jsonWriter.WriteEndObject();

            _streamWriter.Close();
        }

        public void Dispose()
        {
            Close();
        }

        private void WriteServiceGlobalValues()
        {
            // keeping this section in alpha order for easier lookup/comparison

            WriteCustomAliasesList();

            WriteInputObjectMappingRulesList();

            WriteServiceGlobalLegacySettings("legacySettings");

            WriteServiceGlobalSdkSettings("netSdk");

            WriteStringListProperty("nonFlattenedTypeNames", Model.TypesNotToFlatten);
            
            WriteMapListProperty("nounMaps", Model.NounMappingsList);

            WriteStringListProperty("outputMetadataMembers", Model.MetadataPropertyNames);

            WritePaginationSettings("paginationDefaults", Model.AutoIterate);

            _jsonWriter.WritePropertyName("pipelineDefaults");
            _jsonWriter.WriteStartObject();
                WriteStringListProperty("byValueMembers", new[] { Model.PipelineParameter });
                WriteStringListProperty("byNameMembers", Model.PipelineByNamePropertyNamesList);
            _jsonWriter.WriteEndObject();

            WriteSimpleProperty("nonSpecifiedRegionFallback", Model.DefaultRegion);

            WriteStringListProperty("supportsShouldProcessVerbs", Model.SupportsShouldProcessVerbsList);

            WriteMapListProperty("verbMaps", Model.VerbMappingsList);
        }

        private void WriteServiceGlobalSdkSettings(string propertyName)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();
            WriteStringListProperty("additionalNamespaces", Model.AdditionalNamespaces);
            WriteSimpleProperty("serviceClientClass", Model.ServiceClient);
            WriteSimpleProperty("serviceConfigClass", Model.ServiceClientConfig);
            WriteSimpleProperty("serviceNamespace", Model.ServiceNamespace);
            _jsonWriter.WriteEndObject();
        }

        private void WriteServiceGlobalLegacySettings(string propertyName)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("nounPrefix", Model.ServiceNounPrefix);
            WriteStringListProperty("positionalMemberNames", Model.PositionalParametersList);
            WriteParamEmittersList();
            _jsonWriter.WriteEndObject();
        }

        private void WriteSimpleProperty(string propertyName, string value)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteValue(value ?? string.Empty);
        }

        private void WriteSimpleProperty(string propertyName, bool value)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteValue(value.ToString().ToLower());
        }

        private void WriteSimpleProperty(string propertyName, int value)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteValue(value);
        }

        private void WriteStringListProperty(string propertyName, IEnumerable<string> list)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartArray();
            if (list != null && list.Any())
            {
                foreach (var v in list)
                {
                    if (!string.IsNullOrEmpty(v))
                        _jsonWriter.WriteValue(v);
                }
            }
            _jsonWriter.WriteEndArray();
        }

        private void WriteObjectListProperty<T>(string propertyName, List<T> list, Action<T> writeObjectProperties)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartArray();
            if (list != null && list.Any())
            {
                foreach (var obj in list)
                {
                    _jsonWriter.WriteStartObject();
                    writeObjectProperties(obj);
                    _jsonWriter.WriteEndObject();
                }
            }
            _jsonWriter.WriteEndArray();
        }

        private void WriteMapListProperty(string propertyName, List<Map> list)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();
            if (list != null && list.Any())
            {
                foreach (var map in list)
                {
                    WriteSimpleProperty(map.From, map.To);
                }
            }
            _jsonWriter.WriteEndObject();
        }

        private void WritePaginationSettings(string propertyName, AutoIteration autoIterate)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();

            if (autoIterate != null)
            {
                WriteStringListProperty("excludedOperations", autoIterate.ExclusionSet);
                WriteSimpleProperty("requestMember", autoIterate.Start);
                WriteSimpleProperty("responseMember", autoIterate.Next);
                WriteSimpleProperty("resultLimitMember", autoIterate.EmitLimit);
                if (autoIterate.ServicePageSize == -1)
                    WriteSimpleProperty("forceMaxResultSize", false);
                else
                {
                    WriteSimpleProperty("forceMaxResultSize", true);
                    WriteSimpleProperty("maxResultSize", autoIterate.ServicePageSize);
                }

                WriteSimpleProperty("resultsTruncatedMember", autoIterate.TruncatedFlag);
            }

            _jsonWriter.WriteEndObject();
        }

        private void WritePassThruObject(PassThruOverride passThru)
        {
            _jsonWriter.WritePropertyName("passThru");
            _jsonWriter.WriteStartObject();
            if (passThru != null)
            {
                WriteSimpleProperty("documentation", passThru.Documentation);
                WriteSimpleProperty("memberSelector", passThru.Expression);
                // type of the passthru is inferable, so we don't output that
            }
            _jsonWriter.WriteEndObject();
        }

        private void WriteAnalyzerResults(OperationAnalyzer analyzer)
        {
            _jsonWriter.WritePropertyName("tempAnalyzerResults");
            _jsonWriter.WriteStartObject();
                WriteSimpleProperty("confirmationMessageNoun", analyzer.ConfirmationMessageNoun);
                WriteSimpleProperty("confirmImpactSetting", analyzer.ConfirmImpactSetting.ToString());
                WriteSimpleProperty("generateIterationCode", analyzer.GenerateIterationCode.ToString().ToLower());
                WriteSimpleProperty("iterationPattern", analyzer.IterationPattern.ToString());
                WriteSimpleProperty("passThruSource", analyzer.PassThruSource);
                if (analyzer.RequiresPassThruGeneration)
                    WriteSimpleProperty("passThruTypeName", analyzer.PassThruTypeName);
                else
                    WriteSimpleProperty("passThruTypeName", "");
                WriteSimpleProperty("requiresPassThruGeneration", analyzer.RequiresPassThruGeneration.ToString().ToLower());
                WritePaginationSettings("autoIterateSettings", analyzer.AutoIterateSettings);

                WriteSupportsShouldProcessInspectionResult(analyzer.SupportsShouldProcessInspectionResult);
                WriteStringListProperty("memoryStreamParameters", analyzer.MemoryStreamParameters);
            _jsonWriter.WriteEndObject();
        }

        private void WriteSupportsShouldProcessInspectionResult(SupportsShouldProcessInspection supportsShouldProcessInspectionResult)
        {
            if (supportsShouldProcessInspectionResult == null)
                return;

            _jsonWriter.WritePropertyName("supportsShouldProcessInspectionResult");
            _jsonWriter.WriteStartObject();
                WriteSimpleProperty("analysisMessage", supportsShouldProcessInspectionResult.AnalysisMessage);
                WriteSimpleProperty("status", supportsShouldProcessInspectionResult.Status.ToString());
                WriteSimpleProperty("targetParameterName",
                    supportsShouldProcessInspectionResult.TargetParameter == null
                        ? ""
                        : supportsShouldProcessInspectionResult.TargetParameter.Name);
            _jsonWriter.WriteEndObject();
        }

        private void WriteCustomAliasesList()
        {
            WriteObjectListProperty("customAliases", Model.CustomAliasesList,
                (aliasSet) =>
                {
                    WriteSimpleProperty("cmdlet", aliasSet.Cmdlet);
                    WriteStringListProperty("aliasNames", aliasSet.Aliases);
                });
        }

        private void WriteInputObjectMappingRulesList()
        {
            WriteObjectListProperty("inputObjectMappingRules", Model.InputObjectMappingRulesList,
                (inputObjectMapping) =>
                {
                    WriteSimpleProperty("isGlobalReference", inputObjectMapping.IsGlobalReference.ToString().ToLower());
                    WriteSimpleProperty("mappingReferenceName", inputObjectMapping.MappingRefName);
                    WriteObjectListProperty("mappingRules", inputObjectMapping.MappingRules,
                        (mappingRule) =>
                        {
                            WriteSimpleProperty("helpDescription", mappingRule.HelpDescription);
                            WriteSimpleProperty("memberName", mappingRule.MemberName);
                            WriteSimpleProperty("parameterName", mappingRule.ParamName);
                        });
                    WriteSimpleProperty("typeName", inputObjectMapping.TypeName);
                });
        }

        private void WriteParamEmittersList()
        {
            WriteObjectListProperty("parameterEmitters", Model.ParamEmittersList,
                (paramEmitter) =>
                {
                    WriteSimpleProperty("emitterType", paramEmitter.EmitterType);
                    WriteStringListProperty("exclusions", new [] { paramEmitter.Exclude });
                    WriteSimpleProperty("emittedParameterName", paramEmitter.ParamName);
                    WriteSimpleProperty("emittedTypeName", paramEmitter.ParamType);
                });
        }
    }
}
