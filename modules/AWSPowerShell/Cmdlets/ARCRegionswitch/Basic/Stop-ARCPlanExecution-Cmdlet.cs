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
    /// Cancels an in-progress plan execution. This operation stops the execution of the plan
    /// and prevents any further steps from being processed.
    /// 
    ///  
    /// <para>
    /// You must specify the plan ARN and execution ID. You can also provide an optional comment
    /// explaining why the execution was canceled.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "ARCPlanExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the ARC - Region switch CancelPlanExecution API operation.", Operation = new[] {"CancelPlanExecution"}, SelectReturnType = typeof(Amazon.ARCRegionswitch.Model.CancelPlanExecutionResponse))]
    [AWSCmdletOutput("None or Amazon.ARCRegionswitch.Model.CancelPlanExecutionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ARCRegionswitch.Model.CancelPlanExecutionResponse) be returned by specifying '-Select *'."
    )]
    public partial class StopARCPlanExecutionCmdlet : AmazonARCRegionswitchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>A comment that you can enter about canceling a plan execution step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter ExecutionId
        /// <summary>
        /// <para>
        /// <para>The execution identifier of a plan execution.</para>
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
        /// <para>The Amazon Resource Name (ARN) of the plan.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCRegionswitch.Model.CancelPlanExecutionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PlanArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-ARCPlanExecution (CancelPlanExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCRegionswitch.Model.CancelPlanExecutionResponse, StopARCPlanExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Comment = this.Comment;
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
            var request = new Amazon.ARCRegionswitch.Model.CancelPlanExecutionRequest();
            
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
        
        private Amazon.ARCRegionswitch.Model.CancelPlanExecutionResponse CallAWSServiceOperation(IAmazonARCRegionswitch client, Amazon.ARCRegionswitch.Model.CancelPlanExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "ARC - Region switch", "CancelPlanExecution");
            try
            {
                #if DESKTOP
                return client.CancelPlanExecution(request);
                #elif CORECLR
                return client.CancelPlanExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String Comment { get; set; }
            public System.String ExecutionId { get; set; }
            public System.String PlanArn { get; set; }
            public System.Func<Amazon.ARCRegionswitch.Model.CancelPlanExecutionResponse, StopARCPlanExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
