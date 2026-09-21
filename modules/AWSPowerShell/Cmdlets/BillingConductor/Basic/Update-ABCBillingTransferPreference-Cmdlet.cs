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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// Sets the auto billing group creation preference for a billing transfer. When the preference
    /// is enabled, Billing Conductor automatically creates an indirect billing transfer billing
    /// group in your account, with the pricing plan that you specify, for each account that
    /// transfers its bill to the bill source account of this billing transfer. The preference
    /// applies only to billing groups that are created after you enable it.
    /// 
    ///  
    /// <para>
    /// Enabling the preference requires the <c>iam:CreateServiceLinkedRole</c> permission.
    /// While a pricing plan is specified in an enabled preference, you can't delete that
    /// pricing plan.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ABCBillingTransferPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor UpdateBillingTransferPreference API operation.", Operation = new[] {"UpdateBillingTransferPreference"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse object containing multiple properties."
    )]
    public partial class UpdateABCBillingTransferPreferenceCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoBillingTransferBillingGroupCreation_Enabled
        /// <summary>
        /// <para>
        /// <para> Specifies whether Billing Conductor automatically creates billing groups for the
        /// billing transfer. The preference is disabled by default. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AutoBillingTransferBillingGroupCreation_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoBillingTransferBillingGroupCreation_PricingPlanArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the pricing plan to apply to the automatically
        /// created billing groups. This value is required when <c>Enabled</c> is <c>true</c>,
        /// and must be omitted when <c>Enabled</c> is <c>false</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoBillingTransferBillingGroupCreation_PricingPlanArn { get; set; }
        #endregion
        
        #region Parameter ResponsibilityTransferArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the billing transfer whose preference you want to
        /// set.</para>
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
        public System.String ResponsibilityTransferArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you specify to ensure idempotency of the
        /// request. Idempotency ensures that an API request completes no more than one time.
        /// With an idempotent request, if the original request completes successfully, any subsequent
        /// retries complete successfully without performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResponsibilityTransferArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ABCBillingTransferPreference (UpdateBillingTransferPreference)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse, UpdateABCBillingTransferPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoBillingTransferBillingGroupCreation_Enabled = this.AutoBillingTransferBillingGroupCreation_Enabled;
            #if MODULAR
            if (this.AutoBillingTransferBillingGroupCreation_Enabled == null && ParameterWasBound(nameof(this.AutoBillingTransferBillingGroupCreation_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoBillingTransferBillingGroupCreation_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoBillingTransferBillingGroupCreation_PricingPlanArn = this.AutoBillingTransferBillingGroupCreation_PricingPlanArn;
            context.ClientToken = this.ClientToken;
            context.ResponsibilityTransferArn = this.ResponsibilityTransferArn;
            #if MODULAR
            if (this.ResponsibilityTransferArn == null && ParameterWasBound(nameof(this.ResponsibilityTransferArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResponsibilityTransferArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceRequest();
            
            
             // populate AutoBillingTransferBillingGroupCreation
            var requestAutoBillingTransferBillingGroupCreationIsNull = true;
            request.AutoBillingTransferBillingGroupCreation = new Amazon.BillingConductor.Model.AutoTransferBillingGroupCreationPreference();
            System.Boolean? requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_Enabled = null;
            if (cmdletContext.AutoBillingTransferBillingGroupCreation_Enabled != null)
            {
                requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_Enabled = cmdletContext.AutoBillingTransferBillingGroupCreation_Enabled.Value;
            }
            if (requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_Enabled != null)
            {
                request.AutoBillingTransferBillingGroupCreation.Enabled = requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_Enabled.Value;
                requestAutoBillingTransferBillingGroupCreationIsNull = false;
            }
            System.String requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_PricingPlanArn = null;
            if (cmdletContext.AutoBillingTransferBillingGroupCreation_PricingPlanArn != null)
            {
                requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_PricingPlanArn = cmdletContext.AutoBillingTransferBillingGroupCreation_PricingPlanArn;
            }
            if (requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_PricingPlanArn != null)
            {
                request.AutoBillingTransferBillingGroupCreation.PricingPlanArn = requestAutoBillingTransferBillingGroupCreation_autoBillingTransferBillingGroupCreation_PricingPlanArn;
                requestAutoBillingTransferBillingGroupCreationIsNull = false;
            }
             // determine if request.AutoBillingTransferBillingGroupCreation should be set to null
            if (requestAutoBillingTransferBillingGroupCreationIsNull)
            {
                request.AutoBillingTransferBillingGroupCreation = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ResponsibilityTransferArn != null)
            {
                request.ResponsibilityTransferArn = cmdletContext.ResponsibilityTransferArn;
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
        
        private Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "UpdateBillingTransferPreference");
            try
            {
                return client.UpdateBillingTransferPreferenceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutoBillingTransferBillingGroupCreation_Enabled { get; set; }
            public System.String AutoBillingTransferBillingGroupCreation_PricingPlanArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ResponsibilityTransferArn { get; set; }
            public System.Func<Amazon.BillingConductor.Model.UpdateBillingTransferPreferenceResponse, UpdateABCBillingTransferPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
