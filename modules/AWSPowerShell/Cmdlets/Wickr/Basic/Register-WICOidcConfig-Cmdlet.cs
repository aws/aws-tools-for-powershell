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
using Amazon.Wickr;
using Amazon.Wickr.Model;

namespace Amazon.PowerShell.Cmdlets.WIC
{
    /// <summary>
    /// Registers and saves an OpenID Connect (OIDC) configuration for a Wickr network, enabling
    /// Single Sign-On (SSO) authentication through an identity provider.
    /// </summary>
    [Cmdlet("Register", "WICOidcConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Wickr.Model.RegisterOidcConfigResponse")]
    [AWSCmdlet("Calls the AWS Wickr Admin API RegisterOidcConfig API operation.", Operation = new[] {"RegisterOidcConfig"}, SelectReturnType = typeof(Amazon.Wickr.Model.RegisterOidcConfigResponse))]
    [AWSCmdletOutput("Amazon.Wickr.Model.RegisterOidcConfigResponse",
        "This cmdlet returns an Amazon.Wickr.Model.RegisterOidcConfigResponse object containing multiple properties."
    )]
    public partial class RegisterWICOidcConfigCmdlet : AmazonWickrClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CompanyId
        /// <summary>
        /// <para>
        /// <para>Custom identifier your end users will use to sign in with SSO.</para>
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
        public System.String CompanyId { get; set; }
        #endregion
        
        #region Parameter CustomUsername
        /// <summary>
        /// <para>
        /// <para>A custom field mapping to extract the username from the OIDC token (optional). </para><note><para>The customUsername is only required if you use something other than email as the username
        /// field.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomUsername { get; set; }
        #endregion
        
        #region Parameter ExtraAuthParam
        /// <summary>
        /// <para>
        /// <para>Additional authentication parameters to include in the OIDC flow (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExtraAuthParams")]
        public System.String ExtraAuthParam { get; set; }
        #endregion
        
        #region Parameter Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer URL of the OIDC provider (e.g., 'https://login.example.com').</para>
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
        public System.String Issuer { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the Wickr network for which OIDC will be configured.</para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>The OAuth scopes to request from the OIDC provider (e.g., 'openid profile email').</para>
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
        [Alias("Scopes")]
        public System.String Scope { get; set; }
        #endregion
        
        #region Parameter Secret
        /// <summary>
        /// <para>
        /// <para>The client secret for authenticating with the OIDC provider (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Secret { get; set; }
        #endregion
        
        #region Parameter SsoTokenBufferMinute
        /// <summary>
        /// <para>
        /// <para>The buffer time in minutes before the SSO token expires to refresh it (optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SsoTokenBufferMinutes")]
        public System.Int32? SsoTokenBufferMinute { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>Unique identifier provided by your identity provider to authenticate the access request.
        /// Also referred to as clientID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Wickr.Model.RegisterOidcConfigResponse).
        /// Specifying the name of a property of type Amazon.Wickr.Model.RegisterOidcConfigResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.CompanyId),
                nameof(this.NetworkId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-WICOidcConfig (RegisterOidcConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Wickr.Model.RegisterOidcConfigResponse, RegisterWICOidcConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CompanyId = this.CompanyId;
            #if MODULAR
            if (this.CompanyId == null && ParameterWasBound(nameof(this.CompanyId)))
            {
                WriteWarning("You are passing $null as a value for parameter CompanyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomUsername = this.CustomUsername;
            context.ExtraAuthParam = this.ExtraAuthParam;
            context.Issuer = this.Issuer;
            #if MODULAR
            if (this.Issuer == null && ParameterWasBound(nameof(this.Issuer)))
            {
                WriteWarning("You are passing $null as a value for parameter Issuer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Secret = this.Secret;
            context.SsoTokenBufferMinute = this.SsoTokenBufferMinute;
            context.UserId = this.UserId;
            
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
            var request = new Amazon.Wickr.Model.RegisterOidcConfigRequest();
            
            if (cmdletContext.CompanyId != null)
            {
                request.CompanyId = cmdletContext.CompanyId;
            }
            if (cmdletContext.CustomUsername != null)
            {
                request.CustomUsername = cmdletContext.CustomUsername;
            }
            if (cmdletContext.ExtraAuthParam != null)
            {
                request.ExtraAuthParams = cmdletContext.ExtraAuthParam;
            }
            if (cmdletContext.Issuer != null)
            {
                request.Issuer = cmdletContext.Issuer;
            }
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scopes = cmdletContext.Scope;
            }
            if (cmdletContext.Secret != null)
            {
                request.Secret = cmdletContext.Secret;
            }
            if (cmdletContext.SsoTokenBufferMinute != null)
            {
                request.SsoTokenBufferMinutes = cmdletContext.SsoTokenBufferMinute.Value;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.Wickr.Model.RegisterOidcConfigResponse CallAWSServiceOperation(IAmazonWickr client, Amazon.Wickr.Model.RegisterOidcConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Wickr Admin API", "RegisterOidcConfig");
            try
            {
                #if DESKTOP
                return client.RegisterOidcConfig(request);
                #elif CORECLR
                return client.RegisterOidcConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String CompanyId { get; set; }
            public System.String CustomUsername { get; set; }
            public System.String ExtraAuthParam { get; set; }
            public System.String Issuer { get; set; }
            public System.String NetworkId { get; set; }
            public System.String Scope { get; set; }
            public System.String Secret { get; set; }
            public System.Int32? SsoTokenBufferMinute { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.Wickr.Model.RegisterOidcConfigResponse, RegisterWICOidcConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
