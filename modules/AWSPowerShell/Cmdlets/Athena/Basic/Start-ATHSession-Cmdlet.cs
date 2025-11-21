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
using Amazon.Athena;
using Amazon.Athena.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ATH
{
    /// <summary>
    /// Creates a session for running calculations within a workgroup. The session is ready
    /// when it reaches an <c>IDLE</c> state.
    /// </summary>
    [Cmdlet("Start", "ATHSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Athena.Model.StartSessionResponse")]
    [AWSCmdlet("Calls the Amazon Athena StartSession API operation.", Operation = new[] {"StartSession"}, SelectReturnType = typeof(Amazon.Athena.Model.StartSessionResponse))]
    [AWSCmdletOutput("Amazon.Athena.Model.StartSessionResponse",
        "This cmdlet returns an Amazon.Athena.Model.StartSessionResponse object containing multiple properties."
    )]
    public partial class StartATHSessionCmdlet : AmazonAthenaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EngineConfiguration_AdditionalConfig
        /// <summary>
        /// <para>
        /// <para>Contains additional notebook engine <c>MAP&lt;string, string&gt;</c> parameter mappings
        /// in the form of key-value pairs. To specify an Athena notebook that the Jupyter server
        /// will download and serve, specify a value for the <a>StartSessionRequest$NotebookVersion</a>
        /// field, and then add a key named <c>NotebookId</c> to <c>AdditionalConfigs</c> that
        /// has the value of the Athena notebook ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EngineConfiguration_AdditionalConfigs")]
        public System.Collections.Hashtable EngineConfiguration_AdditionalConfig { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_Classification
        /// <summary>
        /// <para>
        /// <para>The configuration classifications that can be specified for the engine.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EngineConfiguration_Classifications")]
        public Amazon.Athena.Model.Classification[] EngineConfiguration_Classification { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive string used to ensure the request to create the session is
        /// idempotent (executes only once). If another <c>StartSessionRequest</c> is received,
        /// the same response is returned and another session is not created. If a parameter has
        /// changed, an error is returned.</para><important><para>This token is listed as not required because Amazon Web Services SDKs (for example
        /// the Amazon Web Services SDK for Java) auto-generate the token for users. If you are
        /// not using the Amazon Web Services SDK or the Amazon Web Services CLI, you must provide
        /// this token or the action will fail.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_CoordinatorDpuSize
        /// <summary>
        /// <para>
        /// <para>The number of DPUs to use for the coordinator. A coordinator is a special executor
        /// that orchestrates processing work and manages other executors in a notebook session.
        /// The default is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EngineConfiguration_CoordinatorDpuSize { get; set; }
        #endregion
        
        #region Parameter CopyWorkGroupTag
        /// <summary>
        /// <para>
        /// <para>Copies the tags from the Workgroup to the Session when.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CopyWorkGroupTags")]
        public System.Boolean? CopyWorkGroupTag { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_DefaultExecutorDpuSize
        /// <summary>
        /// <para>
        /// <para>The default number of DPUs to use for executors. An executor is the smallest unit
        /// of compute that a notebook session can request from Athena. The default is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EngineConfiguration_DefaultExecutorDpuSize { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The session description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables CloudWatch logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled")]
        public System.Boolean? CloudWatchLoggingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter ManagedLoggingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables mamanged log persistence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_ManagedLoggingConfiguration_Enabled")]
        public System.Boolean? ManagedLoggingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter S3LoggingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables S3 log delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_S3LoggingConfiguration_Enabled")]
        public System.Boolean? S3LoggingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the execution role used to access user resources for Spark sessions and
        /// Identity Center enabled workgroups. This property applies only to Spark enabled workgroups
        /// and Identity Center enabled workgroups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter ManagedLoggingConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN to encrypt the logs stored in managed log persistence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_ManagedLoggingConfiguration_KmsKey")]
        public System.String ManagedLoggingConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter S3LoggingConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN to encrypt the logs published to the given Amazon S3 destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_S3LoggingConfiguration_KmsKey")]
        public System.String S3LoggingConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the log group in Amazon CloudWatch Logs where you want to publish your
        /// logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup")]
        public System.String CloudWatchLoggingConfiguration_LogGroup { get; set; }
        #endregion
        
        #region Parameter S3LoggingConfiguration_LogLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 destination URI for log publishing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_S3LoggingConfiguration_LogLocation")]
        public System.String S3LoggingConfiguration_LogLocation { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>Prefix for the CloudWatch log stream name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix")]
        public System.String CloudWatchLoggingConfiguration_LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_LogType
        /// <summary>
        /// <para>
        /// <para>The types of logs that you want to publish to CloudWatch.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_LogTypes")]
        public System.Collections.Hashtable CloudWatchLoggingConfiguration_LogType { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_MaxConcurrentDpus
        /// <summary>
        /// <para>
        /// <para>The maximum number of DPUs that can run concurrently.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EngineConfiguration_MaxConcurrentDpus { get; set; }
        #endregion
        
        #region Parameter NotebookVersion
        /// <summary>
        /// <para>
        /// <para>The notebook version. This value is supplied automatically for notebook sessions in
        /// the Athena console and is not required for programmatic session access. The only valid
        /// notebook version is <c>Athena notebook version 1</c>. If you specify a value for <c>NotebookVersion</c>,
        /// you must also specify a value for <c>NotebookId</c>. See <a>EngineConfiguration$AdditionalConfigs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotebookVersion { get; set; }
        #endregion
        
        #region Parameter SessionIdleTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The idle timeout in minutes for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionIdleTimeoutInMinutes")]
        public System.Int32? SessionIdleTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration_SparkProperty
        /// <summary>
        /// <para>
        /// <para>Specifies custom jar files and Spark properties for use cases like cluster encryption,
        /// table formats, and general Spark tuning.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EngineConfiguration_SparkProperties")]
        public System.Collections.Hashtable EngineConfiguration_SparkProperty { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of comma separated tags to add to the session that is created.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Athena.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter WorkGroup
        /// <summary>
        /// <para>
        /// <para>The workgroup to which the session belongs.</para>
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
        public System.String WorkGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Athena.Model.StartSessionResponse).
        /// Specifying the name of a property of type Amazon.Athena.Model.StartSessionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkGroup), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ATHSession (StartSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Athena.Model.StartSessionResponse, StartATHSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.CopyWorkGroupTag = this.CopyWorkGroupTag;
            context.Description = this.Description;
            if (this.EngineConfiguration_AdditionalConfig != null)
            {
                context.EngineConfiguration_AdditionalConfig = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EngineConfiguration_AdditionalConfig.Keys)
                {
                    context.EngineConfiguration_AdditionalConfig.Add((String)hashKey, (System.String)(this.EngineConfiguration_AdditionalConfig[hashKey]));
                }
            }
            if (this.EngineConfiguration_Classification != null)
            {
                context.EngineConfiguration_Classification = new List<Amazon.Athena.Model.Classification>(this.EngineConfiguration_Classification);
            }
            context.EngineConfiguration_CoordinatorDpuSize = this.EngineConfiguration_CoordinatorDpuSize;
            context.EngineConfiguration_DefaultExecutorDpuSize = this.EngineConfiguration_DefaultExecutorDpuSize;
            context.EngineConfiguration_MaxConcurrentDpus = this.EngineConfiguration_MaxConcurrentDpus;
            if (this.EngineConfiguration_SparkProperty != null)
            {
                context.EngineConfiguration_SparkProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EngineConfiguration_SparkProperty.Keys)
                {
                    context.EngineConfiguration_SparkProperty.Add((String)hashKey, (System.String)(this.EngineConfiguration_SparkProperty[hashKey]));
                }
            }
            context.ExecutionRole = this.ExecutionRole;
            context.CloudWatchLoggingConfiguration_Enabled = this.CloudWatchLoggingConfiguration_Enabled;
            context.CloudWatchLoggingConfiguration_LogGroup = this.CloudWatchLoggingConfiguration_LogGroup;
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
            context.ManagedLoggingConfiguration_Enabled = this.ManagedLoggingConfiguration_Enabled;
            context.ManagedLoggingConfiguration_KmsKey = this.ManagedLoggingConfiguration_KmsKey;
            context.S3LoggingConfiguration_Enabled = this.S3LoggingConfiguration_Enabled;
            context.S3LoggingConfiguration_KmsKey = this.S3LoggingConfiguration_KmsKey;
            context.S3LoggingConfiguration_LogLocation = this.S3LoggingConfiguration_LogLocation;
            context.NotebookVersion = this.NotebookVersion;
            context.SessionIdleTimeoutInMinute = this.SessionIdleTimeoutInMinute;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Athena.Model.Tag>(this.Tag);
            }
            context.WorkGroup = this.WorkGroup;
            #if MODULAR
            if (this.WorkGroup == null && ParameterWasBound(nameof(this.WorkGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Athena.Model.StartSessionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CopyWorkGroupTag != null)
            {
                request.CopyWorkGroupTags = cmdletContext.CopyWorkGroupTag.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EngineConfiguration
            var requestEngineConfigurationIsNull = true;
            request.EngineConfiguration = new Amazon.Athena.Model.EngineConfiguration();
            Dictionary<System.String, System.String> requestEngineConfiguration_engineConfiguration_AdditionalConfig = null;
            if (cmdletContext.EngineConfiguration_AdditionalConfig != null)
            {
                requestEngineConfiguration_engineConfiguration_AdditionalConfig = cmdletContext.EngineConfiguration_AdditionalConfig;
            }
            if (requestEngineConfiguration_engineConfiguration_AdditionalConfig != null)
            {
                request.EngineConfiguration.AdditionalConfigs = requestEngineConfiguration_engineConfiguration_AdditionalConfig;
                requestEngineConfigurationIsNull = false;
            }
            List<Amazon.Athena.Model.Classification> requestEngineConfiguration_engineConfiguration_Classification = null;
            if (cmdletContext.EngineConfiguration_Classification != null)
            {
                requestEngineConfiguration_engineConfiguration_Classification = cmdletContext.EngineConfiguration_Classification;
            }
            if (requestEngineConfiguration_engineConfiguration_Classification != null)
            {
                request.EngineConfiguration.Classifications = requestEngineConfiguration_engineConfiguration_Classification;
                requestEngineConfigurationIsNull = false;
            }
            System.Int32? requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize = null;
            if (cmdletContext.EngineConfiguration_CoordinatorDpuSize != null)
            {
                requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize = cmdletContext.EngineConfiguration_CoordinatorDpuSize.Value;
            }
            if (requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize != null)
            {
                request.EngineConfiguration.CoordinatorDpuSize = requestEngineConfiguration_engineConfiguration_CoordinatorDpuSize.Value;
                requestEngineConfigurationIsNull = false;
            }
            System.Int32? requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize = null;
            if (cmdletContext.EngineConfiguration_DefaultExecutorDpuSize != null)
            {
                requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize = cmdletContext.EngineConfiguration_DefaultExecutorDpuSize.Value;
            }
            if (requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize != null)
            {
                request.EngineConfiguration.DefaultExecutorDpuSize = requestEngineConfiguration_engineConfiguration_DefaultExecutorDpuSize.Value;
                requestEngineConfigurationIsNull = false;
            }
            System.Int32? requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus = null;
            if (cmdletContext.EngineConfiguration_MaxConcurrentDpus != null)
            {
                requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus = cmdletContext.EngineConfiguration_MaxConcurrentDpus.Value;
            }
            if (requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus != null)
            {
                request.EngineConfiguration.MaxConcurrentDpus = requestEngineConfiguration_engineConfiguration_MaxConcurrentDpus.Value;
                requestEngineConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestEngineConfiguration_engineConfiguration_SparkProperty = null;
            if (cmdletContext.EngineConfiguration_SparkProperty != null)
            {
                requestEngineConfiguration_engineConfiguration_SparkProperty = cmdletContext.EngineConfiguration_SparkProperty;
            }
            if (requestEngineConfiguration_engineConfiguration_SparkProperty != null)
            {
                request.EngineConfiguration.SparkProperties = requestEngineConfiguration_engineConfiguration_SparkProperty;
                requestEngineConfigurationIsNull = false;
            }
             // determine if request.EngineConfiguration should be set to null
            if (requestEngineConfigurationIsNull)
            {
                request.EngineConfiguration = null;
            }
            if (cmdletContext.ExecutionRole != null)
            {
                request.ExecutionRole = cmdletContext.ExecutionRole;
            }
            
             // populate MonitoringConfiguration
            var requestMonitoringConfigurationIsNull = true;
            request.MonitoringConfiguration = new Amazon.Athena.Model.MonitoringConfiguration();
            Amazon.Athena.Model.ManagedLoggingConfiguration requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration = null;
            
             // populate ManagedLoggingConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration = new Amazon.Athena.Model.ManagedLoggingConfiguration();
            System.Boolean? requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_Enabled = null;
            if (cmdletContext.ManagedLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_Enabled = cmdletContext.ManagedLoggingConfiguration_Enabled.Value;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration.Enabled = requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_Enabled.Value;
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_KmsKey = null;
            if (cmdletContext.ManagedLoggingConfiguration_KmsKey != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_KmsKey = cmdletContext.ManagedLoggingConfiguration_KmsKey;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_KmsKey != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration.KmsKey = requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_managedLoggingConfiguration_KmsKey;
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfigurationIsNull = false;
            }
             // determine if requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration should be set to null
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfigurationIsNull)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration = null;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration != null)
            {
                request.MonitoringConfiguration.ManagedLoggingConfiguration = requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration;
                requestMonitoringConfigurationIsNull = false;
            }
            Amazon.Athena.Model.S3LoggingConfiguration requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration = null;
            
             // populate S3LoggingConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration = new Amazon.Athena.Model.S3LoggingConfiguration();
            System.Boolean? requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_Enabled = null;
            if (cmdletContext.S3LoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_Enabled = cmdletContext.S3LoggingConfiguration_Enabled.Value;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration.Enabled = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_Enabled.Value;
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_KmsKey = null;
            if (cmdletContext.S3LoggingConfiguration_KmsKey != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_KmsKey = cmdletContext.S3LoggingConfiguration_KmsKey;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_KmsKey != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration.KmsKey = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_KmsKey;
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_LogLocation = null;
            if (cmdletContext.S3LoggingConfiguration_LogLocation != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_LogLocation = cmdletContext.S3LoggingConfiguration_LogLocation;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_LogLocation != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration.LogLocation = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_s3LoggingConfiguration_LogLocation;
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = false;
            }
             // determine if requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration should be set to null
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration = null;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration != null)
            {
                request.MonitoringConfiguration.S3LoggingConfiguration = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration;
                requestMonitoringConfigurationIsNull = false;
            }
            Amazon.Athena.Model.CloudWatchLoggingConfiguration requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration = null;
            
             // populate CloudWatchLoggingConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration = new Amazon.Athena.Model.CloudWatchLoggingConfiguration();
            System.Boolean? requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled = cmdletContext.CloudWatchLoggingConfiguration_Enabled.Value;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.Enabled = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_Enabled.Value;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroup = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_LogGroup != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroup = cmdletContext.CloudWatchLoggingConfiguration_LogGroup;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroup != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.LogGroup = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroup;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_LogStreamNamePrefix != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix = cmdletContext.CloudWatchLoggingConfiguration_LogStreamNamePrefix;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.LogStreamNamePrefix = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogStreamNamePrefix;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_LogType != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType = cmdletContext.CloudWatchLoggingConfiguration_LogType;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.LogTypes = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogType;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
             // determine if requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration should be set to null
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration = null;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration != null)
            {
                request.MonitoringConfiguration.CloudWatchLoggingConfiguration = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration;
                requestMonitoringConfigurationIsNull = false;
            }
             // determine if request.MonitoringConfiguration should be set to null
            if (requestMonitoringConfigurationIsNull)
            {
                request.MonitoringConfiguration = null;
            }
            if (cmdletContext.NotebookVersion != null)
            {
                request.NotebookVersion = cmdletContext.NotebookVersion;
            }
            if (cmdletContext.SessionIdleTimeoutInMinute != null)
            {
                request.SessionIdleTimeoutInMinutes = cmdletContext.SessionIdleTimeoutInMinute.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkGroup != null)
            {
                request.WorkGroup = cmdletContext.WorkGroup;
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
        
        private Amazon.Athena.Model.StartSessionResponse CallAWSServiceOperation(IAmazonAthena client, Amazon.Athena.Model.StartSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Athena", "StartSession");
            try
            {
                return client.StartSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? CopyWorkGroupTag { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, System.String> EngineConfiguration_AdditionalConfig { get; set; }
            public List<Amazon.Athena.Model.Classification> EngineConfiguration_Classification { get; set; }
            public System.Int32? EngineConfiguration_CoordinatorDpuSize { get; set; }
            public System.Int32? EngineConfiguration_DefaultExecutorDpuSize { get; set; }
            public System.Int32? EngineConfiguration_MaxConcurrentDpus { get; set; }
            public Dictionary<System.String, System.String> EngineConfiguration_SparkProperty { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.Boolean? CloudWatchLoggingConfiguration_Enabled { get; set; }
            public System.String CloudWatchLoggingConfiguration_LogGroup { get; set; }
            public System.String CloudWatchLoggingConfiguration_LogStreamNamePrefix { get; set; }
            public Dictionary<System.String, List<System.String>> CloudWatchLoggingConfiguration_LogType { get; set; }
            public System.Boolean? ManagedLoggingConfiguration_Enabled { get; set; }
            public System.String ManagedLoggingConfiguration_KmsKey { get; set; }
            public System.Boolean? S3LoggingConfiguration_Enabled { get; set; }
            public System.String S3LoggingConfiguration_KmsKey { get; set; }
            public System.String S3LoggingConfiguration_LogLocation { get; set; }
            public System.String NotebookVersion { get; set; }
            public System.Int32? SessionIdleTimeoutInMinute { get; set; }
            public List<Amazon.Athena.Model.Tag> Tag { get; set; }
            public System.String WorkGroup { get; set; }
            public System.Func<Amazon.Athena.Model.StartSessionResponse, StartATHSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
