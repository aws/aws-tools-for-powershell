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

# Argument completions for service Amazon Nimble Studio


$NS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.NimbleStudio.AutomaticTerminationMode
        {
            ($_ -eq "New-NSLaunchProfile/StreamConfiguration_AutomaticTerminationMode") -Or
            ($_ -eq "Update-NSLaunchProfile/StreamConfiguration_AutomaticTerminationMode")
        }
        {
            $v = "ACTIVATED","DEACTIVATED"
            break
        }

        # Amazon.NimbleStudio.LaunchProfilePersona
        "Update-NSLaunchProfileMember/Persona"
        {
            $v = "USER"
            break
        }

        # Amazon.NimbleStudio.SessionBackupMode
        {
            ($_ -eq "New-NSLaunchProfile/StreamConfiguration_SessionBackup_Mode") -Or
            ($_ -eq "Update-NSLaunchProfile/StreamConfiguration_SessionBackup_Mode")
        }
        {
            $v = "AUTOMATIC","DEACTIVATED"
            break
        }

        # Amazon.NimbleStudio.SessionPersistenceMode
        {
            ($_ -eq "New-NSLaunchProfile/StreamConfiguration_SessionPersistenceMode") -Or
            ($_ -eq "Update-NSLaunchProfile/StreamConfiguration_SessionPersistenceMode")
        }
        {
            $v = "ACTIVATED","DEACTIVATED"
            break
        }

        # Amazon.NimbleStudio.StreamingClipboardMode
        {
            ($_ -eq "New-NSLaunchProfile/StreamConfiguration_ClipboardMode") -Or
            ($_ -eq "Update-NSLaunchProfile/StreamConfiguration_ClipboardMode")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.NimbleStudio.StreamingInstanceType
        "New-NSStreamingSession/Ec2InstanceType"
        {
            $v = "g3.4xlarge","g3s.xlarge","g4dn.12xlarge","g4dn.16xlarge","g4dn.2xlarge","g4dn.4xlarge","g4dn.8xlarge","g4dn.xlarge","g5.16xlarge","g5.2xlarge","g5.4xlarge","g5.8xlarge","g5.xlarge"
            break
        }

        # Amazon.NimbleStudio.StudioComponentSubtype
        {
            ($_ -eq "New-NSStudioComponent/Subtype") -Or
            ($_ -eq "Update-NSStudioComponent/Subtype")
        }
        {
            $v = "AMAZON_FSX_FOR_LUSTRE","AMAZON_FSX_FOR_WINDOWS","AWS_MANAGED_MICROSOFT_AD","CUSTOM"
            break
        }

        # Amazon.NimbleStudio.StudioComponentType
        {
            ($_ -eq "New-NSStudioComponent/Type") -Or
            ($_ -eq "Update-NSStudioComponent/Type")
        }
        {
            $v = "ACTIVE_DIRECTORY","COMPUTE_FARM","CUSTOM","LICENSE_SERVICE","SHARED_FILE_SYSTEM"
            break
        }

        # Amazon.NimbleStudio.StudioEncryptionConfigurationKeyType
        "New-NSStudio/StudioEncryptionConfiguration_KeyType"
        {
            $v = "AWS_OWNED_KEY","CUSTOMER_MANAGED_KEY"
            break
        }

        # Amazon.NimbleStudio.VolumeRetentionMode
        "Stop-NSStreamingSession/VolumeRetentionMode"
        {
            $v = "DELETE","RETAIN"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$NS_map = @{
    "Ec2InstanceType"=@("New-NSStreamingSession")
    "Persona"=@("Update-NSLaunchProfileMember")
    "StreamConfiguration_AutomaticTerminationMode"=@("New-NSLaunchProfile","Update-NSLaunchProfile")
    "StreamConfiguration_ClipboardMode"=@("New-NSLaunchProfile","Update-NSLaunchProfile")
    "StreamConfiguration_SessionBackup_Mode"=@("New-NSLaunchProfile","Update-NSLaunchProfile")
    "StreamConfiguration_SessionPersistenceMode"=@("New-NSLaunchProfile","Update-NSLaunchProfile")
    "StudioEncryptionConfiguration_KeyType"=@("New-NSStudio")
    "Subtype"=@("New-NSStudioComponent","Update-NSStudioComponent")
    "Type"=@("New-NSStudioComponent","Update-NSStudioComponent")
    "VolumeRetentionMode"=@("Stop-NSStreamingSession")
}

_awsArgumentCompleterRegistration $NS_Completers $NS_map

$NS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.NS.$($commandName.Replace('-', ''))Cmdlet]"
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

$NS_SelectMap = @{
    "Select"=@("Approve-NSEula",
               "New-NSLaunchProfile",
               "New-NSStreamingImage",
               "New-NSStreamingSession",
               "New-NSStreamingSessionStream",
               "New-NSStudio",
               "New-NSStudioComponent",
               "Remove-NSLaunchProfile",
               "Remove-NSLaunchProfileMember",
               "Remove-NSStreamingImage",
               "Remove-NSStreamingSession",
               "Remove-NSStudio",
               "Remove-NSStudioComponent",
               "Remove-NSStudioMember",
               "Get-NSEula",
               "Get-NSLaunchProfile",
               "Get-NSLaunchProfileDetail",
               "Get-NSLaunchProfileInitialization",
               "Get-NSLaunchProfileMember",
               "Get-NSStreamingImage",
               "Get-NSStreamingSession",
               "Get-NSStreamingSessionBackup",
               "Get-NSStreamingSessionStream",
               "Get-NSStudio",
               "Get-NSStudioComponent",
               "Get-NSStudioMember",
               "Get-NSEulaAcceptanceList",
               "Get-NSEulaList",
               "Get-NSLaunchProfileMemberList",
               "Get-NSLaunchProfileList",
               "Get-NSStreamingImageList",
               "Get-NSStreamingSessionBackupList",
               "Get-NSStreamingSessionList",
               "Get-NSStudioComponentList",
               "Get-NSStudioMemberList",
               "Get-NSStudioList",
               "Get-NSResourceTag",
               "Write-NSLaunchProfileMember",
               "Write-NSStudioMember",
               "Start-NSStreamingSession",
               "Start-NSStudioSSOConfigurationRepair",
               "Stop-NSStreamingSession",
               "Add-NSResourceTag",
               "Remove-NSResourceTag",
               "Update-NSLaunchProfile",
               "Update-NSLaunchProfileMember",
               "Update-NSStreamingImage",
               "Update-NSStudio",
               "Update-NSStudioComponent")
}

_awsArgumentCompleterRegistration $NS_SelectCompleters $NS_SelectMap

