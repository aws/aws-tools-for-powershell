/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates an Integration.
    /// </summary>
    [Cmdlet("New", "AG2Integration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateIntegrationResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateIntegration API operation.", Operation = new[] {"CreateIntegration"})]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateIntegrationResponse",
        "This cmdlet returns a Amazon.ApiGatewayV2.Model.CreateIntegrationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAG2IntegrationCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The connection ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter ConnectionType
        /// <summary>
        /// <para>
        /// <para>The type of the network connection to the integration endpoint. Currently the only
        /// valid value is INTERNET, for connections through the public routable internet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.ConnectionType")]
        public Amazon.ApiGatewayV2.ConnectionType ConnectionType { get; set; }
        #endregion
        
        #region Parameter ContentHandlingStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies how to handle response payload content type conversions. Supported values
        /// are CONVERT_TO_BINARY and CONVERT_TO_TEXT, with the following behaviors:</para><para> CONVERT_TO_BINARY: Converts a response payload from a Base64-encoded string to the
        /// corresponding binary blob.</para><para> CONVERT_TO_TEXT: Converts a response payload from a binary blob to a Base64-encoded
        /// string.</para><para>If this property is not defined, the response payload will be passed through from
        /// the integration response to the route response or method response without modification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String CredentialsArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IntegrationMethod
        /// <summary>
        /// <para>
        /// <para>Specifies the integration's HTTP method type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IntegrationMethod { get; set; }
        #endregion
        
        #region Parameter IntegrationType
        /// <summary>
        /// <para>
        /// <para>The integration type of an integration. One of the following:</para><para> AWS: for integrating the route or method request with an AWS service action, including
        /// the Lambda function-invoking action. With the Lambda function-invoking action, this
        /// is referred to as the Lambda custom integration. With any other AWS service action,
        /// this is known as AWS integration.</para><para> AWS_PROXY: for integrating the route or method request with the Lambda function-invoking
        /// action with the client request passed through as-is. This integration is also referred
        /// to as Lambda proxy integration.</para><para> HTTP: for integrating the route or method request with an HTTP endpoint. This integration
        /// is also referred to as HTTP custom integration.</para><para> HTTP_PROXY: for integrating route or method request with an HTTP endpoint, with the
        /// client request passed through as-is. This is also referred to as HTTP proxy integration.</para><para> MOCK: for integrating the route or method request with API Gateway as a "loopback"
        /// endpoint without invoking any backend.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.IntegrationType")]
        public Amazon.ApiGatewayV2.IntegrationType IntegrationType { get; set; }
        #endregion
        
        #region Parameter IntegrationUri
        /// <summary>
        /// <para>
        /// <para>For a Lambda proxy integration, this is the URI of the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IntegrationUri { get; set; }
        #endregion
        
        #region Parameter PassthroughBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies the pass-through behavior for incoming requests based on the Content-Type
        /// header in the request, and the available mapping templates specified as the requestTemplates
        /// property on the Integration resource. There are three valid values: WHEN_NO_MATCH,
        /// WHEN_NO_TEMPLATES, and NEVER.</para><para> WHEN_NO_MATCH passes the request body for unmapped content types through to the integration
        /// backend without transformation.</para><para> NEVER rejects unmapped content types with an HTTP 415 Unsupported Media Type response.</para><para> WHEN_NO_TEMPLATES allows pass-through when the integration has no content types mapped
        /// to templates. However, if there is at least one content type defined, unmapped content
        /// types will be rejected with the same HTTP 415 Unsupported Media Type response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.PassthroughBehavior")]
        public Amazon.ApiGatewayV2.PassthroughBehavior PassthroughBehavior { get; set; }
        #endregion
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying request parameters that are passed from the method request
        /// to the backend. The key is an integration request parameter name and the associated
        /// value is a method request parameter value or static value that must be enclosed within
        /// single quotes and pre-encoded as required by the backend. The method request parameter
        /// value must match the pattern of method.request.{location}.{name} , where  {location}
        ///  is querystring, path, or header; and  {name}  must be a valid and unique method request
        /// parameter name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestParameters")]
        public System.Collections.Hashtable RequestParameter { get; set; }
        #endregion
        
        #region Parameter RequestTemplate
        /// <summary>
        /// <para>
        /// <para>Represents a map of Velocity templates that are applied on the request payload based
        /// on the value of the Content-Type header sent by the client. The content type value
        /// is the key in this map, and the template (as a String) is the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestTemplates")]
        public System.Collections.Hashtable RequestTemplate { get; set; }
        #endregion
        
        #region Parameter TemplateSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The template selection expression for the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateSelectionExpression { get; set; }
        #endregion
        
        #region Parameter TimeoutInMilli
        /// <summary>
        /// <para>
        /// <para>Custom timeout between 50 and 29,000 milliseconds. The default value is 29,000 milliseconds
        /// or 29 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TimeoutInMillis")]
        public System.Int32 TimeoutInMilli { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApiId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2Integration (CreateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApiId = this.ApiId;
            context.ConnectionId = this.ConnectionId;
            context.ConnectionType = this.ConnectionType;
            context.ContentHandlingStrategy = this.ContentHandlingStrategy;
            context.CredentialsArn = this.CredentialsArn;
            context.Description = this.Description;
            context.IntegrationMethod = this.IntegrationMethod;
            context.IntegrationType = this.IntegrationType;
            context.IntegrationUri = this.IntegrationUri;
            context.PassthroughBehavior = this.PassthroughBehavior;
            if (this.RequestParameter != null)
            {
                context.RequestParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestParameter.Keys)
                {
                    context.RequestParameters.Add((String)hashKey, (String)(this.RequestParameter[hashKey]));
                }
            }
            if (this.RequestTemplate != null)
            {
                context.RequestTemplates = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestTemplate.Keys)
                {
                    context.RequestTemplates.Add((String)hashKey, (String)(this.RequestTemplate[hashKey]));
                }
            }
            context.TemplateSelectionExpression = this.TemplateSelectionExpression;
            if (ParameterWasBound("TimeoutInMilli"))
                context.TimeoutInMillis = this.TimeoutInMilli;
            
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
            var request = new Amazon.ApiGatewayV2.Model.CreateIntegrationRequest();
            
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
            if (cmdletContext.RequestParameters != null)
            {
                request.RequestParameters = cmdletContext.RequestParameters;
            }
            if (cmdletContext.RequestTemplates != null)
            {
                request.RequestTemplates = cmdletContext.RequestTemplates;
            }
            if (cmdletContext.TemplateSelectionExpression != null)
            {
                request.TemplateSelectionExpression = cmdletContext.TemplateSelectionExpression;
            }
            if (cmdletContext.TimeoutInMillis != null)
            {
                request.TimeoutInMillis = cmdletContext.TimeoutInMillis.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.ApiGatewayV2.Model.CreateIntegrationResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateIntegration");
            try
            {
                #if DESKTOP
                return client.CreateIntegration(request);
                #elif CORECLR
                return client.CreateIntegrationAsync(request).GetAwaiter().GetResult();
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
            public System.String IntegrationMethod { get; set; }
            public Amazon.ApiGatewayV2.IntegrationType IntegrationType { get; set; }
            public System.String IntegrationUri { get; set; }
            public Amazon.ApiGatewayV2.PassthroughBehavior PassthroughBehavior { get; set; }
            public Dictionary<System.String, System.String> RequestParameters { get; set; }
            public Dictionary<System.String, System.String> RequestTemplates { get; set; }
            public System.String TemplateSelectionExpression { get; set; }
            public System.Int32? TimeoutInMillis { get; set; }
        }
        
    }
}
