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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Uploads a server certificate entity for the Amazon Web Services account. The server
    /// certificate entity includes a public key certificate, a private key, and an optional
    /// certificate chain, which should all be PEM-encoded.
    /// 
    ///  
    /// <para>
    /// We recommend that you use <a href="https://docs.aws.amazon.com/acm/">Certificate Manager</a>
    /// to provision, manage, and deploy your server certificates. With ACM you can request
    /// a certificate, deploy it to Amazon Web Services resources, and let ACM handle certificate
    /// renewals for you. Certificates provided by ACM are free. For more information about
    /// using ACM, see the <a href="https://docs.aws.amazon.com/acm/latest/userguide/">Certificate
    /// Manager User Guide</a>.
    /// </para><para>
    /// For more information about working with server certificates, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_server-certs.html">Working
    /// with server certificates</a> in the <i>IAM User Guide</i>. This topic includes a list
    /// of Amazon Web Services services that can use the server certificates that you manage
    /// with IAM.
    /// </para><para>
    /// For information about the number of server certificates you can upload, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_iam-quotas.html">IAM
    /// and STS quotas</a> in the <i>IAM User Guide</i>.
    /// </para><note><para>
    /// Because the body of the public key certificate, private key, and the certificate chain
    /// can be large, you should use POST rather than GET when calling <c>UploadServerCertificate</c>.
    /// For information about setting up signatures and authorization through the API, see
    /// <a href="https://docs.aws.amazon.com/general/latest/gr/signing_aws_api_requests.html">Signing
    /// Amazon Web Services API requests</a> in the <i>Amazon Web Services General Reference</i>.
    /// For general information about using the Query API with IAM, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/programming.html">Calling
    /// the API by making HTTP query requests</a> in the <i>IAM User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Publish", "IAMServerCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.ServerCertificateMetadata")]
    [AWSCmdlet("Calls the AWS Identity and Access Management UploadServerCertificate API operation.", Operation = new[] {"UploadServerCertificate"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.UploadServerCertificateResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.ServerCertificateMetadata or Amazon.IdentityManagement.Model.UploadServerCertificateResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.ServerCertificateMetadata object.",
        "The service call response (type Amazon.IdentityManagement.Model.UploadServerCertificateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class PublishIAMServerCertificateCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CertificateBody
        /// <summary>
        /// <para>
        /// <para>The contents of the public key certificate in PEM-encoded format.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> used to validate this
        /// parameter is a string of characters consisting of the following:</para><ul><li><para>Any printable ASCII character ranging from the space character (<c>\u0020</c>) through
        /// the end of the ASCII character range</para></li><li><para>The printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// <c>\u00FF</c>)</para></li><li><para>The special characters tab (<c>\u0009</c>), line feed (<c>\u000A</c>), and carriage
        /// return (<c>\u000D</c>)</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CertificateBody { get; set; }
        #endregion
        
        #region Parameter CertificateChain
        /// <summary>
        /// <para>
        /// <para>The contents of the certificate chain. This is typically a concatenation of the PEM-encoded
        /// public key certificates of the chain.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> used to validate this
        /// parameter is a string of characters consisting of the following:</para><ul><li><para>Any printable ASCII character ranging from the space character (<c>\u0020</c>) through
        /// the end of the ASCII character range</para></li><li><para>The printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// <c>\u00FF</c>)</para></li><li><para>The special characters tab (<c>\u0009</c>), line feed (<c>\u000A</c>), and carriage
        /// return (<c>\u000D</c>)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        public System.String CertificateChain { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para>The path for the server certificate. For more information about paths, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">IAM
        /// identifiers</a> in the <i>IAM User Guide</i>.</para><para>This parameter is optional. If it is not included, it defaults to a slash (/). This
        /// parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex pattern</a>)
        /// a string of characters consisting of either a forward slash (/) by itself or a string
        /// that must begin and end with forward slashes. In addition, it can contain any ASCII
        /// character from the ! (<c>\u0021</c>) through the DEL character (<c>\u007F</c>), including
        /// most punctuation characters, digits, and upper and lowercased letters.</para><note><para> If you are uploading a server certificate specifically for use with Amazon CloudFront
        /// distributions, you must specify a path using the <c>path</c> parameter. The path must
        /// begin with <c>/cloudfront</c> and must include a trailing slash (for example, <c>/cloudfront/test/</c>).</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter PrivateKey
        /// <summary>
        /// <para>
        /// <para>The contents of the private key in PEM-encoded format.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> used to validate this
        /// parameter is a string of characters consisting of the following:</para><ul><li><para>Any printable ASCII character ranging from the space character (<c>\u0020</c>) through
        /// the end of the ASCII character range</para></li><li><para>The printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// <c>\u00FF</c>)</para></li><li><para>The special characters tab (<c>\u0009</c>), line feed (<c>\u000A</c>), and carriage
        /// return (<c>\u000D</c>)</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String PrivateKey { get; set; }
        #endregion
        
        #region Parameter ServerCertificateName
        /// <summary>
        /// <para>
        /// <para>The name for the server certificate. Do not include the path in this value. The name
        /// of the certificate cannot contain any spaces.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServerCertificateName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags that you want to attach to the new IAM server certificate resource.
        /// Each tag consists of a key name and an associated value. For more information about
        /// tagging, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_tags.html">Tagging
        /// IAM resources</a> in the <i>IAM User Guide</i>.</para><note><para>If any one of the tags is invalid or if you exceed the allowed maximum number of tags,
        /// then the entire request fails and the resource is not created.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IdentityManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerCertificateMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.UploadServerCertificateResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.UploadServerCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerCertificateMetadata";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Path parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerCertificateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-IAMServerCertificate (UploadServerCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.UploadServerCertificateResponse, PublishIAMServerCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Path;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateBody = this.CertificateBody;
            #if MODULAR
            if (this.CertificateBody == null && ParameterWasBound(nameof(this.CertificateBody)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateBody which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateChain = this.CertificateChain;
            context.Path = this.Path;
            context.PrivateKey = this.PrivateKey;
            #if MODULAR
            if (this.PrivateKey == null && ParameterWasBound(nameof(this.PrivateKey)))
            {
                WriteWarning("You are passing $null as a value for parameter PrivateKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerCertificateName = this.ServerCertificateName;
            #if MODULAR
            if (this.ServerCertificateName == null && ParameterWasBound(nameof(this.ServerCertificateName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerCertificateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IdentityManagement.Model.Tag>(this.Tag);
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
            var request = new Amazon.IdentityManagement.Model.UploadServerCertificateRequest();
            
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IdentityManagement.Model.UploadServerCertificateResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.UploadServerCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "UploadServerCertificate");
            try
            {
                #if DESKTOP
                return client.UploadServerCertificate(request);
                #elif CORECLR
                return client.UploadServerCertificateAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateBody { get; set; }
            public System.String CertificateChain { get; set; }
            public System.String Path { get; set; }
            public System.String PrivateKey { get; set; }
            public System.String ServerCertificateName { get; set; }
            public List<Amazon.IdentityManagement.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.UploadServerCertificateResponse, PublishIAMServerCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerCertificateMetadata;
        }
        
    }
}
