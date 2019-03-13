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
    /// Lists information about a specific audit report created by calling the <a>CreateCertificateAuthorityAuditReport</a>
    /// operation. Audit information is created every time the certificate authority (CA)
    /// private key is used. The private key is used when you call the <a>IssueCertificate</a>
    /// operation or the <a>RevokeCertificate</a> operation.
    /// </summary>
    [Cmdlet("Get", "PCACertificateAuthorityAuditReport")]
    [OutputType("Amazon.ACMPCA.Model.DescribeCertificateAuthorityAuditReportResponse")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority DescribeCertificateAuthorityAuditReport API operation.", Operation = new[] {"DescribeCertificateAuthorityAuditReport"})]
    [AWSCmdletOutput("Amazon.ACMPCA.Model.DescribeCertificateAuthorityAuditReportResponse",
        "This cmdlet returns a Amazon.ACMPCA.Model.DescribeCertificateAuthorityAuditReportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPCACertificateAuthorityAuditReportCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter AuditReportId
        /// <summary>
        /// <para>
        /// <para>The report ID returned by calling the <a>CreateCertificateAuthorityAuditReport</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String AuditReportId { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the private CA. This must be of the form:</para><para><code>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateAuthorityArn { get; set; }
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
            
            context.AuditReportId = this.AuditReportId;
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            
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
            var request = new Amazon.ACMPCA.Model.DescribeCertificateAuthorityAuditReportRequest();
            
            if (cmdletContext.AuditReportId != null)
            {
                request.AuditReportId = cmdletContext.AuditReportId;
            }
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
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
        
        private Amazon.ACMPCA.Model.DescribeCertificateAuthorityAuditReportResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.DescribeCertificateAuthorityAuditReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "DescribeCertificateAuthorityAuditReport");
            try
            {
                #if DESKTOP
                return client.DescribeCertificateAuthorityAuditReport(request);
                #elif CORECLR
                return client.DescribeCertificateAuthorityAuditReportAsync(request).GetAwaiter().GetResult();
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
            public System.String AuditReportId { get; set; }
            public System.String CertificateAuthorityArn { get; set; }
        }
        
    }
}
