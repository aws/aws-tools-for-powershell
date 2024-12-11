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
using Amazon.Deadline;
using Amazon.Deadline.Model;

namespace Amazon.PowerShell.Cmdlets.ADC
{
    /// <summary>
    /// Creates a queue to coordinate the order in which jobs run on a farm. A queue can also
    /// specify where to pull resources and indicate where to output completed jobs.
    /// </summary>
    [Cmdlet("New", "ADCQueue", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSDeadlineCloud CreateQueue API operation.", Operation = new[] {"CreateQueue"}, SelectReturnType = typeof(Amazon.Deadline.Model.CreateQueueResponse))]
    [AWSCmdletOutput("System.String or Amazon.Deadline.Model.CreateQueueResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Deadline.Model.CreateQueueResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewADCQueueCmdlet : AmazonDeadlineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowedStorageProfileId
        /// <summary>
        /// <para>
        /// <para>The storage profile IDs to include in the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedStorageProfileIds")]
        public System.String[] AllowedStorageProfileId { get; set; }
        #endregion
        
        #region Parameter DefaultBudgetAction
        /// <summary>
        /// <para>
        /// <para>The default action to take on a queue if a budget isn't configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Deadline.DefaultQueueBudgetAction")]
        public Amazon.Deadline.DefaultQueueBudgetAction DefaultBudgetAction { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the queue.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the queue.</para><important><para>This field can store any content. Escape or encode this content before displaying
        /// it on a webpage or any other system that might interpret the content of this field.</para></important>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter FarmId
        /// <summary>
        /// <para>
        /// <para>The farm ID of the farm to connect to the queue.</para>
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
        
        #region Parameter RequiredFileSystemLocationName
        /// <summary>
        /// <para>
        /// <para>The file system location name to include in the queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequiredFileSystemLocationNames")]
        public System.String[] RequiredFileSystemLocationName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role ARN that workers will use while running jobs for this queue.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Each tag consists of a tag key and a tag value. Tag keys and values are both required,
        /// but tag values can be empty strings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// <para>The unique token which the server uses to recognize retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'QueueId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Deadline.Model.CreateQueueResponse).
        /// Specifying the name of a property of type Amazon.Deadline.Model.CreateQueueResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "QueueId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ADCQueue (CreateQueue)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Deadline.Model.CreateQueueResponse, NewADCQueueCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedStorageProfileId != null)
            {
                context.AllowedStorageProfileId = new List<System.String>(this.AllowedStorageProfileId);
            }
            context.ClientToken = this.ClientToken;
            context.DefaultBudgetAction = this.DefaultBudgetAction;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.RequiredFileSystemLocationName != null)
            {
                context.RequiredFileSystemLocationName = new List<System.String>(this.RequiredFileSystemLocationName);
            }
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Deadline.Model.CreateQueueRequest();
            
            if (cmdletContext.AllowedStorageProfileId != null)
            {
                request.AllowedStorageProfileIds = cmdletContext.AllowedStorageProfileId;
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
            if (cmdletContext.RequiredFileSystemLocationName != null)
            {
                request.RequiredFileSystemLocationNames = cmdletContext.RequiredFileSystemLocationName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Deadline.Model.CreateQueueResponse CallAWSServiceOperation(IAmazonDeadline client, Amazon.Deadline.Model.CreateQueueRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSDeadlineCloud", "CreateQueue");
            try
            {
                #if DESKTOP
                return client.CreateQueue(request);
                #elif CORECLR
                return client.CreateQueueAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedStorageProfileId { get; set; }
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
            public List<System.String> RequiredFileSystemLocationName { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Deadline.Model.CreateQueueResponse, NewADCQueueCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.QueueId;
        }
        
    }
}
