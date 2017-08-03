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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Task runners call <code>ReportTaskRunnerHeartbeat</code> every 15 minutes to indicate
    /// that they are operational. If the AWS Data Pipeline Task Runner is launched on a resource
    /// managed by AWS Data Pipeline, the web service can use this call to detect when the
    /// task runner application has failed and restart a new instance.
    /// </summary>
    [Cmdlet("Update", "DPTaskRunnerHeartbeat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Invokes the ReportTaskRunnerHeartbeat operation against AWS Data Pipeline.", Operation = new[] {"ReportTaskRunnerHeartbeat"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDPTaskRunnerHeartbeatCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The public DNS name of the task runner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Hostname { get; set; }
        #endregion
        
        #region Parameter TaskrunnerId
        /// <summary>
        /// <para>
        /// <para>The ID of the task runner. This value should be unique across your AWS account. In
        /// the case of AWS Data Pipeline Task Runner launched on a resource managed by AWS Data
        /// Pipeline, the web service provides a unique identifier when it launches the application.
        /// If you have written a custom task runner, you should assign a unique identifier for
        /// the task runner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TaskrunnerId { get; set; }
        #endregion
        
        #region Parameter WorkerGroup
        /// <summary>
        /// <para>
        /// <para>The type of task the task runner is configured to accept and process. The worker group
        /// is set as a field on objects in the pipeline when they are created. You can only specify
        /// a single value for <code>workerGroup</code>. There are no wildcard values permitted
        /// in <code>workerGroup</code>; the string must be an exact, case-sensitive, match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String WorkerGroup { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TaskrunnerId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DPTaskRunnerHeartbeat (ReportTaskRunnerHeartbeat)"))
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
            
            context.Hostname = this.Hostname;
            context.TaskrunnerId = this.TaskrunnerId;
            context.WorkerGroup = this.WorkerGroup;
            
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
            var request = new Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatRequest();
            
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            if (cmdletContext.TaskrunnerId != null)
            {
                request.TaskrunnerId = cmdletContext.TaskrunnerId;
            }
            if (cmdletContext.WorkerGroup != null)
            {
                request.WorkerGroup = cmdletContext.WorkerGroup;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Terminate;
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
        
        private Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.ReportTaskRunnerHeartbeatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Data Pipeline", "ReportTaskRunnerHeartbeat");
            #if DESKTOP
            return client.ReportTaskRunnerHeartbeat(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ReportTaskRunnerHeartbeatAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Hostname { get; set; }
            public System.String TaskrunnerId { get; set; }
            public System.String WorkerGroup { get; set; }
        }
        
    }
}
