/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// You can change the status of a container instance to <code>DRAINING</code> to manually
    /// remove an instance from a cluster, for example to perform system updates, update the
    /// Docker daemon, or scale down the cluster size. 
    /// </para><para>
    /// When you set a container instance to <code>DRAINING</code>, Amazon ECS prevents new
    /// tasks from being scheduled for placement on the container instance and replacement
    /// service tasks are started on other container instances in the cluster if the resources
    /// are available. Service tasks on the container instance that are in the <code>PENDING</code>
    /// state are stopped immediately.
    /// </para><para>
    /// Service tasks on the container instance that are in the <code>RUNNING</code> state
    /// are stopped and replaced according to the service's deployment configuration parameters,
    /// <code>minimumHealthyPercent</code> and <code>maximumPercent</code>. You can change
    /// the deployment configuration of your service using <a>UpdateService</a>.
    /// </para><ul><li><para>
    /// If <code>minimumHealthyPercent</code> is below 100%, the scheduler can ignore <code>desiredCount</code>
    /// temporarily during task replacement. For example, <code>desiredCount</code> is four
    /// tasks, a minimum of 50% allows the scheduler to stop two existing tasks before starting
    /// two new tasks. If the minimum is 100%, the service scheduler can't remove existing
    /// tasks until the replacement tasks are considered healthy. Tasks for services that
    /// do not use a load balancer are considered healthy if they are in the <code>RUNNING</code>
    /// state. Tasks for services that use a load balancer are considered healthy if they
    /// are in the <code>RUNNING</code> state and the container instance they are hosted on
    /// is reported as healthy by the load balancer.
    /// </para></li><li><para>
    /// The <code>maximumPercent</code> parameter represents an upper limit on the number
    /// of running tasks during task replacement, which enables you to define the replacement
    /// batch size. For example, if <code>desiredCount</code> of four tasks, a maximum of
    /// 200% starts four new tasks before stopping the four tasks to be drained (provided
    /// that the cluster resources required to do this are available). If the maximum is 100%,
    /// then replacement tasks can't start until the draining tasks have stopped.
    /// </para></li></ul><para>
    /// Any <code>PENDING</code> or <code>RUNNING</code> tasks that do not belong to a service
    /// are not affected; you must wait for them to finish or stop them manually.
    /// </para><para>
    /// A container instance has completed draining when it has no more <code>RUNNING</code>
    /// tasks. You can verify this using <a>ListTasks</a>.
    /// </para><para>
    /// When you set a container instance to <code>ACTIVE</code>, the Amazon ECS scheduler
    /// can begin scheduling tasks on the instance again.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ECSContainerInstancesState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.UpdateContainerInstancesStateResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateContainerInstancesState API operation.", Operation = new[] {"UpdateContainerInstancesState"})]
    [AWSCmdletOutput("Amazon.ECS.Model.UpdateContainerInstancesStateResponse",
        "This cmdlet returns a Amazon.ECS.Model.UpdateContainerInstancesStateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateECSContainerInstancesStateCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the container
        /// instance to update. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ContainerInstance
        /// <summary>
        /// <para>
        /// <para>A list of container instance IDs or full ARN entries.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerInstances")]
        public System.String[] ContainerInstance { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The container instance state with which to update the container instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.ContainerInstanceStatus")]
        public Amazon.ECS.ContainerInstanceStatus Status { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Cluster", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSContainerInstancesState (UpdateContainerInstancesState)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Cluster = this.Cluster;
            if (this.ContainerInstance != null)
            {
                context.ContainerInstances = new List<System.String>(this.ContainerInstance);
            }
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
            var request = new Amazon.ECS.Model.UpdateContainerInstancesStateRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ContainerInstances != null)
            {
                request.ContainerInstances = cmdletContext.ContainerInstances;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateContainerInstancesStateAsync(request);
                return task.Result;
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
            public List<System.String> ContainerInstances { get; set; }
            public Amazon.ECS.ContainerInstanceStatus Status { get; set; }
        }
        
    }
}
