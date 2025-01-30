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
    /// Use the verification code that was received by the verified destination phone number
    /// to opt-in the verified destination phone number to receive more messages.
    /// </summary>
    [Cmdlet("Confirm", "SMSVDestinationNumber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 VerifyDestinationNumber API operation.", Operation = new[] {"VerifyDestinationNumber"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse object containing multiple properties."
    )]
    public partial class ConfirmSMSVDestinationNumberCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VerificationCode
        /// <summary>
        /// <para>
        /// <para>The verification code that was received by the verified destination phone number.</para>
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
        public System.String VerificationCode { get; set; }
        #endregion
        
        #region Parameter VerifiedDestinationNumberId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the verififed destination phone number.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VerifiedDestinationNumberId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VerifiedDestinationNumberId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VerifiedDestinationNumberId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VerifiedDestinationNumberId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-SMSVDestinationNumber (VerifyDestinationNumber)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse, ConfirmSMSVDestinationNumberCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VerifiedDestinationNumberId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.VerificationCode = this.VerificationCode;
            #if MODULAR
            if (this.VerificationCode == null && ParameterWasBound(nameof(this.VerificationCode)))
            {
                WriteWarning("You are passing $null as a value for parameter VerificationCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberRequest();
            
            if (cmdletContext.VerificationCode != null)
            {
                request.VerificationCode = cmdletContext.VerificationCode;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "VerifyDestinationNumber");
            try
            {
                #if DESKTOP
                return client.VerifyDestinationNumber(request);
                #elif CORECLR
                return client.VerifyDestinationNumberAsync(request).GetAwaiter().GetResult();
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
            public System.String VerificationCode { get; set; }
            public System.String VerifiedDestinationNumberId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.VerifyDestinationNumberResponse, ConfirmSMSVDestinationNumberCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
