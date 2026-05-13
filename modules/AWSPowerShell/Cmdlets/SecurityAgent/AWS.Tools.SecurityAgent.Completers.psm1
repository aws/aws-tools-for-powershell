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

# Argument completions for service AWS Security Agent


$SECAG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SecurityAgent.ArtifactType
        "Add-SECAGArtifact/ArtifactType"
        {
            $v = "DOC","DOCX","JPEG","JSON","MD","PDF","PNG","TXT","YAML"
            break
        }

        # Amazon.SecurityAgent.CodeRemediationStrategy
        {
            ($_ -eq "New-SECAGCodeReview/CodeRemediationStrategy") -Or
            ($_ -eq "New-SECAGPentest/CodeRemediationStrategy") -Or
            ($_ -eq "Update-SECAGCodeReview/CodeRemediationStrategy") -Or
            ($_ -eq "Update-SECAGPentest/CodeRemediationStrategy")
        }
        {
            $v = "AUTOMATIC","DISABLED"
            break
        }

        # Amazon.SecurityAgent.ConfidenceLevel
        "Get-SECAGFindingList/Confidence"
        {
            $v = "FALSE_POSITIVE","HIGH","LOW","MEDIUM","UNCONFIRMED"
            break
        }

        # Amazon.SecurityAgent.DomainVerificationMethod
        {
            ($_ -eq "New-SECAGTargetDomain/VerificationMethod") -Or
            ($_ -eq "Update-SECAGTargetDomain/VerificationMethod")
        }
        {
            $v = "DNS_TXT","HTTP_ROUTE","PRIVATE_VPC"
            break
        }

        # Amazon.SecurityAgent.FindingStatus
        {
            ($_ -eq "Get-SECAGFindingList/Status") -Or
            ($_ -eq "Update-SECAGFinding/Status")
        }
        {
            $v = "ACCEPTED","ACTIVE","FALSE_POSITIVE","RESOLVED"
            break
        }

        # Amazon.SecurityAgent.MembershipType
        {
            ($_ -eq "New-SECAGMembership/MemberType") -Or
            ($_ -eq "Remove-SECAGMembership/MemberType")
        }
        {
            $v = "USER"
            break
        }

        # Amazon.SecurityAgent.MembershipTypeFilter
        "Get-SECAGMembershipList/MemberType"
        {
            $v = "ALL","USER"
            break
        }

        # Amazon.SecurityAgent.Provider
        {
            ($_ -eq "Get-SECAGIntegrationList/Filter_Provider") -Or
            ($_ -eq "New-SECAGIntegration/Provider") -Or
            ($_ -eq "Start-SECAGProviderRegistration/Provider")
        }
        {
            $v = "GITHUB"
            break
        }

        # Amazon.SecurityAgent.ProviderType
        "Get-SECAGIntegrationList/Filter_ProviderType"
        {
            $v = "DOCUMENTATION","SOURCE_CODE"
            break
        }

        # Amazon.SecurityAgent.ResourceType
        "Get-SECAGIntegratedResourceList/ResourceType"
        {
            $v = "CODE_REPOSITORY"
            break
        }

        # Amazon.SecurityAgent.RiskLevel
        {
            ($_ -eq "Get-SECAGFindingList/RiskLevel") -Or
            ($_ -eq "Update-SECAGFinding/RiskLevel")
        }
        {
            $v = "CRITICAL","HIGH","INFORMATIONAL","LOW","MEDIUM","UNKNOWN"
            break
        }

        # Amazon.SecurityAgent.StepName
        {
            ($_ -eq "Get-SECAGCodeReviewJobTaskList/StepName") -Or
            ($_ -eq "Get-SECAGPentestJobTaskList/StepName")
        }
        {
            $v = "FINALIZING","PENTEST","PREFLIGHT","STATIC_ANALYSIS"
            break
        }

        # Amazon.SecurityAgent.UserRole
        "New-SECAGMembership/Config_User_Role"
        {
            $v = "MEMBER"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SECAG_map = @{
    "ArtifactType"=@("Add-SECAGArtifact")
    "CodeRemediationStrategy"=@("New-SECAGCodeReview","New-SECAGPentest","Update-SECAGCodeReview","Update-SECAGPentest")
    "Confidence"=@("Get-SECAGFindingList")
    "Config_User_Role"=@("New-SECAGMembership")
    "Filter_Provider"=@("Get-SECAGIntegrationList")
    "Filter_ProviderType"=@("Get-SECAGIntegrationList")
    "MemberType"=@("Get-SECAGMembershipList","New-SECAGMembership","Remove-SECAGMembership")
    "Provider"=@("New-SECAGIntegration","Start-SECAGProviderRegistration")
    "ResourceType"=@("Get-SECAGIntegratedResourceList")
    "RiskLevel"=@("Get-SECAGFindingList","Update-SECAGFinding")
    "Status"=@("Get-SECAGFindingList","Update-SECAGFinding")
    "StepName"=@("Get-SECAGCodeReviewJobTaskList","Get-SECAGPentestJobTaskList")
    "VerificationMethod"=@("New-SECAGTargetDomain","Update-SECAGTargetDomain")
}

_awsArgumentCompleterRegistration $SECAG_Completers $SECAG_map

$SECAG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SECAG.$($commandName.Replace('-', ''))Cmdlet]"
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

