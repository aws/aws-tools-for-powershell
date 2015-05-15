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
    /// Prepares to subscribe an endpoint by sending the endpoint a confirmation message.
    /// To actually create a      subscription, the endpoint owner must call the <code>ConfirmSubscription</code>
    ///      action with the token from the confirmation message. Confirmation tokens are
    ///      valid for three days.
    /// </summary>
    [Cmdlet("Connect", "SNSNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the Subscribe operation against Amazon Simple Notification Service.", Operation = new[] {"Subscribe"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type SubscribeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class ConnectSNSNotificationCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The endpoint that you want to receive notifications. Endpoints vary by protocol:</para><ul><li>For the <code>http</code> protocol, the endpoint is an URL beginning
        /// with "http://"</li><li>For the <code>https</code> protocol, the endpoint is
        /// a URL beginning with "https://"</li><li>For the <code>email</code> protocol,
        /// the endpoint is an email address</li><li>For the <code>email-json</code> protocol,
        /// the endpoint is an email address</li><li>For the <code>sms</code> protocol,
        /// the endpoint is a phone number of an SMS-enabled device</li><li>For the <code>sqs</code>
        /// protocol, the endpoint is the ARN of an Amazon SQS queue</li><li>For the <code>application</code>
        /// protocol, the endpoint is the EndpointArn of a mobile app and device.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String Endpoint { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The protocol you want to use. Supported protocols include:</para><ul><li><code>http</code> -- delivery of JSON-encoded message via HTTP POST</li><li><code>https</code> -- delivery of JSON-encoded message via HTTPS POST</li><li><code>email</code> -- delivery of message via SMTP</li><li><code>email-json</code>
        /// -- delivery of JSON-encoded message via SMTP</li><li><code>sms</code> -- delivery
        /// of message via SMS</li><li><code>sqs</code> -- delivery of JSON-encoded message
        /// to an Amazon SQS queue</li><li><code>application</code> -- delivery of JSON-encoded
        /// message to an EndpointArn for a mobile app and device.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Protocol { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the topic you want to subscribe to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String TopicArn { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TopicArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-SNSNotification (Subscribe)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Endpoint = this.Endpoint;
            context.Protocol = this.Protocol;
            context.TopicArn = this.TopicArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SubscribeRequest();
            
            if (cmdletContext.Endpoint != null)
            {
                request.Endpoint = cmdletContext.Endpoint;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
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
                var response = client.Subscribe(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SubscriptionArn;
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
            public String Endpoint { get; set; }
            public String Protocol { get; set; }
            public String TopicArn { get; set; }
        }
        
    }
}
