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
    /// Creates a space used for real time collaboration in a domain.
    /// </summary>
    [Cmdlet("New", "SMSpace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateSpace API operation.", Operation = new[] {"CreateSpace"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateSpaceResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateSpaceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateSpaceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMSpaceCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SpaceSettings_AppType
        /// <summary>
        /// <para>
        /// <para>The type of app created within the space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AppType")]
        public Amazon.SageMaker.AppType SpaceSettings_AppType { get; set; }
        #endregion
        
        #region Parameter JupyterLabAppSettings_CodeRepository
        /// <summary>
        /// <para>
        /// <para>A list of Git repositories that SageMaker automatically displays to users for cloning
        /// in the JupyterLab application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpaceSettings_JupyterLabAppSettings_CodeRepositories")]
        public Amazon.SageMaker.Model.CodeRepository[] JupyterLabAppSettings_CodeRepository { get; set; }
        #endregion
        
        #region Parameter JupyterServerAppSettings_CodeRepository
        /// <summary>
        /// <para>
        /// <para>A list of Git repositories that SageMaker automatically displays to users for cloning
        /// in the JupyterServer application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpaceSettings_JupyterServerAppSettings_CodeRepositories")]
        public Amazon.SageMaker.Model.CodeRepository[] JupyterServerAppSettings_CodeRepository { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_CustomFileSystem
        /// <summary>
        /// <para>
        /// <para>A file system, created by you, that you assign to a space for an Amazon SageMaker
        /// Domain. Permitted users can access this file system in Amazon SageMaker Studio.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpaceSettings_CustomFileSystems")]
        public Amazon.SageMaker.Model.CustomFileSystem[] SpaceSettings_CustomFileSystem { get; set; }
        #endregion
        
        #region Parameter KernelGatewayAppSettings_CustomImage
        /// <summary>
        /// <para>
        /// <para>A list of custom SageMaker images that are configured to run as a KernelGateway app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpaceSettings_KernelGatewayAppSettings_CustomImages")]
        public Amazon.SageMaker.Model.CustomImage[] KernelGatewayAppSettings_CustomImage { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the associated domain.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter EbsStorageSettings_EbsVolumeSizeInGb
        /// <summary>
        /// <para>
        /// <para>The size of an EBS storage volume for a private space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SpaceSettings_SpaceStorageSettings_EbsStorageSettings_EbsVolumeSizeInGb")]
        public System.Int32? EbsStorageSettings_EbsVolumeSizeInGb { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeEditorAppSettings_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppSettings_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterServerAppSettings_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para><b>JupyterServer apps</b> only support the <c>system</c> value.</para><para>For <b>KernelGateway apps</b>, the <c>system</c> value is translated to <c>ml.t3.medium</c>.
        /// KernelGateway apps also support all other values for available instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayAppSettings_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn")]
        public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn")]
        public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn")]
        public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn")]
        public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
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
        [Alias("SpaceSettings_JupyterServerAppSettings_LifecycleConfigArns")]
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
        [Alias("SpaceSettings_KernelGatewayAppSettings_LifecycleConfigArns")]
        public System.String[] KernelGatewayAppSettings_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter OwnershipSettings_OwnerUserProfileName
        /// <summary>
        /// <para>
        /// <para>The user profile who is the owner of the private space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnershipSettings_OwnerUserProfileName { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn")]
        public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn")]
        public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn")]
        public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn")]
        public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias")]
        public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias")]
        public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias")]
        public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias
        /// <summary>
        /// <para>
        /// <para>The SageMakerImageVersionAlias of the image to launch with. This value is in SemVer
        /// 2.0.0 versioning format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias")]
        public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter SpaceSharingSettings_SharingType
        /// <summary>
        /// <para>
        /// <para>Specifies the sharing type of the space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SharingType")]
        public Amazon.SageMaker.SharingType SpaceSharingSettings_SharingType { get; set; }
        #endregion
        
        #region Parameter SpaceDisplayName
        /// <summary>
        /// <para>
        /// <para>The name of the space that appears in the SageMaker Studio UI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SpaceDisplayName { get; set; }
        #endregion
        
        #region Parameter SpaceName
        /// <summary>
        /// <para>
        /// <para>The name of the space.</para>
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
        public System.String SpaceName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associated with the space. Each tag consists of a key and an optional value.
        /// Tag keys must be unique for each resource. Tags are searchable using the <c>Search</c>
        /// API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SpaceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateSpaceResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateSpaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SpaceArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SpaceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SpaceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SpaceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SpaceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMSpace (CreateSpace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateSpaceResponse, NewSMSpaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SpaceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwnershipSettings_OwnerUserProfileName = this.OwnershipSettings_OwnerUserProfileName;
            context.SpaceDisplayName = this.SpaceDisplayName;
            context.SpaceName = this.SpaceName;
            #if MODULAR
            if (this.SpaceName == null && ParameterWasBound(nameof(this.SpaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SpaceSettings_AppType = this.SpaceSettings_AppType;
            context.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType = this.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType;
            context.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn = this.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            context.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn = this.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn;
            context.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = this.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = this.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            if (this.SpaceSettings_CustomFileSystem != null)
            {
                context.SpaceSettings_CustomFileSystem = new List<Amazon.SageMaker.Model.CustomFileSystem>(this.SpaceSettings_CustomFileSystem);
            }
            if (this.JupyterLabAppSettings_CodeRepository != null)
            {
                context.JupyterLabAppSettings_CodeRepository = new List<Amazon.SageMaker.Model.CodeRepository>(this.JupyterLabAppSettings_CodeRepository);
            }
            context.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType = this.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType;
            context.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn = this.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            context.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn = this.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn;
            context.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = this.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = this.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            if (this.JupyterServerAppSettings_CodeRepository != null)
            {
                context.JupyterServerAppSettings_CodeRepository = new List<Amazon.SageMaker.Model.CodeRepository>(this.JupyterServerAppSettings_CodeRepository);
            }
            context.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType = this.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType;
            context.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn = this.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            context.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn = this.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn;
            context.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = this.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = this.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            if (this.JupyterServerAppSettings_LifecycleConfigArn != null)
            {
                context.JupyterServerAppSettings_LifecycleConfigArn = new List<System.String>(this.JupyterServerAppSettings_LifecycleConfigArn);
            }
            if (this.KernelGatewayAppSettings_CustomImage != null)
            {
                context.KernelGatewayAppSettings_CustomImage = new List<Amazon.SageMaker.Model.CustomImage>(this.KernelGatewayAppSettings_CustomImage);
            }
            context.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType = this.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType;
            context.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn = this.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            context.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn = this.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn;
            context.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = this.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            context.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = this.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            if (this.KernelGatewayAppSettings_LifecycleConfigArn != null)
            {
                context.KernelGatewayAppSettings_LifecycleConfigArn = new List<System.String>(this.KernelGatewayAppSettings_LifecycleConfigArn);
            }
            context.EbsStorageSettings_EbsVolumeSizeInGb = this.EbsStorageSettings_EbsVolumeSizeInGb;
            context.SpaceSharingSettings_SharingType = this.SpaceSharingSettings_SharingType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateSpaceRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate OwnershipSettings
            var requestOwnershipSettingsIsNull = true;
            request.OwnershipSettings = new Amazon.SageMaker.Model.OwnershipSettings();
            System.String requestOwnershipSettings_ownershipSettings_OwnerUserProfileName = null;
            if (cmdletContext.OwnershipSettings_OwnerUserProfileName != null)
            {
                requestOwnershipSettings_ownershipSettings_OwnerUserProfileName = cmdletContext.OwnershipSettings_OwnerUserProfileName;
            }
            if (requestOwnershipSettings_ownershipSettings_OwnerUserProfileName != null)
            {
                request.OwnershipSettings.OwnerUserProfileName = requestOwnershipSettings_ownershipSettings_OwnerUserProfileName;
                requestOwnershipSettingsIsNull = false;
            }
             // determine if request.OwnershipSettings should be set to null
            if (requestOwnershipSettingsIsNull)
            {
                request.OwnershipSettings = null;
            }
            if (cmdletContext.SpaceDisplayName != null)
            {
                request.SpaceDisplayName = cmdletContext.SpaceDisplayName;
            }
            if (cmdletContext.SpaceName != null)
            {
                request.SpaceName = cmdletContext.SpaceName;
            }
            
             // populate SpaceSettings
            var requestSpaceSettingsIsNull = true;
            request.SpaceSettings = new Amazon.SageMaker.Model.SpaceSettings();
            Amazon.SageMaker.AppType requestSpaceSettings_spaceSettings_AppType = null;
            if (cmdletContext.SpaceSettings_AppType != null)
            {
                requestSpaceSettings_spaceSettings_AppType = cmdletContext.SpaceSettings_AppType;
            }
            if (requestSpaceSettings_spaceSettings_AppType != null)
            {
                request.SpaceSettings.AppType = requestSpaceSettings_spaceSettings_AppType;
                requestSpaceSettingsIsNull = false;
            }
            List<Amazon.SageMaker.Model.CustomFileSystem> requestSpaceSettings_spaceSettings_CustomFileSystem = null;
            if (cmdletContext.SpaceSettings_CustomFileSystem != null)
            {
                requestSpaceSettings_spaceSettings_CustomFileSystem = cmdletContext.SpaceSettings_CustomFileSystem;
            }
            if (requestSpaceSettings_spaceSettings_CustomFileSystem != null)
            {
                request.SpaceSettings.CustomFileSystems = requestSpaceSettings_spaceSettings_CustomFileSystem;
                requestSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.SpaceCodeEditorAppSettings requestSpaceSettings_spaceSettings_CodeEditorAppSettings = null;
            
             // populate CodeEditorAppSettings
            var requestSpaceSettings_spaceSettings_CodeEditorAppSettingsIsNull = true;
            requestSpaceSettings_spaceSettings_CodeEditorAppSettings = new Amazon.SageMaker.Model.SpaceCodeEditorAppSettings();
            Amazon.SageMaker.Model.ResourceSpec requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpecIsNull = true;
            requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType = null;
            if (cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType = cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType;
            }
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec.InstanceType = requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType;
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn = cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec.LifecycleConfigArn = requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn;
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn = cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec.SageMakerImageArn = requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn;
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = cmdletContext.SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec should be set to null
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpecIsNull)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec = null;
            }
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec != null)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings.DefaultResourceSpec = requestSpaceSettings_spaceSettings_CodeEditorAppSettings_spaceSettings_CodeEditorAppSettings_DefaultResourceSpec;
                requestSpaceSettings_spaceSettings_CodeEditorAppSettingsIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_CodeEditorAppSettings should be set to null
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettingsIsNull)
            {
                requestSpaceSettings_spaceSettings_CodeEditorAppSettings = null;
            }
            if (requestSpaceSettings_spaceSettings_CodeEditorAppSettings != null)
            {
                request.SpaceSettings.CodeEditorAppSettings = requestSpaceSettings_spaceSettings_CodeEditorAppSettings;
                requestSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.SpaceStorageSettings requestSpaceSettings_spaceSettings_SpaceStorageSettings = null;
            
             // populate SpaceStorageSettings
            var requestSpaceSettings_spaceSettings_SpaceStorageSettingsIsNull = true;
            requestSpaceSettings_spaceSettings_SpaceStorageSettings = new Amazon.SageMaker.Model.SpaceStorageSettings();
            Amazon.SageMaker.Model.EbsStorageSettings requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings = null;
            
             // populate EbsStorageSettings
            var requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettingsIsNull = true;
            requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings = new Amazon.SageMaker.Model.EbsStorageSettings();
            System.Int32? requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings_ebsStorageSettings_EbsVolumeSizeInGb = null;
            if (cmdletContext.EbsStorageSettings_EbsVolumeSizeInGb != null)
            {
                requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings_ebsStorageSettings_EbsVolumeSizeInGb = cmdletContext.EbsStorageSettings_EbsVolumeSizeInGb.Value;
            }
            if (requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings_ebsStorageSettings_EbsVolumeSizeInGb != null)
            {
                requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings.EbsVolumeSizeInGb = requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings_ebsStorageSettings_EbsVolumeSizeInGb.Value;
                requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettingsIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings should be set to null
            if (requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettingsIsNull)
            {
                requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings = null;
            }
            if (requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings != null)
            {
                requestSpaceSettings_spaceSettings_SpaceStorageSettings.EbsStorageSettings = requestSpaceSettings_spaceSettings_SpaceStorageSettings_spaceSettings_SpaceStorageSettings_EbsStorageSettings;
                requestSpaceSettings_spaceSettings_SpaceStorageSettingsIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_SpaceStorageSettings should be set to null
            if (requestSpaceSettings_spaceSettings_SpaceStorageSettingsIsNull)
            {
                requestSpaceSettings_spaceSettings_SpaceStorageSettings = null;
            }
            if (requestSpaceSettings_spaceSettings_SpaceStorageSettings != null)
            {
                request.SpaceSettings.SpaceStorageSettings = requestSpaceSettings_spaceSettings_SpaceStorageSettings;
                requestSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.SpaceJupyterLabAppSettings requestSpaceSettings_spaceSettings_JupyterLabAppSettings = null;
            
             // populate JupyterLabAppSettings
            var requestSpaceSettings_spaceSettings_JupyterLabAppSettingsIsNull = true;
            requestSpaceSettings_spaceSettings_JupyterLabAppSettings = new Amazon.SageMaker.Model.SpaceJupyterLabAppSettings();
            List<Amazon.SageMaker.Model.CodeRepository> requestSpaceSettings_spaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository = null;
            if (cmdletContext.JupyterLabAppSettings_CodeRepository != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository = cmdletContext.JupyterLabAppSettings_CodeRepository;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings.CodeRepositories = requestSpaceSettings_spaceSettings_JupyterLabAppSettings_jupyterLabAppSettings_CodeRepository;
                requestSpaceSettings_spaceSettings_JupyterLabAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = true;
            requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType = null;
            if (cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType = cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec.InstanceType = requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType;
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn = cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec.LifecycleConfigArn = requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn;
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn = cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec.SageMakerImageArn = requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn;
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = cmdletContext.SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec should be set to null
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpecIsNull)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec = null;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec != null)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings.DefaultResourceSpec = requestSpaceSettings_spaceSettings_JupyterLabAppSettings_spaceSettings_JupyterLabAppSettings_DefaultResourceSpec;
                requestSpaceSettings_spaceSettings_JupyterLabAppSettingsIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_JupyterLabAppSettings should be set to null
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettingsIsNull)
            {
                requestSpaceSettings_spaceSettings_JupyterLabAppSettings = null;
            }
            if (requestSpaceSettings_spaceSettings_JupyterLabAppSettings != null)
            {
                request.SpaceSettings.JupyterLabAppSettings = requestSpaceSettings_spaceSettings_JupyterLabAppSettings;
                requestSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.JupyterServerAppSettings requestSpaceSettings_spaceSettings_JupyterServerAppSettings = null;
            
             // populate JupyterServerAppSettings
            var requestSpaceSettings_spaceSettings_JupyterServerAppSettingsIsNull = true;
            requestSpaceSettings_spaceSettings_JupyterServerAppSettings = new Amazon.SageMaker.Model.JupyterServerAppSettings();
            List<Amazon.SageMaker.Model.CodeRepository> requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository = null;
            if (cmdletContext.JupyterServerAppSettings_CodeRepository != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository = cmdletContext.JupyterServerAppSettings_CodeRepository;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings.CodeRepositories = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_CodeRepository;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettingsIsNull = false;
            }
            List<System.String> requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn = null;
            if (cmdletContext.JupyterServerAppSettings_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn = cmdletContext.JupyterServerAppSettings_LifecycleConfigArn;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings.LifecycleConfigArns = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_jupyterServerAppSettings_LifecycleConfigArn;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = true;
            requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType = null;
            if (cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType = cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec.InstanceType = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn = cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec.LifecycleConfigArn = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn = cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec.SageMakerImageArn = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = cmdletContext.SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec should be set to null
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpecIsNull)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec = null;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec != null)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings.DefaultResourceSpec = requestSpaceSettings_spaceSettings_JupyterServerAppSettings_spaceSettings_JupyterServerAppSettings_DefaultResourceSpec;
                requestSpaceSettings_spaceSettings_JupyterServerAppSettingsIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_JupyterServerAppSettings should be set to null
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettingsIsNull)
            {
                requestSpaceSettings_spaceSettings_JupyterServerAppSettings = null;
            }
            if (requestSpaceSettings_spaceSettings_JupyterServerAppSettings != null)
            {
                request.SpaceSettings.JupyterServerAppSettings = requestSpaceSettings_spaceSettings_JupyterServerAppSettings;
                requestSpaceSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.KernelGatewayAppSettings requestSpaceSettings_spaceSettings_KernelGatewayAppSettings = null;
            
             // populate KernelGatewayAppSettings
            var requestSpaceSettings_spaceSettings_KernelGatewayAppSettingsIsNull = true;
            requestSpaceSettings_spaceSettings_KernelGatewayAppSettings = new Amazon.SageMaker.Model.KernelGatewayAppSettings();
            List<Amazon.SageMaker.Model.CustomImage> requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage = null;
            if (cmdletContext.KernelGatewayAppSettings_CustomImage != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage = cmdletContext.KernelGatewayAppSettings_CustomImage;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings.CustomImages = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_CustomImage;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettingsIsNull = false;
            }
            List<System.String> requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn = null;
            if (cmdletContext.KernelGatewayAppSettings_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn = cmdletContext.KernelGatewayAppSettings_LifecycleConfigArn;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings.LifecycleConfigArns = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_kernelGatewayAppSettings_LifecycleConfigArn;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettingsIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = true;
            requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType = null;
            if (cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType = cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.InstanceType = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn = cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.LifecycleConfigArn = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn = cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.SageMakerImageArn = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = null;
            if (cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias = cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.SageMakerImageVersionAlias = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
            System.String requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn = cmdletContext.SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec.SageMakerImageVersionArn = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec should be set to null
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpecIsNull)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec = null;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec != null)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings.DefaultResourceSpec = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings_spaceSettings_KernelGatewayAppSettings_DefaultResourceSpec;
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettingsIsNull = false;
            }
             // determine if requestSpaceSettings_spaceSettings_KernelGatewayAppSettings should be set to null
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettingsIsNull)
            {
                requestSpaceSettings_spaceSettings_KernelGatewayAppSettings = null;
            }
            if (requestSpaceSettings_spaceSettings_KernelGatewayAppSettings != null)
            {
                request.SpaceSettings.KernelGatewayAppSettings = requestSpaceSettings_spaceSettings_KernelGatewayAppSettings;
                requestSpaceSettingsIsNull = false;
            }
             // determine if request.SpaceSettings should be set to null
            if (requestSpaceSettingsIsNull)
            {
                request.SpaceSettings = null;
            }
            
             // populate SpaceSharingSettings
            var requestSpaceSharingSettingsIsNull = true;
            request.SpaceSharingSettings = new Amazon.SageMaker.Model.SpaceSharingSettings();
            Amazon.SageMaker.SharingType requestSpaceSharingSettings_spaceSharingSettings_SharingType = null;
            if (cmdletContext.SpaceSharingSettings_SharingType != null)
            {
                requestSpaceSharingSettings_spaceSharingSettings_SharingType = cmdletContext.SpaceSharingSettings_SharingType;
            }
            if (requestSpaceSharingSettings_spaceSharingSettings_SharingType != null)
            {
                request.SpaceSharingSettings.SharingType = requestSpaceSharingSettings_spaceSharingSettings_SharingType;
                requestSpaceSharingSettingsIsNull = false;
            }
             // determine if request.SpaceSharingSettings should be set to null
            if (requestSpaceSharingSettingsIsNull)
            {
                request.SpaceSharingSettings = null;
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
        
        private Amazon.SageMaker.Model.CreateSpaceResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateSpaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateSpace");
            try
            {
                #if DESKTOP
                return client.CreateSpace(request);
                #elif CORECLR
                return client.CreateSpaceAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String OwnershipSettings_OwnerUserProfileName { get; set; }
            public System.String SpaceDisplayName { get; set; }
            public System.String SpaceName { get; set; }
            public Amazon.SageMaker.AppType SpaceSettings_AppType { get; set; }
            public Amazon.SageMaker.AppInstanceType SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_InstanceType { get; set; }
            public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String SpaceSettings_CodeEditorAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public List<Amazon.SageMaker.Model.CustomFileSystem> SpaceSettings_CustomFileSystem { get; set; }
            public List<Amazon.SageMaker.Model.CodeRepository> JupyterLabAppSettings_CodeRepository { get; set; }
            public Amazon.SageMaker.AppInstanceType SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_InstanceType { get; set; }
            public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String SpaceSettings_JupyterLabAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public List<Amazon.SageMaker.Model.CodeRepository> JupyterServerAppSettings_CodeRepository { get; set; }
            public Amazon.SageMaker.AppInstanceType SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_InstanceType { get; set; }
            public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String SpaceSettings_JupyterServerAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public List<System.String> JupyterServerAppSettings_LifecycleConfigArn { get; set; }
            public List<Amazon.SageMaker.Model.CustomImage> KernelGatewayAppSettings_CustomImage { get; set; }
            public Amazon.SageMaker.AppInstanceType SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_InstanceType { get; set; }
            public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionAlias { get; set; }
            public System.String SpaceSettings_KernelGatewayAppSettings_DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public List<System.String> KernelGatewayAppSettings_LifecycleConfigArn { get; set; }
            public System.Int32? EbsStorageSettings_EbsVolumeSizeInGb { get; set; }
            public Amazon.SageMaker.SharingType SpaceSharingSettings_SharingType { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateSpaceResponse, NewSMSpaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SpaceArn;
        }
        
    }
}
