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
    /// Gets attributes for the specified queue.
    /// 
    ///  <note><para>
    /// To determine whether a queue is <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO</a>,
    /// you can check whether <c>QueueName</c> ends with the <c>.fifo</c> suffix.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "SQSQueueAttribute")]
    [OutputType("Amazon.SQS.Model.GetQueueAttributesResponse")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service (SQS) GetQueueAttributes API operation.", Operation = new[] {"GetQueueAttributes"}, SelectReturnType = typeof(Amazon.SQS.Model.GetQueueAttributesResponse))]
    [AWSCmdletOutput("Amazon.SQS.Model.GetQueueAttributesResponse",
        "This cmdlet returns an Amazon.SQS.Model.GetQueueAttributesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSQSQueueAttributeCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A list of attributes for which to retrieve information.</para><para>The <c>AttributeNames</c> parameter is optional, but if you don't specify values for
        /// this parameter, the request returns empty results.</para><note><para>In the future, new attributes might be added. If you write code that calls this action,
        /// we recommend that you structure your code so that it can handle new attributes gracefully.</para></note><para>The following attributes are supported:</para><important><para>The <c>ApproximateNumberOfMessagesDelayed</c>, <c>ApproximateNumberOfMessagesNotVisible</c>,
        /// and <c>ApproximateNumberOfMessages</c> metrics may not achieve consistency until at
        /// least 1 minute after the producers stop sending messages. This period is required
        /// for the queue metadata to reach eventual consistency. </para></important><ul><li><para><c>All</c> – Returns all values. </para></li><li><para><c>ApproximateNumberOfMessages</c> – Returns the approximate number of messages available
        /// for retrieval from the queue.</para></li><li><para><c>ApproximateNumberOfMessagesDelayed</c> – Returns the approximate number of messages
        /// in the queue that are delayed and not available for reading immediately. This can
        /// happen when the queue is configured as a delay queue or when a message has been sent
        /// with a delay parameter.</para></li><li><para><c>ApproximateNumberOfMessagesNotVisible</c> – Returns the approximate number of
        /// messages that are in flight. Messages are considered to be <i>in flight</i> if they
        /// have been sent to a client but have not yet been deleted or have not yet reached the
        /// end of their visibility window. </para></li><li><para><c>CreatedTimestamp</c> – Returns the time when the queue was created in seconds
        /// (<a href="http://en.wikipedia.org/wiki/Unix_time">epoch time</a>).</para></li><li><para><c>DelaySeconds</c> – Returns the default delay on the queue in seconds.</para></li><li><para><c>LastModifiedTimestamp</c> – Returns the time when the queue was last changed in
        /// seconds (<a href="http://en.wikipedia.org/wiki/Unix_time">epoch time</a>).</para></li><li><para><c>MaximumMessageSize</c> – Returns the limit of how many bytes a message can contain
        /// before Amazon SQS rejects it.</para></li><li><para><c>MessageRetentionPeriod</c> – Returns the length of time, in seconds, for which
        /// Amazon SQS retains a message. When you change a queue's attributes, the change can
        /// take up to 60 seconds for most of the attributes to propagate throughout the Amazon
        /// SQS system. Changes made to the <c>MessageRetentionPeriod</c> attribute can take up
        /// to 15 minutes and will impact existing messages in the queue potentially causing them
        /// to be expired and deleted if the <c>MessageRetentionPeriod</c> is reduced below the
        /// age of existing messages.</para></li><li><para><c>Policy</c> – Returns the policy of the queue.</para></li><li><para><c>QueueArn</c> – Returns the Amazon resource name (ARN) of the queue.</para></li><li><para><c>ReceiveMessageWaitTimeSeconds</c> – Returns the length of time, in seconds, for
        /// which the <c>ReceiveMessage</c> action waits for a message to arrive. </para></li><li><para><c>VisibilityTimeout</c> – Returns the visibility timeout for the queue. For more
        /// information about the visibility timeout, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
        /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>. </para></li></ul><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">dead-letter
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
        /// queue of a standard queue must also be a standard queue.</para></note><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html">server-side-encryption</a>:</para><ul><li><para><c>KmsMasterKeyId</c> – Returns the ID of an Amazon Web Services managed customer
        /// master key (CMK) for Amazon SQS or a custom CMK. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-sse-key-terms">Key
        /// Terms</a>. </para></li><li><para><c>KmsDataKeyReusePeriodSeconds</c> – Returns the length of time, in seconds, for
        /// which Amazon SQS can reuse a data key to encrypt or decrypt messages before calling
        /// KMS again. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-how-does-the-data-key-reuse-period-work">How
        /// Does the Data Key Reuse Period Work?</a>. </para></li><li><para><c>SqsManagedSseEnabled</c> – Returns information about whether the queue is using
        /// SSE-SQS encryption using SQS owned encryption keys. Only one server-side encryption
        /// option is supported per queue (for example, <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-configure-sse-existing-queue.html">SSE-KMS</a>
        /// or <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-configure-sqs-sse-queue.html">SSE-SQS</a>).</para></li></ul><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO
        /// (first-in-first-out) queues</a>:</para><ul><li><para><c>FifoQueue</c> – Returns information about whether the queue is FIFO. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues-understanding-logic.html">FIFO
        /// queue logic</a> in the <i>Amazon SQS Developer Guide</i>.</para><note><para>To determine whether a queue is <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO</a>,
        /// you can check whether <c>QueueName</c> ends with the <c>.fifo</c> suffix.</para></note></li><li><para><c>ContentBasedDeduplication</c> – Returns whether content-based deduplication is
        /// enabled for the queue. For more information, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues-exactly-once-processing.html">Exactly-once
        /// processing</a> in the <i>Amazon SQS Developer Guide</i>. </para></li></ul><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/high-throughput-fifo.html">high
        /// throughput for FIFO queues</a>:</para><ul><li><para><c>DeduplicationScope</c> – Specifies whether message deduplication occurs at the
        /// message group or queue level. Valid values are <c>messageGroup</c> and <c>queue</c>.</para></li><li><para><c>FifoThroughputLimit</c> – Specifies whether the FIFO queue throughput quota applies
        /// to the entire queue or per message group. Valid values are <c>perQueue</c> and <c>perMessageGroupId</c>.
        /// The <c>perMessageGroupId</c> value is allowed only when the value for <c>DeduplicationScope</c>
        /// is <c>messageGroup</c>.</para></li></ul><para>To enable high throughput for FIFO queues, do the following:</para><ul><li><para>Set <c>DeduplicationScope</c> to <c>messageGroup</c>.</para></li><li><para>Set <c>FifoThroughputLimit</c> to <c>perMessageGroupId</c>.</para></li></ul><para>If you set these attributes to anything other than the values shown for enabling high
        /// throughput, normal throughput is in effect and deduplication occurs as specified.</para><para>For information on throughput quotas, see <a href="https://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/quotas-messages.html">Quotas
        /// related to messages</a> in the <i>Amazon SQS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue whose attribute information is retrieved.</para><para>Queue URLs and names are case-sensitive.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SQS.Model.GetQueueAttributesResponse).
        /// Specifying the name of a property of type Amazon.SQS.Model.GetQueueAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SQS.Model.GetQueueAttributesResponse, GetSQSQueueAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AttributeName != null)
            {
                context.AttributeName = new List<System.String>(this.AttributeName);
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
            var request = new Amazon.SQS.Model.GetQueueAttributesRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeNames = cmdletContext.AttributeName;
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
        
        private Amazon.SQS.Model.GetQueueAttributesResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.GetQueueAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service (SQS)", "GetQueueAttributes");
            try
            {
                #if DESKTOP
                return client.GetQueueAttributes(request);
                #elif CORECLR
                return client.GetQueueAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String QueueUrl { get; set; }
            public System.Func<Amazon.SQS.Model.GetQueueAttributesResponse, GetSQSQueueAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
