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
using Amazon.CostOptimizationHub;
using Amazon.CostOptimizationHub.Model;

namespace Amazon.PowerShell.Cmdlets.COH
{
    /// <summary>
    /// Updates a set of preferences for an account in order to add account-specific preferences
    /// into the service. These preferences impact how the savings associated with recommendations
    /// are presented.
    /// </summary>
    [Cmdlet("Update", "COHPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse")]
    [AWSCmdlet("Calls the Cost Optimization Hub UpdatePreferences API operation.", Operation = new[] {"UpdatePreferences"}, SelectReturnType = typeof(Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse))]
    [AWSCmdletOutput("Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse",
        "This cmdlet returns an Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse object containing multiple properties."
    )]
    public partial class UpdateCOHPreferenceCmdlet : AmazonCostOptimizationHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MemberAccountDiscountVisibility
        /// <summary>
        /// <para>
        /// <para>Sets the "member account discount visibility" preference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostOptimizationHub.MemberAccountDiscountVisibility")]
        public Amazon.CostOptimizationHub.MemberAccountDiscountVisibility MemberAccountDiscountVisibility { get; set; }
        #endregion
        
        #region Parameter PreferredCommitment_PaymentOption
        /// <summary>
        /// <para>
        /// <para>The preferred upfront payment structure for commitments. If the value is null, it
        /// will default to <c>AllUpfront</c> (highest savings) where applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostOptimizationHub.PaymentOption")]
        public Amazon.CostOptimizationHub.PaymentOption PreferredCommitment_PaymentOption { get; set; }
        #endregion
        
        #region Parameter SavingsEstimationMode
        /// <summary>
        /// <para>
        /// <para>Sets the "savings estimation mode" preference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostOptimizationHub.SavingsEstimationMode")]
        public Amazon.CostOptimizationHub.SavingsEstimationMode SavingsEstimationMode { get; set; }
        #endregion
        
        #region Parameter PreferredCommitment_Term
        /// <summary>
        /// <para>
        /// <para>The preferred length of the commitment period. If the value is null, it will default
        /// to <c>ThreeYears</c> (highest savings) where applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostOptimizationHub.Term")]
        public Amazon.CostOptimizationHub.Term PreferredCommitment_Term { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse).
        /// Specifying the name of a property of type Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-COHPreference (UpdatePreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse, UpdateCOHPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MemberAccountDiscountVisibility = this.MemberAccountDiscountVisibility;
            context.PreferredCommitment_PaymentOption = this.PreferredCommitment_PaymentOption;
            context.PreferredCommitment_Term = this.PreferredCommitment_Term;
            context.SavingsEstimationMode = this.SavingsEstimationMode;
            
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
            var request = new Amazon.CostOptimizationHub.Model.UpdatePreferencesRequest();
            
            if (cmdletContext.MemberAccountDiscountVisibility != null)
            {
                request.MemberAccountDiscountVisibility = cmdletContext.MemberAccountDiscountVisibility;
            }
            
             // populate PreferredCommitment
            var requestPreferredCommitmentIsNull = true;
            request.PreferredCommitment = new Amazon.CostOptimizationHub.Model.PreferredCommitment();
            Amazon.CostOptimizationHub.PaymentOption requestPreferredCommitment_preferredCommitment_PaymentOption = null;
            if (cmdletContext.PreferredCommitment_PaymentOption != null)
            {
                requestPreferredCommitment_preferredCommitment_PaymentOption = cmdletContext.PreferredCommitment_PaymentOption;
            }
            if (requestPreferredCommitment_preferredCommitment_PaymentOption != null)
            {
                request.PreferredCommitment.PaymentOption = requestPreferredCommitment_preferredCommitment_PaymentOption;
                requestPreferredCommitmentIsNull = false;
            }
            Amazon.CostOptimizationHub.Term requestPreferredCommitment_preferredCommitment_Term = null;
            if (cmdletContext.PreferredCommitment_Term != null)
            {
                requestPreferredCommitment_preferredCommitment_Term = cmdletContext.PreferredCommitment_Term;
            }
            if (requestPreferredCommitment_preferredCommitment_Term != null)
            {
                request.PreferredCommitment.Term = requestPreferredCommitment_preferredCommitment_Term;
                requestPreferredCommitmentIsNull = false;
            }
             // determine if request.PreferredCommitment should be set to null
            if (requestPreferredCommitmentIsNull)
            {
                request.PreferredCommitment = null;
            }
            if (cmdletContext.SavingsEstimationMode != null)
            {
                request.SavingsEstimationMode = cmdletContext.SavingsEstimationMode;
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
        
        private Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse CallAWSServiceOperation(IAmazonCostOptimizationHub client, Amazon.CostOptimizationHub.Model.UpdatePreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Cost Optimization Hub", "UpdatePreferences");
            try
            {
                #if DESKTOP
                return client.UpdatePreferences(request);
                #elif CORECLR
                return client.UpdatePreferencesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CostOptimizationHub.MemberAccountDiscountVisibility MemberAccountDiscountVisibility { get; set; }
            public Amazon.CostOptimizationHub.PaymentOption PreferredCommitment_PaymentOption { get; set; }
            public Amazon.CostOptimizationHub.Term PreferredCommitment_Term { get; set; }
            public Amazon.CostOptimizationHub.SavingsEstimationMode SavingsEstimationMode { get; set; }
            public System.Func<Amazon.CostOptimizationHub.Model.UpdatePreferencesResponse, UpdateCOHPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
