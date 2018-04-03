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
    /// Simulate the execution of an <a>Authorizer</a> in your <a>RestApi</a> with headers,
    /// parameters, and an incoming request body.
    /// 
    ///  <div class="seeAlso"><a href="http://docs.aws.amazon.com/apigateway/latest/developerguide/use-custom-authorizer.html">Enable
    /// custom authorizers</a></div>
    /// </summary>
    [Cmdlet("Test", "AGInvokeAuthorizer")]
    [OutputType("Amazon.APIGateway.Model.TestInvokeAuthorizerResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway TestInvokeAuthorizer API operation.", Operation = new[] {"TestInvokeAuthorizer"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.TestInvokeAuthorizerResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.TestInvokeAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestAGInvokeAuthorizerCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalContext
        /// <summary>
        /// <para>
        /// <para>[Optional] A key-value map of additional context variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AdditionalContext { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// <para>[Required] Specifies a test invoke authorizer request's <a>Authorizer</a> ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerId { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>[Optional] The simulated request body of an incoming invocation request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Body { get; set; }
        #endregion
        
        #region Parameter PathWithQueryString
        /// <summary>
        /// <para>
        /// <para>[Optional] The URI path, including query string, of the simulated invocation request.
        /// Use this to specify path parameters and query string parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PathWithQueryString { get; set; }
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
        
        #region Parameter StageVariable
        /// <summary>
        /// <para>
        /// <para>A key-value map of stage variables to simulate an invocation on a deployed <a>Stage</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StageVariables")]
        public System.Collections.Hashtable StageVariable { get; set; }
        #endregion
        
        #region Parameter Header
        /// <summary>
        /// <para>
        /// <para>[Required] A key-value map of headers to simulate an incoming invocation request.
        /// This is where the incoming authorization token, or identity source, should be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Headers")]
        public System.Collections.Hashtable Header { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AdditionalContext != null)
            {
                context.AdditionalContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalContext.Keys)
                {
                    context.AdditionalContext.Add((String)hashKey, (String)(this.AdditionalContext[hashKey]));
                }
            }
            context.AuthorizerId = this.AuthorizerId;
            context.Body = this.Body;
            if (this.Header != null)
            {
                context.Headers = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Header.Keys)
                {
                    context.Headers.Add((String)hashKey, (String)(this.Header[hashKey]));
                }
            }
            context.PathWithQueryString = this.PathWithQueryString;
            context.RestApiId = this.RestApiId;
            if (this.StageVariable != null)
            {
                context.StageVariables = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StageVariable.Keys)
                {
                    context.StageVariables.Add((String)hashKey, (String)(this.StageVariable[hashKey]));
                }
            }
            
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
            var request = new Amazon.APIGateway.Model.TestInvokeAuthorizerRequest();
            
            if (cmdletContext.AdditionalContext != null)
            {
                request.AdditionalContext = cmdletContext.AdditionalContext;
            }
            if (cmdletContext.AuthorizerId != null)
            {
                request.AuthorizerId = cmdletContext.AuthorizerId;
            }
            if (cmdletContext.Body != null)
            {
                request.Body = cmdletContext.Body;
            }
            if (cmdletContext.Headers != null)
            {
                request.Headers = cmdletContext.Headers;
            }
            if (cmdletContext.PathWithQueryString != null)
            {
                request.PathWithQueryString = cmdletContext.PathWithQueryString;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StageVariables != null)
            {
                request.StageVariables = cmdletContext.StageVariables;
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
        
        private Amazon.APIGateway.Model.TestInvokeAuthorizerResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.TestInvokeAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "TestInvokeAuthorizer");
            try
            {
                #if DESKTOP
                return client.TestInvokeAuthorizer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TestInvokeAuthorizerAsync(request);
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
            public Dictionary<System.String, System.String> AdditionalContext { get; set; }
            public System.String AuthorizerId { get; set; }
            public System.String Body { get; set; }
            public Dictionary<System.String, System.String> Headers { get; set; }
            public System.String PathWithQueryString { get; set; }
            public System.String RestApiId { get; set; }
            public Dictionary<System.String, System.String> StageVariables { get; set; }
        }
        
    }
}
