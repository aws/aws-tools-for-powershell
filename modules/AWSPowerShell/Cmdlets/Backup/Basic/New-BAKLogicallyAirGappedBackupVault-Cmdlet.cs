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
    /// Creates a logical container to where backups may be copied.
    /// 
    ///  
    /// <para>
    /// This request includes a name, the Region, the maximum number of retention days, the
    /// minimum number of retention days, and optionally can include tags and a creator request
    /// ID.
    /// </para><note><para>
    /// Do not include sensitive data, such as passport numbers, in the name of a backup vault.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "BAKLogicallyAirGappedBackupVault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateLogicallyAirGappedBackupVault API operation.", Operation = new[] {"CreateLogicallyAirGappedBackupVault"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse object containing multiple properties."
    )]
    public partial class NewBAKLogicallyAirGappedBackupVaultCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupVaultName
        /// <summary>
        /// <para>
        /// <para>The name of a logical container where backups are stored. Logically air-gapped backup
        /// vaults are identified by names that are unique to the account used to create them
        /// and the Region where they are created.</para>
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
        
        #region Parameter BackupVaultTag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupVaultTags")]
        public System.Collections.Hashtable BackupVaultTag { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>The ID of the creation request.</para><para>This parameter is optional. If used, this parameter must contain 1 to 50 alphanumeric
        /// or '-_.' characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter MaxRetentionDay
        /// <summary>
        /// <para>
        /// <para>The maximum retention period that the vault retains its recovery points.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MaxRetentionDays")]
        public System.Int64? MaxRetentionDay { get; set; }
        #endregion
        
        #region Parameter MinRetentionDay
        /// <summary>
        /// <para>
        /// <para>This setting specifies the minimum retention period that the vault retains its recovery
        /// points.</para><para>The minimum value accepted is 7 days.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MinRetentionDays")]
        public System.Int64? MinRetentionDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BackupVaultName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKLogicallyAirGappedBackupVault (CreateLogicallyAirGappedBackupVault)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse, NewBAKLogicallyAirGappedBackupVaultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BackupVaultName = this.BackupVaultName;
            #if MODULAR
            if (this.BackupVaultName == null && ParameterWasBound(nameof(this.BackupVaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupVaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.BackupVaultTag != null)
            {
                context.BackupVaultTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BackupVaultTag.Keys)
                {
                    context.BackupVaultTag.Add((String)hashKey, (System.String)(this.BackupVaultTag[hashKey]));
                }
            }
            context.CreatorRequestId = this.CreatorRequestId;
            context.MaxRetentionDay = this.MaxRetentionDay;
            #if MODULAR
            if (this.MaxRetentionDay == null && ParameterWasBound(nameof(this.MaxRetentionDay)))
            {
                WriteWarning("You are passing $null as a value for parameter MaxRetentionDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinRetentionDay = this.MinRetentionDay;
            #if MODULAR
            if (this.MinRetentionDay == null && ParameterWasBound(nameof(this.MinRetentionDay)))
            {
                WriteWarning("You are passing $null as a value for parameter MinRetentionDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultRequest();
            
            if (cmdletContext.BackupVaultName != null)
            {
                request.BackupVaultName = cmdletContext.BackupVaultName;
            }
            if (cmdletContext.BackupVaultTag != null)
            {
                request.BackupVaultTags = cmdletContext.BackupVaultTag;
            }
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
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
        
        private Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateLogicallyAirGappedBackupVault");
            try
            {
                #if DESKTOP
                return client.CreateLogicallyAirGappedBackupVault(request);
                #elif CORECLR
                return client.CreateLogicallyAirGappedBackupVaultAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> BackupVaultTag { get; set; }
            public System.String CreatorRequestId { get; set; }
            public System.Int64? MaxRetentionDay { get; set; }
            public System.Int64? MinRetentionDay { get; set; }
            public System.Func<Amazon.Backup.Model.CreateLogicallyAirGappedBackupVaultResponse, NewBAKLogicallyAirGappedBackupVaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
