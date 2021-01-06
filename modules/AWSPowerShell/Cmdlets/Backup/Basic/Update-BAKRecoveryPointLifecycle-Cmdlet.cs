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
    /// </para><para>
    /// Only Amazon EFS file system backups can be transitioned to cold storage.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "BAKRecoveryPointLifecycle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse")]
    [AWSCmdlet("Calls the AWS Backup UpdateRecoveryPointLifecycle API operation.", Operation = new[] {"UpdateRecoveryPointLifecycle"}, SelectReturnType = typeof(Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse",
        "This cmdlet returns an Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BackupVaultName { get; set; }
        #endregion
        
        #region Parameter Lifecycle_DeleteAfterDay
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days after creation that a recovery point is deleted. Must
        /// be greater than 90 days plus <code>MoveToColdStorageAfterDays</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Lifecycle_DeleteAfterDays")]
        public System.Int64? Lifecycle_DeleteAfterDay { get; set; }
        #endregion
        
        #region Parameter Lifecycle_MoveToColdStorageAfterDay
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days after creation that a recovery point is moved to cold
        /// storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Lifecycle_MoveToColdStorageAfterDays")]
        public System.Int64? Lifecycle_MoveToColdStorageAfterDay { get; set; }
        #endregion
        
        #region Parameter RecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that uniquely identifies a recovery point; for example,
        /// <code>arn:aws:backup:us-east-1:123456789012:recovery-point:1EB3B5E7-9EB0-435A-A80B-108B488B0D45</code>.</para>
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
        public System.String RecoveryPointArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RecoveryPointArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RecoveryPointArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RecoveryPointArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecoveryPointArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKRecoveryPointLifecycle (UpdateRecoveryPointLifecycle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse, UpdateBAKRecoveryPointLifecycleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RecoveryPointArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupVaultName = this.BackupVaultName;
            #if MODULAR
            if (this.BackupVaultName == null && ParameterWasBound(nameof(this.BackupVaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupVaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Lifecycle_DeleteAfterDay = this.Lifecycle_DeleteAfterDay;
            context.Lifecycle_MoveToColdStorageAfterDay = this.Lifecycle_MoveToColdStorageAfterDay;
            context.RecoveryPointArn = this.RecoveryPointArn;
            #if MODULAR
            if (this.RecoveryPointArn == null && ParameterWasBound(nameof(this.RecoveryPointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var requestLifecycleIsNull = true;
            request.Lifecycle = new Amazon.Backup.Model.Lifecycle();
            System.Int64? requestLifecycle_lifecycle_DeleteAfterDay = null;
            if (cmdletContext.Lifecycle_DeleteAfterDay != null)
            {
                requestLifecycle_lifecycle_DeleteAfterDay = cmdletContext.Lifecycle_DeleteAfterDay.Value;
            }
            if (requestLifecycle_lifecycle_DeleteAfterDay != null)
            {
                request.Lifecycle.DeleteAfterDays = requestLifecycle_lifecycle_DeleteAfterDay.Value;
                requestLifecycleIsNull = false;
            }
            System.Int64? requestLifecycle_lifecycle_MoveToColdStorageAfterDay = null;
            if (cmdletContext.Lifecycle_MoveToColdStorageAfterDay != null)
            {
                requestLifecycle_lifecycle_MoveToColdStorageAfterDay = cmdletContext.Lifecycle_MoveToColdStorageAfterDay.Value;
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
        
        private Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateRecoveryPointLifecycleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "UpdateRecoveryPointLifecycle");
            try
            {
                #if DESKTOP
                return client.UpdateRecoveryPointLifecycle(request);
                #elif CORECLR
                return client.UpdateRecoveryPointLifecycleAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? Lifecycle_DeleteAfterDay { get; set; }
            public System.Int64? Lifecycle_MoveToColdStorageAfterDay { get; set; }
            public System.String RecoveryPointArn { get; set; }
            public System.Func<Amazon.Backup.Model.UpdateRecoveryPointLifecycleResponse, UpdateBAKRecoveryPointLifecycleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
