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
    /// Generates a unique symmetric data key for client-side encryption. This operation returns
    /// a plaintext copy of the data key and a copy that is encrypted under a customer master
    /// key (CMK) that you specify. You can use the plaintext key to encrypt your data outside
    /// of AWS KMS and store the encrypted data key with the encrypted data.
    /// 
    ///  
    /// <para><code>GenerateDataKey</code> returns a unique data key for each request. The bytes
    /// in the plaintext key are not related to the caller or the CMK.
    /// </para><para>
    /// To generate a data key, specify the symmetric CMK that will be used to encrypt the
    /// data key. You cannot use an asymmetric CMK to generate data keys. To get the type
    /// of your CMK, use the <a>DescribeKey</a> operation. You must also specify the length
    /// of the data key. Use either the <code>KeySpec</code> or <code>NumberOfBytes</code>
    /// parameters (but not both). For 128-bit and 256-bit data keys, use the <code>KeySpec</code>
    /// parameter. 
    /// </para><para>
    /// To get only an encrypted copy of the data key, use <a>GenerateDataKeyWithoutPlaintext</a>.
    /// To generate an asymmetric data key pair, use the <a>GenerateDataKeyPair</a> or <a>GenerateDataKeyPairWithoutPlaintext</a>
    /// operation. To get a cryptographically secure random byte string, use <a>GenerateRandom</a>.
    /// </para><para>
    /// You can use the optional encryption context to add additional security to the encryption
    /// operation. If you specify an <code>EncryptionContext</code>, you must specify the
    /// same encryption context (a case-sensitive exact match) when decrypting the encrypted
    /// data key. Otherwise, the request to decrypt fails with an <code>InvalidCiphertextException</code>.
    /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
    /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para><para><b>How to use your data key</b></para><para>
    /// We recommend that you use the following pattern to encrypt data locally in your application.
    /// You can write your own code or use a client-side encryption library, such as the <a href="https://docs.aws.amazon.com/encryption-sdk/latest/developer-guide/">AWS Encryption
    /// SDK</a>, the <a href="https://docs.aws.amazon.com/dynamodb-encryption-client/latest/devguide/">Amazon
    /// DynamoDB Encryption Client</a>, or <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingClientSideEncryption.html">Amazon
    /// S3 client-side encryption</a> to do these tasks for you.
    /// </para><para>
    /// To encrypt data outside of AWS KMS:
    /// </para><ol><li><para>
    /// Use the <code>GenerateDataKey</code> operation to get a data key.
    /// </para></li><li><para>
    /// Use the plaintext data key (in the <code>Plaintext</code> field of the response) to
    /// encrypt your data outside of AWS KMS. Then erase the plaintext data key from memory.
    /// </para></li><li><para>
    /// Store the encrypted data key (in the <code>CiphertextBlob</code> field of the response)
    /// with the encrypted data.
    /// </para></li></ol><para>
    /// To decrypt data outside of AWS KMS:
    /// </para><ol><li><para>
    /// Use the <a>Decrypt</a> operation to decrypt the encrypted data key. The operation
    /// returns a plaintext copy of the data key.
    /// </para></li><li><para>
    /// Use the plaintext data key to decrypt data outside of AWS KMS, then erase the plaintext
    /// data key from memory.
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("New", "KMSDataKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.GenerateDataKeyResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GenerateDataKey API operation.", Operation = new[] {"GenerateDataKey"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GenerateDataKeyResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GenerateDataKeyResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GenerateDataKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSDataKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption context that will be used when encrypting the data key.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represents
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
        /// <para>Identifies the symmetric CMK that encrypts the data key.</para><para>To specify a CMK, use its key ID, Amazon Resource Name (ARN), alias name, or alias
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
            var request = new Amazon.KeyManagementService.Model.GenerateDataKeyRequest();
            
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
            public Dictionary<System.String, System.String> EncryptionContext { get; set; }
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public Amazon.KeyManagementService.DataKeySpec KeySpec { get; set; }
            public System.Int32? NumberOfBytes { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GenerateDataKeyResponse, NewKMSDataKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
