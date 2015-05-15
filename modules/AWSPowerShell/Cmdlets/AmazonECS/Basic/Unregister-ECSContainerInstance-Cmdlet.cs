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
    /// will no longer be available to run tasks.
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
        /// instance you want to deregister. If you do not specify a cluster, the default cluster
        /// is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Cluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The container instance UUID or full Amazon Resource Name (ARN) of the container instance
        /// you want to deregister. The ARN contains the <code>arn:aws:ecs</code> namespace, followed
        /// by the region of the container instance, the AWS account ID of the container instance
        /// owner, the <code>container-instance</code> namespace, and then the container instance
        /// UUID. For example, arn:aws:ecs:<i>region</i>:<i>aws_account_id</i>:container-instance/<i>container_instance_UUID</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ContainerInstance { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Force the deregistration of the container instance. You can use the <code>force</code>
        /// parameter if you have several tasks running on a container instance and you don't
        /// want to run <code>StopTask</code> for each task before deregistering the container
        /// instance.</para>
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
