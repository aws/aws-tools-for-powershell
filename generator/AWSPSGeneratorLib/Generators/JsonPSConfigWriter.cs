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
                WriteSimpleProperty("excludeFromGeneration", "true");
                _jsonWriter.WriteEndObject();

                return;
            }

            var analyzer = operation.Analyzer;

            _jsonWriter.WritePropertyName(operation.MethodName);
            _jsonWriter.WriteStartObject();

            // keep the most important verb and noun settings at the top, then go to alpha order for the rest
            WriteSimpleProperty("verb", analyzer.CurrentOperation.SelectedVerb);
            WriteSimpleProperty("noun",
                analyzer.CurrentOperation.SelectedNoun.Substring(analyzer.CurrentModel.ServiceNounPrefix.Length));

            if (analyzer.CurrentOperation.CustomParametersList != null)
            {
                WriteObjectListProperty("customParameters", analyzer.CurrentOperation.CustomParametersList,
                    (param) =>
                    {
                        WriteSimpleProperty("name", param.Name);
                        if (!string.IsNullOrEmpty(param.NewName))
                            WriteSimpleProperty("newName", param.NewName);
                        if (!string.IsNullOrEmpty(param.AliasesList))
                            WriteStringListProperty("aliases", param.AliasesList.Split(';'));
                        if (!param.AutoApplyAlias)
                            WriteSimpleProperty("autoApplyAlias", "false");
                        if (!param.AutoRename)
                            WriteSimpleProperty("autoRename", "false");
                        if (param.Exclude)
                            WriteSimpleProperty("exclude", "true");
                    });
            }

            if (!string.IsNullOrEmpty(analyzer.CurrentOperation.LegacyAlias))
                WriteSimpleProperty("legacyAlias", analyzer.CurrentOperation.LegacyAlias);

            if (analyzer.CurrentOperation.PositionalParameters != null)
                WriteStringListProperty("legacyPositionalParameters",
                    analyzer.CurrentOperation.PositionalParameters.Split(';'));

            if (!string.IsNullOrEmpty(analyzer.CurrentOperation.MetadataProperties))
                WriteStringListProperty("outputMetadataPropertyNames", analyzer.CurrentOperation.MetadataProperties.Split(';'));

            if (analyzer.CurrentOperation.NoPipelineParameter)
                WriteSimpleProperty("noPipelineProperty", "true");

            if (analyzer.CurrentOperation.AutoIterate != null)
                WriteAutoIterateObject("paginationSettings", analyzer.CurrentOperation.AutoIterate);

            WritePassThruObject(analyzer.CurrentOperation.PassThru);

            if (!string.IsNullOrEmpty(analyzer.CurrentOperation.PipelineParameter))
                WriteSimpleProperty("pipelineProperty", analyzer.CurrentOperation.PipelineParameter);

            if (analyzer.CurrentOperation.Output != ServiceOperation.OutputMode.Default)
                WriteSimpleProperty("output", analyzer.CurrentOperation.Output.ToString());

            if (!string.IsNullOrEmpty(analyzer.CurrentOperation.OutputWrapper))
                WriteSimpleProperty("outputWrapperMember", analyzer.CurrentOperation.OutputWrapper);

            if (!analyzer.CurrentOperation.RemapMemoryStreamParameters)
                WriteSimpleProperty("remapMemoryStreamParameters", "false");

            if (!string.IsNullOrEmpty(analyzer.CurrentOperation.ShouldProcessMsgNoun))
                WriteSimpleProperty("shouldProcessMsgNoun", analyzer.CurrentOperation.ShouldProcessMsgNoun);

            if (!string.IsNullOrEmpty(analyzer.CurrentOperation.ShouldProcessTarget))
                WriteSimpleProperty("shouldProcessTargetProperty", analyzer.CurrentOperation.ShouldProcessTarget);

            if (analyzer.CurrentOperation.IgnoreSupportsShouldProcess)
                WriteSimpleProperty("suppressShouldProcessConfirmation", "true");

            if (analyzer.CurrentOperation.AnonymousAuthentication != ServiceOperation.AnonymousAuthenticationMode.Never)
                WriteSimpleProperty("useAnonymousAuthentication", analyzer.CurrentOperation.AnonymousAuthentication.ToString());

            if (analyzer.CurrentOperation.AnonymousShouldProcessTarget)
                WriteSimpleProperty("useAnonymousShouldProcessTarget", "true");

            // these are transient in the move to the new generator, so keep at end
            WriteAnalyzerResults(analyzer);

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

            WriteStringListProperty("additionalNamespaces", Model.AdditionalNamespaces);
            WriteCustomAliasesList();
            WriteAutoIterateObject("defaultPaginationSettings", Model.AutoIterate);
            WriteSimpleProperty("defaultPipelineProperty", Model.PipelineParameter);

            WriteSimpleProperty("legacyCmdletPrefix", Model.ServiceNounPrefix);
            if (!string.IsNullOrEmpty(Model.PositionalParameters))
                WriteSimpleProperty("legacyPositionalProperties", Model.PositionalParameters);

            WriteInputObjectMappingRulesList();

            WriteStringListProperty("nonFlatteningTypeNames", Model.TypesNotToFlatten);
            
            WriteMapListProperty("nounMappings", Model.NounMappingsList);

            WriteStringListProperty("outputMetadataPropertyNames", Model.MetadataPropertyNames);
            WriteStringListProperty("pipelineByValuePropertyNames", Model.PipelineByValuePropertyNamesList);

            WriteParamEmittersList();

            if (!string.IsNullOrEmpty(Model.DefaultRegion))
                WriteSimpleProperty("regionFallback", Model.DefaultRegion);

            WriteSimpleProperty("sdkServiceClientClass", Model.ServiceClient);
            WriteSimpleProperty("sdkServiceConfigClass", Model.ServiceClientConfig);
            WriteSimpleProperty("sdkServiceNamespace", Model.ServiceNamespace);

            WriteMapListProperty("verbMappings", Model.VerbMappingsList);

            WriteStringListProperty("verbsRequiringShouldProcessConfirmation", Model.SupportsShouldProcessVerbsList);
        }

        private void WriteSimpleProperty(string propertyName, string value)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteValue(value);
        }

        private void WriteSimpleProperty(string propertyName, int value)
        {
            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteValue(value);
        }

        private void WriteStringListProperty(string propertyName, IEnumerable<string> list, bool skipIfNullOrEmpty = true)
        {
            if (skipIfNullOrEmpty && (list == null || !list.Any()))
                return;

            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartArray();
            if (list != null)
            {
                foreach (var v in list)
                {
                    _jsonWriter.WriteValue(v);
                }
            }
            _jsonWriter.WriteEndArray();
        }

        private void WriteObjectListProperty<T>(string propertyName, List<T> list, Action<T> writeObjectProperties, bool skipIfNullOrEmpty = true)
        {
            if (skipIfNullOrEmpty && (list == null || !list.Any()))
                return;

            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartArray();
            foreach (var obj in list)
            {
                _jsonWriter.WriteStartObject();
                writeObjectProperties(obj);
                _jsonWriter.WriteEndObject();
            }
            _jsonWriter.WriteEndArray();
        }

        private void WriteMapListProperty(string propertyName, List<Map> list, bool skipIfNullOrEmpty = true)
        {
            if (skipIfNullOrEmpty && (list == null || !list.Any()))
                return;

            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();
            foreach (var map in list)
            {
                WriteSimpleProperty(map.From, map.To);
            }
            _jsonWriter.WriteEndObject();
        }

        private void WriteAutoIterateObject(string propertyName, AutoIteration autoIterate)
        {
            if (autoIterate == null)
                autoIterate = new AutoIteration();

            _jsonWriter.WritePropertyName(propertyName);
            _jsonWriter.WriteStartObject();

            if (!string.IsNullOrEmpty(autoIterate.Exclusions))
                WriteStringListProperty("excludedOperations", autoIterate.ExclusionSet);
            
            WriteSimpleProperty("requestTokenMember", autoIterate.Start);
            WriteSimpleProperty("responseTokenMember", autoIterate.Next);
            
            if (!string.IsNullOrEmpty(autoIterate.EmitLimit))
                WriteSimpleProperty("resultLimitMember", autoIterate.EmitLimit);
            
            if (autoIterate.ServicePageSize != -1)
                WriteSimpleProperty("servicePageSize", autoIterate.ServicePageSize);
            
            if (!string.IsNullOrEmpty(autoIterate.TruncatedFlag))
                WriteSimpleProperty("resultsTruncatedMember", autoIterate.TruncatedFlag);
            
            _jsonWriter.WriteEndObject();
        }

        private void WritePassThruObject(PassThruOverride passThru)
        {
            if (passThru == null)
                return;

            _jsonWriter.WritePropertyName("passThru");
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("documentation", passThru.Documentation);
            WriteSimpleProperty("expression", passThru.Expression);
            WriteSimpleProperty("type", passThru.Type);
            _jsonWriter.WriteEndObject();
        }

        private void WriteAnalyzerResults(OperationAnalyzer analyzer)
        {
            _jsonWriter.WritePropertyName("AnalyzerResults");
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("ConfirmationMessageNoun", analyzer.ConfirmationMessageNoun);
            WriteSimpleProperty("ConfirmImpactSetting", analyzer.ConfirmImpactSetting.ToString());
            WriteSimpleProperty("GenerateIterationCode", analyzer.GenerateIterationCode.ToString().ToLower());
            WriteSimpleProperty("IterationPattern", analyzer.IterationPattern.ToString());
            WriteSimpleProperty("PassThruSource", analyzer.PassThruSource);
            if (analyzer.RequiresPassThruGeneration)
                WriteSimpleProperty("PassThruTypeName", analyzer.PassThruTypeName);
            else
                WriteSimpleProperty("PassThruTypeName", "");
            WriteSimpleProperty("RequiresPassThruGeneration", analyzer.RequiresPassThruGeneration.ToString().ToLower());
            WriteAutoIterateObject("AutoIterateSettings", analyzer.AutoIterateSettings);

            WriteSupportsShouldProcessInspectionResult(analyzer.SupportsShouldProcessInspectionResult);
            WriteStringListProperty("MemoryStreamParameters", analyzer.MemoryStreamParameters);
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
            if (supportsShouldProcessInspectionResult.TargetParameter == null)
                WriteSimpleProperty("targetParameterName", "");
            else
                WriteSimpleProperty("targetParameterName", supportsShouldProcessInspectionResult.TargetParameter.Name);
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
                    WriteSimpleProperty("mappingRefName", inputObjectMapping.MappingRefName);
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
            WriteObjectListProperty("legacyParamEmitters", Model.ParamEmittersList,
                (paramEmitter) =>
                {
                    WriteSimpleProperty("emitterType", paramEmitter.EmitterType);
                    WriteSimpleProperty("exclude", paramEmitter.Exclude);
                    WriteSimpleProperty("paramName", paramEmitter.ParamName);
                    WriteSimpleProperty("paramType", paramEmitter.ParamType);
                });
        }
    }
}
