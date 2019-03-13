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
    /// Runs and maintains a desired number of tasks from a specified task definition. If
    /// the number of tasks running in a service drops below the <code>desiredCount</code>,
    /// Amazon ECS spawns another copy of the task in the specified cluster. To update an
    /// existing service, see <a>UpdateService</a>.
    /// 
    ///  
    /// <para>
    /// In addition to maintaining the desired count of tasks in your service, you can optionally
    /// run your service behind a load balancer. The load balancer distributes traffic across
    /// the tasks that are associated with the service. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-load-balancing.html">Service
    /// Load Balancing</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// Tasks for services that <i>do not</i> use a load balancer are considered healthy if
    /// they're in the <code>RUNNING</code> state. Tasks for services that <i>do</i> use a
    /// load balancer are considered healthy if they're in the <code>RUNNING</code> state
    /// and the container instance that they're hosted on is reported as healthy by the load
    /// balancer.
    /// </para><para>
    /// There are two service scheduler strategies available:
    /// </para><ul><li><para><code>REPLICA</code> - The replica scheduling strategy places and maintains the desired
    /// number of tasks across your cluster. By default, the service scheduler spreads tasks
    /// across Availability Zones. You can use task placement strategies and constraints to
    /// customize task placement decisions. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Service
    /// Scheduler Concepts</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para></li><li><para><code>DAEMON</code> - The daemon scheduling strategy deploys exactly one task on
    /// each active container instance that meets all of the task placement constraints that
    /// you specify in your cluster. When using this strategy, you don't need to specify a
    /// desired number of tasks, a task placement strategy, or use Service Auto Scaling policies.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Service
    /// Scheduler Concepts</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para></li></ul><para>
    /// You can optionally specify a deployment configuration for your service. The deployment
    /// is triggered by changing properties, such as the task definition or the desired count
    /// of a service, with an <a>UpdateService</a> operation. The default value for a replica
    /// service for <code>minimumHealthyPercent</code> is 100%. The default value for a daemon
    /// service for <code>minimumHealthyPercent</code> is 0%.
    /// </para><para>
    /// If a service is using the <code>ECS</code> deployment controller, the minimum healthy
    /// percent represents a lower limit on the number of tasks in a service that must remain
    /// in the <code>RUNNING</code> state during a deployment, as a percentage of the desired
    /// number of tasks (rounded up to the nearest integer), and while any container instances
    /// are in the <code>DRAINING</code> state if the service contains tasks using the EC2
    /// launch type. This parameter enables you to deploy without using additional cluster
    /// capacity. For example, if your service has a desired number of four tasks and a minimum
    /// healthy percent of 50%, the scheduler might stop two existing tasks to free up cluster
    /// capacity before starting two new tasks. Tasks for services that <i>do not</i> use
    /// a load balancer are considered healthy if they're in the <code>RUNNING</code> state.
    /// Tasks for services that <i>do</i> use a load balancer are considered healthy if they're
    /// in the <code>RUNNING</code> state and they're reported as healthy by the load balancer.
    /// The default value for minimum healthy percent is 100%.
    /// </para><para>
    /// If a service is using the <code>ECS</code> deployment controller, the <b>maximum percent</b>
    /// parameter represents an upper limit on the number of tasks in a service that are allowed
    /// in the <code>RUNNING</code> or <code>PENDING</code> state during a deployment, as
    /// a percentage of the desired number of tasks (rounded down to the nearest integer),
    /// and while any container instances are in the <code>DRAINING</code> state if the service
    /// contains tasks using the EC2 launch type. This parameter enables you to define the
    /// deployment batch size. For example, if your service has a desired number of four tasks
    /// and a maximum percent value of 200%, the scheduler may start four new tasks before
    /// stopping the four older tasks (provided that the cluster resources required to do
    /// this are available). The default value for maximum percent is 200%.
    /// </para><para>
    /// If a service is using either the <code>CODE_DEPLOY</code> or <code>EXTERNAL</code>
    /// deployment controller types and tasks that use the EC2 launch type, the <b>minimum
    /// healthy percent</b> and <b>maximum percent</b> values are used only to define the
    /// lower and upper limit on the number of the tasks in the service that remain in the
    /// <code>RUNNING</code> state while the container instances are in the <code>DRAINING</code>
    /// state. If the tasks in the service use the Fargate launch type, the minimum healthy
    /// percent and maximum percent values aren't used, although they're currently visible
    /// when describing your service.
    /// </para><para>
    /// When creating a service that uses the <code>EXTERNAL</code> deployment controller,
    /// you can specify only parameters that aren't controlled at the task set level. The
    /// only required parameter is the service name. You control your services using the <a>CreateTaskSet</a>
    /// operation. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/deployment-types.html">Amazon
    /// ECS Deployment Types</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
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
    /// Sort the valid container instances, giving priority to instances that have the fewest
    /// number of running tasks for this service in their respective Availability Zone. For
    /// example, if zone A has one running service task and zones B and C each have zero,
    /// valid container instances in either zone B or C are considered optimal for placement.
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
        /// <para>Whether the task's elastic network interface receives a public IP address. The default
        /// value is <code>DISABLED</code>.</para>
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
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. Up to 32 ASCII characters are allowed.</para>
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
        
        #region Parameter EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable Amazon ECS managed tags for the tasks within the service.
        /// For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// Your Amazon ECS Resources</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EnableECSManagedTags")]
        public System.Boolean EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that the Amazon ECS service scheduler should ignore
        /// unhealthy Elastic Load Balancing target health checks after a task has first started.
        /// This is only valid if your service is configured to use a load balancer. If your service's
        /// tasks take a while to start and respond to Elastic Load Balancing health checks, you
        /// can specify a health check grace period of up to 2,147,483,647 seconds. During that
        /// time, the ECS service scheduler ignores health check status. This grace period can
        /// prevent the ECS service scheduler from marking tasks as unhealthy and stopping them
        /// before they have time to come up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckGracePeriodSeconds")]
        public System.Int32 HealthCheckGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter LaunchType
        /// <summary>
        /// <para>
        /// <para>The launch type on which to run your service. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_types.html">Amazon
        /// ECS Launch Types</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.LaunchType")]
        public Amazon.ECS.LaunchType LaunchType { get; set; }
        #endregion
        
        #region Parameter LoadBalancer
        /// <summary>
        /// <para>
        /// <para>A load balancer object representing the load balancer to use with your service.</para><para>If the service is using the <code>ECS</code> deployment controller, you are limited
        /// to one load balancer or target group.</para><para>If the service is using the <code>CODE_DEPLOY</code> deployment controller, the service
        /// is required to use either an Application Load Balancer or Network Load Balancer. When
        /// creating an AWS CodeDeploy deployment group, you specify two target groups (referred
        /// to as a <code>targetGroupPair</code>). During a deployment, AWS CodeDeploy determines
        /// which task set in your service has the status <code>PRIMARY</code> and associates
        /// one target group with it, and then associates the other target group with the replacement
        /// task set. The load balancer can also have up to two listeners: a required listener
        /// for production traffic and an optional listener that allows you perform validation
        /// tests with Lambda functions before routing production traffic to it.</para><para>After you create a service using the <code>ECS</code> deployment controller, the load
        /// balancer name or target group ARN, container name, and container port specified in
        /// the service definition are immutable. If you are using the <code>CODE_DEPLOY</code>
        /// deployment controller, these values can be changed when updating the service.</para><para>For Classic Load Balancers, this object must contain the load balancer name, the container
        /// name (as it appears in a container definition), and the container port to access from
        /// the load balancer. When a task from this service is placed on a container instance,
        /// the container instance is registered with the load balancer specified here.</para><para>For Application Load Balancers and Network Load Balancers, this object must contain
        /// the load balancer target group ARN, the container name (as it appears in a container
        /// definition), and the container port to access from the load balancer. When a task
        /// from this service is placed on a container instance, the container instance and port
        /// combination is registered as a target in the target group specified here.</para><para>Services with tasks that use the <code>awsvpc</code> network mode (for example, those
        /// with the Fargate launch type) only support Application Load Balancers and Network
        /// Load Balancers. Classic Load Balancers are not supported. Also, when you create any
        /// target groups for these services, you must choose <code>ip</code> as the target type,
        /// not <code>instance</code>, because tasks that use the <code>awsvpc</code> network
        /// mode are associated with an elastic network interface, not an Amazon EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LoadBalancers")]
        public Amazon.ECS.Model.LoadBalancer[] LoadBalancer { get; set; }
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
        [System.Management.Automation.Parameter]
        public System.Int32 DeploymentConfiguration_MaximumPercent { get; set; }
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
        [System.Management.Automation.Parameter]
        public System.Int32 DeploymentConfiguration_MinimumHealthyPercent { get; set; }
        #endregion
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for tasks in your service. You can
        /// specify a maximum of 10 constraints per task (this limit includes constraints in the
        /// task definition and those specified at runtime). </para>
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
        /// <para>The platform version that your tasks in the service are running on. A platform version
        /// is specified only for tasks using the Fargate launch type. If one isn't specified,
        /// the <code>LATEST</code> platform version is used by default. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">AWS
        /// Fargate Platform Versions</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the task definition or the service to
        /// the tasks in the service. If no value is specified, the tags are not propagated. Tags
        /// can only be propagated to the tasks within the service during service creation. To
        /// add tags to a task after service creation, use the <a>TagResource</a> API action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateTags")]
        public Amazon.ECS.PropagateTags PropagateTag { get; set; }
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
        /// see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-friendly-names">Friendly
        /// Names and Paths</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter SchedulingStrategy
        /// <summary>
        /// <para>
        /// <para>The scheduling strategy to use for the service. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs_services.html">Services</a>.</para><para>There are two service scheduler strategies available:</para><ul><li><para><code>REPLICA</code>-The replica scheduling strategy places and maintains the desired
        /// number of tasks across your cluster. By default, the service scheduler spreads tasks
        /// across Availability Zones. You can use task placement strategies and constraints to
        /// customize task placement decisions. This scheduler strategy is required if the service
        /// is using the <code>CODE_DEPLOY</code> or <code>EXTERNAL</code> deployment controller
        /// types.</para></li><li><para><code>DAEMON</code>-The daemon scheduling strategy deploys exactly one task on each
        /// active container instance that meets all of the task placement constraints that you
        /// specify in your cluster. When you're using this strategy, you don't need to specify
        /// a desired number of tasks, a task placement strategy, or use Service Auto Scaling
        /// policies.</para><note><para>Tasks using the Fargate launch type or the <code>CODE_DEPLOY</code> or <code>EXTERNAL</code>
        /// deployment controller types don't support the <code>DAEMON</code> scheduling strategy.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.SchedulingStrategy")]
        public Amazon.ECS.SchedulingStrategy SchedulingStrategy { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the task or service. If you do not specify a security
        /// group, the default security group for the VPC is used. There is a limit of 5 security
        /// groups that can be specified per <code>AwsVpcConfiguration</code>.</para><note><para>All specified security groups must be from the same VPC.</para></note>
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
        /// can have similarly named services in multiple clusters within a Region or across multiple
        /// Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter ServiceRegistry
        /// <summary>
        /// <para>
        /// <para>The details of the service discovery registries to assign to this service. For more
        /// information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-discovery.html">Service
        /// Discovery</a>.</para><note><para>Service discovery is supported for Fargate tasks if you are using platform version
        /// v1.1.0 or later. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">AWS
        /// Fargate Platform Versions</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ServiceRegistries")]
        public Amazon.ECS.Model.ServiceRegistry[] ServiceRegistry { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets associated with the task or service. There is a limit of 16 subnets that
        /// can be specified per <code>AwsVpcConfiguration</code>.</para><note><para>All specified subnets must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_Subnets")]
        public System.String[] AwsvpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the service to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define. When a
        /// service is deleted, the tags are deleted as well. Tag keys can have a maximum character
        /// length of 128 characters, and tag values can have a maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> and <code>revision</code> (<code>family:revision</code>) or
        /// full ARN of the task definition to run in your service. If a <code>revision</code>
        /// is not specified, the latest <code>ACTIVE</code> revision is used.</para><para>A task definition must be specified if the service is using the <code>ECS</code> deployment
        /// controller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TaskDefinition { get; set; }
        #endregion
        
        #region Parameter DeploymentController_Type
        /// <summary>
        /// <para>
        /// <para>The deployment controller type to use.</para><para>There are three deployment controller types available:</para><dl><dt>ECS</dt><dd><para>The rolling update (<code>ECS</code>) deployment type involves replacing the current
        /// running version of the container with the latest version. The number of containers
        /// Amazon ECS adds or removes from the service during a rolling update is controlled
        /// by adjusting the minimum and maximum number of healthy tasks allowed during a service
        /// deployment, as specified in the <a>DeploymentConfiguration</a>.</para></dd><dt>CODE_DEPLOY</dt><dd><para>The blue/green (<code>CODE_DEPLOY</code>) deployment type uses the blue/green deployment
        /// model powered by AWS CodeDeploy, which allows you to verify a new deployment of a
        /// service before sending production traffic to it.</para></dd><dt>EXTERNAL</dt><dd><para>The external (<code>EXTERNAL</code>) deployment type enables you to use any third-party
        /// deployment controller for full control over the deployment process for an Amazon ECS
        /// service.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.DeploymentControllerType")]
        public Amazon.ECS.DeploymentControllerType DeploymentController_Type { get; set; }
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
            context.DeploymentController_Type = this.DeploymentController_Type;
            if (ParameterWasBound("DesiredCount"))
                context.DesiredCount = this.DesiredCount;
            if (ParameterWasBound("EnableECSManagedTag"))
                context.EnableECSManagedTags = this.EnableECSManagedTag;
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
            context.PropagateTags = this.PropagateTag;
            context.Role = this.Role;
            context.SchedulingStrategy = this.SchedulingStrategy;
            context.ServiceName = this.ServiceName;
            if (this.ServiceRegistry != null)
            {
                context.ServiceRegistries = new List<Amazon.ECS.Model.ServiceRegistry>(this.ServiceRegistry);
            }
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ECS.Model.Tag>(this.Tag);
            }
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
            
             // populate DeploymentController
            bool requestDeploymentControllerIsNull = true;
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
            if (cmdletContext.EnableECSManagedTags != null)
            {
                request.EnableECSManagedTags = cmdletContext.EnableECSManagedTags.Value;
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
            if (cmdletContext.PropagateTags != null)
            {
                request.PropagateTags = cmdletContext.PropagateTags;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.SchedulingStrategy != null)
            {
                request.SchedulingStrategy = cmdletContext.SchedulingStrategy;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.ServiceRegistries != null)
            {
                request.ServiceRegistries = cmdletContext.ServiceRegistries;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
            public System.String ClientToken { get; set; }
            public System.String Cluster { get; set; }
            public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
            public Amazon.ECS.DeploymentControllerType DeploymentController_Type { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public System.Boolean? EnableECSManagedTags { get; set; }
            public System.Int32? HealthCheckGracePeriodSeconds { get; set; }
            public Amazon.ECS.LaunchType LaunchType { get; set; }
            public List<Amazon.ECS.Model.LoadBalancer> LoadBalancers { get; set; }
            public Amazon.ECS.AssignPublicIp NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_SecurityGroups { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_Subnets { get; set; }
            public List<Amazon.ECS.Model.PlacementConstraint> PlacementConstraints { get; set; }
            public List<Amazon.ECS.Model.PlacementStrategy> PlacementStrategy { get; set; }
            public System.String PlatformVersion { get; set; }
            public Amazon.ECS.PropagateTags PropagateTags { get; set; }
            public System.String Role { get; set; }
            public Amazon.ECS.SchedulingStrategy SchedulingStrategy { get; set; }
            public System.String ServiceName { get; set; }
            public List<Amazon.ECS.Model.ServiceRegistry> ServiceRegistries { get; set; }
            public List<Amazon.ECS.Model.Tag> Tags { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
