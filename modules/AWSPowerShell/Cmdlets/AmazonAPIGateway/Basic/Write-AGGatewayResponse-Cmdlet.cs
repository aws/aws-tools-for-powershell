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
    /// Creates a customization of a <a>GatewayResponse</a> of a specified response type and
    /// status code on the given <a>RestApi</a>.
    /// </summary>
    [Cmdlet("Write", "AGGatewayResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutGatewayResponseResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway PutGatewayResponse API operation.", Operation = new[] {"PutGatewayResponse"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutGatewayResponseResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.PutGatewayResponseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteAGGatewayResponseCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ResponseParameter
        /// <summary>
        /// <para>
        /// <para><para>Response parameters (paths, query strings and headers) of the <a>GatewayResponse</a>
        /// as a string-to-string map of key-value pairs.</para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseParameters")]
        public System.Collections.Hashtable ResponseParameter { get; set; }
        #endregion
        
        #region Parameter ResponseTemplate
        /// <summary>
        /// <para>
        /// <para><para>Response templates of the <a>GatewayResponse</a> as a string-to-string map of key-value
        /// pairs.</para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseTemplates")]
        public System.Collections.Hashtable ResponseTemplate { get; set; }
        #endregion
        
        #region Parameter ResponseType
        /// <summary>
        /// <para>
        /// <para>[Required] 
        /// <para>The response type of the associated <a>GatewayResponse</a>. Valid values are <ul><li>ACCESS_DENIED</li><li>API_CONFIGURATION_ERROR</li><li>AUTHORIZER_FAILURE</li><li>
        /// AUTHORIZER_CONFIGURATION_ERROR</li><li>BAD_REQUEST_PARAMETERS</li><li>BAD_REQUEST_BODY</li><li>DEFAULT_4XX</li><li>DEFAULT_5XX</li><li>EXPIRED_TOKEN</li><li>INVALID_SIGNATURE</li><li>INTEGRATION_FAILURE</li><li>INTEGRATION_TIMEOUT</li><li>INVALID_API_KEY</li><li>MISSING_AUTHENTICATION_TOKEN</li><li>
        /// QUOTA_EXCEEDED</li><li>REQUEST_TOO_LARGE</li><li>RESOURCE_NOT_FOUND</li><li>THROTTLED</li><li>UNAUTHORIZED</li><li>UNSUPPORTED_MEDIA_TYPE</li></ul></para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.GatewayResponseType")]
        public Amazon.APIGateway.GatewayResponseType ResponseType { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>[Required] The string identifier of the associated <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter StatusCode
        /// <summary>
        /// <para>
        /// The HTTP status code of the <a>GatewayResponse</a>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StatusCode { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RestApiId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AGGatewayResponse (PutGatewayResponse)"))
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
            context.ResponseType = this.ResponseType;
            context.RestApiId = this.RestApiId;
            context.StatusCode = this.StatusCode;
            
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
            var request = new Amazon.APIGateway.Model.PutGatewayResponseRequest();
            
            if (cmdletContext.ResponseParameters != null)
            {
                request.ResponseParameters = cmdletContext.ResponseParameters;
            }
            if (cmdletContext.ResponseTemplates != null)
            {
                request.ResponseTemplates = cmdletContext.ResponseTemplates;
            }
            if (cmdletContext.ResponseType != null)
            {
                request.ResponseType = cmdletContext.ResponseType;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StatusCode != null)
            {
                request.StatusCode = cmdletContext.StatusCode;
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
        
        private Amazon.APIGateway.Model.PutGatewayResponseResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.PutGatewayResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "PutGatewayResponse");
            try
            {
                #if DESKTOP
                return client.PutGatewayResponse(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutGatewayResponseAsync(request);
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
            public Dictionary<System.String, System.String> ResponseParameters { get; set; }
            public Dictionary<System.String, System.String> ResponseTemplates { get; set; }
            public Amazon.APIGateway.GatewayResponseType ResponseType { get; set; }
            public System.String RestApiId { get; set; }
            public System.String StatusCode { get; set; }
        }
        
    }
}
