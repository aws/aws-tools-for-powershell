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
    /// Creates an IntegrationResponses.
    /// </summary>
    [Cmdlet("New", "AG2IntegrationResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateIntegrationResponse API operation.", Operation = new[] {"CreateIntegrationResponse"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAG2IntegrationResponseCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ContentHandlingStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies how to handle response payload content type conversions. Supported values
        /// are CONVERT_TO_BINARY and CONVERT_TO_TEXT, with the following behaviors:</para><para>CONVERT_TO_BINARY: Converts a response payload from a Base64-encoded string to the
        /// corresponding binary blob.</para><para>CONVERT_TO_TEXT: Converts a response payload from a binary blob to a Base64-encoded
        /// string.</para><para>If this property is not defined, the response payload will be passed through from
        /// the integration response to the route response or method response without modification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.ContentHandlingStrategy")]
        public Amazon.ApiGatewayV2.ContentHandlingStrategy ContentHandlingStrategy { get; set; }
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
        
        #region Parameter IntegrationResponseKey
        /// <summary>
        /// <para>
        /// <para>The integration response key.</para>
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
        public System.String IntegrationResponseKey { get; set; }
        #endregion
        
        #region Parameter ResponseParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying response parameters that are passed to the method response
        /// from the backend. The key is a method response header parameter name and the mapped
        /// value is an integration response header value, a static value enclosed within a pair
        /// of single quotes, or a JSON expression from the integration response body. The mapping
        /// key must match the pattern of method.response.header.{name}, where {name} is a valid
        /// and unique header name. The mapped non-static value must match the pattern of integration.response.header.{name}
        /// or integration.response.body.{JSON-expression}, where {name} is a valid and unique
        /// response header name and {JSON-expression} is a valid JSON expression without the
        /// $ prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseParameters")]
        public System.Collections.Hashtable ResponseParameter { get; set; }
        #endregion
        
        #region Parameter ResponseTemplate
        /// <summary>
        /// <para>
        /// <para>The collection of response templates for the integration response as a string-to-string
        /// map of key-value pairs. Response templates are represented as a key/value map, with
        /// a content-type as the key and a template as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResponseTemplates")]
        public System.Collections.Hashtable ResponseTemplate { get; set; }
        #endregion
        
        #region Parameter TemplateSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The template selection expression for the integration response. Supported only for
        /// WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateSelectionExpression { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2IntegrationResponse (CreateIntegrationResponse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse, NewAG2IntegrationResponseCmdlet>(Select) ??
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
            context.ContentHandlingStrategy = this.ContentHandlingStrategy;
            context.IntegrationId = this.IntegrationId;
            #if MODULAR
            if (this.IntegrationId == null && ParameterWasBound(nameof(this.IntegrationId)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntegrationResponseKey = this.IntegrationResponseKey;
            #if MODULAR
            if (this.IntegrationResponseKey == null && ParameterWasBound(nameof(this.IntegrationResponseKey)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationResponseKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResponseParameter != null)
            {
                context.ResponseParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseParameter.Keys)
                {
                    context.ResponseParameter.Add((String)hashKey, (System.String)(this.ResponseParameter[hashKey]));
                }
            }
            if (this.ResponseTemplate != null)
            {
                context.ResponseTemplate = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseTemplate.Keys)
                {
                    context.ResponseTemplate.Add((String)hashKey, (System.String)(this.ResponseTemplate[hashKey]));
                }
            }
            context.TemplateSelectionExpression = this.TemplateSelectionExpression;
            
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
            var request = new Amazon.ApiGatewayV2.Model.CreateIntegrationResponseRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.ContentHandlingStrategy != null)
            {
                request.ContentHandlingStrategy = cmdletContext.ContentHandlingStrategy;
            }
            if (cmdletContext.IntegrationId != null)
            {
                request.IntegrationId = cmdletContext.IntegrationId;
            }
            if (cmdletContext.IntegrationResponseKey != null)
            {
                request.IntegrationResponseKey = cmdletContext.IntegrationResponseKey;
            }
            if (cmdletContext.ResponseParameter != null)
            {
                request.ResponseParameters = cmdletContext.ResponseParameter;
            }
            if (cmdletContext.ResponseTemplate != null)
            {
                request.ResponseTemplates = cmdletContext.ResponseTemplate;
            }
            if (cmdletContext.TemplateSelectionExpression != null)
            {
                request.TemplateSelectionExpression = cmdletContext.TemplateSelectionExpression;
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
        
        private Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateIntegrationResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateIntegrationResponse");
            try
            {
                #if DESKTOP
                return client.CreateIntegrationResponse(request);
                #elif CORECLR
                return client.CreateIntegrationResponseAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ApiGatewayV2.ContentHandlingStrategy ContentHandlingStrategy { get; set; }
            public System.String IntegrationId { get; set; }
            public System.String IntegrationResponseKey { get; set; }
            public Dictionary<System.String, System.String> ResponseParameter { get; set; }
            public Dictionary<System.String, System.String> ResponseTemplate { get; set; }
            public System.String TemplateSelectionExpression { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.CreateIntegrationResponseResponse, NewAG2IntegrationResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
