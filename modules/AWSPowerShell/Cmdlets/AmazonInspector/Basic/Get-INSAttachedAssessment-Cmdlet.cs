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
    /// Lists the assessments attached to the rules package specified by the rules package
    /// ARN.
    /// </summary>
    [Cmdlet("Get", "INSAttachedAssessment")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListAttachedAssessments operation against Amazon Inspector.", Operation = new[] {"ListAttachedAssessments"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type ListAttachedAssessmentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetINSAttachedAssessmentCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, an explicit value or a string containing a wildcard
        /// specified for this data type property must match the value of the <b>assessmentName</b>
        /// property of the <a>Assessment</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_AssessmentNamePatterns")]
        public System.String[] Filter_AssessmentNamePattern { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the value specified for this data type property must
        /// be the exact match of the value of the <b>assessmentState</b> property of the <a>Assessment</a>
        /// data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_AssessmentStates")]
        public System.String[] Filter_AssessmentState { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the value specified for this data type property must
        /// be the exact match of the value of the <b>dataCollected</b> property of the <a>Assessment</a>
        /// data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean Filter_DataCollected { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum value of the duration range. Must be less than or equal to 604800 seconds
        /// (1 week).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_DurationRange_Maximum")]
        public Int32 DurationRange_Maximum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EndTimeRange_Maximum")]
        public DateTime EndTimeRange_Maximum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StartTimeRange_Maximum")]
        public DateTime StartTimeRange_Maximum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum value of the duration range. Must be greater than zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_DurationRange_Minimum")]
        public Int32 DurationRange_Minimum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EndTimeRange_Minimum")]
        public DateTime EndTimeRange_Minimum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StartTimeRange_Minimum")]
        public DateTime StartTimeRange_Minimum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN specifying the rules package whose assessments you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String RulesPackageArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>You can use this parameter to indicate the maximum number of items you want in the
        /// response. The default value is 10. The maximum value is 500.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>You can use this parameter when paginating results. Set the value of this parameter
        /// to 'null' on your first call to the <b>ListAttachedAssessments</b> action. Subsequent
        /// calls to the action fill <b>nextToken</b> in the request with the value of <b>NextToken</b>
        /// from previous response to continue listing data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Filter_AssessmentNamePattern != null)
            {
                context.Filter_AssessmentNamePatterns = new List<String>(this.Filter_AssessmentNamePattern);
            }
            if (this.Filter_AssessmentState != null)
            {
                context.Filter_AssessmentStates = new List<String>(this.Filter_AssessmentState);
            }
            if (ParameterWasBound("Filter_DataCollected"))
                context.Filter_DataCollected = this.Filter_DataCollected;
            if (ParameterWasBound("DurationRange_Maximum"))
                context.Filter_DurationRange_Maximum = this.DurationRange_Maximum;
            if (ParameterWasBound("DurationRange_Minimum"))
                context.Filter_DurationRange_Minimum = this.DurationRange_Minimum;
            if (ParameterWasBound("EndTimeRange_Maximum"))
                context.Filter_EndTimeRange_Maximum = this.EndTimeRange_Maximum;
            if (ParameterWasBound("EndTimeRange_Minimum"))
                context.Filter_EndTimeRange_Minimum = this.EndTimeRange_Minimum;
            if (ParameterWasBound("StartTimeRange_Maximum"))
                context.Filter_StartTimeRange_Maximum = this.StartTimeRange_Maximum;
            if (ParameterWasBound("StartTimeRange_Minimum"))
                context.Filter_StartTimeRange_Minimum = this.StartTimeRange_Minimum;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.RulesPackageArn = this.RulesPackageArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new ListAttachedAssessmentsRequest();
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new AssessmentsFilter();
            List<String> requestFilter_filter_AssessmentNamePattern = null;
            if (cmdletContext.Filter_AssessmentNamePatterns != null)
            {
                requestFilter_filter_AssessmentNamePattern = cmdletContext.Filter_AssessmentNamePatterns;
            }
            if (requestFilter_filter_AssessmentNamePattern != null)
            {
                request.Filter.AssessmentNamePatterns = requestFilter_filter_AssessmentNamePattern;
                requestFilterIsNull = false;
            }
            List<String> requestFilter_filter_AssessmentState = null;
            if (cmdletContext.Filter_AssessmentStates != null)
            {
                requestFilter_filter_AssessmentState = cmdletContext.Filter_AssessmentStates;
            }
            if (requestFilter_filter_AssessmentState != null)
            {
                request.Filter.AssessmentStates = requestFilter_filter_AssessmentState;
                requestFilterIsNull = false;
            }
            Boolean? requestFilter_filter_DataCollected = null;
            if (cmdletContext.Filter_DataCollected != null)
            {
                requestFilter_filter_DataCollected = cmdletContext.Filter_DataCollected.Value;
            }
            if (requestFilter_filter_DataCollected != null)
            {
                request.Filter.DataCollected = requestFilter_filter_DataCollected.Value;
                requestFilterIsNull = false;
            }
            DurationRange requestFilter_filter_DurationRange = null;
            
             // populate DurationRange
            bool requestFilter_filter_DurationRangeIsNull = true;
            requestFilter_filter_DurationRange = new DurationRange();
            Int32? requestFilter_filter_DurationRange_durationRange_Maximum = null;
            if (cmdletContext.Filter_DurationRange_Maximum != null)
            {
                requestFilter_filter_DurationRange_durationRange_Maximum = cmdletContext.Filter_DurationRange_Maximum.Value;
            }
            if (requestFilter_filter_DurationRange_durationRange_Maximum != null)
            {
                requestFilter_filter_DurationRange.Maximum = requestFilter_filter_DurationRange_durationRange_Maximum.Value;
                requestFilter_filter_DurationRangeIsNull = false;
            }
            Int32? requestFilter_filter_DurationRange_durationRange_Minimum = null;
            if (cmdletContext.Filter_DurationRange_Minimum != null)
            {
                requestFilter_filter_DurationRange_durationRange_Minimum = cmdletContext.Filter_DurationRange_Minimum.Value;
            }
            if (requestFilter_filter_DurationRange_durationRange_Minimum != null)
            {
                requestFilter_filter_DurationRange.Minimum = requestFilter_filter_DurationRange_durationRange_Minimum.Value;
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
            TimestampRange requestFilter_filter_EndTimeRange = null;
            
             // populate EndTimeRange
            bool requestFilter_filter_EndTimeRangeIsNull = true;
            requestFilter_filter_EndTimeRange = new TimestampRange();
            DateTime? requestFilter_filter_EndTimeRange_endTimeRange_Maximum = null;
            if (cmdletContext.Filter_EndTimeRange_Maximum != null)
            {
                requestFilter_filter_EndTimeRange_endTimeRange_Maximum = cmdletContext.Filter_EndTimeRange_Maximum.Value;
            }
            if (requestFilter_filter_EndTimeRange_endTimeRange_Maximum != null)
            {
                requestFilter_filter_EndTimeRange.Maximum = requestFilter_filter_EndTimeRange_endTimeRange_Maximum.Value;
                requestFilter_filter_EndTimeRangeIsNull = false;
            }
            DateTime? requestFilter_filter_EndTimeRange_endTimeRange_Minimum = null;
            if (cmdletContext.Filter_EndTimeRange_Minimum != null)
            {
                requestFilter_filter_EndTimeRange_endTimeRange_Minimum = cmdletContext.Filter_EndTimeRange_Minimum.Value;
            }
            if (requestFilter_filter_EndTimeRange_endTimeRange_Minimum != null)
            {
                requestFilter_filter_EndTimeRange.Minimum = requestFilter_filter_EndTimeRange_endTimeRange_Minimum.Value;
                requestFilter_filter_EndTimeRangeIsNull = false;
            }
             // determine if requestFilter_filter_EndTimeRange should be set to null
            if (requestFilter_filter_EndTimeRangeIsNull)
            {
                requestFilter_filter_EndTimeRange = null;
            }
            if (requestFilter_filter_EndTimeRange != null)
            {
                request.Filter.EndTimeRange = requestFilter_filter_EndTimeRange;
                requestFilterIsNull = false;
            }
            TimestampRange requestFilter_filter_StartTimeRange = null;
            
             // populate StartTimeRange
            bool requestFilter_filter_StartTimeRangeIsNull = true;
            requestFilter_filter_StartTimeRange = new TimestampRange();
            DateTime? requestFilter_filter_StartTimeRange_startTimeRange_Maximum = null;
            if (cmdletContext.Filter_StartTimeRange_Maximum != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_Maximum = cmdletContext.Filter_StartTimeRange_Maximum.Value;
            }
            if (requestFilter_filter_StartTimeRange_startTimeRange_Maximum != null)
            {
                requestFilter_filter_StartTimeRange.Maximum = requestFilter_filter_StartTimeRange_startTimeRange_Maximum.Value;
                requestFilter_filter_StartTimeRangeIsNull = false;
            }
            DateTime? requestFilter_filter_StartTimeRange_startTimeRange_Minimum = null;
            if (cmdletContext.Filter_StartTimeRange_Minimum != null)
            {
                requestFilter_filter_StartTimeRange_startTimeRange_Minimum = cmdletContext.Filter_StartTimeRange_Minimum.Value;
            }
            if (requestFilter_filter_StartTimeRange_startTimeRange_Minimum != null)
            {
                requestFilter_filter_StartTimeRange.Minimum = requestFilter_filter_StartTimeRange_startTimeRange_Minimum.Value;
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
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.RulesPackageArn != null)
            {
                request.RulesPackageArn = cmdletContext.RulesPackageArn;
            }
            
            // Initialize loop variants and commence piping
            String _nextMarker = null;
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
                        
                        var response = client.ListAttachedAssessments(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.AssessmentArnList;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.AssessmentArnList.Count;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<String> Filter_AssessmentNamePatterns { get; set; }
            public List<String> Filter_AssessmentStates { get; set; }
            public Boolean? Filter_DataCollected { get; set; }
            public Int32? Filter_DurationRange_Maximum { get; set; }
            public Int32? Filter_DurationRange_Minimum { get; set; }
            public DateTime? Filter_EndTimeRange_Maximum { get; set; }
            public DateTime? Filter_EndTimeRange_Minimum { get; set; }
            public DateTime? Filter_StartTimeRange_Maximum { get; set; }
            public DateTime? Filter_StartTimeRange_Minimum { get; set; }
            public int? MaxResults { get; set; }
            public String NextToken { get; set; }
            public String RulesPackageArn { get; set; }
        }
        
    }
}
