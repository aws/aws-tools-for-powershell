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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Uses your private certificate authority (CA), or one that has been shared with you,
    /// to issue a client certificate. This action returns the Amazon Resource Name (ARN)
    /// of the certificate. You can retrieve the certificate by calling the <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_GetCertificate.html">GetCertificate</a>
    /// action and specifying the ARN. 
    /// 
    ///  <note><para>
    /// You cannot use the ACM <b>ListCertificateAuthorities</b> action to retrieve the ARNs
    /// of the certificates that you issue by using ACM Private CA.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "PCACertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority IssueCertificate API operation.", Operation = new[] {"IssueCertificate"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.IssueCertificateResponse))]
    [AWSCmdletOutput("System.String or Amazon.ACMPCA.Model.IssueCertificateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ACMPCA.Model.IssueCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPCACertificateCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_CreateCertificateAuthority.html">CreateCertificateAuthority</a>.
        /// This must be of the form:</para><para><code>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code></para>
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
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter Extensions_CertificatePolicy
        /// <summary>
        /// <para>
        /// <para>Contains a sequence of one or more policy information terms, each of which consists
        /// of an object identifier (OID) and optional qualifiers. For more information, see NIST's
        /// definition of <a href="https://csrc.nist.gov/glossary/term/Object_Identifier">Object
        /// Identifier (OID)</a>.</para><para>In an end-entity certificate, these terms indicate the policy under which the certificate
        /// was issued and the purposes for which it may be used. In a CA certificate, these terms
        /// limit the set of policies for certification paths that include this certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_CertificatePolicies")]
        public Amazon.ACMPCA.Model.PolicyInformation[] Extensions_CertificatePolicy { get; set; }
        #endregion
        
        #region Parameter Subject_CommonName
        /// <summary>
        /// <para>
        /// <para>For CA and end-entity certificates in a private PKI, the common name (CN) can be any
        /// string within the length limit. </para><para>Note: In publicly trusted certificates, the common name must be a fully qualified
        /// domain name (FQDN) associated with the certificate subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_CommonName")]
        public System.String Subject_CommonName { get; set; }
        #endregion
        
        #region Parameter Subject_Country
        /// <summary>
        /// <para>
        /// <para>Two-digit code that specifies the country in which the certificate subject located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_Country")]
        public System.String Subject_Country { get; set; }
        #endregion
        
        #region Parameter KeyUsage_CRLSign
        /// <summary>
        /// <para>
        /// <para>Key can be used to sign CRLs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_CRLSign")]
        public System.Boolean? KeyUsage_CRLSign { get; set; }
        #endregion
        
        #region Parameter Csr
        /// <summary>
        /// <para>
        /// <para>The certificate signing request (CSR) for the certificate you want to issue. As an
        /// example, you can use the following OpenSSL command to create the CSR and a 2048 bit
        /// RSA private key. </para><para><code>openssl req -new -newkey rsa:2048 -days 365 -keyout private/test_cert_priv_key.pem
        /// -out csr/test_cert_.csr</code></para><para>If you have a configuration file, you can then use the following OpenSSL command.
        /// The <code>usr_cert</code> block in the configuration file contains your X509 version
        /// 3 extensions. </para><para><code>openssl req -new -config openssl_rsa.cnf -extensions usr_cert -newkey rsa:2048
        /// -days 365 -keyout private/test_cert_priv_key.pem -out csr/test_cert_.csr</code></para><para>Note: A CSR must provide either a <i>subject name</i> or a <i>subject alternative
        /// name</i> or the request will be rejected. </para>
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
        public byte[] Csr { get; set; }
        #endregion
        
        #region Parameter Subject_CustomAttribute
        /// <summary>
        /// <para>
        /// <para>Contains a sequence of one or more X.500 relative distinguished names (RDNs), each
        /// of which consists of an object identifier (OID) and a value. For more information,
        /// see NIST’s definition of <a href="https://csrc.nist.gov/glossary/term/Object_Identifier">Object
        /// Identifier (OID)</a>.</para><note><para>Custom attributes cannot be used in combination with standard attributes.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_CustomAttributes")]
        public Amazon.ACMPCA.Model.CustomAttribute[] Subject_CustomAttribute { get; set; }
        #endregion
        
        #region Parameter Extensions_CustomExtension
        /// <summary>
        /// <para>
        /// <para>Contains a sequence of one or more X.509 extensions, each of which consists of an
        /// object identifier (OID), a base64-encoded value, and the critical flag. For more information,
        /// see the <a href="https://oidref.com/2.5.29">Global OID reference database.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_CustomExtensions")]
        public Amazon.ACMPCA.Model.CustomExtension[] Extensions_CustomExtension { get; set; }
        #endregion
        
        #region Parameter KeyUsage_DataEncipherment
        /// <summary>
        /// <para>
        /// <para>Key can be used to decipher data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_DataEncipherment")]
        public System.Boolean? KeyUsage_DataEncipherment { get; set; }
        #endregion
        
        #region Parameter KeyUsage_DecipherOnly
        /// <summary>
        /// <para>
        /// <para>Key can be used only to decipher data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_DecipherOnly")]
        public System.Boolean? KeyUsage_DecipherOnly { get; set; }
        #endregion
        
        #region Parameter KeyUsage_DigitalSignature
        /// <summary>
        /// <para>
        /// <para> Key can be used for digital signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_DigitalSignature")]
        public System.Boolean? KeyUsage_DigitalSignature { get; set; }
        #endregion
        
        #region Parameter Subject_DistinguishedNameQualifier
        /// <summary>
        /// <para>
        /// <para>Disambiguating information for the certificate subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_DistinguishedNameQualifier")]
        public System.String Subject_DistinguishedNameQualifier { get; set; }
        #endregion
        
        #region Parameter KeyUsage_EncipherOnly
        /// <summary>
        /// <para>
        /// <para>Key can be used only to encipher data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_EncipherOnly")]
        public System.Boolean? KeyUsage_EncipherOnly { get; set; }
        #endregion
        
        #region Parameter Extensions_ExtendedKeyUsage
        /// <summary>
        /// <para>
        /// <para>Specifies additional purposes for which the certified public key may be used other
        /// than basic purposes indicated in the <code>KeyUsage</code> extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_ExtendedKeyUsage")]
        public Amazon.ACMPCA.Model.ExtendedKeyUsage[] Extensions_ExtendedKeyUsage { get; set; }
        #endregion
        
        #region Parameter Subject_GenerationQualifier
        /// <summary>
        /// <para>
        /// <para>Typically a qualifier appended to the name of an individual. Examples include Jr.
        /// for junior, Sr. for senior, and III for third.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_GenerationQualifier")]
        public System.String Subject_GenerationQualifier { get; set; }
        #endregion
        
        #region Parameter Subject_GivenName
        /// <summary>
        /// <para>
        /// <para>First name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_GivenName")]
        public System.String Subject_GivenName { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Alphanumeric string that can be used to distinguish between calls to the <b>IssueCertificate</b>
        /// action. Idempotency tokens for <b>IssueCertificate</b> time out after one minute.
        /// Therefore, if you call <b>IssueCertificate</b> multiple times with the same idempotency
        /// token within one minute, ACM Private CA recognizes that you are requesting only one
        /// certificate and will issue only one. If you change the idempotency token for each
        /// call, PCA recognizes that you are requesting multiple certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Subject_Initial
        /// <summary>
        /// <para>
        /// <para>Concatenation that typically contains the first letter of the <b>GivenName</b>, the
        /// first letter of the middle name if one exists, and the first letter of the <b>Surname</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_Initials")]
        public System.String Subject_Initial { get; set; }
        #endregion
        
        #region Parameter KeyUsage_KeyAgreement
        /// <summary>
        /// <para>
        /// <para>Key can be used in a key-agreement protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_KeyAgreement")]
        public System.Boolean? KeyUsage_KeyAgreement { get; set; }
        #endregion
        
        #region Parameter KeyUsage_KeyCertSign
        /// <summary>
        /// <para>
        /// <para>Key can be used to sign certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_KeyCertSign")]
        public System.Boolean? KeyUsage_KeyCertSign { get; set; }
        #endregion
        
        #region Parameter KeyUsage_KeyEncipherment
        /// <summary>
        /// <para>
        /// <para>Key can be used to encipher data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_KeyEncipherment")]
        public System.Boolean? KeyUsage_KeyEncipherment { get; set; }
        #endregion
        
        #region Parameter Subject_Locality
        /// <summary>
        /// <para>
        /// <para>The locality (such as a city or town) in which the certificate subject is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_Locality")]
        public System.String Subject_Locality { get; set; }
        #endregion
        
        #region Parameter KeyUsage_NonRepudiation
        /// <summary>
        /// <para>
        /// <para>Key can be used for non-repudiation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_KeyUsage_NonRepudiation")]
        public System.Boolean? KeyUsage_NonRepudiation { get; set; }
        #endregion
        
        #region Parameter Subject_Organization
        /// <summary>
        /// <para>
        /// <para>Legal name of the organization with which the certificate subject is affiliated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_Organization")]
        public System.String Subject_Organization { get; set; }
        #endregion
        
        #region Parameter Subject_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>A subdivision or unit of the organization (such as sales or finance) with which the
        /// certificate subject is affiliated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_OrganizationalUnit")]
        public System.String Subject_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter Subject_Pseudonym
        /// <summary>
        /// <para>
        /// <para>Typically a shortened version of a longer <b>GivenName</b>. For example, Jonathan
        /// is often shortened to John. Elizabeth is often shortened to Beth, Liz, or Eliza.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_Pseudonym")]
        public System.String Subject_Pseudonym { get; set; }
        #endregion
        
        #region Parameter Subject_SerialNumber
        /// <summary>
        /// <para>
        /// <para>The certificate serial number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_SerialNumber")]
        public System.String Subject_SerialNumber { get; set; }
        #endregion
        
        #region Parameter SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The name of the algorithm that will be used to sign the certificate to be issued.
        /// </para><para>This parameter should not be confused with the <code>SigningAlgorithm</code> parameter
        /// used to sign a CSR in the <code>CreateCertificateAuthority</code> action.</para><note><para>The specified signing algorithm family (RSA or ECDSA) much match the algorithm family
        /// of the CA's secret key.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ACMPCA.SigningAlgorithm")]
        public Amazon.ACMPCA.SigningAlgorithm SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter Subject_State
        /// <summary>
        /// <para>
        /// <para>State in which the subject of the certificate is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_State")]
        public System.String Subject_State { get; set; }
        #endregion
        
        #region Parameter Extensions_SubjectAlternativeName
        /// <summary>
        /// <para>
        /// <para>The subject alternative name extension allows identities to be bound to the subject
        /// of the certificate. These identities may be included in addition to or in place of
        /// the identity in the subject field of the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Extensions_SubjectAlternativeNames")]
        public Amazon.ACMPCA.Model.GeneralName[] Extensions_SubjectAlternativeName { get; set; }
        #endregion
        
        #region Parameter Subject_Surname
        /// <summary>
        /// <para>
        /// <para>Family name. In the US and the UK, for example, the surname of an individual is ordered
        /// last. In Asian cultures the surname is typically ordered first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_Surname")]
        public System.String Subject_Surname { get; set; }
        #endregion
        
        #region Parameter TemplateArn
        /// <summary>
        /// <para>
        /// <para>Specifies a custom configuration template to use when issuing a certificate. If this
        /// parameter is not provided, ACM Private CA defaults to the <code>EndEntityCertificate/V1</code>
        /// template. For CA certificates, you should choose the shortest path length that meets
        /// your needs. The path length is indicated by the PathLen<i>N</i> portion of the ARN,
        /// where <i>N</i> is the <a href="https://docs.aws.amazon.com/acm-pca/latest/userguide/PcaTerms.html#terms-cadepth">CA
        /// depth</a>.</para><para>Note: The CA depth configured on a subordinate CA certificate must not exceed the
        /// limit set by its parents in the CA hierarchy.</para><para>For a list of <code>TemplateArn</code> values supported by ACM Private CA, see <a href="https://docs.aws.amazon.com/acm-pca/latest/userguide/UsingTemplates.html">Understanding
        /// Certificate Templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateArn { get; set; }
        #endregion
        
        #region Parameter Subject_Title
        /// <summary>
        /// <para>
        /// <para>A title such as Mr. or Ms., which is pre-pended to the name to refer formally to the
        /// certificate subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiPassthrough_Subject_Title")]
        public System.String Subject_Title { get; set; }
        #endregion
        
        #region Parameter Validity
        /// <summary>
        /// <para>
        /// <para>Information describing the end of the validity period of the certificate. This parameter
        /// sets the “Not After” date for the certificate.</para><para>Certificate validity is the period of time during which a certificate is valid. Validity
        /// can be expressed as an explicit date and time when the certificate expires, or as
        /// a span of time after issuance, stated in days, months, or years. For more information,
        /// see <a href="https://datatracker.ietf.org/doc/html/rfc5280#section-4.1.2.5">Validity</a>
        /// in RFC 5280. </para><para>This value is unaffected when <code>ValidityNotBefore</code> is also specified. For
        /// example, if <code>Validity</code> is set to 20 days in the future, the certificate
        /// will expire 20 days from issuance time regardless of the <code>ValidityNotBefore</code>
        /// value.</para><para>The end of the validity period configured on a certificate must not exceed the limit
        /// set on its parents in the CA hierarchy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.ACMPCA.Model.Validity Validity { get; set; }
        #endregion
        
        #region Parameter ValidityNotBefore
        /// <summary>
        /// <para>
        /// <para>Information describing the start of the validity period of the certificate. This parameter
        /// sets the “Not Before" date for the certificate.</para><para>By default, when issuing a certificate, ACM Private CA sets the "Not Before" date
        /// to the issuance time minus 60 minutes. This compensates for clock inconsistencies
        /// across computer systems. The <code>ValidityNotBefore</code> parameter can be used
        /// to customize the “Not Before” value. </para><para>Unlike the <code>Validity</code> parameter, the <code>ValidityNotBefore</code> parameter
        /// is optional.</para><para>The <code>ValidityNotBefore</code> value is expressed as an explicit date and time,
        /// using the <code>Validity</code> type value <code>ABSOLUTE</code>. For more information,
        /// see <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_Validity.html">Validity</a>
        /// in this API reference and <a href="https://datatracker.ietf.org/doc/html/rfc5280#section-4.1.2.5">Validity</a>
        /// in RFC 5280.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ACMPCA.Model.Validity ValidityNotBefore { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.IssueCertificateResponse).
        /// Specifying the name of a property of type Amazon.ACMPCA.Model.IssueCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CertificateAuthorityArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCACertificate (IssueCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.IssueCertificateResponse, NewPCACertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CertificateAuthorityArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Extensions_CertificatePolicy != null)
            {
                context.Extensions_CertificatePolicy = new List<Amazon.ACMPCA.Model.PolicyInformation>(this.Extensions_CertificatePolicy);
            }
            if (this.Extensions_CustomExtension != null)
            {
                context.Extensions_CustomExtension = new List<Amazon.ACMPCA.Model.CustomExtension>(this.Extensions_CustomExtension);
            }
            if (this.Extensions_ExtendedKeyUsage != null)
            {
                context.Extensions_ExtendedKeyUsage = new List<Amazon.ACMPCA.Model.ExtendedKeyUsage>(this.Extensions_ExtendedKeyUsage);
            }
            context.KeyUsage_CRLSign = this.KeyUsage_CRLSign;
            context.KeyUsage_DataEncipherment = this.KeyUsage_DataEncipherment;
            context.KeyUsage_DecipherOnly = this.KeyUsage_DecipherOnly;
            context.KeyUsage_DigitalSignature = this.KeyUsage_DigitalSignature;
            context.KeyUsage_EncipherOnly = this.KeyUsage_EncipherOnly;
            context.KeyUsage_KeyAgreement = this.KeyUsage_KeyAgreement;
            context.KeyUsage_KeyCertSign = this.KeyUsage_KeyCertSign;
            context.KeyUsage_KeyEncipherment = this.KeyUsage_KeyEncipherment;
            context.KeyUsage_NonRepudiation = this.KeyUsage_NonRepudiation;
            if (this.Extensions_SubjectAlternativeName != null)
            {
                context.Extensions_SubjectAlternativeName = new List<Amazon.ACMPCA.Model.GeneralName>(this.Extensions_SubjectAlternativeName);
            }
            context.Subject_CommonName = this.Subject_CommonName;
            context.Subject_Country = this.Subject_Country;
            if (this.Subject_CustomAttribute != null)
            {
                context.Subject_CustomAttribute = new List<Amazon.ACMPCA.Model.CustomAttribute>(this.Subject_CustomAttribute);
            }
            context.Subject_DistinguishedNameQualifier = this.Subject_DistinguishedNameQualifier;
            context.Subject_GenerationQualifier = this.Subject_GenerationQualifier;
            context.Subject_GivenName = this.Subject_GivenName;
            context.Subject_Initial = this.Subject_Initial;
            context.Subject_Locality = this.Subject_Locality;
            context.Subject_Organization = this.Subject_Organization;
            context.Subject_OrganizationalUnit = this.Subject_OrganizationalUnit;
            context.Subject_Pseudonym = this.Subject_Pseudonym;
            context.Subject_SerialNumber = this.Subject_SerialNumber;
            context.Subject_State = this.Subject_State;
            context.Subject_Surname = this.Subject_Surname;
            context.Subject_Title = this.Subject_Title;
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Csr = this.Csr;
            #if MODULAR
            if (this.Csr == null && ParameterWasBound(nameof(this.Csr)))
            {
                WriteWarning("You are passing $null as a value for parameter Csr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.SigningAlgorithm = this.SigningAlgorithm;
            #if MODULAR
            if (this.SigningAlgorithm == null && ParameterWasBound(nameof(this.SigningAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateArn = this.TemplateArn;
            context.Validity = this.Validity;
            #if MODULAR
            if (this.Validity == null && ParameterWasBound(nameof(this.Validity)))
            {
                WriteWarning("You are passing $null as a value for parameter Validity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidityNotBefore = this.ValidityNotBefore;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _CsrStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ACMPCA.Model.IssueCertificateRequest();
                
                
                 // populate ApiPassthrough
                var requestApiPassthroughIsNull = true;
                request.ApiPassthrough = new Amazon.ACMPCA.Model.ApiPassthrough();
                Amazon.ACMPCA.Model.Extensions requestApiPassthrough_apiPassthrough_Extensions = null;
                
                 // populate Extensions
                var requestApiPassthrough_apiPassthrough_ExtensionsIsNull = true;
                requestApiPassthrough_apiPassthrough_Extensions = new Amazon.ACMPCA.Model.Extensions();
                List<Amazon.ACMPCA.Model.PolicyInformation> requestApiPassthrough_apiPassthrough_Extensions_extensions_CertificatePolicy = null;
                if (cmdletContext.Extensions_CertificatePolicy != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_extensions_CertificatePolicy = cmdletContext.Extensions_CertificatePolicy;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_extensions_CertificatePolicy != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions.CertificatePolicies = requestApiPassthrough_apiPassthrough_Extensions_extensions_CertificatePolicy;
                    requestApiPassthrough_apiPassthrough_ExtensionsIsNull = false;
                }
                List<Amazon.ACMPCA.Model.CustomExtension> requestApiPassthrough_apiPassthrough_Extensions_extensions_CustomExtension = null;
                if (cmdletContext.Extensions_CustomExtension != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_extensions_CustomExtension = cmdletContext.Extensions_CustomExtension;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_extensions_CustomExtension != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions.CustomExtensions = requestApiPassthrough_apiPassthrough_Extensions_extensions_CustomExtension;
                    requestApiPassthrough_apiPassthrough_ExtensionsIsNull = false;
                }
                List<Amazon.ACMPCA.Model.ExtendedKeyUsage> requestApiPassthrough_apiPassthrough_Extensions_extensions_ExtendedKeyUsage = null;
                if (cmdletContext.Extensions_ExtendedKeyUsage != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_extensions_ExtendedKeyUsage = cmdletContext.Extensions_ExtendedKeyUsage;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_extensions_ExtendedKeyUsage != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions.ExtendedKeyUsage = requestApiPassthrough_apiPassthrough_Extensions_extensions_ExtendedKeyUsage;
                    requestApiPassthrough_apiPassthrough_ExtensionsIsNull = false;
                }
                List<Amazon.ACMPCA.Model.GeneralName> requestApiPassthrough_apiPassthrough_Extensions_extensions_SubjectAlternativeName = null;
                if (cmdletContext.Extensions_SubjectAlternativeName != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_extensions_SubjectAlternativeName = cmdletContext.Extensions_SubjectAlternativeName;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_extensions_SubjectAlternativeName != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions.SubjectAlternativeNames = requestApiPassthrough_apiPassthrough_Extensions_extensions_SubjectAlternativeName;
                    requestApiPassthrough_apiPassthrough_ExtensionsIsNull = false;
                }
                Amazon.ACMPCA.Model.KeyUsage requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage = null;
                
                 // populate KeyUsage
                var requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = true;
                requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage = new Amazon.ACMPCA.Model.KeyUsage();
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_CRLSign = null;
                if (cmdletContext.KeyUsage_CRLSign != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_CRLSign = cmdletContext.KeyUsage_CRLSign.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_CRLSign != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.CRLSign = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_CRLSign.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DataEncipherment = null;
                if (cmdletContext.KeyUsage_DataEncipherment != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DataEncipherment = cmdletContext.KeyUsage_DataEncipherment.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DataEncipherment != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.DataEncipherment = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DataEncipherment.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DecipherOnly = null;
                if (cmdletContext.KeyUsage_DecipherOnly != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DecipherOnly = cmdletContext.KeyUsage_DecipherOnly.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DecipherOnly != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.DecipherOnly = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DecipherOnly.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DigitalSignature = null;
                if (cmdletContext.KeyUsage_DigitalSignature != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DigitalSignature = cmdletContext.KeyUsage_DigitalSignature.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DigitalSignature != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.DigitalSignature = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_DigitalSignature.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_EncipherOnly = null;
                if (cmdletContext.KeyUsage_EncipherOnly != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_EncipherOnly = cmdletContext.KeyUsage_EncipherOnly.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_EncipherOnly != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.EncipherOnly = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_EncipherOnly.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyAgreement = null;
                if (cmdletContext.KeyUsage_KeyAgreement != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyAgreement = cmdletContext.KeyUsage_KeyAgreement.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyAgreement != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.KeyAgreement = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyAgreement.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyCertSign = null;
                if (cmdletContext.KeyUsage_KeyCertSign != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyCertSign = cmdletContext.KeyUsage_KeyCertSign.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyCertSign != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.KeyCertSign = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyCertSign.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyEncipherment = null;
                if (cmdletContext.KeyUsage_KeyEncipherment != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyEncipherment = cmdletContext.KeyUsage_KeyEncipherment.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyEncipherment != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.KeyEncipherment = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_KeyEncipherment.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                System.Boolean? requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_NonRepudiation = null;
                if (cmdletContext.KeyUsage_NonRepudiation != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_NonRepudiation = cmdletContext.KeyUsage_NonRepudiation.Value;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_NonRepudiation != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage.NonRepudiation = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage_keyUsage_NonRepudiation.Value;
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull = false;
                }
                 // determine if requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage should be set to null
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsageIsNull)
                {
                    requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage = null;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage != null)
                {
                    requestApiPassthrough_apiPassthrough_Extensions.KeyUsage = requestApiPassthrough_apiPassthrough_Extensions_apiPassthrough_Extensions_KeyUsage;
                    requestApiPassthrough_apiPassthrough_ExtensionsIsNull = false;
                }
                 // determine if requestApiPassthrough_apiPassthrough_Extensions should be set to null
                if (requestApiPassthrough_apiPassthrough_ExtensionsIsNull)
                {
                    requestApiPassthrough_apiPassthrough_Extensions = null;
                }
                if (requestApiPassthrough_apiPassthrough_Extensions != null)
                {
                    request.ApiPassthrough.Extensions = requestApiPassthrough_apiPassthrough_Extensions;
                    requestApiPassthroughIsNull = false;
                }
                Amazon.ACMPCA.Model.ASN1Subject requestApiPassthrough_apiPassthrough_Subject = null;
                
                 // populate Subject
                var requestApiPassthrough_apiPassthrough_SubjectIsNull = true;
                requestApiPassthrough_apiPassthrough_Subject = new Amazon.ACMPCA.Model.ASN1Subject();
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_CommonName = null;
                if (cmdletContext.Subject_CommonName != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_CommonName = cmdletContext.Subject_CommonName;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_CommonName != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.CommonName = requestApiPassthrough_apiPassthrough_Subject_subject_CommonName;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_Country = null;
                if (cmdletContext.Subject_Country != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_Country = cmdletContext.Subject_Country;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_Country != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.Country = requestApiPassthrough_apiPassthrough_Subject_subject_Country;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                List<Amazon.ACMPCA.Model.CustomAttribute> requestApiPassthrough_apiPassthrough_Subject_subject_CustomAttribute = null;
                if (cmdletContext.Subject_CustomAttribute != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_CustomAttribute = cmdletContext.Subject_CustomAttribute;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_CustomAttribute != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.CustomAttributes = requestApiPassthrough_apiPassthrough_Subject_subject_CustomAttribute;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_DistinguishedNameQualifier = null;
                if (cmdletContext.Subject_DistinguishedNameQualifier != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_DistinguishedNameQualifier = cmdletContext.Subject_DistinguishedNameQualifier;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_DistinguishedNameQualifier != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.DistinguishedNameQualifier = requestApiPassthrough_apiPassthrough_Subject_subject_DistinguishedNameQualifier;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_GenerationQualifier = null;
                if (cmdletContext.Subject_GenerationQualifier != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_GenerationQualifier = cmdletContext.Subject_GenerationQualifier;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_GenerationQualifier != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.GenerationQualifier = requestApiPassthrough_apiPassthrough_Subject_subject_GenerationQualifier;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_GivenName = null;
                if (cmdletContext.Subject_GivenName != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_GivenName = cmdletContext.Subject_GivenName;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_GivenName != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.GivenName = requestApiPassthrough_apiPassthrough_Subject_subject_GivenName;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_Initial = null;
                if (cmdletContext.Subject_Initial != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_Initial = cmdletContext.Subject_Initial;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_Initial != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.Initials = requestApiPassthrough_apiPassthrough_Subject_subject_Initial;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_Locality = null;
                if (cmdletContext.Subject_Locality != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_Locality = cmdletContext.Subject_Locality;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_Locality != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.Locality = requestApiPassthrough_apiPassthrough_Subject_subject_Locality;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_Organization = null;
                if (cmdletContext.Subject_Organization != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_Organization = cmdletContext.Subject_Organization;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_Organization != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.Organization = requestApiPassthrough_apiPassthrough_Subject_subject_Organization;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_OrganizationalUnit = null;
                if (cmdletContext.Subject_OrganizationalUnit != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_OrganizationalUnit = cmdletContext.Subject_OrganizationalUnit;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_OrganizationalUnit != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.OrganizationalUnit = requestApiPassthrough_apiPassthrough_Subject_subject_OrganizationalUnit;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_Pseudonym = null;
                if (cmdletContext.Subject_Pseudonym != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_Pseudonym = cmdletContext.Subject_Pseudonym;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_Pseudonym != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.Pseudonym = requestApiPassthrough_apiPassthrough_Subject_subject_Pseudonym;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_SerialNumber = null;
                if (cmdletContext.Subject_SerialNumber != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_SerialNumber = cmdletContext.Subject_SerialNumber;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_SerialNumber != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.SerialNumber = requestApiPassthrough_apiPassthrough_Subject_subject_SerialNumber;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_State = null;
                if (cmdletContext.Subject_State != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_State = cmdletContext.Subject_State;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_State != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.State = requestApiPassthrough_apiPassthrough_Subject_subject_State;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_Surname = null;
                if (cmdletContext.Subject_Surname != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_Surname = cmdletContext.Subject_Surname;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_Surname != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.Surname = requestApiPassthrough_apiPassthrough_Subject_subject_Surname;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                System.String requestApiPassthrough_apiPassthrough_Subject_subject_Title = null;
                if (cmdletContext.Subject_Title != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject_subject_Title = cmdletContext.Subject_Title;
                }
                if (requestApiPassthrough_apiPassthrough_Subject_subject_Title != null)
                {
                    requestApiPassthrough_apiPassthrough_Subject.Title = requestApiPassthrough_apiPassthrough_Subject_subject_Title;
                    requestApiPassthrough_apiPassthrough_SubjectIsNull = false;
                }
                 // determine if requestApiPassthrough_apiPassthrough_Subject should be set to null
                if (requestApiPassthrough_apiPassthrough_SubjectIsNull)
                {
                    requestApiPassthrough_apiPassthrough_Subject = null;
                }
                if (requestApiPassthrough_apiPassthrough_Subject != null)
                {
                    request.ApiPassthrough.Subject = requestApiPassthrough_apiPassthrough_Subject;
                    requestApiPassthroughIsNull = false;
                }
                 // determine if request.ApiPassthrough should be set to null
                if (requestApiPassthroughIsNull)
                {
                    request.ApiPassthrough = null;
                }
                if (cmdletContext.CertificateAuthorityArn != null)
                {
                    request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
                }
                if (cmdletContext.Csr != null)
                {
                    _CsrStream = new System.IO.MemoryStream(cmdletContext.Csr);
                    request.Csr = _CsrStream;
                }
                if (cmdletContext.IdempotencyToken != null)
                {
                    request.IdempotencyToken = cmdletContext.IdempotencyToken;
                }
                if (cmdletContext.SigningAlgorithm != null)
                {
                    request.SigningAlgorithm = cmdletContext.SigningAlgorithm;
                }
                if (cmdletContext.TemplateArn != null)
                {
                    request.TemplateArn = cmdletContext.TemplateArn;
                }
                if (cmdletContext.Validity != null)
                {
                    request.Validity = cmdletContext.Validity;
                }
                if (cmdletContext.ValidityNotBefore != null)
                {
                    request.ValidityNotBefore = cmdletContext.ValidityNotBefore;
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
                if( _CsrStream != null)
                {
                    _CsrStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ACMPCA.Model.IssueCertificateResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.IssueCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "IssueCertificate");
            try
            {
                #if DESKTOP
                return client.IssueCertificate(request);
                #elif CORECLR
                return client.IssueCertificateAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ACMPCA.Model.PolicyInformation> Extensions_CertificatePolicy { get; set; }
            public List<Amazon.ACMPCA.Model.CustomExtension> Extensions_CustomExtension { get; set; }
            public List<Amazon.ACMPCA.Model.ExtendedKeyUsage> Extensions_ExtendedKeyUsage { get; set; }
            public System.Boolean? KeyUsage_CRLSign { get; set; }
            public System.Boolean? KeyUsage_DataEncipherment { get; set; }
            public System.Boolean? KeyUsage_DecipherOnly { get; set; }
            public System.Boolean? KeyUsage_DigitalSignature { get; set; }
            public System.Boolean? KeyUsage_EncipherOnly { get; set; }
            public System.Boolean? KeyUsage_KeyAgreement { get; set; }
            public System.Boolean? KeyUsage_KeyCertSign { get; set; }
            public System.Boolean? KeyUsage_KeyEncipherment { get; set; }
            public System.Boolean? KeyUsage_NonRepudiation { get; set; }
            public List<Amazon.ACMPCA.Model.GeneralName> Extensions_SubjectAlternativeName { get; set; }
            public System.String Subject_CommonName { get; set; }
            public System.String Subject_Country { get; set; }
            public List<Amazon.ACMPCA.Model.CustomAttribute> Subject_CustomAttribute { get; set; }
            public System.String Subject_DistinguishedNameQualifier { get; set; }
            public System.String Subject_GenerationQualifier { get; set; }
            public System.String Subject_GivenName { get; set; }
            public System.String Subject_Initial { get; set; }
            public System.String Subject_Locality { get; set; }
            public System.String Subject_Organization { get; set; }
            public System.String Subject_OrganizationalUnit { get; set; }
            public System.String Subject_Pseudonym { get; set; }
            public System.String Subject_SerialNumber { get; set; }
            public System.String Subject_State { get; set; }
            public System.String Subject_Surname { get; set; }
            public System.String Subject_Title { get; set; }
            public System.String CertificateAuthorityArn { get; set; }
            public byte[] Csr { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Amazon.ACMPCA.SigningAlgorithm SigningAlgorithm { get; set; }
            public System.String TemplateArn { get; set; }
            public Amazon.ACMPCA.Model.Validity Validity { get; set; }
            public Amazon.ACMPCA.Model.Validity ValidityNotBefore { get; set; }
            public System.Func<Amazon.ACMPCA.Model.IssueCertificateResponse, NewPCACertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateArn;
        }
        
    }
}
