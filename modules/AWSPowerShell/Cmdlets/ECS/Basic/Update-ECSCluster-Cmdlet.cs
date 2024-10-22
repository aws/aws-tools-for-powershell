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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Updates the cluster.
    /// </summary>
    [Cmdlet("Update", "ECSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateCluster API operation.", Operation = new[] {"UpdateCluster"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateClusterResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Cluster or Amazon.ECS.Model.UpdateClusterResponse",
        "This cmdlet returns an Amazon.ECS.Model.Cluster object.",
        "The service call response (type Amazon.ECS.Model.UpdateClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateECSClusterCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogConfiguration_CloudWatchEncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>Determines whether to use encryption on the CloudWatch logs. If not specified, encryption
        /// will be off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ExecuteCommandConfiguration_LogConfiguration_CloudWatchEncryptionEnabled")]
        public System.Boolean? LogConfiguration_CloudWatchEncryptionEnabled { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_CloudWatchLogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch log group to send logs to.</para><note><para>The CloudWatch log group must already be created.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ExecuteCommandConfiguration_LogConfiguration_CloudWatchLogGroupName")]
        public System.String LogConfiguration_CloudWatchLogGroupName { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The name of the cluster to modify the settings for.</para>
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
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId
        /// <summary>
        /// <para>
        /// <para>Specify the Key Management Service key ID for the Fargate ephemeral storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId")]
        public System.String ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ExecuteCommandConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Specify an Key Management Service key ID to encrypt the data between the local client
        /// and the container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ExecuteCommandConfiguration_KmsKeyId")]
        public System.String ExecuteCommandConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ManagedStorageConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Specify a Key Management Service key ID to encrypt the managed storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManagedStorageConfiguration_KmsKeyId")]
        public System.String ManagedStorageConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ExecuteCommandConfiguration_Logging
        /// <summary>
        /// <para>
        /// <para>The log setting to use for redirecting logs for your execute command results. The
        /// following log settings are available.</para><ul><li><para><c>NONE</c>: The execute command session is not logged.</para></li><li><para><c>DEFAULT</c>: The <c>awslogs</c> configuration in the task definition is used.
        /// If no logging parameter is specified, it defaults to this value. If no <c>awslogs</c>
        /// log driver is configured in the task definition, the output won't be logged.</para></li><li><para><c>OVERRIDE</c>: Specify the logging details as a part of <c>logConfiguration</c>.
        /// If the <c>OVERRIDE</c> logging option is specified, the <c>logConfiguration</c> is
        /// required.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ExecuteCommandConfiguration_Logging")]
        [AWSConstantClassSource("Amazon.ECS.ExecuteCommandLogging")]
        public Amazon.ECS.ExecuteCommandLogging ExecuteCommandConfiguration_Logging { get; set; }
        #endregion
        
        #region Parameter ServiceConnectDefaults_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace name or full Amazon Resource Name (ARN) of the Cloud Map namespace that's
        /// used when you create a service and don't specify a Service Connect configuration.
        /// The namespace name can include up to 1024 characters. The name is case-sensitive.
        /// The name can't include hyphens (-), tilde (~), greater than (&gt;), less than (&lt;),
        /// or slash (/).</para><para>If you enter an existing namespace name or ARN, then that namespace will be used.
        /// Any namespace type is supported. The namespace must be in this account and this Amazon
        /// Web Services Region.</para><para>If you enter a new name, a Cloud Map namespace will be created. Amazon ECS creates
        /// a Cloud Map namespace with the "API calls" method of instance discovery only. This
        /// instance discovery method is the "HTTP" namespace type in the Command Line Interface.
        /// Other types of instance discovery aren't used by Service Connect.</para><para>If you update the cluster with an empty string <c>""</c> for the namespace name, the
        /// cluster configuration for Service Connect is removed. Note that the namespace will
        /// remain in Cloud Map and must be deleted separately.</para><para>For more information about Cloud Map, see <a href="https://docs.aws.amazon.com/cloud-map/latest/dg/working-with-services.html">Working
        /// with Services</a> in the <i>Cloud Map Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceConnectDefaults_Namespace { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket to send logs to.</para><note><para>The S3 bucket must already be created.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ExecuteCommandConfiguration_LogConfiguration_S3BucketName")]
        public System.String LogConfiguration_S3BucketName { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_S3EncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>Determines whether to use encryption on the S3 logs. If not specified, encryption
        /// is not used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ExecuteCommandConfiguration_LogConfiguration_S3EncryptionEnabled")]
        public System.Boolean? LogConfiguration_S3EncryptionEnabled { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>An optional folder in the S3 bucket to place logs in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ExecuteCommandConfiguration_LogConfiguration_S3KeyPrefix")]
        public System.String LogConfiguration_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Setting
        /// <summary>
        /// <para>
        /// <para>The cluster settings for your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings")]
        public Amazon.ECS.Model.ClusterSetting[] Setting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateClusterResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSCluster (UpdateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateClusterResponse, UpdateECSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Cluster = this.Cluster;
            #if MODULAR
            if (this.Cluster == null && ParameterWasBound(nameof(this.Cluster)))
            {
                WriteWarning("You are passing $null as a value for parameter Cluster which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecuteCommandConfiguration_KmsKeyId = this.ExecuteCommandConfiguration_KmsKeyId;
            context.LogConfiguration_CloudWatchEncryptionEnabled = this.LogConfiguration_CloudWatchEncryptionEnabled;
            context.LogConfiguration_CloudWatchLogGroupName = this.LogConfiguration_CloudWatchLogGroupName;
            context.LogConfiguration_S3BucketName = this.LogConfiguration_S3BucketName;
            context.LogConfiguration_S3EncryptionEnabled = this.LogConfiguration_S3EncryptionEnabled;
            context.LogConfiguration_S3KeyPrefix = this.LogConfiguration_S3KeyPrefix;
            context.ExecuteCommandConfiguration_Logging = this.ExecuteCommandConfiguration_Logging;
            context.ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId = this.ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId;
            context.ManagedStorageConfiguration_KmsKeyId = this.ManagedStorageConfiguration_KmsKeyId;
            context.ServiceConnectDefaults_Namespace = this.ServiceConnectDefaults_Namespace;
            if (this.Setting != null)
            {
                context.Setting = new List<Amazon.ECS.Model.ClusterSetting>(this.Setting);
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
            var request = new Amazon.ECS.Model.UpdateClusterRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.ECS.Model.ClusterConfiguration();
            Amazon.ECS.Model.ManagedStorageConfiguration requestConfiguration_configuration_ManagedStorageConfiguration = null;
            
             // populate ManagedStorageConfiguration
            var requestConfiguration_configuration_ManagedStorageConfigurationIsNull = true;
            requestConfiguration_configuration_ManagedStorageConfiguration = new Amazon.ECS.Model.ManagedStorageConfiguration();
            System.String requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_FargateEphemeralStorageKmsKeyId = null;
            if (cmdletContext.ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId != null)
            {
                requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_FargateEphemeralStorageKmsKeyId = cmdletContext.ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId;
            }
            if (requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_FargateEphemeralStorageKmsKeyId != null)
            {
                requestConfiguration_configuration_ManagedStorageConfiguration.FargateEphemeralStorageKmsKeyId = requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_FargateEphemeralStorageKmsKeyId;
                requestConfiguration_configuration_ManagedStorageConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_KmsKeyId = null;
            if (cmdletContext.ManagedStorageConfiguration_KmsKeyId != null)
            {
                requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_KmsKeyId = cmdletContext.ManagedStorageConfiguration_KmsKeyId;
            }
            if (requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_KmsKeyId != null)
            {
                requestConfiguration_configuration_ManagedStorageConfiguration.KmsKeyId = requestConfiguration_configuration_ManagedStorageConfiguration_managedStorageConfiguration_KmsKeyId;
                requestConfiguration_configuration_ManagedStorageConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ManagedStorageConfiguration should be set to null
            if (requestConfiguration_configuration_ManagedStorageConfigurationIsNull)
            {
                requestConfiguration_configuration_ManagedStorageConfiguration = null;
            }
            if (requestConfiguration_configuration_ManagedStorageConfiguration != null)
            {
                request.Configuration.ManagedStorageConfiguration = requestConfiguration_configuration_ManagedStorageConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.ECS.Model.ExecuteCommandConfiguration requestConfiguration_configuration_ExecuteCommandConfiguration = null;
            
             // populate ExecuteCommandConfiguration
            var requestConfiguration_configuration_ExecuteCommandConfigurationIsNull = true;
            requestConfiguration_configuration_ExecuteCommandConfiguration = new Amazon.ECS.Model.ExecuteCommandConfiguration();
            System.String requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_KmsKeyId = null;
            if (cmdletContext.ExecuteCommandConfiguration_KmsKeyId != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_KmsKeyId = cmdletContext.ExecuteCommandConfiguration_KmsKeyId;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_KmsKeyId != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration.KmsKeyId = requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_KmsKeyId;
                requestConfiguration_configuration_ExecuteCommandConfigurationIsNull = false;
            }
            Amazon.ECS.ExecuteCommandLogging requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_Logging = null;
            if (cmdletContext.ExecuteCommandConfiguration_Logging != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_Logging = cmdletContext.ExecuteCommandConfiguration_Logging;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_Logging != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration.Logging = requestConfiguration_configuration_ExecuteCommandConfiguration_executeCommandConfiguration_Logging;
                requestConfiguration_configuration_ExecuteCommandConfigurationIsNull = false;
            }
            Amazon.ECS.Model.ExecuteCommandLogConfiguration requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration = null;
            
             // populate LogConfiguration
            var requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfigurationIsNull = true;
            requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration = new Amazon.ECS.Model.ExecuteCommandLogConfiguration();
            System.Boolean? requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchEncryptionEnabled = null;
            if (cmdletContext.LogConfiguration_CloudWatchEncryptionEnabled != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchEncryptionEnabled = cmdletContext.LogConfiguration_CloudWatchEncryptionEnabled.Value;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchEncryptionEnabled != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration.CloudWatchEncryptionEnabled = requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchEncryptionEnabled.Value;
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchLogGroupName = null;
            if (cmdletContext.LogConfiguration_CloudWatchLogGroupName != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchLogGroupName = cmdletContext.LogConfiguration_CloudWatchLogGroupName;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchLogGroupName != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration.CloudWatchLogGroupName = requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_CloudWatchLogGroupName;
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3BucketName = null;
            if (cmdletContext.LogConfiguration_S3BucketName != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3BucketName = cmdletContext.LogConfiguration_S3BucketName;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3BucketName != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration.S3BucketName = requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3BucketName;
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3EncryptionEnabled = null;
            if (cmdletContext.LogConfiguration_S3EncryptionEnabled != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3EncryptionEnabled = cmdletContext.LogConfiguration_S3EncryptionEnabled.Value;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3EncryptionEnabled != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration.S3EncryptionEnabled = requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3EncryptionEnabled.Value;
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3KeyPrefix = null;
            if (cmdletContext.LogConfiguration_S3KeyPrefix != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3KeyPrefix = cmdletContext.LogConfiguration_S3KeyPrefix;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3KeyPrefix != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration.S3KeyPrefix = requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration_logConfiguration_S3KeyPrefix;
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration should be set to null
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfigurationIsNull)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration = null;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration != null)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration.LogConfiguration = requestConfiguration_configuration_ExecuteCommandConfiguration_configuration_ExecuteCommandConfiguration_LogConfiguration;
                requestConfiguration_configuration_ExecuteCommandConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ExecuteCommandConfiguration should be set to null
            if (requestConfiguration_configuration_ExecuteCommandConfigurationIsNull)
            {
                requestConfiguration_configuration_ExecuteCommandConfiguration = null;
            }
            if (requestConfiguration_configuration_ExecuteCommandConfiguration != null)
            {
                request.Configuration.ExecuteCommandConfiguration = requestConfiguration_configuration_ExecuteCommandConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            
             // populate ServiceConnectDefaults
            var requestServiceConnectDefaultsIsNull = true;
            request.ServiceConnectDefaults = new Amazon.ECS.Model.ClusterServiceConnectDefaultsRequest();
            System.String requestServiceConnectDefaults_serviceConnectDefaults_Namespace = null;
            if (cmdletContext.ServiceConnectDefaults_Namespace != null)
            {
                requestServiceConnectDefaults_serviceConnectDefaults_Namespace = cmdletContext.ServiceConnectDefaults_Namespace;
            }
            if (requestServiceConnectDefaults_serviceConnectDefaults_Namespace != null)
            {
                request.ServiceConnectDefaults.Namespace = requestServiceConnectDefaults_serviceConnectDefaults_Namespace;
                requestServiceConnectDefaultsIsNull = false;
            }
             // determine if request.ServiceConnectDefaults should be set to null
            if (requestServiceConnectDefaultsIsNull)
            {
                request.ServiceConnectDefaults = null;
            }
            if (cmdletContext.Setting != null)
            {
                request.Settings = cmdletContext.Setting;
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
        
        private Amazon.ECS.Model.UpdateClusterResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateCluster");
            try
            {
                #if DESKTOP
                return client.UpdateCluster(request);
                #elif CORECLR
                return client.UpdateClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String Cluster { get; set; }
            public System.String ExecuteCommandConfiguration_KmsKeyId { get; set; }
            public System.Boolean? LogConfiguration_CloudWatchEncryptionEnabled { get; set; }
            public System.String LogConfiguration_CloudWatchLogGroupName { get; set; }
            public System.String LogConfiguration_S3BucketName { get; set; }
            public System.Boolean? LogConfiguration_S3EncryptionEnabled { get; set; }
            public System.String LogConfiguration_S3KeyPrefix { get; set; }
            public Amazon.ECS.ExecuteCommandLogging ExecuteCommandConfiguration_Logging { get; set; }
            public System.String ManagedStorageConfiguration_FargateEphemeralStorageKmsKeyId { get; set; }
            public System.String ManagedStorageConfiguration_KmsKeyId { get; set; }
            public System.String ServiceConnectDefaults_Namespace { get; set; }
            public List<Amazon.ECS.Model.ClusterSetting> Setting { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateClusterResponse, UpdateECSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
