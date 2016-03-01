/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Represents a put integration.
    /// </summary>
    [Cmdlet("Write", "AGIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutIntegrationResponse")]
    [AWSCmdlet("Invokes the PutIntegration operation against Amazon API Gateway.", Operation = new[] {"PutIntegration"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutIntegrationResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.PutIntegrationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteAGIntegrationCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
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
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>Represents request parameters that are sent with the backend request. Request parameters
        /// are represented as a key/value map, with a destination as the key and a source as
        /// the value. A source must match an existing method request parameter, or a static value.
        /// Static values must be enclosed with single quotes, and be pre-encoded based on their
        /// destination in the request. The destination must match the pattern <code>integration.request.{location}.{name}</code>,
        /// where <code>location</code> is either querystring, path, or header. <code>name</code>
        /// must be a valid, unique parameter name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestParameters")]
        public System.Collections.Hashtable RequestParameter { get; set; }
        #endregion
        
        #region Parameter RequestTemplate
        /// <summary>
        /// <para>
        /// <para>Specifies the templates used to transform the method request body. Request templates
        /// are represented as a key/value map, with a content-type as the key and a template
        /// as the value.</para>
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
        /// <para>Specifies a put integration request's API identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
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
        /// <para>Specifies a put integration input's Uniform Resource Identifier (URI). When the integration
        /// type is HTTP or AWS, this field is required.</para>
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
            
            if (this.CacheKeyParameter != null)
            {
                context.CacheKeyParameters = new List<System.String>(this.CacheKeyParameter);
            }
            context.CacheNamespace = this.CacheNamespace;
            context.TargetCredential = this.TargetCredential;
            context.HttpMethod = this.HttpMethod;
            context.IntegrationHttpMethod = this.IntegrationHttpMethod;
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
            context.Type = this.Type;
            context.Uri = this.Uri;
            
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
                var response = client.PutIntegration(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> CacheKeyParameters { get; set; }
            public System.String CacheNamespace { get; set; }
            public System.String TargetCredential { get; set; }
            public System.String HttpMethod { get; set; }
            public System.String IntegrationHttpMethod { get; set; }
            public Dictionary<System.String, System.String> RequestParameters { get; set; }
            public Dictionary<System.String, System.String> RequestTemplates { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RestApiId { get; set; }
            public Amazon.APIGateway.IntegrationType Type { get; set; }
            public System.String Uri { get; set; }
        }
        
    }
}
