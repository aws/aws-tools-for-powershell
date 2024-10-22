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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Updates settings for a connection.
    /// </summary>
    [Cmdlet("Update", "EVBConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridge.Model.UpdateConnectionResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge UpdateConnection API operation.", Operation = new[] {"UpdateConnection"}, SelectReturnType = typeof(Amazon.EventBridge.Model.UpdateConnectionResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.UpdateConnectionResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.UpdateConnectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEVBConnectionCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
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
        /// <para>The value associated with teh API key to use for authorization.</para>
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
        /// <para>The type of authorization to use for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridge.ConnectionAuthorizationType")]
        public Amazon.EventBridge.ConnectionAuthorizationType AuthorizationType { get; set; }
        #endregion
        
        #region Parameter InvocationHttpParameters_BodyParameter
        /// <summary>
        /// <para>
        /// <para>Contains additional body string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_InvocationHttpParameters_BodyParameters")]
        public Amazon.EventBridge.Model.ConnectionBodyParameter[] InvocationHttpParameters_BodyParameter { get; set; }
        #endregion
        
        #region Parameter OAuthHttpParameters_BodyParameter
        /// <summary>
        /// <para>
        /// <para>Contains additional body string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_OAuthHttpParameters_BodyParameters")]
        public Amazon.EventBridge.Model.ConnectionBodyParameter[] OAuthHttpParameters_BodyParameter { get; set; }
        #endregion
        
        #region Parameter ClientParameters_ClientID
        /// <summary>
        /// <para>
        /// <para>The client ID to use for OAuth authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_ClientParameters_ClientID")]
        public System.String ClientParameters_ClientID { get; set; }
        #endregion
        
        #region Parameter ClientParameters_ClientSecret
        /// <summary>
        /// <para>
        /// <para>The client secret assciated with the client ID to use for OAuth authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_ClientParameters_ClientSecret")]
        public System.String ClientParameters_ClientSecret { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InvocationHttpParameters_HeaderParameter
        /// <summary>
        /// <para>
        /// <para>Contains additional header parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_InvocationHttpParameters_HeaderParameters")]
        public Amazon.EventBridge.Model.ConnectionHeaderParameter[] InvocationHttpParameters_HeaderParameter { get; set; }
        #endregion
        
        #region Parameter OAuthHttpParameters_HeaderParameter
        /// <summary>
        /// <para>
        /// <para>Contains additional header parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_OAuthHttpParameters_HeaderParameters")]
        public Amazon.EventBridge.Model.ConnectionHeaderParameter[] OAuthHttpParameters_HeaderParameter { get; set; }
        #endregion
        
        #region Parameter OAuthParameters_HttpMethod
        /// <summary>
        /// <para>
        /// <para>The method used to connect to the HTTP endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_HttpMethod")]
        [AWSConstantClassSource("Amazon.EventBridge.ConnectionOAuthHttpMethod")]
        public Amazon.EventBridge.ConnectionOAuthHttpMethod OAuthParameters_HttpMethod { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the connection to update.</para>
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
        /// <para>Contains additional query string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_InvocationHttpParameters_QueryStringParameters")]
        public Amazon.EventBridge.Model.ConnectionQueryStringParameter[] InvocationHttpParameters_QueryStringParameter { get; set; }
        #endregion
        
        #region Parameter OAuthHttpParameters_QueryStringParameter
        /// <summary>
        /// <para>
        /// <para>Contains additional query string parameters for the connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthParameters_OAuthParameters_OAuthHttpParameters_QueryStringParameters")]
        public Amazon.EventBridge.Model.ConnectionQueryStringParameter[] OAuthHttpParameters_QueryStringParameter { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.UpdateConnectionResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.UpdateConnectionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EVBConnection (UpdateConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.UpdateConnectionResponse, UpdateEVBConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizationType = this.AuthorizationType;
            context.ApiKeyAuthParameters_ApiKeyName = this.ApiKeyAuthParameters_ApiKeyName;
            context.ApiKeyAuthParameters_ApiKeyValue = this.ApiKeyAuthParameters_ApiKeyValue;
            context.BasicAuthParameters_Password = this.BasicAuthParameters_Password;
            context.BasicAuthParameters_Username = this.BasicAuthParameters_Username;
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
            var request = new Amazon.EventBridge.Model.UpdateConnectionRequest();
            
            if (cmdletContext.AuthorizationType != null)
            {
                request.AuthorizationType = cmdletContext.AuthorizationType;
            }
            
             // populate AuthParameters
            var requestAuthParametersIsNull = true;
            request.AuthParameters = new Amazon.EventBridge.Model.UpdateConnectionAuthRequestParameters();
            Amazon.EventBridge.Model.UpdateConnectionApiKeyAuthRequestParameters requestAuthParameters_authParameters_ApiKeyAuthParameters = null;
            
             // populate ApiKeyAuthParameters
            var requestAuthParameters_authParameters_ApiKeyAuthParametersIsNull = true;
            requestAuthParameters_authParameters_ApiKeyAuthParameters = new Amazon.EventBridge.Model.UpdateConnectionApiKeyAuthRequestParameters();
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
                requestAuthParametersIsNull = false;
            }
            Amazon.EventBridge.Model.UpdateConnectionBasicAuthRequestParameters requestAuthParameters_authParameters_BasicAuthParameters = null;
            
             // populate BasicAuthParameters
            var requestAuthParameters_authParameters_BasicAuthParametersIsNull = true;
            requestAuthParameters_authParameters_BasicAuthParameters = new Amazon.EventBridge.Model.UpdateConnectionBasicAuthRequestParameters();
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
                requestAuthParametersIsNull = false;
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
                requestAuthParametersIsNull = false;
            }
            Amazon.EventBridge.Model.UpdateConnectionOAuthRequestParameters requestAuthParameters_authParameters_OAuthParameters = null;
            
             // populate OAuthParameters
            var requestAuthParameters_authParameters_OAuthParametersIsNull = true;
            requestAuthParameters_authParameters_OAuthParameters = new Amazon.EventBridge.Model.UpdateConnectionOAuthRequestParameters();
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
            Amazon.EventBridge.Model.UpdateConnectionOAuthClientRequestParameters requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters = null;
            
             // populate ClientParameters
            var requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParametersIsNull = true;
            requestAuthParameters_authParameters_OAuthParameters_authParameters_OAuthParameters_ClientParameters = new Amazon.EventBridge.Model.UpdateConnectionOAuthClientRequestParameters();
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
                requestAuthParametersIsNull = false;
            }
             // determine if request.AuthParameters should be set to null
            if (requestAuthParametersIsNull)
            {
                request.AuthParameters = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
        
        private Amazon.EventBridge.Model.UpdateConnectionResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.UpdateConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "UpdateConnection");
            try
            {
                #if DESKTOP
                return client.UpdateConnection(request);
                #elif CORECLR
                return client.UpdateConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.Func<Amazon.EventBridge.Model.UpdateConnectionResponse, UpdateEVBConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
