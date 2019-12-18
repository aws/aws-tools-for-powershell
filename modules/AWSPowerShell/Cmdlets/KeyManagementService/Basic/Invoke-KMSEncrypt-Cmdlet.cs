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
    /// Encrypts plaintext into ciphertext by using a customer master key (CMK). The <code>Encrypt</code>
    /// operation has two primary use cases:
    /// 
    ///  <ul><li><para>
    /// You can encrypt small amounts of arbitrary data, such as a personal identifier or
    /// database password, or other sensitive information. 
    /// </para></li><li><para>
    /// You can use the <code>Encrypt</code> operation to move encrypted data from one AWS
    /// region to another. In the first region, generate a data key and use the plaintext
    /// key to encrypt the data. Then, in the new region, call the <code>Encrypt</code> method
    /// on same plaintext data key. Now, you can safely move the encrypted data and encrypted
    /// data key to the new region, and decrypt in the new region when necessary.
    /// </para></li></ul><para>
    /// You don't need to use the <code>Encrypt</code> operation to encrypt a data key. The
    /// <a>GenerateDataKey</a> and <a>GenerateDataKeyPair</a> operations return a plaintext
    /// data key and an encrypted copy of that data key.
    /// </para><para>
    /// When you encrypt data, you must specify a symmetric or asymmetric CMK to use in the
    /// encryption operation. The CMK must have a <code>KeyUsage</code> value of <code>ENCRYPT_DECRYPT.</code>
    /// To find the <code>KeyUsage</code> of a CMK, use the <a>DescribeKey</a> operation.
    /// 
    /// </para><para>
    /// If you use a symmetric CMK, you can use an encryption context to add additional security
    /// to your encryption operation. If you specify an <code>EncryptionContext</code> when
    /// encrypting data, you must specify the same encryption context (a case-sensitive exact
    /// match) when decrypting the data. Otherwise, the request to decrypt fails with an <code>InvalidCiphertextException</code>.
    /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
    /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// If you specify an asymmetric CMK, you must also specify the encryption algorithm.
    /// The algorithm must be compatible with the CMK type.
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
    /// </para></important><para>
    /// The maximum size of the data that you can encrypt varies with the type of CMK and
    /// the encryption algorithm that you choose.
    /// </para><ul><li><para>
    /// Symmetric CMKs
    /// </para><ul><li><para><code>SYMMETRIC_DEFAULT</code>: 4096 bytes
    /// </para></li></ul></li><li><para><code>RSA_2048</code></para><ul><li><para><code>RSAES_OAEP_SHA_1</code>: 214 bytes
    /// </para></li><li><para><code>RSAES_OAEP_SHA_256</code>: 190 bytes
    /// </para></li></ul></li><li><para><code>RSA_3072</code></para><ul><li><para><code>RSAES_OAEP_SHA_1</code>: 342 bytes
    /// </para></li><li><para><code>RSAES_OAEP_SHA_256</code>: 318 bytes
    /// </para></li></ul></li><li><para><code>RSA_4096</code></para><ul><li><para><code>RSAES_OAEP_SHA_1</code>: 470 bytes
    /// </para></li><li><para><code>RSAES_OAEP_SHA_256</code>: 446 bytes
    /// </para></li></ul></li></ul><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para><para>
    /// To perform this operation on a CMK in a different AWS account, specify the key ARN
    /// or alias ARN in the value of the KeyId parameter.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSEncrypt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.EncryptResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service Encrypt API operation.", Operation = new[] {"Encrypt"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.EncryptResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.EncryptResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.EncryptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKMSEncryptCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption algorithm that AWS KMS will use to encrypt the plaintext
        /// message. The algorithm must be compatible with the CMK that you specify.</para><para>This parameter is required only for asymmetric CMKs. The default value, <code>SYMMETRIC_DEFAULT</code>,
        /// is the algorithm used for symmetric CMKs. If you are using an asymmetric CMK, we recommend
        /// RSAES_OAEP_SHA_256.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.EncryptionAlgorithmSpec")]
        public Amazon.KeyManagementService.EncryptionAlgorithmSpec EncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption context that will be used to encrypt the data. An encryption
        /// context is valid only for cryptographic operations with a symmetric CMK. The standard
        /// asymmetric encryption algorithms that AWS KMS uses do not support an encryption context.
        /// </para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represents
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
        /// <para>A unique identifier for the customer master key (CMK).</para><para>To specify a CMK, use its key ID, Amazon Resource Name (ARN), alias name, or alias
        /// ARN. When using an alias name, prefix it with <code>"alias/"</code>. To specify a
        /// CMK in a different AWS account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.
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
        
        #region Parameter Plaintext
        /// <summary>
        /// <para>
        /// <para>Data to be encrypted.</para>
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
        public byte[] Plaintext { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.EncryptResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.EncryptResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KMSEncrypt (Encrypt)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.EncryptResponse, InvokeKMSEncryptCmdlet>(Select) ??
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
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Plaintext = this.Plaintext;
            #if MODULAR
            if (this.Plaintext == null && ParameterWasBound(nameof(this.Plaintext)))
            {
                WriteWarning("You are passing $null as a value for parameter Plaintext which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _PlaintextStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.EncryptRequest();
                
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
                if (cmdletContext.Plaintext != null)
                {
                    _PlaintextStream = new System.IO.MemoryStream(cmdletContext.Plaintext);
                    request.Plaintext = _PlaintextStream;
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
                if( _PlaintextStream != null)
                {
                    _PlaintextStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.EncryptResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.EncryptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "Encrypt");
            try
            {
                #if DESKTOP
                return client.Encrypt(request);
                #elif CORECLR
                return client.EncryptAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KeyManagementService.EncryptionAlgorithmSpec EncryptionAlgorithm { get; set; }
            public Dictionary<System.String, System.String> EncryptionContext { get; set; }
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public byte[] Plaintext { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.EncryptResponse, InvokeKMSEncryptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
