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

# Argument completions for service CleanRoomsML


$CRML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CleanRoomsML.AudienceSizeType
        {
            ($_ -eq "Start-CRMLAudienceExportJob/AudienceSize_Type") -Or
            ($_ -eq "New-CRMLConfiguredAudienceModel/AudienceSizeConfig_AudienceSizeType") -Or
            ($_ -eq "Update-CRMLConfiguredAudienceModel/AudienceSizeConfig_AudienceSizeType")
        }
        {
            $v = "ABSOLUTE","PERCENTAGE"
            break
        }

        # Amazon.CleanRoomsML.InferenceInstanceType
        "Start-CRMLTrainedModelInferenceJob/ResourceConfig_InstanceType"
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c6i.12xlarge","ml.c6i.16xlarge","ml.c6i.24xlarge","ml.c6i.2xlarge","ml.c6i.32xlarge","ml.c6i.4xlarge","ml.c6i.8xlarge","ml.c6i.large","ml.c6i.xlarge","ml.c7i.12xlarge","ml.c7i.16xlarge","ml.c7i.24xlarge","ml.c7i.2xlarge","ml.c7i.48xlarge","ml.c7i.4xlarge","ml.c7i.8xlarge","ml.c7i.large","ml.c7i.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.large","ml.m5.xlarge","ml.m6i.12xlarge","ml.m6i.16xlarge","ml.m6i.24xlarge","ml.m6i.2xlarge","ml.m6i.32xlarge","ml.m6i.4xlarge","ml.m6i.8xlarge","ml.m6i.large","ml.m6i.xlarge","ml.m7i.12xlarge","ml.m7i.16xlarge","ml.m7i.24xlarge","ml.m7i.2xlarge","ml.m7i.48xlarge","ml.m7i.4xlarge","ml.m7i.8xlarge","ml.m7i.large","ml.m7i.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.r6i.12xlarge","ml.r6i.16xlarge","ml.r6i.24xlarge","ml.r6i.2xlarge","ml.r6i.32xlarge","ml.r6i.4xlarge","ml.r6i.8xlarge","ml.r6i.large","ml.r6i.xlarge","ml.r7i.12xlarge","ml.r7i.16xlarge","ml.r7i.24xlarge","ml.r7i.2xlarge","ml.r7i.48xlarge","ml.r7i.4xlarge","ml.r7i.8xlarge","ml.r7i.large","ml.r7i.xlarge"
            break
        }

        # Amazon.CleanRoomsML.InstanceType
        "New-CRMLTrainedModel/ResourceConfig_InstanceType"
        {
            $v = "ml.c4.2xlarge","ml.c4.4xlarge","ml.c4.8xlarge","ml.c4.xlarge","ml.c5.18xlarge","ml.c5.2xlarge","ml.c5.4xlarge","ml.c5.9xlarge","ml.c5.xlarge","ml.c5n.18xlarge","ml.c5n.2xlarge","ml.c5n.4xlarge","ml.c5n.9xlarge","ml.c5n.xlarge","ml.c6i.12xlarge","ml.c6i.16xlarge","ml.c6i.24xlarge","ml.c6i.2xlarge","ml.c6i.32xlarge","ml.c6i.4xlarge","ml.c6i.8xlarge","ml.c6i.xlarge","ml.g4dn.12xlarge","ml.g4dn.16xlarge","ml.g4dn.2xlarge","ml.g4dn.4xlarge","ml.g4dn.8xlarge","ml.g4dn.xlarge","ml.g5.12xlarge","ml.g5.16xlarge","ml.g5.24xlarge","ml.g5.2xlarge","ml.g5.48xlarge","ml.g5.4xlarge","ml.g5.8xlarge","ml.g5.xlarge","ml.m4.10xlarge","ml.m4.16xlarge","ml.m4.2xlarge","ml.m4.4xlarge","ml.m4.xlarge","ml.m5.12xlarge","ml.m5.24xlarge","ml.m5.2xlarge","ml.m5.4xlarge","ml.m5.large","ml.m5.xlarge","ml.m6i.12xlarge","ml.m6i.16xlarge","ml.m6i.24xlarge","ml.m6i.2xlarge","ml.m6i.32xlarge","ml.m6i.4xlarge","ml.m6i.8xlarge","ml.m6i.large","ml.m6i.xlarge","ml.p2.16xlarge","ml.p2.8xlarge","ml.p2.xlarge","ml.p3.16xlarge","ml.p3.2xlarge","ml.p3.8xlarge","ml.p3dn.24xlarge","ml.p4d.24xlarge","ml.p4de.24xlarge","ml.p5.48xlarge","ml.r5.12xlarge","ml.r5.16xlarge","ml.r5.24xlarge","ml.r5.2xlarge","ml.r5.4xlarge","ml.r5.8xlarge","ml.r5.large","ml.r5.xlarge","ml.r5d.12xlarge","ml.r5d.16xlarge","ml.r5d.24xlarge","ml.r5d.2xlarge","ml.r5d.4xlarge","ml.r5d.8xlarge","ml.r5d.large","ml.r5d.xlarge","ml.t3.2xlarge","ml.t3.large","ml.t3.medium","ml.t3.xlarge","ml.trn1.2xlarge","ml.trn1.32xlarge","ml.trn1n.32xlarge"
            break
        }

        # Amazon.CleanRoomsML.NoiseLevelType
        "New-CRMLConfiguredModelAlgorithmAssociation/ContainerMetrics_NoiseLevel"
        {
            $v = "HIGH","LOW","MEDIUM","NONE"
            break
        }

        # Amazon.CleanRoomsML.PolicyExistenceCondition
        "Write-CRMLConfiguredAudienceModelPolicy/PolicyExistenceCondition"
        {
            $v = "POLICY_MUST_EXIST","POLICY_MUST_NOT_EXIST"
            break
        }

        # Amazon.CleanRoomsML.TagOnCreatePolicy
        "New-CRMLConfiguredAudienceModel/ChildResourceTagOnCreatePolicy"
        {
            $v = "FROM_PARENT_RESOURCE","NONE"
            break
        }

        # Amazon.CleanRoomsML.TrainedModelExportsMaxSizeUnitType
        "New-CRMLConfiguredModelAlgorithmAssociation/MaxSize_Unit"
        {
            $v = "GB"
            break
        }

        # Amazon.CleanRoomsML.TrainedModelInferenceMaxOutputSizeUnitType
        "New-CRMLConfiguredModelAlgorithmAssociation/MaxOutputSize_Unit"
        {
            $v = "GB"
            break
        }

        # Amazon.CleanRoomsML.WorkerComputeType
        {
            ($_ -eq "New-CRMLMLInputChannel/Worker_Type") -Or
            ($_ -eq "Start-CRMLAudienceGenerationJob/Worker_Type")
        }
        {
            $v = "CR.1X","CR.4X"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CRML_map = @{
    "AudienceSize_Type"=@("Start-CRMLAudienceExportJob")
    "AudienceSizeConfig_AudienceSizeType"=@("New-CRMLConfiguredAudienceModel","Update-CRMLConfiguredAudienceModel")
    "ChildResourceTagOnCreatePolicy"=@("New-CRMLConfiguredAudienceModel")
    "ContainerMetrics_NoiseLevel"=@("New-CRMLConfiguredModelAlgorithmAssociation")
    "MaxOutputSize_Unit"=@("New-CRMLConfiguredModelAlgorithmAssociation")
    "MaxSize_Unit"=@("New-CRMLConfiguredModelAlgorithmAssociation")
    "PolicyExistenceCondition"=@("Write-CRMLConfiguredAudienceModelPolicy")
    "ResourceConfig_InstanceType"=@("New-CRMLTrainedModel","Start-CRMLTrainedModelInferenceJob")
    "Worker_Type"=@("New-CRMLMLInputChannel","Start-CRMLAudienceGenerationJob")
}

_awsArgumentCompleterRegistration $CRML_Completers $CRML_map

$CRML_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CRML.$($commandName.Replace('-', ''))Cmdlet]"
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

