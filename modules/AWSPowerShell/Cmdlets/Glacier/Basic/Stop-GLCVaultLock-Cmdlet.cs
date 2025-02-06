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
using Amazon.Glacier;
using Amazon.Glacier.Model;

namespace Amazon.PowerShell.Cmdlets.GLC
{
    /// <summary>
    /// This operation aborts the vault locking process if the vault lock is not in the <c>Locked</c>
    /// state. If the vault lock is in the <c>Locked</c> state when this operation is requested,
    /// the operation returns an <c>AccessDeniedException</c> error. Aborting the vault locking
    /// process removes the vault lock policy from the specified vault. 
    /// 
    ///  
    /// <para>
    /// A vault lock is put into the <c>InProgress</c> state by calling <a>InitiateVaultLock</a>.
    /// A vault lock is put into the <c>Locked</c> state by calling <a>CompleteVaultLock</a>.
    /// You can get the state of a vault lock by calling <a>GetVaultLock</a>. For more information
    /// about the vault locking process, see <a href="https://docs.aws.amazon.com/amazonglacier/latest/dev/vault-lock.html">Amazon
    /// Glacier Vault Lock</a>. For more information about vault lock policies, see <a href="https://docs.aws.amazon.com/amazonglacier/latest/dev/vault-lock-policy.html">Amazon
    /// Glacier Access Control with Vault Lock Policies</a>. 
    /// </para><para>
    /// This operation is idempotent. You can successfully invoke this operation multiple
    /// times, if the vault lock is in the <c>InProgress</c> state or if there is no policy
    /// associated with the vault.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "GLCVaultLock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Glacier AbortVaultLock API operation.", Operation = new[] {"AbortVaultLock"}, SelectReturnType = typeof(Amazon.Glacier.Model.AbortVaultLockResponse))]
    [AWSCmdletOutput("None or Amazon.Glacier.Model.AbortVaultLockResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glacier.Model.AbortVaultLockResponse) be returned by specifying '-Select *'."
    )]
    public partial class StopGLCVaultLockCmdlet : AmazonGlacierClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <c>AccountId</c> value is the AWS account ID. This value must match the AWS account
        /// ID associated with the credentials used to sign the request. You can either specify
        /// an AWS account ID or optionally a single '<c>-</c>' (hyphen), in which case Amazon
        /// Glacier uses the AWS account ID associated with the credentials used to sign the request.
        /// If you specify your account ID, do not include any hyphens ('-') in the ID.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>-</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter VaultName
        /// <summary>
        /// <para>
        /// <para>The name of the vault.</para>
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
        public System.String VaultName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glacier.Model.AbortVaultLockResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VaultName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-GLCVaultLock (AbortVaultLock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glacier.Model.AbortVaultLockResponse, StopGLCVaultLockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            if (!ParameterWasBound(nameof(this.AccountId)))
            {
                WriteVerbose("AccountId parameter unset, using default value of '-'");
                context.AccountId = "-";
            }
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VaultName = this.VaultName;
            #if MODULAR
            if (this.VaultName == null && ParameterWasBound(nameof(this.VaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter VaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glacier.Model.AbortVaultLockRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.VaultName != null)
            {
                request.VaultName = cmdletContext.VaultName;
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
        
        private Amazon.Glacier.Model.AbortVaultLockResponse CallAWSServiceOperation(IAmazonGlacier client, Amazon.Glacier.Model.AbortVaultLockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Glacier", "AbortVaultLock");
            try
            {
                #if DESKTOP
                return client.AbortVaultLock(request);
                #elif CORECLR
                return client.AbortVaultLockAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String VaultName { get; set; }
            public System.Func<Amazon.Glacier.Model.AbortVaultLockResponse, StopGLCVaultLockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
