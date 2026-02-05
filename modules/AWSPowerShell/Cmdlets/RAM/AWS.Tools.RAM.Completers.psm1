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

# Argument completions for service AWS Resource Access Manager (RAM)


$RAM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.RAM.PermissionFeatureSet
        "Get-RAMPermissionAssociationList/FeatureSet"
        {
            $v = "CREATED_FROM_POLICY","PROMOTING_TO_STANDARD","STANDARD"
            break
        }

        # Amazon.RAM.PermissionTypeFilter
        "Get-RAMPermissionList/PermissionType"
        {
            $v = "ALL","AWS_MANAGED","CUSTOMER_MANAGED"
            break
        }

        # Amazon.RAM.ReplacePermissionAssociationsWorkStatus
        "Get-RAMReplacePermissionAssociationsWorkList/Status"
        {
            $v = "COMPLETED","FAILED","IN_PROGRESS"
            break
        }

        # Amazon.RAM.ResourceOwner
        {
            ($_ -eq "Get-RAMPrincipalList/ResourceOwner") -Or
            ($_ -eq "Get-RAMResourceList/ResourceOwner") -Or
            ($_ -eq "Get-RAMResourceShare/ResourceOwner")
        }
        {
            $v = "OTHER-ACCOUNTS","SELF"
            break
        }

        # Amazon.RAM.ResourceRegionScopeFilter
        {
            ($_ -eq "Get-RAMPendingInvitationResourceList/ResourceRegionScope") -Or
            ($_ -eq "Get-RAMResourceList/ResourceRegionScope") -Or
            ($_ -eq "Get-RAMResourceTypeList/ResourceRegionScope")
        }
        {
            $v = "ALL","GLOBAL","REGIONAL"
            break
        }

        # Amazon.RAM.ResourceShareAssociationStatus
        {
            ($_ -eq "Get-RAMPermissionAssociationList/AssociationStatus") -Or
            ($_ -eq "Get-RAMResourceShareAssociation/AssociationStatus") -Or
            ($_ -eq "Get-RAMSourceAssociationList/AssociationStatus")
        }
        {
            $v = "ASSOCIATED","ASSOCIATING","DISASSOCIATED","DISASSOCIATING","FAILED","RESTORING","SUSPENDED","SUSPENDING"
            break
        }

        # Amazon.RAM.ResourceShareAssociationType
        "Get-RAMResourceShareAssociation/AssociationType"
        {
            $v = "PRINCIPAL","RESOURCE","SOURCE"
            break
        }

        # Amazon.RAM.ResourceShareStatus
        "Get-RAMResourceShare/ResourceShareStatus"
        {
            $v = "ACTIVE","DELETED","DELETING","FAILED","PENDING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RAM_map = @{
    "AssociationStatus"=@("Get-RAMPermissionAssociationList","Get-RAMResourceShareAssociation","Get-RAMSourceAssociationList")
    "AssociationType"=@("Get-RAMResourceShareAssociation")
    "FeatureSet"=@("Get-RAMPermissionAssociationList")
    "PermissionType"=@("Get-RAMPermissionList")
    "ResourceOwner"=@("Get-RAMPrincipalList","Get-RAMResourceList","Get-RAMResourceShare")
    "ResourceRegionScope"=@("Get-RAMPendingInvitationResourceList","Get-RAMResourceList","Get-RAMResourceTypeList")
    "ResourceShareStatus"=@("Get-RAMResourceShare")
    "Status"=@("Get-RAMReplacePermissionAssociationsWorkList")
}

_awsArgumentCompleterRegistration $RAM_Completers $RAM_map

$RAM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.RAM.$($commandName.Replace('-', ''))Cmdlet]"
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

$RAM_SelectMap = @{
    "Select"=@("Confirm-RAMResourceShareInvitation",
               "Connect-RAMResourceShare",
               "Add-RAMPermissionToResourceShare",
               "New-RAMPermission",
               "New-RAMPermissionVersion",
               "New-RAMResourceShare",
               "Remove-RAMPermission",
               "Remove-RAMPermissionVersion",
               "Remove-RAMResourceShare",
               "Disconnect-RAMResourceShare",
               "Remove-RAMPermissionFromResourceShare",
               "Enable-RAMSharingWithAwsOrganization",
               "Get-RAMPermission",
               "Get-RAMResourcePolicy",
               "Get-RAMResourceShareAssociation",
               "Get-RAMResourceShareInvitation",
               "Get-RAMResourceShare",
               "Get-RAMPendingInvitationResourceList",
               "Get-RAMPermissionAssociationList",
               "Get-RAMPermissionList",
               "Get-RAMPermissionVersionList",
               "Get-RAMPrincipalList",
               "Get-RAMReplacePermissionAssociationsWorkList",
               "Get-RAMResourceList",
               "Get-RAMResourceSharePermissionList",
               "Get-RAMResourceTypeList",
               "Get-RAMSourceAssociationList",
               "Convert-RAMPermissionCreatedFromPolicy",
               "Convert-RAMPolicyBasedResourceShareToPromoted",
               "Deny-RAMResourceShareInvitation",
               "Edit-RAMPermissionAssociation",
               "Set-RAMDefaultPermissionVersion",
               "Add-RAMResourceTag",
               "Remove-RAMResourceTag",
               "Update-RAMResourceShare")
}

_awsArgumentCompleterRegistration $RAM_SelectCompleters $RAM_SelectMap

