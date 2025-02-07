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
    /// Decrypts ciphertext and then reencrypts it entirely within KMS. You can use this operation
    /// to change the KMS key under which data is encrypted, such as when you <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html#rotate-keys-manually">manually
    /// rotate</a> a KMS key or change the KMS key that protects a ciphertext. You can also
    /// use it to reencrypt ciphertext under the same KMS key, such as to change the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">encryption
    /// context</a> of a ciphertext.
    /// 
    ///  
    /// <para>
    /// The <c>ReEncrypt</c> operation can decrypt ciphertext that was encrypted by using
    /// a KMS key in an KMS operation, such as <a>Encrypt</a> or <a>GenerateDataKey</a>. It
    /// can also decrypt ciphertext that was encrypted by using the public key of an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symm-asymm-concepts.html#asymmetric-cmks">asymmetric
    /// KMS key</a> outside of KMS. However, it cannot decrypt ciphertext produced by other
    /// libraries, such as the <a href="https://docs.aws.amazon.com/encryption-sdk/latest/developer-guide/">Amazon
    /// Web Services Encryption SDK</a> or <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingClientSideEncryption.html">Amazon
    /// S3 client-side encryption</a>. These libraries return a ciphertext format that is
    /// incompatible with KMS.
    /// </para><para>
    /// When you use the <c>ReEncrypt</c> operation, you need to provide information for the
    /// decrypt operation and the subsequent encrypt operation.
    /// </para><ul><li><para>
    /// If your ciphertext was encrypted under an asymmetric KMS key, you must use the <c>SourceKeyId</c>
    /// parameter to identify the KMS key that encrypted the ciphertext. You must also supply
    /// the encryption algorithm that was used. This information is required to decrypt the
    /// data.
    /// </para></li><li><para>
    /// If your ciphertext was encrypted under a symmetric encryption KMS key, the <c>SourceKeyId</c>
    /// parameter is optional. KMS can get this information from metadata that it adds to
    /// the symmetric ciphertext blob. This feature adds durability to your implementation
    /// by ensuring that authorized users can decrypt ciphertext decades after it was encrypted,
    /// even if they've lost track of the key ID. However, specifying the source KMS key is
    /// always recommended as a best practice. When you use the <c>SourceKeyId</c> parameter
    /// to specify a KMS key, KMS uses only the KMS key you specify. If the ciphertext was
    /// encrypted under a different KMS key, the <c>ReEncrypt</c> operation fails. This practice
    /// ensures that you use the KMS key that you intend.
    /// </para></li><li><para>
    /// To reencrypt the data, you must use the <c>DestinationKeyId</c> parameter to specify
    /// the KMS key that re-encrypts the data after it is decrypted. If the destination KMS
    /// key is an asymmetric KMS key, you must also provide the encryption algorithm. The
    /// algorithm that you choose must be compatible with the KMS key.
    /// </para><important><para>
    /// When you use an asymmetric KMS key to encrypt or reencrypt data, be sure to record
    /// the KMS key and encryption algorithm that you choose. You will be required to provide
    /// the same KMS key and encryption algorithm when you decrypt the data. If the KMS key
    /// and algorithm do not match the values used to encrypt the data, the decrypt operation
    /// fails.
    /// </para><para>
    /// You are not required to supply the key ID and encryption algorithm when you decrypt
    /// with symmetric encryption KMS keys because KMS stores this information in the ciphertext
    /// blob. KMS cannot store metadata in ciphertext generated with asymmetric keys. The
    /// standard format for asymmetric key ciphertext does not include configurable fields.
    /// </para></important></li></ul><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. The source KMS key and destination KMS key can be
    /// in different Amazon Web Services accounts. Either or both KMS keys can be in a different
    /// account than the caller. To specify a KMS key in a different account, you must use
    /// its key ARN or alias ARN.
    /// </para><para><b>Required permissions</b>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:ReEncryptFrom</a>
    /// permission on the source KMS key (key policy)
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:ReEncryptTo</a>
    /// permission on the destination KMS key (key policy)
    /// </para></li></ul><para>
    /// To permit reencryption from or to a KMS key, include the <c>"kms:ReEncrypt*"</c> permission
    /// in your <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">key
    /// policy</a>. This permission is automatically included in the key policy when you use
    /// the console to create a KMS key. But you must include it manually when you create
    /// a KMS key programmatically or when you use the <a>PutKeyPolicy</a> operation to set
    /// a key policy.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Decrypt</a></para></li><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSReEncrypt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ReEncryptResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service ReEncrypt API operation.", Operation = new[] {"ReEncrypt"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ReEncryptResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ReEncryptResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.ReEncryptResponse object containing multiple properties."
    )]
    public partial class InvokeKMSReEncryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CiphertextBlob
        /// <summary>
        /// <para>
        /// <para>Ciphertext of the data to reencrypt.</para>
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
        
        #region Parameter DestinationEncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption algorithm that KMS will use to reecrypt the data after it
        /// has decrypted it. The default value, <c>SYMMETRIC_DEFAULT</c>, represents the encryption
        /// algorithm used for symmetric encryption KMS keys.</para><para>This parameter is required only when the destination KMS key is an asymmetric KMS
        /// key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.EncryptionAlgorithmSpec")]
        public Amazon.KeyManagementService.EncryptionAlgorithmSpec DestinationEncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter DestinationEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies that encryption context to use when the reencrypting the data.</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><para>A destination encryption context is valid only when the destination KMS key is a symmetric
        /// encryption KMS key. The standard ciphertext format for asymmetric KMS keys does not
        /// include fields for metadata.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represent
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is supported only on operations with symmetric encryption
        /// KMS keys. On operations with symmetric encryption KMS keys, an encryption context
        /// is optional, but it is strongly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
        /// context</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DestinationEncryptionContext { get; set; }
        #endregion
        
        #region Parameter DestinationKeyId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the KMS key that is used to reencrypt the data. Specify a
        /// symmetric encryption KMS key or an asymmetric KMS key with a <c>KeyUsage</c> value
        /// of <c>ENCRYPT_DECRYPT</c>. To find the <c>KeyUsage</c> value of a KMS key, use the
        /// <a>DescribeKey</a> operation.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with <c>"alias/"</c>. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// To get the alias name and alias ARN, use <a>ListAliases</a>.</para>
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
        public System.String DestinationKeyId { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks if your request will succeed. <c>DryRun</c> is an optional parameter. </para><para>To learn more about how to use this parameter, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-dryrun.html">Testing
        /// your KMS API calls</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
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
        
        #region Parameter SourceEncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption algorithm that KMS will use to decrypt the ciphertext before
        /// it is reencrypted. The default value, <c>SYMMETRIC_DEFAULT</c>, represents the algorithm
        /// used for symmetric encryption KMS keys.</para><para>Specify the same algorithm that was used to encrypt the ciphertext. If you specify
        /// a different algorithm, the decrypt attempt fails.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.EncryptionAlgorithmSpec")]
        public Amazon.KeyManagementService.EncryptionAlgorithmSpec SourceEncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter SourceEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption context to use to decrypt the ciphertext. Enter the same
        /// encryption context that was used to encrypt the ciphertext.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represent
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is supported only on operations with symmetric encryption
        /// KMS keys. On operations with symmetric encryption KMS keys, an encryption context
        /// is optional, but it is strongly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
        /// context</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable SourceEncryptionContext { get; set; }
        #endregion
        
        #region Parameter SourceKeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the KMS key that KMS will use to decrypt the ciphertext before it is re-encrypted.</para><para>Enter a key ID of the KMS key that was used to encrypt the ciphertext. If you identify
        /// a different KMS key, the <c>ReEncrypt</c> operation throws an <c>IncorrectKeyException</c>.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// KMS key. If you used a symmetric encryption KMS key, KMS can get the KMS key from
        /// metadata that it adds to the symmetric ciphertext blob. However, it is always recommended
        /// as a best practice. This practice ensures that you use the KMS key that you intend.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
        /// an alias name, prefix it with <c>"alias/"</c>. To specify a KMS key in a different
        /// Amazon Web Services account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Alias name: <c>alias/ExampleAlias</c></para></li><li><para>Alias ARN: <c>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.
        /// To get the alias name and alias ARN, use <a>ListAliases</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.ReEncryptResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.ReEncryptResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KMSReEncrypt (ReEncrypt)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.ReEncryptResponse, InvokeKMSReEncryptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CiphertextBlob = this.CiphertextBlob;
            #if MODULAR
            if (this.CiphertextBlob == null && ParameterWasBound(nameof(this.CiphertextBlob)))
            {
                WriteWarning("You are passing $null as a value for parameter CiphertextBlob which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationEncryptionAlgorithm = this.DestinationEncryptionAlgorithm;
            if (this.DestinationEncryptionContext != null)
            {
                context.DestinationEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DestinationEncryptionContext.Keys)
                {
                    context.DestinationEncryptionContext.Add((String)hashKey, (System.String)(this.DestinationEncryptionContext[hashKey]));
                }
            }
            context.DestinationKeyId = this.DestinationKeyId;
            #if MODULAR
            if (this.DestinationKeyId == null && ParameterWasBound(nameof(this.DestinationKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            if (this.GrantToken != null)
            {
                context.GrantToken = new List<System.String>(this.GrantToken);
            }
            context.SourceEncryptionAlgorithm = this.SourceEncryptionAlgorithm;
            if (this.SourceEncryptionContext != null)
            {
                context.SourceEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SourceEncryptionContext.Keys)
                {
                    context.SourceEncryptionContext.Add((String)hashKey, (System.String)(this.SourceEncryptionContext[hashKey]));
                }
            }
            context.SourceKeyId = this.SourceKeyId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _CiphertextBlobStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.ReEncryptRequest();
                
                if (cmdletContext.CiphertextBlob != null)
                {
                    _CiphertextBlobStream = new System.IO.MemoryStream(cmdletContext.CiphertextBlob);
                    request.CiphertextBlob = _CiphertextBlobStream;
                }
                if (cmdletContext.DestinationEncryptionAlgorithm != null)
                {
                    request.DestinationEncryptionAlgorithm = cmdletContext.DestinationEncryptionAlgorithm;
                }
                if (cmdletContext.DestinationEncryptionContext != null)
                {
                    request.DestinationEncryptionContext = cmdletContext.DestinationEncryptionContext;
                }
                if (cmdletContext.DestinationKeyId != null)
                {
                    request.DestinationKeyId = cmdletContext.DestinationKeyId;
                }
                if (cmdletContext.DryRun != null)
                {
                    request.DryRun = cmdletContext.DryRun.Value;
                }
                if (cmdletContext.GrantToken != null)
                {
                    request.GrantTokens = cmdletContext.GrantToken;
                }
                if (cmdletContext.SourceEncryptionAlgorithm != null)
                {
                    request.SourceEncryptionAlgorithm = cmdletContext.SourceEncryptionAlgorithm;
                }
                if (cmdletContext.SourceEncryptionContext != null)
                {
                    request.SourceEncryptionContext = cmdletContext.SourceEncryptionContext;
                }
                if (cmdletContext.SourceKeyId != null)
                {
                    request.SourceKeyId = cmdletContext.SourceKeyId;
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
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.ReEncryptResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ReEncryptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "ReEncrypt");
            try
            {
                #if DESKTOP
                return client.ReEncrypt(request);
                #elif CORECLR
                return client.ReEncryptAsync(request).GetAwaiter().GetResult();
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
            public byte[] CiphertextBlob { get; set; }
            public Amazon.KeyManagementService.EncryptionAlgorithmSpec DestinationEncryptionAlgorithm { get; set; }
            public Dictionary<System.String, System.String> DestinationEncryptionContext { get; set; }
            public System.String DestinationKeyId { get; set; }
            public System.Boolean? DryRun { get; set; }
            public List<System.String> GrantToken { get; set; }
            public Amazon.KeyManagementService.EncryptionAlgorithmSpec SourceEncryptionAlgorithm { get; set; }
            public Dictionary<System.String, System.String> SourceEncryptionContext { get; set; }
            public System.String SourceKeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ReEncryptResponse, InvokeKMSReEncryptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
