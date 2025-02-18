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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns the history of the specified workflow execution. The results may be split
    /// into multiple pages. To retrieve subsequent pages, make the call again using the <c>nextPageToken</c>
    /// returned by the initial call.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not exactly
    /// reflect recent updates and changes.
    /// </para></note><para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <c>Resource</c> element with the domain name to limit the action to only specified
    /// domains.
    /// </para></li><li><para>
    /// Use an <c>Action</c> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// You cannot use an IAM policy to constrain this action's parameters.
    /// </para></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <c>cause</c> parameter is set to <c>OPERATION_NOT_PERMITTED</c>. For details
    /// and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SWFWorkflowExecutionHistory")]
    [OutputType("Amazon.SimpleWorkflow.Model.HistoryEvent")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) GetWorkflowExecutionHistory API operation.", Operation = new[] {"GetWorkflowExecutionHistory"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse))]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.HistoryEvent or Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse",
        "This cmdlet returns a collection of Amazon.SimpleWorkflow.Model.HistoryEvent objects.",
        "The service call response (type Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSWFWorkflowExecutionHistoryCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain containing the workflow execution.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ReverseOrder
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, returns the events in reverse order. By default the results
        /// are returned in ascending order of the <c>eventTimeStamp</c> of the events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReverseOrder { get; set; }
        #endregion
        
        #region Parameter Execution_RunId
        /// <summary>
        /// <para>
        /// <para>A system-generated unique identifier for the workflow execution.</para>
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
        public System.String Execution_RunId { get; set; }
        #endregion
        
        #region Parameter Execution_WorkflowId
        /// <summary>
        /// <para>
        /// <para>The user defined identifier associated with the workflow execution.</para>
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
        public System.String Execution_WorkflowId { get; set; }
        #endregion
        
        #region Parameter MaximumPageSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that are returned per call. Use <c>nextPageToken</c>
        /// to obtain further pages of results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? MaximumPageSize { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>If <c>NextPageToken</c> is returned there are more results available. The value of
        /// <c>NextPageToken</c> is a unique pagination token for each page. Make the call again
        /// using the returned token to retrieve the next page. Keep all other arguments unchanged.
        /// Each pagination token expires after 24 hours. Using an expired pagination token will
        /// return a <c>400</c> error: "<c>Specified token has exceeded its maximum lifetime</c>".
        /// </para><para>The configured <c>maximumPageSize</c> determines how many results can be returned
        /// in a single call. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextPageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextPageToken' to null for the first call then set the 'NextPageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'History.Events'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "History.Events";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse, GetSWFWorkflowExecutionHistoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Execution_RunId = this.Execution_RunId;
            #if MODULAR
            if (this.Execution_RunId == null && ParameterWasBound(nameof(this.Execution_RunId)))
            {
                WriteWarning("You are passing $null as a value for parameter Execution_RunId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Execution_WorkflowId = this.Execution_WorkflowId;
            #if MODULAR
            if (this.Execution_WorkflowId == null && ParameterWasBound(nameof(this.Execution_WorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter Execution_WorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaximumPageSize = this.MaximumPageSize;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaximumPageSize)) && this.MaximumPageSize.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaximumPageSize parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaximumPageSize" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextPageToken = this.NextPageToken;
            context.ReverseOrder = this.ReverseOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate Execution
            var requestExecutionIsNull = true;
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
            if (cmdletContext.MaximumPageSize != null)
            {
                request.MaximumPageSize = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaximumPageSize.Value);
            }
            if (cmdletContext.ReverseOrder != null)
            {
                request.ReverseOrder = cmdletContext.ReverseOrder.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextPageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                
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
                    
                    _nextToken = response.History.NextPageToken;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryRequest();
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate Execution
            var requestExecutionIsNull = true;
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
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextPageToken))
            {
                _nextToken = cmdletContext.NextPageToken;
            }
            if (cmdletContext.MaximumPageSize.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaximumPageSize;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaximumPageSize = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
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
                    int _receivedThisCall = response.History.Events?.Count ?? 0;
                    
                    _nextToken = response.History.NextPageToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 0));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "GetWorkflowExecutionHistory");
            try
            {
                return client.GetWorkflowExecutionHistoryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SimpleWorkflow.Model.GetWorkflowExecutionHistoryResponse, GetSWFWorkflowExecutionHistoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.History.Events;
        }
        
    }
}
