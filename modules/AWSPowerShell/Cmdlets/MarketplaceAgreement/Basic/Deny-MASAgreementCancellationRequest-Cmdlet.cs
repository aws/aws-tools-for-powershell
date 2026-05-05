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
using Amazon.MarketplaceAgreement;
using Amazon.MarketplaceAgreement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAS
{
    /// <summary>
    /// Allows buyers (acceptors) to reject a cancellation request that is in <c>PENDING_APPROVAL</c>
    /// status. Once rejected, the cancellation request transitions to <c>REJECTED</c> status
    /// and the agreement remains active. Buyers must provide a reason for the rejection.
    /// 
    ///  <note><para>
    /// Only cancellation requests in <c>PENDING_APPROVAL</c> status can be rejected. A <c>ConflictException</c>
    /// is thrown if the cancellation request is in any other status.
    /// </para></note>
    /// </summary>
    [Cmdlet("Deny", "MASAgreementCancellationRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service RejectAgreementCancellationRequest API operation.", Operation = new[] {"RejectAgreementCancellationRequest"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse",
        "This cmdlet returns an Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse object containing multiple properties."
    )]
    public partial class DenyMASAgreementCancellationRequestCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgreementCancellationRequestId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cancellation request to reject.</para>
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
        public System.String AgreementCancellationRequestId { get; set; }
        #endregion
        
        #region Parameter AgreementId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agreement associated with the cancellation request.</para>
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
        public System.String AgreementId { get; set; }
        #endregion
        
        #region Parameter RejectionReason
        /// <summary>
        /// <para>
        /// <para>The reason for rejecting the cancellation request (1-2000 characters). This message
        /// is visible to the seller.</para>
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
        public System.String RejectionReason { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgreementCancellationRequestId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Deny-MASAgreementCancellationRequest (RejectAgreementCancellationRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse, DenyMASAgreementCancellationRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgreementCancellationRequestId = this.AgreementCancellationRequestId;
            #if MODULAR
            if (this.AgreementCancellationRequestId == null && ParameterWasBound(nameof(this.AgreementCancellationRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgreementCancellationRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgreementId = this.AgreementId;
            #if MODULAR
            if (this.AgreementId == null && ParameterWasBound(nameof(this.AgreementId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgreementId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RejectionReason = this.RejectionReason;
            #if MODULAR
            if (this.RejectionReason == null && ParameterWasBound(nameof(this.RejectionReason)))
            {
                WriteWarning("You are passing $null as a value for parameter RejectionReason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestRequest();
            
            if (cmdletContext.AgreementCancellationRequestId != null)
            {
                request.AgreementCancellationRequestId = cmdletContext.AgreementCancellationRequestId;
            }
            if (cmdletContext.AgreementId != null)
            {
                request.AgreementId = cmdletContext.AgreementId;
            }
            if (cmdletContext.RejectionReason != null)
            {
                request.RejectionReason = cmdletContext.RejectionReason;
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
        
        private Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "RejectAgreementCancellationRequest");
            try
            {
                return client.RejectAgreementCancellationRequestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgreementCancellationRequestId { get; set; }
            public System.String AgreementId { get; set; }
            public System.String RejectionReason { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.RejectAgreementCancellationRequestResponse, DenyMASAgreementCancellationRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
