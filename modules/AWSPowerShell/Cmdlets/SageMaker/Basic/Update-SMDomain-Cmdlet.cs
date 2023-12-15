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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

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
        "The service call response (type Amazon.SageMaker.Model.UpdateDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMDomainCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppNetworkAccessType
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC used for non-EFS traffic.</para><ul><li><para><code>PublicInternetOnly</code> - Non-EFS traffic is through a VPC managed by Amazon
        /// SageMaker, which allows direct internet access.</para></li><li><para><code>VpcOnly</code> - All Studio traffic is through the specified VPC and subnets.</para></li></ul><para>This configuration can only be modified if there are no apps in the <code>InService</code>,
        /// <code>Pending</code>, or <code>Deleting</code> state. The configuration cannot be
        /// updated if <code>DomainSettings.RStudioServerProDomainSettings.DomainExecutionRoleArn</code>
        /// is already set or <code>DomainSettings.RStudioServerProDomainSettings.DomainExecutionRoleArn</code>
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
        /// in <code>VPCOnly</code> mode. Required when <code>CreateDomain.AppNetworkAccessType</code>
        /// is <code>VPCOnly</code> and <code>DomainSettings.RStudioServerProDomainSettings.DomainExecutionRoleArn</code>
        /// is provided. If setting up the domain for use with RStudio, this value must be set
        /// to <code>Service</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AppSecurityGroupManagement")]
        public Amazon.SageMaker.AppSecurityGroupManagement AppSecurityGroupManagement { get; set; }
        #endregion
        
        #region Parameter JupyterServerAppSettings_CodeRepository
        /// <summary>
        /// <para>
        /// <para>A list of Git repositories that SageMaker automatically displays to users for cloning
        /// in the JupyterServer application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_JupyterServerAppSettings_CodeRepositories")]
        public Amazon.SageMaker.Model.CodeRepository[] JupyterServerAppSettings_CodeRepository { get; set; }
        #endregion
        
        #region Parameter KernelGatewayAppSettings_CustomImage
        /// <summary>
        /// <para>
        /// <para>A list of custom SageMaker images that are configured to run as a KernelGateway app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_KernelGatewayAppSettings_CustomImages")]
        public Amazon.SageMaker.Model.CustomImage[] KernelGatewayAppSettings_CustomImage { get; set; }
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
        
        #region Parameter RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role for the <code>RStudioServerPro</code> Domain-level app.</para>
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
        
        #region Parameter DefaultSpaceSettings_ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the execution role for the space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_ExecutionRole { get; set; }
        #endregion
        
        #region Parameter DomainSettingsForUpdate_ExecutionRoleIdentityConfig
        /// <summary>
        /// <para>
        /// <para>The configuration for attaching a SageMaker user profile name to the execution role
        /// as a <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_control-access_monitor.html">sts:SourceIdentity
        /// key</a>. This configuration can only be modified if there are no apps in the <code>InService</code>
        /// or <code>Pending</code> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ExecutionRoleIdentityConfig")]
        public Amazon.SageMaker.ExecutionRoleIdentityConfig DomainSettingsForUpdate_ExecutionRoleIdentityConfig { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <code>system</code> value.</para><para>For <b>KernelGateway apps</b>, the <code>system</code> value is translated to <code>ml.t3.medium</code>.
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
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <code>system</code> value.</para><para>For <b>KernelGateway apps</b>, the <code>system</code> value is translated to <code>ml.t3.medium</code>.
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
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <code>system</code> value.</para><para>For <b>KernelGateway apps</b>, the <code>system</code> value is translated to <code>ml.t3.medium</code>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType DefaultResourceSpec_InstanceType { get; set; }
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
        
        #region Parameter JupyterServerAppSettings_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configurations attached to the JupyterServerApp.
        /// If you use this parameter, the <code>DefaultResourceSpec</code> parameter is also
        /// required.</para><note><para>To remove a Lifecycle Config, you must set <code>LifecycleConfigArns</code> to an
        /// empty list.</para></note>
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
        /// user profile or domain.</para><note><para>To remove a Lifecycle Config, you must set <code>LifecycleConfigArns</code> to an
        /// empty list.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_KernelGatewayAppSettings_LifecycleConfigArns")]
        public System.String[] KernelGatewayAppSettings_LifecycleConfigArn { get; set; }
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
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageArn")]
        public System.String DefaultResourceSpec_SageMakerImageArn { get; set; }
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
        
        #region Parameter DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter DomainSettingsForUpdate_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The security groups for the Amazon Virtual Private Cloud that the <code>Domain</code>
        /// uses for communication between Domain-level apps and user apps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_SecurityGroupIds")]
        public System.String[] DomainSettingsForUpdate_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter DefaultSpaceSettings_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security group IDs for the Amazon Virtual Private Cloud that the space uses for
        /// communication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultSpaceSettings_SecurityGroups")]
        public System.String[] DefaultSpaceSettings_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The VPC subnets that Studio uses for communication.</para><para>If removing subnets, ensure there are no apps in the <code>InService</code>, <code>Pending</code>,
        /// or <code>Deleting</code> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMDomain (UpdateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateDomainResponse, UpdateSMDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppNetworkAccessType = this.AppNetworkAccessType;
            context.AppSecurityGroupManagement = this.AppSecurityGroupManagement;
            context.DefaultSpaceSettings_ExecutionRole = this.DefaultSpaceSettings_ExecutionRole;
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
            context.DefaultUserSetting = this.DefaultUserSetting;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
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
             // determine if request.DomainSettingsForUpdate should be set to null
            if (requestDomainSettingsForUpdateIsNull)
            {
                request.DomainSettingsForUpdate = null;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
                #if DESKTOP
                return client.UpdateDomain(request);
                #elif CORECLR
                return client.UpdateDomainAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.AppNetworkAccessType AppNetworkAccessType { get; set; }
            public Amazon.SageMaker.AppSecurityGroupManagement AppSecurityGroupManagement { get; set; }
            public System.String DefaultSpaceSettings_ExecutionRole { get; set; }
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
            public Amazon.SageMaker.Model.UserSettings DefaultUserSetting { get; set; }
            public System.String DomainId { get; set; }
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
            public List<System.String> SubnetId { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateDomainResponse, UpdateSMDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainArn;
        }
        
    }
}
