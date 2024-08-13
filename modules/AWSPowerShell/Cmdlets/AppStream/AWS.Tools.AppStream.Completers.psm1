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

# Argument completions for service Amazon AppStream


$APS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AppStream.AppBlockBuilderPlatformType
        "New-APSAppBlockBuilder/Platform"
        {
            $v = "WINDOWS_SERVER_2019"
            break
        }

        # Amazon.AppStream.AppVisibility
        {
            ($_ -eq "New-APSEntitlement/AppVisibility") -Or
            ($_ -eq "Update-APSEntitlement/AppVisibility")
        }
        {
            $v = "ALL","ASSOCIATED"
            break
        }

        # Amazon.AppStream.AuthenticationType
        {
            ($_ -eq "Disable-APSUser/AuthenticationType") -Or
            ($_ -eq "Enable-APSUser/AuthenticationType") -Or
            ($_ -eq "Get-APSSessionList/AuthenticationType") -Or
            ($_ -eq "Get-APSUser/AuthenticationType") -Or
            ($_ -eq "Get-APSUserStackAssociation/AuthenticationType") -Or
            ($_ -eq "New-APSUser/AuthenticationType") -Or
            ($_ -eq "Remove-APSUser/AuthenticationType")
        }
        {
            $v = "API","AWS_AD","SAML","USERPOOL"
            break
        }

        # Amazon.AppStream.CertificateBasedAuthStatus
        {
            ($_ -eq "New-APSDirectoryConfig/CertificateBasedAuthProperties_Status") -Or
            ($_ -eq "Update-APSDirectoryConfig/CertificateBasedAuthProperties_Status")
        }
        {
            $v = "DISABLED","ENABLED","ENABLED_NO_DIRECTORY_LOGIN_FALLBACK"
            break
        }

        # Amazon.AppStream.FleetType
        "New-APSFleet/FleetType"
        {
            $v = "ALWAYS_ON","ELASTIC","ON_DEMAND"
            break
        }

        # Amazon.AppStream.MessageAction
        "New-APSUser/MessageAction"
        {
            $v = "RESEND","SUPPRESS"
            break
        }

        # Amazon.AppStream.PackagingType
        "New-APSAppBlock/PackagingType"
        {
            $v = "APPSTREAM2","CUSTOM"
            break
        }

        # Amazon.AppStream.PlatformType
        {
            ($_ -eq "New-APSFleet/Platform") -Or
            ($_ -eq "Update-APSAppBlockBuilder/Platform") -Or
            ($_ -eq "Update-APSFleet/Platform")
        }
        {
            $v = "AMAZON_LINUX2","RHEL8","WINDOWS","WINDOWS_SERVER_2016","WINDOWS_SERVER_2019","WINDOWS_SERVER_2022"
            break
        }

        # Amazon.AppStream.PreferredProtocol
        {
            ($_ -eq "New-APSStack/StreamingExperienceSettings_PreferredProtocol") -Or
            ($_ -eq "Update-APSStack/StreamingExperienceSettings_PreferredProtocol")
        }
        {
            $v = "TCP","UDP"
            break
        }

        # Amazon.AppStream.StreamView
        {
            ($_ -eq "New-APSFleet/StreamView") -Or
            ($_ -eq "Update-APSFleet/StreamView")
        }
        {
            $v = "APP","DESKTOP"
            break
        }

        # Amazon.AppStream.ThemeState
        "Update-APSThemeForStack/State"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.AppStream.ThemeStyling
        {
            ($_ -eq "New-APSThemeForStack/ThemeStyling") -Or
            ($_ -eq "Update-APSThemeForStack/ThemeStyling")
        }
        {
            $v = "BLUE","LIGHT_BLUE","PINK","RED"
            break
        }

        # Amazon.AppStream.VisibilityType
        "Get-APSImageList/Type"
        {
            $v = "PRIVATE","PUBLIC","SHARED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$APS_map = @{
    "AppVisibility"=@("New-APSEntitlement","Update-APSEntitlement")
    "AuthenticationType"=@("Disable-APSUser","Enable-APSUser","Get-APSSessionList","Get-APSUser","Get-APSUserStackAssociation","New-APSUser","Remove-APSUser")
    "CertificateBasedAuthProperties_Status"=@("New-APSDirectoryConfig","Update-APSDirectoryConfig")
    "FleetType"=@("New-APSFleet")
    "MessageAction"=@("New-APSUser")
    "PackagingType"=@("New-APSAppBlock")
    "Platform"=@("New-APSAppBlockBuilder","New-APSFleet","Update-APSAppBlockBuilder","Update-APSFleet")
    "State"=@("Update-APSThemeForStack")
    "StreamingExperienceSettings_PreferredProtocol"=@("New-APSStack","Update-APSStack")
    "StreamView"=@("New-APSFleet","Update-APSFleet")
    "ThemeStyling"=@("New-APSThemeForStack","Update-APSThemeForStack")
    "Type"=@("Get-APSImageList")
}

