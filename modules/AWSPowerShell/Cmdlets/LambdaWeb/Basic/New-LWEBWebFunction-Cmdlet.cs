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
using System.Threading;
using Amazon.LambdaWeb;
using Amazon.LambdaWeb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LWEB
{
    /// <summary>
    /// Creates a web function with an initial revision and endpoint. To create a web function,
    /// you provide the function name, revision configuration (code and service settings),
    /// and endpoint configuration.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>CreateWebFunction</c> permission on the
    /// web function. You don't need separate permissions for the initial revision or endpoint.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LWEBWebFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaWeb.Model.CreateWebFunctionResponse")]
    [AWSCmdlet("Calls the Lambda Web CreateWebFunction API operation.", Operation = new[] {"CreateWebFunction"}, SelectReturnType = typeof(Amazon.LambdaWeb.Model.CreateWebFunctionResponse))]
    [AWSCmdletOutput("Amazon.LambdaWeb.Model.CreateWebFunctionResponse",
        "This cmdlet returns an Amazon.LambdaWeb.Model.CreateWebFunctionResponse object containing multiple properties."
    )]
    public partial class NewLWEBWebFunctionCmdlet : AmazonLambdaWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel
        /// <summary>
        /// <para>
        /// <para>The log level for application logs emitted by the web function. If you don't specify
        /// a value, the default is <c>INFO</c>, and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.ApplicationLogLevel")]
        public Amazon.LambdaWeb.ApplicationLogLevel RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_AuthType
        /// <summary>
        /// <para>
        /// <para>The authorization type for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.AuthType")]
        public Amazon.LambdaWeb.AuthType EndpointConfig_AuthType { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_AutoDeploymentMode
        /// <summary>
        /// <para>
        /// <para>The auto-deployment mode for the endpoint. If you don't specify a value, the default
        /// is <c>Disabled</c>, and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.AutoDeploymentMode")]
        public Amazon.LambdaWeb.AutoDeploymentMode EndpointConfig_AutoDeploymentMode { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_BuildConfig_CodeConfig_S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket. Must be between 3 and 63 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_BuildConfig_CodeConfig_S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_Description
        /// <summary>
        /// <para>
        /// <para>A description of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointConfig_Description { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_Description
        /// <summary>
        /// <para>
        /// <para>A description of the revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_Description { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint. The name can contain letters, numbers, hyphens (-), and
        /// underscores (_), and can't begin or end with a hyphen or an underscore. The length
        /// constraint applies only to the full ARN. If you specify only the endpoint name, it
        /// is limited to 64 characters in length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointConfig_EndpointName { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint. Determines how traffic is served and routed across Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.EndpointType")]
        public Amazon.LambdaWeb.EndpointType EndpointConfig_EndpointType { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_ServiceConfig_EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>A map of environment variable key-value pairs available to the web function at runtime.
        /// Environment variable values are sensitive.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevisionConfig_ServiceConfig_EnvironmentVariables")]
        public System.Collections.Hashtable RevisionConfig_ServiceConfig_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_ServiceConfig_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the web function assumes when it runs. This role provides
        /// permissions to access AWS services and resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_ServiceConfig_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name of the web function. The name can contain letters, numbers, hyphens (-),
        /// and underscores (_), and can't begin or end with a hyphen or an underscore. The length
        /// constraint applies only to the full ARN. If you specify only the function name, it
        /// is limited to 64 characters in length.</para>
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_BuildConfig_CodeConfig_S3Object_Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 object key. Must be between 1 and 1024 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_BuildConfig_CodeConfig_S3Object_Key { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Key Management Service (AWS KMS) key used
        /// to encrypt the revision's code and environment variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch Logs log group the web function sends logs to. If
        /// you don't specify a value, the default is <c>/aws/lambda/web/{functionName}</c>, and
        /// this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent requests handled per execution environment. Minimum
        /// value of 1, maximum value of 128. If you don't specify a value, the default is 64,
        /// and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RevisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_ScalingConfig_MaxEnvironment
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent execution environments for the endpoint. Minimum
        /// value of 2, maximum value of 10000. There is no default value. If you don't specify
        /// a value, the scaling configuration is absent from the response. On an update, omit
        /// <c>scalingConfig</c> to keep the current value, or specify an empty object to clear
        /// a previously set value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_ScalingConfig_MaxEnvironments")]
        public System.Int32? EndpointConfig_ScalingConfig_MaxEnvironment { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_ThrottleConfig_RateLimit
        /// <summary>
        /// <para>
        /// <para>The maximum request rate per second for the endpoint. The value must be one of the
        /// following supported values: <c>0</c>, <c>100</c>, <c>200</c>, <c>300</c>, <c>400</c>,
        /// <c>500</c>, <c>600</c>, <c>700</c>, <c>800</c>, <c>900</c>, <c>1000</c>, <c>2000</c>,
        /// <c>3000</c>, <c>4000</c>, <c>5000</c>, <c>6000</c>, <c>7000</c>, <c>8000</c>, <c>9000</c>,
        /// or <c>10000</c>. The maximum effective value is also bounded by your account-level
        /// maximum total rate limit. There is no default value. If you don't specify a value,
        /// the throttling configuration is absent from the response. On an update, omit <c>throttleConfig</c>
        /// to keep the current value, or specify an empty object to clear a previously set value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EndpointConfig_ThrottleConfig_RateLimit { get; set; }
        #endregion
        
        #region Parameter EndpointConfig_Region
        /// <summary>
        /// <para>
        /// <para>The list of Regions for the endpoint. Required when the endpoint type is <c>MultiRegion</c>
        /// or <c>PerRegion</c>: specify at least one Region other than the Region where you create
        /// the endpoint (the home Region). The home Region is added automatically if you don't
        /// include it; specifying only the home Region isn't allowed. When the endpoint type
        /// is <c>HomeRegion</c>, omit this field or specify only the home Region.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfig_Regions")]
        public System.String[] EndpointConfig_Region { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_BuildConfig_RuntimeConfig_Runtime
        /// <summary>
        /// <para>
        /// <para>The runtime identifier for the web function (for example, a Node.js runtime identifier).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_BuildConfig_RuntimeConfig_Runtime { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel
        /// <summary>
        /// <para>
        /// <para>The log level for system logs emitted by the Lambda runtime. If you don't specify
        /// a value, the default is <c>INFO</c>, and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.SystemLogLevel")]
        public Amazon.LambdaWeb.SystemLogLevel RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to apply to the web function.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_ServiceConfig_TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time (in seconds) that Lambda allows the web function to run before
        /// stopping it. Minimum value of 3, maximum value of 900. If you don't specify a value,
        /// the default is 30, and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevisionConfig_ServiceConfig_TimeoutSeconds")]
        public System.Int32? RevisionConfig_ServiceConfig_TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter RevisionConfig_BuildConfig_CodeConfig_S3Object_VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the Amazon S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevisionConfig_BuildConfig_CodeConfig_S3Object_VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaWeb.Model.CreateWebFunctionResponse).
        /// Specifying the name of a property of type Amazon.LambdaWeb.Model.CreateWebFunctionResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LWEBWebFunction (CreateWebFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaWeb.Model.CreateWebFunctionResponse, NewLWEBWebFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndpointConfig_AuthType = this.EndpointConfig_AuthType;
            context.EndpointConfig_AutoDeploymentMode = this.EndpointConfig_AutoDeploymentMode;
            context.EndpointConfig_Description = this.EndpointConfig_Description;
            context.EndpointConfig_EndpointName = this.EndpointConfig_EndpointName;
            context.EndpointConfig_EndpointType = this.EndpointConfig_EndpointType;
            if (this.EndpointConfig_Region != null)
            {
                context.EndpointConfig_Region = new List<System.String>(this.EndpointConfig_Region);
            }
            context.EndpointConfig_ScalingConfig_MaxEnvironment = this.EndpointConfig_ScalingConfig_MaxEnvironment;
            context.EndpointConfig_ThrottleConfig_RateLimit = this.EndpointConfig_ThrottleConfig_RateLimit;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevisionConfig_BuildConfig_CodeConfig_S3Object_Bucket = this.RevisionConfig_BuildConfig_CodeConfig_S3Object_Bucket;
            context.RevisionConfig_BuildConfig_CodeConfig_S3Object_Key = this.RevisionConfig_BuildConfig_CodeConfig_S3Object_Key;
            context.RevisionConfig_BuildConfig_CodeConfig_S3Object_VersionId = this.RevisionConfig_BuildConfig_CodeConfig_S3Object_VersionId;
            context.RevisionConfig_BuildConfig_RuntimeConfig_Runtime = this.RevisionConfig_BuildConfig_RuntimeConfig_Runtime;
            context.RevisionConfig_Description = this.RevisionConfig_Description;
            context.RevisionConfig_KmsKeyArn = this.RevisionConfig_KmsKeyArn;
            if (this.RevisionConfig_ServiceConfig_EnvironmentVariable != null)
            {
                context.RevisionConfig_ServiceConfig_EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RevisionConfig_ServiceConfig_EnvironmentVariable.Keys)
                {
                    context.RevisionConfig_ServiceConfig_EnvironmentVariable.Add((String)hashKey, (System.String)(this.RevisionConfig_ServiceConfig_EnvironmentVariable[hashKey]));
                }
            }
            context.RevisionConfig_ServiceConfig_ExecutionRoleArn = this.RevisionConfig_ServiceConfig_ExecutionRoleArn;
            context.RevisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment = this.RevisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment;
            context.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel = this.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel;
            context.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup = this.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup;
            context.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel = this.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel;
            context.RevisionConfig_ServiceConfig_TimeoutSecond = this.RevisionConfig_ServiceConfig_TimeoutSecond;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.LambdaWeb.Model.CreateWebFunctionRequest();
            
            
             // populate EndpointConfig
            var requestEndpointConfigIsNull = true;
            request.EndpointConfig = new Amazon.LambdaWeb.Model.EndpointConfig();
            Amazon.LambdaWeb.AuthType requestEndpointConfig_endpointConfig_AuthType = null;
            if (cmdletContext.EndpointConfig_AuthType != null)
            {
                requestEndpointConfig_endpointConfig_AuthType = cmdletContext.EndpointConfig_AuthType;
            }
            if (requestEndpointConfig_endpointConfig_AuthType != null)
            {
                request.EndpointConfig.AuthType = requestEndpointConfig_endpointConfig_AuthType;
                requestEndpointConfigIsNull = false;
            }
            Amazon.LambdaWeb.AutoDeploymentMode requestEndpointConfig_endpointConfig_AutoDeploymentMode = null;
            if (cmdletContext.EndpointConfig_AutoDeploymentMode != null)
            {
                requestEndpointConfig_endpointConfig_AutoDeploymentMode = cmdletContext.EndpointConfig_AutoDeploymentMode;
            }
            if (requestEndpointConfig_endpointConfig_AutoDeploymentMode != null)
            {
                request.EndpointConfig.AutoDeploymentMode = requestEndpointConfig_endpointConfig_AutoDeploymentMode;
                requestEndpointConfigIsNull = false;
            }
            System.String requestEndpointConfig_endpointConfig_Description = null;
            if (cmdletContext.EndpointConfig_Description != null)
            {
                requestEndpointConfig_endpointConfig_Description = cmdletContext.EndpointConfig_Description;
            }
            if (requestEndpointConfig_endpointConfig_Description != null)
            {
                request.EndpointConfig.Description = requestEndpointConfig_endpointConfig_Description;
                requestEndpointConfigIsNull = false;
            }
            System.String requestEndpointConfig_endpointConfig_EndpointName = null;
            if (cmdletContext.EndpointConfig_EndpointName != null)
            {
                requestEndpointConfig_endpointConfig_EndpointName = cmdletContext.EndpointConfig_EndpointName;
            }
            if (requestEndpointConfig_endpointConfig_EndpointName != null)
            {
                request.EndpointConfig.EndpointName = requestEndpointConfig_endpointConfig_EndpointName;
                requestEndpointConfigIsNull = false;
            }
            Amazon.LambdaWeb.EndpointType requestEndpointConfig_endpointConfig_EndpointType = null;
            if (cmdletContext.EndpointConfig_EndpointType != null)
            {
                requestEndpointConfig_endpointConfig_EndpointType = cmdletContext.EndpointConfig_EndpointType;
            }
            if (requestEndpointConfig_endpointConfig_EndpointType != null)
            {
                request.EndpointConfig.EndpointType = requestEndpointConfig_endpointConfig_EndpointType;
                requestEndpointConfigIsNull = false;
            }
            List<System.String> requestEndpointConfig_endpointConfig_Region = null;
            if (cmdletContext.EndpointConfig_Region != null)
            {
                requestEndpointConfig_endpointConfig_Region = cmdletContext.EndpointConfig_Region;
            }
            if (requestEndpointConfig_endpointConfig_Region != null)
            {
                request.EndpointConfig.Regions = requestEndpointConfig_endpointConfig_Region;
                requestEndpointConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.ScalingConfig requestEndpointConfig_endpointConfig_ScalingConfig = null;
            
             // populate ScalingConfig
            var requestEndpointConfig_endpointConfig_ScalingConfigIsNull = true;
            requestEndpointConfig_endpointConfig_ScalingConfig = new Amazon.LambdaWeb.Model.ScalingConfig();
            System.Int32? requestEndpointConfig_endpointConfig_ScalingConfig_endpointConfig_ScalingConfig_MaxEnvironment = null;
            if (cmdletContext.EndpointConfig_ScalingConfig_MaxEnvironment != null)
            {
                requestEndpointConfig_endpointConfig_ScalingConfig_endpointConfig_ScalingConfig_MaxEnvironment = cmdletContext.EndpointConfig_ScalingConfig_MaxEnvironment.Value;
            }
            if (requestEndpointConfig_endpointConfig_ScalingConfig_endpointConfig_ScalingConfig_MaxEnvironment != null)
            {
                requestEndpointConfig_endpointConfig_ScalingConfig.MaxEnvironments = requestEndpointConfig_endpointConfig_ScalingConfig_endpointConfig_ScalingConfig_MaxEnvironment.Value;
                requestEndpointConfig_endpointConfig_ScalingConfigIsNull = false;
            }
             // determine if requestEndpointConfig_endpointConfig_ScalingConfig should be set to null
            if (requestEndpointConfig_endpointConfig_ScalingConfigIsNull)
            {
                requestEndpointConfig_endpointConfig_ScalingConfig = null;
            }
            if (requestEndpointConfig_endpointConfig_ScalingConfig != null)
            {
                request.EndpointConfig.ScalingConfig = requestEndpointConfig_endpointConfig_ScalingConfig;
                requestEndpointConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.ThrottleConfig requestEndpointConfig_endpointConfig_ThrottleConfig = null;
            
             // populate ThrottleConfig
            var requestEndpointConfig_endpointConfig_ThrottleConfigIsNull = true;
            requestEndpointConfig_endpointConfig_ThrottleConfig = new Amazon.LambdaWeb.Model.ThrottleConfig();
            System.Int32? requestEndpointConfig_endpointConfig_ThrottleConfig_endpointConfig_ThrottleConfig_RateLimit = null;
            if (cmdletContext.EndpointConfig_ThrottleConfig_RateLimit != null)
            {
                requestEndpointConfig_endpointConfig_ThrottleConfig_endpointConfig_ThrottleConfig_RateLimit = cmdletContext.EndpointConfig_ThrottleConfig_RateLimit.Value;
            }
            if (requestEndpointConfig_endpointConfig_ThrottleConfig_endpointConfig_ThrottleConfig_RateLimit != null)
            {
                requestEndpointConfig_endpointConfig_ThrottleConfig.RateLimit = requestEndpointConfig_endpointConfig_ThrottleConfig_endpointConfig_ThrottleConfig_RateLimit.Value;
                requestEndpointConfig_endpointConfig_ThrottleConfigIsNull = false;
            }
             // determine if requestEndpointConfig_endpointConfig_ThrottleConfig should be set to null
            if (requestEndpointConfig_endpointConfig_ThrottleConfigIsNull)
            {
                requestEndpointConfig_endpointConfig_ThrottleConfig = null;
            }
            if (requestEndpointConfig_endpointConfig_ThrottleConfig != null)
            {
                request.EndpointConfig.ThrottleConfig = requestEndpointConfig_endpointConfig_ThrottleConfig;
                requestEndpointConfigIsNull = false;
            }
             // determine if request.EndpointConfig should be set to null
            if (requestEndpointConfigIsNull)
            {
                request.EndpointConfig = null;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            
             // populate RevisionConfig
            var requestRevisionConfigIsNull = true;
            request.RevisionConfig = new Amazon.LambdaWeb.Model.RevisionConfig();
            System.String requestRevisionConfig_revisionConfig_Description = null;
            if (cmdletContext.RevisionConfig_Description != null)
            {
                requestRevisionConfig_revisionConfig_Description = cmdletContext.RevisionConfig_Description;
            }
            if (requestRevisionConfig_revisionConfig_Description != null)
            {
                request.RevisionConfig.Description = requestRevisionConfig_revisionConfig_Description;
                requestRevisionConfigIsNull = false;
            }
            System.String requestRevisionConfig_revisionConfig_KmsKeyArn = null;
            if (cmdletContext.RevisionConfig_KmsKeyArn != null)
            {
                requestRevisionConfig_revisionConfig_KmsKeyArn = cmdletContext.RevisionConfig_KmsKeyArn;
            }
            if (requestRevisionConfig_revisionConfig_KmsKeyArn != null)
            {
                request.RevisionConfig.KmsKeyArn = requestRevisionConfig_revisionConfig_KmsKeyArn;
                requestRevisionConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.BuildConfig requestRevisionConfig_revisionConfig_BuildConfig = null;
            
             // populate BuildConfig
            var requestRevisionConfig_revisionConfig_BuildConfigIsNull = true;
            requestRevisionConfig_revisionConfig_BuildConfig = new Amazon.LambdaWeb.Model.BuildConfig();
            Amazon.LambdaWeb.Model.CodeConfig requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig = null;
            
             // populate CodeConfig
            var requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfigIsNull = true;
            requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig = new Amazon.LambdaWeb.Model.CodeConfig();
            Amazon.LambdaWeb.Model.S3Object requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object = null;
            
             // populate S3Object
            var requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3ObjectIsNull = true;
            requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object = new Amazon.LambdaWeb.Model.S3Object();
            System.String requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Bucket = null;
            if (cmdletContext.RevisionConfig_BuildConfig_CodeConfig_S3Object_Bucket != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Bucket = cmdletContext.RevisionConfig_BuildConfig_CodeConfig_S3Object_Bucket;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Bucket != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object.Bucket = requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Bucket;
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3ObjectIsNull = false;
            }
            System.String requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Key = null;
            if (cmdletContext.RevisionConfig_BuildConfig_CodeConfig_S3Object_Key != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Key = cmdletContext.RevisionConfig_BuildConfig_CodeConfig_S3Object_Key;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Key != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object.Key = requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_Key;
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3ObjectIsNull = false;
            }
            System.String requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_VersionId = null;
            if (cmdletContext.RevisionConfig_BuildConfig_CodeConfig_S3Object_VersionId != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_VersionId = cmdletContext.RevisionConfig_BuildConfig_CodeConfig_S3Object_VersionId;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_VersionId != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object.VersionId = requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object_revisionConfig_BuildConfig_CodeConfig_S3Object_VersionId;
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3ObjectIsNull = false;
            }
             // determine if requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object should be set to null
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3ObjectIsNull)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object = null;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig.S3Object = requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig_revisionConfig_BuildConfig_CodeConfig_S3Object;
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfigIsNull = false;
            }
             // determine if requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig should be set to null
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfigIsNull)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig = null;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig.CodeConfig = requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_CodeConfig;
                requestRevisionConfig_revisionConfig_BuildConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.RuntimeConfig requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig = null;
            
             // populate RuntimeConfig
            var requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfigIsNull = true;
            requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig = new Amazon.LambdaWeb.Model.RuntimeConfig();
            System.String requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig_revisionConfig_BuildConfig_RuntimeConfig_Runtime = null;
            if (cmdletContext.RevisionConfig_BuildConfig_RuntimeConfig_Runtime != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig_revisionConfig_BuildConfig_RuntimeConfig_Runtime = cmdletContext.RevisionConfig_BuildConfig_RuntimeConfig_Runtime;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig_revisionConfig_BuildConfig_RuntimeConfig_Runtime != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig.Runtime = requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig_revisionConfig_BuildConfig_RuntimeConfig_Runtime;
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfigIsNull = false;
            }
             // determine if requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig should be set to null
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfigIsNull)
            {
                requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig = null;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig != null)
            {
                requestRevisionConfig_revisionConfig_BuildConfig.RuntimeConfig = requestRevisionConfig_revisionConfig_BuildConfig_revisionConfig_BuildConfig_RuntimeConfig;
                requestRevisionConfig_revisionConfig_BuildConfigIsNull = false;
            }
             // determine if requestRevisionConfig_revisionConfig_BuildConfig should be set to null
            if (requestRevisionConfig_revisionConfig_BuildConfigIsNull)
            {
                requestRevisionConfig_revisionConfig_BuildConfig = null;
            }
            if (requestRevisionConfig_revisionConfig_BuildConfig != null)
            {
                request.RevisionConfig.BuildConfig = requestRevisionConfig_revisionConfig_BuildConfig;
                requestRevisionConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.ServiceConfig requestRevisionConfig_revisionConfig_ServiceConfig = null;
            
             // populate ServiceConfig
            var requestRevisionConfig_revisionConfig_ServiceConfigIsNull = true;
            requestRevisionConfig_revisionConfig_ServiceConfig = new Amazon.LambdaWeb.Model.ServiceConfig();
            Dictionary<System.String, System.String> requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_EnvironmentVariable = null;
            if (cmdletContext.RevisionConfig_ServiceConfig_EnvironmentVariable != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_EnvironmentVariable = cmdletContext.RevisionConfig_ServiceConfig_EnvironmentVariable;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_EnvironmentVariable != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig.EnvironmentVariables = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_EnvironmentVariable;
                requestRevisionConfig_revisionConfig_ServiceConfigIsNull = false;
            }
            System.String requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_ExecutionRoleArn = null;
            if (cmdletContext.RevisionConfig_ServiceConfig_ExecutionRoleArn != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_ExecutionRoleArn = cmdletContext.RevisionConfig_ServiceConfig_ExecutionRoleArn;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_ExecutionRoleArn != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig.ExecutionRoleArn = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_ExecutionRoleArn;
                requestRevisionConfig_revisionConfig_ServiceConfigIsNull = false;
            }
            System.Int32? requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment = null;
            if (cmdletContext.RevisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment = cmdletContext.RevisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment.Value;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig.MaxConcurrencyPerEnvironment = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment.Value;
                requestRevisionConfig_revisionConfig_ServiceConfigIsNull = false;
            }
            System.Int32? requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TimeoutSecond = null;
            if (cmdletContext.RevisionConfig_ServiceConfig_TimeoutSecond != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TimeoutSecond = cmdletContext.RevisionConfig_ServiceConfig_TimeoutSecond.Value;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TimeoutSecond != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig.TimeoutSeconds = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TimeoutSecond.Value;
                requestRevisionConfig_revisionConfig_ServiceConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.TelemetryConfig requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig = null;
            
             // populate TelemetryConfig
            var requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfigIsNull = true;
            requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig = new Amazon.LambdaWeb.Model.TelemetryConfig();
            Amazon.LambdaWeb.Model.LoggingConfig requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig = null;
            
             // populate LoggingConfig
            var requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfigIsNull = true;
            requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig = new Amazon.LambdaWeb.Model.LoggingConfig();
            Amazon.LambdaWeb.ApplicationLogLevel requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel = null;
            if (cmdletContext.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel = cmdletContext.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig.ApplicationLogLevel = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel;
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfigIsNull = false;
            }
            System.String requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup = null;
            if (cmdletContext.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup = cmdletContext.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig.LogGroup = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup;
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfigIsNull = false;
            }
            Amazon.LambdaWeb.SystemLogLevel requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel = null;
            if (cmdletContext.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel = cmdletContext.RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig.SystemLogLevel = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel;
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfigIsNull = false;
            }
             // determine if requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig should be set to null
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfigIsNull)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig = null;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig.LoggingConfig = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig_revisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig;
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfigIsNull = false;
            }
             // determine if requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig should be set to null
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfigIsNull)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig = null;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig != null)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig.TelemetryConfig = requestRevisionConfig_revisionConfig_ServiceConfig_revisionConfig_ServiceConfig_TelemetryConfig;
                requestRevisionConfig_revisionConfig_ServiceConfigIsNull = false;
            }
             // determine if requestRevisionConfig_revisionConfig_ServiceConfig should be set to null
            if (requestRevisionConfig_revisionConfig_ServiceConfigIsNull)
            {
                requestRevisionConfig_revisionConfig_ServiceConfig = null;
            }
            if (requestRevisionConfig_revisionConfig_ServiceConfig != null)
            {
                request.RevisionConfig.ServiceConfig = requestRevisionConfig_revisionConfig_ServiceConfig;
                requestRevisionConfigIsNull = false;
            }
             // determine if request.RevisionConfig should be set to null
            if (requestRevisionConfigIsNull)
            {
                request.RevisionConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LambdaWeb.Model.CreateWebFunctionResponse CallAWSServiceOperation(IAmazonLambdaWeb client, Amazon.LambdaWeb.Model.CreateWebFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda Web", "CreateWebFunction");
            try
            {
                return client.CreateWebFunctionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.LambdaWeb.AuthType EndpointConfig_AuthType { get; set; }
            public Amazon.LambdaWeb.AutoDeploymentMode EndpointConfig_AutoDeploymentMode { get; set; }
            public System.String EndpointConfig_Description { get; set; }
            public System.String EndpointConfig_EndpointName { get; set; }
            public Amazon.LambdaWeb.EndpointType EndpointConfig_EndpointType { get; set; }
            public List<System.String> EndpointConfig_Region { get; set; }
            public System.Int32? EndpointConfig_ScalingConfig_MaxEnvironment { get; set; }
            public System.Int32? EndpointConfig_ThrottleConfig_RateLimit { get; set; }
            public System.String FunctionName { get; set; }
            public System.String RevisionConfig_BuildConfig_CodeConfig_S3Object_Bucket { get; set; }
            public System.String RevisionConfig_BuildConfig_CodeConfig_S3Object_Key { get; set; }
            public System.String RevisionConfig_BuildConfig_CodeConfig_S3Object_VersionId { get; set; }
            public System.String RevisionConfig_BuildConfig_RuntimeConfig_Runtime { get; set; }
            public System.String RevisionConfig_Description { get; set; }
            public System.String RevisionConfig_KmsKeyArn { get; set; }
            public Dictionary<System.String, System.String> RevisionConfig_ServiceConfig_EnvironmentVariable { get; set; }
            public System.String RevisionConfig_ServiceConfig_ExecutionRoleArn { get; set; }
            public System.Int32? RevisionConfig_ServiceConfig_MaxConcurrencyPerEnvironment { get; set; }
            public Amazon.LambdaWeb.ApplicationLogLevel RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel { get; set; }
            public System.String RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup { get; set; }
            public Amazon.LambdaWeb.SystemLogLevel RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel { get; set; }
            public System.Int32? RevisionConfig_ServiceConfig_TimeoutSecond { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LambdaWeb.Model.CreateWebFunctionResponse, NewLWEBWebFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
