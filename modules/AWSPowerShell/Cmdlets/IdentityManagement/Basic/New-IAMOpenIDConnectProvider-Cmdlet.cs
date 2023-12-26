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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Creates an IAM entity to describe an identity provider (IdP) that supports <a href="http://openid.net/connect/">OpenID
    /// Connect (OIDC)</a>.
    /// 
    ///  
    /// <para>
    /// The OIDC provider that you create with this operation can be used as a principal in
    /// a role's trust policy. Such a policy establishes a trust relationship between Amazon
    /// Web Services and the OIDC provider.
    /// </para><para>
    /// If you are using an OIDC identity provider from Google, Facebook, or Amazon Cognito,
    /// you don't need to create a separate IAM identity provider. These OIDC identity providers
    /// are already built-in to Amazon Web Services and are available for your use. Instead,
    /// you can move directly to creating new roles using your identity provider. To learn
    /// more, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_create_for-idp_oidc.html">Creating
    /// a role for web identity or OpenID connect federation</a> in the <i>IAM User Guide</i>.
    /// </para><para>
    /// When you create the IAM OIDC provider, you specify the following:
    /// </para><ul><li><para>
    /// The URL of the OIDC identity provider (IdP) to trust
    /// </para></li><li><para>
    /// A list of client IDs (also known as audiences) that identify the application or applications
    /// allowed to authenticate using the OIDC provider
    /// </para></li><li><para>
    /// A list of tags that are attached to the specified IAM OIDC provider
    /// </para></li><li><para>
    /// A list of thumbprints of one or more server certificates that the IdP uses
    /// </para></li></ul><para>
    /// You get all of this information from the OIDC IdP you want to use to access Amazon
    /// Web Services.
    /// </para><note><para>
    /// Amazon Web Services secures communication with some OIDC identity providers (IdPs)
    /// through our library of trusted root certificate authorities (CAs) instead of using
    /// a certificate thumbprint to verify your IdP server certificate. In these cases, your
    /// legacy thumbprint remains in your configuration, but is no longer used for validation.
    /// These OIDC IdPs include Auth0, GitHub, GitLab, Google, and those that use an Amazon
    /// S3 bucket to host a JSON Web Key Set (JWKS) endpoint.
    /// </para></note><note><para>
    /// The trust for the OIDC provider is derived from the IAM provider that this operation
    /// creates. Therefore, it is best to limit access to the <a>CreateOpenIDConnectProvider</a>
    /// operation to highly privileged users.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "IAMOpenIDConnectProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateOpenIDConnectProvider API operation.", Operation = new[] {"CreateOpenIDConnectProvider"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse))]
    [AWSCmdletOutput("System.String or Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIAMOpenIDConnectProviderCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientIDList
        /// <summary>
        /// <para>
        /// <para>Provides a list of client IDs, also known as audiences. When a mobile or web app registers
        /// with an OpenID Connect provider, they establish a value that identifies the application.
        /// This is the value that's sent as the <code>client_id</code> parameter on OAuth requests.</para><para>You can register multiple client IDs with the same provider. For example, you might
        /// have multiple applications that use the same OIDC provider. You cannot register more
        /// than 100 client IDs with a single IAM OIDC provider.</para><para>There is no defined format for a client ID. The <code>CreateOpenIDConnectProviderRequest</code>
        /// operation accepts client IDs up to 255 characters long.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ClientIDList { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags that you want to attach to the new IAM OpenID Connect (OIDC) provider.
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
        
        #region Parameter ThumbprintList
        /// <summary>
        /// <para>
        /// <para>A list of server certificate thumbprints for the OpenID Connect (OIDC) identity provider's
        /// server certificates. Typically this list includes only one entry. However, IAM lets
        /// you have up to five thumbprints for an OIDC provider. This lets you maintain multiple
        /// thumbprints if the identity provider is rotating certificates.</para><para>The server certificate thumbprint is the hex-encoded SHA-1 hash value of the X.509
        /// certificate used by the domain where the OpenID Connect provider makes its keys available.
        /// It is always a 40-character string.</para><para>You must provide at least one thumbprint when creating an IAM OIDC provider. For example,
        /// assume that the OIDC provider is <code>server.example.com</code> and the provider
        /// stores its keys at https://keys.server.example.com/openid-connect. In that case, the
        /// thumbprint string would be the hex-encoded SHA-1 hash value of the certificate used
        /// by <code>https://keys.server.example.com.</code></para><para>For more information about obtaining the OIDC provider thumbprint, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/identity-providers-oidc-obtain-thumbprint.html">Obtaining
        /// the thumbprint for an OpenID Connect provider</a> in the <i>IAM user Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] ThumbprintList { get; set; }
        #endregion
        
        #region Parameter Url
        /// <summary>
        /// <para>
        /// <para>The URL of the identity provider. The URL must begin with <code>https://</code> and
        /// should correspond to the <code>iss</code> claim in the provider's OpenID Connect ID
        /// tokens. Per the OIDC standard, path components are allowed but query parameters are
        /// not. Typically the URL consists of only a hostname, like <code>https://server.example.org</code>
        /// or <code>https://example.com</code>. The URL should not contain a port number. </para><para>You cannot register the same provider multiple times in a single Amazon Web Services
        /// account. If you try to submit a URL that has already been used for an OpenID Connect
        /// provider in the Amazon Web Services account, you will get an error.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OpenIDConnectProviderArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OpenIDConnectProviderArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Url parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Url' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Url' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Url), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMOpenIDConnectProvider (CreateOpenIDConnectProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse, NewIAMOpenIDConnectProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Url;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ClientIDList != null)
            {
                context.ClientIDList = new List<System.String>(this.ClientIDList);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IdentityManagement.Model.Tag>(this.Tag);
            }
            if (this.ThumbprintList != null)
            {
                context.ThumbprintList = new List<System.String>(this.ThumbprintList);
            }
            #if MODULAR
            if (this.ThumbprintList == null && ParameterWasBound(nameof(this.ThumbprintList)))
            {
                WriteWarning("You are passing $null as a value for parameter ThumbprintList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Url = this.Url;
            #if MODULAR
            if (this.Url == null && ParameterWasBound(nameof(this.Url)))
            {
                WriteWarning("You are passing $null as a value for parameter Url which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderRequest();
            
            if (cmdletContext.ClientIDList != null)
            {
                request.ClientIDList = cmdletContext.ClientIDList;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ThumbprintList != null)
            {
                request.ThumbprintList = cmdletContext.ThumbprintList;
            }
            if (cmdletContext.Url != null)
            {
                request.Url = cmdletContext.Url;
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
        
        private Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "CreateOpenIDConnectProvider");
            try
            {
                #if DESKTOP
                return client.CreateOpenIDConnectProvider(request);
                #elif CORECLR
                return client.CreateOpenIDConnectProviderAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ClientIDList { get; set; }
            public List<Amazon.IdentityManagement.Model.Tag> Tag { get; set; }
            public List<System.String> ThumbprintList { get; set; }
            public System.String Url { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse, NewIAMOpenIDConnectProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OpenIDConnectProviderArn;
        }
        
    }
}
