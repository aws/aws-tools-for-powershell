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
    /// Sets the value of one or more queue attributes. When you change a queue's attributes,
    /// the change can take up to 60 seconds for most of the attributes to propagate throughout
    /// the SQS system. Changes made to the <code>MessageRetentionPeriod</code> attribute
    /// can take up to 15 minutes.
    /// 
    ///  <note><para>
    /// In the future, new attributes might be added. When you write code that calls this
    /// action, we recommend structuring your code so that it can handle new attributes gracefully.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "SQSQueueAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetQueueAttributes operation against Amazon Simple Queue Service.", Operation = new[] {"SetQueueAttributes"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the QueueUrl parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SQS.Model.SetQueueAttributesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetSQSQueueAttributeCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of attributes to set.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that the <code>SetQueueAttributes</code> action uses:</para><ul><li><para><code>DelaySeconds</code> - The number of seconds for which the delivery of all messages
        /// in the queue is delayed. An integer from 0 to 900 (15 minutes). The default is 0 (zero).
        /// </para></li><li><para><code>MaximumMessageSize</code> - The limit of how many bytes a message can contain
        /// before Amazon SQS rejects it. An integer from 1,024 bytes (1 KiB) up to 262,144 bytes
        /// (256 KiB). The default is 262,144 (256 KiB). </para></li><li><para><code>MessageRetentionPeriod</code> - The number of seconds for which Amazon SQS
        /// retains a message. An integer representing seconds, from 60 (1 minute) to 120,9600
        /// (14 days). The default is 345,600 (4 days). </para></li><li><para><code>Policy</code> - The queue's policy. A valid AWS policy. For more information
        /// about policy structure, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/PoliciesOverview.html">Overview
        /// of AWS IAM Policies</a> in the <i>Amazon IAM User Guide</i>. </para></li><li><para><code>ReceiveMessageWaitTimeSeconds</code> - The number of seconds for which a <a>ReceiveMessage</a>
        /// action will wait for a message to arrive. An integer from 0 to 20 (seconds). The default
        /// is 0. </para></li><li><para><code>RedrivePolicy</code> - The parameters for the dead letter queue functionality
        /// of the source queue. For more information about the redrive policy and dead letter
        /// queues, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-dead-letter-queues.html">Using
        /// Amazon SQS Dead Letter Queues</a> in the <i>Amazon SQS Developer Guide</i>. </para><note><para>The dead letter queue of a FIFO queue must also be a FIFO queue. Similarly, the dead
        /// letter queue of a standard queue must also be a standard queue.</para></note></li><li><para><code>VisibilityTimeout</code> - The visibility timeout for the queue. An integer
        /// from 0 to 43200 (12 hours). The default is 30. For more information about the visibility
        /// timeout, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/sqs-visibility-timeout.html">Visibility
        /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.</para></li></ul><para>The following attribute applies only to <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html">FIFO
        /// (first-in-first-out) queues</a>:</para><ul><li><para><code>ContentBasedDeduplication</code> - Enables content-based deduplication. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/FIFO-queues.html#FIFO-queues-exactly-once-processing">Exactly-Once
        /// Processing</a> in the <i>Amazon SQS Developer Guide</i>. </para><ul><li><para>Every message must have a unique <code>MessageDeduplicationId</code>,</para><ul><li><para>You may provide a <code>MessageDeduplicationId</code> explicitly.</para></li><li><para>If you aren't able to provide a <code>MessageDeduplicationId</code> and you enable
        /// <code>ContentBasedDeduplication</code> for your queue, Amazon SQS uses a SHA-256 hash
        /// to generate the <code>MessageDeduplicationId</code> using the body of the message
        /// (but not the attributes of the message). </para></li><li><para>If you don't provide a <code>MessageDeduplicationId</code> and the queue doesn't have
        /// <code>ContentBasedDeduplication</code> set, the action fails with an error.</para></li><li><para>If the queue has <code>ContentBasedDeduplication</code> set, your <code>MessageDeduplicationId</code>
        /// overrides the generated one.</para></li></ul></li><li><para>When <code>ContentBasedDeduplication</code> is in effect, messages with identical
        /// content sent within the deduplication interval are treated as duplicates and only
        /// one copy of the message is delivered.</para></li><li><para>You can also use <code>ContentBasedDeduplication</code> for messages with identical
        /// content to be treated as duplicates.</para></li><li><para>If you send one message with <code>ContentBasedDeduplication</code> enabled and then
        /// another message with a <code>MessageDeduplicationId</code> that is the same as the
        /// one generated for the first <code>MessageDeduplicationId</code>, the two messages
        /// are treated as duplicates and only one copy of the message is delivered. </para></li></ul></li></ul><para>Any other valid special request parameters that are specified (such as <code>ApproximateNumberOfMessages</code>,
        /// <code>ApproximateNumberOfMessagesDelayed</code>, <code>ApproximateNumberOfMessagesNotVisible</code>,
        /// <code>CreatedTimestamp</code>, <code>LastModifiedTimestamp</code>, and <code>QueueArn</code>)
        /// will be ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
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
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the QueueUrl parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SQSQueueAttribute (SetQueueAttributes)"))
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
            var request = new Amazon.SQS.Model.SetQueueAttributesRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
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
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.QueueUrl;
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
        
        private static Amazon.SQS.Model.SetQueueAttributesResponse CallAWSServiceOperation(IAmazonSQS client, Amazon.SQS.Model.SetQueueAttributesRequest request)
        {
            #if DESKTOP
            return client.SetQueueAttributes(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SetQueueAttributesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
