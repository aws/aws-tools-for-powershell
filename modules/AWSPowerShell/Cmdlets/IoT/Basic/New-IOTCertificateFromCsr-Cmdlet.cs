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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates an X.509 certificate using the specified certificate signing request.
    /// 
    ///  
    /// <para><b>Note:</b> The CSR must include a public key that is either an RSA key with a length
    /// of at least 2048 bits or an ECC key from NIST P-256, NIST P-384, or NIST P-512 curves.
    /// For supported certificates, consult <a href="https://docs.aws.amazon.com/iot/latest/developerguide/x509-client-certs.html#x509-cert-algorithms">
    /// Certificate signing algorithms supported by IoT</a>.
    /// </para><para><b>Note:</b> Reusing the same certificate signing request (CSR) results in a distinct
    /// certificate.
    /// </para><para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateCertificateFromCsr</a>
    /// action.
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
    /// to the aws iot create-certificate-from-csr Amazon Web Services CLI command to create
    /// a certificate for the corresponding CSR.
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
    [AWSCmdlet("Calls the AWS IoT CreateCertificateFromCsr API operation.", Operation = new[] {"CreateCertificateFromCsr"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateCertificateFromCsrResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateCertificateFromCsrResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateCertificateFromCsrResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTCertificateFromCsrCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateSigningRequest
        /// <summary>
        /// <para>
        /// <para>The certificate signing request (CSR).</para>
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
        public System.String CertificateSigningRequest { get; set; }
        #endregion
        
        #region Parameter SetAsActive
        /// <summary>
        /// <para>
        /// <para>Specifies whether the certificate is active.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SetAsActive { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateCertificateFromCsrResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateCertificateFromCsrResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateCertificateFromCsrResponse, NewIOTCertificateFromCsrCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateSigningRequest = this.CertificateSigningRequest;
            #if MODULAR
            if (this.CertificateSigningRequest == null && ParameterWasBound(nameof(this.CertificateSigningRequest)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateSigningRequest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        private Amazon.IoT.Model.CreateCertificateFromCsrResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateCertificateFromCsrRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateCertificateFromCsr");
            try
            {
                #if DESKTOP
                return client.CreateCertificateFromCsr(request);
                #elif CORECLR
                return client.CreateCertificateFromCsrAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.IoT.Model.CreateCertificateFromCsrResponse, NewIOTCertificateFromCsrCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
