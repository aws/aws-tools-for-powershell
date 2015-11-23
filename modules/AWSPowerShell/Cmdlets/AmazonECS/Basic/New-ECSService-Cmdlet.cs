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
    /// Runs and maintains a desired number of tasks from a specified task definition. If
    /// the number of tasks running in a service drops below <code>desiredCount</code>, Amazon
    /// ECS spawns another instantiation of the task in the specified cluster. To update an
    /// existing service, see <a>UpdateService</a>.
    /// 
    ///  
    /// <para>
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
    [Cmdlet("New", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Invokes the CreateService operation against Amazon EC2 Container Service.", Operation = new[] {"CreateService"})]
    [AWSCmdletOutput("Amazon.ECS.Model.Service",
        "This cmdlet returns a Service object.",
        "The service call response (type Amazon.ECS.Model.CreateServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// Up to 32 ASCII characters are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster on which to run your
        /// service. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the specified task definition to place and keep running
        /// on your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DesiredCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of load balancer objects, containing the load balancer name, the container
        /// name (as it appears in a container definition), and the container port to access from
        /// the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LoadBalancers")]
        public Amazon.ECS.Model.LoadBalancer[] LoadBalancer { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the IAM role that allows your Amazon
        /// ECS container agent to make calls to your load balancer on your behalf. This parameter
        /// is only required if you are using a load balancer with your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of your service. Up to 255 letters (uppercase and lowercase), numbers, hyphens,
        /// and underscores are allowed. Service names must be unique within a cluster, but you
        /// can have similarly named services in multiple clusters within a region or across multiple
        /// regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> and <code>revision</code> (<code>family:revision</code>) or
        /// full Amazon Resource Name (ARN) of the task definition to run in your service. If
        /// a <code>revision</code> is not specified, the latest <code>ACTIVE</code> revision
        /// is used.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServiceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSService (CreateService)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientToken = this.ClientToken;
            context.Cluster = this.Cluster;
            if (ParameterWasBound("DesiredCount"))
                context.DesiredCount = this.DesiredCount;
            if (this.LoadBalancer != null)
            {
                context.LoadBalancers = new List<Amazon.ECS.Model.LoadBalancer>(this.LoadBalancer);
            }
            context.Role = this.Role;
            context.ServiceName = this.ServiceName;
            context.TaskDefinition = this.TaskDefinition;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ECS.Model.CreateServiceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.DesiredCount != null)
            {
                request.DesiredCount = cmdletContext.DesiredCount.Value;
            }
            if (cmdletContext.LoadBalancers != null)
            {
                request.LoadBalancers = cmdletContext.LoadBalancers;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
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
                var response = client.CreateService(request);
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
            public System.String ClientToken { get; set; }
            public System.String Cluster { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public List<Amazon.ECS.Model.LoadBalancer> LoadBalancers { get; set; }
            public System.String Role { get; set; }
            public System.String ServiceName { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
