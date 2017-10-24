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
    /// Delivers a message to the specified queue.
    /// 
    ///  <important><para>
    /// A message can include only XML, JSON, and unformatted text. The following Unicode
    /// characters are allowed:
    /// </para><para><code>#x9</code> | <code>#xA</code> | <code>#xD</code> | <code>#x20</code> to <code>#xD7FF</code>
    /// | <code>#xE000</code> to <code>#xFFFD</code> | <code>#x10000</code> to <code>#x10FFFF</code></para><para>
    /// Any characters not included in this list will be rejected. For more information, see
    /// the <a href="http://www.w3.org/TR/REC-xml/#charsets">W3C specification for characters</a>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Send", "SQSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.SendMessageResponse")]
    [AWSCmdlet("Invokes the SendMessage operation against Amazon Simple Queue Service.", Operation = new[] {"SendMessage"})]
    [AWSCmdletOutput("Amazon.SQS.Model.SendMessageResponse",
        "This cmdlet returns a Amazon.SQS.Model.SendMessageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSQSMessageCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter DelayInSeconds
        /// <summary>
        /// <para>
        /// <para> The length of time, in seconds, for which to delay a specific message. Valid values:
        /// 0 to 900. Maximum: 15 minutes. Messages with a positive <code>DelaySeconds</code>
        /// value become available for processing after the delay period is finished. If you don't
        /// specify a value, the default value for the queue applies. </para><note><para>When you set <code>FifoQueue</code>, you can't set <code>DelaySeconds</code> per message.
        /// You can set this parameter only on a queue level.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("DelaySeconds")]
        public System.Int32 DelayInSeconds { get; set; }
        #endregion
        
        #region Parameter MessageAttribute
        /// <summary>
        /// <para>
        /// <para>Each message attribute consists of a <code>Name</code>, <code>Type</code>, and <code>Value</code>.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-message-attributes.html#message-attributes-items-validation">Message
        /// Attribute Items and Validation</a> in the <i>Amazon Simple Queue Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageAttributes")]
        public System.Collections.Hashtable MessageAttribute { get; set; }
        #endregion
        
        #region Parameter MessageBody
        /// <summary>
        /// <para>
        /// <para>The message to send. The maximum string size is 256 KB.</para><important><para>A message can include only XML, JSON, and unformatted text. The following Unicode
        /// characters are allowed:</para><para><code>#x9</code> | <code>#xA</code> | <code>#xD</code> | <code>#x20</code> to <code>#xD7FF</code>
        /// | <code>#xE000</code> to <code>#xFFFD</code> | <code>#x10000</code> to <code>#x10FFFF</code></para><para>Any characters not included in this list will be rejected. For more information, see
        /// the <a href="http://www.w3.org/TR/REC-xml/#charsets">W3C specification for characters</a>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String MessageBody { get; set; }
        #endregion
        
        #region Parameter MessageDeduplicationId
        /// <summary>
        /// <para>
        /// <para>This parameter applies only to FIFO (first-in-first-out) queues.</para><para>The token used for deduplication of sent messages. If a message with a particular
        /// <code>MessageDeduplicationId</code> is sent successfully, any messages sent with the
        /// same <code>MessageDeduplicationId</code> are accepted successfully but aren't delivered
        /// during the 5-minute deduplication interval. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html#FIFO-queues-exactly-once-processing">
        /// Exactly-Once Processing</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.</para><ul><li><para>Every message must have a unique <code>MessageDeduplicationId</code>,</para><ul><li><para>You may provide a <code>MessageDeduplicationId</code> explicitly.</para></li><li><para>If you aren't able to provide a <code>MessageDeduplicationId</code> and you enable
        /// <code>ContentBasedDeduplication</code> for your queue, Amazon SQS uses a SHA-256 hash
        /// to generate the <code>MessageDeduplicationId</code> using the body of the message
        /// (but not the attributes of the message). </para></li><li><para>If you don't provide a <code>MessageDeduplicationId</code> and the queue doesn't have
        /// <code>ContentBasedDeduplication</code> set, the action fails with an error.</para></li><li><para>If the queue has <code>ContentBasedDeduplication</code> set, your <code>MessageDeduplicationId</code>
        /// overrides the generated one.</para></li></ul></li><li><para>When <code>ContentBasedDeduplication</code> is in effect, messages with identical
        /// content sent within the deduplication interval are treated as duplicates and only
        /// one copy of the message is delivered.</para></li><li><para>If you send one message with <code>ContentBasedDeduplication</code> enabled and then
        /// another message with a <code>MessageDeduplicationId</code> that is the same as the
        /// one generated for the first <code>MessageDeduplicationId</code>, the two messages
        /// are treated as duplicates and only one copy of the message is delivered. </para></li></ul><note><para>The <code>MessageDeduplicationId</code> is available to the recipient of the message
        /// (this can be useful for troubleshooting delivery issues).</para><para>If a message is sent successfully but the acknowledgement is lost and the message
        /// is resent with the same <code>MessageDeduplicationId</code> after the deduplication
        /// interval, Amazon SQS can't detect duplicate messages.</para></note><para>The length of <code>MessageDeduplicationId</code> is 128 characters. <code>MessageDeduplicationId</code>
        /// can contain alphanumeric characters (<code>a-z</code>, <code>A-Z</code>, <code>0-9</code>)
        /// and punctuation (<code>!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~</code>).</para><para>For best practices of using <code>MessageDeduplicationId</code>, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queue-recommendations.html#using-messagededuplicationid-property">Using
        /// the MessageDeduplicationId Property</a> in the <i>Amazon Simple Queue Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MessageDeduplicationId { get; set; }
        #endregion
        
        #region Parameter MessageGroupId
        /// <summary>
        /// <para>
        /// <para>This parameter applies only to FIFO (first-in-first-out) queues.</para><para>The tag that specifies that a message belongs to a specific message group. Messages
        /// that belong to the same message group are processed in a FIFO manner (however, messages
        /// in different message groups might be processed out of order). To interleave multiple
        /// ordered streams within a single queue, use <code>MessageGroupId</code> values (for
        /// example, session data for multiple users). In this scenario, multiple readers can
        /// process the queue, but the session data of each user is processed in a FIFO fashion.</para><ul><li><para>You must associate a non-empty <code>MessageGroupId</code> with a message. If you
        /// don't provide a <code>MessageGroupId</code>, the action fails.</para></li><li><para><code>ReceiveMessage</code> might return messages with multiple <code>MessageGroupId</code>
        /// values. For each <code>MessageGroupId</code>, the messages are sorted by time sent.
        /// The caller can't specify a <code>MessageGroupId</code>.</para></li></ul><para>The length of <code>MessageGroupId</code> is 128 characters. Valid values are alphanumeric
        /// characters and punctuation <code>(!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~)</code>.</para><para>For best practices of using <code>MessageGroupId</code>, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queue-recommendations.html#using-messagegroupid-property">Using
        /// the MessageGroupId Property</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.</para><important><para><code>MessageGroupId</code> is required for FIFO queues. You can't use it for Standard
        /// queues.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MessageGroupId { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to which a message is sent.</para><para>Queue URLs are case-sensitive.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("MessageDeduplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SQSMessage (SendMessage)"))
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
            
            if (ParameterWasBound("DelayInSeconds"))
                context.DelayInSeconds = this.DelayInSeconds;
            if (this.MessageAttribute != null)
            {
                context.MessageAttributes = new Dictionary<System.String, Amazon.SQS.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageAttribute.Keys)
                {
                    context.MessageAttributes.Add((String)hashKey, (MessageAttributeValue)(this.MessageAttribute[hashKey]));
                }
            }
            context.MessageBody = this.MessageBody;
            context.MessageDeduplicationId = this.MessageDeduplicationId;
            context.MessageGroupId = this.MessageGroupId;
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
            var request = new Amazon.SQS.Model.SendMessageRequest();
            
            if (cmdletContext.DelayInSeconds != null)
            {
                request.DelaySeconds = cmdletContext.DelayInSeconds.Value;
            }
            if (cmdletContext.MessageAttributes != null)
            {
                request.MessageAttributes = cmdletContext.MessageAttributes;
            }
            if (cmdletContext.MessageBody != null)
            {
                request.MessageBody = cmdletContext.MessageBody;
            }
            if (cmdletContext.MessageDeduplicationId != null)
            {
                request.MessageDeduplicationId = cmdletContext.MessageDeduplicationId;
            }
            if (cmdletContext.MessageGroupId != null)
            {
                request.MessageGroupId = cmdletContext.MessageGroupId;
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
        
        private Amazon.SQS.Model.SendMessageResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.SendMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service", "SendMessage");
            try
            {
                #if DESKTOP
                return client.SendMessage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendMessageAsync(request);
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
            public System.Int32? DelayInSeconds { get; set; }
            public Dictionary<System.String, Amazon.SQS.Model.MessageAttributeValue> MessageAttributes { get; set; }
            public System.String MessageBody { get; set; }
            public System.String MessageDeduplicationId { get; set; }
            public System.String MessageGroupId { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
