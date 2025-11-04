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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Request an origination phone number for use in your account. For more information
    /// on phone number request see <a href="https://docs.aws.amazon.com/sms-voice/latest/userguide/phone-numbers-request.html">Request
    /// a phone number</a> in the <i>End User MessagingSMS User Guide</i>.
    /// </summary>
    [Cmdlet("New", "SMSVPhoneNumber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 RequestPhoneNumber API operation.", Operation = new[] {"RequestPhoneNumber"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse object containing multiple properties."
    )]
    public partial class NewSMSVPhoneNumberCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true the phone number can't be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter InternationalSendingEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true the international sending of phone
        /// number is Enabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InternationalSendingEnabled { get; set; }
        #endregion
        
        #region Parameter IsoCountryCode
        /// <summary>
        /// <para>
        /// <para>The two-character code, in ISO 3166-1 alpha-2 format, for the country or region. </para>
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
        public System.String IsoCountryCode { get; set; }
        #endregion
        
        #region Parameter MessageType
        /// <summary>
        /// <para>
        /// <para>The type of message. Valid values are <c>TRANSACTIONAL</c> for messages that are critical
        /// or time-sensitive and <c>PROMOTIONAL</c> for messages that aren't critical or time-sensitive.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.MessageType")]
        public Amazon.PinpointSMSVoiceV2.MessageType MessageType { get; set; }
        #endregion
        
        #region Parameter NumberCapability
        /// <summary>
        /// <para>
        /// <para>Indicates if the phone number will be used for text messages, voice messages, or both.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NumberCapabilities")]
        public System.String[] NumberCapability { get; set; }
        #endregion
        
        #region Parameter NumberType
        /// <summary>
        /// <para>
        /// <para>The type of phone number to request.</para><para>When you request a <c>SIMULATOR</c> phone number, you must set <b>MessageType</b>
        /// as <c>TRANSACTIONAL</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.RequestableNumberType")]
        public Amazon.PinpointSMSVoiceV2.RequestableNumberType NumberType { get; set; }
        #endregion
        
        #region Parameter OptOutListName
        /// <summary>
        /// <para>
        /// <para>The name of the OptOutList to associate with the phone number. You can use the OptOutListName
        /// or OptOutListArn.</para><important><para>If you are using a shared End User MessagingSMS resource then you must use the full
        /// Amazon Resource Name(ARN).</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptOutListName { get; set; }
        #endregion
        
        #region Parameter PoolId
        /// <summary>
        /// <para>
        /// <para>The pool to associated with the phone number. You can use the PoolId or PoolArn. </para><important><para>If you are using a shared End User MessagingSMS resource then you must use the full
        /// Amazon Resource Name(ARN).</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PoolId { get; set; }
        #endregion
        
        #region Parameter RegistrationId
        /// <summary>
        /// <para>
        /// <para>Use this field to attach your phone number for an external registration process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistrationId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of tags (key and value pairs) to associate with the requested phone number.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PinpointSMSVoiceV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If you don't specify a client token, a randomly generated token is used for
        /// the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMSVPhoneNumber (RequestPhoneNumber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse, NewSMSVPhoneNumberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            context.InternationalSendingEnabled = this.InternationalSendingEnabled;
            context.IsoCountryCode = this.IsoCountryCode;
            #if MODULAR
            if (this.IsoCountryCode == null && ParameterWasBound(nameof(this.IsoCountryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter IsoCountryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageType = this.MessageType;
            #if MODULAR
            if (this.MessageType == null && ParameterWasBound(nameof(this.MessageType)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NumberCapability != null)
            {
                context.NumberCapability = new List<System.String>(this.NumberCapability);
            }
            #if MODULAR
            if (this.NumberCapability == null && ParameterWasBound(nameof(this.NumberCapability)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberCapability which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumberType = this.NumberType;
            #if MODULAR
            if (this.NumberType == null && ParameterWasBound(nameof(this.NumberType)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OptOutListName = this.OptOutListName;
            context.PoolId = this.PoolId;
            context.RegistrationId = this.RegistrationId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PinpointSMSVoiceV2.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.InternationalSendingEnabled != null)
            {
                request.InternationalSendingEnabled = cmdletContext.InternationalSendingEnabled.Value;
            }
            if (cmdletContext.IsoCountryCode != null)
            {
                request.IsoCountryCode = cmdletContext.IsoCountryCode;
            }
            if (cmdletContext.MessageType != null)
            {
                request.MessageType = cmdletContext.MessageType;
            }
            if (cmdletContext.NumberCapability != null)
            {
                request.NumberCapabilities = cmdletContext.NumberCapability;
            }
            if (cmdletContext.NumberType != null)
            {
                request.NumberType = cmdletContext.NumberType;
            }
            if (cmdletContext.OptOutListName != null)
            {
                request.OptOutListName = cmdletContext.OptOutListName;
            }
            if (cmdletContext.PoolId != null)
            {
                request.PoolId = cmdletContext.PoolId;
            }
            if (cmdletContext.RegistrationId != null)
            {
                request.RegistrationId = cmdletContext.RegistrationId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "RequestPhoneNumber");
            try
            {
                #if DESKTOP
                return client.RequestPhoneNumber(request);
                #elif CORECLR
                return client.RequestPhoneNumberAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public System.Boolean? InternationalSendingEnabled { get; set; }
            public System.String IsoCountryCode { get; set; }
            public Amazon.PinpointSMSVoiceV2.MessageType MessageType { get; set; }
            public List<System.String> NumberCapability { get; set; }
            public Amazon.PinpointSMSVoiceV2.RequestableNumberType NumberType { get; set; }
            public System.String OptOutListName { get; set; }
            public System.String PoolId { get; set; }
            public System.String RegistrationId { get; set; }
            public List<Amazon.PinpointSMSVoiceV2.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.RequestPhoneNumberResponse, NewSMSVPhoneNumberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
