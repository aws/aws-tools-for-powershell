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
using Amazon.EMRServerless;
using Amazon.EMRServerless.Model;

namespace Amazon.PowerShell.Cmdlets.EMRServerless
{
    /// <summary>
    /// Starts a job run.
    /// </summary>
    [Cmdlet("Start", "EMRServerlessJobRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRServerless.Model.StartJobRunResponse")]
    [AWSCmdlet("Calls the EMR Serverless StartJobRun API operation.", Operation = new[] {"StartJobRun"}, SelectReturnType = typeof(Amazon.EMRServerless.Model.StartJobRunResponse))]
    [AWSCmdletOutput("Amazon.EMRServerless.Model.StartJobRunResponse",
        "This cmdlet returns an Amazon.EMRServerless.Model.StartJobRunResponse object containing multiple properties."
    )]
    public partial class StartEMRServerlessJobRunCmdlet : AmazonEMRServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationOverrides_ApplicationConfiguration
        /// <summary>
        /// <para>
        /// <para>The override configurations for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EMRServerless.Model.Configuration[] ConfigurationOverrides_ApplicationConfiguration { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the application on which to run the job.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled")]
        public System.Boolean? CloudWatchLoggingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter ManagedPersistenceMonitoringConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables managed logging and defaults to true. If set to false, managed logging will
        /// be turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_Enabled")]
        public System.Boolean? ManagedPersistenceMonitoringConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Key Management Service (KMS) key ARN to encrypt the logs that you store in CloudWatch
        /// Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn")]
        public System.String CloudWatchLoggingConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN to encrypt the logs stored in managed log persistence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn")]
        public System.String ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter S3MonitoringConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN to encrypt the logs published to the given Amazon S3 destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_EncryptionKeyArn")]
        public System.String S3MonitoringConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter SparkSubmit_EntryPoint
        /// <summary>
        /// <para>
        /// <para>The entry point for the Spark submit job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSubmit_EntryPoint")]
        public System.String SparkSubmit_EntryPoint { get; set; }
        #endregion
        
