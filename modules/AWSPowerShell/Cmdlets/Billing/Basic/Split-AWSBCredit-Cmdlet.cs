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
    /// Splits the available balance of a credit into 2 to 99 new credits in the same account,
    /// and cancels the original credit. The new credits keep the original credit's end date
    /// and applicable products.
    /// 
    ///  
    /// <para>
    /// The available balance is the remaining balance minus any amount reserved for a bill
    /// that isn't finalized. The portions must add up to exactly the available balance. Each
    /// portion must be at least 100.00 in the currency of the credit. For example, if the
    /// credit is in USD, each portion must be at least USD $100.00. A reserved amount stays
    /// on the original credit and still applies to that bill.
    /// </para><para>
    /// A credit and every credit split from it count toward a limit of 100 credits. After
    /// a split, you can't split or transfer the original credit. You can split or transfer
    /// its new credits, and you can split a credit after you transfer it.
    /// </para><para>
    /// You must own the credit or be the payer of the account that owns it. You can't undo
    /// a split. This operation is idempotent and supports a dry run.
    /// </para>
    /// </summary>
    [Cmdlet("Split", "AWSBCredit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Billing.Model.SplitCreditResponse")]
    [AWSCmdlet("Calls the AWS Billing SplitCredit API operation.", Operation = new[] {"SplitCredit"}, SelectReturnType = typeof(Amazon.Billing.Model.SplitCreditResponse))]
    [AWSCmdletOutput("Amazon.Billing.Model.SplitCreditResponse",
        "This cmdlet returns an Amazon.Billing.Model.SplitCreditResponse object containing multiple properties."
    )]
    public partial class SplitAWSBCreditCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreditId
        /// <summary>
        /// <para>
        /// <para>The ID of the credit to split.</para>
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
        public System.String CreditId { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Specifies whether to validate the request and return the result without changing any
        /// credit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter Portion
        /// <summary>
        /// <para>
        /// <para>The new credits to create, one for each portion, in the order listed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Portions")]
        public Amazon.Billing.Model.SplitPortion[] Portion { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.SplitCreditResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.SplitCreditResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Split-AWSBCredit (SplitCredit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.SplitCreditResponse, SplitAWSBCreditCmdlet>(Select) ??
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
            context.DryRun = this.DryRun;
            if (this.Portion != null)
            {
                context.Portion = new List<Amazon.Billing.Model.SplitPortion>(this.Portion);
            }
            #if MODULAR
            if (this.Portion == null && ParameterWasBound(nameof(this.Portion)))
            {
                WriteWarning("You are passing $null as a value for parameter Portion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Billing.Model.SplitCreditRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CreditId != null)
            {
                request.CreditId = cmdletContext.CreditId;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Portion != null)
            {
                request.Portions = cmdletContext.Portion;
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
        
        private Amazon.Billing.Model.SplitCreditResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.SplitCreditRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "SplitCredit");
            try
            {
                return client.SplitCreditAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public List<Amazon.Billing.Model.SplitPortion> Portion { get; set; }
            public System.Func<Amazon.Billing.Model.SplitCreditResponse, SplitAWSBCreditCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
