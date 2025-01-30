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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Subscribes an endpoint to an Amazon SNS topic. If the endpoint type is HTTP/S or email,
    /// or if the endpoint and the topic are not in the same Amazon Web Services account,
    /// the endpoint owner must run the <c>ConfirmSubscription</c> action to confirm the subscription.
    /// 
    ///  
    /// <para>
    /// You call the <c>ConfirmSubscription</c> action with the token from the subscription
    /// response. Confirmation tokens are valid for two days.
    /// </para><para>
    /// This action is throttled at 100 transactions per second (TPS).
    /// </para>
    /// </summary>
    [Cmdlet("Connect", "SNSNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) Subscribe API operation.", Operation = new[] {"Subscribe"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.SubscribeResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleNotificationService.Model.SubscribeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.SubscribeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConnectSNSNotificationCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of attributes with their corresponding values.</para><para>The following lists the names, descriptions, and values of the special request parameters
        /// that the <c>Subscribe</c> action uses:</para><ul><li><para><c>DeliveryPolicy</c> – The policy that defines how Amazon SNS retries failed deliveries
        /// to HTTP/S endpoints.</para></li><li><para><c>FilterPolicy</c> – The simple JSON object that lets your subscriber receive only
        /// a subset of messages, rather than receiving every message published to the topic.</para></li><li><para><c>FilterPolicyScope</c> – This attribute lets you choose the filtering scope by
        /// using one of the following string value types:</para><ul><li><para><c>MessageAttributes</c> (default) – The filter is applied on the message attributes.</para></li><li><para><c>MessageBody</c> – The filter is applied on the message body.</para></li></ul></li><li><para><c>RawMessageDelivery</c> – When set to <c>true</c>, enables raw message delivery
        /// to Amazon SQS or HTTP/S endpoints. This eliminates the need for the endpoints to process
        /// JSON formatting, which is otherwise created for Amazon SNS metadata.</para></li><li><para><c>RedrivePolicy</c> – When specified, sends undeliverable messages to the specified
        /// Amazon SQS dead-letter queue. Messages that can't be delivered due to client errors
        /// (for example, when the subscribed endpoint is unreachable) or server errors (for example,
        /// when the service that powers the subscribed endpoint becomes unavailable) are held
        /// in the dead-letter queue for further analysis or reprocessing.</para></li></ul><para>The following attribute applies only to Amazon Data Firehose delivery stream subscriptions:</para><ul><li><para><c>SubscriptionRoleArn</c> – The ARN of the IAM role that has the following:</para><ul><li><para>Permission to write to the Firehose delivery stream</para></li><li><para>Amazon SNS listed as a trusted entity</para></li></ul><para>Specifying a valid ARN for this attribute is required for Firehose delivery stream
        /// subscriptions. For more information, see <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-firehose-as-subscriber.html">Fanout
        /// to Firehose delivery streams</a> in the <i>Amazon SNS Developer Guide</i>.</para></li></ul><para>The following attributes apply only to <a href="https://docs.aws.amazon.com/sns/latest/dg/sns-fifo-topics.html">FIFO
        /// topics</a>:</para><ul><li><para><c>ReplayPolicy</c> – Adds or updates an inline policy document for a subscription
        /// to replay messages stored in the specified Amazon SNS topic.</para></li><li><para><c>ReplayStatus</c> – Retrieves the status of the subscription message replay, which
        /// can be one of the following:</para><ul><li><para><c>Completed</c> – The replay has successfully redelivered all messages, and is now
        /// delivering newly published messages. If an ending point was specified in the <c>ReplayPolicy</c>
        /// then the subscription will no longer receive newly published messages.</para></li><li><para><c>In progress</c> – The replay is currently replaying the selected messages.</para></li><li><para><c>Failed</c> – The replay was unable to complete.</para></li><li><para><c>Pending</c> – The default state while the replay initiates.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint that you want to receive notifications. Endpoints vary by protocol:</para><ul><li><para>For the <c>http</c> protocol, the (public) endpoint is a URL beginning with <c>http://</c>.</para></li><li><para>For the <c>https</c> protocol, the (public) endpoint is a URL beginning with <c>https://</c>.</para></li><li><para>For the <c>email</c> protocol, the endpoint is an email address.</para></li><li><para>For the <c>email-json</c> protocol, the endpoint is an email address.</para></li><li><para>For the <c>sms</c> protocol, the endpoint is a phone number of an SMS-enabled device.</para></li><li><para>For the <c>sqs</c> protocol, the endpoint is the ARN of an Amazon SQS queue.</para></li><li><para>For the <c>application</c> protocol, the endpoint is the EndpointArn of a mobile app
        /// and device.</para></li><li><para>For the <c>lambda</c> protocol, the endpoint is the ARN of an Lambda function.</para></li><li><para>For the <c>firehose</c> protocol, the endpoint is the ARN of an Amazon Kinesis Data
        /// Firehose delivery stream.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String Endpoint { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol that you want to use. Supported protocols include:</para><ul><li><para><c>http</c> – delivery of JSON-encoded message via HTTP POST</para></li><li><para><c>https</c> – delivery of JSON-encoded message via HTTPS POST</para></li><li><para><c>email</c> – delivery of message via SMTP</para></li><li><para><c>email-json</c> – delivery of JSON-encoded message via SMTP</para></li><li><para><c>sms</c> – delivery of message via SMS</para></li><li><para><c>sqs</c> – delivery of JSON-encoded message to an Amazon SQS queue</para></li><li><para><c>application</c> – delivery of JSON-encoded message to an EndpointArn for a mobile
        /// app and device</para></li><li><para><c>lambda</c> – delivery of JSON-encoded message to an Lambda function</para></li><li><para><c>firehose</c> – delivery of JSON-encoded message to an Amazon Kinesis Data Firehose
        /// delivery stream.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Protocol { get; set; }
        #endregion
        
        #region Parameter ReturnSubscriptionArn
        /// <summary>
        /// <para>
        /// <para>Sets whether the response from the <c>Subscribe</c> request includes the subscription
        /// ARN, even if the subscription is not yet confirmed.</para><para>If you set this parameter to <c>true</c>, the response includes the ARN in all cases,
        /// even if the subscription is not yet confirmed. In addition to the ARN for confirmed
        /// subscriptions, the response also includes the <c>pending subscription</c> ARN value
        /// for subscriptions that aren't yet confirmed. A subscription becomes confirmed when
        /// the subscriber calls the <c>ConfirmSubscription</c> action with a confirmation token.</para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReturnSubscriptionArn { get; set; }
        #endregion
        
        #region Parameter TopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the topic you want to subscribe to.</para>
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
        public System.String TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SubscriptionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.SubscribeResponse).
        /// Specifying the name of a property of type Amazon.SimpleNotificationService.Model.SubscribeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SubscriptionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TopicArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TopicArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TopicArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TopicArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-SNSNotification (Subscribe)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.SubscribeResponse, ConnectSNSNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TopicArn;
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
            context.Endpoint = this.Endpoint;
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReturnSubscriptionArn = this.ReturnSubscriptionArn;
            context.TopicArn = this.TopicArn;
            #if MODULAR
            if (this.TopicArn == null && ParameterWasBound(nameof(this.TopicArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleNotificationService.Model.SubscribeRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
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
        
        private Amazon.SimpleNotificationService.Model.SubscribeResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.SubscribeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "Subscribe");
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String Endpoint { get; set; }
            public System.String Protocol { get; set; }
            public System.Boolean? ReturnSubscriptionArn { get; set; }
            public System.String TopicArn { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.SubscribeResponse, ConnectSNSNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SubscriptionArn;
        }
        
    }
}
