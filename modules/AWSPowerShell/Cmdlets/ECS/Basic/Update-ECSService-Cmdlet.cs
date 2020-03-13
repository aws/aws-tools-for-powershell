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
    /// <important><para>
    /// Updating the task placement strategies and constraints on an Amazon ECS service remains
    /// in preview and is a Beta Service as defined by and subject to the Beta Service Participation
    /// Service Terms located at <a href="https://aws.amazon.com/service-terms">https://aws.amazon.com/service-terms</a>
    /// ("Beta Terms"). These Beta Terms apply to your participation in this preview.
    /// </para></important><para>
    /// Modifies the parameters of a service.
    /// </para><para>
    /// For services using the rolling update (<code>ECS</code>) deployment controller, the
    /// desired count, deployment configuration, network configuration, task placement constraints
    /// and strategies, or task definition used can be updated.
    /// </para><para>
    /// For services using the blue/green (<code>CODE_DEPLOY</code>) deployment controller,
    /// only the desired count, deployment configuration, task placement constraints and strategies,
    /// and health check grace period can be updated using this API. If the network configuration,
    /// platform version, or task definition need to be updated, a new AWS CodeDeploy deployment
    /// should be created. For more information, see <a href="https://docs.aws.amazon.com/codedeploy/latest/APIReference/API_CreateDeployment.html">CreateDeployment</a>
    /// in the <i>AWS CodeDeploy API Reference</i>.
    /// </para><para>
    /// For services using an external deployment controller, you can update only the desired
    /// count, task placement constraints and strategies, and health check grace period using
    /// this API. If the launch type, load balancer, network configuration, platform version,
    /// or task definition need to be updated, you should create a new task set. For more
    /// information, see <a>CreateTaskSet</a>.
    /// </para><para>
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
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateService API operation.", Operation = new[] {"UpdateService"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateServiceResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Service or Amazon.ECS.Model.UpdateServiceResponse",
        "This cmdlet returns an Amazon.ECS.Model.Service object.",
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.ECS.AssignPublicIp")]
        public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
        #endregion
        
        #region Parameter CapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to update the service to use.</para><para>If the service is using the default capacity provider strategy for the cluster, the
        /// service can be updated to use one or more capacity providers as opposed to the default
        /// capacity provider strategy. However, when a service is using a capacity provider strategy
        /// that is not the default capacity provider strategy, the service cannot be updated
        /// to use the cluster's default capacity provider strategy.</para><para>A capacity provider strategy consists of one or more capacity providers along with
        /// the <code>base</code> and <code>weight</code> to assign to them. A capacity provider
        /// must be associated with the cluster to be used in a capacity provider strategy. The
        /// <a>PutClusterCapacityProviders</a> API is used to associate a capacity provider with
        /// a cluster. Only capacity providers with an <code>ACTIVE</code> or <code>UPDATING</code>
        /// status can be used.</para><para>If specifying a capacity provider that uses an Auto Scaling group, the capacity provider
        /// must already be created. New capacity providers can be created with the <a>CreateCapacityProvider</a>
        /// API operation.</para><para>To use a AWS Fargate capacity provider, specify either the <code>FARGATE</code> or
        /// <code>FARGATE_SPOT</code> capacity providers. The AWS Fargate capacity providers are
        /// available to all accounts and only need to be associated with a cluster to be used.</para><para>The <a>PutClusterCapacityProviders</a> API operation is used to update the list of
        /// available capacity providers for a cluster after the cluster is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.CapacityProviderStrategyItem[] CapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that your service
        /// is running on. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter DesiredCount
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the task to place and keep running in your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DesiredCount { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceNewDeployment { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that the Amazon ECS service scheduler should ignore
        /// unhealthy Elastic Load Balancing target health checks after a task has first started.
        /// This is only valid if your service is configured to use a load balancer. If your service's
        /// tasks take a while to start and respond to Elastic Load Balancing health checks, you
        /// can specify a health check grace period of up to 2,147,483,647 seconds. During that
        /// time, the Amazon ECS service scheduler ignores the Elastic Load Balancing health check
        /// status. This grace period can prevent the ECS service scheduler from marking tasks
        /// as unhealthy and stopping them before they have time to come up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckGracePeriodSeconds")]
        public System.Int32? HealthCheckGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MaximumPercent
        /// <summary>
        /// <para>
        /// <para>If a service is using the rolling update (<code>ECS</code>) deployment type, the <b>maximum
        /// percent</b> parameter represents an upper limit on the number of tasks in a service
        /// that are allowed in the <code>RUNNING</code> or <code>PENDING</code> state during
        /// a deployment, as a percentage of the desired number of tasks (rounded down to the
        /// nearest integer), and while any container instances are in the <code>DRAINING</code>
        /// state if the service contains tasks using the EC2 launch type. This parameter enables
        /// you to define the deployment batch size. For example, if your service has a desired
        /// number of four tasks and a maximum percent value of 200%, the scheduler may start
        /// four new tasks before stopping the four older tasks (provided that the cluster resources
        /// required to do this are available). The default value for maximum percent is 200%.</para><para>If a service is using the blue/green (<code>CODE_DEPLOY</code>) or <code>EXTERNAL</code>
        /// deployment types and tasks that use the EC2 launch type, the <b>maximum percent</b>
        /// value is set to the default value and is used to define the upper limit on the number
        /// of the tasks in the service that remain in the <code>RUNNING</code> state while the
        /// container instances are in the <code>DRAINING</code> state. If the tasks in the service
        /// use the Fargate launch type, the maximum percent value is not used, although it is
        /// returned when describing your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MinimumHealthyPercent
        /// <summary>
        /// <para>
        /// <para>If a service is using the rolling update (<code>ECS</code>) deployment type, the <b>minimum
        /// healthy percent</b> represents a lower limit on the number of tasks in a service that
        /// must remain in the <code>RUNNING</code> state during a deployment, as a percentage
        /// of the desired number of tasks (rounded up to the nearest integer), and while any
        /// container instances are in the <code>DRAINING</code> state if the service contains
        /// tasks using the EC2 launch type. This parameter enables you to deploy without using
        /// additional cluster capacity. For example, if your service has a desired number of
        /// four tasks and a minimum healthy percent of 50%, the scheduler may stop two existing
        /// tasks to free up cluster capacity before starting two new tasks. Tasks for services
        /// that <i>do not</i> use a load balancer are considered healthy if they are in the <code>RUNNING</code>
        /// state; tasks for services that <i>do</i> use a load balancer are considered healthy
        /// if they are in the <code>RUNNING</code> state and they are reported as healthy by
        /// the load balancer. The default value for minimum healthy percent is 100%.</para><para>If a service is using the blue/green (<code>CODE_DEPLOY</code>) or <code>EXTERNAL</code>
        /// deployment types and tasks that use the EC2 launch type, the <b>minimum healthy percent</b>
        /// value is set to the default value and is used to define the lower limit on the number
        /// of the tasks in the service that remain in the <code>RUNNING</code> state while the
        /// container instances are in the <code>DRAINING</code> state. If the tasks in the service
        /// use the Fargate launch type, the minimum healthy percent value is not used, although
        /// it is returned when describing your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
        #endregion
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of task placement constraint objects to update the service to use. If no
        /// value is specified, the existing placement constraints for the service will remain
        /// unchanged. If this value is specified, it will override any existing placement constraints
        /// defined for the service. To remove all existing placement constraints, specify an
        /// empty array.</para><para>You can specify a maximum of 10 constraints per task (this limit includes constraints
        /// in the task definition and those specified at runtime).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.PlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The task placement strategy objects to update the service to use. If no value is specified,
        /// the existing placement strategy for the service will remain unchanged. If this value
        /// is specified, it will override the existing placement strategy defined for the service.
        /// To remove an existing placement strategy, specify an empty object.</para><para>You can specify a maximum of five strategy rules per service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.PlacementStrategy[] PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version on which your tasks in the service are running. A platform version
        /// is only specified for tasks using the Fargate launch type. If a platform version is
        /// not specified, the <code>LATEST</code> platform version is used by default. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">AWS
        /// Fargate Platform Versions</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the task or service. If you do not specify a security
        /// group, the default security group for the VPC is used. There is a limit of 5 security
        /// groups that can be specified per <code>AwsVpcConfiguration</code>.</para><note><para>All specified security groups must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_SecurityGroups")]
        public System.String[] AwsvpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The name of the service to update.</para>
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
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets associated with the task or service. There is a limit of 16 subnets that
        /// can be specified per <code>AwsVpcConfiguration</code>.</para><note><para>All specified subnets must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Service'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateServiceResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Service";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Service), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSService (UpdateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateServiceResponse, UpdateECSServiceCmdlet>(Select) ??
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
            if (this.CapacityProviderStrategy != null)
            {
                context.CapacityProviderStrategy = new List<Amazon.ECS.Model.CapacityProviderStrategyItem>(this.CapacityProviderStrategy);
            }
            context.Cluster = this.Cluster;
            context.DeploymentConfiguration_MaximumPercent = this.DeploymentConfiguration_MaximumPercent;
            context.DeploymentConfiguration_MinimumHealthyPercent = this.DeploymentConfiguration_MinimumHealthyPercent;
            context.DesiredCount = this.DesiredCount;
            context.ForceNewDeployment = this.ForceNewDeployment;
            context.HealthCheckGracePeriodSecond = this.HealthCheckGracePeriodSecond;
            context.AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.AwsvpcConfiguration_SecurityGroup = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.AwsvpcConfiguration_Subnet = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            if (this.PlacementConstraint != null)
            {
                context.PlacementConstraint = new List<Amazon.ECS.Model.PlacementConstraint>(this.PlacementConstraint);
            }
            if (this.PlacementStrategy != null)
            {
                context.PlacementStrategy = new List<Amazon.ECS.Model.PlacementStrategy>(this.PlacementStrategy);
            }
            context.PlatformVersion = this.PlatformVersion;
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            
            if (cmdletContext.CapacityProviderStrategy != null)
            {
                request.CapacityProviderStrategy = cmdletContext.CapacityProviderStrategy;
            }
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            
             // populate DeploymentConfiguration
            var requestDeploymentConfigurationIsNull = true;
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
            if (cmdletContext.HealthCheckGracePeriodSecond != null)
            {
                request.HealthCheckGracePeriodSeconds = cmdletContext.HealthCheckGracePeriodSecond.Value;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.ECS.Model.NetworkConfiguration();
            Amazon.ECS.Model.AwsVpcConfiguration requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = null;
            
             // populate AwsvpcConfiguration
            var requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = true;
            requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = new Amazon.ECS.Model.AwsVpcConfiguration();
            Amazon.ECS.AssignPublicIp requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = null;
            if (cmdletContext.AwsvpcConfiguration_AssignPublicIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = cmdletContext.AwsvpcConfiguration_AssignPublicIp;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.AssignPublicIp = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = null;
            if (cmdletContext.AwsvpcConfiguration_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = cmdletContext.AwsvpcConfiguration_SecurityGroup;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.SecurityGroups = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = null;
            if (cmdletContext.AwsvpcConfiguration_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = cmdletContext.AwsvpcConfiguration_Subnet;
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
            if (cmdletContext.PlacementConstraint != null)
            {
                request.PlacementConstraints = cmdletContext.PlacementConstraint;
            }
            if (cmdletContext.PlacementStrategy != null)
            {
                request.PlacementStrategy = cmdletContext.PlacementStrategy;
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
        
        private Amazon.ECS.Model.UpdateServiceResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateService");
            try
            {
                #if DESKTOP
                return client.UpdateService(request);
                #elif CORECLR
                return client.UpdateServiceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ECS.Model.CapacityProviderStrategyItem> CapacityProviderStrategy { get; set; }
            public System.String Cluster { get; set; }
            public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public System.Boolean? ForceNewDeployment { get; set; }
            public System.Int32? HealthCheckGracePeriodSecond { get; set; }
            public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> AwsvpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> AwsvpcConfiguration_Subnet { get; set; }
            public List<Amazon.ECS.Model.PlacementConstraint> PlacementConstraint { get; set; }
            public List<Amazon.ECS.Model.PlacementStrategy> PlacementStrategy { get; set; }
            public System.String PlatformVersion { get; set; }
            public System.String Service { get; set; }
            public System.String TaskDefinition { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateServiceResponse, UpdateECSServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Service;
        }
        
    }
}
