/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a delivery stream.
    /// 
    ///  
    /// <para><a>CreateDeliveryStream</a> is an asynchronous operation that immediately returns.
    /// The initial status of the delivery stream is <code>CREATING</code>. After the delivery
    /// stream is created, its status is <code>ACTIVE</code> and it now accepts data. Attempts
    /// to send data to a delivery stream that is not in the <code>ACTIVE</code> state cause
    /// an exception. To check the state of a delivery stream, use <a>DescribeDeliveryStream</a>.
    /// </para><para>
    /// The name of a delivery stream identifies it. You can't have two delivery streams with
    /// the same name in the same region. Two delivery streams in different AWS accounts or
    /// different regions in the same AWS account can have the same name.
    /// </para><para>
    /// By default, you can create up to 20 delivery streams per region.
    /// </para><para>
    /// A delivery stream can only be configured with a single destination, Amazon S3, Amazon
    /// Elasticsearch Service, or Amazon Redshift. For correct <a>CreateDeliveryStream</a>
    /// request syntax, specify only one destination configuration parameter: either <b>S3DestinationConfiguration</b>,
    /// <b>ElasticsearchDestinationConfiguration</b>, or <b>RedshiftDestinationConfiguration</b>.
    /// 
    /// </para><para>
    /// As part of <b>S3DestinationConfiguration</b>, optional values <b>BufferingHints</b>,
    /// <b>EncryptionConfiguration</b>, and <b>CompressionFormat</b> can be provided. By default,
    /// if no <b>BufferingHints</b> value is provided, Firehose buffers data up to 5 MB or
    /// for 5 minutes, whichever condition is satisfied first. Note that <b>BufferingHints</b>
    /// is a hint, so there are some cases where the service cannot adhere to these conditions
    /// strictly; for example, record boundaries are such that the size is a little over or
    /// under the configured buffering size. By default, no encryption is performed. We strongly
    /// recommend that you enable encryption to ensure secure data storage in Amazon S3.
    /// </para><para>
    /// A few notes about <b>RedshiftDestinationConfiguration</b>:
    /// </para><ul><li><para>
    /// An Amazon Redshift destination requires an S3 bucket as intermediate location, as
    /// Firehose first delivers data to S3 and then uses <code>COPY</code> syntax to load
    /// data into an Amazon Redshift table. This is specified in the <b>RedshiftDestinationConfiguration.S3Configuration</b>
    /// parameter element.
    /// </para></li><li><para>
    /// The compression formats <code>SNAPPY</code> or <code>ZIP</code> cannot be specified
    /// in <b>RedshiftDestinationConfiguration.S3Configuration</b> because the Amazon Redshift
    /// <code>COPY</code> operation that reads from the S3 bucket doesn't support these compression
    /// formats.
    /// </para></li><li><para>
    /// We strongly recommend that the username and password provided is used exclusively
    /// for Firehose purposes, and that the permissions for the account are restricted for
    /// Amazon Redshift <code>INSERT</code> permissions.
    /// </para></li></ul><para>
    /// Firehose assumes the IAM role that is configured as part of destinations. The IAM
    /// role should allow the Firehose principal to assume the role, and the role should have
    /// permissions that allows the service to deliver the data. For more information, see
    /// <a href="http://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Amazon
    /// S3 Bucket Access</a> in the <i>Amazon Kinesis Firehose Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINFDeliveryStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateDeliveryStream operation against Amazon Kinesis Firehose.", Operation = new[] {"CreateDeliveryStream"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewKINFDeliveryStreamCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_DomainARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon ES domain. The IAM role must have permission for <code>DescribeElasticsearchDomain</code>,
        /// <code>DescribeElasticsearchDomains</code> , and <code>DescribeElasticsearchDomainConfig</code> after
        /// assuming <b>RoleARN</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchDestinationConfiguration_DomainARN { get; set; }
        #endregion
        
        #region Parameter RetryOptions_DurationInSecond
        /// <summary>
        /// <para>
        /// <para>After an initial failure to deliver to Amazon ES, the total amount of time during
        /// which Firehose re-attempts delivery (including the first attempt). After this time
        /// has elapsed, the failed documents are written to Amazon S3. Default value is 300 seconds
        /// (5 minutes). A value of 0 (zero) results in no retries.</para>
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
        /// <para>The Elasticsearch index rotation period. Index rotation appends a timestamp to the
        /// IndexName to facilitate expiration of old data. For more information, see <a href="http://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-index-rotation">Index
        /// Rotation for Amazon Elasticsearch Service Destination</a>. Default value is <code>OneDay</code>.</para>
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
        
        #region Parameter CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if Enabled is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName")]
        public System.String CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if Enabled is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName")]
        public System.String CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter RedshiftDestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Amazon Redshift. This value cannot be specified if Amazon S3 or
        /// Amazon Elasticsearch is the desired destination (see restrictions listed above).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisFirehose.Model.RedshiftDestinationConfiguration RedshiftDestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role to be assumed by Firehose for calling the Amazon ES Configuration
        /// API and for indexing documents. For more information, see <a href="http://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Amazon
        /// S3 Bucket Access</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Defines how documents should be delivered to Amazon S3. When set to FailedDocumentsOnly,
        /// Firehose writes any documents that could not be indexed to the configured Amazon S3
        /// destination, with elasticsearch-failed/ appended to the key prefix. When set to AllDocuments,
        /// Firehose delivers all incoming records to Amazon S3, and also writes failed documents
        /// with elasticsearch-failed/ appended to the prefix. For more information, see <a href="http://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-s3-backup">Amazon
        /// S3 Backup for Amazon Elasticsearch Service Destination</a>. Default value is FailedDocumentsOnly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ElasticsearchS3BackupMode")]
        public Amazon.KinesisFirehose.ElasticsearchS3BackupMode ElasticsearchDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration ElasticsearchDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Amazon S3. This value must be specified if <b>ElasticsearchDestinationConfiguration</b>
        /// or <b>RedshiftDestinationConfiguration</b> is specified (see restrictions listed above).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration S3DestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter BufferingHints_SizeInMBs
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data to the specified size, in MBs, before delivering it to the destination.
        /// The default value is 5.</para><para>We recommend setting <b>SizeInMBs</b> to a value greater than the amount of data you
        /// typically ingest into the delivery stream in 10 seconds. For example, if you typically
        /// ingest data at 1 MB/sec, set <b>SizeInMBs</b> to be 10 MB or higher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs")]
        public System.Int32 BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_TypeName
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch type name.</para>
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
            
            context.DeliveryStreamName = this.DeliveryStreamName;
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
            if (ParameterWasBound("RetryOptions_DurationInSecond"))
                context.ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds = this.RetryOptions_DurationInSecond;
            context.ElasticsearchDestinationConfiguration_RoleARN = this.ElasticsearchDestinationConfiguration_RoleARN;
            context.ElasticsearchDestinationConfiguration_S3BackupMode = this.ElasticsearchDestinationConfiguration_S3BackupMode;
            context.ElasticsearchDestinationConfiguration_S3Configuration = this.ElasticsearchDestinationConfiguration_S3Configuration;
            context.ElasticsearchDestinationConfiguration_TypeName = this.ElasticsearchDestinationConfiguration_TypeName;
            context.RedshiftDestinationConfiguration = this.RedshiftDestinationConfiguration;
            context.S3DestinationConfiguration = this.S3DestinationConfiguration;
            
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
            if (cmdletContext.RedshiftDestinationConfiguration != null)
            {
                request.RedshiftDestinationConfiguration = cmdletContext.RedshiftDestinationConfiguration;
            }
            if (cmdletContext.S3DestinationConfiguration != null)
            {
                request.S3DestinationConfiguration = cmdletContext.S3DestinationConfiguration;
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
        
        private static Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.CreateDeliveryStreamRequest request)
        {
            return client.CreateDeliveryStream(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DeliveryStreamName { get; set; }
            public System.Int32? ElasticsearchDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
            public System.Int32? ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String ElasticsearchDestinationConfiguration_DomainARN { get; set; }
            public System.String ElasticsearchDestinationConfiguration_IndexName { get; set; }
            public Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod ElasticsearchDestinationConfiguration_IndexRotationPeriod { get; set; }
            public System.Int32? ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
            public System.String ElasticsearchDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.ElasticsearchS3BackupMode ElasticsearchDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration ElasticsearchDestinationConfiguration_S3Configuration { get; set; }
            public System.String ElasticsearchDestinationConfiguration_TypeName { get; set; }
            public Amazon.KinesisFirehose.Model.RedshiftDestinationConfiguration RedshiftDestinationConfiguration { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration S3DestinationConfiguration { get; set; }
        }
        
    }
}
