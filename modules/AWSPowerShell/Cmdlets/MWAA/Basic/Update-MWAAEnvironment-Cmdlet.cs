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
using Amazon.MWAA;
using Amazon.MWAA.Model;

namespace Amazon.PowerShell.Cmdlets.MWAA
{
    /// <summary>
    /// Updates an Amazon Managed Workflows for Apache Airflow (MWAA) environment.
    /// </summary>
    [Cmdlet("Update", "MWAAEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AmazonMWAA UpdateEnvironment API operation.", Operation = new[] {"UpdateEnvironment"}, SelectReturnType = typeof(Amazon.MWAA.Model.UpdateEnvironmentResponse))]
    [AWSCmdletOutput("System.String or Amazon.MWAA.Model.UpdateEnvironmentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MWAA.Model.UpdateEnvironmentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMWAAEnvironmentCmdlet : AmazonMWAAClientCmdlet, IExecutor
    {
        
        #region Parameter AirflowConfigurationOption
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs containing the Apache Airflow configuration options you
        /// want to attach to your environment. To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-env-variables.html">Apache
        /// Airflow configuration options</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AirflowConfigurationOptions")]
        public System.Collections.Hashtable AirflowConfigurationOption { get; set; }
        #endregion
        
        #region Parameter AirflowVersion
        /// <summary>
        /// <para>
        /// <para>The Apache Airflow version for your environment. If no value is specified, defaults
        /// to the latest version. Valid values: <code>1.10.12</code>, <code>2.0.2</code>, and
        /// <code>2.2.2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AirflowVersion { get; set; }
        #endregion
        
        #region Parameter DagS3Path
        /// <summary>
        /// <para>
        /// <para>The relative path to the DAGs folder on your Amazon S3 bucket. For example, <code>dags</code>.
        /// To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-dag-folder.html">Adding
        /// or updating DAGs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DagS3Path { get; set; }
        #endregion
        
        #region Parameter DagProcessingLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <code>DagProcessingLogs</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_DagProcessingLogs_Enabled")]
        public System.Boolean? DagProcessingLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter SchedulerLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <code>DagProcessingLogs</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_SchedulerLogs_Enabled")]
        public System.Boolean? SchedulerLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter TaskLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <code>DagProcessingLogs</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_TaskLogs_Enabled")]
        public System.Boolean? TaskLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter WebserverLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <code>DagProcessingLogs</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_WebserverLogs_Enabled")]
        public System.Boolean? WebserverLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter WorkerLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <code>DagProcessingLogs</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_WorkerLogs_Enabled")]
        public System.Boolean? WorkerLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter EnvironmentClass
        /// <summary>
        /// <para>
        /// <para>The environment class type. Valid values: <code>mw1.small</code>, <code>mw1.medium</code>,
        /// <code>mw1.large</code>. To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/environment-class.html">Amazon
        /// MWAA environment class</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentClass { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the execution role in IAM that allows MWAA to access
        /// Amazon Web Services resources in your environment. For example, <code>arn:aws:iam::123456789:role/my-execution-role</code>.
        /// To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/mwaa-create-role.html">Amazon
        /// MWAA Execution role</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter DagProcessingLogs_LogLevel
        /// <summary>
        /// <para>
        /// <para>Defines the Apache Airflow log level (e.g. <code>INFO</code>) to send to CloudWatch
        /// Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_DagProcessingLogs_LogLevel")]
        [AWSConstantClassSource("Amazon.MWAA.LoggingLevel")]
        public Amazon.MWAA.LoggingLevel DagProcessingLogs_LogLevel { get; set; }
        #endregion
        
        #region Parameter SchedulerLogs_LogLevel
        /// <summary>
        /// <para>
        /// <para>Defines the Apache Airflow log level (e.g. <code>INFO</code>) to send to CloudWatch
        /// Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_SchedulerLogs_LogLevel")]
        [AWSConstantClassSource("Amazon.MWAA.LoggingLevel")]
        public Amazon.MWAA.LoggingLevel SchedulerLogs_LogLevel { get; set; }
        #endregion
        
        #region Parameter TaskLogs_LogLevel
        /// <summary>
        /// <para>
        /// <para>Defines the Apache Airflow log level (e.g. <code>INFO</code>) to send to CloudWatch
        /// Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_TaskLogs_LogLevel")]
        [AWSConstantClassSource("Amazon.MWAA.LoggingLevel")]
        public Amazon.MWAA.LoggingLevel TaskLogs_LogLevel { get; set; }
        #endregion
        
        #region Parameter WebserverLogs_LogLevel
        /// <summary>
        /// <para>
        /// <para>Defines the Apache Airflow log level (e.g. <code>INFO</code>) to send to CloudWatch
        /// Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_WebserverLogs_LogLevel")]
        [AWSConstantClassSource("Amazon.MWAA.LoggingLevel")]
        public Amazon.MWAA.LoggingLevel WebserverLogs_LogLevel { get; set; }
        #endregion
        
        #region Parameter WorkerLogs_LogLevel
        /// <summary>
        /// <para>
        /// <para>Defines the Apache Airflow log level (e.g. <code>INFO</code>) to send to CloudWatch
        /// Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_WorkerLogs_LogLevel")]
        [AWSConstantClassSource("Amazon.MWAA.LoggingLevel")]
        public Amazon.MWAA.LoggingLevel WorkerLogs_LogLevel { get; set; }
        #endregion
        
        #region Parameter MaxWorker
        /// <summary>
        /// <para>
        /// <para>The maximum number of workers that you want to run in your environment. MWAA scales
        /// the number of Apache Airflow workers up to the number you specify in the <code>MaxWorkers</code>
        /// field. For example, <code>20</code>. When there are no more tasks running, and no
        /// more in the queue, MWAA disposes of the extra workers leaving the one worker that
        /// is included with your environment, or the number you specify in <code>MinWorkers</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxWorkers")]
        public System.Int32? MaxWorker { get; set; }
        #endregion
        
        #region Parameter MinWorker
        /// <summary>
        /// <para>
        /// <para>The minimum number of workers that you want to run in your environment. MWAA scales
        /// the number of Apache Airflow workers up to the number you specify in the <code>MaxWorkers</code>
        /// field. When there are no more tasks running, and no more in the queue, MWAA disposes
        /// of the extra workers leaving the worker count you specify in the <code>MinWorkers</code>
        /// field. For example, <code>2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinWorkers")]
        public System.Int32? MinWorker { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of your Amazon MWAA environment. For example, <code>MyMWAAEnvironment</code>.</para>
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
        
        #region Parameter PluginsS3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of the plugins.zip file on your Amazon S3 bucket. A version must be specified
        /// each time a plugins.zip file is updated. To learn more, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/versioning-workflows.html">How
        /// S3 Versioning works</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PluginsS3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter PluginsS3Path
        /// <summary>
        /// <para>
        /// <para>The relative path to the <code>plugins.zip</code> file on your Amazon S3 bucket. For
        /// example, <code>plugins.zip</code>. If specified, then the plugins.zip version is required.
        /// To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-dag-import-plugins.html">Installing
        /// custom plugins</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PluginsS3Path { get; set; }
        #endregion
        
        #region Parameter RequirementsS3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of the requirements.txt file on your Amazon S3 bucket. A version must
        /// be specified each time a requirements.txt file is updated. To learn more, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/versioning-workflows.html">How
        /// S3 Versioning works</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequirementsS3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter RequirementsS3Path
        /// <summary>
        /// <para>
        /// <para>The relative path to the <code>requirements.txt</code> file on your Amazon S3 bucket.
        /// For example, <code>requirements.txt</code>. If specified, then a file version is required.
        /// To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/working-dags-dependencies.html">Installing
        /// Python dependencies</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequirementsS3Path { get; set; }
        #endregion
        
        #region Parameter Scheduler
        /// <summary>
        /// <para>
        /// <para>The number of Apache Airflow schedulers to run in your Amazon MWAA environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedulers")]
        public System.Int32? Scheduler { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security group IDs. A security group must be attached to the same VPC as
        /// the subnets. To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/vpc-security.html">Security
        /// in your VPC on Amazon MWAA</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SecurityGroupIds")]
        public System.String[] NetworkConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SourceBucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon S3 bucket where your DAG code and supporting
        /// files are stored. For example, <code>arn:aws:s3:::my-airflow-bucket-unique-name</code>.
        /// To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/mwaa-s3-bucket.html">Create
        /// an Amazon S3 bucket for Amazon MWAA</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceBucketArn { get; set; }
        #endregion
        
        #region Parameter WebserverAccessMode
        /// <summary>
        /// <para>
        /// <para>The Apache Airflow <i>Web server</i> access mode. To learn more, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-networking.html">Apache
        /// Airflow access modes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MWAA.WebserverAccessMode")]
        public Amazon.MWAA.WebserverAccessMode WebserverAccessMode { get; set; }
        #endregion
        
        #region Parameter WeeklyMaintenanceWindowStart
        /// <summary>
        /// <para>
        /// <para>The day and time of the week in Coordinated Universal Time (UTC) 24-hour standard
        /// time to start weekly maintenance updates of your environment in the following format:
        /// <code>DAY:HH:MM</code>. For example: <code>TUE:03:30</code>. You can specify a start
        /// time in 30 minute increments only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WeeklyMaintenanceWindowStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAA.Model.UpdateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.MWAA.Model.UpdateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MWAAEnvironment (UpdateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAA.Model.UpdateEnvironmentResponse, UpdateMWAAEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AirflowConfigurationOption != null)
            {
                context.AirflowConfigurationOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AirflowConfigurationOption.Keys)
                {
                    context.AirflowConfigurationOption.Add((String)hashKey, (String)(this.AirflowConfigurationOption[hashKey]));
                }
            }
            context.AirflowVersion = this.AirflowVersion;
            context.DagS3Path = this.DagS3Path;
            context.EnvironmentClass = this.EnvironmentClass;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.DagProcessingLogs_Enabled = this.DagProcessingLogs_Enabled;
            context.DagProcessingLogs_LogLevel = this.DagProcessingLogs_LogLevel;
            context.SchedulerLogs_Enabled = this.SchedulerLogs_Enabled;
            context.SchedulerLogs_LogLevel = this.SchedulerLogs_LogLevel;
            context.TaskLogs_Enabled = this.TaskLogs_Enabled;
            context.TaskLogs_LogLevel = this.TaskLogs_LogLevel;
            context.WebserverLogs_Enabled = this.WebserverLogs_Enabled;
            context.WebserverLogs_LogLevel = this.WebserverLogs_LogLevel;
            context.WorkerLogs_Enabled = this.WorkerLogs_Enabled;
            context.WorkerLogs_LogLevel = this.WorkerLogs_LogLevel;
            context.MaxWorker = this.MaxWorker;
            context.MinWorker = this.MinWorker;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NetworkConfiguration_SecurityGroupId != null)
            {
                context.NetworkConfiguration_SecurityGroupId = new List<System.String>(this.NetworkConfiguration_SecurityGroupId);
            }
            context.PluginsS3ObjectVersion = this.PluginsS3ObjectVersion;
            context.PluginsS3Path = this.PluginsS3Path;
            context.RequirementsS3ObjectVersion = this.RequirementsS3ObjectVersion;
            context.RequirementsS3Path = this.RequirementsS3Path;
            context.Scheduler = this.Scheduler;
            context.SourceBucketArn = this.SourceBucketArn;
            context.WebserverAccessMode = this.WebserverAccessMode;
            context.WeeklyMaintenanceWindowStart = this.WeeklyMaintenanceWindowStart;
            
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
            var request = new Amazon.MWAA.Model.UpdateEnvironmentRequest();
            
            if (cmdletContext.AirflowConfigurationOption != null)
            {
                request.AirflowConfigurationOptions = cmdletContext.AirflowConfigurationOption;
            }
            if (cmdletContext.AirflowVersion != null)
            {
                request.AirflowVersion = cmdletContext.AirflowVersion;
            }
            if (cmdletContext.DagS3Path != null)
            {
                request.DagS3Path = cmdletContext.DagS3Path;
            }
            if (cmdletContext.EnvironmentClass != null)
            {
                request.EnvironmentClass = cmdletContext.EnvironmentClass;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.MWAA.Model.LoggingConfigurationInput();
            Amazon.MWAA.Model.ModuleLoggingConfigurationInput requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs = null;
            
             // populate DagProcessingLogs
            var requestLoggingConfiguration_loggingConfiguration_DagProcessingLogsIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs = new Amazon.MWAA.Model.ModuleLoggingConfigurationInput();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_Enabled = null;
            if (cmdletContext.DagProcessingLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_Enabled = cmdletContext.DagProcessingLogs_Enabled.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs.Enabled = requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_Enabled.Value;
                requestLoggingConfiguration_loggingConfiguration_DagProcessingLogsIsNull = false;
            }
            Amazon.MWAA.LoggingLevel requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_LogLevel = null;
            if (cmdletContext.DagProcessingLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_LogLevel = cmdletContext.DagProcessingLogs_LogLevel;
            }
            if (requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs.LogLevel = requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs_dagProcessingLogs_LogLevel;
                requestLoggingConfiguration_loggingConfiguration_DagProcessingLogsIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_DagProcessingLogsIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs != null)
            {
                request.LoggingConfiguration.DagProcessingLogs = requestLoggingConfiguration_loggingConfiguration_DagProcessingLogs;
                requestLoggingConfigurationIsNull = false;
            }
            Amazon.MWAA.Model.ModuleLoggingConfigurationInput requestLoggingConfiguration_loggingConfiguration_SchedulerLogs = null;
            
             // populate SchedulerLogs
            var requestLoggingConfiguration_loggingConfiguration_SchedulerLogsIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_SchedulerLogs = new Amazon.MWAA.Model.ModuleLoggingConfigurationInput();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_Enabled = null;
            if (cmdletContext.SchedulerLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_Enabled = cmdletContext.SchedulerLogs_Enabled.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_SchedulerLogs.Enabled = requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_Enabled.Value;
                requestLoggingConfiguration_loggingConfiguration_SchedulerLogsIsNull = false;
            }
            Amazon.MWAA.LoggingLevel requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_LogLevel = null;
            if (cmdletContext.SchedulerLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_LogLevel = cmdletContext.SchedulerLogs_LogLevel;
            }
            if (requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_SchedulerLogs.LogLevel = requestLoggingConfiguration_loggingConfiguration_SchedulerLogs_schedulerLogs_LogLevel;
                requestLoggingConfiguration_loggingConfiguration_SchedulerLogsIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_SchedulerLogs should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_SchedulerLogsIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_SchedulerLogs = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_SchedulerLogs != null)
            {
                request.LoggingConfiguration.SchedulerLogs = requestLoggingConfiguration_loggingConfiguration_SchedulerLogs;
                requestLoggingConfigurationIsNull = false;
            }
            Amazon.MWAA.Model.ModuleLoggingConfigurationInput requestLoggingConfiguration_loggingConfiguration_TaskLogs = null;
            
             // populate TaskLogs
            var requestLoggingConfiguration_loggingConfiguration_TaskLogsIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_TaskLogs = new Amazon.MWAA.Model.ModuleLoggingConfigurationInput();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_Enabled = null;
            if (cmdletContext.TaskLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_Enabled = cmdletContext.TaskLogs_Enabled.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_TaskLogs.Enabled = requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_Enabled.Value;
                requestLoggingConfiguration_loggingConfiguration_TaskLogsIsNull = false;
            }
            Amazon.MWAA.LoggingLevel requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_LogLevel = null;
            if (cmdletContext.TaskLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_LogLevel = cmdletContext.TaskLogs_LogLevel;
            }
            if (requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_TaskLogs.LogLevel = requestLoggingConfiguration_loggingConfiguration_TaskLogs_taskLogs_LogLevel;
                requestLoggingConfiguration_loggingConfiguration_TaskLogsIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_TaskLogs should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_TaskLogsIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_TaskLogs = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_TaskLogs != null)
            {
                request.LoggingConfiguration.TaskLogs = requestLoggingConfiguration_loggingConfiguration_TaskLogs;
                requestLoggingConfigurationIsNull = false;
            }
            Amazon.MWAA.Model.ModuleLoggingConfigurationInput requestLoggingConfiguration_loggingConfiguration_WebserverLogs = null;
            
             // populate WebserverLogs
            var requestLoggingConfiguration_loggingConfiguration_WebserverLogsIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_WebserverLogs = new Amazon.MWAA.Model.ModuleLoggingConfigurationInput();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_Enabled = null;
            if (cmdletContext.WebserverLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_Enabled = cmdletContext.WebserverLogs_Enabled.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WebserverLogs.Enabled = requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_Enabled.Value;
                requestLoggingConfiguration_loggingConfiguration_WebserverLogsIsNull = false;
            }
            Amazon.MWAA.LoggingLevel requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_LogLevel = null;
            if (cmdletContext.WebserverLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_LogLevel = cmdletContext.WebserverLogs_LogLevel;
            }
            if (requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WebserverLogs.LogLevel = requestLoggingConfiguration_loggingConfiguration_WebserverLogs_webserverLogs_LogLevel;
                requestLoggingConfiguration_loggingConfiguration_WebserverLogsIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_WebserverLogs should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_WebserverLogsIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_WebserverLogs = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_WebserverLogs != null)
            {
                request.LoggingConfiguration.WebserverLogs = requestLoggingConfiguration_loggingConfiguration_WebserverLogs;
                requestLoggingConfigurationIsNull = false;
            }
            Amazon.MWAA.Model.ModuleLoggingConfigurationInput requestLoggingConfiguration_loggingConfiguration_WorkerLogs = null;
            
             // populate WorkerLogs
            var requestLoggingConfiguration_loggingConfiguration_WorkerLogsIsNull = true;
            requestLoggingConfiguration_loggingConfiguration_WorkerLogs = new Amazon.MWAA.Model.ModuleLoggingConfigurationInput();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_Enabled = null;
            if (cmdletContext.WorkerLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_Enabled = cmdletContext.WorkerLogs_Enabled.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_Enabled != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WorkerLogs.Enabled = requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_Enabled.Value;
                requestLoggingConfiguration_loggingConfiguration_WorkerLogsIsNull = false;
            }
            Amazon.MWAA.LoggingLevel requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_LogLevel = null;
            if (cmdletContext.WorkerLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_LogLevel = cmdletContext.WorkerLogs_LogLevel;
            }
            if (requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_LogLevel != null)
            {
                requestLoggingConfiguration_loggingConfiguration_WorkerLogs.LogLevel = requestLoggingConfiguration_loggingConfiguration_WorkerLogs_workerLogs_LogLevel;
                requestLoggingConfiguration_loggingConfiguration_WorkerLogsIsNull = false;
            }
             // determine if requestLoggingConfiguration_loggingConfiguration_WorkerLogs should be set to null
            if (requestLoggingConfiguration_loggingConfiguration_WorkerLogsIsNull)
            {
                requestLoggingConfiguration_loggingConfiguration_WorkerLogs = null;
            }
            if (requestLoggingConfiguration_loggingConfiguration_WorkerLogs != null)
            {
                request.LoggingConfiguration.WorkerLogs = requestLoggingConfiguration_loggingConfiguration_WorkerLogs;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            if (cmdletContext.MaxWorker != null)
            {
                request.MaxWorkers = cmdletContext.MaxWorker.Value;
            }
            if (cmdletContext.MinWorker != null)
            {
                request.MinWorkers = cmdletContext.MinWorker.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.MWAA.Model.UpdateNetworkConfigurationInput();
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
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.PluginsS3ObjectVersion != null)
            {
                request.PluginsS3ObjectVersion = cmdletContext.PluginsS3ObjectVersion;
            }
            if (cmdletContext.PluginsS3Path != null)
            {
                request.PluginsS3Path = cmdletContext.PluginsS3Path;
            }
            if (cmdletContext.RequirementsS3ObjectVersion != null)
            {
                request.RequirementsS3ObjectVersion = cmdletContext.RequirementsS3ObjectVersion;
            }
            if (cmdletContext.RequirementsS3Path != null)
            {
                request.RequirementsS3Path = cmdletContext.RequirementsS3Path;
            }
            if (cmdletContext.Scheduler != null)
            {
                request.Schedulers = cmdletContext.Scheduler.Value;
            }
            if (cmdletContext.SourceBucketArn != null)
            {
                request.SourceBucketArn = cmdletContext.SourceBucketArn;
            }
            if (cmdletContext.WebserverAccessMode != null)
            {
                request.WebserverAccessMode = cmdletContext.WebserverAccessMode;
            }
            if (cmdletContext.WeeklyMaintenanceWindowStart != null)
            {
                request.WeeklyMaintenanceWindowStart = cmdletContext.WeeklyMaintenanceWindowStart;
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
        
        private Amazon.MWAA.Model.UpdateEnvironmentResponse CallAWSServiceOperation(IAmazonMWAA client, Amazon.MWAA.Model.UpdateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAA", "UpdateEnvironment");
            try
            {
                #if DESKTOP
                return client.UpdateEnvironment(request);
                #elif CORECLR
                return client.UpdateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AirflowConfigurationOption { get; set; }
            public System.String AirflowVersion { get; set; }
            public System.String DagS3Path { get; set; }
            public System.String EnvironmentClass { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Boolean? DagProcessingLogs_Enabled { get; set; }
            public Amazon.MWAA.LoggingLevel DagProcessingLogs_LogLevel { get; set; }
            public System.Boolean? SchedulerLogs_Enabled { get; set; }
            public Amazon.MWAA.LoggingLevel SchedulerLogs_LogLevel { get; set; }
            public System.Boolean? TaskLogs_Enabled { get; set; }
            public Amazon.MWAA.LoggingLevel TaskLogs_LogLevel { get; set; }
            public System.Boolean? WebserverLogs_Enabled { get; set; }
            public Amazon.MWAA.LoggingLevel WebserverLogs_LogLevel { get; set; }
            public System.Boolean? WorkerLogs_Enabled { get; set; }
            public Amazon.MWAA.LoggingLevel WorkerLogs_LogLevel { get; set; }
            public System.Int32? MaxWorker { get; set; }
            public System.Int32? MinWorker { get; set; }
            public System.String Name { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroupId { get; set; }
            public System.String PluginsS3ObjectVersion { get; set; }
            public System.String PluginsS3Path { get; set; }
            public System.String RequirementsS3ObjectVersion { get; set; }
            public System.String RequirementsS3Path { get; set; }
            public System.Int32? Scheduler { get; set; }
            public System.String SourceBucketArn { get; set; }
            public Amazon.MWAA.WebserverAccessMode WebserverAccessMode { get; set; }
            public System.String WeeklyMaintenanceWindowStart { get; set; }
            public System.Func<Amazon.MWAA.Model.UpdateEnvironmentResponse, UpdateMWAAEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
