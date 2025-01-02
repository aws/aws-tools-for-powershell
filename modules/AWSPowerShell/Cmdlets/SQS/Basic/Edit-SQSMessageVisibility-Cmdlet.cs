/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// default visibility timeout for a message is 30 seconds. The minimum is 0 seconds.
    /// The maximum is 12 hours. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
    /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// For example, if the default timeout for a queue is 60 seconds, 15 seconds have elapsed
    /// since you received the message, and you send a ChangeMessageVisibility call with <c>VisibilityTimeout</c>
    /// set to 10 seconds, the 10 seconds begin to count from the time that you make the <c>ChangeMessageVisibility</c>
    /// call. Thus, any attempt to change the visibility timeout or to delete that message
    /// 10 seconds after you initially change the visibility timeout (a total of 25 seconds)
    /// might result in an error.
    /// </para><para>
    /// An Amazon SQS message has three basic states:
    /// </para><ol><li><para>
    /// Sent to a queue by a producer.
    /// </para></li><li><para>
    /// Received from the queue by a consumer.
    /// </para></li><li><para>
    /// Deleted from the queue.
    /// </para></li></ol><para>
    /// A message is considered to be <i>stored</i> after it is sent to a queue by a producer,
    /// but not yet received from the queue by a consumer (that is, between states 1 and 2).
    /// There is no limit to the number of stored messages. A message is considered to be
    /// <i>in flight</i> after it is received from a queue by a consumer, but not yet deleted
    /// from the queue (that is, between states 2 and 3). There is a limit to the number of
    /// in flight messages.
    /// </para><para>
    /// Limits that apply to in flight messages are unrelated to the <i>unlimited</i> number
    /// of stored messages.
    /// </para><para>
    /// For most standard queues (depending on queue traffic and message backlog), there can
    /// be a maximum of approximately 120,000 in flight messages (received from a queue by
    /// a consumer, but not yet deleted from the queue). If you reach this limit, Amazon SQS
    /// returns the <c>OverLimit</c> error message. To avoid reaching the limit, you should
    /// delete messages from the queue after they're processed. You can also increase the
    /// number of queues you use to process your messages. To request a limit increase, <a href="https://console.aws.amazon.com/support/home#/case/create?issueType=service-limit-increase&amp;limitType=service-code-sqs">file
    /// a support request</a>.
    /// </para><para>
    /// For FIFO queues, there can be a maximum of 120,000 in flight messages (received from
    /// a queue by a consumer, but not yet deleted from the queue). If you reach this limit,
    /// Amazon SQS returns no error messages.
    /// </para><important><para>
    /// If you attempt to set the <c>VisibilityTimeout</c> to a value greater than the maximum
    /// time left, Amazon SQS returns an error. Amazon SQS doesn't automatically recalculate
    /// and increase the timeout to the maximum remaining time.
    /// </para><para>
    /// Unlike with a queue, when you change the visibility timeout for a specific message
    /// the timeout value is applied immediately but isn't saved in memory for that message.
    /// If you don't delete a message after it is received, the visibility timeout for the
    /// message reverts to the original timeout value (not to the value you set using the
    /// <c>ChangeMessageVisibility</c> action) the next time the message is received.
    /// </para></important>
    /// </summary>
    [Cmdlet("Edit", "SQSMessageVisibility", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) ChangeMessageVisibility API operation.", Operation = new[] {"ChangeMessageVisibility"}, SelectReturnType = typeof(Amazon.SQS.Model.ChangeMessageVisibilityResponse))]
    [AWSCmdletOutput("None or Amazon.SQS.Model.ChangeMessageVisibilityResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SQS.Model.ChangeMessageVisibilityResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditSQSMessageVisibilityCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue whose message's visibility is changed.</para><para>Queue URLs and names are case-sensitive.</para>
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
        /// <para>The receipt handle associated with the message, whose visibility timeout is changed.
        /// This parameter is returned by the <c><a>ReceiveMessage</a></c> action.</para>
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
        
        #region Parameter VisibilityTimeout
        /// <summary>
        /// <para>
        /// <para>The new value for the message's visibility timeout (in seconds). Values range: <c>0</c>
        /// to <c>43200</c>. Maximum: 12 hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? VisibilityTimeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.ChangeMessageVisibilityResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueueUrl), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-SQSMessageVisibility (ChangeMessageVisibility)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.ChangeMessageVisibilityResponse, EditSQSMessageVisibilityCmdlet>(Select) ??
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
            context.VisibilityTimeout = this.VisibilityTimeout;
            #if MODULAR
            if (this.VisibilityTimeout == null && ParameterWasBound(nameof(this.VisibilityTimeout)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibilityTimeout which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
        
        private Amazon.SQS.Model.ChangeMessageVisibilityResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.ChangeMessageVisibilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "ChangeMessageVisibility");
            try
            {
                #if DESKTOP
                return client.ChangeMessageVisibility(request);
                #elif CORECLR
                return client.ChangeMessageVisibilityAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SQS.Model.ChangeMessageVisibilityResponse, EditSQSMessageVisibilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
