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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Sends a message to an Amazon SNS topic, a text message (SMS message) directly to a
    /// phone number, or a message to a mobile platform endpoint (when you specify the <c>TargetArn</c>).
    /// 
    ///  
    /// <para>
    /// If you send a message to a topic, Amazon SNS delivers the message to each endpoint
    /// that is subscribed to the topic. The format of the message depends on the notification
    /// protocol for each subscribed endpoint.
    /// </para><para>
    /// When a <c>messageId</c> is returned, the message is saved and Amazon SNS immediately
    /// delivers it to subscribers.
    /// </para><para>
    /// To use the <c>Publish</c> action for publishing a message to a mobile endpoint, such
    /// as an app on a Kindle device or mobile phone, you must specify the EndpointArn for
    /// the TargetArn parameter. The EndpointArn is returned when making a call with the <c>CreatePlatformEndpoint</c>
    /// action. 
    /// </para><para>
    /// For more information about formatting messages, see <a href="https://docs.aws.amazon.com/sns/latest/dg/mobile-push-send-custommessage.html">Send
    /// Custom Platform-Specific Payloads in Messages to Mobile Devices</a>. 
    /// </para><important><para>
    /// You can publish messages only to topics and endpoints in the same Amazon Web Services
    /// Region.
    /// </para></important>
    /// </summary>
    [Cmdlet("Publish", "SNSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) Publish API operation.", Operation = new[] {"Publish"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.PublishResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleNotificationService.Model.PublishResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.PublishResponse) can be returned by specifying '-Select *'."
    )]
    public partial class PublishSNSMessageCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The message you want to send.</para><para>If you are publishing to a topic and you want to send the same message to all transport
        /// protocols, include the text of the message as a String value. If you want to send
        /// different messages for each transport protocol, set the value of the <c>MessageStructure</c>
        /// parameter to <c>json</c> and use a JSON object for the <c>Message</c> parameter. </para><para>Constraints:</para><ul><li><para>With the exception of SMS, messages must be UTF-8 encoded strings and at most 256
        /// KB in size (262,144 bytes, not 262,144 characters).</para></li><li><para>For SMS, each message can contain up to 140 characters. This character limit depends
        /// on the encoding schema. For example, an SMS message can contain 160 GSM characters,
        /// 140 ASCII characters, or 70 UCS-2 characters.</para><para>If you publish a message that exceeds this size limit, Amazon SNS sends the message
        /// as multiple messages, each fitting within the size limit. Messages aren't truncated
        /// mid-word but are cut off at whole-word boundaries.</para><para>The total size limit for a single SMS <c>Publish</c> action is 1,600 characters.</para></li></ul><para>JSON-specific constraints:</para><ul><li><para>Keys in the JSON object that correspond to supported transport protocols must have
        /// simple JSON string values.</para></li><li><para>The values will be parsed (unescaped) before they are used in outgoing messages.</para></li><li><para>Outbound notifications are JSON encoded (meaning that the characters will be reescaped
        /// for sending).</para></li><li><para>Values have a minimum length of 0 (the empty string, "", is allowed).</para></li><li><para>Values have a maximum length bounded by the overall message size (so, including multiple
        /// protocols may limit message sizes).</para></li><li><para>Non-string values will cause the key to be ignored.</para></li><li><para>Keys that do not correspond to supported transport protocols are ignored.</para></li><li><para>Duplicate keys are not allowed.</para></li><li><para>Failure to parse or validate any key or value in the message will cause the <c>Publish</c>
        /// call to return an error (no partial delivery).</para></li></ul>
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
        public System.String Message { get; set; }
        #endregion
        
        #region Parameter MessageAttribute
        /// <summary>
        /// <para>
        /// <para>Message attributes for Publish action.</para><para />
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
        
        #region Parameter MessageDeduplicationId
        /// <summary>
        /// <para>
        /// <ul><li><para>This parameter applies only to FIFO (first-in-first-out) topics. The <c>MessageDeduplicationId</c>
        /// can contain up to 128 alphanumeric characters <c>(a-z, A-Z, 0-9)</c> and punctuation
        /// <c>(!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~)</c>.</para></li><li><para>Every message must have a unique <c>MessageDeduplicationId</c>, which is a token used
        /// for deduplication of sent messages within the 5 minute minimum deduplication interval.</para></li><li><para>The scope of deduplication depends on the <c>FifoThroughputScope</c> attribute, when
        /// set to <c>Topic</c> the message deduplication scope is across the entire topic, when
        /// set to <c>MessageGroup</c> the message deduplication scope is within each individual
        /// message group.</para></li><li><para>If a message with a particular <c>MessageDeduplicationId</c> is sent successfully,
        /// subsequent messages within the deduplication scope and interval, with the same <c>MessageDeduplicationId</c>,
        /// are accepted successfully but aren't delivered.</para></li><li><para>Every message must have a unique <c>MessageDeduplicationId</c>:</para><ul><li><para>You may provide a <c>MessageDeduplicationId</c> explicitly.</para></li><li><para>If you aren't able to provide a <c>MessageDeduplicationId</c> and you enable <c>ContentBasedDeduplication</c>
        /// for your topic, Amazon SNS uses a SHA-256 hash to generate the <c>MessageDeduplicationId</c>
        /// using the body of the message (but not the attributes of the message).</para></li><li><para>If you don't provide a <c>MessageDeduplicationId</c> and the topic doesn't have <c>ContentBasedDeduplication</c>
        /// set, the action fails with an error.</para></li><li><para>If the topic has a <c>ContentBasedDeduplication</c> set, your <c>MessageDeduplicationId</c>
        /// overrides the generated one. </para></li></ul></li><li><para>When <c>ContentBasedDeduplication</c> is in effect, messages with identical content
        /// sent within the deduplication scope and interval are treated as duplicates and only
        /// one copy of the message is delivered.</para></li><li><para>If you send one message with <c>ContentBasedDeduplication</c> enabled, and then another
        /// message with a <c>MessageDeduplicationId</c> that is the same as the one generated
        /// for the first <c>MessageDeduplicationId</c>, the two messages are treated as duplicates,
        /// within the deduplication scope and interval, and only one copy of the message is delivered.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageDeduplicationId { get; set; }
        #endregion
        
        #region Parameter MessageGroupId
        /// <summary>
        /// <para>
        /// <para>The <c>MessageGroupId</c> can contain up to 128 alphanumeric characters <c>(a-z, A-Z,
        /// 0-9)</c> and punctuation <c>(!"#$%&amp;'()*+,-./:;&lt;=&gt;?@[\]^_`{|}~)</c>.</para><para> For FIFO topics: The <c>MessageGroupId</c> is a tag that specifies that a message
        /// belongs to a specific message group. Messages that belong to the same message group
        /// are processed in a FIFO manner (however, messages in different message groups might
        /// be processed out of order). Every message must include a <c>MessageGroupId</c>. </para><para> For standard topics: The <c>MessageGroupId</c> is optional and is forwarded only
        /// to Amazon SQS standard subscriptions to activate <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-fair-queues.html">fair
        /// queues</a>. The <c>MessageGroupId</c> is not used for, or sent to, any other endpoint
        /// types. When provided, the same validation rules apply as for FIFO topics. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageGroupId { get; set; }
        #endregion
        
        #region Parameter MessageStructure
        /// <summary>
        /// <para>
        /// <para>Set <c>MessageStructure</c> to <c>json</c> if you want to send a different message
        /// for each protocol. For example, using one publish action, you can send a short message
        /// to your SMS subscribers and a longer message to your email subscribers. If you set
        /// <c>MessageStructure</c> to <c>json</c>, the value of the <c>Message</c> parameter
        /// must: </para><ul><li><para>be a syntactically valid JSON object; and</para></li><li><para>contain at least a top-level JSON key of "default" with a value that is a string.</para></li></ul><para>You can define other top-level keys that define the message you want to send to a
        /// specific transport protocol (e.g., "http").</para><para>Valid value: <c>json</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String MessageStructure { get; set; }
        #endregion
        
        #region Parameter PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number to which you want to deliver an SMS message. Use E.164 format.</para><para>If you don't specify a value for the <c>PhoneNumber</c> parameter, you must specify
        /// a value for the <c>TargetArn</c> or <c>TopicArn</c> parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PhoneNumber { get; set; }
        #endregion
        
        #region Parameter Subject
        /// <summary>
        /// <para>
        /// <para>Optional parameter to be used as the "Subject" line when the message is delivered
        /// to email endpoints. This field will also be included, if present, in the standard
        /// JSON messages delivered to other endpoints.</para><para>Constraints: Subjects must be UTF-8 text with no line breaks or control characters,
        /// and less than 100 characters long.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String Subject { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>If you don't specify a value for the <c>TargetArn</c> parameter, you must specify
        /// a value for the <c>PhoneNumber</c> or <c>TopicArn</c> parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter TopicArn
        /// <summary>
        /// <para>
        /// <para>The topic you want to publish to.</para><para>If you don't specify a value for the <c>TopicArn</c> parameter, you must specify a
        /// value for the <c>PhoneNumber</c> or <c>TargetArn</c> parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.PublishResponse).
        /// Specifying the name of a property of type Amazon.SimpleNotificationService.Model.PublishResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TopicArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-SNSMessage (Publish)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.PublishResponse, PublishSNSMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Message = this.Message;
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MessageAttribute != null)
            {
                context.MessageAttribute = new Dictionary<System.String, Amazon.SimpleNotificationService.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageAttribute.Keys)
                {
                    context.MessageAttribute.Add((String)hashKey, (Amazon.SimpleNotificationService.Model.MessageAttributeValue)(this.MessageAttribute[hashKey]));
                }
            }
            context.MessageDeduplicationId = this.MessageDeduplicationId;
            context.MessageGroupId = this.MessageGroupId;
            context.MessageStructure = this.MessageStructure;
            context.PhoneNumber = this.PhoneNumber;
            context.Subject = this.Subject;
            context.TargetArn = this.TargetArn;
            context.TopicArn = this.TopicArn;
            
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
            var request = new Amazon.SimpleNotificationService.Model.PublishRequest();
            
            if (cmdletContext.Message != null)
            {
                request.Message = cmdletContext.Message;
            }
            if (cmdletContext.MessageAttribute != null)
            {
                request.MessageAttributes = cmdletContext.MessageAttribute;
            }
            if (cmdletContext.MessageDeduplicationId != null)
            {
                request.MessageDeduplicationId = cmdletContext.MessageDeduplicationId;
            }
            if (cmdletContext.MessageGroupId != null)
            {
                request.MessageGroupId = cmdletContext.MessageGroupId;
            }
            if (cmdletContext.MessageStructure != null)
            {
                request.MessageStructure = cmdletContext.MessageStructure;
            }
            if (cmdletContext.PhoneNumber != null)
            {
                request.PhoneNumber = cmdletContext.PhoneNumber;
            }
            if (cmdletContext.Subject != null)
            {
                request.Subject = cmdletContext.Subject;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
            }
            if (cmdletContext.TopicArn != null)
            {
                request.TopicArn = cmdletContext.TopicArn;
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
        
        private Amazon.SimpleNotificationService.Model.PublishResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.PublishRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "Publish");
            try
            {
                return client.PublishAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Message { get; set; }
            public Dictionary<System.String, Amazon.SimpleNotificationService.Model.MessageAttributeValue> MessageAttribute { get; set; }
            public System.String MessageDeduplicationId { get; set; }
            public System.String MessageGroupId { get; set; }
            public System.String MessageStructure { get; set; }
            public System.String PhoneNumber { get; set; }
            public System.String Subject { get; set; }
            public System.String TargetArn { get; set; }
            public System.String TopicArn { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.PublishResponse, PublishSNSMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
