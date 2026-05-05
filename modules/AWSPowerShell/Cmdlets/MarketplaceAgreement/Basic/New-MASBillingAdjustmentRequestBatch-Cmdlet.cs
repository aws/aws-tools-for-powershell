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
    /// Allows sellers (proposers) to submit billing adjustment requests for one or more invoices
    /// within an agreement. Each entry in the batch specifies an invoice and the adjustment
    /// amount. The operation returns successfully created adjustment request IDs and any
    /// errors for entries that failed to process.
    /// 
    ///  <note><para>
    /// Each entry requires a unique <c>clientToken</c> for idempotency.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "MASBillingAdjustmentRequestBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service BatchCreateBillingAdjustmentRequest API operation.", Operation = new[] {"BatchCreateBillingAdjustmentRequest"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse",
        "This cmdlet returns an Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse object containing multiple properties."
    )]
    public partial class NewMASBillingAdjustmentRequestBatchCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BillingAdjustmentRequestEntry
        /// <summary>
        /// <para>
        /// <para>A list of billing adjustment request entries. Each entry specifies the invoice and
        /// adjustment details.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
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
        [Alias("BillingAdjustmentRequestEntries")]
        public Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestEntry[] BillingAdjustmentRequestEntry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MASBillingAdjustmentRequestBatch (BatchCreateBillingAdjustmentRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse, NewMASBillingAdjustmentRequestBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.BillingAdjustmentRequestEntry != null)
            {
                context.BillingAdjustmentRequestEntry = new List<Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestEntry>(this.BillingAdjustmentRequestEntry);
            }
            #if MODULAR
            if (this.BillingAdjustmentRequestEntry == null && ParameterWasBound(nameof(this.BillingAdjustmentRequestEntry)))
            {
                WriteWarning("You are passing $null as a value for parameter BillingAdjustmentRequestEntry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestRequest();
            
            if (cmdletContext.BillingAdjustmentRequestEntry != null)
            {
                request.BillingAdjustmentRequestEntries = cmdletContext.BillingAdjustmentRequestEntry;
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
        
        private Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "BatchCreateBillingAdjustmentRequest");
            try
            {
                return client.BatchCreateBillingAdjustmentRequestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestEntry> BillingAdjustmentRequestEntry { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.BatchCreateBillingAdjustmentRequestResponse, NewMASBillingAdjustmentRequestBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
