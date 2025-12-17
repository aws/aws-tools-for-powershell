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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Creates a certificate signing request (CSR) from a key pair.
    /// </summary>
    [Cmdlet("Get", "PAYCCCertificateSigningRequest")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane GetCertificateSigningRequest API operation.", Operation = new[] {"GetCertificateSigningRequest"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse))]
    [AWSCmdletOutput("System.String or Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPAYCCCertificateSigningRequestCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificateSubject_City
        /// <summary>
        /// <para>
        /// <para>The city you provide to create the certificate signing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateSubject_City { get; set; }
        #endregion
        
        #region Parameter CertificateSubject_CommonName
        /// <summary>
        /// <para>
        /// <para>The name you provide to create the certificate signing request.</para>
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
        public System.String CertificateSubject_CommonName { get; set; }
        #endregion
        
        #region Parameter CertificateSubject_Country
        /// <summary>
        /// <para>
        /// <para>The country you provide to create the certificate signing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateSubject_Country { get; set; }
        #endregion
        
        #region Parameter CertificateSubject_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address you provide to create the certificate signing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateSubject_EmailAddress { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>Asymmetric key used for generating the certificate signing request</para>
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
        public System.String KeyIdentifier { get; set; }
        #endregion
        
        #region Parameter CertificateSubject_Organization
        /// <summary>
        /// <para>
        /// <para>The organization you provide to create the certificate signing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateSubject_Organization { get; set; }
        #endregion
        
        #region Parameter CertificateSubject_OrganizationUnit
        /// <summary>
        /// <para>
        /// <para>The organization unit you provide to create the certificate signing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateSubject_OrganizationUnit { get; set; }
        #endregion
        
        #region Parameter SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The cryptographic algorithm used to sign your CSR.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptography.SigningAlgorithmType")]
        public Amazon.PaymentCryptography.SigningAlgorithmType SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter CertificateSubject_StateOrProvince
        /// <summary>
        /// <para>
        /// <para>The state or province you provide to create the certificate signing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateSubject_StateOrProvince { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateSigningRequest'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateSigningRequest";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse, GetPAYCCCertificateSigningRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateSubject_City = this.CertificateSubject_City;
            context.CertificateSubject_CommonName = this.CertificateSubject_CommonName;
            #if MODULAR
            if (this.CertificateSubject_CommonName == null && ParameterWasBound(nameof(this.CertificateSubject_CommonName)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateSubject_CommonName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateSubject_Country = this.CertificateSubject_Country;
            context.CertificateSubject_EmailAddress = this.CertificateSubject_EmailAddress;
            context.CertificateSubject_Organization = this.CertificateSubject_Organization;
            context.CertificateSubject_OrganizationUnit = this.CertificateSubject_OrganizationUnit;
            context.CertificateSubject_StateOrProvince = this.CertificateSubject_StateOrProvince;
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SigningAlgorithm = this.SigningAlgorithm;
            #if MODULAR
            if (this.SigningAlgorithm == null && ParameterWasBound(nameof(this.SigningAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptography.Model.GetCertificateSigningRequestRequest();
            
            
             // populate CertificateSubject
            var requestCertificateSubjectIsNull = true;
            request.CertificateSubject = new Amazon.PaymentCryptography.Model.CertificateSubjectType();
            System.String requestCertificateSubject_certificateSubject_City = null;
            if (cmdletContext.CertificateSubject_City != null)
            {
                requestCertificateSubject_certificateSubject_City = cmdletContext.CertificateSubject_City;
            }
            if (requestCertificateSubject_certificateSubject_City != null)
            {
                request.CertificateSubject.City = requestCertificateSubject_certificateSubject_City;
                requestCertificateSubjectIsNull = false;
            }
            System.String requestCertificateSubject_certificateSubject_CommonName = null;
            if (cmdletContext.CertificateSubject_CommonName != null)
            {
                requestCertificateSubject_certificateSubject_CommonName = cmdletContext.CertificateSubject_CommonName;
            }
            if (requestCertificateSubject_certificateSubject_CommonName != null)
            {
                request.CertificateSubject.CommonName = requestCertificateSubject_certificateSubject_CommonName;
                requestCertificateSubjectIsNull = false;
            }
            System.String requestCertificateSubject_certificateSubject_Country = null;
            if (cmdletContext.CertificateSubject_Country != null)
            {
                requestCertificateSubject_certificateSubject_Country = cmdletContext.CertificateSubject_Country;
            }
            if (requestCertificateSubject_certificateSubject_Country != null)
            {
                request.CertificateSubject.Country = requestCertificateSubject_certificateSubject_Country;
                requestCertificateSubjectIsNull = false;
            }
            System.String requestCertificateSubject_certificateSubject_EmailAddress = null;
            if (cmdletContext.CertificateSubject_EmailAddress != null)
            {
                requestCertificateSubject_certificateSubject_EmailAddress = cmdletContext.CertificateSubject_EmailAddress;
            }
            if (requestCertificateSubject_certificateSubject_EmailAddress != null)
            {
                request.CertificateSubject.EmailAddress = requestCertificateSubject_certificateSubject_EmailAddress;
                requestCertificateSubjectIsNull = false;
            }
            System.String requestCertificateSubject_certificateSubject_Organization = null;
            if (cmdletContext.CertificateSubject_Organization != null)
            {
                requestCertificateSubject_certificateSubject_Organization = cmdletContext.CertificateSubject_Organization;
            }
            if (requestCertificateSubject_certificateSubject_Organization != null)
            {
                request.CertificateSubject.Organization = requestCertificateSubject_certificateSubject_Organization;
                requestCertificateSubjectIsNull = false;
            }
            System.String requestCertificateSubject_certificateSubject_OrganizationUnit = null;
            if (cmdletContext.CertificateSubject_OrganizationUnit != null)
            {
                requestCertificateSubject_certificateSubject_OrganizationUnit = cmdletContext.CertificateSubject_OrganizationUnit;
            }
            if (requestCertificateSubject_certificateSubject_OrganizationUnit != null)
            {
                request.CertificateSubject.OrganizationUnit = requestCertificateSubject_certificateSubject_OrganizationUnit;
                requestCertificateSubjectIsNull = false;
            }
            System.String requestCertificateSubject_certificateSubject_StateOrProvince = null;
            if (cmdletContext.CertificateSubject_StateOrProvince != null)
            {
                requestCertificateSubject_certificateSubject_StateOrProvince = cmdletContext.CertificateSubject_StateOrProvince;
            }
            if (requestCertificateSubject_certificateSubject_StateOrProvince != null)
            {
                request.CertificateSubject.StateOrProvince = requestCertificateSubject_certificateSubject_StateOrProvince;
                requestCertificateSubjectIsNull = false;
            }
             // determine if request.CertificateSubject should be set to null
            if (requestCertificateSubjectIsNull)
            {
                request.CertificateSubject = null;
            }
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
            }
            if (cmdletContext.SigningAlgorithm != null)
            {
                request.SigningAlgorithm = cmdletContext.SigningAlgorithm;
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
        
        private Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.GetCertificateSigningRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "GetCertificateSigningRequest");
            try
            {
                #if DESKTOP
                return client.GetCertificateSigningRequest(request);
                #elif CORECLR
                return client.GetCertificateSigningRequestAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateSubject_City { get; set; }
            public System.String CertificateSubject_CommonName { get; set; }
            public System.String CertificateSubject_Country { get; set; }
            public System.String CertificateSubject_EmailAddress { get; set; }
            public System.String CertificateSubject_Organization { get; set; }
            public System.String CertificateSubject_OrganizationUnit { get; set; }
            public System.String CertificateSubject_StateOrProvince { get; set; }
            public System.String KeyIdentifier { get; set; }
            public Amazon.PaymentCryptography.SigningAlgorithmType SigningAlgorithm { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.GetCertificateSigningRequestResponse, GetPAYCCCertificateSigningRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateSigningRequest;
        }
        
    }
}
