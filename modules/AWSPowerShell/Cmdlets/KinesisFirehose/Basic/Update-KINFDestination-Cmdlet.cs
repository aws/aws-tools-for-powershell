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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Updates the specified destination of the specified delivery stream.
    /// 
    ///  
    /// <para>
    /// Use this operation to change the destination type (for example, to replace the Amazon
    /// S3 destination with Amazon Redshift) or change the parameters associated with a destination
    /// (for example, to change the bucket name of the Amazon S3 destination). The update
    /// might not occur immediately. The target delivery stream remains active while the configurations
    /// are updated, so data writes to the delivery stream can continue during this process.
    /// The updated configurations are usually effective within a few minutes.
    /// </para><para>
    /// Switching between Amazon ES and other services is not supported. For an Amazon ES
    /// destination, you can only update to another Amazon ES destination.
    /// </para><para>
    /// If the destination type is the same, Kinesis Data Firehose merges the configuration
    /// parameters specified with the destination configuration that already exists on the
    /// delivery stream. If any of the parameters are not specified in the call, the existing
    /// values are retained. For example, in the Amazon S3 destination, if <a>EncryptionConfiguration</a>
    /// is not specified, then the existing <code>EncryptionConfiguration</code> is maintained
    /// on the destination.
    /// </para><para>
    /// If the destination type is not the same, for example, changing the destination from
    /// Amazon S3 to Amazon Redshift, Kinesis Data Firehose does not merge any parameters.
    /// In this case, all parameters must be specified.
    /// </para><para>
    /// Kinesis Data Firehose uses <code>CurrentDeliveryStreamVersionId</code> to avoid race
    /// conditions and conflicting merges. This is a required field, and the service updates
    /// the configuration only if the existing configuration has a version ID that matches.
    /// After the update is applied successfully, the version ID is updated, and can be retrieved
    /// using <a>DescribeDeliveryStream</a>. Use the new version ID to set <code>CurrentDeliveryStreamVersionId</code>
    /// in the next call.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINFDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose UpdateDestination API operation.", Operation = new[] {"UpdateDestination"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.UpdateDestinationResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisFirehose.Model.UpdateDestinationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisFirehose.Model.UpdateDestinationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKINFDestinationCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter ElasticsearchDestinationUpdate_ClusterEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to use when communicating with the cluster. Specify either this <code>ClusterEndpoint</code>
        /// or the <code>DomainARN</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationUpdate_ClusterEndpoint { get; set; }
        #endregion
        
        #region Parameter CurrentDeliveryStreamVersionId
        /// <summary>
        /// <para>
        /// <para>Obtain this value from the <code>VersionId</code> result of <a>DeliveryStreamDescription</a>.
        /// This value is required, and helps the service perform conditional operations. For
        /// example, if there is an interleaving update and this value is null, then the update
        /// destination fails. After the update is successful, the <code>VersionId</code> value
        /// is updated. The service then performs a merge of the old configuration with the new
        /// configuration.</para>
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
        public System.String CurrentDeliveryStreamVersionId { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
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
        public System.String DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter DestinationId
        /// <summary>
        /// <para>
        /// <para>The ID of the destination.</para>
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
        public System.String DestinationId { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationUpdate_DomainARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon ES domain. The IAM role must have permissions for <code>DescribeElasticsearchDomain</code>,
        /// <code>DescribeElasticsearchDomains</code>, and <code>DescribeElasticsearchDomainConfig</code> after
        /// assuming the IAM role specified in <code>RoleARN</code>. For more information, see
        /// <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para><para>Specify either <code>ClusterEndpoint</code> or <code>DomainARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationUpdate_DomainARN { get; set; }
        #endregion
        
        #region Parameter RetryOptions_DurationInSecond
        /// <summary>
        /// <para>
        /// <para>After an initial failure to deliver to Amazon ES, the total amount of time during
        /// which Kinesis Data Firehose retries delivery (including the first attempt). After
        /// this time has elapsed, the failed documents are written to Amazon S3. Default value
        /// is 300 seconds (5 minutes). A value of 0 (zero) results in no retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_RetryOptions_DurationInSeconds")]
        public System.Int32? RetryOptions_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_CloudWatchLoggingOptions_Enabled")]
        public System.Boolean? CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_ProcessingConfiguration_Enabled")]
        public System.Boolean? ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter ExtendedS3DestinationUpdate
        /// <summary>
        /// <para>
        /// <para>Describes an update for a destination in Amazon S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.ExtendedS3DestinationUpdate ExtendedS3DestinationUpdate { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationUpdate_IndexName
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch index name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationUpdate_IndexName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationUpdate_IndexRotationPeriod
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch index rotation period. Index rotation appends a timestamp to <code>IndexName</code>
        /// to facilitate the expiration of old data. For more information, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-index-rotation">Index
        /// Rotation for the Amazon ES Destination</a>. Default value is <code>OneDay</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod")]
        public Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod ElasticsearchDestinationUpdate_IndexRotationPeriod { get; set; }
        #endregion
        
        #region Parameter BufferingHints_IntervalInSecond
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 300 (5 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_BufferingHints_IntervalInSeconds")]
        public System.Int32? BufferingHints_IntervalInSecond { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_CloudWatchLoggingOptions_LogGroupName")]
        public System.String CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_CloudWatchLoggingOptions_LogStreamName")]
        public System.String CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter ProcessingConfiguration_Processor
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_ProcessingConfiguration_Processors")]
        public Amazon.KinesisFirehose.Model.Processor[] ProcessingConfiguration_Processor { get; set; }
        #endregion
        
        #region Parameter RedshiftDestinationUpdate
        /// <summary>
        /// <para>
        /// <para>Describes an update for a destination in Amazon Redshift.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.RedshiftDestinationUpdate RedshiftDestinationUpdate { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationUpdate_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Kinesis Data Firehose
        /// for calling the Amazon ES Configuration API and for indexing documents. For more information,
        /// see <a href="https://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Grant
        /// Kinesis Data Firehose Access to an Amazon S3 Destination</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationUpdate_RoleARN { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationUpdate_S3Update
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.S3DestinationUpdate ElasticsearchDestinationUpdate_S3Update { get; set; }
        #endregion
        
        #region Parameter BufferingHints_SizeInMBs
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data to the specified size, in MBs, before delivering it to the destination.
        /// The default value is 5.</para><para>We recommend setting this parameter to a value greater than the amount of data you
        /// typically ingest into the delivery stream in 10 seconds. For example, if you typically
        /// ingest data at 1 MB/sec, the value should be 10 MB or higher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationUpdate_BufferingHints_SizeInMBs")]
        public System.Int32? BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter SplunkDestinationUpdate
        /// <summary>
        /// <para>
        /// <para>Describes an update for a destination in Splunk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.SplunkDestinationUpdate SplunkDestinationUpdate { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationUpdate_TypeName
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch type name. For Elasticsearch 6.x, there can be only one type per
        /// index. If you try to specify a new type for an existing index that already has another
        /// type, Kinesis Data Firehose returns an error during runtime.</para><para>If you upgrade Elasticsearch from 6.x to 7.x and don’t update your delivery stream,
        /// Kinesis Data Firehose still delivers data to Elasticsearch with the old index name
        /// and type name. If you want to update your delivery stream with a new index name, provide
        /// an empty string for <code>TypeName</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationUpdate_TypeName { get; set; }
        #endregion
        
        #region Parameter S3DestinationUpdate
        /// <summary>
        /// <para>
        /// <para>[Deprecated] Describes an update for a destination in Amazon S3.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated. Use ExtendedS3DestinationUpdate instead.")]
        public Amazon.KinesisFirehose.Model.S3DestinationUpdate S3DestinationUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.UpdateDestinationResponse).
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeliveryStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINFDestination (UpdateDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.UpdateDestinationResponse, UpdateKINFDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CurrentDeliveryStreamVersionId = this.CurrentDeliveryStreamVersionId;
            #if MODULAR
            if (this.CurrentDeliveryStreamVersionId == null && ParameterWasBound(nameof(this.CurrentDeliveryStreamVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentDeliveryStreamVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryStreamName = this.DeliveryStreamName;
            #if MODULAR
            if (this.DeliveryStreamName == null && ParameterWasBound(nameof(this.DeliveryStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationId = this.DestinationId;
            #if MODULAR
            if (this.DestinationId == null && ParameterWasBound(nameof(this.DestinationId)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BufferingHints_IntervalInSecond = this.BufferingHints_IntervalInSecond;
            context.BufferingHints_SizeInMBs = this.BufferingHints_SizeInMBs;
            context.CloudWatchLoggingOptions_Enabled = this.CloudWatchLoggingOptions_Enabled;
            context.CloudWatchLoggingOptions_LogGroupName = this.CloudWatchLoggingOptions_LogGroupName;
            context.CloudWatchLoggingOptions_LogStreamName = this.CloudWatchLoggingOptions_LogStreamName;
            context.ElasticsearchDestinationUpdate_ClusterEndpoint = this.ElasticsearchDestinationUpdate_ClusterEndpoint;
            context.ElasticsearchDestinationUpdate_DomainARN = this.ElasticsearchDestinationUpdate_DomainARN;
            context.ElasticsearchDestinationUpdate_IndexName = this.ElasticsearchDestinationUpdate_IndexName;
            context.ElasticsearchDestinationUpdate_IndexRotationPeriod = this.ElasticsearchDestinationUpdate_IndexRotationPeriod;
            context.ProcessingConfiguration_Enabled = this.ProcessingConfiguration_Enabled;
            if (this.ProcessingConfiguration_Processor != null)
            {
                context.ProcessingConfiguration_Processor = new List<Amazon.KinesisFirehose.Model.Processor>(this.ProcessingConfiguration_Processor);
            }
            context.RetryOptions_DurationInSecond = this.RetryOptions_DurationInSecond;
            context.ElasticsearchDestinationUpdate_RoleARN = this.ElasticsearchDestinationUpdate_RoleARN;
            context.ElasticsearchDestinationUpdate_S3Update = this.ElasticsearchDestinationUpdate_S3Update;
            context.ElasticsearchDestinationUpdate_TypeName = this.ElasticsearchDestinationUpdate_TypeName;
            context.ExtendedS3DestinationUpdate = this.ExtendedS3DestinationUpdate;
            context.RedshiftDestinationUpdate = this.RedshiftDestinationUpdate;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3DestinationUpdate = this.S3DestinationUpdate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SplunkDestinationUpdate = this.SplunkDestinationUpdate;
            
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
            var request = new Amazon.KinesisFirehose.Model.UpdateDestinationRequest();
            
            if (cmdletContext.CurrentDeliveryStreamVersionId != null)
            {
                request.CurrentDeliveryStreamVersionId = cmdletContext.CurrentDeliveryStreamVersionId;
            }
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
            }
            if (cmdletContext.DestinationId != null)
            {
                request.DestinationId = cmdletContext.DestinationId;
            }
            
             // populate ElasticsearchDestinationUpdate
            var requestElasticsearchDestinationUpdateIsNull = true;
            request.ElasticsearchDestinationUpdate = new Amazon.KinesisFirehose.Model.ElasticsearchDestinationUpdate();
            System.String requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ClusterEndpoint = null;
            if (cmdletContext.ElasticsearchDestinationUpdate_ClusterEndpoint != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ClusterEndpoint = cmdletContext.ElasticsearchDestinationUpdate_ClusterEndpoint;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ClusterEndpoint != null)
            {
                request.ElasticsearchDestinationUpdate.ClusterEndpoint = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ClusterEndpoint;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            System.String requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_DomainARN = null;
            if (cmdletContext.ElasticsearchDestinationUpdate_DomainARN != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_DomainARN = cmdletContext.ElasticsearchDestinationUpdate_DomainARN;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_DomainARN != null)
            {
                request.ElasticsearchDestinationUpdate.DomainARN = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_DomainARN;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            System.String requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexName = null;
            if (cmdletContext.ElasticsearchDestinationUpdate_IndexName != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexName = cmdletContext.ElasticsearchDestinationUpdate_IndexName;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexName != null)
            {
                request.ElasticsearchDestinationUpdate.IndexName = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexName;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexRotationPeriod = null;
            if (cmdletContext.ElasticsearchDestinationUpdate_IndexRotationPeriod != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexRotationPeriod = cmdletContext.ElasticsearchDestinationUpdate_IndexRotationPeriod;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexRotationPeriod != null)
            {
                request.ElasticsearchDestinationUpdate.IndexRotationPeriod = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_IndexRotationPeriod;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            System.String requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RoleARN = null;
            if (cmdletContext.ElasticsearchDestinationUpdate_RoleARN != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RoleARN = cmdletContext.ElasticsearchDestinationUpdate_RoleARN;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RoleARN != null)
            {
                request.ElasticsearchDestinationUpdate.RoleARN = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RoleARN;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            Amazon.KinesisFirehose.Model.S3DestinationUpdate requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_S3Update = null;
            if (cmdletContext.ElasticsearchDestinationUpdate_S3Update != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_S3Update = cmdletContext.ElasticsearchDestinationUpdate_S3Update;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_S3Update != null)
            {
                request.ElasticsearchDestinationUpdate.S3Update = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_S3Update;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            System.String requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_TypeName = null;
            if (cmdletContext.ElasticsearchDestinationUpdate_TypeName != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_TypeName = cmdletContext.ElasticsearchDestinationUpdate_TypeName;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_TypeName != null)
            {
                request.ElasticsearchDestinationUpdate.TypeName = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_TypeName;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ElasticsearchRetryOptions requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions = null;
            
             // populate RetryOptions
            var requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptionsIsNull = true;
            requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions = new Amazon.KinesisFirehose.Model.ElasticsearchRetryOptions();
            System.Int32? requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions_retryOptions_DurationInSecond = null;
            if (cmdletContext.RetryOptions_DurationInSecond != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions_retryOptions_DurationInSecond = cmdletContext.RetryOptions_DurationInSecond.Value;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions_retryOptions_DurationInSecond != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions.DurationInSeconds = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions_retryOptions_DurationInSecond.Value;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptionsIsNull = false;
            }
             // determine if requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions should be set to null
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptionsIsNull)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions = null;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions != null)
            {
                request.ElasticsearchDestinationUpdate.RetryOptions = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_RetryOptions;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ElasticsearchBufferingHints requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints = null;
            
             // populate BufferingHints
            var requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHintsIsNull = true;
            requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints = new Amazon.KinesisFirehose.Model.ElasticsearchBufferingHints();
            System.Int32? requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_IntervalInSecond = null;
            if (cmdletContext.BufferingHints_IntervalInSecond != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_IntervalInSecond = cmdletContext.BufferingHints_IntervalInSecond.Value;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_IntervalInSecond != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints.IntervalInSeconds = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_IntervalInSecond.Value;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHintsIsNull = false;
            }
            System.Int32? requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_SizeInMBs = null;
            if (cmdletContext.BufferingHints_SizeInMBs != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_SizeInMBs = cmdletContext.BufferingHints_SizeInMBs.Value;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_SizeInMBs != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints.SizeInMBs = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints_bufferingHints_SizeInMBs.Value;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHintsIsNull = false;
            }
             // determine if requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints should be set to null
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHintsIsNull)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints = null;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints != null)
            {
                request.ElasticsearchDestinationUpdate.BufferingHints = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_BufferingHints;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ProcessingConfiguration requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration = null;
            
             // populate ProcessingConfiguration
            var requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfigurationIsNull = true;
            requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Enabled = null;
            if (cmdletContext.ProcessingConfiguration_Enabled != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Enabled = cmdletContext.ProcessingConfiguration_Enabled.Value;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Enabled != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration.Enabled = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Enabled.Value;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Processor = null;
            if (cmdletContext.ProcessingConfiguration_Processor != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Processor = cmdletContext.ProcessingConfiguration_Processor;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Processor != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration.Processors = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration_processingConfiguration_Processor;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfigurationIsNull = false;
            }
             // determine if requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration should be set to null
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfigurationIsNull)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration = null;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration != null)
            {
                request.ElasticsearchDestinationUpdate.ProcessingConfiguration = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_ProcessingConfiguration;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions = null;
            
             // populate CloudWatchLoggingOptions
            var requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptionsIsNull = true;
            requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.CloudWatchLoggingOptions_Enabled != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled = cmdletContext.CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions.Enabled = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled.Value;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName = cmdletContext.CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions.LogGroupName = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName = cmdletContext.CloudWatchLoggingOptions_LogStreamName;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName != null)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions.LogStreamName = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName;
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptionsIsNull = false;
            }
             // determine if requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions should be set to null
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptionsIsNull)
            {
                requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions = null;
            }
            if (requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions != null)
            {
                request.ElasticsearchDestinationUpdate.CloudWatchLoggingOptions = requestElasticsearchDestinationUpdate_elasticsearchDestinationUpdate_CloudWatchLoggingOptions;
                requestElasticsearchDestinationUpdateIsNull = false;
            }
             // determine if request.ElasticsearchDestinationUpdate should be set to null
            if (requestElasticsearchDestinationUpdateIsNull)
            {
                request.ElasticsearchDestinationUpdate = null;
            }
            if (cmdletContext.ExtendedS3DestinationUpdate != null)
            {
                request.ExtendedS3DestinationUpdate = cmdletContext.ExtendedS3DestinationUpdate;
            }
            if (cmdletContext.RedshiftDestinationUpdate != null)
            {
                request.RedshiftDestinationUpdate = cmdletContext.RedshiftDestinationUpdate;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.S3DestinationUpdate != null)
            {
                request.S3DestinationUpdate = cmdletContext.S3DestinationUpdate;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.SplunkDestinationUpdate != null)
            {
                request.SplunkDestinationUpdate = cmdletContext.SplunkDestinationUpdate;
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
        
        private Amazon.KinesisFirehose.Model.UpdateDestinationResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.UpdateDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "UpdateDestination");
            try
            {
                #if DESKTOP
                return client.UpdateDestination(request);
                #elif CORECLR
                return client.UpdateDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String CurrentDeliveryStreamVersionId { get; set; }
            public System.String DeliveryStreamName { get; set; }
            public System.String DestinationId { get; set; }
            public System.Int32? BufferingHints_IntervalInSecond { get; set; }
            public System.Int32? BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String ElasticsearchDestinationUpdate_ClusterEndpoint { get; set; }
            public System.String ElasticsearchDestinationUpdate_DomainARN { get; set; }
            public System.String ElasticsearchDestinationUpdate_IndexName { get; set; }
            public Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod ElasticsearchDestinationUpdate_IndexRotationPeriod { get; set; }
            public System.Boolean? ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> ProcessingConfiguration_Processor { get; set; }
            public System.Int32? RetryOptions_DurationInSecond { get; set; }
            public System.String ElasticsearchDestinationUpdate_RoleARN { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationUpdate ElasticsearchDestinationUpdate_S3Update { get; set; }
            public System.String ElasticsearchDestinationUpdate_TypeName { get; set; }
            public Amazon.KinesisFirehose.Model.ExtendedS3DestinationUpdate ExtendedS3DestinationUpdate { get; set; }
            public Amazon.KinesisFirehose.Model.RedshiftDestinationUpdate RedshiftDestinationUpdate { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.KinesisFirehose.Model.S3DestinationUpdate S3DestinationUpdate { get; set; }
            public Amazon.KinesisFirehose.Model.SplunkDestinationUpdate SplunkDestinationUpdate { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.UpdateDestinationResponse, UpdateKINFDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
