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
using Amazon.ConnectCases;
using Amazon.ConnectCases.Model;

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
        
        #region Parameter FieldOptions_ChildFieldId
        /// <summary>
        /// <para>
        /// <para>The identifier of the child field whose options are controlled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_FieldOptions_ChildFieldId")]
        public System.String FieldOptions_ChildFieldId { get; set; }
        #endregion
        
        #region Parameter Hidden_Condition
        /// <summary>
        /// <para>
        /// <para>A list of conditions that determine field visibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Hidden_Conditions")]
        public Amazon.ConnectCases.Model.BooleanCondition[] Hidden_Condition { get; set; }
        #endregion
        
        #region Parameter Required_Condition
        /// <summary>
        /// <para>
        /// <para>List of conditions for the required rule; the first condition to evaluate to true
        /// dictates the value of the rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Required_Conditions")]
        public Amazon.ConnectCases.Model.BooleanCondition[] Required_Condition { get; set; }
        #endregion
        
        #region Parameter Hidden_DefaultValue
        /// <summary>
        /// <para>
        /// <para>Whether the field is hidden when no conditions match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_Hidden_DefaultValue")]
        public System.Boolean? Hidden_DefaultValue { get; set; }
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
        
        #region Parameter FieldOptions_ParentChildFieldOptionsMapping
        /// <summary>
        /// <para>
        /// <para>A mapping between a parent field option value and child field option values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_FieldOptions_ParentChildFieldOptionsMappings")]
        public Amazon.ConnectCases.Model.ParentChildFieldOptionsMapping[] FieldOptions_ParentChildFieldOptionsMapping { get; set; }
        #endregion
        
        #region Parameter FieldOptions_ParentFieldId
        /// <summary>
        /// <para>
        /// <para>The identifier of the parent field that controls options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_FieldOptions_ParentFieldId")]
        public System.String FieldOptions_ParentFieldId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCASCaseRule (CreateCaseRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCases.Model.CreateCaseRuleResponse, NewCCASCaseRuleCmdlet>(Select) ??
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
            context.FieldOptions_ChildFieldId = this.FieldOptions_ChildFieldId;
            if (this.FieldOptions_ParentChildFieldOptionsMapping != null)
            {
                context.FieldOptions_ParentChildFieldOptionsMapping = new List<Amazon.ConnectCases.Model.ParentChildFieldOptionsMapping>(this.FieldOptions_ParentChildFieldOptionsMapping);
            }
            context.FieldOptions_ParentFieldId = this.FieldOptions_ParentFieldId;
            if (this.Hidden_Condition != null)
            {
                context.Hidden_Condition = new List<Amazon.ConnectCases.Model.BooleanCondition>(this.Hidden_Condition);
            }
            context.Hidden_DefaultValue = this.Hidden_DefaultValue;
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
            Amazon.ConnectCases.Model.HiddenCaseRule requestRule_rule_Hidden = null;
            
             // populate Hidden
            var requestRule_rule_HiddenIsNull = true;
            requestRule_rule_Hidden = new Amazon.ConnectCases.Model.HiddenCaseRule();
            List<Amazon.ConnectCases.Model.BooleanCondition> requestRule_rule_Hidden_hidden_Condition = null;
            if (cmdletContext.Hidden_Condition != null)
            {
                requestRule_rule_Hidden_hidden_Condition = cmdletContext.Hidden_Condition;
            }
            if (requestRule_rule_Hidden_hidden_Condition != null)
            {
                requestRule_rule_Hidden.Conditions = requestRule_rule_Hidden_hidden_Condition;
                requestRule_rule_HiddenIsNull = false;
            }
            System.Boolean? requestRule_rule_Hidden_hidden_DefaultValue = null;
            if (cmdletContext.Hidden_DefaultValue != null)
            {
                requestRule_rule_Hidden_hidden_DefaultValue = cmdletContext.Hidden_DefaultValue.Value;
            }
            if (requestRule_rule_Hidden_hidden_DefaultValue != null)
            {
                requestRule_rule_Hidden.DefaultValue = requestRule_rule_Hidden_hidden_DefaultValue.Value;
                requestRule_rule_HiddenIsNull = false;
            }
             // determine if requestRule_rule_Hidden should be set to null
            if (requestRule_rule_HiddenIsNull)
            {
                requestRule_rule_Hidden = null;
            }
            if (requestRule_rule_Hidden != null)
            {
                request.Rule.Hidden = requestRule_rule_Hidden;
                requestRuleIsNull = false;
            }
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
            Amazon.ConnectCases.Model.FieldOptionsCaseRule requestRule_rule_FieldOptions = null;
            
             // populate FieldOptions
            var requestRule_rule_FieldOptionsIsNull = true;
            requestRule_rule_FieldOptions = new Amazon.ConnectCases.Model.FieldOptionsCaseRule();
            System.String requestRule_rule_FieldOptions_fieldOptions_ChildFieldId = null;
            if (cmdletContext.FieldOptions_ChildFieldId != null)
            {
                requestRule_rule_FieldOptions_fieldOptions_ChildFieldId = cmdletContext.FieldOptions_ChildFieldId;
            }
            if (requestRule_rule_FieldOptions_fieldOptions_ChildFieldId != null)
            {
                requestRule_rule_FieldOptions.ChildFieldId = requestRule_rule_FieldOptions_fieldOptions_ChildFieldId;
                requestRule_rule_FieldOptionsIsNull = false;
            }
            List<Amazon.ConnectCases.Model.ParentChildFieldOptionsMapping> requestRule_rule_FieldOptions_fieldOptions_ParentChildFieldOptionsMapping = null;
            if (cmdletContext.FieldOptions_ParentChildFieldOptionsMapping != null)
            {
                requestRule_rule_FieldOptions_fieldOptions_ParentChildFieldOptionsMapping = cmdletContext.FieldOptions_ParentChildFieldOptionsMapping;
            }
            if (requestRule_rule_FieldOptions_fieldOptions_ParentChildFieldOptionsMapping != null)
            {
                requestRule_rule_FieldOptions.ParentChildFieldOptionsMappings = requestRule_rule_FieldOptions_fieldOptions_ParentChildFieldOptionsMapping;
                requestRule_rule_FieldOptionsIsNull = false;
            }
            System.String requestRule_rule_FieldOptions_fieldOptions_ParentFieldId = null;
            if (cmdletContext.FieldOptions_ParentFieldId != null)
            {
                requestRule_rule_FieldOptions_fieldOptions_ParentFieldId = cmdletContext.FieldOptions_ParentFieldId;
            }
            if (requestRule_rule_FieldOptions_fieldOptions_ParentFieldId != null)
            {
                requestRule_rule_FieldOptions.ParentFieldId = requestRule_rule_FieldOptions_fieldOptions_ParentFieldId;
                requestRule_rule_FieldOptionsIsNull = false;
            }
             // determine if requestRule_rule_FieldOptions should be set to null
            if (requestRule_rule_FieldOptionsIsNull)
            {
                requestRule_rule_FieldOptions = null;
            }
            if (requestRule_rule_FieldOptions != null)
            {
                request.Rule.FieldOptions = requestRule_rule_FieldOptions;
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
                #if DESKTOP
                return client.CreateCaseRule(request);
                #elif CORECLR
                return client.CreateCaseRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DomainId { get; set; }
            public System.String Name { get; set; }
            public System.String FieldOptions_ChildFieldId { get; set; }
            public List<Amazon.ConnectCases.Model.ParentChildFieldOptionsMapping> FieldOptions_ParentChildFieldOptionsMapping { get; set; }
            public System.String FieldOptions_ParentFieldId { get; set; }
            public List<Amazon.ConnectCases.Model.BooleanCondition> Hidden_Condition { get; set; }
            public System.Boolean? Hidden_DefaultValue { get; set; }
            public List<Amazon.ConnectCases.Model.BooleanCondition> Required_Condition { get; set; }
            public System.Boolean? Required_DefaultValue { get; set; }
            public System.Func<Amazon.ConnectCases.Model.CreateCaseRuleResponse, NewCCASCaseRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
