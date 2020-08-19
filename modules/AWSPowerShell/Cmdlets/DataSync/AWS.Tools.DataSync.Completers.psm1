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

# Argument completions for service AWS DataSync


$DSYN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DataSync.NfsVersion
        "New-DSYNLocationNfs/MountOptions_Version"
        {
            $v = "AUTOMATIC","NFS3","NFS4_0","NFS4_1"
            break
        }

        # Amazon.DataSync.ObjectStorageServerProtocol
        "New-DSYNLocationObjectStorage/ServerProtocol"
        {
            $v = "HTTP","HTTPS"
            break
        }

        # Amazon.DataSync.S3StorageClass
        "New-DSYNLocationS3/S3StorageClass"
        {
            $v = "DEEP_ARCHIVE","GLACIER","INTELLIGENT_TIERING","ONEZONE_IA","OUTPOSTS","STANDARD","STANDARD_IA"
            break
        }

        # Amazon.DataSync.SmbVersion
        "New-DSYNLocationSmb/MountOptions_Version"
        {
            $v = "AUTOMATIC","SMB2","SMB3"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DSYN_map = @{
    "MountOptions_Version"=@("New-DSYNLocationNfs","New-DSYNLocationSmb")
    "S3StorageClass"=@("New-DSYNLocationS3")
    "ServerProtocol"=@("New-DSYNLocationObjectStorage")
}

_awsArgumentCompleterRegistration $DSYN_Completers $DSYN_map

$DSYN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DSYN.$($commandName.Replace('-', ''))Cmdlet]"
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

$DSYN_SelectMap = @{
    "Select"=@("Stop-DSYNTaskExecution",
               "New-DSYNAgent",
               "New-DSYNLocationEfs",
               "New-DSYNLocationFsxWindow",
               "New-DSYNLocationNfs",
               "New-DSYNLocationObjectStorage",
               "New-DSYNLocationS3",
               "New-DSYNLocationSmb",
               "New-DSYNTask",
               "Remove-DSYNAgent",
               "Remove-DSYNLocation",
               "Remove-DSYNTask",
               "Get-DSYNAgent",
               "Get-DSYNLocationEfs",
               "Get-DSYNLocationFsxWindow",
               "Get-DSYNLocationNfs",
               "Get-DSYNLocationObjectStorage",
               "Get-DSYNLocationS3",
               "Get-DSYNLocationSmb",
               "Get-DSYNTask",
               "Get-DSYNTaskExecution",
               "Get-DSYNAgentList",
               "Get-DSYNLocationList",
               "Get-DSYNResourceTagList",
               "Get-DSYNTaskExecutionList",
               "Get-DSYNTaskList",
               "Start-DSYNTaskExecution",
               "Add-DSYNResourceTag",
               "Remove-DSYNResourceTag",
               "Update-DSYNAgent",
               "Update-DSYNTask")
}

_awsArgumentCompleterRegistration $DSYN_SelectCompleters $DSYN_SelectMap

