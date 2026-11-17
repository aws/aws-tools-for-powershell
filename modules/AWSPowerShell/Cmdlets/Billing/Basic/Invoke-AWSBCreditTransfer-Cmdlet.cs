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
using Amazon.Billing;
using Amazon.Billing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// Moves a credit to another account in the same consolidated billing family. The credit
    /// keeps its ID, balance, end date, and applicable products. Only the account that owns
    /// the credit changes.
    /// 
    ///  
    /// <para>
    /// The transfer removes the credit's sharing settings. The new owner or the payer can
    /// set them again. Any amount reserved for a bill that isn't finalized moves with the
    /// credit and still applies to that bill.
    /// </para><para>
    /// You must be the payer of both accounts. You can't transfer a credit that has ended,
    /// has no available balance, or is the original credit of a split. A transfer creates
    /// no credit, so it doesn't count toward the split limit, and the payer can transfer
    /// the credit back. This operation is idempotent and supports a dry run.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "AWSBCreditTransfer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Billing.Model.TransferCreditResponse")]
    [AWSCmdlet("Calls the AWS Billing TransferCredit API operation.", Operation = new[] {"TransferCredit"}, SelectReturnType = typeof(Amazon.Billing.Model.TransferCreditResponse))]
    [AWSCmdletOutput("Amazon.Billing.Model.TransferCreditResponse",
        "This cmdlet returns an Amazon.Billing.Model.TransferCreditResponse object containing multiple properties."
    )]
    public partial class InvokeAWSBCreditTransferCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreditId
        /// <summary>
        /// <para>
        /// <para>The ID of the credit to transfer.</para>
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
        public System.String CreditId { get; set; }
        #endregion
        
        #region Parameter DestinationAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that becomes the owner of the credit. The account
        /// must be in your consolidated billing family and must not be the current owner.</para>
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
        public System.String DestinationAccountId { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Specifies whether to validate the request and return the result without changing the
        /// credit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If you retry a successful request with the same client
        /// token and parameters, the retry completes without performing any further actions.
        /// If you reuse a client token with different parameters, the request fails with a <c>ValidationException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.TransferCreditResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.TransferCreditResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CreditId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-AWSBCreditTransfer (TransferCredit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.TransferCreditResponse, InvokeAWSBCreditTransferCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CreditId = this.CreditId;
            #if MODULAR
            if (this.CreditId == null && ParameterWasBound(nameof(this.CreditId)))
            {
                WriteWarning("You are passing $null as a value for parameter CreditId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationAccountId = this.DestinationAccountId;
            #if MODULAR
            if (this.DestinationAccountId == null && ParameterWasBound(nameof(this.DestinationAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            
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
            var request = new Amazon.Billing.Model.TransferCreditRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CreditId != null)
            {
                request.CreditId = cmdletContext.CreditId;
            }
            if (cmdletContext.DestinationAccountId != null)
            {
                request.DestinationAccountId = cmdletContext.DestinationAccountId;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
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
        
        private Amazon.Billing.Model.TransferCreditResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.TransferCreditRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "TransferCredit");
            try
            {
                return client.TransferCreditAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CreditId { get; set; }
            public System.String DestinationAccountId { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Func<Amazon.Billing.Model.TransferCreditResponse, InvokeAWSBCreditTransferCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
