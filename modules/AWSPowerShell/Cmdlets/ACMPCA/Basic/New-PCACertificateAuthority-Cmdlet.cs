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
    /// the CA configuration, the certificate revocation list (CRL) configuration, the CA
    /// type, and an optional idempotency token to avoid accidental creation of multiple CAs.
    /// The CA configuration specifies the name of the algorithm and key size to be used to
    /// create the CA private key, the type of signing algorithm that the CA uses, and X.500
    /// subject information. The CRL configuration specifies the CRL expiration period in
    /// days (the validity period of the CRL), the Amazon S3 bucket that will contain the
    /// CRL, and a CNAME alias for the S3 bucket that is included in certificates issued by
    /// the CA. If successful, this action returns the Amazon Resource Name (ARN) of the CA.
    /// 
    ///  
    /// <para>
    /// ACM Private CAA assets that are stored in Amazon S3 can be protected with encryption.
    /// For more information, see <a href="https://docs.aws.amazon.com/acm-pca/latest/userguide/PcaCreateCa.html#crl-encryption">Encrypting
    /// Your CRLs</a>.
    /// </para><note><para>
    /// Both PCA and the IAM principal must have permission to write to the S3 bucket that
    /// you specify. If the IAM principal making the call does not have permission to write
    /// to the bucket, then an exception is thrown. For more information, see <a href="https://docs.aws.amazon.com/acm-pca/latest/userguide/PcaAuthAccess.html">Configure
    /// Access to ACM Private CA</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "PCACertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority CreateCertificateAuthority API operation.", Operation = new[] {"CreateCertificateAuthority"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse))]
    [AWSCmdletOutput("System.String or Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
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
        /// <para>Alphanumeric string that can be used to distinguish between calls to <b>CreateCertificateAuthority</b>.
        /// For a given token, ACM Private CA creates exactly one CA. If you issue a subsequent
        /// call using the same token, ACM Private CA returns the ARN of the existing CA and takes
        /// no further action. If you change the idempotency token across multiple calls, ACM
        /// Private CA creates a unique CA for each unique token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter RevocationConfiguration
        /// <summary>
        /// <para>
        /// <para>Contains a Boolean value that you can use to enable a certification revocation list
        /// (CRL) for the CA, the name of the S3 bucket to which ACM Private CA will write the
        /// CRL, and an optional CNAME alias that you can use to hide the name of your bucket
        /// in the <b>CRL Distribution Points</b> extension of your CA certificate. For more information,
        /// see the <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_CrlConfiguration.html">CrlConfiguration</a>
        /// structure. </para>
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
            context.RevocationConfiguration = this.RevocationConfiguration;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ACMPCA.Model.Tag>(this.Tag);
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
            if (cmdletContext.RevocationConfiguration != null)
            {
                request.RevocationConfiguration = cmdletContext.RevocationConfiguration;
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
            public Amazon.ACMPCA.Model.RevocationConfiguration RevocationConfiguration { get; set; }
            public List<Amazon.ACMPCA.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse, NewPCACertificateAuthorityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateAuthorityArn;
        }
        
    }
}
