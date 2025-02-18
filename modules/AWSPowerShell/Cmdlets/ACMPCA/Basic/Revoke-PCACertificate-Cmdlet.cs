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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Revokes a certificate that was issued inside Amazon Web Services Private CA. If you
    /// enable a certificate revocation list (CRL) when you create or update your private
    /// CA, information about the revoked certificates will be included in the CRL. Amazon
    /// Web Services Private CA writes the CRL to an S3 bucket that you specify. A CRL is
    /// typically updated approximately 30 minutes after a certificate is revoked. If for
    /// any reason the CRL update fails, Amazon Web Services Private CA attempts makes further
    /// attempts every 15 minutes. With Amazon CloudWatch, you can create alarms for the metrics
    /// <c>CRLGenerated</c> and <c>MisconfiguredCRLBucket</c>. For more information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/PcaCloudWatch.html">Supported
    /// CloudWatch Metrics</a>.
    /// 
    ///  <note><para>
    /// Both Amazon Web Services Private CA and the IAM principal must have permission to
    /// write to the S3 bucket that you specify. If the IAM principal making the call does
    /// not have permission to write to the bucket, then an exception is thrown. For more
    /// information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/crl-planning.html#s3-policies">Access
    /// policies for CRLs in Amazon S3</a>.
    /// </para></note><para>
    /// Amazon Web Services Private CA also writes revocation information to the audit report.
    /// For more information, see <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_CreateCertificateAuthorityAuditReport.html">CreateCertificateAuthorityAuditReport</a>.
    /// </para><note><para>
    /// You cannot revoke a root CA self-signed certificate.
    /// </para></note>
    /// </summary>
    [Cmdlet("Revoke", "PCACertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority RevokeCertificate API operation.", Operation = new[] {"RevokeCertificate"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.RevokeCertificateResponse))]
    [AWSCmdletOutput("None or Amazon.ACMPCA.Model.RevokeCertificateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ACMPCA.Model.RevokeCertificateResponse) be returned by specifying '-Select *'."
    )]
    public partial class RevokePCACertificateCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the private CA that issued the certificate to be revoked.
        /// This must be of the form:</para><para><c>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></c></para>
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
        
        #region Parameter CertificateSerial
        /// <summary>
        /// <para>
        /// <para>Serial number of the certificate to be revoked. This must be in hexadecimal format.
        /// You can retrieve the serial number by calling <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_GetCertificate.html">GetCertificate</a>
        /// with the Amazon Resource Name (ARN) of the certificate you want and the ARN of your
        /// private CA. The <b>GetCertificate</b> action retrieves the certificate in the PEM
        /// format. You can use the following OpenSSL command to list the certificate in text
        /// format and copy the hexadecimal serial number. </para><para><c>openssl x509 -in <i>file_path</i> -text -noout</c></para><para>You can also copy the serial number from the console or use the <a href="https://docs.aws.amazon.com/acm/latest/APIReference/API_DescribeCertificate.html">DescribeCertificate</a>
        /// action in the <i>Certificate Manager API Reference</i>. </para>
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
        public System.String CertificateSerial { get; set; }
        #endregion
        
        #region Parameter RevocationReason
        /// <summary>
        /// <para>
        /// <para>Specifies why you revoked the certificate.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ACMPCA.RevocationReason")]
        public Amazon.ACMPCA.RevocationReason RevocationReason { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.RevokeCertificateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Revoke-PCACertificate (RevokeCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.RevokeCertificateResponse, RevokePCACertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateSerial = this.CertificateSerial;
            #if MODULAR
            if (this.CertificateSerial == null && ParameterWasBound(nameof(this.CertificateSerial)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateSerial which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevocationReason = this.RevocationReason;
            #if MODULAR
            if (this.RevocationReason == null && ParameterWasBound(nameof(this.RevocationReason)))
            {
                WriteWarning("You are passing $null as a value for parameter RevocationReason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ACMPCA.Model.RevokeCertificateRequest();
            
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.CertificateSerial != null)
            {
                request.CertificateSerial = cmdletContext.CertificateSerial;
            }
            if (cmdletContext.RevocationReason != null)
            {
                request.RevocationReason = cmdletContext.RevocationReason;
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
        
        private Amazon.ACMPCA.Model.RevokeCertificateResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.RevokeCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "RevokeCertificate");
            try
            {
                return client.RevokeCertificateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateAuthorityArn { get; set; }
            public System.String CertificateSerial { get; set; }
            public Amazon.ACMPCA.RevocationReason RevocationReason { get; set; }
            public System.Func<Amazon.ACMPCA.Model.RevokeCertificateResponse, RevokePCACertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
