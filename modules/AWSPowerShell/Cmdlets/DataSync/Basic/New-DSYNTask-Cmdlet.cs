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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates a task. A task is a set of two locations (source and destination) and a set
    /// of Options that you use to control the behavior of a task. If you don't specify Options
    /// when you create a task, AWS DataSync populates them with service defaults.
    /// 
    ///  
    /// <para>
    /// When you create a task, it first enters the CREATING state. During CREATING AWS DataSync
    /// attempts to mount the on-premises Network File System (NFS) location. The task transitions
    /// to the AVAILABLE state without waiting for the AWS location to become mounted. If
    /// required, AWS DataSync mounts the AWS location before each task execution.
    /// </para><para>
    /// If an agent that is associated with a source (NFS) location goes offline, the task
    /// transitions to the UNAVAILABLE status. If the status of the task remains in the CREATING
    /// status for more than a few minutes, it means that your agent might be having trouble
    /// mounting the source NFS file system. Check the task's ErrorCode and ErrorDetail. Mount
    /// issues are often caused by either a misconfigured firewall or a mistyped NFS server
    /// hostname.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateTask API operation.", Operation = new[] {"CreateTask"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNTaskCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter CloudWatchLogGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon CloudWatch log group that is used to
        /// monitor and log events in the task. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogGroupArn { get; set; }
        #endregion
        
        #region Parameter DestinationLocationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS storage resource's location. </para>
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
        public System.String DestinationLocationArn { get; set; }
        #endregion
        
        #region Parameter Exclude
        /// <summary>
        /// <para>
        /// <para>A list of filter rules that determines which files to exclude from a task. The list
        /// should contain a single filter string that consists of the patterns to exclude. The
        /// patterns are delimited by "|" (that is, a pipe), for example, <code>"/folder1|/folder2"</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Excludes")]
        public Amazon.DataSync.Model.FilterRule[] Exclude { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a task. This value is a text reference that is used to identify the task
        /// in the console. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Option
        /// <summary>
        /// <para>
        /// <para>The set of configuration options that control the behavior of a single execution of
        /// the task that occurs when you call <code>StartTaskExecution</code>. You can configure
        /// these options to preserve metadata such as user ID (UID) and group ID (GID), file
        /// permissions, data integrity verification, and so on.</para><para>For each individual task execution, you can override these options by specifying the
        /// <code>OverrideOptions</code> before starting the task execution. For more information,
        /// see the operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Options")]
        public Amazon.DataSync.Model.Options Option { get; set; }
        #endregion
        
        #region Parameter Schedule_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A cron expression that specifies when AWS DataSync initiates a scheduled transfer
        /// from a source to a destination location. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter SourceLocationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source location for the task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceLocationArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to add to the resource. The
        /// value can be an empty string. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateTaskResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceLocationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceLocationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceLocationArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceLocationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNTask (CreateTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateTaskResponse, NewDSYNTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceLocationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchLogGroupArn = this.CloudWatchLogGroupArn;
            context.DestinationLocationArn = this.DestinationLocationArn;
            #if MODULAR
            if (this.DestinationLocationArn == null && ParameterWasBound(nameof(this.DestinationLocationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationLocationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Exclude != null)
            {
                context.Exclude = new List<Amazon.DataSync.Model.FilterRule>(this.Exclude);
            }
            context.Name = this.Name;
            context.Option = this.Option;
            context.Schedule_ScheduleExpression = this.Schedule_ScheduleExpression;
            context.SourceLocationArn = this.SourceLocationArn;
            #if MODULAR
            if (this.SourceLocationArn == null && ParameterWasBound(nameof(this.SourceLocationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceLocationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            var request = new Amazon.DataSync.Model.CreateTaskRequest();
            
            if (cmdletContext.CloudWatchLogGroupArn != null)
            {
                request.CloudWatchLogGroupArn = cmdletContext.CloudWatchLogGroupArn;
            }
            if (cmdletContext.DestinationLocationArn != null)
            {
                request.DestinationLocationArn = cmdletContext.DestinationLocationArn;
            }
            if (cmdletContext.Exclude != null)
            {
                request.Excludes = cmdletContext.Exclude;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Option != null)
            {
                request.Options = cmdletContext.Option;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.DataSync.Model.TaskSchedule();
            System.String requestSchedule_schedule_ScheduleExpression = null;
            if (cmdletContext.Schedule_ScheduleExpression != null)
            {
                requestSchedule_schedule_ScheduleExpression = cmdletContext.Schedule_ScheduleExpression;
            }
            if (requestSchedule_schedule_ScheduleExpression != null)
            {
                request.Schedule.ScheduleExpression = requestSchedule_schedule_ScheduleExpression;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.SourceLocationArn != null)
            {
                request.SourceLocationArn = cmdletContext.SourceLocationArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.DataSync.Model.CreateTaskResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateTask");
            try
            {
                #if DESKTOP
                return client.CreateTask(request);
                #elif CORECLR
                return client.CreateTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogGroupArn { get; set; }
            public System.String DestinationLocationArn { get; set; }
            public List<Amazon.DataSync.Model.FilterRule> Exclude { get; set; }
            public System.String Name { get; set; }
            public Amazon.DataSync.Model.Options Option { get; set; }
            public System.String Schedule_ScheduleExpression { get; set; }
            public System.String SourceLocationArn { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateTaskResponse, NewDSYNTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskArn;
        }
        
    }
}
