/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a Kinesis Data Firehose delivery stream.
    /// 
    ///  
    /// <para>
    /// By default, you can create up to 50 delivery streams per AWS Region.
    /// </para><para>
    /// This is an asynchronous operation that immediately returns. The initial status of
    /// the delivery stream is <code>CREATING</code>. After the delivery stream is created,
    /// its status is <code>ACTIVE</code> and it now accepts data. Attempts to send data to
    /// a delivery stream that is not in the <code>ACTIVE</code> state cause an exception.
    /// To check the state of a delivery stream, use <a>DescribeDeliveryStream</a>.
    /// </para><para>
    /// A Kinesis Data Firehose delivery stream can be configured to receive records directly
    /// from providers using <a>PutRecord</a> or <a>PutRecordBatch</a>, or it can be configured
    /// to use an existing Kinesis stream as its source. To specify a Kinesis data stream
    /// as input, set the <code>DeliveryStreamType</code> parameter to <code>KinesisStreamAsSource</code>,
    /// and provide the Kinesis stream Amazon Resource Name (ARN) and role ARN in the <code>KinesisStreamSourceConfiguration</code>
    /// parameter.
    /// </para><para>
    /// A delivery stream is configured with a single destination: Amazon S3, Amazon ES, Amazon
    /// Redshift, or Splunk. You must specify only one of the following destination configuration
    /// parameters: <b>ExtendedS3DestinationConfiguration</b>, <b>S3DestinationConfiguration</b>,
    /// <b>ElasticsearchDestinationConfiguration</b>, <b>RedshiftDestinationConfiguration</b>,
    /// or <b>SplunkDestinationConfiguration</b>.
    /// </para><para>
    /// When you specify <b>S3DestinationConfiguration</b>, you can also provide the following
    /// optional values: <b>BufferingHints</b>, <b>EncryptionConfiguration</b>, and <b>CompressionFormat</b>.
    /// By default, if no <b>BufferingHints</b> value is provided, Kinesis Data Firehose buffers
    /// data up to 5 MB or for 5 minutes, whichever condition is satisfied first. <b>BufferingHints</b>
    /// is a hint, so there are some cases where the service cannot adhere to these conditions
    /// strictly. For example, record boundaries might be such that the size is a little over
    /// or under the configured buffering size. By default, no encryption is performed. We
    /// strongly recommend that you enable encryption to ensure secure data storage in Amazon
    /// S3.
    /// </para><para>
    /// A few notes about Amazon Redshift as a destination:
    /// </para><ul><li><para>
    /// An Amazon Redshift destination requires an S3 bucket as intermediate location. Kinesis
    /// Data Firehose first delivers data to Amazon S3 and then uses <code>COPY</code> syntax
    /// to load data into an Amazon Redshift table. This is specified in the <b>RedshiftDestinationConfiguration.S3Configuration</b>
    /// parameter.
    /// </para></li><li><para>
    /// The compression formats <code>SNAPPY</code> or <code>ZIP</code> cannot be specified
    /// in <code>RedshiftDestinationConfiguration.S3Configuration</code> because the Amazon
    /// Redshift <code>COPY</code> operation that reads from the S3 bucket doesn't support
    /// these compression formats.
    /// </para></li><li><para>
    /// We strongly recommend that you use the user name and password you provide exclusively
    /// with Kinesis Data Firehose, and that the permissions for the account are restricted
    /// for Amazon Redshift <code>INSERT</code> permissions.
    /// </para></li></ul><para>
    /// Kinesis Data Firehose assumes the IAM role that is configured as part of the destination.
    /// The role should allow the Kinesis Data Firehose principal to assume the role, and
    /// the role should have permissions that allow the service to deliver the data. For more
    /// information, see <a href="http://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Grant
    /// Kinesis Data Firehose Access to an Amazon S3 Destination</a> in the <i>Amazon Kinesis
    /// Data Firehose Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINFDeliveryStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose CreateDeliveryStream API operation.", Operation = new[] {"CreateDeliveryStream"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKINFDeliveryStreamCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream. This name must be unique per AWS account in the same
        /// AWS Region. If the delivery streams are in different accounts or different Regions,
        /// you can have multiple delivery streams with the same name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamType
        /// <summary>
        /// <para>
        /// <para>The delivery stream type. This parameter can be one of the following values:</para><ul><li><para><code>DirectPut</code>: Provider applications access the delivery stream directly.</para></li><li><para><code>KinesisStreamAsSource</code>: The delivery stream uses a Kinesis data stream
        /// as a source.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DeliveryStreamType")]
        public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_DomainARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon ES domain. The IAM role must have permissions for <code>DescribeElasticsearchDomain</code>,
        /// <code>DescribeElasticsearchDomains</code>, and <code>DescribeElasticsearchDomainConfig</code> after
        /// assuming the role specified in <b>RoleARN</b>. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchDestinationConfiguration_DomainARN { get; set; }
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
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds")]
        public System.Int32 RetryOptions_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_Enabled")]
        public System.Boolean CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_ProcessingConfiguration_Enabled")]
        public System.Boolean ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter ExtendedS3DestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Amazon S3. You can specify only one destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisFirehose.Model.ExtendedS3DestinationConfiguration ExtendedS3DestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_IndexName
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch index name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchDestinationConfiguration_IndexName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_IndexRotationPeriod
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch index rotation period. Index rotation appends a time stamp to the
        /// <code>IndexName</code> to facilitate the expiration of old data. For more information,
        /// see <a href="http://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-index-rotation">Index
        /// Rotation for the Amazon ES Destination</a>. The default value is <code>OneDay</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod")]
        public Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod ElasticsearchDestinationConfiguration_IndexRotationPeriod { get; set; }
        #endregion
        
        #region Parameter BufferingHints_IntervalInSecond
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 300 (5 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_BufferingHints_IntervalInSeconds")]
        public System.Int32 BufferingHints_IntervalInSecond { get; set; }
        #endregion
        
        #region Parameter KinesisStreamSourceConfiguration_KinesisStreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the source Kinesis data stream. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-kinesis-streams">Amazon
        /// Kinesis Data Streams ARN Format</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KinesisStreamSourceConfiguration_KinesisStreamARN { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName")]
        public System.String CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName")]
        public System.String CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter ProcessingConfiguration_Processor
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_ProcessingConfiguration_Processors")]
        public Amazon.KinesisFirehose.Model.Processor[] ProcessingConfiguration_Processor { get; set; }
        #endregion
        
        #region Parameter RedshiftDestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Amazon Redshift. You can specify only one destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisFirehose.Model.RedshiftDestinationConfiguration RedshiftDestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Kinesis Data Firehose
        /// for calling the Amazon ES Configuration API and for indexing documents. For more information,
        /// see <a href="http://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Grant
        /// Kinesis Data Firehose Access to an Amazon S3 Destination</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamSourceConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that provides access to the source Kinesis data stream. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-iam">AWS
        /// Identity and Access Management (IAM) ARN Format</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KinesisStreamSourceConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Defines how documents should be delivered to Amazon S3. When it is set to <code>FailedDocumentsOnly</code>,
        /// Kinesis Data Firehose writes any documents that could not be indexed to the configured
        /// Amazon S3 destination, with <code>elasticsearch-failed/</code> appended to the key
        /// prefix. When set to <code>AllDocuments</code>, Kinesis Data Firehose delivers all
        /// incoming records to Amazon S3, and also writes failed documents with <code>elasticsearch-failed/</code>
        /// appended to the prefix. For more information, see <a href="http://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-s3-backup">Amazon
        /// S3 Backup for the Amazon ES Destination</a>. Default value is <code>FailedDocumentsOnly</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ElasticsearchS3BackupMode")]
        public Amazon.KinesisFirehose.ElasticsearchS3BackupMode ElasticsearchDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// <para>The configuration for the backup Amazon S3 location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration ElasticsearchDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>[Deprecated] The destination in Amazon S3. You can specify only one destination.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This property is deprecated. Use ExtendedS3DestinationConfiguration instead.")]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration S3DestinationConfiguration { get; set; }
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
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs")]
        public System.Int32 BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter SplunkDestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Splunk. You can specify only one destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisFirehose.Model.SplunkDestinationConfiguration SplunkDestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags to assign to the delivery stream. A tag is a key-value pair that you
        /// can define and assign to AWS resources. Tags are metadata. For example, you can add
        /// friendly names and descriptions or other types of information that can help you distinguish
        /// the delivery stream. For more information about tags, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html">Using
        /// Cost Allocation Tags</a> in the AWS Billing and Cost Management User Guide.</para><para>You can specify up to 50 tags when creating a delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.KinesisFirehose.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_TypeName
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch type name. For Elasticsearch 6.x, there can be only one type per
        /// index. If you try to specify a new type for an existing index that already has another
        /// type, Kinesis Data Firehose returns an error during run time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchDestinationConfiguration_TypeName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeliveryStreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINFDeliveryStream (CreateDeliveryStream)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DeliveryStreamName = this.DeliveryStreamName;
            context.DeliveryStreamType = this.DeliveryStreamType;
            if (ParameterWasBound("BufferingHints_IntervalInSecond"))
                context.ElasticsearchDestinationConfiguration_BufferingHints_IntervalInSeconds = this.BufferingHints_IntervalInSecond;
            if (ParameterWasBound("BufferingHints_SizeInMBs"))
                context.ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs = this.BufferingHints_SizeInMBs;
            if (ParameterWasBound("CloudWatchLoggingOptions_Enabled"))
                context.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_Enabled = this.CloudWatchLoggingOptions_Enabled;
            context.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = this.CloudWatchLoggingOptions_LogGroupName;
            context.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = this.CloudWatchLoggingOptions_LogStreamName;
            context.ElasticsearchDestinationConfiguration_DomainARN = this.ElasticsearchDestinationConfiguration_DomainARN;
            context.ElasticsearchDestinationConfiguration_IndexName = this.ElasticsearchDestinationConfiguration_IndexName;
            context.ElasticsearchDestinationConfiguration_IndexRotationPeriod = this.ElasticsearchDestinationConfiguration_IndexRotationPeriod;
            if (ParameterWasBound("ProcessingConfiguration_Enabled"))
                context.ElasticsearchDestinationConfiguration_ProcessingConfiguration_Enabled = this.ProcessingConfiguration_Enabled;
            if (this.ProcessingConfiguration_Processor != null)
            {
                context.ElasticsearchDestinationConfiguration_ProcessingConfiguration_Processors = new List<Amazon.KinesisFirehose.Model.Processor>(this.ProcessingConfiguration_Processor);
            }
            if (ParameterWasBound("RetryOptions_DurationInSecond"))
                context.ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds = this.RetryOptions_DurationInSecond;
            context.ElasticsearchDestinationConfiguration_RoleARN = this.ElasticsearchDestinationConfiguration_RoleARN;
            context.ElasticsearchDestinationConfiguration_S3BackupMode = this.ElasticsearchDestinationConfiguration_S3BackupMode;
            context.ElasticsearchDestinationConfiguration_S3Configuration = this.ElasticsearchDestinationConfiguration_S3Configuration;
            context.ElasticsearchDestinationConfiguration_TypeName = this.ElasticsearchDestinationConfiguration_TypeName;
            context.ExtendedS3DestinationConfiguration = this.ExtendedS3DestinationConfiguration;
            context.KinesisStreamSourceConfiguration_KinesisStreamARN = this.KinesisStreamSourceConfiguration_KinesisStreamARN;
            context.KinesisStreamSourceConfiguration_RoleARN = this.KinesisStreamSourceConfiguration_RoleARN;
            context.RedshiftDestinationConfiguration = this.RedshiftDestinationConfiguration;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3DestinationConfiguration = this.S3DestinationConfiguration;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SplunkDestinationConfiguration = this.SplunkDestinationConfiguration;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.KinesisFirehose.Model.Tag>(this.Tag);
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
            var request = new Amazon.KinesisFirehose.Model.CreateDeliveryStreamRequest();
            
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
            }
            if (cmdletContext.DeliveryStreamType != null)
            {
                request.DeliveryStreamType = cmdletContext.DeliveryStreamType;
            }
            
             // populate ElasticsearchDestinationConfiguration
            bool requestElasticsearchDestinationConfigurationIsNull = true;
            request.ElasticsearchDestinationConfiguration = new Amazon.KinesisFirehose.Model.ElasticsearchDestinationConfiguration();
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DomainARN = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_DomainARN != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DomainARN = cmdletContext.ElasticsearchDestinationConfiguration_DomainARN;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DomainARN != null)
            {
                request.ElasticsearchDestinationConfiguration.DomainARN = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DomainARN;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexName = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_IndexName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexName = cmdletContext.ElasticsearchDestinationConfiguration_IndexName;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexName != null)
            {
                request.ElasticsearchDestinationConfiguration.IndexName = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexName;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexRotationPeriod = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_IndexRotationPeriod != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexRotationPeriod = cmdletContext.ElasticsearchDestinationConfiguration_IndexRotationPeriod;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexRotationPeriod != null)
            {
                request.ElasticsearchDestinationConfiguration.IndexRotationPeriod = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_IndexRotationPeriod;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RoleARN = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_RoleARN != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RoleARN = cmdletContext.ElasticsearchDestinationConfiguration_RoleARN;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RoleARN != null)
            {
                request.ElasticsearchDestinationConfiguration.RoleARN = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RoleARN;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.ElasticsearchS3BackupMode requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3BackupMode = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_S3BackupMode != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3BackupMode = cmdletContext.ElasticsearchDestinationConfiguration_S3BackupMode;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3BackupMode != null)
            {
                request.ElasticsearchDestinationConfiguration.S3BackupMode = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3BackupMode;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.S3DestinationConfiguration requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3Configuration = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_S3Configuration != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3Configuration = cmdletContext.ElasticsearchDestinationConfiguration_S3Configuration;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3Configuration != null)
            {
                request.ElasticsearchDestinationConfiguration.S3Configuration = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_S3Configuration;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_TypeName = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_TypeName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_TypeName = cmdletContext.ElasticsearchDestinationConfiguration_TypeName;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_TypeName != null)
            {
                request.ElasticsearchDestinationConfiguration.TypeName = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_TypeName;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ElasticsearchRetryOptions requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions = null;
            
             // populate RetryOptions
            bool requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptionsIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions = new Amazon.KinesisFirehose.Model.ElasticsearchRetryOptions();
            System.Int32? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions_retryOptions_DurationInSecond = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions_retryOptions_DurationInSecond = cmdletContext.ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions_retryOptions_DurationInSecond != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions.DurationInSeconds = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions_retryOptions_DurationInSecond.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptionsIsNull = false;
            }
             // determine if requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions should be set to null
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptionsIsNull)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions = null;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions != null)
            {
                request.ElasticsearchDestinationConfiguration.RetryOptions = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ElasticsearchBufferingHints requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints = null;
            
             // populate BufferingHints
            bool requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHintsIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints = new Amazon.KinesisFirehose.Model.ElasticsearchBufferingHints();
            System.Int32? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond = cmdletContext.ElasticsearchDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints.IntervalInSeconds = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHintsIsNull = false;
            }
            System.Int32? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_SizeInMBs = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_SizeInMBs = cmdletContext.ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_SizeInMBs != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints.SizeInMBs = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_SizeInMBs.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHintsIsNull = false;
            }
             // determine if requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints should be set to null
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHintsIsNull)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints = null;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints != null)
            {
                request.ElasticsearchDestinationConfiguration.BufferingHints = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ProcessingConfiguration requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration = null;
            
             // populate ProcessingConfiguration
            bool requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfigurationIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled = cmdletContext.ElasticsearchDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration.Enabled = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Processor = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Processor = cmdletContext.ElasticsearchDestinationConfiguration_ProcessingConfiguration_Processors;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Processor != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration.Processors = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Processor;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
             // determine if requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration should be set to null
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfigurationIsNull)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration = null;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration != null)
            {
                request.ElasticsearchDestinationConfiguration.ProcessingConfiguration = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions = null;
            
             // populate CloudWatchLoggingOptions
            bool requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled = cmdletContext.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions.Enabled = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName = cmdletContext.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions.LogGroupName = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName = cmdletContext.ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions.LogStreamName = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
             // determine if requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions should be set to null
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions = null;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions != null)
            {
                request.ElasticsearchDestinationConfiguration.CloudWatchLoggingOptions = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
             // determine if request.ElasticsearchDestinationConfiguration should be set to null
            if (requestElasticsearchDestinationConfigurationIsNull)
            {
                request.ElasticsearchDestinationConfiguration = null;
            }
            if (cmdletContext.ExtendedS3DestinationConfiguration != null)
            {
                request.ExtendedS3DestinationConfiguration = cmdletContext.ExtendedS3DestinationConfiguration;
            }
            
             // populate KinesisStreamSourceConfiguration
            bool requestKinesisStreamSourceConfigurationIsNull = true;
            request.KinesisStreamSourceConfiguration = new Amazon.KinesisFirehose.Model.KinesisStreamSourceConfiguration();
            System.String requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_KinesisStreamARN = null;
            if (cmdletContext.KinesisStreamSourceConfiguration_KinesisStreamARN != null)
            {
                requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_KinesisStreamARN = cmdletContext.KinesisStreamSourceConfiguration_KinesisStreamARN;
            }
            if (requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_KinesisStreamARN != null)
            {
                request.KinesisStreamSourceConfiguration.KinesisStreamARN = requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_KinesisStreamARN;
                requestKinesisStreamSourceConfigurationIsNull = false;
            }
            System.String requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_RoleARN = null;
            if (cmdletContext.KinesisStreamSourceConfiguration_RoleARN != null)
            {
                requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_RoleARN = cmdletContext.KinesisStreamSourceConfiguration_RoleARN;
            }
            if (requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_RoleARN != null)
            {
                request.KinesisStreamSourceConfiguration.RoleARN = requestKinesisStreamSourceConfiguration_kinesisStreamSourceConfiguration_RoleARN;
                requestKinesisStreamSourceConfigurationIsNull = false;
            }
             // determine if request.KinesisStreamSourceConfiguration should be set to null
            if (requestKinesisStreamSourceConfigurationIsNull)
            {
                request.KinesisStreamSourceConfiguration = null;
            }
            if (cmdletContext.RedshiftDestinationConfiguration != null)
            {
                request.RedshiftDestinationConfiguration = cmdletContext.RedshiftDestinationConfiguration;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.S3DestinationConfiguration != null)
            {
                request.S3DestinationConfiguration = cmdletContext.S3DestinationConfiguration;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.SplunkDestinationConfiguration != null)
            {
                request.SplunkDestinationConfiguration = cmdletContext.SplunkDestinationConfiguration;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeliveryStreamARN;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.CreateDeliveryStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "CreateDeliveryStream");
            try
            {
                #if DESKTOP
                return client.CreateDeliveryStream(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDeliveryStreamAsync(request);
                return task.Result;
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
            public System.String DeliveryStreamName { get; set; }
            public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
            public System.Int32? ElasticsearchDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
            public System.Int32? ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String ElasticsearchDestinationConfiguration_DomainARN { get; set; }
            public System.String ElasticsearchDestinationConfiguration_IndexName { get; set; }
            public Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod ElasticsearchDestinationConfiguration_IndexRotationPeriod { get; set; }
            public System.Boolean? ElasticsearchDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> ElasticsearchDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
            public System.Int32? ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
            public System.String ElasticsearchDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.ElasticsearchS3BackupMode ElasticsearchDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration ElasticsearchDestinationConfiguration_S3Configuration { get; set; }
            public System.String ElasticsearchDestinationConfiguration_TypeName { get; set; }
            public Amazon.KinesisFirehose.Model.ExtendedS3DestinationConfiguration ExtendedS3DestinationConfiguration { get; set; }
            public System.String KinesisStreamSourceConfiguration_KinesisStreamARN { get; set; }
            public System.String KinesisStreamSourceConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.Model.RedshiftDestinationConfiguration RedshiftDestinationConfiguration { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration S3DestinationConfiguration { get; set; }
            public Amazon.KinesisFirehose.Model.SplunkDestinationConfiguration SplunkDestinationConfiguration { get; set; }
            public List<Amazon.KinesisFirehose.Model.Tag> Tags { get; set; }
        }
        
    }
}
