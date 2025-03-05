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

# Argument completions for service Amazon WorkSpaces


$WKS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WorkSpaces.AccessPropertyValue
        {
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeAndroid") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeChromeOs") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeIo") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeLinux") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeOsx") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeWeb") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeWindow") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeZeroClient")
        }
        {
            $v = "ALLOW","DENY"
            break
        }

        # Amazon.WorkSpaces.AGAModeForDirectoryEnum
        "Edit-WKSStreamingProperty/GlobalAccelerator_Mode"
        {
            $v = "DISABLED","ENABLED_AUTO"
            break
        }

        # Amazon.WorkSpaces.AGAModeForWorkSpaceEnum
        "Edit-WKSWorkspaceProperty/GlobalAccelerator_Mode"
        {
            $v = "DISABLED","ENABLED_AUTO","INHERITED"
            break
        }

        # Amazon.WorkSpaces.AGAPreferredProtocolForDirectory
        "Edit-WKSStreamingProperty/GlobalAccelerator_PreferredProtocol"
        {
            $v = "NONE","TCP"
            break
        }

        # Amazon.WorkSpaces.AGAPreferredProtocolForWorkSpace
        "Edit-WKSWorkspaceProperty/GlobalAccelerator_PreferredProtocol"
        {
            $v = "INHERITED","NONE","TCP"
            break
        }

        # Amazon.WorkSpaces.ApplicationSettingsStatusEnum
        {
            ($_ -eq "New-WKSWorkspacesPool/ApplicationSettings_Status") -Or
            ($_ -eq "Update-WKSWorkspacesPool/ApplicationSettings_Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.WorkSpaces.CertificateBasedAuthStatusEnum
        "Edit-WKSCertificateBasedAuthProperty/CertificateBasedAuthProperties_Status"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.WorkSpaces.Compute
        {
            ($_ -eq "New-WKSWorkspaceBundle/ComputeType_Name") -Or
            ($_ -eq "Edit-WKSWorkspaceProperty/WorkspaceProperties_ComputeTypeName")
        }
        {
            $v = "GENERALPURPOSE_4XLARGE","GENERALPURPOSE_8XLARGE","GRAPHICS","GRAPHICSPRO","GRAPHICSPRO_G4DN","GRAPHICS_G4DN","PERFORMANCE","POWER","POWERPRO","STANDARD","VALUE"
            break
        }

        # Amazon.WorkSpaces.DataReplication
        "Edit-WKSWorkspaceProperty/DataReplication"
        {
            $v = "NO_REPLICATION","PRIMARY_AS_SOURCE"
            break
        }

        # Amazon.WorkSpaces.DedicatedTenancySupportEnum
        "Edit-WKSAccount/DedicatedTenancySupport"
        {
            $v = "ENABLED"
            break
        }

        # Amazon.WorkSpaces.ImageType
        "Get-WKSWorkspaceImage/ImageType"
        {
            $v = "OWNED","SHARED"
            break
        }

        # Amazon.WorkSpaces.LogUploadEnum
        "Edit-WKSClientProperty/ClientProperties_LogUploadEnabled"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.WorkSpaces.OperatingSystemName
        "Edit-WKSWorkspaceProperty/WorkspaceProperties_OperatingSystemName"
        {
            $v = "AMAZON_LINUX_2","RHEL_8","ROCKY_8","UBUNTU_18_04","UBUNTU_20_04","UBUNTU_22_04","UNKNOWN","WINDOWS_10","WINDOWS_11","WINDOWS_7","WINDOWS_SERVER_2016","WINDOWS_SERVER_2019","WINDOWS_SERVER_2022"
            break
        }

        # Amazon.WorkSpaces.ReconnectEnum
        {
            ($_ -eq "Edit-WKSClientProperty/ClientProperties_ReconnectEnabled") -Or
            ($_ -eq "Edit-WKSSelfservicePermission/SelfservicePermissions_ChangeComputeType") -Or
            ($_ -eq "Edit-WKSSelfservicePermission/SelfservicePermissions_IncreaseVolumeSize") -Or
            ($_ -eq "Edit-WKSSelfservicePermission/SelfservicePermissions_RebuildWorkspace") -Or
            ($_ -eq "Edit-WKSSelfservicePermission/SelfservicePermissions_RestartWorkspace") -Or
            ($_ -eq "Edit-WKSSelfservicePermission/SelfservicePermissions_SwitchRunningMode")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.WorkSpaces.RunningMode
        "Edit-WKSWorkspaceProperty/WorkspaceProperties_RunningMode"
        {
            $v = "ALWAYS_ON","AUTO_STOP","MANUAL"
            break
        }

        # Amazon.WorkSpaces.SamlStatusEnum
        "Edit-WKSSamlProperty/SamlProperties_Status"
        {
            $v = "DISABLED","ENABLED","ENABLED_WITH_DIRECTORY_LOGIN_FALLBACK"
            break
        }

        # Amazon.WorkSpaces.StreamingExperiencePreferredProtocolEnum
        "Edit-WKSStreamingProperty/StreamingProperties_StreamingExperiencePreferredProtocol"
        {
            $v = "TCP","UDP"
            break
        }

        # Amazon.WorkSpaces.TargetWorkspaceState
        "Edit-WKSWorkspaceState/WorkspaceState"
        {
            $v = "ADMIN_MAINTENANCE","AVAILABLE"
            break
        }

        # Amazon.WorkSpaces.Tenancy
        "Register-WKSWorkspaceDirectory/Tenancy"
        {
            $v = "DEDICATED","SHARED"
            break
        }

        # Amazon.WorkSpaces.UserIdentityType
        "Register-WKSWorkspaceDirectory/UserIdentityType"
        {
            $v = "AWS_DIRECTORY_SERVICE","AWS_IAM_IDENTITY_CENTER","CUSTOMER_MANAGED"
            break
        }

        # Amazon.WorkSpaces.WorkSpaceApplicationLicenseType
        "Get-WKSApplication/LicenseType"
        {
            $v = "LICENSED","UNLICENSED"
            break
        }

        # Amazon.WorkSpaces.WorkspaceImageIngestionProcess
        "Import-WKSWorkspaceImage/IngestionProcess"
        {
            $v = "BYOL_GRAPHICS","BYOL_GRAPHICSPRO","BYOL_GRAPHICS_G4DN","BYOL_GRAPHICS_G4DN_BYOP","BYOL_GRAPHICS_G4DN_WSP","BYOL_REGULAR","BYOL_REGULAR_BYOP","BYOL_REGULAR_WSP"
            break
        }

        # Amazon.WorkSpaces.WorkspaceType
        "Register-WKSWorkspaceDirectory/WorkspaceType"
        {
            $v = "PERSONAL","POOLS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WKS_map = @{
    "ApplicationSettings_Status"=@("New-WKSWorkspacesPool","Update-WKSWorkspacesPool")
    "CertificateBasedAuthProperties_Status"=@("Edit-WKSCertificateBasedAuthProperty")
    "ClientProperties_LogUploadEnabled"=@("Edit-WKSClientProperty")
    "ClientProperties_ReconnectEnabled"=@("Edit-WKSClientProperty")
    "ComputeType_Name"=@("New-WKSWorkspaceBundle")
    "DataReplication"=@("Edit-WKSWorkspaceProperty")
    "DedicatedTenancySupport"=@("Edit-WKSAccount")
    "GlobalAccelerator_Mode"=@("Edit-WKSStreamingProperty","Edit-WKSWorkspaceProperty")
    "GlobalAccelerator_PreferredProtocol"=@("Edit-WKSStreamingProperty","Edit-WKSWorkspaceProperty")
    "ImageType"=@("Get-WKSWorkspaceImage")
    "IngestionProcess"=@("Import-WKSWorkspaceImage")
    "LicenseType"=@("Get-WKSApplication")
    "SamlProperties_Status"=@("Edit-WKSSamlProperty")
    "SelfservicePermissions_ChangeComputeType"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_IncreaseVolumeSize"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_RebuildWorkspace"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_RestartWorkspace"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_SwitchRunningMode"=@("Edit-WKSSelfservicePermission")
    "StreamingProperties_StreamingExperiencePreferredProtocol"=@("Edit-WKSStreamingProperty")
    "Tenancy"=@("Register-WKSWorkspaceDirectory")
    "UserIdentityType"=@("Register-WKSWorkspaceDirectory")
    "WorkspaceAccessProperties_DeviceTypeAndroid"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeChromeOs"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeIo"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeLinux"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeOsx"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeWeb"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeWindow"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeWorkSpacesThinClient"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeZeroClient"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceProperties_ComputeTypeName"=@("Edit-WKSWorkspaceProperty")
    "WorkspaceProperties_OperatingSystemName"=@("Edit-WKSWorkspaceProperty")
    "WorkspaceProperties_RunningMode"=@("Edit-WKSWorkspaceProperty")
    "WorkspaceState"=@("Edit-WKSWorkspaceState")
    "WorkspaceType"=@("Register-WKSWorkspaceDirectory")
}

_awsArgumentCompleterRegistration $WKS_Completers $WKS_map

$WKS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WKS.$($commandName.Replace('-', ''))Cmdlet]"
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

$WKS_SelectMap = @{
    "Select"=@("Approve-WKSAccountLinkInvitation",
               "Register-WKSConnectionAlias",
               "Register-WKSIpGroup",
               "Register-WKSWorkspaceApplication",
               "Approve-WKSIpRule",
               "Copy-WKSWorkspaceImage",
               "New-WKSAccountLinkInvitation",
               "New-WKSConnectClientAddIn",
               "New-WKSConnectionAlias",
               "New-WKSIpGroup",
               "New-WKSStandbyWorkspace",
               "New-WKSTag",
               "New-WKSUpdatedWorkspaceImage",
               "New-WKSWorkspaceBundle",
               "New-WKSWorkspaceImage",
               "New-WKSWorkspace",
               "New-WKSWorkspacesPool",
               "Remove-WKSAccountLinkInvitation",
               "Remove-WKSClientBranding",
               "Remove-WKSConnectClientAddIn",
               "Remove-WKSConnectionAlias",
               "Remove-WKSIpGroup",
               "Remove-WKSTag",
               "Remove-WKSWorkspaceBundle",
               "Remove-WKSWorkspaceImage",
               "Publish-WKSWorkspaceApplication",
               "Unregister-WKSWorkspaceDirectory",
               "Get-WKSAccount",
               "Get-WKSAccountModification",
               "Get-WKSApplicationAssociation",
               "Get-WKSApplication",
               "Get-WKSBundleAssociation",
               "Get-WKSClientBranding",
               "Get-WKSClientProperty",
               "Get-WKSConnectClientAddIn",
               "Get-WKSConnectionAlias",
               "Get-WKSConnectionAliasPermission",
               "Get-WKSImageAssociation",
               "Get-WKSIpGroup",
               "Get-WKSTag",
               "Get-WKSWorkspaceAssociation",
               "Get-WKSWorkspaceBundle",
               "Get-WKSWorkspaceDirectory",
               "Get-WKSWorkspaceImagePermission",
               "Get-WKSWorkspaceImage",
               "Get-WKSWorkspace",
               "Get-WKSWorkspacesConnectionStatus",
               "Get-WKSWorkspaceSnapshot",
               "Get-WKSWorkspacesPool",
               "Get-WKSWorkspacesPoolSession",
               "Unregister-WKSConnectionAlias",
               "Unregister-WKSIpGroup",
               "Unregister-WKSWorkspaceApplication",
               "Get-WKSAccountLink",
               "Import-WKSClientBranding",
               "Import-WKSWorkspaceImage",
               "Get-WKSAccountLinkList",
               "Get-WKSAvailableManagementCidrRangeList",
               "Start-WKSWorkspaceMigration",
               "Edit-WKSAccount",
               "Edit-WKSCertificateBasedAuthProperty",
               "Edit-WKSClientProperty",
               "Edit-WKSSamlProperty",
               "Edit-WKSSelfservicePermission",
               "Edit-WKSStreamingProperty",
               "Edit-WKSWorkspaceAccessProperty",
               "Edit-WKSWorkspaceCreationProperty",
               "Edit-WKSWorkspaceProperty",
               "Edit-WKSWorkspaceState",
               "Restart-WKSWorkspace",
               "Reset-WKSWorkspace",
               "Register-WKSWorkspaceDirectory",
               "Deny-WKSAccountLinkInvitation",
               "Restore-WKSWorkspace",
               "Revoke-WKSIpRule",
               "Start-WKSWorkspace",
               "Start-WKSWorkspacesPool",
               "Stop-WKSWorkspace",
               "Stop-WKSWorkspacesPool",
               "Remove-WKSWorkspace",
               "Remove-WKSWorkspacesPool",
               "Remove-WKSWorkspacesPoolSession",
               "Update-WKSConnectClientAddIn",
               "Update-WKSConnectionAliasPermission",
               "Update-WKSRulesOfIpGroup",
               "Update-WKSWorkspaceBundle",
               "Update-WKSWorkspaceImagePermission",
               "Update-WKSWorkspacesPool")
}

_awsArgumentCompleterRegistration $WKS_SelectCompleters $WKS_SelectMap

