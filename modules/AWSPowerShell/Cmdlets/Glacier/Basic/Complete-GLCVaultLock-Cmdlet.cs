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
using Amazon.Glacier;
using Amazon.Glacier.Model;

namespace Amazon.PowerShell.Cmdlets.GLC
{
    /// <summary>
    /// This operation completes the vault locking process by transitioning the vault lock
    /// from the <code>InProgress</code> state to the <code>Locked</code> state, which causes
    /// the vault lock policy to become unchangeable. A vault lock is put into the <code>InProgress</code>
    /// state by calling <a>InitiateVaultLock</a>. You can obtain the state of the vault lock
    /// by calling <a>GetVaultLock</a>. For more information about the vault locking process,
    /// <a href="https://docs.aws.amazon.com/amazonglacier/latest/dev/vault-lock.html">Amazon
    /// Glacier Vault Lock</a>. 
    /// 
    ///  
    /// <para>
    /// This operation is idempotent. This request is always successful if the vault lock
    /// is in the <code>Locked</code> state and the provided lock ID matches the lock ID originally
    /// used to lock the vault.
    /// </para><para>
    /// If an invalid lock ID is passed in the request when the vault lock is in the <code>Locked</code>
    /// state, the operation returns an <code>AccessDeniedException</code> error. If an invalid
    /// lock ID is passed in the request when the vault lock is in the <code>InProgress</code>
    /// state, the operation throws an <code>InvalidParameter</code> error.
    /// </para>
    /// </summary>
    [Cmdlet("Complete", "GLCVaultLock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Glacier CompleteVaultLock API operation.", Operation = new[] {"CompleteVaultLock"}, SelectReturnType = typeof(Amazon.Glacier.Model.CompleteVaultLockResponse))]
    [AWSCmdletOutput("None or Amazon.Glacier.Model.CompleteVaultLockResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glacier.Model.CompleteVaultLockResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CompleteGLCVaultLockCmdlet : AmazonGlacierClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <code>AccountId</code> value is the AWS account ID. This value must match the
        /// AWS account ID associated with the credentials used to sign the request. You can either
        /// specify an AWS account ID or optionally a single '<code>-</code>' (hyphen), in which
        /// case Amazon Glacier uses the AWS account ID associated with the credentials used to
        /// sign the request. If you specify your account ID, do not include any hyphens ('-')
        /// in the ID.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>-</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter LockId
        /// <summary>
        /// <para>
        /// <para>The <code>lockId</code> value is the lock ID obtained from a <a>InitiateVaultLock</a>
        /// request.</para>
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
        public System.String LockId { get; set; }
        #endregion
        
        #region Parameter VaultName
        /// <summary>
        /// <para>
        /// <para>The name of the vault.</para>
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
        public System.String VaultName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glacier.Model.CompleteVaultLockResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LockId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LockId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LockId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LockId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-GLCVaultLock (CompleteVaultLock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glacier.Model.CompleteVaultLockResponse, CompleteGLCVaultLockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LockId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.LockId = this.LockId;
            #if MODULAR
            if (this.LockId == null && ParameterWasBound(nameof(this.LockId)))
            {
                WriteWarning("You are passing $null as a value for parameter LockId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glacier.Model.CompleteVaultLockRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.LockId != null)
            {
                request.LockId = cmdletContext.LockId;
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
        
        private Amazon.Glacier.Model.CompleteVaultLockResponse CallAWSServiceOperation(IAmazonGlacier client, Amazon.Glacier.Model.CompleteVaultLockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Glacier", "CompleteVaultLock");
            try
            {
                #if DESKTOP
                return client.CompleteVaultLock(request);
                #elif CORECLR
                return client.CompleteVaultLockAsync(request).GetAwaiter().GetResult();
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
            public System.String LockId { get; set; }
            public System.String VaultName { get; set; }
            public System.Func<Amazon.Glacier.Model.CompleteVaultLockResponse, CompleteGLCVaultLockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
