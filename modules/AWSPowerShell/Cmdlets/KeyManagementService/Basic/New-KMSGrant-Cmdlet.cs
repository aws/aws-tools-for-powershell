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
    /// Adds a grant to a KMS key. 
    /// 
    ///  
    /// <para>
    /// A <i>grant</i> is a policy instrument that allows Amazon Web Services principals to
    /// use KMS keys in cryptographic operations. It also can allow them to view a KMS key
    /// (<a>DescribeKey</a>) and create and manage grants. When authorizing access to a KMS
    /// key, grants are considered along with key policies and IAM policies. Grants are often
    /// used for temporary permissions because you can create one, use its permissions, and
    /// delete it without changing your key policies or IAM policies. 
    /// </para><para>
    /// For detailed information about grants, including grant terminology, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html">Grants
    /// in KMS</a> in the <i><i>Key Management Service Developer Guide</i></i>. For examples
    /// of working with grants in several programming languages, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-grants.html">Programming
    /// grants</a>. 
    /// </para><para>
    /// The <code>CreateGrant</code> operation returns a <code>GrantToken</code> and a <code>GrantId</code>.
    /// </para><ul><li><para>
    /// When you create, retire, or revoke a grant, there might be a brief delay, usually
    /// less than five minutes, until the grant is available throughout KMS. This state is
    /// known as <i>eventual consistency</i>. Once the grant has achieved eventual consistency,
    /// the grantee principal can use the permissions in the grant without identifying the
    /// grant. 
    /// </para><para>
    /// However, to use the permissions in the grant immediately, use the <code>GrantToken</code>
    /// that <code>CreateGrant</code> returns. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#using-grant-token">Using
    /// a grant token</a> in the <i><i>Key Management Service Developer Guide</i></i>.
    /// </para></li><li><para>
    /// The <code>CreateGrant</code> operation also returns a <code>GrantId</code>. You can
    /// use the <code>GrantId</code> and a key identifier to identify the grant in the <a>RetireGrant</a>
    /// and <a>RevokeGrant</a> operations. To find the grant ID, use the <a>ListGrants</a>
    /// or <a>ListRetirableGrants</a> operations.
    /// </para></li></ul><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation on a KMS key in a different
    /// Amazon Web Services account, specify the key ARN in the value of the <code>KeyId</code>
    /// parameter. 
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
        /// <para>The identity that gets the permissions specified in the grant.</para><para>To specify the grantee principal, use the Amazon Resource Name (ARN) of an Amazon
        /// Web Services principal. Valid principals include Amazon Web Services accounts, IAM
        /// users, IAM roles, federated users, and assumed role users. For help with the ARN syntax
        /// for a principal, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a> in the <i><i>Identity and Access Management User Guide</i></i>.</para>
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
        /// <para>A list of grant tokens. </para><para>Use a grant token when your permission to call this operation comes from a new grant
        /// that has not yet achieved <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">Grant
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#using-grant-token">Using
        /// a grant token</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Identifies the KMS key for the grant. The grant gives principals permission to use
        /// this KMS key.</para><para>Specify the key ID or key ARN of the KMS key. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        /// <para>A list of operations that the grant permits. </para><para>This list must include only operations that are permitted in a grant. Also, the operation
        /// must be supported on the KMS key. For example, you cannot create a grant for a symmetric
        /// encryption KMS key that allows the <a>Sign</a> operation, or a grant for an asymmetric
        /// KMS key that allows the <a>GenerateDataKey</a> operation. If you try, KMS returns
        /// a <code>ValidationError</code> exception. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#terms-grant-operations">Grant
        /// operations</a> in the <i>Key Management Service Developer Guide</i>.</para>
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
        /// <para>The principal that has permission to use the <a>RetireGrant</a> operation to retire
        /// the grant. </para><para>To specify the principal, use the <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an Amazon Web Services principal. Valid principals include
        /// Amazon Web Services accounts, IAM users, IAM roles, federated users, and assumed role
        /// users. For help with the ARN syntax for a principal, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-arns">IAM
        /// ARNs</a> in the <i><i>Identity and Access Management User Guide</i></i>.</para><para>The grant determines the retiring principal. Other principals might have permission
        /// to retire the grant or revoke the grant. For details, see <a>RevokeGrant</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#grant-delete">Retiring
        /// and revoking grants</a> in the <i>Key Management Service Developer Guide</i>. </para>
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
            this._AWSSignerType = "v4";
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
