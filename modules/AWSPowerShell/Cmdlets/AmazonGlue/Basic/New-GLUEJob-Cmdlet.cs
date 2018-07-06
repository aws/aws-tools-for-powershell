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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a new job definition.
    /// </summary>
    [Cmdlet("New", "GLUEJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue CreateJob API operation.", Operation = new[] {"CreateJob"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Glue.Model.CreateJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUEJobCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter AllocatedCapacity
        /// <summary>
        /// <para>
        /// <para>The number of AWS Glue data processing units (DPUs) to allocate to this Job. From
        /// 2 to 100 DPUs can be allocated; the default is 10. A DPU is a relative measure of
        /// processing power that consists of 4 vCPUs of compute capacity and 16 GB of memory.
        /// For more information, see the <a href="https://aws.amazon.com/glue/pricing/">AWS Glue
        /// pricing page</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AllocatedCapacity { get; set; }
        #endregion
        
        #region Parameter Command
        /// <summary>
        /// <para>
        /// <para>The JobCommand that executes this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.Glue.Model.JobCommand Command { get; set; }
        #endregion
        
        #region Parameter Connections_Connection
        /// <summary>
        /// <para>
        /// <para>A list of connections used by the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Connections_Connections")]
        public System.String[] Connections_Connection { get; set; }
        #endregion
        
        #region Parameter DefaultArgument
        /// <summary>
        /// <para>
        /// <para>The default arguments for this job.</para><para>You can specify arguments here that your own job-execution script consumes, as well
        /// as arguments that AWS Glue itself consumes.</para><para>For information about how to specify and consume your own Job arguments, see the <a href="http://docs.aws.amazon.com/glue/latest/dg/aws-glue-programming-python-calling.html">Calling
        /// AWS Glue APIs in Python</a> topic in the developer guide.</para><para>For information about the key-value pairs that AWS Glue consumes to set up your job,
        /// see the <a href="http://docs.aws.amazon.com/glue/latest/dg/aws-glue-programming-etl-glue-arguments.html">Special
        /// Parameters Used by AWS Glue</a> topic in the developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DefaultArguments")]
        public System.Collections.Hashtable DefaultArgument { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the job being defined.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LogUri
        /// <summary>
        /// <para>
        /// <para>This field is reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LogUri { get; set; }
        #endregion
        
        #region Parameter ExecutionProperty_MaxConcurrentRun
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent runs allowed for the job. The default is 1. An error
        /// is returned when this threshold is reached. The maximum value you can specify is controlled
        /// by a service limit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ExecutionProperty_MaxConcurrentRuns")]
        public System.Int32 ExecutionProperty_MaxConcurrentRun { get; set; }
        #endregion
        
        #region Parameter MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times to retry this job if it fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxRetries")]
        public System.Int32 MaxRetry { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name you assign to this job definition. It must be unique in your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NotificationProperty_NotifyDelayAfter
        /// <summary>
        /// <para>
        /// <para>After a job run starts, the number of minutes to wait before sending a job run delay
        /// notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NotificationProperty_NotifyDelayAfter { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the IAM role associated with this job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The job timeout in minutes. The default is 2880 minutes (48 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Timeout { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEJob (CreateJob)"))
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
            
            if (ParameterWasBound("AllocatedCapacity"))
                context.AllocatedCapacity = this.AllocatedCapacity;
            context.Command = this.Command;
            if (this.Connections_Connection != null)
            {
                context.Connections_Connections = new List<System.String>(this.Connections_Connection);
            }
            if (this.DefaultArgument != null)
            {
                context.DefaultArguments = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultArgument.Keys)
                {
                    context.DefaultArguments.Add((String)hashKey, (String)(this.DefaultArgument[hashKey]));
                }
            }
            context.Description = this.Description;
            if (ParameterWasBound("ExecutionProperty_MaxConcurrentRun"))
                context.ExecutionProperty_MaxConcurrentRuns = this.ExecutionProperty_MaxConcurrentRun;
            context.LogUri = this.LogUri;
            if (ParameterWasBound("MaxRetry"))
                context.MaxRetries = this.MaxRetry;
            context.Name = this.Name;
            if (ParameterWasBound("NotificationProperty_NotifyDelayAfter"))
                context.NotificationProperty_NotifyDelayAfter = this.NotificationProperty_NotifyDelayAfter;
            context.Role = this.Role;
            if (ParameterWasBound("Timeout"))
                context.Timeout = this.Timeout;
            
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
            var request = new Amazon.Glue.Model.CreateJobRequest();
            
            if (cmdletContext.AllocatedCapacity != null)
            {
                request.AllocatedCapacity = cmdletContext.AllocatedCapacity.Value;
            }
            if (cmdletContext.Command != null)
            {
                request.Command = cmdletContext.Command;
            }
            
             // populate Connections
            bool requestConnectionsIsNull = true;
            request.Connections = new Amazon.Glue.Model.ConnectionsList();
            List<System.String> requestConnections_connections_Connection = null;
            if (cmdletContext.Connections_Connections != null)
            {
                requestConnections_connections_Connection = cmdletContext.Connections_Connections;
            }
            if (requestConnections_connections_Connection != null)
            {
                request.Connections.Connections = requestConnections_connections_Connection;
                requestConnectionsIsNull = false;
            }
             // determine if request.Connections should be set to null
            if (requestConnectionsIsNull)
            {
                request.Connections = null;
            }
            if (cmdletContext.DefaultArguments != null)
            {
                request.DefaultArguments = cmdletContext.DefaultArguments;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate ExecutionProperty
            bool requestExecutionPropertyIsNull = true;
            request.ExecutionProperty = new Amazon.Glue.Model.ExecutionProperty();
            System.Int32? requestExecutionProperty_executionProperty_MaxConcurrentRun = null;
            if (cmdletContext.ExecutionProperty_MaxConcurrentRuns != null)
            {
                requestExecutionProperty_executionProperty_MaxConcurrentRun = cmdletContext.ExecutionProperty_MaxConcurrentRuns.Value;
            }
            if (requestExecutionProperty_executionProperty_MaxConcurrentRun != null)
            {
                request.ExecutionProperty.MaxConcurrentRuns = requestExecutionProperty_executionProperty_MaxConcurrentRun.Value;
                requestExecutionPropertyIsNull = false;
            }
             // determine if request.ExecutionProperty should be set to null
            if (requestExecutionPropertyIsNull)
            {
                request.ExecutionProperty = null;
            }
            if (cmdletContext.LogUri != null)
            {
                request.LogUri = cmdletContext.LogUri;
            }
            if (cmdletContext.MaxRetries != null)
            {
                request.MaxRetries = cmdletContext.MaxRetries.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NotificationProperty
            bool requestNotificationPropertyIsNull = true;
            request.NotificationProperty = new Amazon.Glue.Model.NotificationProperty();
            System.Int32? requestNotificationProperty_notificationProperty_NotifyDelayAfter = null;
            if (cmdletContext.NotificationProperty_NotifyDelayAfter != null)
            {
                requestNotificationProperty_notificationProperty_NotifyDelayAfter = cmdletContext.NotificationProperty_NotifyDelayAfter.Value;
            }
            if (requestNotificationProperty_notificationProperty_NotifyDelayAfter != null)
            {
                request.NotificationProperty.NotifyDelayAfter = requestNotificationProperty_notificationProperty_NotifyDelayAfter.Value;
                requestNotificationPropertyIsNull = false;
            }
             // determine if request.NotificationProperty should be set to null
            if (requestNotificationPropertyIsNull)
            {
                request.NotificationProperty = null;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Name;
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
        
        private Amazon.Glue.Model.CreateJobResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateJob");
            try
            {
                #if DESKTOP
                return client.CreateJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateJobAsync(request);
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
            public System.Int32? AllocatedCapacity { get; set; }
            public Amazon.Glue.Model.JobCommand Command { get; set; }
            public List<System.String> Connections_Connections { get; set; }
            public Dictionary<System.String, System.String> DefaultArguments { get; set; }
            public System.String Description { get; set; }
            public System.Int32? ExecutionProperty_MaxConcurrentRuns { get; set; }
            public System.String LogUri { get; set; }
            public System.Int32? MaxRetries { get; set; }
            public System.String Name { get; set; }
            public System.Int32? NotificationProperty_NotifyDelayAfter { get; set; }
            public System.String Role { get; set; }
            public System.Int32? Timeout { get; set; }
        }
        
    }
}
