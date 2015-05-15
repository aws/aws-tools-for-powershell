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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns the summary information for stacks whose status matches the specified StackStatusFilter.
    /// Summary information for stacks that have been deleted is kept for 90 days after the
    /// stack is deleted. If no StackStatusFilter is specified, summary information for all
    /// stacks is returned (including existing stacks and stacks that have been deleted).
    /// </summary>
    [Cmdlet("Get", "CFNStackSummary")]
    [OutputType("Amazon.CloudFormation.Model.StackSummary")]
    [AWSCmdlet("Invokes the ListStacks operation against AWS CloudFormation.", Operation = new[] {"ListStacks"})]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.StackSummary",
        "This cmdlet returns a collection of StackSummary objects.",
        "The service call response (type ListStacksResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCFNStackSummaryCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Stack status to use as a filter. Specify one or more stack status codes to list only
        /// stacks with the specified status codes. For a complete list of stack status codes,
        /// see the <code>StackStatus</code> parameter of the <a>Stack</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String[] StackStatusFilter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>String that identifies the start of the next list of stacks, if there is one.</para><para>Default: There is no default value.</para>
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
            
            context.NextToken = this.NextToken;
            if (this.StackStatusFilter != null)
            {
                context.StackStatusFilter = new List<String>(this.StackStatusFilter);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new ListStacksRequest();
            
            if (cmdletContext.StackStatusFilter != null)
            {
                request.StackStatusFilter = cmdletContext.StackStatusFilter;
            }
            
            // Initialize loop variant and commence piping
            String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.ListStacks(request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.StackSummaries;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.StackSummaries.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (AutoIterationHelpers.HasValue(_nextMarker));
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
            public String NextToken { get; set; }
            public List<String> StackStatusFilter { get; set; }
        }
        
    }
}