_awsArgumentCompleterRegistration $APS_Completers $APS_map

$APS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.APS.$($commandName.Replace('-', ''))Cmdlet]"
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

$APS_SelectMap = @{
    "Select"=@("Add-APSAppBlockBuilderAppBlock",
               "Register-APSApplicationFleet",
               "Add-APSApplicationToEntitlement",
               "Register-APSFleet",
               "Register-APSUserStackBatch",
               "Unregister-APSUserStackBatch",
               "Copy-APSImage",
               "New-APSAppBlock",
               "New-APSAppBlockBuilder",
               "New-APSAppBlockBuilderStreamingURL",
               "New-APSApplication",
               "New-APSDirectoryConfig",
               "New-APSEntitlement",
               "New-APSFleet",
               "New-APSImageBuilder",
               "New-APSImageBuilderStreamingURL",
               "New-APSStack",
               "New-APSStreamingURL",
               "New-APSThemeForStack",
               "New-APSUpdatedImage",
               "New-APSUsageReportSubscription",
               "New-APSUser",
               "Remove-APSAppBlock",
               "Remove-APSAppBlockBuilder",
               "Remove-APSApplication",
               "Remove-APSDirectoryConfig",
               "Remove-APSEntitlement",
               "Remove-APSFleet",
               "Remove-APSImage",
               "Remove-APSImageBuilder",
               "Remove-APSImagePermission",
               "Remove-APSStack",
               "Remove-APSThemeForStack",
               "Remove-APSUsageReportSubscription",
               "Remove-APSUser",
               "Get-APSAppBlockBuilderAppBlockAssociation",
               "Get-APSAppBlockBuilder",
               "Get-APSAppBlock",
               "Get-APSApplicationFleetAssociation",
               "Get-APSApplication",
               "Get-APSDirectoryConfigList",
               "Get-APSEntitlement",
               "Get-APSFleetList",
               "Get-APSImageBuilderList",
               "Get-APSImagePermission",
               "Get-APSImageList",
               "Get-APSSessionList",
               "Get-APSStackList",
               "Get-APSThemeForStack",
               "Get-APSUsageReportSubscription",
               "Get-APSUser",
               "Get-APSUserStackAssociation",
               "Disable-APSUser",
               "Remove-APSAppBlockBuilderAppBlock",
               "Unregister-APSApplicationFleet",
               "Remove-APSApplicationFromEntitlement",
               "Unregister-APSFleet",
               "Enable-APSUser",
               "Revoke-APSSession",
               "Get-APSAssociatedFleetList",
               "Get-APSAssociatedStackList",
               "Get-APSEntitledApplicationList",
               "Get-APSTagsForResourceList",
               "Start-APSAppBlockBuilder",
               "Start-APSFleet",
               "Start-APSImageBuilder",
               "Stop-APSAppBlockBuilder",
               "Stop-APSFleet",
               "Stop-APSImageBuilder",
               "Add-APSResourceTag",
               "Remove-APSResourceTag",
               "Update-APSAppBlockBuilder",
               "Update-APSApplication",
               "Update-APSDirectoryConfig",
               "Update-APSEntitlement",
               "Update-APSFleet",
               "Update-APSImagePermission",
               "Update-APSStack",
               "Update-APSThemeForStack")
}

_awsArgumentCompleterRegistration $APS_SelectCompleters $APS_SelectMap

