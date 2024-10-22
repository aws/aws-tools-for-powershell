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
    /// Creates a <a href="https://en.wikipedia.org/wiki/Digital_signature">digital signature</a>
    /// for a message or message digest by using the private key in an asymmetric signing
    /// KMS key. To verify the signature, use the <a>Verify</a> operation, or use the public
    /// key in the same asymmetric KMS key outside of KMS. For information about asymmetric
    /// KMS keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Asymmetric
    /// KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// Digital signatures are generated and verified by using asymmetric key pair, such as
    /// an RSA or ECC pair that is represented by an asymmetric KMS key. The key owner (or
    /// an authorized user) uses their private key to sign a message. Anyone with the public
    /// key can verify that the message was signed with that particular private key and that
    /// the message hasn't changed since it was signed. 
    /// </para><para>
    /// To use the <c>Sign</c> operation, provide the following information:
    /// </para><ul><li><para>
    /// Use the <c>KeyId</c> parameter to identify an asymmetric KMS key with a <c>KeyUsage</c>
    /// value of <c>SIGN_VERIFY</c>. To get the <c>KeyUsage</c> value of a KMS key, use the
    /// <a>DescribeKey</a> operation. The caller must have <c>kms:Sign</c> permission on the
    /// KMS key.
    /// </para></li><li><para>
    /// Use the <c>Message</c> parameter to specify the message or message digest to sign.
    /// You can submit messages of up to 4096 bytes. To sign a larger message, generate a
    /// hash digest of the message, and then provide the hash digest in the <c>Message</c>
    /// parameter. To indicate whether the message is a full message or a digest, use the
    /// <c>MessageType</c> parameter.
    /// </para></li><li><para>
    /// Choose a signing algorithm that is compatible with the KMS key. 
    /// </para></li></ul><important><para>
    /// When signing a message, be sure to record the KMS key and the signing algorithm. This
    /// information is required to verify the signature.
    /// </para></important><note><para>
    /// Best practices recommend that you limit the time during which any signature is effective.
    /// This deters an attack where the actor uses a signed message to establish validity
    /// repeatedly or long after the message is superseded. Signatures do not include a timestamp,
    /// but you can include a timestamp in the signed message to help you detect when its
    /// time to refresh the signature. 
    /// </para></note><para>
    /// To verify the signature that this operation generates, use the <a>Verify</a> operation.
    /// Or use the <a>GetPublicKey</a> operation to download the public key and then use the
    /// public key to verify the signature outside of KMS. 
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <c>KeyId</c> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:Sign</a>
    /// (key policy)
    /// </para><para><b>Related operations</b>: <a>Verify</a></para><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "KMSSigning", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the AWS Key Management Service Sign API operation.", Operation = new[] {"Sign"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.SignResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.KeyManagementService.Model.SignResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.KeyManagementService.Model.SignResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeKMSSigningCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
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
        /// <para>Identifies an asymmetric KMS key. KMS uses the private key in the asymmetric KMS key
        /// to sign the message. The <c>KeyUsage</c> type of the KMS key must be <c>SIGN_VERIFY</c>.
        /// To find the <c>KeyUsage</c> of a KMS key, use the <a>DescribeKey</a> operation.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
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
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>Specifies the message or message digest to sign. Messages can be 0-4096 bytes. To
        /// sign a larger message, provide a message digest.</para><para>If you provide a message digest, use the <c>DIGEST</c> value of <c>MessageType</c>
        /// to prevent the digest from being hashed again while signing.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Message { get; set; }
        #endregion
        
        #region Parameter MessageType
        /// <summary>
        /// <para>
        /// <para>Tells KMS whether the value of the <c>Message</c> parameter should be hashed as part
        /// of the signing algorithm. Use <c>RAW</c> for unhashed messages; use <c>DIGEST</c>
        /// for message digests, which are already hashed.</para><para>When the value of <c>MessageType</c> is <c>RAW</c>, KMS uses the standard signing
        /// algorithm, which begins with a hash function. When the value is <c>DIGEST</c>, KMS
        /// skips the hashing step in the signing algorithm.</para><important><para>Use the <c>DIGEST</c> value only when the value of the <c>Message</c> parameter is
        /// a message digest. If you use the <c>DIGEST</c> value with an unhashed message, the
        /// security of the signing operation can be compromised.</para></important><para>When the value of <c>MessageType</c>is <c>DIGEST</c>, the length of the <c>Message</c>
        /// value must match the length of hashed messages for the specified signing algorithm.</para><para>You can submit a message digest and omit the <c>MessageType</c> or specify <c>RAW</c>
        /// so the digest is hashed again while signing. However, this can cause verification
        /// failures when verifying with a system that assumes a single hash.</para><para>The hashing algorithm in that <c>Sign</c> uses is based on the <c>SigningAlgorithm</c>
        /// value.</para><ul><li><para>Signing algorithms that end in SHA_256 use the SHA_256 hashing algorithm.</para></li><li><para>Signing algorithms that end in SHA_384 use the SHA_384 hashing algorithm.</para></li><li><para>Signing algorithms that end in SHA_512 use the SHA_512 hashing algorithm.</para></li><li><para>SM2DSA uses the SM3 hashing algorithm. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/asymmetric-key-specs.html#key-spec-sm-offline-verification">Offline
        /// verification with SM2 key pairs</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.MessageType")]
        public Amazon.KeyManagementService.MessageType MessageType { get; set; }
        #endregion
        
        #region Parameter SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the signing algorithm to use when signing the message. </para><para>Choose an algorithm that is compatible with the type and size of the specified asymmetric
        /// KMS key. When signing with RSA key pairs, RSASSA-PSS algorithms are preferred. We
        /// include RSASSA-PKCS1-v1_5 algorithms for compatibility with existing applications.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.SigningAlgorithmSpec")]
        public Amazon.KeyManagementService.SigningAlgorithmSpec SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Signature'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.SignResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.SignResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Signature";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-KMSSigning (Sign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.SignResponse, InvokeKMSSigningCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
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
            context.Message = this.Message;
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageType = this.MessageType;
            context.SigningAlgorithm = this.SigningAlgorithm;
            #if MODULAR
            if (this.SigningAlgorithm == null && ParameterWasBound(nameof(this.SigningAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _MessageStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.SignRequest();
                
                if (cmdletContext.DryRun != null)
                {
                    request.DryRun = cmdletContext.DryRun.Value;
                }
                if (cmdletContext.GrantToken != null)
                {
                    request.GrantTokens = cmdletContext.GrantToken;
                }
                if (cmdletContext.KeyId != null)
                {
                    request.KeyId = cmdletContext.KeyId;
                }
                if (cmdletContext.Message != null)
                {
                    _MessageStream = new System.IO.MemoryStream(cmdletContext.Message);
                    request.Message = _MessageStream;
                }
                if (cmdletContext.MessageType != null)
                {
                    request.MessageType = cmdletContext.MessageType;
                }
                if (cmdletContext.SigningAlgorithm != null)
                {
                    request.SigningAlgorithm = cmdletContext.SigningAlgorithm;
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
                if( _MessageStream != null)
                {
                    _MessageStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.SignResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.SignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "Sign");
            try
            {
                #if DESKTOP
                return client.Sign(request);
                #elif CORECLR
                return client.SignAsync(request).GetAwaiter().GetResult();
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
            public System.String KeyId { get; set; }
            public byte[] Message { get; set; }
            public Amazon.KeyManagementService.MessageType MessageType { get; set; }
            public Amazon.KeyManagementService.SigningAlgorithmSpec SigningAlgorithm { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.SignResponse, InvokeKMSSigningCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Signature;
        }
        
    }
}
