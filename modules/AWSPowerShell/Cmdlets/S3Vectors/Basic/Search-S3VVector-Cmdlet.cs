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
    /// Amazon.S3Vectors.IAmazonS3Vectors.QueryVectors
    /// </summary>
    [Cmdlet("Search", "S3VVector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3Vectors.Model.QueryOutputVector")]
    [AWSCmdlet("Calls the Amazon S3 Vectors QueryVectors API operation.", Operation = new[] {"QueryVectors"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.QueryVectorsResponse))]
    [AWSCmdletOutput("Amazon.S3Vectors.Model.QueryOutputVector or Amazon.S3Vectors.Model.QueryVectorsResponse",
        "This cmdlet returns a collection of Amazon.S3Vectors.Model.QueryOutputVector objects.",
        "The service call response (type Amazon.S3Vectors.Model.QueryVectorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SearchS3VVectorCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Metadata filter to apply during the query. For more information about metadata keys,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-vectors-metadata-filtering.html">Metadata
        /// filtering</a> in the <i>Amazon S3 User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Filter { get; set; }
        #endregion
        
        #region Parameter QueryVector_Float32
        /// <summary>
        /// <para>
        /// <para>The vector data as 32-bit floating point numbers. The number of elements in this array
        /// must exactly match the dimension of the vector index where the operation is being
        /// performed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single[] QueryVector_Float32 { get; set; }
        #endregion
        
        #region Parameter IndexArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the vector index that you want to query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexArn { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index that you want to query. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter ReturnDistance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include the computed distance in the response. The default value
        /// is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReturnDistance { get; set; }
        #endregion
        
        #region Parameter ReturnMetadata
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include metadata in the response. The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReturnMetadata { get; set; }
        #endregion
        
        #region Parameter TopK
        /// <summary>
        /// <para>
        /// <para>The number of results to return for each query.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TopK { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket that contains the vector index. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Vectors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.QueryVectorsResponse).
        /// Specifying the name of a property of type Amazon.S3Vectors.Model.QueryVectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Vectors";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-S3VVector (QueryVectors)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.QueryVectorsResponse, SearchS3VVectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter = this.Filter;
            context.IndexArn = this.IndexArn;
            context.IndexName = this.IndexName;
            if (this.QueryVector_Float32 != null)
            {
                context.QueryVector_Float32 = new List<System.Single>(this.QueryVector_Float32);
            }
            context.ReturnDistance = this.ReturnDistance;
            context.ReturnMetadata = this.ReturnMetadata;
            context.TopK = this.TopK;
            #if MODULAR
            if (this.TopK == null && ParameterWasBound(nameof(this.TopK)))
            {
                WriteWarning("You are passing $null as a value for parameter TopK which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.S3Vectors.Model.QueryVectorsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Filter);
            }
            if (cmdletContext.IndexArn != null)
            {
                request.IndexArn = cmdletContext.IndexArn;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            
             // populate QueryVector
            request.QueryVector = new Amazon.S3Vectors.Model.VectorData();
            List<System.Single> requestQueryVector_queryVector_Float32 = null;
            if (cmdletContext.QueryVector_Float32 != null)
            {
                requestQueryVector_queryVector_Float32 = cmdletContext.QueryVector_Float32;
            }
            if (requestQueryVector_queryVector_Float32 != null)
            {
                request.QueryVector.Float32 = requestQueryVector_queryVector_Float32;
            }
            if (cmdletContext.ReturnDistance != null)
            {
                request.ReturnDistance = cmdletContext.ReturnDistance.Value;
            }
            if (cmdletContext.ReturnMetadata != null)
            {
                request.ReturnMetadata = cmdletContext.ReturnMetadata.Value;
            }
            if (cmdletContext.TopK != null)
            {
                request.TopK = cmdletContext.TopK.Value;
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
        
        private Amazon.S3Vectors.Model.QueryVectorsResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.QueryVectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "QueryVectors");
            try
            {
                return client.QueryVectorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject Filter { get; set; }
            public System.String IndexArn { get; set; }
            public System.String IndexName { get; set; }
            public List<System.Single> QueryVector_Float32 { get; set; }
            public System.Boolean? ReturnDistance { get; set; }
            public System.Boolean? ReturnMetadata { get; set; }
            public System.Int32? TopK { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.QueryVectorsResponse, SearchS3VVectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Vectors;
        }
        
    }
}
