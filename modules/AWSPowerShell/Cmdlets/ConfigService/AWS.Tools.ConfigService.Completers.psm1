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

# Argument completions for service AWS Config


$CFG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ConfigService.ChronologicalOrder
        "Get-CFGResourceConfigHistory/ChronologicalOrder"
        {
            $v = "Forward","Reverse"
            break
        }

        # Amazon.ConfigService.ComplianceType
        {
            ($_ -eq "Get-CFGAggregateComplianceDetailsByConfigRule/ComplianceType") -Or
            ($_ -eq "Get-CFGAggregateComplianceByConfigRuleList/Filters_ComplianceType")
        }
        {
            $v = "COMPLIANT","INSUFFICIENT_DATA","NON_COMPLIANT","NOT_APPLICABLE"
            break
        }

        # Amazon.ConfigService.ConfigRuleComplianceSummaryGroupKey
        "Get-CFGAggregateConfigRuleComplianceSummary/GroupByKey"
        {
            $v = "ACCOUNT_ID","AWS_REGION"
            break
        }

        # Amazon.ConfigService.ConfigRuleState
        "Write-CFGConfigRule/ConfigRule_ConfigRuleState"
        {
            $v = "ACTIVE","DELETING","DELETING_RESULTS","EVALUATING"
            break
        }

        # Amazon.ConfigService.ConformancePackComplianceType
        {
            ($_ -eq "Get-CFGConformancePackCompliance/Filters_ComplianceType") -Or
            ($_ -eq "Get-CFGConformancePackComplianceDetail/Filters_ComplianceType")
        }
        {
            $v = "COMPLIANT","NON_COMPLIANT"
            break
        }

        # Amazon.ConfigService.MaximumExecutionFrequency
        {
            ($_ -eq "Write-CFGConfigRule/ConfigRule_MaximumExecutionFrequency") -Or
            ($_ -eq "Write-CFGDeliveryChannel/DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency") -Or
            ($_ -eq "Write-CFGOrganizationConfigRule/OrganizationCustomRuleMetadata_MaximumExecutionFrequency") -Or
            ($_ -eq "Write-CFGOrganizationConfigRule/OrganizationManagedRuleMetadata_MaximumExecutionFrequency")
        }
        {
            $v = "One_Hour","Six_Hours","Three_Hours","Twelve_Hours","TwentyFour_Hours"
            break
        }

        # Amazon.ConfigService.MemberAccountRuleStatus
        "Get-CFGOrganizationConfigRuleDetailedStatus/Filters_MemberAccountRuleStatus"
        {
            $v = "CREATE_FAILED","CREATE_IN_PROGRESS","CREATE_SUCCESSFUL","DELETE_FAILED","DELETE_IN_PROGRESS","DELETE_SUCCESSFUL","UPDATE_FAILED","UPDATE_IN_PROGRESS","UPDATE_SUCCESSFUL"
            break
        }

        # Amazon.ConfigService.OrganizationResourceDetailedStatus
        "Get-CFGOrganizationConformancePackDetailedStatus/Filters_Status"
        {
            $v = "CREATE_FAILED","CREATE_IN_PROGRESS","CREATE_SUCCESSFUL","DELETE_FAILED","DELETE_IN_PROGRESS","DELETE_SUCCESSFUL","UPDATE_FAILED","UPDATE_IN_PROGRESS","UPDATE_SUCCESSFUL"
            break
        }

        # Amazon.ConfigService.Owner
        "Write-CFGConfigRule/ConfigRule_Source_Owner"
        {
            $v = "AWS","CUSTOM_LAMBDA"
            break
        }

        # Amazon.ConfigService.ResourceCountGroupKey
        "Get-CFGAggregateDiscoveredResourceCount/GroupByKey"
        {
            $v = "ACCOUNT_ID","AWS_REGION","RESOURCE_TYPE"
            break
        }

        # Amazon.ConfigService.ResourceType
        {
            ($_ -eq "Get-CFGAggregateDiscoveredResourceCount/Filters_ResourceType") -Or
            ($_ -eq "Get-CFGAggregateResourceConfig/ResourceIdentifier_ResourceType") -Or
            ($_ -eq "Get-CFGAggregateDiscoveredResourceList/ResourceType") -Or
            ($_ -eq "Get-CFGDiscoveredResource/ResourceType") -Or
            ($_ -eq "Get-CFGResourceConfigHistory/ResourceType")
        }
        {
            $v = "AWS::ACM::Certificate","AWS::ApiGateway::RestApi","AWS::ApiGateway::Stage","AWS::ApiGatewayV2::Api","AWS::ApiGatewayV2::Stage","AWS::AutoScaling::AutoScalingGroup","AWS::AutoScaling::LaunchConfiguration","AWS::AutoScaling::ScalingPolicy","AWS::AutoScaling::ScheduledAction","AWS::CloudFormation::Stack","AWS::CloudFront::Distribution","AWS::CloudFront::StreamingDistribution","AWS::CloudTrail::Trail","AWS::CloudWatch::Alarm","AWS::CodeBuild::Project","AWS::CodePipeline::Pipeline","AWS::Config::ResourceCompliance","AWS::DynamoDB::Table","AWS::EC2::CustomerGateway","AWS::EC2::EgressOnlyInternetGateway","AWS::EC2::EIP","AWS::EC2::FlowLog","AWS::EC2::Host","AWS::EC2::Instance","AWS::EC2::InternetGateway","AWS::EC2::NatGateway","AWS::EC2::NetworkAcl","AWS::EC2::NetworkInterface","AWS::EC2::RegisteredHAInstance","AWS::EC2::RouteTable","AWS::EC2::SecurityGroup","AWS::EC2::Subnet","AWS::EC2::Volume","AWS::EC2::VPC","AWS::EC2::VPCEndpoint","AWS::EC2::VPCEndpointService","AWS::EC2::VPCPeeringConnection","AWS::EC2::VPNConnection","AWS::EC2::VPNGateway","AWS::ElasticBeanstalk::Application","AWS::ElasticBeanstalk::ApplicationVersion","AWS::ElasticBeanstalk::Environment","AWS::ElasticLoadBalancing::LoadBalancer","AWS::ElasticLoadBalancingV2::LoadBalancer","AWS::Elasticsearch::Domain","AWS::IAM::Group","AWS::IAM::Policy","AWS::IAM::Role","AWS::IAM::User","AWS::KMS::Key","AWS::Lambda::Function","AWS::QLDB::Ledger","AWS::RDS::DBCluster","AWS::RDS::DBClusterSnapshot","AWS::RDS::DBInstance","AWS::RDS::DBSecurityGroup","AWS::RDS::DBSnapshot","AWS::RDS::DBSubnetGroup","AWS::RDS::EventSubscription","AWS::Redshift::Cluster","AWS::Redshift::ClusterParameterGroup","AWS::Redshift::ClusterSecurityGroup","AWS::Redshift::ClusterSnapshot","AWS::Redshift::ClusterSubnetGroup","AWS::Redshift::EventSubscription","AWS::S3::AccountPublicAccessBlock","AWS::S3::Bucket","AWS::ServiceCatalog::CloudFormationProduct","AWS::ServiceCatalog::CloudFormationProvisionedProduct","AWS::ServiceCatalog::Portfolio","AWS::Shield::Protection","AWS::ShieldRegional::Protection","AWS::SQS::Queue","AWS::SSM::AssociationCompliance","AWS::SSM::ManagedInstanceInventory","AWS::SSM::PatchCompliance","AWS::WAF::RateBasedRule","AWS::WAF::Rule","AWS::WAF::RuleGroup","AWS::WAF::WebACL","AWS::WAFRegional::RateBasedRule","AWS::WAFRegional::Rule","AWS::WAFRegional::RuleGroup","AWS::WAFRegional::WebACL","AWS::WAFv2::IPSet","AWS::WAFv2::ManagedRuleSet","AWS::WAFv2::RegexPatternSet","AWS::WAFv2::RuleGroup","AWS::WAFv2::WebACL","AWS::XRay::EncryptionConfig"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CFG_map = @{
    "ChronologicalOrder"=@("Get-CFGResourceConfigHistory")
    "ComplianceType"=@("Get-CFGAggregateComplianceDetailsByConfigRule")
    "ConfigRule_ConfigRuleState"=@("Write-CFGConfigRule")
    "ConfigRule_MaximumExecutionFrequency"=@("Write-CFGConfigRule")
    "ConfigRule_Source_Owner"=@("Write-CFGConfigRule")
    "DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency"=@("Write-CFGDeliveryChannel")
    "Filters_ComplianceType"=@("Get-CFGAggregateComplianceByConfigRuleList","Get-CFGConformancePackCompliance","Get-CFGConformancePackComplianceDetail")
    "Filters_MemberAccountRuleStatus"=@("Get-CFGOrganizationConfigRuleDetailedStatus")
    "Filters_ResourceType"=@("Get-CFGAggregateDiscoveredResourceCount")
    "Filters_Status"=@("Get-CFGOrganizationConformancePackDetailedStatus")
    "GroupByKey"=@("Get-CFGAggregateConfigRuleComplianceSummary","Get-CFGAggregateDiscoveredResourceCount")
    "OrganizationCustomRuleMetadata_MaximumExecutionFrequency"=@("Write-CFGOrganizationConfigRule")
    "OrganizationManagedRuleMetadata_MaximumExecutionFrequency"=@("Write-CFGOrganizationConfigRule")
    "ResourceIdentifier_ResourceType"=@("Get-CFGAggregateResourceConfig")
    "ResourceType"=@("Get-CFGAggregateDiscoveredResourceList","Get-CFGDiscoveredResource","Get-CFGResourceConfigHistory")
}

_awsArgumentCompleterRegistration $CFG_Completers $CFG_map

$CFG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CFG.$($commandName.Replace('-', ''))Cmdlet]"
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

