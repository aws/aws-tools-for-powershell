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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a <c>Domain</c>. A domain consists of an associated Amazon Elastic File System
    /// volume, a list of authorized users, and a variety of security, application, policy,
    /// and Amazon Virtual Private Cloud (VPC) configurations. Users within a domain can share
    /// notebook files and other artifacts with each other.
    /// 
    ///  
    /// <para><b>EFS storage</b></para><para>
    /// When a domain is created, an EFS volume is created for use by all of the users within
    /// the domain. Each user receives a private home directory within the EFS volume for
    /// notebooks, Git repositories, and data files.
    /// </para><para>
    /// SageMaker AI uses the Amazon Web Services Key Management Service (Amazon Web Services
    /// KMS) to encrypt the EFS volume attached to the domain with an Amazon Web Services
    /// managed key by default. For more control, you can specify a customer managed key.
    /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/encryption-at-rest.html">Protect
    /// Data at Rest Using Encryption</a>.
    /// </para><para><b>VPC configuration</b></para><para>
    /// All traffic between the domain and the Amazon EFS volume is through the specified
    /// VPC and subnets. For other traffic, you can specify the <c>AppNetworkAccessType</c>
    /// parameter. <c>AppNetworkAccessType</c> corresponds to the network access type that
    /// you choose when you onboard to the domain. The following options are available:
    /// </para><ul><li><para><c>PublicInternetOnly</c> - Non-EFS traffic goes through a VPC managed by Amazon
    /// SageMaker AI, which allows internet access. This is the default value.
    /// </para></li><li><para><c>VpcOnly</c> - All traffic is through the specified VPC and subnets. Internet access
    /// is disabled by default. To allow internet access, you must specify a NAT gateway.
    /// </para><para>
    /// When internet access is disabled, you won't be able to run a Amazon SageMaker AI Studio
    /// notebook or to train or host models unless your VPC has an interface endpoint to the
    /// SageMaker AI API and runtime or a NAT gateway and your security groups allow outbound
    /// connections.
    /// </para></li></ul><important><para>
    /// NFS traffic over TCP on port 2049 needs to be allowed in both inbound and outbound
    /// rules in order to launch a Amazon SageMaker AI Studio app successfully.
    /// </para></important><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/studio-notebooks-and-internet-access.html">Connect
    /// Amazon SageMaker AI Studio Notebooks to Resources in a VPC</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.CreateDomainResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateDomain API operation.", Operation = new[] {"CreateDomain"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateDomainResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.CreateDomainResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.CreateDomainResponse object containing multiple properties."
    )]
    public partial class NewSMDomainCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppNetworkAccessType
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC used for non-EFS traffic. The default value is <c>PublicInternetOnly</c>.</para><ul><li><para><c>PublicInternetOnly</c> - Non-EFS traffic is through a VPC managed by Amazon SageMaker
        /// AI, which allows direct internet access</para></li><li><para><c>VpcOnly</c> - All traffic is through the specified VPC and subnets</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AppNetworkAccessType")]
        public Amazon.SageMaker.AppNetworkAccessType AppNetworkAccessType { get; set; }
        #endregion
        
        #region Parameter AppSecurityGroupManagement
        /// <summary>
        /// <para>
        /// <para>The entity that creates and manages the required security groups for inter-app communication
        /// in <c>VPCOnly</c> mode. Required when <c>CreateDomain.AppNetworkAccessType</c> is
        /// <c>VPCOnly</c> and <c>DomainSettings.RStudioServerProDomainSettings.DomainExecutionRoleArn</c>
        /// is provided. If setting up the domain for use with RStudio, this value must be set
        /// to <c>Service</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AppSecurityGroupManagement")]
        public Amazon.SageMaker.AppSecurityGroupManagement AppSecurityGroupManagement { get; set; }
        #endregion
        
        #region Parameter EmrSettings_AssumableRoleArn
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Resource Names (ARNs) of the IAM roles that the execution role
        /// of SageMaker can assume for performing operations or tasks related to Amazon EMR clusters
        /// or Amazon EMR Serverless applications. These roles define the permissions and access
        /// policies required when performing Amazon EMR-related operations, such as listing,
        /// connecting to, or terminating Amazon EMR clusters or Amazon EMR Serverless applications.
        /// They are typically used in cross-account access scenarios, where the Amazon EMR resources
        /// (clusters or serverless applications) are located in a different Amazon Web Services
        /// account than the SageMaker domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_EmrSettings_AssumableRoleArns")]
        public System.String[] EmrSettings_AssumableRoleArn { get; set; }
        #endregion
        
        #region Parameter AuthMode
        /// <summary>
        /// <para>
        /// <para>The mode of authentication that members use to access the domain.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SageMaker.AuthMode")]
        public Amazon.SageMaker.AuthMode AuthMode { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppSettings_BuiltInLifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para>The lifecycle configuration that runs before the default lifecycle configuration.
        /// It can override changes made in the default lifecycle configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_BuiltInLifecycleConfigArn")]
        public System.String JupyterLabAppSettings_BuiltInLifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppSettings_CodeRepository
        /// <summary>
        /// <para>
        /// <para>A list of Git repositories that SageMaker automatically displays to users for cloning
        /// in the JupyterLab application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_CodeRepositories")]
        public Amazon.SageMaker.Model.CodeRepository[] JupyterLabAppSettings_CodeRepository { get; set; }
        #endregion
        
        #region Parameter JupyterServerAppSettings_CodeRepository
        /// <summary>
        /// <para>
        /// <para>A list of Git repositories that SageMaker AI automatically displays to users for cloning
        /// in the JupyterServer application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterServerAppSettings_CodeRepositories")]
        public Amazon.SageMaker.Model.CodeRepository[] JupyterServerAppSettings_CodeRepository { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_CustomFileSystemConfig
        /// <summary>
        /// <para>
        /// <para>The settings for assigning a custom file system to a domain. Permitted users can access
        /// this file system in Amazon SageMaker AI Studio.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_CustomFileSystemConfigs")]
        public Amazon.SageMaker.Model.CustomFileSystemConfig[] DefaultSpaceSettings_CustomFileSystemConfig { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppSettings_CustomImage
        /// <summary>
        /// <para>
        /// <para>A list of custom SageMaker images that are configured to run as a JupyterLab app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_CustomImages")]
        public Amazon.SageMaker.Model.CustomImage[] JupyterLabAppSettings_CustomImage { get; set; }
        #endregion
        
        #region Parameter KernelGatewayAppSettings_CustomImage
        /// <summary>
        /// <para>
        /// <para>A list of custom SageMaker AI images that are configured to run as a KernelGateway
        /// app.</para><para>The maximum number of custom images are as follows.</para><ul><li><para>On a domain level: 200</para></li><li><para>On a space level: 5</para></li><li><para>On a user profile level: 5</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_KernelGatewayAppSettings_CustomImages")]
        public Amazon.SageMaker.Model.CustomImage[] KernelGatewayAppSettings_CustomImage { get; set; }
        #endregion
        
        #region Parameter DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb
        /// <summary>
        /// <para>
        /// <para>The default size of the EBS storage volume for a space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb")]
        public System.Int32? DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb { get; set; }
        #endregion
        
        #region Parameter DefaultUserSetting
        /// <summary>
        /// <para>
        /// <para>The default settings to use to create a user profile when <c>UserSettings</c> isn't
        /// specified in the call to the <c>CreateUserProfile</c> API.</para><para><c>SecurityGroups</c> is aggregated when specified in both calls. For all other settings
        /// in <c>UserSettings</c>, the values specified in <c>CreateUserProfile</c> take precedence
        /// over those specified in <c>CreateDomain</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DefaultUserSettings")]
        public Amazon.SageMaker.Model.UserSettings DefaultUserSetting { get; set; }
        #endregion
        
        #region Parameter RStudioServerProDomainSettings_DomainExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the execution role for the <c>RStudioServerPro</c> Domain-level app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_RStudioServerProDomainSettings_DomainExecutionRoleArn")]
        public System.String RStudioServerProDomainSettings_DomainExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>A name for the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DockerSettings_EnableDockerAccess
        /// <summary>
        /// <para>
        /// <para>Indicates whether the domain can access Docker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_DockerSettings_EnableDockerAccess")]
        [AWSConstantClassSource("Amazon.SageMaker.FeatureStatus")]
        public Amazon.SageMaker.FeatureStatus DockerSettings_EnableDockerAccess { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the execution role for the space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_ExecutionRole { get; set; }
        #endregion
        
        #region Parameter EmrSettings_ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>An array of Amazon Resource Names (ARNs) of the IAM roles used by the Amazon EMR cluster
        /// instances or job execution environments to access other Amazon Web Services services
        /// and resources needed during the runtime of your Amazon EMR or Amazon EMR Serverless
        /// workloads, such as Amazon S3 for data access, Amazon CloudWatch for logging, or other
        /// Amazon Web Services services based on the particular workload requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_EmrSettings_ExecutionRoleArns")]
        public System.String[] EmrSettings_ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter DomainSettings_ExecutionRoleIdentityConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for attaching a SageMaker AI user profile name to the execution
        /// role as a <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_control-access_monitor.html">sts:SourceIdentity
        /// key</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ExecutionRoleIdentityConfig")]
        public Amazon.SageMaker.ExecutionRoleIdentityConfig DomainSettings_ExecutionRoleIdentityConfig { get; set; }
        #endregion
        
        #region Parameter CustomPosixUserConfig_Gid
        /// <summary>
        /// <para>
        /// <para>The POSIX group ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_CustomPosixUserConfig_Gid")]
        public System.Int64? CustomPosixUserConfig_Gid { get; set; }
        #endregion
        
        #region Parameter IdleSettings_IdleTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The time that SageMaker waits after the application becomes idle before shutting it
        /// down.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_IdleTimeoutInMinutes")]
        public System.Int32? IdleSettings_IdleTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>SageMaker AI uses Amazon Web Services KMS to encrypt EFS and EBS volumes attached
        /// to the domain with an Amazon Web Services managed key by default. For more control,
        /// specify a customer managed key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_LifecycleConfigArn")]
        public System.String DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppSettings_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the lifecycle configurations attached to the user
        /// profile or domain. To remove a lifecycle config, you must set <c>LifecycleConfigArns</c>
        /// to an empty list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_LifecycleConfigArns")]
        public System.String[] JupyterLabAppSettings_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter JupyterServerAppSettings_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configurations attached to the JupyterServerApp.
        /// If you use this parameter, the <c>DefaultResourceSpec</c> parameter is also required.</para><note><para>To remove a Lifecycle Config, you must set <c>LifecycleConfigArns</c> to an empty
        /// list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterServerAppSettings_LifecycleConfigArns")]
        public System.String[] JupyterServerAppSettings_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter KernelGatewayAppSettings_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configurations attached to the the
        /// user profile or domain.</para><note><para>To remove a Lifecycle Config, you must set <c>LifecycleConfigArns</c> to an empty
        /// list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_KernelGatewayAppSettings_LifecycleConfigArns")]
        public System.String[] KernelGatewayAppSettings_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter IdleSettings_LifecycleManagement
        /// <summary>
        /// <para>
        /// <para>Indicates whether idle shutdown is activated for the application type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_LifecycleManagement")]
        [AWSConstantClassSource("Amazon.SageMaker.LifecycleManagement")]
        public Amazon.SageMaker.LifecycleManagement IdleSettings_LifecycleManagement { get; set; }
        #endregion
        
        #region Parameter IdleSettings_MaxIdleTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The maximum value in minutes that custom idle shutdown can be set to by the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_MaxIdleTimeoutInMinutes")]
        public System.Int32? IdleSettings_MaxIdleTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb
        /// <summary>
        /// <para>
        /// <para>The maximum size of the EBS storage volume for a space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb")]
        public System.Int32? DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb { get; set; }
        #endregion
        
        #region Parameter IdleSettings_MinIdleTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The minimum value in minutes that custom idle shutdown can be set to by the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_MinIdleTimeoutInMinutes")]
        public System.Int32? IdleSettings_MinIdleTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter AmazonQSettings_QProfileArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Q profile used within the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_AmazonQSettings_QProfileArn")]
        public System.String AmazonQSettings_QProfileArn { get; set; }
        #endregion
        
        #region Parameter RStudioServerProDomainSettings_RStudioConnectUrl
        /// <summary>
        /// <para>
        /// <para>A URL pointing to an RStudio Connect server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_RStudioServerProDomainSettings_RStudioConnectUrl")]
        public System.String RStudioServerProDomainSettings_RStudioConnectUrl { get; set; }
        #endregion
        
        #region Parameter RStudioServerProDomainSettings_RStudioPackageManagerUrl
        /// <summary>
        /// <para>
        /// <para>A URL pointing to an RStudio Package Manager server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_RStudioServerProDomainSettings_RStudioPackageManagerUrl")]
        public System.String RStudioServerProDomainSettings_RStudioPackageManagerUrl { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker AI image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker AI image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker AI image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker AI image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageArn")]
        public System.String DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias")]
        public System.String DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance. To clear the value set for <c>SageMakerImageVersionArn</c>,
        /// pass <c>None</c> as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance. To clear the value set for <c>SageMakerImageVersionArn</c>,
        /// pass <c>None</c> as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance. To clear the value set for <c>SageMakerImageVersionArn</c>,
        /// pass <c>None</c> as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance. To clear the value set for <c>SageMakerImageVersionArn</c>,
        /// pass <c>None</c> as the value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DomainSettings_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The security groups for the Amazon Virtual Private Cloud that the <c>Domain</c> uses
        /// for communication between Domain-level apps and user apps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_SecurityGroupIds")]
        public System.String[] DomainSettings_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security group IDs for the Amazon VPC that the space uses for communication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_SecurityGroups")]
        public System.String[] DefaultSpaceSettings_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter AmazonQSettings_Status
        /// <summary>
        /// <para>
        /// <para>Whether Amazon Q has been enabled within the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_AmazonQSettings_Status")]
        [AWSConstantClassSource("Amazon.SageMaker.FeatureStatus")]
        public Amazon.SageMaker.FeatureStatus AmazonQSettings_Status { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The VPC subnets that the domain uses for communication.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter TagPropagation
        /// <summary>
        /// <para>
        /// <para>Indicates whether custom tag propagation is supported for the domain. Defaults to
        /// <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.TagPropagation")]
        public Amazon.SageMaker.TagPropagation TagPropagation { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associated with the Domain. Each tag consists of a key and an optional value.
        /// Tag keys must be unique per resource. Tags are searchable using the <c>Search</c>
        /// API.</para><para>Tags that you specify for the Domain are also added to all Apps that the Domain launches.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter CustomPosixUserConfig_Uid
        /// <summary>
        /// <para>
        /// <para>The POSIX user ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_CustomPosixUserConfig_Uid")]
        public System.Int64? CustomPosixUserConfig_Uid { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Virtual Private Cloud (VPC) that the domain uses for communication.</para>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter DockerSettings_VpcOnlyTrustedAccount
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Web Services accounts that are trusted when the domain is created
        /// in VPC-only mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettings_DockerSettings_VpcOnlyTrustedAccounts")]
        public System.String[] DockerSettings_VpcOnlyTrustedAccount { get; set; }
        #endregion
        
        #region Parameter HomeEfsFileSystemKmsKeyId
        /// <summary>
        /// <para>
        /// <para>Use <c>KmsKeyId</c>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This property is deprecated, use KmsKeyId instead.")]
        public System.String HomeEfsFileSystemKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateDomainResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateDomainResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMDomain (CreateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateDomainResponse, NewSMDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppNetworkAccessType = this.AppNetworkAccessType;
            context.AppSecurityGroupManagement = this.AppSecurityGroupManagement;
            context.AuthMode = this.AuthMode;
            #if MODULAR
            if (this.AuthMode == null && ParameterWasBound(nameof(this.AuthMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DefaultSpaceSettings_CustomFileSystemConfig != null)
            {
                context.DefaultSpaceSettings_CustomFileSystemConfig = new List<Amazon.SageMaker.Model.CustomFileSystemConfig>(this.DefaultSpaceSettings_CustomFileSystemConfig);
            }
            context.CustomPosixUserConfig_Gid = this.CustomPosixUserConfig_Gid;
            context.CustomPosixUserConfig_Uid = this.CustomPosixUserConfig_Uid;
            context.DefaultSpaceSettings_ExecutionRole = this.DefaultSpaceSettings_ExecutionRole;
            context.IdleSettings_IdleTimeoutInMinute = this.IdleSettings_IdleTimeoutInMinute;
            context.IdleSettings_LifecycleManagement = this.IdleSettings_LifecycleManagement;
            context.IdleSettings_MaxIdleTimeoutInMinute = this.IdleSettings_MaxIdleTimeoutInMinute;
            context.IdleSettings_MinIdleTimeoutInMinute = this.IdleSettings_MinIdleTimeoutInMinute;
            context.JupyterLabAppSettings_BuiltInLifecycleConfigArn = this.JupyterLabAppSettings_BuiltInLifecycleConfigArn;
            if (this.JupyterLabAppSettings_CodeRepository != null)
            {
                context.JupyterLabAppSettings_CodeRepository = new List<Amazon.SageMaker.Model.CodeRepository>(this.JupyterLabAppSettings_CodeRepository);
            }
            if (this.JupyterLabAppSettings_CustomImage != null)
            {
                context.JupyterLabAppSettings_CustomImage = new List<Amazon.SageMaker.Model.CustomImage>(this.JupyterLabAppSettings_CustomImage);
            }
            context.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType = this.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType;
            context.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn = this.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            context.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn = this.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn;
            context.DefaultResourceSpec_SageMakerImageVersionAlias = this.DefaultResourceSpec_SageMakerImageVersionAlias;
            context.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = this.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            if (this.EmrSettings_AssumableRoleArn != null)
            {
                context.EmrSettings_AssumableRoleArn = new List<System.String>(this.EmrSettings_AssumableRoleArn);
            }
            if (this.EmrSettings_ExecutionRoleArn != null)
            {
                context.EmrSettings_ExecutionRoleArn = new List<System.String>(this.EmrSettings_ExecutionRoleArn);
            }
            if (this.JupyterLabAppSettings_LifecycleConfigArn != null)
            {
                context.JupyterLabAppSettings_LifecycleConfigArn = new List<System.String>(this.JupyterLabAppSettings_LifecycleConfigArn);
            }
            if (this.JupyterServerAppSettings_CodeRepository != null)
            {
                context.JupyterServerAppSettings_CodeRepository = new List<Amazon.SageMaker.Model.CodeRepository>(this.JupyterServerAppSettings_CodeRepository);
            }
            context.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType = this.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType;
            context.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn = this.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            context.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn = this.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn;
            context.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = this.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = this.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            if (this.JupyterServerAppSettings_LifecycleConfigArn != null)
            {
                context.JupyterServerAppSettings_LifecycleConfigArn = new List<System.String>(this.JupyterServerAppSettings_LifecycleConfigArn);
            }
            if (this.KernelGatewayAppSettings_CustomImage != null)
            {
                context.KernelGatewayAppSettings_CustomImage = new List<Amazon.SageMaker.Model.CustomImage>(this.KernelGatewayAppSettings_CustomImage);
            }
            context.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType = this.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType;
            context.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn = this.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            context.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn = this.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn;
            context.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = this.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = this.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            if (this.KernelGatewayAppSettings_LifecycleConfigArn != null)
            {
                context.KernelGatewayAppSettings_LifecycleConfigArn = new List<System.String>(this.KernelGatewayAppSettings_LifecycleConfigArn);
            }
            if (this.DefaultSpaceSettings_SecurityGroup != null)
            {
                context.DefaultSpaceSettings_SecurityGroup = new List<System.String>(this.DefaultSpaceSettings_SecurityGroup);
            }
            context.DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb = this.DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb;
            context.DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb = this.DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb;
            context.DefaultUserSetting = this.DefaultUserSetting;
            #if MODULAR
            if (this.DefaultUserSetting == null && ParameterWasBound(nameof(this.DefaultUserSetting)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultUserSetting which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AmazonQSettings_QProfileArn = this.AmazonQSettings_QProfileArn;
            context.AmazonQSettings_Status = this.AmazonQSettings_Status;
            context.DockerSettings_EnableDockerAccess = this.DockerSettings_EnableDockerAccess;
            if (this.DockerSettings_VpcOnlyTrustedAccount != null)
            {
                context.DockerSettings_VpcOnlyTrustedAccount = new List<System.String>(this.DockerSettings_VpcOnlyTrustedAccount);
            }
            context.DomainSettings_ExecutionRoleIdentityConfig = this.DomainSettings_ExecutionRoleIdentityConfig;
            context.DefaultResourceSpec_InstanceType = this.DefaultResourceSpec_InstanceType;
            context.DefaultResourceSpec_LifecycleConfigArn = this.DefaultResourceSpec_LifecycleConfigArn;
            context.DefaultResourceSpec_SageMakerImageArn = this.DefaultResourceSpec_SageMakerImageArn;
            context.DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias = this.DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.DefaultResourceSpec_SageMakerImageVersionArn = this.DefaultResourceSpec_SageMakerImageVersionArn;
            context.RStudioServerProDomainSettings_DomainExecutionRoleArn = this.RStudioServerProDomainSettings_DomainExecutionRoleArn;
            context.RStudioServerProDomainSettings_RStudioConnectUrl = this.RStudioServerProDomainSettings_RStudioConnectUrl;
            context.RStudioServerProDomainSettings_RStudioPackageManagerUrl = this.RStudioServerProDomainSettings_RStudioPackageManagerUrl;
            if (this.DomainSettings_SecurityGroupId != null)
            {
                context.DomainSettings_SecurityGroupId = new List<System.String>(this.DomainSettings_SecurityGroupId);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HomeEfsFileSystemKmsKeyId = this.HomeEfsFileSystemKmsKeyId;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KmsKeyId = this.KmsKeyId;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TagPropagation = this.TagPropagation;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreateDomainRequest();
            
            if (cmdletContext.AppNetworkAccessType != null)
            {
                request.AppNetworkAccessType = cmdletContext.AppNetworkAccessType;
            }
            if (cmdletContext.AppSecurityGroupManagement != null)
            {
                request.AppSecurityGroupManagement = cmdletContext.AppSecurityGroupManagement;
            }
            if (cmdletContext.AuthMode != null)
            {
                request.AuthMode = cmdletContext.AuthMode;
            }
            
             // populate DefaultSpaceSettings
            var requestDefaultSpaceSettingsIsNull = true;
            request.DefaultSpaceSettings = new Amazon.SageMaker.Model.DefaultSpaceSettings();
            List<Amazon.SageMaker.Model.CustomFileSystemConfig> requestDefaultSpaceSettings_defaultSpaceSettings_CustomFileSystemConfig = null;
            if (cmdletContext.DefaultSpaceSettings_CustomFileSystemConfig != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomFileSystemConfig = cmdletContext.DefaultSpaceSettings_CustomFileSystemConfig;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_CustomFileSystemConfig != null)
            {
                request.DefaultSpaceSettings.CustomFileSystemConfigs = requestDefaultSpaceSettings_defaultSpaceSettings_CustomFileSystemConfig;
                requestDefaultSpaceSettingsIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_ExecutionRole = null;
            if (cmdletContext.DefaultSpaceSettings_ExecutionRole != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_ExecutionRole = cmdletContext.DefaultSpaceSettings_ExecutionRole;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_ExecutionRole != null)
            {
                request.DefaultSpaceSettings.ExecutionRole = requestDefaultSpaceSettings_defaultSpaceSettings_ExecutionRole;
                requestDefaultSpaceSettingsIsNull = false;
            }
            List<System.String> requestDefaultSpaceSettings_defaultSpaceSettings_SecurityGroup = null;
            if (cmdletContext.DefaultSpaceSettings_SecurityGroup != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SecurityGroup = cmdletContext.DefaultSpaceSettings_SecurityGroup;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_SecurityGroup != null)
            {
                request.DefaultSpaceSettings.SecurityGroups = requestDefaultSpaceSettings_defaultSpaceSettings_SecurityGroup;
                requestDefaultSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.DefaultSpaceStorageSettings requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings = null;
            
             // populate SpaceStorageSettings
            var requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettingsIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings = new Amazon.SageMaker.Model.DefaultSpaceStorageSettings();
            Amazon.SageMaker.Model.DefaultEbsStorageSettings requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings = null;
            
             // populate DefaultEbsStorageSettings
            var requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettingsIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings = new Amazon.SageMaker.Model.DefaultEbsStorageSettings();
            System.Int32? requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_DefaultEbsVolumeSizeInGb = null;
            if (cmdletContext.DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_DefaultEbsVolumeSizeInGb = cmdletContext.DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb.Value;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_DefaultEbsVolumeSizeInGb != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings.DefaultEbsVolumeSizeInGb = requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_DefaultEbsVolumeSizeInGb.Value;
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettingsIsNull = false;
            }
            System.Int32? requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_MaximumEbsVolumeSizeInGb = null;
            if (cmdletContext.DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_MaximumEbsVolumeSizeInGb = cmdletContext.DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb.Value;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_MaximumEbsVolumeSizeInGb != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings.MaximumEbsVolumeSizeInGb = requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings_defaultEbsStorageSettings_MaximumEbsVolumeSizeInGb.Value;
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettingsIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettingsIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings.DefaultEbsStorageSettings = requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings_defaultSpaceSettings_SpaceStorageSettings_DefaultEbsStorageSettings;
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettingsIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettingsIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings != null)
            {
                request.DefaultSpaceSettings.SpaceStorageSettings = requestDefaultSpaceSettings_defaultSpaceSettings_SpaceStorageSettings;
                requestDefaultSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.CustomPosixUserConfig requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig = null;
            
             // populate CustomPosixUserConfig
            var requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfigIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig = new Amazon.SageMaker.Model.CustomPosixUserConfig();
            System.Int64? requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Gid = null;
            if (cmdletContext.CustomPosixUserConfig_Gid != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Gid = cmdletContext.CustomPosixUserConfig_Gid.Value;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Gid != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig.Gid = requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Gid.Value;
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfigIsNull = false;
            }
            System.Int64? requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Uid = null;
            if (cmdletContext.CustomPosixUserConfig_Uid != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Uid = cmdletContext.CustomPosixUserConfig_Uid.Value;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Uid != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig.Uid = requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig_customPosixUserConfig_Uid.Value;
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfigIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfigIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig != null)
            {
                request.DefaultSpaceSettings.CustomPosixUserConfig = requestDefaultSpaceSettings_defaultSpaceSettings_CustomPosixUserConfig;
                requestDefaultSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.JupyterServerAppSettings requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings = null;
            
             // populate JupyterServerAppSettings
            var requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettingsIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings = new Amazon.SageMaker.Model.JupyterServerAppSettings();
            List<Amazon.SageMaker.Model.CodeRepository> requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository = null;
            if (cmdletContext.JupyterServerAppSettings_CodeRepository != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository = cmdletContext.JupyterServerAppSettings_CodeRepository;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings.CodeRepositories = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettingsIsNull = false;
            }
            List<System.String> requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn = null;
            if (cmdletContext.JupyterServerAppSettings_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn = cmdletContext.JupyterServerAppSettings_LifecycleConfigArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings.LifecycleConfigArns = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType = cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec.InstanceType = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn = cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec.LifecycleConfigArn = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn = cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec.SageMakerImageArn = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = cmdletContext.DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings.DefaultResourceSpec = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings_defaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettingsIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettingsIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings != null)
            {
                request.DefaultSpaceSettings.JupyterServerAppSettings = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterServerAppSettings;
                requestDefaultSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.KernelGatewayAppSettings requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings = null;
            
             // populate KernelGatewayAppSettings
            var requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettingsIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings = new Amazon.SageMaker.Model.KernelGatewayAppSettings();
            List<Amazon.SageMaker.Model.CustomImage> requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage = null;
            if (cmdletContext.KernelGatewayAppSettings_CustomImage != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage = cmdletContext.KernelGatewayAppSettings_CustomImage;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings.CustomImages = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettingsIsNull = false;
            }
            List<System.String> requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn = null;
            if (cmdletContext.KernelGatewayAppSettings_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn = cmdletContext.KernelGatewayAppSettings_LifecycleConfigArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings.LifecycleConfigArns = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType = null;
            if (cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType = cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.InstanceType = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn = cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.LifecycleConfigArn = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn = cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.SageMakerImageArn = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = cmdletContext.DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings.DefaultResourceSpec = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings_defaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec;
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettingsIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettingsIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings != null)
            {
                request.DefaultSpaceSettings.KernelGatewayAppSettings = requestDefaultSpaceSettings_defaultSpaceSettings_KernelGatewayAppSettings;
                requestDefaultSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.JupyterLabAppSettings requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings = null;
            
             // populate JupyterLabAppSettings
            var requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings = new Amazon.SageMaker.Model.JupyterLabAppSettings();
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_BuiltInLifecycleConfigArn = null;
            if (cmdletContext.JupyterLabAppSettings_BuiltInLifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_BuiltInLifecycleConfigArn = cmdletContext.JupyterLabAppSettings_BuiltInLifecycleConfigArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_BuiltInLifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings.BuiltInLifecycleConfigArn = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_BuiltInLifecycleConfigArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = false;
            }
            List<Amazon.SageMaker.Model.CodeRepository> requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository = null;
            if (cmdletContext.JupyterLabAppSettings_CodeRepository != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository = cmdletContext.JupyterLabAppSettings_CodeRepository;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings.CodeRepositories = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = false;
            }
            List<Amazon.SageMaker.Model.CustomImage> requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CustomImage = null;
            if (cmdletContext.JupyterLabAppSettings_CustomImage != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CustomImage = cmdletContext.JupyterLabAppSettings_CustomImage;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CustomImage != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings.CustomImages = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CustomImage;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = false;
            }
            List<System.String> requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_LifecycleConfigArn = null;
            if (cmdletContext.JupyterLabAppSettings_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_LifecycleConfigArn = cmdletContext.JupyterLabAppSettings_LifecycleConfigArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings.LifecycleConfigArns = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_LifecycleConfigArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.AppLifecycleManagement requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement = null;
            
             // populate AppLifecycleManagement
            var requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagementIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement = new Amazon.SageMaker.Model.AppLifecycleManagement();
            Amazon.SageMaker.Model.IdleSettings requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings = null;
            
             // populate IdleSettings
            var requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettingsIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings = new Amazon.SageMaker.Model.IdleSettings();
            System.Int32? requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_IdleTimeoutInMinute = null;
            if (cmdletContext.IdleSettings_IdleTimeoutInMinute != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_IdleTimeoutInMinute = cmdletContext.IdleSettings_IdleTimeoutInMinute.Value;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_IdleTimeoutInMinute != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings.IdleTimeoutInMinutes = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_IdleTimeoutInMinute.Value;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettingsIsNull = false;
            }
            Amazon.SageMaker.LifecycleManagement requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_LifecycleManagement = null;
            if (cmdletContext.IdleSettings_LifecycleManagement != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_LifecycleManagement = cmdletContext.IdleSettings_LifecycleManagement;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_LifecycleManagement != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings.LifecycleManagement = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_LifecycleManagement;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettingsIsNull = false;
            }
            System.Int32? requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MaxIdleTimeoutInMinute = null;
            if (cmdletContext.IdleSettings_MaxIdleTimeoutInMinute != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MaxIdleTimeoutInMinute = cmdletContext.IdleSettings_MaxIdleTimeoutInMinute.Value;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MaxIdleTimeoutInMinute != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings.MaxIdleTimeoutInMinutes = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MaxIdleTimeoutInMinute.Value;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettingsIsNull = false;
            }
            System.Int32? requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MinIdleTimeoutInMinute = null;
            if (cmdletContext.IdleSettings_MinIdleTimeoutInMinute != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MinIdleTimeoutInMinute = cmdletContext.IdleSettings_MinIdleTimeoutInMinute.Value;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MinIdleTimeoutInMinute != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings.MinIdleTimeoutInMinutes = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings_idleSettings_MinIdleTimeoutInMinute.Value;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettingsIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettingsIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement.IdleSettings = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement_IdleSettings;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagementIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagementIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings.AppLifecycleManagement = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_AppLifecycleManagement;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.EmrSettings requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings = null;
            
             // populate EmrSettings
            var requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettingsIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings = new Amazon.SageMaker.Model.EmrSettings();
            List<System.String> requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_AssumableRoleArn = null;
            if (cmdletContext.EmrSettings_AssumableRoleArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_AssumableRoleArn = cmdletContext.EmrSettings_AssumableRoleArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_AssumableRoleArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings.AssumableRoleArns = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_AssumableRoleArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettingsIsNull = false;
            }
            List<System.String> requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_ExecutionRoleArn = null;
            if (cmdletContext.EmrSettings_ExecutionRoleArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_ExecutionRoleArn = cmdletContext.EmrSettings_ExecutionRoleArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_ExecutionRoleArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings.ExecutionRoleArns = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings_emrSettings_ExecutionRoleArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettingsIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettingsIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings.EmrSettings = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_EmrSettings;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = true;
            requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType = cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec.InstanceType = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn = cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec.LifecycleConfigArn = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn = cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec.SageMakerImageArn = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionAlias;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = cmdletContext.DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec != null)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings.DefaultResourceSpec = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings_defaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec;
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull = false;
            }
             // determine if requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings should be set to null
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettingsIsNull)
            {
                requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings = null;
            }
            if (requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings != null)
            {
                request.DefaultSpaceSettings.JupyterLabAppSettings = requestDefaultSpaceSettings_defaultSpaceSettings_JupyterLabAppSettings;
                requestDefaultSpaceSettingsIsNull = false;
            }
             // determine if request.DefaultSpaceSettings should be set to null
            if (requestDefaultSpaceSettingsIsNull)
            {
                request.DefaultSpaceSettings = null;
            }
            if (cmdletContext.DefaultUserSetting != null)
            {
                request.DefaultUserSettings = cmdletContext.DefaultUserSetting;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate DomainSettings
            var requestDomainSettingsIsNull = true;
            request.DomainSettings = new Amazon.SageMaker.Model.DomainSettings();
            Amazon.SageMaker.ExecutionRoleIdentityConfig requestDomainSettings_domainSettings_ExecutionRoleIdentityConfig = null;
            if (cmdletContext.DomainSettings_ExecutionRoleIdentityConfig != null)
            {
                requestDomainSettings_domainSettings_ExecutionRoleIdentityConfig = cmdletContext.DomainSettings_ExecutionRoleIdentityConfig;
            }
            if (requestDomainSettings_domainSettings_ExecutionRoleIdentityConfig != null)
            {
                request.DomainSettings.ExecutionRoleIdentityConfig = requestDomainSettings_domainSettings_ExecutionRoleIdentityConfig;
                requestDomainSettingsIsNull = false;
            }
            List<System.String> requestDomainSettings_domainSettings_SecurityGroupId = null;
            if (cmdletContext.DomainSettings_SecurityGroupId != null)
            {
                requestDomainSettings_domainSettings_SecurityGroupId = cmdletContext.DomainSettings_SecurityGroupId;
            }
            if (requestDomainSettings_domainSettings_SecurityGroupId != null)
            {
                request.DomainSettings.SecurityGroupIds = requestDomainSettings_domainSettings_SecurityGroupId;
                requestDomainSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.AmazonQSettings requestDomainSettings_domainSettings_AmazonQSettings = null;
            
             // populate AmazonQSettings
            var requestDomainSettings_domainSettings_AmazonQSettingsIsNull = true;
            requestDomainSettings_domainSettings_AmazonQSettings = new Amazon.SageMaker.Model.AmazonQSettings();
            System.String requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_QProfileArn = null;
            if (cmdletContext.AmazonQSettings_QProfileArn != null)
            {
                requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_QProfileArn = cmdletContext.AmazonQSettings_QProfileArn;
            }
            if (requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_QProfileArn != null)
            {
                requestDomainSettings_domainSettings_AmazonQSettings.QProfileArn = requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_QProfileArn;
                requestDomainSettings_domainSettings_AmazonQSettingsIsNull = false;
            }
            Amazon.SageMaker.FeatureStatus requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_Status = null;
            if (cmdletContext.AmazonQSettings_Status != null)
            {
                requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_Status = cmdletContext.AmazonQSettings_Status;
            }
            if (requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_Status != null)
            {
                requestDomainSettings_domainSettings_AmazonQSettings.Status = requestDomainSettings_domainSettings_AmazonQSettings_amazonQSettings_Status;
                requestDomainSettings_domainSettings_AmazonQSettingsIsNull = false;
            }
             // determine if requestDomainSettings_domainSettings_AmazonQSettings should be set to null
            if (requestDomainSettings_domainSettings_AmazonQSettingsIsNull)
            {
                requestDomainSettings_domainSettings_AmazonQSettings = null;
            }
            if (requestDomainSettings_domainSettings_AmazonQSettings != null)
            {
                request.DomainSettings.AmazonQSettings = requestDomainSettings_domainSettings_AmazonQSettings;
                requestDomainSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.DockerSettings requestDomainSettings_domainSettings_DockerSettings = null;
            
             // populate DockerSettings
            var requestDomainSettings_domainSettings_DockerSettingsIsNull = true;
            requestDomainSettings_domainSettings_DockerSettings = new Amazon.SageMaker.Model.DockerSettings();
            Amazon.SageMaker.FeatureStatus requestDomainSettings_domainSettings_DockerSettings_dockerSettings_EnableDockerAccess = null;
            if (cmdletContext.DockerSettings_EnableDockerAccess != null)
            {
                requestDomainSettings_domainSettings_DockerSettings_dockerSettings_EnableDockerAccess = cmdletContext.DockerSettings_EnableDockerAccess;
            }
            if (requestDomainSettings_domainSettings_DockerSettings_dockerSettings_EnableDockerAccess != null)
            {
                requestDomainSettings_domainSettings_DockerSettings.EnableDockerAccess = requestDomainSettings_domainSettings_DockerSettings_dockerSettings_EnableDockerAccess;
                requestDomainSettings_domainSettings_DockerSettingsIsNull = false;
            }
            List<System.String> requestDomainSettings_domainSettings_DockerSettings_dockerSettings_VpcOnlyTrustedAccount = null;
            if (cmdletContext.DockerSettings_VpcOnlyTrustedAccount != null)
            {
                requestDomainSettings_domainSettings_DockerSettings_dockerSettings_VpcOnlyTrustedAccount = cmdletContext.DockerSettings_VpcOnlyTrustedAccount;
            }
            if (requestDomainSettings_domainSettings_DockerSettings_dockerSettings_VpcOnlyTrustedAccount != null)
            {
                requestDomainSettings_domainSettings_DockerSettings.VpcOnlyTrustedAccounts = requestDomainSettings_domainSettings_DockerSettings_dockerSettings_VpcOnlyTrustedAccount;
                requestDomainSettings_domainSettings_DockerSettingsIsNull = false;
            }
             // determine if requestDomainSettings_domainSettings_DockerSettings should be set to null
            if (requestDomainSettings_domainSettings_DockerSettingsIsNull)
            {
                requestDomainSettings_domainSettings_DockerSettings = null;
            }
            if (requestDomainSettings_domainSettings_DockerSettings != null)
            {
                request.DomainSettings.DockerSettings = requestDomainSettings_domainSettings_DockerSettings;
                requestDomainSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.RStudioServerProDomainSettings requestDomainSettings_domainSettings_RStudioServerProDomainSettings = null;
            
             // populate RStudioServerProDomainSettings
            var requestDomainSettings_domainSettings_RStudioServerProDomainSettingsIsNull = true;
            requestDomainSettings_domainSettings_RStudioServerProDomainSettings = new Amazon.SageMaker.Model.RStudioServerProDomainSettings();
            System.String requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_DomainExecutionRoleArn = null;
            if (cmdletContext.RStudioServerProDomainSettings_DomainExecutionRoleArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_DomainExecutionRoleArn = cmdletContext.RStudioServerProDomainSettings_DomainExecutionRoleArn;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_DomainExecutionRoleArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings.DomainExecutionRoleArn = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_DomainExecutionRoleArn;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettingsIsNull = false;
            }
            System.String requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioConnectUrl = null;
            if (cmdletContext.RStudioServerProDomainSettings_RStudioConnectUrl != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioConnectUrl = cmdletContext.RStudioServerProDomainSettings_RStudioConnectUrl;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioConnectUrl != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings.RStudioConnectUrl = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioConnectUrl;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettingsIsNull = false;
            }
            System.String requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioPackageManagerUrl = null;
            if (cmdletContext.RStudioServerProDomainSettings_RStudioPackageManagerUrl != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioPackageManagerUrl = cmdletContext.RStudioServerProDomainSettings_RStudioPackageManagerUrl;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioPackageManagerUrl != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings.RStudioPackageManagerUrl = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_rStudioServerProDomainSettings_RStudioPackageManagerUrl;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpecIsNull = true;
            requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_InstanceType = null;
            if (cmdletContext.DefaultResourceSpec_InstanceType != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_InstanceType = cmdletContext.DefaultResourceSpec_InstanceType;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_InstanceType != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec.InstanceType = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_InstanceType;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn = cmdletContext.DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec.LifecycleConfigArn = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn = cmdletContext.DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec.SageMakerImageArn = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn = cmdletContext.DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec should be set to null
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpecIsNull)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec = null;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec != null)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings.DefaultResourceSpec = requestDomainSettings_domainSettings_RStudioServerProDomainSettings_domainSettings_RStudioServerProDomainSettings_DefaultResourceSpec;
                requestDomainSettings_domainSettings_RStudioServerProDomainSettingsIsNull = false;
            }
             // determine if requestDomainSettings_domainSettings_RStudioServerProDomainSettings should be set to null
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettingsIsNull)
            {
                requestDomainSettings_domainSettings_RStudioServerProDomainSettings = null;
            }
            if (requestDomainSettings_domainSettings_RStudioServerProDomainSettings != null)
            {
                request.DomainSettings.RStudioServerProDomainSettings = requestDomainSettings_domainSettings_RStudioServerProDomainSettings;
                requestDomainSettingsIsNull = false;
            }
             // determine if request.DomainSettings should be set to null
            if (requestDomainSettingsIsNull)
            {
                request.DomainSettings = null;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.HomeEfsFileSystemKmsKeyId != null)
            {
                request.HomeEfsFileSystemKmsKeyId = cmdletContext.HomeEfsFileSystemKmsKeyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.TagPropagation != null)
            {
                request.TagPropagation = cmdletContext.TagPropagation;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.SageMaker.Model.CreateDomainResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateDomain");
            try
            {
                return client.CreateDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.AppNetworkAccessType AppNetworkAccessType { get; set; }
            public Amazon.SageMaker.AppSecurityGroupManagement AppSecurityGroupManagement { get; set; }
            public Amazon.SageMaker.AuthMode AuthMode { get; set; }
            public List<Amazon.SageMaker.Model.CustomFileSystemConfig> DefaultSpaceSettings_CustomFileSystemConfig { get; set; }
            public System.Int64? CustomPosixUserConfig_Gid { get; set; }
            public System.Int64? CustomPosixUserConfig_Uid { get; set; }
            public System.String DefaultSpaceSettings_ExecutionRole { get; set; }
            public System.Int32? IdleSettings_IdleTimeoutInMinute { get; set; }
            public Amazon.SageMaker.LifecycleManagement IdleSettings_LifecycleManagement { get; set; }
            public System.Int32? IdleSettings_MaxIdleTimeoutInMinute { get; set; }
            public System.Int32? IdleSettings_MinIdleTimeoutInMinute { get; set; }
            public System.String JupyterLabAppSettings_BuiltInLifecycleConfigArn { get; set; }
            public List<Amazon.SageMaker.Model.CodeRepository> JupyterLabAppSettings_CodeRepository { get; set; }
            public List<Amazon.SageMaker.Model.CustomImage> JupyterLabAppSettings_CustomImage { get; set; }
            public Amazon.SageMaker.AppInstanceType DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType { get; set; }
            public System.String DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String DefaultSpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public List<System.String> EmrSettings_AssumableRoleArn { get; set; }
            public List<System.String> EmrSettings_ExecutionRoleArn { get; set; }
            public List<System.String> JupyterLabAppSettings_LifecycleConfigArn { get; set; }
            public List<Amazon.SageMaker.Model.CodeRepository> JupyterServerAppSettings_CodeRepository { get; set; }
            public Amazon.SageMaker.AppInstanceType DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType { get; set; }
            public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public List<System.String> JupyterServerAppSettings_LifecycleConfigArn { get; set; }
            public List<Amazon.SageMaker.Model.CustomImage> KernelGatewayAppSettings_CustomImage { get; set; }
            public Amazon.SageMaker.AppInstanceType DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType { get; set; }
            public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public List<System.String> KernelGatewayAppSettings_LifecycleConfigArn { get; set; }
            public List<System.String> DefaultSpaceSettings_SecurityGroup { get; set; }
            public System.Int32? DefaultEbsStorageSettings_DefaultEbsVolumeSizeInGb { get; set; }
            public System.Int32? DefaultEbsStorageSettings_MaximumEbsVolumeSizeInGb { get; set; }
            public Amazon.SageMaker.Model.UserSettings DefaultUserSetting { get; set; }
            public System.String DomainName { get; set; }
            public System.String AmazonQSettings_QProfileArn { get; set; }
            public Amazon.SageMaker.FeatureStatus AmazonQSettings_Status { get; set; }
            public Amazon.SageMaker.FeatureStatus DockerSettings_EnableDockerAccess { get; set; }
            public List<System.String> DockerSettings_VpcOnlyTrustedAccount { get; set; }
            public Amazon.SageMaker.ExecutionRoleIdentityConfig DomainSettings_ExecutionRoleIdentityConfig { get; set; }
            public Amazon.SageMaker.AppInstanceType DefaultResourceSpec_InstanceType { get; set; }
            public System.String DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String DomainSettings_RStudioServerProDomainSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public System.String RStudioServerProDomainSettings_DomainExecutionRoleArn { get; set; }
            public System.String RStudioServerProDomainSettings_RStudioConnectUrl { get; set; }
            public System.String RStudioServerProDomainSettings_RStudioPackageManagerUrl { get; set; }
            public List<System.String> DomainSettings_SecurityGroupId { get; set; }
            [System.ObsoleteAttribute]
            public System.String HomeEfsFileSystemKmsKeyId { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<System.String> SubnetId { get; set; }
            public Amazon.SageMaker.TagPropagation TagPropagation { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateDomainResponse, NewSMDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
