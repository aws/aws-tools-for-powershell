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
    /// Sets the transition lifecycle of a recovery point.
    /// 
    ///  
    /// <para>
    /// The lifecycle defines when a protected resource is transitioned to cold storage and
    /// when it expires. AWS Backup transitions and expires backups automatically according
    /// to the lifecycle that you define. 
    /// </para><para>
    /// Backups transitioned to cold storage must be stored in cold storage for a minimum
    /// of 90 days. Therefore, the “expire after days” setting must be 90 days greater than
    /// the “transition to cold after days” setting. The “transition to cold after days” setting
    /// cannot be changed after a backup has been transitioned to cold. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "BAKRecoveryPointLifecycle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse")]
    [AWSCmdlet("Calls the Amazon Backup UpdateRecoveryPointLifecycle API operation.", Operation = new[] {"UpdateRecoveryPointLifecycle"})]
    [AWSCmdletOutput("Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse",
        "This cmdlet returns a Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBAKRecoveryPointLifecycleCmdlet : AmazonBackupClientCmdlet, IExecutor
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
        
        #region Parameter RecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that uniquely identifies a recovery point; for example,
        /// <code>arn:aws:backup:us-east-1:123456789012:recovery-point:1EB3B5E7-9EB0-435A-A80B-108B488B0D45</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RecoveryPointArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RecoveryPointArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKRecoveryPointLifecycle (UpdateRecoveryPointLifecycle)"))
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
            if (ParameterWasBound("Lifecycle_DeleteAfterDay"))
                context.Lifecycle_DeleteAfterDays = this.Lifecycle_DeleteAfterDay;
            if (ParameterWasBound("Lifecycle_MoveToColdStorageAfterDay"))
                context.Lifecycle_MoveToColdStorageAfterDays = this.Lifecycle_MoveToColdStorageAfterDay;
            context.RecoveryPointArn = this.RecoveryPointArn;
            
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
            var request = new Amazon.Backup.Model.UpdateRecoveryPointLifecycleRequest();
            
            if (cmdletContext.BackupVaultName != null)
            {
                request.BackupVaultName = cmdletContext.BackupVaultName;
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
            if (cmdletContext.RecoveryPointArn != null)
            {
                request.RecoveryPointArn = cmdletContext.RecoveryPointArn;
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
        
        private Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateRecoveryPointLifecycleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Backup", "UpdateRecoveryPointLifecycle");
            try
            {
                #if DESKTOP
                return client.UpdateRecoveryPointLifecycle(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRecoveryPointLifecycleAsync(request);
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
            public System.Int64? Lifecycle_DeleteAfterDays { get; set; }
            public System.Int64? Lifecycle_MoveToColdStorageAfterDays { get; set; }
            public System.String RecoveryPointArn { get; set; }
        }
        
    }
}
