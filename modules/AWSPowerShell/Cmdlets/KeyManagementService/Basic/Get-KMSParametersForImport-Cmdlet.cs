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
    /// Returns the public key and an import token you need to import or reimport key material
    /// for a KMS key. 
    /// 
    ///  
    /// <para>
    /// By default, KMS keys are created with key material that KMS generates. This operation
    /// supports <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// key material</a>, an advanced feature that lets you generate and import the cryptographic
    /// key material for a KMS key. For more information about importing key material into
    /// KMS, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// key material</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// Before calling <c>GetParametersForImport</c>, use the <a>CreateKey</a> operation with
    /// an <c>Origin</c> value of <c>EXTERNAL</c> to create a KMS key with no key material.
    /// You can import key material for a symmetric encryption KMS key, HMAC KMS key, asymmetric
    /// encryption KMS key, or asymmetric signing KMS key. You can also import key material
    /// into a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">multi-Region
    /// key</a> of any supported type. However, you can't import key material into a KMS key
    /// in a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key store</a>. You can also use <c>GetParametersForImport</c> to get a public key
    /// and import token to <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html#reimport-key-material">reimport
    /// the original key material</a> into a KMS key whose key material expired or was deleted.
    /// </para><para><c>GetParametersForImport</c> returns the items that you need to import your key
    /// material.
    /// </para><ul><li><para>
    /// The public key (or "wrapping key") of an RSA key pair that KMS generates.
    /// </para><para>
    /// You will use this public key to encrypt ("wrap") your key material while it's in transit
    /// to KMS. 
    /// </para></li><li><para>
    /// A import token that ensures that KMS can decrypt your key material and associate it
    /// with the correct KMS key.
    /// </para></li></ul><para>
    /// The public key and its import token are permanently linked and must be used together.
    /// Each public key and import token set is valid for 24 hours. The expiration date and
    /// time appear in the <c>ParametersValidTo</c> field in the <c>GetParametersForImport</c>
    /// response. You cannot use an expired public key or import token in an <a>ImportKeyMaterial</a>
    /// request. If your key and token expire, send another <c>GetParametersForImport</c>
    /// request.
    /// </para><para><c>GetParametersForImport</c> requires the following information:
    /// </para><ul><li><para>
    /// The key ID of the KMS key for which you are importing the key material.
    /// </para></li><li><para>
    /// The key spec of the public key ("wrapping key") that you will use to encrypt your
    /// key material during import.
    /// </para></li><li><para>
    /// The wrapping algorithm that you will use with the public key to encrypt your key material.
    /// </para></li></ul><para>
    /// You can use the same or a different public key spec and wrapping algorithm each time
    /// you import or reimport the same key material. 
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:GetParametersForImport</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>ImportKeyMaterial</a></para></li><li><para><a>DeleteImportedKeyMaterial</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KMSParametersForImport")]
    [OutputType("Amazon.KeyManagementService.Model.GetParametersForImportResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service GetParametersForImport API operation.", Operation = new[] {"GetParametersForImport"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.GetParametersForImportResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.GetParametersForImportResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.GetParametersForImportResponse object containing multiple properties."
    )]
    public partial class GetKMSParametersForImportCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key that will be associated with the imported key material.
        /// The <c>Origin</c> of the KMS key must be <c>EXTERNAL</c>.</para><para>All KMS key types are supported, including multi-Region keys. However, you cannot
        /// import key material into a KMS key in a custom key store.</para><para>Specify the key ID or key ARN of the KMS key.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        
        #region Parameter WrappingAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm you will use with the RSA public key (<c>PublicKey</c>) in the response
        /// to protect your key material during import. For more information, see <a href="kms/latest/developerguide/importing-keys-get-public-key-and-token.html#select-wrapping-algorithm">Select
        /// a wrapping algorithm</a> in the <i>Key Management Service Developer Guide</i>.</para><para>For RSA_AES wrapping algorithms, you encrypt your key material with an AES key that
        /// you generate, then encrypt your AES key with the RSA public key from KMS. For RSAES
        /// wrapping algorithms, you encrypt your key material directly with the RSA public key
        /// from KMS.</para><para>The wrapping algorithms that you can use depend on the type of key material that you
        /// are importing. To import an RSA private key, you must use an RSA_AES wrapping algorithm.</para><ul><li><para><b>RSA_AES_KEY_WRAP_SHA_256</b> — Supported for wrapping RSA and ECC key material.</para></li><li><para><b>RSA_AES_KEY_WRAP_SHA_1</b> — Supported for wrapping RSA and ECC key material.</para></li><li><para><b>RSAES_OAEP_SHA_256</b> — Supported for all types of key material, except RSA key
        /// material (private key).</para><para>You cannot use the RSAES_OAEP_SHA_256 wrapping algorithm with the RSA_2048 wrapping
        /// key spec to wrap ECC_NIST_P521 key material.</para></li><li><para><b>RSAES_OAEP_SHA_1</b> — Supported for all types of key material, except RSA key
        /// material (private key).</para><para>You cannot use the RSAES_OAEP_SHA_1 wrapping algorithm with the RSA_2048 wrapping
        /// key spec to wrap ECC_NIST_P521 key material.</para></li><li><para><b>RSAES_PKCS1_V1_5</b> (Deprecated) — As of October 10, 2023, KMS does not support
        /// the RSAES_PKCS1_V1_5 wrapping algorithm.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.AlgorithmSpec")]
        public Amazon.KeyManagementService.AlgorithmSpec WrappingAlgorithm { get; set; }
        #endregion
        
        #region Parameter WrappingKeySpec
        /// <summary>
        /// <para>
        /// <para>The type of RSA public key to return in the response. You will use this wrapping key
        /// with the specified wrapping algorithm to protect your key material during import.
        /// </para><para>Use the longest RSA wrapping key that is practical. </para><para>You cannot use an RSA_2048 public key to directly wrap an ECC_NIST_P521 private key.
        /// Instead, use an RSA_AES wrapping algorithm or choose a longer RSA public key.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KeyManagementService.WrappingKeySpec")]
        public Amazon.KeyManagementService.WrappingKeySpec WrappingKeySpec { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.GetParametersForImportResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.GetParametersForImportResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.GetParametersForImportResponse, GetKMSParametersForImportCmdlet>(Select) ??
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
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WrappingAlgorithm = this.WrappingAlgorithm;
            #if MODULAR
            if (this.WrappingAlgorithm == null && ParameterWasBound(nameof(this.WrappingAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter WrappingAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WrappingKeySpec = this.WrappingKeySpec;
            #if MODULAR
            if (this.WrappingKeySpec == null && ParameterWasBound(nameof(this.WrappingKeySpec)))
            {
                WriteWarning("You are passing $null as a value for parameter WrappingKeySpec which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.GetParametersForImportRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.WrappingAlgorithm != null)
            {
                request.WrappingAlgorithm = cmdletContext.WrappingAlgorithm;
            }
            if (cmdletContext.WrappingKeySpec != null)
            {
                request.WrappingKeySpec = cmdletContext.WrappingKeySpec;
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
        
        private Amazon.KeyManagementService.Model.GetParametersForImportResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.GetParametersForImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "GetParametersForImport");
            try
            {
                #if DESKTOP
                return client.GetParametersForImport(request);
                #elif CORECLR
                return client.GetParametersForImportAsync(request).GetAwaiter().GetResult();
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
            public System.String KeyId { get; set; }
            public Amazon.KeyManagementService.AlgorithmSpec WrappingAlgorithm { get; set; }
            public Amazon.KeyManagementService.WrappingKeySpec WrappingKeySpec { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.GetParametersForImportResponse, GetKMSParametersForImportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
