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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Starts an asynchronous bulk operation that reads items from Amazon S3 and writes them
    /// to an existing DynamoDB table, so you can efficiently load or migrate large datasets.
    /// </summary>
    [Cmdlet("Start", "DDBBulkPutItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.BulkOperationDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB StartBulkPutItems API operation.", Operation = new[] {"StartBulkPutItems"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.BulkOperationDescription or Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.BulkOperationDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDDBBulkPutItemCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InputS3Configuration_InputCompressionType
        /// <summary>
        /// <para>
        /// <para>The compression type of the input objects. Valid values are <c>GZIP</c>, <c>ZSTD</c>,
        /// and <c>NONE</c>. If you don't specify a value, DynamoDB uses <c>NONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.InputCompressionType")]
        public Amazon.DynamoDBv2.InputCompressionType InputS3Configuration_InputCompressionType { get; set; }
        #endregion
        
        #region Parameter InputS3Configuration_InputFormat
        /// <summary>
        /// <para>
        /// <para>The format of the input objects. <c>DYNAMODB_JSON</c> uses JSON Lines, with one JSON
        /// record per line. <c>ION</c> uses a sequence of Ion structs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BulkOperationInputFormat")]
        public Amazon.DynamoDBv2.BulkOperationInputFormat InputS3Configuration_InputFormat { get; set; }
        #endregion
        
        #region Parameter MaxWriteRequestUnit
        /// <summary>
        /// <para>
        /// <para>The maximum rate, in write request units per second, at which the bulk operation attempts
        /// to write. The value must be at least 1,024. With this setting, you limit only the
        /// bulk operation; the table's provisioned or on-demand capacity settings don't change.
        /// The actual write rate can be lower.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxWriteRequestUnits")]
        public System.Int64? MaxWriteRequestUnit { get; set; }
        #endregion
        
        #region Parameter OutputS3Configuration_OutputType
        /// <summary>
        /// <para>
        /// <para>The following values describe the types of output that DynamoDB writes for individual
        /// input items. Include one or both values.</para><dl><dt> ERROR </dt><dd><para>Reports input records or input objects that DynamoDB couldn't process. This includes
        /// malformed input and item validation failures, such as a missing or incorrectly typed
        /// primary key attribute or an item that exceeds a DynamoDB limit.</para></dd><dt> CONDITION_CHECK_FAILURE </dt><dd><para>Reports the attempted item and, when present, the existing item for a write whose
        /// condition expression evaluates to false.</para></dd></dl><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
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
        public System.String[] OutputS3Configuration_OutputType { get; set; }
        #endregion
        
        #region Parameter PerformanceTier
        /// <summary>
        /// <para>
        /// <para>The performance tier for the bulk operation. Valid values are <c>STANDARD</c> and
        /// <c>ACCELERATED</c>. If you don't specify a value, the operation uses <c>STANDARD</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BulkOperationPerformanceTier")]
        public Amazon.DynamoDBv2.BulkOperationPerformanceTier PerformanceTier { get; set; }
        #endregion
        
        #region Parameter InputS3Configuration_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket that contains the input objects.</para>
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
        public System.String InputS3Configuration_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputS3Configuration_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket where DynamoDB writes output records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputS3Configuration_S3Bucket { get; set; }
        #endregion
        
        #region Parameter InputS3Configuration_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the input bucket owner. If you omit this value,
        /// DynamoDB uses the Amazon Web Services account ID of the requester.</para><note><para><c>S3BucketOwner</c> is required when the bucket is owned by another Amazon Web Services
        /// account.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputS3Configuration_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter OutputS3Configuration_S3BucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the output bucket owner. If you omit this value,
        /// DynamoDB uses the Amazon Web Services account ID of the requester.</para><note><para><c>S3BucketOwner</c> is required when the bucket is owned by another Amazon Web Services
        /// account.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputS3Configuration_S3BucketOwner { get; set; }
        #endregion
        
        #region Parameter InputS3Configuration_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>An optional key prefix that limits the input to matching objects in the Amazon S3
        /// bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputS3Configuration_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter OutputS3Configuration_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>An optional key prefix under which DynamoDB writes the output records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputS3Configuration_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter OutputS3Configuration_S3SseAlgorithm
        /// <summary>
        /// <para>
        /// <para>The server-side encryption algorithm for the output objects. Valid values are <c>AES256</c>
        /// and <c>KMS</c>. If you don't specify a value, Amazon S3 applies the destination bucket's
        /// default encryption settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.S3SseAlgorithm")]
        public Amazon.DynamoDBv2.S3SseAlgorithm OutputS3Configuration_S3SseAlgorithm { get; set; }
        #endregion
        
        #region Parameter OutputS3Configuration_S3SseKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key that encrypts the output objects. Specify this value
        /// when <c>S3SseAlgorithm</c> is <c>KMS</c>. Don't specify it when the algorithm is <c>AES256</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputS3Configuration_S3SseKmsKeyId { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the existing DynamoDB table that receives the items.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that ensures the bulk operation starts no more
        /// than one time. During the 8 hours after the initial request, repeated requests that
        /// use the same token and parameters return the same bulk operation. If a request reuses
        /// the token with different parameters, DynamoDB returns an <c>IdempotentParameterMismatchException</c>.
        /// If you omit the token, an Amazon Web Services SDK automatically generates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BulkOperationDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BulkOperationDescription";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DDBBulkPutItem (StartBulkPutItems)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse, StartDDBBulkPutItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InputS3Configuration_InputCompressionType = this.InputS3Configuration_InputCompressionType;
            context.InputS3Configuration_InputFormat = this.InputS3Configuration_InputFormat;
            #if MODULAR
            if (this.InputS3Configuration_InputFormat == null && ParameterWasBound(nameof(this.InputS3Configuration_InputFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter InputS3Configuration_InputFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputS3Configuration_S3Bucket = this.InputS3Configuration_S3Bucket;
            #if MODULAR
            if (this.InputS3Configuration_S3Bucket == null && ParameterWasBound(nameof(this.InputS3Configuration_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter InputS3Configuration_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputS3Configuration_S3BucketOwner = this.InputS3Configuration_S3BucketOwner;
            context.InputS3Configuration_S3KeyPrefix = this.InputS3Configuration_S3KeyPrefix;
            context.MaxWriteRequestUnit = this.MaxWriteRequestUnit;
            if (this.OutputS3Configuration_OutputType != null)
            {
                context.OutputS3Configuration_OutputType = new List<System.String>(this.OutputS3Configuration_OutputType);
            }
            #if MODULAR
            if (this.OutputS3Configuration_OutputType == null && ParameterWasBound(nameof(this.OutputS3Configuration_OutputType)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputS3Configuration_OutputType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputS3Configuration_S3Bucket = this.OutputS3Configuration_S3Bucket;
            context.OutputS3Configuration_S3BucketOwner = this.OutputS3Configuration_S3BucketOwner;
            context.OutputS3Configuration_S3KeyPrefix = this.OutputS3Configuration_S3KeyPrefix;
            context.OutputS3Configuration_S3SseAlgorithm = this.OutputS3Configuration_S3SseAlgorithm;
            context.OutputS3Configuration_S3SseKmsKeyId = this.OutputS3Configuration_S3SseKmsKeyId;
            context.PerformanceTier = this.PerformanceTier;
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DynamoDBv2.Model.StartBulkPutItemsRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate InputS3Configuration
            var requestInputS3ConfigurationIsNull = true;
            request.InputS3Configuration = new Amazon.DynamoDBv2.Model.InputS3Configuration();
            Amazon.DynamoDBv2.InputCompressionType requestInputS3Configuration_inputS3Configuration_InputCompressionType = null;
            if (cmdletContext.InputS3Configuration_InputCompressionType != null)
            {
                requestInputS3Configuration_inputS3Configuration_InputCompressionType = cmdletContext.InputS3Configuration_InputCompressionType;
            }
            if (requestInputS3Configuration_inputS3Configuration_InputCompressionType != null)
            {
                request.InputS3Configuration.InputCompressionType = requestInputS3Configuration_inputS3Configuration_InputCompressionType;
                requestInputS3ConfigurationIsNull = false;
            }
            Amazon.DynamoDBv2.BulkOperationInputFormat requestInputS3Configuration_inputS3Configuration_InputFormat = null;
            if (cmdletContext.InputS3Configuration_InputFormat != null)
            {
                requestInputS3Configuration_inputS3Configuration_InputFormat = cmdletContext.InputS3Configuration_InputFormat;
            }
            if (requestInputS3Configuration_inputS3Configuration_InputFormat != null)
            {
                request.InputS3Configuration.InputFormat = requestInputS3Configuration_inputS3Configuration_InputFormat;
                requestInputS3ConfigurationIsNull = false;
            }
            System.String requestInputS3Configuration_inputS3Configuration_S3Bucket = null;
            if (cmdletContext.InputS3Configuration_S3Bucket != null)
            {
                requestInputS3Configuration_inputS3Configuration_S3Bucket = cmdletContext.InputS3Configuration_S3Bucket;
            }
            if (requestInputS3Configuration_inputS3Configuration_S3Bucket != null)
            {
                request.InputS3Configuration.S3Bucket = requestInputS3Configuration_inputS3Configuration_S3Bucket;
                requestInputS3ConfigurationIsNull = false;
            }
            System.String requestInputS3Configuration_inputS3Configuration_S3BucketOwner = null;
            if (cmdletContext.InputS3Configuration_S3BucketOwner != null)
            {
                requestInputS3Configuration_inputS3Configuration_S3BucketOwner = cmdletContext.InputS3Configuration_S3BucketOwner;
            }
            if (requestInputS3Configuration_inputS3Configuration_S3BucketOwner != null)
            {
                request.InputS3Configuration.S3BucketOwner = requestInputS3Configuration_inputS3Configuration_S3BucketOwner;
                requestInputS3ConfigurationIsNull = false;
            }
            System.String requestInputS3Configuration_inputS3Configuration_S3KeyPrefix = null;
            if (cmdletContext.InputS3Configuration_S3KeyPrefix != null)
            {
                requestInputS3Configuration_inputS3Configuration_S3KeyPrefix = cmdletContext.InputS3Configuration_S3KeyPrefix;
            }
            if (requestInputS3Configuration_inputS3Configuration_S3KeyPrefix != null)
            {
                request.InputS3Configuration.S3KeyPrefix = requestInputS3Configuration_inputS3Configuration_S3KeyPrefix;
                requestInputS3ConfigurationIsNull = false;
            }
             // determine if request.InputS3Configuration should be set to null
            if (requestInputS3ConfigurationIsNull)
            {
                request.InputS3Configuration = null;
            }
            if (cmdletContext.MaxWriteRequestUnit != null)
            {
                request.MaxWriteRequestUnits = cmdletContext.MaxWriteRequestUnit.Value;
            }
            
             // populate OutputS3Configuration
            var requestOutputS3ConfigurationIsNull = true;
            request.OutputS3Configuration = new Amazon.DynamoDBv2.Model.OutputS3Configuration();
            List<System.String> requestOutputS3Configuration_outputS3Configuration_OutputType = null;
            if (cmdletContext.OutputS3Configuration_OutputType != null)
            {
                requestOutputS3Configuration_outputS3Configuration_OutputType = cmdletContext.OutputS3Configuration_OutputType;
            }
            if (requestOutputS3Configuration_outputS3Configuration_OutputType != null)
            {
                request.OutputS3Configuration.OutputType = requestOutputS3Configuration_outputS3Configuration_OutputType;
                requestOutputS3ConfigurationIsNull = false;
            }
            System.String requestOutputS3Configuration_outputS3Configuration_S3Bucket = null;
            if (cmdletContext.OutputS3Configuration_S3Bucket != null)
            {
                requestOutputS3Configuration_outputS3Configuration_S3Bucket = cmdletContext.OutputS3Configuration_S3Bucket;
            }
            if (requestOutputS3Configuration_outputS3Configuration_S3Bucket != null)
            {
                request.OutputS3Configuration.S3Bucket = requestOutputS3Configuration_outputS3Configuration_S3Bucket;
                requestOutputS3ConfigurationIsNull = false;
            }
            System.String requestOutputS3Configuration_outputS3Configuration_S3BucketOwner = null;
            if (cmdletContext.OutputS3Configuration_S3BucketOwner != null)
            {
                requestOutputS3Configuration_outputS3Configuration_S3BucketOwner = cmdletContext.OutputS3Configuration_S3BucketOwner;
            }
            if (requestOutputS3Configuration_outputS3Configuration_S3BucketOwner != null)
            {
                request.OutputS3Configuration.S3BucketOwner = requestOutputS3Configuration_outputS3Configuration_S3BucketOwner;
                requestOutputS3ConfigurationIsNull = false;
            }
            System.String requestOutputS3Configuration_outputS3Configuration_S3KeyPrefix = null;
            if (cmdletContext.OutputS3Configuration_S3KeyPrefix != null)
            {
                requestOutputS3Configuration_outputS3Configuration_S3KeyPrefix = cmdletContext.OutputS3Configuration_S3KeyPrefix;
            }
            if (requestOutputS3Configuration_outputS3Configuration_S3KeyPrefix != null)
            {
                request.OutputS3Configuration.S3KeyPrefix = requestOutputS3Configuration_outputS3Configuration_S3KeyPrefix;
                requestOutputS3ConfigurationIsNull = false;
            }
            Amazon.DynamoDBv2.S3SseAlgorithm requestOutputS3Configuration_outputS3Configuration_S3SseAlgorithm = null;
            if (cmdletContext.OutputS3Configuration_S3SseAlgorithm != null)
            {
                requestOutputS3Configuration_outputS3Configuration_S3SseAlgorithm = cmdletContext.OutputS3Configuration_S3SseAlgorithm;
            }
            if (requestOutputS3Configuration_outputS3Configuration_S3SseAlgorithm != null)
            {
                request.OutputS3Configuration.S3SseAlgorithm = requestOutputS3Configuration_outputS3Configuration_S3SseAlgorithm;
                requestOutputS3ConfigurationIsNull = false;
            }
            System.String requestOutputS3Configuration_outputS3Configuration_S3SseKmsKeyId = null;
            if (cmdletContext.OutputS3Configuration_S3SseKmsKeyId != null)
            {
                requestOutputS3Configuration_outputS3Configuration_S3SseKmsKeyId = cmdletContext.OutputS3Configuration_S3SseKmsKeyId;
            }
            if (requestOutputS3Configuration_outputS3Configuration_S3SseKmsKeyId != null)
            {
                request.OutputS3Configuration.S3SseKmsKeyId = requestOutputS3Configuration_outputS3Configuration_S3SseKmsKeyId;
                requestOutputS3ConfigurationIsNull = false;
            }
             // determine if request.OutputS3Configuration should be set to null
            if (requestOutputS3ConfigurationIsNull)
            {
                request.OutputS3Configuration = null;
            }
            if (cmdletContext.PerformanceTier != null)
            {
                request.PerformanceTier = cmdletContext.PerformanceTier;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.StartBulkPutItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "StartBulkPutItems");
            try
            {
                return client.StartBulkPutItemsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DynamoDBv2.InputCompressionType InputS3Configuration_InputCompressionType { get; set; }
            public Amazon.DynamoDBv2.BulkOperationInputFormat InputS3Configuration_InputFormat { get; set; }
            public System.String InputS3Configuration_S3Bucket { get; set; }
            public System.String InputS3Configuration_S3BucketOwner { get; set; }
            public System.String InputS3Configuration_S3KeyPrefix { get; set; }
            public System.Int64? MaxWriteRequestUnit { get; set; }
            public List<System.String> OutputS3Configuration_OutputType { get; set; }
            public System.String OutputS3Configuration_S3Bucket { get; set; }
            public System.String OutputS3Configuration_S3BucketOwner { get; set; }
            public System.String OutputS3Configuration_S3KeyPrefix { get; set; }
            public Amazon.DynamoDBv2.S3SseAlgorithm OutputS3Configuration_S3SseAlgorithm { get; set; }
            public System.String OutputS3Configuration_S3SseKmsKeyId { get; set; }
            public Amazon.DynamoDBv2.BulkOperationPerformanceTier PerformanceTier { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.StartBulkPutItemsResponse, StartDDBBulkPutItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BulkOperationDescription;
        }
        
    }
}
