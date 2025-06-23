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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// A trust provider is a third-party entity that creates, maintains, and manages identity
    /// information for users and devices. When an application request is made, the identity
    /// information sent by the trust provider is evaluated by Verified Access before allowing
    /// or denying the application request.
    /// </summary>
    [Cmdlet("New", "EC2VerifiedAccessTrustProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VerifiedAccessTrustProvider")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVerifiedAccessTrustProvider API operation.", Operation = new[] {"CreateVerifiedAccessTrustProvider"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VerifiedAccessTrustProvider or Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse",
        "This cmdlet returns an Amazon.EC2.Model.VerifiedAccessTrustProvider object.",
        "The service call response (type Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2VerifiedAccessTrustProviderCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NativeApplicationOidcOptions_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The authorization endpoint of the IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter OidcOptions_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The OIDC authorization endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OidcOptions_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter NativeApplicationOidcOptions_ClientId
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 client identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_ClientId { get; set; }
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
        
        #region Parameter NativeApplicationOidcOptions_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The OAuth 2.0 client secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_ClientSecret { get; set; }
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
        
        #region Parameter DeviceTrustProviderType
        /// <summary>
        /// <para>
        /// <para>The type of device-based trust provider. This parameter is required when the provider
        /// type is <c>device</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DeviceTrustProviderType")]
        public Amazon.EC2.DeviceTrustProviderType DeviceTrustProviderType { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter NativeApplicationOidcOptions_Issuer
        /// <summary>
        /// <para>
        /// <para>The OIDC issuer identifier of the IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_Issuer { get; set; }
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
        
        #region Parameter PolicyReferenceName
        /// <summary>
        /// <para>
        /// <para>The identifier to be used when working with policy rules.</para>
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
        public System.String PolicyReferenceName { get; set; }
        #endregion
        
        #region Parameter NativeApplicationOidcOptions_PublicSigningKeyEndpoint
        /// <summary>
        /// <para>
        /// <para>The public signing key endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_PublicSigningKeyEndpoint { get; set; }
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
        
        #region Parameter NativeApplicationOidcOptions_Scope
        /// <summary>
        /// <para>
        /// <para>The set of user claims to be requested from the IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_Scope { get; set; }
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
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the Verified Access trust provider.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter DeviceOptions_TenantId
        /// <summary>
        /// <para>
        /// <para>The ID of the tenant application with the device-identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceOptions_TenantId { get; set; }
        #endregion
        
        #region Parameter NativeApplicationOidcOptions_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>The token endpoint of the IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_TokenEndpoint { get; set; }
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
        
        #region Parameter TrustProviderType
        /// <summary>
        /// <para>
        /// <para>The type of trust provider.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.TrustProviderType")]
        public Amazon.EC2.TrustProviderType TrustProviderType { get; set; }
        #endregion
        
        #region Parameter NativeApplicationOidcOptions_UserInfoEndpoint
        /// <summary>
        /// <para>
        /// <para>The user info endpoint of the IdP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NativeApplicationOidcOptions_UserInfoEndpoint { get; set; }
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
        
        #region Parameter UserTrustProviderType
        /// <summary>
        /// <para>
        /// <para>The type of user-based trust provider. This parameter is required when the provider
        /// type is <c>user</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.UserTrustProviderType")]
        public Amazon.EC2.UserTrustProviderType UserTrustProviderType { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VerifiedAccessTrustProvider";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyReferenceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2VerifiedAccessTrustProvider (CreateVerifiedAccessTrustProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse, NewEC2VerifiedAccessTrustProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DeviceOptions_PublicSigningKeyUrl = this.DeviceOptions_PublicSigningKeyUrl;
            context.DeviceOptions_TenantId = this.DeviceOptions_TenantId;
            context.DeviceTrustProviderType = this.DeviceTrustProviderType;
            context.DryRun = this.DryRun;
            context.NativeApplicationOidcOptions_AuthorizationEndpoint = this.NativeApplicationOidcOptions_AuthorizationEndpoint;
            context.NativeApplicationOidcOptions_ClientId = this.NativeApplicationOidcOptions_ClientId;
            context.NativeApplicationOidcOptions_ClientSecret = this.NativeApplicationOidcOptions_ClientSecret;
            context.NativeApplicationOidcOptions_Issuer = this.NativeApplicationOidcOptions_Issuer;
            context.NativeApplicationOidcOptions_PublicSigningKeyEndpoint = this.NativeApplicationOidcOptions_PublicSigningKeyEndpoint;
            context.NativeApplicationOidcOptions_Scope = this.NativeApplicationOidcOptions_Scope;
            context.NativeApplicationOidcOptions_TokenEndpoint = this.NativeApplicationOidcOptions_TokenEndpoint;
            context.NativeApplicationOidcOptions_UserInfoEndpoint = this.NativeApplicationOidcOptions_UserInfoEndpoint;
            context.OidcOptions_AuthorizationEndpoint = this.OidcOptions_AuthorizationEndpoint;
            context.OidcOptions_ClientId = this.OidcOptions_ClientId;
            context.OidcOptions_ClientSecret = this.OidcOptions_ClientSecret;
            context.OidcOptions_Issuer = this.OidcOptions_Issuer;
            context.OidcOptions_Scope = this.OidcOptions_Scope;
            context.OidcOptions_TokenEndpoint = this.OidcOptions_TokenEndpoint;
            context.OidcOptions_UserInfoEndpoint = this.OidcOptions_UserInfoEndpoint;
            context.PolicyReferenceName = this.PolicyReferenceName;
            #if MODULAR
            if (this.PolicyReferenceName == null && ParameterWasBound(nameof(this.PolicyReferenceName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyReferenceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SseSpecification_CustomerManagedKeyEnabled = this.SseSpecification_CustomerManagedKeyEnabled;
            context.SseSpecification_KmsKeyArn = this.SseSpecification_KmsKeyArn;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TrustProviderType = this.TrustProviderType;
            #if MODULAR
            if (this.TrustProviderType == null && ParameterWasBound(nameof(this.TrustProviderType)))
            {
                WriteWarning("You are passing $null as a value for parameter TrustProviderType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserTrustProviderType = this.UserTrustProviderType;
            
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
            var request = new Amazon.EC2.Model.CreateVerifiedAccessTrustProviderRequest();
            
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
            request.DeviceOptions = new Amazon.EC2.Model.CreateVerifiedAccessTrustProviderDeviceOptions();
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
            System.String requestDeviceOptions_deviceOptions_TenantId = null;
            if (cmdletContext.DeviceOptions_TenantId != null)
            {
                requestDeviceOptions_deviceOptions_TenantId = cmdletContext.DeviceOptions_TenantId;
            }
            if (requestDeviceOptions_deviceOptions_TenantId != null)
            {
                request.DeviceOptions.TenantId = requestDeviceOptions_deviceOptions_TenantId;
                requestDeviceOptionsIsNull = false;
            }
             // determine if request.DeviceOptions should be set to null
            if (requestDeviceOptionsIsNull)
            {
                request.DeviceOptions = null;
            }
            if (cmdletContext.DeviceTrustProviderType != null)
            {
                request.DeviceTrustProviderType = cmdletContext.DeviceTrustProviderType;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            
             // populate NativeApplicationOidcOptions
            var requestNativeApplicationOidcOptionsIsNull = true;
            request.NativeApplicationOidcOptions = new Amazon.EC2.Model.CreateVerifiedAccessNativeApplicationOidcOptions();
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_AuthorizationEndpoint = null;
            if (cmdletContext.NativeApplicationOidcOptions_AuthorizationEndpoint != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_AuthorizationEndpoint = cmdletContext.NativeApplicationOidcOptions_AuthorizationEndpoint;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_AuthorizationEndpoint != null)
            {
                request.NativeApplicationOidcOptions.AuthorizationEndpoint = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_AuthorizationEndpoint;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientId = null;
            if (cmdletContext.NativeApplicationOidcOptions_ClientId != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientId = cmdletContext.NativeApplicationOidcOptions_ClientId;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientId != null)
            {
                request.NativeApplicationOidcOptions.ClientId = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientId;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientSecret = null;
            if (cmdletContext.NativeApplicationOidcOptions_ClientSecret != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientSecret = cmdletContext.NativeApplicationOidcOptions_ClientSecret;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientSecret != null)
            {
                request.NativeApplicationOidcOptions.ClientSecret = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_ClientSecret;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Issuer = null;
            if (cmdletContext.NativeApplicationOidcOptions_Issuer != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Issuer = cmdletContext.NativeApplicationOidcOptions_Issuer;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Issuer != null)
            {
                request.NativeApplicationOidcOptions.Issuer = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Issuer;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_PublicSigningKeyEndpoint = null;
            if (cmdletContext.NativeApplicationOidcOptions_PublicSigningKeyEndpoint != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_PublicSigningKeyEndpoint = cmdletContext.NativeApplicationOidcOptions_PublicSigningKeyEndpoint;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_PublicSigningKeyEndpoint != null)
            {
                request.NativeApplicationOidcOptions.PublicSigningKeyEndpoint = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_PublicSigningKeyEndpoint;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Scope = null;
            if (cmdletContext.NativeApplicationOidcOptions_Scope != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Scope = cmdletContext.NativeApplicationOidcOptions_Scope;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Scope != null)
            {
                request.NativeApplicationOidcOptions.Scope = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_Scope;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_TokenEndpoint = null;
            if (cmdletContext.NativeApplicationOidcOptions_TokenEndpoint != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_TokenEndpoint = cmdletContext.NativeApplicationOidcOptions_TokenEndpoint;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_TokenEndpoint != null)
            {
                request.NativeApplicationOidcOptions.TokenEndpoint = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_TokenEndpoint;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
            System.String requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_UserInfoEndpoint = null;
            if (cmdletContext.NativeApplicationOidcOptions_UserInfoEndpoint != null)
            {
                requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_UserInfoEndpoint = cmdletContext.NativeApplicationOidcOptions_UserInfoEndpoint;
            }
            if (requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_UserInfoEndpoint != null)
            {
                request.NativeApplicationOidcOptions.UserInfoEndpoint = requestNativeApplicationOidcOptions_nativeApplicationOidcOptions_UserInfoEndpoint;
                requestNativeApplicationOidcOptionsIsNull = false;
            }
             // determine if request.NativeApplicationOidcOptions should be set to null
            if (requestNativeApplicationOidcOptionsIsNull)
            {
                request.NativeApplicationOidcOptions = null;
            }
            
             // populate OidcOptions
            var requestOidcOptionsIsNull = true;
            request.OidcOptions = new Amazon.EC2.Model.CreateVerifiedAccessTrustProviderOidcOptions();
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
            if (cmdletContext.PolicyReferenceName != null)
            {
                request.PolicyReferenceName = cmdletContext.PolicyReferenceName;
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
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TrustProviderType != null)
            {
                request.TrustProviderType = cmdletContext.TrustProviderType;
            }
            if (cmdletContext.UserTrustProviderType != null)
            {
                request.UserTrustProviderType = cmdletContext.UserTrustProviderType;
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
        
        private Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVerifiedAccessTrustProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVerifiedAccessTrustProvider");
            try
            {
                return client.CreateVerifiedAccessTrustProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DeviceOptions_TenantId { get; set; }
            public Amazon.EC2.DeviceTrustProviderType DeviceTrustProviderType { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String NativeApplicationOidcOptions_AuthorizationEndpoint { get; set; }
            public System.String NativeApplicationOidcOptions_ClientId { get; set; }
            public System.String NativeApplicationOidcOptions_ClientSecret { get; set; }
            public System.String NativeApplicationOidcOptions_Issuer { get; set; }
            public System.String NativeApplicationOidcOptions_PublicSigningKeyEndpoint { get; set; }
            public System.String NativeApplicationOidcOptions_Scope { get; set; }
            public System.String NativeApplicationOidcOptions_TokenEndpoint { get; set; }
            public System.String NativeApplicationOidcOptions_UserInfoEndpoint { get; set; }
            public System.String OidcOptions_AuthorizationEndpoint { get; set; }
            public System.String OidcOptions_ClientId { get; set; }
            public System.String OidcOptions_ClientSecret { get; set; }
            public System.String OidcOptions_Issuer { get; set; }
            public System.String OidcOptions_Scope { get; set; }
            public System.String OidcOptions_TokenEndpoint { get; set; }
            public System.String OidcOptions_UserInfoEndpoint { get; set; }
            public System.String PolicyReferenceName { get; set; }
            public System.Boolean? SseSpecification_CustomerManagedKeyEnabled { get; set; }
            public System.String SseSpecification_KmsKeyArn { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.TrustProviderType TrustProviderType { get; set; }
            public Amazon.EC2.UserTrustProviderType UserTrustProviderType { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVerifiedAccessTrustProviderResponse, NewEC2VerifiedAccessTrustProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VerifiedAccessTrustProvider;
        }
        
    }
}
