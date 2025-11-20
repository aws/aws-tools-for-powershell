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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Creates a portal.
    /// </summary>
    [Cmdlet("New", "AG2Portal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreatePortalResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreatePortal API operation.", Operation = new[] {"CreatePortal"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.CreatePortalResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreatePortalResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.CreatePortalResponse object containing multiple properties."
    )]
    public partial class NewAG2PortalCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CustomColors_AccentColor
        /// <summary>
        /// <para>
        /// <para>Represents the accent color.</para>
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
        [Alias("PortalContent_Theme_CustomColors_AccentColor")]
        public System.String CustomColors_AccentColor { get; set; }
        #endregion
        
        #region Parameter CognitoConfig_AppClientId
        /// <summary>
        /// <para>
        /// <para>The app client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Authorization_CognitoConfig_AppClientId")]
        public System.String CognitoConfig_AppClientId { get; set; }
        #endregion
        
        #region Parameter CustomColors_BackgroundColor
        /// <summary>
        /// <para>
        /// <para>Represents the background color.</para>
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
        [Alias("PortalContent_Theme_CustomColors_BackgroundColor")]
        public System.String CustomColors_BackgroundColor { get; set; }
        #endregion
        
        #region Parameter AcmManaged_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The certificate ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfiguration_AcmManaged_CertificateArn")]
        public System.String AcmManaged_CertificateArn { get; set; }
        #endregion
        
        #region Parameter PortalContent_Description
        /// <summary>
        /// <para>
        /// <para>A description of the portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PortalContent_Description { get; set; }
        #endregion
        
        #region Parameter PortalContent_DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name for the portal.</para>
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
        public System.String PortalContent_DisplayName { get; set; }
        #endregion
        
        #region Parameter AcmManaged_DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfiguration_AcmManaged_DomainName")]
        public System.String AcmManaged_DomainName { get; set; }
        #endregion
        
        #region Parameter CustomColors_ErrorValidationColor
        /// <summary>
        /// <para>
        /// <para>The errorValidationColor.</para>
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
        [Alias("PortalContent_Theme_CustomColors_ErrorValidationColor")]
        public System.String CustomColors_ErrorValidationColor { get; set; }
        #endregion
        
        #region Parameter CustomColors_HeaderColor
        /// <summary>
        /// <para>
        /// <para>Represents the header color.</para>
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
        [Alias("PortalContent_Theme_CustomColors_HeaderColor")]
        public System.String CustomColors_HeaderColor { get; set; }
        #endregion
        
        #region Parameter IncludedPortalProductArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the portal products included in the portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludedPortalProductArns")]
        public System.String[] IncludedPortalProductArn { get; set; }
        #endregion
        
        #region Parameter Theme_LogoLastUploaded
        /// <summary>
        /// <para>
        /// <para>The timestamp when the logo was last uploaded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortalContent_Theme_LogoLastUploaded")]
        public System.DateTime? Theme_LogoLastUploaded { get; set; }
        #endregion
        
        #region Parameter LogoUri
        /// <summary>
        /// <para>
        /// <para>The URI for the portal logo image that is displayed in the portal header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogoUri { get; set; }
        #endregion
        
        #region Parameter CustomColors_NavigationColor
        /// <summary>
        /// <para>
        /// <para>Represents the navigation color.</para>
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
        [Alias("PortalContent_Theme_CustomColors_NavigationColor")]
        public System.String CustomColors_NavigationColor { get; set; }
        #endregion
        
        #region Parameter Authorization_None
        /// <summary>
        /// <para>
        /// <para>Provide no authorization for your portal. This makes your portal publicly accesible
        /// on the web.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ApiGatewayV2.Model.None Authorization_None { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_None
        /// <summary>
        /// <para>
        /// <para>Use the default portal domain name that is generated and managed by API Gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ApiGatewayV2.Model.None EndpointConfiguration_None { get; set; }
        #endregion
        
        #region Parameter RumAppMonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch RUM app monitor for the portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RumAppMonitorName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The collection of tags. Each tag element is associated with a given resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter CustomColors_TextColor
        /// <summary>
        /// <para>
        /// <para>Represents the text color.</para>
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
        [Alias("PortalContent_Theme_CustomColors_TextColor")]
        public System.String CustomColors_TextColor { get; set; }
        #endregion
        
        #region Parameter CognitoConfig_UserPoolArn
        /// <summary>
        /// <para>
        /// <para>The user pool ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Authorization_CognitoConfig_UserPoolArn")]
        public System.String CognitoConfig_UserPoolArn { get; set; }
        #endregion
        
        #region Parameter CognitoConfig_UserPoolDomain
        /// <summary>
        /// <para>
        /// <para>The user pool domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Authorization_CognitoConfig_UserPoolDomain")]
        public System.String CognitoConfig_UserPoolDomain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.CreatePortalResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.CreatePortalResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortalContent_DisplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2Portal (CreatePortal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.CreatePortalResponse, NewAG2PortalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CognitoConfig_AppClientId = this.CognitoConfig_AppClientId;
            context.CognitoConfig_UserPoolArn = this.CognitoConfig_UserPoolArn;
            context.CognitoConfig_UserPoolDomain = this.CognitoConfig_UserPoolDomain;
            context.Authorization_None = this.Authorization_None;
            context.AcmManaged_CertificateArn = this.AcmManaged_CertificateArn;
            context.AcmManaged_DomainName = this.AcmManaged_DomainName;
            context.EndpointConfiguration_None = this.EndpointConfiguration_None;
            if (this.IncludedPortalProductArn != null)
            {
                context.IncludedPortalProductArn = new List<System.String>(this.IncludedPortalProductArn);
            }
            context.LogoUri = this.LogoUri;
            context.PortalContent_Description = this.PortalContent_Description;
            context.PortalContent_DisplayName = this.PortalContent_DisplayName;
            #if MODULAR
            if (this.PortalContent_DisplayName == null && ParameterWasBound(nameof(this.PortalContent_DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalContent_DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomColors_AccentColor = this.CustomColors_AccentColor;
            #if MODULAR
            if (this.CustomColors_AccentColor == null && ParameterWasBound(nameof(this.CustomColors_AccentColor)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomColors_AccentColor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomColors_BackgroundColor = this.CustomColors_BackgroundColor;
            #if MODULAR
            if (this.CustomColors_BackgroundColor == null && ParameterWasBound(nameof(this.CustomColors_BackgroundColor)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomColors_BackgroundColor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomColors_ErrorValidationColor = this.CustomColors_ErrorValidationColor;
            #if MODULAR
            if (this.CustomColors_ErrorValidationColor == null && ParameterWasBound(nameof(this.CustomColors_ErrorValidationColor)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomColors_ErrorValidationColor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomColors_HeaderColor = this.CustomColors_HeaderColor;
            #if MODULAR
            if (this.CustomColors_HeaderColor == null && ParameterWasBound(nameof(this.CustomColors_HeaderColor)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomColors_HeaderColor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomColors_NavigationColor = this.CustomColors_NavigationColor;
            #if MODULAR
            if (this.CustomColors_NavigationColor == null && ParameterWasBound(nameof(this.CustomColors_NavigationColor)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomColors_NavigationColor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomColors_TextColor = this.CustomColors_TextColor;
            #if MODULAR
            if (this.CustomColors_TextColor == null && ParameterWasBound(nameof(this.CustomColors_TextColor)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomColors_TextColor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Theme_LogoLastUploaded = this.Theme_LogoLastUploaded;
            context.RumAppMonitorName = this.RumAppMonitorName;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.ApiGatewayV2.Model.CreatePortalRequest();
            
            
             // populate Authorization
            var requestAuthorizationIsNull = true;
            request.Authorization = new Amazon.ApiGatewayV2.Model.Authorization();
            Amazon.ApiGatewayV2.Model.None requestAuthorization_authorization_None = null;
            if (cmdletContext.Authorization_None != null)
            {
                requestAuthorization_authorization_None = cmdletContext.Authorization_None;
            }
            if (requestAuthorization_authorization_None != null)
            {
                request.Authorization.None = requestAuthorization_authorization_None;
                requestAuthorizationIsNull = false;
            }
            Amazon.ApiGatewayV2.Model.CognitoConfig requestAuthorization_authorization_CognitoConfig = null;
            
             // populate CognitoConfig
            var requestAuthorization_authorization_CognitoConfigIsNull = true;
            requestAuthorization_authorization_CognitoConfig = new Amazon.ApiGatewayV2.Model.CognitoConfig();
            System.String requestAuthorization_authorization_CognitoConfig_cognitoConfig_AppClientId = null;
            if (cmdletContext.CognitoConfig_AppClientId != null)
            {
                requestAuthorization_authorization_CognitoConfig_cognitoConfig_AppClientId = cmdletContext.CognitoConfig_AppClientId;
            }
            if (requestAuthorization_authorization_CognitoConfig_cognitoConfig_AppClientId != null)
            {
                requestAuthorization_authorization_CognitoConfig.AppClientId = requestAuthorization_authorization_CognitoConfig_cognitoConfig_AppClientId;
                requestAuthorization_authorization_CognitoConfigIsNull = false;
            }
            System.String requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolArn = null;
            if (cmdletContext.CognitoConfig_UserPoolArn != null)
            {
                requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolArn = cmdletContext.CognitoConfig_UserPoolArn;
            }
            if (requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolArn != null)
            {
                requestAuthorization_authorization_CognitoConfig.UserPoolArn = requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolArn;
                requestAuthorization_authorization_CognitoConfigIsNull = false;
            }
            System.String requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolDomain = null;
            if (cmdletContext.CognitoConfig_UserPoolDomain != null)
            {
                requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolDomain = cmdletContext.CognitoConfig_UserPoolDomain;
            }
            if (requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolDomain != null)
            {
                requestAuthorization_authorization_CognitoConfig.UserPoolDomain = requestAuthorization_authorization_CognitoConfig_cognitoConfig_UserPoolDomain;
                requestAuthorization_authorization_CognitoConfigIsNull = false;
            }
             // determine if requestAuthorization_authorization_CognitoConfig should be set to null
            if (requestAuthorization_authorization_CognitoConfigIsNull)
            {
                requestAuthorization_authorization_CognitoConfig = null;
            }
            if (requestAuthorization_authorization_CognitoConfig != null)
            {
                request.Authorization.CognitoConfig = requestAuthorization_authorization_CognitoConfig;
                requestAuthorizationIsNull = false;
            }
             // determine if request.Authorization should be set to null
            if (requestAuthorizationIsNull)
            {
                request.Authorization = null;
            }
            
             // populate EndpointConfiguration
            var requestEndpointConfigurationIsNull = true;
            request.EndpointConfiguration = new Amazon.ApiGatewayV2.Model.EndpointConfigurationRequest();
            Amazon.ApiGatewayV2.Model.None requestEndpointConfiguration_endpointConfiguration_None = null;
            if (cmdletContext.EndpointConfiguration_None != null)
            {
                requestEndpointConfiguration_endpointConfiguration_None = cmdletContext.EndpointConfiguration_None;
            }
            if (requestEndpointConfiguration_endpointConfiguration_None != null)
            {
                request.EndpointConfiguration.None = requestEndpointConfiguration_endpointConfiguration_None;
                requestEndpointConfigurationIsNull = false;
            }
            Amazon.ApiGatewayV2.Model.ACMManaged requestEndpointConfiguration_endpointConfiguration_AcmManaged = null;
            
             // populate AcmManaged
            var requestEndpointConfiguration_endpointConfiguration_AcmManagedIsNull = true;
            requestEndpointConfiguration_endpointConfiguration_AcmManaged = new Amazon.ApiGatewayV2.Model.ACMManaged();
            System.String requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_CertificateArn = null;
            if (cmdletContext.AcmManaged_CertificateArn != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_CertificateArn = cmdletContext.AcmManaged_CertificateArn;
            }
            if (requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_CertificateArn != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged.CertificateArn = requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_CertificateArn;
                requestEndpointConfiguration_endpointConfiguration_AcmManagedIsNull = false;
            }
            System.String requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_DomainName = null;
            if (cmdletContext.AcmManaged_DomainName != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_DomainName = cmdletContext.AcmManaged_DomainName;
            }
            if (requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_DomainName != null)
            {
                requestEndpointConfiguration_endpointConfiguration_AcmManaged.DomainName = requestEndpointConfiguration_endpointConfiguration_AcmManaged_acmManaged_DomainName;
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
            if (cmdletContext.IncludedPortalProductArn != null)
            {
                request.IncludedPortalProductArns = cmdletContext.IncludedPortalProductArn;
            }
            if (cmdletContext.LogoUri != null)
            {
                request.LogoUri = cmdletContext.LogoUri;
            }
            
             // populate PortalContent
            var requestPortalContentIsNull = true;
            request.PortalContent = new Amazon.ApiGatewayV2.Model.PortalContent();
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
            Amazon.ApiGatewayV2.Model.PortalTheme requestPortalContent_portalContent_Theme = null;
            
             // populate Theme
            var requestPortalContent_portalContent_ThemeIsNull = true;
            requestPortalContent_portalContent_Theme = new Amazon.ApiGatewayV2.Model.PortalTheme();
            System.DateTime? requestPortalContent_portalContent_Theme_theme_LogoLastUploaded = null;
            if (cmdletContext.Theme_LogoLastUploaded != null)
            {
                requestPortalContent_portalContent_Theme_theme_LogoLastUploaded = cmdletContext.Theme_LogoLastUploaded.Value;
            }
            if (requestPortalContent_portalContent_Theme_theme_LogoLastUploaded != null)
            {
                requestPortalContent_portalContent_Theme.LogoLastUploaded = requestPortalContent_portalContent_Theme_theme_LogoLastUploaded.Value;
                requestPortalContent_portalContent_ThemeIsNull = false;
            }
            Amazon.ApiGatewayV2.Model.CustomColors requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors = null;
            
             // populate CustomColors
            var requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = true;
            requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors = new Amazon.ApiGatewayV2.Model.CustomColors();
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_AccentColor = null;
            if (cmdletContext.CustomColors_AccentColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_AccentColor = cmdletContext.CustomColors_AccentColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_AccentColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.AccentColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_AccentColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_BackgroundColor = null;
            if (cmdletContext.CustomColors_BackgroundColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_BackgroundColor = cmdletContext.CustomColors_BackgroundColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_BackgroundColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.BackgroundColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_BackgroundColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_ErrorValidationColor = null;
            if (cmdletContext.CustomColors_ErrorValidationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_ErrorValidationColor = cmdletContext.CustomColors_ErrorValidationColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_ErrorValidationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.ErrorValidationColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_ErrorValidationColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_HeaderColor = null;
            if (cmdletContext.CustomColors_HeaderColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_HeaderColor = cmdletContext.CustomColors_HeaderColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_HeaderColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.HeaderColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_HeaderColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_NavigationColor = null;
            if (cmdletContext.CustomColors_NavigationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_NavigationColor = cmdletContext.CustomColors_NavigationColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_NavigationColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.NavigationColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_NavigationColor;
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColorsIsNull = false;
            }
            System.String requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_TextColor = null;
            if (cmdletContext.CustomColors_TextColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_TextColor = cmdletContext.CustomColors_TextColor;
            }
            if (requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_TextColor != null)
            {
                requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors.TextColor = requestPortalContent_portalContent_Theme_portalContent_Theme_CustomColors_customColors_TextColor;
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
            if (cmdletContext.RumAppMonitorName != null)
            {
                request.RumAppMonitorName = cmdletContext.RumAppMonitorName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ApiGatewayV2.Model.CreatePortalResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreatePortalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreatePortal");
            try
            {
                #if DESKTOP
                return client.CreatePortal(request);
                #elif CORECLR
                return client.CreatePortalAsync(request).GetAwaiter().GetResult();
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
            public System.String CognitoConfig_AppClientId { get; set; }
            public System.String CognitoConfig_UserPoolArn { get; set; }
            public System.String CognitoConfig_UserPoolDomain { get; set; }
            public Amazon.ApiGatewayV2.Model.None Authorization_None { get; set; }
            public System.String AcmManaged_CertificateArn { get; set; }
            public System.String AcmManaged_DomainName { get; set; }
            public Amazon.ApiGatewayV2.Model.None EndpointConfiguration_None { get; set; }
            public List<System.String> IncludedPortalProductArn { get; set; }
            public System.String LogoUri { get; set; }
            public System.String PortalContent_Description { get; set; }
            public System.String PortalContent_DisplayName { get; set; }
            public System.String CustomColors_AccentColor { get; set; }
            public System.String CustomColors_BackgroundColor { get; set; }
            public System.String CustomColors_ErrorValidationColor { get; set; }
            public System.String CustomColors_HeaderColor { get; set; }
            public System.String CustomColors_NavigationColor { get; set; }
            public System.String CustomColors_TextColor { get; set; }
            public System.DateTime? Theme_LogoLastUploaded { get; set; }
            public System.String RumAppMonitorName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.CreatePortalResponse, NewAG2PortalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
