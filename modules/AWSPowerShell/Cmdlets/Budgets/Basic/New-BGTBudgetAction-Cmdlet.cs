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
using Amazon.Budgets;
using Amazon.Budgets.Model;

namespace Amazon.PowerShell.Cmdlets.BGT
{
    /// <summary>
    /// Creates a budget action.
    /// </summary>
    [Cmdlet("New", "BGTBudgetAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Budgets.Model.CreateBudgetActionResponse")]
    [AWSCmdlet("Calls the AWS Budgets CreateBudgetAction API operation.", Operation = new[] {"CreateBudgetAction"}, SelectReturnType = typeof(Amazon.Budgets.Model.CreateBudgetActionResponse))]
    [AWSCmdletOutput("Amazon.Budgets.Model.CreateBudgetActionResponse",
        "This cmdlet returns an Amazon.Budgets.Model.CreateBudgetActionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBGTBudgetActionCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter SsmActionDefinition_ActionSubType
        /// <summary>
        /// <para>
        /// <para>The action subType. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_SsmActionDefinition_ActionSubType")]
        [AWSConstantClassSource("Amazon.Budgets.ActionSubType")]
        public Amazon.Budgets.ActionSubType SsmActionDefinition_ActionSubType { get; set; }
        #endregion
        
        #region Parameter ActionThreshold_ActionThresholdType
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
        [AWSConstantClassSource("Amazon.Budgets.ThresholdType")]
        public Amazon.Budgets.ThresholdType ActionThreshold_ActionThresholdType { get; set; }
        #endregion
        
        #region Parameter ActionThreshold_ActionThresholdValue
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
        public System.Double? ActionThreshold_ActionThresholdValue { get; set; }
        #endregion
        
        #region Parameter ActionType
        /// <summary>
        /// <para>
        /// <para> The type of action. This defines the type of tasks that can be carried out by this
        /// action. This field also determines the format for definition. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.ActionType")]
        public Amazon.Budgets.ActionType ActionType { get; set; }
        #endregion
        
        #region Parameter ApprovalModel
        /// <summary>
        /// <para>
        /// <para> This specifies if the action needs manual or automatic approval. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.ApprovalModel")]
        public Amazon.Budgets.ApprovalModel ApprovalModel { get; set; }
        #endregion
        
        #region Parameter BudgetName
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
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para> The role passed for action execution and reversion. Roles and actions must be in
        /// the same account. </para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter IamActionDefinition_Group
        /// <summary>
        /// <para>
        /// <para>A list of groups to be attached. There must be at least one group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_IamActionDefinition_Groups")]
        public System.String[] IamActionDefinition_Group { get; set; }
        #endregion
        
        #region Parameter SsmActionDefinition_InstanceId
        /// <summary>
        /// <para>
        /// <para>The EC2 and RDS instance IDs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_SsmActionDefinition_InstanceIds")]
        public System.String[] SsmActionDefinition_InstanceId { get; set; }
        #endregion
        
        #region Parameter NotificationType
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
        [AWSConstantClassSource("Amazon.Budgets.NotificationType")]
        public Amazon.Budgets.NotificationType NotificationType { get; set; }
        #endregion
        
        #region Parameter IamActionDefinition_PolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the policy to be attached. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_IamActionDefinition_PolicyArn")]
        public System.String IamActionDefinition_PolicyArn { get; set; }
        #endregion
        
        #region Parameter ScpActionDefinition_PolicyId
        /// <summary>
        /// <para>
        /// <para>The policy ID attached. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_ScpActionDefinition_PolicyId")]
        public System.String ScpActionDefinition_PolicyId { get; set; }
        #endregion
        
        #region Parameter SsmActionDefinition_Region
        /// <summary>
        /// <para>
        /// <para>The Region to run the SSM document. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_SsmActionDefinition_Region")]
        public System.String SsmActionDefinition_Region { get; set; }
        #endregion
        
        #region Parameter IamActionDefinition_Role
        /// <summary>
        /// <para>
        /// <para>A list of roles to be attached. There must be at least one role. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_IamActionDefinition_Roles")]
        public System.String[] IamActionDefinition_Role { get; set; }
        #endregion
        
        #region Parameter Subscriber
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        [Alias("Subscribers")]
        public Amazon.Budgets.Model.Subscriber[] Subscriber { get; set; }
        #endregion
        
        #region Parameter ScpActionDefinition_TargetId
        /// <summary>
        /// <para>
        /// <para>A list of target IDs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_ScpActionDefinition_TargetIds")]
        public System.String[] ScpActionDefinition_TargetId { get; set; }
        #endregion
        
        #region Parameter IamActionDefinition_User
        /// <summary>
        /// <para>
        /// <para>A list of users to be attached. There must be at least one user. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_IamActionDefinition_Users")]
        public System.String[] IamActionDefinition_User { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Budgets.Model.CreateBudgetActionResponse).
        /// Specifying the name of a property of type Amazon.Budgets.Model.CreateBudgetActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BudgetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BudgetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BudgetName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BudgetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BGTBudgetAction (CreateBudgetAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Budgets.Model.CreateBudgetActionResponse, NewBGTBudgetActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BudgetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionThreshold_ActionThresholdType = this.ActionThreshold_ActionThresholdType;
            #if MODULAR
            if (this.ActionThreshold_ActionThresholdType == null && ParameterWasBound(nameof(this.ActionThreshold_ActionThresholdType)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionThreshold_ActionThresholdType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionThreshold_ActionThresholdValue = this.ActionThreshold_ActionThresholdValue;
            #if MODULAR
            if (this.ActionThreshold_ActionThresholdValue == null && ParameterWasBound(nameof(this.ActionThreshold_ActionThresholdValue)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionThreshold_ActionThresholdValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ActionType = this.ActionType;
            #if MODULAR
            if (this.ActionType == null && ParameterWasBound(nameof(this.ActionType)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApprovalModel = this.ApprovalModel;
            #if MODULAR
            if (this.ApprovalModel == null && ParameterWasBound(nameof(this.ApprovalModel)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalModel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BudgetName = this.BudgetName;
            #if MODULAR
            if (this.BudgetName == null && ParameterWasBound(nameof(this.BudgetName)))
            {
                WriteWarning("You are passing $null as a value for parameter BudgetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IamActionDefinition_Group != null)
            {
                context.IamActionDefinition_Group = new List<System.String>(this.IamActionDefinition_Group);
            }
            context.IamActionDefinition_PolicyArn = this.IamActionDefinition_PolicyArn;
            if (this.IamActionDefinition_Role != null)
            {
                context.IamActionDefinition_Role = new List<System.String>(this.IamActionDefinition_Role);
            }
            if (this.IamActionDefinition_User != null)
            {
                context.IamActionDefinition_User = new List<System.String>(this.IamActionDefinition_User);
            }
            context.ScpActionDefinition_PolicyId = this.ScpActionDefinition_PolicyId;
            if (this.ScpActionDefinition_TargetId != null)
            {
                context.ScpActionDefinition_TargetId = new List<System.String>(this.ScpActionDefinition_TargetId);
            }
            context.SsmActionDefinition_ActionSubType = this.SsmActionDefinition_ActionSubType;
            if (this.SsmActionDefinition_InstanceId != null)
            {
                context.SsmActionDefinition_InstanceId = new List<System.String>(this.SsmActionDefinition_InstanceId);
            }
            context.SsmActionDefinition_Region = this.SsmActionDefinition_Region;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationType = this.NotificationType;
            #if MODULAR
            if (this.NotificationType == null && ParameterWasBound(nameof(this.NotificationType)))
            {
                WriteWarning("You are passing $null as a value for parameter NotificationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Subscriber != null)
            {
                context.Subscriber = new List<Amazon.Budgets.Model.Subscriber>(this.Subscriber);
            }
            #if MODULAR
            if (this.Subscriber == null && ParameterWasBound(nameof(this.Subscriber)))
            {
                WriteWarning("You are passing $null as a value for parameter Subscriber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Budgets.Model.CreateBudgetActionRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate ActionThreshold
            var requestActionThresholdIsNull = true;
            request.ActionThreshold = new Amazon.Budgets.Model.ActionThreshold();
            Amazon.Budgets.ThresholdType requestActionThreshold_actionThreshold_ActionThresholdType = null;
            if (cmdletContext.ActionThreshold_ActionThresholdType != null)
            {
                requestActionThreshold_actionThreshold_ActionThresholdType = cmdletContext.ActionThreshold_ActionThresholdType;
            }
            if (requestActionThreshold_actionThreshold_ActionThresholdType != null)
            {
                request.ActionThreshold.ActionThresholdType = requestActionThreshold_actionThreshold_ActionThresholdType;
                requestActionThresholdIsNull = false;
            }
            System.Double? requestActionThreshold_actionThreshold_ActionThresholdValue = null;
            if (cmdletContext.ActionThreshold_ActionThresholdValue != null)
            {
                requestActionThreshold_actionThreshold_ActionThresholdValue = cmdletContext.ActionThreshold_ActionThresholdValue.Value;
            }
            if (requestActionThreshold_actionThreshold_ActionThresholdValue != null)
            {
                request.ActionThreshold.ActionThresholdValue = requestActionThreshold_actionThreshold_ActionThresholdValue.Value;
                requestActionThresholdIsNull = false;
            }
             // determine if request.ActionThreshold should be set to null
            if (requestActionThresholdIsNull)
            {
                request.ActionThreshold = null;
            }
            if (cmdletContext.ActionType != null)
            {
                request.ActionType = cmdletContext.ActionType;
            }
            if (cmdletContext.ApprovalModel != null)
            {
                request.ApprovalModel = cmdletContext.ApprovalModel;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            
             // populate Definition
            var requestDefinitionIsNull = true;
            request.Definition = new Amazon.Budgets.Model.Definition();
            Amazon.Budgets.Model.ScpActionDefinition requestDefinition_definition_ScpActionDefinition = null;
            
             // populate ScpActionDefinition
            var requestDefinition_definition_ScpActionDefinitionIsNull = true;
            requestDefinition_definition_ScpActionDefinition = new Amazon.Budgets.Model.ScpActionDefinition();
            System.String requestDefinition_definition_ScpActionDefinition_scpActionDefinition_PolicyId = null;
            if (cmdletContext.ScpActionDefinition_PolicyId != null)
            {
                requestDefinition_definition_ScpActionDefinition_scpActionDefinition_PolicyId = cmdletContext.ScpActionDefinition_PolicyId;
            }
            if (requestDefinition_definition_ScpActionDefinition_scpActionDefinition_PolicyId != null)
            {
                requestDefinition_definition_ScpActionDefinition.PolicyId = requestDefinition_definition_ScpActionDefinition_scpActionDefinition_PolicyId;
                requestDefinition_definition_ScpActionDefinitionIsNull = false;
            }
            List<System.String> requestDefinition_definition_ScpActionDefinition_scpActionDefinition_TargetId = null;
            if (cmdletContext.ScpActionDefinition_TargetId != null)
            {
                requestDefinition_definition_ScpActionDefinition_scpActionDefinition_TargetId = cmdletContext.ScpActionDefinition_TargetId;
            }
            if (requestDefinition_definition_ScpActionDefinition_scpActionDefinition_TargetId != null)
            {
                requestDefinition_definition_ScpActionDefinition.TargetIds = requestDefinition_definition_ScpActionDefinition_scpActionDefinition_TargetId;
                requestDefinition_definition_ScpActionDefinitionIsNull = false;
            }
             // determine if requestDefinition_definition_ScpActionDefinition should be set to null
            if (requestDefinition_definition_ScpActionDefinitionIsNull)
            {
                requestDefinition_definition_ScpActionDefinition = null;
            }
            if (requestDefinition_definition_ScpActionDefinition != null)
            {
                request.Definition.ScpActionDefinition = requestDefinition_definition_ScpActionDefinition;
                requestDefinitionIsNull = false;
            }
            Amazon.Budgets.Model.SsmActionDefinition requestDefinition_definition_SsmActionDefinition = null;
            
             // populate SsmActionDefinition
            var requestDefinition_definition_SsmActionDefinitionIsNull = true;
            requestDefinition_definition_SsmActionDefinition = new Amazon.Budgets.Model.SsmActionDefinition();
            Amazon.Budgets.ActionSubType requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_ActionSubType = null;
            if (cmdletContext.SsmActionDefinition_ActionSubType != null)
            {
                requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_ActionSubType = cmdletContext.SsmActionDefinition_ActionSubType;
            }
            if (requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_ActionSubType != null)
            {
                requestDefinition_definition_SsmActionDefinition.ActionSubType = requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_ActionSubType;
                requestDefinition_definition_SsmActionDefinitionIsNull = false;
            }
            List<System.String> requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_InstanceId = null;
            if (cmdletContext.SsmActionDefinition_InstanceId != null)
            {
                requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_InstanceId = cmdletContext.SsmActionDefinition_InstanceId;
            }
            if (requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_InstanceId != null)
            {
                requestDefinition_definition_SsmActionDefinition.InstanceIds = requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_InstanceId;
                requestDefinition_definition_SsmActionDefinitionIsNull = false;
            }
            System.String requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_Region = null;
            if (cmdletContext.SsmActionDefinition_Region != null)
            {
                requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_Region = cmdletContext.SsmActionDefinition_Region;
            }
            if (requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_Region != null)
            {
                requestDefinition_definition_SsmActionDefinition.Region = requestDefinition_definition_SsmActionDefinition_ssmActionDefinition_Region;
                requestDefinition_definition_SsmActionDefinitionIsNull = false;
            }
             // determine if requestDefinition_definition_SsmActionDefinition should be set to null
            if (requestDefinition_definition_SsmActionDefinitionIsNull)
            {
                requestDefinition_definition_SsmActionDefinition = null;
            }
            if (requestDefinition_definition_SsmActionDefinition != null)
            {
                request.Definition.SsmActionDefinition = requestDefinition_definition_SsmActionDefinition;
                requestDefinitionIsNull = false;
            }
            Amazon.Budgets.Model.IamActionDefinition requestDefinition_definition_IamActionDefinition = null;
            
             // populate IamActionDefinition
            var requestDefinition_definition_IamActionDefinitionIsNull = true;
            requestDefinition_definition_IamActionDefinition = new Amazon.Budgets.Model.IamActionDefinition();
            List<System.String> requestDefinition_definition_IamActionDefinition_iamActionDefinition_Group = null;
            if (cmdletContext.IamActionDefinition_Group != null)
            {
                requestDefinition_definition_IamActionDefinition_iamActionDefinition_Group = cmdletContext.IamActionDefinition_Group;
            }
            if (requestDefinition_definition_IamActionDefinition_iamActionDefinition_Group != null)
            {
                requestDefinition_definition_IamActionDefinition.Groups = requestDefinition_definition_IamActionDefinition_iamActionDefinition_Group;
                requestDefinition_definition_IamActionDefinitionIsNull = false;
            }
            System.String requestDefinition_definition_IamActionDefinition_iamActionDefinition_PolicyArn = null;
            if (cmdletContext.IamActionDefinition_PolicyArn != null)
            {
                requestDefinition_definition_IamActionDefinition_iamActionDefinition_PolicyArn = cmdletContext.IamActionDefinition_PolicyArn;
            }
            if (requestDefinition_definition_IamActionDefinition_iamActionDefinition_PolicyArn != null)
            {
                requestDefinition_definition_IamActionDefinition.PolicyArn = requestDefinition_definition_IamActionDefinition_iamActionDefinition_PolicyArn;
                requestDefinition_definition_IamActionDefinitionIsNull = false;
            }
            List<System.String> requestDefinition_definition_IamActionDefinition_iamActionDefinition_Role = null;
            if (cmdletContext.IamActionDefinition_Role != null)
            {
                requestDefinition_definition_IamActionDefinition_iamActionDefinition_Role = cmdletContext.IamActionDefinition_Role;
            }
            if (requestDefinition_definition_IamActionDefinition_iamActionDefinition_Role != null)
            {
                requestDefinition_definition_IamActionDefinition.Roles = requestDefinition_definition_IamActionDefinition_iamActionDefinition_Role;
                requestDefinition_definition_IamActionDefinitionIsNull = false;
            }
            List<System.String> requestDefinition_definition_IamActionDefinition_iamActionDefinition_User = null;
            if (cmdletContext.IamActionDefinition_User != null)
            {
                requestDefinition_definition_IamActionDefinition_iamActionDefinition_User = cmdletContext.IamActionDefinition_User;
            }
            if (requestDefinition_definition_IamActionDefinition_iamActionDefinition_User != null)
            {
                requestDefinition_definition_IamActionDefinition.Users = requestDefinition_definition_IamActionDefinition_iamActionDefinition_User;
                requestDefinition_definition_IamActionDefinitionIsNull = false;
            }
             // determine if requestDefinition_definition_IamActionDefinition should be set to null
            if (requestDefinition_definition_IamActionDefinitionIsNull)
            {
                requestDefinition_definition_IamActionDefinition = null;
            }
            if (requestDefinition_definition_IamActionDefinition != null)
            {
                request.Definition.IamActionDefinition = requestDefinition_definition_IamActionDefinition;
                requestDefinitionIsNull = false;
            }
             // determine if request.Definition should be set to null
            if (requestDefinitionIsNull)
            {
                request.Definition = null;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.NotificationType != null)
            {
                request.NotificationType = cmdletContext.NotificationType;
            }
            if (cmdletContext.Subscriber != null)
            {
                request.Subscribers = cmdletContext.Subscriber;
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
        
        private Amazon.Budgets.Model.CreateBudgetActionResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.CreateBudgetActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "CreateBudgetAction");
            try
            {
                #if DESKTOP
                return client.CreateBudgetAction(request);
                #elif CORECLR
                return client.CreateBudgetActionAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.Budgets.ThresholdType ActionThreshold_ActionThresholdType { get; set; }
            public System.Double? ActionThreshold_ActionThresholdValue { get; set; }
            public Amazon.Budgets.ActionType ActionType { get; set; }
            public Amazon.Budgets.ApprovalModel ApprovalModel { get; set; }
            public System.String BudgetName { get; set; }
            public List<System.String> IamActionDefinition_Group { get; set; }
            public System.String IamActionDefinition_PolicyArn { get; set; }
            public List<System.String> IamActionDefinition_Role { get; set; }
            public List<System.String> IamActionDefinition_User { get; set; }
            public System.String ScpActionDefinition_PolicyId { get; set; }
            public List<System.String> ScpActionDefinition_TargetId { get; set; }
            public Amazon.Budgets.ActionSubType SsmActionDefinition_ActionSubType { get; set; }
            public List<System.String> SsmActionDefinition_InstanceId { get; set; }
            public System.String SsmActionDefinition_Region { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public Amazon.Budgets.NotificationType NotificationType { get; set; }
            public List<Amazon.Budgets.Model.Subscriber> Subscriber { get; set; }
            public System.Func<Amazon.Budgets.Model.CreateBudgetActionResponse, NewBGTBudgetActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
