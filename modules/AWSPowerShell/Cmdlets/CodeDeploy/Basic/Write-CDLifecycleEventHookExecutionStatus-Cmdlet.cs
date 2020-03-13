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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Sets the result of a Lambda validation function. The function validates lifecycle
    /// hooks during a deployment that uses the AWS Lambda or Amazon ECS compute platform.
    /// For AWS Lambda deployments, the available lifecycle hooks are <code>BeforeAllowTraffic</code>
    /// and <code>AfterAllowTraffic</code>. For Amazon ECS deployments, the available lifecycle
    /// hooks are <code>BeforeInstall</code>, <code>AfterInstall</code>, <code>AfterAllowTestTraffic</code>,
    /// <code>BeforeAllowTraffic</code>, and <code>AfterAllowTraffic</code>. Lambda validation
    /// functions return <code>Succeeded</code> or <code>Failed</code>. For more information,
    /// see <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/reference-appspec-file-structure-hooks.html#appspec-hooks-lambda">AppSpec
    /// 'hooks' Section for an AWS Lambda Deployment </a> and <a href="https://docs.aws.amazon.com/codedeploy/latest/userguide/reference-appspec-file-structure-hooks.html#appspec-hooks-ecs">AppSpec
    /// 'hooks' Section for an Amazon ECS Deployment</a>.
    /// </summary>
    [Cmdlet("Write", "CDLifecycleEventHookExecutionStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CodeDeploy PutLifecycleEventHookExecutionStatus API operation.", Operation = new[] {"PutLifecycleEventHookExecutionStatus"}, SelectReturnType = typeof(Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse))]
    [AWSCmdletOutput("System.String or Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCDLifecycleEventHookExecutionStatusCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
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
        /// specified in the <code>hooks</code> section of the AppSpec file. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LifecycleEventHookExecutionId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The result of a Lambda function that validates a deployment lifecycle event (<code>Succeeded</code>
        /// or <code>Failed</code>).</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LifecycleEventHookExecutionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LifecycleEventHookExecutionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LifecycleEventHookExecutionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LifecycleEventHookExecutionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CDLifecycleEventHookExecutionStatus (PutLifecycleEventHookExecutionStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse, WriteCDLifecycleEventHookExecutionStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LifecycleEventHookExecutionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.PutLifecycleEventHookExecutionStatus(request);
                #elif CORECLR
                return client.PutLifecycleEventHookExecutionStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String DeploymentId { get; set; }
            public System.String LifecycleEventHookExecutionId { get; set; }
            public Amazon.CodeDeploy.LifecycleEventStatus Status { get; set; }
            public System.Func<Amazon.CodeDeploy.Model.PutLifecycleEventHookExecutionStatusResponse, WriteCDLifecycleEventHookExecutionStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LifecycleEventHookExecutionId;
        }
        
    }
}
