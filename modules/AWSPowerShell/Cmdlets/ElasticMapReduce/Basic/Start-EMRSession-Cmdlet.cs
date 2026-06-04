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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Creates and starts a new Spark Connect session on the specified cluster. The cluster
    /// must be in the <c>RUNNING</c> or <c>WAITING</c> state and have sessions enabled. This
    /// operation is supported in Amazon EMR Spark 8.0.0 and later.
    /// </summary>
    [Cmdlet("Start", "EMRSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticMapReduce.Model.StartSessionResponse")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce StartSession API operation.", Operation = new[] {"StartSession"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.StartSessionResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.StartSessionResponse",
        "This cmdlet returns an Amazon.ElasticMapReduce.Model.StartSessionResponse object containing multiple properties."
    )]
    public partial class StartEMRSessionCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// request token, the service returns the original response without performing the operation
        /// again.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The ID of the cluster on which to start the session.</para>
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether CloudWatch Logs is enabled for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_ManagedLoggingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether Amazon EMR-managed logging is enabled for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MonitoringConfiguration_ManagedLoggingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_S3LoggingConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether Amazon S3 logging is enabled for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MonitoringConfiguration_S3LoggingConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key used to encrypt the logs published to
        /// CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key used to encrypt the managed logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key used to encrypt logs published to Amazon
        /// S3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter EngineConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration overrides for the session. Only runtime configuration overrides
        /// are supported.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EngineConfigurations")]
        public Amazon.ElasticMapReduce.Model.Configuration[] EngineConfiguration { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role ARN for the session. Amazon EMR uses this role to access Amazon
        /// Web Services resources on your behalf during session execution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup
        /// <summary>
        /// <para>
        /// <para>The name of the log group where session logs are published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>The prefix applied to the log stream name where session logs are published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType
        /// <summary>
        /// <para>
        /// <para>A map of log component names (for example, <c>SPARK_DRIVER</c>, <c>SPARK_EXECUTOR</c>)
        /// to the list of log types to publish for that component (for example, <c>stdout</c>,
        /// <c>stderr</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_LogTypes")]
        public System.Collections.Hashtable MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_S3LoggingConfiguration_LogType
        /// <summary>
        /// <para>
        /// <para>A map of log component names (for example, <c>SPARK_DRIVER</c>, <c>SPARK_EXECUTOR</c>)
        /// to the list of log types to publish for that component (for example, <c>stdout</c>,
        /// <c>stderr</c>).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_S3LoggingConfiguration_LogTypes")]
        public System.Collections.Hashtable MonitoringConfiguration_S3LoggingConfiguration_LogType { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_S3LoggingConfiguration_LogUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 destination URI where session logs are published.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringConfiguration_S3LoggingConfiguration_LogUri { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An optional name for the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SessionIdleTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The idle timeout, in minutes. If the session is idle for this duration, Amazon EMR
        /// EC2 automatically terminates it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionIdleTimeoutInMinutes")]
        public System.Int64? SessionIdleTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the session.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticMapReduce.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.StartSessionResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.StartSessionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMRSession (StartSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.StartSessionResponse, StartEMRSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EngineConfiguration != null)
            {
                context.EngineConfiguration = new List<Amazon.ElasticMapReduce.Model.Configuration>(this.EngineConfiguration);
            }
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled = this.MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled;
            context.MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn = this.MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn;
            context.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup = this.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup;
            context.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix = this.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix;
            if (this.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType != null)
            {
                context.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType.Keys)
                {
                    object hashValue = this.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType[hashKey];
                    if (hashValue == null)
                    {
                        context.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType.Add((String)hashKey, valueSet);
                }
            }
            context.MonitoringConfiguration_ManagedLoggingConfiguration_Enabled = this.MonitoringConfiguration_ManagedLoggingConfiguration_Enabled;
            context.MonitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn = this.MonitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn;
            context.MonitoringConfiguration_S3LoggingConfiguration_Enabled = this.MonitoringConfiguration_S3LoggingConfiguration_Enabled;
            context.MonitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn = this.MonitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn;
            if (this.MonitoringConfiguration_S3LoggingConfiguration_LogType != null)
            {
                context.MonitoringConfiguration_S3LoggingConfiguration_LogType = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.MonitoringConfiguration_S3LoggingConfiguration_LogType.Keys)
                {
                    object hashValue = this.MonitoringConfiguration_S3LoggingConfiguration_LogType[hashKey];
                    if (hashValue == null)
                    {
                        context.MonitoringConfiguration_S3LoggingConfiguration_LogType.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.MonitoringConfiguration_S3LoggingConfiguration_LogType.Add((String)hashKey, valueSet);
                }
            }
            context.MonitoringConfiguration_S3LoggingConfiguration_LogUri = this.MonitoringConfiguration_S3LoggingConfiguration_LogUri;
            context.Name = this.Name;
            context.SessionIdleTimeoutInMinute = this.SessionIdleTimeoutInMinute;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticMapReduce.Model.Tag>(this.Tag);
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
            var request = new Amazon.ElasticMapReduce.Model.StartSessionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.EngineConfiguration != null)
            {
                request.EngineConfigurations = cmdletContext.EngineConfiguration;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate MonitoringConfiguration
            var requestMonitoringConfigurationIsNull = true;
            request.MonitoringConfiguration = new Amazon.ElasticMapReduce.Model.SessionMonitoringConfiguration();
            Amazon.ElasticMapReduce.Model.SessionManagedLoggingConfiguration requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration = null;
            
             // populate ManagedLoggingConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration = new Amazon.ElasticMapReduce.Model.SessionManagedLoggingConfiguration();
            System.Boolean? requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_Enabled = null;
            if (cmdletContext.MonitoringConfiguration_ManagedLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_Enabled = cmdletContext.MonitoringConfiguration_ManagedLoggingConfiguration_Enabled.Value;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration.Enabled = requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_Enabled.Value;
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.MonitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn = cmdletContext.MonitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration.EncryptionKeyArn = requestMonitoringConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_monitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn;
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
            Amazon.ElasticMapReduce.Model.SessionS3LoggingConfiguration requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration = null;
            
             // populate S3LoggingConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration = new Amazon.ElasticMapReduce.Model.SessionS3LoggingConfiguration();
            System.Boolean? requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_Enabled = null;
            if (cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_Enabled = cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_Enabled.Value;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration.Enabled = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_Enabled.Value;
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn = cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration.EncryptionKeyArn = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn;
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogType = null;
            if (cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_LogType != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogType = cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_LogType;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogType != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration.LogTypes = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogType;
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogUri = null;
            if (cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_LogUri != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogUri = cmdletContext.MonitoringConfiguration_S3LoggingConfiguration_LogUri;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogUri != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration.LogUri = requestMonitoringConfiguration_monitoringConfiguration_S3LoggingConfiguration_monitoringConfiguration_S3LoggingConfiguration_LogUri;
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
            Amazon.ElasticMapReduce.Model.SessionCloudWatchLoggingConfiguration requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration = null;
            
             // populate CloudWatchLoggingConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration = new Amazon.ElasticMapReduce.Model.SessionCloudWatchLoggingConfiguration();
            System.Boolean? requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_Enabled = null;
            if (cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_Enabled = cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled.Value;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.Enabled = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_Enabled.Value;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn = cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.EncryptionKeyArn = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup = null;
            if (cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup = cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.LogGroup = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix = null;
            if (cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix = cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.LogStreamNamePrefix = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            Dictionary<System.String, List<System.String>> requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogType = null;
            if (cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogType = cmdletContext.MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogType != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.LogTypes = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_LogType;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.SessionIdleTimeoutInMinute != null)
            {
                request.SessionIdleTimeoutInMinutes = cmdletContext.SessionIdleTimeoutInMinute.Value;
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
        
        private Amazon.ElasticMapReduce.Model.StartSessionResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.StartSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "StartSession");
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
            public System.String ClusterId { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Configuration> EngineConfiguration { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Boolean? MonitoringConfiguration_CloudWatchLoggingConfiguration_Enabled { get; set; }
            public System.String MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn { get; set; }
            public System.String MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroup { get; set; }
            public System.String MonitoringConfiguration_CloudWatchLoggingConfiguration_LogStreamNamePrefix { get; set; }
            public Dictionary<System.String, List<System.String>> MonitoringConfiguration_CloudWatchLoggingConfiguration_LogType { get; set; }
            public System.Boolean? MonitoringConfiguration_ManagedLoggingConfiguration_Enabled { get; set; }
            public System.String MonitoringConfiguration_ManagedLoggingConfiguration_EncryptionKeyArn { get; set; }
            public System.Boolean? MonitoringConfiguration_S3LoggingConfiguration_Enabled { get; set; }
            public System.String MonitoringConfiguration_S3LoggingConfiguration_EncryptionKeyArn { get; set; }
            public Dictionary<System.String, List<System.String>> MonitoringConfiguration_S3LoggingConfiguration_LogType { get; set; }
            public System.String MonitoringConfiguration_S3LoggingConfiguration_LogUri { get; set; }
            public System.String Name { get; set; }
            public System.Int64? SessionIdleTimeoutInMinute { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.StartSessionResponse, StartEMRSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
