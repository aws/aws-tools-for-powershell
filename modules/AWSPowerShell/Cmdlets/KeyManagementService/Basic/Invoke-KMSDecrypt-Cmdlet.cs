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
    /// Decrypts ciphertext that was encrypted by a AWS KMS customer master key (CMK) using
    /// any of the following operations:
    /// 
    ///  <ul><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li><li><para><a>GenerateDataKeyWithoutPlaintext</a></para></li><li><para><a>GenerateDataKeyPairWithoutPlaintext</a></para></li></ul><para>
    /// You can use this operation to decrypt ciphertext that was encrypted under a symmetric
    /// or asymmetric CMK. When the CMK is asymmetric, you must specify the CMK and the encryption
    /// algorithm that was used to encrypt the ciphertext. For information about symmetric
    /// and asymmetric CMKs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
    /// Symmetric and Asymmetric CMKs</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The Decrypt operation also decrypts ciphertext that was encrypted outside of AWS KMS
    /// by the public key in an AWS KMS asymmetric CMK. However, it cannot decrypt ciphertext
    /// produced by other libraries, such as the <a href="https://docs.aws.amazon.com/encryption-sdk/latest/developer-guide/">AWS
    /// Encryption SDK</a> or <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingClientSideEncryption.html">Amazon
    /// S3 client-side encryption</a>. These libraries return a ciphertext format that is
    /// incompatible with AWS KMS.
    /// </para><para>
    /// If the ciphertext was encrypted under a symmetric CMK, the <code>KeyId</code> parameter
    /// is optional. AWS KMS can get this information from metadata that it adds to the symmetric
    /// ciphertext blob. This feature adds durability to your implementation by ensuring that
    /// authorized users can decrypt ciphertext decades after it was encrypted, even if they've
    /// lost track of the CMK ID. However, specifying the CMK is always recommended as a best
    /// practice. When you use the <code>KeyId</code> parameter to specify a CMK, AWS KMS
    /// only uses the CMK you specify. If the ciphertext was encrypted under a different CMK,
    /// the <code>Decrypt</code> operation fails. This practice ensures that you use the CMK
    /// that you intend.
    /// </para><para>
    /// Whenever possible, use key policies to give users permission to call the <code>Decrypt</code>
    /// operation on a particular CMK, instead of using IAM policies. Otherwise, you might
    /// create an IAM user policy that gives the user <code>Decrypt</code> permission on all
    /// CMKs. This user could decrypt ciphertext that was encrypted by CMKs in other accounts
    /// if the key policy for the cross-account CMK permits it. If you must use an IAM policy
    /// for <code>Decrypt</code> permissions, limit the user to particular CMKs or particular
    /// trusted accounts. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/iam-policies.html#iam-policies-best-practices">Best
    /// practices for IAM policies</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// state: Effect on your CMK</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. You can decrypt a ciphertext using a CMK in a different
    /// AWS account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:Decrypt</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li><li><para><a>ReEncrypt</a></para></li></ul>
    /// </summary>
    [Cmdlet("Invoke", "KMSDecrypt")]
    [OutputType("Amazon.KeyManagementService.Model.DecryptResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service Decrypt API operation.", Operation = new[] {"Decrypt"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.DecryptResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.DecryptResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.DecryptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKMSDecryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption algorithm that will be used to decrypt the ciphertext. Specify
        /// the same algorithm that was used to encrypt the data. If you specify a different algorithm,
        /// the <code>Decrypt</code> operation fails.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// CMK. The default value, <code>SYMMETRIC_DEFAULT</code>, represents the only supported
        /// algorithm that is valid for symmetric CMKs.</para>
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
        /// is valid only for <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#cryptographic-operations">cryptographic
        /// operations</a> with a symmetric CMK. The standard asymmetric encryption algorithms
        /// that AWS KMS uses do not support an encryption context.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represents
        /// additional authenticated data. When you use an encryption context to encrypt data,
        /// you must specify the same (an exact case-sensitive match) encryption context to decrypt
        /// the data. An encryption context is optional when encrypting with a symmetric CMK,
        /// but it is highly recommended.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
        /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable EncryptionContext { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens. </para><para>Use a grant token when your permission to call this operation comes from a newly created
        /// grant that has not yet achieved eventual consistency. Use a grant token when your
        /// permission to call this operation comes from a new grant that has not yet achieved
        /// <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
        /// token</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the customer master key (CMK) that AWS KMS uses to decrypt the ciphertext.
        /// Enter a key ID of the CMK that was used to encrypt the ciphertext.</para><para>This parameter is required only when the ciphertext was encrypted under an asymmetric
        /// CMK. If you used a symmetric CMK, AWS KMS can get the CMK from metadata that it adds
        /// to the symmetric ciphertext blob. However, it is always recommended as a best practice.
        /// This practice ensures that you use the CMK that you intend.</para><para>To specify a CMK, use its key ID, key ARN, alias name, or alias ARN. When using an
        /// alias name, prefix it with <code>"alias/"</code>. To specify a CMK in a different
        /// AWS account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.
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
            context.EncryptionAlgorithm = this.EncryptionAlgorithm;
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
                var request = new Amazon.KeyManagementService.Model.DecryptRequest();
                
                if (cmdletContext.CiphertextBlob != null)
                {
                    _CiphertextBlobStream = new System.IO.MemoryStream(cmdletContext.CiphertextBlob);
                    request.CiphertextBlob = _CiphertextBlobStream;
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
        
        private Amazon.KeyManagementService.Model.DecryptResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.DecryptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "Decrypt");
            try
            {
                #if DESKTOP
                return client.Decrypt(request);
                #elif CORECLR
                return client.DecryptAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KeyManagementService.EncryptionAlgorithmSpec EncryptionAlgorithm { get; set; }
            public Dictionary<System.String, System.String> EncryptionContext { get; set; }
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.DecryptResponse, InvokeKMSDecryptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
