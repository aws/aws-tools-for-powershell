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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns information about one or more Amazon Lightsail SSL/TLS certificates.
    /// 
    ///  <note><para>
    /// To get a summary of a certificate, ommit <code>includeCertificateDetails</code> from
    /// your request. The response will include only the certificate Amazon Resource Name
    /// (ARN), certificate name, domain name, and tags.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "LSCertificate")]
    [OutputType("Amazon.Lightsail.Model.CertificateSummary")]
    [AWSCmdlet("Calls the Amazon Lightsail GetCertificates API operation.", Operation = new[] {"GetCertificates"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetCertificatesResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.CertificateSummary or Amazon.Lightsail.Model.GetCertificatesResponse",
        "This cmdlet returns a collection of Amazon.Lightsail.Model.CertificateSummary objects.",
        "The service call response (type Amazon.Lightsail.Model.GetCertificatesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLSCertificateCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateName
        /// <summary>
        /// <para>
        /// <para>The name for the certificate for which to return information.</para><para>When omitted, the response includes all of your certificates in the Amazon Web Services
        /// Region where the request is made.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateName { get; set; }
        #endregion
        
        #region Parameter CertificateStatus
        /// <summary>
        /// <para>
        /// <para>The status of the certificates for which to return information.</para><para>For example, specify <code>ISSUED</code> to return only certificates with an <code>ISSUED</code>
        /// status.</para><para>When omitted, the response includes all of your certificates in the Amazon Web Services
        /// Region where the request is made, regardless of their current status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CertificateStatuses")]
        public System.String[] CertificateStatus { get; set; }
        #endregion
        
        #region Parameter IncludeCertificateDetail
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include detailed information about the certificates in the response.</para><para>When omitted, the response includes only the certificate names, Amazon Resource Names
        /// (ARNs), domain names, and tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeCertificateDetails")]
        public System.Boolean? IncludeCertificateDetail { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Certificates'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetCertificatesResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetCertificatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Certificates";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CertificateName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CertificateName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CertificateName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetCertificatesResponse, GetLSCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CertificateName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateName = this.CertificateName;
            if (this.CertificateStatus != null)
            {
                context.CertificateStatus = new List<System.String>(this.CertificateStatus);
            }
            context.IncludeCertificateDetail = this.IncludeCertificateDetail;
            
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
            var request = new Amazon.Lightsail.Model.GetCertificatesRequest();
            
            if (cmdletContext.CertificateName != null)
            {
                request.CertificateName = cmdletContext.CertificateName;
            }
            if (cmdletContext.CertificateStatus != null)
            {
                request.CertificateStatuses = cmdletContext.CertificateStatus;
            }
            if (cmdletContext.IncludeCertificateDetail != null)
            {
                request.IncludeCertificateDetails = cmdletContext.IncludeCertificateDetail.Value;
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
        
        private Amazon.Lightsail.Model.GetCertificatesResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetCertificatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetCertificates");
            try
            {
                #if DESKTOP
                return client.GetCertificates(request);
                #elif CORECLR
                return client.GetCertificatesAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateName { get; set; }
            public List<System.String> CertificateStatus { get; set; }
            public System.Boolean? IncludeCertificateDetail { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetCertificatesResponse, GetLSCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Certificates;
        }
        
    }
}
