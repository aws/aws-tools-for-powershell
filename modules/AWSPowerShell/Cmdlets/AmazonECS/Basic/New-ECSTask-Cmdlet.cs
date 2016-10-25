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
    /// Start a task using random placement and the default Amazon ECS scheduler. To use your
    /// own scheduler or place a task on a specific container instance, use <code>StartTask</code>
    /// instead.
    /// 
    ///  <important><para>
    /// The <code>count</code> parameter is limited to 10 tasks per call.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "ECSTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.RunTaskResponse")]
    [AWSCmdlet("Invokes the RunTask operation against Amazon EC2 Container Service.", Operation = new[] {"RunTask"})]
    [AWSCmdletOutput("Amazon.ECS.Model.RunTaskResponse",
        "This cmdlet returns a Amazon.ECS.Model.RunTaskResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECSTaskCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster on which to run your
        /// task. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
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
        
        #region Parameter Count
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the specified task to place on your cluster.</para><important><para>The <code>count</code> parameter is limited to 10 tasks per call.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Count { get; set; }
        #endregion
        
        #region Parameter StartedBy
        /// <summary>
        /// <para>
        /// <para>An optional tag specified when a task is started. For example if you automatically
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
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> and <code>revision</code> (<code>family:revision</code>) or
        /// full Amazon Resource Name (ARN) of the task definition to run. If a <code>revision</code>
        /// is not specified, the latest <code>ACTIVE</code> revision is used.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSTask (RunTask)"))
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
            if (ParameterWasBound("Count"))
                context.Count = this.Count;
            if (this.Overrides_ContainerOverride != null)
            {
                context.Overrides_ContainerOverrides = new List<Amazon.ECS.Model.ContainerOverride>(this.Overrides_ContainerOverride);
            }
            context.Overrides_TaskRoleArn = this.Overrides_TaskRoleArn;
            context.StartedBy = this.StartedBy;
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
            var request = new Amazon.ECS.Model.RunTaskRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.Count != null)
            {
                request.Count = cmdletContext.Count.Value;
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
        
        private static Amazon.ECS.Model.RunTaskResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.RunTaskRequest request)
        {
            #if DESKTOP
            return client.RunTask(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.RunTaskAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Cluster { get; set; }
            public System.Int32? Count { get; set; }
            public List<Amazon.ECS.Model.ContainerOverride> Overrides_ContainerOverrides { get; set; }
            public System.String Overrides_TaskRoleArn { get; set; }
            public System.String StartedBy { get; set; }
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
