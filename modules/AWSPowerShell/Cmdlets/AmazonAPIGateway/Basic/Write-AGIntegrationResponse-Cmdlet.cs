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
    [Cmdlet("Write", "AGIntegrationResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.PutIntegrationResponseResponse")]
    [AWSCmdlet("Invokes the PutIntegrationResponse operation against Amazon API Gateway.", Operation = new[] {"PutIntegrationResponse"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.PutIntegrationResponseResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.PutIntegrationResponseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteAGIntegrationResponseCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration response request's HTTP method.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration response request's resource identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResponseParameter
        /// <summary>
        /// <para>
        /// <para>A key-value map specifying response parameters that are passed to the method response
        /// from the back end. The key is a method response header parameter name and the mapped
        /// value is an integration response header value, a static value enclosed within a pair
        /// of single quotes, or a JSON expression from the integration response body. The mapping
        /// key must match the pattern of <code>method.response.header.{name}</code>, where <code>name</code>
        /// is a valid and unique header name. The mapped non-static value must match the pattern
        /// of <code>integration.response.header.{name}</code> or <code>integration.response.body.{JSON-expression}</code>,
        /// where <code>name</code> must be a valid and unique response header name and <code>JSON-expression</code>
        /// a valid JSON expression without the <code>$</code> prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseParameters")]
        public System.Collections.Hashtable ResponseParameter { get; set; }
        #endregion
        
        #region Parameter ResponseTemplate
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration response's templates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResponseTemplates")]
        public System.Collections.Hashtable ResponseTemplate { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>Specifies a put integration response request's API identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter SelectionPattern
        /// <summary>
        /// <para>
        /// <para>Specifies the selection pattern of a put integration response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SelectionPattern { get; set; }
        #endregion
        
        #region Parameter StatusCode
        /// <summary>
        /// <para>
        /// <para>Specifies the status code that is used to map the integration response to an existing
        /// <a>MethodResponse</a>.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AGIntegrationResponse (PutIntegrationResponse)"))
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
            context.RestApiId = this.RestApiId;
            context.SelectionPattern = this.SelectionPattern;
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
            var request = new Amazon.APIGateway.Model.PutIntegrationResponseRequest();
            
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResponseParameters != null)
            {
                request.ResponseParameters = cmdletContext.ResponseParameters;
            }
            if (cmdletContext.ResponseTemplates != null)
            {
                request.ResponseTemplates = cmdletContext.ResponseTemplates;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.SelectionPattern != null)
            {
                request.SelectionPattern = cmdletContext.SelectionPattern;
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
        
        private static Amazon.APIGateway.Model.PutIntegrationResponseResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.PutIntegrationResponseRequest request)
        {
            #if DESKTOP
            return client.PutIntegrationResponse(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutIntegrationResponseAsync(request);
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
            public Dictionary<System.String, System.String> ResponseParameters { get; set; }
            public Dictionary<System.String, System.String> ResponseTemplates { get; set; }
            public System.String RestApiId { get; set; }
            public System.String SelectionPattern { get; set; }
            public System.String StatusCode { get; set; }
        }
        
    }
}
