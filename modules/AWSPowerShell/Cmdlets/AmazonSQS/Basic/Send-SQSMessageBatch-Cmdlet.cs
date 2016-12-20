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
    /// Delivers up to ten messages to the specified queue. This is a batch version of <code><a>SendMessage</a></code>. For a FIFO queue, multiple messages within a single batch
    /// are enqueued in the order they are sent.
    /// 
    ///  
    /// <para>
    /// The result of sending each message is reported individually in the response. Because
    /// the batch request can result in a combination of successful and unsuccessful actions,
    /// you should check for batch errors even when the call returns an HTTP status code of
    /// <code>200</code>.
    /// </para><para>
    /// The maximum allowed individual message size and the maximum total payload size (the
    /// sum of the individual lengths of all of the batched messages) are both 256 KB (262,144
    /// bytes).
    /// </para><important><para>
    /// The following list shows the characters (in Unicode) that are allowed in your message,
    /// according to the W3C XML specification:
    /// </para><ul><li><para><code>#x9</code></para></li><li><para><code>#xA</code></para></li><li><para><code>#xD</code></para></li><li><para><code>#x20</code> to <code>#xD7FF</code></para></li><li><para><code>#xE000</code> to <code>#xFFFD</code></para></li><li><para><code>#x10000</code> to <code>#x10FFFF</code></para></li></ul><para>
    /// For more information, see <a href="https://www.ietf.org/rfc/rfc1321.txt">RFC1321</a>.
    /// If you send any characters that aren't included in this list, your request is rejected.
    /// </para></important><para>
    /// If you don't specify the <code>DelaySeconds</code> parameter for an entry, Amazon
    /// SQS uses the default value for the queue.
    /// </para><note><para>
    /// Some actions take lists of parameters. These lists are specified using the <code>param.n</code>
    /// notation. Values of <code>n</code> are integers starting from 1. For example, a parameter
    /// list with two elements looks like this:
    /// </para><para><code>&amp;Attribute.1=this</code></para><para><code>&amp;Attribute.2=that</code></para></note>
    /// </summary>
    [Cmdlet("Send", "SQSMessageBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.SendMessageBatchResponse")]
    [AWSCmdlet("Invokes the SendMessageBatch operation against Amazon Simple Queue Service.", Operation = new[] {"SendMessageBatch"})]
    [AWSCmdletOutput("Amazon.SQS.Model.SendMessageBatchResponse",
        "This cmdlet returns a Amazon.SQS.Model.SendMessageBatchResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSQSMessageBatchCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>A list of <code><a>SendMessageBatchRequestEntry</a></code> items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Entries")]
        public Amazon.SQS.Model.SendMessageBatchRequestEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to which batched messages are sent.</para><para>Queue URLs are case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueUrl { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SQSMessageBatch (SendMessageBatch)"))
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
            
            if (this.Entry != null)
            {
                context.Entries = new List<Amazon.SQS.Model.SendMessageBatchRequestEntry>(this.Entry);
            }
            context.QueueUrl = this.QueueUrl;
            
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
            
            if (cmdletContext.Entries != null)
            {
                request.Entries = cmdletContext.Entries;
            }
            if (cmdletContext.QueueUrl != null)
            {
                request.QueueUrl = cmdletContext.QueueUrl;
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
        
        private static Amazon.SQS.Model.SendMessageBatchResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.SendMessageBatchRequest request)
        {
            #if DESKTOP
            return client.SendMessageBatch(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SendMessageBatchAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.SQS.Model.SendMessageBatchRequestEntry> Entries { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
