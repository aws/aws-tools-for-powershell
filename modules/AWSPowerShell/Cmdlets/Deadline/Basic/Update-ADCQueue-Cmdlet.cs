/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Updates a queue.
    /// </summary>
    [Cmdlet("Update", "ADCQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWSDeadlineCloud UpdateQueue API operation.", Operation = new[] {"UpdateQueue"}, SelectReturnType = typeof(Amazon.Deadline.Model.UpdateQueueResponse))]
    [AWSCmdletOutput("None or Amazon.Deadline.Model.UpdateQueueResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Deadline.Model.UpdateQueueResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateADCQueueCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowedStorageProfileIdsToAdd
        /// <summary>
        /// <para>
        /// <para>The storage profile IDs to add.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AllowedStorageProfileIdsToAdd { get; set; }
        #endregion
        
        #region Parameter AllowedStorageProfileIdsToRemove
        /// <summary>
        /// <para>
        /// <para>The storage profile ID to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AllowedStorageProfileIdsToRemove { get; set; }
        #endregion
        
        #region Parameter DefaultBudgetAction
        /// <summary>
        /// <para>
        /// <para>The default action to take for a queue update if a budget isn't configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.DefaultQueueBudgetAction")]
        public Amazon.Deadline.DefaultQueueBudgetAction DefaultBudgetAction { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the queue to update.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the queue to update.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID to update in the queue.</para>
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
        public System.String FarmId { get; set; }
        #endregion
        
        #region Parameter Posix_Group
        /// <summary>
        /// <para>
        /// <para>The name of the POSIX user's group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobRunAsUser_Posix_Group")]
        public System.String Posix_Group { get; set; }
        #endregion
        
        #region Parameter Windows_PasswordArn
        /// <summary>
        /// <para>
        /// <para>The password ARN for the Windows user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobRunAsUser_Windows_PasswordArn")]
        public System.String Windows_PasswordArn { get; set; }
        #endregion
        
        #region Parameter QueueId
        /// <summary>
        /// <para>
        /// <para>The queue ID to update.</para>
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
        public System.String QueueId { get; set; }
        #endregion
        
        #region Parameter RequiredFileSystemLocationNamesToAdd
        /// <summary>
        /// <para>
        /// <para>The required file system location names to add to the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RequiredFileSystemLocationNamesToAdd { get; set; }
        #endregion
        
        #region Parameter RequiredFileSystemLocationNamesToRemove
        /// <summary>
        /// <para>
        /// <para>The required file system location names to remove from the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RequiredFileSystemLocationNamesToRemove { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN that's used to run jobs from this queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter JobAttachmentSettings_RootPrefix
        /// <summary>
        /// <para>
        /// <para>The root prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobAttachmentSettings_RootPrefix { get; set; }
        #endregion
        
        #region Parameter JobRunAsUser_RunAs
        /// <summary>
        /// <para>
        /// <para>Specifies whether the job should run using the queue's system user or if the job should
        /// run using the worker agent system user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.RunAs")]
        public Amazon.Deadline.RunAs JobRunAsUser_RunAs { get; set; }
        #endregion
        
        #region Parameter JobAttachmentSettings_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobAttachmentSettings_S3BucketName { get; set; }
        #endregion
        
        #region Parameter Posix_User
        /// <summary>
        /// <para>
        /// <para>The name of the POSIX user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobRunAsUser_Posix_User")]
        public System.String Posix_User { get; set; }
        #endregion
        
        #region Parameter Windows_User
        /// <summary>
        /// <para>
        /// <para>The user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobRunAsUser_Windows_User")]
        public System.String Windows_User { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token to update in the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.UpdateQueueResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ADCQueue (UpdateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.UpdateQueueResponse, UpdateADCQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedStorageProfileIdsToAdd != null)
            {
                context.AllowedStorageProfileIdsToAdd = new List<System.String>(this.AllowedStorageProfileIdsToAdd);
            }
            if (this.AllowedStorageProfileIdsToRemove != null)
            {
                context.AllowedStorageProfileIdsToRemove = new List<System.String>(this.AllowedStorageProfileIdsToRemove);
            }
            context.ClientToken = this.ClientToken;
            context.DefaultBudgetAction = this.DefaultBudgetAction;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.FarmId = this.FarmId;
            #if MODULAR
            if (this.FarmId == null && ParameterWasBound(nameof(this.FarmId)))
            {
                WriteWarning("You are passing $null as a value for parameter FarmId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobAttachmentSettings_RootPrefix = this.JobAttachmentSettings_RootPrefix;
            context.JobAttachmentSettings_S3BucketName = this.JobAttachmentSettings_S3BucketName;
            context.Posix_Group = this.Posix_Group;
            context.Posix_User = this.Posix_User;
            context.JobRunAsUser_RunAs = this.JobRunAsUser_RunAs;
            context.Windows_PasswordArn = this.Windows_PasswordArn;
            context.Windows_User = this.Windows_User;
            context.QueueId = this.QueueId;
            #if MODULAR
            if (this.QueueId == null && ParameterWasBound(nameof(this.QueueId)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequiredFileSystemLocationNamesToAdd != null)
            {
                context.RequiredFileSystemLocationNamesToAdd = new List<System.String>(this.RequiredFileSystemLocationNamesToAdd);
            }
            if (this.RequiredFileSystemLocationNamesToRemove != null)
            {
                context.RequiredFileSystemLocationNamesToRemove = new List<System.String>(this.RequiredFileSystemLocationNamesToRemove);
            }
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.Deadline.Model.UpdateQueueRequest();
            
            if (cmdletContext.AllowedStorageProfileIdsToAdd != null)
            {
                request.AllowedStorageProfileIdsToAdd = cmdletContext.AllowedStorageProfileIdsToAdd;
            }
            if (cmdletContext.AllowedStorageProfileIdsToRemove != null)
            {
                request.AllowedStorageProfileIdsToRemove = cmdletContext.AllowedStorageProfileIdsToRemove;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DefaultBudgetAction != null)
            {
                request.DefaultBudgetAction = cmdletContext.DefaultBudgetAction;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.FarmId != null)
            {
                request.FarmId = cmdletContext.FarmId;
            }
            
             // populate JobAttachmentSettings
            var requestJobAttachmentSettingsIsNull = true;
            request.JobAttachmentSettings = new Amazon.Deadline.Model.JobAttachmentSettings();
            System.String requestJobAttachmentSettings_jobAttachmentSettings_RootPrefix = null;
            if (cmdletContext.JobAttachmentSettings_RootPrefix != null)
            {
                requestJobAttachmentSettings_jobAttachmentSettings_RootPrefix = cmdletContext.JobAttachmentSettings_RootPrefix;
            }
            if (requestJobAttachmentSettings_jobAttachmentSettings_RootPrefix != null)
            {
                request.JobAttachmentSettings.RootPrefix = requestJobAttachmentSettings_jobAttachmentSettings_RootPrefix;
                requestJobAttachmentSettingsIsNull = false;
            }
            System.String requestJobAttachmentSettings_jobAttachmentSettings_S3BucketName = null;
            if (cmdletContext.JobAttachmentSettings_S3BucketName != null)
            {
                requestJobAttachmentSettings_jobAttachmentSettings_S3BucketName = cmdletContext.JobAttachmentSettings_S3BucketName;
            }
            if (requestJobAttachmentSettings_jobAttachmentSettings_S3BucketName != null)
            {
                request.JobAttachmentSettings.S3BucketName = requestJobAttachmentSettings_jobAttachmentSettings_S3BucketName;
                requestJobAttachmentSettingsIsNull = false;
            }
             // determine if request.JobAttachmentSettings should be set to null
            if (requestJobAttachmentSettingsIsNull)
            {
                request.JobAttachmentSettings = null;
            }
            
             // populate JobRunAsUser
            var requestJobRunAsUserIsNull = true;
            request.JobRunAsUser = new Amazon.Deadline.Model.JobRunAsUser();
            Amazon.Deadline.RunAs requestJobRunAsUser_jobRunAsUser_RunAs = null;
            if (cmdletContext.JobRunAsUser_RunAs != null)
            {
                requestJobRunAsUser_jobRunAsUser_RunAs = cmdletContext.JobRunAsUser_RunAs;
            }
            if (requestJobRunAsUser_jobRunAsUser_RunAs != null)
            {
                request.JobRunAsUser.RunAs = requestJobRunAsUser_jobRunAsUser_RunAs;
                requestJobRunAsUserIsNull = false;
            }
            Amazon.Deadline.Model.PosixUser requestJobRunAsUser_jobRunAsUser_Posix = null;
            
             // populate Posix
            var requestJobRunAsUser_jobRunAsUser_PosixIsNull = true;
            requestJobRunAsUser_jobRunAsUser_Posix = new Amazon.Deadline.Model.PosixUser();
            System.String requestJobRunAsUser_jobRunAsUser_Posix_posix_Group = null;
            if (cmdletContext.Posix_Group != null)
            {
                requestJobRunAsUser_jobRunAsUser_Posix_posix_Group = cmdletContext.Posix_Group;
            }
            if (requestJobRunAsUser_jobRunAsUser_Posix_posix_Group != null)
            {
                requestJobRunAsUser_jobRunAsUser_Posix.Group = requestJobRunAsUser_jobRunAsUser_Posix_posix_Group;
                requestJobRunAsUser_jobRunAsUser_PosixIsNull = false;
            }
            System.String requestJobRunAsUser_jobRunAsUser_Posix_posix_User = null;
            if (cmdletContext.Posix_User != null)
            {
                requestJobRunAsUser_jobRunAsUser_Posix_posix_User = cmdletContext.Posix_User;
            }
            if (requestJobRunAsUser_jobRunAsUser_Posix_posix_User != null)
            {
                requestJobRunAsUser_jobRunAsUser_Posix.User = requestJobRunAsUser_jobRunAsUser_Posix_posix_User;
                requestJobRunAsUser_jobRunAsUser_PosixIsNull = false;
            }
             // determine if requestJobRunAsUser_jobRunAsUser_Posix should be set to null
            if (requestJobRunAsUser_jobRunAsUser_PosixIsNull)
            {
                requestJobRunAsUser_jobRunAsUser_Posix = null;
            }
            if (requestJobRunAsUser_jobRunAsUser_Posix != null)
            {
                request.JobRunAsUser.Posix = requestJobRunAsUser_jobRunAsUser_Posix;
                requestJobRunAsUserIsNull = false;
            }
            Amazon.Deadline.Model.WindowsUser requestJobRunAsUser_jobRunAsUser_Windows = null;
            
             // populate Windows
            var requestJobRunAsUser_jobRunAsUser_WindowsIsNull = true;
            requestJobRunAsUser_jobRunAsUser_Windows = new Amazon.Deadline.Model.WindowsUser();
            System.String requestJobRunAsUser_jobRunAsUser_Windows_windows_PasswordArn = null;
            if (cmdletContext.Windows_PasswordArn != null)
            {
                requestJobRunAsUser_jobRunAsUser_Windows_windows_PasswordArn = cmdletContext.Windows_PasswordArn;
            }
            if (requestJobRunAsUser_jobRunAsUser_Windows_windows_PasswordArn != null)
            {
                requestJobRunAsUser_jobRunAsUser_Windows.PasswordArn = requestJobRunAsUser_jobRunAsUser_Windows_windows_PasswordArn;
                requestJobRunAsUser_jobRunAsUser_WindowsIsNull = false;
            }
            System.String requestJobRunAsUser_jobRunAsUser_Windows_windows_User = null;
            if (cmdletContext.Windows_User != null)
            {
                requestJobRunAsUser_jobRunAsUser_Windows_windows_User = cmdletContext.Windows_User;
            }
            if (requestJobRunAsUser_jobRunAsUser_Windows_windows_User != null)
            {
                requestJobRunAsUser_jobRunAsUser_Windows.User = requestJobRunAsUser_jobRunAsUser_Windows_windows_User;
                requestJobRunAsUser_jobRunAsUser_WindowsIsNull = false;
            }
             // determine if requestJobRunAsUser_jobRunAsUser_Windows should be set to null
            if (requestJobRunAsUser_jobRunAsUser_WindowsIsNull)
            {
                requestJobRunAsUser_jobRunAsUser_Windows = null;
            }
            if (requestJobRunAsUser_jobRunAsUser_Windows != null)
            {
                request.JobRunAsUser.Windows = requestJobRunAsUser_jobRunAsUser_Windows;
                requestJobRunAsUserIsNull = false;
            }
             // determine if request.JobRunAsUser should be set to null
            if (requestJobRunAsUserIsNull)
            {
                request.JobRunAsUser = null;
            }
            if (cmdletContext.QueueId != null)
            {
                request.QueueId = cmdletContext.QueueId;
            }
            if (cmdletContext.RequiredFileSystemLocationNamesToAdd != null)
            {
                request.RequiredFileSystemLocationNamesToAdd = cmdletContext.RequiredFileSystemLocationNamesToAdd;
            }
            if (cmdletContext.RequiredFileSystemLocationNamesToRemove != null)
            {
                request.RequiredFileSystemLocationNamesToRemove = cmdletContext.RequiredFileSystemLocationNamesToRemove;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Deadline.Model.UpdateQueueResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.UpdateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "UpdateQueue");
            try
            {
                #if DESKTOP
                return client.UpdateQueue(request);
                #elif CORECLR
                return client.UpdateQueueAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedStorageProfileIdsToAdd { get; set; }
            public List<System.String> AllowedStorageProfileIdsToRemove { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.Deadline.DefaultQueueBudgetAction DefaultBudgetAction { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String FarmId { get; set; }
            public System.String JobAttachmentSettings_RootPrefix { get; set; }
            public System.String JobAttachmentSettings_S3BucketName { get; set; }
            public System.String Posix_Group { get; set; }
            public System.String Posix_User { get; set; }
            public Amazon.Deadline.RunAs JobRunAsUser_RunAs { get; set; }
            public System.String Windows_PasswordArn { get; set; }
            public System.String Windows_User { get; set; }
            public System.String QueueId { get; set; }
            public List<System.String> RequiredFileSystemLocationNamesToAdd { get; set; }
            public List<System.String> RequiredFileSystemLocationNamesToRemove { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Deadline.Model.UpdateQueueResponse, UpdateADCQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
