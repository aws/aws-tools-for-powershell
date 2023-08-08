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
    /// Starts an on-demand backup job for the specified resource.
    /// </summary>
    [Cmdlet("Start", "BAKBackupJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.StartBackupJobResponse")]
    [AWSCmdlet("Calls the AWS Backup StartBackupJob API operation.", Operation = new[] {"StartBackupJob"}, SelectReturnType = typeof(Amazon.Backup.Model.StartBackupJobResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.StartBackupJobResponse",
        "This cmdlet returns an Amazon.Backup.Model.StartBackupJobResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartBAKBackupJobCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter BackupOption
        /// <summary>
        /// <para>
        /// <para>Specifies the backup option for a selected resource. This option is only available
        /// for Windows Volume Shadow Copy Service (VSS) backup jobs.</para><para>Valid values: Set to <code>"WindowsVSS":"enabled"</code> to enable the <code>WindowsVSS</code>
        /// backup option and create a Windows VSS backup. Set to <code>"WindowsVSS""disabled"</code>
        /// to create a regular backup. The <code>WindowsVSS</code> option is not enabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupOptions")]
        public System.Collections.Hashtable BackupOption { get; set; }
        #endregion
        
        #region Parameter BackupVaultName
        /// <summary>
        /// <para>
        /// <para>The name of a logical container where backups are stored. Backup vaults are identified
        /// by names that are unique to the account used to create them and the Amazon Web Services
        /// Region where they are created. They consist of lowercase letters, numbers, and hyphens.</para>
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
        
        #region Parameter CompleteWindowMinute
        /// <summary>
        /// <para>
        /// <para>A value in minutes during which a successfully started backup must complete, or else
        /// Backup will cancel the job. This value is optional. This value begins counting down
        /// from when the backup was scheduled. It does not add additional time for <code>StartWindowMinutes</code>,
        /// or if the backup started later than scheduled.</para><para>Like <code>StartWindowMinutes</code>, this parameter has a maximum value of 100 years
        /// (52,560,000 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompleteWindowMinutes")]
        public System.Int64? CompleteWindowMinute { get; set; }
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
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the IAM role ARN used to create the target recovery point; for example,
        /// <code>arn:aws:iam::123456789012:role/S3Access</code>.</para>
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
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A customer-chosen string that you can use to distinguish between otherwise identical
        /// calls to <code>StartBackupJob</code>. Retrying a successful request with the same
        /// idempotency token results in a success message with no action taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
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
        
        #region Parameter RecoveryPointTag
        /// <summary>
        /// <para>
        /// <para>To help organize your resources, you can assign your own metadata to the resources
        /// that you create. Each tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter StartWindowMinute
        /// <summary>
        /// <para>
        /// <para>A value in minutes after a backup is scheduled before a job will be canceled if it
        /// doesn't start successfully. This value is optional, and the default is 8 hours. If
        /// this value is included, it must be at least 60 minutes to avoid errors.</para><para>This parameter has a maximum value of 100 years (52,560,000 minutes).</para><para>During the start window, the backup job status remains in <code>CREATED</code> status
        /// until it has successfully begun or until the start window time has run out. If within
        /// the start window time Backup receives an error that allows the job to be retried,
        /// Backup will automatically retry to begin the job at least every 10 minutes until the
        /// backup successfully begins (the job status changes to <code>RUNNING</code>) or until
        /// the job status changes to <code>EXPIRED</code> (which is expected to occur when the
        /// start window time is over).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StartWindowMinutes")]
        public System.Int64? StartWindowMinute { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.StartBackupJobResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.StartBackupJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceArn' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKBackupJob (StartBackupJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.StartBackupJobResponse, StartBAKBackupJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BackupOption != null)
            {
                context.BackupOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BackupOption.Keys)
                {
                    context.BackupOption.Add((String)hashKey, (String)(this.BackupOption[hashKey]));
                }
            }
            context.BackupVaultName = this.BackupVaultName;
            #if MODULAR
            if (this.BackupVaultName == null && ParameterWasBound(nameof(this.BackupVaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupVaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CompleteWindowMinute = this.CompleteWindowMinute;
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.Lifecycle_DeleteAfterDay = this.Lifecycle_DeleteAfterDay;
            context.Lifecycle_MoveToColdStorageAfterDay = this.Lifecycle_MoveToColdStorageAfterDay;
            if (this.RecoveryPointTag != null)
            {
                context.RecoveryPointTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RecoveryPointTag.Keys)
                {
                    context.RecoveryPointTag.Add((String)hashKey, (String)(this.RecoveryPointTag[hashKey]));
                }
            }
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartWindowMinute = this.StartWindowMinute;
            
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
            
            if (cmdletContext.BackupOption != null)
            {
                request.BackupOptions = cmdletContext.BackupOption;
            }
            if (cmdletContext.BackupVaultName != null)
            {
                request.BackupVaultName = cmdletContext.BackupVaultName;
            }
            if (cmdletContext.CompleteWindowMinute != null)
            {
                request.CompleteWindowMinutes = cmdletContext.CompleteWindowMinute.Value;
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
            if (cmdletContext.RecoveryPointTag != null)
            {
                request.RecoveryPointTags = cmdletContext.RecoveryPointTag;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            if (cmdletContext.StartWindowMinute != null)
            {
                request.StartWindowMinutes = cmdletContext.StartWindowMinute.Value;
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
        
        private Amazon.Backup.Model.StartBackupJobResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.StartBackupJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "StartBackupJob");
            try
            {
                #if DESKTOP
                return client.StartBackupJob(request);
                #elif CORECLR
                return client.StartBackupJobAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> BackupOption { get; set; }
            public System.String BackupVaultName { get; set; }
            public System.Int64? CompleteWindowMinute { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.Int64? Lifecycle_DeleteAfterDay { get; set; }
            public System.Int64? Lifecycle_MoveToColdStorageAfterDay { get; set; }
            public Dictionary<System.String, System.String> RecoveryPointTag { get; set; }
            public System.String ResourceArn { get; set; }
            public System.Int64? StartWindowMinute { get; set; }
            public System.Func<Amazon.Backup.Model.StartBackupJobResponse, StartBAKBackupJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
