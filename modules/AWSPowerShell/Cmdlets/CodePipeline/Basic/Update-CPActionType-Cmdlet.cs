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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Updates an action type that was created with any supported integration model, where
    /// the action type is to be used by customers of the action type provider. Use a JSON
    /// file with the action definition and <c>UpdateActionType</c> to provide the full structure.
    /// </summary>
    [Cmdlet("Update", "CPActionType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CodePipeline UpdateActionType API operation.", Operation = new[] {"UpdateActionType"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.UpdateActionTypeResponse))]
    [AWSCmdletOutput("None or Amazon.CodePipeline.Model.UpdateActionTypeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CodePipeline.Model.UpdateActionTypeResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCPActionTypeCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Permissions_AllowedAccount
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services account IDs with access to use the action type in their
        /// pipelines.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Permissions_AllowedAccounts")]
        public System.String[] Permissions_AllowedAccount { get; set; }
        #endregion
        
        #region Parameter Id_Category
        /// <summary>
        /// <para>
        /// <para>Defines what kind of action can be taken in the stage, one of the following:</para><ul><li><para><c>Source</c></para></li><li><para><c>Build</c></para></li><li><para><c>Test</c></para></li><li><para><c>Deploy</c></para></li><li><para><c>Approval</c></para></li><li><para><c>Invoke</c></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionType_Id_Category")]
        [AWSConstantClassSource("Amazon.CodePipeline.ActionCategory")]
        public Amazon.CodePipeline.ActionCategory Id_Category { get; set; }
        #endregion
        
        #region Parameter Urls_ConfigurationUrl
        /// <summary>
        /// <para>
        /// <para>The URL returned to the CodePipeline console that contains a link to the page where
        /// customers can configure the external action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Urls_ConfigurationUrl")]
        public System.String Urls_ConfigurationUrl { get; set; }
        #endregion
        
        #region Parameter ActionType_Description
        /// <summary>
        /// <para>
        /// <para>The description for the action type to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionType_Description { get; set; }
        #endregion
        
        #region Parameter Urls_EntityUrlTemplate
        /// <summary>
        /// <para>
        /// <para>The URL returned to the CodePipeline console that provides a deep link to the resources
        /// of the external system, such as a status page. This link is provided as part of the
        /// action display in the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Urls_EntityUrlTemplate")]
        public System.String Urls_EntityUrlTemplate { get; set; }
        #endregion
        
        #region Parameter Urls_ExecutionUrlTemplate
        /// <summary>
        /// <para>
        /// <para>The link to an execution page for the action type in progress. For example, for a
        /// CodeDeploy action, this link is shown on the pipeline view page in the CodePipeline
        /// console, and it links to a CodeDeploy status page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Urls_ExecutionUrlTemplate")]
        public System.String Urls_ExecutionUrlTemplate { get; set; }
        #endregion
        
        #region Parameter Executor_JobTimeout
        /// <summary>
        /// <para>
        /// <para>The timeout in seconds for the job. An action execution can have multiple jobs. This
        /// is the timeout for a single job, not the entire action execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Executor_JobTimeout")]
        public System.Int32? Executor_JobTimeout { get; set; }
        #endregion
        
        #region Parameter LambdaExecutorConfiguration_LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function used by the action engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Executor_Configuration_LambdaExecutorConfiguration_LambdaFunctionArn")]
        public System.String LambdaExecutorConfiguration_LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter InputArtifactDetails_MaximumCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of artifacts that can be used with the actiontype. For example,
        /// you should specify a minimum and maximum of zero input artifacts for an action type
        /// with a category of <c>source</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionType_InputArtifactDetails_MaximumCount")]
        public System.Int32? InputArtifactDetails_MaximumCount { get; set; }
        #endregion
        
        #region Parameter OutputArtifactDetails_MaximumCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of artifacts that can be used with the actiontype. For example,
        /// you should specify a minimum and maximum of zero input artifacts for an action type
        /// with a category of <c>source</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionType_OutputArtifactDetails_MaximumCount")]
        public System.Int32? OutputArtifactDetails_MaximumCount { get; set; }
        #endregion
        
        #region Parameter InputArtifactDetails_MinimumCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of artifacts that can be used with the action type. For example,
        /// you should specify a minimum and maximum of zero input artifacts for an action type
        /// with a category of <c>source</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionType_InputArtifactDetails_MinimumCount")]
        public System.Int32? InputArtifactDetails_MinimumCount { get; set; }
        #endregion
        
        #region Parameter OutputArtifactDetails_MinimumCount
        /// <summary>
        /// <para>
        /// <para>The minimum number of artifacts that can be used with the action type. For example,
        /// you should specify a minimum and maximum of zero input artifacts for an action type
        /// with a category of <c>source</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionType_OutputArtifactDetails_MinimumCount")]
        public System.Int32? OutputArtifactDetails_MinimumCount { get; set; }
        #endregion
        
        #region Parameter Id_Owner
        /// <summary>
        /// <para>
        /// <para>The creator of the action type being called: <c>AWS</c> or <c>ThirdParty</c>.</para>
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
        [Alias("ActionType_Id_Owner")]
        public System.String Id_Owner { get; set; }
        #endregion
        
        #region Parameter Executor_PolicyStatementsTemplate
        /// <summary>
        /// <para>
        /// <para>The policy statement that specifies the permissions in the CodePipeline customer account
        /// that are needed to successfully run an action.</para><para>To grant permission to another account, specify the account ID as the Principal, a
        /// domain-style identifier defined by the service, for example <c>codepipeline.amazonaws.com</c>.</para><note><para>The size of the passed JSON policy document cannot exceed 2048 characters.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Executor_PolicyStatementsTemplate")]
        public System.String Executor_PolicyStatementsTemplate { get; set; }
        #endregion
        
        #region Parameter JobWorkerExecutorConfiguration_PollingAccount
        /// <summary>
        /// <para>
        /// <para>The accounts in which the job worker is configured and might poll for jobs as part
        /// of the action execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Executor_Configuration_JobWorkerExecutorConfiguration_PollingAccounts")]
        public System.String[] JobWorkerExecutorConfiguration_PollingAccount { get; set; }
        #endregion
        
        #region Parameter JobWorkerExecutorConfiguration_PollingServicePrincipal
        /// <summary>
        /// <para>
        /// <para>The service Principals in which the job worker is configured and might poll for jobs
        /// as part of the action execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Executor_Configuration_JobWorkerExecutorConfiguration_PollingServicePrincipals")]
        public System.String[] JobWorkerExecutorConfiguration_PollingServicePrincipal { get; set; }
        #endregion
        
        #region Parameter ActionType_Property
        /// <summary>
        /// <para>
        /// <para>The properties of the action type to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Properties")]
        public Amazon.CodePipeline.Model.ActionTypeProperty[] ActionType_Property { get; set; }
        #endregion
        
        #region Parameter Id_Provider
        /// <summary>
        /// <para>
        /// <para>The provider of the action type being called. The provider name is supplied when the
        /// action type is created.</para>
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
        [Alias("ActionType_Id_Provider")]
        public System.String Id_Provider { get; set; }
        #endregion
        
        #region Parameter Urls_RevisionUrlTemplate
        /// <summary>
        /// <para>
        /// <para>The URL returned to the CodePipeline console that contains a link to the page where
        /// customers can update or change the configuration of the external action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionType_Urls_RevisionUrlTemplate")]
        public System.String Urls_RevisionUrlTemplate { get; set; }
        #endregion
        
        #region Parameter Executor_Type
        /// <summary>
        /// <para>
        /// <para>The integration model used to create and update the action type, <c>Lambda</c> or
        /// <c>JobWorker</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ActionType_Executor_Type")]
        [AWSConstantClassSource("Amazon.CodePipeline.ExecutorType")]
        public Amazon.CodePipeline.ExecutorType Executor_Type { get; set; }
        #endregion
        
        #region Parameter Id_Version
        /// <summary>
        /// <para>
        /// <para>A string that describes the action type version.</para>
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
        [Alias("ActionType_Id_Version")]
        public System.String Id_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.UpdateActionTypeResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CPActionType (UpdateActionType)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.UpdateActionTypeResponse, UpdateCPActionTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionType_Description = this.ActionType_Description;
            if (this.JobWorkerExecutorConfiguration_PollingAccount != null)
            {
                context.JobWorkerExecutorConfiguration_PollingAccount = new List<System.String>(this.JobWorkerExecutorConfiguration_PollingAccount);
            }
            if (this.JobWorkerExecutorConfiguration_PollingServicePrincipal != null)
            {
                context.JobWorkerExecutorConfiguration_PollingServicePrincipal = new List<System.String>(this.JobWorkerExecutorConfiguration_PollingServicePrincipal);
            }
            context.LambdaExecutorConfiguration_LambdaFunctionArn = this.LambdaExecutorConfiguration_LambdaFunctionArn;
            context.Executor_JobTimeout = this.Executor_JobTimeout;
            context.Executor_PolicyStatementsTemplate = this.Executor_PolicyStatementsTemplate;
            context.Executor_Type = this.Executor_Type;
            #if MODULAR
            if (this.Executor_Type == null && ParameterWasBound(nameof(this.Executor_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Executor_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id_Category = this.Id_Category;
            #if MODULAR
            if (this.Id_Category == null && ParameterWasBound(nameof(this.Id_Category)))
            {
                WriteWarning("You are passing $null as a value for parameter Id_Category which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id_Owner = this.Id_Owner;
            #if MODULAR
            if (this.Id_Owner == null && ParameterWasBound(nameof(this.Id_Owner)))
            {
                WriteWarning("You are passing $null as a value for parameter Id_Owner which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id_Provider = this.Id_Provider;
            #if MODULAR
            if (this.Id_Provider == null && ParameterWasBound(nameof(this.Id_Provider)))
            {
                WriteWarning("You are passing $null as a value for parameter Id_Provider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id_Version = this.Id_Version;
            #if MODULAR
            if (this.Id_Version == null && ParameterWasBound(nameof(this.Id_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter Id_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputArtifactDetails_MaximumCount = this.InputArtifactDetails_MaximumCount;
            #if MODULAR
            if (this.InputArtifactDetails_MaximumCount == null && ParameterWasBound(nameof(this.InputArtifactDetails_MaximumCount)))
            {
                WriteWarning("You are passing $null as a value for parameter InputArtifactDetails_MaximumCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputArtifactDetails_MinimumCount = this.InputArtifactDetails_MinimumCount;
            #if MODULAR
            if (this.InputArtifactDetails_MinimumCount == null && ParameterWasBound(nameof(this.InputArtifactDetails_MinimumCount)))
            {
                WriteWarning("You are passing $null as a value for parameter InputArtifactDetails_MinimumCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputArtifactDetails_MaximumCount = this.OutputArtifactDetails_MaximumCount;
            #if MODULAR
            if (this.OutputArtifactDetails_MaximumCount == null && ParameterWasBound(nameof(this.OutputArtifactDetails_MaximumCount)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputArtifactDetails_MaximumCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputArtifactDetails_MinimumCount = this.OutputArtifactDetails_MinimumCount;
            #if MODULAR
            if (this.OutputArtifactDetails_MinimumCount == null && ParameterWasBound(nameof(this.OutputArtifactDetails_MinimumCount)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputArtifactDetails_MinimumCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permissions_AllowedAccount != null)
            {
                context.Permissions_AllowedAccount = new List<System.String>(this.Permissions_AllowedAccount);
            }
            if (this.ActionType_Property != null)
            {
                context.ActionType_Property = new List<Amazon.CodePipeline.Model.ActionTypeProperty>(this.ActionType_Property);
            }
            context.Urls_ConfigurationUrl = this.Urls_ConfigurationUrl;
            context.Urls_EntityUrlTemplate = this.Urls_EntityUrlTemplate;
            context.Urls_ExecutionUrlTemplate = this.Urls_ExecutionUrlTemplate;
            context.Urls_RevisionUrlTemplate = this.Urls_RevisionUrlTemplate;
            
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
            var request = new Amazon.CodePipeline.Model.UpdateActionTypeRequest();
            
            
             // populate ActionType
            var requestActionTypeIsNull = true;
            request.ActionType = new Amazon.CodePipeline.Model.ActionTypeDeclaration();
            System.String requestActionType_actionType_Description = null;
            if (cmdletContext.ActionType_Description != null)
            {
                requestActionType_actionType_Description = cmdletContext.ActionType_Description;
            }
            if (requestActionType_actionType_Description != null)
            {
                request.ActionType.Description = requestActionType_actionType_Description;
                requestActionTypeIsNull = false;
            }
            List<Amazon.CodePipeline.Model.ActionTypeProperty> requestActionType_actionType_Property = null;
            if (cmdletContext.ActionType_Property != null)
            {
                requestActionType_actionType_Property = cmdletContext.ActionType_Property;
            }
            if (requestActionType_actionType_Property != null)
            {
                request.ActionType.Properties = requestActionType_actionType_Property;
                requestActionTypeIsNull = false;
            }
            Amazon.CodePipeline.Model.ActionTypePermissions requestActionType_actionType_Permissions = null;
            
             // populate Permissions
            var requestActionType_actionType_PermissionsIsNull = true;
            requestActionType_actionType_Permissions = new Amazon.CodePipeline.Model.ActionTypePermissions();
            List<System.String> requestActionType_actionType_Permissions_permissions_AllowedAccount = null;
            if (cmdletContext.Permissions_AllowedAccount != null)
            {
                requestActionType_actionType_Permissions_permissions_AllowedAccount = cmdletContext.Permissions_AllowedAccount;
            }
            if (requestActionType_actionType_Permissions_permissions_AllowedAccount != null)
            {
                requestActionType_actionType_Permissions.AllowedAccounts = requestActionType_actionType_Permissions_permissions_AllowedAccount;
                requestActionType_actionType_PermissionsIsNull = false;
            }
             // determine if requestActionType_actionType_Permissions should be set to null
            if (requestActionType_actionType_PermissionsIsNull)
            {
                requestActionType_actionType_Permissions = null;
            }
            if (requestActionType_actionType_Permissions != null)
            {
                request.ActionType.Permissions = requestActionType_actionType_Permissions;
                requestActionTypeIsNull = false;
            }
            Amazon.CodePipeline.Model.ActionTypeArtifactDetails requestActionType_actionType_InputArtifactDetails = null;
            
             // populate InputArtifactDetails
            var requestActionType_actionType_InputArtifactDetailsIsNull = true;
            requestActionType_actionType_InputArtifactDetails = new Amazon.CodePipeline.Model.ActionTypeArtifactDetails();
            System.Int32? requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MaximumCount = null;
            if (cmdletContext.InputArtifactDetails_MaximumCount != null)
            {
                requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MaximumCount = cmdletContext.InputArtifactDetails_MaximumCount.Value;
            }
            if (requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MaximumCount != null)
            {
                requestActionType_actionType_InputArtifactDetails.MaximumCount = requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MaximumCount.Value;
                requestActionType_actionType_InputArtifactDetailsIsNull = false;
            }
            System.Int32? requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MinimumCount = null;
            if (cmdletContext.InputArtifactDetails_MinimumCount != null)
            {
                requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MinimumCount = cmdletContext.InputArtifactDetails_MinimumCount.Value;
            }
            if (requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MinimumCount != null)
            {
                requestActionType_actionType_InputArtifactDetails.MinimumCount = requestActionType_actionType_InputArtifactDetails_inputArtifactDetails_MinimumCount.Value;
                requestActionType_actionType_InputArtifactDetailsIsNull = false;
            }
             // determine if requestActionType_actionType_InputArtifactDetails should be set to null
            if (requestActionType_actionType_InputArtifactDetailsIsNull)
            {
                requestActionType_actionType_InputArtifactDetails = null;
            }
            if (requestActionType_actionType_InputArtifactDetails != null)
            {
                request.ActionType.InputArtifactDetails = requestActionType_actionType_InputArtifactDetails;
                requestActionTypeIsNull = false;
            }
            Amazon.CodePipeline.Model.ActionTypeArtifactDetails requestActionType_actionType_OutputArtifactDetails = null;
            
             // populate OutputArtifactDetails
            var requestActionType_actionType_OutputArtifactDetailsIsNull = true;
            requestActionType_actionType_OutputArtifactDetails = new Amazon.CodePipeline.Model.ActionTypeArtifactDetails();
            System.Int32? requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MaximumCount = null;
            if (cmdletContext.OutputArtifactDetails_MaximumCount != null)
            {
                requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MaximumCount = cmdletContext.OutputArtifactDetails_MaximumCount.Value;
            }
            if (requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MaximumCount != null)
            {
                requestActionType_actionType_OutputArtifactDetails.MaximumCount = requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MaximumCount.Value;
                requestActionType_actionType_OutputArtifactDetailsIsNull = false;
            }
            System.Int32? requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MinimumCount = null;
            if (cmdletContext.OutputArtifactDetails_MinimumCount != null)
            {
                requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MinimumCount = cmdletContext.OutputArtifactDetails_MinimumCount.Value;
            }
            if (requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MinimumCount != null)
            {
                requestActionType_actionType_OutputArtifactDetails.MinimumCount = requestActionType_actionType_OutputArtifactDetails_outputArtifactDetails_MinimumCount.Value;
                requestActionType_actionType_OutputArtifactDetailsIsNull = false;
            }
             // determine if requestActionType_actionType_OutputArtifactDetails should be set to null
            if (requestActionType_actionType_OutputArtifactDetailsIsNull)
            {
                requestActionType_actionType_OutputArtifactDetails = null;
            }
            if (requestActionType_actionType_OutputArtifactDetails != null)
            {
                request.ActionType.OutputArtifactDetails = requestActionType_actionType_OutputArtifactDetails;
                requestActionTypeIsNull = false;
            }
            Amazon.CodePipeline.Model.ActionTypeExecutor requestActionType_actionType_Executor = null;
            
             // populate Executor
            var requestActionType_actionType_ExecutorIsNull = true;
            requestActionType_actionType_Executor = new Amazon.CodePipeline.Model.ActionTypeExecutor();
            System.Int32? requestActionType_actionType_Executor_executor_JobTimeout = null;
            if (cmdletContext.Executor_JobTimeout != null)
            {
                requestActionType_actionType_Executor_executor_JobTimeout = cmdletContext.Executor_JobTimeout.Value;
            }
            if (requestActionType_actionType_Executor_executor_JobTimeout != null)
            {
                requestActionType_actionType_Executor.JobTimeout = requestActionType_actionType_Executor_executor_JobTimeout.Value;
                requestActionType_actionType_ExecutorIsNull = false;
            }
            System.String requestActionType_actionType_Executor_executor_PolicyStatementsTemplate = null;
            if (cmdletContext.Executor_PolicyStatementsTemplate != null)
            {
                requestActionType_actionType_Executor_executor_PolicyStatementsTemplate = cmdletContext.Executor_PolicyStatementsTemplate;
            }
            if (requestActionType_actionType_Executor_executor_PolicyStatementsTemplate != null)
            {
                requestActionType_actionType_Executor.PolicyStatementsTemplate = requestActionType_actionType_Executor_executor_PolicyStatementsTemplate;
                requestActionType_actionType_ExecutorIsNull = false;
            }
            Amazon.CodePipeline.ExecutorType requestActionType_actionType_Executor_executor_Type = null;
            if (cmdletContext.Executor_Type != null)
            {
                requestActionType_actionType_Executor_executor_Type = cmdletContext.Executor_Type;
            }
            if (requestActionType_actionType_Executor_executor_Type != null)
            {
                requestActionType_actionType_Executor.Type = requestActionType_actionType_Executor_executor_Type;
                requestActionType_actionType_ExecutorIsNull = false;
            }
            Amazon.CodePipeline.Model.ExecutorConfiguration requestActionType_actionType_Executor_actionType_Executor_Configuration = null;
            
             // populate Configuration
            var requestActionType_actionType_Executor_actionType_Executor_ConfigurationIsNull = true;
            requestActionType_actionType_Executor_actionType_Executor_Configuration = new Amazon.CodePipeline.Model.ExecutorConfiguration();
            Amazon.CodePipeline.Model.LambdaExecutorConfiguration requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration = null;
            
             // populate LambdaExecutorConfiguration
            var requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfigurationIsNull = true;
            requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration = new Amazon.CodePipeline.Model.LambdaExecutorConfiguration();
            System.String requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration_lambdaExecutorConfiguration_LambdaFunctionArn = null;
            if (cmdletContext.LambdaExecutorConfiguration_LambdaFunctionArn != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration_lambdaExecutorConfiguration_LambdaFunctionArn = cmdletContext.LambdaExecutorConfiguration_LambdaFunctionArn;
            }
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration_lambdaExecutorConfiguration_LambdaFunctionArn != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration.LambdaFunctionArn = requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration_lambdaExecutorConfiguration_LambdaFunctionArn;
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfigurationIsNull = false;
            }
             // determine if requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration should be set to null
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfigurationIsNull)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration = null;
            }
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration.LambdaExecutorConfiguration = requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_LambdaExecutorConfiguration;
                requestActionType_actionType_Executor_actionType_Executor_ConfigurationIsNull = false;
            }
            Amazon.CodePipeline.Model.JobWorkerExecutorConfiguration requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration = null;
            
             // populate JobWorkerExecutorConfiguration
            var requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfigurationIsNull = true;
            requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration = new Amazon.CodePipeline.Model.JobWorkerExecutorConfiguration();
            List<System.String> requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingAccount = null;
            if (cmdletContext.JobWorkerExecutorConfiguration_PollingAccount != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingAccount = cmdletContext.JobWorkerExecutorConfiguration_PollingAccount;
            }
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingAccount != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration.PollingAccounts = requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingAccount;
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfigurationIsNull = false;
            }
            List<System.String> requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingServicePrincipal = null;
            if (cmdletContext.JobWorkerExecutorConfiguration_PollingServicePrincipal != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingServicePrincipal = cmdletContext.JobWorkerExecutorConfiguration_PollingServicePrincipal;
            }
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingServicePrincipal != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration.PollingServicePrincipals = requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration_jobWorkerExecutorConfiguration_PollingServicePrincipal;
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfigurationIsNull = false;
            }
             // determine if requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration should be set to null
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfigurationIsNull)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration = null;
            }
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration != null)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration.JobWorkerExecutorConfiguration = requestActionType_actionType_Executor_actionType_Executor_Configuration_actionType_Executor_Configuration_JobWorkerExecutorConfiguration;
                requestActionType_actionType_Executor_actionType_Executor_ConfigurationIsNull = false;
            }
             // determine if requestActionType_actionType_Executor_actionType_Executor_Configuration should be set to null
            if (requestActionType_actionType_Executor_actionType_Executor_ConfigurationIsNull)
            {
                requestActionType_actionType_Executor_actionType_Executor_Configuration = null;
            }
            if (requestActionType_actionType_Executor_actionType_Executor_Configuration != null)
            {
                requestActionType_actionType_Executor.Configuration = requestActionType_actionType_Executor_actionType_Executor_Configuration;
                requestActionType_actionType_ExecutorIsNull = false;
            }
             // determine if requestActionType_actionType_Executor should be set to null
            if (requestActionType_actionType_ExecutorIsNull)
            {
                requestActionType_actionType_Executor = null;
            }
            if (requestActionType_actionType_Executor != null)
            {
                request.ActionType.Executor = requestActionType_actionType_Executor;
                requestActionTypeIsNull = false;
            }
            Amazon.CodePipeline.Model.ActionTypeIdentifier requestActionType_actionType_Id = null;
            
             // populate Id
            var requestActionType_actionType_IdIsNull = true;
            requestActionType_actionType_Id = new Amazon.CodePipeline.Model.ActionTypeIdentifier();
            Amazon.CodePipeline.ActionCategory requestActionType_actionType_Id_id_Category = null;
            if (cmdletContext.Id_Category != null)
            {
                requestActionType_actionType_Id_id_Category = cmdletContext.Id_Category;
            }
            if (requestActionType_actionType_Id_id_Category != null)
            {
                requestActionType_actionType_Id.Category = requestActionType_actionType_Id_id_Category;
                requestActionType_actionType_IdIsNull = false;
            }
            System.String requestActionType_actionType_Id_id_Owner = null;
            if (cmdletContext.Id_Owner != null)
            {
                requestActionType_actionType_Id_id_Owner = cmdletContext.Id_Owner;
            }
            if (requestActionType_actionType_Id_id_Owner != null)
            {
                requestActionType_actionType_Id.Owner = requestActionType_actionType_Id_id_Owner;
                requestActionType_actionType_IdIsNull = false;
            }
            System.String requestActionType_actionType_Id_id_Provider = null;
            if (cmdletContext.Id_Provider != null)
            {
                requestActionType_actionType_Id_id_Provider = cmdletContext.Id_Provider;
            }
            if (requestActionType_actionType_Id_id_Provider != null)
            {
                requestActionType_actionType_Id.Provider = requestActionType_actionType_Id_id_Provider;
                requestActionType_actionType_IdIsNull = false;
            }
            System.String requestActionType_actionType_Id_id_Version = null;
            if (cmdletContext.Id_Version != null)
            {
                requestActionType_actionType_Id_id_Version = cmdletContext.Id_Version;
            }
            if (requestActionType_actionType_Id_id_Version != null)
            {
                requestActionType_actionType_Id.Version = requestActionType_actionType_Id_id_Version;
                requestActionType_actionType_IdIsNull = false;
            }
             // determine if requestActionType_actionType_Id should be set to null
            if (requestActionType_actionType_IdIsNull)
            {
                requestActionType_actionType_Id = null;
            }
            if (requestActionType_actionType_Id != null)
            {
                request.ActionType.Id = requestActionType_actionType_Id;
                requestActionTypeIsNull = false;
            }
            Amazon.CodePipeline.Model.ActionTypeUrls requestActionType_actionType_Urls = null;
            
             // populate Urls
            var requestActionType_actionType_UrlsIsNull = true;
            requestActionType_actionType_Urls = new Amazon.CodePipeline.Model.ActionTypeUrls();
            System.String requestActionType_actionType_Urls_urls_ConfigurationUrl = null;
            if (cmdletContext.Urls_ConfigurationUrl != null)
            {
                requestActionType_actionType_Urls_urls_ConfigurationUrl = cmdletContext.Urls_ConfigurationUrl;
            }
            if (requestActionType_actionType_Urls_urls_ConfigurationUrl != null)
            {
                requestActionType_actionType_Urls.ConfigurationUrl = requestActionType_actionType_Urls_urls_ConfigurationUrl;
                requestActionType_actionType_UrlsIsNull = false;
            }
            System.String requestActionType_actionType_Urls_urls_EntityUrlTemplate = null;
            if (cmdletContext.Urls_EntityUrlTemplate != null)
            {
                requestActionType_actionType_Urls_urls_EntityUrlTemplate = cmdletContext.Urls_EntityUrlTemplate;
            }
            if (requestActionType_actionType_Urls_urls_EntityUrlTemplate != null)
            {
                requestActionType_actionType_Urls.EntityUrlTemplate = requestActionType_actionType_Urls_urls_EntityUrlTemplate;
                requestActionType_actionType_UrlsIsNull = false;
            }
            System.String requestActionType_actionType_Urls_urls_ExecutionUrlTemplate = null;
            if (cmdletContext.Urls_ExecutionUrlTemplate != null)
            {
                requestActionType_actionType_Urls_urls_ExecutionUrlTemplate = cmdletContext.Urls_ExecutionUrlTemplate;
            }
            if (requestActionType_actionType_Urls_urls_ExecutionUrlTemplate != null)
            {
                requestActionType_actionType_Urls.ExecutionUrlTemplate = requestActionType_actionType_Urls_urls_ExecutionUrlTemplate;
                requestActionType_actionType_UrlsIsNull = false;
            }
            System.String requestActionType_actionType_Urls_urls_RevisionUrlTemplate = null;
            if (cmdletContext.Urls_RevisionUrlTemplate != null)
            {
                requestActionType_actionType_Urls_urls_RevisionUrlTemplate = cmdletContext.Urls_RevisionUrlTemplate;
            }
            if (requestActionType_actionType_Urls_urls_RevisionUrlTemplate != null)
            {
                requestActionType_actionType_Urls.RevisionUrlTemplate = requestActionType_actionType_Urls_urls_RevisionUrlTemplate;
                requestActionType_actionType_UrlsIsNull = false;
            }
             // determine if requestActionType_actionType_Urls should be set to null
            if (requestActionType_actionType_UrlsIsNull)
            {
                requestActionType_actionType_Urls = null;
            }
            if (requestActionType_actionType_Urls != null)
            {
                request.ActionType.Urls = requestActionType_actionType_Urls;
                requestActionTypeIsNull = false;
            }
             // determine if request.ActionType should be set to null
            if (requestActionTypeIsNull)
            {
                request.ActionType = null;
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
        
        private Amazon.CodePipeline.Model.UpdateActionTypeResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.UpdateActionTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "UpdateActionType");
            try
            {
                return client.UpdateActionTypeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActionType_Description { get; set; }
            public List<System.String> JobWorkerExecutorConfiguration_PollingAccount { get; set; }
            public List<System.String> JobWorkerExecutorConfiguration_PollingServicePrincipal { get; set; }
            public System.String LambdaExecutorConfiguration_LambdaFunctionArn { get; set; }
            public System.Int32? Executor_JobTimeout { get; set; }
            public System.String Executor_PolicyStatementsTemplate { get; set; }
            public Amazon.CodePipeline.ExecutorType Executor_Type { get; set; }
            public Amazon.CodePipeline.ActionCategory Id_Category { get; set; }
            public System.String Id_Owner { get; set; }
            public System.String Id_Provider { get; set; }
            public System.String Id_Version { get; set; }
            public System.Int32? InputArtifactDetails_MaximumCount { get; set; }
            public System.Int32? InputArtifactDetails_MinimumCount { get; set; }
            public System.Int32? OutputArtifactDetails_MaximumCount { get; set; }
            public System.Int32? OutputArtifactDetails_MinimumCount { get; set; }
            public List<System.String> Permissions_AllowedAccount { get; set; }
            public List<Amazon.CodePipeline.Model.ActionTypeProperty> ActionType_Property { get; set; }
            public System.String Urls_ConfigurationUrl { get; set; }
            public System.String Urls_EntityUrlTemplate { get; set; }
            public System.String Urls_ExecutionUrlTemplate { get; set; }
            public System.String Urls_RevisionUrlTemplate { get; set; }
            public System.Func<Amazon.CodePipeline.Model.UpdateActionTypeResponse, UpdateCPActionTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
