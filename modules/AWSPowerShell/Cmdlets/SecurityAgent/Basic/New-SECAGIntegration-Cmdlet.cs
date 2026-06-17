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
using System.Threading;
using Amazon.SecurityAgent;
using Amazon.SecurityAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SECAG
{
    /// <summary>
    /// Creates a new integration with a third-party provider, such as GitHub, for code review
    /// and remediation.
    /// </summary>
    [Cmdlet("New", "SECAGIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Security Agent CreateIntegration API operation.", Operation = new[] {"CreateIntegration"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.CreateIntegrationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SecurityAgent.Model.CreateIntegrationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SecurityAgent.Model.CreateIntegrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSECAGIntegrationCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Input_Gitlab_AccessToken
        /// <summary>
        /// <para>
        /// <para>The GitLab access token used to authenticate. This can be a personal access token
        /// or a group access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Gitlab_AccessToken { get; set; }
        #endregion
        
        #region Parameter Input_Bitbucket_Code
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 authorization code returned from the consent redirect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Bitbucket_Code { get; set; }
        #endregion
        
        #region Parameter Input_Confluence_Code
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 authorization code returned from the consent redirect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Confluence_Code { get; set; }
        #endregion
        
        #region Parameter Input_Github_Code
        /// <summary>
        /// <para>
        /// <para>The OAuth authorization code received from GitHub.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_Code { get; set; }
        #endregion
        
        #region Parameter Input_Gitlab_GroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the GitLab group. Required when tokenType is group and ignored for
        /// personal tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Gitlab_GroupId { get; set; }
        #endregion
        
        #region Parameter Input_Bitbucket_InstallationId
        /// <summary>
        /// <para>
        /// <para>The Atlassian installation identifier, available from the Atlassian administration
        /// console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Bitbucket_InstallationId { get; set; }
        #endregion
        
        #region Parameter Input_Confluence_InstallationId
        /// <summary>
        /// <para>
        /// <para>The Atlassian installation identifier, available from the Atlassian administration
        /// console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Confluence_InstallationId { get; set; }
        #endregion
        
        #region Parameter Input_Github_InstallationId
        /// <summary>
        /// <para>
        /// <para>The installation identifier provided by GitHub Enterprise Server on the install callback.
        /// Required for GitHub Enterprise Server integrations and ignored for GitHub.com.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_InstallationId { get; set; }
        #endregion
        
        #region Parameter IntegrationDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name for the integration.</para>
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
        public System.String IntegrationDisplayName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AWS KMS key to use for encrypting data associated with the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Input_Github_OrganizationName
        /// <summary>
        /// <para>
        /// <para>The name of the GitHub organization to integrate with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_OrganizationName { get; set; }
        #endregion
        
        #region Parameter PrivateConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of an active private connection used to reach a self-hosted provider instance
        /// over private networking. Specify this when the instance is not publicly reachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateConnectionName { get; set; }
        #endregion
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The integration provider. Currently, only GITHUB is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SecurityAgent.Provider")]
        public Amazon.SecurityAgent.Provider Provider { get; set; }
        #endregion
        
        #region Parameter Input_Confluence_SiteUrl
        /// <summary>
        /// <para>
        /// <para>The Confluence Cloud site URL, for example https://mysite.atlassian.net.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Confluence_SiteUrl { get; set; }
        #endregion
        
        #region Parameter Input_Bitbucket_State
        /// <summary>
        /// <para>
        /// <para>The CSRF state token echoed back from the OAuth redirect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Bitbucket_State { get; set; }
        #endregion
        
        #region Parameter Input_Confluence_State
        /// <summary>
        /// <para>
        /// <para>The CSRF state token echoed back from the OAuth redirect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Confluence_State { get; set; }
        #endregion
        
        #region Parameter Input_Github_State
        /// <summary>
        /// <para>
        /// <para>The CSRF state token for validating the OAuth flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the integration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Input_Github_TargetUrl
        /// <summary>
        /// <para>
        /// <para>The HTTPS URL of a self-hosted GitHub Enterprise Server instance. Omit this value
        /// for GitHub.com.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Github_TargetUrl { get; set; }
        #endregion
        
        #region Parameter Input_Gitlab_TargetUrl
        /// <summary>
        /// <para>
        /// <para>The HTTPS URL of a self-managed GitLab instance. Omit this value for GitLab SaaS (gitlab.com).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Gitlab_TargetUrl { get; set; }
        #endregion
        
        #region Parameter Input_Gitlab_TokenType
        /// <summary>
        /// <para>
        /// <para>The type of GitLab access token provided in accessToken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityAgent.GitLabTokenType")]
        public Amazon.SecurityAgent.GitLabTokenType Input_Gitlab_TokenType { get; set; }
        #endregion
        
        #region Parameter Input_Bitbucket_Workspace
        /// <summary>
        /// <para>
        /// <para>The Bitbucket workspace slug that identifies the workspace to integrate, for example
        /// acme-corp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Input_Bitbucket_Workspace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IntegrationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.CreateIntegrationResponse).
        /// Specifying the name of a property of type Amazon.SecurityAgent.Model.CreateIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IntegrationId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationDisplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SECAGIntegration (CreateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.CreateIntegrationResponse, NewSECAGIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Input_Bitbucket_Code = this.Input_Bitbucket_Code;
            context.Input_Bitbucket_InstallationId = this.Input_Bitbucket_InstallationId;
            context.Input_Bitbucket_State = this.Input_Bitbucket_State;
            context.Input_Bitbucket_Workspace = this.Input_Bitbucket_Workspace;
            context.Input_Confluence_Code = this.Input_Confluence_Code;
            context.Input_Confluence_InstallationId = this.Input_Confluence_InstallationId;
            context.Input_Confluence_SiteUrl = this.Input_Confluence_SiteUrl;
            context.Input_Confluence_State = this.Input_Confluence_State;
            context.Input_Github_Code = this.Input_Github_Code;
            context.Input_Github_InstallationId = this.Input_Github_InstallationId;
            context.Input_Github_OrganizationName = this.Input_Github_OrganizationName;
            context.Input_Github_State = this.Input_Github_State;
            context.Input_Github_TargetUrl = this.Input_Github_TargetUrl;
            context.Input_Gitlab_AccessToken = this.Input_Gitlab_AccessToken;
            context.Input_Gitlab_GroupId = this.Input_Gitlab_GroupId;
            context.Input_Gitlab_TargetUrl = this.Input_Gitlab_TargetUrl;
            context.Input_Gitlab_TokenType = this.Input_Gitlab_TokenType;
            context.IntegrationDisplayName = this.IntegrationDisplayName;
            #if MODULAR
            if (this.IntegrationDisplayName == null && ParameterWasBound(nameof(this.IntegrationDisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationDisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.PrivateConnectionName = this.PrivateConnectionName;
            context.Provider = this.Provider;
            #if MODULAR
            if (this.Provider == null && ParameterWasBound(nameof(this.Provider)))
            {
                WriteWarning("You are passing $null as a value for parameter Provider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.SecurityAgent.Model.CreateIntegrationRequest();
            
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.SecurityAgent.Model.ProviderInput();
            Amazon.SecurityAgent.Model.BitbucketIntegrationInput requestInput_input_Bitbucket = null;
            
             // populate Bitbucket
            var requestInput_input_BitbucketIsNull = true;
            requestInput_input_Bitbucket = new Amazon.SecurityAgent.Model.BitbucketIntegrationInput();
            System.String requestInput_input_Bitbucket_input_Bitbucket_Code = null;
            if (cmdletContext.Input_Bitbucket_Code != null)
            {
                requestInput_input_Bitbucket_input_Bitbucket_Code = cmdletContext.Input_Bitbucket_Code;
            }
            if (requestInput_input_Bitbucket_input_Bitbucket_Code != null)
            {
                requestInput_input_Bitbucket.Code = requestInput_input_Bitbucket_input_Bitbucket_Code;
                requestInput_input_BitbucketIsNull = false;
            }
            System.String requestInput_input_Bitbucket_input_Bitbucket_InstallationId = null;
            if (cmdletContext.Input_Bitbucket_InstallationId != null)
            {
                requestInput_input_Bitbucket_input_Bitbucket_InstallationId = cmdletContext.Input_Bitbucket_InstallationId;
            }
            if (requestInput_input_Bitbucket_input_Bitbucket_InstallationId != null)
            {
                requestInput_input_Bitbucket.InstallationId = requestInput_input_Bitbucket_input_Bitbucket_InstallationId;
                requestInput_input_BitbucketIsNull = false;
            }
            System.String requestInput_input_Bitbucket_input_Bitbucket_State = null;
            if (cmdletContext.Input_Bitbucket_State != null)
            {
                requestInput_input_Bitbucket_input_Bitbucket_State = cmdletContext.Input_Bitbucket_State;
            }
            if (requestInput_input_Bitbucket_input_Bitbucket_State != null)
            {
                requestInput_input_Bitbucket.State = requestInput_input_Bitbucket_input_Bitbucket_State;
                requestInput_input_BitbucketIsNull = false;
            }
            System.String requestInput_input_Bitbucket_input_Bitbucket_Workspace = null;
            if (cmdletContext.Input_Bitbucket_Workspace != null)
            {
                requestInput_input_Bitbucket_input_Bitbucket_Workspace = cmdletContext.Input_Bitbucket_Workspace;
            }
            if (requestInput_input_Bitbucket_input_Bitbucket_Workspace != null)
            {
                requestInput_input_Bitbucket.Workspace = requestInput_input_Bitbucket_input_Bitbucket_Workspace;
                requestInput_input_BitbucketIsNull = false;
            }
             // determine if requestInput_input_Bitbucket should be set to null
            if (requestInput_input_BitbucketIsNull)
            {
                requestInput_input_Bitbucket = null;
            }
            if (requestInput_input_Bitbucket != null)
            {
                request.Input.Bitbucket = requestInput_input_Bitbucket;
                requestInputIsNull = false;
            }
            Amazon.SecurityAgent.Model.ConfluenceIntegrationInput requestInput_input_Confluence = null;
            
             // populate Confluence
            var requestInput_input_ConfluenceIsNull = true;
            requestInput_input_Confluence = new Amazon.SecurityAgent.Model.ConfluenceIntegrationInput();
            System.String requestInput_input_Confluence_input_Confluence_Code = null;
            if (cmdletContext.Input_Confluence_Code != null)
            {
                requestInput_input_Confluence_input_Confluence_Code = cmdletContext.Input_Confluence_Code;
            }
            if (requestInput_input_Confluence_input_Confluence_Code != null)
            {
                requestInput_input_Confluence.Code = requestInput_input_Confluence_input_Confluence_Code;
                requestInput_input_ConfluenceIsNull = false;
            }
            System.String requestInput_input_Confluence_input_Confluence_InstallationId = null;
            if (cmdletContext.Input_Confluence_InstallationId != null)
            {
                requestInput_input_Confluence_input_Confluence_InstallationId = cmdletContext.Input_Confluence_InstallationId;
            }
            if (requestInput_input_Confluence_input_Confluence_InstallationId != null)
            {
                requestInput_input_Confluence.InstallationId = requestInput_input_Confluence_input_Confluence_InstallationId;
                requestInput_input_ConfluenceIsNull = false;
            }
            System.String requestInput_input_Confluence_input_Confluence_SiteUrl = null;
            if (cmdletContext.Input_Confluence_SiteUrl != null)
            {
                requestInput_input_Confluence_input_Confluence_SiteUrl = cmdletContext.Input_Confluence_SiteUrl;
            }
            if (requestInput_input_Confluence_input_Confluence_SiteUrl != null)
            {
                requestInput_input_Confluence.SiteUrl = requestInput_input_Confluence_input_Confluence_SiteUrl;
                requestInput_input_ConfluenceIsNull = false;
            }
            System.String requestInput_input_Confluence_input_Confluence_State = null;
            if (cmdletContext.Input_Confluence_State != null)
            {
                requestInput_input_Confluence_input_Confluence_State = cmdletContext.Input_Confluence_State;
            }
            if (requestInput_input_Confluence_input_Confluence_State != null)
            {
                requestInput_input_Confluence.State = requestInput_input_Confluence_input_Confluence_State;
                requestInput_input_ConfluenceIsNull = false;
            }
             // determine if requestInput_input_Confluence should be set to null
            if (requestInput_input_ConfluenceIsNull)
            {
                requestInput_input_Confluence = null;
            }
            if (requestInput_input_Confluence != null)
            {
                request.Input.Confluence = requestInput_input_Confluence;
                requestInputIsNull = false;
            }
            Amazon.SecurityAgent.Model.GitLabIntegrationInput requestInput_input_Gitlab = null;
            
             // populate Gitlab
            var requestInput_input_GitlabIsNull = true;
            requestInput_input_Gitlab = new Amazon.SecurityAgent.Model.GitLabIntegrationInput();
            System.String requestInput_input_Gitlab_input_Gitlab_AccessToken = null;
            if (cmdletContext.Input_Gitlab_AccessToken != null)
            {
                requestInput_input_Gitlab_input_Gitlab_AccessToken = cmdletContext.Input_Gitlab_AccessToken;
            }
            if (requestInput_input_Gitlab_input_Gitlab_AccessToken != null)
            {
                requestInput_input_Gitlab.AccessToken = requestInput_input_Gitlab_input_Gitlab_AccessToken;
                requestInput_input_GitlabIsNull = false;
            }
            System.String requestInput_input_Gitlab_input_Gitlab_GroupId = null;
            if (cmdletContext.Input_Gitlab_GroupId != null)
            {
                requestInput_input_Gitlab_input_Gitlab_GroupId = cmdletContext.Input_Gitlab_GroupId;
            }
            if (requestInput_input_Gitlab_input_Gitlab_GroupId != null)
            {
                requestInput_input_Gitlab.GroupId = requestInput_input_Gitlab_input_Gitlab_GroupId;
                requestInput_input_GitlabIsNull = false;
            }
            System.String requestInput_input_Gitlab_input_Gitlab_TargetUrl = null;
            if (cmdletContext.Input_Gitlab_TargetUrl != null)
            {
                requestInput_input_Gitlab_input_Gitlab_TargetUrl = cmdletContext.Input_Gitlab_TargetUrl;
            }
            if (requestInput_input_Gitlab_input_Gitlab_TargetUrl != null)
            {
                requestInput_input_Gitlab.TargetUrl = requestInput_input_Gitlab_input_Gitlab_TargetUrl;
                requestInput_input_GitlabIsNull = false;
            }
            Amazon.SecurityAgent.GitLabTokenType requestInput_input_Gitlab_input_Gitlab_TokenType = null;
            if (cmdletContext.Input_Gitlab_TokenType != null)
            {
                requestInput_input_Gitlab_input_Gitlab_TokenType = cmdletContext.Input_Gitlab_TokenType;
            }
            if (requestInput_input_Gitlab_input_Gitlab_TokenType != null)
            {
                requestInput_input_Gitlab.TokenType = requestInput_input_Gitlab_input_Gitlab_TokenType;
                requestInput_input_GitlabIsNull = false;
            }
             // determine if requestInput_input_Gitlab should be set to null
            if (requestInput_input_GitlabIsNull)
            {
                requestInput_input_Gitlab = null;
            }
            if (requestInput_input_Gitlab != null)
            {
                request.Input.Gitlab = requestInput_input_Gitlab;
                requestInputIsNull = false;
            }
            Amazon.SecurityAgent.Model.GitHubIntegrationInput requestInput_input_Github = null;
            
             // populate Github
            var requestInput_input_GithubIsNull = true;
            requestInput_input_Github = new Amazon.SecurityAgent.Model.GitHubIntegrationInput();
            System.String requestInput_input_Github_input_Github_Code = null;
            if (cmdletContext.Input_Github_Code != null)
            {
                requestInput_input_Github_input_Github_Code = cmdletContext.Input_Github_Code;
            }
            if (requestInput_input_Github_input_Github_Code != null)
            {
                requestInput_input_Github.Code = requestInput_input_Github_input_Github_Code;
                requestInput_input_GithubIsNull = false;
            }
            System.String requestInput_input_Github_input_Github_InstallationId = null;
            if (cmdletContext.Input_Github_InstallationId != null)
            {
                requestInput_input_Github_input_Github_InstallationId = cmdletContext.Input_Github_InstallationId;
            }
            if (requestInput_input_Github_input_Github_InstallationId != null)
            {
                requestInput_input_Github.InstallationId = requestInput_input_Github_input_Github_InstallationId;
                requestInput_input_GithubIsNull = false;
            }
            System.String requestInput_input_Github_input_Github_OrganizationName = null;
            if (cmdletContext.Input_Github_OrganizationName != null)
            {
                requestInput_input_Github_input_Github_OrganizationName = cmdletContext.Input_Github_OrganizationName;
            }
            if (requestInput_input_Github_input_Github_OrganizationName != null)
            {
                requestInput_input_Github.OrganizationName = requestInput_input_Github_input_Github_OrganizationName;
                requestInput_input_GithubIsNull = false;
            }
            System.String requestInput_input_Github_input_Github_State = null;
            if (cmdletContext.Input_Github_State != null)
            {
                requestInput_input_Github_input_Github_State = cmdletContext.Input_Github_State;
            }
            if (requestInput_input_Github_input_Github_State != null)
            {
                requestInput_input_Github.State = requestInput_input_Github_input_Github_State;
                requestInput_input_GithubIsNull = false;
            }
            System.String requestInput_input_Github_input_Github_TargetUrl = null;
            if (cmdletContext.Input_Github_TargetUrl != null)
            {
                requestInput_input_Github_input_Github_TargetUrl = cmdletContext.Input_Github_TargetUrl;
            }
            if (requestInput_input_Github_input_Github_TargetUrl != null)
            {
                requestInput_input_Github.TargetUrl = requestInput_input_Github_input_Github_TargetUrl;
                requestInput_input_GithubIsNull = false;
            }
             // determine if requestInput_input_Github should be set to null
            if (requestInput_input_GithubIsNull)
            {
                requestInput_input_Github = null;
            }
            if (requestInput_input_Github != null)
            {
                request.Input.Github = requestInput_input_Github;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.IntegrationDisplayName != null)
            {
                request.IntegrationDisplayName = cmdletContext.IntegrationDisplayName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.PrivateConnectionName != null)
            {
                request.PrivateConnectionName = cmdletContext.PrivateConnectionName;
            }
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
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
        
        private Amazon.SecurityAgent.Model.CreateIntegrationResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.CreateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "CreateIntegration");
            try
            {
                return client.CreateIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Input_Bitbucket_Code { get; set; }
            public System.String Input_Bitbucket_InstallationId { get; set; }
            public System.String Input_Bitbucket_State { get; set; }
            public System.String Input_Bitbucket_Workspace { get; set; }
            public System.String Input_Confluence_Code { get; set; }
            public System.String Input_Confluence_InstallationId { get; set; }
            public System.String Input_Confluence_SiteUrl { get; set; }
            public System.String Input_Confluence_State { get; set; }
            public System.String Input_Github_Code { get; set; }
            public System.String Input_Github_InstallationId { get; set; }
            public System.String Input_Github_OrganizationName { get; set; }
            public System.String Input_Github_State { get; set; }
            public System.String Input_Github_TargetUrl { get; set; }
            public System.String Input_Gitlab_AccessToken { get; set; }
            public System.String Input_Gitlab_GroupId { get; set; }
            public System.String Input_Gitlab_TargetUrl { get; set; }
            public Amazon.SecurityAgent.GitLabTokenType Input_Gitlab_TokenType { get; set; }
            public System.String IntegrationDisplayName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PrivateConnectionName { get; set; }
            public Amazon.SecurityAgent.Provider Provider { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.CreateIntegrationResponse, NewSECAGIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IntegrationId;
        }
        
    }
}
