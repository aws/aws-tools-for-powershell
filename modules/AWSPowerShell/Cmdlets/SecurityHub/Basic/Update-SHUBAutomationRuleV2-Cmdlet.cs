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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Updates a V2 automation rule. This API is in public preview and subject to change.
    /// </summary>
    [Cmdlet("Update", "SHUBAutomationRuleV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateAutomationRuleV2 API operation.", Operation = new[] {"UpdateAutomationRuleV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateAutomationRuleV2Response))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.UpdateAutomationRuleV2Response",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.UpdateAutomationRuleV2Response) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSHUBAutomationRuleV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>A list of actions to be performed when the rule criteria is met.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Actions")]
        public Amazon.SecurityHub.Model.AutomationRulesActionV2[] Action { get; set; }
        #endregion
        
        #region Parameter OcsfFindingCriteria_CompositeFilter
        /// <summary>
        /// <para>
        /// <para>Enables the creation of complex filtering conditions by combining filter criteria.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_OcsfFindingCriteria_CompositeFilters")]
        public Amazon.SecurityHub.Model.CompositeFilter[] OcsfFindingCriteria_CompositeFilter { get; set; }
        #endregion
        
        #region Parameter OcsfFindingCriteria_CompositeOperator
        /// <summary>
        /// <para>
        /// <para>The logical operators used to combine the filtering on multiple <c>CompositeFilters</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Criteria_OcsfFindingCriteria_CompositeOperator")]
        [AWSConstantClassSource("Amazon.SecurityHub.AllowedOperators")]
        public Amazon.SecurityHub.AllowedOperators OcsfFindingCriteria_CompositeOperator { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the automation rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the automation rule.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter RuleName
        /// <summary>
        /// <para>
        /// <para>The name of the automation rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleName { get; set; }
        #endregion
        
        #region Parameter RuleOrder
        /// <summary>
        /// <para>
        /// <para>Represents a value for the rule priority.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? RuleOrder { get; set; }
        #endregion
        
        #region Parameter RuleStatus
        /// <summary>
        /// <para>
        /// <para>The status of the automation rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.RuleStatusV2")]
        public Amazon.SecurityHub.RuleStatusV2 RuleStatus { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateAutomationRuleV2Response).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBAutomationRuleV2 (UpdateAutomationRuleV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateAutomationRuleV2Response, UpdateSHUBAutomationRuleV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Action != null)
            {
                context.Action = new List<Amazon.SecurityHub.Model.AutomationRulesActionV2>(this.Action);
            }
            if (this.OcsfFindingCriteria_CompositeFilter != null)
            {
                context.OcsfFindingCriteria_CompositeFilter = new List<Amazon.SecurityHub.Model.CompositeFilter>(this.OcsfFindingCriteria_CompositeFilter);
            }
            context.OcsfFindingCriteria_CompositeOperator = this.OcsfFindingCriteria_CompositeOperator;
            context.Description = this.Description;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleName = this.RuleName;
            context.RuleOrder = this.RuleOrder;
            context.RuleStatus = this.RuleStatus;
            
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
            var request = new Amazon.SecurityHub.Model.UpdateAutomationRuleV2Request();
            
            if (cmdletContext.Action != null)
            {
                request.Actions = cmdletContext.Action;
            }
            
             // populate Criteria
            var requestCriteriaIsNull = true;
            request.Criteria = new Amazon.SecurityHub.Model.Criteria();
            Amazon.SecurityHub.Model.OcsfFindingFilters requestCriteria_criteria_OcsfFindingCriteria = null;
            
             // populate OcsfFindingCriteria
            var requestCriteria_criteria_OcsfFindingCriteriaIsNull = true;
            requestCriteria_criteria_OcsfFindingCriteria = new Amazon.SecurityHub.Model.OcsfFindingFilters();
            List<Amazon.SecurityHub.Model.CompositeFilter> requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeFilter = null;
            if (cmdletContext.OcsfFindingCriteria_CompositeFilter != null)
            {
                requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeFilter = cmdletContext.OcsfFindingCriteria_CompositeFilter;
            }
            if (requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeFilter != null)
            {
                requestCriteria_criteria_OcsfFindingCriteria.CompositeFilters = requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeFilter;
                requestCriteria_criteria_OcsfFindingCriteriaIsNull = false;
            }
            Amazon.SecurityHub.AllowedOperators requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeOperator = null;
            if (cmdletContext.OcsfFindingCriteria_CompositeOperator != null)
            {
                requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeOperator = cmdletContext.OcsfFindingCriteria_CompositeOperator;
            }
            if (requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeOperator != null)
            {
                requestCriteria_criteria_OcsfFindingCriteria.CompositeOperator = requestCriteria_criteria_OcsfFindingCriteria_ocsfFindingCriteria_CompositeOperator;
                requestCriteria_criteria_OcsfFindingCriteriaIsNull = false;
            }
             // determine if requestCriteria_criteria_OcsfFindingCriteria should be set to null
            if (requestCriteria_criteria_OcsfFindingCriteriaIsNull)
            {
                requestCriteria_criteria_OcsfFindingCriteria = null;
            }
            if (requestCriteria_criteria_OcsfFindingCriteria != null)
            {
                request.Criteria.OcsfFindingCriteria = requestCriteria_criteria_OcsfFindingCriteria;
                requestCriteriaIsNull = false;
            }
             // determine if request.Criteria should be set to null
            if (requestCriteriaIsNull)
            {
                request.Criteria = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.RuleName != null)
            {
                request.RuleName = cmdletContext.RuleName;
            }
            if (cmdletContext.RuleOrder != null)
            {
                request.RuleOrder = cmdletContext.RuleOrder.Value;
            }
            if (cmdletContext.RuleStatus != null)
            {
                request.RuleStatus = cmdletContext.RuleStatus;
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
        
        private Amazon.SecurityHub.Model.UpdateAutomationRuleV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateAutomationRuleV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateAutomationRuleV2");
            try
            {
                return client.UpdateAutomationRuleV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SecurityHub.Model.AutomationRulesActionV2> Action { get; set; }
            public List<Amazon.SecurityHub.Model.CompositeFilter> OcsfFindingCriteria_CompositeFilter { get; set; }
            public Amazon.SecurityHub.AllowedOperators OcsfFindingCriteria_CompositeOperator { get; set; }
            public System.String Description { get; set; }
            public System.String Identifier { get; set; }
            public System.String RuleName { get; set; }
            public System.Single? RuleOrder { get; set; }
            public Amazon.SecurityHub.RuleStatusV2 RuleStatus { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateAutomationRuleV2Response, UpdateSHUBAutomationRuleV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
