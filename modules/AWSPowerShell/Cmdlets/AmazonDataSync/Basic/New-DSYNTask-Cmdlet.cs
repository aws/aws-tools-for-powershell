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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates a task. A task is a set of two locations (source and destination) and a set
    /// of default <code>OverrideOptions</code> that you use to control the behavior of a
    /// task. If you don't specify default values for <code>Options</code> when you create
    /// a task, AWS DataSync populates them with safe service defaults.
    /// 
    ///  
    /// <para>
    /// When you initially create a task, it enters the INITIALIZING status and then the CREATING
    /// status. In CREATING status, AWS DataSync attempts to mount the source Network File
    /// System (NFS) location. The task transitions to the AVAILABLE status without waiting
    /// for the destination location to mount. Instead, AWS DataSync mounts a destination
    /// before every task execution and then unmounts it after every task execution. 
    /// </para><para>
    /// If an agent that is associated with a source (NFS) location goes offline, the task
    /// transitions to the UNAVAILABLE status. If the status of the task remains in the CREATING
    /// status for more than a few minutes, it means that your agent might be having trouble
    /// mounting the source NFS file system. Check the task's <code>ErrorCode</code> and <code>ErrorDetail</code>.
    /// Mount issues are often caused by either a misconfigured firewall or a mistyped NFS
    /// server host name.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateTask API operation.", Operation = new[] {"CreateTask"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.DataSync.Model.CreateTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNTaskCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        #region Parameter CloudWatchLogGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon CloudWatch log group that is used to
        /// monitor and log events in the task. For more information on these groups, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Working-with-log-groups-and-streams.html">Working
        /// with Log Groups and Log Streams</a> in the <i>Amazon CloudWatch User Guide. </i></para><para>For more information about how to useCloudWatchLogs with DataSync, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/monitor-datasync.html">Monitoring
        /// Your Task</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloudWatchLogGroupArn { get; set; }
        #endregion
        
        #region Parameter DestinationLocationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS storage resource's location. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DestinationLocationArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a task. This value is a text reference that is used to identify the task
        /// in the console. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Option
        /// <summary>
        /// <para>
        /// <para>The set of configuration options that control the behavior of a single execution of
        /// the task that occurs when you call <code>StartTaskExecution</code>. You can configure
        /// these options to preserve metadata such as user ID (UID) and group ID (GID), file
        /// permissions, data integrity verification, and so on.</para><para>For each individual task execution, you can override these options by specifying the
        /// <code>OverrideOptions</code> before starting a the task execution. For more information,
        /// see the operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Options")]
        public Amazon.DataSync.Model.Options Option { get; set; }
        #endregion
        
        #region Parameter SourceLocationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source location for the task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceLocationArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents the tag that you want to add to the resource. The
        /// value can be an empty string. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceLocationArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNTask (CreateTask)"))
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
            
            context.CloudWatchLogGroupArn = this.CloudWatchLogGroupArn;
            context.DestinationLocationArn = this.DestinationLocationArn;
            context.Name = this.Name;
            context.Options = this.Option;
            context.SourceLocationArn = this.SourceLocationArn;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Options != null)
            {
                request.Options = cmdletContext.Options;
            }
            if (cmdletContext.SourceLocationArn != null)
            {
                request.SourceLocationArn = cmdletContext.SourceLocationArn;
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
                object pipelineOutput = response.TaskArn;
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
            public System.String Name { get; set; }
            public Amazon.DataSync.Model.Options Options { get; set; }
            public System.String SourceLocationArn { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tags { get; set; }
        }
        
    }
}
