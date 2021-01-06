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
using Amazon.AuditManager;
using Amazon.AuditManager.Model;

namespace Amazon.PowerShell.Cmdlets.AUDM
{
    /// <summary>
    /// Updates a custom control in AWS Audit Manager.
    /// </summary>
    [Cmdlet("Edit", "AUDMControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AuditManager.Model.Control")]
    [AWSCmdlet("Calls the AWS Audit Manager UpdateControl API operation.", Operation = new[] {"UpdateControl"}, SelectReturnType = typeof(Amazon.AuditManager.Model.UpdateControlResponse))]
    [AWSCmdletOutput("Amazon.AuditManager.Model.Control or Amazon.AuditManager.Model.UpdateControlResponse",
        "This cmdlet returns an Amazon.AuditManager.Model.Control object.",
        "The service call response (type Amazon.AuditManager.Model.UpdateControlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditAUDMControlCmdlet : AmazonAuditManagerClientCmdlet, IExecutor
    {
        
        #region Parameter ActionPlanInstruction
        /// <summary>
        /// <para>
        /// <para> The recommended actions to carry out if the control is not fulfilled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionPlanInstructions")]
        public System.String ActionPlanInstruction { get; set; }
        #endregion
        
        #region Parameter ActionPlanTitle
        /// <summary>
        /// <para>
        /// <para> The title of the action plan for remediating the control. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionPlanTitle { get; set; }
        #endregion
        
        #region Parameter ControlId
        /// <summary>
        /// <para>
        /// <para> The identifier for the specified control. </para>
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
        public System.String ControlId { get; set; }
        #endregion
        
        #region Parameter ControlMappingSource
        /// <summary>
        /// <para>
        /// <para> The data mapping sources for the specified control. </para>
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
        [Alias("ControlMappingSources")]
        public Amazon.AuditManager.Model.ControlMappingSource[] ControlMappingSource { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The optional description of the control. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the control to be updated. </para>
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
        
        #region Parameter TestingInformation
        /// <summary>
        /// <para>
        /// <para> The steps that to follow to determine if the control has been satisfied. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TestingInformation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Control'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AuditManager.Model.UpdateControlResponse).
        /// Specifying the name of a property of type Amazon.AuditManager.Model.UpdateControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Control";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ControlId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ControlId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ControlId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-AUDMControl (UpdateControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AuditManager.Model.UpdateControlResponse, EditAUDMControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ControlId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActionPlanInstruction = this.ActionPlanInstruction;
            context.ActionPlanTitle = this.ActionPlanTitle;
            context.ControlId = this.ControlId;
            #if MODULAR
            if (this.ControlId == null && ParameterWasBound(nameof(this.ControlId)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ControlMappingSource != null)
            {
                context.ControlMappingSource = new List<Amazon.AuditManager.Model.ControlMappingSource>(this.ControlMappingSource);
            }
            #if MODULAR
            if (this.ControlMappingSource == null && ParameterWasBound(nameof(this.ControlMappingSource)))
            {
                WriteWarning("You are passing $null as a value for parameter ControlMappingSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TestingInformation = this.TestingInformation;
            
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
            var request = new Amazon.AuditManager.Model.UpdateControlRequest();
            
            if (cmdletContext.ActionPlanInstruction != null)
            {
                request.ActionPlanInstructions = cmdletContext.ActionPlanInstruction;
            }
            if (cmdletContext.ActionPlanTitle != null)
            {
                request.ActionPlanTitle = cmdletContext.ActionPlanTitle;
            }
            if (cmdletContext.ControlId != null)
            {
                request.ControlId = cmdletContext.ControlId;
            }
            if (cmdletContext.ControlMappingSource != null)
            {
                request.ControlMappingSources = cmdletContext.ControlMappingSource;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.TestingInformation != null)
            {
                request.TestingInformation = cmdletContext.TestingInformation;
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
        
        private Amazon.AuditManager.Model.UpdateControlResponse CallAWSServiceOperation(IAmazonAuditManager client, Amazon.AuditManager.Model.UpdateControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Audit Manager", "UpdateControl");
            try
            {
                #if DESKTOP
                return client.UpdateControl(request);
                #elif CORECLR
                return client.UpdateControlAsync(request).GetAwaiter().GetResult();
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
            public System.String ActionPlanInstruction { get; set; }
            public System.String ActionPlanTitle { get; set; }
            public System.String ControlId { get; set; }
            public List<Amazon.AuditManager.Model.ControlMappingSource> ControlMappingSource { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String TestingInformation { get; set; }
            public System.Func<Amazon.AuditManager.Model.UpdateControlResponse, EditAUDMControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Control;
        }
        
    }
}
