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
using Amazon.Invoicing;
using Amazon.Invoicing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INV
{
    /// <summary>
    /// <i><b>This feature API is subject to changing at any time. For more information,
    /// see the <a href="https://aws.amazon.com/service-terms/">Amazon Web Services Service
    /// Terms</a> (Betas and Previews).</b></i><para>
    /// Sends a validation request for a procurement portal preference. This operation initiates
    /// the validation process by issuing a validation code that confirms ownership and connectivity
    /// of the configured procurement portal endpoint. Use <c>VerifyProcurementPortalValidation</c>
    /// to submit the received code and complete validation.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "INVProcurementPortalValidation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Invoicing SendProcurementPortalValidation API operation.", Operation = new[] {"SendProcurementPortalValidation"}, SelectReturnType = typeof(Amazon.Invoicing.Model.SendProcurementPortalValidationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Invoicing.Model.SendProcurementPortalValidationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Invoicing.Model.SendProcurementPortalValidationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendINVProcurementPortalValidationCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProcurementPortalPreferenceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the procurement portal preference to validate.</para>
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
        public System.String ProcurementPortalPreferenceArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ProcurementPortalPreferenceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.SendProcurementPortalValidationResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.SendProcurementPortalValidationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ProcurementPortalPreferenceArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProcurementPortalPreferenceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-INVProcurementPortalValidation (SendProcurementPortalValidation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.SendProcurementPortalValidationResponse, SendINVProcurementPortalValidationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ProcurementPortalPreferenceArn = this.ProcurementPortalPreferenceArn;
            #if MODULAR
            if (this.ProcurementPortalPreferenceArn == null && ParameterWasBound(nameof(this.ProcurementPortalPreferenceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProcurementPortalPreferenceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Invoicing.Model.SendProcurementPortalValidationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ProcurementPortalPreferenceArn != null)
            {
                request.ProcurementPortalPreferenceArn = cmdletContext.ProcurementPortalPreferenceArn;
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
        
        private Amazon.Invoicing.Model.SendProcurementPortalValidationResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.SendProcurementPortalValidationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "SendProcurementPortalValidation");
            try
            {
                return client.SendProcurementPortalValidationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProcurementPortalPreferenceArn { get; set; }
            public System.Func<Amazon.Invoicing.Model.SendProcurementPortalValidationResponse, SendINVProcurementPortalValidationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ProcurementPortalPreferenceArn;
        }
        
    }
}
