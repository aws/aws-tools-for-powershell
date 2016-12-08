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
    /// Retrieves one or more messages, with a maximum limit of 10 messages, from the specified
    /// queue. Long poll support is enabled by using the <code>WaitTimeSeconds</code> parameter.
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-long-polling.html">Amazon
    /// SQS Long Polling</a> in the <i>Amazon SQS Developer Guide</i>. 
    /// 
    ///  
    /// <para>
    ///  Short poll is the default behavior where a weighted random set of machines is sampled
    /// on a <code>ReceiveMessage</code> call. This means only the messages on the sampled
    /// machines are returned. If the number of messages in the queue is small (less than
    /// 1000), it is likely you will get fewer messages than you requested per <code>ReceiveMessage</code>
    /// call. If the number of messages in the queue is extremely small, you might not receive
    /// any messages in a particular <code>ReceiveMessage</code> response; in which case you
    /// should repeat the request. 
    /// </para><para>
    /// For each message returned, the response includes the following:
    /// </para><ul><li><para>
    /// Message body
    /// </para></li><li><para>
    ///  MD5 digest of the message body. For information about MD5, see <a href="https://www.ietf.org/rfc/rfc1321.txt">RFC1321</a>.
    /// 
    /// </para></li><li><para>
    /// Message ID you received when you sent the message to the queue.
    /// </para></li><li><para>
    /// Receipt handle.
    /// </para></li><li><para>
    /// Message attributes.
    /// </para></li><li><para>
    /// MD5 digest of the message attributes.
    /// </para></li></ul><para>
    ///  The receipt handle is the identifier you must provide when deleting the message.
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-queue-message-identifiers.html">Queue
    /// and Message Identifiers</a> in the <i>Amazon SQS Developer Guide</i>. 
    /// </para><para>
    ///  You can provide the <code>VisibilityTimeout</code> parameter in your request, which
    /// will be applied to the messages that Amazon SQS returns in the response. If you don't
    /// include the parameter, the overall visibility timeout for the queue is used for the
    /// returned messages. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
    /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>. 
    /// </para><para>
    ///  A message that is not deleted or a message whose visibility is not extended before
    /// the visibility timeout expires counts as a failed receive. Depending on the configuration
    /// of the queue, the message might be sent to the dead letter queue. 
    /// </para><note><para>
    /// Going forward, new attributes might be added. If you are writing code that calls this
    /// action, we recommend that you structure your code so that it can handle new attributes
    /// gracefully.
    /// </para></note>
    /// </summary>
    [Cmdlet("Receive", "SQSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.Message")]
    [AWSCmdlet("Invokes the ReceiveMessage operation against Amazon Simple Queue Service.", Operation = new[] {"ReceiveMessage"})]
    [AWSCmdletOutput("Amazon.SQS.Model.Message",
        "This cmdlet returns a collection of Message objects.",
        "The service call response (type Amazon.SQS.Model.ReceiveMessageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ReceiveSQSMessageCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A list of attributes that need to be returned along with each message. These attributes
        /// include:</para><ul><li><para><code>All</code> - Returns all values.</para></li><li><para><code>ApproximateFirstReceiveTimestamp</code> - Returns the time the message was
        /// first received from the queue (epoch time in milliseconds).</para></li><li><para><code>ApproximateReceiveCount</code> - Returns the number of times a message has
        /// been received from the queue but not deleted.</para></li><li><para><code>SenderId</code></para><ul><li><para>For an IAM user, returns the IAM user ID, for example <code>ABCDEFGHI1JKLMNOPQ23R</code>.</para></li><li><para>For an IAM role, returns the IAM role ID, for example <code>ABCDE1F2GH3I4JK5LMNOP:i-a123b456</code>.</para></li></ul></li><li><para><code>SentTimestamp</code> - Returns the time the message was sent to the queue (epoch
        /// time in milliseconds).</para></li><li><para><code>MessageDeduplicationId</code> - Returns the value provided by the sender that
        /// calls the <code><a>SendMessage</a></code> action.</para></li><li><para><code>MessageGroupId</code> - Returns the value provided by the sender that calls
        /// the <code><a>SendMessage</a></code> action. Messages with the same <code>MessageGroupId</code>
        /// are returned in sequence.</para></li><li><para><code>SequenceNumber</code> - Returns the value provided by Amazon SQS.</para></li></ul><para>Any other valid special request parameters (such as the following) that are specified
        /// are ignored:</para><ul><li><para><code>ApproximateNumberOfMessages</code></para></li><li><para><code>ApproximateNumberOfMessagesDelayed</code></para></li><li><para><code>ApproximateNumberOfMessagesNotVisible</code></para></li><li><para><code>CreatedTimestamp</code></para></li><li><para><code>ContentBasedDeduplication</code></para></li><li><para><code>DelaySeconds</code></para></li><li><para><code>LastModifiedTimestamp</code></para></li><li><para><code>MaximumMessageSize</code></para></li><li><para><code>MessageRetentionPeriod</code></para></li><li><para><code>Policy</code></para></li><li><para><code>QueueArn</code>, </para></li><li><para><code>ReceiveMessageWaitTimeSeconds</code></para></li><li><para><code>RedrivePolicy</code></para></li><li><para><code>FifoQueue</code></para></li><li><para><code>VisibilityTimeout</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter MessageCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of messages to return. Amazon SQS never returns more messages than
        /// this value but might return fewer. Values can be from 1 to 10. Default is 1.</para><para>All of the messages are not necessarily returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("MaxNumberOfMessages")]
        public System.Int32 MessageCount { get; set; }
        #endregion
        
        #region Parameter MessageAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the message attribute, where <i>N</i> is the index. The message attribute
        /// name can contain the following characters: A-Z, a-z, 0-9, underscore (_), hyphen (-),
        /// and period (.). The name must not start or end with a period, and it should not have
        /// successive periods. The name is case sensitive and must be unique among all attribute
        /// names for the message. The name can be up to 256 characters long. The name can't start
        /// with "AWS." or "Amazon." (or any variations in casing), because these prefixes are
        /// reserved for use by Amazon Web Services.</para><para>When using <code>ReceiveMessage</code>, you can send a list of attribute names to
        /// receive, or you can return all of the attributes by specifying "All" or ".*" in your
        /// request. You can also use "bar.*" to return all message attributes starting with the
        /// "bar" prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageAttributeNames")]
        public System.String[] MessageAttributeName { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to take action on.</para><para>Queue URLs are case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueUrl { get; set; }
        #endregion
        
        #region Parameter ReceiveRequestAttemptId
        /// <summary>
        /// <para>
        /// <para>This parameter applies only to FIFO (first-in-first-out) queues.</para><para>The token used for deduplication of <code>ReceiveMessage</code> calls. If a networking
        /// issue occurs after a <code>ReceiveMessage</code> action, and instead of a response
        /// you receive a generic error, you can retry the same action with an identical <code>ReceiveRequestAttemptId</code>
        /// to retrieve the same set of messages, even if their visibility timeout has not yet
        /// expired.</para><ul><li><para>You can use <code>ReceiveRequestAttemptId</code> only for 5 minutes after a <code>ReceiveMessage</code>
        /// action.</para></li><li><para>When you set <code>FifoQueue</code>, a caller of the <code>ReceiveMessage</code> action
        /// can provide a <code>ReceiveRequestAttemptId</code> explicitly.</para></li><li><para>If a caller of the <code>ReceiveMessage</code> action doesn't provide a <code>ReceiveRequestAttemptId</code>,
        /// Amazon SQS generates a <code>ReceiveRequestAttemptId</code>.</para></li><li><para>You can retry the <code>ReceiveMessage</code> action with the same <code>ReceiveRequestAttemptId</code>
        /// if none of the messages have been modified (deleted or had their visibility changes).</para></li><li><para>During a visibility timeout, subsequent calls with the same <code>ReceiveRequestAttemptId</code>
        /// return the same messages and receipt handles. If a retry occurs within the deduplication
        /// interval, it resets the visibility timeout. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
        /// Timeout</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.</para><important><para>If a caller of the <code>ReceiveMessage</code> action is still processing messages
        /// when the visibility timeout expires and messages become visible, another worker reading
        /// from the same queue can receive the same messages and therefore process duplicates.
        /// Also, if a reader whose message processing time is longer than the visibility timeout
        /// tries to delete the processed messages, the action fails with an error.</para><para>To mitigate this effect, ensure that your application observes a safe threshold before
        /// the visibility timeout expires and extend the visibility timeout as necessary.</para></important></li><li><para>While messages with a particular <code>MessageGroupId</code> are invisible, no more
        /// messages belonging to the same <code>MessageGroupId</code> are returned until the
        /// visibility timeout expires. You can still receive messages with another <code>MessageGroupId</code>
        /// as long as it is also visible.</para></li><li><para>If a caller of <code>ReceiveMessage</code> can't track the <code>ReceiveRequestAttemptId</code>,
        /// no retries will work until the original visibility timeout expires. As a result, delays
        /// might occur but the messages in the queue will remain in a strict order.</para></li></ul><para>The length of <code>ReceiveRequestAttemptId</code> is 128 characters. <code>ReceiveRequestAttemptId</code>
        /// can contain alphanumeric characters (<code>a-z</code>, <code>A-Z</code>, <code>0-9</code>)
        /// and punctuation (<code>!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~</code>).</para><para>For best practices of using <code>ReceiveRequestAttemptId</code>, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queue-recommendations.html#using-receiverequestattemptid-request-parameter">Using
        /// the ReceiveRequestAttemptId Request Parameter</a> in the <i>Amazon Simple Queue Service
        /// Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReceiveRequestAttemptId { get; set; }
        #endregion
        
        #region Parameter VisibilityTimeout
        /// <summary>
        /// <para>
        /// <para>The duration (in seconds) that the received messages are hidden from subsequent retrieve
        /// requests after being retrieved by a <code>ReceiveMessage</code> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Int32 VisibilityTimeout { get; set; }
        #endregion
        
        #region Parameter WaitTimeInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration (in seconds) for which the call will wait for a message to arrive in
        /// the queue before returning. If a message is available, the call will return sooner
        /// than WaitTimeSeconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        [Alias("WaitTimeSeconds")]
        public System.Int32 WaitTimeInSeconds { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Receive-SQSMessage (ReceiveMessage)"))
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
            
            if (this.AttributeName != null)
            {
                context.AttributeNames = new List<System.String>(this.AttributeName);
            }
            if (ParameterWasBound("MessageCount"))
                context.MessageCount = this.MessageCount;
            if (this.MessageAttributeName != null)
            {
                context.MessageAttributeNames = new List<System.String>(this.MessageAttributeName);
            }
            context.QueueUrl = this.QueueUrl;
            context.ReceiveRequestAttemptId = this.ReceiveRequestAttemptId;
            if (ParameterWasBound("VisibilityTimeout"))
                context.VisibilityTimeout = this.VisibilityTimeout;
            if (ParameterWasBound("WaitTimeInSeconds"))
                context.WaitTimeInSeconds = this.WaitTimeInSeconds;
            
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
            var request = new Amazon.SQS.Model.ReceiveMessageRequest();
            
            if (cmdletContext.AttributeNames != null)
            {
                request.AttributeNames = cmdletContext.AttributeNames;
            }
            if (cmdletContext.MessageCount != null)
            {
                request.MaxNumberOfMessages = cmdletContext.MessageCount.Value;
            }
            if (cmdletContext.MessageAttributeNames != null)
            {
                request.MessageAttributeNames = cmdletContext.MessageAttributeNames;
            }
            if (cmdletContext.QueueUrl != null)
            {
                request.QueueUrl = cmdletContext.QueueUrl;
            }
            if (cmdletContext.ReceiveRequestAttemptId != null)
            {
                request.ReceiveRequestAttemptId = cmdletContext.ReceiveRequestAttemptId;
            }
            if (cmdletContext.VisibilityTimeout != null)
            {
                request.VisibilityTimeout = cmdletContext.VisibilityTimeout.Value;
            }
            if (cmdletContext.WaitTimeInSeconds != null)
            {
                request.WaitTimeSeconds = cmdletContext.WaitTimeInSeconds.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Messages;
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
        
        private static Amazon.SQS.Model.ReceiveMessageResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.ReceiveMessageRequest request)
        {
            #if DESKTOP
            return client.ReceiveMessage(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ReceiveMessageAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AttributeNames { get; set; }
            public System.Int32? MessageCount { get; set; }
            public List<System.String> MessageAttributeNames { get; set; }
            public System.String QueueUrl { get; set; }
            public System.String ReceiveRequestAttemptId { get; set; }
            public System.Int32? VisibilityTimeout { get; set; }
            public System.Int32? WaitTimeInSeconds { get; set; }
        }
        
    }
}
