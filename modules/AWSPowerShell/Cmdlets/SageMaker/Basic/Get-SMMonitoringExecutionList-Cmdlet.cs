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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Returns list of all monitoring job executions.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMMonitoringExecutionList")]
    [OutputType("Amazon.SageMaker.Model.MonitoringExecutionSummary")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ListMonitoringExecutions API operation.", Operation = new[] {"ListMonitoringExecutions"}, SelectReturnType = typeof(Amazon.SageMaker.Model.ListMonitoringExecutionsResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.MonitoringExecutionSummary or Amazon.SageMaker.Model.ListMonitoringExecutionsResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.MonitoringExecutionSummary objects.",
        "The service call response (type Amazon.SageMaker.Model.ListMonitoringExecutionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMMonitoringExecutionListCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>A filter that returns only jobs created after a specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>A filter that returns only jobs created before a specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>Name of a specific endpoint to fetch jobs for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter LastModifiedTimeAfter
        /// <summary>
        /// <para>
        /// <para>A filter that returns only jobs modified before a specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LastModifiedTimeAfter { get; set; }
        #endregion
        
        #region Parameter LastModifiedTimeBefore
        /// <summary>
        /// <para>
        /// <para>A filter that returns only jobs modified after a specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LastModifiedTimeBefore { get; set; }
        #endregion
        
        #region Parameter MonitoringJobDefinitionName
        /// <summary>
        /// <para>
        /// <para>Gets a list of the monitoring job runs of the specified monitoring job definitions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringJobDefinitionName { get; set; }
        #endregion
        
        #region Parameter MonitoringScheduleName
        /// <summary>
        /// <para>
        /// <para>Name of a specific schedule to fetch jobs for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringScheduleName { get; set; }
        #endregion
        
        #region Parameter MonitoringTypeEqual
        /// <summary>
        /// <para>
        /// <para>A filter that returns only the monitoring job runs of the specified monitoring type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringTypeEquals")]
        [AWSConstantClassSource("Amazon.SageMaker.MonitoringType")]
        public Amazon.SageMaker.MonitoringType MonitoringTypeEqual { get; set; }
        #endregion
        
        #region Parameter ScheduledTimeAfter
        /// <summary>
        /// <para>
        /// <para>Filter for jobs scheduled after a specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledTimeAfter { get; set; }
        #endregion
        
        #region Parameter ScheduledTimeBefore
        /// <summary>
        /// <para>
        /// <para>Filter for jobs scheduled before a specified time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ScheduledTimeBefore { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Whether to sort the results by the <c>Status</c>, <c>CreationTime</c>, or <c>ScheduledTime</c>
        /// field. The default is <c>CreationTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.MonitoringExecutionSortKey")]
        public Amazon.SageMaker.MonitoringExecutionSortKey SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Whether to sort the results in <c>Ascending</c> or <c>Descending</c> order. The default
        /// is <c>Descending</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SortOrder")]
        public Amazon.SageMaker.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter StatusEqual
        /// <summary>
        /// <para>
        /// <para>A filter that retrieves only jobs with a specific status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusEquals")]
        [AWSConstantClassSource("Amazon.SageMaker.ExecutionStatus")]
        public Amazon.SageMaker.ExecutionStatus StatusEqual { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of jobs to return in the response. The default value is 10.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>100</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned if the response is truncated. To retrieve the next set of job executions,
        /// use it in the next request.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MonitoringExecutionSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.ListMonitoringExecutionsResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.ListMonitoringExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MonitoringExecutionSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.ListMonitoringExecutionsResponse, GetSMMonitoringExecutionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreationTimeAfter = this.CreationTimeAfter;
            context.CreationTimeBefore = this.CreationTimeBefore;
            context.EndpointName = this.EndpointName;
            context.LastModifiedTimeAfter = this.LastModifiedTimeAfter;
            context.LastModifiedTimeBefore = this.LastModifiedTimeBefore;
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '100'");
                context.MaxResult = 100;
            }
            #endif
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.MonitoringJobDefinitionName = this.MonitoringJobDefinitionName;
            context.MonitoringScheduleName = this.MonitoringScheduleName;
            context.MonitoringTypeEqual = this.MonitoringTypeEqual;
            context.NextToken = this.NextToken;
            context.ScheduledTimeAfter = this.ScheduledTimeAfter;
            context.ScheduledTimeBefore = this.ScheduledTimeBefore;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.StatusEqual = this.StatusEqual;
            
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
            var request = new Amazon.SageMaker.Model.ListMonitoringExecutionsRequest();
            
            if (cmdletContext.CreationTimeAfter != null)
            {
                request.CreationTimeAfter = cmdletContext.CreationTimeAfter.Value;
            }
            if (cmdletContext.CreationTimeBefore != null)
            {
                request.CreationTimeBefore = cmdletContext.CreationTimeBefore.Value;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.LastModifiedTimeAfter != null)
            {
                request.LastModifiedTimeAfter = cmdletContext.LastModifiedTimeAfter.Value;
            }
            if (cmdletContext.LastModifiedTimeBefore != null)
            {
                request.LastModifiedTimeBefore = cmdletContext.LastModifiedTimeBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MonitoringJobDefinitionName != null)
            {
                request.MonitoringJobDefinitionName = cmdletContext.MonitoringJobDefinitionName;
            }
            if (cmdletContext.MonitoringScheduleName != null)
            {
                request.MonitoringScheduleName = cmdletContext.MonitoringScheduleName;
            }
            if (cmdletContext.MonitoringTypeEqual != null)
            {
                request.MonitoringTypeEquals = cmdletContext.MonitoringTypeEqual;
            }
            if (cmdletContext.ScheduledTimeAfter != null)
            {
                request.ScheduledTimeAfter = cmdletContext.ScheduledTimeAfter.Value;
            }
            if (cmdletContext.ScheduledTimeBefore != null)
            {
                request.ScheduledTimeBefore = cmdletContext.ScheduledTimeBefore.Value;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.StatusEqual != null)
            {
                request.StatusEquals = cmdletContext.StatusEqual;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.ListMonitoringExecutionsRequest();
            if (cmdletContext.CreationTimeAfter != null)
            {
                request.CreationTimeAfter = cmdletContext.CreationTimeAfter.Value;
            }
            if (cmdletContext.CreationTimeBefore != null)
            {
                request.CreationTimeBefore = cmdletContext.CreationTimeBefore.Value;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.LastModifiedTimeAfter != null)
            {
                request.LastModifiedTimeAfter = cmdletContext.LastModifiedTimeAfter.Value;
            }
            if (cmdletContext.LastModifiedTimeBefore != null)
            {
                request.LastModifiedTimeBefore = cmdletContext.LastModifiedTimeBefore.Value;
            }
            if (cmdletContext.MonitoringJobDefinitionName != null)
            {
                request.MonitoringJobDefinitionName = cmdletContext.MonitoringJobDefinitionName;
            }
            if (cmdletContext.MonitoringScheduleName != null)
            {
                request.MonitoringScheduleName = cmdletContext.MonitoringScheduleName;
            }
            if (cmdletContext.MonitoringTypeEqual != null)
            {
                request.MonitoringTypeEquals = cmdletContext.MonitoringTypeEqual;
            }
            if (cmdletContext.ScheduledTimeAfter != null)
            {
                request.ScheduledTimeAfter = cmdletContext.ScheduledTimeAfter.Value;
            }
            if (cmdletContext.ScheduledTimeBefore != null)
            {
                request.ScheduledTimeBefore = cmdletContext.ScheduledTimeBefore.Value;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.StatusEqual != null)
            {
                request.StatusEquals = cmdletContext.StatusEqual;
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
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
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
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(100);
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
                    int _receivedThisCall = response.MonitoringExecutionSummaries.Count;
                    
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
        
        private Amazon.SageMaker.Model.ListMonitoringExecutionsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ListMonitoringExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ListMonitoringExecutions");
            try
            {
                #if DESKTOP
                return client.ListMonitoringExecutions(request);
                #elif CORECLR
                return client.ListMonitoringExecutionsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? CreationTimeAfter { get; set; }
            public System.DateTime? CreationTimeBefore { get; set; }
            public System.String EndpointName { get; set; }
            public System.DateTime? LastModifiedTimeAfter { get; set; }
            public System.DateTime? LastModifiedTimeBefore { get; set; }
            public int? MaxResult { get; set; }
            public System.String MonitoringJobDefinitionName { get; set; }
            public System.String MonitoringScheduleName { get; set; }
            public Amazon.SageMaker.MonitoringType MonitoringTypeEqual { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? ScheduledTimeAfter { get; set; }
            public System.DateTime? ScheduledTimeBefore { get; set; }
            public Amazon.SageMaker.MonitoringExecutionSortKey SortBy { get; set; }
            public Amazon.SageMaker.SortOrder SortOrder { get; set; }
            public Amazon.SageMaker.ExecutionStatus StatusEqual { get; set; }
            public System.Func<Amazon.SageMaker.Model.ListMonitoringExecutionsResponse, GetSMMonitoringExecutionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MonitoringExecutionSummaries;
        }
        
    }
}
