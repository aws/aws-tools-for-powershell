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
    /// Creates a new Amazon ECS cluster. By default, your account receives a <code>default</code>
    /// cluster when you launch your first container instance. However, you can create your
    /// own cluster with a unique name with the <code>CreateCluster</code> action.
    /// 
    ///  <note><para>
    /// When you call the <a>CreateCluster</a> API operation, Amazon ECS attempts to create
    /// the Amazon ECS service-linked role for your account. This is so that it can manage
    /// required resources in other Amazon Web Services services on your behalf. However,
    /// if the IAM user that makes the call doesn't have permissions to create the service-linked
    /// role, it isn't created. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using-service-linked-roles.html">Using
    /// service-linked roles for Amazon ECS</a> in the <i>Amazon Elastic Container Service
    /// Developer Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "ECSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.ECS.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Cluster or Amazon.ECS.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.ECS.Model.Cluster object.",
        "The service call response (type Amazon.ECS.Model.CreateClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECSClusterCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter CapacityProvider
        /// <summary>
        /// <para>
        /// <para>The short name of one or more capacity providers to associate with the cluster. A
        /// capacity provider must be associated with a cluster before it can be included as part
        /// of the default capacity provider strategy of the cluster or used in a capacity provider
        /// strategy when calling the <a>CreateService</a> or <a>RunTask</a> actions.</para><para>If specifying a capacity provider that uses an Auto Scaling group, the capacity provider
        /// must be created but not associated with another cluster. New Auto Scaling group capacity
        /// providers can be created with the <a>CreateCapacityProvider</a> API operation.</para><para>To use a Fargate capacity provider, specify either the <code>FARGATE</code> or <code>FARGATE_SPOT</code>
        /// capacity providers. The Fargate capacity providers are available to all accounts and
        /// only need to be associated with a cluster to be used.</para><para>The <a>PutClusterCapacityProviders</a> API operation is used to update the list of
        /// available capacity providers for a cluster after the cluster is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityProviders")]
        public System.String[] CapacityProvider { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_CloudWatchEncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>Determines whether to use encryption on the CloudWatch logs. If not specified, encryption
        /// will be disabled.</para>
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
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of your cluster. If you don't specify a name for your cluster, you create
        /// a cluster that's named <code>default</code>. Up to 255 letters (uppercase and lowercase),
        /// numbers, underscores, and hyphens are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter DefaultCapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to set as the default for the cluster. After a default
        /// capacity provider strategy is set for a cluster, when you call the <a>RunTask</a>
        /// or <a>CreateService</a> APIs with no capacity provider strategy or launch type specified,
        /// the default capacity provider strategy for the cluster is used.</para><para>If a default capacity provider strategy isn't defined for a cluster when it was created,
        /// it can be defined later with the <a>PutClusterCapacityProviders</a> API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.CapacityProviderStrategyItem[] DefaultCapacityProviderStrategy { get; set; }
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
        
        #region Parameter ExecuteCommandConfiguration_Logging
        /// <summary>
        /// <para>
        /// <para>The log setting to use for redirecting logs for your execute command results. The
        /// following log settings are available.</para><ul><li><para><code>NONE</code>: The execute command session is not logged.</para></li><li><para><code>DEFAULT</code>: The <code>awslogs</code> configuration in the task definition
        /// is used. If no logging parameter is specified, it defaults to this value. If no <code>awslogs</code>
        /// log driver is configured in the task definition, the output won't be logged.</para></li><li><para><code>OVERRIDE</code>: Specify the logging details as a part of <code>logConfiguration</code>.
        /// If the <code>OVERRIDE</code> logging option is specified, the <code>logConfiguration</code>
        /// is required.</para></li></ul>
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
        /// Up to 1024 characters are allowed. The name is case-sensitive. The characters can't
        /// include hyphens (-), tilde (~), greater than (&gt;), less than (&lt;), or slash (/).</para><para>If you enter an existing namespace name or ARN, then that namespace will be used.
        /// Any namespace type is supported. The namespace must be in this account and this Amazon
        /// Web Services Region.</para><para>If you enter a new name, a Cloud Map namespace will be created. Amazon ECS creates
        /// a Cloud Map namespace with the "API calls" method of instance discovery only. This
        /// instance discovery method is the "HTTP" namespace type in the Command Line Interface.
        /// Other types of instance discovery aren't used by Service Connect.</para><para>If you update the service with an empty string <code>""</code> for the namespace name,
        /// the cluster configuration for Service Connect is removed. Note that the namespace
        /// will remain in Cloud Map and must be deleted separately.</para><para>For more information about Cloud Map, see <a href="https://docs.aws.amazon.com/">Working
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
        /// <para>The setting to use when creating a cluster. This parameter is used to turn on CloudWatch
        /// Container Insights for a cluster. If this value is specified, it overrides the <code>containerInsights</code>
        /// value set with <a>PutAccountSetting</a> or <a>PutAccountSettingDefault</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings")]
        public Amazon.ECS.Model.ClusterSetting[] Setting { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata that you apply to the cluster to help you categorize and organize them.
        /// Each tag consists of a key and an optional value. You define both.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case-sensitive.</para></li><li><para>Do not use <code>aws:</code>, <code>AWS:</code>, or any upper or lowercase combination
        /// of such as a prefix for either keys or values as it is reserved for Amazon Web Services
        /// use. You cannot edit or delete tag keys or values with this prefix. Tags with this
        /// prefix do not count against your tags per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ECS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECSCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.CreateClusterResponse, NewECSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CapacityProvider != null)
            {
                context.CapacityProvider = new List<System.String>(this.CapacityProvider);
            }
            context.ClusterName = this.ClusterName;
            context.ExecuteCommandConfiguration_KmsKeyId = this.ExecuteCommandConfiguration_KmsKeyId;
            context.LogConfiguration_CloudWatchEncryptionEnabled = this.LogConfiguration_CloudWatchEncryptionEnabled;
            context.LogConfiguration_CloudWatchLogGroupName = this.LogConfiguration_CloudWatchLogGroupName;
            context.LogConfiguration_S3BucketName = this.LogConfiguration_S3BucketName;
            context.LogConfiguration_S3EncryptionEnabled = this.LogConfiguration_S3EncryptionEnabled;
            context.LogConfiguration_S3KeyPrefix = this.LogConfiguration_S3KeyPrefix;
            context.ExecuteCommandConfiguration_Logging = this.ExecuteCommandConfiguration_Logging;
            if (this.DefaultCapacityProviderStrategy != null)
            {
                context.DefaultCapacityProviderStrategy = new List<Amazon.ECS.Model.CapacityProviderStrategyItem>(this.DefaultCapacityProviderStrategy);
            }
            context.ServiceConnectDefaults_Namespace = this.ServiceConnectDefaults_Namespace;
            if (this.Setting != null)
            {
                context.Setting = new List<Amazon.ECS.Model.ClusterSetting>(this.Setting);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ECS.Model.Tag>(this.Tag);
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
            var request = new Amazon.ECS.Model.CreateClusterRequest();
            
            if (cmdletContext.CapacityProvider != null)
            {
                request.CapacityProviders = cmdletContext.CapacityProvider;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.ECS.Model.ClusterConfiguration();
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
            if (cmdletContext.DefaultCapacityProviderStrategy != null)
            {
                request.DefaultCapacityProviderStrategy = cmdletContext.DefaultCapacityProviderStrategy;
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
        
        private Amazon.ECS.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                return client.CreateClusterAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CapacityProvider { get; set; }
            public System.String ClusterName { get; set; }
            public System.String ExecuteCommandConfiguration_KmsKeyId { get; set; }
            public System.Boolean? LogConfiguration_CloudWatchEncryptionEnabled { get; set; }
            public System.String LogConfiguration_CloudWatchLogGroupName { get; set; }
            public System.String LogConfiguration_S3BucketName { get; set; }
            public System.Boolean? LogConfiguration_S3EncryptionEnabled { get; set; }
            public System.String LogConfiguration_S3KeyPrefix { get; set; }
            public Amazon.ECS.ExecuteCommandLogging ExecuteCommandConfiguration_Logging { get; set; }
            public List<Amazon.ECS.Model.CapacityProviderStrategyItem> DefaultCapacityProviderStrategy { get; set; }
            public System.String ServiceConnectDefaults_Namespace { get; set; }
            public List<Amazon.ECS.Model.ClusterSetting> Setting { get; set; }
            public List<Amazon.ECS.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ECS.Model.CreateClusterResponse, NewECSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
