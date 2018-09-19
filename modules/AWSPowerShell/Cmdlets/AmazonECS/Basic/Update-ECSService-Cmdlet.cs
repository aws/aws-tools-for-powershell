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
    /// Modifies the desired count, deployment configuration, network configuration, or task
    /// definition used in a service.
    /// 
    ///  
    /// <para>
    /// You can add to or subtract from the number of instantiations of a task definition
    /// in a service by specifying the cluster that the service is running in and a new <code>desiredCount</code>
    /// parameter.
    /// </para><para>
    /// If you have updated the Docker image of your application, you can create a new task
    /// definition with that image and deploy it to your service. The service scheduler uses
    /// the minimum healthy percent and maximum percent parameters (in the service's deployment
    /// configuration) to determine the deployment strategy.
    /// </para><note><para>
    /// If your updated Docker image uses the same tag as what is in the existing task definition
    /// for your service (for example, <code>my_image:latest</code>), you do not need to create
    /// a new revision of your task definition. You can update the service using the <code>forceNewDeployment</code>
    /// option. The new tasks launched by the deployment pull the current image/tag combination
    /// from your repository when they start.
    /// </para></note><para>
    /// You can also update the deployment configuration of a service. When a deployment is
    /// triggered by updating the task definition of a service, the service scheduler uses
    /// the deployment configuration parameters, <code>minimumHealthyPercent</code> and <code>maximumPercent</code>,
    /// to determine the deployment strategy.
    /// </para><ul><li><para>
    /// If <code>minimumHealthyPercent</code> is below 100%, the scheduler can ignore <code>desiredCount</code>
    /// temporarily during a deployment. For example, if <code>desiredCount</code> is four
    /// tasks, a minimum of 50% allows the scheduler to stop two existing tasks before starting
    /// two new tasks. Tasks for services that do not use a load balancer are considered healthy
    /// if they are in the <code>RUNNING</code> state. Tasks for services that use a load
    /// balancer are considered healthy if they are in the <code>RUNNING</code> state and
    /// the container instance they are hosted on is reported as healthy by the load balancer.
    /// </para></li><li><para>
    /// The <code>maximumPercent</code> parameter represents an upper limit on the number
    /// of running tasks during a deployment, which enables you to define the deployment batch
    /// size. For example, if <code>desiredCount</code> is four tasks, a maximum of 200% starts
    /// four new tasks before stopping the four older tasks (provided that the cluster resources
    /// required to do this are available).
    /// </para></li></ul><para>
    /// When <a>UpdateService</a> stops a task during a deployment, the equivalent of <code>docker
    /// stop</code> is issued to the containers running in the task. This results in a <code>SIGTERM</code>
    /// and a 30-second timeout, after which <code>SIGKILL</code> is sent and the containers
    /// are forcibly stopped. If the container handles the <code>SIGTERM</code> gracefully
    /// and exits within 30 seconds from receiving it, no <code>SIGKILL</code> is sent.
    /// </para><para>
    /// When the service scheduler launches new tasks, it determines task placement in your
    /// cluster with the following logic:
    /// </para><ul><li><para>
    /// Determine which of the container instances in your cluster can support your service's
    /// task definition (for example, they have the required CPU, memory, ports, and container
    /// instance attributes).
    /// </para></li><li><para>
    /// By default, the service scheduler attempts to balance tasks across Availability Zones
    /// in this manner (although you can choose a different placement strategy):
    /// </para><ul><li><para>
    /// Sort the valid container instances by the fewest number of running tasks for this
    /// service in the same Availability Zone as the instance. For example, if zone A has
    /// one running service task and zones B and C each have zero, valid container instances
    /// in either zone B or C are considered optimal for placement.
    /// </para></li><li><para>
    /// Place the new service task on a valid container instance in an optimal Availability
    /// Zone (based on the previous steps), favoring container instances with the fewest number
    /// of running tasks for this service.
    /// </para></li></ul></li></ul><para>
    /// When the service scheduler stops running tasks, it attempts to maintain balance across
    /// the Availability Zones in your cluster using the following logic: 
    /// </para><ul><li><para>
    /// Sort the container instances by the largest number of running tasks for this service
    /// in the same Availability Zone as the instance. For example, if zone A has one running
    /// service task and zones B and C each have two, container instances in either zone B
    /// or C are considered optimal for termination.
    /// </para></li><li><para>
    /// Stop the task on a container instance in an optimal Availability Zone (based on the
    /// previous steps), favoring container instances with the largest number of running tasks
    /// for this service.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateService API operation.", Operation = new[] {"UpdateService"})]
    [AWSCmdletOutput("Amazon.ECS.Model.Service",
        "This cmdlet returns a Service object.",
        "The service call response (type Amazon.ECS.Model.UpdateServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter AwsvpcConfiguration_AssignPublicIp
        /// <summary>
        /// <para>
        /// <para>Whether the task's elastic network interface receives a public IP address. The default
        /// value is <code>DISABLED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.ECS.AssignPublicIp")]
        public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that your service
        /// is running on. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter DesiredCount
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the task to place and keep running in your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DesiredCount { get; set; }
        #endregion
        
        #region Parameter ForceNewDeployment
        /// <summary>
        /// <para>
        /// <para>Whether to force a new deployment of the service. Deployments are not forced by default.
        /// You can use this option to trigger a new deployment with no service definition changes.
        /// For example, you can update a service's tasks to use a newer Docker image with the
        /// same image/tag combination (<code>my_image:latest</code>) or to roll Fargate tasks
        /// onto a newer platform version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ForceNewDeployment { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that the Amazon ECS service scheduler should ignore
        /// unhealthy Elastic Load Balancing target health checks after a task has first started.
        /// This is only valid if your service is configured to use a load balancer. If your service's
        /// tasks take a while to start and respond to Elastic Load Balancing health checks, you
        /// can specify a health check grace period of up to 1,800 seconds during which the ECS
        /// service scheduler ignores the Elastic Load Balancing health check status. This grace
        /// period can prevent the ECS service scheduler from marking tasks as unhealthy and stopping
        /// them before they have time to come up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckGracePeriodSeconds")]
        public System.Int32 HealthCheckGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MaximumPercent
        /// <summary>
        /// <para>
        /// <para>The upper limit (as a percentage of the service's <code>desiredCount</code>) of the
        /// number of tasks that are allowed in the <code>RUNNING</code> or <code>PENDING</code>
        /// state in a service during a deployment. The maximum number of tasks during a deployment
        /// is the <code>desiredCount</code> multiplied by <code>maximumPercent</code>/100, rounded
        /// down to the nearest integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DeploymentConfiguration_MaximumPercent { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MinimumHealthyPercent
        /// <summary>
        /// <para>
        /// <para>The lower limit (as a percentage of the service's <code>desiredCount</code>) of the
        /// number of running tasks that must remain in the <code>RUNNING</code> state in a service
        /// during a deployment. The minimum number of healthy tasks during a deployment is the
        /// <code>desiredCount</code> multiplied by <code>minimumHealthyPercent</code>/100, rounded
        /// up to the nearest integer value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DeploymentConfiguration_MinimumHealthyPercent { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version that your service should run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the task or service. If you do not specify a security
        /// group, the default security group for the VPC is used. There is a limit of 5 security
        /// groups able to be specified per <code>AwsVpcConfiguration</code>.</para><note><para>All specified security groups must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_SecurityGroups")]
        public System.String[] AwsvpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The name of the service to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets associated with the task or service. There is a limit of 16 subnets able
        /// to be specified per <code>AwsVpcConfiguration</code>.</para><note><para>All specified subnets must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_Subnets")]
        public System.String[] AwsvpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> and <code>revision</code> (<code>family:revision</code>) or
        /// full ARN of the task definition to run in your service. If a <code>revision</code>
        /// is not specified, the latest <code>ACTIVE</code> revision is used. If you modify the
        /// task definition with <code>UpdateService</code>, Amazon ECS spawns a task with the
        /// new version of the task definition and then stops an old task after the new version
        /// is running.</para>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Cluster = this.Cluster;
            if (ParameterWasBound("DeploymentConfiguration_MaximumPercent"))
                context.DeploymentConfiguration_MaximumPercent = this.DeploymentConfiguration_MaximumPercent;
            if (ParameterWasBound("DeploymentConfiguration_MinimumHealthyPercent"))
                context.DeploymentConfiguration_MinimumHealthyPercent = this.DeploymentConfiguration_MinimumHealthyPercent;
            if (ParameterWasBound("DesiredCount"))
                context.DesiredCount = this.DesiredCount;
            if (ParameterWasBound("ForceNewDeployment"))
                context.ForceNewDeployment = this.ForceNewDeployment;
            if (ParameterWasBound("HealthCheckGracePeriodSecond"))
                context.HealthCheckGracePeriodSeconds = this.HealthCheckGracePeriodSecond;
            context.NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.NetworkConfiguration_AwsvpcConfiguration_SecurityGroups = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.NetworkConfiguration_AwsvpcConfiguration_Subnets = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            context.PlatformVersion = this.PlatformVersion;
            context.Service = this.Service;
            context.TaskDefinition = this.TaskDefinition;
            
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
            var request = new Amazon.ECS.Model.UpdateServiceRequest();
            
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
            if (cmdletContext.ForceNewDeployment != null)
            {
                request.ForceNewDeployment = cmdletContext.ForceNewDeployment.Value;
            }
            if (cmdletContext.HealthCheckGracePeriodSeconds != null)
            {
                request.HealthCheckGracePeriodSeconds = cmdletContext.HealthCheckGracePeriodSeconds.Value;
            }
            
             // populate NetworkConfiguration
            bool requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.ECS.Model.NetworkConfiguration();
            Amazon.ECS.Model.AwsVpcConfiguration requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = null;
            
             // populate AwsvpcConfiguration
            bool requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = true;
            requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = new Amazon.ECS.Model.AwsVpcConfiguration();
            Amazon.ECS.AssignPublicIp requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = null;
            if (cmdletContext.NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = cmdletContext.NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.AssignPublicIp = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = null;
            if (cmdletContext.NetworkConfiguration_AwsvpcConfiguration_SecurityGroups != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = cmdletContext.NetworkConfiguration_AwsvpcConfiguration_SecurityGroups;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.SecurityGroups = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = null;
            if (cmdletContext.NetworkConfiguration_AwsvpcConfiguration_Subnets != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = cmdletContext.NetworkConfiguration_AwsvpcConfiguration_Subnets;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.Subnets = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
             // determine if requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration should be set to null
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = null;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration != null)
            {
                request.NetworkConfiguration.AwsvpcConfiguration = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.PlatformVersion != null)
            {
                request.PlatformVersion = cmdletContext.PlatformVersion;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.ECS.Model.UpdateServiceResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateService");
            try
            {
                #if DESKTOP
                return client.UpdateService(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateServiceAsync(request);
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
            public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public System.Boolean? ForceNewDeployment { get; set; }
            public System.Int32? HealthCheckGracePeriodSeconds { get; set; }
            public Amazon.ECS.AssignPublicIp NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_SecurityGroups { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_Subnets { get; set; }
            public System.String PlatformVersion { get; set; }
            public System.String Service { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
