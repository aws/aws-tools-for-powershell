/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Inspector;
using Amazon.Inspector.Model;

namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Lists the assessment runs that correspond to the assessment templates that are specified
    /// by the ARNs of the assessment templates.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentRunList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListAssessmentRuns operation against Amazon Inspector.", Operation = new[] {"ListAssessmentRuns"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.Inspector.Model.ListAssessmentRunsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetINSAssessmentRunListCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter AssessmentTemplateArn
        /// <summary>
        /// <para>
        /// <para>The ARNs that specify the assessment templates whose assessment runs you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentTemplateArns")]
        public System.String[] AssessmentTemplateArn { get; set; }
        #endregion
        
        #region Parameter CompletionTimeRange_BeginDate
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_CompletionTimeRange_BeginDate")]
        public System.DateTime CompletionTimeRange_BeginDate { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_BeginDate
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StartTimeRange_BeginDate")]
        public System.DateTime StartTimeRange_BeginDate { get; set; }
        #endregion
        
        #region Parameter StateChangeTimeRange_BeginDate
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StateChangeTimeRange_BeginDate")]
        public System.DateTime StateChangeTimeRange_BeginDate { get; set; }
        #endregion
        
        #region Parameter CompletionTimeRange_EndDate
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_CompletionTimeRange_EndDate")]
        public System.DateTime CompletionTimeRange_EndDate { get; set; }
        #endregion
        
        #region Parameter StartTimeRange_EndDate
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StartTimeRange_EndDate")]
        public System.DateTime StartTimeRange_EndDate { get; set; }
        #endregion
        
        #region Parameter StateChangeTimeRange_EndDate
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StateChangeTimeRange_EndDate")]
        public System.DateTime StateChangeTimeRange_EndDate { get; set; }
        #endregion
        
        #region Parameter DurationRange_MaxSecond
        /// <summary>
        /// <para>
        /// <para>The maximum value of the duration range. Must be less than or equal to 604800 seconds
        /// (1 week).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_DurationRange_MaxSeconds")]
        public System.Int32 DurationRange_MaxSecond { get; set; }
        #endregion
        
        #region Parameter DurationRange_MinSecond
        /// <summary>
        /// <para>
        /// <para>The minimum value of the duration range. Must be greater than zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_DurationRange_MinSeconds")]
        public System.Int32 DurationRange_MinSecond { get; set; }
        #endregion
        
        #region Parameter Filter_NamePattern
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, an explicit value or a string containing a wildcard
        /// that is specified for this data type property must match the value of the <b>assessmentRunName</b>
        /// property of the <a>AssessmentRun</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("Filter_States")]
        public System.String[] Filter_State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>You can use this parameter to indicate the maximum number of items that you want in
        /// the response. The default value is 10. The maximum value is 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>You can use this parameter when paginating results. Set the value of this parameter
        /// to null on your first call to the <b>ListAssessmentRuns</b> action. Subsequent calls
        /// to the action fill <b>nextToken</b> in the request with the value of <b>NextToken</b>
        /// from the previous response to continue listing data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AssessmentTemplateArn != null)
            {
                context.AssessmentTemplateArns = new List<System.String>(this.AssessmentTemplateArn);
            }
            if (ParameterWasBound("CompletionTimeRange_BeginDate"))
                context.Filter_CompletionTimeRange_BeginDate = this.CompletionTimeRange_BeginDate;
            if (ParameterWasBound("CompletionTimeRange_EndDate"))
                context.Filter_CompletionTimeRange_EndDate = this.CompletionTimeRange_EndDate;
            if (ParameterWasBound("DurationRange_MaxSecond"))
                context.Filter_DurationRange_MaxSeconds = this.DurationRange_MaxSecond;
            if (ParameterWasBound("DurationRange_MinSecond"))
                context.Filter_DurationRange_MinSeconds = this.DurationRange_MinSecond;
            context.Filter_NamePattern = this.Filter_NamePattern;
            if (this.Filter_RulesPackageArn != null)
            {
                context.Filter_RulesPackageArns = new List<System.String>(this.Filter_RulesPackageArn);
            }
            if (ParameterWasBound("StartTimeRange_BeginDate"))
                context.Filter_StartTimeRange_BeginDate = this.StartTimeRange_BeginDate;
            if (ParameterWasBound("StartTimeRange_EndDate"))
                context.Filter_StartTimeRange_EndDate = this.StartTimeRange_EndDate;
            if (ParameterWasBound("StateChangeTimeRange_BeginDate"))
                context.Filter_StateChangeTimeRange_BeginDate = this.StateChangeTimeRange_BeginDate;
            if (ParameterWasBound("StateChangeTimeRange_EndDate"))
                context.Filter_StateChangeTimeRange_EndDate = this.StateChangeTimeRange_EndDate;
            if (this.Filter_State != null)
            {
                context.Filter_States = new List<System.String>(this.Filter_State);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.Inspector.Model.ListAssessmentRunsRequest();
            if (cmdletContext.AssessmentTemplateArns != null)
            {
                request.AssessmentTemplateArns = cmdletContext.AssessmentTemplateArns;
            }
            
             // populate Filter
            bool requestFilterIsNull = true;
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
            if (cmdletContext.Filter_RulesPackageArns != null)
            {
                requestFilter_filter_RulesPackageArn = cmdletContext.Filter_RulesPackageArns;
            }
            if (requestFilter_filter_RulesPackageArn != null)
            {
                request.Filter.RulesPackageArns = requestFilter_filter_RulesPackageArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_State = null;
            if (cmdletContext.Filter_States != null)
            {
                requestFilter_filter_State = cmdletContext.Filter_States;
            }
            if (requestFilter_filter_State != null)
            {
                request.Filter.States = requestFilter_filter_State;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_CompletionTimeRange = null;
            
             // populate CompletionTimeRange
            bool requestFilter_filter_CompletionTimeRangeIsNull = true;
            requestFilter_filter_CompletionTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate = null;
            if (cmdletContext.Filter_CompletionTimeRange_BeginDate != null)
            {
                requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate = cmdletContext.Filter_CompletionTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate != null)
            {
                requestFilter_filter_CompletionTimeRange.BeginDate = requestFilter_filter_CompletionTimeRange_completionTimeRange_BeginDate.Value;
                requestFilter_filter_CompletionTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate = null;
            if (cmdletContext.Filter_CompletionTimeRange_EndDate != null)
            {
                requestFilter_filter_CompletionTimeRange_completionTimeRange_EndDate = cmdletContext.Filter_CompletionTimeRange_EndDate.Value;
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
            bool requestFilter_filter_DurationRangeIsNull = true;
            requestFilter_filter_DurationRange = new Amazon.Inspector.Model.DurationRange();
            System.Int32? requestFilter_filter_DurationRange_durationRange_MaxSecond = null;
            if (cmdletContext.Filter_DurationRange_MaxSeconds != null)
            {
                requestFilter_filter_DurationRange_durationRange_MaxSecond = cmdletContext.Filter_DurationRange_MaxSeconds.Value;
            }
            if (requestFilter_filter_DurationRange_durationRange_MaxSecond != null)
            {
                requestFilter_filter_DurationRange.MaxSeconds = requestFilter_filter_DurationRange_durationRange_MaxSecond.Value;
                requestFilter_filter_DurationRangeIsNull = false;
            }
            System.Int32? requestFilter_filter_DurationRange_durationRange_MinSecond = null;
            if (cmdletContext.Filter_DurationRange_MinSeconds != null)
            {
                requestFilter_filter_DurationRange_durationRange_MinSecond = cmdletContext.Filter_DurationRange_MinSeconds.Value;
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
            bool requestFilter_filter_StartTimeRangeIsNull = true;
            requestFilter_filter_StartTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_StartTimeRange_startTimeRange_BeginDate = null;
            if (cmdletContext.Filter_StartTimeRange_BeginDate != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_BeginDate = cmdletContext.Filter_StartTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_StartTimeRange_startTimeRange_BeginDate != null)
            {
                requestFilter_filter_StartTimeRange.BeginDate = requestFilter_filter_StartTimeRange_startTimeRange_BeginDate.Value;
                requestFilter_filter_StartTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_StartTimeRange_startTimeRange_EndDate = null;
            if (cmdletContext.Filter_StartTimeRange_EndDate != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_EndDate = cmdletContext.Filter_StartTimeRange_EndDate.Value;
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
            bool requestFilter_filter_StateChangeTimeRangeIsNull = true;
            requestFilter_filter_StateChangeTimeRange = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate = null;
            if (cmdletContext.Filter_StateChangeTimeRange_BeginDate != null)
            {
                requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate = cmdletContext.Filter_StateChangeTimeRange_BeginDate.Value;
            }
            if (requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate != null)
            {
                requestFilter_filter_StateChangeTimeRange.BeginDate = requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_BeginDate.Value;
                requestFilter_filter_StateChangeTimeRangeIsNull = false;
            }
            System.DateTime? requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate = null;
            if (cmdletContext.Filter_StateChangeTimeRange_EndDate != null)
            {
                requestFilter_filter_StateChangeTimeRange_stateChangeTimeRange_EndDate = cmdletContext.Filter_StateChangeTimeRange_EndDate.Value;
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.AssessmentRunArns;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.AssessmentRunArns.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
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
        
        private static Amazon.Inspector.Model.ListAssessmentRunsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.ListAssessmentRunsRequest request)
        {
            return client.ListAssessmentRuns(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AssessmentTemplateArns { get; set; }
            public System.DateTime? Filter_CompletionTimeRange_BeginDate { get; set; }
            public System.DateTime? Filter_CompletionTimeRange_EndDate { get; set; }
            public System.Int32? Filter_DurationRange_MaxSeconds { get; set; }
            public System.Int32? Filter_DurationRange_MinSeconds { get; set; }
            public System.String Filter_NamePattern { get; set; }
            public List<System.String> Filter_RulesPackageArns { get; set; }
            public System.DateTime? Filter_StartTimeRange_BeginDate { get; set; }
            public System.DateTime? Filter_StartTimeRange_EndDate { get; set; }
            public System.DateTime? Filter_StateChangeTimeRange_BeginDate { get; set; }
            public System.DateTime? Filter_StateChangeTimeRange_EndDate { get; set; }
            public List<System.String> Filter_States { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
