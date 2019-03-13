/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns the history of the specified workflow execution. The results may be split
    /// into multiple pages. To retrieve subsequent pages, make the call again using the <code>nextPageToken</code>
    /// returned by the initial call.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not exactly
    /// reflect recent updates and changes.
    /// </para></note><para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <code>Resource</code> element with the domain name to limit the action to only
    /// specified domains.
    /// </para></li><li><para>
    /// Use an <code>Action</code> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// You cannot use an IAM policy to constrain this action's parameters.
    /// </para></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <code>cause</code> parameter is set to <code>OPERATION_NOT_PERMITTED</code>.
    /// For details and example IAM policies, see <a href="http://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "SWFWorkflowExecutionHistory")]
    [OutputType("Amazon.SimpleWorkflow.Model.HistoryEvent")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service GetWorkflowExecutionHistory API operation.", Operation = new[] {"GetWorkflowExecutionHistory"})]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.HistoryEvent",
        "This cmdlet returns a collection of HistoryEvent objects.",
        "The service call response (type Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextPageToken (type System.String)"
    )]
    public partial class GetSWFWorkflowExecutionHistoryCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain containing the workflow execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ReverseOrder
        /// <summary>
        /// <para>
        /// <para>When set to <code>true</code>, returns the events in reverse order. By default the
        /// results are returned in ascending order of the <code>eventTimeStamp</code> of the
        /// events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ReverseOrder { get; set; }
        #endregion
        
        #region Parameter Execution_RunId
        /// <summary>
        /// <para>
        /// <para>A system-generated unique identifier for the workflow execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Execution_RunId { get; set; }
        #endregion
        
        #region Parameter Execution_WorkflowId
        /// <summary>
        /// <para>
        /// <para>The user defined identifier associated with the workflow execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Execution_WorkflowId { get; set; }
        #endregion
        
        #region Parameter MaximumPageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that are returned per call. <code>nextPageToken</code>
        /// can be used to obtain futher pages of results. The default is 1000, which is the maximum
        /// allowed page size. You can, however, specify a page size <i>smaller</i> than the maximum.</para><para>This is an upper limit only; the actual number of results returned per call may be
        /// fewer than the specified maximum.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaximumPageSize { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>If a <code>NextPageToken</code> was returned by a previous call, there are more results
        /// available. To retrieve the next page of results, make the call again using the returned
        /// token in <code>nextPageToken</code>. Keep all other arguments unchanged.</para><para>The configured <code>maximumPageSize</code> determines how many results can be returned
        /// in a single call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextPageToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Domain = this.Domain;
            context.Execution_RunId = this.Execution_RunId;
            context.Execution_WorkflowId = this.Execution_WorkflowId;
            if (ParameterWasBound("MaximumPageSize"))
                context.MaximumPageSize = this.MaximumPageSize;
            context.NextPageToken = this.NextPageToken;
            if (ParameterWasBound("ReverseOrder"))
                context.ReverseOrder = this.ReverseOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryRequest();
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate Execution
            bool requestExecutionIsNull = true;
            request.Execution = new Amazon.SimpleWorkflow.Model.WorkflowExecution();
            System.String requestExecution_execution_RunId = null;
            if (cmdletContext.Execution_RunId != null)
            {
                requestExecution_execution_RunId = cmdletContext.Execution_RunId;
            }
            if (requestExecution_execution_RunId != null)
            {
                request.Execution.RunId = requestExecution_execution_RunId;
                requestExecutionIsNull = false;
            }
            System.String requestExecution_execution_WorkflowId = null;
            if (cmdletContext.Execution_WorkflowId != null)
            {
                requestExecution_execution_WorkflowId = cmdletContext.Execution_WorkflowId;
            }
            if (requestExecution_execution_WorkflowId != null)
            {
                request.Execution.WorkflowId = requestExecution_execution_WorkflowId;
                requestExecutionIsNull = false;
            }
             // determine if request.Execution should be set to null
            if (requestExecutionIsNull)
            {
                request.Execution = null;
            }
            if (cmdletContext.ReverseOrder != null)
            {
                request.ReverseOrder = cmdletContext.ReverseOrder.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextPageToken))
            {
                _nextMarker = cmdletContext.NextPageToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaximumPageSize))
            {
                _emitLimit = cmdletContext.MaximumPageSize;
            }
            bool _userControllingPaging = ParameterWasBound("NextPageToken") || ParameterWasBound("MaximumPageSize");
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextPageToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaximumPageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.History.Events;
                        notes = new Dictionary<string, object>();
                        notes["NextPageToken"] = response.History.NextPageToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.History.Events.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextPageToken));
                        }
                        
                        _nextMarker = response.History.NextPageToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service", "GetWorkflowExecutionHistory");
            try
            {
                #if DESKTOP
                return client.GetWorkflowExecutionHistory(request);
                #elif CORECLR
                return client.GetWorkflowExecutionHistoryAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.String Execution_RunId { get; set; }
            public System.String Execution_WorkflowId { get; set; }
            public int? MaximumPageSize { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Boolean? ReverseOrder { get; set; }
        }
        
    }
}
