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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Updates the monitoring settings for the cluster. You can use this operation to specify
    /// which Apache Kafka metrics you want Amazon MSK to send to Amazon CloudWatch. You can
    /// also specify settings for open monitoring with Prometheus.
    /// </summary>
    [Cmdlet("Update", "MSKMonitoring", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.UpdateMonitoringResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) UpdateMonitoring API operation.", Operation = new[] {"UpdateMonitoring"}, SelectReturnType = typeof(Amazon.Kafka.Model.UpdateMonitoringResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.UpdateMonitoringResponse",
        "This cmdlet returns an Amazon.Kafka.Model.UpdateMonitoringResponse object containing multiple properties."
    )]
    public partial class UpdateMSKMonitoringCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_Bucket
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_S3_Bucket")]
        public System.String S3_Bucket { get; set; }
        #endregion
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the cluster.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the MSK cluster to update. Cluster versions aren't simple numbers.
        /// You can describe an MSK cluster to find its version. When this update operation is
        /// successful, it generates a new cluster version.</para>
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
        public System.String CurrentVersion { get; set; }
        #endregion
        
        #region Parameter Firehose_DeliveryStream
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_Firehose_DeliveryStream")]
        public System.String Firehose_DeliveryStream { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_CloudWatchLogs_Enabled")]
        public System.Boolean? CloudWatchLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter Firehose_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_Firehose_Enabled")]
        public System.Boolean? Firehose_Enabled { get; set; }
        #endregion
        
        #region Parameter S3_Enabled
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_S3_Enabled")]
        public System.Boolean? S3_Enabled { get; set; }
        #endregion
        
        #region Parameter JmxExporter_EnabledInBroker
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to turn on or turn off the JMX Exporter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenMonitoring_Prometheus_JmxExporter_EnabledInBroker")]
        public System.Boolean? JmxExporter_EnabledInBroker { get; set; }
        #endregion
        
        #region Parameter NodeExporter_EnabledInBroker
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want to turn on or turn off the Node Exporter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenMonitoring_Prometheus_NodeExporter_EnabledInBroker")]
        public System.Boolean? NodeExporter_EnabledInBroker { get; set; }
        #endregion
        
        #region Parameter EnhancedMonitoring
        /// <summary>
        /// <para>
        /// <para>Specifies which Apache Kafka metrics Amazon MSK gathers and sends to Amazon CloudWatch
        /// for this cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.EnhancedMonitoring")]
        public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_LogGroup
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_CloudWatchLogs_LogGroup")]
        public System.String CloudWatchLogs_LogGroup { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingInfo_BrokerLogs_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.UpdateMonitoringResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.UpdateMonitoringResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKMonitoring (UpdateMonitoring)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.UpdateMonitoringResponse, UpdateMSKMonitoringCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnhancedMonitoring = this.EnhancedMonitoring;
            context.CloudWatchLogs_Enabled = this.CloudWatchLogs_Enabled;
            context.CloudWatchLogs_LogGroup = this.CloudWatchLogs_LogGroup;
            context.Firehose_DeliveryStream = this.Firehose_DeliveryStream;
            context.Firehose_Enabled = this.Firehose_Enabled;
            context.S3_Bucket = this.S3_Bucket;
            context.S3_Enabled = this.S3_Enabled;
            context.S3_Prefix = this.S3_Prefix;
            context.JmxExporter_EnabledInBroker = this.JmxExporter_EnabledInBroker;
            context.NodeExporter_EnabledInBroker = this.NodeExporter_EnabledInBroker;
            
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
            var request = new Amazon.Kafka.Model.UpdateMonitoringRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
            }
            if (cmdletContext.EnhancedMonitoring != null)
            {
                request.EnhancedMonitoring = cmdletContext.EnhancedMonitoring;
            }
            
             // populate LoggingInfo
            var requestLoggingInfoIsNull = true;
            request.LoggingInfo = new Amazon.Kafka.Model.LoggingInfo();
            Amazon.Kafka.Model.BrokerLogs requestLoggingInfo_loggingInfo_BrokerLogs = null;
            
             // populate BrokerLogs
            var requestLoggingInfo_loggingInfo_BrokerLogsIsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs = new Amazon.Kafka.Model.BrokerLogs();
            Amazon.Kafka.Model.CloudWatchLogs requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs = new Amazon.Kafka.Model.CloudWatchLogs();
            System.Boolean? requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled = null;
            if (cmdletContext.CloudWatchLogs_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled = cmdletContext.CloudWatchLogs_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs.Enabled = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_Enabled.Value;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = null;
            if (cmdletContext.CloudWatchLogs_LogGroup != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup = cmdletContext.CloudWatchLogs_LogGroup;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs.LogGroup = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs_cloudWatchLogs_LogGroup;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogsIsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs.CloudWatchLogs = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_CloudWatchLogs;
                requestLoggingInfo_loggingInfo_BrokerLogsIsNull = false;
            }
            Amazon.Kafka.Model.Firehose requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose = null;
            
             // populate Firehose
            var requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose = new Amazon.Kafka.Model.Firehose();
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream = null;
            if (cmdletContext.Firehose_DeliveryStream != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream = cmdletContext.Firehose_DeliveryStream;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose.DeliveryStream = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_DeliveryStream;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull = false;
            }
            System.Boolean? requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled = null;
            if (cmdletContext.Firehose_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled = cmdletContext.Firehose_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose.Enabled = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose_firehose_Enabled.Value;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_FirehoseIsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs.Firehose = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_Firehose;
                requestLoggingInfo_loggingInfo_BrokerLogsIsNull = false;
            }
            Amazon.Kafka.Model.S3 requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 = null;
            
             // populate S3
            var requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = true;
            requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 = new Amazon.Kafka.Model.S3();
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket = null;
            if (cmdletContext.S3_Bucket != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket = cmdletContext.S3_Bucket;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3.Bucket = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Bucket;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = false;
            }
            System.Boolean? requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled = null;
            if (cmdletContext.S3_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled = cmdletContext.S3_Enabled.Value;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3.Enabled = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Enabled.Value;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = false;
            }
            System.String requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3.Prefix = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3_s3_Prefix;
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3IsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3 != null)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs.S3 = requestLoggingInfo_loggingInfo_BrokerLogs_loggingInfo_BrokerLogs_S3;
                requestLoggingInfo_loggingInfo_BrokerLogsIsNull = false;
            }
             // determine if requestLoggingInfo_loggingInfo_BrokerLogs should be set to null
            if (requestLoggingInfo_loggingInfo_BrokerLogsIsNull)
            {
                requestLoggingInfo_loggingInfo_BrokerLogs = null;
            }
            if (requestLoggingInfo_loggingInfo_BrokerLogs != null)
            {
                request.LoggingInfo.BrokerLogs = requestLoggingInfo_loggingInfo_BrokerLogs;
                requestLoggingInfoIsNull = false;
            }
             // determine if request.LoggingInfo should be set to null
            if (requestLoggingInfoIsNull)
            {
                request.LoggingInfo = null;
            }
            
             // populate OpenMonitoring
            var requestOpenMonitoringIsNull = true;
            request.OpenMonitoring = new Amazon.Kafka.Model.OpenMonitoringInfo();
            Amazon.Kafka.Model.PrometheusInfo requestOpenMonitoring_openMonitoring_Prometheus = null;
            
             // populate Prometheus
            var requestOpenMonitoring_openMonitoring_PrometheusIsNull = true;
            requestOpenMonitoring_openMonitoring_Prometheus = new Amazon.Kafka.Model.PrometheusInfo();
            Amazon.Kafka.Model.JmxExporterInfo requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter = null;
            
             // populate JmxExporter
            var requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporterIsNull = true;
            requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter = new Amazon.Kafka.Model.JmxExporterInfo();
            System.Boolean? requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker = null;
            if (cmdletContext.JmxExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker = cmdletContext.JmxExporter_EnabledInBroker.Value;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter.EnabledInBroker = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter_jmxExporter_EnabledInBroker.Value;
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporterIsNull = false;
            }
             // determine if requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter should be set to null
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporterIsNull)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter = null;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus.JmxExporter = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_JmxExporter;
                requestOpenMonitoring_openMonitoring_PrometheusIsNull = false;
            }
            Amazon.Kafka.Model.NodeExporterInfo requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter = null;
            
             // populate NodeExporter
            var requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporterIsNull = true;
            requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter = new Amazon.Kafka.Model.NodeExporterInfo();
            System.Boolean? requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker = null;
            if (cmdletContext.NodeExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker = cmdletContext.NodeExporter_EnabledInBroker.Value;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter.EnabledInBroker = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter_nodeExporter_EnabledInBroker.Value;
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporterIsNull = false;
            }
             // determine if requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter should be set to null
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporterIsNull)
            {
                requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter = null;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter != null)
            {
                requestOpenMonitoring_openMonitoring_Prometheus.NodeExporter = requestOpenMonitoring_openMonitoring_Prometheus_openMonitoring_Prometheus_NodeExporter;
                requestOpenMonitoring_openMonitoring_PrometheusIsNull = false;
            }
             // determine if requestOpenMonitoring_openMonitoring_Prometheus should be set to null
            if (requestOpenMonitoring_openMonitoring_PrometheusIsNull)
            {
                requestOpenMonitoring_openMonitoring_Prometheus = null;
            }
            if (requestOpenMonitoring_openMonitoring_Prometheus != null)
            {
                request.OpenMonitoring.Prometheus = requestOpenMonitoring_openMonitoring_Prometheus;
                requestOpenMonitoringIsNull = false;
            }
             // determine if request.OpenMonitoring should be set to null
            if (requestOpenMonitoringIsNull)
            {
                request.OpenMonitoring = null;
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
        
        private Amazon.Kafka.Model.UpdateMonitoringResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.UpdateMonitoringRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "UpdateMonitoring");
            try
            {
                #if DESKTOP
                return client.UpdateMonitoring(request);
                #elif CORECLR
                return client.UpdateMonitoringAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String CurrentVersion { get; set; }
            public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
            public System.Boolean? CloudWatchLogs_Enabled { get; set; }
            public System.String CloudWatchLogs_LogGroup { get; set; }
            public System.String Firehose_DeliveryStream { get; set; }
            public System.Boolean? Firehose_Enabled { get; set; }
            public System.String S3_Bucket { get; set; }
            public System.Boolean? S3_Enabled { get; set; }
            public System.String S3_Prefix { get; set; }
            public System.Boolean? JmxExporter_EnabledInBroker { get; set; }
            public System.Boolean? NodeExporter_EnabledInBroker { get; set; }
            public System.Func<Amazon.Kafka.Model.UpdateMonitoringResponse, UpdateMSKMonitoringCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
