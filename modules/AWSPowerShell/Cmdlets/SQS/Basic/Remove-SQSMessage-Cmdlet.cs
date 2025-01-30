/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// use the <c>ReceiptHandle</c> of the message (<i>not</i> the <c>MessageId</c> which
    /// you receive when you send the message). Amazon SQS can delete a message from a queue
    /// even if a visibility timeout setting causes the message to be locked by another consumer.
    /// Amazon SQS automatically deletes messages left in a queue longer than the retention
    /// period configured for the queue. 
    /// 
    ///  <note><para>
    /// Each time you receive a message, meaning when a consumer retrieves a message from
    /// the queue, it comes with a unique <c>ReceiptHandle</c>. If you receive the same message
    /// more than once, you will get a different <c>ReceiptHandle</c> each time. When you
    /// want to delete a message using the <c>DeleteMessage</c> action, you must use the <c>ReceiptHandle</c>
    /// from the most recent time you received the message. If you use an old <c>ReceiptHandle</c>,
    /// the request will succeed, but the message might not be deleted. 
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
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) DeleteMessage API operation.", Operation = new[] {"DeleteMessage"}, SelectReturnType = typeof(Amazon.SQS.Model.DeleteMessageResponse))]
    [AWSCmdletOutput("None or Amazon.SQS.Model.DeleteMessageResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SQS.Model.DeleteMessageResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSQSMessageCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue from which messages are deleted.</para><para>Queue URLs and names are case-sensitive.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String QueueUrl { get; set; }
        #endregion
        
        #region Parameter ReceiptHandle
        /// <summary>
        /// <para>
        /// <para>The receipt handle associated with the message to delete.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ReceiptHandle { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.DeleteMessageResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueueUrl parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueueUrl' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueueUrl' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReceiptHandle), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SQSMessage (DeleteMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.DeleteMessageResponse, RemoveSQSMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueueUrl;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.QueueUrl = this.QueueUrl;
            #if MODULAR
            if (this.QueueUrl == null && ParameterWasBound(nameof(this.QueueUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReceiptHandle = this.ReceiptHandle;
            #if MODULAR
            if (this.ReceiptHandle == null && ParameterWasBound(nameof(this.ReceiptHandle)))
            {
                WriteWarning("You are passing $null as a value for parameter ReceiptHandle which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "DeleteMessage");
            try
            {
                #if DESKTOP
                return client.DeleteMessage(request);
                #elif CORECLR
                return client.DeleteMessageAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SQS.Model.DeleteMessageResponse, RemoveSQSMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
