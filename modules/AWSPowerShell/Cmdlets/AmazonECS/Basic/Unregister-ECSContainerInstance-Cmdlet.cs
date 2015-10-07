/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// you should stop all of the tasks running on the container instance before deregistration
    /// to avoid any orphaned tasks from consuming resources.
    /// </para><para>
    /// Deregistering a container instance removes the instance from a cluster, but it does
    /// not terminate the EC2 instance; if you are finished using the instance, be sure to
    /// terminate it in the Amazon EC2 console to stop billing.
    /// </para><note><para>
    /// When you terminate a container instance, it is automatically deregistered from your
    /// cluster.
    /// </para></note>
    /// </summary>
    [Cmdlet("Unregister", "ECSContainerInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.ContainerInstance")]
    [AWSCmdlet("Invokes the DeregisterContainerInstance operation against Amazon EC2 Container Service.", Operation = new[] {"DeregisterContainerInstance"})]
    [AWSCmdletOutput("Amazon.ECS.Model.ContainerInstance",
        "This cmdlet returns a ContainerInstance object.",
        "The service call response (type DeregisterContainerInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UnregisterECSContainerInstanceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that hosts the container
        /// instance to deregister. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Cluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The container instance ID or full Amazon Resource Name (ARN) of the container instance
        /// to deregister. The ARN contains the <code>arn:aws:ecs</code> namespace, followed by
        /// the region of the container instance, the AWS account ID of the container instance
        /// owner, the <code>container-instance</code> namespace, and then the container instance
        /// ID. For example, arn:aws:ecs:<i>region</i>:<i>aws_account_id</i>:container-instance/<i>container_instance_ID</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ContainerInstance { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Forces the deregistration of the container instance. If you have tasks running on
        /// the container instance when you deregister it with the <code>force</code> option,
        /// these tasks remain running and they continue to pass Elastic Load Balancing load balancer
        /// health checks until you terminate the instance or the tasks stop through some other
        /// means, but they are orphaned (no longer monitored or accounted for by Amazon ECS).
        /// If an orphaned task on your container instance is part of an Amazon ECS service, then
        /// the service scheduler starts another copy of that task, on a different container instance
        /// if possible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ForceDeregistration { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Cluster", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-ECSContainerInstance (DeregisterContainerInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Cluster = this.Cluster;
            context.ContainerInstance = this.ContainerInstance;
            if (ParameterWasBound("ForceDeregistration"))
                context.ForceDeregistration = this.ForceDeregistration;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DeregisterContainerInstanceRequest();
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DeregisterContainerInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ContainerInstance;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Cluster { get; set; }
            public String ContainerInstance { get; set; }
            public Boolean? ForceDeregistration { get; set; }
        }
        
    }
}
