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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Updates an Amazon Q Business web experience.
    /// </summary>
    [Cmdlet("Update", "QBUSWebExperience", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness UpdateWebExperience API operation.", Operation = new[] {"UpdateWebExperience"}, SelectReturnType = typeof(Amazon.QBusiness.Model.UpdateWebExperienceResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.UpdateWebExperienceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.UpdateWebExperienceResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateQBUSWebExperienceCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q Business application attached to the web experience.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter SamlConfiguration_AuthenticationUrl
        /// <summary>
        /// <para>
        /// <para>The URL where Amazon Q Business end users will be redirected for authentication. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProviderConfiguration_SamlConfiguration_AuthenticationUrl")]
        public System.String SamlConfiguration_AuthenticationUrl { get; set; }
        #endregion
        
        #region Parameter BrowserExtensionConfiguration_EnabledBrowserExtension
        /// <summary>
        /// <para>
        /// <para>Specify the browser extensions allowed for your Amazon Q web experience.</para><ul><li><para><c>CHROME</c> — Enables the extension for Chromium-based browsers (Google Chrome,
        /// Microsoft Edge, Opera, etc.).</para></li><li><para><c>FIREFOX</c> — Enables the extension for Mozilla Firefox.</para></li><li><para><c>CHROME</c> and <c>FIREFOX</c> — Enable the extension for Chromium-based browsers
        /// and Mozilla Firefox.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BrowserExtensionConfiguration_EnabledBrowserExtensions")]
        public System.String[] BrowserExtensionConfiguration_EnabledBrowserExtension { get; set; }
        #endregion
        
        #region Parameter SamlConfiguration_MetadataXML
        /// <summary>
        /// <para>
        /// <para>The metadata XML that your IdP generated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfiguration_SamlConfiguration_MetadataXML")]
        public System.String SamlConfiguration_MetadataXML { get; set; }
        #endregion
        
        #region Parameter Origin
        /// <summary>
        /// <para>
        /// Amazon.QBusiness.Model.UpdateWebExperienceRequest.Origins
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Origins")]
        public System.String[] Origin { get; set; }
        #endregion
        
        #region Parameter SamlConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role assumed by users when they authenticate
        /// into their Amazon Q Business web experience, containing the relevant Amazon Q Business
        /// permissions for conversing with Amazon Q Business.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfiguration_SamlConfiguration_RoleArn")]
        public System.String SamlConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role with permission to access the Amazon Q
        /// Business web experience and required resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SamplePromptsControlMode
        /// <summary>
        /// <para>
        /// <para>Determines whether sample prompts are enabled in the web experience for an end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.WebExperienceSamplePromptsControlMode")]
        public Amazon.QBusiness.WebExperienceSamplePromptsControlMode SamplePromptsControlMode { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfiguration_SecretsArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a Secrets Manager secret containing the OIDC client
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProviderConfiguration_OpenIDConnectConfiguration_SecretsArn")]
        public System.String OpenIDConnectConfiguration_SecretsArn { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfiguration_SecretsRole
        /// <summary>
        /// <para>
        /// <para>An IAM role with permissions to access KMS to decrypt the Secrets Manager secret containing
        /// your OIDC client secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProviderConfiguration_OpenIDConnectConfiguration_SecretsRole")]
        public System.String OpenIDConnectConfiguration_SecretsRole { get; set; }
        #endregion
        
        #region Parameter Subtitle
        /// <summary>
        /// <para>
        /// <para>The subtitle of the Amazon Q Business web experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subtitle { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>The title of the Amazon Q Business web experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter SamlConfiguration_UserGroupAttribute
        /// <summary>
        /// <para>
        /// <para>The group attribute name in your IdP that maps to user groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfiguration_SamlConfiguration_UserGroupAttribute")]
        public System.String SamlConfiguration_UserGroupAttribute { get; set; }
        #endregion
        
        #region Parameter SamlConfiguration_UserIdAttribute
        /// <summary>
        /// <para>
        /// <para>The user attribute name in your IdP that maps to the user email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfiguration_SamlConfiguration_UserIdAttribute")]
        public System.String SamlConfiguration_UserIdAttribute { get; set; }
        #endregion
        
        #region Parameter WebExperienceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q Business web experience.</para>
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
        public System.String WebExperienceId { get; set; }
        #endregion
        
        #region Parameter WelcomeMessage
        /// <summary>
        /// <para>
        /// <para>A customized welcome message for an end user in an Amazon Q Business web experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WelcomeMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.UpdateWebExperienceResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WebExperienceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WebExperienceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WebExperienceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WebExperienceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QBUSWebExperience (UpdateWebExperience)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.UpdateWebExperienceResponse, UpdateQBUSWebExperienceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WebExperienceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamlConfiguration_MetadataXML = this.SamlConfiguration_MetadataXML;
            context.SamlConfiguration_RoleArn = this.SamlConfiguration_RoleArn;
            context.SamlConfiguration_UserGroupAttribute = this.SamlConfiguration_UserGroupAttribute;
            context.SamlConfiguration_UserIdAttribute = this.SamlConfiguration_UserIdAttribute;
            if (this.BrowserExtensionConfiguration_EnabledBrowserExtension != null)
            {
                context.BrowserExtensionConfiguration_EnabledBrowserExtension = new List<System.String>(this.BrowserExtensionConfiguration_EnabledBrowserExtension);
            }
            context.OpenIDConnectConfiguration_SecretsArn = this.OpenIDConnectConfiguration_SecretsArn;
            context.OpenIDConnectConfiguration_SecretsRole = this.OpenIDConnectConfiguration_SecretsRole;
            context.SamlConfiguration_AuthenticationUrl = this.SamlConfiguration_AuthenticationUrl;
            if (this.Origin != null)
            {
                context.Origin = new List<System.String>(this.Origin);
            }
            context.RoleArn = this.RoleArn;
            context.SamplePromptsControlMode = this.SamplePromptsControlMode;
            context.Subtitle = this.Subtitle;
            context.Title = this.Title;
            context.WebExperienceId = this.WebExperienceId;
            #if MODULAR
            if (this.WebExperienceId == null && ParameterWasBound(nameof(this.WebExperienceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WebExperienceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WelcomeMessage = this.WelcomeMessage;
            
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
            var request = new Amazon.QBusiness.Model.UpdateWebExperienceRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate AuthenticationConfiguration
            var requestAuthenticationConfigurationIsNull = true;
            request.AuthenticationConfiguration = new Amazon.QBusiness.Model.WebExperienceAuthConfiguration();
            Amazon.QBusiness.Model.SamlConfiguration requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration = null;
            
             // populate SamlConfiguration
            var requestAuthenticationConfiguration_authenticationConfiguration_SamlConfigurationIsNull = true;
            requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration = new Amazon.QBusiness.Model.SamlConfiguration();
            System.String requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_MetadataXML = null;
            if (cmdletContext.SamlConfiguration_MetadataXML != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_MetadataXML = cmdletContext.SamlConfiguration_MetadataXML;
            }
            if (requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_MetadataXML != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration.MetadataXML = requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_MetadataXML;
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfigurationIsNull = false;
            }
            System.String requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_RoleArn = null;
            if (cmdletContext.SamlConfiguration_RoleArn != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_RoleArn = cmdletContext.SamlConfiguration_RoleArn;
            }
            if (requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_RoleArn != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration.RoleArn = requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_RoleArn;
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfigurationIsNull = false;
            }
            System.String requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserGroupAttribute = null;
            if (cmdletContext.SamlConfiguration_UserGroupAttribute != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserGroupAttribute = cmdletContext.SamlConfiguration_UserGroupAttribute;
            }
            if (requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserGroupAttribute != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration.UserGroupAttribute = requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserGroupAttribute;
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfigurationIsNull = false;
            }
            System.String requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserIdAttribute = null;
            if (cmdletContext.SamlConfiguration_UserIdAttribute != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserIdAttribute = cmdletContext.SamlConfiguration_UserIdAttribute;
            }
            if (requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserIdAttribute != null)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration.UserIdAttribute = requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration_samlConfiguration_UserIdAttribute;
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfigurationIsNull = false;
            }
             // determine if requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration should be set to null
            if (requestAuthenticationConfiguration_authenticationConfiguration_SamlConfigurationIsNull)
            {
                requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration = null;
            }
            if (requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration != null)
            {
                request.AuthenticationConfiguration.SamlConfiguration = requestAuthenticationConfiguration_authenticationConfiguration_SamlConfiguration;
                requestAuthenticationConfigurationIsNull = false;
            }
             // determine if request.AuthenticationConfiguration should be set to null
            if (requestAuthenticationConfigurationIsNull)
            {
                request.AuthenticationConfiguration = null;
            }
            
             // populate BrowserExtensionConfiguration
            var requestBrowserExtensionConfigurationIsNull = true;
            request.BrowserExtensionConfiguration = new Amazon.QBusiness.Model.BrowserExtensionConfiguration();
            List<System.String> requestBrowserExtensionConfiguration_browserExtensionConfiguration_EnabledBrowserExtension = null;
            if (cmdletContext.BrowserExtensionConfiguration_EnabledBrowserExtension != null)
            {
                requestBrowserExtensionConfiguration_browserExtensionConfiguration_EnabledBrowserExtension = cmdletContext.BrowserExtensionConfiguration_EnabledBrowserExtension;
            }
            if (requestBrowserExtensionConfiguration_browserExtensionConfiguration_EnabledBrowserExtension != null)
            {
                request.BrowserExtensionConfiguration.EnabledBrowserExtensions = requestBrowserExtensionConfiguration_browserExtensionConfiguration_EnabledBrowserExtension;
                requestBrowserExtensionConfigurationIsNull = false;
            }
             // determine if request.BrowserExtensionConfiguration should be set to null
            if (requestBrowserExtensionConfigurationIsNull)
            {
                request.BrowserExtensionConfiguration = null;
            }
            
             // populate IdentityProviderConfiguration
            var requestIdentityProviderConfigurationIsNull = true;
            request.IdentityProviderConfiguration = new Amazon.QBusiness.Model.IdentityProviderConfiguration();
            Amazon.QBusiness.Model.SamlProviderConfiguration requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration = null;
            
             // populate SamlConfiguration
            var requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfigurationIsNull = true;
            requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration = new Amazon.QBusiness.Model.SamlProviderConfiguration();
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration_samlConfiguration_AuthenticationUrl = null;
            if (cmdletContext.SamlConfiguration_AuthenticationUrl != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration_samlConfiguration_AuthenticationUrl = cmdletContext.SamlConfiguration_AuthenticationUrl;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration_samlConfiguration_AuthenticationUrl != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration.AuthenticationUrl = requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration_samlConfiguration_AuthenticationUrl;
                requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfigurationIsNull = false;
            }
             // determine if requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration should be set to null
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfigurationIsNull)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration = null;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration != null)
            {
                request.IdentityProviderConfiguration.SamlConfiguration = requestIdentityProviderConfiguration_identityProviderConfiguration_SamlConfiguration;
                requestIdentityProviderConfigurationIsNull = false;
            }
            Amazon.QBusiness.Model.OpenIDConnectProviderConfiguration requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration = null;
            
             // populate OpenIDConnectConfiguration
            var requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfigurationIsNull = true;
            requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration = new Amazon.QBusiness.Model.OpenIDConnectProviderConfiguration();
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsArn = null;
            if (cmdletContext.OpenIDConnectConfiguration_SecretsArn != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsArn = cmdletContext.OpenIDConnectConfiguration_SecretsArn;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsArn != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration.SecretsArn = requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsArn;
                requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfigurationIsNull = false;
            }
            System.String requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsRole = null;
            if (cmdletContext.OpenIDConnectConfiguration_SecretsRole != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsRole = cmdletContext.OpenIDConnectConfiguration_SecretsRole;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsRole != null)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration.SecretsRole = requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration_openIDConnectConfiguration_SecretsRole;
                requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfigurationIsNull = false;
            }
             // determine if requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration should be set to null
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfigurationIsNull)
            {
                requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration = null;
            }
            if (requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration != null)
            {
                request.IdentityProviderConfiguration.OpenIDConnectConfiguration = requestIdentityProviderConfiguration_identityProviderConfiguration_OpenIDConnectConfiguration;
                requestIdentityProviderConfigurationIsNull = false;
            }
             // determine if request.IdentityProviderConfiguration should be set to null
            if (requestIdentityProviderConfigurationIsNull)
            {
                request.IdentityProviderConfiguration = null;
            }
            if (cmdletContext.Origin != null)
            {
                request.Origins = cmdletContext.Origin;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SamplePromptsControlMode != null)
            {
                request.SamplePromptsControlMode = cmdletContext.SamplePromptsControlMode;
            }
            if (cmdletContext.Subtitle != null)
            {
                request.Subtitle = cmdletContext.Subtitle;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
            }
            if (cmdletContext.WebExperienceId != null)
            {
                request.WebExperienceId = cmdletContext.WebExperienceId;
            }
            if (cmdletContext.WelcomeMessage != null)
            {
                request.WelcomeMessage = cmdletContext.WelcomeMessage;
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
        
        private Amazon.QBusiness.Model.UpdateWebExperienceResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.UpdateWebExperienceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "UpdateWebExperience");
            try
            {
                #if DESKTOP
                return client.UpdateWebExperience(request);
                #elif CORECLR
                return client.UpdateWebExperienceAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String SamlConfiguration_MetadataXML { get; set; }
            public System.String SamlConfiguration_RoleArn { get; set; }
            public System.String SamlConfiguration_UserGroupAttribute { get; set; }
            public System.String SamlConfiguration_UserIdAttribute { get; set; }
            public List<System.String> BrowserExtensionConfiguration_EnabledBrowserExtension { get; set; }
            public System.String OpenIDConnectConfiguration_SecretsArn { get; set; }
            public System.String OpenIDConnectConfiguration_SecretsRole { get; set; }
            public System.String SamlConfiguration_AuthenticationUrl { get; set; }
            public List<System.String> Origin { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.QBusiness.WebExperienceSamplePromptsControlMode SamplePromptsControlMode { get; set; }
            public System.String Subtitle { get; set; }
            public System.String Title { get; set; }
            public System.String WebExperienceId { get; set; }
            public System.String WelcomeMessage { get; set; }
            public System.Func<Amazon.QBusiness.Model.UpdateWebExperienceResponse, UpdateQBUSWebExperienceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
