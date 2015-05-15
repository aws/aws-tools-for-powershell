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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Uploads a server certificate entity for the AWS account. The server certificate entity
    /// includes a public key certificate, a private key, and an optional certificate chain,
    /// which should all be PEM-encoded. 
    /// 
    ///  
    /// <para>
    /// For information about the number of server certificates you can upload, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/LimitationsOnEntities.html">Limitations
    /// on IAM Entities</a> in the <i>Using IAM</i> guide. 
    /// </para><note>Because the body of the public key certificate, private key, and the certificate
    /// chain can be large, you should use POST rather than GET when calling <code>UploadServerCertificate</code>.
    /// For information about setting up signatures and authorization through the API, go
    /// to <a href="http://docs.aws.amazon.com/general/latest/gr/signing_aws_api_requests.html">Signing
    /// AWS API Requests</a> in the <i>AWS General Reference</i>. For general information
    /// about using the Query API with IAM, go to <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/IAM_UsingQueryAPI.html">Making
    /// Query Requests</a> in the <i>Using IAM</i> guide. </note>
    /// </summary>
    [Cmdlet("Publish", "IAMServerCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.ServerCertificateMetadata")]
    [AWSCmdlet("Invokes the UploadServerCertificate operation against AWS Identity and Access Management.", Operation = new[] {"UploadServerCertificate"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ServerCertificateMetadata",
        "This cmdlet returns a ServerCertificateMetadata object.",
        "The service call response (type UploadServerCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class PublishIAMServerCertificateCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The contents of the public key certificate in PEM-encoded format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String CertificateBody { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The contents of the certificate chain. This is typically a concatenation of the PEM-encoded
        /// public key certificates of the chain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4)]
        public String CertificateChain { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The path for the server certificate. For more information about paths, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">IAM
        /// Identifiers</a> in the <i>Using IAM</i> guide. </para><para>This parameter is optional. If it is not included, it defaults to a slash (/).</para><note> If you are uploading a server certificate specifically for use with Amazon
        /// CloudFront distributions, you must specify a path using the <code>--path</code> option.
        /// The path must begin with <code>/cloudfront</code> and must include a trailing slash
        /// (for example, <code>/cloudfront/test/</code>). </note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String Path { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The contents of the private key in PEM-encoded format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public String PrivateKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name for the server certificate. Do not include the path in this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String ServerCertificateName { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServerCertificateName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-IAMServerCertificate (UploadServerCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CertificateBody = this.CertificateBody;
            context.CertificateChain = this.CertificateChain;
            context.Path = this.Path;
            context.PrivateKey = this.PrivateKey;
            context.ServerCertificateName = this.ServerCertificateName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UploadServerCertificateRequest();
            
            if (cmdletContext.CertificateBody != null)
            {
                request.CertificateBody = cmdletContext.CertificateBody;
            }
            if (cmdletContext.CertificateChain != null)
            {
                request.CertificateChain = cmdletContext.CertificateChain;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.PrivateKey != null)
            {
                request.PrivateKey = cmdletContext.PrivateKey;
            }
            if (cmdletContext.ServerCertificateName != null)
            {
                request.ServerCertificateName = cmdletContext.ServerCertificateName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UploadServerCertificate(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ServerCertificateMetadata;
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
            public String CertificateBody { get; set; }
            public String CertificateChain { get; set; }
            public String Path { get; set; }
            public String PrivateKey { get; set; }
            public String ServerCertificateName { get; set; }
        }
        
    }
}
