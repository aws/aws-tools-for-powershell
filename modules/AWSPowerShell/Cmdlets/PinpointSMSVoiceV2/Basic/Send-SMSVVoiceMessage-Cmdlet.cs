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
    /// Allows you to send a request that sends a voice message through Amazon Pinpoint. This
    /// operation uses <a href="http://aws.amazon.com/polly/">Amazon Polly</a> to convert
    /// a text script into a voice message.
    /// </summary>
    [Cmdlet("Send", "SMSVVoiceMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 SendVoiceMessage API operation.", Operation = new[] {"SendVoiceMessage"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSMSVVoiceMessageCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
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
        /// recipient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter MaxPricePerMinute
        /// <summary>
        /// <para>
        /// <para>The maximum amount to spend per voice message, in US dollars.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaxPricePerMinute { get; set; }
        #endregion
        
        #region Parameter MessageBody
        /// <summary>
        /// <para>
        /// <para>The text to convert to a voice message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageBody { get; set; }
        #endregion
        
        #region Parameter MessageBodyTextType
        /// <summary>
        /// <para>
        /// <para>Specifies if the MessageBody field contains text or <a href="https://docs.aws.amazon.com/polly/latest/dg/what-is.html">speech
        /// synthesis markup language (SSML)</a>.</para><ul><li><para>TEXT: This is the default value. When used the maximum character limit is 3000.</para></li><li><para>SSML: When used the maximum character limit is 6000 including SSML tagging.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.VoiceMessageBodyTextType")]
        public Amazon.PinpointSMSVoiceV2.VoiceMessageBodyTextType MessageBodyTextType { get; set; }
        #endregion
        
        #region Parameter OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity to use for the voice call. This can be the PhoneNumber, PhoneNumberId,
        /// PhoneNumberArn, PoolId, or PoolArn.</para>
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
        public System.String OriginationIdentity { get; set; }
        #endregion
        
        #region Parameter TimeToLive
        /// <summary>
        /// <para>
        /// <para>How long the voice message is valid for. By default this is 72 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TimeToLive { get; set; }
        #endregion
        
        #region Parameter VoiceId
        /// <summary>
        /// <para>
        /// <para>The voice for the <a href="https://docs.aws.amazon.com/polly/latest/dg/what-is.html">Amazon
        /// Polly</a> service to use. By default this is set to "MATTHEW".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.VoiceId")]
        public Amazon.PinpointSMSVoiceV2.VoiceId VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SMSVVoiceMessage (SendVoiceMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse, SendSMSVVoiceMessageCmdlet>(Select) ??
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
            context.DestinationPhoneNumber = this.DestinationPhoneNumber;
            #if MODULAR
            if (this.DestinationPhoneNumber == null && ParameterWasBound(nameof(this.DestinationPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.MaxPricePerMinute = this.MaxPricePerMinute;
            context.MessageBody = this.MessageBody;
            context.MessageBodyTextType = this.MessageBodyTextType;
            context.OriginationIdentity = this.OriginationIdentity;
            #if MODULAR
            if (this.OriginationIdentity == null && ParameterWasBound(nameof(this.OriginationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter OriginationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeToLive = this.TimeToLive;
            context.VoiceId = this.VoiceId;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DestinationPhoneNumber != null)
            {
                request.DestinationPhoneNumber = cmdletContext.DestinationPhoneNumber;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MaxPricePerMinute != null)
            {
                request.MaxPricePerMinute = cmdletContext.MaxPricePerMinute;
            }
            if (cmdletContext.MessageBody != null)
            {
                request.MessageBody = cmdletContext.MessageBody;
            }
            if (cmdletContext.MessageBodyTextType != null)
            {
                request.MessageBodyTextType = cmdletContext.MessageBodyTextType;
            }
            if (cmdletContext.OriginationIdentity != null)
            {
                request.OriginationIdentity = cmdletContext.OriginationIdentity;
            }
            if (cmdletContext.TimeToLive != null)
            {
                request.TimeToLive = cmdletContext.TimeToLive.Value;
            }
            if (cmdletContext.VoiceId != null)
            {
                request.VoiceId = cmdletContext.VoiceId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "SendVoiceMessage");
            try
            {
                #if DESKTOP
                return client.SendVoiceMessage(request);
                #elif CORECLR
                return client.SendVoiceMessageAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationPhoneNumber { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String MaxPricePerMinute { get; set; }
            public System.String MessageBody { get; set; }
            public Amazon.PinpointSMSVoiceV2.VoiceMessageBodyTextType MessageBodyTextType { get; set; }
            public System.String OriginationIdentity { get; set; }
            public System.Int32? TimeToLive { get; set; }
            public Amazon.PinpointSMSVoiceV2.VoiceId VoiceId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.SendVoiceMessageResponse, SendSMSVVoiceMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
