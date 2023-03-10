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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// Creates a pricing rule can be associated to a pricing plan, or a set of pricing plans.
    /// </summary>
    [Cmdlet("New", "ABCPricingRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSBillingConductor CreatePricingRule API operation.", Operation = new[] {"CreatePricingRule"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.CreatePricingRuleResponse))]
    [AWSCmdletOutput("System.String or Amazon.BillingConductor.Model.CreatePricingRuleResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BillingConductor.Model.CreatePricingRuleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewABCPricingRuleCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter FreeTier_Activated
        /// <summary>
        /// <para>
        /// <para> Activate or deactivate Amazon Web Services Free Tier. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tiering_FreeTier_Activated")]
        public System.Boolean? FreeTier_Activated { get; set; }
        #endregion
        
        #region Parameter BillingEntity
        /// <summary>
        /// <para>
        /// <para> The seller of services provided by Amazon Web Services, their affiliates, or third-party
        /// providers selling services via Amazon Web Services Marketplace. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingEntity { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The pricing rule description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ModifierPercentage
        /// <summary>
        /// <para>
        /// <para> A percentage modifier that's applied on the public pricing rates. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ModifierPercentage { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The pricing rule name. The names must be unique to each pricing rule. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para> Operation is the specific Amazon Web Services action covered by this line item. This
        /// describes the specific usage of the line item.</para><para> If the <code>Scope</code> attribute is set to <code>SKU</code>, this attribute indicates
        /// which operation the <code>PricingRule</code> is modifying. For example, a value of
        /// <code>RunInstances:0202</code> indicates the operation of running an Amazon EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Operation { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para> The scope of pricing rule that indicates if it's globally applicable, or it's service-specific.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BillingConductor.PricingRuleScope")]
        public Amazon.BillingConductor.PricingRuleScope Scope { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para> If the <code>Scope</code> attribute is set to <code>SERVICE</code> or <code>SKU</code>,
        /// the attribute indicates which service the <code>PricingRule</code> is applicable for.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A map that contains tag keys and tag values that are attached to a pricing rule.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para> The type of pricing rule. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BillingConductor.PricingRuleType")]
        public Amazon.BillingConductor.PricingRuleType Type { get; set; }
        #endregion
        
        #region Parameter UsageType
        /// <summary>
        /// <para>
        /// Amazon.BillingConductor.Model.CreatePricingRuleRequest.UsageType
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UsageType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> The token that's needed to support idempotency. Idempotency isn't currently supported,
        /// but will be implemented in a future update. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.CreatePricingRuleResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.CreatePricingRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ABCPricingRule (CreatePricingRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.CreatePricingRuleResponse, NewABCPricingRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingEntity = this.BillingEntity;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ModifierPercentage = this.ModifierPercentage;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Operation = this.Operation;
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Service = this.Service;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.FreeTier_Activated = this.FreeTier_Activated;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UsageType = this.UsageType;
            
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
            var request = new Amazon.BillingConductor.Model.CreatePricingRuleRequest();
            
            if (cmdletContext.BillingEntity != null)
            {
                request.BillingEntity = cmdletContext.BillingEntity;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
            if (cmdletContext.Operation != null)
            {
                request.Operation = cmdletContext.Operation;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Tiering
            var requestTieringIsNull = true;
            request.Tiering = new Amazon.BillingConductor.Model.CreateTieringInput();
            Amazon.BillingConductor.Model.CreateFreeTierConfig requestTiering_tiering_FreeTier = null;
            
             // populate FreeTier
            var requestTiering_tiering_FreeTierIsNull = true;
            requestTiering_tiering_FreeTier = new Amazon.BillingConductor.Model.CreateFreeTierConfig();
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
            if (cmdletContext.UsageType != null)
            {
                request.UsageType = cmdletContext.UsageType;
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
        
        private Amazon.BillingConductor.Model.CreatePricingRuleResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.CreatePricingRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "CreatePricingRule");
            try
            {
                #if DESKTOP
                return client.CreatePricingRule(request);
                #elif CORECLR
                return client.CreatePricingRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String BillingEntity { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Double? ModifierPercentage { get; set; }
            public System.String Name { get; set; }
            public System.String Operation { get; set; }
            public Amazon.BillingConductor.PricingRuleScope Scope { get; set; }
            public System.String Service { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? FreeTier_Activated { get; set; }
            public Amazon.BillingConductor.PricingRuleType Type { get; set; }
            public System.String UsageType { get; set; }
            public System.Func<Amazon.BillingConductor.Model.CreatePricingRuleResponse, NewABCPricingRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