$SECAG_SelectMap = @{
    "Select"=@("Add-SECAGArtifact",
               "Remove-SECAGCodeReviewBatch",
               "Remove-SECAGPentestBatch",
               "Get-SECAGAgentSpaceBatch",
               "Get-SECAGArtifactMetadataBatch",
               "Get-SECAGCodeReviewJobBatch",
               "Get-SECAGCodeReviewJobTaskBatch",
               "Get-SECAGCodeReviewBatch",
               "Get-SECAGFindingBatch",
               "Get-SECAGPentestJobBatch",
               "Get-SECAGPentestJobTaskBatch",
               "Get-SECAGPentestBatch",
               "Get-SECAGTargetDomainBatch",
               "New-SECAGAgentSpace",
               "New-SECAGApplication",
               "New-SECAGCodeReview",
               "New-SECAGIntegration",
               "New-SECAGMembership",
               "New-SECAGPentest",
               "New-SECAGTargetDomain",
               "Remove-SECAGAgentSpace",
               "Remove-SECAGApplication",
               "Remove-SECAGArtifact",
               "Remove-SECAGIntegration",
               "Remove-SECAGMembership",
               "Remove-SECAGTargetDomain",
               "Get-SECAGApplication",
               "Get-SECAGArtifact",
               "Get-SECAGIntegration",
               "Start-SECAGProviderRegistration",
               "Get-SECAGAgentSpaceList",
               "Get-SECAGApplicationList",
               "Get-SECAGArtifactList",
               "Get-SECAGCodeReviewJobsForCodeReviewList",
               "Get-SECAGCodeReviewJobTaskList",
               "Get-SECAGCodeReviewList",
               "Get-SECAGDiscoveredEndpointList",
               "Get-SECAGFindingList",
               "Get-SECAGIntegratedResourceList",
               "Get-SECAGIntegrationList",
               "Get-SECAGMembershipList",
               "Get-SECAGPentestJobsForPentestList",
               "Get-SECAGPentestJobTaskList",
               "Get-SECAGPentestList",
               "Get-SECAGResourceTag",
               "Get-SECAGTargetDomainList",
               "Start-SECAGCodeRemediation",
               "Start-SECAGCodeReviewJob",
               "Start-SECAGPentestJob",
               "Stop-SECAGCodeReviewJob",
               "Stop-SECAGPentestJob",
               "Add-SECAGResourceTag",
               "Remove-SECAGResourceTag",
               "Update-SECAGAgentSpace",
               "Update-SECAGApplication",
               "Update-SECAGCodeReview",
               "Update-SECAGFinding",
               "Update-SECAGIntegratedResource",
               "Update-SECAGPentest",
               "Update-SECAGTargetDomain",
               "Confirm-SECAGTargetDomain")
}

_awsArgumentCompleterRegistration $SECAG_SelectCompleters $SECAG_SelectMap

