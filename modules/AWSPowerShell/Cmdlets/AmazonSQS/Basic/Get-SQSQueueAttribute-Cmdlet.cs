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
    /// Gets attributes for the specified queue.
    /// 
    ///  <note><para>
    /// Some API actions take lists of parameters. These lists are specified using the <code>param.n</code>
    /// notation. Values of <code>n</code> are integers starting from 1. For example, a parameter
    /// list with two elements looks like this:
    /// </para></note><para><code><![CDATA[&amp;Attribute.1=this]]></code></para><para><code><![CDATA[&amp;Attribute.2=that]]></code></para>
    /// </summary>
    [Cmdlet("Get", "SQSQueueAttribute")]
    [OutputType("Amazon.SQS.Model.GetQueueAttributesResponse")]
    [AWSCmdlet("Invokes the GetQueueAttributes operation against Amazon Simple Queue Service.", Operation = new[] {"GetQueueAttributes"})]
    [AWSCmdletOutput("Amazon.SQS.Model.GetQueueAttributesResponse",
        "This cmdlet returns a Amazon.SQS.Model.GetQueueAttributesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetSQSQueueAttributeCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A list of attributes to retrieve information for. The following attributes are supported:</para><ul><li><para><code>All</code> - returns all values.</para></li><li><para><code>ApproximateNumberOfMessages</code> - returns the approximate number of visible
        /// messages in a queue. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/ApproximateNumber.html">Resources
        /// Required to Process Messages</a> in the <i>Amazon SQS Developer Guide</i>.</para></li><li><para><code>ApproximateNumberOfMessagesNotVisible</code> - returns the approximate number
        /// of messages that are not timed-out and not deleted. For more information, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/ApproximateNumber.html">Resources
        /// Required to Process Messages</a> in the <i>Amazon SQS Developer Guide</i>.</para></li><li><para><code>VisibilityTimeout</code> - returns the visibility timeout for the queue. For
        /// more information about visibility timeout, see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/AboutVT.html">Visibility
        /// Timeout</a> in the <i>Amazon SQS Developer Guide</i>.</para></li><li><para><code>CreatedTimestamp</code> - returns the time when the queue was created (epoch
        /// time in seconds).</para></li><li><para><code>LastModifiedTimestamp</code> - returns the time when the queue was last changed
        /// (epoch time in seconds).</para></li><li><para><code>Policy</code> - returns the queue's policy.</para></li><li><para><code>MaximumMessageSize</code> - returns the limit of how many bytes a message can
        /// contain before Amazon SQS rejects it.</para></li><li><para><code>MessageRetentionPeriod</code> - returns the number of seconds Amazon SQS retains
        /// a message.</para></li><li><para><code>QueueArn</code> - returns the queue's Amazon resource name (ARN).</para></li><li><para><code>ApproximateNumberOfMessagesDelayed</code> - returns the approximate number of
        /// messages that are pending to be added to the queue.</para></li><li><para><code>DelaySeconds</code> - returns the default delay on the queue in seconds.</para></li><li><para><code>ReceiveMessageWaitTimeSeconds</code> - returns the time for which a ReceiveMessage
        /// call will wait for a message to arrive.</para></li><li><para><code>RedrivePolicy</code> - returns the parameters for dead letter queue functionality
        /// of the source queue. For more information about RedrivePolicy and dead letter queues,
        /// see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/SQSDeadLetterQueue.html">Using
        /// Amazon SQS Dead Letter Queues</a> in the <i>Amazon SQS Developer Guide</i>.</para></li></ul><note><para>Going forward, new attributes might be added. If you are writing code that calls this
        /// action, we recommend that you structure your code so that it can handle new attributes
        /// gracefully.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AttributeName != null)
            {
                context.AttributeNames = new List<System.String>(this.AttributeName);
            }
            context.QueueUrl = this.QueueUrl;
            
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
                var response = client.GetQueueAttributes(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AttributeNames { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
