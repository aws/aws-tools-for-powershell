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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Creates a new Maintenance Window.
    /// </summary>
    [Cmdlet("New", "SSMMaintenanceWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager CreateMaintenanceWindow API operation.", Operation = new[] {"CreateMaintenanceWindow"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreateMaintenanceWindowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMMaintenanceWindowCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter AllowUnassociatedTarget
        /// <summary>
        /// <para>
        /// <para>Enables a Maintenance Window task to execute on managed instances, even if you have
        /// not registered those instances as targets. If enabled, then you must specify the unregistered
        /// instances (by instance ID) when you register a task with the Maintenance Window </para><para>If you don't enable this option, then you must specify previously-registered targets
        /// when you register a task with the Maintenance Window. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AllowUnassociatedTargets")]
        public System.Boolean AllowUnassociatedTarget { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Cutoff
        /// <summary>
        /// <para>
        /// <para>The number of hours before the end of the Maintenance Window that Systems Manager
        /// stops scheduling new tasks for execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Cutoff { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the Maintenance Window. We recommend specifying a description
        /// to help you organize your Maintenance Windows. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>The duration of the Maintenance Window in hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Duration { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time, in ISO-8601 Extended format, for when you want the Maintenance
        /// Window to become inactive. EndDate allows you to set a date and time in the future
        /// when the Maintenance Window will no longer run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EndDate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Maintenance Window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Schedule
        /// <summary>
        /// <para>
        /// <para>The schedule of the Maintenance Window in the form of a cron or rate expression.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Schedule { get; set; }
        #endregion
        
        #region Parameter ScheduleTimezone
        /// <summary>
        /// <para>
        /// <para>The time zone that the scheduled Maintenance Window executions are based on, in Internet
        /// Assigned Numbers Authority (IANA) format. For example: "America/Los_Angeles", "etc/UTC",
        /// or "Asia/Seoul". For more information, see the <a href="https://www.iana.org/time-zones">Time
        /// Zone Database</a> on the IANA website.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ScheduleTimezone { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <para>The date and time, in ISO-8601 Extended format, for when you want the Maintenance
        /// Window to become active. StartDate allows you to delay activation of the Maintenance
        /// Window until the specified future date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartDate { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you assign to a resource. Tags enable you to categorize a resource
        /// in different ways, such as by purpose, owner, or environment. For example, you might
        /// want to tag a Maintenance Window to identify the type of tasks it will run, the types
        /// of targets, and the environment it will run in. In this case, you could specify the
        /// following key name/value pairs:</para><ul><li><para><code>Key=TaskType,Value=AgentUpdate</code></para></li><li><para><code>Key=OS,Value=Windows</code></para></li><li><para><code>Key=Environment,Value=Production</code></para></li></ul><note><para>To add tags to an existing Maintenance Window, use the <a>AddTagsToResource</a> action.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMMaintenanceWindow (CreateMaintenanceWindow)"))
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
            
            if (ParameterWasBound("AllowUnassociatedTarget"))
                context.AllowUnassociatedTargets = this.AllowUnassociatedTarget;
            context.ClientToken = this.ClientToken;
            if (ParameterWasBound("Cutoff"))
                context.Cutoff = this.Cutoff;
            context.Description = this.Description;
            if (ParameterWasBound("Duration"))
                context.Duration = this.Duration;
            context.EndDate = this.EndDate;
            context.Name = this.Name;
            context.Schedule = this.Schedule;
            context.ScheduleTimezone = this.ScheduleTimezone;
            context.StartDate = this.StartDate;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreateMaintenanceWindowRequest();
            
            if (cmdletContext.AllowUnassociatedTargets != null)
            {
                request.AllowUnassociatedTargets = cmdletContext.AllowUnassociatedTargets.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Cutoff != null)
            {
                request.Cutoff = cmdletContext.Cutoff.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration.Value;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Schedule != null)
            {
                request.Schedule = cmdletContext.Schedule;
            }
            if (cmdletContext.ScheduleTimezone != null)
            {
                request.ScheduleTimezone = cmdletContext.ScheduleTimezone;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.WindowId;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreateMaintenanceWindowResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreateMaintenanceWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreateMaintenanceWindow");
            try
            {
                #if DESKTOP
                return client.CreateMaintenanceWindow(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateMaintenanceWindowAsync(request);
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
            public System.Boolean? AllowUnassociatedTargets { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? Cutoff { get; set; }
            public System.String Description { get; set; }
            public System.Int32? Duration { get; set; }
            public System.String EndDate { get; set; }
            public System.String Name { get; set; }
            public System.String Schedule { get; set; }
            public System.String ScheduleTimezone { get; set; }
            public System.String StartDate { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tags { get; set; }
        }
        
    }
}
