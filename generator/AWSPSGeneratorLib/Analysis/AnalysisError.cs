using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.ServiceConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSPowerShellGenerator.Analysis
{
    public struct AnalysisError
    {
        public readonly string Service;
        public readonly string Operation;
        public readonly string Message;

        private AnalysisError(ConfigModel service, ServiceOperation operation, string message)
        {
            Service = service.ServiceName;
            Operation = operation?.MethodName;
            Message = message;

            if (operation != null)
            {
                operation.AnalysisErrors.Add(this);
            }
            else
            {
                service.AnalysisErrors.Add(this);
            }
        }

        public override string ToString()
        {
            if (Operation != null)
            {
                return $"{Service} - {Operation}. {Message}";
            }
            return $"{Service}. {Message}";
        }

        public static void NonExistingMetadataProperties(ConfigModel service, ServiceOperation operation, IEnumerable<string> propertyNames)
        {
            new AnalysisError(service, operation, $"The following configured metadata properties don't exist: {FormatList(propertyNames)}.");
        }

        public static void SkipOutputComputationCheckError(ConfigModel service, ServiceOperation operation, ServiceOperation.OutputMode identifiedOutputMode)
        {
            new AnalysisError(service, operation, $"The cmdlet has 'Output' configuration '{operation.Output}' but analysis has identified an output type of '{identifiedOutputMode}'; conversion from '{operation.Output}' to '{identifiedOutputMode}' cannot be forced by 'SkipOutputComputationCheck'.");
        }

        public static void OutputTypeError(ConfigModel service, ServiceOperation operation, ServiceOperation.OutputMode identifiedOutputMode)
        {
            string guidance = "";
            if (operation.Output == ServiceOperation.OutputMode.Response && identifiedOutputMode == ServiceOperation.OutputMode.DefaultSingleMember)
            {
                guidance = " Output type 'Response' can be left unchanged by setting 'SkipOutputComputationCheck=\"true\"'.";
            }
            else if (identifiedOutputMode == ServiceOperation.OutputMode.Response ||
                     identifiedOutputMode == ServiceOperation.OutputMode.DefaultSingleMember)
            {
                guidance = $" In case all new output fields are unlikely to be useful to users, output type '{operation.Output}' can be left unchanged by adding all new parameters in 'MetadataProperties=\"\"'. Common metadata properties are: copies of input parameters, pagination-related parameters...";
            }
            new AnalysisError(service, operation, $"The cmdlet has 'Output' configuration '{operation.Output}' but analysis has identified an output type of '{identifiedOutputMode}'; this is a breaking change.{guidance}");
        }

        public static void PaginatedCmdletShouldReturnSingleProperty(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"The cmdlet is configured for automatic pagination but its 'Output' configuration is not 'DefaultSingleMember'. If all output properties, except for one paginated list, are unlikely to be useful to users, change the configuration to 'Output=\"DefaultSingleMember\"' and add all parameters but the list to 'MetadataProperties=\"\"'. If the cmdlet is not supposed to support automated pagination, add it to the <AutoIterate Exclusions=\"\" /> list of this service.");
        }

        public static void InvalidPassThruConfiguration(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"Invalid 'PassThru' configuration.");
        }

        public static void InvalidPassThruType(ConfigModel service, ServiceOperation operation, SimplePropertyInfo.PropertyCollectionType type)
        {
            new AnalysisError(service, operation, $"Cannot configure a {type} parameter as 'PassThru'.");
        }

        public static void MissingOutputWrapperProperty(ConfigModel service, ServiceOperation operation, string propertyName)
        {
            new AnalysisError(service, operation, $"The response type of the operation doesn't contain a property named '{propertyName}', the 'OutputWrapper' configuration is invalid.");
        }

        public static void CannotDetermineVerbAndNoun(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"Cannot determine 'Verb' and 'Noun' for this operation.");
        }

        public static void UnapprovedVerb(ConfigModel service, ServiceOperation operation, string verb)
        {
            new AnalysisError(service, operation, $"'{verb}' is not a valid verb (see https://docs.microsoft.com/en-us/powershell/developer/cmdlet/approved-verbs-for-windows-powershell-commands).");
        }

        public static void MustUpdateVerbAndNoun(ConfigModel service, ServiceOperation operation, string suggestedVerb, string suggestedNoun)
        {
            new AnalysisError(service, operation, $"'Verb' or 'Noun' configurations must be updated, Suggested values are '{suggestedVerb}' and '{suggestedNoun}'.");
        }

        public static void ConfiguredNounIsPlural(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"'Noun' configuration '{operation.RequestedNoun}' cannot end with a plural word or with a plural word followed by 'List'.");
        }

        public static void DuplicatedParameterNames(ConfigModel service, ServiceOperation operation, IEnumerable<string> duplicatedNames)
        {
            new AnalysisError(service, operation, $"Duplicated parameter names: {FormatList(duplicatedNames)}.");
        }

        public static void DuplicatedAliasNames(ConfigModel service, ServiceOperation operation, IEnumerable<string> duplicatedNames)
        {
            new AnalysisError(service, operation, $"Duplicated alias names: {FormatList(duplicatedNames)}.");
        }

        public static void ReservedParameterNames(ConfigModel service, ServiceOperation operation, IEnumerable<string> reservedNames)
        {
            new AnalysisError(service, operation, $"The following parameters use names that are reserved: {FormatList(reservedNames)}. A different name can be provided by configuring '<Param Name=\"ReservedName\" NewName=\"AlternateName\" AutoApplyAlias=\"false\" />'.");
        }

        public static void ReservedAliasNames(ConfigModel service, ServiceOperation operation, IEnumerable<string> reservedNames)
        {
            new AnalysisError(service, operation, $"The following aliases are reserved: {FormatList(reservedNames)}.");
        }

        public static void AliasParameterConflicts(ConfigModel service, ServiceOperation operation, IEnumerable<string> conflictingNames)
        {
            new AnalysisError(service, operation, $"There are conflicts between alias and parameter names: {FormatList(conflictingNames)}.");
        }

        public static void InvalidPipelineConfiguration(ConfigModel service, ServiceOperation operation, string pipelineParameter, IEnumerable<SimplePropertyInfo> candidatePipelineParameters)
        {
            new AnalysisError(service, operation, $"'PipelineParameter' is not a valid parameter name, valid options are : {FormatList(candidatePipelineParameters.Select(param => param.AnalyzedName))}.");
        }

        public static void MissingPipelineConfiguration(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> candidateParameters)
        {
            new AnalysisError(service, operation, $"Missing 'PipelineParameter' configuration, valid options are : {FormatList(candidateParameters.Select(param => param.AnalyzedName))}. In case none of the parameters is a valid candidate, configure 'NoPipelineParameter=\"true\"'.");
        }

        public static void OutdatedPipelineConfiguration(ConfigModel service, ServiceOperation operation, string suggestedParam)
        {
            new AnalysisError(service, operation, $"'PipelineParameter' configuration is not valid, the suggested value is {suggestedParam}.");
        }

        public static void MultipleTargetsForShouldProcessParameter(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> candidateParameters)
        {
            new AnalysisError(service, operation, $"Missing 'ShouldProcessTarget' configuration, valid options are: {FormatList(candidateParameters.Select(param => param.AnalyzedName))}. In case none of the parameters is a valid candidate, configure 'AnonymousShouldProcessTarget=\"true\"'.");
        }

        public static void OutdatedShouldProcessTargetConfiguration(ConfigModel service, ServiceOperation operation, string suggestedParam)
        {
            new AnalysisError(service, operation, $"'ShouldProcessTarget' configuration is not valid, the suggested value is {suggestedParam}.");
        }

        public static void InvalidShouldProcessTargetConfiguration(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> candidateParameters)
        {
            new AnalysisError(service, operation, $"'ShouldProcessTarget' configuration is not valid, valid options are: {FormatList(candidateParameters.Select(param => param.AnalyzedName))}.");
        }

        public static void PassThruConfiguredForNonVoidCmdlet(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, "'PassThru' can only be configured for cmdlets having 'Output=\"Void\"'.");
        }

        public static void ShouldProcessTargetMustBeEmpty(ConfigModel service, ServiceOperation operation)
        {
            if (operation.IgnoreSupportsShouldProcess)
            {
                new AnalysisError(service, operation, "This cmdlet is configured with 'IgnoreSupportsShouldProcess=\"true\"', 'ShouldProcessTarget' must be removed.");
            }
            else if (operation.AnonymousShouldProcessTarget)
            {
                new AnalysisError(service, operation, "This cmdlet is configured with 'AnonymousShouldProcessTarget=\"true\"', 'ShouldProcessTarget' must be removed.");
            }
            else
            {
                new AnalysisError(service, operation, "This cmdlet doesn't require confirmation and 'ShouldProcessTarget' must be removed.");
            }
        }

        public static void NonConfiguredPassThru(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, "'PassThru' must have valid 'Expression' and 'Documentation' configurations.");
        }

        public static void DuplicatedLegacyAlias(ConfigModel service, string alias, string cmdletName, string existingCmdletName)
        {
            new AnalysisError(service, null, $"Cannot add {alias} for cmdlet {cmdletName} because it is already assigned to cmdlet {existingCmdletName}");
        }

        public static void DuplicatedServicePrefix(ConfigModel service, IEnumerable<ConfigModel> services)
        {
            new AnalysisError(service, null, $"'<ServiceNounPrefix>{service.ServiceNounPrefix}</ServiceNounPrefix>' is used for multiple services: {FormatList(services.Select(model => model.ServiceName))}. Each service must have a unique prefix.");
        }

        public static void DuplicatedCmdletName(ConfigModel service, ServiceOperation operation, IEnumerable<ServiceOperation> operations)
        {
            new AnalysisError(service, operation, $"Multiple operations are configured with the same 'Verb' and 'Noun': {FormatList(operations.Select(op => op.MethodName))}");
        }

        public static void AdvancedCmdletNameConflict(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"'Verb' and 'Noun' configurations are in use by an existing custom cmdlet.");
        }

        public static void ExceptionWhileWritingCmdletCode(ConfigModel service, ServiceOperation operation, Exception exception)
        {
            new AnalysisError(service, operation, $"Error while generating cmdlet code: {exception.ToString()}");
        }

        public static void ExceptionWhileWritingServiceClientCode(ConfigModel service, Exception exception)
        {
            new AnalysisError(service, null, $"Error while generating service client code: {exception.ToString()}");
        }

        public static void MissingSDKMethodForCmdletConfiguration(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, "Missing SDK method corresponding to this configuration.");
        }

        public static void ExceptionWhileAnalyzingSDKLibrary(ConfigModel service, ServiceOperation operation, Exception exception)
        {
            new AnalysisError(service, operation, $"Error while analyzing SDK library: {exception.ToString()}");
        }

        public static void ExceptionWhileGeneratingForService(ConfigModel service, Exception exception)
        {
            new AnalysisError(service, null, $"Error during code generation: {exception.ToString()}");
        }

        private static string FormatList(IEnumerable<string> list)
        {
            return string.Join(", ", list);
        }
    }
}
