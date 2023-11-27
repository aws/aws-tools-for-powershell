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

# Argument completions for service Amazon WorkSpaces Thin Client


$WSTC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.WorkSpacesThinClient.ApplyTimeOf
        {
            ($_ -eq "New-WSTCEnvironment/MaintenanceWindow_ApplyTimeOf") -Or
            ($_ -eq "Update-WSTCEnvironment/MaintenanceWindow_ApplyTimeOf")
        }
        {
            $v = "DEVICE","UTC"
            break
        }

        # Amazon.WorkSpacesThinClient.MaintenanceWindowType
        {
            ($_ -eq "New-WSTCEnvironment/MaintenanceWindow_Type") -Or
            ($_ -eq "Update-WSTCEnvironment/MaintenanceWindow_Type")
        }
        {
            $v = "CUSTOM","SYSTEM"
            break
        }

        # Amazon.WorkSpacesThinClient.SoftwareSetUpdateMode
        {
            ($_ -eq "New-WSTCEnvironment/SoftwareSetUpdateMode") -Or
            ($_ -eq "Update-WSTCEnvironment/SoftwareSetUpdateMode")
        }
        {
            $v = "USE_DESIRED","USE_LATEST"
            break
        }

        # Amazon.WorkSpacesThinClient.SoftwareSetUpdateSchedule
        {
            ($_ -eq "New-WSTCEnvironment/SoftwareSetUpdateSchedule") -Or
            ($_ -eq "Update-WSTCDevice/SoftwareSetUpdateSchedule") -Or
            ($_ -eq "Update-WSTCEnvironment/SoftwareSetUpdateSchedule")
        }
        {
            $v = "APPLY_IMMEDIATELY","USE_MAINTENANCE_WINDOW"
            break
        }

        # Amazon.WorkSpacesThinClient.SoftwareSetValidationStatus
        "Update-WSTCSoftwareSet/ValidationStatus"
        {
            $v = "NOT_VALIDATED","VALIDATED"
            break
        }

        # Amazon.WorkSpacesThinClient.TargetDeviceStatus
        "Unregister-WSTCDevice/TargetDeviceStatus"
        {
            $v = "ARCHIVED","DEREGISTERED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$WSTC_map = @{
    "MaintenanceWindow_ApplyTimeOf"=@("New-WSTCEnvironment","Update-WSTCEnvironment")
    "MaintenanceWindow_Type"=@("New-WSTCEnvironment","Update-WSTCEnvironment")
    "SoftwareSetUpdateMode"=@("New-WSTCEnvironment","Update-WSTCEnvironment")
    "SoftwareSetUpdateSchedule"=@("New-WSTCEnvironment","Update-WSTCDevice","Update-WSTCEnvironment")
    "TargetDeviceStatus"=@("Unregister-WSTCDevice")
    "ValidationStatus"=@("Update-WSTCSoftwareSet")
}

_awsArgumentCompleterRegistration $WSTC_Completers $WSTC_map

$WSTC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.WSTC.$($commandName.Replace('-', ''))Cmdlet]"
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

$WSTC_SelectMap = @{
    "Select"=@("New-WSTCEnvironment",
               "Remove-WSTCDevice",
               "Remove-WSTCEnvironment",
               "Unregister-WSTCDevice",
               "Get-WSTCDevice",
               "Get-WSTCEnvironment",
               "Get-WSTCSoftwareSet",
               "Get-WSTCDeviceList",
               "Get-WSTCEnvironmentList",
               "Get-WSTCSoftwareSetList",
               "Get-WSTCResourceTag",
               "Add-WSTCResourceTag",
               "Remove-WSTCResourceTag",
               "Update-WSTCDevice",
               "Update-WSTCEnvironment",
               "Update-WSTCSoftwareSet")
}

_awsArgumentCompleterRegistration $WSTC_SelectCompleters $WSTC_SelectMap

