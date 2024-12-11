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

# Argument completions for service AWS IAM Access Analyzer


$IAMAA_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AccessAnalyzer.AccessCheckPolicyType
        {
            ($_ -eq "Test-IAMAAAccessNotGranted/PolicyType") -Or
            ($_ -eq "Test-IAMAANoNewAccess/PolicyType")
        }
        {
            $v = "IDENTITY_POLICY","RESOURCE_POLICY"
            break
        }

        # Amazon.AccessAnalyzer.AccessCheckResourceType
        "Test-IAMAANoPublicAccess/ResourceType"
        {
            $v = "AWS::DynamoDB::Stream","AWS::DynamoDB::Table","AWS::EFS::FileSystem","AWS::IAM::AssumeRolePolicyDocument","AWS::Kinesis::Stream","AWS::Kinesis::StreamConsumer","AWS::KMS::Key","AWS::Lambda::Function","AWS::OpenSearchService::Domain","AWS::S3::AccessPoint","AWS::S3::Bucket","AWS::S3::Glacier","AWS::S3Express::DirectoryBucket","AWS::S3Outposts::AccessPoint","AWS::S3Outposts::Bucket","AWS::SecretsManager::Secret","AWS::SNS::Topic","AWS::SQS::Queue"
            break
        }

        # Amazon.AccessAnalyzer.FindingStatusUpdate
        "Update-IAMAAFinding/Status"
        {
            $v = "ACTIVE","ARCHIVED"
            break
        }

        # Amazon.AccessAnalyzer.Locale
        "Use-IAMAAPolicyValidation/Locale"
        {
            $v = "DE","EN","ES","FR","IT","JA","KO","PT_BR","ZH_CN","ZH_TW"
            break
        }

        # Amazon.AccessAnalyzer.OrderBy
        {
            ($_ -eq "Get-IAMAAFindingList/Sort_OrderBy") -Or
            ($_ -eq "Get-IAMAAFindingsV2List/Sort_OrderBy")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.AccessAnalyzer.PolicyType
        "Use-IAMAAPolicyValidation/PolicyType"
        {
            $v = "IDENTITY_POLICY","RESOURCE_CONTROL_POLICY","RESOURCE_POLICY","SERVICE_CONTROL_POLICY"
            break
        }

        # Amazon.AccessAnalyzer.ResourceType
        "Get-IAMAAAnalyzedResourceList/ResourceType"
        {
            $v = "AWS::DynamoDB::Stream","AWS::DynamoDB::Table","AWS::EC2::Snapshot","AWS::ECR::Repository","AWS::EFS::FileSystem","AWS::IAM::Role","AWS::IAM::User","AWS::KMS::Key","AWS::Lambda::Function","AWS::Lambda::LayerVersion","AWS::RDS::DBClusterSnapshot","AWS::RDS::DBSnapshot","AWS::S3::Bucket","AWS::S3Express::DirectoryBucket","AWS::SecretsManager::Secret","AWS::SNS::Topic","AWS::SQS::Queue"
            break
        }

        # Amazon.AccessAnalyzer.Type
        {
            ($_ -eq "Get-IAMAAAnalyzerList/Type") -Or
            ($_ -eq "New-IAMAAAnalyzer/Type")
        }
        {
            $v = "ACCOUNT","ACCOUNT_UNUSED_ACCESS","ORGANIZATION","ORGANIZATION_UNUSED_ACCESS"
            break
        }

        # Amazon.AccessAnalyzer.ValidatePolicyResourceType
        "Use-IAMAAPolicyValidation/ValidatePolicyResourceType"
        {
            $v = "AWS::DynamoDB::Table","AWS::IAM::AssumeRolePolicyDocument","AWS::S3::AccessPoint","AWS::S3::Bucket","AWS::S3::MultiRegionAccessPoint","AWS::S3ObjectLambda::AccessPoint"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IAMAA_map = @{
    "Locale"=@("Use-IAMAAPolicyValidation")
    "PolicyType"=@("Test-IAMAAAccessNotGranted","Test-IAMAANoNewAccess","Use-IAMAAPolicyValidation")
    "ResourceType"=@("Get-IAMAAAnalyzedResourceList","Test-IAMAANoPublicAccess")
    "Sort_OrderBy"=@("Get-IAMAAFindingList","Get-IAMAAFindingsV2List")
    "Status"=@("Update-IAMAAFinding")
    "Type"=@("Get-IAMAAAnalyzerList","New-IAMAAAnalyzer")
    "ValidatePolicyResourceType"=@("Use-IAMAAPolicyValidation")
}

_awsArgumentCompleterRegistration $IAMAA_Completers $IAMAA_map

$IAMAA_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.IAMAA.$($commandName.Replace('-', ''))Cmdlet]"
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

$IAMAA_SelectMap = @{
    "Select"=@("Start-IAMAAArchiveRule",
               "Stop-IAMAAPolicyGeneration",
               "Test-IAMAAAccessNotGranted",
               "Test-IAMAANoNewAccess",
               "Test-IAMAANoPublicAccess",
               "New-IAMAAAccessPreview",
               "New-IAMAAAnalyzer",
               "New-IAMAAArchiveRule",
               "Remove-IAMAAAnalyzer",
               "Remove-IAMAAArchiveRule",
               "Start-IAMAAFindingRecommendation",
               "Get-IAMAAAccessPreview",
               "Get-IAMAAAnalyzedResource",
               "Get-IAMAAAnalyzer",
               "Get-IAMAAArchiveRule",
               "Get-IAMAAFinding",
               "Get-IAMAAFindingRecommendation",
               "Get-IAMAAFindingV2",
               "Get-IAMAAGeneratedPolicy",
               "Get-IAMAAAccessPreviewFindingList",
               "Get-IAMAAAccessPreviewList",
               "Get-IAMAAAnalyzedResourceList",
               "Get-IAMAAAnalyzerList",
               "Get-IAMAAArchiveRuleList",
               "Get-IAMAAFindingList",
               "Get-IAMAAFindingsV2List",
               "Get-IAMAAPolicyGenerationList",
               "Get-IAMAAResourceTag",
               "Start-IAMAAPolicyGeneration",
               "Start-IAMAAResourceScan",
               "Add-IAMAAResourceTag",
               "Remove-IAMAAResourceTag",
               "Update-IAMAAAnalyzer",
               "Update-IAMAAArchiveRule",
               "Update-IAMAAFinding",
               "Use-IAMAAPolicyValidation")
}

_awsArgumentCompleterRegistration $IAMAA_SelectCompleters $IAMAA_SelectMap

