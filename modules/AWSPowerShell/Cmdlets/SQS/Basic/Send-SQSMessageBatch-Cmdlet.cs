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
    /// You can use <c>SendMessageBatch</c> to send up to 10 messages to the specified queue
    /// by assigning either identical or different values to each message (or by not assigning
    /// values at all). This is a batch version of <c><a>SendMessage</a>.</c> For a FIFO
    /// queue, multiple messages within a single batch are enqueued in the order they are
    /// sent.
    /// 
    ///  
    /// <para>
    /// The result of sending each message is reported individually in the response. Because
    /// the batch request can result in a combination of successful and unsuccessful actions,
    /// you should check for batch errors even when the call returns an HTTP status code of
    /// <c>200</c>.
    /// </para><para>
    /// The maximum allowed individual message size and the maximum total payload size (the
    /// sum of the individual lengths of all of the batched messages) are both 1 MiB 1,048,576
    /// bytes.
    /// </para><important><para>
    /// A message can include only XML, JSON, and unformatted text. The following Unicode
    /// characters are allowed. For more information, see the <a href="http://www.w3.org/TR/REC-xml/#charsets">W3C
    /// specification for characters</a>.
    /// </para><para><c>#x9</c> | <c>#xA</c> | <c>#xD</c> | <c>#x20</c> to <c>#xD7FF</c> | <c>#xE000</c>
    /// to <c>#xFFFD</c> | <c>#x10000</c> to <c>#x10FFFF</c></para><para>
    /// Amazon SQS does not throw an exception or completely reject the message if it contains
    /// invalid characters. Instead, it replaces those invalid characters with U+FFFD before
    /// storing the message in the queue, as long as the message body contains at least one
    /// valid character.
    /// </para></important><para>
    /// If you don't specify the <c>DelaySeconds</c> parameter for an entry, Amazon SQS uses
    /// the default value for the queue.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "SQSMessageBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.SendMessageBatchResponse")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) SendMessageBatch API operation.", Operation = new[] {"SendMessageBatch"}, SelectReturnType = typeof(Amazon.SQS.Model.SendMessageBatchResponse))]
    [AWSCmdletOutput("Amazon.SQS.Model.SendMessageBatchResponse",
        "This cmdlet returns an Amazon.SQS.Model.SendMessageBatchResponse object containing multiple properties."
    )]
    public partial class SendSQSMessageBatchCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>A list of <c><a>SendMessageBatchRequestEntry</a></c> items.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Entries")]
        public Amazon.SQS.Model.SendMessageBatchRequestEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to which batched messages are sent.</para><para>Queue URLs and names are case-sensitive.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.SendMessageBatchResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.SendMessageBatchResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SQSMessageBatch (SendMessageBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.SendMessageBatchResponse, SendSQSMessageBatchCmdlet>(Select) ??
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
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.SQS.Model.SendMessageBatchRequestEntry>(this.Entry);
            }
            #if MODULAR
            if (this.Entry == null && ParameterWasBound(nameof(this.Entry)))
            {
                WriteWarning("You are passing $null as a value for parameter Entry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueueUrl = this.QueueUrl;
            #if MODULAR
            if (this.QueueUrl == null && ParameterWasBound(nameof(this.QueueUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SQS.Model.SendMessageBatchRequest();
            
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
            }
            if (cmdletContext.QueueUrl != null)
            {
                request.QueueUrl = cmdletContext.QueueUrl;
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
        
        private Amazon.SQS.Model.SendMessageBatchResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.SendMessageBatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "SendMessageBatch");
            try
            {
                #if DESKTOP
                return client.SendMessageBatch(request);
                #elif CORECLR
                return client.SendMessageBatchAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SQS.Model.SendMessageBatchRequestEntry> Entry { get; set; }
            public System.String QueueUrl { get; set; }
            public System.Func<Amazon.SQS.Model.SendMessageBatchResponse, SendSQSMessageBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
