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
    /// Creates an application.
    /// </summary>
    [Cmdlet("New", "EMRServerlessApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRServerless.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the EMR Serverless CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.EMRServerless.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.EMRServerless.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.EMRServerless.Model.CreateApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEMRServerlessApplicationCmdlet : AmazonEMRServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The CPU architecture of an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EMRServerless.Architecture")]
        public Amazon.EMRServerless.Architecture Architecture { get; set; }
        #endregion
        
        #region Parameter MaximumCapacity_Cpu
        /// <summary>
        /// <para>
        /// <para>The maximum allowed CPU for an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumCapacity_Cpu { get; set; }
        #endregion
        
        #region Parameter MaximumCapacity_Disk
        /// <summary>
        /// <para>
        /// <para>The maximum allowed disk for an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumCapacity_Disk { get; set; }
        #endregion
        
        #region Parameter AutoStartConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables the application to automatically start on job submission. Defaults to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoStartConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter AutoStopConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables the application to automatically stop after a certain amount of time being
        /// idle. Defaults to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoStopConfiguration_Enabled { get; set; }
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
        
        #region Parameter ManagedPersistenceMonitoringConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Enables managed logging and defaults to true. If set to false, managed logging will
        /// be turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_Enabled")]
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
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_EncryptionKeyArn")]
        public System.String CloudWatchLoggingConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN to encrypt the logs stored in managed log persistence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn")]
        public System.String ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter S3MonitoringConfiguration_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN to encrypt the logs published to the given Amazon S3 destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_S3MonitoringConfiguration_EncryptionKeyArn")]
        public System.String S3MonitoringConfiguration_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter AutoStopConfiguration_IdleTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The amount of idle time in minutes after which your application will automatically
        /// stop. Defaults to 15 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoStopConfiguration_IdleTimeoutMinutes")]
        public System.Int32? AutoStopConfiguration_IdleTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter ImageConfiguration_ImageUri
        /// <summary>
        /// <para>
        /// <para>The URI of an image in the Amazon ECR registry. This field is required when you create
        /// a new application. If you leave this field blank in an update, Amazon EMR will remove
        /// the image configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageConfiguration_ImageUri { get; set; }
        #endregion
        
        #region Parameter InitialCapacity
        /// <summary>
        /// <para>
        /// <para>The capacity to initialize when the application is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable InitialCapacity { get; set; }
        #endregion
        
        #region Parameter InteractiveConfiguration_LivyEndpointEnabled
        /// <summary>
        /// <para>
        /// <para>Enables an Apache Livy endpoint that you can connect to and run interactive jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InteractiveConfiguration_LivyEndpointEnabled { get; set; }
        #endregion
        
        #region Parameter CloudWatchLoggingConfiguration_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group in Amazon CloudWatch Logs where you want to publish your
        /// logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_LogGroupName")]
        public System.String CloudWatchLoggingConfiguration_LogGroupName { get; set; }
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
        [Alias("MonitoringConfiguration_CloudWatchLoggingConfiguration_LogTypes")]
        public System.Collections.Hashtable CloudWatchLoggingConfiguration_LogType { get; set; }
        #endregion
        
        #region Parameter S3MonitoringConfiguration_LogUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 destination URI for log publishing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_S3MonitoringConfiguration_LogUri")]
        public System.String S3MonitoringConfiguration_LogUri { get; set; }
        #endregion
        
        #region Parameter SchedulerConfiguration_MaxConcurrentRun
        /// <summary>
        /// <para>
        /// <para>The maximum concurrent job runs on this application. If scheduler configuration is
        /// enabled on your application, the default value is 15. The valid range is 1 to 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchedulerConfiguration_MaxConcurrentRuns")]
        public System.Int32? SchedulerConfiguration_MaxConcurrentRun { get; set; }
        #endregion
        
        #region Parameter MaximumCapacity_Memory
        /// <summary>
        /// <para>
        /// <para>The maximum allowed resources for an application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaximumCapacity_Memory { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SchedulerConfiguration_QueueTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The maximum duration in minutes for the job in QUEUED state. If scheduler configuration
        /// is enabled on your application, the default value is 360 minutes (6 hours). The valid
        /// range is from 15 to 720.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SchedulerConfiguration_QueueTimeoutMinutes")]
        public System.Int32? SchedulerConfiguration_QueueTimeoutMinute { get; set; }
        #endregion
        
        #region Parameter ReleaseLabel
        /// <summary>
        /// <para>
        /// <para>The Amazon EMR release associated with the application.</para>
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
        public System.String ReleaseLabel { get; set; }
        #endregion
        
        #region Parameter PrometheusMonitoringConfiguration_RemoteWriteUrl
        /// <summary>
        /// <para>
        /// <para>The remote write URL in the Amazon Managed Service for Prometheus workspace to send
        /// metrics to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MonitoringConfiguration_PrometheusMonitoringConfiguration_RemoteWriteUrl")]
        public System.String PrometheusMonitoringConfiguration_RemoteWriteUrl { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/emr-serverless/latest/APIReference/API_Configuration.html">Configuration</a>
        /// specifications to use when creating an application. Each configuration consists of
        /// a classification and properties. This configuration is applied to all the job runs
        /// submitted under the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EMRServerless.Model.Configuration[] RuntimeConfiguration { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The array of security group Ids for customer VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SecurityGroupIds")]
        public System.String[] NetworkConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter InteractiveConfiguration_StudioEnabled
        /// <summary>
        /// <para>
        /// <para>Enables you to connect an application to Amazon EMR Studio to run interactive workloads
        /// in a notebook.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InteractiveConfiguration_StudioEnabled { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The array of subnet Ids for customer VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SubnetIds")]
        public System.String[] NetworkConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of application you want to start, such as Spark or Hive.</para>
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
        public System.String Type { get; set; }
        #endregion
        
        #region Parameter WorkerTypeSpecification
        /// <summary>
        /// <para>
        /// <para>The key-value pairs that specify worker type to <c>WorkerTypeSpecificationInput</c>.
        /// This parameter must contain all valid worker types for a Spark or Hive application.
        /// Valid worker types include <c>Driver</c> and <c>Executor</c> for Spark applications
        /// and <c>HiveDriver</c> and <c>TezTask</c> for Hive applications. You can either set
        /// image details in this parameter for each worker type, or in <c>imageConfiguration</c>
        /// for all worker types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WorkerTypeSpecifications")]
        public System.Collections.Hashtable WorkerTypeSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client idempotency token of the application to create. Its value must be unique
        /// for each request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRServerless.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.EMRServerless.Model.CreateApplicationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRServerlessApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRServerless.Model.CreateApplicationResponse, NewEMRServerlessApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Architecture = this.Architecture;
            context.AutoStartConfiguration_Enabled = this.AutoStartConfiguration_Enabled;
            context.AutoStopConfiguration_Enabled = this.AutoStopConfiguration_Enabled;
            context.AutoStopConfiguration_IdleTimeoutMinute = this.AutoStopConfiguration_IdleTimeoutMinute;
            context.ClientToken = this.ClientToken;
            context.ImageConfiguration_ImageUri = this.ImageConfiguration_ImageUri;
            if (this.InitialCapacity != null)
            {
                context.InitialCapacity = new Dictionary<System.String, Amazon.EMRServerless.Model.InitialCapacityConfig>(StringComparer.Ordinal);
                foreach (var hashKey in this.InitialCapacity.Keys)
                {
                    context.InitialCapacity.Add((String)hashKey, (Amazon.EMRServerless.Model.InitialCapacityConfig)(this.InitialCapacity[hashKey]));
                }
            }
            context.InteractiveConfiguration_LivyEndpointEnabled = this.InteractiveConfiguration_LivyEndpointEnabled;
            context.InteractiveConfiguration_StudioEnabled = this.InteractiveConfiguration_StudioEnabled;
            context.MaximumCapacity_Cpu = this.MaximumCapacity_Cpu;
            context.MaximumCapacity_Disk = this.MaximumCapacity_Disk;
            context.MaximumCapacity_Memory = this.MaximumCapacity_Memory;
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
            context.Name = this.Name;
            if (this.NetworkConfiguration_SecurityGroupId != null)
            {
                context.NetworkConfiguration_SecurityGroupId = new List<System.String>(this.NetworkConfiguration_SecurityGroupId);
            }
            if (this.NetworkConfiguration_SubnetId != null)
            {
                context.NetworkConfiguration_SubnetId = new List<System.String>(this.NetworkConfiguration_SubnetId);
            }
            context.ReleaseLabel = this.ReleaseLabel;
            #if MODULAR
            if (this.ReleaseLabel == null && ParameterWasBound(nameof(this.ReleaseLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter ReleaseLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RuntimeConfiguration != null)
            {
                context.RuntimeConfiguration = new List<Amazon.EMRServerless.Model.Configuration>(this.RuntimeConfiguration);
            }
            context.SchedulerConfiguration_MaxConcurrentRun = this.SchedulerConfiguration_MaxConcurrentRun;
            context.SchedulerConfiguration_QueueTimeoutMinute = this.SchedulerConfiguration_QueueTimeoutMinute;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.WorkerTypeSpecification != null)
            {
                context.WorkerTypeSpecification = new Dictionary<System.String, Amazon.EMRServerless.Model.WorkerTypeSpecificationInput>(StringComparer.Ordinal);
                foreach (var hashKey in this.WorkerTypeSpecification.Keys)
                {
                    context.WorkerTypeSpecification.Add((String)hashKey, (Amazon.EMRServerless.Model.WorkerTypeSpecificationInput)(this.WorkerTypeSpecification[hashKey]));
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
            var request = new Amazon.EMRServerless.Model.CreateApplicationRequest();
            
            if (cmdletContext.Architecture != null)
            {
                request.Architecture = cmdletContext.Architecture;
            }
            
             // populate AutoStartConfiguration
            var requestAutoStartConfigurationIsNull = true;
            request.AutoStartConfiguration = new Amazon.EMRServerless.Model.AutoStartConfig();
            System.Boolean? requestAutoStartConfiguration_autoStartConfiguration_Enabled = null;
            if (cmdletContext.AutoStartConfiguration_Enabled != null)
            {
                requestAutoStartConfiguration_autoStartConfiguration_Enabled = cmdletContext.AutoStartConfiguration_Enabled.Value;
            }
            if (requestAutoStartConfiguration_autoStartConfiguration_Enabled != null)
            {
                request.AutoStartConfiguration.Enabled = requestAutoStartConfiguration_autoStartConfiguration_Enabled.Value;
                requestAutoStartConfigurationIsNull = false;
            }
             // determine if request.AutoStartConfiguration should be set to null
            if (requestAutoStartConfigurationIsNull)
            {
                request.AutoStartConfiguration = null;
            }
            
             // populate AutoStopConfiguration
            var requestAutoStopConfigurationIsNull = true;
            request.AutoStopConfiguration = new Amazon.EMRServerless.Model.AutoStopConfig();
            System.Boolean? requestAutoStopConfiguration_autoStopConfiguration_Enabled = null;
            if (cmdletContext.AutoStopConfiguration_Enabled != null)
            {
                requestAutoStopConfiguration_autoStopConfiguration_Enabled = cmdletContext.AutoStopConfiguration_Enabled.Value;
            }
            if (requestAutoStopConfiguration_autoStopConfiguration_Enabled != null)
            {
                request.AutoStopConfiguration.Enabled = requestAutoStopConfiguration_autoStopConfiguration_Enabled.Value;
                requestAutoStopConfigurationIsNull = false;
            }
            System.Int32? requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute = null;
            if (cmdletContext.AutoStopConfiguration_IdleTimeoutMinute != null)
            {
                requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute = cmdletContext.AutoStopConfiguration_IdleTimeoutMinute.Value;
            }
            if (requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute != null)
            {
                request.AutoStopConfiguration.IdleTimeoutMinutes = requestAutoStopConfiguration_autoStopConfiguration_IdleTimeoutMinute.Value;
                requestAutoStopConfigurationIsNull = false;
            }
             // determine if request.AutoStopConfiguration should be set to null
            if (requestAutoStopConfigurationIsNull)
            {
                request.AutoStopConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ImageConfiguration
            var requestImageConfigurationIsNull = true;
            request.ImageConfiguration = new Amazon.EMRServerless.Model.ImageConfigurationInput();
            System.String requestImageConfiguration_imageConfiguration_ImageUri = null;
            if (cmdletContext.ImageConfiguration_ImageUri != null)
            {
                requestImageConfiguration_imageConfiguration_ImageUri = cmdletContext.ImageConfiguration_ImageUri;
            }
            if (requestImageConfiguration_imageConfiguration_ImageUri != null)
            {
                request.ImageConfiguration.ImageUri = requestImageConfiguration_imageConfiguration_ImageUri;
                requestImageConfigurationIsNull = false;
            }
             // determine if request.ImageConfiguration should be set to null
            if (requestImageConfigurationIsNull)
            {
                request.ImageConfiguration = null;
            }
            if (cmdletContext.InitialCapacity != null)
            {
                request.InitialCapacity = cmdletContext.InitialCapacity;
            }
            
             // populate InteractiveConfiguration
            var requestInteractiveConfigurationIsNull = true;
            request.InteractiveConfiguration = new Amazon.EMRServerless.Model.InteractiveConfiguration();
            System.Boolean? requestInteractiveConfiguration_interactiveConfiguration_LivyEndpointEnabled = null;
            if (cmdletContext.InteractiveConfiguration_LivyEndpointEnabled != null)
            {
                requestInteractiveConfiguration_interactiveConfiguration_LivyEndpointEnabled = cmdletContext.InteractiveConfiguration_LivyEndpointEnabled.Value;
            }
            if (requestInteractiveConfiguration_interactiveConfiguration_LivyEndpointEnabled != null)
            {
                request.InteractiveConfiguration.LivyEndpointEnabled = requestInteractiveConfiguration_interactiveConfiguration_LivyEndpointEnabled.Value;
                requestInteractiveConfigurationIsNull = false;
            }
            System.Boolean? requestInteractiveConfiguration_interactiveConfiguration_StudioEnabled = null;
            if (cmdletContext.InteractiveConfiguration_StudioEnabled != null)
            {
                requestInteractiveConfiguration_interactiveConfiguration_StudioEnabled = cmdletContext.InteractiveConfiguration_StudioEnabled.Value;
            }
            if (requestInteractiveConfiguration_interactiveConfiguration_StudioEnabled != null)
            {
                request.InteractiveConfiguration.StudioEnabled = requestInteractiveConfiguration_interactiveConfiguration_StudioEnabled.Value;
                requestInteractiveConfigurationIsNull = false;
            }
             // determine if request.InteractiveConfiguration should be set to null
            if (requestInteractiveConfigurationIsNull)
            {
                request.InteractiveConfiguration = null;
            }
            
             // populate MaximumCapacity
            var requestMaximumCapacityIsNull = true;
            request.MaximumCapacity = new Amazon.EMRServerless.Model.MaximumAllowedResources();
            System.String requestMaximumCapacity_maximumCapacity_Cpu = null;
            if (cmdletContext.MaximumCapacity_Cpu != null)
            {
                requestMaximumCapacity_maximumCapacity_Cpu = cmdletContext.MaximumCapacity_Cpu;
            }
            if (requestMaximumCapacity_maximumCapacity_Cpu != null)
            {
                request.MaximumCapacity.Cpu = requestMaximumCapacity_maximumCapacity_Cpu;
                requestMaximumCapacityIsNull = false;
            }
            System.String requestMaximumCapacity_maximumCapacity_Disk = null;
            if (cmdletContext.MaximumCapacity_Disk != null)
            {
                requestMaximumCapacity_maximumCapacity_Disk = cmdletContext.MaximumCapacity_Disk;
            }
            if (requestMaximumCapacity_maximumCapacity_Disk != null)
            {
                request.MaximumCapacity.Disk = requestMaximumCapacity_maximumCapacity_Disk;
                requestMaximumCapacityIsNull = false;
            }
            System.String requestMaximumCapacity_maximumCapacity_Memory = null;
            if (cmdletContext.MaximumCapacity_Memory != null)
            {
                requestMaximumCapacity_maximumCapacity_Memory = cmdletContext.MaximumCapacity_Memory;
            }
            if (requestMaximumCapacity_maximumCapacity_Memory != null)
            {
                request.MaximumCapacity.Memory = requestMaximumCapacity_maximumCapacity_Memory;
                requestMaximumCapacityIsNull = false;
            }
             // determine if request.MaximumCapacity should be set to null
            if (requestMaximumCapacityIsNull)
            {
                request.MaximumCapacity = null;
            }
            
             // populate MonitoringConfiguration
            var requestMonitoringConfigurationIsNull = true;
            request.MonitoringConfiguration = new Amazon.EMRServerless.Model.MonitoringConfiguration();
            Amazon.EMRServerless.Model.PrometheusMonitoringConfiguration requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration = null;
            
             // populate PrometheusMonitoringConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration = new Amazon.EMRServerless.Model.PrometheusMonitoringConfiguration();
            System.String requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl = null;
            if (cmdletContext.PrometheusMonitoringConfiguration_RemoteWriteUrl != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl = cmdletContext.PrometheusMonitoringConfiguration_RemoteWriteUrl;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration.RemoteWriteUrl = requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration_prometheusMonitoringConfiguration_RemoteWriteUrl;
                requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfigurationIsNull = false;
            }
             // determine if requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration should be set to null
            if (requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfigurationIsNull)
            {
                requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration = null;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration != null)
            {
                request.MonitoringConfiguration.PrometheusMonitoringConfiguration = requestMonitoringConfiguration_monitoringConfiguration_PrometheusMonitoringConfiguration;
                requestMonitoringConfigurationIsNull = false;
            }
            Amazon.EMRServerless.Model.ManagedPersistenceMonitoringConfiguration requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration = null;
            
             // populate ManagedPersistenceMonitoringConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration = new Amazon.EMRServerless.Model.ManagedPersistenceMonitoringConfiguration();
            System.Boolean? requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled = null;
            if (cmdletContext.ManagedPersistenceMonitoringConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled = cmdletContext.ManagedPersistenceMonitoringConfiguration_Enabled.Value;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration.Enabled = requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_Enabled.Value;
                requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn = cmdletContext.ManagedPersistenceMonitoringConfiguration_EncryptionKeyArn;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration.EncryptionKeyArn = requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration_managedPersistenceMonitoringConfiguration_EncryptionKeyArn;
                requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull = false;
            }
             // determine if requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration should be set to null
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfigurationIsNull)
            {
                requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration = null;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration != null)
            {
                request.MonitoringConfiguration.ManagedPersistenceMonitoringConfiguration = requestMonitoringConfiguration_monitoringConfiguration_ManagedPersistenceMonitoringConfiguration;
                requestMonitoringConfigurationIsNull = false;
            }
            Amazon.EMRServerless.Model.S3MonitoringConfiguration requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration = null;
            
             // populate S3MonitoringConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration = new Amazon.EMRServerless.Model.S3MonitoringConfiguration();
            System.String requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.S3MonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn = cmdletContext.S3MonitoringConfiguration_EncryptionKeyArn;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration.EncryptionKeyArn = requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_EncryptionKeyArn;
                requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri = null;
            if (cmdletContext.S3MonitoringConfiguration_LogUri != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri = cmdletContext.S3MonitoringConfiguration_LogUri;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration.LogUri = requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri;
                requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfigurationIsNull = false;
            }
             // determine if requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration should be set to null
            if (requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfigurationIsNull)
            {
                requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration = null;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration != null)
            {
                request.MonitoringConfiguration.S3MonitoringConfiguration = requestMonitoringConfiguration_monitoringConfiguration_S3MonitoringConfiguration;
                requestMonitoringConfigurationIsNull = false;
            }
            Amazon.EMRServerless.Model.CloudWatchLoggingConfiguration requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration = null;
            
             // populate CloudWatchLoggingConfiguration
            var requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = true;
            requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration = new Amazon.EMRServerless.Model.CloudWatchLoggingConfiguration();
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
            System.String requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn = cmdletContext.CloudWatchLoggingConfiguration_EncryptionKeyArn;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.EncryptionKeyArn = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_EncryptionKeyArn;
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfigurationIsNull = false;
            }
            System.String requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName = null;
            if (cmdletContext.CloudWatchLoggingConfiguration_LogGroupName != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName = cmdletContext.CloudWatchLoggingConfiguration_LogGroupName;
            }
            if (requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName != null)
            {
                requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration.LogGroupName = requestMonitoringConfiguration_monitoringConfiguration_CloudWatchLoggingConfiguration_cloudWatchLoggingConfiguration_LogGroupName;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.EMRServerless.Model.NetworkConfiguration();
            List<System.String> requestNetworkConfiguration_networkConfiguration_SecurityGroupId = null;
            if (cmdletContext.NetworkConfiguration_SecurityGroupId != null)
            {
                requestNetworkConfiguration_networkConfiguration_SecurityGroupId = cmdletContext.NetworkConfiguration_SecurityGroupId;
            }
            if (requestNetworkConfiguration_networkConfiguration_SecurityGroupId != null)
            {
                request.NetworkConfiguration.SecurityGroupIds = requestNetworkConfiguration_networkConfiguration_SecurityGroupId;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_SubnetId = null;
            if (cmdletContext.NetworkConfiguration_SubnetId != null)
            {
                requestNetworkConfiguration_networkConfiguration_SubnetId = cmdletContext.NetworkConfiguration_SubnetId;
            }
            if (requestNetworkConfiguration_networkConfiguration_SubnetId != null)
            {
                request.NetworkConfiguration.SubnetIds = requestNetworkConfiguration_networkConfiguration_SubnetId;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.ReleaseLabel != null)
            {
                request.ReleaseLabel = cmdletContext.ReleaseLabel;
            }
            if (cmdletContext.RuntimeConfiguration != null)
            {
                request.RuntimeConfiguration = cmdletContext.RuntimeConfiguration;
            }
            
             // populate SchedulerConfiguration
            var requestSchedulerConfigurationIsNull = true;
            request.SchedulerConfiguration = new Amazon.EMRServerless.Model.SchedulerConfiguration();
            System.Int32? requestSchedulerConfiguration_schedulerConfiguration_MaxConcurrentRun = null;
            if (cmdletContext.SchedulerConfiguration_MaxConcurrentRun != null)
            {
                requestSchedulerConfiguration_schedulerConfiguration_MaxConcurrentRun = cmdletContext.SchedulerConfiguration_MaxConcurrentRun.Value;
            }
            if (requestSchedulerConfiguration_schedulerConfiguration_MaxConcurrentRun != null)
            {
                request.SchedulerConfiguration.MaxConcurrentRuns = requestSchedulerConfiguration_schedulerConfiguration_MaxConcurrentRun.Value;
                requestSchedulerConfigurationIsNull = false;
            }
            System.Int32? requestSchedulerConfiguration_schedulerConfiguration_QueueTimeoutMinute = null;
            if (cmdletContext.SchedulerConfiguration_QueueTimeoutMinute != null)
            {
                requestSchedulerConfiguration_schedulerConfiguration_QueueTimeoutMinute = cmdletContext.SchedulerConfiguration_QueueTimeoutMinute.Value;
            }
            if (requestSchedulerConfiguration_schedulerConfiguration_QueueTimeoutMinute != null)
            {
                request.SchedulerConfiguration.QueueTimeoutMinutes = requestSchedulerConfiguration_schedulerConfiguration_QueueTimeoutMinute.Value;
                requestSchedulerConfigurationIsNull = false;
            }
             // determine if request.SchedulerConfiguration should be set to null
            if (requestSchedulerConfigurationIsNull)
            {
                request.SchedulerConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.WorkerTypeSpecification != null)
            {
                request.WorkerTypeSpecifications = cmdletContext.WorkerTypeSpecification;
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
        
        private Amazon.EMRServerless.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonEMRServerless client, Amazon.EMRServerless.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EMR Serverless", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EMRServerless.Architecture Architecture { get; set; }
            public System.Boolean? AutoStartConfiguration_Enabled { get; set; }
            public System.Boolean? AutoStopConfiguration_Enabled { get; set; }
            public System.Int32? AutoStopConfiguration_IdleTimeoutMinute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ImageConfiguration_ImageUri { get; set; }
            public Dictionary<System.String, Amazon.EMRServerless.Model.InitialCapacityConfig> InitialCapacity { get; set; }
            public System.Boolean? InteractiveConfiguration_LivyEndpointEnabled { get; set; }
            public System.Boolean? InteractiveConfiguration_StudioEnabled { get; set; }
            public System.String MaximumCapacity_Cpu { get; set; }
            public System.String MaximumCapacity_Disk { get; set; }
            public System.String MaximumCapacity_Memory { get; set; }
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
            public System.String Name { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroupId { get; set; }
            public List<System.String> NetworkConfiguration_SubnetId { get; set; }
            public System.String ReleaseLabel { get; set; }
            public List<Amazon.EMRServerless.Model.Configuration> RuntimeConfiguration { get; set; }
            public System.Int32? SchedulerConfiguration_MaxConcurrentRun { get; set; }
            public System.Int32? SchedulerConfiguration_QueueTimeoutMinute { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Type { get; set; }
            public Dictionary<System.String, Amazon.EMRServerless.Model.WorkerTypeSpecificationInput> WorkerTypeSpecification { get; set; }
            public System.Func<Amazon.EMRServerless.Model.CreateApplicationResponse, NewEMRServerlessApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
