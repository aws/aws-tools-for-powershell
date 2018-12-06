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
    /// Starts a new task from the specified task definition on the specified container instance
    /// or instances.
    /// 
    ///  
    /// <para>
    /// Alternatively, you can use <a>RunTask</a> to place tasks for you. For more information,
    /// see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/scheduling_tasks.html">Scheduling
    /// Tasks</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "ECSTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.StartTaskResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service StartTask API operation.", Operation = new[] {"StartTask"})]
    [AWSCmdletOutput("Amazon.ECS.Model.StartTaskResponse",
        "This cmdlet returns a Amazon.ECS.Model.StartTaskResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartECSTaskCmdlet : AmazonECSClientCmdlet, IExecutor
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
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster on which to start
        /// your task. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ContainerInstance
        /// <summary>
        /// <para>
        /// <para>The container instance IDs or full ARN entries for the container instances on which
        /// you would like to place your task. You can specify up to 10 container instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerInstances")]
        public System.String[] ContainerInstance { get; set; }
        #endregion
        
        #region Parameter Overrides_ContainerOverride
        /// <summary>
        /// <para>
        /// <para>One or more container overrides sent to a task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Overrides_ContainerOverrides")]
        public Amazon.ECS.Model.ContainerOverride[] Overrides_ContainerOverride { get; set; }
        #endregion
        
        #region Parameter EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable Amazon ECS managed tags for the task. For more information,
        /// see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/Using_Tags.html">Tagging
        /// Your Amazon ECS Resources</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EnableECSManagedTags")]
        public System.Boolean EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter Overrides_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the task execution role that the Amazon ECS container
        /// agent and the Docker daemon can assume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Overrides_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The name of the task group to associate with the task. The default value is the family
        /// name of the task definition (for example, family:my-family-name).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Group { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether to propagate the tags from the task definition or the service to
        /// the task. If no value is specified, the tags are not propagated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateTags")]
        public Amazon.ECS.PropagateTags PropagateTag { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the task or service. If you do not specify a security
        /// group, the default security group for the VPC is used. There is a limit of five security
        /// groups able to be specified per <code>AwsVpcConfiguration</code>.</para><note><para>All specified security groups must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String StartedBy { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the task to help you categorize and organize them.
        /// Each tag consists of a key and an optional value, both of which you define. Tag keys
        /// can have a maximum character length of 128 characters, and tag values can have a maximum
        /// length of 256 characters.</para>
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
        /// full ARN of the task definition to start. If a <code>revision</code> is not specified,
        /// the latest <code>ACTIVE</code> revision is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String Overrides_TaskRoleArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Cluster", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ECSTask (StartTask)"))
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
            if (this.ContainerInstance != null)
            {
                context.ContainerInstances = new List<System.String>(this.ContainerInstance);
            }
            if (ParameterWasBound("EnableECSManagedTag"))
                context.EnableECSManagedTags = this.EnableECSManagedTag;
            context.Group = this.Group;
            context.NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.NetworkConfiguration_AwsvpcConfiguration_SecurityGroups = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.NetworkConfiguration_AwsvpcConfiguration_Subnets = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            if (this.Overrides_ContainerOverride != null)
            {
                context.Overrides_ContainerOverrides = new List<Amazon.ECS.Model.ContainerOverride>(this.Overrides_ContainerOverride);
            }
            context.Overrides_ExecutionRoleArn = this.Overrides_ExecutionRoleArn;
            context.Overrides_TaskRoleArn = this.Overrides_TaskRoleArn;
            context.PropagateTags = this.PropagateTag;
            context.StartedBy = this.StartedBy;
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
            var request = new Amazon.ECS.Model.StartTaskRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ContainerInstances != null)
            {
                request.ContainerInstances = cmdletContext.ContainerInstances;
            }
            if (cmdletContext.EnableECSManagedTags != null)
            {
                request.EnableECSManagedTags = cmdletContext.EnableECSManagedTags.Value;
            }
            if (cmdletContext.Group != null)
            {
                request.Group = cmdletContext.Group;
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
            
             // populate Overrides
            bool requestOverridesIsNull = true;
            request.Overrides = new Amazon.ECS.Model.TaskOverride();
            List<Amazon.ECS.Model.ContainerOverride> requestOverrides_overrides_ContainerOverride = null;
            if (cmdletContext.Overrides_ContainerOverrides != null)
            {
                requestOverrides_overrides_ContainerOverride = cmdletContext.Overrides_ContainerOverrides;
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
            if (cmdletContext.PropagateTags != null)
            {
                request.PropagateTags = cmdletContext.PropagateTags;
            }
            if (cmdletContext.StartedBy != null)
            {
                request.StartedBy = cmdletContext.StartedBy;
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
        
        private Amazon.ECS.Model.StartTaskResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.StartTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "StartTask");
            try
            {
                #if DESKTOP
                return client.StartTask(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartTaskAsync(request);
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
            public List<System.String> ContainerInstances { get; set; }
            public System.Boolean? EnableECSManagedTags { get; set; }
            public System.String Group { get; set; }
            public Amazon.ECS.AssignPublicIp NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_SecurityGroups { get; set; }
            public List<System.String> NetworkConfiguration_AwsvpcConfiguration_Subnets { get; set; }
            public List<Amazon.ECS.Model.ContainerOverride> Overrides_ContainerOverrides { get; set; }
            public System.String Overrides_ExecutionRoleArn { get; set; }
            public System.String Overrides_TaskRoleArn { get; set; }
            public Amazon.ECS.PropagateTags PropagateTags { get; set; }
            public System.String StartedBy { get; set; }
            public List<Amazon.ECS.Model.Tag> Tags { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
