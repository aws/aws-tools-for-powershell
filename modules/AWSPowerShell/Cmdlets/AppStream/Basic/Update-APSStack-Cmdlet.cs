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
using Amazon.AppStream;
using Amazon.AppStream.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Updates the specified fields for the specified stack.
    /// </summary>
    [Cmdlet("Update", "APSStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Stack")]
    [AWSCmdlet("Calls the Amazon AppStream UpdateStack API operation.", Operation = new[] {"UpdateStack"}, SelectReturnType = typeof(Amazon.AppStream.Model.UpdateStackResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.Stack or Amazon.AppStream.Model.UpdateStackResponse",
        "This cmdlet returns an Amazon.AppStream.Model.Stack object.",
        "The service call response (type Amazon.AppStream.Model.UpdateStackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAPSStackCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessEndpoint
        /// <summary>
        /// <para>
        /// <para>The list of interface VPC endpoint (interface endpoint) objects. Users of the stack
        /// can connect to WorkSpaces Applications only through the specified endpoints.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessEndpoints")]
        public Amazon.AppStream.Model.AccessEndpoint[] AccessEndpoint { get; set; }
        #endregion
        
        #region Parameter ContentRedirection_HostToClient_AllowedUrl
        /// <summary>
        /// <para>
        /// <para>List of URL patterns that are allowed to be redirected. URLs matching these patterns
        /// will be redirected unless they also match a pattern in the denied list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContentRedirection_HostToClient_AllowedUrls")]
        public System.String[] ContentRedirection_HostToClient_AllowedUrl { get; set; }
        #endregion
        
        #region Parameter AttributesToDelete
        /// <summary>
        /// <para>
        /// <para>The stack attributes to delete.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AttributesToDelete { get; set; }
        #endregion
        
        #region Parameter ContentRedirection_HostToClient_DeniedUrl
        /// <summary>
        /// <para>
        /// <para>List of URL patterns that are denied from redirection. This list takes precedence
        /// over the allowed list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContentRedirection_HostToClient_DeniedUrls")]
        public System.String[] ContentRedirection_HostToClient_DeniedUrl { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The stack name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EmbedHostDomain
        /// <summary>
        /// <para>
        /// <para>The domains where WorkSpaces Applications streaming sessions can be embedded in an
        /// iframe. You must approve the domains that you want to host embedded WorkSpaces Applications
        /// streaming sessions. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmbedHostDomains")]
        public System.String[] EmbedHostDomain { get; set; }
        #endregion
        
        #region Parameter ApplicationSettings_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables or disables persistent application settings for users during their streaming
        /// sessions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplicationSettings_Enabled { get; set; }
        #endregion
        
        #region Parameter ContentRedirection_HostToClient_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether URL redirection is enabled for this direction.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ContentRedirection_HostToClient_Enabled { get; set; }
        #endregion
        
        #region Parameter FeedbackURL
        /// <summary>
        /// <para>
        /// <para>The URL that users are redirected to after they choose the Send Feedback link. If
        /// no URL is specified, no Send Feedback link is displayed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackURL { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the stack.</para>
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
        
        #region Parameter StreamingExperienceSettings_PreferredProtocol
        /// <summary>
        /// <para>
        /// <para>The preferred protocol that you want to use while streaming your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.PreferredProtocol")]
        public Amazon.AppStream.PreferredProtocol StreamingExperienceSettings_PreferredProtocol { get; set; }
        #endregion
        
        #region Parameter RedirectURL
        /// <summary>
        /// <para>
        /// <para>The URL that users are redirected to after their streaming session ends.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedirectURL { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_S3BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon S3 bucket where agent screenshots are
        /// stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgentAccessConfig_S3BucketArn { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_ScreenImageFormat
        /// <summary>
        /// <para>
        /// <para>The image format for agent screen captures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.ScreenImageFormat")]
        public Amazon.AppStream.ScreenImageFormat AgentAccessConfig_ScreenImageFormat { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_ScreenResolution
        /// <summary>
        /// <para>
        /// <para>The screen resolution for the agent streaming environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.ScreenResolution")]
        public Amazon.AppStream.ScreenResolution AgentAccessConfig_ScreenResolution { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_ScreenshotsUploadEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether screenshot uploads to Amazon S3 are enabled for agent sessions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AgentAccessConfig_ScreenshotsUploadEnabled { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_Setting
        /// <summary>
        /// <para>
        /// <para>The list of agent access settings that define permissions for each agent action.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentAccessConfig_Settings")]
        public Amazon.AppStream.Model.AgentAccessSetting[] AgentAccessConfig_Setting { get; set; }
        #endregion
        
        #region Parameter ApplicationSettings_SettingsGroup
        /// <summary>
        /// <para>
        /// <para>The path prefix for the S3 bucket where users’ persistent application settings are
        /// stored. You can allow the same persistent application settings to be used across multiple
        /// stacks by specifying the same settings group for each stack. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationSettings_SettingsGroup { get; set; }
        #endregion
        
        #region Parameter StorageConnector
        /// <summary>
        /// <para>
        /// <para>The storage connectors to enable.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConnectors")]
        public Amazon.AppStream.Model.StorageConnector[] StorageConnector { get; set; }
        #endregion
        
        #region Parameter UserSetting
        /// <summary>
        /// <para>
        /// <para>The actions that are enabled or disabled for users during their streaming sessions.
        /// By default, these actions are enabled.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserSettings")]
        public Amazon.AppStream.Model.UserSetting[] UserSetting { get; set; }
        #endregion
        
        #region Parameter DeleteStorageConnector
        /// <summary>
        /// <para>
        /// <para>Deletes the storage connectors currently enabled for the stack.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated")]
        [Alias("DeleteStorageConnectors")]
        public System.Boolean? DeleteStorageConnector { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Stack'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.UpdateStackResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.UpdateStackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Stack";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APSStack (UpdateStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.UpdateStackResponse, UpdateAPSStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccessEndpoint != null)
            {
                context.AccessEndpoint = new List<Amazon.AppStream.Model.AccessEndpoint>(this.AccessEndpoint);
            }
            context.AgentAccessConfig_S3BucketArn = this.AgentAccessConfig_S3BucketArn;
            context.AgentAccessConfig_ScreenImageFormat = this.AgentAccessConfig_ScreenImageFormat;
            context.AgentAccessConfig_ScreenResolution = this.AgentAccessConfig_ScreenResolution;
            context.AgentAccessConfig_ScreenshotsUploadEnabled = this.AgentAccessConfig_ScreenshotsUploadEnabled;
            if (this.AgentAccessConfig_Setting != null)
            {
                context.AgentAccessConfig_Setting = new List<Amazon.AppStream.Model.AgentAccessSetting>(this.AgentAccessConfig_Setting);
            }
            context.ApplicationSettings_Enabled = this.ApplicationSettings_Enabled;
            context.ApplicationSettings_SettingsGroup = this.ApplicationSettings_SettingsGroup;
            if (this.AttributesToDelete != null)
            {
                context.AttributesToDelete = new List<System.String>(this.AttributesToDelete);
            }
            if (this.ContentRedirection_HostToClient_AllowedUrl != null)
            {
                context.ContentRedirection_HostToClient_AllowedUrl = new List<System.String>(this.ContentRedirection_HostToClient_AllowedUrl);
            }
            if (this.ContentRedirection_HostToClient_DeniedUrl != null)
            {
                context.ContentRedirection_HostToClient_DeniedUrl = new List<System.String>(this.ContentRedirection_HostToClient_DeniedUrl);
            }
            context.ContentRedirection_HostToClient_Enabled = this.ContentRedirection_HostToClient_Enabled;
            context.DeleteStorageConnector = this.DeleteStorageConnector;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            if (this.EmbedHostDomain != null)
            {
                context.EmbedHostDomain = new List<System.String>(this.EmbedHostDomain);
            }
            context.FeedbackURL = this.FeedbackURL;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RedirectURL = this.RedirectURL;
            if (this.StorageConnector != null)
            {
                context.StorageConnector = new List<Amazon.AppStream.Model.StorageConnector>(this.StorageConnector);
            }
            context.StreamingExperienceSettings_PreferredProtocol = this.StreamingExperienceSettings_PreferredProtocol;
            if (this.UserSetting != null)
            {
                context.UserSetting = new List<Amazon.AppStream.Model.UserSetting>(this.UserSetting);
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
            var request = new Amazon.AppStream.Model.UpdateStackRequest();
            
            if (cmdletContext.AccessEndpoint != null)
            {
                request.AccessEndpoints = cmdletContext.AccessEndpoint;
            }
            
             // populate AgentAccessConfig
            var requestAgentAccessConfigIsNull = true;
            request.AgentAccessConfig = new Amazon.AppStream.Model.AgentAccessConfigForUpdate();
            System.String requestAgentAccessConfig_agentAccessConfig_S3BucketArn = null;
            if (cmdletContext.AgentAccessConfig_S3BucketArn != null)
            {
                requestAgentAccessConfig_agentAccessConfig_S3BucketArn = cmdletContext.AgentAccessConfig_S3BucketArn;
            }
            if (requestAgentAccessConfig_agentAccessConfig_S3BucketArn != null)
            {
                request.AgentAccessConfig.S3BucketArn = requestAgentAccessConfig_agentAccessConfig_S3BucketArn;
                requestAgentAccessConfigIsNull = false;
            }
            Amazon.AppStream.ScreenImageFormat requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat = null;
            if (cmdletContext.AgentAccessConfig_ScreenImageFormat != null)
            {
                requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat = cmdletContext.AgentAccessConfig_ScreenImageFormat;
            }
            if (requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat != null)
            {
                request.AgentAccessConfig.ScreenImageFormat = requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat;
                requestAgentAccessConfigIsNull = false;
            }
            Amazon.AppStream.ScreenResolution requestAgentAccessConfig_agentAccessConfig_ScreenResolution = null;
            if (cmdletContext.AgentAccessConfig_ScreenResolution != null)
            {
                requestAgentAccessConfig_agentAccessConfig_ScreenResolution = cmdletContext.AgentAccessConfig_ScreenResolution;
            }
            if (requestAgentAccessConfig_agentAccessConfig_ScreenResolution != null)
            {
                request.AgentAccessConfig.ScreenResolution = requestAgentAccessConfig_agentAccessConfig_ScreenResolution;
                requestAgentAccessConfigIsNull = false;
            }
            System.Boolean? requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled = null;
            if (cmdletContext.AgentAccessConfig_ScreenshotsUploadEnabled != null)
            {
                requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled = cmdletContext.AgentAccessConfig_ScreenshotsUploadEnabled.Value;
            }
            if (requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled != null)
            {
                request.AgentAccessConfig.ScreenshotsUploadEnabled = requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled.Value;
                requestAgentAccessConfigIsNull = false;
            }
            List<Amazon.AppStream.Model.AgentAccessSetting> requestAgentAccessConfig_agentAccessConfig_Setting = null;
            if (cmdletContext.AgentAccessConfig_Setting != null)
            {
                requestAgentAccessConfig_agentAccessConfig_Setting = cmdletContext.AgentAccessConfig_Setting;
            }
            if (requestAgentAccessConfig_agentAccessConfig_Setting != null)
            {
                request.AgentAccessConfig.Settings = requestAgentAccessConfig_agentAccessConfig_Setting;
                requestAgentAccessConfigIsNull = false;
            }
             // determine if request.AgentAccessConfig should be set to null
            if (requestAgentAccessConfigIsNull)
            {
                request.AgentAccessConfig = null;
            }
            
             // populate ApplicationSettings
            var requestApplicationSettingsIsNull = true;
            request.ApplicationSettings = new Amazon.AppStream.Model.ApplicationSettings();
            System.Boolean? requestApplicationSettings_applicationSettings_Enabled = null;
            if (cmdletContext.ApplicationSettings_Enabled != null)
            {
                requestApplicationSettings_applicationSettings_Enabled = cmdletContext.ApplicationSettings_Enabled.Value;
            }
            if (requestApplicationSettings_applicationSettings_Enabled != null)
            {
                request.ApplicationSettings.Enabled = requestApplicationSettings_applicationSettings_Enabled.Value;
                requestApplicationSettingsIsNull = false;
            }
            System.String requestApplicationSettings_applicationSettings_SettingsGroup = null;
            if (cmdletContext.ApplicationSettings_SettingsGroup != null)
            {
                requestApplicationSettings_applicationSettings_SettingsGroup = cmdletContext.ApplicationSettings_SettingsGroup;
            }
            if (requestApplicationSettings_applicationSettings_SettingsGroup != null)
            {
                request.ApplicationSettings.SettingsGroup = requestApplicationSettings_applicationSettings_SettingsGroup;
                requestApplicationSettingsIsNull = false;
            }
             // determine if request.ApplicationSettings should be set to null
            if (requestApplicationSettingsIsNull)
            {
                request.ApplicationSettings = null;
            }
            if (cmdletContext.AttributesToDelete != null)
            {
                request.AttributesToDelete = cmdletContext.AttributesToDelete;
            }
            
             // populate ContentRedirection
            var requestContentRedirectionIsNull = true;
            request.ContentRedirection = new Amazon.AppStream.Model.ContentRedirection();
            Amazon.AppStream.Model.UrlRedirectionConfig requestContentRedirection_contentRedirection_HostToClient = null;
            
             // populate HostToClient
            var requestContentRedirection_contentRedirection_HostToClientIsNull = true;
            requestContentRedirection_contentRedirection_HostToClient = new Amazon.AppStream.Model.UrlRedirectionConfig();
            List<System.String> requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_AllowedUrl = null;
            if (cmdletContext.ContentRedirection_HostToClient_AllowedUrl != null)
            {
                requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_AllowedUrl = cmdletContext.ContentRedirection_HostToClient_AllowedUrl;
            }
            if (requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_AllowedUrl != null)
            {
                requestContentRedirection_contentRedirection_HostToClient.AllowedUrls = requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_AllowedUrl;
                requestContentRedirection_contentRedirection_HostToClientIsNull = false;
            }
            List<System.String> requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_DeniedUrl = null;
            if (cmdletContext.ContentRedirection_HostToClient_DeniedUrl != null)
            {
                requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_DeniedUrl = cmdletContext.ContentRedirection_HostToClient_DeniedUrl;
            }
            if (requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_DeniedUrl != null)
            {
                requestContentRedirection_contentRedirection_HostToClient.DeniedUrls = requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_DeniedUrl;
                requestContentRedirection_contentRedirection_HostToClientIsNull = false;
            }
            System.Boolean? requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_Enabled = null;
            if (cmdletContext.ContentRedirection_HostToClient_Enabled != null)
            {
                requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_Enabled = cmdletContext.ContentRedirection_HostToClient_Enabled.Value;
            }
            if (requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_Enabled != null)
            {
                requestContentRedirection_contentRedirection_HostToClient.Enabled = requestContentRedirection_contentRedirection_HostToClient_contentRedirection_HostToClient_Enabled.Value;
                requestContentRedirection_contentRedirection_HostToClientIsNull = false;
            }
             // determine if requestContentRedirection_contentRedirection_HostToClient should be set to null
            if (requestContentRedirection_contentRedirection_HostToClientIsNull)
            {
                requestContentRedirection_contentRedirection_HostToClient = null;
            }
            if (requestContentRedirection_contentRedirection_HostToClient != null)
            {
                request.ContentRedirection.HostToClient = requestContentRedirection_contentRedirection_HostToClient;
                requestContentRedirectionIsNull = false;
            }
             // determine if request.ContentRedirection should be set to null
            if (requestContentRedirectionIsNull)
            {
                request.ContentRedirection = null;
            }
            if (cmdletContext.DeleteStorageConnector != null)
            {
                request.DeleteStorageConnectors = cmdletContext.DeleteStorageConnector.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.EmbedHostDomain != null)
            {
                request.EmbedHostDomains = cmdletContext.EmbedHostDomain;
            }
            if (cmdletContext.FeedbackURL != null)
            {
                request.FeedbackURL = cmdletContext.FeedbackURL;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RedirectURL != null)
            {
                request.RedirectURL = cmdletContext.RedirectURL;
            }
            if (cmdletContext.StorageConnector != null)
            {
                request.StorageConnectors = cmdletContext.StorageConnector;
            }
            
             // populate StreamingExperienceSettings
            var requestStreamingExperienceSettingsIsNull = true;
            request.StreamingExperienceSettings = new Amazon.AppStream.Model.StreamingExperienceSettings();
            Amazon.AppStream.PreferredProtocol requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol = null;
            if (cmdletContext.StreamingExperienceSettings_PreferredProtocol != null)
            {
                requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol = cmdletContext.StreamingExperienceSettings_PreferredProtocol;
            }
            if (requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol != null)
            {
                request.StreamingExperienceSettings.PreferredProtocol = requestStreamingExperienceSettings_streamingExperienceSettings_PreferredProtocol;
                requestStreamingExperienceSettingsIsNull = false;
            }
             // determine if request.StreamingExperienceSettings should be set to null
            if (requestStreamingExperienceSettingsIsNull)
            {
                request.StreamingExperienceSettings = null;
            }
            if (cmdletContext.UserSetting != null)
            {
                request.UserSettings = cmdletContext.UserSetting;
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
        
        private Amazon.AppStream.Model.UpdateStackResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.UpdateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "UpdateStack");
            try
            {
                return client.UpdateStackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.AppStream.Model.AccessEndpoint> AccessEndpoint { get; set; }
            public System.String AgentAccessConfig_S3BucketArn { get; set; }
            public Amazon.AppStream.ScreenImageFormat AgentAccessConfig_ScreenImageFormat { get; set; }
            public Amazon.AppStream.ScreenResolution AgentAccessConfig_ScreenResolution { get; set; }
            public System.Boolean? AgentAccessConfig_ScreenshotsUploadEnabled { get; set; }
            public List<Amazon.AppStream.Model.AgentAccessSetting> AgentAccessConfig_Setting { get; set; }
            public System.Boolean? ApplicationSettings_Enabled { get; set; }
            public System.String ApplicationSettings_SettingsGroup { get; set; }
            public List<System.String> AttributesToDelete { get; set; }
            public List<System.String> ContentRedirection_HostToClient_AllowedUrl { get; set; }
            public List<System.String> ContentRedirection_HostToClient_DeniedUrl { get; set; }
            public System.Boolean? ContentRedirection_HostToClient_Enabled { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? DeleteStorageConnector { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public List<System.String> EmbedHostDomain { get; set; }
            public System.String FeedbackURL { get; set; }
            public System.String Name { get; set; }
            public System.String RedirectURL { get; set; }
            public List<Amazon.AppStream.Model.StorageConnector> StorageConnector { get; set; }
            public Amazon.AppStream.PreferredProtocol StreamingExperienceSettings_PreferredProtocol { get; set; }
            public List<Amazon.AppStream.Model.UserSetting> UserSetting { get; set; }
            public System.Func<Amazon.AppStream.Model.UpdateStackResponse, UpdateAPSStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Stack;
        }
        
    }
}
