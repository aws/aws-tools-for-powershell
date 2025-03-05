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

namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Creates a managed endpoint. A managed endpoint is a gateway that connects Amazon EMR
    /// Studio to Amazon EMR on EKS so that Amazon EMR Studio can communicate with your virtual
    /// cluster.
    /// </summary>
    [Cmdlet("New", "EMRCManagedEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRContainers.Model.CreateManagedEndpointResponse")]
    [AWSCmdlet("Calls the Amazon EMR Containers CreateManagedEndpoint API operation.", Operation = new[] {"CreateManagedEndpoint"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.CreateManagedEndpointResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.CreateManagedEndpointResponse",
        "This cmdlet returns an Amazon.EMRContainers.Model.CreateManagedEndpointResponse object containing multiple properties."
    )]
    public partial class NewEMRCManagedEndpointCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ManagedLogs_AllowAWSToRetainLog
        /// <summary>
        /// <para>
        /// <para>Determines whether Amazon Web Services can retain logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_ManagedLogs_AllowAWSToRetainLogs")]
        [AWSConstantClassSource("Amazon.EMRContainers.AllowAWSToRetainLogs")]
        public Amazon.EMRContainers.AllowAWSToRetainLogs ManagedLogs_AllowAWSToRetainLog { get; set; }
        #endregion
        
        #region Parameter ConfigurationOverrides_ApplicationConfiguration
        /// <summary>
        /// <para>
        /// <para>The configurations for the application running by the job run. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EMRContainers.Model.Configuration[] ConfigurationOverrides_ApplicationConfiguration { get; set; }
        #endregion
        
        #region Parameter ManagedLogs_EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon resource name (ARN) of the encryption key for logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationOverrides_MonitoringConfiguration_ManagedLogs_EncryptionKeyArn")]
        public System.String ManagedLogs_EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the execution role.</para>
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
        /// <para>The name of the managed endpoint.</para>
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
        /// <para>The Amazon EMR release version.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags of the managed endpoint. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the managed endpoint.</para>
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
        
        #region Parameter VirtualClusterId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual cluster for which a managed endpoint is created.</para>
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
        public System.String VirtualClusterId { get; set; }
        #endregion
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>The certificate ARN provided by users for the managed endpoint. This field is under
        /// deprecation and will be removed in future releases.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Customer provided certificate-arn is deprecated and would be removed in future.")]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client idempotency token for this create call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.CreateManagedEndpointResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.CreateManagedEndpointResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRCManagedEndpoint (CreateManagedEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.CreateManagedEndpointResponse, NewEMRCManagedEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateArn = this.CertificateArn;
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
            context.ManagedLogs_AllowAWSToRetainLog = this.ManagedLogs_AllowAWSToRetainLog;
            context.ManagedLogs_EncryptionKeyArn = this.ManagedLogs_EncryptionKeyArn;
            context.MonitoringConfiguration_PersistentAppUI = this.MonitoringConfiguration_PersistentAppUI;
            context.S3MonitoringConfiguration_LogUri = this.S3MonitoringConfiguration_LogUri;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReleaseLabel = this.ReleaseLabel;
            #if MODULAR
            if (this.ReleaseLabel == null && ParameterWasBound(nameof(this.ReleaseLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter ReleaseLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.EMRContainers.Model.CreateManagedEndpointRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            Amazon.EMRContainers.Model.ManagedLogs requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs = null;
            
             // populate ManagedLogs
            var requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogsIsNull = true;
            requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs = new Amazon.EMRContainers.Model.ManagedLogs();
            Amazon.EMRContainers.AllowAWSToRetainLogs requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_AllowAWSToRetainLog = null;
            if (cmdletContext.ManagedLogs_AllowAWSToRetainLog != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_AllowAWSToRetainLog = cmdletContext.ManagedLogs_AllowAWSToRetainLog;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_AllowAWSToRetainLog != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs.AllowAWSToRetainLogs = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_AllowAWSToRetainLog;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogsIsNull = false;
            }
            System.String requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_EncryptionKeyArn = null;
            if (cmdletContext.ManagedLogs_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_EncryptionKeyArn = cmdletContext.ManagedLogs_EncryptionKeyArn;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_EncryptionKeyArn != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs.EncryptionKeyArn = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs_managedLogs_EncryptionKeyArn;
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogsIsNull = false;
            }
             // determine if requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs should be set to null
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogsIsNull)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs = null;
            }
            if (requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs != null)
            {
                requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration.ManagedLogs = requestConfigurationOverrides_configurationOverrides_MonitoringConfiguration_configurationOverrides_MonitoringConfiguration_ManagedLogs;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ReleaseLabel != null)
            {
                request.ReleaseLabel = cmdletContext.ReleaseLabel;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.EMRContainers.Model.CreateManagedEndpointResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.CreateManagedEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "CreateManagedEndpoint");
            try
            {
                return client.CreateManagedEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public System.String CertificateArn { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.EMRContainers.Model.Configuration> ConfigurationOverrides_ApplicationConfiguration { get; set; }
            public System.String CloudWatchMonitoringConfiguration_LogGroupName { get; set; }
            public System.String CloudWatchMonitoringConfiguration_LogStreamNamePrefix { get; set; }
            public System.Int32? ContainerLogRotationConfiguration_MaxFilesToKeep { get; set; }
            public System.String ContainerLogRotationConfiguration_RotationSize { get; set; }
            public Amazon.EMRContainers.AllowAWSToRetainLogs ManagedLogs_AllowAWSToRetainLog { get; set; }
            public System.String ManagedLogs_EncryptionKeyArn { get; set; }
            public Amazon.EMRContainers.PersistentAppUI MonitoringConfiguration_PersistentAppUI { get; set; }
            public System.String S3MonitoringConfiguration_LogUri { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String Name { get; set; }
            public System.String ReleaseLabel { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Type { get; set; }
            public System.String VirtualClusterId { get; set; }
            public System.Func<Amazon.EMRContainers.Model.CreateManagedEndpointResponse, NewEMRCManagedEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
