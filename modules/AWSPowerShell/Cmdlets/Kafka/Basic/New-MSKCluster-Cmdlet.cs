/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Creates a new MSK cluster.
    /// </summary>
    [Cmdlet("New", "MSKCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.CreateClusterResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.Kafka.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.Kafka.Model.CreateClusterResponse object containing multiple properties."
    )]
    public partial class NewMSKClusterCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationInfo_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationInfo_Arn { get; set; }
        #endregion
        
        #region Parameter BrokerNodeGroupInfo
        /// <summary>
        /// <para>
        /// <para>Information about the broker nodes in the cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Kafka.Model.BrokerNodeGroupInfo BrokerNodeGroupInfo { get; set; }
        #endregion
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter Tls_CertificateAuthorityArnList
        /// <summary>
        /// <para>
        /// <para>List of ACM Certificate Authority ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Tls_CertificateAuthorityArnList")]
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
        [Alias("EncryptionInfo_EncryptionInTransit_ClientBroker")]
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
        [Alias("EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId")]
        public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
        #endregion
        
        #region Parameter Firehose_DeliveryStream
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_Firehose_DeliveryStream")]
        public System.String Firehose_DeliveryStream { get; set; }
        #endregion
        
        #region Parameter Iam_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether IAM access control is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Sasl_Iam_Enabled")]
        public System.Boolean? Iam_Enabled { get; set; }
        #endregion
        
        #region Parameter Scram_Enabled
        /// <summary>
        /// <para>
        /// <para>SASL/SCRAM authentication is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Sasl_Scram_Enabled")]
        public System.Boolean? Scram_Enabled { get; set; }
        #endregion
        
        #region Parameter Tls_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to turn on or turn off TLS authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Tls_Enabled")]
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
        [Alias("ClientAuthentication_Unauthenticated_Enabled")]
        public System.Boolean? Unauthenticated_Enabled { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_CloudWatchLogs_Enabled")]
        public System.Boolean? CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter Firehose_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_Firehose_Enabled")]
        public System.Boolean? Firehose_Enabled { get; set; }
        #endregion
        
        #region Parameter S3_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_S3_Enabled")]
        public System.Boolean? S3_Enabled { get; set; }
        #endregion
        
        #region Parameter JmxExporter_EnabledInBroker
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to turn on or turn off the JMX Exporter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenMonitoring_Prometheus_JmxExporter_EnabledInBroker")]
        public System.Boolean? JmxExporter_EnabledInBroker { get; set; }
        #endregion
        
        #region Parameter NodeExporter_EnabledInBroker
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to turn on or turn off the Node Exporter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenMonitoring_Prometheus_NodeExporter_EnabledInBroker")]
        public System.Boolean? NodeExporter_EnabledInBroker { get; set; }
        #endregion
        
        #region Parameter EnhancedMonitoring
        /// <summary>
        /// <para>
        /// <para>Specifies the level of monitoring for the MSK cluster. The possible values are DEFAULT,
        /// PER_BROKER, PER_TOPIC_PER_BROKER, and PER_TOPIC_PER_PARTITION.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.EnhancedMonitoring")]
        public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
        #endregion
        
        #region Parameter EncryptionInTransit_InCluster
        /// <summary>
        /// <para>
        /// <para>When set to true, it indicates that data communication among the broker nodes of the
        /// cluster is encrypted. When set to false, the communication happens in plaintext.</para><para>The default value is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionInfo_EncryptionInTransit_InCluster")]
        public System.Boolean? EncryptionInTransit_InCluster { get; set; }
        #endregion
        
        #region Parameter KafkaVersion
        /// <summary>
        /// <para>
        /// <para>The version of Apache Kafka.</para>
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
        public System.String KafkaVersion { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_CloudWatchLogs_LogGroup")]
        public System.String CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter NumberOfBrokerNode
        /// <summary>
        /// <para>
        /// <para>The number of broker nodes in the cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NumberOfBrokerNodes")]
        public System.Int32? NumberOfBrokerNode { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter ConfigurationInfo_Revision
        /// <summary>
        /// <para>
        /// <para>The revision of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ConfigurationInfo_Revision { get; set; }
        #endregion
        
        #region Parameter StorageMode
        /// <summary>
        /// <para>
        /// <para>This controls storage mode for supported storage tiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.StorageMode")]
        public Amazon.Kafka.StorageMode StorageMode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Create tags when creating the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.CreateClusterResponse, NewMSKClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BrokerNodeGroupInfo = this.BrokerNodeGroupInfo;
            #if MODULAR
            if (this.BrokerNodeGroupInfo == null && ParameterWasBound(nameof(this.BrokerNodeGroupInfo)))
            {
                WriteWarning("You are passing $null as a value for parameter BrokerNodeGroupInfo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Iam_Enabled = this.Iam_Enabled;
            context.Scram_Enabled = this.Scram_Enabled;
            if (this.Tls_CertificateAuthorityArnList != null)
            {
                context.Tls_CertificateAuthorityArnList = new List<System.String>(this.Tls_CertificateAuthorityArnList);
            }
            context.Tls_Enabled = this.Tls_Enabled;
            context.Unauthenticated_Enabled = this.Unauthenticated_Enabled;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationInfo_Arn = this.ConfigurationInfo_Arn;
            context.ConfigurationInfo_Revision = this.ConfigurationInfo_Revision;
            context.EncryptionAtRest_DataVolumeKMSKeyId = this.EncryptionAtRest_DataVolumeKMSKeyId;
            context.EncryptionInTransit_ClientBroker = this.EncryptionInTransit_ClientBroker;
            context.EncryptionInTransit_InCluster = this.EncryptionInTransit_InCluster;
            context.EnhancedMonitoring = this.EnhancedMonitoring;
            context.KafkaVersion = this.KafkaVersion;
            #if MODULAR
            if (this.KafkaVersion == null && ParameterWasBound(nameof(this.KafkaVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter KafkaVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLogs_Enabled = this.CloudWatchLogs_Enabled;
            context.CloudWatchLogs_LogGroup = this.CloudWatchLogs_LogGroup;
            context.Firehose_DeliveryStream = this.Firehose_DeliveryStream;
            context.Firehose_Enabled = this.Firehose_Enabled;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Enabled = this.S3_Enabled;
            context.S3_Prefix = this.S3_Prefix;
            context.NumberOfBrokerNode = this.NumberOfBrokerNode;
            #if MODULAR
            if (this.NumberOfBrokerNode == null && ParameterWasBound(nameof(this.NumberOfBrokerNode)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberOfBrokerNode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JmxExporter_EnabledInBroker = this.JmxExporter_EnabledInBroker;
            context.NodeExporter_EnabledInBroker = this.NodeExporter_EnabledInBroker;
            context.StorageMode = this.StorageMode;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.Kafka.Model.CreateClusterRequest();
            
            if (cmdletContext.BrokerNodeGroupInfo != null)
            {
                request.BrokerNodeGroupInfo = cmdletContext.BrokerNodeGroupInfo;
            }
            
             // populate ClientAuthentication
            var requestClientAuthenticationIsNull = true;
            request.ClientAuthentication = new Amazon.Kafka.Model.ClientAuthentication();
            Amazon.Kafka.Model.Unauthenticated requestClientAuthentication_clientAuthentication_Unauthenticated = null;
            
             // populate Unauthenticated
            var requestClientAuthentication_clientAuthentication_UnauthenticatedIsNull = true;
            requestClientAuthentication_clientAuthentication_Unauthenticated = new Amazon.Kafka.Model.Unauthenticated();
            System.Boolean? requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled = null;
            if (cmdletContext.Unauthenticated_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled = cmdletContext.Unauthenticated_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Unauthenticated.Enabled = requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled.Value;
                requestClientAuthentication_clientAuthentication_UnauthenticatedIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Unauthenticated should be set to null
            if (requestClientAuthentication_clientAuthentication_UnauthenticatedIsNull)
            {
                requestClientAuthentication_clientAuthentication_Unauthenticated = null;
            }
            if (requestClientAuthentication_clientAuthentication_Unauthenticated != null)
            {
                request.ClientAuthentication.Unauthenticated = requestClientAuthentication_clientAuthentication_Unauthenticated;
                requestClientAuthenticationIsNull = false;
            }
            Amazon.Kafka.Model.Sasl requestClientAuthentication_clientAuthentication_Sasl = null;
            
             // populate Sasl
            var requestClientAuthentication_clientAuthentication_SaslIsNull = true;
            requestClientAuthentication_clientAuthentication_Sasl = new Amazon.Kafka.Model.Sasl();
            Amazon.Kafka.Model.Iam requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam = null;
            
             // populate Iam
            var requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_IamIsNull = true;
            requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam = new Amazon.Kafka.Model.Iam();
            System.Boolean? requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled = null;
            if (cmdletContext.Iam_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled = cmdletContext.Iam_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam.Enabled = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled.Value;
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_IamIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam should be set to null
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_IamIsNull)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam = null;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl.Iam = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam;
                requestClientAuthentication_clientAuthentication_SaslIsNull = false;
            }
            Amazon.Kafka.Model.Scram requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram = null;
            
             // populate Scram
            var requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_ScramIsNull = true;
            requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram = new Amazon.Kafka.Model.Scram();
            System.Boolean? requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled = null;
            if (cmdletContext.Scram_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled = cmdletContext.Scram_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram.Enabled = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled.Value;
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_ScramIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram should be set to null
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_ScramIsNull)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram = null;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl.Scram = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram;
                requestClientAuthentication_clientAuthentication_SaslIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Sasl should be set to null
            if (requestClientAuthentication_clientAuthentication_SaslIsNull)
            {
                requestClientAuthentication_clientAuthentication_Sasl = null;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl != null)
            {
                request.ClientAuthentication.Sasl = requestClientAuthentication_clientAuthentication_Sasl;
                requestClientAuthenticationIsNull = false;
            }
            Amazon.Kafka.Model.Tls requestClientAuthentication_clientAuthentication_Tls = null;
            
             // populate Tls
            var requestClientAuthentication_clientAuthentication_TlsIsNull = true;
            requestClientAuthentication_clientAuthentication_Tls = new Amazon.Kafka.Model.Tls();
            List<System.String> requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList = null;
            if (cmdletContext.Tls_CertificateAuthorityArnList != null)
            {
                requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList = cmdletContext.Tls_CertificateAuthorityArnList;
            }
            if (requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList != null)
            {
                requestClientAuthentication_clientAuthentication_Tls.CertificateAuthorityArnList = requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList;
                requestClientAuthentication_clientAuthentication_TlsIsNull = false;
            }
            System.Boolean? requestClientAuthentication_clientAuthentication_Tls_tls_Enabled = null;
            if (cmdletContext.Tls_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Tls_tls_Enabled = cmdletContext.Tls_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Tls_tls_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Tls.Enabled = requestClientAuthentication_clientAuthentication_Tls_tls_Enabled.Value;
                requestClientAuthentication_clientAuthentication_TlsIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Tls should be set to null
            if (requestClientAuthentication_clientAuthentication_TlsIsNull)
            {
                requestClientAuthentication_clientAuthentication_Tls = null;
            }
            if (requestClientAuthentication_clientAuthentication_Tls != null)
            {
                request.ClientAuthentication.Tls = requestClientAuthentication_clientAuthentication_Tls;
                requestClientAuthenticationIsNull = false;
            }
             // determine if request.ClientAuthentication should be set to null
            if (requestClientAuthenticationIsNull)
            {
                request.ClientAuthentication = null;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate ConfigurationInfo
            var requestConfigurationInfoIsNull = true;
            request.ConfigurationInfo = new Amazon.Kafka.Model.ConfigurationInfo();
            System.String requestConfigurationInfo_configurationInfo_Arn = null;
            if (cmdletContext.ConfigurationInfo_Arn != null)
            {
                requestConfigurationInfo_configurationInfo_Arn = cmdletContext.ConfigurationInfo_Arn;
            }
            if (requestConfigurationInfo_configurationInfo_Arn != null)
            {
                request.ConfigurationInfo.Arn = requestConfigurationInfo_configurationInfo_Arn;
                requestConfigurationInfoIsNull = false;
            }
            System.Int64? requestConfigurationInfo_configurationInfo_Revision = null;
            if (cmdletContext.ConfigurationInfo_Revision != null)
            {
                requestConfigurationInfo_configurationInfo_Revision = cmdletContext.ConfigurationInfo_Revision.Value;
            }
            if (requestConfigurationInfo_configurationInfo_Revision != null)
            {
                request.ConfigurationInfo.Revision = requestConfigurationInfo_configurationInfo_Revision.Value;
                requestConfigurationInfoIsNull = false;
            }
             // determine if request.ConfigurationInfo should be set to null
            if (requestConfigurationInfoIsNull)
            {
                request.ConfigurationInfo = null;
            }
            
             // populate EncryptionInfo
            var requestEncryptionInfoIsNull = true;
            request.EncryptionInfo = new Amazon.Kafka.Model.EncryptionInfo();
            Amazon.Kafka.Model.EncryptionAtRest requestEncryptionInfo_encryptionInfo_EncryptionAtRest = null;
            
             // populate EncryptionAtRest
            var requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull = true;
            requestEncryptionInfo_encryptionInfo_EncryptionAtRest = new Amazon.Kafka.Model.EncryptionAtRest();
            System.String requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = null;
            if (cmdletContext.EncryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = cmdletContext.EncryptionAtRest_DataVolumeKMSKeyId;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest.DataVolumeKMSKeyId = requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId;
                requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull = false;
            }
             // determine if requestEncryptionInfo_encryptionInfo_EncryptionAtRest should be set to null
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest = null;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRest != null)
            {
                request.EncryptionInfo.EncryptionAtRest = requestEncryptionInfo_encryptionInfo_EncryptionAtRest;
                requestEncryptionInfoIsNull = false;
            }
            Amazon.Kafka.Model.EncryptionInTransit requestEncryptionInfo_encryptionInfo_EncryptionInTransit = null;
            
             // populate EncryptionInTransit
            var requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull = true;
            requestEncryptionInfo_encryptionInfo_EncryptionInTransit = new Amazon.Kafka.Model.EncryptionInTransit();
            Amazon.Kafka.ClientBroker requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker = null;
            if (cmdletContext.EncryptionInTransit_ClientBroker != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker = cmdletContext.EncryptionInTransit_ClientBroker;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit.ClientBroker = requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker;
                requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull = false;
            }
            System.Boolean? requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster = null;
            if (cmdletContext.EncryptionInTransit_InCluster != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster = cmdletContext.EncryptionInTransit_InCluster.Value;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit.InCluster = requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster.Value;
                requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull = false;
            }
             // determine if requestEncryptionInfo_encryptionInfo_EncryptionInTransit should be set to null
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit = null;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransit != null)
            {
                request.EncryptionInfo.EncryptionInTransit = requestEncryptionInfo_encryptionInfo_EncryptionInTransit;
                requestEncryptionInfoIsNull = false;
            }
             // determine if request.EncryptionInfo should be set to null
            if (requestEncryptionInfoIsNull)
            {
                request.EncryptionInfo = null;
            }
            if (cmdletContext.EnhancedMonitoring != null)
            {
                request.EnhancedMonitoring = cmdletContext.EnhancedMonitoring;
            }
            if (cmdletContext.KafkaVersion != null)
            {
                request.KafkaVersion = cmdletContext.KafkaVersion;
            }
            
             // populate LoggingInfo
            var requestLoggingInfoIsNull = true;
            request.LoggingInfo = new Amazon.Kafka.Model.LoggingInfo();
            Amazon.Kafka.Model.BrokerLogs requestLoggingInfo_loggingInfo_BrokerLogs = null;
            
             // populate BrokerLogs
            var requestLoggingInfo_loggingInfo_BrokerLogsIsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs = new Amazon.Kafka.Model.BrokerLogs();
            Amazon.Kafka.Model.CloudWatchLogs requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs = new Amazon.Kafka.Model.CloudWatchLogs();
            System.Boolean? requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled = null;
            if (cmdletContext.CloudWatchLogs_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled = cmdletContext.CloudWatchLogs_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs.Enabled = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled.Value;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = null;
            if (cmdletContext.CloudWatchLogs_LogGroup != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = cmdletContext.CloudWatchLogs_LogGroup;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs.LogGroup = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs.CloudWatchLogs = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs;
                requestLoggingInfo_loggingInfo_BrokerLogsIsNull = false;
            }
            Amazon.Kafka.Model.Firehose requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose = null;
            
             // populate Firehose
            var requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose = new Amazon.Kafka.Model.Firehose();
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream = null;
            if (cmdletContext.Firehose_DeliveryStream != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream = cmdletContext.Firehose_DeliveryStream;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose.DeliveryStream = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull = false;
            }
            System.Boolean? requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled = null;
            if (cmdletContext.Firehose_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled = cmdletContext.Firehose_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose.Enabled = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled.Value;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs.Firehose = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose;
                requestLoggingInfo_loggingInfo_BrokerLogsIsNull = false;
            }
            Amazon.Kafka.Model.S3 requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 = null;
            
             // populate S3
            var requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 = new Amazon.Kafka.Model.S3();
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3.Bucket = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = false;
            }
            System.Boolean? requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled = null;
            if (cmdletContext.S3_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled = cmdletContext.S3_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3.Enabled = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled.Value;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3.Prefix = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs.S3 = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3;
                requestLoggingInfo_loggingInfo_BrokerLogsIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogsIsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs != null)
            {
                request.LoggingInfo.BrokerLogs = requestLoggingInfo_loggingInfo_BrokerLogs;
                requestLoggingInfoIsNull = false;
            }
             // determine if request.LoggingInfo should be set to null
            if (requestLoggingInfoIsNull)
            {
                request.LoggingInfo = null;
            }
            if (cmdletContext.NumberOfBrokerNode != null)
            {
                request.NumberOfBrokerNodes = cmdletContext.NumberOfBrokerNode.Value;
            }
            
             // populate OpenMonitoring
            var requestOpenMonitoringIsNull = true;
            request.OpenMonitoring = new Amazon.Kafka.Model.OpenMonitoringInfo();
            Amazon.Kafka.Model.PrometheusInfo requestOpenMonitoring_openMonitoring_Prometheus = null;
            
             // populate Prometheus
            var requestOpenMonitoring_openMonitoring_PrometheusIsNull = true;
            requestOpenMonitoring_openMonitoring_Prometheus = new Amazon.Kafka.Model.PrometheusInfo();
            Amazon.Kafka.Model.JmxExporterInfo requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter = null;
            
             // populate JmxExporter
            var requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporterIsNull = true;
            requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter = new Amazon.Kafka.Model.JmxExporterInfo();
            System.Boolean? requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker = null;
            if (cmdletContext.JmxExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker = cmdletContext.JmxExporter_EnabledInBroker.Value;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter.EnabledInBroker = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker.Value;
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporterIsNull = false;
            }
             // determine if requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter should be set to null
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporterIsNull)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter = null;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus.JmxExporter = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter;
                requestOpenMonitoring_openMonitoring_PrometheusIsNull = false;
            }
            Amazon.Kafka.Model.NodeExporterInfo requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter = null;
            
             // populate NodeExporter
            var requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporterIsNull = true;
            requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter = new Amazon.Kafka.Model.NodeExporterInfo();
            System.Boolean? requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker = null;
            if (cmdletContext.NodeExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker = cmdletContext.NodeExporter_EnabledInBroker.Value;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter.EnabledInBroker = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker.Value;
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporterIsNull = false;
            }
             // determine if requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter should be set to null
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporterIsNull)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter = null;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus.NodeExporter = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter;
                requestOpenMonitoring_openMonitoring_PrometheusIsNull = false;
            }
             // determine if requestOpenMonitoring_openMonitoring_Prometheus should be set to null
            if (requestOpenMonitoring_openMonitoring_PrometheusIsNull)
            {
                requestOpenMonitoring_openMonitoring_Prometheus = null;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus != null)
            {
                request.OpenMonitoring.Prometheus = requestOpenMonitoring_openMonitoring_Prometheus;
                requestOpenMonitoringIsNull = false;
            }
             // determine if request.OpenMonitoring should be set to null
            if (requestOpenMonitoringIsNull)
            {
                request.OpenMonitoring = null;
            }
            if (cmdletContext.StorageMode != null)
            {
                request.StorageMode = cmdletContext.StorageMode;
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
        
        private Amazon.Kafka.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "CreateCluster");
            try
            {
                return client.CreateClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Kafka.Model.BrokerNodeGroupInfo BrokerNodeGroupInfo { get; set; }
            public System.Boolean? Iam_Enabled { get; set; }
            public System.Boolean? Scram_Enabled { get; set; }
            public List<System.String> Tls_CertificateAuthorityArnList { get; set; }
            public System.Boolean? Tls_Enabled { get; set; }
            public System.Boolean? Unauthenticated_Enabled { get; set; }
            public System.String ClusterName { get; set; }
            public System.String ConfigurationInfo_Arn { get; set; }
            public System.Int64? ConfigurationInfo_Revision { get; set; }
            public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
            public Amazon.Kafka.ClientBroker EncryptionInTransit_ClientBroker { get; set; }
            public System.Boolean? EncryptionInTransit_InCluster { get; set; }
            public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
            public System.String KafkaVersion { get; set; }
            public System.Boolean? CloudWatchLogs_Enabled { get; set; }
            public System.String CloudWatchLogs_LogGroup { get; set; }
            public System.String Firehose_DeliveryStream { get; set; }
            public System.Boolean? Firehose_Enabled { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.Boolean? S3_Enabled { get; set; }
            public System.String S3_Prefix { get; set; }
            public System.Int32? NumberOfBrokerNode { get; set; }
            public System.Boolean? JmxExporter_EnabledInBroker { get; set; }
            public System.Boolean? NodeExporter_EnabledInBroker { get; set; }
            public Amazon.Kafka.StorageMode StorageMode { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kafka.Model.CreateClusterResponse, NewMSKClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
