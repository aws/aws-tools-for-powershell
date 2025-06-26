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
    /// Updates the properties of an existing connector destination.
    /// </summary>
    [Cmdlet("Update", "IOTMIConnectorDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management UpdateConnectorDestination API operation.", Operation = new[] {"UpdateConnectorDestination"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationResponse))]
    [AWSCmdletOutput("None or Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTMIConnectorDestinationCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SecretsManager_Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecretsManager_Arn { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The new authentication type to use for the connector destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.AuthType")]
        public Amazon.IoTManagedIntegrations.AuthType AuthType { get; set; }
        #endregion
        
        #region Parameter ProactiveRefreshTokenRenewal_DaysBeforeRenewal
        /// <summary>
        /// <para>
        /// <para>The days before token expiration when the system should attempt to renew the token,
        /// specified in days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_DaysBeforeRenewal")]
        public System.Int32? ProactiveRefreshTokenRenewal_DaysBeforeRenewal { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description to assign to the connector destination.</para>
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
        [Alias("AuthConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_Enabled")]
        public System.Boolean? ProactiveRefreshTokenRenewal_Enabled { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the connector destination to update.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new display name to assign to the connector destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OAuthUpdate_OAuthCompleteRedirectUrl
        /// <summary>
        /// <para>
        /// <para>The updated URL where users are redirected after completing the OAuth authorization
        /// process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthConfig_OAuthUpdate_OAuthCompleteRedirectUrl")]
        public System.String OAuthUpdate_OAuthCompleteRedirectUrl { get; set; }
        #endregion
        
        #region Parameter SecretsManager_VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the AWS Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecretsManager_VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTMIConnectorDestination (UpdateConnectorDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationResponse, UpdateIOTMIConnectorDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OAuthUpdate_OAuthCompleteRedirectUrl = this.OAuthUpdate_OAuthCompleteRedirectUrl;
            context.ProactiveRefreshTokenRenewal_DaysBeforeRenewal = this.ProactiveRefreshTokenRenewal_DaysBeforeRenewal;
            context.ProactiveRefreshTokenRenewal_Enabled = this.ProactiveRefreshTokenRenewal_Enabled;
            context.AuthType = this.AuthType;
            context.Description = this.Description;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.SecretsManager_Arn = this.SecretsManager_Arn;
            context.SecretsManager_VersionId = this.SecretsManager_VersionId;
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationRequest();
            
            
             // populate AuthConfig
            var requestAuthConfigIsNull = true;
            request.AuthConfig = new Amazon.IoTManagedIntegrations.Model.AuthConfigUpdate();
            Amazon.IoTManagedIntegrations.Model.OAuthUpdate requestAuthConfig_authConfig_OAuthUpdate = null;
            
             // populate OAuthUpdate
            var requestAuthConfig_authConfig_OAuthUpdateIsNull = true;
            requestAuthConfig_authConfig_OAuthUpdate = new Amazon.IoTManagedIntegrations.Model.OAuthUpdate();
            System.String requestAuthConfig_authConfig_OAuthUpdate_oAuthUpdate_OAuthCompleteRedirectUrl = null;
            if (cmdletContext.OAuthUpdate_OAuthCompleteRedirectUrl != null)
            {
                requestAuthConfig_authConfig_OAuthUpdate_oAuthUpdate_OAuthCompleteRedirectUrl = cmdletContext.OAuthUpdate_OAuthCompleteRedirectUrl;
            }
            if (requestAuthConfig_authConfig_OAuthUpdate_oAuthUpdate_OAuthCompleteRedirectUrl != null)
            {
                requestAuthConfig_authConfig_OAuthUpdate.OAuthCompleteRedirectUrl = requestAuthConfig_authConfig_OAuthUpdate_oAuthUpdate_OAuthCompleteRedirectUrl;
                requestAuthConfig_authConfig_OAuthUpdateIsNull = false;
            }
            Amazon.IoTManagedIntegrations.Model.ProactiveRefreshTokenRenewal requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal = null;
            
             // populate ProactiveRefreshTokenRenewal
            var requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewalIsNull = true;
            requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal = new Amazon.IoTManagedIntegrations.Model.ProactiveRefreshTokenRenewal();
            System.Int32? requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal = null;
            if (cmdletContext.ProactiveRefreshTokenRenewal_DaysBeforeRenewal != null)
            {
                requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal = cmdletContext.ProactiveRefreshTokenRenewal_DaysBeforeRenewal.Value;
            }
            if (requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal != null)
            {
                requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal.DaysBeforeRenewal = requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_DaysBeforeRenewal.Value;
                requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewalIsNull = false;
            }
            System.Boolean? requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled = null;
            if (cmdletContext.ProactiveRefreshTokenRenewal_Enabled != null)
            {
                requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled = cmdletContext.ProactiveRefreshTokenRenewal_Enabled.Value;
            }
            if (requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled != null)
            {
                requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal.Enabled = requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal_proactiveRefreshTokenRenewal_Enabled.Value;
                requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewalIsNull = false;
            }
             // determine if requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal should be set to null
            if (requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewalIsNull)
            {
                requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal = null;
            }
            if (requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal != null)
            {
                requestAuthConfig_authConfig_OAuthUpdate.ProactiveRefreshTokenRenewal = requestAuthConfig_authConfig_OAuthUpdate_authConfig_OAuthUpdate_ProactiveRefreshTokenRenewal;
                requestAuthConfig_authConfig_OAuthUpdateIsNull = false;
            }
             // determine if requestAuthConfig_authConfig_OAuthUpdate should be set to null
            if (requestAuthConfig_authConfig_OAuthUpdateIsNull)
            {
                requestAuthConfig_authConfig_OAuthUpdate = null;
            }
            if (requestAuthConfig_authConfig_OAuthUpdate != null)
            {
                request.AuthConfig.OAuthUpdate = requestAuthConfig_authConfig_OAuthUpdate;
                requestAuthConfigIsNull = false;
            }
             // determine if request.AuthConfig should be set to null
            if (requestAuthConfigIsNull)
            {
                request.AuthConfig = null;
            }
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
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
        
        private Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "UpdateConnectorDestination");
            try
            {
                return client.UpdateConnectorDestinationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String OAuthUpdate_OAuthCompleteRedirectUrl { get; set; }
            public System.Int32? ProactiveRefreshTokenRenewal_DaysBeforeRenewal { get; set; }
            public System.Boolean? ProactiveRefreshTokenRenewal_Enabled { get; set; }
            public Amazon.IoTManagedIntegrations.AuthType AuthType { get; set; }
            public System.String Description { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.String SecretsManager_Arn { get; set; }
            public System.String SecretsManager_VersionId { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.UpdateConnectorDestinationResponse, UpdateIOTMIConnectorDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
