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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Sets up a method's integration.
    /// </summary>
    [Cmdlet("Write", "AGIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutIntegrationResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway PutIntegration API operation.", Operation = new[] {"PutIntegration"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutIntegrationResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.PutIntegrationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteAGIntegrationCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter CacheKeyParameter
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration input's cache key parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CacheKeyParameters")]
        public System.String[] CacheKeyParameter { get; set; }
        #endregion
        
        #region Parameter CacheNamespace
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration input's cache namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CacheNamespace { get; set; }
        #endregion
        
        #region Parameter ConnectionId
        /// <summary>
        /// <para>
        /// <para>The (<a href="http://docs.aws.amazon.com/apigateway/api-reference/resource/vpc-link/#id"><code>id</code></a>)
        /// of the <a>VpcLink</a> used for the integration when <code>connectionType=VPC_LINK</code>
        /// and undefined, otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConnectionId { get; set; }
        #endregion
        
        #region Parameter ConnectionType
        /// <summary>
        /// <para>
        /// <para>The type of the network connection to the integration endpoint. The valid value is
        /// <code>INTERNET</code> for connections through the public routable internet or <code>VPC_LINK</code>
        /// for private connections between API Gateway and a network load balancer in a VPC.
        /// The default value is <code>INTERNET</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.ConnectionType")]
        public Amazon.APIGateway.ConnectionType ConnectionType { get; set; }
        #endregion
        
        #region Parameter ContentHandling
        /// <summary>
        /// <para>
        /// <para>Specifies how to handle request payload content type conversions. Supported values
        /// are <code>CONVERT_TO_BINARY</code> and <code>CONVERT_TO_TEXT</code>, with the following
        /// behaviors:</para><ul><li><para><code>CONVERT_TO_BINARY</code>: Converts a request payload from a Base64-encoded string
        /// to the corresponding binary blob.</para></li><li><para><code>CONVERT_TO_TEXT</code>: Converts a request payload from a binary blob to a Base64-encoded
        /// string.</para></li></ul><para>If this property is not defined, the request payload will be passed through from the
        /// method request to integration request without modification, provided that the <code>passthroughBehaviors</code>
        /// is configured to support payload pass-through.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.ContentHandlingStrategy")]
        public Amazon.APIGateway.ContentHandlingStrategy ContentHandling { get; set; }
        #endregion
        
        #region Parameter TargetCredential
        /// <summary>
        /// <para>
        /// <para>Specifies whether credentials are required for a put integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetCredential { get; set; }
        #endregion
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration request's HTTP method.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter IntegrationHttpMethod
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration HTTP method. When the integration type is HTTP or AWS,
        /// this field is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IntegrationHttpMethod { get; set; }
        #endregion
        
        #region Parameter PassthroughBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies the pass-through behavior for incoming requests based on the Content-Type
        /// header in the request, and the available mapping templates specified as the <code>requestTemplates</code>
        /// property on the Integration resource. There are three valid values: <code>WHEN_NO_MATCH</code>,
        /// <code>WHEN_NO_TEMPLATES</code>, and <code>NEVER</code>. </para><ul><li><para><code>WHEN_NO_MATCH</code> passes the request body for unmapped content types through
        /// to the integration back end without transformation.</para></li><li><para><code>NEVER</code> rejects unmapped content types with an HTTP 415 'Unsupported Media
        /// Type' response.</para></li><li><para><code>WHEN_NO_TEMPLATES</code> allows pass-through when the integration has NO content
        /// types mapped to templates. However if there is at least one content type defined,
        /// unmapped content types will be rejected with the same 415 response.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PassthroughBehavior { get; set; }
        #endregion
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying request parameters that are passed from the method request
        /// to the back end. The key is an integration request parameter name and the associated
        /// value is a method request parameter value or static value that must be enclosed within
        /// single quotes and pre-encoded as required by the back end. The method request parameter
        /// value must match the pattern of <code>method.request.{location}.{name}</code>, where
        /// <code>location</code> is <code>querystring</code>, <code>path</code>, or <code>header</code>
        /// and <code>name</code> must be a valid and unique method request parameter name.</para>
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
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration request's resource ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration input's type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.IntegrationType")]
        public Amazon.APIGateway.IntegrationType Type { get; set; }
        #endregion
        
        #region Parameter Uri
        /// <summary>
        /// <para>
        /// <para>Specifies Uniform Resource Identifier (URI) of the integration endpoint.</para><ul><li><para> For <code>HTTP</code> or <code>HTTP_PROXY</code> integrations, the URI must be a
        /// fully formed, encoded HTTP(S) URL according to the <a target="_blank" href="https://en.wikipedia.org/wiki/Uniform_Resource_Identifier">RFC-3986
        /// specification</a>, for either standard integration, where <code>connectionType</code>
        /// is not <code>VPC_LINK</code>, or private integration, where <code>connectionType</code>
        /// is <code>VPC_LINK</code>. For a private HTTP integration, the URI is not used for
        /// routing. </para></li><li><para> For <code>AWS</code> or <code>AWS_PROXY</code> integrations, the URI is of the form
        /// <code>arn:aws:apigateway:{region}:{subdomain.service|service}:path|action/{service_api}</code>.
        /// Here, <code>{Region}</code> is the API Gateway region (e.g., <code>us-east-1</code>);
        /// <code>{service}</code> is the name of the integrated AWS service (e.g., <code>s3</code>);
        /// and <code>{subdomain}</code> is a designated subdomain supported by certain AWS service
        /// for fast host-name lookup. <code>action</code> can be used for an AWS service action-based
        /// API, using an <code>Action={name}&amp;{p1}={v1}&amp;p2={v2}...</code> query string.
        /// The ensuing <code>{service_api}</code> refers to a supported action <code>{name}</code>
        /// plus any required input parameters. Alternatively, <code>path</code> can be used for
        /// an AWS service path-based API. The ensuing <code>service_api</code> refers to the
        /// path to an AWS service resource, including the region of the integrated AWS service,
        /// if applicable. For example, for integration with the S3 API of <code><a href="http://docs.aws.amazon.com/AmazonS3/latest/API/RESTObjectGET.html">GetObject</a></code>,
        /// the <code>uri</code> can be either <code>arn:aws:apigateway:us-west-2:s3:action/GetObject&amp;Bucket={bucket}&amp;Key={key}</code>
        /// or <code>arn:aws:apigateway:us-west-2:s3:path/{bucket}/{key}</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Uri { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AGIntegration (PutIntegration)"))
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
            
            if (this.CacheKeyParameter != null)
            {
                context.CacheKeyParameters = new List<System.String>(this.CacheKeyParameter);
            }
            context.CacheNamespace = this.CacheNamespace;
            context.ConnectionId = this.ConnectionId;
            context.ConnectionType = this.ConnectionType;
            context.ContentHandling = this.ContentHandling;
            context.TargetCredential = this.TargetCredential;
            context.HttpMethod = this.HttpMethod;
            context.IntegrationHttpMethod = this.IntegrationHttpMethod;
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
            context.ResourceId = this.ResourceId;
            context.RestApiId = this.RestApiId;
            if (ParameterWasBound("TimeoutInMilli"))
                context.TimeoutInMillis = this.TimeoutInMilli;
            context.Type = this.Type;
            context.Uri = this.Uri;
            
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
            var request = new Amazon.APIGateway.Model.PutIntegrationRequest();
            
            if (cmdletContext.CacheKeyParameters != null)
            {
                request.CacheKeyParameters = cmdletContext.CacheKeyParameters;
            }
            if (cmdletContext.CacheNamespace != null)
            {
                request.CacheNamespace = cmdletContext.CacheNamespace;
            }
            if (cmdletContext.ConnectionId != null)
            {
                request.ConnectionId = cmdletContext.ConnectionId;
            }
            if (cmdletContext.ConnectionType != null)
            {
                request.ConnectionType = cmdletContext.ConnectionType;
            }
            if (cmdletContext.ContentHandling != null)
            {
                request.ContentHandling = cmdletContext.ContentHandling;
            }
            if (cmdletContext.TargetCredential != null)
            {
                request.Credentials = cmdletContext.TargetCredential;
            }
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.IntegrationHttpMethod != null)
            {
                request.IntegrationHttpMethod = cmdletContext.IntegrationHttpMethod;
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
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.TimeoutInMillis != null)
            {
                request.TimeoutInMillis = cmdletContext.TimeoutInMillis.Value;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.Uri != null)
            {
                request.Uri = cmdletContext.Uri;
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
        
        private Amazon.APIGateway.Model.PutIntegrationResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.PutIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "PutIntegration");
            try
            {
                #if DESKTOP
                return client.PutIntegration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutIntegrationAsync(request);
                return task.Result;
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
            public List<System.String> CacheKeyParameters { get; set; }
            public System.String CacheNamespace { get; set; }
            public System.String ConnectionId { get; set; }
            public Amazon.APIGateway.ConnectionType ConnectionType { get; set; }
            public Amazon.APIGateway.ContentHandlingStrategy ContentHandling { get; set; }
            public System.String TargetCredential { get; set; }
            public System.String HttpMethod { get; set; }
            public System.String IntegrationHttpMethod { get; set; }
            public System.String PassthroughBehavior { get; set; }
            public Dictionary<System.String, System.String> RequestParameters { get; set; }
            public Dictionary<System.String, System.String> RequestTemplates { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RestApiId { get; set; }
            public System.Int32? TimeoutInMillis { get; set; }
            public Amazon.APIGateway.IntegrationType Type { get; set; }
            public System.String Uri { get; set; }
        }
        
    }
}
