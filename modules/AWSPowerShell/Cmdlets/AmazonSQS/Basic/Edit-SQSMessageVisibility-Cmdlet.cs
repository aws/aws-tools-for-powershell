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
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Changes the visibility timeout of a specified message in a queue to a new value. The
    /// maximum allowed timeout value you can set the value to is 12 hours. This means you
    /// can't extend the timeout of a message in an existing queue to more than a total visibility
    /// timeout of 12 hours. (For more information visibility timeout, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/AboutVT.html">Visibility
    /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.)
    /// 
    ///  
    /// <para>
    /// For example, let's say you have a message and its default message visibility timeout
    /// is 30 minutes. You could call <code>ChangeMessageVisiblity</code> with a value of
    /// two hours and the effective timeout would be two hours and 30 minutes. When that time
    /// comes near you could again extend the time out by calling ChangeMessageVisiblity,
    /// but this time the maximum allowed timeout would be 9 hours and 30 minutes.
    /// </para><note><para>
    /// There is a 120,000 limit for the number of inflight messages per queue. Messages are
    /// inflight after they have been received from the queue by a consuming component, but
    /// have not yet been deleted from the queue. If you reach the 120,000 limit, you will
    /// receive an OverLimit error message from Amazon SQS. To help avoid reaching the limit,
    /// you should delete the messages from the queue after they have been processed. You
    /// can also increase the number of queues you use to process the messages. 
    /// </para></note><important>If you attempt to set the <code>VisibilityTimeout</code> to an
    /// amount more than the maximum time left, Amazon SQS returns an error. It will not automatically
    /// recalculate and increase the timeout to the maximum time remaining.</important><important>Unlike
    /// with a queue, when you change the visibility timeout for a specific message, that
    /// timeout value is applied immediately but is not saved in memory for that message.
    /// If you don't delete a message after it is received, the visibility timeout for the
    /// message the next time it is received reverts to the original timeout value, not the
    /// value you set with the <code>ChangeMessageVisibility</code> action.</important>
    /// </summary>
    [Cmdlet("Edit", "SQSMessageVisibility", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ChangeMessageVisibility operation against Amazon Simple Queue Service.", Operation = new[] {"ChangeMessageVisibility"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the QueueUrl parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type ChangeMessageVisibilityResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditSQSMessageVisibilityCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to take action on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String QueueUrl { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The receipt handle associated with the message whose visibility timeout should be
        /// changed. This parameter is returned by the <a>ReceiveMessage</a> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String ReceiptHandle { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The new value (in seconds - from 0 to 43200 - maximum 12 hours) for the message's
        /// visibility timeout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Int32 VisibilityTimeout { get; set; }
        
        /// <summary>
        /// Returns the value passed to the QueueUrl parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("QueueUrl", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-SQSMessageVisibility (ChangeMessageVisibility)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.QueueUrl = this.QueueUrl;
            context.ReceiptHandle = this.ReceiptHandle;
            if (ParameterWasBound("VisibilityTimeout"))
                context.VisibilityTimeout = this.VisibilityTimeout;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ChangeMessageVisibilityRequest();
            
            if (cmdletContext.QueueUrl != null)
            {
                request.QueueUrl = cmdletContext.QueueUrl;
            }
            if (cmdletContext.ReceiptHandle != null)
            {
                request.ReceiptHandle = cmdletContext.ReceiptHandle;
            }
            if (cmdletContext.VisibilityTimeout != null)
            {
                request.VisibilityTimeout = cmdletContext.VisibilityTimeout.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ChangeMessageVisibility(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.QueueUrl;
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
            public String QueueUrl { get; set; }
            public String ReceiptHandle { get; set; }
            public Int32? VisibilityTimeout { get; set; }
        }
        
    }
}
