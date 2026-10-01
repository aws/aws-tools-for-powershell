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
using System.Threading;
using Amazon.EndUserMessaging;
using Amazon.EndUserMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EUM
{
    /// <summary>
    /// Validates a one-time passcode that a recipient submitted. Validation succeeds when
    /// the passcode matches, the validity period has not elapsed, and the maximum number
    /// of attempts has not been exceeded.
    /// </summary>
    [Cmdlet("Confirm", "EUMNotifyCodeVerification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EndUserMessaging.VerificationStatus")]
    [AWSCmdlet("Calls the AWS End User Messaging ValidateNotifyCodeVerification API operation.", Operation = new[] {"ValidateNotifyCodeVerification"}, SelectReturnType = typeof(Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse))]
    [AWSCmdletOutput("Amazon.EndUserMessaging.VerificationStatus or Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse",
        "This cmdlet returns an Amazon.EndUserMessaging.VerificationStatus object.",
        "The service call response (type Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConfirmEUMNotifyCodeVerificationCmdlet : AmazonEndUserMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Code
        /// <summary>
        /// <para>
        /// <para>The one-time passcode that the recipient submitted for validation.</para>
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
        public System.String Code { get; set; }
        #endregion
        
        #region Parameter DestinationIdentity
        /// <summary>
        /// <para>
        /// <para>The recipient identifier. For the TEXT and VOICE channels, specify an E.164 phone
        /// number. For the WhatsApp channel, specify a WhatsApp address.</para>
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
        public System.String DestinationIdentity { get; set; }
        #endregion
        
        #region Parameter ReferenceId
        /// <summary>
        /// <para>
        /// <para>The caller-supplied reference identifier used to locate the verification. This value
        /// must match the value that you supplied to the SendNotifyCodeVerification operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReferenceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse).
        /// Specifying the name of a property of type Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-EUMNotifyCodeVerification (ValidateNotifyCodeVerification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse, ConfirmEUMNotifyCodeVerificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Code = this.Code;
            #if MODULAR
            if (this.Code == null && ParameterWasBound(nameof(this.Code)))
            {
                WriteWarning("You are passing $null as a value for parameter Code which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationIdentity = this.DestinationIdentity;
            #if MODULAR
            if (this.DestinationIdentity == null && ParameterWasBound(nameof(this.DestinationIdentity)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationIdentity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReferenceId = this.ReferenceId;
            
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
            var request = new Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationRequest();
            
            if (cmdletContext.Code != null)
            {
                request.Code = cmdletContext.Code;
            }
            if (cmdletContext.DestinationIdentity != null)
            {
                request.DestinationIdentity = cmdletContext.DestinationIdentity;
            }
            if (cmdletContext.ReferenceId != null)
            {
                request.ReferenceId = cmdletContext.ReferenceId;
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
        
        private Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse CallAWSServiceOperation(IAmazonEndUserMessaging client, Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging", "ValidateNotifyCodeVerification");
            try
            {
                return client.ValidateNotifyCodeVerificationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Code { get; set; }
            public System.String DestinationIdentity { get; set; }
            public System.String ReferenceId { get; set; }
            public System.Func<Amazon.EndUserMessaging.Model.ValidateNotifyCodeVerificationResponse, ConfirmEUMNotifyCodeVerificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
