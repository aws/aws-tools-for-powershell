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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Allows a topic owner to set an attribute of the topic to a new value.
    /// 
    ///  <note><para>
    /// To remove the ability to change topic permissions, you must deny permissions to the
    /// <c>AddPermission</c>, <c>RemovePermission</c>, and <c>SetTopicAttributes</c> actions
    /// in your IAM policy.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "SNSTopicAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) SetTopicAttributes API operation.", Operation = new[] {"SetTopicAttributes"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.SetTopicAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleNotificationService.Model.SetTopicAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleNotificationService.Model.SetTopicAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetSNSTopicAttributeCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A map of attributes with their corresponding values.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that the <c>SetTopicAttributes</c> action uses:</para><ul><li><para><c>ApplicationSuccessFeedbackRoleArn</c> – Indicates failed message delivery status
        /// for an Amazon SNS topic that is subscribed to a platform application endpoint.</para></li><li><para><c>DeliveryPolicy</c> – The policy that defines how Amazon SNS retries failed deliveries
        /// to HTTP/S endpoints.</para></li><li><para><c>DisplayName</c> – The display name to use for a topic with SMS subscriptions.</para></li><li><para><c>Policy</c> – The policy that defines who can access your topic. By default, only
        /// the topic owner can publish or subscribe to the topic.</para></li><li><para><c>TracingConfig</c> – Tracing mode of an Amazon SNS topic. By default <c>TracingConfig</c>
        /// is set to <c>PassThrough</c>, and the topic passes through the tracing header it receives
        /// from an Amazon SNS publisher to its subscriptions. If set to <c>Active</c>, Amazon
        /// SNS will vend X-Ray segment data to topic owner account if the sampled flag in the
        /// tracing header is true. This is only supported on standard topics.</para></li><li><para>HTTP</para><ul><li><para><c>HTTPSuccessFeedbackRoleArn</c> – Indicates successful message delivery status
        /// for an Amazon SNS topic that is subscribed to an HTTP endpoint. </para></li><li><para><c>HTTPSuccessFeedbackSampleRate</c> – Indicates percentage of successful messages
        /// to sample for an Amazon SNS topic that is subscribed to an HTTP endpoint.</para></li><li><para><c>HTTPFailureFeedbackRoleArn</c> – Indicates failed message delivery status for
        /// an Amazon SNS topic that is subscribed to an HTTP endpoint.</para></li></ul></li><li><para>Amazon Kinesis Data Firehose</para><ul><li><para><c>FirehoseSuccessFeedbackRoleArn</c> – Indicates successful message delivery status
        /// for an Amazon SNS topic that is subscribed to an Amazon Kinesis Data Firehose endpoint.</para></li><li><para><c>FirehoseSuccessFeedbackSampleRate</c> – Indicates percentage of successful messages
        /// to sample for an Amazon SNS topic that is subscribed to an Amazon Kinesis Data Firehose
        /// endpoint.</para></li><li><para><c>FirehoseFailureFeedbackRoleArn</c> – Indicates failed message delivery status
        /// for an Amazon SNS topic that is subscribed to an Amazon Kinesis Data Firehose endpoint.
        /// </para></li></ul></li><li><para>Lambda</para><ul><li><para><c>LambdaSuccessFeedbackRoleArn</c> – Indicates successful message delivery status
        /// for an Amazon SNS topic that is subscribed to an Lambda endpoint.</para></li><li><para><c>LambdaSuccessFeedbackSampleRate</c> – Indicates percentage of successful messages
        /// to sample for an Amazon SNS topic that is subscribed to an Lambda endpoint.</para></li><li><para><c>LambdaFailureFeedbackRoleArn</c> – Indicates failed message delivery status for
        /// an Amazon SNS topic that is subscribed to an Lambda endpoint. </para></li></ul></li><li><para>Platform application endpoint</para><ul><li><para><c>ApplicationSuccessFeedbackRoleArn</c> – Indicates successful message delivery
        /// status for an Amazon SNS topic that is subscribed to an Amazon Web Services application
        /// endpoint.</para></li><li><para><c>ApplicationSuccessFeedbackSampleRate</c> – Indicates percentage of successful
        /// messages to sample for an Amazon SNS topic that is subscribed to an Amazon Web Services
        /// application endpoint.</para></li><li><para><c>ApplicationFailureFeedbackRoleArn</c> – Indicates failed message delivery status
        /// for an Amazon SNS topic that is subscribed to an Amazon Web Services application endpoint.</para></li></ul><note><para>In addition to being able to configure topic attributes for message delivery status
        /// of notification messages sent to Amazon SNS application endpoints, you can also configure
        /// application attributes for the delivery status of push notification messages sent
        /// to push notification services.</para><para>For example, For more information, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-msg-status.html">Using
        /// Amazon SNS Application Attributes for Message Delivery Status</a>. </para></note></li><li><para>Amazon SQS</para><ul><li><para><c>SQSSuccessFeedbackRoleArn</c> – Indicates successful message delivery status for
        /// an Amazon SNS topic that is subscribed to an Amazon SQS endpoint. </para></li><li><para><c>SQSSuccessFeedbackSampleRate</c> – Indicates percentage of successful messages
        /// to sample for an Amazon SNS topic that is subscribed to an Amazon SQS endpoint. </para></li><li><para><c>SQSFailureFeedbackRoleArn</c> – Indicates failed message delivery status for an
        /// Amazon SNS topic that is subscribed to an Amazon SQS endpoint. </para></li></ul></li></ul><note><para>The &lt;ENDPOINT&gt;SuccessFeedbackRoleArn and &lt;ENDPOINT&gt;FailureFeedbackRoleArn
        /// attributes are used to give Amazon SNS write access to use CloudWatch Logs on your
        /// behalf. The &lt;ENDPOINT&gt;SuccessFeedbackSampleRate attribute is for specifying
        /// the sample rate percentage (0-100) of successfully delivered messages. After you configure
        /// the &lt;ENDPOINT&gt;FailureFeedbackRoleArn attribute, then all failed message deliveries
        /// generate CloudWatch Logs. </para></note><para>The following attribute applies only to <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-server-side-encryption.html">server-side-encryption</a>:</para><ul><li><para><c>KmsMasterKeyId</c> – The ID of an Amazon Web Services managed customer master
        /// key (CMK) for Amazon SNS or a custom CMK. For more information, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-server-side-encryption.html#sse-key-terms">Key
        /// Terms</a>. For more examples, see <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_DescribeKey.html#API_DescribeKey_RequestParameters">KeyId</a>
        /// in the <i>Key Management Service API Reference</i>. </para></li><li><para><c>SignatureVersion</c> – The signature version corresponds to the hashing algorithm
        /// used while creating the signature of the notifications, subscription confirmations,
        /// or unsubscribe confirmation messages sent by Amazon SNS. By default, <c>SignatureVersion</c>
        /// is set to <c>1</c>.</para></li></ul><para>The following attribute applies only to <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-fifo-topics.html">FIFO
        /// topics</a>:</para><ul><li><para><c>ArchivePolicy</c> – The policy that sets the retention period for messages stored
        /// in the message archive of an Amazon SNS FIFO topic.</para></li><li><para><c>ContentBasedDeduplication</c> – Enables content-based deduplication for FIFO topics.</para><ul><li><para>By default, <c>ContentBasedDeduplication</c> is set to <c>false</c>. If you create
        /// a FIFO topic and this attribute is <c>false</c>, you must specify a value for the
        /// <c>MessageDeduplicationId</c> parameter for the <a href="https://docs.aws.amazon.com/sns/latest/api/API_Publish.html">Publish</a>
        /// action. </para></li><li><para>When you set <c>ContentBasedDeduplication</c> to <c>true</c>, Amazon SNS uses a SHA-256
        /// hash to generate the <c>MessageDeduplicationId</c> using the body of the message (but
        /// not the attributes of the message).</para><para>(Optional) To override the generated value, you can specify a value for the <c>MessageDeduplicationId</c>
        /// parameter for the <c>Publish</c> action.</para></li></ul></li></ul>
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
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter AttributeValue
        /// <summary>
        /// <para>
        /// <para>The new value for the attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AttributeValue { get; set; }
        #endregion
        
        #region Parameter TopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the topic to modify.</para>
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
        public System.String TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.SetTopicAttributesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TopicArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TopicArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TopicArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TopicArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SNSTopicAttribute (SetTopicAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.SetTopicAttributesResponse, SetSNSTopicAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TopicArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AttributeName = this.AttributeName;
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttributeValue = this.AttributeValue;
            context.TopicArn = this.TopicArn;
            #if MODULAR
            if (this.TopicArn == null && ParameterWasBound(nameof(this.TopicArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleNotificationService.Model.SetTopicAttributesRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.AttributeValue != null)
            {
                request.AttributeValue = cmdletContext.AttributeValue;
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
        
        private Amazon.SimpleNotificationService.Model.SetTopicAttributesResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.SetTopicAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "SetTopicAttributes");
            try
            {
                #if DESKTOP
                return client.SetTopicAttributes(request);
                #elif CORECLR
                return client.SetTopicAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String AttributeName { get; set; }
            public System.String AttributeValue { get; set; }
            public System.String TopicArn { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.SetTopicAttributesResponse, SetSNSTopicAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
