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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Adds a grant to a customer master key (CMK). The grant allows the grantee principal
    /// to use the CMK when the conditions specified in the grant are met. When setting permissions,
    /// grants are an alternative to key policies. 
    /// 
    ///  
    /// <para>
    /// To create a grant that allows a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#cryptographic-operations">cryptographic
    /// operation</a> only when the request includes a particular <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">encryption
    /// context</a>, use the <code>Constraints</code> parameter. For details, see <a>GrantConstraints</a>.
    /// </para><para>
    /// You can create grants on symmetric and asymmetric CMKs. However, if the grant allows
    /// an operation that the CMK does not support, <code>CreateGrant</code> fails with a
    /// <code>ValidationException</code>. 
    /// </para><ul><li><para>
    /// Grants for symmetric CMKs cannot allow operations that are not supported for symmetric
    /// CMKs, including <a>Sign</a>, <a>Verify</a>, and <a>GetPublicKey</a>. (There are limited
    /// exceptions to this rule for legacy operations, but you should not create a grant for
    /// an operation that AWS KMS does not support.)
    /// </para></li><li><para>
    /// Grants for asymmetric CMKs cannot allow operations that are not supported for asymmetric
    /// CMKs, including operations that <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_GenerateDataKey">generate
    /// data keys</a> or <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_GenerateDataKeyPair">data
    /// key pairs</a>, or operations related to <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html">automatic
    /// key rotation</a>, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">imported
    /// key material</a>, or CMKs in <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key stores</a>.
    /// </para></li><li><para>
    /// Grants for asymmetric CMKs with a <code>KeyUsage</code> of <code>ENCRYPT_DECRYPT</code>
    /// cannot allow the <a>Sign</a> or <a>Verify</a> operations. Grants for asymmetric CMKs
    /// with a <code>KeyUsage</code> of <code>SIGN_VERIFY</code> cannot allow the <a>Encrypt</a>
    /// or <a>Decrypt</a> operations.
    /// </para></li><li><para>
    /// Grants for asymmetric CMKs cannot include an encryption context grant constraint.
    /// An encryption context is not supported on asymmetric CMKs.
    /// </para></li></ul><para>
    /// For information about symmetric and asymmetric CMKs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
    /// Symmetric and Asymmetric CMKs</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// For more information about grants, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html">Grants</a>
    /// in the <i><i>AWS Key Management Service Developer Guide</i></i>.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation on a CMK in a different
    /// AWS account, specify the key ARN in the value of the <code>KeyId</code> parameter.
    /// 
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:CreateGrant</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>ListGrants</a></para></li><li><para><a>ListRetirableGrants</a></para></li><li><para><a>RetireGrant</a></para></li><li><para><a>RevokeGrant</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "KMSGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.CreateGrantResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateGrant API operation.", Operation = new[] {"CreateGrant"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.CreateGrantResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.CreateGrantResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.CreateGrantResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSGrantCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Constraints_EncryptionContextEqual
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that must match the encryption context in the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#cryptographic-operations">cryptographic
        /// operation</a> request. The grant allows the operation only when the encryption context
        /// in the request is the same as the encryption context specified in this constraint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Constraints_EncryptionContextEquals")]
        public System.Collections.Hashtable Constraints_EncryptionContextEqual { get; set; }
        #endregion
        
        #region Parameter Constraints_EncryptionContextSubset
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that must be included in the encryption context of the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#cryptographic-operations">cryptographic
        /// operation</a> request. The grant allows the cryptographic operation only when the
        /// encryption context in the request includes the key-value pairs specified in this constraint,
        /// although it can include additional key-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Constraints_EncryptionContextSubset { get; set; }
        #endregion
        
        #region Parameter GranteePrincipal
        /// <summary>
        /// <para>
        /// <para>The principal that is given permission to perform the operations that the grant permits.</para><para>To specify the principal, use the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an AWS principal. Valid AWS principals include AWS accounts
        /// (root), IAM users, IAM roles, federated users, and assumed role users. For examples
        /// of the ARN syntax to use for specifying a principal, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-iam">AWS
        /// Identity and Access Management (IAM)</a> in the Example ARNs section of the <i>AWS
        /// General Reference</i>.</para>
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
        public System.String GranteePrincipal { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
        /// Tokens</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the customer master key (CMK) that the grant applies to.</para><para>Specify the key ID or the Amazon Resource Name (ARN) of the CMK. To specify a CMK
        /// in a different AWS account, you must use the key ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name for the grant. Use this value to prevent the unintended creation of
        /// duplicate grants when retrying this request.</para><para>When this value is absent, all <code>CreateGrant</code> requests result in a new grant
        /// with a unique <code>GrantId</code> even if all the supplied parameters are identical.
        /// This can result in unintended duplicates when you retry the <code>CreateGrant</code>
        /// request.</para><para>When this value is present, you can retry a <code>CreateGrant</code> request with
        /// identical parameters; if the grant already exists, the original <code>GrantId</code>
        /// is returned without creating a new grant. Note that the returned grant token is unique
        /// with every <code>CreateGrant</code> request, even when a duplicate <code>GrantId</code>
        /// is returned. All grant tokens for the same grant ID can be used interchangeably.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>A list of operations that the grant permits.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Operations")]
        public System.String[] Operation { get; set; }
        #endregion
        
        #region Parameter RetiringPrincipal
        /// <summary>
        /// <para>
        /// <para>The principal that is given permission to retire the grant by using <a>RetireGrant</a>
        /// operation.</para><para>To specify the principal, use the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an AWS principal. Valid AWS principals include AWS accounts
        /// (root), IAM users, federated users, and assumed role users. For examples of the ARN
        /// syntax to use for specifying a principal, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-iam">AWS
        /// Identity and Access Management (IAM)</a> in the Example ARNs section of the <i>AWS
        /// General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetiringPrincipal { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.CreateGrantResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.CreateGrantResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSGrant (CreateGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.CreateGrantResponse, NewKMSGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Constraints_EncryptionContextEqual != null)
            {
                context.Constraints_EncryptionContextEqual = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Constraints_EncryptionContextEqual.Keys)
                {
                    context.Constraints_EncryptionContextEqual.Add((String)hashKey, (String)(this.Constraints_EncryptionContextEqual[hashKey]));
                }
            }
            if (this.Constraints_EncryptionContextSubset != null)
            {
                context.Constraints_EncryptionContextSubset = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Constraints_EncryptionContextSubset.Keys)
                {
                    context.Constraints_EncryptionContextSubset.Add((String)hashKey, (String)(this.Constraints_EncryptionContextSubset[hashKey]));
                }
            }
            context.GranteePrincipal = this.GranteePrincipal;
            #if MODULAR
            if (this.GranteePrincipal == null && ParameterWasBound(nameof(this.GranteePrincipal)))
            {
                WriteWarning("You are passing $null as a value for parameter GranteePrincipal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GrantToken != null)
            {
                context.GrantToken = new List<System.String>(this.GrantToken);
            }
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.Operation != null)
            {
                context.Operation = new List<System.String>(this.Operation);
            }
            #if MODULAR
            if (this.Operation == null && ParameterWasBound(nameof(this.Operation)))
            {
                WriteWarning("You are passing $null as a value for parameter Operation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetiringPrincipal = this.RetiringPrincipal;
            
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
            var request = new Amazon.KeyManagementService.Model.CreateGrantRequest();
            
            
             // populate Constraints
            var requestConstraintsIsNull = true;
            request.Constraints = new Amazon.KeyManagementService.Model.GrantConstraints();
            Dictionary<System.String, System.String> requestConstraints_constraints_EncryptionContextEqual = null;
            if (cmdletContext.Constraints_EncryptionContextEqual != null)
            {
                requestConstraints_constraints_EncryptionContextEqual = cmdletContext.Constraints_EncryptionContextEqual;
            }
            if (requestConstraints_constraints_EncryptionContextEqual != null)
            {
                request.Constraints.EncryptionContextEquals = requestConstraints_constraints_EncryptionContextEqual;
                requestConstraintsIsNull = false;
            }
            Dictionary<System.String, System.String> requestConstraints_constraints_EncryptionContextSubset = null;
            if (cmdletContext.Constraints_EncryptionContextSubset != null)
            {
                requestConstraints_constraints_EncryptionContextSubset = cmdletContext.Constraints_EncryptionContextSubset;
            }
            if (requestConstraints_constraints_EncryptionContextSubset != null)
            {
                request.Constraints.EncryptionContextSubset = requestConstraints_constraints_EncryptionContextSubset;
                requestConstraintsIsNull = false;
            }
             // determine if request.Constraints should be set to null
            if (requestConstraintsIsNull)
            {
                request.Constraints = null;
            }
            if (cmdletContext.GranteePrincipal != null)
            {
                request.GranteePrincipal = cmdletContext.GranteePrincipal;
            }
            if (cmdletContext.GrantToken != null)
            {
                request.GrantTokens = cmdletContext.GrantToken;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Operation != null)
            {
                request.Operations = cmdletContext.Operation;
            }
            if (cmdletContext.RetiringPrincipal != null)
            {
                request.RetiringPrincipal = cmdletContext.RetiringPrincipal;
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
        
        private Amazon.KeyManagementService.Model.CreateGrantResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateGrant");
            try
            {
                #if DESKTOP
                return client.CreateGrant(request);
                #elif CORECLR
                return client.CreateGrantAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Constraints_EncryptionContextEqual { get; set; }
            public Dictionary<System.String, System.String> Constraints_EncryptionContextSubset { get; set; }
            public System.String GranteePrincipal { get; set; }
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Operation { get; set; }
            public System.String RetiringPrincipal { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.CreateGrantResponse, NewKMSGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
