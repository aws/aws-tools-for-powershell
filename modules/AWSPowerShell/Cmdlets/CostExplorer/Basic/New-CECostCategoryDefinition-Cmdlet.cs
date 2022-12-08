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
    /// Creates a new Cost Category with the requested name and rules.
    /// </summary>
    [Cmdlet("New", "CECostCategoryDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer CreateCostCategoryDefinition API operation.", Operation = new[] {"CreateCostCategoryDefinition"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCECostCategoryDefinitionCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>An optional list of tags to associate with the specified <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_CostCategory.html"><code>CostCategory</code></a>. You can use resource tags to control access to your
        /// <code>cost category</code> using IAM policies.</para><para>Each tag consists of a key and a value, and each key must be unique for the resource.
        /// The following restrictions apply to resource tags:</para><ul><li><para>Although the maximum number of array members is 200, you can assign a maximum of 50
        /// user-tags to one resource. The remaining are reserved for Amazon Web Services use</para></li><li><para>The maximum length of a key is 128 characters</para></li><li><para>The maximum length of a value is 256 characters</para></li><li><para>Keys and values can only contain alphanumeric characters, spaces, and any of the following:
        /// <code>_.:/=+@-</code></para></li><li><para>Keys and values are case sensitive</para></li><li><para>Keys and values are trimmed for any leading or trailing whitespaces</para></li><li><para>Don’t use <code>aws:</code> as a prefix for your keys. This prefix is reserved for
        /// Amazon Web Services use</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.CostExplorer.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The Cost Category rules used to categorize costs. For more information, see <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_CostCategoryRule.html">CostCategoryRule</a>.</para>
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
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SplitChargeRules")]
        public Amazon.CostExplorer.Model.CostCategorySplitChargeRule[] SplitChargeRule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CECostCategoryDefinition (CreateCostCategoryDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse, NewCECostCategoryDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultValue = this.DefaultValue;
            context.EffectiveStart = this.EffectiveStart;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.CostExplorer.Model.ResourceTag>(this.ResourceTag);
            }
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
            var request = new Amazon.CostExplorer.Model.CreateCostCategoryDefinitionRequest();
            
            if (cmdletContext.DefaultValue != null)
            {
                request.DefaultValue = cmdletContext.DefaultValue;
            }
            if (cmdletContext.EffectiveStart != null)
            {
                request.EffectiveStart = cmdletContext.EffectiveStart;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
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
        
        private Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.CreateCostCategoryDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "CreateCostCategoryDefinition");
            try
            {
                #if DESKTOP
                return client.CreateCostCategoryDefinition(request);
                #elif CORECLR
                return client.CreateCostCategoryDefinitionAsync(request).GetAwaiter().GetResult();
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
            public System.String DefaultValue { get; set; }
            public System.String EffectiveStart { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.CostExplorer.Model.ResourceTag> ResourceTag { get; set; }
            public List<Amazon.CostExplorer.Model.CostCategoryRule> Rule { get; set; }
            public Amazon.CostExplorer.CostCategoryRuleVersion RuleVersion { get; set; }
            public List<Amazon.CostExplorer.Model.CostCategorySplitChargeRule> SplitChargeRule { get; set; }
            public System.Func<Amazon.CostExplorer.Model.CreateCostCategoryDefinitionResponse, NewCECostCategoryDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
