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

# Argument completions for service AWS Audit Manager


$AUDM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AuditManager.AssessmentReportDestinationType
        {
            ($_ -eq "Edit-AUDMAssessment/AssessmentReportsDestination_DestinationType") -Or
            ($_ -eq "New-AUDMAssessment/AssessmentReportsDestination_DestinationType") -Or
            ($_ -eq "Edit-AUDMSetting/DefaultAssessmentReportsDestination_DestinationType")
        }
        {
            $v = "S3"
            break
        }

        # Amazon.AuditManager.AssessmentStatus
        {
            ($_ -eq "Edit-AUDMAssessmentStatus/Status") -Or
            ($_ -eq "Get-AUDMAssessmentList/Status")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.AuditManager.ControlSetStatus
        "Edit-AUDMAssessmentControlSetStatus/Status"
        {
            $v = "ACTIVE","REVIEWED","UNDER_REVIEW"
            break
        }

        # Amazon.AuditManager.ControlStatus
        "Edit-AUDMAssessmentControl/ControlStatus"
        {
            $v = "INACTIVE","REVIEWED","UNDER_REVIEW"
            break
        }

        # Amazon.AuditManager.ControlType
        "Get-AUDMControlList/ControlType"
        {
            $v = "Custom","Standard"
            break
        }

        # Amazon.AuditManager.DeleteResources
        "Edit-AUDMSetting/DeregistrationPolicy_DeleteResources"
        {
            $v = "ALL","DEFAULT"
            break
        }

        # Amazon.AuditManager.ExportDestinationType
        "Edit-AUDMSetting/DefaultExportDestination_DestinationType"
        {
            $v = "S3"
            break
        }

        # Amazon.AuditManager.FrameworkType
        "Get-AUDMAssessmentFrameworkList/FrameworkType"
        {
            $v = "Custom","Standard"
            break
        }

        # Amazon.AuditManager.SettingAttribute
        "Get-AUDMSetting/Attribute"
        {
            $v = "ALL","DEFAULT_ASSESSMENT_REPORTS_DESTINATION","DEFAULT_EXPORT_DESTINATION","DEFAULT_PROCESS_OWNERS","DEREGISTRATION_POLICY","EVIDENCE_FINDER_ENABLEMENT","IS_AWS_ORG_ENABLED","SNS_TOPIC"
            break
        }

        # Amazon.AuditManager.ShareRequestAction
        "Update-AUDMAssessmentFrameworkShare/Action"
        {
            $v = "ACCEPT","DECLINE","REVOKE"
            break
        }

        # Amazon.AuditManager.ShareRequestType
        {
            ($_ -eq "Get-AUDMAssessmentFrameworkShareRequestList/RequestType") -Or
            ($_ -eq "Remove-AUDMAssessmentFrameworkShare/RequestType") -Or
            ($_ -eq "Update-AUDMAssessmentFrameworkShare/RequestType")
        }
        {
            $v = "RECEIVED","SENT"
            break
        }

        # Amazon.AuditManager.SourceType
        "Get-AUDMKeywordForDataSourceList/Source"
        {
            $v = "AWS_API_Call","AWS_Cloudtrail","AWS_Config","AWS_Security_Hub","MANUAL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AUDM_map = @{
    "Action"=@("Update-AUDMAssessmentFrameworkShare")
    "AssessmentReportsDestination_DestinationType"=@("Edit-AUDMAssessment","New-AUDMAssessment")
    "Attribute"=@("Get-AUDMSetting")
    "ControlStatus"=@("Edit-AUDMAssessmentControl")
    "ControlType"=@("Get-AUDMControlList")
    "DefaultAssessmentReportsDestination_DestinationType"=@("Edit-AUDMSetting")
    "DefaultExportDestination_DestinationType"=@("Edit-AUDMSetting")
    "DeregistrationPolicy_DeleteResources"=@("Edit-AUDMSetting")
    "FrameworkType"=@("Get-AUDMAssessmentFrameworkList")
    "RequestType"=@("Get-AUDMAssessmentFrameworkShareRequestList","Remove-AUDMAssessmentFrameworkShare","Update-AUDMAssessmentFrameworkShare")
    "Source"=@("Get-AUDMKeywordForDataSourceList")
    "Status"=@("Edit-AUDMAssessmentControlSetStatus","Edit-AUDMAssessmentStatus","Get-AUDMAssessmentList")
}

_awsArgumentCompleterRegistration $AUDM_Completers $AUDM_map

$AUDM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AUDM.$($commandName.Replace('-', ''))Cmdlet]"
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

