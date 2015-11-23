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
    /// Modify the desired count or task definition used in a service.
    /// 
    ///  
    /// <para>
    /// You can add to or subtract from the number of instantiations of a task definition
    /// in a service by specifying the cluster that the service is running in and a new <code>desiredCount</code>
    /// parameter.
    /// </para><para>
    /// You can use <code>UpdateService</code> to modify your task definition and deploy a
    /// new version of your service, one task at a time. If you modify the task definition
    /// with <code>UpdateService</code>, Amazon ECS spawns a task with the new version of
    /// the task definition and then stops an old task after the new version is running. Because
    /// <code>UpdateService</code> starts a new version of the task before stopping an old
    /// version, your cluster must have capacity to support one more instantiation of the
    /// task when <code>UpdateService</code> is run. If your cluster cannot support another
    /// instantiation of the task used in your service, you can reduce the desired count of
    /// your service by one before modifying the task definition.
    /// </para><para>
    /// When <a>UpdateService</a> replaces a task during an update, the equivalent of <code>docker
    /// stop</code> is issued to the containers running in the task. This results in a <code>SIGTERM</code>
    /// and a 30-second timeout, after which <code>SIGKILL</code> is sent and the containers
    /// are forcibly stopped. If the container handles the <code>SIGTERM</code> gracefully
    /// and exits within 30 seconds from receiving it, no <code>SIGKILL</code> is sent.
    /// </para><para>
    /// When the service scheduler launches new tasks, it attempts to balance them across
    /// the Availability Zones in your cluster with the following logic:
    /// </para><ul><li><para>
    /// Determine which of the container instances in your cluster can support your service's
    /// task definition (for example, they have the required CPU, memory, ports, and container
    /// instance attributes).
    /// </para></li><li><para>
    /// Sort the valid container instances by the fewest number of running tasks for this
    /// service in the same Availability Zone as the instance. For example, if zone A has
    /// one running service task and zones B and C each have zero, valid container instances
    /// in either zone B or C are considered optimal for placement.
    /// </para></li><li><para>
    /// Place the new service task on a valid container instance in an optimal Availability
    /// Zone (based on the previous steps), favoring container instances with the fewest number
    /// of running tasks for this service.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Invokes the UpdateService operation against Amazon EC2 Container Service.", Operation = new[] {"UpdateService"})]
    [AWSCmdletOutput("Amazon.ECS.Model.Service",
        "This cmdlet returns a Service object.",
        "The service call response (type Amazon.ECS.Model.UpdateServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that your service
        /// is running on. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the task to place and keep running in your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DesiredCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the service to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Service { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> and <code>revision</code> (<code>family:revision</code>) or
        /// full Amazon Resource Name (ARN) of the task definition to run in your service. If
        /// a <code>revision</code> is not specified, the latest <code>ACTIVE</code> revision
        /// is used. If you modify the task definition with <code>UpdateService</code>, Amazon
        /// ECS spawns a task with the new version of the task definition and then stops an old
        /// task after the new version is running.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TaskDefinition { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Service", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSService (UpdateService)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Cluster = this.Cluster;
            if (ParameterWasBound("DesiredCount"))
                context.DesiredCount = this.DesiredCount;
            context.Service = this.Service;
            context.TaskDefinition = this.TaskDefinition;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ECS.Model.UpdateServiceRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.DesiredCount != null)
            {
                request.DesiredCount = cmdletContext.DesiredCount.Value;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            if (cmdletContext.TaskDefinition != null)
            {
                request.TaskDefinition = cmdletContext.TaskDefinition;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateService(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Service;
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
            public System.String Cluster { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public System.String Service { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
