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
    /// Adds a new <a>Authorizer</a> resource to an existing <a>RestApi</a> resource.
    /// 
    ///  <div class="seeAlso"><a href="https://docs.aws.amazon.com/cli/latest/reference/apigateway/create-authorizer.html">AWS
    /// CLI</a></div>
    /// </summary>
    [Cmdlet("New", "AGAuthorizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateAuthorizerResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateAuthorizer API operation.", Operation = new[] {"CreateAuthorizer"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateAuthorizerResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGAuthorizerCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizerCredential
        /// <summary>
        /// <para>
        /// <para>Specifies the required credentials as an IAM role for API Gateway to invoke the authorizer.
        /// To specify an IAM role for API Gateway to assume, use the role's Amazon Resource Name
        /// (ARN). To use resource-based permissions on the Lambda function, specify null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthorizerCredentials")]
        public System.String AuthorizerCredential { get; set; }
        #endregion
        
        #region Parameter AuthorizerResultTtlInSecond
        /// <summary>
        /// <para>
        /// <para>The TTL in seconds of cached authorizer results. If it equals 0, authorization caching
        /// is disabled. If it is greater than 0, API Gateway will cache authorizer responses.
        /// If this field is not set, the default value is 300. The maximum value is 3600, or
        /// 1 hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthorizerResultTtlInSeconds")]
        public System.Int32 AuthorizerResultTtlInSecond { get; set; }
        #endregion
        
        #region Parameter AuthorizerUri
        /// <summary>
        /// <para>
        /// <para>Specifies the authorizer's Uniform Resource Identifier (URI). For <code>TOKEN</code>
        /// or <code>REQUEST</code> authorizers, this must be a well-formed Lambda function URI,
        /// for example, <code>arn:aws:apigateway:us-west-2:lambda:path/2015-03-31/functions/arn:aws:lambda:us-west-2:{account_id}:function:{lambda_function_name}/invocations</code>.
        /// In general, the URI has this form <code>arn:aws:apigateway:{region}:lambda:path/{service_api}</code>,
        /// where <code>{region}</code> is the same as the region hosting the Lambda function,
        /// <code>path</code> indicates that the remaining substring in the URI should be treated
        /// as the path to the resource, including the initial <code>/</code>. For Lambda functions,
        /// this is usually of the form <code>/2015-03-31/functions/[FunctionARN]/invocations</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthorizerUri { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>Optional customer-defined field, used in OpenAPI imports and exports without functional
        /// impact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthType { get; set; }
        #endregion
        
        #region Parameter IdentitySource
        /// <summary>
        /// <para>
        /// <para>The identity source for which authorization is requested. <ul><li>For a <code>TOKEN</code>
        /// or <code>COGNITO_USER_POOLS</code> authorizer, this is required and specifies the
        /// request header mapping expression for the custom header holding the authorization
        /// token submitted by the client. For example, if the token header name is <code>Auth</code>,
        /// the header mapping expression is <code>method.request.header.Auth</code>.</li><li>For
        /// the <code>REQUEST</code> authorizer, this is required when authorization caching is
        /// enabled. The value is a comma-separated string of one or more mapping expressions
        /// of the specified request parameters. For example, if an <code>Auth</code> header,
        /// a <code>Name</code> query string parameter are defined as identity sources, this value
        /// is <code>method.request.header.Auth, method.request.querystring.Name</code>. These
        /// parameters will be used to derive the authorization caching key and to perform runtime
        /// validation of the <code>REQUEST</code> authorizer by verifying all of the identity-related
        /// request parameters are present, not null and non-empty. Only when this is true does
        /// the authorizer invoke the authorizer Lambda function, otherwise, it returns a 401
        /// Unauthorized response without calling the Lambda function. The valid value is a string
        /// of comma-separated mapping expressions of the specified request parameters. When the
        /// authorization caching is not enabled, this property is optional.</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdentitySource { get; set; }
        #endregion
        
        #region Parameter IdentityValidationExpression
        /// <summary>
        /// <para>
        /// <para>A validation expression for the incoming identity token. For <code>TOKEN</code> authorizers,
        /// this value is a regular expression. API Gateway will match the <code>aud</code> field
        /// of the incoming token from the client against the specified regular expression. It
        /// will invoke the authorizer's Lambda function when there is a match. Otherwise, it
        /// will return a 401 Unauthorized response without calling the Lambda function. The validation
        /// expression does not apply to the <code>REQUEST</code> authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdentityValidationExpression { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>[Required] The name of the authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProviderARNs
        /// <summary>
        /// <para>
        /// <para>A list of the Amazon Cognito user pool ARNs for the <code>COGNITO_USER_POOLS</code>
        /// authorizer. Each element is of this format: <code>arn:aws:cognito-idp:{region}:{account_id}:userpool/{user_pool_id}</code>.
        /// For a <code>TOKEN</code> or <code>REQUEST</code> authorizer, this is not defined.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] ProviderARNs { get; set; }
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>[Required] The authorizer type. Valid values are <code>TOKEN</code> for a Lambda function
        /// using a single authorization token submitted in a custom header, <code>REQUEST</code>
        /// for a Lambda function using incoming request parameters, and <code>COGNITO_USER_POOLS</code>
        /// for using an Amazon Cognito user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.AuthorizerType")]
        public Amazon.APIGateway.AuthorizerType Type { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGAuthorizer (CreateAuthorizer)"))
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
            
            context.AuthorizerCredentials = this.AuthorizerCredential;
            if (ParameterWasBound("AuthorizerResultTtlInSecond"))
                context.AuthorizerResultTtlInSeconds = this.AuthorizerResultTtlInSecond;
            context.AuthorizerUri = this.AuthorizerUri;
            context.AuthType = this.AuthType;
            context.IdentitySource = this.IdentitySource;
            context.IdentityValidationExpression = this.IdentityValidationExpression;
            context.Name = this.Name;
            if (this.ProviderARNs != null)
            {
                context.ProviderARNs = new List<System.String>(this.ProviderARNs);
            }
            context.RestApiId = this.RestApiId;
            context.Type = this.Type;
            
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
            var request = new Amazon.APIGateway.Model.CreateAuthorizerRequest();
            
            if (cmdletContext.AuthorizerCredentials != null)
            {
                request.AuthorizerCredentials = cmdletContext.AuthorizerCredentials;
            }
            if (cmdletContext.AuthorizerResultTtlInSeconds != null)
            {
                request.AuthorizerResultTtlInSeconds = cmdletContext.AuthorizerResultTtlInSeconds.Value;
            }
            if (cmdletContext.AuthorizerUri != null)
            {
                request.AuthorizerUri = cmdletContext.AuthorizerUri;
            }
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.IdentitySource != null)
            {
                request.IdentitySource = cmdletContext.IdentitySource;
            }
            if (cmdletContext.IdentityValidationExpression != null)
            {
                request.IdentityValidationExpression = cmdletContext.IdentityValidationExpression;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProviderARNs != null)
            {
                request.ProviderARNs = cmdletContext.ProviderARNs;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.APIGateway.Model.CreateAuthorizerResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateAuthorizer");
            try
            {
                #if DESKTOP
                return client.CreateAuthorizer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateAuthorizerAsync(request);
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
            public System.String AuthorizerCredentials { get; set; }
            public System.Int32? AuthorizerResultTtlInSeconds { get; set; }
            public System.String AuthorizerUri { get; set; }
            public System.String AuthType { get; set; }
            public System.String IdentitySource { get; set; }
            public System.String IdentityValidationExpression { get; set; }
            public System.String Name { get; set; }
            public List<System.String> ProviderARNs { get; set; }
            public System.String RestApiId { get; set; }
            public Amazon.APIGateway.AuthorizerType Type { get; set; }
        }
        
    }
}
