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
    /// Lists the assessment runs associated with the assessments specified by the assessment
    /// ARNs.
    /// </summary>
    [Cmdlet("Get", "INSRunList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListRuns operation against Amazon Inspector.", Operation = new[] {"ListRuns"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.Inspector.Model.ListRunsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetINSRunListCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ARNs specifying the assessments whose runs you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("AssessmentArns")]
        public System.String[] AssessmentArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_CompletionTime_Maximum")]
        public System.DateTime CompletionTime_Maximum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_CreationTime_Maximum")]
        public System.DateTime CreationTime_Maximum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_CompletionTime_Minimum")]
        public System.DateTime CompletionTime_Minimum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum value of the timestamp range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_CreationTime_Minimum")]
        public System.DateTime CreationTime_Minimum { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the value specified for this data type property must
        /// match a list of values of the <b>rulesPackages</b> property of the <a>Run</a> data
        /// type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_RulesPackages")]
        public System.String[] Filter_RulesPackage { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, an explicit value or a string containing a wildcard
        /// specified for this data type property must match the value of the <b>runName</b> property
        /// of the <a>Run</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_RunNamePatterns")]
        public System.String[] Filter_RunNamePattern { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the value specified for this data type property must
        /// be the exact match of the value of the <b>runState</b> property of the <a>Run</a>
        /// data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_RunStates")]
        public System.String[] Filter_RunState { get; set; }
        
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
        /// to 'null' on your first call to the <b>ListRuns</b> action. Subsequent calls to the
        /// action fill <b>nextToken</b> in the request with the value of <b>NextToken</b> from
        /// previous response to continue listing data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AssessmentArn != null)
            {
                context.AssessmentArns = new List<System.String>(this.AssessmentArn);
            }
            if (ParameterWasBound("CompletionTime_Maximum"))
                context.Filter_CompletionTime_Maximum = this.CompletionTime_Maximum;
            if (ParameterWasBound("CompletionTime_Minimum"))
                context.Filter_CompletionTime_Minimum = this.CompletionTime_Minimum;
            if (ParameterWasBound("CreationTime_Maximum"))
                context.Filter_CreationTime_Maximum = this.CreationTime_Maximum;
            if (ParameterWasBound("CreationTime_Minimum"))
                context.Filter_CreationTime_Minimum = this.CreationTime_Minimum;
            if (this.Filter_RulesPackage != null)
            {
                context.Filter_RulesPackages = new List<System.String>(this.Filter_RulesPackage);
            }
            if (this.Filter_RunNamePattern != null)
            {
                context.Filter_RunNamePatterns = new List<System.String>(this.Filter_RunNamePattern);
            }
            if (this.Filter_RunState != null)
            {
                context.Filter_RunStates = new List<System.String>(this.Filter_RunState);
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
            var request = new Amazon.Inspector.Model.ListRunsRequest();
            if (cmdletContext.AssessmentArns != null)
            {
                request.AssessmentArns = cmdletContext.AssessmentArns;
            }
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.Inspector.Model.RunsFilter();
            List<System.String> requestFilter_filter_RulesPackage = null;
            if (cmdletContext.Filter_RulesPackages != null)
            {
                requestFilter_filter_RulesPackage = cmdletContext.Filter_RulesPackages;
            }
            if (requestFilter_filter_RulesPackage != null)
            {
                request.Filter.RulesPackages = requestFilter_filter_RulesPackage;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RunNamePattern = null;
            if (cmdletContext.Filter_RunNamePatterns != null)
            {
                requestFilter_filter_RunNamePattern = cmdletContext.Filter_RunNamePatterns;
            }
            if (requestFilter_filter_RunNamePattern != null)
            {
                request.Filter.RunNamePatterns = requestFilter_filter_RunNamePattern;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_RunState = null;
            if (cmdletContext.Filter_RunStates != null)
            {
                requestFilter_filter_RunState = cmdletContext.Filter_RunStates;
            }
            if (requestFilter_filter_RunState != null)
            {
                request.Filter.RunStates = requestFilter_filter_RunState;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_CompletionTime = null;
            
             // populate CompletionTime
            bool requestFilter_filter_CompletionTimeIsNull = true;
            requestFilter_filter_CompletionTime = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_CompletionTime_completionTime_Maximum = null;
            if (cmdletContext.Filter_CompletionTime_Maximum != null)
            {
                requestFilter_filter_CompletionTime_completionTime_Maximum = cmdletContext.Filter_CompletionTime_Maximum.Value;
            }
            if (requestFilter_filter_CompletionTime_completionTime_Maximum != null)
            {
                requestFilter_filter_CompletionTime.Maximum = requestFilter_filter_CompletionTime_completionTime_Maximum.Value;
                requestFilter_filter_CompletionTimeIsNull = false;
            }
            System.DateTime? requestFilter_filter_CompletionTime_completionTime_Minimum = null;
            if (cmdletContext.Filter_CompletionTime_Minimum != null)
            {
                requestFilter_filter_CompletionTime_completionTime_Minimum = cmdletContext.Filter_CompletionTime_Minimum.Value;
            }
            if (requestFilter_filter_CompletionTime_completionTime_Minimum != null)
            {
                requestFilter_filter_CompletionTime.Minimum = requestFilter_filter_CompletionTime_completionTime_Minimum.Value;
                requestFilter_filter_CompletionTimeIsNull = false;
            }
             // determine if requestFilter_filter_CompletionTime should be set to null
            if (requestFilter_filter_CompletionTimeIsNull)
            {
                requestFilter_filter_CompletionTime = null;
            }
            if (requestFilter_filter_CompletionTime != null)
            {
                request.Filter.CompletionTime = requestFilter_filter_CompletionTime;
                requestFilterIsNull = false;
            }
            Amazon.Inspector.Model.TimestampRange requestFilter_filter_CreationTime = null;
            
             // populate CreationTime
            bool requestFilter_filter_CreationTimeIsNull = true;
            requestFilter_filter_CreationTime = new Amazon.Inspector.Model.TimestampRange();
            System.DateTime? requestFilter_filter_CreationTime_creationTime_Maximum = null;
            if (cmdletContext.Filter_CreationTime_Maximum != null)
            {
                requestFilter_filter_CreationTime_creationTime_Maximum = cmdletContext.Filter_CreationTime_Maximum.Value;
            }
            if (requestFilter_filter_CreationTime_creationTime_Maximum != null)
            {
                requestFilter_filter_CreationTime.Maximum = requestFilter_filter_CreationTime_creationTime_Maximum.Value;
                requestFilter_filter_CreationTimeIsNull = false;
            }
            System.DateTime? requestFilter_filter_CreationTime_creationTime_Minimum = null;
            if (cmdletContext.Filter_CreationTime_Minimum != null)
            {
                requestFilter_filter_CreationTime_creationTime_Minimum = cmdletContext.Filter_CreationTime_Minimum.Value;
            }
            if (requestFilter_filter_CreationTime_creationTime_Minimum != null)
            {
                requestFilter_filter_CreationTime.Minimum = requestFilter_filter_CreationTime_creationTime_Minimum.Value;
                requestFilter_filter_CreationTimeIsNull = false;
            }
             // determine if requestFilter_filter_CreationTime should be set to null
            if (requestFilter_filter_CreationTimeIsNull)
            {
                requestFilter_filter_CreationTime = null;
            }
            if (requestFilter_filter_CreationTime != null)
            {
                request.Filter.CreationTime = requestFilter_filter_CreationTime;
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
                        
                        var response = client.ListRuns(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.RunArnList;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.RunArnList.Count;
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
            public List<System.String> AssessmentArns { get; set; }
            public System.DateTime? Filter_CompletionTime_Maximum { get; set; }
            public System.DateTime? Filter_CompletionTime_Minimum { get; set; }
            public System.DateTime? Filter_CreationTime_Maximum { get; set; }
            public System.DateTime? Filter_CreationTime_Minimum { get; set; }
            public List<System.String> Filter_RulesPackages { get; set; }
            public List<System.String> Filter_RunNamePatterns { get; set; }
            public List<System.String> Filter_RunStates { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
