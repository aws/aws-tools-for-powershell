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
    /// Creates an ingestion job that performs a one-time bulk ingestion of data from an Amazon
    /// S3 bucket into an index in an OpenSearch Serverless collection. An ingestion job scans
    /// the source bucket, indexes the documents it finds, and then completes. To continuously
    /// ingest new data as it arrives, use <c>CreateIngestionStream</c> instead.
    /// </summary>
    [Cmdlet("New", "OSSIngestionJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.IngestionJobDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless CreateIngestionJob API operation.", Operation = new[] {"CreateIngestionJob"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.IngestionJobDetail or Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.IngestionJobDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSSIngestionJobCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Source_S3_Bucket
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the Amazon S3 bucket to ingest data from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_S3_Bucket { get; set; }
        #endregion
        
        #region Parameter Source_S3_BucketOwnerAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that owns the Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_S3_BucketOwnerAccountId { get; set; }
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
        
        #region Parameter IngestionJobName
        /// <summary>
        /// <para>
        /// <para>The name of the ingestion job. The name must be unique within the collection.</para>
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
        public System.String IngestionJobName { get; set; }
        #endregion
        
        #region Parameter Source_S3_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>A key prefix that limits ingestion to objects in the Amazon S3 bucket whose keys begin
        /// with the prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_S3_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An arbitrary set of tags (key–value pairs) to associate with the ingestion job.</para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IngestionJobDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IngestionJobDetail";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IngestionJobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSSIngestionJob (CreateIngestionJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse, NewOSSIngestionJobCmdlet>(Select) ??
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
            context.IngestionJobName = this.IngestionJobName;
            #if MODULAR
            if (this.IngestionJobName == null && ParameterWasBound(nameof(this.IngestionJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source_S3_Bucket = this.Source_S3_Bucket;
            context.Source_S3_BucketOwnerAccountId = this.Source_S3_BucketOwnerAccountId;
            context.Source_S3_KeyPrefix = this.Source_S3_KeyPrefix;
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
            var request = new Amazon.OpenSearchServerless.Model.CreateIngestionJobRequest();
            
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
            if (cmdletContext.IngestionJobName != null)
            {
                request.IngestionJobName = cmdletContext.IngestionJobName;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.OpenSearchServerless.Model.IngestionJobSource();
            Amazon.OpenSearchServerless.Model.IngestionJobS3Source requestSource_source_S3 = null;
            
             // populate S3
            var requestSource_source_S3IsNull = true;
            requestSource_source_S3 = new Amazon.OpenSearchServerless.Model.IngestionJobS3Source();
            System.String requestSource_source_S3_source_S3_Bucket = null;
            if (cmdletContext.Source_S3_Bucket != null)
            {
                requestSource_source_S3_source_S3_Bucket = cmdletContext.Source_S3_Bucket;
            }
            if (requestSource_source_S3_source_S3_Bucket != null)
            {
                requestSource_source_S3.Bucket = requestSource_source_S3_source_S3_Bucket;
                requestSource_source_S3IsNull = false;
            }
            System.String requestSource_source_S3_source_S3_BucketOwnerAccountId = null;
            if (cmdletContext.Source_S3_BucketOwnerAccountId != null)
            {
                requestSource_source_S3_source_S3_BucketOwnerAccountId = cmdletContext.Source_S3_BucketOwnerAccountId;
            }
            if (requestSource_source_S3_source_S3_BucketOwnerAccountId != null)
            {
                requestSource_source_S3.BucketOwnerAccountId = requestSource_source_S3_source_S3_BucketOwnerAccountId;
                requestSource_source_S3IsNull = false;
            }
            System.String requestSource_source_S3_source_S3_KeyPrefix = null;
            if (cmdletContext.Source_S3_KeyPrefix != null)
            {
                requestSource_source_S3_source_S3_KeyPrefix = cmdletContext.Source_S3_KeyPrefix;
            }
            if (requestSource_source_S3_source_S3_KeyPrefix != null)
            {
                requestSource_source_S3.KeyPrefix = requestSource_source_S3_source_S3_KeyPrefix;
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
        
        private Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.CreateIngestionJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "CreateIngestionJob");
            try
            {
                return client.CreateIngestionJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IngestionJobName { get; set; }
            public System.String Source_S3_Bucket { get; set; }
            public System.String Source_S3_BucketOwnerAccountId { get; set; }
            public System.String Source_S3_KeyPrefix { get; set; }
            public List<Amazon.OpenSearchServerless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.CreateIngestionJobResponse, NewOSSIngestionJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IngestionJobDetail;
        }
        
    }
}
