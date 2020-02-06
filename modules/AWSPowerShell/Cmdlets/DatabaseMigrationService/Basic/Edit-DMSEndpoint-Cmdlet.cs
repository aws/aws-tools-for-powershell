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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Modifies the specified endpoint.
    /// </summary>
    [Cmdlet("Edit", "DMSEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.Endpoint")]
    [AWSCmdlet("Calls the AWS Database Migration Service ModifyEndpoint API operation.", Operation = new[] {"ModifyEndpoint"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.Endpoint or Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.Endpoint object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditDMSEndpointCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter RedshiftSettings_AcceptAnyDate
        /// <summary>
        /// <para>
        /// <para>A value that indicates to allow any date format, including invalid formats such as
        /// 00/00/00 00:00:00, to be loaded without generating an error. You can choose <code>true</code>
        /// or <code>false</code> (the default).</para><para>This parameter applies only to TIMESTAMP and DATE columns. Always use ACCEPTANYDATE
        /// with the DATEFORMAT parameter. If the date format for the data doesn't match the DATEFORMAT
        /// specification, Amazon Redshift inserts a NULL value into that field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RedshiftSettings_AcceptAnyDate { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_AfterConnectScript
        /// <summary>
        /// <para>
        /// <para>Code to run after connecting. This parameter should contain the code itself, not the
        /// name of a file containing the code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_AfterConnectScript { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthMechanism
        /// <summary>
        /// <para>
        /// <para> The authentication mechanism you use to access the MongoDB source endpoint.</para><para>Valid values: DEFAULT, MONGODB_CR, SCRAM_SHA_1 </para><para>DEFAULT – For MongoDB version 2.x, use MONGODB_CR. For MongoDB version 3.x, use SCRAM_SHA_1.
        /// This setting isn't used when authType=No.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.AuthMechanismValue")]
        public Amazon.DatabaseMigrationService.AuthMechanismValue MongoDbSettings_AuthMechanism { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthSource
        /// <summary>
        /// <para>
        /// <para> The MongoDB database name. This setting isn't used when <code>authType=NO</code>.
        /// </para><para>The default is admin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_AuthSource { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthType
        /// <summary>
        /// <para>
        /// <para> The authentication type you use to access the MongoDB source endpoint.</para><para>Valid values: NO, PASSWORD </para><para>When NO is selected, user name and password parameters are not used and can be empty.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.AuthTypeValue")]
        public Amazon.DatabaseMigrationService.AuthTypeValue MongoDbSettings_AuthType { get; set; }
        #endregion
        
        #region Parameter KafkaSettings_Broker
        /// <summary>
        /// <para>
        /// <para>The broker location and port of the Kafka broker that hosts your Kafka instance. Specify
        /// the broker in the form <code><i>broker-hostname-or-ip</i>:<i>port</i></code>. For
        /// example, <code>"ec2-12-345-678-901.compute-1.amazonaws.com:2345"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KafkaSettings_Broker { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_BucketFolder
        /// <summary>
        /// <para>
        /// <para>The location where the comma-separated value (.csv) files are stored before being
        /// uploaded to the S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_BucketFolder { get; set; }
        #endregion
        
        #region Parameter S3Settings_BucketFolder
        /// <summary>
        /// <para>
        /// <para> An optional parameter to set a folder name in the S3 bucket. If provided, tables
        /// are created in the path <code><i>bucketFolder</i>/<i>schema_name</i>/<i>table_name</i>/</code>.
        /// If this parameter isn't specified, then the path used is <code><i>schema_name</i>/<i>table_name</i>/</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_BucketFolder { get; set; }
        #endregion
        
        #region Parameter DmsTransferSettings_BucketName
        /// <summary>
        /// <para>
        /// <para> The name of the S3 bucket to use. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DmsTransferSettings_BucketName { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket you want to use</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Settings_BucketName
        /// <summary>
        /// <para>
        /// <para> The name of the S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Settings_CdcInsertsAndUpdate
        /// <summary>
        /// <para>
        /// <para>A value that enables a change data capture (CDC) load to write INSERT and UPDATE operations
        /// to .csv or .parquet (columnar storage) output files. The default setting is <code>false</code>,
        /// but when <code>CdcInsertsAndUpdates</code> is set to <code>true</code>or <code>y</code>,
        /// INSERTs and UPDATEs from the source database are migrated to the .csv or .parquet
        /// file. </para><para>For .csv file format only, how these INSERTs and UPDATEs are recorded depends on the
        /// value of the <code>IncludeOpForFullLoad</code> parameter. If <code>IncludeOpForFullLoad</code>
        /// is set to <code>true</code>, the first field of every CDC record is set to either
        /// <code>I</code> or <code>U</code> to indicate INSERT and UPDATE operations at the source.
        /// But if <code>IncludeOpForFullLoad</code> is set to <code>false</code>, CDC records
        /// are written without an indication of INSERT or UPDATE operations at the source. For
        /// more information about how these settings work together, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Target.S3.html#CHAP_Target.S3.Configuring.InsertOps">Indicating
        /// Source DB Operations in Migrated S3 Data</a> in the <i>AWS Database Migration Service
        /// User Guide.</i>.</para><note><para>AWS DMS supports the use of the <code>CdcInsertsAndUpdates</code> parameter in versions
        /// 3.3.1 and later.</para><para><code>CdcInsertsOnly</code> and <code>CdcInsertsAndUpdates</code> can't both be set
        /// to <code>true</code> for the same endpoint. Set either <code>CdcInsertsOnly</code>
        /// or <code>CdcInsertsAndUpdates</code> to <code>true</code> for the same endpoint, but
        /// not both.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3Settings_CdcInsertsAndUpdates")]
        public System.Boolean? S3Settings_CdcInsertsAndUpdate { get; set; }
        #endregion
        
        #region Parameter S3Settings_CdcInsertsOnly
        /// <summary>
        /// <para>
        /// <para>A value that enables a change data capture (CDC) load to write only INSERT operations
        /// to .csv or columnar storage (.parquet) output files. By default (the <code>false</code>
        /// setting), the first field in a .csv or .parquet record contains the letter I (INSERT),
        /// U (UPDATE), or D (DELETE). These values indicate whether the row was inserted, updated,
        /// or deleted at the source database for a CDC load to the target.</para><para>If <code>CdcInsertsOnly</code> is set to <code>true</code> or <code>y</code>, only
        /// INSERTs from the source database are migrated to the .csv or .parquet file. For .csv
        /// format only, how these INSERTs are recorded depends on the value of <code>IncludeOpForFullLoad</code>.
        /// If <code>IncludeOpForFullLoad</code> is set to <code>true</code>, the first field
        /// of every CDC record is set to I to indicate the INSERT operation at the source. If
        /// <code>IncludeOpForFullLoad</code> is set to <code>false</code>, every CDC record is
        /// written without a first field to indicate the INSERT operation at the source. For
        /// more information about how these settings work together, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Target.S3.html#CHAP_Target.S3.Configuring.InsertOps">Indicating
        /// Source DB Operations in Migrated S3 Data</a> in the <i>AWS Database Migration Service
        /// User Guide.</i>.</para><note><para>AWS DMS supports the interaction described preceding between the <code>CdcInsertsOnly</code>
        /// and <code>IncludeOpForFullLoad</code> parameters in versions 3.1.4 and later. </para><para><code>CdcInsertsOnly</code> and <code>CdcInsertsAndUpdates</code> can't both be set
        /// to <code>true</code> for the same endpoint. Set either <code>CdcInsertsOnly</code>
        /// or <code>CdcInsertsAndUpdates</code> to <code>true</code> for the same endpoint, but
        /// not both.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? S3Settings_CdcInsertsOnly { get; set; }
        #endregion
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate used for SSL connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter S3Settings_CompressionType
        /// <summary>
        /// <para>
        /// <para>An optional parameter to use GZIP to compress the target files. Set to GZIP to compress
        /// the target files. Either set this parameter to NONE (the default) or don't use it
        /// to leave the files uncompressed. This parameter applies to both .csv and .parquet
        /// file formats. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.CompressionTypeValue")]
        public Amazon.DatabaseMigrationService.CompressionTypeValue S3Settings_CompressionType { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_ConnectionTimeout
        /// <summary>
        /// <para>
        /// <para>A value that sets the amount of time to wait (in milliseconds) before timing out,
        /// beginning from when you initially establish a connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RedshiftSettings_ConnectionTimeout { get; set; }
        #endregion
        
        #region Parameter S3Settings_CsvDelimiter
        /// <summary>
        /// <para>
        /// <para> The delimiter used to separate columns in the source files. The default is a comma.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_CsvDelimiter { get; set; }
        #endregion
        
        #region Parameter S3Settings_CsvRowDelimiter
        /// <summary>
        /// <para>
        /// <para> The delimiter used to separate rows in the source files. The default is a carriage
        /// return (<code>\n</code>). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_CsvRowDelimiter { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para> The database name on the MongoDB source endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Redshift data warehouse (service) that you are working with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter S3Settings_DataFormat
        /// <summary>
        /// <para>
        /// <para>The format of the data that you want to use for output. You can choose one of the
        /// following: </para><ul><li><para><code>csv</code> : This is a row-based file format with comma-separated values (.csv).
        /// </para></li><li><para><code>parquet</code> : Apache Parquet (.parquet) is a columnar storage file format
        /// that features efficient compression and provides faster query response. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DataFormatValue")]
        public Amazon.DatabaseMigrationService.DataFormatValue S3Settings_DataFormat { get; set; }
        #endregion
        
        #region Parameter S3Settings_DataPageSize
        /// <summary>
        /// <para>
        /// <para>The size of one data page in bytes. This parameter defaults to 1024 * 1024 bytes (1
        /// MiB). This number is used for .parquet file format only. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? S3Settings_DataPageSize { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_DateFormat
        /// <summary>
        /// <para>
        /// <para>The date format that you are using. Valid values are <code>auto</code> (case-sensitive),
        /// your date format string enclosed in quotes, or NULL. If this parameter is left unset
        /// (NULL), it defaults to a format of 'YYYY-MM-DD'. Using <code>auto</code> recognizes
        /// most strings, even some that aren't supported when you use a date format string. </para><para>If your date and time values use formats different from each other, set this to <code>auto</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_DateFormat { get; set; }
        #endregion
        
        #region Parameter S3Settings_DictPageSizeLimit
        /// <summary>
        /// <para>
        /// <para>The maximum size of an encoded dictionary page of a column. If the dictionary page
        /// exceeds this, this column is stored using an encoding type of <code>PLAIN</code>.
        /// This parameter defaults to 1024 * 1024 bytes (1 MiB), the maximum size of a dictionary
        /// page before it reverts to <code>PLAIN</code> encoding. This size is used for .parquet
        /// file format only. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? S3Settings_DictPageSizeLimit { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_DocsToInvestigate
        /// <summary>
        /// <para>
        /// <para> Indicates the number of documents to preview to determine the document organization.
        /// Use this setting when <code>NestingLevel</code> is set to ONE. </para><para>Must be a positive value greater than 0. Default value is 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_DocsToInvestigate { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_EmptyAsNull
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether AWS DMS should migrate empty CHAR and VARCHAR fields
        /// as NULL. A value of <code>true</code> sets empty CHAR and VARCHAR fields to null.
        /// The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RedshiftSettings_EmptyAsNull { get; set; }
        #endregion
        
        #region Parameter S3Settings_EnableStatistic
        /// <summary>
        /// <para>
        /// <para>A value that enables statistics for Parquet pages and row groups. Choose <code>true</code>
        /// to enable statistics, <code>false</code> to disable. Statistics include <code>NULL</code>,
        /// <code>DISTINCT</code>, <code>MAX</code>, and <code>MIN</code> values. This parameter
        /// defaults to <code>true</code>. This value is used for .parquet file format only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3Settings_EnableStatistics")]
        public System.Boolean? S3Settings_EnableStatistic { get; set; }
        #endregion
        
        #region Parameter S3Settings_EncodingType
        /// <summary>
        /// <para>
        /// <para>The type of encoding you are using: </para><ul><li><para><code>RLE_DICTIONARY</code> uses a combination of bit-packing and run-length encoding
        /// to store repeated values more efficiently. This is the default.</para></li><li><para><code>PLAIN</code> doesn't use encoding at all. Values are stored as they are.</para></li><li><para><code>PLAIN_DICTIONARY</code> builds a dictionary of the values encountered in a
        /// given column. The dictionary is stored in a dictionary page for each column chunk.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.EncodingTypeValue")]
        public Amazon.DatabaseMigrationService.EncodingTypeValue S3Settings_EncodingType { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_EncryptionMode
        /// <summary>
        /// <para>
        /// <para>The type of server-side encryption that you want to use for your data. This encryption
        /// type is part of the endpoint settings or the extra connections attributes for Amazon
        /// S3. You can choose either <code>SSE_S3</code> (the default) or <code>SSE_KMS</code>.
        /// To use <code>SSE_S3</code>, create an AWS Identity and Access Management (IAM) role
        /// with a policy that allows <code>"arn:aws:s3:::*"</code> to use the following actions:
        /// <code>"s3:PutObject", "s3:ListBucket"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.EncryptionModeValue")]
        public Amazon.DatabaseMigrationService.EncryptionModeValue RedshiftSettings_EncryptionMode { get; set; }
        #endregion
        
        #region Parameter S3Settings_EncryptionMode
        /// <summary>
        /// <para>
        /// <para>The type of server-side encryption that you want to use for your data. This encryption
        /// type is part of the endpoint settings or the extra connections attributes for Amazon
        /// S3. You can choose either <code>SSE_S3</code> (the default) or <code>SSE_KMS</code>.
        /// To use <code>SSE_S3</code>, you need an AWS Identity and Access Management (IAM) role
        /// with permission to allow <code>"arn:aws:s3:::dms-*"</code> to use the following actions:</para><ul><li><para><code>s3:CreateBucket</code></para></li><li><para><code>s3:ListBucket</code></para></li><li><para><code>s3:DeleteBucket</code></para></li><li><para><code>s3:GetBucketLocation</code></para></li><li><para><code>s3:GetObject</code></para></li><li><para><code>s3:PutObject</code></para></li><li><para><code>s3:DeleteObject</code></para></li><li><para><code>s3:GetObjectVersion</code></para></li><li><para><code>s3:GetBucketPolicy</code></para></li><li><para><code>s3:PutBucketPolicy</code></para></li><li><para><code>s3:DeleteBucketPolicy</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.EncryptionModeValue")]
        public Amazon.DatabaseMigrationService.EncryptionModeValue S3Settings_EncryptionMode { get; set; }
        #endregion
        
        #region Parameter EndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) string that uniquely identifies the endpoint.</para>
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
        public System.String EndpointArn { get; set; }
        #endregion
        
        #region Parameter EndpointIdentifier
        /// <summary>
        /// <para>
        /// <para>The database endpoint identifier. Identifiers must begin with a letter and must contain
        /// only ASCII letters, digits, and hyphens. They can't end with a hyphen or contain two
        /// consecutive hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointIdentifier { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint. Valid values are <code>source</code> and <code>target</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue")]
        public Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue EndpointType { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_EndpointUri
        /// <summary>
        /// <para>
        /// <para>The endpoint for the Elasticsearch cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchSettings_EndpointUri { get; set; }
        #endregion
        
        #region Parameter EngineName
        /// <summary>
        /// <para>
        /// <para>The type of engine for the endpoint. Valid values, depending on the EndpointType,
        /// include <code>"mysql"</code>, <code>"oracle"</code>, <code>"postgres"</code>, <code>"mariadb"</code>,
        /// <code>"aurora"</code>, <code>"aurora-postgresql"</code>, <code>"redshift"</code>,
        /// <code>"s3"</code>, <code>"db2"</code>, <code>"azuredb"</code>, <code>"sybase"</code>,
        /// <code>"dynamodb"</code>, <code>"mongodb"</code>, <code>"kinesis"</code>, <code>"kafka"</code>,
        /// <code>"elasticsearch"</code>, <code>"documentdb"</code>, and <code>"sqlserver"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_ErrorRetryDuration
        /// <summary>
        /// <para>
        /// <para>The maximum number of seconds for which DMS retries failed API requests to the Elasticsearch
        /// cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ElasticsearchSettings_ErrorRetryDuration { get; set; }
        #endregion
        
        #region Parameter ExternalTableDefinition
        /// <summary>
        /// <para>
        /// <para>The external table definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalTableDefinition { get; set; }
        #endregion
        
        #region Parameter S3Settings_ExternalTableDefinition
        /// <summary>
        /// <para>
        /// <para> The external table definition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_ExternalTableDefinition { get; set; }
        #endregion
        
        #region Parameter ExtraConnectionAttribute
        /// <summary>
        /// <para>
        /// <para>Additional attributes associated with the connection. To reset this parameter, pass
        /// the empty string ("") as an argument.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExtraConnectionAttributes")]
        public System.String ExtraConnectionAttribute { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_ExtractDocId
        /// <summary>
        /// <para>
        /// <para> Specifies the document ID. Use this setting when <code>NestingLevel</code> is set
        /// to NONE. </para><para>Default value is false. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_ExtractDocId { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_FileTransferUploadStream
        /// <summary>
        /// <para>
        /// <para>The number of threads used to upload a single file. This parameter accepts a value
        /// from 1 through 64. It defaults to 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RedshiftSettings_FileTransferUploadStreams")]
        public System.Int32? RedshiftSettings_FileTransferUploadStream { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_FullLoadErrorPercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of records that can fail to be written before a full load operation
        /// stops. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ElasticsearchSettings_FullLoadErrorPercentage { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_IncludeControlDetail
        /// <summary>
        /// <para>
        /// <para>Shows detailed control information for table definition, column definition, and table
        /// and column changes in the Kinesis message output. The default is <code>False</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisSettings_IncludeControlDetails")]
        public System.Boolean? KinesisSettings_IncludeControlDetail { get; set; }
        #endregion
        
        #region Parameter S3Settings_IncludeOpForFullLoad
        /// <summary>
        /// <para>
        /// <para>A value that enables a full load to write INSERT operations to the comma-separated
        /// value (.csv) output files only to indicate how the rows were added to the source database.</para><note><para>AWS DMS supports the <code>IncludeOpForFullLoad</code> parameter in versions 3.1.4
        /// and later.</para></note><para>For full load, records can only be inserted. By default (the <code>false</code> setting),
        /// no information is recorded in these output files for a full load to indicate that
        /// the rows were inserted at the source database. If <code>IncludeOpForFullLoad</code>
        /// is set to <code>true</code> or <code>y</code>, the INSERT is recorded as an I annotation
        /// in the first field of the .csv file. This allows the format of your target records
        /// from a full load to be consistent with the target records from a CDC load.</para><note><para>This setting works together with the <code>CdcInsertsOnly</code> and the <code>CdcInsertsAndUpdates</code>
        /// parameters for output to .csv files only. For more information about how these settings
        /// work together, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Target.S3.html#CHAP_Target.S3.Configuring.InsertOps">Indicating
        /// Source DB Operations in Migrated S3 Data</a> in the <i>AWS Database Migration Service
        /// User Guide.</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? S3Settings_IncludeOpForFullLoad { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_IncludePartitionValue
        /// <summary>
        /// <para>
        /// <para>Shows the partition value within the Kinesis message output, unless the partition
        /// type is <code>schema-table-type</code>. The default is <code>False</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KinesisSettings_IncludePartitionValue { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_IncludeTableAlterOperation
        /// <summary>
        /// <para>
        /// <para>Includes any data definition language (DDL) operations that change the table in the
        /// control data, such as <code>rename-table</code>, <code>drop-table</code>, <code>add-column</code>,
        /// <code>drop-column</code>, and <code>rename-column</code>. The default is <code>False</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisSettings_IncludeTableAlterOperations")]
        public System.Boolean? KinesisSettings_IncludeTableAlterOperation { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_IncludeTransactionDetail
        /// <summary>
        /// <para>
        /// <para>Provides detailed transaction information from the source database. This information
        /// includes a commit timestamp, a log position, and values for <code>transaction_id</code>,
        /// previous <code>transaction_id</code>, and <code>transaction_record_id</code> (the
        /// record offset within a transaction). The default is <code>False</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KinesisSettings_IncludeTransactionDetails")]
        public System.Boolean? KinesisSettings_IncludeTransactionDetail { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key identifier that is used to encrypt the content on the replication
        /// instance. If you don't specify a value for the <code>KmsKeyId</code> parameter, then
        /// AWS DMS uses your default encryption key. AWS KMS creates the default encryption key
        /// for your AWS account. Your AWS account has a different default encryption key for
        /// each AWS Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_LoadTimeout
        /// <summary>
        /// <para>
        /// <para>The amount of time to wait (in milliseconds) before timing out, beginning from when
        /// you begin loading.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RedshiftSettings_LoadTimeout { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_MaxFileSize
        /// <summary>
        /// <para>
        /// <para>The maximum size (in KB) of any .csv file used to transfer data to Amazon Redshift.
        /// This accepts a value from 1 through 1,048,576. It defaults to 32,768 KB (32 MB).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RedshiftSettings_MaxFileSize { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_MessageFormat
        /// <summary>
        /// <para>
        /// <para>The output format for the records created on the endpoint. The message format is <code>JSON</code>
        /// (default) or <code>JSON_UNFORMATTED</code> (a single line with no tab).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MessageFormatValue")]
        public Amazon.DatabaseMigrationService.MessageFormatValue KinesisSettings_MessageFormat { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_NestingLevel
        /// <summary>
        /// <para>
        /// <para> Specifies either document or table mode. </para><para>Valid values: NONE, ONE</para><para>Default value is NONE. Specify NONE to use document mode. Specify ONE to use table
        /// mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.NestingLevelValue")]
        public Amazon.DatabaseMigrationService.NestingLevelValue MongoDbSettings_NestingLevel { get; set; }
        #endregion
        
        #region Parameter S3Settings_ParquetTimestampInMillisecond
        /// <summary>
        /// <para>
        /// <para>A value that specifies the precision of any <code>TIMESTAMP</code> column values that
        /// are written to an Amazon S3 object file in .parquet format.</para><note><para>AWS DMS supports the <code>ParquetTimestampInMillisecond</code> parameter in versions
        /// 3.1.4 and later.</para></note><para>When <code>ParquetTimestampInMillisecond</code> is set to <code>true</code> or <code>y</code>,
        /// AWS DMS writes all <code>TIMESTAMP</code> columns in a .parquet formatted file with
        /// millisecond precision. Otherwise, DMS writes them with microsecond precision.</para><para>Currently, Amazon Athena and AWS Glue can handle only millisecond precision for <code>TIMESTAMP</code>
        /// values. Set this parameter to <code>true</code> for S3 endpoint object files that
        /// are .parquet formatted only if you plan to query or process the data with Athena or
        /// AWS Glue.</para><note><para>AWS DMS writes any <code>TIMESTAMP</code> column values written to an S3 file in .csv
        /// format with microsecond precision.</para><para>Setting <code>ParquetTimestampInMillisecond</code> has no effect on the string format
        /// of the timestamp column value that is inserted by setting the <code>TimestampColumnName</code>
        /// parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? S3Settings_ParquetTimestampInMillisecond { get; set; }
        #endregion
        
        #region Parameter S3Settings_ParquetVersion
        /// <summary>
        /// <para>
        /// <para>The version of the Apache Parquet format that you want to use: <code>parquet_1_0</code>
        /// (the default) or <code>parquet_2_0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.ParquetVersionValue")]
        public Amazon.DatabaseMigrationService.ParquetVersionValue S3Settings_ParquetVersion { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_PartitionIncludeSchemaTable
        /// <summary>
        /// <para>
        /// <para>Prefixes schema and table names to partition values, when the partition type is <code>primary-key-type</code>.
        /// Doing this increases data distribution among Kinesis shards. For example, suppose
        /// that a SysBench schema has thousands of tables and each table has only limited range
        /// for a primary key. In this case, the same primary key is sent from thousands of tables
        /// to the same shard, which causes throttling. The default is <code>False</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KinesisSettings_PartitionIncludeSchemaTable { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_Password
        /// <summary>
        /// <para>
        /// <para> The password for the user account you use to access the MongoDB source endpoint.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_Password { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password to be used to login to the endpoint database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_Password
        /// <summary>
        /// <para>
        /// <para>The password for the user named in the <code>username</code> property.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_Password { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_Port
        /// <summary>
        /// <para>
        /// <para> The port value for the MongoDB source endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MongoDbSettings_Port { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port used by the endpoint database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_Port
        /// <summary>
        /// <para>
        /// <para>The port number for Amazon Redshift. The default value is 5439.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RedshiftSettings_Port { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_RemoveQuote
        /// <summary>
        /// <para>
        /// <para>A value that specifies to remove surrounding quotation marks from strings in the incoming
        /// data. All characters within the quotation marks, including delimiters, are retained.
        /// Choose <code>true</code> to remove quotation marks. The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RedshiftSettings_RemoveQuotes")]
        public System.Boolean? RedshiftSettings_RemoveQuote { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_ReplaceChar
        /// <summary>
        /// <para>
        /// <para>A value that specifies to replaces the invalid characters specified in <code>ReplaceInvalidChars</code>,
        /// substituting the specified characters instead. The default is <code>"?"</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RedshiftSettings_ReplaceChars")]
        public System.String RedshiftSettings_ReplaceChar { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_ReplaceInvalidChar
        /// <summary>
        /// <para>
        /// <para>A list of characters that you want to replace. Use with <code>ReplaceChars</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RedshiftSettings_ReplaceInvalidChars")]
        public System.String RedshiftSettings_ReplaceInvalidChar { get; set; }
        #endregion
        
        #region Parameter S3Settings_RowGroupLength
        /// <summary>
        /// <para>
        /// <para>The number of rows in a row group. A smaller row group size provides faster reads.
        /// But as the number of row groups grows, the slower writes become. This parameter defaults
        /// to 10,000 rows. This number is used for .parquet file format only. </para><para>If you choose a value larger than the maximum, <code>RowGroupLength</code> is set
        /// to the max row group length in bytes (64 * 1024 * 1024). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? S3Settings_RowGroupLength { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_ServerName
        /// <summary>
        /// <para>
        /// <para> The name of the server on the MongoDB source endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Redshift cluster you are using.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the server where the endpoint database resides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_ServerSideEncryptionKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key ID. If you are using <code>SSE_KMS</code> for the <code>EncryptionMode</code>,
        /// provide this key ID. The key that you use needs an attached policy that enables IAM
        /// user permissions and allows use of the key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_ServerSideEncryptionKmsKeyId { get; set; }
        #endregion
        
        #region Parameter S3Settings_ServerSideEncryptionKmsKeyId
        /// <summary>
        /// <para>
        /// <para>If you are using <code>SSE_KMS</code> for the <code>EncryptionMode</code>, provide
        /// the AWS KMS key ID. The key that you use needs an attached policy that enables AWS
        /// Identity and Access Management (IAM) user permissions and allows use of the key.</para><para>Here is a CLI example: <code>aws dms create-endpoint --endpoint-identifier <i>value</i>
        /// --endpoint-type target --engine-name s3 --s3-settings ServiceAccessRoleArn=<i>value</i>,BucketFolder=<i>value</i>,BucketName=<i>value</i>,EncryptionMode=SSE_KMS,ServerSideEncryptionKmsKeyId=<i>value</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_ServerSideEncryptionKmsKeyId { get; set; }
        #endregion
        
        #region Parameter DmsTransferSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The IAM role that has permission to access the Amazon S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DmsTransferSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter DynamoDbSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) used by the service access IAM role. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DynamoDbSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) used by service to access the IAM role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticsearchSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the AWS Identity and Access Management (IAM) role
        /// that AWS DMS uses to write to the Kinesis data stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that has access to the Amazon Redshift
        /// service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter S3Settings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) used by the service access IAM role. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) for the service access role you want to use to modify
        /// the endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter SslMode
        /// <summary>
        /// <para>
        /// <para>The SSL mode used to connect to the endpoint. The default value is <code>none</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue SslMode { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_StreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Amazon Kinesis Data Streams endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisSettings_StreamArn { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_TimeFormat
        /// <summary>
        /// <para>
        /// <para>The time format that you want to use. Valid values are <code>auto</code> (case-sensitive),
        /// <code>'timeformat_string'</code>, <code>'epochsecs'</code>, or <code>'epochmillisecs'</code>.
        /// It defaults to 10. Using <code>auto</code> recognizes most strings, even some that
        /// aren't supported when you use a time format string. </para><para>If your date and time values use formats different from each other, set this parameter
        /// to <code>auto</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_TimeFormat { get; set; }
        #endregion
        
        #region Parameter S3Settings_TimestampColumnName
        /// <summary>
        /// <para>
        /// <para>A value that when nonblank causes AWS DMS to add a column with timestamp information
        /// to the endpoint data for an Amazon S3 target.</para><note><para>AWS DMS supports the <code>TimestampColumnName</code> parameter in versions 3.1.4
        /// and later.</para></note><para>DMS includes an additional <code>STRING</code> column in the .csv or .parquet object
        /// files of your migrated data when you set <code>TimestampColumnName</code> to a nonblank
        /// value.</para><para>For a full load, each row of this timestamp column contains a timestamp for when the
        /// data was transferred from the source to the target by DMS. </para><para>For a change data capture (CDC) load, each row of the timestamp column contains the
        /// timestamp for the commit of that row in the source database.</para><para>The string format for this timestamp column value is <code>yyyy-MM-dd HH:mm:ss.SSSSSS</code>.
        /// By default, the precision of this value is in microseconds. For a CDC load, the rounding
        /// of the precision depends on the commit timestamp supported by DMS for the source database.</para><para>When the <code>AddColumnName</code> parameter is set to <code>true</code>, DMS also
        /// includes a name for the timestamp column that you set with <code>TimestampColumnName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Settings_TimestampColumnName { get; set; }
        #endregion
        
        #region Parameter KafkaSettings_Topic
        /// <summary>
        /// <para>
        /// <para>The topic to which you migrate the data. If you don't specify a topic, AWS DMS specifies
        /// <code>"kafka-default-topic"</code> as the migration topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KafkaSettings_Topic { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_TrimBlank
        /// <summary>
        /// <para>
        /// <para>A value that specifies to remove the trailing white space characters from a VARCHAR
        /// string. This parameter applies only to columns with a VARCHAR data type. Choose <code>true</code>
        /// to remove unneeded white space. The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RedshiftSettings_TrimBlanks")]
        public System.Boolean? RedshiftSettings_TrimBlank { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_TruncateColumn
        /// <summary>
        /// <para>
        /// <para>A value that specifies to truncate data in columns to the appropriate number of characters,
        /// so that the data fits in the column. This parameter applies only to columns with a
        /// VARCHAR or CHAR data type, and rows with a size of 4 MB or less. Choose <code>true</code>
        /// to truncate data. The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RedshiftSettings_TruncateColumns")]
        public System.Boolean? RedshiftSettings_TruncateColumn { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_Username
        /// <summary>
        /// <para>
        /// <para>The user name you use to access the MongoDB source endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MongoDbSettings_Username { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_Username
        /// <summary>
        /// <para>
        /// <para>An Amazon Redshift user name for a registered user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedshiftSettings_Username { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The user name to be used to login to the endpoint database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter RedshiftSettings_WriteBufferSize
        /// <summary>
        /// <para>
        /// <para>The size of the write buffer to use in rows. Valid values range from 1 through 2,048.
        /// The default is 1,024. Use this setting to tune performance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RedshiftSettings_WriteBufferSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Endpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Endpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EndpointArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EndpointArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EndpointArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DMSEndpoint (ModifyEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse, EditDMSEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EndpointArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateArn = this.CertificateArn;
            context.DatabaseName = this.DatabaseName;
            context.DmsTransferSettings_BucketName = this.DmsTransferSettings_BucketName;
            context.DmsTransferSettings_ServiceAccessRoleArn = this.DmsTransferSettings_ServiceAccessRoleArn;
            context.DynamoDbSettings_ServiceAccessRoleArn = this.DynamoDbSettings_ServiceAccessRoleArn;
            context.ElasticsearchSettings_EndpointUri = this.ElasticsearchSettings_EndpointUri;
            context.ElasticsearchSettings_ErrorRetryDuration = this.ElasticsearchSettings_ErrorRetryDuration;
            context.ElasticsearchSettings_FullLoadErrorPercentage = this.ElasticsearchSettings_FullLoadErrorPercentage;
            context.ElasticsearchSettings_ServiceAccessRoleArn = this.ElasticsearchSettings_ServiceAccessRoleArn;
            context.EndpointArn = this.EndpointArn;
            #if MODULAR
            if (this.EndpointArn == null && ParameterWasBound(nameof(this.EndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointIdentifier = this.EndpointIdentifier;
            context.EndpointType = this.EndpointType;
            context.EngineName = this.EngineName;
            context.ExternalTableDefinition = this.ExternalTableDefinition;
            context.ExtraConnectionAttribute = this.ExtraConnectionAttribute;
            context.KafkaSettings_Broker = this.KafkaSettings_Broker;
            context.KafkaSettings_Topic = this.KafkaSettings_Topic;
            context.KinesisSettings_IncludeControlDetail = this.KinesisSettings_IncludeControlDetail;
            context.KinesisSettings_IncludePartitionValue = this.KinesisSettings_IncludePartitionValue;
            context.KinesisSettings_IncludeTableAlterOperation = this.KinesisSettings_IncludeTableAlterOperation;
            context.KinesisSettings_IncludeTransactionDetail = this.KinesisSettings_IncludeTransactionDetail;
            context.KinesisSettings_MessageFormat = this.KinesisSettings_MessageFormat;
            context.KinesisSettings_PartitionIncludeSchemaTable = this.KinesisSettings_PartitionIncludeSchemaTable;
            context.KinesisSettings_ServiceAccessRoleArn = this.KinesisSettings_ServiceAccessRoleArn;
            context.KinesisSettings_StreamArn = this.KinesisSettings_StreamArn;
            context.MongoDbSettings_AuthMechanism = this.MongoDbSettings_AuthMechanism;
            context.MongoDbSettings_AuthSource = this.MongoDbSettings_AuthSource;
            context.MongoDbSettings_AuthType = this.MongoDbSettings_AuthType;
            context.MongoDbSettings_DatabaseName = this.MongoDbSettings_DatabaseName;
            context.MongoDbSettings_DocsToInvestigate = this.MongoDbSettings_DocsToInvestigate;
            context.MongoDbSettings_ExtractDocId = this.MongoDbSettings_ExtractDocId;
            context.MongoDbSettings_KmsKeyId = this.MongoDbSettings_KmsKeyId;
            context.MongoDbSettings_NestingLevel = this.MongoDbSettings_NestingLevel;
            context.MongoDbSettings_Password = this.MongoDbSettings_Password;
            context.MongoDbSettings_Port = this.MongoDbSettings_Port;
            context.MongoDbSettings_ServerName = this.MongoDbSettings_ServerName;
            context.MongoDbSettings_Username = this.MongoDbSettings_Username;
            context.Password = this.Password;
            context.Port = this.Port;
            context.RedshiftSettings_AcceptAnyDate = this.RedshiftSettings_AcceptAnyDate;
            context.RedshiftSettings_AfterConnectScript = this.RedshiftSettings_AfterConnectScript;
            context.RedshiftSettings_BucketFolder = this.RedshiftSettings_BucketFolder;
            context.RedshiftSettings_BucketName = this.RedshiftSettings_BucketName;
            context.RedshiftSettings_ConnectionTimeout = this.RedshiftSettings_ConnectionTimeout;
            context.RedshiftSettings_DatabaseName = this.RedshiftSettings_DatabaseName;
            context.RedshiftSettings_DateFormat = this.RedshiftSettings_DateFormat;
            context.RedshiftSettings_EmptyAsNull = this.RedshiftSettings_EmptyAsNull;
            context.RedshiftSettings_EncryptionMode = this.RedshiftSettings_EncryptionMode;
            context.RedshiftSettings_FileTransferUploadStream = this.RedshiftSettings_FileTransferUploadStream;
            context.RedshiftSettings_LoadTimeout = this.RedshiftSettings_LoadTimeout;
            context.RedshiftSettings_MaxFileSize = this.RedshiftSettings_MaxFileSize;
            context.RedshiftSettings_Password = this.RedshiftSettings_Password;
            context.RedshiftSettings_Port = this.RedshiftSettings_Port;
            context.RedshiftSettings_RemoveQuote = this.RedshiftSettings_RemoveQuote;
            context.RedshiftSettings_ReplaceChar = this.RedshiftSettings_ReplaceChar;
            context.RedshiftSettings_ReplaceInvalidChar = this.RedshiftSettings_ReplaceInvalidChar;
            context.RedshiftSettings_ServerName = this.RedshiftSettings_ServerName;
            context.RedshiftSettings_ServerSideEncryptionKmsKeyId = this.RedshiftSettings_ServerSideEncryptionKmsKeyId;
            context.RedshiftSettings_ServiceAccessRoleArn = this.RedshiftSettings_ServiceAccessRoleArn;
            context.RedshiftSettings_TimeFormat = this.RedshiftSettings_TimeFormat;
            context.RedshiftSettings_TrimBlank = this.RedshiftSettings_TrimBlank;
            context.RedshiftSettings_TruncateColumn = this.RedshiftSettings_TruncateColumn;
            context.RedshiftSettings_Username = this.RedshiftSettings_Username;
            context.RedshiftSettings_WriteBufferSize = this.RedshiftSettings_WriteBufferSize;
            context.S3Settings_BucketFolder = this.S3Settings_BucketFolder;
            context.S3Settings_BucketName = this.S3Settings_BucketName;
            context.S3Settings_CdcInsertsAndUpdate = this.S3Settings_CdcInsertsAndUpdate;
            context.S3Settings_CdcInsertsOnly = this.S3Settings_CdcInsertsOnly;
            context.S3Settings_CompressionType = this.S3Settings_CompressionType;
            context.S3Settings_CsvDelimiter = this.S3Settings_CsvDelimiter;
            context.S3Settings_CsvRowDelimiter = this.S3Settings_CsvRowDelimiter;
            context.S3Settings_DataFormat = this.S3Settings_DataFormat;
            context.S3Settings_DataPageSize = this.S3Settings_DataPageSize;
            context.S3Settings_DictPageSizeLimit = this.S3Settings_DictPageSizeLimit;
            context.S3Settings_EnableStatistic = this.S3Settings_EnableStatistic;
            context.S3Settings_EncodingType = this.S3Settings_EncodingType;
            context.S3Settings_EncryptionMode = this.S3Settings_EncryptionMode;
            context.S3Settings_ExternalTableDefinition = this.S3Settings_ExternalTableDefinition;
            context.S3Settings_IncludeOpForFullLoad = this.S3Settings_IncludeOpForFullLoad;
            context.S3Settings_ParquetTimestampInMillisecond = this.S3Settings_ParquetTimestampInMillisecond;
            context.S3Settings_ParquetVersion = this.S3Settings_ParquetVersion;
            context.S3Settings_RowGroupLength = this.S3Settings_RowGroupLength;
            context.S3Settings_ServerSideEncryptionKmsKeyId = this.S3Settings_ServerSideEncryptionKmsKeyId;
            context.S3Settings_ServiceAccessRoleArn = this.S3Settings_ServiceAccessRoleArn;
            context.S3Settings_TimestampColumnName = this.S3Settings_TimestampColumnName;
            context.ServerName = this.ServerName;
            context.ServiceAccessRoleArn = this.ServiceAccessRoleArn;
            context.SslMode = this.SslMode;
            context.Username = this.Username;
            
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
            var request = new Amazon.DatabaseMigrationService.Model.ModifyEndpointRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            
             // populate DmsTransferSettings
            var requestDmsTransferSettingsIsNull = true;
            request.DmsTransferSettings = new Amazon.DatabaseMigrationService.Model.DmsTransferSettings();
            System.String requestDmsTransferSettings_dmsTransferSettings_BucketName = null;
            if (cmdletContext.DmsTransferSettings_BucketName != null)
            {
                requestDmsTransferSettings_dmsTransferSettings_BucketName = cmdletContext.DmsTransferSettings_BucketName;
            }
            if (requestDmsTransferSettings_dmsTransferSettings_BucketName != null)
            {
                request.DmsTransferSettings.BucketName = requestDmsTransferSettings_dmsTransferSettings_BucketName;
                requestDmsTransferSettingsIsNull = false;
            }
            System.String requestDmsTransferSettings_dmsTransferSettings_ServiceAccessRoleArn = null;
            if (cmdletContext.DmsTransferSettings_ServiceAccessRoleArn != null)
            {
                requestDmsTransferSettings_dmsTransferSettings_ServiceAccessRoleArn = cmdletContext.DmsTransferSettings_ServiceAccessRoleArn;
            }
            if (requestDmsTransferSettings_dmsTransferSettings_ServiceAccessRoleArn != null)
            {
                request.DmsTransferSettings.ServiceAccessRoleArn = requestDmsTransferSettings_dmsTransferSettings_ServiceAccessRoleArn;
                requestDmsTransferSettingsIsNull = false;
            }
             // determine if request.DmsTransferSettings should be set to null
            if (requestDmsTransferSettingsIsNull)
            {
                request.DmsTransferSettings = null;
            }
            
             // populate DynamoDbSettings
            var requestDynamoDbSettingsIsNull = true;
            request.DynamoDbSettings = new Amazon.DatabaseMigrationService.Model.DynamoDbSettings();
            System.String requestDynamoDbSettings_dynamoDbSettings_ServiceAccessRoleArn = null;
            if (cmdletContext.DynamoDbSettings_ServiceAccessRoleArn != null)
            {
                requestDynamoDbSettings_dynamoDbSettings_ServiceAccessRoleArn = cmdletContext.DynamoDbSettings_ServiceAccessRoleArn;
            }
            if (requestDynamoDbSettings_dynamoDbSettings_ServiceAccessRoleArn != null)
            {
                request.DynamoDbSettings.ServiceAccessRoleArn = requestDynamoDbSettings_dynamoDbSettings_ServiceAccessRoleArn;
                requestDynamoDbSettingsIsNull = false;
            }
             // determine if request.DynamoDbSettings should be set to null
            if (requestDynamoDbSettingsIsNull)
            {
                request.DynamoDbSettings = null;
            }
            
             // populate ElasticsearchSettings
            var requestElasticsearchSettingsIsNull = true;
            request.ElasticsearchSettings = new Amazon.DatabaseMigrationService.Model.ElasticsearchSettings();
            System.String requestElasticsearchSettings_elasticsearchSettings_EndpointUri = null;
            if (cmdletContext.ElasticsearchSettings_EndpointUri != null)
            {
                requestElasticsearchSettings_elasticsearchSettings_EndpointUri = cmdletContext.ElasticsearchSettings_EndpointUri;
            }
            if (requestElasticsearchSettings_elasticsearchSettings_EndpointUri != null)
            {
                request.ElasticsearchSettings.EndpointUri = requestElasticsearchSettings_elasticsearchSettings_EndpointUri;
                requestElasticsearchSettingsIsNull = false;
            }
            System.Int32? requestElasticsearchSettings_elasticsearchSettings_ErrorRetryDuration = null;
            if (cmdletContext.ElasticsearchSettings_ErrorRetryDuration != null)
            {
                requestElasticsearchSettings_elasticsearchSettings_ErrorRetryDuration = cmdletContext.ElasticsearchSettings_ErrorRetryDuration.Value;
            }
            if (requestElasticsearchSettings_elasticsearchSettings_ErrorRetryDuration != null)
            {
                request.ElasticsearchSettings.ErrorRetryDuration = requestElasticsearchSettings_elasticsearchSettings_ErrorRetryDuration.Value;
                requestElasticsearchSettingsIsNull = false;
            }
            System.Int32? requestElasticsearchSettings_elasticsearchSettings_FullLoadErrorPercentage = null;
            if (cmdletContext.ElasticsearchSettings_FullLoadErrorPercentage != null)
            {
                requestElasticsearchSettings_elasticsearchSettings_FullLoadErrorPercentage = cmdletContext.ElasticsearchSettings_FullLoadErrorPercentage.Value;
            }
            if (requestElasticsearchSettings_elasticsearchSettings_FullLoadErrorPercentage != null)
            {
                request.ElasticsearchSettings.FullLoadErrorPercentage = requestElasticsearchSettings_elasticsearchSettings_FullLoadErrorPercentage.Value;
                requestElasticsearchSettingsIsNull = false;
            }
            System.String requestElasticsearchSettings_elasticsearchSettings_ServiceAccessRoleArn = null;
            if (cmdletContext.ElasticsearchSettings_ServiceAccessRoleArn != null)
            {
                requestElasticsearchSettings_elasticsearchSettings_ServiceAccessRoleArn = cmdletContext.ElasticsearchSettings_ServiceAccessRoleArn;
            }
            if (requestElasticsearchSettings_elasticsearchSettings_ServiceAccessRoleArn != null)
            {
                request.ElasticsearchSettings.ServiceAccessRoleArn = requestElasticsearchSettings_elasticsearchSettings_ServiceAccessRoleArn;
                requestElasticsearchSettingsIsNull = false;
            }
             // determine if request.ElasticsearchSettings should be set to null
            if (requestElasticsearchSettingsIsNull)
            {
                request.ElasticsearchSettings = null;
            }
            if (cmdletContext.EndpointArn != null)
            {
                request.EndpointArn = cmdletContext.EndpointArn;
            }
            if (cmdletContext.EndpointIdentifier != null)
            {
                request.EndpointIdentifier = cmdletContext.EndpointIdentifier;
            }
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
            }
            if (cmdletContext.EngineName != null)
            {
                request.EngineName = cmdletContext.EngineName;
            }
            if (cmdletContext.ExternalTableDefinition != null)
            {
                request.ExternalTableDefinition = cmdletContext.ExternalTableDefinition;
            }
            if (cmdletContext.ExtraConnectionAttribute != null)
            {
                request.ExtraConnectionAttributes = cmdletContext.ExtraConnectionAttribute;
            }
            
             // populate KafkaSettings
            var requestKafkaSettingsIsNull = true;
            request.KafkaSettings = new Amazon.DatabaseMigrationService.Model.KafkaSettings();
            System.String requestKafkaSettings_kafkaSettings_Broker = null;
            if (cmdletContext.KafkaSettings_Broker != null)
            {
                requestKafkaSettings_kafkaSettings_Broker = cmdletContext.KafkaSettings_Broker;
            }
            if (requestKafkaSettings_kafkaSettings_Broker != null)
            {
                request.KafkaSettings.Broker = requestKafkaSettings_kafkaSettings_Broker;
                requestKafkaSettingsIsNull = false;
            }
            System.String requestKafkaSettings_kafkaSettings_Topic = null;
            if (cmdletContext.KafkaSettings_Topic != null)
            {
                requestKafkaSettings_kafkaSettings_Topic = cmdletContext.KafkaSettings_Topic;
            }
            if (requestKafkaSettings_kafkaSettings_Topic != null)
            {
                request.KafkaSettings.Topic = requestKafkaSettings_kafkaSettings_Topic;
                requestKafkaSettingsIsNull = false;
            }
             // determine if request.KafkaSettings should be set to null
            if (requestKafkaSettingsIsNull)
            {
                request.KafkaSettings = null;
            }
            
             // populate KinesisSettings
            var requestKinesisSettingsIsNull = true;
            request.KinesisSettings = new Amazon.DatabaseMigrationService.Model.KinesisSettings();
            System.Boolean? requestKinesisSettings_kinesisSettings_IncludeControlDetail = null;
            if (cmdletContext.KinesisSettings_IncludeControlDetail != null)
            {
                requestKinesisSettings_kinesisSettings_IncludeControlDetail = cmdletContext.KinesisSettings_IncludeControlDetail.Value;
            }
            if (requestKinesisSettings_kinesisSettings_IncludeControlDetail != null)
            {
                request.KinesisSettings.IncludeControlDetails = requestKinesisSettings_kinesisSettings_IncludeControlDetail.Value;
                requestKinesisSettingsIsNull = false;
            }
            System.Boolean? requestKinesisSettings_kinesisSettings_IncludePartitionValue = null;
            if (cmdletContext.KinesisSettings_IncludePartitionValue != null)
            {
                requestKinesisSettings_kinesisSettings_IncludePartitionValue = cmdletContext.KinesisSettings_IncludePartitionValue.Value;
            }
            if (requestKinesisSettings_kinesisSettings_IncludePartitionValue != null)
            {
                request.KinesisSettings.IncludePartitionValue = requestKinesisSettings_kinesisSettings_IncludePartitionValue.Value;
                requestKinesisSettingsIsNull = false;
            }
            System.Boolean? requestKinesisSettings_kinesisSettings_IncludeTableAlterOperation = null;
            if (cmdletContext.KinesisSettings_IncludeTableAlterOperation != null)
            {
                requestKinesisSettings_kinesisSettings_IncludeTableAlterOperation = cmdletContext.KinesisSettings_IncludeTableAlterOperation.Value;
            }
            if (requestKinesisSettings_kinesisSettings_IncludeTableAlterOperation != null)
            {
                request.KinesisSettings.IncludeTableAlterOperations = requestKinesisSettings_kinesisSettings_IncludeTableAlterOperation.Value;
                requestKinesisSettingsIsNull = false;
            }
            System.Boolean? requestKinesisSettings_kinesisSettings_IncludeTransactionDetail = null;
            if (cmdletContext.KinesisSettings_IncludeTransactionDetail != null)
            {
                requestKinesisSettings_kinesisSettings_IncludeTransactionDetail = cmdletContext.KinesisSettings_IncludeTransactionDetail.Value;
            }
            if (requestKinesisSettings_kinesisSettings_IncludeTransactionDetail != null)
            {
                request.KinesisSettings.IncludeTransactionDetails = requestKinesisSettings_kinesisSettings_IncludeTransactionDetail.Value;
                requestKinesisSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.MessageFormatValue requestKinesisSettings_kinesisSettings_MessageFormat = null;
            if (cmdletContext.KinesisSettings_MessageFormat != null)
            {
                requestKinesisSettings_kinesisSettings_MessageFormat = cmdletContext.KinesisSettings_MessageFormat;
            }
            if (requestKinesisSettings_kinesisSettings_MessageFormat != null)
            {
                request.KinesisSettings.MessageFormat = requestKinesisSettings_kinesisSettings_MessageFormat;
                requestKinesisSettingsIsNull = false;
            }
            System.Boolean? requestKinesisSettings_kinesisSettings_PartitionIncludeSchemaTable = null;
            if (cmdletContext.KinesisSettings_PartitionIncludeSchemaTable != null)
            {
                requestKinesisSettings_kinesisSettings_PartitionIncludeSchemaTable = cmdletContext.KinesisSettings_PartitionIncludeSchemaTable.Value;
            }
            if (requestKinesisSettings_kinesisSettings_PartitionIncludeSchemaTable != null)
            {
                request.KinesisSettings.PartitionIncludeSchemaTable = requestKinesisSettings_kinesisSettings_PartitionIncludeSchemaTable.Value;
                requestKinesisSettingsIsNull = false;
            }
            System.String requestKinesisSettings_kinesisSettings_ServiceAccessRoleArn = null;
            if (cmdletContext.KinesisSettings_ServiceAccessRoleArn != null)
            {
                requestKinesisSettings_kinesisSettings_ServiceAccessRoleArn = cmdletContext.KinesisSettings_ServiceAccessRoleArn;
            }
            if (requestKinesisSettings_kinesisSettings_ServiceAccessRoleArn != null)
            {
                request.KinesisSettings.ServiceAccessRoleArn = requestKinesisSettings_kinesisSettings_ServiceAccessRoleArn;
                requestKinesisSettingsIsNull = false;
            }
            System.String requestKinesisSettings_kinesisSettings_StreamArn = null;
            if (cmdletContext.KinesisSettings_StreamArn != null)
            {
                requestKinesisSettings_kinesisSettings_StreamArn = cmdletContext.KinesisSettings_StreamArn;
            }
            if (requestKinesisSettings_kinesisSettings_StreamArn != null)
            {
                request.KinesisSettings.StreamArn = requestKinesisSettings_kinesisSettings_StreamArn;
                requestKinesisSettingsIsNull = false;
            }
             // determine if request.KinesisSettings should be set to null
            if (requestKinesisSettingsIsNull)
            {
                request.KinesisSettings = null;
            }
            
             // populate MongoDbSettings
            var requestMongoDbSettingsIsNull = true;
            request.MongoDbSettings = new Amazon.DatabaseMigrationService.Model.MongoDbSettings();
            Amazon.DatabaseMigrationService.AuthMechanismValue requestMongoDbSettings_mongoDbSettings_AuthMechanism = null;
            if (cmdletContext.MongoDbSettings_AuthMechanism != null)
            {
                requestMongoDbSettings_mongoDbSettings_AuthMechanism = cmdletContext.MongoDbSettings_AuthMechanism;
            }
            if (requestMongoDbSettings_mongoDbSettings_AuthMechanism != null)
            {
                request.MongoDbSettings.AuthMechanism = requestMongoDbSettings_mongoDbSettings_AuthMechanism;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_AuthSource = null;
            if (cmdletContext.MongoDbSettings_AuthSource != null)
            {
                requestMongoDbSettings_mongoDbSettings_AuthSource = cmdletContext.MongoDbSettings_AuthSource;
            }
            if (requestMongoDbSettings_mongoDbSettings_AuthSource != null)
            {
                request.MongoDbSettings.AuthSource = requestMongoDbSettings_mongoDbSettings_AuthSource;
                requestMongoDbSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.AuthTypeValue requestMongoDbSettings_mongoDbSettings_AuthType = null;
            if (cmdletContext.MongoDbSettings_AuthType != null)
            {
                requestMongoDbSettings_mongoDbSettings_AuthType = cmdletContext.MongoDbSettings_AuthType;
            }
            if (requestMongoDbSettings_mongoDbSettings_AuthType != null)
            {
                request.MongoDbSettings.AuthType = requestMongoDbSettings_mongoDbSettings_AuthType;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_DatabaseName = null;
            if (cmdletContext.MongoDbSettings_DatabaseName != null)
            {
                requestMongoDbSettings_mongoDbSettings_DatabaseName = cmdletContext.MongoDbSettings_DatabaseName;
            }
            if (requestMongoDbSettings_mongoDbSettings_DatabaseName != null)
            {
                request.MongoDbSettings.DatabaseName = requestMongoDbSettings_mongoDbSettings_DatabaseName;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_DocsToInvestigate = null;
            if (cmdletContext.MongoDbSettings_DocsToInvestigate != null)
            {
                requestMongoDbSettings_mongoDbSettings_DocsToInvestigate = cmdletContext.MongoDbSettings_DocsToInvestigate;
            }
            if (requestMongoDbSettings_mongoDbSettings_DocsToInvestigate != null)
            {
                request.MongoDbSettings.DocsToInvestigate = requestMongoDbSettings_mongoDbSettings_DocsToInvestigate;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_ExtractDocId = null;
            if (cmdletContext.MongoDbSettings_ExtractDocId != null)
            {
                requestMongoDbSettings_mongoDbSettings_ExtractDocId = cmdletContext.MongoDbSettings_ExtractDocId;
            }
            if (requestMongoDbSettings_mongoDbSettings_ExtractDocId != null)
            {
                request.MongoDbSettings.ExtractDocId = requestMongoDbSettings_mongoDbSettings_ExtractDocId;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_KmsKeyId = null;
            if (cmdletContext.MongoDbSettings_KmsKeyId != null)
            {
                requestMongoDbSettings_mongoDbSettings_KmsKeyId = cmdletContext.MongoDbSettings_KmsKeyId;
            }
            if (requestMongoDbSettings_mongoDbSettings_KmsKeyId != null)
            {
                request.MongoDbSettings.KmsKeyId = requestMongoDbSettings_mongoDbSettings_KmsKeyId;
                requestMongoDbSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.NestingLevelValue requestMongoDbSettings_mongoDbSettings_NestingLevel = null;
            if (cmdletContext.MongoDbSettings_NestingLevel != null)
            {
                requestMongoDbSettings_mongoDbSettings_NestingLevel = cmdletContext.MongoDbSettings_NestingLevel;
            }
            if (requestMongoDbSettings_mongoDbSettings_NestingLevel != null)
            {
                request.MongoDbSettings.NestingLevel = requestMongoDbSettings_mongoDbSettings_NestingLevel;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_Password = null;
            if (cmdletContext.MongoDbSettings_Password != null)
            {
                requestMongoDbSettings_mongoDbSettings_Password = cmdletContext.MongoDbSettings_Password;
            }
            if (requestMongoDbSettings_mongoDbSettings_Password != null)
            {
                request.MongoDbSettings.Password = requestMongoDbSettings_mongoDbSettings_Password;
                requestMongoDbSettingsIsNull = false;
            }
            System.Int32? requestMongoDbSettings_mongoDbSettings_Port = null;
            if (cmdletContext.MongoDbSettings_Port != null)
            {
                requestMongoDbSettings_mongoDbSettings_Port = cmdletContext.MongoDbSettings_Port.Value;
            }
            if (requestMongoDbSettings_mongoDbSettings_Port != null)
            {
                request.MongoDbSettings.Port = requestMongoDbSettings_mongoDbSettings_Port.Value;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_ServerName = null;
            if (cmdletContext.MongoDbSettings_ServerName != null)
            {
                requestMongoDbSettings_mongoDbSettings_ServerName = cmdletContext.MongoDbSettings_ServerName;
            }
            if (requestMongoDbSettings_mongoDbSettings_ServerName != null)
            {
                request.MongoDbSettings.ServerName = requestMongoDbSettings_mongoDbSettings_ServerName;
                requestMongoDbSettingsIsNull = false;
            }
            System.String requestMongoDbSettings_mongoDbSettings_Username = null;
            if (cmdletContext.MongoDbSettings_Username != null)
            {
                requestMongoDbSettings_mongoDbSettings_Username = cmdletContext.MongoDbSettings_Username;
            }
            if (requestMongoDbSettings_mongoDbSettings_Username != null)
            {
                request.MongoDbSettings.Username = requestMongoDbSettings_mongoDbSettings_Username;
                requestMongoDbSettingsIsNull = false;
            }
             // determine if request.MongoDbSettings should be set to null
            if (requestMongoDbSettingsIsNull)
            {
                request.MongoDbSettings = null;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            
             // populate RedshiftSettings
            var requestRedshiftSettingsIsNull = true;
            request.RedshiftSettings = new Amazon.DatabaseMigrationService.Model.RedshiftSettings();
            System.Boolean? requestRedshiftSettings_redshiftSettings_AcceptAnyDate = null;
            if (cmdletContext.RedshiftSettings_AcceptAnyDate != null)
            {
                requestRedshiftSettings_redshiftSettings_AcceptAnyDate = cmdletContext.RedshiftSettings_AcceptAnyDate.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_AcceptAnyDate != null)
            {
                request.RedshiftSettings.AcceptAnyDate = requestRedshiftSettings_redshiftSettings_AcceptAnyDate.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_AfterConnectScript = null;
            if (cmdletContext.RedshiftSettings_AfterConnectScript != null)
            {
                requestRedshiftSettings_redshiftSettings_AfterConnectScript = cmdletContext.RedshiftSettings_AfterConnectScript;
            }
            if (requestRedshiftSettings_redshiftSettings_AfterConnectScript != null)
            {
                request.RedshiftSettings.AfterConnectScript = requestRedshiftSettings_redshiftSettings_AfterConnectScript;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_BucketFolder = null;
            if (cmdletContext.RedshiftSettings_BucketFolder != null)
            {
                requestRedshiftSettings_redshiftSettings_BucketFolder = cmdletContext.RedshiftSettings_BucketFolder;
            }
            if (requestRedshiftSettings_redshiftSettings_BucketFolder != null)
            {
                request.RedshiftSettings.BucketFolder = requestRedshiftSettings_redshiftSettings_BucketFolder;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_BucketName = null;
            if (cmdletContext.RedshiftSettings_BucketName != null)
            {
                requestRedshiftSettings_redshiftSettings_BucketName = cmdletContext.RedshiftSettings_BucketName;
            }
            if (requestRedshiftSettings_redshiftSettings_BucketName != null)
            {
                request.RedshiftSettings.BucketName = requestRedshiftSettings_redshiftSettings_BucketName;
                requestRedshiftSettingsIsNull = false;
            }
            System.Int32? requestRedshiftSettings_redshiftSettings_ConnectionTimeout = null;
            if (cmdletContext.RedshiftSettings_ConnectionTimeout != null)
            {
                requestRedshiftSettings_redshiftSettings_ConnectionTimeout = cmdletContext.RedshiftSettings_ConnectionTimeout.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_ConnectionTimeout != null)
            {
                request.RedshiftSettings.ConnectionTimeout = requestRedshiftSettings_redshiftSettings_ConnectionTimeout.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_DatabaseName = null;
            if (cmdletContext.RedshiftSettings_DatabaseName != null)
            {
                requestRedshiftSettings_redshiftSettings_DatabaseName = cmdletContext.RedshiftSettings_DatabaseName;
            }
            if (requestRedshiftSettings_redshiftSettings_DatabaseName != null)
            {
                request.RedshiftSettings.DatabaseName = requestRedshiftSettings_redshiftSettings_DatabaseName;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_DateFormat = null;
            if (cmdletContext.RedshiftSettings_DateFormat != null)
            {
                requestRedshiftSettings_redshiftSettings_DateFormat = cmdletContext.RedshiftSettings_DateFormat;
            }
            if (requestRedshiftSettings_redshiftSettings_DateFormat != null)
            {
                request.RedshiftSettings.DateFormat = requestRedshiftSettings_redshiftSettings_DateFormat;
                requestRedshiftSettingsIsNull = false;
            }
            System.Boolean? requestRedshiftSettings_redshiftSettings_EmptyAsNull = null;
            if (cmdletContext.RedshiftSettings_EmptyAsNull != null)
            {
                requestRedshiftSettings_redshiftSettings_EmptyAsNull = cmdletContext.RedshiftSettings_EmptyAsNull.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_EmptyAsNull != null)
            {
                request.RedshiftSettings.EmptyAsNull = requestRedshiftSettings_redshiftSettings_EmptyAsNull.Value;
                requestRedshiftSettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.EncryptionModeValue requestRedshiftSettings_redshiftSettings_EncryptionMode = null;
            if (cmdletContext.RedshiftSettings_EncryptionMode != null)
            {
                requestRedshiftSettings_redshiftSettings_EncryptionMode = cmdletContext.RedshiftSettings_EncryptionMode;
            }
            if (requestRedshiftSettings_redshiftSettings_EncryptionMode != null)
            {
                request.RedshiftSettings.EncryptionMode = requestRedshiftSettings_redshiftSettings_EncryptionMode;
                requestRedshiftSettingsIsNull = false;
            }
            System.Int32? requestRedshiftSettings_redshiftSettings_FileTransferUploadStream = null;
            if (cmdletContext.RedshiftSettings_FileTransferUploadStream != null)
            {
                requestRedshiftSettings_redshiftSettings_FileTransferUploadStream = cmdletContext.RedshiftSettings_FileTransferUploadStream.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_FileTransferUploadStream != null)
            {
                request.RedshiftSettings.FileTransferUploadStreams = requestRedshiftSettings_redshiftSettings_FileTransferUploadStream.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.Int32? requestRedshiftSettings_redshiftSettings_LoadTimeout = null;
            if (cmdletContext.RedshiftSettings_LoadTimeout != null)
            {
                requestRedshiftSettings_redshiftSettings_LoadTimeout = cmdletContext.RedshiftSettings_LoadTimeout.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_LoadTimeout != null)
            {
                request.RedshiftSettings.LoadTimeout = requestRedshiftSettings_redshiftSettings_LoadTimeout.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.Int32? requestRedshiftSettings_redshiftSettings_MaxFileSize = null;
            if (cmdletContext.RedshiftSettings_MaxFileSize != null)
            {
                requestRedshiftSettings_redshiftSettings_MaxFileSize = cmdletContext.RedshiftSettings_MaxFileSize.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_MaxFileSize != null)
            {
                request.RedshiftSettings.MaxFileSize = requestRedshiftSettings_redshiftSettings_MaxFileSize.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_Password = null;
            if (cmdletContext.RedshiftSettings_Password != null)
            {
                requestRedshiftSettings_redshiftSettings_Password = cmdletContext.RedshiftSettings_Password;
            }
            if (requestRedshiftSettings_redshiftSettings_Password != null)
            {
                request.RedshiftSettings.Password = requestRedshiftSettings_redshiftSettings_Password;
                requestRedshiftSettingsIsNull = false;
            }
            System.Int32? requestRedshiftSettings_redshiftSettings_Port = null;
            if (cmdletContext.RedshiftSettings_Port != null)
            {
                requestRedshiftSettings_redshiftSettings_Port = cmdletContext.RedshiftSettings_Port.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_Port != null)
            {
                request.RedshiftSettings.Port = requestRedshiftSettings_redshiftSettings_Port.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.Boolean? requestRedshiftSettings_redshiftSettings_RemoveQuote = null;
            if (cmdletContext.RedshiftSettings_RemoveQuote != null)
            {
                requestRedshiftSettings_redshiftSettings_RemoveQuote = cmdletContext.RedshiftSettings_RemoveQuote.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_RemoveQuote != null)
            {
                request.RedshiftSettings.RemoveQuotes = requestRedshiftSettings_redshiftSettings_RemoveQuote.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_ReplaceChar = null;
            if (cmdletContext.RedshiftSettings_ReplaceChar != null)
            {
                requestRedshiftSettings_redshiftSettings_ReplaceChar = cmdletContext.RedshiftSettings_ReplaceChar;
            }
            if (requestRedshiftSettings_redshiftSettings_ReplaceChar != null)
            {
                request.RedshiftSettings.ReplaceChars = requestRedshiftSettings_redshiftSettings_ReplaceChar;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_ReplaceInvalidChar = null;
            if (cmdletContext.RedshiftSettings_ReplaceInvalidChar != null)
            {
                requestRedshiftSettings_redshiftSettings_ReplaceInvalidChar = cmdletContext.RedshiftSettings_ReplaceInvalidChar;
            }
            if (requestRedshiftSettings_redshiftSettings_ReplaceInvalidChar != null)
            {
                request.RedshiftSettings.ReplaceInvalidChars = requestRedshiftSettings_redshiftSettings_ReplaceInvalidChar;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_ServerName = null;
            if (cmdletContext.RedshiftSettings_ServerName != null)
            {
                requestRedshiftSettings_redshiftSettings_ServerName = cmdletContext.RedshiftSettings_ServerName;
            }
            if (requestRedshiftSettings_redshiftSettings_ServerName != null)
            {
                request.RedshiftSettings.ServerName = requestRedshiftSettings_redshiftSettings_ServerName;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_ServerSideEncryptionKmsKeyId = null;
            if (cmdletContext.RedshiftSettings_ServerSideEncryptionKmsKeyId != null)
            {
                requestRedshiftSettings_redshiftSettings_ServerSideEncryptionKmsKeyId = cmdletContext.RedshiftSettings_ServerSideEncryptionKmsKeyId;
            }
            if (requestRedshiftSettings_redshiftSettings_ServerSideEncryptionKmsKeyId != null)
            {
                request.RedshiftSettings.ServerSideEncryptionKmsKeyId = requestRedshiftSettings_redshiftSettings_ServerSideEncryptionKmsKeyId;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_ServiceAccessRoleArn = null;
            if (cmdletContext.RedshiftSettings_ServiceAccessRoleArn != null)
            {
                requestRedshiftSettings_redshiftSettings_ServiceAccessRoleArn = cmdletContext.RedshiftSettings_ServiceAccessRoleArn;
            }
            if (requestRedshiftSettings_redshiftSettings_ServiceAccessRoleArn != null)
            {
                request.RedshiftSettings.ServiceAccessRoleArn = requestRedshiftSettings_redshiftSettings_ServiceAccessRoleArn;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_TimeFormat = null;
            if (cmdletContext.RedshiftSettings_TimeFormat != null)
            {
                requestRedshiftSettings_redshiftSettings_TimeFormat = cmdletContext.RedshiftSettings_TimeFormat;
            }
            if (requestRedshiftSettings_redshiftSettings_TimeFormat != null)
            {
                request.RedshiftSettings.TimeFormat = requestRedshiftSettings_redshiftSettings_TimeFormat;
                requestRedshiftSettingsIsNull = false;
            }
            System.Boolean? requestRedshiftSettings_redshiftSettings_TrimBlank = null;
            if (cmdletContext.RedshiftSettings_TrimBlank != null)
            {
                requestRedshiftSettings_redshiftSettings_TrimBlank = cmdletContext.RedshiftSettings_TrimBlank.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_TrimBlank != null)
            {
                request.RedshiftSettings.TrimBlanks = requestRedshiftSettings_redshiftSettings_TrimBlank.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.Boolean? requestRedshiftSettings_redshiftSettings_TruncateColumn = null;
            if (cmdletContext.RedshiftSettings_TruncateColumn != null)
            {
                requestRedshiftSettings_redshiftSettings_TruncateColumn = cmdletContext.RedshiftSettings_TruncateColumn.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_TruncateColumn != null)
            {
                request.RedshiftSettings.TruncateColumns = requestRedshiftSettings_redshiftSettings_TruncateColumn.Value;
                requestRedshiftSettingsIsNull = false;
            }
            System.String requestRedshiftSettings_redshiftSettings_Username = null;
            if (cmdletContext.RedshiftSettings_Username != null)
            {
                requestRedshiftSettings_redshiftSettings_Username = cmdletContext.RedshiftSettings_Username;
            }
            if (requestRedshiftSettings_redshiftSettings_Username != null)
            {
                request.RedshiftSettings.Username = requestRedshiftSettings_redshiftSettings_Username;
                requestRedshiftSettingsIsNull = false;
            }
            System.Int32? requestRedshiftSettings_redshiftSettings_WriteBufferSize = null;
            if (cmdletContext.RedshiftSettings_WriteBufferSize != null)
            {
                requestRedshiftSettings_redshiftSettings_WriteBufferSize = cmdletContext.RedshiftSettings_WriteBufferSize.Value;
            }
            if (requestRedshiftSettings_redshiftSettings_WriteBufferSize != null)
            {
                request.RedshiftSettings.WriteBufferSize = requestRedshiftSettings_redshiftSettings_WriteBufferSize.Value;
                requestRedshiftSettingsIsNull = false;
            }
             // determine if request.RedshiftSettings should be set to null
            if (requestRedshiftSettingsIsNull)
            {
                request.RedshiftSettings = null;
            }
            
             // populate S3Settings
            var requestS3SettingsIsNull = true;
            request.S3Settings = new Amazon.DatabaseMigrationService.Model.S3Settings();
            System.String requestS3Settings_s3Settings_BucketFolder = null;
            if (cmdletContext.S3Settings_BucketFolder != null)
            {
                requestS3Settings_s3Settings_BucketFolder = cmdletContext.S3Settings_BucketFolder;
            }
            if (requestS3Settings_s3Settings_BucketFolder != null)
            {
                request.S3Settings.BucketFolder = requestS3Settings_s3Settings_BucketFolder;
                requestS3SettingsIsNull = false;
            }
            System.String requestS3Settings_s3Settings_BucketName = null;
            if (cmdletContext.S3Settings_BucketName != null)
            {
                requestS3Settings_s3Settings_BucketName = cmdletContext.S3Settings_BucketName;
            }
            if (requestS3Settings_s3Settings_BucketName != null)
            {
                request.S3Settings.BucketName = requestS3Settings_s3Settings_BucketName;
                requestS3SettingsIsNull = false;
            }
            System.Boolean? requestS3Settings_s3Settings_CdcInsertsAndUpdate = null;
            if (cmdletContext.S3Settings_CdcInsertsAndUpdate != null)
            {
                requestS3Settings_s3Settings_CdcInsertsAndUpdate = cmdletContext.S3Settings_CdcInsertsAndUpdate.Value;
            }
            if (requestS3Settings_s3Settings_CdcInsertsAndUpdate != null)
            {
                request.S3Settings.CdcInsertsAndUpdates = requestS3Settings_s3Settings_CdcInsertsAndUpdate.Value;
                requestS3SettingsIsNull = false;
            }
            System.Boolean? requestS3Settings_s3Settings_CdcInsertsOnly = null;
            if (cmdletContext.S3Settings_CdcInsertsOnly != null)
            {
                requestS3Settings_s3Settings_CdcInsertsOnly = cmdletContext.S3Settings_CdcInsertsOnly.Value;
            }
            if (requestS3Settings_s3Settings_CdcInsertsOnly != null)
            {
                request.S3Settings.CdcInsertsOnly = requestS3Settings_s3Settings_CdcInsertsOnly.Value;
                requestS3SettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.CompressionTypeValue requestS3Settings_s3Settings_CompressionType = null;
            if (cmdletContext.S3Settings_CompressionType != null)
            {
                requestS3Settings_s3Settings_CompressionType = cmdletContext.S3Settings_CompressionType;
            }
            if (requestS3Settings_s3Settings_CompressionType != null)
            {
                request.S3Settings.CompressionType = requestS3Settings_s3Settings_CompressionType;
                requestS3SettingsIsNull = false;
            }
            System.String requestS3Settings_s3Settings_CsvDelimiter = null;
            if (cmdletContext.S3Settings_CsvDelimiter != null)
            {
                requestS3Settings_s3Settings_CsvDelimiter = cmdletContext.S3Settings_CsvDelimiter;
            }
            if (requestS3Settings_s3Settings_CsvDelimiter != null)
            {
                request.S3Settings.CsvDelimiter = requestS3Settings_s3Settings_CsvDelimiter;
                requestS3SettingsIsNull = false;
            }
            System.String requestS3Settings_s3Settings_CsvRowDelimiter = null;
            if (cmdletContext.S3Settings_CsvRowDelimiter != null)
            {
                requestS3Settings_s3Settings_CsvRowDelimiter = cmdletContext.S3Settings_CsvRowDelimiter;
            }
            if (requestS3Settings_s3Settings_CsvRowDelimiter != null)
            {
                request.S3Settings.CsvRowDelimiter = requestS3Settings_s3Settings_CsvRowDelimiter;
                requestS3SettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.DataFormatValue requestS3Settings_s3Settings_DataFormat = null;
            if (cmdletContext.S3Settings_DataFormat != null)
            {
                requestS3Settings_s3Settings_DataFormat = cmdletContext.S3Settings_DataFormat;
            }
            if (requestS3Settings_s3Settings_DataFormat != null)
            {
                request.S3Settings.DataFormat = requestS3Settings_s3Settings_DataFormat;
                requestS3SettingsIsNull = false;
            }
            System.Int32? requestS3Settings_s3Settings_DataPageSize = null;
            if (cmdletContext.S3Settings_DataPageSize != null)
            {
                requestS3Settings_s3Settings_DataPageSize = cmdletContext.S3Settings_DataPageSize.Value;
            }
            if (requestS3Settings_s3Settings_DataPageSize != null)
            {
                request.S3Settings.DataPageSize = requestS3Settings_s3Settings_DataPageSize.Value;
                requestS3SettingsIsNull = false;
            }
            System.Int32? requestS3Settings_s3Settings_DictPageSizeLimit = null;
            if (cmdletContext.S3Settings_DictPageSizeLimit != null)
            {
                requestS3Settings_s3Settings_DictPageSizeLimit = cmdletContext.S3Settings_DictPageSizeLimit.Value;
            }
            if (requestS3Settings_s3Settings_DictPageSizeLimit != null)
            {
                request.S3Settings.DictPageSizeLimit = requestS3Settings_s3Settings_DictPageSizeLimit.Value;
                requestS3SettingsIsNull = false;
            }
            System.Boolean? requestS3Settings_s3Settings_EnableStatistic = null;
            if (cmdletContext.S3Settings_EnableStatistic != null)
            {
                requestS3Settings_s3Settings_EnableStatistic = cmdletContext.S3Settings_EnableStatistic.Value;
            }
            if (requestS3Settings_s3Settings_EnableStatistic != null)
            {
                request.S3Settings.EnableStatistics = requestS3Settings_s3Settings_EnableStatistic.Value;
                requestS3SettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.EncodingTypeValue requestS3Settings_s3Settings_EncodingType = null;
            if (cmdletContext.S3Settings_EncodingType != null)
            {
                requestS3Settings_s3Settings_EncodingType = cmdletContext.S3Settings_EncodingType;
            }
            if (requestS3Settings_s3Settings_EncodingType != null)
            {
                request.S3Settings.EncodingType = requestS3Settings_s3Settings_EncodingType;
                requestS3SettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.EncryptionModeValue requestS3Settings_s3Settings_EncryptionMode = null;
            if (cmdletContext.S3Settings_EncryptionMode != null)
            {
                requestS3Settings_s3Settings_EncryptionMode = cmdletContext.S3Settings_EncryptionMode;
            }
            if (requestS3Settings_s3Settings_EncryptionMode != null)
            {
                request.S3Settings.EncryptionMode = requestS3Settings_s3Settings_EncryptionMode;
                requestS3SettingsIsNull = false;
            }
            System.String requestS3Settings_s3Settings_ExternalTableDefinition = null;
            if (cmdletContext.S3Settings_ExternalTableDefinition != null)
            {
                requestS3Settings_s3Settings_ExternalTableDefinition = cmdletContext.S3Settings_ExternalTableDefinition;
            }
            if (requestS3Settings_s3Settings_ExternalTableDefinition != null)
            {
                request.S3Settings.ExternalTableDefinition = requestS3Settings_s3Settings_ExternalTableDefinition;
                requestS3SettingsIsNull = false;
            }
            System.Boolean? requestS3Settings_s3Settings_IncludeOpForFullLoad = null;
            if (cmdletContext.S3Settings_IncludeOpForFullLoad != null)
            {
                requestS3Settings_s3Settings_IncludeOpForFullLoad = cmdletContext.S3Settings_IncludeOpForFullLoad.Value;
            }
            if (requestS3Settings_s3Settings_IncludeOpForFullLoad != null)
            {
                request.S3Settings.IncludeOpForFullLoad = requestS3Settings_s3Settings_IncludeOpForFullLoad.Value;
                requestS3SettingsIsNull = false;
            }
            System.Boolean? requestS3Settings_s3Settings_ParquetTimestampInMillisecond = null;
            if (cmdletContext.S3Settings_ParquetTimestampInMillisecond != null)
            {
                requestS3Settings_s3Settings_ParquetTimestampInMillisecond = cmdletContext.S3Settings_ParquetTimestampInMillisecond.Value;
            }
            if (requestS3Settings_s3Settings_ParquetTimestampInMillisecond != null)
            {
                request.S3Settings.ParquetTimestampInMillisecond = requestS3Settings_s3Settings_ParquetTimestampInMillisecond.Value;
                requestS3SettingsIsNull = false;
            }
            Amazon.DatabaseMigrationService.ParquetVersionValue requestS3Settings_s3Settings_ParquetVersion = null;
            if (cmdletContext.S3Settings_ParquetVersion != null)
            {
                requestS3Settings_s3Settings_ParquetVersion = cmdletContext.S3Settings_ParquetVersion;
            }
            if (requestS3Settings_s3Settings_ParquetVersion != null)
            {
                request.S3Settings.ParquetVersion = requestS3Settings_s3Settings_ParquetVersion;
                requestS3SettingsIsNull = false;
            }
            System.Int32? requestS3Settings_s3Settings_RowGroupLength = null;
            if (cmdletContext.S3Settings_RowGroupLength != null)
            {
                requestS3Settings_s3Settings_RowGroupLength = cmdletContext.S3Settings_RowGroupLength.Value;
            }
            if (requestS3Settings_s3Settings_RowGroupLength != null)
            {
                request.S3Settings.RowGroupLength = requestS3Settings_s3Settings_RowGroupLength.Value;
                requestS3SettingsIsNull = false;
            }
            System.String requestS3Settings_s3Settings_ServerSideEncryptionKmsKeyId = null;
            if (cmdletContext.S3Settings_ServerSideEncryptionKmsKeyId != null)
            {
                requestS3Settings_s3Settings_ServerSideEncryptionKmsKeyId = cmdletContext.S3Settings_ServerSideEncryptionKmsKeyId;
            }
            if (requestS3Settings_s3Settings_ServerSideEncryptionKmsKeyId != null)
            {
                request.S3Settings.ServerSideEncryptionKmsKeyId = requestS3Settings_s3Settings_ServerSideEncryptionKmsKeyId;
                requestS3SettingsIsNull = false;
            }
            System.String requestS3Settings_s3Settings_ServiceAccessRoleArn = null;
            if (cmdletContext.S3Settings_ServiceAccessRoleArn != null)
            {
                requestS3Settings_s3Settings_ServiceAccessRoleArn = cmdletContext.S3Settings_ServiceAccessRoleArn;
            }
            if (requestS3Settings_s3Settings_ServiceAccessRoleArn != null)
            {
                request.S3Settings.ServiceAccessRoleArn = requestS3Settings_s3Settings_ServiceAccessRoleArn;
                requestS3SettingsIsNull = false;
            }
            System.String requestS3Settings_s3Settings_TimestampColumnName = null;
            if (cmdletContext.S3Settings_TimestampColumnName != null)
            {
                requestS3Settings_s3Settings_TimestampColumnName = cmdletContext.S3Settings_TimestampColumnName;
            }
            if (requestS3Settings_s3Settings_TimestampColumnName != null)
            {
                request.S3Settings.TimestampColumnName = requestS3Settings_s3Settings_TimestampColumnName;
                requestS3SettingsIsNull = false;
            }
             // determine if request.S3Settings should be set to null
            if (requestS3SettingsIsNull)
            {
                request.S3Settings = null;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
            }
            if (cmdletContext.ServiceAccessRoleArn != null)
            {
                request.ServiceAccessRoleArn = cmdletContext.ServiceAccessRoleArn;
            }
            if (cmdletContext.SslMode != null)
            {
                request.SslMode = cmdletContext.SslMode;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
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
        
        private Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ModifyEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ModifyEndpoint");
            try
            {
                #if DESKTOP
                return client.ModifyEndpoint(request);
                #elif CORECLR
                return client.ModifyEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateArn { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String DmsTransferSettings_BucketName { get; set; }
            public System.String DmsTransferSettings_ServiceAccessRoleArn { get; set; }
            public System.String DynamoDbSettings_ServiceAccessRoleArn { get; set; }
            public System.String ElasticsearchSettings_EndpointUri { get; set; }
            public System.Int32? ElasticsearchSettings_ErrorRetryDuration { get; set; }
            public System.Int32? ElasticsearchSettings_FullLoadErrorPercentage { get; set; }
            public System.String ElasticsearchSettings_ServiceAccessRoleArn { get; set; }
            public System.String EndpointArn { get; set; }
            public System.String EndpointIdentifier { get; set; }
            public Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue EndpointType { get; set; }
            public System.String EngineName { get; set; }
            public System.String ExternalTableDefinition { get; set; }
            public System.String ExtraConnectionAttribute { get; set; }
            public System.String KafkaSettings_Broker { get; set; }
            public System.String KafkaSettings_Topic { get; set; }
            public System.Boolean? KinesisSettings_IncludeControlDetail { get; set; }
            public System.Boolean? KinesisSettings_IncludePartitionValue { get; set; }
            public System.Boolean? KinesisSettings_IncludeTableAlterOperation { get; set; }
            public System.Boolean? KinesisSettings_IncludeTransactionDetail { get; set; }
            public Amazon.DatabaseMigrationService.MessageFormatValue KinesisSettings_MessageFormat { get; set; }
            public System.Boolean? KinesisSettings_PartitionIncludeSchemaTable { get; set; }
            public System.String KinesisSettings_ServiceAccessRoleArn { get; set; }
            public System.String KinesisSettings_StreamArn { get; set; }
            public Amazon.DatabaseMigrationService.AuthMechanismValue MongoDbSettings_AuthMechanism { get; set; }
            public System.String MongoDbSettings_AuthSource { get; set; }
            public Amazon.DatabaseMigrationService.AuthTypeValue MongoDbSettings_AuthType { get; set; }
            public System.String MongoDbSettings_DatabaseName { get; set; }
            public System.String MongoDbSettings_DocsToInvestigate { get; set; }
            public System.String MongoDbSettings_ExtractDocId { get; set; }
            public System.String MongoDbSettings_KmsKeyId { get; set; }
            public Amazon.DatabaseMigrationService.NestingLevelValue MongoDbSettings_NestingLevel { get; set; }
            public System.String MongoDbSettings_Password { get; set; }
            public System.Int32? MongoDbSettings_Port { get; set; }
            public System.String MongoDbSettings_ServerName { get; set; }
            public System.String MongoDbSettings_Username { get; set; }
            public System.String Password { get; set; }
            public System.Int32? Port { get; set; }
            public System.Boolean? RedshiftSettings_AcceptAnyDate { get; set; }
            public System.String RedshiftSettings_AfterConnectScript { get; set; }
            public System.String RedshiftSettings_BucketFolder { get; set; }
            public System.String RedshiftSettings_BucketName { get; set; }
            public System.Int32? RedshiftSettings_ConnectionTimeout { get; set; }
            public System.String RedshiftSettings_DatabaseName { get; set; }
            public System.String RedshiftSettings_DateFormat { get; set; }
            public System.Boolean? RedshiftSettings_EmptyAsNull { get; set; }
            public Amazon.DatabaseMigrationService.EncryptionModeValue RedshiftSettings_EncryptionMode { get; set; }
            public System.Int32? RedshiftSettings_FileTransferUploadStream { get; set; }
            public System.Int32? RedshiftSettings_LoadTimeout { get; set; }
            public System.Int32? RedshiftSettings_MaxFileSize { get; set; }
            public System.String RedshiftSettings_Password { get; set; }
            public System.Int32? RedshiftSettings_Port { get; set; }
            public System.Boolean? RedshiftSettings_RemoveQuote { get; set; }
            public System.String RedshiftSettings_ReplaceChar { get; set; }
            public System.String RedshiftSettings_ReplaceInvalidChar { get; set; }
            public System.String RedshiftSettings_ServerName { get; set; }
            public System.String RedshiftSettings_ServerSideEncryptionKmsKeyId { get; set; }
            public System.String RedshiftSettings_ServiceAccessRoleArn { get; set; }
            public System.String RedshiftSettings_TimeFormat { get; set; }
            public System.Boolean? RedshiftSettings_TrimBlank { get; set; }
            public System.Boolean? RedshiftSettings_TruncateColumn { get; set; }
            public System.String RedshiftSettings_Username { get; set; }
            public System.Int32? RedshiftSettings_WriteBufferSize { get; set; }
            public System.String S3Settings_BucketFolder { get; set; }
            public System.String S3Settings_BucketName { get; set; }
            public System.Boolean? S3Settings_CdcInsertsAndUpdate { get; set; }
            public System.Boolean? S3Settings_CdcInsertsOnly { get; set; }
            public Amazon.DatabaseMigrationService.CompressionTypeValue S3Settings_CompressionType { get; set; }
            public System.String S3Settings_CsvDelimiter { get; set; }
            public System.String S3Settings_CsvRowDelimiter { get; set; }
            public Amazon.DatabaseMigrationService.DataFormatValue S3Settings_DataFormat { get; set; }
            public System.Int32? S3Settings_DataPageSize { get; set; }
            public System.Int32? S3Settings_DictPageSizeLimit { get; set; }
            public System.Boolean? S3Settings_EnableStatistic { get; set; }
            public Amazon.DatabaseMigrationService.EncodingTypeValue S3Settings_EncodingType { get; set; }
            public Amazon.DatabaseMigrationService.EncryptionModeValue S3Settings_EncryptionMode { get; set; }
            public System.String S3Settings_ExternalTableDefinition { get; set; }
            public System.Boolean? S3Settings_IncludeOpForFullLoad { get; set; }
            public System.Boolean? S3Settings_ParquetTimestampInMillisecond { get; set; }
            public Amazon.DatabaseMigrationService.ParquetVersionValue S3Settings_ParquetVersion { get; set; }
            public System.Int32? S3Settings_RowGroupLength { get; set; }
            public System.String S3Settings_ServerSideEncryptionKmsKeyId { get; set; }
            public System.String S3Settings_ServiceAccessRoleArn { get; set; }
            public System.String S3Settings_TimestampColumnName { get; set; }
            public System.String ServerName { get; set; }
            public System.String ServiceAccessRoleArn { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue SslMode { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.ModifyEndpointResponse, EditDMSEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Endpoint;
        }
        
    }
}
