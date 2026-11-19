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
using Amazon.BCMPricingCalculator;
using Amazon.BCMPricingCalculator.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BCMPC
{
    /// <summary>
    /// Retrieves the estimated cost of a list of usage lines. Each usage line identifies
    /// a billing line by its service code, usage type, and operation, and includes the usage
    /// amount to price. The estimate is based on Amazon Web Services pricing data and the
    /// rate type you choose. It doesn't include taxes, and your actual charges depend on
    /// your usage. 
    /// 
    ///  
    /// <para>
    ///  The response includes the estimated cost of each usage line that was priced. It also
    /// includes each usage line that couldn't be priced, and the reason it couldn't be priced.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "BCMPCUsageLinesEstimatedCost")]
    [OutputType("Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse")]
    [AWSCmdlet("Calls the AWS Billing and Cost Management Pricing Calculator GetUsageLinesEstimatedCost API operation.", Operation = new[] {"GetUsageLinesEstimatedCost"}, SelectReturnType = typeof(Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse))]
    [AWSCmdletOutput("Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse",
        "This cmdlet returns an Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse object containing multiple properties."
    )]
    public partial class GetBCMPCUsageLinesEstimatedCostCmdlet : AmazonBCMPricingCalculatorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RateType
        /// <summary>
        /// <para>
        /// <para> The type of pricing rates to use to estimate the cost of the usage lines. You can
        /// only use a rate type that your Pricing Calculator rate preferences allow. If you use
        /// billing transfer as a bill source account, you can only use BEFORE_DISCOUNTS </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BCMPricingCalculator.RateType")]
        public Amazon.BCMPricingCalculator.RateType RateType { get; set; }
        #endregion
        
        #region Parameter Usage
        /// <summary>
        /// <para>
        /// <para> The usage lines that you want to estimate. You can include up to 500 usage lines
        /// in a request. </para><para />
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
        public Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostInput[] Usage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse).
        /// Specifying the name of a property of type Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse, GetBCMPCUsageLinesEstimatedCostCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RateType = this.RateType;
            #if MODULAR
            if (this.RateType == null && ParameterWasBound(nameof(this.RateType)))
            {
                WriteWarning("You are passing $null as a value for parameter RateType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Usage != null)
            {
                context.Usage = new List<Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostInput>(this.Usage);
            }
            #if MODULAR
            if (this.Usage == null && ParameterWasBound(nameof(this.Usage)))
            {
                WriteWarning("You are passing $null as a value for parameter Usage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostRequest();
            
            if (cmdletContext.RateType != null)
            {
                request.RateType = cmdletContext.RateType;
            }
            if (cmdletContext.Usage != null)
            {
                request.Usage = cmdletContext.Usage;
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
        
        private Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse CallAWSServiceOperation(IAmazonBCMPricingCalculator client, Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing and Cost Management Pricing Calculator", "GetUsageLinesEstimatedCost");
            try
            {
                return client.GetUsageLinesEstimatedCostAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.BCMPricingCalculator.RateType RateType { get; set; }
            public List<Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostInput> Usage { get; set; }
            public System.Func<Amazon.BCMPricingCalculator.Model.GetUsageLinesEstimatedCostResponse, GetBCMPCUsageLinesEstimatedCostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
