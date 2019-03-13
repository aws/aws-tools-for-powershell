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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Prepares to subscribe an endpoint by sending the endpoint a confirmation message.
    /// To actually create a subscription, the endpoint owner must call the <code>ConfirmSubscription</code>
    /// action with the token from the confirmation message. Confirmation tokens are valid
    /// for three days.
    /// 
    ///  
    /// <para>
    /// This action is throttled at 100 transactions per second (TPS).
    /// </para>
    /// </summary>
    [Cmdlet("Connect", "SNSNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service Subscribe API operation.", Operation = new[] {"Subscribe"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.SubscribeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConnectSNSNotificationCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of attributes with their corresponding values.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that the <code>SetTopicAttributes</code> action uses:</para><ul><li><para><code>DeliveryPolicy</code> – The policy that defines how Amazon SNS retries failed
        /// deliveries to HTTP/S endpoints.</para></li><li><para><code>FilterPolicy</code> – The simple JSON object that lets your subscriber receive
        /// only a subset of messages, rather than receiving every message published to the topic.</para></li><li><para><code>RawMessageDelivery</code> – When set to <code>true</code>, enables raw message
        /// delivery to Amazon SQS or HTTP/S endpoints. This eliminates the need for the endpoints
        /// to process JSON formatting, which is otherwise created for Amazon SNS metadata.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint that you want to receive notifications. Endpoints vary by protocol:</para><ul><li><para>For the <code>http</code> protocol, the endpoint is an URL beginning with "http://"</para></li><li><para>For the <code>https</code> protocol, the endpoint is a URL beginning with "https://"</para></li><li><para>For the <code>email</code> protocol, the endpoint is an email address</para></li><li><para>For the <code>email-json</code> protocol, the endpoint is an email address</para></li><li><para>For the <code>sms</code> protocol, the endpoint is a phone number of an SMS-enabled
        /// device</para></li><li><para>For the <code>sqs</code> protocol, the endpoint is the ARN of an Amazon SQS queue</para></li><li><para>For the <code>application</code> protocol, the endpoint is the EndpointArn of a mobile
        /// app and device.</para></li><li><para>For the <code>lambda</code> protocol, the endpoint is the ARN of an AWS Lambda function.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Endpoint { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol you want to use. Supported protocols include:</para><ul><li><para><code>http</code> – delivery of JSON-encoded message via HTTP POST</para></li><li><para><code>https</code> – delivery of JSON-encoded message via HTTPS POST</para></li><li><para><code>email</code> – delivery of message via SMTP</para></li><li><para><code>email-json</code> – delivery of JSON-encoded message via SMTP</para></li><li><para><code>sms</code> – delivery of message via SMS</para></li><li><para><code>sqs</code> – delivery of JSON-encoded message to an Amazon SQS queue</para></li><li><para><code>application</code> – delivery of JSON-encoded message to an EndpointArn for
        /// a mobile app and device.</para></li><li><para><code>lambda</code> – delivery of JSON-encoded message to an AWS Lambda function.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Protocol { get; set; }
        #endregion
        
        #region Parameter ReturnSubscriptionArn
        /// <summary>
        /// <para>
        /// <para>Sets whether the response from the <code>Subscribe</code> request includes the subscription
        /// ARN, even if the subscription is not yet confirmed.</para><para>If you set this parameter to <code>false</code>, the response includes the ARN for
        /// confirmed subscriptions, but it includes an ARN value of "pending subscription" for
        /// subscriptions that are not yet confirmed. A subscription becomes confirmed when the
        /// subscriber calls the <code>ConfirmSubscription</code> action with a confirmation token.</para><para>If you set this parameter to <code>true</code>, the response includes the ARN in all
        /// cases, even if the subscription is not yet confirmed.</para><para>The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ReturnSubscriptionArn { get; set; }
        #endregion
        
        #region Parameter TopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the topic you want to subscribe to.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-SNSNotification (Subscribe)"))
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
            context.Endpoint = this.Endpoint;
            context.Protocol = this.Protocol;
            if (ParameterWasBound("ReturnSubscriptionArn"))
                context.ReturnSubscriptionArn = this.ReturnSubscriptionArn;
            context.TopicArn = this.TopicArn;
            
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
            var request = new Amazon.SimpleNotificationService.Model.SubscribeRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.Endpoint != null)
            {
                request.Endpoint = cmdletContext.Endpoint;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.ReturnSubscriptionArn != null)
            {
                request.ReturnSubscriptionArn = cmdletContext.ReturnSubscriptionArn.Value;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleNotificationService.Model.SubscribeResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.SubscribeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service", "Subscribe");
            try
            {
                #if DESKTOP
                return client.Subscribe(request);
                #elif CORECLR
                return client.SubscribeAsync(request).GetAwaiter().GetResult();
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
            public System.String Endpoint { get; set; }
            public System.String Protocol { get; set; }
            public System.Boolean? ReturnSubscriptionArn { get; set; }
            public System.String TopicArn { get; set; }
        }
        
    }
}
