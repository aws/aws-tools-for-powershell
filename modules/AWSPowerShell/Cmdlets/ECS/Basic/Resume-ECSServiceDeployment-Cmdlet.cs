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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Continues or rolls back an Amazon ECS service deployment that is paused at a lifecycle
    /// hook.
    /// 
    ///  
    /// <para>
    /// When a service deployment reaches a lifecycle stage that has a <c>PAUSE</c> hook configured,
    /// the deployment pauses and waits for an explicit action. Use this API to either continue
    /// the deployment to the next stage or roll back to the previous service revision.
    /// </para><para>
    /// To find the <c>hookId</c> of the paused hook, call <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_DescribeServiceDeployments.html">DescribeServiceDeployments</a>
    /// and inspect the <c>lifecycleHookDetails</c> field.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/continue-service-deployment.html">Continuing
    /// Amazon ECS service deployments</a> in the <i>Amazon Elastic Container Service Developer
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Resume", "ECSServiceDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service ContinueServiceDeployment API operation.", Operation = new[] {"ContinueServiceDeployment"}, SelectReturnType = typeof(Amazon.ECS.Model.ContinueServiceDeploymentResponse))]
    [AWSCmdletOutput("System.String or Amazon.ECS.Model.ContinueServiceDeploymentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ECS.Model.ContinueServiceDeploymentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ResumeECSServiceDeploymentCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Action
        /// <summary>
        /// <para>
        /// <para>The action to take on the paused lifecycle hook. Valid values are:</para><ul><li><para><c>CONTINUE</c> - Proceeds the deployment to the next lifecycle stage.</para></li><li><para><c>ROLLBACK</c> - Rolls back the deployment to the previous service revision.</para></li></ul><para>If no value is specified, the default action is <c>CONTINUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.DeploymentLifecycleHookAction")]
        public Amazon.ECS.DeploymentLifecycleHookAction Action { get; set; }
        #endregion
        
        #region Parameter HookId
        /// <summary>
        /// <para>
        /// <para>The ID of the paused lifecycle hook to act on. You can find the <c>hookId</c> by calling
        /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_DescribeServiceDeployments.html">DescribeServiceDeployments</a>
        /// and inspecting the <c>lifecycleHookDetails</c> field of the service deployment.</para>
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
        public System.String HookId { get; set; }
        #endregion
        
        #region Parameter ServiceDeploymentArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the service deployment to continue or roll back.</para>
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
        public System.String ServiceDeploymentArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServiceDeploymentArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.ContinueServiceDeploymentResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.ContinueServiceDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServiceDeploymentArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceDeploymentArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Resume-ECSServiceDeployment (ContinueServiceDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.ContinueServiceDeploymentResponse, ResumeECSServiceDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Action = this.Action;
            context.HookId = this.HookId;
            #if MODULAR
            if (this.HookId == null && ParameterWasBound(nameof(this.HookId)))
            {
                WriteWarning("You are passing $null as a value for parameter HookId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceDeploymentArn = this.ServiceDeploymentArn;
            #if MODULAR
            if (this.ServiceDeploymentArn == null && ParameterWasBound(nameof(this.ServiceDeploymentArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceDeploymentArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.ContinueServiceDeploymentRequest();
            
            if (cmdletContext.Action != null)
            {
                request.Action = cmdletContext.Action;
            }
            if (cmdletContext.HookId != null)
            {
                request.HookId = cmdletContext.HookId;
            }
            if (cmdletContext.ServiceDeploymentArn != null)
            {
                request.ServiceDeploymentArn = cmdletContext.ServiceDeploymentArn;
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
        
        private Amazon.ECS.Model.ContinueServiceDeploymentResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.ContinueServiceDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "ContinueServiceDeployment");
            try
            {
                return client.ContinueServiceDeploymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ECS.DeploymentLifecycleHookAction Action { get; set; }
            public System.String HookId { get; set; }
            public System.String ServiceDeploymentArn { get; set; }
            public System.Func<Amazon.ECS.Model.ContinueServiceDeploymentResponse, ResumeECSServiceDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServiceDeploymentArn;
        }
        
    }
}
