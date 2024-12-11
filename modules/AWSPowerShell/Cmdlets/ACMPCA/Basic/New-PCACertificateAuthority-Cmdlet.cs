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
    /// Creates a root or subordinate private certificate authority (CA). You must specify
    /// the CA configuration, an optional configuration for Online Certificate Status Protocol
    /// (OCSP) and/or a certificate revocation list (CRL), the CA type, and an optional idempotency
    /// token to avoid accidental creation of multiple CAs. The CA configuration specifies
    /// the name of the algorithm and key size to be used to create the CA private key, the
    /// type of signing algorithm that the CA uses, and X.500 subject information. The OCSP
    /// configuration can optionally specify a custom URL for the OCSP responder. The CRL
    /// configuration specifies the CRL expiration period in days (the validity period of
    /// the CRL), the Amazon S3 bucket that will contain the CRL, and a CNAME alias for the
    /// S3 bucket that is included in certificates issued by the CA. If successful, this action
    /// returns the Amazon Resource Name (ARN) of the CA.
    /// 
    ///  <note><para>
    /// Both Amazon Web Services Private CA and the IAM principal must have permission to
    /// write to the S3 bucket that you specify. If the IAM principal making the call does
    /// not have permission to write to the bucket, then an exception is thrown. For more
    /// information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/crl-planning.html#s3-policies">Access
    /// policies for CRLs in Amazon S3</a>.
    /// </para></note><para>
    /// Amazon Web Services Private CA assets that are stored in Amazon S3 can be protected
    /// with encryption. For more information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/crl-planning.html#crl-encryption">Encrypting
    /// Your CRLs</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "PCACertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority CreateCertificateAuthority API operation.", Operation = new[] {"CreateCertificateAuthority"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse))]
    [AWSCmdletOutput("System.String or Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificateAuthorityConfiguration
        /// <summary>
        /// <para>
        /// <para>Name and bit size of the private key algorithm, the name of the signing algorithm,
        /// and X.500 certificate subject information.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.ACMPCA.Model.CertificateAuthorityConfiguration CertificateAuthorityConfiguration { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityType
        /// <summary>
        /// <para>
        /// <para>The type of the certificate authority.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ACMPCA.CertificateAuthorityType")]
        public Amazon.ACMPCA.CertificateAuthorityType CertificateAuthorityType { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Custom string that can be used to distinguish between calls to the <b>CreateCertificateAuthority</b>
        /// action. Idempotency tokens for <b>CreateCertificateAuthority</b> time out after five
        /// minutes. Therefore, if you call <b>CreateCertificateAuthority</b> multiple times with
        /// the same idempotency token within five minutes, Amazon Web Services Private CA recognizes
        /// that you are requesting only certificate authority and will issue only one. If you
        /// change the idempotency token for each call, Amazon Web Services Private CA recognizes
        /// that you are requesting multiple certificate authorities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter KeyStorageSecurityStandard
        /// <summary>
        /// <para>
        /// <para>Specifies a cryptographic key management compliance standard used for handling CA
        /// keys.</para><para>Default: FIPS_140_2_LEVEL_3_OR_HIGHER</para><note><para>Some Amazon Web Services Regions do not support the default. When creating a CA in
        /// these Regions, you must provide <c>FIPS_140_2_LEVEL_2_OR_HIGHER</c> as the argument
        /// for <c>KeyStorageSecurityStandard</c>. Failure to do this results in an <c>InvalidArgsException</c>
        /// with the message, "A certificate authority cannot be created in this region with the
        /// specified security standard."</para><para>For information about security standard support in various Regions, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/data-protection.html#private-keys">Storage
        /// and security compliance of Amazon Web Services Private CA private keys</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ACMPCA.KeyStorageSecurityStandard")]
        public Amazon.ACMPCA.KeyStorageSecurityStandard KeyStorageSecurityStandard { get; set; }
        #endregion
        
        #region Parameter RevocationConfiguration
        /// <summary>
        /// <para>
        /// <para>Contains information to enable support for Online Certificate Status Protocol (OCSP),
        /// certificate revocation list (CRL), both protocols, or neither. By default, both certificate
        /// validation mechanisms are disabled.</para><para>The following requirements apply to revocation configurations.</para><ul><li><para>A configuration disabling CRLs or OCSP must contain only the <c>Enabled=False</c>
        /// parameter, and will fail if other parameters such as <c>CustomCname</c> or <c>ExpirationInDays</c>
        /// are included.</para></li><li><para>In a CRL configuration, the <c>S3BucketName</c> parameter must conform to <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucketnamingrules.html">Amazon
        /// S3 bucket naming rules</a>.</para></li><li><para>A configuration containing a custom Canonical Name (CNAME) parameter for CRLs or OCSP
        /// must conform to <a href="https://www.ietf.org/rfc/rfc2396.txt">RFC2396</a> restrictions
        /// on the use of special characters in a CNAME. </para></li><li><para>In a CRL or OCSP configuration, the value of a CNAME parameter must not include a
        /// protocol prefix such as "http://" or "https://".</para></li></ul><para> For more information, see the <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_OcspConfiguration.html">OcspConfiguration</a>
        /// and <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_CrlConfiguration.html">CrlConfiguration</a>
        /// types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ACMPCA.Model.RevocationConfiguration RevocationConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that will be attached to the new private CA. You can associate up
        /// to 50 tags with a private CA. For information using tags with IAM to manage permissions,
        /// see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_iam-tags.html">Controlling
        /// Access Using IAM Tags</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ACMPCA.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UsageMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the CA issues general-purpose certificates that typically require
        /// a revocation mechanism, or short-lived certificates that may optionally omit revocation
        /// because they expire quickly. Short-lived certificate validity is limited to seven
        /// days.</para><para>The default value is GENERAL_PURPOSE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ACMPCA.CertificateAuthorityUsageMode")]
        public Amazon.ACMPCA.CertificateAuthorityUsageMode UsageMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateAuthorityArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse).
        /// Specifying the name of a property of type Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateAuthorityArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCACertificateAuthority (CreateCertificateAuthority)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse, NewPCACertificateAuthorityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateAuthorityConfiguration = this.CertificateAuthorityConfiguration;
            #if MODULAR
            if (this.CertificateAuthorityConfiguration == null && ParameterWasBound(nameof(this.CertificateAuthorityConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateAuthorityType = this.CertificateAuthorityType;
            #if MODULAR
            if (this.CertificateAuthorityType == null && ParameterWasBound(nameof(this.CertificateAuthorityType)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.KeyStorageSecurityStandard = this.KeyStorageSecurityStandard;
            context.RevocationConfiguration = this.RevocationConfiguration;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ACMPCA.Model.Tag>(this.Tag);
            }
            context.UsageMode = this.UsageMode;
            
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
            var request = new Amazon.ACMPCA.Model.CreateCertificateAuthorityRequest();
            
            if (cmdletContext.CertificateAuthorityConfiguration != null)
            {
                request.CertificateAuthorityConfiguration = cmdletContext.CertificateAuthorityConfiguration;
            }
            if (cmdletContext.CertificateAuthorityType != null)
            {
                request.CertificateAuthorityType = cmdletContext.CertificateAuthorityType;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.KeyStorageSecurityStandard != null)
            {
                request.KeyStorageSecurityStandard = cmdletContext.KeyStorageSecurityStandard;
            }
            if (cmdletContext.RevocationConfiguration != null)
            {
                request.RevocationConfiguration = cmdletContext.RevocationConfiguration;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UsageMode != null)
            {
                request.UsageMode = cmdletContext.UsageMode;
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
        
        private Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.CreateCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "CreateCertificateAuthority");
            try
            {
                #if DESKTOP
                return client.CreateCertificateAuthority(request);
                #elif CORECLR
                return client.CreateCertificateAuthorityAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ACMPCA.Model.CertificateAuthorityConfiguration CertificateAuthorityConfiguration { get; set; }
            public Amazon.ACMPCA.CertificateAuthorityType CertificateAuthorityType { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Amazon.ACMPCA.KeyStorageSecurityStandard KeyStorageSecurityStandard { get; set; }
            public Amazon.ACMPCA.Model.RevocationConfiguration RevocationConfiguration { get; set; }
            public List<Amazon.ACMPCA.Model.Tag> Tag { get; set; }
            public Amazon.ACMPCA.CertificateAuthorityUsageMode UsageMode { get; set; }
            public System.Func<Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse, NewPCACertificateAuthorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateAuthorityArn;
        }
        
    }
}
