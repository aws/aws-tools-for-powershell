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
    /// Imports or reimports key material into an existing KMS key that was created without
    /// key material. You can also use this operation to set or update the expiration model
    /// and expiration date of the imported key material.
    /// 
    ///  
    /// <para>
    /// By default, KMS creates KMS keys with key material that it generates. You can also
    /// generate and import your own key material. For more information about importing key
    /// material, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// key material</a>.
    /// </para><para>
    /// For asymmetric, HMAC and multi-Region keys, you cannot change the key material after
    /// the initial import. You can import multiple key materials into single-Region, symmetric
    /// encryption keys and rotate the key material on demand using <c>RotateKeyOnDemand</c>.
    /// </para><para>
    /// After you import key material, you can <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-import-key-material.html#reimport-key-material">reimport
    /// the same key material</a> into that KMS key or, if the key supports on-demand rotation,
    /// import new key material. You can use the <c>ImportType</c> parameter to indicate whether
    /// you are importing new key material or re-importing previously imported key material.
    /// You might reimport key material to replace key material that expired or key material
    /// that you deleted. You might also reimport key material to change the expiration model
    /// or expiration date of the key material.
    /// </para><para>
    /// Each time you import key material into KMS, you can determine whether (<c>ExpirationModel</c>)
    /// and when (<c>ValidTo</c>) the key material expires. To change the expiration of your
    /// key material, you must import it again, either by calling <c>ImportKeyMaterial</c>
    /// or using the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-import-key-material.html#importing-keys-import-key-material-console">import
    /// features</a> of the KMS console.
    /// </para><para>
    /// Before you call <c>ImportKeyMaterial</c>, complete these steps:
    /// </para><ul><li><para>
    /// Create or identify a KMS key with <c>EXTERNAL</c> origin, which indicates that the
    /// KMS key is designed for imported key material. 
    /// </para><para>
    /// To create a new KMS key for imported key material, call the <a>CreateKey</a> operation
    /// with an <c>Origin</c> value of <c>EXTERNAL</c>. You can create a symmetric encryption
    /// KMS key, HMAC KMS key, asymmetric encryption KMS key, asymmetric key agreement key,
    /// or asymmetric signing KMS key. You can also import key material into a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">multi-Region
    /// key</a> of any supported type. However, you can't import key material into a KMS key
    /// in a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key store</a>.
    /// </para></li><li><para>
    /// Call the <a>GetParametersForImport</a> operation to get a public key and import token
    /// set for importing key material. 
    /// </para></li><li><para>
    /// Use the public key in the <a>GetParametersForImport</a> response to encrypt your key
    /// material.
    /// </para></li></ul><para>
    ///  Then, in an <c>ImportKeyMaterial</c> request, you submit your encrypted key material
    /// and import token. When calling this operation, you must specify the following values:
    /// </para><ul><li><para>
    /// The key ID or key ARN of the KMS key to associate with the imported key material.
    /// Its <c>Origin</c> must be <c>EXTERNAL</c> and its <c>KeyState</c> must be <c>PendingImport</c>.
    /// You cannot perform this operation on a KMS key in a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key store</a>, or on a KMS key in a different Amazon Web Services account. To get
    /// the <c>Origin</c> and <c>KeyState</c> of a KMS key, call <a>DescribeKey</a>.
    /// </para></li><li><para>
    /// The encrypted key material. 
    /// </para></li><li><para>
    /// The import token that <a>GetParametersForImport</a> returned. You must use a public
    /// key and token from the same <c>GetParametersForImport</c> response.
    /// </para></li><li><para>
    /// Whether the key material expires (<c>ExpirationModel</c>) and, if so, when (<c>ValidTo</c>).
    /// For help with this choice, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-import-key-material.html#importing-keys-expiration">Setting
    /// an expiration time</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para>
    /// If you set an expiration date, KMS deletes the key material from the KMS key on the
    /// specified date, making the KMS key unusable. To use the KMS key in cryptographic operations
    /// again, you must reimport the same key material. However, you can delete and reimport
    /// the key material at any time, including before the key material expires. Each time
    /// you reimport, you can eliminate or reset the expiration time.
    /// </para></li></ul><para>
    /// When this operation is successful, the key state of the KMS key changes from <c>PendingImport</c>
    /// to <c>Enabled</c>, and you can use the KMS key in cryptographic operations. For single-Region,
    /// symmetric encryption keys, you will need to import all of the key materials associated
    /// with the KMS key to change its state to <c>Enabled</c>. Use the <c>ListKeyRotations</c>
    /// operation to list the ID and import state of each key material associated with a KMS
    /// key.
    /// </para><para>
    /// If this operation fails, use the exception to help determine the problem. If the error
    /// is related to the key material, the import token, or wrapping key, use <a>GetParametersForImport</a>
    /// to get a new public key and import token for the KMS key and repeat the import procedure.
    /// For help, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-conceptual.html">Create
    /// a KMS key with imported key material</a> in the <i>Key Management Service Developer
    /// Guide</i>.
    /// </para><para>
    /// The KMS key that you use for this operation must be in a compatible key state. For
    /// details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">Key
    /// states of KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a KMS key in a
    /// different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:ImportKeyMaterial</a>
    /// (key policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DeleteImportedKeyMaterial</a></para></li><li><para><a>GetParametersForImport</a></para></li><li><para><a>ListKeyRotations</a></para></li><li><para><a>RotateKeyOnDemand</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/accessing-kms.html#programming-eventual-consistency">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "KMSKeyMaterial", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.ImportKeyMaterialResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service ImportKeyMaterial API operation.", Operation = new[] {"ImportKeyMaterial"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.ImportKeyMaterialResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.ImportKeyMaterialResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.ImportKeyMaterialResponse object containing multiple properties."
    )]
    public partial class ImportKMSKeyMaterialCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptedKeyMaterial
        /// <summary>
        /// <para>
        /// <para>The encrypted key material to import. The key material must be encrypted under the
        /// public wrapping key that <a>GetParametersForImport</a> returned, using the wrapping
        /// algorithm that you specified in the same <c>GetParametersForImport</c> request.</para>
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
        /// <para>Specifies whether the key material expires. The default is <c>KEY_MATERIAL_EXPIRES</c>.
        /// For help with this choice, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-import-key-material.html#importing-keys-expiration">Setting
        /// an expiration time</a> in the <i>Key Management Service Developer Guide</i>.</para><para>When the value of <c>ExpirationModel</c> is <c>KEY_MATERIAL_EXPIRES</c>, you must
        /// specify a value for the <c>ValidTo</c> parameter. When value is <c>KEY_MATERIAL_DOES_NOT_EXPIRE</c>,
        /// you must omit the <c>ValidTo</c> parameter.</para><para>You cannot change the <c>ExpirationModel</c> or <c>ValidTo</c> values for the current
        /// import after the request completes. To change either value, you must reimport the
        /// key material.</para>
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
        
        #region Parameter ImportType
        /// <summary>
        /// <para>
        /// <para>Indicates whether the key material being imported is previously associated with this
        /// KMS key or not. This parameter is optional and only usable with symmetric encryption
        /// keys. If no key material has ever been imported into the KMS key, and this parameter
        /// is omitted, the parameter defaults to <c>NEW_KEY_MATERIAL</c>. After the first key
        /// material is imported, if this parameter is omitted then the parameter defaults to
        /// <c>EXISTING_KEY_MATERIAL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.ImportType")]
        public Amazon.KeyManagementService.ImportType ImportType { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key that will be associated with the imported key material.
        /// This must be the same KMS key specified in the <c>KeyID</c> parameter of the corresponding
        /// <a>GetParametersForImport</a> request. The <c>Origin</c> of the KMS key must be <c>EXTERNAL</c>
        /// and its <c>KeyState</c> must be <c>PendingImport</c>. </para><para>The KMS key can be a symmetric encryption KMS key, HMAC KMS key, asymmetric encryption
        /// KMS key, or asymmetric signing KMS key, including a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">multi-Region
        /// key</a> of any supported type. You cannot perform this operation on a KMS key in a
        /// custom key store, or on a KMS key in a different Amazon Web Services account.</para><para>Specify the key ID or key ARN of the KMS key.</para><para>For example:</para><ul><li><para>Key ID: <c>1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li><li><para>Key ARN: <c>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</c></para></li></ul><para>To get the key ID and key ARN for a KMS key, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
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
        
        #region Parameter KeyMaterialDescription
        /// <summary>
        /// <para>
        /// <para>Description for the key material being imported. This parameter is optional and only
        /// usable with symmetric encryption keys. If you do not specify a key material description,
        /// KMS retains the value you specified when you last imported the same key material into
        /// this KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyMaterialDescription { get; set; }
        #endregion
        
        #region Parameter KeyMaterialId
        /// <summary>
        /// <para>
        /// <para>Identifies the key material being imported. This parameter is optional and only usable
        /// with symmetric encryption keys. You cannot specify a key material ID with <c>ImportType</c>
        /// set to <c>NEW_KEY_MATERIAL</c>. Whenever you import key material into a symmetric
        /// encryption key, KMS assigns a unique identifier to the key material based on the KMS
        /// key ID and the imported key material. When you re-import key material with a specified
        /// key material ID, KMS:</para><ul><li><para>Computes the identifier for the key material</para></li><li><para>Matches the computed identifier against the specified key material ID</para></li><li><para>Verifies that the key material ID is already associated with the KMS key</para></li></ul><para>To get the list of key material IDs associated with a KMS key, use <a>ListKeyRotations</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyMaterialId { get; set; }
        #endregion
        
        #region Parameter ValidTo
        /// <summary>
        /// <para>
        /// <para>The date and time when the imported key material expires. This parameter is required
        /// when the value of the <c>ExpirationModel</c> parameter is <c>KEY_MATERIAL_EXPIRES</c>.
        /// Otherwise it is not valid.</para><para>The value of this parameter must be a future date and time. The maximum value is 365
        /// days from the request date.</para><para>When the key material expires, KMS deletes the key material from the KMS key. Without
        /// its key material, the KMS key is unusable. To use the KMS key in cryptographic operations,
        /// you must reimport the same key material.</para><para>You cannot change the <c>ExpirationModel</c> or <c>ValidTo</c> values for the current
        /// import after the request completes. To change either value, you must delete (<a>DeleteImportedKeyMaterial</a>)
        /// and reimport the key material.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ValidTo { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.ImportKeyMaterialResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.ImportKeyMaterialResponse will result in that property being returned.
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
            context.ImportType = this.ImportType;
            context.KeyId = this.KeyId;
            #if MODULAR
            if (this.KeyId == null && ParameterWasBound(nameof(this.KeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyMaterialDescription = this.KeyMaterialDescription;
            context.KeyMaterialId = this.KeyMaterialId;
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
                if (cmdletContext.ImportType != null)
                {
                    request.ImportType = cmdletContext.ImportType;
                }
                if (cmdletContext.KeyId != null)
                {
                    request.KeyId = cmdletContext.KeyId;
                }
                if (cmdletContext.KeyMaterialDescription != null)
                {
                    request.KeyMaterialDescription = cmdletContext.KeyMaterialDescription;
                }
                if (cmdletContext.KeyMaterialId != null)
                {
                    request.KeyMaterialId = cmdletContext.KeyMaterialId;
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
            public Amazon.KeyManagementService.ImportType ImportType { get; set; }
            public System.String KeyId { get; set; }
            public System.String KeyMaterialDescription { get; set; }
            public System.String KeyMaterialId { get; set; }
            public System.DateTime? ValidTo { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.ImportKeyMaterialResponse, ImportKMSKeyMaterialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
