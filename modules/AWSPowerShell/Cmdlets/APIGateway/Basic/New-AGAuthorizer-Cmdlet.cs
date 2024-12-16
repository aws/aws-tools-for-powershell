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
    /// Adds a new Authorizer resource to an existing RestApi resource.
    /// </summary>
    [Cmdlet("New", "AGAuthorizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateAuthorizerResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateAuthorizer API operation.", Operation = new[] {"CreateAuthorizer"}, SelectReturnType = typeof(Amazon.APIGateway.Model.CreateAuthorizerResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateAuthorizerResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.CreateAuthorizerResponse object containing multiple properties."
    )]
    public partial class NewAGAuthorizerCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthorizerCredential
        /// <summary>
        /// <para>
        /// <para>Specifies the required credentials as an IAM role for API Gateway to invoke the authorizer.
        /// To specify an IAM role for API Gateway to assume, use the role's Amazon Resource Name
        /// (ARN). To use resource-based permissions on the Lambda function, specify null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerResultTtlInSeconds")]
        public System.Int32? AuthorizerResultTtlInSecond { get; set; }
        #endregion
        
        #region Parameter AuthorizerUri
        /// <summary>
        /// <para>
        /// <para>Specifies the authorizer's Uniform Resource Identifier (URI). For <c>TOKEN</c> or
        /// <c>REQUEST</c> authorizers, this must be a well-formed Lambda function URI, for example,
        /// <c>arn:aws:apigateway:us-west-2:lambda:path/2015-03-31/functions/arn:aws:lambda:us-west-2:{account_id}:function:{lambda_function_name}/invocations</c>.
        /// In general, the URI has this form <c>arn:aws:apigateway:{region}:lambda:path/{service_api}</c>,
        /// where <c>{region}</c> is the same as the region hosting the Lambda function, <c>path</c>
        /// indicates that the remaining substring in the URI should be treated as the path to
        /// the resource, including the initial <c>/</c>. For Lambda functions, this is usually
        /// of the form <c>/2015-03-31/functions/[FunctionARN]/invocations</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerUri { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>Optional customer-defined field, used in OpenAPI imports and exports without functional
        /// impact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthType { get; set; }
        #endregion
        
        #region Parameter IdentitySource
        /// <summary>
        /// <para>
        /// <para>The identity source for which authorization is requested. For a <c>TOKEN</c> or <c>COGNITO_USER_POOLS</c>
        /// authorizer, this is required and specifies the request header mapping expression for
        /// the custom header holding the authorization token submitted by the client. For example,
        /// if the token header name is <c>Auth</c>, the header mapping expression is <c>method.request.header.Auth</c>.
        /// For the <c>REQUEST</c> authorizer, this is required when authorization caching is
        /// enabled. The value is a comma-separated string of one or more mapping expressions
        /// of the specified request parameters. For example, if an <c>Auth</c> header, a <c>Name</c>
        /// query string parameter are defined as identity sources, this value is <c>method.request.header.Auth,
        /// method.request.querystring.Name</c>. These parameters will be used to derive the authorization
        /// caching key and to perform runtime validation of the <c>REQUEST</c> authorizer by
        /// verifying all of the identity-related request parameters are present, not null and
        /// non-empty. Only when this is true does the authorizer invoke the authorizer Lambda
        /// function, otherwise, it returns a 401 Unauthorized response without calling the Lambda
        /// function. The valid value is a string of comma-separated mapping expressions of the
        /// specified request parameters. When the authorization caching is not enabled, this
        /// property is optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentitySource { get; set; }
        #endregion
        
        #region Parameter IdentityValidationExpression
        /// <summary>
        /// <para>
        /// <para>A validation expression for the incoming identity token. For <c>TOKEN</c> authorizers,
        /// this value is a regular expression. For <c>COGNITO_USER_POOLS</c> authorizers, API
        /// Gateway will match the <c>aud</c> field of the incoming token from the client against
        /// the specified regular expression. It will invoke the authorizer's Lambda function
        /// when there is a match. Otherwise, it will return a 401 Unauthorized response without
        /// calling the Lambda function. The validation expression does not apply to the <c>REQUEST</c>
        /// authorizer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityValidationExpression { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the authorizer.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProviderARNs
        /// <summary>
        /// <para>
        /// <para>A list of the Amazon Cognito user pool ARNs for the <c>COGNITO_USER_POOLS</c> authorizer.
        /// Each element is of this format: <c>arn:aws:cognito-idp:{region}:{account_id}:userpool/{user_pool_id}</c>.
        /// For a <c>TOKEN</c> or <c>REQUEST</c> authorizer, this is not defined. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ProviderARNs { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated RestApi.</para>
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The authorizer type. Valid values are <c>TOKEN</c> for a Lambda function using a single
        /// authorization token submitted in a custom header, <c>REQUEST</c> for a Lambda function
        /// using incoming request parameters, and <c>COGNITO_USER_POOLS</c> for using an Amazon
        /// Cognito user pool.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.APIGateway.AuthorizerType")]
        public Amazon.APIGateway.AuthorizerType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.CreateAuthorizerResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.CreateAuthorizerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RestApiId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGAuthorizer (CreateAuthorizer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.CreateAuthorizerResponse, NewAGAuthorizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthorizerCredential = this.AuthorizerCredential;
            context.AuthorizerResultTtlInSecond = this.AuthorizerResultTtlInSecond;
            context.AuthorizerUri = this.AuthorizerUri;
            context.AuthType = this.AuthType;
            context.IdentitySource = this.IdentitySource;
            context.IdentityValidationExpression = this.IdentityValidationExpression;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ProviderARNs != null)
            {
                context.ProviderARNs = new List<System.String>(this.ProviderARNs);
            }
            context.RestApiId = this.RestApiId;
            #if MODULAR
            if (this.RestApiId == null && ParameterWasBound(nameof(this.RestApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            
            if (cmdletContext.AuthorizerCredential != null)
            {
                request.AuthorizerCredentials = cmdletContext.AuthorizerCredential;
            }
            if (cmdletContext.AuthorizerResultTtlInSecond != null)
            {
                request.AuthorizerResultTtlInSeconds = cmdletContext.AuthorizerResultTtlInSecond.Value;
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
        
        private Amazon.APIGateway.Model.CreateAuthorizerResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateAuthorizer");
            try
            {
                #if DESKTOP
                return client.CreateAuthorizer(request);
                #elif CORECLR
                return client.CreateAuthorizerAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthorizerCredential { get; set; }
            public System.Int32? AuthorizerResultTtlInSecond { get; set; }
            public System.String AuthorizerUri { get; set; }
            public System.String AuthType { get; set; }
            public System.String IdentitySource { get; set; }
            public System.String IdentityValidationExpression { get; set; }
            public System.String Name { get; set; }
            public List<System.String> ProviderARNs { get; set; }
            public System.String RestApiId { get; set; }
            public Amazon.APIGateway.AuthorizerType Type { get; set; }
            public System.Func<Amazon.APIGateway.Model.CreateAuthorizerResponse, NewAGAuthorizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
