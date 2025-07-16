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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a new OAuth2 credential provider.
    /// </summary>
    [Cmdlet("New", "BACCOauth2CredentialProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateOauth2CredentialProvider API operation.", Operation = new[] {"CreateOauth2CredentialProvider"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse object containing multiple properties."
    )]
    public partial class NewBACCOauth2CredentialProviderCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthorizationServerMetadata_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The authorization endpoint URL for the OAuth2 authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_AuthorizationEndpoint")]
        public System.String AuthorizationServerMetadata_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter CustomOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the custom OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientId")]
        public System.String CustomOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter GithubOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the GitHub OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientId")]
        public System.String GithubOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter GoogleOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Google OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientId")]
        public System.String GoogleOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter MicrosoftOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Microsoft OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientId")]
        public System.String MicrosoftOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter SalesforceOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Salesforce OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientId")]
        public System.String SalesforceOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter SlackOauth2ProviderConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the Slack OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientId")]
        public System.String SlackOauth2ProviderConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter CustomOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the custom OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientSecret")]
        public System.String CustomOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter GithubOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the GitHub OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GithubOauth2ProviderConfig_ClientSecret")]
        public System.String GithubOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter GoogleOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Google OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_ClientSecret")]
        public System.String GoogleOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter MicrosoftOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Microsoft OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_ClientSecret")]
        public System.String MicrosoftOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter SalesforceOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Salesforce OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_ClientSecret")]
        public System.String SalesforceOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter SlackOauth2ProviderConfig_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the Slack OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_SlackOauth2ProviderConfig_ClientSecret")]
        public System.String SlackOauth2ProviderConfig_ClientSecret { get; set; }
        #endregion
        
        #region Parameter CredentialProviderVendor
        /// <summary>
        /// <para>
        /// <para>The vendor of the OAuth2 credential provider. This specifies which OAuth2 implementation
        /// to use.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.CredentialProviderVendorType")]
        public Amazon.BedrockAgentCoreControl.CredentialProviderVendorType CredentialProviderVendor { get; set; }
        #endregion
        
        #region Parameter OauthDiscovery_DiscoveryUrl
        /// <summary>
        /// <para>
        /// <para>The discovery URL for the OAuth2 provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_DiscoveryUrl")]
        public System.String OauthDiscovery_DiscoveryUrl { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer URL for the OAuth2 authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_Issuer")]
        public System.String AuthorizationServerMetadata_Issuer { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the OAuth2 credential provider. The name must be unique within your account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_ResponseType
        /// <summary>
        /// <para>
        /// <para>The supported response types for the OAuth2 authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_ResponseTypes")]
        public System.String[] AuthorizationServerMetadata_ResponseType { get; set; }
        #endregion
        
        #region Parameter AuthorizationServerMetadata_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>The token endpoint URL for the OAuth2 authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_TokenEndpoint")]
        public System.String AuthorizationServerMetadata_TokenEndpoint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCOauth2CredentialProvider (CreateOauth2CredentialProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse, NewBACCOauth2CredentialProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CredentialProviderVendor = this.CredentialProviderVendor;
            #if MODULAR
            if (this.CredentialProviderVendor == null && ParameterWasBound(nameof(this.CredentialProviderVendor)))
            {
                WriteWarning("You are passing $null as a value for parameter CredentialProviderVendor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomOauth2ProviderConfig_ClientId = this.CustomOauth2ProviderConfig_ClientId;
            context.CustomOauth2ProviderConfig_ClientSecret = this.CustomOauth2ProviderConfig_ClientSecret;
            context.AuthorizationServerMetadata_AuthorizationEndpoint = this.AuthorizationServerMetadata_AuthorizationEndpoint;
            context.AuthorizationServerMetadata_Issuer = this.AuthorizationServerMetadata_Issuer;
            if (this.AuthorizationServerMetadata_ResponseType != null)
            {
                context.AuthorizationServerMetadata_ResponseType = new List<System.String>(this.AuthorizationServerMetadata_ResponseType);
            }
            context.AuthorizationServerMetadata_TokenEndpoint = this.AuthorizationServerMetadata_TokenEndpoint;
            context.OauthDiscovery_DiscoveryUrl = this.OauthDiscovery_DiscoveryUrl;
            context.GithubOauth2ProviderConfig_ClientId = this.GithubOauth2ProviderConfig_ClientId;
            context.GithubOauth2ProviderConfig_ClientSecret = this.GithubOauth2ProviderConfig_ClientSecret;
            context.GoogleOauth2ProviderConfig_ClientId = this.GoogleOauth2ProviderConfig_ClientId;
            context.GoogleOauth2ProviderConfig_ClientSecret = this.GoogleOauth2ProviderConfig_ClientSecret;
            context.MicrosoftOauth2ProviderConfig_ClientId = this.MicrosoftOauth2ProviderConfig_ClientId;
            context.MicrosoftOauth2ProviderConfig_ClientSecret = this.MicrosoftOauth2ProviderConfig_ClientSecret;
            context.SalesforceOauth2ProviderConfig_ClientId = this.SalesforceOauth2ProviderConfig_ClientId;
            context.SalesforceOauth2ProviderConfig_ClientSecret = this.SalesforceOauth2ProviderConfig_ClientSecret;
            context.SlackOauth2ProviderConfig_ClientId = this.SlackOauth2ProviderConfig_ClientId;
            context.SlackOauth2ProviderConfig_ClientSecret = this.SlackOauth2ProviderConfig_ClientSecret;
            
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderRequest();
            
            if (cmdletContext.CredentialProviderVendor != null)
            {
                request.CredentialProviderVendor = cmdletContext.CredentialProviderVendor;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Oauth2ProviderConfigInput
            var requestOauth2ProviderConfigInputIsNull = true;
            request.Oauth2ProviderConfigInput = new Amazon.BedrockAgentCoreControl.Model.Oauth2ProviderConfigInput();
            Amazon.BedrockAgentCoreControl.Model.GithubOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig = null;
            
             // populate GithubOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.GithubOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.GithubOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId = cmdletContext.GithubOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.GithubOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret = cmdletContext.GithubOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig_githubOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.GithubOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GithubOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.GoogleOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig = null;
            
             // populate GoogleOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.GoogleOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.GoogleOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId = cmdletContext.GoogleOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.GoogleOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret = cmdletContext.GoogleOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig_googleOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.GoogleOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_GoogleOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.MicrosoftOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig = null;
            
             // populate MicrosoftOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.MicrosoftOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.MicrosoftOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId = cmdletContext.MicrosoftOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.MicrosoftOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret = cmdletContext.MicrosoftOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig_microsoftOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.MicrosoftOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_MicrosoftOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SalesforceOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig = null;
            
             // populate SalesforceOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.SalesforceOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.SalesforceOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId = cmdletContext.SalesforceOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.SalesforceOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret = cmdletContext.SalesforceOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig_salesforceOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.SalesforceOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SalesforceOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SlackOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig = null;
            
             // populate SlackOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.SlackOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.SlackOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId = cmdletContext.SlackOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.SlackOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret = cmdletContext.SlackOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig_slackOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.SlackOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_SlackOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.CustomOauth2ProviderConfigInput requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig = null;
            
             // populate CustomOauth2ProviderConfig
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig = new Amazon.BedrockAgentCoreControl.Model.CustomOauth2ProviderConfigInput();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId = null;
            if (cmdletContext.CustomOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId = cmdletContext.CustomOauth2ProviderConfig_ClientId;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.ClientId = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientId;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret = null;
            if (cmdletContext.CustomOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret = cmdletContext.CustomOauth2ProviderConfig_ClientSecret;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.ClientSecret = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_customOauth2ProviderConfig_ClientSecret;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.Oauth2Discovery requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery = null;
            
             // populate OauthDiscovery
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery = new Amazon.BedrockAgentCoreControl.Model.Oauth2Discovery();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl = null;
            if (cmdletContext.OauthDiscovery_DiscoveryUrl != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl = cmdletContext.OauthDiscovery_DiscoveryUrl;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery.DiscoveryUrl = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauthDiscovery_DiscoveryUrl;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.Oauth2AuthorizationServerMetadata requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata = null;
            
             // populate AuthorizationServerMetadata
            var requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = true;
            requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata = new Amazon.BedrockAgentCoreControl.Model.Oauth2AuthorizationServerMetadata();
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint = null;
            if (cmdletContext.AuthorizationServerMetadata_AuthorizationEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint = cmdletContext.AuthorizationServerMetadata_AuthorizationEndpoint;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.AuthorizationEndpoint = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_AuthorizationEndpoint;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer = null;
            if (cmdletContext.AuthorizationServerMetadata_Issuer != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer = cmdletContext.AuthorizationServerMetadata_Issuer;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.Issuer = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_Issuer;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
            List<System.String> requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType = null;
            if (cmdletContext.AuthorizationServerMetadata_ResponseType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType = cmdletContext.AuthorizationServerMetadata_ResponseType;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.ResponseTypes = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_ResponseType;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
            System.String requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint = null;
            if (cmdletContext.AuthorizationServerMetadata_TokenEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint = cmdletContext.AuthorizationServerMetadata_TokenEndpoint;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata.TokenEndpoint = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata_authorizationServerMetadata_TokenEndpoint;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadataIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery.AuthorizationServerMetadata = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery_AuthorizationServerMetadata;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscoveryIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery != null)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig.OauthDiscovery = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OauthDiscovery;
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull = false;
            }
             // determine if requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig should be set to null
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfigIsNull)
            {
                requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig = null;
            }
            if (requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig != null)
            {
                request.Oauth2ProviderConfigInput.CustomOauth2ProviderConfig = requestOauth2ProviderConfigInput_oauth2ProviderConfigInput_CustomOauth2ProviderConfig;
                requestOauth2ProviderConfigInputIsNull = false;
            }
             // determine if request.Oauth2ProviderConfigInput should be set to null
            if (requestOauth2ProviderConfigInputIsNull)
            {
                request.Oauth2ProviderConfigInput = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateOauth2CredentialProvider");
            try
            {
                #if DESKTOP
                return client.CreateOauth2CredentialProvider(request);
                #elif CORECLR
                return client.CreateOauth2CredentialProviderAsync(request).GetAwaiter().GetResult();
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
            public Amazon.BedrockAgentCoreControl.CredentialProviderVendorType CredentialProviderVendor { get; set; }
            public System.String Name { get; set; }
            public System.String CustomOauth2ProviderConfig_ClientId { get; set; }
            public System.String CustomOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String AuthorizationServerMetadata_AuthorizationEndpoint { get; set; }
            public System.String AuthorizationServerMetadata_Issuer { get; set; }
            public List<System.String> AuthorizationServerMetadata_ResponseType { get; set; }
            public System.String AuthorizationServerMetadata_TokenEndpoint { get; set; }
            public System.String OauthDiscovery_DiscoveryUrl { get; set; }
            public System.String GithubOauth2ProviderConfig_ClientId { get; set; }
            public System.String GithubOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String GoogleOauth2ProviderConfig_ClientId { get; set; }
            public System.String GoogleOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String MicrosoftOauth2ProviderConfig_ClientId { get; set; }
            public System.String MicrosoftOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String SalesforceOauth2ProviderConfig_ClientId { get; set; }
            public System.String SalesforceOauth2ProviderConfig_ClientSecret { get; set; }
            public System.String SlackOauth2ProviderConfig_ClientId { get; set; }
            public System.String SlackOauth2ProviderConfig_ClientSecret { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateOauth2CredentialProviderResponse, NewBACCOauth2CredentialProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
