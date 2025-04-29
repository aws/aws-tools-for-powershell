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
using Amazon.Inspector;
using Amazon.Inspector.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Lists the assessment runs that correspond to the assessment templates that are specified
    /// by the ARNs of the assessment templates.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentRunList")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Inspector ListAssessmentRuns API operation.", Operation = new[] {"ListAssessmentRuns"}, SelectReturnType = typeof(Amazon.Inspector.Model.ListAssessmentRunsResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector.Model.ListAssessmentRunsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.Inspector.Model.ListAssessmentRunsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINSAssessmentRunListCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentTemplateArn
        /// <summary>
        /// <para>
        /// <para>The ARNs that specify the assessment templates whose assessment runs you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("AssessmentTemplateArns")]
        public System.String[] AssessmentTemplateArn { get; set; }
        #endregion
        
        #region Parameter CompletionTimeRange_BeginDate
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_CompletionTimeRange_BeginDate")]
        public System.DateTime? CompletionTimeRange_BeginDate { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_BeginDate
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_StartTimeRange_BeginDate")]
        public System.DateTime? StartTimeRange_BeginDate { get; set; }
        #endregion
        
        #region Parameter StateChangeTimeRange_BeginDate
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_StateChangeTimeRange_BeginDate")]
        public System.DateTime? StateChangeTimeRange_BeginDate { get; set; }
        #endregion
        
        #region Parameter CompletionTimeRange_EndDate
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_CompletionTimeRange_EndDate")]
        public System.DateTime? CompletionTimeRange_EndDate { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_EndDate
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_StartTimeRange_EndDate")]
        public System.DateTime? StartTimeRange_EndDate { get; set; }
        #endregion
        
        #region Parameter StateChangeTimeRange_EndDate
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_StateChangeTimeRange_EndDate")]
        public System.DateTime? StateChangeTimeRange_EndDate { get; set; }
        #endregion
        
        #region Parameter DurationRange_MaxSecond
        /// <summary>
        /// <para>
        /// <para>The maximum value of the duration range. Must be less than or equal to 604800 seconds
        /// (1 week).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DurationRange_MaxSeconds")]
        public System.Int32? DurationRange_MaxSecond { get; set; }
        #endregion
        
        #region Parameter DurationRange_MinSecond
        /// <summary>
        /// <para>
        /// <para>The minimum value of the duration range. Must be greater than zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_DurationRange_MinSeconds")]
        public System.Int32? DurationRange_MinSecond { get; set; }
        #endregion
        
        #region Parameter Filter_NamePattern
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, an explicit value or a string containing a wildcard
        /// that is specified for this data type property must match the value of the <b>assessmentRunName</b>
        /// property of the <a>AssessmentRun</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filter_NamePattern { get; set; }
        #endregion
        
        #region Parameter Filter_RulesPackageArn
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the value that is specified for this data type property
        /// must be contained in the list of values of the <b>rulesPackages</b> property of the
        /// <a>AssessmentRun</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_RulesPackageArns")]
        public System.String[] Filter_RulesPackageArn { get; set; }
        #endregion
        
        #region Parameter Filter_State
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, one of the values specified for this data type property
        /// must be the exact match of the value of the <b>assessmentRunState</b> property of
        /// the <a>AssessmentRun</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_States")]
        public System.String[] Filter_State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>You can use this parameter to indicate the maximum number of items that you want in
        /// the response. The default value is 10. The maximum value is 500.</para>
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
        /// <para>You can use this parameter when paginating results. Set the value of this parameter
        /// to null on your first call to the <b>ListAssessmentRuns</b> action. Subsequent calls
        /// to the action fill <b>nextToken</b> in the request with the value of <b>NextToken</b>
        /// from the previous response to continue listing data.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssessmentRunArns'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.ListAssessmentRunsResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.ListAssessmentRunsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssessmentRunArns";
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
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.ListAssessmentRunsResponse, GetINSAssessmentRunListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssessmentTemplateArn != null)
            {
                context.AssessmentTemplateArn = new List<System.String>(this.AssessmentTemplateArn);
            }
            context.CompletionTimeRange_BeginDate = this.CompletionTimeRange_BeginDate;
            context.CompletionTimeRange_EndDate = this.CompletionTimeRange_EndDate;
            context.DurationRange_MaxSecond = this.DurationRange_MaxSecond;
            context.DurationRange_MinSecond = this.DurationRange_MinSecond;
            context.Filter_NamePattern = this.Filter_NamePattern;
            if (this.Filter_RulesPackageArn != null)
            {
                context.Filter_RulesPackageArn = new List<System.String>(this.Filter_RulesPackageArn);
            }
            context.StartTimeRange_BeginDate = this.StartTimeRange_BeginDate;
            context.StartTimeRange_EndDate = this.StartTimeRange_EndDate;
            context.StateChangeTimeRange_BeginDate = this.StateChangeTimeRange_BeginDate;
            context.StateChangeTimeRange_EndDate = this.StateChangeTimeRange_EndDate;
            if (this.Filter_State != null)
            {
                context.Filter_State = new List<System.String>(this.Filter_State);
            }
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
            var request = new Amazon.Inspector.Model.ListAssessmentRunsRequest();
            
            if (cmdletContext.AssessmentTemplateArn != null)
            {
                request.AssessmentTemplateArns = cmdletContext.AssessmentTemplateArn;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Inspector.Model.AssessmentRunFilter();
            System.String requestFilter_filter_NamePattern = null;
            if (cmdletContext.Filter_NamePattern != null)
            {
                requestFilter_filter_NamePattern = cmdletContext.Filter_NamePattern;
            }
            if (requestFilter_filter_NamePattern != null)
            {
                request.Filter.NamePattern = requestFilter_filter_NamePattern;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RulesPackageArn = null;
            if (cmdletContext.Filter_RulesPackageArn != null)
            {
                requestFilter_filter_RulesPackageArn = cmdletContext.Filter_RulesPackageArn;
            }
            if (requestFilter_filter_RulesPackageArn != null)
            {
                request.Filter.RulesPackageArns = requestFilter_filter_RulesPackageArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_State = null;
            if (cmdletContext.Filter_State != null)
            {
                requestFilter_filter_State = cmdletContext.Filter_State;
            }
            if (requestFilter_filter_State != null)
            {
                request.Filter.States = requestFilter_filter_State;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_CompletionTimeRange = null;
            
             // populate CompletionTimeRange
            var requestFilter_filter_CompletionTimeRangeIsNull = true;
            requestFilter_filter_CompletionTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate = null;
            if (cmdletContext.CompletionTimeRange_BeginDate != null)
            {
                requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate = cmdletContext.CompletionTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate != null)
            {
                requestFilter_filter_CompletionTimeRange.BeginDate = requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate.Value;
                requestFilter_filter_CompletionTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate = null;
            if (cmdletContext.CompletionTimeRange_EndDate != null)
            {
                requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate = cmdletContext.CompletionTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate != null)
            {
                requestFilter_filter_CompletionTimeRange.EndDate = requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate.Value;
                requestFilter_filter_CompletionTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_CompletionTimeRange should be set to null
            if (requestFilter_filter_CompletionTimeRangeIsNull)
            {
                requestFilter_filter_CompletionTimeRange = null;
            }
            if (requestFilter_filter_CompletionTimeRange != null)
            {
                request.Filter.CompletionTimeRange = requestFilter_filter_CompletionTimeRange;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.DurationRange requestFilter_filter_DurationRange = null;
            
             // populate DurationRange
            var requestFilter_filter_DurationRangeIsNull = true;
            requestFilter_filter_DurationRange = new Amazon.Inspector.Model.DurationRange();
            System.Int32? requestFilter_filter_DurationRange_durationRange_MaxSecond = null;
            if (cmdletContext.DurationRange_MaxSecond != null)
            {
                requestFilter_filter_DurationRange_durationRange_MaxSecond = cmdletContext.DurationRange_MaxSecond.Value;
            }
            if (requestFilter_filter_DurationRange_durationRange_MaxSecond != null)
            {
                requestFilter_filter_DurationRange.MaxSeconds = requestFilter_filter_DurationRange_durationRange_MaxSecond.Value;
                requestFilter_filter_DurationRangeIsNull = false;
            }
            System.Int32? requestFilter_filter_DurationRange_durationRange_MinSecond = null;
            if (cmdletContext.DurationRange_MinSecond != null)
            {
                requestFilter_filter_DurationRange_durationRange_MinSecond = cmdletContext.DurationRange_MinSecond.Value;
            }
            if (requestFilter_filter_DurationRange_durationRange_MinSecond != null)
            {
                requestFilter_filter_DurationRange.MinSeconds = requestFilter_filter_DurationRange_durationRange_MinSecond.Value;
                requestFilter_filter_DurationRangeIsNull = false;
            }
             // determine if requestFilter_filter_DurationRange should be set to null
            if (requestFilter_filter_DurationRangeIsNull)
            {
                requestFilter_filter_DurationRange = null;
            }
            if (requestFilter_filter_DurationRange != null)
            {
                request.Filter.DurationRange = requestFilter_filter_DurationRange;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_StartTimeRange = null;
            
             // populate StartTimeRange
            var requestFilter_filter_StartTimeRangeIsNull = true;
            requestFilter_filter_StartTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_StartTimeRange_startTimeRange_BeginDate = null;
            if (cmdletContext.StartTimeRange_BeginDate != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_BeginDate = cmdletContext.StartTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_StartTimeRange_startTimeRange_BeginDate != null)
            {
                requestFilter_filter_StartTimeRange.BeginDate = requestFilter_filter_StartTimeRange_startTimeRange_BeginDate.Value;
                requestFilter_filter_StartTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_StartTimeRange_startTimeRange_EndDate = null;
            if (cmdletContext.StartTimeRange_EndDate != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_EndDate = cmdletContext.StartTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_StartTimeRange_startTimeRange_EndDate != null)
            {
                requestFilter_filter_StartTimeRange.EndDate = requestFilter_filter_StartTimeRange_startTimeRange_EndDate.Value;
                requestFilter_filter_StartTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_StartTimeRange should be set to null
            if (requestFilter_filter_StartTimeRangeIsNull)
            {
                requestFilter_filter_StartTimeRange = null;
            }
            if (requestFilter_filter_StartTimeRange != null)
            {
                request.Filter.StartTimeRange = requestFilter_filter_StartTimeRange;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_StateChangeTimeRange = null;
            
             // populate StateChangeTimeRange
            var requestFilter_filter_StateChangeTimeRangeIsNull = true;
            requestFilter_filter_StateChangeTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate = null;
            if (cmdletContext.StateChangeTimeRange_BeginDate != null)
            {
                requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate = cmdletContext.StateChangeTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate != null)
            {
                requestFilter_filter_StateChangeTimeRange.BeginDate = requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate.Value;
                requestFilter_filter_StateChangeTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate = null;
            if (cmdletContext.StateChangeTimeRange_EndDate != null)
            {
                requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate = cmdletContext.StateChangeTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate != null)
            {
                requestFilter_filter_StateChangeTimeRange.EndDate = requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate.Value;
                requestFilter_filter_StateChangeTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_StateChangeTimeRange should be set to null
            if (requestFilter_filter_StateChangeTimeRangeIsNull)
            {
                requestFilter_filter_StateChangeTimeRange = null;
            }
            if (requestFilter_filter_StateChangeTimeRange != null)
            {
                request.Filter.StateChangeTimeRange = requestFilter_filter_StateChangeTimeRange;
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
            var request = new Amazon.Inspector.Model.ListAssessmentRunsRequest();
            if (cmdletContext.AssessmentTemplateArn != null)
            {
                request.AssessmentTemplateArns = cmdletContext.AssessmentTemplateArn;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.Inspector.Model.AssessmentRunFilter();
            System.String requestFilter_filter_NamePattern = null;
            if (cmdletContext.Filter_NamePattern != null)
            {
                requestFilter_filter_NamePattern = cmdletContext.Filter_NamePattern;
            }
            if (requestFilter_filter_NamePattern != null)
            {
                request.Filter.NamePattern = requestFilter_filter_NamePattern;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RulesPackageArn = null;
            if (cmdletContext.Filter_RulesPackageArn != null)
            {
                requestFilter_filter_RulesPackageArn = cmdletContext.Filter_RulesPackageArn;
            }
            if (requestFilter_filter_RulesPackageArn != null)
            {
                request.Filter.RulesPackageArns = requestFilter_filter_RulesPackageArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_State = null;
            if (cmdletContext.Filter_State != null)
            {
                requestFilter_filter_State = cmdletContext.Filter_State;
            }
            if (requestFilter_filter_State != null)
            {
                request.Filter.States = requestFilter_filter_State;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_CompletionTimeRange = null;
            
             // populate CompletionTimeRange
            var requestFilter_filter_CompletionTimeRangeIsNull = true;
            requestFilter_filter_CompletionTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate = null;
            if (cmdletContext.CompletionTimeRange_BeginDate != null)
            {
                requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate = cmdletContext.CompletionTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate != null)
            {
                requestFilter_filter_CompletionTimeRange.BeginDate = requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate.Value;
                requestFilter_filter_CompletionTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate = null;
            if (cmdletContext.CompletionTimeRange_EndDate != null)
            {
                requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate = cmdletContext.CompletionTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate != null)
            {
                requestFilter_filter_CompletionTimeRange.EndDate = requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate.Value;
                requestFilter_filter_CompletionTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_CompletionTimeRange should be set to null
            if (requestFilter_filter_CompletionTimeRangeIsNull)
            {
                requestFilter_filter_CompletionTimeRange = null;
            }
            if (requestFilter_filter_CompletionTimeRange != null)
            {
                request.Filter.CompletionTimeRange = requestFilter_filter_CompletionTimeRange;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.DurationRange requestFilter_filter_DurationRange = null;
            
             // populate DurationRange
            var requestFilter_filter_DurationRangeIsNull = true;
            requestFilter_filter_DurationRange = new Amazon.Inspector.Model.DurationRange();
            System.Int32? requestFilter_filter_DurationRange_durationRange_MaxSecond = null;
            if (cmdletContext.DurationRange_MaxSecond != null)
            {
                requestFilter_filter_DurationRange_durationRange_MaxSecond = cmdletContext.DurationRange_MaxSecond.Value;
            }
            if (requestFilter_filter_DurationRange_durationRange_MaxSecond != null)
            {
                requestFilter_filter_DurationRange.MaxSeconds = requestFilter_filter_DurationRange_durationRange_MaxSecond.Value;
                requestFilter_filter_DurationRangeIsNull = false;
            }
            System.Int32? requestFilter_filter_DurationRange_durationRange_MinSecond = null;
            if (cmdletContext.DurationRange_MinSecond != null)
            {
                requestFilter_filter_DurationRange_durationRange_MinSecond = cmdletContext.DurationRange_MinSecond.Value;
            }
            if (requestFilter_filter_DurationRange_durationRange_MinSecond != null)
            {
                requestFilter_filter_DurationRange.MinSeconds = requestFilter_filter_DurationRange_durationRange_MinSecond.Value;
                requestFilter_filter_DurationRangeIsNull = false;
            }
             // determine if requestFilter_filter_DurationRange should be set to null
            if (requestFilter_filter_DurationRangeIsNull)
            {
                requestFilter_filter_DurationRange = null;
            }
            if (requestFilter_filter_DurationRange != null)
            {
                request.Filter.DurationRange = requestFilter_filter_DurationRange;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_StartTimeRange = null;
            
             // populate StartTimeRange
            var requestFilter_filter_StartTimeRangeIsNull = true;
            requestFilter_filter_StartTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_StartTimeRange_startTimeRange_BeginDate = null;
            if (cmdletContext.StartTimeRange_BeginDate != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_BeginDate = cmdletContext.StartTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_StartTimeRange_startTimeRange_BeginDate != null)
            {
                requestFilter_filter_StartTimeRange.BeginDate = requestFilter_filter_StartTimeRange_startTimeRange_BeginDate.Value;
                requestFilter_filter_StartTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_StartTimeRange_startTimeRange_EndDate = null;
            if (cmdletContext.StartTimeRange_EndDate != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_EndDate = cmdletContext.StartTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_StartTimeRange_startTimeRange_EndDate != null)
            {
                requestFilter_filter_StartTimeRange.EndDate = requestFilter_filter_StartTimeRange_startTimeRange_EndDate.Value;
                requestFilter_filter_StartTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_StartTimeRange should be set to null
            if (requestFilter_filter_StartTimeRangeIsNull)
            {
                requestFilter_filter_StartTimeRange = null;
            }
            if (requestFilter_filter_StartTimeRange != null)
            {
                request.Filter.StartTimeRange = requestFilter_filter_StartTimeRange;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_StateChangeTimeRange = null;
            
             // populate StateChangeTimeRange
            var requestFilter_filter_StateChangeTimeRangeIsNull = true;
            requestFilter_filter_StateChangeTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate = null;
            if (cmdletContext.StateChangeTimeRange_BeginDate != null)
            {
                requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate = cmdletContext.StateChangeTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate != null)
            {
                requestFilter_filter_StateChangeTimeRange.BeginDate = requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate.Value;
                requestFilter_filter_StateChangeTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate = null;
            if (cmdletContext.StateChangeTimeRange_EndDate != null)
            {
                requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate = cmdletContext.StateChangeTimeRange_EndDate.Value;
            }
            if (requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate != null)
            {
                requestFilter_filter_StateChangeTimeRange.EndDate = requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate.Value;
                requestFilter_filter_StateChangeTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_StateChangeTimeRange should be set to null
            if (requestFilter_filter_StateChangeTimeRangeIsNull)
            {
                requestFilter_filter_StateChangeTimeRange = null;
            }
            if (requestFilter_filter_StateChangeTimeRange != null)
            {
                request.Filter.StateChangeTimeRange = requestFilter_filter_StateChangeTimeRange;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
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
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
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
                    int _receivedThisCall = response.AssessmentRunArns?.Count ?? 0;
                    
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
        
        private Amazon.Inspector.Model.ListAssessmentRunsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.ListAssessmentRunsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "ListAssessmentRuns");
            try
            {
                return client.ListAssessmentRunsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AssessmentTemplateArn { get; set; }
            public System.DateTime? CompletionTimeRange_BeginDate { get; set; }
            public System.DateTime? CompletionTimeRange_EndDate { get; set; }
            public System.Int32? DurationRange_MaxSecond { get; set; }
            public System.Int32? DurationRange_MinSecond { get; set; }
            public System.String Filter_NamePattern { get; set; }
            public List<System.String> Filter_RulesPackageArn { get; set; }
            public System.DateTime? StartTimeRange_BeginDate { get; set; }
            public System.DateTime? StartTimeRange_EndDate { get; set; }
            public System.DateTime? StateChangeTimeRange_BeginDate { get; set; }
            public System.DateTime? StateChangeTimeRange_EndDate { get; set; }
            public List<System.String> Filter_State { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Inspector.Model.ListAssessmentRunsResponse, GetINSAssessmentRunListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssessmentRunArns;
        }
        
    }
}
