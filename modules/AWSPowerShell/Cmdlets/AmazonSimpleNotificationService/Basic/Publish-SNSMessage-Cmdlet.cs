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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Sends a message to all of a topic's subscribed endpoints. When a    <code>messageId</code>
    /// is returned, the message has been saved and Amazon SNS will attempt to deliver it
    ///       to the topic's subscribers shortly. The format of the outgoing message to each
    ///      subscribed endpoint depends on the notification protocol selected.
    /// 
    ///     
    /// <para>
    /// To use the <code>Publish</code> action for sending a message to a mobile endpoint,
    /// such as an app on a Kindle device or mobile phone,       you must specify the EndpointArn.
    /// The EndpointArn is returned when making a call with the <code>CreatePlatformEndpoint</code>
    /// action.       The second example below shows a request and response for publishing
    /// to a mobile endpoint.    
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "SNSMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the Publish operation against Amazon Simple Notification Service.", Operation = new[] {"Publish"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.PublishResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class PublishSNSMessageCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The message you want to send to the topic.</para><para>If you want to send the same message to all transport protocols,       include the
        /// text of the message as a String value.</para><para>If you want to send different messages for each transport protocol,       set the
        /// value of the <code>MessageStructure</code> parameter to <code>json</code>       and
        /// use a JSON object for the <code>Message</code> parameter.       See the Examples section
        /// for the format of the JSON object. </para><para>Constraints: Messages must be UTF-8 encoded      strings at most 256 KB in size (262144
        /// bytes, not 262144 characters).</para><para>JSON-specific constraints:      <ul><li>Keys in the JSON object that correspond
        /// to supported transport      protocols must have simple JSON string values. </li><li>The values will be parsed (unescaped)        before they are used in outgoing
        /// messages.</li><li>Outbound notifications are JSON        encoded (meaning
        /// that the characters will be reescaped for sending).</li><li>Values have a
        /// minimum length of 0 (the empty string, "", is allowed).</li><li>Values have
        /// a maximum length bounded by the overall message size (so, including        multiple
        /// protocols may limit message sizes).</li><li>Non-string values will cause the
        /// key        to be ignored.</li><li>Keys that do not correspond to supported
        /// transport protocols are ignored.</li><li>Duplicate keys are not allowed.</li><li>Failure to parse or validate any key or          value in the message will
        /// cause the <code>Publish</code> call to return an error (no partial      delivery).</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Message { get; set; }
        #endregion
        
        #region Parameter MessageAttribute
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MessageAttributes")]
        public System.Collections.Hashtable MessageAttribute { get; set; }
        #endregion
        
        #region Parameter MessageStructure
        /// <summary>
        /// <para>
        /// <para>Set <code>MessageStructure</code> to <code>json</code> if you want to send      a
        /// different message for each protocol. For example, using one publish action,      you
        /// can send a short message to your SMS subscribers and a longer message to      your
        /// email subscribers.      If you set <code>MessageStructure</code> to <code>json</code>,
        /// the value of       the <code>Message</code> parameter must:    </para><ul><li>be a syntactically valid JSON object; and</li><li>contain
        /// at least a top-level JSON key of "default" with a value that is a string.</li></ul><para> You can define other top-level keys that define the message you want to send    
        ///  to a specific transport protocol (e.g., "http"). </para><para>For information about sending different messages for each protocol using      the
        /// AWS Management Console, go to <a href="http://docs.aws.amazon.com/sns/latest/gsg/Publish.html#sns-message-formatting-by-protocol">Create
        ///         Different Messages for Each Protocol</a> in the <i>Amazon Simple Notification
        /// Service      Getting Started Guide</i>.    </para><para>Valid value: <code>json</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String MessageStructure { get; set; }
        #endregion
        
        #region Parameter Subject
        /// <summary>
        /// <para>
        /// <para>Optional parameter to be used as the "Subject" line when the message is      delivered
        /// to email endpoints. This field will also be included, if present,       in the standard
        /// JSON messages delivered to other endpoints.</para><para>Constraints: Subjects must be ASCII text that begins with a letter, number,      
        /// or punctuation mark; must not include line breaks or control characters; and     
        ///  must be less than 100 characters long.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String Subject { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>Either TopicArn or EndpointArn, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter TopicArn
        /// <summary>
        /// <para>
        /// <para>The topic you want to publish to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TopicArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TopicArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-SNSMessage (Publish)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Message = this.Message;
            if (this.MessageAttribute != null)
            {
                context.MessageAttributes = new Dictionary<System.String, Amazon.SimpleNotificationService.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageAttribute.Keys)
                {
                    context.MessageAttributes.Add((String)hashKey, (MessageAttributeValue)(this.MessageAttribute[hashKey]));
                }
            }
            context.MessageStructure = this.MessageStructure;
            context.Subject = this.Subject;
            context.TargetArn = this.TargetArn;
            context.TopicArn = this.TopicArn;
            
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
            if (cmdletContext.MessageAttributes != null)
            {
                request.MessageAttributes = cmdletContext.MessageAttributes;
            }
            if (cmdletContext.MessageStructure != null)
            {
                request.MessageStructure = cmdletContext.MessageStructure;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.Publish(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.MessageId;
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
            public System.String Message { get; set; }
            public Dictionary<System.String, Amazon.SimpleNotificationService.Model.MessageAttributeValue> MessageAttributes { get; set; }
            public System.String MessageStructure { get; set; }
            public System.String Subject { get; set; }
            public System.String TargetArn { get; set; }
            public System.String TopicArn { get; set; }
        }
        
    }
}
