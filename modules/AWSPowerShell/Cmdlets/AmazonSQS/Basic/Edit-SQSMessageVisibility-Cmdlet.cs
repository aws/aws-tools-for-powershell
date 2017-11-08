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
    /// maximum allowed timeout value is 12 hours. Thus, you can't extend the timeout of a
    /// message in an existing queue to more than a total visibility timeout of 12 hours.
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
    /// Timeout</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// For example, you have a message with a visibility timeout of 5 minutes. After 3 minutes,
    /// you call <code>ChangeMessageVisiblity</code> with a timeout of 10 minutes. At that
    /// time, the timeout for the message is extended by 10 minutes beyond the time of the
    /// <code>ChangeMessageVisibility</code> action. This results in a total visibility timeout
    /// of 13 minutes. You can continue to call the <code>ChangeMessageVisibility</code> to
    /// extend the visibility timeout to a maximum of 12 hours. If you try to extend the visibility
    /// timeout beyond 12 hours, your request is rejected.
    /// </para><para>
    /// A message is considered to be <i>in flight</i> after it's received from a queue by
    /// a consumer, but not yet deleted from the queue.
    /// </para><para>
    /// For standard queues, there can be a maximum of 120,000 inflight messages per queue.
    /// If you reach this limit, Amazon SQS returns the <code>OverLimit</code> error message.
    /// To avoid reaching the limit, you should delete messages from the queue after they're
    /// processed. You can also increase the number of queues you use to process your messages.
    /// </para><para>
    /// For FIFO queues, there can be a maximum of 20,000 inflight messages per queue. If
    /// you reach this limit, Amazon SQS returns no error messages.
    /// </para><important><para>
    /// If you attempt to set the <code>VisibilityTimeout</code> to a value greater than the
    /// maximum time left, Amazon SQS returns an error. Amazon SQS doesn't automatically recalculate
    /// and increase the timeout to the maximum remaining time.
    /// </para><para>
    /// Unlike with a queue, when you change the visibility timeout for a specific message
    /// the timeout value is applied immediately but isn't saved in memory for that message.
    /// If you don't delete a message after it is received, the visibility timeout for the
    /// message reverts to the original timeout value (not to the value you set using the
    /// <code>ChangeMessageVisibility</code> action) the next time the message is received.
    /// </para></important>
    /// </summary>
    [Cmdlet("Edit", "SQSMessageVisibility", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service ChangeMessageVisibility API operation.", Operation = new[] {"ChangeMessageVisibility"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the QueueUrl parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SQS.Model.ChangeMessageVisibilityResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditSQSMessageVisibilityCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue whose message's visibility is changed.</para><para>Queue URLs are case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueUrl { get; set; }
        #endregion
        
        #region Parameter ReceiptHandle
        /// <summary>
        /// <para>
        /// <para>The receipt handle associated with the message whose visibility timeout is changed.
        /// This parameter is returned by the <code><a>ReceiveMessage</a></code> action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ReceiptHandle { get; set; }
        #endregion
        
        #region Parameter VisibilityTimeout
        /// <summary>
        /// <para>
        /// <para>The new value for the message's visibility timeout (in seconds). Values values: <code>0</code>
        /// to <code>43200</code>. Maximum: 12 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Int32 VisibilityTimeout { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the QueueUrl parameter.
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.QueueUrl = this.QueueUrl;
            context.ReceiptHandle = this.ReceiptHandle;
            if (ParameterWasBound("VisibilityTimeout"))
                context.VisibilityTimeout = this.VisibilityTimeout;
            
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
            var request = new Amazon.SQS.Model.ChangeMessageVisibilityRequest();
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.SQS.Model.ChangeMessageVisibilityResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.ChangeMessageVisibilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service", "ChangeMessageVisibility");
            try
            {
                #if DESKTOP
                return client.ChangeMessageVisibility(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ChangeMessageVisibilityAsync(request);
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
            public System.String QueueUrl { get; set; }
            public System.String ReceiptHandle { get; set; }
            public System.Int32? VisibilityTimeout { get; set; }
        }
        
    }
}
