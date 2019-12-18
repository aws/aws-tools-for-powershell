/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Creates a new Elasticsearch domain. For more information, see <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-createupdatedomains.html#es-createdomains" target="_blank">Creating Elasticsearch Domains</a> in the <i>Amazon Elasticsearch
    /// Service Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "ESDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.ElasticsearchDomainStatus")]
    [AWSCmdlet("Calls the Amazon Elasticsearch CreateElasticsearchDomain API operation.", Operation = new[] {"CreateElasticsearchDomain"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.ElasticsearchDomainStatus or Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse",
        "This cmdlet returns an Amazon.Elasticsearch.Model.ElasticsearchDomainStatus object.",
        "The service call response (type Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewESDomainCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        #region Parameter AccessPolicy
        /// <summary>
        /// <para>
        /// <para> IAM access policy as a JSON-formatted string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessPolicies")]
        public System.String AccessPolicy { get; set; }
        #endregion
        
        #region Parameter AdvancedOption
        /// <summary>
        /// <para>
        /// <para> Option to allow references to indices in an HTTP request body. Must be <code>false</code>
        /// when configuring access to individual sub-resources. By default, the value is <code>true</code>.
        /// See <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-createupdatedomains.html#es-createdomain-configure-advanced-options" target="_blank">Configuration Advanced Options</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdvancedOptions")]
        public System.Collections.Hashtable AdvancedOption { get; set; }
        #endregion
        
        #region Parameter SnapshotOptions_AutomatedSnapshotStartHour
        /// <summary>
        /// <para>
        /// <para>Specifies the time, in UTC format, when the service takes a daily automated snapshot
        /// of the specified Elasticsearch domain. Default value is <code>0</code> hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotOptions_AutomatedSnapshotStartHour { get; set; }
        #endregion
        
        #region Parameter ZoneAwarenessConfig_AvailabilityZoneCount
        /// <summary>
        /// <para>
        /// <para>An integer value to indicate the number of availability zones for a domain when zone
        /// awareness is enabled. This should be equal to number of subnets if VPC endpoints is
        /// enabled</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchClusterConfig_ZoneAwarenessConfig_AvailabilityZoneCount")]
        public System.Int32? ZoneAwarenessConfig_AvailabilityZoneCount { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_DedicatedMasterCount
        /// <summary>
        /// <para>
        /// <para>Total number of dedicated master nodes, active and on standby, for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ElasticsearchClusterConfig_DedicatedMasterCount { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_DedicatedMasterEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean value to indicate whether a dedicated master node is enabled. See <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-managedomains.html#es-managedomains-dedicatedmasternodes" target="_blank">About Dedicated Master Nodes</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ElasticsearchClusterConfig_DedicatedMasterEnabled { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_DedicatedMasterType
        /// <summary>
        /// <para>
        /// <para>The instance type for a dedicated master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.ESPartitionInstanceType")]
        public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_DedicatedMasterType { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the Elasticsearch domain that you are creating. Domain names are unique
        /// across the domains owned by an account within an AWS region. Domain names must start
        /// with a lowercase letter and can contain the following characters: a-z (lowercase),
        /// 0-9, and - (hyphen).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter EBSOptions_EBSEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether EBS-based storage is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EBSOptions_EBSEnabled { get; set; }
        #endregion
        
        #region Parameter ElasticsearchVersion
        /// <summary>
        /// <para>
        /// <para>String of format X.Y to specify version for the Elasticsearch domain eg. "1.5" or
        /// "2.3". For more information, see <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-createupdatedomains.html#es-createdomains" target="_blank">Creating Elasticsearch Domains</a> in the <i>Amazon Elasticsearch
        /// Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchVersion { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies the option to enable Cognito for Kibana authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CognitoOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter NodeToNodeEncryptionOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Specify true to enable node-to-node encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NodeToNodeEncryptionOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRestOption
        /// <summary>
        /// <para>
        /// <para>Specifies the Encryption At Rest Options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAtRestOptions")]
        public Amazon.Elasticsearch.Model.EncryptionAtRestOptions EncryptionAtRestOption { get; set; }
        #endregion
        
        #region Parameter DomainEndpointOptions_EnforceHTTPS
        /// <summary>
        /// <para>
        /// <para>Specify if only HTTPS endpoint should be enabled for the Elasticsearch domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DomainEndpointOptions_EnforceHTTPS { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_IdentityPoolId
        /// <summary>
        /// <para>
        /// <para>Specifies the Cognito identity pool ID for Kibana authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoOptions_IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances in the specified domain cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ElasticsearchClusterConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type for an Elasticsearch cluster. UltraWarm instance types are not supported
        /// for data instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.ESPartitionInstanceType")]
        public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter EBSOptions_Iops
        /// <summary>
        /// <para>
        /// <para>Specifies the IOPD for a Provisioned IOPS EBS volume (SSD).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EBSOptions_Iops { get; set; }
        #endregion
        
        #region Parameter LogPublishingOption
        /// <summary>
        /// <para>
        /// <para>Map of <code>LogType</code> and <code>LogPublishingOption</code>, each containing
        /// options to publish a given type of Elasticsearch log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogPublishingOptions")]
        public System.Collections.Hashtable LogPublishingOption { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_RoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the role ARN that provides Elasticsearch permissions for accessing Cognito
        /// resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoOptions_RoleArn { get; set; }
        #endregion
        
        #region Parameter VPCOptions_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the security groups for VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VPCOptions_SecurityGroupIds")]
        public System.String[] VPCOptions_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VPCOptions_SubnetId
        /// <summary>
        /// <para>
        /// <para>Specifies the subnets for VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VPCOptions_SubnetIds")]
        public System.String[] VPCOptions_SubnetId { get; set; }
        #endregion
        
        #region Parameter DomainEndpointOptions_TLSSecurityPolicy
        /// <summary>
        /// <para>
        /// <para>Specify the TLS security policy that needs to be applied to the HTTPS endpoint of
        /// Elasticsearch domain. <br /> It can be one of the following values: <ul><li><b>Policy-Min-TLS-1-0-2019-07:
        /// </b> TLS security policy which supports TLSv1.0 and higher.</li><li><b>Policy-Min-TLS-1-2-2019-07:
        /// </b> TLS security policy which supports only TLSv1.2</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.TLSSecurityPolicy")]
        public Amazon.Elasticsearch.TLSSecurityPolicy DomainEndpointOptions_TLSSecurityPolicy { get; set; }
        #endregion
        
        #region Parameter CognitoOptions_UserPoolId
        /// <summary>
        /// <para>
        /// <para>Specifies the Cognito user pool ID for Kibana authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CognitoOptions_UserPoolId { get; set; }
        #endregion
        
        #region Parameter EBSOptions_VolumeSize
        /// <summary>
        /// <para>
        /// <para> Integer to specify the size of an EBS volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EBSOptions_VolumeSize { get; set; }
        #endregion
        
        #region Parameter EBSOptions_VolumeType
        /// <summary>
        /// <para>
        /// <para> Specifies the volume type for EBS-based storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.VolumeType")]
        public Amazon.Elasticsearch.VolumeType EBSOptions_VolumeType { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_WarmCount
        /// <summary>
        /// <para>
        /// <para>The number of warm nodes in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ElasticsearchClusterConfig_WarmCount { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_WarmEnabled
        /// <summary>
        /// <para>
        /// <para>True to enable warm storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ElasticsearchClusterConfig_WarmEnabled { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_WarmType
        /// <summary>
        /// <para>
        /// <para>The instance type for the Elasticsearch cluster's warm nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.ESWarmPartitionInstanceType")]
        public Amazon.Elasticsearch.ESWarmPartitionInstanceType ElasticsearchClusterConfig_WarmType { get; set; }
        #endregion
        
        #region Parameter ElasticsearchClusterConfig_ZoneAwarenessEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean value to indicate whether zone awareness is enabled. See <a href="http://docs.aws.amazon.com/elasticsearch-service/latest/developerguide/es-managedomains.html#es-managedomains-zoneawareness" target="_blank">About Zone Awareness</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ElasticsearchClusterConfig_ZoneAwarenessEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainStatus";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ESDomain (CreateElasticsearchDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse, NewESDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessPolicy = this.AccessPolicy;
            if (this.AdvancedOption != null)
            {
                context.AdvancedOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdvancedOption.Keys)
                {
                    context.AdvancedOption.Add((String)hashKey, (String)(this.AdvancedOption[hashKey]));
                }
            }
            context.CognitoOptions_Enabled = this.CognitoOptions_Enabled;
            context.CognitoOptions_IdentityPoolId = this.CognitoOptions_IdentityPoolId;
            context.CognitoOptions_RoleArn = this.CognitoOptions_RoleArn;
            context.CognitoOptions_UserPoolId = this.CognitoOptions_UserPoolId;
            context.DomainEndpointOptions_EnforceHTTPS = this.DomainEndpointOptions_EnforceHTTPS;
            context.DomainEndpointOptions_TLSSecurityPolicy = this.DomainEndpointOptions_TLSSecurityPolicy;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EBSOptions_EBSEnabled = this.EBSOptions_EBSEnabled;
            context.EBSOptions_Iops = this.EBSOptions_Iops;
            context.EBSOptions_VolumeSize = this.EBSOptions_VolumeSize;
            context.EBSOptions_VolumeType = this.EBSOptions_VolumeType;
            context.ElasticsearchClusterConfig_DedicatedMasterCount = this.ElasticsearchClusterConfig_DedicatedMasterCount;
            context.ElasticsearchClusterConfig_DedicatedMasterEnabled = this.ElasticsearchClusterConfig_DedicatedMasterEnabled;
            context.ElasticsearchClusterConfig_DedicatedMasterType = this.ElasticsearchClusterConfig_DedicatedMasterType;
            context.ElasticsearchClusterConfig_InstanceCount = this.ElasticsearchClusterConfig_InstanceCount;
            context.ElasticsearchClusterConfig_InstanceType = this.ElasticsearchClusterConfig_InstanceType;
            context.ElasticsearchClusterConfig_WarmCount = this.ElasticsearchClusterConfig_WarmCount;
            context.ElasticsearchClusterConfig_WarmEnabled = this.ElasticsearchClusterConfig_WarmEnabled;
            context.ElasticsearchClusterConfig_WarmType = this.ElasticsearchClusterConfig_WarmType;
            context.ZoneAwarenessConfig_AvailabilityZoneCount = this.ZoneAwarenessConfig_AvailabilityZoneCount;
            context.ElasticsearchClusterConfig_ZoneAwarenessEnabled = this.ElasticsearchClusterConfig_ZoneAwarenessEnabled;
            context.ElasticsearchVersion = this.ElasticsearchVersion;
            context.EncryptionAtRestOption = this.EncryptionAtRestOption;
            if (this.LogPublishingOption != null)
            {
                context.LogPublishingOption = new Dictionary<System.String, Amazon.Elasticsearch.Model.LogPublishingOption>(StringComparer.Ordinal);
                foreach (var hashKey in this.LogPublishingOption.Keys)
                {
                    context.LogPublishingOption.Add((String)hashKey, (LogPublishingOption)(this.LogPublishingOption[hashKey]));
                }
            }
            context.NodeToNodeEncryptionOptions_Enabled = this.NodeToNodeEncryptionOptions_Enabled;
            context.SnapshotOptions_AutomatedSnapshotStartHour = this.SnapshotOptions_AutomatedSnapshotStartHour;
            if (this.VPCOptions_SecurityGroupId != null)
            {
                context.VPCOptions_SecurityGroupId = new List<System.String>(this.VPCOptions_SecurityGroupId);
            }
            if (this.VPCOptions_SubnetId != null)
            {
                context.VPCOptions_SubnetId = new List<System.String>(this.VPCOptions_SubnetId);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Elasticsearch.Model.CreateElasticsearchDomainRequest();
            
            if (cmdletContext.AccessPolicy != null)
            {
                request.AccessPolicies = cmdletContext.AccessPolicy;
            }
            if (cmdletContext.AdvancedOption != null)
            {
                request.AdvancedOptions = cmdletContext.AdvancedOption;
            }
            
             // populate CognitoOptions
            var requestCognitoOptionsIsNull = true;
            request.CognitoOptions = new Amazon.Elasticsearch.Model.CognitoOptions();
            System.Boolean? requestCognitoOptions_cognitoOptions_Enabled = null;
            if (cmdletContext.CognitoOptions_Enabled != null)
            {
                requestCognitoOptions_cognitoOptions_Enabled = cmdletContext.CognitoOptions_Enabled.Value;
            }
            if (requestCognitoOptions_cognitoOptions_Enabled != null)
            {
                request.CognitoOptions.Enabled = requestCognitoOptions_cognitoOptions_Enabled.Value;
                requestCognitoOptionsIsNull = false;
            }
            System.String requestCognitoOptions_cognitoOptions_IdentityPoolId = null;
            if (cmdletContext.CognitoOptions_IdentityPoolId != null)
            {
                requestCognitoOptions_cognitoOptions_IdentityPoolId = cmdletContext.CognitoOptions_IdentityPoolId;
            }
            if (requestCognitoOptions_cognitoOptions_IdentityPoolId != null)
            {
                request.CognitoOptions.IdentityPoolId = requestCognitoOptions_cognitoOptions_IdentityPoolId;
                requestCognitoOptionsIsNull = false;
            }
            System.String requestCognitoOptions_cognitoOptions_RoleArn = null;
            if (cmdletContext.CognitoOptions_RoleArn != null)
            {
                requestCognitoOptions_cognitoOptions_RoleArn = cmdletContext.CognitoOptions_RoleArn;
            }
            if (requestCognitoOptions_cognitoOptions_RoleArn != null)
            {
                request.CognitoOptions.RoleArn = requestCognitoOptions_cognitoOptions_RoleArn;
                requestCognitoOptionsIsNull = false;
            }
            System.String requestCognitoOptions_cognitoOptions_UserPoolId = null;
            if (cmdletContext.CognitoOptions_UserPoolId != null)
            {
                requestCognitoOptions_cognitoOptions_UserPoolId = cmdletContext.CognitoOptions_UserPoolId;
            }
            if (requestCognitoOptions_cognitoOptions_UserPoolId != null)
            {
                request.CognitoOptions.UserPoolId = requestCognitoOptions_cognitoOptions_UserPoolId;
                requestCognitoOptionsIsNull = false;
            }
             // determine if request.CognitoOptions should be set to null
            if (requestCognitoOptionsIsNull)
            {
                request.CognitoOptions = null;
            }
            
             // populate DomainEndpointOptions
            var requestDomainEndpointOptionsIsNull = true;
            request.DomainEndpointOptions = new Amazon.Elasticsearch.Model.DomainEndpointOptions();
            System.Boolean? requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS = null;
            if (cmdletContext.DomainEndpointOptions_EnforceHTTPS != null)
            {
                requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS = cmdletContext.DomainEndpointOptions_EnforceHTTPS.Value;
            }
            if (requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS != null)
            {
                request.DomainEndpointOptions.EnforceHTTPS = requestDomainEndpointOptions_domainEndpointOptions_EnforceHTTPS.Value;
                requestDomainEndpointOptionsIsNull = false;
            }
            Amazon.Elasticsearch.TLSSecurityPolicy requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy = null;
            if (cmdletContext.DomainEndpointOptions_TLSSecurityPolicy != null)
            {
                requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy = cmdletContext.DomainEndpointOptions_TLSSecurityPolicy;
            }
            if (requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy != null)
            {
                request.DomainEndpointOptions.TLSSecurityPolicy = requestDomainEndpointOptions_domainEndpointOptions_TLSSecurityPolicy;
                requestDomainEndpointOptionsIsNull = false;
            }
             // determine if request.DomainEndpointOptions should be set to null
            if (requestDomainEndpointOptionsIsNull)
            {
                request.DomainEndpointOptions = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate EBSOptions
            var requestEBSOptionsIsNull = true;
            request.EBSOptions = new Amazon.Elasticsearch.Model.EBSOptions();
            System.Boolean? requestEBSOptions_eBSOptions_EBSEnabled = null;
            if (cmdletContext.EBSOptions_EBSEnabled != null)
            {
                requestEBSOptions_eBSOptions_EBSEnabled = cmdletContext.EBSOptions_EBSEnabled.Value;
            }
            if (requestEBSOptions_eBSOptions_EBSEnabled != null)
            {
                request.EBSOptions.EBSEnabled = requestEBSOptions_eBSOptions_EBSEnabled.Value;
                requestEBSOptionsIsNull = false;
            }
            System.Int32? requestEBSOptions_eBSOptions_Iops = null;
            if (cmdletContext.EBSOptions_Iops != null)
            {
                requestEBSOptions_eBSOptions_Iops = cmdletContext.EBSOptions_Iops.Value;
            }
            if (requestEBSOptions_eBSOptions_Iops != null)
            {
                request.EBSOptions.Iops = requestEBSOptions_eBSOptions_Iops.Value;
                requestEBSOptionsIsNull = false;
            }
            System.Int32? requestEBSOptions_eBSOptions_VolumeSize = null;
            if (cmdletContext.EBSOptions_VolumeSize != null)
            {
                requestEBSOptions_eBSOptions_VolumeSize = cmdletContext.EBSOptions_VolumeSize.Value;
            }
            if (requestEBSOptions_eBSOptions_VolumeSize != null)
            {
                request.EBSOptions.VolumeSize = requestEBSOptions_eBSOptions_VolumeSize.Value;
                requestEBSOptionsIsNull = false;
            }
            Amazon.Elasticsearch.VolumeType requestEBSOptions_eBSOptions_VolumeType = null;
            if (cmdletContext.EBSOptions_VolumeType != null)
            {
                requestEBSOptions_eBSOptions_VolumeType = cmdletContext.EBSOptions_VolumeType;
            }
            if (requestEBSOptions_eBSOptions_VolumeType != null)
            {
                request.EBSOptions.VolumeType = requestEBSOptions_eBSOptions_VolumeType;
                requestEBSOptionsIsNull = false;
            }
             // determine if request.EBSOptions should be set to null
            if (requestEBSOptionsIsNull)
            {
                request.EBSOptions = null;
            }
            
             // populate ElasticsearchClusterConfig
            var requestElasticsearchClusterConfigIsNull = true;
            request.ElasticsearchClusterConfig = new Amazon.Elasticsearch.Model.ElasticsearchClusterConfig();
            System.Int32? requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount = null;
            if (cmdletContext.ElasticsearchClusterConfig_DedicatedMasterCount != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount = cmdletContext.ElasticsearchClusterConfig_DedicatedMasterCount.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount != null)
            {
                request.ElasticsearchClusterConfig.DedicatedMasterCount = requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterCount.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Boolean? requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled = null;
            if (cmdletContext.ElasticsearchClusterConfig_DedicatedMasterEnabled != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled = cmdletContext.ElasticsearchClusterConfig_DedicatedMasterEnabled.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled != null)
            {
                request.ElasticsearchClusterConfig.DedicatedMasterEnabled = requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterEnabled.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            Amazon.Elasticsearch.ESPartitionInstanceType requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType = null;
            if (cmdletContext.ElasticsearchClusterConfig_DedicatedMasterType != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType = cmdletContext.ElasticsearchClusterConfig_DedicatedMasterType;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType != null)
            {
                request.ElasticsearchClusterConfig.DedicatedMasterType = requestElasticsearchClusterConfig_elasticsearchClusterConfig_DedicatedMasterType;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Int32? requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount = null;
            if (cmdletContext.ElasticsearchClusterConfig_InstanceCount != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount = cmdletContext.ElasticsearchClusterConfig_InstanceCount.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount != null)
            {
                request.ElasticsearchClusterConfig.InstanceCount = requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceCount.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            Amazon.Elasticsearch.ESPartitionInstanceType requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType = null;
            if (cmdletContext.ElasticsearchClusterConfig_InstanceType != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType = cmdletContext.ElasticsearchClusterConfig_InstanceType;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType != null)
            {
                request.ElasticsearchClusterConfig.InstanceType = requestElasticsearchClusterConfig_elasticsearchClusterConfig_InstanceType;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Int32? requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmCount = null;
            if (cmdletContext.ElasticsearchClusterConfig_WarmCount != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmCount = cmdletContext.ElasticsearchClusterConfig_WarmCount.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmCount != null)
            {
                request.ElasticsearchClusterConfig.WarmCount = requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmCount.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Boolean? requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmEnabled = null;
            if (cmdletContext.ElasticsearchClusterConfig_WarmEnabled != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmEnabled = cmdletContext.ElasticsearchClusterConfig_WarmEnabled.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmEnabled != null)
            {
                request.ElasticsearchClusterConfig.WarmEnabled = requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmEnabled.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            Amazon.Elasticsearch.ESWarmPartitionInstanceType requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmType = null;
            if (cmdletContext.ElasticsearchClusterConfig_WarmType != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmType = cmdletContext.ElasticsearchClusterConfig_WarmType;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmType != null)
            {
                request.ElasticsearchClusterConfig.WarmType = requestElasticsearchClusterConfig_elasticsearchClusterConfig_WarmType;
                requestElasticsearchClusterConfigIsNull = false;
            }
            System.Boolean? requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled = null;
            if (cmdletContext.ElasticsearchClusterConfig_ZoneAwarenessEnabled != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled = cmdletContext.ElasticsearchClusterConfig_ZoneAwarenessEnabled.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled != null)
            {
                request.ElasticsearchClusterConfig.ZoneAwarenessEnabled = requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessEnabled.Value;
                requestElasticsearchClusterConfigIsNull = false;
            }
            Amazon.Elasticsearch.Model.ZoneAwarenessConfig requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig = null;
            
             // populate ZoneAwarenessConfig
            var requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfigIsNull = true;
            requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig = new Amazon.Elasticsearch.Model.ZoneAwarenessConfig();
            System.Int32? requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount = null;
            if (cmdletContext.ZoneAwarenessConfig_AvailabilityZoneCount != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount = cmdletContext.ZoneAwarenessConfig_AvailabilityZoneCount.Value;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount != null)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig.AvailabilityZoneCount = requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig_zoneAwarenessConfig_AvailabilityZoneCount.Value;
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfigIsNull = false;
            }
             // determine if requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig should be set to null
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfigIsNull)
            {
                requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig = null;
            }
            if (requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig != null)
            {
                request.ElasticsearchClusterConfig.ZoneAwarenessConfig = requestElasticsearchClusterConfig_elasticsearchClusterConfig_ZoneAwarenessConfig;
                requestElasticsearchClusterConfigIsNull = false;
            }
             // determine if request.ElasticsearchClusterConfig should be set to null
            if (requestElasticsearchClusterConfigIsNull)
            {
                request.ElasticsearchClusterConfig = null;
            }
            if (cmdletContext.ElasticsearchVersion != null)
            {
                request.ElasticsearchVersion = cmdletContext.ElasticsearchVersion;
            }
            if (cmdletContext.EncryptionAtRestOption != null)
            {
                request.EncryptionAtRestOptions = cmdletContext.EncryptionAtRestOption;
            }
            if (cmdletContext.LogPublishingOption != null)
            {
                request.LogPublishingOptions = cmdletContext.LogPublishingOption;
            }
            
             // populate NodeToNodeEncryptionOptions
            var requestNodeToNodeEncryptionOptionsIsNull = true;
            request.NodeToNodeEncryptionOptions = new Amazon.Elasticsearch.Model.NodeToNodeEncryptionOptions();
            System.Boolean? requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled = null;
            if (cmdletContext.NodeToNodeEncryptionOptions_Enabled != null)
            {
                requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled = cmdletContext.NodeToNodeEncryptionOptions_Enabled.Value;
            }
            if (requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled != null)
            {
                request.NodeToNodeEncryptionOptions.Enabled = requestNodeToNodeEncryptionOptions_nodeToNodeEncryptionOptions_Enabled.Value;
                requestNodeToNodeEncryptionOptionsIsNull = false;
            }
             // determine if request.NodeToNodeEncryptionOptions should be set to null
            if (requestNodeToNodeEncryptionOptionsIsNull)
            {
                request.NodeToNodeEncryptionOptions = null;
            }
            
             // populate SnapshotOptions
            var requestSnapshotOptionsIsNull = true;
            request.SnapshotOptions = new Amazon.Elasticsearch.Model.SnapshotOptions();
            System.Int32? requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour = null;
            if (cmdletContext.SnapshotOptions_AutomatedSnapshotStartHour != null)
            {
                requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour = cmdletContext.SnapshotOptions_AutomatedSnapshotStartHour.Value;
            }
            if (requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour != null)
            {
                request.SnapshotOptions.AutomatedSnapshotStartHour = requestSnapshotOptions_snapshotOptions_AutomatedSnapshotStartHour.Value;
                requestSnapshotOptionsIsNull = false;
            }
             // determine if request.SnapshotOptions should be set to null
            if (requestSnapshotOptionsIsNull)
            {
                request.SnapshotOptions = null;
            }
            
             // populate VPCOptions
            var requestVPCOptionsIsNull = true;
            request.VPCOptions = new Amazon.Elasticsearch.Model.VPCOptions();
            List<System.String> requestVPCOptions_vPCOptions_SecurityGroupId = null;
            if (cmdletContext.VPCOptions_SecurityGroupId != null)
            {
                requestVPCOptions_vPCOptions_SecurityGroupId = cmdletContext.VPCOptions_SecurityGroupId;
            }
            if (requestVPCOptions_vPCOptions_SecurityGroupId != null)
            {
                request.VPCOptions.SecurityGroupIds = requestVPCOptions_vPCOptions_SecurityGroupId;
                requestVPCOptionsIsNull = false;
            }
            List<System.String> requestVPCOptions_vPCOptions_SubnetId = null;
            if (cmdletContext.VPCOptions_SubnetId != null)
            {
                requestVPCOptions_vPCOptions_SubnetId = cmdletContext.VPCOptions_SubnetId;
            }
            if (requestVPCOptions_vPCOptions_SubnetId != null)
            {
                request.VPCOptions.SubnetIds = requestVPCOptions_vPCOptions_SubnetId;
                requestVPCOptionsIsNull = false;
            }
             // determine if request.VPCOptions should be set to null
            if (requestVPCOptionsIsNull)
            {
                request.VPCOptions = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.CreateElasticsearchDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "CreateElasticsearchDomain");
            try
            {
                #if DESKTOP
                return client.CreateElasticsearchDomain(request);
                #elif CORECLR
                return client.CreateElasticsearchDomainAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AccessPolicy { get; set; }
            public Dictionary<System.String, System.String> AdvancedOption { get; set; }
            public System.Boolean? CognitoOptions_Enabled { get; set; }
            public System.String CognitoOptions_IdentityPoolId { get; set; }
            public System.String CognitoOptions_RoleArn { get; set; }
            public System.String CognitoOptions_UserPoolId { get; set; }
            public System.Boolean? DomainEndpointOptions_EnforceHTTPS { get; set; }
            public Amazon.Elasticsearch.TLSSecurityPolicy DomainEndpointOptions_TLSSecurityPolicy { get; set; }
            public System.String DomainName { get; set; }
            public System.Boolean? EBSOptions_EBSEnabled { get; set; }
            public System.Int32? EBSOptions_Iops { get; set; }
            public System.Int32? EBSOptions_VolumeSize { get; set; }
            public Amazon.Elasticsearch.VolumeType EBSOptions_VolumeType { get; set; }
            public System.Int32? ElasticsearchClusterConfig_DedicatedMasterCount { get; set; }
            public System.Boolean? ElasticsearchClusterConfig_DedicatedMasterEnabled { get; set; }
            public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_DedicatedMasterType { get; set; }
            public System.Int32? ElasticsearchClusterConfig_InstanceCount { get; set; }
            public Amazon.Elasticsearch.ESPartitionInstanceType ElasticsearchClusterConfig_InstanceType { get; set; }
            public System.Int32? ElasticsearchClusterConfig_WarmCount { get; set; }
            public System.Boolean? ElasticsearchClusterConfig_WarmEnabled { get; set; }
            public Amazon.Elasticsearch.ESWarmPartitionInstanceType ElasticsearchClusterConfig_WarmType { get; set; }
            public System.Int32? ZoneAwarenessConfig_AvailabilityZoneCount { get; set; }
            public System.Boolean? ElasticsearchClusterConfig_ZoneAwarenessEnabled { get; set; }
            public System.String ElasticsearchVersion { get; set; }
            public Amazon.Elasticsearch.Model.EncryptionAtRestOptions EncryptionAtRestOption { get; set; }
            public Dictionary<System.String, Amazon.Elasticsearch.Model.LogPublishingOption> LogPublishingOption { get; set; }
            public System.Boolean? NodeToNodeEncryptionOptions_Enabled { get; set; }
            public System.Int32? SnapshotOptions_AutomatedSnapshotStartHour { get; set; }
            public List<System.String> VPCOptions_SecurityGroupId { get; set; }
            public List<System.String> VPCOptions_SubnetId { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.CreateElasticsearchDomainResponse, NewESDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainStatus;
        }
        
    }
}
