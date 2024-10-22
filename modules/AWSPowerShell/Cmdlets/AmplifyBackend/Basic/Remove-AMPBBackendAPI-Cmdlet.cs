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
using Amazon.AmplifyBackend;
using Amazon.AmplifyBackend.Model;

namespace Amazon.PowerShell.Cmdlets.AMPB
{
    /// <summary>
    /// Deletes an existing backend API resource.
    /// </summary>
    [Cmdlet("Remove", "AMPBBackendAPI", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse")]
    [AWSCmdlet("Calls the Amplify Backend DeleteBackendAPI API operation.", Operation = new[] {"DeleteBackendAPI"}, SelectReturnType = typeof(Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse))]
    [AWSCmdletOutput("Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse",
        "This cmdlet returns an Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveAMPBBackendAPICmdlet : AmazonAmplifyBackendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceConfig_AdditionalAuthType
        /// <summary>
        /// <para>
        /// <para>Additional authentication methods used to interact with your data models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_AdditionalAuthTypes")]
        public Amazon.AmplifyBackend.Model.BackendAPIAuthType[] ResourceConfig_AdditionalAuthType { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_ApiName
        /// <summary>
        /// <para>
        /// <para>The API name used to interact with the data model, configured as a part of your Amplify
        /// project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfig_ApiName { get; set; }
        #endregion
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The app ID.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter BackendEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment.</para>
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
        public System.String BackendEnvironmentName { get; set; }
        #endregion
        
        #region Parameter Settings_CognitoUserPoolId
        /// <summary>
        /// <para>
        /// <para>The Amazon Cognito user pool ID, if Amazon Cognito was used as an authentication setting
        /// to access your data models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_CognitoUserPoolId")]
        public System.String Settings_CognitoUserPoolId { get; set; }
        #endregion
        
        #region Parameter Settings_Description
        /// <summary>
        /// <para>
        /// <para>The API key description for API_KEY, if it was used as an authentication mechanism
        /// to access your data models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_Description")]
        public System.String Settings_Description { get; set; }
        #endregion
        
        #region Parameter Settings_ExpirationTime
        /// <summary>
        /// <para>
        /// <para>The API key expiration time for API_KEY, if it was used as an authentication mechanism
        /// to access your data models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_ExpirationTime")]
        public System.Double? Settings_ExpirationTime { get; set; }
        #endregion
        
        #region Parameter DefaultAuthType_Mode
        /// <summary>
        /// <para>
        /// <para>Describes the authentication mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Mode")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.Mode")]
        public Amazon.AmplifyBackend.Mode DefaultAuthType_Mode { get; set; }
        #endregion
        
        #region Parameter Settings_OpenIDAuthTTL
        /// <summary>
        /// <para>
        /// <para>The expiry time for the OpenID authentication mechanism.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_OpenIDAuthTTL")]
        public System.String Settings_OpenIDAuthTTL { get; set; }
        #endregion
        
        #region Parameter Settings_OpenIDClientId
        /// <summary>
        /// <para>
        /// <para>The clientID for openID, if openID was used as an authentication setting to access
        /// your data models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_OpenIDClientId")]
        public System.String Settings_OpenIDClientId { get; set; }
        #endregion
        
        #region Parameter Settings_OpenIDIatTTL
        /// <summary>
        /// <para>
        /// <para>The expiry time for the OpenID authentication mechanism.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_OpenIDIatTTL")]
        public System.String Settings_OpenIDIatTTL { get; set; }
        #endregion
        
        #region Parameter Settings_OpenIDIssueURL
        /// <summary>
        /// <para>
        /// <para>The openID issuer URL, if openID was used as an authentication setting to access your
        /// data models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_OpenIDIssueURL")]
        public System.String Settings_OpenIDIssueURL { get; set; }
        #endregion
        
        #region Parameter Settings_OpenIDProviderName
        /// <summary>
        /// <para>
        /// <para>The OpenID provider name, if OpenID was used as an authentication mechanism to access
        /// your data models.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_DefaultAuthType_Settings_OpenIDProviderName")]
        public System.String Settings_OpenIDProviderName { get; set; }
        #endregion
        
        #region Parameter ConflictResolution_ResolutionStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy for conflict resolution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_ConflictResolution_ResolutionStrategy")]
        [AWSConstantClassSource("Amazon.AmplifyBackend.ResolutionStrategy")]
        public Amazon.AmplifyBackend.ResolutionStrategy ConflictResolution_ResolutionStrategy { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of this resource.</para>
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
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_Service
        /// <summary>
        /// <para>
        /// <para>The service used to provision and interact with the data model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfig_Service { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_TransformSchema
        /// <summary>
        /// <para>
        /// <para>The definition of the data model in the annotated transform of the GraphQL schema.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceConfig_TransformSchema { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse).
        /// Specifying the name of a property of type Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AMPBBackendAPI (DeleteBackendAPI)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse, RemoveAMPBBackendAPICmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BackendEnvironmentName = this.BackendEnvironmentName;
            #if MODULAR
            if (this.BackendEnvironmentName == null && ParameterWasBound(nameof(this.BackendEnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackendEnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceConfig_AdditionalAuthType != null)
            {
                context.ResourceConfig_AdditionalAuthType = new List<Amazon.AmplifyBackend.Model.BackendAPIAuthType>(this.ResourceConfig_AdditionalAuthType);
            }
            context.ResourceConfig_ApiName = this.ResourceConfig_ApiName;
            context.ConflictResolution_ResolutionStrategy = this.ConflictResolution_ResolutionStrategy;
            context.DefaultAuthType_Mode = this.DefaultAuthType_Mode;
            context.Settings_CognitoUserPoolId = this.Settings_CognitoUserPoolId;
            context.Settings_Description = this.Settings_Description;
            context.Settings_ExpirationTime = this.Settings_ExpirationTime;
            context.Settings_OpenIDAuthTTL = this.Settings_OpenIDAuthTTL;
            context.Settings_OpenIDClientId = this.Settings_OpenIDClientId;
            context.Settings_OpenIDIatTTL = this.Settings_OpenIDIatTTL;
            context.Settings_OpenIDIssueURL = this.Settings_OpenIDIssueURL;
            context.Settings_OpenIDProviderName = this.Settings_OpenIDProviderName;
            context.ResourceConfig_Service = this.ResourceConfig_Service;
            context.ResourceConfig_TransformSchema = this.ResourceConfig_TransformSchema;
            context.ResourceName = this.ResourceName;
            #if MODULAR
            if (this.ResourceName == null && ParameterWasBound(nameof(this.ResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyBackend.Model.DeleteBackendAPIRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.BackendEnvironmentName != null)
            {
                request.BackendEnvironmentName = cmdletContext.BackendEnvironmentName;
            }
            
             // populate ResourceConfig
            var requestResourceConfigIsNull = true;
            request.ResourceConfig = new Amazon.AmplifyBackend.Model.BackendAPIResourceConfig();
            List<Amazon.AmplifyBackend.Model.BackendAPIAuthType> requestResourceConfig_resourceConfig_AdditionalAuthType = null;
            if (cmdletContext.ResourceConfig_AdditionalAuthType != null)
            {
                requestResourceConfig_resourceConfig_AdditionalAuthType = cmdletContext.ResourceConfig_AdditionalAuthType;
            }
            if (requestResourceConfig_resourceConfig_AdditionalAuthType != null)
            {
                request.ResourceConfig.AdditionalAuthTypes = requestResourceConfig_resourceConfig_AdditionalAuthType;
                requestResourceConfigIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_ApiName = null;
            if (cmdletContext.ResourceConfig_ApiName != null)
            {
                requestResourceConfig_resourceConfig_ApiName = cmdletContext.ResourceConfig_ApiName;
            }
            if (requestResourceConfig_resourceConfig_ApiName != null)
            {
                request.ResourceConfig.ApiName = requestResourceConfig_resourceConfig_ApiName;
                requestResourceConfigIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_Service = null;
            if (cmdletContext.ResourceConfig_Service != null)
            {
                requestResourceConfig_resourceConfig_Service = cmdletContext.ResourceConfig_Service;
            }
            if (requestResourceConfig_resourceConfig_Service != null)
            {
                request.ResourceConfig.Service = requestResourceConfig_resourceConfig_Service;
                requestResourceConfigIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_TransformSchema = null;
            if (cmdletContext.ResourceConfig_TransformSchema != null)
            {
                requestResourceConfig_resourceConfig_TransformSchema = cmdletContext.ResourceConfig_TransformSchema;
            }
            if (requestResourceConfig_resourceConfig_TransformSchema != null)
            {
                request.ResourceConfig.TransformSchema = requestResourceConfig_resourceConfig_TransformSchema;
                requestResourceConfigIsNull = false;
            }
            Amazon.AmplifyBackend.Model.BackendAPIConflictResolution requestResourceConfig_resourceConfig_ConflictResolution = null;
            
             // populate ConflictResolution
            var requestResourceConfig_resourceConfig_ConflictResolutionIsNull = true;
            requestResourceConfig_resourceConfig_ConflictResolution = new Amazon.AmplifyBackend.Model.BackendAPIConflictResolution();
            Amazon.AmplifyBackend.ResolutionStrategy requestResourceConfig_resourceConfig_ConflictResolution_conflictResolution_ResolutionStrategy = null;
            if (cmdletContext.ConflictResolution_ResolutionStrategy != null)
            {
                requestResourceConfig_resourceConfig_ConflictResolution_conflictResolution_ResolutionStrategy = cmdletContext.ConflictResolution_ResolutionStrategy;
            }
            if (requestResourceConfig_resourceConfig_ConflictResolution_conflictResolution_ResolutionStrategy != null)
            {
                requestResourceConfig_resourceConfig_ConflictResolution.ResolutionStrategy = requestResourceConfig_resourceConfig_ConflictResolution_conflictResolution_ResolutionStrategy;
                requestResourceConfig_resourceConfig_ConflictResolutionIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_ConflictResolution should be set to null
            if (requestResourceConfig_resourceConfig_ConflictResolutionIsNull)
            {
                requestResourceConfig_resourceConfig_ConflictResolution = null;
            }
            if (requestResourceConfig_resourceConfig_ConflictResolution != null)
            {
                request.ResourceConfig.ConflictResolution = requestResourceConfig_resourceConfig_ConflictResolution;
                requestResourceConfigIsNull = false;
            }
            Amazon.AmplifyBackend.Model.BackendAPIAuthType requestResourceConfig_resourceConfig_DefaultAuthType = null;
            
             // populate DefaultAuthType
            var requestResourceConfig_resourceConfig_DefaultAuthTypeIsNull = true;
            requestResourceConfig_resourceConfig_DefaultAuthType = new Amazon.AmplifyBackend.Model.BackendAPIAuthType();
            Amazon.AmplifyBackend.Mode requestResourceConfig_resourceConfig_DefaultAuthType_defaultAuthType_Mode = null;
            if (cmdletContext.DefaultAuthType_Mode != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_defaultAuthType_Mode = cmdletContext.DefaultAuthType_Mode;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_defaultAuthType_Mode != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType.Mode = requestResourceConfig_resourceConfig_DefaultAuthType_defaultAuthType_Mode;
                requestResourceConfig_resourceConfig_DefaultAuthTypeIsNull = false;
            }
            Amazon.AmplifyBackend.Model.BackendAPIAppSyncAuthSettings requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings = null;
            
             // populate Settings
            var requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = true;
            requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings = new Amazon.AmplifyBackend.Model.BackendAPIAppSyncAuthSettings();
            System.String requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_CognitoUserPoolId = null;
            if (cmdletContext.Settings_CognitoUserPoolId != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_CognitoUserPoolId = cmdletContext.Settings_CognitoUserPoolId;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_CognitoUserPoolId != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.CognitoUserPoolId = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_CognitoUserPoolId;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_Description = null;
            if (cmdletContext.Settings_Description != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_Description = cmdletContext.Settings_Description;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_Description != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.Description = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_Description;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
            System.Double? requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_ExpirationTime = null;
            if (cmdletContext.Settings_ExpirationTime != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_ExpirationTime = cmdletContext.Settings_ExpirationTime.Value;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_ExpirationTime != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.ExpirationTime = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_ExpirationTime.Value;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDAuthTTL = null;
            if (cmdletContext.Settings_OpenIDAuthTTL != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDAuthTTL = cmdletContext.Settings_OpenIDAuthTTL;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDAuthTTL != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.OpenIDAuthTTL = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDAuthTTL;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDClientId = null;
            if (cmdletContext.Settings_OpenIDClientId != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDClientId = cmdletContext.Settings_OpenIDClientId;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDClientId != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.OpenIDClientId = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDClientId;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIatTTL = null;
            if (cmdletContext.Settings_OpenIDIatTTL != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIatTTL = cmdletContext.Settings_OpenIDIatTTL;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIatTTL != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.OpenIDIatTTL = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIatTTL;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIssueURL = null;
            if (cmdletContext.Settings_OpenIDIssueURL != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIssueURL = cmdletContext.Settings_OpenIDIssueURL;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIssueURL != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.OpenIDIssueURL = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDIssueURL;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDProviderName = null;
            if (cmdletContext.Settings_OpenIDProviderName != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDProviderName = cmdletContext.Settings_OpenIDProviderName;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDProviderName != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings.OpenIDProviderName = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings_settings_OpenIDProviderName;
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings should be set to null
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_SettingsIsNull)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings = null;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings != null)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType.Settings = requestResourceConfig_resourceConfig_DefaultAuthType_resourceConfig_DefaultAuthType_Settings;
                requestResourceConfig_resourceConfig_DefaultAuthTypeIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_DefaultAuthType should be set to null
            if (requestResourceConfig_resourceConfig_DefaultAuthTypeIsNull)
            {
                requestResourceConfig_resourceConfig_DefaultAuthType = null;
            }
            if (requestResourceConfig_resourceConfig_DefaultAuthType != null)
            {
                request.ResourceConfig.DefaultAuthType = requestResourceConfig_resourceConfig_DefaultAuthType;
                requestResourceConfigIsNull = false;
            }
             // determine if request.ResourceConfig should be set to null
            if (requestResourceConfigIsNull)
            {
                request.ResourceConfig = null;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
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
        
        private Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse CallAWSServiceOperation(IAmazonAmplifyBackend client, Amazon.AmplifyBackend.Model.DeleteBackendAPIRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amplify Backend", "DeleteBackendAPI");
            try
            {
                #if DESKTOP
                return client.DeleteBackendAPI(request);
                #elif CORECLR
                return client.DeleteBackendAPIAsync(request).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String BackendEnvironmentName { get; set; }
            public List<Amazon.AmplifyBackend.Model.BackendAPIAuthType> ResourceConfig_AdditionalAuthType { get; set; }
            public System.String ResourceConfig_ApiName { get; set; }
            public Amazon.AmplifyBackend.ResolutionStrategy ConflictResolution_ResolutionStrategy { get; set; }
            public Amazon.AmplifyBackend.Mode DefaultAuthType_Mode { get; set; }
            public System.String Settings_CognitoUserPoolId { get; set; }
            public System.String Settings_Description { get; set; }
            public System.Double? Settings_ExpirationTime { get; set; }
            public System.String Settings_OpenIDAuthTTL { get; set; }
            public System.String Settings_OpenIDClientId { get; set; }
            public System.String Settings_OpenIDIatTTL { get; set; }
            public System.String Settings_OpenIDIssueURL { get; set; }
            public System.String Settings_OpenIDProviderName { get; set; }
            public System.String ResourceConfig_Service { get; set; }
            public System.String ResourceConfig_TransformSchema { get; set; }
            public System.String ResourceName { get; set; }
            public System.Func<Amazon.AmplifyBackend.Model.DeleteBackendAPIResponse, RemoveAMPBBackendAPICmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
