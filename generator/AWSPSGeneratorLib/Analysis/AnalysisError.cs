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

        private AnalysisError(ConfigModel service, string message)
            : this(service, null, message)
        {
        }

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

        public static void OutputWrapperOutputPropertyConflict(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"'OutputWrapper=\"{operation.OutputWrapper}\"' is set, configure 'OutputProperty=\"{operation.OutputWrapper}\"' or 'OutputProperty=\"{operation.OutputWrapper}.SomePropertyName\"'.");
        }

        public static void OutputTypeError(ConfigModel service, ServiceOperation operation, int propertyCount)
        {
            if (propertyCount == 0)
            {
                new AnalysisError(service, operation, "This operation doesn't return any property. The 'OutputProperty' attribute must be removed.");
            }
            else
            {
                new AnalysisError(service, operation, $"This operation returns {propertyCount} properties. Configure 'OutputProperty=\"*\" if you want the cmdlet to return the whole response object or OutputProperty=\"PropertyName\" to return a specific property'.");
            }
        }

        public static void NonExistingOutputProperty(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"The specified 'OutputProperty=\"{operation.OutputProperty}\"' doesn't exist in the class returned by the service operation.");
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
            new AnalysisError(service, operation, $"'{verb}' is not a valid verb (see https://docs.microsoft.com/en-us/powershell/scripting/developer/cmdlet/approved-verbs-for-windows-powershell-commands).");
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

        public static void NoPipelineParameterAndPipelineParameterSpecified(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"'PipelineParameter' must be an emtpy string when 'NoPipelineParameter' is specified.");
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
            new AnalysisError(service, operation, $"'ShouldProcessTarget' configuration is not valid, the suggested value is 'ShouldProcessTarget=\"{suggestedParam}\"'.");
        }

        public static void InvalidShouldProcessTargetConfiguration(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> candidateParameters)
        {
            new AnalysisError(service, operation, $"'ShouldProcessTarget' configuration is not valid, valid options are: {FormatList(candidateParameters.Select(param => param.AnalyzedName))}.");
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

        internal static void StreamParametersNotSupportedForPaginatedCmdlets(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> streamParameters)
        {
            new AnalysisError(service, operation, "Pagination is not supported for cmdlets with stream parameters.");
        }

        public static void DuplicatedLegacyAlias(ConfigModel service, string alias, string cmdletName, string existingCmdletName)
        {
            new AnalysisError(service, $"Cannot add {alias} for cmdlet {cmdletName} because it is already assigned to cmdlet {existingCmdletName}");
        }

        public static void DuplicatedServicePrefix(ConfigModel service, IEnumerable<ConfigModel> services)
        {
            new AnalysisError(service, $"'<ServiceNounPrefix>{service.ServiceNounPrefix}</ServiceNounPrefix>' is used for multiple services: {FormatList(services.Select(model => model.ServiceName))}. Each service must have a unique prefix.");
        }

        public static void DuplicatedAssemblyName(IEnumerable<ConfigModel> services)
        {
            foreach (var service in services)
            {
                new AnalysisError(service, $"'<AssemblyName>{service.AssemblyName}</AssemblyName>' is used for multiple projects: {FormatList(services.Select(model => model.ServiceName))}. If multiple services share a single 'AssemblyName', all but one should have an empty '<ServiceModuleGuid />'.");
            }
        }

        public static void DuplicatedCmdletName(ConfigModel service, ServiceOperation operation, IEnumerable<ServiceOperation> operations)
        {
            new AnalysisError(service, operation, $"Multiple operations are configured with the same 'Verb' and 'Noun': {FormatList(operations.Select(op => op.MethodName))}");
        }

        public static void AdvancedCmdletNameConflict(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, $"'Verb' and 'Noun' configurations are in use by an existing custom cmdlet.");
        }

        public static void ExceptionWhileWritingServiceClientCode(ConfigModel service, Exception exception)
        {
            new AnalysisError(service, $"Error while generating service client code: {exception}");
        }

        public static void ExceptionWhileWritingCmdletCode(ConfigModel service, ServiceOperation operation, Exception exception)
        {
            new AnalysisError(service, operation, $"Error writing Cmdlet: {exception}");
        }

        public static void WrongFileVersionNumber(ConfigModel service)
        {
            new AnalysisError(service, $"Overrides for this service were ignored because they are marked with a different FileVersion number.");
        }

        public static void ExceptionWhileWritingServiceProjectFile(ConfigModel service, Exception exception)
        {
            new AnalysisError(service, $"Error while generating service project file: {exception}");
        }

        
        public static void MissingSDKMethodForCmdletConfiguration(ConfigModel service, ServiceOperation operation)
        {
            new AnalysisError(service, operation, "Missing SDK method corresponding to this configuration (verify the operation was not removed in the latest model revision).");
        }

        public static void ExceptionWhileAnalyzingSDKLibrary(ConfigModel service, ServiceOperation operation, Exception exception)
        {
            new AnalysisError(service, operation, $"Error while analyzing SDK library: {exception}");
        }

        public static void ExceptionWhileGeneratingForService(ConfigModel service, Exception exception)
        {
            new AnalysisError(service, $"Error during code generation: {exception}");
        }

        public static void InvalidServicePageSize(ConfigModel service, ServiceOperation operation, int servicePageSize, string emitLimitParameterName, long? minValue, long? maxValue)
        {
            if (!minValue.HasValue)
            {
                new AnalysisError(service, operation, $"'ServicePageSize={servicePageSize}' is invalid: parameter {emitLimitParameterName} value cannot be greater than {maxValue}.");
            }
            else if (!maxValue.HasValue)
            {
                new AnalysisError(service, operation, $"'ServicePageSize={servicePageSize}' is invalid: parameter {emitLimitParameterName} value cannot be smaller than {minValue}.");
            }
            else
            {
                new AnalysisError(service, operation, $"'ServicePageSize={servicePageSize}' is invalid: parameter {emitLimitParameterName} value must be between {minValue} and {maxValue}.");
            }
        }

        public static void ServicePageSizeIsRequired(ConfigModel service, ServiceOperation operation, string emitLimitParameterName)
        {
            new AnalysisError(service, operation, $"Parameter {emitLimitParameterName} is marked as required but the model doesn't provide a maximum accepted value. Add a 'ServicePageSize' tag to the 'AutoIterate' configuration of this operation.");
        }

        private static string FormatList(IEnumerable<string> list)
        {
            return string.Join(", ", list);
        }
        public static void ExceptionWhileGettingPaginatorAttributes(ConfigModel service, ServiceOperation operation, Exception exception)
        {
            new AnalysisError(service, operation, $"Error while getting paginator attributes: {exception}");
        }
        public static void ExceptionWhileLoadingPaginatorAttributes(ConfigModel service, Exception exception)
        {
            new AnalysisError(service, $"Error while loading paginator attributes: {exception}");
        }

        public static void NoPriorityVerbAvailable(ConfigModel service, ServiceOperation operation, string serviceOperationVerb, IEnumerable<string> availableVerbs)
        {
            var verbList = string.Join(", ", availableVerbs);
            new AnalysisError(service, operation, $"No suitable PowerShell verb available for service operation verb '{serviceOperationVerb}'. Available priority mappings: {verbList}. All mapped verbs are already in use by other operations in this service.");
        }
    }

    public struct InfoMessage
    {
        public readonly string Service;
        public readonly string Operation;
        public readonly string Message;

        private InfoMessage(ConfigModel service, ServiceOperation operation, string message)
        {
            Service = service.ServiceName;
            Operation = operation?.MethodName;
            Message = message;

            if (operation != null)
            {
                operation.InfoMessages.Add(this);
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

        public static void NoPipelineParameterCandidates(ConfigModel service, ServiceOperation operation)
        {
            new InfoMessage(service, operation, "No suitable pipeline parameter candidates found. Setting NoPipelineParameter=true for this new cmdlet.");
        }

        public static void SinglePipelineParameterCandidate(ConfigModel service, ServiceOperation operation, SimplePropertyInfo candidateParameter)
        {
            new InfoMessage(service, operation, $"Single pipeline parameter candidate found: {candidateParameter.AnalyzedName}. Automatically selected as PipelineParameter for this new cmdlet.");
        }

        public static void MultiplePipelineParameterCandidates(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> candidateParameters)
        {
            var candidateNames = string.Join(", ", candidateParameters.Select(param => param.AnalyzedName));
            new InfoMessage(service, operation, $"Multiple pipeline parameter candidates found: {candidateNames}. Setting NoPipelineParameter=true for this new cmdlet.");
        }

        public static void NoShouldProcessTargetParameters(ConfigModel service, ServiceOperation operation, IEnumerable<string> filteredParameterNames)
        {
            var parameterList = filteredParameterNames?.ToList() ?? new List<string>();
            var message = "No suitable ShouldProcessTarget parameters found after applying selection filters.";
            if (parameterList.Any())
            {
                message += $" The following parameter(s) were filtered out as they were either complex collection types, deprecated, or metadata parameters: {string.Join(", ", parameterList)}.";
            }
            new InfoMessage(service, operation, message);
        }

        public static void ShouldProcessTargetSelectedSingleParameter(ConfigModel service, ServiceOperation operation, SimplePropertyInfo selectedParameter)
        {
            new InfoMessage(service, operation, $"ShouldProcessTarget selected single parameter: {selectedParameter.AnalyzedName}");
        }

        public static void ShouldProcessTargetSelectedExactNounMatch(ConfigModel service, ServiceOperation operation, SimplePropertyInfo selectedParameter)
        {
            new InfoMessage(service, operation, $"ShouldProcessTarget selected exact noun match: {selectedParameter.AnalyzedName}");
        }

        public static void ShouldProcessTargetSelectedSingularizedNounMatch(ConfigModel service, ServiceOperation operation, SimplePropertyInfo selectedParameter)
        {
            new InfoMessage(service, operation, $"ShouldProcessTarget selected singularized noun match: {selectedParameter.AnalyzedName}");
        }

        public static void ShouldProcessTargetSelectedSuffixMatch(ConfigModel service, ServiceOperation operation, SimplePropertyInfo selectedParameter)
        {
            new InfoMessage(service, operation, $"ShouldProcessTarget selected suffix match: {selectedParameter.AnalyzedName}");
        }

        public static void ShouldProcessTargetSelectedNounPrefixMatch(ConfigModel service, ServiceOperation operation, SimplePropertyInfo selectedParameter)
        {
            new InfoMessage(service, operation, $"ShouldProcessTarget selected noun prefix match: {selectedParameter.AnalyzedName}");
        }

        public static void ShouldProcessTargetSelectedMultipleParameters(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> selectedParameters)
        {
            var parameterNames = string.Join(", ", selectedParameters.Select(param => param.AnalyzedName));
            new InfoMessage(service, operation, $"ShouldProcessTarget selected multiple parameters: {parameterNames}");
        }

        public static void ShouldProcessTargetMultipleCandidatesFound(ConfigModel service, ServiceOperation operation, IEnumerable<SimplePropertyInfo> candidateParameters)
        {
            var candidateNames = string.Join(", ", candidateParameters.Select(param => param.AnalyzedName));
            new InfoMessage(service, operation, $"ShouldProcessTarget multiple candidates found: {candidateNames}");
        }

        public static void ShouldProcessTargetSetToAnonymous(ConfigModel service, ServiceOperation operation)
        {
            new InfoMessage(service, operation, $"ShouldProcessTarget set to anonymous");
        }

        public static void PriorityVerbConflictDetected(ConfigModel service, ServiceOperation operation, string conflictingVerb, string predictedNoun)
        {
            new InfoMessage(service, operation, $"verb assignment: Priority verb '{conflictingVerb}' conflicts with existing Verb-Noun combination '{conflictingVerb}-{predictedNoun}'. Trying alternative priority verbs.");
        }

        public static void AlternativePriorityVerbSelected(ConfigModel service, ServiceOperation operation, string originalVerb, string selectedVerb, string predictedNoun)
        {
            new InfoMessage(service, operation, $"verb assignment: Selected alternative priority verb '{selectedVerb}' for operation verb '{originalVerb}' to avoid Verb-Noun conflict with '{selectedVerb}-{predictedNoun}'.");
        }

        public static void VerbAssignmentSingleWordOperation(ConfigModel service, ServiceOperation operation, string originalVerb)
        {
            new InfoMessage(service, operation, $"verb assignment: Single word operation '{originalVerb}' transformed to use 'Invoke' verb.");
        }

        public static void VerbAssignmentApprovedVerbUsed(ConfigModel service, ServiceOperation operation, string verb)
        {
            new InfoMessage(service, operation, $"verb assignment: Approved PowerShell verb '{verb}' used directly.");
        }

        public static void VerbAssignmentTransformationPatternApplied(ConfigModel service, ServiceOperation operation, string originalVerb, string transformedVerb)
        {
            new InfoMessage(service, operation, $"verb assignment: Transformation pattern applied - '{originalVerb}' transformed to '{transformedVerb}'.");
        }

        public static void VerbAssignmentPriorityVerbConflictDetected(ConfigModel service, ServiceOperation operation, string conflictingVerb, string predictedNoun)
        {
            new InfoMessage(service, operation, $"verb assignment: Priority verb '{conflictingVerb}' conflicts with existing Verb-Noun combination '{conflictingVerb}-{predictedNoun}'. Trying alternative priority verbs.");
        }

        public static void VerbAssignmentAlternativePriorityVerbSelected(ConfigModel service, ServiceOperation operation, string originalVerb, string selectedVerb, string predictedNoun)
        {
            new InfoMessage(service, operation, $"verb assignment: Selected alternative priority verb '{selectedVerb}' for operation verb '{originalVerb}' to avoid Verb-Noun conflict with '{selectedVerb}-{predictedNoun}'.");
        }

        public static void NounAssignmentSingleWordOperation(ConfigModel service, ServiceOperation operation, string methodName)
        {
            new InfoMessage(service, operation, $"noun assignment: Single word operation using method name '{methodName}' as noun.");
        }

        public static void NounAssignmentTransformationPatternApplied(ConfigModel service, ServiceOperation operation, string originalNoun, string transformedNoun, string patternName)
        {
            new InfoMessage(service, operation, $"noun assignment: Transformation pattern '{patternName}' applied - '{originalNoun}' transformed to '{transformedNoun}'.");
        }

        public static void NounAssignmentMappingApplied(ConfigModel service, ServiceOperation operation, string originalNoun, string mappedNoun, string mappingSource)
        {
            new InfoMessage(service, operation, $"noun assignment: {mappingSource} mapping applied - '{originalNoun}' mapped to '{mappedNoun}'.");
        }

        public static void NounAssignmentSingularizedWithCollection(ConfigModel service, ServiceOperation operation, string originalNoun, string finalNoun)
        {
            new InfoMessage(service, operation, $"noun assignment: Noun singularized and 'Collection' suffix added - '{originalNoun}' became '{finalNoun}'.");
        }

        public static void NounAssignmentPluralNounRuleApplied(ConfigModel service, ServiceOperation operation, string originalNoun, string finalNoun, string verb)
        {
            new InfoMessage(service, operation, $"noun assignment: Plural noun rule applied for verb '{verb}' - '{originalNoun}' became '{finalNoun}' due to singular/plural operation conflict detection.");
        }

        public static void NounAssignmentSingularizedWithoutCollection(ConfigModel service, ServiceOperation operation, string originalNoun, string finalNoun)
        {
            new InfoMessage(service, operation, $"noun assignment: Noun singularized without Collection suffix - '{originalNoun}' became '{finalNoun}' (no singular/plural operation conflict detected).");
        }

        public static void NounAssignmentMethodPrefixTransformationApplied(ConfigModel service, ServiceOperation operation, string originalNoun, string transformedNoun, string methodPrefix)
        {
            new InfoMessage(service, operation, $"noun assignment: Method prefix transformation applied - '{originalNoun}' transformed to '{transformedNoun}' using '{methodPrefix}' prefix pattern.");
        }

        public static void ReservedParameterNameConflictResolved(ConfigModel service, ServiceOperation operation, SimplePropertyInfo candidateParameter)
        {
            new InfoMessage(service, operation, $"Reserved paramater name conflict {candidateParameter.AnalyzedName} found. Automatically resolved as {candidateParameter.CmdletParameterName}.");
        }

        public static void CircularDependencyDetected(ConfigModel service, ServiceOperation operation, string typeName)
        {
            new InfoMessage(service, operation, $"Circular dependency detected for type '{typeName}'. Type added to TypesNotToFlatten at service level to prevent StackOverflow during parameter flattening.");
        }
    }
}
