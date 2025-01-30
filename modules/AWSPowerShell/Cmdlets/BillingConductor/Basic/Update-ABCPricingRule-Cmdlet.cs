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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// Updates an existing pricing rule.
    /// </summary>
    [Cmdlet("Update", "ABCPricingRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BillingConductor.Model.UpdatePricingRuleResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor UpdatePricingRule API operation.", Operation = new[] {"UpdatePricingRule"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.UpdatePricingRuleResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.UpdatePricingRuleResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.UpdatePricingRuleResponse object containing multiple properties."
    )]
    public partial class UpdateABCPricingRuleCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FreeTier_Activated
        /// <summary>
        /// <para>
        /// <para> Activate or deactivate application of Amazon Web Services Free Tier. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tiering_FreeTier_Activated")]
        public System.Boolean? FreeTier_Activated { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the pricing rule to update. </para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The new description for the pricing rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ModifierPercentage
        /// <summary>
        /// <para>
        /// <para> The new modifier to show pricing plan rates as a percentage. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ModifierPercentage { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The new name of the pricing rule. The name must be unique to each pricing rule. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para> The new pricing rule type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BillingConductor.PricingRuleType")]
        public Amazon.BillingConductor.PricingRuleType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.UpdatePricingRuleResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.UpdatePricingRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ABCPricingRule (UpdatePricingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.UpdatePricingRuleResponse, UpdateABCPricingRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.ModifierPercentage = this.ModifierPercentage;
            context.Name = this.Name;
            context.FreeTier_Activated = this.FreeTier_Activated;
            context.Type = this.Type;
            
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
            var request = new Amazon.BillingConductor.Model.UpdatePricingRuleRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ModifierPercentage != null)
            {
                request.ModifierPercentage = cmdletContext.ModifierPercentage.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Tiering
            var requestTieringIsNull = true;
            request.Tiering = new Amazon.BillingConductor.Model.UpdateTieringInput();
            Amazon.BillingConductor.Model.UpdateFreeTierConfig requestTiering_tiering_FreeTier = null;
            
             // populate FreeTier
            var requestTiering_tiering_FreeTierIsNull = true;
            requestTiering_tiering_FreeTier = new Amazon.BillingConductor.Model.UpdateFreeTierConfig();
            System.Boolean? requestTiering_tiering_FreeTier_freeTier_Activated = null;
            if (cmdletContext.FreeTier_Activated != null)
            {
                requestTiering_tiering_FreeTier_freeTier_Activated = cmdletContext.FreeTier_Activated.Value;
            }
            if (requestTiering_tiering_FreeTier_freeTier_Activated != null)
            {
                requestTiering_tiering_FreeTier.Activated = requestTiering_tiering_FreeTier_freeTier_Activated.Value;
                requestTiering_tiering_FreeTierIsNull = false;
            }
             // determine if requestTiering_tiering_FreeTier should be set to null
            if (requestTiering_tiering_FreeTierIsNull)
            {
                requestTiering_tiering_FreeTier = null;
            }
            if (requestTiering_tiering_FreeTier != null)
            {
                request.Tiering.FreeTier = requestTiering_tiering_FreeTier;
                requestTieringIsNull = false;
            }
             // determine if request.Tiering should be set to null
            if (requestTieringIsNull)
            {
                request.Tiering = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.BillingConductor.Model.UpdatePricingRuleResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.UpdatePricingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "UpdatePricingRule");
            try
            {
                #if DESKTOP
                return client.UpdatePricingRule(request);
                #elif CORECLR
                return client.UpdatePricingRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String Description { get; set; }
            public System.Double? ModifierPercentage { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? FreeTier_Activated { get; set; }
            public Amazon.BillingConductor.PricingRuleType Type { get; set; }
            public System.Func<Amazon.BillingConductor.Model.UpdatePricingRuleResponse, UpdateABCPricingRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
