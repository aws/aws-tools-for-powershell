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
    /// Registers a new task definition from the supplied <code>family</code> and <code>containerDefinitions</code>.
    /// Optionally, you can add data volumes to your containers with the <code>volumes</code>
    /// parameter. For more information about task definition parameters and defaults, see
    /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_defintions.html">Amazon
    /// ECS Task Definitions</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can specify an IAM role for your task with the <code>taskRoleArn</code> parameter.
    /// When you specify an IAM role for a task, its containers can then use the latest versions
    /// of the AWS CLI or SDKs to make API requests to the AWS services that are specified
    /// in the IAM policy associated with the role. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
    /// Roles for Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// You can specify a Docker networking mode for the containers in your task definition
    /// with the <code>networkMode</code> parameter. The available network modes correspond
    /// to those described in <a href="https://docs.docker.com/engine/reference/run/#/network-settings">Network
    /// settings</a> in the Docker run reference. If you specify the <code>awsvpc</code> network
    /// mode, the task is allocated an elastic network interface, and you must specify a <a>NetworkConfiguration</a>
    /// when you create a service or run a task with the task definition. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking.html">Task
    /// Networking</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "ECSTaskDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.RegisterTaskDefinitionResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service RegisterTaskDefinition API operation.", Operation = new[] {"RegisterTaskDefinition"}, SelectReturnType = typeof(Amazon.ECS.Model.RegisterTaskDefinitionResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.RegisterTaskDefinitionResponse",
        "This cmdlet returns an Amazon.ECS.Model.RegisterTaskDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterECSTaskDefinitionCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
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
        /// CPU units, for example <code>1024</code>, or as a string using vCPUs, for example
        /// <code>1 vCPU</code> or <code>1 vcpu</code>, in a task definition. String values are
        /// converted to an integer indicating the CPU units when the task definition is registered.</para><note><para>Task-level CPU and memory parameters are ignored for Windows containers. We recommend
        /// specifying container-level resources for Windows containers.</para></note><para>If you are using the EC2 launch type, this field is optional. Supported values are
        /// between <code>128</code> CPU units (<code>0.125</code> vCPUs) and <code>10240</code>
        /// CPU units (<code>10</code> vCPUs).</para><para>If you are using the Fargate launch type, this field is required and you must use
        /// one of the following values, which determines your range of supported values for the
        /// <code>memory</code> parameter:</para><ul><li><para>256 (.25 vCPU) - Available <code>memory</code> values: 512 (0.5 GB), 1024 (1 GB),
        /// 2048 (2 GB)</para></li><li><para>512 (.5 vCPU) - Available <code>memory</code> values: 1024 (1 GB), 2048 (2 GB), 3072
        /// (3 GB), 4096 (4 GB)</para></li><li><para>1024 (1 vCPU) - Available <code>memory</code> values: 2048 (2 GB), 3072 (3 GB), 4096
        /// (4 GB), 5120 (5 GB), 6144 (6 GB), 7168 (7 GB), 8192 (8 GB)</para></li><li><para>2048 (2 vCPU) - Available <code>memory</code> values: Between 4096 (4 GB) and 16384
        /// (16 GB) in increments of 1024 (1 GB)</para></li><li><para>4096 (4 vCPU) - Available <code>memory</code> values: Between 8192 (8 GB) and 30720
        /// (30 GB) in increments of 1024 (1 GB)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cpu { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution role that the Amazon ECS container
        /// agent and the Docker daemon can assume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Family
        /// <summary>
        /// <para>
        /// <para>You must specify a <code>family</code> for a task definition, which allows you to
        /// track multiple versions of the same task definition. The <code>family</code> is used
        /// as a name for your task definition. Up to 255 letters (uppercase and lowercase), numbers,
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
        /// are <code>host</code>, <code>task</code>, or <code>none</code>. If <code>host</code>
        /// is specified, then all containers within the tasks that specified the <code>host</code>
        /// IPC mode on the same container instance share the same IPC resources with the host
        /// Amazon EC2 instance. If <code>task</code> is specified, all containers within the
        /// specified task share the same IPC resources. If <code>none</code> is specified, then
        /// IPC resources within the containers of a task are private and not shared with other
        /// containers in a task or on the container instance. If no value is specified, then
        /// the IPC resource namespace sharing depends on the Docker daemon setting on the container
        /// instance. For more information, see <a href="https://docs.docker.com/engine/reference/run/#ipc-settings---ipc">IPC
        /// settings</a> in the <i>Docker run reference</i>.</para><para>If the <code>host</code> IPC mode is used, be aware that there is a heightened risk
        /// of undesired IPC namespace expose. For more information, see <a href="https://docs.docker.com/engine/security/security/">Docker
        /// security</a>.</para><para>If you are setting namespaced kernel parameters using <code>systemControls</code>
        /// for the containers in the task, the following will apply to your IPC resource namespace.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_definition_parameters.html">System
        /// Controls</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><ul><li><para>For tasks that use the <code>host</code> IPC mode, IPC namespace related <code>systemControls</code>
        /// are not supported.</para></li><li><para>For tasks that use the <code>task</code> IPC mode, IPC namespace related <code>systemControls</code>
        /// will apply to all containers within a task.</para></li></ul><note><para>This parameter is not supported for Windows containers or tasks using the Fargate
        /// launch type.</para></note>
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
        /// using MiB, for example <code>1024</code>, or as a string using GB, for example <code>1GB</code>
        /// or <code>1 GB</code>, in a task definition. String values are converted to an integer
        /// indicating the MiB when the task definition is registered.</para><note><para>Task-level CPU and memory parameters are ignored for Windows containers. We recommend
        /// specifying container-level resources for Windows containers.</para></note><para>If using the EC2 launch type, this field is optional.</para><para>If using the Fargate launch type, this field is required and you must use one of the
        /// following values, which determines your range of supported values for the <code>cpu</code>
        /// parameter:</para><ul><li><para>512 (0.5 GB), 1024 (1 GB), 2048 (2 GB) - Available <code>cpu</code> values: 256 (.25
        /// vCPU)</para></li><li><para>1024 (1 GB), 2048 (2 GB), 3072 (3 GB), 4096 (4 GB) - Available <code>cpu</code> values:
        /// 512 (.5 vCPU)</para></li><li><para>2048 (2 GB), 3072 (3 GB), 4096 (4 GB), 5120 (5 GB), 6144 (6 GB), 7168 (7 GB), 8192
        /// (8 GB) - Available <code>cpu</code> values: 1024 (1 vCPU)</para></li><li><para>Between 4096 (4 GB) and 16384 (16 GB) in increments of 1024 (1 GB) - Available <code>cpu</code>
        /// values: 2048 (2 vCPU)</para></li><li><para>Between 8192 (8 GB) and 30720 (30 GB) in increments of 1024 (1 GB) - Available <code>cpu</code>
        /// values: 4096 (4 vCPU)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Memory { get; set; }
        #endregion
        
        #region Parameter NetworkMode
        /// <summary>
        /// <para>
        /// <para>The Docker networking mode to use for the containers in the task. The valid values
        /// are <code>none</code>, <code>bridge</code>, <code>awsvpc</code>, and <code>host</code>.
        /// The default Docker network mode is <code>bridge</code>. If you are using the Fargate
        /// launch type, the <code>awsvpc</code> network mode is required. If you are using the
        /// EC2 launch type, any network mode can be used. If the network mode is set to <code>none</code>,
        /// you cannot specify port mappings in your container definitions, and the tasks containers
        /// do not have external connectivity. The <code>host</code> and <code>awsvpc</code> network
        /// modes offer the highest networking performance for containers because they use the
        /// EC2 network stack instead of the virtualized network stack provided by the <code>bridge</code>
        /// mode.</para><para>With the <code>host</code> and <code>awsvpc</code> network modes, exposed container
        /// ports are mapped directly to the corresponding host port (for the <code>host</code>
        /// network mode) or the attached elastic network interface port (for the <code>awsvpc</code>
        /// network mode), so you cannot take advantage of dynamic host port mappings. </para><para>If the network mode is <code>awsvpc</code>, the task is allocated an elastic network
        /// interface, and you must specify a <a>NetworkConfiguration</a> value when you create
        /// a service or run a task with the task definition. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking.html">Task
        /// Networking</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><note><para>Currently, only Amazon ECS-optimized AMIs, other Amazon Linux variants with the <code>ecs-init</code>
        /// package, or AWS Fargate infrastructure support the <code>awsvpc</code> network mode.
        /// </para></note><para>If the network mode is <code>host</code>, you cannot run multiple instantiations of
        /// the same task on a single container instance when port mappings are used.</para><para>Docker for Windows uses different network modes than Docker for Linux. When you register
        /// a task definition with Windows containers, you must not specify a network mode. If
        /// you use the console to register a task definition with Windows containers, you must
        /// choose the <code>&lt;default&gt;</code> network mode object. </para><para>For more information, see <a href="https://docs.docker.com/engine/reference/run/#network-settings">Network
        /// settings</a> in the <i>Docker run reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.NetworkMode")]
        public Amazon.ECS.NetworkMode NetworkMode { get; set; }
        #endregion
        
        #region Parameter PidMode
        /// <summary>
        /// <para>
        /// <para>The process namespace to use for the containers in the task. The valid values are
        /// <code>host</code> or <code>task</code>. If <code>host</code> is specified, then all
        /// containers within the tasks that specified the <code>host</code> PID mode on the same
        /// container instance share the same process namespace with the host Amazon EC2 instance.
        /// If <code>task</code> is specified, all containers within the specified task share
        /// the same process namespace. If no value is specified, the default is a private namespace.
        /// For more information, see <a href="https://docs.docker.com/engine/reference/run/#pid-settings---pid">PID
        /// settings</a> in the <i>Docker run reference</i>.</para><para>If the <code>host</code> PID mode is used, be aware that there is a heightened risk
        /// of undesired process namespace expose. For more information, see <a href="https://docs.docker.com/engine/security/security/">Docker
        /// security</a>.</para><note><para>This parameter is not supported for Windows containers or tasks using the Fargate
        /// launch type.</para></note>
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
        /// of 10 constraints per task (this limit includes constraints in the task definition
        /// and those specified at runtime).</para>
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
        /// (CNI) plugin, specified as key-value pairs.</para><ul><li><para><code>IgnoredUID</code> - (Required) The user ID (UID) of the proxy container as
        /// defined by the <code>user</code> parameter in a container definition. This is used
        /// to ensure the proxy ignores its own traffic. If <code>IgnoredGID</code> is specified,
        /// this field can be empty.</para></li><li><para><code>IgnoredGID</code> - (Required) The group ID (GID) of the proxy container as
        /// defined by the <code>user</code> parameter in a container definition. This is used
        /// to ensure the proxy ignores its own traffic. If <code>IgnoredUID</code> is specified,
        /// this field can be empty.</para></li><li><para><code>AppPorts</code> - (Required) The list of ports that the application uses. Network
        /// traffic to these ports is forwarded to the <code>ProxyIngressPort</code> and <code>ProxyEgressPort</code>.</para></li><li><para><code>ProxyIngressPort</code> - (Required) Specifies the port that incoming traffic
        /// to the <code>AppPorts</code> is directed to.</para></li><li><para><code>ProxyEgressPort</code> - (Required) Specifies the port that outgoing traffic
        /// from the <code>AppPorts</code> is directed to.</para></li><li><para><code>EgressIgnoredPorts</code> - (Required) The egress traffic going to the specified
        /// ports is ignored and not redirected to the <code>ProxyEgressPort</code>. It can be
        /// an empty list.</para></li><li><para><code>EgressIgnoredIPs</code> - (Required) The egress traffic going to the specified
        /// IP addresses is ignored and not redirected to the <code>ProxyEgressPort</code>. It
        /// can be an empty list.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProxyConfiguration_Properties")]
        public Amazon.ECS.Model.KeyValuePair[] ProxyConfiguration_Property { get; set; }
        #endregion
        
        #region Parameter RequiresCompatibility
        /// <summary>
        /// <para>
        /// <para>The launch type required by the task. If no value is specified, it defaults to <code>EC2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequiresCompatibilities")]
        public System.String[] RequiresCompatibility { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the task definition to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case-sensitive.</para></li><li><para>Do not use <code>aws:</code>, <code>AWS:</code>, or any upper or lowercase combination
        /// of such as a prefix for either keys or values as it is reserved for AWS use. You cannot
        /// edit or delete tag keys or values with this prefix. Tags with this prefix do not count
        /// against your tags per resource limit.</para></li></ul>
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
        /// <para>The proxy type. The only supported value is <code>APPMESH</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.ProxyConfigurationType")]
        public Amazon.ECS.ProxyConfigurationType ProxyConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Volume
        /// <summary>
        /// <para>
        /// <para>A list of volume definitions in JSON format that containers in your task may use.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Family parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Family' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Family' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Family), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-ECSTaskDefinition (RegisterTaskDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.RegisterTaskDefinitionResponse, RegisterECSTaskDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Family;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.RegisterTaskDefinition(request);
                #elif CORECLR
                return client.RegisterTaskDefinitionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ECS.Model.ContainerDefinition> ContainerDefinition { get; set; }
            public System.String Cpu { get; set; }
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
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.String TaskRoleArn { get; set; }
            public List<Amazon.ECS.Model.Volume> Volume { get; set; }
            public System.Func<Amazon.ECS.Model.RegisterTaskDefinitionResponse, RegisterECSTaskDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
