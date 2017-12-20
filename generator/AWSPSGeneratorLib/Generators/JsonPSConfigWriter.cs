using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.CmdletConfig;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

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
            OutputPath = Path.Combine(outputFolder, configModel.SourceGenerationFolder + ".json");
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
            _jsonWriter.WritePropertyName("Operations");
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
                WriteSimpleProperty("Exclude", "true");
                _jsonWriter.WriteEndObject();

                return;
            }

            var analyzer = operation.Analyzer;

            _jsonWriter.WritePropertyName(operation.MethodName);
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("Verb", analyzer.CurrentOperation.SelectedVerb);
            WriteSimpleProperty("Noun", analyzer.CurrentOperation.SelectedNoun);
            WriteSimpleProperty("AnonymousAuthentication", analyzer.CurrentOperation.AnonymousAuthentication.ToString());
            WriteSimpleProperty("AnonymousShouldProcessTarget", analyzer.CurrentOperation.AnonymousShouldProcessTarget.ToString().ToLower());
            WriteSimpleProperty("IgnoreSupportsShouldProcess", analyzer.CurrentOperation.IgnoreSupportsShouldProcess.ToString().ToLower());
            WriteSimpleProperty("LegacyAlias", analyzer.CurrentOperation.LegacyAlias);
            WriteSimpleProperty("MetadataProperties", analyzer.CurrentOperation.MetadataProperties);
            WriteSimpleProperty("NoPipelineParameter", analyzer.CurrentOperation.NoPipelineParameter.ToString().ToLower());
            WriteSimpleProperty("Output", analyzer.CurrentOperation.Output.ToString());
            WriteSimpleProperty("OutputWrapper", analyzer.CurrentOperation.OutputWrapper);
            WriteSimpleProperty("PipelineParameter", analyzer.CurrentOperation.PipelineParameter);
            WriteSimpleProperty("PositionalParameters", analyzer.CurrentOperation.PositionalParameters);
            WriteSimpleProperty("RemapMemoryStreamParameters", analyzer.CurrentOperation.RemapMemoryStreamParameters.ToString().ToLower());
            WriteSimpleProperty("ShouldProcessMsgNoun", analyzer.CurrentOperation.ShouldProcessMsgNoun);
            WriteSimpleProperty("ShouldProcessTarget", analyzer.CurrentOperation.ShouldProcessTarget);

            if (analyzer.CurrentOperation.AutoIterate != null)
                WriteAutoIterateObject("AutoIterate", analyzer.CurrentOperation.AutoIterate);

            if (analyzer.CurrentOperation.CustomParametersList != null &&
                analyzer.CurrentOperation.CustomParametersList.Count > 0)
            {
                WriteObjectListProperty("CustomParametersList", analyzer.CurrentOperation.CustomParametersList,
                    (param) =>
                    {
                        WriteSimpleProperty("Name", param.Name);
                        WriteSimpleProperty("Aliases", param.AliasesList);
                        WriteSimpleProperty("AutoApplyAlias", param.AutoApplyAlias.ToString().ToLower());
                        WriteSimpleProperty("AutoRename", param.AutoRename.ToString().ToLower());
                        WriteSimpleProperty("Exclude", param.Exclude.ToString().ToLower());
                        WriteSimpleProperty("NewName", param.NewName);
                    });
            }
            WritePassThruObject(analyzer.CurrentOperation.PassThru);

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
            WriteStringListProperty("AdditionalNamespaces", Model.AdditionalNamespaces);
            WriteSimpleProperty("DefaultRegion", Model.DefaultRegion);
            WriteSimpleProperty("IsS3", Model.IsS3.ToString().ToLower());
            WriteStringListProperty("MetadataPropertyNames", Model.MetadataPropertyNames);
            WriteStringListProperty("PipelineByValuePropertyNamesList", Model.PipelineByValuePropertyNamesList);
            WriteSimpleProperty("PipelineParameter", Model.PipelineParameter);
            WriteSimpleProperty("PositionalParameters", Model.PositionalParameters);
            WriteSimpleProperty("ServiceClient", Model.ServiceClient);
            WriteSimpleProperty("ServiceClientConfig", Model.ServiceClientConfig);
            WriteSimpleProperty("ServiceClientInterface", Model.ServiceClientInterface);
            WriteSimpleProperty("ServiceName", Model.ServiceName);
            WriteSimpleProperty("ServiceNamespace", Model.ServiceNamespace);
            WriteSimpleProperty("ServiceNounPrefix", Model.ServiceNounPrefix);
            WriteStringListProperty("SupportsShouldProcessVerbsList", Model.SupportsShouldProcessVerbsList);
            WriteStringListProperty("TypesNotToFlatten", Model.TypesNotToFlatten);

            WriteAutoIterateObject("AutoIterate", Model.AutoIterate);
            WriteCustomAliasesList();
            WriteInputObjectMappingRulesList();
            WriteParamEmittersList();
            WriteMapListProperty("NounMappings", Model.NounMappingsList);
            WriteMapListProperty("VerbMappings", Model.VerbMappingsList);
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

        private void WriteStringListProperty(string propertyName, IEnumerable<string> list)
        {
            // May do an actual array in the future.  But comma delimited for now.
            if (list == null)
                WriteSimpleProperty(propertyName, "");
            else
                WriteSimpleProperty(propertyName, String.Join(",", list));
        }

        private void WriteObjectListProperty<T>(string propertyName, List<T> list, Action<T> writeObjectProperties)
        {
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

        private void WriteMapListProperty(string propertyName, List<Map> list)
        {
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
            WriteSimpleProperty("EmitLimit", autoIterate.EmitLimit);
            WriteSimpleProperty("Exclusions", autoIterate.Exclusions);
            WriteSimpleProperty("Next", autoIterate.Next);
            WriteSimpleProperty("ServicePageSize", autoIterate.ServicePageSize);
            WriteSimpleProperty("Start", autoIterate.Start);
            WriteSimpleProperty("TruncatedFlag", autoIterate.TruncatedFlag);
            _jsonWriter.WriteEndObject();
        }

        private void WritePassThruObject(PassThruOverride passThru)
        {
            if (passThru == null)
                passThru = new PassThruOverride();

            _jsonWriter.WritePropertyName("PassThru");
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("Documentation", passThru.Documentation);
            WriteSimpleProperty("Expression", passThru.Expression);
            WriteSimpleProperty("Type", passThru.Type);
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
                supportsShouldProcessInspectionResult = new SupportsShouldProcessInspection();

            _jsonWriter.WritePropertyName("SupportsShouldProcessInspectionResult");
            _jsonWriter.WriteStartObject();
            WriteSimpleProperty("AnalysisMessage", supportsShouldProcessInspectionResult.AnalysisMessage);
            WriteSimpleProperty("Status", supportsShouldProcessInspectionResult.Status.ToString());
            if (supportsShouldProcessInspectionResult.TargetParameter == null)
                WriteSimpleProperty("TargetParameterName", "");
            else
                WriteSimpleProperty("TargetParameterName", supportsShouldProcessInspectionResult.TargetParameter.Name);
            _jsonWriter.WriteEndObject();
        }

        private void WriteCustomAliasesList()
        {
            WriteObjectListProperty("CustomAliases", Model.CustomAliasesList,
                (aliasSet) =>
                {
                    WriteSimpleProperty("Cmdlet", aliasSet.Cmdlet);
                    WriteSimpleProperty("AliasesField", aliasSet.AliasesField);
                });
        }

        private void WriteInputObjectMappingRulesList()
        {
            WriteObjectListProperty("InputObjectMappingRules", Model.InputObjectMappingRulesList,
                (inputObjectMapping) =>
                {
                    WriteSimpleProperty("IsGlobalReference", inputObjectMapping.IsGlobalReference.ToString().ToLower());
                    WriteSimpleProperty("MappingRefName", inputObjectMapping.MappingRefName);
                    WriteSimpleProperty("TypeName", inputObjectMapping.TypeName);
                    WriteObjectListProperty("MappingRules", inputObjectMapping.MappingRules,
                        (mappingRule) =>
                        {
                            WriteSimpleProperty("HelpDescription", mappingRule.HelpDescription);
                            WriteSimpleProperty("MemberName", mappingRule.MemberName);
                            WriteSimpleProperty("ParamName", mappingRule.ParamName);
                        });
                });
        }

        private void WriteNounMappingsList()
        {
            WriteObjectListProperty("NounMappings", Model.NounMappingsList,
               (map) =>
               {
                   WriteSimpleProperty("From", map.From);
                   WriteSimpleProperty("To", map.To);
               });
        }

        private void WriteParamEmittersList()
        {
            WriteObjectListProperty("ParamEmitters", Model.ParamEmittersList,
                 (paramEmitter) =>
                 {
                     WriteSimpleProperty("EmitterType", paramEmitter.EmitterType);
                     WriteSimpleProperty("Exclude", paramEmitter.Exclude);
                     WriteSimpleProperty("ParamName", paramEmitter.ParamName);
                     WriteSimpleProperty("ParamType", paramEmitter.ParamType);
                 });
        }
    }
}
