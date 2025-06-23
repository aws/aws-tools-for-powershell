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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Updates an existing Cost Category. Changes made to the Cost Category rules will be
    /// used to categorize the current month’s expenses and future expenses. This won’t change
    /// categorization for the previous months.
    /// </summary>
    [Cmdlet("Update", "CECostCategoryDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer UpdateCostCategoryDefinition API operation.", Operation = new[] {"UpdateCostCategoryDefinition"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse object containing multiple properties."
    )]
    public partial class UpdateCECostCategoryDefinitionCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CostCategoryArn
        /// <summary>
        /// <para>
        /// <para>The unique identifier for your Cost Category.</para>
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
        public System.String CostCategoryArn { get; set; }
        #endregion
        
        #region Parameter DefaultValue
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultValue { get; set; }
        #endregion
        
        #region Parameter EffectiveStart
        /// <summary>
        /// <para>
        /// <para>The Cost Category's effective start date. It can only be a billing start date (first
        /// day of the month). If the date isn't provided, it's the first day of the current month.
        /// Dates can't be before the previous twelve months, or in the future.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveStart { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The <c>Expression</c> object used to categorize costs. For more information, see <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_CostCategoryRule.html">CostCategoryRule
        /// </a>. </para><para />
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
        [Alias("Rules")]
        public Amazon.CostExplorer.Model.CostCategoryRule[] Rule { get; set; }
        #endregion
        
        #region Parameter RuleVersion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.CostCategoryRuleVersion")]
        public Amazon.CostExplorer.CostCategoryRuleVersion RuleVersion { get; set; }
        #endregion
        
        #region Parameter SplitChargeRule
        /// <summary>
        /// <para>
        /// <para> The split charge rules used to allocate your charges between your Cost Category values.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SplitChargeRules")]
        public Amazon.CostExplorer.Model.CostCategorySplitChargeRule[] SplitChargeRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CostCategoryArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CECostCategoryDefinition (UpdateCostCategoryDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse, UpdateCECostCategoryDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CostCategoryArn = this.CostCategoryArn;
            #if MODULAR
            if (this.CostCategoryArn == null && ParameterWasBound(nameof(this.CostCategoryArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CostCategoryArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultValue = this.DefaultValue;
            context.EffectiveStart = this.EffectiveStart;
            if (this.Rule != null)
            {
                context.Rule = new List<Amazon.CostExplorer.Model.CostCategoryRule>(this.Rule);
            }
            #if MODULAR
            if (this.Rule == null && ParameterWasBound(nameof(this.Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleVersion = this.RuleVersion;
            #if MODULAR
            if (this.RuleVersion == null && ParameterWasBound(nameof(this.RuleVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SplitChargeRule != null)
            {
                context.SplitChargeRule = new List<Amazon.CostExplorer.Model.CostCategorySplitChargeRule>(this.SplitChargeRule);
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
            var request = new Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionRequest();
            
            if (cmdletContext.CostCategoryArn != null)
            {
                request.CostCategoryArn = cmdletContext.CostCategoryArn;
            }
            if (cmdletContext.DefaultValue != null)
            {
                request.DefaultValue = cmdletContext.DefaultValue;
            }
            if (cmdletContext.EffectiveStart != null)
            {
                request.EffectiveStart = cmdletContext.EffectiveStart;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
            }
            if (cmdletContext.RuleVersion != null)
            {
                request.RuleVersion = cmdletContext.RuleVersion;
            }
            if (cmdletContext.SplitChargeRule != null)
            {
                request.SplitChargeRules = cmdletContext.SplitChargeRule;
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
        
        private Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "UpdateCostCategoryDefinition");
            try
            {
                return client.UpdateCostCategoryDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CostCategoryArn { get; set; }
            public System.String DefaultValue { get; set; }
            public System.String EffectiveStart { get; set; }
            public List<Amazon.CostExplorer.Model.CostCategoryRule> Rule { get; set; }
            public Amazon.CostExplorer.CostCategoryRuleVersion RuleVersion { get; set; }
            public List<Amazon.CostExplorer.Model.CostCategorySplitChargeRule> SplitChargeRule { get; set; }
            public System.Func<Amazon.CostExplorer.Model.UpdateCostCategoryDefinitionResponse, UpdateCECostCategoryDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
