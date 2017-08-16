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
    /// Add a method to an existing <a>Resource</a> resource.
    /// </summary>
    [Cmdlet("Write", "AGMethod", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutMethodResponse")]
    [AWSCmdlet("Invokes the PutMethod operation against Amazon API Gateway.", Operation = new[] {"PutMethod"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutMethodResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.PutMethodResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteAGMethodCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter ApiKeyRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether the method required a valid <a>ApiKey</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApiKeyRequired { get; set; }
        #endregion
        
        #region Parameter AuthorizationType
        /// <summary>
        /// <para>
        /// <para>The method's authorization type. Valid values are <code>NONE</code> for open access,
        /// <code>AWS_IAM</code> for using AWS IAM permissions, <code>CUSTOM</code> for using
        /// a custom authorizer, or <code>COGNITO_USER_POOLS</code> for using a Cognito user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthorizationType { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// <para>Specifies the identifier of an <a>Authorizer</a> to use on this Method, if the type
        /// is CUSTOM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerId { get; set; }
        #endregion
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>Specifies the method request's HTTP method type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter OperationName
        /// <summary>
        /// <para>
        /// <para>A human-friendly operation identifier for the method. For example, you can assign
        /// the <code>operationName</code> of <code>ListPets</code> for the <code>GET /pets</code>
        /// method in <a href="http://petstore-demo-endpoint.execute-api.com/petstore/pets">PetStore</a>
        /// example.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OperationName { get; set; }
        #endregion
        
        #region Parameter RequestModel
        /// <summary>
        /// <para>
        /// <para>Specifies the <a>Model</a> resources used for the request's content type. Request
        /// models are represented as a key/value map, with a content type as the key and a <a>Model</a>
        /// name as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestModels")]
        public System.Collections.Hashtable RequestModel { get; set; }
        #endregion
        
        #region Parameter RequestParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map defining required or optional method request parameters that can be
        /// accepted by Amazon API Gateway. A key defines a method request parameter name matching
        /// the pattern of <code>method.request.{location}.{name}</code>, where <code>location</code>
        /// is <code>querystring</code>, <code>path</code>, or <code>header</code> and <code>name</code>
        /// is a valid and unique parameter name. The value associated with the key is a Boolean
        /// flag indicating whether the parameter is required (<code>true</code>) or optional
        /// (<code>false</code>). The method request parameter names defined here are available
        /// in <a>Integration</a> to be mapped to integration request parameters or body-mapping
        /// templates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestParameters")]
        public System.Collections.Hashtable RequestParameter { get; set; }
        #endregion
        
        #region Parameter RequestValidatorId
        /// <summary>
        /// <para>
        /// <para>The identifier of a <a>RequestValidator</a> for validating the method request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RequestValidatorId { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The <a>Resource</a> identifier for the new <a>Method</a> resource.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AGMethod (PutMethod)"))
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
            
            if (ParameterWasBound("ApiKeyRequired"))
                context.ApiKeyRequired = this.ApiKeyRequired;
            context.AuthorizationType = this.AuthorizationType;
            context.AuthorizerId = this.AuthorizerId;
            context.HttpMethod = this.HttpMethod;
            context.OperationName = this.OperationName;
            if (this.RequestModel != null)
            {
                context.RequestModels = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestModel.Keys)
                {
                    context.RequestModels.Add((String)hashKey, (String)(this.RequestModel[hashKey]));
                }
            }
            if (this.RequestParameter != null)
            {
                context.RequestParameters = new Dictionary<System.String, System.Boolean>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestParameter.Keys)
                {
                    context.RequestParameters.Add((String)hashKey, (Boolean)(this.RequestParameter[hashKey]));
                }
            }
            context.RequestValidatorId = this.RequestValidatorId;
            context.ResourceId = this.ResourceId;
            context.RestApiId = this.RestApiId;
            
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
            var request = new Amazon.APIGateway.Model.PutMethodRequest();
            
            if (cmdletContext.ApiKeyRequired != null)
            {
                request.ApiKeyRequired = cmdletContext.ApiKeyRequired.Value;
            }
            if (cmdletContext.AuthorizationType != null)
            {
                request.AuthorizationType = cmdletContext.AuthorizationType;
            }
            if (cmdletContext.AuthorizerId != null)
            {
                request.AuthorizerId = cmdletContext.AuthorizerId;
            }
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.OperationName != null)
            {
                request.OperationName = cmdletContext.OperationName;
            }
            if (cmdletContext.RequestModels != null)
            {
                request.RequestModels = cmdletContext.RequestModels;
            }
            if (cmdletContext.RequestParameters != null)
            {
                request.RequestParameters = cmdletContext.RequestParameters;
            }
            if (cmdletContext.RequestValidatorId != null)
            {
                request.RequestValidatorId = cmdletContext.RequestValidatorId;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
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
        
        private Amazon.APIGateway.Model.PutMethodResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.PutMethodRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "PutMethod");
            try
            {
                #if DESKTOP
                return client.PutMethod(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutMethodAsync(request);
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
            public System.Boolean? ApiKeyRequired { get; set; }
            public System.String AuthorizationType { get; set; }
            public System.String AuthorizerId { get; set; }
            public System.String HttpMethod { get; set; }
            public System.String OperationName { get; set; }
            public Dictionary<System.String, System.String> RequestModels { get; set; }
            public Dictionary<System.String, System.Boolean> RequestParameters { get; set; }
            public System.String RequestValidatorId { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RestApiId { get; set; }
        }
        
    }
}
