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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Creates a Firehose stream.
    /// 
    ///  
    /// <para>
    /// By default, you can create up to 5,000 Firehose streams per Amazon Web Services Region.
    /// </para><para>
    /// This is an asynchronous operation that immediately returns. The initial status of
    /// the Firehose stream is <c>CREATING</c>. After the Firehose stream is created, its
    /// status is <c>ACTIVE</c> and it now accepts data. If the Firehose stream creation fails,
    /// the status transitions to <c>CREATING_FAILED</c>. Attempts to send data to a delivery
    /// stream that is not in the <c>ACTIVE</c> state cause an exception. To check the state
    /// of a Firehose stream, use <a>DescribeDeliveryStream</a>.
    /// </para><para>
    /// If the status of a Firehose stream is <c>CREATING_FAILED</c>, this status doesn't
    /// change, and you can't invoke <c>CreateDeliveryStream</c> again on it. However, you
    /// can invoke the <a>DeleteDeliveryStream</a> operation to delete it.
    /// </para><para>
    /// A Firehose stream can be configured to receive records directly from providers using
    /// <a>PutRecord</a> or <a>PutRecordBatch</a>, or it can be configured to use an existing
    /// Kinesis stream as its source. To specify a Kinesis data stream as input, set the <c>DeliveryStreamType</c>
    /// parameter to <c>KinesisStreamAsSource</c>, and provide the Kinesis stream Amazon Resource
    /// Name (ARN) and role ARN in the <c>KinesisStreamSourceConfiguration</c> parameter.
    /// </para><para>
    /// To create a Firehose stream with server-side encryption (SSE) enabled, include <a>DeliveryStreamEncryptionConfigurationInput</a>
    /// in your request. This is optional. You can also invoke <a>StartDeliveryStreamEncryption</a>
    /// to turn on SSE for an existing Firehose stream that doesn't have SSE enabled.
    /// </para><para>
    /// A Firehose stream is configured with a single destination, such as Amazon Simple Storage
    /// Service (Amazon S3), Amazon Redshift, Amazon OpenSearch Service, Amazon OpenSearch
    /// Serverless, Splunk, and any custom HTTP endpoint or HTTP endpoints owned by or supported
    /// by third-party service providers, including Datadog, Dynatrace, LogicMonitor, MongoDB,
    /// New Relic, and Sumo Logic. You must specify only one of the following destination
    /// configuration parameters: <c>ExtendedS3DestinationConfiguration</c>, <c>S3DestinationConfiguration</c>,
    /// <c>ElasticsearchDestinationConfiguration</c>, <c>RedshiftDestinationConfiguration</c>,
    /// or <c>SplunkDestinationConfiguration</c>.
    /// </para><para>
    /// When you specify <c>S3DestinationConfiguration</c>, you can also provide the following
    /// optional values: BufferingHints, <c>EncryptionConfiguration</c>, and <c>CompressionFormat</c>.
    /// By default, if no <c>BufferingHints</c> value is provided, Firehose buffers data up
    /// to 5 MB or for 5 minutes, whichever condition is satisfied first. <c>BufferingHints</c>
    /// is a hint, so there are some cases where the service cannot adhere to these conditions
    /// strictly. For example, record boundaries might be such that the size is a little over
    /// or under the configured buffering size. By default, no encryption is performed. We
    /// strongly recommend that you enable encryption to ensure secure data storage in Amazon
    /// S3.
    /// </para><para>
    /// A few notes about Amazon Redshift as a destination:
    /// </para><ul><li><para>
    /// An Amazon Redshift destination requires an S3 bucket as intermediate location. Firehose
    /// first delivers data to Amazon S3 and then uses <c>COPY</c> syntax to load data into
    /// an Amazon Redshift table. This is specified in the <c>RedshiftDestinationConfiguration.S3Configuration</c>
    /// parameter.
    /// </para></li><li><para>
    /// The compression formats <c>SNAPPY</c> or <c>ZIP</c> cannot be specified in <c>RedshiftDestinationConfiguration.S3Configuration</c>
    /// because the Amazon Redshift <c>COPY</c> operation that reads from the S3 bucket doesn't
    /// support these compression formats.
    /// </para></li><li><para>
    /// We strongly recommend that you use the user name and password you provide exclusively
    /// with Firehose, and that the permissions for the account are restricted for Amazon
    /// Redshift <c>INSERT</c> permissions.
    /// </para></li></ul><para>
    /// Firehose assumes the IAM role that is configured as part of the destination. The role
    /// should allow the Firehose principal to assume the role, and the role should have permissions
    /// that allow the service to deliver the data. For more information, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Grant
    /// Firehose Access to an Amazon S3 Destination</a> in the <i>Amazon Firehose Developer
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KINFDeliveryStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose CreateDeliveryStream API operation.", Operation = new[] {"CreateDeliveryStream"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKINFDeliveryStreamCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter SnowflakeDestinationConfiguration_AccountUrl
        /// <summary>
        /// <para>
        /// <para>URL for accessing your Snowflake account. This URL must include your <a href="https://docs.snowflake.com/en/user-guide/admin-account-identifier">account
        /// identifier</a>. Note that the protocol (https://) and port number are optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_AccountUrl { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_AppendOnly
        /// <summary>
        /// <para>
        /// <para> Describes whether all incoming data for this delivery stream will be append only
        /// (inserts only and not for updates and deletes) for Iceberg delivery. This feature
        /// is only applicable for Apache Iceberg Tables.</para><para>The default value is false. If you set this value to true, Firehose automatically
        /// increases the throughput limit of a stream based on the throttling levels of the stream.
        /// If you set this parameter to true for a stream with updates and deletes, you will
        /// see out of order delivery. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IcebergDestinationConfiguration_AppendOnly { get; set; }
        #endregion
        
        #region Parameter CatalogConfiguration_CatalogARN
        /// <summary>
        /// <para>
        /// <para> Specifies the Glue catalog ARN identifier of the destination Apache Iceberg Tables.
        /// You must specify the ARN in the format <c>arn:aws:glue:region:account-id:catalog</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IcebergDestinationConfiguration_CatalogConfiguration_CatalogARN")]
        public System.String CatalogConfiguration_CatalogARN { get; set; }
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
        /// <para>The endpoint to use when communicating with the cluster. Specify either this <c>ClusterEndpoint</c>
        /// or the <c>DomainARN</c> field.</para>
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
        
        #region Parameter AuthenticationConfiguration_Connectivity
        /// <summary>
        /// <para>
        /// <para>The type of connectivity used to access the Amazon MSK cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MSKSourceConfiguration_AuthenticationConfiguration_Connectivity")]
        [AWSConstantClassSource("Amazon.KinesisFirehose.Connectivity")]
        public Amazon.KinesisFirehose.Connectivity AuthenticationConfiguration_Connectivity { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_ContentColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the record content column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_ContentColumnName { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding
        /// <summary>
        /// <para>
        /// <para>Firehose uses the content encoding to compress the body of a request before sending
        /// the request to the destination. For more information, see <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Encoding">Content-Encoding</a>
        /// in MDN Web Docs, the official Mozilla documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ContentEncoding")]
        public Amazon.KinesisFirehose.ContentEncoding HttpEndpointDestinationConfiguration_RequestConfiguration_ContentEncoding { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_Database
        /// <summary>
        /// <para>
        /// <para>All data in Snowflake is maintained in databases.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_Database { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_DataLoadingOption
        /// <summary>
        /// <para>
        /// <para>Choose to load JSON keys mapped to table column names or choose to split the JSON
        /// payload where content is mapped to a record content column and source metadata is
        /// mapped to a record metadata column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.SnowflakeDataLoadingOption")]
        public Amazon.KinesisFirehose.SnowflakeDataLoadingOption SnowflakeDestinationConfiguration_DataLoadingOption { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat
        /// <summary>
        /// <para>
        /// <para>When the <c>FIREHOSE_DEFAULT</c> option is chosen, Firehose generates a unique document
        /// ID for each record based on a unique internal identifier. The generated document ID
        /// is stable across multiple delivery attempts, which helps prevent the same record from
        /// being indexed multiple times with different document IDs.</para><para>When the <c>NO_DOCUMENT_ID</c> option is chosen, Firehose does not include any document
        /// IDs in the requests it sends to the Amazon OpenSearch Service. This causes the Amazon
        /// OpenSearch Service domain to generate document IDs. In case of multiple delivery attempts,
        /// this may cause the same record to be indexed more than once with different document
        /// IDs. This option enables write-heavy operations, such as the ingestion of logs and
        /// observability data, to consume less resources in the Amazon OpenSearch Service domain,
        /// resulting in improved performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DefaultDocumentIdFormat")]
        public Amazon.KinesisFirehose.DefaultDocumentIdFormat AmazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat { get; set; }
        #endregion
        
        #region Parameter DocumentIdOptions_DefaultDocumentIdFormat
        /// <summary>
        /// <para>
        /// <para>When the <c>FIREHOSE_DEFAULT</c> option is chosen, Firehose generates a unique document
        /// ID for each record based on a unique internal identifier. The generated document ID
        /// is stable across multiple delivery attempts, which helps prevent the same record from
        /// being indexed multiple times with different document IDs.</para><para>When the <c>NO_DOCUMENT_ID</c> option is chosen, Firehose does not include any document
        /// IDs in the requests it sends to the Amazon OpenSearch Service. This causes the Amazon
        /// OpenSearch Service domain to generate document IDs. In case of multiple delivery attempts,
        /// this may cause the same record to be indexed more than once with different document
        /// IDs. This option enables write-heavy operations, such as the ingestion of logs and
        /// observability data, to consume less resources in the Amazon OpenSearch Service domain,
        /// resulting in improved performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat")]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DefaultDocumentIdFormat")]
        public Amazon.KinesisFirehose.DefaultDocumentIdFormat DocumentIdOptions_DefaultDocumentIdFormat { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the Firehose stream. This name must be unique per Amazon Web Services
        /// account in the same Amazon Web Services Region. If the Firehose streams are in different
        /// accounts or different Regions, you can have multiple Firehose streams with the same
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
        /// <para>The Firehose stream type. This parameter can be one of the following values:</para><ul><li><para><c>DirectPut</c>: Provider applications access the Firehose stream directly.</para></li><li><para><c>KinesisStreamAsSource</c>: The Firehose stream uses a Kinesis data stream as a
        /// source.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DeliveryStreamType")]
        public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_DestinationTableConfigurationList
        /// <summary>
        /// <para>
        /// <para> Provides a list of <c>DestinationTableConfigurations</c> which Firehose uses to deliver
        /// data to Apache Iceberg Tables. Firehose will write data with insert if table specific
        /// configuration is not provided here.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.DestinationTableConfiguration[] IcebergDestinationConfiguration_DestinationTableConfigurationList { get; set; }
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
        /// <para>The ARN of the Amazon OpenSearch Service domain. The IAM role must have permissions
        /// for <c>DescribeDomain</c>, <c>DescribeDomains</c>, and <c>DescribeDomainConfig</c> after
        /// assuming the role specified in <b>RoleARN</b>. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para><para>Specify either <c>ClusterEndpoint</c> or <c>DomainARN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationConfiguration_DomainARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>After an initial failure to deliver to the Serverless offering for Amazon OpenSearch
        /// Service, the total amount of time during which Firehose retries delivery (including
        /// the first attempt). After this time has elapsed, the failed documents are written
        /// to Amazon S3. Default value is 300 seconds (5 minutes). A value of 0 (zero) results
        /// in no retries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonOpenSearchServerlessDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>After an initial failure to deliver to Amazon OpenSearch Service, the total amount
        /// of time during which Firehose retries delivery (including the first attempt). After
        /// this time has elapsed, the failed documents are written to Amazon S3. Default value
        /// is 300 seconds (5 minutes). A value of 0 (zero) results in no retries. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AmazonopensearchserviceDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter RetryOptions_DurationInSecond
        /// <summary>
        /// <para>
        /// <para>After an initial failure to deliver to Amazon OpenSearch Service, the total amount
        /// of time during which Firehose retries delivery (including the first attempt). After
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
        /// <para>The total amount of time that Firehose spends on retries. This duration starts after
        /// the initial attempt to send data to the custom destination via HTTPS endpoint fails.
        /// It doesn't include the periods during which Firehose waits for acknowledgment from
        /// the specified destination after each attempt. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpEndpointDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_RetryOptions_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The period of time during which Firehose retries to deliver data to the specified
        /// destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IcebergDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>the time period where Firehose will retry sending data to the chosen HTTP endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
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
        
        #region Parameter SecretsManagerConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to use the secrets manager feature. When set as <c>True</c>
        /// the secrets manager configuration overwrites the existing secrets in the destination
        /// configuration. When it's set to <c>False</c> Firehose falls back to the credentials
        /// in the destination configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_Enabled")]
        public System.Boolean? SecretsManagerConfiguration_Enabled { get; set; }
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
        
        #region Parameter HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to use the secrets manager feature. When set as <c>True</c>
        /// the secrets manager configuration overwrites the existing secrets in the destination
        /// configuration. When it's set to <c>False</c> Firehose falls back to the credentials
        /// in the destination configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IcebergDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter SchemaEvolutionConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para> Specify whether you want to enable schema evolution. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IcebergDestinationConfiguration_SchemaEvolutionConfiguration_Enabled")]
        public System.Boolean? SchemaEvolutionConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter TableCreationConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para> Specify whether you want to enable automatic table creation. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IcebergDestinationConfiguration_TableCreationConfiguration_Enabled")]
        public System.Boolean? TableCreationConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables data processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to use the secrets manager feature. When set as <c>True</c>
        /// the secrets manager configuration overwrites the existing secrets in the destination
        /// configuration. When it's set to <c>False</c> Firehose falls back to the credentials
        /// in the destination configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter SnowflakeRoleConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enable Snowflake role</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnowflakeDestinationConfiguration_SnowflakeRoleConfiguration_Enabled")]
        public System.Boolean? SnowflakeRoleConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter DatabaseSourceConfiguration_Endpoint
        /// <summary>
        /// <para>
        /// <para> The endpoint of the database server. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseSourceConfiguration_Endpoint { get; set; }
        #endregion
        
        #region Parameter Columns_Exclude
        /// <summary>
        /// <para>
        /// <para> The list of column patterns in source database to be excluded for Firehose to read
        /// from. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_Columns_Exclude")]
        public System.String[] Columns_Exclude { get; set; }
        #endregion
        
        #region Parameter Databases_Exclude
        /// <summary>
        /// <para>
        /// <para>The list of database patterns in source database endpoint to be excluded for Firehose
        /// to read from. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_Databases_Exclude")]
        public System.String[] Databases_Exclude { get; set; }
        #endregion
        
        #region Parameter Tables_Exclude
        /// <summary>
        /// <para>
        /// <para>The list of table patterns in source database endpoint to be excluded for Firehose
        /// to read from. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_Tables_Exclude")]
        public System.String[] Tables_Exclude { get; set; }
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
        
        #region Parameter Columns_Include
        /// <summary>
        /// <para>
        /// <para> The list of column patterns in source database to be included for Firehose to read
        /// from. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_Columns_Include")]
        public System.String[] Columns_Include { get; set; }
        #endregion
        
        #region Parameter Databases_Include
        /// <summary>
        /// <para>
        /// <para>The list of database patterns in source database endpoint to be included for Firehose
        /// to read from. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_Databases_Include")]
        public System.String[] Databases_Include { get; set; }
        #endregion
        
        #region Parameter Tables_Include
        /// <summary>
        /// <para>
        /// <para>The list of table patterns in source database endpoint to be included for Firehose
        /// to read from. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_Tables_Include")]
        public System.String[] Tables_Include { get; set; }
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
        /// <c>IndexName</c> to facilitate the expiration of old data. For more information, see
        /// <a href="https://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-index-rotation">Index
        /// Rotation for the Amazon OpenSearch Service Destination</a>. The default value is <c>OneDay</c>.</para>
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
        
        #region Parameter IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 300. This parameter is optional but if
        /// you specify a value for it, you must also specify a value for <c>SizeInMBs</c>, and
        /// vice versa.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds
        /// <summary>
        /// <para>
        /// <para> Buffer incoming data for the specified period of time, in seconds, before delivering
        /// it to the destination. The default value is 0. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamEncryptionConfigurationInput_KeyARN
        /// <summary>
        /// <para>
        /// <para>If you set <c>KeyType</c> to <c>CUSTOMER_MANAGED_CMK</c>, you must specify the Amazon
        /// Resource Name (ARN) of the CMK. If you set <c>KeyType</c> to <c>Amazon Web Services_OWNED_CMK</c>,
        /// Firehose uses a service-account CMK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeliveryStreamEncryptionConfigurationInput_KeyARN { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_KeyPassphrase
        /// <summary>
        /// <para>
        /// <para>Passphrase to decrypt the private key when the key is encrypted. For information,
        /// see <a href="https://docs.snowflake.com/en/user-guide/data-load-snowpipe-streaming-configuration#using-key-pair-authentication-key-rotation">Using
        /// Key Pair Authentication &amp; Key Rotation</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_KeyPassphrase { get; set; }
        #endregion
        
        #region Parameter DeliveryStreamEncryptionConfigurationInput_KeyType
        /// <summary>
        /// <para>
        /// <para>Indicates the type of customer master key (CMK) to use for encryption. The default
        /// setting is <c>Amazon Web Services_OWNED_CMK</c>. For more information about CMKs,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#master_keys">Customer
        /// Master Keys (CMKs)</a>. When you invoke <a>CreateDeliveryStream</a> or <a>StartDeliveryStreamEncryption</a>
        /// with <c>KeyType</c> set to CUSTOMER_MANAGED_CMK, Firehose invokes the Amazon KMS operation
        /// <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_CreateGrant.html">CreateGrant</a>
        /// to create a grant that allows the Firehose service to use the customer managed CMK
        /// to perform encryption and decryption. Firehose manages that grant. </para><para>When you invoke <a>StartDeliveryStreamEncryption</a> to change the CMK for a Firehose
        /// stream that is encrypted with a customer managed CMK, Firehose schedules the grant
        /// it had on the old CMK for retirement.</para><para>You can use a CMK of type CUSTOMER_MANAGED_CMK to encrypt up to 500 Firehose streams.
        /// If a <a>CreateDeliveryStream</a> or <a>StartDeliveryStreamEncryption</a> operation
        /// exceeds this limit, Firehose throws a <c>LimitExceededException</c>. </para><important><para>To encrypt your Firehose stream, use symmetric CMKs. Firehose doesn't support asymmetric
        /// CMKs. For information about symmetric and asymmetric CMKs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symm-asymm-concepts.html">About
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
        
        #region Parameter IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch group name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
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
        
        #region Parameter IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName
        /// <summary>
        /// <para>
        /// <para>The CloudWatch log stream name for logging. This value is required if CloudWatch logging
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_MetaDataColumnName
        /// <summary>
        /// <para>
        /// <para>Specify a column name in the table, where the metadata information has to be loaded.
        /// When you enable this field, you will see the following column in the snowflake table,
        /// which differs based on the source type.</para><para>For Direct PUT as source </para><para><c>{ "firehoseDeliveryStreamName" : "streamname", "IngestionTime" : "timestamp" }</c></para><para>For Kinesis Data Stream as source </para><para><c> "kinesisStreamName" : "streamname", "kinesisShardId" : "Id", "kinesisPartitionKey"
        /// : "key", "kinesisSequenceNumber" : "1234", "subsequenceNumber" : "2334", "IngestionTime"
        /// : "timestamp" }</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_MetaDataColumnName { get; set; }
        #endregion
        
        #region Parameter MSKSourceConfiguration_MSKClusterARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon MSK cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MSKSourceConfiguration_MSKClusterARN { get; set; }
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
        
        #region Parameter DatabaseSourceConfiguration_Port
        /// <summary>
        /// <para>
        /// <para>The port of the database. This can be one of the following values.</para><ul><li><para>3306 for MySQL database type</para></li><li><para>5432 for PostgreSQL database type</para></li></ul><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DatabaseSourceConfiguration_Port { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key used to encrypt your Snowflake client. For information, see <a href="https://docs.snowflake.com/en/user-guide/data-load-snowpipe-streaming-configuration#using-key-pair-authentication-key-rotation">Using
        /// Key Pair Authentication &amp; Key Rotation</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_PrivateKey { get; set; }
        #endregion
        
        #region Parameter SnowflakeVpcConfiguration_PrivateLinkVpceId
        /// <summary>
        /// <para>
        /// <para>The VPCE ID for Firehose to privately connect with Snowflake. The ID format is com.amazonaws.vpce.[region].vpce-svc-&lt;[id]&gt;.
        /// For more information, see <a href="https://docs.snowflake.com/en/user-guide/admin-security-privatelink">Amazon
        /// PrivateLink &amp; Snowflake</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnowflakeDestinationConfiguration_SnowflakeVpcConfiguration_PrivateLinkVpceId")]
        public System.String SnowflakeVpcConfiguration_PrivateLinkVpceId { get; set; }
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
        
        #region Parameter IcebergDestinationConfiguration_ProcessingConfiguration_Processors
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.Processor[] IcebergDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors
        /// <summary>
        /// <para>
        /// <para>The data processors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.Processor[] SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
        #endregion
        
        #region Parameter MSKSourceConfiguration_ReadFromTimestamp
        /// <summary>
        /// <para>
        /// <para>The start date and time in UTC for the offset position within your MSK topic from
        /// where Firehose begins to read. By default, this is set to timestamp when Firehose
        /// becomes Active. </para><para>If you want to create a Firehose stream with Earliest start position from SDK or CLI,
        /// you need to set the <c>ReadFromTimestamp</c> parameter to Epoch (1970-01-01T00:00:00Z).
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? MSKSourceConfiguration_ReadFromTimestamp { get; set; }
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
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Firehose for calling
        /// the Serverless offering for Amazon OpenSearch Service Configuration API and for indexing
        /// documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that you want the Firehose stream to use to create endpoints
        /// in the destination VPC. You can use your existing Firehose delivery role or you can
        /// specify a new role. In either case, make sure that the role trusts the Firehose service
        /// principal and that it grants the following permissions:</para><ul><li><para><c>ec2:DescribeVpcs</c></para></li><li><para><c>ec2:DescribeVpcAttribute</c></para></li><li><para><c>ec2:DescribeSubnets</c></para></li><li><para><c>ec2:DescribeSecurityGroups</c></para></li><li><para><c>ec2:DescribeNetworkInterfaces</c></para></li><li><para><c>ec2:CreateNetworkInterface</c></para></li><li><para><c>ec2:CreateNetworkInterfacePermission</c></para></li><li><para><c>ec2:DeleteNetworkInterface</c></para></li></ul><important><para>When you specify subnets for delivering data to the destination in a private VPC,
        /// make sure you have enough number of free IP addresses in chosen subnets. If there
        /// is no available free IP address in a specified subnet, Firehose cannot create or add
        /// ENIs for the data delivery in the private VPC, and the delivery will be degraded or
        /// fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Firehose for calling
        /// the Amazon OpenSearch Service Configuration API and for indexing documents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that you want the Firehose stream to use to create endpoints
        /// in the destination VPC. You can use your existing Firehose delivery role or you can
        /// specify a new role. In either case, make sure that the role trusts the Firehose service
        /// principal and that it grants the following permissions:</para><ul><li><para><c>ec2:DescribeVpcs</c></para></li><li><para><c>ec2:DescribeVpcAttribute</c></para></li><li><para><c>ec2:DescribeSubnets</c></para></li><li><para><c>ec2:DescribeSecurityGroups</c></para></li><li><para><c>ec2:DescribeNetworkInterfaces</c></para></li><li><para><c>ec2:CreateNetworkInterface</c></para></li><li><para><c>ec2:CreateNetworkInterfacePermission</c></para></li><li><para><c>ec2:DeleteNetworkInterface</c></para></li></ul><important><para>When you specify subnets for delivering data to the destination in a private VPC,
        /// make sure you have enough number of free IP addresses in chosen subnets. If there
        /// is no available free IP address in a specified subnet, Firehose cannot create or add
        /// ENIs for the data delivery in the private VPC, and the delivery will be degraded or
        /// fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter SecretsManagerConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para> Specifies the role that Firehose assumes when calling the Secrets Manager API operation.
        /// When you provide the role, it overrides any destination specific role defined in the
        /// destination configuration. If you do not provide the then we use the destination specific
        /// role. This parameter is required for Splunk. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_RoleARN")]
        public System.String SecretsManagerConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to be assumed by Firehose for calling
        /// the Amazon OpenSearch Service Configuration API and for indexing documents. For more
        /// information, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/controlling-access.html#using-iam-s3">Grant
        /// Firehose Access to an Amazon S3 Destination</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that you want the Firehose stream to use to create endpoints
        /// in the destination VPC. You can use your existing Firehose delivery role or you can
        /// specify a new role. In either case, make sure that the role trusts the Firehose service
        /// principal and that it grants the following permissions:</para><ul><li><para><c>ec2:DescribeVpcs</c></para></li><li><para><c>ec2:DescribeVpcAttribute</c></para></li><li><para><c>ec2:DescribeSubnets</c></para></li><li><para><c>ec2:DescribeSecurityGroups</c></para></li><li><para><c>ec2:DescribeNetworkInterfaces</c></para></li><li><para><c>ec2:CreateNetworkInterface</c></para></li><li><para><c>ec2:CreateNetworkInterfacePermission</c></para></li><li><para><c>ec2:DeleteNetworkInterface</c></para></li></ul><important><para>When you specify subnets for delivering data to the destination in a private VPC,
        /// make sure you have enough number of free IP addresses in chosen subnets. If there
        /// is no available free IP address in a specified subnet, Firehose cannot create or add
        /// ENIs for the data delivery in the private VPC, and the delivery will be degraded or
        /// fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_VpcConfiguration_RoleARN")]
        public System.String VpcConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>Firehose uses this IAM role for all the permissions that the delivery stream needs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para> Specifies the role that Firehose assumes when calling the Secrets Manager API operation.
        /// When you provide the role, it overrides any destination specific role defined in the
        /// destination configuration. If you do not provide the then we use the destination specific
        /// role. This parameter is required for Splunk. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the IAM role to be assumed by Firehose for calling
        /// Apache Iceberg Tables. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IcebergDestinationConfiguration_RoleARN { get; set; }
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
        
        #region Parameter AuthenticationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the role used to access the Amazon MSK cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MSKSourceConfiguration_AuthenticationConfiguration_RoleARN")]
        public System.String AuthenticationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Snowflake role</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN
        /// <summary>
        /// <para>
        /// <para> Specifies the role that Firehose assumes when calling the Secrets Manager API operation.
        /// When you provide the role, it overrides any destination specific role defined in the
        /// destination configuration. If you do not provide the then we use the destination specific
        /// role. This parameter is required for Splunk. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Defines how documents should be delivered to Amazon S3. When it is set to FailedDocumentsOnly,
        /// Firehose writes any documents that could not be indexed to the configured Amazon S3
        /// destination, with AmazonOpenSearchService-failed/ appended to the key prefix. When
        /// set to AllDocuments, Firehose delivers all incoming records to Amazon S3, and also
        /// writes failed documents with AmazonOpenSearchService-failed/ appended to the prefix.</para>
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
        /// Firehose writes any documents that could not be indexed to the configured Amazon S3
        /// destination, with AmazonOpenSearchService-failed/ appended to the key prefix. When
        /// set to AllDocuments, Firehose delivers all incoming records to Amazon S3, and also
        /// writes failed documents with AmazonOpenSearchService-failed/ appended to the prefix.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.AmazonopensearchserviceS3BackupMode")]
        public Amazon.KinesisFirehose.AmazonopensearchserviceS3BackupMode AmazonopensearchserviceDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter ElasticsearchDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Defines how documents should be delivered to Amazon S3. When it is set to <c>FailedDocumentsOnly</c>,
        /// Firehose writes any documents that could not be indexed to the configured Amazon S3
        /// destination, with <c>AmazonOpenSearchService-failed/</c> appended to the key prefix.
        /// When set to <c>AllDocuments</c>, Firehose delivers all incoming records to Amazon
        /// S3, and also writes failed documents with <c>AmazonOpenSearchService-failed/</c> appended
        /// to the prefix. For more information, see <a href="https://docs.aws.amazon.com/firehose/latest/dev/basic-deliver.html#es-s3-backup">Amazon
        /// S3 Backup for the Amazon OpenSearch Service Destination</a>. Default value is <c>FailedDocumentsOnly</c>.</para><para>You can't change this backup mode after you create the Firehose stream. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.ElasticsearchS3BackupMode")]
        public Amazon.KinesisFirehose.ElasticsearchS3BackupMode ElasticsearchDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Describes the S3 bucket backup options for the data that Firehose delivers to the
        /// HTTP endpoint destination. You can back up all documents (<c>AllData</c>) or only
        /// the documents that Firehose could not deliver to the specified HTTP endpoint destination
        /// (<c>FailedDataOnly</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.HttpEndpointS3BackupMode")]
        public Amazon.KinesisFirehose.HttpEndpointS3BackupMode HttpEndpointDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para> Describes how Firehose will backup records. Currently,S3 backup only supports <c>FailedDataOnly</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.IcebergS3BackupMode")]
        public Amazon.KinesisFirehose.IcebergS3BackupMode IcebergDestinationConfiguration_S3BackupMode { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_S3BackupMode
        /// <summary>
        /// <para>
        /// <para>Choose an S3 backup mode</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.SnowflakeS3BackupMode")]
        public Amazon.KinesisFirehose.SnowflakeS3BackupMode SnowflakeDestinationConfiguration_S3BackupMode { get; set; }
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
        
        #region Parameter IcebergDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration IcebergDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_S3Configuration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.KinesisFirehose.Model.S3DestinationConfiguration SnowflakeDestinationConfiguration_S3Configuration { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_Schema
        /// <summary>
        /// <para>
        /// <para>Each database consists of one or more schemas, which are logical groupings of database
        /// objects, such as tables and views</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_Schema { get; set; }
        #endregion
        
        #region Parameter SecretsManagerConfiguration_SecretARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret that stores your credentials. It must be in the same region
        /// as the Firehose stream and the role. The secret ARN can reside in a different account
        /// than the Firehose stream and role as Firehose supports cross-account secret access.
        /// This parameter is required when <b>Enabled</b> is set to <c>True</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_SecretARN")]
        public System.String SecretsManagerConfiguration_SecretARN { get; set; }
        #endregion
        
        #region Parameter HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret that stores your credentials. It must be in the same region
        /// as the Firehose stream and the role. The secret ARN can reside in a different account
        /// than the Firehose stream and role as Firehose supports cross-account secret access.
        /// This parameter is required when <b>Enabled</b> is set to <c>True</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret that stores your credentials. It must be in the same region
        /// as the Firehose stream and the role. The secret ARN can reside in a different account
        /// than the Firehose stream and role as Firehose supports cross-account secret access.
        /// This parameter is required when <b>Enabled</b> is set to <c>True</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups that you want Firehose to use when it creates ENIs
        /// in the VPC of the Amazon OpenSearch Service destination. You can use the same security
        /// group that the Amazon OpenSearch Service domain uses or different ones. If you specify
        /// different security groups here, ensure that they allow outbound HTTPS traffic to the
        /// Amazon OpenSearch Service domain's security group. Also ensure that the Amazon OpenSearch
        /// Service domain's security group allows HTTPS traffic from the security groups specified
        /// here. If you use the same security group for both your delivery stream and the Amazon
        /// OpenSearch Service domain, make sure the security group inbound rule allows HTTPS
        /// traffic. For more information about security group rules, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html#SecurityGroupRules">Security
        /// group rules</a> in the Amazon VPC documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SecurityGroupIds { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups that you want Firehose to use when it creates ENIs
        /// in the VPC of the Amazon OpenSearch Service destination. You can use the same security
        /// group that the Amazon OpenSearch Service domain uses or different ones. If you specify
        /// different security groups here, ensure that they allow outbound HTTPS traffic to the
        /// Amazon OpenSearch Service domain's security group. Also ensure that the Amazon OpenSearch
        /// Service domain's security group allows HTTPS traffic from the security groups specified
        /// here. If you use the same security group for both your delivery stream and the Amazon
        /// OpenSearch Service domain, make sure the security group inbound rule allows HTTPS
        /// traffic. For more information about security group rules, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html#SecurityGroupRules">Security
        /// group rules</a> in the Amazon VPC documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SecurityGroupIds { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups that you want Firehose to use when it creates ENIs
        /// in the VPC of the Amazon OpenSearch Service destination. You can use the same security
        /// group that the Amazon OpenSearch Service domain uses or different ones. If you specify
        /// different security groups here, ensure that they allow outbound HTTPS traffic to the
        /// Amazon OpenSearch Service domain's security group. Also ensure that the Amazon OpenSearch
        /// Service domain's security group allows HTTPS traffic from the security groups specified
        /// here. If you use the same security group for both your delivery stream and the Amazon
        /// OpenSearch Service domain, make sure the security group inbound rule allows HTTPS
        /// traffic. For more information about security group rules, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html#SecurityGroupRules">Security
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
        /// typically ingest into the Firehose stream in 10 seconds. For example, if you typically
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
        /// typically ingest into the Firehose stream in 10 seconds. For example, if you typically
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
        /// typically ingest into the Firehose stream in 10 seconds. For example, if you typically
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
        /// typically ingest into the Firehose stream in 10 seconds. For example, if you typically
        /// ingest data at 1 MB/sec, the value should be 10 MB or higher. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HttpEndpointDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter IcebergDestinationConfiguration_BufferingHints_SizeInMBs
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data to the specified size, in MiBs, before delivering it to the destination.
        /// The default value is 5. This parameter is optional but if you specify a value for
        /// it, you must also specify a value for <c>IntervalInSeconds</c>, and vice versa.</para><para>We recommend setting this parameter to a value greater than the amount of data you
        /// typically ingest into the Firehose stream in 10 seconds. For example, if you typically
        /// ingest data at 1 MiB/sec, the value should be 10 MiB or higher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IcebergDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs
        /// <summary>
        /// <para>
        /// <para>Buffer incoming data to the specified size, in MBs, before delivering it to the destination.
        /// The default value is 128. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
        #endregion
        
        #region Parameter DatabaseSourceConfiguration_SnapshotWatermarkTable
        /// <summary>
        /// <para>
        /// <para> The fully qualified name of the table in source database endpoint that Firehose uses
        /// to track snapshot progress. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseSourceConfiguration_SnapshotWatermarkTable { get; set; }
        #endregion
        
        #region Parameter SnowflakeRoleConfiguration_SnowflakeRole
        /// <summary>
        /// <para>
        /// <para>The Snowflake role you wish to configure</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnowflakeDestinationConfiguration_SnowflakeRoleConfiguration_SnowflakeRole")]
        public System.String SnowflakeRoleConfiguration_SnowflakeRole { get; set; }
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
        
        #region Parameter DatabaseSourceConfiguration_SSLMode
        /// <summary>
        /// <para>
        /// <para> The mode to enable or disable SSL when Firehose connects to the database endpoint.
        /// </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.SSLMode")]
        public Amazon.KinesisFirehose.SSLMode DatabaseSourceConfiguration_SSLMode { get; set; }
        #endregion
        
        #region Parameter AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets that you want Firehose to use to create ENIs in the VPC of
        /// the Amazon OpenSearch Service destination. Make sure that the routing tables and inbound
        /// and outbound rules allow traffic to flow from the subnets whose IDs are specified
        /// here to the subnets that have the destination Amazon OpenSearch Service endpoints.
        /// Firehose creates at least one ENI in each of the subnets that are specified here.
        /// Do not delete or modify these ENIs.</para><para>The number of ENIs that Firehose creates in the subnets specified here scales up and
        /// down automatically based on throughput. To enable Firehose to scale up the number
        /// of ENIs to match throughput, ensure that you have sufficient quota. To help you calculate
        /// the quota you need, assume that Firehose can create up to three ENIs for this Firehose
        /// stream for each of the subnets specified here. For more information about ENI quota,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html#vpc-limits-enis">Network
        /// Interfaces </a> in the Amazon VPC Quotas topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonOpenSearchServerlessDestinationConfiguration_VpcConfiguration_SubnetIds { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets that you want Firehose to use to create ENIs in the VPC of
        /// the Amazon OpenSearch Service destination. Make sure that the routing tables and inbound
        /// and outbound rules allow traffic to flow from the subnets whose IDs are specified
        /// here to the subnets that have the destination Amazon OpenSearch Service endpoints.
        /// Firehose creates at least one ENI in each of the subnets that are specified here.
        /// Do not delete or modify these ENIs.</para><para>The number of ENIs that Firehose creates in the subnets specified here scales up and
        /// down automatically based on throughput. To enable Firehose to scale up the number
        /// of ENIs to match throughput, ensure that you have sufficient quota. To help you calculate
        /// the quota you need, assume that Firehose can create up to three ENIs for this Firehose
        /// stream for each of the subnets specified here. For more information about ENI quota,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html#vpc-limits-enis">Network
        /// Interfaces </a> in the Amazon VPC Quotas topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AmazonopensearchserviceDestinationConfiguration_VpcConfiguration_SubnetIds { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets that you want Firehose to use to create ENIs in the VPC of
        /// the Amazon OpenSearch Service destination. Make sure that the routing tables and inbound
        /// and outbound rules allow traffic to flow from the subnets whose IDs are specified
        /// here to the subnets that have the destination Amazon OpenSearch Service endpoints.
        /// Firehose creates at least one ENI in each of the subnets that are specified here.
        /// Do not delete or modify these ENIs.</para><para>The number of ENIs that Firehose creates in the subnets specified here scales up and
        /// down automatically based on throughput. To enable Firehose to scale up the number
        /// of ENIs to match throughput, ensure that you have sufficient quota. To help you calculate
        /// the quota you need, assume that Firehose can create up to three ENIs for this Firehose
        /// stream for each of the subnets specified here. For more information about ENI quota,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html#vpc-limits-enis">Network
        /// Interfaces </a> in the Amazon VPC Quotas topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticsearchDestinationConfiguration_VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter DatabaseSourceConfiguration_SurrogateKey
        /// <summary>
        /// <para>
        /// <para> The optional list of table and column names used as unique key columns when taking
        /// snapshot if the tables don’t have primary keys configured. </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_SurrogateKeys")]
        public System.String[] DatabaseSourceConfiguration_SurrogateKey { get; set; }
        #endregion
        
        #region Parameter SnowflakeDestinationConfiguration_Table
        /// <summary>
        /// <para>
        /// <para>All data in Snowflake is stored in database tables, logically structured as collections
        /// of columns and rows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_Table { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags to assign to the Firehose stream. A tag is a key-value pair that you
        /// can define and assign to Amazon Web Services resources. Tags are metadata. For example,
        /// you can add friendly names and descriptions or other types of information that can
        /// help you distinguish the Firehose stream. For more information about tags, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/cost-alloc-tags.html">Using
        /// Cost Allocation Tags</a> in the Amazon Web Services Billing and Cost Management User
        /// Guide.</para><para>You can specify up to 50 tags when creating a Firehose stream.</para><para>If you specify tags in the <c>CreateDeliveryStream</c> action, Amazon Data Firehose
        /// performs an additional authorization on the <c>firehose:TagDeliveryStream</c> action
        /// to verify if users have permissions to create tags. If you do not provide this permission,
        /// requests to create new Firehose streams with IAM resource tags will fail with an <c>AccessDeniedException</c>
        /// such as following.</para><para><b>AccessDeniedException</b></para><para>User: arn:aws:sts::x:assumed-role/x/x is not authorized to perform: firehose:TagDeliveryStream
        /// on resource: arn:aws:firehose:us-east-1:x:deliverystream/x with an explicit deny in
        /// an identity-based policy.</para><para>For an example IAM policy, see <a href="https://docs.aws.amazon.com/firehose/latest/APIReference/API_CreateDeliveryStream.html#API_CreateDeliveryStream_Examples">Tag
        /// example.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KinesisFirehose.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DirectPutSourceConfiguration_ThroughputHintInMBs
        /// <summary>
        /// <para>
        /// <para> The value that you configure for this parameter is for information purpose only and
        /// does not affect Firehose delivery throughput limit. You can use the <a href="https://support.console.aws.amazon.com/support/home#/case/create%3FissueType=service-limit-increase%26limitType=kinesis-firehose-limits">Firehose
        /// Limits form</a> to request a throughput limit increase. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DirectPutSourceConfiguration_ThroughputHintInMBs { get; set; }
        #endregion
        
        #region Parameter MSKSourceConfiguration_TopicName
        /// <summary>
        /// <para>
        /// <para>The topic name within the Amazon MSK cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MSKSourceConfiguration_TopicName { get; set; }
        #endregion
        
        #region Parameter DatabaseSourceConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of database engine. This can be one of the following values. </para><ul><li><para>MySQL</para></li><li><para>PostgreSQL</para></li></ul><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DatabaseType")]
        public Amazon.KinesisFirehose.DatabaseType DatabaseSourceConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter AmazonopensearchserviceDestinationConfiguration_TypeName
        /// <summary>
        /// <para>
        /// <para>The Amazon OpenSearch Service type name. For Elasticsearch 6.x, there can be only
        /// one type per index. If you try to specify a new type for an existing index that already
        /// has another type, Firehose returns an error during run time. </para>
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
        /// type, Firehose returns an error during run time.</para><para>For Elasticsearch 7.x, don't specify a <c>TypeName</c>.</para>
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
        
        #region Parameter SnowflakeDestinationConfiguration_User
        /// <summary>
        /// <para>
        /// <para>User login name for the Snowflake account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnowflakeDestinationConfiguration_User { get; set; }
        #endregion
        
        #region Parameter DatabaseSourceVPCConfiguration_VpcEndpointServiceName
        /// <summary>
        /// <para>
        /// <para> The VPC endpoint service name which Firehose uses to create a PrivateLink to the
        /// database. The endpoint service must have the Firehose service principle <c>firehose.amazonaws.com</c>
        /// as an allowed principal on the VPC endpoint service. The VPC endpoint service name
        /// is a string that looks like <c>com.amazonaws.vpce.&lt;region&gt;.&lt;vpc-endpoint-service-id&gt;</c>.
        /// </para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatabaseSourceConfiguration_DatabaseSourceVPCConfiguration_VpcEndpointServiceName")]
        public System.String DatabaseSourceVPCConfiguration_VpcEndpointServiceName { get; set; }
        #endregion
        
        #region Parameter CatalogConfiguration_WarehouseLocation
        /// <summary>
        /// <para>
        /// <para>The warehouse location for Apache Iceberg tables. You must configure this when schema
        /// evolution and table creation is enabled.</para><para>Amazon Data Firehose is in preview release and is subject to change.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IcebergDestinationConfiguration_CatalogConfiguration_WarehouseLocation")]
        public System.String CatalogConfiguration_WarehouseLocation { get; set; }
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
            this._AWSSignerType = "v4";
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
            context.AmazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat = this.AmazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat;
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
            if (this.Columns_Exclude != null)
            {
                context.Columns_Exclude = new List<System.String>(this.Columns_Exclude);
            }
            if (this.Columns_Include != null)
            {
                context.Columns_Include = new List<System.String>(this.Columns_Include);
            }
            if (this.Databases_Exclude != null)
            {
                context.Databases_Exclude = new List<System.String>(this.Databases_Exclude);
            }
            if (this.Databases_Include != null)
            {
                context.Databases_Include = new List<System.String>(this.Databases_Include);
            }
            context.SecretsManagerConfiguration_Enabled = this.SecretsManagerConfiguration_Enabled;
            context.SecretsManagerConfiguration_RoleARN = this.SecretsManagerConfiguration_RoleARN;
            context.SecretsManagerConfiguration_SecretARN = this.SecretsManagerConfiguration_SecretARN;
            context.DatabaseSourceVPCConfiguration_VpcEndpointServiceName = this.DatabaseSourceVPCConfiguration_VpcEndpointServiceName;
            context.DatabaseSourceConfiguration_Endpoint = this.DatabaseSourceConfiguration_Endpoint;
            context.DatabaseSourceConfiguration_Port = this.DatabaseSourceConfiguration_Port;
            context.DatabaseSourceConfiguration_SnapshotWatermarkTable = this.DatabaseSourceConfiguration_SnapshotWatermarkTable;
            context.DatabaseSourceConfiguration_SSLMode = this.DatabaseSourceConfiguration_SSLMode;
            if (this.DatabaseSourceConfiguration_SurrogateKey != null)
            {
                context.DatabaseSourceConfiguration_SurrogateKey = new List<System.String>(this.DatabaseSourceConfiguration_SurrogateKey);
            }
            if (this.Tables_Exclude != null)
            {
                context.Tables_Exclude = new List<System.String>(this.Tables_Exclude);
            }
            if (this.Tables_Include != null)
            {
                context.Tables_Include = new List<System.String>(this.Tables_Include);
            }
            context.DatabaseSourceConfiguration_Type = this.DatabaseSourceConfiguration_Type;
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
            context.DirectPutSourceConfiguration_ThroughputHintInMBs = this.DirectPutSourceConfiguration_ThroughputHintInMBs;
            context.BufferingHints_IntervalInSecond = this.BufferingHints_IntervalInSecond;
            context.BufferingHints_SizeInMBs = this.BufferingHints_SizeInMBs;
            context.CloudWatchLoggingOptions_Enabled = this.CloudWatchLoggingOptions_Enabled;
            context.CloudWatchLoggingOptions_LogGroupName = this.CloudWatchLoggingOptions_LogGroupName;
            context.CloudWatchLoggingOptions_LogStreamName = this.CloudWatchLoggingOptions_LogStreamName;
            context.ElasticsearchDestinationConfiguration_ClusterEndpoint = this.ElasticsearchDestinationConfiguration_ClusterEndpoint;
            context.DocumentIdOptions_DefaultDocumentIdFormat = this.DocumentIdOptions_DefaultDocumentIdFormat;
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
            context.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled = this.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled;
            context.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN = this.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN;
            context.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN = this.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN;
            context.IcebergDestinationConfiguration_AppendOnly = this.IcebergDestinationConfiguration_AppendOnly;
            context.IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds = this.IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds;
            context.IcebergDestinationConfiguration_BufferingHints_SizeInMBs = this.IcebergDestinationConfiguration_BufferingHints_SizeInMBs;
            context.CatalogConfiguration_CatalogARN = this.CatalogConfiguration_CatalogARN;
            context.CatalogConfiguration_WarehouseLocation = this.CatalogConfiguration_WarehouseLocation;
            context.IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled = this.IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled;
            context.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = this.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            context.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = this.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            if (this.IcebergDestinationConfiguration_DestinationTableConfigurationList != null)
            {
                context.IcebergDestinationConfiguration_DestinationTableConfigurationList = new List<Amazon.KinesisFirehose.Model.DestinationTableConfiguration>(this.IcebergDestinationConfiguration_DestinationTableConfigurationList);
            }
            context.IcebergDestinationConfiguration_ProcessingConfiguration_Enabled = this.IcebergDestinationConfiguration_ProcessingConfiguration_Enabled;
            if (this.IcebergDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                context.IcebergDestinationConfiguration_ProcessingConfiguration_Processors = new List<Amazon.KinesisFirehose.Model.Processor>(this.IcebergDestinationConfiguration_ProcessingConfiguration_Processors);
            }
            context.IcebergDestinationConfiguration_RetryOptions_DurationInSeconds = this.IcebergDestinationConfiguration_RetryOptions_DurationInSeconds;
            context.IcebergDestinationConfiguration_RoleARN = this.IcebergDestinationConfiguration_RoleARN;
            context.IcebergDestinationConfiguration_S3BackupMode = this.IcebergDestinationConfiguration_S3BackupMode;
            context.IcebergDestinationConfiguration_S3Configuration = this.IcebergDestinationConfiguration_S3Configuration;
            context.SchemaEvolutionConfiguration_Enabled = this.SchemaEvolutionConfiguration_Enabled;
            context.TableCreationConfiguration_Enabled = this.TableCreationConfiguration_Enabled;
            context.KinesisStreamSourceConfiguration_KinesisStreamARN = this.KinesisStreamSourceConfiguration_KinesisStreamARN;
            context.KinesisStreamSourceConfiguration_RoleARN = this.KinesisStreamSourceConfiguration_RoleARN;
            context.AuthenticationConfiguration_Connectivity = this.AuthenticationConfiguration_Connectivity;
            context.AuthenticationConfiguration_RoleARN = this.AuthenticationConfiguration_RoleARN;
            context.MSKSourceConfiguration_MSKClusterARN = this.MSKSourceConfiguration_MSKClusterARN;
            context.MSKSourceConfiguration_ReadFromTimestamp = this.MSKSourceConfiguration_ReadFromTimestamp;
            context.MSKSourceConfiguration_TopicName = this.MSKSourceConfiguration_TopicName;
            context.RedshiftDestinationConfiguration = this.RedshiftDestinationConfiguration;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3DestinationConfiguration = this.S3DestinationConfiguration;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SnowflakeDestinationConfiguration_AccountUrl = this.SnowflakeDestinationConfiguration_AccountUrl;
            context.SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds = this.SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds;
            context.SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs = this.SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs;
            context.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled = this.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled;
            context.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = this.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            context.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = this.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            context.SnowflakeDestinationConfiguration_ContentColumnName = this.SnowflakeDestinationConfiguration_ContentColumnName;
            context.SnowflakeDestinationConfiguration_Database = this.SnowflakeDestinationConfiguration_Database;
            context.SnowflakeDestinationConfiguration_DataLoadingOption = this.SnowflakeDestinationConfiguration_DataLoadingOption;
            context.SnowflakeDestinationConfiguration_KeyPassphrase = this.SnowflakeDestinationConfiguration_KeyPassphrase;
            context.SnowflakeDestinationConfiguration_MetaDataColumnName = this.SnowflakeDestinationConfiguration_MetaDataColumnName;
            context.SnowflakeDestinationConfiguration_PrivateKey = this.SnowflakeDestinationConfiguration_PrivateKey;
            context.SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled = this.SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled;
            if (this.SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                context.SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors = new List<Amazon.KinesisFirehose.Model.Processor>(this.SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors);
            }
            context.SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds = this.SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds;
            context.SnowflakeDestinationConfiguration_RoleARN = this.SnowflakeDestinationConfiguration_RoleARN;
            context.SnowflakeDestinationConfiguration_S3BackupMode = this.SnowflakeDestinationConfiguration_S3BackupMode;
            context.SnowflakeDestinationConfiguration_S3Configuration = this.SnowflakeDestinationConfiguration_S3Configuration;
            context.SnowflakeDestinationConfiguration_Schema = this.SnowflakeDestinationConfiguration_Schema;
            context.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled = this.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled;
            context.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN = this.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN;
            context.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN = this.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN;
            context.SnowflakeRoleConfiguration_Enabled = this.SnowflakeRoleConfiguration_Enabled;
            context.SnowflakeRoleConfiguration_SnowflakeRole = this.SnowflakeRoleConfiguration_SnowflakeRole;
            context.SnowflakeVpcConfiguration_PrivateLinkVpceId = this.SnowflakeVpcConfiguration_PrivateLinkVpceId;
            context.SnowflakeDestinationConfiguration_Table = this.SnowflakeDestinationConfiguration_Table;
            context.SnowflakeDestinationConfiguration_User = this.SnowflakeDestinationConfiguration_User;
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
            Amazon.KinesisFirehose.Model.DocumentIdOptions requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions = null;
            
             // populate DocumentIdOptions
            var requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptionsIsNull = true;
            requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions = new Amazon.KinesisFirehose.Model.DocumentIdOptions();
            Amazon.KinesisFirehose.DefaultDocumentIdFormat requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat = null;
            if (cmdletContext.AmazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat = cmdletContext.AmazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat != null)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions.DefaultDocumentIdFormat = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat;
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptionsIsNull = false;
            }
             // determine if requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions should be set to null
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptionsIsNull)
            {
                requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions = null;
            }
            if (requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions != null)
            {
                request.AmazonopensearchserviceDestinationConfiguration.DocumentIdOptions = requestAmazonopensearchserviceDestinationConfiguration_amazonopensearchserviceDestinationConfiguration_DocumentIdOptions;
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
            
             // populate DatabaseSourceConfiguration
            var requestDatabaseSourceConfigurationIsNull = true;
            request.DatabaseSourceConfiguration = new Amazon.KinesisFirehose.Model.DatabaseSourceConfiguration();
            System.String requestDatabaseSourceConfiguration_databaseSourceConfiguration_Endpoint = null;
            if (cmdletContext.DatabaseSourceConfiguration_Endpoint != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Endpoint = cmdletContext.DatabaseSourceConfiguration_Endpoint;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Endpoint != null)
            {
                request.DatabaseSourceConfiguration.Endpoint = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Endpoint;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            System.Int32? requestDatabaseSourceConfiguration_databaseSourceConfiguration_Port = null;
            if (cmdletContext.DatabaseSourceConfiguration_Port != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Port = cmdletContext.DatabaseSourceConfiguration_Port.Value;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Port != null)
            {
                request.DatabaseSourceConfiguration.Port = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Port.Value;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            System.String requestDatabaseSourceConfiguration_databaseSourceConfiguration_SnapshotWatermarkTable = null;
            if (cmdletContext.DatabaseSourceConfiguration_SnapshotWatermarkTable != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_SnapshotWatermarkTable = cmdletContext.DatabaseSourceConfiguration_SnapshotWatermarkTable;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_SnapshotWatermarkTable != null)
            {
                request.DatabaseSourceConfiguration.SnapshotWatermarkTable = requestDatabaseSourceConfiguration_databaseSourceConfiguration_SnapshotWatermarkTable;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.SSLMode requestDatabaseSourceConfiguration_databaseSourceConfiguration_SSLMode = null;
            if (cmdletContext.DatabaseSourceConfiguration_SSLMode != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_SSLMode = cmdletContext.DatabaseSourceConfiguration_SSLMode;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_SSLMode != null)
            {
                request.DatabaseSourceConfiguration.SSLMode = requestDatabaseSourceConfiguration_databaseSourceConfiguration_SSLMode;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            List<System.String> requestDatabaseSourceConfiguration_databaseSourceConfiguration_SurrogateKey = null;
            if (cmdletContext.DatabaseSourceConfiguration_SurrogateKey != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_SurrogateKey = cmdletContext.DatabaseSourceConfiguration_SurrogateKey;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_SurrogateKey != null)
            {
                request.DatabaseSourceConfiguration.SurrogateKeys = requestDatabaseSourceConfiguration_databaseSourceConfiguration_SurrogateKey;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.DatabaseType requestDatabaseSourceConfiguration_databaseSourceConfiguration_Type = null;
            if (cmdletContext.DatabaseSourceConfiguration_Type != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Type = cmdletContext.DatabaseSourceConfiguration_Type;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Type != null)
            {
                request.DatabaseSourceConfiguration.Type = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Type;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.DatabaseSourceAuthenticationConfiguration requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration = null;
            
             // populate DatabaseSourceAuthenticationConfiguration
            var requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfigurationIsNull = true;
            requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration = new Amazon.KinesisFirehose.Model.DatabaseSourceAuthenticationConfiguration();
            Amazon.KinesisFirehose.Model.SecretsManagerConfiguration requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration = null;
            
             // populate SecretsManagerConfiguration
            var requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfigurationIsNull = true;
            requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration = new Amazon.KinesisFirehose.Model.SecretsManagerConfiguration();
            System.Boolean? requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_Enabled = null;
            if (cmdletContext.SecretsManagerConfiguration_Enabled != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_Enabled = cmdletContext.SecretsManagerConfiguration_Enabled.Value;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_Enabled != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration.Enabled = requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_Enabled.Value;
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
            System.String requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_RoleARN = null;
            if (cmdletContext.SecretsManagerConfiguration_RoleARN != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_RoleARN = cmdletContext.SecretsManagerConfiguration_RoleARN;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_RoleARN != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration.RoleARN = requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_RoleARN;
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
            System.String requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_SecretARN = null;
            if (cmdletContext.SecretsManagerConfiguration_SecretARN != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_SecretARN = cmdletContext.SecretsManagerConfiguration_SecretARN;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_SecretARN != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration.SecretARN = requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration_secretsManagerConfiguration_SecretARN;
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
             // determine if requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration should be set to null
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfigurationIsNull)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration = null;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration.SecretsManagerConfiguration = requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration_SecretsManagerConfiguration;
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfigurationIsNull = false;
            }
             // determine if requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration should be set to null
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfigurationIsNull)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration = null;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration != null)
            {
                request.DatabaseSourceConfiguration.DatabaseSourceAuthenticationConfiguration = requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceAuthenticationConfiguration;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.DatabaseSourceVPCConfiguration requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration = null;
            
             // populate DatabaseSourceVPCConfiguration
            var requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfigurationIsNull = true;
            requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration = new Amazon.KinesisFirehose.Model.DatabaseSourceVPCConfiguration();
            System.String requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration_databaseSourceVPCConfiguration_VpcEndpointServiceName = null;
            if (cmdletContext.DatabaseSourceVPCConfiguration_VpcEndpointServiceName != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration_databaseSourceVPCConfiguration_VpcEndpointServiceName = cmdletContext.DatabaseSourceVPCConfiguration_VpcEndpointServiceName;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration_databaseSourceVPCConfiguration_VpcEndpointServiceName != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration.VpcEndpointServiceName = requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration_databaseSourceVPCConfiguration_VpcEndpointServiceName;
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfigurationIsNull = false;
            }
             // determine if requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration should be set to null
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfigurationIsNull)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration = null;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration != null)
            {
                request.DatabaseSourceConfiguration.DatabaseSourceVPCConfiguration = requestDatabaseSourceConfiguration_databaseSourceConfiguration_DatabaseSourceVPCConfiguration;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.DatabaseColumnList requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns = null;
            
             // populate Columns
            var requestDatabaseSourceConfiguration_databaseSourceConfiguration_ColumnsIsNull = true;
            requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns = new Amazon.KinesisFirehose.Model.DatabaseColumnList();
            List<System.String> requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Exclude = null;
            if (cmdletContext.Columns_Exclude != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Exclude = cmdletContext.Columns_Exclude;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Exclude != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns.Exclude = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Exclude;
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_ColumnsIsNull = false;
            }
            List<System.String> requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Include = null;
            if (cmdletContext.Columns_Include != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Include = cmdletContext.Columns_Include;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Include != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns.Include = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns_columns_Include;
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_ColumnsIsNull = false;
            }
             // determine if requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns should be set to null
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_ColumnsIsNull)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns = null;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns != null)
            {
                request.DatabaseSourceConfiguration.Columns = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Columns;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.DatabaseList requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases = null;
            
             // populate Databases
            requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases = new Amazon.KinesisFirehose.Model.DatabaseList();
            List<System.String> requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Exclude = null;
            if (cmdletContext.Databases_Exclude != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Exclude = cmdletContext.Databases_Exclude;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Exclude != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases.Exclude = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Exclude;
            }
            List<System.String> requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Include = null;
            if (cmdletContext.Databases_Include != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Include = cmdletContext.Databases_Include;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Include != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases.Include = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases_databases_Include;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases != null)
            {
                request.DatabaseSourceConfiguration.Databases = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Databases;
                requestDatabaseSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.DatabaseTableList requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables = null;
            
             // populate Tables
            requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables = new Amazon.KinesisFirehose.Model.DatabaseTableList();
            List<System.String> requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Exclude = null;
            if (cmdletContext.Tables_Exclude != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Exclude = cmdletContext.Tables_Exclude;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Exclude != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables.Exclude = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Exclude;
            }
            List<System.String> requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Include = null;
            if (cmdletContext.Tables_Include != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Include = cmdletContext.Tables_Include;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Include != null)
            {
                requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables.Include = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables_tables_Include;
            }
            if (requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables != null)
            {
                request.DatabaseSourceConfiguration.Tables = requestDatabaseSourceConfiguration_databaseSourceConfiguration_Tables;
                requestDatabaseSourceConfigurationIsNull = false;
            }
             // determine if request.DatabaseSourceConfiguration should be set to null
            if (requestDatabaseSourceConfigurationIsNull)
            {
                request.DatabaseSourceConfiguration = null;
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
            
             // populate DirectPutSourceConfiguration
            var requestDirectPutSourceConfigurationIsNull = true;
            request.DirectPutSourceConfiguration = new Amazon.KinesisFirehose.Model.DirectPutSourceConfiguration();
            System.Int32? requestDirectPutSourceConfiguration_directPutSourceConfiguration_ThroughputHintInMBs = null;
            if (cmdletContext.DirectPutSourceConfiguration_ThroughputHintInMBs != null)
            {
                requestDirectPutSourceConfiguration_directPutSourceConfiguration_ThroughputHintInMBs = cmdletContext.DirectPutSourceConfiguration_ThroughputHintInMBs.Value;
            }
            if (requestDirectPutSourceConfiguration_directPutSourceConfiguration_ThroughputHintInMBs != null)
            {
                request.DirectPutSourceConfiguration.ThroughputHintInMBs = requestDirectPutSourceConfiguration_directPutSourceConfiguration_ThroughputHintInMBs.Value;
                requestDirectPutSourceConfigurationIsNull = false;
            }
             // determine if request.DirectPutSourceConfiguration should be set to null
            if (requestDirectPutSourceConfigurationIsNull)
            {
                request.DirectPutSourceConfiguration = null;
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
            Amazon.KinesisFirehose.Model.DocumentIdOptions requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions = null;
            
             // populate DocumentIdOptions
            var requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptionsIsNull = true;
            requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions = new Amazon.KinesisFirehose.Model.DocumentIdOptions();
            Amazon.KinesisFirehose.DefaultDocumentIdFormat requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions_documentIdOptions_DefaultDocumentIdFormat = null;
            if (cmdletContext.DocumentIdOptions_DefaultDocumentIdFormat != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions_documentIdOptions_DefaultDocumentIdFormat = cmdletContext.DocumentIdOptions_DefaultDocumentIdFormat;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions_documentIdOptions_DefaultDocumentIdFormat != null)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions.DefaultDocumentIdFormat = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions_documentIdOptions_DefaultDocumentIdFormat;
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptionsIsNull = false;
            }
             // determine if requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions should be set to null
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptionsIsNull)
            {
                requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions = null;
            }
            if (requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions != null)
            {
                request.ElasticsearchDestinationConfiguration.DocumentIdOptions = requestElasticsearchDestinationConfiguration_elasticsearchDestinationConfiguration_DocumentIdOptions;
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
            Amazon.KinesisFirehose.Model.SecretsManagerConfiguration requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration = null;
            
             // populate SecretsManagerConfiguration
            var requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfigurationIsNull = true;
            requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration = new Amazon.KinesisFirehose.Model.SecretsManagerConfiguration();
            System.Boolean? requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled = cmdletContext.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled.Value;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration.Enabled = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled.Value;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN = cmdletContext.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration.RoleARN = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
            System.String requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN = null;
            if (cmdletContext.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN = cmdletContext.HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN != null)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration.SecretARN = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN;
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
             // determine if requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration should be set to null
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfigurationIsNull)
            {
                requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration = null;
            }
            if (requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration != null)
            {
                request.HttpEndpointDestinationConfiguration.SecretsManagerConfiguration = requestHttpEndpointDestinationConfiguration_httpEndpointDestinationConfiguration_SecretsManagerConfiguration;
                requestHttpEndpointDestinationConfigurationIsNull = false;
            }
             // determine if request.HttpEndpointDestinationConfiguration should be set to null
            if (requestHttpEndpointDestinationConfigurationIsNull)
            {
                request.HttpEndpointDestinationConfiguration = null;
            }
            
             // populate IcebergDestinationConfiguration
            var requestIcebergDestinationConfigurationIsNull = true;
            request.IcebergDestinationConfiguration = new Amazon.KinesisFirehose.Model.IcebergDestinationConfiguration();
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
            List<Amazon.KinesisFirehose.Model.DestinationTableConfiguration> requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableConfigurationList = null;
            if (cmdletContext.IcebergDestinationConfiguration_DestinationTableConfigurationList != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableConfigurationList = cmdletContext.IcebergDestinationConfiguration_DestinationTableConfigurationList;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableConfigurationList != null)
            {
                request.IcebergDestinationConfiguration.DestinationTableConfigurationList = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_DestinationTableConfigurationList;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RoleARN = null;
            if (cmdletContext.IcebergDestinationConfiguration_RoleARN != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RoleARN = cmdletContext.IcebergDestinationConfiguration_RoleARN;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RoleARN != null)
            {
                request.IcebergDestinationConfiguration.RoleARN = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RoleARN;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.IcebergS3BackupMode requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3BackupMode = null;
            if (cmdletContext.IcebergDestinationConfiguration_S3BackupMode != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3BackupMode = cmdletContext.IcebergDestinationConfiguration_S3BackupMode;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3BackupMode != null)
            {
                request.IcebergDestinationConfiguration.S3BackupMode = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3BackupMode;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.S3DestinationConfiguration requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3Configuration = null;
            if (cmdletContext.IcebergDestinationConfiguration_S3Configuration != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3Configuration = cmdletContext.IcebergDestinationConfiguration_S3Configuration;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3Configuration != null)
            {
                request.IcebergDestinationConfiguration.S3Configuration = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_S3Configuration;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.RetryOptions requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions = null;
            
             // populate RetryOptions
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptionsIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions = new Amazon.KinesisFirehose.Model.RetryOptions();
            System.Int32? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions_icebergDestinationConfiguration_RetryOptions_DurationInSeconds = null;
            if (cmdletContext.IcebergDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions_icebergDestinationConfiguration_RetryOptions_DurationInSeconds = cmdletContext.IcebergDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions_icebergDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions.DurationInSeconds = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions_icebergDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptionsIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptionsIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions != null)
            {
                request.IcebergDestinationConfiguration.RetryOptions = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_RetryOptions;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.SchemaEvolutionConfiguration requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration = null;
            
             // populate SchemaEvolutionConfiguration
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfigurationIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration = new Amazon.KinesisFirehose.Model.SchemaEvolutionConfiguration();
            System.Boolean? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration_schemaEvolutionConfiguration_Enabled = null;
            if (cmdletContext.SchemaEvolutionConfiguration_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration_schemaEvolutionConfiguration_Enabled = cmdletContext.SchemaEvolutionConfiguration_Enabled.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration_schemaEvolutionConfiguration_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration.Enabled = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration_schemaEvolutionConfiguration_Enabled.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfigurationIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfigurationIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration != null)
            {
                request.IcebergDestinationConfiguration.SchemaEvolutionConfiguration = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_SchemaEvolutionConfiguration;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.TableCreationConfiguration requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration = null;
            
             // populate TableCreationConfiguration
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfigurationIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration = new Amazon.KinesisFirehose.Model.TableCreationConfiguration();
            System.Boolean? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration_tableCreationConfiguration_Enabled = null;
            if (cmdletContext.TableCreationConfiguration_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration_tableCreationConfiguration_Enabled = cmdletContext.TableCreationConfiguration_Enabled.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration_tableCreationConfiguration_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration.Enabled = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration_tableCreationConfiguration_Enabled.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfigurationIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfigurationIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration != null)
            {
                request.IcebergDestinationConfiguration.TableCreationConfiguration = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_TableCreationConfiguration;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.BufferingHints requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints = null;
            
             // populate BufferingHints
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHintsIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints = new Amazon.KinesisFirehose.Model.BufferingHints();
            System.Int32? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_IntervalInSeconds = null;
            if (cmdletContext.IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_IntervalInSeconds = cmdletContext.IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints.IntervalInSeconds = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHintsIsNull = false;
            }
            System.Int32? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_SizeInMBs = null;
            if (cmdletContext.IcebergDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_SizeInMBs = cmdletContext.IcebergDestinationConfiguration_BufferingHints_SizeInMBs.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints.SizeInMBs = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints_icebergDestinationConfiguration_BufferingHints_SizeInMBs.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHintsIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHintsIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints != null)
            {
                request.IcebergDestinationConfiguration.BufferingHints = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_BufferingHints;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CatalogConfiguration requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration = null;
            
             // populate CatalogConfiguration
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration = new Amazon.KinesisFirehose.Model.CatalogConfiguration();
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_CatalogARN = null;
            if (cmdletContext.CatalogConfiguration_CatalogARN != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_CatalogARN = cmdletContext.CatalogConfiguration_CatalogARN;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_CatalogARN != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration.CatalogARN = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_CatalogARN;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_WarehouseLocation = null;
            if (cmdletContext.CatalogConfiguration_WarehouseLocation != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_WarehouseLocation = cmdletContext.CatalogConfiguration_WarehouseLocation;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_WarehouseLocation != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration.WarehouseLocation = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration_catalogConfiguration_WarehouseLocation;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration != null)
            {
                request.IcebergDestinationConfiguration.CatalogConfiguration = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CatalogConfiguration;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ProcessingConfiguration requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration = null;
            
             // populate ProcessingConfiguration
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfigurationIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Enabled = null;
            if (cmdletContext.IcebergDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Enabled = cmdletContext.IcebergDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration.Enabled = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Processors = null;
            if (cmdletContext.IcebergDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Processors = cmdletContext.IcebergDestinationConfiguration_ProcessingConfiguration_Processors;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration.Processors = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_icebergDestinationConfiguration_ProcessingConfiguration_Processors;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfigurationIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration != null)
            {
                request.IcebergDestinationConfiguration.ProcessingConfiguration = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_ProcessingConfiguration;
                requestIcebergDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions = null;
            
             // populate CloudWatchLoggingOptions
            var requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptionsIsNull = true;
            requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled = cmdletContext.IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions.Enabled = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = cmdletContext.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions.LogGroupName = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = cmdletContext.IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions.LogStreamName = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions_icebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
             // determine if requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions should be set to null
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptionsIsNull)
            {
                requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions = null;
            }
            if (requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions != null)
            {
                request.IcebergDestinationConfiguration.CloudWatchLoggingOptions = requestIcebergDestinationConfiguration_icebergDestinationConfiguration_CloudWatchLoggingOptions;
                requestIcebergDestinationConfigurationIsNull = false;
            }
             // determine if request.IcebergDestinationConfiguration should be set to null
            if (requestIcebergDestinationConfigurationIsNull)
            {
                request.IcebergDestinationConfiguration = null;
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
            
             // populate MSKSourceConfiguration
            var requestMSKSourceConfigurationIsNull = true;
            request.MSKSourceConfiguration = new Amazon.KinesisFirehose.Model.MSKSourceConfiguration();
            System.String requestMSKSourceConfiguration_mSKSourceConfiguration_MSKClusterARN = null;
            if (cmdletContext.MSKSourceConfiguration_MSKClusterARN != null)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_MSKClusterARN = cmdletContext.MSKSourceConfiguration_MSKClusterARN;
            }
            if (requestMSKSourceConfiguration_mSKSourceConfiguration_MSKClusterARN != null)
            {
                request.MSKSourceConfiguration.MSKClusterARN = requestMSKSourceConfiguration_mSKSourceConfiguration_MSKClusterARN;
                requestMSKSourceConfigurationIsNull = false;
            }
            System.DateTime? requestMSKSourceConfiguration_mSKSourceConfiguration_ReadFromTimestamp = null;
            if (cmdletContext.MSKSourceConfiguration_ReadFromTimestamp != null)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_ReadFromTimestamp = cmdletContext.MSKSourceConfiguration_ReadFromTimestamp.Value;
            }
            if (requestMSKSourceConfiguration_mSKSourceConfiguration_ReadFromTimestamp != null)
            {
                request.MSKSourceConfiguration.ReadFromTimestamp = requestMSKSourceConfiguration_mSKSourceConfiguration_ReadFromTimestamp.Value;
                requestMSKSourceConfigurationIsNull = false;
            }
            System.String requestMSKSourceConfiguration_mSKSourceConfiguration_TopicName = null;
            if (cmdletContext.MSKSourceConfiguration_TopicName != null)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_TopicName = cmdletContext.MSKSourceConfiguration_TopicName;
            }
            if (requestMSKSourceConfiguration_mSKSourceConfiguration_TopicName != null)
            {
                request.MSKSourceConfiguration.TopicName = requestMSKSourceConfiguration_mSKSourceConfiguration_TopicName;
                requestMSKSourceConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.AuthenticationConfiguration requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration = null;
            
             // populate AuthenticationConfiguration
            var requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfigurationIsNull = true;
            requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration = new Amazon.KinesisFirehose.Model.AuthenticationConfiguration();
            Amazon.KinesisFirehose.Connectivity requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_Connectivity = null;
            if (cmdletContext.AuthenticationConfiguration_Connectivity != null)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_Connectivity = cmdletContext.AuthenticationConfiguration_Connectivity;
            }
            if (requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_Connectivity != null)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration.Connectivity = requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_Connectivity;
                requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfigurationIsNull = false;
            }
            System.String requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_RoleARN = null;
            if (cmdletContext.AuthenticationConfiguration_RoleARN != null)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_RoleARN = cmdletContext.AuthenticationConfiguration_RoleARN;
            }
            if (requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_RoleARN != null)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration.RoleARN = requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_RoleARN;
                requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfigurationIsNull = false;
            }
             // determine if requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration should be set to null
            if (requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfigurationIsNull)
            {
                requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration = null;
            }
            if (requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration != null)
            {
                request.MSKSourceConfiguration.AuthenticationConfiguration = requestMSKSourceConfiguration_mSKSourceConfiguration_AuthenticationConfiguration;
                requestMSKSourceConfigurationIsNull = false;
            }
             // determine if request.MSKSourceConfiguration should be set to null
            if (requestMSKSourceConfigurationIsNull)
            {
                request.MSKSourceConfiguration = null;
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
            
             // populate SnowflakeDestinationConfiguration
            var requestSnowflakeDestinationConfigurationIsNull = true;
            request.SnowflakeDestinationConfiguration = new Amazon.KinesisFirehose.Model.SnowflakeDestinationConfiguration();
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_AccountUrl = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_AccountUrl != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_AccountUrl = cmdletContext.SnowflakeDestinationConfiguration_AccountUrl;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_AccountUrl != null)
            {
                request.SnowflakeDestinationConfiguration.AccountUrl = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_AccountUrl;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ContentColumnName = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_ContentColumnName != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ContentColumnName = cmdletContext.SnowflakeDestinationConfiguration_ContentColumnName;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ContentColumnName != null)
            {
                request.SnowflakeDestinationConfiguration.ContentColumnName = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ContentColumnName;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Database = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_Database != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Database = cmdletContext.SnowflakeDestinationConfiguration_Database;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Database != null)
            {
                request.SnowflakeDestinationConfiguration.Database = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Database;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.SnowflakeDataLoadingOption requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_DataLoadingOption = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_DataLoadingOption != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_DataLoadingOption = cmdletContext.SnowflakeDestinationConfiguration_DataLoadingOption;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_DataLoadingOption != null)
            {
                request.SnowflakeDestinationConfiguration.DataLoadingOption = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_DataLoadingOption;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_KeyPassphrase = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_KeyPassphrase != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_KeyPassphrase = cmdletContext.SnowflakeDestinationConfiguration_KeyPassphrase;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_KeyPassphrase != null)
            {
                request.SnowflakeDestinationConfiguration.KeyPassphrase = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_KeyPassphrase;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_MetaDataColumnName = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_MetaDataColumnName != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_MetaDataColumnName = cmdletContext.SnowflakeDestinationConfiguration_MetaDataColumnName;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_MetaDataColumnName != null)
            {
                request.SnowflakeDestinationConfiguration.MetaDataColumnName = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_MetaDataColumnName;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_PrivateKey = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_PrivateKey != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_PrivateKey = cmdletContext.SnowflakeDestinationConfiguration_PrivateKey;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_PrivateKey != null)
            {
                request.SnowflakeDestinationConfiguration.PrivateKey = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_PrivateKey;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RoleARN = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_RoleARN != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RoleARN = cmdletContext.SnowflakeDestinationConfiguration_RoleARN;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RoleARN != null)
            {
                request.SnowflakeDestinationConfiguration.RoleARN = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RoleARN;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.SnowflakeS3BackupMode requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3BackupMode = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_S3BackupMode != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3BackupMode = cmdletContext.SnowflakeDestinationConfiguration_S3BackupMode;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3BackupMode != null)
            {
                request.SnowflakeDestinationConfiguration.S3BackupMode = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3BackupMode;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.S3DestinationConfiguration requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3Configuration = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_S3Configuration != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3Configuration = cmdletContext.SnowflakeDestinationConfiguration_S3Configuration;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3Configuration != null)
            {
                request.SnowflakeDestinationConfiguration.S3Configuration = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_S3Configuration;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Schema = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_Schema != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Schema = cmdletContext.SnowflakeDestinationConfiguration_Schema;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Schema != null)
            {
                request.SnowflakeDestinationConfiguration.Schema = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Schema;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Table = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_Table != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Table = cmdletContext.SnowflakeDestinationConfiguration_Table;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Table != null)
            {
                request.SnowflakeDestinationConfiguration.Table = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_Table;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_User = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_User != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_User = cmdletContext.SnowflakeDestinationConfiguration_User;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_User != null)
            {
                request.SnowflakeDestinationConfiguration.User = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_User;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.SnowflakeRetryOptions requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions = null;
            
             // populate RetryOptions
            var requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptionsIsNull = true;
            requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions = new Amazon.KinesisFirehose.Model.SnowflakeRetryOptions();
            System.Int32? requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions_snowflakeDestinationConfiguration_RetryOptions_DurationInSeconds = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions_snowflakeDestinationConfiguration_RetryOptions_DurationInSeconds = cmdletContext.SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions_snowflakeDestinationConfiguration_RetryOptions_DurationInSeconds != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions.DurationInSeconds = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions_snowflakeDestinationConfiguration_RetryOptions_DurationInSeconds.Value;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptionsIsNull = false;
            }
             // determine if requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions should be set to null
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptionsIsNull)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions = null;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions != null)
            {
                request.SnowflakeDestinationConfiguration.RetryOptions = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_RetryOptions;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.SnowflakeVpcConfiguration requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration = null;
            
             // populate SnowflakeVpcConfiguration
            var requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfigurationIsNull = true;
            requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration = new Amazon.KinesisFirehose.Model.SnowflakeVpcConfiguration();
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration_snowflakeVpcConfiguration_PrivateLinkVpceId = null;
            if (cmdletContext.SnowflakeVpcConfiguration_PrivateLinkVpceId != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration_snowflakeVpcConfiguration_PrivateLinkVpceId = cmdletContext.SnowflakeVpcConfiguration_PrivateLinkVpceId;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration_snowflakeVpcConfiguration_PrivateLinkVpceId != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration.PrivateLinkVpceId = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration_snowflakeVpcConfiguration_PrivateLinkVpceId;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfigurationIsNull = false;
            }
             // determine if requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration should be set to null
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfigurationIsNull)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration = null;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration != null)
            {
                request.SnowflakeDestinationConfiguration.SnowflakeVpcConfiguration = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeVpcConfiguration;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.SnowflakeBufferingHints requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints = null;
            
             // populate BufferingHints
            var requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHintsIsNull = true;
            requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints = new Amazon.KinesisFirehose.Model.SnowflakeBufferingHints();
            System.Int32? requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds = cmdletContext.SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints.IntervalInSeconds = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds.Value;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHintsIsNull = false;
            }
            System.Int32? requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_SizeInMBs = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_SizeInMBs = cmdletContext.SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs.Value;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_SizeInMBs != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints.SizeInMBs = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints_snowflakeDestinationConfiguration_BufferingHints_SizeInMBs.Value;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHintsIsNull = false;
            }
             // determine if requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints should be set to null
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHintsIsNull)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints = null;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints != null)
            {
                request.SnowflakeDestinationConfiguration.BufferingHints = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_BufferingHints;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.ProcessingConfiguration requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration = null;
            
             // populate ProcessingConfiguration
            var requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfigurationIsNull = true;
            requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration = new Amazon.KinesisFirehose.Model.ProcessingConfiguration();
            System.Boolean? requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Enabled = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Enabled = cmdletContext.SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration.Enabled = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Enabled.Value;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
            List<Amazon.KinesisFirehose.Model.Processor> requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Processors = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Processors = cmdletContext.SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Processors != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration.Processors = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration_Processors;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfigurationIsNull = false;
            }
             // determine if requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration should be set to null
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfigurationIsNull)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration = null;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration != null)
            {
                request.SnowflakeDestinationConfiguration.ProcessingConfiguration = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_ProcessingConfiguration;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.SnowflakeRoleConfiguration requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration = null;
            
             // populate SnowflakeRoleConfiguration
            var requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfigurationIsNull = true;
            requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration = new Amazon.KinesisFirehose.Model.SnowflakeRoleConfiguration();
            System.Boolean? requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_Enabled = null;
            if (cmdletContext.SnowflakeRoleConfiguration_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_Enabled = cmdletContext.SnowflakeRoleConfiguration_Enabled.Value;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration.Enabled = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_Enabled.Value;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_SnowflakeRole = null;
            if (cmdletContext.SnowflakeRoleConfiguration_SnowflakeRole != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_SnowflakeRole = cmdletContext.SnowflakeRoleConfiguration_SnowflakeRole;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_SnowflakeRole != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration.SnowflakeRole = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration_snowflakeRoleConfiguration_SnowflakeRole;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfigurationIsNull = false;
            }
             // determine if requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration should be set to null
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfigurationIsNull)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration = null;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration != null)
            {
                request.SnowflakeDestinationConfiguration.SnowflakeRoleConfiguration = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SnowflakeRoleConfiguration;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions = null;
            
             // populate CloudWatchLoggingOptions
            var requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptionsIsNull = true;
            requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions = new Amazon.KinesisFirehose.Model.CloudWatchLoggingOptions();
            System.Boolean? requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled = cmdletContext.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions.Enabled = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled.Value;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName = cmdletContext.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions.LogGroupName = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName = cmdletContext.SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions.LogStreamName = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_snowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptionsIsNull = false;
            }
             // determine if requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions should be set to null
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptionsIsNull)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions = null;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions != null)
            {
                request.SnowflakeDestinationConfiguration.CloudWatchLoggingOptions = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_CloudWatchLoggingOptions;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
            Amazon.KinesisFirehose.Model.SecretsManagerConfiguration requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration = null;
            
             // populate SecretsManagerConfiguration
            var requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfigurationIsNull = true;
            requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration = new Amazon.KinesisFirehose.Model.SecretsManagerConfiguration();
            System.Boolean? requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled = cmdletContext.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled.Value;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration.Enabled = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled.Value;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN = cmdletContext.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration.RoleARN = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
            System.String requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN = null;
            if (cmdletContext.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN = cmdletContext.SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN != null)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration.SecretARN = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN;
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfigurationIsNull = false;
            }
             // determine if requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration should be set to null
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfigurationIsNull)
            {
                requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration = null;
            }
            if (requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration != null)
            {
                request.SnowflakeDestinationConfiguration.SecretsManagerConfiguration = requestSnowflakeDestinationConfiguration_snowflakeDestinationConfiguration_SecretsManagerConfiguration;
                requestSnowflakeDestinationConfigurationIsNull = false;
            }
             // determine if request.SnowflakeDestinationConfiguration should be set to null
            if (requestSnowflakeDestinationConfigurationIsNull)
            {
                request.SnowflakeDestinationConfiguration = null;
            }
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
            public Amazon.KinesisFirehose.DefaultDocumentIdFormat AmazonopensearchserviceDestinationConfiguration_DocumentIdOptions_DefaultDocumentIdFormat { get; set; }
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
            public List<System.String> Columns_Exclude { get; set; }
            public List<System.String> Columns_Include { get; set; }
            public List<System.String> Databases_Exclude { get; set; }
            public List<System.String> Databases_Include { get; set; }
            public System.Boolean? SecretsManagerConfiguration_Enabled { get; set; }
            public System.String SecretsManagerConfiguration_RoleARN { get; set; }
            public System.String SecretsManagerConfiguration_SecretARN { get; set; }
            public System.String DatabaseSourceVPCConfiguration_VpcEndpointServiceName { get; set; }
            public System.String DatabaseSourceConfiguration_Endpoint { get; set; }
            public System.Int32? DatabaseSourceConfiguration_Port { get; set; }
            public System.String DatabaseSourceConfiguration_SnapshotWatermarkTable { get; set; }
            public Amazon.KinesisFirehose.SSLMode DatabaseSourceConfiguration_SSLMode { get; set; }
            public List<System.String> DatabaseSourceConfiguration_SurrogateKey { get; set; }
            public List<System.String> Tables_Exclude { get; set; }
            public List<System.String> Tables_Include { get; set; }
            public Amazon.KinesisFirehose.DatabaseType DatabaseSourceConfiguration_Type { get; set; }
            public System.String DeliveryStreamEncryptionConfigurationInput_KeyARN { get; set; }
            public Amazon.KinesisFirehose.KeyType DeliveryStreamEncryptionConfigurationInput_KeyType { get; set; }
            public System.String DeliveryStreamName { get; set; }
            public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
            public System.Int32? DirectPutSourceConfiguration_ThroughputHintInMBs { get; set; }
            public System.Int32? BufferingHints_IntervalInSecond { get; set; }
            public System.Int32? BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String ElasticsearchDestinationConfiguration_ClusterEndpoint { get; set; }
            public Amazon.KinesisFirehose.DefaultDocumentIdFormat DocumentIdOptions_DefaultDocumentIdFormat { get; set; }
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
            public System.Boolean? HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_Enabled { get; set; }
            public System.String HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_RoleARN { get; set; }
            public System.String HttpEndpointDestinationConfiguration_SecretsManagerConfiguration_SecretARN { get; set; }
            public System.Boolean? IcebergDestinationConfiguration_AppendOnly { get; set; }
            public System.Int32? IcebergDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
            public System.Int32? IcebergDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
            public System.String CatalogConfiguration_CatalogARN { get; set; }
            public System.String CatalogConfiguration_WarehouseLocation { get; set; }
            public System.Boolean? IcebergDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String IcebergDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
            public List<Amazon.KinesisFirehose.Model.DestinationTableConfiguration> IcebergDestinationConfiguration_DestinationTableConfigurationList { get; set; }
            public System.Boolean? IcebergDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> IcebergDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
            public System.Int32? IcebergDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
            public System.String IcebergDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.IcebergS3BackupMode IcebergDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration IcebergDestinationConfiguration_S3Configuration { get; set; }
            public System.Boolean? SchemaEvolutionConfiguration_Enabled { get; set; }
            public System.Boolean? TableCreationConfiguration_Enabled { get; set; }
            public System.String KinesisStreamSourceConfiguration_KinesisStreamARN { get; set; }
            public System.String KinesisStreamSourceConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.Connectivity AuthenticationConfiguration_Connectivity { get; set; }
            public System.String AuthenticationConfiguration_RoleARN { get; set; }
            public System.String MSKSourceConfiguration_MSKClusterARN { get; set; }
            public System.DateTime? MSKSourceConfiguration_ReadFromTimestamp { get; set; }
            public System.String MSKSourceConfiguration_TopicName { get; set; }
            public Amazon.KinesisFirehose.Model.RedshiftDestinationConfiguration RedshiftDestinationConfiguration { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration S3DestinationConfiguration { get; set; }
            public System.String SnowflakeDestinationConfiguration_AccountUrl { get; set; }
            public System.Int32? SnowflakeDestinationConfiguration_BufferingHints_IntervalInSeconds { get; set; }
            public System.Int32? SnowflakeDestinationConfiguration_BufferingHints_SizeInMBs { get; set; }
            public System.Boolean? SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_Enabled { get; set; }
            public System.String SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogGroupName { get; set; }
            public System.String SnowflakeDestinationConfiguration_CloudWatchLoggingOptions_LogStreamName { get; set; }
            public System.String SnowflakeDestinationConfiguration_ContentColumnName { get; set; }
            public System.String SnowflakeDestinationConfiguration_Database { get; set; }
            public Amazon.KinesisFirehose.SnowflakeDataLoadingOption SnowflakeDestinationConfiguration_DataLoadingOption { get; set; }
            public System.String SnowflakeDestinationConfiguration_KeyPassphrase { get; set; }
            public System.String SnowflakeDestinationConfiguration_MetaDataColumnName { get; set; }
            public System.String SnowflakeDestinationConfiguration_PrivateKey { get; set; }
            public System.Boolean? SnowflakeDestinationConfiguration_ProcessingConfiguration_Enabled { get; set; }
            public List<Amazon.KinesisFirehose.Model.Processor> SnowflakeDestinationConfiguration_ProcessingConfiguration_Processors { get; set; }
            public System.Int32? SnowflakeDestinationConfiguration_RetryOptions_DurationInSeconds { get; set; }
            public System.String SnowflakeDestinationConfiguration_RoleARN { get; set; }
            public Amazon.KinesisFirehose.SnowflakeS3BackupMode SnowflakeDestinationConfiguration_S3BackupMode { get; set; }
            public Amazon.KinesisFirehose.Model.S3DestinationConfiguration SnowflakeDestinationConfiguration_S3Configuration { get; set; }
            public System.String SnowflakeDestinationConfiguration_Schema { get; set; }
            public System.Boolean? SnowflakeDestinationConfiguration_SecretsManagerConfiguration_Enabled { get; set; }
            public System.String SnowflakeDestinationConfiguration_SecretsManagerConfiguration_RoleARN { get; set; }
            public System.String SnowflakeDestinationConfiguration_SecretsManagerConfiguration_SecretARN { get; set; }
            public System.Boolean? SnowflakeRoleConfiguration_Enabled { get; set; }
            public System.String SnowflakeRoleConfiguration_SnowflakeRole { get; set; }
            public System.String SnowflakeVpcConfiguration_PrivateLinkVpceId { get; set; }
            public System.String SnowflakeDestinationConfiguration_Table { get; set; }
            public System.String SnowflakeDestinationConfiguration_User { get; set; }
            public Amazon.KinesisFirehose.Model.SplunkDestinationConfiguration SplunkDestinationConfiguration { get; set; }
            public List<Amazon.KinesisFirehose.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.CreateDeliveryStreamResponse, NewKINFDeliveryStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeliveryStreamARN;
        }
        
    }
}
