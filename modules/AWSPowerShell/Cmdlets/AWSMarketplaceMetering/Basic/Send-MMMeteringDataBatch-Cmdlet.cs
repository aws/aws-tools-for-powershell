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
using Amazon.AWSMarketplaceMetering;
using Amazon.AWSMarketplaceMetering.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MM
{
    /// <summary>
    /// <important><para>
    ///  The <c>CustomerIdentifier</c> parameter is scheduled for deprecation. Use <c>CustomerAWSAccountID</c>
    /// instead.
    /// </para><para>
    /// These parameters are mutually exclusive. You can't specify both <c>CustomerIdentifier</c>
    /// and <c>CustomerAWSAccountID</c> in the same request. 
    /// </para></important><para>
    /// To post metering records for customers, SaaS applications call <c>BatchMeterUsage</c>,
    /// which is used for metering SaaS flexible consumption pricing (FCP). Identical requests
    /// are idempotent and can be retried with the same records or a subset of records. Each
    /// <c>BatchMeterUsage</c> request is for only one product. If you want to meter usage
    /// for multiple products, you must make multiple <c>BatchMeterUsage</c> calls.
    /// </para><para>
    /// Usage records should be submitted in quick succession following a recorded event.
    /// Usage records aren't accepted 6 hours or more after an event.
    /// </para><para><c>BatchMeterUsage</c> can process up to 25 <c>UsageRecords</c> at a time, and each
    /// request must be less than 1 MB in size. Optionally, you can have multiple usage allocations
    /// for usage data that's split into buckets according to predefined tags.
    /// </para><para><c>BatchMeterUsage</c> returns a list of <c>UsageRecordResult</c> objects, which
    /// have each <c>UsageRecord</c>. It also returns a list of <c>UnprocessedRecords</c>,
    /// which indicate errors on the service side that should be retried.
    /// </para><para>
    /// For Amazon Web Services Regions that support <c>BatchMeterUsage</c>, see <a href="https://docs.aws.amazon.com/marketplace/latest/APIReference/metering-regions.html#batchmeterusage-region-support">BatchMeterUsage
    /// Region support</a>. 
    /// </para><note><para>
    /// For an example of <c>BatchMeterUsage</c>, see <a href="https://docs.aws.amazon.com/marketplace/latest/userguide/saas-code-examples.html#saas-batchmeterusage-example">
    /// BatchMeterUsage code example</a> in the <i>Amazon Web Services Marketplace Seller
    /// Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "MMMeteringDataBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Metering BatchMeterUsage API operation.", Operation = new[] {"BatchMeterUsage"}, SelectReturnType = typeof(Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse))]
    [AWSCmdletOutput("Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse",
        "This cmdlet returns an Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse object containing multiple properties."
    )]
    public partial class SendMMMeteringDataBatchCmdlet : AmazonAWSMarketplaceMeteringClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProductCode
        /// <summary>
        /// <para>
        /// <para>Product code is used to uniquely identify a product in Amazon Web Services Marketplace.
        /// The product code should be the same as the one used during the publishing of a new
        /// product.</para>
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
        public System.String ProductCode { get; set; }
        #endregion
        
        #region Parameter UsageRecord
        /// <summary>
        /// <para>
        /// <para>The set of <c>UsageRecords</c> to submit. <c>BatchMeterUsage</c> accepts up to 25
        /// <c>UsageRecords</c> at a time.</para><para />
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
        [Alias("UsageRecords")]
        public Amazon.AWSMarketplaceMetering.Model.UsageRecord[] UsageRecord { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse).
        /// Specifying the name of a property of type Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProductCode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MMMeteringDataBatch (BatchMeterUsage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse, SendMMMeteringDataBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProductCode = this.ProductCode;
            #if MODULAR
            if (this.ProductCode == null && ParameterWasBound(nameof(this.ProductCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UsageRecord != null)
            {
                context.UsageRecord = new List<Amazon.AWSMarketplaceMetering.Model.UsageRecord>(this.UsageRecord);
            }
            #if MODULAR
            if (this.UsageRecord == null && ParameterWasBound(nameof(this.UsageRecord)))
            {
                WriteWarning("You are passing $null as a value for parameter UsageRecord which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageRequest();
            
            if (cmdletContext.ProductCode != null)
            {
                request.ProductCode = cmdletContext.ProductCode;
            }
            if (cmdletContext.UsageRecord != null)
            {
                request.UsageRecords = cmdletContext.UsageRecord;
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
        
        private Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse CallAWSServiceOperation(IAmazonAWSMarketplaceMetering client, Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Metering", "BatchMeterUsage");
            try
            {
                return client.BatchMeterUsageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProductCode { get; set; }
            public List<Amazon.AWSMarketplaceMetering.Model.UsageRecord> UsageRecord { get; set; }
            public System.Func<Amazon.AWSMarketplaceMetering.Model.BatchMeterUsageResponse, SendMMMeteringDataBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
