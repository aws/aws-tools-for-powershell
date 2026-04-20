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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Creates the replicator.
    /// </summary>
    [Cmdlet("New", "MSKReplicator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.CreateReplicatorResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) CreateReplicator API operation.", Operation = new[] {"CreateReplicator"}, SelectReturnType = typeof(Amazon.Kafka.Model.CreateReplicatorResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.CreateReplicatorResponse",
        "This cmdlet returns an Amazon.Kafka.Model.CreateReplicatorResponse object containing multiple properties."
    )]
    public partial class NewMSKReplicatorCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogDelivery_ReplicatorLogDelivery_S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket that is the destination for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDelivery_ReplicatorLogDelivery_S3_Bucket { get; set; }
        #endregion
        
        #region Parameter LogDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream
        /// <summary>
        /// <para>
        /// <para>The Firehose delivery stream that is the destination for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A summary description of the replicator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether log delivery to CloudWatch Logs is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter LogDelivery_ReplicatorLogDelivery_Firehose_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether log delivery to Firehose is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LogDelivery_ReplicatorLogDelivery_Firehose_Enabled { get; set; }
        #endregion
        
        #region Parameter LogDelivery_ReplicatorLogDelivery_S3_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether log delivery to S3 is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LogDelivery_ReplicatorLogDelivery_S3_Enabled { get; set; }
        #endregion
        
        #region Parameter KafkaCluster
        /// <summary>
        /// <para>
        /// <para>Kafka Clusters to use in setting up sources / targets for replication.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("KafkaClusters")]
        public Amazon.Kafka.Model.KafkaCluster[] KafkaCluster { get; set; }
        #endregion
        
        #region Parameter LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log group that is the destination for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter LogDelivery_ReplicatorLogDelivery_S3_Prefix
        /// <summary>
        /// <para>
        /// <para>The S3 prefix that is the destination for log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDelivery_ReplicatorLogDelivery_S3_Prefix { get; set; }
        #endregion
        
        #region Parameter ReplicationInfoList
        /// <summary>
        /// <para>
        /// <para>A list of replication configurations, where each configuration targets a given source
        /// cluster to target cluster replication flow.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        public Amazon.Kafka.Model.ReplicationInfo[] ReplicationInfoList { get; set; }
        #endregion
        
        #region Parameter ReplicatorName
        /// <summary>
        /// <para>
        /// <para>The name of the replicator. Alpha-numeric characters with '-' are allowed.</para>
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
        public System.String ReplicatorName { get; set; }
        #endregion
        
        #region Parameter ServiceExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role used by the replicator to access resources in the customer's
        /// account (e.g source and target clusters)</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>List of tags to attach to created Replicator.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.CreateReplicatorResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.CreateReplicatorResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicatorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKReplicator (CreateReplicator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.CreateReplicatorResponse, NewMSKReplicatorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            if (this.KafkaCluster != null)
            {
                context.KafkaCluster = new List<Amazon.Kafka.Model.KafkaCluster>(this.KafkaCluster);
            }
            #if MODULAR
            if (this.KafkaCluster == null && ParameterWasBound(nameof(this.KafkaCluster)))
            {
                WriteWarning("You are passing $null as a value for parameter KafkaCluster which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled = this.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled;
            context.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup = this.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup;
            context.LogDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream = this.LogDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream;
            context.LogDelivery_ReplicatorLogDelivery_Firehose_Enabled = this.LogDelivery_ReplicatorLogDelivery_Firehose_Enabled;
            context.LogDelivery_ReplicatorLogDelivery_S3_Bucket = this.LogDelivery_ReplicatorLogDelivery_S3_Bucket;
            context.LogDelivery_ReplicatorLogDelivery_S3_Enabled = this.LogDelivery_ReplicatorLogDelivery_S3_Enabled;
            context.LogDelivery_ReplicatorLogDelivery_S3_Prefix = this.LogDelivery_ReplicatorLogDelivery_S3_Prefix;
            if (this.ReplicationInfoList != null)
            {
                context.ReplicationInfoList = new List<Amazon.Kafka.Model.ReplicationInfo>(this.ReplicationInfoList);
            }
            #if MODULAR
            if (this.ReplicationInfoList == null && ParameterWasBound(nameof(this.ReplicationInfoList)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationInfoList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicatorName = this.ReplicatorName;
            #if MODULAR
            if (this.ReplicatorName == null && ParameterWasBound(nameof(this.ReplicatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceExecutionRoleArn = this.ServiceExecutionRoleArn;
            #if MODULAR
            if (this.ServiceExecutionRoleArn == null && ParameterWasBound(nameof(this.ServiceExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Kafka.Model.CreateReplicatorRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KafkaCluster != null)
            {
                request.KafkaClusters = cmdletContext.KafkaCluster;
            }
            
             // populate LogDelivery
            var requestLogDeliveryIsNull = true;
            request.LogDelivery = new Amazon.Kafka.Model.LogDelivery();
            Amazon.Kafka.Model.ReplicatorLogDelivery requestLogDelivery_logDelivery_ReplicatorLogDelivery = null;
            
             // populate ReplicatorLogDelivery
            var requestLogDelivery_logDelivery_ReplicatorLogDeliveryIsNull = true;
            requestLogDelivery_logDelivery_ReplicatorLogDelivery = new Amazon.Kafka.Model.ReplicatorLogDelivery();
            Amazon.Kafka.Model.ReplicatorCloudWatchLogs requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogsIsNull = true;
            requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs = new Amazon.Kafka.Model.ReplicatorCloudWatchLogs();
            System.Boolean? requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled = null;
            if (cmdletContext.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled = cmdletContext.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled.Value;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs.Enabled = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled.Value;
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogsIsNull = false;
            }
            System.String requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup = null;
            if (cmdletContext.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup = cmdletContext.LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs.LogGroup = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_logDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup;
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogsIsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs should be set to null
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogsIsNull)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs = null;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery.CloudWatchLogs = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_CloudWatchLogs;
                requestLogDelivery_logDelivery_ReplicatorLogDeliveryIsNull = false;
            }
            Amazon.Kafka.Model.ReplicatorFirehose requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose = null;
            
             // populate Firehose
            var requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_FirehoseIsNull = true;
            requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose = new Amazon.Kafka.Model.ReplicatorFirehose();
            System.String requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream = null;
            if (cmdletContext.LogDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream = cmdletContext.LogDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose.DeliveryStream = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream;
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_FirehoseIsNull = false;
            }
            System.Boolean? requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_Enabled = null;
            if (cmdletContext.LogDelivery_ReplicatorLogDelivery_Firehose_Enabled != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_Enabled = cmdletContext.LogDelivery_ReplicatorLogDelivery_Firehose_Enabled.Value;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_Enabled != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose.Enabled = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose_logDelivery_ReplicatorLogDelivery_Firehose_Enabled.Value;
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_FirehoseIsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose should be set to null
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_FirehoseIsNull)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose = null;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery.Firehose = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_Firehose;
                requestLogDelivery_logDelivery_ReplicatorLogDeliveryIsNull = false;
            }
            Amazon.Kafka.Model.ReplicatorS3 requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3 = null;
            
             // populate S3
            var requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3IsNull = true;
            requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3 = new Amazon.Kafka.Model.ReplicatorS3();
            System.String requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Bucket = null;
            if (cmdletContext.LogDelivery_ReplicatorLogDelivery_S3_Bucket != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Bucket = cmdletContext.LogDelivery_ReplicatorLogDelivery_S3_Bucket;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Bucket != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3.Bucket = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Bucket;
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3IsNull = false;
            }
            System.Boolean? requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Enabled = null;
            if (cmdletContext.LogDelivery_ReplicatorLogDelivery_S3_Enabled != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Enabled = cmdletContext.LogDelivery_ReplicatorLogDelivery_S3_Enabled.Value;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Enabled != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3.Enabled = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Enabled.Value;
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3IsNull = false;
            }
            System.String requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Prefix = null;
            if (cmdletContext.LogDelivery_ReplicatorLogDelivery_S3_Prefix != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Prefix = cmdletContext.LogDelivery_ReplicatorLogDelivery_S3_Prefix;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Prefix != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3.Prefix = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3_logDelivery_ReplicatorLogDelivery_S3_Prefix;
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3IsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3 should be set to null
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3IsNull)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3 = null;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3 != null)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery.S3 = requestLogDelivery_logDelivery_ReplicatorLogDelivery_logDelivery_ReplicatorLogDelivery_S3;
                requestLogDelivery_logDelivery_ReplicatorLogDeliveryIsNull = false;
            }
             // determine if requestLogDelivery_logDelivery_ReplicatorLogDelivery should be set to null
            if (requestLogDelivery_logDelivery_ReplicatorLogDeliveryIsNull)
            {
                requestLogDelivery_logDelivery_ReplicatorLogDelivery = null;
            }
            if (requestLogDelivery_logDelivery_ReplicatorLogDelivery != null)
            {
                request.LogDelivery.ReplicatorLogDelivery = requestLogDelivery_logDelivery_ReplicatorLogDelivery;
                requestLogDeliveryIsNull = false;
            }
             // determine if request.LogDelivery should be set to null
            if (requestLogDeliveryIsNull)
            {
                request.LogDelivery = null;
            }
            if (cmdletContext.ReplicationInfoList != null)
            {
                request.ReplicationInfoList = cmdletContext.ReplicationInfoList;
            }
            if (cmdletContext.ReplicatorName != null)
            {
                request.ReplicatorName = cmdletContext.ReplicatorName;
            }
            if (cmdletContext.ServiceExecutionRoleArn != null)
            {
                request.ServiceExecutionRoleArn = cmdletContext.ServiceExecutionRoleArn;
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
        
        private Amazon.Kafka.Model.CreateReplicatorResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.CreateReplicatorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "CreateReplicator");
            try
            {
                return client.CreateReplicatorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<Amazon.Kafka.Model.KafkaCluster> KafkaCluster { get; set; }
            public System.Boolean? LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_Enabled { get; set; }
            public System.String LogDelivery_ReplicatorLogDelivery_CloudWatchLogs_LogGroup { get; set; }
            public System.String LogDelivery_ReplicatorLogDelivery_Firehose_DeliveryStream { get; set; }
            public System.Boolean? LogDelivery_ReplicatorLogDelivery_Firehose_Enabled { get; set; }
            public System.String LogDelivery_ReplicatorLogDelivery_S3_Bucket { get; set; }
            public System.Boolean? LogDelivery_ReplicatorLogDelivery_S3_Enabled { get; set; }
            public System.String LogDelivery_ReplicatorLogDelivery_S3_Prefix { get; set; }
            public List<Amazon.Kafka.Model.ReplicationInfo> ReplicationInfoList { get; set; }
            public System.String ReplicatorName { get; set; }
            public System.String ServiceExecutionRoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kafka.Model.CreateReplicatorResponse, NewMSKReplicatorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
