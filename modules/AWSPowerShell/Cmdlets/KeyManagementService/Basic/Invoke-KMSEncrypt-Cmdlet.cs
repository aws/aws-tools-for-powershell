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
    /// Encrypts plaintext of up to 4,096 bytes using a KMS key. You can use a symmetric or
    /// asymmetric KMS key with a <c>KeyUsage</c> of <c>ENCRYPT_DECRYPT</c>.
    /// 
    ///  
    /// <para>
    /// You can use this operation to encrypt small amounts of arbitrary data, such as a personal
    /// identifier or database password, or other sensitive information. You don't need to
    /// use the <c>Encrypt</c> operation to encrypt a data key. The <a>GenerateDataKey</a>
    /// and <a>GenerateDataKeyPair</a> operations return a plaintext data key and an encrypted
    /// copy of that data key.
    /// </para><para>
    /// If you use a symmetric encryption KMS key, you can use an encryption context to add
    /// additional security to your encryption operation. If you specify an <c>EncryptionContext</c>
    /// when encrypting data, you must specify the same encryption context (a case-sensitive
    /// exact match) when decrypting the data. Otherwise, the request to decrypt fails with
    /// an <c>InvalidCiphertextException</c>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
    /// Context</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// If you specify an asymmetric KMS key, you must also specify the encryption algorithm.
    /// The algorithm must be compatible with the KMS key spec.
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
    /// </para></important><para>
    /// The maximum size of the data that you can encrypt varies with the type of KMS key
    /// and the encryption algorithm that you choose.
    /// </para><ul><li><para>
    /// Symmetric encryption KMS keys
    /// </para><ul><li><para><c>SYMMETRIC_DEFAULT</c>: 4096 bytes
    /// </para></li></ul></li><li><para><c>RSA_2048</c></para><ul><li><para><c>RSAES_OAEP_SHA_1</c>: 214 bytes
    /// </para></li><li><para><c>RSAES_OAEP_SHA_256</c>: 190 bytes
    /// </para></li></ul></li><li><para><c>RSA_3072</c></para><ul><li><para><c>RSAES_OAEP_SHA_1</c>: 342 bytes
    /// </para></li><li><para><c>RSAES_OAEP_SHA_256</c>: 318 bytes
    /// </para></li></ul></li><li><para><c>RSA_4096</c></para><ul><li><para><c>RSAES_OAEP_SHA_1</c>: 470 bytes
    /// </para></li><li><para><c>RSAES_OAEP_SHA_256</c>: 446 bytes
    /// </para></li></ul></li><li><para><c>SM2PKE</c>: 1024 bytes (China Regions only)
    /// </para></li></ul><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <c>KeyId</c> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:Encrypt</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Decrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
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
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption algorithm that KMS will use to encrypt the plaintext message.
        /// The algorithm must be compatible with the KMS key that you specify.</para><para>This parameter is required only for asymmetric KMS keys. The default value, <c>SYMMETRIC_DEFAULT</c>,
        /// is the algorithm used for symmetric encryption KMS keys. If you are using an asymmetric
        /// KMS key, we recommend RSAES_OAEP_SHA_256.</para><para>The SM2PKE algorithm is only available in China Regions.</para>
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
        /// context is valid only for <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#cryptographic-operations">cryptographic
        /// operations</a> with a symmetric encryption KMS key. The standard asymmetric encryption
        /// algorithms and HMAC algorithms that KMS uses do not support an encryption context.
        /// </para><important><para>Do not include confidential or sensitive information in this field. This field may
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
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>Identifies the KMS key to use in the encryption operation. The KMS key must have a
        /// <c>KeyUsage</c> of <c>ENCRYPT_DECRYPT</c>. To find the <c>KeyUsage</c> of a KMS key,
        /// use the <a>DescribeKey</a> operation.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
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
            this._AWSSignerType = "v4";
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
            context.DryRun = this.DryRun;
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
            public System.Boolean? DryRun { get; set; }
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
