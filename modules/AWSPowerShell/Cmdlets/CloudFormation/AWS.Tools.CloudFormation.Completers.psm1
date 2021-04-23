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

# Argument completions for service AWS CloudFormation


$CFN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudFormation.CallAs
        {
            ($_ -eq "Get-CFNStackInstance/CallAs") -Or
            ($_ -eq "Get-CFNStackInstanceList/CallAs") -Or
            ($_ -eq "Get-CFNStackSet/CallAs") -Or
            ($_ -eq "Get-CFNStackSetList/CallAs") -Or
            ($_ -eq "Get-CFNStackSetOperation/CallAs") -Or
            ($_ -eq "Get-CFNStackSetOperationList/CallAs") -Or
            ($_ -eq "Get-CFNStackSetOperationResultList/CallAs") -Or
            ($_ -eq "Get-CFNTemplateSummary/CallAs") -Or
            ($_ -eq "New-CFNStackInstance/CallAs") -Or
            ($_ -eq "New-CFNStackSet/CallAs") -Or
            ($_ -eq "Remove-CFNStackInstance/CallAs") -Or
            ($_ -eq "Remove-CFNStackSet/CallAs") -Or
            ($_ -eq "Start-CFNStackSetDriftDetection/CallAs") -Or
            ($_ -eq "Stop-CFNStackSetOperation/CallAs") -Or
            ($_ -eq "Update-CFNStackInstance/CallAs") -Or
            ($_ -eq "Update-CFNStackSet/CallAs")
        }
        {
            $v = "DELEGATED_ADMIN","SELF"
            break
        }

        # Amazon.CloudFormation.ChangeSetType
        "New-CFNChangeSet/ChangeSetType"
        {
            $v = "CREATE","IMPORT","UPDATE"
            break
        }

        # Amazon.CloudFormation.DeprecatedStatus
        {
            ($_ -eq "Get-CFNTypeList/DeprecatedStatus") -Or
            ($_ -eq "Get-CFNTypeVersion/DeprecatedStatus")
        }
        {
            $v = "DEPRECATED","LIVE"
            break
        }

        # Amazon.CloudFormation.HandlerErrorCode
        "Write-CFNHandlerProgress/ErrorCode"
        {
            $v = "AccessDenied","AlreadyExists","GeneralServiceException","InternalFailure","InvalidCredentials","InvalidRequest","NetworkFailure","NotFound","NotStabilized","NotUpdatable","ResourceConflict","ServiceInternalError","ServiceLimitExceeded","Throttling"
            break
        }

        # Amazon.CloudFormation.OnFailure
        "New-CFNStack/OnFailure"
        {
            $v = "DELETE","DO_NOTHING","ROLLBACK"
            break
        }

        # Amazon.CloudFormation.OperationStatus
        {
            ($_ -eq "Write-CFNHandlerProgress/CurrentOperationStatus") -Or
            ($_ -eq "Write-CFNHandlerProgress/OperationStatus")
        }
        {
            $v = "FAILED","IN_PROGRESS","PENDING","SUCCESS"
            break
        }

        # Amazon.CloudFormation.PermissionModels
        {
            ($_ -eq "New-CFNStackSet/PermissionModel") -Or
            ($_ -eq "Update-CFNStackSet/PermissionModel")
        }
        {
            $v = "SELF_MANAGED","SERVICE_MANAGED"
            break
        }

        # Amazon.CloudFormation.ProvisioningType
        "Get-CFNTypeList/ProvisioningType"
        {
            $v = "FULLY_MUTABLE","IMMUTABLE","NON_PROVISIONABLE"
            break
        }

        # Amazon.CloudFormation.RegistrationStatus
        "Get-CFNTypeRegistrationList/RegistrationStatusFilter"
        {
            $v = "COMPLETE","FAILED","IN_PROGRESS"
            break
        }

        # Amazon.CloudFormation.RegistryType
        {
            ($_ -eq "Get-CFNType/Type") -Or
            ($_ -eq "Get-CFNTypeList/Type") -Or
            ($_ -eq "Get-CFNTypeRegistrationList/Type") -Or
            ($_ -eq "Get-CFNTypeVersion/Type") -Or
            ($_ -eq "Register-CFNType/Type") -Or
            ($_ -eq "Set-CFNTypeDefaultVersion/Type") -Or
            ($_ -eq "Unregister-CFNType/Type")
        }
        {
            $v = "MODULE","RESOURCE"
            break
        }

        # Amazon.CloudFormation.ResourceSignalStatus
        "Send-CFNResourceSignal/Status"
        {
            $v = "FAILURE","SUCCESS"
            break
        }

        # Amazon.CloudFormation.StackSetStatus
        "Get-CFNStackSetList/Status"
        {
            $v = "ACTIVE","DELETED"
            break
        }

        # Amazon.CloudFormation.StackStatus
        {
            ($_ -eq "Test-CFNStack/Status") -Or
            ($_ -eq "Wait-CFNStack/Status")
        }
        {
            $v = "CREATE_COMPLETE","CREATE_FAILED","CREATE_IN_PROGRESS","DELETE_COMPLETE","DELETE_FAILED","DELETE_IN_PROGRESS","IMPORT_COMPLETE","IMPORT_IN_PROGRESS","IMPORT_ROLLBACK_COMPLETE","IMPORT_ROLLBACK_FAILED","IMPORT_ROLLBACK_IN_PROGRESS","REVIEW_IN_PROGRESS","ROLLBACK_COMPLETE","ROLLBACK_FAILED","ROLLBACK_IN_PROGRESS","UPDATE_COMPLETE","UPDATE_COMPLETE_CLEANUP_IN_PROGRESS","UPDATE_IN_PROGRESS","UPDATE_ROLLBACK_COMPLETE","UPDATE_ROLLBACK_COMPLETE_CLEANUP_IN_PROGRESS","UPDATE_ROLLBACK_FAILED","UPDATE_ROLLBACK_IN_PROGRESS"
            break
        }

        # Amazon.CloudFormation.TemplateStage
        "Get-CFNTemplate/TemplateStage"
        {
            $v = "Original","Processed"
            break
        }

        # Amazon.CloudFormation.Visibility
        "Get-CFNTypeList/Visibility"
        {
            $v = "PRIVATE","PUBLIC"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CFN_map = @{
    "CallAs"=@("Get-CFNStackInstance","Get-CFNStackInstanceList","Get-CFNStackSet","Get-CFNStackSetList","Get-CFNStackSetOperation","Get-CFNStackSetOperationList","Get-CFNStackSetOperationResultList","Get-CFNTemplateSummary","New-CFNStackInstance","New-CFNStackSet","Remove-CFNStackInstance","Remove-CFNStackSet","Start-CFNStackSetDriftDetection","Stop-CFNStackSetOperation","Update-CFNStackInstance","Update-CFNStackSet")
    "ChangeSetType"=@("New-CFNChangeSet")
    "CurrentOperationStatus"=@("Write-CFNHandlerProgress")
    "DeprecatedStatus"=@("Get-CFNTypeList","Get-CFNTypeVersion")
    "ErrorCode"=@("Write-CFNHandlerProgress")
    "OnFailure"=@("New-CFNStack")
    "OperationStatus"=@("Write-CFNHandlerProgress")
    "PermissionModel"=@("New-CFNStackSet","Update-CFNStackSet")
    "ProvisioningType"=@("Get-CFNTypeList")
    "RegistrationStatusFilter"=@("Get-CFNTypeRegistrationList")
    "Status"=@("Get-CFNStackSetList","Send-CFNResourceSignal","Test-CFNStack","Wait-CFNStack")
    "TemplateStage"=@("Get-CFNTemplate")
    "Type"=@("Get-CFNType","Get-CFNTypeList","Get-CFNTypeRegistrationList","Get-CFNTypeVersion","Register-CFNType","Set-CFNTypeDefaultVersion","Unregister-CFNType")
    "Visibility"=@("Get-CFNTypeList")
}

_awsArgumentCompleterRegistration $CFN_Completers $CFN_map

$CFN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CFN.$($commandName.Replace('-', ''))Cmdlet]"
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

