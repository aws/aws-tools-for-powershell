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
using Amazon.IoTManagedIntegrations;
using Amazon.IoTManagedIntegrations.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTMI
{
    /// <summary>
    /// Create a connector destination for connecting a cloud-to-cloud (C2C) connector to
    /// the customer's Amazon Web Services account.
    /// </summary>
    [Cmdlet("New", "IOTMIConnectorDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management CreateConnectorDestination API operation.", Operation = new[] {"CreateConnectorDestination"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIOTMIConnectorDestinationCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SecretsManager_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Secrets Manager secret.</para>
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
        public System.String SecretsManager_Arn { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The authentication type used for the connector destination, which determines how credentials
        /// and access are managed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.AuthType")]
        public Amazon.IoTManagedIntegrations.AuthType AuthType { get; set; }
        #endregion
        
        #region Parameter OAuth_AuthUrl
        /// <summary>
        /// <para>
        /// <para>The authorization URL for the OAuth service, where users are directed to authenticate
        /// and authorize access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuth_AuthUrl")]
        public System.String OAuth_AuthUrl { get; set; }
        #endregion
        
        #region Parameter CloudConnectorId
        /// <summary>
        /// <para>
        /// <para>The identifier of the C2C connector.</para>
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
        public System.String CloudConnectorId { get; set; }
        #endregion
        
        #region Parameter ProactiveRefreshTokenRenewal_DaysBeforeRenewal
        /// <summary>
        /// <para>
        /// <para>The days before token expiration when the system should attempt to renew the token,
        /// specified in days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuth_ProactiveRefreshTokenRenewal_DaysBeforeRenewal")]
        public System.Int32? ProactiveRefreshTokenRenewal_DaysBeforeRenewal { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the connector destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ProactiveRefreshTokenRenewal_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether proactive refresh token renewal is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuth_ProactiveRefreshTokenRenewal_Enabled")]
        public System.Boolean? ProactiveRefreshTokenRenewal_Enabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name of the connector destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OAuth_OAuthCompleteRedirectUrl
        /// <summary>
        /// <para>
        /// <para>The URL where users are redirected after completing the OAuth authorization process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuth_OAuthCompleteRedirectUrl")]
        public System.String OAuth_OAuthCompleteRedirectUrl { get; set; }
        #endregion
        
        #region Parameter OAuth_Scope
        /// <summary>
        /// <para>
        /// <para>The OAuth scopes requested during authorization, which define the permissions granted
        /// to the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuth_Scope")]
        public System.String OAuth_Scope { get; set; }
        #endregion
        
        #region Parameter OAuth_TokenEndpointAuthenticationScheme
        /// <summary>
        /// <para>
        /// <para>The authentication scheme used when requesting tokens from the token endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuth_TokenEndpointAuthenticationScheme")]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.TokenEndpointAuthenticationScheme")]
        public Amazon.IoTManagedIntegrations.TokenEndpointAuthenticationScheme OAuth_TokenEndpointAuthenticationScheme { get; set; }
        #endregion
        
        #region Parameter OAuth_TokenUrl
        /// <summary>
        /// <para>
        /// <para>The token URL for the OAuth service, where authorization codes are exchanged for access
        /// tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuth_TokenUrl")]
        public System.String OAuth_TokenUrl { get; set; }
        #endregion
        
        #region Parameter SecretsManager_VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the AWS Secrets Manager secret.</para>
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
        public System.String SecretsManager_VersionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token. If you retry a request that completed successfully initially
        /// using the same client token and parameters, then the retry attempt will succeed without
        /// performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CloudConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTMIConnectorDestination (CreateConnectorDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse, NewIOTMIConnectorDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OAuth_AuthUrl = this.OAuth_AuthUrl;
            context.OAuth_OAuthCompleteRedirectUrl = this.OAuth_OAuthCompleteRedirectUrl;
            context.ProactiveRefreshTokenRenewal_DaysBeforeRenewal = this.ProactiveRefreshTokenRenewal_DaysBeforeRenewal;
            context.ProactiveRefreshTokenRenewal_Enabled = this.ProactiveRefreshTokenRenewal_Enabled;
            context.OAuth_Scope = this.OAuth_Scope;
            context.OAuth_TokenEndpointAuthenticationScheme = this.OAuth_TokenEndpointAuthenticationScheme;
            context.OAuth_TokenUrl = this.OAuth_TokenUrl;
            context.AuthType = this.AuthType;
            #if MODULAR
            if (this.AuthType == null && ParameterWasBound(nameof(this.AuthType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.CloudConnectorId = this.CloudConnectorId;
            #if MODULAR
            if (this.CloudConnectorId == null && ParameterWasBound(nameof(this.CloudConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            context.SecretsManager_Arn = this.SecretsManager_Arn;
            #if MODULAR
            if (this.SecretsManager_Arn == null && ParameterWasBound(nameof(this.SecretsManager_Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretsManager_Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretsManager_VersionId = this.SecretsManager_VersionId;
            #if MODULAR
            if (this.SecretsManager_VersionId == null && ParameterWasBound(nameof(this.SecretsManager_VersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretsManager_VersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationRequest();
            
            
             // populate AuthConfig
            request.AuthConfig = new Amazon.IoTManagedIntegrations.Model.AuthConfig();
            Amazon.IoTManagedIntegrations.Model.OAuthConfig requestAuthConfig_authConfig_OAuth = null;
            
             // populate OAuth
            var requestAuthConfig_authConfig_OAuthIsNull = true;
            requestAuthConfig_authConfig_OAuth = new Amazon.IoTManagedIntegrations.Model.OAuthConfig();
            System.String requestAuthConfig_authConfig_OAuth_oAuth_AuthUrl = null;
            if (cmdletContext.OAuth_AuthUrl != null)
            {
                requestAuthConfig_authConfig_OAuth_oAuth_AuthUrl = cmdletContext.OAuth_AuthUrl;
            }
            if (requestAuthConfig_authConfig_OAuth_oAuth_AuthUrl != null)
            {
                requestAuthConfig_authConfig_OAuth.AuthUrl = requestAuthConfig_authConfig_OAuth_oAuth_AuthUrl;
                requestAuthConfig_authConfig_OAuthIsNull = false;
            }
            System.String requestAuthConfig_authConfig_OAuth_oAuth_OAuthCompleteRedirectUrl = null;
            if (cmdletContext.OAuth_OAuthCompleteRedirectUrl != null)
            {
                requestAuthConfig_authConfig_OAuth_oAuth_OAuthCompleteRedirectUrl = cmdletContext.OAuth_OAuthCompleteRedirectUrl;
            }
            if (requestAuthConfig_authConfig_OAuth_oAuth_OAuthCompleteRedirectUrl != null)
            {
                requestAuthConfig_authConfig_OAuth.OAuthCompleteRedirectUrl = requestAuthConfig_authConfig_OAuth_oAuth_OAuthCompleteRedirectUrl;
                requestAuthConfig_authConfig_OAuthIsNull = false;
            }
            System.String requestAuthConfig_authConfig_OAuth_oAuth_Scope = null;
            if (cmdletContext.OAuth_Scope != null)
            {
                requestAuthConfig_authConfig_OAuth_oAuth_Scope = cmdletContext.OAuth_Scope;
            }
            if (requestAuthConfig_authConfig_OAuth_oAuth_Scope != null)
            {
                requestAuthConfig_authConfig_OAuth.Scope = requestAuthConfig_authConfig_OAuth_oAuth_Scope;
                requestAuthConfig_authConfig_OAuthIsNull = false;
            }
            Amazon.IoTManagedIntegrations.TokenEndpointAuthenticationScheme requestAuthConfig_authConfig_OAuth_oAuth_TokenEndpointAuthenticationScheme = null;
            if (cmdletContext.OAuth_TokenEndpointAuthenticationScheme != null)
            {
                requestAuthConfig_authConfig_OAuth_oAuth_TokenEndpointAuthenticationScheme = cmdletContext.OAuth_TokenEndpointAuthenticationScheme;
            }
            if (requestAuthConfig_authConfig_OAuth_oAuth_TokenEndpointAuthenticationScheme != null)
            {
                requestAuthConfig_authConfig_OAuth.TokenEndpointAuthenticationScheme = requestAuthConfig_authConfig_OAuth_oAuth_TokenEndpointAuthenticationScheme;
                requestAuthConfig_authConfig_OAuthIsNull = false;
            }
            System.String requestAuthConfig_authConfig_OAuth_oAuth_TokenUrl = null;
            if (cmdletContext.OAuth_TokenUrl != null)
            {
                requestAuthConfig_authConfig_OAuth_oAuth_TokenUrl = cmdletContext.OAuth_TokenUrl;
            }
            if (requestAuthConfig_authConfig_OAuth_oAuth_TokenUrl != null)
            {
                requestAuthConfig_authConfig_OAuth.TokenUrl = requestAuthConfig_authConfig_OAuth_oAuth_TokenUrl;
                requestAuthConfig_authConfig_OAuthIsNull = false;
            }
            Amazon.IoTManagedIntegrations.Model.ProactiveRefreshTokenRenewal requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal = null;
            
             // populate ProactiveRefreshTokenRenewal
            var requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewalIsNull = true;
            requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal = new Amazon.IoTManagedIntegrations.Model.ProactiveRefreshTokenRenewal();
            System.Int32? requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal = null;
            if (cmdletContext.ProactiveRefreshTokenRenewal_DaysBeforeRenewal != null)
            {
                requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal = cmdletContext.ProactiveRefreshTokenRenewal_DaysBeforeRenewal.Value;
            }
            if (requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal != null)
            {
                requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal.DaysBeforeRenewal = requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal.Value;
                requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewalIsNull = false;
            }
            System.Boolean? requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled = null;
            if (cmdletContext.ProactiveRefreshTokenRenewal_Enabled != null)
            {
                requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled = cmdletContext.ProactiveRefreshTokenRenewal_Enabled.Value;
            }
            if (requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled != null)
            {
                requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal.Enabled = requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled.Value;
                requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewalIsNull = false;
            }
             // determine if requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal should be set to null
            if (requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewalIsNull)
            {
                requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal = null;
            }
            if (requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal != null)
            {
                requestAuthConfig_authConfig_OAuth.ProactiveRefreshTokenRenewal = requestAuthConfig_authConfig_OAuth_authConfig_OAuth_ProactiveRefreshTokenRenewal;
                requestAuthConfig_authConfig_OAuthIsNull = false;
            }
             // determine if requestAuthConfig_authConfig_OAuth should be set to null
            if (requestAuthConfig_authConfig_OAuthIsNull)
            {
                requestAuthConfig_authConfig_OAuth = null;
            }
            if (requestAuthConfig_authConfig_OAuth != null)
            {
                request.AuthConfig.OAuth = requestAuthConfig_authConfig_OAuth;
            }
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CloudConnectorId != null)
            {
                request.CloudConnectorId = cmdletContext.CloudConnectorId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SecretsManager
            var requestSecretsManagerIsNull = true;
            request.SecretsManager = new Amazon.IoTManagedIntegrations.Model.SecretsManager();
            System.String requestSecretsManager_secretsManager_Arn = null;
            if (cmdletContext.SecretsManager_Arn != null)
            {
                requestSecretsManager_secretsManager_Arn = cmdletContext.SecretsManager_Arn;
            }
            if (requestSecretsManager_secretsManager_Arn != null)
            {
                request.SecretsManager.Arn = requestSecretsManager_secretsManager_Arn;
                requestSecretsManagerIsNull = false;
            }
            System.String requestSecretsManager_secretsManager_VersionId = null;
            if (cmdletContext.SecretsManager_VersionId != null)
            {
                requestSecretsManager_secretsManager_VersionId = cmdletContext.SecretsManager_VersionId;
            }
            if (requestSecretsManager_secretsManager_VersionId != null)
            {
                request.SecretsManager.VersionId = requestSecretsManager_secretsManager_VersionId;
                requestSecretsManagerIsNull = false;
            }
             // determine if request.SecretsManager should be set to null
            if (requestSecretsManagerIsNull)
            {
                request.SecretsManager = null;
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
        
        private Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "CreateConnectorDestination");
            try
            {
                return client.CreateConnectorDestinationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OAuth_AuthUrl { get; set; }
            public System.String OAuth_OAuthCompleteRedirectUrl { get; set; }
            public System.Int32? ProactiveRefreshTokenRenewal_DaysBeforeRenewal { get; set; }
            public System.Boolean? ProactiveRefreshTokenRenewal_Enabled { get; set; }
            public System.String OAuth_Scope { get; set; }
            public Amazon.IoTManagedIntegrations.TokenEndpointAuthenticationScheme OAuth_TokenEndpointAuthenticationScheme { get; set; }
            public System.String OAuth_TokenUrl { get; set; }
            public Amazon.IoTManagedIntegrations.AuthType AuthType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CloudConnectorId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String SecretsManager_Arn { get; set; }
            public System.String SecretsManager_VersionId { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.CreateConnectorDestinationResponse, NewIOTMIConnectorDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
