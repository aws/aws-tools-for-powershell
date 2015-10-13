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
    /// Retrieves log events, optionally filtered by a filter pattern from the specified
    /// log group. You can provide an optional time range to filter the results on the event
    /// <code class="code">timestamp</code>. You can limit the streams searched to an explicit
    /// list of <code class="code">logStreamNames</code>. 
    /// 
    ///  
    /// <para>
    ///  By default, this operation returns as much matching log events as can fit in a response
    /// size of 1MB, up to 10,000 log events, or all the events found within a time-bounded
    /// scan window. If the response includes a <code class="code">nextToken</code>, then
    /// there is more data to search, and the search can be resumed with a new request providing
    /// the nextToken. The response will contain a list of <code class="code">searchedLogStreams</code>
    /// that contains information about which streams were searched in the request and whether
    /// they have been searched completely or require further pagination. The <code class="code">limit</code>
    /// parameter in the request. can be used to specify the maximum number of events to return
    /// in a page. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLFilteredLogEvent")]
    [OutputType("Amazon.CloudWatchLogs.Model.FilterLogEventsResponse")]
    [AWSCmdlet("Invokes the FilterLogEvents operation against Amazon CloudWatch Logs.", Operation = new[] {"FilterLogEvents"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.FilterLogEventsResponse",
        "This cmdlet returns a Amazon.CloudWatchLogs.Model.FilterLogEventsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCWLFilteredLogEventCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A unix timestamp indicating the end time of the range for the request. If provided,
        /// events with a timestamp later than this time will not be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 EndTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A valid CloudWatch Logs filter pattern to use for filtering the response. If not
        /// provided, all the events are matched. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilterPattern { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If provided, the API will make a best effort to provide responses that contain events
        /// from multiple log streams within the log group interleaved in a single response. If
        /// not provided, all the matched log events in the first log stream will be searched
        /// first, then those in the next log stream, etc.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Interleaved { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the log group to query. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Optional list of log stream names within the specified log group to search. Defaults
        /// to all the log streams in the log group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogStreamNames")]
        public System.String[] LogStreamName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A unix timestamp indicating the start time of the range for the request. If provided,
        /// events with a timestamp prior to this time will not be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 StartTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of events to return in a page of results. Default is 10,000 events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A pagination token obtained from a <code class="code">FilterLogEvents</code> response
        /// to continue paginating the FilterLogEvents results.</para>
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
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.FilterPattern = this.FilterPattern;
            if (ParameterWasBound("Interleaved"))
                context.Interleaved = this.Interleaved;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LogGroupName = this.LogGroupName;
            if (this.LogStreamName != null)
            {
                context.LogStreamNames = new List<System.String>(this.LogStreamName);
            }
            context.NextToken = this.NextToken;
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
            var request = new Amazon.CloudWatchLogs.Model.FilterLogEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            if (cmdletContext.Interleaved != null)
            {
                request.Interleaved = cmdletContext.Interleaved.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamNames != null)
            {
                request.LogStreamNames = cmdletContext.LogStreamNames;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
                var response = client.FilterLogEvents(request);
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
            public System.Int64? EndTime { get; set; }
            public System.String FilterPattern { get; set; }
            public System.Boolean? Interleaved { get; set; }
            public int? Limit { get; set; }
            public System.String LogGroupName { get; set; }
            public List<System.String> LogStreamNames { get; set; }
            public System.String NextToken { get; set; }
            public System.Int64? StartTime { get; set; }
        }
        
    }
}
