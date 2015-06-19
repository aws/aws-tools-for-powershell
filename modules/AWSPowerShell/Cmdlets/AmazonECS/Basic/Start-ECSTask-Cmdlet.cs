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
    /// Starts a new task from the specified task definition on the specified container instance
    /// or instances. If you want to use the default Amazon ECS scheduler to place your task,
    /// use <code>RunTask</code> instead.
    /// 
    ///  <important><para>
    /// The list of container instances to start tasks on is limited to 10.
    /// </para></important>
    /// </summary>
    [Cmdlet("Start", "ECSTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.StartTaskResponse")]
    [AWSCmdlet("Invokes the StartTask operation against Amazon EC2 Container Service.", Operation = new[] {"StartTask"})]
    [AWSCmdletOutput("Amazon.ECS.Model.StartTaskResponse",
        "This cmdlet returns a StartTaskResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StartECSTaskCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that you want to
        /// start your task on. If you do not specify a cluster, the default cluster is assumed..</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Cluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The container instance UUIDs or full Amazon Resource Name (ARN) entries for the container
        /// instances on which you would like to place your task.</para><important><para>The list of container instances to start tasks on is limited to 10.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerInstances")]
        public System.String[] ContainerInstance { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more container overrides sent to a task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Overrides_ContainerOverrides")]
        public Amazon.ECS.Model.ContainerOverride[] Overrides_ContainerOverride { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An optional tag specified when a task is started. For example if you automatically
        /// trigger a task to run a batch process job, you could apply a unique identifier for
        /// that job to your task with the <code>startedBy</code> parameter. You can then identify
        /// which tasks belong to that job by filtering the results of a <a>ListTasks</a> call
        /// with the <code>startedBy</code> value.</para><para>If a task is started by an Amazon ECS service, then the <code>startedBy</code> parameter
        /// contains the deployment ID of the service that starts it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String StartedBy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> and <code>revision</code> (<code>family:revision</code>) or
        /// full Amazon Resource Name (ARN) of the task definition that you want to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TaskDefinition { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            context.Cluster = this.Cluster;
            if (this.ContainerInstance != null)
            {
                context.ContainerInstances = new List<String>(this.ContainerInstance);
            }
            if (this.Overrides_ContainerOverride != null)
            {
                context.Overrides_ContainerOverrides = new List<ContainerOverride>(this.Overrides_ContainerOverride);
            }
            context.StartedBy = this.StartedBy;
            context.TaskDefinition = this.TaskDefinition;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new StartTaskRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ContainerInstances != null)
            {
                request.ContainerInstances = cmdletContext.ContainerInstances;
            }
            
             // populate Overrides
            bool requestOverridesIsNull = true;
            request.Overrides = new TaskOverride();
            List<ContainerOverride> requestOverrides_overrides_ContainerOverride = null;
            if (cmdletContext.Overrides_ContainerOverrides != null)
            {
                requestOverrides_overrides_ContainerOverride = cmdletContext.Overrides_ContainerOverrides;
            }
            if (requestOverrides_overrides_ContainerOverride != null)
            {
                request.Overrides.ContainerOverrides = requestOverrides_overrides_ContainerOverride;
                requestOverridesIsNull = false;
            }
             // determine if request.Overrides should be set to null
            if (requestOverridesIsNull)
            {
                request.Overrides = null;
            }
            if (cmdletContext.StartedBy != null)
            {
                request.StartedBy = cmdletContext.StartedBy;
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
                var response = client.StartTask(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Cluster { get; set; }
            public List<String> ContainerInstances { get; set; }
            public List<ContainerOverride> Overrides_ContainerOverrides { get; set; }
            public String StartedBy { get; set; }
            public String TaskDefinition { get; set; }
        }
        
    }
}