$CFG_SelectMap = @{
    "Select"=@("Get-CFGAggregateResourceConfigBatch",
               "Get-CFGGetResourceConfigBatch",
               "Remove-CFGAggregationAuthorization",
               "Remove-CFGConfigRule",
               "Remove-CFGConfigurationAggregator",
               "Remove-CFGConfigurationRecorder",
               "Remove-CFGConformancePack",
               "Remove-CFGDeliveryChannel",
               "Remove-CFGEvaluationResult",
               "Remove-CFGOrganizationConfigRule",
               "Remove-CFGOrganizationConformancePack",
               "Remove-CFGPendingAggregationRequest",
               "Remove-CFGRemediationConfiguration",
               "Remove-CFGRemediationException",
               "Remove-CFGResourceConfig",
               "Remove-CFGRetentionConfiguration",
               "Submit-CFGConfigSnapshotDelivery",
               "Get-CFGAggregateComplianceByConfigRuleList",
               "Get-CFGAggregationAuthorizationList",
               "Get-CFGComplianceByConfigRule",
               "Get-CFGComplianceByResource",
               "Get-CFGConfigRuleEvaluationStatus",
               "Get-CFGConfigRule",
               "Get-CFGConfigurationAggregatorList",
               "Get-CFGConfigurationAggregatorSourcesStatus",
               "Get-CFGConfigurationRecorder",
               "Get-CFGConfigurationRecorderStatus",
               "Get-CFGConformancePackCompliance",
               "Get-CFGConformancePack",
               "Get-CFGConformancePackStatus",
               "Get-CFGDeliveryChannel",
               "Get-CFGDeliveryChannelStatus",
               "Get-CFGOrganizationConfigRule",
               "Get-CFGOrganizationConfigRuleStatus",
               "Get-CFGOrganizationConformancePack",
               "Get-CFGOrganizationConformancePackStatus",
               "Get-CFGPendingAggregationRequestList",
               "Get-CFGRemediationConfiguration",
               "Get-CFGRemediationException",
               "Get-CFGRemediationExecutionStatus",
               "Get-CFGRetentionConfiguration",
               "Get-CFGAggregateComplianceDetailsByConfigRule",
               "Get-CFGAggregateConfigRuleComplianceSummary",
               "Get-CFGAggregateDiscoveredResourceCount",
               "Get-CFGAggregateResourceConfig",
               "Get-CFGComplianceDetailsByConfigRule",
               "Get-CFGComplianceDetailsByResource",
               "Get-CFGComplianceSummaryByConfigRule",
               "Get-CFGComplianceSummaryByResourceType",
               "Get-CFGConformancePackComplianceDetail",
               "Get-CFGConformancePackComplianceSummary",
               "Get-CFGDiscoveredResourceCount",
               "Get-CFGOrganizationConfigRuleDetailedStatus",
               "Get-CFGOrganizationConformancePackDetailedStatus",
               "Get-CFGResourceConfigHistory",
               "Get-CFGAggregateDiscoveredResourceList",
               "Get-CFGDiscoveredResource",
               "Get-CFGResourceTag",
               "Write-CFGAggregationAuthorization",
               "Write-CFGConfigRule",
               "Write-CFGConfigurationAggregator",
               "Write-CFGConfigurationRecorder",
               "Write-CFGConformancePack",
               "Write-CFGDeliveryChannel",
               "Write-CFGEvaluation",
               "Write-CFGOrganizationConfigRule",
               "Write-CFGOrganizationConformancePack",
               "Write-CFGRemediationConfiguration",
               "Write-CFGRemediationException",
               "Write-CFGResourceConfig",
               "Write-CFGRetentionConfiguration",
               "Select-CFGAggregateResourceConfig",
               "Select-CFGResourceConfig",
               "Start-CFGConfigRulesEvaluation",
               "Start-CFGConfigurationRecorder",
               "Start-CFGRemediationExecution",
               "Stop-CFGConfigurationRecorder",
               "Add-CFGResourceTag",
               "Remove-CFGResourceTag")
}

_awsArgumentCompleterRegistration $CFG_SelectCompleters $CFG_SelectMap

