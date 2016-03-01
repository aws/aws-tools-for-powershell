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
    
    /// </summary>
    [Cmdlet("Test", "AGInvokeAuthorizer")]
    [OutputType("Amazon.APIGateway.Model.TestInvokeAuthorizerResponse")]
    [AWSCmdlet("Invokes the TestInvokeAuthorizer operation against Amazon API Gateway.", Operation = new[] {"TestInvokeAuthorizer"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.TestInvokeAuthorizerResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.TestInvokeAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class TestAGInvokeAuthorizerCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalContext
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable AdditionalContext { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerId { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Body { get; set; }
        #endregion
        
        #region Parameter PathWithQueryString
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PathWithQueryString { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter StageVariable
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StageVariables")]
        public System.Collections.Hashtable StageVariable { get; set; }
        #endregion
        
        #region Parameter Header
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
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
                var response = client.TestInvokeAuthorizer(request);
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
