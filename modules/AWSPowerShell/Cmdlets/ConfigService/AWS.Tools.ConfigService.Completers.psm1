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
        # Amazon.ConfigService.AggregateConformancePackComplianceSummaryGroupKey
        "Get-CFGAggregateConformancePackComplianceSummary/GroupByKey"
        {
            $v = "ACCOUNT_ID","AWS_REGION"
            break
        }

        # Amazon.ConfigService.ChronologicalOrder
        "Get-CFGResourceConfigHistory/ChronologicalOrder"
        {
            $v = "Forward","Reverse"
            break
        }

        # Amazon.ConfigService.ComplianceType
        {
            ($_ -eq "Get-CFGAggregateComplianceDetailsByConfigRule/ComplianceType") -Or
            ($_ -eq "Write-CFGExternalEvaluation/ExternalEvaluation_ComplianceType") -Or
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
            ($_ -eq "Get-CFGAggregateComplianceByConformancePack/Filters_ComplianceType") -Or
            ($_ -eq "Get-CFGConformancePackCompliance/Filters_ComplianceType") -Or
            ($_ -eq "Get-CFGConformancePackComplianceDetail/Filters_ComplianceType")
        }
        {
            $v = "COMPLIANT","INSUFFICIENT_DATA","NON_COMPLIANT"
            break
        }

        # Amazon.ConfigService.EvaluationMode
        {
            ($_ -eq "Start-CFGResourceEvaluation/EvaluationMode") -Or
            ($_ -eq "Get-CFGConfigRule/Filters_EvaluationMode") -Or
            ($_ -eq "Get-CFGResourceEvaluationList/Filters_EvaluationMode")
        }
        {
            $v = "DETECTIVE","PROACTIVE"
            break
        }

        # Amazon.ConfigService.MaximumExecutionFrequency
        {
            ($_ -eq "Write-CFGConfigRule/ConfigRule_MaximumExecutionFrequency") -Or
            ($_ -eq "Write-CFGDeliveryChannel/ConfigSnapshotDeliveryProperties_DeliveryFrequency") -Or
            ($_ -eq "Write-CFGOrganizationConfigRule/OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency") -Or
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
        "Write-CFGConfigRule/Source_Owner"
        {
            $v = "AWS","CUSTOM_LAMBDA","CUSTOM_POLICY"
            break
        }

        # Amazon.ConfigService.RecordingFrequency
        "Write-CFGConfigurationRecorder/RecordingMode_RecordingFrequency"
        {
            $v = "CONTINUOUS","DAILY"
            break
        }

        # Amazon.ConfigService.RecordingStrategyType
        "Write-CFGConfigurationRecorder/RecordingStrategy_UseOnly"
        {
            $v = "ALL_SUPPORTED_RESOURCE_TYPES","EXCLUSION_BY_RESOURCE_TYPES","INCLUSION_BY_RESOURCE_TYPES"
            break
        }

        # Amazon.ConfigService.ResourceConfigurationSchemaType
        "Start-CFGResourceEvaluation/ResourceDetails_ResourceConfigurationSchemaType"
        {
            $v = "CFN_RESOURCE_SCHEMA"
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
            $v = "AWS::AccessAnalyzer::Analyzer","AWS::ACM::Certificate","AWS::ACMPCA::CertificateAuthority","AWS::ACMPCA::CertificateAuthorityActivation","AWS::AmazonMQ::Broker","AWS::Amplify::App","AWS::Amplify::Branch","AWS::ApiGateway::RestApi","AWS::ApiGateway::Stage","AWS::ApiGatewayV2::Api","AWS::ApiGatewayV2::Stage","AWS::AppConfig::Application","AWS::AppConfig::ConfigurationProfile","AWS::AppConfig::DeploymentStrategy","AWS::AppConfig::Environment","AWS::AppConfig::HostedConfigurationVersion","AWS::AppFlow::Flow","AWS::AppIntegrations::EventIntegration","AWS::AppMesh::GatewayRoute","AWS::AppMesh::Mesh","AWS::AppMesh::Route","AWS::AppMesh::VirtualGateway","AWS::AppMesh::VirtualNode","AWS::AppMesh::VirtualRouter","AWS::AppMesh::VirtualService","AWS::AppRunner::Service","AWS::AppRunner::VpcConnector","AWS::AppStream::Application","AWS::AppStream::DirectoryConfig","AWS::AppStream::Fleet","AWS::AppStream::Stack","AWS::AppSync::GraphQLApi","AWS::APS::RuleGroupsNamespace","AWS::Athena::DataCatalog","AWS::Athena::PreparedStatement","AWS::Athena::WorkGroup","AWS::AuditManager::Assessment","AWS::AutoScaling::AutoScalingGroup","AWS::AutoScaling::LaunchConfiguration","AWS::AutoScaling::ScalingPolicy","AWS::AutoScaling::ScheduledAction","AWS::AutoScaling::WarmPool","AWS::Backup::BackupPlan","AWS::Backup::BackupSelection","AWS::Backup::BackupVault","AWS::Backup::RecoveryPoint","AWS::Backup::ReportPlan","AWS::Batch::ComputeEnvironment","AWS::Batch::JobQueue","AWS::Batch::SchedulingPolicy","AWS::Budgets::BudgetsAction","AWS::Cassandra::Keyspace","AWS::Cloud9::EnvironmentEC2","AWS::CloudFormation::Stack","AWS::CloudFront::Distribution","AWS::CloudFront::StreamingDistribution","AWS::CloudTrail::Trail","AWS::CloudWatch::Alarm","AWS::CloudWatch::MetricStream","AWS::CodeArtifact::Repository","AWS::CodeBuild::Project","AWS::CodeBuild::ReportGroup","AWS::CodeDeploy::Application","AWS::CodeDeploy::DeploymentConfig","AWS::CodeDeploy::DeploymentGroup","AWS::CodeGuruProfiler::ProfilingGroup","AWS::CodeGuruReviewer::RepositoryAssociation","AWS::CodePipeline::Pipeline","AWS::Cognito::UserPool","AWS::Cognito::UserPoolClient","AWS::Cognito::UserPoolGroup","AWS::Config::ConformancePackCompliance","AWS::Config::ResourceCompliance","AWS::Connect::Instance","AWS::Connect::PhoneNumber","AWS::Connect::QuickConnect","AWS::CustomerProfiles::Domain","AWS::CustomerProfiles::ObjectType","AWS::DataSync::LocationEFS","AWS::DataSync::LocationFSxLustre","AWS::DataSync::LocationFSxWindows","AWS::DataSync::LocationHDFS","AWS::DataSync::LocationNFS","AWS::DataSync::LocationObjectStorage","AWS::DataSync::LocationS3","AWS::DataSync::LocationSMB","AWS::DataSync::Task","AWS::Detective::Graph","AWS::DeviceFarm::InstanceProfile","AWS::DeviceFarm::Project","AWS::DeviceFarm::TestGridProject","AWS::DMS::Certificate","AWS::DMS::Endpoint","AWS::DMS::EventSubscription","AWS::DMS::ReplicationSubnetGroup","AWS::DynamoDB::Table","AWS::EC2::CapacityReservation","AWS::EC2::CarrierGateway","AWS::EC2::ClientVpnEndpoint","AWS::EC2::CustomerGateway","AWS::EC2::DHCPOptions","AWS::EC2::EC2Fleet","AWS::EC2::EgressOnlyInternetGateway","AWS::EC2::EIP","AWS::EC2::FlowLog","AWS::EC2::Host","AWS::EC2::Instance","AWS::EC2::InternetGateway","AWS::EC2::IPAM","AWS::EC2::IPAMPool","AWS::EC2::IPAMScope","AWS::EC2::LaunchTemplate","AWS::EC2::NatGateway","AWS::EC2::NetworkAcl","AWS::EC2::NetworkInsightsAccessScope","AWS::EC2::NetworkInsightsAccessScopeAnalysis","AWS::EC2::NetworkInsightsAnalysis","AWS::EC2::NetworkInsightsPath","AWS::EC2::NetworkInterface","AWS::EC2::PrefixList","AWS::EC2::RegisteredHAInstance","AWS::EC2::RouteTable","AWS::EC2::SecurityGroup","AWS::EC2::SpotFleet","AWS::EC2::Subnet","AWS::EC2::SubnetRouteTableAssociation","AWS::EC2::TrafficMirrorFilter","AWS::EC2::TrafficMirrorSession","AWS::EC2::TrafficMirrorTarget","AWS::EC2::TransitGateway","AWS::EC2::TransitGatewayAttachment","AWS::EC2::TransitGatewayConnect","AWS::EC2::TransitGatewayMulticastDomain","AWS::EC2::TransitGatewayRouteTable","AWS::EC2::Volume","AWS::EC2::VPC","AWS::EC2::VPCEndpoint","AWS::EC2::VPCEndpointService","AWS::EC2::VPCPeeringConnection","AWS::EC2::VPNConnection","AWS::EC2::VPNGateway","AWS::ECR::PublicRepository","AWS::ECR::PullThroughCacheRule","AWS::ECR::RegistryPolicy","AWS::ECR::Repository","AWS::ECS::CapacityProvider","AWS::ECS::Cluster","AWS::ECS::Service","AWS::ECS::TaskDefinition","AWS::ECS::TaskSet","AWS::EFS::AccessPoint","AWS::EFS::FileSystem","AWS::EKS::Addon","AWS::EKS::Cluster","AWS::EKS::FargateProfile","AWS::EKS::IdentityProviderConfig","AWS::ElasticBeanstalk::Application","AWS::ElasticBeanstalk::ApplicationVersion","AWS::ElasticBeanstalk::Environment","AWS::ElasticLoadBalancing::LoadBalancer","AWS::ElasticLoadBalancingV2::Listener","AWS::ElasticLoadBalancingV2::LoadBalancer","AWS::Elasticsearch::Domain","AWS::EMR::SecurityConfiguration","AWS::Events::ApiDestination","AWS::Events::Archive","AWS::Events::Connection","AWS::Events::Endpoint","AWS::Events::EventBus","AWS::Events::Rule","AWS::EventSchemas::Discoverer","AWS::EventSchemas::Registry","AWS::EventSchemas::RegistryPolicy","AWS::EventSchemas::Schema","AWS::Evidently::Launch","AWS::Evidently::Project","AWS::FIS::ExperimentTemplate","AWS::Forecast::Dataset","AWS::Forecast::DatasetGroup","AWS::FraudDetector::EntityType","AWS::FraudDetector::Label","AWS::FraudDetector::Outcome","AWS::FraudDetector::Variable","AWS::GlobalAccelerator::Accelerator","AWS::GlobalAccelerator::EndpointGroup","AWS::GlobalAccelerator::Listener","AWS::Glue::Classifier","AWS::Glue::Job","AWS::Glue::MLTransform","AWS::Grafana::Workspace","AWS::GreengrassV2::ComponentVersion","AWS::GroundStation::Config","AWS::GroundStation::DataflowEndpointGroup","AWS::GroundStation::MissionProfile","AWS::GuardDuty::Detector","AWS::GuardDuty::Filter","AWS::GuardDuty::IPSet","AWS::GuardDuty::ThreatIntelSet","AWS::HealthLake::FHIRDatastore","AWS::IAM::Group","AWS::IAM::InstanceProfile","AWS::IAM::Policy","AWS::IAM::Role","AWS::IAM::SAMLProvider","AWS::IAM::ServerCertificate","AWS::IAM::User","AWS::ImageBuilder::ContainerRecipe","AWS::ImageBuilder::DistributionConfiguration","AWS::ImageBuilder::ImagePipeline","AWS::ImageBuilder::ImageRecipe","AWS::ImageBuilder::InfrastructureConfiguration","AWS::InspectorV2::Filter","AWS::IoT::AccountAuditConfiguration","AWS::IoT::Authorizer","AWS::IoT::CACertificate","AWS::IoT::CustomMetric","AWS::IoT::Dimension","AWS::IoT::FleetMetric","AWS::IoT::JobTemplate","AWS::IoT::MitigationAction","AWS::IoT::Policy","AWS::IoT::ProvisioningTemplate","AWS::IoT::RoleAlias","AWS::IoT::ScheduledAudit","AWS::IoT::SecurityProfile","AWS::IoTAnalytics::Channel","AWS::IoTAnalytics::Dataset","AWS::IoTAnalytics::Datastore","AWS::IoTAnalytics::Pipeline","AWS::IoTEvents::AlarmModel","AWS::IoTEvents::DetectorModel","AWS::IoTEvents::Input","AWS::IoTSiteWise::AssetModel","AWS::IoTSiteWise::Dashboard","AWS::IoTSiteWise::Gateway","AWS::IoTSiteWise::Portal","AWS::IoTSiteWise::Project","AWS::IoTTwinMaker::ComponentType","AWS::IoTTwinMaker::Entity","AWS::IoTTwinMaker::Scene","AWS::IoTTwinMaker::SyncJob","AWS::IoTTwinMaker::Workspace","AWS::IoTWireless::FuotaTask","AWS::IoTWireless::MulticastGroup","AWS::IoTWireless::ServiceProfile","AWS::IVS::Channel","AWS::IVS::PlaybackKeyPair","AWS::IVS::RecordingConfiguration","AWS::KafkaConnect::Connector","AWS::Kendra::Index","AWS::Kinesis::Stream","AWS::Kinesis::StreamConsumer","AWS::KinesisAnalyticsV2::Application","AWS::KinesisFirehose::DeliveryStream","AWS::KinesisVideo::SignalingChannel","AWS::KinesisVideo::Stream","AWS::KMS::Alias","AWS::KMS::Key","AWS::Lambda::CodeSigningConfig","AWS::Lambda::Function","AWS::Lex::Bot","AWS::Lex::BotAlias","AWS::Lightsail::Bucket","AWS::Lightsail::Certificate","AWS::Lightsail::Disk","AWS::Lightsail::StaticIp","AWS::Logs::Destination","AWS::LookoutMetrics::Alert","AWS::LookoutVision::Project","AWS::M2::Environment","AWS::MediaConnect::FlowEntitlement","AWS::MediaConnect::FlowSource","AWS::MediaConnect::FlowVpcInterface","AWS::MediaPackage::PackagingConfiguration","AWS::MediaPackage::PackagingGroup","AWS::MediaTailor::PlaybackConfiguration","AWS::MSK::BatchScramSecret","AWS::MSK::Cluster","AWS::MSK::Configuration","AWS::NetworkFirewall::Firewall","AWS::NetworkFirewall::FirewallPolicy","AWS::NetworkFirewall::RuleGroup","AWS::NetworkManager::ConnectPeer","AWS::NetworkManager::CustomerGatewayAssociation","AWS::NetworkManager::Device","AWS::NetworkManager::GlobalNetwork","AWS::NetworkManager::Link","AWS::NetworkManager::LinkAssociation","AWS::NetworkManager::Site","AWS::NetworkManager::TransitGatewayRegistration","AWS::OpenSearch::Domain","AWS::Panorama::Package","AWS::Personalize::Dataset","AWS::Personalize::DatasetGroup","AWS::Personalize::Schema","AWS::Personalize::Solution","AWS::Pinpoint::App","AWS::Pinpoint::ApplicationSettings","AWS::Pinpoint::Campaign","AWS::Pinpoint::EmailChannel","AWS::Pinpoint::EmailTemplate","AWS::Pinpoint::EventStream","AWS::Pinpoint::InAppTemplate","AWS::Pinpoint::Segment","AWS::QLDB::Ledger","AWS::QuickSight::DataSource","AWS::QuickSight::Template","AWS::QuickSight::Theme","AWS::RDS::DBCluster","AWS::RDS::DBClusterSnapshot","AWS::RDS::DBInstance","AWS::RDS::DBSecurityGroup","AWS::RDS::DBSnapshot","AWS::RDS::DBSubnetGroup","AWS::RDS::EventSubscription","AWS::RDS::GlobalCluster","AWS::RDS::OptionGroup","AWS::Redshift::Cluster","AWS::Redshift::ClusterParameterGroup","AWS::Redshift::ClusterSecurityGroup","AWS::Redshift::ClusterSnapshot","AWS::Redshift::ClusterSubnetGroup","AWS::Redshift::EndpointAccess","AWS::Redshift::EventSubscription","AWS::Redshift::ScheduledAction","AWS::ResilienceHub::App","AWS::ResilienceHub::ResiliencyPolicy","AWS::ResourceExplorer2::Index","AWS::RoboMaker::RobotApplication","AWS::RoboMaker::RobotApplicationVersion","AWS::RoboMaker::SimulationApplication","AWS::Route53::HostedZone","AWS::Route53RecoveryControl::Cluster","AWS::Route53RecoveryControl::ControlPanel","AWS::Route53RecoveryControl::RoutingControl","AWS::Route53RecoveryControl::SafetyRule","AWS::Route53RecoveryReadiness::Cell","AWS::Route53RecoveryReadiness::ReadinessCheck","AWS::Route53RecoveryReadiness::RecoveryGroup","AWS::Route53RecoveryReadiness::ResourceSet","AWS::Route53Resolver::FirewallDomainList","AWS::Route53Resolver::FirewallRuleGroup","AWS::Route53Resolver::FirewallRuleGroupAssociation","AWS::Route53Resolver::ResolverEndpoint","AWS::Route53Resolver::ResolverQueryLoggingConfig","AWS::Route53Resolver::ResolverQueryLoggingConfigAssociation","AWS::Route53Resolver::ResolverRule","AWS::Route53Resolver::ResolverRuleAssociation","AWS::RUM::AppMonitor","AWS::S3::AccessPoint","AWS::S3::AccountPublicAccessBlock","AWS::S3::Bucket","AWS::S3::MultiRegionAccessPoint","AWS::S3::StorageLens","AWS::SageMaker::AppImageConfig","AWS::SageMaker::CodeRepository","AWS::SageMaker::Domain","AWS::SageMaker::FeatureGroup","AWS::SageMaker::Image","AWS::SageMaker::Model","AWS::SageMaker::NotebookInstanceLifecycleConfig","AWS::SageMaker::Workteam","AWS::SecretsManager::Secret","AWS::ServiceCatalog::CloudFormationProduct","AWS::ServiceCatalog::CloudFormationProvisionedProduct","AWS::ServiceCatalog::Portfolio","AWS::ServiceDiscovery::HttpNamespace","AWS::ServiceDiscovery::Instance","AWS::ServiceDiscovery::PublicDnsNamespace","AWS::ServiceDiscovery::Service","AWS::SES::ConfigurationSet","AWS::SES::ContactList","AWS::SES::ReceiptFilter","AWS::SES::ReceiptRuleSet","AWS::SES::Template","AWS::Shield::Protection","AWS::ShieldRegional::Protection","AWS::Signer::SigningProfile","AWS::SNS::Topic","AWS::SQS::Queue","AWS::SSM::AssociationCompliance","AWS::SSM::Document","AWS::SSM::FileData","AWS::SSM::ManagedInstanceInventory","AWS::SSM::PatchCompliance","AWS::StepFunctions::Activity","AWS::StepFunctions::StateMachine","AWS::Transfer::Agreement","AWS::Transfer::Certificate","AWS::Transfer::Connector","AWS::Transfer::Workflow","AWS::WAF::RateBasedRule","AWS::WAF::Rule","AWS::WAF::RuleGroup","AWS::WAF::WebACL","AWS::WAFRegional::RateBasedRule","AWS::WAFRegional::Rule","AWS::WAFRegional::RuleGroup","AWS::WAFRegional::WebACL","AWS::WAFv2::IPSet","AWS::WAFv2::ManagedRuleSet","AWS::WAFv2::RegexPatternSet","AWS::WAFv2::RuleGroup","AWS::WAFv2::WebACL","AWS::WorkSpaces::ConnectionAlias","AWS::WorkSpaces::Workspace","AWS::XRay::EncryptionConfig"
            break
        }

        # Amazon.ConfigService.SortBy
        "Get-CFGConformancePackComplianceScoreList/SortBy"
        {
            $v = "SCORE"
            break
        }

        # Amazon.ConfigService.SortOrder
        "Get-CFGConformancePackComplianceScoreList/SortOrder"
        {
            $v = "ASCENDING","DESCENDING"
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
    "ConfigSnapshotDeliveryProperties_DeliveryFrequency"=@("Write-CFGDeliveryChannel")
    "EvaluationMode"=@("Start-CFGResourceEvaluation")
    "ExternalEvaluation_ComplianceType"=@("Write-CFGExternalEvaluation")
    "Filters_ComplianceType"=@("Get-CFGAggregateComplianceByConfigRuleList","Get-CFGAggregateComplianceByConformancePack","Get-CFGConformancePackCompliance","Get-CFGConformancePackComplianceDetail")
    "Filters_EvaluationMode"=@("Get-CFGConfigRule","Get-CFGResourceEvaluationList")
    "Filters_MemberAccountRuleStatus"=@("Get-CFGOrganizationConfigRuleDetailedStatus")
    "Filters_ResourceType"=@("Get-CFGAggregateDiscoveredResourceCount")
    "Filters_Status"=@("Get-CFGOrganizationConformancePackDetailedStatus")
    "GroupByKey"=@("Get-CFGAggregateConfigRuleComplianceSummary","Get-CFGAggregateConformancePackComplianceSummary","Get-CFGAggregateDiscoveredResourceCount")
    "OrganizationCustomPolicyRuleMetadata_MaximumExecutionFrequency"=@("Write-CFGOrganizationConfigRule")
    "OrganizationCustomRuleMetadata_MaximumExecutionFrequency"=@("Write-CFGOrganizationConfigRule")
    "OrganizationManagedRuleMetadata_MaximumExecutionFrequency"=@("Write-CFGOrganizationConfigRule")
    "RecordingMode_RecordingFrequency"=@("Write-CFGConfigurationRecorder")
    "RecordingStrategy_UseOnly"=@("Write-CFGConfigurationRecorder")
    "ResourceDetails_ResourceConfigurationSchemaType"=@("Start-CFGResourceEvaluation")
    "ResourceIdentifier_ResourceType"=@("Get-CFGAggregateResourceConfig")
    "ResourceType"=@("Get-CFGAggregateDiscoveredResourceList","Get-CFGDiscoveredResource","Get-CFGResourceConfigHistory")
    "SortBy"=@("Get-CFGConformancePackComplianceScoreList")
    "SortOrder"=@("Get-CFGConformancePackComplianceScoreList")
    "Source_Owner"=@("Write-CFGConfigRule")
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
               "Remove-CFGStoredQuery",
               "Submit-CFGConfigSnapshotDelivery",
               "Get-CFGAggregateComplianceByConfigRuleList",
               "Get-CFGAggregateComplianceByConformancePack",
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
               "Get-CFGAggregateConformancePackComplianceSummary",
               "Get-CFGAggregateDiscoveredResourceCount",
               "Get-CFGAggregateResourceConfig",
               "Get-CFGComplianceDetailsByConfigRule",
               "Get-CFGComplianceDetailsByResource",
               "Get-CFGComplianceSummaryByConfigRule",
               "Get-CFGComplianceSummaryByResourceType",
               "Get-CFGConformancePackComplianceDetail",
               "Get-CFGConformancePackComplianceSummary",
               "Get-CFGCustomRulePolicy",
               "Get-CFGDiscoveredResourceCount",
               "Get-CFGOrganizationConfigRuleDetailedStatus",
               "Get-CFGOrganizationConformancePackDetailedStatus",
               "Get-CFGOrganizationCustomRulePolicy",
               "Get-CFGResourceConfigHistory",
               "Get-CFGResourceEvaluationSummary",
               "Get-CFGStoredQuery",
               "Get-CFGAggregateDiscoveredResourceList",
               "Get-CFGConformancePackComplianceScoreList",
               "Get-CFGDiscoveredResource",
               "Get-CFGResourceEvaluationList",
               "Get-CFGStoredQueryList",
               "Get-CFGResourceTag",
               "Write-CFGAggregationAuthorization",
               "Write-CFGConfigRule",
               "Write-CFGConfigurationAggregator",
               "Write-CFGConfigurationRecorder",
               "Write-CFGConformancePack",
               "Write-CFGDeliveryChannel",
               "Write-CFGEvaluation",
               "Write-CFGExternalEvaluation",
               "Write-CFGOrganizationConfigRule",
               "Write-CFGOrganizationConformancePack",
               "Write-CFGRemediationConfiguration",
               "Write-CFGRemediationException",
               "Write-CFGResourceConfig",
               "Write-CFGRetentionConfiguration",
               "Write-CFGStoredQuery",
               "Select-CFGAggregateResourceConfig",
               "Select-CFGResourceConfig",
               "Start-CFGConfigRulesEvaluation",
               "Start-CFGConfigurationRecorder",
               "Start-CFGRemediationExecution",
               "Start-CFGResourceEvaluation",
               "Stop-CFGConfigurationRecorder",
               "Add-CFGResourceTag",
               "Remove-CFGResourceTag")
}

_awsArgumentCompleterRegistration $CFG_SelectCompleters $CFG_SelectMap

