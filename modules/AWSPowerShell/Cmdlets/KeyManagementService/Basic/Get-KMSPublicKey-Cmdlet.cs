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
using System.Threading;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Returns the public key of an asymmetric KMS key. Unlike the private key of a asymmetric
    /// KMS key, which never leaves KMS unencrypted, callers with <c>kms:GetPublicKey</c>
    /// permission can download the public key of an asymmetric KMS key. You can share the
    /// public key to allow others to encrypt messages and verify signatures outside of KMS.
    /// For information about asymmetric KMS keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Asymmetric
    /// KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// 
    ///  
    /// <para>
    /// You do not need to download the public key. Instead, you can use the public key within
    /// KMS by calling the <a>Encrypt</a>, <a>ReEncrypt</a>, or <a>Verify</a> operations with
    /// the identifier of an asymmetric KMS key. When you use the public key within KMS, you
    /// benefit from the authentication, authorization, and logging that are part of every
    /// KMS operation. You also reduce of risk of encrypting data that cannot be decrypted.
    /// These features are not effective outside of KMS.
    /// </para><para>
    /// To help you use the public key safely outside of KMS, <c>GetPublicKey</c> returns
    /// important information about the public key in the response, including:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_GetPublicKey.html#KMS-GetPublicKey-response-KeySpec">KeySpec</a>:
    /// The type of key material in the public key, such as <c>RSA_4096</c> or <c>ECC_NIST_P521</c>.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_GetPublicKey.html#KMS-GetPublicKey-response-KeyUsage">KeyUsage</a>:
    /// Whether the key is used for encryption, signing, or deriving a shared secret.
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_GetPublicKey.html#KMS-GetPublicKey-response-EncryptionAlgorithms">EncryptionAlgorithms</a>
    /// or <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_GetPublicKey.html#KMS-GetPublicKey-response-SigningAlgorithms">SigningAlgorithms</a>:
    /// A list of the encryption algorithms or the signing algorithms for the key.
    /// </para></li></ul><para>
    /// Although KMS cannot enforce these restrictions on external operations, it is crucial
    /// that you use this information to prevent the public key from being used improperly.
    /// For example, you can prevent a public signing key from being used encrypt data, or
    /// prevent a public key from being used with an encryption algorithm that is not supported
    /// by KMS. You can also avoid errors, such as using the wrong signing algorithm in a
    /// verification operation.
    /// </para><para>
    /// To verify a signature outside of KMS with an SM2 public key (China Regions only),
    /// you must specify the distinguishing ID. By default, KMS uses <c>1234567812345678</c>
    /// as the distinguishing ID. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/asymmetric-key-specs.html#key-spec-sm-offline-verification">Offline
    /// verification with SM2 key pairs</a>.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: Yes. To perform this operation with a KMS key in a different
    /// Amazon Web Services account, specify the key ARN or alias ARN in the value of the
    /// <c>KeyId</c> parameter.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GetPublicKey</a>
    /// (key policy)
    /// </para><para><b>Related operations</b>: <a>CreateKey</a></para><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSPublicKey")]
    [OutputType("Amazon.KeyManagementService.Model.GetPublicKeyResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GetPublicKey API operation.", Operation = new[] {"GetPublicKey"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GetPublicKeyResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GetPublicKeyResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GetPublicKeyResponse object containing multiple properties."
    )]
    public partial class GetKMSPublicKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>Identifies the asymmetric KMS key that includes the public key.</para><para>To specify a KMS key, use its key ID, key ARN, alias name, or alias ARN. When using
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GetPublicKeyResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GetPublicKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GetPublicKeyResponse, GetKMSPublicKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.KeyManagementService.Model.GetPublicKeyRequest();
            
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.GetPublicKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GetPublicKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GetPublicKey");
            try
            {
                return client.GetPublicKeyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> GrantToken { get; set; }
            public System.String KeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GetPublicKeyResponse, GetKMSPublicKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
