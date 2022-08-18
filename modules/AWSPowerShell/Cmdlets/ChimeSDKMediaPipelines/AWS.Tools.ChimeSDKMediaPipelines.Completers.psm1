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

# Argument completions for service Amazon Chime SDK Media Pipelines


$CHMMP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ChimeSDKMediaPipelines.ArtifactsState
        {
            ($_ -eq "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_State") -Or
            ($_ -eq "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_State")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.AudioMuxType
        "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio_MuxType"
        {
            $v = "AudioOnly","AudioWithActiveSpeakerVideo","AudioWithCompositedVideo"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.ContentMuxType
        "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_MuxType"
        {
            $v = "ContentOnly"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.ContentShareLayoutOption
        "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_GridViewConfiguration_ContentShareLayout"
        {
            $v = "Horizontal","PresenterOnly","Vertical"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.LayoutOption
        "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_Layout"
        {
            $v = "GridView"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.MediaPipelineSinkType
        "New-CHMMPMediaCapturePipeline/SinkType"
        {
            $v = "S3Bucket"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.MediaPipelineSourceType
        "New-CHMMPMediaCapturePipeline/SourceType"
        {
            $v = "ChimeSdkMeeting"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.PresenterPosition
        "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_GridViewConfiguration_PresenterOnlyConfiguration_PresenterPosition"
        {
            $v = "BottomLeft","BottomRight","TopLeft","TopRight"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.ResolutionOption
        "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_Resolution"
        {
            $v = "FHD","HD"
            break
        }

        # Amazon.ChimeSDKMediaPipelines.VideoMuxType
        "New-CHMMPMediaCapturePipeline/ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_MuxType"
        {
            $v = "VideoOnly"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CHMMP_map = @{
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Audio_MuxType"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_GridViewConfiguration_ContentShareLayout"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_GridViewConfiguration_PresenterOnlyConfiguration_PresenterPosition"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_Layout"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_CompositedVideo_Resolution"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_MuxType"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Content_State"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_MuxType"=@("New-CHMMPMediaCapturePipeline")
    "ChimeSdkMeetingConfiguration_ArtifactsConfiguration_Video_State"=@("New-CHMMPMediaCapturePipeline")
    "SinkType"=@("New-CHMMPMediaCapturePipeline")
    "SourceType"=@("New-CHMMPMediaCapturePipeline")
}

_awsArgumentCompleterRegistration $CHMMP_Completers $CHMMP_map

$CHMMP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CHMMP.$($commandName.Replace('-', ''))Cmdlet]"
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

$CHMMP_SelectMap = @{
    "Select"=@("New-CHMMPMediaCapturePipeline",
               "New-CHMMPMediaConcatenationPipeline",
               "New-CHMMPMediaLiveConnectorPipeline",
               "Remove-CHMMPMediaCapturePipeline",
               "Remove-CHMMPMediaPipeline",
               "Get-CHMMPMediaCapturePipeline",
               "Get-CHMMPMediaPipeline",
               "Get-CHMMPMediaCapturePipelineList",
               "Get-CHMMPMediaPipelineList",
               "Get-CHMMPResourceTag",
               "Add-CHMMPResourceTag",
               "Remove-CHMMPResourceTag")
}

_awsArgumentCompleterRegistration $CHMMP_SelectCompleters $CHMMP_SelectMap

