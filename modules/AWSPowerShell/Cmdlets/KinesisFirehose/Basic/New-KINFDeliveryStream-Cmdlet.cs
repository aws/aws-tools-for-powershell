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
    /// Creates a Kinesis Data Firehose delivery stream.
    /// 
    ///  
    /// <para>
    /// By default, you can create up to 50 delivery streams per Amazon Web Services Region.
    /// </para><para>
    /// This is an asynchronous operation that immediately returns. The initial status of
    /// the delivery stream is <code>CREATING</code>. After the delivery stream is created,
    /// its status is <code>ACTIVE</code> and it now accepts data. If the delivery stream
    /// creation fails, the status transitions to <code>CREATING_FAILED</code>. Attempts to
    /// send data to a delivery stream that is not in the <code>ACTIVE</code> state cause
    /// an exception. To check the state of a delivery stream, use <a>DescribeDeliveryStream</a>.
    /// </para><para>
    /// If the status of a delivery stream is <code>CREATING_FAILED</code>, this status doesn't
    /// change, and you can't invoke <code>CreateDeliveryStream</code> again on it. However,
    /// you can invoke the <a>DeleteDeliveryStream</a> operation to delete it.
    /// </para><para>
    /// A Kinesis Data Firehose delivery stream can be configured to receive records directly
    /// from providers using <a>PutRecord</a> or <a>PutRecordBatch</a>, or it can be configured
    /// to use an existing Kinesis stream as its source. To specify a Kinesis data stream
    /// as input, set the <code>DeliveryStreamType</code> parameter to <code>KinesisStreamAsSource</code>,
    /// and provide the Kinesis stream Amazon Resource Name (ARN) and role ARN in the <code>KinesisStreamSourceConfiguration</code>
    /// parameter.
    /// </para><para>
    /// To create a delivery stream with server-side encryption (SSE) enabled, include <a>DeliveryStreamEncryptionConfigurationInput</a>
    /// in your request. This is optional. You can also invoke <a>StartDeliveryStreamEncryption</a>
    /// to turn on SSE for an existing delivery stream that doesn't have SSE enabled.
    /// </para><para>
    /// A delivery stream is configured with a single destination: Amazon S3, Amazon ES, Amazon
    /// Redshift, or Splunk. You must specify only one of the following destination configuration
    /// parameters: <code>ExtendedS3DestinationConfiguration</code>, <code>S3DestinationConfiguration</code>,
    /// <code>ElasticsearchDestinationConfiguration</code>, <code>RedshiftDestinationConfiguration</code>,
    /// or <code>SplunkDestinationConfiguration</code>.
    /// </para><para>
    /// When you specify <code>S3DestinationConfiguration</code>, you can also provide the
    /// following optional values: BufferingHints, <code>EncryptionConfiguration</code>, and
    /// <code>CompressionFormat</code>. By default, if no <code>BufferingHints</code> value
    /// is provided, Kinesis Data Firehose buffers data up to 5 MB or for 5 minutes, whichever
    /// condition is satisfied first. <code>BufferingHints</code> is a hint, so there are
    /// some cases where the service cannot adhere to these conditions strictly. For example,
    /// record boundaries might be such that the size is a little over or under the configured
    /// buffering size. By default, no encryption is performed. We strongly recommend that
    /// you enable encryption to ensure secure data storage in Amazon S3.
    /// </para><para>
    /// A few notes about Amazon Redshift as a destination:
    /// </para><ul><li><para>
    /// An Amazon Redshift destination requires an S3 bucket as intermediate location. Kinesis
    /// Data Firehose first delivers data to Amazon S3 and then uses <code>COPY</code> syntax
    /// to load data into an Amazon Redshift table. This is specified in the <code>RedshiftDestinationConfiguration.S3Configuration</code>
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
    /// information, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Grant
    /// Kinesis Data Firehose Access to an Amazon S3 Destination</a> in the <i>Amazon Kinesis
    /// Data Firehose Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINFDeliveryStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose CreateDeliveryStream API operation.", Operation = new[] {"CreateDeliveryStream"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKINFDeliveryStreamCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey
        /// <summary>
        /// <para>
        /// <para>The access key required for Kinesis Firehose to authenticate with the HTTP endpoint
        /// selected as the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to use when communicating with the cluster. Specify either this ClusterEndpoint
        /// or the DomainARN field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_ClusterEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to use when communicating with the cluster. Specify either this <code>ClusterEndpoint</code>
        /// or the <code>DomainARN</code> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationConfiguration_ClusterEndpoint { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to use when communicating with the collection in the Serverless offering
        /// for Amazon OpenSearch Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes
        /// <summary>
        /// <para>
        /// <para>Describes the metadata sent to the HTTP endpoint destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.HttpEndpointCommonAttribute[] HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding
        /// <summary>
        /// <para>
        /// <para>Kinesis Data Firehose uses the content encoding to compress the body of a request
        /// before sending the request to the destination. For more information, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Encoding">Content-Encoding</a>
        /// in MDN Web Docs, the official Mozilla documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ContentEncoding")]
        public Amazon.KinesisFirehose.ContentEncoding HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery stream. This name must be unique per Amazon Web Services
        /// account in the same Amazon Web Services Region. If the delivery streams are in different
        /// accounts or different Regions, you can have multiple delivery streams with the same
        /// name.</para>
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
        
        #region Parameter DeliveryStreamType
        /// <summary>
        /// <para>
        /// <para>The delivery stream type. This parameter can be one of the following values:</para><ul><li><para><code>DirectPut</code>: Provider applications access the delivery stream directly.</para></li><li><para><code>KinesisStreamAsSource</code>: The delivery stream uses a Kinesis data stream
        /// as a source.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DeliveryStreamType")]
        public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_DomainARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon OpenSearch Service domain. The IAM role must have permissions
        /// for DescribeElasticsearchDomain, DescribeElasticsearchDomains, and DescribeElasticsearchDomainConfig
        /// after assuming the role specified in RoleARN. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_DomainARN { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_DomainARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon ES domain. The IAM role must have permissions for <code>DescribeDomain</code>,
        /// <code>DescribeDomains</code>, and <code>DescribeDomainConfig</code> after assuming
        /// the role specified in <b>RoleARN</b>. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para><para>Specify either <code>ClusterEndpoint</code> or <code>DomainARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationConfiguration_DomainARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>After an initial failure to deliver to the Serverless offering for Amazon OpenSearch
        /// Service, the total amount of time during which Kinesis Data Firehose retries delivery
        /// (including the first attempt). After this time has elapsed, the failed documents are
        /// written to Amazon S3. Default value is 300 seconds (5 minutes). A value of 0 (zero)
        /// results in no retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>After an initial failure to deliver to Amazon OpenSearch Service, the total amount
        /// of time during which Kinesis Data Firehose retries delivery (including the first attempt).
        /// After this time has elapsed, the failed documents are written to Amazon S3. Default
        /// value is 300 seconds (5 minutes). A value of 0 (zero) results in no retries. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
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
        [Alias("ElasticsearchDestinationConfiguration_RetryOptions_DurationInSeconds")]
        public System.Int32? RetryOptions_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The total amount of time that Kinesis Data Firehose spends on retries. This duration
        /// starts after the initial attempt to send data to the custom destination via HTTPS
        /// endpoint fails. It doesn't include the periods during which Kinesis Data Firehose
        /// waits for acknowledgment from the specified destination after each attempt. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_Enabled")]
        public System.Boolean? CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_ProcessingConfiguration_Enabled")]
        public System.Boolean? ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter ExtendedS3DestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Amazon S3. You can specify only one destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.ExtendedS3DestinationConfiguration ExtendedS3DestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_IndexName
        /// <summary>
        /// <para>
        /// <para>The Serverless offering for Amazon OpenSearch Service index name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_IndexName { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_IndexName
        /// <summary>
        /// <para>
        /// <para>The ElasticsearAmazon OpenSearch Service index name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_IndexName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_IndexName
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch index name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationConfiguration_IndexName { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod
        /// <summary>
        /// <para>
        /// <para>The Amazon OpenSearch Service index rotation period. Index rotation appends a timestamp
        /// to the IndexName to facilitate the expiration of old data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.AmazonopensearchserviceIndexRotationPeriod")]
        public Amazon.KinesisFirehose.AmazonopensearchserviceIndexRotationPeriod AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_IndexRotationPeriod
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch index rotation period. Index rotation appends a timestamp to the
        /// <code>IndexName</code> to facilitate the expiration of old data. For more information,
        /// see <a href="https://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-index-rotation">Index
        /// Rotation for the Amazon ES Destination</a>. The default value is <code>OneDay</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod")]
        public Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod ElasticsearchDestinationConfiguration_IndexRotationPeriod { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 300 (5 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 300 (5 minutes). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
        #endregion
        
        #region Parameter BufferingHints_IntervalInSecond
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 300 (5 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_BufferingHints_IntervalInSeconds")]
        public System.Int32? BufferingHints_IntervalInSecond { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 300 (5 minutes). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamEncryptionConfigurationInput_KeyARN
        /// <summary>
        /// <para>
        /// <para>If you set <code>KeyType</code> to <code>CUSTOMER_MANAGED_CMK</code>, you must specify
        /// the Amazon Resource Name (ARN) of the CMK. If you set <code>KeyType</code> to <code>Amazon
        /// Web Services_OWNED_CMK</code>, Kinesis Data Firehose uses a service-account CMK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryStreamEncryptionConfigurationInput_KeyARN { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamEncryptionConfigurationInput_KeyType
        /// <summary>
        /// <para>
        /// <para>Indicates the type of customer master key (CMK) to use for encryption. The default
        /// setting is <code>Amazon Web Services_OWNED_CMK</code>. For more information about
        /// CMKs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#master_keys">Customer
        /// Master Keys (CMKs)</a>. When you invoke <a>CreateDeliveryStream</a> or <a>StartDeliveryStreamEncryption</a>
        /// with <code>KeyType</code> set to CUSTOMER_MANAGED_CMK, Kinesis Data Firehose invokes
        /// the Amazon KMS operation <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_CreateGrant.html">CreateGrant</a>
        /// to create a grant that allows the Kinesis Data Firehose service to use the customer
        /// managed CMK to perform encryption and decryption. Kinesis Data Firehose manages that
        /// grant. </para><para>When you invoke <a>StartDeliveryStreamEncryption</a> to change the CMK for a delivery
        /// stream that is encrypted with a customer managed CMK, Kinesis Data Firehose schedules
        /// the grant it had on the old CMK for retirement.</para><para>You can use a CMK of type CUSTOMER_MANAGED_CMK to encrypt up to 500 delivery streams.
        /// If a <a>CreateDeliveryStream</a> or <a>StartDeliveryStreamEncryption</a> operation
        /// exceeds this limit, Kinesis Data Firehose throws a <code>LimitExceededException</code>.
        /// </para><important><para>To encrypt your delivery stream, use symmetric CMKs. Kinesis Data Firehose doesn't
        /// support asymmetric CMKs. For information about symmetric and asymmetric CMKs, see
        /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symm-asymm-concepts.html">About
        /// Symmetric and Asymmetric CMKs</a> in the Amazon Web Services Key Management Service
        /// developer guide.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.KeyType")]
        public Amazon.KinesisFirehose.KeyType DeliveryStreamEncryptionConfigurationInput_KeyType { get; set; }
        #endregion
        
        #region Parameter KinesisStreamSourceConfiguration_KinesisStreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the source Kinesis data stream. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-kinesis-streams">Amazon
        /// Kinesis Data Streams ARN Format</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisStreamSourceConfiguration_KinesisStreamARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName")]
        public System.String CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName")]
        public System.String CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_Name
        /// <summary>
        /// <para>
        /// <para>The name of the HTTP endpoint selected as the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HttpEndpointDestinationConfiguration_EndpointConfiguration_Name")]
        public System.String EndpointConfiguration_Name { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.Processor[] AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.Processor[] AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
        #endregion
        
        #region Parameter ProcessingConfiguration_Processor
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_ProcessingConfiguration_Processors")]
        public Amazon.KinesisFirehose.Model.Processor[] ProcessingConfiguration_Processor { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.Processor[] HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
        #endregion
        
        #region Parameter RedshiftDestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Amazon Redshift. You can specify only one destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.RedshiftDestinationConfiguration RedshiftDestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Kinesis Data Firehose
        /// for calling the Serverless offering for Amazon OpenSearch Service Configuration API
        /// and for indexing documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that you want the delivery stream to use to create endpoints
        /// in the destination VPC. You can use your existing Kinesis Data Firehose delivery role
        /// or you can specify a new role. In either case, make sure that the role trusts the
        /// Kinesis Data Firehose service principal and that it grants the following permissions:</para><ul><li><para><code>ec2:DescribeVpcs</code></para></li><li><para><code>ec2:DescribeVpcAttribute</code></para></li><li><para><code>ec2:DescribeSubnets</code></para></li><li><para><code>ec2:DescribeSecurityGroups</code></para></li><li><para><code>ec2:DescribeNetworkInterfaces</code></para></li><li><para><code>ec2:CreateNetworkInterface</code></para></li><li><para><code>ec2:CreateNetworkInterfacePermission</code></para></li><li><para><code>ec2:DeleteNetworkInterface</code></para></li></ul><para>If you revoke these permissions after you create the delivery stream, Kinesis Data
        /// Firehose can't scale out by creating more ENIs when necessary. You might therefore
        /// see a degradation in performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Kinesis Data Firehose
        /// for calling the Amazon OpenSearch Service Configuration API and for indexing documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that you want the delivery stream to use to create endpoints
        /// in the destination VPC. You can use your existing Kinesis Data Firehose delivery role
        /// or you can specify a new role. In either case, make sure that the role trusts the
        /// Kinesis Data Firehose service principal and that it grants the following permissions:</para><ul><li><para><code>ec2:DescribeVpcs</code></para></li><li><para><code>ec2:DescribeVpcAttribute</code></para></li><li><para><code>ec2:DescribeSubnets</code></para></li><li><para><code>ec2:DescribeSecurityGroups</code></para></li><li><para><code>ec2:DescribeNetworkInterfaces</code></para></li><li><para><code>ec2:CreateNetworkInterface</code></para></li><li><para><code>ec2:CreateNetworkInterfacePermission</code></para></li><li><para><code>ec2:DeleteNetworkInterface</code></para></li></ul><para>If you revoke these permissions after you create the delivery stream, Kinesis Data
        /// Firehose can't scale out by creating more ENIs when necessary. You might therefore
        /// see a degradation in performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Kinesis Data Firehose
        /// for calling the Amazon ES Configuration API and for indexing documents. For more information,
        /// see <a href="https://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Grant
        /// Kinesis Data Firehose Access to an Amazon S3 Destination</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that you want the delivery stream to use to create endpoints
        /// in the destination VPC. You can use your existing Kinesis Data Firehose delivery role
        /// or you can specify a new role. In either case, make sure that the role trusts the
        /// Kinesis Data Firehose service principal and that it grants the following permissions:</para><ul><li><para><code>ec2:DescribeVpcs</code></para></li><li><para><code>ec2:DescribeVpcAttribute</code></para></li><li><para><code>ec2:DescribeSubnets</code></para></li><li><para><code>ec2:DescribeSecurityGroups</code></para></li><li><para><code>ec2:DescribeNetworkInterfaces</code></para></li><li><para><code>ec2:CreateNetworkInterface</code></para></li><li><para><code>ec2:CreateNetworkInterfacePermission</code></para></li><li><para><code>ec2:DeleteNetworkInterface</code></para></li></ul><para>If you revoke these permissions after you create the delivery stream, Kinesis Data
        /// Firehose can't scale out by creating more ENIs when necessary. You might therefore
        /// see a degradation in performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_VpcConfiguration_RoleARN")]
        public System.String VpcConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>Kinesis Data Firehose uses this IAM role for all the permissions that the delivery
        /// stream needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter KinesisStreamSourceConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the role that provides access to the source Kinesis data stream. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-iam">Amazon
        /// Web Services Identity and Access Management (IAM) ARN Format</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisStreamSourceConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Defines how documents should be delivered to Amazon S3. When it is set to FailedDocumentsOnly,
        /// Kinesis Data Firehose writes any documents that could not be indexed to the configured
        /// Amazon S3 destination, with AmazonOpenSearchService-failed/ appended to the key prefix.
        /// When set to AllDocuments, Kinesis Data Firehose delivers all incoming records to Amazon
        /// S3, and also writes failed documents with AmazonOpenSearchService-failed/ appended
        /// to the prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.AmazonOpenSearchServerlessS3BackupMode")]
        public Amazon.KinesisFirehose.AmazonOpenSearchServerlessS3BackupMode AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Defines how documents should be delivered to Amazon S3. When it is set to FailedDocumentsOnly,
        /// Kinesis Data Firehose writes any documents that could not be indexed to the configured
        /// Amazon S3 destination, with AmazonOpenSearchService-failed/ appended to the key prefix.
        /// When set to AllDocuments, Kinesis Data Firehose delivers all incoming records to Amazon
        /// S3, and also writes failed documents with AmazonOpenSearchService-failed/ appended
        /// to the prefix. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.AmazonopensearchserviceS3BackupMode")]
        public Amazon.KinesisFirehose.AmazonopensearchserviceS3BackupMode AmazonopensearchserviceDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Defines how documents should be delivered to Amazon S3. When it is set to <code>FailedDocumentsOnly</code>,
        /// Kinesis Data Firehose writes any documents that could not be indexed to the configured
        /// Amazon S3 destination, with <code>AmazonOpenSearchService-failed/</code> appended
        /// to the key prefix. When set to <code>AllDocuments</code>, Kinesis Data Firehose delivers
        /// all incoming records to Amazon S3, and also writes failed documents with <code>AmazonOpenSearchService-failed/</code>
        /// appended to the prefix. For more information, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-s3-backup">Amazon
        /// S3 Backup for the Amazon ES Destination</a>. Default value is <code>FailedDocumentsOnly</code>.</para><para>You can't change this backup mode after you create the delivery stream. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ElasticsearchS3BackupMode")]
        public Amazon.KinesisFirehose.ElasticsearchS3BackupMode ElasticsearchDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Describes the S3 bucket backup options for the data that Kinesis Data Firehose delivers
        /// to the HTTP endpoint destination. You can back up all documents (<code>AllData</code>)
        /// or only the documents that Kinesis Data Firehose could not deliver to the specified
        /// HTTP endpoint destination (<code>FailedDataOnly</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.HttpEndpointS3BackupMode")]
        public Amazon.KinesisFirehose.HttpEndpointS3BackupMode HttpEndpointDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration AmazonOpenSearchServerlessDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration AmazonopensearchserviceDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// <para>The configuration for the backup Amazon S3 location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration ElasticsearchDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration HttpEndpointDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups that you want Kinesis Data Firehose to use when it
        /// creates ENIs in the VPC of the Amazon ES destination. You can use the same security
        /// group that the Amazon ES domain uses or different ones. If you specify different security
        /// groups here, ensure that they allow outbound HTTPS traffic to the Amazon ES domain's
        /// security group. Also ensure that the Amazon ES domain's security group allows HTTPS
        /// traffic from the security groups specified here. If you use the same security group
        /// for both your delivery stream and the Amazon ES domain, make sure the security group
        /// inbound rule allows HTTPS traffic. For more information about security group rules,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html#SecurityGroupRules">Security
        /// group rules</a> in the Amazon VPC documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups that you want Kinesis Data Firehose to use when it
        /// creates ENIs in the VPC of the Amazon ES destination. You can use the same security
        /// group that the Amazon ES domain uses or different ones. If you specify different security
        /// groups here, ensure that they allow outbound HTTPS traffic to the Amazon ES domain's
        /// security group. Also ensure that the Amazon ES domain's security group allows HTTPS
        /// traffic from the security groups specified here. If you use the same security group
        /// for both your delivery stream and the Amazon ES domain, make sure the security group
        /// inbound rule allows HTTPS traffic. For more information about security group rules,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html#SecurityGroupRules">Security
        /// group rules</a> in the Amazon VPC documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups that you want Kinesis Data Firehose to use when it
        /// creates ENIs in the VPC of the Amazon ES destination. You can use the same security
        /// group that the Amazon ES domain uses or different ones. If you specify different security
        /// groups here, ensure that they allow outbound HTTPS traffic to the Amazon ES domain's
        /// security group. Also ensure that the Amazon ES domain's security group allows HTTPS
        /// traffic from the security groups specified here. If you use the same security group
        /// for both your delivery stream and the Amazon ES domain, make sure the security group
        /// inbound rule allows HTTPS traffic. For more information about security group rules,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html#SecurityGroupRules">Security
        /// group rules</a> in the Amazon VPC documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_VpcConfiguration_SecurityGroupIds")]
        public System.String[] VpcConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data to the specified size, in MBs, before delivering it to the destination.
        /// The default value is 5. </para><para>We recommend setting this parameter to a value greater than the amount of data you
        /// typically ingest into the delivery stream in 10 seconds. For example, if you typically
        /// ingest data at 1 MB/sec, the value should be 10 MB or higher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data to the specified size, in MBs, before delivering it to the destination.
        /// The default value is 5.</para><para>We recommend setting this parameter to a value greater than the amount of data you
        /// typically ingest into the delivery stream in 10 seconds. For example, if you typically
        /// ingest data at 1 MB/sec, the value should be 10 MB or higher. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
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
        [Alias("ElasticsearchDestinationConfiguration_BufferingHints_SizeInMBs")]
        public System.Int32? BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data to the specified size, in MBs, before delivering it to the destination.
        /// The default value is 5. </para><para>We recommend setting this parameter to a value greater than the amount of data you
        /// typically ingest into the delivery stream in 10 seconds. For example, if you typically
        /// ingest data at 1 MB/sec, the value should be 10 MB or higher. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter SplunkDestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>The destination in Splunk. You can specify only one destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.SplunkDestinationConfiguration SplunkDestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets that you want Kinesis Data Firehose to use to create ENIs in
        /// the VPC of the Amazon ES destination. Make sure that the routing tables and inbound
        /// and outbound rules allow traffic to flow from the subnets whose IDs are specified
        /// here to the subnets that have the destination Amazon ES endpoints. Kinesis Data Firehose
        /// creates at least one ENI in each of the subnets that are specified here. Do not delete
        /// or modify these ENIs.</para><para>The number of ENIs that Kinesis Data Firehose creates in the subnets specified here
        /// scales up and down automatically based on throughput. To enable Kinesis Data Firehose
        /// to scale up the number of ENIs to match throughput, ensure that you have sufficient
        /// quota. To help you calculate the quota you need, assume that Kinesis Data Firehose
        /// can create up to three ENIs for this delivery stream for each of the subnets specified
        /// here. For more information about ENI quota, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html#vpc-limits-enis">Network
        /// Interfaces </a> in the Amazon VPC Quotas topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets that you want Kinesis Data Firehose to use to create ENIs in
        /// the VPC of the Amazon ES destination. Make sure that the routing tables and inbound
        /// and outbound rules allow traffic to flow from the subnets whose IDs are specified
        /// here to the subnets that have the destination Amazon ES endpoints. Kinesis Data Firehose
        /// creates at least one ENI in each of the subnets that are specified here. Do not delete
        /// or modify these ENIs.</para><para>The number of ENIs that Kinesis Data Firehose creates in the subnets specified here
        /// scales up and down automatically based on throughput. To enable Kinesis Data Firehose
        /// to scale up the number of ENIs to match throughput, ensure that you have sufficient
        /// quota. To help you calculate the quota you need, assume that Kinesis Data Firehose
        /// can create up to three ENIs for this delivery stream for each of the subnets specified
        /// here. For more information about ENI quota, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html#vpc-limits-enis">Network
        /// Interfaces </a> in the Amazon VPC Quotas topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets that you want Kinesis Data Firehose to use to create ENIs in
        /// the VPC of the Amazon ES destination. Make sure that the routing tables and inbound
        /// and outbound rules allow traffic to flow from the subnets whose IDs are specified
        /// here to the subnets that have the destination Amazon ES endpoints. Kinesis Data Firehose
        /// creates at least one ENI in each of the subnets that are specified here. Do not delete
        /// or modify these ENIs.</para><para>The number of ENIs that Kinesis Data Firehose creates in the subnets specified here
        /// scales up and down automatically based on throughput. To enable Kinesis Data Firehose
        /// to scale up the number of ENIs to match throughput, ensure that you have sufficient
        /// quota. To help you calculate the quota you need, assume that Kinesis Data Firehose
        /// can create up to three ENIs for this delivery stream for each of the subnets specified
        /// here. For more information about ENI quota, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html#vpc-limits-enis">Network
        /// Interfaces </a> in the Amazon VPC Quotas topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags to assign to the delivery stream. A tag is a key-value pair that you
        /// can define and assign to Amazon Web Services resources. Tags are metadata. For example,
        /// you can add friendly names and descriptions or other types of information that can
        /// help you distinguish the delivery stream. For more information about tags, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html">Using
        /// Cost Allocation Tags</a> in the Amazon Web Services Billing and Cost Management User
        /// Guide.</para><para>You can specify up to 50 tags when creating a delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KinesisFirehose.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_TypeName
        /// <summary>
        /// <para>
        /// <para>The Amazon OpenSearch Service type name. For Elasticsearch 6.x, there can be only
        /// one type per index. If you try to specify a new type for an existing index that already
        /// has another type, Kinesis Data Firehose returns an error during run time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_TypeName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_TypeName
        /// <summary>
        /// <para>
        /// <para>The Elasticsearch type name. For Elasticsearch 6.x, there can be only one type per
        /// index. If you try to specify a new type for an existing index that already has another
        /// type, Kinesis Data Firehose returns an error during run time.</para><para>For Elasticsearch 7.x, don't specify a <code>TypeName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationConfiguration_TypeName { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_EndpointConfiguration_Url
        /// <summary>
        /// <para>
        /// <para>The URL of the HTTP endpoint selected as the destination.</para><important><para>If you choose an HTTP endpoint as your destination, review and follow the instructions
        /// in the <a href="https://docs.aws.amazon.com/firehose/latest/dev/httpdeliveryrequestresponse.html">Appendix
        /// - HTTP Endpoint Delivery Request and Response Specifications</a>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_EndpointConfiguration_Url { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfiguration
        /// <summary>
        /// <para>
        /// <para>[Deprecated] The destination in Amazon S3. You can specify only one destination.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated. Use ExtendedS3DestinationConfiguration instead.")]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration S3DestinationConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeliveryStreamARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse).
        /// Specifying the name of a property of type Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeliveryStreamARN";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KINFDeliveryStream (CreateDeliveryStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse, NewKINFDeliveryStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds = this.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds;
            context.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs = this.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs;
            context.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled = this.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled;
            context.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = this.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            context.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = this.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            context.AmazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint = this.AmazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint;
            context.AmazonOpenSearchServerlessDestinationConfiguration_IndexName = this.AmazonOpenSearchServerlessDestinationConfiguration_IndexName;
            context.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled = this.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled;
            if (this.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                context.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors = new List<Amazon.KinesisFirehose.Model.Processor>(this.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors);
            }
            context.AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds = this.AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds;
            context.AmazonOpenSearchServerlessDestinationConfiguration_RoleARN = this.AmazonOpenSearchServerlessDestinationConfiguration_RoleARN;
            context.AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode = this.AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode;
            context.AmazonOpenSearchServerlessDestinationConfiguration_S3Configuration = this.AmazonOpenSearchServerlessDestinationConfiguration_S3Configuration;
            context.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN = this.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN;
            if (this.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds != null)
            {
                context.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds = new List<System.String>(this.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds);
            }
            if (this.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds != null)
            {
                context.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds = new List<System.String>(this.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds);
            }
            context.AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds = this.AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds;
            context.AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs = this.AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs;
            context.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled = this.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled;
            context.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = this.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            context.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = this.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            context.AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint = this.AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint;
            context.AmazonopensearchserviceDestinationConfiguration_DomainARN = this.AmazonopensearchserviceDestinationConfiguration_DomainARN;
            context.AmazonopensearchserviceDestinationConfiguration_IndexName = this.AmazonopensearchserviceDestinationConfiguration_IndexName;
            context.AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod = this.AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod;
            context.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled = this.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled;
            if (this.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                context.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors = new List<Amazon.KinesisFirehose.Model.Processor>(this.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors);
            }
            context.AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds = this.AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds;
            context.AmazonopensearchserviceDestinationConfiguration_RoleARN = this.AmazonopensearchserviceDestinationConfiguration_RoleARN;
            context.AmazonopensearchserviceDestinationConfiguration_S3BackupMode = this.AmazonopensearchserviceDestinationConfiguration_S3BackupMode;
            context.AmazonopensearchserviceDestinationConfiguration_S3Configuration = this.AmazonopensearchserviceDestinationConfiguration_S3Configuration;
            context.AmazonopensearchserviceDestinationConfiguration_TypeName = this.AmazonopensearchserviceDestinationConfiguration_TypeName;
            context.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN = this.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN;
            if (this.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds != null)
            {
                context.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds = new List<System.String>(this.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds);
            }
            if (this.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds != null)
            {
                context.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds = new List<System.String>(this.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds);
            }
            context.DeliveryStreamEncryptionConfigurationInput_KeyARN = this.DeliveryStreamEncryptionConfigurationInput_KeyARN;
            context.DeliveryStreamEncryptionConfigurationInput_KeyType = this.DeliveryStreamEncryptionConfigurationInput_KeyType;
            context.DeliveryStreamName = this.DeliveryStreamName;
            #if MODULAR
            if (this.DeliveryStreamName == null && ParameterWasBound(nameof(this.DeliveryStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeliveryStreamType = this.DeliveryStreamType;
            context.BufferingHints_IntervalInSecond = this.BufferingHints_IntervalInSecond;
            context.BufferingHints_SizeInMBs = this.BufferingHints_SizeInMBs;
            context.CloudWatchLoggingOptions_Enabled = this.CloudWatchLoggingOptions_Enabled;
            context.CloudWatchLoggingOptions_LogGroupName = this.CloudWatchLoggingOptions_LogGroupName;
            context.CloudWatchLoggingOptions_LogStreamName = this.CloudWatchLoggingOptions_LogStreamName;
            context.ElasticsearchDestinationConfiguration_ClusterEndpoint = this.ElasticsearchDestinationConfiguration_ClusterEndpoint;
            context.ElasticsearchDestinationConfiguration_DomainARN = this.ElasticsearchDestinationConfiguration_DomainARN;
            context.ElasticsearchDestinationConfiguration_IndexName = this.ElasticsearchDestinationConfiguration_IndexName;
            context.ElasticsearchDestinationConfiguration_IndexRotationPeriod = this.ElasticsearchDestinationConfiguration_IndexRotationPeriod;
            context.ProcessingConfiguration_Enabled = this.ProcessingConfiguration_Enabled;
            if (this.ProcessingConfiguration_Processor != null)
            {
                context.ProcessingConfiguration_Processor = new List<Amazon.KinesisFirehose.Model.Processor>(this.ProcessingConfiguration_Processor);
            }
            context.RetryOptions_DurationInSecond = this.RetryOptions_DurationInSecond;
            context.ElasticsearchDestinationConfiguration_RoleARN = this.ElasticsearchDestinationConfiguration_RoleARN;
            context.ElasticsearchDestinationConfiguration_S3BackupMode = this.ElasticsearchDestinationConfiguration_S3BackupMode;
            context.ElasticsearchDestinationConfiguration_S3Configuration = this.ElasticsearchDestinationConfiguration_S3Configuration;
            context.ElasticsearchDestinationConfiguration_TypeName = this.ElasticsearchDestinationConfiguration_TypeName;
            context.VpcConfiguration_RoleARN = this.VpcConfiguration_RoleARN;
            if (this.VpcConfiguration_SecurityGroupId != null)
            {
                context.VpcConfiguration_SecurityGroupId = new List<System.String>(this.VpcConfiguration_SecurityGroupId);
            }
            if (this.VpcConfiguration_SubnetId != null)
            {
                context.VpcConfiguration_SubnetId = new List<System.String>(this.VpcConfiguration_SubnetId);
            }
            context.ExtendedS3DestinationConfiguration = this.ExtendedS3DestinationConfiguration;
            context.HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds = this.HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds;
            context.HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs = this.HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs;
            context.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled = this.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled;
            context.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = this.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            context.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = this.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            context.HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey = this.HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey;
            context.EndpointConfiguration_Name = this.EndpointConfiguration_Name;
            context.HttpEndpointDestinationConfiguration_EndpointConfiguration_Url = this.HttpEndpointDestinationConfiguration_EndpointConfiguration_Url;
            context.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled = this.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled;
            if (this.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                context.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors = new List<Amazon.KinesisFirehose.Model.Processor>(this.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors);
            }
            if (this.HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes != null)
            {
                context.HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes = new List<Amazon.KinesisFirehose.Model.HttpEndpointCommonAttribute>(this.HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes);
            }
            context.HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding = this.HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding;
            context.HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds = this.HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds;
            context.HttpEndpointDestinationConfiguration_RoleARN = this.HttpEndpointDestinationConfiguration_RoleARN;
            context.HttpEndpointDestinationConfiguration_S3BackupMode = this.HttpEndpointDestinationConfiguration_S3BackupMode;
            context.HttpEndpointDestinationConfiguration_S3Configuration = this.HttpEndpointDestinationConfiguration_S3Configuration;
            context.KinesisStreamSourceConfiguration_KinesisStreamARN = this.KinesisStreamSourceConfiguration_KinesisStreamARN;
            context.KinesisStreamSourceConfiguration_RoleARN = this.KinesisStreamSourceConfiguration_RoleARN;
            context.RedshiftDestinationConfiguration = this.RedshiftDestinationConfiguration;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3DestinationConfiguration = this.S3DestinationConfiguration;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SplunkDestinationConfiguration = this.SplunkDestinationConfiguration;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KinesisFirehose.Model.Tag>(this.Tag);
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
            
            
             // populate AmazonOpenSearchServerlessDestinationConfiguration
            var requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = true;
            request.AmazonOpenSearchServerlessDestinationConfiguration = new Amazon.KinesisFirehose.Model.AmazonOpenSearchServerlessDestinationConfiguration();
            System.String requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.CollectionEndpoint = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            System.String requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_IndexName = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_IndexName != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_IndexName = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_IndexName;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_IndexName != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.IndexName = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_IndexName;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            System.String requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RoleARN = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_RoleARN != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RoleARN = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_RoleARN;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RoleARN != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.RoleARN = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RoleARN;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.AmazonOpenSearchServerlessS3BackupMode requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3BackupMode = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3BackupMode = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3BackupMode != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.S3BackupMode = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3BackupMode;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.S3DestinationConfiguration requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3Configuration = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_S3Configuration != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3Configuration = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_S3Configuration;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3Configuration != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.S3Configuration = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_S3Configuration;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.AmazonOpenSearchServerlessRetryOptions requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions = null;
            
             // populate RetryOptions
            var requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptionsIsNull = true;
            requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions = new Amazon.KinesisFirehose.Model.AmazonOpenSearchServerlessRetryOptions();
            System.Int32? requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions.DurationInSeconds = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptionsIsNull = false;
            }
             // determine if requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions should be set to null
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptionsIsNull)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions = null;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.RetryOptions = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_RetryOptions;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.AmazonOpenSearchServerlessBufferingHints requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints = null;
            
             // populate BufferingHints
            var requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHintsIsNull = true;
            requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints = new Amazon.KinesisFirehose.Model.AmazonOpenSearchServerlessBufferingHints();
            System.Int32? requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints.IntervalInSeconds = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHintsIsNull = false;
            }
            System.Int32? requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs.Value;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints.SizeInMBs = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs.Value;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHintsIsNull = false;
            }
             // determine if requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints should be set to null
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHintsIsNull)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints = null;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.BufferingHints = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_BufferingHints;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ProcessingConfiguration requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration = null;
            
             // populate ProcessingConfiguration
            var requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfigurationIsNull = true;
            requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration.Enabled = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration.Processors = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
             // determine if requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration should be set to null
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfigurationIsNull)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration = null;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.ProcessingConfiguration = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions = null;
            
             // populate CloudWatchLoggingOptions
            var requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptionsIsNull = true;
            requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions.Enabled = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions.LogGroupName = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions.LogStreamName = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
             // determine if requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions should be set to null
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptionsIsNull)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions = null;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.CloudWatchLoggingOptions = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.VpcConfiguration requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfigurationIsNull = true;
            requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration = new Amazon.KinesisFirehose.Model.VpcConfiguration();
            System.String requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration.RoleARN = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration.SecurityGroupIds = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds = null;
            if (cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds = cmdletContext.AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds != null)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration.SubnetIds = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds;
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfigurationIsNull = false;
            }
             // determine if requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration should be set to null
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfigurationIsNull)
            {
                requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration = null;
            }
            if (requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration != null)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration.VpcConfiguration = requestAmazonOpenSearchServerlessDestinationConfiguration_amazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration;
                requestAmazonOpenSearchServerlessDestinationConfigurationIsNull = false;
            }
             // determine if request.AmazonOpenSearchServerlessDestinationConfiguration should be set to null
            if (requestAmazonOpenSearchServerlessDestinationConfigurationIsNull)
            {
                request.AmazonOpenSearchServerlessDestinationConfiguration = null;
            }
            
             // populate AmazonopensearchserviceDestinationConfiguration
            var requestAmazonopensearchserviceDestinationConfigurationIsNull = true;
            request.AmazonopensearchserviceDestinationConfiguration = new Amazon.KinesisFirehose.Model.AmazonopensearchserviceDestinationConfiguration();
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ClusterEndpoint = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ClusterEndpoint = cmdletContext.AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ClusterEndpoint != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.ClusterEndpoint = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ClusterEndpoint;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DomainARN = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_DomainARN != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DomainARN = cmdletContext.AmazonopensearchserviceDestinationConfiguration_DomainARN;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DomainARN != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.DomainARN = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DomainARN;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexName = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_IndexName != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexName = cmdletContext.AmazonopensearchserviceDestinationConfiguration_IndexName;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexName != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.IndexName = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexName;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.AmazonopensearchserviceIndexRotationPeriod requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexRotationPeriod = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexRotationPeriod = cmdletContext.AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexRotationPeriod != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.IndexRotationPeriod = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_IndexRotationPeriod;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RoleARN = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_RoleARN != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RoleARN = cmdletContext.AmazonopensearchserviceDestinationConfiguration_RoleARN;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RoleARN != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.RoleARN = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RoleARN;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.AmazonopensearchserviceS3BackupMode requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3BackupMode = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_S3BackupMode != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3BackupMode = cmdletContext.AmazonopensearchserviceDestinationConfiguration_S3BackupMode;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3BackupMode != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.S3BackupMode = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3BackupMode;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.S3DestinationConfiguration requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3Configuration = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_S3Configuration != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3Configuration = cmdletContext.AmazonopensearchserviceDestinationConfiguration_S3Configuration;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3Configuration != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.S3Configuration = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_S3Configuration;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_TypeName = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_TypeName != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_TypeName = cmdletContext.AmazonopensearchserviceDestinationConfiguration_TypeName;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_TypeName != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.TypeName = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_TypeName;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.AmazonopensearchserviceRetryOptions requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions = null;
            
             // populate RetryOptions
            var requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptionsIsNull = true;
            requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions = new Amazon.KinesisFirehose.Model.AmazonopensearchserviceRetryOptions();
            System.Int32? requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions_amazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions_amazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds = cmdletContext.AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions_amazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions.DurationInSeconds = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions_amazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptionsIsNull = false;
            }
             // determine if requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions should be set to null
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptionsIsNull)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions = null;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.RetryOptions = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_RetryOptions;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.AmazonopensearchserviceBufferingHints requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints = null;
            
             // populate BufferingHints
            var requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHintsIsNull = true;
            requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints = new Amazon.KinesisFirehose.Model.AmazonopensearchserviceBufferingHints();
            System.Int32? requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds = cmdletContext.AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints.IntervalInSeconds = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHintsIsNull = false;
            }
            System.Int32? requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs = cmdletContext.AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs.Value;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints.SizeInMBs = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints_amazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs.Value;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHintsIsNull = false;
            }
             // determine if requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints should be set to null
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHintsIsNull)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints = null;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.BufferingHints = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_BufferingHints;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ProcessingConfiguration requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration = null;
            
             // populate ProcessingConfiguration
            var requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfigurationIsNull = true;
            requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled = cmdletContext.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration.Enabled = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors = cmdletContext.AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration.Processors = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
             // determine if requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration should be set to null
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfigurationIsNull)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration = null;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.ProcessingConfiguration = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_ProcessingConfiguration;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions = null;
            
             // populate CloudWatchLoggingOptions
            var requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptionsIsNull = true;
            requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled = cmdletContext.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions.Enabled = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = cmdletContext.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions.LogGroupName = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = cmdletContext.AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions.LogStreamName = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
             // determine if requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions should be set to null
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptionsIsNull)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions = null;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.CloudWatchLoggingOptions = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.VpcConfiguration requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfigurationIsNull = true;
            requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration = new Amazon.KinesisFirehose.Model.VpcConfiguration();
            System.String requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN = cmdletContext.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration.RoleARN = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds = cmdletContext.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration.SecurityGroupIds = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds = cmdletContext.AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration.SubnetIds = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfigurationIsNull = false;
            }
             // determine if requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration should be set to null
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfigurationIsNull)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration = null;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.VpcConfiguration = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_VpcConfiguration;
                requestAmazonopensearchserviceDestinationConfigurationIsNull = false;
            }
             // determine if request.AmazonopensearchserviceDestinationConfiguration should be set to null
            if (requestAmazonopensearchserviceDestinationConfigurationIsNull)
            {
                request.AmazonopensearchserviceDestinationConfiguration = null;
            }
            
             // populate DeliveryStreamEncryptionConfigurationInput
            var requestDeliveryStreamEncryptionConfigurationInputIsNull = true;
            request.DeliveryStreamEncryptionConfigurationInput = new Amazon.KinesisFirehose.Model.DeliveryStreamEncryptionConfigurationInput();
            System.String requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN = null;
            if (cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyARN != null)
            {
                requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN = cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyARN;
            }
            if (requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN != null)
            {
                request.DeliveryStreamEncryptionConfigurationInput.KeyARN = requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyARN;
                requestDeliveryStreamEncryptionConfigurationInputIsNull = false;
            }
            Amazon.KinesisFirehose.KeyType requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType = null;
            if (cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyType != null)
            {
                requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType = cmdletContext.DeliveryStreamEncryptionConfigurationInput_KeyType;
            }
            if (requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType != null)
            {
                request.DeliveryStreamEncryptionConfigurationInput.KeyType = requestDeliveryStreamEncryptionConfigurationInput_deliveryStreamEncryptionConfigurationInput_KeyType;
                requestDeliveryStreamEncryptionConfigurationInputIsNull = false;
            }
             // determine if request.DeliveryStreamEncryptionConfigurationInput should be set to null
            if (requestDeliveryStreamEncryptionConfigurationInputIsNull)
            {
                request.DeliveryStreamEncryptionConfigurationInput = null;
            }
            if (cmdletContext.DeliveryStreamName != null)
            {
                request.DeliveryStreamName = cmdletContext.DeliveryStreamName;
            }
            if (cmdletContext.DeliveryStreamType != null)
            {
                request.DeliveryStreamType = cmdletContext.DeliveryStreamType;
            }
            
             // populate ElasticsearchDestinationConfiguration
            var requestElasticsearchDestinationConfigurationIsNull = true;
            request.ElasticsearchDestinationConfiguration = new Amazon.KinesisFirehose.Model.ElasticsearchDestinationConfiguration();
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ClusterEndpoint = null;
            if (cmdletContext.ElasticsearchDestinationConfiguration_ClusterEndpoint != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ClusterEndpoint = cmdletContext.ElasticsearchDestinationConfiguration_ClusterEndpoint;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ClusterEndpoint != null)
            {
                request.ElasticsearchDestinationConfiguration.ClusterEndpoint = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ClusterEndpoint;
                requestElasticsearchDestinationConfigurationIsNull = false;
            }
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
            var requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptionsIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions = new Amazon.KinesisFirehose.Model.ElasticsearchRetryOptions();
            System.Int32? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions_retryOptions_DurationInSecond = null;
            if (cmdletContext.RetryOptions_DurationInSecond != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_RetryOptions_retryOptions_DurationInSecond = cmdletContext.RetryOptions_DurationInSecond.Value;
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
            var requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHintsIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints = new Amazon.KinesisFirehose.Model.ElasticsearchBufferingHints();
            System.Int32? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond = null;
            if (cmdletContext.BufferingHints_IntervalInSecond != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond = cmdletContext.BufferingHints_IntervalInSecond.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints.IntervalInSeconds = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_IntervalInSecond.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHintsIsNull = false;
            }
            System.Int32? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_SizeInMBs = null;
            if (cmdletContext.BufferingHints_SizeInMBs != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_BufferingHints_bufferingHints_SizeInMBs = cmdletContext.BufferingHints_SizeInMBs.Value;
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
            var requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfigurationIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled = null;
            if (cmdletContext.ProcessingConfiguration_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled = cmdletContext.ProcessingConfiguration_Enabled.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration.Enabled = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Enabled.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Processor = null;
            if (cmdletContext.ProcessingConfiguration_Processor != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_ProcessingConfiguration_processingConfiguration_Processor = cmdletContext.ProcessingConfiguration_Processor;
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
            var requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.CloudWatchLoggingOptions_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled = cmdletContext.CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions.Enabled = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_Enabled.Value;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName = cmdletContext.CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions.LogGroupName = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogGroupName;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_CloudWatchLoggingOptions_cloudWatchLoggingOptions_LogStreamName = cmdletContext.CloudWatchLoggingOptions_LogStreamName;
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
            Amazon.KinesisFirehose.Model.VpcConfiguration requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfigurationIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration = new Amazon.KinesisFirehose.Model.VpcConfiguration();
            System.String requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_RoleARN = null;
            if (cmdletContext.VpcConfiguration_RoleARN != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_RoleARN = cmdletContext.VpcConfiguration_RoleARN;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_RoleARN != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration.RoleARN = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_RoleARN;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroupId = null;
            if (cmdletContext.VpcConfiguration_SecurityGroupId != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroupId = cmdletContext.VpcConfiguration_SecurityGroupId;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroupId != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration.SecurityGroupIds = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SecurityGroupId;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfigurationIsNull = false;
            }
            List<System.String> requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId = null;
            if (cmdletContext.VpcConfiguration_SubnetId != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId = cmdletContext.VpcConfiguration_SubnetId;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration.SubnetIds = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration_vpcConfiguration_SubnetId;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfigurationIsNull = false;
            }
             // determine if requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration should be set to null
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfigurationIsNull)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration = null;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration != null)
            {
                request.ElasticsearchDestinationConfiguration.VpcConfiguration = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_VpcConfiguration;
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
            
             // populate HttpEndpointDestinationConfiguration
            var requestHttpEndpointDestinationConfigurationIsNull = true;
            request.HttpEndpointDestinationConfiguration = new Amazon.KinesisFirehose.Model.HttpEndpointDestinationConfiguration();
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RoleARN = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_RoleARN != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RoleARN = cmdletContext.HttpEndpointDestinationConfiguration_RoleARN;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RoleARN != null)
            {
                request.HttpEndpointDestinationConfiguration.RoleARN = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RoleARN;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.HttpEndpointS3BackupMode requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3BackupMode = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_S3BackupMode != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3BackupMode = cmdletContext.HttpEndpointDestinationConfiguration_S3BackupMode;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3BackupMode != null)
            {
                request.HttpEndpointDestinationConfiguration.S3BackupMode = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3BackupMode;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.S3DestinationConfiguration requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3Configuration = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_S3Configuration != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3Configuration = cmdletContext.HttpEndpointDestinationConfiguration_S3Configuration;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3Configuration != null)
            {
                request.HttpEndpointDestinationConfiguration.S3Configuration = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_S3Configuration;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.HttpEndpointRetryOptions requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions = null;
            
             // populate RetryOptions
            var requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptionsIsNull = true;
            requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions = new Amazon.KinesisFirehose.Model.HttpEndpointRetryOptions();
            System.Int32? requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions_httpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions_httpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds = cmdletContext.HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions_httpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions.DurationInSeconds = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions_httpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptionsIsNull = false;
            }
             // determine if requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions should be set to null
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptionsIsNull)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions = null;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions != null)
            {
                request.HttpEndpointDestinationConfiguration.RetryOptions = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RetryOptions;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.HttpEndpointBufferingHints requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints = null;
            
             // populate BufferingHints
            var requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHintsIsNull = true;
            requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints = new Amazon.KinesisFirehose.Model.HttpEndpointBufferingHints();
            System.Int32? requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds = cmdletContext.HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints.IntervalInSeconds = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHintsIsNull = false;
            }
            System.Int32? requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_SizeInMBs = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_SizeInMBs = cmdletContext.HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs.Value;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints.SizeInMBs = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints_httpEndpointDestinationConfiguration_BufferingHints_SizeInMBs.Value;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHintsIsNull = false;
            }
             // determine if requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints should be set to null
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHintsIsNull)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints = null;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints != null)
            {
                request.HttpEndpointDestinationConfiguration.BufferingHints = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_BufferingHints;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ProcessingConfiguration requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration = null;
            
             // populate ProcessingConfiguration
            var requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfigurationIsNull = true;
            requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled = cmdletContext.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration.Enabled = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Processors = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Processors = cmdletContext.HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration.Processors = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration_Processors;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
             // determine if requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration should be set to null
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfigurationIsNull)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration = null;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration != null)
            {
                request.HttpEndpointDestinationConfiguration.ProcessingConfiguration = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_ProcessingConfiguration;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.HttpEndpointRequestConfiguration requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration = null;
            
             // populate RequestConfiguration
            var requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfigurationIsNull = true;
            requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration = new Amazon.KinesisFirehose.Model.HttpEndpointRequestConfiguration();
            List<Amazon.KinesisFirehose.Model.HttpEndpointCommonAttribute> requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes = cmdletContext.HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration.CommonAttributes = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.ContentEncoding requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding = cmdletContext.HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration.ContentEncoding = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfigurationIsNull = false;
            }
             // determine if requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration should be set to null
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfigurationIsNull)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration = null;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration != null)
            {
                request.HttpEndpointDestinationConfiguration.RequestConfiguration = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_RequestConfiguration;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions = null;
            
             // populate CloudWatchLoggingOptions
            var requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptionsIsNull = true;
            requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled = cmdletContext.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions.Enabled = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = cmdletContext.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions.LogGroupName = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = cmdletContext.HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions.LogStreamName = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
             // determine if requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions should be set to null
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptionsIsNull)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions = null;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions != null)
            {
                request.HttpEndpointDestinationConfiguration.CloudWatchLoggingOptions = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_CloudWatchLoggingOptions;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.HttpEndpointConfiguration requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration = null;
            
             // populate EndpointConfiguration
            var requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfigurationIsNull = true;
            requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration = new Amazon.KinesisFirehose.Model.HttpEndpointConfiguration();
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey = cmdletContext.HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration.AccessKey = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfigurationIsNull = false;
            }
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_endpointConfiguration_Name = null;
            if (cmdletContext.EndpointConfiguration_Name != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_endpointConfiguration_Name = cmdletContext.EndpointConfiguration_Name;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_endpointConfiguration_Name != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration.Name = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_endpointConfiguration_Name;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfigurationIsNull = false;
            }
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_Url = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_EndpointConfiguration_Url != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_Url = cmdletContext.HttpEndpointDestinationConfiguration_EndpointConfiguration_Url;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_Url != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration.Url = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration_Url;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfigurationIsNull = false;
            }
             // determine if requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration should be set to null
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfigurationIsNull)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration = null;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration != null)
            {
                request.HttpEndpointDestinationConfiguration.EndpointConfiguration = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_EndpointConfiguration;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
             // determine if request.HttpEndpointDestinationConfiguration should be set to null
            if (requestHttpEndpointDestinationConfigurationIsNull)
            {
                request.HttpEndpointDestinationConfiguration = null;
            }
            
             // populate KinesisStreamSourceConfiguration
            var requestKinesisStreamSourceConfigurationIsNull = true;
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
        
        private Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.CreateDeliveryStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "CreateDeliveryStream");
            try
            {
                #if DESKTOP
                return client.CreateDeliveryStream(request);
                #elif CORECLR
                return client.CreateDeliveryStreamAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
            public System.Int32? AmazonOpenSearchServerlessDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String AmazonOpenSearchServerlessDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String AmazonOpenSearchServerlessDestinationConfiguration_CollectionEndpoint { get; set; }
            public System.String AmazonOpenSearchServerlessDestinationConfiguration_IndexName { get; set; }
            public System.Boolean? AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> AmazonOpenSearchServerlessDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
            public System.Int32? AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
            public System.String AmazonOpenSearchServerlessDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.AmazonOpenSearchServerlessS3BackupMode AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration AmazonOpenSearchServerlessDestinationConfiguration_S3Configuration { get; set; }
            public System.String AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN { get; set; }
            public List<System.String> AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds { get; set; }
            public List<System.String> AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds { get; set; }
            public System.Int32? AmazonopensearchserviceDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
            public System.Int32? AmazonopensearchserviceDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_ClusterEndpoint { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_DomainARN { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_IndexName { get; set; }
            public Amazon.KinesisFirehose.AmazonopensearchserviceIndexRotationPeriod AmazonopensearchserviceDestinationConfiguration_IndexRotationPeriod { get; set; }
            public System.Boolean? AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> AmazonopensearchserviceDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
            public System.Int32? AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.AmazonopensearchserviceS3BackupMode AmazonopensearchserviceDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration AmazonopensearchserviceDestinationConfiguration_S3Configuration { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_TypeName { get; set; }
            public System.String AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN { get; set; }
            public List<System.String> AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds { get; set; }
            public List<System.String> AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds { get; set; }
            public System.String DeliveryStreamEncryptionConfigurationInput_KeyARN { get; set; }
            public Amazon.KinesisFirehose.KeyType DeliveryStreamEncryptionConfigurationInput_KeyType { get; set; }
            public System.String DeliveryStreamName { get; set; }
            public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
            public System.Int32? BufferingHints_IntervalInSecond { get; set; }
            public System.Int32? BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String ElasticsearchDestinationConfiguration_ClusterEndpoint { get; set; }
            public System.String ElasticsearchDestinationConfiguration_DomainARN { get; set; }
            public System.String ElasticsearchDestinationConfiguration_IndexName { get; set; }
            public Amazon.KinesisFirehose.ElasticsearchIndexRotationPeriod ElasticsearchDestinationConfiguration_IndexRotationPeriod { get; set; }
            public System.Boolean? ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> ProcessingConfiguration_Processor { get; set; }
            public System.Int32? RetryOptions_DurationInSecond { get; set; }
            public System.String ElasticsearchDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.ElasticsearchS3BackupMode ElasticsearchDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration ElasticsearchDestinationConfiguration_S3Configuration { get; set; }
            public System.String ElasticsearchDestinationConfiguration_TypeName { get; set; }
            public System.String VpcConfiguration_RoleARN { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public Amazon.KinesisFirehose.Model.ExtendedS3DestinationConfiguration ExtendedS3DestinationConfiguration { get; set; }
            public System.Int32? HttpEndpointDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
            public System.Int32? HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String HttpEndpointDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String HttpEndpointDestinationConfiguration_EndpointConfiguration_AccessKey { get; set; }
            public System.String EndpointConfiguration_Name { get; set; }
            public System.String HttpEndpointDestinationConfiguration_EndpointConfiguration_Url { get; set; }
            public System.Boolean? HttpEndpointDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> HttpEndpointDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
            public List<Amazon.KinesisFirehose.Model.HttpEndpointCommonAttribute> HttpEndpointDestinationConfiguration_RequestConfiguration_CommonAttributes { get; set; }
            public Amazon.KinesisFirehose.ContentEncoding HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding { get; set; }
            public System.Int32? HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
            public System.String HttpEndpointDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.HttpEndpointS3BackupMode HttpEndpointDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration HttpEndpointDestinationConfiguration_S3Configuration { get; set; }
            public System.String KinesisStreamSourceConfiguration_KinesisStreamARN { get; set; }
            public System.String KinesisStreamSourceConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.Model.RedshiftDestinationConfiguration RedshiftDestinationConfiguration { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration S3DestinationConfiguration { get; set; }
            public Amazon.KinesisFirehose.Model.SplunkDestinationConfiguration SplunkDestinationConfiguration { get; set; }
            public List<Amazon.KinesisFirehose.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse, NewKINFDeliveryStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeliveryStreamARN;
        }
        
    }
}
