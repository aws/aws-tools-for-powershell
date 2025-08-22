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

# Argument completions for service Amazon CloudWatch Synthetics


$CWSYN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Synthetics.BrowserType
        {
            ($_ -eq "Get-CWSYNCanariesLastRun/BrowserType") -Or
            ($_ -eq "Start-CWSYNCanaryDryRun/VisualReference_BrowserType") -Or
            ($_ -eq "Update-CWSYNCanary/VisualReference_BrowserType")
        }
        {
            $v = "CHROME","FIREFOX"
            break
        }

        # Amazon.Synthetics.EncryptionMode
        {
            ($_ -eq "New-CWSYNCanary/S3Encryption_EncryptionMode") -Or
            ($_ -eq "Start-CWSYNCanaryDryRun/S3Encryption_EncryptionMode") -Or
            ($_ -eq "Update-CWSYNCanary/S3Encryption_EncryptionMode")
        }
        {
            $v = "SSE_KMS","SSE_S3"
            break
        }

        # Amazon.Synthetics.ProvisionedResourceCleanupSetting
        {
            ($_ -eq "New-CWSYNCanary/ProvisionedResourceCleanup") -Or
            ($_ -eq "Start-CWSYNCanaryDryRun/ProvisionedResourceCleanup") -Or
            ($_ -eq "Update-CWSYNCanary/ProvisionedResourceCleanup")
        }
        {
            $v = "AUTOMATIC","OFF"
            break
        }

        # Amazon.Synthetics.RunType
        "Get-CWSYNCanaryRun/RunType"
        {
            $v = "CANARY_RUN","DRY_RUN"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CWSYN_map = @{
    "BrowserType"=@("Get-CWSYNCanariesLastRun")
    "ProvisionedResourceCleanup"=@("New-CWSYNCanary","Start-CWSYNCanaryDryRun","Update-CWSYNCanary")
    "RunType"=@("Get-CWSYNCanaryRun")
    "S3Encryption_EncryptionMode"=@("New-CWSYNCanary","Start-CWSYNCanaryDryRun","Update-CWSYNCanary")
    "VisualReference_BrowserType"=@("Start-CWSYNCanaryDryRun","Update-CWSYNCanary")
}

_awsArgumentCompleterRegistration $CWSYN_Completers $CWSYN_map

$CWSYN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CWSYN.$($commandName.Replace('-', ''))Cmdlet]"
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

$CWSYN_SelectMap = @{
    "Select"=@("Add-CWSYNResource",
               "New-CWSYNCanary",
               "New-CWSYNGroup",
               "Remove-CWSYNCanary",
               "Remove-CWSYNGroup",
               "Get-CWSYNCanaryList",
               "Get-CWSYNCanariesLastRun",
               "Get-CWSYNRuntimeVersion",
               "Remove-CWSYNResource",
               "Get-CWSYNCanary",
               "Get-CWSYNCanaryRun",
               "Get-CWSYNGroup",
               "Get-CWSYNAssociatedGroupList",
               "Get-CWSYNGroupResourceList",
               "Get-CWSYNGroupList",
               "Get-CWSYNResourceTag",
               "Start-CWSYNCanary",
               "Start-CWSYNCanaryDryRun",
               "Stop-CWSYNCanary",
               "Add-CWSYNResourceTag",
               "Remove-CWSYNResourceTag",
               "Update-CWSYNCanary")
}

_awsArgumentCompleterRegistration $CWSYN_SelectCompleters $CWSYN_SelectMap

