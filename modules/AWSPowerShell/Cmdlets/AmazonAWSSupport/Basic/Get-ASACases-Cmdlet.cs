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
    /// objects.</li></ol>
    /// </summary>
    [Cmdlet("Get", "ASACases")]
    [OutputType("Amazon.AWSSupport.Model.CaseDetails")]
    [AWSCmdlet("Invokes the DescribeCases operation against AWS Support API.", Operation = new[] {"DescribeCases"})]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.CaseDetails",
        "This cmdlet returns a collection of CaseDetails objects.",
        "The service call response (type DescribeCasesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetASACasesCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The start date for a filtered date search on support case communications. Case communications
        /// are available for 12 months after creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AfterTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The end date for a filtered date search on support case communications. Case communications
        /// are available for 12 months after creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String BeforeTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of ID numbers of the support cases you want returned. The maximum number of
        /// cases is 100. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] CaseIdList { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID displayed for a case in the AWS Support Center user interface. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String DisplayId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether communications should be included in the <a>DescribeCases</a> results.
        /// The default is <i>true</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean IncludeCommunications { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether resolved support cases should be included in the <a>DescribeCases</a>
        /// results. The default is <i>false</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean IncludeResolvedCases { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ISO 639-1 code for the language in which AWS provides support. AWS Support currently
        /// supports English ("en") and Japanese ("ja"). Language parameters must be passed explicitly
        /// for operations that take them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Language { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return before paginating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A resumption point for pagination.</para>
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
            
            context.AfterTime = this.AfterTime;
            context.BeforeTime = this.BeforeTime;
            if (this.CaseIdList != null)
            {
                context.CaseIdList = new List<String>(this.CaseIdList);
            }
            context.DisplayId = this.DisplayId;
            if (ParameterWasBound("IncludeCommunications"))
                context.IncludeCommunications = this.IncludeCommunications;
            if (ParameterWasBound("IncludeResolvedCases"))
                context.IncludeResolvedCases = this.IncludeResolvedCases;
            context.Language = this.Language;
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
            var request = new DescribeCasesRequest();
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
                        
                        var response = client.DescribeCases(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String AfterTime { get; set; }
            public String BeforeTime { get; set; }
            public List<String> CaseIdList { get; set; }
            public String DisplayId { get; set; }
            public Boolean? IncludeCommunications { get; set; }
            public Boolean? IncludeResolvedCases { get; set; }
            public String Language { get; set; }
            public int? MaxResults { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
