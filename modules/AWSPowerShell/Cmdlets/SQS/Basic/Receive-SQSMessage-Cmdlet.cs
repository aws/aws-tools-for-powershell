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
    /// Retrieves one or more messages (up to 10), from the specified queue. Using the <code>WaitTimeSeconds</code>
    /// parameter enables long-poll support. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-long-polling.html">Amazon
    /// SQS Long Polling</a> in the <i>Amazon SQS Developer Guide</i>. 
    /// 
    ///  
    /// <para>
    /// Short poll is the default behavior where a weighted random set of machines is sampled
    /// on a <code>ReceiveMessage</code> call. Thus, only the messages on the sampled machines
    /// are returned. If the number of messages in the queue is small (fewer than 1,000),
    /// you most likely get fewer messages than you requested per <code>ReceiveMessage</code>
    /// call. If the number of messages in the queue is extremely small, you might not receive
    /// any messages in a particular <code>ReceiveMessage</code> response. If this happens,
    /// repeat the request. 
    /// </para><para>
    /// For each message returned, the response includes the following:
    /// </para><ul><li><para>
    /// The message body.
    /// </para></li><li><para>
    /// An MD5 digest of the message body. For information about MD5, see <a href="https://www.ietf.org/rfc/rfc1321.txt">RFC1321</a>.
    /// </para></li><li><para>
    /// The <code>MessageId</code> you received when you sent the message to the queue.
    /// </para></li><li><para>
    /// The receipt handle.
    /// </para></li><li><para>
    /// The message attributes.
    /// </para></li><li><para>
    /// An MD5 digest of the message attributes.
    /// </para></li></ul><para>
    /// The receipt handle is the identifier you must provide when deleting the message. For
    /// more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-queue-message-identifiers.html">Queue
    /// and Message Identifiers</a> in the <i>Amazon SQS Developer Guide</i>.
    /// </para><para>
    /// You can provide the <code>VisibilityTimeout</code> parameter in your request. The
    /// parameter is applied to the messages that Amazon SQS returns in the response. If you
    /// don't include the parameter, the overall visibility timeout for the queue is used
    /// for the returned messages. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
    /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.
    /// </para><para>
    /// A message that isn't deleted or a message whose visibility isn't extended before the
    /// visibility timeout expires counts as a failed receive. Depending on the configuration
    /// of the queue, the message might be sent to the dead-letter queue.
    /// </para><note><para>
    /// In the future, new attributes might be added. If you write code that calls this action,
    /// we recommend that you structure your code so that it can handle new attributes gracefully.
    /// </para></note>
    /// </summary>
    [Cmdlet("Receive", "SQSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.Message")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) ReceiveMessage API operation.", Operation = new[] {"ReceiveMessage"}, SelectReturnType = typeof(Amazon.SQS.Model.ReceiveMessageResponse))]
    [AWSCmdletOutput("Amazon.SQS.Model.Message or Amazon.SQS.Model.ReceiveMessageResponse",
        "This cmdlet returns a collection of Amazon.SQS.Model.Message objects.",
        "The service call response (type Amazon.SQS.Model.ReceiveMessageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ReceiveSQSMessageCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A list of attributes that need to be returned along with each message. These attributes
        /// include:</para><ul><li><para><code>All</code> – Returns all values.</para></li><li><para><code>ApproximateFirstReceiveTimestamp</code> – Returns the time the message was
        /// first received from the queue (<a href="http://en.wikipedia.org/wiki/Unix_time">epoch
        /// time</a> in milliseconds).</para></li><li><para><code>ApproximateReceiveCount</code> – Returns the number of times a message has
        /// been received across all queues but not deleted.</para></li><li><para><code>AWSTraceHeader</code> – Returns the X-Ray trace header string. </para></li><li><para><code>SenderId</code></para><ul><li><para>For an IAM user, returns the IAM user ID, for example <code>ABCDEFGHI1JKLMNOPQ23R</code>.</para></li><li><para>For an IAM role, returns the IAM role ID, for example <code>ABCDE1F2GH3I4JK5LMNOP:i-a123b456</code>.</para></li></ul></li><li><para><code>SentTimestamp</code> – Returns the time the message was sent to the queue (<a href="http://en.wikipedia.org/wiki/Unix_time">epoch time</a> in milliseconds).</para></li><li><para><code>MessageDeduplicationId</code> – Returns the value provided by the producer
        /// that calls the <code><a>SendMessage</a></code> action.</para></li><li><para><code>MessageGroupId</code> – Returns the value provided by the producer that calls
        /// the <code><a>SendMessage</a></code> action. Messages with the same <code>MessageGroupId</code>
        /// are returned in sequence.</para></li><li><para><code>SequenceNumber</code> – Returns the value provided by Amazon SQS.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter MessageCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of messages to return. Amazon SQS never returns more messages than
        /// this value (however, fewer messages might be returned). Valid values: 1 to 10. Default:
        /// 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("MaxNumberOfMessages")]
        public System.Int32? MessageCount { get; set; }
        #endregion
        
        #region Parameter MessageAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the message attribute, where <i>N</i> is the index.</para><ul><li><para>The name can contain alphanumeric characters and the underscore (<code>_</code>),
        /// hyphen (<code>-</code>), and period (<code>.</code>).</para></li><li><para>The name is case-sensitive and must be unique among all attribute names for the message.</para></li><li><para>The name must not start with AWS-reserved prefixes such as <code>AWS.</code> or <code>Amazon.</code>
        /// (or any casing variants).</para></li><li><para>The name must not start or end with a period (<code>.</code>), and it should not have
        /// periods in succession (<code>..</code>).</para></li><li><para>The name can be up to 256 characters long.</para></li></ul><para>When using <code>ReceiveMessage</code>, you can send a list of attribute names to
        /// receive, or you can return all of the attributes by specifying <code>All</code> or
        /// <code>.*</code> in your request. You can also use all message attributes starting
        /// with a prefix, for example <code>bar.*</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageAttributeNames")]
        public System.String[] MessageAttributeName { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue from which messages are received.</para><para>Queue URLs and names are case-sensitive.</para>
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
        
        #region Parameter ReceiveRequestAttemptId
        /// <summary>
        /// <para>
        /// <para>This parameter applies only to FIFO (first-in-first-out) queues.</para><para>The token used for deduplication of <code>ReceiveMessage</code> calls. If a networking
        /// issue occurs after a <code>ReceiveMessage</code> action, and instead of a response
        /// you receive a generic error, it is possible to retry the same action with an identical
        /// <code>ReceiveRequestAttemptId</code> to retrieve the same set of messages, even if
        /// their visibility timeout has not yet expired.</para><ul><li><para>You can use <code>ReceiveRequestAttemptId</code> only for 5 minutes after a <code>ReceiveMessage</code>
        /// action.</para></li><li><para>When you set <code>FifoQueue</code>, a caller of the <code>ReceiveMessage</code> action
        /// can provide a <code>ReceiveRequestAttemptId</code> explicitly.</para></li><li><para>If a caller of the <code>ReceiveMessage</code> action doesn't provide a <code>ReceiveRequestAttemptId</code>,
        /// Amazon SQS generates a <code>ReceiveRequestAttemptId</code>.</para></li><li><para>It is possible to retry the <code>ReceiveMessage</code> action with the same <code>ReceiveRequestAttemptId</code>
        /// if none of the messages have been modified (deleted or had their visibility changes).</para></li><li><para>During a visibility timeout, subsequent calls with the same <code>ReceiveRequestAttemptId</code>
        /// return the same messages and receipt handles. If a retry occurs within the deduplication
        /// interval, it resets the visibility timeout. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
        /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.</para><important><para>If a caller of the <code>ReceiveMessage</code> action still processes messages when
        /// the visibility timeout expires and messages become visible, another worker consuming
        /// from the same queue can receive the same messages and therefore process duplicates.
        /// Also, if a consumer whose message processing time is longer than the visibility timeout
        /// tries to delete the processed messages, the action fails with an error.</para><para>To mitigate this effect, ensure that your application observes a safe threshold before
        /// the visibility timeout expires and extend the visibility timeout as necessary.</para></important></li><li><para>While messages with a particular <code>MessageGroupId</code> are invisible, no more
        /// messages belonging to the same <code>MessageGroupId</code> are returned until the
        /// visibility timeout expires. You can still receive messages with another <code>MessageGroupId</code>
        /// as long as it is also visible.</para></li><li><para>If a caller of <code>ReceiveMessage</code> can't track the <code>ReceiveRequestAttemptId</code>,
        /// no retries work until the original visibility timeout expires. As a result, delays
        /// might occur but the messages in the queue remain in a strict order.</para></li></ul><para>The maximum length of <code>ReceiveRequestAttemptId</code> is 128 characters. <code>ReceiveRequestAttemptId</code>
        /// can contain alphanumeric characters (<code>a-z</code>, <code>A-Z</code>, <code>0-9</code>)
        /// and punctuation (<code>!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~</code>).</para><para>For best practices of using <code>ReceiveRequestAttemptId</code>, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/using-receiverequestattemptid-request-parameter.html">Using
        /// the ReceiveRequestAttemptId Request Parameter</a> in the <i>Amazon SQS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReceiveRequestAttemptId { get; set; }
        #endregion
        
        #region Parameter VisibilityTimeout
        /// <summary>
        /// <para>
        /// <para>The duration (in seconds) that the received messages are hidden from subsequent retrieve
        /// requests after being retrieved by a <code>ReceiveMessage</code> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Int32? VisibilityTimeout { get; set; }
        #endregion
        
        #region Parameter WaitTimeInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration (in seconds) for which the call waits for a message to arrive in the
        /// queue before returning. If a message is available, the call returns sooner than <code>WaitTimeSeconds</code>.
        /// If no messages are available and the wait time expires, the call returns successfully
        /// with an empty list of messages.</para><important><para>To avoid HTTP errors, ensure that the HTTP response timeout for <code>ReceiveMessage</code>
        /// requests is longer than the <code>WaitTimeSeconds</code> parameter. For example, with
        /// the Java SDK, you can set HTTP transport settings using the <a href="https://sdk.amazonaws.com/java/api/latest/software/amazon/awssdk/http/nio/netty/NettyNioAsyncHttpClient.html">
        /// NettyNioAsyncHttpClient</a> for asynchronous clients, or the <a href="https://sdk.amazonaws.com/java/api/latest/software/amazon/awssdk/http/apache/ApacheHttpClient.html">
        /// ApacheHttpClient</a> for synchronous clients. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        [Alias("WaitTimeSeconds")]
        public System.Int32? WaitTimeInSeconds { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Messages'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.ReceiveMessageResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.ReceiveMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Messages";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueueUrl), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Receive-SQSMessage (ReceiveMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.ReceiveMessageResponse, ReceiveSQSMessageCmdlet>(Select) ??
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
            if (this.AttributeName != null)
            {
                context.AttributeName = new List<System.String>(this.AttributeName);
            }
            context.MessageCount = this.MessageCount;
            if (this.MessageAttributeName != null)
            {
                context.MessageAttributeName = new List<System.String>(this.MessageAttributeName);
            }
            context.QueueUrl = this.QueueUrl;
            #if MODULAR
            if (this.QueueUrl == null && ParameterWasBound(nameof(this.QueueUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReceiveRequestAttemptId = this.ReceiveRequestAttemptId;
            context.VisibilityTimeout = this.VisibilityTimeout;
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
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeNames = cmdletContext.AttributeName;
            }
            if (cmdletContext.MessageCount != null)
            {
                request.MaxNumberOfMessages = cmdletContext.MessageCount.Value;
            }
            if (cmdletContext.MessageAttributeName != null)
            {
                request.MessageAttributeNames = cmdletContext.MessageAttributeName;
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
        
        private Amazon.SQS.Model.ReceiveMessageResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.ReceiveMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "ReceiveMessage");
            try
            {
                #if DESKTOP
                return client.ReceiveMessage(request);
                #elif CORECLR
                return client.ReceiveMessageAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AttributeName { get; set; }
            public System.Int32? MessageCount { get; set; }
            public List<System.String> MessageAttributeName { get; set; }
            public System.String QueueUrl { get; set; }
            public System.String ReceiveRequestAttemptId { get; set; }
            public System.Int32? VisibilityTimeout { get; set; }
            public System.Int32? WaitTimeInSeconds { get; set; }
            public System.Func<Amazon.SQS.Model.ReceiveMessageResponse, ReceiveSQSMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Messages;
        }
        
    }
}
