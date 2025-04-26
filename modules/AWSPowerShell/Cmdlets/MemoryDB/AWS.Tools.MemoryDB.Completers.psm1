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

# Argument completions for service Amazon MemoryDB


$MDB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MemoryDB.InputAuthenticationType
        {
            ($_ -eq "New-MDBUser/AuthenticationMode_Type") -Or
            ($_ -eq "Update-MDBUser/AuthenticationMode_Type")
        }
        {
            $v = "iam","password"
            break
        }

        # Amazon.MemoryDB.IpDiscovery
        {
            ($_ -eq "New-MDBCluster/IpDiscovery") -Or
            ($_ -eq "Update-MDBCluster/IpDiscovery")
        }
        {
            $v = "ipv4","ipv6"
            break
        }

        # Amazon.MemoryDB.NetworkType
        "New-MDBCluster/NetworkType"
        {
            $v = "dual_stack","ipv4","ipv6"
            break
        }

        # Amazon.MemoryDB.SourceType
        "Get-MDBEvent/SourceType"
        {
            $v = "acl","cluster","node","parameter-group","subnet-group","user"
            break
        }

        # Amazon.MemoryDB.UpdateStrategy
        "Update-MDBMultiRegionCluster/UpdateStrategy"
        {
            $v = "coordinated","uncoordinated"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MDB_map = @{
    "AuthenticationMode_Type"=@("New-MDBUser","Update-MDBUser")
    "IpDiscovery"=@("New-MDBCluster","Update-MDBCluster")
    "NetworkType"=@("New-MDBCluster")
    "SourceType"=@("Get-MDBEvent")
    "UpdateStrategy"=@("Update-MDBMultiRegionCluster")
}

_awsArgumentCompleterRegistration $MDB_Completers $MDB_map

$MDB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MDB.$($commandName.Replace('-', ''))Cmdlet]"
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

$MDB_SelectMap = @{
    "Select"=@("Update-MDBUpdateClusterBatch",
               "Copy-MDBSnapshot",
               "New-MDBACL",
               "New-MDBCluster",
               "New-MDBMultiRegionCluster",
               "New-MDBParameterGroup",
               "New-MDBSnapshot",
               "New-MDBSubnetGroup",
               "New-MDBUser",
               "Remove-MDBACL",
               "Remove-MDBCluster",
               "Remove-MDBMultiRegionCluster",
               "Remove-MDBParameterGroup",
               "Remove-MDBSnapshot",
               "Remove-MDBSubnetGroup",
               "Remove-MDBUser",
               "Get-MDBACLs",
               "Get-MDBCluster",
               "Get-MDBEngineVersion",
               "Get-MDBEvent",
               "Get-MDBMultiRegionCluster",
               "Get-MDBParameterGroup",
               "Get-MDBParameter",
               "Get-MDBReservedNode",
               "Get-MDBReservedNodesOffering",
               "Get-MDBServiceUpdate",
               "Get-MDBSnapshot",
               "Get-MDBSubnetGroup",
               "Get-MDBUser",
               "Start-MDBFailoverShard",
               "Get-MDBAllowedMultiRegionClusterUpdateList",
               "Get-MDBAllowedNodeTypeUpdateList",
               "Get-MDBTag",
               "Request-MDBReservedNodesOffering",
               "Reset-MDBParameterGroup",
               "Add-MDBResourceTag",
               "Remove-MDBResourceTag",
               "Update-MDBACL",
               "Update-MDBCluster",
               "Update-MDBMultiRegionCluster",
               "Update-MDBParameterGroup",
               "Update-MDBSubnetGroup",
               "Update-MDBUser")
}

_awsArgumentCompleterRegistration $MDB_SelectCompleters $MDB_SelectMap

