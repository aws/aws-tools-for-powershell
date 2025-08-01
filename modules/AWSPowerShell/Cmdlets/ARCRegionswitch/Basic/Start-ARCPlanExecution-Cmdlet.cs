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
    /// Starts the execution of a Region switch plan. You can execute a plan in either PRACTICE
    /// or RECOVERY mode.
    /// 
    ///  
    /// <para>
    /// In PRACTICE mode, the execution simulates the steps without making actual changes
    /// to your application's traffic routing. In RECOVERY mode, the execution performs actual
    /// changes to shift traffic between Regions.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "ARCPlanExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse")]
    [AWSCmdlet("Calls the ARC - Region switch StartPlanExecution API operation.", Operation = new[] {"StartPlanExecution"}, SelectReturnType = typeof(Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse))]
    [AWSCmdletOutput("Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse",
        "This cmdlet returns an Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse object containing multiple properties."
    )]
    public partial class StartARCPlanExecutionCmdlet : AmazonARCRegionswitchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action to perform. Valid values are ACTIVATE (to shift traffic to the target Region)
        /// or DEACTIVATE (to shift traffic away from the target Region).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ARCRegionswitch.ExecutionAction")]
        public Amazon.ARCRegionswitch.ExecutionAction Action { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>An optional comment explaining why the plan execution is being started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter LatestVersion
        /// <summary>
        /// <para>
        /// <para>A boolean value indicating whether to use the latest version of the plan. If set to
        /// false, you must specify a specific version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LatestVersion { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>The plan execution mode. Valid values are <c>Practice</c>, for testing without making
        /// actual changes, or <c>Recovery</c>, for actual traffic shifting and application recovery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ARCRegionswitch.ExecutionMode")]
        public Amazon.ARCRegionswitch.ExecutionMode Mode { get; set; }
        #endregion
        
        #region Parameter PlanArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the plan to execute.</para>
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
        
        #region Parameter TargetRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region to target with this execution. This is the Region that
        /// traffic will be shifted to or from, depending on the action.</para>
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
        public System.String TargetRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse).
        /// Specifying the name of a property of type Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ARCPlanExecution (StartPlanExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse, StartARCPlanExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            #if MODULAR
            if (this.Action == null && ParameterWasBound(nameof(this.Action)))
            {
                WriteWarning("You are passing $null as a value for parameter Action which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Comment = this.Comment;
            context.LatestVersion = this.LatestVersion;
            context.Mode = this.Mode;
            context.PlanArn = this.PlanArn;
            #if MODULAR
            if (this.PlanArn == null && ParameterWasBound(nameof(this.PlanArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PlanArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetRegion = this.TargetRegion;
            #if MODULAR
            if (this.TargetRegion == null && ParameterWasBound(nameof(this.TargetRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCRegionswitch.Model.StartPlanExecutionRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            if (cmdletContext.LatestVersion != null)
            {
                request.LatestVersion = cmdletContext.LatestVersion;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.PlanArn != null)
            {
                request.PlanArn = cmdletContext.PlanArn;
            }
            if (cmdletContext.TargetRegion != null)
            {
                request.TargetRegion = cmdletContext.TargetRegion;
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
        
        private Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse CallAWSServiceOperation(IAmazonARCRegionswitch client, Amazon.ARCRegionswitch.Model.StartPlanExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "ARC - Region switch", "StartPlanExecution");
            try
            {
                #if DESKTOP
                return client.StartPlanExecution(request);
                #elif CORECLR
                return client.StartPlanExecutionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ARCRegionswitch.ExecutionAction Action { get; set; }
            public System.String Comment { get; set; }
            public System.String LatestVersion { get; set; }
            public Amazon.ARCRegionswitch.ExecutionMode Mode { get; set; }
            public System.String PlanArn { get; set; }
            public System.String TargetRegion { get; set; }
            public System.Func<Amazon.ARCRegionswitch.Model.StartPlanExecutionResponse, StartARCPlanExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
