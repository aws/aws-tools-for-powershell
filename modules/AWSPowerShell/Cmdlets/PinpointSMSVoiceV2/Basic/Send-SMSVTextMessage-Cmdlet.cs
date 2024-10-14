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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Creates a new text message and sends it to a recipient's phone number. SendTextMessage
    /// only sends an SMS message to one recipient each time it is invoked.
    /// 
    ///  
    /// <para>
    /// SMS throughput limits are measured in Message Parts per Second (MPS). Your MPS limit
    /// depends on the destination country of your messages, as well as the type of phone
    /// number (origination number) that you use to send the message. For more information
    /// about MPS, see <a href="https://docs.aws.amazon.com/sms-voice/latest/userguide/sms-limitations-mps.html">Message
    /// Parts per Second (MPS) limits</a> in the <i>AWS End User Messaging SMS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "SMSVTextMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 SendTextMessage API operation.", Operation = new[] {"SendTextMessage"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse object containing multiple properties."
    )]
    public partial class SendSMSVTextMessageCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use. This can be either the ConfigurationSetName
        /// or ConfigurationSetArn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>You can specify custom data in this field. If you do, that data is logged to the event
        /// destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Context { get; set; }
        #endregion
        
        #region Parameter DestinationCountryParameter
        /// <summary>
        /// <para>
        /// <para>This field is used for any country-specific registration requirements. Currently,
        /// this setting is only used when you send messages to recipients in India using a sender
        /// ID. For more information see <a href="https://docs.aws.amazon.com/pinpoint/latest/userguide/channels-sms-senderid-india.html">Special
        /// requirements for sending SMS messages to recipients in India</a>. </para><ul><li><para><c>IN_ENTITY_ID</c> The entity ID or Principal Entity (PE) ID that you received after
        /// completing the sender ID registration process.</para></li><li><para><c>IN_TEMPLATE_ID</c> The template ID that you received after completing the sender
        /// ID registration process.</para><important><para>Make sure that the Template ID that you specify matches your message template exactly.
        /// If your message doesn't match the template that you provided during the registration
        /// process, the mobile carriers might reject your message.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationCountryParameters")]
        public System.Collections.Hashtable DestinationCountryParameter { get; set; }
        #endregion
        
        #region Parameter DestinationPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The destination phone number in E.164 format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DestinationPhoneNumber { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>When set to true, the message is checked and validated, but isn't sent to the end
        /// recipient. You are not charged for using <c>DryRun</c>.</para><para>The Message Parts per Second (MPS) limit when using <c>DryRun</c> is five. If your
        /// origination identity has a lower MPS limit then the lower MPS limit is used. For more
        /// information about MPS limits, see <a href="https://docs.aws.amazon.com/sms-voice/latest/userguide/sms-limitations-mps.html">Message
        /// Parts per Second (MPS) limits</a> in the <i>AWS End User Messaging SMS User Guide</i>..</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter Keyword
        /// <summary>
        /// <para>
        /// <para>When you register a short code in the US, you must specify a program name. If you
        /// don’t have a US short code, omit this attribute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Keyword { get; set; }
        #endregion
        
        #region Parameter MaxPrice
        /// <summary>
        /// <para>
        /// <para>The maximum amount that you want to spend, in US dollars, per each text message. If
        /// the calculated amount to send the text message is greater than <c>MaxPrice</c>, the
        /// message is not sent and an error is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxPrice { get; set; }
        #endregion
        
        #region Parameter MessageBody
        /// <summary>
        /// <para>
        /// <para>The body of the text message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageBody { get; set; }
        #endregion
        
        #region Parameter MessageType
        /// <summary>
        /// <para>
        /// <para>The type of message. Valid values are for messages that are critical or time-sensitive
        /// and PROMOTIONAL for messages that aren't critical or time-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.MessageType")]
        public Amazon.PinpointSMSVoiceV2.MessageType MessageType { get; set; }
        #endregion
        
        #region Parameter OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity of the message. This can be either the PhoneNumber, PhoneNumberId,
        /// PhoneNumberArn, SenderId, SenderIdArn, PoolId, or PoolArn.</para><important><para>If you are using a shared AWS End User Messaging SMS and Voice resource then you must
        /// use the full Amazon Resource Name(ARN).</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OriginationIdentity { get; set; }
        #endregion
        
        #region Parameter ProtectConfigurationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the protect configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtectConfigurationId { get; set; }
        #endregion
        
        #region Parameter TimeToLive
        /// <summary>
        /// <para>
        /// <para>How long the text message is valid for, in seconds. By default this is 72 hours. If
        /// the messages isn't handed off before the TTL expires we stop attempting to hand off
        /// the message and return <c>TTL_EXPIRED</c> event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TimeToLive { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationPhoneNumber), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SMSVTextMessage (SendTextMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse, SendSMSVTextMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.Context != null)
            {
                context.Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context.Keys)
                {
                    context.Context.Add((String)hashKey, (System.String)(this.Context[hashKey]));
                }
            }
            if (this.DestinationCountryParameter != null)
            {
                context.DestinationCountryParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationCountryParameter.Keys)
                {
                    context.DestinationCountryParameter.Add((String)hashKey, (System.String)(this.DestinationCountryParameter[hashKey]));
                }
            }
            context.DestinationPhoneNumber = this.DestinationPhoneNumber;
            #if MODULAR
            if (this.DestinationPhoneNumber == null && ParameterWasBound(nameof(this.DestinationPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.Keyword = this.Keyword;
            context.MaxPrice = this.MaxPrice;
            context.MessageBody = this.MessageBody;
            context.MessageType = this.MessageType;
            context.OriginationIdentity = this.OriginationIdentity;
            context.ProtectConfigurationId = this.ProtectConfigurationId;
            context.TimeToLive = this.TimeToLive;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.SendTextMessageRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DestinationCountryParameter != null)
            {
                request.DestinationCountryParameters = cmdletContext.DestinationCountryParameter;
            }
            if (cmdletContext.DestinationPhoneNumber != null)
            {
                request.DestinationPhoneNumber = cmdletContext.DestinationPhoneNumber;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Keyword != null)
            {
                request.Keyword = cmdletContext.Keyword;
            }
            if (cmdletContext.MaxPrice != null)
            {
                request.MaxPrice = cmdletContext.MaxPrice;
            }
            if (cmdletContext.MessageBody != null)
            {
                request.MessageBody = cmdletContext.MessageBody;
            }
            if (cmdletContext.MessageType != null)
            {
                request.MessageType = cmdletContext.MessageType;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
            }
            if (cmdletContext.ProtectConfigurationId != null)
            {
                request.ProtectConfigurationId = cmdletContext.ProtectConfigurationId;
            }
            if (cmdletContext.TimeToLive != null)
            {
                request.TimeToLive = cmdletContext.TimeToLive.Value;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.SendTextMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "SendTextMessage");
            try
            {
                #if DESKTOP
                return client.SendTextMessage(request);
                #elif CORECLR
                return client.SendTextMessageAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public Dictionary<System.String, System.String> Context { get; set; }
            public Dictionary<System.String, System.String> DestinationCountryParameter { get; set; }
            public System.String DestinationPhoneNumber { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String Keyword { get; set; }
            public System.String MaxPrice { get; set; }
            public System.String MessageBody { get; set; }
            public Amazon.PinpointSMSVoiceV2.MessageType MessageType { get; set; }
            public System.String OriginationIdentity { get; set; }
            public System.String ProtectConfigurationId { get; set; }
            public System.Int32? TimeToLive { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.SendTextMessageResponse, SendSMSVTextMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
