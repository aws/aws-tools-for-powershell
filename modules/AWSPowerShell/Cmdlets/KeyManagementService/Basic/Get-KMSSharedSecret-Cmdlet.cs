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
    /// Derives a shared secret using a key agreement algorithm.
    /// 
    ///  <note><para>
    /// You must use an asymmetric NIST-recommended elliptic curve (ECC) or SM2 (China Regions
    /// only) KMS key pair with a <c>KeyUsage</c> value of <c>KEY_AGREEMENT</c> to call DeriveSharedSecret.
    /// </para></note><para>
    /// DeriveSharedSecret uses the <a href="https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-56Ar3.pdf#page=60">Elliptic
    /// Curve Cryptography Cofactor Diffie-Hellman Primitive</a> (ECDH) to establish a key
    /// agreement between two peers by deriving a shared secret from their elliptic curve
    /// public-private key pairs. You can use the raw shared secret that DeriveSharedSecret
    /// returns to derive a symmetric key that can encrypt and decrypt data that is sent between
    /// the two peers, or that can generate and verify HMACs. KMS recommends that you follow
    /// <a href="https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-56Cr2.pdf">NIST
    /// recommendations for key derivation</a> when using the raw shared secret to derive
    /// a symmetric key.
    /// </para><para>
    /// The following workflow demonstrates how to establish key agreement over an insecure
    /// communication channel using DeriveSharedSecret.
    /// </para><ol><li><para><b>Alice</b> calls <a>CreateKey</a> to create an asymmetric KMS key pair with a <c>KeyUsage</c>
    /// value of <c>KEY_AGREEMENT</c>.
    /// </para><para>
    /// The asymmetric KMS key must use a NIST-recommended elliptic curve (ECC) or SM2 (China
    /// Regions only) key spec.
    /// </para></li><li><para><b>Bob</b> creates an elliptic curve key pair.
    /// </para><para>
    /// Bob can call <a>CreateKey</a> to create an asymmetric KMS key pair or generate a key
    /// pair outside of KMS. Bob's key pair must use the same NIST-recommended elliptic curve
    /// (ECC) or SM2 (China Regions ony) curve as Alice.
    /// </para></li><li><para>
    /// Alice and Bob <b>exchange their public keys</b> through an insecure communication
    /// channel (like the internet).
    /// </para><para>
    /// Use <a>GetPublicKey</a> to download the public key of your asymmetric KMS key pair.
    /// </para><note><para>
    /// KMS strongly recommends verifying that the public key you receive came from the expected
    /// party before using it to derive a shared secret.
    /// </para></note></li><li><para><b>Alice</b> calls DeriveSharedSecret.
    /// </para><para>
    /// KMS uses the private key from the KMS key pair generated in <b>Step 1</b>, Bob's public
    /// key, and the Elliptic Curve Cryptography Cofactor Diffie-Hellman Primitive to derive
    /// the shared secret. The private key in your KMS key pair never leaves KMS unencrypted.
    /// DeriveSharedSecret returns the raw shared secret.
    /// </para></li><li><para><b>Bob</b> uses the Elliptic Curve Cryptography Cofactor Diffie-Hellman Primitive
    /// to calculate the same raw secret using his private key and Alice's public key.
    /// </para></li></ol><para>
    /// To derive a shared secret you must provide a key agreement algorithm, the private
    /// key of the caller's asymmetric NIST-recommended elliptic curve or SM2 (China Regions
    /// only) KMS key pair, and the public key from your peer's NIST-recommended elliptic
    /// curve or SM2 (China Regions only) key pair. The public key can be from another asymmetric
    /// KMS key pair or from a key pair generated outside of KMS, but both key pairs must
    /// be on the same elliptic curve.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <c>KeyId</c> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:DeriveSharedSecret</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>CreateKey</a></para></li><li><para><a>GetPublicKey</a></para></li><li><para><a>DescribeKey</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSSharedSecret")]
    [OutputType("Amazon.KeyManagementService.Model.DeriveSharedSecretResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service DeriveSharedSecret API operation.", Operation = new[] {"DeriveSharedSecret"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.DeriveSharedSecretResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.DeriveSharedSecretResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.DeriveSharedSecretResponse object containing multiple properties."
    )]
    public partial class GetKMSSharedSecretCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
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
        
        #region Parameter KeyAgreementAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the key agreement algorithm used to derive the shared secret. The only valid
        /// value is <c>ECDH</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyAgreementAlgorithmSpec")]
        public Amazon.KeyManagementService.KeyAgreementAlgorithmSpec KeyAgreementAlgorithm { get; set; }
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
        /// <para>Identifies an asymmetric NIST-recommended ECC or SM2 (China Regions only) KMS key.
        /// KMS uses the private key in the specified key pair to derive the shared secret. The
        /// key usage of the KMS key must be <c>KEY_AGREEMENT</c>. To find the <c>KeyUsage</c>
        /// of a KMS key, use the <a>DescribeKey</a> operation.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
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
        
        #region Parameter PublicKey
        /// <summary>
        /// <para>
        /// <para>Specifies the public key in your peer's NIST-recommended elliptic curve (ECC) or SM2
        /// (China Regions only) key pair.</para><para>The public key must be a DER-encoded X.509 public key, also known as <c>SubjectPublicKeyInfo</c>
        /// (SPKI), as defined in <a href="https://tools.ietf.org/html/rfc5280">RFC 5280</a>.</para><para><a>GetPublicKey</a> returns the public key of an asymmetric KMS key pair in the required
        /// DER-encoded format.</para><note><para>If you use <a href="https://docs.aws.amazon.com/cli/v1/userguide/cli-chap-welcome.html">Amazon
        /// Web Services CLI version 1</a>, you must provide the DER-encoded X.509 public key
        /// in a file. Otherwise, the Amazon Web Services CLI Base64-encodes the public key a
        /// second time, resulting in a <c>ValidationException</c>.</para></note><para>You can specify the public key as binary data in a file using fileb (<c>fileb://&lt;path-to-file&gt;</c>)
        /// or in-line using a Base64 encoded string.</para>
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
        public byte[] PublicKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.DeriveSharedSecretResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.DeriveSharedSecretResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.DeriveSharedSecretResponse, GetKMSSharedSecretCmdlet>(Select) ??
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
            if (this.GrantToken != null)
            {
                context.GrantToken = new List<System.String>(this.GrantToken);
            }
            context.KeyAgreementAlgorithm = this.KeyAgreementAlgorithm;
            #if MODULAR
            if (this.KeyAgreementAlgorithm == null && ParameterWasBound(nameof(this.KeyAgreementAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyAgreementAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicKey = this.PublicKey;
            #if MODULAR
            if (this.PublicKey == null && ParameterWasBound(nameof(this.PublicKey)))
            {
                WriteWarning("You are passing $null as a value for parameter PublicKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _PublicKeyStream = null;
            System.IO.MemoryStream _Recipient_AttestationDocumentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.DeriveSharedSecretRequest();
                
                if (cmdletContext.DryRun != null)
                {
                    request.DryRun = cmdletContext.DryRun.Value;
                }
                if (cmdletContext.GrantToken != null)
                {
                    request.GrantTokens = cmdletContext.GrantToken;
                }
                if (cmdletContext.KeyAgreementAlgorithm != null)
                {
                    request.KeyAgreementAlgorithm = cmdletContext.KeyAgreementAlgorithm;
                }
                if (cmdletContext.KeyId != null)
                {
                    request.KeyId = cmdletContext.KeyId;
                }
                if (cmdletContext.PublicKey != null)
                {
                    _PublicKeyStream = new System.IO.MemoryStream(cmdletContext.PublicKey);
                    request.PublicKey = _PublicKeyStream;
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
                if( _PublicKeyStream != null)
                {
                    _PublicKeyStream.Dispose();
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
        
        private Amazon.KeyManagementService.Model.DeriveSharedSecretResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.DeriveSharedSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "DeriveSharedSecret");
            try
            {
                #if DESKTOP
                return client.DeriveSharedSecret(request);
                #elif CORECLR
                return client.DeriveSharedSecretAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> GrantToken { get; set; }
            public Amazon.KeyManagementService.KeyAgreementAlgorithmSpec KeyAgreementAlgorithm { get; set; }
            public System.String KeyId { get; set; }
            public byte[] PublicKey { get; set; }
            public byte[] Recipient_AttestationDocument { get; set; }
            public Amazon.KeyManagementService.KeyEncryptionMechanism Recipient_KeyEncryptionAlgorithm { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.DeriveSharedSecretResponse, GetKMSSharedSecretCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
