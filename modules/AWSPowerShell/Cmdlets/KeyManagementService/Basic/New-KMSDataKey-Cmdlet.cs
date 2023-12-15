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
    /// Returns a unique symmetric data key for use outside of KMS. This operation returns
    /// a plaintext copy of the data key and a copy that is encrypted under a symmetric encryption
    /// KMS key that you specify. The bytes in the plaintext key are random; they are not
    /// related to the caller or the KMS key. You can use the plaintext key to encrypt your
    /// data outside of KMS and store the encrypted data key with the encrypted data.
    /// 
    ///  
    /// <para>
    /// To generate a data key, specify the symmetric encryption KMS key that will be used
    /// to encrypt the data key. You cannot use an asymmetric KMS key to encrypt data keys.
    /// To get the type of your KMS key, use the <a>DescribeKey</a> operation.
    /// </para><para>
    /// You must also specify the length of the data key. Use either the <code>KeySpec</code>
    /// or <code>NumberOfBytes</code> parameters (but not both). For 128-bit and 256-bit data
    /// keys, use the <code>KeySpec</code> parameter.
    /// </para><para>
    /// To generate a 128-bit SM4 data key (China Regions only), specify a <code>KeySpec</code>
    /// value of <code>AES_128</code> or a <code>NumberOfBytes</code> value of <code>16</code>.
    /// The symmetric encryption key used in China Regions to encrypt your data key is an
    /// SM4 encryption key.
    /// </para><para>
    /// To get only an encrypted copy of the data key, use <a>GenerateDataKeyWithoutPlaintext</a>.
    /// To generate an asymmetric data key pair, use the <a>GenerateDataKeyPair</a> or <a>GenerateDataKeyPairWithoutPlaintext</a>
    /// operation. To get a cryptographically secure random byte string, use <a>GenerateRandom</a>.
    /// </para><para>
    /// You can use an optional encryption context to add additional security to the encryption
    /// operation. If you specify an <code>EncryptionContext</code>, you must specify the
    /// same encryption context (a case-sensitive exact match) when decrypting the encrypted
    /// data key. Otherwise, the request to decrypt fails with an <code>InvalidCiphertextException</code>.
    /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
    /// Context</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><code>GenerateDataKey</code> also supports <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/nitro-enclave.html">Amazon
    /// Web Services Nitro Enclaves</a>, which provide an isolated compute environment in
    /// Amazon EC2. To call <code>GenerateDataKey</code> for an Amazon Web Services Nitro
    /// enclave, use the <a href="https://docs.aws.amazon.com/enclaves/latest/user/developing-applications.html#sdk">Amazon
    /// Web Services Nitro Enclaves SDK</a> or any Amazon Web Services SDK. Use the <code>Recipient</code>
    /// parameter to provide the attestation document for the enclave. <code>GenerateDataKey</code>
    /// returns a copy of the data key encrypted under the specified KMS key, as usual. But
    /// instead of a plaintext copy of the data key, the response includes a copy of the data
    /// key encrypted under the public key from the attestation document (<code>CiphertextForRecipient</code>).
    /// For information about the interaction between KMS and Amazon Web Services Nitro Enclaves,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/services-nitro-enclaves.html">How
    /// Amazon Web Services Nitro Enclaves uses KMS</a> in the <i>Key Management Service Developer
    /// Guide</i>..
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>How to use your data key</b></para><para>
    /// We recommend that you use the following pattern to encrypt data locally in your application.
    /// You can write your own code or use a client-side encryption library, such as the <a href="https://docs.aws.amazon.com/encryption-sdk/latest/developer-guide/">Amazon Web
    /// Services Encryption SDK</a>, the <a href="https://docs.aws.amazon.com/dynamodb-encryption-client/latest/devguide/">Amazon
    /// DynamoDB Encryption Client</a>, or <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingClientSideEncryption.html">Amazon
    /// S3 client-side encryption</a> to do these tasks for you.
    /// </para><para>
    /// To encrypt data outside of KMS:
    /// </para><ol><li><para>
    /// Use the <code>GenerateDataKey</code> operation to get a data key.
    /// </para></li><li><para>
    /// Use the plaintext data key (in the <code>Plaintext</code> field of the response) to
    /// encrypt your data outside of KMS. Then erase the plaintext data key from memory.
    /// </para></li><li><para>
    /// Store the encrypted data key (in the <code>CiphertextBlob</code> field of the response)
    /// with the encrypted data.
    /// </para></li></ol><para>
    /// To decrypt data outside of KMS:
    /// </para><ol><li><para>
    /// Use the <a>Decrypt</a> operation to decrypt the encrypted data key. The operation
    /// returns a plaintext copy of the data key.
    /// </para></li><li><para>
    /// Use the plaintext data key to decrypt data outside of KMS, then erase the plaintext
    /// data key from memory.
    /// </para></li></ol><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <code>KeyId</code> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GenerateDataKey</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Decrypt</a></para></li><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li><li><para><a>GenerateDataKeyPairWithoutPlaintext</a></para></li><li><para><a>GenerateDataKeyWithoutPlaintext</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSDataKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.GenerateDataKeyResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GenerateDataKey API operation.", Operation = new[] {"GenerateDataKey"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GenerateDataKeyResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GenerateDataKeyResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GenerateDataKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSDataKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks if your request will succeed. <code>DryRun</code> is an optional parameter.
        /// </para><para>To learn more about how to use this parameter, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-dryrun.html">Testing
        /// your KMS API calls</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption context that will be used when encrypting the data key.</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represent
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is supported only on operations with symmetric encryption
        /// KMS keys. On operations with symmetric encryption KMS keys, an encryption context
        /// is optional, but it is strongly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
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
        /// token</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/grant-manage.html#using-grant-token">Using
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
        /// Services Nitro Enclave to encrypt plaintext values for the response. The only valid
        /// value is <code>RSAES_OAEP_SHA_256</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyEncryptionMechanism")]
        public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the symmetric encryption KMS key that encrypts the data key. You cannot
        /// specify an asymmetric KMS key or a KMS key in a custom key store. To get the type
        /// and origin of your KMS key, use the <a>DescribeKey</a> operation.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with <code>"alias/"</code>. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
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
        
        #region Parameter KeySpec
        /// <summary>
        /// <para>
        /// <para>Specifies the length of the data key. Use <code>AES_128</code> to generate a 128-bit
        /// symmetric key, or <code>AES_256</code> to generate a 256-bit symmetric key.</para><para>You must specify either the <code>KeySpec</code> or the <code>NumberOfBytes</code>
        /// parameter (but not both) in every <code>GenerateDataKey</code> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.DataKeySpec")]
        public Amazon.KeyManagementService.DataKeySpec KeySpec { get; set; }
        #endregion
        
        #region Parameter NumberOfBytes
        /// <summary>
        /// <para>
        /// <para>Specifies the length of the data key in bytes. For example, use the value 64 to generate
        /// a 512-bit data key (64 bytes is 512 bits). For 128-bit (16-byte) and 256-bit (32-byte)
        /// data keys, use the <code>KeySpec</code> parameter.</para><para>You must specify either the <code>KeySpec</code> or the <code>NumberOfBytes</code>
        /// parameter (but not both) in every <code>GenerateDataKey</code> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NumberOfBytes { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GenerateDataKeyResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GenerateDataKeyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSDataKey (GenerateDataKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GenerateDataKeyResponse, NewKMSDataKeyCmdlet>(Select) ??
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
                    context.EncryptionContext.Add((String)hashKey, (String)(this.EncryptionContext[hashKey]));
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
            context.KeySpec = this.KeySpec;
            context.NumberOfBytes = this.NumberOfBytes;
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
                var request = new Amazon.KeyManagementService.Model.GenerateDataKeyRequest();
                
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
                if (cmdletContext.KeySpec != null)
                {
                    request.KeySpec = cmdletContext.KeySpec;
                }
                if (cmdletContext.NumberOfBytes != null)
                {
                    request.NumberOfBytes = cmdletContext.NumberOfBytes.Value;
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
        
        private Amazon.KeyManagementService.Model.GenerateDataKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GenerateDataKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GenerateDataKey");
            try
            {
                #if DESKTOP
                return client.GenerateDataKey(request);
                #elif CORECLR
                return client.GenerateDataKeyAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KeyManagementService.DataKeySpec KeySpec { get; set; }
            public System.Int32? NumberOfBytes { get; set; }
            public byte[] Recipient_AttestationDocument { get; set; }
            public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GenerateDataKeyResponse, NewKMSDataKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
