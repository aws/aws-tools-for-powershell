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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Gets a list of runs for a machine learning transform. Machine learning task runs are
    /// asynchronous tasks that AWS Glue runs on your behalf as part of various machine learning
    /// workflows. You can get a sortable, filterable list of machine learning task runs by
    /// calling <code>GetMLTaskRuns</code> with their parent transform's <code>TransformID</code>
    /// and other optional parameters as documented in this section.
    /// 
    ///  
    /// <para>
    /// This operation returns a list of historic runs and must be paginated.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "GLUEMLTaskRunList")]
    [OutputType("Amazon.Glue.Model.TaskRun")]
    [AWSCmdlet("Calls the AWS Glue GetMLTaskRuns API operation.", Operation = new[] {"GetMLTaskRuns"}, SelectReturnType = typeof(Amazon.Glue.Model.GetMLTaskRunsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.TaskRun or Amazon.Glue.Model.GetMLTaskRunsResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.TaskRun objects.",
        "The service call response (type Amazon.Glue.Model.GetMLTaskRunsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGLUEMLTaskRunListCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter Sort_Column
        /// <summary>
        /// <para>
        /// <para>The column to be used to sort the list of task runs for the machine learning transform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.TaskRunSortColumnType")]
        public Amazon.Glue.TaskRunSortColumnType Sort_Column { get; set; }
        #endregion
        
        #region Parameter Sort_SortDirection
        /// <summary>
        /// <para>
        /// <para>The sort direction to be used to sort the list of task runs for the machine learning
        /// transform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.SortDirectionType")]
        public Amazon.Glue.SortDirectionType Sort_SortDirection { get; set; }
        #endregion
        
        #region Parameter Filter_StartedAfter
        /// <summary>
        /// <para>
        /// <para>Filter on task runs started after this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_StartedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_StartedBefore
        /// <summary>
        /// <para>
        /// <para>Filter on task runs started before this date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Filter_StartedBefore { get; set; }
        #endregion
        
        #region Parameter Filter_Status
        /// <summary>
        /// <para>
        /// <para>The current status of the task run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.TaskStatusType")]
        public Amazon.Glue.TaskStatusType Filter_Status { get; set; }
        #endregion
        
        #region Parameter Filter_TaskRunType
        /// <summary>
        /// <para>
        /// <para>The type of task run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.TaskType")]
        public Amazon.Glue.TaskType Filter_TaskRunType { get; set; }
        #endregion
        
        #region Parameter TransformId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the machine learning transform.</para>
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
        public System.String TransformId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token for pagination of the results. The default is empty.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskRuns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetMLTaskRunsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetMLTaskRunsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskRuns";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransformId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransformId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransformId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetMLTaskRunsResponse, GetGLUEMLTaskRunListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransformId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filter_StartedAfter = this.Filter_StartedAfter;
            context.Filter_StartedBefore = this.Filter_StartedBefore;
            context.Filter_Status = this.Filter_Status;
            context.Filter_TaskRunType = this.Filter_TaskRunType;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.Sort_Column = this.Sort_Column;
            context.Sort_SortDirection = this.Sort_SortDirection;
            context.TransformId = this.TransformId;
            #if MODULAR
            if (this.TransformId == null && ParameterWasBound(nameof(this.TransformId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Glue.Model.GetMLTaskRunsRequest();
            
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Glue.Model.TaskRunFilterCriteria();
            System.DateTime? requestFilter_filter_StartedAfter = null;
            if (cmdletContext.Filter_StartedAfter != null)
            {
                requestFilter_filter_StartedAfter = cmdletContext.Filter_StartedAfter.Value;
            }
            if (requestFilter_filter_StartedAfter != null)
            {
                request.Filter.StartedAfter = requestFilter_filter_StartedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_StartedBefore = null;
            if (cmdletContext.Filter_StartedBefore != null)
            {
                requestFilter_filter_StartedBefore = cmdletContext.Filter_StartedBefore.Value;
            }
            if (requestFilter_filter_StartedBefore != null)
            {
                request.Filter.StartedBefore = requestFilter_filter_StartedBefore.Value;
                requestFilterIsNull = false;
            }
            Amazon.Glue.TaskStatusType requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            Amazon.Glue.TaskType requestFilter_filter_TaskRunType = null;
            if (cmdletContext.Filter_TaskRunType != null)
            {
                requestFilter_filter_TaskRunType = cmdletContext.Filter_TaskRunType;
            }
            if (requestFilter_filter_TaskRunType != null)
            {
                request.Filter.TaskRunType = requestFilter_filter_TaskRunType;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.Glue.Model.TaskRunSortCriteria();
            Amazon.Glue.TaskRunSortColumnType requestSort_sort_Column = null;
            if (cmdletContext.Sort_Column != null)
            {
                requestSort_sort_Column = cmdletContext.Sort_Column;
            }
            if (requestSort_sort_Column != null)
            {
                request.Sort.Column = requestSort_sort_Column;
                requestSortIsNull = false;
            }
            Amazon.Glue.SortDirectionType requestSort_sort_SortDirection = null;
            if (cmdletContext.Sort_SortDirection != null)
            {
                requestSort_sort_SortDirection = cmdletContext.Sort_SortDirection;
            }
            if (requestSort_sort_SortDirection != null)
            {
                request.Sort.SortDirection = requestSort_sort_SortDirection;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            if (cmdletContext.TransformId != null)
            {
                request.TransformId = cmdletContext.TransformId;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.Glue.Model.GetMLTaskRunsRequest();
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Glue.Model.TaskRunFilterCriteria();
            System.DateTime? requestFilter_filter_StartedAfter = null;
            if (cmdletContext.Filter_StartedAfter != null)
            {
                requestFilter_filter_StartedAfter = cmdletContext.Filter_StartedAfter.Value;
            }
            if (requestFilter_filter_StartedAfter != null)
            {
                request.Filter.StartedAfter = requestFilter_filter_StartedAfter.Value;
                requestFilterIsNull = false;
            }
            System.DateTime? requestFilter_filter_StartedBefore = null;
            if (cmdletContext.Filter_StartedBefore != null)
            {
                requestFilter_filter_StartedBefore = cmdletContext.Filter_StartedBefore.Value;
            }
            if (requestFilter_filter_StartedBefore != null)
            {
                request.Filter.StartedBefore = requestFilter_filter_StartedBefore.Value;
                requestFilterIsNull = false;
            }
            Amazon.Glue.TaskStatusType requestFilter_filter_Status = null;
            if (cmdletContext.Filter_Status != null)
            {
                requestFilter_filter_Status = cmdletContext.Filter_Status;
            }
            if (requestFilter_filter_Status != null)
            {
                request.Filter.Status = requestFilter_filter_Status;
                requestFilterIsNull = false;
            }
            Amazon.Glue.TaskType requestFilter_filter_TaskRunType = null;
            if (cmdletContext.Filter_TaskRunType != null)
            {
                requestFilter_filter_TaskRunType = cmdletContext.Filter_TaskRunType;
            }
            if (requestFilter_filter_TaskRunType != null)
            {
                request.Filter.TaskRunType = requestFilter_filter_TaskRunType;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            
             // populate Sort
            var requestSortIsNull = true;
            request.Sort = new Amazon.Glue.Model.TaskRunSortCriteria();
            Amazon.Glue.TaskRunSortColumnType requestSort_sort_Column = null;
            if (cmdletContext.Sort_Column != null)
            {
                requestSort_sort_Column = cmdletContext.Sort_Column;
            }
            if (requestSort_sort_Column != null)
            {
                request.Sort.Column = requestSort_sort_Column;
                requestSortIsNull = false;
            }
            Amazon.Glue.SortDirectionType requestSort_sort_SortDirection = null;
            if (cmdletContext.Sort_SortDirection != null)
            {
                requestSort_sort_SortDirection = cmdletContext.Sort_SortDirection;
            }
            if (requestSort_sort_SortDirection != null)
            {
                request.Sort.SortDirection = requestSort_sort_SortDirection;
                requestSortIsNull = false;
            }
             // determine if request.Sort should be set to null
            if (requestSortIsNull)
            {
                request.Sort = null;
            }
            if (cmdletContext.TransformId != null)
            {
                request.TransformId = cmdletContext.TransformId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.TaskRuns.Count;
                    
                    _nextToken = response.NextToken;
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
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
        
        private Amazon.Glue.Model.GetMLTaskRunsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetMLTaskRunsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetMLTaskRuns");
            try
            {
                #if DESKTOP
                return client.GetMLTaskRuns(request);
                #elif CORECLR
                return client.GetMLTaskRunsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? Filter_StartedAfter { get; set; }
            public System.DateTime? Filter_StartedBefore { get; set; }
            public Amazon.Glue.TaskStatusType Filter_Status { get; set; }
            public Amazon.Glue.TaskType Filter_TaskRunType { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Glue.TaskRunSortColumnType Sort_Column { get; set; }
            public Amazon.Glue.SortDirectionType Sort_SortDirection { get; set; }
            public System.String TransformId { get; set; }
            public System.Func<Amazon.Glue.Model.GetMLTaskRunsResponse, GetGLUEMLTaskRunListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskRuns;
        }
        
    }
}
