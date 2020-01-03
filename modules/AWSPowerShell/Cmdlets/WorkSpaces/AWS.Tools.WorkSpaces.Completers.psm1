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
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeIos") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeOsx") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeWeb") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeWindows") -Or
            ($_ -eq "Edit-WKSWorkspaceAccessProperty/WorkspaceAccessProperties_DeviceTypeZeroClient")
        }
        {
            $v = "ALLOW","DENY"
            break
        }

        # Amazon.WorkSpaces.Compute
        "Edit-WKSWorkspaceProperty/WorkspaceProperties_ComputeTypeName"
        {
            $v = "GRAPHICS","GRAPHICSPRO","PERFORMANCE","POWER","POWERPRO","STANDARD","VALUE"
            break
        }

        # Amazon.WorkSpaces.DedicatedTenancySupportEnum
        "Edit-WKSAccount/DedicatedTenancySupport"
        {
            $v = "ENABLED"
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
            $v = "ALWAYS_ON","AUTO_STOP"
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

        # Amazon.WorkSpaces.WorkspaceImageIngestionProcess
        "Import-WKSWorkspaceImage/IngestionProcess"
        {
            $v = "BYOL_GRAPHICS","BYOL_GRAPHICSPRO","BYOL_REGULAR"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WKS_map = @{
    "ClientProperties_ReconnectEnabled"=@("Edit-WKSClientProperty")
    "DedicatedTenancySupport"=@("Edit-WKSAccount")
    "IngestionProcess"=@("Import-WKSWorkspaceImage")
    "SelfservicePermissions_ChangeComputeType"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_IncreaseVolumeSize"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_RebuildWorkspace"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_RestartWorkspace"=@("Edit-WKSSelfservicePermission")
    "SelfservicePermissions_SwitchRunningMode"=@("Edit-WKSSelfservicePermission")
    "Tenancy"=@("Register-WKSWorkspaceDirectory")
    "WorkspaceAccessProperties_DeviceTypeAndroid"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeChromeOs"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeIos"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeOsx"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeWeb"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeWindows"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceAccessProperties_DeviceTypeZeroClient"=@("Edit-WKSWorkspaceAccessProperty")
    "WorkspaceProperties_ComputeTypeName"=@("Edit-WKSWorkspaceProperty")
    "WorkspaceProperties_RunningMode"=@("Edit-WKSWorkspaceProperty")
    "WorkspaceState"=@("Edit-WKSWorkspaceState")
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
    "Select"=@("Register-WKSIpGroup",
               "Approve-WKSIpRule",
               "Copy-WKSWorkspaceImage",
               "New-WKSIpGroup",
               "New-WKSTag",
               "New-WKSWorkspace",
               "Remove-WKSIpGroup",
               "Remove-WKSTag",
               "Remove-WKSWorkspaceImage",
               "Unregister-WKSWorkspaceDirectory",
               "Get-WKSAccount",
               "Get-WKSAccountModification",
               "Get-WKSClientProperty",
               "Get-WKSIpGroup",
               "Get-WKSTag",
               "Get-WKSWorkspaceBundle",
               "Get-WKSWorkspaceDirectory",
               "Get-WKSWorkspaceImage",
               "Get-WKSWorkspace",
               "Get-WKSWorkspacesConnectionStatus",
               "Get-WKSWorkspaceSnapshot",
               "Unregister-WKSIpGroup",
               "Import-WKSWorkspaceImage",
               "Get-WKSAvailableManagementCidrRangeList",
               "Start-WKSWorkspaceMigration",
               "Edit-WKSAccount",
               "Edit-WKSClientProperty",
               "Edit-WKSSelfservicePermission",
               "Edit-WKSWorkspaceAccessProperty",
               "Edit-WKSWorkspaceCreationProperty",
               "Edit-WKSWorkspaceProperty",
               "Edit-WKSWorkspaceState",
               "Restart-WKSWorkspace",
               "Reset-WKSWorkspace",
               "Register-WKSWorkspaceDirectory",
               "Restore-WKSWorkspace",
               "Revoke-WKSIpRule",
               "Start-WKSWorkspace",
               "Stop-WKSWorkspace",
               "Remove-WKSWorkspace",
               "Update-WKSRulesOfIpGroup")
}

_awsArgumentCompleterRegistration $WKS_SelectCompleters $WKS_SelectMap

