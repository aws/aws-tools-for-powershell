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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Starts a job run. A job run is a unit of work, such as a Spark jar, PySpark script,
    /// or SparkSQL query, that you submit to Amazon EMR on EKS.
    /// </summary>
    [Cmdlet("Start", "EMRCJobRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRContainers.Model.StartJobRunResponse")]
    [AWSCmdlet("Calls the Amazon EMR Containers StartJobRun API operation.", Operation = new[] {"StartJobRun"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.StartJobRunResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.StartJobRunResponse",
        "This cmdlet returns an Amazon.EMRContainers.Model.StartJobRunResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartEMRCJobRunCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationOverrides_ApplicationConfiguration
        /// <summary>
        /// <para>
        /// <para>The configurations for the application running by the job run. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EMRContainers.Model.Configuration[] ConfigurationOverrides_ApplicationConfiguration { get; set; }
        #endregion
        
        #region Parameter SparkSqlJobDriver_EntryPoint
        /// <summary>
        /// <para>
        /// <para>The SQL file to be executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSqlJobDriver_EntryPoint")]
        public System.String SparkSqlJobDriver_EntryPoint { get; set; }
        #endregion
        
        #region Parameter SparkSubmitJobDriver_EntryPoint
        /// <summary>
        /// <para>
        /// <para>The entry point of job application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSubmitJobDriver_EntryPoint")]
        public System.String SparkSubmitJobDriver_EntryPoint { get; set; }
        #endregion
        
        #region Parameter SparkSubmitJobDriver_EntryPointArgument
        /// <summary>
        /// <para>
        /// <para>The arguments for job application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSubmitJobDriver_EntryPointArguments")]
        public System.String[] SparkSubmitJobDriver_EntryPointArgument { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role ARN for the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter JobTemplateId
        /// <summary>
        /// <para>
        /// <para>The job template ID to be used to start the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobTemplateId { get; set; }
        #endregion
        
        #region Parameter JobTemplateParameter
        /// <summary>
        /// <para>
        /// <para>The values of job template parameters to start a job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateParameters")]
        public System.Collections.Hashtable JobTemplateParameter { get; set; }
        #endregion
        
        #region Parameter CloudWatchMonitoringConfiguration_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group for log publishing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_LogGroupName")]
        public System.String CloudWatchMonitoringConfiguration_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchMonitoringConfiguration_LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>The specified name prefix for log streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_LogStreamNamePrefix")]
        public System.String CloudWatchMonitoringConfiguration_LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter S3MonitoringConfiguration_LogUri
        /// <summary>
        /// <para>
        /// <para>Amazon S3 destination URI for log publishing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_LogUri")]
        public System.String S3MonitoringConfiguration_LogUri { get; set; }
        #endregion
        
        #region Parameter RetryPolicyConfiguration_MaxAttempt
        /// <summary>
        /// <para>
        /// <para>The maximum number of attempts on the job's driver.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetryPolicyConfiguration_MaxAttempts")]
        public System.Int32? RetryPolicyConfiguration_MaxAttempt { get; set; }
        #endregion
        
        #region Parameter ContainerLogRotationConfiguration_MaxFilesToKeep
        /// <summary>
        /// <para>
        /// <para>The number of files to keep in container after rotation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_MaxFilesToKeep")]
        public System.Int32? ContainerLogRotationConfiguration_MaxFilesToKeep { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_PersistentAppUI
        /// <summary>
        /// <para>
        /// <para>Monitoring configurations for the persistent application UI. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_PersistentAppUI")]
        [AWSConstantClassSource("Amazon.EMRContainers.PersistentAppUI")]
        public Amazon.EMRContainers.PersistentAppUI MonitoringConfiguration_PersistentAppUI { get; set; }
        #endregion
        
        #region Parameter ReleaseLabel
        /// <summary>
        /// <para>
        /// <para>The Amazon EMR release version to use for the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseLabel { get; set; }
        #endregion
        
        #region Parameter ContainerLogRotationConfiguration_RotationSize
        /// <summary>
        /// <para>
        /// <para>The file size at which to rotate logs. Minimum of 2KB, Maximum of 2GB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_RotationSize")]
        public System.String ContainerLogRotationConfiguration_RotationSize { get; set; }
        #endregion
        
        #region Parameter SparkSqlJobDriver_SparkSqlParameter
        /// <summary>
        /// <para>
        /// <para>The Spark parameters to be included in the Spark SQL command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSqlJobDriver_SparkSqlParameters")]
        public System.String SparkSqlJobDriver_SparkSqlParameter { get; set; }
        #endregion
        
        #region Parameter SparkSubmitJobDriver_SparkSubmitParameter
        /// <summary>
        /// <para>
        /// <para>The Spark submit parameters that are used for job runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobDriver_SparkSubmitJobDriver_SparkSubmitParameters")]
        public System.String SparkSubmitJobDriver_SparkSubmitParameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to job runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VirtualClusterId
        /// <summary>
        /// <para>
        /// <para>The virtual cluster ID for which the job run request is submitted.</para>
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
        public System.String VirtualClusterId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client idempotency token of the job run request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.StartJobRunResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.StartJobRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VirtualClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VirtualClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VirtualClusterId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMRCJobRun (StartJobRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.StartJobRunResponse, StartEMRCJobRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VirtualClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.ConfigurationOverrides_ApplicationConfiguration != null)
            {
                context.ConfigurationOverrides_ApplicationConfiguration = new List<Amazon.EMRContainers.Model.Configuration>(this.ConfigurationOverrides_ApplicationConfiguration);
            }
            context.CloudWatchMonitoringConfiguration_LogGroupName = this.CloudWatchMonitoringConfiguration_LogGroupName;
            context.CloudWatchMonitoringConfiguration_LogStreamNamePrefix = this.CloudWatchMonitoringConfiguration_LogStreamNamePrefix;
            context.ContainerLogRotationConfiguration_MaxFilesToKeep = this.ContainerLogRotationConfiguration_MaxFilesToKeep;
            context.ContainerLogRotationConfiguration_RotationSize = this.ContainerLogRotationConfiguration_RotationSize;
            context.MonitoringConfiguration_PersistentAppUI = this.MonitoringConfiguration_PersistentAppUI;
            context.S3MonitoringConfiguration_LogUri = this.S3MonitoringConfiguration_LogUri;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.SparkSqlJobDriver_EntryPoint = this.SparkSqlJobDriver_EntryPoint;
            context.SparkSqlJobDriver_SparkSqlParameter = this.SparkSqlJobDriver_SparkSqlParameter;
            context.SparkSubmitJobDriver_EntryPoint = this.SparkSubmitJobDriver_EntryPoint;
            if (this.SparkSubmitJobDriver_EntryPointArgument != null)
            {
                context.SparkSubmitJobDriver_EntryPointArgument = new List<System.String>(this.SparkSubmitJobDriver_EntryPointArgument);
            }
            context.SparkSubmitJobDriver_SparkSubmitParameter = this.SparkSubmitJobDriver_SparkSubmitParameter;
            context.JobTemplateId = this.JobTemplateId;
            if (this.JobTemplateParameter != null)
            {
                context.JobTemplateParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.JobTemplateParameter.Keys)
                {
                    context.JobTemplateParameter.Add((String)hashKey, (String)(this.JobTemplateParameter[hashKey]));
                }
            }
            context.Name = this.Name;
            context.ReleaseLabel = this.ReleaseLabel;
            context.RetryPolicyConfiguration_MaxAttempt = this.RetryPolicyConfiguration_MaxAttempt;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.VirtualClusterId = this.VirtualClusterId;
            #if MODULAR
            if (this.VirtualClusterId == null && ParameterWasBound(nameof(this.VirtualClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EMRContainers.Model.StartJobRunRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConfigurationOverrides
            var requestConfigurationOverridesIsNull = true;
            request.ConfigurationOverrides = new Amazon.EMRContainers.Model.ConfigurationOverrides();
            List<Amazon.EMRContainers.Model.Configuration> requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration = null;
            if (cmdletContext.ConfigurationOverrides_ApplicationConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration = cmdletContext.ConfigurationOverrides_ApplicationConfiguration;
            }
            if (requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration != null)
            {
                request.ConfigurationOverrides.ApplicationConfiguration = requestConfigurationOverrides_configurationOverrides_ApplicationConfiguration;
                requestConfigurationOverridesIsNull = false;
            }
            Amazon.EMRContainers.Model.MonitoringConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration = null;
            
             // populate MonitoringConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration = new Amazon.EMRContainers.Model.MonitoringConfiguration();
            Amazon.EMRContainers.PersistentAppUI requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI = null;
            if (cmdletContext.MonitoringConfiguration_PersistentAppUI != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI = cmdletContext.MonitoringConfiguration_PersistentAppUI;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.PersistentAppUI = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = false;
            }
            Amazon.EMRContainers.Model.S3MonitoringConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = null;
            
             // populate S3MonitoringConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = new Amazon.EMRContainers.Model.S3MonitoringConfiguration();
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
            Amazon.EMRContainers.Model.CloudWatchMonitoringConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration = null;
            
             // populate CloudWatchMonitoringConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration = new Amazon.EMRContainers.Model.CloudWatchMonitoringConfiguration();
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName = null;
            if (cmdletContext.CloudWatchMonitoringConfiguration_LogGroupName != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName = cmdletContext.CloudWatchMonitoringConfiguration_LogGroupName;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration.LogGroupName = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix = null;
            if (cmdletContext.CloudWatchMonitoringConfiguration_LogStreamNamePrefix != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix = cmdletContext.CloudWatchMonitoringConfiguration_LogStreamNamePrefix;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration.LogStreamNamePrefix = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.CloudWatchMonitoringConfiguration = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfigurationIsNull = false;
            }
            Amazon.EMRContainers.Model.ContainerLogRotationConfiguration requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration = null;
            
             // populate ContainerLogRotationConfiguration
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfigurationIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration = new Amazon.EMRContainers.Model.ContainerLogRotationConfiguration();
            System.Int32? requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_MaxFilesToKeep = null;
            if (cmdletContext.ContainerLogRotationConfiguration_MaxFilesToKeep != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_MaxFilesToKeep = cmdletContext.ContainerLogRotationConfiguration_MaxFilesToKeep.Value;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_MaxFilesToKeep != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration.MaxFilesToKeep = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_MaxFilesToKeep.Value;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfigurationIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_RotationSize = null;
            if (cmdletContext.ContainerLogRotationConfiguration_RotationSize != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_RotationSize = cmdletContext.ContainerLogRotationConfiguration_RotationSize;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_RotationSize != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration.RotationSize = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration_containerLogRotationConfiguration_RotationSize;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfigurationIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfigurationIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.ContainerLogRotationConfiguration = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ContainerLogRotationConfiguration;
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
            
             // populate JobDriver
            var requestJobDriverIsNull = true;
            request.JobDriver = new Amazon.EMRContainers.Model.JobDriver();
            Amazon.EMRContainers.Model.SparkSqlJobDriver requestJobDriver_jobDriver_SparkSqlJobDriver = null;
            
             // populate SparkSqlJobDriver
            var requestJobDriver_jobDriver_SparkSqlJobDriverIsNull = true;
            requestJobDriver_jobDriver_SparkSqlJobDriver = new Amazon.EMRContainers.Model.SparkSqlJobDriver();
            System.String requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint = null;
            if (cmdletContext.SparkSqlJobDriver_EntryPoint != null)
            {
                requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint = cmdletContext.SparkSqlJobDriver_EntryPoint;
            }
            if (requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint != null)
            {
                requestJobDriver_jobDriver_SparkSqlJobDriver.EntryPoint = requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint;
                requestJobDriver_jobDriver_SparkSqlJobDriverIsNull = false;
            }
            System.String requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter = null;
            if (cmdletContext.SparkSqlJobDriver_SparkSqlParameter != null)
            {
                requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter = cmdletContext.SparkSqlJobDriver_SparkSqlParameter;
            }
            if (requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter != null)
            {
                requestJobDriver_jobDriver_SparkSqlJobDriver.SparkSqlParameters = requestJobDriver_jobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter;
                requestJobDriver_jobDriver_SparkSqlJobDriverIsNull = false;
            }
             // determine if requestJobDriver_jobDriver_SparkSqlJobDriver should be set to null
            if (requestJobDriver_jobDriver_SparkSqlJobDriverIsNull)
            {
                requestJobDriver_jobDriver_SparkSqlJobDriver = null;
            }
            if (requestJobDriver_jobDriver_SparkSqlJobDriver != null)
            {
                request.JobDriver.SparkSqlJobDriver = requestJobDriver_jobDriver_SparkSqlJobDriver;
                requestJobDriverIsNull = false;
            }
            Amazon.EMRContainers.Model.SparkSubmitJobDriver requestJobDriver_jobDriver_SparkSubmitJobDriver = null;
            
             // populate SparkSubmitJobDriver
            var requestJobDriver_jobDriver_SparkSubmitJobDriverIsNull = true;
            requestJobDriver_jobDriver_SparkSubmitJobDriver = new Amazon.EMRContainers.Model.SparkSubmitJobDriver();
            System.String requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint = null;
            if (cmdletContext.SparkSubmitJobDriver_EntryPoint != null)
            {
                requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint = cmdletContext.SparkSubmitJobDriver_EntryPoint;
            }
            if (requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint != null)
            {
                requestJobDriver_jobDriver_SparkSubmitJobDriver.EntryPoint = requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint;
                requestJobDriver_jobDriver_SparkSubmitJobDriverIsNull = false;
            }
            List<System.String> requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument = null;
            if (cmdletContext.SparkSubmitJobDriver_EntryPointArgument != null)
            {
                requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument = cmdletContext.SparkSubmitJobDriver_EntryPointArgument;
            }
            if (requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument != null)
            {
                requestJobDriver_jobDriver_SparkSubmitJobDriver.EntryPointArguments = requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument;
                requestJobDriver_jobDriver_SparkSubmitJobDriverIsNull = false;
            }
            System.String requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter = null;
            if (cmdletContext.SparkSubmitJobDriver_SparkSubmitParameter != null)
            {
                requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter = cmdletContext.SparkSubmitJobDriver_SparkSubmitParameter;
            }
            if (requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter != null)
            {
                requestJobDriver_jobDriver_SparkSubmitJobDriver.SparkSubmitParameters = requestJobDriver_jobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter;
                requestJobDriver_jobDriver_SparkSubmitJobDriverIsNull = false;
            }
             // determine if requestJobDriver_jobDriver_SparkSubmitJobDriver should be set to null
            if (requestJobDriver_jobDriver_SparkSubmitJobDriverIsNull)
            {
                requestJobDriver_jobDriver_SparkSubmitJobDriver = null;
            }
            if (requestJobDriver_jobDriver_SparkSubmitJobDriver != null)
            {
                request.JobDriver.SparkSubmitJobDriver = requestJobDriver_jobDriver_SparkSubmitJobDriver;
                requestJobDriverIsNull = false;
            }
             // determine if request.JobDriver should be set to null
            if (requestJobDriverIsNull)
            {
                request.JobDriver = null;
            }
            if (cmdletContext.JobTemplateId != null)
            {
                request.JobTemplateId = cmdletContext.JobTemplateId;
            }
            if (cmdletContext.JobTemplateParameter != null)
            {
                request.JobTemplateParameters = cmdletContext.JobTemplateParameter;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ReleaseLabel != null)
            {
                request.ReleaseLabel = cmdletContext.ReleaseLabel;
            }
            
             // populate RetryPolicyConfiguration
            var requestRetryPolicyConfigurationIsNull = true;
            request.RetryPolicyConfiguration = new Amazon.EMRContainers.Model.RetryPolicyConfiguration();
            System.Int32? requestRetryPolicyConfiguration_retryPolicyConfiguration_MaxAttempt = null;
            if (cmdletContext.RetryPolicyConfiguration_MaxAttempt != null)
            {
                requestRetryPolicyConfiguration_retryPolicyConfiguration_MaxAttempt = cmdletContext.RetryPolicyConfiguration_MaxAttempt.Value;
            }
            if (requestRetryPolicyConfiguration_retryPolicyConfiguration_MaxAttempt != null)
            {
                request.RetryPolicyConfiguration.MaxAttempts = requestRetryPolicyConfiguration_retryPolicyConfiguration_MaxAttempt.Value;
                requestRetryPolicyConfigurationIsNull = false;
            }
             // determine if request.RetryPolicyConfiguration should be set to null
            if (requestRetryPolicyConfigurationIsNull)
            {
                request.RetryPolicyConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VirtualClusterId != null)
            {
                request.VirtualClusterId = cmdletContext.VirtualClusterId;
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
        
        private Amazon.EMRContainers.Model.StartJobRunResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.StartJobRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "StartJobRun");
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
            public System.String ClientToken { get; set; }
            public List<Amazon.EMRContainers.Model.Configuration> ConfigurationOverrides_ApplicationConfiguration { get; set; }
            public System.String CloudWatchMonitoringConfiguration_LogGroupName { get; set; }
            public System.String CloudWatchMonitoringConfiguration_LogStreamNamePrefix { get; set; }
            public System.Int32? ContainerLogRotationConfiguration_MaxFilesToKeep { get; set; }
            public System.String ContainerLogRotationConfiguration_RotationSize { get; set; }
            public Amazon.EMRContainers.PersistentAppUI MonitoringConfiguration_PersistentAppUI { get; set; }
            public System.String S3MonitoringConfiguration_LogUri { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String SparkSqlJobDriver_EntryPoint { get; set; }
            public System.String SparkSqlJobDriver_SparkSqlParameter { get; set; }
            public System.String SparkSubmitJobDriver_EntryPoint { get; set; }
            public List<System.String> SparkSubmitJobDriver_EntryPointArgument { get; set; }
            public System.String SparkSubmitJobDriver_SparkSubmitParameter { get; set; }
            public System.String JobTemplateId { get; set; }
            public Dictionary<System.String, System.String> JobTemplateParameter { get; set; }
            public System.String Name { get; set; }
            public System.String ReleaseLabel { get; set; }
            public System.Int32? RetryPolicyConfiguration_MaxAttempt { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String VirtualClusterId { get; set; }
            public System.Func<Amazon.EMRContainers.Model.StartJobRunResponse, StartEMRCJobRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
