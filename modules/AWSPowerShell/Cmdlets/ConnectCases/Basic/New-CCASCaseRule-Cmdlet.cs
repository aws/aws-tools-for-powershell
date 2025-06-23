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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCAS
{
    /// <summary>
    /// Creates a new case rule. In the Amazon Connect admin website, case rules are known
    /// as <i>case field conditions</i>. For more information about case field conditions,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/case-field-conditions.html">Add
    /// case field conditions to a case template</a>.
    /// </summary>
    [Cmdlet("New", "CCASCaseRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCases.Model.CreateCaseRuleResponse")]
    [AWSCmdlet("Calls the Amazon Connect Cases CreateCaseRule API operation.", Operation = new[] {"CreateCaseRule"}, SelectReturnType = typeof(Amazon.ConnectCases.Model.CreateCaseRuleResponse))]
    [AWSCmdletOutput("Amazon.ConnectCases.Model.CreateCaseRuleResponse",
        "This cmdlet returns an Amazon.ConnectCases.Model.CreateCaseRuleResponse object containing multiple properties."
    )]
    public partial class NewCCASCaseRuleCmdlet : AmazonConnectCasesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Required_Condition
        /// <summary>
        /// <para>
        /// <para>List of conditions for the required rule; the first condition to evaluate to true
        /// dictates the value of the rule.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Required_Conditions")]
        public Amazon.ConnectCases.Model.BooleanCondition[] Required_Condition { get; set; }
        #endregion
        
        #region Parameter Required_DefaultValue
        /// <summary>
        /// <para>
        /// <para>The value of the rule (that is, whether the field is required) should none of the
        /// conditions evaluate to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Required_DefaultValue")]
        public System.Boolean? Required_DefaultValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of a case rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of a Cases domain.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the case rule.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCases.Model.CreateCaseRuleResponse).
        /// Specifying the name of a property of type Amazon.ConnectCases.Model.CreateCaseRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCASCaseRule (CreateCaseRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.CreateCaseRuleResponse, NewCCASCaseRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Required_Condition != null)
            {
                context.Required_Condition = new List<Amazon.ConnectCases.Model.BooleanCondition>(this.Required_Condition);
            }
            context.Required_DefaultValue = this.Required_DefaultValue;
            
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
            var request = new Amazon.ConnectCases.Model.CreateCaseRuleRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.ConnectCases.Model.CaseRuleDetails();
            Amazon.ConnectCases.Model.RequiredCaseRule requestRule_rule_Required = null;
            
             // populate Required
            var requestRule_rule_RequiredIsNull = true;
            requestRule_rule_Required = new Amazon.ConnectCases.Model.RequiredCaseRule();
            List<Amazon.ConnectCases.Model.BooleanCondition> requestRule_rule_Required_required_Condition = null;
            if (cmdletContext.Required_Condition != null)
            {
                requestRule_rule_Required_required_Condition = cmdletContext.Required_Condition;
            }
            if (requestRule_rule_Required_required_Condition != null)
            {
                requestRule_rule_Required.Conditions = requestRule_rule_Required_required_Condition;
                requestRule_rule_RequiredIsNull = false;
            }
            System.Boolean? requestRule_rule_Required_required_DefaultValue = null;
            if (cmdletContext.Required_DefaultValue != null)
            {
                requestRule_rule_Required_required_DefaultValue = cmdletContext.Required_DefaultValue.Value;
            }
            if (requestRule_rule_Required_required_DefaultValue != null)
            {
                requestRule_rule_Required.DefaultValue = requestRule_rule_Required_required_DefaultValue.Value;
                requestRule_rule_RequiredIsNull = false;
            }
             // determine if requestRule_rule_Required should be set to null
            if (requestRule_rule_RequiredIsNull)
            {
                requestRule_rule_Required = null;
            }
            if (requestRule_rule_Required != null)
            {
                request.Rule.Required = requestRule_rule_Required;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
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
        
        private Amazon.ConnectCases.Model.CreateCaseRuleResponse CallAWSServiceOperation(IAmazonConnectCases client, Amazon.ConnectCases.Model.CreateCaseRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Cases", "CreateCaseRule");
            try
            {
                return client.CreateCaseRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ConnectCases.Model.BooleanCondition> Required_Condition { get; set; }
            public System.Boolean? Required_DefaultValue { get; set; }
            public System.Func<Amazon.ConnectCases.Model.CreateCaseRuleResponse, NewCCASCaseRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
