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

# Argument completions for service AWS Elastic Beanstalk


$EB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticBeanstalk.ActionStatus
        "Get-EBEnvironmentManagedAction/Status"
        {
            $v = "Pending","Running","Scheduled","Unknown"
            break
        }

        # Amazon.ElasticBeanstalk.ComputeType
        "New-EBApplicationVersion/BuildConfiguration_ComputeType"
        {
            $v = "BUILD_GENERAL1_LARGE","BUILD_GENERAL1_MEDIUM","BUILD_GENERAL1_SMALL"
            break
        }

        # Amazon.ElasticBeanstalk.EnvironmentInfoType
        {
            ($_ -eq "Get-EBEnvironmentInfo/InfoType") -Or
            ($_ -eq "Request-EBEnvironmentInfo/InfoType")
        }
        {
            $v = "bundle","tail"
            break
        }

        # Amazon.ElasticBeanstalk.EventSeverity
        "Get-EBEvent/Severity"
        {
            $v = "DEBUG","ERROR","FATAL","INFO","TRACE","WARN"
            break
        }

        # Amazon.ElasticBeanstalk.SourceRepository
        "New-EBApplicationVersion/SourceBuildInformation_SourceRepository"
        {
            $v = "CodeCommit","S3"
            break
        }

        # Amazon.ElasticBeanstalk.SourceType
        "New-EBApplicationVersion/SourceBuildInformation_SourceType"
        {
            $v = "Git","Zip"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EB_map = @{
    "BuildConfiguration_ComputeType"=@("New-EBApplicationVersion")
    "InfoType"=@("Get-EBEnvironmentInfo","Request-EBEnvironmentInfo")
    "Severity"=@("Get-EBEvent")
    "SourceBuildInformation_SourceRepository"=@("New-EBApplicationVersion")
    "SourceBuildInformation_SourceType"=@("New-EBApplicationVersion")
    "Status"=@("Get-EBEnvironmentManagedAction")
}

_awsArgumentCompleterRegistration $EB_Completers $EB_map

$EB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EB.$($commandName.Replace('-', ''))Cmdlet]"
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

$EB_SelectMap = @{
    "Select"=@("Stop-EBEnvironmentUpdate",
               "Submit-EBEnvironmentManagedAction",
               "Register-EBEnvironmentOperationsRole",
               "Get-EBDNSAvailability",
               "Group-EBEnvironment",
               "New-EBApplication",
               "New-EBApplicationVersion",
               "New-EBConfigurationTemplate",
               "New-EBEnvironment",
               "New-EBPlatformVersion",
               "New-EBStorageLocation",
               "Remove-EBApplication",
               "Remove-EBApplicationVersion",
               "Remove-EBConfigurationTemplate",
               "Remove-EBEnvironmentConfiguration",
               "Remove-EBPlatformVersion",
               "Get-EBAccountAttribute",
               "Get-EBApplication",
               "Get-EBApplicationVersion",
               "Get-EBConfigurationOption",
               "Get-EBConfigurationSetting",
               "Get-EBEnvironmentHealth",
               "Get-EBEnvironmentManagedActionHistory",
               "Get-EBEnvironmentManagedAction",
               "Get-EBEnvironmentResource",
               "Get-EBEnvironment",
               "Get-EBEvent",
               "Get-EBInstanceHealth",
               "Get-EBPlatformVersionDetail",
               "Unregister-EBEnvironmentOperationsRole",
               "Get-EBAvailableSolutionStackList",
               "Get-EBPlatformBranch",
               "Get-EBPlatformVersion",
               "Get-EBResourceTag",
               "Start-EBEnvironmentRebuild",
               "Request-EBEnvironmentInfo",
               "Restart-EBAppServer",
               "Get-EBEnvironmentInfo",
               "Set-EBEnvironmentCNAME",
               "Stop-EBEnvironment",
               "Update-EBApplication",
               "Update-EBApplicationResourceLifecycle",
               "Update-EBApplicationVersion",
               "Update-EBConfigurationTemplate",
               "Update-EBEnvironment",
               "Update-EBResourceTag",
               "Test-EBConfigurationSetting")
}

_awsArgumentCompleterRegistration $EB_SelectCompleters $EB_SelectMap

