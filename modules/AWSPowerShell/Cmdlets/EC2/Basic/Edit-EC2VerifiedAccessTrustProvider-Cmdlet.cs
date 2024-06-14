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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the configuration of the specified Amazon Web Services Verified Access trust
    /// provider.
    /// </summary>
    [Cmdlet("Edit", "EC2VerifiedAccessTrustProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VerifiedAccessTrustProvider")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVerifiedAccessTrustProvider API operation.", Operation = new[] {"ModifyVerifiedAccessTrustProvider"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VerifiedAccessTrustProvider or Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse",
        "This cmdlet returns an Amazon.EC2.Model.VerifiedAccessTrustProvider object.",
        "The service call response (type Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VerifiedAccessTrustProviderCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OidcOptions_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC authorization endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter OidcOptions_ClientId
        /// <summary>
        /// <para>
        /// <para>The client identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_ClientId { get; set; }
        #endregion
        
        #region Parameter OidcOptions_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_ClientSecret { get; set; }
        #endregion
        
        #region Parameter SseSpecification_CustomerManagedKeyEnabled
        /// <summary>
        /// <para>
        /// <para> Enable or disable the use of customer managed KMS keys for server side encryption.
        /// </para><para>Valid values: <c>True</c> | <c>False</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SseSpecification_CustomerManagedKeyEnabled { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the Verified Access trust provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OidcOptions_Issuer
        /// <summary>
        /// <para>
        /// <para>The OIDC issuer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_Issuer { get; set; }
        #endregion
        
        #region Parameter SseSpecification_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the KMS key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SseSpecification_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter DeviceOptions_PublicSigningKeyUrl
        /// <summary>
        /// <para>
        /// <para> The URL Amazon Web Services Verified Access will use to verify the authenticity of
        /// the device tokens. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceOptions_PublicSigningKeyUrl { get; set; }
        #endregion
        
        #region Parameter OidcOptions_Scope
        /// <summary>
        /// <para>
        /// <para>OpenID Connect (OIDC) scopes are used by an application during authentication to authorize
        /// access to a user's details. Each scope returns a specific set of user attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_Scope { get; set; }
        #endregion
        
        #region Parameter OidcOptions_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC token endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_TokenEndpoint { get; set; }
        #endregion
        
        #region Parameter OidcOptions_UserInfoEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC user info endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_UserInfoEndpoint { get; set; }
        #endregion
        
        #region Parameter VerifiedAccessTrustProviderId
        /// <summary>
        /// <para>
        /// <para>The ID of the Verified Access trust provider.</para>
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
        public System.String VerifiedAccessTrustProviderId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure idempotency of your modification
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VerifiedAccessTrustProvider'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VerifiedAccessTrustProvider";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VerifiedAccessTrustProviderId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VerifiedAccessTrustProviderId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VerifiedAccessTrustProviderId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VerifiedAccessTrustProviderId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VerifiedAccessTrustProvider (ModifyVerifiedAccessTrustProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse, EditEC2VerifiedAccessTrustProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VerifiedAccessTrustProviderId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DeviceOptions_PublicSigningKeyUrl = this.DeviceOptions_PublicSigningKeyUrl;
            context.OidcOptions_AuthorizationEndpoint = this.OidcOptions_AuthorizationEndpoint;
            context.OidcOptions_ClientId = this.OidcOptions_ClientId;
            context.OidcOptions_ClientSecret = this.OidcOptions_ClientSecret;
            context.OidcOptions_Issuer = this.OidcOptions_Issuer;
            context.OidcOptions_Scope = this.OidcOptions_Scope;
            context.OidcOptions_TokenEndpoint = this.OidcOptions_TokenEndpoint;
            context.OidcOptions_UserInfoEndpoint = this.OidcOptions_UserInfoEndpoint;
            context.SseSpecification_CustomerManagedKeyEnabled = this.SseSpecification_CustomerManagedKeyEnabled;
            context.SseSpecification_KmsKeyArn = this.SseSpecification_KmsKeyArn;
            context.VerifiedAccessTrustProviderId = this.VerifiedAccessTrustProviderId;
            #if MODULAR
            if (this.VerifiedAccessTrustProviderId == null && ParameterWasBound(nameof(this.VerifiedAccessTrustProviderId)))
            {
                WriteWarning("You are passing $null as a value for parameter VerifiedAccessTrustProviderId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DeviceOptions
            var requestDeviceOptionsIsNull = true;
            request.DeviceOptions = new Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderDeviceOptions();
            System.String requestDeviceOptions_deviceOptions_PublicSigningKeyUrl = null;
            if (cmdletContext.DeviceOptions_PublicSigningKeyUrl != null)
            {
                requestDeviceOptions_deviceOptions_PublicSigningKeyUrl = cmdletContext.DeviceOptions_PublicSigningKeyUrl;
            }
            if (requestDeviceOptions_deviceOptions_PublicSigningKeyUrl != null)
            {
                request.DeviceOptions.PublicSigningKeyUrl = requestDeviceOptions_deviceOptions_PublicSigningKeyUrl;
                requestDeviceOptionsIsNull = false;
            }
             // determine if request.DeviceOptions should be set to null
            if (requestDeviceOptionsIsNull)
            {
                request.DeviceOptions = null;
            }
            
             // populate OidcOptions
            var requestOidcOptionsIsNull = true;
            request.OidcOptions = new Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderOidcOptions();
            System.String requestOidcOptions_oidcOptions_AuthorizationEndpoint = null;
            if (cmdletContext.OidcOptions_AuthorizationEndpoint != null)
            {
                requestOidcOptions_oidcOptions_AuthorizationEndpoint = cmdletContext.OidcOptions_AuthorizationEndpoint;
            }
            if (requestOidcOptions_oidcOptions_AuthorizationEndpoint != null)
            {
                request.OidcOptions.AuthorizationEndpoint = requestOidcOptions_oidcOptions_AuthorizationEndpoint;
                requestOidcOptionsIsNull = false;
            }
            System.String requestOidcOptions_oidcOptions_ClientId = null;
            if (cmdletContext.OidcOptions_ClientId != null)
            {
                requestOidcOptions_oidcOptions_ClientId = cmdletContext.OidcOptions_ClientId;
            }
            if (requestOidcOptions_oidcOptions_ClientId != null)
            {
                request.OidcOptions.ClientId = requestOidcOptions_oidcOptions_ClientId;
                requestOidcOptionsIsNull = false;
            }
            System.String requestOidcOptions_oidcOptions_ClientSecret = null;
            if (cmdletContext.OidcOptions_ClientSecret != null)
            {
                requestOidcOptions_oidcOptions_ClientSecret = cmdletContext.OidcOptions_ClientSecret;
            }
            if (requestOidcOptions_oidcOptions_ClientSecret != null)
            {
                request.OidcOptions.ClientSecret = requestOidcOptions_oidcOptions_ClientSecret;
                requestOidcOptionsIsNull = false;
            }
            System.String requestOidcOptions_oidcOptions_Issuer = null;
            if (cmdletContext.OidcOptions_Issuer != null)
            {
                requestOidcOptions_oidcOptions_Issuer = cmdletContext.OidcOptions_Issuer;
            }
            if (requestOidcOptions_oidcOptions_Issuer != null)
            {
                request.OidcOptions.Issuer = requestOidcOptions_oidcOptions_Issuer;
                requestOidcOptionsIsNull = false;
            }
            System.String requestOidcOptions_oidcOptions_Scope = null;
            if (cmdletContext.OidcOptions_Scope != null)
            {
                requestOidcOptions_oidcOptions_Scope = cmdletContext.OidcOptions_Scope;
            }
            if (requestOidcOptions_oidcOptions_Scope != null)
            {
                request.OidcOptions.Scope = requestOidcOptions_oidcOptions_Scope;
                requestOidcOptionsIsNull = false;
            }
            System.String requestOidcOptions_oidcOptions_TokenEndpoint = null;
            if (cmdletContext.OidcOptions_TokenEndpoint != null)
            {
                requestOidcOptions_oidcOptions_TokenEndpoint = cmdletContext.OidcOptions_TokenEndpoint;
            }
            if (requestOidcOptions_oidcOptions_TokenEndpoint != null)
            {
                request.OidcOptions.TokenEndpoint = requestOidcOptions_oidcOptions_TokenEndpoint;
                requestOidcOptionsIsNull = false;
            }
            System.String requestOidcOptions_oidcOptions_UserInfoEndpoint = null;
            if (cmdletContext.OidcOptions_UserInfoEndpoint != null)
            {
                requestOidcOptions_oidcOptions_UserInfoEndpoint = cmdletContext.OidcOptions_UserInfoEndpoint;
            }
            if (requestOidcOptions_oidcOptions_UserInfoEndpoint != null)
            {
                request.OidcOptions.UserInfoEndpoint = requestOidcOptions_oidcOptions_UserInfoEndpoint;
                requestOidcOptionsIsNull = false;
            }
             // determine if request.OidcOptions should be set to null
            if (requestOidcOptionsIsNull)
            {
                request.OidcOptions = null;
            }
            
             // populate SseSpecification
            var requestSseSpecificationIsNull = true;
            request.SseSpecification = new Amazon.EC2.Model.VerifiedAccessSseSpecificationRequest();
            System.Boolean? requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled = null;
            if (cmdletContext.SseSpecification_CustomerManagedKeyEnabled != null)
            {
                requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled = cmdletContext.SseSpecification_CustomerManagedKeyEnabled.Value;
            }
            if (requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled != null)
            {
                request.SseSpecification.CustomerManagedKeyEnabled = requestSseSpecification_sseSpecification_CustomerManagedKeyEnabled.Value;
                requestSseSpecificationIsNull = false;
            }
            System.String requestSseSpecification_sseSpecification_KmsKeyArn = null;
            if (cmdletContext.SseSpecification_KmsKeyArn != null)
            {
                requestSseSpecification_sseSpecification_KmsKeyArn = cmdletContext.SseSpecification_KmsKeyArn;
            }
            if (requestSseSpecification_sseSpecification_KmsKeyArn != null)
            {
                request.SseSpecification.KmsKeyArn = requestSseSpecification_sseSpecification_KmsKeyArn;
                requestSseSpecificationIsNull = false;
            }
             // determine if request.SseSpecification should be set to null
            if (requestSseSpecificationIsNull)
            {
                request.SseSpecification = null;
            }
            if (cmdletContext.VerifiedAccessTrustProviderId != null)
            {
                request.VerifiedAccessTrustProviderId = cmdletContext.VerifiedAccessTrustProviderId;
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
        
        private Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVerifiedAccessTrustProvider");
            try
            {
                #if DESKTOP
                return client.ModifyVerifiedAccessTrustProvider(request);
                #elif CORECLR
                return client.ModifyVerifiedAccessTrustProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DeviceOptions_PublicSigningKeyUrl { get; set; }
            public System.String OidcOptions_AuthorizationEndpoint { get; set; }
            public System.String OidcOptions_ClientId { get; set; }
            public System.String OidcOptions_ClientSecret { get; set; }
            public System.String OidcOptions_Issuer { get; set; }
            public System.String OidcOptions_Scope { get; set; }
            public System.String OidcOptions_TokenEndpoint { get; set; }
            public System.String OidcOptions_UserInfoEndpoint { get; set; }
            public System.Boolean? SseSpecification_CustomerManagedKeyEnabled { get; set; }
            public System.String SseSpecification_KmsKeyArn { get; set; }
            public System.String VerifiedAccessTrustProviderId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVerifiedAccessTrustProviderResponse, EditEC2VerifiedAccessTrustProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VerifiedAccessTrustProvider;
        }
        
    }
}
