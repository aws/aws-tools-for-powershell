/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a new standard or FIFO queue. You can pass one or more attributes in the request.
    /// Keep the following caveats in mind:
    /// 
    ///  <ul><li><para>
    /// If you don't specify the <code>FifoQueue</code> attribute, Amazon SQS creates a standard
    /// queue.
    /// </para><note><para>
    ///  You can't change the queue type after you create it and you can't convert an existing
    /// standard queue into a FIFO queue. You must either create a new FIFO queue for your
    /// application or delete your existing standard queue and recreate it as a FIFO queue.
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html#FIFO-queues-moving">
    /// Moving From a Standard Queue to a FIFO Queue</a> in the <i>Amazon Simple Queue Service
    /// Developer Guide</i>. 
    /// </para></note></li><li><para>
    /// If you don't provide a value for an attribute, the queue is created with the default
    /// value for the attribute.
    /// </para></li><li><para>
    /// If you delete a queue, you must wait at least 60 seconds before creating a queue with
    /// the same name.
    /// </para></li></ul><para>
    /// To successfully create a new queue, you must provide a queue name that adheres to
    /// the <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/limits-queues.html">limits
    /// related to queues</a> and is unique within the scope of your queues.
    /// </para><para>
    /// To get the queue URL, use the <code><a>GetQueueUrl</a></code> action. <code><a>GetQueueUrl</a></code> requires only the <code>QueueName</code> parameter. be aware of existing queue
    /// names:
    /// </para><ul><li><para>
    /// If you provide the name of an existing queue along with the exact names and values
    /// of all the queue's attributes, <code>CreateQueue</code> returns the queue URL for
    /// the existing queue.
    /// </para></li><li><para>
    /// If the queue name, attribute names, or attribute values don't match an existing queue,
    /// <code>CreateQueue</code> returns an error.
    /// </para></li></ul><note><para>
    /// Some actions take lists of parameters. These lists are specified using the <code>param.n</code>
    /// notation. Values of <code>n</code> are integers starting from 1. For example, a parameter
    /// list with two elements looks like this:
    /// </para><para><code>&amp;Attribute.1=this</code></para><para><code>&amp;Attribute.2=that</code></para></note>
    /// </summary>
    [Cmdlet("New", "SQSQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service CreateQueue API operation.", Operation = new[] {"CreateQueue"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SQS.Model.CreateQueueResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSQSQueueCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of attributes with their corresponding values.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that the <code>CreateQueue</code> action uses:</para><ul><li><para><code>DelaySeconds</code> - The length of time, in seconds, for which the delivery
        /// of all messages in the queue is delayed. Valid values: An integer from 0 to 900 seconds
        /// (15 minutes). The default is 0 (zero). </para></li><li><para><code>MaximumMessageSize</code> - The limit of how many bytes a message can contain
        /// before Amazon SQS rejects it. Valid values: An integer from 1,024 bytes (1 KiB) to
        /// 262,144 bytes (256 KiB). The default is 262,144 (256 KiB). </para></li><li><para><code>MessageRetentionPeriod</code> - The length of time, in seconds, for which Amazon
        /// SQS retains a message. Valid values: An integer from 60 seconds (1 minute) to 1,209,600
        /// seconds (14 days). The default is 345,600 (4 days). </para></li><li><para><code>Policy</code> - The queue's policy. A valid AWS policy. For more information
        /// about policy structure, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/PoliciesOverview.html">Overview
        /// of AWS IAM Policies</a> in the <i>Amazon IAM User Guide</i>. </para></li><li><para><code>ReceiveMessageWaitTimeSeconds</code> - The length of time, in seconds, for
        /// which a <code><a>ReceiveMessage</a></code> action waits for a message to arrive.
        /// Valid values: An integer from 0 to 20 (seconds). The default is 0 (zero). </para></li><li><para><code>RedrivePolicy</code> - The string that includes the parameters for the dead-letter
        /// queue functionality of the source queue. For more information about the redrive policy
        /// and dead-letter queues, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">Using
        /// Amazon SQS Dead-Letter Queues</a> in the <i>Amazon Simple Queue Service Developer
        /// Guide</i>. </para><ul><li><para><code>deadLetterTargetArn</code> - The Amazon Resource Name (ARN) of the dead-letter
        /// queue to which Amazon SQS moves messages after the value of <code>maxReceiveCount</code>
        /// is exceeded.</para></li><li><para><code>maxReceiveCount</code> - The number of times a message is delivered to the
        /// source queue before being moved to the dead-letter queue.</para></li></ul><note><para>The dead-letter queue of a FIFO queue must also be a FIFO queue. Similarly, the dead-letter
        /// queue of a standard queue must also be a standard queue.</para></note></li><li><para><code>VisibilityTimeout</code> - The visibility timeout for the queue. Valid values:
        /// An integer from 0 to 43,200 (12 hours). The default is 30. For more information about
        /// the visibility timeout, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
        /// Timeout</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.</para></li></ul><para>The following attributes apply only to <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html">server-side-encryption</a>:</para><ul><li><para><code>KmsMasterKeyId</code> - The ID of an AWS-managed customer master key (CMK)
        /// for Amazon SQS or a custom CMK. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-sse-key-terms">Key
        /// Terms</a>. While the alias of the AWS-managed CMK for Amazon SQS is always <code>alias/aws/sqs</code>,
        /// the alias of a custom CMK can, for example, be <code>alias/<i>MyAlias</i></code>.
        /// For more examples, see <a href="http://docs.aws.amazon.com/kms/latest/APIReference/API_DescribeKey.html#API_DescribeKey_RequestParameters">KeyId</a>
        /// in the <i>AWS Key Management Service API Reference</i>. </para></li><li><para><code>KmsDataKeyReusePeriodSeconds</code> - The length of time, in seconds, for which
        /// Amazon SQS can reuse a <a href="http://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#data-keys">data
        /// key</a> to encrypt or decrypt messages before calling AWS KMS again. An integer representing
        /// seconds, between 60 seconds (1 minute) and 86,400 seconds (24 hours). The default
        /// is 300 (5 minutes). A shorter time period provides better security but results in
        /// more calls to KMS which might incur charges after Free Tier. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-how-does-the-data-key-reuse-period-work">How
        /// Does the Data Key Reuse Period Work?</a>. </para></li></ul><para>The following attributes apply only to <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO
        /// (first-in-first-out) queues</a>:</para><ul><li><para><code>FifoQueue</code> - Designates a queue as FIFO. Valid values: <code>true</code>,
        /// <code>false</code>. You can provide this attribute only during queue creation. You
        /// can't change it for an existing queue. When you set this attribute, you must also
        /// provide the <code>MessageGroupId</code> for your messages explicitly.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html#FIFO-queues-understanding-logic">FIFO
        /// Queue Logic</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.</para></li><li><para><code>ContentBasedDeduplication</code> - Enables content-based deduplication. Valid
        /// values: <code>true</code>, <code>false</code>. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html#FIFO-queues-exactly-once-processing">Exactly-Once
        /// Processing</a> in the <i>Amazon Simple Queue Service Developer Guide</i>. </para><ul><li><para>Every message must have a unique <code>MessageDeduplicationId</code>,</para><ul><li><para>You may provide a <code>MessageDeduplicationId</code> explicitly.</para></li><li><para>If you aren't able to provide a <code>MessageDeduplicationId</code> and you enable
        /// <code>ContentBasedDeduplication</code> for your queue, Amazon SQS uses a SHA-256 hash
        /// to generate the <code>MessageDeduplicationId</code> using the body of the message
        /// (but not the attributes of the message). </para></li><li><para>If you don't provide a <code>MessageDeduplicationId</code> and the queue doesn't have
        /// <code>ContentBasedDeduplication</code> set, the action fails with an error.</para></li><li><para>If the queue has <code>ContentBasedDeduplication</code> set, your <code>MessageDeduplicationId</code>
        /// overrides the generated one.</para></li></ul></li><li><para>When <code>ContentBasedDeduplication</code> is in effect, messages with identical
        /// content sent within the deduplication interval are treated as duplicates and only
        /// one copy of the message is delivered.</para></li><li><para>If you send one message with <code>ContentBasedDeduplication</code> enabled and then
        /// another message with a <code>MessageDeduplicationId</code> that is the same as the
        /// one generated for the first <code>MessageDeduplicationId</code>, the two messages
        /// are treated as duplicates and only one copy of the message is delivered. </para></li></ul></li></ul><para>Any other valid special request parameters (such as the following) are ignored:</para><ul><li><para><code>ApproximateNumberOfMessages</code></para></li><li><para><code>ApproximateNumberOfMessagesDelayed</code></para></li><li><para><code>ApproximateNumberOfMessagesNotVisible</code></para></li><li><para><code>CreatedTimestamp</code></para></li><li><para><code>LastModifiedTimestamp</code></para></li><li><para><code>QueueArn</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter QueueName
        /// <summary>
        /// <para>
        /// <para>The name of the new queue. The following limits apply to this name:</para><ul><li><para>A queue name can have up to 80 characters.</para></li><li><para>Valid values: alphanumeric characters, hyphens (<code>-</code>), and underscores (<code>_</code>).</para></li><li><para>A FIFO queue name must end with the <code>.fifo</code> suffix.</para></li></ul><para>Queue names are case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("QueueName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SQSQueue (CreateQueue)"))
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
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.QueueName = this.QueueName;
            
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
            var request = new Amazon.SQS.Model.CreateQueueRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.QueueName != null)
            {
                request.QueueName = cmdletContext.QueueName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.QueueUrl;
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
        
        private Amazon.SQS.Model.CreateQueueResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.CreateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service", "CreateQueue");
            try
            {
                #if DESKTOP
                return client.CreateQueue(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateQueueAsync(request);
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
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.String QueueName { get; set; }
        }
        
    }
}