$CRML_SelectMap = @{
    "Select"=@("Stop-CRMLTrainedModel",
               "Stop-CRMLTrainedModelInferenceJob",
               "New-CRMLAudienceModel",
               "New-CRMLConfiguredAudienceModel",
               "New-CRMLConfiguredModelAlgorithm",
               "New-CRMLConfiguredModelAlgorithmAssociation",
               "New-CRMLMLInputChannel",
               "New-CRMLTrainedModel",
               "New-CRMLTrainingDataset",
               "Remove-CRMLAudienceGenerationJob",
               "Remove-CRMLAudienceModel",
               "Remove-CRMLConfiguredAudienceModel",
               "Remove-CRMLConfiguredAudienceModelPolicy",
               "Remove-CRMLConfiguredModelAlgorithm",
               "Remove-CRMLConfiguredModelAlgorithmAssociation",
               "Remove-CRMLMLConfiguration",
               "Remove-CRMLMLInputChannelData",
               "Remove-CRMLTrainedModelOutput",
               "Remove-CRMLTrainingDataset",
               "Get-CRMLAudienceGenerationJob",
               "Get-CRMLAudienceModel",
               "Get-CRMLCollaborationConfiguredModelAlgorithmAssociation",
               "Get-CRMLCollaborationMLInputChannel",
               "Get-CRMLCollaborationTrainedModel",
               "Get-CRMLConfiguredAudienceModel",
               "Get-CRMLConfiguredAudienceModelPolicy",
               "Get-CRMLConfiguredModelAlgorithm",
               "Get-CRMLConfiguredModelAlgorithmAssociation",
               "Get-CRMLMLConfiguration",
               "Get-CRMLMLInputChannel",
               "Get-CRMLTrainedModel",
               "Get-CRMLTrainedModelInferenceJob",
               "Get-CRMLTrainingDataset",
               "Get-CRMLAudienceExportJobList",
               "Get-CRMLAudienceGenerationJobList",
               "Get-CRMLAudienceModelList",
               "Get-CRMLCollaborationConfiguredModelAlgorithmAssociationList",
               "Get-CRMLCollaborationMLInputChannelList",
               "Get-CRMLCollaborationTrainedModelExportJobList",
               "Get-CRMLCollaborationTrainedModelInferenceJobList",
               "Get-CRMLCollaborationTrainedModelList",
               "Get-CRMLConfiguredAudienceModelList",
               "Get-CRMLConfiguredModelAlgorithmAssociationList",
               "Get-CRMLConfiguredModelAlgorithmList",
               "Get-CRMLMLInputChannelList",
               "Get-CRMLResourceTag",
               "Get-CRMLTrainedModelInferenceJobList",
               "Get-CRMLTrainedModelList",
               "Get-CRMLTrainingDatasetList",
               "Write-CRMLConfiguredAudienceModelPolicy",
               "Write-CRMLMLConfiguration",
               "Start-CRMLAudienceExportJob",
               "Start-CRMLAudienceGenerationJob",
               "Start-CRMLTrainedModelExportJob",
               "Start-CRMLTrainedModelInferenceJob",
               "Add-CRMLResourceTag",
               "Remove-CRMLResourceTag",
               "Update-CRMLConfiguredAudienceModel")
}

_awsArgumentCompleterRegistration $CRML_SelectCompleters $CRML_SelectMap

