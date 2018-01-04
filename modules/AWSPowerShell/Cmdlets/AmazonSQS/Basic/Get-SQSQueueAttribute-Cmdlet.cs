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
    /// Gets attributes for the specified queue.
    /// 
    ///  <note><para>
    /// To determine whether a queue is <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO</a>,
    /// you can check whether <code>QueueName</code> ends with the <code>.fifo</code> suffix.
    /// </para></note><note><para>
    /// Some actions take lists of parameters. These lists are specified using the <code>param.n</code>
    /// notation. Values of <code>n</code> are integers starting from 1. For example, a parameter
    /// list with two elements looks like this:
    /// </para><para><code>&amp;Attribute.1=this</code></para><para><code>&amp;Attribute.2=that</code></para></note>
    /// </summary>
    [Cmdlet("Get", "SQSQueueAttribute")]
    [OutputType("Amazon.SQS.Model.GetQueueAttributesResponse")]
    [AWSCmdlet("Calls the Amazon Simple Queue Service GetQueueAttributes API operation.", Operation = new[] {"GetQueueAttributes"})]
    [AWSCmdletOutput("Amazon.SQS.Model.GetQueueAttributesResponse",
        "This cmdlet returns a Amazon.SQS.Model.GetQueueAttributesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSQSQueueAttributeCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A list of attributes for which to retrieve information.</para><note><para>In the future, new attributes might be added. If you write code that calls this action,
        /// we recommend that you structure your code so that it can handle new attributes gracefully.</para></note><para>The following attributes are supported:</para><ul><li><para><code>All</code> - Returns all values. </para></li><li><para><code>ApproximateNumberOfMessages</code> - Returns the approximate number of visible
        /// messages in a queue. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-resources-required-process-messages.html">Resources
        /// Required to Process Messages</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.
        /// </para></li><li><para><code>ApproximateNumberOfMessagesDelayed</code> - Returns the approximate number
        /// of messages that are waiting to be added to the queue. </para></li><li><para><code>ApproximateNumberOfMessagesNotVisible</code> - Returns the approximate number
        /// of messages that have not timed-out and aren't deleted. For more information, see
        /// <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-resources-required-process-messages.html">Resources
        /// Required to Process Messages</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.
        /// </para></li><li><para><code>CreatedTimestamp</code> - Returns the time when the queue was created in seconds
        /// (<a href="http://en.wikipedia.org/wiki/Unix_time">epoch time</a>).</para></li><li><para><code>DelaySeconds</code> - Returns the default delay on the queue in seconds.</para></li><li><para><code>LastModifiedTimestamp</code> - Returns the time when the queue was last changed
        /// in seconds (<a href="http://en.wikipedia.org/wiki/Unix_time">epoch time</a>).</para></li><li><para><code>MaximumMessageSize</code> - Returns the limit of how many bytes a message can
        /// contain before Amazon SQS rejects it.</para></li><li><para><code>MessageRetentionPeriod</code> - Returns the length of time, in seconds, for
        /// which Amazon SQS retains a message.</para></li><li><para><code>Policy</code> - Returns the policy of the queue.</para></li><li><para><code>QueueArn</code> - Returns the Amazon resource name (ARN) of the queue.</para></li><li><para><code>ReceiveMessageWaitTimeSeconds</code> - Returns the length of time, in seconds,
        /// for which the <code>ReceiveMessage</code> action waits for a message to arrive. </para></li><li><para><code>RedrivePolicy</code> - Returns the string that includes the parameters for
        /// dead-letter queue functionality of the source queue. For more information about the
        /// redrive policy and dead-letter queues, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">Using
        /// Amazon SQS Dead-Letter Queues</a> in the <i>Amazon Simple Queue Service Developer
        /// Guide</i>. </para><ul><li><para><code>deadLetterTargetArn</code> - The Amazon Resource Name (ARN) of the dead-letter
        /// queue to which Amazon SQS moves messages after the value of <code>maxReceiveCount</code>
        /// is exceeded.</para></li><li><para><code>maxReceiveCount</code> - The number of times a message is delivered to the
        /// source queue before being moved to the dead-letter queue.</para></li></ul></li><li><para><code>VisibilityTimeout</code> - Returns the visibility timeout for the queue. For
        /// more information about the visibility timeout, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
        /// Timeout</a> in the <i>Amazon Simple Queue Service Developer Guide</i>. </para></li></ul><para>The following attributes apply only to <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html">server-side-encryption</a>:</para><ul><li><para><code>KmsMasterKeyId</code> - Returns the ID of an AWS-managed customer master key
        /// (CMK) for Amazon SQS or a custom CMK. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-sse-key-terms">Key
        /// Terms</a>. </para></li><li><para><code>KmsDataKeyReusePeriodSeconds</code> - Returns the length of time, in seconds,
        /// for which Amazon SQS can reuse a data key to encrypt or decrypt messages before calling
        /// AWS KMS again. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-server-side-encryption.html#sqs-how-does-the-data-key-reuse-period-work">How
        /// Does the Data Key Reuse Period Work?</a>. </para></li></ul><para>The following attributes apply only to <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO
        /// (first-in-first-out) queues</a>:</para><ul><li><para><code>FifoQueue</code> - Returns whether the queue is FIFO. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html#FIFO-queues-understanding-logic">FIFO
        /// Queue Logic</a> in the <i>Amazon Simple Queue Service Developer Guide</i>.</para><note><para>To determine whether a queue is <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO</a>,
        /// you can check whether <code>QueueName</code> ends with the <code>.fifo</code> suffix.</para></note></li><li><para><code>ContentBasedDeduplication</code> - Returns whether content-based deduplication
        /// is enabled for the queue. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html#FIFO-queues-exactly-once-processing">Exactly-Once
        /// Processing</a> in the <i>Amazon Simple Queue Service Developer Guide</i>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter QueueUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue whose attribute information is retrieved.</para><para>Queue URLs are case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueUrl { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
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
            var request = new Amazon.SQS.Model.GetQueueAttributesRequest();
            
            if (cmdletContext.AttributeNames != null)
            {
                request.AttributeNames = cmdletContext.AttributeNames;
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
        
        private Amazon.SQS.Model.GetQueueAttributesResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.GetQueueAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Queue Service", "GetQueueAttributes");
            try
            {
                #if DESKTOP
                return client.GetQueueAttributes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetQueueAttributesAsync(request);
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
            public List<System.String> AttributeNames { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
