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
using Amazon.MigrationHubOrchestrator;
using Amazon.MigrationHubOrchestrator.Model;

namespace Amazon.PowerShell.Cmdlets.MHO
{
    /// <summary>
    /// Create a workflow to orchestrate your migrations.
    /// </summary>
    [Cmdlet("New", "MHOWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse")]
    [AWSCmdlet("Calls the AWS Migration Hub Orchestrator CreateWorkflow API operation.", Operation = new[] {"CreateWorkflow"}, SelectReturnType = typeof(Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse",
        "This cmdlet returns an Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse object containing multiple properties."
    )]
    public partial class NewMHOWorkflowCmdlet : AmazonMigrationHubOrchestratorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationConfigurationId
        /// <summary>
        /// <para>
        /// <para>The configuration ID of the application configured in Application Discovery Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationConfigurationId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the migration workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InputParameter
        /// <summary>
        /// <para>
        /// <para>The input parameters required to create a migration workflow.</para>
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
        [Alias("InputParameters")]
        public System.Collections.Hashtable InputParameter { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the migration workflow.</para>
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
        
        #region Parameter StepTarget
        /// <summary>
        /// <para>
        /// <para>The servers on which a step will be run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StepTargets")]
        public System.String[] StepTarget { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add on a migration workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the template.</para>
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
        public System.String TemplateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MHOWorkflow (CreateWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse, NewMHOWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationConfigurationId = this.ApplicationConfigurationId;
            context.Description = this.Description;
            if (this.InputParameter != null)
            {
                context.InputParameter = new Dictionary<System.String, Amazon.MigrationHubOrchestrator.Model.StepInput>(StringComparer.Ordinal);
                foreach (var hashKey in this.InputParameter.Keys)
                {
                    context.InputParameter.Add((String)hashKey, (Amazon.MigrationHubOrchestrator.Model.StepInput)(this.InputParameter[hashKey]));
                }
            }
            #if MODULAR
            if (this.InputParameter == null && ParameterWasBound(nameof(this.InputParameter)))
            {
                WriteWarning("You are passing $null as a value for parameter InputParameter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StepTarget != null)
            {
                context.StepTarget = new List<System.String>(this.StepTarget);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TemplateId = this.TemplateId;
            #if MODULAR
            if (this.TemplateId == null && ParameterWasBound(nameof(this.TemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MigrationHubOrchestrator.Model.CreateWorkflowRequest();
            
            if (cmdletContext.ApplicationConfigurationId != null)
            {
                request.ApplicationConfigurationId = cmdletContext.ApplicationConfigurationId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InputParameter != null)
            {
                request.InputParameters = cmdletContext.InputParameter;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.StepTarget != null)
            {
                request.StepTargets = cmdletContext.StepTarget;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateId != null)
            {
                request.TemplateId = cmdletContext.TemplateId;
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
        
        private Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse CallAWSServiceOperation(IAmazonMigrationHubOrchestrator client, Amazon.MigrationHubOrchestrator.Model.CreateWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Orchestrator", "CreateWorkflow");
            try
            {
                #if DESKTOP
                return client.CreateWorkflow(request);
                #elif CORECLR
                return client.CreateWorkflowAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationConfigurationId { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, Amazon.MigrationHubOrchestrator.Model.StepInput> InputParameter { get; set; }
            public System.String Name { get; set; }
            public List<System.String> StepTarget { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TemplateId { get; set; }
            public System.Func<Amazon.MigrationHubOrchestrator.Model.CreateWorkflowResponse, NewMHOWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
