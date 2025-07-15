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
using Amazon.S3Vectors;
using Amazon.S3Vectors.Model;

namespace Amazon.PowerShell.Cmdlets.S3V
{
    /// <summary>
    /// Amazon.S3Vectors.IAmazonS3Vectors.ListVectors<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "S3VVectorList")]
    [OutputType("Amazon.S3Vectors.Model.ListOutputVector")]
    [AWSCmdlet("Calls the Amazon S3 Vectors ListVectors API operation.", Operation = new[] {"ListVectors"}, SelectReturnType = typeof(Amazon.S3Vectors.Model.ListVectorsResponse))]
    [AWSCmdletOutput("Amazon.S3Vectors.Model.ListOutputVector or Amazon.S3Vectors.Model.ListVectorsResponse",
        "This cmdlet returns a collection of Amazon.S3Vectors.Model.ListOutputVector objects.",
        "The service call response (type Amazon.S3Vectors.Model.ListVectorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3VVectorListCmdlet : AmazonS3VectorsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IndexArn
        /// <summary>
        /// <para>
        /// <para>The Amazon resource Name (ARN) of the vector index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexArn { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the vector index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter ReturnData
        /// <summary>
        /// <para>
        /// <para>If true, the vector data of each vector will be included in the response. The default
        /// value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReturnData { get; set; }
        #endregion
        
        #region Parameter ReturnMetadata
        /// <summary>
        /// <para>
        /// <para>If true, the metadata associated with each vector will be included in the response.
        /// The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReturnMetadata { get; set; }
        #endregion
        
        #region Parameter SegmentCount
        /// <summary>
        /// <para>
        /// <para>For a parallel <c>ListVectors</c> request, <c>segmentCount</c> represents the total
        /// number of vector segments into which the <c>ListVectors</c> operation will be divided.
        /// The value of <c>segmentCount</c> corresponds to the number of application workers
        /// that will perform the parallel <c>ListVectors</c> operation. For example, if you want
        /// to use four application threads to list vectors in a vector index, specify a <c>segmentCount</c>
        /// value of 4. </para><para>If you specify a <c>segmentCount</c> value of 1, the <c>ListVectors</c> operation
        /// will be sequential rather than parallel.</para><para>If you specify <c>segmentCount</c>, you must also specify <c>segmentIndex</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SegmentCount { get; set; }
        #endregion
        
        #region Parameter SegmentIndex
        /// <summary>
        /// <para>
        /// <para>For a parallel <c>ListVectors</c> request, <c>segmentIndex</c> is the index of the
        /// segment from which to list vectors in the current request. It identifies an individual
        /// segment to be listed by an application worker. </para><para>Segment IDs are zero-based, so the first segment is always 0. For example, if you
        /// want to use four application threads to list vectors in a vector index, then the first
        /// thread specifies a <c>segmentIndex</c> value of 0, the second thread specifies 1,
        /// and so on. </para><para>The value of <c>segmentIndex</c> must be less than the value provided for <c>segmentCount</c>.
        /// </para><para>If you provide <c>segmentIndex</c>, you must also provide <c>segmentCount</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SegmentIndex { get; set; }
        #endregion
        
        #region Parameter VectorBucketName
        /// <summary>
        /// <para>
        /// <para>The name of the vector bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VectorBucketName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of vectors to return on a page.</para><para>If you don't specify <c>maxResults</c>, the <c>ListVectors</c> operation uses a default
        /// value of 500.</para><para>If the processed dataset size exceeds 1 MB before reaching the <c>maxResults</c> value,
        /// the operation stops and returns the vectors that are retrieved up to that point, along
        /// with a <c>nextToken</c> that you can use in a subsequent request to retrieve the next
        /// set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Pagination token from a previous request. The value of this field is empty for an
        /// initial request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Vectors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Vectors.Model.ListVectorsResponse).
        /// Specifying the name of a property of type Amazon.S3Vectors.Model.ListVectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Vectors";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Vectors.Model.ListVectorsResponse, GetS3VVectorListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IndexArn = this.IndexArn;
            context.IndexName = this.IndexName;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ReturnData = this.ReturnData;
            context.ReturnMetadata = this.ReturnMetadata;
            context.SegmentCount = this.SegmentCount;
            context.SegmentIndex = this.SegmentIndex;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.S3Vectors.Model.ListVectorsRequest();
            
            if (cmdletContext.IndexArn != null)
            {
                request.IndexArn = cmdletContext.IndexArn;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.ReturnData != null)
            {
                request.ReturnData = cmdletContext.ReturnData.Value;
            }
            if (cmdletContext.ReturnMetadata != null)
            {
                request.ReturnMetadata = cmdletContext.ReturnMetadata.Value;
            }
            if (cmdletContext.SegmentCount != null)
            {
                request.SegmentCount = cmdletContext.SegmentCount.Value;
            }
            if (cmdletContext.SegmentIndex != null)
            {
                request.SegmentIndex = cmdletContext.SegmentIndex.Value;
            }
            if (cmdletContext.VectorBucketName != null)
            {
                request.VectorBucketName = cmdletContext.VectorBucketName;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.S3Vectors.Model.ListVectorsResponse CallAWSServiceOperation(IAmazonS3Vectors client, Amazon.S3Vectors.Model.ListVectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Vectors", "ListVectors");
            try
            {
                #if DESKTOP
                return client.ListVectors(request);
                #elif CORECLR
                return client.ListVectorsAsync(request).GetAwaiter().GetResult();
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
            public System.String IndexArn { get; set; }
            public System.String IndexName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? ReturnData { get; set; }
            public System.Boolean? ReturnMetadata { get; set; }
            public System.Int32? SegmentCount { get; set; }
            public System.Int32? SegmentIndex { get; set; }
            public System.String VectorBucketName { get; set; }
            public System.Func<Amazon.S3Vectors.Model.ListVectorsResponse, GetS3VVectorListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Vectors;
        }
        
    }
}
