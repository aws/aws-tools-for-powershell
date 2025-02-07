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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Deregisters an Amazon ECS container instance from the specified cluster. This instance
    /// is no longer available to run tasks.
    /// 
    ///  
    /// <para>
    /// If you intend to use the container instance for some other purpose after deregistration,
    /// we recommend that you stop all of the tasks running on the container instance before
    /// deregistration. That prevents any orphaned tasks from consuming resources.
    /// </para><para>
    /// Deregistering a container instance removes the instance from a cluster, but it doesn't
    /// terminate the EC2 instance. If you are finished using the instance, be sure to terminate
    /// it in the Amazon EC2 console to stop billing.
    /// </para><note><para>
    /// If you terminate a running container instance, Amazon ECS automatically deregisters
    /// the instance from your cluster (stopped container instances or instances with disconnected
    /// agents aren't automatically deregistered when terminated).
    /// </para></note>
    /// </summary>
    [Cmdlet("Unregister", "ECSContainerInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.ContainerInstance")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DeregisterContainerInstance API operation.", Operation = new[] {"DeregisterContainerInstance"}, SelectReturnType = typeof(Amazon.ECS.Model.DeregisterContainerInstanceResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.ContainerInstance or Amazon.ECS.Model.DeregisterContainerInstanceResponse",
        "This cmdlet returns an Amazon.ECS.Model.ContainerInstance object.",
        "The service call response (type Amazon.ECS.Model.DeregisterContainerInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UnregisterECSContainerInstanceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the container
        /// instance to deregister. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ContainerInstance
        /// <summary>
        /// <para>
        /// <para>The container instance ID or full ARN of the container instance to deregister. For
        /// more information about the ARN format, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-account-settings.html#ecs-resource-ids">Amazon
        /// Resource Name (ARN)</a> in the <i>Amazon ECS Developer Guide</i>.</para>
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
        public System.String ContainerInstance { get; set; }
        #endregion
        
        #region Parameter ForceDeregistration
        /// <summary>
        /// <para>
        /// <para>Forces the container instance to be deregistered. If you have tasks running on the
        /// container instance when you deregister it with the <c>force</c> option, these tasks
        /// remain running until you terminate the instance or the tasks stop through some other
        /// means, but they're orphaned (no longer monitored or accounted for by Amazon ECS).
        /// If an orphaned task on your container instance is part of an Amazon ECS service, then
        /// the service scheduler starts another copy of that task, on a different container instance
        /// if possible. </para><para>Any containers in orphaned service tasks that are registered with a Classic Load Balancer
        /// or an Application Load Balancer target group are deregistered. They begin connection
        /// draining according to the settings on the load balancer or target group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceDeregistration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DeregisterContainerInstanceResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DeregisterContainerInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerInstance";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cluster), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-ECSContainerInstance (DeregisterContainerInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DeregisterContainerInstanceResponse, UnregisterECSContainerInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cluster = this.Cluster;
            context.ContainerInstance = this.ContainerInstance;
            #if MODULAR
            if (this.ContainerInstance == null && ParameterWasBound(nameof(this.ContainerInstance)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerInstance which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ForceDeregistration = this.ForceDeregistration;
            
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
            var request = new Amazon.ECS.Model.DeregisterContainerInstanceRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ContainerInstance != null)
            {
                request.ContainerInstance = cmdletContext.ContainerInstance;
            }
            if (cmdletContext.ForceDeregistration != null)
            {
                request.Force = cmdletContext.ForceDeregistration.Value;
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
        
        private Amazon.ECS.Model.DeregisterContainerInstanceResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DeregisterContainerInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DeregisterContainerInstance");
            try
            {
                #if DESKTOP
                return client.DeregisterContainerInstance(request);
                #elif CORECLR
                return client.DeregisterContainerInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String Cluster { get; set; }
            public System.String ContainerInstance { get; set; }
            public System.Boolean? ForceDeregistration { get; set; }
            public System.Func<Amazon.ECS.Model.DeregisterContainerInstanceResponse, UnregisterECSContainerInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerInstance;
        }
        
    }
}
