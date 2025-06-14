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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates the default settings for new user profiles in the domain.
    /// </summary>
    [Cmdlet("Update", "SMDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateDomain API operation.", Operation = new[] {"UpdateDomain"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateDomainResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateDomainResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateDomainResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMDomainCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppNetworkAccessType
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC used for non-EFS traffic.</para><ul><li><para><c>PublicInternetOnly</c> - Non-EFS traffic is through a VPC managed by Amazon SageMaker
        /// AI, which allows direct internet access.</para></li><li><para><c>VpcOnly</c> - All Studio traffic is through the specified VPC and subnets.</para></li></ul><para>This configuration can only be modified if there are no apps in the <c>InService</c>,
        /// <c>Pending</c>, or <c>Deleting</c> state. The configuration cannot be updated if <c>DomainSettings.RStudioServerProDomainSettings.DomainExecutionRoleArn</c>
        /// is already set or <c>DomainSettings.RStudioServerProDomainSettings.DomainExecutionRoleArn</c>
        /// is provided as part of the same request.</para>
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
        /// <para>A collection of settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultUserSettings")]
        public Amazon.SageMaker.Model.UserSettings DefaultUserSetting { get; set; }
        #endregion
        
        #region Parameter UnifiedStudioSettings_DomainAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that has the Amazon SageMaker Unified Studio
        /// domain. The default value, if you don't specify an ID, is the ID of the account that
        /// has the Amazon SageMaker AI domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_DomainAccountId")]
        public System.String UnifiedStudioSettings_DomainAccountId { get; set; }
        #endregion
        
        #region Parameter RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role for the <c>RStudioServerPro</c> Domain-level app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn")]
        public System.String RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain to be updated.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter UnifiedStudioSettings_DomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon SageMaker Unified Studio domain associated with this domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_DomainId")]
        public System.String UnifiedStudioSettings_DomainId { get; set; }
        #endregion
        
        #region Parameter UnifiedStudioSettings_DomainRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the domain is located in Amazon SageMaker Unified
        /// Studio. The default value, if you don't specify a Region, is the Region where the
        /// Amazon SageMaker AI domain is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_DomainRegion")]
        public System.String UnifiedStudioSettings_DomainRegion { get; set; }
        #endregion
        
        #region Parameter DockerSettings_EnableDockerAccess
        /// <summary>
        /// <para>
        /// <para>Indicates whether the domain can access Docker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_DockerSettings_EnableDockerAccess")]
        [AWSConstantClassSource("Amazon.SageMaker.FeatureStatus")]
        public Amazon.SageMaker.FeatureStatus DockerSettings_EnableDockerAccess { get; set; }
        #endregion
        
        #region Parameter UnifiedStudioSettings_EnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the environment that Amazon SageMaker Unified Studio associates with the
        /// domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_EnvironmentId")]
        public System.String UnifiedStudioSettings_EnvironmentId { get; set; }
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
        
        #region Parameter DomainSettingsForUpdate_ExecutionRoleIdentityConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for attaching a SageMaker AI user profile name to the execution
        /// role as a <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_control-access_monitor.html">sts:SourceIdentity
        /// key</a>. This configuration can only be modified if there are no apps in the <c>InService</c>
        /// or <c>Pending</c> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ExecutionRoleIdentityConfig")]
        public Amazon.SageMaker.ExecutionRoleIdentityConfig DomainSettingsForUpdate_ExecutionRoleIdentityConfig { get; set; }
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
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType DefaultResourceSpec_InstanceType { get; set; }
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
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_LifecycleConfigArn")]
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
        
        #region Parameter UnifiedStudioSettings_ProjectId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon SageMaker Unified Studio project that corresponds to the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_ProjectId")]
        public System.String UnifiedStudioSettings_ProjectId { get; set; }
        #endregion
        
        #region Parameter UnifiedStudioSettings_ProjectS3Path
        /// <summary>
        /// <para>
        /// <para>The location where Amazon S3 stores temporary execution data and other artifacts for
        /// the project that corresponds to the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_ProjectS3Path")]
        public System.String UnifiedStudioSettings_ProjectS3Path { get; set; }
        #endregion
        
        #region Parameter AmazonQSettings_QProfileArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Q profile used within the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_AmazonQSettings_QProfileArn")]
        public System.String AmazonQSettings_QProfileArn { get; set; }
        #endregion
        
        #region Parameter RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl
        /// <summary>
        /// <para>
        /// <para>A URL pointing to an RStudio Connect server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl")]
        public System.String RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl { get; set; }
        #endregion
        
        #region Parameter RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl
        /// <summary>
        /// <para>
        /// <para>A URL pointing to an RStudio Package Manager server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl")]
        public System.String RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl { get; set; }
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
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageArn")]
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
        
        #region Parameter DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
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
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DomainSettingsForUpdate_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The security groups for the Amazon Virtual Private Cloud that the <c>Domain</c> uses
        /// for communication between Domain-level apps and user apps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_SecurityGroupIds")]
        public System.String[] DomainSettingsForUpdate_SecurityGroupId { get; set; }
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
        
        #region Parameter UnifiedStudioSettings_SingleSignOnApplicationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the application managed by SageMaker AI and SageMaker Unified Studio in
        /// the Amazon Web Services IAM Identity Center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_SingleSignOnApplicationArn")]
        public System.String UnifiedStudioSettings_SingleSignOnApplicationArn { get; set; }
        #endregion
        
        #region Parameter AmazonQSettings_Status
        /// <summary>
        /// <para>
        /// <para>Whether Amazon Q has been enabled within the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_AmazonQSettings_Status")]
        [AWSConstantClassSource("Amazon.SageMaker.FeatureStatus")]
        public Amazon.SageMaker.FeatureStatus AmazonQSettings_Status { get; set; }
        #endregion
        
        #region Parameter UnifiedStudioSettings_StudioWebPortalAccess
        /// <summary>
        /// <para>
        /// <para>Sets whether you can access the domain in Amazon SageMaker Studio:</para><dl><dt>ENABLED</dt><dd><para>You can access the domain in Amazon SageMaker Studio. If you migrate the domain to
        /// Amazon SageMaker Unified Studio, you can access it in both studio interfaces.</para></dd><dt>DISABLED</dt><dd><para>You can't access the domain in Amazon SageMaker Studio. If you migrate the domain
        /// to Amazon SageMaker Unified Studio, you can access it only in that studio interface.</para></dd></dl><para>To migrate a domain to Amazon SageMaker Unified Studio, you specify the UnifiedStudioSettings
        /// data type when you use the UpdateDomain action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_UnifiedStudioSettings_StudioWebPortalAccess")]
        [AWSConstantClassSource("Amazon.SageMaker.FeatureStatus")]
        public Amazon.SageMaker.FeatureStatus UnifiedStudioSettings_StudioWebPortalAccess { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The VPC subnets that Studio uses for communication.</para><para>If removing subnets, ensure there are no apps in the <c>InService</c>, <c>Pending</c>,
        /// or <c>Deleting</c> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter DockerSettings_VpcOnlyTrustedAccount
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Web Services accounts that are trusted when the domain is created
        /// in VPC-only mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_DockerSettings_VpcOnlyTrustedAccounts")]
        public System.String[] DockerSettings_VpcOnlyTrustedAccount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateDomainResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMDomain (UpdateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateDomainResponse, UpdateSMDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppNetworkAccessType = this.AppNetworkAccessType;
            context.AppSecurityGroupManagement = this.AppSecurityGroupManagement;
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
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AmazonQSettings_QProfileArn = this.AmazonQSettings_QProfileArn;
            context.AmazonQSettings_Status = this.AmazonQSettings_Status;
            context.DockerSettings_EnableDockerAccess = this.DockerSettings_EnableDockerAccess;
            if (this.DockerSettings_VpcOnlyTrustedAccount != null)
            {
                context.DockerSettings_VpcOnlyTrustedAccount = new List<System.String>(this.DockerSettings_VpcOnlyTrustedAccount);
            }
            context.DomainSettingsForUpdate_ExecutionRoleIdentityConfig = this.DomainSettingsForUpdate_ExecutionRoleIdentityConfig;
            context.DefaultResourceSpec_InstanceType = this.DefaultResourceSpec_InstanceType;
            context.DefaultResourceSpec_LifecycleConfigArn = this.DefaultResourceSpec_LifecycleConfigArn;
            context.DefaultResourceSpec_SageMakerImageArn = this.DefaultResourceSpec_SageMakerImageArn;
            context.DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias = this.DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.DefaultResourceSpec_SageMakerImageVersionArn = this.DefaultResourceSpec_SageMakerImageVersionArn;
            context.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn = this.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn;
            context.RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl = this.RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl;
            context.RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl = this.RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl;
            if (this.DomainSettingsForUpdate_SecurityGroupId != null)
            {
                context.DomainSettingsForUpdate_SecurityGroupId = new List<System.String>(this.DomainSettingsForUpdate_SecurityGroupId);
            }
            context.UnifiedStudioSettings_DomainAccountId = this.UnifiedStudioSettings_DomainAccountId;
            context.UnifiedStudioSettings_DomainId = this.UnifiedStudioSettings_DomainId;
            context.UnifiedStudioSettings_DomainRegion = this.UnifiedStudioSettings_DomainRegion;
            context.UnifiedStudioSettings_EnvironmentId = this.UnifiedStudioSettings_EnvironmentId;
            context.UnifiedStudioSettings_ProjectId = this.UnifiedStudioSettings_ProjectId;
            context.UnifiedStudioSettings_ProjectS3Path = this.UnifiedStudioSettings_ProjectS3Path;
            context.UnifiedStudioSettings_SingleSignOnApplicationArn = this.UnifiedStudioSettings_SingleSignOnApplicationArn;
            context.UnifiedStudioSettings_StudioWebPortalAccess = this.UnifiedStudioSettings_StudioWebPortalAccess;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            context.TagPropagation = this.TagPropagation;
            
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
            var request = new Amazon.SageMaker.Model.UpdateDomainRequest();
            
            if (cmdletContext.AppNetworkAccessType != null)
            {
                request.AppNetworkAccessType = cmdletContext.AppNetworkAccessType;
            }
            if (cmdletContext.AppSecurityGroupManagement != null)
            {
                request.AppSecurityGroupManagement = cmdletContext.AppSecurityGroupManagement;
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
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate DomainSettingsForUpdate
            var requestDomainSettingsForUpdateIsNull = true;
            request.DomainSettingsForUpdate = new Amazon.SageMaker.Model.DomainSettingsForUpdate();
            Amazon.SageMaker.ExecutionRoleIdentityConfig requestDomainSettingsForUpdate_domainSettingsForUpdate_ExecutionRoleIdentityConfig = null;
            if (cmdletContext.DomainSettingsForUpdate_ExecutionRoleIdentityConfig != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_ExecutionRoleIdentityConfig = cmdletContext.DomainSettingsForUpdate_ExecutionRoleIdentityConfig;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_ExecutionRoleIdentityConfig != null)
            {
                request.DomainSettingsForUpdate.ExecutionRoleIdentityConfig = requestDomainSettingsForUpdate_domainSettingsForUpdate_ExecutionRoleIdentityConfig;
                requestDomainSettingsForUpdateIsNull = false;
            }
            List<System.String> requestDomainSettingsForUpdate_domainSettingsForUpdate_SecurityGroupId = null;
            if (cmdletContext.DomainSettingsForUpdate_SecurityGroupId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_SecurityGroupId = cmdletContext.DomainSettingsForUpdate_SecurityGroupId;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_SecurityGroupId != null)
            {
                request.DomainSettingsForUpdate.SecurityGroupIds = requestDomainSettingsForUpdate_domainSettingsForUpdate_SecurityGroupId;
                requestDomainSettingsForUpdateIsNull = false;
            }
            Amazon.SageMaker.Model.AmazonQSettings requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings = null;
            
             // populate AmazonQSettings
            var requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettingsIsNull = true;
            requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings = new Amazon.SageMaker.Model.AmazonQSettings();
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_QProfileArn = null;
            if (cmdletContext.AmazonQSettings_QProfileArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_QProfileArn = cmdletContext.AmazonQSettings_QProfileArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_QProfileArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings.QProfileArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_QProfileArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettingsIsNull = false;
            }
            Amazon.SageMaker.FeatureStatus requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_Status = null;
            if (cmdletContext.AmazonQSettings_Status != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_Status = cmdletContext.AmazonQSettings_Status;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_Status != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings.Status = requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings_amazonQSettings_Status;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettingsIsNull = false;
            }
             // determine if requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings should be set to null
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettingsIsNull)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings = null;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings != null)
            {
                request.DomainSettingsForUpdate.AmazonQSettings = requestDomainSettingsForUpdate_domainSettingsForUpdate_AmazonQSettings;
                requestDomainSettingsForUpdateIsNull = false;
            }
            Amazon.SageMaker.Model.DockerSettings requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings = null;
            
             // populate DockerSettings
            var requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettingsIsNull = true;
            requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings = new Amazon.SageMaker.Model.DockerSettings();
            Amazon.SageMaker.FeatureStatus requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_EnableDockerAccess = null;
            if (cmdletContext.DockerSettings_EnableDockerAccess != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_EnableDockerAccess = cmdletContext.DockerSettings_EnableDockerAccess;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_EnableDockerAccess != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings.EnableDockerAccess = requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_EnableDockerAccess;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettingsIsNull = false;
            }
            List<System.String> requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_VpcOnlyTrustedAccount = null;
            if (cmdletContext.DockerSettings_VpcOnlyTrustedAccount != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_VpcOnlyTrustedAccount = cmdletContext.DockerSettings_VpcOnlyTrustedAccount;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_VpcOnlyTrustedAccount != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings.VpcOnlyTrustedAccounts = requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings_dockerSettings_VpcOnlyTrustedAccount;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettingsIsNull = false;
            }
             // determine if requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings should be set to null
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettingsIsNull)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings = null;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings != null)
            {
                request.DomainSettingsForUpdate.DockerSettings = requestDomainSettingsForUpdate_domainSettingsForUpdate_DockerSettings;
                requestDomainSettingsForUpdateIsNull = false;
            }
            Amazon.SageMaker.Model.RStudioServerProDomainSettingsForUpdate requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate = null;
            
             // populate RStudioServerProDomainSettingsForUpdate
            var requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = true;
            requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate = new Amazon.SageMaker.Model.RStudioServerProDomainSettingsForUpdate();
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn = null;
            if (cmdletContext.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn = cmdletContext.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate.DomainExecutionRoleArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioConnectUrl = null;
            if (cmdletContext.RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioConnectUrl = cmdletContext.RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioConnectUrl != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate.RStudioConnectUrl = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioConnectUrl;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl = null;
            if (cmdletContext.RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl = cmdletContext.RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate.RStudioPackageManagerUrl = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = true;
            requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType = null;
            if (cmdletContext.DefaultResourceSpec_InstanceType != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType = cmdletContext.DefaultResourceSpec_InstanceType;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.InstanceType = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn = cmdletContext.DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.LifecycleConfigArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn = cmdletContext.DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.SageMakerImageArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.SageMakerImageVersionAlias = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn = cmdletContext.DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.SageMakerImageVersionArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
             // determine if requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec should be set to null
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec = null;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate.DefaultResourceSpec = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = false;
            }
             // determine if requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate should be set to null
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate = null;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate != null)
            {
                request.DomainSettingsForUpdate.RStudioServerProDomainSettingsForUpdate = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate;
                requestDomainSettingsForUpdateIsNull = false;
            }
            Amazon.SageMaker.Model.UnifiedStudioSettings requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings = null;
            
             // populate UnifiedStudioSettings
            var requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = true;
            requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings = new Amazon.SageMaker.Model.UnifiedStudioSettings();
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainAccountId = null;
            if (cmdletContext.UnifiedStudioSettings_DomainAccountId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainAccountId = cmdletContext.UnifiedStudioSettings_DomainAccountId;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainAccountId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.DomainAccountId = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainAccountId;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainId = null;
            if (cmdletContext.UnifiedStudioSettings_DomainId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainId = cmdletContext.UnifiedStudioSettings_DomainId;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.DomainId = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainId;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainRegion = null;
            if (cmdletContext.UnifiedStudioSettings_DomainRegion != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainRegion = cmdletContext.UnifiedStudioSettings_DomainRegion;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainRegion != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.DomainRegion = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_DomainRegion;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_EnvironmentId = null;
            if (cmdletContext.UnifiedStudioSettings_EnvironmentId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_EnvironmentId = cmdletContext.UnifiedStudioSettings_EnvironmentId;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_EnvironmentId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.EnvironmentId = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_EnvironmentId;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectId = null;
            if (cmdletContext.UnifiedStudioSettings_ProjectId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectId = cmdletContext.UnifiedStudioSettings_ProjectId;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectId != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.ProjectId = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectId;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectS3Path = null;
            if (cmdletContext.UnifiedStudioSettings_ProjectS3Path != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectS3Path = cmdletContext.UnifiedStudioSettings_ProjectS3Path;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectS3Path != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.ProjectS3Path = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_ProjectS3Path;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_SingleSignOnApplicationArn = null;
            if (cmdletContext.UnifiedStudioSettings_SingleSignOnApplicationArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_SingleSignOnApplicationArn = cmdletContext.UnifiedStudioSettings_SingleSignOnApplicationArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_SingleSignOnApplicationArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.SingleSignOnApplicationArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_SingleSignOnApplicationArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
            Amazon.SageMaker.FeatureStatus requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_StudioWebPortalAccess = null;
            if (cmdletContext.UnifiedStudioSettings_StudioWebPortalAccess != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_StudioWebPortalAccess = cmdletContext.UnifiedStudioSettings_StudioWebPortalAccess;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_StudioWebPortalAccess != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings.StudioWebPortalAccess = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings_unifiedStudioSettings_StudioWebPortalAccess;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull = false;
            }
             // determine if requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings should be set to null
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettingsIsNull)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings = null;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings != null)
            {
                request.DomainSettingsForUpdate.UnifiedStudioSettings = requestDomainSettingsForUpdate_domainSettingsForUpdate_UnifiedStudioSettings;
                requestDomainSettingsForUpdateIsNull = false;
            }
             // determine if request.DomainSettingsForUpdate should be set to null
            if (requestDomainSettingsForUpdateIsNull)
            {
                request.DomainSettingsForUpdate = null;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.TagPropagation != null)
            {
                request.TagPropagation = cmdletContext.TagPropagation;
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
        
        private Amazon.SageMaker.Model.UpdateDomainResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateDomain");
            try
            {
                return client.UpdateDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String AmazonQSettings_QProfileArn { get; set; }
            public Amazon.SageMaker.FeatureStatus AmazonQSettings_Status { get; set; }
            public Amazon.SageMaker.FeatureStatus DockerSettings_EnableDockerAccess { get; set; }
            public List<System.String> DockerSettings_VpcOnlyTrustedAccount { get; set; }
            public Amazon.SageMaker.ExecutionRoleIdentityConfig DomainSettingsForUpdate_ExecutionRoleIdentityConfig { get; set; }
            public Amazon.SageMaker.AppInstanceType DefaultResourceSpec_InstanceType { get; set; }
            public System.String DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public System.String RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn { get; set; }
            public System.String RStudioServerProDomainSettingsForUpdate_RStudioConnectUrl { get; set; }
            public System.String RStudioServerProDomainSettingsForUpdate_RStudioPackageManagerUrl { get; set; }
            public List<System.String> DomainSettingsForUpdate_SecurityGroupId { get; set; }
            public System.String UnifiedStudioSettings_DomainAccountId { get; set; }
            public System.String UnifiedStudioSettings_DomainId { get; set; }
            public System.String UnifiedStudioSettings_DomainRegion { get; set; }
            public System.String UnifiedStudioSettings_EnvironmentId { get; set; }
            public System.String UnifiedStudioSettings_ProjectId { get; set; }
            public System.String UnifiedStudioSettings_ProjectS3Path { get; set; }
            public System.String UnifiedStudioSettings_SingleSignOnApplicationArn { get; set; }
            public Amazon.SageMaker.FeatureStatus UnifiedStudioSettings_StudioWebPortalAccess { get; set; }
            public List<System.String> SubnetId { get; set; }
            public Amazon.SageMaker.TagPropagation TagPropagation { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateDomainResponse, UpdateSMDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainArn;
        }
        
    }
}
