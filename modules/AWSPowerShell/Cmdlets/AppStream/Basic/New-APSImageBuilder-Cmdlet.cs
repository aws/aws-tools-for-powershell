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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates an image builder. An image builder is a virtual machine that is used to create
    /// an image.
    /// 
    ///  
    /// <para>
    /// The initial state of the builder is <c>PENDING</c>. When it is ready, the state is
    /// <c>RUNNING</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "APSImageBuilder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.ImageBuilder")]
    [AWSCmdlet("Calls the Amazon AppStream CreateImageBuilder API operation.", Operation = new[] {"CreateImageBuilder"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateImageBuilderResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.ImageBuilder or Amazon.AppStream.Model.CreateImageBuilderResponse",
        "This cmdlet returns an Amazon.AppStream.Model.ImageBuilder object.",
        "The service call response (type Amazon.AppStream.Model.CreateImageBuilderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAPSImageBuilderCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessEndpoint
        /// <summary>
        /// <para>
        /// <para>The list of interface VPC endpoint (interface endpoint) objects. Administrators can
        /// connect to the image builder only through the specified endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessEndpoints")]
        public Amazon.AppStream.Model.AccessEndpoint[] AccessEndpoint { get; set; }
        #endregion
        
        #region Parameter AppstreamAgentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the WorkSpaces Applications agent to use for this image builder. To
        /// use the latest version of the WorkSpaces Applications agent, specify [LATEST]. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppstreamAgentVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainJoinInfo_DirectoryName
        /// <summary>
        /// <para>
        /// <para>The fully qualified name of the directory (for example, corp.example.com).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainJoinInfo_DirectoryName { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The image builder name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EnableDefaultInternetAccess
        /// <summary>
        /// <para>
        /// <para>Enables or disables default internet access for the image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableDefaultInternetAccess { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to apply to the image builder. To assume
        /// a role, the image builder calls the AWS Security Token Service (STS) <c>AssumeRole</c>
        /// API operation and passes the ARN of the role to use. The operation creates a new session
        /// with temporary credentials. WorkSpaces Applications retrieves the temporary credentials
        /// and creates the <b>appstream_machine_role</b> credential profile on the instance.</para><para>For more information, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/using-iam-roles-to-grant-permissions-to-applications-scripts-streaming-instances.html">Using
        /// an IAM Role to Grant Permissions to Applications and Scripts Running on WorkSpaces
        /// Applications Streaming Instances</a> in the <i>Amazon WorkSpaces Applications Administration
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter ImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the public, private, or shared image to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageArn { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>The name of the image used to create the image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use when launching the image builder. The following instance
        /// types are available:</para><ul><li><para>stream.standard.small</para></li><li><para>stream.standard.medium</para></li><li><para>stream.standard.large</para></li><li><para>stream.compute.large</para></li><li><para>stream.compute.xlarge</para></li><li><para>stream.compute.2xlarge</para></li><li><para>stream.compute.4xlarge</para></li><li><para>stream.compute.8xlarge</para></li><li><para>stream.memory.large</para></li><li><para>stream.memory.xlarge</para></li><li><para>stream.memory.2xlarge</para></li><li><para>stream.memory.4xlarge</para></li><li><para>stream.memory.8xlarge</para></li><li><para>stream.memory.z1d.large</para></li><li><para>stream.memory.z1d.xlarge</para></li><li><para>stream.memory.z1d.2xlarge</para></li><li><para>stream.memory.z1d.3xlarge</para></li><li><para>stream.memory.z1d.6xlarge</para></li><li><para>stream.memory.z1d.12xlarge</para></li><li><para>stream.graphics.g4dn.xlarge</para></li><li><para>stream.graphics.g4dn.2xlarge</para></li><li><para>stream.graphics.g4dn.4xlarge</para></li><li><para>stream.graphics.g4dn.8xlarge</para></li><li><para>stream.graphics.g4dn.12xlarge</para></li><li><para>stream.graphics.g4dn.16xlarge</para></li><li><para>stream.graphics.g5.xlarge</para></li><li><para>stream.graphics.g5.2xlarge</para></li><li><para>stream.graphics.g5.4xlarge</para></li><li><para>stream.graphics.g5.8xlarge</para></li><li><para>stream.graphics.g5.16xlarge</para></li><li><para>stream.graphics.g5.12xlarge</para></li><li><para>stream.graphics.g5.24xlarge</para></li><li><para>stream.graphics.g6.xlarge</para></li><li><para>stream.graphics.g6.2xlarge</para></li><li><para>stream.graphics.g6.4xlarge</para></li><li><para>stream.graphics.g6.8xlarge</para></li><li><para>stream.graphics.g6.16xlarge</para></li><li><para>stream.graphics.g6.12xlarge</para></li><li><para>stream.graphics.g6.24xlarge</para></li><li><para>stream.graphics.gr6.4xlarge</para></li><li><para>stream.graphics.gr6.8xlarge</para></li><li><para>stream.graphics.g6f.large</para></li><li><para>stream.graphics.g6f.xlarge</para></li><li><para>stream.graphics.g6f.2xlarge</para></li><li><para>stream.graphics.g6f.4xlarge</para></li><li><para>stream.graphics.gr6f.4xlarge</para></li></ul>
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
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the image builder.</para>
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
        
        #region Parameter DomainJoinInfo_OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>The distinguished name of the organizational unit for computer accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainJoinInfo_OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the security groups for the fleet or image builder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SoftwaresToInstall
        /// <summary>
        /// <para>
        /// <para>The list of license included applications to install on the image builder during creation.</para><para>Possible values include the following:</para><ul><li><para>Microsoft_Office_2021_LTSC_Professional_Plus_32Bit</para></li><li><para>Microsoft_Office_2021_LTSC_Professional_Plus_64Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Professional_Plus_32Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Professional_Plus_64Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Professional_32Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Professional_64Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Professional_32Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Professional_64Bit</para></li><li><para>Microsoft_Project_2021_Professional_32Bit</para></li><li><para>Microsoft_Project_2021_Professional_64Bit</para></li><li><para>Microsoft_Project_2024_Professional_32Bit</para></li><li><para>Microsoft_Project_2024_Professional_64Bit</para></li><li><para>Microsoft_Office_2021_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Office_2021_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Project_2021_Standard_32Bit</para></li><li><para>Microsoft_Project_2021_Standard_64Bit</para></li><li><para>Microsoft_Project_2024_Standard_32Bit</para></li><li><para>Microsoft_Project_2024_Standard_64Bit</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SoftwaresToInstall { get; set; }
        #endregion
        
        #region Parameter SoftwaresToUninstall
        /// <summary>
        /// <para>
        /// <para>The list of license included applications to uninstall from the image builder during
        /// creation.</para><para>Possible values include the following:</para><ul><li><para>Microsoft_Office_2021_LTSC_Professional_Plus_32Bit</para></li><li><para>Microsoft_Office_2021_LTSC_Professional_Plus_64Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Professional_Plus_32Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Professional_Plus_64Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Professional_32Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Professional_64Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Professional_32Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Professional_64Bit</para></li><li><para>Microsoft_Project_2021_Professional_32Bit</para></li><li><para>Microsoft_Project_2021_Professional_64Bit</para></li><li><para>Microsoft_Project_2024_Professional_32Bit</para></li><li><para>Microsoft_Project_2024_Professional_64Bit</para></li><li><para>Microsoft_Office_2021_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Office_2021_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Office_2024_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Visio_2021_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Standard_32Bit</para></li><li><para>Microsoft_Visio_2024_LTSC_Standard_64Bit</para></li><li><para>Microsoft_Project_2021_Standard_32Bit</para></li><li><para>Microsoft_Project_2021_Standard_64Bit</para></li><li><para>Microsoft_Project_2024_Standard_32Bit</para></li><li><para>Microsoft_Project_2024_Standard_64Bit</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SoftwaresToUninstall { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifiers of the subnets to which a network interface is attached from the fleet
        /// instance or image builder instance. Fleet instances use one or more subnets. Image
        /// builder instances use one subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the image builder. A tag is a key-value pair, and the value
        /// is optional. For example, Environment=Test. If you do not specify a value, Environment=.
        /// </para><para>Generally allowed characters are: letters, numbers, and spaces representable in UTF-8,
        /// and the following special characters: </para><para>_ . : / = + \ - @</para><para>If you do not specify a value, the value is set to an empty string.</para><para>For more information about tags, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/tagging-basic.html">Tagging
        /// Your Resources</a> in the <i>Amazon WorkSpaces Applications Administration Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter RootVolumeConfig_VolumeSizeInGb
        /// <summary>
        /// <para>
        /// <para>The size of the root volume in GB. Valid range is 200-500 GB. The default is 200 GB,
        /// which is included in the hourly instance rate. Additional storage beyond 200 GB incurs
        /// extra charges and applies to instances regardless of their running state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RootVolumeConfig_VolumeSizeInGb { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageBuilder'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateImageBuilderResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateImageBuilderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageBuilder";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSImageBuilder (CreateImageBuilder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateImageBuilderResponse, NewAPSImageBuilderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccessEndpoint != null)
            {
                context.AccessEndpoint = new List<Amazon.AppStream.Model.AccessEndpoint>(this.AccessEndpoint);
            }
            context.AppstreamAgentVersion = this.AppstreamAgentVersion;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.DomainJoinInfo_DirectoryName = this.DomainJoinInfo_DirectoryName;
            context.DomainJoinInfo_OrganizationalUnitDistinguishedName = this.DomainJoinInfo_OrganizationalUnitDistinguishedName;
            context.EnableDefaultInternetAccess = this.EnableDefaultInternetAccess;
            context.IamRoleArn = this.IamRoleArn;
            context.ImageArn = this.ImageArn;
            context.ImageName = this.ImageName;
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RootVolumeConfig_VolumeSizeInGb = this.RootVolumeConfig_VolumeSizeInGb;
            if (this.SoftwaresToInstall != null)
            {
                context.SoftwaresToInstall = new List<System.String>(this.SoftwaresToInstall);
            }
            if (this.SoftwaresToUninstall != null)
            {
                context.SoftwaresToUninstall = new List<System.String>(this.SoftwaresToUninstall);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
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
            var request = new Amazon.AppStream.Model.CreateImageBuilderRequest();
            
            if (cmdletContext.AccessEndpoint != null)
            {
                request.AccessEndpoints = cmdletContext.AccessEndpoint;
            }
            if (cmdletContext.AppstreamAgentVersion != null)
            {
                request.AppstreamAgentVersion = cmdletContext.AppstreamAgentVersion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate DomainJoinInfo
            var requestDomainJoinInfoIsNull = true;
            request.DomainJoinInfo = new Amazon.AppStream.Model.DomainJoinInfo();
            System.String requestDomainJoinInfo_domainJoinInfo_DirectoryName = null;
            if (cmdletContext.DomainJoinInfo_DirectoryName != null)
            {
                requestDomainJoinInfo_domainJoinInfo_DirectoryName = cmdletContext.DomainJoinInfo_DirectoryName;
            }
            if (requestDomainJoinInfo_domainJoinInfo_DirectoryName != null)
            {
                request.DomainJoinInfo.DirectoryName = requestDomainJoinInfo_domainJoinInfo_DirectoryName;
                requestDomainJoinInfoIsNull = false;
            }
            System.String requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName = null;
            if (cmdletContext.DomainJoinInfo_OrganizationalUnitDistinguishedName != null)
            {
                requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName = cmdletContext.DomainJoinInfo_OrganizationalUnitDistinguishedName;
            }
            if (requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName != null)
            {
                request.DomainJoinInfo.OrganizationalUnitDistinguishedName = requestDomainJoinInfo_domainJoinInfo_OrganizationalUnitDistinguishedName;
                requestDomainJoinInfoIsNull = false;
            }
             // determine if request.DomainJoinInfo should be set to null
            if (requestDomainJoinInfoIsNull)
            {
                request.DomainJoinInfo = null;
            }
            if (cmdletContext.EnableDefaultInternetAccess != null)
            {
                request.EnableDefaultInternetAccess = cmdletContext.EnableDefaultInternetAccess.Value;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.ImageArn != null)
            {
                request.ImageArn = cmdletContext.ImageArn;
            }
            if (cmdletContext.ImageName != null)
            {
                request.ImageName = cmdletContext.ImageName;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RootVolumeConfig
            var requestRootVolumeConfigIsNull = true;
            request.RootVolumeConfig = new Amazon.AppStream.Model.VolumeConfig();
            System.Int32? requestRootVolumeConfig_rootVolumeConfig_VolumeSizeInGb = null;
            if (cmdletContext.RootVolumeConfig_VolumeSizeInGb != null)
            {
                requestRootVolumeConfig_rootVolumeConfig_VolumeSizeInGb = cmdletContext.RootVolumeConfig_VolumeSizeInGb.Value;
            }
            if (requestRootVolumeConfig_rootVolumeConfig_VolumeSizeInGb != null)
            {
                request.RootVolumeConfig.VolumeSizeInGb = requestRootVolumeConfig_rootVolumeConfig_VolumeSizeInGb.Value;
                requestRootVolumeConfigIsNull = false;
            }
             // determine if request.RootVolumeConfig should be set to null
            if (requestRootVolumeConfigIsNull)
            {
                request.RootVolumeConfig = null;
            }
            if (cmdletContext.SoftwaresToInstall != null)
            {
                request.SoftwaresToInstall = cmdletContext.SoftwaresToInstall;
            }
            if (cmdletContext.SoftwaresToUninstall != null)
            {
                request.SoftwaresToUninstall = cmdletContext.SoftwaresToUninstall;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.AppStream.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
            if (cmdletContext.VpcConfig_SubnetId != null)
            {
                requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
            }
            if (requestVpcConfig_vpcConfig_SubnetId != null)
            {
                request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.AppStream.Model.CreateImageBuilderResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateImageBuilderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateImageBuilder");
            try
            {
                #if DESKTOP
                return client.CreateImageBuilder(request);
                #elif CORECLR
                return client.CreateImageBuilderAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.AppStream.Model.AccessEndpoint> AccessEndpoint { get; set; }
            public System.String AppstreamAgentVersion { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String DomainJoinInfo_DirectoryName { get; set; }
            public System.String DomainJoinInfo_OrganizationalUnitDistinguishedName { get; set; }
            public System.Boolean? EnableDefaultInternetAccess { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String ImageArn { get; set; }
            public System.String ImageName { get; set; }
            public System.String InstanceType { get; set; }
            public System.String Name { get; set; }
            public System.Int32? RootVolumeConfig_VolumeSizeInGb { get; set; }
            public List<System.String> SoftwaresToInstall { get; set; }
            public List<System.String> SoftwaresToUninstall { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateImageBuilderResponse, NewAPSImageBuilderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageBuilder;
        }
        
    }
}
