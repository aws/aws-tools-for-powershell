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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Starts a job to create a one-time backup of the specified resource.
    /// </summary>
    [Cmdlet("Start", "BAKBackupJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.StartBackupJobResponse")]
    [AWSCmdlet("Calls the Amazon Backup StartBackupJob API operation.", Operation = new[] {"StartBackupJob"})]
    [AWSCmdletOutput("Amazon.Backup.Model.StartBackupJobResponse",
        "This cmdlet returns a Amazon.Backup.Model.StartBackupJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartBAKBackupJobCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        #region Parameter BackupVaultName
        /// <summary>
        /// <para>
        /// <para>The name of a logical container where backups are stored. Backup vaults are identified
        /// by names that are unique to the account used to create them and the AWS Region where
        /// they are created. They consist of lowercase letters, numbers, and hyphens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackupVaultName { get; set; }
        #endregion
        
        #region Parameter CompleteWindowMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time AWS Backup attempts a backup before canceling the job and returning
        /// an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CompleteWindowMinutes")]
        public System.Int64 CompleteWindowMinute { get; set; }
        #endregion
        
        #region Parameter Lifecycle_DeleteAfterDay
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days after creation that a recovery point is deleted. Must
        /// be greater than <code>MoveToColdStorageAfterDays</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Lifecycle_DeleteAfterDays")]
        public System.Int64 Lifecycle_DeleteAfterDay { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the IAM role ARN used to create the target recovery point; for example,
        /// <code>arn:aws:iam::123456789012:role/S3Access</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A customer chosen string that can be used to distinguish between calls to <code>StartBackupJob</code>.
        /// Idempotency tokens time out after one hour. Therefore, if you call <code>StartBackupJob</code>
        /// multiple times with the same idempotency token within one hour, AWS Backup recognizes
        /// that you are requesting only one backup job and initiates only one. If you change
        /// the idempotency token for each call, AWS Backup recognizes that you are requesting
        /// to start multiple backups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Lifecycle_MoveToColdStorageAfterDay
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days after creation that a recovery point is moved to cold
        /// storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Lifecycle_MoveToColdStorageAfterDays")]
        public System.Int64 Lifecycle_MoveToColdStorageAfterDay { get; set; }
        #endregion
        
        #region Parameter RecoveryPointTag
        /// <summary>
        /// <para>
        /// <para>To help organize your resources, you can assign your own metadata to the resources
        /// that you create. Each tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RecoveryPointTags")]
        public System.Collections.Hashtable RecoveryPointTag { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that uniquely identifies a resource. The format of the
        /// ARN depends on the resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter StartWindowMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time in minutes before beginning a backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StartWindowMinutes")]
        public System.Int64 StartWindowMinute { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKBackupJob (StartBackupJob)"))
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
            
            context.BackupVaultName = this.BackupVaultName;
            if (ParameterWasBound("CompleteWindowMinute"))
                context.CompleteWindowMinutes = this.CompleteWindowMinute;
            context.IamRoleArn = this.IamRoleArn;
            context.IdempotencyToken = this.IdempotencyToken;
            if (ParameterWasBound("Lifecycle_DeleteAfterDay"))
                context.Lifecycle_DeleteAfterDays = this.Lifecycle_DeleteAfterDay;
            if (ParameterWasBound("Lifecycle_MoveToColdStorageAfterDay"))
                context.Lifecycle_MoveToColdStorageAfterDays = this.Lifecycle_MoveToColdStorageAfterDay;
            if (this.RecoveryPointTag != null)
            {
                context.RecoveryPointTags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RecoveryPointTag.Keys)
                {
                    context.RecoveryPointTags.Add((String)hashKey, (String)(this.RecoveryPointTag[hashKey]));
                }
            }
            context.ResourceArn = this.ResourceArn;
            if (ParameterWasBound("StartWindowMinute"))
                context.StartWindowMinutes = this.StartWindowMinute;
            
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
            var request = new Amazon.Backup.Model.StartBackupJobRequest();
            
            if (cmdletContext.BackupVaultName != null)
            {
                request.BackupVaultName = cmdletContext.BackupVaultName;
            }
            if (cmdletContext.CompleteWindowMinutes != null)
            {
                request.CompleteWindowMinutes = cmdletContext.CompleteWindowMinutes.Value;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            
             // populate Lifecycle
            bool requestLifecycleIsNull = true;
            request.Lifecycle = new Amazon.Backup.Model.Lifecycle();
            System.Int64? requestLifecycle_lifecycle_DeleteAfterDay = null;
            if (cmdletContext.Lifecycle_DeleteAfterDays != null)
            {
                requestLifecycle_lifecycle_DeleteAfterDay = cmdletContext.Lifecycle_DeleteAfterDays.Value;
            }
            if (requestLifecycle_lifecycle_DeleteAfterDay != null)
            {
                request.Lifecycle.DeleteAfterDays = requestLifecycle_lifecycle_DeleteAfterDay.Value;
                requestLifecycleIsNull = false;
            }
            System.Int64? requestLifecycle_lifecycle_MoveToColdStorageAfterDay = null;
            if (cmdletContext.Lifecycle_MoveToColdStorageAfterDays != null)
            {
                requestLifecycle_lifecycle_MoveToColdStorageAfterDay = cmdletContext.Lifecycle_MoveToColdStorageAfterDays.Value;
            }
            if (requestLifecycle_lifecycle_MoveToColdStorageAfterDay != null)
            {
                request.Lifecycle.MoveToColdStorageAfterDays = requestLifecycle_lifecycle_MoveToColdStorageAfterDay.Value;
                requestLifecycleIsNull = false;
            }
             // determine if request.Lifecycle should be set to null
            if (requestLifecycleIsNull)
            {
                request.Lifecycle = null;
            }
            if (cmdletContext.RecoveryPointTags != null)
            {
                request.RecoveryPointTags = cmdletContext.RecoveryPointTags;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            if (cmdletContext.StartWindowMinutes != null)
            {
                request.StartWindowMinutes = cmdletContext.StartWindowMinutes.Value;
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
        
        private Amazon.Backup.Model.StartBackupJobResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.StartBackupJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Backup", "StartBackupJob");
            try
            {
                #if DESKTOP
                return client.StartBackupJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartBackupJobAsync(request);
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
            public System.String BackupVaultName { get; set; }
            public System.Int64? CompleteWindowMinutes { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.Int64? Lifecycle_DeleteAfterDays { get; set; }
            public System.Int64? Lifecycle_MoveToColdStorageAfterDays { get; set; }
            public Dictionary<System.String, System.String> RecoveryPointTags { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Int64? StartWindowMinutes { get; set; }
        }
        
    }
}
