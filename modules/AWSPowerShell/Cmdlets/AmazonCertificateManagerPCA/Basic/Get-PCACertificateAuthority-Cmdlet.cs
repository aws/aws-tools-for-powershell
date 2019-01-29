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
    /// Lists information about your private certificate authority (CA). You specify the private
    /// CA on input by its ARN (Amazon Resource Name). The output contains the status of your
    /// CA. This can be any of the following: 
    /// 
    ///  <ul><li><para><code>CREATING</code> - ACM PCA is creating your private certificate authority.
    /// </para></li><li><para><code>PENDING_CERTIFICATE</code> - The certificate is pending. You must use your
    /// on-premises root or subordinate CA to sign your private CA CSR and then import it
    /// into PCA. 
    /// </para></li><li><para><code>ACTIVE</code> - Your private CA is active.
    /// </para></li><li><para><code>DISABLED</code> - Your private CA has been disabled.
    /// </para></li><li><para><code>EXPIRED</code> - Your private CA certificate has expired.
    /// </para></li><li><para><code>FAILED</code> - Your private CA has failed. Your CA can fail because of problems
    /// such a network outage or backend AWS failure or other errors. A failed CA can never
    /// return to the pending state. You must create a new CA. 
    /// </para></li><li><para><code>DELETED</code> - Your private CA is within the restoration period, after which
    /// it is permanently deleted. The length of time remaining in the CA's restoration period
    /// is also included in this operation's output.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "PCACertificateAuthority")]
    [OutputType("Amazon.ACMPCA.Model.CertificateAuthority")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority DescribeCertificateAuthority API operation.", Operation = new[] {"DescribeCertificateAuthority"})]
    [AWSCmdletOutput("Amazon.ACMPCA.Model.CertificateAuthority",
        "This cmdlet returns a CertificateAuthority object.",
        "The service call response (type Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a>CreateCertificateAuthority</a>.
        /// This must be of the form: </para><para><code>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
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
            var request = new Amazon.ACMPCA.Model.DescribeCertificateAuthorityRequest();
            
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
                object pipelineOutput = response.CertificateAuthority;
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
        
        private Amazon.ACMPCA.Model.DescribeCertificateAuthorityResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.DescribeCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "DescribeCertificateAuthority");
            try
            {
                #if DESKTOP
                return client.DescribeCertificateAuthority(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeCertificateAuthorityAsync(request);
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
            public System.String CertificateAuthorityArn { get; set; }
        }
        
    }
}
