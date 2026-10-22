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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Creates an ingestion stream that continuously ingests data from an Amazon S3 bucket
    /// into an index in an OpenSearch Serverless collection. An ingestion stream processes
    /// Amazon S3 event notifications delivered to an Amazon SQS queue and ingests new objects
    /// as they arrive. The stream continues to ingest data until you delete it. To perform
    /// a one-time bulk ingestion instead, use <c>CreateIngestionJob</c>.
    /// </summary>
    [Cmdlet("New", "OSSIngestionStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.IngestionStreamDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless CreateIngestionStream API operation.", Operation = new[] {"CreateIngestionStream"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.IngestionStreamDetail or Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.IngestionStreamDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSSIngestionStreamCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Source_S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The configuration for each Amazon S3 bucket that the ingestion stream ingests data
        /// from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_S3_Buckets")]
        public Amazon.OpenSearchServerless.Model.StreamBucketConfig[] Source_S3_Bucket { get; set; }
        #endregion
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the collection to ingest data into.</para>
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
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter FailureIndexName
        /// <summary>
        /// <para>
        /// <para>The name of the index where documents that fail to be ingested are recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FailureIndexName { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the index to ingest documents into.</para>
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
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter IngestionStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the ingestion stream. The name must be unique within the collection.</para>
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
        public System.String IngestionStreamName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that OpenSearch Serverless assumes
        /// to read data from the source. The role must be in the same account as the collection.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Source_S3_SqsArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SQS queue that receives Amazon S3 event
        /// notifications for the source buckets.</para>
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
        public System.String Source_S3_SqsArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An arbitrary set of tags (key–value pairs) to associate with the ingestion stream.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.OpenSearchServerless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IngestionStreamDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IngestionStreamDetail";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IngestionStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSSIngestionStream (CreateIngestionStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse, NewOSSIngestionStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CollectionId = this.CollectionId;
            #if MODULAR
            if (this.CollectionId == null && ParameterWasBound(nameof(this.CollectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FailureIndexName = this.FailureIndexName;
            context.IndexName = this.IndexName;
            #if MODULAR
            if (this.IndexName == null && ParameterWasBound(nameof(this.IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IngestionStreamName = this.IngestionStreamName;
            #if MODULAR
            if (this.IngestionStreamName == null && ParameterWasBound(nameof(this.IngestionStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Source_S3_Bucket != null)
            {
                context.Source_S3_Bucket = new List<Amazon.OpenSearchServerless.Model.StreamBucketConfig>(this.Source_S3_Bucket);
            }
            context.Source_S3_SqsArn = this.Source_S3_SqsArn;
            #if MODULAR
            if (this.Source_S3_SqsArn == null && ParameterWasBound(nameof(this.Source_S3_SqsArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Source_S3_SqsArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.OpenSearchServerless.Model.Tag>(this.Tag);
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
            var request = new Amazon.OpenSearchServerless.Model.CreateIngestionStreamRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CollectionId != null)
            {
                request.CollectionId = cmdletContext.CollectionId;
            }
            if (cmdletContext.FailureIndexName != null)
            {
                request.FailureIndexName = cmdletContext.FailureIndexName;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.IngestionStreamName != null)
            {
                request.IngestionStreamName = cmdletContext.IngestionStreamName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.OpenSearchServerless.Model.IngestionStreamSource();
            Amazon.OpenSearchServerless.Model.IngestionStreamS3Source requestSource_source_S3 = null;
            
             // populate S3
            var requestSource_source_S3IsNull = true;
            requestSource_source_S3 = new Amazon.OpenSearchServerless.Model.IngestionStreamS3Source();
            List<Amazon.OpenSearchServerless.Model.StreamBucketConfig> requestSource_source_S3_source_S3_Bucket = null;
            if (cmdletContext.Source_S3_Bucket != null)
            {
                requestSource_source_S3_source_S3_Bucket = cmdletContext.Source_S3_Bucket;
            }
            if (requestSource_source_S3_source_S3_Bucket != null)
            {
                requestSource_source_S3.Buckets = requestSource_source_S3_source_S3_Bucket;
                requestSource_source_S3IsNull = false;
            }
            System.String requestSource_source_S3_source_S3_SqsArn = null;
            if (cmdletContext.Source_S3_SqsArn != null)
            {
                requestSource_source_S3_source_S3_SqsArn = cmdletContext.Source_S3_SqsArn;
            }
            if (requestSource_source_S3_source_S3_SqsArn != null)
            {
                requestSource_source_S3.SqsArn = requestSource_source_S3_source_S3_SqsArn;
                requestSource_source_S3IsNull = false;
            }
             // determine if requestSource_source_S3 should be set to null
            if (requestSource_source_S3IsNull)
            {
                requestSource_source_S3 = null;
            }
            if (requestSource_source_S3 != null)
            {
                request.Source.S3 = requestSource_source_S3;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.CreateIngestionStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "CreateIngestionStream");
            try
            {
                return client.CreateIngestionStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CollectionId { get; set; }
            public System.String FailureIndexName { get; set; }
            public System.String IndexName { get; set; }
            public System.String IngestionStreamName { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.OpenSearchServerless.Model.StreamBucketConfig> Source_S3_Bucket { get; set; }
            public System.String Source_S3_SqsArn { get; set; }
            public List<Amazon.OpenSearchServerless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.CreateIngestionStreamResponse, NewOSSIngestionStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IngestionStreamDetail;
        }
        
    }
}
