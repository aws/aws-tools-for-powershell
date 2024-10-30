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

# Argument completions for service OpenSearch Serverless


$OSS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.OpenSearchServerless.AccessPolicyType
        {
            ($_ -eq "Get-OSSAccessPolicy/Type") -Or
            ($_ -eq "Get-OSSAccessPolicyList/Type") -Or
            ($_ -eq "New-OSSAccessPolicy/Type") -Or
            ($_ -eq "Remove-OSSAccessPolicy/Type") -Or
            ($_ -eq "Update-OSSAccessPolicy/Type")
        }
        {
            $v = "data"
            break
        }

        # Amazon.OpenSearchServerless.CollectionStatus
        "Get-OSSCollectionList/CollectionFilters_Status"
        {
            $v = "ACTIVE","CREATING","DELETING","FAILED"
            break
        }

        # Amazon.OpenSearchServerless.CollectionType
        "New-OSSCollection/Type"
        {
            $v = "SEARCH","TIMESERIES","VECTORSEARCH"
            break
        }

        # Amazon.OpenSearchServerless.IamIdentityCenterGroupAttribute
        {
            ($_ -eq "New-OSSSecurityConfig/IamIdentityCenterOptions_GroupAttribute") -Or
            ($_ -eq "Update-OSSSecurityConfig/IamIdentityCenterOptionsUpdates_GroupAttribute")
        }
        {
            $v = "GroupId","GroupName"
            break
        }

        # Amazon.OpenSearchServerless.IamIdentityCenterUserAttribute
        {
            ($_ -eq "New-OSSSecurityConfig/IamIdentityCenterOptions_UserAttribute") -Or
            ($_ -eq "Update-OSSSecurityConfig/IamIdentityCenterOptionsUpdates_UserAttribute")
        }
        {
            $v = "Email","UserId","UserName"
            break
        }

        # Amazon.OpenSearchServerless.LifecyclePolicyType
        {
            ($_ -eq "Get-OSSLifecyclePolicyList/Type") -Or
            ($_ -eq "New-OSSLifecyclePolicy/Type") -Or
            ($_ -eq "Remove-OSSLifecyclePolicy/Type") -Or
            ($_ -eq "Update-OSSLifecyclePolicy/Type")
        }
        {
            $v = "retention"
            break
        }

        # Amazon.OpenSearchServerless.SecurityConfigType
        {
            ($_ -eq "Get-OSSSecurityConfigList/Type") -Or
            ($_ -eq "New-OSSSecurityConfig/Type")
        }
        {
            $v = "iamidentitycenter","saml"
            break
        }

        # Amazon.OpenSearchServerless.SecurityPolicyType
        {
            ($_ -eq "Get-OSSSecurityPolicy/Type") -Or
            ($_ -eq "Get-OSSSecurityPolicyList/Type") -Or
            ($_ -eq "New-OSSSecurityPolicy/Type") -Or
            ($_ -eq "Remove-OSSSecurityPolicy/Type") -Or
            ($_ -eq "Update-OSSSecurityPolicy/Type")
        }
        {
            $v = "encryption","network"
            break
        }

        # Amazon.OpenSearchServerless.StandbyReplicas
        "New-OSSCollection/StandbyReplica"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.OpenSearchServerless.VpcEndpointStatus
        "Get-OSSVpcEndpointList/VpcEndpointFilters_Status"
        {
            $v = "ACTIVE","DELETING","FAILED","PENDING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$OSS_map = @{
    "CollectionFilters_Status"=@("Get-OSSCollectionList")
    "IamIdentityCenterOptions_GroupAttribute"=@("New-OSSSecurityConfig")
    "IamIdentityCenterOptions_UserAttribute"=@("New-OSSSecurityConfig")
    "IamIdentityCenterOptionsUpdates_GroupAttribute"=@("Update-OSSSecurityConfig")
    "IamIdentityCenterOptionsUpdates_UserAttribute"=@("Update-OSSSecurityConfig")
    "StandbyReplica"=@("New-OSSCollection")
    "Type"=@("Get-OSSAccessPolicy","Get-OSSAccessPolicyList","Get-OSSLifecyclePolicyList","Get-OSSSecurityConfigList","Get-OSSSecurityPolicy","Get-OSSSecurityPolicyList","New-OSSAccessPolicy","New-OSSCollection","New-OSSLifecyclePolicy","New-OSSSecurityConfig","New-OSSSecurityPolicy","Remove-OSSAccessPolicy","Remove-OSSLifecyclePolicy","Remove-OSSSecurityPolicy","Update-OSSAccessPolicy","Update-OSSLifecyclePolicy","Update-OSSSecurityPolicy")
    "VpcEndpointFilters_Status"=@("Get-OSSVpcEndpointList")
}

_awsArgumentCompleterRegistration $OSS_Completers $OSS_map

$OSS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.OSS.$($commandName.Replace('-', ''))Cmdlet]"
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

$OSS_SelectMap = @{
    "Select"=@("Get-OSSGetCollection",
               "Get-OSSGetEffectiveLifecyclePolicy",
               "Get-OSSGetLifecyclePolicy",
               "Get-OSSGetVpcEndpoint",
               "New-OSSAccessPolicy",
               "New-OSSCollection",
               "New-OSSLifecyclePolicy",
               "New-OSSSecurityConfig",
               "New-OSSSecurityPolicy",
               "New-OSSVpcEndpoint",
               "Remove-OSSAccessPolicy",
               "Remove-OSSCollection",
               "Remove-OSSLifecyclePolicy",
               "Remove-OSSSecurityConfig",
               "Remove-OSSSecurityPolicy",
               "Remove-OSSVpcEndpoint",
               "Get-OSSAccessPolicy",
               "Get-OSSAccountSetting",
               "Get-OSSPoliciesStat",
               "Get-OSSSecurityConfig",
               "Get-OSSSecurityPolicy",
               "Get-OSSAccessPolicyList",
               "Get-OSSCollectionList",
               "Get-OSSLifecyclePolicyList",
               "Get-OSSSecurityConfigList",
               "Get-OSSSecurityPolicyList",
               "Get-OSSResourceTag",
               "Get-OSSVpcEndpointList",
               "Add-OSSResourceTag",
               "Remove-OSSResourceTag",
               "Update-OSSAccessPolicy",
               "Update-OSSAccountSetting",
               "Update-OSSCollection",
               "Update-OSSLifecyclePolicy",
               "Update-OSSSecurityConfig",
               "Update-OSSSecurityPolicy",
               "Update-OSSVpcEndpoint")
}

_awsArgumentCompleterRegistration $OSS_SelectCompleters $OSS_SelectMap

