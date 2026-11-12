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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Links a primary secret in your account to a replica secret in a different Amazon Web
    /// Services account and starts replication to this replica. The replica secret must already
    /// exist in the other Amazon Web Services account. Create the replica with <a>CreateSecret</a>
    /// and set its <c>CrossAccountPrimaryARN</c> field set to this primary secret's ARN.
    /// When you call AssociateCrossAccountReplica, Secrets Manager calls AcceptCrossAccountReplication
    /// on the replica secret on your behalf.
    /// 
    ///  
    /// <para>
    /// The primary and replica secrets must be in the same Amazon Web Services Region and
    /// partition, and you must call this operation from the account that owns the primary
    /// secret. A primary secret can have at most one cross-account replica. This operation
    /// is idempotent, so you can call it again for the same replica to repair replication.
    /// If the association fails, Secrets Manager does not modify either the primary or replica
    /// secret.
    /// </para><para>
    /// Secrets Manager generates a CloudTrail log entry when you call this action. Do not
    /// include sensitive information in request parameters because it might be logged. For
    /// more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/retrieve-ct-entries.html">Logging
    /// Secrets Manager events with CloudTrail</a>.
    /// </para><para><b>Required permissions: </b><c>secretsmanager:AssociateCrossAccountReplica</c>,
    /// <c>secretsmanager:GetSecretValue</c> on the primary secret, and <c>secretsmanager:AcceptCrossAccountReplication</c>
    /// on the replica secret. You must also have <c>kms:Decrypt</c> permission for the Key
    /// Management Service (KMS) key that encrypts the primary secret, and <c>kms:Encrypt</c>
    /// permission for the Amazon Web Services KMS key that encrypts the replica secret. If
    /// you supply <c>ReplicationRoleARN</c>, you also need <c>iam:PassRole</c> for that role.
    /// For more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/reference_iam-permissions.html#reference_iam-permissions_actions">
    /// IAM policy actions for Secrets Manager</a> and <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/auth-and-access.html">Authentication
    /// and access control in Secrets Manager</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "SECCrossAccountReplica", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager AssociateCrossAccountReplica API operation.", Operation = new[] {"AssociateCrossAccountReplica"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse))]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse",
        "This cmdlet returns an Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse object containing multiple properties."
    )]
    public partial class AddSECCrossAccountReplicaCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CrossAccountReplicaARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the replica secret in the other Amazon Web Services account. The replica
        /// secret must be in the same Region and partition as the primary secret. Additionally,
        /// the replica account owner must have created the replica secret as a cross-account
        /// replica of the primary secret. For more information see <a>CreateSecret</a>.</para>
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
        public System.String CrossAccountReplicaARN { get; set; }
        #endregion
        
        #region Parameter ReplicaRestriction
        /// <summary>
        /// <para>
        /// <para>Whether the replica account must belong to the same Amazon Web Services organization
        /// as the primary account:</para><ul><li><para><c>SameOrg</c>, which requires the replica account to be in the same organization
        /// as the primary account. This is the default.</para></li><li><para><c>NoRestriction</c>, which allows the replica account to be in any organization.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecretsManager.ReplicaRestrictionType")]
        public Amazon.SecretsManager.ReplicaRestrictionType ReplicaRestriction { get; set; }
        #endregion
        
        #region Parameter ReplicationRoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role in the primary account that Secrets Manager assumes to perform
        /// replication. If you don't include this field, Secrets Manager replicates using the
        /// credentials of caller who updates the primary secret. For more information, see <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/cross-account-replicate-permissions.html">
        /// Cross-account replication permissions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationRoleARN { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>The ARN or name of the primary secret in your account to replicate.</para><para>For an ARN, we recommend that you specify a complete ARN rather than a partial ARN.
        /// See <a href="https://docs.aws.amazon.com/secretsmanager/latest/userguide/troubleshoot.html#ARN_secretnamehyphen">Finding
        /// a secret from a partial ARN</a>.</para>
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
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CrossAccountReplicaARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-SECCrossAccountReplica (AssociateCrossAccountReplica)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse, AddSECCrossAccountReplicaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CrossAccountReplicaARN = this.CrossAccountReplicaARN;
            #if MODULAR
            if (this.CrossAccountReplicaARN == null && ParameterWasBound(nameof(this.CrossAccountReplicaARN)))
            {
                WriteWarning("You are passing $null as a value for parameter CrossAccountReplicaARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicaRestriction = this.ReplicaRestriction;
            context.ReplicationRoleARN = this.ReplicationRoleARN;
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
            var request = new Amazon.SecretsManager.Model.AssociateCrossAccountReplicaRequest();
            
            if (cmdletContext.CrossAccountReplicaARN != null)
            {
                request.CrossAccountReplicaARN = cmdletContext.CrossAccountReplicaARN;
            }
            if (cmdletContext.ReplicaRestriction != null)
            {
                request.ReplicaRestriction = cmdletContext.ReplicaRestriction;
            }
            if (cmdletContext.ReplicationRoleARN != null)
            {
                request.ReplicationRoleARN = cmdletContext.ReplicationRoleARN;
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
        
        private Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.AssociateCrossAccountReplicaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "AssociateCrossAccountReplica");
            try
            {
                return client.AssociateCrossAccountReplicaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CrossAccountReplicaARN { get; set; }
            public Amazon.SecretsManager.ReplicaRestrictionType ReplicaRestriction { get; set; }
            public System.String ReplicationRoleARN { get; set; }
            public System.String SecretId { get; set; }
            public System.Func<Amazon.SecretsManager.Model.AssociateCrossAccountReplicaResponse, AddSECCrossAccountReplicaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
