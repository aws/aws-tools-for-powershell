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

# Argument completions for service CloudWatch Omni


$CWOM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudWatchOmni.AccessGrantPermission
        {
            ($_ -eq "Get-CWOMAccessGrantList/Permission") -Or
            ($_ -eq "New-CWOMAccessGrant/Permission")
        }
        {
            $v = "CUSTOM","READ","READ_WRITE_DELETE","SPACE_ADMIN"
            break
        }

        # Amazon.CloudWatchOmni.AccessGrantPrincipalType
        {
            ($_ -eq "New-CWOMAccessGrant/Principal_PrincipalType") -Or
            ($_ -eq "Get-CWOMAccessGrantList/PrincipalType")
        }
        {
            $v = "ACCESS_PROFILE","AGENT","ALERT","IAM_ROLE","IAM_ROOT","IAM_USER","IDC_GROUP","IDC_USER"
            break
        }

        # Amazon.CloudWatchOmni.AlertSortField
        "Get-CWOMAlertList/SortBy"
        {
            $v = "NAME","STATE"
            break
        }

        # Amazon.CloudWatchOmni.AlertSortOrder
        "Get-CWOMAlertList/SortOrder"
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.CloudWatchOmni.AlertState
        {
            ($_ -eq "New-CWOMAlert/Rule_TelemetryRule_NoData_TreatAs") -Or
            ($_ -eq "Update-CWOMAlert/Rule_TelemetryRule_NoData_TreatAs")
        }
        {
            $v = "CRITICAL","NODATA","OK","WARNING"
            break
        }

        # Amazon.CloudWatchOmni.Comparator
        {
            ($_ -eq "New-CWOMAlert/Rule_TelemetryRule_Condition_Comparator") -Or
            ($_ -eq "Update-CWOMAlert/Rule_TelemetryRule_Condition_Comparator")
        }
        {
            $v = "GT","GTE","LT","LTE"
            break
        }

        # Amazon.CloudWatchOmni.EdgeType
        "Get-CWOMContextGraph/EdgeFilters_EdgeType"
        {
            $v = "ACCESSES","CALLS","RUNS_ON"
            break
        }

        # Amazon.CloudWatchOmni.EncryptionStrategy
        {
            ($_ -eq "New-CWOMSpace/EncryptionConfiguration_EncryptionStrategy") -Or
            ($_ -eq "Update-CWOMSpace/EncryptionConfiguration_EncryptionStrategy")
        }
        {
            $v = "AWS_OWNED","CUSTOMER_MANAGED"
            break
        }

        # Amazon.CloudWatchOmni.IntegrationStatus
        "Get-CWOMIntegrationList/Status"
        {
            $v = "ACTIVE","DELETED","ERROR","FAILED","PENDING","PENDING_OAUTH"
            break
        }

        # Amazon.CloudWatchOmni.IntegrationType
        {
            ($_ -eq "Get-CWOMIntegrationList/IntegrationType") -Or
            ($_ -eq "New-CWOMIntegration/IntegrationType")
        }
        {
            $v = "AWS_CONFIG_SLREC","AWS_INTEGRATION","EXTERNAL_AGENT","SLACK"
            break
        }

        # Amazon.CloudWatchOmni.NodeType
        "Get-CWOMContextGraph/NodeFilters_NodeType"
        {
            $v = "REMOTE_SERVICE","RESOURCE","SERVICE"
            break
        }

        # Amazon.CloudWatchOmni.OrganizationCredentialType
        "Get-CWOMSpaceCredentialsForOrganization/CredentialType"
        {
            $v = "SPACE_OPERATION"
            break
        }

        # Amazon.CloudWatchOmni.OrganizationGrantPermission
        {
            ($_ -eq "Get-CWOMDomainAccessGrantsForOrganizationList/Permission") -Or
            ($_ -eq "New-CWOMDomainAccessGrantForOrganization/Permission")
        }
        {
            $v = "ADMIN"
            break
        }

        # Amazon.CloudWatchOmni.OrganizationGrantPrincipalType
        {
            ($_ -eq "New-CWOMDomainAccessGrantForOrganization/Principal_PrincipalType") -Or
            ($_ -eq "Get-CWOMDomainAccessGrantsForOrganizationList/PrincipalType")
        }
        {
            $v = "IAM_ROLE","IAM_ROOT","IAM_USER","IDC_GROUP","IDC_USER"
            break
        }

        # Amazon.CloudWatchOmni.QueryLanguage
        {
            ($_ -eq "New-CWOMAlert/Rule_TelemetryRule_Query_Language") -Or
            ($_ -eq "Update-CWOMAlert/Rule_TelemetryRule_Query_Language")
        }
        {
            $v = "PROMQL","SQL"
            break
        }

        # Amazon.CloudWatchOmni.TelemetryType
        "Get-CWOMTelemetryFieldList/TelemetryType"
        {
            $v = "LOGS","TRACES"
            break
        }

        # Amazon.CloudWatchOmni.ThresholdMode
        {
            ($_ -eq "New-CWOMAlert/Rule_TelemetryRule_Condition_ThresholdMode") -Or
            ($_ -eq "Update-CWOMAlert/Rule_TelemetryRule_Condition_ThresholdMode")
        }
        {
            $v = "COUNT_OF_RESULTS","FIELD_VALUE"
            break
        }

        # Amazon.CloudWatchOmni.ViewType
        "Get-CWOMViewList/Type"
        {
            $v = "MANAGED","USER"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWOM_map = @{
    "CredentialType"=@("Get-CWOMSpaceCredentialsForOrganization")
    "EdgeFilters_EdgeType"=@("Get-CWOMContextGraph")
    "EncryptionConfiguration_EncryptionStrategy"=@("New-CWOMSpace","Update-CWOMSpace")
    "IntegrationType"=@("Get-CWOMIntegrationList","New-CWOMIntegration")
    "NodeFilters_NodeType"=@("Get-CWOMContextGraph")
    "Permission"=@("Get-CWOMAccessGrantList","Get-CWOMDomainAccessGrantsForOrganizationList","New-CWOMAccessGrant","New-CWOMDomainAccessGrantForOrganization")
    "Principal_PrincipalType"=@("New-CWOMAccessGrant","New-CWOMDomainAccessGrantForOrganization")
    "PrincipalType"=@("Get-CWOMAccessGrantList","Get-CWOMDomainAccessGrantsForOrganizationList")
    "Rule_TelemetryRule_Condition_Comparator"=@("New-CWOMAlert","Update-CWOMAlert")
    "Rule_TelemetryRule_Condition_ThresholdMode"=@("New-CWOMAlert","Update-CWOMAlert")
    "Rule_TelemetryRule_NoData_TreatAs"=@("New-CWOMAlert","Update-CWOMAlert")
    "Rule_TelemetryRule_Query_Language"=@("New-CWOMAlert","Update-CWOMAlert")
    "SortBy"=@("Get-CWOMAlertList")
    "SortOrder"=@("Get-CWOMAlertList")
    "Status"=@("Get-CWOMIntegrationList")
    "TelemetryType"=@("Get-CWOMTelemetryFieldList")
    "Type"=@("Get-CWOMViewList")
}

_awsArgumentCompleterRegistration $CWOM_Completers $CWOM_map

$CWOM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CWOM.$($commandName.Replace('-', ''))Cmdlet]"
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

