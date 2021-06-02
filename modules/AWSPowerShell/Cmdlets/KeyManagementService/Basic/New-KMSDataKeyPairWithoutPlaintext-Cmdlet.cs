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
    /// Generates a unique asymmetric data key pair. The <code>GenerateDataKeyPairWithoutPlaintext</code>
    /// operation returns a plaintext public key and a copy of the private key that is encrypted
    /// under the symmetric CMK you specify. Unlike <a>GenerateDataKeyPair</a>, this operation
    /// does not return a plaintext private key. 
    /// 
    ///  
    /// <para>
    /// To generate a data key pair, you must specify a symmetric customer master key (CMK)
    /// to encrypt the private key in the data key pair. You cannot use an asymmetric CMK
    /// or a CMK in a custom key store. To get the type and origin of your CMK, use the <code>KeySpec</code>
    /// field in the <a>DescribeKey</a> response.
    /// </para><para>
    /// You can use the public key that <code>GenerateDataKeyPairWithoutPlaintext</code> returns
    /// to encrypt data or verify a signature outside of AWS KMS. Then, store the encrypted
    /// private key with the data. When you are ready to decrypt data or sign a message, you
    /// can use the <a>Decrypt</a> operation to decrypt the encrypted private key.
    /// </para><para><code>GenerateDataKeyPairWithoutPlaintext</code> returns a unique data key pair for
    /// each request. The bytes in the key are not related to the caller or CMK that is used
    /// to encrypt the private key.
    /// </para><para>
    /// You can use the optional encryption context to add additional security to the encryption
    /// operation. If you specify an <code>EncryptionContext</code>, you must specify the
    /// same encryption context (a case-sensitive exact match) when decrypting the encrypted
    /// data key. Otherwise, the request to decrypt fails with an <code>InvalidCiphertextException</code>.
    /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
    /// Context</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// state: Effect on your CMK</a> in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a CMK in a different
    /// AWS account, specify the key ARN or alias ARN in the value of the <code>KeyId</code>
    /// parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GenerateDataKeyPairWithoutPlaintext</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>Decrypt</a></para></li><li><para><a>Encrypt</a></para></li><li><para><a>GenerateDataKey</a></para></li><li><para><a>GenerateDataKeyPair</a></para></li><li><para><a>GenerateDataKeyWithoutPlaintext</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "KMSDataKeyPairWithoutPlaintext", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GenerateDataKeyPairWithoutPlaintext API operation.", Operation = new[] {"GenerateDataKeyPairWithoutPlaintext"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSDataKeyPairWithoutPlaintextCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptionContext
        /// <summary>
        /// <para>
        /// <para>Specifies the encryption context that will be used when encrypting the private key
        /// in the data key pair.</para><para>An <i>encryption context</i> is a collection of non-secret key-value pairs that represents
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
        /// <para>A list of grant tokens.</para><para>Use a grant token when your permission to call this operation comes from a new grant
        /// that has not yet achieved <i>eventual consistency</i>. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
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
        /// <para>Specifies the CMK that encrypts the private key in the data key pair. You must specify
        /// a symmetric CMK. You cannot use an asymmetric CMK or a CMK in a custom key store.
        /// To get the type and origin of your CMK, use the <a>DescribeKey</a> operation. </para><para>To specify a CMK, use its key ID, key ARN, alias name, or alias ARN. When using an
        /// alias name, prefix it with <code>"alias/"</code>. To specify a CMK in a different
        /// AWS account, you must use the key ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.
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
        /// <para>Determines the type of data key pair that is generated.</para><para>The AWS KMS rule that restricts the use of asymmetric RSA CMKs to encrypt and decrypt
        /// or to sign and verify (but not both), and the rule that permits you to use ECC CMKs
        /// only to sign and verify, are not effective outside of AWS KMS.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSDataKeyPairWithoutPlaintext (GenerateDataKeyPairWithoutPlaintext)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse, NewKMSDataKeyPairWithoutPlaintextCmdlet>(Select) ??
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
            context.KeyPairSpec = this.KeyPairSpec;
            #if MODULAR
            if (this.KeyPairSpec == null && ParameterWasBound(nameof(this.KeyPairSpec)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyPairSpec which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextRequest();
            
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
        
        private Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GenerateDataKeyPairWithoutPlaintext");
            try
            {
                #if DESKTOP
                return client.GenerateDataKeyPairWithoutPlaintext(request);
                #elif CORECLR
                return client.GenerateDataKeyPairWithoutPlaintextAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KeyManagementService.DataKeyPairSpec KeyPairSpec { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GenerateDataKeyPairWithoutPlaintextResponse, NewKMSDataKeyPairWithoutPlaintextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
