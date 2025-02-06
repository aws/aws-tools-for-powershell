/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Updates a <c>GraphqlApi</c> object.
    /// </summary>
    [Cmdlet("Update", "ASYNGraphqlApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.GraphqlApi")]
    [AWSCmdlet("Calls the AWS AppSync UpdateGraphqlApi API operation.", Operation = new[] {"UpdateGraphqlApi"}, SelectReturnType = typeof(Amazon.AppSync.Model.UpdateGraphqlApiResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.GraphqlApi or Amazon.AppSync.Model.UpdateGraphqlApiResponse",
        "This cmdlet returns an Amazon.AppSync.Model.GraphqlApi object.",
        "The service call response (type Amazon.AppSync.Model.UpdateGraphqlApiResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateASYNGraphqlApiCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalAuthenticationProvider
        /// <summary>
        /// <para>
        /// <para>A list of additional authentication providers for the <c>GraphqlApi</c> API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalAuthenticationProviders")]
        public Amazon.AppSync.Model.AdditionalAuthenticationProvider[] AdditionalAuthenticationProvider { get; set; }
        #endregion
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API ID.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>The new authentication type for the <c>GraphqlApi</c> object.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppSync.AuthenticationType")]
        public Amazon.AppSync.AuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter LambdaAuthorizerConfig_AuthorizerResultTtlInSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds a response should be cached for. The default is 0 seconds, which
        /// disables caching. If you don't specify a value for <c>authorizerResultTtlInSeconds</c>,
        /// the default value is used. The maximum value is one hour (3600 seconds). The Lambda
        /// function can override this by returning a <c>ttlOverride</c> key in its response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaAuthorizerConfig_AuthorizerResultTtlInSeconds")]
        public System.Int32? LambdaAuthorizerConfig_AuthorizerResultTtlInSecond { get; set; }
        #endregion
        
        #region Parameter LambdaAuthorizerConfig_AuthorizerUri
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Lambda function to be called for authorization.
        /// This can be a standard Lambda ARN, a version ARN (<c>.../v3</c>), or an alias ARN.
        /// </para><para><b>Note</b>: This Lambda function must have the following resource-based policy assigned
        /// to it. When configuring Lambda authorizers in the console, this is done for you. To
        /// use the Command Line Interface (CLI), run the following:</para><para><c>aws lambda add-permission --function-name "arn:aws:lambda:us-east-2:111122223333:function:my-function"
        /// --statement-id "appsync" --principal appsync.amazonaws.com --action lambda:InvokeFunction</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaAuthorizerConfig_AuthorizerUri { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_AuthTTL
        /// <summary>
        /// <para>
        /// <para>The number of milliseconds that a token is valid after being authenticated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OpenIDConnectConfig_AuthTTL { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_ClientId
        /// <summary>
        /// <para>
        /// <para>The client identifier of the relying party at the OpenID identity provider. This identifier
        /// is typically obtained when the relying party is registered with the OpenID identity
        /// provider. You can specify a regular expression so that AppSync can validate against
        /// multiple client identifiers at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenIDConnectConfig_ClientId { get; set; }
        #endregion
        
        #region Parameter LogConfig_CloudWatchLogsRoleArn
        /// <summary>
        /// <para>
        /// <para>The service role that AppSync assumes to publish to CloudWatch logs in your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogConfig_CloudWatchLogsRoleArn { get; set; }
        #endregion
        
        #region Parameter EnhancedMetricsConfig_DataSourceLevelMetricsBehavior
        /// <summary>
        /// <para>
        /// <para>Controls how data source metrics will be emitted to CloudWatch. Data source metrics
        /// include:</para><ul><li><para>Requests: The number of invocations that occured during a request.</para></li><li><para>Latency: The time to complete a data source invocation.</para></li><li><para>Errors: The number of errors that occurred during a data source invocation.</para></li></ul><para>These metrics can be emitted to CloudWatch per data source or for all data sources
        /// in the request. Metrics will be recorded by API ID and data source name. <c>dataSourceLevelMetricsBehavior</c>
        /// accepts one of these values at a time:</para><ul><li><para><c>FULL_REQUEST_DATA_SOURCE_METRICS</c>: Records and emits metric data for all data
        /// sources in the request.</para></li><li><para><c>PER_DATA_SOURCE_METRICS</c>: Records and emits metric data for data sources that
        /// have the <c>metricsConfig</c> value set to <c>ENABLED</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.DataSourceLevelMetricsBehavior")]
        public Amazon.AppSync.DataSourceLevelMetricsBehavior EnhancedMetricsConfig_DataSourceLevelMetricsBehavior { get; set; }
        #endregion
        
        #region Parameter LogConfig_ExcludeVerboseContent
        /// <summary>
        /// <para>
        /// <para>Set to TRUE to exclude sections that contain information such as headers, context,
        /// and evaluated mapping templates, regardless of logging level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LogConfig_ExcludeVerboseContent { get; set; }
        #endregion
        
        #region Parameter LogConfig_FieldLogLevel
        /// <summary>
        /// <para>
        /// <para>The field logging level. Values can be NONE, ERROR, or ALL.</para><ul><li><para><b>NONE</b>: No field-level logs are captured.</para></li><li><para><b>ERROR</b>: Logs the following information only for the fields that are in error:</para><ul><li><para>The error section in the server response.</para></li><li><para>Field-level errors.</para></li><li><para>The generated request/response functions that got resolved for error fields.</para></li></ul></li><li><para><b>ALL</b>: The following information is logged for all fields in the query:</para><ul><li><para>Field-level tracing information.</para></li><li><para>The generated request/response functions that got resolved for each field.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.FieldLogLevel")]
        public Amazon.AppSync.FieldLogLevel LogConfig_FieldLogLevel { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_IatTTL
        /// <summary>
        /// <para>
        /// <para>The number of milliseconds that a token is valid after it's issued to a user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OpenIDConnectConfig_IatTTL { get; set; }
        #endregion
        
        #region Parameter LambdaAuthorizerConfig_IdentityValidationExpression
        /// <summary>
        /// <para>
        /// <para>A regular expression for validation of tokens before the Lambda function is called.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaAuthorizerConfig_IdentityValidationExpression { get; set; }
        #endregion
        
        #region Parameter IntrospectionConfig
        /// <summary>
        /// <para>
        /// <para>Sets the value of the GraphQL API to enable (<c>ENABLED</c>) or disable (<c>DISABLED</c>)
        /// introspection. If no value is provided, the introspection configuration will be set
        /// to <c>ENABLED</c> by default. This field will produce an error if the operation attempts
        /// to use the introspection feature while this field is disabled.</para><para>For more information about introspection, see <a href="https://graphql.org/learn/introspection/">GraphQL
        /// introspection</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.GraphQLApiIntrospectionConfig")]
        public Amazon.AppSync.GraphQLApiIntrospectionConfig IntrospectionConfig { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectConfig_Issuer
        /// <summary>
        /// <para>
        /// <para>The issuer for the OIDC configuration. The issuer returned by discovery must exactly
        /// match the value of <c>iss</c> in the ID token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenIDConnectConfig_Issuer { get; set; }
        #endregion
        
        #region Parameter MergedApiExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Identity and Access Management service role ARN for a merged API. The AppSync
        /// service assumes this role on behalf of the Merged API to validate access to source
        /// APIs at runtime and to prompt the <c>AUTO_MERGE</c> to update the merged API endpoint
        /// with the source API changes automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MergedApiExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name for the <c>GraphqlApi</c> object.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EnhancedMetricsConfig_OperationLevelMetricsConfig
        /// <summary>
        /// <para>
        /// <para> Controls how operation metrics will be emitted to CloudWatch. Operation metrics include:</para><ul><li><para>Requests: The number of times a specified GraphQL operation was called.</para></li><li><para>GraphQL errors: The number of GraphQL errors that occurred during a specified GraphQL
        /// operation.</para></li></ul><para>Metrics will be recorded by API ID and operation name. You can set the value to <c>ENABLED</c>
        /// or <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.OperationLevelMetricsConfig")]
        public Amazon.AppSync.OperationLevelMetricsConfig EnhancedMetricsConfig_OperationLevelMetricsConfig { get; set; }
        #endregion
        
        #region Parameter OwnerContact
        /// <summary>
        /// <para>
        /// <para>The owner contact information for an API resource.</para><para>This field accepts any string input with a length of 0 - 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerContact { get; set; }
        #endregion
        
        #region Parameter QueryDepthLimit
        /// <summary>
        /// <para>
        /// <para>The maximum depth a query can have in a single request. Depth refers to the amount
        /// of nested levels allowed in the body of query. The default value is <c>0</c> (or unspecified),
        /// which indicates there's no depth limit. If you set a limit, it can be between <c>1</c>
        /// and <c>75</c> nested levels. This field will produce a limit error if the operation
        /// falls out of bounds.</para><para>Note that fields can still be set to nullable or non-nullable. If a non-nullable field
        /// produces an error, the error will be thrown upwards to the first nullable field available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? QueryDepthLimit { get; set; }
        #endregion
        
        #region Parameter ResolverCountLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of resolvers that can be invoked in a single request. The default
        /// value is <c>0</c> (or unspecified), which will set the limit to <c>10000</c>. When
        /// specified, the limit value can be between <c>1</c> and <c>10000</c>. This field will
        /// produce a limit error if the operation falls out of bounds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ResolverCountLimit { get; set; }
        #endregion
        
        #region Parameter EnhancedMetricsConfig_ResolverLevelMetricsBehavior
        /// <summary>
        /// <para>
        /// <para>Controls how resolver metrics will be emitted to CloudWatch. Resolver metrics include:</para><ul><li><para>GraphQL errors: The number of GraphQL errors that occurred.</para></li><li><para>Requests: The number of invocations that occurred during a request. </para></li><li><para>Latency: The time to complete a resolver invocation.</para></li><li><para>Cache hits: The number of cache hits during a request.</para></li><li><para>Cache misses: The number of cache misses during a request.</para></li></ul><para>These metrics can be emitted to CloudWatch per resolver or for all resolvers in the
        /// request. Metrics will be recorded by API ID and resolver name. <c>resolverLevelMetricsBehavior</c>
        /// accepts one of these values at a time:</para><ul><li><para><c>FULL_REQUEST_RESOLVER_METRICS</c>: Records and emits metric data for all resolvers
        /// in the request.</para></li><li><para><c>PER_RESOLVER_METRICS</c>: Records and emits metric data for resolvers that have
        /// the <c>metricsConfig</c> value set to <c>ENABLED</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.ResolverLevelMetricsBehavior")]
        public Amazon.AppSync.ResolverLevelMetricsBehavior EnhancedMetricsConfig_ResolverLevelMetricsBehavior { get; set; }
        #endregion
        
        #region Parameter UserPoolConfig
        /// <summary>
        /// <para>
        /// <para>The new Amazon Cognito user pool configuration for the <c>~GraphqlApi</c> object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppSync.Model.UserPoolConfig UserPoolConfig { get; set; }
        #endregion
        
        #region Parameter XrayEnabled
        /// <summary>
        /// <para>
        /// <para>A flag indicating whether to use X-Ray tracing for the <c>GraphqlApi</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? XrayEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GraphqlApi'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.UpdateGraphqlApiResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.UpdateGraphqlApiResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GraphqlApi";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASYNGraphqlApi (UpdateGraphqlApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.UpdateGraphqlApiResponse, UpdateASYNGraphqlApiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalAuthenticationProvider != null)
            {
                context.AdditionalAuthenticationProvider = new List<Amazon.AppSync.Model.AdditionalAuthenticationProvider>(this.AdditionalAuthenticationProvider);
            }
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthenticationType = this.AuthenticationType;
            #if MODULAR
            if (this.AuthenticationType == null && ParameterWasBound(nameof(this.AuthenticationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnhancedMetricsConfig_DataSourceLevelMetricsBehavior = this.EnhancedMetricsConfig_DataSourceLevelMetricsBehavior;
            context.EnhancedMetricsConfig_OperationLevelMetricsConfig = this.EnhancedMetricsConfig_OperationLevelMetricsConfig;
            context.EnhancedMetricsConfig_ResolverLevelMetricsBehavior = this.EnhancedMetricsConfig_ResolverLevelMetricsBehavior;
            context.IntrospectionConfig = this.IntrospectionConfig;
            context.LambdaAuthorizerConfig_AuthorizerResultTtlInSecond = this.LambdaAuthorizerConfig_AuthorizerResultTtlInSecond;
            context.LambdaAuthorizerConfig_AuthorizerUri = this.LambdaAuthorizerConfig_AuthorizerUri;
            context.LambdaAuthorizerConfig_IdentityValidationExpression = this.LambdaAuthorizerConfig_IdentityValidationExpression;
            context.LogConfig_CloudWatchLogsRoleArn = this.LogConfig_CloudWatchLogsRoleArn;
            context.LogConfig_ExcludeVerboseContent = this.LogConfig_ExcludeVerboseContent;
            context.LogConfig_FieldLogLevel = this.LogConfig_FieldLogLevel;
            context.MergedApiExecutionRoleArn = this.MergedApiExecutionRoleArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OpenIDConnectConfig_AuthTTL = this.OpenIDConnectConfig_AuthTTL;
            context.OpenIDConnectConfig_ClientId = this.OpenIDConnectConfig_ClientId;
            context.OpenIDConnectConfig_IatTTL = this.OpenIDConnectConfig_IatTTL;
            context.OpenIDConnectConfig_Issuer = this.OpenIDConnectConfig_Issuer;
            context.OwnerContact = this.OwnerContact;
            context.QueryDepthLimit = this.QueryDepthLimit;
            context.ResolverCountLimit = this.ResolverCountLimit;
            context.UserPoolConfig = this.UserPoolConfig;
            context.XrayEnabled = this.XrayEnabled;
            
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
            var request = new Amazon.AppSync.Model.UpdateGraphqlApiRequest();
            
            if (cmdletContext.AdditionalAuthenticationProvider != null)
            {
                request.AdditionalAuthenticationProviders = cmdletContext.AdditionalAuthenticationProvider;
            }
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.AuthenticationType != null)
            {
                request.AuthenticationType = cmdletContext.AuthenticationType;
            }
            
             // populate EnhancedMetricsConfig
            var requestEnhancedMetricsConfigIsNull = true;
            request.EnhancedMetricsConfig = new Amazon.AppSync.Model.EnhancedMetricsConfig();
            Amazon.AppSync.DataSourceLevelMetricsBehavior requestEnhancedMetricsConfig_enhancedMetricsConfig_DataSourceLevelMetricsBehavior = null;
            if (cmdletContext.EnhancedMetricsConfig_DataSourceLevelMetricsBehavior != null)
            {
                requestEnhancedMetricsConfig_enhancedMetricsConfig_DataSourceLevelMetricsBehavior = cmdletContext.EnhancedMetricsConfig_DataSourceLevelMetricsBehavior;
            }
            if (requestEnhancedMetricsConfig_enhancedMetricsConfig_DataSourceLevelMetricsBehavior != null)
            {
                request.EnhancedMetricsConfig.DataSourceLevelMetricsBehavior = requestEnhancedMetricsConfig_enhancedMetricsConfig_DataSourceLevelMetricsBehavior;
                requestEnhancedMetricsConfigIsNull = false;
            }
            Amazon.AppSync.OperationLevelMetricsConfig requestEnhancedMetricsConfig_enhancedMetricsConfig_OperationLevelMetricsConfig = null;
            if (cmdletContext.EnhancedMetricsConfig_OperationLevelMetricsConfig != null)
            {
                requestEnhancedMetricsConfig_enhancedMetricsConfig_OperationLevelMetricsConfig = cmdletContext.EnhancedMetricsConfig_OperationLevelMetricsConfig;
            }
            if (requestEnhancedMetricsConfig_enhancedMetricsConfig_OperationLevelMetricsConfig != null)
            {
                request.EnhancedMetricsConfig.OperationLevelMetricsConfig = requestEnhancedMetricsConfig_enhancedMetricsConfig_OperationLevelMetricsConfig;
                requestEnhancedMetricsConfigIsNull = false;
            }
            Amazon.AppSync.ResolverLevelMetricsBehavior requestEnhancedMetricsConfig_enhancedMetricsConfig_ResolverLevelMetricsBehavior = null;
            if (cmdletContext.EnhancedMetricsConfig_ResolverLevelMetricsBehavior != null)
            {
                requestEnhancedMetricsConfig_enhancedMetricsConfig_ResolverLevelMetricsBehavior = cmdletContext.EnhancedMetricsConfig_ResolverLevelMetricsBehavior;
            }
            if (requestEnhancedMetricsConfig_enhancedMetricsConfig_ResolverLevelMetricsBehavior != null)
            {
                request.EnhancedMetricsConfig.ResolverLevelMetricsBehavior = requestEnhancedMetricsConfig_enhancedMetricsConfig_ResolverLevelMetricsBehavior;
                requestEnhancedMetricsConfigIsNull = false;
            }
             // determine if request.EnhancedMetricsConfig should be set to null
            if (requestEnhancedMetricsConfigIsNull)
            {
                request.EnhancedMetricsConfig = null;
            }
            if (cmdletContext.IntrospectionConfig != null)
            {
                request.IntrospectionConfig = cmdletContext.IntrospectionConfig;
            }
            
             // populate LambdaAuthorizerConfig
            var requestLambdaAuthorizerConfigIsNull = true;
            request.LambdaAuthorizerConfig = new Amazon.AppSync.Model.LambdaAuthorizerConfig();
            System.Int32? requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerResultTtlInSecond = null;
            if (cmdletContext.LambdaAuthorizerConfig_AuthorizerResultTtlInSecond != null)
            {
                requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerResultTtlInSecond = cmdletContext.LambdaAuthorizerConfig_AuthorizerResultTtlInSecond.Value;
            }
            if (requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerResultTtlInSecond != null)
            {
                request.LambdaAuthorizerConfig.AuthorizerResultTtlInSeconds = requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerResultTtlInSecond.Value;
                requestLambdaAuthorizerConfigIsNull = false;
            }
            System.String requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerUri = null;
            if (cmdletContext.LambdaAuthorizerConfig_AuthorizerUri != null)
            {
                requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerUri = cmdletContext.LambdaAuthorizerConfig_AuthorizerUri;
            }
            if (requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerUri != null)
            {
                request.LambdaAuthorizerConfig.AuthorizerUri = requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_AuthorizerUri;
                requestLambdaAuthorizerConfigIsNull = false;
            }
            System.String requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_IdentityValidationExpression = null;
            if (cmdletContext.LambdaAuthorizerConfig_IdentityValidationExpression != null)
            {
                requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_IdentityValidationExpression = cmdletContext.LambdaAuthorizerConfig_IdentityValidationExpression;
            }
            if (requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_IdentityValidationExpression != null)
            {
                request.LambdaAuthorizerConfig.IdentityValidationExpression = requestLambdaAuthorizerConfig_lambdaAuthorizerConfig_IdentityValidationExpression;
                requestLambdaAuthorizerConfigIsNull = false;
            }
             // determine if request.LambdaAuthorizerConfig should be set to null
            if (requestLambdaAuthorizerConfigIsNull)
            {
                request.LambdaAuthorizerConfig = null;
            }
            
             // populate LogConfig
            var requestLogConfigIsNull = true;
            request.LogConfig = new Amazon.AppSync.Model.LogConfig();
            System.String requestLogConfig_logConfig_CloudWatchLogsRoleArn = null;
            if (cmdletContext.LogConfig_CloudWatchLogsRoleArn != null)
            {
                requestLogConfig_logConfig_CloudWatchLogsRoleArn = cmdletContext.LogConfig_CloudWatchLogsRoleArn;
            }
            if (requestLogConfig_logConfig_CloudWatchLogsRoleArn != null)
            {
                request.LogConfig.CloudWatchLogsRoleArn = requestLogConfig_logConfig_CloudWatchLogsRoleArn;
                requestLogConfigIsNull = false;
            }
            System.Boolean? requestLogConfig_logConfig_ExcludeVerboseContent = null;
            if (cmdletContext.LogConfig_ExcludeVerboseContent != null)
            {
                requestLogConfig_logConfig_ExcludeVerboseContent = cmdletContext.LogConfig_ExcludeVerboseContent.Value;
            }
            if (requestLogConfig_logConfig_ExcludeVerboseContent != null)
            {
                request.LogConfig.ExcludeVerboseContent = requestLogConfig_logConfig_ExcludeVerboseContent.Value;
                requestLogConfigIsNull = false;
            }
            Amazon.AppSync.FieldLogLevel requestLogConfig_logConfig_FieldLogLevel = null;
            if (cmdletContext.LogConfig_FieldLogLevel != null)
            {
                requestLogConfig_logConfig_FieldLogLevel = cmdletContext.LogConfig_FieldLogLevel;
            }
            if (requestLogConfig_logConfig_FieldLogLevel != null)
            {
                request.LogConfig.FieldLogLevel = requestLogConfig_logConfig_FieldLogLevel;
                requestLogConfigIsNull = false;
            }
             // determine if request.LogConfig should be set to null
            if (requestLogConfigIsNull)
            {
                request.LogConfig = null;
            }
            if (cmdletContext.MergedApiExecutionRoleArn != null)
            {
                request.MergedApiExecutionRoleArn = cmdletContext.MergedApiExecutionRoleArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OpenIDConnectConfig
            var requestOpenIDConnectConfigIsNull = true;
            request.OpenIDConnectConfig = new Amazon.AppSync.Model.OpenIDConnectConfig();
            System.Int64? requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL = null;
            if (cmdletContext.OpenIDConnectConfig_AuthTTL != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL = cmdletContext.OpenIDConnectConfig_AuthTTL.Value;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL != null)
            {
                request.OpenIDConnectConfig.AuthTTL = requestOpenIDConnectConfig_openIDConnectConfig_AuthTTL.Value;
                requestOpenIDConnectConfigIsNull = false;
            }
            System.String requestOpenIDConnectConfig_openIDConnectConfig_ClientId = null;
            if (cmdletContext.OpenIDConnectConfig_ClientId != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_ClientId = cmdletContext.OpenIDConnectConfig_ClientId;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_ClientId != null)
            {
                request.OpenIDConnectConfig.ClientId = requestOpenIDConnectConfig_openIDConnectConfig_ClientId;
                requestOpenIDConnectConfigIsNull = false;
            }
            System.Int64? requestOpenIDConnectConfig_openIDConnectConfig_IatTTL = null;
            if (cmdletContext.OpenIDConnectConfig_IatTTL != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_IatTTL = cmdletContext.OpenIDConnectConfig_IatTTL.Value;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_IatTTL != null)
            {
                request.OpenIDConnectConfig.IatTTL = requestOpenIDConnectConfig_openIDConnectConfig_IatTTL.Value;
                requestOpenIDConnectConfigIsNull = false;
            }
            System.String requestOpenIDConnectConfig_openIDConnectConfig_Issuer = null;
            if (cmdletContext.OpenIDConnectConfig_Issuer != null)
            {
                requestOpenIDConnectConfig_openIDConnectConfig_Issuer = cmdletContext.OpenIDConnectConfig_Issuer;
            }
            if (requestOpenIDConnectConfig_openIDConnectConfig_Issuer != null)
            {
                request.OpenIDConnectConfig.Issuer = requestOpenIDConnectConfig_openIDConnectConfig_Issuer;
                requestOpenIDConnectConfigIsNull = false;
            }
             // determine if request.OpenIDConnectConfig should be set to null
            if (requestOpenIDConnectConfigIsNull)
            {
                request.OpenIDConnectConfig = null;
            }
            if (cmdletContext.OwnerContact != null)
            {
                request.OwnerContact = cmdletContext.OwnerContact;
            }
            if (cmdletContext.QueryDepthLimit != null)
            {
                request.QueryDepthLimit = cmdletContext.QueryDepthLimit.Value;
            }
            if (cmdletContext.ResolverCountLimit != null)
            {
                request.ResolverCountLimit = cmdletContext.ResolverCountLimit.Value;
            }
            if (cmdletContext.UserPoolConfig != null)
            {
                request.UserPoolConfig = cmdletContext.UserPoolConfig;
            }
            if (cmdletContext.XrayEnabled != null)
            {
                request.XrayEnabled = cmdletContext.XrayEnabled.Value;
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
        
        private Amazon.AppSync.Model.UpdateGraphqlApiResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.UpdateGraphqlApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "UpdateGraphqlApi");
            try
            {
                #if DESKTOP
                return client.UpdateGraphqlApi(request);
                #elif CORECLR
                return client.UpdateGraphqlApiAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.AppSync.Model.AdditionalAuthenticationProvider> AdditionalAuthenticationProvider { get; set; }
            public System.String ApiId { get; set; }
            public Amazon.AppSync.AuthenticationType AuthenticationType { get; set; }
            public Amazon.AppSync.DataSourceLevelMetricsBehavior EnhancedMetricsConfig_DataSourceLevelMetricsBehavior { get; set; }
            public Amazon.AppSync.OperationLevelMetricsConfig EnhancedMetricsConfig_OperationLevelMetricsConfig { get; set; }
            public Amazon.AppSync.ResolverLevelMetricsBehavior EnhancedMetricsConfig_ResolverLevelMetricsBehavior { get; set; }
            public Amazon.AppSync.GraphQLApiIntrospectionConfig IntrospectionConfig { get; set; }
            public System.Int32? LambdaAuthorizerConfig_AuthorizerResultTtlInSecond { get; set; }
            public System.String LambdaAuthorizerConfig_AuthorizerUri { get; set; }
            public System.String LambdaAuthorizerConfig_IdentityValidationExpression { get; set; }
            public System.String LogConfig_CloudWatchLogsRoleArn { get; set; }
            public System.Boolean? LogConfig_ExcludeVerboseContent { get; set; }
            public Amazon.AppSync.FieldLogLevel LogConfig_FieldLogLevel { get; set; }
            public System.String MergedApiExecutionRoleArn { get; set; }
            public System.String Name { get; set; }
            public System.Int64? OpenIDConnectConfig_AuthTTL { get; set; }
            public System.String OpenIDConnectConfig_ClientId { get; set; }
            public System.Int64? OpenIDConnectConfig_IatTTL { get; set; }
            public System.String OpenIDConnectConfig_Issuer { get; set; }
            public System.String OwnerContact { get; set; }
            public System.Int32? QueryDepthLimit { get; set; }
            public System.Int32? ResolverCountLimit { get; set; }
            public Amazon.AppSync.Model.UserPoolConfig UserPoolConfig { get; set; }
            public System.Boolean? XrayEnabled { get; set; }
            public System.Func<Amazon.AppSync.Model.UpdateGraphqlApiResponse, UpdateASYNGraphqlApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GraphqlApi;
        }
        
    }
}
