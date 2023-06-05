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

# Argument completions for service FinSpace User Environment Management Service


$FINSP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Finspace.AutoScalingMetric
        "New-FINSPKxCluster/AutoScalingConfiguration_AutoScalingMetric"
        {
            $v = "CPU_UTILIZATION_PERCENTAGE"
            break
        }

        # Amazon.Finspace.FederationMode
        {
            ($_ -eq "New-FINSPEnvironment/FederationMode") -Or
            ($_ -eq "Update-FINSPEnvironment/FederationMode")
        }
        {
            $v = "FEDERATED","LOCAL"
            break
        }

        # Amazon.Finspace.IPAddressType
        "New-FINSPKxCluster/VpcConfiguration_IpAddressType"
        {
            $v = "IP_V4"
            break
        }

        # Amazon.Finspace.KxAzMode
        "New-FINSPKxCluster/AzMode"
        {
            $v = "MULTI","SINGLE"
            break
        }

        # Amazon.Finspace.KxClusterType
        {
            ($_ -eq "Get-FINSPKxClusterList/ClusterType") -Or
            ($_ -eq "New-FINSPKxCluster/ClusterType")
        }
        {
            $v = "GATEWAY","HDB","RDB"
            break
        }

        # Amazon.Finspace.KxSavedownStorageType
        "New-FINSPKxCluster/SavedownStorageConfiguration_Type"
        {
            $v = "SDS01"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$FINSP_map = @{
    "AutoScalingConfiguration_AutoScalingMetric"=@("New-FINSPKxCluster")
    "AzMode"=@("New-FINSPKxCluster")
    "ClusterType"=@("Get-FINSPKxClusterList","New-FINSPKxCluster")
    "FederationMode"=@("New-FINSPEnvironment","Update-FINSPEnvironment")
    "SavedownStorageConfiguration_Type"=@("New-FINSPKxCluster")
    "VpcConfiguration_IpAddressType"=@("New-FINSPKxCluster")
}

_awsArgumentCompleterRegistration $FINSP_Completers $FINSP_map

$FINSP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.FINSP.$($commandName.Replace('-', ''))Cmdlet]"
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

$FINSP_SelectMap = @{
    "Select"=@("New-FINSPEnvironment",
               "New-FINSPKxChangeset",
               "New-FINSPKxCluster",
               "New-FINSPKxDatabase",
               "New-FINSPKxEnvironment",
               "New-FINSPKxUser",
               "Remove-FINSPEnvironment",
               "Remove-FINSPKxCluster",
               "Remove-FINSPKxDatabase",
               "Remove-FINSPKxEnvironment",
               "Remove-FINSPKxUser",
               "Get-FINSPEnvironment",
               "Get-FINSPKxChangeset",
               "Get-FINSPKxCluster",
               "Get-FINSPKxConnectionString",
               "Get-FINSPKxDatabase",
               "Get-FINSPKxEnvironment",
               "Get-FINSPKxUser",
               "Get-FINSPEnvironmentList",
               "Get-FINSPKxChangesetList",
               "Get-FINSPKxClusterNodeList",
               "Get-FINSPKxClusterList",
               "Get-FINSPKxDatabasisList",
               "Get-FINSPKxEnvironmentList",
               "Get-FINSPKxUserList",
               "Get-FINSPResourceTag",
               "Add-FINSPResourceTag",
               "Remove-FINSPResourceTag",
               "Update-FINSPEnvironment",
               "Update-FINSPKxClusterDatabasis",
               "Update-FINSPKxDatabase",
               "Update-FINSPKxEnvironment",
               "Update-FINSPKxEnvironmentNetwork",
               "Update-FINSPKxUser")
}

_awsArgumentCompleterRegistration $FINSP_SelectCompleters $FINSP_SelectMap

