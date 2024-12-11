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
using Amazon.AppFabric;
using Amazon.AppFabric.Model;

namespace Amazon.PowerShell.Cmdlets.AFAB
{
    /// <summary>
    /// Updates an app authorization within an app bundle, which allows AppFabric to connect
    /// to an application.
    /// 
    ///  
    /// <para>
    /// If the app authorization was in a <c>connected</c> state, updating the app authorization
    /// will set it back to a <c>PendingConnect</c> state.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "AFABAppAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppFabric.Model.AppAuthorization")]
    [AWSCmdlet("Calls the Amazon Web Services AppFabric UpdateAppAuthorization API operation.", Operation = new[] {"UpdateAppAuthorization"}, SelectReturnType = typeof(Amazon.AppFabric.Model.UpdateAppAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.AppFabric.Model.AppAuthorization or Amazon.AppFabric.Model.UpdateAppAuthorizationResponse",
        "This cmdlet returns an Amazon.AppFabric.Model.AppAuthorization object.",
        "The service call response (type Amazon.AppFabric.Model.UpdateAppAuthorizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAFABAppAuthorizationCmdlet : AmazonAppFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiKeyCredential_ApiKey
        /// <summary>
        /// <para>
        /// <para>An API key for an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Credential_ApiKeyCredential_ApiKey")]
        public System.String ApiKeyCredential_ApiKey { get; set; }
        #endregion
        
        #region Parameter AppAuthorizationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app authorization
        /// to use for the request.</para>
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
        public System.String AppAuthorizationIdentifier { get; set; }
        #endregion
        
        #region Parameter AppBundleIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app bundle
        /// to use for the request.</para>
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
        public System.String AppBundleIdentifier { get; set; }
        #endregion
        
        #region Parameter Oauth2Credential_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID of the client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Credential_Oauth2Credential_ClientId")]
        public System.String Oauth2Credential_ClientId { get; set; }
        #endregion
        
        #region Parameter Oauth2Credential_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret of the client application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Credential_Oauth2Credential_ClientSecret")]
        public System.String Oauth2Credential_ClientSecret { get; set; }
        #endregion
        
        #region Parameter Tenant_TenantDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the tenant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Tenant_TenantDisplayName { get; set; }
        #endregion
        
        #region Parameter Tenant_TenantIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the application tenant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Tenant_TenantIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppAuthorization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppFabric.Model.UpdateAppAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.AppFabric.Model.UpdateAppAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppAuthorization";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppAuthorizationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AFABAppAuthorization (UpdateAppAuthorization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppFabric.Model.UpdateAppAuthorizationResponse, UpdateAFABAppAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppAuthorizationIdentifier = this.AppAuthorizationIdentifier;
            #if MODULAR
            if (this.AppAuthorizationIdentifier == null && ParameterWasBound(nameof(this.AppAuthorizationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppAuthorizationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppBundleIdentifier = this.AppBundleIdentifier;
            #if MODULAR
            if (this.AppBundleIdentifier == null && ParameterWasBound(nameof(this.AppBundleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBundleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiKeyCredential_ApiKey = this.ApiKeyCredential_ApiKey;
            context.Oauth2Credential_ClientId = this.Oauth2Credential_ClientId;
            context.Oauth2Credential_ClientSecret = this.Oauth2Credential_ClientSecret;
            context.Tenant_TenantDisplayName = this.Tenant_TenantDisplayName;
            context.Tenant_TenantIdentifier = this.Tenant_TenantIdentifier;
            
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
            var request = new Amazon.AppFabric.Model.UpdateAppAuthorizationRequest();
            
            if (cmdletContext.AppAuthorizationIdentifier != null)
            {
                request.AppAuthorizationIdentifier = cmdletContext.AppAuthorizationIdentifier;
            }
            if (cmdletContext.AppBundleIdentifier != null)
            {
                request.AppBundleIdentifier = cmdletContext.AppBundleIdentifier;
            }
            
             // populate Credential
            var requestCredentialIsNull = true;
            request.Credential = new Amazon.AppFabric.Model.Credential();
            Amazon.AppFabric.Model.ApiKeyCredential requestCredential_credential_ApiKeyCredential = null;
            
             // populate ApiKeyCredential
            var requestCredential_credential_ApiKeyCredentialIsNull = true;
            requestCredential_credential_ApiKeyCredential = new Amazon.AppFabric.Model.ApiKeyCredential();
            System.String requestCredential_credential_ApiKeyCredential_apiKeyCredential_ApiKey = null;
            if (cmdletContext.ApiKeyCredential_ApiKey != null)
            {
                requestCredential_credential_ApiKeyCredential_apiKeyCredential_ApiKey = cmdletContext.ApiKeyCredential_ApiKey;
            }
            if (requestCredential_credential_ApiKeyCredential_apiKeyCredential_ApiKey != null)
            {
                requestCredential_credential_ApiKeyCredential.ApiKey = requestCredential_credential_ApiKeyCredential_apiKeyCredential_ApiKey;
                requestCredential_credential_ApiKeyCredentialIsNull = false;
            }
             // determine if requestCredential_credential_ApiKeyCredential should be set to null
            if (requestCredential_credential_ApiKeyCredentialIsNull)
            {
                requestCredential_credential_ApiKeyCredential = null;
            }
            if (requestCredential_credential_ApiKeyCredential != null)
            {
                request.Credential.ApiKeyCredential = requestCredential_credential_ApiKeyCredential;
                requestCredentialIsNull = false;
            }
            Amazon.AppFabric.Model.Oauth2Credential requestCredential_credential_Oauth2Credential = null;
            
             // populate Oauth2Credential
            var requestCredential_credential_Oauth2CredentialIsNull = true;
            requestCredential_credential_Oauth2Credential = new Amazon.AppFabric.Model.Oauth2Credential();
            System.String requestCredential_credential_Oauth2Credential_oauth2Credential_ClientId = null;
            if (cmdletContext.Oauth2Credential_ClientId != null)
            {
                requestCredential_credential_Oauth2Credential_oauth2Credential_ClientId = cmdletContext.Oauth2Credential_ClientId;
            }
            if (requestCredential_credential_Oauth2Credential_oauth2Credential_ClientId != null)
            {
                requestCredential_credential_Oauth2Credential.ClientId = requestCredential_credential_Oauth2Credential_oauth2Credential_ClientId;
                requestCredential_credential_Oauth2CredentialIsNull = false;
            }
            System.String requestCredential_credential_Oauth2Credential_oauth2Credential_ClientSecret = null;
            if (cmdletContext.Oauth2Credential_ClientSecret != null)
            {
                requestCredential_credential_Oauth2Credential_oauth2Credential_ClientSecret = cmdletContext.Oauth2Credential_ClientSecret;
            }
            if (requestCredential_credential_Oauth2Credential_oauth2Credential_ClientSecret != null)
            {
                requestCredential_credential_Oauth2Credential.ClientSecret = requestCredential_credential_Oauth2Credential_oauth2Credential_ClientSecret;
                requestCredential_credential_Oauth2CredentialIsNull = false;
            }
             // determine if requestCredential_credential_Oauth2Credential should be set to null
            if (requestCredential_credential_Oauth2CredentialIsNull)
            {
                requestCredential_credential_Oauth2Credential = null;
            }
            if (requestCredential_credential_Oauth2Credential != null)
            {
                request.Credential.Oauth2Credential = requestCredential_credential_Oauth2Credential;
                requestCredentialIsNull = false;
            }
             // determine if request.Credential should be set to null
            if (requestCredentialIsNull)
            {
                request.Credential = null;
            }
            
             // populate Tenant
            var requestTenantIsNull = true;
            request.Tenant = new Amazon.AppFabric.Model.Tenant();
            System.String requestTenant_tenant_TenantDisplayName = null;
            if (cmdletContext.Tenant_TenantDisplayName != null)
            {
                requestTenant_tenant_TenantDisplayName = cmdletContext.Tenant_TenantDisplayName;
            }
            if (requestTenant_tenant_TenantDisplayName != null)
            {
                request.Tenant.TenantDisplayName = requestTenant_tenant_TenantDisplayName;
                requestTenantIsNull = false;
            }
            System.String requestTenant_tenant_TenantIdentifier = null;
            if (cmdletContext.Tenant_TenantIdentifier != null)
            {
                requestTenant_tenant_TenantIdentifier = cmdletContext.Tenant_TenantIdentifier;
            }
            if (requestTenant_tenant_TenantIdentifier != null)
            {
                request.Tenant.TenantIdentifier = requestTenant_tenant_TenantIdentifier;
                requestTenantIsNull = false;
            }
             // determine if request.Tenant should be set to null
            if (requestTenantIsNull)
            {
                request.Tenant = null;
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
        
        private Amazon.AppFabric.Model.UpdateAppAuthorizationResponse CallAWSServiceOperation(IAmazonAppFabric client, Amazon.AppFabric.Model.UpdateAppAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Web Services AppFabric", "UpdateAppAuthorization");
            try
            {
                #if DESKTOP
                return client.UpdateAppAuthorization(request);
                #elif CORECLR
                return client.UpdateAppAuthorizationAsync(request).GetAwaiter().GetResult();
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
            public System.String AppAuthorizationIdentifier { get; set; }
            public System.String AppBundleIdentifier { get; set; }
            public System.String ApiKeyCredential_ApiKey { get; set; }
            public System.String Oauth2Credential_ClientId { get; set; }
            public System.String Oauth2Credential_ClientSecret { get; set; }
            public System.String Tenant_TenantDisplayName { get; set; }
            public System.String Tenant_TenantIdentifier { get; set; }
            public System.Func<Amazon.AppFabric.Model.UpdateAppAuthorizationResponse, UpdateAFABAppAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppAuthorization;
        }
        
    }
}
