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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates an endpoint using the provided settings.
    /// </summary>
    [Cmdlet("New", "DMSEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.Endpoint")]
    [AWSCmdlet("Calls the AWS Database Migration Service CreateEndpoint API operation.", Operation = new[] {"CreateEndpoint"})]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.Endpoint",
        "This cmdlet returns a Endpoint object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDMSEndpointCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter MongoDbSettings_AuthMechanism
        /// <summary>
        /// <para>
        /// <para> The authentication mechanism you use to access the MongoDB source endpoint.</para><para>Valid values: DEFAULT, MONGODB_CR, SCRAM_SHA_1 </para><para>DEFAULT – For MongoDB version 2.x, use MONGODB_CR. For MongoDB version 3.x, use SCRAM_SHA_1.
        /// This attribute is not used when authType=No.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.AuthMechanismValue")]
        public Amazon.DatabaseMigrationService.AuthMechanismValue MongoDbSettings_AuthMechanism { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthSource
        /// <summary>
        /// <para>
        /// <para> The MongoDB database name. This attribute is not used when <code>authType=NO</code>.
        /// </para><para>The default is admin.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_AuthSource { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_AuthType
        /// <summary>
        /// <para>
        /// <para> The authentication type you use to access the MongoDB source endpoint.</para><para>Valid values: NO, PASSWORD </para><para>When NO is selected, user name and password parameters are not used and can be empty.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.AuthTypeValue")]
        public Amazon.DatabaseMigrationService.AuthTypeValue MongoDbSettings_AuthType { get; set; }
        #endregion
        
        #region Parameter S3Settings_BucketFolder
        /// <summary>
        /// <para>
        /// <para> An optional parameter to set a folder name in the S3 bucket. If provided, tables
        /// are created in the path &lt;bucketFolder&gt;/&lt;schema_name&gt;/&lt;table_name&gt;/.
        /// If this parameter is not specified, then the path used is &lt;schema_name&gt;/&lt;table_name&gt;/.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Settings_BucketFolder { get; set; }
        #endregion
        
        #region Parameter DmsTransferSettings_BucketName
        /// <summary>
        /// <para>
        /// <para> The name of the S3 bucket to use. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DmsTransferSettings_BucketName { get; set; }
        #endregion
        
        #region Parameter S3Settings_BucketName
        /// <summary>
        /// <para>
        /// <para> The name of the S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Settings_BucketName { get; set; }
        #endregion
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter S3Settings_CompressionType
        /// <summary>
        /// <para>
        /// <para> An optional parameter to use GZIP to compress the target files. Set to GZIP to compress
        /// the target files. Set to NONE (the default) or do not use to leave the files uncompressed.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.CompressionTypeValue")]
        public Amazon.DatabaseMigrationService.CompressionTypeValue S3Settings_CompressionType { get; set; }
        #endregion
        
        #region Parameter S3Settings_CsvDelimiter
        /// <summary>
        /// <para>
        /// <para> The delimiter used to separate columns in the source files. The default is a comma.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Settings_CsvDelimiter { get; set; }
        #endregion
        
        #region Parameter S3Settings_CsvRowDelimiter
        /// <summary>
        /// <para>
        /// <para> The delimiter used to separate rows in the source files. The default is a carriage
        /// return (\n). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_DatabaseName { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_DocsToInvestigate
        /// <summary>
        /// <para>
        /// <para> Indicates the number of documents to preview to determine the document organization.
        /// Use this attribute when <code>NestingLevel</code> is set to ONE. </para><para>Must be a positive value greater than 0. Default value is 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_DocsToInvestigate { get; set; }
        #endregion
        
        #region Parameter EndpointIdentifier
        /// <summary>
        /// <para>
        /// <para>The database endpoint identifier. Identifiers must begin with a letter; must contain
        /// only ASCII letters, digits, and hyphens; and must not end with a hyphen or contain
        /// two consecutive hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EndpointIdentifier { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue")]
        public Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue EndpointType { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_EndpointUri
        /// <summary>
        /// <para>
        /// <para>The endpoint for the ElasticSearch cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchSettings_EndpointUri { get; set; }
        #endregion
        
        #region Parameter EngineName
        /// <summary>
        /// <para>
        /// <para>The type of engine for the endpoint. Valid values, depending on the <code>EndPointType</code>
        /// value, include <code>mysql</code>, <code>oracle</code>, <code>postgres</code>, <code>mariadb</code>,
        /// <code>aurora</code>, <code>aurora-postgresql</code>, <code>redshift</code>, <code>s3</code>,
        /// <code>db2</code>, <code>azuredb</code>, <code>sybase</code>, <code>dynamodb</code>,
        /// <code>mongodb</code>, and <code>sqlserver</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineName { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_ErrorRetryDuration
        /// <summary>
        /// <para>
        /// <para>The maximum number of seconds that DMS retries failed API requests to the Elasticsearch
        /// cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ElasticsearchSettings_ErrorRetryDuration { get; set; }
        #endregion
        
        #region Parameter ExternalTableDefinition
        /// <summary>
        /// <para>
        /// <para>The external table definition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExternalTableDefinition { get; set; }
        #endregion
        
        #region Parameter S3Settings_ExternalTableDefinition
        /// <summary>
        /// <para>
        /// <para> The external table definition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Settings_ExternalTableDefinition { get; set; }
        #endregion
        
        #region Parameter ExtraConnectionAttribute
        /// <summary>
        /// <para>
        /// <para>Additional attributes associated with the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ExtraConnectionAttributes")]
        public System.String ExtraConnectionAttribute { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_ExtractDocId
        /// <summary>
        /// <para>
        /// <para> Specifies the document ID. Use this attribute when <code>NestingLevel</code> is set
        /// to NONE. </para><para>Default value is false. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_ExtractDocId { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_FullLoadErrorPercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of records that can fail to be written before a full load operation
        /// stops. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ElasticsearchSettings_FullLoadErrorPercentage { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key identifier to use to encrypt the connection parameters. If you don't
        /// specify a value for the <code>KmsKeyId</code> parameter, then AWS DMS uses your default
        /// encryption key. AWS KMS creates the default encryption key for your AWS account. Your
        /// AWS account has a different default encryption key for each AWS Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
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
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_MessageFormat
        /// <summary>
        /// <para>
        /// <para>The output format for the records created on the endpoint. The message format is <code>JSON</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.NestingLevelValue")]
        public Amazon.DatabaseMigrationService.NestingLevelValue MongoDbSettings_NestingLevel { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_Password
        /// <summary>
        /// <para>
        /// <para> The password for the user account you use to access the MongoDB source endpoint.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_Password { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password to be used to log in to the endpoint database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_Port
        /// <summary>
        /// <para>
        /// <para> The port value for the MongoDB source endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MongoDbSettings_Port { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port used by the endpoint database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_ServerName
        /// <summary>
        /// <para>
        /// <para> The name of the server on the MongoDB source endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_ServerName { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para>The name of the server where the endpoint database resides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter DmsTransferSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The IAM role that has permission to access the Amazon S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DmsTransferSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter DynamoDbSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) used by the service access IAM role. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DynamoDbSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter ElasticsearchSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) used by service to access the IAM role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticsearchSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the IAM role that DMS uses to write to the Amazon
        /// Kinesis data stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KinesisSettings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter S3Settings_ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) used by the service access IAM role. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3Settings_ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) for the service access role that you want to use to
        /// create the endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter SslMode
        /// <summary>
        /// <para>
        /// <para>The Secure Sockets Layer (SSL) mode to use for the SSL connection. The SSL mode can
        /// be one of four values: <code>none</code>, <code>require</code>, <code>verify-ca</code>,
        /// <code>verify-full</code>. The default value is <code>none</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.DmsSslModeValue")]
        public Amazon.DatabaseMigrationService.DmsSslModeValue SslMode { get; set; }
        #endregion
        
        #region Parameter KinesisSettings_StreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Amazon Kinesis Data Streams endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KinesisSettings_StreamArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be added to the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter MongoDbSettings_Username
        /// <summary>
        /// <para>
        /// <para>The user name you use to access the MongoDB source endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MongoDbSettings_Username { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The user name to be used to log in to the endpoint database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Username { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EndpointIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSEndpoint (CreateEndpoint)"))
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
            
            context.CertificateArn = this.CertificateArn;
            context.DatabaseName = this.DatabaseName;
            context.DmsTransferSettings_BucketName = this.DmsTransferSettings_BucketName;
            context.DmsTransferSettings_ServiceAccessRoleArn = this.DmsTransferSettings_ServiceAccessRoleArn;
            context.DynamoDbSettings_ServiceAccessRoleArn = this.DynamoDbSettings_ServiceAccessRoleArn;
            context.ElasticsearchSettings_EndpointUri = this.ElasticsearchSettings_EndpointUri;
            if (ParameterWasBound("ElasticsearchSettings_ErrorRetryDuration"))
                context.ElasticsearchSettings_ErrorRetryDuration = this.ElasticsearchSettings_ErrorRetryDuration;
            if (ParameterWasBound("ElasticsearchSettings_FullLoadErrorPercentage"))
                context.ElasticsearchSettings_FullLoadErrorPercentage = this.ElasticsearchSettings_FullLoadErrorPercentage;
            context.ElasticsearchSettings_ServiceAccessRoleArn = this.ElasticsearchSettings_ServiceAccessRoleArn;
            context.EndpointIdentifier = this.EndpointIdentifier;
            context.EndpointType = this.EndpointType;
            context.EngineName = this.EngineName;
            context.ExternalTableDefinition = this.ExternalTableDefinition;
            context.ExtraConnectionAttributes = this.ExtraConnectionAttribute;
            context.KinesisSettings_MessageFormat = this.KinesisSettings_MessageFormat;
            context.KinesisSettings_ServiceAccessRoleArn = this.KinesisSettings_ServiceAccessRoleArn;
            context.KinesisSettings_StreamArn = this.KinesisSettings_StreamArn;
            context.KmsKeyId = this.KmsKeyId;
            context.MongoDbSettings_AuthMechanism = this.MongoDbSettings_AuthMechanism;
            context.MongoDbSettings_AuthSource = this.MongoDbSettings_AuthSource;
            context.MongoDbSettings_AuthType = this.MongoDbSettings_AuthType;
            context.MongoDbSettings_DatabaseName = this.MongoDbSettings_DatabaseName;
            context.MongoDbSettings_DocsToInvestigate = this.MongoDbSettings_DocsToInvestigate;
            context.MongoDbSettings_ExtractDocId = this.MongoDbSettings_ExtractDocId;
            context.MongoDbSettings_KmsKeyId = this.MongoDbSettings_KmsKeyId;
            context.MongoDbSettings_NestingLevel = this.MongoDbSettings_NestingLevel;
            context.MongoDbSettings_Password = this.MongoDbSettings_Password;
            if (ParameterWasBound("MongoDbSettings_Port"))
                context.MongoDbSettings_Port = this.MongoDbSettings_Port;
            context.MongoDbSettings_ServerName = this.MongoDbSettings_ServerName;
            context.MongoDbSettings_Username = this.MongoDbSettings_Username;
            context.Password = this.Password;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.S3Settings_BucketFolder = this.S3Settings_BucketFolder;
            context.S3Settings_BucketName = this.S3Settings_BucketName;
            context.S3Settings_CompressionType = this.S3Settings_CompressionType;
            context.S3Settings_CsvDelimiter = this.S3Settings_CsvDelimiter;
            context.S3Settings_CsvRowDelimiter = this.S3Settings_CsvRowDelimiter;
            context.S3Settings_ExternalTableDefinition = this.S3Settings_ExternalTableDefinition;
            context.S3Settings_ServiceAccessRoleArn = this.S3Settings_ServiceAccessRoleArn;
            context.ServerName = this.ServerName;
            context.ServiceAccessRoleArn = this.ServiceAccessRoleArn;
            context.SslMode = this.SslMode;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.DatabaseMigrationService.Model.CreateEndpointRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            
             // populate DmsTransferSettings
            bool requestDmsTransferSettingsIsNull = true;
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
            bool requestDynamoDbSettingsIsNull = true;
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
            bool requestElasticsearchSettingsIsNull = true;
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
            if (cmdletContext.ExtraConnectionAttributes != null)
            {
                request.ExtraConnectionAttributes = cmdletContext.ExtraConnectionAttributes;
            }
            
             // populate KinesisSettings
            bool requestKinesisSettingsIsNull = true;
            request.KinesisSettings = new Amazon.DatabaseMigrationService.Model.KinesisSettings();
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
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate MongoDbSettings
            bool requestMongoDbSettingsIsNull = true;
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
            
             // populate S3Settings
            bool requestS3SettingsIsNull = true;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Endpoint;
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
        
        private Amazon.DatabaseMigrationService.Model.CreateEndpointResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CreateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CreateEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateEndpoint(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateEndpointAsync(request);
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
            public System.String CertificateArn { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String DmsTransferSettings_BucketName { get; set; }
            public System.String DmsTransferSettings_ServiceAccessRoleArn { get; set; }
            public System.String DynamoDbSettings_ServiceAccessRoleArn { get; set; }
            public System.String ElasticsearchSettings_EndpointUri { get; set; }
            public System.Int32? ElasticsearchSettings_ErrorRetryDuration { get; set; }
            public System.Int32? ElasticsearchSettings_FullLoadErrorPercentage { get; set; }
            public System.String ElasticsearchSettings_ServiceAccessRoleArn { get; set; }
            public System.String EndpointIdentifier { get; set; }
            public Amazon.DatabaseMigrationService.ReplicationEndpointTypeValue EndpointType { get; set; }
            public System.String EngineName { get; set; }
            public System.String ExternalTableDefinition { get; set; }
            public System.String ExtraConnectionAttributes { get; set; }
            public Amazon.DatabaseMigrationService.MessageFormatValue KinesisSettings_MessageFormat { get; set; }
            public System.String KinesisSettings_ServiceAccessRoleArn { get; set; }
            public System.String KinesisSettings_StreamArn { get; set; }
            public System.String KmsKeyId { get; set; }
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
            public System.String S3Settings_BucketFolder { get; set; }
            public System.String S3Settings_BucketName { get; set; }
            public Amazon.DatabaseMigrationService.CompressionTypeValue S3Settings_CompressionType { get; set; }
            public System.String S3Settings_CsvDelimiter { get; set; }
            public System.String S3Settings_CsvRowDelimiter { get; set; }
            public System.String S3Settings_ExternalTableDefinition { get; set; }
            public System.String S3Settings_ServiceAccessRoleArn { get; set; }
            public System.String ServerName { get; set; }
            public System.String ServiceAccessRoleArn { get; set; }
            public Amazon.DatabaseMigrationService.DmsSslModeValue SslMode { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tags { get; set; }
            public System.String Username { get; set; }
        }
        
    }
}
