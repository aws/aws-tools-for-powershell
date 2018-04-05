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
    /// Exports a certificate for use anywhere. You can export the certificate, the certificate
    /// chain, and the encrypted private key associated with the public key embedded in the
    /// certificate. You must store the private key securely. The private key is a 2048 bit
    /// RSA key. You must provide a passphrase for the private key when exporting it. You
    /// can use the following OpenSSL command to decrypt it later. Provide the passphrase
    /// when prompted. 
    /// 
    ///  
    /// <para><code>openssl rsa -in encrypted_key.pem -out decrypted_key.pem</code></para>
    /// </summary>
    [Cmdlet("Export", "ACMCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CertificateManager.Model.ExportCertificateResponse")]
    [AWSCmdlet("Calls the AWS Certificate Manager ExportCertificate API operation.", Operation = new[] {"ExportCertificate"})]
    [AWSCmdletOutput("Amazon.CertificateManager.Model.ExportCertificateResponse",
        "This cmdlet returns a Amazon.CertificateManager.Model.ExportCertificateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ExportACMCertificateCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) of the issued certificate. This must be of the form:</para><para><code>arn:aws:acm:region:account:certificate/12345678-1234-1234-1234-123456789012</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter Passphrase
        /// <summary>
        /// <para>
        /// <para>Passphrase to associate with the encrypted exported private key. If you want to later
        /// decrypt the private key, you must have the passphrase. You can use the following OpenSSL
        /// command to decrypt a private key: </para><para><code>openssl rsa -in encrypted_key.pem -out decrypted_key.pem</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] Passphrase { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-ACMCertificate (ExportCertificate)"))
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
            
            context.CertificateArn = this.CertificateArn;
            context.Passphrase = this.Passphrase;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _PassphraseStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.CertificateManager.Model.ExportCertificateRequest();
                
                if (cmdletContext.CertificateArn != null)
                {
                    request.CertificateArn = cmdletContext.CertificateArn;
                }
                if (cmdletContext.Passphrase != null)
                {
                    _PassphraseStream = new System.IO.MemoryStream(cmdletContext.Passphrase);
                    request.Passphrase = _PassphraseStream;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
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
                if( _PassphraseStream != null)
                {
                    _PassphraseStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CertificateManager.Model.ExportCertificateResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.ExportCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "ExportCertificate");
            try
            {
                #if DESKTOP
                return client.ExportCertificate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ExportCertificateAsync(request);
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
            public System.String CertificateArn { get; set; }
            public byte[] Passphrase { get; set; }
        }
        
    }
}