        #region Parameter SparkSubmit_EntryPointArgument
        /// <summary>
        /// <para>
        /// <para>The arguments for the Spark submit job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSubmit_EntryPointArguments")]
        public System.String[] SparkSubmit_EntryPointArgument { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role ARN for the job run.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ExecutionTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The maximum duration for the job run to run. If the job run runs beyond this duration,
        /// it will be automatically cancelled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionTimeoutMinutes")]
        public System.Int64? ExecutionTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter Hive_InitQueryFile
        /// <summary>
        /// <para>
        /// <para>The query file for the Hive job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_Hive_InitQueryFile")]
        public System.String Hive_InitQueryFile { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group in Amazon CloudWatch Logs where you want to publish your
        /// logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroupName")]
        public System.String CloudWatchLoggingConfiguration_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>Prefix for the CloudWatch log stream name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix")]
        public System.String CloudWatchLoggingConfiguration_LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_LogType
        /// <summary>
        /// <para>
        /// <para>The types of logs that you want to publish to CloudWatch. If you don't specify any
        /// log types, driver STDOUT and STDERR logs will be published to CloudWatch Logs by default.
        /// For more information including the supported worker types for Hive and Spark, see
        /// <a href="https://docs.aws.amazon.com/emr/latest/EMR-Serverless-UserGuide/logging.html#jobs-log-storage-cw">Logging
        /// for EMR Serverless with CloudWatch</a>.</para><ul><li><para><b>Key Valid Values</b>: <c>SPARK_DRIVER</c>, <c>SPARK_EXECUTOR</c>, <c>HIVE_DRIVER</c>,
        /// <c>TEZ_TASK</c></para></li><li><para><b>Array Members Valid Values</b>: <c>STDOUT</c>, <c>STDERR</c>, <c>HIVE_LOG</c>,
        /// <c>TEZ_AM</c>, <c>SYSTEM_LOGS</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_LogTypes")]
        public System.Collections.Hashtable CloudWatchLoggingConfiguration_LogType { get; set; }
        #endregion
        
        #region Parameter S3MonitoringConfiguration_LogUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 destination URI for log publishing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_LogUri")]
        public System.String S3MonitoringConfiguration_LogUri { get; set; }
        #endregion
        
        #region Parameter RetryPolicy_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>Maximum number of attempts for the job run. This parameter is only applicable for
        /// <c>BATCH</c> mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryPolicy_MaxAttempts")]
        public System.Int32? RetryPolicy_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter RetryPolicy_MaxFailedAttemptsPerHour
        /// <summary>
        /// <para>
        /// <para>Maximum number of failed attempts per hour. This [arameter is only applicable for
        /// <c>STREAMING</c> mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RetryPolicy_MaxFailedAttemptsPerHour { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>The mode of the job run when it starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EMRServerless.JobRunMode")]
        public Amazon.EMRServerless.JobRunMode Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The optional job run name. This doesn't have to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Hive_Parameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the Hive job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_Hive_Parameters")]
        public System.String Hive_Parameter { get; set; }
        #endregion
        
        #region Parameter Hive_Query
        /// <summary>
        /// <para>
        /// <para>The query for the Hive job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_Hive_Query")]
        public System.String Hive_Query { get; set; }
        #endregion
        
        #region Parameter PrometheusMonitoringConfiguration_RemoteWriteUrl
        /// <summary>
        /// <para>
        /// <para>The remote write URL in the Amazon Managed Service for Prometheus workspace to send
        /// metrics to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration_RemoteWriteUrl")]
        public System.String PrometheusMonitoringConfiguration_RemoteWriteUrl { get; set; }
        #endregion
        
        #region Parameter SparkSubmit_SparkSubmitParameter
        /// <summary>
        /// <para>
        /// <para>The parameters for the Spark submit job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSubmit_SparkSubmitParameters")]
        public System.String SparkSubmit_SparkSubmitParameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client idempotency token of the job run to start. Its value must be unique for
        /// each request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRServerless.Model.StartJobRunResponse).
        /// Specifying the name of a property of type Amazon.EMRServerless.Model.StartJobRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMRServerlessJobRun (StartJobRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRServerless.Model.StartJobRunResponse, StartEMRServerlessJobRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.ConfigurationOverrides_ApplicationConfiguration != null)
            {
                context.ConfigurationOverrides_ApplicationConfiguration = new List<Amazon.EMRServerless.Model.Configuration>(this.ConfigurationOverrides_ApplicationConfiguration);
            }
            context.CloudWatchLoggingConfiguration_Enabled = this.CloudWatchLoggingConfiguration_Enabled;
            context.CloudWatchLoggingConfiguration_EncryptionKeyArn = this.CloudWatchLoggingConfiguration_EncryptionKeyArn;
            context.CloudWatchLoggingConfiguration_LogGroupName = this.CloudWatchLoggingConfiguration_LogGroupName;
            context.CloudWatchLoggingConfiguration_LogStreamNamePrefix = this.CloudWatchLoggingConfiguration_LogStreamNamePrefix;
            if (this.CloudWatchLoggingConfiguration_LogType != null)
            {
                context.CloudWatchLoggingConfiguration_LogType = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.CloudWatchLoggingConfiguration_LogType.Keys)
                {
                    object hashValue = this.CloudWatchLoggingConfiguration_LogType[hashKey];
                    if (hashValue == null)
                    {
                        context.CloudWatchLoggingConfiguration_LogType.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.CloudWatchLoggingConfiguration_LogType.Add((String)hashKey, valueSet);
                }
            }
            context.ManagedPersistenceMonitoringConfiguration_Enabled = this.ManagedPersistenceMonitoringConfiguration_Enabled;
            context.ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn = this.ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn;
            context.PrometheusMonitoringConfiguration_RemoteWriteUrl = this.PrometheusMonitoringConfiguration_RemoteWriteUrl;
            context.S3MonitoringConfiguration_EncryptionKeyArn = this.S3MonitoringConfiguration_EncryptionKeyArn;
            context.S3MonitoringConfiguration_LogUri = this.S3MonitoringConfiguration_LogUri;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionTimeoutMinute = this.ExecutionTimeoutMinute;
            context.Hive_InitQueryFile = this.Hive_InitQueryFile;
            context.Hive_Parameter = this.Hive_Parameter;
            context.Hive_Query = this.Hive_Query;
            context.SparkSubmit_EntryPoint = this.SparkSubmit_EntryPoint;
            if (this.SparkSubmit_EntryPointArgument != null)
            {
                context.SparkSubmit_EntryPointArgument = new List<System.String>(this.SparkSubmit_EntryPointArgument);
            }
            context.SparkSubmit_SparkSubmitParameter = this.SparkSubmit_SparkSubmitParameter;
            context.Mode = this.Mode;
            context.Name = this.Name;
            context.RetryPolicy_MaxAttempt = this.RetryPolicy_MaxAttempt;
            context.RetryPolicy_MaxFailedAttemptsPerHour = this.RetryPolicy_MaxFailedAttemptsPerHour;
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
            var request = new Amazon.EMRServerless.Model.StartJobRunRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConfigurationOverrides
            var requestConfigurationOverridesIsNull = true;
            request.ConfigurationOverrides = new Amazon.EMRServerless.Model.ConfigurationOverrides();
            List<Amazon.EMRServerless.Model.Configuration> requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration = null;
            if (cmdletContext.ConfigurationOverrides_ApplicationConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration = cmdletContext.ConfigurationOverrides_ApplicationConfiguration;
            }
            if (requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration != null)
            {
                request.ConfigurationOverrides.ApplicationConfiguration = requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration;
                requestConfigurationOverridesIsNull = false;
            }
            Amazon.EMRServerless.Model.MonitoringConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration = null;
            
             // populate MonitoringConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration = new Amazon.EMRServerless.Model.MonitoringConfiguration();
            Amazon.EMRServerless.Model.PrometheusMonitoringConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration = null;
            
             // populate PrometheusMonitoringConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration = new Amazon.EMRServerless.Model.PrometheusMonitoringConfiguration();
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl = null;
            if (cmdletContext.PrometheusMonitoringConfiguration_RemoteWriteUrl != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl = cmdletContext.PrometheusMonitoringConfiguration_RemoteWriteUrl;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration.RemoteWriteUrl = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfigurationIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfigurationIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.PrometheusMonitoringConfiguration = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_PrometheusMonitoringConfiguration;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = false;
            }
            Amazon.EMRServerless.Model.ManagedPersistenceMonitoringConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration = null;
            
             // populate ManagedPersistenceMonitoringConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration = new Amazon.EMRServerless.Model.ManagedPersistenceMonitoringConfiguration();
            System.Boolean? requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled = null;
            if (cmdletContext.ManagedPersistenceMonitoringConfiguration_Enabled != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled = cmdletContext.ManagedPersistenceMonitoringConfiguration_Enabled.Value;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration.Enabled = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled.Value;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn = cmdletContext.ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration.EncryptionKeyArn = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.ManagedPersistenceMonitoringConfiguration = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = false;
            }
            Amazon.EMRServerless.Model.S3MonitoringConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = null;
            
             // populate S3MonitoringConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = new Amazon.EMRServerless.Model.S3MonitoringConfiguration();
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.S3MonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn = cmdletContext.S3MonitoringConfiguration_EncryptionKeyArn;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration.EncryptionKeyArn = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri = null;
            if (cmdletContext.S3MonitoringConfiguration_LogUri != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri = cmdletContext.S3MonitoringConfiguration_LogUri;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration.LogUri = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.S3MonitoringConfiguration = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = false;
            }
            Amazon.EMRServerless.Model.CloudWatchLoggingConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration = null;
            
             // populate CloudWatchLoggingConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration = new Amazon.EMRServerless.Model.CloudWatchLoggingConfiguration();
            System.Boolean? requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_Enabled != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled = cmdletContext.CloudWatchLoggingConfiguration_Enabled.Value;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration.Enabled = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled.Value;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn = cmdletContext.CloudWatchLoggingConfiguration_EncryptionKeyArn;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration.EncryptionKeyArn = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_LogGroupName != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName = cmdletContext.CloudWatchLoggingConfiguration_LogGroupName;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration.LogGroupName = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_LogStreamNamePrefix != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix = cmdletContext.CloudWatchLoggingConfiguration_LogStreamNamePrefix;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration.LogStreamNamePrefix = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_LogType != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType = cmdletContext.CloudWatchLoggingConfiguration_LogType;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration.LogTypes = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfigurationIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.CloudWatchLoggingConfiguration = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchLoggingConfiguration;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration != null)
            {
                request.ConfigurationOverrides.MonitoringConfiguration = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration;
                requestConfigurationOverridesIsNull = false;
            }
             // determine if request.ConfigurationOverrides should be set to null
            if (requestConfigurationOverridesIsNull)
            {
                request.ConfigurationOverrides = null;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.ExecutionTimeoutMinute != null)
            {
                request.ExecutionTimeoutMinutes = cmdletContext.ExecutionTimeoutMinute.Value;
            }
            
             // populate JobDriver
            var requestJobDriverIsNull = true;
            request.JobDriver = new Amazon.EMRServerless.Model.JobDriver();
            Amazon.EMRServerless.Model.Hive requestJobDriver_jobDriver_Hive = null;
            
             // populate Hive
            var requestJobDriver_jobDriver_HiveIsNull = true;
            requestJobDriver_jobDriver_Hive = new Amazon.EMRServerless.Model.Hive();
            System.String requestJobDriver_jobDriver_Hive_hive_InitQueryFile = null;
            if (cmdletContext.Hive_InitQueryFile != null)
            {
                requestJobDriver_jobDriver_Hive_hive_InitQueryFile = cmdletContext.Hive_InitQueryFile;
            }
            if (requestJobDriver_jobDriver_Hive_hive_InitQueryFile != null)
            {
                requestJobDriver_jobDriver_Hive.InitQueryFile = requestJobDriver_jobDriver_Hive_hive_InitQueryFile;
                requestJobDriver_jobDriver_HiveIsNull = false;
            }
            System.String requestJobDriver_jobDriver_Hive_hive_Parameter = null;
            if (cmdletContext.Hive_Parameter != null)
            {
                requestJobDriver_jobDriver_Hive_hive_Parameter = cmdletContext.Hive_Parameter;
            }
            if (requestJobDriver_jobDriver_Hive_hive_Parameter != null)
            {
                requestJobDriver_jobDriver_Hive.Parameters = requestJobDriver_jobDriver_Hive_hive_Parameter;
                requestJobDriver_jobDriver_HiveIsNull = false;
            }
            System.String requestJobDriver_jobDriver_Hive_hive_Query = null;
            if (cmdletContext.Hive_Query != null)
            {
                requestJobDriver_jobDriver_Hive_hive_Query = cmdletContext.Hive_Query;
            }
            if (requestJobDriver_jobDriver_Hive_hive_Query != null)
            {
                requestJobDriver_jobDriver_Hive.Query = requestJobDriver_jobDriver_Hive_hive_Query;
                requestJobDriver_jobDriver_HiveIsNull = false;
            }
             // determine if requestJobDriver_jobDriver_Hive should be set to null
            if (requestJobDriver_jobDriver_HiveIsNull)
            {
                requestJobDriver_jobDriver_Hive = null;
            }
            if (requestJobDriver_jobDriver_Hive != null)
            {
                request.JobDriver.Hive = requestJobDriver_jobDriver_Hive;
                requestJobDriverIsNull = false;
            }
            Amazon.EMRServerless.Model.SparkSubmit requestJobDriver_jobDriver_SparkSubmit = null;
            
             // populate SparkSubmit
            var requestJobDriver_jobDriver_SparkSubmitIsNull = true;
            requestJobDriver_jobDriver_SparkSubmit = new Amazon.EMRServerless.Model.SparkSubmit();
            System.String requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPoint = null;
            if (cmdletContext.SparkSubmit_EntryPoint != null)
            {
                requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPoint = cmdletContext.SparkSubmit_EntryPoint;
            }
            if (requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPoint != null)
            {
                requestJobDriver_jobDriver_SparkSubmit.EntryPoint = requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPoint;
                requestJobDriver_jobDriver_SparkSubmitIsNull = false;
            }
            List<System.String> requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPointArgument = null;
            if (cmdletContext.SparkSubmit_EntryPointArgument != null)
            {
                requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPointArgument = cmdletContext.SparkSubmit_EntryPointArgument;
            }
            if (requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPointArgument != null)
            {
                requestJobDriver_jobDriver_SparkSubmit.EntryPointArguments = requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_EntryPointArgument;
                requestJobDriver_jobDriver_SparkSubmitIsNull = false;
            }
            System.String requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_SparkSubmitParameter = null;
            if (cmdletContext.SparkSubmit_SparkSubmitParameter != null)
            {
                requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_SparkSubmitParameter = cmdletContext.SparkSubmit_SparkSubmitParameter;
            }
            if (requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_SparkSubmitParameter != null)
            {
                requestJobDriver_jobDriver_SparkSubmit.SparkSubmitParameters = requestJobDriver_jobDriver_SparkSubmit_sparkSubmit_SparkSubmitParameter;
                requestJobDriver_jobDriver_SparkSubmitIsNull = false;
            }
             // determine if requestJobDriver_jobDriver_SparkSubmit should be set to null
            if (requestJobDriver_jobDriver_SparkSubmitIsNull)
            {
                requestJobDriver_jobDriver_SparkSubmit = null;
            }
            if (requestJobDriver_jobDriver_SparkSubmit != null)
            {
                request.JobDriver.SparkSubmit = requestJobDriver_jobDriver_SparkSubmit;
                requestJobDriverIsNull = false;
            }
             // determine if request.JobDriver should be set to null
            if (requestJobDriverIsNull)
            {
                request.JobDriver = null;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RetryPolicy
            var requestRetryPolicyIsNull = true;
            request.RetryPolicy = new Amazon.EMRServerless.Model.RetryPolicy();
            System.Int32? requestRetryPolicy_retryPolicy_MaxAttempt = null;
            if (cmdletContext.RetryPolicy_MaxAttempt != null)
            {
                requestRetryPolicy_retryPolicy_MaxAttempt = cmdletContext.RetryPolicy_MaxAttempt.Value;
            }
            if (requestRetryPolicy_retryPolicy_MaxAttempt != null)
            {
                request.RetryPolicy.MaxAttempts = requestRetryPolicy_retryPolicy_MaxAttempt.Value;
                requestRetryPolicyIsNull = false;
            }
            System.Int32? requestRetryPolicy_retryPolicy_MaxFailedAttemptsPerHour = null;
            if (cmdletContext.RetryPolicy_MaxFailedAttemptsPerHour != null)
            {
                requestRetryPolicy_retryPolicy_MaxFailedAttemptsPerHour = cmdletContext.RetryPolicy_MaxFailedAttemptsPerHour.Value;
            }
            if (requestRetryPolicy_retryPolicy_MaxFailedAttemptsPerHour != null)
            {
                request.RetryPolicy.MaxFailedAttemptsPerHour = requestRetryPolicy_retryPolicy_MaxFailedAttemptsPerHour.Value;
                requestRetryPolicyIsNull = false;
            }
             // determine if request.RetryPolicy should be set to null
            if (requestRetryPolicyIsNull)
            {
                request.RetryPolicy = null;
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
        
        private Amazon.EMRServerless.Model.StartJobRunResponse CallAWSServiceOperation(IAmazonEMRServerless client, Amazon.EMRServerless.Model.StartJobRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EMR Serverless", "StartJobRun");
            try
            {
                #if DESKTOP
                return client.StartJobRun(request);
                #elif CORECLR
                return client.StartJobRunAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.EMRServerless.Model.Configuration> ConfigurationOverrides_ApplicationConfiguration { get; set; }
            public System.Boolean? CloudWatchLoggingConfiguration_Enabled { get; set; }
            public System.String CloudWatchLoggingConfiguration_EncryptionKeyArn { get; set; }
            public System.String CloudWatchLoggingConfiguration_LogGroupName { get; set; }
            public System.String CloudWatchLoggingConfiguration_LogStreamNamePrefix { get; set; }
            public Dictionary<System.String, List<System.String>> CloudWatchLoggingConfiguration_LogType { get; set; }
            public System.Boolean? ManagedPersistenceMonitoringConfiguration_Enabled { get; set; }
            public System.String ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn { get; set; }
            public System.String PrometheusMonitoringConfiguration_RemoteWriteUrl { get; set; }
            public System.String S3MonitoringConfiguration_EncryptionKeyArn { get; set; }
            public System.String S3MonitoringConfiguration_LogUri { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Int64? ExecutionTimeoutMinute { get; set; }
            public System.String Hive_InitQueryFile { get; set; }
            public System.String Hive_Parameter { get; set; }
            public System.String Hive_Query { get; set; }
            public System.String SparkSubmit_EntryPoint { get; set; }
            public List<System.String> SparkSubmit_EntryPointArgument { get; set; }
            public System.String SparkSubmit_SparkSubmitParameter { get; set; }
            public Amazon.EMRServerless.JobRunMode Mode { get; set; }
            public System.String Name { get; set; }
            public System.Int32? RetryPolicy_MaxAttempt { get; set; }
            public System.Int32? RetryPolicy_MaxFailedAttemptsPerHour { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.EMRServerless.Model.StartJobRunResponse, StartEMRServerlessJobRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
