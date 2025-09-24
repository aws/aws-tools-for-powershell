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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Returns a unique asymmetric data key pair for use outside of KMS. This operation returns
    /// a plaintext public key, a plaintext private key, and a copy of the private key that
    /// is encrypted under the symmetric encryption KMS key you specify. You can use the data
    /// key pair to perform asymmetric cryptography and implement digital signatures outside
    /// of KMS. The bytes in the keys are random; they are not related to the caller or to
    /// the KMS key that is used to encrypt the private key. 
    /// 
    ///  
    /// <para>
    /// You can use the public key that <c>GenerateDataKeyPair</c> returns to encrypt data
    /// or verify a signature outside of KMS. Then, store the encrypted private key with the
    /// data. When you are ready to decrypt data or sign a message, you can use the <a>Decrypt</a>
    /// operation to decrypt the encrypted private key.
    /// </para><para>
    /// To generate a data key pair, you must specify a symmetric encryption KMS key to encrypt
    /// the private key in a data key pair. You cannot use an asymmetric KMS key or a KMS
    /// key in a custom key store. To get the type and origin of your KMS key, use the <a>DescribeKey</a>
    /// operation. 
    /// </para><para>
    /// Use the <c>KeyPairSpec</c> parameter to choose an RSA or Elliptic Curve (ECC) data
    /// key pair. In China Regions, you can also choose an SM2 data key pair. KMS recommends
    /// that you use ECC key pairs for signing, and use RSA and SM2 key pairs for either encryption
    /// or signing, but not both. However, KMS cannot enforce any restrictions on the use
    /// of data key pairs outside of KMS.
    /// </para><para>
    /// If you are using the data key pair to encrypt data, or for any operation where you
    /// don't immediately need a private key, consider using the <a>GenerateDataKeyPairWithoutPlaintext</a>
    /// operation. <c>GenerateDataKeyPairWithoutPlaintext</c> returns a plaintext public key
    /// and an encrypted private key, but omits the plaintext private key that you need only
    /// to decrypt ciphertext or sign a message. Later, when you need to decrypt the data
    /// or sign a message, use the <a>Decrypt</a> operation to decrypt the encrypted private
    /// key in the data key pair.
    /// </para><para><c>GenerateDataKeyPair</c> returns a unique data key pair for each request. The bytes
    /// in the keys are random; they are not related to the caller or the KMS key that is
    /// used to encrypt the private key. The public key is a DER-encoded X.509 SubjectPublicKeyInfo,
    /// as specified in <a href="https://tools.ietf.org/html/rfc5280">RFC 5280</a>. The private
    /// key is a DER-encoded PKCS8 PrivateKeyInfo, as specified in <a href="https://tools.ietf.org/html/rfc5958">RFC
    /// 5958</a>.
    /// </para><para><c>GenerateDataKeyPair</c> also supports <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/nitro-enclave.html">Amazon
    /// Web Services Nitro Enclaves</a>, which provide an isolated compute environment in
    /// Amazon EC2. To call <c>GenerateDataKeyPair</c> for an Amazon Web Services Nitro enclave
    /// or NitroTPM, use the <a href="https://docs.aws.amazon.com/enclaves/latest/user/developing-applications.html#sdk">Amazon
    /// Web Services Nitro Enclaves SDK</a> or any Amazon Web Services SDK. Use the <c>Recipient</c>
    /// parameter to provide the attestation document for the attested environment. <c>GenerateDataKeyPair</c>
    /// returns the public data key and a copy of the private data key encrypted under the
    /// specified KMS key, as usual. But instead of a plaintext copy of the private data key
    /// (<c>PrivateKeyPlaintext</c>), the response includes a copy of the private data key
    /// encrypted under the public key from the attestation document (<c>CiphertextForRecipient</c>).
    /// For information about the interaction between KMS and Amazon Web Services Nitro Enclaves
    /// or Amazon Web Services NitroTPM, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/cryptographic-attestation.html">Cryptographic
    /// attestation support in KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// You can use an optional encryption context to add additional security to the encryption
    /// operation. If you specify an <c>EncryptionContext</c>, you must specify the same encryption
    /// context (a case-sensitive exact match) when decrypting the encrypted data key. Otherwise,
    /// the request to decrypt fails with an <c>InvalidCiphertextException</c>. For more information,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/encrypt_context.html">Encryption
    /// Context</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <c>KeyId</c> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GenerateDataKeyPair</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Decrypt</a></para></li><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPairWithoutPlaintext</a></para></li><li><para><a>GenerateDataKeyWithoutPlaintext</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/accessing-kms.html#programming-eventual-consistency">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSDataKeyPair", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GenerateDataKeyPair API operation.", Operation = new[] {"GenerateDataKeyPair"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse object containing multiple properties."
    )]
    public partial class NewKMSDataKeyPairCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Recipient_AttestationDocument
        /// <summary>
        /// <para>
        /// <para>The attestation document for an Amazon Web Services Nitro Enclave or a NitroTPM. This
        /// document includes the enclave's public key.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Recipient_AttestationDocument { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks if your request will succeed. <c>DryRun</c> is an optional parameter. </para><para>To learn more about how to use this parameter, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/testing-permissions.html">Testing
        /// your permissions</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption context that will be used when encrypting the private key
        /// in the data key pair.</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represent
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is supported only on operations with symmetric encryption
        /// KMS keys. On operations with symmetric encryption KMS keys, an encryption context
        /// is optional, but it is strongly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/encrypt_context.html">Encryption
        /// context</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionContext { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>Use a grant token when your permission to call this operation comes from a new grant
        /// that has not yet achieved <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">Grant
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/using-grant-token.html">Using
        /// a grant token</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter Recipient_KeyEncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>The encryption algorithm that KMS should use with the public key for an Amazon Web
        /// Services Nitro Enclave or NitroTPM to encrypt plaintext values for the response. The
        /// only valid value is <c>RSAES_OAEP_SHA_256</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyEncryptionMechanism")]
        public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the symmetric encryption KMS key that encrypts the private key in the data
        /// key pair. You cannot specify an asymmetric KMS key or a KMS key in a custom key store.
        /// To get the type and origin of your KMS key, use the <a>DescribeKey</a> operation.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with <c>"alias/"</c>. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// To get the alias name and alias ARN, use <a>ListAliases</a>.</para>
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
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter KeyPairSpec
        /// <summary>
        /// <para>
        /// <para>Determines the type of data key pair that is generated. </para><para>The KMS rule that restricts the use of asymmetric RSA and SM2 KMS keys to encrypt
        /// and decrypt or to sign and verify (but not both), the rule that permits you to use
        /// ECC KMS keys only to sign and verify, and the rule that permits you to use ML-DSA
        /// key pairs to sign and verify only are not effective on data key pairs, which are used
        /// outside of KMS. The SM2 key spec is only available in China Regions.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.DataKeyPairSpec")]
        public Amazon.KeyManagementService.DataKeyPairSpec KeyPairSpec { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSDataKeyPair (GenerateDataKeyPair)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse, NewKMSDataKeyPairCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            if (this.EncryptionContext != null)
            {
                context.EncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EncryptionContext.Keys)
                {
                    context.EncryptionContext.Add((String)hashKey, (System.String)(this.EncryptionContext[hashKey]));
                }
            }
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
            context.KeyPairSpec = this.KeyPairSpec;
            #if MODULAR
            if (this.KeyPairSpec == null && ParameterWasBound(nameof(this.KeyPairSpec)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyPairSpec which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Recipient_AttestationDocument = this.Recipient_AttestationDocument;
            context.Recipient_KeyEncryptionAlgorithm = this.Recipient_KeyEncryptionAlgorithm;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Recipient_AttestationDocumentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.GenerateDataKeyPairRequest();
                
                if (cmdletContext.DryRun != null)
                {
                    request.DryRun = cmdletContext.DryRun.Value;
                }
                if (cmdletContext.EncryptionContext != null)
                {
                    request.EncryptionContext = cmdletContext.EncryptionContext;
                }
                if (cmdletContext.GrantToken != null)
                {
                    request.GrantTokens = cmdletContext.GrantToken;
                }
                if (cmdletContext.KeyId != null)
                {
                    request.KeyId = cmdletContext.KeyId;
                }
                if (cmdletContext.KeyPairSpec != null)
                {
                    request.KeyPairSpec = cmdletContext.KeyPairSpec;
                }
                
                 // populate Recipient
                var requestRecipientIsNull = true;
                request.Recipient = new Amazon.KeyManagementService.Model.RecipientInfo();
                System.IO.MemoryStream requestRecipient_recipient_AttestationDocument = null;
                if (cmdletContext.Recipient_AttestationDocument != null)
                {
                    _Recipient_AttestationDocumentStream = new System.IO.MemoryStream(cmdletContext.Recipient_AttestationDocument);
                    requestRecipient_recipient_AttestationDocument = _Recipient_AttestationDocumentStream;
                }
                if (requestRecipient_recipient_AttestationDocument != null)
                {
                    request.Recipient.AttestationDocument = requestRecipient_recipient_AttestationDocument;
                    requestRecipientIsNull = false;
                }
                Amazon.KeyManagementService.KeyEncryptionMechanism requestRecipient_recipient_KeyEncryptionAlgorithm = null;
                if (cmdletContext.Recipient_KeyEncryptionAlgorithm != null)
                {
                    requestRecipient_recipient_KeyEncryptionAlgorithm = cmdletContext.Recipient_KeyEncryptionAlgorithm;
                }
                if (requestRecipient_recipient_KeyEncryptionAlgorithm != null)
                {
                    request.Recipient.KeyEncryptionAlgorithm = requestRecipient_recipient_KeyEncryptionAlgorithm;
                    requestRecipientIsNull = false;
                }
                 // determine if request.Recipient should be set to null
                if (requestRecipientIsNull)
                {
                    request.Recipient = null;
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
            finally
            {
                if( _Recipient_AttestationDocumentStream != null)
                {
                    _Recipient_AttestationDocumentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GenerateDataKeyPairRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GenerateDataKeyPair");
            try
            {
                #if DESKTOP
                return client.GenerateDataKeyPair(request);
                #elif CORECLR
                return client.GenerateDataKeyPairAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public Dictionary<System.String, System.String> EncryptionContext { get; set; }
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public Amazon.KeyManagementService.DataKeyPairSpec KeyPairSpec { get; set; }
            public byte[] Recipient_AttestationDocument { get; set; }
            public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GenerateDataKeyPairResponse, NewKMSDataKeyPairCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
