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

# Argument completions for service AWS Amplify


$AMP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Amplify.ArtifactType
        "Get-AMPArtifactList/ArtifactType"
        {
            $v = "TEST"
            break
        }

        # Amazon.Amplify.JobType
        "Start-AMPJob/JobType"
        {
            $v = "MANUAL","RELEASE","RETRY","WEB_HOOK"
            break
        }

        # Amazon.Amplify.Platform
        {
            ($_ -eq "New-AMPApp/Platform") -Or
            ($_ -eq "Update-AMPApp/Platform")
        }
        {
            $v = "WEB"
            break
        }

        # Amazon.Amplify.Stage
        {
            ($_ -eq "New-AMPApp/AutoBranchCreationConfig_Stage") -Or
            ($_ -eq "Update-AMPApp/AutoBranchCreationConfig_Stage") -Or
            ($_ -eq "New-AMPBranch/Stage") -Or
            ($_ -eq "Update-AMPBranch/Stage")
        }
        {
            $v = "BETA","DEVELOPMENT","EXPERIMENTAL","PRODUCTION","PULL_REQUEST"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AMP_map = @{
    "ArtifactType"=@("Get-AMPArtifactList")
    "AutoBranchCreationConfig_Stage"=@("New-AMPApp","Update-AMPApp")
    "JobType"=@("Start-AMPJob")
    "Platform"=@("New-AMPApp","Update-AMPApp")
    "Stage"=@("New-AMPBranch","Update-AMPBranch")
}

_awsArgumentCompleterRegistration $AMP_Completers $AMP_map

$AMP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AMP.$($commandName.Replace('-', ''))Cmdlet]"
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

$AMP_SelectMap = @{
    "Select"=@("New-AMPApp",
               "New-AMPBranch",
               "New-AMPDeployment",
               "New-AMPDomainAssociation",
               "New-AMPWebhook",
               "Remove-AMPApp",
               "Remove-AMPBranch",
               "Remove-AMPDomainAssociation",
               "Remove-AMPJob",
               "Remove-AMPWebhook",
               "New-AMPAccessLog",
               "Get-AMPApp",
               "Get-AMPArtifactUrl",
               "Get-AMPBranch",
               "Get-AMPDomainAssociation",
               "Get-AMPJob",
               "Get-AMPWebhook",
               "Get-AMPAppList",
               "Get-AMPArtifactList",
               "Get-AMPBranchList",
               "Get-AMPDomainAssociationList",
               "Get-AMPJobList",
               "Get-AMPResourceTag",
               "Get-AMPWebhookList",
               "Start-AMPDeployment",
               "Start-AMPJob",
               "Stop-AMPJob",
               "Add-AMPResourceTag",
               "Remove-AMPResourceTag",
               "Update-AMPApp",
               "Update-AMPBranch",
               "Update-AMPDomainAssociation",
               "Update-AMPWebhook")
}

_awsArgumentCompleterRegistration $AMP_SelectCompleters $AMP_SelectMap

