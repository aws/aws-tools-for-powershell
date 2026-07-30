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
    /// Creates a Channel that streams records from an Amazon MSK Express cluster topic to
    /// Amazon S3 or Apache Iceberg.
    /// </summary>
    [Cmdlet("New", "MSKChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.CreateChannelResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) CreateChannel API operation.", Operation = new[] {"CreateChannel"}, SelectReturnType = typeof(Amazon.Kafka.Model.CreateChannelResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.CreateChannelResponse",
        "This cmdlet returns an Amazon.Kafka.Model.CreateChannelResponse object containing multiple properties."
    )]
    public partial class NewMSKChannelCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IcebergDestinationConfiguration_AppendOnly
        /// <summary>
        /// <para>
        /// <para>Whether the destination is append-only. Must be true; updates and deletes are not
        /// supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IcebergDestinationConfiguration_AppendOnly { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3_Bucket
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingInfo_S3_Bucket { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_DeadLetterQueueS3_BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dead-letter Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_DeadLetterQueueS3_BucketArn { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DeadLetterQueueS3_BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dead-letter Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_DeadLetterQueueS3_BucketArn { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_Storage_BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_Storage_BucketArn { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_Catalog_CatalogArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the federated AWS Glue Data Catalog that projects
        /// the S3 Tables bucket. If omitted, MSK derives the catalog ARN from warehouseLocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_Catalog_CatalogArn { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the channel. Must be unique within the cluster.</para>
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
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the cluster.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_CompressionType
        /// <summary>
        /// <para>
        /// <para>The compression codec for Iceberg table data files. Defaults to ZSTD.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.IcebergCompressionType")]
        public Amazon.Kafka.IcebergCompressionType IcebergDestinationConfiguration_CompressionType { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_Storage_CompressionType
        /// <summary>
        /// <para>
        /// <para>The compression codec applied to delivered Amazon S3 objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.S3CompressionType")]
        public Amazon.Kafka.S3CompressionType S3DestinationConfiguration_Storage_CompressionType { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_DataFreshnessInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that records buffer in MSK before being flushed to the
        /// destination. Allowed range: 300 to 900. Default: 600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IcebergDestinationConfiguration_DataFreshnessInSeconds")]
        public System.Int32? IcebergDestinationConfiguration_DataFreshnessInSecond { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DataFreshnessInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that records buffer in MSK before being flushed to the
        /// destination. Allowed range: 300 to 900. Default: 600.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3DestinationConfiguration_DataFreshnessInSeconds")]
        public System.Int32? S3DestinationConfiguration_DataFreshnessInSecond { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_Firehose_DeliveryStream
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingInfo_Firehose_DeliveryStream { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_DestinationTableList
        /// <summary>
        /// <para>
        /// <para>The destination Iceberg tables. Currently exactly one table must be specified.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kafka.Model.DestinationTable[] IcebergDestinationConfiguration_DestinationTableList { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingInfo_CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_Firehose_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingInfo_Firehose_Enabled { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingInfo_S3_Enabled { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution
        /// <summary>
        /// <para>
        /// <para>Whether to allow MSK to evolve the destination table's schema. Must be false for the
        /// current release.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IcebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_TableCreation_EnableTableCreation
        /// <summary>
        /// <para>
        /// <para>Whether MSK creates the destination table on the customer's behalf. Must be true for
        /// the current release.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IcebergDestinationConfiguration_TableCreation_EnableTableCreation { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix
        /// <summary>
        /// <para>
        /// <para>An optional prefix prepended to every dead-letter Amazon S3 object key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix
        /// <summary>
        /// <para>
        /// <para>An optional prefix prepended to every dead-letter Amazon S3 object key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>Optional 12-digit AWS account ID expected to own the dead-letter Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>Optional 12-digit AWS account ID expected to own the dead-letter Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_Storage_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>Optional 12-digit AWS account ID expected to own the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_Storage_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS KMS key used to encrypt the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingInfo_CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_Storage_OutputKeyTemplate
        /// <summary>
        /// <para>
        /// <para>An optional template that controls the Amazon S3 object key for each delivered record.
        /// Supports the placeholders !{partition-id}, !{sequence-number}, and !{kafka-offset}.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_Storage_OutputKeyTemplate { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_Storage_OutputPrefix
        /// <summary>
        /// <para>
        /// <para>An optional prefix prepended to every Amazon S3 object key written by the channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_Storage_OutputPrefix { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3_Prefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingInfo_S3_Prefix { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_ServiceExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that MSK assumes to access the destination
        /// table, the AWS Glue Data Catalog, and the dead-letter Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_ServiceExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_ServiceExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that MSK assumes to write to the destination
        /// Amazon S3 bucket and the dead-letter bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_ServiceExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_Storage_StorageClass
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 storage class for delivered objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.S3StorageClass")]
        public Amazon.Kafka.S3StorageClass S3DestinationConfiguration_Storage_StorageClass { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags attached to the channel.</para><para />
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
        
        #region Parameter TopicConfigurationList
        /// <summary>
        /// <para>
        /// <para>The list of topic configurations for the channel. Currently exactly one topic must
        /// be specified.</para><para />
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
        public Amazon.Kafka.Model.TopicConfiguration[] TopicConfigurationList { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_Catalog_WarehouseLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the S3 Tables bucket that backs the Apache Iceberg
        /// warehouse.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_Catalog_WarehouseLocation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.CreateChannelResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.CreateChannelResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKChannel (CreateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.CreateChannelResponse, NewMSKChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.IcebergDestinationConfiguration_AppendOnly = this.IcebergDestinationConfiguration_AppendOnly;
            context.IcebergDestinationConfiguration_Catalog_CatalogArn = this.IcebergDestinationConfiguration_Catalog_CatalogArn;
            context.IcebergDestinationConfiguration_Catalog_WarehouseLocation = this.IcebergDestinationConfiguration_Catalog_WarehouseLocation;
            context.IcebergDestinationConfiguration_CompressionType = this.IcebergDestinationConfiguration_CompressionType;
            context.IcebergDestinationConfiguration_DataFreshnessInSecond = this.IcebergDestinationConfiguration_DataFreshnessInSecond;
            context.IcebergDestinationConfiguration_DeadLetterQueueS3_BucketArn = this.IcebergDestinationConfiguration_DeadLetterQueueS3_BucketArn;
            context.IcebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix = this.IcebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix;
            context.IcebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner = this.IcebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner;
            if (this.IcebergDestinationConfiguration_DestinationTableList != null)
            {
                context.IcebergDestinationConfiguration_DestinationTableList = new List<Amazon.Kafka.Model.DestinationTable>(this.IcebergDestinationConfiguration_DestinationTableList);
            }
            context.IcebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution = this.IcebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution;
            context.IcebergDestinationConfiguration_ServiceExecutionRoleArn = this.IcebergDestinationConfiguration_ServiceExecutionRoleArn;
            context.IcebergDestinationConfiguration_TableCreation_EnableTableCreation = this.IcebergDestinationConfiguration_TableCreation_EnableTableCreation;
            context.LoggingInfo_CloudWatchLogs_Enabled = this.LoggingInfo_CloudWatchLogs_Enabled;
            context.LoggingInfo_CloudWatchLogs_LogGroup = this.LoggingInfo_CloudWatchLogs_LogGroup;
            context.LoggingInfo_Firehose_DeliveryStream = this.LoggingInfo_Firehose_DeliveryStream;
            context.LoggingInfo_Firehose_Enabled = this.LoggingInfo_Firehose_Enabled;
            context.LoggingInfo_S3_Bucket = this.LoggingInfo_S3_Bucket;
            context.LoggingInfo_S3_Enabled = this.LoggingInfo_S3_Enabled;
            context.LoggingInfo_S3_Prefix = this.LoggingInfo_S3_Prefix;
            context.S3DestinationConfiguration_DataFreshnessInSecond = this.S3DestinationConfiguration_DataFreshnessInSecond;
            context.S3DestinationConfiguration_DeadLetterQueueS3_BucketArn = this.S3DestinationConfiguration_DeadLetterQueueS3_BucketArn;
            context.S3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix = this.S3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix;
            context.S3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner = this.S3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner;
            context.S3DestinationConfiguration_ServiceExecutionRoleArn = this.S3DestinationConfiguration_ServiceExecutionRoleArn;
            context.S3DestinationConfiguration_Storage_BucketArn = this.S3DestinationConfiguration_Storage_BucketArn;
            context.S3DestinationConfiguration_Storage_CompressionType = this.S3DestinationConfiguration_Storage_CompressionType;
            context.S3DestinationConfiguration_Storage_ExpectedBucketOwner = this.S3DestinationConfiguration_Storage_ExpectedBucketOwner;
            context.S3DestinationConfiguration_Storage_OutputKeyTemplate = this.S3DestinationConfiguration_Storage_OutputKeyTemplate;
            context.S3DestinationConfiguration_Storage_OutputPrefix = this.S3DestinationConfiguration_Storage_OutputPrefix;
            context.S3DestinationConfiguration_Storage_StorageClass = this.S3DestinationConfiguration_Storage_StorageClass;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.TopicConfigurationList != null)
            {
                context.TopicConfigurationList = new List<Amazon.Kafka.Model.TopicConfiguration>(this.TopicConfigurationList);
            }
            #if MODULAR
            if (this.TopicConfigurationList == null && ParameterWasBound(nameof(this.TopicConfigurationList)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicConfigurationList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Kafka.Model.CreateChannelRequest();
            
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.Kafka.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                request.EncryptionConfiguration.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate IcebergDestinationConfiguration
            var requestIcebergDestinationConfigurationIsNull = true;
            request.IcebergDestinationConfiguration = new Amazon.Kafka.Model.IcebergDestinationConfiguration();
            System.Boolean? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_AppendOnly = null;
            if (cmdletContext.IcebergDestinationConfiguration_AppendOnly != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_AppendOnly = cmdletContext.IcebergDestinationConfiguration_AppendOnly.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_AppendOnly != null)
            {
                request.IcebergDestinationConfiguration.AppendOnly = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_AppendOnly.Value;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.Kafka.IcebergCompressionType requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CompressionType = null;
            if (cmdletContext.IcebergDestinationConfiguration_CompressionType != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CompressionType = cmdletContext.IcebergDestinationConfiguration_CompressionType;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CompressionType != null)
            {
                request.IcebergDestinationConfiguration.CompressionType = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CompressionType;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            System.Int32? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DataFreshnessInSecond = null;
            if (cmdletContext.IcebergDestinationConfiguration_DataFreshnessInSecond != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DataFreshnessInSecond = cmdletContext.IcebergDestinationConfiguration_DataFreshnessInSecond.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DataFreshnessInSecond != null)
            {
                request.IcebergDestinationConfiguration.DataFreshnessInSeconds = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DataFreshnessInSecond.Value;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            List<Amazon.Kafka.Model.DestinationTable> requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableList = null;
            if (cmdletContext.IcebergDestinationConfiguration_DestinationTableList != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableList = cmdletContext.IcebergDestinationConfiguration_DestinationTableList;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableList != null)
            {
                request.IcebergDestinationConfiguration.DestinationTableList = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableList;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ServiceExecutionRoleArn = null;
            if (cmdletContext.IcebergDestinationConfiguration_ServiceExecutionRoleArn != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ServiceExecutionRoleArn = cmdletContext.IcebergDestinationConfiguration_ServiceExecutionRoleArn;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ServiceExecutionRoleArn != null)
            {
                request.IcebergDestinationConfiguration.ServiceExecutionRoleArn = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ServiceExecutionRoleArn;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.Kafka.Model.SchemaEvolution requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution = null;
            
             // populate SchemaEvolution
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution = new Amazon.Kafka.Model.SchemaEvolution();
            System.Boolean? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution_icebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution = null;
            if (cmdletContext.IcebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution_icebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution = cmdletContext.IcebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution_icebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution.EnableSchemaEvolution = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution_icebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution != null)
            {
                request.IcebergDestinationConfiguration.SchemaEvolution = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolution;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.Kafka.Model.TableCreation requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation = null;
            
             // populate TableCreation
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation = new Amazon.Kafka.Model.TableCreation();
            System.Boolean? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation_icebergDestinationConfiguration_TableCreation_EnableTableCreation = null;
            if (cmdletContext.IcebergDestinationConfiguration_TableCreation_EnableTableCreation != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation_icebergDestinationConfiguration_TableCreation_EnableTableCreation = cmdletContext.IcebergDestinationConfiguration_TableCreation_EnableTableCreation.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation_icebergDestinationConfiguration_TableCreation_EnableTableCreation != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation.EnableTableCreation = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation_icebergDestinationConfiguration_TableCreation_EnableTableCreation.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation != null)
            {
                request.IcebergDestinationConfiguration.TableCreation = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreation;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.Kafka.Model.Catalog requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog = null;
            
             // populate Catalog
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog = new Amazon.Kafka.Model.Catalog();
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_CatalogArn = null;
            if (cmdletContext.IcebergDestinationConfiguration_Catalog_CatalogArn != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_CatalogArn = cmdletContext.IcebergDestinationConfiguration_Catalog_CatalogArn;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_CatalogArn != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog.CatalogArn = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_CatalogArn;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogIsNull = false;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_WarehouseLocation = null;
            if (cmdletContext.IcebergDestinationConfiguration_Catalog_WarehouseLocation != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_WarehouseLocation = cmdletContext.IcebergDestinationConfiguration_Catalog_WarehouseLocation;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_WarehouseLocation != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog.WarehouseLocation = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog_icebergDestinationConfiguration_Catalog_WarehouseLocation;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog != null)
            {
                request.IcebergDestinationConfiguration.Catalog = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_Catalog;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.Kafka.Model.DeadLetterQueueS3 requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3 = null;
            
             // populate DeadLetterQueueS3
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3IsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3 = new Amazon.Kafka.Model.DeadLetterQueueS3();
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_BucketArn = null;
            if (cmdletContext.IcebergDestinationConfiguration_DeadLetterQueueS3_BucketArn != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_BucketArn = cmdletContext.IcebergDestinationConfiguration_DeadLetterQueueS3_BucketArn;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_BucketArn != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3.BucketArn = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_BucketArn;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3IsNull = false;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix = null;
            if (cmdletContext.IcebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix = cmdletContext.IcebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3.ErrorOutputPrefix = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3IsNull = false;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner = null;
            if (cmdletContext.IcebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner = cmdletContext.IcebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3.ExpectedBucketOwner = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3_icebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3IsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3 should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3IsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3 = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3 != null)
            {
                request.IcebergDestinationConfiguration.DeadLetterQueueS3 = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DeadLetterQueueS3;
                requestIcebergDestinationConfigurationIsNull = false;
            }
             // determine if request.IcebergDestinationConfiguration should be set to null
            if (requestIcebergDestinationConfigurationIsNull)
            {
                request.IcebergDestinationConfiguration = null;
            }
            
             // populate LoggingInfo
            var requestLoggingInfoIsNull = true;
            request.LoggingInfo = new Amazon.Kafka.Model.ChannelLoggingInfo();
            Amazon.Kafka.Model.CloudWatchLogs requestLoggingInfo_loggingInfo_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLoggingInfo_loggingInfo_CloudWatchLogsIsNull = true;
            requestLoggingInfo_loggingInfo_CloudWatchLogs = new Amazon.Kafka.Model.CloudWatchLogs();
            System.Boolean? requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_Enabled = null;
            if (cmdletContext.LoggingInfo_CloudWatchLogs_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_Enabled = cmdletContext.LoggingInfo_CloudWatchLogs_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_CloudWatchLogs.Enabled = requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_Enabled.Value;
                requestLoggingInfo_loggingInfo_CloudWatchLogsIsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_LogGroup = null;
            if (cmdletContext.LoggingInfo_CloudWatchLogs_LogGroup != null)
            {
                requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_LogGroup = cmdletContext.LoggingInfo_CloudWatchLogs_LogGroup;
            }
            if (requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_LogGroup != null)
            {
                requestLoggingInfo_loggingInfo_CloudWatchLogs.LogGroup = requestLoggingInfo_loggingInfo_CloudWatchLogs_loggingInfo_CloudWatchLogs_LogGroup;
                requestLoggingInfo_loggingInfo_CloudWatchLogsIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_CloudWatchLogs should be set to null
            if (requestLoggingInfo_loggingInfo_CloudWatchLogsIsNull)
            {
                requestLoggingInfo_loggingInfo_CloudWatchLogs = null;
            }
            if (requestLoggingInfo_loggingInfo_CloudWatchLogs != null)
            {
                request.LoggingInfo.CloudWatchLogs = requestLoggingInfo_loggingInfo_CloudWatchLogs;
                requestLoggingInfoIsNull = false;
            }
            Amazon.Kafka.Model.Firehose requestLoggingInfo_loggingInfo_Firehose = null;
            
             // populate Firehose
            var requestLoggingInfo_loggingInfo_FirehoseIsNull = true;
            requestLoggingInfo_loggingInfo_Firehose = new Amazon.Kafka.Model.Firehose();
            System.String requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_DeliveryStream = null;
            if (cmdletContext.LoggingInfo_Firehose_DeliveryStream != null)
            {
                requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_DeliveryStream = cmdletContext.LoggingInfo_Firehose_DeliveryStream;
            }
            if (requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_DeliveryStream != null)
            {
                requestLoggingInfo_loggingInfo_Firehose.DeliveryStream = requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_DeliveryStream;
                requestLoggingInfo_loggingInfo_FirehoseIsNull = false;
            }
            System.Boolean? requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_Enabled = null;
            if (cmdletContext.LoggingInfo_Firehose_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_Enabled = cmdletContext.LoggingInfo_Firehose_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_Firehose.Enabled = requestLoggingInfo_loggingInfo_Firehose_loggingInfo_Firehose_Enabled.Value;
                requestLoggingInfo_loggingInfo_FirehoseIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_Firehose should be set to null
            if (requestLoggingInfo_loggingInfo_FirehoseIsNull)
            {
                requestLoggingInfo_loggingInfo_Firehose = null;
            }
            if (requestLoggingInfo_loggingInfo_Firehose != null)
            {
                request.LoggingInfo.Firehose = requestLoggingInfo_loggingInfo_Firehose;
                requestLoggingInfoIsNull = false;
            }
            Amazon.Kafka.Model.S3 requestLoggingInfo_loggingInfo_S3 = null;
            
             // populate S3
            var requestLoggingInfo_loggingInfo_S3IsNull = true;
            requestLoggingInfo_loggingInfo_S3 = new Amazon.Kafka.Model.S3();
            System.String requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Bucket = null;
            if (cmdletContext.LoggingInfo_S3_Bucket != null)
            {
                requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Bucket = cmdletContext.LoggingInfo_S3_Bucket;
            }
            if (requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Bucket != null)
            {
                requestLoggingInfo_loggingInfo_S3.Bucket = requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Bucket;
                requestLoggingInfo_loggingInfo_S3IsNull = false;
            }
            System.Boolean? requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Enabled = null;
            if (cmdletContext.LoggingInfo_S3_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Enabled = cmdletContext.LoggingInfo_S3_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_S3.Enabled = requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Enabled.Value;
                requestLoggingInfo_loggingInfo_S3IsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Prefix = null;
            if (cmdletContext.LoggingInfo_S3_Prefix != null)
            {
                requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Prefix = cmdletContext.LoggingInfo_S3_Prefix;
            }
            if (requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Prefix != null)
            {
                requestLoggingInfo_loggingInfo_S3.Prefix = requestLoggingInfo_loggingInfo_S3_loggingInfo_S3_Prefix;
                requestLoggingInfo_loggingInfo_S3IsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_S3 should be set to null
            if (requestLoggingInfo_loggingInfo_S3IsNull)
            {
                requestLoggingInfo_loggingInfo_S3 = null;
            }
            if (requestLoggingInfo_loggingInfo_S3 != null)
            {
                request.LoggingInfo.S3 = requestLoggingInfo_loggingInfo_S3;
                requestLoggingInfoIsNull = false;
            }
             // determine if request.LoggingInfo should be set to null
            if (requestLoggingInfoIsNull)
            {
                request.LoggingInfo = null;
            }
            
             // populate S3DestinationConfiguration
            var requestS3DestinationConfigurationIsNull = true;
            request.S3DestinationConfiguration = new Amazon.Kafka.Model.S3DestinationConfiguration();
            System.Int32? requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond = null;
            if (cmdletContext.S3DestinationConfiguration_DataFreshnessInSecond != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond = cmdletContext.S3DestinationConfiguration_DataFreshnessInSecond.Value;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond != null)
            {
                request.S3DestinationConfiguration.DataFreshnessInSeconds = requestS3DestinationConfiguration_s3DestinationConfiguration_DataFreshnessInSecond.Value;
                requestS3DestinationConfigurationIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_ServiceExecutionRoleArn = null;
            if (cmdletContext.S3DestinationConfiguration_ServiceExecutionRoleArn != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_ServiceExecutionRoleArn = cmdletContext.S3DestinationConfiguration_ServiceExecutionRoleArn;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_ServiceExecutionRoleArn != null)
            {
                request.S3DestinationConfiguration.ServiceExecutionRoleArn = requestS3DestinationConfiguration_s3DestinationConfiguration_ServiceExecutionRoleArn;
                requestS3DestinationConfigurationIsNull = false;
            }
            Amazon.Kafka.Model.DeadLetterQueueS3 requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3 = null;
            
             // populate DeadLetterQueueS3
            var requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3IsNull = true;
            requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3 = new Amazon.Kafka.Model.DeadLetterQueueS3();
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_BucketArn = null;
            if (cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3_BucketArn != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_BucketArn = cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3_BucketArn;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_BucketArn != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3.BucketArn = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_BucketArn;
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3IsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix = null;
            if (cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix = cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3.ErrorOutputPrefix = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix;
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3IsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner = null;
            if (cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner = cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3.ExpectedBucketOwner = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3_s3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner;
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3IsNull = false;
            }
             // determine if requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3 should be set to null
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3IsNull)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3 = null;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3 != null)
            {
                request.S3DestinationConfiguration.DeadLetterQueueS3 = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3;
                requestS3DestinationConfigurationIsNull = false;
            }
            Amazon.Kafka.Model.S3Storage requestS3DestinationConfiguration_s3DestinationConfiguration_Storage = null;
            
             // populate Storage
            var requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull = true;
            requestS3DestinationConfiguration_s3DestinationConfiguration_Storage = new Amazon.Kafka.Model.S3Storage();
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_BucketArn = null;
            if (cmdletContext.S3DestinationConfiguration_Storage_BucketArn != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_BucketArn = cmdletContext.S3DestinationConfiguration_Storage_BucketArn;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_BucketArn != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage.BucketArn = requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_BucketArn;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull = false;
            }
            Amazon.Kafka.S3CompressionType requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_CompressionType = null;
            if (cmdletContext.S3DestinationConfiguration_Storage_CompressionType != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_CompressionType = cmdletContext.S3DestinationConfiguration_Storage_CompressionType;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_CompressionType != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage.CompressionType = requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_CompressionType;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_ExpectedBucketOwner = null;
            if (cmdletContext.S3DestinationConfiguration_Storage_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_ExpectedBucketOwner = cmdletContext.S3DestinationConfiguration_Storage_ExpectedBucketOwner;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage.ExpectedBucketOwner = requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_ExpectedBucketOwner;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputKeyTemplate = null;
            if (cmdletContext.S3DestinationConfiguration_Storage_OutputKeyTemplate != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputKeyTemplate = cmdletContext.S3DestinationConfiguration_Storage_OutputKeyTemplate;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputKeyTemplate != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage.OutputKeyTemplate = requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputKeyTemplate;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputPrefix = null;
            if (cmdletContext.S3DestinationConfiguration_Storage_OutputPrefix != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputPrefix = cmdletContext.S3DestinationConfiguration_Storage_OutputPrefix;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputPrefix != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage.OutputPrefix = requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_OutputPrefix;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull = false;
            }
            Amazon.Kafka.S3StorageClass requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_StorageClass = null;
            if (cmdletContext.S3DestinationConfiguration_Storage_StorageClass != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_StorageClass = cmdletContext.S3DestinationConfiguration_Storage_StorageClass;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_StorageClass != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage.StorageClass = requestS3DestinationConfiguration_s3DestinationConfiguration_Storage_s3DestinationConfiguration_Storage_StorageClass;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull = false;
            }
             // determine if requestS3DestinationConfiguration_s3DestinationConfiguration_Storage should be set to null
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageIsNull)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_Storage = null;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_Storage != null)
            {
                request.S3DestinationConfiguration.Storage = requestS3DestinationConfiguration_s3DestinationConfiguration_Storage;
                requestS3DestinationConfigurationIsNull = false;
            }
             // determine if request.S3DestinationConfiguration should be set to null
            if (requestS3DestinationConfigurationIsNull)
            {
                request.S3DestinationConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TopicConfigurationList != null)
            {
                request.TopicConfigurationList = cmdletContext.TopicConfigurationList;
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
        
        private Amazon.Kafka.Model.CreateChannelResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.CreateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "CreateChannel");
            try
            {
                return client.CreateChannelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelName { get; set; }
            public System.String ClusterArn { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public System.Boolean? IcebergDestinationConfiguration_AppendOnly { get; set; }
            public System.String IcebergDestinationConfiguration_Catalog_CatalogArn { get; set; }
            public System.String IcebergDestinationConfiguration_Catalog_WarehouseLocation { get; set; }
            public Amazon.Kafka.IcebergCompressionType IcebergDestinationConfiguration_CompressionType { get; set; }
            public System.Int32? IcebergDestinationConfiguration_DataFreshnessInSecond { get; set; }
            public System.String IcebergDestinationConfiguration_DeadLetterQueueS3_BucketArn { get; set; }
            public System.String IcebergDestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix { get; set; }
            public System.String IcebergDestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner { get; set; }
            public List<Amazon.Kafka.Model.DestinationTable> IcebergDestinationConfiguration_DestinationTableList { get; set; }
            public System.Boolean? IcebergDestinationConfiguration_SchemaEvolution_EnableSchemaEvolution { get; set; }
            public System.String IcebergDestinationConfiguration_ServiceExecutionRoleArn { get; set; }
            public System.Boolean? IcebergDestinationConfiguration_TableCreation_EnableTableCreation { get; set; }
            public System.Boolean? LoggingInfo_CloudWatchLogs_Enabled { get; set; }
            public System.String LoggingInfo_CloudWatchLogs_LogGroup { get; set; }
            public System.String LoggingInfo_Firehose_DeliveryStream { get; set; }
            public System.Boolean? LoggingInfo_Firehose_Enabled { get; set; }
            public System.String LoggingInfo_S3_Bucket { get; set; }
            public System.Boolean? LoggingInfo_S3_Enabled { get; set; }
            public System.String LoggingInfo_S3_Prefix { get; set; }
            public System.Int32? S3DestinationConfiguration_DataFreshnessInSecond { get; set; }
            public System.String S3DestinationConfiguration_DeadLetterQueueS3_BucketArn { get; set; }
            public System.String S3DestinationConfiguration_DeadLetterQueueS3_ErrorOutputPrefix { get; set; }
            public System.String S3DestinationConfiguration_DeadLetterQueueS3_ExpectedBucketOwner { get; set; }
            public System.String S3DestinationConfiguration_ServiceExecutionRoleArn { get; set; }
            public System.String S3DestinationConfiguration_Storage_BucketArn { get; set; }
            public Amazon.Kafka.S3CompressionType S3DestinationConfiguration_Storage_CompressionType { get; set; }
            public System.String S3DestinationConfiguration_Storage_ExpectedBucketOwner { get; set; }
            public System.String S3DestinationConfiguration_Storage_OutputKeyTemplate { get; set; }
            public System.String S3DestinationConfiguration_Storage_OutputPrefix { get; set; }
            public Amazon.Kafka.S3StorageClass S3DestinationConfiguration_Storage_StorageClass { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.Kafka.Model.TopicConfiguration> TopicConfigurationList { get; set; }
            public System.Func<Amazon.Kafka.Model.CreateChannelResponse, NewMSKChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
