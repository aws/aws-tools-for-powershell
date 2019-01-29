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
    /// Creates a private subordinate certificate authority (CA). You must specify the CA
    /// configuration, the revocation configuration, the CA type, and an optional idempotency
    /// token. The CA configuration specifies the name of the algorithm and key size to be
    /// used to create the CA private key, the type of signing algorithm that the CA uses
    /// to sign, and X.500 subject information. The CRL (certificate revocation list) configuration
    /// specifies the CRL expiration period in days (the validity period of the CRL), the
    /// Amazon S3 bucket that will contain the CRL, and a CNAME alias for the S3 bucket that
    /// is included in certificates issued by the CA. If successful, this operation returns
    /// the Amazon Resource Name (ARN) of the CA.
    /// </summary>
    [Cmdlet("New", "PCACertificateAuthority", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority CreateCertificateAuthority API operation.", Operation = new[] {"CreateCertificateAuthority"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPCACertificateAuthorityCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAuthorityConfiguration
        /// <summary>
        /// <para>
        /// <para>Name and bit size of the private key algorithm, the name of the signing algorithm,
        /// and X.500 certificate subject information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ACMPCA.Model.CertificateAuthorityConfiguration CertificateAuthorityConfiguration { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityType
        /// <summary>
        /// <para>
        /// <para>The type of the certificate authority. Currently, this must be <b>SUBORDINATE</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ACMPCA.CertificateAuthorityType")]
        public Amazon.ACMPCA.CertificateAuthorityType CertificateAuthorityType { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Alphanumeric string that can be used to distinguish between calls to <b>CreateCertificateAuthority</b>.
        /// Idempotency tokens time out after five minutes. Therefore, if you call <b>CreateCertificateAuthority</b>
        /// multiple times with the same idempotency token within a five minute period, ACM PCA
        /// recognizes that you are requesting only one certificate. As a result, ACM PCA issues
        /// only one. If you change the idempotency token for each call, however, ACM PCA recognizes
        /// that you are requesting multiple certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter RevocationConfiguration
        /// <summary>
        /// <para>
        /// <para>Contains a Boolean value that you can use to enable a certification revocation list
        /// (CRL) for the CA, the name of the S3 bucket to which ACM PCA will write the CRL, and
        /// an optional CNAME alias that you can use to hide the name of your bucket in the <b>CRL
        /// Distribution Points</b> extension of your CA certificate. For more information, see
        /// the <a>CrlConfiguration</a> structure. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ACMPCA.Model.RevocationConfiguration RevocationConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that will be attached to the new private CA. You can associate up
        /// to 50 tags with a private CA.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ACMPCA.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCACertificateAuthority (CreateCertificateAuthority)"))
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
            
            context.CertificateAuthorityConfiguration = this.CertificateAuthorityConfiguration;
            context.CertificateAuthorityType = this.CertificateAuthorityType;
            context.IdempotencyToken = this.IdempotencyToken;
            context.RevocationConfiguration = this.RevocationConfiguration;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ACMPCA.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.ACMPCA.Model.CreateCertificateAuthorityRequest();
            
            if (cmdletContext.CertificateAuthorityConfiguration != null)
            {
                request.CertificateAuthorityConfiguration = cmdletContext.CertificateAuthorityConfiguration;
            }
            if (cmdletContext.CertificateAuthorityType != null)
            {
                request.CertificateAuthorityType = cmdletContext.CertificateAuthorityType;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.RevocationConfiguration != null)
            {
                request.RevocationConfiguration = cmdletContext.RevocationConfiguration;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CertificateAuthorityArn;
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
        
        private Amazon.ACMPCA.Model.CreateCertificateAuthorityResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.CreateCertificateAuthorityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "CreateCertificateAuthority");
            try
            {
                #if DESKTOP
                return client.CreateCertificateAuthority(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCertificateAuthorityAsync(request);
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
            public Amazon.ACMPCA.Model.CertificateAuthorityConfiguration CertificateAuthorityConfiguration { get; set; }
            public Amazon.ACMPCA.CertificateAuthorityType CertificateAuthorityType { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Amazon.ACMPCA.Model.RevocationConfiguration RevocationConfiguration { get; set; }
            public List<Amazon.ACMPCA.Model.Tag> Tags { get; set; }
        }
        
    }
}
