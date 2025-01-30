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
    /// Applies Backup Vault Lock to a backup vault, preventing attempts to delete any recovery
    /// point stored in or created in a backup vault. Vault Lock also prevents attempts to
    /// update the lifecycle policy that controls the retention period of any recovery point
    /// currently stored in a backup vault. If specified, Vault Lock enforces a minimum and
    /// maximum retention period for future backup and copy jobs that target a backup vault.
    /// 
    ///  <note><para>
    /// Backup Vault Lock has been assessed by Cohasset Associates for use in environments
    /// that are subject to SEC 17a-4, CFTC, and FINRA regulations. For more information about
    /// how Backup Vault Lock relates to these regulations, see the <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/samples/cohassetreport.zip">Cohasset
    /// Associates Compliance Assessment.</a></para></note><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/aws-backup/latest/devguide/vault-lock.html">Backup
    /// Vault Lock</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "BAKBackupVaultLockConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Backup PutBackupVaultLockConfiguration API operation.", Operation = new[] {"PutBackupVaultLockConfiguration"}, SelectReturnType = typeof(Amazon.Backup.Model.PutBackupVaultLockConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Backup.Model.PutBackupVaultLockConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Backup.Model.PutBackupVaultLockConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteBAKBackupVaultLockConfigurationCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupVaultName
        /// <summary>
        /// <para>
        /// <para>The Backup Vault Lock configuration that specifies the name of the backup vault it
        /// protects.</para>
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
        public System.String BackupVaultName { get; set; }
        #endregion
        
        #region Parameter ChangeableForDay
        /// <summary>
        /// <para>
        /// <para>The Backup Vault Lock configuration that specifies the number of days before the lock
        /// date. For example, setting <c>ChangeableForDays</c> to 30 on Jan. 1, 2022 at 8pm UTC
        /// will set the lock date to Jan. 31, 2022 at 8pm UTC.</para><para>Backup enforces a 72-hour cooling-off period before Vault Lock takes effect and becomes
        /// immutable. Therefore, you must set <c>ChangeableForDays</c> to 3 or greater.</para><para>Before the lock date, you can delete Vault Lock from the vault using <c>DeleteBackupVaultLockConfiguration</c>
        /// or change the Vault Lock configuration using <c>PutBackupVaultLockConfiguration</c>.
        /// On and after the lock date, the Vault Lock becomes immutable and cannot be changed
        /// or deleted.</para><para>If this parameter is not specified, you can delete Vault Lock from the vault using
        /// <c>DeleteBackupVaultLockConfiguration</c> or change the Vault Lock configuration using
        /// <c>PutBackupVaultLockConfiguration</c> at any time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChangeableForDays")]
        public System.Int64? ChangeableForDay { get; set; }
        #endregion
        
        #region Parameter MaxRetentionDay
        /// <summary>
        /// <para>
        /// <para>The Backup Vault Lock configuration that specifies the maximum retention period that
        /// the vault retains its recovery points. This setting can be useful if, for example,
        /// your organization's policies require you to destroy certain data after retaining it
        /// for four years (1460 days).</para><para>If this parameter is not included, Vault Lock does not enforce a maximum retention
        /// period on the recovery points in the vault. If this parameter is included without
        /// a value, Vault Lock will not enforce a maximum retention period.</para><para>If this parameter is specified, any backup or copy job to the vault must have a lifecycle
        /// policy with a retention period equal to or shorter than the maximum retention period.
        /// If the job's retention period is longer than that maximum retention period, then the
        /// vault fails the backup or copy job, and you should either modify your lifecycle settings
        /// or use a different vault. The longest maximum retention period you can specify is
        /// 36500 days (approximately 100 years). Recovery points already saved in the vault prior
        /// to Vault Lock are not affected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRetentionDays")]
        public System.Int64? MaxRetentionDay { get; set; }
        #endregion
        
        #region Parameter MinRetentionDay
        /// <summary>
        /// <para>
        /// <para>The Backup Vault Lock configuration that specifies the minimum retention period that
        /// the vault retains its recovery points. This setting can be useful if, for example,
        /// your organization's policies require you to retain certain data for at least seven
        /// years (2555 days).</para><para>This parameter is required when a vault lock is created through CloudFormation; otherwise,
        /// this parameter is optional. If this parameter is not specified, Vault Lock will not
        /// enforce a minimum retention period.</para><para>If this parameter is specified, any backup or copy job to the vault must have a lifecycle
        /// policy with a retention period equal to or longer than the minimum retention period.
        /// If the job's retention period is shorter than that minimum retention period, then
        /// the vault fails that backup or copy job, and you should either modify your lifecycle
        /// settings or use a different vault. The shortest minimum retention period you can specify
        /// is 1 day. Recovery points already saved in the vault prior to Vault Lock are not affected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinRetentionDays")]
        public System.Int64? MinRetentionDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.PutBackupVaultLockConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BackupVaultName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BackupVaultName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BackupVaultName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BackupVaultName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BAKBackupVaultLockConfiguration (PutBackupVaultLockConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.PutBackupVaultLockConfigurationResponse, WriteBAKBackupVaultLockConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BackupVaultName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupVaultName = this.BackupVaultName;
            #if MODULAR
            if (this.BackupVaultName == null && ParameterWasBound(nameof(this.BackupVaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupVaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChangeableForDay = this.ChangeableForDay;
            context.MaxRetentionDay = this.MaxRetentionDay;
            context.MinRetentionDay = this.MinRetentionDay;
            
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
            var request = new Amazon.Backup.Model.PutBackupVaultLockConfigurationRequest();
            
            if (cmdletContext.BackupVaultName != null)
            {
                request.BackupVaultName = cmdletContext.BackupVaultName;
            }
            if (cmdletContext.ChangeableForDay != null)
            {
                request.ChangeableForDays = cmdletContext.ChangeableForDay.Value;
            }
            if (cmdletContext.MaxRetentionDay != null)
            {
                request.MaxRetentionDays = cmdletContext.MaxRetentionDay.Value;
            }
            if (cmdletContext.MinRetentionDay != null)
            {
                request.MinRetentionDays = cmdletContext.MinRetentionDay.Value;
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
        
        private Amazon.Backup.Model.PutBackupVaultLockConfigurationResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.PutBackupVaultLockConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "PutBackupVaultLockConfiguration");
            try
            {
                #if DESKTOP
                return client.PutBackupVaultLockConfiguration(request);
                #elif CORECLR
                return client.PutBackupVaultLockConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? ChangeableForDay { get; set; }
            public System.Int64? MaxRetentionDay { get; set; }
            public System.Int64? MinRetentionDay { get; set; }
            public System.Func<Amazon.Backup.Model.PutBackupVaultLockConfigurationResponse, WriteBAKBackupVaultLockConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
