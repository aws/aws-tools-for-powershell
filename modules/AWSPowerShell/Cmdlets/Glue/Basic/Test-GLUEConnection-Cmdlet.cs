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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Tests a connection to a service to validate the service credentials that you provide.
    /// 
    ///  
    /// <para>
    /// You can either provide an existing connection name or a <c>TestConnectionInput</c>
    /// for testing a non-existing connection input. Providing both at the same time will
    /// cause an error.
    /// </para><para>
    /// If the action is successful, the service sends back an HTTP 200 response.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "GLUEConnection")]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Glue TestConnection API operation.", Operation = new[] {"TestConnection"}, SelectReturnType = typeof(Amazon.Glue.Model.TestConnectionResponse))]
    [AWSCmdletOutput("None or Amazon.Glue.Model.TestConnectionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Glue.Model.TestConnectionResponse) be returned by specifying '-Select *'."
    )]
    public partial class TestGLUEConnectionCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OAuth2Credentials_AccessToken
        /// <summary>
        /// <para>
        /// <para>The access token used when the authentication type is OAuth2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_AccessToken")]
        public System.String OAuth2Credentials_AccessToken { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_AuthenticationType
        /// <summary>
        /// <para>
        /// <para>A structure containing the authentication configuration in the CreateConnection request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_AuthenticationType")]
        [AWSConstantClassSource("Amazon.Glue.AuthenticationType")]
        public Amazon.Glue.AuthenticationType AuthenticationConfiguration_AuthenticationType { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeProperties_AuthorizationCode
        /// <summary>
        /// <para>
        /// <para>An authorization code to be used in the third leg of the <c>AUTHORIZATION_CODE</c>
        /// grant workflow. This is a single-use code which becomes invalid once exchanged for
        /// an access token, thus it is acceptable to have this value as a request parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_AuthorizationCode")]
        public System.String AuthorizationCodeProperties_AuthorizationCode { get; set; }
        #endregion
        
        #region Parameter OAuth2ClientApplication_AWSManagedClientApplicationReference
        /// <summary>
        /// <para>
        /// <para>The reference to the SaaS-side client app that is Amazon Web Services managed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_AWSManagedClientApplicationReference")]
        public System.String OAuth2ClientApplication_AWSManagedClientApplicationReference { get; set; }
        #endregion
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The catalog ID where the connection resides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter ConnectionName
        /// <summary>
        /// <para>
        /// <para>Optional. The name of the connection to test. If only name is provided, the operation
        /// will get the connection and use that for testing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConnectionName { get; set; }
        #endregion
        
        #region Parameter TestConnectionInput_ConnectionProperty
        /// <summary>
        /// <para>
        /// <para>The key-value pairs that define parameters for the connection.</para><para>JDBC connections use the following connection properties:</para><ul><li><para>Required: All of (<c>HOST</c>, <c>PORT</c>, <c>JDBC_ENGINE</c>) or <c>JDBC_CONNECTION_URL</c>.</para></li><li><para>Required: All of (<c>USERNAME</c>, <c>PASSWORD</c>) or <c>SECRET_ID</c>.</para></li><li><para>Optional: <c>JDBC_ENFORCE_SSL</c>, <c>CUSTOM_JDBC_CERT</c>, <c>CUSTOM_JDBC_CERT_STRING</c>,
        /// <c>SKIP_CUSTOM_JDBC_CERT_VALIDATION</c>. These parameters are used to configure SSL
        /// with JDBC.</para></li></ul><para>SALESFORCE connections require the <c>AuthenticationConfiguration</c> member to be
        /// configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_ConnectionProperties")]
        public System.Collections.Hashtable TestConnectionInput_ConnectionProperty { get; set; }
        #endregion
        
        #region Parameter TestConnectionInput_ConnectionType
        /// <summary>
        /// <para>
        /// <para>The type of connection to test. This operation is only available for the <c>JDBC</c>
        /// or <c>SALESFORCE</c> connection types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ConnectionType")]
        public Amazon.Glue.ConnectionType TestConnectionInput_ConnectionType { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_CustomAuthenticationCredential
        /// <summary>
        /// <para>
        /// <para>The credentials used when the authentication type is custom authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_CustomAuthenticationCredentials")]
        public System.Collections.Hashtable AuthenticationConfiguration_CustomAuthenticationCredential { get; set; }
        #endregion
        
        #region Parameter OAuth2Credentials_JwtToken
        /// <summary>
        /// <para>
        /// <para>The JSON Web Token (JWT) used when the authentication type is OAuth2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_JwtToken")]
        public System.String OAuth2Credentials_JwtToken { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt the connection. Only taken an as input in the
        /// request and stored in the Secret Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_KmsKeyArn")]
        public System.String AuthenticationConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter OAuth2Properties_OAuth2GrantType
        /// <summary>
        /// <para>
        /// <para>The OAuth2 grant type in the CreateConnection request. For example, <c>AUTHORIZATION_CODE</c>,
        /// <c>JWT_BEARER</c>, or <c>CLIENT_CREDENTIALS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2GrantType")]
        [AWSConstantClassSource("Amazon.Glue.OAuth2GrantType")]
        public Amazon.Glue.OAuth2GrantType OAuth2Properties_OAuth2GrantType { get; set; }
        #endregion
        
        #region Parameter BasicAuthenticationCredentials_Password
        /// <summary>
        /// <para>
        /// <para>The password to connect to the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_Password")]
        public System.String BasicAuthenticationCredentials_Password { get; set; }
        #endregion
        
        #region Parameter AuthorizationCodeProperties_RedirectUri
        /// <summary>
        /// <para>
        /// <para>The redirect URI where the user gets redirected to by authorization server when issuing
        /// an authorization code. The URI is subsequently used when the authorization code is
        /// exchanged for an access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_RedirectUri")]
        public System.String AuthorizationCodeProperties_RedirectUri { get; set; }
        #endregion
        
        #region Parameter OAuth2Credentials_RefreshToken
        /// <summary>
        /// <para>
        /// <para>The refresh token used when the authentication type is OAuth2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_RefreshToken")]
        public System.String OAuth2Credentials_RefreshToken { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_SecretArn
        /// <summary>
        /// <para>
        /// <para>The secret manager ARN to store credentials in the CreateConnection request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_SecretArn")]
        public System.String AuthenticationConfiguration_SecretArn { get; set; }
        #endregion
        
        #region Parameter OAuth2Properties_TokenUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the provider's authentication server, to exchange an authorization code
        /// for an access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_TokenUrl")]
        public System.String OAuth2Properties_TokenUrl { get; set; }
        #endregion
        
        #region Parameter OAuth2Properties_TokenUrlParametersMap
        /// <summary>
        /// <para>
        /// <para>A map of parameters that are added to the token <c>GET</c> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_TokenUrlParametersMap")]
        public System.Collections.Hashtable OAuth2Properties_TokenUrlParametersMap { get; set; }
        #endregion
        
        #region Parameter OAuth2ClientApplication_UserManagedClientApplicationClientId
        /// <summary>
        /// <para>
        /// <para>The client application clientID if the ClientAppType is <c>USER_MANAGED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_UserManagedClientApplicationClientId")]
        public System.String OAuth2ClientApplication_UserManagedClientApplicationClientId { get; set; }
        #endregion
        
        #region Parameter OAuth2Credentials_UserManagedClientApplicationClientSecret
        /// <summary>
        /// <para>
        /// <para>The client application client secret if the client application is user managed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_UserManagedClientApplicationClientSecret")]
        public System.String OAuth2Credentials_UserManagedClientApplicationClientSecret { get; set; }
        #endregion
        
        #region Parameter BasicAuthenticationCredentials_Username
        /// <summary>
        /// <para>
        /// <para>The username to connect to the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TestConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_Username")]
        public System.String BasicAuthenticationCredentials_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.TestConnectionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectionName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.TestConnectionResponse, TestGLUEConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            context.ConnectionName = this.ConnectionName;
            context.AuthenticationConfiguration_AuthenticationType = this.AuthenticationConfiguration_AuthenticationType;
            context.BasicAuthenticationCredentials_Password = this.BasicAuthenticationCredentials_Password;
            context.BasicAuthenticationCredentials_Username = this.BasicAuthenticationCredentials_Username;
            if (this.AuthenticationConfiguration_CustomAuthenticationCredential != null)
            {
                context.AuthenticationConfiguration_CustomAuthenticationCredential = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuthenticationConfiguration_CustomAuthenticationCredential.Keys)
                {
                    context.AuthenticationConfiguration_CustomAuthenticationCredential.Add((String)hashKey, (System.String)(this.AuthenticationConfiguration_CustomAuthenticationCredential[hashKey]));
                }
            }
            context.AuthenticationConfiguration_KmsKeyArn = this.AuthenticationConfiguration_KmsKeyArn;
            context.AuthorizationCodeProperties_AuthorizationCode = this.AuthorizationCodeProperties_AuthorizationCode;
            context.AuthorizationCodeProperties_RedirectUri = this.AuthorizationCodeProperties_RedirectUri;
            context.OAuth2ClientApplication_AWSManagedClientApplicationReference = this.OAuth2ClientApplication_AWSManagedClientApplicationReference;
            context.OAuth2ClientApplication_UserManagedClientApplicationClientId = this.OAuth2ClientApplication_UserManagedClientApplicationClientId;
            context.OAuth2Credentials_AccessToken = this.OAuth2Credentials_AccessToken;
            context.OAuth2Credentials_JwtToken = this.OAuth2Credentials_JwtToken;
            context.OAuth2Credentials_RefreshToken = this.OAuth2Credentials_RefreshToken;
            context.OAuth2Credentials_UserManagedClientApplicationClientSecret = this.OAuth2Credentials_UserManagedClientApplicationClientSecret;
            context.OAuth2Properties_OAuth2GrantType = this.OAuth2Properties_OAuth2GrantType;
            context.OAuth2Properties_TokenUrl = this.OAuth2Properties_TokenUrl;
            if (this.OAuth2Properties_TokenUrlParametersMap != null)
            {
                context.OAuth2Properties_TokenUrlParametersMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.OAuth2Properties_TokenUrlParametersMap.Keys)
                {
                    context.OAuth2Properties_TokenUrlParametersMap.Add((String)hashKey, (System.String)(this.OAuth2Properties_TokenUrlParametersMap[hashKey]));
                }
            }
            context.AuthenticationConfiguration_SecretArn = this.AuthenticationConfiguration_SecretArn;
            if (this.TestConnectionInput_ConnectionProperty != null)
            {
                context.TestConnectionInput_ConnectionProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TestConnectionInput_ConnectionProperty.Keys)
                {
                    context.TestConnectionInput_ConnectionProperty.Add((String)hashKey, (System.String)(this.TestConnectionInput_ConnectionProperty[hashKey]));
                }
            }
            context.TestConnectionInput_ConnectionType = this.TestConnectionInput_ConnectionType;
            
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
            var request = new Amazon.Glue.Model.TestConnectionRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            if (cmdletContext.ConnectionName != null)
            {
                request.ConnectionName = cmdletContext.ConnectionName;
            }
            
             // populate TestConnectionInput
            var requestTestConnectionInputIsNull = true;
            request.TestConnectionInput = new Amazon.Glue.Model.TestConnectionInput();
            Dictionary<System.String, System.String> requestTestConnectionInput_testConnectionInput_ConnectionProperty = null;
            if (cmdletContext.TestConnectionInput_ConnectionProperty != null)
            {
                requestTestConnectionInput_testConnectionInput_ConnectionProperty = cmdletContext.TestConnectionInput_ConnectionProperty;
            }
            if (requestTestConnectionInput_testConnectionInput_ConnectionProperty != null)
            {
                request.TestConnectionInput.ConnectionProperties = requestTestConnectionInput_testConnectionInput_ConnectionProperty;
                requestTestConnectionInputIsNull = false;
            }
            Amazon.Glue.ConnectionType requestTestConnectionInput_testConnectionInput_ConnectionType = null;
            if (cmdletContext.TestConnectionInput_ConnectionType != null)
            {
                requestTestConnectionInput_testConnectionInput_ConnectionType = cmdletContext.TestConnectionInput_ConnectionType;
            }
            if (requestTestConnectionInput_testConnectionInput_ConnectionType != null)
            {
                request.TestConnectionInput.ConnectionType = requestTestConnectionInput_testConnectionInput_ConnectionType;
                requestTestConnectionInputIsNull = false;
            }
            Amazon.Glue.Model.AuthenticationConfigurationInput requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration = null;
            
             // populate AuthenticationConfiguration
            var requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull = true;
            requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration = new Amazon.Glue.Model.AuthenticationConfigurationInput();
            Amazon.Glue.AuthenticationType requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType = null;
            if (cmdletContext.AuthenticationConfiguration_AuthenticationType != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType = cmdletContext.AuthenticationConfiguration_AuthenticationType;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration.AuthenticationType = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_AuthenticationType;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential = null;
            if (cmdletContext.AuthenticationConfiguration_CustomAuthenticationCredential != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential = cmdletContext.AuthenticationConfiguration_CustomAuthenticationCredential;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration.CustomAuthenticationCredentials = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_CustomAuthenticationCredential;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn = null;
            if (cmdletContext.AuthenticationConfiguration_KmsKeyArn != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn = cmdletContext.AuthenticationConfiguration_KmsKeyArn;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration.KmsKeyArn = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_KmsKeyArn;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn = null;
            if (cmdletContext.AuthenticationConfiguration_SecretArn != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn = cmdletContext.AuthenticationConfiguration_SecretArn;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration.SecretArn = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_authenticationConfiguration_SecretArn;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            Amazon.Glue.Model.BasicAuthenticationCredentials requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials = null;
            
             // populate BasicAuthenticationCredentials
            var requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull = true;
            requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials = new Amazon.Glue.Model.BasicAuthenticationCredentials();
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password = null;
            if (cmdletContext.BasicAuthenticationCredentials_Password != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password = cmdletContext.BasicAuthenticationCredentials_Password;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials.Password = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Password;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Username = null;
            if (cmdletContext.BasicAuthenticationCredentials_Username != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Username = cmdletContext.BasicAuthenticationCredentials_Username;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Username != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials.Username = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials_basicAuthenticationCredentials_Username;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull = false;
            }
             // determine if requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials should be set to null
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentialsIsNull)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials = null;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration.BasicAuthenticationCredentials = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_BasicAuthenticationCredentials;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull = false;
            }
            Amazon.Glue.Model.OAuth2PropertiesInput requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties = null;
            
             // populate OAuth2Properties
            var requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = true;
            requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties = new Amazon.Glue.Model.OAuth2PropertiesInput();
            Amazon.Glue.OAuth2GrantType requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType = null;
            if (cmdletContext.OAuth2Properties_OAuth2GrantType != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType = cmdletContext.OAuth2Properties_OAuth2GrantType;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties.OAuth2GrantType = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_OAuth2GrantType;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl = null;
            if (cmdletContext.OAuth2Properties_TokenUrl != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl = cmdletContext.OAuth2Properties_TokenUrl;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties.TokenUrl = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrl;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Dictionary<System.String, System.String> requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap = null;
            if (cmdletContext.OAuth2Properties_TokenUrlParametersMap != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap = cmdletContext.OAuth2Properties_TokenUrlParametersMap;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties.TokenUrlParametersMap = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_oAuth2Properties_TokenUrlParametersMap;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.Glue.Model.AuthorizationCodeProperties requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = null;
            
             // populate AuthorizationCodeProperties
            var requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = true;
            requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = new Amazon.Glue.Model.AuthorizationCodeProperties();
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode = null;
            if (cmdletContext.AuthorizationCodeProperties_AuthorizationCode != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode = cmdletContext.AuthorizationCodeProperties_AuthorizationCode;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.AuthorizationCode = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_AuthorizationCode;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri = null;
            if (cmdletContext.AuthorizationCodeProperties_RedirectUri != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri = cmdletContext.AuthorizationCodeProperties_RedirectUri;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties.RedirectUri = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties_authorizationCodeProperties_RedirectUri;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull = false;
            }
             // determine if requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties should be set to null
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodePropertiesIsNull)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties = null;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties.AuthorizationCodeProperties = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_AuthorizationCodeProperties;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.Glue.Model.OAuth2ClientApplication requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication = null;
            
             // populate OAuth2ClientApplication
            var requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull = true;
            requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication = new Amazon.Glue.Model.OAuth2ClientApplication();
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference = null;
            if (cmdletContext.OAuth2ClientApplication_AWSManagedClientApplicationReference != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference = cmdletContext.OAuth2ClientApplication_AWSManagedClientApplicationReference;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication.AWSManagedClientApplicationReference = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_AWSManagedClientApplicationReference;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId = null;
            if (cmdletContext.OAuth2ClientApplication_UserManagedClientApplicationClientId != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId = cmdletContext.OAuth2ClientApplication_UserManagedClientApplicationClientId;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication.UserManagedClientApplicationClientId = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication_oAuth2ClientApplication_UserManagedClientApplicationClientId;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull = false;
            }
             // determine if requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication should be set to null
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplicationIsNull)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication = null;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties.OAuth2ClientApplication = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2ClientApplication;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
            Amazon.Glue.Model.OAuth2Credentials requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials = null;
            
             // populate OAuth2Credentials
            var requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = true;
            requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials = new Amazon.Glue.Model.OAuth2Credentials();
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken = null;
            if (cmdletContext.OAuth2Credentials_AccessToken != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken = cmdletContext.OAuth2Credentials_AccessToken;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.AccessToken = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_AccessToken;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken = null;
            if (cmdletContext.OAuth2Credentials_JwtToken != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken = cmdletContext.OAuth2Credentials_JwtToken;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.JwtToken = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_JwtToken;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken = null;
            if (cmdletContext.OAuth2Credentials_RefreshToken != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken = cmdletContext.OAuth2Credentials_RefreshToken;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.RefreshToken = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_RefreshToken;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
            System.String requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret = null;
            if (cmdletContext.OAuth2Credentials_UserManagedClientApplicationClientSecret != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret = cmdletContext.OAuth2Credentials_UserManagedClientApplicationClientSecret;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials.UserManagedClientApplicationClientSecret = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials_oAuth2Credentials_UserManagedClientApplicationClientSecret;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull = false;
            }
             // determine if requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials should be set to null
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2CredentialsIsNull)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials = null;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties.OAuth2Credentials = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_testConnectionInput_AuthenticationConfiguration_OAuth2Properties_OAuth2Credentials;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull = false;
            }
             // determine if requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties should be set to null
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2PropertiesIsNull)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties = null;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties != null)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration.OAuth2Properties = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration_testConnectionInput_AuthenticationConfiguration_OAuth2Properties;
                requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull = false;
            }
             // determine if requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration should be set to null
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfigurationIsNull)
            {
                requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration = null;
            }
            if (requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration != null)
            {
                request.TestConnectionInput.AuthenticationConfiguration = requestTestConnectionInput_testConnectionInput_AuthenticationConfiguration;
                requestTestConnectionInputIsNull = false;
            }
             // determine if request.TestConnectionInput should be set to null
            if (requestTestConnectionInputIsNull)
            {
                request.TestConnectionInput = null;
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
        
        private Amazon.Glue.Model.TestConnectionResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.TestConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "TestConnection");
            try
            {
                #if DESKTOP
                return client.TestConnection(request);
                #elif CORECLR
                return client.TestConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.String ConnectionName { get; set; }
            public Amazon.Glue.AuthenticationType AuthenticationConfiguration_AuthenticationType { get; set; }
            public System.String BasicAuthenticationCredentials_Password { get; set; }
            public System.String BasicAuthenticationCredentials_Username { get; set; }
            public Dictionary<System.String, System.String> AuthenticationConfiguration_CustomAuthenticationCredential { get; set; }
            public System.String AuthenticationConfiguration_KmsKeyArn { get; set; }
            public System.String AuthorizationCodeProperties_AuthorizationCode { get; set; }
            public System.String AuthorizationCodeProperties_RedirectUri { get; set; }
            public System.String OAuth2ClientApplication_AWSManagedClientApplicationReference { get; set; }
            public System.String OAuth2ClientApplication_UserManagedClientApplicationClientId { get; set; }
            public System.String OAuth2Credentials_AccessToken { get; set; }
            public System.String OAuth2Credentials_JwtToken { get; set; }
            public System.String OAuth2Credentials_RefreshToken { get; set; }
            public System.String OAuth2Credentials_UserManagedClientApplicationClientSecret { get; set; }
            public Amazon.Glue.OAuth2GrantType OAuth2Properties_OAuth2GrantType { get; set; }
            public System.String OAuth2Properties_TokenUrl { get; set; }
            public Dictionary<System.String, System.String> OAuth2Properties_TokenUrlParametersMap { get; set; }
            public System.String AuthenticationConfiguration_SecretArn { get; set; }
            public Dictionary<System.String, System.String> TestConnectionInput_ConnectionProperty { get; set; }
            public Amazon.Glue.ConnectionType TestConnectionInput_ConnectionType { get; set; }
            public System.Func<Amazon.Glue.Model.TestConnectionResponse, TestGLUEConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
