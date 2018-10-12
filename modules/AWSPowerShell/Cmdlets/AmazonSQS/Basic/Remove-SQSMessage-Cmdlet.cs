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
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Deletes the specified message from the specified queue. To select the message to delete,
    /// use the <code>ReceiptHandle</code> of the message (<i>not</i> the <code>MessageId</code>
    /// which you receive when you send the message). Amazon SQS can delete a message from
    /// a queue even if a visibility timeout setting causes the message to be locked by another
    /// consumer. Amazon SQS automatically deletes messages left in a queue longer than the
    /// retention period configured for the queue. 
    /// 
    ///  <note><para>
    /// The <code>ReceiptHandle</code> is associated with a <i>specific instance</i> of receiving
    /// a message. If you receive a message more than once, the <code>ReceiptHandle</code>
    /// is different each time you receive a message. When you use the <code>DeleteMessage</code>
    /// action, you must provide the most recently received <code>ReceiptHandle</code> for
    /// the message (otherwise, the request succeeds, but the message might not be deleted).
    /// </para><para>
    /// For standard queues, it is possible to receive a message even after you delete it.
    /// This might happen on rare occasions if one of the servers which stores a copy of the
    /// message is unavailable when you send the request to delete the message. The copy remains
    /// on the server and might be returned to you during a subsequent receive request. You
    /// should ensure that your application is idempotent, so that receiving a message more
    /// than once does not cause issues.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "SQSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service DeleteMessage API operation.", Operation = new[] {"DeleteMessage"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the QueueUrl parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SQS.Model.DeleteMessageResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSQSMessageCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue from which messages are deleted.</para><para>Queue URLs and names are case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueUrl { get; set; }
        #endregion
        
        #region Parameter ReceiptHandle
        /// <summary>
        /// <para>
        /// <para>The receipt handle associated with the message to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ReceiptHandle { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReceiptHandle", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SQSMessage (DeleteMessage)"))
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
            var request = new Amazon.SQS.Model.DeleteMessageRequest();
            
            if (cmdletContext.QueueUrl != null)
            {
                request.QueueUrl = cmdletContext.QueueUrl;
            }
            if (cmdletContext.ReceiptHandle != null)
            {
                request.ReceiptHandle = cmdletContext.ReceiptHandle;
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
        
        private Amazon.SQS.Model.DeleteMessageResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.DeleteMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service", "DeleteMessage");
            try
            {
                #if DESKTOP
                return client.DeleteMessage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteMessageAsync(request);
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
        }
        
    }
}
