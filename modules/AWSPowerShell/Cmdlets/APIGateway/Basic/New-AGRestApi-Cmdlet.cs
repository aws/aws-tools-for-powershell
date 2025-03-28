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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Creates a new RestApi resource.
    /// </summary>
    [Cmdlet("New", "AGRestApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateRestApiResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateRestApi API operation.", Operation = new[] {"CreateRestApi"}, SelectReturnType = typeof(Amazon.APIGateway.Model.CreateRestApiResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateRestApiResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.CreateRestApiResponse object containing multiple properties."
    )]
    public partial class NewAGRestApiCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiKeySource
        /// <summary>
        /// <para>
        /// <para>The source of the API key for metering requests according to a usage plan. Valid values
        /// are: <c>HEADER</c> to read the API key from the <c>X-API-Key</c> header of a request.
        /// <c>AUTHORIZER</c> to read the API key from the <c>UsageIdentifierKey</c> from a custom
        /// authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIGateway.ApiKeySourceType")]
        public Amazon.APIGateway.ApiKeySourceType ApiKeySource { get; set; }
        #endregion
        
        #region Parameter BinaryMediaType
        /// <summary>
        /// <para>
        /// <para>The list of binary media types supported by the RestApi. By default, the RestApi supports
        /// only UTF-8-encoded text payloads.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BinaryMediaTypes")]
        public System.String[] BinaryMediaType { get; set; }
        #endregion
        
        #region Parameter CloneFrom
        /// <summary>
        /// <para>
        /// <para>The ID of the RestApi that you want to clone from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloneFrom { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the RestApi.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisableExecuteApiEndpoint
        /// <summary>
        /// <para>
        /// <para>Specifies whether clients can invoke your API by using the default <c>execute-api</c>
        /// endpoint. By default, clients can invoke your API with the default <c>https://{api_id}.execute-api.{region}.amazonaws.com</c>
        /// endpoint. To require that clients use a custom domain name to invoke your API, disable
        /// the default endpoint</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableExecuteApiEndpoint { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address types that can invoke an API (RestApi) or a DomainName. Use <c>ipv4</c>
        /// to allow only IPv4 addresses to invoke an API or DomainName, or use <c>dualstack</c>
        /// to allow both IPv4 and IPv6 addresses to invoke an API or a DomainName. For the <c>PRIVATE</c>
        /// endpoint type, only <c>dualstack</c> is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIGateway.IpAddressType")]
        public Amazon.APIGateway.IpAddressType EndpointConfiguration_IpAddressType { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinimumCompressionSize { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the RestApi.</para>
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
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>A stringified JSON policy document that applies to this RestApi regardless of the
        /// caller and Method configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value map of strings. The valid character set is [a-zA-Z+-=._:/]. The tag
        /// key can be up to 128 characters and must not start with <c>aws:</c>. The tag value
        /// can be up to 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter EndpointConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>A list of endpoint types of an API (RestApi) or its custom domain name (DomainName).
        /// For an edge-optimized API and its custom domain name, the endpoint type is <c>"EDGE"</c>.
        /// For a regional API and its custom domain name, the endpoint type is <c>REGIONAL</c>.
        /// For a private API, the endpoint type is <c>PRIVATE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfiguration_Types")]
        public System.String[] EndpointConfiguration_Type { get; set; }
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
        
        #region Parameter EndpointConfiguration_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>A list of VpcEndpointIds of an API (RestApi) against which to create Route53 ALIASes.
        /// It is only supported for <c>PRIVATE</c> endpoint type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfiguration_VpcEndpointIds")]
        public System.String[] EndpointConfiguration_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.CreateRestApiResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.CreateRestApiResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGRestApi (CreateRestApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.CreateRestApiResponse, NewAGRestApiCmdlet>(Select) ??
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
            context.ApiKeySource = this.ApiKeySource;
            if (this.BinaryMediaType != null)
            {
                context.BinaryMediaType = new List<System.String>(this.BinaryMediaType);
            }
            context.CloneFrom = this.CloneFrom;
            context.Description = this.Description;
            context.DisableExecuteApiEndpoint = this.DisableExecuteApiEndpoint;
            context.EndpointConfiguration_IpAddressType = this.EndpointConfiguration_IpAddressType;
            if (this.EndpointConfiguration_Type != null)
            {
                context.EndpointConfiguration_Type = new List<System.String>(this.EndpointConfiguration_Type);
            }
            if (this.EndpointConfiguration_VpcEndpointId != null)
            {
                context.EndpointConfiguration_VpcEndpointId = new List<System.String>(this.EndpointConfiguration_VpcEndpointId);
            }
            context.MinimumCompressionSize = this.MinimumCompressionSize;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            if (cmdletContext.BinaryMediaType != null)
            {
                request.BinaryMediaTypes = cmdletContext.BinaryMediaType;
            }
            if (cmdletContext.CloneFrom != null)
            {
                request.CloneFrom = cmdletContext.CloneFrom;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisableExecuteApiEndpoint != null)
            {
                request.DisableExecuteApiEndpoint = cmdletContext.DisableExecuteApiEndpoint.Value;
            }
            
             // populate EndpointConfiguration
            var requestEndpointConfigurationIsNull = true;
            request.EndpointConfiguration = new Amazon.APIGateway.Model.EndpointConfiguration();
            Amazon.APIGateway.IpAddressType requestEndpointConfiguration_endpointConfiguration_IpAddressType = null;
            if (cmdletContext.EndpointConfiguration_IpAddressType != null)
            {
                requestEndpointConfiguration_endpointConfiguration_IpAddressType = cmdletContext.EndpointConfiguration_IpAddressType;
            }
            if (requestEndpointConfiguration_endpointConfiguration_IpAddressType != null)
            {
                request.EndpointConfiguration.IpAddressType = requestEndpointConfiguration_endpointConfiguration_IpAddressType;
                requestEndpointConfigurationIsNull = false;
            }
            List<System.String> requestEndpointConfiguration_endpointConfiguration_Type = null;
            if (cmdletContext.EndpointConfiguration_Type != null)
            {
                requestEndpointConfiguration_endpointConfiguration_Type = cmdletContext.EndpointConfiguration_Type;
            }
            if (requestEndpointConfiguration_endpointConfiguration_Type != null)
            {
                request.EndpointConfiguration.Types = requestEndpointConfiguration_endpointConfiguration_Type;
                requestEndpointConfigurationIsNull = false;
            }
            List<System.String> requestEndpointConfiguration_endpointConfiguration_VpcEndpointId = null;
            if (cmdletContext.EndpointConfiguration_VpcEndpointId != null)
            {
                requestEndpointConfiguration_endpointConfiguration_VpcEndpointId = cmdletContext.EndpointConfiguration_VpcEndpointId;
            }
            if (requestEndpointConfiguration_endpointConfiguration_VpcEndpointId != null)
            {
                request.EndpointConfiguration.VpcEndpointIds = requestEndpointConfiguration_endpointConfiguration_VpcEndpointId;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            public List<System.String> BinaryMediaType { get; set; }
            public System.String CloneFrom { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DisableExecuteApiEndpoint { get; set; }
            public Amazon.APIGateway.IpAddressType EndpointConfiguration_IpAddressType { get; set; }
            public List<System.String> EndpointConfiguration_Type { get; set; }
            public List<System.String> EndpointConfiguration_VpcEndpointId { get; set; }
            public System.Int32? MinimumCompressionSize { get; set; }
            public System.String Name { get; set; }
            public System.String Policy { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.APIGateway.Model.CreateRestApiResponse, NewAGRestApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
