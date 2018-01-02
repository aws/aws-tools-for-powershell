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
    /// ECS spawns another copy of the task in the specified cluster. To update an existing
    /// service, see <a>UpdateService</a>.
    /// 
    ///  
    /// <para>
    /// In addition to maintaining the desired count of tasks in your service, you can optionally
    /// run your service behind a load balancer. The load balancer distributes traffic across
    /// the tasks that are associated with the service. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-load-balancing.html">Service
    /// Load Balancing</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// You can optionally specify a deployment configuration for your service. During a deployment,
    /// the service scheduler uses the <code>minimumHealthyPercent</code> and <code>maximumPercent</code>
    /// parameters to determine the deployment strategy. The deployment is triggered by changing
    /// the task definition or the desired count of a service with an <a>UpdateService</a>
    /// operation.
    /// </para><para>
    /// The <code>minimumHealthyPercent</code> represents a lower limit on the number of your
    /// service's tasks that must remain in the <code>RUNNING</code> state during a deployment,
    /// as a percentage of the <code>desiredCount</code> (rounded up to the nearest integer).
    /// This parameter enables you to deploy without using additional cluster capacity. For
    /// example, if your service has a <code>desiredCount</code> of four tasks and a <code>minimumHealthyPercent</code>
    /// of 50%, the scheduler can stop two existing tasks to free up cluster capacity before
    /// starting two new tasks. Tasks for services that <i>do not</i> use a load balancer
    /// are considered healthy if they are in the <code>RUNNING</code> state. Tasks for services
    /// that <i>do</i> use a load balancer are considered healthy if they are in the <code>RUNNING</code>
    /// state and the container instance they are hosted on is reported as healthy by the
    /// load balancer. The default value for <code>minimumHealthyPercent</code> is 50% in
    /// the console and 100% for the AWS CLI, the AWS SDKs, and the APIs.
    /// </para><para>
    /// The <code>maximumPercent</code> parameter represents an upper limit on the number
    /// of your service's tasks that are allowed in the <code>RUNNING</code> or <code>PENDING</code>
    /// state during a deployment, as a percentage of the <code>desiredCount</code> (rounded
    /// down to the nearest integer). This parameter enables you to define the deployment
    /// batch size. For example, if your service has a <code>desiredCount</code> of four tasks
    /// and a <code>maximumPercent</code> value of 200%, the scheduler can start four new
    /// tasks before stopping the four older tasks (provided that the cluster resources required
    /// to do this are available). The default value for <code>maximumPercent</code> is 200%.
    /// </para><para>
    /// When the service scheduler launches new tasks, it determines task placement in your
    /// cluster using the following logic:
    /// </para><ul><li><para>
    /// Determine which of the container instances in your cluster can support your service's
    /// task definition (for example, they have the required CPU, memory, ports, and container
    /// instance attributes).
    /// </para></li><li><para>
    /// By default, the service scheduler attempts to balance tasks across Availability Zones
    /// in this manner (although you can choose a different placement strategy) with the <code>placementStrategy</code>
    /// parameter):
    /// </para><ul><li><para>
    /// Sort the valid container instances by the fewest number of running tasks for this
    /// service in the same Availability Zone as the instance. For example, if zone A has
    /// one running service task and zones B and C each have zero, valid container instances
    /// in either zone B or C are considered optimal for placement.
    /// </para></li><li><para>
    /// Place the new service task on a valid container instance in an optimal Availability
    /// Zone (based on the previous steps), favoring container instances with the fewest number
    /// of running tasks for this service.
    /// </para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("New", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateService API operation.", Operation = new[] {"CreateService"})]
    [AWSCmdletOutput("Amazon.ECS.Model.Service",
        "This cmdlet returns a Service object.",
        "The service call response (type Amazon.ECS.Model.CreateServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter AwsvpcConfiguration_AssignPublicIp
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not the task's elastic network interface receives a public IP
        /// address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.ECS.AssignPublicIp")]
        public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
        #endregion
        
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
        
        #region Parameter HealthCheckGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that the Amazon ECS service scheduler should ignore
        /// unhealthy Elastic Load Balancing target health checks after a task has first started.
        /// This is only valid if your service is configured to use a load balancer. If your service's
        /// tasks take a while to start and respond to ELB health checks, you can specify a health
        /// check grace period of up to 1,800 seconds during which the ECS service scheduler will
        /// ignore ELB health check status. This grace period can prevent the ECS service scheduler
        /// from marking tasks as unhealthy and stopping them before they have time to come up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckGracePeriodSeconds")]
        public System.Int32 HealthCheckGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter LaunchType
        /// <summary>
        /// <para>
        /// <para>The launch type on which to run your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.LaunchType")]
        public Amazon.ECS.LaunchType LaunchType { get; set; }
        #endregion
        
        #region Parameter LoadBalancer
        /// <summary>
        /// <para>
        /// <para>A load balancer object representing the load balancer to use with your service. Currently,
        /// you are limited to one load balancer or target group per service. After you create
        /// a service, the load balancer name or target group ARN, container name, and container
        /// port specified in the service definition are immutable.</para><para>For Classic Load Balancers, this object must contain the load balancer name, the container
        /// name (as it appears in a container definition), and the container port to access from
        /// the load balancer. When a task from this service is placed on a container instance,
        /// the container instance is registered with the load balancer specified here.</para><para>For Application Load Balancers and Network Load Balancers, this object must contain
        /// the load balancer target group ARN, the container name (as it appears in a container
        /// definition), and the container port to access from the load balancer. When a task
        /// from this service is placed on a container instance, the container instance and port
        /// combination is registered as a target in the target group specified here.</para>
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
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for tasks in your service. You can
        /// specify a maximum of 10 constraints per task (this limit includes constraints in the
        /// task definition and those specified at run time). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.PlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The placement strategy objects to use for tasks in your service. You can specify a
        /// maximum of five strategy rules per service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ECS.Model.PlacementStrategy[] PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version on which to run your service. If one is not specified, the latest
        /// version is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the IAM role that allows Amazon ECS
        /// to make calls to your load balancer on your behalf. This parameter is only permitted
        /// if you are using a load balancer with your service and your task definition does not
        /// use the <code>awsvpc</code> network mode. If you specify the <code>role</code> parameter,
        /// you must also specify a load balancer object with the <code>loadBalancers</code> parameter.</para><important><para>If your account has already created the Amazon ECS service-linked role, that role
        /// is used by default for your service unless you specify a role here. The service-linked
        /// role is required if your task definition uses the <code>awsvpc</code> network mode,
        /// in which case you should not specify a role here. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/using-service-linked-roles.html">Using
        /// Service-Linked Roles for Amazon ECS</a> in the <i>Amazon Elastic Container Service
        /// Developer Guide</i>.</para></important><para>If your specified role has a path other than <code>/</code>, then you must either
        /// specify the full role ARN (this is recommended) or prefix the role name with the path.
        /// For example, if a role with the name <code>bar</code> has a path of <code>/foo/</code>
        /// then you would specify <code>/foo/bar</code> as the role name. For more information,
        /// see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-friendly-names">Friendly
        /// Names and Paths</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the task or service. If you do not specify a security
        /// group, the default security group for the VPC is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_SecurityGroups")]
        public System.String[] AwsvpcConfiguration_SecurityGroup { get; set; }
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
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets associated with the task or service.</para>
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
        /// is not specified, the latest <code>ACTIVE</code> revision is used.</para>
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            context.Cluster = this.Cluster;
            if (ParameterWasBound("DeploymentConfiguration_MaximumPercent"))
                context.DeploymentConfiguration_MaximumPercent = this.DeploymentConfiguration_MaximumPercent;
            if (ParameterWasBound("DeploymentConfiguration_MinimumHealthyPercent"))
                context.DeploymentConfiguration_MinimumHealthyPercent = this.DeploymentConfiguration_MinimumHealthyPercent;
            if (ParameterWasBound("DesiredCount"))
                context.DesiredCount = this.DesiredCount;
            if (ParameterWasBound("HealthCheckGracePeriodSecond"))
                context.HealthCheckGracePeriodSeconds = this.HealthCheckGracePeriodSecond;
            context.LaunchType = this.LaunchType;
            if (this.LoadBalancer != null)
            {
                context.LoadBalancers = new List<Amazon.ECS.Model.LoadBalancer>(this.LoadBalancer);
            }
            context.NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.NetworkConfiguration_AwsvpcConfiguration_SecurityGroups = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.NetworkConfiguration_AwsvpcConfiguration_Subnets = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            if (this.PlacementConstraint != null)
            {
                context.PlacementConstraints = new List<Amazon.ECS.Model.PlacementConstraint>(this.PlacementConstraint);
            }
            if (this.PlacementStrategy != null)
            {
                context.PlacementStrategy = new List<Amazon.ECS.Model.PlacementStrategy>(this.PlacementStrategy);
            }
            context.PlatformVersion = this.PlatformVersion;
            context.Role = this.Role;
            context.ServiceName = this.ServiceName;
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
            if (cmdletContext.HealthCheckGracePeriodSeconds != null)
            {
                request.HealthCheckGracePeriodSeconds = cmdletContext.HealthCheckGracePeriodSeconds.Value;
            }
            if (cmdletContext.LaunchType != null)
            {
                request.LaunchType = cmdletContext.LaunchType;
            }
            if (cmdletContext.LoadBalancers != null)
            {
                request.LoadBalancers = cmdletContext.LoadBalancers;
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
            if (cmdletContext.PlacementConstraints != null)
            {
                request.PlacementConstraints = cmdletContext.PlacementConstraints;
            }
            if (cmdletContext.PlacementStrategy != null)
            {
                request.PlacementStrategy = cmdletContext.PlacementStrategy;
            }
            if (cmdletContext.PlatformVersion != null)
            {
                request.PlatformVersion = cmdletContext.PlatformVersion;
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
        
        private Amazon.ECS.Model.CreateServiceResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateService");
            try
            {
                #if DESKTOP
                return client.CreateService(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateServiceAsync(request);
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
            public System.String ClientToken { get; set; }
            public System.String Cluster { get; set; }
            public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public System.Int32? HealthCheckGracePeriodSeconds { get; set; }
            public Amazon.ECS.LaunchType LaunchType { get; set; }
            public List<Amazon.ECS.Model.LoadBalancer> LoadBalancers { get; set; }
            public Amazon.ECS.AssignPublicIp NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_SecurityGroups { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_Subnets { get; set; }
            public List<Amazon.ECS.Model.PlacementConstraint> PlacementConstraints { get; set; }
            public List<Amazon.ECS.Model.PlacementStrategy> PlacementStrategy { get; set; }
            public System.String PlatformVersion { get; set; }
            public System.String Role { get; set; }
            public System.String ServiceName { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
