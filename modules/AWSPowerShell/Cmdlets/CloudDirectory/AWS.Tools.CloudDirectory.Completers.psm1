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

# Argument completions for service Amazon Cloud Directory


$CDIR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudDirectory.ConsistencyLevel
        {
            ($_ -eq "Get-CDIRIncomingTypedLink/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRIndex/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRLinkAttribute/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectAttribute/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectAttributeList/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectChild/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectIndex/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectInformation/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectParent/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRObjectPolicy/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIROutgoingTypedLink/ConsistencyLevel") -Or
            ($_ -eq "Get-CDIRPolicyAttachment/ConsistencyLevel") -Or
            ($_ -eq "Read-CDIRDirectoryBatch/ConsistencyLevel")
        }
        {
            $v = "EVENTUAL","SERIALIZABLE"
            break
        }

        # Amazon.CloudDirectory.DirectoryState
        "Get-CDIRDirectory/State"
        {
            $v = "DELETED","DISABLED","ENABLED"
            break
        }

        # Amazon.CloudDirectory.FacetStyle
        "New-CDIRFacet/FacetStyle"
        {
            $v = "DYNAMIC","STATIC"
            break
        }

        # Amazon.CloudDirectory.ObjectType
        {
            ($_ -eq "New-CDIRFacet/ObjectType") -Or
            ($_ -eq "Update-CDIRFacet/ObjectType")
        }
        {
            $v = "INDEX","LEAF_NODE","NODE","POLICY"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CDIR_map = @{
    "ConsistencyLevel"=@("Get-CDIRIncomingTypedLink","Get-CDIRIndex","Get-CDIRLinkAttribute","Get-CDIRObjectAttribute","Get-CDIRObjectAttributeList","Get-CDIRObjectChild","Get-CDIRObjectIndex","Get-CDIRObjectInformation","Get-CDIRObjectParent","Get-CDIRObjectPolicy","Get-CDIROutgoingTypedLink","Get-CDIRPolicyAttachment","Read-CDIRDirectoryBatch")
    "FacetStyle"=@("New-CDIRFacet")
    "ObjectType"=@("New-CDIRFacet","Update-CDIRFacet")
    "State"=@("Get-CDIRDirectory")
}

_awsArgumentCompleterRegistration $CDIR_Completers $CDIR_map

$CDIR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CDIR.$($commandName.Replace('-', ''))Cmdlet]"
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

$CDIR_SelectMap = @{
    "Select"=@("Add-CDIRFacetToObject",
               "Add-CDIRSchema",
               "Connect-CDIRObject",
               "Mount-CDIRPolicy",
               "Mount-CDIRObjectToIndex",
               "Mount-CDIRTypedLink",
               "Read-CDIRDirectoryBatch",
               "Write-CDIRDirectoryBatch",
               "New-CDIRDirectory",
               "New-CDIRFacet",
               "New-CDIRIndex",
               "New-CDIRDirectoryObject",
               "New-CDIRSchema",
               "New-CDIRTypedLinkFacet",
               "Remove-CDIRDirectory",
               "Remove-CDIRFacet",
               "Remove-CDIRDirectoryObject",
               "Remove-CDIRSchema",
               "Remove-CDIRTypedLinkFacet",
               "Dismount-CDIRObjectFromIndex",
               "Disconnect-CDIRObject",
               "Dismount-CDIRPolicyFromObject",
               "Dismount-CDIRTypedLink",
               "Disable-CDIRDirectory",
               "Enable-CDIRDirectory",
               "Get-CDIRAppliedSchemaVersion",
               "Get-CDIRDirectoryMetadata",
               "Get-CDIRFacet",
               "Get-CDIRLinkAttribute",
               "Get-CDIRObjectAttribute",
               "Get-CDIRObjectInformation",
               "Get-CDIRSchemaAsJson",
               "Get-CDIRTypedLinkFacetInformation",
               "Get-CDIRAppliedSchemaArn",
               "Get-CDIRObjectIndex",
               "Get-CDIRDevelopmentSchemaArn",
               "Get-CDIRDirectory",
               "Get-CDIRFacetAttribute",
               "Get-CDIRFacetName",
               "Get-CDIRIncomingTypedLink",
               "Get-CDIRIndex",
               "Get-CDIRManagedSchemaArn",
               "Get-CDIRObjectAttributeList",
               "Get-CDIRObjectChild",
               "Get-CDIRObjectParentPath",
               "Get-CDIRObjectParent",
               "Get-CDIRObjectPolicy",
               "Get-CDIROutgoingTypedLink",
               "Get-CDIRPolicyAttachment",
               "Get-CDIRPublishedSchemaArn",
               "Get-CDIRResourceTag",
               "Get-CDIRTypedLinkFacetAttribute",
               "Get-CDIRTypedLinkFacetName",
               "Get-CDIRDirectoryPolicy",
               "Publish-CDIRSchema",
               "Write-CDIRSchemaFromJson",
               "Remove-CDIRFacetFromObject",
               "Add-CDIRResourceTag",
               "Remove-CDIRResourceTag",
               "Update-CDIRFacet",
               "Update-CDIRLinkAttribute",
               "Update-CDIRObjectAttribute",
               "Update-CDIRSchema",
               "Update-CDIRTypedLinkFacet",
               "Update-CDIRAppliedSchema",
               "Update-CDIRPublishedSchema")
}

_awsArgumentCompleterRegistration $CDIR_SelectCompleters $CDIR_SelectMap

