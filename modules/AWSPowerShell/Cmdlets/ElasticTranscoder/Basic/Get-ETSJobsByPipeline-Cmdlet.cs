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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The ListJobsByPipeline operation gets a list of the jobs currently in a pipeline.
    /// 
    ///  
    /// <para>
    /// Elastic Transcoder returns all of the jobs currently in the specified pipeline. The
    /// response body contains one element for each job that satisfies the search criteria.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ETSJobsByPipeline")]
    [OutputType("Amazon.ElasticTranscoder.Model.Job")]
    [AWSCmdlet("Calls the Amazon Elastic Transcoder ListJobsByPipeline API operation.", Operation = new[] {"ListJobsByPipeline"}, SelectReturnType = typeof(Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse))]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.Job or Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse",
        "This cmdlet returns a collection of Amazon.ElasticTranscoder.Model.Job objects.",
        "The service call response (type Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetETSJobsByPipelineCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Ascending
        /// <summary>
        /// <para>
        /// <para> To list jobs in chronological order by the date and time that they were submitted,
        /// enter <c>true</c>. To list jobs in reverse chronological order, enter <c>false</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Ascending { get; set; }
        #endregion
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline for which you want to get job information.</para>
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
        public System.String PipelineId { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para> When Elastic Transcoder returns more than one page of results, use <c>pageToken</c>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Jobs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse).
        /// Specifying the name of a property of type Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Jobs";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PipelineId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PipelineId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PipelineId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse, GetETSJobsByPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PipelineId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Ascending = this.Ascending;
            context.PageToken = this.PageToken;
            context.PipelineId = this.PipelineId;
            #if MODULAR
            if (this.PipelineId == null && ParameterWasBound(nameof(this.PipelineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticTranscoder.Model.ListJobsByPipelineRequest();
            
            if (cmdletContext.Ascending != null)
            {
                request.Ascending = cmdletContext.Ascending;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
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
        
        private Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.ListJobsByPipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Transcoder", "ListJobsByPipeline");
            try
            {
                #if DESKTOP
                return client.ListJobsByPipeline(request);
                #elif CORECLR
                return client.ListJobsByPipelineAsync(request).GetAwaiter().GetResult();
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
            public System.String Ascending { get; set; }
            public System.String PageToken { get; set; }
            public System.String PipelineId { get; set; }
            public System.Func<Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse, GetETSJobsByPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Jobs;
        }
        
    }
}
