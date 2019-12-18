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
    /// Decrypts ciphertext and then reencrypts it entirely within AWS KMS. You can use this
    /// operation to change the customer master key (CMK) under which data is encrypted, such
    /// as when you <a href="https://docs.aws.amazon.com/kms/latest/developerguide/rotate-keys.html#rotate-keys-manually">manually
    /// rotate</a> a CMK or change the CMK that protects a ciphertext. You can also use it
    /// to reencrypt ciphertext under the same CMK, such as to change the encryption context
    /// of a ciphertext. 
    /// 
    ///  
    /// <para>
    /// The <code>ReEncrypt</code> operation can decrypt ciphertext that was encrypted by
    /// using an AWS KMS CMK in an AWS KMS operation, such as <a>Encrypt</a> or <a>GenerateDataKey</a>.
    /// It can also decrypt ciphertext that was encrypted by using the public key of an asymmetric
    /// CMK outside of AWS KMS. However, it cannot decrypt ciphertext produced by other libraries,
    /// such as the <a href="https://docs.aws.amazon.com/encryption-sdk/latest/developer-guide/">AWS
    /// Encryption SDK</a> or <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingClientSideEncryption.html">Amazon
    /// S3 client-side encryption</a>. These libraries return a ciphertext format that is
    /// incompatible with AWS KMS.
    /// </para><para>
    /// When you use the <code>ReEncrypt</code> operation, you need to provide information
    /// for the decrypt operation and the subsequent encrypt operation.
    /// </para><ul><li><para>
    /// If your ciphertext was encrypted under an asymmetric CMK, you must identify the <i>source
    /// CMK</i>, that is, the CMK that encrypted the ciphertext. You must also supply the
    /// encryption algorithm that was used. This information is required to decrypt the data.
    /// </para></li><li><para>
    /// It is optional, but you can specify a source CMK even when the ciphertext was encrypted
    /// under a symmetric CMK. This ensures that the ciphertext is decrypted only by using
    /// a particular CMK. If the CMK that you specify cannot decrypt the ciphertext, the <code>ReEncrypt</code>
    /// operation fails.
    /// </para></li><li><para>
    /// To reencrypt the data, you must specify the <i>destination CMK</i>, that is, the CMK
    /// that re-encrypts the data after it is decrypted. You can select a symmetric or asymmetric
    /// CMK. If the destination CMK is an asymmetric CMK, you must also provide the encryption
    /// algorithm. The algorithm that you choose must be compatible with the CMK.
    /// </para><important><para>
    /// When you use an asymmetric CMK to encrypt or reencrypt data, be sure to record the
    /// CMK and encryption algorithm that you choose. You will be required to provide the
    /// same CMK and encryption algorithm when you decrypt the data. If the CMK and algorithm
    /// do not match the values used to encrypt the data, the decrypt operation fails.
    /// </para><para>
    /// You are not required to supply the CMK ID and encryption algorithm when you decrypt
    /// with symmetric CMKs because AWS KMS stores this information in the ciphertext blob.
    /// AWS KMS cannot store metadata in ciphertext generated with asymmetric keys. The standard
    /// format for asymmetric key ciphertext does not include configurable fields.
    /// </para></important></li></ul><para>
    /// Unlike other AWS KMS API operations, <code>ReEncrypt</code> callers must have two
    /// permissions:
    /// </para><ul><li><para><code>kms:EncryptFrom</code> permission on the source CMK
    /// </para></li><li><para><code>kms:EncryptTo</code> permission on the destination CMK
    /// </para></li></ul><para>
    /// To permit reencryption from
    /// </para><para>
    ///  or to a CMK, include the <code>"kms:ReEncrypt*"</code> permission in your <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policies.html">key
    /// policy</a>. This permission is automatically included in the key policy when you use
    /// the console to create a CMK. But you must include it manually when you create a CMK
    /// programmatically or when you use the <a>PutKeyPolicy</a> operation set a key policy.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSReEncrypt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ReEncryptResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service ReEncrypt API operation.", Operation = new[] {"ReEncrypt"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ReEncryptResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ReEncryptResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.ReEncryptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKMSReEncryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
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
        /// <para>Specifies the encryption algorithm that AWS KMS will use to reecrypt the data after
        /// it has decrypted it. The default value, <code>SYMMETRIC_DEFAULT</code>, represents
        /// the encryption algorithm used for symmetric CMKs.</para><para>This parameter is required only when the destination CMK is an asymmetric CMK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.EncryptionAlgorithmSpec")]
        public Amazon.KeyManagementService.EncryptionAlgorithmSpec DestinationEncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter DestinationEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies that encryption context to use when the reencrypting the data.</para><para>A destination encryption context is valid only when the destination CMK is a symmetric
        /// CMK. The standard ciphertext format for asymmetric CMKs does not include fields for
        /// metadata.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represents
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is optional when encrypting with a symmetric CMK,
        /// but it is highly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
        /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable DestinationEncryptionContext { get; set; }
        #endregion
        
        #region Parameter DestinationKeyId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the CMK that is used to reencrypt the data. Specify a symmetric
        /// or asymmetric CMK with a <code>KeyUsage</code> value of <code>ENCRYPT_DECRYPT</code>.
        /// To find the <code>KeyUsage</code> value of a CMK, use the <a>DescribeKey</a> operation.</para><para>To specify a CMK, use its key ID, Amazon Resource Name (ARN), alias name, or alias
        /// ARN. When using an alias name, prefix it with <code>"alias/"</code>. To specify a
        /// CMK in a different AWS account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.
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
        
        #region Parameter SourceEncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption algorithm that AWS KMS will use to decrypt the ciphertext
        /// before it is reencrypted. The default value, <code>SYMMETRIC_DEFAULT</code>, represents
        /// the algorithm used for symmetric CMKs.</para><para>Specify the same algorithm that was used to encrypt the ciphertext. If you specify
        /// a different algorithm, the decrypt attempt fails.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// CMK.</para>
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
        /// encryption context that was used to encrypt the ciphertext.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represents
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is optional when encrypting with a symmetric CMK,
        /// but it is highly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
        /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable SourceEncryptionContext { get; set; }
        #endregion
        
        #region Parameter SourceKeyId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the CMK that is used to decrypt the ciphertext before it reencrypts
        /// it using the destination CMK.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// CMK. Otherwise, AWS KMS uses the metadata that it adds to the ciphertext blob to determine
        /// which CMK was used to encrypt the ciphertext. However, you can use this parameter
        /// to ensure that a particular CMK (of any kind) is used to decrypt the ciphertext before
        /// it is reencrypted.</para><para>If you specify a <code>KeyId</code> value, the decrypt part of the <code>ReEncrypt</code>
        /// operation succeeds only if the specified CMK was used to encrypt the ciphertext.</para><para>To specify a CMK, use its key ID, Amazon Resource Name (ARN), alias name, or alias
        /// ARN. When using an alias name, prefix it with <code>"alias/"</code>.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.
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
                    context.DestinationEncryptionContext.Add((String)hashKey, (String)(this.DestinationEncryptionContext[hashKey]));
                }
            }
            context.DestinationKeyId = this.DestinationKeyId;
            #if MODULAR
            if (this.DestinationKeyId == null && ParameterWasBound(nameof(this.DestinationKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
                    context.SourceEncryptionContext.Add((String)hashKey, (String)(this.SourceEncryptionContext[hashKey]));
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
            public List<System.String> GrantToken { get; set; }
            public Amazon.KeyManagementService.EncryptionAlgorithmSpec SourceEncryptionAlgorithm { get; set; }
            public Dictionary<System.String, System.String> SourceEncryptionContext { get; set; }
            public System.String SourceKeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ReEncryptResponse, InvokeKMSReEncryptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
