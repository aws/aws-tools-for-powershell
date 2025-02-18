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

namespace Amazon.PowerShell.Cmdlets.BCMPC
{
    /// <summary>
    /// Update a newly added or existing usage lines. You can update the usage amounts and
    /// usage group based on a usage ID and a Workload estimate ID. 
    /// 
    ///  <note><para>
    /// The <c>BatchUpdateWorkloadEstimateUsage</c> operation doesn't have its own IAM permission.
    /// To authorize this operation for Amazon Web Services principals, include the permission
    /// <c>bcm-pricing-calculator:UpdateWorkloadEstimateUsage</c> in your policies.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "BCMPCUpdateWorkloadEstimateUsage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse")]
    [AWSCmdlet("Calls the AWS Pricing Calculator BatchUpdateWorkloadEstimateUsage API operation.", Operation = new[] {"BatchUpdateWorkloadEstimateUsage"}, SelectReturnType = typeof(Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse))]
    [AWSCmdletOutput("Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse",
        "This cmdlet returns an Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse object containing multiple properties."
    )]
    public partial class NewBCMPCUpdateWorkloadEstimateUsageCmdlet : AmazonBCMPricingCalculatorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Usage
        /// <summary>
        /// <para>
        /// <para> List of usage line amounts and usage group that you want to update in a Workload
        /// estimate identified by the usage ID. </para>
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
        public Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageEntry[] Usage { get; set; }
        #endregion
        
        #region Parameter WorkloadEstimateId
        /// <summary>
        /// <para>
        /// <para> The ID of the Workload estimate for which you want to modify the usage lines. </para>
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
        public System.String WorkloadEstimateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse).
        /// Specifying the name of a property of type Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkloadEstimateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BCMPCUpdateWorkloadEstimateUsage (BatchUpdateWorkloadEstimateUsage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse, NewBCMPCUpdateWorkloadEstimateUsageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Usage != null)
            {
                context.Usage = new List<Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageEntry>(this.Usage);
            }
            #if MODULAR
            if (this.Usage == null && ParameterWasBound(nameof(this.Usage)))
            {
                WriteWarning("You are passing $null as a value for parameter Usage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkloadEstimateId = this.WorkloadEstimateId;
            #if MODULAR
            if (this.WorkloadEstimateId == null && ParameterWasBound(nameof(this.WorkloadEstimateId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkloadEstimateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageRequest();
            
            if (cmdletContext.Usage != null)
            {
                request.Usage = cmdletContext.Usage;
            }
            if (cmdletContext.WorkloadEstimateId != null)
            {
                request.WorkloadEstimateId = cmdletContext.WorkloadEstimateId;
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
        
        private Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse CallAWSServiceOperation(IAmazonBCMPricingCalculator client, Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Pricing Calculator", "BatchUpdateWorkloadEstimateUsage");
            try
            {
                return client.BatchUpdateWorkloadEstimateUsageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageEntry> Usage { get; set; }
            public System.String WorkloadEstimateId { get; set; }
            public System.Func<Amazon.BCMPricingCalculator.Model.BatchUpdateWorkloadEstimateUsageResponse, NewBCMPCUpdateWorkloadEstimateUsageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
