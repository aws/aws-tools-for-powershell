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
using Amazon.Continuum;
using Amazon.Continuum.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONT
{
    /// <summary>
    /// Creates a new integration with an external source provider. Repeating an identical
    /// request with the same clientToken returns the original integrationId, integrationArn,
    /// and createdAt. Token records are retained for eight hours after success or terminal
    /// failure, including after the integration is deleted; replaying a deleted integration's
    /// token does not recreate it. An identical request with a retained terminal failure
    /// returns the recorded error. Reusing a token with different parameters returns ValidationException.
    /// A fresh token starts a new create attempt; if the name is already owned by another
    /// integration, ConflictException includes that integration's identifier. An attempt
    /// still in progress may return ThrottlingException with retryAfterSeconds set to 1;
    /// retry with the same token and identical parameters. GitHub authorization codes are
    /// single use. Retry an unresolved attempt with its original token and unchanged parameters
    /// first. If the service reports a terminal failure, an expired attempt, or a successful
    /// token exchange whose integration could not be saved, restart GitHub authorization
    /// with a fresh token and authorization code. The service does not checkpoint provider
    /// results for recovery by another request.
    /// </summary>
    [Cmdlet("New", "CONTIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.CreateIntegrationResponse")]
    [AWSCmdlet("Calls the AWS Continuum CreateIntegration API operation.", Operation = new[] {"CreateIntegration"}, SelectReturnType = typeof(Amazon.Continuum.Model.CreateIntegrationResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.CreateIntegrationResponse",
        "This cmdlet returns an Amazon.Continuum.Model.CreateIntegrationResponse object containing multiple properties."
    )]
    public partial class NewCONTIntegrationCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProviderConfiguration_Gitlab_AccessToken
        /// <summary>
        /// <para>
        /// The GitLab access token (personal, group or
        /// project). Write-only; not stored or returned after creation. If the token carries
        /// the self-rotate scope, rotation is opted in and Continuum manages the token thereafter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_Gitlab_AccessToken { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_Github_Authorization_AuthorizationCode
        /// <summary>
        /// <para>
        /// The OAuth authorization code returned
        /// by GitHub after the user authorizes the application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_Github_Authorization_AuthorizationCode { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_S3_Bucket
        /// <summary>
        /// <para>
        /// Customer-managed source bucket name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_S3_Bucket { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_S3_ExternalId
        /// <summary>
        /// <para>
        /// Caller-provided external ID required by the
        /// role trust policy.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_S3_ExternalId { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_Gitlab_InstanceUrl
        /// <summary>
        /// <para>
        /// The HTTPS base URL of the GitLab instance
        /// (gitlab.com or self-managed).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_Gitlab_InstanceUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name for the integration.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_Github_OrganizationName
        /// <summary>
        /// <para>
        /// The name of the GitHub organization to
        /// associate with the integration. If not specified, the integration is associated with
        /// the authenticated user's personal account.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_Github_OrganizationName { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_Github_Authorization_RedirectUrl
        /// <summary>
        /// <para>
        /// The redirect URL used to obtain the authorization
        /// code. Must match one of the redirect URLs registered on the GitHub App. If omitted,
        /// the App's default redirect URL is used. Not stored or returned after creation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_Github_Authorization_RedirectUrl { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_S3_RoleArn
        /// <summary>
        /// <para>
        /// Role Continuum will assume to read from the source
        /// bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_S3_RoleArn { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_Github_Authorization_State
        /// <summary>
        /// <para>
        /// The `state` returned by GitHub in the OAuth callback.
        /// It must be the state that StartIntegrationAuthorization returned to the same AWS account,
        /// and the authorization request must have sent that call's codeChallenge. The state
        /// can be redeemed once. A stage that enforces authorization sessions rejects a missing,
        /// expired, already used, or other-account state with ValidationException; restart the
        /// authorization with StartIntegrationAuthorization.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_Github_Authorization_State { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_Gitlab_TargetPath
        /// <summary>
        /// <para>
        /// The group or project path the integration targets.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfiguration_Gitlab_TargetPath { get; set; }
        #endregion
        
        #region Parameter ProviderConfiguration_Gitlab_TargetType
        /// <summary>
        /// <para>
        /// Whether the integration targets a group or
        /// a single project.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Continuum.GitLabTargetType")]
        public Amazon.Continuum.GitLabTargetType ProviderConfiguration_Gitlab_TargetType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// An optional token identifying one create attempt
        /// within the caller's account, Region, and operation. SDKs generate a token when omitted.
        /// If a request reaches the service without a token, the service generates one for that
        /// request. Each request without a token starts a new attempt. To replay an attempt,
        /// supply the same token and identical input. Authorized users and roles in the same
        /// account can retry an attempt this way. Token records are retained for eight hours
        /// after success or terminal failure, including after deletion of a successfully created
        /// integration. Different input with the same token returns ValidationException.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.CreateIntegrationResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.CreateIntegrationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONTIntegration (CreateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.CreateIntegrationResponse, NewCONTIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderConfiguration_Github_Authorization_AuthorizationCode = this.ProviderConfiguration_Github_Authorization_AuthorizationCode;
            context.ProviderConfiguration_Github_Authorization_RedirectUrl = this.ProviderConfiguration_Github_Authorization_RedirectUrl;
            context.ProviderConfiguration_Github_Authorization_State = this.ProviderConfiguration_Github_Authorization_State;
            context.ProviderConfiguration_Github_OrganizationName = this.ProviderConfiguration_Github_OrganizationName;
            context.ProviderConfiguration_Gitlab_AccessToken = this.ProviderConfiguration_Gitlab_AccessToken;
            context.ProviderConfiguration_Gitlab_InstanceUrl = this.ProviderConfiguration_Gitlab_InstanceUrl;
            context.ProviderConfiguration_Gitlab_TargetPath = this.ProviderConfiguration_Gitlab_TargetPath;
            context.ProviderConfiguration_Gitlab_TargetType = this.ProviderConfiguration_Gitlab_TargetType;
            context.ProviderConfiguration_S3_Bucket = this.ProviderConfiguration_S3_Bucket;
            context.ProviderConfiguration_S3_ExternalId = this.ProviderConfiguration_S3_ExternalId;
            context.ProviderConfiguration_S3_RoleArn = this.ProviderConfiguration_S3_RoleArn;
            
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
            var request = new Amazon.Continuum.Model.CreateIntegrationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ProviderConfiguration
            var requestProviderConfigurationIsNull = true;
            request.ProviderConfiguration = new Amazon.Continuum.Model.ProviderConfiguration();
            Amazon.Continuum.Model.GitHubConfiguration requestProviderConfiguration_providerConfiguration_Github = null;
            
             // populate Github
            var requestProviderConfiguration_providerConfiguration_GithubIsNull = true;
            requestProviderConfiguration_providerConfiguration_Github = new Amazon.Continuum.Model.GitHubConfiguration();
            System.String requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_OrganizationName = null;
            if (cmdletContext.ProviderConfiguration_Github_OrganizationName != null)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_OrganizationName = cmdletContext.ProviderConfiguration_Github_OrganizationName;
            }
            if (requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_OrganizationName != null)
            {
                requestProviderConfiguration_providerConfiguration_Github.OrganizationName = requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_OrganizationName;
                requestProviderConfiguration_providerConfiguration_GithubIsNull = false;
            }
            Amazon.Continuum.Model.GitHubAuthorizationConfiguration requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization = null;
            
             // populate Authorization
            var requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_AuthorizationIsNull = true;
            requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization = new Amazon.Continuum.Model.GitHubAuthorizationConfiguration();
            System.String requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_AuthorizationCode = null;
            if (cmdletContext.ProviderConfiguration_Github_Authorization_AuthorizationCode != null)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_AuthorizationCode = cmdletContext.ProviderConfiguration_Github_Authorization_AuthorizationCode;
            }
            if (requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_AuthorizationCode != null)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization.AuthorizationCode = requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_AuthorizationCode;
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_AuthorizationIsNull = false;
            }
            System.String requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_RedirectUrl = null;
            if (cmdletContext.ProviderConfiguration_Github_Authorization_RedirectUrl != null)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_RedirectUrl = cmdletContext.ProviderConfiguration_Github_Authorization_RedirectUrl;
            }
            if (requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_RedirectUrl != null)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization.RedirectUrl = requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_RedirectUrl;
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_AuthorizationIsNull = false;
            }
            System.String requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_State = null;
            if (cmdletContext.ProviderConfiguration_Github_Authorization_State != null)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_State = cmdletContext.ProviderConfiguration_Github_Authorization_State;
            }
            if (requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_State != null)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization.State = requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization_providerConfiguration_Github_Authorization_State;
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_AuthorizationIsNull = false;
            }
             // determine if requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization should be set to null
            if (requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_AuthorizationIsNull)
            {
                requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization = null;
            }
            if (requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization != null)
            {
                requestProviderConfiguration_providerConfiguration_Github.Authorization = requestProviderConfiguration_providerConfiguration_Github_providerConfiguration_Github_Authorization;
                requestProviderConfiguration_providerConfiguration_GithubIsNull = false;
            }
             // determine if requestProviderConfiguration_providerConfiguration_Github should be set to null
            if (requestProviderConfiguration_providerConfiguration_GithubIsNull)
            {
                requestProviderConfiguration_providerConfiguration_Github = null;
            }
            if (requestProviderConfiguration_providerConfiguration_Github != null)
            {
                request.ProviderConfiguration.Github = requestProviderConfiguration_providerConfiguration_Github;
                requestProviderConfigurationIsNull = false;
            }
            Amazon.Continuum.Model.S3Configuration requestProviderConfiguration_providerConfiguration_S3 = null;
            
             // populate S3
            var requestProviderConfiguration_providerConfiguration_S3IsNull = true;
            requestProviderConfiguration_providerConfiguration_S3 = new Amazon.Continuum.Model.S3Configuration();
            System.String requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_Bucket = null;
            if (cmdletContext.ProviderConfiguration_S3_Bucket != null)
            {
                requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_Bucket = cmdletContext.ProviderConfiguration_S3_Bucket;
            }
            if (requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_Bucket != null)
            {
                requestProviderConfiguration_providerConfiguration_S3.Bucket = requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_Bucket;
                requestProviderConfiguration_providerConfiguration_S3IsNull = false;
            }
            System.String requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId = null;
            if (cmdletContext.ProviderConfiguration_S3_ExternalId != null)
            {
                requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId = cmdletContext.ProviderConfiguration_S3_ExternalId;
            }
            if (requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId != null)
            {
                requestProviderConfiguration_providerConfiguration_S3.ExternalId = requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_ExternalId;
                requestProviderConfiguration_providerConfiguration_S3IsNull = false;
            }
            System.String requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn = null;
            if (cmdletContext.ProviderConfiguration_S3_RoleArn != null)
            {
                requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn = cmdletContext.ProviderConfiguration_S3_RoleArn;
            }
            if (requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn != null)
            {
                requestProviderConfiguration_providerConfiguration_S3.RoleArn = requestProviderConfiguration_providerConfiguration_S3_providerConfiguration_S3_RoleArn;
                requestProviderConfiguration_providerConfiguration_S3IsNull = false;
            }
             // determine if requestProviderConfiguration_providerConfiguration_S3 should be set to null
            if (requestProviderConfiguration_providerConfiguration_S3IsNull)
            {
                requestProviderConfiguration_providerConfiguration_S3 = null;
            }
            if (requestProviderConfiguration_providerConfiguration_S3 != null)
            {
                request.ProviderConfiguration.S3 = requestProviderConfiguration_providerConfiguration_S3;
                requestProviderConfigurationIsNull = false;
            }
            Amazon.Continuum.Model.GitLabConfiguration requestProviderConfiguration_providerConfiguration_Gitlab = null;
            
             // populate Gitlab
            var requestProviderConfiguration_providerConfiguration_GitlabIsNull = true;
            requestProviderConfiguration_providerConfiguration_Gitlab = new Amazon.Continuum.Model.GitLabConfiguration();
            System.String requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_AccessToken = null;
            if (cmdletContext.ProviderConfiguration_Gitlab_AccessToken != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_AccessToken = cmdletContext.ProviderConfiguration_Gitlab_AccessToken;
            }
            if (requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_AccessToken != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab.AccessToken = requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_AccessToken;
                requestProviderConfiguration_providerConfiguration_GitlabIsNull = false;
            }
            System.String requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_InstanceUrl = null;
            if (cmdletContext.ProviderConfiguration_Gitlab_InstanceUrl != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_InstanceUrl = cmdletContext.ProviderConfiguration_Gitlab_InstanceUrl;
            }
            if (requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_InstanceUrl != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab.InstanceUrl = requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_InstanceUrl;
                requestProviderConfiguration_providerConfiguration_GitlabIsNull = false;
            }
            System.String requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetPath = null;
            if (cmdletContext.ProviderConfiguration_Gitlab_TargetPath != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetPath = cmdletContext.ProviderConfiguration_Gitlab_TargetPath;
            }
            if (requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetPath != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab.TargetPath = requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetPath;
                requestProviderConfiguration_providerConfiguration_GitlabIsNull = false;
            }
            Amazon.Continuum.GitLabTargetType requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetType = null;
            if (cmdletContext.ProviderConfiguration_Gitlab_TargetType != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetType = cmdletContext.ProviderConfiguration_Gitlab_TargetType;
            }
            if (requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetType != null)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab.TargetType = requestProviderConfiguration_providerConfiguration_Gitlab_providerConfiguration_Gitlab_TargetType;
                requestProviderConfiguration_providerConfiguration_GitlabIsNull = false;
            }
             // determine if requestProviderConfiguration_providerConfiguration_Gitlab should be set to null
            if (requestProviderConfiguration_providerConfiguration_GitlabIsNull)
            {
                requestProviderConfiguration_providerConfiguration_Gitlab = null;
            }
            if (requestProviderConfiguration_providerConfiguration_Gitlab != null)
            {
                request.ProviderConfiguration.Gitlab = requestProviderConfiguration_providerConfiguration_Gitlab;
                requestProviderConfigurationIsNull = false;
            }
             // determine if request.ProviderConfiguration should be set to null
            if (requestProviderConfigurationIsNull)
            {
                request.ProviderConfiguration = null;
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
        
        private Amazon.Continuum.Model.CreateIntegrationResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.CreateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "CreateIntegration");
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
            public System.String ClientToken { get; set; }
            public System.String Name { get; set; }
            public System.String ProviderConfiguration_Github_Authorization_AuthorizationCode { get; set; }
            public System.String ProviderConfiguration_Github_Authorization_RedirectUrl { get; set; }
            public System.String ProviderConfiguration_Github_Authorization_State { get; set; }
            public System.String ProviderConfiguration_Github_OrganizationName { get; set; }
            public System.String ProviderConfiguration_Gitlab_AccessToken { get; set; }
            public System.String ProviderConfiguration_Gitlab_InstanceUrl { get; set; }
            public System.String ProviderConfiguration_Gitlab_TargetPath { get; set; }
            public Amazon.Continuum.GitLabTargetType ProviderConfiguration_Gitlab_TargetType { get; set; }
            public System.String ProviderConfiguration_S3_Bucket { get; set; }
            public System.String ProviderConfiguration_S3_ExternalId { get; set; }
            public System.String ProviderConfiguration_S3_RoleArn { get; set; }
            public System.Func<Amazon.Continuum.Model.CreateIntegrationResponse, NewCONTIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
