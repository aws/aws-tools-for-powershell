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
    /// Creates an app authorization within an app bundle, which allows AppFabric to connect
    /// to an application.
    /// </summary>
    [Cmdlet("New", "AFABAppAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppFabric.Model.AppAuthorization")]
    [AWSCmdlet("Calls the Amazon Web Services AppFabric CreateAppAuthorization API operation.", Operation = new[] {"CreateAppAuthorization"}, SelectReturnType = typeof(Amazon.AppFabric.Model.CreateAppAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.AppFabric.Model.AppAuthorization or Amazon.AppFabric.Model.CreateAppAuthorizationResponse",
        "This cmdlet returns an Amazon.AppFabric.Model.AppAuthorization object.",
        "The service call response (type Amazon.AppFabric.Model.CreateAppAuthorizationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAFABAppAuthorizationCmdlet : AmazonAppFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
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
        
        #region Parameter App
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para><para>Valid values are:</para><ul><li><para><c>SLACK</c></para></li><li><para><c>ASANA</c></para></li><li><para><c>JIRA</c></para></li><li><para><c>M365</c></para></li><li><para><c>M365AUDITLOGS</c></para></li><li><para><c>ZOOM</c></para></li><li><para><c>ZENDESK</c></para></li><li><para><c>OKTA</c></para></li><li><para><c>GOOGLE</c></para></li><li><para><c>DROPBOX</c></para></li><li><para><c>SMARTSHEET</c></para></li><li><para><c>CISCO</c></para></li></ul>
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
        public System.String App { get; set; }
        #endregion
        
        #region Parameter AppBundleIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app bundle
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
        public System.String AppBundleIdentifier { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The authorization type for the app authorization.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppFabric.AuthType")]
        public Amazon.AppFabric.AuthType AuthType { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of the key-value pairs of the tag or tags to assign to the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppFabric.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Tenant_TenantDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the tenant.</para>
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
        public System.String Tenant_TenantDisplayName { get; set; }
        #endregion
        
        #region Parameter Tenant_TenantIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the application tenant.</para>
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
        public System.String Tenant_TenantIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Specifies a unique, case-sensitive identifier that you provide to ensure the idempotency
        /// of the request. This lets you safely retry the request without accidentally performing
        /// the same operation a second time. Passing the same value to a later call to an operation
        /// requires that you also pass the same value for all other parameters. We recommend
        /// that you use a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID
        /// type of value</a>.</para><para>If you don't provide this value, then Amazon Web Services generates a random one for
        /// you.</para><para>If you retry the operation with the same <c>ClientToken</c>, but with different parameters,
        /// the retry fails with an <c>IdempotentParameterMismatch</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppAuthorization'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppFabric.Model.CreateAppAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.AppFabric.Model.CreateAppAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppAuthorization";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppBundleIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppBundleIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppBundleIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppBundleIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AFABAppAuthorization (CreateAppAuthorization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppFabric.Model.CreateAppAuthorizationResponse, NewAFABAppAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppBundleIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.App = this.App;
            #if MODULAR
            if (this.App == null && ParameterWasBound(nameof(this.App)))
            {
                WriteWarning("You are passing $null as a value for parameter App which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppBundleIdentifier = this.AppBundleIdentifier;
            #if MODULAR
            if (this.AppBundleIdentifier == null && ParameterWasBound(nameof(this.AppBundleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBundleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthType = this.AuthType;
            #if MODULAR
            if (this.AuthType == null && ParameterWasBound(nameof(this.AuthType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.ApiKeyCredential_ApiKey = this.ApiKeyCredential_ApiKey;
            context.Oauth2Credential_ClientId = this.Oauth2Credential_ClientId;
            context.Oauth2Credential_ClientSecret = this.Oauth2Credential_ClientSecret;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppFabric.Model.Tag>(this.Tag);
            }
            context.Tenant_TenantDisplayName = this.Tenant_TenantDisplayName;
            #if MODULAR
            if (this.Tenant_TenantDisplayName == null && ParameterWasBound(nameof(this.Tenant_TenantDisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter Tenant_TenantDisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Tenant_TenantIdentifier = this.Tenant_TenantIdentifier;
            #if MODULAR
            if (this.Tenant_TenantIdentifier == null && ParameterWasBound(nameof(this.Tenant_TenantIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Tenant_TenantIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppFabric.Model.CreateAppAuthorizationRequest();
            
            if (cmdletContext.App != null)
            {
                request.App = cmdletContext.App;
            }
            if (cmdletContext.AppBundleIdentifier != null)
            {
                request.AppBundleIdentifier = cmdletContext.AppBundleIdentifier;
            }
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.AppFabric.Model.CreateAppAuthorizationResponse CallAWSServiceOperation(IAmazonAppFabric client, Amazon.AppFabric.Model.CreateAppAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Web Services AppFabric", "CreateAppAuthorization");
            try
            {
                #if DESKTOP
                return client.CreateAppAuthorization(request);
                #elif CORECLR
                return client.CreateAppAuthorizationAsync(request).GetAwaiter().GetResult();
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
            public System.String App { get; set; }
            public System.String AppBundleIdentifier { get; set; }
            public Amazon.AppFabric.AuthType AuthType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ApiKeyCredential_ApiKey { get; set; }
            public System.String Oauth2Credential_ClientId { get; set; }
            public System.String Oauth2Credential_ClientSecret { get; set; }
            public List<Amazon.AppFabric.Model.Tag> Tag { get; set; }
            public System.String Tenant_TenantDisplayName { get; set; }
            public System.String Tenant_TenantIdentifier { get; set; }
            public System.Func<Amazon.AppFabric.Model.CreateAppAuthorizationResponse, NewAFABAppAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppAuthorization;
        }
        
    }
}
