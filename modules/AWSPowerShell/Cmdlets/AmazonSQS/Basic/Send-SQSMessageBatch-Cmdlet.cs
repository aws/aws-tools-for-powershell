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
    /// Delivers up to ten messages to the specified queue. This is a batch version of <a>SendMessage</a>.
    /// The result of the send action on each message is reported individually in the response.
    /// The maximum allowed individual message size is 256 KB (262,144 bytes).
    /// 
    ///  
    /// <para>
    /// The maximum total payload size (i.e., the sum of all a batch's individual message
    /// lengths) is also 256 KB (262,144 bytes).
    /// </para><para>
    /// If the <code>DelaySeconds</code> parameter is not specified for an entry, the default
    /// for the queue is used.
    /// </para><important>The following list shows the characters (in Unicode) that are allowed
    /// in your message, according to the W3C XML specification. For more information, go
    /// to <a href="http://www.faqs.org/rfcs/rfc1321.html">http://www.faqs.org/rfcs/rfc1321.html</a>.
    /// If you send any characters that are not included in the list, your request will be
    /// rejected. 
    /// <para>
    /// #x9 | #xA | #xD | [#x20 to #xD7FF] | [#xE000 to #xFFFD] | [#x10000 to #x10FFFF]
    /// </para></important><important> Because the batch request can result in a combination of
    /// successful and unsuccessful actions, you should check for batch errors even when the
    /// call returns an HTTP status code of 200. </important><note>Some API actions take
    /// lists of parameters. These lists are specified using the <code>param.n</code> notation.
    /// Values of <code>n</code> are integers starting from 1. For example, a parameter list
    /// with two elements looks like this: </note><para><code>&amp;Attribute.1=this</code></para><para><code>&amp;Attribute.2=that</code></para>
    /// </summary>
    [Cmdlet("Send", "SQSMessageBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.SendMessageBatchResponse")]
    [AWSCmdlet("Invokes the SendMessageBatch operation against Amazon Simple Queue Service.", Operation = new[] {"SendMessageBatch"})]
    [AWSCmdletOutput("Amazon.SQS.Model.SendMessageBatchResponse",
        "This cmdlet returns a Amazon.SQS.Model.SendMessageBatchResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendSQSMessageBatchCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para>A list of <a>SendMessageBatchRequestEntry</a> items.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Entries")]
        public Amazon.SQS.Model.SendMessageBatchRequestEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to take action on.</para>
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
            
            if (this.Entry != null)
            {
                context.Entries = new List<Amazon.SQS.Model.SendMessageBatchRequestEntry>(this.Entry);
            }
            context.QueueUrl = this.QueueUrl;
            
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
                var response = client.SendMessageBatch(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.SQS.Model.SendMessageBatchRequestEntry> Entries { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