$CFN_SelectMap = @{
    "Select"=@("Stop-CFNUpdateStack",
               "Resume-CFNUpdateRollback",
               "New-CFNChangeSet",
               "New-CFNStack",
               "New-CFNStackInstance",
               "New-CFNStackSet",
               "Remove-CFNChangeSet",
               "Remove-CFNStack",
               "Remove-CFNStackInstance",
               "Remove-CFNStackSet",
               "Unregister-CFNType",
               "Get-CFNAccountLimit",
               "Get-CFNChangeSet",
               "Get-CFNStackDriftDetectionStatus",
               "Get-CFNStackEvent",
               "Get-CFNStackInstance",
               "Get-CFNStackResource",
               "Get-CFNDetectedStackResourceDrift",
               "Get-CFNStackResourceList",
               "Get-CFNStack",
               "Get-CFNStackSet",
               "Get-CFNStackSetOperation",
               "Get-CFNType",
               "Get-CFNTypeRegistration",
               "Start-CFNStackDriftDetection",
               "Get-CFNStackResourceDrift",
               "Start-CFNStackSetDriftDetection",
               "Measure-CFNTemplateCost",
               "Start-CFNChangeSet",
               "Get-CFNStackPolicy",
               "Get-CFNTemplate",
               "Get-CFNTemplateSummary",
               "Get-CFNChangeSetList",
               "Get-CFNExport",
               "Get-CFNImportList",
               "Get-CFNStackInstanceList",
               "Get-CFNStackResourceSummary",
               "Get-CFNStackSummary",
               "Get-CFNStackSetOperationResultList",
               "Get-CFNStackSetOperationList",
               "Get-CFNStackSetList",
               "Get-CFNTypeRegistrationList",
               "Get-CFNTypeList",
               "Get-CFNTypeVersion",
               "Write-CFNHandlerProgress",
               "Register-CFNType",
               "Set-CFNStackPolicy",
               "Set-CFNTypeDefaultVersion",
               "Send-CFNResourceSignal",
               "Stop-CFNStackSetOperation",
               "Update-CFNStack",
               "Update-CFNStackInstance",
               "Update-CFNStackSet",
               "Update-CFNTerminationProtection",
               "Test-CFNTemplate",
               "Test-CFNStack",
               "Wait-CFNStack")
}

_awsArgumentCompleterRegistration $CFN_SelectCompleters $CFN_SelectMap

