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
    /// Adds a <a>MethodResponse</a> to an existing <a>Method</a> resource.
    /// </summary>
    [Cmdlet("Write", "AGMethodResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutMethodResponseResponse")]
    [AWSCmdlet("Invokes the PutMethodResponse operation against Amazon API Gateway.", Operation = new[] {"PutMethodResponse"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutMethodResponseResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.PutMethodResponseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteAGMethodResponseCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP verb of the <a>Method</a> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The <a>Resource</a> identifier for the <a>Method</a> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResponseModel
        /// <summary>
        /// <para>
        /// <para>Specifies the <a>Model</a> resources used for the response's content type. Response
        /// models are represented as a key/value map, with a content type as the key and a <a>Model</a>
        /// name as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseModels")]
        public System.Collections.Hashtable ResponseModel { get; set; }
        #endregion
        
        #region Parameter ResponseParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying required or optional response parameters that Amazon API
        /// Gateway can send back to the caller. A key defines a method response header name and
        /// the associated value is a Boolean flag indicating whether the method response parameter
        /// is required or not. The method response header names must match the pattern of <code>method.response.header.{name}</code>,
        /// where <code>name</code> is a valid and unique header name. The response parameter
        /// names defined here are available in the integration response to be mapped from an
        /// integration response header expressed in <code>integration.response.header.{name}</code>,
        /// a static value enclosed within a pair of single quotes (e.g., <code>'application/json'</code>),
        /// or a JSON expression from the back-end response payload in the form of <code>integration.response.body.{JSON-expression}</code>,
        /// where <code>JSON-expression</code> is a valid JSON expression without the <code>$</code>
        /// prefix.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseParameters")]
        public System.Collections.Hashtable ResponseParameter { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The <a>RestApi</a> identifier for the <a>Method</a> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter StatusCode
        /// <summary>
        /// <para>
        /// <para>The method response's status code.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AGMethodResponse (PutMethodResponse)"))
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
            
            context.HttpMethod = this.HttpMethod;
            context.ResourceId = this.ResourceId;
            if (this.ResponseModel != null)
            {
                context.ResponseModels = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseModel.Keys)
                {
                    context.ResponseModels.Add((String)hashKey, (String)(this.ResponseModel[hashKey]));
                }
            }
            if (this.ResponseParameter != null)
            {
                context.ResponseParameters = new Dictionary<System.String, System.Boolean>(StringComparer.Ordinal);
                foreach (var hashKey in this.ResponseParameter.Keys)
                {
                    context.ResponseParameters.Add((String)hashKey, (Boolean)(this.ResponseParameter[hashKey]));
                }
            }
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
            var request = new Amazon.APIGateway.Model.PutMethodResponseRequest();
            
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResponseModels != null)
            {
                request.ResponseModels = cmdletContext.ResponseModels;
            }
            if (cmdletContext.ResponseParameters != null)
            {
                request.ResponseParameters = cmdletContext.ResponseParameters;
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
        
        private Amazon.APIGateway.Model.PutMethodResponseResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.PutMethodResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "PutMethodResponse");
            #if DESKTOP
            return client.PutMethodResponse(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutMethodResponseAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String HttpMethod { get; set; }
            public System.String ResourceId { get; set; }
            public Dictionary<System.String, System.String> ResponseModels { get; set; }
            public Dictionary<System.String, System.Boolean> ResponseParameters { get; set; }
            public System.String RestApiId { get; set; }
            public System.String StatusCode { get; set; }
        }
        
    }
}
