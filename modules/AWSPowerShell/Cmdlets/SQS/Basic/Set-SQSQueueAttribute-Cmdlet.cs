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
    /// Sets the value of one or more queue attributes, like a policy. When you change a queue's
    /// attributes, the change can take up to 60 seconds for most of the attributes to propagate
    /// throughout the Amazon SQS system. Changes made to the <c>MessageRetentionPeriod</c>
    /// attribute can take up to 15 minutes and will impact existing messages in the queue
    /// potentially causing them to be expired and deleted if the <c>MessageRetentionPeriod</c>
    /// is reduced below the age of existing messages.
    /// 
    ///  <note><ul><li><para>
    /// In the future, new attributes might be added. If you write code that calls this action,
    /// we recommend that you structure your code so that it can handle new attributes gracefully.
    /// </para></li><li><para>
    /// Cross-account permissions don't apply to this action. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-customer-managed-policy-examples.html#grant-cross-account-permissions-to-role-and-user-name">Grant
    /// cross-account permissions to a role and a username</a> in the <i>Amazon SQS Developer
    /// Guide</i>.
    /// </para></li><li><para>
    /// To remove the ability to change queue permissions, you must deny permission to the
    /// <c>AddPermission</c>, <c>RemovePermission</c>, and <c>SetQueueAttributes</c> actions
    /// in your IAM policy.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Set", "SQSQueueAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) SetQueueAttributes API operation.", Operation = new[] {"SetQueueAttributes"}, SelectReturnType = typeof(Amazon.SQS.Model.SetQueueAttributesResponse))]
    [AWSCmdletOutput("None or Amazon.SQS.Model.SetQueueAttributesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SQS.Model.SetQueueAttributesResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetSQSQueueAttributeCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of attributes to set.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that the <c>SetQueueAttributes</c> action uses:</para><ul><li><para><c>DelaySeconds</c> – The length of time, in seconds, for which the delivery of all
        /// messages in the queue is delayed. Valid values: An integer from 0 to 900 (15 minutes).
        /// Default: 0. </para></li><li><para><c>MaximumMessageSize</c> – The limit of how many bytes a message can contain before
        /// Amazon SQS rejects it. Valid values: An integer from 1,024 bytes (1 KiB) up to 1,048,576
        /// bytes (1 MiB). Default: 1,048,576 bytes (1 MiB). </para></li><li><para><c>MessageRetentionPeriod</c> – The length of time, in seconds, for which Amazon
        /// SQS retains a message. Valid values: An integer representing seconds, from 60 (1 minute)
        /// to 1,209,600 (14 days). Default: 345,600 (4 days). When you change a queue's attributes,
        /// the change can take up to 60 seconds for most of the attributes to propagate throughout
        /// the Amazon SQS system. Changes made to the <c>MessageRetentionPeriod</c> attribute
        /// can take up to 15 minutes and will impact existing messages in the queue potentially
        /// causing them to be expired and deleted if the <c>MessageRetentionPeriod</c> is reduced
        /// below the age of existing messages.</para></li><li><para><c>Policy</c> – The queue's policy. A valid Amazon Web Services policy. For more
        /// information about policy structure, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/PoliciesOverview.html">Overview
        /// of Amazon Web Services IAM Policies</a> in the <i>Identity and Access Management User
        /// Guide</i>. </para></li><li><para><c>ReceiveMessageWaitTimeSeconds</c> – The length of time, in seconds, for which
        /// a <c><a>ReceiveMessage</a></c> action waits for a message to arrive. Valid values:
        /// An integer from 0 to 20 (seconds). Default: 0. </para></li><li><para><c>VisibilityTimeout</c> – The visibility timeout for the queue, in seconds. Valid
        /// values: An integer from 0 to 43,200 (12 hours). Default: 30. For more information
        /// about the visibility timeout, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
        /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.</para></li></ul><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">dead-letter
        /// queues:</a></para><ul><li><para><c>RedrivePolicy</c> – The string that includes the parameters for the dead-letter
        /// queue functionality of the source queue as a JSON object. The parameters are as follows:</para><ul><li><para><c>deadLetterTargetArn</c> – The Amazon Resource Name (ARN) of the dead-letter queue
        /// to which Amazon SQS moves messages after the value of <c>maxReceiveCount</c> is exceeded.</para></li><li><para><c>maxReceiveCount</c> – The number of times a message is delivered to the source
        /// queue before being moved to the dead-letter queue. Default: 10. When the <c>ReceiveCount</c>
        /// for a message exceeds the <c>maxReceiveCount</c> for a queue, Amazon SQS moves the
        /// message to the dead-letter-queue.</para></li></ul></li><li><para><c>RedriveAllowPolicy</c> – The string that includes the parameters for the permissions
        /// for the dead-letter queue redrive permission and which source queues can specify dead-letter
        /// queues as a JSON object. The parameters are as follows:</para><ul><li><para><c>redrivePermission</c> – The permission type that defines which source queues can
        /// specify the current queue as the dead-letter queue. Valid values are:</para><ul><li><para><c>allowAll</c> – (Default) Any source queues in this Amazon Web Services account
        /// in the same Region can specify this queue as the dead-letter queue.</para></li><li><para><c>denyAll</c> – No source queues can specify this queue as the dead-letter queue.</para></li><li><para><c>byQueue</c> – Only queues specified by the <c>sourceQueueArns</c> parameter can
        /// specify this queue as the dead-letter queue.</para></li></ul></li><li><para><c>sourceQueueArns</c> – The Amazon Resource Names (ARN)s of the source queues that
        /// can specify this queue as the dead-letter queue and redrive messages. You can specify
        /// this parameter only when the <c>redrivePermission</c> parameter is set to <c>byQueue</c>.
        /// You can specify up to 10 source queue ARNs. To allow more than 10 source queues to
        /// specify dead-letter queues, set the <c>redrivePermission</c> parameter to <c>allowAll</c>.</para></li></ul></li></ul><note><para>The dead-letter queue of a FIFO queue must also be a FIFO queue. Similarly, the dead-letter
        /// queue of a standard queue must also be a standard queue.</para></note><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html">server-side-encryption</a>:</para><ul><li><para><c>KmsMasterKeyId</c> – The ID of an Amazon Web Services managed customer master
        /// key (CMK) for Amazon SQS or a custom CMK. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-sse-key-terms">Key
        /// Terms</a>. While the alias of the AWS-managed CMK for Amazon SQS is always <c>alias/aws/sqs</c>,
        /// the alias of a custom CMK can, for example, be <c>alias/<i>MyAlias</i></c>. For more
        /// examples, see <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_DescribeKey.html#API_DescribeKey_RequestParameters">KeyId</a>
        /// in the <i>Key Management Service API Reference</i>. </para></li><li><para><c>KmsDataKeyReusePeriodSeconds</c> – The length of time, in seconds, for which Amazon
        /// SQS can reuse a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#data-keys">data
        /// key</a> to encrypt or decrypt messages before calling KMS again. An integer representing
        /// seconds, between 60 seconds (1 minute) and 86,400 seconds (24 hours). Default: 300
        /// (5 minutes). A shorter time period provides better security but results in more calls
        /// to KMS which might incur charges after Free Tier. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-how-does-the-data-key-reuse-period-work">How
        /// Does the Data Key Reuse Period Work?</a>. </para></li><li><para><c>SqsManagedSseEnabled</c> – Enables server-side queue encryption using SQS owned
        /// encryption keys. Only one server-side encryption option is supported per queue (for
        /// example, <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-configure-sse-existing-queue.html">SSE-KMS</a>
        /// or <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-configure-sqs-sse-queue.html">SSE-SQS</a>).</para></li></ul><para>The following attribute applies only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO
        /// (first-in-first-out) queues</a>:</para><ul><li><para><c>ContentBasedDeduplication</c> – Enables content-based deduplication. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues-exactly-once-processing.html">Exactly-once
        /// processing</a> in the <i>Amazon SQS Developer Guide</i>. Note the following: </para><ul><li><para>Every message must have a unique <c>MessageDeduplicationId</c>.</para><ul><li><para>You may provide a <c>MessageDeduplicationId</c> explicitly.</para></li><li><para>If you aren't able to provide a <c>MessageDeduplicationId</c> and you enable <c>ContentBasedDeduplication</c>
        /// for your queue, Amazon SQS uses a SHA-256 hash to generate the <c>MessageDeduplicationId</c>
        /// using the body of the message (but not the attributes of the message). </para></li><li><para>If you don't provide a <c>MessageDeduplicationId</c> and the queue doesn't have <c>ContentBasedDeduplication</c>
        /// set, the action fails with an error.</para></li><li><para>If the queue has <c>ContentBasedDeduplication</c> set, your <c>MessageDeduplicationId</c>
        /// overrides the generated one.</para></li></ul></li><li><para>When <c>ContentBasedDeduplication</c> is in effect, messages with identical content
        /// sent within the deduplication interval are treated as duplicates and only one copy
        /// of the message is delivered.</para></li><li><para>If you send one message with <c>ContentBasedDeduplication</c> enabled and then another
        /// message with a <c>MessageDeduplicationId</c> that is the same as the one generated
        /// for the first <c>MessageDeduplicationId</c>, the two messages are treated as duplicates
        /// and only one copy of the message is delivered. </para></li></ul></li></ul><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/high-throughput-fifo.html">high
        /// throughput for FIFO queues</a>:</para><ul><li><para><c>DeduplicationScope</c> – Specifies whether message deduplication occurs at the
        /// message group or queue level. Valid values are <c>messageGroup</c> and <c>queue</c>.</para></li><li><para><c>FifoThroughputLimit</c> – Specifies whether the FIFO queue throughput quota applies
        /// to the entire queue or per message group. Valid values are <c>perQueue</c> and <c>perMessageGroupId</c>.
        /// The <c>perMessageGroupId</c> value is allowed only when the value for <c>DeduplicationScope</c>
        /// is <c>messageGroup</c>.</para></li></ul><para>To enable high throughput for FIFO queues, do the following:</para><ul><li><para>Set <c>DeduplicationScope</c> to <c>messageGroup</c>.</para></li><li><para>Set <c>FifoThroughputLimit</c> to <c>perMessageGroupId</c>.</para></li></ul><para>If you set these attributes to anything other than the values shown for enabling high
        /// throughput, normal throughput is in effect and deduplication occurs as specified.</para><para>For information on throughput quotas, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/quotas-messages.html">Quotas
        /// related to messages</a> in the <i>Amazon SQS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue whose attributes are set.</para><para>Queue URLs and names are case-sensitive.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.SetQueueAttributesResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SQSQueueAttribute (SetQueueAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.SetQueueAttributesResponse, SetSQSQueueAttributeCmdlet>(Select) ??
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
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            #if MODULAR
            if (this.Attribute == null && ParameterWasBound(nameof(this.Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SQS.Model.SetQueueAttributesRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
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
        
        private Amazon.SQS.Model.SetQueueAttributesResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.SetQueueAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "SetQueueAttributes");
            try
            {
                #if DESKTOP
                return client.SetQueueAttributes(request);
                #elif CORECLR
                return client.SetQueueAttributesAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String QueueUrl { get; set; }
            public System.Func<Amazon.SQS.Model.SetQueueAttributesResponse, SetSQSQueueAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
