/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns a list of the fields contained in the specified certificate. For example,
    /// this function returns the certificate status, a flag that indicates whether the certificate
    /// is associated with any other AWS service, and the date at which the certificate request
    /// was created. The certificate is specified on input by its Amazon Resource Name (ARN).
    /// </summary>
    [Cmdlet("Get", "ACMCertificateDetail")]
    [OutputType("Amazon.CertificateManager.Model.CertificateDetail")]
    [AWSCmdlet("Invokes the DescribeCertificate operation against AWS Certificate Manager.", Operation = new[] {"DescribeCertificate"})]
    [AWSCmdletOutput("Amazon.CertificateManager.Model.CertificateDetail",
        "This cmdlet returns a CertificateDetail object.",
        "The service call response (type Amazon.CertificateManager.Model.DescribeCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetACMCertificateDetailCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para> String that contains a certificate ARN. The ARN must be of the form: </para><para><code>arn:aws:acm:us-east-1:123456789012:certificate/12345678-1234-1234-1234-123456789012</code></para><para> For more information about ARNs, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CertificateArn = this.CertificateArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CertificateManager.Model.DescribeCertificateRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeCertificate(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Certificate;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CertificateArn { get; set; }
        }
        
    }
}
