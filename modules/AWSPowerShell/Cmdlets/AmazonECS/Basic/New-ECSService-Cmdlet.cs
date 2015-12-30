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
    /// You can optionally specify a deployment configuration for your service. During a deployment
    /// (which is triggered by changing the task definition of a service with an <a>UpdateService</a>
    /// operation), the service scheduler uses the <code>minimumHealthyPercent</code> and
    /// <code>maximumPercent</code> parameters to determine the deployment strategy.
    /// </para><para>
    /// If the <code>minimumHealthyPercent</code> is below 100%, the scheduler can ignore
    /// the <code>desiredCount</code> temporarily during a deployment. For example, if your
    /// service has a <code>desiredCount</code> of four tasks, a <code>minimumHealthyPercent</code>
    /// of 50% allows the scheduler to stop two existing tasks before starting two new tasks.
    /// Tasks for services that <i>do not</i> use a load balancer are considered healthy if
    /// they are in the <code>RUNNING</code> state; tasks for services that <i>do</i> use
    /// a load balancer are considered healthy if they are in the <code>RUNNING</code> state
    /// and the container instance it is hosted on is reported as healthy by the load balancer.
    /// The default value for <code>minimumHealthyPercent</code> is 50% in the console and
    /// 100% for the AWS CLI, the AWS SDKs, and the APIs.
    /// </para><para>
    /// The <code>maximumPercent</code> parameter represents an upper limit on the number
    /// of running tasks during a deployment, which enables you to define the deployment batch
    /// size. For example, if your service has a <code>desiredCount</code> of four tasks,
    /// a <code>maximumPercent</code> value of 200% starts four new tasks before stopping
    /// the four older tasks (provided that the cluster resources required to do this are
    /// available). The default value for <code>maximumPercent</code> is 200%.
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
    [Cmdlet("New", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Invokes the CreateService operation against Amazon EC2 Container Service.", Operation = new[] {"CreateService"})]
    [AWSCmdletOutput("Amazon.ECS.Model.Service",
        "This cmdlet returns a Service object.",
        "The service call response (type Amazon.ECS.Model.CreateServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure the idempotency of the request.
        /// Up to 32 ASCII characters are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster on which to run your
        /// service. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter DesiredCount
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the specified task definition to place and keep running
        /// on your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DesiredCount { get; set; }
        #endregion
        
        #region Parameter LoadBalancer
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
        #endregion
        
        #region Parameter DeploymentConfiguration_MaximumPercent
        /// <summary>
        /// <para>
        /// <para>The upper limit (as a percentage of the service's <code>desiredCount</code>) of the
        /// number of running tasks that can be running in a service during a deployment. The
        /// maximum number of tasks during a deployment is the <code>desiredCount</code> multiplied
        /// by the <code>maximumPercent</code>/100, rounded down to the nearest integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DeploymentConfiguration_MaximumPercent { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MinimumHealthyPercent
        /// <summary>
        /// <para>
        /// <para>The lower limit (as a percentage of the service's <code>desiredCount</code>) of the
        /// number of running tasks that must remain running and healthy in a service during a
        /// deployment. The minimum healthy tasks during a deployment is the <code>desiredCount</code>
        /// multiplied by the <code>minimumHealthyPercent</code>/100, rounded up to the nearest
        /// integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DeploymentConfiguration_MinimumHealthyPercent { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the IAM role that allows your Amazon
        /// ECS container agent to make calls to your load balancer on your behalf. This parameter
        /// is only required if you are using a load balancer with your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter ServiceName
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
        #endregion
        
        #region Parameter TaskDefinition
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
            if (ParameterWasBound("DeploymentConfiguration_MaximumPercent"))
                context.DeploymentConfiguration_MaximumPercent = this.DeploymentConfiguration_MaximumPercent;
            if (ParameterWasBound("DeploymentConfiguration_MinimumHealthyPercent"))
                context.DeploymentConfiguration_MinimumHealthyPercent = this.DeploymentConfiguration_MinimumHealthyPercent;
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
            
             // populate DeploymentConfiguration
            bool requestDeploymentConfigurationIsNull = true;
            request.DeploymentConfiguration = new Amazon.ECS.Model.DeploymentConfiguration();
            System.Int32? requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent = null;
            if (cmdletContext.DeploymentConfiguration_MaximumPercent != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent = cmdletContext.DeploymentConfiguration_MaximumPercent.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent != null)
            {
                request.DeploymentConfiguration.MaximumPercent = requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent.Value;
                requestDeploymentConfigurationIsNull = false;
            }
            System.Int32? requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent = null;
            if (cmdletContext.DeploymentConfiguration_MinimumHealthyPercent != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent = cmdletContext.DeploymentConfiguration_MinimumHealthyPercent.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent != null)
            {
                request.DeploymentConfiguration.MinimumHealthyPercent = requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent.Value;
                requestDeploymentConfigurationIsNull = false;
            }
             // determine if request.DeploymentConfiguration should be set to null
            if (requestDeploymentConfigurationIsNull)
            {
                request.DeploymentConfiguration = null;
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
            public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public List<Amazon.ECS.Model.LoadBalancer> LoadBalancers { get; set; }
            public System.String Role { get; set; }
            public System.String ServiceName { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
