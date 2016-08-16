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
    /// Lists the assessment templates that correspond to the assessment targets that are
    /// specified by the ARNs of the assessment targets.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentTemplateList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListAssessmentTemplates operation against Amazon Inspector.", Operation = new[] {"ListAssessmentTemplates"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.Inspector.Model.ListAssessmentTemplatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetINSAssessmentTemplateListCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter AssessmentTargetArn
        /// <summary>
        /// <para>
        /// <para>A list of ARNs that specifies the assessment targets whose assessment templates you
        /// want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssessmentTargetArns")]
        public System.String[] AssessmentTargetArn { get; set; }
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
        /// <para>For a record to match a filter, an explicit value or a string that contains a wildcard
        /// that is specified for this data type property must match the value of the <b>assessmentTemplateName</b>
        /// property of the <a>AssessmentTemplate</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filter_NamePattern { get; set; }
        #endregion
        
        #region Parameter Filter_RulesPackageArn
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, the values that are specified for this data type property
        /// must be contained in the list of values of the <b>rulesPackageArns</b> property of
        /// the <a>AssessmentTemplate</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_RulesPackageArns")]
        public System.String[] Filter_RulesPackageArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>You can use this parameter to indicate the maximum number of items you want in the
        /// response. The default value is 10. The maximum value is 500.</para>
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
        /// to null on your first call to the <b>ListAssessmentTemplates</b> action. Subsequent
        /// calls to the action fill <b>nextToken</b> in the request with the value of <b>NextToken</b>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AssessmentTargetArn != null)
            {
                context.AssessmentTargetArns = new List<System.String>(this.AssessmentTargetArn);
            }
            if (ParameterWasBound("DurationRange_MaxSecond"))
                context.Filter_DurationRange_MaxSeconds = this.DurationRange_MaxSecond;
            if (ParameterWasBound("DurationRange_MinSecond"))
                context.Filter_DurationRange_MinSeconds = this.DurationRange_MinSecond;
            context.Filter_NamePattern = this.Filter_NamePattern;
            if (this.Filter_RulesPackageArn != null)
            {
                context.Filter_RulesPackageArns = new List<System.String>(this.Filter_RulesPackageArn);
            }
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Inspector.Model.ListAssessmentTemplatesRequest();
            if (cmdletContext.AssessmentTargetArns != null)
            {
                request.AssessmentTargetArns = cmdletContext.AssessmentTargetArns;
            }
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.Inspector.Model.AssessmentTemplateFilter();
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
                        object pipelineOutput = response.AssessmentTemplateArns;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.AssessmentTemplateArns.Count;
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
        
        private static Amazon.Inspector.Model.ListAssessmentTemplatesResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.ListAssessmentTemplatesRequest request)
        {
            #if DESKTOP
            return client.ListAssessmentTemplates(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListAssessmentTemplatesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AssessmentTargetArns { get; set; }
            public System.Int32? Filter_DurationRange_MaxSeconds { get; set; }
            public System.Int32? Filter_DurationRange_MinSeconds { get; set; }
            public System.String Filter_NamePattern { get; set; }
            public List<System.String> Filter_RulesPackageArns { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
