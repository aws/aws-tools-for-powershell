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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Updates an Api resource.
    /// </summary>
    [Cmdlet("Update", "AG2Api", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdateApiResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdateApi API operation.", Operation = new[] {"UpdateApi"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.UpdateApiResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdateApiResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.UpdateApiResponse object containing multiple properties."
    )]
    public partial class UpdateAG2ApiCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>Represents a collection of allowed headers. Supported only for HTTP APIs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_AllowHeaders")]
        public System.String[] CorsConfiguration_AllowHeader { get; set; }
        #endregion
        
        #region Parameter CorsConfiguration_AllowMethod
        /// <summary>
        /// <para>
        /// <para>Represents a collection of allowed HTTP methods. Supported only for HTTP APIs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_AllowMethods")]
        public System.String[] CorsConfiguration_AllowMethod { get; set; }
        #endregion
        
        #region Parameter CorsConfiguration_AllowOrigin
        /// <summary>
        /// <para>
        /// <para>Represents a collection of allowed origins. Supported only for HTTP APIs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_AllowOrigins")]
        public System.String[] CorsConfiguration_AllowOrigin { get; set; }
        #endregion
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API identifier.</para>
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
        public System.String ApiId { get; set; }
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
        /// don't specify this parameter. Currently, this property is not used for HTTP integrations.
        /// If provided, this value replaces the credentials associated with the quick create
        /// integration. Supported only for HTTP APIs.</para>
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
        /// <para>Represents a collection of exposed headers. Supported only for HTTP APIs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CorsConfiguration_ExposeHeaders")]
        public System.String[] CorsConfiguration_ExposeHeader { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address types that can invoke your API or domain name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.IpAddressType")]
        public Amazon.ApiGatewayV2.IpAddressType IpAddressType { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RouteKey
        /// <summary>
        /// <para>
        /// <para>This property is part of quick create. If not specified, the route created using quick
        /// create is kept. Otherwise, this value replaces the route key of the quick create route.
        /// Additional routes may still be added after the API is updated. Supported only for
        /// HTTP APIs.</para>
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
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>This property is part of quick create. For HTTP integrations, specify a fully qualified
        /// URL. For Lambda integrations, specify a function ARN. The type of the integration
        /// will be HTTP_PROXY or AWS_PROXY, respectively. The value provided updates the integration
        /// URI and integration type. You can update a quick-created target, but you can't remove
        /// it from an API. Supported only for HTTP APIs.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.UpdateApiResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.UpdateApiResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApiId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2Api (UpdateApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.UpdateApiResponse, UpdateAG2ApiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.IpAddressType = this.IpAddressType;
            context.Name = this.Name;
            context.RouteKey = this.RouteKey;
            context.RouteSelectionExpression = this.RouteSelectionExpression;
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
            var request = new Amazon.ApiGatewayV2.Model.UpdateApiRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
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
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RouteKey != null)
            {
                request.RouteKey = cmdletContext.RouteKey;
            }
            if (cmdletContext.RouteSelectionExpression != null)
            {
                request.RouteSelectionExpression = cmdletContext.RouteSelectionExpression;
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
        
        private Amazon.ApiGatewayV2.Model.UpdateApiResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdateApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdateApi");
            try
            {
                return client.UpdateApiAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
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
            public Amazon.ApiGatewayV2.IpAddressType IpAddressType { get; set; }
            public System.String Name { get; set; }
            public System.String RouteKey { get; set; }
            public System.String RouteSelectionExpression { get; set; }
            public System.String Target { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.UpdateApiResponse, UpdateAG2ApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
