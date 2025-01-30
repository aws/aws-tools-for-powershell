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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Imports table data from an S3 bucket.
    /// </summary>
    [Cmdlet("Import", "DDBTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.ImportTableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB ImportTable API operation.", Operation = new[] {"ImportTable"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.ImportTableResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ImportTableDescription or Amazon.DynamoDBv2.Model.ImportTableResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.ImportTableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.ImportTableResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportDDBTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TableCreationParameters_AttributeDefinition
        /// <summary>
        /// <para>
        /// <para> The attributes of the table created as part of the import operation. </para>
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
        [Alias("TableCreationParameters_AttributeDefinitions")]
        public Amazon.DynamoDBv2.Model.AttributeDefinition[] TableCreationParameters_AttributeDefinition { get; set; }
        #endregion
        
        #region Parameter TableCreationParameters_BillingMode
        /// <summary>
        /// <para>
        /// <para> The billing mode for provisioning the table created as part of the import operation.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BillingMode")]
        public Amazon.DynamoDBv2.BillingMode TableCreationParameters_BillingMode { get; set; }
        #endregion
        
        #region Parameter Csv_Delimiter
        /// <summary>
        /// <para>
        /// <para> The delimiter used for separating items in the CSV file being imported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputFormatOptions_Csv_Delimiter")]
        public System.String Csv_Delimiter { get; set; }
        #endregion
        
        #region Parameter SSESpecification_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether server-side encryption is done using an Amazon Web Services managed
        /// key or an Amazon Web Services owned key. If enabled (true), server-side encryption
        /// type is set to <c>KMS</c> and an Amazon Web Services managed key is used (KMS charges
        /// apply). If disabled (false) or not specified, server-side encryption is set to Amazon
        /// Web Services owned key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_SSESpecification_Enabled")]
        public System.Boolean? SSESpecification_Enabled { get; set; }
        #endregion
        
        #region Parameter TableCreationParameters_GlobalSecondaryIndex
        /// <summary>
        /// <para>
        /// <para> The Global Secondary Indexes (GSI) of the table to be created as part of the import
        /// operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_GlobalSecondaryIndexes")]
        public Amazon.DynamoDBv2.Model.GlobalSecondaryIndex[] TableCreationParameters_GlobalSecondaryIndex { get; set; }
        #endregion
        
        #region Parameter Csv_HeaderList
        /// <summary>
        /// <para>
        /// <para> List of the headers used to specify a common header for all source CSV files being
        /// imported. If this field is specified then the first line of each CSV file is treated
        /// as data instead of the header. If this field is not specified the the first line of
        /// each CSV file is treated as the header. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputFormatOptions_Csv_HeaderList")]
        public System.String[] Csv_HeaderList { get; set; }
        #endregion
        
        #region Parameter InputCompressionType
        /// <summary>
        /// <para>
        /// <para> Type of compression to be used on the input coming from the imported table. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.InputCompressionType")]
        public Amazon.DynamoDBv2.InputCompressionType InputCompressionType { get; set; }
        #endregion
        
        #region Parameter InputFormat
        /// <summary>
        /// <para>
        /// <para> The format of the source data. Valid values for <c>ImportFormat</c> are <c>CSV</c>,
        /// <c>DYNAMODB_JSON</c> or <c>ION</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DynamoDBv2.InputFormat")]
        public Amazon.DynamoDBv2.InputFormat InputFormat { get; set; }
        #endregion
        
        #region Parameter TableCreationParameters_KeySchema
        /// <summary>
        /// <para>
        /// <para> The primary key and option sort key of the table created as part of the import operation.
        /// </para>
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
        public Amazon.DynamoDBv2.Model.KeySchemaElement[] TableCreationParameters_KeySchema { get; set; }
        #endregion
        
        #region Parameter SSESpecification_KMSMasterKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key that should be used for the KMS encryption. To specify a key, use its
        /// key ID, Amazon Resource Name (ARN), alias name, or alias ARN. Note that you should
        /// only provide this parameter if the key is different from the default DynamoDB key
        /// <c>alias/aws/dynamodb</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_SSESpecification_KMSMasterKeyId")]
        public System.String SSESpecification_KMSMasterKeyId { get; set; }
        #endregion
        
        #region Parameter OnDemandThroughput_MaxReadRequestUnit
        /// <summary>
        /// <para>
        /// <para>Maximum number of read request units for the specified table.</para><para>To specify a maximum <c>OnDemandThroughput</c> on your table, set the value of <c>MaxReadRequestUnits</c>
        /// as greater than or equal to 1. To remove the maximum <c>OnDemandThroughput</c> that
        /// is currently set on your table, set the value of <c>MaxReadRequestUnits</c> to -1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_OnDemandThroughput_MaxReadRequestUnits")]
        public System.Int64? OnDemandThroughput_MaxReadRequestUnit { get; set; }
        #endregion
        
        #region Parameter OnDemandThroughput_MaxWriteRequestUnit
        /// <summary>
        /// <para>
        /// <para>Maximum number of write request units for the specified table.</para><para>To specify a maximum <c>OnDemandThroughput</c> on your table, set the value of <c>MaxWriteRequestUnits</c>
        /// as greater than or equal to 1. To remove the maximum <c>OnDemandThroughput</c> that
        /// is currently set on your table, set the value of <c>MaxWriteRequestUnits</c> to -1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_OnDemandThroughput_MaxWriteRequestUnits")]
        public System.Int64? OnDemandThroughput_MaxWriteRequestUnit { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughput_ReadCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of strongly consistent reads consumed per second before DynamoDB
        /// returns a <c>ThrottlingException</c>. For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ProvisionedThroughput.html">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>If read/write capacity mode is <c>PAY_PER_REQUEST</c> the value is set to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_ProvisionedThroughput_ReadCapacityUnits")]
        public System.Int64? ProvisionedThroughput_ReadCapacityUnit { get; set; }
        #endregion
        
        #region Parameter S3BucketSource_S3Bucket
        /// <summary>
        /// <para>
        /// <para> The S3 bucket that is being imported from. </para>
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
        public System.String S3BucketSource_S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3BucketSource_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para> The account number of the S3 bucket that is being imported from. If the bucket is
        /// owned by the requester this is optional. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3BucketSource_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter S3BucketSource_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para> The key prefix shared by all S3 Objects that are being imported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3BucketSource_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter SSESpecification_SSEType
        /// <summary>
        /// <para>
        /// <para>Server-side encryption type. The only supported value is:</para><ul><li><para><c>KMS</c> - Server-side encryption that uses Key Management Service. The key is
        /// stored in your account and is managed by KMS (KMS charges apply).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_SSESpecification_SSEType")]
        [AWSConstantClassSource("Amazon.DynamoDBv2.SSEType")]
        public Amazon.DynamoDBv2.SSEType SSESpecification_SSEType { get; set; }
        #endregion
        
        #region Parameter TableCreationParameters_TableName
        /// <summary>
        /// <para>
        /// <para> The name of the table created as part of the import operation. </para>
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
        public System.String TableCreationParameters_TableName { get; set; }
        #endregion
        
        #region Parameter ProvisionedThroughput_WriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of writes consumed per second before DynamoDB returns a <c>ThrottlingException</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/ProvisionedThroughput.html">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para><para>If read/write capacity mode is <c>PAY_PER_REQUEST</c> the value is set to 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TableCreationParameters_ProvisionedThroughput_WriteCapacityUnits")]
        public System.Int64? ProvisionedThroughput_WriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Providing a <c>ClientToken</c> makes the call to <c>ImportTableInput</c> idempotent,
        /// meaning that multiple identical calls have the same effect as one single call.</para><para>A client token is valid for 8 hours after the first request that uses it is completed.
        /// After 8 hours, any request with the same client token is treated as a new request.
        /// Do not resubmit the same request with the same client token for more than 8 hours,
        /// or the result might not be idempotent.</para><para>If you submit a request with the same client token but a change in other parameters
        /// within the 8-hour idempotency window, DynamoDB returns an <c>IdempotentParameterMismatch</c>
        /// exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImportTableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.ImportTableResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.ImportTableResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImportTableDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InputFormat parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InputFormat' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InputFormat' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableCreationParameters_TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-DDBTable (ImportTable)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.ImportTableResponse, ImportDDBTableCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InputFormat;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.InputCompressionType = this.InputCompressionType;
            context.InputFormat = this.InputFormat;
            #if MODULAR
            if (this.InputFormat == null && ParameterWasBound(nameof(this.InputFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter InputFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Csv_Delimiter = this.Csv_Delimiter;
            if (this.Csv_HeaderList != null)
            {
                context.Csv_HeaderList = new List<System.String>(this.Csv_HeaderList);
            }
            context.S3BucketSource_S3Bucket = this.S3BucketSource_S3Bucket;
            #if MODULAR
            if (this.S3BucketSource_S3Bucket == null && ParameterWasBound(nameof(this.S3BucketSource_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketSource_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3BucketSource_S3BucketOwner = this.S3BucketSource_S3BucketOwner;
            context.S3BucketSource_S3KeyPrefix = this.S3BucketSource_S3KeyPrefix;
            if (this.TableCreationParameters_AttributeDefinition != null)
            {
                context.TableCreationParameters_AttributeDefinition = new List<Amazon.DynamoDBv2.Model.AttributeDefinition>(this.TableCreationParameters_AttributeDefinition);
            }
            #if MODULAR
            if (this.TableCreationParameters_AttributeDefinition == null && ParameterWasBound(nameof(this.TableCreationParameters_AttributeDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter TableCreationParameters_AttributeDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableCreationParameters_BillingMode = this.TableCreationParameters_BillingMode;
            if (this.TableCreationParameters_GlobalSecondaryIndex != null)
            {
                context.TableCreationParameters_GlobalSecondaryIndex = new List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndex>(this.TableCreationParameters_GlobalSecondaryIndex);
            }
            if (this.TableCreationParameters_KeySchema != null)
            {
                context.TableCreationParameters_KeySchema = new List<Amazon.DynamoDBv2.Model.KeySchemaElement>(this.TableCreationParameters_KeySchema);
            }
            #if MODULAR
            if (this.TableCreationParameters_KeySchema == null && ParameterWasBound(nameof(this.TableCreationParameters_KeySchema)))
            {
                WriteWarning("You are passing $null as a value for parameter TableCreationParameters_KeySchema which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnDemandThroughput_MaxReadRequestUnit = this.OnDemandThroughput_MaxReadRequestUnit;
            context.OnDemandThroughput_MaxWriteRequestUnit = this.OnDemandThroughput_MaxWriteRequestUnit;
            context.ProvisionedThroughput_ReadCapacityUnit = this.ProvisionedThroughput_ReadCapacityUnit;
            context.ProvisionedThroughput_WriteCapacityUnit = this.ProvisionedThroughput_WriteCapacityUnit;
            context.SSESpecification_Enabled = this.SSESpecification_Enabled;
            context.SSESpecification_KMSMasterKeyId = this.SSESpecification_KMSMasterKeyId;
            context.SSESpecification_SSEType = this.SSESpecification_SSEType;
            context.TableCreationParameters_TableName = this.TableCreationParameters_TableName;
            #if MODULAR
            if (this.TableCreationParameters_TableName == null && ParameterWasBound(nameof(this.TableCreationParameters_TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableCreationParameters_TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.ImportTableRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InputCompressionType != null)
            {
                request.InputCompressionType = cmdletContext.InputCompressionType;
            }
            if (cmdletContext.InputFormat != null)
            {
                request.InputFormat = cmdletContext.InputFormat;
            }
            
             // populate InputFormatOptions
            var requestInputFormatOptionsIsNull = true;
            request.InputFormatOptions = new Amazon.DynamoDBv2.Model.InputFormatOptions();
            Amazon.DynamoDBv2.Model.CsvOptions requestInputFormatOptions_inputFormatOptions_Csv = null;
            
             // populate Csv
            var requestInputFormatOptions_inputFormatOptions_CsvIsNull = true;
            requestInputFormatOptions_inputFormatOptions_Csv = new Amazon.DynamoDBv2.Model.CsvOptions();
            System.String requestInputFormatOptions_inputFormatOptions_Csv_csv_Delimiter = null;
            if (cmdletContext.Csv_Delimiter != null)
            {
                requestInputFormatOptions_inputFormatOptions_Csv_csv_Delimiter = cmdletContext.Csv_Delimiter;
            }
            if (requestInputFormatOptions_inputFormatOptions_Csv_csv_Delimiter != null)
            {
                requestInputFormatOptions_inputFormatOptions_Csv.Delimiter = requestInputFormatOptions_inputFormatOptions_Csv_csv_Delimiter;
                requestInputFormatOptions_inputFormatOptions_CsvIsNull = false;
            }
            List<System.String> requestInputFormatOptions_inputFormatOptions_Csv_csv_HeaderList = null;
            if (cmdletContext.Csv_HeaderList != null)
            {
                requestInputFormatOptions_inputFormatOptions_Csv_csv_HeaderList = cmdletContext.Csv_HeaderList;
            }
            if (requestInputFormatOptions_inputFormatOptions_Csv_csv_HeaderList != null)
            {
                requestInputFormatOptions_inputFormatOptions_Csv.HeaderList = requestInputFormatOptions_inputFormatOptions_Csv_csv_HeaderList;
                requestInputFormatOptions_inputFormatOptions_CsvIsNull = false;
            }
             // determine if requestInputFormatOptions_inputFormatOptions_Csv should be set to null
            if (requestInputFormatOptions_inputFormatOptions_CsvIsNull)
            {
                requestInputFormatOptions_inputFormatOptions_Csv = null;
            }
            if (requestInputFormatOptions_inputFormatOptions_Csv != null)
            {
                request.InputFormatOptions.Csv = requestInputFormatOptions_inputFormatOptions_Csv;
                requestInputFormatOptionsIsNull = false;
            }
             // determine if request.InputFormatOptions should be set to null
            if (requestInputFormatOptionsIsNull)
            {
                request.InputFormatOptions = null;
            }
            
             // populate S3BucketSource
            var requestS3BucketSourceIsNull = true;
            request.S3BucketSource = new Amazon.DynamoDBv2.Model.S3BucketSource();
            System.String requestS3BucketSource_s3BucketSource_S3Bucket = null;
            if (cmdletContext.S3BucketSource_S3Bucket != null)
            {
                requestS3BucketSource_s3BucketSource_S3Bucket = cmdletContext.S3BucketSource_S3Bucket;
            }
            if (requestS3BucketSource_s3BucketSource_S3Bucket != null)
            {
                request.S3BucketSource.S3Bucket = requestS3BucketSource_s3BucketSource_S3Bucket;
                requestS3BucketSourceIsNull = false;
            }
            System.String requestS3BucketSource_s3BucketSource_S3BucketOwner = null;
            if (cmdletContext.S3BucketSource_S3BucketOwner != null)
            {
                requestS3BucketSource_s3BucketSource_S3BucketOwner = cmdletContext.S3BucketSource_S3BucketOwner;
            }
            if (requestS3BucketSource_s3BucketSource_S3BucketOwner != null)
            {
                request.S3BucketSource.S3BucketOwner = requestS3BucketSource_s3BucketSource_S3BucketOwner;
                requestS3BucketSourceIsNull = false;
            }
            System.String requestS3BucketSource_s3BucketSource_S3KeyPrefix = null;
            if (cmdletContext.S3BucketSource_S3KeyPrefix != null)
            {
                requestS3BucketSource_s3BucketSource_S3KeyPrefix = cmdletContext.S3BucketSource_S3KeyPrefix;
            }
            if (requestS3BucketSource_s3BucketSource_S3KeyPrefix != null)
            {
                request.S3BucketSource.S3KeyPrefix = requestS3BucketSource_s3BucketSource_S3KeyPrefix;
                requestS3BucketSourceIsNull = false;
            }
             // determine if request.S3BucketSource should be set to null
            if (requestS3BucketSourceIsNull)
            {
                request.S3BucketSource = null;
            }
            
             // populate TableCreationParameters
            var requestTableCreationParametersIsNull = true;
            request.TableCreationParameters = new Amazon.DynamoDBv2.Model.TableCreationParameters();
            List<Amazon.DynamoDBv2.Model.AttributeDefinition> requestTableCreationParameters_tableCreationParameters_AttributeDefinition = null;
            if (cmdletContext.TableCreationParameters_AttributeDefinition != null)
            {
                requestTableCreationParameters_tableCreationParameters_AttributeDefinition = cmdletContext.TableCreationParameters_AttributeDefinition;
            }
            if (requestTableCreationParameters_tableCreationParameters_AttributeDefinition != null)
            {
                request.TableCreationParameters.AttributeDefinitions = requestTableCreationParameters_tableCreationParameters_AttributeDefinition;
                requestTableCreationParametersIsNull = false;
            }
            Amazon.DynamoDBv2.BillingMode requestTableCreationParameters_tableCreationParameters_BillingMode = null;
            if (cmdletContext.TableCreationParameters_BillingMode != null)
            {
                requestTableCreationParameters_tableCreationParameters_BillingMode = cmdletContext.TableCreationParameters_BillingMode;
            }
            if (requestTableCreationParameters_tableCreationParameters_BillingMode != null)
            {
                request.TableCreationParameters.BillingMode = requestTableCreationParameters_tableCreationParameters_BillingMode;
                requestTableCreationParametersIsNull = false;
            }
            List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndex> requestTableCreationParameters_tableCreationParameters_GlobalSecondaryIndex = null;
            if (cmdletContext.TableCreationParameters_GlobalSecondaryIndex != null)
            {
                requestTableCreationParameters_tableCreationParameters_GlobalSecondaryIndex = cmdletContext.TableCreationParameters_GlobalSecondaryIndex;
            }
            if (requestTableCreationParameters_tableCreationParameters_GlobalSecondaryIndex != null)
            {
                request.TableCreationParameters.GlobalSecondaryIndexes = requestTableCreationParameters_tableCreationParameters_GlobalSecondaryIndex;
                requestTableCreationParametersIsNull = false;
            }
            List<Amazon.DynamoDBv2.Model.KeySchemaElement> requestTableCreationParameters_tableCreationParameters_KeySchema = null;
            if (cmdletContext.TableCreationParameters_KeySchema != null)
            {
                requestTableCreationParameters_tableCreationParameters_KeySchema = cmdletContext.TableCreationParameters_KeySchema;
            }
            if (requestTableCreationParameters_tableCreationParameters_KeySchema != null)
            {
                request.TableCreationParameters.KeySchema = requestTableCreationParameters_tableCreationParameters_KeySchema;
                requestTableCreationParametersIsNull = false;
            }
            System.String requestTableCreationParameters_tableCreationParameters_TableName = null;
            if (cmdletContext.TableCreationParameters_TableName != null)
            {
                requestTableCreationParameters_tableCreationParameters_TableName = cmdletContext.TableCreationParameters_TableName;
            }
            if (requestTableCreationParameters_tableCreationParameters_TableName != null)
            {
                request.TableCreationParameters.TableName = requestTableCreationParameters_tableCreationParameters_TableName;
                requestTableCreationParametersIsNull = false;
            }
            Amazon.DynamoDBv2.Model.OnDemandThroughput requestTableCreationParameters_tableCreationParameters_OnDemandThroughput = null;
            
             // populate OnDemandThroughput
            var requestTableCreationParameters_tableCreationParameters_OnDemandThroughputIsNull = true;
            requestTableCreationParameters_tableCreationParameters_OnDemandThroughput = new Amazon.DynamoDBv2.Model.OnDemandThroughput();
            System.Int64? requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxReadRequestUnit = null;
            if (cmdletContext.OnDemandThroughput_MaxReadRequestUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxReadRequestUnit = cmdletContext.OnDemandThroughput_MaxReadRequestUnit.Value;
            }
            if (requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxReadRequestUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_OnDemandThroughput.MaxReadRequestUnits = requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxReadRequestUnit.Value;
                requestTableCreationParameters_tableCreationParameters_OnDemandThroughputIsNull = false;
            }
            System.Int64? requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxWriteRequestUnit = null;
            if (cmdletContext.OnDemandThroughput_MaxWriteRequestUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxWriteRequestUnit = cmdletContext.OnDemandThroughput_MaxWriteRequestUnit.Value;
            }
            if (requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxWriteRequestUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_OnDemandThroughput.MaxWriteRequestUnits = requestTableCreationParameters_tableCreationParameters_OnDemandThroughput_onDemandThroughput_MaxWriteRequestUnit.Value;
                requestTableCreationParameters_tableCreationParameters_OnDemandThroughputIsNull = false;
            }
             // determine if requestTableCreationParameters_tableCreationParameters_OnDemandThroughput should be set to null
            if (requestTableCreationParameters_tableCreationParameters_OnDemandThroughputIsNull)
            {
                requestTableCreationParameters_tableCreationParameters_OnDemandThroughput = null;
            }
            if (requestTableCreationParameters_tableCreationParameters_OnDemandThroughput != null)
            {
                request.TableCreationParameters.OnDemandThroughput = requestTableCreationParameters_tableCreationParameters_OnDemandThroughput;
                requestTableCreationParametersIsNull = false;
            }
            Amazon.DynamoDBv2.Model.ProvisionedThroughput requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput = null;
            
             // populate ProvisionedThroughput
            var requestTableCreationParameters_tableCreationParameters_ProvisionedThroughputIsNull = true;
            requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput = new Amazon.DynamoDBv2.Model.ProvisionedThroughput();
            System.Int64? requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_ReadCapacityUnit = null;
            if (cmdletContext.ProvisionedThroughput_ReadCapacityUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_ReadCapacityUnit = cmdletContext.ProvisionedThroughput_ReadCapacityUnit.Value;
            }
            if (requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_ReadCapacityUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput.ReadCapacityUnits = requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_ReadCapacityUnit.Value;
                requestTableCreationParameters_tableCreationParameters_ProvisionedThroughputIsNull = false;
            }
            System.Int64? requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_WriteCapacityUnit = null;
            if (cmdletContext.ProvisionedThroughput_WriteCapacityUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_WriteCapacityUnit = cmdletContext.ProvisionedThroughput_WriteCapacityUnit.Value;
            }
            if (requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_WriteCapacityUnit != null)
            {
                requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput.WriteCapacityUnits = requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput_provisionedThroughput_WriteCapacityUnit.Value;
                requestTableCreationParameters_tableCreationParameters_ProvisionedThroughputIsNull = false;
            }
             // determine if requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput should be set to null
            if (requestTableCreationParameters_tableCreationParameters_ProvisionedThroughputIsNull)
            {
                requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput = null;
            }
            if (requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput != null)
            {
                request.TableCreationParameters.ProvisionedThroughput = requestTableCreationParameters_tableCreationParameters_ProvisionedThroughput;
                requestTableCreationParametersIsNull = false;
            }
            Amazon.DynamoDBv2.Model.SSESpecification requestTableCreationParameters_tableCreationParameters_SSESpecification = null;
            
             // populate SSESpecification
            var requestTableCreationParameters_tableCreationParameters_SSESpecificationIsNull = true;
            requestTableCreationParameters_tableCreationParameters_SSESpecification = new Amazon.DynamoDBv2.Model.SSESpecification();
            System.Boolean? requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_Enabled = null;
            if (cmdletContext.SSESpecification_Enabled != null)
            {
                requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_Enabled = cmdletContext.SSESpecification_Enabled.Value;
            }
            if (requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_Enabled != null)
            {
                requestTableCreationParameters_tableCreationParameters_SSESpecification.Enabled = requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_Enabled.Value;
                requestTableCreationParameters_tableCreationParameters_SSESpecificationIsNull = false;
            }
            System.String requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_KMSMasterKeyId = null;
            if (cmdletContext.SSESpecification_KMSMasterKeyId != null)
            {
                requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_KMSMasterKeyId = cmdletContext.SSESpecification_KMSMasterKeyId;
            }
            if (requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_KMSMasterKeyId != null)
            {
                requestTableCreationParameters_tableCreationParameters_SSESpecification.KMSMasterKeyId = requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_KMSMasterKeyId;
                requestTableCreationParameters_tableCreationParameters_SSESpecificationIsNull = false;
            }
            Amazon.DynamoDBv2.SSEType requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_SSEType = null;
            if (cmdletContext.SSESpecification_SSEType != null)
            {
                requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_SSEType = cmdletContext.SSESpecification_SSEType;
            }
            if (requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_SSEType != null)
            {
                requestTableCreationParameters_tableCreationParameters_SSESpecification.SSEType = requestTableCreationParameters_tableCreationParameters_SSESpecification_sSESpecification_SSEType;
                requestTableCreationParameters_tableCreationParameters_SSESpecificationIsNull = false;
            }
             // determine if requestTableCreationParameters_tableCreationParameters_SSESpecification should be set to null
            if (requestTableCreationParameters_tableCreationParameters_SSESpecificationIsNull)
            {
                requestTableCreationParameters_tableCreationParameters_SSESpecification = null;
            }
            if (requestTableCreationParameters_tableCreationParameters_SSESpecification != null)
            {
                request.TableCreationParameters.SSESpecification = requestTableCreationParameters_tableCreationParameters_SSESpecification;
                requestTableCreationParametersIsNull = false;
            }
             // determine if request.TableCreationParameters should be set to null
            if (requestTableCreationParametersIsNull)
            {
                request.TableCreationParameters = null;
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
        
        private Amazon.DynamoDBv2.Model.ImportTableResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.ImportTableRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "ImportTable");
            try
            {
                #if DESKTOP
                return client.ImportTable(request);
                #elif CORECLR
                return client.ImportTableAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public Amazon.DynamoDBv2.InputCompressionType InputCompressionType { get; set; }
            public Amazon.DynamoDBv2.InputFormat InputFormat { get; set; }
            public System.String Csv_Delimiter { get; set; }
            public List<System.String> Csv_HeaderList { get; set; }
            public System.String S3BucketSource_S3Bucket { get; set; }
            public System.String S3BucketSource_S3BucketOwner { get; set; }
            public System.String S3BucketSource_S3KeyPrefix { get; set; }
            public List<Amazon.DynamoDBv2.Model.AttributeDefinition> TableCreationParameters_AttributeDefinition { get; set; }
            public Amazon.DynamoDBv2.BillingMode TableCreationParameters_BillingMode { get; set; }
            public List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndex> TableCreationParameters_GlobalSecondaryIndex { get; set; }
            public List<Amazon.DynamoDBv2.Model.KeySchemaElement> TableCreationParameters_KeySchema { get; set; }
            public System.Int64? OnDemandThroughput_MaxReadRequestUnit { get; set; }
            public System.Int64? OnDemandThroughput_MaxWriteRequestUnit { get; set; }
            public System.Int64? ProvisionedThroughput_ReadCapacityUnit { get; set; }
            public System.Int64? ProvisionedThroughput_WriteCapacityUnit { get; set; }
            public System.Boolean? SSESpecification_Enabled { get; set; }
            public System.String SSESpecification_KMSMasterKeyId { get; set; }
            public Amazon.DynamoDBv2.SSEType SSESpecification_SSEType { get; set; }
            public System.String TableCreationParameters_TableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.ImportTableResponse, ImportDDBTableCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImportTableDescription;
        }
        
    }
}
