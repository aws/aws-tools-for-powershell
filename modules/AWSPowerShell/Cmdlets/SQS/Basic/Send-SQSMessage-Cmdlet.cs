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
using System.Threading;
using Amazon.SQS;
using Amazon.SQS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SQS
{
    /// <summary>
    /// Delivers a message to the specified queue.
    /// 
    ///  <important><para>
    /// A message can include only XML, JSON, and unformatted text. The following Unicode
    /// characters are allowed. For more information, see the <a href="http://www.w3.org/TR/REC-xml/#charsets">W3C
    /// specification for characters</a>.
    /// </para><para><c>#x9</c> | <c>#xA</c> | <c>#xD</c> | <c>#x20</c> to <c>#xD7FF</c> | <c>#xE000</c>
    /// to <c>#xFFFD</c> | <c>#x10000</c> to <c>#x10FFFF</c></para><para>
    /// Amazon SQS does not throw an exception or completely reject the message if it contains
    /// invalid characters. Instead, it replaces those invalid characters with <c>U+FFFD</c>
    /// before storing the message in the queue, as long as the message body contains at least
    /// one valid character.
    /// </para></important>
    /// </summary>
    [Cmdlet("Send", "SQSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.SendMessageResponse")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) SendMessage API operation.", Operation = new[] {"SendMessage"}, SelectReturnType = typeof(Amazon.SQS.Model.SendMessageResponse))]
    [AWSCmdletOutput("Amazon.SQS.Model.SendMessageResponse",
        "This cmdlet returns an Amazon.SQS.Model.SendMessageResponse object containing multiple properties."
    )]
    public partial class SendSQSMessageCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DelayInSeconds
        /// <summary>
        /// <para>
        /// <para> The length of time, in seconds, for which to delay a specific message. Valid values:
        /// 0 to 900. Maximum: 15 minutes. Messages with a positive <c>DelaySeconds</c> value
        /// become available for processing after the delay period is finished. If you don't specify
        /// a value, the default value for the queue applies. </para><note><para>When you set <c>FifoQueue</c>, you can't set <c>DelaySeconds</c> per message. You
        /// can set this parameter only on a queue level.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("DelaySeconds")]
        public System.Int32? DelayInSeconds { get; set; }
        #endregion
        
        #region Parameter MessageAttribute
        /// <summary>
        /// <para>
        /// <para>Each message attribute consists of a <c>Name</c>, <c>Type</c>, and <c>Value</c>. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-message-metadata.html#sqs-message-attributes">Amazon
        /// SQS message attributes</a> in the <i>Amazon SQS Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageAttributes")]
        public System.Collections.Hashtable MessageAttribute { get; set; }
        #endregion
        
        #region Parameter MessageBody
        /// <summary>
        /// <para>
        /// <para>The message to send. The minimum size is one character. The maximum size is 256 KiB.</para><important><para>A message can include only XML, JSON, and unformatted text. The following Unicode
        /// characters are allowed. For more information, see the <a href="http://www.w3.org/TR/REC-xml/#charsets">W3C
        /// specification for characters</a>.</para><para><c>#x9</c> | <c>#xA</c> | <c>#xD</c> | <c>#x20</c> to <c>#xD7FF</c> | <c>#xE000</c>
        /// to <c>#xFFFD</c> | <c>#x10000</c> to <c>#x10FFFF</c></para><para>Amazon SQS does not throw an exception or completely reject the message if it contains
        /// invalid characters. Instead, it replaces those invalid characters with <c>U+FFFD</c>
        /// before storing the message in the queue, as long as the message body contains at least
        /// one valid character.</para></important>
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
        public System.String MessageBody { get; set; }
        #endregion
        
        #region Parameter MessageDeduplicationId
        /// <summary>
        /// <para>
        /// <para>This parameter applies only to FIFO (first-in-first-out) queues.</para><para>The token used for deduplication of sent messages. If a message with a particular
        /// <c>MessageDeduplicationId</c> is sent successfully, any messages sent with the same
        /// <c>MessageDeduplicationId</c> are accepted successfully but aren't delivered during
        /// the 5-minute deduplication interval. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues-exactly-once-processing.html">
        /// Exactly-once processing</a> in the <i>Amazon SQS Developer Guide</i>.</para><ul><li><para>Every message must have a unique <c>MessageDeduplicationId</c>,</para><ul><li><para>You may provide a <c>MessageDeduplicationId</c> explicitly.</para></li><li><para>If you aren't able to provide a <c>MessageDeduplicationId</c> and you enable <c>ContentBasedDeduplication</c>
        /// for your queue, Amazon SQS uses a SHA-256 hash to generate the <c>MessageDeduplicationId</c>
        /// using the body of the message (but not the attributes of the message). </para></li><li><para>If you don't provide a <c>MessageDeduplicationId</c> and the queue doesn't have <c>ContentBasedDeduplication</c>
        /// set, the action fails with an error.</para></li><li><para>If the queue has <c>ContentBasedDeduplication</c> set, your <c>MessageDeduplicationId</c>
        /// overrides the generated one.</para></li></ul></li><li><para>When <c>ContentBasedDeduplication</c> is in effect, messages with identical content
        /// sent within the deduplication interval are treated as duplicates and only one copy
        /// of the message is delivered.</para></li><li><para>If you send one message with <c>ContentBasedDeduplication</c> enabled and then another
        /// message with a <c>MessageDeduplicationId</c> that is the same as the one generated
        /// for the first <c>MessageDeduplicationId</c>, the two messages are treated as duplicates
        /// and only one copy of the message is delivered. </para></li></ul><note><para>The <c>MessageDeduplicationId</c> is available to the consumer of the message (this
        /// can be useful for troubleshooting delivery issues).</para><para>If a message is sent successfully but the acknowledgement is lost and the message
        /// is resent with the same <c>MessageDeduplicationId</c> after the deduplication interval,
        /// Amazon SQS can't detect duplicate messages.</para><para>Amazon SQS continues to keep track of the message deduplication ID even after the
        /// message is received and deleted.</para></note><para>The maximum length of <c>MessageDeduplicationId</c> is 128 characters. <c>MessageDeduplicationId</c>
        /// can contain alphanumeric characters (<c>a-z</c>, <c>A-Z</c>, <c>0-9</c>) and punctuation
        /// (<c>!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~</c>).</para><para>For best practices of using <c>MessageDeduplicationId</c>, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/using-messagededuplicationid-property.html">Using
        /// the MessageDeduplicationId Property</a> in the <i>Amazon SQS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageDeduplicationId { get; set; }
        #endregion
        
        #region Parameter MessageGroupId
        /// <summary>
        /// <para>
        /// <para>This parameter applies only to FIFO (first-in-first-out) queues.</para><para>The tag that specifies that a message belongs to a specific message group. Messages
        /// that belong to the same message group are processed in a FIFO manner (however, messages
        /// in different message groups might be processed out of order). To interleave multiple
        /// ordered streams within a single queue, use <c>MessageGroupId</c> values (for example,
        /// session data for multiple users). In this scenario, multiple consumers can process
        /// the queue, but the session data of each user is processed in a FIFO fashion.</para><ul><li><para>You must associate a non-empty <c>MessageGroupId</c> with a message. If you don't
        /// provide a <c>MessageGroupId</c>, the action fails.</para></li><li><para><c>ReceiveMessage</c> might return messages with multiple <c>MessageGroupId</c> values.
        /// For each <c>MessageGroupId</c>, the messages are sorted by time sent. The caller can't
        /// specify a <c>MessageGroupId</c>.</para></li></ul><para>The maximum length of <c>MessageGroupId</c> is 128 characters. Valid values: alphanumeric
        /// characters and punctuation <c>(!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~)</c>.</para><para>For best practices of using <c>MessageGroupId</c>, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/using-messagegroupid-property.html">Using
        /// the MessageGroupId Property</a> in the <i>Amazon SQS Developer Guide</i>.</para><important><para><c>MessageGroupId</c> is required for FIFO queues. You can't use it for Standard
        /// queues.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageGroupId { get; set; }
        #endregion
        
        #region Parameter MessageSystemAttribute
        /// <summary>
        /// <para>
        /// <para>The message system attribute to send. Each message system attribute consists of a
        /// <c>Name</c>, <c>Type</c>, and <c>Value</c>.</para><important><ul><li><para>Currently, the only supported message system attribute is <c>AWSTraceHeader</c>. Its
        /// type must be <c>String</c> and its value must be a correctly formatted X-Ray trace
        /// header string.</para></li><li><para>The size of a message system attribute doesn't count towards the total size of a message.</para></li></ul></important><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageSystemAttributes")]
        public System.Collections.Hashtable MessageSystemAttribute { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to which a message is sent.</para><para>Queue URLs and names are case-sensitive.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.SendMessageResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.SendMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MessageDeduplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SQSMessage (SendMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.SendMessageResponse, SendSQSMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DelayInSeconds = this.DelayInSeconds;
            if (this.MessageAttribute != null)
            {
                context.MessageAttribute = new Dictionary<System.String, Amazon.SQS.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageAttribute.Keys)
                {
                    context.MessageAttribute.Add((String)hashKey, (Amazon.SQS.Model.MessageAttributeValue)(this.MessageAttribute[hashKey]));
                }
            }
            context.MessageBody = this.MessageBody;
            #if MODULAR
            if (this.MessageBody == null && ParameterWasBound(nameof(this.MessageBody)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageDeduplicationId = this.MessageDeduplicationId;
            context.MessageGroupId = this.MessageGroupId;
            if (this.MessageSystemAttribute != null)
            {
                context.MessageSystemAttribute = new Dictionary<System.String, Amazon.SQS.Model.MessageSystemAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageSystemAttribute.Keys)
                {
                    context.MessageSystemAttribute.Add((String)hashKey, (Amazon.SQS.Model.MessageSystemAttributeValue)(this.MessageSystemAttribute[hashKey]));
                }
            }
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
            var request = new Amazon.SQS.Model.SendMessageRequest();
            
            if (cmdletContext.DelayInSeconds != null)
            {
                request.DelaySeconds = cmdletContext.DelayInSeconds.Value;
            }
            if (cmdletContext.MessageAttribute != null)
            {
                request.MessageAttributes = cmdletContext.MessageAttribute;
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
            if (cmdletContext.MessageSystemAttribute != null)
            {
                request.MessageSystemAttributes = cmdletContext.MessageSystemAttribute;
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
        
        private Amazon.SQS.Model.SendMessageResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.SendMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "SendMessage");
            try
            {
                return client.SendMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.SQS.Model.MessageAttributeValue> MessageAttribute { get; set; }
            public System.String MessageBody { get; set; }
            public System.String MessageDeduplicationId { get; set; }
            public System.String MessageGroupId { get; set; }
            public Dictionary<System.String, Amazon.SQS.Model.MessageSystemAttributeValue> MessageSystemAttribute { get; set; }
            public System.String QueueUrl { get; set; }
            public System.Func<Amazon.SQS.Model.SendMessageResponse, SendSQSMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
