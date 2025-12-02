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
using Amazon.S3Vectors;
using Amazon.S3Vectors.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3V
{
    /// <summary>
    /// Creates a vector index within a vector bucket. To specify the vector bucket, you must
    /// use either the vector bucket name or the vector bucket Amazon Resource Name (ARN).
    /// 
    ///  <dl><dt>Permissions</dt><dd><para>
    /// You must have the <c>s3vectors:CreateIndex</c> permission to use this operation.
    /// </para><para>
    /// You must have the <c>s3vectors:TagResource</c> permission in addition to <c>s3vectors:CreateIndex</c>
    /// permission to create a vector index with tags.
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("New", "S3VIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon S3 Vectors CreateIndex API operation.", Operation = new[] {"CreateIndex"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.CreateIndexResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3Vectors.Model.CreateIndexResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3Vectors.Model.CreateIndexResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewS3VIndexCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataType
        /// <summary>
        /// <para>
        /// <para>The data type of the vectors to be inserted into the vector index. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Vectors.DataType")]
        public Amazon.S3Vectors.DataType DataType { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions of the vectors to be inserted into the vector index. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Dimension { get; set; }
        #endregion
        
        #region Parameter DistanceMetric
        /// <summary>
        /// <para>
        /// <para>The distance metric to be used for similarity search. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.S3Vectors.DistanceMetric")]
        public Amazon.S3Vectors.DistanceMetric DistanceMetric { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index to create. </para>
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
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services Key Management Service (KMS) customer managed key ID to use for
        /// the encryption configuration. This parameter is allowed if and only if <c>sseType</c>
        /// is set to <c>aws:kms</c>.</para><para>To specify the KMS key, you must use the format of the KMS key Amazon Resource Name
        /// (ARN).</para><para>For example, specify Key ARN in the following format: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MetadataConfiguration_NonFilterableMetadataKey
        /// <summary>
        /// <para>
        /// <para>Non-filterable metadata keys allow you to enrich vectors with additional context during
        /// storage and retrieval. Unlike default metadata keys, these keys can’t be used as query
        /// filters. Non-filterable metadata keys can be retrieved but can’t be searched, queried,
        /// or filtered. You can access non-filterable metadata keys of your vectors after finding
        /// the vectors. For more information about non-filterable metadata keys, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-vectors-vectors.html">Vectors</a>
        /// and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-vectors-limitations.html">Limitations
        /// and restrictions</a> in the <i>Amazon S3 User Guide</i>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataConfiguration_NonFilterableMetadataKeys")]
        public System.String[] MetadataConfiguration_NonFilterableMetadataKey { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_SseType
        /// <summary>
        /// <para>
        /// <para>The server-side encryption type to use for the encryption configuration of the vector
        /// bucket. By default, if you don't specify, all new vectors in Amazon S3 vector buckets
        /// use server-side encryption with Amazon S3 managed keys (SSE-S3), specifically <c>AES256</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Vectors.SseType")]
        public Amazon.S3Vectors.SseType EncryptionConfiguration_SseType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of user-defined tags that you would like to apply to the vector index that
        /// you are creating. A tag is a key-value pair that you apply to your resources. Tags
        /// can help you organize, track costs, and control access to resources. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/tagging.html">Tagging
        /// for cost allocation or attribute-based access control (ABAC)</a>.</para><note><para>You must have the <c>s3vectors:TagResource</c> permission in addition to <c>s3vectors:CreateIndex</c>
        /// permission to create a vector index with tags.</para></note><para />
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
        
        #region Parameter VectorBucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the vector bucket to create the vector index in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketArn { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket to create the vector index in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IndexArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.CreateIndexResponse).
        /// Specifying the name of a property of type Amazon.S3Vectors.Model.CreateIndexResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IndexArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3VIndex (CreateIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.CreateIndexResponse, NewS3VIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataType = this.DataType;
            #if MODULAR
            if (this.DataType == null && ParameterWasBound(nameof(this.DataType)))
            {
                WriteWarning("You are passing $null as a value for parameter DataType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Dimension = this.Dimension;
            #if MODULAR
            if (this.Dimension == null && ParameterWasBound(nameof(this.Dimension)))
            {
                WriteWarning("You are passing $null as a value for parameter Dimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistanceMetric = this.DistanceMetric;
            #if MODULAR
            if (this.DistanceMetric == null && ParameterWasBound(nameof(this.DistanceMetric)))
            {
                WriteWarning("You are passing $null as a value for parameter DistanceMetric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.EncryptionConfiguration_SseType = this.EncryptionConfiguration_SseType;
            context.IndexName = this.IndexName;
            #if MODULAR
            if (this.IndexName == null && ParameterWasBound(nameof(this.IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MetadataConfiguration_NonFilterableMetadataKey != null)
            {
                context.MetadataConfiguration_NonFilterableMetadataKey = new List<System.String>(this.MetadataConfiguration_NonFilterableMetadataKey);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VectorBucketArn = this.VectorBucketArn;
            context.VectorBucketName = this.VectorBucketName;
            
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
            var request = new Amazon.S3Vectors.Model.CreateIndexRequest();
            
            if (cmdletContext.DataType != null)
            {
                request.DataType = cmdletContext.DataType;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimension = cmdletContext.Dimension.Value;
            }
            if (cmdletContext.DistanceMetric != null)
            {
                request.DistanceMetric = cmdletContext.DistanceMetric;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.S3Vectors.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                request.EncryptionConfiguration.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.S3Vectors.SseType requestEncryptionConfiguration_encryptionConfiguration_SseType = null;
            if (cmdletContext.EncryptionConfiguration_SseType != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_SseType = cmdletContext.EncryptionConfiguration_SseType;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_SseType != null)
            {
                request.EncryptionConfiguration.SseType = requestEncryptionConfiguration_encryptionConfiguration_SseType;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            
             // populate MetadataConfiguration
            var requestMetadataConfigurationIsNull = true;
            request.MetadataConfiguration = new Amazon.S3Vectors.Model.MetadataConfiguration();
            List<System.String> requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey = null;
            if (cmdletContext.MetadataConfiguration_NonFilterableMetadataKey != null)
            {
                requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey = cmdletContext.MetadataConfiguration_NonFilterableMetadataKey;
            }
            if (requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey != null)
            {
                request.MetadataConfiguration.NonFilterableMetadataKeys = requestMetadataConfiguration_metadataConfiguration_NonFilterableMetadataKey;
                requestMetadataConfigurationIsNull = false;
            }
             // determine if request.MetadataConfiguration should be set to null
            if (requestMetadataConfigurationIsNull)
            {
                request.MetadataConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VectorBucketArn != null)
            {
                request.VectorBucketArn = cmdletContext.VectorBucketArn;
            }
            if (cmdletContext.VectorBucketName != null)
            {
                request.VectorBucketName = cmdletContext.VectorBucketName;
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
        
        private Amazon.S3Vectors.Model.CreateIndexResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.CreateIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "CreateIndex");
            try
            {
                return client.CreateIndexAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.S3Vectors.DataType DataType { get; set; }
            public System.Int32? Dimension { get; set; }
            public Amazon.S3Vectors.DistanceMetric DistanceMetric { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public Amazon.S3Vectors.SseType EncryptionConfiguration_SseType { get; set; }
            public System.String IndexName { get; set; }
            public List<System.String> MetadataConfiguration_NonFilterableMetadataKey { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VectorBucketArn { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.CreateIndexResponse, NewS3VIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IndexArn;
        }
        
    }
}
