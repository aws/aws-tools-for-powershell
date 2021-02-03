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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Associate an identity provider configuration to a cluster.
    /// 
    ///  
    /// <para>
    /// If you want to authenticate identities using an identity provider, you can create
    /// an identity provider configuration and associate it to your cluster. After configuring
    /// authentication to your cluster you can create Kubernetes <code>roles</code> and <code>clusterroles</code>
    /// to assign permissions to the roles, and then bind the roles to the identities using
    /// Kubernetes <code>rolebindings</code> and <code>clusterrolebindings</code>. For more
    /// information see <a href="https://kubernetes.io/docs/reference/access-authn-authz/rbac/">Using
    /// RBAC Authorization</a> in the Kubernetes documentation.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "EKSIdentityProviderConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.AssociateIdentityProviderConfigResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes AssociateIdentityProviderConfig API operation.", Operation = new[] {"AssociateIdentityProviderConfig"}, SelectReturnType = typeof(Amazon.EKS.Model.AssociateIdentityProviderConfigResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.AssociateIdentityProviderConfigResponse",
        "This cmdlet returns an Amazon.EKS.Model.AssociateIdentityProviderConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddEKSIdentityProviderConfigCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        #region Parameter Oidc_ClientId
        /// <summary>
        /// <para>
        /// <para>This is also known as <i>audience</i>. The ID for the client application that makes
        /// authentication requests to the OpenID identity provider.</para>
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
        public System.String Oidc_ClientId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster to associate the configuration to.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter Oidc_GroupsClaim
        /// <summary>
        /// <para>
        /// <para>The JWT claim that the provider uses to return your groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oidc_GroupsClaim { get; set; }
        #endregion
        
        #region Parameter Oidc_GroupsPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix that is prepended to group claims to prevent clashes with existing names
        /// (such as <code>system:</code> groups). For example, the value<code> oidc:</code> will
        /// create group names like <code>oidc:engineering</code> and <code>oidc:infra</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oidc_GroupsPrefix { get; set; }
        #endregion
        
        #region Parameter Oidc_IdentityProviderConfigName
        /// <summary>
        /// <para>
        /// <para>The name of the OIDC provider configuration.</para>
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
        public System.String Oidc_IdentityProviderConfigName { get; set; }
        #endregion
        
        #region Parameter Oidc_IssuerUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the OpenID identity provider that allows the API server to discover public
        /// signing keys for verifying tokens. The URL must begin with <code>https://</code> and
        /// should correspond to the <code>iss</code> claim in the provider's OIDC ID tokens.
        /// Per the OIDC standard, path components are allowed but query parameters are not. Typically
        /// the URL consists of only a hostname, like <code>https://server.example.org</code>
        /// or <code>https://example.com</code>. This URL should point to the level below <code>.well-known/openid-configuration</code>
        /// and must be publicly accessible over the internet.</para>
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
        public System.String Oidc_IssuerUrl { get; set; }
        #endregion
        
        #region Parameter Oidc_RequiredClaim
        /// <summary>
        /// <para>
        /// <para>The key value pairs that describe required claims in the identity token. If set, each
        /// claim is verified to be present in the token with a matching value. For the maximum
        /// number of claims that you can require, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/service-quotas.html">Amazon
        /// EKS service quotas</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oidc_RequiredClaims")]
        public System.Collections.Hashtable Oidc_RequiredClaim { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata to apply to the configuration to assist with categorization and organization.
        /// Each tag consists of a key and an optional value, both of which you define.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Oidc_UsernameClaim
        /// <summary>
        /// <para>
        /// <para>The JSON Web Token (JWT) claim to use as the username. The default is <code>sub</code>,
        /// which is expected to be a unique identifier of the end user. You can choose other
        /// claims, such as <code>email</code> or <code>name</code>, depending on the OpenID identity
        /// provider. Claims other than <code>email</code> are prefixed with the issuer URL to
        /// prevent naming clashes with other plug-ins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oidc_UsernameClaim { get; set; }
        #endregion
        
        #region Parameter Oidc_UsernamePrefix
        /// <summary>
        /// <para>
        /// <para>The prefix that is prepended to username claims to prevent clashes with existing names.
        /// If you do not provide this field, and <code>username</code> is a value other than
        /// <code>email</code>, the prefix defaults to <code>issuerurl#</code>. You can use the
        /// value <code>-</code> to disable all prefixing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Oidc_UsernamePrefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.AssociateIdentityProviderConfigResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.AssociateIdentityProviderConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EKSIdentityProviderConfig (AssociateIdentityProviderConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.AssociateIdentityProviderConfigResponse, AddEKSIdentityProviderConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Oidc_ClientId = this.Oidc_ClientId;
            #if MODULAR
            if (this.Oidc_ClientId == null && ParameterWasBound(nameof(this.Oidc_ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter Oidc_ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Oidc_GroupsClaim = this.Oidc_GroupsClaim;
            context.Oidc_GroupsPrefix = this.Oidc_GroupsPrefix;
            context.Oidc_IdentityProviderConfigName = this.Oidc_IdentityProviderConfigName;
            #if MODULAR
            if (this.Oidc_IdentityProviderConfigName == null && ParameterWasBound(nameof(this.Oidc_IdentityProviderConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter Oidc_IdentityProviderConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Oidc_IssuerUrl = this.Oidc_IssuerUrl;
            #if MODULAR
            if (this.Oidc_IssuerUrl == null && ParameterWasBound(nameof(this.Oidc_IssuerUrl)))
            {
                WriteWarning("You are passing $null as a value for parameter Oidc_IssuerUrl which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Oidc_RequiredClaim != null)
            {
                context.Oidc_RequiredClaim = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Oidc_RequiredClaim.Keys)
                {
                    context.Oidc_RequiredClaim.Add((String)hashKey, (String)(this.Oidc_RequiredClaim[hashKey]));
                }
            }
            context.Oidc_UsernameClaim = this.Oidc_UsernameClaim;
            context.Oidc_UsernamePrefix = this.Oidc_UsernamePrefix;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.EKS.Model.AssociateIdentityProviderConfigRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Oidc
            var requestOidcIsNull = true;
            request.Oidc = new Amazon.EKS.Model.OidcIdentityProviderConfigRequest();
            System.String requestOidc_oidc_ClientId = null;
            if (cmdletContext.Oidc_ClientId != null)
            {
                requestOidc_oidc_ClientId = cmdletContext.Oidc_ClientId;
            }
            if (requestOidc_oidc_ClientId != null)
            {
                request.Oidc.ClientId = requestOidc_oidc_ClientId;
                requestOidcIsNull = false;
            }
            System.String requestOidc_oidc_GroupsClaim = null;
            if (cmdletContext.Oidc_GroupsClaim != null)
            {
                requestOidc_oidc_GroupsClaim = cmdletContext.Oidc_GroupsClaim;
            }
            if (requestOidc_oidc_GroupsClaim != null)
            {
                request.Oidc.GroupsClaim = requestOidc_oidc_GroupsClaim;
                requestOidcIsNull = false;
            }
            System.String requestOidc_oidc_GroupsPrefix = null;
            if (cmdletContext.Oidc_GroupsPrefix != null)
            {
                requestOidc_oidc_GroupsPrefix = cmdletContext.Oidc_GroupsPrefix;
            }
            if (requestOidc_oidc_GroupsPrefix != null)
            {
                request.Oidc.GroupsPrefix = requestOidc_oidc_GroupsPrefix;
                requestOidcIsNull = false;
            }
            System.String requestOidc_oidc_IdentityProviderConfigName = null;
            if (cmdletContext.Oidc_IdentityProviderConfigName != null)
            {
                requestOidc_oidc_IdentityProviderConfigName = cmdletContext.Oidc_IdentityProviderConfigName;
            }
            if (requestOidc_oidc_IdentityProviderConfigName != null)
            {
                request.Oidc.IdentityProviderConfigName = requestOidc_oidc_IdentityProviderConfigName;
                requestOidcIsNull = false;
            }
            System.String requestOidc_oidc_IssuerUrl = null;
            if (cmdletContext.Oidc_IssuerUrl != null)
            {
                requestOidc_oidc_IssuerUrl = cmdletContext.Oidc_IssuerUrl;
            }
            if (requestOidc_oidc_IssuerUrl != null)
            {
                request.Oidc.IssuerUrl = requestOidc_oidc_IssuerUrl;
                requestOidcIsNull = false;
            }
            Dictionary<System.String, System.String> requestOidc_oidc_RequiredClaim = null;
            if (cmdletContext.Oidc_RequiredClaim != null)
            {
                requestOidc_oidc_RequiredClaim = cmdletContext.Oidc_RequiredClaim;
            }
            if (requestOidc_oidc_RequiredClaim != null)
            {
                request.Oidc.RequiredClaims = requestOidc_oidc_RequiredClaim;
                requestOidcIsNull = false;
            }
            System.String requestOidc_oidc_UsernameClaim = null;
            if (cmdletContext.Oidc_UsernameClaim != null)
            {
                requestOidc_oidc_UsernameClaim = cmdletContext.Oidc_UsernameClaim;
            }
            if (requestOidc_oidc_UsernameClaim != null)
            {
                request.Oidc.UsernameClaim = requestOidc_oidc_UsernameClaim;
                requestOidcIsNull = false;
            }
            System.String requestOidc_oidc_UsernamePrefix = null;
            if (cmdletContext.Oidc_UsernamePrefix != null)
            {
                requestOidc_oidc_UsernamePrefix = cmdletContext.Oidc_UsernamePrefix;
            }
            if (requestOidc_oidc_UsernamePrefix != null)
            {
                request.Oidc.UsernamePrefix = requestOidc_oidc_UsernamePrefix;
                requestOidcIsNull = false;
            }
             // determine if request.Oidc should be set to null
            if (requestOidcIsNull)
            {
                request.Oidc = null;
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
        
        private Amazon.EKS.Model.AssociateIdentityProviderConfigResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.AssociateIdentityProviderConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "AssociateIdentityProviderConfig");
            try
            {
                #if DESKTOP
                return client.AssociateIdentityProviderConfig(request);
                #elif CORECLR
                return client.AssociateIdentityProviderConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.String Oidc_ClientId { get; set; }
            public System.String Oidc_GroupsClaim { get; set; }
            public System.String Oidc_GroupsPrefix { get; set; }
            public System.String Oidc_IdentityProviderConfigName { get; set; }
            public System.String Oidc_IssuerUrl { get; set; }
            public Dictionary<System.String, System.String> Oidc_RequiredClaim { get; set; }
            public System.String Oidc_UsernameClaim { get; set; }
            public System.String Oidc_UsernamePrefix { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.EKS.Model.AssociateIdentityProviderConfigResponse, AddEKSIdentityProviderConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
