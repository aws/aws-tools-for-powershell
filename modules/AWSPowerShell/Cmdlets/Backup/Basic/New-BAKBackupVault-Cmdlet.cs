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
    /// Creates a logical container where backups are stored. A <c>CreateBackupVault</c> request
    /// includes a name, optionally one or more resource tags, an encryption key, and a request
    /// ID.
    /// 
    ///  <note><para>
    /// Do not include sensitive data, such as passport numbers, in the name of a backup vault.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "BAKBackupVault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateBackupVaultResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateBackupVault API operation.", Operation = new[] {"CreateBackupVault"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateBackupVaultResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateBackupVaultResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateBackupVaultResponse object containing multiple properties."
    )]
    public partial class NewBAKBackupVaultCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupVaultName
        /// <summary>
        /// <para>
        /// <para>The name of a logical container where backups are stored. Backup vaults are identified
        /// by names that are unique to the account used to create them and the Amazon Web Services
        /// Region where they are created. They consist of letters, numbers, and hyphens.</para>
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
        /// <para>The tags to assign to the backup vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BackupVaultTags")]
        public System.Collections.Hashtable BackupVaultTag { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and allows failed requests to be retried
        /// without the risk of running the operation twice. This parameter is optional.</para><para>If used, this parameter must contain 1 to 50 alphanumeric or '-_.' characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The server-side encryption key that is used to protect your backups; for example,
        /// <c>arn:aws:kms:us-west-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateBackupVaultResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateBackupVaultResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKBackupVault (CreateBackupVault)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateBackupVaultResponse, NewBAKBackupVaultCmdlet>(Select) ??
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
            if (this.BackupVaultTag != null)
            {
                context.BackupVaultTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BackupVaultTag.Keys)
                {
                    context.BackupVaultTag.Add((String)hashKey, (System.String)(this.BackupVaultTag[hashKey]));
                }
            }
            context.CreatorRequestId = this.CreatorRequestId;
            context.EncryptionKeyArn = this.EncryptionKeyArn;
            
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
            var request = new Amazon.Backup.Model.CreateBackupVaultRequest();
            
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
            if (cmdletContext.EncryptionKeyArn != null)
            {
                request.EncryptionKeyArn = cmdletContext.EncryptionKeyArn;
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
        
        private Amazon.Backup.Model.CreateBackupVaultResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateBackupVaultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateBackupVault");
            try
            {
                #if DESKTOP
                return client.CreateBackupVault(request);
                #elif CORECLR
                return client.CreateBackupVaultAsync(request).GetAwaiter().GetResult();
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
            public System.String EncryptionKeyArn { get; set; }
            public System.Func<Amazon.Backup.Model.CreateBackupVaultResponse, NewBAKBackupVaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
