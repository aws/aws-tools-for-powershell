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
    /// Simulate the execution of a <a>Method</a> in your <a>RestApi</a> with headers, parameters,
    /// and an incoming request body.
    /// </summary>
    [Cmdlet("Test", "AGInvokeMethod")]
    [OutputType("Amazon.APIGateway.Model.TestInvokeMethodResponse")]
    [AWSCmdlet("Invokes the TestInvokeMethod operation against Amazon API Gateway.", Operation = new[] {"TestInvokeMethod"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.TestInvokeMethodResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.TestInvokeMethodResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class TestAGInvokeMethodCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>The simulated request body of an incoming invocation request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Body { get; set; }
        #endregion
        
        #region Parameter ClientCertificateId
        /// <summary>
        /// <para>
        /// <para>A <a>ClientCertificate</a> identifier to use in the test invocation. API Gateway will
        /// use use the certificate when making the HTTPS request to the defined backend endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientCertificateId { get; set; }
        #endregion
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>Specifies a test invoke method request's HTTP method.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter PathWithQueryString
        /// <summary>
        /// <para>
        /// <para>The URI path, including query string, of the simulated invocation request. Use this
        /// to specify path parameters and query string parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PathWithQueryString { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Specifies a test invoke method request's resource ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>Specifies a test invoke method request's API identifier.</para>
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
        /// <para>A key-value map of headers to simulate an incoming invocation request.</para>
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
            
            context.Body = this.Body;
            context.ClientCertificateId = this.ClientCertificateId;
            if (this.Header != null)
            {
                context.Headers = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Header.Keys)
                {
                    context.Headers.Add((String)hashKey, (String)(this.Header[hashKey]));
                }
            }
            context.HttpMethod = this.HttpMethod;
            context.PathWithQueryString = this.PathWithQueryString;
            context.ResourceId = this.ResourceId;
            context.RestApiId = this.RestApiId;
            if (this.StageVariable != null)
            {
                context.StageVariables = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StageVariable.Keys)
                {
                    context.StageVariables.Add((String)hashKey, (String)(this.StageVariable[hashKey]));
                }
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.APIGateway.Model.TestInvokeMethodRequest();
            
            if (cmdletContext.Body != null)
            {
                request.Body = cmdletContext.Body;
            }
            if (cmdletContext.ClientCertificateId != null)
            {
                request.ClientCertificateId = cmdletContext.ClientCertificateId;
            }
            if (cmdletContext.Headers != null)
            {
                request.Headers = cmdletContext.Headers;
            }
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.PathWithQueryString != null)
            {
                request.PathWithQueryString = cmdletContext.PathWithQueryString;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
                var response = client.TestInvokeMethod(request);
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
            public System.String Body { get; set; }
            public System.String ClientCertificateId { get; set; }
            public Dictionary<System.String, System.String> Headers { get; set; }
            public System.String HttpMethod { get; set; }
            public System.String PathWithQueryString { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RestApiId { get; set; }
            public Dictionary<System.String, System.String> StageVariables { get; set; }
        }
        
    }
}
