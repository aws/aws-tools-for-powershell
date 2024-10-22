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
    /// Before you can send test messages to a verified destination phone number you need
    /// to opt-in the verified destination phone number. Creates a new text message with a
    /// verification code and send it to a verified destination phone number. Once you have
    /// the verification code use <a>VerifyDestinationNumber</a> to opt-in the verified destination
    /// phone number to receive messages.
    /// </summary>
    [Cmdlet("Send", "SMSVDestinationNumberVerificationCode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 SendDestinationNumberVerificationCode API operation.", Operation = new[] {"SendDestinationNumberVerificationCode"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSMSVDestinationNumberVerificationCodeCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
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
        /// requirements for sending SMS messages to recipients in India</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationCountryParameters")]
        public System.Collections.Hashtable DestinationCountryParameter { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>Choose the language to use for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.LanguageCode")]
        public Amazon.PinpointSMSVoiceV2.LanguageCode LanguageCode { get; set; }
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
        
        #region Parameter VerificationChannel
        /// <summary>
        /// <para>
        /// <para>Choose to send the verification code as an SMS or voice message.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.VerificationChannel")]
        public Amazon.PinpointSMSVoiceV2.VerificationChannel VerificationChannel { get; set; }
        #endregion
        
        #region Parameter VerifiedDestinationNumberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the verified destination phone number.</para>
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
        public System.String VerifiedDestinationNumberId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VerifiedDestinationNumberId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SMSVDestinationNumberVerificationCode (SendDestinationNumberVerificationCode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse, SendSMSVDestinationNumberVerificationCodeCmdlet>(Select) ??
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
            context.LanguageCode = this.LanguageCode;
            context.OriginationIdentity = this.OriginationIdentity;
            context.VerificationChannel = this.VerificationChannel;
            #if MODULAR
            if (this.VerificationChannel == null && ParameterWasBound(nameof(this.VerificationChannel)))
            {
                WriteWarning("You are passing $null as a value for parameter VerificationChannel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerifiedDestinationNumberId = this.VerifiedDestinationNumberId;
            #if MODULAR
            if (this.VerifiedDestinationNumberId == null && ParameterWasBound(nameof(this.VerifiedDestinationNumberId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifiedDestinationNumberId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeRequest();
            
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
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
            }
            if (cmdletContext.VerificationChannel != null)
            {
                request.VerificationChannel = cmdletContext.VerificationChannel;
            }
            if (cmdletContext.VerifiedDestinationNumberId != null)
            {
                request.VerifiedDestinationNumberId = cmdletContext.VerifiedDestinationNumberId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "SendDestinationNumberVerificationCode");
            try
            {
                #if DESKTOP
                return client.SendDestinationNumberVerificationCode(request);
                #elif CORECLR
                return client.SendDestinationNumberVerificationCodeAsync(request).GetAwaiter().GetResult();
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
            public Amazon.PinpointSMSVoiceV2.LanguageCode LanguageCode { get; set; }
            public System.String OriginationIdentity { get; set; }
            public Amazon.PinpointSMSVoiceV2.VerificationChannel VerificationChannel { get; set; }
            public System.String VerifiedDestinationNumberId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.SendDestinationNumberVerificationCodeResponse, SendSMSVDestinationNumberVerificationCodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
