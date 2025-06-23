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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Imports symmetric keys and public key certificates in PEM format (base64 encoded)
    /// into Amazon Web Services Payment Cryptography.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services Payment Cryptography simplifies key exchange by replacing the
    /// existing paper-based approach with a modern electronic approach. With <c>ImportKey</c>
    /// you can import symmetric keys using either symmetric and asymmetric key exchange mechanisms.
    /// </para><para>
    /// For symmetric key exchange, Amazon Web Services Payment Cryptography uses the ANSI
    /// X9 TR-31 norm in accordance with PCI PIN guidelines. And for asymmetric key exchange,
    /// Amazon Web Services Payment Cryptography supports ANSI X9 TR-34 norm, RSA unwrap,
    /// and ECDH (Elliptic Curve Diffie-Hellman) key exchange mechanisms. Asymmetric key exchange
    /// methods are typically used to establish bi-directional trust between the two parties
    /// exhanging keys and are used for initial key exchange such as Key Encryption Key (KEK)
    /// or Zone Master Key (ZMK). After which you can import working keys using symmetric
    /// method to perform various cryptographic operations within Amazon Web Services Payment
    /// Cryptography.
    /// </para><para>
    /// PCI requires specific minimum key strength of wrapping keys used to protect the keys
    /// being exchanged electronically. These requirements can change when PCI standards are
    /// revised. The rules specify that wrapping keys used for transport must be at least
    /// as strong as the key being protected. For more information on recommended key strength
    /// of wrapping keys and key exchange mechanism, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-importexport.html">Importing
    /// and exporting keys</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// </para><para>
    /// You can also import a <i>root public key certificate</i>, used to sign other public
    /// key certificates, or a <i>trusted public key certificate</i> under an already established
    /// root public key certificate.
    /// </para><para><b>To import a public root key certificate</b></para><para>
    /// Using this operation, you can import the public component (in PEM cerificate format)
    /// of your private root key. You can use the imported public root key certificate for
    /// digital signatures, for example signing wrapping key or signing key in TR-34, within
    /// your Amazon Web Services Payment Cryptography account.
    /// </para><para>
    /// Set the following parameters:
    /// </para><ul><li><para><c>KeyMaterial</c>: <c>RootCertificatePublicKey</c></para></li><li><para><c>KeyClass</c>: <c>PUBLIC_KEY</c></para></li><li><para><c>KeyModesOfUse</c>: <c>Verify</c></para></li><li><para><c>KeyUsage</c>: <c>TR31_S0_ASYMMETRIC_KEY_FOR_DIGITAL_SIGNATURE</c></para></li><li><para><c>PublicKeyCertificate</c>: The public key certificate in PEM format (base64 encoded)
    /// of the private root key under import.
    /// </para></li></ul><para><b>To import a trusted public key certificate</b></para><para>
    /// The root public key certificate must be in place and operational before you import
    /// a trusted public key certificate. Set the following parameters:
    /// </para><ul><li><para><c>KeyMaterial</c>: <c>TrustedCertificatePublicKey</c></para></li><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: <c>KeyArn</c> of the <c>RootCertificatePublicKey</c>.
    /// </para></li><li><para><c>KeyModesOfUse</c> and <c>KeyUsage</c>: Corresponding to the cryptographic operations
    /// such as wrap, sign, or encrypt that you will allow the trusted public key certificate
    /// to perform.
    /// </para></li><li><para><c>PublicKeyCertificate</c>: The trusted public key certificate in PEM format (base64
    /// encoded) under import.
    /// </para></li></ul><para><b>To import initial keys (KEK or ZMK or similar) using TR-34</b></para><para>
    /// Using this operation, you can import initial key using TR-34 asymmetric key exchange.
    /// In TR-34 terminology, the sending party of the key is called Key Distribution Host
    /// (KDH) and the receiving party of the key is called Key Receiving Device (KRD). During
    /// the key import process, KDH is the user who initiates the key import and KRD is Amazon
    /// Web Services Payment Cryptography who receives the key.
    /// </para><para>
    /// To initiate TR-34 key import, the KDH must obtain an import token by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForImport.html">GetParametersForImport</a>.
    /// This operation generates an encryption keypair for the purpose of key import, signs
    /// the key and returns back the wrapping key certificate (also known as KRD wrapping
    /// certificate) and the root certificate chain. The KDH must trust and install the KRD
    /// wrapping certificate on its HSM and use it to encrypt (wrap) the KDH key during TR-34
    /// WrappedKeyBlock generation. The import token and associated KRD wrapping certificate
    /// expires after 30 days.
    /// </para><para>
    /// Next the KDH generates a key pair for the purpose of signing the encrypted KDH key
    /// and provides the public certificate of the signing key to Amazon Web Services Payment
    /// Cryptography. The KDH will also need to import the root certificate chain of the KDH
    /// signing certificate by calling <c>ImportKey</c> for <c>RootCertificatePublicKey</c>.
    /// For more information on TR-34 key import, see section <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-import.html">Importing
    /// symmetric keys</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// </para><para>
    /// Set the following parameters:
    /// </para><ul><li><para><c>KeyMaterial</c>: Use <c>Tr34KeyBlock</c> parameters.
    /// </para></li><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: The <c>KeyARN</c> of the certificate
    /// chain that signed the KDH signing key certificate.
    /// </para></li><li><para><c>ImportToken</c>: Obtained from KRD by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForImport.html">GetParametersForImport</a>.
    /// </para></li><li><para><c>WrappedKeyBlock</c>: The TR-34 wrapped key material from KDH. It contains the
    /// KDH key under import, wrapped with KRD wrapping certificate and signed by KDH signing
    /// private key. This TR-34 key block is typically generated by the KDH Hardware Security
    /// Module (HSM) outside of Amazon Web Services Payment Cryptography.
    /// </para></li><li><para><c>SigningKeyCertificate</c>: The public key certificate in PEM format (base64 encoded)
    /// of the KDH signing key generated under the root certificate (CertificateAuthorityPublicKeyIdentifier)
    /// imported in Amazon Web Services Payment Cryptography.
    /// </para></li></ul><para><b>To import initial keys (KEK or ZMK or similar) using RSA Wrap and Unwrap</b></para><para>
    /// Using this operation, you can import initial key using asymmetric RSA wrap and unwrap
    /// key exchange method. To initiate import, call <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForImport.html">GetParametersForImport</a>
    /// with <c>KeyMaterial</c> set to <c>KEY_CRYPTOGRAM</c> to generate an import token.
    /// This operation also generates an encryption keypair for the purpose of key import,
    /// signs the key and returns back the wrapping key certificate in PEM format (base64
    /// encoded) and its root certificate chain. The import token and associated KRD wrapping
    /// certificate expires after 30 days. 
    /// </para><para>
    /// You must trust and install the wrapping certificate and its certificate chain on the
    /// sending HSM and use it to wrap the key under export for WrappedKeyCryptogram generation.
    /// Next call <c>ImportKey</c> with <c>KeyMaterial</c> set to <c>KEY_CRYPTOGRAM</c> and
    /// provide the <c>ImportToken</c> and <c>KeyAttributes</c> for the key under import.
    /// </para><para><b>To import working keys using TR-31</b></para><para>
    /// Amazon Web Services Payment Cryptography uses TR-31 symmetric key exchange norm to
    /// import working keys. A KEK must be established within Amazon Web Services Payment
    /// Cryptography by using TR-34 key import or by using <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>.
    /// To initiate a TR-31 key import, set the following parameters:
    /// </para><ul><li><para><c>KeyMaterial</c>: Use <c>Tr31KeyBlock</c> parameters.
    /// </para></li><li><para><c>WrappedKeyBlock</c>: The TR-31 wrapped key material. It contains the key under
    /// import, encrypted using KEK. The TR-31 key block is typically generated by a HSM outside
    /// of Amazon Web Services Payment Cryptography. 
    /// </para></li><li><para><c>WrappingKeyIdentifier</c>: The <c>KeyArn</c> of the KEK that Amazon Web Services
    /// Payment Cryptography uses to decrypt or unwrap the key under import.
    /// </para></li></ul><para><b>To import working keys using ECDH</b></para><para>
    /// You can also use ECDH key agreement to import working keys as a TR-31 keyblock, where
    /// the wrapping key is an ECDH derived key.
    /// </para><para>
    /// To initiate a TR-31 key import using ECDH, both sides must create an ECC key pair
    /// with key usage K3 and exchange public key certificates. In Amazon Web Services Payment
    /// Cryptography, you can do this by calling <c>CreateKey</c> and then <c>GetPublicKeyCertificate</c>
    /// to retrieve its public key certificate. Next, you can then generate a TR-31 WrappedKeyBlock
    /// using your own ECC key pair, the public certificate of the service's ECC key pair,
    /// and the key derivation parameters including key derivation function, hash algorithm,
    /// derivation data, and key algorithm. If you have not already done so, you must import
    /// the CA chain that issued the receiving public key certificate by calling <c>ImportKey</c>
    /// with input <c>RootCertificatePublicKey</c> for root CA or <c>TrustedPublicKey</c>
    /// for intermediate CA. To complete the TR-31 key import, you can use the following parameters.
    /// It is important that the ECDH key derivation parameters you use should match those
    /// used during import to derive the same shared wrapping key within Amazon Web Services
    /// Payment Cryptography.
    /// </para><ul><li><para><c>KeyMaterial</c>: Use <c>DiffieHellmanTr31KeyBlock</c> parameters.
    /// </para></li><li><para><c>PrivateKeyIdentifier</c>: The <c>KeyArn</c> of the ECC key pair created within
    /// Amazon Web Services Payment Cryptography to derive a shared KEK.
    /// </para></li><li><para><c>PublicKeyCertificate</c>: The public key certificate of the receiving ECC key
    /// pair in PEM format (base64 encoded) to derive a shared KEK.
    /// </para></li><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: The <c>keyARN</c> of the CA that
    /// signed the public key certificate of the receiving ECC key pair.
    /// </para></li></ul><para><b>Cross-account use:</b> This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ExportKey.html">ExportKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetParametersForImport.html">GetParametersForImport</a></para></li></ul>
    /// </summary>
    [Cmdlet("Import", "PAYCCKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptography.Model.Key")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane ImportKey API operation.", Operation = new[] {"ImportKey"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.ImportKeyResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptography.Model.Key or Amazon.PaymentCryptography.Model.ImportKeyResponse",
        "This cmdlet returns an Amazon.PaymentCryptography.Model.Key object.",
        "The service call response (type Amazon.PaymentCryptography.Model.ImportKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportPAYCCKeyCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the certificate chain that signs the signing key certificate
        /// during TR-34 key import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier")]
        public System.String Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the root public key certificate or certificate chain that signs
        /// the trusted public key certificate import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier")]
        public System.String TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to decrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to decrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Decrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to decrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt")]
        public System.Boolean? KeyModesOfUse_Decrypt { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to derive
        /// new keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to derive
        /// new keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_DeriveKey
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to derive
        /// new keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey")]
        public System.Boolean? KeyModesOfUse_DeriveKey { get; set; }
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
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether import key is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to encrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to encrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Encrypt
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to encrypt
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt")]
        public System.Boolean? KeyModesOfUse_Encrypt { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_Exportable
        /// <summary>
        /// <para>
        /// <para>Specifies whether the key is exportable from the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_Exportable")]
        public System.Boolean? KeyCryptogram_Exportable { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to generate
        /// and verify other card and PIN verification keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to generate
        /// and verify other card and PIN verification keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Generate
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to generate
        /// and verify other card and PIN verification keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate")]
        public System.Boolean? KeyModesOfUse_Generate { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_ImportToken
        /// <summary>
        /// <para>
        /// <para>The import token that initiates key import using the asymmetric RSA wrap and unwrap
        /// key exchange method into AWS Payment Cryptography. It expires after 30 days. You can
        /// use the same import token to import multiple keys to the same service account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_ImportToken")]
        public System.String KeyCryptogram_ImportToken { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_ImportToken
        /// <summary>
        /// <para>
        /// <para>The import token that initiates key import using the asymmetric TR-34 key exchange
        /// method into Amazon Web Services Payment Cryptography. It expires after 30 days. You
        /// can use the same import token to import multiple keys to the same service account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_ImportToken")]
        public System.String Tr34KeyBlock_ImportToken { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithm to be use during creation of an Amazon Web Services Payment Cryptography
        /// key.</para><para>For symmetric keys, Amazon Web Services Payment Cryptography supports <c>AES</c> and
        /// <c>TDES</c> algorithms. For asymmetric keys, Amazon Web Services Payment Cryptography
        /// supports <c>RSA</c> and <c>ECC_NIST</c> algorithms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyAlgorithm")]
        public Amazon.PaymentCryptography.KeyAlgorithm KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithm to be use during creation of an Amazon Web Services Payment Cryptography
        /// key.</para><para>For symmetric keys, Amazon Web Services Payment Cryptography supports <c>AES</c> and
        /// <c>TDES</c> algorithms. For asymmetric keys, Amazon Web Services Payment Cryptography
        /// supports <c>RSA</c> and <c>ECC_NIST</c> algorithms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyAlgorithm")]
        public Amazon.PaymentCryptography.KeyAlgorithm KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyAlgorithm")]
        public Amazon.PaymentCryptography.KeyAlgorithm KeyAttributes_KeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_KeyBlockFormat
        /// <summary>
        /// <para>
        /// <para>The key block format to use during key import. The only value allowed is <c>X9_TR34_2012</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_KeyBlockFormat")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.Tr34KeyBlockFormat")]
        public Amazon.PaymentCryptography.Tr34KeyBlockFormat Tr34KeyBlock_KeyBlockFormat { get; set; }
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
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services Payment Cryptography key to create, which determines
        /// the classiﬁcation of the cryptographic method and whether Amazon Web Services Payment
        /// Cryptography key contains a symmetric key or an asymmetric key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyClass")]
        public Amazon.PaymentCryptography.KeyClass KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services Payment Cryptography key to create, which determines
        /// the classiﬁcation of the cryptographic method and whether Amazon Web Services Payment
        /// Cryptography key contains a symmetric key or an asymmetric key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyClass")]
        public Amazon.PaymentCryptography.KeyClass KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass { get; set; }
        #endregion
        
        #region Parameter KeyAttributes_KeyClass
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services Payment Cryptography key to create, which determines
        /// the classiﬁcation of the cryptographic method and whether Amazon Web Services Payment
        /// Cryptography key contains a symmetric key or an asymmetric key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyClass")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyClass")]
        public Amazon.PaymentCryptography.KeyClass KeyAttributes_KeyClass { get; set; }
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
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage
        /// <summary>
        /// <para>
        /// <para>The cryptographic usage of an Amazon Web Services Payment Cryptography key as deﬁned
        /// in section A.5.2 of the TR-31 spec.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyUsage")]
        public Amazon.PaymentCryptography.KeyUsage KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage
        /// <summary>
        /// <para>
        /// <para>The cryptographic usage of an Amazon Web Services Payment Cryptography key as deﬁned
        /// in section A.5.2 of the TR-31 spec.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyUsage")]
        public Amazon.PaymentCryptography.KeyUsage KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage { get; set; }
        #endregion
        
        #region Parameter KeyAttributes_KeyUsage
        /// <summary>
        /// <para>
        /// <para>The cryptographic usage of an Amazon Web Services Payment Cryptography key as deﬁned
        /// in section A.5.2 of the TR-31 spec.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyUsage")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyUsage")]
        public Amazon.PaymentCryptography.KeyUsage KeyAttributes_KeyUsage { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key has no special restrictions
        /// other than the restrictions implied by <c>KeyUsage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key has no special restrictions
        /// other than the restrictions implied by <c>KeyUsage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_NoRestriction
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key has no special restrictions
        /// other than the restrictions implied by <c>KeyUsage</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions")]
        public System.Boolean? KeyModesOfUse_NoRestriction { get; set; }
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
        
        #region Parameter RootCertificatePublicKey_PublicKeyCertificate
        /// <summary>
        /// <para>
        /// <para>Parameter information for root public key certificate import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_RootCertificatePublicKey_PublicKeyCertificate")]
        public System.String RootCertificatePublicKey_PublicKeyCertificate { get; set; }
        #endregion
        
        #region Parameter TrustedCertificatePublicKey_PublicKeyCertificate
        /// <summary>
        /// <para>
        /// <para>Parameter information for trusted public key certificate import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_PublicKeyCertificate")]
        public System.String TrustedCertificatePublicKey_PublicKeyCertificate { get; set; }
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
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used for signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used for signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Sign
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used for signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign")]
        public System.Boolean? KeyModesOfUse_Sign { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_SigningKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The public key component in PEM certificate format of the private key that signs the
        /// KDH TR-34 WrappedKeyBlock.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_SigningKeyCertificate")]
        public System.String Tr34KeyBlock_SigningKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags to the Amazon Web Services Payment Cryptography key. Use
        /// this parameter to tag a key when it is imported. To tag an existing Amazon Web Services
        /// Payment Cryptography key, use the <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_TagResource.html">TagResource</a>
        /// operation.</para><para>Each tag consists of a tag key and a tag value. Both the tag key and the tag value
        /// are required, but the tag value can be an empty (null) string. You can't have more
        /// than one tag on an Amazon Web Services Payment Cryptography key with the same tag
        /// key. If you specify an existing tag key with a different tag value, Amazon Web Services
        /// Payment Cryptography replaces the current tag value with the specified one.</para><important><para>Don't include personal, confidential or sensitive information in this field. This
        /// field may be displayed in plaintext in CloudTrail logs and other output.</para></important><note><para>Tagging or untagging an Amazon Web Services Payment Cryptography key can allow or
        /// deny permission to the key.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.PaymentCryptography.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to unwrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to unwrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Unwrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to unwrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap")]
        public System.Boolean? KeyModesOfUse_Unwrap { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to verify
        /// signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to verify
        /// signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Verify
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to verify
        /// signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify")]
        public System.Boolean? KeyModesOfUse_Verify { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to wrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap { get; set; }
        #endregion
        
        #region Parameter KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to wrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap { get; set; }
        #endregion
        
        #region Parameter KeyModesOfUse_Wrap
        /// <summary>
        /// <para>
        /// <para>Speciﬁes whether an Amazon Web Services Payment Cryptography key can be used to wrap
        /// other keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap")]
        public System.Boolean? KeyModesOfUse_Wrap { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_WrappedKeyBlock
        /// <summary>
        /// <para>
        /// <para>The ECDH wrapped key block to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_DiffieHellmanTr31KeyBlock_WrappedKeyBlock")]
        public System.String DiffieHellmanTr31KeyBlock_WrappedKeyBlock { get; set; }
        #endregion
        
        #region Parameter Tr31KeyBlock_WrappedKeyBlock
        /// <summary>
        /// <para>
        /// <para>The TR-31 wrapped key block to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_WrappedKeyBlock")]
        public System.String Tr31KeyBlock_WrappedKeyBlock { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_WrappedKeyBlock
        /// <summary>
        /// <para>
        /// <para>The TR-34 wrapped key block to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_WrappedKeyBlock")]
        public System.String Tr34KeyBlock_WrappedKeyBlock { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_WrappedKeyCryptogram
        /// <summary>
        /// <para>
        /// <para>The RSA wrapped key cryptogram under import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_WrappedKeyCryptogram")]
        public System.String KeyCryptogram_WrappedKeyCryptogram { get; set; }
        #endregion
        
        #region Parameter Tr31KeyBlock_WrappingKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the key that will decrypt or unwrap a TR-31 key block during
        /// import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_WrappingKeyIdentifier")]
        public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_WrappingSpec
        /// <summary>
        /// <para>
        /// <para>The wrapping spec for the wrapped key cryptogram.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_WrappingSpec")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.WrappingKeySpec")]
        public Amazon.PaymentCryptography.WrappingKeySpec KeyCryptogram_WrappingSpec { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Key'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.ImportKeyResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.ImportKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Key";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-PAYCCKey (ImportKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.ImportKeyResponse, ImportPAYCCKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enabled = this.Enabled;
            context.KeyCheckValueAlgorithm = this.KeyCheckValueAlgorithm;
            context.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier = this.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            context.DerivationData_SharedInformation = this.DerivationData_SharedInformation;
            context.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm = this.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm;
            context.DiffieHellmanTr31KeyBlock_KeyDerivationFunction = this.DiffieHellmanTr31KeyBlock_KeyDerivationFunction;
            context.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm = this.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm;
            context.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier = this.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier;
            context.DiffieHellmanTr31KeyBlock_PublicKeyCertificate = this.DiffieHellmanTr31KeyBlock_PublicKeyCertificate;
            context.DiffieHellmanTr31KeyBlock_WrappedKeyBlock = this.DiffieHellmanTr31KeyBlock_WrappedKeyBlock;
            context.KeyCryptogram_Exportable = this.KeyCryptogram_Exportable;
            context.KeyCryptogram_ImportToken = this.KeyCryptogram_ImportToken;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap;
            context.KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage = this.KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage;
            context.KeyCryptogram_WrappedKeyCryptogram = this.KeyCryptogram_WrappedKeyCryptogram;
            context.KeyCryptogram_WrappingSpec = this.KeyCryptogram_WrappingSpec;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap;
            context.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage = this.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage;
            context.RootCertificatePublicKey_PublicKeyCertificate = this.RootCertificatePublicKey_PublicKeyCertificate;
            context.Tr31KeyBlock_WrappedKeyBlock = this.Tr31KeyBlock_WrappedKeyBlock;
            context.Tr31KeyBlock_WrappingKeyIdentifier = this.Tr31KeyBlock_WrappingKeyIdentifier;
            context.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier = this.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            context.Tr34KeyBlock_ImportToken = this.Tr34KeyBlock_ImportToken;
            context.Tr34KeyBlock_KeyBlockFormat = this.Tr34KeyBlock_KeyBlockFormat;
            context.Tr34KeyBlock_RandomNonce = this.Tr34KeyBlock_RandomNonce;
            context.Tr34KeyBlock_SigningKeyCertificate = this.Tr34KeyBlock_SigningKeyCertificate;
            context.Tr34KeyBlock_WrappedKeyBlock = this.Tr34KeyBlock_WrappedKeyBlock;
            context.TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier = this.TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier;
            context.KeyAttributes_KeyAlgorithm = this.KeyAttributes_KeyAlgorithm;
            context.KeyAttributes_KeyClass = this.KeyAttributes_KeyClass;
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
            context.TrustedCertificatePublicKey_PublicKeyCertificate = this.TrustedCertificatePublicKey_PublicKeyCertificate;
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
            var request = new Amazon.PaymentCryptography.Model.ImportKeyRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.KeyCheckValueAlgorithm != null)
            {
                request.KeyCheckValueAlgorithm = cmdletContext.KeyCheckValueAlgorithm;
            }
            
             // populate KeyMaterial
            var requestKeyMaterialIsNull = true;
            request.KeyMaterial = new Amazon.PaymentCryptography.Model.ImportKeyMaterial();
            Amazon.PaymentCryptography.Model.RootCertificatePublicKey requestKeyMaterial_keyMaterial_RootCertificatePublicKey = null;
            
             // populate RootCertificatePublicKey
            var requestKeyMaterial_keyMaterial_RootCertificatePublicKeyIsNull = true;
            requestKeyMaterial_keyMaterial_RootCertificatePublicKey = new Amazon.PaymentCryptography.Model.RootCertificatePublicKey();
            System.String requestKeyMaterial_keyMaterial_RootCertificatePublicKey_rootCertificatePublicKey_PublicKeyCertificate = null;
            if (cmdletContext.RootCertificatePublicKey_PublicKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_rootCertificatePublicKey_PublicKeyCertificate = cmdletContext.RootCertificatePublicKey_PublicKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_rootCertificatePublicKey_PublicKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey.PublicKeyCertificate = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_rootCertificatePublicKey_PublicKeyCertificate;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKeyIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyAttributes requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes = null;
            
             // populate KeyAttributes
            var requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributesIsNull = true;
            requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes = new Amazon.PaymentCryptography.Model.KeyAttributes();
            Amazon.PaymentCryptography.KeyAlgorithm requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes.KeyAlgorithm = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyClass requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes.KeyClass = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyUsage requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes.KeyUsage = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyModesOfUse requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse = null;
            
             // populate KeyModesOfUse
            var requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = true;
            requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse = new Amazon.PaymentCryptography.Model.KeyModesOfUse();
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.Decrypt = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.DeriveKey = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.Encrypt = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.Generate = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.NoRestrictions = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.Sign = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.Unwrap = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.Verify = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap = null;
            if (cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap = cmdletContext.KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse.Wrap = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap.Value;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse should be set to null
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse = null;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes.KeyModesOfUse = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes_keyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributesIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes should be set to null
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributesIsNull)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes = null;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes != null)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey.KeyAttributes = requestKeyMaterial_keyMaterial_RootCertificatePublicKey_keyMaterial_RootCertificatePublicKey_KeyAttributes;
                requestKeyMaterial_keyMaterial_RootCertificatePublicKeyIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_RootCertificatePublicKey should be set to null
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKeyIsNull)
            {
                requestKeyMaterial_keyMaterial_RootCertificatePublicKey = null;
            }
            if (requestKeyMaterial_keyMaterial_RootCertificatePublicKey != null)
            {
                request.KeyMaterial.RootCertificatePublicKey = requestKeyMaterial_keyMaterial_RootCertificatePublicKey;
                requestKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptography.Model.ImportTr31KeyBlock requestKeyMaterial_keyMaterial_Tr31KeyBlock = null;
            
             // populate Tr31KeyBlock
            var requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_Tr31KeyBlock = new Amazon.PaymentCryptography.Model.ImportTr31KeyBlock();
            System.String requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappedKeyBlock = null;
            if (cmdletContext.Tr31KeyBlock_WrappedKeyBlock != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappedKeyBlock = cmdletContext.Tr31KeyBlock_WrappedKeyBlock;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappedKeyBlock != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock.WrappedKeyBlock = requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappedKeyBlock;
                requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull = false;
            }
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
             // determine if requestKeyMaterial_keyMaterial_Tr31KeyBlock should be set to null
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock != null)
            {
                request.KeyMaterial.Tr31KeyBlock = requestKeyMaterial_keyMaterial_Tr31KeyBlock;
                requestKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptography.Model.TrustedCertificatePublicKey requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey = null;
            
             // populate TrustedCertificatePublicKey
            var requestKeyMaterial_keyMaterial_TrustedCertificatePublicKeyIsNull = true;
            requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey = new Amazon.PaymentCryptography.Model.TrustedCertificatePublicKey();
            System.String requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier = cmdletContext.TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey.CertificateAuthorityPublicKeyIdentifier = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKeyIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_PublicKeyCertificate = null;
            if (cmdletContext.TrustedCertificatePublicKey_PublicKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_PublicKeyCertificate = cmdletContext.TrustedCertificatePublicKey_PublicKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_PublicKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey.PublicKeyCertificate = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_trustedCertificatePublicKey_PublicKeyCertificate;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKeyIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyAttributes requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes = null;
            
             // populate KeyAttributes
            var requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributesIsNull = true;
            requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes = new Amazon.PaymentCryptography.Model.KeyAttributes();
            Amazon.PaymentCryptography.KeyAlgorithm requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyAlgorithm = null;
            if (cmdletContext.KeyAttributes_KeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyAlgorithm = cmdletContext.KeyAttributes_KeyAlgorithm;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes.KeyAlgorithm = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyAlgorithm;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyClass requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyClass = null;
            if (cmdletContext.KeyAttributes_KeyClass != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyClass = cmdletContext.KeyAttributes_KeyClass;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyClass != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes.KeyClass = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyClass;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyUsage requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyUsage = null;
            if (cmdletContext.KeyAttributes_KeyUsage != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyUsage = cmdletContext.KeyAttributes_KeyUsage;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyUsage != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes.KeyUsage = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyAttributes_KeyUsage;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyModesOfUse requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse = null;
            
             // populate KeyModesOfUse
            var requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = true;
            requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse = new Amazon.PaymentCryptography.Model.KeyModesOfUse();
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt = null;
            if (cmdletContext.KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt = cmdletContext.KeyModesOfUse_Decrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.Decrypt = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Decrypt.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey = null;
            if (cmdletContext.KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey = cmdletContext.KeyModesOfUse_DeriveKey.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.DeriveKey = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_DeriveKey.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt = null;
            if (cmdletContext.KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt = cmdletContext.KeyModesOfUse_Encrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.Encrypt = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Encrypt.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Generate = null;
            if (cmdletContext.KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Generate = cmdletContext.KeyModesOfUse_Generate.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.Generate = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Generate.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction = null;
            if (cmdletContext.KeyModesOfUse_NoRestriction != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction = cmdletContext.KeyModesOfUse_NoRestriction.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.NoRestrictions = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_NoRestriction.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Sign = null;
            if (cmdletContext.KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Sign = cmdletContext.KeyModesOfUse_Sign.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.Sign = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Sign.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap = null;
            if (cmdletContext.KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap = cmdletContext.KeyModesOfUse_Unwrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.Unwrap = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Unwrap.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Verify = null;
            if (cmdletContext.KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Verify = cmdletContext.KeyModesOfUse_Verify.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.Verify = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Verify.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Wrap = null;
            if (cmdletContext.KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Wrap = cmdletContext.KeyModesOfUse_Wrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse.Wrap = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse_keyModesOfUse_Wrap.Value;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse should be set to null
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUseIsNull)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse = null;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes.KeyModesOfUse = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_keyMaterial_TrustedCertificatePublicKey_KeyAttributes_KeyModesOfUse;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributesIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes should be set to null
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributesIsNull)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes = null;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes != null)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey.KeyAttributes = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey_keyMaterial_TrustedCertificatePublicKey_KeyAttributes;
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKeyIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey should be set to null
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKeyIsNull)
            {
                requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey = null;
            }
            if (requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey != null)
            {
                request.KeyMaterial.TrustedCertificatePublicKey = requestKeyMaterial_keyMaterial_TrustedCertificatePublicKey;
                requestKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptography.Model.ImportKeyCryptogram requestKeyMaterial_keyMaterial_KeyCryptogram = null;
            
             // populate KeyCryptogram
            var requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = true;
            requestKeyMaterial_keyMaterial_KeyCryptogram = new Amazon.PaymentCryptography.Model.ImportKeyCryptogram();
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_Exportable = null;
            if (cmdletContext.KeyCryptogram_Exportable != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_Exportable = cmdletContext.KeyCryptogram_Exportable.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_Exportable != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.Exportable = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_Exportable.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_ImportToken = null;
            if (cmdletContext.KeyCryptogram_ImportToken != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_ImportToken = cmdletContext.KeyCryptogram_ImportToken;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_ImportToken != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.ImportToken = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_ImportToken;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappedKeyCryptogram = null;
            if (cmdletContext.KeyCryptogram_WrappedKeyCryptogram != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappedKeyCryptogram = cmdletContext.KeyCryptogram_WrappedKeyCryptogram;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappedKeyCryptogram != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.WrappedKeyCryptogram = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappedKeyCryptogram;
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
            Amazon.PaymentCryptography.Model.KeyAttributes requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes = null;
            
             // populate KeyAttributes
            var requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributesIsNull = true;
            requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes = new Amazon.PaymentCryptography.Model.KeyAttributes();
            Amazon.PaymentCryptography.KeyAlgorithm requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes.KeyAlgorithm = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyClass requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyClass = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyClass = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyClass != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes.KeyClass = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyClass;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.KeyUsage requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyUsage = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyUsage = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyUsage != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes.KeyUsage = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyUsage;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.Model.KeyModesOfUse requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse = null;
            
             // populate KeyModesOfUse
            var requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = true;
            requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse = new Amazon.PaymentCryptography.Model.KeyModesOfUse();
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.Decrypt = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.DeriveKey = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.Encrypt = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.Generate = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.NoRestrictions = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.Sign = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.Unwrap = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.Verify = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
            System.Boolean? requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap = null;
            if (cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap = cmdletContext.KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap.Value;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse.Wrap = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap.Value;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse should be set to null
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUseIsNull)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse = null;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes.KeyModesOfUse = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes_keyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse;
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributesIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes should be set to null
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributesIsNull)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes = null;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.KeyAttributes = requestKeyMaterial_keyMaterial_KeyCryptogram_keyMaterial_KeyCryptogram_KeyAttributes;
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
                requestKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptography.Model.ImportTr34KeyBlock requestKeyMaterial_keyMaterial_Tr34KeyBlock = null;
            
             // populate Tr34KeyBlock
            var requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_Tr34KeyBlock = new Amazon.PaymentCryptography.Model.ImportTr34KeyBlock();
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
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ImportToken = null;
            if (cmdletContext.Tr34KeyBlock_ImportToken != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ImportToken = cmdletContext.Tr34KeyBlock_ImportToken;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ImportToken != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.ImportToken = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ImportToken;
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
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_SigningKeyCertificate = null;
            if (cmdletContext.Tr34KeyBlock_SigningKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_SigningKeyCertificate = cmdletContext.Tr34KeyBlock_SigningKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_SigningKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.SigningKeyCertificate = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_SigningKeyCertificate;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappedKeyBlock = null;
            if (cmdletContext.Tr34KeyBlock_WrappedKeyBlock != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappedKeyBlock = cmdletContext.Tr34KeyBlock_WrappedKeyBlock;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappedKeyBlock != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.WrappedKeyBlock = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappedKeyBlock;
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
                requestKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptography.Model.ImportDiffieHellmanTr31KeyBlock requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock = null;
            
             // populate DiffieHellmanTr31KeyBlock
            var requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock = new Amazon.PaymentCryptography.Model.ImportDiffieHellmanTr31KeyBlock();
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
            System.String requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_WrappedKeyBlock != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock = cmdletContext.DiffieHellmanTr31KeyBlock_WrappedKeyBlock;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.WrappedKeyBlock = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.Model.DiffieHellmanDerivationData requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = null;
            
             // populate DerivationData
            var requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationDataIsNull = true;
            requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = new Amazon.PaymentCryptography.Model.DiffieHellmanDerivationData();
            System.String requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation = null;
            if (cmdletContext.DerivationData_SharedInformation != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation = cmdletContext.DerivationData_SharedInformation;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData.SharedInformation = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation;
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationDataIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData should be set to null
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationDataIsNull)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = null;
            }
            if (requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData != null)
            {
                requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock.DerivationData = requestKeyMaterial_keyMaterial_DiffieHellmanTr31KeyBlock_keyMaterial_DiffieHellmanTr31KeyBlock_DerivationData;
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
                requestKeyMaterialIsNull = false;
            }
             // determine if request.KeyMaterial should be set to null
            if (requestKeyMaterialIsNull)
            {
                request.KeyMaterial = null;
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
        
        private Amazon.PaymentCryptography.Model.ImportKeyResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.ImportKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "ImportKey");
            try
            {
                return client.ImportKeyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public Amazon.PaymentCryptography.KeyCheckValueAlgorithm KeyCheckValueAlgorithm { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String DerivationData_SharedInformation { get; set; }
            public Amazon.PaymentCryptography.SymmetricKeyAlgorithm DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm { get; set; }
            public Amazon.PaymentCryptography.KeyDerivationFunction DiffieHellmanTr31KeyBlock_KeyDerivationFunction { get; set; }
            public Amazon.PaymentCryptography.KeyDerivationHashAlgorithm DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_PublicKeyCertificate { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_WrappedKeyBlock { get; set; }
            public System.Boolean? KeyCryptogram_Exportable { get; set; }
            public System.String KeyCryptogram_ImportToken { get; set; }
            public Amazon.PaymentCryptography.KeyAlgorithm KeyMaterial_KeyCryptogram_KeyAttributes_KeyAlgorithm { get; set; }
            public Amazon.PaymentCryptography.KeyClass KeyMaterial_KeyCryptogram_KeyAttributes_KeyClass { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Decrypt { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_DeriveKey { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Encrypt { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Generate { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_NoRestrictions { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Sign { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Unwrap { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Verify { get; set; }
            public System.Boolean? KeyMaterial_KeyCryptogram_KeyAttributes_KeyModesOfUse_Wrap { get; set; }
            public Amazon.PaymentCryptography.KeyUsage KeyMaterial_KeyCryptogram_KeyAttributes_KeyUsage { get; set; }
            public System.String KeyCryptogram_WrappedKeyCryptogram { get; set; }
            public Amazon.PaymentCryptography.WrappingKeySpec KeyCryptogram_WrappingSpec { get; set; }
            public Amazon.PaymentCryptography.KeyAlgorithm KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyAlgorithm { get; set; }
            public Amazon.PaymentCryptography.KeyClass KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyClass { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Decrypt { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_DeriveKey { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Encrypt { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Generate { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_NoRestrictions { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Sign { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Unwrap { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Verify { get; set; }
            public System.Boolean? KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyModesOfUse_Wrap { get; set; }
            public Amazon.PaymentCryptography.KeyUsage KeyMaterial_RootCertificatePublicKey_KeyAttributes_KeyUsage { get; set; }
            public System.String RootCertificatePublicKey_PublicKeyCertificate { get; set; }
            public System.String Tr31KeyBlock_WrappedKeyBlock { get; set; }
            public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
            public System.String Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String Tr34KeyBlock_ImportToken { get; set; }
            public Amazon.PaymentCryptography.Tr34KeyBlockFormat Tr34KeyBlock_KeyBlockFormat { get; set; }
            public System.String Tr34KeyBlock_RandomNonce { get; set; }
            public System.String Tr34KeyBlock_SigningKeyCertificate { get; set; }
            public System.String Tr34KeyBlock_WrappedKeyBlock { get; set; }
            public System.String TrustedCertificatePublicKey_CertificateAuthorityPublicKeyIdentifier { get; set; }
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
            public System.String TrustedCertificatePublicKey_PublicKeyCertificate { get; set; }
            public List<Amazon.PaymentCryptography.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.ImportKeyResponse, ImportPAYCCKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Key;
        }
        
    }
}
