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
    /// Creates a restore access backup vault that provides temporary access to recovery points
    /// in a logically air-gapped backup vault, subject to MPA approval.
    /// </summary>
    [Cmdlet("New", "BAKRestoreAccessBackupVault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateRestoreAccessBackupVault API operation.", Operation = new[] {"CreateRestoreAccessBackupVault"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse object containing multiple properties."
    )]
    public partial class NewBAKRestoreAccessBackupVaultCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BackupVaultName
        /// <summary>
        /// <para>
        /// <para>The name of the backup vault to associate with an MPA approval team.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackupVaultName { get; set; }
        #endregion
        
        #region Parameter BackupVaultTag
        /// <summary>
        /// <para>
        /// <para>Optional tags to assign to the restore access backup vault.</para>
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
        /// without the risk of executing the operation twice.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter RequesterComment
        /// <summary>
        /// <para>
        /// <para>A comment explaining the reason for requesting restore access to the backup vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequesterComment { get; set; }
        #endregion
        
        #region Parameter SourceBackupVaultArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the source backup vault containing the recovery points to which temporary
        /// access is requested.</para>
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
        public System.String SourceBackupVaultArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceBackupVaultArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceBackupVaultArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceBackupVaultArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceBackupVaultArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKRestoreAccessBackupVault (CreateRestoreAccessBackupVault)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse, NewBAKRestoreAccessBackupVaultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceBackupVaultArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupVaultName = this.BackupVaultName;
            if (this.BackupVaultTag != null)
            {
                context.BackupVaultTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.BackupVaultTag.Keys)
                {
                    context.BackupVaultTag.Add((String)hashKey, (System.String)(this.BackupVaultTag[hashKey]));
                }
            }
            context.CreatorRequestId = this.CreatorRequestId;
            context.RequesterComment = this.RequesterComment;
            context.SourceBackupVaultArn = this.SourceBackupVaultArn;
            #if MODULAR
            if (this.SourceBackupVaultArn == null && ParameterWasBound(nameof(this.SourceBackupVaultArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceBackupVaultArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.CreateRestoreAccessBackupVaultRequest();
            
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
            if (cmdletContext.RequesterComment != null)
            {
                request.RequesterComment = cmdletContext.RequesterComment;
            }
            if (cmdletContext.SourceBackupVaultArn != null)
            {
                request.SourceBackupVaultArn = cmdletContext.SourceBackupVaultArn;
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
        
        private Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateRestoreAccessBackupVaultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateRestoreAccessBackupVault");
            try
            {
                #if DESKTOP
                return client.CreateRestoreAccessBackupVault(request);
                #elif CORECLR
                return client.CreateRestoreAccessBackupVaultAsync(request).GetAwaiter().GetResult();
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
            public System.String RequesterComment { get; set; }
            public System.String SourceBackupVaultArn { get; set; }
            public System.Func<Amazon.Backup.Model.CreateRestoreAccessBackupVaultResponse, NewBAKRestoreAccessBackupVaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