$CWOM_SelectMap = @{
    "Select"=@("New-CWOMAccessGrant",
               "New-CWOMAccessProfile",
               "New-CWOMAlert",
               "New-CWOMDomain",
               "New-CWOMDomainAccessGrantForOrganization",
               "New-CWOMDomainForOrganization",
               "New-CWOMIntegration",
               "New-CWOMOmniDashboard",
               "New-CWOMOneTimeDeepLinkCode",
               "New-CWOMSpace",
               "New-CWOMView",
               "Remove-CWOMAccessGrant",
               "Remove-CWOMAccessProfile",
               "Remove-CWOMAlert",
               "Remove-CWOMDomain",
               "Remove-CWOMDomainAccessGrantForOrganization",
               "Remove-CWOMDomainForOrganization",
               "Remove-CWOMIntegration",
               "Remove-CWOMOmniDashboard",
               "Remove-CWOMSpace",
               "Remove-CWOMView",
               "Get-CWOMAccessGrant",
               "Get-CWOMAccessProfile",
               "Get-CWOMAlert",
               "Get-CWOMContextGraph",
               "Get-CWOMDomain",
               "Get-CWOMDomainAccessGrantForOrganization",
               "Get-CWOMDomainForOrganization",
               "Get-CWOMIntegration",
               "Get-CWOMIntelligenceConfiguration",
               "Get-CWOMOmniDashboard",
               "Get-CWOMSpace",
               "Get-CWOMSpaceCredentialsForOrganization",
               "Get-CWOMTelemetryQueryResult",
               "Get-CWOMView",
               "Get-CWOMAccessGrantList",
               "Get-CWOMAccessProfileList",
               "Get-CWOMAlertList",
               "Get-CWOMDomainAccessGrantsForOrganizationList",
               "Get-CWOMDomainList",
               "Get-CWOMIntegrationList",
               "Get-CWOMOmniDashboardList",
               "Get-CWOMSpaceList",
               "Get-CWOMSpacesForOrganizationList",
               "Get-CWOMTelemetryFieldList",
               "Get-CWOMTelemetryQuerySessionList",
               "Get-CWOMViewList",
               "Write-CWOMIntelligenceConfiguration",
               "Search-CWOMPrincipal",
               "Start-CWOMTelemetryQuery",
               "Start-CWOMTelemetryQuerySession",
               "Stop-CWOMTelemetryQuery",
               "Stop-CWOMTelemetryQuerySession",
               "Update-CWOMAccessProfile",
               "Update-CWOMAlert",
               "Update-CWOMDomain",
               "Update-CWOMDomainForOrganization",
               "Update-CWOMIntegration",
               "Update-CWOMOmniDashboard",
               "Update-CWOMSpace",
               "Update-CWOMView")
}

_awsArgumentCompleterRegistration $CWOM_SelectCompleters $CWOM_SelectMap

