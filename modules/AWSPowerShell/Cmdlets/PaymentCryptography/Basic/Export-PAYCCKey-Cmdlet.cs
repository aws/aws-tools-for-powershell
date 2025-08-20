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
    /// Exports a key from Amazon Web Services Payment Cryptography.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services Payment Cryptography simplifies key exchange by replacing the
    /// existing paper-based approach with a modern electronic approach. With <c>ExportKey</c>
    /// you can export symmetric keys using either symmetric and asymmetric key exchange mechanisms.
    /// Using this operation, you can share your Amazon Web Services Payment Cryptography
    /// generated keys with other service partners to perform cryptographic operations outside
    /// of Amazon Web Services Payment Cryptography 
    /// </para><para>
    /// For symmetric key exchange, Amazon Web Services Payment Cryptography uses the ANSI
    /// X9 TR-31 norm in accordance with PCI PIN guidelines. And for asymmetric key exchange,
    /// Amazon Web Services Payment Cryptography supports ANSI X9 TR-34 norm, RSA unwrap,
    /// and ECDH (Elliptic Curve Diffie-Hellman) key exchange mechanisms. Asymmetric key exchange
    /// methods are typically used to establish bi-directional trust between the two parties
    /// exhanging keys and are used for initial key exchange such as Key Encryption Key (KEK).
    /// After which you can export working keys using symmetric method to perform various
    /// cryptographic operations within Amazon Web Services Payment Cryptography.
    /// </para><para>
    /// PCI requires specific minimum key strength of wrapping keys used to protect the keys
    /// being exchanged electronically. These requirements can change when PCI standards are
    /// revised. The rules specify that wrapping keys used for transport must be at least
    /// as strong as the key being protected. For more information on recommended key strength
    /// of wrapping keys and key exchange mechanism, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-importexport.html">Importing
    /// and exporting keys</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// </para><para>
    /// You can also use <c>ExportKey</c> functionality to generate and export an IPEK (Initial
    /// Pin Encryption Key) from Amazon Web Services Payment Cryptography using either TR-31
    /// or TR-34 export key exchange. IPEK is generated from BDK (Base Derivation Key) and
    /// <c>ExportDukptInitialKey</c> attribute KSN (<c>KeySerialNumber</c>). The generated
    /// IPEK does not persist within Amazon Web Services Payment Cryptography and has to be
    /// re-generated each time during export.
    /// </para><para>
    /// For key exchange using TR-31 or TR-34 key blocks, you can also export optional blocks
    /// within the key block header which contain additional attribute information about the
    /// key. The <c>KeyVersion</c> within <c>KeyBlockHeaders</c> indicates the version of
    /// the key within the key block. Furthermore, <c>KeyExportability</c> within <c>KeyBlockHeaders</c>
    /// can be used to further restrict exportability of the key after export from Amazon
    /// Web Services Payment Cryptography.
    /// </para><para>
    /// The <c>OptionalBlocks</c> contain the additional data related to the key. For information
    /// on data type that can be included within optional blocks, refer to <a href="https://webstore.ansi.org/standards/ascx9/ansix91432022">ASC
    /// X9.143-2022</a>.
    /// </para><note><para>
    /// Data included in key block headers is signed but transmitted in clear text. Sensitive
    /// or confidential information should not be included in optional blocks. Refer to ASC
    /// X9.143-2022 standard for information on allowed data type.
    /// </para></note><para><b>To export initial keys (KEK) or IPEK using TR-34</b></para><para>
    /// Using this operation, you can export initial key using TR-34 asymmetric key exchange.
    /// You can only export KEK generated within Amazon Web Services Payment Cryptography.
    /// In TR-34 terminology, the sending party of the key is called Key Distribution Host
    /// (KDH) and the receiving party of the key is called Key Receiving Device (KRD). During
    /// key export process, KDH is Amazon Web Services Payment Cryptography which initiates
    /// key export and KRD is the user receiving the key.
    /// </para><para>
    /// To initiate TR-34 key export, the KRD must obtain an export token by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForExport.html">GetParametersForExport</a>.
    /// This operation also generates a key pair for the purpose of key export, signs the
    /// key and returns back the signing public key certificate (also known as KDH signing
    /// certificate) and root certificate chain. The KDH uses the private key to sign the
    /// the export payload and the signing public key certificate is provided to KRD to verify
    /// the signature. The KRD can import the root certificate into its Hardware Security
    /// Module (HSM), as required. The export token and the associated KDH signing certificate
    /// expires after 30 days. 
    /// </para><para>
    /// Next the KRD generates a key pair for the the purpose of encrypting the KDH key and
    /// provides the public key cerificate (also known as KRD wrapping certificate) back to
    /// KDH. The KRD will also import the root cerificate chain into Amazon Web Services Payment
    /// Cryptography by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>
    /// for <c>RootCertificatePublicKey</c>. The KDH, Amazon Web Services Payment Cryptography,
    /// will use the KRD wrapping cerificate to encrypt (wrap) the key under export and signs
    /// it with signing private key to generate a TR-34 WrappedKeyBlock. For more information
    /// on TR-34 key export, see section <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-export.html">Exporting
    /// symmetric keys</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    /// </para><para>
    /// Set the following parameters:
    /// </para><ul><li><para><c>ExportAttributes</c>: Specify export attributes in case of IPEK export. This parameter
    /// is optional for KEK export.
    /// </para></li><li><para><c>ExportKeyIdentifier</c>: The <c>KeyARN</c> of the KEK or BDK (in case of IPEK)
    /// under export.
    /// </para></li><li><para><c>KeyMaterial</c>: Use <c>Tr34KeyBlock</c> parameters.
    /// </para></li><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: The <c>KeyARN</c> of the certificate
    /// chain that signed the KRD wrapping key certificate.
    /// </para></li><li><para><c>ExportToken</c>: Obtained from KDH by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForImport.html">GetParametersForImport</a>.
    /// </para></li><li><para><c>WrappingKeyCertificate</c>: The public key certificate in PEM format (base64 encoded)
    /// of the KRD wrapping key Amazon Web Services Payment Cryptography uses for encryption
    /// of the TR-34 export payload. This certificate must be signed by the root certificate
    /// (CertificateAuthorityPublicKeyIdentifier) imported into Amazon Web Services Payment
    /// Cryptography.
    /// </para></li></ul><para>
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// the KEK or IPEK as a TR-34 WrappedKeyBlock. 
    /// </para><para><b>To export initial keys (KEK) or IPEK using RSA Wrap and Unwrap</b></para><para>
    /// Using this operation, you can export initial key using asymmetric RSA wrap and unwrap
    /// key exchange method. To initiate export, generate an asymmetric key pair on the receiving
    /// HSM and obtain the public key certificate in PEM format (base64 encoded) for the purpose
    /// of wrapping and the root certifiate chain. Import the root certificate into Amazon
    /// Web Services Payment Cryptography by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>
    /// for <c>RootCertificatePublicKey</c>.
    /// </para><para>
    /// Next call <c>ExportKey</c> and set the following parameters:
    /// </para><ul><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: The <c>KeyARN</c> of the certificate
    /// chain that signed wrapping key certificate.
    /// </para></li><li><para><c>KeyMaterial</c>: Set to <c>KeyCryptogram</c>.
    /// </para></li><li><para><c>WrappingKeyCertificate</c>: The public key certificate in PEM format (base64 encoded)
    /// obtained by the receiving HSM and signed by the root certificate (CertificateAuthorityPublicKeyIdentifier)
    /// imported into Amazon Web Services Payment Cryptography. The receiving HSM uses its
    /// private key component to unwrap the WrappedKeyCryptogram.
    /// </para></li></ul><para>
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// the WrappedKeyCryptogram. 
    /// </para><para><b>To export working keys or IPEK using TR-31</b></para><para>
    /// Using this operation, you can export working keys or IPEK using TR-31 symmetric key
    /// exchange. In TR-31, you must use an initial key such as KEK to encrypt or wrap the
    /// key under export. To establish a KEK, you can use <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>
    /// or <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>.
    /// 
    /// </para><para>
    /// Set the following parameters:
    /// </para><ul><li><para><c>ExportAttributes</c>: Specify export attributes in case of IPEK export. This parameter
    /// is optional for KEK export.
    /// </para></li><li><para><c>ExportKeyIdentifier</c>: The <c>KeyARN</c> of the KEK or BDK (in case of IPEK)
    /// under export.
    /// </para></li><li><para><c>KeyMaterial</c>: Use <c>Tr31KeyBlock</c> parameters.
    /// </para></li></ul><para><b>To export working keys using ECDH</b></para><para>
    /// You can also use ECDH key agreement to export working keys in a TR-31 keyblock, where
    /// the wrapping key is an ECDH derived key.
    /// </para><para>
    /// To initiate a TR-31 key export using ECDH, both sides must create an ECC key pair
    /// with key usage K3 and exchange public key certificates. In Amazon Web Services Payment
    /// Cryptography, you can do this by calling <c>CreateKey</c>. If you have not already
    /// done so, you must import the CA chain that issued the receiving public key certificate
    /// by calling <c>ImportKey</c> with input <c>RootCertificatePublicKey</c> for root CA
    /// or <c>TrustedPublicKey</c> for intermediate CA. You can then complete a TR-31 key
    /// export by deriving a shared wrapping key using the service ECC key pair, public certificate
    /// of your ECC key pair outside of Amazon Web Services Payment Cryptography, and the
    /// key derivation parameters including key derivation function, hash algorithm, derivation
    /// data, key algorithm.
    /// </para><ul><li><para><c>KeyMaterial</c>: Use <c>DiffieHellmanTr31KeyBlock</c> parameters.
    /// </para></li><li><para><c>PrivateKeyIdentifier</c>: The <c>KeyArn</c> of the ECC key pair created within
    /// Amazon Web Services Payment Cryptography to derive a shared KEK.
    /// </para></li><li><para><c>PublicKeyCertificate</c>: The public key certificate of the receiving ECC key
    /// pair in PEM format (base64 encoded) to derive a shared KEK.
    /// </para></li><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: The <c>keyARN</c> of the CA that
    /// signed the public key certificate of the receiving ECC key pair.
    /// </para></li></ul><para>
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// the working key as a TR-31 WrappedKeyBlock, where the wrapping key is the ECDH derived
    /// key.
    /// </para><para><b>Cross-account use:</b> This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForExport.html">GetParametersForExport</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a></para></li></ul>
    /// </summary>
    [Cmdlet("Export", "PAYCCKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptography.Model.WrappedKey")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane ExportKey API operation.", Operation = new[] {"ExportKey"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.ExportKeyResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptography.Model.WrappedKey or Amazon.PaymentCryptography.Model.ExportKeyResponse",
        "This cmdlet returns an Amazon.PaymentCryptography.Model.WrappedKey object.",
        "The service call response (type Amazon.PaymentCryptography.Model.ExportKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ExportPAYCCKeyCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the CA that signed the <c>PublicKeyCertificate</c> for the client's
        /// receiving ECC key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier")]
        public System.String DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the certificate chain that signs the wrapping key certificate
        /// during RSA wrap and unwrap key export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_CertificateAuthorityPublicKeyIdentifier")]
        public System.String KeyCryptogram_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the certificate chain that signs the wrapping key certificate
        /// during TR-34 key export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier")]
        public System.String Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to decrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Decrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to decrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt")]
        public System.Boolean? KeyModesOfUse_Decrypt { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to decrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to derive
        /// new keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_DeriveKey
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to derive
        /// new keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey")]
        public System.Boolean? KeyModesOfUse_DeriveKey { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to derive
        /// new keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithm of the shared derived ECDH key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.SymmetricKeyAlgorithm")]
        public Amazon.PaymentCryptography.SymmetricKeyAlgorithm DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to encrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Encrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to encrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt")]
        public System.Boolean? KeyModesOfUse_Encrypt { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to encrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt { get; set; }
        #endregion
        
        #region Parameter ExportKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the key under export from Amazon Web Services Payment Cryptography.</para>
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
        public System.String ExportKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_ExportToken
        /// <summary>
        /// <para>
        /// <para>The export token to initiate key export from Amazon Web Services Payment Cryptography.
        /// It also contains the signing key certificate that will sign the wrapped key during
        /// TR-34 key block generation. Call <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForExport.html">GetParametersForExport</a>
        /// to receive an export token. It expires after 30 days. You can use the same export
        /// token to export multiple keys from the same service account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_ExportToken")]
        public System.String Tr34KeyBlock_ExportToken { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to generate
        /// and verify other card and PIN verification keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Generate
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to generate
        /// and verify other card and PIN verification keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate")]
        public System.Boolean? KeyModesOfUse_Generate { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to generate
        /// and verify other card and PIN verification keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_KeyBlockFormat
        /// <summary>
        /// <para>
        /// <para>The format of key block that Amazon Web Services Payment Cryptography will use during
        /// key export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_KeyBlockFormat")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.Tr34KeyBlockFormat")]
        public Amazon.PaymentCryptography.Tr34KeyBlockFormat Tr34KeyBlock_KeyBlockFormat { get; set; }
        #endregion
        
        #region Parameter ExportAttributes_KeyCheckValueAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that Amazon Web Services Payment Cryptography uses to calculate the
        /// key check value (KCV). It is used to validate the key integrity. Specify KCV for IPEK
        /// export only.</para><para>For TDES keys, the KCV is computed by encrypting 8 bytes, each with value of zero,
        /// with the key to be checked and retaining the 3 highest order bytes of the encrypted
        /// result. For AES keys, the KCV is computed using a CMAC algorithm where the input data
        /// is 16 bytes of zero and retaining the 3 highest order bytes of the encrypted result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyCheckValueAlgorithm")]
        public Amazon.PaymentCryptography.KeyCheckValueAlgorithm ExportAttributes_KeyCheckValueAlgorithm { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_KeyDerivationFunction
        /// <summary>
        /// <para>
        /// <para>The key derivation function to use when deriving a key using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_KeyDerivationFunction")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyDerivationFunction")]
        public Amazon.PaymentCryptography.KeyDerivationFunction DiffieHellmanTr31KeyBlock_KeyDerivationFunction { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm
        /// <summary>
        /// <para>
        /// <para>The hash type to use when deriving a key using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyDerivationHashAlgorithm")]
        public Amazon.PaymentCryptography.KeyDerivationHashAlgorithm DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability
        /// <summary>
        /// <para>
        /// <para>Specifies subsequent exportability of the key within the key block after it is received
        /// by the receiving party. It can be used to further restrict exportability of the key
        /// after export from Amazon Web Services Payment Cryptography.</para><para>When set to <c>EXPORTABLE</c>, the key can be subsequently exported by the receiver
        /// under a KEK using TR-31 or TR-34 key block export only. When set to <c>NON_EXPORTABLE</c>,
        /// the key cannot be subsequently exported by the receiver. When set to <c>SENSITIVE</c>,
        /// the key can be exported by the receiver under a KEK using TR-31, TR-34, RSA wrap and
        /// unwrap cryptogram or using a symmetric cryptogram key export method. For further information
        /// refer to <a href="https://webstore.ansi.org/standards/ascx9/ansix91432022">ANSI X9.143-2022</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyExportability")]
        public Amazon.PaymentCryptography.KeyExportability KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability { get; set; }
        #endregion
        
        #region Parameter KeyBlockHeaders_KeyExportability
        /// <summary>
        /// <para>
        /// <para>Specifies subsequent exportability of the key within the key block after it is received
        /// by the receiving party. It can be used to further restrict exportability of the key
        /// after export from Amazon Web Services Payment Cryptography.</para><para>When set to <c>EXPORTABLE</c>, the key can be subsequently exported by the receiver
        /// under a KEK using TR-31 or TR-34 key block export only. When set to <c>NON_EXPORTABLE</c>,
        /// the key cannot be subsequently exported by the receiver. When set to <c>SENSITIVE</c>,
        /// the key can be exported by the receiver under a KEK using TR-31, TR-34, RSA wrap and
        /// unwrap cryptogram or using a symmetric cryptogram key export method. For further information
        /// refer to <a href="https://webstore.ansi.org/standards/ascx9/ansix91432022">ANSI X9.143-2022</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyExportability")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyExportability")]
        public Amazon.PaymentCryptography.KeyExportability KeyBlockHeaders_KeyExportability { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability
        /// <summary>
        /// <para>
        /// <para>Specifies subsequent exportability of the key within the key block after it is received
        /// by the receiving party. It can be used to further restrict exportability of the key
        /// after export from Amazon Web Services Payment Cryptography.</para><para>When set to <c>EXPORTABLE</c>, the key can be subsequently exported by the receiver
        /// under a KEK using TR-31 or TR-34 key block export only. When set to <c>NON_EXPORTABLE</c>,
        /// the key cannot be subsequently exported by the receiver. When set to <c>SENSITIVE</c>,
        /// the key can be exported by the receiver under a KEK using TR-31, TR-34, RSA wrap and
        /// unwrap cryptogram or using a symmetric cryptogram key export method. For further information
        /// refer to <a href="https://webstore.ansi.org/standards/ascx9/ansix91432022">ANSI X9.143-2022</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyExportability")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyExportability")]
        public Amazon.PaymentCryptography.KeyExportability KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability { get; set; }
        #endregion
        
        #region Parameter ExportDukptInitialKey_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The KSN for IPEK generation using DUKPT. </para><para>KSN must be padded before sending to Amazon Web Services Payment Cryptography. KSN
        /// hex length should be 20 for a TDES_2KEY key or 24 for an AES key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportAttributes_ExportDukptInitialKey_KeySerialNumber")]
        public System.String ExportDukptInitialKey_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion
        /// <summary>
        /// <para>
        /// <para>Parameter used to indicate the version of the key carried in the key block or indicate
        /// the value carried in the key block is a component of a key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion")]
        public System.String KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion { get; set; }
        #endregion
        
        #region Parameter KeyBlockHeaders_KeyVersion
        /// <summary>
        /// <para>
        /// <para>Parameter used to indicate the version of the key carried in the key block or indicate
        /// the value carried in the key block is a component of a key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyVersion")]
        public System.String KeyBlockHeaders_KeyVersion { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion
        /// <summary>
        /// <para>
        /// <para>Parameter used to indicate the version of the key carried in the key block or indicate
        /// the value carried in the key block is a component of a key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyVersion")]
        public System.String KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key has no special restrictions
        /// other than the restrictions implied by <c>KeyUsage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_NoRestriction
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key has no special restrictions
        /// other than the restrictions implied by <c>KeyUsage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions")]
        public System.Boolean? KeyModesOfUse_NoRestriction { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key has no special restrictions
        /// other than the restrictions implied by <c>KeyUsage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks
        /// <summary>
        /// <para>
        /// <para>Parameter used to indicate the type of optional data in key block headers. Refer to
        /// <a href="https://webstore.ansi.org/standards/ascx9/ansix91432022">ANSI X9.143-2022</a>
        /// for information on allowed data type for optional blocks.</para><para>Optional block character limit is 112 characters. For each optional block, 2 characters
        /// are reserved for optional block ID and 2 characters reserved for optional block length.
        /// More than one optional blocks can be included as long as the combined length does
        /// not increase 112 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks")]
        public System.Collections.Hashtable KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks { get; set; }
        #endregion
        
        #region Parameter KeyBlockHeaders_OptionalBlock
        /// <summary>
        /// <para>
        /// <para>Parameter used to indicate the type of optional data in key block headers. Refer to
        /// <a href="https://webstore.ansi.org/standards/ascx9/ansix91432022">ANSI X9.143-2022</a>
        /// for information on allowed data type for optional blocks.</para><para>Optional block character limit is 112 characters. For each optional block, 2 characters
        /// are reserved for optional block ID and 2 characters reserved for optional block length.
        /// More than one optional blocks can be included as long as the combined length does
        /// not increase 112 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_OptionalBlocks")]
        public System.Collections.Hashtable KeyBlockHeaders_OptionalBlock { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks
        /// <summary>
        /// <para>
        /// <para>Parameter used to indicate the type of optional data in key block headers. Refer to
        /// <a href="https://webstore.ansi.org/standards/ascx9/ansix91432022">ANSI X9.143-2022</a>
        /// for information on allowed data type for optional blocks.</para><para>Optional block character limit is 112 characters. For each optional block, 2 characters
        /// are reserved for optional block ID and 2 characters reserved for optional block length.
        /// More than one optional blocks can be included as long as the combined length does
        /// not increase 112 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks")]
        public System.Collections.Hashtable KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the asymmetric ECC key created within Amazon Web Services Payment
        /// Cryptography.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier")]
        public System.String DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_PublicKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The public key certificate of the client's receiving ECC key pair, in PEM format (base64
        /// encoded), to use for ECDH key derivation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_PublicKeyCertificate")]
        public System.String DiffieHellmanTr31KeyBlock_PublicKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_RandomNonce
        /// <summary>
        /// <para>
        /// <para>A random number value that is unique to the TR-34 key block generated using 2 pass.
        /// The operation will fail, if a random nonce value is not provided for a TR-34 key block
        /// generated using 2 pass.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_RandomNonce")]
        public System.String Tr34KeyBlock_RandomNonce { get; set; }
        #endregion
        
        #region Parameter DerivationData_SharedInformation
        /// <summary>
        /// <para>
        /// <para>A string containing information that binds the ECDH derived key to the two parties
        /// involved or to the context of the key.</para><para>It may include details like identities of the two parties deriving the key, context
        /// of the operation, session IDs, and optionally a nonce. It must not contain zero bytes.
        /// It is not recommended to reuse shared information for multiple ECDH key derivations,
        /// as it could result in derived key material being the same across different derivations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_SharedInformation")]
        public System.String DerivationData_SharedInformation { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used for signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Sign
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used for signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign")]
        public System.Boolean? KeyModesOfUse_Sign { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used for signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to unwrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Unwrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to unwrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap")]
        public System.Boolean? KeyModesOfUse_Unwrap { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to unwrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to verify
        /// signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Verify
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to verify
        /// signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify")]
        public System.Boolean? KeyModesOfUse_Verify { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to verify
        /// signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to wrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap")]
        public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Wrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to wrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap")]
        public System.Boolean? KeyModesOfUse_Wrap { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to wrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap")]
        public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_WrappingKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The wrapping key certificate in PEM format (base64 encoded). Amazon Web Services Payment
        /// Cryptography uses this certificate to wrap the key under export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_WrappingKeyCertificate")]
        public System.String KeyCryptogram_WrappingKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_WrappingKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the wrapping key certificate. Amazon Web Services Payment Cryptography
        /// uses this certificate to wrap the key under export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_WrappingKeyCertificate")]
        public System.String Tr34KeyBlock_WrappingKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Tr31KeyBlock_WrappingKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the the wrapping key. This key encrypts or wraps the key under
        /// export for TR-31 key block generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_WrappingKeyIdentifier")]
        public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_WrappingSpec
        /// <summary>
        /// <para>
        /// <para>The wrapping spec for the key under export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_WrappingSpec")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.WrappingKeySpec")]
        public Amazon.PaymentCryptography.WrappingKeySpec KeyCryptogram_WrappingSpec { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WrappedKey'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.ExportKeyResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.ExportKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WrappedKey";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExportKeyIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExportKeyIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExportKeyIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExportKeyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-PAYCCKey (ExportKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.ExportKeyResponse, ExportPAYCCKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExportKeyIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExportDukptInitialKey_KeySerialNumber = this.ExportDukptInitialKey_KeySerialNumber;
            context.ExportAttributes_KeyCheckValueAlgorithm = this.ExportAttributes_KeyCheckValueAlgorithm;
            context.ExportKeyIdentifier = this.ExportKeyIdentifier;
            #if MODULAR
            if (this.ExportKeyIdentifier == null && ParameterWasBound(nameof(this.ExportKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier = this.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            context.DerivationData_SharedInformation = this.DerivationData_SharedInformation;
            context.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm = this.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap;
            context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion = this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion;
            if (this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks != null)
            {
                context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks.Keys)
                {
                    context.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks.Add((String)hashKey, (System.String)(this.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks[hashKey]));
                }
            }
            context.DiffieHellmanTr31KeyBlock_KeyDerivationFunction = this.DiffieHellmanTr31KeyBlock_KeyDerivationFunction;
            context.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm = this.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm;
            context.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier = this.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier;
            context.DiffieHellmanTr31KeyBlock_PublicKeyCertificate = this.DiffieHellmanTr31KeyBlock_PublicKeyCertificate;
            context.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier = this.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier;
            context.KeyCryptogram_WrappingKeyCertificate = this.KeyCryptogram_WrappingKeyCertificate;
            context.KeyCryptogram_WrappingSpec = this.KeyCryptogram_WrappingSpec;
            context.KeyBlockHeaders_KeyExportability = this.KeyBlockHeaders_KeyExportability;
            context.KeyModesOfUse_Decrypt = this.KeyModesOfUse_Decrypt;
            context.KeyModesOfUse_DeriveKey = this.KeyModesOfUse_DeriveKey;
            context.KeyModesOfUse_Encrypt = this.KeyModesOfUse_Encrypt;
            context.KeyModesOfUse_Generate = this.KeyModesOfUse_Generate;
            context.KeyModesOfUse_NoRestriction = this.KeyModesOfUse_NoRestriction;
            context.KeyModesOfUse_Sign = this.KeyModesOfUse_Sign;
            context.KeyModesOfUse_Unwrap = this.KeyModesOfUse_Unwrap;
            context.KeyModesOfUse_Verify = this.KeyModesOfUse_Verify;
            context.KeyModesOfUse_Wrap = this.KeyModesOfUse_Wrap;
            context.KeyBlockHeaders_KeyVersion = this.KeyBlockHeaders_KeyVersion;
            if (this.KeyBlockHeaders_OptionalBlock != null)
            {
                context.KeyBlockHeaders_OptionalBlock = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.KeyBlockHeaders_OptionalBlock.Keys)
                {
                    context.KeyBlockHeaders_OptionalBlock.Add((String)hashKey, (System.String)(this.KeyBlockHeaders_OptionalBlock[hashKey]));
                }
            }
            context.Tr31KeyBlock_WrappingKeyIdentifier = this.Tr31KeyBlock_WrappingKeyIdentifier;
            context.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier = this.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            context.Tr34KeyBlock_ExportToken = this.Tr34KeyBlock_ExportToken;
            context.Tr34KeyBlock_KeyBlockFormat = this.Tr34KeyBlock_KeyBlockFormat;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap;
            context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion = this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion;
            if (this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks != null)
            {
                context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks.Keys)
                {
                    context.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks.Add((String)hashKey, (System.String)(this.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks[hashKey]));
                }
            }
            context.Tr34KeyBlock_RandomNonce = this.Tr34KeyBlock_RandomNonce;
            context.Tr34KeyBlock_WrappingKeyCertificate = this.Tr34KeyBlock_WrappingKeyCertificate;
            
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
            var request = new Amazon.PaymentCryptography.Model.ExportKeyRequest();
            
            
             // populate ExportAttributes
            var requestExportAttributesIsNull = true;
            request.ExportAttributes = new Amazon.PaymentCryptography.Model.ExportAttributes();
            Amazon.PaymentCryptography.KeyCheckValueAlgorithm requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm = null;
            if (cmdletContext.ExportAttributes_KeyCheckValueAlgorithm != null)
            {
                requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm = cmdletContext.ExportAttributes_KeyCheckValueAlgorithm;
            }
            if (requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm != null)
            {
                request.ExportAttributes.KeyCheckValueAlgorithm = requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm;
                requestExportAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.Model.ExportDukptInitialKey requestExportAttributes_exportAttributes_ExportDukptInitialKey = null;
            
             // populate ExportDukptInitialKey
            var requestExportAttributes_exportAttributes_ExportDukptInitialKeyIsNull = true;
            requestExportAttributes_exportAttributes_ExportDukptInitialKey = new Amazon.PaymentCryptography.Model.ExportDukptInitialKey();
            System.String requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber = null;
            if (cmdletContext.ExportDukptInitialKey_KeySerialNumber != null)
            {
                requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber = cmdletContext.ExportDukptInitialKey_KeySerialNumber;
            }
            if (requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber != null)
            {
                requestExportAttributes_exportAttributes_ExportDukptInitialKey.KeySerialNumber = requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber;
                requestExportAttributes_exportAttributes_ExportDukptInitialKeyIsNull = false;
            }
             // determine if requestExportAttributes_exportAttributes_ExportDukptInitialKey should be set to null
            if (requestExportAttributes_exportAttributes_ExportDukptInitialKeyIsNull)
            {
                requestExportAttributes_exportAttributes_ExportDukptInitialKey = null;
            }
            if (requestExportAttributes_exportAttributes_ExportDukptInitialKey != null)
            {
                request.ExportAttributes.ExportDukptInitialKey = requestExportAttributes_exportAttributes_ExportDukptInitialKey;
                requestExportAttributesIsNull = false;
            }
             // determine if request.ExportAttributes should be set to null
            if (requestExportAttributesIsNull)
            {
                request.ExportAttributes = null;
            }
            if (cmdletContext.ExportKeyIdentifier != null)
            {
                request.ExportKeyIdentifier = cmdletContext.ExportKeyIdentifier;
            }
            
             // populate KeyMaterial
            request.KeyMaterial = new Amazon.PaymentCryptography.Model.ExportKeyMaterial();
            Amazon.PaymentCryptography.Model.ExportTr31KeyBlock requestKeyMaterial_keyMaterial_Tr31KeyBlock = null;
            
             // populate Tr31KeyBlock
            var requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_Tr31KeyBlock = new Amazon.PaymentCryptography.Model.ExportTr31KeyBlock();
            System.String requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier = null;
            if (cmdletContext.Tr31KeyBlock_WrappingKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier = cmdletContext.Tr31KeyBlock_WrappingKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock.WrappingKeyIdentifier = requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier;
                requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyBlockHeaders requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders = null;
            
             // populate KeyBlockHeaders
            var requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeadersIsNull = true;
            requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders = new Amazon.PaymentCryptography.Model.KeyBlockHeaders();
            Amazon.PaymentCryptography.KeyExportability requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyExportability = null;
            if (cmdletContext.KeyBlockHeaders_KeyExportability != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyExportability = cmdletContext.KeyBlockHeaders_KeyExportability;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyExportability != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders.KeyExportability = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyExportability;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyVersion = null;
            if (cmdletContext.KeyBlockHeaders_KeyVersion != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyVersion = cmdletContext.KeyBlockHeaders_KeyVersion;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyVersion != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders.KeyVersion = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_KeyVersion;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
            Dictionary<System.String, System.String> requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_OptionalBlock = null;
            if (cmdletContext.KeyBlockHeaders_OptionalBlock != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_OptionalBlock = cmdletContext.KeyBlockHeaders_OptionalBlock;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_OptionalBlock != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders.OptionalBlocks = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyBlockHeaders_OptionalBlock;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyModesOfUse requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse = null;
            
             // populate KeyModesOfUse
            var requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = true;
            requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse = new Amazon.PaymentCryptography.Model.KeyModesOfUse();
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Decrypt = null;
            if (cmdletContext.KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Decrypt = cmdletContext.KeyModesOfUse_Decrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Decrypt = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Decrypt.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_DeriveKey = null;
            if (cmdletContext.KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_DeriveKey = cmdletContext.KeyModesOfUse_DeriveKey.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.DeriveKey = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_DeriveKey.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Encrypt = null;
            if (cmdletContext.KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Encrypt = cmdletContext.KeyModesOfUse_Encrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Encrypt = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Encrypt.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Generate = null;
            if (cmdletContext.KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Generate = cmdletContext.KeyModesOfUse_Generate.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Generate = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Generate.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_NoRestriction = null;
            if (cmdletContext.KeyModesOfUse_NoRestriction != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_NoRestriction = cmdletContext.KeyModesOfUse_NoRestriction.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_NoRestriction != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.NoRestrictions = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_NoRestriction.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Sign = null;
            if (cmdletContext.KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Sign = cmdletContext.KeyModesOfUse_Sign.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Sign = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Sign.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Unwrap = null;
            if (cmdletContext.KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Unwrap = cmdletContext.KeyModesOfUse_Unwrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Unwrap = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Unwrap.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Verify = null;
            if (cmdletContext.KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Verify = cmdletContext.KeyModesOfUse_Verify.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Verify = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Verify.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Wrap = null;
            if (cmdletContext.KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Wrap = cmdletContext.KeyModesOfUse_Wrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Wrap = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyModesOfUse_Wrap.Value;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse should be set to null
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders.KeyModesOfUse = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_keyMaterial_Tr31KeyBlock_KeyBlockHeaders_KeyModesOfUse;
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders should be set to null
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeadersIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock.KeyBlockHeaders = requestKeyMaterial_keyMaterial_Tr31KeyBlock_keyMaterial_Tr31KeyBlock_KeyBlockHeaders;
                requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr31KeyBlock should be set to null
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock != null)
            {
                request.KeyMaterial.Tr31KeyBlock = requestKeyMaterial_keyMaterial_Tr31KeyBlock;
            }
            Amazon.PaymentCryptography.Model.ExportKeyCryptogram requestKeyMaterial_keyMaterial_KeyCryptogram = null;
            
             // populate KeyCryptogram
            var requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = true;
            requestKeyMaterial_keyMaterial_KeyCryptogram = new Amazon.PaymentCryptography.Model.ExportKeyCryptogram();
            System.String requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier = cmdletContext.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.CertificateAuthorityPublicKeyIdentifier = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate = null;
            if (cmdletContext.KeyCryptogram_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate = cmdletContext.KeyCryptogram_WrappingKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.WrappingKeyCertificate = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
            Amazon.PaymentCryptography.WrappingKeySpec requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec = null;
            if (cmdletContext.KeyCryptogram_WrappingSpec != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec = cmdletContext.KeyCryptogram_WrappingSpec;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.WrappingSpec = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_KeyCryptogram should be set to null
            if (requestKeyMaterial_keyMaterial_KeyCryptogramIsNull)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram = null;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram != null)
            {
                request.KeyMaterial.KeyCryptogram = requestKeyMaterial_keyMaterial_KeyCryptogram;
            }
            Amazon.PaymentCryptography.Model.ExportTr34KeyBlock requestKeyMaterial_keyMaterial_Tr34KeyBlock = null;
            
             // populate Tr34KeyBlock
            var requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_Tr34KeyBlock = new Amazon.PaymentCryptography.Model.ExportTr34KeyBlock();
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier = cmdletContext.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.CertificateAuthorityPublicKeyIdentifier = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken = null;
            if (cmdletContext.Tr34KeyBlock_ExportToken != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken = cmdletContext.Tr34KeyBlock_ExportToken;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.ExportToken = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.Tr34KeyBlockFormat requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat = null;
            if (cmdletContext.Tr34KeyBlock_KeyBlockFormat != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat = cmdletContext.Tr34KeyBlock_KeyBlockFormat;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.KeyBlockFormat = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce = null;
            if (cmdletContext.Tr34KeyBlock_RandomNonce != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce = cmdletContext.Tr34KeyBlock_RandomNonce;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.RandomNonce = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate = null;
            if (cmdletContext.Tr34KeyBlock_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate = cmdletContext.Tr34KeyBlock_WrappingKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.WrappingKeyCertificate = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyBlockHeaders requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders = null;
            
             // populate KeyBlockHeaders
            var requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeadersIsNull = true;
            requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders = new Amazon.PaymentCryptography.Model.KeyBlockHeaders();
            Amazon.PaymentCryptography.KeyExportability requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders.KeyExportability = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeadersIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders.KeyVersion = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeadersIsNull = false;
            }
            Dictionary<System.String, System.String> requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders.OptionalBlocks = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeadersIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyModesOfUse requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse = null;
            
             // populate KeyModesOfUse
            var requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = true;
            requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse = new Amazon.PaymentCryptography.Model.KeyModesOfUse();
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.Decrypt = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.DeriveKey = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.Encrypt = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.Generate = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.NoRestrictions = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.Sign = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.Unwrap = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.Verify = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap = null;
            if (cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap = cmdletContext.KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse.Wrap = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap.Value;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse should be set to null
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders.KeyModesOfUse = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_keyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse;
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeadersIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders should be set to null
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeadersIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.KeyBlockHeaders = requestKeyMaterial_keyMaterial_Tr34KeyBlock_keyMaterial_Tr34KeyBlock_KeyBlockHeaders;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr34KeyBlock should be set to null
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock != null)
            {
                request.KeyMaterial.Tr34KeyBlock = requestKeyMaterial_keyMaterial_Tr34KeyBlock;
            }
            Amazon.PaymentCryptography.Model.ExportDiffieHellmanTr31KeyBlock requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock = null;
            
             // populate DiffieHellmanTr31KeyBlock
            var requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock = new Amazon.PaymentCryptography.Model.ExportDiffieHellmanTr31KeyBlock();
            System.String requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier = cmdletContext.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.CertificateAuthorityPublicKeyIdentifier = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.SymmetricKeyAlgorithm requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm = cmdletContext.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.DeriveKeyAlgorithm = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.KeyDerivationFunction requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationFunction != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction = cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationFunction;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.KeyDerivationFunction = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.KeyDerivationHashAlgorithm requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm = cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.KeyDerivationHashAlgorithm = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier = cmdletContext.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.PrivateKeyIdentifier = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_PublicKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate = cmdletContext.DiffieHellmanTr31KeyBlock_PublicKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.PublicKeyCertificate = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.Model.DiffieHellmanDerivationData requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = null;
            
             // populate DerivationData
            requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = new Amazon.PaymentCryptography.Model.DiffieHellmanDerivationData();
            System.String requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation = null;
            if (cmdletContext.DerivationData_SharedInformation != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation = cmdletContext.DerivationData_SharedInformation;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData.SharedInformation = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.DerivationData = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyBlockHeaders requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders = null;
            
             // populate KeyBlockHeaders
            var requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeadersIsNull = true;
            requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders = new Amazon.PaymentCryptography.Model.KeyBlockHeaders();
            Amazon.PaymentCryptography.KeyExportability requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders.KeyExportability = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders.KeyVersion = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
            Dictionary<System.String, System.String> requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders.OptionalBlocks = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyModesOfUse requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse = null;
            
             // populate KeyModesOfUse
            var requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = true;
            requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse = new Amazon.PaymentCryptography.Model.KeyModesOfUse();
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Decrypt = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.DeriveKey = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Encrypt = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Generate = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.NoRestrictions = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Sign = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Unwrap = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Verify = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap = null;
            if (cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap = cmdletContext.KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse.Wrap = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap.Value;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse should be set to null
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUseIsNull)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse = null;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders.KeyModesOfUse = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeadersIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders should be set to null
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeadersIsNull)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders = null;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.KeyBlockHeaders = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock should be set to null
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock = null;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock != null)
            {
                request.KeyMaterial.DiffieHellmanTr31KeyBlock = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock;
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
        
        private Amazon.PaymentCryptography.Model.ExportKeyResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.ExportKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "ExportKey");
            try
            {
                #if DESKTOP
                return client.ExportKey(request);
                #elif CORECLR
                return client.ExportKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String ExportDukptInitialKey_KeySerialNumber { get; set; }
            public Amazon.PaymentCryptography.KeyCheckValueAlgorithm ExportAttributes_KeyCheckValueAlgorithm { get; set; }
            public System.String ExportKeyIdentifier { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String DerivationData_SharedInformation { get; set; }
            public Amazon.PaymentCryptography.SymmetricKeyAlgorithm DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm { get; set; }
            public Amazon.PaymentCryptography.KeyExportability KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyExportability { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify { get; set; }
            public System.Boolean? KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap { get; set; }
            public System.String KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_KeyVersion { get; set; }
            public Dictionary<System.String, System.String> KeyMaterial_DiffieHellmanTr31KeyBlock_KeyBlockHeaders_OptionalBlocks { get; set; }
            public Amazon.PaymentCryptography.KeyDerivationFunction DiffieHellmanTr31KeyBlock_KeyDerivationFunction { get; set; }
            public Amazon.PaymentCryptography.KeyDerivationHashAlgorithm DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_PublicKeyCertificate { get; set; }
            public System.String KeyCryptogram_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String KeyCryptogram_WrappingKeyCertificate { get; set; }
            public Amazon.PaymentCryptography.WrappingKeySpec KeyCryptogram_WrappingSpec { get; set; }
            public Amazon.PaymentCryptography.KeyExportability KeyBlockHeaders_KeyExportability { get; set; }
            public System.Boolean? KeyModesOfUse_Decrypt { get; set; }
            public System.Boolean? KeyModesOfUse_DeriveKey { get; set; }
            public System.Boolean? KeyModesOfUse_Encrypt { get; set; }
            public System.Boolean? KeyModesOfUse_Generate { get; set; }
            public System.Boolean? KeyModesOfUse_NoRestriction { get; set; }
            public System.Boolean? KeyModesOfUse_Sign { get; set; }
            public System.Boolean? KeyModesOfUse_Unwrap { get; set; }
            public System.Boolean? KeyModesOfUse_Verify { get; set; }
            public System.Boolean? KeyModesOfUse_Wrap { get; set; }
            public System.String KeyBlockHeaders_KeyVersion { get; set; }
            public Dictionary<System.String, System.String> KeyBlockHeaders_OptionalBlock { get; set; }
            public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
            public System.String Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String Tr34KeyBlock_ExportToken { get; set; }
            public Amazon.PaymentCryptography.Tr34KeyBlockFormat Tr34KeyBlock_KeyBlockFormat { get; set; }
            public Amazon.PaymentCryptography.KeyExportability KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyExportability { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Decrypt { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_DeriveKey { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Encrypt { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Generate { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_NoRestrictions { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Sign { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Unwrap { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Verify { get; set; }
            public System.Boolean? KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyModesOfUse_Wrap { get; set; }
            public System.String KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_KeyVersion { get; set; }
            public Dictionary<System.String, System.String> KeyMaterial_Tr34KeyBlock_KeyBlockHeaders_OptionalBlocks { get; set; }
            public System.String Tr34KeyBlock_RandomNonce { get; set; }
            public System.String Tr34KeyBlock_WrappingKeyCertificate { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.ExportKeyResponse, ExportPAYCCKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WrappedKey;
        }
        
    }
}
