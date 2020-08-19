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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Provides summaries of all notebook executions. You can filter the list based on multiple
    /// criteria such as status, time range, and editor id. Returns a maximum of 50 notebook
    /// executions and a marker to track the paging of a longer notebook execution list across
    /// multiple <code>ListNotebookExecution</code> calls.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EMRNotebookExecutionList")]
    [OutputType("Amazon.ElasticMapReduce.Model.NotebookExecutionSummary")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce ListNotebookExecutions API operation.", Operation = new[] {"ListNotebookExecutions"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.NotebookExecutionSummary or Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse",
        "This cmdlet returns a collection of Amazon.ElasticMapReduce.Model.NotebookExecutionSummary objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEMRNotebookExecutionListCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter EditorId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the editor associated with the notebook execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EditorId { get; set; }
        #endregion
        
        #region Parameter From
        /// <summary>
        /// <para>
        /// <para>The beginning of time range filter for listing notebook executions. The default is
        /// the timestamp of 30 days ago.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? From { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status filter for listing notebook executions.</para><ul><li><para><code>START_PENDING</code> indicates that the cluster has received the execution
        /// request but execution has not begun.</para></li><li><para><code>STARTING</code> indicates that the execution is starting on the cluster.</para></li><li><para><code>RUNNING</code> indicates that the execution is being processed by the cluster.</para></li><li><para><code>FINISHING</code> indicates that execution processing is in the final stages.</para></li><li><para><code>FINISHED</code> indicates that the execution has completed without error.</para></li><li><para><code>FAILING</code> indicates that the execution is failing and will not finish
        /// successfully.</para></li><li><para><code>FAILED</code> indicates that the execution failed.</para></li><li><para><code>STOP_PENDING</code> indicates that the cluster has received a <code>StopNotebookExecution</code>
        /// request and the stop is pending.</para></li><li><para><code>STOPPING</code> indicates that the cluster is in the process of stopping the
        /// execution as a result of a <code>StopNotebookExecution</code> request.</para></li><li><para><code>STOPPED</code> indicates that the execution stopped because of a <code>StopNotebookExecution</code>
        /// request.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.NotebookExecutionStatus")]
        public Amazon.ElasticMapReduce.NotebookExecutionStatus Status { get; set; }
        #endregion
        
        #region Parameter To
        /// <summary>
        /// <para>
        /// <para>The end of time range filter for listing notebook executions. The default is the current
        /// timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? To { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>The pagination token, returned by a previous <code>ListNotebookExecutions</code> call,
        /// that indicates the start of the list for this <code>ListNotebookExecutions</code>
        /// call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-Marker $null' for the first call and '-Marker $AWSHistory.LastServiceResponse.Marker' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotebookExecutions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotebookExecutions";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse, GetEMRNotebookExecutionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EditorId = this.EditorId;
            context.From = this.From;
            context.Marker = this.Marker;
            context.Status = this.Status;
            context.To = this.To;
            
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
            var request = new Amazon.ElasticMapReduce.Model.ListNotebookExecutionsRequest();
            
            if (cmdletContext.EditorId != null)
            {
                request.EditorId = cmdletContext.EditorId;
            }
            if (cmdletContext.From != null)
            {
                request.From = cmdletContext.From.Value;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.To != null)
            {
                request.To = cmdletContext.To.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.Marker;
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
        
        private Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.ListNotebookExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "ListNotebookExecutions");
            try
            {
                #if DESKTOP
                return client.ListNotebookExecutions(request);
                #elif CORECLR
                return client.ListNotebookExecutionsAsync(request).GetAwaiter().GetResult();
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
            public System.String EditorId { get; set; }
            public System.DateTime? From { get; set; }
            public System.String Marker { get; set; }
            public Amazon.ElasticMapReduce.NotebookExecutionStatus Status { get; set; }
            public System.DateTime? To { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.ListNotebookExecutionsResponse, GetEMRNotebookExecutionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotebookExecutions;
        }
        
    }
}
