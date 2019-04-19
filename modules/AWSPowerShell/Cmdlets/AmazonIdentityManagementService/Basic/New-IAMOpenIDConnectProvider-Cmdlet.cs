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
    /// a role's trust policy. Such a policy establishes a trust relationship between AWS
    /// and the OIDC provider.
    /// </para><para>
    /// When you create the IAM OIDC provider, you specify the following:
    /// </para><ul><li><para>
    /// The URL of the OIDC identity provider (IdP) to trust
    /// </para></li><li><para>
    /// A list of client IDs (also known as audiences) that identify the application or applications
    /// that are allowed to authenticate using the OIDC provider
    /// </para></li><li><para>
    /// A list of thumbprints of the server certificate(s) that the IdP uses.
    /// </para></li></ul><para>
    /// You get all of this information from the OIDC IdP that you want to use to access AWS.
    /// </para><note><para>
    /// Because trust for the OIDC provider is derived from the IAM provider that this operation
    /// creates, it is best to limit access to the <a>CreateOpenIDConnectProvider</a> operation
    /// to highly privileged users.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "IAMOpenIDConnectProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateOpenIDConnectProvider API operation.", Operation = new[] {"CreateOpenIDConnectProvider"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateOpenIDConnectProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIAMOpenIDConnectProviderCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ClientIDList
        /// <summary>
        /// <para>
        /// <para>A list of client IDs (also known as audiences). When a mobile or web app registers
        /// with an OpenID Connect provider, they establish a value that identifies the application.
        /// (This is the value that's sent as the <code>client_id</code> parameter on OAuth requests.)</para><para>You can register multiple client IDs with the same provider. For example, you might
        /// have multiple applications that use the same OIDC provider. You cannot register more
        /// than 100 client IDs with a single IAM OIDC provider.</para><para>There is no defined format for a client ID. The <code>CreateOpenIDConnectProviderRequest</code>
        /// operation accepts client IDs up to 255 characters long.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ClientIDList { get; set; }
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
        /// by https://keys.server.example.com.</para><para>For more information about obtaining the OIDC provider's thumbprint, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/identity-providers-oidc-obtain-thumbprint.html">Obtaining
        /// the Thumbprint for an OpenID Connect Provider</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ThumbprintList { get; set; }
        #endregion
        
        #region Parameter Url
        /// <summary>
        /// <para>
        /// <para>The URL of the identity provider. The URL must begin with <code>https://</code> and
        /// should correspond to the <code>iss</code> claim in the provider's OpenID Connect ID
        /// tokens. Per the OIDC standard, path components are allowed but query parameters are
        /// not. Typically the URL consists of only a hostname, like <code>https://server.example.org</code>
        /// or <code>https://example.com</code>.</para><para>You cannot register the same provider multiple times in a single AWS account. If you
        /// try to submit a URL that has already been used for an OpenID Connect provider in the
        /// AWS account, you will get an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Url { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Url", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMOpenIDConnectProvider (CreateOpenIDConnectProvider)"))
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
            
            if (this.ClientIDList != null)
            {
                context.ClientIDList = new List<System.String>(this.ClientIDList);
            }
            if (this.ThumbprintList != null)
            {
                context.ThumbprintList = new List<System.String>(this.ThumbprintList);
            }
            context.Url = this.Url;
            
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.OpenIDConnectProviderArn;
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
            public List<System.String> ThumbprintList { get; set; }
            public System.String Url { get; set; }
        }
        
    }
}
