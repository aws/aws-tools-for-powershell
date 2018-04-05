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
    /// Imports your signed private CA certificate into ACM PCA. Before you can call this
    /// function, you must create the private certificate authority by calling the <a>CreateCertificateAuthority</a>
    /// function. You must then generate a certificate signing request (CSR) by calling the
    /// <a>GetCertificateAuthorityCsr</a> function. Take the CSR to your on-premises CA and
    /// use the root certificate or a subordinate certificate to sign it. Create a certificate
    /// chain and copy the signed certificate and the certificate chain to your working directory.
    /// 
    /// 
    ///  <note><para>
    /// Your certificate chain must not include the private CA certificate that you are importing.
    /// </para></note><note><para>
    /// Your on-premises CA certificate must be the last certificate in your chain. The subordinate
    /// certificate, if any, that your root CA signed must be next to last. The subordinate
    /// certificate signed by the preceding subordinate CA must come next, and so on until
    /// your chain is built. 
    /// </para></note><note><para>
    /// The chain must be PEM-encoded.
    /// </para></note>
    /// </summary>
    [Cmdlet("Import", "PCACertificateAuthorityCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority ImportCertificateAuthorityCertificate API operation.", Operation = new[] {"ImportCertificateAuthorityCertificate"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CertificateAuthorityArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportPCACertificateAuthorityCertificateCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The PEM-encoded certificate for your private CA. This must be signed by using your
        /// on-premises CA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] Certificate { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a>CreateCertificateAuthority</a>.
        /// This must be of the form: </para><para><code>arn:aws:acm:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter CertificateChain
        /// <summary>
        /// <para>
        /// <para>A PEM-encoded file that contains all of your certificates, other than the certificate
        /// you're importing, chaining up to your root CA. Your on-premises root certificate is
        /// the last in the chain, and each certificate in the chain signs the one preceding.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] CertificateChain { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the CertificateAuthorityArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-PCACertificateAuthorityCertificate (ImportCertificateAuthorityCertificate)"))
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
            
            context.Certificate = this.Certificate;
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            context.CertificateChain = this.CertificateChain;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _CertificateStream = null;
            System.IO.MemoryStream _CertificateChainStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateRequest();
                
                if (cmdletContext.Certificate != null)
                {
                    _CertificateStream = new System.IO.MemoryStream(cmdletContext.Certificate);
                    request.Certificate = _CertificateStream;
                }
                if (cmdletContext.CertificateAuthorityArn != null)
                {
                    request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
                }
                if (cmdletContext.CertificateChain != null)
                {
                    _CertificateChainStream = new System.IO.MemoryStream(cmdletContext.CertificateChain);
                    request.CertificateChain = _CertificateChainStream;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = null;
                    if (this.PassThru.IsPresent)
                        pipelineOutput = this.CertificateAuthorityArn;
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
                if( _CertificateStream != null)
                {
                    _CertificateStream.Dispose();
                }
                if( _CertificateChainStream != null)
                {
                    _CertificateChainStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "ImportCertificateAuthorityCertificate");
            try
            {
                #if DESKTOP
                return client.ImportCertificateAuthorityCertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ImportCertificateAuthorityCertificateAsync(request);
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
            public byte[] Certificate { get; set; }
            public System.String CertificateAuthorityArn { get; set; }
            public byte[] CertificateChain { get; set; }
        }
        
    }
}
