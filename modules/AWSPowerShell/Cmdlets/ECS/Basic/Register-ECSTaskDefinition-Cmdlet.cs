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
using System.Threading;
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Registers a new task definition from the supplied <c>family</c> and <c>containerDefinitions</c>.
    /// Optionally, you can add data volumes to your containers with the <c>volumes</c> parameter.
    /// For more information about task definition parameters and defaults, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_defintions.html">Amazon
    /// ECS Task Definitions</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can specify a role for your task with the <c>taskRoleArn</c> parameter. When you
    /// specify a role for a task, its containers can then use the latest versions of the
    /// CLI or SDKs to make API requests to the Amazon Web Services services that are specified
    /// in the policy that's associated with the role. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
    /// Roles for Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// You can specify a Docker networking mode for the containers in your task definition
    /// with the <c>networkMode</c> parameter. If you specify the <c>awsvpc</c> network mode,
    /// the task is allocated an elastic network interface, and you must specify a <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_NetworkConfiguration.html">NetworkConfiguration</a>
    /// when you create a service or run a task with the task definition. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking.html">Task
    /// Networking</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "ECSTaskDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.RegisterTaskDefinitionResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service RegisterTaskDefinition API operation.", Operation = new[] {"RegisterTaskDefinition"}, SelectReturnType = typeof(Amazon.ECS.Model.RegisterTaskDefinitionResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.RegisterTaskDefinitionResponse",
        "This cmdlet returns an Amazon.ECS.Model.RegisterTaskDefinitionResponse object containing multiple properties."
    )]
    public partial class RegisterECSTaskDefinitionCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContainerDefinition
        /// <summary>
        /// <para>
        /// <para>A list of container definitions in JSON format that describe the different containers
        /// that make up your task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ContainerDefinitions")]
        public Amazon.ECS.Model.ContainerDefinition[] ContainerDefinition { get; set; }
        #endregion
        
        #region Parameter ProxyConfiguration_ContainerName
        /// <summary>
        /// <para>
        /// <para>The name of the container that will serve as the App Mesh proxy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxyConfiguration_ContainerName { get; set; }
        #endregion
        
        #region Parameter Cpu
        /// <summary>
        /// <para>
        /// <para>The number of CPU units used by the task. It can be expressed as an integer using
        /// CPU units (for example, <c>1024</c>) or as a string using vCPUs (for example, <c>1
        /// vCPU</c> or <c>1 vcpu</c>) in a task definition. String values are converted to an
        /// integer indicating the CPU units when the task definition is registered.</para><note><para>Task-level CPU and memory parameters are ignored for Windows containers. We recommend
        /// specifying container-level resources for Windows containers.</para></note><para>If you're using the EC2 launch type, this field is optional. Supported values are
        /// between <c>128</c> CPU units (<c>0.125</c> vCPUs) and <c>10240</c> CPU units (<c>10</c>
        /// vCPUs). If you do not specify a value, the parameter is ignored.</para><para>If you're using the Fargate launch type, this field is required and you must use one
        /// of the following values, which determines your range of supported values for the <c>memory</c>
        /// parameter:</para><para>The CPU units cannot be less than 1 vCPU when you use Windows containers on Fargate.</para><ul><li><para>256 (.25 vCPU) - Available <c>memory</c> values: 512 (0.5 GB), 1024 (1 GB), 2048 (2
        /// GB)</para></li><li><para>512 (.5 vCPU) - Available <c>memory</c> values: 1024 (1 GB), 2048 (2 GB), 3072 (3
        /// GB), 4096 (4 GB)</para></li><li><para>1024 (1 vCPU) - Available <c>memory</c> values: 2048 (2 GB), 3072 (3 GB), 4096 (4
        /// GB), 5120 (5 GB), 6144 (6 GB), 7168 (7 GB), 8192 (8 GB)</para></li><li><para>2048 (2 vCPU) - Available <c>memory</c> values: 4096 (4 GB) and 16384 (16 GB) in increments
        /// of 1024 (1 GB)</para></li><li><para>4096 (4 vCPU) - Available <c>memory</c> values: 8192 (8 GB) and 30720 (30 GB) in increments
        /// of 1024 (1 GB)</para></li><li><para>8192 (8 vCPU) - Available <c>memory</c> values: 16 GB and 60 GB in 4 GB increments</para><para>This option requires Linux platform <c>1.4.0</c> or later.</para></li><li><para>16384 (16vCPU) - Available <c>memory</c> values: 32GB and 120 GB in 8 GB increments</para><para>This option requires Linux platform <c>1.4.0</c> or later.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cpu { get; set; }
        #endregion
        
        #region Parameter RuntimePlatform_CpuArchitecture
        /// <summary>
        /// <para>
        /// <para>The CPU architecture.</para><para>You can run your Linux tasks on an ARM-based platform by setting the value to <c>ARM64</c>.
        /// This option is available for tasks that run on Linux Amazon EC2 instance or Linux
        /// containers on Fargate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.CPUArchitecture")]
        public Amazon.ECS.CPUArchitecture RuntimePlatform_CpuArchitecture { get; set; }
        #endregion
        
        #region Parameter EnableFaultInjection
        /// <summary>
        /// <para>
        /// <para>Enables fault injection when you register your task definition and allows for fault
        /// injection requests to be accepted from the task's containers. The default value is
        /// <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableFaultInjection { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution role that grants the Amazon ECS
        /// container agent permission to make Amazon Web Services API calls on your behalf. For
        /// informationabout the required IAM roles for Amazon ECS, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/security-ecs-iam-role-overview.html">IAM
        /// roles for Amazon ECS</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Family
        /// <summary>
        /// <para>
        /// <para>You must specify a <c>family</c> for a task definition. You can use it track multiple
        /// versions of the same task definition. The <c>family</c> is used as a name for your
        /// task definition. Up to 255 letters (uppercase and lowercase), numbers, underscores,
        /// and hyphens are allowed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Family { get; set; }
        #endregion
        
        #region Parameter InferenceAccelerator
        /// <summary>
        /// <para>
        /// <para>The Elastic Inference accelerators to use for the containers in the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceAccelerators")]
        public Amazon.ECS.Model.InferenceAccelerator[] InferenceAccelerator { get; set; }
        #endregion
        
        #region Parameter IpcMode
        /// <summary>
        /// <para>
        /// <para>The IPC resource namespace to use for the containers in the task. The valid values
        /// are <c>host</c>, <c>task</c>, or <c>none</c>. If <c>host</c> is specified, then all
        /// containers within the tasks that specified the <c>host</c> IPC mode on the same container
        /// instance share the same IPC resources with the host Amazon EC2 instance. If <c>task</c>
        /// is specified, all containers within the specified task share the same IPC resources.
        /// If <c>none</c> is specified, then IPC resources within the containers of a task are
        /// private and not shared with other containers in a task or on the container instance.
        /// If no value is specified, then the IPC resource namespace sharing depends on the Docker
        /// daemon setting on the container instance.</para><para>If the <c>host</c> IPC mode is used, be aware that there is a heightened risk of undesired
        /// IPC namespace expose.</para><para>If you are setting namespaced kernel parameters using <c>systemControls</c> for the
        /// containers in the task, the following will apply to your IPC resource namespace. For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_definition_parameters.html">System
        /// Controls</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><ul><li><para>For tasks that use the <c>host</c> IPC mode, IPC namespace related <c>systemControls</c>
        /// are not supported.</para></li><li><para>For tasks that use the <c>task</c> IPC mode, IPC namespace related <c>systemControls</c>
        /// will apply to all containers within a task.</para></li></ul><note><para>This parameter is not supported for Windows containers or tasks run on Fargate.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.IpcMode")]
        public Amazon.ECS.IpcMode IpcMode { get; set; }
        #endregion
        
        #region Parameter Memory
        /// <summary>
        /// <para>
        /// <para>The amount of memory (in MiB) used by the task. It can be expressed as an integer
        /// using MiB (for example ,<c>1024</c>) or as a string using GB (for example, <c>1GB</c>
        /// or <c>1 GB</c>) in a task definition. String values are converted to an integer indicating
        /// the MiB when the task definition is registered.</para><note><para>Task-level CPU and memory parameters are ignored for Windows containers. We recommend
        /// specifying container-level resources for Windows containers.</para></note><para>If using the EC2 launch type, this field is optional.</para><para>If using the Fargate launch type, this field is required and you must use one of the
        /// following values. This determines your range of supported values for the <c>cpu</c>
        /// parameter.</para><para>The CPU units cannot be less than 1 vCPU when you use Windows containers on Fargate.</para><ul><li><para>512 (0.5 GB), 1024 (1 GB), 2048 (2 GB) - Available <c>cpu</c> values: 256 (.25 vCPU)</para></li><li><para>1024 (1 GB), 2048 (2 GB), 3072 (3 GB), 4096 (4 GB) - Available <c>cpu</c> values:
        /// 512 (.5 vCPU)</para></li><li><para>2048 (2 GB), 3072 (3 GB), 4096 (4 GB), 5120 (5 GB), 6144 (6 GB), 7168 (7 GB), 8192
        /// (8 GB) - Available <c>cpu</c> values: 1024 (1 vCPU)</para></li><li><para>Between 4096 (4 GB) and 16384 (16 GB) in increments of 1024 (1 GB) - Available <c>cpu</c>
        /// values: 2048 (2 vCPU)</para></li><li><para>Between 8192 (8 GB) and 30720 (30 GB) in increments of 1024 (1 GB) - Available <c>cpu</c>
        /// values: 4096 (4 vCPU)</para></li><li><para>Between 16 GB and 60 GB in 4 GB increments - Available <c>cpu</c> values: 8192 (8
        /// vCPU)</para><para>This option requires Linux platform <c>1.4.0</c> or later.</para></li><li><para>Between 32GB and 120 GB in 8 GB increments - Available <c>cpu</c> values: 16384 (16
        /// vCPU)</para><para>This option requires Linux platform <c>1.4.0</c> or later.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Memory { get; set; }
        #endregion
        
        #region Parameter NetworkMode
        /// <summary>
        /// <para>
        /// <para>The Docker networking mode to use for the containers in the task. The valid values
        /// are <c>none</c>, <c>bridge</c>, <c>awsvpc</c>, and <c>host</c>. If no network mode
        /// is specified, the default is <c>bridge</c>.</para><para>For Amazon ECS tasks on Fargate, the <c>awsvpc</c> network mode is required. For Amazon
        /// ECS tasks on Amazon EC2 Linux instances, any network mode can be used. For Amazon
        /// ECS tasks on Amazon EC2 Windows instances, <c>&lt;default&gt;</c> or <c>awsvpc</c>
        /// can be used. If the network mode is set to <c>none</c>, you cannot specify port mappings
        /// in your container definitions, and the tasks containers do not have external connectivity.
        /// The <c>host</c> and <c>awsvpc</c> network modes offer the highest networking performance
        /// for containers because they use the EC2 network stack instead of the virtualized network
        /// stack provided by the <c>bridge</c> mode.</para><para>With the <c>host</c> and <c>awsvpc</c> network modes, exposed container ports are
        /// mapped directly to the corresponding host port (for the <c>host</c> network mode)
        /// or the attached elastic network interface port (for the <c>awsvpc</c> network mode),
        /// so you cannot take advantage of dynamic host port mappings. </para><important><para>When using the <c>host</c> network mode, you should not run containers using the root
        /// user (UID 0). It is considered best practice to use a non-root user.</para></important><para>If the network mode is <c>awsvpc</c>, the task is allocated an elastic network interface,
        /// and you must specify a <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_NetworkConfiguration.html">NetworkConfiguration</a>
        /// value when you create a service or run a task with the task definition. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking.html">Task
        /// Networking</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><para>If the network mode is <c>host</c>, you cannot run multiple instantiations of the
        /// same task on a single container instance when port mappings are used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.NetworkMode")]
        public Amazon.ECS.NetworkMode NetworkMode { get; set; }
        #endregion
        
        #region Parameter RuntimePlatform_OperatingSystemFamily
        /// <summary>
        /// <para>
        /// <para>The operating system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.OSFamily")]
        public Amazon.ECS.OSFamily RuntimePlatform_OperatingSystemFamily { get; set; }
        #endregion
        
        #region Parameter PidMode
        /// <summary>
        /// <para>
        /// <para>The process namespace to use for the containers in the task. The valid values are
        /// <c>host</c> or <c>task</c>. On Fargate for Linux containers, the only valid value
        /// is <c>task</c>. For example, monitoring sidecars might need <c>pidMode</c> to access
        /// information about other containers running in the same task.</para><para>If <c>host</c> is specified, all containers within the tasks that specified the <c>host</c>
        /// PID mode on the same container instance share the same process namespace with the
        /// host Amazon EC2 instance.</para><para>If <c>task</c> is specified, all containers within the specified task share the same
        /// process namespace.</para><para>If no value is specified, the default is a private namespace for each container.</para><para>If the <c>host</c> PID mode is used, there's a heightened risk of undesired process
        /// namespace exposure.</para><note><para>This parameter is not supported for Windows containers.</para></note><note><para>This parameter is only supported for tasks that are hosted on Fargate if the tasks
        /// are using platform version <c>1.4.0</c> or later (Linux). This isn't supported for
        /// Windows containers on Fargate.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.PidMode")]
        public Amazon.ECS.PidMode PidMode { get; set; }
        #endregion
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for the task. You can specify a maximum
        /// of 10 constraints for each task. This limit includes constraints in the task definition
        /// and those specified at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.TaskDefinitionPlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter ProxyConfiguration_Property
        /// <summary>
        /// <para>
        /// <para>The set of network configuration parameters to provide the Container Network Interface
        /// (CNI) plugin, specified as key-value pairs.</para><ul><li><para><c>IgnoredUID</c> - (Required) The user ID (UID) of the proxy container as defined
        /// by the <c>user</c> parameter in a container definition. This is used to ensure the
        /// proxy ignores its own traffic. If <c>IgnoredGID</c> is specified, this field can be
        /// empty.</para></li><li><para><c>IgnoredGID</c> - (Required) The group ID (GID) of the proxy container as defined
        /// by the <c>user</c> parameter in a container definition. This is used to ensure the
        /// proxy ignores its own traffic. If <c>IgnoredUID</c> is specified, this field can be
        /// empty.</para></li><li><para><c>AppPorts</c> - (Required) The list of ports that the application uses. Network
        /// traffic to these ports is forwarded to the <c>ProxyIngressPort</c> and <c>ProxyEgressPort</c>.</para></li><li><para><c>ProxyIngressPort</c> - (Required) Specifies the port that incoming traffic to
        /// the <c>AppPorts</c> is directed to.</para></li><li><para><c>ProxyEgressPort</c> - (Required) Specifies the port that outgoing traffic from
        /// the <c>AppPorts</c> is directed to.</para></li><li><para><c>EgressIgnoredPorts</c> - (Required) The egress traffic going to the specified
        /// ports is ignored and not redirected to the <c>ProxyEgressPort</c>. It can be an empty
        /// list.</para></li><li><para><c>EgressIgnoredIPs</c> - (Required) The egress traffic going to the specified IP
        /// addresses is ignored and not redirected to the <c>ProxyEgressPort</c>. It can be an
        /// empty list.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProxyConfiguration_Properties")]
        public Amazon.ECS.Model.KeyValuePair[] ProxyConfiguration_Property { get; set; }
        #endregion
        
        #region Parameter RequiresCompatibility
        /// <summary>
        /// <para>
        /// <para>The task launch type that Amazon ECS validates the task definition against. A client
        /// exception is returned if the task definition doesn't validate against the compatibilities
        /// specified. If no value is specified, the parameter is omitted from the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequiresCompatibilities")]
        public System.String[] RequiresCompatibility { get; set; }
        #endregion
        
        #region Parameter EphemeralStorage_SizeInGiB
        /// <summary>
        /// <para>
        /// <para>The total amount, in GiB, of ephemeral storage to set for the task. The minimum supported
        /// value is <c>21</c> GiB and the maximum supported value is <c>200</c> GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the task definition to help you categorize and organize
        /// them. Each tag consists of a key and an optional value. You define both of them.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
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
        
        #region Parameter TaskRoleArn
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the IAM role that containers
        /// in this task can assume. All containers in this task are granted the permissions that
        /// are specified in this role. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
        /// Roles for Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskRoleArn { get; set; }
        #endregion
        
        #region Parameter ProxyConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The proxy type. The only supported value is <c>APPMESH</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ProxyConfigurationType")]
        public Amazon.ECS.ProxyConfigurationType ProxyConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Volume
        /// <summary>
        /// <para>
        /// <para>A list of volume definitions in JSON format that containers in your task might use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Volumes")]
        public Amazon.ECS.Model.Volume[] Volume { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.RegisterTaskDefinitionResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.RegisterTaskDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Family), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-ECSTaskDefinition (RegisterTaskDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.RegisterTaskDefinitionResponse, RegisterECSTaskDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContainerDefinition != null)
            {
                context.ContainerDefinition = new List<Amazon.ECS.Model.ContainerDefinition>(this.ContainerDefinition);
            }
            #if MODULAR
            if (this.ContainerDefinition == null && ParameterWasBound(nameof(this.ContainerDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Cpu = this.Cpu;
            context.EnableFaultInjection = this.EnableFaultInjection;
            context.EphemeralStorage_SizeInGiB = this.EphemeralStorage_SizeInGiB;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.Family = this.Family;
            #if MODULAR
            if (this.Family == null && ParameterWasBound(nameof(this.Family)))
            {
                WriteWarning("You are passing $null as a value for parameter Family which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InferenceAccelerator != null)
            {
                context.InferenceAccelerator = new List<Amazon.ECS.Model.InferenceAccelerator>(this.InferenceAccelerator);
            }
            context.IpcMode = this.IpcMode;
            context.Memory = this.Memory;
            context.NetworkMode = this.NetworkMode;
            context.PidMode = this.PidMode;
            if (this.PlacementConstraint != null)
            {
                context.PlacementConstraint = new List<Amazon.ECS.Model.TaskDefinitionPlacementConstraint>(this.PlacementConstraint);
            }
            context.ProxyConfiguration_ContainerName = this.ProxyConfiguration_ContainerName;
            if (this.ProxyConfiguration_Property != null)
            {
                context.ProxyConfiguration_Property = new List<Amazon.ECS.Model.KeyValuePair>(this.ProxyConfiguration_Property);
            }
            context.ProxyConfiguration_Type = this.ProxyConfiguration_Type;
            if (this.RequiresCompatibility != null)
            {
                context.RequiresCompatibility = new List<System.String>(this.RequiresCompatibility);
            }
            context.RuntimePlatform_CpuArchitecture = this.RuntimePlatform_CpuArchitecture;
            context.RuntimePlatform_OperatingSystemFamily = this.RuntimePlatform_OperatingSystemFamily;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
            }
            context.TaskRoleArn = this.TaskRoleArn;
            if (this.Volume != null)
            {
                context.Volume = new List<Amazon.ECS.Model.Volume>(this.Volume);
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
            var request = new Amazon.ECS.Model.RegisterTaskDefinitionRequest();
            
            if (cmdletContext.ContainerDefinition != null)
            {
                request.ContainerDefinitions = cmdletContext.ContainerDefinition;
            }
            if (cmdletContext.Cpu != null)
            {
                request.Cpu = cmdletContext.Cpu;
            }
            if (cmdletContext.EnableFaultInjection != null)
            {
                request.EnableFaultInjection = cmdletContext.EnableFaultInjection.Value;
            }
            
             // populate EphemeralStorage
            var requestEphemeralStorageIsNull = true;
            request.EphemeralStorage = new Amazon.ECS.Model.EphemeralStorage();
            System.Int32? requestEphemeralStorage_ephemeralStorage_SizeInGiB = null;
            if (cmdletContext.EphemeralStorage_SizeInGiB != null)
            {
                requestEphemeralStorage_ephemeralStorage_SizeInGiB = cmdletContext.EphemeralStorage_SizeInGiB.Value;
            }
            if (requestEphemeralStorage_ephemeralStorage_SizeInGiB != null)
            {
                request.EphemeralStorage.SizeInGiB = requestEphemeralStorage_ephemeralStorage_SizeInGiB.Value;
                requestEphemeralStorageIsNull = false;
            }
             // determine if request.EphemeralStorage should be set to null
            if (requestEphemeralStorageIsNull)
            {
                request.EphemeralStorage = null;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.Family != null)
            {
                request.Family = cmdletContext.Family;
            }
            if (cmdletContext.InferenceAccelerator != null)
            {
                request.InferenceAccelerators = cmdletContext.InferenceAccelerator;
            }
            if (cmdletContext.IpcMode != null)
            {
                request.IpcMode = cmdletContext.IpcMode;
            }
            if (cmdletContext.Memory != null)
            {
                request.Memory = cmdletContext.Memory;
            }
            if (cmdletContext.NetworkMode != null)
            {
                request.NetworkMode = cmdletContext.NetworkMode;
            }
            if (cmdletContext.PidMode != null)
            {
                request.PidMode = cmdletContext.PidMode;
            }
            if (cmdletContext.PlacementConstraint != null)
            {
                request.PlacementConstraints = cmdletContext.PlacementConstraint;
            }
            
             // populate ProxyConfiguration
            var requestProxyConfigurationIsNull = true;
            request.ProxyConfiguration = new Amazon.ECS.Model.ProxyConfiguration();
            System.String requestProxyConfiguration_proxyConfiguration_ContainerName = null;
            if (cmdletContext.ProxyConfiguration_ContainerName != null)
            {
                requestProxyConfiguration_proxyConfiguration_ContainerName = cmdletContext.ProxyConfiguration_ContainerName;
            }
            if (requestProxyConfiguration_proxyConfiguration_ContainerName != null)
            {
                request.ProxyConfiguration.ContainerName = requestProxyConfiguration_proxyConfiguration_ContainerName;
                requestProxyConfigurationIsNull = false;
            }
            List<Amazon.ECS.Model.KeyValuePair> requestProxyConfiguration_proxyConfiguration_Property = null;
            if (cmdletContext.ProxyConfiguration_Property != null)
            {
                requestProxyConfiguration_proxyConfiguration_Property = cmdletContext.ProxyConfiguration_Property;
            }
            if (requestProxyConfiguration_proxyConfiguration_Property != null)
            {
                request.ProxyConfiguration.Properties = requestProxyConfiguration_proxyConfiguration_Property;
                requestProxyConfigurationIsNull = false;
            }
            Amazon.ECS.ProxyConfigurationType requestProxyConfiguration_proxyConfiguration_Type = null;
            if (cmdletContext.ProxyConfiguration_Type != null)
            {
                requestProxyConfiguration_proxyConfiguration_Type = cmdletContext.ProxyConfiguration_Type;
            }
            if (requestProxyConfiguration_proxyConfiguration_Type != null)
            {
                request.ProxyConfiguration.Type = requestProxyConfiguration_proxyConfiguration_Type;
                requestProxyConfigurationIsNull = false;
            }
             // determine if request.ProxyConfiguration should be set to null
            if (requestProxyConfigurationIsNull)
            {
                request.ProxyConfiguration = null;
            }
            if (cmdletContext.RequiresCompatibility != null)
            {
                request.RequiresCompatibilities = cmdletContext.RequiresCompatibility;
            }
            
             // populate RuntimePlatform
            var requestRuntimePlatformIsNull = true;
            request.RuntimePlatform = new Amazon.ECS.Model.RuntimePlatform();
            Amazon.ECS.CPUArchitecture requestRuntimePlatform_runtimePlatform_CpuArchitecture = null;
            if (cmdletContext.RuntimePlatform_CpuArchitecture != null)
            {
                requestRuntimePlatform_runtimePlatform_CpuArchitecture = cmdletContext.RuntimePlatform_CpuArchitecture;
            }
            if (requestRuntimePlatform_runtimePlatform_CpuArchitecture != null)
            {
                request.RuntimePlatform.CpuArchitecture = requestRuntimePlatform_runtimePlatform_CpuArchitecture;
                requestRuntimePlatformIsNull = false;
            }
            Amazon.ECS.OSFamily requestRuntimePlatform_runtimePlatform_OperatingSystemFamily = null;
            if (cmdletContext.RuntimePlatform_OperatingSystemFamily != null)
            {
                requestRuntimePlatform_runtimePlatform_OperatingSystemFamily = cmdletContext.RuntimePlatform_OperatingSystemFamily;
            }
            if (requestRuntimePlatform_runtimePlatform_OperatingSystemFamily != null)
            {
                request.RuntimePlatform.OperatingSystemFamily = requestRuntimePlatform_runtimePlatform_OperatingSystemFamily;
                requestRuntimePlatformIsNull = false;
            }
             // determine if request.RuntimePlatform should be set to null
            if (requestRuntimePlatformIsNull)
            {
                request.RuntimePlatform = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TaskRoleArn != null)
            {
                request.TaskRoleArn = cmdletContext.TaskRoleArn;
            }
            if (cmdletContext.Volume != null)
            {
                request.Volumes = cmdletContext.Volume;
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
        
        private Amazon.ECS.Model.RegisterTaskDefinitionResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.RegisterTaskDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "RegisterTaskDefinition");
            try
            {
                return client.RegisterTaskDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ECS.Model.ContainerDefinition> ContainerDefinition { get; set; }
            public System.String Cpu { get; set; }
            public System.Boolean? EnableFaultInjection { get; set; }
            public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String Family { get; set; }
            public List<Amazon.ECS.Model.InferenceAccelerator> InferenceAccelerator { get; set; }
            public Amazon.ECS.IpcMode IpcMode { get; set; }
            public System.String Memory { get; set; }
            public Amazon.ECS.NetworkMode NetworkMode { get; set; }
            public Amazon.ECS.PidMode PidMode { get; set; }
            public List<Amazon.ECS.Model.TaskDefinitionPlacementConstraint> PlacementConstraint { get; set; }
            public System.String ProxyConfiguration_ContainerName { get; set; }
            public List<Amazon.ECS.Model.KeyValuePair> ProxyConfiguration_Property { get; set; }
            public Amazon.ECS.ProxyConfigurationType ProxyConfiguration_Type { get; set; }
            public List<System.String> RequiresCompatibility { get; set; }
            public Amazon.ECS.CPUArchitecture RuntimePlatform_CpuArchitecture { get; set; }
            public Amazon.ECS.OSFamily RuntimePlatform_OperatingSystemFamily { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.String TaskRoleArn { get; set; }
            public List<Amazon.ECS.Model.Volume> Volume { get; set; }
            public System.Func<Amazon.ECS.Model.RegisterTaskDefinitionResponse, RegisterECSTaskDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
