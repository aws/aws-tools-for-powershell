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
    /// Creates an Amazon Managed Workflows for Apache Airflow (Amazon MWAA) environment.
    /// </summary>
    [Cmdlet("New", "MWAAEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AmazonMWAA CreateEnvironment API operation.", Operation = new[] {"CreateEnvironment"}, SelectReturnType = typeof(Amazon.MWAA.Model.CreateEnvironmentResponse))]
    [AWSCmdletOutput("System.String or Amazon.MWAA.Model.CreateEnvironmentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MWAA.Model.CreateEnvironmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMWAAEnvironmentCmdlet : AmazonMWAAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AirflowConfigurationOption
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs containing the Apache Airflow configuration options you
        /// want to attach to your environment. For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-env-variables.html">Apache
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
        /// <para>The Apache Airflow version for your environment. If no value is specified, it defaults
        /// to the latest version. For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/airflow-versions.html">Apache
        /// Airflow versions on Amazon Managed Workflows for Apache Airflow (Amazon MWAA)</a>.</para><para>Valid values: <c>1.10.12</c>, <c>2.0.2</c>, <c>2.2.2</c>, <c>2.4.3</c>, <c>2.5.1</c>,
        /// <c>2.6.3</c>, <c>2.7.2</c>, <c>2.8.1</c>, <c>2.9.2</c>, and <c>2.10.1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AirflowVersion { get; set; }
        #endregion
        
        #region Parameter DagS3Path
        /// <summary>
        /// <para>
        /// <para>The relative path to the DAGs folder on your Amazon S3 bucket. For example, <c>dags</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-dag-folder.html">Adding
        /// or updating DAGs</a>.</para>
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
        public System.String DagS3Path { get; set; }
        #endregion
        
        #region Parameter DagProcessingLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <c>DagProcessingLogs</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_DagProcessingLogs_Enabled")]
        public System.Boolean? DagProcessingLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter SchedulerLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <c>DagProcessingLogs</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_SchedulerLogs_Enabled")]
        public System.Boolean? SchedulerLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter TaskLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <c>DagProcessingLogs</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_TaskLogs_Enabled")]
        public System.Boolean? TaskLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter WebserverLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <c>DagProcessingLogs</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_WebserverLogs_Enabled")]
        public System.Boolean? WebserverLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter WorkerLogs_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable the Apache Airflow log type (e.g. <c>DagProcessingLogs</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_WorkerLogs_Enabled")]
        public System.Boolean? WorkerLogs_Enabled { get; set; }
        #endregion
        
        #region Parameter EndpointManagement
        /// <summary>
        /// <para>
        /// <para>Defines whether the VPC endpoints configured for the environment are created, and
        /// managed, by the customer or by Amazon MWAA. If set to <c>SERVICE</c>, Amazon MWAA
        /// will create and manage the required VPC endpoints in your VPC. If set to <c>CUSTOMER</c>,
        /// you must create, and manage, the VPC endpoints for your VPC. If you choose to create
        /// an environment in a shared VPC, you must set this value to <c>CUSTOMER</c>. In a shared
        /// VPC deployment, the environment will remain in <c>PENDING</c> status until you create
        /// the VPC endpoints. If you do not take action to create the endpoints within 72 hours,
        /// the status will change to <c>CREATE_FAILED</c>. You can delete the failed environment
        /// and create a new one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MWAA.EndpointManagement")]
        public Amazon.MWAA.EndpointManagement EndpointManagement { get; set; }
        #endregion
        
        #region Parameter EnvironmentClass
        /// <summary>
        /// <para>
        /// <para>The environment class type. Valid values: <c>mw1.small</c>, <c>mw1.medium</c>, <c>mw1.large</c>,
        /// <c>mw1.xlarge</c>, and <c>mw1.2xlarge</c>. For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/environment-class.html">Amazon
        /// MWAA environment class</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentClass { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the execution role for your environment. An execution
        /// role is an Amazon Web Services Identity and Access Management (IAM) role that grants
        /// MWAA permission to access Amazon Web Services services and resources used by your
        /// environment. For example, <c>arn:aws:iam::123456789:role/my-execution-role</c>. For
        /// more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/mwaa-create-role.html">Amazon
        /// MWAA Execution role</a>.</para>
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
        
        #region Parameter KmsKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management Service (KMS) key to encrypt the data in your
        /// environment. You can use an Amazon Web Services owned CMK, or a Customer managed CMK
        /// (advanced). For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/create-environment.html">Create
        /// an Amazon MWAA environment</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKey { get; set; }
        #endregion
        
        #region Parameter DagProcessingLogs_LogLevel
        /// <summary>
        /// <para>
        /// <para>Defines the Apache Airflow log level (e.g. <c>INFO</c>) to send to CloudWatch Logs.</para>
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
        /// <para>Defines the Apache Airflow log level (e.g. <c>INFO</c>) to send to CloudWatch Logs.</para>
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
        /// <para>Defines the Apache Airflow log level (e.g. <c>INFO</c>) to send to CloudWatch Logs.</para>
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
        /// <para>Defines the Apache Airflow log level (e.g. <c>INFO</c>) to send to CloudWatch Logs.</para>
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
        /// <para>Defines the Apache Airflow log level (e.g. <c>INFO</c>) to send to CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_WorkerLogs_LogLevel")]
        [AWSConstantClassSource("Amazon.MWAA.LoggingLevel")]
        public Amazon.MWAA.LoggingLevel WorkerLogs_LogLevel { get; set; }
        #endregion
        
        #region Parameter MaxWebserver
        /// <summary>
        /// <para>
        /// <para> The maximum number of web servers that you want to run in your environment. Amazon
        /// MWAA scales the number of Apache Airflow web servers up to the number you specify
        /// for <c>MaxWebservers</c> when you interact with your Apache Airflow environment using
        /// Apache Airflow REST API, or the Apache Airflow CLI. For example, in scenarios where
        /// your workload requires network calls to the Apache Airflow REST API with a high transaction-per-second
        /// (TPS) rate, Amazon MWAA will increase the number of web servers up to the number set
        /// in <c>MaxWebserers</c>. As TPS rates decrease Amazon MWAA disposes of the additional
        /// web servers, and scales down to the number set in <c>MinxWebserers</c>. </para><para>Valid values: Accepts between <c>2</c> and <c>5</c>. Defaults to <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxWebservers")]
        public System.Int32? MaxWebserver { get; set; }
        #endregion
        
        #region Parameter MaxWorker
        /// <summary>
        /// <para>
        /// <para>The maximum number of workers that you want to run in your environment. MWAA scales
        /// the number of Apache Airflow workers up to the number you specify in the <c>MaxWorkers</c>
        /// field. For example, <c>20</c>. When there are no more tasks running, and no more in
        /// the queue, MWAA disposes of the extra workers leaving the one worker that is included
        /// with your environment, or the number you specify in <c>MinWorkers</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxWorkers")]
        public System.Int32? MaxWorker { get; set; }
        #endregion
        
        #region Parameter MinWebserver
        /// <summary>
        /// <para>
        /// <para> The minimum number of web servers that you want to run in your environment. Amazon
        /// MWAA scales the number of Apache Airflow web servers up to the number you specify
        /// for <c>MaxWebservers</c> when you interact with your Apache Airflow environment using
        /// Apache Airflow REST API, or the Apache Airflow CLI. As the transaction-per-second
        /// rate, and the network load, decrease, Amazon MWAA disposes of the additional web servers,
        /// and scales down to the number set in <c>MinxWebserers</c>. </para><para>Valid values: Accepts between <c>2</c> and <c>5</c>. Defaults to <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinWebservers")]
        public System.Int32? MinWebserver { get; set; }
        #endregion
        
        #region Parameter MinWorker
        /// <summary>
        /// <para>
        /// <para>The minimum number of workers that you want to run in your environment. MWAA scales
        /// the number of Apache Airflow workers up to the number you specify in the <c>MaxWorkers</c>
        /// field. When there are no more tasks running, and no more in the queue, MWAA disposes
        /// of the extra workers leaving the worker count you specify in the <c>MinWorkers</c>
        /// field. For example, <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinWorkers")]
        public System.Int32? MinWorker { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon MWAA environment. For example, <c>MyMWAAEnvironment</c>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PluginsS3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of the plugins.zip file on your Amazon S3 bucket. You must specify a version
        /// each time a plugins.zip file is updated. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/versioning-workflows.html">How
        /// S3 Versioning works</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PluginsS3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter PluginsS3Path
        /// <summary>
        /// <para>
        /// <para>The relative path to the <c>plugins.zip</c> file on your Amazon S3 bucket. For example,
        /// <c>plugins.zip</c>. If specified, then the <c>plugins.zip</c> version is required.
        /// For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-dag-import-plugins.html">Installing
        /// custom plugins</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PluginsS3Path { get; set; }
        #endregion
        
        #region Parameter RequirementsS3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of the <c>requirements.txt</c> file on your Amazon S3 bucket. You must
        /// specify a version each time a requirements.txt file is updated. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/versioning-workflows.html">How
        /// S3 Versioning works</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequirementsS3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter RequirementsS3Path
        /// <summary>
        /// <para>
        /// <para>The relative path to the <c>requirements.txt</c> file on your Amazon S3 bucket. For
        /// example, <c>requirements.txt</c>. If specified, then a version is required. For more
        /// information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/working-dags-dependencies.html">Installing
        /// Python dependencies</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequirementsS3Path { get; set; }
        #endregion
        
        #region Parameter Scheduler
        /// <summary>
        /// <para>
        /// <para>The number of Apache Airflow schedulers to run in your environment. Valid values:</para><ul><li><para>v2 - Accepts between <c>2</c> to <c>5</c>. Defaults to <c>2</c>.</para></li><li><para>v1 - Accepts <c>1</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedulers")]
        public System.Int32? Scheduler { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security group IDs. For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/vpc-security.html">Security
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
        /// files are stored. For example, <c>arn:aws:s3:::my-airflow-bucket-unique-name</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/mwaa-s3-bucket.html">Create
        /// an Amazon S3 bucket for Amazon MWAA</a>.</para>
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
        public System.String SourceBucketArn { get; set; }
        #endregion
        
        #region Parameter StartupScriptS3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of the startup shell script in your Amazon S3 bucket. You must specify
        /// the <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/versioning-workflows.html">version
        /// ID</a> that Amazon S3 assigns to the file every time you update the script. </para><para> Version IDs are Unicode, UTF-8 encoded, URL-ready, opaque strings that are no more
        /// than 1,024 bytes long. The following is an example: </para><para><c>3sL4kqtJlcpXroDTDmJ+rmSpXd3dIbrHY+MTRCxf3vjVBH40Nr8X8gdRQBpUMLUo</c></para><para> For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/using-startup-script.html">Using
        /// a startup script</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartupScriptS3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter StartupScriptS3Path
        /// <summary>
        /// <para>
        /// <para>The relative path to the startup shell script in your Amazon S3 bucket. For example,
        /// <c>s3://mwaa-environment/startup.sh</c>.</para><para> Amazon MWAA runs the script as your environment starts, and before running the Apache
        /// Airflow process. You can use this script to install dependencies, modify Apache Airflow
        /// configuration options, and set environment variables. For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/using-startup-script.html">Using
        /// a startup script</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartupScriptS3Path { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs. For more information, see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/networking-about.html">About
        /// networking on Amazon MWAA</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_SubnetIds")]
        public System.String[] NetworkConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value tag pairs you want to associate to your environment. For example, <c>"Environment":
        /// "Staging"</c>. For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WebserverAccessMode
        /// <summary>
        /// <para>
        /// <para>Defines the access mode for the Apache Airflow <i>web server</i>. For more information,
        /// see <a href="https://docs.aws.amazon.com/mwaa/latest/userguide/configuring-networking.html">Apache
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
        /// <c>DAY:HH:MM</c>. For example: <c>TUE:03:30</c>. You can specify a start time in 30
        /// minute increments only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WeeklyMaintenanceWindowStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MWAA.Model.CreateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.MWAA.Model.CreateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MWAAEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MWAA.Model.CreateEnvironmentResponse, NewMWAAEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AirflowConfigurationOption != null)
            {
                context.AirflowConfigurationOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AirflowConfigurationOption.Keys)
                {
                    context.AirflowConfigurationOption.Add((String)hashKey, (System.String)(this.AirflowConfigurationOption[hashKey]));
                }
            }
            context.AirflowVersion = this.AirflowVersion;
            context.DagS3Path = this.DagS3Path;
            #if MODULAR
            if (this.DagS3Path == null && ParameterWasBound(nameof(this.DagS3Path)))
            {
                WriteWarning("You are passing $null as a value for parameter DagS3Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointManagement = this.EndpointManagement;
            context.EnvironmentClass = this.EnvironmentClass;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKey = this.KmsKey;
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
            context.MaxWebserver = this.MaxWebserver;
            context.MaxWorker = this.MaxWorker;
            context.MinWebserver = this.MinWebserver;
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
            if (this.NetworkConfiguration_SubnetId != null)
            {
                context.NetworkConfiguration_SubnetId = new List<System.String>(this.NetworkConfiguration_SubnetId);
            }
            context.PluginsS3ObjectVersion = this.PluginsS3ObjectVersion;
            context.PluginsS3Path = this.PluginsS3Path;
            context.RequirementsS3ObjectVersion = this.RequirementsS3ObjectVersion;
            context.RequirementsS3Path = this.RequirementsS3Path;
            context.Scheduler = this.Scheduler;
            context.SourceBucketArn = this.SourceBucketArn;
            #if MODULAR
            if (this.SourceBucketArn == null && ParameterWasBound(nameof(this.SourceBucketArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceBucketArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartupScriptS3ObjectVersion = this.StartupScriptS3ObjectVersion;
            context.StartupScriptS3Path = this.StartupScriptS3Path;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.MWAA.Model.CreateEnvironmentRequest();
            
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
            if (cmdletContext.EndpointManagement != null)
            {
                request.EndpointManagement = cmdletContext.EndpointManagement;
            }
            if (cmdletContext.EnvironmentClass != null)
            {
                request.EnvironmentClass = cmdletContext.EnvironmentClass;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.KmsKey != null)
            {
                request.KmsKey = cmdletContext.KmsKey;
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
            if (cmdletContext.MaxWebserver != null)
            {
                request.MaxWebservers = cmdletContext.MaxWebserver.Value;
            }
            if (cmdletContext.MaxWorker != null)
            {
                request.MaxWorkers = cmdletContext.MaxWorker.Value;
            }
            if (cmdletContext.MinWebserver != null)
            {
                request.MinWebservers = cmdletContext.MinWebserver.Value;
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
            request.NetworkConfiguration = new Amazon.MWAA.Model.NetworkConfiguration();
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
            if (cmdletContext.StartupScriptS3ObjectVersion != null)
            {
                request.StartupScriptS3ObjectVersion = cmdletContext.StartupScriptS3ObjectVersion;
            }
            if (cmdletContext.StartupScriptS3Path != null)
            {
                request.StartupScriptS3Path = cmdletContext.StartupScriptS3Path;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MWAA.Model.CreateEnvironmentResponse CallAWSServiceOperation(IAmazonMWAA client, Amazon.MWAA.Model.CreateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonMWAA", "CreateEnvironment");
            try
            {
                #if DESKTOP
                return client.CreateEnvironment(request);
                #elif CORECLR
                return client.CreateEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MWAA.EndpointManagement EndpointManagement { get; set; }
            public System.String EnvironmentClass { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String KmsKey { get; set; }
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
            public System.Int32? MaxWebserver { get; set; }
            public System.Int32? MaxWorker { get; set; }
            public System.Int32? MinWebserver { get; set; }
            public System.Int32? MinWorker { get; set; }
            public System.String Name { get; set; }
            public List<System.String> NetworkConfiguration_SecurityGroupId { get; set; }
            public List<System.String> NetworkConfiguration_SubnetId { get; set; }
            public System.String PluginsS3ObjectVersion { get; set; }
            public System.String PluginsS3Path { get; set; }
            public System.String RequirementsS3ObjectVersion { get; set; }
            public System.String RequirementsS3Path { get; set; }
            public System.Int32? Scheduler { get; set; }
            public System.String SourceBucketArn { get; set; }
            public System.String StartupScriptS3ObjectVersion { get; set; }
            public System.String StartupScriptS3Path { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.MWAA.WebserverAccessMode WebserverAccessMode { get; set; }
            public System.String WeeklyMaintenanceWindowStart { get; set; }
            public System.Func<Amazon.MWAA.Model.CreateEnvironmentResponse, NewMWAAEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
