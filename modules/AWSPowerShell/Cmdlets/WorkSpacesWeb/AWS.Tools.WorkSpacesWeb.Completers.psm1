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

# Argument completions for service Amazon WorkSpaces Web


$WSW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WorkSpacesWeb.AuthenticationType
        {
            ($_ -eq "New-WSWPortal/AuthenticationType") -Or
            ($_ -eq "Update-WSWPortal/AuthenticationType")
        }
        {
            $v = "IAM_Identity_Center","Standard"
            break
        }

        # Amazon.WorkSpacesWeb.EnabledType
        {
            ($_ -eq "New-WSWUserSetting/CopyAllowed") -Or
            ($_ -eq "Update-WSWUserSetting/CopyAllowed") -Or
            ($_ -eq "New-WSWUserSetting/DeepLinkAllowed") -Or
            ($_ -eq "Update-WSWUserSetting/DeepLinkAllowed") -Or
            ($_ -eq "New-WSWUserSetting/DownloadAllowed") -Or
            ($_ -eq "Update-WSWUserSetting/DownloadAllowed") -Or
            ($_ -eq "New-WSWUserSetting/PasteAllowed") -Or
            ($_ -eq "Update-WSWUserSetting/PasteAllowed") -Or
            ($_ -eq "New-WSWUserSetting/PrintAllowed") -Or
            ($_ -eq "Update-WSWUserSetting/PrintAllowed") -Or
            ($_ -eq "New-WSWUserSetting/UploadAllowed") -Or
            ($_ -eq "Update-WSWUserSetting/UploadAllowed")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.WorkSpacesWeb.IdentityProviderType
        {
            ($_ -eq "New-WSWIdentityProvider/IdentityProviderType") -Or
            ($_ -eq "Update-WSWIdentityProvider/IdentityProviderType")
        }
        {
            $v = "Facebook","Google","LoginWithAmazon","OIDC","SAML","SignInWithApple"
            break
        }

        # Amazon.WorkSpacesWeb.InstanceType
        {
            ($_ -eq "New-WSWPortal/InstanceType") -Or
            ($_ -eq "Update-WSWPortal/InstanceType")
        }
        {
            $v = "standard.large","standard.regular","standard.xlarge"
            break
        }

        # Amazon.WorkSpacesWeb.MaxDisplayResolution
        {
            ($_ -eq "New-WSWUserSetting/ToolbarConfiguration_MaxDisplayResolution") -Or
            ($_ -eq "Update-WSWUserSetting/ToolbarConfiguration_MaxDisplayResolution")
        }
        {
            $v = "size1024X768","size1280X720","size1920X1080","size2560X1440","size3440X1440","size3840X2160","size4096X2160","size800X600"
            break
        }

        # Amazon.WorkSpacesWeb.SessionSortBy
        "Get-WSWSessionList/SortBy"
        {
            $v = "StartTimeAscending","StartTimeDescending"
            break
        }

        # Amazon.WorkSpacesWeb.SessionStatus
        "Get-WSWSessionList/Status"
        {
            $v = "Active","Terminated"
            break
        }

        # Amazon.WorkSpacesWeb.ToolbarType
        {
            ($_ -eq "New-WSWUserSetting/ToolbarConfiguration_ToolbarType") -Or
            ($_ -eq "Update-WSWUserSetting/ToolbarConfiguration_ToolbarType")
        }
        {
            $v = "Docked","Floating"
            break
        }

        # Amazon.WorkSpacesWeb.VisualMode
        {
            ($_ -eq "New-WSWUserSetting/ToolbarConfiguration_VisualMode") -Or
            ($_ -eq "Update-WSWUserSetting/ToolbarConfiguration_VisualMode")
        }
        {
            $v = "Dark","Light"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WSW_map = @{
    "AuthenticationType"=@("New-WSWPortal","Update-WSWPortal")
    "CopyAllowed"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "DeepLinkAllowed"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "DownloadAllowed"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "IdentityProviderType"=@("New-WSWIdentityProvider","Update-WSWIdentityProvider")
    "InstanceType"=@("New-WSWPortal","Update-WSWPortal")
    "PasteAllowed"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "PrintAllowed"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "SortBy"=@("Get-WSWSessionList")
    "Status"=@("Get-WSWSessionList")
    "ToolbarConfiguration_MaxDisplayResolution"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "ToolbarConfiguration_ToolbarType"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "ToolbarConfiguration_VisualMode"=@("New-WSWUserSetting","Update-WSWUserSetting")
    "UploadAllowed"=@("New-WSWUserSetting","Update-WSWUserSetting")
}

_awsArgumentCompleterRegistration $WSW_Completers $WSW_map

$WSW_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WSW.$($commandName.Replace('-', ''))Cmdlet]"
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

$WSW_SelectMap = @{
    "Select"=@("Register-WSWBrowserSetting",
               "Register-WSWDataProtectionSetting",
               "Register-WSWIpAccessSetting",
               "Register-WSWNetworkSetting",
               "Register-WSWTrustStore",
               "Register-WSWUserAccessLoggingSetting",
               "Register-WSWUserSetting",
               "New-WSWBrowserSetting",
               "New-WSWDataProtectionSetting",
               "New-WSWIdentityProvider",
               "New-WSWIpAccessSetting",
               "New-WSWNetworkSetting",
               "New-WSWPortal",
               "New-WSWTrustStore",
               "New-WSWUserAccessLoggingSetting",
               "New-WSWUserSetting",
               "Remove-WSWBrowserSetting",
               "Remove-WSWDataProtectionSetting",
               "Remove-WSWIdentityProvider",
               "Remove-WSWIpAccessSetting",
               "Remove-WSWNetworkSetting",
               "Remove-WSWPortal",
               "Remove-WSWTrustStore",
               "Remove-WSWUserAccessLoggingSetting",
               "Remove-WSWUserSetting",
               "Unregister-WSWBrowserSetting",
               "Unregister-WSWDataProtectionSetting",
               "Unregister-WSWIpAccessSetting",
               "Unregister-WSWNetworkSetting",
               "Unregister-WSWTrustStore",
               "Unregister-WSWUserAccessLoggingSetting",
               "Unregister-WSWUserSetting",
               "Revoke-WSWSession",
               "Get-WSWBrowserSetting",
               "Get-WSWDataProtectionSetting",
               "Get-WSWIdentityProvider",
               "Get-WSWIpAccessSetting",
               "Get-WSWNetworkSetting",
               "Get-WSWPortal",
               "Get-WSWPortalServiceProviderMetadata",
               "Get-WSWSession",
               "Get-WSWTrustStore",
               "Get-WSWTrustStoreCertificate",
               "Get-WSWUserAccessLoggingSetting",
               "Get-WSWUserSetting",
               "Get-WSWBrowserSettingList",
               "Get-WSWDataProtectionSettingList",
               "Get-WSWIdentityProviderList",
               "Get-WSWIpAccessSettingList",
               "Get-WSWNetworkSettingList",
               "Get-WSWPortalList",
               "Get-WSWSessionList",
               "Get-WSWResourceTag",
               "Get-WSWTrustStoreCertificateList",
               "Get-WSWTrustStoreList",
               "Get-WSWUserAccessLoggingSettingList",
               "Get-WSWUserSettingList",
               "Add-WSWResourceTag",
               "Remove-WSWResourceTag",
               "Update-WSWBrowserSetting",
               "Update-WSWDataProtectionSetting",
               "Update-WSWIdentityProvider",
               "Update-WSWIpAccessSetting",
               "Update-WSWNetworkSetting",
               "Update-WSWPortal",
               "Update-WSWTrustStore",
               "Update-WSWUserAccessLoggingSetting",
               "Update-WSWUserSetting")
}

_awsArgumentCompleterRegistration $WSW_SelectCompleters $WSW_SelectMap

