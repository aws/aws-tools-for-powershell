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
    /// Imports key material into an existing symmetric encryption KMS key that was created
    /// without key material. After you successfully import key material into a KMS key, you
    /// can <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html#reimport-key-material">reimport
    /// the same key material</a> into that KMS key, but you cannot import different key material.
    /// 
    /// 
    ///  
    /// <para>
    /// You cannot perform this operation on an asymmetric KMS key, an HMAC KMS key, or on
    /// any KMS key in a different Amazon Web Services account. For more information about
    /// creating KMS keys with no key material and then importing key material, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// Key Material</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// Before using this operation, call <a>GetParametersForImport</a>. Its response includes
    /// a public key and an import token. Use the public key to encrypt the key material.
    /// Then, submit the import token from the same <code>GetParametersForImport</code> response.
    /// </para><para>
    /// When calling this operation, you must specify the following values:
    /// </para><ul><li><para>
    /// The key ID or key ARN of a KMS key with no key material. Its <code>Origin</code> must
    /// be <code>EXTERNAL</code>.
    /// </para><para>
    /// To create a KMS key with no key material, call <a>CreateKey</a> and set the value
    /// of its <code>Origin</code> parameter to <code>EXTERNAL</code>. To get the <code>Origin</code>
    /// of a KMS key, call <a>DescribeKey</a>.)
    /// </para></li><li><para>
    /// The encrypted key material. To get the public key to encrypt the key material, call
    /// <a>GetParametersForImport</a>.
    /// </para></li><li><para>
    /// The import token that <a>GetParametersForImport</a> returned. You must use a public
    /// key and token from the same <code>GetParametersForImport</code> response.
    /// </para></li><li><para>
    /// Whether the key material expires (<code>ExpirationModel</code>) and, if so, when (<code>ValidTo</code>).
    /// If you set an expiration date, on the specified date, KMS deletes the key material
    /// from the KMS key, making the KMS key unusable. To use the KMS key in cryptographic
    /// operations again, you must reimport the same key material. The only way to change
    /// the expiration model or expiration date is by reimporting the same key material and
    /// specifying a new expiration date. 
    /// </para></li></ul><para>
    /// When this operation is successful, the key state of the KMS key changes from <code>PendingImport</code>
    /// to <code>Enabled</code>, and you can use the KMS key.
    /// </para><para>
    /// If this operation fails, use the exception to help determine the problem. If the error
    /// is related to the key material, the import token, or wrapping key, use <a>GetParametersForImport</a>
    /// to get a new public key and import token for the KMS key and repeat the import procedure.
    /// For help, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html#importing-keys-overview">How
    /// To Import Key Material</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:ImportKeyMaterial</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DeleteImportedKeyMaterial</a></para></li><li><para><a>GetParametersForImport</a></para></li></ul>
    /// </summary>
    [Cmdlet("Import", "KMSKeyMaterial", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service ImportKeyMaterial API operation.", Operation = new[] {"ImportKeyMaterial"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ImportKeyMaterialResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.ImportKeyMaterialResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.ImportKeyMaterialResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportKMSKeyMaterialCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter EncryptedKeyMaterial
        /// <summary>
        /// <para>
        /// <para>The encrypted key material to import. The key material must be encrypted with the
        /// public wrapping key that <a>GetParametersForImport</a> returned, using the wrapping
        /// algorithm that you specified in the same <code>GetParametersForImport</code> request.</para>
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
        public byte[] EncryptedKeyMaterial { get; set; }
        #endregion
        
        #region Parameter ExpirationModel
        /// <summary>
        /// <para>
        /// <para>Specifies whether the key material expires. The default is <code>KEY_MATERIAL_EXPIRES</code>.</para><para>When the value of <code>ExpirationModel</code> is <code>KEY_MATERIAL_EXPIRES</code>,
        /// you must specify a value for the <code>ValidTo</code> parameter. When value is <code>KEY_MATERIAL_DOES_NOT_EXPIRE</code>,
        /// you must omit the <code>ValidTo</code> parameter.</para><para>You cannot change the <code>ExpirationModel</code> or <code>ValidTo</code> values
        /// for the current import after the request completes. To change either value, you must
        /// delete (<a>DeleteImportedKeyMaterial</a>) and reimport the key material.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.ExpirationModelType")]
        public Amazon.KeyManagementService.ExpirationModelType ExpirationModel { get; set; }
        #endregion
        
        #region Parameter ImportToken
        /// <summary>
        /// <para>
        /// <para>The import token that you received in the response to a previous <a>GetParametersForImport</a>
        /// request. It must be from the same response that contained the public key that you
        /// used to encrypt the key material.</para>
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
        public byte[] ImportToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the symmetric encryption KMS key that receives the imported key
        /// material. This must be the same KMS key specified in the <code>KeyID</code> parameter
        /// of the corresponding <a>GetParametersForImport</a> request. The <code>Origin</code>
        /// of the KMS key must be <code>EXTERNAL</code>. You cannot perform this operation on
        /// an asymmetric KMS key, an HMAC KMS key, a KMS key in a custom key store, or on a KMS
        /// key in a different Amazon Web Services account</para><para>Specify the key ID or key ARN of the KMS key.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        
        #region Parameter ValidTo
        /// <summary>
        /// <para>
        /// <para>The date and time when the imported key material expires. This parameter is required
        /// when the value of the <code>ExpirationModel</code> parameter is <code>KEY_MATERIAL_EXPIRES</code>.
        /// Otherwise it is not valid.</para><para>The value of this parameter must be a future date and time. The maximum value is 365
        /// days from the request date.</para><para>When the key material expires, KMS deletes the key material from the KMS key. Without
        /// its key material, the KMS key is unusable. To use the KMS key in cryptographic operations,
        /// you must reimport the same key material.</para><para>You cannot change the <code>ExpirationModel</code> or <code>ValidTo</code> values
        /// for the current import after the request completes. To change either value, you must
        /// delete (<a>DeleteImportedKeyMaterial</a>) and reimport the key material.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ValidTo { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.ImportKeyMaterialResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-KMSKeyMaterial (ImportKeyMaterial)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.ImportKeyMaterialResponse, ImportKMSKeyMaterialCmdlet>(Select) ??
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
            context.EncryptedKeyMaterial = this.EncryptedKeyMaterial;
            #if MODULAR
            if (this.EncryptedKeyMaterial == null && ParameterWasBound(nameof(this.EncryptedKeyMaterial)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptedKeyMaterial which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpirationModel = this.ExpirationModel;
            context.ImportToken = this.ImportToken;
            #if MODULAR
            if (this.ImportToken == null && ParameterWasBound(nameof(this.ImportToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidTo = this.ValidTo;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _EncryptedKeyMaterialStream = null;
            System.IO.MemoryStream _ImportTokenStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.KeyManagementService.Model.ImportKeyMaterialRequest();
                
                if (cmdletContext.EncryptedKeyMaterial != null)
                {
                    _EncryptedKeyMaterialStream = new System.IO.MemoryStream(cmdletContext.EncryptedKeyMaterial);
                    request.EncryptedKeyMaterial = _EncryptedKeyMaterialStream;
                }
                if (cmdletContext.ExpirationModel != null)
                {
                    request.ExpirationModel = cmdletContext.ExpirationModel;
                }
                if (cmdletContext.ImportToken != null)
                {
                    _ImportTokenStream = new System.IO.MemoryStream(cmdletContext.ImportToken);
                    request.ImportToken = _ImportTokenStream;
                }
                if (cmdletContext.KeyId != null)
                {
                    request.KeyId = cmdletContext.KeyId;
                }
                if (cmdletContext.ValidTo != null)
                {
                    request.ValidTo = cmdletContext.ValidTo.Value;
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
                if( _EncryptedKeyMaterialStream != null)
                {
                    _EncryptedKeyMaterialStream.Dispose();
                }
                if( _ImportTokenStream != null)
                {
                    _ImportTokenStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KeyManagementService.Model.ImportKeyMaterialResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.ImportKeyMaterialRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "ImportKeyMaterial");
            try
            {
                #if DESKTOP
                return client.ImportKeyMaterial(request);
                #elif CORECLR
                return client.ImportKeyMaterialAsync(request).GetAwaiter().GetResult();
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
            public byte[] EncryptedKeyMaterial { get; set; }
            public Amazon.KeyManagementService.ExpirationModelType ExpirationModel { get; set; }
            public byte[] ImportToken { get; set; }
            public System.String KeyId { get; set; }
            public System.DateTime? ValidTo { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ImportKeyMaterialResponse, ImportKMSKeyMaterialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
