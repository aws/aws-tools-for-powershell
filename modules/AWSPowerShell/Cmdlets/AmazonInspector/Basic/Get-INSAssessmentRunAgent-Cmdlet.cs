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
    /// Lists the agents of the assessment runs that are specified by the ARNs of the assessment
    /// runs.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "INSAssessmentRunAgent")]
    [OutputType("Amazon.Inspector.Model.AssessmentRunAgent")]
    [AWSCmdlet("Invokes the ListAssessmentRunAgents operation against Amazon Inspector.", Operation = new[] {"ListAssessmentRunAgents"})]
    [AWSCmdletOutput("Amazon.Inspector.Model.AssessmentRunAgent",
        "This cmdlet returns a collection of AssessmentRunAgent objects.",
        "The service call response (type Amazon.Inspector.Model.ListAssessmentRunAgentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetINSAssessmentRunAgentCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        #region Parameter Filter_AgentHealthCode
        /// <summary>
        /// <para>
        /// <para>The detailed health state of the agent. Values can be set to <b>IDLE</b>, <b>RUNNING</b>,
        /// <b>SHUTDOWN</b>, <b>UNHEALTHY</b>, <b>THROTTLED</b>, and <b>UNKNOWN</b>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_AgentHealthCodes")]
        public System.String[] Filter_AgentHealthCode { get; set; }
        #endregion
        
        #region Parameter Filter_AgentHealth
        /// <summary>
        /// <para>
        /// <para>The current health state of the agent. Values can be set to <b>HEALTHY</b> or <b>UNHEALTHY</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_AgentHealths")]
        public System.String[] Filter_AgentHealth { get; set; }
        #endregion
        
        #region Parameter AssessmentRunArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the assessment run whose agents you want to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AssessmentRunArn { get; set; }
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
        /// to null on your first call to the <b>ListAssessmentRunAgents</b> action. Subsequent
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
            
            context.AssessmentRunArn = this.AssessmentRunArn;
            if (this.Filter_AgentHealthCode != null)
            {
                context.Filter_AgentHealthCodes = new List<System.String>(this.Filter_AgentHealthCode);
            }
            if (this.Filter_AgentHealth != null)
            {
                context.Filter_AgentHealths = new List<System.String>(this.Filter_AgentHealth);
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
            var request = new Amazon.Inspector.Model.ListAssessmentRunAgentsRequest();
            if (cmdletContext.AssessmentRunArn != null)
            {
                request.AssessmentRunArn = cmdletContext.AssessmentRunArn;
            }
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.Inspector.Model.AgentFilter();
            List<System.String> requestFilter_filter_AgentHealthCode = null;
            if (cmdletContext.Filter_AgentHealthCodes != null)
            {
                requestFilter_filter_AgentHealthCode = cmdletContext.Filter_AgentHealthCodes;
            }
            if (requestFilter_filter_AgentHealthCode != null)
            {
                request.Filter.AgentHealthCodes = requestFilter_filter_AgentHealthCode;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_AgentHealth = null;
            if (cmdletContext.Filter_AgentHealths != null)
            {
                requestFilter_filter_AgentHealth = cmdletContext.Filter_AgentHealths;
            }
            if (requestFilter_filter_AgentHealth != null)
            {
                request.Filter.AgentHealths = requestFilter_filter_AgentHealth;
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
                        object pipelineOutput = response.AssessmentRunAgents;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.AssessmentRunAgents.Count;
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
        
        private static Amazon.Inspector.Model.ListAssessmentRunAgentsResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.ListAssessmentRunAgentsRequest request)
        {
            #if DESKTOP
            return client.ListAssessmentRunAgents(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListAssessmentRunAgentsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AssessmentRunArn { get; set; }
            public List<System.String> Filter_AgentHealthCodes { get; set; }
            public List<System.String> Filter_AgentHealths { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
