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
    /// Lists the ARNs of the applications within this AWS account. For more information about
    /// applications, see <a href="https://docs.aws.amazon.com/inspector/latest/userguide//inspector_applications.html">Inspector
    /// Applications</a>.
    /// </summary>
    [Cmdlet("Get", "INSApplicationList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListApplications operation against Amazon Inspector.", Operation = new[] {"ListApplications"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type ListApplicationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetINSApplicationListCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>For a record to match a filter, an explicit value or a string containing a wildcard
        /// specified for this data type property must match the value of the <b>applicationName</b>
        /// property of the <a>Application</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_ApplicationNamePatterns")]
        public System.String[] Filter_ApplicationNamePattern { get; set; }
        
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
        /// to 'null' on your first call to the <b>ListApplications</b> action. Subsequent calls
        /// to the action fill <b>nextToken</b> in the request with the value of <b>NextToken</b>
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
            
            if (this.Filter_ApplicationNamePattern != null)
            {
                context.Filter_ApplicationNamePatterns = new List<String>(this.Filter_ApplicationNamePattern);
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
            var request = new ListApplicationsRequest();
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new ApplicationsFilter();
            List<String> requestFilter_filter_ApplicationNamePattern = null;
            if (cmdletContext.Filter_ApplicationNamePatterns != null)
            {
                requestFilter_filter_ApplicationNamePattern = cmdletContext.Filter_ApplicationNamePatterns;
            }
            if (requestFilter_filter_ApplicationNamePattern != null)
            {
                request.Filter.ApplicationNamePatterns = requestFilter_filter_ApplicationNamePattern;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
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
                        
                        var response = client.ListApplications(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ApplicationArnList;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ApplicationArnList.Count;
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
            public List<String> Filter_ApplicationNamePatterns { get; set; }
            public int? MaxResults { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
