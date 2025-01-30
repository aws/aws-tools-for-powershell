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
using Amazon.MigrationHubOrchestrator;
using Amazon.MigrationHubOrchestrator.Model;

namespace Amazon.PowerShell.Cmdlets.MHO
{
    /// <summary>
    /// Update a step in a migration workflow.
    /// </summary>
    [Cmdlet("Update", "MHOWorkflowStep", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse")]
    [AWSCmdlet("Calls the AWS Migration Hub Orchestrator UpdateWorkflowStep API operation.", Operation = new[] {"UpdateWorkflowStep"}, SelectReturnType = typeof(Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse",
        "This cmdlet returns an Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse object containing multiple properties."
    )]
    public partial class UpdateMHOWorkflowStepCmdlet : AmazonMigrationHubOrchestratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the step.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Command_Linux
        /// <summary>
        /// <para>
        /// <para>Command for Linux.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkflowStepAutomationConfiguration_Command_Linux")]
        public System.String Command_Linux { get; set; }
        #endregion
        
        #region Parameter ScriptLocationS3Key_Linux
        /// <summary>
        /// <para>
        /// <para>The script location for Linux.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkflowStepAutomationConfiguration_ScriptLocationS3Key_Linux")]
        public System.String ScriptLocationS3Key_Linux { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Next
        /// <summary>
        /// <para>
        /// <para>The next step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Next { get; set; }
        #endregion
        
        #region Parameter Output
        /// <summary>
        /// <para>
        /// <para>The outputs of a step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Outputs")]
        public Amazon.MigrationHubOrchestrator.Model.WorkflowStepOutput[] Output { get; set; }
        #endregion
        
        #region Parameter Previou
        /// <summary>
        /// <para>
        /// <para>The previous step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Previous")]
        public System.String[] Previou { get; set; }
        #endregion
        
        #region Parameter WorkflowStepAutomationConfiguration_RunEnvironment
        /// <summary>
        /// <para>
        /// <para>The source or target environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubOrchestrator.RunEnvironment")]
        public Amazon.MigrationHubOrchestrator.RunEnvironment WorkflowStepAutomationConfiguration_RunEnvironment { get; set; }
        #endregion
        
        #region Parameter WorkflowStepAutomationConfiguration_ScriptLocationS3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket where the script is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkflowStepAutomationConfiguration_ScriptLocationS3Bucket { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubOrchestrator.StepStatus")]
        public Amazon.MigrationHubOrchestrator.StepStatus Status { get; set; }
        #endregion
        
        #region Parameter StepActionType
        /// <summary>
        /// <para>
        /// <para>The action type of the step. You must run and update the status of a manual step for
        /// the workflow to continue after the completion of the step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubOrchestrator.StepActionType")]
        public Amazon.MigrationHubOrchestrator.StepActionType StepActionType { get; set; }
        #endregion
        
        #region Parameter StepGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the step group.</para>
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
        public System.String StepGroupId { get; set; }
        #endregion
        
        #region Parameter StepTarget
        /// <summary>
        /// <para>
        /// <para>The servers on which a step will be run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StepTarget { get; set; }
        #endregion
        
        #region Parameter WorkflowStepAutomationConfiguration_TargetType
        /// <summary>
        /// <para>
        /// <para>The servers on which to run the script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubOrchestrator.TargetType")]
        public Amazon.MigrationHubOrchestrator.TargetType WorkflowStepAutomationConfiguration_TargetType { get; set; }
        #endregion
        
        #region Parameter Command_Window
        /// <summary>
        /// <para>
        /// <para>Command for Windows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkflowStepAutomationConfiguration_Command_Windows")]
        public System.String Command_Window { get; set; }
        #endregion
        
        #region Parameter ScriptLocationS3Key_Window
        /// <summary>
        /// <para>
        /// <para>The script location for Windows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkflowStepAutomationConfiguration_ScriptLocationS3Key_Windows")]
        public System.String ScriptLocationS3Key_Window { get; set; }
        #endregion
        
        #region Parameter WorkflowId
        /// <summary>
        /// <para>
        /// <para>The ID of the migration workflow.</para>
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
        public System.String WorkflowId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MHOWorkflowStep (UpdateWorkflowStep)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse, UpdateMHOWorkflowStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.Next != null)
            {
                context.Next = new List<System.String>(this.Next);
            }
            if (this.Output != null)
            {
                context.Output = new List<Amazon.MigrationHubOrchestrator.Model.WorkflowStepOutput>(this.Output);
            }
            if (this.Previou != null)
            {
                context.Previou = new List<System.String>(this.Previou);
            }
            context.Status = this.Status;
            context.StepActionType = this.StepActionType;
            context.StepGroupId = this.StepGroupId;
            #if MODULAR
            if (this.StepGroupId == null && ParameterWasBound(nameof(this.StepGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter StepGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StepTarget != null)
            {
                context.StepTarget = new List<System.String>(this.StepTarget);
            }
            context.WorkflowId = this.WorkflowId;
            #if MODULAR
            if (this.WorkflowId == null && ParameterWasBound(nameof(this.WorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Command_Linux = this.Command_Linux;
            context.Command_Window = this.Command_Window;
            context.WorkflowStepAutomationConfiguration_RunEnvironment = this.WorkflowStepAutomationConfiguration_RunEnvironment;
            context.WorkflowStepAutomationConfiguration_ScriptLocationS3Bucket = this.WorkflowStepAutomationConfiguration_ScriptLocationS3Bucket;
            context.ScriptLocationS3Key_Linux = this.ScriptLocationS3Key_Linux;
            context.ScriptLocationS3Key_Window = this.ScriptLocationS3Key_Window;
            context.WorkflowStepAutomationConfiguration_TargetType = this.WorkflowStepAutomationConfiguration_TargetType;
            
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
            var request = new Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Next != null)
            {
                request.Next = cmdletContext.Next;
            }
            if (cmdletContext.Output != null)
            {
                request.Outputs = cmdletContext.Output;
            }
            if (cmdletContext.Previou != null)
            {
                request.Previous = cmdletContext.Previou;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.StepActionType != null)
            {
                request.StepActionType = cmdletContext.StepActionType;
            }
            if (cmdletContext.StepGroupId != null)
            {
                request.StepGroupId = cmdletContext.StepGroupId;
            }
            if (cmdletContext.StepTarget != null)
            {
                request.StepTarget = cmdletContext.StepTarget;
            }
            if (cmdletContext.WorkflowId != null)
            {
                request.WorkflowId = cmdletContext.WorkflowId;
            }
            
             // populate WorkflowStepAutomationConfiguration
            var requestWorkflowStepAutomationConfigurationIsNull = true;
            request.WorkflowStepAutomationConfiguration = new Amazon.MigrationHubOrchestrator.Model.WorkflowStepAutomationConfiguration();
            Amazon.MigrationHubOrchestrator.RunEnvironment requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_RunEnvironment = null;
            if (cmdletContext.WorkflowStepAutomationConfiguration_RunEnvironment != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_RunEnvironment = cmdletContext.WorkflowStepAutomationConfiguration_RunEnvironment;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_RunEnvironment != null)
            {
                request.WorkflowStepAutomationConfiguration.RunEnvironment = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_RunEnvironment;
                requestWorkflowStepAutomationConfigurationIsNull = false;
            }
            System.String requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Bucket = null;
            if (cmdletContext.WorkflowStepAutomationConfiguration_ScriptLocationS3Bucket != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Bucket = cmdletContext.WorkflowStepAutomationConfiguration_ScriptLocationS3Bucket;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Bucket != null)
            {
                request.WorkflowStepAutomationConfiguration.ScriptLocationS3Bucket = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Bucket;
                requestWorkflowStepAutomationConfigurationIsNull = false;
            }
            Amazon.MigrationHubOrchestrator.TargetType requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_TargetType = null;
            if (cmdletContext.WorkflowStepAutomationConfiguration_TargetType != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_TargetType = cmdletContext.WorkflowStepAutomationConfiguration_TargetType;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_TargetType != null)
            {
                request.WorkflowStepAutomationConfiguration.TargetType = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_TargetType;
                requestWorkflowStepAutomationConfigurationIsNull = false;
            }
            Amazon.MigrationHubOrchestrator.Model.PlatformCommand requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command = null;
            
             // populate Command
            var requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_CommandIsNull = true;
            requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command = new Amazon.MigrationHubOrchestrator.Model.PlatformCommand();
            System.String requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Linux = null;
            if (cmdletContext.Command_Linux != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Linux = cmdletContext.Command_Linux;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Linux != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command.Linux = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Linux;
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_CommandIsNull = false;
            }
            System.String requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Window = null;
            if (cmdletContext.Command_Window != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Window = cmdletContext.Command_Window;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Window != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command.Windows = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command_command_Window;
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_CommandIsNull = false;
            }
             // determine if requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command should be set to null
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_CommandIsNull)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command = null;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command != null)
            {
                request.WorkflowStepAutomationConfiguration.Command = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_Command;
                requestWorkflowStepAutomationConfigurationIsNull = false;
            }
            Amazon.MigrationHubOrchestrator.Model.PlatformScriptKey requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key = null;
            
             // populate ScriptLocationS3Key
            var requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3KeyIsNull = true;
            requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key = new Amazon.MigrationHubOrchestrator.Model.PlatformScriptKey();
            System.String requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Linux = null;
            if (cmdletContext.ScriptLocationS3Key_Linux != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Linux = cmdletContext.ScriptLocationS3Key_Linux;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Linux != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key.Linux = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Linux;
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3KeyIsNull = false;
            }
            System.String requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Window = null;
            if (cmdletContext.ScriptLocationS3Key_Window != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Window = cmdletContext.ScriptLocationS3Key_Window;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Window != null)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key.Windows = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key_scriptLocationS3Key_Window;
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3KeyIsNull = false;
            }
             // determine if requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key should be set to null
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3KeyIsNull)
            {
                requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key = null;
            }
            if (requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key != null)
            {
                request.WorkflowStepAutomationConfiguration.ScriptLocationS3Key = requestWorkflowStepAutomationConfiguration_workflowStepAutomationConfiguration_ScriptLocationS3Key;
                requestWorkflowStepAutomationConfigurationIsNull = false;
            }
             // determine if request.WorkflowStepAutomationConfiguration should be set to null
            if (requestWorkflowStepAutomationConfigurationIsNull)
            {
                request.WorkflowStepAutomationConfiguration = null;
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
        
        private Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse CallAWSServiceOperation(IAmazonMigrationHubOrchestrator client, Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Orchestrator", "UpdateWorkflowStep");
            try
            {
                #if DESKTOP
                return client.UpdateWorkflowStep(request);
                #elif CORECLR
                return client.UpdateWorkflowStepAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Next { get; set; }
            public List<Amazon.MigrationHubOrchestrator.Model.WorkflowStepOutput> Output { get; set; }
            public List<System.String> Previou { get; set; }
            public Amazon.MigrationHubOrchestrator.StepStatus Status { get; set; }
            public Amazon.MigrationHubOrchestrator.StepActionType StepActionType { get; set; }
            public System.String StepGroupId { get; set; }
            public List<System.String> StepTarget { get; set; }
            public System.String WorkflowId { get; set; }
            public System.String Command_Linux { get; set; }
            public System.String Command_Window { get; set; }
            public Amazon.MigrationHubOrchestrator.RunEnvironment WorkflowStepAutomationConfiguration_RunEnvironment { get; set; }
            public System.String WorkflowStepAutomationConfiguration_ScriptLocationS3Bucket { get; set; }
            public System.String ScriptLocationS3Key_Linux { get; set; }
            public System.String ScriptLocationS3Key_Window { get; set; }
            public Amazon.MigrationHubOrchestrator.TargetType WorkflowStepAutomationConfiguration_TargetType { get; set; }
            public System.Func<Amazon.MigrationHubOrchestrator.Model.UpdateWorkflowStepResponse, UpdateMHOWorkflowStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
