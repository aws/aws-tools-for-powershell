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
using Amazon.Amplify;
using Amazon.Amplify.Model;

namespace Amazon.PowerShell.Cmdlets.AMP
{
    /// <summary>
    /// Creates a new Amplify app.
    /// </summary>
    [Cmdlet("New", "AMPApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Amplify.Model.App")]
    [AWSCmdlet("Calls the AWS Amplify CreateApp API operation.", Operation = new[] {"CreateApp"}, SelectReturnType = typeof(Amazon.Amplify.Model.CreateAppResponse))]
    [AWSCmdletOutput("Amazon.Amplify.Model.App or Amazon.Amplify.Model.CreateAppResponse",
        "This cmdlet returns an Amazon.Amplify.Model.App object.",
        "The service call response (type Amazon.Amplify.Model.CreateAppResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMPAppCmdlet : AmazonAmplifyClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>The personal access token for a GitHub repository for an Amplify app. The personal
        /// access token is used to authorize access to a GitHub repository using the Amplify
        /// GitHub App. The token is not stored.</para><para>Use <code>accessToken</code> for GitHub repositories only. To authorize access to
        /// a repository provider such as Bitbucket or CodeCommit, use <code>oauthToken</code>.</para><para>You must specify either <code>accessToken</code> or <code>oauthToken</code> when you
        /// create a new app.</para><para>Existing Amplify apps deployed from a GitHub repository using OAuth continue to work
        /// with CI/CD. However, we strongly recommend that you migrate these apps to use the
        /// GitHub App. For more information, see <a href="https://docs.aws.amazon.com/amplify/latest/userguide/setting-up-GitHub-access.html#migrating-to-github-app-auth">Migrating
        /// an existing OAuth app to the Amplify GitHub App</a> in the <i>Amplify User Guide</i>
        /// .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessToken { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationPattern
        /// <summary>
        /// <para>
        /// <para>The automated branch creation glob patterns for an Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoBranchCreationPatterns")]
        public System.String[] AutoBranchCreationPattern { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_BasicAuthCredential
        /// <summary>
        /// <para>
        /// <para>The basic authorization credentials for the autocreated branch. You must base64-encode
        /// the authorization credentials and provide them in the format <code>user:password</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoBranchCreationConfig_BasicAuthCredentials")]
        public System.String AutoBranchCreationConfig_BasicAuthCredential { get; set; }
        #endregion
        
        #region Parameter BasicAuthCredential
        /// <summary>
        /// <para>
        /// <para>The credentials for basic authorization for an Amplify app. You must base64-encode
        /// the authorization credentials and provide them in the format <code>user:password</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BasicAuthCredentials")]
        public System.String BasicAuthCredential { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_BuildSpec
        /// <summary>
        /// <para>
        /// <para>The build specification (build spec) for the autocreated branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoBranchCreationConfig_BuildSpec { get; set; }
        #endregion
        
        #region Parameter BuildSpec
        /// <summary>
        /// <para>
        /// <para>The build specification (build spec) for an Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildSpec { get; set; }
        #endregion
        
        #region Parameter CustomHeader
        /// <summary>
        /// <para>
        /// <para>The custom HTTP headers for an Amplify app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomHeaders")]
        public System.String CustomHeader { get; set; }
        #endregion
        
        #region Parameter CustomRule
        /// <summary>
        /// <para>
        /// <para>The custom rewrite and redirect rules for an Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomRules")]
        public Amazon.Amplify.Model.CustomRule[] CustomRule { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnableAutoBranchCreation
        /// <summary>
        /// <para>
        /// <para>Enables automated branch creation for an Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableAutoBranchCreation { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_EnableAutoBuild
        /// <summary>
        /// <para>
        /// <para>Enables auto building for the autocreated branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoBranchCreationConfig_EnableAutoBuild { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_EnableBasicAuth
        /// <summary>
        /// <para>
        /// <para>Enables basic authorization for the autocreated branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoBranchCreationConfig_EnableBasicAuth { get; set; }
        #endregion
        
        #region Parameter EnableBasicAuth
        /// <summary>
        /// <para>
        /// <para>Enables basic authorization for an Amplify app. This will apply to all branches that
        /// are part of this app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableBasicAuth { get; set; }
        #endregion
        
        #region Parameter EnableBranchAutoBuild
        /// <summary>
        /// <para>
        /// <para>Enables the auto building of branches for an Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableBranchAutoBuild { get; set; }
        #endregion
        
        #region Parameter EnableBranchAutoDeletion
        /// <summary>
        /// <para>
        /// <para>Automatically disconnects a branch in the Amplify console when you delete a branch
        /// from your Git repository. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableBranchAutoDeletion { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_EnablePerformanceMode
        /// <summary>
        /// <para>
        /// <para>Enables performance mode for the branch.</para><para>Performance mode optimizes for faster hosting performance by keeping content cached
        /// at the edge for a longer interval. When performance mode is enabled, hosting configuration
        /// or code changes can take up to 10 minutes to roll out. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoBranchCreationConfig_EnablePerformanceMode { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_EnablePullRequestPreview
        /// <summary>
        /// <para>
        /// <para>Enables pull request previews for the autocreated branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoBranchCreationConfig_EnablePullRequestPreview { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>The environment variables for the autocreated branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoBranchCreationConfig_EnvironmentVariables")]
        public System.Collections.Hashtable AutoBranchCreationConfig_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>The environment variables map for an Amplify app. </para><para>For a list of the environment variables that are accessible to Amplify by default,
        /// see <a href="https://docs.aws.amazon.com/amplify/latest/userguide/amplify-console-environment-variables.html">Amplify
        /// Environment variables</a> in the <i>Amplify Hosting User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnvironmentVariables")]
        public System.Collections.Hashtable EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_Framework
        /// <summary>
        /// <para>
        /// <para>The framework for the autocreated branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoBranchCreationConfig_Framework { get; set; }
        #endregion
        
        #region Parameter IamServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The AWS Identity and Access Management (IAM) service role for an Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amplify app. </para>
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
        
        #region Parameter OauthToken
        /// <summary>
        /// <para>
        /// <para>The OAuth token for a third-party source control system for an Amplify app. The OAuth
        /// token is used to create a webhook and a read-only deploy key using SSH cloning. The
        /// OAuth token is not stored.</para><para>Use <code>oauthToken</code> for repository providers other than GitHub, such as Bitbucket
        /// or CodeCommit. To authorize access to GitHub as your repository provider, use <code>accessToken</code>.</para><para>You must specify either <code>oauthToken</code> or <code>accessToken</code> when you
        /// create a new app.</para><para>Existing Amplify apps deployed from a GitHub repository using OAuth continue to work
        /// with CI/CD. However, we strongly recommend that you migrate these apps to use the
        /// GitHub App. For more information, see <a href="https://docs.aws.amazon.com/amplify/latest/userguide/setting-up-GitHub-access.html#migrating-to-github-app-auth">Migrating
        /// an existing OAuth app to the Amplify GitHub App</a> in the <i>Amplify User Guide</i>
        /// .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OauthToken { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The platform for the Amplify app. For a static app, set the platform type to <code>WEB</code>.
        /// For a dynamic server-side rendered (SSR) app, set the platform type to <code>WEB_COMPUTE</code>.
        /// For an app requiring Amplify Hosting's original SSR support only, set the platform
        /// type to <code>WEB_DYNAMIC</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Amplify.Platform")]
        public Amazon.Amplify.Platform Platform { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_PullRequestEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The Amplify environment name for the pull request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoBranchCreationConfig_PullRequestEnvironmentName { get; set; }
        #endregion
        
        #region Parameter Repository
        /// <summary>
        /// <para>
        /// <para>The Git repository for the Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Repository { get; set; }
        #endregion
        
        #region Parameter AutoBranchCreationConfig_Stage
        /// <summary>
        /// <para>
        /// <para>Describes the current stage for the autocreated branch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Amplify.Stage")]
        public Amazon.Amplify.Stage AutoBranchCreationConfig_Stage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag for an Amplify app. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'App'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Amplify.Model.CreateAppResponse).
        /// Specifying the name of a property of type Amazon.Amplify.Model.CreateAppResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "App";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMPApp (CreateApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Amplify.Model.CreateAppResponse, NewAMPAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessToken = this.AccessToken;
            context.AutoBranchCreationConfig_BasicAuthCredential = this.AutoBranchCreationConfig_BasicAuthCredential;
            context.AutoBranchCreationConfig_BuildSpec = this.AutoBranchCreationConfig_BuildSpec;
            context.AutoBranchCreationConfig_EnableAutoBuild = this.AutoBranchCreationConfig_EnableAutoBuild;
            context.AutoBranchCreationConfig_EnableBasicAuth = this.AutoBranchCreationConfig_EnableBasicAuth;
            context.AutoBranchCreationConfig_EnablePerformanceMode = this.AutoBranchCreationConfig_EnablePerformanceMode;
            context.AutoBranchCreationConfig_EnablePullRequestPreview = this.AutoBranchCreationConfig_EnablePullRequestPreview;
            if (this.AutoBranchCreationConfig_EnvironmentVariable != null)
            {
                context.AutoBranchCreationConfig_EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AutoBranchCreationConfig_EnvironmentVariable.Keys)
                {
                    context.AutoBranchCreationConfig_EnvironmentVariable.Add((String)hashKey, (String)(this.AutoBranchCreationConfig_EnvironmentVariable[hashKey]));
                }
            }
            context.AutoBranchCreationConfig_Framework = this.AutoBranchCreationConfig_Framework;
            context.AutoBranchCreationConfig_PullRequestEnvironmentName = this.AutoBranchCreationConfig_PullRequestEnvironmentName;
            context.AutoBranchCreationConfig_Stage = this.AutoBranchCreationConfig_Stage;
            if (this.AutoBranchCreationPattern != null)
            {
                context.AutoBranchCreationPattern = new List<System.String>(this.AutoBranchCreationPattern);
            }
            context.BasicAuthCredential = this.BasicAuthCredential;
            context.BuildSpec = this.BuildSpec;
            context.CustomHeader = this.CustomHeader;
            if (this.CustomRule != null)
            {
                context.CustomRule = new List<Amazon.Amplify.Model.CustomRule>(this.CustomRule);
            }
            context.Description = this.Description;
            context.EnableAutoBranchCreation = this.EnableAutoBranchCreation;
            context.EnableBasicAuth = this.EnableBasicAuth;
            context.EnableBranchAutoBuild = this.EnableBranchAutoBuild;
            context.EnableBranchAutoDeletion = this.EnableBranchAutoDeletion;
            if (this.EnvironmentVariable != null)
            {
                context.EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EnvironmentVariable.Keys)
                {
                    context.EnvironmentVariable.Add((String)hashKey, (String)(this.EnvironmentVariable[hashKey]));
                }
            }
            context.IamServiceRoleArn = this.IamServiceRoleArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OauthToken = this.OauthToken;
            context.Platform = this.Platform;
            context.Repository = this.Repository;
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
            var request = new Amazon.Amplify.Model.CreateAppRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
            }
            
             // populate AutoBranchCreationConfig
            var requestAutoBranchCreationConfigIsNull = true;
            request.AutoBranchCreationConfig = new Amazon.Amplify.Model.AutoBranchCreationConfig();
            System.String requestAutoBranchCreationConfig_autoBranchCreationConfig_BasicAuthCredential = null;
            if (cmdletContext.AutoBranchCreationConfig_BasicAuthCredential != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_BasicAuthCredential = cmdletContext.AutoBranchCreationConfig_BasicAuthCredential;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_BasicAuthCredential != null)
            {
                request.AutoBranchCreationConfig.BasicAuthCredentials = requestAutoBranchCreationConfig_autoBranchCreationConfig_BasicAuthCredential;
                requestAutoBranchCreationConfigIsNull = false;
            }
            System.String requestAutoBranchCreationConfig_autoBranchCreationConfig_BuildSpec = null;
            if (cmdletContext.AutoBranchCreationConfig_BuildSpec != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_BuildSpec = cmdletContext.AutoBranchCreationConfig_BuildSpec;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_BuildSpec != null)
            {
                request.AutoBranchCreationConfig.BuildSpec = requestAutoBranchCreationConfig_autoBranchCreationConfig_BuildSpec;
                requestAutoBranchCreationConfigIsNull = false;
            }
            System.Boolean? requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableAutoBuild = null;
            if (cmdletContext.AutoBranchCreationConfig_EnableAutoBuild != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableAutoBuild = cmdletContext.AutoBranchCreationConfig_EnableAutoBuild.Value;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableAutoBuild != null)
            {
                request.AutoBranchCreationConfig.EnableAutoBuild = requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableAutoBuild.Value;
                requestAutoBranchCreationConfigIsNull = false;
            }
            System.Boolean? requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableBasicAuth = null;
            if (cmdletContext.AutoBranchCreationConfig_EnableBasicAuth != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableBasicAuth = cmdletContext.AutoBranchCreationConfig_EnableBasicAuth.Value;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableBasicAuth != null)
            {
                request.AutoBranchCreationConfig.EnableBasicAuth = requestAutoBranchCreationConfig_autoBranchCreationConfig_EnableBasicAuth.Value;
                requestAutoBranchCreationConfigIsNull = false;
            }
            System.Boolean? requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePerformanceMode = null;
            if (cmdletContext.AutoBranchCreationConfig_EnablePerformanceMode != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePerformanceMode = cmdletContext.AutoBranchCreationConfig_EnablePerformanceMode.Value;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePerformanceMode != null)
            {
                request.AutoBranchCreationConfig.EnablePerformanceMode = requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePerformanceMode.Value;
                requestAutoBranchCreationConfigIsNull = false;
            }
            System.Boolean? requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePullRequestPreview = null;
            if (cmdletContext.AutoBranchCreationConfig_EnablePullRequestPreview != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePullRequestPreview = cmdletContext.AutoBranchCreationConfig_EnablePullRequestPreview.Value;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePullRequestPreview != null)
            {
                request.AutoBranchCreationConfig.EnablePullRequestPreview = requestAutoBranchCreationConfig_autoBranchCreationConfig_EnablePullRequestPreview.Value;
                requestAutoBranchCreationConfigIsNull = false;
            }
            Dictionary<System.String, System.String> requestAutoBranchCreationConfig_autoBranchCreationConfig_EnvironmentVariable = null;
            if (cmdletContext.AutoBranchCreationConfig_EnvironmentVariable != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_EnvironmentVariable = cmdletContext.AutoBranchCreationConfig_EnvironmentVariable;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_EnvironmentVariable != null)
            {
                request.AutoBranchCreationConfig.EnvironmentVariables = requestAutoBranchCreationConfig_autoBranchCreationConfig_EnvironmentVariable;
                requestAutoBranchCreationConfigIsNull = false;
            }
            System.String requestAutoBranchCreationConfig_autoBranchCreationConfig_Framework = null;
            if (cmdletContext.AutoBranchCreationConfig_Framework != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_Framework = cmdletContext.AutoBranchCreationConfig_Framework;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_Framework != null)
            {
                request.AutoBranchCreationConfig.Framework = requestAutoBranchCreationConfig_autoBranchCreationConfig_Framework;
                requestAutoBranchCreationConfigIsNull = false;
            }
            System.String requestAutoBranchCreationConfig_autoBranchCreationConfig_PullRequestEnvironmentName = null;
            if (cmdletContext.AutoBranchCreationConfig_PullRequestEnvironmentName != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_PullRequestEnvironmentName = cmdletContext.AutoBranchCreationConfig_PullRequestEnvironmentName;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_PullRequestEnvironmentName != null)
            {
                request.AutoBranchCreationConfig.PullRequestEnvironmentName = requestAutoBranchCreationConfig_autoBranchCreationConfig_PullRequestEnvironmentName;
                requestAutoBranchCreationConfigIsNull = false;
            }
            Amazon.Amplify.Stage requestAutoBranchCreationConfig_autoBranchCreationConfig_Stage = null;
            if (cmdletContext.AutoBranchCreationConfig_Stage != null)
            {
                requestAutoBranchCreationConfig_autoBranchCreationConfig_Stage = cmdletContext.AutoBranchCreationConfig_Stage;
            }
            if (requestAutoBranchCreationConfig_autoBranchCreationConfig_Stage != null)
            {
                request.AutoBranchCreationConfig.Stage = requestAutoBranchCreationConfig_autoBranchCreationConfig_Stage;
                requestAutoBranchCreationConfigIsNull = false;
            }
             // determine if request.AutoBranchCreationConfig should be set to null
            if (requestAutoBranchCreationConfigIsNull)
            {
                request.AutoBranchCreationConfig = null;
            }
            if (cmdletContext.AutoBranchCreationPattern != null)
            {
                request.AutoBranchCreationPatterns = cmdletContext.AutoBranchCreationPattern;
            }
            if (cmdletContext.BasicAuthCredential != null)
            {
                request.BasicAuthCredentials = cmdletContext.BasicAuthCredential;
            }
            if (cmdletContext.BuildSpec != null)
            {
                request.BuildSpec = cmdletContext.BuildSpec;
            }
            if (cmdletContext.CustomHeader != null)
            {
                request.CustomHeaders = cmdletContext.CustomHeader;
            }
            if (cmdletContext.CustomRule != null)
            {
                request.CustomRules = cmdletContext.CustomRule;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnableAutoBranchCreation != null)
            {
                request.EnableAutoBranchCreation = cmdletContext.EnableAutoBranchCreation.Value;
            }
            if (cmdletContext.EnableBasicAuth != null)
            {
                request.EnableBasicAuth = cmdletContext.EnableBasicAuth.Value;
            }
            if (cmdletContext.EnableBranchAutoBuild != null)
            {
                request.EnableBranchAutoBuild = cmdletContext.EnableBranchAutoBuild.Value;
            }
            if (cmdletContext.EnableBranchAutoDeletion != null)
            {
                request.EnableBranchAutoDeletion = cmdletContext.EnableBranchAutoDeletion.Value;
            }
            if (cmdletContext.EnvironmentVariable != null)
            {
                request.EnvironmentVariables = cmdletContext.EnvironmentVariable;
            }
            if (cmdletContext.IamServiceRoleArn != null)
            {
                request.IamServiceRoleArn = cmdletContext.IamServiceRoleArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OauthToken != null)
            {
                request.OauthToken = cmdletContext.OauthToken;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.Repository != null)
            {
                request.Repository = cmdletContext.Repository;
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
        
        private Amazon.Amplify.Model.CreateAppResponse CallAWSServiceOperation(IAmazonAmplify client, Amazon.Amplify.Model.CreateAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Amplify", "CreateApp");
            try
            {
                #if DESKTOP
                return client.CreateApp(request);
                #elif CORECLR
                return client.CreateAppAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessToken { get; set; }
            public System.String AutoBranchCreationConfig_BasicAuthCredential { get; set; }
            public System.String AutoBranchCreationConfig_BuildSpec { get; set; }
            public System.Boolean? AutoBranchCreationConfig_EnableAutoBuild { get; set; }
            public System.Boolean? AutoBranchCreationConfig_EnableBasicAuth { get; set; }
            public System.Boolean? AutoBranchCreationConfig_EnablePerformanceMode { get; set; }
            public System.Boolean? AutoBranchCreationConfig_EnablePullRequestPreview { get; set; }
            public Dictionary<System.String, System.String> AutoBranchCreationConfig_EnvironmentVariable { get; set; }
            public System.String AutoBranchCreationConfig_Framework { get; set; }
            public System.String AutoBranchCreationConfig_PullRequestEnvironmentName { get; set; }
            public Amazon.Amplify.Stage AutoBranchCreationConfig_Stage { get; set; }
            public List<System.String> AutoBranchCreationPattern { get; set; }
            public System.String BasicAuthCredential { get; set; }
            public System.String BuildSpec { get; set; }
            public System.String CustomHeader { get; set; }
            public List<Amazon.Amplify.Model.CustomRule> CustomRule { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnableAutoBranchCreation { get; set; }
            public System.Boolean? EnableBasicAuth { get; set; }
            public System.Boolean? EnableBranchAutoBuild { get; set; }
            public System.Boolean? EnableBranchAutoDeletion { get; set; }
            public Dictionary<System.String, System.String> EnvironmentVariable { get; set; }
            public System.String IamServiceRoleArn { get; set; }
            public System.String Name { get; set; }
            public System.String OauthToken { get; set; }
            public Amazon.Amplify.Platform Platform { get; set; }
            public System.String Repository { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Amplify.Model.CreateAppResponse, NewAMPAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.App;
        }
        
    }
}
