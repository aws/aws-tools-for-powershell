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
    /// Starts a new task using the specified task definition.
    /// 
    ///  <note><para>
    /// On March 21, 2024, a change was made to resolve the task definition revision before
    /// authorization. When a task definition revision is not specified, authorization will
    /// occur using the latest revision of a task definition.
    /// </para></note><note><para>
    /// Amazon Elastic Inference (EI) is no longer available to customers.
    /// </para></note><para>
    /// You can allow Amazon ECS to place tasks for you, or you can customize how Amazon ECS
    /// places tasks using placement constraints and placement strategies. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/scheduling_tasks.html">Scheduling
    /// Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// Alternatively, you can use <c>StartTask</c> to use your own scheduler or place tasks
    /// manually on specific container instances.
    /// </para><para>
    /// You can attach Amazon EBS volumes to Amazon ECS tasks by configuring the volume when
    /// creating or updating a service. For more infomation, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ebs-volumes.html#ebs-volume-types">Amazon
    /// EBS volumes</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// The Amazon ECS API follows an eventual consistency model. This is because of the distributed
    /// nature of the system supporting the API. This means that the result of an API command
    /// you run that affects your Amazon ECS resources might not be immediately visible to
    /// all subsequent commands you run. Keep this in mind when you carry out an API command
    /// that immediately follows a previous API command.
    /// </para><para>
    /// To manage eventual consistency, you can do the following:
    /// </para><ul><li><para>
    /// Confirm the state of the resource before you run a command to modify it. Run the DescribeTasks
    /// command using an exponential backoff algorithm to ensure that you allow enough time
    /// for the previous command to propagate through the system. To do this, run the DescribeTasks
    /// command repeatedly, starting with a couple of seconds of wait time and increasing
    /// gradually up to five minutes of wait time.
    /// </para></li><li><para>
    /// Add wait time between subsequent commands, even if the DescribeTasks command returns
    /// an accurate response. Apply an exponential backoff algorithm starting with a couple
    /// of seconds of wait time, and increase gradually up to about five minutes of wait time.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "ECSTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.RunTaskResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service RunTask API operation.", Operation = new[] {"RunTask"}, SelectReturnType = typeof(Amazon.ECS.Model.RunTaskResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.RunTaskResponse",
        "This cmdlet returns an Amazon.ECS.Model.RunTaskResponse object containing multiple properties."
    )]
    public partial class NewECSTaskCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsvpcConfiguration_AssignPublicIp
        /// <summary>
        /// <para>
        /// <para>Whether the task's elastic network interface receives a public IP address. The default
        /// value is <c>ENABLED</c>.</para>
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
        /// <para>The capacity provider strategy to use for the task.</para><para>If a <c>capacityProviderStrategy</c> is specified, the <c>launchType</c> parameter
        /// must be omitted. If no <c>capacityProviderStrategy</c> or <c>launchType</c> is specified,
        /// the <c>defaultCapacityProviderStrategy</c> for the cluster is used.</para><para>When you use cluster auto scaling, you must specify <c>capacityProviderStrategy</c>
        /// and not <c>launchType</c>. </para><para>A capacity provider strategy can contain a maximum of 20 capacity providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.CapacityProviderStrategyItem[] CapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster to run your task
        /// on. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter Overrides_ContainerOverride
        /// <summary>
        /// <para>
        /// <para>One or more container overrides that are sent to a task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Overrides_ContainerOverrides")]
        public Amazon.ECS.Model.ContainerOverride[] Overrides_ContainerOverride { get; set; }
        #endregion
        
        #region Parameter Count
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the specified task to place on your cluster. You can
        /// specify up to 10 tasks for each call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Count { get; set; }
        #endregion
        
        #region Parameter Overrides_Cpu
        /// <summary>
        /// <para>
        /// <para>The CPU override for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Overrides_Cpu { get; set; }
        #endregion
        
        #region Parameter EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use Amazon ECS managed tags for the task. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// Your Amazon ECS Resources</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableECSManagedTags")]
        public System.Boolean? EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter EnableExecuteCommand
        /// <summary>
        /// <para>
        /// <para>Determines whether to use the execute command functionality for the containers in
        /// this task. If <c>true</c>, this enables execute command functionality on all containers
        /// in the task.</para><para>If <c>true</c>, then the task definition must have a task role, or you must provide
        /// one as an override.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableExecuteCommand { get; set; }
        #endregion
        
        #region Parameter Overrides_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution role override for the task. For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_execution_IAM_role.html">Amazon
        /// ECS task execution IAM role</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Overrides_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The name of the task group to associate with the task. The default value is the family
        /// name of the task definition (for example, <c>family:my-family-name</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Group { get; set; }
        #endregion
        
        #region Parameter Overrides_InferenceAcceleratorOverride
        /// <summary>
        /// <para>
        /// <para>The Elastic Inference accelerator override for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Overrides_InferenceAcceleratorOverrides")]
        public Amazon.ECS.Model.InferenceAcceleratorOverride[] Overrides_InferenceAcceleratorOverride { get; set; }
        #endregion
        
        #region Parameter LaunchType
        /// <summary>
        /// <para>
        /// <para>The infrastructure to run your standalone task on. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_types.html">Amazon
        /// ECS launch types</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><para>The <c>FARGATE</c> launch type runs your tasks on Fargate On-Demand infrastructure.</para><note><para>Fargate Spot infrastructure is available for use but a capacity provider strategy
        /// must be used. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/fargate-capacity-providers.html">Fargate
        /// capacity providers</a> in the <i>Amazon ECS Developer Guide</i>.</para></note><para>The <c>EC2</c> launch type runs your tasks on Amazon EC2 instances registered to your
        /// cluster.</para><para>The <c>EXTERNAL</c> launch type runs your tasks on your on-premises server or virtual
        /// machine (VM) capacity registered to your cluster.</para><para>A task can use either a launch type or a capacity provider strategy. If a <c>launchType</c>
        /// is specified, the <c>capacityProviderStrategy</c> parameter must be omitted.</para><para>When you use cluster auto scaling, you must specify <c>capacityProviderStrategy</c>
        /// and not <c>launchType</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.LaunchType")]
        public Amazon.ECS.LaunchType LaunchType { get; set; }
        #endregion
        
        #region Parameter Overrides_Memory
        /// <summary>
        /// <para>
        /// <para>The memory override for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Overrides_Memory { get; set; }
        #endregion
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for the task. You can specify up to
        /// 10 constraints for each task (including constraints in the task definition and those
        /// specified at runtime).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.PlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The placement strategy objects to use for the task. You can specify a maximum of 5
        /// strategy rules for each task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.PlacementStrategy[] PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version the task uses. A platform version is only specified for tasks
        /// hosted on Fargate. If one isn't specified, the <c>LATEST</c> platform version is used.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">Fargate
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
        /// task during task creation. To add tags to a task after task creation, use the<a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_TagResource.html">TagResource</a>
        /// API action.</para><note><para>An error will be received if you specify the <c>SERVICE</c> option when running a
        /// task.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateTags")]
        public Amazon.ECS.PropagateTags PropagateTag { get; set; }
        #endregion
        
        #region Parameter ReferenceId
        /// <summary>
        /// <para>
        /// <para>This parameter is only used by Amazon ECS. It is not intended for use by customers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReferenceId { get; set; }
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
        
        #region Parameter EphemeralStorage_SizeInGiB
        /// <summary>
        /// <para>
        /// <para>The total amount, in GiB, of ephemeral storage to set for the task. The minimum supported
        /// value is <c>21</c> GiB and the maximum supported value is <c>200</c> GiB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Overrides_EphemeralStorage_SizeInGiB")]
        public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
        #endregion
        
        #region Parameter StartedBy
        /// <summary>
        /// <para>
        /// <para>An optional tag specified when a task is started. For example, if you automatically
        /// trigger a task to run a batch process job, you could apply a unique identifier for
        /// that job to your task with the <c>startedBy</c> parameter. You can then identify which
        /// tasks belong to that job by filtering the results of a <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_ListTasks.html">ListTasks</a>
        /// call with the <c>startedBy</c> value. Up to 128 letters (uppercase and lowercase),
        /// numbers, hyphens (-), forward slash (/), and underscores (_) are allowed.</para><para>If a task is started by an Amazon ECS service, then the <c>startedBy</c> parameter
        /// contains the deployment ID of the service that starts it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartedBy { get; set; }
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
        /// <para>The metadata that you apply to the task to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
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
        /// task definition to run. If a <c>revision</c> isn't specified, the latest <c>ACTIVE</c>
        /// revision is used.</para><para>The full ARN value must match the value that you specified as the <c>Resource</c>
        /// of the principal's permissions policy.</para><para>When you specify a task definition, you must either specify a specific revision, or
        /// all revisions in the ARN.</para><para>To specify a specific revision, include the revision number in the ARN. For example,
        /// to specify revision 2, use <c>arn:aws:ecs:us-east-1:111122223333:task-definition/TaskFamilyName:2</c>.</para><para>To specify all revisions, use the wildcard (*) in the ARN. For example, to specify
        /// all revisions, use <c>arn:aws:ecs:us-east-1:111122223333:task-definition/TaskFamilyName:*</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/security_iam_service-with-iam.html#security_iam_service-with-iam-id-based-policies-resources">Policy
        /// Resources for Amazon ECS</a> in the Amazon Elastic Container Service Developer Guide.</para>
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
        public System.String TaskDefinition { get; set; }
        #endregion
        
        #region Parameter Overrides_TaskRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role that containers in this task can assume.
        /// All containers in this task are granted the permissions that are specified in this
        /// role. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
        /// Role for Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Overrides_TaskRoleArn { get; set; }
        #endregion
        
        #region Parameter VolumeConfiguration
        /// <summary>
        /// <para>
        /// <para>The details of the volume that was <c>configuredAtLaunch</c>. You can configure the
        /// size, volumeType, IOPS, throughput, snapshot and encryption in in <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_TaskManagedEBSVolumeConfiguration.html">TaskManagedEBSVolumeConfiguration</a>.
        /// The <c>name</c> of the volume must match the <c>name</c> from the task definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VolumeConfigurations")]
        public Amazon.ECS.Model.TaskVolumeConfiguration[] VolumeConfiguration { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An identifier that you provide to ensure the idempotency of the request. It must be
        /// unique and is case sensitive. Up to 64 characters are allowed. The valid characters
        /// are characters in the range of 33-126, inclusive. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/ECS_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.RunTaskResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.RunTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Cluster), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSTask (RunTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.RunTaskResponse, NewECSTaskCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.Cluster = this.Cluster;
            context.Count = this.Count;
            context.EnableECSManagedTag = this.EnableECSManagedTag;
            context.EnableExecuteCommand = this.EnableExecuteCommand;
            context.Group = this.Group;
            context.LaunchType = this.LaunchType;
            context.AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.AwsvpcConfiguration_SecurityGroup = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.AwsvpcConfiguration_Subnet = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            if (this.Overrides_ContainerOverride != null)
            {
                context.Overrides_ContainerOverride = new List<Amazon.ECS.Model.ContainerOverride>(this.Overrides_ContainerOverride);
            }
            context.Overrides_Cpu = this.Overrides_Cpu;
            context.EphemeralStorage_SizeInGiB = this.EphemeralStorage_SizeInGiB;
            context.Overrides_ExecutionRoleArn = this.Overrides_ExecutionRoleArn;
            if (this.Overrides_InferenceAcceleratorOverride != null)
            {
                context.Overrides_InferenceAcceleratorOverride = new List<Amazon.ECS.Model.InferenceAcceleratorOverride>(this.Overrides_InferenceAcceleratorOverride);
            }
            context.Overrides_Memory = this.Overrides_Memory;
            context.Overrides_TaskRoleArn = this.Overrides_TaskRoleArn;
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
            context.ReferenceId = this.ReferenceId;
            context.StartedBy = this.StartedBy;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
            }
            context.TaskDefinition = this.TaskDefinition;
            #if MODULAR
            if (this.TaskDefinition == null && ParameterWasBound(nameof(this.TaskDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VolumeConfiguration != null)
            {
                context.VolumeConfiguration = new List<Amazon.ECS.Model.TaskVolumeConfiguration>(this.VolumeConfiguration);
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
            var request = new Amazon.ECS.Model.RunTaskRequest();
            
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
            if (cmdletContext.Count != null)
            {
                request.Count = cmdletContext.Count.Value;
            }
            if (cmdletContext.EnableECSManagedTag != null)
            {
                request.EnableECSManagedTags = cmdletContext.EnableECSManagedTag.Value;
            }
            if (cmdletContext.EnableExecuteCommand != null)
            {
                request.EnableExecuteCommand = cmdletContext.EnableExecuteCommand.Value;
            }
            if (cmdletContext.Group != null)
            {
                request.Group = cmdletContext.Group;
            }
            if (cmdletContext.LaunchType != null)
            {
                request.LaunchType = cmdletContext.LaunchType;
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
            
             // populate Overrides
            var requestOverridesIsNull = true;
            request.Overrides = new Amazon.ECS.Model.TaskOverride();
            List<Amazon.ECS.Model.ContainerOverride> requestOverrides_overrides_ContainerOverride = null;
            if (cmdletContext.Overrides_ContainerOverride != null)
            {
                requestOverrides_overrides_ContainerOverride = cmdletContext.Overrides_ContainerOverride;
            }
            if (requestOverrides_overrides_ContainerOverride != null)
            {
                request.Overrides.ContainerOverrides = requestOverrides_overrides_ContainerOverride;
                requestOverridesIsNull = false;
            }
            System.String requestOverrides_overrides_Cpu = null;
            if (cmdletContext.Overrides_Cpu != null)
            {
                requestOverrides_overrides_Cpu = cmdletContext.Overrides_Cpu;
            }
            if (requestOverrides_overrides_Cpu != null)
            {
                request.Overrides.Cpu = requestOverrides_overrides_Cpu;
                requestOverridesIsNull = false;
            }
            System.String requestOverrides_overrides_ExecutionRoleArn = null;
            if (cmdletContext.Overrides_ExecutionRoleArn != null)
            {
                requestOverrides_overrides_ExecutionRoleArn = cmdletContext.Overrides_ExecutionRoleArn;
            }
            if (requestOverrides_overrides_ExecutionRoleArn != null)
            {
                request.Overrides.ExecutionRoleArn = requestOverrides_overrides_ExecutionRoleArn;
                requestOverridesIsNull = false;
            }
            List<Amazon.ECS.Model.InferenceAcceleratorOverride> requestOverrides_overrides_InferenceAcceleratorOverride = null;
            if (cmdletContext.Overrides_InferenceAcceleratorOverride != null)
            {
                requestOverrides_overrides_InferenceAcceleratorOverride = cmdletContext.Overrides_InferenceAcceleratorOverride;
            }
            if (requestOverrides_overrides_InferenceAcceleratorOverride != null)
            {
                request.Overrides.InferenceAcceleratorOverrides = requestOverrides_overrides_InferenceAcceleratorOverride;
                requestOverridesIsNull = false;
            }
            System.String requestOverrides_overrides_Memory = null;
            if (cmdletContext.Overrides_Memory != null)
            {
                requestOverrides_overrides_Memory = cmdletContext.Overrides_Memory;
            }
            if (requestOverrides_overrides_Memory != null)
            {
                request.Overrides.Memory = requestOverrides_overrides_Memory;
                requestOverridesIsNull = false;
            }
            System.String requestOverrides_overrides_TaskRoleArn = null;
            if (cmdletContext.Overrides_TaskRoleArn != null)
            {
                requestOverrides_overrides_TaskRoleArn = cmdletContext.Overrides_TaskRoleArn;
            }
            if (requestOverrides_overrides_TaskRoleArn != null)
            {
                request.Overrides.TaskRoleArn = requestOverrides_overrides_TaskRoleArn;
                requestOverridesIsNull = false;
            }
            Amazon.ECS.Model.EphemeralStorage requestOverrides_overrides_EphemeralStorage = null;
            
             // populate EphemeralStorage
            var requestOverrides_overrides_EphemeralStorageIsNull = true;
            requestOverrides_overrides_EphemeralStorage = new Amazon.ECS.Model.EphemeralStorage();
            System.Int32? requestOverrides_overrides_EphemeralStorage_ephemeralStorage_SizeInGiB = null;
            if (cmdletContext.EphemeralStorage_SizeInGiB != null)
            {
                requestOverrides_overrides_EphemeralStorage_ephemeralStorage_SizeInGiB = cmdletContext.EphemeralStorage_SizeInGiB.Value;
            }
            if (requestOverrides_overrides_EphemeralStorage_ephemeralStorage_SizeInGiB != null)
            {
                requestOverrides_overrides_EphemeralStorage.SizeInGiB = requestOverrides_overrides_EphemeralStorage_ephemeralStorage_SizeInGiB.Value;
                requestOverrides_overrides_EphemeralStorageIsNull = false;
            }
             // determine if requestOverrides_overrides_EphemeralStorage should be set to null
            if (requestOverrides_overrides_EphemeralStorageIsNull)
            {
                requestOverrides_overrides_EphemeralStorage = null;
            }
            if (requestOverrides_overrides_EphemeralStorage != null)
            {
                request.Overrides.EphemeralStorage = requestOverrides_overrides_EphemeralStorage;
                requestOverridesIsNull = false;
            }
             // determine if request.Overrides should be set to null
            if (requestOverridesIsNull)
            {
                request.Overrides = null;
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
            if (cmdletContext.ReferenceId != null)
            {
                request.ReferenceId = cmdletContext.ReferenceId;
            }
            if (cmdletContext.StartedBy != null)
            {
                request.StartedBy = cmdletContext.StartedBy;
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
        
        private Amazon.ECS.Model.RunTaskResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.RunTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "RunTask");
            try
            {
                #if DESKTOP
                return client.RunTask(request);
                #elif CORECLR
                return client.RunTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Cluster { get; set; }
            public System.Int32? Count { get; set; }
            public System.Boolean? EnableECSManagedTag { get; set; }
            public System.Boolean? EnableExecuteCommand { get; set; }
            public System.String Group { get; set; }
            public Amazon.ECS.LaunchType LaunchType { get; set; }
            public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> AwsvpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> AwsvpcConfiguration_Subnet { get; set; }
            public List<Amazon.ECS.Model.ContainerOverride> Overrides_ContainerOverride { get; set; }
            public System.String Overrides_Cpu { get; set; }
            public System.Int32? EphemeralStorage_SizeInGiB { get; set; }
            public System.String Overrides_ExecutionRoleArn { get; set; }
            public List<Amazon.ECS.Model.InferenceAcceleratorOverride> Overrides_InferenceAcceleratorOverride { get; set; }
            public System.String Overrides_Memory { get; set; }
            public System.String Overrides_TaskRoleArn { get; set; }
            public List<Amazon.ECS.Model.PlacementConstraint> PlacementConstraint { get; set; }
            public List<Amazon.ECS.Model.PlacementStrategy> PlacementStrategy { get; set; }
            public System.String PlatformVersion { get; set; }
            public Amazon.ECS.PropagateTags PropagateTag { get; set; }
            public System.String ReferenceId { get; set; }
            public System.String StartedBy { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.String TaskDefinition { get; set; }
            public List<Amazon.ECS.Model.TaskVolumeConfiguration> VolumeConfiguration { get; set; }
            public System.Func<Amazon.ECS.Model.RunTaskResponse, NewECSTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
