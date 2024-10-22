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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Send an OTP message
    /// </summary>
    [Cmdlet("Send", "PINOTPMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SendOTPMessage API operation.", Operation = new[] {"SendOTPMessage"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.SendOTPMessageResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageResponse or Amazon.Pinpoint.Model.SendOTPMessageResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.SendOTPMessageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendPINOTPMessageCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SendOTPMessageRequestParameters_AllowedAttempt
        /// <summary>
        /// <para>
        /// <para>The attempts allowed to validate an OTP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SendOTPMessageRequestParameters_AllowedAttempts")]
        public System.Int32? SendOTPMessageRequestParameters_AllowedAttempt { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique ID of your Amazon Pinpoint application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_BrandName
        /// <summary>
        /// <para>
        /// <para>The brand name that will be substituted into the OTP message body. Should be owned
        /// by calling AWS account.</para>
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
        public System.String SendOTPMessageRequestParameters_BrandName { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_Channel
        /// <summary>
        /// <para>
        /// <para>Channel type for the OTP message. Supported values: [SMS].</para>
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
        public System.String SendOTPMessageRequestParameters_Channel { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_CodeLength
        /// <summary>
        /// <para>
        /// <para>The number of characters in the generated OTP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SendOTPMessageRequestParameters_CodeLength { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_DestinationIdentity
        /// <summary>
        /// <para>
        /// <para>The destination identity to send OTP to.</para>
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
        public System.String SendOTPMessageRequestParameters_DestinationIdentity { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_EntityId
        /// <summary>
        /// <para>
        /// <para>A unique Entity ID received from DLT after entity registration is approved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SendOTPMessageRequestParameters_EntityId { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_Language
        /// <summary>
        /// <para>
        /// <para>The language to be used for the outgoing message body containing the OTP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SendOTPMessageRequestParameters_Language { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_OriginationIdentity
        /// <summary>
        /// <para>
        /// <para>The origination identity used to send OTP from.</para>
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
        public System.String SendOTPMessageRequestParameters_OriginationIdentity { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_ReferenceId
        /// <summary>
        /// <para>
        /// <para>Developer-specified reference identifier. Required to match during OTP verification.</para>
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
        public System.String SendOTPMessageRequestParameters_ReferenceId { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_TemplateId
        /// <summary>
        /// <para>
        /// <para>A unique Template ID received from DLT after entity registration is approved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SendOTPMessageRequestParameters_TemplateId { get; set; }
        #endregion
        
        #region Parameter SendOTPMessageRequestParameters_ValidityPeriod
        /// <summary>
        /// <para>
        /// <para>The time in minutes before the OTP is no longer valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SendOTPMessageRequestParameters_ValidityPeriod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.SendOTPMessageResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.SendOTPMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageResponse";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-PINOTPMessage (SendOTPMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.SendOTPMessageResponse, SendPINOTPMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SendOTPMessageRequestParameters_AllowedAttempt = this.SendOTPMessageRequestParameters_AllowedAttempt;
            context.SendOTPMessageRequestParameters_BrandName = this.SendOTPMessageRequestParameters_BrandName;
            #if MODULAR
            if (this.SendOTPMessageRequestParameters_BrandName == null && ParameterWasBound(nameof(this.SendOTPMessageRequestParameters_BrandName)))
            {
                WriteWarning("You are passing $null as a value for parameter SendOTPMessageRequestParameters_BrandName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SendOTPMessageRequestParameters_Channel = this.SendOTPMessageRequestParameters_Channel;
            #if MODULAR
            if (this.SendOTPMessageRequestParameters_Channel == null && ParameterWasBound(nameof(this.SendOTPMessageRequestParameters_Channel)))
            {
                WriteWarning("You are passing $null as a value for parameter SendOTPMessageRequestParameters_Channel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SendOTPMessageRequestParameters_CodeLength = this.SendOTPMessageRequestParameters_CodeLength;
            context.SendOTPMessageRequestParameters_DestinationIdentity = this.SendOTPMessageRequestParameters_DestinationIdentity;
            #if MODULAR
            if (this.SendOTPMessageRequestParameters_DestinationIdentity == null && ParameterWasBound(nameof(this.SendOTPMessageRequestParameters_DestinationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter SendOTPMessageRequestParameters_DestinationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SendOTPMessageRequestParameters_EntityId = this.SendOTPMessageRequestParameters_EntityId;
            context.SendOTPMessageRequestParameters_Language = this.SendOTPMessageRequestParameters_Language;
            context.SendOTPMessageRequestParameters_OriginationIdentity = this.SendOTPMessageRequestParameters_OriginationIdentity;
            #if MODULAR
            if (this.SendOTPMessageRequestParameters_OriginationIdentity == null && ParameterWasBound(nameof(this.SendOTPMessageRequestParameters_OriginationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter SendOTPMessageRequestParameters_OriginationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SendOTPMessageRequestParameters_ReferenceId = this.SendOTPMessageRequestParameters_ReferenceId;
            #if MODULAR
            if (this.SendOTPMessageRequestParameters_ReferenceId == null && ParameterWasBound(nameof(this.SendOTPMessageRequestParameters_ReferenceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SendOTPMessageRequestParameters_ReferenceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SendOTPMessageRequestParameters_TemplateId = this.SendOTPMessageRequestParameters_TemplateId;
            context.SendOTPMessageRequestParameters_ValidityPeriod = this.SendOTPMessageRequestParameters_ValidityPeriod;
            
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
            var request = new Amazon.Pinpoint.Model.SendOTPMessageRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate SendOTPMessageRequestParameters
            var requestSendOTPMessageRequestParametersIsNull = true;
            request.SendOTPMessageRequestParameters = new Amazon.Pinpoint.Model.SendOTPMessageRequestParameters();
            System.Int32? requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_AllowedAttempt = null;
            if (cmdletContext.SendOTPMessageRequestParameters_AllowedAttempt != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_AllowedAttempt = cmdletContext.SendOTPMessageRequestParameters_AllowedAttempt.Value;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_AllowedAttempt != null)
            {
                request.SendOTPMessageRequestParameters.AllowedAttempts = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_AllowedAttempt.Value;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_BrandName = null;
            if (cmdletContext.SendOTPMessageRequestParameters_BrandName != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_BrandName = cmdletContext.SendOTPMessageRequestParameters_BrandName;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_BrandName != null)
            {
                request.SendOTPMessageRequestParameters.BrandName = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_BrandName;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Channel = null;
            if (cmdletContext.SendOTPMessageRequestParameters_Channel != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Channel = cmdletContext.SendOTPMessageRequestParameters_Channel;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Channel != null)
            {
                request.SendOTPMessageRequestParameters.Channel = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Channel;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.Int32? requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_CodeLength = null;
            if (cmdletContext.SendOTPMessageRequestParameters_CodeLength != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_CodeLength = cmdletContext.SendOTPMessageRequestParameters_CodeLength.Value;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_CodeLength != null)
            {
                request.SendOTPMessageRequestParameters.CodeLength = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_CodeLength.Value;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_DestinationIdentity = null;
            if (cmdletContext.SendOTPMessageRequestParameters_DestinationIdentity != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_DestinationIdentity = cmdletContext.SendOTPMessageRequestParameters_DestinationIdentity;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_DestinationIdentity != null)
            {
                request.SendOTPMessageRequestParameters.DestinationIdentity = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_DestinationIdentity;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_EntityId = null;
            if (cmdletContext.SendOTPMessageRequestParameters_EntityId != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_EntityId = cmdletContext.SendOTPMessageRequestParameters_EntityId;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_EntityId != null)
            {
                request.SendOTPMessageRequestParameters.EntityId = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_EntityId;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Language = null;
            if (cmdletContext.SendOTPMessageRequestParameters_Language != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Language = cmdletContext.SendOTPMessageRequestParameters_Language;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Language != null)
            {
                request.SendOTPMessageRequestParameters.Language = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_Language;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_OriginationIdentity = null;
            if (cmdletContext.SendOTPMessageRequestParameters_OriginationIdentity != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_OriginationIdentity = cmdletContext.SendOTPMessageRequestParameters_OriginationIdentity;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_OriginationIdentity != null)
            {
                request.SendOTPMessageRequestParameters.OriginationIdentity = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_OriginationIdentity;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ReferenceId = null;
            if (cmdletContext.SendOTPMessageRequestParameters_ReferenceId != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ReferenceId = cmdletContext.SendOTPMessageRequestParameters_ReferenceId;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ReferenceId != null)
            {
                request.SendOTPMessageRequestParameters.ReferenceId = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ReferenceId;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.String requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_TemplateId = null;
            if (cmdletContext.SendOTPMessageRequestParameters_TemplateId != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_TemplateId = cmdletContext.SendOTPMessageRequestParameters_TemplateId;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_TemplateId != null)
            {
                request.SendOTPMessageRequestParameters.TemplateId = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_TemplateId;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
            System.Int32? requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ValidityPeriod = null;
            if (cmdletContext.SendOTPMessageRequestParameters_ValidityPeriod != null)
            {
                requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ValidityPeriod = cmdletContext.SendOTPMessageRequestParameters_ValidityPeriod.Value;
            }
            if (requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ValidityPeriod != null)
            {
                request.SendOTPMessageRequestParameters.ValidityPeriod = requestSendOTPMessageRequestParameters_sendOTPMessageRequestParameters_ValidityPeriod.Value;
                requestSendOTPMessageRequestParametersIsNull = false;
            }
             // determine if request.SendOTPMessageRequestParameters should be set to null
            if (requestSendOTPMessageRequestParametersIsNull)
            {
                request.SendOTPMessageRequestParameters = null;
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
        
        private Amazon.Pinpoint.Model.SendOTPMessageResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.SendOTPMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "SendOTPMessage");
            try
            {
                #if DESKTOP
                return client.SendOTPMessage(request);
                #elif CORECLR
                return client.SendOTPMessageAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.Int32? SendOTPMessageRequestParameters_AllowedAttempt { get; set; }
            public System.String SendOTPMessageRequestParameters_BrandName { get; set; }
            public System.String SendOTPMessageRequestParameters_Channel { get; set; }
            public System.Int32? SendOTPMessageRequestParameters_CodeLength { get; set; }
            public System.String SendOTPMessageRequestParameters_DestinationIdentity { get; set; }
            public System.String SendOTPMessageRequestParameters_EntityId { get; set; }
            public System.String SendOTPMessageRequestParameters_Language { get; set; }
            public System.String SendOTPMessageRequestParameters_OriginationIdentity { get; set; }
            public System.String SendOTPMessageRequestParameters_ReferenceId { get; set; }
            public System.String SendOTPMessageRequestParameters_TemplateId { get; set; }
            public System.Int32? SendOTPMessageRequestParameters_ValidityPeriod { get; set; }
            public System.Func<Amazon.Pinpoint.Model.SendOTPMessageResponse, SendPINOTPMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageResponse;
        }
        
    }
}
