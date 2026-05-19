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
using Amazon.DevOpsAgent;
using Amazon.DevOpsAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOPS
{
    /// <summary>
    /// Lists backlog tasks in the specified agent space with optional filtering and sorting<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DOPSBacklogTaskList")]
    [OutputType("Amazon.DevOpsAgent.Model.Task")]
    [AWSCmdlet("Calls the AWS DevOps Agent Service ListBacklogTasks API operation.", Operation = new[] {"ListBacklogTasks"}, SelectReturnType = typeof(Amazon.DevOpsAgent.Model.ListBacklogTasksResponse))]
    [AWSCmdletOutput("Amazon.DevOpsAgent.Model.Task or Amazon.DevOpsAgent.Model.ListBacklogTasksResponse",
        "This cmdlet returns a collection of Amazon.DevOpsAgent.Model.Task objects.",
        "The service call response (type Amazon.DevOpsAgent.Model.ListBacklogTasksResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDOPSBacklogTaskListCmdlet : AmazonDevOpsAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the agent space containing the tasks</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>Filter for tasks created after this timestamp inclusive</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>Filter for tasks created before this timestamp exclusive</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter Order
        /// <summary>
        /// <para>
        /// <para>Sort order for the tasks based on sortField (default: DESC)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.TaskSortOrder")]
        public Amazon.DevOpsAgent.TaskSortOrder Order { get; set; }
        #endregion
        
        #region Parameter Filter_PrimaryTaskId
        /// <summary>
        /// <para>
        /// <para>Filter by primary task ID to get linked tasks</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_PrimaryTaskId { get; set; }
        #endregion
        
        #region Parameter Filter_Priority
        /// <summary>
        /// <para>
        /// <para>Filter by priority (single value only)</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filter_Priority { get; set; }
        #endregion
        
        #region Parameter SortField
        /// <summary>
        /// <para>
        /// <para>Field to sort by Sorting restrictions: - Only sorting on createdAt is supported when
        /// using priority or status filters alone. - Sorting by priority is not supported when
        /// using Timestamp filters (createdAfter, createdBefore)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsAgent.TaskSortField")]
        public Amazon.DevOpsAgent.TaskSortField SortField { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>Filter by status (single value only)</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_TaskType
        /// <summary>
        /// <para>
        /// <para>Filter by task type (single value only)</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filter_TaskType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of tasks to return in a single response (1-1000, default: 100)</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token for retrieving the next page of results</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Tasks'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsAgent.Model.ListBacklogTasksResponse).
        /// Specifying the name of a property of type Amazon.DevOpsAgent.Model.ListBacklogTasksResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Tasks";
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
                context.Select = CreateSelectDelegate<Amazon.DevOpsAgent.Model.ListBacklogTasksResponse, GetDOPSBacklogTaskListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filter_CreatedAfter = this.Filter_CreatedAfter;
            context.Filter_CreatedBefore = this.Filter_CreatedBefore;
            context.Filter_PrimaryTaskId = this.Filter_PrimaryTaskId;
            if (this.Filter_Priority != null)
            {
                context.Filter_Priority = new List<System.String>(this.Filter_Priority);
            }
            if (this.Filter_Status != null)
            {
                context.Filter_Status = new List<System.String>(this.Filter_Status);
            }
            if (this.Filter_TaskType != null)
            {
                context.Filter_TaskType = new List<System.String>(this.Filter_TaskType);
            }
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Order = this.Order;
            context.SortField = this.SortField;
            
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
            var request = new Amazon.DevOpsAgent.Model.ListBacklogTasksRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.DevOpsAgent.Model.TaskFilter();
            System.DateTime? requestFilter_filter_CreatedAfter = null;
            if (cmdletContext.Filter_CreatedAfter != null)
            {
                requestFilter_filter_CreatedAfter = cmdletContext.Filter_CreatedAfter.Value;
            }
            if (requestFilter_filter_CreatedAfter != null)
            {
                request.Filter.CreatedAfter = requestFilter_filter_CreatedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreatedBefore = null;
            if (cmdletContext.Filter_CreatedBefore != null)
            {
                requestFilter_filter_CreatedBefore = cmdletContext.Filter_CreatedBefore.Value;
            }
            if (requestFilter_filter_CreatedBefore != null)
            {
                request.Filter.CreatedBefore = requestFilter_filter_CreatedBefore.Value;
                requestFilterIsNull = false;
            }
            System.String requestFilter_filter_PrimaryTaskId = null;
            if (cmdletContext.Filter_PrimaryTaskId != null)
            {
                requestFilter_filter_PrimaryTaskId = cmdletContext.Filter_PrimaryTaskId;
            }
            if (requestFilter_filter_PrimaryTaskId != null)
            {
                request.Filter.PrimaryTaskId = requestFilter_filter_PrimaryTaskId;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Priority = null;
            if (cmdletContext.Filter_Priority != null)
            {
                requestFilter_filter_Priority = cmdletContext.Filter_Priority;
            }
            if (requestFilter_filter_Priority != null)
            {
                request.Filter.Priority = requestFilter_filter_Priority;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_TaskType = null;
            if (cmdletContext.Filter_TaskType != null)
            {
                requestFilter_filter_TaskType = cmdletContext.Filter_TaskType;
            }
            if (requestFilter_filter_TaskType != null)
            {
                request.Filter.TaskType = requestFilter_filter_TaskType;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.Order != null)
            {
                request.Order = cmdletContext.Order;
            }
            if (cmdletContext.SortField != null)
            {
                request.SortField = cmdletContext.SortField;
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
        
        private Amazon.DevOpsAgent.Model.ListBacklogTasksResponse CallAWSServiceOperation(IAmazonDevOpsAgent client, Amazon.DevOpsAgent.Model.ListBacklogTasksRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DevOps Agent Service", "ListBacklogTasks");
            try
            {
                return client.ListBacklogTasksAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public System.DateTime? Filter_CreatedAfter { get; set; }
            public System.DateTime? Filter_CreatedBefore { get; set; }
            public System.String Filter_PrimaryTaskId { get; set; }
            public List<System.String> Filter_Priority { get; set; }
            public List<System.String> Filter_Status { get; set; }
            public List<System.String> Filter_TaskType { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.DevOpsAgent.TaskSortOrder Order { get; set; }
            public Amazon.DevOpsAgent.TaskSortField SortField { get; set; }
            public System.Func<Amazon.DevOpsAgent.Model.ListBacklogTasksResponse, GetDOPSBacklogTaskListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Tasks;
        }
        
    }
}
