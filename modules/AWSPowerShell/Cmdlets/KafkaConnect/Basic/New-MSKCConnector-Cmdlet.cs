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
using Amazon.KafkaConnect;
using Amazon.KafkaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.MSKC
{
    /// <summary>
    /// Creates a connector using the specified properties.
    /// </summary>
    [Cmdlet("New", "MSKCConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KafkaConnect.Model.CreateConnectorResponse")]
    [AWSCmdlet("Calls the Managed Streaming for Kafka Connect CreateConnector API operation.", Operation = new[] {"CreateConnector"}, SelectReturnType = typeof(Amazon.KafkaConnect.Model.CreateConnectorResponse))]
    [AWSCmdletOutput("Amazon.KafkaConnect.Model.CreateConnectorResponse",
        "This cmdlet returns an Amazon.KafkaConnect.Model.CreateConnectorResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMSKCConnectorCmdlet : AmazonKafkaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter KafkaClusterClientAuthentication_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The type of client authentication used to connect to the Apache Kafka cluster. Value
        /// NONE means that no client authentication is used.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KafkaConnect.KafkaClusterClientAuthenticationType")]
        public Amazon.KafkaConnect.KafkaClusterClientAuthenticationType KafkaClusterClientAuthentication_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter ApacheKafkaCluster_BootstrapServer
        /// <summary>
        /// <para>
        /// <para>The bootstrap servers of the cluster.</para>
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
        [Alias("KafkaCluster_ApacheKafkaCluster_BootstrapServers")]
        public System.String ApacheKafkaCluster_BootstrapServer { get; set; }
        #endregion
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket that is the destination for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDelivery_WorkerLogDelivery_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter ConnectorConfiguration
        /// <summary>
        /// <para>
        /// <para>A map of keys to values that represent the configuration for the connector.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Collections.Hashtable ConnectorConfiguration { get; set; }
        #endregion
        
        #region Parameter ConnectorDescription
        /// <summary>
        /// <para>
        /// <para>A summary description of the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorDescription { get; set; }
        #endregion
        
        #region Parameter ConnectorName
        /// <summary>
        /// <para>
        /// <para>The name of the connector.</para>
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
        public System.String ConnectorName { get; set; }
        #endregion
        
        #region Parameter ScaleInPolicy_CpuUtilizationPercentage
        /// <summary>
        /// <para>
        /// <para>Specifies the CPU utilization percentage threshold at which you want connector scale
        /// in to be triggered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_ScaleInPolicy_CpuUtilizationPercentage")]
        public System.Int32? ScaleInPolicy_CpuUtilizationPercentage { get; set; }
        #endregion
        
        #region Parameter ScaleOutPolicy_CpuUtilizationPercentage
        /// <summary>
        /// <para>
        /// <para>The CPU utilization percentage threshold at which you want connector scale out to
        /// be triggered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_ScaleOutPolicy_CpuUtilizationPercentage")]
        public System.Int32? ScaleOutPolicy_CpuUtilizationPercentage { get; set; }
        #endregion
        
        #region Parameter Firehose_DeliveryStream
        /// <summary>
        /// <para>
        /// <para>The name of the Kinesis Data Firehose delivery stream that is the destination for
        /// log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDelivery_WorkerLogDelivery_Firehose_DeliveryStream")]
        public System.String Firehose_DeliveryStream { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether log delivery to Amazon CloudWatch Logs is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDelivery_WorkerLogDelivery_CloudWatchLogs_Enabled")]
        public System.Boolean? CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter Firehose_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether connector logs get delivered to Amazon Kinesis Data Firehose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDelivery_WorkerLogDelivery_Firehose_Enabled")]
        public System.Boolean? Firehose_Enabled { get; set; }
        #endregion
        
        #region Parameter S3_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether connector logs get sent to the specified Amazon S3 destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDelivery_WorkerLogDelivery_S3_Enabled")]
        public System.Boolean? S3_Enabled { get; set; }
        #endregion
        
        #region Parameter KafkaClusterEncryptionInTransit_EncryptionType
        /// <summary>
        /// <para>
        /// <para>The type of encryption in transit to the Apache Kafka cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KafkaConnect.KafkaClusterEncryptionInTransitType")]
        public Amazon.KafkaConnect.KafkaClusterEncryptionInTransitType KafkaClusterEncryptionInTransit_EncryptionType { get; set; }
        #endregion
        
        #region Parameter KafkaConnectVersion
        /// <summary>
        /// <para>
        /// <para>The version of Kafka Connect. It has to be compatible with both the Apache Kafka cluster's
        /// version and the plugins.</para>
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
        public System.String KafkaConnectVersion { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch log group that is the destination for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDelivery_WorkerLogDelivery_CloudWatchLogs_LogGroup")]
        public System.String CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter AutoScaling_MaxWorkerCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of workers allocated to the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_MaxWorkerCount")]
        public System.Int32? AutoScaling_MaxWorkerCount { get; set; }
        #endregion
        
        #region Parameter AutoScaling_McuCount
        /// <summary>
        /// <para>
        /// <para>The number of microcontroller units (MCUs) allocated to each connector worker. The
        /// valid values are 1,2,4,8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_McuCount")]
        public System.Int32? AutoScaling_McuCount { get; set; }
        #endregion
        
        #region Parameter ProvisionedCapacity_McuCount
        /// <summary>
        /// <para>
        /// <para>The number of microcontroller units (MCUs) allocated to each connector worker. The
        /// valid values are 1,2,4,8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_ProvisionedCapacity_McuCount")]
        public System.Int32? ProvisionedCapacity_McuCount { get; set; }
        #endregion
        
        #region Parameter AutoScaling_MinWorkerCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of workers allocated to the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_MinWorkerCount")]
        public System.Int32? AutoScaling_MinWorkerCount { get; set; }
        #endregion
        
        #region Parameter Plugin
        /// <summary>
        /// <para>
        /// <para>Specifies which plugins to use for the connector.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Plugins")]
        public Amazon.KafkaConnect.Model.Plugin[] Plugin { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// <para>The S3 prefix that is the destination for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDelivery_WorkerLogDelivery_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter WorkerConfiguration_Revision
        /// <summary>
        /// <para>
        /// <para>The revision of the worker configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? WorkerConfiguration_Revision { get; set; }
        #endregion
        
        #region Parameter Vpc_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups for the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KafkaCluster_ApacheKafkaCluster_Vpc_SecurityGroups")]
        public System.String[] Vpc_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter ServiceExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role used by the connector to access the
        /// Amazon Web Services resources that it needs. The types of resources depends on the
        /// logic of the connector. For example, a connector that has Amazon S3 as a destination
        /// must have permissions that allow it to write to the S3 destination bucket.</para>
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
        public System.String ServiceExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Vpc_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets for the connector.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("KafkaCluster_ApacheKafkaCluster_Vpc_Subnets")]
        public System.String[] Vpc_Subnet { get; set; }
        #endregion
        
        #region Parameter WorkerConfiguration_WorkerConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the worker configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkerConfiguration_WorkerConfigurationArn { get; set; }
        #endregion
        
        #region Parameter ProvisionedCapacity_WorkerCount
        /// <summary>
        /// <para>
        /// <para>The number of workers that are allocated to the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_ProvisionedCapacity_WorkerCount")]
        public System.Int32? ProvisionedCapacity_WorkerCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KafkaConnect.Model.CreateConnectorResponse).
        /// Specifying the name of a property of type Amazon.KafkaConnect.Model.CreateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectorName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectorName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectorName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKCConnector (CreateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KafkaConnect.Model.CreateConnectorResponse, NewMSKCConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectorName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScaling_MaxWorkerCount = this.AutoScaling_MaxWorkerCount;
            context.AutoScaling_McuCount = this.AutoScaling_McuCount;
            context.AutoScaling_MinWorkerCount = this.AutoScaling_MinWorkerCount;
            context.ScaleInPolicy_CpuUtilizationPercentage = this.ScaleInPolicy_CpuUtilizationPercentage;
            context.ScaleOutPolicy_CpuUtilizationPercentage = this.ScaleOutPolicy_CpuUtilizationPercentage;
            context.ProvisionedCapacity_McuCount = this.ProvisionedCapacity_McuCount;
            context.ProvisionedCapacity_WorkerCount = this.ProvisionedCapacity_WorkerCount;
            if (this.ConnectorConfiguration != null)
            {
                context.ConnectorConfiguration = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ConnectorConfiguration.Keys)
                {
                    context.ConnectorConfiguration.Add((String)hashKey, (String)(this.ConnectorConfiguration[hashKey]));
                }
            }
            #if MODULAR
            if (this.ConnectorConfiguration == null && ParameterWasBound(nameof(this.ConnectorConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectorDescription = this.ConnectorDescription;
            context.ConnectorName = this.ConnectorName;
            #if MODULAR
            if (this.ConnectorName == null && ParameterWasBound(nameof(this.ConnectorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApacheKafkaCluster_BootstrapServer = this.ApacheKafkaCluster_BootstrapServer;
            #if MODULAR
            if (this.ApacheKafkaCluster_BootstrapServer == null && ParameterWasBound(nameof(this.ApacheKafkaCluster_BootstrapServer)))
            {
                WriteWarning("You are passing $null as a value for parameter ApacheKafkaCluster_BootstrapServer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Vpc_SecurityGroup != null)
            {
                context.Vpc_SecurityGroup = new List<System.String>(this.Vpc_SecurityGroup);
            }
            if (this.Vpc_Subnet != null)
            {
                context.Vpc_Subnet = new List<System.String>(this.Vpc_Subnet);
            }
            #if MODULAR
            if (this.Vpc_Subnet == null && ParameterWasBound(nameof(this.Vpc_Subnet)))
            {
                WriteWarning("You are passing $null as a value for parameter Vpc_Subnet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KafkaClusterClientAuthentication_AuthenticationType = this.KafkaClusterClientAuthentication_AuthenticationType;
            #if MODULAR
            if (this.KafkaClusterClientAuthentication_AuthenticationType == null && ParameterWasBound(nameof(this.KafkaClusterClientAuthentication_AuthenticationType)))
            {
                WriteWarning("You are passing $null as a value for parameter KafkaClusterClientAuthentication_AuthenticationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KafkaClusterEncryptionInTransit_EncryptionType = this.KafkaClusterEncryptionInTransit_EncryptionType;
            #if MODULAR
            if (this.KafkaClusterEncryptionInTransit_EncryptionType == null && ParameterWasBound(nameof(this.KafkaClusterEncryptionInTransit_EncryptionType)))
            {
                WriteWarning("You are passing $null as a value for parameter KafkaClusterEncryptionInTransit_EncryptionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KafkaConnectVersion = this.KafkaConnectVersion;
            #if MODULAR
            if (this.KafkaConnectVersion == null && ParameterWasBound(nameof(this.KafkaConnectVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter KafkaConnectVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLogs_Enabled = this.CloudWatchLogs_Enabled;
            context.CloudWatchLogs_LogGroup = this.CloudWatchLogs_LogGroup;
            context.Firehose_DeliveryStream = this.Firehose_DeliveryStream;
            context.Firehose_Enabled = this.Firehose_Enabled;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Enabled = this.S3_Enabled;
            context.S3_Prefix = this.S3_Prefix;
            if (this.Plugin != null)
            {
                context.Plugin = new List<Amazon.KafkaConnect.Model.Plugin>(this.Plugin);
            }
            #if MODULAR
            if (this.Plugin == null && ParameterWasBound(nameof(this.Plugin)))
            {
                WriteWarning("You are passing $null as a value for parameter Plugin which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceExecutionRoleArn = this.ServiceExecutionRoleArn;
            #if MODULAR
            if (this.ServiceExecutionRoleArn == null && ParameterWasBound(nameof(this.ServiceExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkerConfiguration_Revision = this.WorkerConfiguration_Revision;
            context.WorkerConfiguration_WorkerConfigurationArn = this.WorkerConfiguration_WorkerConfigurationArn;
            
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
            var request = new Amazon.KafkaConnect.Model.CreateConnectorRequest();
            
            
             // populate Capacity
            var requestCapacityIsNull = true;
            request.Capacity = new Amazon.KafkaConnect.Model.Capacity();
            Amazon.KafkaConnect.Model.ProvisionedCapacity requestCapacity_capacity_ProvisionedCapacity = null;
            
             // populate ProvisionedCapacity
            var requestCapacity_capacity_ProvisionedCapacityIsNull = true;
            requestCapacity_capacity_ProvisionedCapacity = new Amazon.KafkaConnect.Model.ProvisionedCapacity();
            System.Int32? requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount = null;
            if (cmdletContext.ProvisionedCapacity_McuCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount = cmdletContext.ProvisionedCapacity_McuCount.Value;
            }
            if (requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity.McuCount = requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount.Value;
                requestCapacity_capacity_ProvisionedCapacityIsNull = false;
            }
            System.Int32? requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount = null;
            if (cmdletContext.ProvisionedCapacity_WorkerCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount = cmdletContext.ProvisionedCapacity_WorkerCount.Value;
            }
            if (requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity.WorkerCount = requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount.Value;
                requestCapacity_capacity_ProvisionedCapacityIsNull = false;
            }
             // determine if requestCapacity_capacity_ProvisionedCapacity should be set to null
            if (requestCapacity_capacity_ProvisionedCapacityIsNull)
            {
                requestCapacity_capacity_ProvisionedCapacity = null;
            }
            if (requestCapacity_capacity_ProvisionedCapacity != null)
            {
                request.Capacity.ProvisionedCapacity = requestCapacity_capacity_ProvisionedCapacity;
                requestCapacityIsNull = false;
            }
            Amazon.KafkaConnect.Model.AutoScaling requestCapacity_capacity_AutoScaling = null;
            
             // populate AutoScaling
            var requestCapacity_capacity_AutoScalingIsNull = true;
            requestCapacity_capacity_AutoScaling = new Amazon.KafkaConnect.Model.AutoScaling();
            System.Int32? requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount = null;
            if (cmdletContext.AutoScaling_MaxWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount = cmdletContext.AutoScaling_MaxWorkerCount.Value;
            }
            if (requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling.MaxWorkerCount = requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount.Value;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            System.Int32? requestCapacity_capacity_AutoScaling_autoScaling_McuCount = null;
            if (cmdletContext.AutoScaling_McuCount != null)
            {
                requestCapacity_capacity_AutoScaling_autoScaling_McuCount = cmdletContext.AutoScaling_McuCount.Value;
            }
            if (requestCapacity_capacity_AutoScaling_autoScaling_McuCount != null)
            {
                requestCapacity_capacity_AutoScaling.McuCount = requestCapacity_capacity_AutoScaling_autoScaling_McuCount.Value;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            System.Int32? requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount = null;
            if (cmdletContext.AutoScaling_MinWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount = cmdletContext.AutoScaling_MinWorkerCount.Value;
            }
            if (requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling.MinWorkerCount = requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount.Value;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            Amazon.KafkaConnect.Model.ScaleInPolicy requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy = null;
            
             // populate ScaleInPolicy
            var requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicyIsNull = true;
            requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy = new Amazon.KafkaConnect.Model.ScaleInPolicy();
            System.Int32? requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage = null;
            if (cmdletContext.ScaleInPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage = cmdletContext.ScaleInPolicy_CpuUtilizationPercentage.Value;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy.CpuUtilizationPercentage = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage.Value;
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicyIsNull = false;
            }
             // determine if requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy should be set to null
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicyIsNull)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy = null;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy != null)
            {
                requestCapacity_capacity_AutoScaling.ScaleInPolicy = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            Amazon.KafkaConnect.Model.ScaleOutPolicy requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy = null;
            
             // populate ScaleOutPolicy
            var requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicyIsNull = true;
            requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy = new Amazon.KafkaConnect.Model.ScaleOutPolicy();
            System.Int32? requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage = null;
            if (cmdletContext.ScaleOutPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage = cmdletContext.ScaleOutPolicy_CpuUtilizationPercentage.Value;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy.CpuUtilizationPercentage = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage.Value;
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicyIsNull = false;
            }
             // determine if requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy should be set to null
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicyIsNull)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy = null;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy != null)
            {
                requestCapacity_capacity_AutoScaling.ScaleOutPolicy = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
             // determine if requestCapacity_capacity_AutoScaling should be set to null
            if (requestCapacity_capacity_AutoScalingIsNull)
            {
                requestCapacity_capacity_AutoScaling = null;
            }
            if (requestCapacity_capacity_AutoScaling != null)
            {
                request.Capacity.AutoScaling = requestCapacity_capacity_AutoScaling;
                requestCapacityIsNull = false;
            }
             // determine if request.Capacity should be set to null
            if (requestCapacityIsNull)
            {
                request.Capacity = null;
            }
            if (cmdletContext.ConnectorConfiguration != null)
            {
                request.ConnectorConfiguration = cmdletContext.ConnectorConfiguration;
            }
            if (cmdletContext.ConnectorDescription != null)
            {
                request.ConnectorDescription = cmdletContext.ConnectorDescription;
            }
            if (cmdletContext.ConnectorName != null)
            {
                request.ConnectorName = cmdletContext.ConnectorName;
            }
            
             // populate KafkaCluster
            var requestKafkaClusterIsNull = true;
            request.KafkaCluster = new Amazon.KafkaConnect.Model.KafkaCluster();
            Amazon.KafkaConnect.Model.ApacheKafkaCluster requestKafkaCluster_kafkaCluster_ApacheKafkaCluster = null;
            
             // populate ApacheKafkaCluster
            var requestKafkaCluster_kafkaCluster_ApacheKafkaClusterIsNull = true;
            requestKafkaCluster_kafkaCluster_ApacheKafkaCluster = new Amazon.KafkaConnect.Model.ApacheKafkaCluster();
            System.String requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_apacheKafkaCluster_BootstrapServer = null;
            if (cmdletContext.ApacheKafkaCluster_BootstrapServer != null)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_apacheKafkaCluster_BootstrapServer = cmdletContext.ApacheKafkaCluster_BootstrapServer;
            }
            if (requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_apacheKafkaCluster_BootstrapServer != null)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster.BootstrapServers = requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_apacheKafkaCluster_BootstrapServer;
                requestKafkaCluster_kafkaCluster_ApacheKafkaClusterIsNull = false;
            }
            Amazon.KafkaConnect.Model.Vpc requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc = null;
            
             // populate Vpc
            var requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_VpcIsNull = true;
            requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc = new Amazon.KafkaConnect.Model.Vpc();
            List<System.String> requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_SecurityGroup = null;
            if (cmdletContext.Vpc_SecurityGroup != null)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_SecurityGroup = cmdletContext.Vpc_SecurityGroup;
            }
            if (requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_SecurityGroup != null)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc.SecurityGroups = requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_SecurityGroup;
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_VpcIsNull = false;
            }
            List<System.String> requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_Subnet = null;
            if (cmdletContext.Vpc_Subnet != null)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_Subnet = cmdletContext.Vpc_Subnet;
            }
            if (requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_Subnet != null)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc.Subnets = requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc_vpc_Subnet;
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_VpcIsNull = false;
            }
             // determine if requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc should be set to null
            if (requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_VpcIsNull)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc = null;
            }
            if (requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc != null)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster.Vpc = requestKafkaCluster_kafkaCluster_ApacheKafkaCluster_kafkaCluster_ApacheKafkaCluster_Vpc;
                requestKafkaCluster_kafkaCluster_ApacheKafkaClusterIsNull = false;
            }
             // determine if requestKafkaCluster_kafkaCluster_ApacheKafkaCluster should be set to null
            if (requestKafkaCluster_kafkaCluster_ApacheKafkaClusterIsNull)
            {
                requestKafkaCluster_kafkaCluster_ApacheKafkaCluster = null;
            }
            if (requestKafkaCluster_kafkaCluster_ApacheKafkaCluster != null)
            {
                request.KafkaCluster.ApacheKafkaCluster = requestKafkaCluster_kafkaCluster_ApacheKafkaCluster;
                requestKafkaClusterIsNull = false;
            }
             // determine if request.KafkaCluster should be set to null
            if (requestKafkaClusterIsNull)
            {
                request.KafkaCluster = null;
            }
            
             // populate KafkaClusterClientAuthentication
            var requestKafkaClusterClientAuthenticationIsNull = true;
            request.KafkaClusterClientAuthentication = new Amazon.KafkaConnect.Model.KafkaClusterClientAuthentication();
            Amazon.KafkaConnect.KafkaClusterClientAuthenticationType requestKafkaClusterClientAuthentication_kafkaClusterClientAuthentication_AuthenticationType = null;
            if (cmdletContext.KafkaClusterClientAuthentication_AuthenticationType != null)
            {
                requestKafkaClusterClientAuthentication_kafkaClusterClientAuthentication_AuthenticationType = cmdletContext.KafkaClusterClientAuthentication_AuthenticationType;
            }
            if (requestKafkaClusterClientAuthentication_kafkaClusterClientAuthentication_AuthenticationType != null)
            {
                request.KafkaClusterClientAuthentication.AuthenticationType = requestKafkaClusterClientAuthentication_kafkaClusterClientAuthentication_AuthenticationType;
                requestKafkaClusterClientAuthenticationIsNull = false;
            }
             // determine if request.KafkaClusterClientAuthentication should be set to null
            if (requestKafkaClusterClientAuthenticationIsNull)
            {
                request.KafkaClusterClientAuthentication = null;
            }
            
             // populate KafkaClusterEncryptionInTransit
            var requestKafkaClusterEncryptionInTransitIsNull = true;
            request.KafkaClusterEncryptionInTransit = new Amazon.KafkaConnect.Model.KafkaClusterEncryptionInTransit();
            Amazon.KafkaConnect.KafkaClusterEncryptionInTransitType requestKafkaClusterEncryptionInTransit_kafkaClusterEncryptionInTransit_EncryptionType = null;
            if (cmdletContext.KafkaClusterEncryptionInTransit_EncryptionType != null)
            {
                requestKafkaClusterEncryptionInTransit_kafkaClusterEncryptionInTransit_EncryptionType = cmdletContext.KafkaClusterEncryptionInTransit_EncryptionType;
            }
            if (requestKafkaClusterEncryptionInTransit_kafkaClusterEncryptionInTransit_EncryptionType != null)
            {
                request.KafkaClusterEncryptionInTransit.EncryptionType = requestKafkaClusterEncryptionInTransit_kafkaClusterEncryptionInTransit_EncryptionType;
                requestKafkaClusterEncryptionInTransitIsNull = false;
            }
             // determine if request.KafkaClusterEncryptionInTransit should be set to null
            if (requestKafkaClusterEncryptionInTransitIsNull)
            {
                request.KafkaClusterEncryptionInTransit = null;
            }
            if (cmdletContext.KafkaConnectVersion != null)
            {
                request.KafkaConnectVersion = cmdletContext.KafkaConnectVersion;
            }
            
             // populate LogDelivery
            var requestLogDeliveryIsNull = true;
            request.LogDelivery = new Amazon.KafkaConnect.Model.LogDelivery();
            Amazon.KafkaConnect.Model.WorkerLogDelivery requestLogDelivery_logDelivery_WorkerLogDelivery = null;
            
             // populate WorkerLogDelivery
            var requestLogDelivery_logDelivery_WorkerLogDeliveryIsNull = true;
            requestLogDelivery_logDelivery_WorkerLogDelivery = new Amazon.KafkaConnect.Model.WorkerLogDelivery();
            Amazon.KafkaConnect.Model.CloudWatchLogsLogDelivery requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogsIsNull = true;
            requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs = new Amazon.KafkaConnect.Model.CloudWatchLogsLogDelivery();
            System.Boolean? requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_Enabled = null;
            if (cmdletContext.CloudWatchLogs_Enabled != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_Enabled = cmdletContext.CloudWatchLogs_Enabled.Value;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_Enabled != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs.Enabled = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_Enabled.Value;
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogsIsNull = false;
            }
            System.String requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup = null;
            if (cmdletContext.CloudWatchLogs_LogGroup != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup = cmdletContext.CloudWatchLogs_LogGroup;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs.LogGroup = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs_cloudWatchLogs_LogGroup;
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogsIsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs should be set to null
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogsIsNull)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs = null;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery.CloudWatchLogs = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_CloudWatchLogs;
                requestLogDelivery_logDelivery_WorkerLogDeliveryIsNull = false;
            }
            Amazon.KafkaConnect.Model.FirehoseLogDelivery requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose = null;
            
             // populate Firehose
            var requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_FirehoseIsNull = true;
            requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose = new Amazon.KafkaConnect.Model.FirehoseLogDelivery();
            System.String requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_DeliveryStream = null;
            if (cmdletContext.Firehose_DeliveryStream != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_DeliveryStream = cmdletContext.Firehose_DeliveryStream;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_DeliveryStream != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose.DeliveryStream = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_DeliveryStream;
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_FirehoseIsNull = false;
            }
            System.Boolean? requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_Enabled = null;
            if (cmdletContext.Firehose_Enabled != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_Enabled = cmdletContext.Firehose_Enabled.Value;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_Enabled != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose.Enabled = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose_firehose_Enabled.Value;
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_FirehoseIsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose should be set to null
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_FirehoseIsNull)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose = null;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery.Firehose = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_Firehose;
                requestLogDelivery_logDelivery_WorkerLogDeliveryIsNull = false;
            }
            Amazon.KafkaConnect.Model.S3LogDelivery requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3 = null;
            
             // populate S3
            var requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3IsNull = true;
            requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3 = new Amazon.KafkaConnect.Model.S3LogDelivery();
            System.String requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Bucket != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3.Bucket = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Bucket;
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3IsNull = false;
            }
            System.Boolean? requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Enabled = null;
            if (cmdletContext.S3_Enabled != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Enabled = cmdletContext.S3_Enabled.Value;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Enabled != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3.Enabled = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Enabled.Value;
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3IsNull = false;
            }
            System.String requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Prefix != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3.Prefix = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3_s3_Prefix;
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3IsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3 should be set to null
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3IsNull)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3 = null;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3 != null)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery.S3 = requestLogDelivery_logDelivery_WorkerLogDelivery_logDelivery_WorkerLogDelivery_S3;
                requestLogDelivery_logDelivery_WorkerLogDeliveryIsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_WorkerLogDelivery should be set to null
            if (requestLogDelivery_logDelivery_WorkerLogDeliveryIsNull)
            {
                requestLogDelivery_logDelivery_WorkerLogDelivery = null;
            }
            if (requestLogDelivery_logDelivery_WorkerLogDelivery != null)
            {
                request.LogDelivery.WorkerLogDelivery = requestLogDelivery_logDelivery_WorkerLogDelivery;
                requestLogDeliveryIsNull = false;
            }
             // determine if request.LogDelivery should be set to null
            if (requestLogDeliveryIsNull)
            {
                request.LogDelivery = null;
            }
            if (cmdletContext.Plugin != null)
            {
                request.Plugins = cmdletContext.Plugin;
            }
            if (cmdletContext.ServiceExecutionRoleArn != null)
            {
                request.ServiceExecutionRoleArn = cmdletContext.ServiceExecutionRoleArn;
            }
            
             // populate WorkerConfiguration
            var requestWorkerConfigurationIsNull = true;
            request.WorkerConfiguration = new Amazon.KafkaConnect.Model.WorkerConfiguration();
            System.Int64? requestWorkerConfiguration_workerConfiguration_Revision = null;
            if (cmdletContext.WorkerConfiguration_Revision != null)
            {
                requestWorkerConfiguration_workerConfiguration_Revision = cmdletContext.WorkerConfiguration_Revision.Value;
            }
            if (requestWorkerConfiguration_workerConfiguration_Revision != null)
            {
                request.WorkerConfiguration.Revision = requestWorkerConfiguration_workerConfiguration_Revision.Value;
                requestWorkerConfigurationIsNull = false;
            }
            System.String requestWorkerConfiguration_workerConfiguration_WorkerConfigurationArn = null;
            if (cmdletContext.WorkerConfiguration_WorkerConfigurationArn != null)
            {
                requestWorkerConfiguration_workerConfiguration_WorkerConfigurationArn = cmdletContext.WorkerConfiguration_WorkerConfigurationArn;
            }
            if (requestWorkerConfiguration_workerConfiguration_WorkerConfigurationArn != null)
            {
                request.WorkerConfiguration.WorkerConfigurationArn = requestWorkerConfiguration_workerConfiguration_WorkerConfigurationArn;
                requestWorkerConfigurationIsNull = false;
            }
             // determine if request.WorkerConfiguration should be set to null
            if (requestWorkerConfigurationIsNull)
            {
                request.WorkerConfiguration = null;
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
        
        private Amazon.KafkaConnect.Model.CreateConnectorResponse CallAWSServiceOperation(IAmazonKafkaConnect client, Amazon.KafkaConnect.Model.CreateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed Streaming for Kafka Connect", "CreateConnector");
            try
            {
                #if DESKTOP
                return client.CreateConnector(request);
                #elif CORECLR
                return client.CreateConnectorAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? AutoScaling_MaxWorkerCount { get; set; }
            public System.Int32? AutoScaling_McuCount { get; set; }
            public System.Int32? AutoScaling_MinWorkerCount { get; set; }
            public System.Int32? ScaleInPolicy_CpuUtilizationPercentage { get; set; }
            public System.Int32? ScaleOutPolicy_CpuUtilizationPercentage { get; set; }
            public System.Int32? ProvisionedCapacity_McuCount { get; set; }
            public System.Int32? ProvisionedCapacity_WorkerCount { get; set; }
            public Dictionary<System.String, System.String> ConnectorConfiguration { get; set; }
            public System.String ConnectorDescription { get; set; }
            public System.String ConnectorName { get; set; }
            public System.String ApacheKafkaCluster_BootstrapServer { get; set; }
            public List<System.String> Vpc_SecurityGroup { get; set; }
            public List<System.String> Vpc_Subnet { get; set; }
            public Amazon.KafkaConnect.KafkaClusterClientAuthenticationType KafkaClusterClientAuthentication_AuthenticationType { get; set; }
            public Amazon.KafkaConnect.KafkaClusterEncryptionInTransitType KafkaClusterEncryptionInTransit_EncryptionType { get; set; }
            public System.String KafkaConnectVersion { get; set; }
            public System.Boolean? CloudWatchLogs_Enabled { get; set; }
            public System.String CloudWatchLogs_LogGroup { get; set; }
            public System.String Firehose_DeliveryStream { get; set; }
            public System.Boolean? Firehose_Enabled { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.Boolean? S3_Enabled { get; set; }
            public System.String S3_Prefix { get; set; }
            public List<Amazon.KafkaConnect.Model.Plugin> Plugin { get; set; }
            public System.String ServiceExecutionRoleArn { get; set; }
            public System.Int64? WorkerConfiguration_Revision { get; set; }
            public System.String WorkerConfiguration_WorkerConfigurationArn { get; set; }
            public System.Func<Amazon.KafkaConnect.Model.CreateConnectorResponse, NewMSKCConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
