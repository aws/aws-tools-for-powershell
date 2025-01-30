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
using Amazon.SSOOIDC;
using Amazon.SSOOIDC.Model;

namespace Amazon.PowerShell.Cmdlets.SSOOIDC
{
    /// <summary>
    /// Registers a public client with IAM Identity Center. This allows clients to perform
    /// authorization using the authorization code grant with Proof Key for Code Exchange
    /// (PKCE) or the device code grant.
    /// </summary>
    [Cmdlet("Register", "SSOOIDCClient", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SSOOIDC.Model.RegisterClientResponse")]
    [AWSCmdlet("Calls the AWS Single Sign-On OIDC RegisterClient API operation.", Operation = new[] {"RegisterClient"}, SelectReturnType = typeof(Amazon.SSOOIDC.Model.RegisterClientResponse))]
    [AWSCmdletOutput("Amazon.SSOOIDC.Model.RegisterClientResponse",
        "This cmdlet returns an Amazon.SSOOIDC.Model.RegisterClientResponse object containing multiple properties."
    )]
    public partial class RegisterSSOOIDCClientCmdlet : AmazonSSOOIDCClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientName
        /// <summary>
        /// <para>
        /// <para>The friendly name of the client.</para>
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
        public System.String ClientName { get; set; }
        #endregion
        
        #region Parameter ClientType
        /// <summary>
        /// <para>
        /// <para>The type of client. The service supports only <c>public</c> as a client type. Anything
        /// other than public will be rejected by the service.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ClientType { get; set; }
        #endregion
        
        #region Parameter EntitledApplicationArn
        /// <summary>
        /// <para>
        /// <para>This IAM Identity Center application ARN is used to define administrator-managed configuration
        /// for public client access to resources. At authorization, the scopes, grants, and redirect
        /// URI available to this client will be restricted by this application resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntitledApplicationArn { get; set; }
        #endregion
        
        #region Parameter GrantType
        /// <summary>
        /// <para>
        /// <para>The list of OAuth 2.0 grant types that are defined by the client. This list is used
        /// to restrict the token granting flows available to the client. Supports the following
        /// OAuth 2.0 grant types: Authorization Code, Device Code, and Refresh Token. </para><para>* Authorization Code - <c>authorization_code</c></para><para>* Device Code - <c>urn:ietf:params:oauth:grant-type:device_code</c></para><para>* Refresh Token - <c>refresh_token</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantTypes")]
        public System.String[] GrantType { get; set; }
        #endregion
        
        #region Parameter IssuerUrl
        /// <summary>
        /// <para>
        /// <para>The IAM Identity Center Issuer URL associated with an instance of IAM Identity Center.
        /// This value is needed for user access to resources through the client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IssuerUrl { get; set; }
        #endregion
        
        #region Parameter RedirectUris
        /// <summary>
        /// <para>
        /// <para>The list of redirect URI that are defined by the client. At completion of authorization,
        /// this list is used to restrict what locations the user agent can be redirected back
        /// to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RedirectUris { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The list of scopes that are defined by the client. Upon authorization, this list is
        /// used to restrict permissions when granting an access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scopes")]
        public System.String[] Scope { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOOIDC.Model.RegisterClientResponse).
        /// Specifying the name of a property of type Amazon.SSOOIDC.Model.RegisterClientResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClientName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClientName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClientName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-SSOOIDCClient (RegisterClient)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOOIDC.Model.RegisterClientResponse, RegisterSSOOIDCClientCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClientName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientName = this.ClientName;
            #if MODULAR
            if (this.ClientName == null && ParameterWasBound(nameof(this.ClientName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientType = this.ClientType;
            #if MODULAR
            if (this.ClientType == null && ParameterWasBound(nameof(this.ClientType)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntitledApplicationArn = this.EntitledApplicationArn;
            if (this.GrantType != null)
            {
                context.GrantType = new List<System.String>(this.GrantType);
            }
            context.IssuerUrl = this.IssuerUrl;
            if (this.RedirectUris != null)
            {
                context.RedirectUris = new List<System.String>(this.RedirectUris);
            }
            if (this.Scope != null)
            {
                context.Scope = new List<System.String>(this.Scope);
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
            var request = new Amazon.SSOOIDC.Model.RegisterClientRequest();
            
            if (cmdletContext.ClientName != null)
            {
                request.ClientName = cmdletContext.ClientName;
            }
            if (cmdletContext.ClientType != null)
            {
                request.ClientType = cmdletContext.ClientType;
            }
            if (cmdletContext.EntitledApplicationArn != null)
            {
                request.EntitledApplicationArn = cmdletContext.EntitledApplicationArn;
            }
            if (cmdletContext.GrantType != null)
            {
                request.GrantTypes = cmdletContext.GrantType;
            }
            if (cmdletContext.IssuerUrl != null)
            {
                request.IssuerUrl = cmdletContext.IssuerUrl;
            }
            if (cmdletContext.RedirectUris != null)
            {
                request.RedirectUris = cmdletContext.RedirectUris;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scopes = cmdletContext.Scope;
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
        
        private Amazon.SSOOIDC.Model.RegisterClientResponse CallAWSServiceOperation(IAmazonSSOOIDC client, Amazon.SSOOIDC.Model.RegisterClientRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On OIDC", "RegisterClient");
            try
            {
                #if DESKTOP
                return client.RegisterClient(request);
                #elif CORECLR
                return client.RegisterClientAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientName { get; set; }
            public System.String ClientType { get; set; }
            public System.String EntitledApplicationArn { get; set; }
            public List<System.String> GrantType { get; set; }
            public System.String IssuerUrl { get; set; }
            public List<System.String> RedirectUris { get; set; }
            public List<System.String> Scope { get; set; }
            public System.Func<Amazon.SSOOIDC.Model.RegisterClientResponse, RegisterSSOOIDCClientCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