$AUDM_SelectMap = @{
    "Select"=@("Add-AUDMAssessmentReportEvidenceFolder",
               "Add-AUDMAssessmentReportEvidence",
               "New-AUDMCreateDelegationByAssessment",
               "Remove-AUDMDelegationByAssessment",
               "Remove-AUDMAssessmentReportEvidence",
               "Add-AUDMEvidenceToAssessmentControl",
               "New-AUDMAssessment",
               "New-AUDMAssessmentFramework",
               "New-AUDMAssessmentReport",
               "New-AUDMControl",
               "Remove-AUDMAssessment",
               "Remove-AUDMAssessmentFramework",
               "Remove-AUDMAssessmentFrameworkShare",
               "Remove-AUDMAssessmentReport",
               "Remove-AUDMControl",
               "Unregister-AUDMAccount",
               "Unregister-AUDMOrganizationAdminAccount",
               "Remove-AUDMAssessmentReportEvidenceFolder",
               "Get-AUDMAccountStatus",
               "Get-AUDMAssessment",
               "Get-AUDMAssessmentFramework",
               "Get-AUDMAssessmentReportUrl",
               "Get-AUDMChangeLog",
               "Get-AUDMControl",
               "Get-AUDMDelegation",
               "Get-AUDMEvidence",
               "Get-AUDMEvidenceByEvidenceFolder",
               "Get-AUDMEvidenceFileUploadUrl",
               "Get-AUDMEvidenceFolder",
               "Get-AUDMEvidenceFolderByAssessment",
               "Get-AUDMEvidenceFolderByAssessmentControl",
               "Get-AUDMInsight",
               "Get-AUDMInsightsByAssessment",
               "Get-AUDMOrganizationAdminAccount",
               "Get-AUDMServiceInScope",
               "Get-AUDMSetting",
               "Get-AUDMAssessmentControlInsightsByControlDomainList",
               "Get-AUDMAssessmentFrameworkList",
               "Get-AUDMAssessmentFrameworkShareRequestList",
               "Get-AUDMAssessmentReportList",
               "Get-AUDMAssessmentList",
               "Get-AUDMControlDomainInsightList",
               "Get-AUDMControlDomainInsightsByAssessmentList",
               "Get-AUDMControlInsightsByControlDomainList",
               "Get-AUDMControlList",
               "Get-AUDMKeywordForDataSourceList",
               "Get-AUDMNotificationList",
               "Get-AUDMResourceTagList",
               "Register-AUDMAccount",
               "Register-AUDMOrganizationAdminAccount",
               "Start-AUDMAssessmentFrameworkShare",
               "Add-AUDMResourceTag",
               "Remove-AUDMResourceTag",
               "Edit-AUDMAssessment",
               "Edit-AUDMAssessmentControl",
               "Edit-AUDMAssessmentControlSetStatus",
               "Edit-AUDMAssessmentFramework",
               "Update-AUDMAssessmentFrameworkShare",
               "Edit-AUDMAssessmentStatus",
               "Edit-AUDMControl",
               "Edit-AUDMSetting",
               "Confirm-AUDMAssessmentReportIntegrity")
}

_awsArgumentCompleterRegistration $AUDM_SelectCompleters $AUDM_SelectMap

