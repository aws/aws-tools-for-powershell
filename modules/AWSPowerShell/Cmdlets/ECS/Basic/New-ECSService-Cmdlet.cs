/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Runs and maintains your desired number of tasks from a specified task definition.
    /// If the number of tasks running in a service drops below the <c>desiredCount</c>, Amazon
    /// ECS runs another copy of the task in the specified cluster. To update an existing
    /// service, use <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_UpdateService.html">UpdateService</a>.
    /// 
    ///  <note><para>
    /// On March 21, 2024, a change was made to resolve the task definition revision before
    /// authorization. When a task definition revision is not specified, authorization will
    /// occur using the latest revision of a task definition.
    /// </para></note><note><para>
    /// Amazon Elastic Inference (EI) is no longer available to customers.
    /// </para></note><para>
    /// In addition to maintaining the desired count of tasks in your service, you can optionally
    /// run your service behind one or more load balancers. The load balancers distribute
    /// traffic across the tasks that are associated with the service. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-load-balancing.html">Service
    /// load balancing</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// You can attach Amazon EBS volumes to Amazon ECS tasks by configuring the volume when
    /// creating or updating a service. <c>volumeConfigurations</c> is only supported for
    /// REPLICA service and not DAEMON service. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ebs-volumes.html#ebs-volume-types">Amazon
    /// EBS volumes</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// Tasks for services that don't use a load balancer are considered healthy if they're
    /// in the <c>RUNNING</c> state. Tasks for services that use a load balancer are considered
    /// healthy if they're in the <c>RUNNING</c> state and are reported as healthy by the
    /// load balancer.
    /// </para><para>
    /// There are two service scheduler strategies available:
    /// </para><ul><li><para><c>REPLICA</c> - The replica scheduling strategy places and maintains your desired
    /// number of tasks across your cluster. By default, the service scheduler spreads tasks
    /// across Availability Zones. You can use task placement strategies and constraints to
    /// customize task placement decisions. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Service
    /// scheduler concepts</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para></li><li><para><c>DAEMON</c> - The daemon scheduling strategy deploys exactly one task on each active
    /// container instance that meets all of the task placement constraints that you specify
    /// in your cluster. The service scheduler also evaluates the task placement constraints
    /// for running tasks. It also stops tasks that don't meet the placement constraints.
    /// When using this strategy, you don't need to specify a desired number of tasks, a task
    /// placement strategy, or use Service Auto Scaling policies. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Amazon
    /// ECS services</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para></li></ul><para>
    /// The deployment controller is the mechanism that determines how tasks are deployed
    /// for your service. The valid options are:
    /// </para><ul><li><para>
    /// ECS
    /// </para><para>
    ///  When you create a service which uses the <c>ECS</c> deployment controller, you can
    /// choose between the following deployment strategies (which you can set in the “<c>strategy</c>”
    /// field in “<c>deploymentConfiguration</c>”): :
    /// </para><ul><li><para><c>ROLLING</c>: When you create a service which uses the <i>rolling update</i> (<c>ROLLING</c>)
    /// deployment strategy, the Amazon ECS service scheduler replaces the currently running
    /// tasks with new tasks. The number of tasks that Amazon ECS adds or removes from the
    /// service during a rolling update is controlled by the service deployment configuration.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/deployment-type-ecs.html">Deploy
    /// Amazon ECS services by replacing tasks</a> in the <i>Amazon Elastic Container Service
    /// Developer Guide</i>.
    /// </para><para>
    /// Rolling update deployments are best suited for the following scenarios:
    /// </para><ul><li><para>
    /// Gradual service updates: You need to update your service incrementally without taking
    /// the entire service offline at once.
    /// </para></li><li><para>
    /// Limited resource requirements: You want to avoid the additional resource costs of
    /// running two complete environments simultaneously (as required by blue/green deployments).
    /// </para></li><li><para>
    /// Acceptable deployment time: Your application can tolerate a longer deployment process,
    /// as rolling updates replace tasks one by one.
    /// </para></li><li><para>
    /// No need for instant roll back: Your service can tolerate a rollback process that takes
    /// minutes rather than seconds.
    /// </para></li><li><para>
    /// Simple deployment process: You prefer a straightforward deployment approach without
    /// the complexity of managing multiple environments, target groups, and listeners.
    /// </para></li><li><para>
    /// No load balancer requirement: Your service doesn't use or require a load balancer,
    /// Application Load Balancer, Network Load Balancer, or Service Connect (which are required
    /// for blue/green deployments).
    /// </para></li><li><para>
    /// Stateful applications: Your application maintains state that makes it difficult to
    /// run two parallel environments.
    /// </para></li><li><para>
    /// Cost sensitivity: You want to minimize deployment costs by not running duplicate environments
    /// during deployment.
    /// </para></li></ul><para>
    /// Rolling updates are the default deployment strategy for services and provide a balance
    /// between deployment safety and resource efficiency for many common application scenarios.
    /// </para></li><li><para><c>BLUE_GREEN</c>: A <i>blue/green</i> deployment strategy (<c>BLUE_GREEN</c>) is
    /// a release methodology that reduces downtime and risk by running two identical production
    /// environments called blue and green. With Amazon ECS blue/green deployments, you can
    /// validate new service revisions before directing production traffic to them. This approach
    /// provides a safer way to deploy changes with the ability to quickly roll back if needed.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/deployment-type-blue-green.html">Amazon
    /// ECS blue/green deployments</a> in the <i>Amazon Elastic Container Service Developer
    /// Guide</i>.
    /// </para><para>
    /// Amazon ECS blue/green deployments are best suited for the following scenarios:
    /// </para><ul><li><para>
    /// Service validation: When you need to validate new service revisions before directing
    /// production traffic to them
    /// </para></li><li><para>
    /// Zero downtime: When your service requires zero-downtime deployments
    /// </para></li><li><para>
    /// Instant roll back: When you need the ability to quickly roll back if issues are detected
    /// </para></li><li><para>
    /// Load balancer requirement: When your service uses Application Load Balancer, Network
    /// Load Balancer, or Service Connect
    /// </para></li></ul></li></ul></li><li><para>
    /// External
    /// </para><para>
    /// Use a third-party deployment controller.
    /// </para></li><li><para>
    /// Blue/green deployment (powered by CodeDeploy)
    /// </para><para>
    /// CodeDeploy installs an updated version of the application as a new replacement task
    /// set and reroutes production traffic from the original application task set to the
    /// replacement task set. The original task set is terminated after a successful deployment.
    /// Use this deployment controller to verify a new deployment of a service before sending
    /// production traffic to it.
    /// </para></li></ul><para>
    /// When creating a service that uses the <c>EXTERNAL</c> deployment controller, you can
    /// specify only parameters that aren't controlled at the task set level. The only required
    /// parameter is the service name. You control your services using the <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_CreateTaskSet.html">CreateTaskSet</a>.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/deployment-types.html">Amazon
    /// ECS deployment types</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// When the service scheduler launches new tasks, it determines task placement. For information
    /// about task placement and task placement strategies, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-placement.html">Amazon
    /// ECS task placement</a> in the <i>Amazon Elastic Container Service Developer Guide</i></para>
    /// </summary>
    [Cmdlet("New", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateService API operation.", Operation = new[] {"CreateService"}, SelectReturnType = typeof(Amazon.ECS.Model.CreateServiceResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Service or Amazon.ECS.Model.CreateServiceResponse",
        "This cmdlet returns an Amazon.ECS.Model.Service object.",
        "The service call response (type Amazon.ECS.Model.CreateServiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alarms_AlarmName
        /// <summary>
        /// <para>
        /// <para>One or more CloudWatch alarm names. Use a "," to separate the alarms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_Alarms_AlarmNames")]
        public System.String[] Alarms_AlarmName { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_AssignPublicIp
        /// <summary>
        /// <para>
        /// <para>Whether the task's elastic network interface receives a public IP address. </para><para>Consider the following when you set this value:</para><ul><li><para>When you use <c>create-service</c> or <c>update-service</c>, the default is <c>DISABLED</c>.
        /// </para></li><li><para>When the service <c>deploymentController</c> is <c>ECS</c>, the value must be <c>DISABLED</c>.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.ECS.AssignPublicIp")]
        public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneRebalancing
        /// <summary>
        /// <para>
        /// <para>Indicates whether to use Availability Zone rebalancing for the service.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-rebalancing.html">Balancing
        /// an Amazon ECS service across Availability Zones</a> in the <i><i>Amazon Elastic Container
        /// Service Developer Guide</i></i>.</para><para>The default behavior of <c>AvailabilityZoneRebalancing</c> differs between create
        /// and update requests:</para><ul><li><para>For create service requests, when no value is specified for <c>AvailabilityZoneRebalancing</c>,
        /// Amazon ECS defaults the value to <c>ENABLED</c>.</para></li><li><para>For update service requests, when no value is specified for <c>AvailabilityZoneRebalancing</c>,
        /// Amazon ECS defaults to the existing service’s <c>AvailabilityZoneRebalancing</c> value.
        /// If the service never had an <c>AvailabilityZoneRebalancing</c> value set, Amazon ECS
        /// treats this as <c>DISABLED</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.AvailabilityZoneRebalancing")]
        public Amazon.ECS.AvailabilityZoneRebalancing AvailabilityZoneRebalancing { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_BakeTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The time period when both blue and green service revisions are running simultaneously
        /// after the production traffic has shifted.</para><para>You must provide this parameter when you use the <c>BLUE_GREEN</c> deployment strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_BakeTimeInMinutes")]
        public System.Int32? DeploymentConfiguration_BakeTimeInMinute { get; set; }
        #endregion
        
        #region Parameter CapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to use for the service.</para><para>If a <c>capacityProviderStrategy</c> is specified, the <c>launchType</c> parameter
        /// must be omitted. If no <c>capacityProviderStrategy</c> or <c>launchType</c> is specified,
        /// the <c>defaultCapacityProviderStrategy</c> for the cluster is used.</para><para>A capacity provider strategy can contain a maximum of 20 capacity providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.CapacityProviderStrategyItem[] CapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that you run your
        /// service on. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter DesiredCount
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the specified task definition to place and keep running
        /// in your service.</para><para>This is required if <c>schedulingStrategy</c> is <c>REPLICA</c> or isn't specified.
        /// If <c>schedulingStrategy</c> is <c>DAEMON</c> then this isn't required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DesiredCount { get; set; }
        #endregion
        
        #region Parameter Alarms_Enable
        /// <summary>
        /// <para>
        /// <para>Determines whether to use the CloudWatch alarm option in the service deployment process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_Alarms_Enable")]
        public System.Boolean? Alarms_Enable { get; set; }
        #endregion
        
        #region Parameter DeploymentCircuitBreaker_Enable
        /// <summary>
        /// <para>
        /// <para>Determines whether to use the deployment circuit breaker logic for the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_DeploymentCircuitBreaker_Enable")]
        public System.Boolean? DeploymentCircuitBreaker_Enable { get; set; }
        #endregion
        
        #region Parameter ServiceConnectConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use Service Connect with this service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ServiceConnectConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to turn on Amazon ECS managed tags for the tasks within the service.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// your Amazon ECS resources</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para><para>When you use Amazon ECS managed tags, you must set the <c>propagateTags</c> request
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableECSManagedTags")]
        public System.Boolean? EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter EnableExecuteCommand
        /// <summary>
        /// <para>
        /// <para>Determines whether the execute command functionality is turned on for the service.
        /// If <c>true</c>, this enables execute command functionality on all containers in the
        /// service tasks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableExecuteCommand { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that the Amazon Amazon ECS service scheduler ignores
        /// unhealthy Elastic Load Balancing, VPC Lattice, and container health checks after a
        /// task has first started. If you do not specify a health check grace period value, the
        /// default value of 0 is used. If you do not use any of the health checks, then <c>healthCheckGracePeriodSeconds</c>
        /// is unused.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckGracePeriodSeconds")]
        public System.Int32? HealthCheckGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter LaunchType
        /// <summary>
        /// <para>
        /// <para>The infrastructure that you run your service on. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_types.html">Amazon
        /// ECS launch types</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><para>The <c>FARGATE</c> launch type runs your tasks on Fargate On-Demand infrastructure.</para><note><para>Fargate Spot infrastructure is available for use but a capacity provider strategy
        /// must be used. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/fargate-capacity-providers.html">Fargate
        /// capacity providers</a> in the <i>Amazon ECS Developer Guide</i>.</para></note><para>The <c>EC2</c> launch type runs your tasks on Amazon EC2 instances registered to your
        /// cluster.</para><para>The <c>EXTERNAL</c> launch type runs your tasks on your on-premises server or virtual
        /// machine (VM) capacity registered to your cluster.</para><para>A service can use either a launch type or a capacity provider strategy. If a <c>launchType</c>
        /// is specified, the <c>capacityProviderStrategy</c> parameter must be omitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.LaunchType")]
        public Amazon.ECS.LaunchType LaunchType { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_LifecycleHook
        /// <summary>
        /// <para>
        /// <para>An array of deployment lifecycle hook objects to run custom logic at specific stages
        /// of the deployment lifecycle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_LifecycleHooks")]
        public Amazon.ECS.Model.DeploymentLifecycleHook[] DeploymentConfiguration_LifecycleHook { get; set; }
        #endregion
        
        #region Parameter LoadBalancer
        /// <summary>
        /// <para>
        /// <para>A load balancer object representing the load balancers to use with your service. For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-load-balancing.html">Service
        /// load balancing</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><para>If the service uses the <c>ECS</c> deployment controller and using either an Application
        /// Load Balancer or Network Load Balancer, you must specify one or more target group
        /// ARNs to attach to the service. The service-linked role is required for services that
        /// use multiple target groups. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using-service-linked-roles.html">Using
        /// service-linked roles for Amazon ECS</a> in the <i>Amazon Elastic Container Service
        /// Developer Guide</i>.</para><para>If the service uses the <c>CODE_DEPLOY</c> deployment controller, the service is required
        /// to use either an Application Load Balancer or Network Load Balancer. When creating
        /// an CodeDeploy deployment group, you specify two target groups (referred to as a <c>targetGroupPair</c>).
        /// During a deployment, CodeDeploy determines which task set in your service has the
        /// status <c>PRIMARY</c>, and it associates one target group with it. Then, it also associates
        /// the other target group with the replacement task set. The load balancer can also have
        /// up to two listeners: a required listener for production traffic and an optional listener
        /// that you can use to perform validation tests with Lambda functions before routing
        /// production traffic to it.</para><para>If you use the <c>CODE_DEPLOY</c> deployment controller, these values can be changed
        /// when updating the service.</para><para>For Application Load Balancers and Network Load Balancers, this object must contain
        /// the load balancer target group ARN, the container name, and the container port to
        /// access from the load balancer. The container name must be as it appears in a container
        /// definition. The load balancer name parameter must be omitted. When a task from this
        /// service is placed on a container instance, the container instance and port combination
        /// is registered as a target in the target group that's specified here.</para><para>For Classic Load Balancers, this object must contain the load balancer name, the container
        /// name , and the container port to access from the load balancer. The container name
        /// must be as it appears in a container definition. The target group ARN parameter must
        /// be omitted. When a task from this service is placed on a container instance, the container
        /// instance is registered with the load balancer that's specified here.</para><para>Services with tasks that use the <c>awsvpc</c> network mode (for example, those with
        /// the Fargate launch type) only support Application Load Balancers and Network Load
        /// Balancers. Classic Load Balancers aren't supported. Also, when you create any target
        /// groups for these services, you must choose <c>ip</c> as the target type, not <c>instance</c>.
        /// This is because tasks that use the <c>awsvpc</c> network mode are associated with
        /// an elastic network interface, not an Amazon EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancers")]
        public Amazon.ECS.Model.LoadBalancer[] LoadBalancer { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_LogDriver
        /// <summary>
        /// <para>
        /// <para>The log driver to use for the container.</para><para>For tasks on Fargate, the supported log drivers are <c>awslogs</c>, <c>splunk</c>,
        /// and <c>awsfirelens</c>.</para><para>For tasks hosted on Amazon EC2 instances, the supported log drivers are <c>awslogs</c>,
        /// <c>fluentd</c>, <c>gelf</c>, <c>json-file</c>, <c>journald</c>, <c>syslog</c>, <c>splunk</c>,
        /// and <c>awsfirelens</c>.</para><para>For more information about using the <c>awslogs</c> log driver, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using_awslogs.html">Send
        /// Amazon ECS logs to CloudWatch</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para><para>For more information about using the <c>awsfirelens</c> log driver, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using_firelens.html">Send
        /// Amazon ECS logs to an Amazon Web Services service or Amazon Web Services Partner</a>.</para><note><para>If you have a custom driver that isn't listed, you can fork the Amazon ECS container
        /// agent project that's <a href="https://github.com/aws/amazon-ecs-agent">available on
        /// GitHub</a> and customize it to work with that driver. We encourage you to submit pull
        /// requests for changes that you would like to have included. However, we don't currently
        /// provide support for running modified copies of this software.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_LogConfiguration_LogDriver")]
        [AWSConstantClassSource("Amazon.ECS.LogDriver")]
        public Amazon.ECS.LogDriver LogConfiguration_LogDriver { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MaximumPercent
        /// <summary>
        /// <para>
        /// <para>If a service is using the rolling update (<c>ECS</c>) deployment type, the <c>maximumPercent</c>
        /// parameter represents an upper limit on the number of your service's tasks that are
        /// allowed in the <c>RUNNING</c> or <c>PENDING</c> state during a deployment, as a percentage
        /// of the <c>desiredCount</c> (rounded down to the nearest integer). This parameter enables
        /// you to define the deployment batch size. For example, if your service is using the
        /// <c>REPLICA</c> service scheduler and has a <c>desiredCount</c> of four tasks and a
        /// <c>maximumPercent</c> value of 200%, the scheduler may start four new tasks before
        /// stopping the four older tasks (provided that the cluster resources required to do
        /// this are available). The default <c>maximumPercent</c> value for a service using the
        /// <c>REPLICA</c> service scheduler is 200%.</para><para>The Amazon ECS scheduler uses this parameter to replace unhealthy tasks by starting
        /// replacement tasks first and then stopping the unhealthy tasks, as long as cluster
        /// resources for starting replacement tasks are available. For more information about
        /// how the scheduler replaces unhealthy tasks, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Amazon
        /// ECS services</a>.</para><para>If a service is using either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c>
        /// deployment types, and tasks in the service use the EC2 launch type, the <b>maximum
        /// percent</b> value is set to the default value. The <b>maximum percent</b> value is
        /// used to define the upper limit on the number of the tasks in the service that remain
        /// in the <c>RUNNING</c> state while the container instances are in the <c>DRAINING</c>
        /// state.</para><note><para>You can't specify a custom <c>maximumPercent</c> value for a service that uses either
        /// the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c> deployment types and has tasks
        /// that use the EC2 launch type.</para></note><para>If the service uses either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c>
        /// deployment types, and the tasks in the service use the Fargate launch type, the maximum
        /// percent value is not used. The value is still returned when describing your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MinimumHealthyPercent
        /// <summary>
        /// <para>
        /// <para>If a service is using the rolling update (<c>ECS</c>) deployment type, the <c>minimumHealthyPercent</c>
        /// represents a lower limit on the number of your service's tasks that must remain in
        /// the <c>RUNNING</c> state during a deployment, as a percentage of the <c>desiredCount</c>
        /// (rounded up to the nearest integer). This parameter enables you to deploy without
        /// using additional cluster capacity. For example, if your service has a <c>desiredCount</c>
        /// of four tasks and a <c>minimumHealthyPercent</c> of 50%, the service scheduler may
        /// stop two existing tasks to free up cluster capacity before starting two new tasks.
        /// </para><para> If any tasks are unhealthy and if <c>maximumPercent</c> doesn't allow the Amazon
        /// ECS scheduler to start replacement tasks, the scheduler stops the unhealthy tasks
        /// one-by-one — using the <c>minimumHealthyPercent</c> as a constraint — to clear up
        /// capacity to launch replacement tasks. For more information about how the scheduler
        /// replaces unhealthy tasks, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Amazon
        /// ECS services</a>. </para><para>For services that <i>do not</i> use a load balancer, the following should be noted:</para><ul><li><para>A service is considered healthy if all essential containers within the tasks in the
        /// service pass their health checks.</para></li><li><para>If a task has no essential containers with a health check defined, the service scheduler
        /// will wait for 40 seconds after a task reaches a <c>RUNNING</c> state before the task
        /// is counted towards the minimum healthy percent total.</para></li><li><para>If a task has one or more essential containers with a health check defined, the service
        /// scheduler will wait for the task to reach a healthy status before counting it towards
        /// the minimum healthy percent total. A task is considered healthy when all essential
        /// containers within the task have passed their health checks. The amount of time the
        /// service scheduler can wait for is determined by the container health check settings.
        /// </para></li></ul><para>For services that <i>do</i> use a load balancer, the following should be noted:</para><ul><li><para>If a task has no essential containers with a health check defined, the service scheduler
        /// will wait for the load balancer target group health check to return a healthy status
        /// before counting the task towards the minimum healthy percent total.</para></li><li><para>If a task has an essential container with a health check defined, the service scheduler
        /// will wait for both the task to reach a healthy status and the load balancer target
        /// group health check to return a healthy status before counting the task towards the
        /// minimum healthy percent total.</para></li></ul><para>The default value for a replica service for <c>minimumHealthyPercent</c> is 100%.
        /// The default <c>minimumHealthyPercent</c> value for a service using the <c>DAEMON</c>
        /// service schedule is 0% for the CLI, the Amazon Web Services SDKs, and the APIs and
        /// 50% for the Amazon Web Services Management Console.</para><para>The minimum number of healthy tasks during a deployment is the <c>desiredCount</c>
        /// multiplied by the <c>minimumHealthyPercent</c>/100, rounded up to the nearest integer
        /// value.</para><para>If a service is using either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c>
        /// deployment types and is running tasks that use the EC2 launch type, the <b>minimum
        /// healthy percent</b> value is set to the default value. The <b>minimum healthy percent</b>
        /// value is used to define the lower limit on the number of the tasks in the service
        /// that remain in the <c>RUNNING</c> state while the container instances are in the <c>DRAINING</c>
        /// state.</para><note><para>You can't specify a custom <c>minimumHealthyPercent</c> value for a service that uses
        /// either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c> deployment types and
        /// has tasks that use the EC2 launch type.</para></note><para>If a service is using either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c>
        /// deployment types and is running tasks that use the Fargate launch type, the minimum
        /// healthy percent value is not used, although it is returned when describing your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
        #endregion
        
        #region Parameter ServiceConnectConfiguration_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace name or full Amazon Resource Name (ARN) of the Cloud Map namespace for
        /// use with Service Connect. The namespace must be in the same Amazon Web Services Region
        /// as the Amazon ECS service and cluster. The type of namespace doesn't affect Service
        /// Connect. For more information about Cloud Map, see <a href="https://docs.aws.amazon.com/cloud-map/latest/dg/working-with-services.html">Working
        /// with Services</a> in the <i>Cloud Map Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceConnectConfiguration_Namespace { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_Option
        /// <summary>
        /// <para>
        /// <para>The configuration options to send to the log driver.</para><para>The options you can specify depend on the log driver. Some of the options you can
        /// specify when you use the <c>awslogs</c> log driver to route logs to Amazon CloudWatch
        /// include the following:</para><dl><dt>awslogs-create-group</dt><dd><para>Required: No</para><para>Specify whether you want the log group to be created automatically. If this option
        /// isn't specified, it defaults to <c>false</c>.</para><note><para>Your IAM policy must include the <c>logs:CreateLogGroup</c> permission before you
        /// attempt to use <c>awslogs-create-group</c>.</para></note></dd><dt>awslogs-region</dt><dd><para>Required: Yes</para><para>Specify the Amazon Web Services Region that the <c>awslogs</c> log driver is to send
        /// your Docker logs to. You can choose to send all of your logs from clusters in different
        /// Regions to a single region in CloudWatch Logs. This is so that they're all visible
        /// in one location. Otherwise, you can separate them by Region for more granularity.
        /// Make sure that the specified log group exists in the Region that you specify with
        /// this option.</para></dd><dt>awslogs-group</dt><dd><para>Required: Yes</para><para>Make sure to specify a log group that the <c>awslogs</c> log driver sends its log
        /// streams to.</para></dd><dt>awslogs-stream-prefix</dt><dd><para>Required: Yes, when using Fargate.Optional when using EC2.</para><para>Use the <c>awslogs-stream-prefix</c> option to associate a log stream with the specified
        /// prefix, the container name, and the ID of the Amazon ECS task that the container belongs
        /// to. If you specify a prefix with this option, then the log stream takes the format
        /// <c>prefix-name/container-name/ecs-task-id</c>.</para><para>If you don't specify a prefix with this option, then the log stream is named after
        /// the container ID that's assigned by the Docker daemon on the container instance. Because
        /// it's difficult to trace logs back to the container that sent them with just the Docker
        /// container ID (which is only available on the container instance), we recommend that
        /// you specify a prefix with this option.</para><para>For Amazon ECS services, you can use the service name as the prefix. Doing so, you
        /// can trace log streams to the service that the container belongs to, the name of the
        /// container that sent them, and the ID of the task that the container belongs to.</para><para>You must specify a stream-prefix for your logs to have your logs appear in the Log
        /// pane when using the Amazon ECS console.</para></dd><dt>awslogs-datetime-format</dt><dd><para>Required: No</para><para>This option defines a multiline start pattern in Python <c>strftime</c> format. A
        /// log message consists of a line that matches the pattern and any following lines that
        /// don’t match the pattern. The matched line is the delimiter between log messages.</para><para>One example of a use case for using this format is for parsing output such as a stack
        /// dump, which might otherwise be logged in multiple entries. The correct pattern allows
        /// it to be captured in a single entry.</para><para>For more information, see <a href="https://docs.docker.com/config/containers/logging/awslogs/#awslogs-datetime-format">awslogs-datetime-format</a>.</para><para>You cannot configure both the <c>awslogs-datetime-format</c> and <c>awslogs-multiline-pattern</c>
        /// options.</para><note><para>Multiline logging performs regular expression parsing and matching of all log messages.
        /// This might have a negative impact on logging performance.</para></note></dd><dt>awslogs-multiline-pattern</dt><dd><para>Required: No</para><para>This option defines a multiline start pattern that uses a regular expression. A log
        /// message consists of a line that matches the pattern and any following lines that don’t
        /// match the pattern. The matched line is the delimiter between log messages.</para><para>For more information, see <a href="https://docs.docker.com/config/containers/logging/awslogs/#awslogs-multiline-pattern">awslogs-multiline-pattern</a>.</para><para>This option is ignored if <c>awslogs-datetime-format</c> is also configured.</para><para>You cannot configure both the <c>awslogs-datetime-format</c> and <c>awslogs-multiline-pattern</c>
        /// options.</para><note><para>Multiline logging performs regular expression parsing and matching of all log messages.
        /// This might have a negative impact on logging performance.</para></note></dd></dl><para>The following options apply to all supported log drivers.</para><dl><dt>mode</dt><dd><para>Required: No</para><para>Valid values: <c>non-blocking</c> | <c>blocking</c></para><para>This option defines the delivery mode of log messages from the container to the log
        /// driver specified using <c>logDriver</c>. The delivery mode you choose affects application
        /// availability when the flow of logs from container is interrupted.</para><para>If you use the <c>blocking</c> mode and the flow of logs is interrupted, calls from
        /// container code to write to the <c>stdout</c> and <c>stderr</c> streams will block.
        /// The logging thread of the application will block as a result. This may cause the application
        /// to become unresponsive and lead to container healthcheck failure. </para><para>If you use the <c>non-blocking</c> mode, the container's logs are instead stored in
        /// an in-memory intermediate buffer configured with the <c>max-buffer-size</c> option.
        /// This prevents the application from becoming unresponsive when logs cannot be sent.
        /// We recommend using this mode if you want to ensure service availability and are okay
        /// with some log loss. For more information, see <a href="http://aws.amazon.com/blogs/containers/preventing-log-loss-with-non-blocking-mode-in-the-awslogs-container-log-driver/">Preventing
        /// log loss with non-blocking mode in the <c>awslogs</c> container log driver</a>.</para><para>You can set a default <c>mode</c> for all containers in a specific Amazon Web Services
        /// Region by using the <c>defaultLogDriverMode</c> account setting. If you don't specify
        /// the <c>mode</c> option or configure the account setting, Amazon ECS will default to
        /// the <c>non-blocking</c> mode. For more information about the account setting, see
        /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-account-settings.html#default-log-driver-mode">Default
        /// log driver mode</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><note><para>On June 25, 2025, Amazon ECS changed the default log driver mode from <c>blocking</c>
        /// to <c>non-blocking</c> to prioritize task availability over logging. To continue using
        /// the <c>blocking</c> mode after this change, do one of the following:</para><ul><li><para>Set the <c>mode</c> option in your container definition's <c>logConfiguration</c>
        /// as <c>blocking</c>.</para></li><li><para>Set the <c>defaultLogDriverMode</c> account setting to <c>blocking</c>.</para></li></ul></note></dd><dt>max-buffer-size</dt><dd><para>Required: No</para><para>Default value: <c>10m</c></para><para>When <c>non-blocking</c> mode is used, the <c>max-buffer-size</c> log option controls
        /// the size of the buffer that's used for intermediate message storage. Make sure to
        /// specify an adequate buffer size based on your application. When the buffer fills up,
        /// further logs cannot be stored. Logs that cannot be stored are lost. </para></dd></dl><para>To route logs using the <c>splunk</c> log router, you need to specify a <c>splunk-token</c>
        /// and a <c>splunk-url</c>.</para><para>When you use the <c>awsfirelens</c> log router to route logs to an Amazon Web Services
        /// Service or Amazon Web Services Partner Network destination for log storage and analytics,
        /// you can set the <c>log-driver-buffer-limit</c> option to limit the number of events
        /// that are buffered in memory, before being sent to the log router container. It can
        /// help to resolve potential log loss issue because high throughput might result in memory
        /// running out for the buffer inside of Docker.</para><para>Other options you can specify when using <c>awsfirelens</c> to route logs depend on
        /// the destination. When you export logs to Amazon Data Firehose, you can specify the
        /// Amazon Web Services Region with <c>region</c> and a name for the log stream with <c>delivery_stream</c>.</para><para>When you export logs to Amazon Kinesis Data Streams, you can specify an Amazon Web
        /// Services Region with <c>region</c> and a data stream name with <c>stream</c>.</para><para> When you export logs to Amazon OpenSearch Service, you can specify options like <c>Name</c>,
        /// <c>Host</c> (OpenSearch Service endpoint without protocol), <c>Port</c>, <c>Index</c>,
        /// <c>Type</c>, <c>Aws_auth</c>, <c>Aws_region</c>, <c>Suppress_Type_Name</c>, and <c>tls</c>.
        /// For more information, see <a href="http://aws.amazon.com/blogs/containers/under-the-hood-firelens-for-amazon-ecs-tasks/">Under
        /// the hood: FireLens for Amazon ECS Tasks</a>.</para><para>When you export logs to Amazon S3, you can specify the bucket using the <c>bucket</c>
        /// option. You can also specify <c>region</c>, <c>total_file_size</c>, <c>upload_timeout</c>,
        /// and <c>use_put_object</c> as options.</para><para>This parameter requires version 1.19 of the Docker Remote API or greater on your container
        /// instance. To check the Docker Remote API version on your container instance, log in
        /// to your container instance and run the following command: <c>sudo docker version --format
        /// '{{.Server.APIVersion}}'</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_LogConfiguration_Options")]
        public System.Collections.Hashtable LogConfiguration_Option { get; set; }
        #endregion
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for tasks in your service. You can
        /// specify a maximum of 10 constraints for each task. This limit includes constraints
        /// in the task definition and those specified at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.PlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The placement strategy objects to use for tasks in your service. You can specify a
        /// maximum of 5 strategy rules for each service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.PlacementStrategy[] PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version that your tasks in the service are running on. A platform version
        /// is specified only for tasks using the Fargate launch type. If one isn't specified,
        /// the <c>LATEST</c> platform version is used. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">Fargate
        /// platform versions</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the task definition to the task. If no
        /// value is specified, the tags aren't propagated. Tags can only be propagated to the
        /// task during task creation. To add tags to a task after task creation, use the <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_TagResource.html">TagResource</a>
        /// API action.</para><para>You must set this to a value other than <c>NONE</c> when you use Cost Explorer. For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/usage-reports.html">Amazon
        /// ECS usage reports</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><para>The default is <c>NONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateTags")]
        public Amazon.ECS.PropagateTags PropagateTag { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the IAM role that allows Amazon ECS
        /// to make calls to your load balancer on your behalf. This parameter is only permitted
        /// if you are using a load balancer with your service and your task definition doesn't
        /// use the <c>awsvpc</c> network mode. If you specify the <c>role</c> parameter, you
        /// must also specify a load balancer object with the <c>loadBalancers</c> parameter.</para><important><para>If your account has already created the Amazon ECS service-linked role, that role
        /// is used for your service unless you specify a role here. The service-linked role is
        /// required if your task definition uses the <c>awsvpc</c> network mode or if the service
        /// is configured to use service discovery, an external deployment controller, multiple
        /// target groups, or Elastic Inference accelerators in which case you don't specify a
        /// role here. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using-service-linked-roles.html">Using
        /// service-linked roles for Amazon ECS</a> in the <i>Amazon Elastic Container Service
        /// Developer Guide</i>.</para></important><para>If your specified role has a path other than <c>/</c>, then you must either specify
        /// the full role ARN (this is recommended) or prefix the role name with the path. For
        /// example, if a role with the name <c>bar</c> has a path of <c>/foo/</c> then you would
        /// specify <c>/foo/bar</c> as the role name. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-friendly-names">Friendly
        /// names and paths</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Alarms_Rollback
        /// <summary>
        /// <para>
        /// <para>Determines whether to configure Amazon ECS to roll back the service if a service deployment
        /// fails. If rollback is used, when a service deployment fails, the service is rolled
        /// back to the last deployment that completed successfully.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_Alarms_Rollback")]
        public System.Boolean? Alarms_Rollback { get; set; }
        #endregion
        
        #region Parameter DeploymentCircuitBreaker_Rollback
        /// <summary>
        /// <para>
        /// <para>Determines whether to configure Amazon ECS to roll back the service if a service deployment
        /// fails. If rollback is on, when a service deployment fails, the service is rolled back
        /// to the last deployment that completed successfully.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_DeploymentCircuitBreaker_Rollback")]
        public System.Boolean? DeploymentCircuitBreaker_Rollback { get; set; }
        #endregion
        
        #region Parameter SchedulingStrategy
        /// <summary>
        /// <para>
        /// <para>The scheduling strategy to use for the service. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Services</a>.</para><para>There are two service scheduler strategies available:</para><ul><li><para><c>REPLICA</c>-The replica scheduling strategy places and maintains the desired number
        /// of tasks across your cluster. By default, the service scheduler spreads tasks across
        /// Availability Zones. You can use task placement strategies and constraints to customize
        /// task placement decisions. This scheduler strategy is required if the service uses
        /// the <c>CODE_DEPLOY</c> or <c>EXTERNAL</c> deployment controller types.</para></li><li><para><c>DAEMON</c>-The daemon scheduling strategy deploys exactly one task on each active
        /// container instance that meets all of the task placement constraints that you specify
        /// in your cluster. The service scheduler also evaluates the task placement constraints
        /// for running tasks and will stop tasks that don't meet the placement constraints. When
        /// you're using this strategy, you don't need to specify a desired number of tasks, a
        /// task placement strategy, or use Service Auto Scaling policies.</para><note><para>Tasks using the Fargate launch type or the <c>CODE_DEPLOY</c> or <c>EXTERNAL</c> deployment
        /// controller types don't support the <c>DAEMON</c> scheduling strategy.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.SchedulingStrategy")]
        public Amazon.ECS.SchedulingStrategy SchedulingStrategy { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_SecretOption
        /// <summary>
        /// <para>
        /// <para>The secrets to pass to the log configuration. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/specifying-sensitive-data.html">Specifying
        /// sensitive data</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_LogConfiguration_SecretOptions")]
        public Amazon.ECS.Model.Secret[] LogConfiguration_SecretOption { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups associated with the task or service. If you don't specify
        /// a security group, the default security group for the VPC is used. There's a limit
        /// of 5 security groups that can be specified.</para><note><para>All specified security groups must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_SecurityGroups")]
        public System.String[] AwsvpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of your service. Up to 255 letters (uppercase and lowercase), numbers, underscores,
        /// and hyphens are allowed. Service names must be unique within a cluster, but you can
        /// have similarly named services in multiple clusters within a Region or across multiple
        /// Regions.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter ServiceRegistry
        /// <summary>
        /// <para>
        /// <para>The details of the service discovery registry to associate with this service. For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-discovery.html">Service
        /// discovery</a>.</para><note><para>Each service may be associated with one service registry. Multiple service registries
        /// for each service isn't supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceRegistries")]
        public Amazon.ECS.Model.ServiceRegistry[] ServiceRegistry { get; set; }
        #endregion
        
        #region Parameter ServiceConnectConfiguration_Service
        /// <summary>
        /// <para>
        /// <para>The list of Service Connect service objects. These are names and aliases (also known
        /// as endpoints) that are used by other Amazon ECS services to connect to this service.
        /// </para><para>This field is not required for a "client" Amazon ECS service that's a member of a
        /// namespace only to connect to other services within the namespace. An example of this
        /// would be a frontend application that accepts incoming requests from either a load
        /// balancer that's attached to the service or by other means.</para><para>An object selects a port from the task definition, assigns a name for the Cloud Map
        /// service, and a list of aliases (endpoints) and ports for client applications to refer
        /// to this service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_Services")]
        public Amazon.ECS.Model.ServiceConnectService[] ServiceConnectConfiguration_Service { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_Strategy
        /// <summary>
        /// <para>
        /// <para>The deployment strategy for the service. Choose from these valid values:</para><ul><li><para><c>ROLLING</c> - When you create a service which uses the rolling update (<c>ROLLING</c>)
        /// deployment strategy, the Amazon ECS service scheduler replaces the currently running
        /// tasks with new tasks. The number of tasks that Amazon ECS adds or removes from the
        /// service during a rolling update is controlled by the service deployment configuration.</para></li><li><para><c>BLUE_GREEN</c> - A blue/green deployment strategy (<c>BLUE_GREEN</c>) is a release
        /// methodology that reduces downtime and risk by running two identical production environments
        /// called blue and green. With Amazon ECS blue/green deployments, you can validate new
        /// service revisions before directing production traffic to them. This approach provides
        /// a safer way to deploy changes with the ability to quickly roll back if needed.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.DeploymentStrategy")]
        public Amazon.ECS.DeploymentStrategy DeploymentConfiguration_Strategy { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets associated with the task or service. There's a limit of 16
        /// subnets that can be specified.</para><note><para>All specified subnets must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_Subnets")]
        public System.String[] AwsvpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the service to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define. When a
        /// service is deleted, the tags are deleted as well.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case-sensitive.</para></li><li><para>Do not use <c>aws:</c>, <c>AWS:</c>, or any upper or lowercase combination of such
        /// as a prefix for either keys or values as it is reserved for Amazon Web Services use.
        /// You cannot edit or delete tag keys or values with this prefix. Tags with this prefix
        /// do not count against your tags per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <c>family</c> and <c>revision</c> (<c>family:revision</c>) or full ARN of the
        /// task definition to run in your service. If a <c>revision</c> isn't specified, the
        /// latest <c>ACTIVE</c> revision is used.</para><para>A task definition must be specified if the service uses either the <c>ECS</c> or <c>CODE_DEPLOY</c>
        /// deployment controllers.</para><para>For more information about deployment types, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/deployment-types.html">Amazon
        /// ECS deployment types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskDefinition { get; set; }
        #endregion
        
        #region Parameter DeploymentController_Type
        /// <summary>
        /// <para>
        /// <para>The deployment controller type to use.</para><para>The deployment controller is the mechanism that determines how tasks are deployed
        /// for your service. The valid options are:</para><ul><li><para>ECS</para><para>When you create a service which uses the <c>ECS</c> deployment controller, you can
        /// choose between the following deployment strategies:</para><ul><li><para><c>ROLLING</c>: When you create a service which uses the <i>rolling update</i> (<c>ROLLING</c>)
        /// deployment strategy, the Amazon ECS service scheduler replaces the currently running
        /// tasks with new tasks. The number of tasks that Amazon ECS adds or removes from the
        /// service during a rolling update is controlled by the service deployment configuration.
        /// </para><para>Rolling update deployments are best suited for the following scenarios:</para><ul><li><para>Gradual service updates: You need to update your service incrementally without taking
        /// the entire service offline at once.</para></li><li><para>Limited resource requirements: You want to avoid the additional resource costs of
        /// running two complete environments simultaneously (as required by blue/green deployments).</para></li><li><para>Acceptable deployment time: Your application can tolerate a longer deployment process,
        /// as rolling updates replace tasks one by one.</para></li><li><para>No need for instant roll back: Your service can tolerate a rollback process that takes
        /// minutes rather than seconds.</para></li><li><para>Simple deployment process: You prefer a straightforward deployment approach without
        /// the complexity of managing multiple environments, target groups, and listeners.</para></li><li><para>No load balancer requirement: Your service doesn't use or require a load balancer,
        /// Application Load Balancer, Network Load Balancer, or Service Connect (which are required
        /// for blue/green deployments).</para></li><li><para>Stateful applications: Your application maintains state that makes it difficult to
        /// run two parallel environments.</para></li><li><para>Cost sensitivity: You want to minimize deployment costs by not running duplicate environments
        /// during deployment.</para></li></ul><para>Rolling updates are the default deployment strategy for services and provide a balance
        /// between deployment safety and resource efficiency for many common application scenarios.</para></li><li><para><c>BLUE_GREEN</c>: A <i>blue/green</i> deployment strategy (<c>BLUE_GREEN</c>) is
        /// a release methodology that reduces downtime and risk by running two identical production
        /// environments called blue and green. With Amazon ECS blue/green deployments, you can
        /// validate new service revisions before directing production traffic to them. This approach
        /// provides a safer way to deploy changes with the ability to quickly roll back if needed.</para><para>Amazon ECS blue/green deployments are best suited for the following scenarios:</para><ul><li><para>Service validation: When you need to validate new service revisions before directing
        /// production traffic to them</para></li><li><para>Zero downtime: When your service requires zero-downtime deployments</para></li><li><para>Instant roll back: When you need the ability to quickly roll back if issues are detected</para></li><li><para>Load balancer requirement: When your service uses Application Load Balancer, Network
        /// Load Balancer, or Service Connect</para></li></ul></li></ul></li><li><para>External</para><para>Use a third-party deployment controller.</para></li><li><para>Blue/green deployment (powered by CodeDeploy)</para><para>CodeDeploy installs an updated version of the application as a new replacement task
        /// set and reroutes production traffic from the original application task set to the
        /// replacement task set. The original task set is terminated after a successful deployment.
        /// Use this deployment controller to verify a new deployment of a service before sending
        /// production traffic to it.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.DeploymentControllerType")]
        public Amazon.ECS.DeploymentControllerType DeploymentController_Type { get; set; }
        #endregion
        
        #region Parameter VolumeConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration for a volume specified in the task definition as a volume that is
        /// configured at launch time. Currently, the only supported volume type is an Amazon
        /// EBS volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VolumeConfigurations")]
        public Amazon.ECS.Model.ServiceVolumeConfiguration[] VolumeConfiguration { get; set; }
        #endregion
        
        #region Parameter VpcLatticeConfiguration
        /// <summary>
        /// <para>
        /// <para>The VPC Lattice configuration for the service being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcLatticeConfigurations")]
        public Amazon.ECS.Model.VpcLatticeConfiguration[] VpcLatticeConfiguration { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An identifier that you provide to ensure the idempotency of the request. It must be
        /// unique and is case sensitive. Up to 36 ASCII characters in the range of 33-126 (inclusive)
        /// are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Service'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.CreateServiceResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.CreateServiceResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSService (CreateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.CreateServiceResponse, NewECSServiceCmdlet>(Select) ??
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
            context.AvailabilityZoneRebalancing = this.AvailabilityZoneRebalancing;
            if (this.CapacityProviderStrategy != null)
            {
                context.CapacityProviderStrategy = new List<Amazon.ECS.Model.CapacityProviderStrategyItem>(this.CapacityProviderStrategy);
            }
            context.ClientToken = this.ClientToken;
            context.Cluster = this.Cluster;
            if (this.Alarms_AlarmName != null)
            {
                context.Alarms_AlarmName = new List<System.String>(this.Alarms_AlarmName);
            }
            context.Alarms_Enable = this.Alarms_Enable;
            context.Alarms_Rollback = this.Alarms_Rollback;
            context.DeploymentConfiguration_BakeTimeInMinute = this.DeploymentConfiguration_BakeTimeInMinute;
            context.DeploymentCircuitBreaker_Enable = this.DeploymentCircuitBreaker_Enable;
            context.DeploymentCircuitBreaker_Rollback = this.DeploymentCircuitBreaker_Rollback;
            if (this.DeploymentConfiguration_LifecycleHook != null)
            {
                context.DeploymentConfiguration_LifecycleHook = new List<Amazon.ECS.Model.DeploymentLifecycleHook>(this.DeploymentConfiguration_LifecycleHook);
            }
            context.DeploymentConfiguration_MaximumPercent = this.DeploymentConfiguration_MaximumPercent;
            context.DeploymentConfiguration_MinimumHealthyPercent = this.DeploymentConfiguration_MinimumHealthyPercent;
            context.DeploymentConfiguration_Strategy = this.DeploymentConfiguration_Strategy;
            context.DeploymentController_Type = this.DeploymentController_Type;
            context.DesiredCount = this.DesiredCount;
            context.EnableECSManagedTag = this.EnableECSManagedTag;
            context.EnableExecuteCommand = this.EnableExecuteCommand;
            context.HealthCheckGracePeriodSecond = this.HealthCheckGracePeriodSecond;
            context.LaunchType = this.LaunchType;
            if (this.LoadBalancer != null)
            {
                context.LoadBalancer = new List<Amazon.ECS.Model.LoadBalancer>(this.LoadBalancer);
            }
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
            context.PropagateTag = this.PropagateTag;
            context.Role = this.Role;
            context.SchedulingStrategy = this.SchedulingStrategy;
            context.ServiceConnectConfiguration_Enabled = this.ServiceConnectConfiguration_Enabled;
            context.LogConfiguration_LogDriver = this.LogConfiguration_LogDriver;
            if (this.LogConfiguration_Option != null)
            {
                context.LogConfiguration_Option = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.LogConfiguration_Option.Keys)
                {
                    context.LogConfiguration_Option.Add((String)hashKey, (System.String)(this.LogConfiguration_Option[hashKey]));
                }
            }
            if (this.LogConfiguration_SecretOption != null)
            {
                context.LogConfiguration_SecretOption = new List<Amazon.ECS.Model.Secret>(this.LogConfiguration_SecretOption);
            }
            context.ServiceConnectConfiguration_Namespace = this.ServiceConnectConfiguration_Namespace;
            if (this.ServiceConnectConfiguration_Service != null)
            {
                context.ServiceConnectConfiguration_Service = new List<Amazon.ECS.Model.ServiceConnectService>(this.ServiceConnectConfiguration_Service);
            }
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ServiceRegistry != null)
            {
                context.ServiceRegistry = new List<Amazon.ECS.Model.ServiceRegistry>(this.ServiceRegistry);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
            }
            context.TaskDefinition = this.TaskDefinition;
            if (this.VolumeConfiguration != null)
            {
                context.VolumeConfiguration = new List<Amazon.ECS.Model.ServiceVolumeConfiguration>(this.VolumeConfiguration);
            }
            if (this.VpcLatticeConfiguration != null)
            {
                context.VpcLatticeConfiguration = new List<Amazon.ECS.Model.VpcLatticeConfiguration>(this.VpcLatticeConfiguration);
            }
            
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
            
            if (cmdletContext.AvailabilityZoneRebalancing != null)
            {
                request.AvailabilityZoneRebalancing = cmdletContext.AvailabilityZoneRebalancing;
            }
            if (cmdletContext.CapacityProviderStrategy != null)
            {
                request.CapacityProviderStrategy = cmdletContext.CapacityProviderStrategy;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            
             // populate DeploymentConfiguration
            var requestDeploymentConfigurationIsNull = true;
            request.DeploymentConfiguration = new Amazon.ECS.Model.DeploymentConfiguration();
            System.Int32? requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute = null;
            if (cmdletContext.DeploymentConfiguration_BakeTimeInMinute != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute = cmdletContext.DeploymentConfiguration_BakeTimeInMinute.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute != null)
            {
                request.DeploymentConfiguration.BakeTimeInMinutes = requestDeploymentConfiguration_deploymentConfiguration_BakeTimeInMinute.Value;
                requestDeploymentConfigurationIsNull = false;
            }
            List<Amazon.ECS.Model.DeploymentLifecycleHook> requestDeploymentConfiguration_deploymentConfiguration_LifecycleHook = null;
            if (cmdletContext.DeploymentConfiguration_LifecycleHook != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_LifecycleHook = cmdletContext.DeploymentConfiguration_LifecycleHook;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_LifecycleHook != null)
            {
                request.DeploymentConfiguration.LifecycleHooks = requestDeploymentConfiguration_deploymentConfiguration_LifecycleHook;
                requestDeploymentConfigurationIsNull = false;
            }
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
            Amazon.ECS.DeploymentStrategy requestDeploymentConfiguration_deploymentConfiguration_Strategy = null;
            if (cmdletContext.DeploymentConfiguration_Strategy != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Strategy = cmdletContext.DeploymentConfiguration_Strategy;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Strategy != null)
            {
                request.DeploymentConfiguration.Strategy = requestDeploymentConfiguration_deploymentConfiguration_Strategy;
                requestDeploymentConfigurationIsNull = false;
            }
            Amazon.ECS.Model.DeploymentCircuitBreaker requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker = null;
            
             // populate DeploymentCircuitBreaker
            var requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull = true;
            requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker = new Amazon.ECS.Model.DeploymentCircuitBreaker();
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable = null;
            if (cmdletContext.DeploymentCircuitBreaker_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable = cmdletContext.DeploymentCircuitBreaker_Enable.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker.Enable = requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable.Value;
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull = false;
            }
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback = null;
            if (cmdletContext.DeploymentCircuitBreaker_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback = cmdletContext.DeploymentCircuitBreaker_Rollback.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker.Rollback = requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback.Value;
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull = false;
            }
             // determine if requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker should be set to null
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker = null;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker != null)
            {
                request.DeploymentConfiguration.DeploymentCircuitBreaker = requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker;
                requestDeploymentConfigurationIsNull = false;
            }
            Amazon.ECS.Model.DeploymentAlarms requestDeploymentConfiguration_deploymentConfiguration_Alarms = null;
            
             // populate Alarms
            var requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = true;
            requestDeploymentConfiguration_deploymentConfiguration_Alarms = new Amazon.ECS.Model.DeploymentAlarms();
            List<System.String> requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName = null;
            if (cmdletContext.Alarms_AlarmName != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName = cmdletContext.Alarms_AlarmName;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.AlarmNames = requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable = null;
            if (cmdletContext.Alarms_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable = cmdletContext.Alarms_Enable.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.Enable = requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable.Value;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback = null;
            if (cmdletContext.Alarms_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback = cmdletContext.Alarms_Rollback.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.Rollback = requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback.Value;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
             // determine if requestDeploymentConfiguration_deploymentConfiguration_Alarms should be set to null
            if (requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms = null;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms != null)
            {
                request.DeploymentConfiguration.Alarms = requestDeploymentConfiguration_deploymentConfiguration_Alarms;
                requestDeploymentConfigurationIsNull = false;
            }
             // determine if request.DeploymentConfiguration should be set to null
            if (requestDeploymentConfigurationIsNull)
            {
                request.DeploymentConfiguration = null;
            }
            
             // populate DeploymentController
            var requestDeploymentControllerIsNull = true;
            request.DeploymentController = new Amazon.ECS.Model.DeploymentController();
            Amazon.ECS.DeploymentControllerType requestDeploymentController_deploymentController_Type = null;
            if (cmdletContext.DeploymentController_Type != null)
            {
                requestDeploymentController_deploymentController_Type = cmdletContext.DeploymentController_Type;
            }
            if (requestDeploymentController_deploymentController_Type != null)
            {
                request.DeploymentController.Type = requestDeploymentController_deploymentController_Type;
                requestDeploymentControllerIsNull = false;
            }
             // determine if request.DeploymentController should be set to null
            if (requestDeploymentControllerIsNull)
            {
                request.DeploymentController = null;
            }
            if (cmdletContext.DesiredCount != null)
            {
                request.DesiredCount = cmdletContext.DesiredCount.Value;
            }
            if (cmdletContext.EnableECSManagedTag != null)
            {
                request.EnableECSManagedTags = cmdletContext.EnableECSManagedTag.Value;
            }
            if (cmdletContext.EnableExecuteCommand != null)
            {
                request.EnableExecuteCommand = cmdletContext.EnableExecuteCommand.Value;
            }
            if (cmdletContext.HealthCheckGracePeriodSecond != null)
            {
                request.HealthCheckGracePeriodSeconds = cmdletContext.HealthCheckGracePeriodSecond.Value;
            }
            if (cmdletContext.LaunchType != null)
            {
                request.LaunchType = cmdletContext.LaunchType;
            }
            if (cmdletContext.LoadBalancer != null)
            {
                request.LoadBalancers = cmdletContext.LoadBalancer;
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
            if (cmdletContext.PropagateTag != null)
            {
                request.PropagateTags = cmdletContext.PropagateTag;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.SchedulingStrategy != null)
            {
                request.SchedulingStrategy = cmdletContext.SchedulingStrategy;
            }
            
             // populate ServiceConnectConfiguration
            var requestServiceConnectConfigurationIsNull = true;
            request.ServiceConnectConfiguration = new Amazon.ECS.Model.ServiceConnectConfiguration();
            System.Boolean? requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled = null;
            if (cmdletContext.ServiceConnectConfiguration_Enabled != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled = cmdletContext.ServiceConnectConfiguration_Enabled.Value;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled != null)
            {
                request.ServiceConnectConfiguration.Enabled = requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled.Value;
                requestServiceConnectConfigurationIsNull = false;
            }
            System.String requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace = null;
            if (cmdletContext.ServiceConnectConfiguration_Namespace != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace = cmdletContext.ServiceConnectConfiguration_Namespace;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace != null)
            {
                request.ServiceConnectConfiguration.Namespace = requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace;
                requestServiceConnectConfigurationIsNull = false;
            }
            List<Amazon.ECS.Model.ServiceConnectService> requestServiceConnectConfiguration_serviceConnectConfiguration_Service = null;
            if (cmdletContext.ServiceConnectConfiguration_Service != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_Service = cmdletContext.ServiceConnectConfiguration_Service;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_Service != null)
            {
                request.ServiceConnectConfiguration.Services = requestServiceConnectConfiguration_serviceConnectConfiguration_Service;
                requestServiceConnectConfigurationIsNull = false;
            }
            Amazon.ECS.Model.LogConfiguration requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration = null;
            
             // populate LogConfiguration
            var requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = true;
            requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration = new Amazon.ECS.Model.LogConfiguration();
            Amazon.ECS.LogDriver requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver = null;
            if (cmdletContext.LogConfiguration_LogDriver != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver = cmdletContext.LogConfiguration_LogDriver;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration.LogDriver = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver;
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option = null;
            if (cmdletContext.LogConfiguration_Option != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option = cmdletContext.LogConfiguration_Option;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration.Options = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option;
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = false;
            }
            List<Amazon.ECS.Model.Secret> requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption = null;
            if (cmdletContext.LogConfiguration_SecretOption != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption = cmdletContext.LogConfiguration_SecretOption;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration.SecretOptions = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption;
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = false;
            }
             // determine if requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration should be set to null
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration = null;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration != null)
            {
                request.ServiceConnectConfiguration.LogConfiguration = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration;
                requestServiceConnectConfigurationIsNull = false;
            }
             // determine if request.ServiceConnectConfiguration should be set to null
            if (requestServiceConnectConfigurationIsNull)
            {
                request.ServiceConnectConfiguration = null;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.ServiceRegistry != null)
            {
                request.ServiceRegistries = cmdletContext.ServiceRegistry;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TaskDefinition != null)
            {
                request.TaskDefinition = cmdletContext.TaskDefinition;
            }
            if (cmdletContext.VolumeConfiguration != null)
            {
                request.VolumeConfigurations = cmdletContext.VolumeConfiguration;
            }
            if (cmdletContext.VpcLatticeConfiguration != null)
            {
                request.VpcLatticeConfigurations = cmdletContext.VpcLatticeConfiguration;
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
        
        private Amazon.ECS.Model.CreateServiceResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateService");
            try
            {
                #if DESKTOP
                return client.CreateService(request);
                #elif CORECLR
                return client.CreateServiceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ECS.AvailabilityZoneRebalancing AvailabilityZoneRebalancing { get; set; }
            public List<Amazon.ECS.Model.CapacityProviderStrategyItem> CapacityProviderStrategy { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Cluster { get; set; }
            public List<System.String> Alarms_AlarmName { get; set; }
            public System.Boolean? Alarms_Enable { get; set; }
            public System.Boolean? Alarms_Rollback { get; set; }
            public System.Int32? DeploymentConfiguration_BakeTimeInMinute { get; set; }
            public System.Boolean? DeploymentCircuitBreaker_Enable { get; set; }
            public System.Boolean? DeploymentCircuitBreaker_Rollback { get; set; }
            public List<Amazon.ECS.Model.DeploymentLifecycleHook> DeploymentConfiguration_LifecycleHook { get; set; }
            public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
            public Amazon.ECS.DeploymentStrategy DeploymentConfiguration_Strategy { get; set; }
            public Amazon.ECS.DeploymentControllerType DeploymentController_Type { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public System.Boolean? EnableECSManagedTag { get; set; }
            public System.Boolean? EnableExecuteCommand { get; set; }
            public System.Int32? HealthCheckGracePeriodSecond { get; set; }
            public Amazon.ECS.LaunchType LaunchType { get; set; }
            public List<Amazon.ECS.Model.LoadBalancer> LoadBalancer { get; set; }
            public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> AwsvpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> AwsvpcConfiguration_Subnet { get; set; }
            public List<Amazon.ECS.Model.PlacementConstraint> PlacementConstraint { get; set; }
            public List<Amazon.ECS.Model.PlacementStrategy> PlacementStrategy { get; set; }
            public System.String PlatformVersion { get; set; }
            public Amazon.ECS.PropagateTags PropagateTag { get; set; }
            public System.String Role { get; set; }
            public Amazon.ECS.SchedulingStrategy SchedulingStrategy { get; set; }
            public System.Boolean? ServiceConnectConfiguration_Enabled { get; set; }
            public Amazon.ECS.LogDriver LogConfiguration_LogDriver { get; set; }
            public Dictionary<System.String, System.String> LogConfiguration_Option { get; set; }
            public List<Amazon.ECS.Model.Secret> LogConfiguration_SecretOption { get; set; }
            public System.String ServiceConnectConfiguration_Namespace { get; set; }
            public List<Amazon.ECS.Model.ServiceConnectService> ServiceConnectConfiguration_Service { get; set; }
            public System.String ServiceName { get; set; }
            public List<Amazon.ECS.Model.ServiceRegistry> ServiceRegistry { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.String TaskDefinition { get; set; }
            public List<Amazon.ECS.Model.ServiceVolumeConfiguration> VolumeConfiguration { get; set; }
            public List<Amazon.ECS.Model.VpcLatticeConfiguration> VpcLatticeConfiguration { get; set; }
            public System.Func<Amazon.ECS.Model.CreateServiceResponse, NewECSServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Service;
        }
        
    }
}
