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
    /// Updates an IntegrationResponses.
    /// </summary>
    [Cmdlet("Update", "AG2IntegrationResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdateIntegrationResponseResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdateIntegrationResponse API operation.", Operation = new[] {"UpdateIntegrationResponse"})]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdateIntegrationResponseResponse",
        "This cmdlet returns a Amazon.ApiGatewayV2.Model.UpdateIntegrationResponseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAG2IntegrationResponseCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
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
        
        #region Parameter IntegrationId
        /// <summary>
        /// <para>
        /// <para>The integration ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IntegrationId { get; set; }
        #endregion
        
        #region Parameter IntegrationResponseId
        /// <summary>
        /// <para>
        /// <para>The integration response ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IntegrationResponseId { get; set; }
        #endregion
        
        #region Parameter IntegrationResponseKey
        /// <summary>
        /// <para>
        /// <para>The integration response key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IntegrationResponseKey { get; set; }
        #endregion
        
        #region Parameter ResponseParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying response parameters that are passed to the method response
        /// from the backend. The key is a method response header parameter name and the mapped
        /// value is an integration response header value, a static value enclosed within a pair
        /// of single quotes, or a JSON expression from the integration response body. The mapping
        /// key must match the pattern of method.response.header.{name} , where name is a valid
        /// and unique header name. The mapped non-static value must match the pattern of integration.response.header.{name}
        ///  or integration.response.body.{JSON-expression} , where  {name}  is a valid and unique
        /// response header name and  {JSON-expression}  is a valid JSON expression without the
        /// $ prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("ResponseTemplates")]
        public System.Collections.Hashtable ResponseTemplate { get; set; }
        #endregion
        
        #region Parameter TemplateSelectionExpression
        /// <summary>
        /// <para>
        /// <para>The template selection expression for the integration response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateSelectionExpression { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("IntegrationResponseId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2IntegrationResponse (UpdateIntegrationResponse)"))
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
            context.ContentHandlingStrategy = this.ContentHandlingStrategy;
            context.IntegrationId = this.IntegrationId;
            context.IntegrationResponseId = this.IntegrationResponseId;
            context.IntegrationResponseKey = this.IntegrationResponseKey;
            if (this.ResponseParameter != null)
            {
                context.ResponseParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseParameter.Keys)
                {
                    context.ResponseParameters.Add((String)hashKey, (String)(this.ResponseParameter[hashKey]));
                }
            }
            if (this.ResponseTemplate != null)
            {
                context.ResponseTemplates = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseTemplate.Keys)
                {
                    context.ResponseTemplates.Add((String)hashKey, (String)(this.ResponseTemplate[hashKey]));
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
            var request = new Amazon.ApiGatewayV2.Model.UpdateIntegrationResponseRequest();
            
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
            if (cmdletContext.IntegrationResponseId != null)
            {
                request.IntegrationResponseId = cmdletContext.IntegrationResponseId;
            }
            if (cmdletContext.IntegrationResponseKey != null)
            {
                request.IntegrationResponseKey = cmdletContext.IntegrationResponseKey;
            }
            if (cmdletContext.ResponseParameters != null)
            {
                request.ResponseParameters = cmdletContext.ResponseParameters;
            }
            if (cmdletContext.ResponseTemplates != null)
            {
                request.ResponseTemplates = cmdletContext.ResponseTemplates;
            }
            if (cmdletContext.TemplateSelectionExpression != null)
            {
                request.TemplateSelectionExpression = cmdletContext.TemplateSelectionExpression;
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
        
        private Amazon.ApiGatewayV2.Model.UpdateIntegrationResponseResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdateIntegrationResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdateIntegrationResponse");
            try
            {
                #if DESKTOP
                return client.UpdateIntegrationResponse(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateIntegrationResponseAsync(request);
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
            public System.String ApiId { get; set; }
            public Amazon.ApiGatewayV2.ContentHandlingStrategy ContentHandlingStrategy { get; set; }
            public System.String IntegrationId { get; set; }
            public System.String IntegrationResponseId { get; set; }
            public System.String IntegrationResponseKey { get; set; }
            public Dictionary<System.String, System.String> ResponseParameters { get; set; }
            public Dictionary<System.String, System.String> ResponseTemplates { get; set; }
            public System.String TemplateSelectionExpression { get; set; }
        }
        
    }
}
