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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Modifies the status of an Amazon ECS container instance.
    /// 
    ///  
    /// <para>
    /// Once a container instance has reached an <c>ACTIVE</c> state, you can change the status
    /// of a container instance to <c>DRAINING</c> to manually remove an instance from a cluster,
    /// for example to perform system updates, update the Docker daemon, or scale down the
    /// cluster size.
    /// </para><important><para>
    /// A container instance can't be changed to <c>DRAINING</c> until it has reached an <c>ACTIVE</c>
    /// status. If the instance is in any other status, an error will be received.
    /// </para></important><para>
    /// When you set a container instance to <c>DRAINING</c>, Amazon ECS prevents new tasks
    /// from being scheduled for placement on the container instance and replacement service
    /// tasks are started on other container instances in the cluster if the resources are
    /// available. Service tasks on the container instance that are in the <c>PENDING</c>
    /// state are stopped immediately.
    /// </para><para>
    /// Service tasks on the container instance that are in the <c>RUNNING</c> state are stopped
    /// and replaced according to the service's deployment configuration parameters, <c>minimumHealthyPercent</c>
    /// and <c>maximumPercent</c>. You can change the deployment configuration of your service
    /// using <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_UpdateService.html">UpdateService</a>.
    /// </para><ul><li><para>
    /// If <c>minimumHealthyPercent</c> is below 100%, the scheduler can ignore <c>desiredCount</c>
    /// temporarily during task replacement. For example, <c>desiredCount</c> is four tasks,
    /// a minimum of 50% allows the scheduler to stop two existing tasks before starting two
    /// new tasks. If the minimum is 100%, the service scheduler can't remove existing tasks
    /// until the replacement tasks are considered healthy. Tasks for services that do not
    /// use a load balancer are considered healthy if they're in the <c>RUNNING</c> state.
    /// Tasks for services that use a load balancer are considered healthy if they're in the
    /// <c>RUNNING</c> state and are reported as healthy by the load balancer.
    /// </para></li><li><para>
    /// The <c>maximumPercent</c> parameter represents an upper limit on the number of running
    /// tasks during task replacement. You can use this to define the replacement batch size.
    /// For example, if <c>desiredCount</c> is four tasks, a maximum of 200% starts four new
    /// tasks before stopping the four tasks to be drained, provided that the cluster resources
    /// required to do this are available. If the maximum is 100%, then replacement tasks
    /// can't start until the draining tasks have stopped.
    /// </para></li></ul><para>
    /// Any <c>PENDING</c> or <c>RUNNING</c> tasks that do not belong to a service aren't
    /// affected. You must wait for them to finish or stop them manually.
    /// </para><para>
    /// A container instance has completed draining when it has no more <c>RUNNING</c> tasks.
    /// You can verify this using <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_ListTasks.html">ListTasks</a>.
    /// </para><para>
    /// When a container instance has been drained, you can set a container instance to <c>ACTIVE</c>
    /// status and once it has reached that status the Amazon ECS scheduler can begin scheduling
    /// tasks on the instance again.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ECSContainerInstancesState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.UpdateContainerInstancesStateResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateContainerInstancesState API operation.", Operation = new[] {"UpdateContainerInstancesState"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateContainerInstancesStateResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.UpdateContainerInstancesStateResponse",
        "This cmdlet returns an Amazon.ECS.Model.UpdateContainerInstancesStateResponse object containing multiple properties."
    )]
    public partial class UpdateECSContainerInstancesStateCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the container
        /// instance to update. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ContainerInstance
        /// <summary>
        /// <para>
        /// <para>A list of up to 10 container instance IDs or full ARN entries.</para>
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
        [Alias("ContainerInstances")]
        public System.String[] ContainerInstance { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The container instance state to update the container instance with. The only valid
        /// values for this action are <c>ACTIVE</c> and <c>DRAINING</c>. A container instance
        /// can only be updated to <c>DRAINING</c> status once it has reached an <c>ACTIVE</c>
        /// state. If a container instance is in <c>REGISTERING</c>, <c>DEREGISTERING</c>, or
        /// <c>REGISTRATION_FAILED</c> state you can describe the container instance but can't
        /// update the container instance state.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ECS.ContainerInstanceStatus")]
        public Amazon.ECS.ContainerInstanceStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateContainerInstancesStateResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateContainerInstancesStateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Cluster parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Cluster' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Cluster' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cluster), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSContainerInstancesState (UpdateContainerInstancesState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateContainerInstancesStateResponse, UpdateECSContainerInstancesStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Cluster;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Cluster = this.Cluster;
            if (this.ContainerInstance != null)
            {
                context.ContainerInstance = new List<System.String>(this.ContainerInstance);
            }
            #if MODULAR
            if (this.ContainerInstance == null && ParameterWasBound(nameof(this.ContainerInstance)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerInstance which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            #if MODULAR
            if (this.Status == null && ParameterWasBound(nameof(this.Status)))
            {
                WriteWarning("You are passing $null as a value for parameter Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.UpdateContainerInstancesStateRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ContainerInstance != null)
            {
                request.ContainerInstances = cmdletContext.ContainerInstance;
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
        
        private Amazon.ECS.Model.UpdateContainerInstancesStateResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateContainerInstancesStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateContainerInstancesState");
            try
            {
                #if DESKTOP
                return client.UpdateContainerInstancesState(request);
                #elif CORECLR
                return client.UpdateContainerInstancesStateAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContainerInstance { get; set; }
            public Amazon.ECS.ContainerInstanceStatus Status { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateContainerInstancesStateResponse, UpdateECSContainerInstancesStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
