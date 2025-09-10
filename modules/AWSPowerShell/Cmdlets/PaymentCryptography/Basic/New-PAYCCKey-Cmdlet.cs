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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Creates an Amazon Web Services Payment Cryptography key, a logical representation
    /// of a cryptographic key, that is unique in your account and Amazon Web Services Region.
    /// You use keys for cryptographic functions such as encryption and decryption. 
    /// 
    ///  
    /// <para>
    /// In addition to the key material used in cryptographic operations, an Amazon Web Services
    /// Payment Cryptography key includes metadata such as the key ARN, key usage, key origin,
    /// creation date, description, and key state.
    /// </para><para>
    /// When you create a key, you specify both immutable and mutable data about the key.
    /// The immutable data contains key attributes that define the scope and cryptographic
    /// operations that you can perform using the key, for example key class (example: <c>SYMMETRIC_KEY</c>),
    /// key algorithm (example: <c>TDES_2KEY</c>), key usage (example: <c>TR31_P0_PIN_ENCRYPTION_KEY</c>)
    /// and key modes of use (example: <c>Encrypt</c>). Amazon Web Services Payment Cryptography
    /// binds key attributes to keys using key blocks when you store or export them. Amazon
    /// Web Services Payment Cryptography stores the key contents wrapped and never stores
    /// or transmits them in the clear.
    /// </para><para>
    /// For information about valid combinations of key attributes, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// The mutable data contained within a key includes usage timestamp and key deletion
    /// timestamp and can be modified after creation.
    /// </para><para>
    /// You can use the <c>CreateKey</c> operation to generate an ECC (Elliptic Curve Cryptography)
    /// key pair used for establishing an ECDH (Elliptic Curve Diffie-Hellman) key agreement
    /// between two parties. In the ECDH key agreement process, both parties generate their
    /// own ECC key pair with key usage K3 and exchange the public keys. Each party then use
    /// their private key, the received public key from the other party, and the key derivation
    /// parameters including key derivation function, hash algorithm, derivation data, and
    /// key algorithm to derive a shared key.
    /// </para><para>
    /// To maintain the single-use principle of cryptographic keys in payments, ECDH derived
    /// keys should not be used for multiple purposes, such as a <c>TR31_P0_PIN_ENCRYPTION_KEY</c>
    /// and <c>TR31_K1_KEY_BLOCK_PROTECTION_KEY</c>. When creating ECC key pairs in Amazon
    /// Web Services Payment Cryptography you can optionally set the <c>DeriveKeyUsage</c>
    /// parameter, which defines the key usage bound to the symmetric key that will be derived
    /// using the ECC key pair.
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_DeleteKey.html">DeleteKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetKey.html">GetKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ListKeys.html">ListKeys</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PAYCCKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptography.Model.Key")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane CreateKey API operation.", Operation = new[] {"CreateKey"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.CreateKeyResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptography.Model.Key or Amazon.PaymentCryptography.Model.CreateKeyResponse",
        "This cmdlet returns an Amazon.PaymentCryptography.Model.Key object.",
        "The service call response (type Amazon.PaymentCryptography.Model.CreateKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPAYCCKeyCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyModesOfUse_Decrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to decrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_Decrypt")]
        public System.Boolean? KeyModesOfUse_Decrypt { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_DeriveKey
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to derive
        /// new keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_DeriveKey")]
        public System.Boolean? KeyModesOfUse_DeriveKey { get; set; }
        #endregion
        
        #region Parameter DeriveKeyUsage
        /// <summary>
        /// <para>
        /// <para>The intended cryptographic usage of keys derived from the ECC key pair to be created.</para><para>After creating an ECC key pair, you cannot change the intended cryptographic usage
        /// of keys derived from it using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.DeriveKeyUsage")]
        public Amazon.PaymentCryptography.DeriveKeyUsage DeriveKeyUsage { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the key. If the key is enabled, it is activated for use
        /// within the service. If the key is not enabled, then it is created but not activated.
        /// The default value is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Encrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to encrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_Encrypt")]
        public System.Boolean? KeyModesOfUse_Encrypt { get; set; }
        #endregion
        
        #region Parameter Exportable
        /// <summary>
        /// <para>
        /// <para>Specifies whether the key is exportable from the service.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Exportable { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Generate
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to generate
        /// and verify other card and PIN verification keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_Generate")]
        public System.Boolean? KeyModesOfUse_Generate { get; set; }
        #endregion
        
        #region Parameter KeyAttributes_KeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithm to be use during creation of an Amazon Web Services Payment Cryptography
        /// key.</para><para>For symmetric keys, Amazon Web Services Payment Cryptography supports <c>AES</c> and
        /// <c>TDES</c> algorithms. For asymmetric keys, Amazon Web Services Payment Cryptography
        /// supports <c>RSA</c> and <c>ECC_NIST</c> algorithms.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyAlgorithm")]
        public Amazon.PaymentCryptography.KeyAlgorithm KeyAttributes_KeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyCheckValueAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that Amazon Web Services Payment Cryptography uses to calculate the
        /// key check value (KCV). It is used to validate the key integrity.</para><para>For TDES keys, the KCV is computed by encrypting 8 bytes, each with value of zero,
        /// with the key to be checked and retaining the 3 highest order bytes of the encrypted
        /// result. For AES keys, the KCV is computed using a CMAC algorithm where the input data
        /// is 16 bytes of zero and retaining the 3 highest order bytes of the encrypted result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyCheckValueAlgorithm")]
        public Amazon.PaymentCryptography.KeyCheckValueAlgorithm KeyCheckValueAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyAttributes_KeyClass
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services Payment Cryptography key to create, which determines
        /// the classiﬁcation of the cryptographic method and whether Amazon Web Services Payment
        /// Cryptography key contains a symmetric key or an asymmetric key pair.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyClass")]
        public Amazon.PaymentCryptography.KeyClass KeyAttributes_KeyClass { get; set; }
        #endregion
        
        #region Parameter KeyAttributes_KeyUsage
        /// <summary>
        /// <para>
        /// <para>The cryptographic usage of an Amazon Web Services Payment Cryptography key as deﬁned
        /// in section A.5.2 of the TR-31 spec.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyUsage")]
        public Amazon.PaymentCryptography.KeyUsage KeyAttributes_KeyUsage { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_NoRestriction
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key has no special restrictions
        /// other than the restrictions implied by <c>KeyUsage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_NoRestrictions")]
        public System.Boolean? KeyModesOfUse_NoRestriction { get; set; }
        #endregion
        
        #region Parameter ReplicationRegion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicationRegions")]
        public System.String[] ReplicationRegion { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Sign
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used for signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_Sign")]
        public System.Boolean? KeyModesOfUse_Sign { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags to the Amazon Web Services Payment Cryptography key. Use
        /// this parameter to tag a key when it is created. To tag an existing Amazon Web Services
        /// Payment Cryptography key, use the <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_TagResource.html">TagResource</a>
        /// operation.</para><para>Each tag consists of a tag key and a tag value. Both the tag key and the tag value
        /// are required, but the tag value can be an empty (null) string. You can't have more
        /// than one tag on an Amazon Web Services Payment Cryptography key with the same tag
        /// key. </para><important><para>Don't include personal, confidential or sensitive information in this field. This
        /// field may be displayed in plaintext in CloudTrail logs and other output.</para></important><note><para>Tagging or untagging an Amazon Web Services Payment Cryptography key can allow or
        /// deny permission to the key.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PaymentCryptography.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Unwrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to unwrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_Unwrap")]
        public System.Boolean? KeyModesOfUse_Unwrap { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Verify
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to verify
        /// signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_Verify")]
        public System.Boolean? KeyModesOfUse_Verify { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Wrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to wrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyAttributes_KeyModesOfUse_Wrap")]
        public System.Boolean? KeyModesOfUse_Wrap { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Key'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.CreateKeyResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.CreateKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Key";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Exportable parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Exportable' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Exportable' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Exportable), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PAYCCKey (CreateKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.CreateKeyResponse, NewPAYCCKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Exportable;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeriveKeyUsage = this.DeriveKeyUsage;
            context.Enabled = this.Enabled;
            context.Exportable = this.Exportable;
            #if MODULAR
            if (this.Exportable == null && ParameterWasBound(nameof(this.Exportable)))
            {
                WriteWarning("You are passing $null as a value for parameter Exportable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyAttributes_KeyAlgorithm = this.KeyAttributes_KeyAlgorithm;
            #if MODULAR
            if (this.KeyAttributes_KeyAlgorithm == null && ParameterWasBound(nameof(this.KeyAttributes_KeyAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyAttributes_KeyAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyAttributes_KeyClass = this.KeyAttributes_KeyClass;
            #if MODULAR
            if (this.KeyAttributes_KeyClass == null && ParameterWasBound(nameof(this.KeyAttributes_KeyClass)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyAttributes_KeyClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyModesOfUse_Decrypt = this.KeyModesOfUse_Decrypt;
            context.KeyModesOfUse_DeriveKey = this.KeyModesOfUse_DeriveKey;
            context.KeyModesOfUse_Encrypt = this.KeyModesOfUse_Encrypt;
            context.KeyModesOfUse_Generate = this.KeyModesOfUse_Generate;
            context.KeyModesOfUse_NoRestriction = this.KeyModesOfUse_NoRestriction;
            context.KeyModesOfUse_Sign = this.KeyModesOfUse_Sign;
            context.KeyModesOfUse_Unwrap = this.KeyModesOfUse_Unwrap;
            context.KeyModesOfUse_Verify = this.KeyModesOfUse_Verify;
            context.KeyModesOfUse_Wrap = this.KeyModesOfUse_Wrap;
            context.KeyAttributes_KeyUsage = this.KeyAttributes_KeyUsage;
            #if MODULAR
            if (this.KeyAttributes_KeyUsage == null && ParameterWasBound(nameof(this.KeyAttributes_KeyUsage)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyAttributes_KeyUsage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyCheckValueAlgorithm = this.KeyCheckValueAlgorithm;
            if (this.ReplicationRegion != null)
            {
                context.ReplicationRegion = new List<System.String>(this.ReplicationRegion);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.PaymentCryptography.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.PaymentCryptography.Model.CreateKeyRequest();
            
            if (cmdletContext.DeriveKeyUsage != null)
            {
                request.DeriveKeyUsage = cmdletContext.DeriveKeyUsage;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.Exportable != null)
            {
                request.Exportable = cmdletContext.Exportable.Value;
            }
            
             // populate KeyAttributes
            var requestKeyAttributesIsNull = true;
            request.KeyAttributes = new Amazon.PaymentCryptography.Model.KeyAttributes();
            Amazon.PaymentCryptography.KeyAlgorithm requestKeyAttributes_keyAttributes_KeyAlgorithm = null;
            if (cmdletContext.KeyAttributes_KeyAlgorithm != null)
            {
                requestKeyAttributes_keyAttributes_KeyAlgorithm = cmdletContext.KeyAttributes_KeyAlgorithm;
            }
            if (requestKeyAttributes_keyAttributes_KeyAlgorithm != null)
            {
                request.KeyAttributes.KeyAlgorithm = requestKeyAttributes_keyAttributes_KeyAlgorithm;
                requestKeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyClass requestKeyAttributes_keyAttributes_KeyClass = null;
            if (cmdletContext.KeyAttributes_KeyClass != null)
            {
                requestKeyAttributes_keyAttributes_KeyClass = cmdletContext.KeyAttributes_KeyClass;
            }
            if (requestKeyAttributes_keyAttributes_KeyClass != null)
            {
                request.KeyAttributes.KeyClass = requestKeyAttributes_keyAttributes_KeyClass;
                requestKeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyUsage requestKeyAttributes_keyAttributes_KeyUsage = null;
            if (cmdletContext.KeyAttributes_KeyUsage != null)
            {
                requestKeyAttributes_keyAttributes_KeyUsage = cmdletContext.KeyAttributes_KeyUsage;
            }
            if (requestKeyAttributes_keyAttributes_KeyUsage != null)
            {
                request.KeyAttributes.KeyUsage = requestKeyAttributes_keyAttributes_KeyUsage;
                requestKeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyModesOfUse requestKeyAttributes_keyAttributes_KeyModesOfUse = null;
            
             // populate KeyModesOfUse
            requestKeyAttributes_keyAttributes_KeyModesOfUse = new Amazon.PaymentCryptography.Model.KeyModesOfUse();
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt = null;
            if (cmdletContext.KeyModesOfUse_Decrypt != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt = cmdletContext.KeyModesOfUse_Decrypt.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.Decrypt = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey = null;
            if (cmdletContext.KeyModesOfUse_DeriveKey != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey = cmdletContext.KeyModesOfUse_DeriveKey.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.DeriveKey = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt = null;
            if (cmdletContext.KeyModesOfUse_Encrypt != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt = cmdletContext.KeyModesOfUse_Encrypt.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.Encrypt = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Generate = null;
            if (cmdletContext.KeyModesOfUse_Generate != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Generate = cmdletContext.KeyModesOfUse_Generate.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Generate != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.Generate = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Generate.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction = null;
            if (cmdletContext.KeyModesOfUse_NoRestriction != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction = cmdletContext.KeyModesOfUse_NoRestriction.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.NoRestrictions = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Sign = null;
            if (cmdletContext.KeyModesOfUse_Sign != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Sign = cmdletContext.KeyModesOfUse_Sign.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Sign != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.Sign = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Sign.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap = null;
            if (cmdletContext.KeyModesOfUse_Unwrap != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap = cmdletContext.KeyModesOfUse_Unwrap.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.Unwrap = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Verify = null;
            if (cmdletContext.KeyModesOfUse_Verify != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Verify = cmdletContext.KeyModesOfUse_Verify.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Verify != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.Verify = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Verify.Value;
            }
            System.Boolean? requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Wrap = null;
            if (cmdletContext.KeyModesOfUse_Wrap != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Wrap = cmdletContext.KeyModesOfUse_Wrap.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Wrap != null)
            {
                requestKeyAttributes_keyAttributes_KeyModesOfUse.Wrap = requestKeyAttributes_keyAttributes_KeyModesOfUse_keyModesOfUse_Wrap.Value;
            }
            if (requestKeyAttributes_keyAttributes_KeyModesOfUse != null)
            {
                request.KeyAttributes.KeyModesOfUse = requestKeyAttributes_keyAttributes_KeyModesOfUse;
                requestKeyAttributesIsNull = false;
            }
             // determine if request.KeyAttributes should be set to null
            if (requestKeyAttributesIsNull)
            {
                request.KeyAttributes = null;
            }
            if (cmdletContext.KeyCheckValueAlgorithm != null)
            {
                request.KeyCheckValueAlgorithm = cmdletContext.KeyCheckValueAlgorithm;
            }
            if (cmdletContext.ReplicationRegion != null)
            {
                request.ReplicationRegions = cmdletContext.ReplicationRegion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PaymentCryptography.Model.CreateKeyResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.CreateKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "CreateKey");
            try
            {
                #if DESKTOP
                return client.CreateKey(request);
                #elif CORECLR
                return client.CreateKeyAsync(request).GetAwaiter().GetResult();
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
            public Amazon.PaymentCryptography.DeriveKeyUsage DeriveKeyUsage { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.Boolean? Exportable { get; set; }
            public Amazon.PaymentCryptography.KeyAlgorithm KeyAttributes_KeyAlgorithm { get; set; }
            public Amazon.PaymentCryptography.KeyClass KeyAttributes_KeyClass { get; set; }
            public System.Boolean? KeyModesOfUse_Decrypt { get; set; }
            public System.Boolean? KeyModesOfUse_DeriveKey { get; set; }
            public System.Boolean? KeyModesOfUse_Encrypt { get; set; }
            public System.Boolean? KeyModesOfUse_Generate { get; set; }
            public System.Boolean? KeyModesOfUse_NoRestriction { get; set; }
            public System.Boolean? KeyModesOfUse_Sign { get; set; }
            public System.Boolean? KeyModesOfUse_Unwrap { get; set; }
            public System.Boolean? KeyModesOfUse_Verify { get; set; }
            public System.Boolean? KeyModesOfUse_Wrap { get; set; }
            public Amazon.PaymentCryptography.KeyUsage KeyAttributes_KeyUsage { get; set; }
            public Amazon.PaymentCryptography.KeyCheckValueAlgorithm KeyCheckValueAlgorithm { get; set; }
            public List<System.String> ReplicationRegion { get; set; }
            public List<Amazon.PaymentCryptography.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.CreateKeyResponse, NewPAYCCKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Key;
        }
        
    }
}
