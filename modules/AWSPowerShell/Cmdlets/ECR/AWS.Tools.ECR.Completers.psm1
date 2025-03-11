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

# Argument completions for service Amazon EC2 Container Registry


$ECR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ECR.EncryptionType
        {
            ($_ -eq "New-ECRRepository/EncryptionConfiguration_EncryptionType") -Or
            ($_ -eq "New-ECRRepositoryCreationTemplate/EncryptionConfiguration_EncryptionType") -Or
            ($_ -eq "Update-ECRRepositoryCreationTemplate/EncryptionConfiguration_EncryptionType")
        }
        {
            $v = "AES256","KMS","KMS_DSSE"
            break
        }

        # Amazon.ECR.ImageTagMutability
        {
            ($_ -eq "New-ECRRepository/ImageTagMutability") -Or
            ($_ -eq "New-ECRRepositoryCreationTemplate/ImageTagMutability") -Or
            ($_ -eq "Update-ECRRepositoryCreationTemplate/ImageTagMutability") -Or
            ($_ -eq "Write-ECRImageTagMutability/ImageTagMutability")
        }
        {
            $v = "IMMUTABLE","MUTABLE"
            break
        }

        # Amazon.ECR.ScanType
        "Write-ECRRegistryScanningConfiguration/ScanType"
        {
            $v = "BASIC","ENHANCED"
            break
        }

        # Amazon.ECR.TagStatus
        {
            ($_ -eq "Get-ECRImage/Filter_TagStatus") -Or
            ($_ -eq "Get-ECRImageMetadata/Filter_TagStatus") -Or
            ($_ -eq "Get-ECRLifecyclePolicyPreview/Filter_TagStatus")
        }
        {
            $v = "ANY","TAGGED","UNTAGGED"
            break
        }

        # Amazon.ECR.UpstreamRegistry
        "New-ECRPullThroughCacheRule/UpstreamRegistry"
        {
            $v = "azure-container-registry","docker-hub","ecr","ecr-public","github-container-registry","gitlab-container-registry","k8s","quay"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ECR_map = @{
    "EncryptionConfiguration_EncryptionType"=@("New-ECRRepository","New-ECRRepositoryCreationTemplate","Update-ECRRepositoryCreationTemplate")
    "Filter_TagStatus"=@("Get-ECRImage","Get-ECRImageMetadata","Get-ECRLifecyclePolicyPreview")
    "ImageTagMutability"=@("New-ECRRepository","New-ECRRepositoryCreationTemplate","Update-ECRRepositoryCreationTemplate","Write-ECRImageTagMutability")
    "ScanType"=@("Write-ECRRegistryScanningConfiguration")
    "UpstreamRegistry"=@("New-ECRPullThroughCacheRule")
}

_awsArgumentCompleterRegistration $ECR_Completers $ECR_map

$ECR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ECR.$($commandName.Replace('-', ''))Cmdlet]"
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

$ECR_SelectMap = @{
    "Select"=@("Get-ECRLayerAvailabilityBatch",
               "Remove-ECRImageBatch",
               "Get-ECRImageBatch",
               "Get-ECRRepositoryScanningConfigurationBatch",
               "Complete-ECRLayerUpload",
               "New-ECRPullThroughCacheRule",
               "New-ECRRepository",
               "New-ECRRepositoryCreationTemplate",
               "Remove-ECRLifecyclePolicy",
               "Remove-ECRPullThroughCacheRule",
               "Remove-ECRRegistryPolicy",
               "Remove-ECRRepository",
               "Remove-ECRRepositoryCreationTemplate",
               "Remove-ECRRepositoryPolicy",
               "Get-ECRImageReplicationStatus",
               "Get-ECRImageMetadata",
               "Get-ECRImageScanFinding",
               "Get-ECRPullThroughCacheRule",
               "Get-ECRRegistry",
               "Get-ECRRepository",
               "Get-ECRRepositoryCreationTemplate",
               "Get-ECRAccountSetting",
               "Get-ECRAuthorizationToken",
               "Get-ECRDownloadUrlForLayer",
               "Get-ECRLifecyclePolicy",
               "Get-ECRLifecyclePolicyPreview",
               "Get-ECRRegistryPolicy",
               "Get-ECRRegistryScanningConfiguration",
               "Get-ECRRepositoryPolicy",
               "Start-ECRLayerUpload",
               "Get-ECRImage",
               "Get-ECRResourceTag",
               "Write-ECRAccountSetting",
               "Write-ECRImage",
               "Write-ECRImageScanningConfiguration",
               "Write-ECRImageTagMutability",
               "Write-ECRLifecyclePolicy",
               "Write-ECRRegistryPolicy",
               "Write-ECRRegistryScanningConfiguration",
               "Write-ECRReplicationConfiguration",
               "Set-ECRRepositoryPolicy",
               "Start-ECRImageScan",
               "Start-ECRLifecyclePolicyPreview",
               "Add-ECRResourceTag",
               "Remove-ECRResourceTag",
               "Update-ECRPullThroughCacheRule",
               "Update-ECRRepositoryCreationTemplate",
               "Send-ECRLayerPart",
               "Test-ECRPullThroughCacheRule",
               "Get-ECRLoginCommand")
}

_awsArgumentCompleterRegistration $ECR_SelectCompleters $ECR_SelectMap

