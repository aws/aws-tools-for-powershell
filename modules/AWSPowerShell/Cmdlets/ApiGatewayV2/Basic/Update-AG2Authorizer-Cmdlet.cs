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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Updates an Authorizer.
    /// </summary>
    [Cmdlet("Update", "AG2Authorizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdateAuthorizer API operation.", Operation = new[] {"UpdateAuthorizer"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAG2AuthorizerCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API identifier.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter AuthorizerCredentialsArn
        /// <summary>
        /// <para>
        /// <para>Specifies the required credentials as an IAM role for API Gateway to invoke the authorizer.
        /// To specify an IAM role for API Gateway to assume, use the role's Amazon Resource Name
        /// (ARN). To use resource-based permissions on the Lambda function, specify null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerCredentialsArn { get; set; }
        #endregion
        
        #region Parameter AuthorizerId
        /// <summary>
        /// <para>
        /// <para>The authorizer identifier.</para>
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
        
        #region Parameter AuthorizerResultTtlInSecond
        /// <summary>
        /// <para>
        /// <para>The time to live (TTL), in seconds, of cached authorizer results. If it is zero, authorization
        /// caching is disabled. If it is greater than zero, API Gateway will cache authorizer
        /// responses. If this field is not set, the default value is 300. The maximum value is
        /// 3600, or 1 hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthorizerResultTtlInSeconds")]
        public System.Int32? AuthorizerResultTtlInSecond { get; set; }
        #endregion
        
        #region Parameter AuthorizerType
        /// <summary>
        /// <para>
        /// <para>The authorizer type. Currently the only valid value is REQUEST, for a Lambda function
        /// using incoming request parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.AuthorizerType")]
        public Amazon.ApiGatewayV2.AuthorizerType AuthorizerType { get; set; }
        #endregion
        
        #region Parameter AuthorizerUri
        /// <summary>
        /// <para>
        /// <para>The authorizer's Uniform Resource Identifier (URI). For REQUEST authorizers, this
        /// must be a well-formed Lambda function URI, for example, arn:aws:apigateway:us-west-2:lambda:path/2015-03-31/functions/arn:aws:lambda:us-west-2:{account_id}:function:{lambda_function_name}/invocations.
        /// In general, the URI has this form: arn:aws:apigateway:{region}:lambda:path/{service_api}
        /// , where {region} is the same as the region hosting the Lambda function, path indicates
        /// that the remaining substring in the URI should be treated as the path to the resource,
        /// including the initial /. For Lambda functions, this is usually of the form /2015-03-31/functions/[FunctionARN]/invocations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthorizerUri { get; set; }
        #endregion
        
        #region Parameter IdentitySource
        /// <summary>
        /// <para>
        /// <para>The identity source for which authorization is requested.</para><para>For the REQUEST authorizer, this is required when authorization caching is enabled.
        /// The value is a comma-separated string of one or more mapping expressions of the specified
        /// request parameters. For example, if an Auth header, a Name query string parameter
        /// are defined as identity sources, this value is $method.request.header.Auth, $method.request.querystring.Name.
        /// These parameters will be used to derive the authorization caching key and to perform
        /// runtime validation of the REQUEST authorizer by verifying all of the identity-related
        /// request parameters are present, not null and non-empty. Only when this is true does
        /// the authorizer invoke the authorizer Lambda function, otherwise, it returns a 401
        /// Unauthorized response without calling the Lambda function. The valid value is a string
        /// of comma-separated mapping expressions of the specified request parameters. When the
        /// authorization caching is not enabled, this property is optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] IdentitySource { get; set; }
        #endregion
        
        #region Parameter IdentityValidationExpression
        /// <summary>
        /// <para>
        /// <para>The validation expression does not apply to the REQUEST authorizer.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProviderArn
        /// <summary>
        /// <para>
        /// <para>For REQUEST authorizer, this is not defined.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProviderArns")]
        public System.String[] ProviderArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApiId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AuthorizerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2Authorizer (UpdateAuthorizer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse, UpdateAG2AuthorizerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApiId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthorizerCredentialsArn = this.AuthorizerCredentialsArn;
            context.AuthorizerId = this.AuthorizerId;
            #if MODULAR
            if (this.AuthorizerId == null && ParameterWasBound(nameof(this.AuthorizerId)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthorizerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthorizerResultTtlInSecond = this.AuthorizerResultTtlInSecond;
            context.AuthorizerType = this.AuthorizerType;
            context.AuthorizerUri = this.AuthorizerUri;
            if (this.IdentitySource != null)
            {
                context.IdentitySource = new List<System.String>(this.IdentitySource);
            }
            context.IdentityValidationExpression = this.IdentityValidationExpression;
            context.Name = this.Name;
            if (this.ProviderArn != null)
            {
                context.ProviderArn = new List<System.String>(this.ProviderArn);
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
            var request = new Amazon.ApiGatewayV2.Model.UpdateAuthorizerRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.AuthorizerCredentialsArn != null)
            {
                request.AuthorizerCredentialsArn = cmdletContext.AuthorizerCredentialsArn;
            }
            if (cmdletContext.AuthorizerId != null)
            {
                request.AuthorizerId = cmdletContext.AuthorizerId;
            }
            if (cmdletContext.AuthorizerResultTtlInSecond != null)
            {
                request.AuthorizerResultTtlInSeconds = cmdletContext.AuthorizerResultTtlInSecond.Value;
            }
            if (cmdletContext.AuthorizerType != null)
            {
                request.AuthorizerType = cmdletContext.AuthorizerType;
            }
            if (cmdletContext.AuthorizerUri != null)
            {
                request.AuthorizerUri = cmdletContext.AuthorizerUri;
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
            if (cmdletContext.ProviderArn != null)
            {
                request.ProviderArns = cmdletContext.ProviderArn;
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
        
        private Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdateAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdateAuthorizer");
            try
            {
                #if DESKTOP
                return client.UpdateAuthorizer(request);
                #elif CORECLR
                return client.UpdateAuthorizerAsync(request).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public System.String AuthorizerCredentialsArn { get; set; }
            public System.String AuthorizerId { get; set; }
            public System.Int32? AuthorizerResultTtlInSecond { get; set; }
            public Amazon.ApiGatewayV2.AuthorizerType AuthorizerType { get; set; }
            public System.String AuthorizerUri { get; set; }
            public List<System.String> IdentitySource { get; set; }
            public System.String IdentityValidationExpression { get; set; }
            public System.String Name { get; set; }
            public List<System.String> ProviderArn { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.UpdateAuthorizerResponse, UpdateAG2AuthorizerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
