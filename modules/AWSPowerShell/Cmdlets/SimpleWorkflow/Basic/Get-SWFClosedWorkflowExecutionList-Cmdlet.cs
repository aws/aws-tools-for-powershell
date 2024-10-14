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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns a list of closed workflow executions in the specified domain that meet the
    /// filtering criteria. The results may be split into multiple pages. To retrieve subsequent
    /// pages, make the call again using the nextPageToken returned by the initial call.
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
    /// Constrain the following parameters by using a <c>Condition</c> element with the appropriate
    /// keys.
    /// </para><ul><li><para><c>tagFilter.tag</c>: String constraint. The key is <c>swf:tagFilter.tag</c>.
    /// </para></li><li><para><c>typeFilter.name</c>: String constraint. The key is <c>swf:typeFilter.name</c>.
    /// </para></li><li><para><c>typeFilter.version</c>: String constraint. The key is <c>swf:typeFilter.version</c>.
    /// </para></li></ul></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <c>cause</c> parameter is set to <c>OPERATION_NOT_PERMITTED</c>. For details
    /// and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SWFClosedWorkflowExecutionList")]
    [OutputType("Amazon.SimpleWorkflow.Model.WorkflowExecutionInfo")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) ListClosedWorkflowExecutions API operation.", Operation = new[] {"ListClosedWorkflowExecutions"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse))]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.WorkflowExecutionInfo or Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse",
        "This cmdlet returns a collection of Amazon.SimpleWorkflow.Model.WorkflowExecutionInfo objects.",
        "The service call response (type Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSWFClosedWorkflowExecutionListCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain that contains the workflow executions to list.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter CloseTimeFilter_LatestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the latest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CloseTimeFilter_LatestDate { get; set; }
        #endregion
        
        #region Parameter StartTimeFilter_LatestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the latest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTimeFilter_LatestDate { get; set; }
        #endregion
        
        #region Parameter TypeFilter_Name
        /// <summary>
        /// <para>
        /// <para> Name of the workflow type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeFilter_Name { get; set; }
        #endregion
        
        #region Parameter CloseTimeFilter_OldestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the oldest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CloseTimeFilter_OldestDate { get; set; }
        #endregion
        
        #region Parameter StartTimeFilter_OldestDate
        /// <summary>
        /// <para>
        /// <para>Specifies the oldest start or close date and time to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTimeFilter_OldestDate { get; set; }
        #endregion
        
        #region Parameter ReverseOrder
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, returns the results in reverse order. By default the results
        /// are returned in descending order of the start or the close time of the executions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReverseOrder { get; set; }
        #endregion
        
        #region Parameter CloseStatusFilter_Status
        /// <summary>
        /// <para>
        /// <para> The close status that must match the close status of an execution for it to meet
        /// the criteria of this filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleWorkflow.CloseStatus")]
        public Amazon.SimpleWorkflow.CloseStatus CloseStatusFilter_Status { get; set; }
        #endregion
        
        #region Parameter TagFilter_Tag
        /// <summary>
        /// <para>
        /// <para> Specifies the tag that must be associated with the execution for it to meet the filter
        /// criteria.</para><para>Tags may only contain unicode letters, digits, whitespace, or these symbols: <c>_
        /// . : / = + - @</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TagFilter_Tag { get; set; }
        #endregion
        
        #region Parameter TypeFilter_Version
        /// <summary>
        /// <para>
        /// <para>Version of the workflow type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeFilter_Version { get; set; }
        #endregion
        
        #region Parameter ExecutionFilter_WorkflowId
        /// <summary>
        /// <para>
        /// <para>The workflowId to pass of match the criteria of this filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionFilter_WorkflowId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkflowExecutionInfos.ExecutionInfos'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkflowExecutionInfos.ExecutionInfos";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Domain parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Domain' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Domain' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse, GetSWFClosedWorkflowExecutionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Domain;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloseStatusFilter_Status = this.CloseStatusFilter_Status;
            context.CloseTimeFilter_LatestDate = this.CloseTimeFilter_LatestDate;
            context.CloseTimeFilter_OldestDate = this.CloseTimeFilter_OldestDate;
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionFilter_WorkflowId = this.ExecutionFilter_WorkflowId;
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
            context.StartTimeFilter_LatestDate = this.StartTimeFilter_LatestDate;
            context.StartTimeFilter_OldestDate = this.StartTimeFilter_OldestDate;
            context.TagFilter_Tag = this.TagFilter_Tag;
            context.TypeFilter_Name = this.TypeFilter_Name;
            context.TypeFilter_Version = this.TypeFilter_Version;
            
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsRequest();
            
            
             // populate CloseStatusFilter
            var requestCloseStatusFilterIsNull = true;
            request.CloseStatusFilter = new Amazon.SimpleWorkflow.Model.CloseStatusFilter();
            Amazon.SimpleWorkflow.CloseStatus requestCloseStatusFilter_closeStatusFilter_Status = null;
            if (cmdletContext.CloseStatusFilter_Status != null)
            {
                requestCloseStatusFilter_closeStatusFilter_Status = cmdletContext.CloseStatusFilter_Status;
            }
            if (requestCloseStatusFilter_closeStatusFilter_Status != null)
            {
                request.CloseStatusFilter.Status = requestCloseStatusFilter_closeStatusFilter_Status;
                requestCloseStatusFilterIsNull = false;
            }
             // determine if request.CloseStatusFilter should be set to null
            if (requestCloseStatusFilterIsNull)
            {
                request.CloseStatusFilter = null;
            }
            
             // populate CloseTimeFilter
            var requestCloseTimeFilterIsNull = true;
            request.CloseTimeFilter = new Amazon.SimpleWorkflow.Model.ExecutionTimeFilter();
            System.DateTime? requestCloseTimeFilter_closeTimeFilter_LatestDate = null;
            if (cmdletContext.CloseTimeFilter_LatestDate != null)
            {
                requestCloseTimeFilter_closeTimeFilter_LatestDate = cmdletContext.CloseTimeFilter_LatestDate.Value;
            }
            if (requestCloseTimeFilter_closeTimeFilter_LatestDate != null)
            {
                request.CloseTimeFilter.LatestDate = requestCloseTimeFilter_closeTimeFilter_LatestDate.Value;
                requestCloseTimeFilterIsNull = false;
            }
            System.DateTime? requestCloseTimeFilter_closeTimeFilter_OldestDate = null;
            if (cmdletContext.CloseTimeFilter_OldestDate != null)
            {
                requestCloseTimeFilter_closeTimeFilter_OldestDate = cmdletContext.CloseTimeFilter_OldestDate.Value;
            }
            if (requestCloseTimeFilter_closeTimeFilter_OldestDate != null)
            {
                request.CloseTimeFilter.OldestDate = requestCloseTimeFilter_closeTimeFilter_OldestDate.Value;
                requestCloseTimeFilterIsNull = false;
            }
             // determine if request.CloseTimeFilter should be set to null
            if (requestCloseTimeFilterIsNull)
            {
                request.CloseTimeFilter = null;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate ExecutionFilter
            var requestExecutionFilterIsNull = true;
            request.ExecutionFilter = new Amazon.SimpleWorkflow.Model.WorkflowExecutionFilter();
            System.String requestExecutionFilter_executionFilter_WorkflowId = null;
            if (cmdletContext.ExecutionFilter_WorkflowId != null)
            {
                requestExecutionFilter_executionFilter_WorkflowId = cmdletContext.ExecutionFilter_WorkflowId;
            }
            if (requestExecutionFilter_executionFilter_WorkflowId != null)
            {
                request.ExecutionFilter.WorkflowId = requestExecutionFilter_executionFilter_WorkflowId;
                requestExecutionFilterIsNull = false;
            }
             // determine if request.ExecutionFilter should be set to null
            if (requestExecutionFilterIsNull)
            {
                request.ExecutionFilter = null;
            }
            if (cmdletContext.MaximumPageSize != null)
            {
                request.MaximumPageSize = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaximumPageSize.Value);
            }
            if (cmdletContext.ReverseOrder != null)
            {
                request.ReverseOrder = cmdletContext.ReverseOrder.Value;
            }
            
             // populate StartTimeFilter
            var requestStartTimeFilterIsNull = true;
            request.StartTimeFilter = new Amazon.SimpleWorkflow.Model.ExecutionTimeFilter();
            System.DateTime? requestStartTimeFilter_startTimeFilter_LatestDate = null;
            if (cmdletContext.StartTimeFilter_LatestDate != null)
            {
                requestStartTimeFilter_startTimeFilter_LatestDate = cmdletContext.StartTimeFilter_LatestDate.Value;
            }
            if (requestStartTimeFilter_startTimeFilter_LatestDate != null)
            {
                request.StartTimeFilter.LatestDate = requestStartTimeFilter_startTimeFilter_LatestDate.Value;
                requestStartTimeFilterIsNull = false;
            }
            System.DateTime? requestStartTimeFilter_startTimeFilter_OldestDate = null;
            if (cmdletContext.StartTimeFilter_OldestDate != null)
            {
                requestStartTimeFilter_startTimeFilter_OldestDate = cmdletContext.StartTimeFilter_OldestDate.Value;
            }
            if (requestStartTimeFilter_startTimeFilter_OldestDate != null)
            {
                request.StartTimeFilter.OldestDate = requestStartTimeFilter_startTimeFilter_OldestDate.Value;
                requestStartTimeFilterIsNull = false;
            }
             // determine if request.StartTimeFilter should be set to null
            if (requestStartTimeFilterIsNull)
            {
                request.StartTimeFilter = null;
            }
            
             // populate TagFilter
            var requestTagFilterIsNull = true;
            request.TagFilter = new Amazon.SimpleWorkflow.Model.TagFilter();
            System.String requestTagFilter_tagFilter_Tag = null;
            if (cmdletContext.TagFilter_Tag != null)
            {
                requestTagFilter_tagFilter_Tag = cmdletContext.TagFilter_Tag;
            }
            if (requestTagFilter_tagFilter_Tag != null)
            {
                request.TagFilter.Tag = requestTagFilter_tagFilter_Tag;
                requestTagFilterIsNull = false;
            }
             // determine if request.TagFilter should be set to null
            if (requestTagFilterIsNull)
            {
                request.TagFilter = null;
            }
            
             // populate TypeFilter
            var requestTypeFilterIsNull = true;
            request.TypeFilter = new Amazon.SimpleWorkflow.Model.WorkflowTypeFilter();
            System.String requestTypeFilter_typeFilter_Name = null;
            if (cmdletContext.TypeFilter_Name != null)
            {
                requestTypeFilter_typeFilter_Name = cmdletContext.TypeFilter_Name;
            }
            if (requestTypeFilter_typeFilter_Name != null)
            {
                request.TypeFilter.Name = requestTypeFilter_typeFilter_Name;
                requestTypeFilterIsNull = false;
            }
            System.String requestTypeFilter_typeFilter_Version = null;
            if (cmdletContext.TypeFilter_Version != null)
            {
                requestTypeFilter_typeFilter_Version = cmdletContext.TypeFilter_Version;
            }
            if (requestTypeFilter_typeFilter_Version != null)
            {
                request.TypeFilter.Version = requestTypeFilter_typeFilter_Version;
                requestTypeFilterIsNull = false;
            }
             // determine if request.TypeFilter should be set to null
            if (requestTypeFilterIsNull)
            {
                request.TypeFilter = null;
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
                    
                    _nextToken = response.WorkflowExecutionInfos.NextPageToken;
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsRequest();
            
             // populate CloseStatusFilter
            var requestCloseStatusFilterIsNull = true;
            request.CloseStatusFilter = new Amazon.SimpleWorkflow.Model.CloseStatusFilter();
            Amazon.SimpleWorkflow.CloseStatus requestCloseStatusFilter_closeStatusFilter_Status = null;
            if (cmdletContext.CloseStatusFilter_Status != null)
            {
                requestCloseStatusFilter_closeStatusFilter_Status = cmdletContext.CloseStatusFilter_Status;
            }
            if (requestCloseStatusFilter_closeStatusFilter_Status != null)
            {
                request.CloseStatusFilter.Status = requestCloseStatusFilter_closeStatusFilter_Status;
                requestCloseStatusFilterIsNull = false;
            }
             // determine if request.CloseStatusFilter should be set to null
            if (requestCloseStatusFilterIsNull)
            {
                request.CloseStatusFilter = null;
            }
            
             // populate CloseTimeFilter
            var requestCloseTimeFilterIsNull = true;
            request.CloseTimeFilter = new Amazon.SimpleWorkflow.Model.ExecutionTimeFilter();
            System.DateTime? requestCloseTimeFilter_closeTimeFilter_LatestDate = null;
            if (cmdletContext.CloseTimeFilter_LatestDate != null)
            {
                requestCloseTimeFilter_closeTimeFilter_LatestDate = cmdletContext.CloseTimeFilter_LatestDate.Value;
            }
            if (requestCloseTimeFilter_closeTimeFilter_LatestDate != null)
            {
                request.CloseTimeFilter.LatestDate = requestCloseTimeFilter_closeTimeFilter_LatestDate.Value;
                requestCloseTimeFilterIsNull = false;
            }
            System.DateTime? requestCloseTimeFilter_closeTimeFilter_OldestDate = null;
            if (cmdletContext.CloseTimeFilter_OldestDate != null)
            {
                requestCloseTimeFilter_closeTimeFilter_OldestDate = cmdletContext.CloseTimeFilter_OldestDate.Value;
            }
            if (requestCloseTimeFilter_closeTimeFilter_OldestDate != null)
            {
                request.CloseTimeFilter.OldestDate = requestCloseTimeFilter_closeTimeFilter_OldestDate.Value;
                requestCloseTimeFilterIsNull = false;
            }
             // determine if request.CloseTimeFilter should be set to null
            if (requestCloseTimeFilterIsNull)
            {
                request.CloseTimeFilter = null;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate ExecutionFilter
            var requestExecutionFilterIsNull = true;
            request.ExecutionFilter = new Amazon.SimpleWorkflow.Model.WorkflowExecutionFilter();
            System.String requestExecutionFilter_executionFilter_WorkflowId = null;
            if (cmdletContext.ExecutionFilter_WorkflowId != null)
            {
                requestExecutionFilter_executionFilter_WorkflowId = cmdletContext.ExecutionFilter_WorkflowId;
            }
            if (requestExecutionFilter_executionFilter_WorkflowId != null)
            {
                request.ExecutionFilter.WorkflowId = requestExecutionFilter_executionFilter_WorkflowId;
                requestExecutionFilterIsNull = false;
            }
             // determine if request.ExecutionFilter should be set to null
            if (requestExecutionFilterIsNull)
            {
                request.ExecutionFilter = null;
            }
            if (cmdletContext.ReverseOrder != null)
            {
                request.ReverseOrder = cmdletContext.ReverseOrder.Value;
            }
            
             // populate StartTimeFilter
            var requestStartTimeFilterIsNull = true;
            request.StartTimeFilter = new Amazon.SimpleWorkflow.Model.ExecutionTimeFilter();
            System.DateTime? requestStartTimeFilter_startTimeFilter_LatestDate = null;
            if (cmdletContext.StartTimeFilter_LatestDate != null)
            {
                requestStartTimeFilter_startTimeFilter_LatestDate = cmdletContext.StartTimeFilter_LatestDate.Value;
            }
            if (requestStartTimeFilter_startTimeFilter_LatestDate != null)
            {
                request.StartTimeFilter.LatestDate = requestStartTimeFilter_startTimeFilter_LatestDate.Value;
                requestStartTimeFilterIsNull = false;
            }
            System.DateTime? requestStartTimeFilter_startTimeFilter_OldestDate = null;
            if (cmdletContext.StartTimeFilter_OldestDate != null)
            {
                requestStartTimeFilter_startTimeFilter_OldestDate = cmdletContext.StartTimeFilter_OldestDate.Value;
            }
            if (requestStartTimeFilter_startTimeFilter_OldestDate != null)
            {
                request.StartTimeFilter.OldestDate = requestStartTimeFilter_startTimeFilter_OldestDate.Value;
                requestStartTimeFilterIsNull = false;
            }
             // determine if request.StartTimeFilter should be set to null
            if (requestStartTimeFilterIsNull)
            {
                request.StartTimeFilter = null;
            }
            
             // populate TagFilter
            var requestTagFilterIsNull = true;
            request.TagFilter = new Amazon.SimpleWorkflow.Model.TagFilter();
            System.String requestTagFilter_tagFilter_Tag = null;
            if (cmdletContext.TagFilter_Tag != null)
            {
                requestTagFilter_tagFilter_Tag = cmdletContext.TagFilter_Tag;
            }
            if (requestTagFilter_tagFilter_Tag != null)
            {
                request.TagFilter.Tag = requestTagFilter_tagFilter_Tag;
                requestTagFilterIsNull = false;
            }
             // determine if request.TagFilter should be set to null
            if (requestTagFilterIsNull)
            {
                request.TagFilter = null;
            }
            
             // populate TypeFilter
            var requestTypeFilterIsNull = true;
            request.TypeFilter = new Amazon.SimpleWorkflow.Model.WorkflowTypeFilter();
            System.String requestTypeFilter_typeFilter_Name = null;
            if (cmdletContext.TypeFilter_Name != null)
            {
                requestTypeFilter_typeFilter_Name = cmdletContext.TypeFilter_Name;
            }
            if (requestTypeFilter_typeFilter_Name != null)
            {
                request.TypeFilter.Name = requestTypeFilter_typeFilter_Name;
                requestTypeFilterIsNull = false;
            }
            System.String requestTypeFilter_typeFilter_Version = null;
            if (cmdletContext.TypeFilter_Version != null)
            {
                requestTypeFilter_typeFilter_Version = cmdletContext.TypeFilter_Version;
            }
            if (requestTypeFilter_typeFilter_Version != null)
            {
                request.TypeFilter.Version = requestTypeFilter_typeFilter_Version;
                requestTypeFilterIsNull = false;
            }
             // determine if request.TypeFilter should be set to null
            if (requestTypeFilterIsNull)
            {
                request.TypeFilter = null;
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
                    int _receivedThisCall = response.WorkflowExecutionInfos.ExecutionInfos.Count;
                    
                    _nextToken = response.WorkflowExecutionInfos.NextPageToken;
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
        
        private Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "ListClosedWorkflowExecutions");
            try
            {
                #if DESKTOP
                return client.ListClosedWorkflowExecutions(request);
                #elif CORECLR
                return client.ListClosedWorkflowExecutionsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SimpleWorkflow.CloseStatus CloseStatusFilter_Status { get; set; }
            public System.DateTime? CloseTimeFilter_LatestDate { get; set; }
            public System.DateTime? CloseTimeFilter_OldestDate { get; set; }
            public System.String Domain { get; set; }
            public System.String ExecutionFilter_WorkflowId { get; set; }
            public int? MaximumPageSize { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Boolean? ReverseOrder { get; set; }
            public System.DateTime? StartTimeFilter_LatestDate { get; set; }
            public System.DateTime? StartTimeFilter_OldestDate { get; set; }
            public System.String TagFilter_Tag { get; set; }
            public System.String TypeFilter_Name { get; set; }
            public System.String TypeFilter_Version { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.ListClosedWorkflowExecutionsResponse, GetSWFClosedWorkflowExecutionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkflowExecutionInfos.ExecutionInfos;
        }
        
    }
}
