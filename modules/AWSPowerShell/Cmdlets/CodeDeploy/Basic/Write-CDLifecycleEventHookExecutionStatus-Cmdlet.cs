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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Sets the result of a Lambda validation function. The function validates lifecycle
    /// hooks during a deployment that uses the Lambda or Amazon ECS compute platform. For
    /// Lambda deployments, the available lifecycle hooks are <c>BeforeAllowTraffic</c> and
    /// <c>AfterAllowTraffic</c>. For Amazon ECS deployments, the available lifecycle hooks
    /// are <c>BeforeInstall</c>, <c>AfterInstall</c>, <c>AfterAllowTestTraffic</c>, <c>BeforeAllowTraffic</c>,
    /// and <c>AfterAllowTraffic</c>. Lambda validation functions return <c>Succeeded</c>
    /// or <c>Failed</c>. For more information, see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/reference-appspec-file-structure-hooks.html#appspec-hooks-lambda">AppSpec
    /// 'hooks' Section for an Lambda Deployment </a> and <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/reference-appspec-file-structure-hooks.html#appspec-hooks-ecs">AppSpec
    /// 'hooks' Section for an Amazon ECS Deployment</a>.
    /// </summary>
    [Cmdlet("Write", "CDLifecycleEventHookExecutionStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeDeploy PutLifecycleEventHookExecutionStatus API operation.", Operation = new[] {"PutLifecycleEventHookExecutionStatus"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCDLifecycleEventHookExecutionStatusCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para> The unique ID of a deployment. Pass this ID to a Lambda function that validates a
        /// deployment lifecycle event. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter LifecycleEventHookExecutionId
        /// <summary>
        /// <para>
        /// <para> The execution ID of a deployment's lifecycle hook. A deployment lifecycle hook is
        /// specified in the <c>hooks</c> section of the AppSpec file. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LifecycleEventHookExecutionId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The result of a Lambda function that validates a deployment lifecycle event. The values
        /// listed in <b>Valid Values</b> are valid for lifecycle statuses in general; however,
        /// only <c>Succeeded</c> and <c>Failed</c> can be passed successfully in your API call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeDeploy.LifecycleEventStatus")]
        public Amazon.CodeDeploy.LifecycleEventStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LifecycleEventHookExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse).
        /// Specifying the name of a property of type Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LifecycleEventHookExecutionId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LifecycleEventHookExecutionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CDLifecycleEventHookExecutionStatus (PutLifecycleEventHookExecutionStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse, WriteCDLifecycleEventHookExecutionStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentId = this.DeploymentId;
            context.LifecycleEventHookExecutionId = this.LifecycleEventHookExecutionId;
            context.Status = this.Status;
            
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
            var request = new Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.LifecycleEventHookExecutionId != null)
            {
                request.LifecycleEventHookExecutionId = cmdletContext.LifecycleEventHookExecutionId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "PutLifecycleEventHookExecutionStatus");
            try
            {
                return client.PutLifecycleEventHookExecutionStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeploymentId { get; set; }
            public System.String LifecycleEventHookExecutionId { get; set; }
            public Amazon.CodeDeploy.LifecycleEventStatus Status { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse, WriteCDLifecycleEventHookExecutionStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LifecycleEventHookExecutionId;
        }
        
    }
}
