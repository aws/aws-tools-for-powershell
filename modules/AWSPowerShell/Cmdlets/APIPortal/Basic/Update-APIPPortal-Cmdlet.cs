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
using Amazon.APIPortal;
using Amazon.APIPortal.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APIP
{
    /// <summary>
    /// Updates a portal. Only the fields supplied in the request are changed.
    /// </summary>
    [Cmdlet("Update", "APIPPortal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIPortal.Model.UpdatePortalResponse")]
    [AWSCmdlet("Calls the APIPortal UpdatePortal API operation.", Operation = new[] {"UpdatePortal"}, SelectReturnType = typeof(Amazon.APIPortal.Model.UpdatePortalResponse))]
    [AWSCmdletOutput("Amazon.APIPortal.Model.UpdatePortalResponse",
        "This cmdlet returns an Amazon.APIPortal.Model.UpdatePortalResponse object containing multiple properties."
    )]
    public partial class UpdateAPIPPortalCmdlet : AmazonAPIPortalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PortalContent_Theme_CustomColors_AccentColor
        /// <summary>
        /// <para>
        /// The color of links, buttons, and other highlighted
        /// elements.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Theme_CustomColors_AccentColor { get; set; }
        #endregion
        
        #region Parameter Authorization_AuthorizationConfig_CognitoConfig_AppClientId
        /// <summary>
        /// <para>
        /// The ID of the user pool app client the portal
        /// uses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authorization_AuthorizationConfig_CognitoConfig_AppClientId { get; set; }
        #endregion
        
        #region Parameter PortalContent_Theme_CustomColors_BackgroundColor
        /// <summary>
        /// <para>
        /// The page background color.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Theme_CustomColors_BackgroundColor { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_AcmManaged_CertificateArn
        /// <summary>
        /// <para>
        /// The ARN of the ACM certificate for the
        /// domain. The certificate must be in us-east-1, issued, not private, and must cover
        /// the domain name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointConfiguration_AcmManaged_CertificateArn { get; set; }
        #endregion
        
        #region Parameter PortalContent_Description
        /// <summary>
        /// <para>
        /// A description of the portal, up to 1024 characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Description { get; set; }
        #endregion
        
        #region Parameter PortalContent_DisplayName
        /// <summary>
        /// <para>
        /// The name shown in the portal, from 3 to 255
        /// characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_DisplayName { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_AcmManaged_DomainName
        /// <summary>
        /// <para>
        /// The custom domain name for the portal.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointConfiguration_AcmManaged_DomainName { get; set; }
        #endregion
        
        #region Parameter PortalContent_Theme_CustomColors_ErrorValidationColor
        /// <summary>
        /// <para>
        /// The color of error and validation
        /// messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Theme_CustomColors_ErrorValidationColor { get; set; }
        #endregion
        
        #region Parameter Authorization_FineGrainedAccessControl
        /// <summary>
        /// <para>
        /// Whether access to individual
        /// products in the portal is controlled per reader.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIPortal.FineGrainedAccessControl")]
        public Amazon.APIPortal.FineGrainedAccessControl Authorization_FineGrainedAccessControl { get; set; }
        #endregion
        
        #region Parameter PortalContent_Theme_CustomColors_HeaderColor
        /// <summary>
        /// <para>
        /// The header color.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Theme_CustomColors_HeaderColor { get; set; }
        #endregion
        
        #region Parameter Authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId
        /// <summary>
        /// <para>
        /// The ID of the Cognito identity pool. Required
        /// only for fine-grained access control.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId { get; set; }
        #endregion
        
        #region Parameter IncludedProductArn
        /// <summary>
        /// <para>
        /// The new list of product ARNs, up to
        /// 200. It replaces the current list. Omit it to keep the current list.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludedProductArns")]
        public System.String[] IncludedProductArn { get; set; }
        #endregion
        
        #region Parameter PortalContent_Theme_LogoUploadedAt
        /// <summary>
        /// <para>
        /// When the portal logo was last uploaded.
        /// Absent if the portal has no logo.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PortalContent_Theme_LogoUploadedAt { get; set; }
        #endregion
        
        #region Parameter LogoUri
        /// <summary>
        /// <para>
        /// The new S3 location of the portal logo, in the
        /// form `s3://bucket/key`. An empty string removes the logo. Omit it to keep the current
        /// logo.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogoUri { get; set; }
        #endregion
        
        #region Parameter PortalContent_Theme_CustomColors_NavigationColor
        /// <summary>
        /// <para>
        /// The navigation pane color.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Theme_CustomColors_NavigationColor { get; set; }
        #endregion
        
        #region Parameter Authorization_AuthorizationConfig_None
        /// <summary>
        /// <para>
        /// The portal is public and readers do not sign in.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.APIPortal.Model.None Authorization_AuthorizationConfig_None { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_None
        /// <summary>
        /// <para>
        /// Serve the portal only on its default domain.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.APIPortal.Model.None EndpointConfiguration_None { get; set; }
        #endregion
        
        #region Parameter PortalId
        /// <summary>
        /// <para>
        /// The identifier of the portal.
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
        public System.String PortalId { get; set; }
        #endregion
        
        #region Parameter RumAppMonitorName
        /// <summary>
        /// <para>
        /// The new CloudWatch RUM app monitor name.
        /// Omit it to keep the current value.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RumAppMonitorName { get; set; }
        #endregion
        
        #region Parameter PortalContent_Theme_CustomColors_TextColor
        /// <summary>
        /// <para>
        /// The text color.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Theme_CustomColors_TextColor { get; set; }
        #endregion
        
        #region Parameter Authorization_AuthorizationConfig_CognitoConfig_UserPoolArn
        /// <summary>
        /// <para>
        /// The ARN of the Cognito user pool.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authorization_AuthorizationConfig_CognitoConfig_UserPoolArn { get; set; }
        #endregion
        
        #region Parameter Authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain
        /// <summary>
        /// <para>
        /// The domain of the user pool's hosted sign-in
        /// pages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIPortal.Model.UpdatePortalResponse).
        /// Specifying the name of a property of type Amazon.APIPortal.Model.UpdatePortalResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortalId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APIPPortal (UpdatePortal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIPortal.Model.UpdatePortalResponse, UpdateAPIPPortalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Authorization_AuthorizationConfig_CognitoConfig_AppClientId = this.Authorization_AuthorizationConfig_CognitoConfig_AppClientId;
            context.Authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId = this.Authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId;
            context.Authorization_AuthorizationConfig_CognitoConfig_UserPoolArn = this.Authorization_AuthorizationConfig_CognitoConfig_UserPoolArn;
            context.Authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain = this.Authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain;
            context.Authorization_AuthorizationConfig_None = this.Authorization_AuthorizationConfig_None;
            context.Authorization_FineGrainedAccessControl = this.Authorization_FineGrainedAccessControl;
            context.EndpointConfiguration_AcmManaged_CertificateArn = this.EndpointConfiguration_AcmManaged_CertificateArn;
            context.EndpointConfiguration_AcmManaged_DomainName = this.EndpointConfiguration_AcmManaged_DomainName;
            context.EndpointConfiguration_None = this.EndpointConfiguration_None;
            if (this.IncludedProductArn != null)
            {
                context.IncludedProductArn = new List<System.String>(this.IncludedProductArn);
            }
            context.LogoUri = this.LogoUri;
            context.PortalContent_Description = this.PortalContent_Description;
            context.PortalContent_DisplayName = this.PortalContent_DisplayName;
            context.PortalContent_Theme_CustomColors_AccentColor = this.PortalContent_Theme_CustomColors_AccentColor;
            context.PortalContent_Theme_CustomColors_BackgroundColor = this.PortalContent_Theme_CustomColors_BackgroundColor;
            context.PortalContent_Theme_CustomColors_ErrorValidationColor = this.PortalContent_Theme_CustomColors_ErrorValidationColor;
            context.PortalContent_Theme_CustomColors_HeaderColor = this.PortalContent_Theme_CustomColors_HeaderColor;
            context.PortalContent_Theme_CustomColors_NavigationColor = this.PortalContent_Theme_CustomColors_NavigationColor;
            context.PortalContent_Theme_CustomColors_TextColor = this.PortalContent_Theme_CustomColors_TextColor;
            context.PortalContent_Theme_LogoUploadedAt = this.PortalContent_Theme_LogoUploadedAt;
            context.PortalId = this.PortalId;
            #if MODULAR
            if (this.PortalId == null && ParameterWasBound(nameof(this.PortalId)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RumAppMonitorName = this.RumAppMonitorName;
            
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
            var request = new Amazon.APIPortal.Model.UpdatePortalRequest();
            
            
             // populate Authorization
            var requestAuthorizationIsNull = true;
            request.Authorization = new Amazon.APIPortal.Model.Authorization();
            Amazon.APIPortal.FineGrainedAccessControl requestAuthorization_authorization_FineGrainedAccessControl = null;
            if (cmdletContext.Authorization_FineGrainedAccessControl != null)
            {
                requestAuthorization_authorization_FineGrainedAccessControl = cmdletContext.Authorization_FineGrainedAccessControl;
            }
            if (requestAuthorization_authorization_FineGrainedAccessControl != null)
            {
                request.Authorization.FineGrainedAccessControl = requestAuthorization_authorization_FineGrainedAccessControl;
                requestAuthorizationIsNull = false;
            }
            Amazon.APIPortal.Model.AuthorizationConfig requestAuthorization_authorization_AuthorizationConfig = null;
            
             // populate AuthorizationConfig
            var requestAuthorization_authorization_AuthorizationConfigIsNull = true;
            requestAuthorization_authorization_AuthorizationConfig = new Amazon.APIPortal.Model.AuthorizationConfig();
            Amazon.APIPortal.Model.None requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_None = null;
            if (cmdletContext.Authorization_AuthorizationConfig_None != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_None = cmdletContext.Authorization_AuthorizationConfig_None;
            }
            if (requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_None != null)
            {
                requestAuthorization_authorization_AuthorizationConfig.None = requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_None;
                requestAuthorization_authorization_AuthorizationConfigIsNull = false;
            }
            Amazon.APIPortal.Model.CognitoConfig requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig = null;
            
             // populate CognitoConfig
            var requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfigIsNull = true;
            requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig = new Amazon.APIPortal.Model.CognitoConfig();
            System.String requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_AppClientId = null;
            if (cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_AppClientId != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_AppClientId = cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_AppClientId;
            }
            if (requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_AppClientId != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig.AppClientId = requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_AppClientId;
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfigIsNull = false;
            }
            System.String requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId = null;
            if (cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId = cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId;
            }
            if (requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig.IdentityPoolId = requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId;
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfigIsNull = false;
            }
            System.String requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolArn = null;
            if (cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_UserPoolArn != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolArn = cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_UserPoolArn;
            }
            if (requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolArn != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig.UserPoolArn = requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolArn;
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfigIsNull = false;
            }
            System.String requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain = null;
            if (cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain = cmdletContext.Authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain;
            }
            if (requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain != null)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig.UserPoolDomain = requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig_authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain;
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfigIsNull = false;
            }
             // determine if requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig should be set to null
            if (requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfigIsNull)
            {
                requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig = null;
            }
            if (requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig != null)
            {
                requestAuthorization_authorization_AuthorizationConfig.CognitoConfig = requestAuthorization_authorization_AuthorizationConfig_authorization_AuthorizationConfig_CognitoConfig;
                requestAuthorization_authorization_AuthorizationConfigIsNull = false;
            }
             // determine if requestAuthorization_authorization_AuthorizationConfig should be set to null
            if (requestAuthorization_authorization_AuthorizationConfigIsNull)
            {
                requestAuthorization_authorization_AuthorizationConfig = null;
            }
            if (requestAuthorization_authorization_AuthorizationConfig != null)
            {
                request.Authorization.AuthorizationConfig = requestAuthorization_authorization_AuthorizationConfig;
                requestAuthorizationIsNull = false;
            }
             // determine if request.Authorization should be set to null
            if (requestAuthorizationIsNull)
            {
                request.Authorization = null;
            }
            
             // populate EndpointConfiguration
            var requestEndpointConfigurationIsNull = true;
            request.EndpointConfiguration = new Amazon.APIPortal.Model.EndpointConfigurationRequest();
            Amazon.APIPortal.Model.None requestEndpointConfiguration_endpointConfiguration_None = null;
            if (cmdletContext.EndpointConfiguration_None != null)
            {
                requestEndpointConfiguration_endpointConfiguration_None = cmdletContext.EndpointConfiguration_None;
            }
            if (requestEndpointConfiguration_endpointConfiguration_None != null)
            {
                request.EndpointConfiguration.None = requestEndpointConfiguration_endpointConfiguration_None;
                requestEndpointConfigurationIsNull = false;
            }
            Amazon.APIPortal.Model.ACMManaged requestEndpointConfiguration_endpointConfiguration_AcmManaged = null;
            
             // populate AcmManaged
            var requestEndpointConfiguration_endpointConfiguration_AcmManagedIsNull = true;
            requestEndpointConfiguration_endpointConfiguration_AcmManaged = new Amazon.APIPortal.Model.ACMManaged();
            System.String requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_CertificateArn = null;
            if (cmdletContext.EndpointConfiguration_AcmManaged_CertificateArn != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_CertificateArn = cmdletContext.EndpointConfiguration_AcmManaged_CertificateArn;
            }
            if (requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_CertificateArn != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged.CertificateArn = requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_CertificateArn;
                requestEndpointConfiguration_endpointConfiguration_AcmManagedIsNull = false;
            }
            System.String requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_DomainName = null;
            if (cmdletContext.EndpointConfiguration_AcmManaged_DomainName != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_DomainName = cmdletContext.EndpointConfiguration_AcmManaged_DomainName;
            }
            if (requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_DomainName != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged.DomainName = requestEndpointConfiguration_endpointConfiguration_AcmManaged_endpointConfiguration_AcmManaged_DomainName;
                requestEndpointConfiguration_endpointConfiguration_AcmManagedIsNull = false;
            }
             // determine if requestEndpointConfiguration_endpointConfiguration_AcmManaged should be set to null
            if (requestEndpointConfiguration_endpointConfiguration_AcmManagedIsNull)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged = null;
            }
            if (requestEndpointConfiguration_endpointConfiguration_AcmManaged != null)
            {
                request.EndpointConfiguration.AcmManaged = requestEndpointConfiguration_endpointConfiguration_AcmManaged;
                requestEndpointConfigurationIsNull = false;
            }
             // determine if request.EndpointConfiguration should be set to null
            if (requestEndpointConfigurationIsNull)
            {
                request.EndpointConfiguration = null;
            }
            if (cmdletContext.IncludedProductArn != null)
            {
                request.IncludedProductArns = cmdletContext.IncludedProductArn;
            }
            if (cmdletContext.LogoUri != null)
            {
                request.LogoUri = cmdletContext.LogoUri;
            }
            
             // populate PortalContent
            var requestPortalContentIsNull = true;
            request.PortalContent = new Amazon.APIPortal.Model.PortalContent();
            System.String requestPortalContent_portalContent_Description = null;
            if (cmdletContext.PortalContent_Description != null)
            {
                requestPortalContent_portalContent_Description = cmdletContext.PortalContent_Description;
            }
            if (requestPortalContent_portalContent_Description != null)
            {
                request.PortalContent.Description = requestPortalContent_portalContent_Description;
                requestPortalContentIsNull = false;
            }
            System.String requestPortalContent_portalContent_DisplayName = null;
            if (cmdletContext.PortalContent_DisplayName != null)
            {
                requestPortalContent_portalContent_DisplayName = cmdletContext.PortalContent_DisplayName;
            }
            if (requestPortalContent_portalContent_DisplayName != null)
            {
                request.PortalContent.DisplayName = requestPortalContent_portalContent_DisplayName;
                requestPortalContentIsNull = false;
            }
            Amazon.APIPortal.Model.PortalTheme requestPortalContent_portalContent_Theme = null;
            
             // populate Theme
            var requestPortalContent_portalContent_ThemeIsNull = true;
            requestPortalContent_portalContent_Theme = new Amazon.APIPortal.Model.PortalTheme();
            System.DateTime? requestPortalContent_portalContent_Theme_portalContent_Theme_LogoUploadedAt = null;
            if (cmdletContext.PortalContent_Theme_LogoUploadedAt != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_LogoUploadedAt = cmdletContext.PortalContent_Theme_LogoUploadedAt.Value;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_LogoUploadedAt != null)
            {
                requestPortalContent_portalContent_Theme.LogoUploadedAt = requestPortalContent_portalContent_Theme_portalContent_Theme_LogoUploadedAt.Value;
                requestPortalContent_portalContent_ThemeIsNull = false;
            }
            Amazon.APIPortal.Model.CustomColors requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors = null;
            
             // populate CustomColors
            var requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = true;
            requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors = new Amazon.APIPortal.Model.CustomColors();
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_AccentColor = null;
            if (cmdletContext.PortalContent_Theme_CustomColors_AccentColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_AccentColor = cmdletContext.PortalContent_Theme_CustomColors_AccentColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_AccentColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.AccentColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_AccentColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_BackgroundColor = null;
            if (cmdletContext.PortalContent_Theme_CustomColors_BackgroundColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_BackgroundColor = cmdletContext.PortalContent_Theme_CustomColors_BackgroundColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_BackgroundColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.BackgroundColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_BackgroundColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_ErrorValidationColor = null;
            if (cmdletContext.PortalContent_Theme_CustomColors_ErrorValidationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_ErrorValidationColor = cmdletContext.PortalContent_Theme_CustomColors_ErrorValidationColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_ErrorValidationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.ErrorValidationColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_ErrorValidationColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_HeaderColor = null;
            if (cmdletContext.PortalContent_Theme_CustomColors_HeaderColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_HeaderColor = cmdletContext.PortalContent_Theme_CustomColors_HeaderColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_HeaderColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.HeaderColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_HeaderColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_NavigationColor = null;
            if (cmdletContext.PortalContent_Theme_CustomColors_NavigationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_NavigationColor = cmdletContext.PortalContent_Theme_CustomColors_NavigationColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_NavigationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.NavigationColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_NavigationColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_TextColor = null;
            if (cmdletContext.PortalContent_Theme_CustomColors_TextColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_TextColor = cmdletContext.PortalContent_Theme_CustomColors_TextColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_TextColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.TextColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_portalContent_Theme_CustomColors_TextColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
             // determine if requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors should be set to null
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors = null;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors != null)
            {
                requestPortalContent_portalContent_Theme.CustomColors = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors;
                requestPortalContent_portalContent_ThemeIsNull = false;
            }
             // determine if requestPortalContent_portalContent_Theme should be set to null
            if (requestPortalContent_portalContent_ThemeIsNull)
            {
                requestPortalContent_portalContent_Theme = null;
            }
            if (requestPortalContent_portalContent_Theme != null)
            {
                request.PortalContent.Theme = requestPortalContent_portalContent_Theme;
                requestPortalContentIsNull = false;
            }
             // determine if request.PortalContent should be set to null
            if (requestPortalContentIsNull)
            {
                request.PortalContent = null;
            }
            if (cmdletContext.PortalId != null)
            {
                request.PortalId = cmdletContext.PortalId;
            }
            if (cmdletContext.RumAppMonitorName != null)
            {
                request.RumAppMonitorName = cmdletContext.RumAppMonitorName;
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
        
        private Amazon.APIPortal.Model.UpdatePortalResponse CallAWSServiceOperation(IAmazonAPIPortal client, Amazon.APIPortal.Model.UpdatePortalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "APIPortal", "UpdatePortal");
            try
            {
                return client.UpdatePortalAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Authorization_AuthorizationConfig_CognitoConfig_AppClientId { get; set; }
            public System.String Authorization_AuthorizationConfig_CognitoConfig_IdentityPoolId { get; set; }
            public System.String Authorization_AuthorizationConfig_CognitoConfig_UserPoolArn { get; set; }
            public System.String Authorization_AuthorizationConfig_CognitoConfig_UserPoolDomain { get; set; }
            public Amazon.APIPortal.Model.None Authorization_AuthorizationConfig_None { get; set; }
            public Amazon.APIPortal.FineGrainedAccessControl Authorization_FineGrainedAccessControl { get; set; }
            public System.String EndpointConfiguration_AcmManaged_CertificateArn { get; set; }
            public System.String EndpointConfiguration_AcmManaged_DomainName { get; set; }
            public Amazon.APIPortal.Model.None EndpointConfiguration_None { get; set; }
            public List<System.String> IncludedProductArn { get; set; }
            public System.String LogoUri { get; set; }
            public System.String PortalContent_Description { get; set; }
            public System.String PortalContent_DisplayName { get; set; }
            public System.String PortalContent_Theme_CustomColors_AccentColor { get; set; }
            public System.String PortalContent_Theme_CustomColors_BackgroundColor { get; set; }
            public System.String PortalContent_Theme_CustomColors_ErrorValidationColor { get; set; }
            public System.String PortalContent_Theme_CustomColors_HeaderColor { get; set; }
            public System.String PortalContent_Theme_CustomColors_NavigationColor { get; set; }
            public System.String PortalContent_Theme_CustomColors_TextColor { get; set; }
            public System.DateTime? PortalContent_Theme_LogoUploadedAt { get; set; }
            public System.String PortalId { get; set; }
            public System.String RumAppMonitorName { get; set; }
            public System.Func<Amazon.APIPortal.Model.UpdatePortalResponse, UpdateAPIPPortalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
