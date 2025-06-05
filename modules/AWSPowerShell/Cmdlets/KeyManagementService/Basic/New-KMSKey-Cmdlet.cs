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
    /// Creates a unique customer managed <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#kms-keys">KMS
    /// key</a> in your Amazon Web Services account and Region. You can use a KMS key in cryptographic
    /// operations, such as encryption and signing. Some Amazon Web Services services let
    /// you use KMS keys that you create and manage to protect your service resources.
    /// 
    ///  
    /// <para>
    /// A KMS key is a logical representation of a cryptographic key. In addition to the key
    /// material used in cryptographic operations, a KMS key includes metadata, such as the
    /// key ID, key policy, creation date, description, and key state. 
    /// </para><para>
    /// Use the parameters of <c>CreateKey</c> to specify the type of KMS key, the source
    /// of its key material, its key policy, description, tags, and other properties.
    /// </para><note><para>
    /// KMS has replaced the term <i>customer master key (CMK)</i> with <i>KMS key</i> and
    /// <i>KMS key</i>. The concept has not changed. To prevent breaking changes, KMS is keeping
    /// some variations of this term.
    /// </para></note><para>
    /// To create different types of KMS keys, use the following guidance:
    /// </para><dl><dt>Symmetric encryption KMS key</dt><dd><para>
    /// By default, <c>CreateKey</c> creates a symmetric encryption KMS key with key material
    /// that KMS generates. This is the basic and most widely used type of KMS key, and provides
    /// the best performance.
    /// </para><para>
    /// To create a symmetric encryption KMS key, you don't need to specify any parameters.
    /// The default value for <c>KeySpec</c>, <c>SYMMETRIC_DEFAULT</c>, the default value
    /// for <c>KeyUsage</c>, <c>ENCRYPT_DECRYPT</c>, and the default value for <c>Origin</c>,
    /// <c>AWS_KMS</c>, create a symmetric encryption KMS key with KMS key material.
    /// </para><para>
    /// If you need a key for basic encryption and decryption or you are creating a KMS key
    /// to protect your resources in an Amazon Web Services service, create a symmetric encryption
    /// KMS key. The key material in a symmetric encryption key never leaves KMS unencrypted.
    /// You can use a symmetric encryption KMS key to encrypt and decrypt data up to 4,096
    /// bytes, but they are typically used to generate data keys and data keys pairs. For
    /// details, see <a>GenerateDataKey</a> and <a>GenerateDataKeyPair</a>.
    /// </para><para></para></dd><dt>Asymmetric KMS keys</dt><dd><para>
    /// To create an asymmetric KMS key, use the <c>KeySpec</c> parameter to specify the type
    /// of key material in the KMS key. Then, use the <c>KeyUsage</c> parameter to determine
    /// whether the KMS key will be used to encrypt and decrypt or sign and verify. You can't
    /// change these properties after the KMS key is created.
    /// </para><para>
    /// Asymmetric KMS keys contain an RSA key pair, Elliptic Curve (ECC) key pair, or an
    /// SM2 key pair (China Regions only). The private key in an asymmetric KMS key never
    /// leaves KMS unencrypted. However, you can use the <a>GetPublicKey</a> operation to
    /// download the public key so it can be used outside of KMS. Each KMS key can have only
    /// one key usage. KMS keys with RSA key pairs can be used to encrypt and decrypt data
    /// or sign and verify messages (but not both). KMS keys with NIST-recommended ECC key
    /// pairs can be used to sign and verify messages or derive shared secrets (but not both).
    /// KMS keys with <c>ECC_SECG_P256K1</c> can be used only to sign and verify messages.
    /// KMS keys with SM2 key pairs (China Regions only) can be used to either encrypt and
    /// decrypt data, sign and verify messages, or derive shared secrets (you must choose
    /// one key usage type). For information about asymmetric KMS keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Asymmetric
    /// KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para></para></dd><dt>HMAC KMS key</dt><dd><para>
    /// To create an HMAC KMS key, set the <c>KeySpec</c> parameter to a key spec value for
    /// HMAC KMS keys. Then set the <c>KeyUsage</c> parameter to <c>GENERATE_VERIFY_MAC</c>.
    /// You must set the key usage even though <c>GENERATE_VERIFY_MAC</c> is the only valid
    /// key usage value for HMAC KMS keys. You can't change these properties after the KMS
    /// key is created.
    /// </para><para>
    /// HMAC KMS keys are symmetric keys that never leave KMS unencrypted. You can use HMAC
    /// keys to generate (<a>GenerateMac</a>) and verify (<a>VerifyMac</a>) HMAC codes for
    /// messages up to 4096 bytes.
    /// </para><para></para></dd><dt>Multi-Region primary keys</dt><dt>Imported key material</dt><dd><para>
    /// To create a multi-Region <i>primary key</i> in the local Amazon Web Services Region,
    /// use the <c>MultiRegion</c> parameter with a value of <c>True</c>. To create a multi-Region
    /// <i>replica key</i>, that is, a KMS key with the same key ID and key material as a
    /// primary key, but in a different Amazon Web Services Region, use the <a>ReplicateKey</a>
    /// operation. To change a replica key to a primary key, and its primary key to a replica
    /// key, use the <a>UpdatePrimaryRegion</a> operation.
    /// </para><para>
    /// You can create multi-Region KMS keys for all supported KMS key types: symmetric encryption
    /// KMS keys, HMAC KMS keys, asymmetric encryption KMS keys, and asymmetric signing KMS
    /// keys. You can also create multi-Region keys with imported key material. However, you
    /// can't create multi-Region keys in a custom key store.
    /// </para><para>
    /// This operation supports <i>multi-Region keys</i>, an KMS feature that lets you create
    /// multiple interoperable KMS keys in different Amazon Web Services Regions. Because
    /// these KMS keys have the same key ID, key material, and other metadata, you can use
    /// them interchangeably to encrypt data in one Amazon Web Services Region and decrypt
    /// it in a different Amazon Web Services Region without re-encrypting the data or making
    /// a cross-Region call. For more information about multi-Region keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">Multi-Region
    /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para></para></dd><dd><para>
    /// To import your own key material into a KMS key, begin by creating a KMS key with no
    /// key material. To do this, use the <c>Origin</c> parameter of <c>CreateKey</c> with
    /// a value of <c>EXTERNAL</c>. Next, use <a>GetParametersForImport</a> operation to get
    /// a public key and import token. Use the wrapping public key to encrypt your key material.
    /// Then, use <a>ImportKeyMaterial</a> with your import token to import the key material.
    /// For step-by-step instructions, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
    /// Key Material</a> in the <i><i>Key Management Service Developer Guide</i></i>.
    /// </para><para>
    /// You can import key material into KMS keys of all supported KMS key types: symmetric
    /// encryption KMS keys, HMAC KMS keys, asymmetric encryption KMS keys, and asymmetric
    /// signing KMS keys. You can also create multi-Region keys with imported key material.
    /// However, you can't import key material into a KMS key in a custom key store.
    /// </para><para>
    /// To create a multi-Region primary key with imported key material, use the <c>Origin</c>
    /// parameter of <c>CreateKey</c> with a value of <c>EXTERNAL</c> and the <c>MultiRegion</c>
    /// parameter with a value of <c>True</c>. To create replicas of the multi-Region primary
    /// key, use the <a>ReplicateKey</a> operation. For instructions, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-create-cmk.html&#xD;&#xA;            ">Importing key material step 1</a>. For more information about multi-Region keys,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">Multi-Region
    /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para></para></dd><dt>Custom key store</dt><dd><para>
    /// A <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
    /// key store</a> lets you protect your Amazon Web Services resources using keys in a
    /// backing key store that you own and manage. When you request a cryptographic operation
    /// with a KMS key in a custom key store, the operation is performed in the backing key
    /// store using its cryptographic keys.
    /// </para><para>
    /// KMS supports <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-cloudhsm.html">CloudHSM
    /// key stores</a> backed by an CloudHSM cluster and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-external.html">external
    /// key stores</a> backed by an external key manager outside of Amazon Web Services. When
    /// you create a KMS key in an CloudHSM key store, KMS generates an encryption key in
    /// the CloudHSM cluster and associates it with the KMS key. When you create a KMS key
    /// in an external key store, you specify an existing encryption key in the external key
    /// manager.
    /// </para><note><para>
    /// Some external key managers provide a simpler method for creating a KMS key in an external
    /// key store. For details, see your external key manager documentation.
    /// </para></note><para>
    /// Before you create a KMS key in a custom key store, the <c>ConnectionState</c> of the
    /// key store must be <c>CONNECTED</c>. To connect the custom key store, use the <a>ConnectCustomKeyStore</a>
    /// operation. To find the <c>ConnectionState</c>, use the <a>DescribeCustomKeyStores</a>
    /// operation.
    /// </para><para>
    /// To create a KMS key in a custom key store, use the <c>CustomKeyStoreId</c>. Use the
    /// default <c>KeySpec</c> value, <c>SYMMETRIC_DEFAULT</c>, and the default <c>KeyUsage</c>
    /// value, <c>ENCRYPT_DECRYPT</c> to create a symmetric encryption key. No other key type
    /// is supported in a custom key store.
    /// </para><para>
    /// To create a KMS key in an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-cmk-keystore.html">CloudHSM
    /// key store</a>, use the <c>Origin</c> parameter with a value of <c>AWS_CLOUDHSM</c>.
    /// The CloudHSM cluster that is associated with the custom key store must have at least
    /// two active HSMs in different Availability Zones in the Amazon Web Services Region.
    /// </para><para>
    /// To create a KMS key in an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-xks-keys.html">external
    /// key store</a>, use the <c>Origin</c> parameter with a value of <c>EXTERNAL_KEY_STORE</c>
    /// and an <c>XksKeyId</c> parameter that identifies an existing external key.
    /// </para><note><para>
    /// Some external key managers provide a simpler method for creating a KMS key in an external
    /// key store. For details, see your external key manager documentation.
    /// </para></note></dd></dl><para><b>Cross-account use</b>: No. You cannot use this operation to create a KMS key in
    /// a different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:CreateKey</a>
    /// (IAM policy). To use the <c>Tags</c> parameter, <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:TagResource</a>
    /// (IAM policy). For examples and information about related permissions, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/customer-managed-policies.html#iam-policy-example-create-key">Allow
    /// a user to create KMS keys</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DescribeKey</a></para></li><li><para><a>ListKeys</a></para></li><li><para><a>ScheduleKeyDeletion</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/accessing-kms.html#programming-eventual-consistency">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.KeyMetadata")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateKey API operation.", Operation = new[] {"CreateKey"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.CreateKeyResponse))]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.KeyMetadata or Amazon.KeyManagementService.Model.CreateKeyResponse",
        "This cmdlet returns an Amazon.KeyManagementService.Model.KeyMetadata object.",
        "The service call response (type Amazon.KeyManagementService.Model.CreateKeyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKMSKeyCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BypassPolicyLockoutSafetyCheck
        /// <summary>
        /// <para>
        /// <para>Skips ("bypasses") the key policy lockout safety check. The default value is false.</para><important><para>Setting this value to true increases the risk that the KMS key becomes unmanageable.
        /// Do not set this value to true indiscriminately.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-default.html#prevent-unmanageable-key">Default
        /// key policy</a> in the <i>Key Management Service Developer Guide</i>.</para></important><para>Use this parameter only when you intend to prevent the principal that is making the
        /// request from making a subsequent <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_PutKeyPolicy.html">PutKeyPolicy</a>
        /// request on the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Creates the KMS key in the specified <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-store-overview.html">custom
        /// key store</a>. The <c>ConnectionState</c> of the custom key store must be <c>CONNECTED</c>.
        /// To find the CustomKeyStoreID and ConnectionState use the <a>DescribeCustomKeyStores</a>
        /// operation.</para><para>This parameter is valid only for symmetric encryption KMS keys in a single Region.
        /// You cannot create any other type of KMS key in a custom key store.</para><para>When you create a KMS key in an CloudHSM key store, KMS generates a non-exportable
        /// 256-bit symmetric key in its associated CloudHSM cluster and associates it with the
        /// KMS key. When you create a KMS key in an external key store, you must use the <c>XksKeyId</c>
        /// parameter to specify an external key that serves as key material for the KMS key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the KMS key. Use a description that helps you decide whether the
        /// KMS key is appropriate for a task. The default value is an empty string (no description).</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><para>To set or change the description after the key is created, use <a>UpdateKeyDescription</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KeySpec
        /// <summary>
        /// <para>
        /// <para>Specifies the type of KMS key to create. The default value, <c>SYMMETRIC_DEFAULT</c>,
        /// creates a KMS key with a 256-bit AES-GCM key that is used for encryption and decryption,
        /// except in China Regions, where it creates a 128-bit symmetric key that uses SM4 encryption.
        /// For a detailed description of all supported key specs, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symm-asymm-choose-key-spec.html">Key
        /// spec reference</a> in the <i><i>Key Management Service Developer Guide</i></i>.</para><para>The <c>KeySpec</c> determines whether the KMS key contains a symmetric key or an asymmetric
        /// key pair. It also determines the algorithms that the KMS key supports. You can't change
        /// the <c>KeySpec</c> after the KMS key is created. To further restrict the algorithms
        /// that can be used with the KMS key, use a condition key in its key policy or IAM policy.
        /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/conditions-kms.html#conditions-kms-encryption-algorithm">kms:EncryptionAlgorithm</a>,
        /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/conditions-kms.html#conditions-kms-mac-algorithm">kms:MacAlgorithm</a>,
        /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/conditions-kms.html#conditions-kms-key-agreement-algorithm">kms:KeyAgreementAlgorithm</a>,
        /// or <a href="https://docs.aws.amazon.com/kms/latest/developerguide/conditions-kms.html#conditions-kms-signing-algorithm">kms:SigningAlgorithm</a>
        /// in the <i><i>Key Management Service Developer Guide</i></i>.</para><important><para><a href="http://aws.amazon.com/kms/features/#AWS_Service_Integration">Amazon Web
        /// Services services that are integrated with KMS</a> use symmetric encryption KMS keys
        /// to protect your data. These services do not support asymmetric KMS keys or HMAC KMS
        /// keys.</para></important><para>KMS supports the following key specs for KMS keys:</para><ul><li><para>Symmetric encryption key (default)</para><ul><li><para><c>SYMMETRIC_DEFAULT</c></para></li></ul></li><li><para>HMAC keys (symmetric)</para><ul><li><para><c>HMAC_224</c></para></li><li><para><c>HMAC_256</c></para></li><li><para><c>HMAC_384</c></para></li><li><para><c>HMAC_512</c></para></li></ul></li><li><para>Asymmetric RSA key pairs (encryption and decryption -or- signing and verification)</para><ul><li><para><c>RSA_2048</c></para></li><li><para><c>RSA_3072</c></para></li><li><para><c>RSA_4096</c></para></li></ul></li><li><para>Asymmetric NIST-recommended elliptic curve key pairs (signing and verification -or-
        /// deriving shared secrets)</para><ul><li><para><c>ECC_NIST_P256</c> (secp256r1)</para></li><li><para><c>ECC_NIST_P384</c> (secp384r1)</para></li><li><para><c>ECC_NIST_P521</c> (secp521r1)</para></li></ul></li><li><para>Other asymmetric elliptic curve key pairs (signing and verification)</para><ul><li><para><c>ECC_SECG_P256K1</c> (secp256k1), commonly used for cryptocurrencies.</para></li></ul></li><li><para>SM2 key pairs (encryption and decryption -or- signing and verification -or- deriving
        /// shared secrets)</para><ul><li><para><c>SM2</c> (China Regions only)</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeySpec")]
        public Amazon.KeyManagementService.KeySpec KeySpec { get; set; }
        #endregion
        
        #region Parameter KeyUsage
        /// <summary>
        /// <para>
        /// <para>Determines the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-cryptography.html#cryptographic-operations">cryptographic
        /// operations</a> for which you can use the KMS key. The default value is <c>ENCRYPT_DECRYPT</c>.
        /// This parameter is optional when you are creating a symmetric encryption KMS key; otherwise,
        /// it is required. You can't change the <c>KeyUsage</c> value after the KMS key is created.</para><para>Select only one valid value.</para><ul><li><para>For symmetric encryption KMS keys, omit the parameter or specify <c>ENCRYPT_DECRYPT</c>.</para></li><li><para>For HMAC KMS keys (symmetric), specify <c>GENERATE_VERIFY_MAC</c>.</para></li><li><para>For asymmetric KMS keys with RSA key pairs, specify <c>ENCRYPT_DECRYPT</c> or <c>SIGN_VERIFY</c>.</para></li><li><para>For asymmetric KMS keys with NIST-recommended elliptic curve key pairs, specify <c>SIGN_VERIFY</c>
        /// or <c>KEY_AGREEMENT</c>.</para></li><li><para>For asymmetric KMS keys with <c>ECC_SECG_P256K1</c> key pairs specify <c>SIGN_VERIFY</c>.</para></li><li><para>For asymmetric KMS keys with SM2 key pairs (China Regions only), specify <c>ENCRYPT_DECRYPT</c>,
        /// <c>SIGN_VERIFY</c>, or <c>KEY_AGREEMENT</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.KeyUsageType")]
        public Amazon.KeyManagementService.KeyUsageType KeyUsage { get; set; }
        #endregion
        
        #region Parameter MultiRegion
        /// <summary>
        /// <para>
        /// <para>Creates a multi-Region primary key that you can replicate into other Amazon Web Services
        /// Regions. You cannot change this value after you create the KMS key. </para><para>For a multi-Region key, set this parameter to <c>True</c>. For a single-Region KMS
        /// key, omit this parameter or set it to <c>False</c>. The default value is <c>False</c>.</para><para>This operation supports <i>multi-Region keys</i>, an KMS feature that lets you create
        /// multiple interoperable KMS keys in different Amazon Web Services Regions. Because
        /// these KMS keys have the same key ID, key material, and other metadata, you can use
        /// them interchangeably to encrypt data in one Amazon Web Services Region and decrypt
        /// it in a different Amazon Web Services Region without re-encrypting the data or making
        /// a cross-Region call. For more information about multi-Region keys, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/multi-region-keys-overview.html">Multi-Region
        /// keys in KMS</a> in the <i>Key Management Service Developer Guide</i>.</para><para>This value creates a <i>primary key</i>, not a replica. To create a <i>replica key</i>,
        /// use the <a>ReplicateKey</a> operation. </para><para>You can create a symmetric or asymmetric multi-Region key, and you can create a multi-Region
        /// key with imported key material. However, you cannot create a multi-Region key in a
        /// custom key store.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiRegion { get; set; }
        #endregion
        
        #region Parameter Origin
        /// <summary>
        /// <para>
        /// <para>The source of the key material for the KMS key. You cannot change the origin after
        /// you create the KMS key. The default is <c>AWS_KMS</c>, which means that KMS creates
        /// the key material.</para><para>To <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys-create-cmk.html">create
        /// a KMS key with no key material</a> (for imported key material), set this value to
        /// <c>EXTERNAL</c>. For more information about importing key material into KMS, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/importing-keys.html">Importing
        /// Key Material</a> in the <i>Key Management Service Developer Guide</i>. The <c>EXTERNAL</c>
        /// origin value is valid only for symmetric KMS keys.</para><para>To <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-cmk-keystore.html">create
        /// a KMS key in an CloudHSM key store</a> and create its key material in the associated
        /// CloudHSM cluster, set this value to <c>AWS_CLOUDHSM</c>. You must also use the <c>CustomKeyStoreId</c>
        /// parameter to identify the CloudHSM key store. The <c>KeySpec</c> value must be <c>SYMMETRIC_DEFAULT</c>.</para><para>To <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-xks-keys.html">create
        /// a KMS key in an external key store</a>, set this value to <c>EXTERNAL_KEY_STORE</c>.
        /// You must also use the <c>CustomKeyStoreId</c> parameter to identify the external key
        /// store and the <c>XksKeyId</c> parameter to identify the associated external key. The
        /// <c>KeySpec</c> value must be <c>SYMMETRIC_DEFAULT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.OriginType")]
        public Amazon.KeyManagementService.OriginType Origin { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The key policy to attach to the KMS key.</para><para>If you provide a key policy, it must meet the following criteria:</para><ul><li><para>The key policy must allow the calling principal to make a subsequent <c>PutKeyPolicy</c>
        /// request on the KMS key. This reduces the risk that the KMS key becomes unmanageable.
        /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-default.html#prevent-unmanageable-key">Default
        /// key policy</a> in the <i>Key Management Service Developer Guide</i>. (To omit this
        /// condition, set <c>BypassPolicyLockoutSafetyCheck</c> to true.)</para></li><li><para>Each statement in the key policy must contain one or more principals. The principals
        /// in the key policy must exist and be visible to KMS. When you create a new Amazon Web
        /// Services principal, you might need to enforce a delay before including the new principal
        /// in a key policy because the new principal might not be immediately visible to KMS.
        /// For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/troubleshoot_general.html#troubleshoot_general_eventual-consistency">Changes
        /// that I make are not always immediately visible</a> in the <i>Amazon Web Services Identity
        /// and Access Management User Guide</i>.</para></li></ul><note><para>If either of the required <c>Resource</c> or <c>Action</c> elements are missing from
        /// a key policy statement, the policy statement has no effect. When a key policy statement
        /// is missing one of these elements, the KMS console correctly reports an error, but
        /// the <c>CreateKey</c> and <c>PutKeyPolicy</c> API requests succeed, even though the
        /// policy statement is ineffective.</para><para>For more information on required key policy elements, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-overview.html#key-policy-elements">Elements
        /// in a key policy</a> in the <i>Key Management Service Developer Guide</i>.</para></note><para>If you do not provide a key policy, KMS attaches a default key policy to the KMS key.
        /// For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-policy-default.html">Default
        /// key policy</a> in the <i>Key Management Service Developer Guide</i>. </para><note><para>If the key policy exceeds the length constraint, KMS returns a <c>LimitExceededException</c>.</para></note><para>For help writing and formatting a JSON policy document, see the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies.html">IAM
        /// JSON Policy Reference</a> in the <i><i>Identity and Access Management User Guide</i></i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags to the KMS key. Use this parameter to tag the KMS key when
        /// it is created. To tag an existing KMS key, use the <a>TagResource</a> operation.</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><note><para>Tagging or untagging a KMS key can allow or deny permission to the KMS key. For details,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/abac.html">ABAC
        /// for KMS</a> in the <i>Key Management Service Developer Guide</i>.</para></note><para>To use this parameter, you must have <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:TagResource</a>
        /// permission in an IAM policy.</para><para>Each tag consists of a tag key and a tag value. Both the tag key and the tag value
        /// are required, but the tag value can be an empty (null) string. You cannot have more
        /// than one tag on a KMS key with the same tag key. If you specify an existing tag key
        /// with a different tag value, KMS replaces the current tag value with the specified
        /// one.</para><para>When you add tags to an Amazon Web Services resource, Amazon Web Services generates
        /// a cost allocation report with usage and costs aggregated by tags. Tags can also be
        /// used to control access to a KMS key. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/tagging-keys.html">Tags
        /// in KMS</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KeyManagementService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter XksKeyId
        /// <summary>
        /// <para>
        /// <para>Identifies the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-external.html#concept-external-key">external
        /// key</a> that serves as key material for the KMS key in an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-external.html">external
        /// key store</a>. Specify the ID that the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-external.html#concept-xks-proxy">external
        /// key store proxy</a> uses to refer to the external key. For help, see the documentation
        /// for your external key store proxy.</para><para>This parameter is required for a KMS key with an <c>Origin</c> value of <c>EXTERNAL_KEY_STORE</c>.
        /// It is not valid for KMS keys with any other <c>Origin</c> value.</para><para>The external key must be an existing 256-bit AES symmetric encryption key hosted outside
        /// of Amazon Web Services in an external key manager associated with the external key
        /// store specified by the <c>CustomKeyStoreId</c> parameter. This key must be enabled
        /// and configured to perform encryption and decryption. Each KMS key in an external key
        /// store must use a different external key. For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-xks-keys.html#xks-key-requirements">Requirements
        /// for a KMS key in an external key store</a> in the <i>Key Management Service Developer
        /// Guide</i>.</para><para>Each KMS key in an external key store is associated two backing keys. One is key material
        /// that KMS generates. The other is the external key specified by this parameter. When
        /// you use the KMS key in an external key store to encrypt data, the encryption operation
        /// is performed first by KMS using the KMS key material, and then by the external key
        /// manager using the specified external key, a process known as <i>double encryption</i>.
        /// For details, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-external.html#concept-double-encryption">Double
        /// encryption</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksKeyId { get; set; }
        #endregion
        
        #region Parameter CustomerMasterKeySpec
        /// <summary>
        /// <para>
        /// <para>Instead, use the <c>KeySpec</c> parameter.</para><para>The <c>KeySpec</c> and <c>CustomerMasterKeySpec</c> parameters work the same way.
        /// Only the names differ. We recommend that you use <c>KeySpec</c> parameter in your
        /// code. However, to avoid breaking changes, KMS supports both parameters.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter has been deprecated. Instead, use the KeySpec parameter.")]
        [AWSConstantClassSource("Amazon.KeyManagementService.CustomerMasterKeySpec")]
        public Amazon.KeyManagementService.CustomerMasterKeySpec CustomerMasterKeySpec { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'KeyMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.CreateKeyResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.CreateKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "KeyMetadata";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSKey (CreateKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.CreateKeyResponse, NewKMSKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BypassPolicyLockoutSafetyCheck = this.BypassPolicyLockoutSafetyCheck;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomerMasterKeySpec = this.CustomerMasterKeySpec;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            context.Description = this.Description;
            context.KeySpec = this.KeySpec;
            context.KeyUsage = this.KeyUsage;
            context.MultiRegion = this.MultiRegion;
            context.Origin = this.Origin;
            context.Policy = this.Policy;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KeyManagementService.Model.Tag>(this.Tag);
            }
            context.XksKeyId = this.XksKeyId;
            
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
            var request = new Amazon.KeyManagementService.Model.CreateKeyRequest();
            
            if (cmdletContext.BypassPolicyLockoutSafetyCheck != null)
            {
                request.BypassPolicyLockoutSafetyCheck = cmdletContext.BypassPolicyLockoutSafetyCheck.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.CustomerMasterKeySpec != null)
            {
                request.CustomerMasterKeySpec = cmdletContext.CustomerMasterKeySpec;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.CustomKeyStoreId != null)
            {
                request.CustomKeyStoreId = cmdletContext.CustomKeyStoreId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KeySpec != null)
            {
                request.KeySpec = cmdletContext.KeySpec;
            }
            if (cmdletContext.KeyUsage != null)
            {
                request.KeyUsage = cmdletContext.KeyUsage;
            }
            if (cmdletContext.MultiRegion != null)
            {
                request.MultiRegion = cmdletContext.MultiRegion.Value;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origin = cmdletContext.Origin;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.XksKeyId != null)
            {
                request.XksKeyId = cmdletContext.XksKeyId;
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
        
        private Amazon.KeyManagementService.Model.CreateKeyResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateKey");
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
            public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.KeyManagementService.CustomerMasterKeySpec CustomerMasterKeySpec { get; set; }
            public System.String CustomKeyStoreId { get; set; }
            public System.String Description { get; set; }
            public Amazon.KeyManagementService.KeySpec KeySpec { get; set; }
            public Amazon.KeyManagementService.KeyUsageType KeyUsage { get; set; }
            public System.Boolean? MultiRegion { get; set; }
            public Amazon.KeyManagementService.OriginType Origin { get; set; }
            public System.String Policy { get; set; }
            public List<Amazon.KeyManagementService.Model.Tag> Tag { get; set; }
            public System.String XksKeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.CreateKeyResponse, NewKMSKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.KeyMetadata;
        }
        
    }
}
