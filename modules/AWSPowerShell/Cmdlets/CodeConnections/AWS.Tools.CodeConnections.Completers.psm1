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

# Argument completions for service AWS CodeConnections


$CCON_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeConnections.ProviderType
        {
            ($_ -eq "New-CCONConnection/ProviderType") -Or
            ($_ -eq "New-CCONHost/ProviderType") -Or
            ($_ -eq "Get-CCONConnectionList/ProviderTypeFilter")
        }
        {
            $v = "Bitbucket","GitHub","GitHubEnterpriseServer","GitLab","GitLabSelfManaged"
            break
        }

        # Amazon.CodeConnections.PublishDeploymentStatus
        {
            ($_ -eq "New-CCONSyncConfiguration/PublishDeploymentStatus") -Or
            ($_ -eq "Update-CCONSyncConfiguration/PublishDeploymentStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CodeConnections.SyncConfigurationType
        {
            ($_ -eq "Get-CCONRepositorySyncDefinitionList/SyncType") -Or
            ($_ -eq "Get-CCONRepositorySyncStatus/SyncType") -Or
            ($_ -eq "Get-CCONResourceSyncStatus/SyncType") -Or
            ($_ -eq "Get-CCONSyncBlockerSummary/SyncType") -Or
            ($_ -eq "Get-CCONSyncConfiguration/SyncType") -Or
            ($_ -eq "Get-CCONSyncConfigurationList/SyncType") -Or
            ($_ -eq "New-CCONSyncConfiguration/SyncType") -Or
            ($_ -eq "Remove-CCONSyncConfiguration/SyncType") -Or
            ($_ -eq "Update-CCONSyncBlocker/SyncType") -Or
            ($_ -eq "Update-CCONSyncConfiguration/SyncType")
        }
        {
            $v = "CFN_STACK_SYNC"
            break
        }

        # Amazon.CodeConnections.TriggerResourceUpdateOn
        {
            ($_ -eq "New-CCONSyncConfiguration/TriggerResourceUpdateOn") -Or
            ($_ -eq "Update-CCONSyncConfiguration/TriggerResourceUpdateOn")
        }
        {
            $v = "ANY_CHANGE","FILE_CHANGE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CCON_map = @{
    "ProviderType"=@("New-CCONConnection","New-CCONHost")
    "ProviderTypeFilter"=@("Get-CCONConnectionList")
    "PublishDeploymentStatus"=@("New-CCONSyncConfiguration","Update-CCONSyncConfiguration")
    "SyncType"=@("Get-CCONRepositorySyncDefinitionList","Get-CCONRepositorySyncStatus","Get-CCONResourceSyncStatus","Get-CCONSyncBlockerSummary","Get-CCONSyncConfiguration","Get-CCONSyncConfigurationList","New-CCONSyncConfiguration","Remove-CCONSyncConfiguration","Update-CCONSyncBlocker","Update-CCONSyncConfiguration")
    "TriggerResourceUpdateOn"=@("New-CCONSyncConfiguration","Update-CCONSyncConfiguration")
}

_awsArgumentCompleterRegistration $CCON_Completers $CCON_map

$CCON_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CCON.$($commandName.Replace('-', ''))Cmdlet]"
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

$CCON_SelectMap = @{
    "Select"=@("New-CCONConnection",
               "New-CCONHost",
               "New-CCONRepositoryLink",
               "New-CCONSyncConfiguration",
               "Remove-CCONConnection",
               "Remove-CCONHost",
               "Remove-CCONRepositoryLink",
               "Remove-CCONSyncConfiguration",
               "Get-CCONConnection",
               "Get-CCONHost",
               "Get-CCONRepositoryLink",
               "Get-CCONRepositorySyncStatus",
               "Get-CCONResourceSyncStatus",
               "Get-CCONSyncBlockerSummary",
               "Get-CCONSyncConfiguration",
               "Get-CCONConnectionList",
               "Get-CCONHostList",
               "Get-CCONRepositoryLinkList",
               "Get-CCONRepositorySyncDefinitionList",
               "Get-CCONSyncConfigurationList",
               "Get-CCONResourceTag",
               "Add-CCONResourceTag",
               "Remove-CCONResourceTag",
               "Update-CCONHost",
               "Update-CCONRepositoryLink",
               "Update-CCONSyncBlocker",
               "Update-CCONSyncConfiguration")
}

_awsArgumentCompleterRegistration $CCON_SelectCompleters $CCON_SelectMap

