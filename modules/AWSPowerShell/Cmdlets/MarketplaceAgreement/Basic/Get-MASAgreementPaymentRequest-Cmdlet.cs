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
    /// Retrieves detailed information about a specific payment request. Both sellers (proposers)
    /// and buyers (acceptors) can use this operation to view payment requests associated
    /// with their agreements. The response includes the current status, charge details, timestamps,
    /// and the charge ID if the request has been approved.
    /// 
    ///  <note><para>
    /// The calling identity must be either the acceptor or proposer of the payment request.
    /// A <c>ResourceNotFoundException</c> is returned if the payment request does not exist.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "MASAgreementPaymentRequest")]
    [OutputType("Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service GetAgreementPaymentRequest API operation.", Operation = new[] {"GetAgreementPaymentRequest"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse",
        "This cmdlet returns an Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse object containing multiple properties."
    )]
    public partial class GetMASAgreementPaymentRequestCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgreementId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agreement associated with the payment request.</para>
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
        
        #region Parameter PaymentRequestId
        /// <summary>
        /// <para>
        /// <para>The identifier of the payment request.</para>
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
        public System.String PaymentRequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse, GetMASAgreementPaymentRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgreementId = this.AgreementId;
            #if MODULAR
            if (this.AgreementId == null && ParameterWasBound(nameof(this.AgreementId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgreementId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentRequestId = this.PaymentRequestId;
            #if MODULAR
            if (this.PaymentRequestId == null && ParameterWasBound(nameof(this.PaymentRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestRequest();
            
            if (cmdletContext.AgreementId != null)
            {
                request.AgreementId = cmdletContext.AgreementId;
            }
            if (cmdletContext.PaymentRequestId != null)
            {
                request.PaymentRequestId = cmdletContext.PaymentRequestId;
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
        
        private Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "GetAgreementPaymentRequest");
            try
            {
                return client.GetAgreementPaymentRequestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgreementId { get; set; }
            public System.String PaymentRequestId { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.GetAgreementPaymentRequestResponse, GetMASAgreementPaymentRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
