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

# Argument completions for service APIPortal


$APIP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.APIPortal.ApiSelectionMode
        {
            ($_ -eq "New-APIPProduct/ApiSelectionConfiguration_ApiSelectionMode") -Or
            ($_ -eq "Update-APIPProduct/ApiSelectionConfiguration_ApiSelectionMode")
        }
        {
            $v = "CUSTOM","RULE_BASED"
            break
        }

        # Amazon.APIPortal.DesiredPublishStatus
        "Update-APIPPortalPublishStatus/Status"
        {
            $v = "DISABLED","PUBLISHED"
            break
        }

        # Amazon.APIPortal.DiscoverySource
        {
            ($_ -eq "Get-APIPDiscoveryStatusList/DiscoverySource") -Or
            ($_ -eq "Get-APIPApiInventoryItemList/Filters_DiscoverySource")
        }
        {
            $v = "API_GATEWAY","CLOUDFRONT","ELB"
            break
        }

        # Amazon.APIPortal.FineGrainedAccessControl
        {
            ($_ -eq "New-APIPPortal/Authorization_FineGrainedAccessControl") -Or
            ($_ -eq "Update-APIPPortal/Authorization_FineGrainedAccessControl")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.APIPortal.HttpMethod
        {
            ($_ -eq "New-APIPManagedApi/ApiSignature_Method") -Or
            ($_ -eq "Get-APIPApiInventoryItem/Method")
        }
        {
            $v = "ANY","DELETE","GET","HEAD","OPTIONS","PATCH","POST","PUT"
            break
        }

        # Amazon.APIPortal.ResourceOwner
        "Get-APIPProductList/ResourceOwner"
        {
            $v = "ALL","OTHER_ACCOUNTS","SELF"
            break
        }

        # Amazon.APIPortal.TryItState
        {
            ($_ -eq "New-APIPProductApiPage/TryItState") -Or
            ($_ -eq "Update-APIPProductApiPage/TryItState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$APIP_map = @{
    "ApiSelectionConfiguration_ApiSelectionMode"=@("New-APIPProduct","Update-APIPProduct")
    "ApiSignature_Method"=@("New-APIPManagedApi")
    "Authorization_FineGrainedAccessControl"=@("New-APIPPortal","Update-APIPPortal")
    "DiscoverySource"=@("Get-APIPDiscoveryStatusList")
    "Filters_DiscoverySource"=@("Get-APIPApiInventoryItemList")
    "Method"=@("Get-APIPApiInventoryItem")
    "ResourceOwner"=@("Get-APIPProductList")
    "Status"=@("Update-APIPPortalPublishStatus")
    "TryItState"=@("New-APIPProductApiPage","Update-APIPProductApiPage")
}

_awsArgumentCompleterRegistration $APIP_Completers $APIP_map

$APIP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.APIP.$($commandName.Replace('-', ''))Cmdlet]"
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

$APIP_SelectMap = @{
    "Select"=@("Add-APIPManagedApi",
               "New-APIPManagedApi",
               "New-APIPPortal",
               "New-APIPPortalPreview",
               "New-APIPProduct",
               "New-APIPProductApiPage",
               "New-APIPProductPage",
               "Remove-APIPDiscoveryConfiguration",
               "Remove-APIPManagedApi",
               "Remove-APIPOrganizationDiscoveryConfiguration",
               "Remove-APIPPortal",
               "Remove-APIPProduct",
               "Remove-APIPProductApiPage",
               "Remove-APIPProductPage",
               "Remove-APIPProductSharingPolicy",
               "Unregister-APIPManagedApi",
               "Get-APIPApiInventoryItem",
               "Get-APIPDiscoveryConfiguration",
               "Get-APIPManagedApi",
               "Get-APIPOrganizationDiscoveryConfiguration",
               "Get-APIPPortal",
               "Get-APIPProduct",
               "Get-APIPProductApiPage",
               "Get-APIPProductPage",
               "Get-APIPProductSharingPolicy",
               "Get-APIPApiInventoryItemList",
               "Get-APIPDiscoveryStatusList",
               "Get-APIPManagedApiEventList",
               "Get-APIPManagedApiList",
               "Get-APIPPortalList",
               "Get-APIPProductApiPageList",
               "Get-APIPProductPageList",
               "Get-APIPProductList",
               "Get-APIPResourceTag",
               "Write-APIPDiscoveryConfiguration",
               "Write-APIPOrganizationDiscoveryConfiguration",
               "Write-APIPProductSharingPolicy",
               "Start-APIPDiscovery",
               "Stop-APIPDiscovery",
               "Add-APIPResourceTag",
               "Remove-APIPResourceTag",
               "Update-APIPPortal",
               "Update-APIPPortalPublishStatus",
               "Update-APIPProduct",
               "Update-APIPProductApiPage",
               "Update-APIPProductPage")
}

_awsArgumentCompleterRegistration $APIP_SelectCompleters $APIP_SelectMap

