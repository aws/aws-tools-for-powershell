/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Uses your private certificate authority (CA) to issue a client certificate. This operation
    /// returns the Amazon Resource Name (ARN) of the certificate. You can retrieve the certificate
    /// by calling the <a>GetCertificate</a> operation and specifying the ARN. 
    /// 
    ///  <note><para>
    /// You cannot use the ACM <b>ListCertificateAuthorities</b> operation to retrieve the
    /// ARNs of the certificates that you issue by using ACM PCA.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "PCACertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority IssueCertificate API operation.", Operation = new[] {"IssueCertificate"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.ACMPCA.Model.IssueCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPCACertificateCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a>CreateCertificateAuthority</a>.
        /// This must be of the form:</para><para><code>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter Csr
        /// <summary>
        /// <para>
        /// <para>The certificate signing request (CSR) for the certificate you want to issue. You can
        /// use the following OpenSSL command to create the CSR and a 2048 bit RSA private key.
        /// </para><para><code>openssl req -new -newkey rsa:2048 -days 365 -keyout private/test_cert_priv_key.pem
        /// -out csr/test_cert_.csr</code></para><para>If you have a configuration file, you can use the following OpenSSL command. The <code>usr_cert</code>
        /// block in the configuration file contains your X509 version 3 extensions. </para><para><code>openssl req -new -config openssl_rsa.cnf -extensions usr_cert -newkey rsa:2048
        /// -days -365 -keyout private/test_cert_priv_key.pem -out csr/test_cert_.csr</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] Csr { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Custom string that can be used to distinguish between calls to the <b>IssueCertificate</b>
        /// operation. Idempotency tokens time out after one hour. Therefore, if you call <b>IssueCertificate</b>
        /// multiple times with the same idempotency token within 5 minutes, ACM PCA recognizes
        /// that you are requesting only one certificate and will issue only one. If you change
        /// the idempotency token for each call, PCA recognizes that you are requesting multiple
        /// certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The name of the algorithm that will be used to sign the certificate to be issued.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ACMPCA.SigningAlgorithm")]
        public Amazon.ACMPCA.SigningAlgorithm SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter Validity
        /// <summary>
        /// <para>
        /// <para>The type of the validity period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ACMPCA.Model.Validity Validity { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateAuthorityArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCACertificate (IssueCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            context.Csr = this.Csr;
            context.IdempotencyToken = this.IdempotencyToken;
            context.SigningAlgorithm = this.SigningAlgorithm;
            context.Validity = this.Validity;
            
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
                if (cmdletContext.Validity != null)
                {
                    request.Validity = cmdletContext.Validity;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.CertificateArn;
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response,
                        Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.IssueCertificateAsync(request);
                return task.Result;
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
            public System.String CertificateAuthorityArn { get; set; }
            public byte[] Csr { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Amazon.ACMPCA.SigningAlgorithm SigningAlgorithm { get; set; }
            public Amazon.ACMPCA.Model.Validity Validity { get; set; }
        }
        
    }
}
