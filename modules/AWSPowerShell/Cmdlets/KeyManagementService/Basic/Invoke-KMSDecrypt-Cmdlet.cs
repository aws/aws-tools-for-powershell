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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Decrypts ciphertext that was encrypted by a KMS key using any of the following operations:
    /// 
    ///  <ul><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li><li><para><a>GenerateDataKeyWithoutPlaintext</a></para></li><li><para><a>GenerateDataKeyPairWithoutPlaintext</a></para></li></ul><para>
    /// You can use this operation to decrypt ciphertext that was encrypted under a symmetric
    /// encryption KMS key or an asymmetric encryption KMS key. When the KMS key is asymmetric,
    /// you must specify the KMS key and the encryption algorithm that was used to encrypt
    /// the ciphertext. For information about asymmetric KMS keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Asymmetric
    /// KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The <c>Decrypt</c> operation also decrypts ciphertext that was encrypted outside of
    /// KMS by the public key in an KMS asymmetric KMS key. However, it cannot decrypt symmetric
    /// ciphertext produced by other libraries, such as the <a href="https://docs.aws.amazon.com/encryption-sdk/latest/developer-guide/">Amazon
    /// Web Services Encryption SDK</a> or <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingClientSideEncryption.html">Amazon
    /// S3 client-side encryption</a>. These libraries return a ciphertext format that is
    /// incompatible with KMS.
    /// </para><para>
    /// If the ciphertext was encrypted under a symmetric encryption KMS key, the <c>KeyId</c>
    /// parameter is optional. KMS can get this information from metadata that it adds to
    /// the symmetric ciphertext blob. This feature adds durability to your implementation
    /// by ensuring that authorized users can decrypt ciphertext decades after it was encrypted,
    /// even if they've lost track of the key ID. However, specifying the KMS key is always
    /// recommended as a best practice. When you use the <c>KeyId</c> parameter to specify
    /// a KMS key, KMS only uses the KMS key you specify. If the ciphertext was encrypted
    /// under a different KMS key, the <c>Decrypt</c> operation fails. This practice ensures
    /// that you use the KMS key that you intend.
    /// </para><para>
    /// Whenever possible, use key policies to give users permission to call the <c>Decrypt</c>
    /// operation on a particular KMS key, instead of using IAM policies. Otherwise, you might
    /// create an IAM policy that gives the user <c>Decrypt</c> permission on all KMS keys.
    /// This user could decrypt ciphertext that was encrypted by KMS keys in other accounts
    /// if the key policy for the cross-account KMS key permits it. If you must use an IAM
    /// policy for <c>Decrypt</c> permissions, limit the user to particular KMS keys or particular
    /// trusted accounts. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/iam-policies.html#iam-policies-best-practices">Best
    /// practices for IAM policies</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><c>Decrypt</c> also supports <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/nitro-enclave.html">Amazon
    /// Web Services Nitro Enclaves</a>, which provide an isolated compute environment in
    /// Amazon EC2. To call <c>Decrypt</c> for a Nitro enclave, use the <a href="https://docs.aws.amazon.com/enclaves/latest/user/developing-applications.html#sdk">Amazon
    /// Web Services Nitro Enclaves SDK</a> or any Amazon Web Services SDK. Use the <c>Recipient</c>
    /// parameter to provide the attestation document for the enclave. Instead of the plaintext
    /// data, the response includes the plaintext data encrypted with the public key from
    /// the attestation document (<c>CiphertextForRecipient</c>). For information about the
    /// interaction between KMS and Amazon Web Services Nitro Enclaves, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/services-nitro-enclaves.html">How
    /// Amazon Web Services Nitro Enclaves uses KMS</a> in the <i>Key Management Service Developer
    /// Guide</i>.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. If you use the <c>KeyId</c> parameter to identify
    /// a KMS key in a different Amazon Web Services account, specify the key ARN or the alias
    /// ARN of the KMS key.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:Decrypt</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li><li><para><a>ReEncrypt</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/accessing-kms.html#programming-eventual-consistency">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSDecrypt")]
    [OutputType("Amazon.KeyManagementService.Model.DecryptResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service Decrypt API operation.", Operation = new[] {"Decrypt"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.DecryptResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.DecryptResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.DecryptResponse object containing multiple properties."
    )]
    public partial class InvokeKMSDecryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Recipient_AttestationDocument
        /// <summary>
        /// <para>
        /// <para>The attestation document for an Amazon Web Services Nitro Enclave. This document includes
        /// the enclave's public key.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Recipient_AttestationDocument { get; set; }
        #endregion
        
        #region Parameter CiphertextBlob
        /// <summary>
        /// <para>
        /// <para>Ciphertext to be decrypted. The blob includes metadata.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CiphertextBlob { get; set; }
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
        
        #region Parameter EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption algorithm that will be used to decrypt the ciphertext. Specify
        /// the same algorithm that was used to encrypt the data. If you specify a different algorithm,
        /// the <c>Decrypt</c> operation fails.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// KMS key. The default value, <c>SYMMETRIC_DEFAULT</c>, represents the only supported
        /// algorithm that is valid for symmetric encryption KMS keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.EncryptionAlgorithmSpec")]
        public Amazon.KeyManagementService.EncryptionAlgorithmSpec EncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption context to use when decrypting the data. An encryption context
        /// is valid only for <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-cryptography.html#cryptographic-operations">cryptographic
        /// operations</a> with a symmetric encryption KMS key. The standard asymmetric encryption
        /// algorithms and HMAC algorithms that KMS uses do not support an encryption context.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represent
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is supported only on operations with symmetric encryption
        /// KMS keys. On operations with symmetric encryption KMS keys, an encryption context
        /// is optional, but it is strongly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/encrypt_context.html">Encryption
        /// context</a> in the <i>Key Management Service Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionContext { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens. </para><para>Use a grant token when your permission to call this operation comes from a new grant
        /// that has not yet achieved <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grants.html#grant_token">Grant
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/using-grant-token.html">Using
        /// a grant token</a> in the <i>Key Management Service Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// Services Nitro Enclave to encrypt plaintext values for the response. The only valid
        /// value is <c>RSAES_OAEP_SHA_256</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyEncryptionMechanism")]
        public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the KMS key that KMS uses to decrypt the ciphertext.</para><para>Enter a key ID of the KMS key that was used to encrypt the ciphertext. If you identify
        /// a different KMS key, the <c>Decrypt</c> operation throws an <c>IncorrectKeyException</c>.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// KMS key. If you used a symmetric encryption KMS key, KMS can get the KMS key from
        /// metadata that it adds to the symmetric ciphertext blob. However, it is always recommended
        /// as a best practice. This practice ensures that you use the KMS key that you intend.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with <c>"alias/"</c>. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// To get the alias name and alias ARN, use <a>ListAliases</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.DecryptResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.DecryptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.DecryptResponse, InvokeKMSDecryptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CiphertextBlob = this.CiphertextBlob;
            #if MODULAR
            if (this.CiphertextBlob == null && ParameterWasBound(nameof(this.CiphertextBlob)))
            {
                WriteWarning("You are passing $null as a value for parameter CiphertextBlob which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.EncryptionAlgorithm = this.EncryptionAlgorithm;
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
            System.IO.MemoryStream _CiphertextBlobStream = null;
            System.IO.MemoryStream _Recipient_AttestationDocumentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.DecryptRequest();
                
                if (cmdletContext.CiphertextBlob != null)
                {
                    _CiphertextBlobStream = new System.IO.MemoryStream(cmdletContext.CiphertextBlob);
                    request.CiphertextBlob = _CiphertextBlobStream;
                }
                if (cmdletContext.DryRun != null)
                {
                    request.DryRun = cmdletContext.DryRun.Value;
                }
                if (cmdletContext.EncryptionAlgorithm != null)
                {
                    request.EncryptionAlgorithm = cmdletContext.EncryptionAlgorithm;
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
                if( _CiphertextBlobStream != null)
                {
                    _CiphertextBlobStream.Dispose();
                }
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
        
        private Amazon.KeyManagementService.Model.DecryptResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.DecryptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "Decrypt");
            try
            {
                return client.DecryptAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] CiphertextBlob { get; set; }
            public System.Boolean? DryRun { get; set; }
            public Amazon.KeyManagementService.EncryptionAlgorithmSpec EncryptionAlgorithm { get; set; }
            public Dictionary<System.String, System.String> EncryptionContext { get; set; }
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public byte[] Recipient_AttestationDocument { get; set; }
            public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.DecryptResponse, InvokeKMSDecryptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
