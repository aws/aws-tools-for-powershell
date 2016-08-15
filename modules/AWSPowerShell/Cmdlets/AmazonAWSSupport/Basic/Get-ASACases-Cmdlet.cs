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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns a list of cases that you specify by passing one or more case IDs. In addition,
    /// you can filter the cases by date by setting values for the <code>AfterTime</code>
    /// and <code>BeforeTime</code> request parameters. You can set values for the <code>IncludeResolvedCases</code>
    /// and <code>IncludeCommunications</code> request parameters to control how much information
    /// is returned. 
    /// 
    ///  
    /// <para>
    /// Case data is available for 12 months after creation. If a case was created more than
    /// 12 months ago, a request for data might cause an error. 
    /// </para><para>
    /// The response returns the following in JSON format:
    /// </para><ol><li>One or more <a>CaseDetails</a> data types. </li><li>One or more <code>NextToken</code>
    /// values, which specify where to paginate the returned records represented by the <code>CaseDetails</code>
    /// objects.</li></ol><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "ASACases")]
    [OutputType("Amazon.AWSSupport.Model.CaseDetails")]
    [AWSCmdlet("Invokes the DescribeCases operation against AWS Support API.", Operation = new[] {"DescribeCases"})]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.CaseDetails",
        "This cmdlet returns a collection of CaseDetails objects.",
        "The service call response (type Amazon.AWSSupport.Model.DescribeCasesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetASACasesCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        #region Parameter AfterTime
        /// <summary>
        /// <para>
        /// <para>The start date for a filtered date search on support case communications. Case communications
        /// are available for 12 months after creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AfterTime { get; set; }
        #endregion
        
        #region Parameter BeforeTime
        /// <summary>
        /// <para>
        /// <para>The end date for a filtered date search on support case communications. Case communications
        /// are available for 12 months after creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BeforeTime { get; set; }
        #endregion
        
        #region Parameter CaseIdList
        /// <summary>
        /// <para>
        /// <para>A list of ID numbers of the support cases you want returned. The maximum number of
        /// cases is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] CaseIdList { get; set; }
        #endregion
        
        #region Parameter DisplayId
        /// <summary>
        /// <para>
        /// <para>The ID displayed for a case in the AWS Support Center user interface. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayId { get; set; }
        #endregion
        
        #region Parameter IncludeCommunication
        /// <summary>
        /// <para>
        /// <para>Specifies whether communications should be included in the <a>DescribeCases</a> results.
        /// The default is <i>true</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeCommunications")]
        public System.Boolean IncludeCommunication { get; set; }
        #endregion
        
        #region Parameter IncludeResolvedCase
        /// <summary>
        /// <para>
        /// <para>Specifies whether resolved support cases should be included in the <a>DescribeCases</a>
        /// results. The default is <i>false</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeResolvedCases")]
        public System.Boolean IncludeResolvedCase { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The ISO 639-1 code for the language in which AWS provides support. AWS Support currently
        /// supports English ("en") and Japanese ("ja"). Language parameters must be passed explicitly
        /// for operations that take them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return before paginating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A resumption point for pagination.</para>
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
            
            context.AfterTime = this.AfterTime;
            context.BeforeTime = this.BeforeTime;
            if (this.CaseIdList != null)
            {
                context.CaseIdList = new List<System.String>(this.CaseIdList);
            }
            context.DisplayId = this.DisplayId;
            if (ParameterWasBound("IncludeCommunication"))
                context.IncludeCommunications = this.IncludeCommunication;
            if (ParameterWasBound("IncludeResolvedCase"))
                context.IncludeResolvedCases = this.IncludeResolvedCase;
            context.Language = this.Language;
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
            var request = new Amazon.AWSSupport.Model.DescribeCasesRequest();
            if (cmdletContext.AfterTime != null)
            {
                request.AfterTime = cmdletContext.AfterTime;
            }
            if (cmdletContext.BeforeTime != null)
            {
                request.BeforeTime = cmdletContext.BeforeTime;
            }
            if (cmdletContext.CaseIdList != null)
            {
                request.CaseIdList = cmdletContext.CaseIdList;
            }
            if (cmdletContext.DisplayId != null)
            {
                request.DisplayId = cmdletContext.DisplayId;
            }
            if (cmdletContext.IncludeCommunications != null)
            {
                request.IncludeCommunications = cmdletContext.IncludeCommunications.Value;
            }
            if (cmdletContext.IncludeResolvedCases != null)
            {
                request.IncludeResolvedCases = cmdletContext.IncludeResolvedCases.Value;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
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
                        object pipelineOutput = response.Cases;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Cases.Count;
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
        
        private static Amazon.AWSSupport.Model.DescribeCasesResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.DescribeCasesRequest request)
        {
            #if DESKTOP
            return client.DescribeCases(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeCasesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AfterTime { get; set; }
            public System.String BeforeTime { get; set; }
            public List<System.String> CaseIdList { get; set; }
            public System.String DisplayId { get; set; }
            public System.Boolean? IncludeCommunications { get; set; }
            public System.Boolean? IncludeResolvedCases { get; set; }
            public System.String Language { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
