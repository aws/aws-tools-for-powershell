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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates an X.509 certificate using the specified certificate signing request.
    /// 
    ///  
    /// <para><b>Note:</b> The CSR must include a public key that is either an RSA key with a length
    /// of at least 2048 bits or an ECC key from NIST P-256 or NIST P-384 curves. 
    /// </para><para><b>Note:</b> Reusing the same certificate signing request (CSR) results in a distinct
    /// certificate.
    /// </para><para>
    /// You can create multiple certificates in a batch by creating a directory, copying multiple
    /// .csr files into that directory, and then specifying that directory on the command
    /// line. The following commands show how to create a batch of certificates given a batch
    /// of CSRs.
    /// </para><para>
    /// Assuming a set of CSRs are located inside of the directory my-csr-directory:
    /// </para><para>
    /// On Linux and OS X, the command is:
    /// </para><para>
    /// $ ls my-csr-directory/ | xargs -I {} aws iot create-certificate-from-csr --certificate-signing-request
    /// file://my-csr-directory/{}
    /// </para><para>
    /// This command lists all of the CSRs in my-csr-directory and pipes each CSR file name
    /// to the aws iot create-certificate-from-csr AWS CLI command to create a certificate
    /// for the corresponding CSR.
    /// </para><para>
    /// The aws iot create-certificate-from-csr part of the command can also be run in parallel
    /// to speed up the certificate creation process:
    /// </para><para>
    /// $ ls my-csr-directory/ | xargs -P 10 -I {} aws iot create-certificate-from-csr --certificate-signing-request
    /// file://my-csr-directory/{}
    /// </para><para>
    /// On Windows PowerShell, the command to create certificates for all CSRs in my-csr-directory
    /// is:
    /// </para><para>
    /// &gt; ls -Name my-csr-directory | %{aws iot create-certificate-from-csr --certificate-signing-request
    /// file://my-csr-directory/$_}
    /// </para><para>
    /// On a Windows command prompt, the command to create certificates for all CSRs in my-csr-directory
    /// is:
    /// </para><para>
    /// &gt; forfiles /p my-csr-directory /c "cmd /c aws iot create-certificate-from-csr --certificate-signing-request
    /// file://@path"
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTCertificateFromCsr")]
    [OutputType("Amazon.IoT.Model.CreateCertificateFromCsrResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateCertificateFromCsr API operation.", Operation = new[] {"CreateCertificateFromCsr"})]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateCertificateFromCsrResponse",
        "This cmdlet returns a Amazon.IoT.Model.CreateCertificateFromCsrResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTCertificateFromCsrCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateSigningRequest
        /// <summary>
        /// <para>
        /// <para>The certificate signing request (CSR).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateSigningRequest { get; set; }
        #endregion
        
        #region Parameter SetAsActive
        /// <summary>
        /// <para>
        /// <para>Specifies whether the certificate is active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SetAsActive { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CertificateSigningRequest = this.CertificateSigningRequest;
            if (ParameterWasBound("SetAsActive"))
                context.SetAsActive = this.SetAsActive;
            
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
            var request = new Amazon.IoT.Model.CreateCertificateFromCsrRequest();
            
            if (cmdletContext.CertificateSigningRequest != null)
            {
                request.CertificateSigningRequest = cmdletContext.CertificateSigningRequest;
            }
            if (cmdletContext.SetAsActive != null)
            {
                request.SetAsActive = cmdletContext.SetAsActive.Value;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoT.Model.CreateCertificateFromCsrResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateCertificateFromCsrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateCertificateFromCsr");
            try
            {
                #if DESKTOP
                return client.CreateCertificateFromCsr(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCertificateFromCsrAsync(request);
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
            public System.String CertificateSigningRequest { get; set; }
            public System.Boolean? SetAsActive { get; set; }
        }
        
    }
}
