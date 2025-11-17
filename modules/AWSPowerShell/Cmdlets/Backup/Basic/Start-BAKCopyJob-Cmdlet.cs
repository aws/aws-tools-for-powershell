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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Starts a job to create a one-time copy of the specified resource.
    /// 
    ///  
    /// <para>
    /// Does not support continuous backups.
    /// </para><para>
    /// See <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/recov-point-create-a-copy.html#backup-copy-retry">Copy
    /// job retry</a> for information on how Backup retries copy job operations.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "BAKCopyJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.StartCopyJobResponse")]
    [AWSCmdlet("Calls the AWS Backup StartCopyJob API operation.", Operation = new[] {"StartCopyJob"}, SelectReturnType = typeof(Amazon.Backup.Model.StartCopyJobResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.StartCopyJobResponse",
        "This cmdlet returns an Amazon.Backup.Model.StartCopyJobResponse object containing multiple properties."
    )]
    public partial class StartBAKCopyJobCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Lifecycle_DeleteAfterDay
        /// <summary>
        /// <para>
        /// <para>The number of days after creation that a recovery point is deleted. This value must
        /// be at least 90 days after the number of days specified in <c>MoveToColdStorageAfterDays</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Lifecycle_DeleteAfterDays")]
        public System.Int64? Lifecycle_DeleteAfterDay { get; set; }
        #endregion
        
        #region Parameter Lifecycle_DeleteAfterEvent
        /// <summary>
        /// <para>
        /// <para>The event after which a recovery point is deleted. A recovery point with both <c>DeleteAfterDays</c>
        /// and <c>DeleteAfterEvent</c> will delete after whichever condition is satisfied first.
        /// Not valid as an input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Backup.LifecycleDeleteAfterEvent")]
        public Amazon.Backup.LifecycleDeleteAfterEvent Lifecycle_DeleteAfterEvent { get; set; }
        #endregion
        
        #region Parameter DestinationBackupVaultArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that uniquely identifies a destination backup vault
        /// to copy to; for example, <c>arn:aws:backup:us-east-1:123456789012:backup-vault:aBackupVault</c>.</para>
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
        public System.String DestinationBackupVaultArn { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the IAM role ARN used to copy the target recovery point; for example, <c>arn:aws:iam::123456789012:role/S3Access</c>.</para>
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
        /// calls to <c>StartCopyJob</c>. Retrying a successful request with the same idempotency
        /// token results in a success message with no action taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Lifecycle_MoveToColdStorageAfterDay
        /// <summary>
        /// <para>
        /// <para>The number of days after creation that a recovery point is moved to cold storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Lifecycle_MoveToColdStorageAfterDays")]
        public System.Int64? Lifecycle_MoveToColdStorageAfterDay { get; set; }
        #endregion
        
        #region Parameter Lifecycle_OptInToArchiveForSupportedResource
        /// <summary>
        /// <para>
        /// <para>If the value is true, your backup plan transitions supported resources to archive
        /// (cold) storage tier in accordance with your lifecycle settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Lifecycle_OptInToArchiveForSupportedResources")]
        public System.Boolean? Lifecycle_OptInToArchiveForSupportedResource { get; set; }
        #endregion
        
        #region Parameter RecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>An ARN that uniquely identifies a recovery point to use for the copy job; for example,
        /// arn:aws:backup:us-east-1:123456789012:recovery-point:1EB3B5E7-9EB0-435A-A80B-108B488B0D45.
        /// </para>
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
        public System.String RecoveryPointArn { get; set; }
        #endregion
        
        #region Parameter SourceBackupVaultName
        /// <summary>
        /// <para>
        /// <para>The name of a logical source container where backups are stored. Backup vaults are
        /// identified by names that are unique to the account used to create them and the Amazon
        /// Web Services Region where they are created.</para>
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
        public System.String SourceBackupVaultName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.StartCopyJobResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.StartCopyJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceBackupVaultName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceBackupVaultName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceBackupVaultName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceBackupVaultName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BAKCopyJob (StartCopyJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.StartCopyJobResponse, StartBAKCopyJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceBackupVaultName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DestinationBackupVaultArn = this.DestinationBackupVaultArn;
            #if MODULAR
            if (this.DestinationBackupVaultArn == null && ParameterWasBound(nameof(this.DestinationBackupVaultArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationBackupVaultArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamRoleArn = this.IamRoleArn;
            #if MODULAR
            if (this.IamRoleArn == null && ParameterWasBound(nameof(this.IamRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.Lifecycle_DeleteAfterDay = this.Lifecycle_DeleteAfterDay;
            context.Lifecycle_DeleteAfterEvent = this.Lifecycle_DeleteAfterEvent;
            context.Lifecycle_MoveToColdStorageAfterDay = this.Lifecycle_MoveToColdStorageAfterDay;
            context.Lifecycle_OptInToArchiveForSupportedResource = this.Lifecycle_OptInToArchiveForSupportedResource;
            context.RecoveryPointArn = this.RecoveryPointArn;
            #if MODULAR
            if (this.RecoveryPointArn == null && ParameterWasBound(nameof(this.RecoveryPointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceBackupVaultName = this.SourceBackupVaultName;
            #if MODULAR
            if (this.SourceBackupVaultName == null && ParameterWasBound(nameof(this.SourceBackupVaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceBackupVaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.StartCopyJobRequest();
            
            if (cmdletContext.DestinationBackupVaultArn != null)
            {
                request.DestinationBackupVaultArn = cmdletContext.DestinationBackupVaultArn;
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
            Amazon.Backup.LifecycleDeleteAfterEvent requestLifecycle_lifecycle_DeleteAfterEvent = null;
            if (cmdletContext.Lifecycle_DeleteAfterEvent != null)
            {
                requestLifecycle_lifecycle_DeleteAfterEvent = cmdletContext.Lifecycle_DeleteAfterEvent;
            }
            if (requestLifecycle_lifecycle_DeleteAfterEvent != null)
            {
                request.Lifecycle.DeleteAfterEvent = requestLifecycle_lifecycle_DeleteAfterEvent;
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
            System.Boolean? requestLifecycle_lifecycle_OptInToArchiveForSupportedResource = null;
            if (cmdletContext.Lifecycle_OptInToArchiveForSupportedResource != null)
            {
                requestLifecycle_lifecycle_OptInToArchiveForSupportedResource = cmdletContext.Lifecycle_OptInToArchiveForSupportedResource.Value;
            }
            if (requestLifecycle_lifecycle_OptInToArchiveForSupportedResource != null)
            {
                request.Lifecycle.OptInToArchiveForSupportedResources = requestLifecycle_lifecycle_OptInToArchiveForSupportedResource.Value;
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
            if (cmdletContext.SourceBackupVaultName != null)
            {
                request.SourceBackupVaultName = cmdletContext.SourceBackupVaultName;
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
        
        private Amazon.Backup.Model.StartCopyJobResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.StartCopyJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "StartCopyJob");
            try
            {
                #if DESKTOP
                return client.StartCopyJob(request);
                #elif CORECLR
                return client.StartCopyJobAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationBackupVaultArn { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.Int64? Lifecycle_DeleteAfterDay { get; set; }
            public Amazon.Backup.LifecycleDeleteAfterEvent Lifecycle_DeleteAfterEvent { get; set; }
            public System.Int64? Lifecycle_MoveToColdStorageAfterDay { get; set; }
            public System.Boolean? Lifecycle_OptInToArchiveForSupportedResource { get; set; }
            public System.String RecoveryPointArn { get; set; }
            public System.String SourceBackupVaultName { get; set; }
            public System.Func<Amazon.Backup.Model.StartCopyJobResponse, StartBAKCopyJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
