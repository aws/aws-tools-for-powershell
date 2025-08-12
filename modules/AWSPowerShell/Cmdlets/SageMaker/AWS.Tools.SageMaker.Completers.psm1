# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service Amazon SageMaker Service


$SM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SageMaker.ActionStatus
        {
            ($_ -eq "New-SMAction/Status") -Or
            ($_ -eq "Update-SMAction/Status")
        }
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping","Unknown"
            break
        }

        # Amazon.SageMaker.ActivationState
        {
            ($_ -eq "New-SMComputeQuota/ActivationState") -Or
            ($_ -eq "Update-SMComputeQuota/ActivationState")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.AdditionalS3DataSourceDataType
        "New-SMAlgorithm/AdditionalS3DataSource_S3DataType"
        {
            $v = "S3Object","S3Prefix"
            break
        }

        # Amazon.SageMaker.AlgorithmSortBy
        "Get-SMAlgorithmList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.AppImageConfigSortKey
        "Get-SMAppImageConfigList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime","Name"
            break
        }

        # Amazon.SageMaker.AppInstanceType
        {
            ($_ -eq "New-SMDomain/DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMDomain/DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMDomain/DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMDomain/DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMDomain/DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMDomain/DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMDomain/DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMDomain/DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMApp/ResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMSpace/SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMSpace/SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMSpace/SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMSpace/SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMSpace/SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMSpace/SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "New-SMSpace/SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType") -Or
            ($_ -eq "Update-SMSpace/SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType")
        }
        {
            $v = "ml.c5.12xlarge","ml.c5.18xlarge","ml.c5.24xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.large","ml.c5.xlarge","ml.c6i.12xlarge","ml.c6i.16xlarge","ml.c6i.24xlarge","ml.c6i.2xlarge","ml.c6i.32xlarge","ml.c6i.4xlarge","ml.c6i.8xlarge","ml.c6i.large","ml.c6i.xlarge","ml.c6id.12xlarge","ml.c6id.16xlarge","ml.c6id.24xlarge","ml.c6id.2xlarge","ml.c6id.32xlarge","ml.c6id.4xlarge","ml.c6id.8xlarge","ml.c6id.large","ml.c6id.xlarge","ml.c7i.12xlarge","ml.c7i.16xlarge","ml.c7i.24xlarge","ml.c7i.2xlarge","ml.c7i.48xlarge","ml.c7i.4xlarge","ml.c7i.8xlarge","ml.c7i.large","ml.c7i.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.g6.12xlarge","ml.g6.16xlarge","ml.g6.24xlarge","ml.g6.2xlarge","ml.g6.48xlarge","ml.g6.4xlarge","ml.g6.8xlarge","ml.g6.xlarge","ml.g6e.12xlarge","ml.g6e.16xlarge","ml.g6e.24xlarge","ml.g6e.2xlarge","ml.g6e.48xlarge","ml.g6e.4xlarge","ml.g6e.8xlarge","ml.g6e.xlarge","ml.geospatial.interactive","ml.m5.12xlarge","ml.m5.16xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.8xlarge","ml.m5.large","ml.m5.xlarge","ml.m5d.12xlarge","ml.m5d.16xlarge","ml.m5d.24xlarge","ml.m5d.2xlarge","ml.m5d.4xlarge","ml.m5d.8xlarge","ml.m5d.large","ml.m5d.xlarge","ml.m6i.12xlarge","ml.m6i.16xlarge","ml.m6i.24xlarge","ml.m6i.2xlarge","ml.m6i.32xlarge","ml.m6i.4xlarge","ml.m6i.8xlarge","ml.m6i.large","ml.m6i.xlarge","ml.m6id.12xlarge","ml.m6id.16xlarge","ml.m6id.24xlarge","ml.m6id.2xlarge","ml.m6id.32xlarge","ml.m6id.4xlarge","ml.m6id.8xlarge","ml.m6id.large","ml.m6id.xlarge","ml.m7i.12xlarge","ml.m7i.16xlarge","ml.m7i.24xlarge","ml.m7i.2xlarge","ml.m7i.48xlarge","ml.m7i.4xlarge","ml.m7i.8xlarge","ml.m7i.large","ml.m7i.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.p3dn.24xlarge","ml.p4d.24xlarge","ml.p4de.24xlarge","ml.p5.48xlarge","ml.p5en.48xlarge","ml.r5.12xlarge","ml.r5.16xlarge","ml.r5.24xlarge","ml.r5.2xlarge","ml.r5.4xlarge","ml.r5.8xlarge","ml.r5.large","ml.r5.xlarge","ml.r6i.12xlarge","ml.r6i.16xlarge","ml.r6i.24xlarge","ml.r6i.2xlarge","ml.r6i.32xlarge","ml.r6i.4xlarge","ml.r6i.8xlarge","ml.r6i.large","ml.r6i.xlarge","ml.r6id.12xlarge","ml.r6id.16xlarge","ml.r6id.24xlarge","ml.r6id.2xlarge","ml.r6id.32xlarge","ml.r6id.4xlarge","ml.r6id.8xlarge","ml.r6id.large","ml.r6id.xlarge","ml.r7i.12xlarge","ml.r7i.16xlarge","ml.r7i.24xlarge","ml.r7i.2xlarge","ml.r7i.48xlarge","ml.r7i.4xlarge","ml.r7i.8xlarge","ml.r7i.large","ml.r7i.xlarge","ml.t3.2xlarge","ml.t3.large","ml.t3.medium","ml.t3.micro","ml.t3.small","ml.t3.xlarge","ml.trn1.2xlarge","ml.trn1.32xlarge","ml.trn1n.32xlarge","system"
            break
        }

        # Amazon.SageMaker.AppNetworkAccessType
        {
            ($_ -eq "New-SMDomain/AppNetworkAccessType") -Or
            ($_ -eq "Update-SMDomain/AppNetworkAccessType")
        }
        {
            $v = "PublicInternetOnly","VpcOnly"
            break
        }

        # Amazon.SageMaker.AppSecurityGroupManagement
        {
            ($_ -eq "New-SMDomain/AppSecurityGroupManagement") -Or
            ($_ -eq "Update-SMDomain/AppSecurityGroupManagement")
        }
        {
            $v = "Customer","Service"
            break
        }

        # Amazon.SageMaker.AppSortKey
        "Get-SMAppList/SortBy"
        {
            $v = "CreationTime"
            break
        }

        # Amazon.SageMaker.AppType
        {
            ($_ -eq "Get-SMApp/AppType") -Or
            ($_ -eq "New-SMApp/AppType") -Or
            ($_ -eq "Remove-SMApp/AppType") -Or
            ($_ -eq "New-SMSpace/SpaceSettings_AppType") -Or
            ($_ -eq "Update-SMSpace/SpaceSettings_AppType")
        }
        {
            $v = "Canvas","CodeEditor","DetailedProfiler","JupyterLab","JupyterServer","KernelGateway","RSessionGateway","RStudioServerPro","TensorBoard"
            break
        }

        # Amazon.SageMaker.AssemblyType
        "New-SMTransformJob/TransformOutput_AssembleWith"
        {
            $v = "Line","None"
            break
        }

        # Amazon.SageMaker.AssociationEdgeType
        {
            ($_ -eq "Add-SMAssociation/AssociationType") -Or
            ($_ -eq "Get-SMAssociationList/AssociationType")
        }
        {
            $v = "AssociatedWith","ContributedTo","DerivedFrom","Produced","SameAs"
            break
        }

        # Amazon.SageMaker.AuthMode
        "New-SMDomain/AuthMode"
        {
            $v = "IAM","SSO"
            break
        }

        # Amazon.SageMaker.AutoMLJobStatus
        "Get-SMAutoMLJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.AutoMLMetricEnum
        {
            ($_ -eq "New-SMAutoMLJob/AutoMLJobObjective_MetricName") -Or
            ($_ -eq "New-SMAutoMLJobV2/AutoMLJobObjective_MetricName")
        }
        {
            $v = "Accuracy","AUC","AverageWeightedQuantileLoss","BalancedAccuracy","F1","F1macro","MAE","MAPE","MASE","MSE","Precision","PrecisionMacro","R2","Recall","RecallMacro","RMSE","WAPE"
            break
        }

        # Amazon.SageMaker.AutoMLMode
        {
            ($_ -eq "New-SMAutoMLJob/AutoMLJobConfig_Mode") -Or
            ($_ -eq "New-SMAutoMLJobV2/TabularJobConfig_Mode")
        }
        {
            $v = "AUTO","ENSEMBLING","HYPERPARAMETER_TUNING"
            break
        }

        # Amazon.SageMaker.AutoMLSortBy
        "Get-SMAutoMLJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.AutoMLSortOrder
        {
            ($_ -eq "Get-SMAutoMLJobList/SortOrder") -Or
            ($_ -eq "Get-SMCandidatesForAutoMLJobList/SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.AutotuneMode
        "New-SMHyperParameterTuningJob/Autotune_Mode"
        {
            $v = "Enabled"
            break
        }

        # Amazon.SageMaker.AwsManagedHumanLoopRequestSource
        "New-SMFlowDefinition/HumanLoopRequestSource_AwsManagedHumanLoopRequestSource"
        {
            $v = "AWS/Rekognition/DetectModerationLabels/Image/V3","AWS/Textract/AnalyzeDocument/Forms/V1"
            break
        }

        # Amazon.SageMaker.BatchStrategy
        "New-SMTransformJob/BatchStrategy"
        {
            $v = "MultiRecord","SingleRecord"
            break
        }

        # Amazon.SageMaker.BooleanOperator
        "Search-SMResource/SearchExpression_Operator"
        {
            $v = "And","Or"
            break
        }

        # Amazon.SageMaker.CandidateSortBy
        "Get-SMCandidatesForAutoMLJobList/SortBy"
        {
            $v = "CreationTime","FinalObjectiveMetricValue","Status"
            break
        }

        # Amazon.SageMaker.CandidateStatus
        "Get-SMCandidatesForAutoMLJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.CapacitySizeType
        {
            ($_ -eq "New-SMEndpoint/CanarySize_Type") -Or
            ($_ -eq "Update-SMEndpoint/CanarySize_Type") -Or
            ($_ -eq "New-SMEndpoint/LinearStepSize_Type") -Or
            ($_ -eq "Update-SMEndpoint/LinearStepSize_Type") -Or
            ($_ -eq "New-SMEndpoint/MaximumBatchSize_Type") -Or
            ($_ -eq "Update-SMEndpoint/MaximumBatchSize_Type") -Or
            ($_ -eq "New-SMEndpoint/RollbackMaximumBatchSize_Type") -Or
            ($_ -eq "Update-SMEndpoint/RollbackMaximumBatchSize_Type")
        }
        {
            $v = "CAPACITY_PERCENT","INSTANCE_COUNT"
            break
        }

        # Amazon.SageMaker.ClarifyTextGranularity
        "New-SMEndpointConfig/TextConfig_Granularity"
        {
            $v = "paragraph","sentence","token"
            break
        }

        # Amazon.SageMaker.ClarifyTextLanguage
        "New-SMEndpointConfig/TextConfig_Language"
        {
            $v = "af","ar","bg","bn","ca","cs","da","de","el","en","es","et","eu","fa","fi","fr","ga","gu","he","hi","hr","hu","hy","id","is","it","kn","ky","lb","lij","lt","lv","mk","ml","mr","nb","ne","nl","pl","pt","ro","ru","sa","si","sk","sl","sq","sr","sv","ta","te","tl","tn","tr","tt","uk","ur","xx","yo","zh"
            break
        }

        # Amazon.SageMaker.ClusterEventResourceType
        "Get-SMClusterEventList/ResourceType"
        {
            $v = "Cluster","Instance","InstanceGroup"
            break
        }

        # Amazon.SageMaker.ClusterNodeProvisioningMode
        "New-SMCluster/NodeProvisioningMode"
        {
            $v = "Continuous"
            break
        }

        # Amazon.SageMaker.ClusterNodeRecovery
        {
            ($_ -eq "New-SMCluster/NodeRecovery") -Or
            ($_ -eq "Update-SMCluster/NodeRecovery")
        }
        {
            $v = "Automatic","None"
            break
        }

        # Amazon.SageMaker.ClusterSortBy
        {
            ($_ -eq "Get-SMClusterList/SortBy") -Or
            ($_ -eq "Get-SMClusterNodeList/SortBy")
        }
        {
            $v = "CREATION_TIME","NAME"
            break
        }

        # Amazon.SageMaker.CodeRepositorySortBy
        "Get-SMCodeRepositoryList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime","Name"
            break
        }

        # Amazon.SageMaker.CodeRepositorySortOrder
        "Get-SMCodeRepositoryList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.CompilationJobStatus
        "Get-SMCompilationJobList/StatusEqual"
        {
            $v = "COMPLETED","FAILED","INPROGRESS","STARTING","STOPPED","STOPPING"
            break
        }

        # Amazon.SageMaker.CompleteOnConvergence
        "New-SMHyperParameterTuningJob/ConvergenceDetected_CompleteOnConvergence"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.CompressionType
        {
            ($_ -eq "New-SMAlgorithm/AdditionalS3DataSource_CompressionType") -Or
            ($_ -eq "New-SMTransformJob/TransformInput_CompressionType")
        }
        {
            $v = "Gzip","None"
            break
        }

        # Amazon.SageMaker.CrossAccountFilterOption
        {
            ($_ -eq "Get-SMModelPackageGroupList/CrossAccountFilterOption") -Or
            ($_ -eq "Search-SMResource/CrossAccountFilterOption")
        }
        {
            $v = "CrossAccount","SameAccount"
            break
        }

        # Amazon.SageMaker.DirectInternetAccess
        "New-SMNotebookInstance/DirectInternetAccess"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.Direction
        "Find-SMLineage/Direction"
        {
            $v = "Ascendants","Both","Descendants"
            break
        }

        # Amazon.SageMaker.EdgePackagingJobStatus
        "Get-SMEdgePackagingJobList/StatusEqual"
        {
            $v = "COMPLETED","FAILED","INPROGRESS","STARTING","STOPPED","STOPPING"
            break
        }

        # Amazon.SageMaker.EdgePresetDeploymentType
        {
            ($_ -eq "New-SMDeviceFleet/OutputConfig_PresetDeploymentType") -Or
            ($_ -eq "New-SMEdgePackagingJob/OutputConfig_PresetDeploymentType") -Or
            ($_ -eq "Update-SMDeviceFleet/OutputConfig_PresetDeploymentType")
        }
        {
            $v = "GreengrassV2Component"
            break
        }

        # Amazon.SageMaker.EnabledOrDisabled
        {
            ($_ -eq "New-SMWorkteam/IamPolicyConstraints_SourceIp") -Or
            ($_ -eq "Update-SMWorkteam/IamPolicyConstraints_SourceIp") -Or
            ($_ -eq "New-SMWorkteam/IamPolicyConstraints_VpcSourceIp") -Or
            ($_ -eq "Update-SMWorkteam/IamPolicyConstraints_VpcSourceIp")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.EndpointConfigSortKey
        "Get-SMConfigList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.EndpointSortKey
        "Get-SMEndpointList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.EndpointStatus
        "Get-SMEndpointList/StatusEqual"
        {
            $v = "Creating","Deleting","Failed","InService","OutOfService","RollingBack","SystemUpdating","UpdateRollbackFailed","Updating"
            break
        }

        # Amazon.SageMaker.EventSortBy
        "Get-SMClusterEventList/SortBy"
        {
            $v = "EventTime"
            break
        }

        # Amazon.SageMaker.ExecutionRoleIdentityConfig
        {
            ($_ -eq "New-SMDomain/DomainSettings_ExecutionRoleIdentityConfig") -Or
            ($_ -eq "Update-SMDomain/DomainSettingsForUpdate_ExecutionRoleIdentityConfig")
        }
        {
            $v = "DISABLED","USER_PROFILE_NAME"
            break
        }

        # Amazon.SageMaker.ExecutionStatus
        "Get-SMMonitoringExecutionList/StatusEqual"
        {
            $v = "Completed","CompletedWithViolations","Failed","InProgress","Pending","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.FairShare
        {
            ($_ -eq "New-SMClusterSchedulerConfig/SchedulerConfig_FairShare") -Or
            ($_ -eq "Update-SMClusterSchedulerConfig/SchedulerConfig_FairShare")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.FeatureGroupSortBy
        "Get-SMFeatureGroupList/SortBy"
        {
            $v = "CreationTime","FeatureGroupStatus","Name","OfflineStoreStatus"
            break
        }

        # Amazon.SageMaker.FeatureGroupSortOrder
        "Get-SMFeatureGroupList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.FeatureGroupStatus
        "Get-SMFeatureGroupList/FeatureGroupStatusEqual"
        {
            $v = "Created","CreateFailed","Creating","DeleteFailed","Deleting"
            break
        }

        # Amazon.SageMaker.FeatureStatus
        {
            ($_ -eq "New-SMDomain/AmazonQSettings_Status") -Or
            ($_ -eq "Update-SMDomain/AmazonQSettings_Status") -Or
            ($_ -eq "New-SMDomain/DockerSettings_EnableDockerAccess") -Or
            ($_ -eq "Update-SMDomain/DockerSettings_EnableDockerAccess") -Or
            ($_ -eq "New-SMSpace/SpaceSettings_RemoteAccess") -Or
            ($_ -eq "Update-SMSpace/SpaceSettings_RemoteAccess") -Or
            ($_ -eq "New-SMSpace/SpaceSettings_SpaceManagedResource") -Or
            ($_ -eq "Update-SMSpace/SpaceSettings_SpaceManagedResource") -Or
            ($_ -eq "New-SMDomain/TrustedIdentityPropagationSettings_Status") -Or
            ($_ -eq "Update-SMDomain/TrustedIdentityPropagationSettings_Status") -Or
            ($_ -eq "New-SMDomain/UnifiedStudioSettings_StudioWebPortalAccess") -Or
            ($_ -eq "Update-SMDomain/UnifiedStudioSettings_StudioWebPortalAccess")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SageMaker.FlatInvocations
        "New-SMInferenceRecommendationsJob/StoppingConditions_FlatInvocation"
        {
            $v = "Continue","Stop"
            break
        }

        # Amazon.SageMaker.Framework
        "New-SMCompilationJob/InputConfig_Framework"
        {
            $v = "DARKNET","KERAS","MXNET","ONNX","PYTORCH","SKLEARN","TENSORFLOW","TFLITE","XGBOOST"
            break
        }

        # Amazon.SageMaker.HubContentSortBy
        {
            ($_ -eq "Get-SMHubContentList/SortBy") -Or
            ($_ -eq "Get-SMHubContentVersionList/SortBy")
        }
        {
            $v = "CreationTime","HubContentName","HubContentStatus"
            break
        }

        # Amazon.SageMaker.HubContentSupportStatus
        {
            ($_ -eq "Import-SMHubContent/SupportStatus") -Or
            ($_ -eq "Update-SMHubContent/SupportStatus")
        }
        {
            $v = "Deprecated","Restricted","Supported"
            break
        }

        # Amazon.SageMaker.HubContentType
        {
            ($_ -eq "Get-SMHubContent/HubContentType") -Or
            ($_ -eq "Get-SMHubContentList/HubContentType") -Or
            ($_ -eq "Get-SMHubContentVersionList/HubContentType") -Or
            ($_ -eq "Import-SMHubContent/HubContentType") -Or
            ($_ -eq "New-SMHubContentPresignedUrl/HubContentType") -Or
            ($_ -eq "Remove-SMHubContent/HubContentType") -Or
            ($_ -eq "Remove-SMHubContentReference/HubContentType") -Or
            ($_ -eq "Update-SMHubContent/HubContentType") -Or
            ($_ -eq "Update-SMHubContentReference/HubContentType")
        }
        {
            $v = "Model","ModelReference","Notebook"
            break
        }

        # Amazon.SageMaker.HubSortBy
        "Get-SMHubList/SortBy"
        {
            $v = "AccountIdOwner","CreationTime","HubName","HubStatus"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningAllocationStrategy
        "New-SMHyperParameterTuningJob/HyperParameterTuningResourceConfig_AllocationStrategy"
        {
            $v = "Prioritized"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobObjectiveType
        {
            ($_ -eq "New-SMHyperParameterTuningJob/HyperParameterTuningJobObjective_Type") -Or
            ($_ -eq "New-SMHyperParameterTuningJob/TuningObjective_Type")
        }
        {
            $v = "Maximize","Minimize"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobSortByOptions
        "Get-SMHyperParameterTuningJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobStatus
        "Get-SMHyperParameterTuningJobList/StatusEqual"
        {
            $v = "Completed","DeleteFailed","Deleting","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobStrategyType
        "New-SMHyperParameterTuningJob/HyperParameterTuningJobConfig_Strategy"
        {
            $v = "Bayesian","Grid","Hyperband","Random"
            break
        }

        # Amazon.SageMaker.HyperParameterTuningJobWarmStartType
        "New-SMHyperParameterTuningJob/WarmStartConfig_WarmStartType"
        {
            $v = "IdenticalDataAndAlgorithm","TransferLearning"
            break
        }

        # Amazon.SageMaker.ImageSortBy
        "Get-SMImageList/SortBy"
        {
            $v = "CREATION_TIME","IMAGE_NAME","LAST_MODIFIED_TIME"
            break
        }

        # Amazon.SageMaker.ImageSortOrder
        "Get-SMImageList/SortOrder"
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.SageMaker.ImageVersionSortBy
        "Get-SMImageVersionList/SortBy"
        {
            $v = "CREATION_TIME","LAST_MODIFIED_TIME","VERSION"
            break
        }

        # Amazon.SageMaker.ImageVersionSortOrder
        "Get-SMImageVersionList/SortOrder"
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.SageMaker.InferenceComponentCapacitySizeType
        {
            ($_ -eq "Update-SMInferenceComponent/MaximumBatchSize_Type") -Or
            ($_ -eq "Update-SMInferenceComponent/RollbackMaximumBatchSize_Type")
        }
        {
            $v = "CAPACITY_PERCENT","COPY_COUNT"
            break
        }

        # Amazon.SageMaker.InferenceComponentSortKey
        "Get-SMInferenceComponentList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.InferenceComponentStatus
        "Get-SMInferenceComponentList/StatusEqual"
        {
            $v = "Creating","Deleting","Failed","InService","Updating"
            break
        }

        # Amazon.SageMaker.InferenceExecutionMode
        "New-SMModel/InferenceExecutionConfig_Mode"
        {
            $v = "Direct","Serial"
            break
        }

        # Amazon.SageMaker.InferenceExperimentStatus
        "Get-SMInferenceExperimentList/StatusEqual"
        {
            $v = "Cancelled","Completed","Created","Creating","Running","Starting","Stopping","Updating"
            break
        }

        # Amazon.SageMaker.InferenceExperimentStopDesiredState
        "Stop-SMInferenceExperiment/DesiredState"
        {
            $v = "Cancelled","Completed"
            break
        }

        # Amazon.SageMaker.InferenceExperimentType
        {
            ($_ -eq "Get-SMInferenceExperimentList/Type") -Or
            ($_ -eq "New-SMInferenceExperiment/Type")
        }
        {
            $v = "ShadowMode"
            break
        }

        # Amazon.SageMaker.InstanceType
        {
            ($_ -eq "New-SMNotebookInstance/InstanceType") -Or
            ($_ -eq "Update-SMNotebookInstance/InstanceType")
        }
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c5d.18xlarge","ml.c5d.2xlarge","ml.c5d.4xlarge","ml.c5d.9xlarge","ml.c5d.xlarge","ml.c6i.12xlarge","ml.c6i.16xlarge","ml.c6i.24xlarge","ml.c6i.2xlarge","ml.c6i.32xlarge","ml.c6i.4xlarge","ml.c6i.8xlarge","ml.c6i.large","ml.c6i.xlarge","ml.c6id.12xlarge","ml.c6id.16xlarge","ml.c6id.24xlarge","ml.c6id.2xlarge","ml.c6id.32xlarge","ml.c6id.4xlarge","ml.c6id.8xlarge","ml.c6id.large","ml.c6id.xlarge","ml.c7i.12xlarge","ml.c7i.16xlarge","ml.c7i.24xlarge","ml.c7i.2xlarge","ml.c7i.48xlarge","ml.c7i.4xlarge","ml.c7i.8xlarge","ml.c7i.large","ml.c7i.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.g6.12xlarge","ml.g6.16xlarge","ml.g6.24xlarge","ml.g6.2xlarge","ml.g6.48xlarge","ml.g6.4xlarge","ml.g6.8xlarge","ml.g6.xlarge","ml.inf1.24xlarge","ml.inf1.2xlarge","ml.inf1.6xlarge","ml.inf1.xlarge","ml.inf2.24xlarge","ml.inf2.48xlarge","ml.inf2.8xlarge","ml.inf2.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.xlarge","ml.m5d.12xlarge","ml.m5d.16xlarge","ml.m5d.24xlarge","ml.m5d.2xlarge","ml.m5d.4xlarge","ml.m5d.8xlarge","ml.m5d.large","ml.m5d.xlarge","ml.m6i.12xlarge","ml.m6i.16xlarge","ml.m6i.24xlarge","ml.m6i.2xlarge","ml.m6i.32xlarge","ml.m6i.4xlarge","ml.m6i.8xlarge","ml.m6i.large","ml.m6i.xlarge","ml.m6id.12xlarge","ml.m6id.16xlarge","ml.m6id.24xlarge","ml.m6id.2xlarge","ml.m6id.32xlarge","ml.m6id.4xlarge","ml.m6id.8xlarge","ml.m6id.large","ml.m6id.xlarge","ml.m7i.12xlarge","ml.m7i.16xlarge","ml.m7i.24xlarge","ml.m7i.2xlarge","ml.m7i.48xlarge","ml.m7i.4xlarge","ml.m7i.8xlarge","ml.m7i.large","ml.m7i.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.p3dn.24xlarge","ml.p4d.24xlarge","ml.p4de.24xlarge","ml.p5.48xlarge","ml.r5.12xlarge","ml.r5.16xlarge","ml.r5.24xlarge","ml.r5.2xlarge","ml.r5.4xlarge","ml.r5.8xlarge","ml.r5.large","ml.r5.xlarge","ml.r6i.12xlarge","ml.r6i.16xlarge","ml.r6i.24xlarge","ml.r6i.2xlarge","ml.r6i.32xlarge","ml.r6i.4xlarge","ml.r6i.8xlarge","ml.r6i.large","ml.r6i.xlarge","ml.r6id.12xlarge","ml.r6id.16xlarge","ml.r6id.24xlarge","ml.r6id.2xlarge","ml.r6id.32xlarge","ml.r6id.4xlarge","ml.r6id.8xlarge","ml.r6id.large","ml.r6id.xlarge","ml.r7i.12xlarge","ml.r7i.16xlarge","ml.r7i.24xlarge","ml.r7i.2xlarge","ml.r7i.48xlarge","ml.r7i.4xlarge","ml.r7i.8xlarge","ml.r7i.large","ml.r7i.xlarge","ml.t2.2xlarge","ml.t2.large","ml.t2.medium","ml.t2.xlarge","ml.t3.2xlarge","ml.t3.large","ml.t3.medium","ml.t3.xlarge","ml.trn1.2xlarge","ml.trn1.32xlarge","ml.trn1n.32xlarge"
            break
        }

        # Amazon.SageMaker.JobType
        {
            ($_ -eq "New-SMImageVersion/JobType") -Or
            ($_ -eq "Update-SMImageVersion/JobType")
        }
        {
            $v = "INFERENCE","NOTEBOOK_KERNEL","TRAINING"
            break
        }

        # Amazon.SageMaker.JoinSource
        "New-SMTransformJob/DataProcessing_JoinSource"
        {
            $v = "Input","None"
            break
        }

        # Amazon.SageMaker.LabelingJobStatus
        "Get-SMLabelingJobList/StatusEqual"
        {
            $v = "Completed","Failed","Initializing","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.LifecycleManagement
        {
            ($_ -eq "New-SMDomain/IdleSettings_LifecycleManagement") -Or
            ($_ -eq "Update-SMDomain/IdleSettings_LifecycleManagement")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SageMaker.ListCompilationJobsSortBy
        "Get-SMCompilationJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.ListDeviceFleetsSortBy
        "Get-SMDeviceFleetList/SortBy"
        {
            $v = "CREATION_TIME","LAST_MODIFIED_TIME","NAME"
            break
        }

        # Amazon.SageMaker.ListEdgeDeploymentPlansSortBy
        "Get-SMEdgeDeploymentPlanList/SortBy"
        {
            $v = "CREATION_TIME","DEVICE_FLEET_NAME","LAST_MODIFIED_TIME","NAME"
            break
        }

        # Amazon.SageMaker.ListEdgePackagingJobsSortBy
        "Get-SMEdgePackagingJobList/SortBy"
        {
            $v = "CREATION_TIME","LAST_MODIFIED_TIME","MODEL_NAME","NAME","STATUS"
            break
        }

        # Amazon.SageMaker.ListInferenceRecommendationsJobsSortBy
        "Get-SMInferenceRecommendationsJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.ListLabelingJobsForWorkteamSortByOptions
        "Get-SMLabelingJobListForWorkteam/SortBy"
        {
            $v = "CreationTime"
            break
        }

        # Amazon.SageMaker.ListOptimizationJobsSortBy
        "Get-SMOptimizationJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.ListWorkforcesSortByOptions
        "Get-SMWorkforceList/SortBy"
        {
            $v = "CreateDate","Name"
            break
        }

        # Amazon.SageMaker.ListWorkteamsSortByOptions
        "Get-SMWorkteamList/SortBy"
        {
            $v = "CreateDate","Name"
            break
        }

        # Amazon.SageMaker.ModelApprovalStatus
        {
            ($_ -eq "Get-SMModelPackageList/ModelApprovalStatus") -Or
            ($_ -eq "New-SMModelPackage/ModelApprovalStatus") -Or
            ($_ -eq "Update-SMModelPackage/ModelApprovalStatus")
        }
        {
            $v = "Approved","PendingManualApproval","Rejected"
            break
        }

        # Amazon.SageMaker.ModelCardExportJobSortBy
        "Get-SMModelCardExportJobList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.ModelCardExportJobSortOrder
        "Get-SMModelCardExportJobList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.ModelCardExportJobStatus
        "Get-SMModelCardExportJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress"
            break
        }

        # Amazon.SageMaker.ModelCardSortBy
        "Get-SMModelCardList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.ModelCardSortOrder
        {
            ($_ -eq "Get-SMModelCardList/SortOrder") -Or
            ($_ -eq "Get-SMModelCardVersionList/SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.ModelCardStatus
        {
            ($_ -eq "New-SMModelPackage/ModelCard_ModelCardStatus") -Or
            ($_ -eq "Update-SMModelPackage/ModelCard_ModelCardStatus") -Or
            ($_ -eq "Get-SMModelCardList/ModelCardStatus") -Or
            ($_ -eq "Get-SMModelCardVersionList/ModelCardStatus") -Or
            ($_ -eq "New-SMModelCard/ModelCardStatus") -Or
            ($_ -eq "Update-SMModelCard/ModelCardStatus")
        }
        {
            $v = "Approved","Archived","Draft","PendingReview"
            break
        }

        # Amazon.SageMaker.ModelCardVersionSortBy
        "Get-SMModelCardVersionList/SortBy"
        {
            $v = "Version"
            break
        }

        # Amazon.SageMaker.ModelPackageGroupSortBy
        "Get-SMModelPackageGroupList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.ModelPackageSortBy
        "Get-SMModelPackageList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.ModelPackageType
        "Get-SMModelPackageList/ModelPackageType"
        {
            $v = "Both","Unversioned","Versioned"
            break
        }

        # Amazon.SageMaker.ModelSortKey
        "Get-SMModelList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.MonitoringAlertHistorySortKey
        "Get-SMMonitoringAlertHistoryList/SortBy"
        {
            $v = "CreationTime","Status"
            break
        }

        # Amazon.SageMaker.MonitoringAlertStatus
        "Get-SMMonitoringAlertHistoryList/StatusEqual"
        {
            $v = "InAlert","OK"
            break
        }

        # Amazon.SageMaker.MonitoringExecutionSortKey
        "Get-SMMonitoringExecutionList/SortBy"
        {
            $v = "CreationTime","ScheduledTime","Status"
            break
        }

        # Amazon.SageMaker.MonitoringJobDefinitionSortKey
        {
            ($_ -eq "Get-SMDataQualityJobDefinitionList/SortBy") -Or
            ($_ -eq "Get-SMModelBiasJobDefinitionList/SortBy") -Or
            ($_ -eq "Get-SMModelExplainabilityJobDefinitionList/SortBy") -Or
            ($_ -eq "Get-SMModelQualityJobDefinitionList/SortBy")
        }
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.MonitoringProblemType
        "New-SMModelQualityJobDefinition/ModelQualityAppSpecification_ProblemType"
        {
            $v = "BinaryClassification","MulticlassClassification","Regression"
            break
        }

        # Amazon.SageMaker.MonitoringScheduleSortKey
        "Get-SMMonitoringScheduleList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.MonitoringType
        {
            ($_ -eq "Get-SMMonitoringExecutionList/MonitoringTypeEqual") -Or
            ($_ -eq "Get-SMMonitoringScheduleList/MonitoringTypeEqual")
        }
        {
            $v = "DataQuality","ModelBias","ModelExplainability","ModelQuality"
            break
        }

        # Amazon.SageMaker.NodeUnavailabilityType
        {
            ($_ -eq "Update-SMClusterSoftware/MaximumBatchSize_Type") -Or
            ($_ -eq "Update-SMClusterSoftware/RollbackMaximumBatchSize_Type")
        }
        {
            $v = "CAPACITY_PERCENTAGE","INSTANCE_COUNT"
            break
        }

        # Amazon.SageMaker.NotebookInstanceLifecycleConfigSortKey
        "Get-SMNotebookInstanceLifecycleConfigList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime","Name"
            break
        }

        # Amazon.SageMaker.NotebookInstanceLifecycleConfigSortOrder
        "Get-SMNotebookInstanceLifecycleConfigList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.NotebookInstanceSortKey
        "Get-SMNotebookInstanceList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.NotebookInstanceSortOrder
        "Get-SMNotebookInstanceList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.NotebookInstanceStatus
        "Get-SMNotebookInstanceList/StatusEqual"
        {
            $v = "Deleting","Failed","InService","Pending","Stopped","Stopping","Updating"
            break
        }

        # Amazon.SageMaker.OfflineStoreStatusValue
        "Get-SMFeatureGroupList/OfflineStoreStatusEqual"
        {
            $v = "Active","Blocked","Disabled"
            break
        }

        # Amazon.SageMaker.OptimizationJobDeploymentInstanceType
        "New-SMOptimizationJob/DeploymentInstanceType"
        {
            $v = "ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.g6.12xlarge","ml.g6.16xlarge","ml.g6.24xlarge","ml.g6.2xlarge","ml.g6.48xlarge","ml.g6.4xlarge","ml.g6.8xlarge","ml.g6.xlarge","ml.g6e.12xlarge","ml.g6e.16xlarge","ml.g6e.24xlarge","ml.g6e.2xlarge","ml.g6e.48xlarge","ml.g6e.4xlarge","ml.g6e.8xlarge","ml.g6e.xlarge","ml.inf2.24xlarge","ml.inf2.48xlarge","ml.inf2.8xlarge","ml.inf2.xlarge","ml.p4d.24xlarge","ml.p4de.24xlarge","ml.p5.48xlarge","ml.trn1.2xlarge","ml.trn1.32xlarge","ml.trn1n.32xlarge"
            break
        }

        # Amazon.SageMaker.OptimizationJobStatus
        "Get-SMOptimizationJobList/StatusEqual"
        {
            $v = "COMPLETED","FAILED","INPROGRESS","STARTING","STOPPED","STOPPING"
            break
        }

        # Amazon.SageMaker.OrderKey
        {
            ($_ -eq "Get-SMConfigList/SortOrder") -Or
            ($_ -eq "Get-SMEndpointList/SortOrder") -Or
            ($_ -eq "Get-SMInferenceComponentList/SortOrder") -Or
            ($_ -eq "Get-SMModelList/SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.PartnerAppAuthType
        "New-SMPartnerApp/AuthType"
        {
            $v = "IAM"
            break
        }

        # Amazon.SageMaker.PartnerAppType
        "New-SMPartnerApp/Type"
        {
            $v = "comet","deepchecks-llm-evaluation","fiddler","lakera-guard"
            break
        }

        # Amazon.SageMaker.PreemptTeamTasks
        {
            ($_ -eq "New-SMComputeQuota/ComputeQuotaConfig_PreemptTeamTask") -Or
            ($_ -eq "Update-SMComputeQuota/ComputeQuotaConfig_PreemptTeamTask")
        }
        {
            $v = "LowerPriority","Never"
            break
        }

        # Amazon.SageMaker.ProblemType
        {
            ($_ -eq "New-SMAutoMLJob/ProblemType") -Or
            ($_ -eq "New-SMAutoMLJobV2/TabularJobConfig_ProblemType")
        }
        {
            $v = "BinaryClassification","MulticlassClassification","Regression"
            break
        }

        # Amazon.SageMaker.ProcessingInstanceType
        {
            ($_ -eq "New-SMDataQualityJobDefinition/ClusterConfig_InstanceType") -Or
            ($_ -eq "New-SMModelBiasJobDefinition/ClusterConfig_InstanceType") -Or
            ($_ -eq "New-SMModelExplainabilityJobDefinition/ClusterConfig_InstanceType") -Or
            ($_ -eq "New-SMModelQualityJobDefinition/ClusterConfig_InstanceType") -Or
            ($_ -eq "New-SMProcessingJob/ClusterConfig_InstanceType")
        }
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c6i.12xlarge","ml.c6i.16xlarge","ml.c6i.24xlarge","ml.c6i.2xlarge","ml.c6i.32xlarge","ml.c6i.4xlarge","ml.c6i.8xlarge","ml.c6i.xlarge","ml.c7i.12xlarge","ml.c7i.16xlarge","ml.c7i.24xlarge","ml.c7i.2xlarge","ml.c7i.48xlarge","ml.c7i.4xlarge","ml.c7i.8xlarge","ml.c7i.large","ml.c7i.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.g6.12xlarge","ml.g6.16xlarge","ml.g6.24xlarge","ml.g6.2xlarge","ml.g6.48xlarge","ml.g6.4xlarge","ml.g6.8xlarge","ml.g6.xlarge","ml.g6e.12xlarge","ml.g6e.16xlarge","ml.g6e.24xlarge","ml.g6e.2xlarge","ml.g6e.48xlarge","ml.g6e.4xlarge","ml.g6e.8xlarge","ml.g6e.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.large","ml.m5.xlarge","ml.m6i.12xlarge","ml.m6i.16xlarge","ml.m6i.24xlarge","ml.m6i.2xlarge","ml.m6i.32xlarge","ml.m6i.4xlarge","ml.m6i.8xlarge","ml.m6i.large","ml.m6i.xlarge","ml.m7i.12xlarge","ml.m7i.16xlarge","ml.m7i.24xlarge","ml.m7i.2xlarge","ml.m7i.48xlarge","ml.m7i.4xlarge","ml.m7i.8xlarge","ml.m7i.large","ml.m7i.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.r5.12xlarge","ml.r5.16xlarge","ml.r5.24xlarge","ml.r5.2xlarge","ml.r5.4xlarge","ml.r5.8xlarge","ml.r5.large","ml.r5.xlarge","ml.r5d.12xlarge","ml.r5d.16xlarge","ml.r5d.24xlarge","ml.r5d.2xlarge","ml.r5d.4xlarge","ml.r5d.8xlarge","ml.r5d.large","ml.r5d.xlarge","ml.r7i.12xlarge","ml.r7i.16xlarge","ml.r7i.24xlarge","ml.r7i.2xlarge","ml.r7i.48xlarge","ml.r7i.4xlarge","ml.r7i.8xlarge","ml.r7i.large","ml.r7i.xlarge","ml.t3.2xlarge","ml.t3.large","ml.t3.medium","ml.t3.xlarge"
            break
        }

        # Amazon.SageMaker.ProcessingJobStatus
        "Get-SMProcessingJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.ProcessingS3DataDistributionType
        {
            ($_ -eq "New-SMDataQualityJobDefinition/BatchTransformInput_S3DataDistributionType") -Or
            ($_ -eq "New-SMModelBiasJobDefinition/BatchTransformInput_S3DataDistributionType") -Or
            ($_ -eq "New-SMModelExplainabilityJobDefinition/BatchTransformInput_S3DataDistributionType") -Or
            ($_ -eq "New-SMModelQualityJobDefinition/BatchTransformInput_S3DataDistributionType") -Or
            ($_ -eq "New-SMDataQualityJobDefinition/EndpointInput_S3DataDistributionType") -Or
            ($_ -eq "New-SMModelBiasJobDefinition/EndpointInput_S3DataDistributionType") -Or
            ($_ -eq "New-SMModelExplainabilityJobDefinition/EndpointInput_S3DataDistributionType") -Or
            ($_ -eq "New-SMModelQualityJobDefinition/EndpointInput_S3DataDistributionType")
        }
        {
            $v = "FullyReplicated","ShardedByS3Key"
            break
        }

        # Amazon.SageMaker.ProcessingS3InputMode
        {
            ($_ -eq "New-SMDataQualityJobDefinition/BatchTransformInput_S3InputMode") -Or
            ($_ -eq "New-SMModelBiasJobDefinition/BatchTransformInput_S3InputMode") -Or
            ($_ -eq "New-SMModelExplainabilityJobDefinition/BatchTransformInput_S3InputMode") -Or
            ($_ -eq "New-SMModelQualityJobDefinition/BatchTransformInput_S3InputMode") -Or
            ($_ -eq "New-SMDataQualityJobDefinition/EndpointInput_S3InputMode") -Or
            ($_ -eq "New-SMModelBiasJobDefinition/EndpointInput_S3InputMode") -Or
            ($_ -eq "New-SMModelExplainabilityJobDefinition/EndpointInput_S3InputMode") -Or
            ($_ -eq "New-SMModelQualityJobDefinition/EndpointInput_S3InputMode")
        }
        {
            $v = "File","Pipe"
            break
        }

        # Amazon.SageMaker.Processor
        {
            ($_ -eq "New-SMImageVersion/Processor") -Or
            ($_ -eq "Update-SMImageVersion/Processor")
        }
        {
            $v = "CPU","GPU"
            break
        }

        # Amazon.SageMaker.ProjectSortBy
        "Get-SMProjectList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.ProjectSortOrder
        "Get-SMProjectList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.RecommendationJobStatus
        {
            ($_ -eq "Get-SMInferenceRecommendationsJobStepList/Status") -Or
            ($_ -eq "Get-SMInferenceRecommendationsJobList/StatusEqual")
        }
        {
            $v = "COMPLETED","DELETED","DELETING","FAILED","IN_PROGRESS","PENDING","STOPPED","STOPPING"
            break
        }

        # Amazon.SageMaker.RecommendationJobSupportedEndpointType
        "New-SMInferenceRecommendationsJob/ContainerConfig_SupportedEndpointType"
        {
            $v = "RealTime","Serverless"
            break
        }

        # Amazon.SageMaker.RecommendationJobType
        "New-SMInferenceRecommendationsJob/JobType"
        {
            $v = "Advanced","Default"
            break
        }

        # Amazon.SageMaker.RecommendationStepType
        "Get-SMInferenceRecommendationsJobStepList/StepType"
        {
            $v = "BENCHMARK"
            break
        }

        # Amazon.SageMaker.ReservedCapacityInstanceType
        "Search-SMTrainingPlanOffering/InstanceType"
        {
            $v = "ml.p4d.24xlarge","ml.p4de.24xlarge","ml.p5.48xlarge","ml.p5e.48xlarge","ml.p5en.48xlarge","ml.p6-b200.48xlarge","ml.p6e-gb200.36xlarge","ml.trn1.32xlarge","ml.trn2.48xlarge"
            break
        }

        # Amazon.SageMaker.ResourceCatalogSortBy
        "Get-SMResourceCatalogList/SortBy"
        {
            $v = "CreationTime"
            break
        }

        # Amazon.SageMaker.ResourceCatalogSortOrder
        "Get-SMResourceCatalogList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.ResourceSharingStrategy
        {
            ($_ -eq "New-SMComputeQuota/ResourceSharingConfig_Strategy") -Or
            ($_ -eq "Update-SMComputeQuota/ResourceSharingConfig_Strategy")
        }
        {
            $v = "DontLend","Lend","LendAndBorrow"
            break
        }

        # Amazon.SageMaker.ResourceType
        {
            ($_ -eq "Get-SMSearchSuggestion/Resource") -Or
            ($_ -eq "Search-SMResource/Resource")
        }
        {
            $v = "Endpoint","Experiment","ExperimentTrial","ExperimentTrialComponent","FeatureGroup","FeatureMetadata","HyperParameterTuningJob","Image","ImageVersion","Model","ModelCard","ModelPackage","ModelPackageGroup","Pipeline","PipelineExecution","PipelineVersion","Project","TrainingJob"
            break
        }

        # Amazon.SageMaker.RetentionType
        "Remove-SMDomain/RetentionPolicy_HomeEfsFileSystem"
        {
            $v = "Delete","Retain"
            break
        }

        # Amazon.SageMaker.RootAccess
        {
            ($_ -eq "New-SMNotebookInstance/RootAccess") -Or
            ($_ -eq "Update-SMNotebookInstance/RootAccess")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.SageMaker.S3DataType
        "New-SMTransformJob/S3DataSource_S3DataType"
        {
            $v = "AugmentedManifestFile","Converse","ManifestFile","S3Prefix"
            break
        }

        # Amazon.SageMaker.SchedulerResourceStatus
        {
            ($_ -eq "Get-SMClusterSchedulerConfigList/Status") -Or
            ($_ -eq "Get-SMComputeQuotaList/Status")
        }
        {
            $v = "Created","CreateFailed","CreateRollbackFailed","Creating","Deleted","DeleteFailed","DeleteRollbackFailed","Deleting","Updated","UpdateFailed","UpdateRollbackFailed","Updating"
            break
        }

        # Amazon.SageMaker.ScheduleStatus
        "Get-SMMonitoringScheduleList/StatusEqual"
        {
            $v = "Failed","Pending","Scheduled","Stopped"
            break
        }

        # Amazon.SageMaker.SearchSortOrder
        "Search-SMResource/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.SharingType
        "New-SMSpace/SpaceSharingSettings_SharingType"
        {
            $v = "Private","Shared"
            break
        }

        # Amazon.SageMaker.SkipModelValidation
        "New-SMModelPackage/SkipModelValidation"
        {
            $v = "All","None"
            break
        }

        # Amazon.SageMaker.SortActionsBy
        "Get-SMActionList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.SortArtifactsBy
        "Get-SMArtifactList/SortBy"
        {
            $v = "CreationTime"
            break
        }

        # Amazon.SageMaker.SortAssociationsBy
        "Get-SMAssociationList/SortBy"
        {
            $v = "CreationTime","DestinationArn","DestinationType","SourceArn","SourceType"
            break
        }

        # Amazon.SageMaker.SortBy
        {
            ($_ -eq "Get-SMLabelingJobList/SortBy") -Or
            ($_ -eq "Get-SMProcessingJobList/SortBy") -Or
            ($_ -eq "Get-SMTrainingJobList/SortBy") -Or
            ($_ -eq "Get-SMTransformJobList/SortBy")
        }
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.SortClusterSchedulerConfigBy
        "Get-SMClusterSchedulerConfigList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.SortContextsBy
        "Get-SMContextList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.SortExperimentsBy
        "Get-SMExperimentList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.SortInferenceExperimentsBy
        "Get-SMInferenceExperimentList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.SortLineageGroupsBy
        "Get-SMLineageGroupList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.SortOrder
        {
            ($_ -eq "Get-SMActionList/SortOrder") -Or
            ($_ -eq "Get-SMAlgorithmList/SortOrder") -Or
            ($_ -eq "Get-SMAppImageConfigList/SortOrder") -Or
            ($_ -eq "Get-SMAppList/SortOrder") -Or
            ($_ -eq "Get-SMArtifactList/SortOrder") -Or
            ($_ -eq "Get-SMAssociationList/SortOrder") -Or
            ($_ -eq "Get-SMClusterEventList/SortOrder") -Or
            ($_ -eq "Get-SMClusterList/SortOrder") -Or
            ($_ -eq "Get-SMClusterNodeList/SortOrder") -Or
            ($_ -eq "Get-SMClusterSchedulerConfigList/SortOrder") -Or
            ($_ -eq "Get-SMCompilationJobList/SortOrder") -Or
            ($_ -eq "Get-SMComputeQuotaList/SortOrder") -Or
            ($_ -eq "Get-SMContextList/SortOrder") -Or
            ($_ -eq "Get-SMDataQualityJobDefinitionList/SortOrder") -Or
            ($_ -eq "Get-SMDeviceFleetList/SortOrder") -Or
            ($_ -eq "Get-SMEdgeDeploymentPlanList/SortOrder") -Or
            ($_ -eq "Get-SMEdgePackagingJobList/SortOrder") -Or
            ($_ -eq "Get-SMExperimentList/SortOrder") -Or
            ($_ -eq "Get-SMFlowDefinitionList/SortOrder") -Or
            ($_ -eq "Get-SMHubContentList/SortOrder") -Or
            ($_ -eq "Get-SMHubContentVersionList/SortOrder") -Or
            ($_ -eq "Get-SMHubList/SortOrder") -Or
            ($_ -eq "Get-SMHumanTaskUiList/SortOrder") -Or
            ($_ -eq "Get-SMHyperParameterTuningJobList/SortOrder") -Or
            ($_ -eq "Get-SMInferenceExperimentList/SortOrder") -Or
            ($_ -eq "Get-SMInferenceRecommendationsJobList/SortOrder") -Or
            ($_ -eq "Get-SMLabelingJobList/SortOrder") -Or
            ($_ -eq "Get-SMLabelingJobListForWorkteam/SortOrder") -Or
            ($_ -eq "Get-SMLineageGroupList/SortOrder") -Or
            ($_ -eq "Get-SMMlflowTrackingServerList/SortOrder") -Or
            ($_ -eq "Get-SMModelBiasJobDefinitionList/SortOrder") -Or
            ($_ -eq "Get-SMModelExplainabilityJobDefinitionList/SortOrder") -Or
            ($_ -eq "Get-SMModelPackageGroupList/SortOrder") -Or
            ($_ -eq "Get-SMModelPackageList/SortOrder") -Or
            ($_ -eq "Get-SMModelQualityJobDefinitionList/SortOrder") -Or
            ($_ -eq "Get-SMMonitoringAlertHistoryList/SortOrder") -Or
            ($_ -eq "Get-SMMonitoringExecutionList/SortOrder") -Or
            ($_ -eq "Get-SMMonitoringScheduleList/SortOrder") -Or
            ($_ -eq "Get-SMOptimizationJobList/SortOrder") -Or
            ($_ -eq "Get-SMPipelineExecutionList/SortOrder") -Or
            ($_ -eq "Get-SMPipelineExecutionStepList/SortOrder") -Or
            ($_ -eq "Get-SMPipelineList/SortOrder") -Or
            ($_ -eq "Get-SMPipelineVersionList/SortOrder") -Or
            ($_ -eq "Get-SMProcessingJobList/SortOrder") -Or
            ($_ -eq "Get-SMSpaceList/SortOrder") -Or
            ($_ -eq "Get-SMStudioLifecycleConfigList/SortOrder") -Or
            ($_ -eq "Get-SMTrainingJobList/SortOrder") -Or
            ($_ -eq "Get-SMTrainingJobsForHyperParameterTuningJobList/SortOrder") -Or
            ($_ -eq "Get-SMTransformJobList/SortOrder") -Or
            ($_ -eq "Get-SMTrialComponentList/SortOrder") -Or
            ($_ -eq "Get-SMTrialList/SortOrder") -Or
            ($_ -eq "Get-SMUserProfileList/SortOrder") -Or
            ($_ -eq "Get-SMWorkforceList/SortOrder") -Or
            ($_ -eq "Get-SMWorkteamList/SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.SortPipelineExecutionsBy
        "Get-SMPipelineExecutionList/SortBy"
        {
            $v = "CreationTime","PipelineExecutionArn"
            break
        }

        # Amazon.SageMaker.SortPipelinesBy
        "Get-SMPipelineList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.SortQuotaBy
        "Get-SMComputeQuotaList/SortBy"
        {
            $v = "ClusterArn","CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.SortTrackingServerBy
        "Get-SMMlflowTrackingServerList/SortBy"
        {
            $v = "CreationTime","Name","Status"
            break
        }

        # Amazon.SageMaker.SortTrialComponentsBy
        "Get-SMTrialComponentList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.SortTrialsBy
        "Get-SMTrialList/SortBy"
        {
            $v = "CreationTime","Name"
            break
        }

        # Amazon.SageMaker.SpaceSortKey
        "Get-SMSpaceList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime"
            break
        }

        # Amazon.SageMaker.SplitType
        "New-SMTransformJob/TransformInput_SplitType"
        {
            $v = "Line","None","RecordIO","TFRecord"
            break
        }

        # Amazon.SageMaker.StorageType
        "New-SMFeatureGroup/OnlineStoreConfig_StorageType"
        {
            $v = "InMemory","Standard"
            break
        }

        # Amazon.SageMaker.StudioLifecycleConfigAppType
        {
            ($_ -eq "Get-SMStudioLifecycleConfigList/AppTypeEqual") -Or
            ($_ -eq "New-SMStudioLifecycleConfig/StudioLifecycleConfigAppType")
        }
        {
            $v = "CodeEditor","JupyterLab","JupyterServer","KernelGateway"
            break
        }

        # Amazon.SageMaker.StudioLifecycleConfigSortKey
        "Get-SMStudioLifecycleConfigList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime","Name"
            break
        }

        # Amazon.SageMaker.TableFormat
        "New-SMFeatureGroup/OfflineStoreConfig_TableFormat"
        {
            $v = "Default","Glue","Iceberg"
            break
        }

        # Amazon.SageMaker.TagPropagation
        {
            ($_ -eq "New-SMDomain/TagPropagation") -Or
            ($_ -eq "Update-SMDomain/TagPropagation")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.SageMaker.TargetDevice
        "New-SMCompilationJob/OutputConfig_TargetDevice"
        {
            $v = "aisage","amba_cv2","amba_cv22","amba_cv25","coreml","deeplens","imx8mplus","imx8qm","jacinto_tda4vm","jetson_nano","jetson_tx1","jetson_tx2","jetson_xavier","lambda","ml_c4","ml_c5","ml_c6g","ml_eia2","ml_g4dn","ml_inf1","ml_inf2","ml_m4","ml_m5","ml_m6g","ml_p2","ml_p3","ml_trn1","qcs603","qcs605","rasp3b","rasp4b","rk3288","rk3399","sbe_c","sitara_am57x","x86_win32","x86_win64"
            break
        }

        # Amazon.SageMaker.TargetPlatformAccelerator
        "New-SMCompilationJob/TargetPlatform_Accelerator"
        {
            $v = "INTEL_GRAPHICS","MALI","NNA","NVIDIA"
            break
        }

        # Amazon.SageMaker.TargetPlatformArch
        "New-SMCompilationJob/TargetPlatform_Arch"
        {
            $v = "ARM64","ARM_EABI","ARM_EABIHF","X86","X86_64"
            break
        }

        # Amazon.SageMaker.TargetPlatformOs
        "New-SMCompilationJob/TargetPlatform_Os"
        {
            $v = "ANDROID","LINUX"
            break
        }

        # Amazon.SageMaker.ThroughputMode
        {
            ($_ -eq "New-SMFeatureGroup/ThroughputConfig_ThroughputMode") -Or
            ($_ -eq "Update-SMFeatureGroup/ThroughputConfig_ThroughputMode")
        }
        {
            $v = "OnDemand","Provisioned"
            break
        }

        # Amazon.SageMaker.TrackingServerSize
        {
            ($_ -eq "New-SMMlflowTrackingServer/TrackingServerSize") -Or
            ($_ -eq "Update-SMMlflowTrackingServer/TrackingServerSize")
        }
        {
            $v = "Large","Medium","Small"
            break
        }

        # Amazon.SageMaker.TrackingServerStatus
        "Get-SMMlflowTrackingServerList/TrackingServerStatus"
        {
            $v = "Created","CreateFailed","Creating","DeleteFailed","Deleting","MaintenanceComplete","MaintenanceFailed","MaintenanceInProgress","Started","StartFailed","Starting","StopFailed","Stopped","Stopping","Updated","UpdateFailed","Updating"
            break
        }

        # Amazon.SageMaker.TrafficRoutingConfigType
        {
            ($_ -eq "New-SMEndpoint/TrafficRoutingConfiguration_Type") -Or
            ($_ -eq "Update-SMEndpoint/TrafficRoutingConfiguration_Type")
        }
        {
            $v = "ALL_AT_ONCE","CANARY","LINEAR"
            break
        }

        # Amazon.SageMaker.TrafficType
        "New-SMInferenceRecommendationsJob/TrafficPattern_TrafficType"
        {
            $v = "PHASES","STAIRS"
            break
        }

        # Amazon.SageMaker.TrainingInputMode
        "New-SMHyperParameterTuningJob/AlgorithmSpecification_TrainingInputMode"
        {
            $v = "FastFile","File","Pipe"
            break
        }

        # Amazon.SageMaker.TrainingInstanceType
        "New-SMHyperParameterTuningJob/HyperParameterTuningResourceConfig_InstanceType"
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c5n.18xlarge","ml.c5n.2xlarge","ml.c5n.4xlarge","ml.c5n.9xlarge","ml.c5n.xlarge","ml.c6i.12xlarge","ml.c6i.16xlarge","ml.c6i.24xlarge","ml.c6i.2xlarge","ml.c6i.32xlarge","ml.c6i.4xlarge","ml.c6i.8xlarge","ml.c6i.xlarge","ml.c7i.12xlarge","ml.c7i.16xlarge","ml.c7i.24xlarge","ml.c7i.2xlarge","ml.c7i.48xlarge","ml.c7i.4xlarge","ml.c7i.8xlarge","ml.c7i.large","ml.c7i.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.g6.12xlarge","ml.g6.16xlarge","ml.g6.24xlarge","ml.g6.2xlarge","ml.g6.48xlarge","ml.g6.4xlarge","ml.g6.8xlarge","ml.g6.xlarge","ml.g6e.12xlarge","ml.g6e.16xlarge","ml.g6e.24xlarge","ml.g6e.2xlarge","ml.g6e.48xlarge","ml.g6e.4xlarge","ml.g6e.8xlarge","ml.g6e.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.large","ml.m5.xlarge","ml.m6i.12xlarge","ml.m6i.16xlarge","ml.m6i.24xlarge","ml.m6i.2xlarge","ml.m6i.32xlarge","ml.m6i.4xlarge","ml.m6i.8xlarge","ml.m6i.large","ml.m6i.xlarge","ml.m7i.12xlarge","ml.m7i.16xlarge","ml.m7i.24xlarge","ml.m7i.2xlarge","ml.m7i.48xlarge","ml.m7i.4xlarge","ml.m7i.8xlarge","ml.m7i.large","ml.m7i.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.p3dn.24xlarge","ml.p4d.24xlarge","ml.p4de.24xlarge","ml.p5.48xlarge","ml.p5e.48xlarge","ml.p5en.48xlarge","ml.p6-b200.48xlarge","ml.p6e-gb200.36xlarge","ml.r5.12xlarge","ml.r5.16xlarge","ml.r5.24xlarge","ml.r5.2xlarge","ml.r5.4xlarge","ml.r5.8xlarge","ml.r5.large","ml.r5.xlarge","ml.r5d.12xlarge","ml.r5d.16xlarge","ml.r5d.24xlarge","ml.r5d.2xlarge","ml.r5d.4xlarge","ml.r5d.8xlarge","ml.r5d.large","ml.r5d.xlarge","ml.r7i.12xlarge","ml.r7i.16xlarge","ml.r7i.24xlarge","ml.r7i.2xlarge","ml.r7i.48xlarge","ml.r7i.4xlarge","ml.r7i.8xlarge","ml.r7i.large","ml.r7i.xlarge","ml.t3.2xlarge","ml.t3.large","ml.t3.medium","ml.t3.xlarge","ml.trn1.2xlarge","ml.trn1.32xlarge","ml.trn1n.32xlarge","ml.trn2.48xlarge"
            break
        }

        # Amazon.SageMaker.TrainingJobEarlyStoppingType
        "New-SMHyperParameterTuningJob/HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType"
        {
            $v = "Auto","Off"
            break
        }

        # Amazon.SageMaker.TrainingJobSortByOptions
        "Get-SMTrainingJobsForHyperParameterTuningJobList/SortBy"
        {
            $v = "CreationTime","FinalObjectiveMetricValue","Name","Status"
            break
        }

        # Amazon.SageMaker.TrainingJobStatus
        {
            ($_ -eq "Get-SMTrainingJobList/StatusEqual") -Or
            ($_ -eq "Get-SMTrainingJobsForHyperParameterTuningJobList/StatusEqual")
        }
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.TrainingPlanSortBy
        "Get-SMTrainingPlanList/SortBy"
        {
            $v = "StartTime","Status","TrainingPlanName"
            break
        }

        # Amazon.SageMaker.TrainingPlanSortOrder
        "Get-SMTrainingPlanList/SortOrder"
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.SageMaker.TransformInstanceType
        "New-SMTransformJob/TransformResources_InstanceType"
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c6i.12xlarge","ml.c6i.16xlarge","ml.c6i.24xlarge","ml.c6i.2xlarge","ml.c6i.32xlarge","ml.c6i.4xlarge","ml.c6i.8xlarge","ml.c6i.large","ml.c6i.xlarge","ml.c7i.12xlarge","ml.c7i.16xlarge","ml.c7i.24xlarge","ml.c7i.2xlarge","ml.c7i.48xlarge","ml.c7i.4xlarge","ml.c7i.8xlarge","ml.c7i.large","ml.c7i.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.inf2.24xlarge","ml.inf2.48xlarge","ml.inf2.8xlarge","ml.inf2.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.large","ml.m5.xlarge","ml.m6i.12xlarge","ml.m6i.16xlarge","ml.m6i.24xlarge","ml.m6i.2xlarge","ml.m6i.32xlarge","ml.m6i.4xlarge","ml.m6i.8xlarge","ml.m6i.large","ml.m6i.xlarge","ml.m7i.12xlarge","ml.m7i.16xlarge","ml.m7i.24xlarge","ml.m7i.2xlarge","ml.m7i.48xlarge","ml.m7i.4xlarge","ml.m7i.8xlarge","ml.m7i.large","ml.m7i.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.r6i.12xlarge","ml.r6i.16xlarge","ml.r6i.24xlarge","ml.r6i.2xlarge","ml.r6i.32xlarge","ml.r6i.4xlarge","ml.r6i.8xlarge","ml.r6i.large","ml.r6i.xlarge","ml.r7i.12xlarge","ml.r7i.16xlarge","ml.r7i.24xlarge","ml.r7i.2xlarge","ml.r7i.48xlarge","ml.r7i.4xlarge","ml.r7i.8xlarge","ml.r7i.large","ml.r7i.xlarge","ml.trn1.2xlarge","ml.trn1.32xlarge"
            break
        }

        # Amazon.SageMaker.TransformJobStatus
        "Get-SMTransformJobList/StatusEqual"
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.TrialComponentPrimaryStatus
        {
            ($_ -eq "New-SMTrialComponent/Status_PrimaryStatus") -Or
            ($_ -eq "Update-SMTrialComponent/Status_PrimaryStatus")
        }
        {
            $v = "Completed","Failed","InProgress","Stopped","Stopping"
            break
        }

        # Amazon.SageMaker.TtlDurationUnit
        {
            ($_ -eq "New-SMFeatureGroup/TtlDuration_Unit") -Or
            ($_ -eq "Update-SMFeatureGroup/TtlDuration_Unit")
        }
        {
            $v = "Days","Hours","Minutes","Seconds","Weeks"
            break
        }

        # Amazon.SageMaker.UserProfileSortKey
        "Get-SMUserProfileList/SortBy"
        {
            $v = "CreationTime","LastModifiedTime"
            break
        }

        # Amazon.SageMaker.VendorGuidance
        {
            ($_ -eq "New-SMImageVersion/VendorGuidance") -Or
            ($_ -eq "Update-SMImageVersion/VendorGuidance")
        }
        {
            $v = "ARCHIVED","NOT_PROVIDED","STABLE","TO_BE_ARCHIVED"
            break
        }

        # Amazon.SageMaker.WarmPoolResourceStatus
        "Get-SMTrainingJobList/WarmPoolStatusEqual"
        {
            $v = "Available","InUse","Reused","Terminated"
            break
        }

        # Amazon.SageMaker.WorkforceIpAddressType
        {
            ($_ -eq "New-SMWorkforce/IpAddressType") -Or
            ($_ -eq "Update-SMWorkforce/IpAddressType")
        }
        {
            $v = "dualstack","ipv4"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SM_map = @{
    "ActivationState"=@("New-SMComputeQuota","Update-SMComputeQuota")
    "AdditionalS3DataSource_CompressionType"=@("New-SMAlgorithm")
    "AdditionalS3DataSource_S3DataType"=@("New-SMAlgorithm")
    "AlgorithmSpecification_TrainingInputMode"=@("New-SMHyperParameterTuningJob")
    "AmazonQSettings_Status"=@("New-SMDomain","Update-SMDomain")
    "AppNetworkAccessType"=@("New-SMDomain","Update-SMDomain")
    "AppSecurityGroupManagement"=@("New-SMDomain","Update-SMDomain")
    "AppType"=@("Get-SMApp","New-SMApp","Remove-SMApp")
    "AppTypeEqual"=@("Get-SMStudioLifecycleConfigList")
    "AssociationType"=@("Add-SMAssociation","Get-SMAssociationList")
    "AuthMode"=@("New-SMDomain")
    "AuthType"=@("New-SMPartnerApp")
    "AutoMLJobConfig_Mode"=@("New-SMAutoMLJob")
    "AutoMLJobObjective_MetricName"=@("New-SMAutoMLJob","New-SMAutoMLJobV2")
    "Autotune_Mode"=@("New-SMHyperParameterTuningJob")
    "BatchStrategy"=@("New-SMTransformJob")
    "BatchTransformInput_S3DataDistributionType"=@("New-SMDataQualityJobDefinition","New-SMModelBiasJobDefinition","New-SMModelExplainabilityJobDefinition","New-SMModelQualityJobDefinition")
    "BatchTransformInput_S3InputMode"=@("New-SMDataQualityJobDefinition","New-SMModelBiasJobDefinition","New-SMModelExplainabilityJobDefinition","New-SMModelQualityJobDefinition")
    "CanarySize_Type"=@("New-SMEndpoint","Update-SMEndpoint")
    "ClusterConfig_InstanceType"=@("New-SMDataQualityJobDefinition","New-SMModelBiasJobDefinition","New-SMModelExplainabilityJobDefinition","New-SMModelQualityJobDefinition","New-SMProcessingJob")
    "ComputeQuotaConfig_PreemptTeamTask"=@("New-SMComputeQuota","Update-SMComputeQuota")
    "ContainerConfig_SupportedEndpointType"=@("New-SMInferenceRecommendationsJob")
    "ConvergenceDetected_CompleteOnConvergence"=@("New-SMHyperParameterTuningJob")
    "CrossAccountFilterOption"=@("Get-SMModelPackageGroupList","Search-SMResource")
    "DataProcessing_JoinSource"=@("New-SMTransformJob")
    "DefaultResourceSpec_InstanceType"=@("New-SMDomain","Update-SMDomain")
    "DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType"=@("New-SMDomain","Update-SMDomain")
    "DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType"=@("New-SMDomain","Update-SMDomain")
    "DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType"=@("New-SMDomain","Update-SMDomain")
    "DeploymentInstanceType"=@("New-SMOptimizationJob")
    "DesiredState"=@("Stop-SMInferenceExperiment")
    "DirectInternetAccess"=@("New-SMNotebookInstance")
    "Direction"=@("Find-SMLineage")
    "DockerSettings_EnableDockerAccess"=@("New-SMDomain","Update-SMDomain")
    "DomainSettings_ExecutionRoleIdentityConfig"=@("New-SMDomain")
    "DomainSettingsForUpdate_ExecutionRoleIdentityConfig"=@("Update-SMDomain")
    "EndpointInput_S3DataDistributionType"=@("New-SMDataQualityJobDefinition","New-SMModelBiasJobDefinition","New-SMModelExplainabilityJobDefinition","New-SMModelQualityJobDefinition")
    "EndpointInput_S3InputMode"=@("New-SMDataQualityJobDefinition","New-SMModelBiasJobDefinition","New-SMModelExplainabilityJobDefinition","New-SMModelQualityJobDefinition")
    "FeatureGroupStatusEqual"=@("Get-SMFeatureGroupList")
    "HubContentType"=@("Get-SMHubContent","Get-SMHubContentList","Get-SMHubContentVersionList","Import-SMHubContent","New-SMHubContentPresignedUrl","Remove-SMHubContent","Remove-SMHubContentReference","Update-SMHubContent","Update-SMHubContentReference")
    "HumanLoopRequestSource_AwsManagedHumanLoopRequestSource"=@("New-SMFlowDefinition")
    "HyperParameterTuningJobConfig_Strategy"=@("New-SMHyperParameterTuningJob")
    "HyperParameterTuningJobConfig_TrainingJobEarlyStoppingType"=@("New-SMHyperParameterTuningJob")
    "HyperParameterTuningJobObjective_Type"=@("New-SMHyperParameterTuningJob")
    "HyperParameterTuningResourceConfig_AllocationStrategy"=@("New-SMHyperParameterTuningJob")
    "HyperParameterTuningResourceConfig_InstanceType"=@("New-SMHyperParameterTuningJob")
    "IamPolicyConstraints_SourceIp"=@("New-SMWorkteam","Update-SMWorkteam")
    "IamPolicyConstraints_VpcSourceIp"=@("New-SMWorkteam","Update-SMWorkteam")
    "IdleSettings_LifecycleManagement"=@("New-SMDomain","Update-SMDomain")
    "InferenceExecutionConfig_Mode"=@("New-SMModel")
    "InputConfig_Framework"=@("New-SMCompilationJob")
    "InstanceType"=@("New-SMNotebookInstance","Search-SMTrainingPlanOffering","Update-SMNotebookInstance")
    "IpAddressType"=@("New-SMWorkforce","Update-SMWorkforce")
    "JobType"=@("New-SMImageVersion","New-SMInferenceRecommendationsJob","Update-SMImageVersion")
    "LinearStepSize_Type"=@("New-SMEndpoint","Update-SMEndpoint")
    "MaximumBatchSize_Type"=@("New-SMEndpoint","Update-SMClusterSoftware","Update-SMEndpoint","Update-SMInferenceComponent")
    "ModelApprovalStatus"=@("Get-SMModelPackageList","New-SMModelPackage","Update-SMModelPackage")
    "ModelCard_ModelCardStatus"=@("New-SMModelPackage","Update-SMModelPackage")
    "ModelCardStatus"=@("Get-SMModelCardList","Get-SMModelCardVersionList","New-SMModelCard","Update-SMModelCard")
    "ModelPackageType"=@("Get-SMModelPackageList")
    "ModelQualityAppSpecification_ProblemType"=@("New-SMModelQualityJobDefinition")
    "MonitoringTypeEqual"=@("Get-SMMonitoringExecutionList","Get-SMMonitoringScheduleList")
    "NodeProvisioningMode"=@("New-SMCluster")
    "NodeRecovery"=@("New-SMCluster","Update-SMCluster")
    "OfflineStoreConfig_TableFormat"=@("New-SMFeatureGroup")
    "OfflineStoreStatusEqual"=@("Get-SMFeatureGroupList")
    "OnlineStoreConfig_StorageType"=@("New-SMFeatureGroup")
    "OutputConfig_PresetDeploymentType"=@("New-SMDeviceFleet","New-SMEdgePackagingJob","Update-SMDeviceFleet")
    "OutputConfig_TargetDevice"=@("New-SMCompilationJob")
    "ProblemType"=@("New-SMAutoMLJob")
    "Processor"=@("New-SMImageVersion","Update-SMImageVersion")
    "Resource"=@("Get-SMSearchSuggestion","Search-SMResource")
    "ResourceSharingConfig_Strategy"=@("New-SMComputeQuota","Update-SMComputeQuota")
    "ResourceSpec_InstanceType"=@("New-SMApp")
    "ResourceType"=@("Get-SMClusterEventList")
    "RetentionPolicy_HomeEfsFileSystem"=@("Remove-SMDomain")
    "RollbackMaximumBatchSize_Type"=@("New-SMEndpoint","Update-SMClusterSoftware","Update-SMEndpoint","Update-SMInferenceComponent")
    "RootAccess"=@("New-SMNotebookInstance","Update-SMNotebookInstance")
    "S3DataSource_S3DataType"=@("New-SMTransformJob")
    "SchedulerConfig_FairShare"=@("New-SMClusterSchedulerConfig","Update-SMClusterSchedulerConfig")
    "SearchExpression_Operator"=@("Search-SMResource")
    "SkipModelValidation"=@("New-SMModelPackage")
    "SortBy"=@("Get-SMActionList","Get-SMAlgorithmList","Get-SMAppImageConfigList","Get-SMAppList","Get-SMArtifactList","Get-SMAssociationList","Get-SMAutoMLJobList","Get-SMCandidatesForAutoMLJobList","Get-SMClusterEventList","Get-SMClusterList","Get-SMClusterNodeList","Get-SMClusterSchedulerConfigList","Get-SMCodeRepositoryList","Get-SMCompilationJobList","Get-SMComputeQuotaList","Get-SMConfigList","Get-SMContextList","Get-SMDataQualityJobDefinitionList","Get-SMDeviceFleetList","Get-SMEdgeDeploymentPlanList","Get-SMEdgePackagingJobList","Get-SMEndpointList","Get-SMExperimentList","Get-SMFeatureGroupList","Get-SMHubContentList","Get-SMHubContentVersionList","Get-SMHubList","Get-SMHyperParameterTuningJobList","Get-SMImageList","Get-SMImageVersionList","Get-SMInferenceComponentList","Get-SMInferenceExperimentList","Get-SMInferenceRecommendationsJobList","Get-SMLabelingJobList","Get-SMLabelingJobListForWorkteam","Get-SMLineageGroupList","Get-SMMlflowTrackingServerList","Get-SMModelBiasJobDefinitionList","Get-SMModelCardExportJobList","Get-SMModelCardList","Get-SMModelCardVersionList","Get-SMModelExplainabilityJobDefinitionList","Get-SMModelList","Get-SMModelPackageGroupList","Get-SMModelPackageList","Get-SMModelQualityJobDefinitionList","Get-SMMonitoringAlertHistoryList","Get-SMMonitoringExecutionList","Get-SMMonitoringScheduleList","Get-SMNotebookInstanceLifecycleConfigList","Get-SMNotebookInstanceList","Get-SMOptimizationJobList","Get-SMPipelineExecutionList","Get-SMPipelineList","Get-SMProcessingJobList","Get-SMProjectList","Get-SMResourceCatalogList","Get-SMSpaceList","Get-SMStudioLifecycleConfigList","Get-SMTrainingJobList","Get-SMTrainingJobsForHyperParameterTuningJobList","Get-SMTrainingPlanList","Get-SMTransformJobList","Get-SMTrialComponentList","Get-SMTrialList","Get-SMUserProfileList","Get-SMWorkforceList","Get-SMWorkteamList")
    "SortOrder"=@("Get-SMActionList","Get-SMAlgorithmList","Get-SMAppImageConfigList","Get-SMAppList","Get-SMArtifactList","Get-SMAssociationList","Get-SMAutoMLJobList","Get-SMCandidatesForAutoMLJobList","Get-SMClusterEventList","Get-SMClusterList","Get-SMClusterNodeList","Get-SMClusterSchedulerConfigList","Get-SMCodeRepositoryList","Get-SMCompilationJobList","Get-SMComputeQuotaList","Get-SMConfigList","Get-SMContextList","Get-SMDataQualityJobDefinitionList","Get-SMDeviceFleetList","Get-SMEdgeDeploymentPlanList","Get-SMEdgePackagingJobList","Get-SMEndpointList","Get-SMExperimentList","Get-SMFeatureGroupList","Get-SMFlowDefinitionList","Get-SMHubContentList","Get-SMHubContentVersionList","Get-SMHubList","Get-SMHumanTaskUiList","Get-SMHyperParameterTuningJobList","Get-SMImageList","Get-SMImageVersionList","Get-SMInferenceComponentList","Get-SMInferenceExperimentList","Get-SMInferenceRecommendationsJobList","Get-SMLabelingJobList","Get-SMLabelingJobListForWorkteam","Get-SMLineageGroupList","Get-SMMlflowTrackingServerList","Get-SMModelBiasJobDefinitionList","Get-SMModelCardExportJobList","Get-SMModelCardList","Get-SMModelCardVersionList","Get-SMModelExplainabilityJobDefinitionList","Get-SMModelList","Get-SMModelPackageGroupList","Get-SMModelPackageList","Get-SMModelQualityJobDefinitionList","Get-SMMonitoringAlertHistoryList","Get-SMMonitoringExecutionList","Get-SMMonitoringScheduleList","Get-SMNotebookInstanceLifecycleConfigList","Get-SMNotebookInstanceList","Get-SMOptimizationJobList","Get-SMPipelineExecutionList","Get-SMPipelineExecutionStepList","Get-SMPipelineList","Get-SMPipelineVersionList","Get-SMProcessingJobList","Get-SMProjectList","Get-SMResourceCatalogList","Get-SMSpaceList","Get-SMStudioLifecycleConfigList","Get-SMTrainingJobList","Get-SMTrainingJobsForHyperParameterTuningJobList","Get-SMTrainingPlanList","Get-SMTransformJobList","Get-SMTrialComponentList","Get-SMTrialList","Get-SMUserProfileList","Get-SMWorkforceList","Get-SMWorkteamList","Search-SMResource")
    "SpaceSettings_AppType"=@("New-SMSpace","Update-SMSpace")
    "SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType"=@("New-SMSpace","Update-SMSpace")
    "SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType"=@("New-SMSpace","Update-SMSpace")
    "SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType"=@("New-SMSpace","Update-SMSpace")
    "SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType"=@("New-SMSpace","Update-SMSpace")
    "SpaceSettings_RemoteAccess"=@("New-SMSpace","Update-SMSpace")
    "SpaceSettings_SpaceManagedResource"=@("New-SMSpace","Update-SMSpace")
    "SpaceSharingSettings_SharingType"=@("New-SMSpace")
    "Status"=@("Get-SMClusterSchedulerConfigList","Get-SMComputeQuotaList","Get-SMInferenceRecommendationsJobStepList","New-SMAction","Update-SMAction")
    "Status_PrimaryStatus"=@("New-SMTrialComponent","Update-SMTrialComponent")
    "StatusEqual"=@("Get-SMAutoMLJobList","Get-SMCandidatesForAutoMLJobList","Get-SMCompilationJobList","Get-SMEdgePackagingJobList","Get-SMEndpointList","Get-SMHyperParameterTuningJobList","Get-SMInferenceComponentList","Get-SMInferenceExperimentList","Get-SMInferenceRecommendationsJobList","Get-SMLabelingJobList","Get-SMModelCardExportJobList","Get-SMMonitoringAlertHistoryList","Get-SMMonitoringExecutionList","Get-SMMonitoringScheduleList","Get-SMNotebookInstanceList","Get-SMOptimizationJobList","Get-SMProcessingJobList","Get-SMTrainingJobList","Get-SMTrainingJobsForHyperParameterTuningJobList","Get-SMTransformJobList")
    "StepType"=@("Get-SMInferenceRecommendationsJobStepList")
    "StoppingConditions_FlatInvocation"=@("New-SMInferenceRecommendationsJob")
    "StudioLifecycleConfigAppType"=@("New-SMStudioLifecycleConfig")
    "SupportStatus"=@("Import-SMHubContent","Update-SMHubContent")
    "TabularJobConfig_Mode"=@("New-SMAutoMLJobV2")
    "TabularJobConfig_ProblemType"=@("New-SMAutoMLJobV2")
    "TagPropagation"=@("New-SMDomain","Update-SMDomain")
    "TargetPlatform_Accelerator"=@("New-SMCompilationJob")
    "TargetPlatform_Arch"=@("New-SMCompilationJob")
    "TargetPlatform_Os"=@("New-SMCompilationJob")
    "TextConfig_Granularity"=@("New-SMEndpointConfig")
    "TextConfig_Language"=@("New-SMEndpointConfig")
    "ThroughputConfig_ThroughputMode"=@("New-SMFeatureGroup","Update-SMFeatureGroup")
    "TrackingServerSize"=@("New-SMMlflowTrackingServer","Update-SMMlflowTrackingServer")
    "TrackingServerStatus"=@("Get-SMMlflowTrackingServerList")
    "TrafficPattern_TrafficType"=@("New-SMInferenceRecommendationsJob")
    "TrafficRoutingConfiguration_Type"=@("New-SMEndpoint","Update-SMEndpoint")
    "TransformInput_CompressionType"=@("New-SMTransformJob")
    "TransformInput_SplitType"=@("New-SMTransformJob")
    "TransformOutput_AssembleWith"=@("New-SMTransformJob")
    "TransformResources_InstanceType"=@("New-SMTransformJob")
    "TrustedIdentityPropagationSettings_Status"=@("New-SMDomain","Update-SMDomain")
    "TtlDuration_Unit"=@("New-SMFeatureGroup","Update-SMFeatureGroup")
    "TuningObjective_Type"=@("New-SMHyperParameterTuningJob")
    "Type"=@("Get-SMInferenceExperimentList","New-SMInferenceExperiment","New-SMPartnerApp")
    "UnifiedStudioSettings_StudioWebPortalAccess"=@("New-SMDomain","Update-SMDomain")
    "VendorGuidance"=@("New-SMImageVersion","Update-SMImageVersion")
    "WarmPoolStatusEqual"=@("Get-SMTrainingJobList")
    "WarmStartConfig_WarmStartType"=@("New-SMHyperParameterTuningJob")
}

_awsArgumentCompleterRegistration $SM_Completers $SM_map

$SM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SM.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SM_SelectMap = @{
    "Select"=@("Add-SMAssociation",
               "Add-SMResourceTag",
               "Register-SMTrialComponent",
               "Mount-SMClusterNodeVolume",
               "Set-SMAddClusterNode",
               "Set-SMDeleteClusterNode",
               "Get-SMDescribeModelPackage",
               "New-SMAction",
               "New-SMAlgorithm",
               "New-SMApp",
               "New-SMAppImageConfig",
               "New-SMArtifact",
               "New-SMAutoMLJob",
               "New-SMAutoMLJobV2",
               "New-SMCluster",
               "New-SMClusterSchedulerConfig",
               "New-SMCodeRepository",
               "New-SMCompilationJob",
               "New-SMComputeQuota",
               "New-SMContext",
               "New-SMDataQualityJobDefinition",
               "New-SMDeviceFleet",
               "New-SMDomain",
               "New-SMEdgeDeploymentPlan",
               "New-SMEdgeDeploymentStage",
               "New-SMEdgePackagingJob",
               "New-SMEndpoint",
               "New-SMEndpointConfig",
               "New-SMExperiment",
               "New-SMFeatureGroup",
               "New-SMFlowDefinition",
               "New-SMHub",
               "New-SMHubContentPresignedUrl",
               "New-SMHubContentReference",
               "New-SMHumanTaskUi",
               "New-SMHyperParameterTuningJob",
               "New-SMImage",
               "New-SMImageVersion",
               "New-SMInferenceComponent",
               "New-SMInferenceExperiment",
               "New-SMInferenceRecommendationsJob",
               "New-SMLabelingJob",
               "New-SMMlflowTrackingServer",
               "New-SMModel",
               "New-SMModelBiasJobDefinition",
               "New-SMModelCard",
               "New-SMModelCardExportJob",
               "New-SMModelExplainabilityJobDefinition",
               "New-SMModelPackage",
               "New-SMModelPackageGroup",
               "New-SMModelQualityJobDefinition",
               "New-SMMonitoringSchedule",
               "New-SMNotebookInstance",
               "New-SMNotebookInstanceLifecycleConfig",
               "New-SMOptimizationJob",
               "New-SMPartnerApp",
               "New-SMPartnerAppPresignedUrl",
               "New-SMPipeline",
               "New-SMPresignedDomainUrl",
               "New-SMPresignedMlflowTrackingServerUrl",
               "New-SMPresignedNotebookInstanceUrl",
               "New-SMProcessingJob",
               "New-SMProject",
               "New-SMSpace",
               "New-SMStudioLifecycleConfig",
               "New-SMTrainingJob",
               "New-SMTrainingPlan",
               "New-SMTransformJob",
               "New-SMTrial",
               "New-SMTrialComponent",
               "New-SMUserProfile",
               "New-SMWorkforce",
               "New-SMWorkteam",
               "Remove-SMAction",
               "Remove-SMAlgorithm",
               "Remove-SMApp",
               "Remove-SMAppImageConfig",
               "Remove-SMArtifact",
               "Remove-SMAssociation",
               "Remove-SMCluster",
               "Remove-SMClusterSchedulerConfig",
               "Remove-SMCodeRepository",
               "Remove-SMCompilationJob",
               "Remove-SMComputeQuota",
               "Remove-SMContext",
               "Remove-SMDataQualityJobDefinition",
               "Remove-SMDeviceFleet",
               "Remove-SMDomain",
               "Remove-SMEdgeDeploymentPlan",
               "Remove-SMEdgeDeploymentStage",
               "Remove-SMEndpoint",
               "Remove-SMEndpointConfig",
               "Remove-SMExperiment",
               "Remove-SMFeatureGroup",
               "Remove-SMFlowDefinition",
               "Remove-SMHub",
               "Remove-SMHubContent",
               "Remove-SMHubContentReference",
               "Remove-SMHumanTaskUi",
               "Remove-SMHyperParameterTuningJob",
               "Remove-SMImage",
               "Remove-SMImageVersion",
               "Remove-SMInferenceComponent",
               "Remove-SMInferenceExperiment",
               "Remove-SMMlflowTrackingServer",
               "Remove-SMModel",
               "Remove-SMModelBiasJobDefinition",
               "Remove-SMModelCard",
               "Remove-SMModelExplainabilityJobDefinition",
               "Remove-SMModelPackage",
               "Remove-SMModelPackageGroup",
               "Remove-SMModelPackageGroupPolicy",
               "Remove-SMModelQualityJobDefinition",
               "Remove-SMMonitoringSchedule",
               "Remove-SMNotebookInstance",
               "Remove-SMNotebookInstanceLifecycleConfig",
               "Remove-SMOptimizationJob",
               "Remove-SMPartnerApp",
               "Remove-SMPipeline",
               "Remove-SMProject",
               "Remove-SMSpace",
               "Remove-SMStudioLifecycleConfig",
               "Remove-SMResourceTag",
               "Remove-SMTrial",
               "Remove-SMTrialComponent",
               "Remove-SMUserProfile",
               "Remove-SMWorkforce",
               "Remove-SMWorkteam",
               "Remove-SMDevice",
               "Get-SMAction",
               "Get-SMAlgorithm",
               "Get-SMApp",
               "Get-SMAppImageConfig",
               "Get-SMArtifact",
               "Get-SMAutoMLJob",
               "Get-SMAutoMLJobV2",
               "Get-SMCluster",
               "Get-SMClusterEvent",
               "Get-SMClusterNode",
               "Get-SMClusterSchedulerConfig",
               "Get-SMCodeRepository",
               "Get-SMCompilationJob",
               "Get-SMComputeQuota",
               "Get-SMContext",
               "Get-SMDataQualityJobDefinition",
               "Get-SMDevice",
               "Get-SMDeviceFleet",
               "Get-SMDomain",
               "Get-SMEdgeDeploymentPlan",
               "Get-SMEdgePackagingJob",
               "Get-SMEndpoint",
               "Get-SMEndpointConfig",
               "Get-SMExperiment",
               "Get-SMFeatureGroup",
               "Get-SMFeatureMetadata",
               "Get-SMFlowDefinition",
               "Get-SMHub",
               "Get-SMHubContent",
               "Get-SMHumanTaskUi",
               "Get-SMHyperParameterTuningJob",
               "Get-SMImage",
               "Get-SMImageVersion",
               "Get-SMInferenceComponent",
               "Get-SMInferenceExperiment",
               "Get-SMInferenceRecommendationsJob",
               "Get-SMLabelingJob",
               "Get-SMLineageGroup",
               "Get-SMMlflowTrackingServer",
               "Get-SMModel",
               "Get-SMModelBiasJobDefinition",
               "Get-SMModelCard",
               "Get-SMModelCardExportJob",
               "Get-SMModelExplainabilityJobDefinition",
               "Get-SMModelPackage",
               "Get-SMModelPackageGroup",
               "Get-SMModelQualityJobDefinition",
               "Get-SMMonitoringSchedule",
               "Get-SMNotebookInstance",
               "Get-SMNotebookInstanceLifecycleConfig",
               "Get-SMOptimizationJob",
               "Get-SMPartnerApp",
               "Get-SMPipeline",
               "Get-SMPipelineDefinitionForExecution",
               "Get-SMPipelineExecution",
               "Get-SMProcessingJob",
               "Get-SMProject",
               "Get-SMReservedCapacity",
               "Get-SMSpace",
               "Get-SMStudioLifecycleConfig",
               "Get-SMSubscribedWorkteam",
               "Get-SMTrainingJob",
               "Get-SMTrainingPlan",
               "Get-SMTransformJob",
               "Get-SMTrial",
               "Get-SMTrialComponent",
               "Get-SMUserProfile",
               "Get-SMWorkforce",
               "Get-SMWorkteam",
               "Dismount-SMClusterNodeVolume",
               "Disable-SMSagemakerServicecatalogPortfolio",
               "Unregister-SMTrialComponent",
               "Enable-SMSagemakerServicecatalogPortfolio",
               "Get-SMDeviceFleetReport",
               "Get-SMLineageGroupPolicy",
               "Get-SMModelPackageGroupPolicy",
               "Get-SMSagemakerServicecatalogPortfolioStatus",
               "Get-SMScalingConfigurationRecommendation",
               "Get-SMSearchSuggestion",
               "Import-SMHubContent",
               "Get-SMActionList",
               "Get-SMAlgorithmList",
               "Get-SMAliasList",
               "Get-SMAppImageConfigList",
               "Get-SMAppList",
               "Get-SMArtifactList",
               "Get-SMAssociationList",
               "Get-SMAutoMLJobList",
               "Get-SMCandidatesForAutoMLJobList",
               "Get-SMClusterEventList",
               "Get-SMClusterNodeList",
               "Get-SMClusterList",
               "Get-SMClusterSchedulerConfigList",
               "Get-SMCodeRepositoryList",
               "Get-SMCompilationJobList",
               "Get-SMComputeQuotaList",
               "Get-SMContextList",
               "Get-SMDataQualityJobDefinitionList",
               "Get-SMDeviceFleetList",
               "Get-SMDeviceList",
               "Get-SMDomainList",
               "Get-SMEdgeDeploymentPlanList",
               "Get-SMEdgePackagingJobList",
               "Get-SMConfigList",
               "Get-SMEndpointList",
               "Get-SMExperimentList",
               "Get-SMFeatureGroupList",
               "Get-SMFlowDefinitionList",
               "Get-SMHubContentList",
               "Get-SMHubContentVersionList",
               "Get-SMHubList",
               "Get-SMHumanTaskUiList",
               "Get-SMHyperParameterTuningJobList",
               "Get-SMImageList",
               "Get-SMImageVersionList",
               "Get-SMInferenceComponentList",
               "Get-SMInferenceExperimentList",
               "Get-SMInferenceRecommendationsJobList",
               "Get-SMInferenceRecommendationsJobStepList",
               "Get-SMLabelingJobList",
               "Get-SMLabelingJobListForWorkteam",
               "Get-SMLineageGroupList",
               "Get-SMMlflowTrackingServerList",
               "Get-SMModelBiasJobDefinitionList",
               "Get-SMModelCardExportJobList",
               "Get-SMModelCardList",
               "Get-SMModelCardVersionList",
               "Get-SMModelExplainabilityJobDefinitionList",
               "Get-SMModelMetadataList",
               "Get-SMModelPackageGroupList",
               "Get-SMModelPackageList",
               "Get-SMModelQualityJobDefinitionList",
               "Get-SMModelList",
               "Get-SMMonitoringAlertHistoryList",
               "Get-SMMonitoringAlertList",
               "Get-SMMonitoringExecutionList",
               "Get-SMMonitoringScheduleList",
               "Get-SMNotebookInstanceLifecycleConfigList",
               "Get-SMNotebookInstanceList",
               "Get-SMOptimizationJobList",
               "Get-SMPartnerAppList",
               "Get-SMPipelineExecutionList",
               "Get-SMPipelineExecutionStepList",
               "Get-SMPipelineParametersForExecutionList",
               "Get-SMPipelineList",
               "Get-SMPipelineVersionList",
               "Get-SMProcessingJobList",
               "Get-SMProjectList",
               "Get-SMResourceCatalogList",
               "Get-SMSpaceList",
               "Get-SMStageDeviceList",
               "Get-SMStudioLifecycleConfigList",
               "Get-SMSubscribedWorkteamList",
               "Get-SMResourceTagList",
               "Get-SMTrainingJobList",
               "Get-SMTrainingJobsForHyperParameterTuningJobList",
               "Get-SMTrainingPlanList",
               "Get-SMTransformJobList",
               "Get-SMTrialComponentList",
               "Get-SMTrialList",
               "Get-SMUltraServersByReservedCapacityList",
               "Get-SMUserProfileList",
               "Get-SMWorkforceList",
               "Get-SMWorkteamList",
               "Write-SMModelPackageGroupPolicy",
               "Find-SMLineage",
               "Register-SMDevice",
               "Invoke-SMUiTemplateRendering",
               "Restart-SMPipelineExecution",
               "Search-SMResource",
               "Search-SMTrainingPlanOffering",
               "Send-SMPipelineExecutionStepFailure",
               "Send-SMPipelineExecutionStepSuccess",
               "Start-SMEdgeDeploymentStage",
               "Start-SMInferenceExperiment",
               "Start-SMMlflowTrackingServer",
               "Start-SMMonitoringSchedule",
               "Start-SMNotebookInstance",
               "Start-SMPipelineExecution",
               "Start-SMSession",
               "Stop-SMAutoMLJob",
               "Stop-SMCompilationJob",
               "Stop-SMEdgeDeploymentStage",
               "Stop-SMEdgePackagingJob",
               "Stop-SMHyperParameterTuningJob",
               "Stop-SMInferenceExperiment",
               "Stop-SMInferenceRecommendationsJob",
               "Stop-SMLabelingJob",
               "Stop-SMMlflowTrackingServer",
               "Stop-SMMonitoringSchedule",
               "Stop-SMNotebookInstance",
               "Stop-SMOptimizationJob",
               "Stop-SMPipelineExecution",
               "Stop-SMProcessingJob",
               "Stop-SMTrainingJob",
               "Stop-SMTransformJob",
               "Update-SMAction",
               "Update-SMAppImageConfig",
               "Update-SMArtifact",
               "Update-SMCluster",
               "Update-SMClusterSchedulerConfig",
               "Update-SMClusterSoftware",
               "Update-SMCodeRepository",
               "Update-SMComputeQuota",
               "Update-SMContext",
               "Update-SMDeviceFleet",
               "Update-SMDevice",
               "Update-SMDomain",
               "Update-SMEndpoint",
               "Update-SMEndpointWeightAndCapacity",
               "Update-SMExperiment",
               "Update-SMFeatureGroup",
               "Update-SMFeatureMetadata",
               "Update-SMHub",
               "Update-SMHubContent",
               "Update-SMHubContentReference",
               "Update-SMImage",
               "Update-SMImageVersion",
               "Update-SMInferenceComponent",
               "Update-SMInferenceComponentRuntimeConfig",
               "Update-SMInferenceExperiment",
               "Update-SMMlflowTrackingServer",
               "Update-SMModelCard",
               "Update-SMModelPackage",
               "Update-SMMonitoringAlert",
               "Update-SMMonitoringSchedule",
               "Update-SMNotebookInstance",
               "Update-SMNotebookInstanceLifecycleConfig",
               "Update-SMPartnerApp",
               "Update-SMPipeline",
               "Update-SMPipelineExecution",
               "Update-SMPipelineVersion",
               "Update-SMProject",
               "Update-SMSpace",
               "Update-SMTrainingJob",
               "Update-SMTrial",
               "Update-SMTrialComponent",
               "Update-SMUserProfile",
               "Update-SMWorkforce",
               "Update-SMWorkteam")
}

_awsArgumentCompleterRegistration $SM_SelectCompleters $SM_SelectMap

