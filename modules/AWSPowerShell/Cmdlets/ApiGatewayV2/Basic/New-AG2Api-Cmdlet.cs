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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Creates an Api resource.
    /// </summary>
    [Cmdlet("New", "AG2Api", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateApiResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateApi API operation.", Operation = new[] {"CreateApi"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.CreateApiResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateApiResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.CreateApiResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAG2ApiCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        #region Parameter CorsConfiguration_AllowCredential
        /// <summary>
        /// <para>
        /// <para>Specifies whether credentials are included in the CORS request. Supported only for
        /// HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_AllowCredentials")]
        public System.Boolean? CorsConfiguration_AllowCredential { get; set; }
        #endregion
        
        #region Parameter CorsConfiguration_AllowHeader
        /// <summary>
        /// <para>
        /// <para>Represents a collection of allowed headers. Supported only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_AllowHeaders")]
        public System.String[] CorsConfiguration_AllowHeader { get; set; }
        #endregion
        
        #region Parameter CorsConfiguration_AllowMethod
        /// <summary>
        /// <para>
        /// <para>Represents a collection of allowed HTTP methods. Supported only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_AllowMethods")]
        public System.String[] CorsConfiguration_AllowMethod { get; set; }
        #endregion
        
        #region Parameter CorsConfiguration_AllowOrigin
        /// <summary>
        /// <para>
        /// <para>Represents a collection of allowed origins. Supported only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_AllowOrigins")]
        public System.String[] CorsConfiguration_AllowOrigin { get; set; }
        #endregion
        
        #region Parameter ApiKeySelectionExpression
        /// <summary>
        /// <para>
        /// <para>An API key selection expression. Supported only for WebSocket APIs. See <a href="https://docs.aws.amazon.com/apigateway/latest/developerguide/apigateway-websocket-api-selection-expressions.html#apigateway-websocket-api-apikey-selection-expressions">API
        /// Key Selection Expressions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApiKeySelectionExpression { get; set; }
        #endregion
        
        #region Parameter CredentialsArn
        /// <summary>
        /// <para>
        /// <para>This property is part of quick create. It specifies the credentials required for the
        /// integration, if any. For a Lambda integration, three options are available. To specify
        /// an IAM Role for API Gateway to assume, use the role's Amazon Resource Name (ARN).
        /// To require that the caller's identity be passed through from the request, specify
        /// arn:aws:iam::*:user/*. To use resource-based permissions on supported AWS services,
        /// specify null. Currently, this property is not used for HTTP integrations. Supported
        /// only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CredentialsArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisableExecuteApiEndpoint
        /// <summary>
        /// <para>
        /// <para>Specifies whether clients can invoke your API by using the default execute-api endpoint.
        /// By default, clients can invoke your API with the default https://{api_id}.execute-api.{region}.amazonaws.com
        /// endpoint. To require that clients use a custom domain name to invoke your API, disable
        /// the default endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableExecuteApiEndpoint { get; set; }
        #endregion
        
        #region Parameter DisableSchemaValidation
        /// <summary>
        /// <para>
        /// <para>Avoid validating models when creating a deployment. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableSchemaValidation { get; set; }
        #endregion
        
        #region Parameter CorsConfiguration_ExposeHeader
        /// <summary>
        /// <para>
        /// <para>Represents a collection of exposed headers. Supported only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_ExposeHeaders")]
        public System.String[] CorsConfiguration_ExposeHeader { get; set; }
        #endregion
        
        #region Parameter CorsConfiguration_MaxAge
        /// <summary>
        /// <para>
        /// <para>The number of seconds that the browser should cache preflight request results. Supported
        /// only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CorsConfiguration_MaxAge { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the API.</para>
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
        
        #region Parameter ProtocolType
        /// <summary>
        /// <para>
        /// <para>The API protocol.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.ProtocolType")]
        public Amazon.ApiGatewayV2.ProtocolType ProtocolType { get; set; }
        #endregion
        
        #region Parameter RouteKey
        /// <summary>
        /// <para>
        /// <para>This property is part of quick create. If you don't specify a routeKey, a default
        /// route of $default is created. The $default route acts as a catch-all for any request
        /// made to your API, for a particular stage. The $default route key can't be modified.
        /// You can add routes after creating the API, and you can update the route keys of additional
        /// routes. Supported only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RouteKey { get; set; }
        #endregion
        
        #region Parameter RouteSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The route selection expression for the API. For HTTP APIs, the routeSelectionExpression
        /// must be ${request.method} ${request.path}. If not provided, this will be the default
        /// for HTTP APIs. This property is required for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RouteSelectionExpression { get; set; }
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
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>This property is part of quick create. Quick create produces an API with an integration,
        /// a default catch-all route, and a default stage which is configured to automatically
        /// deploy changes. For HTTP integrations, specify a fully qualified URL. For Lambda integrations,
        /// specify a function ARN. The type of the integration will be HTTP_PROXY or AWS_PROXY,
        /// respectively. Supported only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>A version identifier for the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.CreateApiResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.CreateApiResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2Api (CreateApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.CreateApiResponse, NewAG2ApiCmdlet>(Select) ??
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
            context.ApiKeySelectionExpression = this.ApiKeySelectionExpression;
            context.CorsConfiguration_AllowCredential = this.CorsConfiguration_AllowCredential;
            if (this.CorsConfiguration_AllowHeader != null)
            {
                context.CorsConfiguration_AllowHeader = new List<System.String>(this.CorsConfiguration_AllowHeader);
            }
            if (this.CorsConfiguration_AllowMethod != null)
            {
                context.CorsConfiguration_AllowMethod = new List<System.String>(this.CorsConfiguration_AllowMethod);
            }
            if (this.CorsConfiguration_AllowOrigin != null)
            {
                context.CorsConfiguration_AllowOrigin = new List<System.String>(this.CorsConfiguration_AllowOrigin);
            }
            if (this.CorsConfiguration_ExposeHeader != null)
            {
                context.CorsConfiguration_ExposeHeader = new List<System.String>(this.CorsConfiguration_ExposeHeader);
            }
            context.CorsConfiguration_MaxAge = this.CorsConfiguration_MaxAge;
            context.CredentialsArn = this.CredentialsArn;
            context.Description = this.Description;
            context.DisableExecuteApiEndpoint = this.DisableExecuteApiEndpoint;
            context.DisableSchemaValidation = this.DisableSchemaValidation;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProtocolType = this.ProtocolType;
            #if MODULAR
            if (this.ProtocolType == null && ParameterWasBound(nameof(this.ProtocolType)))
            {
                WriteWarning("You are passing $null as a value for parameter ProtocolType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RouteKey = this.RouteKey;
            context.RouteSelectionExpression = this.RouteSelectionExpression;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Target = this.Target;
            context.Version = this.Version;
            
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
            var request = new Amazon.ApiGatewayV2.Model.CreateApiRequest();
            
            if (cmdletContext.ApiKeySelectionExpression != null)
            {
                request.ApiKeySelectionExpression = cmdletContext.ApiKeySelectionExpression;
            }
            
             // populate CorsConfiguration
            var requestCorsConfigurationIsNull = true;
            request.CorsConfiguration = new Amazon.ApiGatewayV2.Model.Cors();
            System.Boolean? requestCorsConfiguration_corsConfiguration_AllowCredential = null;
            if (cmdletContext.CorsConfiguration_AllowCredential != null)
            {
                requestCorsConfiguration_corsConfiguration_AllowCredential = cmdletContext.CorsConfiguration_AllowCredential.Value;
            }
            if (requestCorsConfiguration_corsConfiguration_AllowCredential != null)
            {
                request.CorsConfiguration.AllowCredentials = requestCorsConfiguration_corsConfiguration_AllowCredential.Value;
                requestCorsConfigurationIsNull = false;
            }
            List<System.String> requestCorsConfiguration_corsConfiguration_AllowHeader = null;
            if (cmdletContext.CorsConfiguration_AllowHeader != null)
            {
                requestCorsConfiguration_corsConfiguration_AllowHeader = cmdletContext.CorsConfiguration_AllowHeader;
            }
            if (requestCorsConfiguration_corsConfiguration_AllowHeader != null)
            {
                request.CorsConfiguration.AllowHeaders = requestCorsConfiguration_corsConfiguration_AllowHeader;
                requestCorsConfigurationIsNull = false;
            }
            List<System.String> requestCorsConfiguration_corsConfiguration_AllowMethod = null;
            if (cmdletContext.CorsConfiguration_AllowMethod != null)
            {
                requestCorsConfiguration_corsConfiguration_AllowMethod = cmdletContext.CorsConfiguration_AllowMethod;
            }
            if (requestCorsConfiguration_corsConfiguration_AllowMethod != null)
            {
                request.CorsConfiguration.AllowMethods = requestCorsConfiguration_corsConfiguration_AllowMethod;
                requestCorsConfigurationIsNull = false;
            }
            List<System.String> requestCorsConfiguration_corsConfiguration_AllowOrigin = null;
            if (cmdletContext.CorsConfiguration_AllowOrigin != null)
            {
                requestCorsConfiguration_corsConfiguration_AllowOrigin = cmdletContext.CorsConfiguration_AllowOrigin;
            }
            if (requestCorsConfiguration_corsConfiguration_AllowOrigin != null)
            {
                request.CorsConfiguration.AllowOrigins = requestCorsConfiguration_corsConfiguration_AllowOrigin;
                requestCorsConfigurationIsNull = false;
            }
            List<System.String> requestCorsConfiguration_corsConfiguration_ExposeHeader = null;
            if (cmdletContext.CorsConfiguration_ExposeHeader != null)
            {
                requestCorsConfiguration_corsConfiguration_ExposeHeader = cmdletContext.CorsConfiguration_ExposeHeader;
            }
            if (requestCorsConfiguration_corsConfiguration_ExposeHeader != null)
            {
                request.CorsConfiguration.ExposeHeaders = requestCorsConfiguration_corsConfiguration_ExposeHeader;
                requestCorsConfigurationIsNull = false;
            }
            System.Int32? requestCorsConfiguration_corsConfiguration_MaxAge = null;
            if (cmdletContext.CorsConfiguration_MaxAge != null)
            {
                requestCorsConfiguration_corsConfiguration_MaxAge = cmdletContext.CorsConfiguration_MaxAge.Value;
            }
            if (requestCorsConfiguration_corsConfiguration_MaxAge != null)
            {
                request.CorsConfiguration.MaxAge = requestCorsConfiguration_corsConfiguration_MaxAge.Value;
                requestCorsConfigurationIsNull = false;
            }
             // determine if request.CorsConfiguration should be set to null
            if (requestCorsConfigurationIsNull)
            {
                request.CorsConfiguration = null;
            }
            if (cmdletContext.CredentialsArn != null)
            {
                request.CredentialsArn = cmdletContext.CredentialsArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisableExecuteApiEndpoint != null)
            {
                request.DisableExecuteApiEndpoint = cmdletContext.DisableExecuteApiEndpoint.Value;
            }
            if (cmdletContext.DisableSchemaValidation != null)
            {
                request.DisableSchemaValidation = cmdletContext.DisableSchemaValidation.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProtocolType != null)
            {
                request.ProtocolType = cmdletContext.ProtocolType;
            }
            if (cmdletContext.RouteKey != null)
            {
                request.RouteKey = cmdletContext.RouteKey;
            }
            if (cmdletContext.RouteSelectionExpression != null)
            {
                request.RouteSelectionExpression = cmdletContext.RouteSelectionExpression;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.ApiGatewayV2.Model.CreateApiResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateApi");
            try
            {
                #if DESKTOP
                return client.CreateApi(request);
                #elif CORECLR
                return client.CreateApiAsync(request).GetAwaiter().GetResult();
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
            public System.String ApiKeySelectionExpression { get; set; }
            public System.Boolean? CorsConfiguration_AllowCredential { get; set; }
            public List<System.String> CorsConfiguration_AllowHeader { get; set; }
            public List<System.String> CorsConfiguration_AllowMethod { get; set; }
            public List<System.String> CorsConfiguration_AllowOrigin { get; set; }
            public List<System.String> CorsConfiguration_ExposeHeader { get; set; }
            public System.Int32? CorsConfiguration_MaxAge { get; set; }
            public System.String CredentialsArn { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DisableExecuteApiEndpoint { get; set; }
            public System.Boolean? DisableSchemaValidation { get; set; }
            public System.String Name { get; set; }
            public Amazon.ApiGatewayV2.ProtocolType ProtocolType { get; set; }
            public System.String RouteKey { get; set; }
            public System.String RouteSelectionExpression { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Target { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.CreateApiResponse, NewAG2ApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
