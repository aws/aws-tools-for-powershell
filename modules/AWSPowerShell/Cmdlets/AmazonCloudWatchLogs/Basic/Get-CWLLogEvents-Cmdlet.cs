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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Retrieves log events from the specified log stream. You can provide an optional time
    /// range to filter the results on the event <code class="code">timestamp</code>. 
    /// 
    ///  
    /// <para>
    ///  By default, this operation returns as much log events as can fit in a response size
    /// of 1MB, up to 10,000 log events. The response will always include a <code class="code">nextForwardToken</code>
    /// and a <code class="code">nextBackwardToken</code> in the response body. You can use
    /// any of these tokens in subsequent <code class="code">GetLogEvents</code> requests
    /// to paginate through events in either forward or backward direction. You can also limit
    /// the number of log events returned in the response by specifying the <code class="code">limit</code>
    /// parameter in the request. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLLogEvents")]
    [OutputType("Amazon.CloudWatchLogs.Model.GetLogEventsResponse")]
    [AWSCmdlet("Invokes the GetLogEvents operation against Amazon CloudWatch Logs.", Operation = new[] {"GetLogEvents"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.GetLogEventsResponse",
        "This cmdlet returns a GetLogEventsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCWLLogEventsCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the log group to query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String LogGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the log stream to query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String LogStreamName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If set to true, the earliest log events would be returned first. The default is false
        /// (the latest log events are returned first).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean StartFromHead { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum number of log events returned in the response. If you don't specify a
        /// value, the request would return as many log events as can fit in a response size of
        /// 1MB, up to 10,000 log events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Limit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A string token used for pagination that points to the next page of results. It must
        /// be a value obtained from the <code class="code">nextForwardToken</code> or <code class="code">nextBackwardToken</code>
        /// fields in the response of the previous <code class="code">GetLogEvents</code> request.
        /// </para>
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
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LogGroupName = this.LogGroupName;
            context.LogStreamName = this.LogStreamName;
            context.NextToken = this.NextToken;
            if (ParameterWasBound("StartFromHead"))
                context.StartFromHead = this.StartFromHead;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetLogEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamName = cmdletContext.LogStreamName;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartFromHead != null)
            {
                request.StartFromHead = cmdletContext.StartFromHead.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetLogEvents(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public DateTime? EndTime { get; set; }
            public Int32? Limit { get; set; }
            public String LogGroupName { get; set; }
            public String LogStreamName { get; set; }
            public String NextToken { get; set; }
            public Boolean? StartFromHead { get; set; }
            public DateTime? StartTime { get; set; }
        }
        
    }
}
