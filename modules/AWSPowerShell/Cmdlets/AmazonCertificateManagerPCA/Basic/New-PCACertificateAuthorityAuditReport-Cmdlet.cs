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
    /// Creates an audit report that lists every time that the your CA private key is used.
    /// The report is saved in the Amazon S3 bucket that you specify on input. The <a>IssueCertificate</a>
    /// and <a>RevokeCertificate</a> functions use the private key. You can generate a new
    /// report every 30 minutes.
    /// </summary>
    [Cmdlet("New", "PCACertificateAuthorityAuditReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ACMPCA.Model.CreateCertificateAuthorityAuditReportResponse")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority CreateCertificateAuthorityAuditReport API operation.", Operation = new[] {"CreateCertificateAuthorityAuditReport"})]
    [AWSCmdletOutput("Amazon.ACMPCA.Model.CreateCertificateAuthorityAuditReportResponse",
        "This cmdlet returns a Amazon.ACMPCA.Model.CreateCertificateAuthorityAuditReportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPCACertificateAuthorityAuditReportCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter AuditReportResponseFormat
        /// <summary>
        /// <para>
        /// <para>Format in which to create the report. This can be either <b>JSON</b> or <b>CSV</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ACMPCA.AuditReportResponseFormat")]
        public Amazon.ACMPCA.AuditReportResponseFormat AuditReportResponseFormat { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the CA to be audited. This is of the form:</para><para><code>arn:aws:acm:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket that will contain the audit report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String S3BucketName { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCACertificateAuthorityAuditReport (CreateCertificateAuthorityAuditReport)"))
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
            
            context.AuditReportResponseFormat = this.AuditReportResponseFormat;
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            context.S3BucketName = this.S3BucketName;
            
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
            var request = new Amazon.ACMPCA.Model.CreateCertificateAuthorityAuditReportRequest();
            
            if (cmdletContext.AuditReportResponseFormat != null)
            {
                request.AuditReportResponseFormat = cmdletContext.AuditReportResponseFormat;
            }
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
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
        
        private Amazon.ACMPCA.Model.CreateCertificateAuthorityAuditReportResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.CreateCertificateAuthorityAuditReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "CreateCertificateAuthorityAuditReport");
            try
            {
                #if DESKTOP
                return client.CreateCertificateAuthorityAuditReport(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCertificateAuthorityAuditReportAsync(request);
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
            public Amazon.ACMPCA.AuditReportResponseFormat AuditReportResponseFormat { get; set; }
            public System.String CertificateAuthorityArn { get; set; }
            public System.String S3BucketName { get; set; }
        }
        
    }
}
