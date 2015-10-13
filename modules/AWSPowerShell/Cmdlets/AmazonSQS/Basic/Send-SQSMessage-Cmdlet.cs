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
    /// Delivers a message to the specified queue. With Amazon SQS, you now have the ability
    /// to send large payload messages that are up to 256KB (262,144 bytes) in size. To send
    /// large payloads, you must use an AWS SDK that supports SigV4 signing. To verify whether
    /// SigV4 is supported for an AWS SDK, check the SDK release notes. 
    /// 
    ///  <important><para>
    ///  The following list shows the characters (in Unicode) allowed in your message, according
    /// to the W3C XML specification. For more information, go to <a href="http://www.w3.org/TR/REC-xml/#charsets">http://www.w3.org/TR/REC-xml/#charsets</a>
    /// If you send any characters not included in the list, your request will be rejected.
    /// 
    /// </para><para>
    ///  #x9 | #xA | #xD | [#x20 to #xD7FF] | [#xE000 to #xFFFD] | [#x10000 to #x10FFFF] 
    /// </para></important>
    /// </summary>
    [Cmdlet("Send", "SQSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SQS.Model.SendMessageResponse")]
    [AWSCmdlet("Invokes the SendMessage operation against Amazon Simple Queue Service.", Operation = new[] {"SendMessage"})]
    [AWSCmdletOutput("Amazon.SQS.Model.SendMessageResponse",
        "This cmdlet returns a Amazon.SQS.Model.SendMessageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendSQSMessageCmdlet : AmazonSQSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The number of seconds (0 to 900 - 15 minutes) to delay a specific message. Messages
        /// with a positive <code>DelaySeconds</code> value become available for processing after
        /// the delay time is finished. If you don't specify a value, the default value for the
        /// queue applies. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("DelaySeconds")]
        public System.Int32 DelayInSeconds { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Each message attribute consists of a Name, Type, and Value. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSSimpleQueueService/latest/SQSDeveloperGuide/SQSMessageAttributes.html#SQSMessageAttributesNTV">Message
        /// Attribute Items</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageAttributes")]
        public System.Collections.Hashtable MessageAttribute { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The message to send. String maximum 256 KB in size. For a list of allowed characters,
        /// see the preceding important note.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String MessageBody { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The URL of the Amazon SQS queue to take action on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueueUrl { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("QueueUrl", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SQSMessage (SendMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("DelayInSeconds"))
                context.DelayInSeconds = this.DelayInSeconds;
            if (this.MessageAttribute != null)
            {
                context.MessageAttributes = new Dictionary<System.String, Amazon.SQS.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageAttribute.Keys)
                {
                    context.MessageAttributes.Add((String)hashKey, (MessageAttributeValue)(this.MessageAttribute[hashKey]));
                }
            }
            context.MessageBody = this.MessageBody;
            context.QueueUrl = this.QueueUrl;
            
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
            if (cmdletContext.MessageAttributes != null)
            {
                request.MessageAttributes = cmdletContext.MessageAttributes;
            }
            if (cmdletContext.MessageBody != null)
            {
                request.MessageBody = cmdletContext.MessageBody;
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
                var response = client.SendMessage(request);
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
            public System.Int32? DelayInSeconds { get; set; }
            public Dictionary<System.String, Amazon.SQS.Model.MessageAttributeValue> MessageAttributes { get; set; }
            public System.String MessageBody { get; set; }
            public System.String QueueUrl { get; set; }
        }
        
    }
}
