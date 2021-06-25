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

# Argument completions for service Amazon Voice ID


$VID_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.VoiceID.DuplicateRegistrationAction
        "Start-VIDFraudsterRegistrationJob/RegistrationConfig_DuplicateRegistrationAction"
        {
            $v = "REGISTER_AS_NEW","SKIP"
            break
        }

        # Amazon.VoiceID.ExistingEnrollmentAction
        "Start-VIDSpeakerEnrollmentJob/EnrollmentConfig_ExistingEnrollmentAction"
        {
            $v = "OVERWRITE","SKIP"
            break
        }

        # Amazon.VoiceID.FraudDetectionAction
        "Start-VIDSpeakerEnrollmentJob/EnrollmentConfig_FraudDetectionConfig_FraudDetectionAction"
        {
            $v = "FAIL","IGNORE"
            break
        }

        # Amazon.VoiceID.FraudsterRegistrationJobStatus
        "Get-VIDFraudsterRegistrationJobList/JobStatus"
        {
            $v = "COMPLETED","COMPLETED_WITH_ERRORS","FAILED","IN_PROGRESS","SUBMITTED"
            break
        }

        # Amazon.VoiceID.SpeakerEnrollmentJobStatus
        "Get-VIDSpeakerEnrollmentJobList/JobStatus"
        {
            $v = "COMPLETED","COMPLETED_WITH_ERRORS","FAILED","IN_PROGRESS","SUBMITTED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$VID_map = @{
    "EnrollmentConfig_ExistingEnrollmentAction"=@("Start-VIDSpeakerEnrollmentJob")
    "EnrollmentConfig_FraudDetectionConfig_FraudDetectionAction"=@("Start-VIDSpeakerEnrollmentJob")
    "JobStatus"=@("Get-VIDFraudsterRegistrationJobList","Get-VIDSpeakerEnrollmentJobList")
    "RegistrationConfig_DuplicateRegistrationAction"=@("Start-VIDFraudsterRegistrationJob")
}

_awsArgumentCompleterRegistration $VID_Completers $VID_map

$VID_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.VID.$($commandName.Replace('-', ''))Cmdlet]"
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

$VID_SelectMap = @{
    "Select"=@("New-VIDDomain",
               "Remove-VIDDomain",
               "Remove-VIDFraudster",
               "Remove-VIDSpeaker",
               "Get-VIDDomain",
               "Get-VIDFraudster",
               "Get-VIDFraudsterRegistrationJob",
               "Get-VIDSpeaker",
               "Get-VIDSpeakerEnrollmentJob",
               "Get-VIDSessionEvaluation",
               "Get-VIDDomainList",
               "Get-VIDFraudsterRegistrationJobList",
               "Get-VIDSpeakerEnrollmentJobList",
               "Get-VIDSpeakerList",
               "Get-VIDResourceTag",
               "Set-VIDOptOutSpeaker",
               "Start-VIDFraudsterRegistrationJob",
               "Start-VIDSpeakerEnrollmentJob",
               "Add-VIDResourceTag",
               "Remove-VIDResourceTag",
               "Edit-VIDDomain")
}

_awsArgumentCompleterRegistration $VID_SelectCompleters $VID_SelectMap

