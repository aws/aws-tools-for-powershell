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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Imports a certificate into AWS Certificate Manager (ACM) to use with services that
    /// are integrated with ACM. Note that <a href="http://docs.aws.amazon.com/http:/docs.aws.amazon.comacm/latest/userguide/acm-services.html">integrated
    /// services</a> allow only certificate types and keys they support to be associated with
    /// their resources. Further, their support differs depending on whether the certificate
    /// is imported into IAM or into ACM. For more information, see the documentation for
    /// each service. For more information about importing certificates into ACM, see <a href="http://docs.aws.amazon.com/http:/docs.aws.amazon.comacm/latest/userguide/import-certificate.html">Importing
    /// Certificates</a> in the <i>AWS Certificate Manager User Guide</i>. 
    /// 
    ///  <note><para>
    /// ACM does not provide <a href="http://docs.aws.amazon.com/http:/docs.aws.amazon.comacm/latest/userguide/acm-renewal.html">managed
    /// renewal</a> for certificates that you import.
    /// </para></note><para>
    /// Note the following guidelines when importing third party certificates:
    /// </para><ul><li><para>
    /// You must enter the private key that matches the certificate you are importing.
    /// </para></li><li><para>
    /// The private key must be unencrypted. You cannot import a private key that is protected
    /// by a password or a passphrase.
    /// </para></li><li><para>
    /// If the certificate you are importing is not self-signed, you must enter its certificate
    /// chain.
    /// </para></li><li><para>
    /// If a certificate chain is included, the issuer must be the subject of one of the certificates
    /// in the chain.
    /// </para></li><li><para>
    /// The certificate, private key, and certificate chain must be PEM-encoded.
    /// </para></li><li><para>
    /// The current time must be between the <code>Not Before</code> and <code>Not After</code>
    /// certificate fields.
    /// </para></li><li><para>
    /// The <code>Issuer</code> field must not be empty.
    /// </para></li><li><para>
    /// The OCSP authority URL, if present, must not exceed 1000 characters.
    /// </para></li><li><para>
    /// To import a new certificate, omit the <code>CertificateArn</code> argument. Include
    /// this argument only when you want to replace a previously imported certificate.
    /// </para></li><li><para>
    /// When you import a certificate by using the CLI or one of the SDKs, you must specify
    /// the certificate, the certificate chain, and the private key by their file names preceded
    /// by <code>file://</code>. For example, you can specify a certificate saved in the <code>C:\temp</code>
    /// folder as <code>file://C:\temp\certificate_to_import.pem</code>. If you are making
    /// an HTTP or HTTPS Query request, include these arguments as BLOBs. 
    /// </para></li></ul><para>
    /// This operation returns the <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
    /// Resource Name (ARN)</a> of the imported certificate.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "ACMCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager ImportCertificate API operation.", Operation = new[] {"ImportCertificate"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CertificateManager.Model.ImportCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportACMCertificateCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The certificate to import.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] Certificate { get; set; }
        #endregion
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an imported certificate to replace. To import a new certificate,
        /// omit this field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter CertificateChain
        /// <summary>
        /// <para>
        /// <para>The PEM encoded certificate chain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] CertificateChain { get; set; }
        #endregion
        
        #region Parameter PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key that matches the public key in the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] PrivateKey { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-ACMCertificate (ImportCertificate)"))
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
            context.CertificateArn = this.CertificateArn;
            context.CertificateChain = this.CertificateChain;
            context.PrivateKey = this.PrivateKey;
            
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
            System.IO.MemoryStream _PrivateKeyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CertificateManager.Model.ImportCertificateRequest();
                
                if (cmdletContext.Certificate != null)
                {
                    _CertificateStream = new System.IO.MemoryStream(cmdletContext.Certificate);
                    request.Certificate = _CertificateStream;
                }
                if (cmdletContext.CertificateArn != null)
                {
                    request.CertificateArn = cmdletContext.CertificateArn;
                }
                if (cmdletContext.CertificateChain != null)
                {
                    _CertificateChainStream = new System.IO.MemoryStream(cmdletContext.CertificateChain);
                    request.CertificateChain = _CertificateChainStream;
                }
                if (cmdletContext.PrivateKey != null)
                {
                    _PrivateKeyStream = new System.IO.MemoryStream(cmdletContext.PrivateKey);
                    request.PrivateKey = _PrivateKeyStream;
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
                if( _CertificateStream != null)
                {
                    _CertificateStream.Dispose();
                }
                if( _CertificateChainStream != null)
                {
                    _CertificateChainStream.Dispose();
                }
                if( _PrivateKeyStream != null)
                {
                    _PrivateKeyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CertificateManager.Model.ImportCertificateResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.ImportCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "ImportCertificate");
            try
            {
                #if DESKTOP
                return client.ImportCertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ImportCertificateAsync(request);
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
            public System.String CertificateArn { get; set; }
            public byte[] CertificateChain { get; set; }
            public byte[] PrivateKey { get; set; }
        }
        
    }
}
