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

# Argument completions for service Partner Central Channel API


$PCC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.PartnerCentralChannel.AssociationType
        "New-PCCRelationship/AssociationType"
        {
            $v = "DOWNSTREAM_SELLER","END_CUSTOMER","INTERNAL"
            break
        }

        # Amazon.PartnerCentralChannel.Coverage
        {
            ($_ -eq "New-PCCRelationship/PartnerLedSupport_Coverage") -Or
            ($_ -eq "Update-PCCRelationship/PartnerLedSupport_Coverage") -Or
            ($_ -eq "New-PCCRelationship/ResoldBusiness_Coverage") -Or
            ($_ -eq "Update-PCCRelationship/ResoldBusiness_Coverage") -Or
            ($_ -eq "New-PCCRelationship/ResoldEnterprise_Coverage") -Or
            ($_ -eq "Update-PCCRelationship/ResoldEnterprise_Coverage")
        }
        {
            $v = "ENTIRE_ORGANIZATION","MANAGEMENT_ACCOUNT_ONLY"
            break
        }

        # Amazon.PartnerCentralChannel.HandshakeType
        {
            ($_ -eq "Get-PCCChannelHandshakeList/HandshakeType") -Or
            ($_ -eq "New-PCCChannelHandshake/HandshakeType")
        }
        {
            $v = "PROGRAM_MANAGEMENT_ACCOUNT","REVOKE_SERVICE_PERIOD","START_SERVICE_PERIOD"
            break
        }

        # Amazon.PartnerCentralChannel.ListProgramManagementAccountsSortName
        "Get-PCCProgramManagementAccountList/Sort_SortBy"
        {
            $v = "UpdatedAt"
            break
        }

        # Amazon.PartnerCentralChannel.ListRelationshipsSortName
        "Get-PCCRelationshipList/Sort_SortBy"
        {
            $v = "UpdatedAt"
            break
        }

        # Amazon.PartnerCentralChannel.ParticipantType
        "Get-PCCChannelHandshakeList/ParticipantType"
        {
            $v = "RECEIVER","SENDER"
            break
        }

        # Amazon.PartnerCentralChannel.Program
        "New-PCCProgramManagementAccount/Program"
        {
            $v = "DISTRIBUTION","DISTRIBUTION_SELLER","SOLUTION_PROVIDER"
            break
        }

        # Amazon.PartnerCentralChannel.ProgramManagementAccountTypeSortName
        "Get-PCCChannelHandshakeList/ProgramManagementAccountTypeSort_SortBy"
        {
            $v = "UpdatedAt"
            break
        }

        # Amazon.PartnerCentralChannel.Provider
        {
            ($_ -eq "New-PCCRelationship/PartnerLedSupport_Provider") -Or
            ($_ -eq "Update-PCCRelationship/PartnerLedSupport_Provider")
        }
        {
            $v = "DISTRIBUTION_SELLER","DISTRIBUTOR"
            break
        }

        # Amazon.PartnerCentralChannel.ResaleAccountModel
        "New-PCCRelationship/ResaleAccountModel"
        {
            $v = "DISTRIBUTOR","END_CUSTOMER","SOLUTION_PROVIDER"
            break
        }

        # Amazon.PartnerCentralChannel.RevokeServicePeriodTypeSortName
        "Get-PCCChannelHandshakeList/RevokeServicePeriodTypeSort_SortBy"
        {
            $v = "UpdatedAt"
            break
        }

        # Amazon.PartnerCentralChannel.Sector
        "New-PCCRelationship/Sector"
        {
            $v = "COMMERCIAL","GOVERNMENT","GOVERNMENT_EXCEPTION"
            break
        }

        # Amazon.PartnerCentralChannel.ServicePeriodType
        "New-PCCChannelHandshake/StartServicePeriodPayload_ServicePeriodType"
        {
            $v = "FIXED_COMMITMENT_PERIOD","MINIMUM_NOTICE_PERIOD"
            break
        }

        # Amazon.PartnerCentralChannel.SortOrder
        {
            ($_ -eq "Get-PCCChannelHandshakeList/ProgramManagementAccountTypeSort_SortOrder") -Or
            ($_ -eq "Get-PCCChannelHandshakeList/RevokeServicePeriodTypeSort_SortOrder") -Or
            ($_ -eq "Get-PCCProgramManagementAccountList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCCRelationshipList/Sort_SortOrder") -Or
            ($_ -eq "Get-PCCChannelHandshakeList/StartServicePeriodTypeSort_SortOrder")
        }
        {
            $v = "Ascending","Descending"
            break
        }

        # Amazon.PartnerCentralChannel.StartServicePeriodTypeSortName
        "Get-PCCChannelHandshakeList/StartServicePeriodTypeSort_SortBy"
        {
            $v = "UpdatedAt"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PCC_map = @{
    "AssociationType"=@("New-PCCRelationship")
    "HandshakeType"=@("Get-PCCChannelHandshakeList","New-PCCChannelHandshake")
    "ParticipantType"=@("Get-PCCChannelHandshakeList")
    "PartnerLedSupport_Coverage"=@("New-PCCRelationship","Update-PCCRelationship")
    "PartnerLedSupport_Provider"=@("New-PCCRelationship","Update-PCCRelationship")
    "Program"=@("New-PCCProgramManagementAccount")
    "ProgramManagementAccountTypeSort_SortBy"=@("Get-PCCChannelHandshakeList")
    "ProgramManagementAccountTypeSort_SortOrder"=@("Get-PCCChannelHandshakeList")
    "ResaleAccountModel"=@("New-PCCRelationship")
    "ResoldBusiness_Coverage"=@("New-PCCRelationship","Update-PCCRelationship")
    "ResoldEnterprise_Coverage"=@("New-PCCRelationship","Update-PCCRelationship")
    "RevokeServicePeriodTypeSort_SortBy"=@("Get-PCCChannelHandshakeList")
    "RevokeServicePeriodTypeSort_SortOrder"=@("Get-PCCChannelHandshakeList")
    "Sector"=@("New-PCCRelationship")
    "Sort_SortBy"=@("Get-PCCProgramManagementAccountList","Get-PCCRelationshipList")
    "Sort_SortOrder"=@("Get-PCCProgramManagementAccountList","Get-PCCRelationshipList")
    "StartServicePeriodPayload_ServicePeriodType"=@("New-PCCChannelHandshake")
    "StartServicePeriodTypeSort_SortBy"=@("Get-PCCChannelHandshakeList")
    "StartServicePeriodTypeSort_SortOrder"=@("Get-PCCChannelHandshakeList")
}

_awsArgumentCompleterRegistration $PCC_Completers $PCC_map

$PCC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PCC.$($commandName.Replace('-', ''))Cmdlet]"
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

$PCC_SelectMap = @{
    "Select"=@("Approve-PCCChannelHandshake",
               "Stop-PCCChannelHandshake",
               "New-PCCChannelHandshake",
               "New-PCCProgramManagementAccount",
               "New-PCCRelationship",
               "Remove-PCCProgramManagementAccount",
               "Remove-PCCRelationship",
               "Get-PCCRelationship",
               "Get-PCCChannelHandshakeList",
               "Get-PCCProgramManagementAccountList",
               "Get-PCCRelationshipList",
               "Get-PCCResourceTag",
               "Deny-PCCChannelHandshake",
               "Add-PCCResourceTag",
               "Remove-PCCResourceTag",
               "Update-PCCProgramManagementAccount",
               "Update-PCCRelationship")
}

_awsArgumentCompleterRegistration $PCC_SelectCompleters $PCC_SelectMap

