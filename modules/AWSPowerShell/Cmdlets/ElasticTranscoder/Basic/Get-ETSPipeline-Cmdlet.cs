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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The ListPipelines operation gets a list of the pipelines associated with the current
    /// AWS account.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ETSPipeline")]
    [OutputType("Amazon.ElasticTranscoder.Model.Pipeline")]
    [AWSCmdlet("Calls the Amazon Elastic Transcoder ListPipelines API operation.", Operation = new[] {"ListPipelines"}, SelectReturnType = typeof(Amazon.ElasticTranscoder.Model.ListPipelinesResponse))]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.Pipeline or Amazon.ElasticTranscoder.Model.ListPipelinesResponse",
        "This cmdlet returns a collection of Amazon.ElasticTranscoder.Model.Pipeline objects.",
        "The service call response (type Amazon.ElasticTranscoder.Model.ListPipelinesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetETSPipelineCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Ascending
        /// <summary>
        /// <para>
        /// <para>To list pipelines in chronological order by the date and time that they were created,
        /// enter <c>true</c>. To list pipelines in reverse chronological order, enter <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Ascending { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para>When Elastic Transcoder returns more than one page of results, use <c>pageToken</c>
        /// in subsequent <c>GET</c> requests to get each successive page of results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'PageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-PageToken' to null for the first call then set the 'PageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Pipelines'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticTranscoder.Model.ListPipelinesResponse).
        /// Specifying the name of a property of type Amazon.ElasticTranscoder.Model.ListPipelinesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Pipelines";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of PageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticTranscoder.Model.ListPipelinesResponse, GetETSPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Ascending = this.Ascending;
            context.PageToken = this.PageToken;
            
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
            var request = new Amazon.ElasticTranscoder.Model.ListPipelinesRequest();
            
            if (cmdletContext.Ascending != null)
            {
                request.Ascending = cmdletContext.Ascending;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.PageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.PageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.PageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
        
        private Amazon.ElasticTranscoder.Model.ListPipelinesResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.ListPipelinesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Transcoder", "ListPipelines");
            try
            {
                return client.ListPipelinesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Ascending { get; set; }
            public System.String PageToken { get; set; }
            public System.Func<Amazon.ElasticTranscoder.Model.ListPipelinesResponse, GetETSPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Pipelines;
        }
        
    }
}
