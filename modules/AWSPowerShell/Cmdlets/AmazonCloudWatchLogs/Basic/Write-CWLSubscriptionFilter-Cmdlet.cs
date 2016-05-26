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
    /// Creates or updates a subscription filter and associates it with the specified log
    /// group. Subscription filters allow you to subscribe to a real-time stream of log events
    /// ingested through <code class="code">PutLogEvents</code> requests and have them delivered
    /// to a specific destination. Currently, the supported destinations are: <ul><li> An
    /// Amazon Kinesis stream belonging to the same account as the subscription filter, for
    /// same-account delivery. </li><li> A logical destination (used via an ARN of <code>Destination</code>)
    /// belonging to a different account, for cross-account delivery. </li><li> An Amazon
    /// Kinesis Firehose stream belonging to the same account as the subscription filter,
    /// for same-account delivery. </li><li> An AWS Lambda function belonging to the same
    /// account as the subscription filter, for same-account delivery. </li></ul><para>
    ///  Currently there can only be one subscription filter associated with a log group.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLSubscriptionFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutSubscriptionFilter operation against Amazon CloudWatch Logs.", Operation = new[] {"PutSubscriptionFilter"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LogGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCWLSubscriptionFilterCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination to deliver matching log events to. Currently, the supported
        /// destinations are: <ul><li> An Amazon Kinesis stream belonging to the same account
        /// as the subscription filter, for same-account delivery. </li><li> A logical destination
        /// (used via an ARN of <code>Destination</code>) belonging to a different account, for
        /// cross-account delivery. </li><li> An Amazon Kinesis Firehose stream belonging to
        /// the same account as the subscription filter, for same-account delivery. </li><li>
        /// An AWS Lambda function belonging to the same account as the subscription filter, for
        /// same-account delivery. </li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter FilterName
        /// <summary>
        /// <para>
        /// <para>A name for the subscription filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String FilterName { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// <para>A valid CloudWatch Logs filter pattern for subscribing to a filtered stream of log
        /// events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group to associate the subscription filter with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that grants CloudWatch Logs permissions to deliver ingested
        /// log events to the destination stream. You don't need to provide the ARN when you are
        /// working with a logical destination (used via an ARN of <code>Destination</code>) for
        /// cross-account delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the LogGroupName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LogGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLSubscriptionFilter (PutSubscriptionFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DestinationArn = this.DestinationArn;
            context.FilterName = this.FilterName;
            context.FilterPattern = this.FilterPattern;
            context.LogGroupName = this.LogGroupName;
            context.RoleArn = this.RoleArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudWatchLogs.Model.PutSubscriptionFilterRequest();
            
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            if (cmdletContext.FilterName != null)
            {
                request.FilterName = cmdletContext.FilterName;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.LogGroupName;
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
        
        private static Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutSubscriptionFilterRequest request)
        {
            return client.PutSubscriptionFilter(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DestinationArn { get; set; }
            public System.String FilterName { get; set; }
            public System.String FilterPattern { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String RoleArn { get; set; }
        }
        
    }
}
