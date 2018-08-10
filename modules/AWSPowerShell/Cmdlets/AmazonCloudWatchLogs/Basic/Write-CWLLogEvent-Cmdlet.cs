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
    /// Uploads a batch of log events to the specified log stream.
    /// 
    ///  
    /// <para>
    /// You must include the sequence token obtained from the response of the previous call.
    /// An upload in a newly created log stream does not require a sequence token. You can
    /// also get the sequence token using <a>DescribeLogStreams</a>. If you call <code>PutLogEvents</code>
    /// twice within a narrow time period using the same value for <code>sequenceToken</code>,
    /// both calls may be successful, or one may be rejected.
    /// </para><para>
    /// The batch of events must satisfy the following constraints:
    /// </para><ul><li><para>
    /// The maximum batch size is 1,048,576 bytes, and this size is calculated as the sum
    /// of all event messages in UTF-8, plus 26 bytes for each log event.
    /// </para></li><li><para>
    /// None of the log events in the batch can be more than 2 hours in the future.
    /// </para></li><li><para>
    /// None of the log events in the batch can be older than 14 days or the retention period
    /// of the log group.
    /// </para></li><li><para>
    /// The log events in the batch must be in chronological ordered by their time stamp.
    /// The time stamp is the time the event occurred, expressed as the number of milliseconds
    /// after Jan 1, 1970 00:00:00 UTC. (In AWS Tools for PowerShell and the AWS SDK for .NET,
    /// the timestamp is specified in .NET format: yyyy-mm-ddThh:mm:ss. For example, 2017-09-15T13:45:30.)
    /// 
    /// </para></li><li><para>
    /// The maximum number of log events in a batch is 10,000.
    /// </para></li><li><para>
    /// A batch of log events in a single request cannot span more than 24 hours. Otherwise,
    /// the operation fails.
    /// </para></li></ul><para>
    /// If a call to PutLogEvents returns "UnrecognizedClientException" the most likely cause
    /// is an invalid AWS access key ID or secret key. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLLogEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutLogEvents API operation.", Operation = new[] {"PutLogEvents"}, LegacyAlias="Write-CWLLogEvents")]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutLogEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: RejectedLogEventsInfo (type Amazon.CloudWatchLogs.Model.RejectedLogEventsInfo)"
    )]
    public partial class WriteCWLLogEventCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter LogEvent
        /// <summary>
        /// <para>
        /// <para>The log events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LogEvents")]
        public Amazon.CloudWatchLogs.Model.InputLogEvent[] LogEvent { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the log stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String LogStreamName { get; set; }
        #endregion
        
        #region Parameter SequenceToken
        /// <summary>
        /// <para>
        /// <para>The sequence token obtained from the response of the previous <code>PutLogEvents</code>
        /// call. An upload in a newly created log stream does not require a sequence token. You
        /// can also get the sequence token using <a>DescribeLogStreams</a>. If you call <code>PutLogEvents</code>
        /// twice within a narrow time period using the same value for <code>sequenceToken</code>,
        /// both calls may be successful, or one may be rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SequenceToken { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LogStreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLLogEvent (PutLogEvents)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.LogEvent != null)
            {
                context.LogEvents = new List<Amazon.CloudWatchLogs.Model.InputLogEvent>(this.LogEvent);
            }
            context.LogGroupName = this.LogGroupName;
            context.LogStreamName = this.LogStreamName;
            context.SequenceToken = this.SequenceToken;
            
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
            var request = new Amazon.CloudWatchLogs.Model.PutLogEventsRequest();
            
            if (cmdletContext.LogEvents != null)
            {
                request.LogEvents = cmdletContext.LogEvents;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamName = cmdletContext.LogStreamName;
            }
            if (cmdletContext.SequenceToken != null)
            {
                request.SequenceToken = cmdletContext.SequenceToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NextSequenceToken;
                notes = new Dictionary<string, object>();
                notes["RejectedLogEventsInfo"] = response.RejectedLogEventsInfo;
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
        
        private Amazon.CloudWatchLogs.Model.PutLogEventsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutLogEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutLogEvents");
            try
            {
                #if DESKTOP
                return client.PutLogEvents(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutLogEventsAsync(request);
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
            public List<Amazon.CloudWatchLogs.Model.InputLogEvent> LogEvents { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamName { get; set; }
            public System.String SequenceToken { get; set; }
        }
        
    }
}
