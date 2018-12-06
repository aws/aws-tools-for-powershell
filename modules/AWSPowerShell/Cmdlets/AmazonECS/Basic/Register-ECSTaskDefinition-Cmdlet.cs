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
    /// Registers a new task definition from the supplied <code>family</code> and <code>containerDefinitions</code>.
    /// Optionally, you can add data volumes to your containers with the <code>volumes</code>
    /// parameter. For more information about task definition parameters and defaults, see
    /// <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_defintions.html">Amazon
    /// ECS Task Definitions</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can specify an IAM role for your task with the <code>taskRoleArn</code> parameter.
    /// When you specify an IAM role for a task, its containers can then use the latest versions
    /// of the AWS CLI or SDKs to make API requests to the AWS services that are specified
    /// in the IAM policy associated with the role. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
    /// Roles for Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para><para>
    /// You can specify a Docker networking mode for the containers in your task definition
    /// with the <code>networkMode</code> parameter. The available network modes correspond
    /// to those described in <a href="https://docs.docker.com/engine/reference/run/#/network-settings">Network
    /// settings</a> in the Docker run reference. If you specify the <code>awsvpc</code> network
    /// mode, the task is allocated an elastic network interface, and you must specify a <a>NetworkConfiguration</a>
    /// when you create a service or run a task with the task definition. For more information,
    /// see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking.html">Task
    /// Networking</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "ECSTaskDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.RegisterTaskDefinitionResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service RegisterTaskDefinition API operation.", Operation = new[] {"RegisterTaskDefinition"})]
    [AWSCmdletOutput("Amazon.ECS.Model.RegisterTaskDefinitionResponse",
        "This cmdlet returns a Amazon.ECS.Model.RegisterTaskDefinitionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        [System.Management.Automation.Parameter]
        [Alias("ContainerDefinitions")]
        public Amazon.ECS.Model.ContainerDefinition[] ContainerDefinition { get; set; }
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
        [System.Management.Automation.Parameter]
        public System.String Cpu { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution role that the Amazon ECS container
        /// agent and the Docker daemon can assume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Family
        /// <summary>
        /// <para>
        /// <para>You must specify a <code>family</code> for a task definition, which allows you to
        /// track multiple versions of the same task definition. The <code>family</code> is used
        /// as a name for your task definition. Up to 255 letters (uppercase and lowercase), numbers,
        /// hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Family { get; set; }
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
        /// For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_definition_parameters.html">System
        /// Controls</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><ul><li><para>For tasks that use the <code>host</code> IPC mode, IPC namespace related <code>systemControls</code>
        /// are not supported.</para></li><li><para>For tasks that use the <code>task</code> IPC mode, IPC namespace related <code>systemControls</code>
        /// will apply to all containers within a task.</para></li></ul><note><para>This parameter is not supported for Windows containers or tasks using the Fargate
        /// launch type.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
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
        /// a service or run a task with the task definition. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-networking.html">Task
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ECS.NetworkMode")]
        public Amazon.ECS.NetworkMode NetworkMode { get; set; }
        #endregion
        
        #region Parameter PidMode
        /// <summary>
        /// <para>
        /// <para>The process namespace to use for the containers in the task. The valid values are
        /// <code>host</code> or <code>task</code>. If <code>host</code> is specified, then all
        /// containers within the tasks that specified the <code>host</code> PID mode on the same
        /// container instance share the same IPC resources with the host Amazon EC2 instance.
        /// If <code>task</code> is specified, all containers within the specified task share
        /// the same process namespace. If no value is specified, the default is a private namespace.
        /// For more information, see <a href="https://docs.docker.com/engine/reference/run/#pid-settings---pid">PID
        /// settings</a> in the <i>Docker run reference</i>.</para><para>If the <code>host</code> PID mode is used, be aware that there is a heightened risk
        /// of undesired process namespace expose. For more information, see <a href="https://docs.docker.com/engine/security/security/">Docker
        /// security</a>.</para><note><para>This parameter is not supported for Windows containers or tasks using the Fargate
        /// launch type.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.TaskDefinitionPlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter RequiresCompatibility
        /// <summary>
        /// <para>
        /// <para>The launch type required by the task. If no value is specified, it defaults to <code>EC2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequiresCompatibilities")]
        public System.String[] RequiresCompatibility { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the task definition to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.
        /// Tag keys can have a maximum character length of 128 characters, and tag values can
        /// have a maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TaskRoleArn
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the IAM role that containers
        /// in this task can assume. All containers in this task are granted the permissions that
        /// are specified in this role. For more information, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/task-iam-roles.html">IAM
        /// Roles for Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TaskRoleArn { get; set; }
        #endregion
        
        #region Parameter Volume
        /// <summary>
        /// <para>
        /// <para>A list of volume definitions in JSON format that containers in your task may use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Volumes")]
        public Amazon.ECS.Model.Volume[] Volume { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Family", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-ECSTaskDefinition (RegisterTaskDefinition)"))
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
            
            if (this.ContainerDefinition != null)
            {
                context.ContainerDefinitions = new List<Amazon.ECS.Model.ContainerDefinition>(this.ContainerDefinition);
            }
            context.Cpu = this.Cpu;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.Family = this.Family;
            context.IpcMode = this.IpcMode;
            context.Memory = this.Memory;
            context.NetworkMode = this.NetworkMode;
            context.PidMode = this.PidMode;
            if (this.PlacementConstraint != null)
            {
                context.PlacementConstraints = new List<Amazon.ECS.Model.TaskDefinitionPlacementConstraint>(this.PlacementConstraint);
            }
            if (this.RequiresCompatibility != null)
            {
                context.RequiresCompatibilities = new List<System.String>(this.RequiresCompatibility);
            }
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ECS.Model.Tag>(this.Tag);
            }
            context.TaskRoleArn = this.TaskRoleArn;
            if (this.Volume != null)
            {
                context.Volumes = new List<Amazon.ECS.Model.Volume>(this.Volume);
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
            
            if (cmdletContext.ContainerDefinitions != null)
            {
                request.ContainerDefinitions = cmdletContext.ContainerDefinitions;
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
            if (cmdletContext.PlacementConstraints != null)
            {
                request.PlacementConstraints = cmdletContext.PlacementConstraints;
            }
            if (cmdletContext.RequiresCompatibilities != null)
            {
                request.RequiresCompatibilities = cmdletContext.RequiresCompatibilities;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TaskRoleArn != null)
            {
                request.TaskRoleArn = cmdletContext.TaskRoleArn;
            }
            if (cmdletContext.Volumes != null)
            {
                request.Volumes = cmdletContext.Volumes;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.ECS.Model.RegisterTaskDefinitionResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.RegisterTaskDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "RegisterTaskDefinition");
            try
            {
                #if DESKTOP
                return client.RegisterTaskDefinition(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RegisterTaskDefinitionAsync(request);
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
            public List<Amazon.ECS.Model.ContainerDefinition> ContainerDefinitions { get; set; }
            public System.String Cpu { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String Family { get; set; }
            public Amazon.ECS.IpcMode IpcMode { get; set; }
            public System.String Memory { get; set; }
            public Amazon.ECS.NetworkMode NetworkMode { get; set; }
            public Amazon.ECS.PidMode PidMode { get; set; }
            public List<Amazon.ECS.Model.TaskDefinitionPlacementConstraint> PlacementConstraints { get; set; }
            public List<System.String> RequiresCompatibilities { get; set; }
            public List<Amazon.ECS.Model.Tag> Tags { get; set; }
            public System.String TaskRoleArn { get; set; }
            public List<Amazon.ECS.Model.Volume> Volumes { get; set; }
        }
        
    }
}
