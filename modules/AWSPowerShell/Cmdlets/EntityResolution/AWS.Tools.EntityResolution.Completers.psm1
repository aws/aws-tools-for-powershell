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

# Argument completions for service AWS EntityResolution


$ERES_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.EntityResolution.AttributeMatchingModel
        {
            ($_ -eq "New-ERESMatchingWorkflow/RuleBasedProperties_AttributeMatchingModel") -Or
            ($_ -eq "Update-ERESMatchingWorkflow/RuleBasedProperties_AttributeMatchingModel")
        }
        {
            $v = "MANY_TO_MANY","ONE_TO_ONE"
            break
        }

        # Amazon.EntityResolution.IdMappingType
        {
            ($_ -eq "New-ERESIdMappingWorkflow/IdMappingTechniques_IdMappingType") -Or
            ($_ -eq "Update-ERESIdMappingWorkflow/IdMappingTechniques_IdMappingType")
        }
        {
            $v = "PROVIDER"
            break
        }

        # Amazon.EntityResolution.IdNamespaceType
        "New-ERESIdNamespace/Type"
        {
            $v = "SOURCE","TARGET"
            break
        }

        # Amazon.EntityResolution.IncrementalRunType
        {
            ($_ -eq "New-ERESMatchingWorkflow/IncrementalRunConfig_IncrementalRunType") -Or
            ($_ -eq "Update-ERESMatchingWorkflow/IncrementalRunConfig_IncrementalRunType")
        }
        {
            $v = "IMMEDIATE"
            break
        }

        # Amazon.EntityResolution.ResolutionType
        {
            ($_ -eq "New-ERESMatchingWorkflow/ResolutionTechniques_ResolutionType") -Or
            ($_ -eq "Update-ERESMatchingWorkflow/ResolutionTechniques_ResolutionType")
        }
        {
            $v = "ML_MATCHING","PROVIDER","RULE_MATCHING"
            break
        }

        # Amazon.EntityResolution.StatementEffect
        "Add-ERESPolicyStatement/Effect"
        {
            $v = "Allow","Deny"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ERES_map = @{
    "Effect"=@("Add-ERESPolicyStatement")
    "IdMappingTechniques_IdMappingType"=@("New-ERESIdMappingWorkflow","Update-ERESIdMappingWorkflow")
    "IncrementalRunConfig_IncrementalRunType"=@("New-ERESMatchingWorkflow","Update-ERESMatchingWorkflow")
    "ResolutionTechniques_ResolutionType"=@("New-ERESMatchingWorkflow","Update-ERESMatchingWorkflow")
    "RuleBasedProperties_AttributeMatchingModel"=@("New-ERESMatchingWorkflow","Update-ERESMatchingWorkflow")
    "Type"=@("New-ERESIdNamespace")
}

_awsArgumentCompleterRegistration $ERES_Completers $ERES_map

$ERES_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ERES.$($commandName.Replace('-', ''))Cmdlet]"
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

$ERES_SelectMap = @{
    "Select"=@("Add-ERESPolicyStatement",
               "Remove-ERESDeleteUniqueId",
               "New-ERESIdMappingWorkflow",
               "New-ERESIdNamespace",
               "New-ERESMatchingWorkflow",
               "New-ERESSchemaMapping",
               "Remove-ERESIdMappingWorkflow",
               "Remove-ERESIdNamespace",
               "Remove-ERESMatchingWorkflow",
               "Remove-ERESPolicyStatement",
               "Remove-ERESSchemaMapping",
               "Get-ERESIdMappingJob",
               "Get-ERESIdMappingWorkflow",
               "Get-ERESIdNamespace",
               "Get-ERESMatchId",
               "Get-ERESMatchingJob",
               "Get-ERESMatchingWorkflow",
               "Get-ERESPolicy",
               "Get-ERESProviderService",
               "Get-ERESSchemaMapping",
               "Get-ERESIdMappingJobList",
               "Get-ERESIdMappingWorkflowList",
               "Get-ERESIdNamespaceList",
               "Get-ERESMatchingJobList",
               "Get-ERESMatchingWorkflowList",
               "Get-ERESProviderServiceList",
               "Get-ERESSchemaMappingList",
               "Get-ERESResourceTag",
               "Write-ERESPolicy",
               "Start-ERESIdMappingJob",
               "Start-ERESMatchingJob",
               "Add-ERESResourceTag",
               "Remove-ERESResourceTag",
               "Update-ERESIdMappingWorkflow",
               "Update-ERESIdNamespace",
               "Update-ERESMatchingWorkflow",
               "Update-ERESSchemaMapping")
}

_awsArgumentCompleterRegistration $ERES_SelectCompleters $ERES_SelectMap

