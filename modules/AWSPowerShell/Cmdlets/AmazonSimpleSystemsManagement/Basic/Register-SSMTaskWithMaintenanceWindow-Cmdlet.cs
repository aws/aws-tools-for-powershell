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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Adds a new task to a Maintenance Window.
    /// </summary>
    [Cmdlet("Register", "SSMTaskWithMaintenanceWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RegisterTaskWithMaintenanceWindow operation against Amazon Simple Systems Management.", Operation = new[] {"RegisterTaskWithMaintenanceWindow"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterSSMTaskWithMaintenanceWindowCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter MaxConcurrency
        /// <summary>
        /// <para>
        /// <para>The maximum number of targets this task can be run for in parallel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MaxConcurrency { get; set; }
        #endregion
        
        #region Parameter MaxError
        /// <summary>
        /// <para>
        /// <para>The maximum number of errors allowed before this task stops being scheduled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxErrors")]
        public System.String MaxError { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority of the task in the Maintenance Window, the lower the number the higher
        /// the priority. Tasks in a Maintenance Window are scheduled in priority order with tasks
        /// that have the same priority scheduled in parallel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Priority { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of an Amazon S3 bucket where execution logs are stored .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoggingInfo_S3BucketName { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>(Optional) The Amazon S3 bucket subfolder. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoggingInfo_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter LoggingInfo_S3Region
        /// <summary>
        /// <para>
        /// <para>The region where the Amazon S3 bucket is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LoggingInfo_S3Region { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The role that should be assumed when executing the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets (either instances or tags). Instances are specified using Key=instanceids,Values=&lt;instanceid1&gt;,&lt;instanceid2&gt;.
        /// Tags are specified using Key=&lt;tag name&gt;,Values=&lt;tag value&gt;.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter TaskArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the task to execute </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TaskArn { get; set; }
        #endregion
        
        #region Parameter TaskParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that should be passed to the task when it is executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TaskParameters")]
        public System.Collections.Hashtable TaskParameter { get; set; }
        #endregion
        
        #region Parameter TaskType
        /// <summary>
        /// <para>
        /// <para>The type of task being registered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType")]
        public Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType TaskType { get; set; }
        #endregion
        
        #region Parameter WindowId
        /// <summary>
        /// <para>
        /// <para>The id of the Maintenance Window the task should be added to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WindowId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TaskArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-SSMTaskWithMaintenanceWindow (RegisterTaskWithMaintenanceWindow)"))
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
            context.LoggingInfo_S3BucketName = this.LoggingInfo_S3BucketName;
            context.LoggingInfo_S3KeyPrefix = this.LoggingInfo_S3KeyPrefix;
            context.LoggingInfo_S3Region = this.LoggingInfo_S3Region;
            context.MaxConcurrency = this.MaxConcurrency;
            context.MaxErrors = this.MaxError;
            if (ParameterWasBound("Priority"))
                context.Priority = this.Priority;
            context.ServiceRoleArn = this.ServiceRoleArn;
            if (this.Target != null)
            {
                context.Targets = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
            }
            context.TaskArn = this.TaskArn;
            if (this.TaskParameter != null)
            {
                context.TaskParameters = new Dictionary<System.String, Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskParameterValueExpression>(StringComparer.Ordinal);
                foreach (var hashKey in this.TaskParameter.Keys)
                {
                    context.TaskParameters.Add((String)hashKey, (MaintenanceWindowTaskParameterValueExpression)(this.TaskParameter[hashKey]));
                }
            }
            context.TaskType = this.TaskType;
            context.WindowId = this.WindowId;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate LoggingInfo
            bool requestLoggingInfoIsNull = true;
            request.LoggingInfo = new Amazon.SimpleSystemsManagement.Model.LoggingInfo();
            System.String requestLoggingInfo_loggingInfo_S3BucketName = null;
            if (cmdletContext.LoggingInfo_S3BucketName != null)
            {
                requestLoggingInfo_loggingInfo_S3BucketName = cmdletContext.LoggingInfo_S3BucketName;
            }
            if (requestLoggingInfo_loggingInfo_S3BucketName != null)
            {
                request.LoggingInfo.S3BucketName = requestLoggingInfo_loggingInfo_S3BucketName;
                requestLoggingInfoIsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_S3KeyPrefix = null;
            if (cmdletContext.LoggingInfo_S3KeyPrefix != null)
            {
                requestLoggingInfo_loggingInfo_S3KeyPrefix = cmdletContext.LoggingInfo_S3KeyPrefix;
            }
            if (requestLoggingInfo_loggingInfo_S3KeyPrefix != null)
            {
                request.LoggingInfo.S3KeyPrefix = requestLoggingInfo_loggingInfo_S3KeyPrefix;
                requestLoggingInfoIsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_S3Region = null;
            if (cmdletContext.LoggingInfo_S3Region != null)
            {
                requestLoggingInfo_loggingInfo_S3Region = cmdletContext.LoggingInfo_S3Region;
            }
            if (requestLoggingInfo_loggingInfo_S3Region != null)
            {
                request.LoggingInfo.S3Region = requestLoggingInfo_loggingInfo_S3Region;
                requestLoggingInfoIsNull = false;
            }
             // determine if request.LoggingInfo should be set to null
            if (requestLoggingInfoIsNull)
            {
                request.LoggingInfo = null;
            }
            if (cmdletContext.MaxConcurrency != null)
            {
                request.MaxConcurrency = cmdletContext.MaxConcurrency;
            }
            if (cmdletContext.MaxErrors != null)
            {
                request.MaxErrors = cmdletContext.MaxErrors;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
            }
            if (cmdletContext.TaskArn != null)
            {
                request.TaskArn = cmdletContext.TaskArn;
            }
            if (cmdletContext.TaskParameters != null)
            {
                request.TaskParameters = cmdletContext.TaskParameters;
            }
            if (cmdletContext.TaskType != null)
            {
                request.TaskType = cmdletContext.TaskType;
            }
            if (cmdletContext.WindowId != null)
            {
                request.WindowId = cmdletContext.WindowId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.WindowTaskId;
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
        
        private Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.RegisterTaskWithMaintenanceWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "RegisterTaskWithMaintenanceWindow");
            #if DESKTOP
            return client.RegisterTaskWithMaintenanceWindow(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.RegisterTaskWithMaintenanceWindowAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.String LoggingInfo_S3BucketName { get; set; }
            public System.String LoggingInfo_S3KeyPrefix { get; set; }
            public System.String LoggingInfo_S3Region { get; set; }
            public System.String MaxConcurrency { get; set; }
            public System.String MaxErrors { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Targets { get; set; }
            public System.String TaskArn { get; set; }
            public Dictionary<System.String, Amazon.SimpleSystemsManagement.Model.MaintenanceWindowTaskParameterValueExpression> TaskParameters { get; set; }
            public Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType TaskType { get; set; }
            public System.String WindowId { get; set; }
        }
        
    }
}
