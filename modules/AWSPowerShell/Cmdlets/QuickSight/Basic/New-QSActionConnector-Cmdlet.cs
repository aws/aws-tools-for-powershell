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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates an action connector that enables Amazon Quick Sight to connect to external
    /// services and perform actions. Action connectors support various authentication methods
    /// and can be configured with specific actions from supported connector types like Amazon
    /// S3, Salesforce, JIRA.
    /// </summary>
    [Cmdlet("New", "QSActionConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateActionConnectorResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateActionConnector API operation.", Operation = new[] {"CreateActionConnector"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateActionConnectorResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateActionConnectorResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateActionConnectorResponse object containing multiple properties."
    )]
    public partial class NewQSActionConnectorCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionConnectorId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the action connector. This ID must be unique within the Amazon
        /// Web Services account. The <c>ActionConnectorId</c> must not start with the prefix
        /// <c>quicksuite-</c></para>
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
        public System.String ActionConnectorId { get; set; }
        #endregion
        
        #region Parameter ApiKeyConnectionMetadata_ApiKey
        /// <summary>
        /// <para>
        /// <para>The API key used for authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_ApiKey")]
        public System.String ApiKeyConnectionMetadata_ApiKey { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfig_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The type of authentication method.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.ConnectionAuthType")]
        public Amazon.QuickSight.ConnectionAuthType AuthenticationConfig_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource
        /// <summary>
        /// <para>
        /// <para>The source of the authorization code grant credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource")]
        [AWSConstantClassSource("Amazon.QuickSight.AuthorizationCodeGrantCredentialsSource")]
        public Amazon.QuickSight.AuthorizationCodeGrantCredentialsSource AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeGrantDetails_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The authorization endpoint URL for the OAuth flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_AuthorizationEndpoint")]
        public System.String AuthorizationCodeGrantDetails_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the action connector.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter ApiKeyConnectionMetadata_BaseEndpoint
        /// <summary>
        /// <para>
        /// <para>The base URL endpoint for the external service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_BaseEndpoint")]
        public System.String ApiKeyConnectionMetadata_BaseEndpoint { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeGrantMetadata_BaseEndpoint
        /// <summary>
        /// <para>
        /// <para>The base URL endpoint for the external service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_BaseEndpoint")]
        public System.String AuthorizationCodeGrantMetadata_BaseEndpoint { get; set; }
        #endregion
        
        #region Parameter BasicAuthConnectionMetadata_BaseEndpoint
        /// <summary>
        /// <para>
        /// <para>The base URL endpoint for the external service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_BaseEndpoint")]
        public System.String BasicAuthConnectionMetadata_BaseEndpoint { get; set; }
        #endregion
        
        #region Parameter ClientCredentialsGrantMetadata_BaseEndpoint
        /// <summary>
        /// <para>
        /// <para>The base endpoint URL for the external service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_BaseEndpoint")]
        public System.String ClientCredentialsGrantMetadata_BaseEndpoint { get; set; }
        #endregion
        
        #region Parameter NoneConnectionMetadata_BaseEndpoint
        /// <summary>
        /// <para>
        /// <para>The base endpoint URL for connections that do not require authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_NoneConnectionMetadata_BaseEndpoint")]
        public System.String NoneConnectionMetadata_BaseEndpoint { get; set; }
        #endregion
        
        #region Parameter ClientCredentialsGrantMetadata_ClientCredentialsSource
        /// <summary>
        /// <para>
        /// <para>The source of the client credentials configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsSource")]
        [AWSConstantClassSource("Amazon.QuickSight.ClientCredentialsSource")]
        public Amazon.QuickSight.ClientCredentialsSource ClientCredentialsGrantMetadata_ClientCredentialsSource { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeGrantDetails_ClientId
        /// <summary>
        /// <para>
        /// <para>The client ID for the OAuth application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_ClientId")]
        public System.String AuthorizationCodeGrantDetails_ClientId { get; set; }
        #endregion
        
        #region Parameter ClientCredentialsGrantDetails_ClientId
        /// <summary>
        /// <para>
        /// <para>The client identifier issued to the client during the registration process with the
        /// authorization server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_ClientId")]
        public System.String ClientCredentialsGrantDetails_ClientId { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeGrantDetails_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret for the OAuth application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_ClientSecret")]
        public System.String AuthorizationCodeGrantDetails_ClientSecret { get; set; }
        #endregion
        
        #region Parameter ClientCredentialsGrantDetails_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret issued to the client during the registration process with the authorization
        /// server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_ClientSecret")]
        public System.String ClientCredentialsGrantDetails_ClientSecret { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the action connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ApiKeyConnectionMetadata_Email
        /// <summary>
        /// <para>
        /// <para>The email address associated with the API key, if required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_Email")]
        public System.String ApiKeyConnectionMetadata_Email { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive name for the action connector.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter BasicAuthConnectionMetadata_Password
        /// <summary>
        /// <para>
        /// <para>The password for basic authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_Password")]
        public System.String BasicAuthConnectionMetadata_Password { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The permissions configuration that defines which users, groups, or namespaces can
        /// access this action connector and what operations they can perform.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] Permission { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeGrantMetadata_RedirectUrl
        /// <summary>
        /// <para>
        /// <para>The redirect URL for the OAuth authorization flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_RedirectUrl")]
        public System.String AuthorizationCodeGrantMetadata_RedirectUrl { get; set; }
        #endregion
        
        #region Parameter IamConnectionMetadata_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to assume for authentication with Amazon
        /// Web Services services. This IAM role should be in the same account as Quick Sight.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_IamConnectionMetadata_RoleArn")]
        public System.String IamConnectionMetadata_RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to apply to the action connector for resource management and organization.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeGrantDetails_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>The token endpoint URL for obtaining access tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_TokenEndpoint")]
        public System.String AuthorizationCodeGrantDetails_TokenEndpoint { get; set; }
        #endregion
        
        #region Parameter ClientCredentialsGrantDetails_TokenEndpoint
        /// <summary>
        /// <para>
        /// <para>The authorization server endpoint used to obtain access tokens via the client credentials
        /// grant flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_TokenEndpoint")]
        public System.String ClientCredentialsGrantDetails_TokenEndpoint { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of action connector.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.ActionConnectorType")]
        public Amazon.QuickSight.ActionConnectorType Type { get; set; }
        #endregion
        
        #region Parameter BasicAuthConnectionMetadata_Username
        /// <summary>
        /// <para>
        /// <para>The username for basic authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_Username")]
        public System.String BasicAuthConnectionMetadata_Username { get; set; }
        #endregion
        
        #region Parameter VpcConnectionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the VPC connection to use for secure connectivity to the external service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConnectionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateActionConnectorResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateActionConnectorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActionConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSActionConnector (CreateActionConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateActionConnectorResponse, NewQSActionConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionConnectorId = this.ActionConnectorId;
            #if MODULAR
            if (this.ActionConnectorId == null && ParameterWasBound(nameof(this.ActionConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiKeyConnectionMetadata_ApiKey = this.ApiKeyConnectionMetadata_ApiKey;
            context.ApiKeyConnectionMetadata_BaseEndpoint = this.ApiKeyConnectionMetadata_BaseEndpoint;
            context.ApiKeyConnectionMetadata_Email = this.ApiKeyConnectionMetadata_Email;
            context.AuthorizationCodeGrantDetails_AuthorizationEndpoint = this.AuthorizationCodeGrantDetails_AuthorizationEndpoint;
            context.AuthorizationCodeGrantDetails_ClientId = this.AuthorizationCodeGrantDetails_ClientId;
            context.AuthorizationCodeGrantDetails_ClientSecret = this.AuthorizationCodeGrantDetails_ClientSecret;
            context.AuthorizationCodeGrantDetails_TokenEndpoint = this.AuthorizationCodeGrantDetails_TokenEndpoint;
            context.AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource = this.AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource;
            context.AuthorizationCodeGrantMetadata_BaseEndpoint = this.AuthorizationCodeGrantMetadata_BaseEndpoint;
            context.AuthorizationCodeGrantMetadata_RedirectUrl = this.AuthorizationCodeGrantMetadata_RedirectUrl;
            context.BasicAuthConnectionMetadata_BaseEndpoint = this.BasicAuthConnectionMetadata_BaseEndpoint;
            context.BasicAuthConnectionMetadata_Password = this.BasicAuthConnectionMetadata_Password;
            context.BasicAuthConnectionMetadata_Username = this.BasicAuthConnectionMetadata_Username;
            context.ClientCredentialsGrantMetadata_BaseEndpoint = this.ClientCredentialsGrantMetadata_BaseEndpoint;
            context.ClientCredentialsGrantDetails_ClientId = this.ClientCredentialsGrantDetails_ClientId;
            context.ClientCredentialsGrantDetails_ClientSecret = this.ClientCredentialsGrantDetails_ClientSecret;
            context.ClientCredentialsGrantDetails_TokenEndpoint = this.ClientCredentialsGrantDetails_TokenEndpoint;
            context.ClientCredentialsGrantMetadata_ClientCredentialsSource = this.ClientCredentialsGrantMetadata_ClientCredentialsSource;
            context.IamConnectionMetadata_RoleArn = this.IamConnectionMetadata_RoleArn;
            context.NoneConnectionMetadata_BaseEndpoint = this.NoneConnectionMetadata_BaseEndpoint;
            context.AuthenticationConfig_AuthenticationType = this.AuthenticationConfig_AuthenticationType;
            #if MODULAR
            if (this.AuthenticationConfig_AuthenticationType == null && ParameterWasBound(nameof(this.AuthenticationConfig_AuthenticationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationConfig_AuthenticationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permission != null)
            {
                context.Permission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.Permission);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcConnectionArn = this.VpcConnectionArn;
            
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
            var request = new Amazon.QuickSight.Model.CreateActionConnectorRequest();
            
            if (cmdletContext.ActionConnectorId != null)
            {
                request.ActionConnectorId = cmdletContext.ActionConnectorId;
            }
            
             // populate AuthenticationConfig
            var requestAuthenticationConfigIsNull = true;
            request.AuthenticationConfig = new Amazon.QuickSight.Model.AuthConfig();
            Amazon.QuickSight.ConnectionAuthType requestAuthenticationConfig_authenticationConfig_AuthenticationType = null;
            if (cmdletContext.AuthenticationConfig_AuthenticationType != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationType = cmdletContext.AuthenticationConfig_AuthenticationType;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationType != null)
            {
                request.AuthenticationConfig.AuthenticationType = requestAuthenticationConfig_authenticationConfig_AuthenticationType;
                requestAuthenticationConfigIsNull = false;
            }
            Amazon.QuickSight.Model.AuthenticationMetadata requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata = null;
            
             // populate AuthenticationMetadata
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata = new Amazon.QuickSight.Model.AuthenticationMetadata();
            Amazon.QuickSight.Model.IAMConnectionMetadata requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata = null;
            
             // populate IamConnectionMetadata
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadataIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata = new Amazon.QuickSight.Model.IAMConnectionMetadata();
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata_iamConnectionMetadata_RoleArn = null;
            if (cmdletContext.IamConnectionMetadata_RoleArn != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata_iamConnectionMetadata_RoleArn = cmdletContext.IamConnectionMetadata_RoleArn;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata_iamConnectionMetadata_RoleArn != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata.RoleArn = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata_iamConnectionMetadata_RoleArn;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadataIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadataIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata.IamConnectionMetadata = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_IamConnectionMetadata;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull = false;
            }
            Amazon.QuickSight.Model.NoneConnectionMetadata requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata = null;
            
             // populate NoneConnectionMetadata
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadataIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata = new Amazon.QuickSight.Model.NoneConnectionMetadata();
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata_noneConnectionMetadata_BaseEndpoint = null;
            if (cmdletContext.NoneConnectionMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata_noneConnectionMetadata_BaseEndpoint = cmdletContext.NoneConnectionMetadata_BaseEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata_noneConnectionMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata.BaseEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata_noneConnectionMetadata_BaseEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadataIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadataIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata.NoneConnectionMetadata = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_NoneConnectionMetadata;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull = false;
            }
            Amazon.QuickSight.Model.APIKeyConnectionMetadata requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata = null;
            
             // populate ApiKeyConnectionMetadata
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadataIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata = new Amazon.QuickSight.Model.APIKeyConnectionMetadata();
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_ApiKey = null;
            if (cmdletContext.ApiKeyConnectionMetadata_ApiKey != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_ApiKey = cmdletContext.ApiKeyConnectionMetadata_ApiKey;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_ApiKey != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata.ApiKey = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_ApiKey;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadataIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_BaseEndpoint = null;
            if (cmdletContext.ApiKeyConnectionMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_BaseEndpoint = cmdletContext.ApiKeyConnectionMetadata_BaseEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata.BaseEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_BaseEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadataIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_Email = null;
            if (cmdletContext.ApiKeyConnectionMetadata_Email != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_Email = cmdletContext.ApiKeyConnectionMetadata_Email;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_Email != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata.Email = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata_apiKeyConnectionMetadata_Email;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadataIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadataIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata.ApiKeyConnectionMetadata = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ApiKeyConnectionMetadata;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull = false;
            }
            Amazon.QuickSight.Model.BasicAuthConnectionMetadata requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata = null;
            
             // populate BasicAuthConnectionMetadata
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadataIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata = new Amazon.QuickSight.Model.BasicAuthConnectionMetadata();
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_BaseEndpoint = null;
            if (cmdletContext.BasicAuthConnectionMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_BaseEndpoint = cmdletContext.BasicAuthConnectionMetadata_BaseEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata.BaseEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_BaseEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadataIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Password = null;
            if (cmdletContext.BasicAuthConnectionMetadata_Password != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Password = cmdletContext.BasicAuthConnectionMetadata_Password;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Password != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata.Password = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Password;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadataIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Username = null;
            if (cmdletContext.BasicAuthConnectionMetadata_Username != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Username = cmdletContext.BasicAuthConnectionMetadata_Username;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Username != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata.Username = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata_basicAuthConnectionMetadata_Username;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadataIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadataIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata.BasicAuthConnectionMetadata = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_BasicAuthConnectionMetadata;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull = false;
            }
            Amazon.QuickSight.Model.ClientCredentialsGrantMetadata requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata = null;
            
             // populate ClientCredentialsGrantMetadata
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadataIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata = new Amazon.QuickSight.Model.ClientCredentialsGrantMetadata();
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_BaseEndpoint = null;
            if (cmdletContext.ClientCredentialsGrantMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_BaseEndpoint = cmdletContext.ClientCredentialsGrantMetadata_BaseEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata.BaseEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_BaseEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadataIsNull = false;
            }
            Amazon.QuickSight.ClientCredentialsSource requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_ClientCredentialsSource = null;
            if (cmdletContext.ClientCredentialsGrantMetadata_ClientCredentialsSource != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_ClientCredentialsSource = cmdletContext.ClientCredentialsGrantMetadata_ClientCredentialsSource;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_ClientCredentialsSource != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata.ClientCredentialsSource = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_clientCredentialsGrantMetadata_ClientCredentialsSource;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadataIsNull = false;
            }
            Amazon.QuickSight.Model.ClientCredentialsDetails requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails = null;
            
             // populate ClientCredentialsDetails
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetailsIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails = new Amazon.QuickSight.Model.ClientCredentialsDetails();
            Amazon.QuickSight.Model.ClientCredentialsGrantDetails requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails = null;
            
             // populate ClientCredentialsGrantDetails
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetailsIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails = new Amazon.QuickSight.Model.ClientCredentialsGrantDetails();
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientId = null;
            if (cmdletContext.ClientCredentialsGrantDetails_ClientId != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientId = cmdletContext.ClientCredentialsGrantDetails_ClientId;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientId != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails.ClientId = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientId;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetailsIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientSecret = null;
            if (cmdletContext.ClientCredentialsGrantDetails_ClientSecret != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientSecret = cmdletContext.ClientCredentialsGrantDetails_ClientSecret;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientSecret != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails.ClientSecret = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_ClientSecret;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetailsIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_TokenEndpoint = null;
            if (cmdletContext.ClientCredentialsGrantDetails_TokenEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_TokenEndpoint = cmdletContext.ClientCredentialsGrantDetails_TokenEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_TokenEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails.TokenEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails_clientCredentialsGrantDetails_TokenEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetailsIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetailsIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails.ClientCredentialsGrantDetails = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails_ClientCredentialsGrantDetails;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetailsIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetailsIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata.ClientCredentialsDetails = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata_ClientCredentialsDetails;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadataIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadataIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata.ClientCredentialsGrantMetadata = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_ClientCredentialsGrantMetadata;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull = false;
            }
            Amazon.QuickSight.Model.AuthorizationCodeGrantMetadata requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata = null;
            
             // populate AuthorizationCodeGrantMetadata
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadataIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata = new Amazon.QuickSight.Model.AuthorizationCodeGrantMetadata();
            Amazon.QuickSight.AuthorizationCodeGrantCredentialsSource requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource = null;
            if (cmdletContext.AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource = cmdletContext.AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata.AuthorizationCodeGrantCredentialsSource = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadataIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_BaseEndpoint = null;
            if (cmdletContext.AuthorizationCodeGrantMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_BaseEndpoint = cmdletContext.AuthorizationCodeGrantMetadata_BaseEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_BaseEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata.BaseEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_BaseEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadataIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_RedirectUrl = null;
            if (cmdletContext.AuthorizationCodeGrantMetadata_RedirectUrl != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_RedirectUrl = cmdletContext.AuthorizationCodeGrantMetadata_RedirectUrl;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_RedirectUrl != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata.RedirectUrl = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authorizationCodeGrantMetadata_RedirectUrl;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadataIsNull = false;
            }
            Amazon.QuickSight.Model.AuthorizationCodeGrantCredentialsDetails requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails = null;
            
             // populate AuthorizationCodeGrantCredentialsDetails
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetailsIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails = new Amazon.QuickSight.Model.AuthorizationCodeGrantCredentialsDetails();
            Amazon.QuickSight.Model.AuthorizationCodeGrantDetails requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails = null;
            
             // populate AuthorizationCodeGrantDetails
            var requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetailsIsNull = true;
            requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails = new Amazon.QuickSight.Model.AuthorizationCodeGrantDetails();
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_AuthorizationEndpoint = null;
            if (cmdletContext.AuthorizationCodeGrantDetails_AuthorizationEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_AuthorizationEndpoint = cmdletContext.AuthorizationCodeGrantDetails_AuthorizationEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_AuthorizationEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails.AuthorizationEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_AuthorizationEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetailsIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientId = null;
            if (cmdletContext.AuthorizationCodeGrantDetails_ClientId != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientId = cmdletContext.AuthorizationCodeGrantDetails_ClientId;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientId != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails.ClientId = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientId;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetailsIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientSecret = null;
            if (cmdletContext.AuthorizationCodeGrantDetails_ClientSecret != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientSecret = cmdletContext.AuthorizationCodeGrantDetails_ClientSecret;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientSecret != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails.ClientSecret = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_ClientSecret;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetailsIsNull = false;
            }
            System.String requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_TokenEndpoint = null;
            if (cmdletContext.AuthorizationCodeGrantDetails_TokenEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_TokenEndpoint = cmdletContext.AuthorizationCodeGrantDetails_TokenEndpoint;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_TokenEndpoint != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails.TokenEndpoint = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails_authorizationCodeGrantDetails_TokenEndpoint;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetailsIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetailsIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails.AuthorizationCodeGrantDetails = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails_AuthorizationCodeGrantDetails;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetailsIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetailsIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata.AuthorizationCodeGrantCredentialsDetails = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsDetails;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadataIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadataIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata != null)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata.AuthorizationCodeGrantMetadata = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata_authenticationConfig_AuthenticationMetadata_AuthorizationCodeGrantMetadata;
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull = false;
            }
             // determine if requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata should be set to null
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadataIsNull)
            {
                requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata = null;
            }
            if (requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata != null)
            {
                request.AuthenticationConfig.AuthenticationMetadata = requestAuthenticationConfig_authenticationConfig_AuthenticationMetadata;
                requestAuthenticationConfigIsNull = false;
            }
             // determine if request.AuthenticationConfig should be set to null
            if (requestAuthenticationConfigIsNull)
            {
                request.AuthenticationConfig = null;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.VpcConnectionArn != null)
            {
                request.VpcConnectionArn = cmdletContext.VpcConnectionArn;
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
        
        private Amazon.QuickSight.Model.CreateActionConnectorResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateActionConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateActionConnector");
            try
            {
                return client.CreateActionConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActionConnectorId { get; set; }
            public System.String ApiKeyConnectionMetadata_ApiKey { get; set; }
            public System.String ApiKeyConnectionMetadata_BaseEndpoint { get; set; }
            public System.String ApiKeyConnectionMetadata_Email { get; set; }
            public System.String AuthorizationCodeGrantDetails_AuthorizationEndpoint { get; set; }
            public System.String AuthorizationCodeGrantDetails_ClientId { get; set; }
            public System.String AuthorizationCodeGrantDetails_ClientSecret { get; set; }
            public System.String AuthorizationCodeGrantDetails_TokenEndpoint { get; set; }
            public Amazon.QuickSight.AuthorizationCodeGrantCredentialsSource AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource { get; set; }
            public System.String AuthorizationCodeGrantMetadata_BaseEndpoint { get; set; }
            public System.String AuthorizationCodeGrantMetadata_RedirectUrl { get; set; }
            public System.String BasicAuthConnectionMetadata_BaseEndpoint { get; set; }
            public System.String BasicAuthConnectionMetadata_Password { get; set; }
            public System.String BasicAuthConnectionMetadata_Username { get; set; }
            public System.String ClientCredentialsGrantMetadata_BaseEndpoint { get; set; }
            public System.String ClientCredentialsGrantDetails_ClientId { get; set; }
            public System.String ClientCredentialsGrantDetails_ClientSecret { get; set; }
            public System.String ClientCredentialsGrantDetails_TokenEndpoint { get; set; }
            public Amazon.QuickSight.ClientCredentialsSource ClientCredentialsGrantMetadata_ClientCredentialsSource { get; set; }
            public System.String IamConnectionMetadata_RoleArn { get; set; }
            public System.String NoneConnectionMetadata_BaseEndpoint { get; set; }
            public Amazon.QuickSight.ConnectionAuthType AuthenticationConfig_AuthenticationType { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> Permission { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public Amazon.QuickSight.ActionConnectorType Type { get; set; }
            public System.String VpcConnectionArn { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateActionConnectorResponse, NewQSActionConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
