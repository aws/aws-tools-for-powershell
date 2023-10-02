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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Creates a new MSK cluster.
    /// </summary>
    [Cmdlet("New", "MSKClusterV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.CreateClusterV2Response")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) CreateClusterV2 API operation.", Operation = new[] {"CreateClusterV2"}, SelectReturnType = typeof(Amazon.Kafka.Model.CreateClusterV2Response))]
    [AWSCmdletOutput("Amazon.Kafka.Model.CreateClusterV2Response",
        "This cmdlet returns an Amazon.Kafka.Model.CreateClusterV2Response object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMSKClusterV2Cmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationInfo_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_ConfigurationInfo_Arn")]
        public System.String ConfigurationInfo_Arn { get; set; }
        #endregion
        
        #region Parameter Provisioned_BrokerNodeGroupInfo
        /// <summary>
        /// <para>
        /// <para>Information about the brokers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kafka.Model.BrokerNodeGroupInfo Provisioned_BrokerNodeGroupInfo { get; set; }
        #endregion
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_LoggingInfo_BrokerLogs_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter Tls_CertificateAuthorityArnList
        /// <summary>
        /// <para>
        /// <para>List of ACM Certificate Authority ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_ClientAuthentication_Tls_CertificateAuthorityArnList")]
        public System.String[] Tls_CertificateAuthorityArnList { get; set; }
        #endregion
        
        #region Parameter EncryptionInTransit_ClientBroker
        /// <summary>
        /// <para>
        /// <para>Indicates the encryption setting for data in transit between clients and brokers.
        /// The following are the possible values.</para><para>               TLS means that client-broker communication is enabled with TLS only.</para><para>               TLS_PLAINTEXT means that client-broker communication is enabled for
        /// both TLS-encrypted, as well as plaintext data.</para><para>               PLAINTEXT means that client-broker communication is enabled in plaintext
        /// only.</para><para>The default value is TLS_PLAINTEXT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_EncryptionInfo_EncryptionInTransit_ClientBroker")]
        [AWSConstantClassSource("Amazon.Kafka.ClientBroker")]
        public Amazon.Kafka.ClientBroker EncryptionInTransit_ClientBroker { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRest_DataVolumeKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS KMS key for encrypting data at rest. If you don't specify a KMS
        /// key, MSK creates one for you and uses it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId")]
        public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
        #endregion
        
        #region Parameter Firehose_DeliveryStream
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_LoggingInfo_BrokerLogs_Firehose_DeliveryStream")]
        public System.String Firehose_DeliveryStream { get; set; }
        #endregion
        
        #region Parameter Provisioned_ClientAuthentication_Sasl_Iam_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether IAM access control is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Provisioned_ClientAuthentication_Sasl_Iam_Enabled { get; set; }
        #endregion
        
        #region Parameter Scram_Enabled
        /// <summary>
        /// <para>
        /// <para>SASL/SCRAM authentication is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_ClientAuthentication_Sasl_Scram_Enabled")]
        public System.Boolean? Scram_Enabled { get; set; }
        #endregion
        
        #region Parameter Tls_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to turn on or turn off TLS authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_ClientAuthentication_Tls_Enabled")]
        public System.Boolean? Tls_Enabled { get; set; }
        #endregion
        
        #region Parameter Unauthenticated_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to turn on or turn off unauthenticated traffic to your
        /// cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_ClientAuthentication_Unauthenticated_Enabled")]
        public System.Boolean? Unauthenticated_Enabled { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_Enabled")]
        public System.Boolean? CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter Firehose_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_LoggingInfo_BrokerLogs_Firehose_Enabled")]
        public System.Boolean? Firehose_Enabled { get; set; }
        #endregion
        
        #region Parameter S3_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_LoggingInfo_BrokerLogs_S3_Enabled")]
        public System.Boolean? S3_Enabled { get; set; }
        #endregion
        
        #region Parameter Serverless_ClientAuthentication_Sasl_Iam_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether IAM access control is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Serverless_ClientAuthentication_Sasl_Iam_Enabled { get; set; }
        #endregion
        
        #region Parameter JmxExporter_EnabledInBroker
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to turn on or turn off the JMX Exporter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_OpenMonitoring_Prometheus_JmxExporter_EnabledInBroker")]
        public System.Boolean? JmxExporter_EnabledInBroker { get; set; }
        #endregion
        
        #region Parameter NodeExporter_EnabledInBroker
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to turn on or turn off the Node Exporter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_OpenMonitoring_Prometheus_NodeExporter_EnabledInBroker")]
        public System.Boolean? NodeExporter_EnabledInBroker { get; set; }
        #endregion
        
        #region Parameter Provisioned_EnhancedMonitoring
        /// <summary>
        /// <para>
        /// <para>Specifies the level of monitoring for the MSK cluster. The possible values are DEFAULT,
        /// PER_BROKER, PER_TOPIC_PER_BROKER, and PER_TOPIC_PER_PARTITION.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.EnhancedMonitoring")]
        public Amazon.Kafka.EnhancedMonitoring Provisioned_EnhancedMonitoring { get; set; }
        #endregion
        
        #region Parameter EncryptionInTransit_InCluster
        /// <summary>
        /// <para>
        /// <para>When set to true, it indicates that data communication among the broker nodes of the
        /// cluster is encrypted. When set to false, the communication happens in plaintext.</para><para>The default value is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_EncryptionInfo_EncryptionInTransit_InCluster")]
        public System.Boolean? EncryptionInTransit_InCluster { get; set; }
        #endregion
        
        #region Parameter Provisioned_KafkaVersion
        /// <summary>
        /// <para>
        /// <para>The Apache Kafka version that you want for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provisioned_KafkaVersion { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_LogGroup")]
        public System.String CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter Provisioned_NumberOfBrokerNode
        /// <summary>
        /// <para>
        /// <para>The number of broker nodes in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_NumberOfBrokerNodes")]
        public System.Int32? Provisioned_NumberOfBrokerNode { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_LoggingInfo_BrokerLogs_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter ConfigurationInfo_Revision
        /// <summary>
        /// <para>
        /// <para>The revision of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provisioned_ConfigurationInfo_Revision")]
        public System.Int64? ConfigurationInfo_Revision { get; set; }
        #endregion
        
        #region Parameter Provisioned_StorageMode
        /// <summary>
        /// <para>
        /// <para>This controls storage mode for supported storage tiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.StorageMode")]
        public Amazon.Kafka.StorageMode Provisioned_StorageMode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tags that you want the cluster to have.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Serverless_VpcConfig
        /// <summary>
        /// <para>
        /// <para>The configuration of the Amazon VPCs for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Serverless_VpcConfigs")]
        public Amazon.Kafka.Model.VpcConfig[] Serverless_VpcConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.CreateClusterV2Response).
        /// Specifying the name of a property of type Amazon.Kafka.Model.CreateClusterV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKClusterV2 (CreateClusterV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.CreateClusterV2Response, NewMSKClusterV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Provisioned_BrokerNodeGroupInfo = this.Provisioned_BrokerNodeGroupInfo;
            context.Provisioned_ClientAuthentication_Sasl_Iam_Enabled = this.Provisioned_ClientAuthentication_Sasl_Iam_Enabled;
            context.Scram_Enabled = this.Scram_Enabled;
            if (this.Tls_CertificateAuthorityArnList != null)
            {
                context.Tls_CertificateAuthorityArnList = new List<System.String>(this.Tls_CertificateAuthorityArnList);
            }
            context.Tls_Enabled = this.Tls_Enabled;
            context.Unauthenticated_Enabled = this.Unauthenticated_Enabled;
            context.ConfigurationInfo_Arn = this.ConfigurationInfo_Arn;
            context.ConfigurationInfo_Revision = this.ConfigurationInfo_Revision;
            context.EncryptionAtRest_DataVolumeKMSKeyId = this.EncryptionAtRest_DataVolumeKMSKeyId;
            context.EncryptionInTransit_ClientBroker = this.EncryptionInTransit_ClientBroker;
            context.EncryptionInTransit_InCluster = this.EncryptionInTransit_InCluster;
            context.Provisioned_EnhancedMonitoring = this.Provisioned_EnhancedMonitoring;
            context.Provisioned_KafkaVersion = this.Provisioned_KafkaVersion;
            context.CloudWatchLogs_Enabled = this.CloudWatchLogs_Enabled;
            context.CloudWatchLogs_LogGroup = this.CloudWatchLogs_LogGroup;
            context.Firehose_DeliveryStream = this.Firehose_DeliveryStream;
            context.Firehose_Enabled = this.Firehose_Enabled;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Enabled = this.S3_Enabled;
            context.S3_Prefix = this.S3_Prefix;
            context.Provisioned_NumberOfBrokerNode = this.Provisioned_NumberOfBrokerNode;
            context.JmxExporter_EnabledInBroker = this.JmxExporter_EnabledInBroker;
            context.NodeExporter_EnabledInBroker = this.NodeExporter_EnabledInBroker;
            context.Provisioned_StorageMode = this.Provisioned_StorageMode;
            context.Serverless_ClientAuthentication_Sasl_Iam_Enabled = this.Serverless_ClientAuthentication_Sasl_Iam_Enabled;
            if (this.Serverless_VpcConfig != null)
            {
                context.Serverless_VpcConfig = new List<Amazon.Kafka.Model.VpcConfig>(this.Serverless_VpcConfig);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Kafka.Model.CreateClusterV2Request();
            
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Provisioned
            var requestProvisionedIsNull = true;
            request.Provisioned = new Amazon.Kafka.Model.ProvisionedRequest();
            Amazon.Kafka.Model.BrokerNodeGroupInfo requestProvisioned_provisioned_BrokerNodeGroupInfo = null;
            if (cmdletContext.Provisioned_BrokerNodeGroupInfo != null)
            {
                requestProvisioned_provisioned_BrokerNodeGroupInfo = cmdletContext.Provisioned_BrokerNodeGroupInfo;
            }
            if (requestProvisioned_provisioned_BrokerNodeGroupInfo != null)
            {
                request.Provisioned.BrokerNodeGroupInfo = requestProvisioned_provisioned_BrokerNodeGroupInfo;
                requestProvisionedIsNull = false;
            }
            Amazon.Kafka.EnhancedMonitoring requestProvisioned_provisioned_EnhancedMonitoring = null;
            if (cmdletContext.Provisioned_EnhancedMonitoring != null)
            {
                requestProvisioned_provisioned_EnhancedMonitoring = cmdletContext.Provisioned_EnhancedMonitoring;
            }
            if (requestProvisioned_provisioned_EnhancedMonitoring != null)
            {
                request.Provisioned.EnhancedMonitoring = requestProvisioned_provisioned_EnhancedMonitoring;
                requestProvisionedIsNull = false;
            }
            System.String requestProvisioned_provisioned_KafkaVersion = null;
            if (cmdletContext.Provisioned_KafkaVersion != null)
            {
                requestProvisioned_provisioned_KafkaVersion = cmdletContext.Provisioned_KafkaVersion;
            }
            if (requestProvisioned_provisioned_KafkaVersion != null)
            {
                request.Provisioned.KafkaVersion = requestProvisioned_provisioned_KafkaVersion;
                requestProvisionedIsNull = false;
            }
            System.Int32? requestProvisioned_provisioned_NumberOfBrokerNode = null;
            if (cmdletContext.Provisioned_NumberOfBrokerNode != null)
            {
                requestProvisioned_provisioned_NumberOfBrokerNode = cmdletContext.Provisioned_NumberOfBrokerNode.Value;
            }
            if (requestProvisioned_provisioned_NumberOfBrokerNode != null)
            {
                request.Provisioned.NumberOfBrokerNodes = requestProvisioned_provisioned_NumberOfBrokerNode.Value;
                requestProvisionedIsNull = false;
            }
            Amazon.Kafka.StorageMode requestProvisioned_provisioned_StorageMode = null;
            if (cmdletContext.Provisioned_StorageMode != null)
            {
                requestProvisioned_provisioned_StorageMode = cmdletContext.Provisioned_StorageMode;
            }
            if (requestProvisioned_provisioned_StorageMode != null)
            {
                request.Provisioned.StorageMode = requestProvisioned_provisioned_StorageMode;
                requestProvisionedIsNull = false;
            }
            Amazon.Kafka.Model.LoggingInfo requestProvisioned_provisioned_LoggingInfo = null;
            
             // populate LoggingInfo
            var requestProvisioned_provisioned_LoggingInfoIsNull = true;
            requestProvisioned_provisioned_LoggingInfo = new Amazon.Kafka.Model.LoggingInfo();
            Amazon.Kafka.Model.BrokerLogs requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs = null;
            
             // populate BrokerLogs
            var requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogsIsNull = true;
            requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs = new Amazon.Kafka.Model.BrokerLogs();
            Amazon.Kafka.Model.CloudWatchLogs requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogsIsNull = true;
            requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs = new Amazon.Kafka.Model.CloudWatchLogs();
            System.Boolean? requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled = null;
            if (cmdletContext.CloudWatchLogs_Enabled != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled = cmdletContext.CloudWatchLogs_Enabled.Value;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs.Enabled = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled.Value;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogsIsNull = false;
            }
            System.String requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = null;
            if (cmdletContext.CloudWatchLogs_LogGroup != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = cmdletContext.CloudWatchLogs_LogGroup;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs.LogGroup = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogsIsNull = false;
            }
             // determine if requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs should be set to null
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogsIsNull)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs = null;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs.CloudWatchLogs = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_CloudWatchLogs;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogsIsNull = false;
            }
            Amazon.Kafka.Model.Firehose requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose = null;
            
             // populate Firehose
            var requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_FirehoseIsNull = true;
            requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose = new Amazon.Kafka.Model.Firehose();
            System.String requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream = null;
            if (cmdletContext.Firehose_DeliveryStream != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream = cmdletContext.Firehose_DeliveryStream;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose.DeliveryStream = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_FirehoseIsNull = false;
            }
            System.Boolean? requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_Enabled = null;
            if (cmdletContext.Firehose_Enabled != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_Enabled = cmdletContext.Firehose_Enabled.Value;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_Enabled != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose.Enabled = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose_firehose_Enabled.Value;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_FirehoseIsNull = false;
            }
             // determine if requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose should be set to null
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_FirehoseIsNull)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose = null;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs.Firehose = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_Firehose;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogsIsNull = false;
            }
            Amazon.Kafka.Model.S3 requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3 = null;
            
             // populate S3
            var requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3IsNull = true;
            requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3 = new Amazon.Kafka.Model.S3();
            System.String requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Bucket != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3.Bucket = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Bucket;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3IsNull = false;
            }
            System.Boolean? requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Enabled = null;
            if (cmdletContext.S3_Enabled != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Enabled = cmdletContext.S3_Enabled.Value;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Enabled != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3.Enabled = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Enabled.Value;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3IsNull = false;
            }
            System.String requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Prefix != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3.Prefix = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3_s3_Prefix;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3IsNull = false;
            }
             // determine if requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3 should be set to null
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3IsNull)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3 = null;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3 != null)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs.S3 = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs_provisioned_LoggingInfo_BrokerLogs_S3;
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogsIsNull = false;
            }
             // determine if requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs should be set to null
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogsIsNull)
            {
                requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs = null;
            }
            if (requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs != null)
            {
                requestProvisioned_provisioned_LoggingInfo.BrokerLogs = requestProvisioned_provisioned_LoggingInfo_provisioned_LoggingInfo_BrokerLogs;
                requestProvisioned_provisioned_LoggingInfoIsNull = false;
            }
             // determine if requestProvisioned_provisioned_LoggingInfo should be set to null
            if (requestProvisioned_provisioned_LoggingInfoIsNull)
            {
                requestProvisioned_provisioned_LoggingInfo = null;
            }
            if (requestProvisioned_provisioned_LoggingInfo != null)
            {
                request.Provisioned.LoggingInfo = requestProvisioned_provisioned_LoggingInfo;
                requestProvisionedIsNull = false;
            }
            Amazon.Kafka.Model.OpenMonitoringInfo requestProvisioned_provisioned_OpenMonitoring = null;
            
             // populate OpenMonitoring
            var requestProvisioned_provisioned_OpenMonitoringIsNull = true;
            requestProvisioned_provisioned_OpenMonitoring = new Amazon.Kafka.Model.OpenMonitoringInfo();
            Amazon.Kafka.Model.PrometheusInfo requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus = null;
            
             // populate Prometheus
            var requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_PrometheusIsNull = true;
            requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus = new Amazon.Kafka.Model.PrometheusInfo();
            Amazon.Kafka.Model.JmxExporterInfo requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter = null;
            
             // populate JmxExporter
            var requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporterIsNull = true;
            requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter = new Amazon.Kafka.Model.JmxExporterInfo();
            System.Boolean? requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker = null;
            if (cmdletContext.JmxExporter_EnabledInBroker != null)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker = cmdletContext.JmxExporter_EnabledInBroker.Value;
            }
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker != null)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter.EnabledInBroker = requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker.Value;
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporterIsNull = false;
            }
             // determine if requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter should be set to null
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporterIsNull)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter = null;
            }
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter != null)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus.JmxExporter = requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_JmxExporter;
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_PrometheusIsNull = false;
            }
            Amazon.Kafka.Model.NodeExporterInfo requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter = null;
            
             // populate NodeExporter
            var requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporterIsNull = true;
            requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter = new Amazon.Kafka.Model.NodeExporterInfo();
            System.Boolean? requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker = null;
            if (cmdletContext.NodeExporter_EnabledInBroker != null)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker = cmdletContext.NodeExporter_EnabledInBroker.Value;
            }
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker != null)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter.EnabledInBroker = requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker.Value;
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporterIsNull = false;
            }
             // determine if requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter should be set to null
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporterIsNull)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter = null;
            }
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter != null)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus.NodeExporter = requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus_provisioned_OpenMonitoring_Prometheus_NodeExporter;
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_PrometheusIsNull = false;
            }
             // determine if requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus should be set to null
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_PrometheusIsNull)
            {
                requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus = null;
            }
            if (requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus != null)
            {
                requestProvisioned_provisioned_OpenMonitoring.Prometheus = requestProvisioned_provisioned_OpenMonitoring_provisioned_OpenMonitoring_Prometheus;
                requestProvisioned_provisioned_OpenMonitoringIsNull = false;
            }
             // determine if requestProvisioned_provisioned_OpenMonitoring should be set to null
            if (requestProvisioned_provisioned_OpenMonitoringIsNull)
            {
                requestProvisioned_provisioned_OpenMonitoring = null;
            }
            if (requestProvisioned_provisioned_OpenMonitoring != null)
            {
                request.Provisioned.OpenMonitoring = requestProvisioned_provisioned_OpenMonitoring;
                requestProvisionedIsNull = false;
            }
            Amazon.Kafka.Model.ConfigurationInfo requestProvisioned_provisioned_ConfigurationInfo = null;
            
             // populate ConfigurationInfo
            var requestProvisioned_provisioned_ConfigurationInfoIsNull = true;
            requestProvisioned_provisioned_ConfigurationInfo = new Amazon.Kafka.Model.ConfigurationInfo();
            System.String requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Arn = null;
            if (cmdletContext.ConfigurationInfo_Arn != null)
            {
                requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Arn = cmdletContext.ConfigurationInfo_Arn;
            }
            if (requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Arn != null)
            {
                requestProvisioned_provisioned_ConfigurationInfo.Arn = requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Arn;
                requestProvisioned_provisioned_ConfigurationInfoIsNull = false;
            }
            System.Int64? requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Revision = null;
            if (cmdletContext.ConfigurationInfo_Revision != null)
            {
                requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Revision = cmdletContext.ConfigurationInfo_Revision.Value;
            }
            if (requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Revision != null)
            {
                requestProvisioned_provisioned_ConfigurationInfo.Revision = requestProvisioned_provisioned_ConfigurationInfo_configurationInfo_Revision.Value;
                requestProvisioned_provisioned_ConfigurationInfoIsNull = false;
            }
             // determine if requestProvisioned_provisioned_ConfigurationInfo should be set to null
            if (requestProvisioned_provisioned_ConfigurationInfoIsNull)
            {
                requestProvisioned_provisioned_ConfigurationInfo = null;
            }
            if (requestProvisioned_provisioned_ConfigurationInfo != null)
            {
                request.Provisioned.ConfigurationInfo = requestProvisioned_provisioned_ConfigurationInfo;
                requestProvisionedIsNull = false;
            }
            Amazon.Kafka.Model.EncryptionInfo requestProvisioned_provisioned_EncryptionInfo = null;
            
             // populate EncryptionInfo
            var requestProvisioned_provisioned_EncryptionInfoIsNull = true;
            requestProvisioned_provisioned_EncryptionInfo = new Amazon.Kafka.Model.EncryptionInfo();
            Amazon.Kafka.Model.EncryptionAtRest requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest = null;
            
             // populate EncryptionAtRest
            var requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRestIsNull = true;
            requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest = new Amazon.Kafka.Model.EncryptionAtRest();
            System.String requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = null;
            if (cmdletContext.EncryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = cmdletContext.EncryptionAtRest_DataVolumeKMSKeyId;
            }
            if (requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest.DataVolumeKMSKeyId = requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId;
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRestIsNull = false;
            }
             // determine if requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest should be set to null
            if (requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRestIsNull)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest = null;
            }
            if (requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest != null)
            {
                requestProvisioned_provisioned_EncryptionInfo.EncryptionAtRest = requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionAtRest;
                requestProvisioned_provisioned_EncryptionInfoIsNull = false;
            }
            Amazon.Kafka.Model.EncryptionInTransit requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit = null;
            
             // populate EncryptionInTransit
            var requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransitIsNull = true;
            requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit = new Amazon.Kafka.Model.EncryptionInTransit();
            Amazon.Kafka.ClientBroker requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker = null;
            if (cmdletContext.EncryptionInTransit_ClientBroker != null)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker = cmdletContext.EncryptionInTransit_ClientBroker;
            }
            if (requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker != null)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit.ClientBroker = requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker;
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransitIsNull = false;
            }
            System.Boolean? requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster = null;
            if (cmdletContext.EncryptionInTransit_InCluster != null)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster = cmdletContext.EncryptionInTransit_InCluster.Value;
            }
            if (requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster != null)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit.InCluster = requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster.Value;
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransitIsNull = false;
            }
             // determine if requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit should be set to null
            if (requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransitIsNull)
            {
                requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit = null;
            }
            if (requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit != null)
            {
                requestProvisioned_provisioned_EncryptionInfo.EncryptionInTransit = requestProvisioned_provisioned_EncryptionInfo_provisioned_EncryptionInfo_EncryptionInTransit;
                requestProvisioned_provisioned_EncryptionInfoIsNull = false;
            }
             // determine if requestProvisioned_provisioned_EncryptionInfo should be set to null
            if (requestProvisioned_provisioned_EncryptionInfoIsNull)
            {
                requestProvisioned_provisioned_EncryptionInfo = null;
            }
            if (requestProvisioned_provisioned_EncryptionInfo != null)
            {
                request.Provisioned.EncryptionInfo = requestProvisioned_provisioned_EncryptionInfo;
                requestProvisionedIsNull = false;
            }
            Amazon.Kafka.Model.ClientAuthentication requestProvisioned_provisioned_ClientAuthentication = null;
            
             // populate ClientAuthentication
            var requestProvisioned_provisioned_ClientAuthenticationIsNull = true;
            requestProvisioned_provisioned_ClientAuthentication = new Amazon.Kafka.Model.ClientAuthentication();
            Amazon.Kafka.Model.Unauthenticated requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated = null;
            
             // populate Unauthenticated
            var requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_UnauthenticatedIsNull = true;
            requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated = new Amazon.Kafka.Model.Unauthenticated();
            System.Boolean? requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated_unauthenticated_Enabled = null;
            if (cmdletContext.Unauthenticated_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated_unauthenticated_Enabled = cmdletContext.Unauthenticated_Enabled.Value;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated_unauthenticated_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated.Enabled = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated_unauthenticated_Enabled.Value;
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_UnauthenticatedIsNull = false;
            }
             // determine if requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated should be set to null
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_UnauthenticatedIsNull)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated = null;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated != null)
            {
                requestProvisioned_provisioned_ClientAuthentication.Unauthenticated = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Unauthenticated;
                requestProvisioned_provisioned_ClientAuthenticationIsNull = false;
            }
            Amazon.Kafka.Model.Sasl requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl = null;
            
             // populate Sasl
            var requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_SaslIsNull = true;
            requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl = new Amazon.Kafka.Model.Sasl();
            Amazon.Kafka.Model.Iam requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam = null;
            
             // populate Iam
            var requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_IamIsNull = true;
            requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam = new Amazon.Kafka.Model.Iam();
            System.Boolean? requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam_provisioned_ClientAuthentication_Sasl_Iam_Enabled = null;
            if (cmdletContext.Provisioned_ClientAuthentication_Sasl_Iam_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam_provisioned_ClientAuthentication_Sasl_Iam_Enabled = cmdletContext.Provisioned_ClientAuthentication_Sasl_Iam_Enabled.Value;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam_provisioned_ClientAuthentication_Sasl_Iam_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam.Enabled = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam_provisioned_ClientAuthentication_Sasl_Iam_Enabled.Value;
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_IamIsNull = false;
            }
             // determine if requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam should be set to null
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_IamIsNull)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam = null;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl.Iam = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Iam;
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_SaslIsNull = false;
            }
            Amazon.Kafka.Model.Scram requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram = null;
            
             // populate Scram
            var requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_ScramIsNull = true;
            requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram = new Amazon.Kafka.Model.Scram();
            System.Boolean? requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram_scram_Enabled = null;
            if (cmdletContext.Scram_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram_scram_Enabled = cmdletContext.Scram_Enabled.Value;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram_scram_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram.Enabled = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram_scram_Enabled.Value;
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_ScramIsNull = false;
            }
             // determine if requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram should be set to null
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_ScramIsNull)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram = null;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl.Scram = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl_provisioned_ClientAuthentication_Sasl_Scram;
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_SaslIsNull = false;
            }
             // determine if requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl should be set to null
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_SaslIsNull)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl = null;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl != null)
            {
                requestProvisioned_provisioned_ClientAuthentication.Sasl = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Sasl;
                requestProvisioned_provisioned_ClientAuthenticationIsNull = false;
            }
            Amazon.Kafka.Model.Tls requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls = null;
            
             // populate Tls
            var requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_TlsIsNull = true;
            requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls = new Amazon.Kafka.Model.Tls();
            List<System.String> requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_CertificateAuthorityArnList = null;
            if (cmdletContext.Tls_CertificateAuthorityArnList != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_CertificateAuthorityArnList = cmdletContext.Tls_CertificateAuthorityArnList;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_CertificateAuthorityArnList != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls.CertificateAuthorityArnList = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_CertificateAuthorityArnList;
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_TlsIsNull = false;
            }
            System.Boolean? requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_Enabled = null;
            if (cmdletContext.Tls_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_Enabled = cmdletContext.Tls_Enabled.Value;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_Enabled != null)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls.Enabled = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls_tls_Enabled.Value;
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_TlsIsNull = false;
            }
             // determine if requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls should be set to null
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_TlsIsNull)
            {
                requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls = null;
            }
            if (requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls != null)
            {
                requestProvisioned_provisioned_ClientAuthentication.Tls = requestProvisioned_provisioned_ClientAuthentication_provisioned_ClientAuthentication_Tls;
                requestProvisioned_provisioned_ClientAuthenticationIsNull = false;
            }
             // determine if requestProvisioned_provisioned_ClientAuthentication should be set to null
            if (requestProvisioned_provisioned_ClientAuthenticationIsNull)
            {
                requestProvisioned_provisioned_ClientAuthentication = null;
            }
            if (requestProvisioned_provisioned_ClientAuthentication != null)
            {
                request.Provisioned.ClientAuthentication = requestProvisioned_provisioned_ClientAuthentication;
                requestProvisionedIsNull = false;
            }
             // determine if request.Provisioned should be set to null
            if (requestProvisionedIsNull)
            {
                request.Provisioned = null;
            }
            
             // populate Serverless
            var requestServerlessIsNull = true;
            request.Serverless = new Amazon.Kafka.Model.ServerlessRequest();
            List<Amazon.Kafka.Model.VpcConfig> requestServerless_serverless_VpcConfig = null;
            if (cmdletContext.Serverless_VpcConfig != null)
            {
                requestServerless_serverless_VpcConfig = cmdletContext.Serverless_VpcConfig;
            }
            if (requestServerless_serverless_VpcConfig != null)
            {
                request.Serverless.VpcConfigs = requestServerless_serverless_VpcConfig;
                requestServerlessIsNull = false;
            }
            Amazon.Kafka.Model.ServerlessClientAuthentication requestServerless_serverless_ClientAuthentication = null;
            
             // populate ClientAuthentication
            var requestServerless_serverless_ClientAuthenticationIsNull = true;
            requestServerless_serverless_ClientAuthentication = new Amazon.Kafka.Model.ServerlessClientAuthentication();
            Amazon.Kafka.Model.ServerlessSasl requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl = null;
            
             // populate Sasl
            var requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_SaslIsNull = true;
            requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl = new Amazon.Kafka.Model.ServerlessSasl();
            Amazon.Kafka.Model.Iam requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam = null;
            
             // populate Iam
            var requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_IamIsNull = true;
            requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam = new Amazon.Kafka.Model.Iam();
            System.Boolean? requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam_serverless_ClientAuthentication_Sasl_Iam_Enabled = null;
            if (cmdletContext.Serverless_ClientAuthentication_Sasl_Iam_Enabled != null)
            {
                requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam_serverless_ClientAuthentication_Sasl_Iam_Enabled = cmdletContext.Serverless_ClientAuthentication_Sasl_Iam_Enabled.Value;
            }
            if (requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam_serverless_ClientAuthentication_Sasl_Iam_Enabled != null)
            {
                requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam.Enabled = requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam_serverless_ClientAuthentication_Sasl_Iam_Enabled.Value;
                requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_IamIsNull = false;
            }
             // determine if requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam should be set to null
            if (requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_IamIsNull)
            {
                requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam = null;
            }
            if (requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam != null)
            {
                requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl.Iam = requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl_serverless_ClientAuthentication_Sasl_Iam;
                requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_SaslIsNull = false;
            }
             // determine if requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl should be set to null
            if (requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_SaslIsNull)
            {
                requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl = null;
            }
            if (requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl != null)
            {
                requestServerless_serverless_ClientAuthentication.Sasl = requestServerless_serverless_ClientAuthentication_serverless_ClientAuthentication_Sasl;
                requestServerless_serverless_ClientAuthenticationIsNull = false;
            }
             // determine if requestServerless_serverless_ClientAuthentication should be set to null
            if (requestServerless_serverless_ClientAuthenticationIsNull)
            {
                requestServerless_serverless_ClientAuthentication = null;
            }
            if (requestServerless_serverless_ClientAuthentication != null)
            {
                request.Serverless.ClientAuthentication = requestServerless_serverless_ClientAuthentication;
                requestServerlessIsNull = false;
            }
             // determine if request.Serverless should be set to null
            if (requestServerlessIsNull)
            {
                request.Serverless = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Kafka.Model.CreateClusterV2Response CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.CreateClusterV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "CreateClusterV2");
            try
            {
                #if DESKTOP
                return client.CreateClusterV2(request);
                #elif CORECLR
                return client.CreateClusterV2Async(request).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public Amazon.Kafka.Model.BrokerNodeGroupInfo Provisioned_BrokerNodeGroupInfo { get; set; }
            public System.Boolean? Provisioned_ClientAuthentication_Sasl_Iam_Enabled { get; set; }
            public System.Boolean? Scram_Enabled { get; set; }
            public List<System.String> Tls_CertificateAuthorityArnList { get; set; }
            public System.Boolean? Tls_Enabled { get; set; }
            public System.Boolean? Unauthenticated_Enabled { get; set; }
            public System.String ConfigurationInfo_Arn { get; set; }
            public System.Int64? ConfigurationInfo_Revision { get; set; }
            public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
            public Amazon.Kafka.ClientBroker EncryptionInTransit_ClientBroker { get; set; }
            public System.Boolean? EncryptionInTransit_InCluster { get; set; }
            public Amazon.Kafka.EnhancedMonitoring Provisioned_EnhancedMonitoring { get; set; }
            public System.String Provisioned_KafkaVersion { get; set; }
            public System.Boolean? CloudWatchLogs_Enabled { get; set; }
            public System.String CloudWatchLogs_LogGroup { get; set; }
            public System.String Firehose_DeliveryStream { get; set; }
            public System.Boolean? Firehose_Enabled { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.Boolean? S3_Enabled { get; set; }
            public System.String S3_Prefix { get; set; }
            public System.Int32? Provisioned_NumberOfBrokerNode { get; set; }
            public System.Boolean? JmxExporter_EnabledInBroker { get; set; }
            public System.Boolean? NodeExporter_EnabledInBroker { get; set; }
            public Amazon.Kafka.StorageMode Provisioned_StorageMode { get; set; }
            public System.Boolean? Serverless_ClientAuthentication_Sasl_Iam_Enabled { get; set; }
            public List<Amazon.Kafka.Model.VpcConfig> Serverless_VpcConfig { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kafka.Model.CreateClusterV2Response, NewMSKClusterV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
