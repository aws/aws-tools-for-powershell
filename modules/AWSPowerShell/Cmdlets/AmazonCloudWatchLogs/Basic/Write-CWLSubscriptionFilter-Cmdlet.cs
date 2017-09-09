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
    /// ingested through <a>PutLogEvents</a> and have them delivered to a specific destination.
    /// Currently, the supported destinations are:
    /// 
    ///  <ul><li><para>
    /// An Amazon Kinesis stream belonging to the same account as the subscription filter,
    /// for same-account delivery.
    /// </para></li><li><para>
    /// A logical destination that belongs to a different account, for cross-account delivery.
    /// </para></li><li><para>
    /// An Amazon Kinesis Firehose delivery stream that belongs to the same account as the
    /// subscription filter, for same-account delivery.
    /// </para></li><li><para>
    /// An AWS Lambda function that belongs to the same account as the subscription filter,
    /// for same-account delivery.
    /// </para></li></ul><para>
    /// There can only be one subscription filter associated with a log group. If you are
    /// updating an existing filter, you must specify the correct name in <code>filterName</code>.
    /// Otherwise, the call fails because you cannot associate a second filter with a log
    /// group.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLSubscriptionFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutSubscriptionFilter operation against Amazon CloudWatch Logs.", Operation = new[] {"PutSubscriptionFilter"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the LogGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWLSubscriptionFilterCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination to deliver matching log events to. Currently, the supported
        /// destinations are:</para><ul><li><para>An Amazon Kinesis stream belonging to the same account as the subscription filter,
        /// for same-account delivery.</para></li><li><para>A logical destination (specified using an ARN) belonging to a different account, for
        /// cross-account delivery.</para></li><li><para>An Amazon Kinesis Firehose delivery stream belonging to the same account as the subscription
        /// filter, for same-account delivery.</para></li><li><para>An AWS Lambda function belonging to the same account as the subscription filter, for
        /// same-account delivery.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter Distribution
        /// <summary>
        /// <para>
        /// <para>The method used to distribute log data to the destination, when the destination is
        /// an Amazon Kinesis stream. By default, log data is grouped by log stream. For a more
        /// even distribution, you can group log data randomly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.Distribution")]
        public Amazon.CloudWatchLogs.Distribution Distribution { get; set; }
        #endregion
        
        #region Parameter FilterName
        /// <summary>
        /// <para>
        /// <para>A name for the subscription filter. If you are updating an existing filter, you must
        /// specify the correct name in <code>filterName</code>. Otherwise, the call fails because
        /// you cannot associate a second filter with a log group. To find the name of the filter
        /// currently associated with a log group, use <a>DescribeSubscriptionFilters</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String FilterName { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// <para>A filter pattern for subscribing to a filtered stream of log events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para>
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
        /// working with a logical destination for cross-account delivery.</para>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DestinationArn = this.DestinationArn;
            context.Distribution = this.Distribution;
            context.FilterName = this.FilterName;
            context.FilterPattern = this.FilterPattern;
            context.LogGroupName = this.LogGroupName;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.CloudWatchLogs.Model.PutSubscriptionFilterRequest();
            
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            if (cmdletContext.Distribution != null)
            {
                request.Distribution = cmdletContext.Distribution;
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
        
        private Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutSubscriptionFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutSubscriptionFilter");
            try
            {
                #if DESKTOP
                return client.PutSubscriptionFilter(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutSubscriptionFilterAsync(request);
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
            public System.String DestinationArn { get; set; }
            public Amazon.CloudWatchLogs.Distribution Distribution { get; set; }
            public System.String FilterName { get; set; }
            public System.String FilterPattern { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String RoleArn { get; set; }
        }
        
    }
}
