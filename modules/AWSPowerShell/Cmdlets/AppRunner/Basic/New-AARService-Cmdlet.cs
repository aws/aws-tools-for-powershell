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
using Amazon.AppRunner;
using Amazon.AppRunner.Model;

namespace Amazon.PowerShell.Cmdlets.AAR
{
    /// <summary>
    /// Create an App Runner service. After the service is created, the action also automatically
    /// starts a deployment.
    /// 
    ///  
    /// <para>
    /// This is an asynchronous operation. On a successful call, you can use the returned
    /// <code>OperationId</code> and the <a href="https://docs.aws.amazon.com/apprunner/latest/api/API_ListOperations.html">ListOperations</a>
    /// call to track the operation's progress.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AARService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRunner.Model.CreateServiceResponse")]
    [AWSCmdlet("Calls the AWS App Runner CreateService API operation.", Operation = new[] {"CreateService"}, SelectReturnType = typeof(Amazon.AppRunner.Model.CreateServiceResponse))]
    [AWSCmdletOutput("Amazon.AppRunner.Model.CreateServiceResponse",
        "This cmdlet returns an Amazon.AppRunner.Model.CreateServiceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAARServiceCmdlet : AmazonAppRunnerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter AuthenticationConfiguration_AccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that grants the App Runner service
        /// access to a source repository. It's required for ECR image repositories (but not for
        /// ECR Public repositories).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_AuthenticationConfiguration_AccessRoleArn")]
        public System.String AuthenticationConfiguration_AccessRoleArn { get; set; }
        #endregion
        
        #region Parameter SourceConfiguration_AutoDeploymentsEnabled
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, continuous integration from the source repository is enabled
        /// for the App Runner service. Each repository change (including any source code commit
        /// or new image version) starts a deployment.</para><para>Default: App Runner sets to <code>false</code> for a source image that uses an ECR
        /// Public repository or an ECR repository that's in an Amazon Web Services account other
        /// than the one that the service is in. App Runner sets to <code>true</code> in all other
        /// cases (which currently include a source code repository or a source image using a
        /// same-account ECR repository).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SourceConfiguration_AutoDeploymentsEnabled { get; set; }
        #endregion
        
        #region Parameter AutoScalingConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an App Runner automatic scaling configuration resource
        /// that you want to associate with your service. If not provided, App Runner associates
        /// the latest revision of a default auto scaling configuration.</para><para>Specify an ARN with a name and a revision number to associate that revision. For example:
        /// <code>arn:aws:apprunner:us-east-1:123456789012:autoscalingconfiguration/high-availability/3</code></para><para>Specify just the name to associate the latest revision. For example: <code>arn:aws:apprunner:us-east-1:123456789012:autoscalingconfiguration/high-availability</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoScalingConfigurationArn { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationValues_BuildCommand
        /// <summary>
        /// <para>
        /// <para>The command App Runner runs to build your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_BuildCommand")]
        public System.String CodeConfigurationValues_BuildCommand { get; set; }
        #endregion
        
        #region Parameter CodeConfiguration_ConfigurationSource
        /// <summary>
        /// <para>
        /// <para>The source of the App Runner configuration. Values are interpreted as follows:</para><ul><li><para><code>REPOSITORY</code> – App Runner reads configuration values from the <code>apprunner.yaml</code>
        /// file in the source code repository and ignores <code>CodeConfigurationValues</code>.</para></li><li><para><code>API</code> – App Runner uses configuration values provided in <code>CodeConfigurationValues</code>
        /// and ignores the <code>apprunner.yaml</code> file in the source code repository.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_CodeConfiguration_ConfigurationSource")]
        [AWSConstantClassSource("Amazon.AppRunner.ConfigurationSource")]
        public Amazon.AppRunner.ConfigurationSource CodeConfiguration_ConfigurationSource { get; set; }
        #endregion
        
        #region Parameter AuthenticationConfiguration_ConnectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the App Runner connection that enables the App Runner
        /// service to connect to a source repository. It's required for GitHub code repositories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_AuthenticationConfiguration_ConnectionArn")]
        public System.String AuthenticationConfiguration_ConnectionArn { get; set; }
        #endregion
        
        #region Parameter InstanceConfiguration_Cpu
        /// <summary>
        /// <para>
        /// <para>The number of CPU units reserved for each instance of your App Runner service.</para><para>Default: <code>1 vCPU</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceConfiguration_Cpu { get; set; }
        #endregion
        
        #region Parameter EgressConfiguration_EgressType
        /// <summary>
        /// <para>
        /// <para>The type of egress configuration.</para><para>Set to <code>DEFAULT</code> for access to resources hosted on public networks.</para><para>Set to <code>VPC</code> to associate your service to a custom VPC specified by <code>VpcConnectorArn</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_EgressConfiguration_EgressType")]
        [AWSConstantClassSource("Amazon.AppRunner.EgressType")]
        public Amazon.AppRunner.EgressType EgressConfiguration_EgressType { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfiguration_HealthyThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive checks that must succeed before App Runner decides that
        /// the service is healthy.</para><para>Default: <code>1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfiguration_HealthyThreshold { get; set; }
        #endregion
        
        #region Parameter ImageRepository_ImageIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of an image.</para><para>For an image in Amazon Elastic Container Registry (Amazon ECR), this is an image name.
        /// For the image name format, see <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/docker-pull-ecr-image.html">Pulling
        /// an image</a> in the <i>Amazon ECR User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ImageRepository_ImageIdentifier")]
        public System.String ImageRepository_ImageIdentifier { get; set; }
        #endregion
        
        #region Parameter ImageRepository_ImageRepositoryType
        /// <summary>
        /// <para>
        /// <para>The type of the image repository. This reflects the repository provider and whether
        /// the repository is private or public.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ImageRepository_ImageRepositoryType")]
        [AWSConstantClassSource("Amazon.AppRunner.ImageRepositoryType")]
        public Amazon.AppRunner.ImageRepositoryType ImageRepository_ImageRepositoryType { get; set; }
        #endregion
        
        #region Parameter InstanceConfiguration_InstanceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that provides permissions to your App
        /// Runner service. These are permissions that your code needs when it calls any Amazon
        /// Web Services APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceConfiguration_InstanceRoleArn { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfiguration_Interval
        /// <summary>
        /// <para>
        /// <para>The time interval, in seconds, between health checks.</para><para>Default: <code>5</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfiguration_Interval { get; set; }
        #endregion
        
        #region Parameter IngressConfiguration_IsPubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies whether your App Runner service is publicly accessible. To make the service
        /// publicly accessible set it to <code>True</code>. To make the service privately accessible,
        /// from only within an Amazon VPC set it to <code>False</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_IngressConfiguration_IsPubliclyAccessible")]
        public System.Boolean? IngressConfiguration_IsPubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKey
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key that's used for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKey { get; set; }
        #endregion
        
        #region Parameter InstanceConfiguration_Memory
        /// <summary>
        /// <para>
        /// <para>The amount of memory, in MB or GB, reserved for each instance of your App Runner service.</para><para>Default: <code>2 GB</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceConfiguration_Memory { get; set; }
        #endregion
        
        #region Parameter ObservabilityConfiguration_ObservabilityConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the observability configuration that is associated
        /// with the service. Specified only when <code>ObservabilityEnabled</code> is <code>true</code>.</para><para>Specify an ARN with a name and a revision number to associate that revision. For example:
        /// <code>arn:aws:apprunner:us-east-1:123456789012:observabilityconfiguration/xray-tracing/3</code></para><para>Specify just the name to associate the latest revision. For example: <code>arn:aws:apprunner:us-east-1:123456789012:observabilityconfiguration/xray-tracing</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObservabilityConfiguration_ObservabilityConfigurationArn { get; set; }
        #endregion
        
        #region Parameter ObservabilityConfiguration_ObservabilityEnabled
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, an observability configuration resource is associated with
        /// the service, and an <code>ObservabilityConfigurationArn</code> is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ObservabilityConfiguration_ObservabilityEnabled { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfiguration_Path
        /// <summary>
        /// <para>
        /// <para>The URL that health check requests are sent to.</para><para><code>Path</code> is only applicable when you set <code>Protocol</code> to <code>HTTP</code>.</para><para>Default: <code>"/"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckConfiguration_Path { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationValues_Port
        /// <summary>
        /// <para>
        /// <para>The port that your application listens to in the container.</para><para>Default: <code>8080</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_Port")]
        public System.String CodeConfigurationValues_Port { get; set; }
        #endregion
        
        #region Parameter ImageConfiguration_Port
        /// <summary>
        /// <para>
        /// <para>The port that your application listens to in the container.</para><para>Default: <code>8080</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ImageRepository_ImageConfiguration_Port")]
        public System.String ImageConfiguration_Port { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfiguration_Protocol
        /// <summary>
        /// <para>
        /// <para>The IP protocol that App Runner uses to perform health checks for your service.</para><para>If you set <code>Protocol</code> to <code>HTTP</code>, App Runner sends health check
        /// requests to the HTTP path specified by <code>Path</code>.</para><para>Default: <code>TCP</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppRunner.HealthCheckProtocol")]
        public Amazon.AppRunner.HealthCheckProtocol HealthCheckConfiguration_Protocol { get; set; }
        #endregion
        
        #region Parameter CodeRepository_RepositoryUrl
        /// <summary>
        /// <para>
        /// <para>The location of the repository that contains the source code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_RepositoryUrl")]
        public System.String CodeRepository_RepositoryUrl { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationValues_Runtime
        /// <summary>
        /// <para>
        /// <para>A runtime environment type for building and running an App Runner service. It represents
        /// a programming language runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_Runtime")]
        [AWSConstantClassSource("Amazon.AppRunner.Runtime")]
        public Amazon.AppRunner.Runtime CodeConfigurationValues_Runtime { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationValues_RuntimeEnvironmentSecret
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs representing the secrets and parameters that get referenced
        /// to your service as an environment variable. The supported values are either the full
        /// Amazon Resource Name (ARN) of the Secrets Manager secret or the full ARN of the parameter
        /// in the Amazon Web Services Systems Manager Parameter Store.</para><note><ul><li><para> If the Amazon Web Services Systems Manager Parameter Store parameter exists in the
        /// same Amazon Web Services Region as the service that you're launching, you can use
        /// either the full ARN or name of the secret. If the parameter exists in a different
        /// Region, then the full ARN must be specified. </para></li><li><para> Currently, cross account referencing of Amazon Web Services Systems Manager Parameter
        /// Store parameter is not supported. </para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_RuntimeEnvironmentSecrets")]
        public System.Collections.Hashtable CodeConfigurationValues_RuntimeEnvironmentSecret { get; set; }
        #endregion
        
        #region Parameter ImageConfiguration_RuntimeEnvironmentSecret
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs representing the secrets and parameters that get referenced
        /// to your service as an environment variable. The supported values are either the full
        /// Amazon Resource Name (ARN) of the Secrets Manager secret or the full ARN of the parameter
        /// in the Amazon Web Services Systems Manager Parameter Store.</para><note><ul><li><para> If the Amazon Web Services Systems Manager Parameter Store parameter exists in the
        /// same Amazon Web Services Region as the service that you're launching, you can use
        /// either the full ARN or name of the secret. If the parameter exists in a different
        /// Region, then the full ARN must be specified. </para></li><li><para> Currently, cross account referencing of Amazon Web Services Systems Manager Parameter
        /// Store parameter is not supported. </para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ImageRepository_ImageConfiguration_RuntimeEnvironmentSecrets")]
        public System.Collections.Hashtable ImageConfiguration_RuntimeEnvironmentSecret { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationValues_RuntimeEnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>The environment variables that are available to your running App Runner service. An
        /// array of key-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_RuntimeEnvironmentVariables")]
        public System.Collections.Hashtable CodeConfigurationValues_RuntimeEnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter ImageConfiguration_RuntimeEnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>Environment variables that are available to your running App Runner service. An array
        /// of key-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ImageRepository_ImageConfiguration_RuntimeEnvironmentVariables")]
        public System.Collections.Hashtable ImageConfiguration_RuntimeEnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>A name for the App Runner service. It must be unique across all the running App Runner
        /// services in your Amazon Web Services account in the Amazon Web Services Region.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter CodeConfigurationValues_StartCommand
        /// <summary>
        /// <para>
        /// <para>The command App Runner runs to start your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_StartCommand")]
        public System.String CodeConfigurationValues_StartCommand { get; set; }
        #endregion
        
        #region Parameter ImageConfiguration_StartCommand
        /// <summary>
        /// <para>
        /// <para>An optional command that App Runner runs to start the application in the source image.
        /// If specified, this command overrides the Docker image’s default start command.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_ImageRepository_ImageConfiguration_StartCommand")]
        public System.String ImageConfiguration_StartCommand { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of metadata items that you can associate with the App Runner service
        /// resource. A tag is a key-value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppRunner.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfiguration_Timeout
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, to wait for a health check response before deciding it failed.</para><para>Default: <code>2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfiguration_Timeout { get; set; }
        #endregion
        
        #region Parameter SourceCodeVersion_Type
        /// <summary>
        /// <para>
        /// <para>The type of version identifier.</para><para>For a git-based repository, branches represent versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_SourceCodeVersion_Type")]
        [AWSConstantClassSource("Amazon.AppRunner.SourceCodeVersionType")]
        public Amazon.AppRunner.SourceCodeVersionType SourceCodeVersion_Type { get; set; }
        #endregion
        
        #region Parameter HealthCheckConfiguration_UnhealthyThreshold
        /// <summary>
        /// <para>
        /// <para>The number of consecutive checks that must fail before App Runner decides that the
        /// service is unhealthy.</para><para>Default: <code>5</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckConfiguration_UnhealthyThreshold { get; set; }
        #endregion
        
        #region Parameter SourceCodeVersion_Value
        /// <summary>
        /// <para>
        /// <para>A source code version.</para><para>For a git-based repository, a branch name maps to a specific version. App Runner uses
        /// the most recent commit to the branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceConfiguration_CodeRepository_SourceCodeVersion_Value")]
        public System.String SourceCodeVersion_Value { get; set; }
        #endregion
        
        #region Parameter EgressConfiguration_VpcConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the App Runner VPC connector that you want to associate
        /// with your App Runner service. Only valid when <code>EgressType = VPC</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_EgressConfiguration_VpcConnectorArn")]
        public System.String EgressConfiguration_VpcConnectorArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRunner.Model.CreateServiceResponse).
        /// Specifying the name of a property of type Amazon.AppRunner.Model.CreateServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AARService (CreateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRunner.Model.CreateServiceResponse, NewAARServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScalingConfigurationArn = this.AutoScalingConfigurationArn;
            context.EncryptionConfiguration_KmsKey = this.EncryptionConfiguration_KmsKey;
            context.HealthCheckConfiguration_HealthyThreshold = this.HealthCheckConfiguration_HealthyThreshold;
            context.HealthCheckConfiguration_Interval = this.HealthCheckConfiguration_Interval;
            context.HealthCheckConfiguration_Path = this.HealthCheckConfiguration_Path;
            context.HealthCheckConfiguration_Protocol = this.HealthCheckConfiguration_Protocol;
            context.HealthCheckConfiguration_Timeout = this.HealthCheckConfiguration_Timeout;
            context.HealthCheckConfiguration_UnhealthyThreshold = this.HealthCheckConfiguration_UnhealthyThreshold;
            context.InstanceConfiguration_Cpu = this.InstanceConfiguration_Cpu;
            context.InstanceConfiguration_InstanceRoleArn = this.InstanceConfiguration_InstanceRoleArn;
            context.InstanceConfiguration_Memory = this.InstanceConfiguration_Memory;
            context.EgressConfiguration_EgressType = this.EgressConfiguration_EgressType;
            context.EgressConfiguration_VpcConnectorArn = this.EgressConfiguration_VpcConnectorArn;
            context.IngressConfiguration_IsPubliclyAccessible = this.IngressConfiguration_IsPubliclyAccessible;
            context.ObservabilityConfiguration_ObservabilityConfigurationArn = this.ObservabilityConfiguration_ObservabilityConfigurationArn;
            context.ObservabilityConfiguration_ObservabilityEnabled = this.ObservabilityConfiguration_ObservabilityEnabled;
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthenticationConfiguration_AccessRoleArn = this.AuthenticationConfiguration_AccessRoleArn;
            context.AuthenticationConfiguration_ConnectionArn = this.AuthenticationConfiguration_ConnectionArn;
            context.SourceConfiguration_AutoDeploymentsEnabled = this.SourceConfiguration_AutoDeploymentsEnabled;
            context.CodeConfigurationValues_BuildCommand = this.CodeConfigurationValues_BuildCommand;
            context.CodeConfigurationValues_Port = this.CodeConfigurationValues_Port;
            context.CodeConfigurationValues_Runtime = this.CodeConfigurationValues_Runtime;
            if (this.CodeConfigurationValues_RuntimeEnvironmentSecret != null)
            {
                context.CodeConfigurationValues_RuntimeEnvironmentSecret = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CodeConfigurationValues_RuntimeEnvironmentSecret.Keys)
                {
                    context.CodeConfigurationValues_RuntimeEnvironmentSecret.Add((String)hashKey, (String)(this.CodeConfigurationValues_RuntimeEnvironmentSecret[hashKey]));
                }
            }
            if (this.CodeConfigurationValues_RuntimeEnvironmentVariable != null)
            {
                context.CodeConfigurationValues_RuntimeEnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CodeConfigurationValues_RuntimeEnvironmentVariable.Keys)
                {
                    context.CodeConfigurationValues_RuntimeEnvironmentVariable.Add((String)hashKey, (String)(this.CodeConfigurationValues_RuntimeEnvironmentVariable[hashKey]));
                }
            }
            context.CodeConfigurationValues_StartCommand = this.CodeConfigurationValues_StartCommand;
            context.CodeConfiguration_ConfigurationSource = this.CodeConfiguration_ConfigurationSource;
            context.CodeRepository_RepositoryUrl = this.CodeRepository_RepositoryUrl;
            context.SourceCodeVersion_Type = this.SourceCodeVersion_Type;
            context.SourceCodeVersion_Value = this.SourceCodeVersion_Value;
            context.ImageConfiguration_Port = this.ImageConfiguration_Port;
            if (this.ImageConfiguration_RuntimeEnvironmentSecret != null)
            {
                context.ImageConfiguration_RuntimeEnvironmentSecret = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ImageConfiguration_RuntimeEnvironmentSecret.Keys)
                {
                    context.ImageConfiguration_RuntimeEnvironmentSecret.Add((String)hashKey, (String)(this.ImageConfiguration_RuntimeEnvironmentSecret[hashKey]));
                }
            }
            if (this.ImageConfiguration_RuntimeEnvironmentVariable != null)
            {
                context.ImageConfiguration_RuntimeEnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ImageConfiguration_RuntimeEnvironmentVariable.Keys)
                {
                    context.ImageConfiguration_RuntimeEnvironmentVariable.Add((String)hashKey, (String)(this.ImageConfiguration_RuntimeEnvironmentVariable[hashKey]));
                }
            }
            context.ImageConfiguration_StartCommand = this.ImageConfiguration_StartCommand;
            context.ImageRepository_ImageIdentifier = this.ImageRepository_ImageIdentifier;
            context.ImageRepository_ImageRepositoryType = this.ImageRepository_ImageRepositoryType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppRunner.Model.Tag>(this.Tag);
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
            var request = new Amazon.AppRunner.Model.CreateServiceRequest();
            
            if (cmdletContext.AutoScalingConfigurationArn != null)
            {
                request.AutoScalingConfigurationArn = cmdletContext.AutoScalingConfigurationArn;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.AppRunner.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKey = null;
            if (cmdletContext.EncryptionConfiguration_KmsKey != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKey = cmdletContext.EncryptionConfiguration_KmsKey;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKey != null)
            {
                request.EncryptionConfiguration.KmsKey = requestEncryptionConfiguration_encryptionConfiguration_KmsKey;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            
             // populate HealthCheckConfiguration
            var requestHealthCheckConfigurationIsNull = true;
            request.HealthCheckConfiguration = new Amazon.AppRunner.Model.HealthCheckConfiguration();
            System.Int32? requestHealthCheckConfiguration_healthCheckConfiguration_HealthyThreshold = null;
            if (cmdletContext.HealthCheckConfiguration_HealthyThreshold != null)
            {
                requestHealthCheckConfiguration_healthCheckConfiguration_HealthyThreshold = cmdletContext.HealthCheckConfiguration_HealthyThreshold.Value;
            }
            if (requestHealthCheckConfiguration_healthCheckConfiguration_HealthyThreshold != null)
            {
                request.HealthCheckConfiguration.HealthyThreshold = requestHealthCheckConfiguration_healthCheckConfiguration_HealthyThreshold.Value;
                requestHealthCheckConfigurationIsNull = false;
            }
            System.Int32? requestHealthCheckConfiguration_healthCheckConfiguration_Interval = null;
            if (cmdletContext.HealthCheckConfiguration_Interval != null)
            {
                requestHealthCheckConfiguration_healthCheckConfiguration_Interval = cmdletContext.HealthCheckConfiguration_Interval.Value;
            }
            if (requestHealthCheckConfiguration_healthCheckConfiguration_Interval != null)
            {
                request.HealthCheckConfiguration.Interval = requestHealthCheckConfiguration_healthCheckConfiguration_Interval.Value;
                requestHealthCheckConfigurationIsNull = false;
            }
            System.String requestHealthCheckConfiguration_healthCheckConfiguration_Path = null;
            if (cmdletContext.HealthCheckConfiguration_Path != null)
            {
                requestHealthCheckConfiguration_healthCheckConfiguration_Path = cmdletContext.HealthCheckConfiguration_Path;
            }
            if (requestHealthCheckConfiguration_healthCheckConfiguration_Path != null)
            {
                request.HealthCheckConfiguration.Path = requestHealthCheckConfiguration_healthCheckConfiguration_Path;
                requestHealthCheckConfigurationIsNull = false;
            }
            Amazon.AppRunner.HealthCheckProtocol requestHealthCheckConfiguration_healthCheckConfiguration_Protocol = null;
            if (cmdletContext.HealthCheckConfiguration_Protocol != null)
            {
                requestHealthCheckConfiguration_healthCheckConfiguration_Protocol = cmdletContext.HealthCheckConfiguration_Protocol;
            }
            if (requestHealthCheckConfiguration_healthCheckConfiguration_Protocol != null)
            {
                request.HealthCheckConfiguration.Protocol = requestHealthCheckConfiguration_healthCheckConfiguration_Protocol;
                requestHealthCheckConfigurationIsNull = false;
            }
            System.Int32? requestHealthCheckConfiguration_healthCheckConfiguration_Timeout = null;
            if (cmdletContext.HealthCheckConfiguration_Timeout != null)
            {
                requestHealthCheckConfiguration_healthCheckConfiguration_Timeout = cmdletContext.HealthCheckConfiguration_Timeout.Value;
            }
            if (requestHealthCheckConfiguration_healthCheckConfiguration_Timeout != null)
            {
                request.HealthCheckConfiguration.Timeout = requestHealthCheckConfiguration_healthCheckConfiguration_Timeout.Value;
                requestHealthCheckConfigurationIsNull = false;
            }
            System.Int32? requestHealthCheckConfiguration_healthCheckConfiguration_UnhealthyThreshold = null;
            if (cmdletContext.HealthCheckConfiguration_UnhealthyThreshold != null)
            {
                requestHealthCheckConfiguration_healthCheckConfiguration_UnhealthyThreshold = cmdletContext.HealthCheckConfiguration_UnhealthyThreshold.Value;
            }
            if (requestHealthCheckConfiguration_healthCheckConfiguration_UnhealthyThreshold != null)
            {
                request.HealthCheckConfiguration.UnhealthyThreshold = requestHealthCheckConfiguration_healthCheckConfiguration_UnhealthyThreshold.Value;
                requestHealthCheckConfigurationIsNull = false;
            }
             // determine if request.HealthCheckConfiguration should be set to null
            if (requestHealthCheckConfigurationIsNull)
            {
                request.HealthCheckConfiguration = null;
            }
            
             // populate InstanceConfiguration
            var requestInstanceConfigurationIsNull = true;
            request.InstanceConfiguration = new Amazon.AppRunner.Model.InstanceConfiguration();
            System.String requestInstanceConfiguration_instanceConfiguration_Cpu = null;
            if (cmdletContext.InstanceConfiguration_Cpu != null)
            {
                requestInstanceConfiguration_instanceConfiguration_Cpu = cmdletContext.InstanceConfiguration_Cpu;
            }
            if (requestInstanceConfiguration_instanceConfiguration_Cpu != null)
            {
                request.InstanceConfiguration.Cpu = requestInstanceConfiguration_instanceConfiguration_Cpu;
                requestInstanceConfigurationIsNull = false;
            }
            System.String requestInstanceConfiguration_instanceConfiguration_InstanceRoleArn = null;
            if (cmdletContext.InstanceConfiguration_InstanceRoleArn != null)
            {
                requestInstanceConfiguration_instanceConfiguration_InstanceRoleArn = cmdletContext.InstanceConfiguration_InstanceRoleArn;
            }
            if (requestInstanceConfiguration_instanceConfiguration_InstanceRoleArn != null)
            {
                request.InstanceConfiguration.InstanceRoleArn = requestInstanceConfiguration_instanceConfiguration_InstanceRoleArn;
                requestInstanceConfigurationIsNull = false;
            }
            System.String requestInstanceConfiguration_instanceConfiguration_Memory = null;
            if (cmdletContext.InstanceConfiguration_Memory != null)
            {
                requestInstanceConfiguration_instanceConfiguration_Memory = cmdletContext.InstanceConfiguration_Memory;
            }
            if (requestInstanceConfiguration_instanceConfiguration_Memory != null)
            {
                request.InstanceConfiguration.Memory = requestInstanceConfiguration_instanceConfiguration_Memory;
                requestInstanceConfigurationIsNull = false;
            }
             // determine if request.InstanceConfiguration should be set to null
            if (requestInstanceConfigurationIsNull)
            {
                request.InstanceConfiguration = null;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.AppRunner.Model.NetworkConfiguration();
            Amazon.AppRunner.Model.IngressConfiguration requestNetworkConfiguration_networkConfiguration_IngressConfiguration = null;
            
             // populate IngressConfiguration
            var requestNetworkConfiguration_networkConfiguration_IngressConfigurationIsNull = true;
            requestNetworkConfiguration_networkConfiguration_IngressConfiguration = new Amazon.AppRunner.Model.IngressConfiguration();
            System.Boolean? requestNetworkConfiguration_networkConfiguration_IngressConfiguration_ingressConfiguration_IsPubliclyAccessible = null;
            if (cmdletContext.IngressConfiguration_IsPubliclyAccessible != null)
            {
                requestNetworkConfiguration_networkConfiguration_IngressConfiguration_ingressConfiguration_IsPubliclyAccessible = cmdletContext.IngressConfiguration_IsPubliclyAccessible.Value;
            }
            if (requestNetworkConfiguration_networkConfiguration_IngressConfiguration_ingressConfiguration_IsPubliclyAccessible != null)
            {
                requestNetworkConfiguration_networkConfiguration_IngressConfiguration.IsPubliclyAccessible = requestNetworkConfiguration_networkConfiguration_IngressConfiguration_ingressConfiguration_IsPubliclyAccessible.Value;
                requestNetworkConfiguration_networkConfiguration_IngressConfigurationIsNull = false;
            }
             // determine if requestNetworkConfiguration_networkConfiguration_IngressConfiguration should be set to null
            if (requestNetworkConfiguration_networkConfiguration_IngressConfigurationIsNull)
            {
                requestNetworkConfiguration_networkConfiguration_IngressConfiguration = null;
            }
            if (requestNetworkConfiguration_networkConfiguration_IngressConfiguration != null)
            {
                request.NetworkConfiguration.IngressConfiguration = requestNetworkConfiguration_networkConfiguration_IngressConfiguration;
                requestNetworkConfigurationIsNull = false;
            }
            Amazon.AppRunner.Model.EgressConfiguration requestNetworkConfiguration_networkConfiguration_EgressConfiguration = null;
            
             // populate EgressConfiguration
            var requestNetworkConfiguration_networkConfiguration_EgressConfigurationIsNull = true;
            requestNetworkConfiguration_networkConfiguration_EgressConfiguration = new Amazon.AppRunner.Model.EgressConfiguration();
            Amazon.AppRunner.EgressType requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_EgressType = null;
            if (cmdletContext.EgressConfiguration_EgressType != null)
            {
                requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_EgressType = cmdletContext.EgressConfiguration_EgressType;
            }
            if (requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_EgressType != null)
            {
                requestNetworkConfiguration_networkConfiguration_EgressConfiguration.EgressType = requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_EgressType;
                requestNetworkConfiguration_networkConfiguration_EgressConfigurationIsNull = false;
            }
            System.String requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_VpcConnectorArn = null;
            if (cmdletContext.EgressConfiguration_VpcConnectorArn != null)
            {
                requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_VpcConnectorArn = cmdletContext.EgressConfiguration_VpcConnectorArn;
            }
            if (requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_VpcConnectorArn != null)
            {
                requestNetworkConfiguration_networkConfiguration_EgressConfiguration.VpcConnectorArn = requestNetworkConfiguration_networkConfiguration_EgressConfiguration_egressConfiguration_VpcConnectorArn;
                requestNetworkConfiguration_networkConfiguration_EgressConfigurationIsNull = false;
            }
             // determine if requestNetworkConfiguration_networkConfiguration_EgressConfiguration should be set to null
            if (requestNetworkConfiguration_networkConfiguration_EgressConfigurationIsNull)
            {
                requestNetworkConfiguration_networkConfiguration_EgressConfiguration = null;
            }
            if (requestNetworkConfiguration_networkConfiguration_EgressConfiguration != null)
            {
                request.NetworkConfiguration.EgressConfiguration = requestNetworkConfiguration_networkConfiguration_EgressConfiguration;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            
             // populate ObservabilityConfiguration
            var requestObservabilityConfigurationIsNull = true;
            request.ObservabilityConfiguration = new Amazon.AppRunner.Model.ServiceObservabilityConfiguration();
            System.String requestObservabilityConfiguration_observabilityConfiguration_ObservabilityConfigurationArn = null;
            if (cmdletContext.ObservabilityConfiguration_ObservabilityConfigurationArn != null)
            {
                requestObservabilityConfiguration_observabilityConfiguration_ObservabilityConfigurationArn = cmdletContext.ObservabilityConfiguration_ObservabilityConfigurationArn;
            }
            if (requestObservabilityConfiguration_observabilityConfiguration_ObservabilityConfigurationArn != null)
            {
                request.ObservabilityConfiguration.ObservabilityConfigurationArn = requestObservabilityConfiguration_observabilityConfiguration_ObservabilityConfigurationArn;
                requestObservabilityConfigurationIsNull = false;
            }
            System.Boolean? requestObservabilityConfiguration_observabilityConfiguration_ObservabilityEnabled = null;
            if (cmdletContext.ObservabilityConfiguration_ObservabilityEnabled != null)
            {
                requestObservabilityConfiguration_observabilityConfiguration_ObservabilityEnabled = cmdletContext.ObservabilityConfiguration_ObservabilityEnabled.Value;
            }
            if (requestObservabilityConfiguration_observabilityConfiguration_ObservabilityEnabled != null)
            {
                request.ObservabilityConfiguration.ObservabilityEnabled = requestObservabilityConfiguration_observabilityConfiguration_ObservabilityEnabled.Value;
                requestObservabilityConfigurationIsNull = false;
            }
             // determine if request.ObservabilityConfiguration should be set to null
            if (requestObservabilityConfigurationIsNull)
            {
                request.ObservabilityConfiguration = null;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            
             // populate SourceConfiguration
            var requestSourceConfigurationIsNull = true;
            request.SourceConfiguration = new Amazon.AppRunner.Model.SourceConfiguration();
            System.Boolean? requestSourceConfiguration_sourceConfiguration_AutoDeploymentsEnabled = null;
            if (cmdletContext.SourceConfiguration_AutoDeploymentsEnabled != null)
            {
                requestSourceConfiguration_sourceConfiguration_AutoDeploymentsEnabled = cmdletContext.SourceConfiguration_AutoDeploymentsEnabled.Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_AutoDeploymentsEnabled != null)
            {
                request.SourceConfiguration.AutoDeploymentsEnabled = requestSourceConfiguration_sourceConfiguration_AutoDeploymentsEnabled.Value;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.AppRunner.Model.AuthenticationConfiguration requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration = null;
            
             // populate AuthenticationConfiguration
            var requestSourceConfiguration_sourceConfiguration_AuthenticationConfigurationIsNull = true;
            requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration = new Amazon.AppRunner.Model.AuthenticationConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_AccessRoleArn = null;
            if (cmdletContext.AuthenticationConfiguration_AccessRoleArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_AccessRoleArn = cmdletContext.AuthenticationConfiguration_AccessRoleArn;
            }
            if (requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_AccessRoleArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration.AccessRoleArn = requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_AccessRoleArn;
                requestSourceConfiguration_sourceConfiguration_AuthenticationConfigurationIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_ConnectionArn = null;
            if (cmdletContext.AuthenticationConfiguration_ConnectionArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_ConnectionArn = cmdletContext.AuthenticationConfiguration_ConnectionArn;
            }
            if (requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_ConnectionArn != null)
            {
                requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration.ConnectionArn = requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration_authenticationConfiguration_ConnectionArn;
                requestSourceConfiguration_sourceConfiguration_AuthenticationConfigurationIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration should be set to null
            if (requestSourceConfiguration_sourceConfiguration_AuthenticationConfigurationIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration != null)
            {
                request.SourceConfiguration.AuthenticationConfiguration = requestSourceConfiguration_sourceConfiguration_AuthenticationConfiguration;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.AppRunner.Model.CodeRepository requestSourceConfiguration_sourceConfiguration_CodeRepository = null;
            
             // populate CodeRepository
            var requestSourceConfiguration_sourceConfiguration_CodeRepositoryIsNull = true;
            requestSourceConfiguration_sourceConfiguration_CodeRepository = new Amazon.AppRunner.Model.CodeRepository();
            System.String requestSourceConfiguration_sourceConfiguration_CodeRepository_codeRepository_RepositoryUrl = null;
            if (cmdletContext.CodeRepository_RepositoryUrl != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_codeRepository_RepositoryUrl = cmdletContext.CodeRepository_RepositoryUrl;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_codeRepository_RepositoryUrl != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository.RepositoryUrl = requestSourceConfiguration_sourceConfiguration_CodeRepository_codeRepository_RepositoryUrl;
                requestSourceConfiguration_sourceConfiguration_CodeRepositoryIsNull = false;
            }
            Amazon.AppRunner.Model.CodeConfiguration requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration = null;
            
             // populate CodeConfiguration
            var requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfigurationIsNull = true;
            requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration = new Amazon.AppRunner.Model.CodeConfiguration();
            Amazon.AppRunner.ConfigurationSource requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_codeConfiguration_ConfigurationSource = null;
            if (cmdletContext.CodeConfiguration_ConfigurationSource != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_codeConfiguration_ConfigurationSource = cmdletContext.CodeConfiguration_ConfigurationSource;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_codeConfiguration_ConfigurationSource != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration.ConfigurationSource = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_codeConfiguration_ConfigurationSource;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfigurationIsNull = false;
            }
            Amazon.AppRunner.Model.CodeConfigurationValues requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues = null;
            
             // populate CodeConfigurationValues
            var requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull = true;
            requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues = new Amazon.AppRunner.Model.CodeConfigurationValues();
            System.String requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_BuildCommand = null;
            if (cmdletContext.CodeConfigurationValues_BuildCommand != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_BuildCommand = cmdletContext.CodeConfigurationValues_BuildCommand;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_BuildCommand != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues.BuildCommand = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_BuildCommand;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Port = null;
            if (cmdletContext.CodeConfigurationValues_Port != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Port = cmdletContext.CodeConfigurationValues_Port;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Port != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues.Port = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Port;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull = false;
            }
            Amazon.AppRunner.Runtime requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Runtime = null;
            if (cmdletContext.CodeConfigurationValues_Runtime != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Runtime = cmdletContext.CodeConfigurationValues_Runtime;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Runtime != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues.Runtime = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_Runtime;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull = false;
            }
            Dictionary<System.String, System.String> requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentSecret = null;
            if (cmdletContext.CodeConfigurationValues_RuntimeEnvironmentSecret != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentSecret = cmdletContext.CodeConfigurationValues_RuntimeEnvironmentSecret;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentSecret != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues.RuntimeEnvironmentSecrets = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentSecret;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull = false;
            }
            Dictionary<System.String, System.String> requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentVariable = null;
            if (cmdletContext.CodeConfigurationValues_RuntimeEnvironmentVariable != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentVariable = cmdletContext.CodeConfigurationValues_RuntimeEnvironmentVariable;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentVariable != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues.RuntimeEnvironmentVariables = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_RuntimeEnvironmentVariable;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_StartCommand = null;
            if (cmdletContext.CodeConfigurationValues_StartCommand != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_StartCommand = cmdletContext.CodeConfigurationValues_StartCommand;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_StartCommand != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues.StartCommand = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_codeConfigurationValues_StartCommand;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues should be set to null
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValuesIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration.CodeConfigurationValues = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration_sourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfigurationIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration should be set to null
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfigurationIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository.CodeConfiguration = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_CodeConfiguration;
                requestSourceConfiguration_sourceConfiguration_CodeRepositoryIsNull = false;
            }
            Amazon.AppRunner.Model.SourceCodeVersion requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion = null;
            
             // populate SourceCodeVersion
            var requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersionIsNull = true;
            requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion = new Amazon.AppRunner.Model.SourceCodeVersion();
            Amazon.AppRunner.SourceCodeVersionType requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Type = null;
            if (cmdletContext.SourceCodeVersion_Type != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Type = cmdletContext.SourceCodeVersion_Type;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Type != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion.Type = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Type;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersionIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Value = null;
            if (cmdletContext.SourceCodeVersion_Value != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Value = cmdletContext.SourceCodeVersion_Value;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Value != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion.Value = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion_sourceCodeVersion_Value;
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersionIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion should be set to null
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersionIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion != null)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository.SourceCodeVersion = requestSourceConfiguration_sourceConfiguration_CodeRepository_sourceConfiguration_CodeRepository_SourceCodeVersion;
                requestSourceConfiguration_sourceConfiguration_CodeRepositoryIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_CodeRepository should be set to null
            if (requestSourceConfiguration_sourceConfiguration_CodeRepositoryIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_CodeRepository = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_CodeRepository != null)
            {
                request.SourceConfiguration.CodeRepository = requestSourceConfiguration_sourceConfiguration_CodeRepository;
                requestSourceConfigurationIsNull = false;
            }
            Amazon.AppRunner.Model.ImageRepository requestSourceConfiguration_sourceConfiguration_ImageRepository = null;
            
             // populate ImageRepository
            var requestSourceConfiguration_sourceConfiguration_ImageRepositoryIsNull = true;
            requestSourceConfiguration_sourceConfiguration_ImageRepository = new Amazon.AppRunner.Model.ImageRepository();
            System.String requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageIdentifier = null;
            if (cmdletContext.ImageRepository_ImageIdentifier != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageIdentifier = cmdletContext.ImageRepository_ImageIdentifier;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageIdentifier != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository.ImageIdentifier = requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageIdentifier;
                requestSourceConfiguration_sourceConfiguration_ImageRepositoryIsNull = false;
            }
            Amazon.AppRunner.ImageRepositoryType requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageRepositoryType = null;
            if (cmdletContext.ImageRepository_ImageRepositoryType != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageRepositoryType = cmdletContext.ImageRepository_ImageRepositoryType;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageRepositoryType != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository.ImageRepositoryType = requestSourceConfiguration_sourceConfiguration_ImageRepository_imageRepository_ImageRepositoryType;
                requestSourceConfiguration_sourceConfiguration_ImageRepositoryIsNull = false;
            }
            Amazon.AppRunner.Model.ImageConfiguration requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration = null;
            
             // populate ImageConfiguration
            var requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfigurationIsNull = true;
            requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration = new Amazon.AppRunner.Model.ImageConfiguration();
            System.String requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_Port = null;
            if (cmdletContext.ImageConfiguration_Port != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_Port = cmdletContext.ImageConfiguration_Port;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_Port != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration.Port = requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_Port;
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentSecret = null;
            if (cmdletContext.ImageConfiguration_RuntimeEnvironmentSecret != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentSecret = cmdletContext.ImageConfiguration_RuntimeEnvironmentSecret;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentSecret != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration.RuntimeEnvironmentSecrets = requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentSecret;
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentVariable = null;
            if (cmdletContext.ImageConfiguration_RuntimeEnvironmentVariable != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentVariable = cmdletContext.ImageConfiguration_RuntimeEnvironmentVariable;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentVariable != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration.RuntimeEnvironmentVariables = requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_RuntimeEnvironmentVariable;
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfigurationIsNull = false;
            }
            System.String requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_StartCommand = null;
            if (cmdletContext.ImageConfiguration_StartCommand != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_StartCommand = cmdletContext.ImageConfiguration_StartCommand;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_StartCommand != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration.StartCommand = requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration_imageConfiguration_StartCommand;
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfigurationIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration should be set to null
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfigurationIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration != null)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository.ImageConfiguration = requestSourceConfiguration_sourceConfiguration_ImageRepository_sourceConfiguration_ImageRepository_ImageConfiguration;
                requestSourceConfiguration_sourceConfiguration_ImageRepositoryIsNull = false;
            }
             // determine if requestSourceConfiguration_sourceConfiguration_ImageRepository should be set to null
            if (requestSourceConfiguration_sourceConfiguration_ImageRepositoryIsNull)
            {
                requestSourceConfiguration_sourceConfiguration_ImageRepository = null;
            }
            if (requestSourceConfiguration_sourceConfiguration_ImageRepository != null)
            {
                request.SourceConfiguration.ImageRepository = requestSourceConfiguration_sourceConfiguration_ImageRepository;
                requestSourceConfigurationIsNull = false;
            }
             // determine if request.SourceConfiguration should be set to null
            if (requestSourceConfigurationIsNull)
            {
                request.SourceConfiguration = null;
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
        
        private Amazon.AppRunner.Model.CreateServiceResponse CallAWSServiceOperation(IAmazonAppRunner client, Amazon.AppRunner.Model.CreateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Runner", "CreateService");
            try
            {
                #if DESKTOP
                return client.CreateService(request);
                #elif CORECLR
                return client.CreateServiceAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingConfigurationArn { get; set; }
            public System.String EncryptionConfiguration_KmsKey { get; set; }
            public System.Int32? HealthCheckConfiguration_HealthyThreshold { get; set; }
            public System.Int32? HealthCheckConfiguration_Interval { get; set; }
            public System.String HealthCheckConfiguration_Path { get; set; }
            public Amazon.AppRunner.HealthCheckProtocol HealthCheckConfiguration_Protocol { get; set; }
            public System.Int32? HealthCheckConfiguration_Timeout { get; set; }
            public System.Int32? HealthCheckConfiguration_UnhealthyThreshold { get; set; }
            public System.String InstanceConfiguration_Cpu { get; set; }
            public System.String InstanceConfiguration_InstanceRoleArn { get; set; }
            public System.String InstanceConfiguration_Memory { get; set; }
            public Amazon.AppRunner.EgressType EgressConfiguration_EgressType { get; set; }
            public System.String EgressConfiguration_VpcConnectorArn { get; set; }
            public System.Boolean? IngressConfiguration_IsPubliclyAccessible { get; set; }
            public System.String ObservabilityConfiguration_ObservabilityConfigurationArn { get; set; }
            public System.Boolean? ObservabilityConfiguration_ObservabilityEnabled { get; set; }
            public System.String ServiceName { get; set; }
            public System.String AuthenticationConfiguration_AccessRoleArn { get; set; }
            public System.String AuthenticationConfiguration_ConnectionArn { get; set; }
            public System.Boolean? SourceConfiguration_AutoDeploymentsEnabled { get; set; }
            public System.String CodeConfigurationValues_BuildCommand { get; set; }
            public System.String CodeConfigurationValues_Port { get; set; }
            public Amazon.AppRunner.Runtime CodeConfigurationValues_Runtime { get; set; }
            public Dictionary<System.String, System.String> CodeConfigurationValues_RuntimeEnvironmentSecret { get; set; }
            public Dictionary<System.String, System.String> CodeConfigurationValues_RuntimeEnvironmentVariable { get; set; }
            public System.String CodeConfigurationValues_StartCommand { get; set; }
            public Amazon.AppRunner.ConfigurationSource CodeConfiguration_ConfigurationSource { get; set; }
            public System.String CodeRepository_RepositoryUrl { get; set; }
            public Amazon.AppRunner.SourceCodeVersionType SourceCodeVersion_Type { get; set; }
            public System.String SourceCodeVersion_Value { get; set; }
            public System.String ImageConfiguration_Port { get; set; }
            public Dictionary<System.String, System.String> ImageConfiguration_RuntimeEnvironmentSecret { get; set; }
            public Dictionary<System.String, System.String> ImageConfiguration_RuntimeEnvironmentVariable { get; set; }
            public System.String ImageConfiguration_StartCommand { get; set; }
            public System.String ImageRepository_ImageIdentifier { get; set; }
            public Amazon.AppRunner.ImageRepositoryType ImageRepository_ImageRepositoryType { get; set; }
            public List<Amazon.AppRunner.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.AppRunner.Model.CreateServiceResponse, NewAARServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
