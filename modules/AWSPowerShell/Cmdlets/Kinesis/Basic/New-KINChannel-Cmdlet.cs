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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Creates a channel that delivers records from a Kinesis data stream to a destination.
    /// A channel reads records from the specified stream and writes them to streaming tables
    /// on Apache Iceberg (Amazon S3 Tables) or to a general purpose Amazon S3 bucket.
    /// 
    ///  
    /// <para>
    /// You must specify either <c>S3DestinationConfiguration</c> or <c>S3TablesDestinationConfiguration</c>,
    /// but not both.
    /// </para><para>
    /// Creating a channel is an asynchronous operation. Upon receiving the request, Amazon
    /// Kinesis Data Streams returns immediately with the channel in the <c>CREATING</c> state.
    /// After provisioning is complete, Amazon Kinesis Data Streams sets the state to <c>ACTIVE</c>.
    /// You can use <a>DescribeChannel</a> to check the current state.
    /// </para><para>
    /// This operation is only supported for data streams with the on-demand capacity mode.
    /// </para><para>
    /// This API has a call limit of 5 transactions per second (TPS) for each Amazon Web Services
    /// account. Exceeding 5 TPS results in a <c>LimitExceededException</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kinesis.Model.ChannelDescription")]
    [AWSCmdlet("Calls the Amazon Kinesis CreateChannel API operation.", Operation = new[] {"CreateChannel"}, SelectReturnType = typeof(Amazon.Kinesis.Model.CreateChannelResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.ChannelDescription or Amazon.Kinesis.Model.CreateChannelResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.ChannelDescription object.",
        "The service call response (type Amazon.Kinesis.Model.CreateChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKINChannelCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dead-letter queue Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_StorageConfiguration_BucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the destination Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_StorageConfiguration_BucketARN { get; set; }
        #endregion
        
        #region Parameter S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dead-letter queue Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the channel. The name is unique within your Amazon Web Services account
        /// and Amazon Web Services Region.</para>
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
        
        #region Parameter S3DestinationConfiguration_StorageConfiguration_CompressionType
        /// <summary>
        /// <para>
        /// <para>The compression applied to delivered objects. Valid values:</para><ul><li><para><c>NONE</c> - No compression.</para></li><li><para><c>GZIP</c> - gzip compression.</para></li><li><para><c>ZSTD</c> - Zstandard compression.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kinesis.S3CompressionType")]
        public Amazon.Kinesis.S3CompressionType S3DestinationConfiguration_StorageConfiguration_CompressionType { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DataFreshnessInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum age, in seconds, of undelivered data. Valid range is 300 to 900 seconds
        /// (5 to 15 minutes). The default value is 300 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3DestinationConfiguration_DataFreshnessInSeconds")]
        public System.Int32? S3DestinationConfiguration_DataFreshnessInSecond { get; set; }
        #endregion
        
        #region Parameter S3TablesDestinationConfiguration_DataFreshnessInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum age, in seconds, of undelivered data. Valid range is 300 to 900 seconds
        /// (5 to 15 minutes). The default value is 300 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3TablesDestinationConfiguration_DataFreshnessInSeconds")]
        public System.Int32? S3TablesDestinationConfiguration_DataFreshnessInSecond { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether logging to Amazon CloudWatch Logs is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoggingConfiguration_CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_EncryptionType
        /// <summary>
        /// <para>
        /// <para>The encryption type. The only valid value is <c>KMS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kinesis.ChannelEncryptionType")]
        public Amazon.Kinesis.ChannelEncryptionType EncryptionConfiguration_EncryptionType { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key prefix for error records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix { get; set; }
        #endregion
        
        #region Parameter S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key prefix for error records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the expected owner of the dead-letter queue
        /// bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the expected owner of the destination bucket.
        /// This value helps prevent delivery to an unintended bucket if ownership changes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the expected owner of the dead-letter queue
        /// bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the customer managed Amazon Web Services KMS key. You cannot use
        /// the Amazon Kinesis Data Streams service key (<c>aws/kinesis</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_CloudWatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch Logs log group. Defaults to <c>/aws/kinesis/{channelName}/{channelId}</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_CloudWatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_CloudWatchLogs_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch Logs log stream. Defaults to <c>DestinationDelivery</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_CloudWatchLogs_LogStreamName { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate
        /// <summary>
        /// <para>
        /// <para>The template used to construct the Amazon S3 object key for delivered objects. If
        /// not specified, a default template is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate { get; set; }
        #endregion
        
        #region Parameter S3TablesDestinationConfiguration_S3TablesConfigurationList
        /// <summary>
        /// <para>
        /// <para>The list of streaming table configurations. Currently, one table is supported per
        /// channel.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Kinesis.Model.S3TablesConfiguration[] S3TablesDestinationConfiguration_S3TablesConfigurationList { get; set; }
        #endregion
        
        #region Parameter ServiceExecutionRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon Kinesis Data Streams assumes
        /// to write records to the destination.</para>
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
        public System.String ServiceExecutionRoleARN { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration_StorageConfiguration_StorageClass
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 storage class for delivered objects. Valid values:</para><ul><li><para><c>STANDARD</c> (default)</para></li><li><para><c>INTELLIGENT_TIERING</c></para></li><li><para><c>GLACIER_IR</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kinesis.S3StorageClass")]
        public Amazon.Kinesis.S3StorageClass S3DestinationConfiguration_StorageConfiguration_StorageClass { get; set; }
        #endregion
        
        #region Parameter StreamConfigurationList
        /// <summary>
        /// <para>
        /// <para>The source stream configuration for the channel. Currently, one stream is supported
        /// per channel.</para><para />
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
        public Amazon.Kinesis.Model.ChannelStreamConfiguration[] StreamConfigurationList { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs to assign to the channel. A tag consists of a required key
        /// and an optional value.</para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.CreateChannelResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.CreateChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelDescription";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINChannel (CreateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.CreateChannelResponse, NewKINChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfiguration_EncryptionType = this.EncryptionConfiguration_EncryptionType;
            context.EncryptionConfiguration_KeyId = this.EncryptionConfiguration_KeyId;
            context.LoggingConfiguration_CloudWatchLogs_Enabled = this.LoggingConfiguration_CloudWatchLogs_Enabled;
            context.LoggingConfiguration_CloudWatchLogs_LogGroupName = this.LoggingConfiguration_CloudWatchLogs_LogGroupName;
            context.LoggingConfiguration_CloudWatchLogs_LogStreamName = this.LoggingConfiguration_CloudWatchLogs_LogStreamName;
            context.S3DestinationConfiguration_DataFreshnessInSecond = this.S3DestinationConfiguration_DataFreshnessInSecond;
            context.S3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN = this.S3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN;
            context.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix = this.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix;
            context.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner = this.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner;
            context.S3DestinationConfiguration_StorageConfiguration_BucketARN = this.S3DestinationConfiguration_StorageConfiguration_BucketARN;
            context.S3DestinationConfiguration_StorageConfiguration_CompressionType = this.S3DestinationConfiguration_StorageConfiguration_CompressionType;
            context.S3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner = this.S3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner;
            context.S3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate = this.S3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate;
            context.S3DestinationConfiguration_StorageConfiguration_StorageClass = this.S3DestinationConfiguration_StorageConfiguration_StorageClass;
            context.S3TablesDestinationConfiguration_DataFreshnessInSecond = this.S3TablesDestinationConfiguration_DataFreshnessInSecond;
            context.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN = this.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN;
            context.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix = this.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix;
            context.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner = this.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner;
            if (this.S3TablesDestinationConfiguration_S3TablesConfigurationList != null)
            {
                context.S3TablesDestinationConfiguration_S3TablesConfigurationList = new List<Amazon.Kinesis.Model.S3TablesConfiguration>(this.S3TablesDestinationConfiguration_S3TablesConfigurationList);
            }
            context.ServiceExecutionRoleARN = this.ServiceExecutionRoleARN;
            #if MODULAR
            if (this.ServiceExecutionRoleARN == null && ParameterWasBound(nameof(this.ServiceExecutionRoleARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceExecutionRoleARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StreamConfigurationList != null)
            {
                context.StreamConfigurationList = new List<Amazon.Kinesis.Model.ChannelStreamConfiguration>(this.StreamConfigurationList);
            }
            #if MODULAR
            if (this.StreamConfigurationList == null && ParameterWasBound(nameof(this.StreamConfigurationList)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamConfigurationList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kinesis.Model.CreateChannelRequest();
            
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.Kinesis.Model.ChannelEncryptionConfiguration();
            Amazon.Kinesis.ChannelEncryptionType requestEncryptionConfiguration_encryptionConfiguration_EncryptionType = null;
            if (cmdletContext.EncryptionConfiguration_EncryptionType != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_EncryptionType = cmdletContext.EncryptionConfiguration_EncryptionType;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_EncryptionType != null)
            {
                request.EncryptionConfiguration.EncryptionType = requestEncryptionConfiguration_encryptionConfiguration_EncryptionType;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KeyId = null;
            if (cmdletContext.EncryptionConfiguration_KeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KeyId = cmdletContext.EncryptionConfiguration_KeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KeyId != null)
            {
                request.EncryptionConfiguration.KeyId = requestEncryptionConfiguration_encryptionConfiguration_KeyId;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.Kinesis.Model.ChannelLoggingConfiguration();
            Amazon.Kinesis.Model.CloudWatchLogs requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs = new Amazon.Kinesis.Model.CloudWatchLogs();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled = null;
            if (cmdletContext.LoggingConfiguration_CloudWatchLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled = cmdletContext.LoggingConfiguration_CloudWatchLogs_Enabled.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs.Enabled = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_Enabled.Value;
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName = null;
            if (cmdletContext.LoggingConfiguration_CloudWatchLogs_LogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName = cmdletContext.LoggingConfiguration_CloudWatchLogs_LogGroupName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs.LogGroupName = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogGroupName;
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName = null;
            if (cmdletContext.LoggingConfiguration_CloudWatchLogs_LogStreamName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName = cmdletContext.LoggingConfiguration_CloudWatchLogs_LogStreamName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs.LogStreamName = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs_loggingConfiguration_CloudWatchLogs_LogStreamName;
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogsIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs != null)
            {
                request.LoggingConfiguration.CloudWatchLogs = requestLoggingConfiguration_loggingConfiguration_CloudWatchLogs;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            
             // populate S3DestinationConfiguration
            var requestS3DestinationConfigurationIsNull = true;
            request.S3DestinationConfiguration = new Amazon.Kinesis.Model.S3DestinationConfiguration();
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
            Amazon.Kinesis.Model.DeadLetterQueueS3Configuration requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration = null;
            
             // populate DeadLetterQueueS3Configuration
            var requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = true;
            requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration = new Amazon.Kinesis.Model.DeadLetterQueueS3Configuration();
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN = null;
            if (cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN = cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration.BucketARN = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN;
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix = null;
            if (cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix = cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration.ErrorOutputPrefix = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix;
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner = null;
            if (cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner = cmdletContext.S3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration.ExpectedBucketOwner = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_s3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner;
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = false;
            }
             // determine if requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration should be set to null
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration = null;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration != null)
            {
                request.S3DestinationConfiguration.DeadLetterQueueS3Configuration = requestS3DestinationConfiguration_s3DestinationConfiguration_DeadLetterQueueS3Configuration;
                requestS3DestinationConfigurationIsNull = false;
            }
            Amazon.Kinesis.Model.S3StorageConfiguration requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration = null;
            
             // populate StorageConfiguration
            var requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfigurationIsNull = true;
            requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration = new Amazon.Kinesis.Model.S3StorageConfiguration();
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_BucketARN = null;
            if (cmdletContext.S3DestinationConfiguration_StorageConfiguration_BucketARN != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_BucketARN = cmdletContext.S3DestinationConfiguration_StorageConfiguration_BucketARN;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_BucketARN != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration.BucketARN = requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_BucketARN;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfigurationIsNull = false;
            }
            Amazon.Kinesis.S3CompressionType requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_CompressionType = null;
            if (cmdletContext.S3DestinationConfiguration_StorageConfiguration_CompressionType != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_CompressionType = cmdletContext.S3DestinationConfiguration_StorageConfiguration_CompressionType;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_CompressionType != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration.CompressionType = requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_CompressionType;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfigurationIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner = null;
            if (cmdletContext.S3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner = cmdletContext.S3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration.ExpectedBucketOwner = requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfigurationIsNull = false;
            }
            System.String requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate = null;
            if (cmdletContext.S3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate = cmdletContext.S3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration.OutputKeyTemplate = requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfigurationIsNull = false;
            }
            Amazon.Kinesis.S3StorageClass requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_StorageClass = null;
            if (cmdletContext.S3DestinationConfiguration_StorageConfiguration_StorageClass != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_StorageClass = cmdletContext.S3DestinationConfiguration_StorageConfiguration_StorageClass;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_StorageClass != null)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration.StorageClass = requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration_s3DestinationConfiguration_StorageConfiguration_StorageClass;
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfigurationIsNull = false;
            }
             // determine if requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration should be set to null
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfigurationIsNull)
            {
                requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration = null;
            }
            if (requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration != null)
            {
                request.S3DestinationConfiguration.StorageConfiguration = requestS3DestinationConfiguration_s3DestinationConfiguration_StorageConfiguration;
                requestS3DestinationConfigurationIsNull = false;
            }
             // determine if request.S3DestinationConfiguration should be set to null
            if (requestS3DestinationConfigurationIsNull)
            {
                request.S3DestinationConfiguration = null;
            }
            
             // populate S3TablesDestinationConfiguration
            var requestS3TablesDestinationConfigurationIsNull = true;
            request.S3TablesDestinationConfiguration = new Amazon.Kinesis.Model.S3TablesDestinationConfiguration();
            System.Int32? requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond = null;
            if (cmdletContext.S3TablesDestinationConfiguration_DataFreshnessInSecond != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond = cmdletContext.S3TablesDestinationConfiguration_DataFreshnessInSecond.Value;
            }
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond != null)
            {
                request.S3TablesDestinationConfiguration.DataFreshnessInSeconds = requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DataFreshnessInSecond.Value;
                requestS3TablesDestinationConfigurationIsNull = false;
            }
            List<Amazon.Kinesis.Model.S3TablesConfiguration> requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_S3TablesConfigurationList = null;
            if (cmdletContext.S3TablesDestinationConfiguration_S3TablesConfigurationList != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_S3TablesConfigurationList = cmdletContext.S3TablesDestinationConfiguration_S3TablesConfigurationList;
            }
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_S3TablesConfigurationList != null)
            {
                request.S3TablesDestinationConfiguration.S3TablesConfigurationList = requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_S3TablesConfigurationList;
                requestS3TablesDestinationConfigurationIsNull = false;
            }
            Amazon.Kinesis.Model.DeadLetterQueueS3Configuration requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration = null;
            
             // populate DeadLetterQueueS3Configuration
            var requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = true;
            requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration = new Amazon.Kinesis.Model.DeadLetterQueueS3Configuration();
            System.String requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN = null;
            if (cmdletContext.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN = cmdletContext.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN;
            }
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration.BucketARN = requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN;
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = false;
            }
            System.String requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix = null;
            if (cmdletContext.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix = cmdletContext.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix;
            }
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration.ErrorOutputPrefix = requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix;
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = false;
            }
            System.String requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner = null;
            if (cmdletContext.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner = cmdletContext.S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner;
            }
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner != null)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration.ExpectedBucketOwner = requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner;
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull = false;
            }
             // determine if requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration should be set to null
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3ConfigurationIsNull)
            {
                requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration = null;
            }
            if (requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration != null)
            {
                request.S3TablesDestinationConfiguration.DeadLetterQueueS3Configuration = requestS3TablesDestinationConfiguration_s3TablesDestinationConfiguration_DeadLetterQueueS3Configuration;
                requestS3TablesDestinationConfigurationIsNull = false;
            }
             // determine if request.S3TablesDestinationConfiguration should be set to null
            if (requestS3TablesDestinationConfigurationIsNull)
            {
                request.S3TablesDestinationConfiguration = null;
            }
            if (cmdletContext.ServiceExecutionRoleARN != null)
            {
                request.ServiceExecutionRoleARN = cmdletContext.ServiceExecutionRoleARN;
            }
            if (cmdletContext.StreamConfigurationList != null)
            {
                request.StreamConfigurationList = cmdletContext.StreamConfigurationList;
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
        
        private Amazon.Kinesis.Model.CreateChannelResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.CreateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "CreateChannel");
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
            public Amazon.Kinesis.ChannelEncryptionType EncryptionConfiguration_EncryptionType { get; set; }
            public System.String EncryptionConfiguration_KeyId { get; set; }
            public System.Boolean? LoggingConfiguration_CloudWatchLogs_Enabled { get; set; }
            public System.String LoggingConfiguration_CloudWatchLogs_LogGroupName { get; set; }
            public System.String LoggingConfiguration_CloudWatchLogs_LogStreamName { get; set; }
            public System.Int32? S3DestinationConfiguration_DataFreshnessInSecond { get; set; }
            public System.String S3DestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN { get; set; }
            public System.String S3DestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix { get; set; }
            public System.String S3DestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner { get; set; }
            public System.String S3DestinationConfiguration_StorageConfiguration_BucketARN { get; set; }
            public Amazon.Kinesis.S3CompressionType S3DestinationConfiguration_StorageConfiguration_CompressionType { get; set; }
            public System.String S3DestinationConfiguration_StorageConfiguration_ExpectedBucketOwner { get; set; }
            public System.String S3DestinationConfiguration_StorageConfiguration_OutputKeyTemplate { get; set; }
            public Amazon.Kinesis.S3StorageClass S3DestinationConfiguration_StorageConfiguration_StorageClass { get; set; }
            public System.Int32? S3TablesDestinationConfiguration_DataFreshnessInSecond { get; set; }
            public System.String S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_BucketARN { get; set; }
            public System.String S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ErrorOutputPrefix { get; set; }
            public System.String S3TablesDestinationConfiguration_DeadLetterQueueS3Configuration_ExpectedBucketOwner { get; set; }
            public List<Amazon.Kinesis.Model.S3TablesConfiguration> S3TablesDestinationConfiguration_S3TablesConfigurationList { get; set; }
            public System.String ServiceExecutionRoleARN { get; set; }
            public List<Amazon.Kinesis.Model.ChannelStreamConfiguration> StreamConfigurationList { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kinesis.Model.CreateChannelResponse, NewKINChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelDescription;
        }
        
    }
}
