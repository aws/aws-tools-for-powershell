/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Lists log events from the specified log group. You can list all the log events or
    /// filter the results using a filter pattern, a time range, and the name of the log stream.
    /// 
    ///  
    /// <para>
    /// By default, this operation returns as many log events as can fit in 1 MB (up to 10,000
    /// log events), or all the events found within the time range that you specify. If the
    /// results include a token, then there are more log events available, and you can get
    /// additional results by specifying the token in a subsequent call.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWLFilteredLogEvent")]
    [OutputType("Amazon.CloudWatchLogs.Model.FilterLogEventsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs FilterLogEvents API operation.", Operation = new[] {"FilterLogEvents"})]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.FilterLogEventsResponse",
        "This cmdlet returns a Amazon.CloudWatchLogs.Model.FilterLogEventsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWLFilteredLogEventCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range, expressed as the number of milliseconds after Jan 1, 1970
        /// 00:00:00 UTC. Events with a timestamp later than this time are not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 EndTime { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// <para>The filter pattern to use. For more information, see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html">Filter
        /// and Pattern Syntax</a>.</para><para>If not provided, all the events are matched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter Interleaved
        /// <summary>
        /// <para>
        /// <para>If the value is true, the operation makes a best effort to provide responses that
        /// contain events from multiple log streams within the log group, interleaved in a single
        /// response. If the value is false, all the matched log events in the first log stream
        /// are searched first, then those in the next log stream, and so on. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Interleaved { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group to search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>Filters the results to include only events from log streams that have names starting
        /// with this prefix.</para><para>If you specify a value for both <code>logStreamNamePrefix</code> and <code>logStreamNames</code>,
        /// but the value for <code>logStreamNamePrefix</code> does not match any log stream names
        /// specified in <code>logStreamNames</code>, the action returns an <code>InvalidParameterException</code>
        /// error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>Filters the results to only logs from the log streams in this list.</para><para>If you specify a value for both <code>logStreamNamePrefix</code> and <code>logStreamNames</code>,
        /// the action returns an <code>InvalidParameterException</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogStreamNames")]
        public System.String[] LogStreamName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time range, expressed as the number of milliseconds after Jan 1,
        /// 1970 00:00:00 UTC. Events with a timestamp before this time are not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 StartTime { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of events to return. The default is 10,000 events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of events to return. (You received this token from a previous
        /// call.)</para>
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
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.FilterPattern = this.FilterPattern;
            if (ParameterWasBound("Interleaved"))
                context.Interleaved = this.Interleaved;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.LogGroupName = this.LogGroupName;
            context.LogStreamNamePrefix = this.LogStreamNamePrefix;
            if (this.LogStreamName != null)
            {
                context.LogStreamNames = new List<System.String>(this.LogStreamName);
            }
            context.NextToken = this.NextToken;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
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
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamNamePrefix != null)
            {
                request.LogStreamNamePrefix = cmdletContext.LogStreamNamePrefix;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatchLogs.Model.FilterLogEventsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.FilterLogEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "FilterLogEvents");
            try
            {
                #if DESKTOP
                return client.FilterLogEvents(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.FilterLogEventsAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Int64? EndTime { get; set; }
            public System.String FilterPattern { get; set; }
            public System.Boolean? Interleaved { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamNamePrefix { get; set; }
            public List<System.String> LogStreamNames { get; set; }
            public System.String NextToken { get; set; }
            public System.Int64? StartTime { get; set; }
        }
        
    }
}
