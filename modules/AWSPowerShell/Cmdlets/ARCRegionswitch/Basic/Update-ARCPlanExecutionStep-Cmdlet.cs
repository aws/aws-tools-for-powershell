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
using Amazon.ARCRegionswitch;
using Amazon.ARCRegionswitch.Model;

namespace Amazon.PowerShell.Cmdlets.ARC
{
    /// <summary>
    /// Updates a specific step in an in-progress plan execution. This operation allows you
    /// to modify the step's comment or action.
    /// </summary>
    [Cmdlet("Update", "ARCPlanExecutionStep", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the ARC - Region switch UpdatePlanExecutionStep API operation.", Operation = new[] {"UpdatePlanExecutionStep"}, SelectReturnType = typeof(Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepResponse))]
    [AWSCmdletOutput("None or Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateARCPlanExecutionStepCmdlet : AmazonARCRegionswitchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionToTake
        /// <summary>
        /// <para>
        /// <para>The updated action to take for the step. This can be used to skip or retry a step.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ARCRegionswitch.UpdatePlanExecutionStepAction")]
        public Amazon.ARCRegionswitch.UpdatePlanExecutionStepAction ActionToTake { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment about the plan execution.</para>
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
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter ExecutionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the plan execution containing the step to update.</para>
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
        public System.String ExecutionId { get; set; }
        #endregion
        
        #region Parameter PlanArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the plan containing the execution step to update.</para>
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
        public System.String PlanArn { get; set; }
        #endregion
        
        #region Parameter StepName
        /// <summary>
        /// <para>
        /// <para>The name of the execution step to update.</para>
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
        public System.String StepName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ARCPlanExecutionStep (UpdatePlanExecutionStep)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepResponse, UpdateARCPlanExecutionStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionToTake = this.ActionToTake;
            #if MODULAR
            if (this.ActionToTake == null && ParameterWasBound(nameof(this.ActionToTake)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionToTake which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Comment = this.Comment;
            #if MODULAR
            if (this.Comment == null && ParameterWasBound(nameof(this.Comment)))
            {
                WriteWarning("You are passing $null as a value for parameter Comment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionId = this.ExecutionId;
            #if MODULAR
            if (this.ExecutionId == null && ParameterWasBound(nameof(this.ExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlanArn = this.PlanArn;
            #if MODULAR
            if (this.PlanArn == null && ParameterWasBound(nameof(this.PlanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PlanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StepName = this.StepName;
            #if MODULAR
            if (this.StepName == null && ParameterWasBound(nameof(this.StepName)))
            {
                WriteWarning("You are passing $null as a value for parameter StepName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepRequest();
            
            if (cmdletContext.ActionToTake != null)
            {
                request.ActionToTake = cmdletContext.ActionToTake;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.ExecutionId != null)
            {
                request.ExecutionId = cmdletContext.ExecutionId;
            }
            if (cmdletContext.PlanArn != null)
            {
                request.PlanArn = cmdletContext.PlanArn;
            }
            if (cmdletContext.StepName != null)
            {
                request.StepName = cmdletContext.StepName;
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
        
        private Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepResponse CallAWSServiceOperation(IAmazonARCRegionswitch client, Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "ARC - Region switch", "UpdatePlanExecutionStep");
            try
            {
                #if DESKTOP
                return client.UpdatePlanExecutionStep(request);
                #elif CORECLR
                return client.UpdatePlanExecutionStepAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ARCRegionswitch.UpdatePlanExecutionStepAction ActionToTake { get; set; }
            public System.String Comment { get; set; }
            public System.String ExecutionId { get; set; }
            public System.String PlanArn { get; set; }
            public System.String StepName { get; set; }
            public System.Func<Amazon.ARCRegionswitch.Model.UpdatePlanExecutionStepResponse, UpdateARCPlanExecutionStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
