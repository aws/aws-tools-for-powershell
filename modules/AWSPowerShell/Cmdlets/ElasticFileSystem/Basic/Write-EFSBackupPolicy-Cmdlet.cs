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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Updates the file system's backup policy. Use this action to start or stop automatic
    /// backups of the file system.
    /// </summary>
    [Cmdlet("Write", "EFSBackupPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.BackupPolicy")]
    [AWSCmdlet("Calls the Amazon Elastic File System PutBackupPolicy API operation.", Operation = new[] {"PutBackupPolicy"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.BackupPolicy or Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.BackupPolicy object.",
        "The service call response (type Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteEFSBackupPolicyCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>Specifies which EFS file system to update the backup policy for.</para>
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter BackupPolicy_Status
        /// <summary>
        /// <para>
        /// <para>Describes the status of the file system's backup policy.</para><ul><li><para><b><c>ENABLED</c></b> – EFS is automatically backing up the file system.</para></li><li><para><b><c>ENABLING</c></b> – EFS is turning on automatic backups for the file system.</para></li><li><para><b><c>DISABLED</c></b> – Automatic back ups are turned off for the file system.</para></li><li><para><b><c>DISABLING</c></b> – EFS is turning off automatic backups for the file system.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.Status")]
        public Amazon.ElasticFileSystem.Status BackupPolicy_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackupPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackupPolicy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EFSBackupPolicy (PutBackupPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse, WriteEFSBackupPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BackupPolicy_Status = this.BackupPolicy_Status;
            #if MODULAR
            if (this.BackupPolicy_Status == null && ParameterWasBound(nameof(this.BackupPolicy_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupPolicy_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticFileSystem.Model.PutBackupPolicyRequest();
            
            
             // populate BackupPolicy
            var requestBackupPolicyIsNull = true;
            request.BackupPolicy = new Amazon.ElasticFileSystem.Model.BackupPolicy();
            Amazon.ElasticFileSystem.Status requestBackupPolicy_backupPolicy_Status = null;
            if (cmdletContext.BackupPolicy_Status != null)
            {
                requestBackupPolicy_backupPolicy_Status = cmdletContext.BackupPolicy_Status;
            }
            if (requestBackupPolicy_backupPolicy_Status != null)
            {
                request.BackupPolicy.Status = requestBackupPolicy_backupPolicy_Status;
                requestBackupPolicyIsNull = false;
            }
             // determine if request.BackupPolicy should be set to null
            if (requestBackupPolicyIsNull)
            {
                request.BackupPolicy = null;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
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
        
        private Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.PutBackupPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "PutBackupPolicy");
            try
            {
                #if DESKTOP
                return client.PutBackupPolicy(request);
                #elif CORECLR
                return client.PutBackupPolicyAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ElasticFileSystem.Status BackupPolicy_Status { get; set; }
            public System.String FileSystemId { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.PutBackupPolicyResponse, WriteEFSBackupPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackupPolicy;
        }
        
    }
}
