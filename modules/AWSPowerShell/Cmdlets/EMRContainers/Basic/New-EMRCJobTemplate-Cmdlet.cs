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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Creates a job template. Job template stores values of StartJobRun API request in a
    /// template and can be used to start a job run. Job template allows two use cases: avoid
    /// repeating recurring StartJobRun API request values, enforcing certain values in StartJobRun
    /// API request.
    /// </summary>
    [Cmdlet("New", "EMRCJobTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRContainers.Model.CreateJobTemplateResponse")]
    [AWSCmdlet("Calls the Amazon EMR Containers CreateJobTemplate API operation.", Operation = new[] {"CreateJobTemplate"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.CreateJobTemplateResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.CreateJobTemplateResponse",
        "This cmdlet returns an Amazon.EMRContainers.Model.CreateJobTemplateResponse object containing multiple properties."
    )]
    public partial class NewEMRCJobTemplateCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationOverrides_ApplicationConfiguration
        /// <summary>
        /// <para>
        /// <para> The configurations for the application running by the job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_ConfigurationOverrides_ApplicationConfiguration")]
        public Amazon.EMRContainers.Model.Configuration[] ConfigurationOverrides_ApplicationConfiguration { get; set; }
        #endregion
        
        #region Parameter SparkSqlJobDriver_EntryPoint
        /// <summary>
        /// <para>
        /// <para>The SQL file to be executed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_JobDriver_SparkSqlJobDriver_EntryPoint")]
        public System.String SparkSqlJobDriver_EntryPoint { get; set; }
        #endregion
        
        #region Parameter SparkSubmitJobDriver_EntryPoint
        /// <summary>
        /// <para>
        /// <para>The entry point of job application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_JobDriver_SparkSubmitJobDriver_EntryPoint")]
        public System.String SparkSubmitJobDriver_EntryPoint { get; set; }
        #endregion
        
        #region Parameter SparkSubmitJobDriver_EntryPointArgument
        /// <summary>
        /// <para>
        /// <para>The arguments for job application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_JobDriver_SparkSubmitJobDriver_EntryPointArguments")]
        public System.String[] SparkSubmitJobDriver_EntryPointArgument { get; set; }
        #endregion
        
        #region Parameter JobTemplateData_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role ARN of the job run.</para>
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
        public System.String JobTemplateData_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter JobTemplateData_JobTag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to jobs started using the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_JobTags")]
        public System.Collections.Hashtable JobTemplateData_JobTag { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The KMS key ARN used to encrypt the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchMonitoringConfiguration_LogGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the log group for log publishing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_LogGroupName")]
        public System.String CloudWatchMonitoringConfiguration_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchMonitoringConfiguration_LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para> The specified name prefix for log streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_LogStreamNamePrefix")]
        public System.String CloudWatchMonitoringConfiguration_LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter S3MonitoringConfiguration_LogUri
        /// <summary>
        /// <para>
        /// <para>Amazon S3 destination URI for log publishing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_LogUri")]
        public System.String S3MonitoringConfiguration_LogUri { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The specified name of the job template.</para>
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
        
        #region Parameter JobTemplateData_ParameterConfiguration
        /// <summary>
        /// <para>
        /// <para>The configuration of parameters existing in the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable JobTemplateData_ParameterConfiguration { get; set; }
        #endregion
        
        #region Parameter MonitoringConfiguration_PersistentAppUI
        /// <summary>
        /// <para>
        /// <para> Monitoring configurations for the persistent application UI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_ConfigurationOverrides_MonitoringConfiguration_PersistentAppUI")]
        public System.String MonitoringConfiguration_PersistentAppUI { get; set; }
        #endregion
        
        #region Parameter JobTemplateData_ReleaseLabel
        /// <summary>
        /// <para>
        /// <para> The release version of Amazon EMR.</para>
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
        public System.String JobTemplateData_ReleaseLabel { get; set; }
        #endregion
        
        #region Parameter SparkSqlJobDriver_SparkSqlParameter
        /// <summary>
        /// <para>
        /// <para>The Spark parameters to be included in the Spark SQL command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_JobDriver_SparkSqlJobDriver_SparkSqlParameters")]
        public System.String SparkSqlJobDriver_SparkSqlParameter { get; set; }
        #endregion
        
        #region Parameter SparkSubmitJobDriver_SparkSubmitParameter
        /// <summary>
        /// <para>
        /// <para>The Spark submit parameters that are used for job runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobTemplateData_JobDriver_SparkSubmitJobDriver_SparkSubmitParameters")]
        public System.String SparkSubmitJobDriver_SparkSubmitParameter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that are associated with the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token of the job template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.CreateJobTemplateResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.CreateJobTemplateResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRCJobTemplate (CreateJobTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.CreateJobTemplateResponse, NewEMRCJobTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ConfigurationOverrides_ApplicationConfiguration != null)
            {
                context.ConfigurationOverrides_ApplicationConfiguration = new List<Amazon.EMRContainers.Model.Configuration>(this.ConfigurationOverrides_ApplicationConfiguration);
            }
            context.CloudWatchMonitoringConfiguration_LogGroupName = this.CloudWatchMonitoringConfiguration_LogGroupName;
            context.CloudWatchMonitoringConfiguration_LogStreamNamePrefix = this.CloudWatchMonitoringConfiguration_LogStreamNamePrefix;
            context.MonitoringConfiguration_PersistentAppUI = this.MonitoringConfiguration_PersistentAppUI;
            context.S3MonitoringConfiguration_LogUri = this.S3MonitoringConfiguration_LogUri;
            context.JobTemplateData_ExecutionRoleArn = this.JobTemplateData_ExecutionRoleArn;
            #if MODULAR
            if (this.JobTemplateData_ExecutionRoleArn == null && ParameterWasBound(nameof(this.JobTemplateData_ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter JobTemplateData_ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SparkSqlJobDriver_EntryPoint = this.SparkSqlJobDriver_EntryPoint;
            context.SparkSqlJobDriver_SparkSqlParameter = this.SparkSqlJobDriver_SparkSqlParameter;
            context.SparkSubmitJobDriver_EntryPoint = this.SparkSubmitJobDriver_EntryPoint;
            if (this.SparkSubmitJobDriver_EntryPointArgument != null)
            {
                context.SparkSubmitJobDriver_EntryPointArgument = new List<System.String>(this.SparkSubmitJobDriver_EntryPointArgument);
            }
            context.SparkSubmitJobDriver_SparkSubmitParameter = this.SparkSubmitJobDriver_SparkSubmitParameter;
            if (this.JobTemplateData_JobTag != null)
            {
                context.JobTemplateData_JobTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.JobTemplateData_JobTag.Keys)
                {
                    context.JobTemplateData_JobTag.Add((String)hashKey, (System.String)(this.JobTemplateData_JobTag[hashKey]));
                }
            }
            if (this.JobTemplateData_ParameterConfiguration != null)
            {
                context.JobTemplateData_ParameterConfiguration = new Dictionary<System.String, Amazon.EMRContainers.Model.TemplateParameterConfiguration>(StringComparer.Ordinal);
                foreach (var hashKey in this.JobTemplateData_ParameterConfiguration.Keys)
                {
                    context.JobTemplateData_ParameterConfiguration.Add((String)hashKey, (Amazon.EMRContainers.Model.TemplateParameterConfiguration)(this.JobTemplateData_ParameterConfiguration[hashKey]));
                }
            }
            context.JobTemplateData_ReleaseLabel = this.JobTemplateData_ReleaseLabel;
            #if MODULAR
            if (this.JobTemplateData_ReleaseLabel == null && ParameterWasBound(nameof(this.JobTemplateData_ReleaseLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter JobTemplateData_ReleaseLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.EMRContainers.Model.CreateJobTemplateRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate JobTemplateData
            var requestJobTemplateDataIsNull = true;
            request.JobTemplateData = new Amazon.EMRContainers.Model.JobTemplateData();
            System.String requestJobTemplateData_jobTemplateData_ExecutionRoleArn = null;
            if (cmdletContext.JobTemplateData_ExecutionRoleArn != null)
            {
                requestJobTemplateData_jobTemplateData_ExecutionRoleArn = cmdletContext.JobTemplateData_ExecutionRoleArn;
            }
            if (requestJobTemplateData_jobTemplateData_ExecutionRoleArn != null)
            {
                request.JobTemplateData.ExecutionRoleArn = requestJobTemplateData_jobTemplateData_ExecutionRoleArn;
                requestJobTemplateDataIsNull = false;
            }
            Dictionary<System.String, System.String> requestJobTemplateData_jobTemplateData_JobTag = null;
            if (cmdletContext.JobTemplateData_JobTag != null)
            {
                requestJobTemplateData_jobTemplateData_JobTag = cmdletContext.JobTemplateData_JobTag;
            }
            if (requestJobTemplateData_jobTemplateData_JobTag != null)
            {
                request.JobTemplateData.JobTags = requestJobTemplateData_jobTemplateData_JobTag;
                requestJobTemplateDataIsNull = false;
            }
            Dictionary<System.String, Amazon.EMRContainers.Model.TemplateParameterConfiguration> requestJobTemplateData_jobTemplateData_ParameterConfiguration = null;
            if (cmdletContext.JobTemplateData_ParameterConfiguration != null)
            {
                requestJobTemplateData_jobTemplateData_ParameterConfiguration = cmdletContext.JobTemplateData_ParameterConfiguration;
            }
            if (requestJobTemplateData_jobTemplateData_ParameterConfiguration != null)
            {
                request.JobTemplateData.ParameterConfiguration = requestJobTemplateData_jobTemplateData_ParameterConfiguration;
                requestJobTemplateDataIsNull = false;
            }
            System.String requestJobTemplateData_jobTemplateData_ReleaseLabel = null;
            if (cmdletContext.JobTemplateData_ReleaseLabel != null)
            {
                requestJobTemplateData_jobTemplateData_ReleaseLabel = cmdletContext.JobTemplateData_ReleaseLabel;
            }
            if (requestJobTemplateData_jobTemplateData_ReleaseLabel != null)
            {
                request.JobTemplateData.ReleaseLabel = requestJobTemplateData_jobTemplateData_ReleaseLabel;
                requestJobTemplateDataIsNull = false;
            }
            Amazon.EMRContainers.Model.ParametricConfigurationOverrides requestJobTemplateData_jobTemplateData_ConfigurationOverrides = null;
            
             // populate ConfigurationOverrides
            var requestJobTemplateData_jobTemplateData_ConfigurationOverridesIsNull = true;
            requestJobTemplateData_jobTemplateData_ConfigurationOverrides = new Amazon.EMRContainers.Model.ParametricConfigurationOverrides();
            List<Amazon.EMRContainers.Model.Configuration> requestJobTemplateData_jobTemplateData_ConfigurationOverrides_configurationOverrides_ApplicationConfiguration = null;
            if (cmdletContext.ConfigurationOverrides_ApplicationConfiguration != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_configurationOverrides_ApplicationConfiguration = cmdletContext.ConfigurationOverrides_ApplicationConfiguration;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_configurationOverrides_ApplicationConfiguration != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides.ApplicationConfiguration = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_configurationOverrides_ApplicationConfiguration;
                requestJobTemplateData_jobTemplateData_ConfigurationOverridesIsNull = false;
            }
            Amazon.EMRContainers.Model.ParametricMonitoringConfiguration requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration = null;
            
             // populate MonitoringConfiguration
            var requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfigurationIsNull = true;
            requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration = new Amazon.EMRContainers.Model.ParametricMonitoringConfiguration();
            System.String requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI = null;
            if (cmdletContext.MonitoringConfiguration_PersistentAppUI != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI = cmdletContext.MonitoringConfiguration_PersistentAppUI;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration.PersistentAppUI = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_monitoringConfiguration_PersistentAppUI;
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfigurationIsNull = false;
            }
            Amazon.EMRContainers.Model.ParametricS3MonitoringConfiguration requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = null;
            
             // populate S3MonitoringConfiguration
            var requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull = true;
            requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = new Amazon.EMRContainers.Model.ParametricS3MonitoringConfiguration();
            System.String requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri = null;
            if (cmdletContext.S3MonitoringConfiguration_LogUri != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri = cmdletContext.S3MonitoringConfiguration_LogUri;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration.LogUri = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration_s3MonitoringConfiguration_LogUri;
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull = false;
            }
             // determine if requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration should be set to null
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfigurationIsNull)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration = null;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration.S3MonitoringConfiguration = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_S3MonitoringConfiguration;
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfigurationIsNull = false;
            }
            Amazon.EMRContainers.Model.ParametricCloudWatchMonitoringConfiguration requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration = null;
            
             // populate CloudWatchMonitoringConfiguration
            var requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull = true;
            requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration = new Amazon.EMRContainers.Model.ParametricCloudWatchMonitoringConfiguration();
            System.String requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName = null;
            if (cmdletContext.CloudWatchMonitoringConfiguration_LogGroupName != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName = cmdletContext.CloudWatchMonitoringConfiguration_LogGroupName;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration.LogGroupName = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogGroupName;
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull = false;
            }
            System.String requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix = null;
            if (cmdletContext.CloudWatchMonitoringConfiguration_LogStreamNamePrefix != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix = cmdletContext.CloudWatchMonitoringConfiguration_LogStreamNamePrefix;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration.LogStreamNamePrefix = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration_cloudWatchMonitoringConfiguration_LogStreamNamePrefix;
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull = false;
            }
             // determine if requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration should be set to null
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfigurationIsNull)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration = null;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration.CloudWatchMonitoringConfiguration = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration_CloudWatchMonitoringConfiguration;
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfigurationIsNull = false;
            }
             // determine if requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration should be set to null
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfigurationIsNull)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration = null;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration != null)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides.MonitoringConfiguration = requestJobTemplateData_jobTemplateData_ConfigurationOverrides_jobTemplateData_ConfigurationOverrides_MonitoringConfiguration;
                requestJobTemplateData_jobTemplateData_ConfigurationOverridesIsNull = false;
            }
             // determine if requestJobTemplateData_jobTemplateData_ConfigurationOverrides should be set to null
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverridesIsNull)
            {
                requestJobTemplateData_jobTemplateData_ConfigurationOverrides = null;
            }
            if (requestJobTemplateData_jobTemplateData_ConfigurationOverrides != null)
            {
                request.JobTemplateData.ConfigurationOverrides = requestJobTemplateData_jobTemplateData_ConfigurationOverrides;
                requestJobTemplateDataIsNull = false;
            }
            Amazon.EMRContainers.Model.JobDriver requestJobTemplateData_jobTemplateData_JobDriver = null;
            
             // populate JobDriver
            var requestJobTemplateData_jobTemplateData_JobDriverIsNull = true;
            requestJobTemplateData_jobTemplateData_JobDriver = new Amazon.EMRContainers.Model.JobDriver();
            Amazon.EMRContainers.Model.SparkSqlJobDriver requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver = null;
            
             // populate SparkSqlJobDriver
            var requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriverIsNull = true;
            requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver = new Amazon.EMRContainers.Model.SparkSqlJobDriver();
            System.String requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint = null;
            if (cmdletContext.SparkSqlJobDriver_EntryPoint != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint = cmdletContext.SparkSqlJobDriver_EntryPoint;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver.EntryPoint = requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_EntryPoint;
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriverIsNull = false;
            }
            System.String requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter = null;
            if (cmdletContext.SparkSqlJobDriver_SparkSqlParameter != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter = cmdletContext.SparkSqlJobDriver_SparkSqlParameter;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver.SparkSqlParameters = requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver_sparkSqlJobDriver_SparkSqlParameter;
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriverIsNull = false;
            }
             // determine if requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver should be set to null
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriverIsNull)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver = null;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver.SparkSqlJobDriver = requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSqlJobDriver;
                requestJobTemplateData_jobTemplateData_JobDriverIsNull = false;
            }
            Amazon.EMRContainers.Model.SparkSubmitJobDriver requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver = null;
            
             // populate SparkSubmitJobDriver
            var requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriverIsNull = true;
            requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver = new Amazon.EMRContainers.Model.SparkSubmitJobDriver();
            System.String requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint = null;
            if (cmdletContext.SparkSubmitJobDriver_EntryPoint != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint = cmdletContext.SparkSubmitJobDriver_EntryPoint;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver.EntryPoint = requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPoint;
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriverIsNull = false;
            }
            List<System.String> requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument = null;
            if (cmdletContext.SparkSubmitJobDriver_EntryPointArgument != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument = cmdletContext.SparkSubmitJobDriver_EntryPointArgument;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver.EntryPointArguments = requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_EntryPointArgument;
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriverIsNull = false;
            }
            System.String requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter = null;
            if (cmdletContext.SparkSubmitJobDriver_SparkSubmitParameter != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter = cmdletContext.SparkSubmitJobDriver_SparkSubmitParameter;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver.SparkSubmitParameters = requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver_sparkSubmitJobDriver_SparkSubmitParameter;
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriverIsNull = false;
            }
             // determine if requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver should be set to null
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriverIsNull)
            {
                requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver = null;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver != null)
            {
                requestJobTemplateData_jobTemplateData_JobDriver.SparkSubmitJobDriver = requestJobTemplateData_jobTemplateData_JobDriver_jobTemplateData_JobDriver_SparkSubmitJobDriver;
                requestJobTemplateData_jobTemplateData_JobDriverIsNull = false;
            }
             // determine if requestJobTemplateData_jobTemplateData_JobDriver should be set to null
            if (requestJobTemplateData_jobTemplateData_JobDriverIsNull)
            {
                requestJobTemplateData_jobTemplateData_JobDriver = null;
            }
            if (requestJobTemplateData_jobTemplateData_JobDriver != null)
            {
                request.JobTemplateData.JobDriver = requestJobTemplateData_jobTemplateData_JobDriver;
                requestJobTemplateDataIsNull = false;
            }
             // determine if request.JobTemplateData should be set to null
            if (requestJobTemplateDataIsNull)
            {
                request.JobTemplateData = null;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.EMRContainers.Model.CreateJobTemplateResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.CreateJobTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "CreateJobTemplate");
            try
            {
                return client.CreateJobTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MonitoringConfiguration_PersistentAppUI { get; set; }
            public System.String S3MonitoringConfiguration_LogUri { get; set; }
            public System.String JobTemplateData_ExecutionRoleArn { get; set; }
            public System.String SparkSqlJobDriver_EntryPoint { get; set; }
            public System.String SparkSqlJobDriver_SparkSqlParameter { get; set; }
            public System.String SparkSubmitJobDriver_EntryPoint { get; set; }
            public List<System.String> SparkSubmitJobDriver_EntryPointArgument { get; set; }
            public System.String SparkSubmitJobDriver_SparkSubmitParameter { get; set; }
            public Dictionary<System.String, System.String> JobTemplateData_JobTag { get; set; }
            public Dictionary<System.String, Amazon.EMRContainers.Model.TemplateParameterConfiguration> JobTemplateData_ParameterConfiguration { get; set; }
            public System.String JobTemplateData_ReleaseLabel { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.EMRContainers.Model.CreateJobTemplateResponse, NewEMRCJobTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
