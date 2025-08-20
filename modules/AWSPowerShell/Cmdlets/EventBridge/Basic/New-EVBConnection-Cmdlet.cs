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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Creates a connection. A connection defines the authorization type and credentials
    /// to use for authorization with an API destination HTTP endpoint.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-target-connection.html">Connections
    /// for endpoint targets</a> in the <i>Amazon EventBridge User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EVBConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridge.Model.CreateConnectionResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge CreateConnection API operation.", Operation = new[] {"CreateConnection"}, SelectReturnType = typeof(Amazon.EventBridge.Model.CreateConnectionResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.CreateConnectionResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.CreateConnectionResponse object containing multiple properties."
    )]
    public partial class NewEVBConnectionCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiKeyAuthParameters_ApiKeyName
        /// <summary>
        /// <para>
        /// <para>The name of the API key to use for authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_ApiKeyAuthParameters_ApiKeyName")]
        public System.String ApiKeyAuthParameters_ApiKeyName { get; set; }
        #endregion
        
        #region Parameter ApiKeyAuthParameters_ApiKeyValue
        /// <summary>
        /// <para>
        /// <para>The value for the API key to use for authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_ApiKeyAuthParameters_ApiKeyValue")]
        public System.String ApiKeyAuthParameters_ApiKeyValue { get; set; }
        #endregion
        
        #region Parameter OAuthParameters_AuthorizationEndpoint
        /// <summary>
        /// <para>
        /// <para>The URL to the authorization endpoint when OAuth is specified as the authorization
        /// type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_AuthorizationEndpoint")]
        public System.String OAuthParameters_AuthorizationEndpoint { get; set; }
        #endregion
        
        #region Parameter AuthorizationType
        /// <summary>
        /// <para>
        /// <para>The type of authorization to use for the connection.</para><note><para>OAUTH tokens are refreshed when a 401 or 407 response is returned.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EventBridge.ConnectionAuthorizationType")]
        public Amazon.EventBridge.ConnectionAuthorizationType AuthorizationType { get; set; }
        #endregion
        
        #region Parameter InvocationHttpParameters_BodyParameter
        /// <summary>
        /// <para>
        /// <para>Any additional body string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_InvocationHttpParameters_BodyParameters")]
        public Amazon.EventBridge.Model.ConnectionBodyParameter[] InvocationHttpParameters_BodyParameter { get; set; }
        #endregion
        
        #region Parameter OAuthHttpParameters_BodyParameter
        /// <summary>
        /// <para>
        /// <para>Any additional body string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_OAuthHttpParameters_BodyParameters")]
        public Amazon.EventBridge.Model.ConnectionBodyParameter[] OAuthHttpParameters_BodyParameter { get; set; }
        #endregion
        
        #region Parameter ClientParameters_ClientID
        /// <summary>
        /// <para>
        /// <para>The client ID to use for OAuth authorization for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_ClientParameters_ClientID")]
        public System.String ClientParameters_ClientID { get; set; }
        #endregion
        
        #region Parameter ClientParameters_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret associated with the client ID to use for OAuth authorization for
        /// the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_ClientParameters_ClientSecret")]
        public System.String ClientParameters_ClientSecret { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the connection to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InvocationHttpParameters_HeaderParameter
        /// <summary>
        /// <para>
        /// <para>Any additional header parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_InvocationHttpParameters_HeaderParameters")]
        public Amazon.EventBridge.Model.ConnectionHeaderParameter[] InvocationHttpParameters_HeaderParameter { get; set; }
        #endregion
        
        #region Parameter OAuthHttpParameters_HeaderParameter
        /// <summary>
        /// <para>
        /// <para>Any additional header parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_OAuthHttpParameters_HeaderParameters")]
        public Amazon.EventBridge.Model.ConnectionHeaderParameter[] OAuthHttpParameters_HeaderParameter { get; set; }
        #endregion
        
        #region Parameter OAuthParameters_HttpMethod
        /// <summary>
        /// <para>
        /// <para>The method to use for the authorization request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_HttpMethod")]
        [AWSConstantClassSource("Amazon.EventBridge.ConnectionOAuthHttpMethod")]
        public Amazon.EventBridge.ConnectionOAuthHttpMethod OAuthParameters_HttpMethod { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS customer managed key for EventBridge to use, if you choose
        /// to use a customer managed key to encrypt this connection. The identifier can be the
        /// key Amazon Resource Name (ARN), KeyId, key alias, or key alias ARN.</para><para>If you do not specify a customer managed key identifier, EventBridge uses an Amazon
        /// Web Services owned key to encrypt the connection.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/viewing-keys.html">Identify
        /// and view keys</a> in the <i>Key Management Service Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the connection to create.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter BasicAuthParameters_Password
        /// <summary>
        /// <para>
        /// <para>The password associated with the user name to use for Basic authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_BasicAuthParameters_Password")]
        public System.String BasicAuthParameters_Password { get; set; }
        #endregion
        
        #region Parameter InvocationHttpParameters_QueryStringParameter
        /// <summary>
        /// <para>
        /// <para>Any additional query string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_InvocationHttpParameters_QueryStringParameters")]
        public Amazon.EventBridge.Model.ConnectionQueryStringParameter[] InvocationHttpParameters_QueryStringParameter { get; set; }
        #endregion
        
        #region Parameter OAuthHttpParameters_QueryStringParameter
        /// <summary>
        /// <para>
        /// <para>Any additional query string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_OAuthHttpParameters_QueryStringParameters")]
        public Amazon.EventBridge.Model.ConnectionQueryStringParameter[] OAuthHttpParameters_QueryStringParameter { get; set; }
        #endregion
        
        #region Parameter AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon VPC Lattice resource configuration for
        /// the resource endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Auth_Resource_Configuration")]
        public System.String AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn { get; set; }
        #endregion
        
        #region Parameter InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon VPC Lattice resource configuration for
        /// the resource endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Invocation_Resource_Configuration")]
        public System.String InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn { get; set; }
        #endregion
        
        #region Parameter BasicAuthParameters_Username
        /// <summary>
        /// <para>
        /// <para>The user name to use for Basic authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_BasicAuthParameters_Username")]
        public System.String BasicAuthParameters_Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.CreateConnectionResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.CreateConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EVBConnection (CreateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.CreateConnectionResponse, NewEVBConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthorizationType = this.AuthorizationType;
            #if MODULAR
            if (this.AuthorizationType == null && ParameterWasBound(nameof(this.AuthorizationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApiKeyAuthParameters_ApiKeyName = this.ApiKeyAuthParameters_ApiKeyName;
            context.ApiKeyAuthParameters_ApiKeyValue = this.ApiKeyAuthParameters_ApiKeyValue;
            context.BasicAuthParameters_Password = this.BasicAuthParameters_Password;
            context.BasicAuthParameters_Username = this.BasicAuthParameters_Username;
            context.AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn = this.AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn;
            if (this.InvocationHttpParameters_BodyParameter != null)
            {
                context.InvocationHttpParameters_BodyParameter = new List<Amazon.EventBridge.Model.ConnectionBodyParameter>(this.InvocationHttpParameters_BodyParameter);
            }
            if (this.InvocationHttpParameters_HeaderParameter != null)
            {
                context.InvocationHttpParameters_HeaderParameter = new List<Amazon.EventBridge.Model.ConnectionHeaderParameter>(this.InvocationHttpParameters_HeaderParameter);
            }
            if (this.InvocationHttpParameters_QueryStringParameter != null)
            {
                context.InvocationHttpParameters_QueryStringParameter = new List<Amazon.EventBridge.Model.ConnectionQueryStringParameter>(this.InvocationHttpParameters_QueryStringParameter);
            }
            context.OAuthParameters_AuthorizationEndpoint = this.OAuthParameters_AuthorizationEndpoint;
            context.ClientParameters_ClientID = this.ClientParameters_ClientID;
            context.ClientParameters_ClientSecret = this.ClientParameters_ClientSecret;
            context.OAuthParameters_HttpMethod = this.OAuthParameters_HttpMethod;
            if (this.OAuthHttpParameters_BodyParameter != null)
            {
                context.OAuthHttpParameters_BodyParameter = new List<Amazon.EventBridge.Model.ConnectionBodyParameter>(this.OAuthHttpParameters_BodyParameter);
            }
            if (this.OAuthHttpParameters_HeaderParameter != null)
            {
                context.OAuthHttpParameters_HeaderParameter = new List<Amazon.EventBridge.Model.ConnectionHeaderParameter>(this.OAuthHttpParameters_HeaderParameter);
            }
            if (this.OAuthHttpParameters_QueryStringParameter != null)
            {
                context.OAuthHttpParameters_QueryStringParameter = new List<Amazon.EventBridge.Model.ConnectionQueryStringParameter>(this.OAuthHttpParameters_QueryStringParameter);
            }
            context.Description = this.Description;
            context.InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn = this.InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridge.Model.CreateConnectionRequest();
            
            if (cmdletContext.AuthorizationType != null)
            {
                request.AuthorizationType = cmdletContext.AuthorizationType;
            }
            
             // populate AuthParameters
            request.AuthParameters = new Amazon.EventBridge.Model.CreateConnectionAuthRequestParameters();
            Amazon.EventBridge.Model.ConnectivityResourceParameters requestAuthParameters_authParameters_ConnectivityParameters = null;
            
             // populate ConnectivityParameters
            var requestAuthParameters_authParameters_ConnectivityParametersIsNull = true;
            requestAuthParameters_authParameters_ConnectivityParameters = new Amazon.EventBridge.Model.ConnectivityResourceParameters();
            Amazon.EventBridge.Model.ConnectivityResourceConfigurationArn requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters = null;
            
             // populate ResourceParameters
            var requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParametersIsNull = true;
            requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters = new Amazon.EventBridge.Model.ConnectivityResourceConfigurationArn();
            System.String requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters_authParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn = null;
            if (cmdletContext.AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn != null)
            {
                requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters_authParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn = cmdletContext.AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn;
            }
            if (requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters_authParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn != null)
            {
                requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters.ResourceConfigurationArn = requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters_authParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn;
                requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters should be set to null
            if (requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParametersIsNull)
            {
                requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters = null;
            }
            if (requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters != null)
            {
                requestAuthParameters_authParameters_ConnectivityParameters.ResourceParameters = requestAuthParameters_authParameters_ConnectivityParameters_authParameters_ConnectivityParameters_ResourceParameters;
                requestAuthParameters_authParameters_ConnectivityParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_ConnectivityParameters should be set to null
            if (requestAuthParameters_authParameters_ConnectivityParametersIsNull)
            {
                requestAuthParameters_authParameters_ConnectivityParameters = null;
            }
            if (requestAuthParameters_authParameters_ConnectivityParameters != null)
            {
                request.AuthParameters.ConnectivityParameters = requestAuthParameters_authParameters_ConnectivityParameters;
            }
            Amazon.EventBridge.Model.CreateConnectionApiKeyAuthRequestParameters requestAuthParameters_authParameters_ApiKeyAuthParameters = null;
            
             // populate ApiKeyAuthParameters
            var requestAuthParameters_authParameters_ApiKeyAuthParametersIsNull = true;
            requestAuthParameters_authParameters_ApiKeyAuthParameters = new Amazon.EventBridge.Model.CreateConnectionApiKeyAuthRequestParameters();
            System.String requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyName = null;
            if (cmdletContext.ApiKeyAuthParameters_ApiKeyName != null)
            {
                requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyName = cmdletContext.ApiKeyAuthParameters_ApiKeyName;
            }
            if (requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyName != null)
            {
                requestAuthParameters_authParameters_ApiKeyAuthParameters.ApiKeyName = requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyName;
                requestAuthParameters_authParameters_ApiKeyAuthParametersIsNull = false;
            }
            System.String requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyValue = null;
            if (cmdletContext.ApiKeyAuthParameters_ApiKeyValue != null)
            {
                requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyValue = cmdletContext.ApiKeyAuthParameters_ApiKeyValue;
            }
            if (requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyValue != null)
            {
                requestAuthParameters_authParameters_ApiKeyAuthParameters.ApiKeyValue = requestAuthParameters_authParameters_ApiKeyAuthParameters_apiKeyAuthParameters_ApiKeyValue;
                requestAuthParameters_authParameters_ApiKeyAuthParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_ApiKeyAuthParameters should be set to null
            if (requestAuthParameters_authParameters_ApiKeyAuthParametersIsNull)
            {
                requestAuthParameters_authParameters_ApiKeyAuthParameters = null;
            }
            if (requestAuthParameters_authParameters_ApiKeyAuthParameters != null)
            {
                request.AuthParameters.ApiKeyAuthParameters = requestAuthParameters_authParameters_ApiKeyAuthParameters;
            }
            Amazon.EventBridge.Model.CreateConnectionBasicAuthRequestParameters requestAuthParameters_authParameters_BasicAuthParameters = null;
            
             // populate BasicAuthParameters
            var requestAuthParameters_authParameters_BasicAuthParametersIsNull = true;
            requestAuthParameters_authParameters_BasicAuthParameters = new Amazon.EventBridge.Model.CreateConnectionBasicAuthRequestParameters();
            System.String requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Password = null;
            if (cmdletContext.BasicAuthParameters_Password != null)
            {
                requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Password = cmdletContext.BasicAuthParameters_Password;
            }
            if (requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Password != null)
            {
                requestAuthParameters_authParameters_BasicAuthParameters.Password = requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Password;
                requestAuthParameters_authParameters_BasicAuthParametersIsNull = false;
            }
            System.String requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Username = null;
            if (cmdletContext.BasicAuthParameters_Username != null)
            {
                requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Username = cmdletContext.BasicAuthParameters_Username;
            }
            if (requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Username != null)
            {
                requestAuthParameters_authParameters_BasicAuthParameters.Username = requestAuthParameters_authParameters_BasicAuthParameters_basicAuthParameters_Username;
                requestAuthParameters_authParameters_BasicAuthParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_BasicAuthParameters should be set to null
            if (requestAuthParameters_authParameters_BasicAuthParametersIsNull)
            {
                requestAuthParameters_authParameters_BasicAuthParameters = null;
            }
            if (requestAuthParameters_authParameters_BasicAuthParameters != null)
            {
                request.AuthParameters.BasicAuthParameters = requestAuthParameters_authParameters_BasicAuthParameters;
            }
            Amazon.EventBridge.Model.ConnectionHttpParameters requestAuthParameters_authParameters_InvocationHttpParameters = null;
            
             // populate InvocationHttpParameters
            var requestAuthParameters_authParameters_InvocationHttpParametersIsNull = true;
            requestAuthParameters_authParameters_InvocationHttpParameters = new Amazon.EventBridge.Model.ConnectionHttpParameters();
            List<Amazon.EventBridge.Model.ConnectionBodyParameter> requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_BodyParameter = null;
            if (cmdletContext.InvocationHttpParameters_BodyParameter != null)
            {
                requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_BodyParameter = cmdletContext.InvocationHttpParameters_BodyParameter;
            }
            if (requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_BodyParameter != null)
            {
                requestAuthParameters_authParameters_InvocationHttpParameters.BodyParameters = requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_BodyParameter;
                requestAuthParameters_authParameters_InvocationHttpParametersIsNull = false;
            }
            List<Amazon.EventBridge.Model.ConnectionHeaderParameter> requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_HeaderParameter = null;
            if (cmdletContext.InvocationHttpParameters_HeaderParameter != null)
            {
                requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_HeaderParameter = cmdletContext.InvocationHttpParameters_HeaderParameter;
            }
            if (requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_HeaderParameter != null)
            {
                requestAuthParameters_authParameters_InvocationHttpParameters.HeaderParameters = requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_HeaderParameter;
                requestAuthParameters_authParameters_InvocationHttpParametersIsNull = false;
            }
            List<Amazon.EventBridge.Model.ConnectionQueryStringParameter> requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_QueryStringParameter = null;
            if (cmdletContext.InvocationHttpParameters_QueryStringParameter != null)
            {
                requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_QueryStringParameter = cmdletContext.InvocationHttpParameters_QueryStringParameter;
            }
            if (requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_QueryStringParameter != null)
            {
                requestAuthParameters_authParameters_InvocationHttpParameters.QueryStringParameters = requestAuthParameters_authParameters_InvocationHttpParameters_invocationHttpParameters_QueryStringParameter;
                requestAuthParameters_authParameters_InvocationHttpParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_InvocationHttpParameters should be set to null
            if (requestAuthParameters_authParameters_InvocationHttpParametersIsNull)
            {
                requestAuthParameters_authParameters_InvocationHttpParameters = null;
            }
            if (requestAuthParameters_authParameters_InvocationHttpParameters != null)
            {
                request.AuthParameters.InvocationHttpParameters = requestAuthParameters_authParameters_InvocationHttpParameters;
            }
            Amazon.EventBridge.Model.CreateConnectionOAuthRequestParameters requestAuthParameters_authParameters_OAuthParameters = null;
            
             // populate OAuthParameters
            var requestAuthParameters_authParameters_OAuthParametersIsNull = true;
            requestAuthParameters_authParameters_OAuthParameters = new Amazon.EventBridge.Model.CreateConnectionOAuthRequestParameters();
            System.String requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_AuthorizationEndpoint = null;
            if (cmdletContext.OAuthParameters_AuthorizationEndpoint != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_AuthorizationEndpoint = cmdletContext.OAuthParameters_AuthorizationEndpoint;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_AuthorizationEndpoint != null)
            {
                requestAuthParameters_authParameters_OAuthParameters.AuthorizationEndpoint = requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_AuthorizationEndpoint;
                requestAuthParameters_authParameters_OAuthParametersIsNull = false;
            }
            Amazon.EventBridge.ConnectionOAuthHttpMethod requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_HttpMethod = null;
            if (cmdletContext.OAuthParameters_HttpMethod != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_HttpMethod = cmdletContext.OAuthParameters_HttpMethod;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_HttpMethod != null)
            {
                requestAuthParameters_authParameters_OAuthParameters.HttpMethod = requestAuthParameters_authParameters_OAuthParameters_oAuthParameters_HttpMethod;
                requestAuthParameters_authParameters_OAuthParametersIsNull = false;
            }
            Amazon.EventBridge.Model.CreateConnectionOAuthClientRequestParameters requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters = null;
            
             // populate ClientParameters
            var requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParametersIsNull = true;
            requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters = new Amazon.EventBridge.Model.CreateConnectionOAuthClientRequestParameters();
            System.String requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientID = null;
            if (cmdletContext.ClientParameters_ClientID != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientID = cmdletContext.ClientParameters_ClientID;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientID != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters.ClientID = requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientID;
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParametersIsNull = false;
            }
            System.String requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientSecret = null;
            if (cmdletContext.ClientParameters_ClientSecret != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientSecret = cmdletContext.ClientParameters_ClientSecret;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientSecret != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters.ClientSecret = requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters_clientParameters_ClientSecret;
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters should be set to null
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParametersIsNull)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters = null;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters != null)
            {
                requestAuthParameters_authParameters_OAuthParameters.ClientParameters = requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters;
                requestAuthParameters_authParameters_OAuthParametersIsNull = false;
            }
            Amazon.EventBridge.Model.ConnectionHttpParameters requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters = null;
            
             // populate OAuthHttpParameters
            var requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParametersIsNull = true;
            requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters = new Amazon.EventBridge.Model.ConnectionHttpParameters();
            List<Amazon.EventBridge.Model.ConnectionBodyParameter> requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_BodyParameter = null;
            if (cmdletContext.OAuthHttpParameters_BodyParameter != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_BodyParameter = cmdletContext.OAuthHttpParameters_BodyParameter;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_BodyParameter != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters.BodyParameters = requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_BodyParameter;
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParametersIsNull = false;
            }
            List<Amazon.EventBridge.Model.ConnectionHeaderParameter> requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_HeaderParameter = null;
            if (cmdletContext.OAuthHttpParameters_HeaderParameter != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_HeaderParameter = cmdletContext.OAuthHttpParameters_HeaderParameter;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_HeaderParameter != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters.HeaderParameters = requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_HeaderParameter;
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParametersIsNull = false;
            }
            List<Amazon.EventBridge.Model.ConnectionQueryStringParameter> requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_QueryStringParameter = null;
            if (cmdletContext.OAuthHttpParameters_QueryStringParameter != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_QueryStringParameter = cmdletContext.OAuthHttpParameters_QueryStringParameter;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_QueryStringParameter != null)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters.QueryStringParameters = requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters_oAuthHttpParameters_QueryStringParameter;
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters should be set to null
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParametersIsNull)
            {
                requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters = null;
            }
            if (requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters != null)
            {
                requestAuthParameters_authParameters_OAuthParameters.OAuthHttpParameters = requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_OAuthHttpParameters;
                requestAuthParameters_authParameters_OAuthParametersIsNull = false;
            }
             // determine if requestAuthParameters_authParameters_OAuthParameters should be set to null
            if (requestAuthParameters_authParameters_OAuthParametersIsNull)
            {
                requestAuthParameters_authParameters_OAuthParameters = null;
            }
            if (requestAuthParameters_authParameters_OAuthParameters != null)
            {
                request.AuthParameters.OAuthParameters = requestAuthParameters_authParameters_OAuthParameters;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate InvocationConnectivityParameters
            var requestInvocationConnectivityParametersIsNull = true;
            request.InvocationConnectivityParameters = new Amazon.EventBridge.Model.ConnectivityResourceParameters();
            Amazon.EventBridge.Model.ConnectivityResourceConfigurationArn requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters = null;
            
             // populate ResourceParameters
            var requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParametersIsNull = true;
            requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters = new Amazon.EventBridge.Model.ConnectivityResourceConfigurationArn();
            System.String requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters_invocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn = null;
            if (cmdletContext.InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn != null)
            {
                requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters_invocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn = cmdletContext.InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn;
            }
            if (requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters_invocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn != null)
            {
                requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters.ResourceConfigurationArn = requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters_invocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn;
                requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParametersIsNull = false;
            }
             // determine if requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters should be set to null
            if (requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParametersIsNull)
            {
                requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters = null;
            }
            if (requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters != null)
            {
                request.InvocationConnectivityParameters.ResourceParameters = requestInvocationConnectivityParameters_invocationConnectivityParameters_ResourceParameters;
                requestInvocationConnectivityParametersIsNull = false;
            }
             // determine if request.InvocationConnectivityParameters should be set to null
            if (requestInvocationConnectivityParametersIsNull)
            {
                request.InvocationConnectivityParameters = null;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.EventBridge.Model.CreateConnectionResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.CreateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "CreateConnection");
            try
            {
                #if DESKTOP
                return client.CreateConnection(request);
                #elif CORECLR
                return client.CreateConnectionAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EventBridge.ConnectionAuthorizationType AuthorizationType { get; set; }
            public System.String ApiKeyAuthParameters_ApiKeyName { get; set; }
            public System.String ApiKeyAuthParameters_ApiKeyValue { get; set; }
            public System.String BasicAuthParameters_Password { get; set; }
            public System.String BasicAuthParameters_Username { get; set; }
            public System.String AuthParameters_ConnectivityParameters_ResourceParameters_ResourceConfigurationArn { get; set; }
            public List<Amazon.EventBridge.Model.ConnectionBodyParameter> InvocationHttpParameters_BodyParameter { get; set; }
            public List<Amazon.EventBridge.Model.ConnectionHeaderParameter> InvocationHttpParameters_HeaderParameter { get; set; }
            public List<Amazon.EventBridge.Model.ConnectionQueryStringParameter> InvocationHttpParameters_QueryStringParameter { get; set; }
            public System.String OAuthParameters_AuthorizationEndpoint { get; set; }
            public System.String ClientParameters_ClientID { get; set; }
            public System.String ClientParameters_ClientSecret { get; set; }
            public Amazon.EventBridge.ConnectionOAuthHttpMethod OAuthParameters_HttpMethod { get; set; }
            public List<Amazon.EventBridge.Model.ConnectionBodyParameter> OAuthHttpParameters_BodyParameter { get; set; }
            public List<Amazon.EventBridge.Model.ConnectionHeaderParameter> OAuthHttpParameters_HeaderParameter { get; set; }
            public List<Amazon.EventBridge.Model.ConnectionQueryStringParameter> OAuthHttpParameters_QueryStringParameter { get; set; }
            public System.String Description { get; set; }
            public System.String InvocationConnectivityParameters_ResourceParameters_ResourceConfigurationArn { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.EventBridge.Model.CreateConnectionResponse, NewEVBConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
