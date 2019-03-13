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
    /// Creates a new <a>RestApi</a> resource.
    /// </summary>
    [Cmdlet("New", "AGRestApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateRestApiResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateRestApi API operation.", Operation = new[] {"CreateRestApi"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateRestApiResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateRestApiResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGRestApiCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ApiKeySource
        /// <summary>
        /// <para>
        /// <para>The source of the API key for metering requests according to a usage plan. Valid values
        /// are: <ul><li><code>HEADER</code> to read the API key from the <code>X-API-Key</code>
        /// header of a request. </li><li><code>AUTHORIZER</code> to read the API key from the
        /// <code>UsageIdentifierKey</code> from a custom authorizer.</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.ApiKeySourceType")]
        public Amazon.APIGateway.ApiKeySourceType ApiKeySource { get; set; }
        #endregion
        
        #region Parameter BinaryMediaType
        /// <summary>
        /// <para>
        /// <para>The list of binary media types supported by the <a>RestApi</a>. By default, the <a>RestApi</a>
        /// supports only UTF-8-encoded text payloads.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BinaryMediaTypes")]
        public System.String[] BinaryMediaType { get; set; }
        #endregion
        
        #region Parameter CloneFrom
        /// <summary>
        /// <para>
        /// <para>The ID of the <a>RestApi</a> that you want to clone from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CloneFrom { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MinimumCompressionSize
        /// <summary>
        /// <para>
        /// <para>A nullable integer that is used to enable compression (with non-negative between 0
        /// and 10485760 (10M) bytes, inclusive) or disable compression (with a null value) on
        /// an API. When compression is enabled, compression or decompression is not applied on
        /// the payload if the payload size is smaller than this value. Setting it to zero allows
        /// compression for any payload size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MinimumCompressionSize { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>[Required] The name of the <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// A stringified JSON policy document that applies
        /// to this RestApi regardless of the caller and <a>Method</a> configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>A list of endpoint types of an API (<a>RestApi</a>) or its custom domain name (<a>DomainName</a>).
        /// For an edge-optimized API and its custom domain name, the endpoint type is <code>"EDGE"</code>.
        /// For a regional API and its custom domain name, the endpoint type is <code>REGIONAL</code>.
        /// For a private API, the endpoint type is <code>PRIVATE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EndpointConfiguration_Types")]
        public System.String[] EndpointConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>A version identifier for the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Version { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGRestApi (CreateRestApi)"))
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
            
            context.ApiKeySource = this.ApiKeySource;
            if (this.BinaryMediaType != null)
            {
                context.BinaryMediaTypes = new List<System.String>(this.BinaryMediaType);
            }
            context.CloneFrom = this.CloneFrom;
            context.Description = this.Description;
            if (this.EndpointConfiguration_Type != null)
            {
                context.EndpointConfiguration_Types = new List<System.String>(this.EndpointConfiguration_Type);
            }
            if (ParameterWasBound("MinimumCompressionSize"))
                context.MinimumCompressionSize = this.MinimumCompressionSize;
            context.Name = this.Name;
            context.Policy = this.Policy;
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
            var request = new Amazon.APIGateway.Model.CreateRestApiRequest();
            
            if (cmdletContext.ApiKeySource != null)
            {
                request.ApiKeySource = cmdletContext.ApiKeySource;
            }
            if (cmdletContext.BinaryMediaTypes != null)
            {
                request.BinaryMediaTypes = cmdletContext.BinaryMediaTypes;
            }
            if (cmdletContext.CloneFrom != null)
            {
                request.CloneFrom = cmdletContext.CloneFrom;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EndpointConfiguration
            bool requestEndpointConfigurationIsNull = true;
            request.EndpointConfiguration = new Amazon.APIGateway.Model.EndpointConfiguration();
            List<System.String> requestEndpointConfiguration_endpointConfiguration_Type = null;
            if (cmdletContext.EndpointConfiguration_Types != null)
            {
                requestEndpointConfiguration_endpointConfiguration_Type = cmdletContext.EndpointConfiguration_Types;
            }
            if (requestEndpointConfiguration_endpointConfiguration_Type != null)
            {
                request.EndpointConfiguration.Types = requestEndpointConfiguration_endpointConfiguration_Type;
                requestEndpointConfigurationIsNull = false;
            }
             // determine if request.EndpointConfiguration should be set to null
            if (requestEndpointConfigurationIsNull)
            {
                request.EndpointConfiguration = null;
            }
            if (cmdletContext.MinimumCompressionSize != null)
            {
                request.MinimumCompressionSize = cmdletContext.MinimumCompressionSize.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.APIGateway.Model.CreateRestApiResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateRestApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateRestApi");
            try
            {
                #if DESKTOP
                return client.CreateRestApi(request);
                #elif CORECLR
                return client.CreateRestApiAsync(request).GetAwaiter().GetResult();
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
            public Amazon.APIGateway.ApiKeySourceType ApiKeySource { get; set; }
            public List<System.String> BinaryMediaTypes { get; set; }
            public System.String CloneFrom { get; set; }
            public System.String Description { get; set; }
            public List<System.String> EndpointConfiguration_Types { get; set; }
            public System.Int32? MinimumCompressionSize { get; set; }
            public System.String Name { get; set; }
            public System.String Policy { get; set; }
            public System.String Version { get; set; }
        }
        
    }
}
