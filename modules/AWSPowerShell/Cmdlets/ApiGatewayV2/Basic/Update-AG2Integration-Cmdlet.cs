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
    /// Updates an Integration.
    /// </summary>
    [Cmdlet("Update", "AG2Integration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdateIntegration API operation.", Operation = new[] {"UpdateIntegration"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAG2IntegrationCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC link for a private integration. Supported only for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter ConnectionType
        /// <summary>
        /// <para>
        /// <para>The type of the network connection to the integration endpoint. Specify INTERNET for
        /// connections through the public routable internet or VPC_LINK for private connections
        /// between API Gateway and resources in a VPC. The default value is INTERNET.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.ConnectionType")]
        public Amazon.ApiGatewayV2.ConnectionType ConnectionType { get; set; }
        #endregion
        
        #region Parameter ContentHandlingStrategy
        /// <summary>
        /// <para>
        /// <para>Supported only for WebSocket APIs. Specifies how to handle response payload content
        /// type conversions. Supported values are CONVERT_TO_BINARY and CONVERT_TO_TEXT, with
        /// the following behaviors:</para><para>CONVERT_TO_BINARY: Converts a response payload from a Base64-encoded string to the
        /// corresponding binary blob.</para><para>CONVERT_TO_TEXT: Converts a response payload from a binary blob to a Base64-encoded
        /// string.</para><para>If this property is not defined, the response payload will be passed through from
        /// the integration response to the route response or method response without modification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.ContentHandlingStrategy")]
        public Amazon.ApiGatewayV2.ContentHandlingStrategy ContentHandlingStrategy { get; set; }
        #endregion
        
        #region Parameter CredentialsArn
        /// <summary>
        /// <para>
        /// <para>Specifies the credentials required for the integration, if any. For AWS integrations,
        /// three options are available. To specify an IAM Role for API Gateway to assume, use
        /// the role's Amazon Resource Name (ARN). To require that the caller's identity be passed
        /// through from the request, specify the string arn:aws:iam::*:user/*. To use resource-based
        /// permissions on supported AWS services, specify null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CredentialsArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the integration</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IntegrationId
        /// <summary>
        /// <para>
        /// <para>The integration ID.</para>
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
        public System.String IntegrationId { get; set; }
        #endregion
        
        #region Parameter IntegrationMethod
        /// <summary>
        /// <para>
        /// <para>Specifies the integration's HTTP method type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntegrationMethod { get; set; }
        #endregion
        
        #region Parameter IntegrationType
        /// <summary>
        /// <para>
        /// <para>The integration type of an integration. One of the following:</para><para>AWS: for integrating the route or method request with an AWS service action, including
        /// the Lambda function-invoking action. With the Lambda function-invoking action, this
        /// is referred to as the Lambda custom integration. With any other AWS service action,
        /// this is known as AWS integration. Supported only for WebSocket APIs.</para><para>AWS_PROXY: for integrating the route or method request with the Lambda function-invoking
        /// action with the client request passed through as-is. This integration is also referred
        /// to as Lambda proxy integration.</para><para>HTTP: for integrating the route or method request with an HTTP endpoint. This integration
        /// is also referred to as the HTTP custom integration. Supported only for WebSocket APIs.</para><para>HTTP_PROXY: for integrating the route or method request with an HTTP endpoint, with
        /// the client request passed through as-is. This is also referred to as HTTP proxy integration.
        /// For HTTP API private integrations, use an HTTP_PROXY integration.</para><para>MOCK: for integrating the route or method request with API Gateway as a "loopback"
        /// endpoint without invoking any backend. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.IntegrationType")]
        public Amazon.ApiGatewayV2.IntegrationType IntegrationType { get; set; }
        #endregion
        
        #region Parameter IntegrationUri
        /// <summary>
        /// <para>
        /// <para>For a Lambda integration, specify the URI of a Lambda function.</para><para>For an HTTP integration, specify a fully-qualified URL.</para><para>For an HTTP API private integration, specify the ARN of an Application Load Balancer
        /// listener, Network Load Balancer listener, or AWS Cloud Map service. If you specify
        /// the ARN of an AWS Cloud Map service, API Gateway uses DiscoverInstances to identify
        /// resources. You can use query parameters to target specific resources. To learn more,
        /// see <a href="https://alpha-docs-aws.amazon.com/cloud-map/latest/api/API_DiscoverInstances.html">DiscoverInstances</a>.
        /// For private integrations, all resources must be owned by the same AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntegrationUri { get; set; }
        #endregion
        
        #region Parameter PassthroughBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies the pass-through behavior for incoming requests based on the Content-Type
        /// header in the request, and the available mapping templates specified as the requestTemplates
        /// property on the Integration resource. There are three valid values: WHEN_NO_MATCH,
        /// WHEN_NO_TEMPLATES, and NEVER. Supported only for WebSocket APIs.</para><para>WHEN_NO_MATCH passes the request body for unmapped content types through to the integration
        /// backend without transformation.</para><para>NEVER rejects unmapped content types with an HTTP 415 Unsupported Media Type response.</para><para>WHEN_NO_TEMPLATES allows pass-through when the integration has no content types mapped
        /// to templates. However, if there is at least one content type defined, unmapped content
        /// types will be rejected with the same HTTP 415 Unsupported Media Type response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.PassthroughBehavior")]
        public Amazon.ApiGatewayV2.PassthroughBehavior PassthroughBehavior { get; set; }
        #endregion
        
        #region Parameter PayloadFormatVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the format of the payload sent to an integration. Required for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PayloadFormatVersion { get; set; }
        #endregion
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying request parameters that are passed from the method request
        /// to the backend. The key is an integration request parameter name and the associated
        /// value is a method request parameter value or static value that must be enclosed within
        /// single quotes and pre-encoded as required by the backend. The method request parameter
        /// value must match the pattern of method.request.<replaceable>{location}</replaceable>.<replaceable>{name}</replaceable>
        ///               , where                   <replaceable>{location}</replaceable>    
        ///            is querystring, path, or header; and                   <replaceable>{name}</replaceable>
        ///                must be a valid and unique method request parameter name. Supported
        /// only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestParameters")]
        public System.Collections.Hashtable RequestParameter { get; set; }
        #endregion
        
        #region Parameter RequestTemplate
        /// <summary>
        /// <para>
        /// <para>Represents a map of Velocity templates that are applied on the request payload based
        /// on the value of the Content-Type header sent by the client. The content type value
        /// is the key in this map, and the template (as a String) is the value. Supported only
        /// for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestTemplates")]
        public System.Collections.Hashtable RequestTemplate { get; set; }
        #endregion
        
        #region Parameter TlsConfig_ServerNameToVerify
        /// <summary>
        /// <para>
        /// <para>If you specify a server name, API Gateway uses it to verify the hostname on the integration's
        /// certificate. The server name is also included in the TLS handshake to support Server
        /// Name Indication (SNI) or virtual hosting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TlsConfig_ServerNameToVerify { get; set; }
        #endregion
        
        #region Parameter TemplateSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The template selection expression for the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateSelectionExpression { get; set; }
        #endregion
        
        #region Parameter TimeoutInMilli
        /// <summary>
        /// <para>
        /// <para>Custom timeout between 50 and 29,000 milliseconds. The default value is 29,000 milliseconds
        /// or 29 seconds for WebSocket APIs. The default value is 5,000 milliseconds, or 5 seconds
        /// for HTTP APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutInMillis")]
        public System.Int32? TimeoutInMilli { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApiId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2Integration (UpdateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse, UpdateAG2IntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApiId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConnectionId = this.ConnectionId;
            context.ConnectionType = this.ConnectionType;
            context.ContentHandlingStrategy = this.ContentHandlingStrategy;
            context.CredentialsArn = this.CredentialsArn;
            context.Description = this.Description;
            context.IntegrationId = this.IntegrationId;
            #if MODULAR
            if (this.IntegrationId == null && ParameterWasBound(nameof(this.IntegrationId)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntegrationMethod = this.IntegrationMethod;
            context.IntegrationType = this.IntegrationType;
            context.IntegrationUri = this.IntegrationUri;
            context.PassthroughBehavior = this.PassthroughBehavior;
            context.PayloadFormatVersion = this.PayloadFormatVersion;
            if (this.RequestParameter != null)
            {
                context.RequestParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestParameter.Keys)
                {
                    context.RequestParameter.Add((String)hashKey, (String)(this.RequestParameter[hashKey]));
                }
            }
            if (this.RequestTemplate != null)
            {
                context.RequestTemplate = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestTemplate.Keys)
                {
                    context.RequestTemplate.Add((String)hashKey, (String)(this.RequestTemplate[hashKey]));
                }
            }
            context.TemplateSelectionExpression = this.TemplateSelectionExpression;
            context.TimeoutInMilli = this.TimeoutInMilli;
            context.TlsConfig_ServerNameToVerify = this.TlsConfig_ServerNameToVerify;
            
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
            var request = new Amazon.ApiGatewayV2.Model.UpdateIntegrationRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.ConnectionType != null)
            {
                request.ConnectionType = cmdletContext.ConnectionType;
            }
            if (cmdletContext.ContentHandlingStrategy != null)
            {
                request.ContentHandlingStrategy = cmdletContext.ContentHandlingStrategy;
            }
            if (cmdletContext.CredentialsArn != null)
            {
                request.CredentialsArn = cmdletContext.CredentialsArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IntegrationId != null)
            {
                request.IntegrationId = cmdletContext.IntegrationId;
            }
            if (cmdletContext.IntegrationMethod != null)
            {
                request.IntegrationMethod = cmdletContext.IntegrationMethod;
            }
            if (cmdletContext.IntegrationType != null)
            {
                request.IntegrationType = cmdletContext.IntegrationType;
            }
            if (cmdletContext.IntegrationUri != null)
            {
                request.IntegrationUri = cmdletContext.IntegrationUri;
            }
            if (cmdletContext.PassthroughBehavior != null)
            {
                request.PassthroughBehavior = cmdletContext.PassthroughBehavior;
            }
            if (cmdletContext.PayloadFormatVersion != null)
            {
                request.PayloadFormatVersion = cmdletContext.PayloadFormatVersion;
            }
            if (cmdletContext.RequestParameter != null)
            {
                request.RequestParameters = cmdletContext.RequestParameter;
            }
            if (cmdletContext.RequestTemplate != null)
            {
                request.RequestTemplates = cmdletContext.RequestTemplate;
            }
            if (cmdletContext.TemplateSelectionExpression != null)
            {
                request.TemplateSelectionExpression = cmdletContext.TemplateSelectionExpression;
            }
            if (cmdletContext.TimeoutInMilli != null)
            {
                request.TimeoutInMillis = cmdletContext.TimeoutInMilli.Value;
            }
            
             // populate TlsConfig
            var requestTlsConfigIsNull = true;
            request.TlsConfig = new Amazon.ApiGatewayV2.Model.TlsConfigInput();
            System.String requestTlsConfig_tlsConfig_ServerNameToVerify = null;
            if (cmdletContext.TlsConfig_ServerNameToVerify != null)
            {
                requestTlsConfig_tlsConfig_ServerNameToVerify = cmdletContext.TlsConfig_ServerNameToVerify;
            }
            if (requestTlsConfig_tlsConfig_ServerNameToVerify != null)
            {
                request.TlsConfig.ServerNameToVerify = requestTlsConfig_tlsConfig_ServerNameToVerify;
                requestTlsConfigIsNull = false;
            }
             // determine if request.TlsConfig should be set to null
            if (requestTlsConfigIsNull)
            {
                request.TlsConfig = null;
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
        
        private Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdateIntegration");
            try
            {
                #if DESKTOP
                return client.UpdateIntegration(request);
                #elif CORECLR
                return client.UpdateIntegrationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public System.String ConnectionId { get; set; }
            public Amazon.ApiGatewayV2.ConnectionType ConnectionType { get; set; }
            public Amazon.ApiGatewayV2.ContentHandlingStrategy ContentHandlingStrategy { get; set; }
            public System.String CredentialsArn { get; set; }
            public System.String Description { get; set; }
            public System.String IntegrationId { get; set; }
            public System.String IntegrationMethod { get; set; }
            public Amazon.ApiGatewayV2.IntegrationType IntegrationType { get; set; }
            public System.String IntegrationUri { get; set; }
            public Amazon.ApiGatewayV2.PassthroughBehavior PassthroughBehavior { get; set; }
            public System.String PayloadFormatVersion { get; set; }
            public Dictionary<System.String, System.String> RequestParameter { get; set; }
            public Dictionary<System.String, System.String> RequestTemplate { get; set; }
            public System.String TemplateSelectionExpression { get; set; }
            public System.Int32? TimeoutInMilli { get; set; }
            public System.String TlsConfig_ServerNameToVerify { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.UpdateIntegrationResponse, UpdateAG2IntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
