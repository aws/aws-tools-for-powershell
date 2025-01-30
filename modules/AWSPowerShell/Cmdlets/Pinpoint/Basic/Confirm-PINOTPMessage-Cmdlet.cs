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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Verify an OTP
    /// </summary>
    [Cmdlet("Confirm", "PINOTPMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.VerificationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint VerifyOTPMessage API operation.", Operation = new[] {"VerifyOTPMessage"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.VerifyOTPMessageResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.VerificationResponse or Amazon.Pinpoint.Model.VerifyOTPMessageResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.VerificationResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.VerifyOTPMessageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConfirmPINOTPMessageCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter VerifyOTPMessageRequestParameters_DestinationIdentity
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
        public System.String VerifyOTPMessageRequestParameters_DestinationIdentity { get; set; }
        #endregion
        
        #region Parameter VerifyOTPMessageRequestParameters_Otp
        /// <summary>
        /// <para>
        /// <para>The OTP the end user provided for verification.</para>
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
        public System.String VerifyOTPMessageRequestParameters_Otp { get; set; }
        #endregion
        
        #region Parameter VerifyOTPMessageRequestParameters_ReferenceId
        /// <summary>
        /// <para>
        /// <para>The reference identifier provided when the OTP was previously sent.</para>
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
        public System.String VerifyOTPMessageRequestParameters_ReferenceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VerificationResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.VerifyOTPMessageResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.VerifyOTPMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VerificationResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-PINOTPMessage (VerifyOTPMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.VerifyOTPMessageResponse, ConfirmPINOTPMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerifyOTPMessageRequestParameters_DestinationIdentity = this.VerifyOTPMessageRequestParameters_DestinationIdentity;
            #if MODULAR
            if (this.VerifyOTPMessageRequestParameters_DestinationIdentity == null && ParameterWasBound(nameof(this.VerifyOTPMessageRequestParameters_DestinationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifyOTPMessageRequestParameters_DestinationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerifyOTPMessageRequestParameters_Otp = this.VerifyOTPMessageRequestParameters_Otp;
            #if MODULAR
            if (this.VerifyOTPMessageRequestParameters_Otp == null && ParameterWasBound(nameof(this.VerifyOTPMessageRequestParameters_Otp)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifyOTPMessageRequestParameters_Otp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerifyOTPMessageRequestParameters_ReferenceId = this.VerifyOTPMessageRequestParameters_ReferenceId;
            #if MODULAR
            if (this.VerifyOTPMessageRequestParameters_ReferenceId == null && ParameterWasBound(nameof(this.VerifyOTPMessageRequestParameters_ReferenceId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifyOTPMessageRequestParameters_ReferenceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.VerifyOTPMessageRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate VerifyOTPMessageRequestParameters
            var requestVerifyOTPMessageRequestParametersIsNull = true;
            request.VerifyOTPMessageRequestParameters = new Amazon.Pinpoint.Model.VerifyOTPMessageRequestParameters();
            System.String requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_DestinationIdentity = null;
            if (cmdletContext.VerifyOTPMessageRequestParameters_DestinationIdentity != null)
            {
                requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_DestinationIdentity = cmdletContext.VerifyOTPMessageRequestParameters_DestinationIdentity;
            }
            if (requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_DestinationIdentity != null)
            {
                request.VerifyOTPMessageRequestParameters.DestinationIdentity = requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_DestinationIdentity;
                requestVerifyOTPMessageRequestParametersIsNull = false;
            }
            System.String requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_Otp = null;
            if (cmdletContext.VerifyOTPMessageRequestParameters_Otp != null)
            {
                requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_Otp = cmdletContext.VerifyOTPMessageRequestParameters_Otp;
            }
            if (requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_Otp != null)
            {
                request.VerifyOTPMessageRequestParameters.Otp = requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_Otp;
                requestVerifyOTPMessageRequestParametersIsNull = false;
            }
            System.String requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_ReferenceId = null;
            if (cmdletContext.VerifyOTPMessageRequestParameters_ReferenceId != null)
            {
                requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_ReferenceId = cmdletContext.VerifyOTPMessageRequestParameters_ReferenceId;
            }
            if (requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_ReferenceId != null)
            {
                request.VerifyOTPMessageRequestParameters.ReferenceId = requestVerifyOTPMessageRequestParameters_verifyOTPMessageRequestParameters_ReferenceId;
                requestVerifyOTPMessageRequestParametersIsNull = false;
            }
             // determine if request.VerifyOTPMessageRequestParameters should be set to null
            if (requestVerifyOTPMessageRequestParametersIsNull)
            {
                request.VerifyOTPMessageRequestParameters = null;
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
        
        private Amazon.Pinpoint.Model.VerifyOTPMessageResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.VerifyOTPMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "VerifyOTPMessage");
            try
            {
                #if DESKTOP
                return client.VerifyOTPMessage(request);
                #elif CORECLR
                return client.VerifyOTPMessageAsync(request).GetAwaiter().GetResult();
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
            public System.String VerifyOTPMessageRequestParameters_DestinationIdentity { get; set; }
            public System.String VerifyOTPMessageRequestParameters_Otp { get; set; }
            public System.String VerifyOTPMessageRequestParameters_ReferenceId { get; set; }
            public System.Func<Amazon.Pinpoint.Model.VerifyOTPMessageResponse, ConfirmPINOTPMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VerificationResponse;
        }
        
    }
}
