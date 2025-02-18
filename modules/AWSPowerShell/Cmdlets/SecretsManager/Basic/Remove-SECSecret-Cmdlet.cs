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
using System.Threading;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Deletes a secret and all of its versions. You can specify a recovery window during
    /// which you can restore the secret. The minimum recovery window is 7 days. The default
    /// recovery window is 30 days. Secrets Manager attaches a <c>DeletionDate</c> stamp to
    /// the secret that specifies the end of the recovery window. At the end of the recovery
    /// window, Secrets Manager deletes the secret permanently.
    /// 
    ///  
    /// <para>
    /// You can't delete a primary secret that is replicated to other Regions. You must first
    /// delete the replicas using <a>RemoveRegionsFromReplication</a>, and then delete the
    /// primary secret. When you delete a replica, it is deleted immediately.
    /// </para><para>
    /// You can't directly delete a version of a secret. Instead, you remove all staging labels
    /// from the version using <a>UpdateSecretVersionStage</a>. This marks the version as
    /// deprecated, and then Secrets Manager can automatically delete the version in the background.
    /// </para><para>
    /// To determine whether an application still uses a secret, you can create an Amazon
    /// CloudWatch alarm to alert you to any attempts to access a secret during the recovery
    /// window. For more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/monitoring_cloudwatch_deleted-secrets.html">
    /// Monitor secrets scheduled for deletion</a>.
    /// </para><para>
    /// Secrets Manager performs the permanent secret deletion at the end of the waiting period
    /// as a background task with low priority. There is no guarantee of a specific time after
    /// the recovery window for the permanent delete to occur.
    /// </para><para>
    /// At any time before recovery window ends, you can use <a>RestoreSecret</a> to remove
    /// the <c>DeletionDate</c> and cancel the deletion of the secret.
    /// </para><para>
    /// When a secret is scheduled for deletion, you cannot retrieve the secret value. You
    /// must first cancel the deletion with <a>RestoreSecret</a> and then you can retrieve
    /// the secret.
    /// </para><para>
    /// Secrets Manager generates a CloudTrail log entry when you call this action. Do not
    /// include sensitive information in request parameters because it might be logged. For
    /// more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/retrieve-ct-entries.html">Logging
    /// Secrets Manager events with CloudTrail</a>.
    /// </para><para><b>Required permissions: </b><c>secretsmanager:DeleteSecret</c>. For more information,
    /// see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/reference_iam-permissions.html#reference_iam-permissions_actions">
    /// IAM policy actions for Secrets Manager</a> and <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access.html">Authentication
    /// and access control in Secrets Manager</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "SECSecret", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.SecretsManager.Model.DeleteSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager DeleteSecret API operation.", Operation = new[] {"DeleteSecret"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.DeleteSecretResponse))]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.DeleteSecretResponse",
        "This cmdlet returns an Amazon.SecretsManager.Model.DeleteSecretResponse object containing multiple properties."
    )]
    public partial class RemoveSECSecretCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeleteWithNoRecovery
        /// <summary>
        /// <para>
        /// <para>Specifies whether to delete the secret without any recovery window. You can't use
        /// both this parameter and <c>RecoveryWindowInDays</c> in the same call. If you don't
        /// use either, then by default Secrets Manager uses a 30 day recovery window.</para><para>Secrets Manager performs the actual deletion with an asynchronous background process,
        /// so there might be a short delay before the secret is permanently deleted. If you delete
        /// a secret and then immediately create a secret with the same name, use appropriate
        /// back off and retry logic.</para><para>If you forcibly delete an already deleted or nonexistent secret, the operation does
        /// not return <c>ResourceNotFoundException</c>.</para><important><para>Use this parameter with caution. This parameter causes the operation to skip the normal
        /// recovery window before the permanent deletion that Secrets Manager would normally
        /// impose with the <c>RecoveryWindowInDays</c> parameter. If you delete a secret with
        /// the <c>ForceDeleteWithoutRecovery</c> parameter, then you have no opportunity to recover
        /// the secret. You lose the secret permanently.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteWithNoRecovery { get; set; }
        #endregion
        
        #region Parameter RecoveryWindowInDay
        /// <summary>
        /// <para>
        /// <para>The number of days from 7 to 30 that Secrets Manager waits before permanently deleting
        /// the secret. You can't use both this parameter and <c>ForceDeleteWithoutRecovery</c>
        /// in the same call. If you don't use either, then by default Secrets Manager uses a
        /// 30 day recovery window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecoveryWindowInDays")]
        public System.Int64? RecoveryWindowInDay { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>The ARN or name of the secret to delete.</para><para>For an ARN, we recommend that you specify a complete ARN rather than a partial ARN.
        /// See <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/troubleshoot.html#ARN_secretnamehyphen">Finding
        /// a secret from a partial ARN</a>.</para>
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
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.DeleteSecretResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.DeleteSecretResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecretId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SECSecret (DeleteSecret)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.DeleteSecretResponse, RemoveSECSecretCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeleteWithNoRecovery = this.DeleteWithNoRecovery;
            context.RecoveryWindowInDay = this.RecoveryWindowInDay;
            context.SecretId = this.SecretId;
            #if MODULAR
            if (this.SecretId == null && ParameterWasBound(nameof(this.SecretId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecretsManager.Model.DeleteSecretRequest();
            
            if (cmdletContext.DeleteWithNoRecovery != null)
            {
                request.ForceDeleteWithoutRecovery = cmdletContext.DeleteWithNoRecovery.Value;
            }
            if (cmdletContext.RecoveryWindowInDay != null)
            {
                request.RecoveryWindowInDays = cmdletContext.RecoveryWindowInDay.Value;
            }
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
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
        
        private Amazon.SecretsManager.Model.DeleteSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.DeleteSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "DeleteSecret");
            try
            {
                return client.DeleteSecretAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DeleteWithNoRecovery { get; set; }
            public System.Int64? RecoveryWindowInDay { get; set; }
            public System.String SecretId { get; set; }
            public System.Func<Amazon.SecretsManager.Model.DeleteSecretResponse, RemoveSECSecretCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
