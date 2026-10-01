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
    /// Creates an immutable revision for a web function. A revision represents a specific
    /// version of the function code and configuration.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>CreateWebFunctionRevision</c> permission
    /// on the web function, not on the revision being created.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LWEBWebFunctionRevision", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse")]
    [AWSCmdlet("Calls the Lambda Web CreateWebFunctionRevision API operation.", Operation = new[] {"CreateWebFunctionRevision"}, SelectReturnType = typeof(Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse))]
    [AWSCmdletOutput("Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse",
        "This cmdlet returns an Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse object containing multiple properties."
    )]
    public partial class NewLWEBWebFunctionRevisionCmdlet : AmazonLambdaWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel
        /// <summary>
        /// <para>
        /// <para>The log level for application logs emitted by the web function. If you don't specify
        /// a value, the default is <c>INFO</c>, and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.ApplicationLogLevel")]
        public Amazon.LambdaWeb.ApplicationLogLevel ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel { get; set; }
        #endregion
        
        #region Parameter BuildConfig_CodeConfig_S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket. Must be between 3 and 63 characters.</para>
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
        public System.String BuildConfig_CodeConfig_S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the revision.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ServiceConfig_EnvironmentVariable
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
        [Alias("ServiceConfig_EnvironmentVariables")]
        public System.Collections.Hashtable ServiceConfig_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter ServiceConfig_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that the web function assumes when it runs. This role provides
        /// permissions to access AWS services and resources.</para>
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
        public System.String ServiceConfig_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name of the web function. You can specify the function name or the function ARN.
        /// The length constraint applies only to the full ARN. If you specify only the function
        /// name, it is limited to 64 characters in length.</para>
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
        
        #region Parameter BuildConfig_CodeConfig_S3Object_Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 object key. Must be between 1 and 1024 characters.</para>
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
        public System.String BuildConfig_CodeConfig_S3Object_Key { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Key Management Service (AWS KMS) key used
        /// to encrypt the revision's code and environment variables.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch Logs log group the web function sends logs to. If
        /// you don't specify a value, the default is <c>/aws/lambda/web/{functionName}</c>, and
        /// this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup { get; set; }
        #endregion
        
        #region Parameter ServiceConfig_MaxConcurrencyPerEnvironment
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent requests handled per execution environment. Minimum
        /// value of 1, maximum value of 128. If you don't specify a value, the default is 64,
        /// and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ServiceConfig_MaxConcurrencyPerEnvironment { get; set; }
        #endregion
        
        #region Parameter BuildConfig_RuntimeConfig_Runtime
        /// <summary>
        /// <para>
        /// <para>The runtime identifier for the web function (for example, a Node.js runtime identifier).</para>
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
        public System.String BuildConfig_RuntimeConfig_Runtime { get; set; }
        #endregion
        
        #region Parameter ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel
        /// <summary>
        /// <para>
        /// <para>The log level for system logs emitted by the Lambda runtime. If you don't specify
        /// a value, the default is <c>INFO</c>, and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LambdaWeb.SystemLogLevel")]
        public Amazon.LambdaWeb.SystemLogLevel ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel { get; set; }
        #endregion
        
        #region Parameter ServiceConfig_TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time (in seconds) that Lambda allows the web function to run before
        /// stopping it. Minimum value of 3, maximum value of 900. If you don't specify a value,
        /// the default is 30, and this default is returned in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConfig_TimeoutSeconds")]
        public System.Int32? ServiceConfig_TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter BuildConfig_CodeConfig_S3Object_VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the Amazon S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildConfig_CodeConfig_S3Object_VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse).
        /// Specifying the name of a property of type Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LWEBWebFunctionRevision (CreateWebFunctionRevision)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse, NewLWEBWebFunctionRevisionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BuildConfig_CodeConfig_S3Object_Bucket = this.BuildConfig_CodeConfig_S3Object_Bucket;
            #if MODULAR
            if (this.BuildConfig_CodeConfig_S3Object_Bucket == null && ParameterWasBound(nameof(this.BuildConfig_CodeConfig_S3Object_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter BuildConfig_CodeConfig_S3Object_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BuildConfig_CodeConfig_S3Object_Key = this.BuildConfig_CodeConfig_S3Object_Key;
            #if MODULAR
            if (this.BuildConfig_CodeConfig_S3Object_Key == null && ParameterWasBound(nameof(this.BuildConfig_CodeConfig_S3Object_Key)))
            {
                WriteWarning("You are passing $null as a value for parameter BuildConfig_CodeConfig_S3Object_Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BuildConfig_CodeConfig_S3Object_VersionId = this.BuildConfig_CodeConfig_S3Object_VersionId;
            context.BuildConfig_RuntimeConfig_Runtime = this.BuildConfig_RuntimeConfig_Runtime;
            #if MODULAR
            if (this.BuildConfig_RuntimeConfig_Runtime == null && ParameterWasBound(nameof(this.BuildConfig_RuntimeConfig_Runtime)))
            {
                WriteWarning("You are passing $null as a value for parameter BuildConfig_RuntimeConfig_Runtime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyArn = this.KmsKeyArn;
            if (this.ServiceConfig_EnvironmentVariable != null)
            {
                context.ServiceConfig_EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ServiceConfig_EnvironmentVariable.Keys)
                {
                    context.ServiceConfig_EnvironmentVariable.Add((String)hashKey, (System.String)(this.ServiceConfig_EnvironmentVariable[hashKey]));
                }
            }
            context.ServiceConfig_ExecutionRoleArn = this.ServiceConfig_ExecutionRoleArn;
            #if MODULAR
            if (this.ServiceConfig_ExecutionRoleArn == null && ParameterWasBound(nameof(this.ServiceConfig_ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceConfig_ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceConfig_MaxConcurrencyPerEnvironment = this.ServiceConfig_MaxConcurrencyPerEnvironment;
            context.ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel = this.ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel;
            context.ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup = this.ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup;
            context.ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel = this.ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel;
            context.ServiceConfig_TimeoutSecond = this.ServiceConfig_TimeoutSecond;
            
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
            var request = new Amazon.LambdaWeb.Model.CreateWebFunctionRevisionRequest();
            
            
             // populate BuildConfig
            var requestBuildConfigIsNull = true;
            request.BuildConfig = new Amazon.LambdaWeb.Model.BuildConfig();
            Amazon.LambdaWeb.Model.CodeConfig requestBuildConfig_buildConfig_CodeConfig = null;
            
             // populate CodeConfig
            var requestBuildConfig_buildConfig_CodeConfigIsNull = true;
            requestBuildConfig_buildConfig_CodeConfig = new Amazon.LambdaWeb.Model.CodeConfig();
            Amazon.LambdaWeb.Model.S3Object requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object = null;
            
             // populate S3Object
            var requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3ObjectIsNull = true;
            requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object = new Amazon.LambdaWeb.Model.S3Object();
            System.String requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Bucket = null;
            if (cmdletContext.BuildConfig_CodeConfig_S3Object_Bucket != null)
            {
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Bucket = cmdletContext.BuildConfig_CodeConfig_S3Object_Bucket;
            }
            if (requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Bucket != null)
            {
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object.Bucket = requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Bucket;
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3ObjectIsNull = false;
            }
            System.String requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Key = null;
            if (cmdletContext.BuildConfig_CodeConfig_S3Object_Key != null)
            {
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Key = cmdletContext.BuildConfig_CodeConfig_S3Object_Key;
            }
            if (requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Key != null)
            {
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object.Key = requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_Key;
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3ObjectIsNull = false;
            }
            System.String requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_VersionId = null;
            if (cmdletContext.BuildConfig_CodeConfig_S3Object_VersionId != null)
            {
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_VersionId = cmdletContext.BuildConfig_CodeConfig_S3Object_VersionId;
            }
            if (requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_VersionId != null)
            {
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object.VersionId = requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object_buildConfig_CodeConfig_S3Object_VersionId;
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3ObjectIsNull = false;
            }
             // determine if requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object should be set to null
            if (requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3ObjectIsNull)
            {
                requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object = null;
            }
            if (requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object != null)
            {
                requestBuildConfig_buildConfig_CodeConfig.S3Object = requestBuildConfig_buildConfig_CodeConfig_buildConfig_CodeConfig_S3Object;
                requestBuildConfig_buildConfig_CodeConfigIsNull = false;
            }
             // determine if requestBuildConfig_buildConfig_CodeConfig should be set to null
            if (requestBuildConfig_buildConfig_CodeConfigIsNull)
            {
                requestBuildConfig_buildConfig_CodeConfig = null;
            }
            if (requestBuildConfig_buildConfig_CodeConfig != null)
            {
                request.BuildConfig.CodeConfig = requestBuildConfig_buildConfig_CodeConfig;
                requestBuildConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.RuntimeConfig requestBuildConfig_buildConfig_RuntimeConfig = null;
            
             // populate RuntimeConfig
            var requestBuildConfig_buildConfig_RuntimeConfigIsNull = true;
            requestBuildConfig_buildConfig_RuntimeConfig = new Amazon.LambdaWeb.Model.RuntimeConfig();
            System.String requestBuildConfig_buildConfig_RuntimeConfig_buildConfig_RuntimeConfig_Runtime = null;
            if (cmdletContext.BuildConfig_RuntimeConfig_Runtime != null)
            {
                requestBuildConfig_buildConfig_RuntimeConfig_buildConfig_RuntimeConfig_Runtime = cmdletContext.BuildConfig_RuntimeConfig_Runtime;
            }
            if (requestBuildConfig_buildConfig_RuntimeConfig_buildConfig_RuntimeConfig_Runtime != null)
            {
                requestBuildConfig_buildConfig_RuntimeConfig.Runtime = requestBuildConfig_buildConfig_RuntimeConfig_buildConfig_RuntimeConfig_Runtime;
                requestBuildConfig_buildConfig_RuntimeConfigIsNull = false;
            }
             // determine if requestBuildConfig_buildConfig_RuntimeConfig should be set to null
            if (requestBuildConfig_buildConfig_RuntimeConfigIsNull)
            {
                requestBuildConfig_buildConfig_RuntimeConfig = null;
            }
            if (requestBuildConfig_buildConfig_RuntimeConfig != null)
            {
                request.BuildConfig.RuntimeConfig = requestBuildConfig_buildConfig_RuntimeConfig;
                requestBuildConfigIsNull = false;
            }
             // determine if request.BuildConfig should be set to null
            if (requestBuildConfigIsNull)
            {
                request.BuildConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            
             // populate ServiceConfig
            var requestServiceConfigIsNull = true;
            request.ServiceConfig = new Amazon.LambdaWeb.Model.ServiceConfig();
            Dictionary<System.String, System.String> requestServiceConfig_serviceConfig_EnvironmentVariable = null;
            if (cmdletContext.ServiceConfig_EnvironmentVariable != null)
            {
                requestServiceConfig_serviceConfig_EnvironmentVariable = cmdletContext.ServiceConfig_EnvironmentVariable;
            }
            if (requestServiceConfig_serviceConfig_EnvironmentVariable != null)
            {
                request.ServiceConfig.EnvironmentVariables = requestServiceConfig_serviceConfig_EnvironmentVariable;
                requestServiceConfigIsNull = false;
            }
            System.String requestServiceConfig_serviceConfig_ExecutionRoleArn = null;
            if (cmdletContext.ServiceConfig_ExecutionRoleArn != null)
            {
                requestServiceConfig_serviceConfig_ExecutionRoleArn = cmdletContext.ServiceConfig_ExecutionRoleArn;
            }
            if (requestServiceConfig_serviceConfig_ExecutionRoleArn != null)
            {
                request.ServiceConfig.ExecutionRoleArn = requestServiceConfig_serviceConfig_ExecutionRoleArn;
                requestServiceConfigIsNull = false;
            }
            System.Int32? requestServiceConfig_serviceConfig_MaxConcurrencyPerEnvironment = null;
            if (cmdletContext.ServiceConfig_MaxConcurrencyPerEnvironment != null)
            {
                requestServiceConfig_serviceConfig_MaxConcurrencyPerEnvironment = cmdletContext.ServiceConfig_MaxConcurrencyPerEnvironment.Value;
            }
            if (requestServiceConfig_serviceConfig_MaxConcurrencyPerEnvironment != null)
            {
                request.ServiceConfig.MaxConcurrencyPerEnvironment = requestServiceConfig_serviceConfig_MaxConcurrencyPerEnvironment.Value;
                requestServiceConfigIsNull = false;
            }
            System.Int32? requestServiceConfig_serviceConfig_TimeoutSecond = null;
            if (cmdletContext.ServiceConfig_TimeoutSecond != null)
            {
                requestServiceConfig_serviceConfig_TimeoutSecond = cmdletContext.ServiceConfig_TimeoutSecond.Value;
            }
            if (requestServiceConfig_serviceConfig_TimeoutSecond != null)
            {
                request.ServiceConfig.TimeoutSeconds = requestServiceConfig_serviceConfig_TimeoutSecond.Value;
                requestServiceConfigIsNull = false;
            }
            Amazon.LambdaWeb.Model.TelemetryConfig requestServiceConfig_serviceConfig_TelemetryConfig = null;
            
             // populate TelemetryConfig
            var requestServiceConfig_serviceConfig_TelemetryConfigIsNull = true;
            requestServiceConfig_serviceConfig_TelemetryConfig = new Amazon.LambdaWeb.Model.TelemetryConfig();
            Amazon.LambdaWeb.Model.LoggingConfig requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig = null;
            
             // populate LoggingConfig
            var requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfigIsNull = true;
            requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig = new Amazon.LambdaWeb.Model.LoggingConfig();
            Amazon.LambdaWeb.ApplicationLogLevel requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel = null;
            if (cmdletContext.ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel != null)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel = cmdletContext.ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel;
            }
            if (requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel != null)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig.ApplicationLogLevel = requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel;
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfigIsNull = false;
            }
            System.String requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_LogGroup = null;
            if (cmdletContext.ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup != null)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_LogGroup = cmdletContext.ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup;
            }
            if (requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_LogGroup != null)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig.LogGroup = requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_LogGroup;
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfigIsNull = false;
            }
            Amazon.LambdaWeb.SystemLogLevel requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel = null;
            if (cmdletContext.ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel != null)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel = cmdletContext.ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel;
            }
            if (requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel != null)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig.SystemLogLevel = requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig_serviceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel;
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfigIsNull = false;
            }
             // determine if requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig should be set to null
            if (requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfigIsNull)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig = null;
            }
            if (requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig != null)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig.LoggingConfig = requestServiceConfig_serviceConfig_TelemetryConfig_serviceConfig_TelemetryConfig_LoggingConfig;
                requestServiceConfig_serviceConfig_TelemetryConfigIsNull = false;
            }
             // determine if requestServiceConfig_serviceConfig_TelemetryConfig should be set to null
            if (requestServiceConfig_serviceConfig_TelemetryConfigIsNull)
            {
                requestServiceConfig_serviceConfig_TelemetryConfig = null;
            }
            if (requestServiceConfig_serviceConfig_TelemetryConfig != null)
            {
                request.ServiceConfig.TelemetryConfig = requestServiceConfig_serviceConfig_TelemetryConfig;
                requestServiceConfigIsNull = false;
            }
             // determine if request.ServiceConfig should be set to null
            if (requestServiceConfigIsNull)
            {
                request.ServiceConfig = null;
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
        
        private Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse CallAWSServiceOperation(IAmazonLambdaWeb client, Amazon.LambdaWeb.Model.CreateWebFunctionRevisionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda Web", "CreateWebFunctionRevision");
            try
            {
                return client.CreateWebFunctionRevisionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BuildConfig_CodeConfig_S3Object_Bucket { get; set; }
            public System.String BuildConfig_CodeConfig_S3Object_Key { get; set; }
            public System.String BuildConfig_CodeConfig_S3Object_VersionId { get; set; }
            public System.String BuildConfig_RuntimeConfig_Runtime { get; set; }
            public System.String Description { get; set; }
            public System.String FunctionName { get; set; }
            public System.String KmsKeyArn { get; set; }
            public Dictionary<System.String, System.String> ServiceConfig_EnvironmentVariable { get; set; }
            public System.String ServiceConfig_ExecutionRoleArn { get; set; }
            public System.Int32? ServiceConfig_MaxConcurrencyPerEnvironment { get; set; }
            public Amazon.LambdaWeb.ApplicationLogLevel ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel { get; set; }
            public System.String ServiceConfig_TelemetryConfig_LoggingConfig_LogGroup { get; set; }
            public Amazon.LambdaWeb.SystemLogLevel ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel { get; set; }
            public System.Int32? ServiceConfig_TimeoutSecond { get; set; }
            public System.Func<Amazon.LambdaWeb.Model.CreateWebFunctionRevisionResponse, NewLWEBWebFunctionRevisionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
