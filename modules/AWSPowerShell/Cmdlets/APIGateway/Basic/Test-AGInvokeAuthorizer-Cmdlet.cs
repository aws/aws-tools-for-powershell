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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Simulate the execution of an <a>Authorizer</a> in your <a>RestApi</a> with headers,
    /// parameters, and an incoming request body.
    /// 
    ///  <div class="seeAlso"><a href="https://docs.aws.amazon.com/apigateway/latest/developerguide/apigateway-use-lambda-authorizer.html">Use
    /// Lambda Function as Authorizer</a><a href="https://docs.aws.amazon.com/apigateway/latest/developerguide/apigateway-integrate-with-cognito.html">Use
    /// Cognito User Pool as Authorizer</a></div>
    /// </summary>
    [Cmdlet("Test", "AGInvokeAuthorizer")]
    [OutputType("Amazon.APIGateway.Model.TestInvokeAuthorizerResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway TestInvokeAuthorizer API operation.", Operation = new[] {"TestInvokeAuthorizer"}, SelectReturnType = typeof(Amazon.APIGateway.Model.TestInvokeAuthorizerResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.TestInvokeAuthorizerResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.TestInvokeAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestAGInvokeAuthorizerCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalContext
        /// <summary>
        /// <para>
        /// <para>[Optional] A key-value map of additional context variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AdditionalContext { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// <para>[Required] Specifies a test invoke authorizer request's <a>Authorizer</a> ID.</para>
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
        public System.String AuthorizerId { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>[Optional] The simulated request body of an incoming invocation request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Body { get; set; }
        #endregion
        
        #region Parameter Header
        /// <summary>
        /// <para>
        /// <para>[Required] A key-value map of headers to simulate an incoming invocation request.
        /// This is where the incoming authorization token, or identity source, should be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Headers")]
        public System.Collections.Hashtable Header { get; set; }
        #endregion
        
        #region Parameter MultiValueHeader
        /// <summary>
        /// <para>
        /// <para>[Optional] The headers as a map from string to list of values to simulate an incoming
        /// invocation request. This is where the incoming authorization token, or identity source,
        /// may be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiValueHeaders")]
        public System.Collections.Hashtable MultiValueHeader { get; set; }
        #endregion
        
        #region Parameter PathWithQueryString
        /// <summary>
        /// <para>
        /// <para>[Optional] The URI path, including query string, of the simulated invocation request.
        /// Use this to specify path parameters and query string parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PathWithQueryString { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>[Required] The string identifier of the associated <a>RestApi</a>.</para>
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
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter StageVariable
        /// <summary>
        /// <para>
        /// <para>A key-value map of stage variables to simulate an invocation on a deployed <a>Stage</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StageVariables")]
        public System.Collections.Hashtable StageVariable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.TestInvokeAuthorizerResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.TestInvokeAuthorizerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RestApiId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RestApiId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RestApiId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.TestInvokeAuthorizerResponse, TestAGInvokeAuthorizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RestApiId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalContext != null)
            {
                context.AdditionalContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalContext.Keys)
                {
                    context.AdditionalContext.Add((String)hashKey, (String)(this.AdditionalContext[hashKey]));
                }
            }
            context.AuthorizerId = this.AuthorizerId;
            #if MODULAR
            if (this.AuthorizerId == null && ParameterWasBound(nameof(this.AuthorizerId)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Body = this.Body;
            if (this.Header != null)
            {
                context.Header = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Header.Keys)
                {
                    context.Header.Add((String)hashKey, (String)(this.Header[hashKey]));
                }
            }
            if (this.MultiValueHeader != null)
            {
                context.MultiValueHeader = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.MultiValueHeader.Keys)
                {
                    object hashValue = this.MultiValueHeader[hashKey];
                    if (hashValue == null)
                    {
                        context.MultiValueHeader.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((String)s);
                    }
                    context.MultiValueHeader.Add((String)hashKey, valueSet);
                }
            }
            context.PathWithQueryString = this.PathWithQueryString;
            context.RestApiId = this.RestApiId;
            #if MODULAR
            if (this.RestApiId == null && ParameterWasBound(nameof(this.RestApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StageVariable != null)
            {
                context.StageVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StageVariable.Keys)
                {
                    context.StageVariable.Add((String)hashKey, (String)(this.StageVariable[hashKey]));
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
            if (cmdletContext.Header != null)
            {
                request.Headers = cmdletContext.Header;
            }
            if (cmdletContext.MultiValueHeader != null)
            {
                request.MultiValueHeaders = cmdletContext.MultiValueHeader;
            }
            if (cmdletContext.PathWithQueryString != null)
            {
                request.PathWithQueryString = cmdletContext.PathWithQueryString;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StageVariable != null)
            {
                request.StageVariables = cmdletContext.StageVariable;
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
        
        private Amazon.APIGateway.Model.TestInvokeAuthorizerResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.TestInvokeAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "TestInvokeAuthorizer");
            try
            {
                #if DESKTOP
                return client.TestInvokeAuthorizer(request);
                #elif CORECLR
                return client.TestInvokeAuthorizerAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Header { get; set; }
            public Dictionary<System.String, List<System.String>> MultiValueHeader { get; set; }
            public System.String PathWithQueryString { get; set; }
            public System.String RestApiId { get; set; }
            public Dictionary<System.String, System.String> StageVariable { get; set; }
            public System.Func<Amazon.APIGateway.Model.TestInvokeAuthorizerResponse, TestAGInvokeAuthorizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
