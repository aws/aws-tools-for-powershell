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

# Argument completions for service AWS Clean Rooms Service


$CRS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CleanRooms.AnalysisFormat
        "New-CRSAnalysisTemplate/Format"
        {
            $v = "SQL"
            break
        }

        # Amazon.CleanRooms.AnalysisMethod
        "New-CRSConfiguredTable/AnalysisMethod"
        {
            $v = "DIRECT_QUERY"
            break
        }

        # Amazon.CleanRooms.AnalysisRuleType
        "Get-CRSSchemaAnalysisRule/Type"
        {
            $v = "AGGREGATION","CUSTOM","LIST"
            break
        }

        # Amazon.CleanRooms.CollaborationQueryLogStatus
        "New-CRSCollaboration/QueryLogStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CleanRooms.ConfiguredTableAnalysisRuleType
        {
            ($_ -eq "Get-CRSConfiguredTableAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "New-CRSConfiguredTableAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "Remove-CRSConfiguredTableAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "Update-CRSConfiguredTableAnalysisRule/AnalysisRuleType")
        }
        {
            $v = "AGGREGATION","CUSTOM","LIST"
            break
        }

        # Amazon.CleanRooms.FilterableMemberStatus
        "Get-CRSCollaborationList/MemberStatus"
        {
            $v = "ACTIVE","INVITED"
            break
        }

        # Amazon.CleanRooms.JoinRequiredOption
        {
            ($_ -eq "New-CRSConfiguredTableAnalysisRule/AnalysisRulePolicy_V1_Aggregation_JoinRequired") -Or
            ($_ -eq "Update-CRSConfiguredTableAnalysisRule/AnalysisRulePolicy_V1_Aggregation_JoinRequired")
        }
        {
            $v = "QUERY_RUNNER"
            break
        }

        # Amazon.CleanRooms.MembershipQueryLogStatus
        {
            ($_ -eq "New-CRSMembership/QueryLogStatus") -Or
            ($_ -eq "Update-CRSMembership/QueryLogStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CleanRooms.MembershipStatus
        "Get-CRSMembershipList/Status"
        {
            $v = "ACTIVE","COLLABORATION_DELETED","REMOVED"
            break
        }

        # Amazon.CleanRooms.ProtectedQueryStatus
        "Get-CRSProtectedQueryList/Status"
        {
            $v = "CANCELLED","CANCELLING","FAILED","STARTED","SUBMITTED","SUCCESS","TIMED_OUT"
            break
        }

        # Amazon.CleanRooms.ProtectedQueryType
        "Start-CRSProtectedQuery/Type"
        {
            $v = "SQL"
            break
        }

        # Amazon.CleanRooms.ResultFormat
        "Start-CRSProtectedQuery/ResultConfiguration_OutputConfiguration_S3_ResultFormat"
        {
            $v = "CSV","PARQUET"
            break
        }

        # Amazon.CleanRooms.SchemaType
        "Get-CRSSchemaList/SchemaType"
        {
            $v = "TABLE"
            break
        }

        # Amazon.CleanRooms.TargetProtectedQueryStatus
        "Update-CRSProtectedQuery/TargetStatus"
        {
            $v = "CANCELLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CRS_map = @{
    "AnalysisMethod"=@("New-CRSConfiguredTable")
    "AnalysisRulePolicy_V1_Aggregation_JoinRequired"=@("New-CRSConfiguredTableAnalysisRule","Update-CRSConfiguredTableAnalysisRule")
    "AnalysisRuleType"=@("Get-CRSConfiguredTableAnalysisRule","New-CRSConfiguredTableAnalysisRule","Remove-CRSConfiguredTableAnalysisRule","Update-CRSConfiguredTableAnalysisRule")
    "Format"=@("New-CRSAnalysisTemplate")
    "MemberStatus"=@("Get-CRSCollaborationList")
    "QueryLogStatus"=@("New-CRSCollaboration","New-CRSMembership","Update-CRSMembership")
    "ResultConfiguration_OutputConfiguration_S3_ResultFormat"=@("Start-CRSProtectedQuery")
    "SchemaType"=@("Get-CRSSchemaList")
    "Status"=@("Get-CRSMembershipList","Get-CRSProtectedQueryList")
    "TargetStatus"=@("Update-CRSProtectedQuery")
    "Type"=@("Get-CRSSchemaAnalysisRule","Start-CRSProtectedQuery")
}

_awsArgumentCompleterRegistration $CRS_Completers $CRS_map

$CRS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CRS.$($commandName.Replace('-', ''))Cmdlet]"
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

$CRS_SelectMap = @{
    "Select"=@("Get-CRSBatchCollaborationAnalysisTemplate",
               "Get-CRSBatchSchema",
               "New-CRSAnalysisTemplate",
               "New-CRSCollaboration",
               "New-CRSConfiguredTable",
               "New-CRSConfiguredTableAnalysisRule",
               "New-CRSConfiguredTableAssociation",
               "New-CRSMembership",
               "Remove-CRSAnalysisTemplate",
               "Remove-CRSCollaboration",
               "Remove-CRSConfiguredTable",
               "Remove-CRSConfiguredTableAnalysisRule",
               "Remove-CRSConfiguredTableAssociation",
               "Remove-CRSMember",
               "Remove-CRSMembership",
               "Get-CRSAnalysisTemplate",
               "Get-CRSCollaboration",
               "Get-CRSCollaborationAnalysisTemplate",
               "Get-CRSConfiguredTable",
               "Get-CRSConfiguredTableAnalysisRule",
               "Get-CRSConfiguredTableAssociation",
               "Get-CRSMembership",
               "Get-CRSProtectedQuery",
               "Get-CRSSchema",
               "Get-CRSSchemaAnalysisRule",
               "Get-CRSAnalysisTemplateList",
               "Get-CRSCollaborationAnalysisTemplateList",
               "Get-CRSCollaborationList",
               "Get-CRSConfiguredTableAssociationList",
               "Get-CRSConfiguredTableList",
               "Get-CRSMemberList",
               "Get-CRSMembershipList",
               "Get-CRSProtectedQueryList",
               "Get-CRSSchemaList",
               "Get-CRSResourceTag",
               "Start-CRSProtectedQuery",
               "Add-CRSResourceTag",
               "Remove-CRSResourceTag",
               "Update-CRSAnalysisTemplate",
               "Update-CRSCollaboration",
               "Update-CRSConfiguredTable",
               "Update-CRSConfiguredTableAnalysisRule",
               "Update-CRSConfiguredTableAssociation",
               "Update-CRSMembership",
               "Update-CRSProtectedQuery")
}

_awsArgumentCompleterRegistration $CRS_SelectCompleters $CRS_SelectMap

