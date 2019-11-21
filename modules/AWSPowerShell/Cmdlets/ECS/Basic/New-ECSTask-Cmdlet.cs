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
    /// Starts a new task using the specified task definition.
    /// 
    ///  
    /// <para>
    /// You can allow Amazon ECS to place tasks for you, or you can customize how Amazon ECS
    /// places tasks using placement constraints and placement strategies. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/scheduling_tasks.html">Scheduling
    /// Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// Alternatively, you can use <a>StartTask</a> to use your own scheduler or place tasks
    /// manually on specific container instances.
    /// </para><para>
    /// The Amazon ECS API follows an eventual consistency model, due to the distributed nature
    /// of the system supporting the API. This means that the result of an API command you
    /// run that affects your Amazon ECS resources might not be immediately visible to all
    /// subsequent commands you run. Keep this in mind when you carry out an API command that
    /// immediately follows a previous API command.
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
        "This cmdlet returns an Amazon.ECS.Model.RunTaskResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECSTaskCmdlet : AmazonECSClientCmdlet, IExecutor
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
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster on which to run your
        /// task. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter Overrides_ContainerOverride
        /// <summary>
        /// <para>
        /// <para>One or more container overrides sent to a task.</para>
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
        /// specify up to 10 tasks per call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Count { get; set; }
        #endregion
        
        #region Parameter EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable Amazon ECS managed tags for the task. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// Your Amazon ECS Resources</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableECSManagedTags")]
        public System.Boolean? EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter Overrides_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution role that the Amazon ECS container
        /// agent and the Docker daemon can assume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Overrides_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The name of the task group to associate with the task. The default value is the family
        /// name of the task definition (for example, family:my-family-name).</para>
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
        /// <para>The launch type on which to run your task. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_types.html">Amazon
        /// ECS Launch Types</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ECS.LaunchType")]
        public Amazon.ECS.LaunchType LaunchType { get; set; }
        #endregion
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of placement constraint objects to use for the task. You can specify up to
        /// 10 constraints per task (including constraints in the task definition and those specified
        /// at runtime).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.PlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The placement strategy objects to use for the task. You can specify a maximum of five
        /// strategy rules per task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.PlacementStrategy[] PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version the task should run. A platform version is only specified for
        /// tasks using the Fargate launch type. If one is not specified, the <code>LATEST</code>
        /// platform version is used by default. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">AWS
        /// Fargate Platform Versions</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the task definition to the task. If no
        /// value is specified, the tags are not propagated. Tags can only be propagated to the
        /// task during task creation. To add tags to a task after task creation, use the <a>TagResource</a>
        /// API action.</para><note><para>An error will be received if you specify the <code>SERVICE</code> option when running
        /// a task.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateTags")]
        public Amazon.ECS.PropagateTags PropagateTag { get; set; }
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
        
        #region Parameter StartedBy
        /// <summary>
        /// <para>
        /// <para>An optional tag specified when a task is started. For example, if you automatically
        /// trigger a task to run a batch process job, you could apply a unique identifier for
        /// that job to your task with the <code>startedBy</code> parameter. You can then identify
        /// which tasks belong to that job by filtering the results of a <a>ListTasks</a> call
        /// with the <code>startedBy</code> value. Up to 36 letters (uppercase and lowercase),
        /// numbers, hyphens, and underscores are allowed.</para><para>If a task is started by an Amazon ECS service, then the <code>startedBy</code> parameter
        /// contains the deployment ID of the service that starts it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartedBy { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the task to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
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
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> and <code>revision</code> (<code>family:revision</code>) or
        /// full ARN of the task definition to run. If a <code>revision</code> is not specified,
        /// the latest <code>ACTIVE</code> revision is used.</para>
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
        /// <para>The Amazon Resource Name (ARN) of the IAM role that containers in this task can assume.
        /// All containers in this task are granted the permissions that are specified in this
        /// role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Overrides_TaskRoleArn { get; set; }
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
            context.Cluster = this.Cluster;
            context.Count = this.Count;
            context.EnableECSManagedTag = this.EnableECSManagedTag;
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
            context.Overrides_ExecutionRoleArn = this.Overrides_ExecutionRoleArn;
            if (this.Overrides_InferenceAcceleratorOverride != null)
            {
                context.Overrides_InferenceAcceleratorOverride = new List<Amazon.ECS.Model.InferenceAcceleratorOverride>(this.Overrides_InferenceAcceleratorOverride);
            }
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
            public System.String Cluster { get; set; }
            public System.Int32? Count { get; set; }
            public System.Boolean? EnableECSManagedTag { get; set; }
            public System.String Group { get; set; }
            public Amazon.ECS.LaunchType LaunchType { get; set; }
            public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> AwsvpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> AwsvpcConfiguration_Subnet { get; set; }
            public List<Amazon.ECS.Model.ContainerOverride> Overrides_ContainerOverride { get; set; }
            public System.String Overrides_ExecutionRoleArn { get; set; }
            public List<Amazon.ECS.Model.InferenceAcceleratorOverride> Overrides_InferenceAcceleratorOverride { get; set; }
            public System.String Overrides_TaskRoleArn { get; set; }
            public List<Amazon.ECS.Model.PlacementConstraint> PlacementConstraint { get; set; }
            public List<Amazon.ECS.Model.PlacementStrategy> PlacementStrategy { get; set; }
            public System.String PlatformVersion { get; set; }
            public Amazon.ECS.PropagateTags PropagateTag { get; set; }
            public System.String StartedBy { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.String TaskDefinition { get; set; }
            public System.Func<Amazon.ECS.Model.RunTaskResponse, NewECSTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
