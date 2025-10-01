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

# Argument completions for service Amazon Chime SDK Meetings


$CHMTG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ChimeSDKMeetings.ContentResolution
        {
            ($_ -eq "New-CHMTGMeeting/Content_MaxResolution") -Or
            ($_ -eq "New-CHMTGMeetingWithAttendee/Content_MaxResolution")
        }
        {
            $v = "FHD","None","UHD"
            break
        }

        # Amazon.ChimeSDKMeetings.MediaCapabilities
        {
            ($_ -eq "New-CHMTGAttendee/Capabilities_Audio") -Or
            ($_ -eq "Update-CHMTGAttendeeCapability/Capabilities_Audio") -Or
            ($_ -eq "Update-CHMTGUpdateAttendeeCapabilitiesExcept/Capabilities_Audio") -Or
            ($_ -eq "New-CHMTGAttendee/Capabilities_Content") -Or
            ($_ -eq "Update-CHMTGAttendeeCapability/Capabilities_Content") -Or
            ($_ -eq "Update-CHMTGUpdateAttendeeCapabilitiesExcept/Capabilities_Content") -Or
            ($_ -eq "New-CHMTGAttendee/Capabilities_Video") -Or
            ($_ -eq "Update-CHMTGAttendeeCapability/Capabilities_Video") -Or
            ($_ -eq "Update-CHMTGUpdateAttendeeCapabilitiesExcept/Capabilities_Video")
        }
        {
            $v = "None","Receive","Send","SendReceive"
            break
        }

        # Amazon.ChimeSDKMeetings.MediaPlacementNetworkType
        {
            ($_ -eq "New-CHMTGMeeting/MediaPlacementNetworkType") -Or
            ($_ -eq "New-CHMTGMeetingWithAttendee/MediaPlacementNetworkType")
        }
        {
            $v = "DualStack","Ipv4Only"
            break
        }

        # Amazon.ChimeSDKMeetings.MeetingFeatureStatus
        {
            ($_ -eq "New-CHMTGMeeting/Audio_EchoReduction") -Or
            ($_ -eq "New-CHMTGMeetingWithAttendee/Audio_EchoReduction")
        }
        {
            $v = "AVAILABLE","UNAVAILABLE"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeContentIdentificationType
        "Start-CHMTGMeetingTranscription/EngineTranscribeSettings_ContentIdentificationType"
        {
            $v = "PII"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeContentRedactionType
        "Start-CHMTGMeetingTranscription/EngineTranscribeSettings_ContentRedactionType"
        {
            $v = "PII"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeLanguageCode
        {
            ($_ -eq "Start-CHMTGMeetingTranscription/EngineTranscribeSettings_LanguageCode") -Or
            ($_ -eq "Start-CHMTGMeetingTranscription/EngineTranscribeSettings_PreferredLanguage")
        }
        {
            $v = "de-DE","en-AU","en-GB","en-US","es-US","fr-CA","fr-FR","hi-IN","it-IT","ja-JP","ko-KR","pt-BR","th-TH","zh-CN"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeMedicalContentIdentificationType
        "Start-CHMTGMeetingTranscription/EngineTranscribeMedicalSettings_ContentIdentificationType"
        {
            $v = "PHI"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeMedicalLanguageCode
        "Start-CHMTGMeetingTranscription/EngineTranscribeMedicalSettings_LanguageCode"
        {
            $v = "en-US"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeMedicalRegion
        "Start-CHMTGMeetingTranscription/EngineTranscribeMedicalSettings_Region"
        {
            $v = "ap-southeast-2","auto","ca-central-1","eu-west-1","us-east-1","us-east-2","us-west-2"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeMedicalSpecialty
        "Start-CHMTGMeetingTranscription/EngineTranscribeMedicalSettings_Specialty"
        {
            $v = "CARDIOLOGY","NEUROLOGY","ONCOLOGY","PRIMARYCARE","RADIOLOGY","UROLOGY"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeMedicalType
        "Start-CHMTGMeetingTranscription/EngineTranscribeMedicalSettings_Type"
        {
            $v = "CONVERSATION","DICTATION"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribePartialResultsStability
        "Start-CHMTGMeetingTranscription/EngineTranscribeSettings_PartialResultsStability"
        {
            $v = "high","low","medium"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeRegion
        "Start-CHMTGMeetingTranscription/EngineTranscribeSettings_Region"
        {
            $v = "ap-northeast-1","ap-northeast-2","ap-southeast-2","auto","ca-central-1","eu-central-1","eu-west-1","eu-west-2","sa-east-1","us-east-1","us-east-2","us-gov-west-1","us-west-2"
            break
        }

        # Amazon.ChimeSDKMeetings.TranscribeVocabularyFilterMethod
        "Start-CHMTGMeetingTranscription/EngineTranscribeSettings_VocabularyFilterMethod"
        {
            $v = "mask","remove","tag"
            break
        }

        # Amazon.ChimeSDKMeetings.VideoResolution
        {
            ($_ -eq "New-CHMTGMeeting/Video_MaxResolution") -Or
            ($_ -eq "New-CHMTGMeetingWithAttendee/Video_MaxResolution")
        }
        {
            $v = "FHD","HD","None"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CHMTG_map = @{
    "Audio_EchoReduction"=@("New-CHMTGMeeting","New-CHMTGMeetingWithAttendee")
    "Capabilities_Audio"=@("New-CHMTGAttendee","Update-CHMTGAttendeeCapability","Update-CHMTGUpdateAttendeeCapabilitiesExcept")
    "Capabilities_Content"=@("New-CHMTGAttendee","Update-CHMTGAttendeeCapability","Update-CHMTGUpdateAttendeeCapabilitiesExcept")
    "Capabilities_Video"=@("New-CHMTGAttendee","Update-CHMTGAttendeeCapability","Update-CHMTGUpdateAttendeeCapabilitiesExcept")
    "Content_MaxResolution"=@("New-CHMTGMeeting","New-CHMTGMeetingWithAttendee")
    "EngineTranscribeMedicalSettings_ContentIdentificationType"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeMedicalSettings_LanguageCode"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeMedicalSettings_Region"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeMedicalSettings_Specialty"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeMedicalSettings_Type"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeSettings_ContentIdentificationType"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeSettings_ContentRedactionType"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeSettings_LanguageCode"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeSettings_PartialResultsStability"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeSettings_PreferredLanguage"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeSettings_Region"=@("Start-CHMTGMeetingTranscription")
    "EngineTranscribeSettings_VocabularyFilterMethod"=@("Start-CHMTGMeetingTranscription")
    "MediaPlacementNetworkType"=@("New-CHMTGMeeting","New-CHMTGMeetingWithAttendee")
    "Video_MaxResolution"=@("New-CHMTGMeeting","New-CHMTGMeetingWithAttendee")
}

_awsArgumentCompleterRegistration $CHMTG_Completers $CHMTG_map

$CHMTG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CHMTG.$($commandName.Replace('-', ''))Cmdlet]"
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

$CHMTG_SelectMap = @{
    "Select"=@("New-CHMTGAttendeeBatch",
               "Update-CHMTGUpdateAttendeeCapabilitiesExcept",
               "New-CHMTGAttendee",
               "New-CHMTGMeeting",
               "New-CHMTGMeetingWithAttendee",
               "Remove-CHMTGAttendee",
               "Remove-CHMTGMeeting",
               "Get-CHMTGAttendee",
               "Get-CHMTGMeeting",
               "Get-CHMTGAttendeeList",
               "Get-CHMTGResourceTag",
               "Start-CHMTGMeetingTranscription",
               "Stop-CHMTGMeetingTranscription",
               "Add-CHMTGResourceTag",
               "Remove-CHMTGResourceTag",
               "Update-CHMTGAttendeeCapability")
}

_awsArgumentCompleterRegistration $CHMTG_SelectCompleters $CHMTG_SelectMap

