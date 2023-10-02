/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Requests a Savings Plans recommendation generation. This enables you to calculate
    /// a fresh set of Savings Plans recommendations that takes your latest usage data and
    /// current Savings Plans inventory into account. You can refresh Savings Plans recommendations
    /// up to three times daily for a consolidated billing family.
    /// 
    ///  <note><para><code>StartSavingsPlansPurchaseRecommendationGeneration</code> has no request syntax
    /// because no input parameters are needed to support this operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "CESavingsPlansPurchaseRecommendationGeneration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer StartSavingsPlansPurchaseRecommendationGeneration API operation.", Operation = new[] {"StartSavingsPlansPurchaseRecommendationGeneration"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCESavingsPlansPurchaseRecommendationGenerationCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CESavingsPlansPurchaseRecommendationGeneration (StartSavingsPlansPurchaseRecommendationGeneration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse, StartCESavingsPlansPurchaseRecommendationGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            
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
            var request = new Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationRequest();
            
            
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
        
        private Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "StartSavingsPlansPurchaseRecommendationGeneration");
            try
            {
                #if DESKTOP
                return client.StartSavingsPlansPurchaseRecommendationGeneration(request);
                #elif CORECLR
                return client.StartSavingsPlansPurchaseRecommendationGenerationAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.Func<Amazon.CostExplorer.Model.StartSavingsPlansPurchaseRecommendationGenerationResponse, StartCESavingsPlansPurchaseRecommendationGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
