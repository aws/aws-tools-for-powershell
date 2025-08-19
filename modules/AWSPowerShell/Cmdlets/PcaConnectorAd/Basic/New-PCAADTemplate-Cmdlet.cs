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
using Amazon.PcaConnectorAd;
using Amazon.PcaConnectorAd.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCAAD
{
    /// <summary>
    /// Creates an Active Directory compatible certificate template. The connectors issues
    /// certificates using these templates based on the requester’s Active Directory group
    /// membership.
    /// </summary>
    [Cmdlet("New", "PCAADTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Pca Connector Ad CreateTemplate API operation.", Operation = new[] {"CreateTemplate"}, SelectReturnType = typeof(Amazon.PcaConnectorAd.Model.CreateTemplateResponse))]
    [AWSCmdletOutput("System.String or Amazon.PcaConnectorAd.Model.CreateTemplateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.PcaConnectorAd.Model.CreateTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCAADTemplateCmdlet : AmazonPcaConnectorAdClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_Algorithm
        /// <summary>
        /// <para>
        /// <para>Defines the algorithm used to generate the private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.PrivateKeyAlgorithm")]
        public Amazon.PcaConnectorAd.PrivateKeyAlgorithm Definition_TemplateV3_PrivateKeyAttributes_Algorithm { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_Algorithm
        /// <summary>
        /// <para>
        /// <para>Defines the algorithm used to generate the private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.PrivateKeyAlgorithm")]
        public Amazon.PcaConnectorAd.PrivateKeyAlgorithm Definition_TemplateV4_PrivateKeyAttributes_Algorithm { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_GeneralFlags_AutoEnrollment
        /// <summary>
        /// <para>
        /// <para>Allows certificate issuance using autoenrollment. Set to TRUE to allow autoenrollment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_GeneralFlags_AutoEnrollment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_GeneralFlags_AutoEnrollment
        /// <summary>
        /// <para>
        /// <para>Allows certificate issuance using autoenrollment. Set to TRUE to allow autoenrollment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_GeneralFlags_AutoEnrollment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_GeneralFlags_AutoEnrollment
        /// <summary>
        /// <para>
        /// <para>Allows certificate issuance using autoenrollment. Set to TRUE to allow autoenrollment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_GeneralFlags_AutoEnrollment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_PrivateKeyFlags_ClientVersion
        /// <summary>
        /// <para>
        /// <para>Defines the minimum client compatibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ClientCompatibilityV2")]
        public Amazon.PcaConnectorAd.ClientCompatibilityV2 Definition_TemplateV2_PrivateKeyFlags_ClientVersion { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyFlags_ClientVersion
        /// <summary>
        /// <para>
        /// <para>Defines the minimum client compatibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ClientCompatibilityV3")]
        public Amazon.PcaConnectorAd.ClientCompatibilityV3 Definition_TemplateV3_PrivateKeyFlags_ClientVersion { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyFlags_ClientVersion
        /// <summary>
        /// <para>
        /// <para>Defines the minimum client compatibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ClientCompatibilityV4")]
        public Amazon.PcaConnectorAd.ClientCompatibilityV4 Definition_TemplateV4_PrivateKeyFlags_ClientVersion { get; set; }
        #endregion
        
        #region Parameter ConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/pca-connector-ad/latest/APIReference/API_CreateConnector.html">CreateConnector</a>.</para>
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
        public System.String ConnectorArn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_ApplicationPolicies_Critical
        /// <summary>
        /// <para>
        /// <para>Marks the application policy extension as critical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_Extensions_ApplicationPolicies_Critical { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_KeyUsage_Critical
        /// <summary>
        /// <para>
        /// <para>Sets the key usage extension to critical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_Critical { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_ApplicationPolicies_Critical
        /// <summary>
        /// <para>
        /// <para>Marks the application policy extension as critical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_Extensions_ApplicationPolicies_Critical { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_KeyUsage_Critical
        /// <summary>
        /// <para>
        /// <para>Sets the key usage extension to critical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_Critical { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_ApplicationPolicies_Critical
        /// <summary>
        /// <para>
        /// <para>Marks the application policy extension as critical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_Extensions_ApplicationPolicies_Critical { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_KeyUsage_Critical
        /// <summary>
        /// <para>
        /// <para>Sets the key usage extension to critical.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_Critical { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders
        /// <summary>
        /// <para>
        /// <para>Defines the cryptographic providers used to generate the private key.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders
        /// <summary>
        /// <para>
        /// <para>Defines the cryptographic providers used to generate the private key.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders
        /// <summary>
        /// <para>
        /// <para>Defines the cryptographic providers used to generate the private key.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment
        /// <summary>
        /// <para>
        /// <para>DataEncipherment is asserted when the subject public key is used for directly enciphering
        /// raw user data without the use of an intermediate symmetric cipher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment
        /// <summary>
        /// <para>
        /// <para>DataEncipherment is asserted when the subject public key is used for directly enciphering
        /// raw user data without the use of an intermediate symmetric cipher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment
        /// <summary>
        /// <para>
        /// <para>DataEncipherment is asserted when the subject public key is used for directly enciphering
        /// raw user data without the use of an intermediate symmetric cipher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt
        /// <summary>
        /// <para>
        /// <para>Allows key for encryption and decryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt
        /// <summary>
        /// <para>
        /// <para>Allows key for encryption and decryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature
        /// <summary>
        /// <para>
        /// <para>The digitalSignature is asserted when the subject public key is used for verifying
        /// digital signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature
        /// <summary>
        /// <para>
        /// <para>The digitalSignature is asserted when the subject public key is used for verifying
        /// digital signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature
        /// <summary>
        /// <para>
        /// <para>The digitalSignature is asserted when the subject public key is used for verifying
        /// digital signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull
        /// <summary>
        /// <para>
        /// <para>Allow renewal using the same key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull
        /// <summary>
        /// <para>
        /// <para>Allow renewal using the same key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull
        /// <summary>
        /// <para>
        /// <para>Allow renewal using the same key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_PrivateKeyFlags_ExportableKey
        /// <summary>
        /// <para>
        /// <para>Allows the private key to be exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_PrivateKeyFlags_ExportableKey { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyFlags_ExportableKey
        /// <summary>
        /// <para>
        /// <para>Allows the private key to be exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_PrivateKeyFlags_ExportableKey { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyFlags_ExportableKey
        /// <summary>
        /// <para>
        /// <para>Allows the private key to be exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_ExportableKey { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_HashAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the hash algorithm used to hash the private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.HashAlgorithm")]
        public Amazon.PcaConnectorAd.HashAlgorithm Definition_TemplateV3_HashAlgorithm { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_HashAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the hash algorithm used to hash the private key. Hash algorithm can only
        /// be specified when using Key Storage Providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.HashAlgorithm")]
        public Amazon.PcaConnectorAd.HashAlgorithm Definition_TemplateV4_HashAlgorithm { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms
        /// <summary>
        /// <para>
        /// <para>Include symmetric algorithms allowed by the subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms
        /// <summary>
        /// <para>
        /// <para>Include symmetric algorithms allowed by the subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms
        /// <summary>
        /// <para>
        /// <para>Include symmetric algorithms allowed by the subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement
        /// <summary>
        /// <para>
        /// <para>KeyAgreement is asserted when the subject public key is used for key agreement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement
        /// <summary>
        /// <para>
        /// <para>KeyAgreement is asserted when the subject public key is used for key agreement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement
        /// <summary>
        /// <para>
        /// <para>Allows key exchange without encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement
        /// <summary>
        /// <para>
        /// <para>KeyAgreement is asserted when the subject public key is used for key agreement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement
        /// <summary>
        /// <para>
        /// <para>Allows key exchange without encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment
        /// <summary>
        /// <para>
        /// <para>KeyEncipherment is asserted when the subject public key is used for enciphering private
        /// or secret keys, i.e., for key transport.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment
        /// <summary>
        /// <para>
        /// <para>KeyEncipherment is asserted when the subject public key is used for enciphering private
        /// or secret keys, i.e., for key transport.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment
        /// <summary>
        /// <para>
        /// <para>KeyEncipherment is asserted when the subject public key is used for enciphering private
        /// or secret keys, i.e., for key transport.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_PrivateKeyAttributes_KeySpec
        /// <summary>
        /// <para>
        /// <para>Defines the purpose of the private key. Set it to "KEY_EXCHANGE" or "SIGNATURE" value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.KeySpec")]
        public Amazon.PcaConnectorAd.KeySpec Definition_TemplateV2_PrivateKeyAttributes_KeySpec { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_KeySpec
        /// <summary>
        /// <para>
        /// <para>Defines the purpose of the private key. Set it to "KEY_EXCHANGE" or "SIGNATURE" value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.KeySpec")]
        public Amazon.PcaConnectorAd.KeySpec Definition_TemplateV3_PrivateKeyAttributes_KeySpec { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_KeySpec
        /// <summary>
        /// <para>
        /// <para>Defines the purpose of the private key. Set it to "KEY_EXCHANGE" or "SIGNATURE" value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.KeySpec")]
        public Amazon.PcaConnectorAd.KeySpec Definition_TemplateV4_PrivateKeyAttributes_KeySpec { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_GeneralFlags_MachineType
        /// <summary>
        /// <para>
        /// <para>Defines if the template is for machines or users. Set to TRUE if the template is for
        /// machines. Set to FALSE if the template is for users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_GeneralFlags_MachineType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_GeneralFlags_MachineType
        /// <summary>
        /// <para>
        /// <para>Defines if the template is for machines or users. Set to TRUE if the template is for
        /// machines. Set to FALSE if the template is for users</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_GeneralFlags_MachineType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_GeneralFlags_MachineType
        /// <summary>
        /// <para>
        /// <para>Defines if the template is for machines or users. Set to TRUE if the template is for
        /// machines. Set to FALSE if the template is for users</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_GeneralFlags_MachineType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength
        /// <summary>
        /// <para>
        /// <para>Set the minimum key length of the private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength
        /// <summary>
        /// <para>
        /// <para>Set the minimum key length of the private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength
        /// <summary>
        /// <para>
        /// <para>Set the minimum key length of the private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the template. The template name must be unique.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation
        /// <summary>
        /// <para>
        /// <para>NonRepudiation is asserted when the subject public key is used to verify digital signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation
        /// <summary>
        /// <para>
        /// <para>NonRepudiation is asserted when the subject public key is used to verify digital signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation
        /// <summary>
        /// <para>
        /// <para>NonRepudiation is asserted when the subject public key is used to verify digital signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_EnrollmentFlags_NoSecurityExtension
        /// <summary>
        /// <para>
        /// <para>This flag instructs the CA to not include the security extension szOID_NTDS_CA_SECURITY_EXT
        /// (OID:1.3.6.1.4.1.311.25.2), as specified in [MS-WCCE] sections 2.2.2.7.7.4 and 3.2.2.6.2.1.4.5.9,
        /// in the issued certificate. This addresses a Windows Kerberos elevation-of-privilege
        /// vulnerability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_EnrollmentFlags_NoSecurityExtension { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_EnrollmentFlags_NoSecurityExtension
        /// <summary>
        /// <para>
        /// <para>This flag instructs the CA to not include the security extension szOID_NTDS_CA_SECURITY_EXT
        /// (OID:1.3.6.1.4.1.311.25.2), as specified in [MS-WCCE] sections 2.2.2.7.7.4 and 3.2.2.6.2.1.4.5.9,
        /// in the issued certificate. This addresses a Windows Kerberos elevation-of-privilege
        /// vulnerability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_EnrollmentFlags_NoSecurityExtension { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_EnrollmentFlags_NoSecurityExtension
        /// <summary>
        /// <para>
        /// <para>This flag instructs the CA to not include the security extension szOID_NTDS_CA_SECURITY_EXT
        /// (OID:1.3.6.1.4.1.311.25.2), as specified in [MS-WCCE] sections 2.2.2.7.7.4 and 3.2.2.6.2.1.4.5.9,
        /// in the issued certificate. This addresses a Windows Kerberos elevation-of-privilege
        /// vulnerability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_EnrollmentFlags_NoSecurityExtension { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_CertificateValidity_RenewalPeriod_Period
        /// <summary>
        /// <para>
        /// <para>The numeric value for the validity period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Definition_TemplateV2_CertificateValidity_RenewalPeriod_Period { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_CertificateValidity_ValidityPeriod_Period
        /// <summary>
        /// <para>
        /// <para>The numeric value for the validity period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Definition_TemplateV2_CertificateValidity_ValidityPeriod_Period { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_CertificateValidity_RenewalPeriod_Period
        /// <summary>
        /// <para>
        /// <para>The numeric value for the validity period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Definition_TemplateV3_CertificateValidity_RenewalPeriod_Period { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_CertificateValidity_ValidityPeriod_Period
        /// <summary>
        /// <para>
        /// <para>The numeric value for the validity period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Definition_TemplateV3_CertificateValidity_ValidityPeriod_Period { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_CertificateValidity_RenewalPeriod_Period
        /// <summary>
        /// <para>
        /// <para>The numeric value for the validity period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Definition_TemplateV4_CertificateValidity_RenewalPeriod_Period { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_CertificateValidity_ValidityPeriod_Period
        /// <summary>
        /// <para>
        /// <para>The numeric value for the validity period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Definition_TemplateV4_CertificateValidity_ValidityPeriod_Period { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType
        /// <summary>
        /// <para>
        /// <para>The unit of time. You can select hours, days, weeks, months, and years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ValidityPeriodType")]
        public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType
        /// <summary>
        /// <para>
        /// <para>The unit of time. You can select hours, days, weeks, months, and years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ValidityPeriodType")]
        public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType
        /// <summary>
        /// <para>
        /// <para>The unit of time. You can select hours, days, weeks, months, and years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ValidityPeriodType")]
        public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType
        /// <summary>
        /// <para>
        /// <para>The unit of time. You can select hours, days, weeks, months, and years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ValidityPeriodType")]
        public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType
        /// <summary>
        /// <para>
        /// <para>The unit of time. You can select hours, days, weeks, months, and years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ValidityPeriodType")]
        public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType
        /// <summary>
        /// <para>
        /// <para>The unit of time. You can select hours, days, weeks, months, and years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.ValidityPeriodType")]
        public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_Extensions_ApplicationPolicies_Policies
        /// <summary>
        /// <para>
        /// <para>Application policies describe what the certificate can be used for.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PcaConnectorAd.Model.ApplicationPolicy[] Definition_TemplateV2_Extensions_ApplicationPolicies_Policies { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_Extensions_ApplicationPolicies_Policies
        /// <summary>
        /// <para>
        /// <para>Application policies describe what the certificate can be used for.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PcaConnectorAd.Model.ApplicationPolicy[] Definition_TemplateV3_Extensions_ApplicationPolicies_Policies { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_Extensions_ApplicationPolicies_Policies
        /// <summary>
        /// <para>
        /// <para>Application policies describe what the certificate can be used for.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PcaConnectorAd.Model.ApplicationPolicy[] Definition_TemplateV4_Extensions_ApplicationPolicies_Policies { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType
        /// <summary>
        /// <para>
        /// <para>You can specify all key usages using property type ALL. You can use property type
        /// or property flags but not both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.KeyUsagePropertyType")]
        public Amazon.PcaConnectorAd.KeyUsagePropertyType Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType
        /// <summary>
        /// <para>
        /// <para>You can specify all key usages using property type ALL. You can use property type
        /// or property flags but not both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PcaConnectorAd.KeyUsagePropertyType")]
        public Amazon.PcaConnectorAd.KeyUsagePropertyType Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore
        /// <summary>
        /// <para>
        /// <para>Delete expired or revoked certificates instead of archiving them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore
        /// <summary>
        /// <para>
        /// <para>Delete expired or revoked certificates instead of archiving them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore
        /// <summary>
        /// <para>
        /// <para>Delete expired or revoked certificates instead of archiving them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm
        /// <summary>
        /// <para>
        /// <para>Reguires the PKCS #1 v2.1 signature format for certificates. You should verify that
        /// your CA, objects, and applications can accept this signature format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm
        /// <summary>
        /// <para>
        /// <para>Requires the PKCS #1 v2.1 signature format for certificates. You should verify that
        /// your CA, objects, and applications can accept this signature format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_RequireCommonName
        /// <summary>
        /// <para>
        /// <para>Include the common name in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireCommonName { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_RequireCommonName
        /// <summary>
        /// <para>
        /// <para>Include the common name in the subject name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireCommonName { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_RequireCommonName
        /// <summary>
        /// <para>
        /// <para>Include the common name in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireCommonName { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath
        /// <summary>
        /// <para>
        /// <para>Include the directory path in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath
        /// <summary>
        /// <para>
        /// <para>Include the directory path in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath
        /// <summary>
        /// <para>
        /// <para>Include the directory path in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn
        /// <summary>
        /// <para>
        /// <para>Include the DNS as common name in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn
        /// <summary>
        /// <para>
        /// <para>Include the DNS as common name in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn
        /// <summary>
        /// <para>
        /// <para>Include the DNS as common name in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_RequireEmail
        /// <summary>
        /// <para>
        /// <para>Include the subject's email in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireEmail { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_RequireEmail
        /// <summary>
        /// <para>
        /// <para>Include the subject's email in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireEmail { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_RequireEmail
        /// <summary>
        /// <para>
        /// <para>Include the subject's email in the subject name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireEmail { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal
        /// <summary>
        /// <para>
        /// <para>Renew certificate using the same private key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid
        /// <summary>
        /// <para>
        /// <para>Include the globally unique identifier (GUID) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid
        /// <summary>
        /// <para>
        /// <para>Include the globally unique identifier (GUID) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid
        /// <summary>
        /// <para>
        /// <para>Include the globally unique identifier (GUID) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_SanRequireDns
        /// <summary>
        /// <para>
        /// <para>Include the DNS in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireDns { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_SanRequireDns
        /// <summary>
        /// <para>
        /// <para>Include the DNS in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireDns { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_SanRequireDns
        /// <summary>
        /// <para>
        /// <para>Include the DNS in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireDns { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns
        /// <summary>
        /// <para>
        /// <para>Include the domain DNS in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns
        /// <summary>
        /// <para>
        /// <para>Include the domain DNS in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns
        /// <summary>
        /// <para>
        /// <para>Include the domain DNS in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_SanRequireEmail
        /// <summary>
        /// <para>
        /// <para>Include the subject's email in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireEmail { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_SanRequireEmail
        /// <summary>
        /// <para>
        /// <para>Include the subject's email in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireEmail { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_SanRequireEmail
        /// <summary>
        /// <para>
        /// <para>Include the subject's email in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireEmail { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_SanRequireSpn
        /// <summary>
        /// <para>
        /// <para>Include the service principal name (SPN) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireSpn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_SanRequireSpn
        /// <summary>
        /// <para>
        /// <para>Include the service principal name (SPN) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireSpn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_SanRequireSpn
        /// <summary>
        /// <para>
        /// <para>Include the service principal name (SPN) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireSpn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SubjectNameFlags_SanRequireUpn
        /// <summary>
        /// <para>
        /// <para>Include the user principal name (UPN) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireUpn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SubjectNameFlags_SanRequireUpn
        /// <summary>
        /// <para>
        /// <para>Include the user principal name (UPN) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireUpn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SubjectNameFlags_SanRequireUpn
        /// <summary>
        /// <para>
        /// <para>Include the user principal name (UPN) in the subject alternate name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireUpn { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign
        /// <summary>
        /// <para>
        /// <para>Allow key use for digital signature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign
        /// <summary>
        /// <para>
        /// <para>Allow key use for digital signature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired
        /// <summary>
        /// <para>
        /// <para>Require user input when using the private key for enrollment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired
        /// <summary>
        /// <para>
        /// <para>Requirer user input when using the private key for enrollment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired
        /// <summary>
        /// <para>
        /// <para>Require user input when using the private key for enrollment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_SupersededTemplates
        /// <summary>
        /// <para>
        /// <para>List of templates in Active Directory that are superseded by this template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Definition_TemplateV2_SupersededTemplates { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_SupersededTemplates
        /// <summary>
        /// <para>
        /// <para>List of templates in Active Directory that are superseded by this template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Definition_TemplateV3_SupersededTemplates { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_SupersededTemplates
        /// <summary>
        /// <para>
        /// <para>List of templates in Active Directory that are superseded by this template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Definition_TemplateV4_SupersededTemplates { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata assigned to a template consisting of a key-value pair.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider
        /// <summary>
        /// <para>
        /// <para>Specifies the cryptographic service provider category used to generate private keys.
        /// Set to TRUE to use Legacy Cryptographic Service Providers and FALSE to use Key Storage
        /// Providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV2_EnrollmentFlags_UserInteractionRequired
        /// <summary>
        /// <para>
        /// <para>Require user interaction when the subject is enrolled and the private key associated
        /// with the certificate is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV2_EnrollmentFlags_UserInteractionRequired { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV3_EnrollmentFlags_UserInteractionRequired
        /// <summary>
        /// <para>
        /// <para>Require user interaction when the subject is enrolled and the private key associated
        /// with the certificate is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV3_EnrollmentFlags_UserInteractionRequired { get; set; }
        #endregion
        
        #region Parameter Definition_TemplateV4_EnrollmentFlags_UserInteractionRequired
        /// <summary>
        /// <para>
        /// <para>Require user interaction when the subject is enrolled and the private key associated
        /// with the certificate is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Definition_TemplateV4_EnrollmentFlags_UserInteractionRequired { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TemplateArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorAd.Model.CreateTemplateResponse).
        /// Specifying the name of a property of type Amazon.PcaConnectorAd.Model.CreateTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TemplateArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCAADTemplate (CreateTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorAd.Model.CreateTemplateResponse, NewPCAADTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectorArn = this.ConnectorArn;
            #if MODULAR
            if (this.ConnectorArn == null && ParameterWasBound(nameof(this.ConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Definition_TemplateV2_CertificateValidity_RenewalPeriod_Period = this.Definition_TemplateV2_CertificateValidity_RenewalPeriod_Period;
            context.Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType = this.Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType;
            context.Definition_TemplateV2_CertificateValidity_ValidityPeriod_Period = this.Definition_TemplateV2_CertificateValidity_ValidityPeriod_Period;
            context.Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType = this.Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType;
            context.Definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = this.Definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull;
            context.Definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms = this.Definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms;
            context.Definition_TemplateV2_EnrollmentFlags_NoSecurityExtension = this.Definition_TemplateV2_EnrollmentFlags_NoSecurityExtension;
            context.Definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = this.Definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore;
            context.Definition_TemplateV2_EnrollmentFlags_UserInteractionRequired = this.Definition_TemplateV2_EnrollmentFlags_UserInteractionRequired;
            context.Definition_TemplateV2_Extensions_ApplicationPolicies_Critical = this.Definition_TemplateV2_Extensions_ApplicationPolicies_Critical;
            if (this.Definition_TemplateV2_Extensions_ApplicationPolicies_Policies != null)
            {
                context.Definition_TemplateV2_Extensions_ApplicationPolicies_Policies = new List<Amazon.PcaConnectorAd.Model.ApplicationPolicy>(this.Definition_TemplateV2_Extensions_ApplicationPolicies_Policies);
            }
            context.Definition_TemplateV2_Extensions_KeyUsage_Critical = this.Definition_TemplateV2_Extensions_KeyUsage_Critical;
            context.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment = this.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment;
            context.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature = this.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature;
            context.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement = this.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement;
            context.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment = this.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment;
            context.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation = this.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation;
            context.Definition_TemplateV2_GeneralFlags_AutoEnrollment = this.Definition_TemplateV2_GeneralFlags_AutoEnrollment;
            context.Definition_TemplateV2_GeneralFlags_MachineType = this.Definition_TemplateV2_GeneralFlags_MachineType;
            if (this.Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders != null)
            {
                context.Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders = new List<System.String>(this.Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders);
            }
            context.Definition_TemplateV2_PrivateKeyAttributes_KeySpec = this.Definition_TemplateV2_PrivateKeyAttributes_KeySpec;
            context.Definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength = this.Definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength;
            context.Definition_TemplateV2_PrivateKeyFlags_ClientVersion = this.Definition_TemplateV2_PrivateKeyFlags_ClientVersion;
            context.Definition_TemplateV2_PrivateKeyFlags_ExportableKey = this.Definition_TemplateV2_PrivateKeyFlags_ExportableKey;
            context.Definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired = this.Definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired;
            context.Definition_TemplateV2_SubjectNameFlags_RequireCommonName = this.Definition_TemplateV2_SubjectNameFlags_RequireCommonName;
            context.Definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath = this.Definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath;
            context.Definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn = this.Definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn;
            context.Definition_TemplateV2_SubjectNameFlags_RequireEmail = this.Definition_TemplateV2_SubjectNameFlags_RequireEmail;
            context.Definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid = this.Definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid;
            context.Definition_TemplateV2_SubjectNameFlags_SanRequireDns = this.Definition_TemplateV2_SubjectNameFlags_SanRequireDns;
            context.Definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns = this.Definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns;
            context.Definition_TemplateV2_SubjectNameFlags_SanRequireEmail = this.Definition_TemplateV2_SubjectNameFlags_SanRequireEmail;
            context.Definition_TemplateV2_SubjectNameFlags_SanRequireSpn = this.Definition_TemplateV2_SubjectNameFlags_SanRequireSpn;
            context.Definition_TemplateV2_SubjectNameFlags_SanRequireUpn = this.Definition_TemplateV2_SubjectNameFlags_SanRequireUpn;
            if (this.Definition_TemplateV2_SupersededTemplates != null)
            {
                context.Definition_TemplateV2_SupersededTemplates = new List<System.String>(this.Definition_TemplateV2_SupersededTemplates);
            }
            context.Definition_TemplateV3_CertificateValidity_RenewalPeriod_Period = this.Definition_TemplateV3_CertificateValidity_RenewalPeriod_Period;
            context.Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType = this.Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType;
            context.Definition_TemplateV3_CertificateValidity_ValidityPeriod_Period = this.Definition_TemplateV3_CertificateValidity_ValidityPeriod_Period;
            context.Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType = this.Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType;
            context.Definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = this.Definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull;
            context.Definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms = this.Definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms;
            context.Definition_TemplateV3_EnrollmentFlags_NoSecurityExtension = this.Definition_TemplateV3_EnrollmentFlags_NoSecurityExtension;
            context.Definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = this.Definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore;
            context.Definition_TemplateV3_EnrollmentFlags_UserInteractionRequired = this.Definition_TemplateV3_EnrollmentFlags_UserInteractionRequired;
            context.Definition_TemplateV3_Extensions_ApplicationPolicies_Critical = this.Definition_TemplateV3_Extensions_ApplicationPolicies_Critical;
            if (this.Definition_TemplateV3_Extensions_ApplicationPolicies_Policies != null)
            {
                context.Definition_TemplateV3_Extensions_ApplicationPolicies_Policies = new List<Amazon.PcaConnectorAd.Model.ApplicationPolicy>(this.Definition_TemplateV3_Extensions_ApplicationPolicies_Policies);
            }
            context.Definition_TemplateV3_Extensions_KeyUsage_Critical = this.Definition_TemplateV3_Extensions_KeyUsage_Critical;
            context.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment = this.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment;
            context.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature = this.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature;
            context.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement = this.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement;
            context.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment = this.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment;
            context.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation = this.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation;
            context.Definition_TemplateV3_GeneralFlags_AutoEnrollment = this.Definition_TemplateV3_GeneralFlags_AutoEnrollment;
            context.Definition_TemplateV3_GeneralFlags_MachineType = this.Definition_TemplateV3_GeneralFlags_MachineType;
            context.Definition_TemplateV3_HashAlgorithm = this.Definition_TemplateV3_HashAlgorithm;
            context.Definition_TemplateV3_PrivateKeyAttributes_Algorithm = this.Definition_TemplateV3_PrivateKeyAttributes_Algorithm;
            if (this.Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders != null)
            {
                context.Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders = new List<System.String>(this.Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders);
            }
            context.Definition_TemplateV3_PrivateKeyAttributes_KeySpec = this.Definition_TemplateV3_PrivateKeyAttributes_KeySpec;
            context.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt = this.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt;
            context.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement = this.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement;
            context.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign = this.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign;
            context.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType = this.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType;
            context.Definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength = this.Definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength;
            context.Definition_TemplateV3_PrivateKeyFlags_ClientVersion = this.Definition_TemplateV3_PrivateKeyFlags_ClientVersion;
            context.Definition_TemplateV3_PrivateKeyFlags_ExportableKey = this.Definition_TemplateV3_PrivateKeyFlags_ExportableKey;
            context.Definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm = this.Definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm;
            context.Definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired = this.Definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired;
            context.Definition_TemplateV3_SubjectNameFlags_RequireCommonName = this.Definition_TemplateV3_SubjectNameFlags_RequireCommonName;
            context.Definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath = this.Definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath;
            context.Definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn = this.Definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn;
            context.Definition_TemplateV3_SubjectNameFlags_RequireEmail = this.Definition_TemplateV3_SubjectNameFlags_RequireEmail;
            context.Definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid = this.Definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid;
            context.Definition_TemplateV3_SubjectNameFlags_SanRequireDns = this.Definition_TemplateV3_SubjectNameFlags_SanRequireDns;
            context.Definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns = this.Definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns;
            context.Definition_TemplateV3_SubjectNameFlags_SanRequireEmail = this.Definition_TemplateV3_SubjectNameFlags_SanRequireEmail;
            context.Definition_TemplateV3_SubjectNameFlags_SanRequireSpn = this.Definition_TemplateV3_SubjectNameFlags_SanRequireSpn;
            context.Definition_TemplateV3_SubjectNameFlags_SanRequireUpn = this.Definition_TemplateV3_SubjectNameFlags_SanRequireUpn;
            if (this.Definition_TemplateV3_SupersededTemplates != null)
            {
                context.Definition_TemplateV3_SupersededTemplates = new List<System.String>(this.Definition_TemplateV3_SupersededTemplates);
            }
            context.Definition_TemplateV4_CertificateValidity_RenewalPeriod_Period = this.Definition_TemplateV4_CertificateValidity_RenewalPeriod_Period;
            context.Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType = this.Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType;
            context.Definition_TemplateV4_CertificateValidity_ValidityPeriod_Period = this.Definition_TemplateV4_CertificateValidity_ValidityPeriod_Period;
            context.Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType = this.Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType;
            context.Definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = this.Definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull;
            context.Definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms = this.Definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms;
            context.Definition_TemplateV4_EnrollmentFlags_NoSecurityExtension = this.Definition_TemplateV4_EnrollmentFlags_NoSecurityExtension;
            context.Definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = this.Definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore;
            context.Definition_TemplateV4_EnrollmentFlags_UserInteractionRequired = this.Definition_TemplateV4_EnrollmentFlags_UserInteractionRequired;
            context.Definition_TemplateV4_Extensions_ApplicationPolicies_Critical = this.Definition_TemplateV4_Extensions_ApplicationPolicies_Critical;
            if (this.Definition_TemplateV4_Extensions_ApplicationPolicies_Policies != null)
            {
                context.Definition_TemplateV4_Extensions_ApplicationPolicies_Policies = new List<Amazon.PcaConnectorAd.Model.ApplicationPolicy>(this.Definition_TemplateV4_Extensions_ApplicationPolicies_Policies);
            }
            context.Definition_TemplateV4_Extensions_KeyUsage_Critical = this.Definition_TemplateV4_Extensions_KeyUsage_Critical;
            context.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment = this.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment;
            context.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature = this.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature;
            context.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement = this.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement;
            context.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment = this.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment;
            context.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation = this.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation;
            context.Definition_TemplateV4_GeneralFlags_AutoEnrollment = this.Definition_TemplateV4_GeneralFlags_AutoEnrollment;
            context.Definition_TemplateV4_GeneralFlags_MachineType = this.Definition_TemplateV4_GeneralFlags_MachineType;
            context.Definition_TemplateV4_HashAlgorithm = this.Definition_TemplateV4_HashAlgorithm;
            context.Definition_TemplateV4_PrivateKeyAttributes_Algorithm = this.Definition_TemplateV4_PrivateKeyAttributes_Algorithm;
            if (this.Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders != null)
            {
                context.Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders = new List<System.String>(this.Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders);
            }
            context.Definition_TemplateV4_PrivateKeyAttributes_KeySpec = this.Definition_TemplateV4_PrivateKeyAttributes_KeySpec;
            context.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt = this.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt;
            context.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement = this.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement;
            context.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign = this.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign;
            context.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType = this.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType;
            context.Definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength = this.Definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength;
            context.Definition_TemplateV4_PrivateKeyFlags_ClientVersion = this.Definition_TemplateV4_PrivateKeyFlags_ClientVersion;
            context.Definition_TemplateV4_PrivateKeyFlags_ExportableKey = this.Definition_TemplateV4_PrivateKeyFlags_ExportableKey;
            context.Definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm = this.Definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm;
            context.Definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal = this.Definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal;
            context.Definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired = this.Definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired;
            context.Definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider = this.Definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider;
            context.Definition_TemplateV4_SubjectNameFlags_RequireCommonName = this.Definition_TemplateV4_SubjectNameFlags_RequireCommonName;
            context.Definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath = this.Definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath;
            context.Definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn = this.Definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn;
            context.Definition_TemplateV4_SubjectNameFlags_RequireEmail = this.Definition_TemplateV4_SubjectNameFlags_RequireEmail;
            context.Definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid = this.Definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid;
            context.Definition_TemplateV4_SubjectNameFlags_SanRequireDns = this.Definition_TemplateV4_SubjectNameFlags_SanRequireDns;
            context.Definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns = this.Definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns;
            context.Definition_TemplateV4_SubjectNameFlags_SanRequireEmail = this.Definition_TemplateV4_SubjectNameFlags_SanRequireEmail;
            context.Definition_TemplateV4_SubjectNameFlags_SanRequireSpn = this.Definition_TemplateV4_SubjectNameFlags_SanRequireSpn;
            context.Definition_TemplateV4_SubjectNameFlags_SanRequireUpn = this.Definition_TemplateV4_SubjectNameFlags_SanRequireUpn;
            if (this.Definition_TemplateV4_SupersededTemplates != null)
            {
                context.Definition_TemplateV4_SupersededTemplates = new List<System.String>(this.Definition_TemplateV4_SupersededTemplates);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.PcaConnectorAd.Model.CreateTemplateRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectorArn != null)
            {
                request.ConnectorArn = cmdletContext.ConnectorArn;
            }
            
             // populate Definition
            request.Definition = new Amazon.PcaConnectorAd.Model.TemplateDefinition();
            Amazon.PcaConnectorAd.Model.TemplateV2 requestDefinition_definition_TemplateV2 = null;
            
             // populate TemplateV2
            var requestDefinition_definition_TemplateV2IsNull = true;
            requestDefinition_definition_TemplateV2 = new Amazon.PcaConnectorAd.Model.TemplateV2();
            List<System.String> requestDefinition_definition_TemplateV2_definition_TemplateV2_SupersededTemplates = null;
            if (cmdletContext.Definition_TemplateV2_SupersededTemplates != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SupersededTemplates = cmdletContext.Definition_TemplateV2_SupersededTemplates;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SupersededTemplates != null)
            {
                requestDefinition_definition_TemplateV2.SupersededTemplates = requestDefinition_definition_TemplateV2_definition_TemplateV2_SupersededTemplates;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.CertificateValidity requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity = null;
            
             // populate CertificateValidity
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidityIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity = new Amazon.PcaConnectorAd.Model.CertificateValidity();
            Amazon.PcaConnectorAd.Model.ValidityPeriod requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod = null;
            
             // populate RenewalPeriod
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriodIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod = new Amazon.PcaConnectorAd.Model.ValidityPeriod();
            System.Int64? requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_Period = null;
            if (cmdletContext.Definition_TemplateV2_CertificateValidity_RenewalPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_Period = cmdletContext.Definition_TemplateV2_CertificateValidity_RenewalPeriod_Period.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod.Period = requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_Period.Value;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriodIsNull = false;
            }
            Amazon.PcaConnectorAd.ValidityPeriodType requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType = null;
            if (cmdletContext.Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType = cmdletContext.Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod.PeriodType = requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod_definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriodIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriodIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity.RenewalPeriod = requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_RenewalPeriod;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidityIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.ValidityPeriod requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod = null;
            
             // populate ValidityPeriod
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriodIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod = new Amazon.PcaConnectorAd.Model.ValidityPeriod();
            System.Int64? requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_Period = null;
            if (cmdletContext.Definition_TemplateV2_CertificateValidity_ValidityPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_Period = cmdletContext.Definition_TemplateV2_CertificateValidity_ValidityPeriod_Period.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod.Period = requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_Period.Value;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriodIsNull = false;
            }
            Amazon.PcaConnectorAd.ValidityPeriodType requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType = null;
            if (cmdletContext.Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType = cmdletContext.Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod.PeriodType = requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod_definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriodIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriodIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity.ValidityPeriod = requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity_definition_TemplateV2_CertificateValidity_ValidityPeriod;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidityIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidityIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity != null)
            {
                requestDefinition_definition_TemplateV2.CertificateValidity = requestDefinition_definition_TemplateV2_definition_TemplateV2_CertificateValidity;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.ExtensionsV2 requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions = null;
            
             // populate Extensions
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_ExtensionsIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions = new Amazon.PcaConnectorAd.Model.ExtensionsV2();
            Amazon.PcaConnectorAd.Model.ApplicationPolicies requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies = null;
            
             // populate ApplicationPolicies
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPoliciesIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies = new Amazon.PcaConnectorAd.Model.ApplicationPolicies();
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Critical = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_ApplicationPolicies_Critical != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Critical = cmdletContext.Definition_TemplateV2_Extensions_ApplicationPolicies_Critical.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Critical != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies.Critical = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Critical.Value;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPoliciesIsNull = false;
            }
            List<Amazon.PcaConnectorAd.Model.ApplicationPolicy> requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Policies = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_ApplicationPolicies_Policies != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Policies = cmdletContext.Definition_TemplateV2_Extensions_ApplicationPolicies_Policies;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Policies != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies.Policies = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies_definition_TemplateV2_Extensions_ApplicationPolicies_Policies;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPoliciesIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPoliciesIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions.ApplicationPolicies = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_ApplicationPolicies;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_ExtensionsIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsage requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage = null;
            
             // populate KeyUsage
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsageIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage = new Amazon.PcaConnectorAd.Model.KeyUsage();
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_Critical = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_Critical != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_Critical = cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_Critical.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_Critical != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage.Critical = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_Critical.Value;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsageIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsageFlags requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags = null;
            
             // populate UsageFlags
            requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags = new Amazon.PcaConnectorAd.Model.KeyUsageFlags();
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment = cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags.DataEncipherment = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature = cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags.DigitalSignature = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement = cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags.KeyAgreement = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment = cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags.KeyEncipherment = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation = null;
            if (cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation = cmdletContext.Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags.NonRepudiation = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage.UsageFlags = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage_definition_TemplateV2_Extensions_KeyUsage_UsageFlags;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsageIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsageIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions.KeyUsage = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions_definition_TemplateV2_Extensions_KeyUsage;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_ExtensionsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_ExtensionsIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions != null)
            {
                requestDefinition_definition_TemplateV2.Extensions = requestDefinition_definition_TemplateV2_definition_TemplateV2_Extensions;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.GeneralFlagsV2 requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags = null;
            
             // populate GeneralFlags
            requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags = new Amazon.PcaConnectorAd.Model.GeneralFlagsV2();
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_AutoEnrollment = null;
            if (cmdletContext.Definition_TemplateV2_GeneralFlags_AutoEnrollment != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_AutoEnrollment = cmdletContext.Definition_TemplateV2_GeneralFlags_AutoEnrollment.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_AutoEnrollment != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags.AutoEnrollment = requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_AutoEnrollment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_MachineType = null;
            if (cmdletContext.Definition_TemplateV2_GeneralFlags_MachineType != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_MachineType = cmdletContext.Definition_TemplateV2_GeneralFlags_MachineType.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_MachineType != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags.MachineType = requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags_definition_TemplateV2_GeneralFlags_MachineType.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags != null)
            {
                requestDefinition_definition_TemplateV2.GeneralFlags = requestDefinition_definition_TemplateV2_definition_TemplateV2_GeneralFlags;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.PrivateKeyAttributesV2 requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes = null;
            
             // populate PrivateKeyAttributes
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributesIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes = new Amazon.PcaConnectorAd.Model.PrivateKeyAttributesV2();
            List<System.String> requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_CryptoProviders = null;
            if (cmdletContext.Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_CryptoProviders = cmdletContext.Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_CryptoProviders != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes.CryptoProviders = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_CryptoProviders;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributesIsNull = false;
            }
            Amazon.PcaConnectorAd.KeySpec requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_KeySpec = null;
            if (cmdletContext.Definition_TemplateV2_PrivateKeyAttributes_KeySpec != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_KeySpec = cmdletContext.Definition_TemplateV2_PrivateKeyAttributes_KeySpec;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_KeySpec != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes.KeySpec = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_KeySpec;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributesIsNull = false;
            }
            System.Int32? requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength = null;
            if (cmdletContext.Definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength = cmdletContext.Definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes.MinimalKeyLength = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes_definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength.Value;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributesIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributesIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes != null)
            {
                requestDefinition_definition_TemplateV2.PrivateKeyAttributes = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyAttributes;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.PrivateKeyFlagsV2 requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags = null;
            
             // populate PrivateKeyFlags
            var requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlagsIsNull = true;
            requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags = new Amazon.PcaConnectorAd.Model.PrivateKeyFlagsV2();
            Amazon.PcaConnectorAd.ClientCompatibilityV2 requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ClientVersion = null;
            if (cmdletContext.Definition_TemplateV2_PrivateKeyFlags_ClientVersion != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ClientVersion = cmdletContext.Definition_TemplateV2_PrivateKeyFlags_ClientVersion;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ClientVersion != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags.ClientVersion = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ClientVersion;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ExportableKey = null;
            if (cmdletContext.Definition_TemplateV2_PrivateKeyFlags_ExportableKey != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ExportableKey = cmdletContext.Definition_TemplateV2_PrivateKeyFlags_ExportableKey.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ExportableKey != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags.ExportableKey = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_ExportableKey.Value;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired = null;
            if (cmdletContext.Definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired = cmdletContext.Definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags.StrongKeyProtectionRequired = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags_definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired.Value;
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlagsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags should be set to null
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlagsIsNull)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags = null;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags != null)
            {
                requestDefinition_definition_TemplateV2.PrivateKeyFlags = requestDefinition_definition_TemplateV2_definition_TemplateV2_PrivateKeyFlags;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.EnrollmentFlagsV2 requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags = null;
            
             // populate EnrollmentFlags
            requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags = new Amazon.PcaConnectorAd.Model.EnrollmentFlagsV2();
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = null;
            if (cmdletContext.Definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = cmdletContext.Definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags.EnableKeyReuseOnNtTokenKeysetStorageFull = requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms = null;
            if (cmdletContext.Definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms = cmdletContext.Definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags.IncludeSymmetricAlgorithms = requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_NoSecurityExtension = null;
            if (cmdletContext.Definition_TemplateV2_EnrollmentFlags_NoSecurityExtension != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_NoSecurityExtension = cmdletContext.Definition_TemplateV2_EnrollmentFlags_NoSecurityExtension.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_NoSecurityExtension != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags.NoSecurityExtension = requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_NoSecurityExtension.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = null;
            if (cmdletContext.Definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = cmdletContext.Definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags.RemoveInvalidCertificateFromPersonalStore = requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_UserInteractionRequired = null;
            if (cmdletContext.Definition_TemplateV2_EnrollmentFlags_UserInteractionRequired != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_UserInteractionRequired = cmdletContext.Definition_TemplateV2_EnrollmentFlags_UserInteractionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_UserInteractionRequired != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags.UserInteractionRequired = requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags_definition_TemplateV2_EnrollmentFlags_UserInteractionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags != null)
            {
                requestDefinition_definition_TemplateV2.EnrollmentFlags = requestDefinition_definition_TemplateV2_definition_TemplateV2_EnrollmentFlags;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.SubjectNameFlagsV2 requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags = null;
            
             // populate SubjectNameFlags
            requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags = new Amazon.PcaConnectorAd.Model.SubjectNameFlagsV2();
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireCommonName = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireCommonName != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireCommonName = cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireCommonName.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireCommonName != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.RequireCommonName = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireCommonName.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath = cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.RequireDirectoryPath = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn = cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.RequireDnsAsCn = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireEmail = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireEmail != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireEmail = cmdletContext.Definition_TemplateV2_SubjectNameFlags_RequireEmail.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireEmail != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.RequireEmail = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_RequireEmail.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid = cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.SanRequireDirectoryGuid = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDns = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireDns != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDns = cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireDns.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDns != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.SanRequireDns = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDns.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns = cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.SanRequireDomainDns = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireEmail = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireEmail != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireEmail = cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireEmail.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireEmail != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.SanRequireEmail = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireEmail.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireSpn = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireSpn != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireSpn = cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireSpn.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireSpn != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.SanRequireSpn = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireSpn.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireUpn = null;
            if (cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireUpn != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireUpn = cmdletContext.Definition_TemplateV2_SubjectNameFlags_SanRequireUpn.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireUpn != null)
            {
                requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags.SanRequireUpn = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags_definition_TemplateV2_SubjectNameFlags_SanRequireUpn.Value;
            }
            if (requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags != null)
            {
                requestDefinition_definition_TemplateV2.SubjectNameFlags = requestDefinition_definition_TemplateV2_definition_TemplateV2_SubjectNameFlags;
                requestDefinition_definition_TemplateV2IsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV2 should be set to null
            if (requestDefinition_definition_TemplateV2IsNull)
            {
                requestDefinition_definition_TemplateV2 = null;
            }
            if (requestDefinition_definition_TemplateV2 != null)
            {
                request.Definition.TemplateV2 = requestDefinition_definition_TemplateV2;
            }
            Amazon.PcaConnectorAd.Model.TemplateV3 requestDefinition_definition_TemplateV3 = null;
            
             // populate TemplateV3
            var requestDefinition_definition_TemplateV3IsNull = true;
            requestDefinition_definition_TemplateV3 = new Amazon.PcaConnectorAd.Model.TemplateV3();
            Amazon.PcaConnectorAd.HashAlgorithm requestDefinition_definition_TemplateV3_definition_TemplateV3_HashAlgorithm = null;
            if (cmdletContext.Definition_TemplateV3_HashAlgorithm != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_HashAlgorithm = cmdletContext.Definition_TemplateV3_HashAlgorithm;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_HashAlgorithm != null)
            {
                requestDefinition_definition_TemplateV3.HashAlgorithm = requestDefinition_definition_TemplateV3_definition_TemplateV3_HashAlgorithm;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            List<System.String> requestDefinition_definition_TemplateV3_definition_TemplateV3_SupersededTemplates = null;
            if (cmdletContext.Definition_TemplateV3_SupersededTemplates != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SupersededTemplates = cmdletContext.Definition_TemplateV3_SupersededTemplates;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SupersededTemplates != null)
            {
                requestDefinition_definition_TemplateV3.SupersededTemplates = requestDefinition_definition_TemplateV3_definition_TemplateV3_SupersededTemplates;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.CertificateValidity requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity = null;
            
             // populate CertificateValidity
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidityIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity = new Amazon.PcaConnectorAd.Model.CertificateValidity();
            Amazon.PcaConnectorAd.Model.ValidityPeriod requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod = null;
            
             // populate RenewalPeriod
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriodIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod = new Amazon.PcaConnectorAd.Model.ValidityPeriod();
            System.Int64? requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_Period = null;
            if (cmdletContext.Definition_TemplateV3_CertificateValidity_RenewalPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_Period = cmdletContext.Definition_TemplateV3_CertificateValidity_RenewalPeriod_Period.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod.Period = requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_Period.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriodIsNull = false;
            }
            Amazon.PcaConnectorAd.ValidityPeriodType requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType = null;
            if (cmdletContext.Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType = cmdletContext.Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod.PeriodType = requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod_definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriodIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriodIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity.RenewalPeriod = requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_RenewalPeriod;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidityIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.ValidityPeriod requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod = null;
            
             // populate ValidityPeriod
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriodIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod = new Amazon.PcaConnectorAd.Model.ValidityPeriod();
            System.Int64? requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_Period = null;
            if (cmdletContext.Definition_TemplateV3_CertificateValidity_ValidityPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_Period = cmdletContext.Definition_TemplateV3_CertificateValidity_ValidityPeriod_Period.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod.Period = requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_Period.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriodIsNull = false;
            }
            Amazon.PcaConnectorAd.ValidityPeriodType requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType = null;
            if (cmdletContext.Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType = cmdletContext.Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod.PeriodType = requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod_definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriodIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriodIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity.ValidityPeriod = requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity_definition_TemplateV3_CertificateValidity_ValidityPeriod;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidityIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidityIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity != null)
            {
                requestDefinition_definition_TemplateV3.CertificateValidity = requestDefinition_definition_TemplateV3_definition_TemplateV3_CertificateValidity;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.ExtensionsV3 requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions = null;
            
             // populate Extensions
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_ExtensionsIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions = new Amazon.PcaConnectorAd.Model.ExtensionsV3();
            Amazon.PcaConnectorAd.Model.ApplicationPolicies requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies = null;
            
             // populate ApplicationPolicies
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPoliciesIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies = new Amazon.PcaConnectorAd.Model.ApplicationPolicies();
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Critical = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_ApplicationPolicies_Critical != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Critical = cmdletContext.Definition_TemplateV3_Extensions_ApplicationPolicies_Critical.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Critical != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies.Critical = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Critical.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPoliciesIsNull = false;
            }
            List<Amazon.PcaConnectorAd.Model.ApplicationPolicy> requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Policies = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_ApplicationPolicies_Policies != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Policies = cmdletContext.Definition_TemplateV3_Extensions_ApplicationPolicies_Policies;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Policies != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies.Policies = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies_definition_TemplateV3_Extensions_ApplicationPolicies_Policies;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPoliciesIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPoliciesIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions.ApplicationPolicies = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_ApplicationPolicies;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_ExtensionsIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsage requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage = null;
            
             // populate KeyUsage
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsageIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage = new Amazon.PcaConnectorAd.Model.KeyUsage();
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_Critical = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_Critical != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_Critical = cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_Critical.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_Critical != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage.Critical = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_Critical.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsageIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsageFlags requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags = null;
            
             // populate UsageFlags
            requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags = new Amazon.PcaConnectorAd.Model.KeyUsageFlags();
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment = cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags.DataEncipherment = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature = cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags.DigitalSignature = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement = cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags.KeyAgreement = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment = cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags.KeyEncipherment = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation = null;
            if (cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation = cmdletContext.Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags.NonRepudiation = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage.UsageFlags = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage_definition_TemplateV3_Extensions_KeyUsage_UsageFlags;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsageIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsageIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions.KeyUsage = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions_definition_TemplateV3_Extensions_KeyUsage;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_ExtensionsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_ExtensionsIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions != null)
            {
                requestDefinition_definition_TemplateV3.Extensions = requestDefinition_definition_TemplateV3_definition_TemplateV3_Extensions;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.GeneralFlagsV3 requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags = null;
            
             // populate GeneralFlags
            requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags = new Amazon.PcaConnectorAd.Model.GeneralFlagsV3();
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_AutoEnrollment = null;
            if (cmdletContext.Definition_TemplateV3_GeneralFlags_AutoEnrollment != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_AutoEnrollment = cmdletContext.Definition_TemplateV3_GeneralFlags_AutoEnrollment.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_AutoEnrollment != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags.AutoEnrollment = requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_AutoEnrollment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_MachineType = null;
            if (cmdletContext.Definition_TemplateV3_GeneralFlags_MachineType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_MachineType = cmdletContext.Definition_TemplateV3_GeneralFlags_MachineType.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_MachineType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags.MachineType = requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags_definition_TemplateV3_GeneralFlags_MachineType.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags != null)
            {
                requestDefinition_definition_TemplateV3.GeneralFlags = requestDefinition_definition_TemplateV3_definition_TemplateV3_GeneralFlags;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.PrivateKeyFlagsV3 requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags = null;
            
             // populate PrivateKeyFlags
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlagsIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags = new Amazon.PcaConnectorAd.Model.PrivateKeyFlagsV3();
            Amazon.PcaConnectorAd.ClientCompatibilityV3 requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ClientVersion = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyFlags_ClientVersion != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ClientVersion = cmdletContext.Definition_TemplateV3_PrivateKeyFlags_ClientVersion;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ClientVersion != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags.ClientVersion = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ClientVersion;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ExportableKey = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyFlags_ExportableKey != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ExportableKey = cmdletContext.Definition_TemplateV3_PrivateKeyFlags_ExportableKey.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ExportableKey != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags.ExportableKey = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_ExportableKey.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm = cmdletContext.Definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags.RequireAlternateSignatureAlgorithm = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired = cmdletContext.Definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags.StrongKeyProtectionRequired = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags_definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlagsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlagsIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags != null)
            {
                requestDefinition_definition_TemplateV3.PrivateKeyFlags = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyFlags;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.EnrollmentFlagsV3 requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags = null;
            
             // populate EnrollmentFlags
            requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags = new Amazon.PcaConnectorAd.Model.EnrollmentFlagsV3();
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = null;
            if (cmdletContext.Definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = cmdletContext.Definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags.EnableKeyReuseOnNtTokenKeysetStorageFull = requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms = null;
            if (cmdletContext.Definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms = cmdletContext.Definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags.IncludeSymmetricAlgorithms = requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_NoSecurityExtension = null;
            if (cmdletContext.Definition_TemplateV3_EnrollmentFlags_NoSecurityExtension != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_NoSecurityExtension = cmdletContext.Definition_TemplateV3_EnrollmentFlags_NoSecurityExtension.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_NoSecurityExtension != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags.NoSecurityExtension = requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_NoSecurityExtension.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = null;
            if (cmdletContext.Definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = cmdletContext.Definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags.RemoveInvalidCertificateFromPersonalStore = requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_UserInteractionRequired = null;
            if (cmdletContext.Definition_TemplateV3_EnrollmentFlags_UserInteractionRequired != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_UserInteractionRequired = cmdletContext.Definition_TemplateV3_EnrollmentFlags_UserInteractionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_UserInteractionRequired != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags.UserInteractionRequired = requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags_definition_TemplateV3_EnrollmentFlags_UserInteractionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags != null)
            {
                requestDefinition_definition_TemplateV3.EnrollmentFlags = requestDefinition_definition_TemplateV3_definition_TemplateV3_EnrollmentFlags;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.PrivateKeyAttributesV3 requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes = null;
            
             // populate PrivateKeyAttributes
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributesIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes = new Amazon.PcaConnectorAd.Model.PrivateKeyAttributesV3();
            Amazon.PcaConnectorAd.PrivateKeyAlgorithm requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_Algorithm = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_Algorithm != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_Algorithm = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_Algorithm;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_Algorithm != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes.Algorithm = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_Algorithm;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributesIsNull = false;
            }
            List<System.String> requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_CryptoProviders = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_CryptoProviders = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_CryptoProviders != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes.CryptoProviders = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_CryptoProviders;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributesIsNull = false;
            }
            Amazon.PcaConnectorAd.KeySpec requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeySpec = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeySpec != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeySpec = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeySpec;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeySpec != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes.KeySpec = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeySpec;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributesIsNull = false;
            }
            System.Int32? requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes.MinimalKeyLength = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributesIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsageProperty requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty = null;
            
             // populate KeyUsageProperty
            requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty = new Amazon.PcaConnectorAd.Model.KeyUsageProperty();
            Amazon.PcaConnectorAd.KeyUsagePropertyType requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty.PropertyType = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType;
            }
            Amazon.PcaConnectorAd.Model.KeyUsagePropertyFlags requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags = null;
            
             // populate PropertyFlags
            var requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = true;
            requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags = new Amazon.PcaConnectorAd.Model.KeyUsagePropertyFlags();
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags.Decrypt = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags.KeyAgreement = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign = null;
            if (cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign = cmdletContext.Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags.Sign = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign.Value;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty.PropertyFlags = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes.KeyUsageProperty = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes_definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty;
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributesIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes should be set to null
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributesIsNull)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes = null;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes != null)
            {
                requestDefinition_definition_TemplateV3.PrivateKeyAttributes = requestDefinition_definition_TemplateV3_definition_TemplateV3_PrivateKeyAttributes;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.SubjectNameFlagsV3 requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags = null;
            
             // populate SubjectNameFlags
            requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags = new Amazon.PcaConnectorAd.Model.SubjectNameFlagsV3();
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireCommonName = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireCommonName != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireCommonName = cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireCommonName.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireCommonName != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.RequireCommonName = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireCommonName.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath = cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.RequireDirectoryPath = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn = cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.RequireDnsAsCn = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireEmail = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireEmail != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireEmail = cmdletContext.Definition_TemplateV3_SubjectNameFlags_RequireEmail.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireEmail != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.RequireEmail = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_RequireEmail.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid = cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.SanRequireDirectoryGuid = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDns = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireDns != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDns = cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireDns.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDns != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.SanRequireDns = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDns.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns = cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.SanRequireDomainDns = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireEmail = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireEmail != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireEmail = cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireEmail.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireEmail != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.SanRequireEmail = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireEmail.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireSpn = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireSpn != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireSpn = cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireSpn.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireSpn != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.SanRequireSpn = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireSpn.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireUpn = null;
            if (cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireUpn != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireUpn = cmdletContext.Definition_TemplateV3_SubjectNameFlags_SanRequireUpn.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireUpn != null)
            {
                requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags.SanRequireUpn = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags_definition_TemplateV3_SubjectNameFlags_SanRequireUpn.Value;
            }
            if (requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags != null)
            {
                requestDefinition_definition_TemplateV3.SubjectNameFlags = requestDefinition_definition_TemplateV3_definition_TemplateV3_SubjectNameFlags;
                requestDefinition_definition_TemplateV3IsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV3 should be set to null
            if (requestDefinition_definition_TemplateV3IsNull)
            {
                requestDefinition_definition_TemplateV3 = null;
            }
            if (requestDefinition_definition_TemplateV3 != null)
            {
                request.Definition.TemplateV3 = requestDefinition_definition_TemplateV3;
            }
            Amazon.PcaConnectorAd.Model.TemplateV4 requestDefinition_definition_TemplateV4 = null;
            
             // populate TemplateV4
            var requestDefinition_definition_TemplateV4IsNull = true;
            requestDefinition_definition_TemplateV4 = new Amazon.PcaConnectorAd.Model.TemplateV4();
            Amazon.PcaConnectorAd.HashAlgorithm requestDefinition_definition_TemplateV4_definition_TemplateV4_HashAlgorithm = null;
            if (cmdletContext.Definition_TemplateV4_HashAlgorithm != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_HashAlgorithm = cmdletContext.Definition_TemplateV4_HashAlgorithm;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_HashAlgorithm != null)
            {
                requestDefinition_definition_TemplateV4.HashAlgorithm = requestDefinition_definition_TemplateV4_definition_TemplateV4_HashAlgorithm;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            List<System.String> requestDefinition_definition_TemplateV4_definition_TemplateV4_SupersededTemplates = null;
            if (cmdletContext.Definition_TemplateV4_SupersededTemplates != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SupersededTemplates = cmdletContext.Definition_TemplateV4_SupersededTemplates;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SupersededTemplates != null)
            {
                requestDefinition_definition_TemplateV4.SupersededTemplates = requestDefinition_definition_TemplateV4_definition_TemplateV4_SupersededTemplates;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.CertificateValidity requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity = null;
            
             // populate CertificateValidity
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidityIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity = new Amazon.PcaConnectorAd.Model.CertificateValidity();
            Amazon.PcaConnectorAd.Model.ValidityPeriod requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod = null;
            
             // populate RenewalPeriod
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriodIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod = new Amazon.PcaConnectorAd.Model.ValidityPeriod();
            System.Int64? requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_Period = null;
            if (cmdletContext.Definition_TemplateV4_CertificateValidity_RenewalPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_Period = cmdletContext.Definition_TemplateV4_CertificateValidity_RenewalPeriod_Period.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod.Period = requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_Period.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriodIsNull = false;
            }
            Amazon.PcaConnectorAd.ValidityPeriodType requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType = null;
            if (cmdletContext.Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType = cmdletContext.Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod.PeriodType = requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod_definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriodIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriodIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity.RenewalPeriod = requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_RenewalPeriod;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidityIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.ValidityPeriod requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod = null;
            
             // populate ValidityPeriod
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriodIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod = new Amazon.PcaConnectorAd.Model.ValidityPeriod();
            System.Int64? requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_Period = null;
            if (cmdletContext.Definition_TemplateV4_CertificateValidity_ValidityPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_Period = cmdletContext.Definition_TemplateV4_CertificateValidity_ValidityPeriod_Period.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_Period != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod.Period = requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_Period.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriodIsNull = false;
            }
            Amazon.PcaConnectorAd.ValidityPeriodType requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType = null;
            if (cmdletContext.Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType = cmdletContext.Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod.PeriodType = requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod_definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriodIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriodIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity.ValidityPeriod = requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity_definition_TemplateV4_CertificateValidity_ValidityPeriod;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidityIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidityIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity != null)
            {
                requestDefinition_definition_TemplateV4.CertificateValidity = requestDefinition_definition_TemplateV4_definition_TemplateV4_CertificateValidity;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.ExtensionsV4 requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions = null;
            
             // populate Extensions
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_ExtensionsIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions = new Amazon.PcaConnectorAd.Model.ExtensionsV4();
            Amazon.PcaConnectorAd.Model.ApplicationPolicies requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies = null;
            
             // populate ApplicationPolicies
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPoliciesIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies = new Amazon.PcaConnectorAd.Model.ApplicationPolicies();
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Critical = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_ApplicationPolicies_Critical != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Critical = cmdletContext.Definition_TemplateV4_Extensions_ApplicationPolicies_Critical.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Critical != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies.Critical = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Critical.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPoliciesIsNull = false;
            }
            List<Amazon.PcaConnectorAd.Model.ApplicationPolicy> requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Policies = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_ApplicationPolicies_Policies != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Policies = cmdletContext.Definition_TemplateV4_Extensions_ApplicationPolicies_Policies;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Policies != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies.Policies = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies_definition_TemplateV4_Extensions_ApplicationPolicies_Policies;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPoliciesIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPoliciesIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions.ApplicationPolicies = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_ApplicationPolicies;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_ExtensionsIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsage requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage = null;
            
             // populate KeyUsage
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsageIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage = new Amazon.PcaConnectorAd.Model.KeyUsage();
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_Critical = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_Critical != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_Critical = cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_Critical.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_Critical != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage.Critical = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_Critical.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsageIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsageFlags requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags = null;
            
             // populate UsageFlags
            requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags = new Amazon.PcaConnectorAd.Model.KeyUsageFlags();
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment = cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags.DataEncipherment = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature = cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags.DigitalSignature = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement = cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags.KeyAgreement = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment = cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags.KeyEncipherment = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation = null;
            if (cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation = cmdletContext.Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags.NonRepudiation = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage.UsageFlags = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage_definition_TemplateV4_Extensions_KeyUsage_UsageFlags;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsageIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsageIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions.KeyUsage = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions_definition_TemplateV4_Extensions_KeyUsage;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_ExtensionsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_ExtensionsIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions != null)
            {
                requestDefinition_definition_TemplateV4.Extensions = requestDefinition_definition_TemplateV4_definition_TemplateV4_Extensions;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.GeneralFlagsV4 requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags = null;
            
             // populate GeneralFlags
            requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags = new Amazon.PcaConnectorAd.Model.GeneralFlagsV4();
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_AutoEnrollment = null;
            if (cmdletContext.Definition_TemplateV4_GeneralFlags_AutoEnrollment != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_AutoEnrollment = cmdletContext.Definition_TemplateV4_GeneralFlags_AutoEnrollment.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_AutoEnrollment != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags.AutoEnrollment = requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_AutoEnrollment.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_MachineType = null;
            if (cmdletContext.Definition_TemplateV4_GeneralFlags_MachineType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_MachineType = cmdletContext.Definition_TemplateV4_GeneralFlags_MachineType.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_MachineType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags.MachineType = requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags_definition_TemplateV4_GeneralFlags_MachineType.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags != null)
            {
                requestDefinition_definition_TemplateV4.GeneralFlags = requestDefinition_definition_TemplateV4_definition_TemplateV4_GeneralFlags;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.EnrollmentFlagsV4 requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags = null;
            
             // populate EnrollmentFlags
            requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags = new Amazon.PcaConnectorAd.Model.EnrollmentFlagsV4();
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = null;
            if (cmdletContext.Definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull = cmdletContext.Definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags.EnableKeyReuseOnNtTokenKeysetStorageFull = requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms = null;
            if (cmdletContext.Definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms = cmdletContext.Definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags.IncludeSymmetricAlgorithms = requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_NoSecurityExtension = null;
            if (cmdletContext.Definition_TemplateV4_EnrollmentFlags_NoSecurityExtension != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_NoSecurityExtension = cmdletContext.Definition_TemplateV4_EnrollmentFlags_NoSecurityExtension.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_NoSecurityExtension != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags.NoSecurityExtension = requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_NoSecurityExtension.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = null;
            if (cmdletContext.Definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore = cmdletContext.Definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags.RemoveInvalidCertificateFromPersonalStore = requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_UserInteractionRequired = null;
            if (cmdletContext.Definition_TemplateV4_EnrollmentFlags_UserInteractionRequired != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_UserInteractionRequired = cmdletContext.Definition_TemplateV4_EnrollmentFlags_UserInteractionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_UserInteractionRequired != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags.UserInteractionRequired = requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags_definition_TemplateV4_EnrollmentFlags_UserInteractionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags != null)
            {
                requestDefinition_definition_TemplateV4.EnrollmentFlags = requestDefinition_definition_TemplateV4_definition_TemplateV4_EnrollmentFlags;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.PrivateKeyAttributesV4 requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes = null;
            
             // populate PrivateKeyAttributes
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributesIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes = new Amazon.PcaConnectorAd.Model.PrivateKeyAttributesV4();
            Amazon.PcaConnectorAd.PrivateKeyAlgorithm requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_Algorithm = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_Algorithm != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_Algorithm = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_Algorithm;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_Algorithm != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes.Algorithm = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_Algorithm;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributesIsNull = false;
            }
            List<System.String> requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_CryptoProviders = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_CryptoProviders = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_CryptoProviders != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes.CryptoProviders = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_CryptoProviders;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributesIsNull = false;
            }
            Amazon.PcaConnectorAd.KeySpec requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeySpec = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeySpec != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeySpec = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeySpec;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeySpec != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes.KeySpec = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeySpec;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributesIsNull = false;
            }
            System.Int32? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes.MinimalKeyLength = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributesIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsageProperty requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty = null;
            
             // populate KeyUsageProperty
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsagePropertyIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty = new Amazon.PcaConnectorAd.Model.KeyUsageProperty();
            Amazon.PcaConnectorAd.KeyUsagePropertyType requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty.PropertyType = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsagePropertyIsNull = false;
            }
            Amazon.PcaConnectorAd.Model.KeyUsagePropertyFlags requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags = null;
            
             // populate PropertyFlags
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags = new Amazon.PcaConnectorAd.Model.KeyUsagePropertyFlags();
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags.Decrypt = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags.KeyAgreement = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign = cmdletContext.Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags.Sign = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlagsIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty.PropertyFlags = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsagePropertyIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsagePropertyIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes.KeyUsageProperty = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes_definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributesIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributesIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes != null)
            {
                requestDefinition_definition_TemplateV4.PrivateKeyAttributes = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyAttributes;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.PrivateKeyFlagsV4 requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags = null;
            
             // populate PrivateKeyFlags
            var requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull = true;
            requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags = new Amazon.PcaConnectorAd.Model.PrivateKeyFlagsV4();
            Amazon.PcaConnectorAd.ClientCompatibilityV4 requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ClientVersion = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyFlags_ClientVersion != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ClientVersion = cmdletContext.Definition_TemplateV4_PrivateKeyFlags_ClientVersion;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ClientVersion != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags.ClientVersion = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ClientVersion;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ExportableKey = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyFlags_ExportableKey != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ExportableKey = cmdletContext.Definition_TemplateV4_PrivateKeyFlags_ExportableKey.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ExportableKey != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags.ExportableKey = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_ExportableKey.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm = cmdletContext.Definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags.RequireAlternateSignatureAlgorithm = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal = cmdletContext.Definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags.RequireSameKeyRenewal = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired = cmdletContext.Definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags.StrongKeyProtectionRequired = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull = false;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider = null;
            if (cmdletContext.Definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider = cmdletContext.Definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags.UseLegacyProvider = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags_definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider.Value;
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags should be set to null
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlagsIsNull)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags = null;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags != null)
            {
                requestDefinition_definition_TemplateV4.PrivateKeyFlags = requestDefinition_definition_TemplateV4_definition_TemplateV4_PrivateKeyFlags;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
            Amazon.PcaConnectorAd.Model.SubjectNameFlagsV4 requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags = null;
            
             // populate SubjectNameFlags
            requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags = new Amazon.PcaConnectorAd.Model.SubjectNameFlagsV4();
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireCommonName = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireCommonName != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireCommonName = cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireCommonName.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireCommonName != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.RequireCommonName = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireCommonName.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath = cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.RequireDirectoryPath = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn = cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.RequireDnsAsCn = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireEmail = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireEmail != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireEmail = cmdletContext.Definition_TemplateV4_SubjectNameFlags_RequireEmail.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireEmail != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.RequireEmail = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_RequireEmail.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid = cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.SanRequireDirectoryGuid = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDns = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireDns != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDns = cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireDns.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDns != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.SanRequireDns = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDns.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns = cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.SanRequireDomainDns = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireEmail = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireEmail != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireEmail = cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireEmail.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireEmail != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.SanRequireEmail = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireEmail.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireSpn = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireSpn != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireSpn = cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireSpn.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireSpn != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.SanRequireSpn = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireSpn.Value;
            }
            System.Boolean? requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireUpn = null;
            if (cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireUpn != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireUpn = cmdletContext.Definition_TemplateV4_SubjectNameFlags_SanRequireUpn.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireUpn != null)
            {
                requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags.SanRequireUpn = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags_definition_TemplateV4_SubjectNameFlags_SanRequireUpn.Value;
            }
            if (requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags != null)
            {
                requestDefinition_definition_TemplateV4.SubjectNameFlags = requestDefinition_definition_TemplateV4_definition_TemplateV4_SubjectNameFlags;
                requestDefinition_definition_TemplateV4IsNull = false;
            }
             // determine if requestDefinition_definition_TemplateV4 should be set to null
            if (requestDefinition_definition_TemplateV4IsNull)
            {
                requestDefinition_definition_TemplateV4 = null;
            }
            if (requestDefinition_definition_TemplateV4 != null)
            {
                request.Definition.TemplateV4 = requestDefinition_definition_TemplateV4;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.PcaConnectorAd.Model.CreateTemplateResponse CallAWSServiceOperation(IAmazonPcaConnectorAd client, Amazon.PcaConnectorAd.Model.CreateTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Pca Connector Ad", "CreateTemplate");
            try
            {
                return client.CreateTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectorArn { get; set; }
            public System.Int64? Definition_TemplateV2_CertificateValidity_RenewalPeriod_Period { get; set; }
            public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV2_CertificateValidity_RenewalPeriod_PeriodType { get; set; }
            public System.Int64? Definition_TemplateV2_CertificateValidity_ValidityPeriod_Period { get; set; }
            public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV2_CertificateValidity_ValidityPeriod_PeriodType { get; set; }
            public System.Boolean? Definition_TemplateV2_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull { get; set; }
            public System.Boolean? Definition_TemplateV2_EnrollmentFlags_IncludeSymmetricAlgorithms { get; set; }
            public System.Boolean? Definition_TemplateV2_EnrollmentFlags_NoSecurityExtension { get; set; }
            public System.Boolean? Definition_TemplateV2_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore { get; set; }
            public System.Boolean? Definition_TemplateV2_EnrollmentFlags_UserInteractionRequired { get; set; }
            public System.Boolean? Definition_TemplateV2_Extensions_ApplicationPolicies_Critical { get; set; }
            public List<Amazon.PcaConnectorAd.Model.ApplicationPolicy> Definition_TemplateV2_Extensions_ApplicationPolicies_Policies { get; set; }
            public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_Critical { get; set; }
            public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DataEncipherment { get; set; }
            public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_DigitalSignature { get; set; }
            public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyAgreement { get; set; }
            public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_KeyEncipherment { get; set; }
            public System.Boolean? Definition_TemplateV2_Extensions_KeyUsage_UsageFlags_NonRepudiation { get; set; }
            public System.Boolean? Definition_TemplateV2_GeneralFlags_AutoEnrollment { get; set; }
            public System.Boolean? Definition_TemplateV2_GeneralFlags_MachineType { get; set; }
            public List<System.String> Definition_TemplateV2_PrivateKeyAttributes_CryptoProviders { get; set; }
            public Amazon.PcaConnectorAd.KeySpec Definition_TemplateV2_PrivateKeyAttributes_KeySpec { get; set; }
            public System.Int32? Definition_TemplateV2_PrivateKeyAttributes_MinimalKeyLength { get; set; }
            public Amazon.PcaConnectorAd.ClientCompatibilityV2 Definition_TemplateV2_PrivateKeyFlags_ClientVersion { get; set; }
            public System.Boolean? Definition_TemplateV2_PrivateKeyFlags_ExportableKey { get; set; }
            public System.Boolean? Definition_TemplateV2_PrivateKeyFlags_StrongKeyProtectionRequired { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireCommonName { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireDirectoryPath { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireDnsAsCn { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_RequireEmail { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireDirectoryGuid { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireDns { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireDomainDns { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireEmail { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireSpn { get; set; }
            public System.Boolean? Definition_TemplateV2_SubjectNameFlags_SanRequireUpn { get; set; }
            public List<System.String> Definition_TemplateV2_SupersededTemplates { get; set; }
            public System.Int64? Definition_TemplateV3_CertificateValidity_RenewalPeriod_Period { get; set; }
            public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV3_CertificateValidity_RenewalPeriod_PeriodType { get; set; }
            public System.Int64? Definition_TemplateV3_CertificateValidity_ValidityPeriod_Period { get; set; }
            public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV3_CertificateValidity_ValidityPeriod_PeriodType { get; set; }
            public System.Boolean? Definition_TemplateV3_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull { get; set; }
            public System.Boolean? Definition_TemplateV3_EnrollmentFlags_IncludeSymmetricAlgorithms { get; set; }
            public System.Boolean? Definition_TemplateV3_EnrollmentFlags_NoSecurityExtension { get; set; }
            public System.Boolean? Definition_TemplateV3_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore { get; set; }
            public System.Boolean? Definition_TemplateV3_EnrollmentFlags_UserInteractionRequired { get; set; }
            public System.Boolean? Definition_TemplateV3_Extensions_ApplicationPolicies_Critical { get; set; }
            public List<Amazon.PcaConnectorAd.Model.ApplicationPolicy> Definition_TemplateV3_Extensions_ApplicationPolicies_Policies { get; set; }
            public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_Critical { get; set; }
            public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DataEncipherment { get; set; }
            public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_DigitalSignature { get; set; }
            public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyAgreement { get; set; }
            public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_KeyEncipherment { get; set; }
            public System.Boolean? Definition_TemplateV3_Extensions_KeyUsage_UsageFlags_NonRepudiation { get; set; }
            public System.Boolean? Definition_TemplateV3_GeneralFlags_AutoEnrollment { get; set; }
            public System.Boolean? Definition_TemplateV3_GeneralFlags_MachineType { get; set; }
            public Amazon.PcaConnectorAd.HashAlgorithm Definition_TemplateV3_HashAlgorithm { get; set; }
            public Amazon.PcaConnectorAd.PrivateKeyAlgorithm Definition_TemplateV3_PrivateKeyAttributes_Algorithm { get; set; }
            public List<System.String> Definition_TemplateV3_PrivateKeyAttributes_CryptoProviders { get; set; }
            public Amazon.PcaConnectorAd.KeySpec Definition_TemplateV3_PrivateKeyAttributes_KeySpec { get; set; }
            public System.Boolean? Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt { get; set; }
            public System.Boolean? Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement { get; set; }
            public System.Boolean? Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign { get; set; }
            public Amazon.PcaConnectorAd.KeyUsagePropertyType Definition_TemplateV3_PrivateKeyAttributes_KeyUsageProperty_PropertyType { get; set; }
            public System.Int32? Definition_TemplateV3_PrivateKeyAttributes_MinimalKeyLength { get; set; }
            public Amazon.PcaConnectorAd.ClientCompatibilityV3 Definition_TemplateV3_PrivateKeyFlags_ClientVersion { get; set; }
            public System.Boolean? Definition_TemplateV3_PrivateKeyFlags_ExportableKey { get; set; }
            public System.Boolean? Definition_TemplateV3_PrivateKeyFlags_RequireAlternateSignatureAlgorithm { get; set; }
            public System.Boolean? Definition_TemplateV3_PrivateKeyFlags_StrongKeyProtectionRequired { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireCommonName { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireDirectoryPath { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireDnsAsCn { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_RequireEmail { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireDirectoryGuid { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireDns { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireDomainDns { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireEmail { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireSpn { get; set; }
            public System.Boolean? Definition_TemplateV3_SubjectNameFlags_SanRequireUpn { get; set; }
            public List<System.String> Definition_TemplateV3_SupersededTemplates { get; set; }
            public System.Int64? Definition_TemplateV4_CertificateValidity_RenewalPeriod_Period { get; set; }
            public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV4_CertificateValidity_RenewalPeriod_PeriodType { get; set; }
            public System.Int64? Definition_TemplateV4_CertificateValidity_ValidityPeriod_Period { get; set; }
            public Amazon.PcaConnectorAd.ValidityPeriodType Definition_TemplateV4_CertificateValidity_ValidityPeriod_PeriodType { get; set; }
            public System.Boolean? Definition_TemplateV4_EnrollmentFlags_EnableKeyReuseOnNtTokenKeysetStorageFull { get; set; }
            public System.Boolean? Definition_TemplateV4_EnrollmentFlags_IncludeSymmetricAlgorithms { get; set; }
            public System.Boolean? Definition_TemplateV4_EnrollmentFlags_NoSecurityExtension { get; set; }
            public System.Boolean? Definition_TemplateV4_EnrollmentFlags_RemoveInvalidCertificateFromPersonalStore { get; set; }
            public System.Boolean? Definition_TemplateV4_EnrollmentFlags_UserInteractionRequired { get; set; }
            public System.Boolean? Definition_TemplateV4_Extensions_ApplicationPolicies_Critical { get; set; }
            public List<Amazon.PcaConnectorAd.Model.ApplicationPolicy> Definition_TemplateV4_Extensions_ApplicationPolicies_Policies { get; set; }
            public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_Critical { get; set; }
            public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DataEncipherment { get; set; }
            public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_DigitalSignature { get; set; }
            public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyAgreement { get; set; }
            public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_KeyEncipherment { get; set; }
            public System.Boolean? Definition_TemplateV4_Extensions_KeyUsage_UsageFlags_NonRepudiation { get; set; }
            public System.Boolean? Definition_TemplateV4_GeneralFlags_AutoEnrollment { get; set; }
            public System.Boolean? Definition_TemplateV4_GeneralFlags_MachineType { get; set; }
            public Amazon.PcaConnectorAd.HashAlgorithm Definition_TemplateV4_HashAlgorithm { get; set; }
            public Amazon.PcaConnectorAd.PrivateKeyAlgorithm Definition_TemplateV4_PrivateKeyAttributes_Algorithm { get; set; }
            public List<System.String> Definition_TemplateV4_PrivateKeyAttributes_CryptoProviders { get; set; }
            public Amazon.PcaConnectorAd.KeySpec Definition_TemplateV4_PrivateKeyAttributes_KeySpec { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Decrypt { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_KeyAgreement { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyFlags_Sign { get; set; }
            public Amazon.PcaConnectorAd.KeyUsagePropertyType Definition_TemplateV4_PrivateKeyAttributes_KeyUsageProperty_PropertyType { get; set; }
            public System.Int32? Definition_TemplateV4_PrivateKeyAttributes_MinimalKeyLength { get; set; }
            public Amazon.PcaConnectorAd.ClientCompatibilityV4 Definition_TemplateV4_PrivateKeyFlags_ClientVersion { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_ExportableKey { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_RequireAlternateSignatureAlgorithm { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_RequireSameKeyRenewal { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_StrongKeyProtectionRequired { get; set; }
            public System.Boolean? Definition_TemplateV4_PrivateKeyFlags_UseLegacyProvider { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireCommonName { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireDirectoryPath { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireDnsAsCn { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_RequireEmail { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireDirectoryGuid { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireDns { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireDomainDns { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireEmail { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireSpn { get; set; }
            public System.Boolean? Definition_TemplateV4_SubjectNameFlags_SanRequireUpn { get; set; }
            public List<System.String> Definition_TemplateV4_SupersededTemplates { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.PcaConnectorAd.Model.CreateTemplateResponse, NewPCAADTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TemplateArn;
        }
        
    }
}
