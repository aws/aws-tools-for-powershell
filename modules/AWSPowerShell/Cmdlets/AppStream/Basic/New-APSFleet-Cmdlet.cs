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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates a fleet. A fleet consists of streaming instances that your users access for
    /// their applications and desktops.
    /// </summary>
    [Cmdlet("New", "APSFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Fleet")]
    [AWSCmdlet("Calls the Amazon AppStream CreateFleet API operation.", Operation = new[] {"CreateFleet"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateFleetResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.Fleet or Amazon.AppStream.Model.CreateFleetResponse",
        "This cmdlet returns an Amazon.AppStream.Model.Fleet object.",
        "The service call response (type Amazon.AppStream.Model.CreateFleetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAPSFleetCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ComputeCapacity_DesiredInstance
        /// <summary>
        /// <para>
        /// <para>The desired number of streaming instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeCapacity_DesiredInstances")]
        public System.Int32? ComputeCapacity_DesiredInstance { get; set; }
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
        
        #region Parameter DisconnectTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time that a streaming session remains active after users disconnect.
        /// If users try to reconnect to the streaming session after a disconnection or network
        /// interruption within this time interval, they are connected to their previous session.
        /// Otherwise, they are connected to a new session with a new streaming instance. </para><para>Specify a value between 60 and 360000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisconnectTimeoutInSeconds")]
        public System.Int32? DisconnectTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The fleet name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EnableDefaultInternetAccess
        /// <summary>
        /// <para>
        /// <para>Enables or disables default internet access for the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableDefaultInternetAccess { get; set; }
        #endregion
        
        #region Parameter FleetType
        /// <summary>
        /// <para>
        /// <para>The fleet type.</para><dl><dt>ALWAYS_ON</dt><dd><para>Provides users with instant-on access to their apps. You are charged for all running
        /// instances in your fleet, even if no users are streaming apps.</para></dd><dt>ON_DEMAND</dt><dd><para>Provide users with access to applications after they connect, which takes one to two
        /// minutes. You are charged for instance streaming when users are connected and a small
        /// hourly fee for instances that are not streaming apps.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.FleetType")]
        public Amazon.AppStream.FleetType FleetType { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to apply to the fleet. To assume a
        /// role, a fleet instance calls the AWS Security Token Service (STS) <code>AssumeRole</code>
        /// API operation and passes the ARN of the role to use. The operation creates a new session
        /// with temporary credentials. AppStream 2.0 retrieves the temporary credentials and
        /// creates the <b>appstream_machine_role</b> credential profile on the instance.</para><para>For more information, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/using-iam-roles-to-grant-permissions-to-applications-scripts-streaming-instances.html">Using
        /// an IAM Role to Grant Permissions to Applications and Scripts Running on AppStream
        /// 2.0 Streaming Instances</a> in the <i>Amazon AppStream 2.0 Administration Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter IdleDisconnectTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time that users can be idle (inactive) before they are disconnected
        /// from their streaming session and the <code>DisconnectTimeoutInSeconds</code> time
        /// interval begins. Users are notified before they are disconnected due to inactivity.
        /// If they try to reconnect to the streaming session before the time interval specified
        /// in <code>DisconnectTimeoutInSeconds</code> elapses, they are connected to their previous
        /// session. Users are considered idle when they stop providing keyboard or mouse input
        /// during their streaming session. File uploads and downloads, audio in, audio out, and
        /// pixels changing do not qualify as user activity. If users continue to be idle after
        /// the time interval in <code>IdleDisconnectTimeoutInSeconds</code> elapses, they are
        /// disconnected.</para><para>To prevent users from being disconnected due to inactivity, specify a value of 0.
        /// Otherwise, specify a value between 60 and 3600. The default value is 0.</para><note><para>If you enable this feature, we recommend that you specify a value that corresponds
        /// exactly to a whole number of minutes (for example, 60, 120, and 180). If you don't
        /// do this, the value is rounded to the nearest minute. For example, if you specify a
        /// value of 70, users are disconnected after 1 minute of inactivity. If you specify a
        /// value that is at the midpoint between two different minutes, the value is rounded
        /// up. For example, if you specify a value of 90, users are disconnected after 2 minutes
        /// of inactivity. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdleDisconnectTimeoutInSeconds")]
        public System.Int32? IdleDisconnectTimeoutInSecond { get; set; }
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
        /// <para>The name of the image used to create the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to use when launching fleet instances. The following instance types
        /// are available:</para><ul><li><para>stream.standard.small</para></li><li><para>stream.standard.medium</para></li><li><para>stream.standard.large</para></li><li><para>stream.standard.xlarge</para></li><li><para>stream.standard.2xlarge</para></li><li><para>stream.compute.large</para></li><li><para>stream.compute.xlarge</para></li><li><para>stream.compute.2xlarge</para></li><li><para>stream.compute.4xlarge</para></li><li><para>stream.compute.8xlarge</para></li><li><para>stream.memory.large</para></li><li><para>stream.memory.xlarge</para></li><li><para>stream.memory.2xlarge</para></li><li><para>stream.memory.4xlarge</para></li><li><para>stream.memory.8xlarge</para></li><li><para>stream.memory.z1d.large</para></li><li><para>stream.memory.z1d.xlarge</para></li><li><para>stream.memory.z1d.2xlarge</para></li><li><para>stream.memory.z1d.3xlarge</para></li><li><para>stream.memory.z1d.6xlarge</para></li><li><para>stream.memory.z1d.12xlarge</para></li><li><para>stream.graphics-design.large</para></li><li><para>stream.graphics-design.xlarge</para></li><li><para>stream.graphics-design.2xlarge</para></li><li><para>stream.graphics-design.4xlarge</para></li><li><para>stream.graphics-desktop.2xlarge</para></li><li><para>stream.graphics.g4dn.xlarge</para></li><li><para>stream.graphics.g4dn.2xlarge</para></li><li><para>stream.graphics.g4dn.4xlarge</para></li><li><para>stream.graphics.g4dn.8xlarge</para></li><li><para>stream.graphics.g4dn.12xlarge</para></li><li><para>stream.graphics.g4dn.16xlarge</para></li><li><para>stream.graphics-pro.4xlarge</para></li><li><para>stream.graphics-pro.8xlarge</para></li><li><para>stream.graphics-pro.16xlarge</para></li></ul><para>The following instance types are available for Elastic fleets:</para><ul><li><para>stream.standard.small</para></li><li><para>stream.standard.medium</para></li><li><para>stream.standard.large</para></li><li><para>stream.standard.xlarge</para></li><li><para>stream.standard.2xlarge</para></li></ul>
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
        
        #region Parameter MaxConcurrentSession
        /// <summary>
        /// <para>
        /// <para>The maximum concurrent sessions of the Elastic fleet. This is required for Elastic
        /// fleets, and not allowed for other fleet types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxConcurrentSessions")]
        public System.Int32? MaxConcurrentSession { get; set; }
        #endregion
        
        #region Parameter MaxUserDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time that a streaming session can remain active, in seconds.
        /// If users are still connected to a streaming instance five minutes before this limit
        /// is reached, they are prompted to save any open documents before being disconnected.
        /// After this time elapses, the instance is terminated and replaced by a new instance.</para><para>Specify a value between 600 and 360000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxUserDurationInSeconds")]
        public System.Int32? MaxUserDurationInSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique name for the fleet.</para>
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
        
        #region Parameter DomainJoinInfo_OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>The distinguished name of the organizational unit for computer accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainJoinInfo_OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The fleet platform. WINDOWS_SERVER_2019 and AMAZON_LINUX2 are supported for Elastic
        /// fleets. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.PlatformType")]
        public Amazon.AppStream.PlatformType Platform { get; set; }
        #endregion
        
        #region Parameter SessionScriptS3Location_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket of the S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionScriptS3Location_S3Bucket { get; set; }
        #endregion
        
        #region Parameter SessionScriptS3Location_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of the S3 object.</para><para>This is required when used for the following:</para><ul><li><para>IconS3Location (Actions: CreateApplication and UpdateApplication)</para></li><li><para>SessionScriptS3Location (Actions: CreateFleet and UpdateFleet)</para></li><li><para>ScriptDetails (Actions: CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <code>CUSTOM</code> PackagingType
        /// (Actions: CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <code>APPSTREAM2</code> PackagingType,
        /// and using an existing application package (VHD file). In this case, <code>S3Key</code>
        /// refers to the VHD file. If a new application package is required, then <code>S3Key</code>
        /// is not required. (Actions: CreateAppBlock)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionScriptS3Location_S3Key { get; set; }
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
        
        #region Parameter StreamView
        /// <summary>
        /// <para>
        /// <para>The AppStream 2.0 view that is displayed to your users when they stream from the fleet.
        /// When <code>APP</code> is specified, only the windows of applications opened by users
        /// display. When <code>DESKTOP</code> is specified, the standard desktop that is provided
        /// by the operating system displays.</para><para>The default value is <code>APP</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.StreamView")]
        public Amazon.AppStream.StreamView StreamView { get; set; }
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
        /// <para>The tags to associate with the fleet. A tag is a key-value pair, and the value is
        /// optional. For example, Environment=Test. If you do not specify a value, Environment=.
        /// </para><para>If you do not specify a value, the value is set to an empty string.</para><para>Generally allowed characters are: letters, numbers, and spaces representable in UTF-8,
        /// and the following special characters: </para><para>_ . : / = + \ - @</para><para>For more information, see <a href="https://docs.aws.amazon.com/appstream2/latest/developerguide/tagging-basic.html">Tagging
        /// Your Resources</a> in the <i>Amazon AppStream 2.0 Administration Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UsbDeviceFilterString
        /// <summary>
        /// <para>
        /// <para>The USB device filter strings that specify which USB devices a user can redirect to
        /// the fleet streaming session, when using the Windows native client. This is allowed
        /// but not required for Elastic fleets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UsbDeviceFilterStrings")]
        public System.String[] UsbDeviceFilterString { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Fleet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateFleetResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Fleet";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSFleet (CreateFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateFleetResponse, NewAPSFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputeCapacity_DesiredInstance = this.ComputeCapacity_DesiredInstance;
            context.Description = this.Description;
            context.DisconnectTimeoutInSecond = this.DisconnectTimeoutInSecond;
            context.DisplayName = this.DisplayName;
            context.DomainJoinInfo_DirectoryName = this.DomainJoinInfo_DirectoryName;
            context.DomainJoinInfo_OrganizationalUnitDistinguishedName = this.DomainJoinInfo_OrganizationalUnitDistinguishedName;
            context.EnableDefaultInternetAccess = this.EnableDefaultInternetAccess;
            context.FleetType = this.FleetType;
            context.IamRoleArn = this.IamRoleArn;
            context.IdleDisconnectTimeoutInSecond = this.IdleDisconnectTimeoutInSecond;
            context.ImageArn = this.ImageArn;
            context.ImageName = this.ImageName;
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxConcurrentSession = this.MaxConcurrentSession;
            context.MaxUserDurationInSecond = this.MaxUserDurationInSecond;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Platform = this.Platform;
            context.SessionScriptS3Location_S3Bucket = this.SessionScriptS3Location_S3Bucket;
            context.SessionScriptS3Location_S3Key = this.SessionScriptS3Location_S3Key;
            context.StreamView = this.StreamView;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            if (this.UsbDeviceFilterString != null)
            {
                context.UsbDeviceFilterString = new List<System.String>(this.UsbDeviceFilterString);
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
            var request = new Amazon.AppStream.Model.CreateFleetRequest();
            
            
             // populate ComputeCapacity
            var requestComputeCapacityIsNull = true;
            request.ComputeCapacity = new Amazon.AppStream.Model.ComputeCapacity();
            System.Int32? requestComputeCapacity_computeCapacity_DesiredInstance = null;
            if (cmdletContext.ComputeCapacity_DesiredInstance != null)
            {
                requestComputeCapacity_computeCapacity_DesiredInstance = cmdletContext.ComputeCapacity_DesiredInstance.Value;
            }
            if (requestComputeCapacity_computeCapacity_DesiredInstance != null)
            {
                request.ComputeCapacity.DesiredInstances = requestComputeCapacity_computeCapacity_DesiredInstance.Value;
                requestComputeCapacityIsNull = false;
            }
             // determine if request.ComputeCapacity should be set to null
            if (requestComputeCapacityIsNull)
            {
                request.ComputeCapacity = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisconnectTimeoutInSecond != null)
            {
                request.DisconnectTimeoutInSeconds = cmdletContext.DisconnectTimeoutInSecond.Value;
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
            if (cmdletContext.FleetType != null)
            {
                request.FleetType = cmdletContext.FleetType;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.IdleDisconnectTimeoutInSecond != null)
            {
                request.IdleDisconnectTimeoutInSeconds = cmdletContext.IdleDisconnectTimeoutInSecond.Value;
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
            if (cmdletContext.MaxConcurrentSession != null)
            {
                request.MaxConcurrentSessions = cmdletContext.MaxConcurrentSession.Value;
            }
            if (cmdletContext.MaxUserDurationInSecond != null)
            {
                request.MaxUserDurationInSeconds = cmdletContext.MaxUserDurationInSecond.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            
             // populate SessionScriptS3Location
            var requestSessionScriptS3LocationIsNull = true;
            request.SessionScriptS3Location = new Amazon.AppStream.Model.S3Location();
            System.String requestSessionScriptS3Location_sessionScriptS3Location_S3Bucket = null;
            if (cmdletContext.SessionScriptS3Location_S3Bucket != null)
            {
                requestSessionScriptS3Location_sessionScriptS3Location_S3Bucket = cmdletContext.SessionScriptS3Location_S3Bucket;
            }
            if (requestSessionScriptS3Location_sessionScriptS3Location_S3Bucket != null)
            {
                request.SessionScriptS3Location.S3Bucket = requestSessionScriptS3Location_sessionScriptS3Location_S3Bucket;
                requestSessionScriptS3LocationIsNull = false;
            }
            System.String requestSessionScriptS3Location_sessionScriptS3Location_S3Key = null;
            if (cmdletContext.SessionScriptS3Location_S3Key != null)
            {
                requestSessionScriptS3Location_sessionScriptS3Location_S3Key = cmdletContext.SessionScriptS3Location_S3Key;
            }
            if (requestSessionScriptS3Location_sessionScriptS3Location_S3Key != null)
            {
                request.SessionScriptS3Location.S3Key = requestSessionScriptS3Location_sessionScriptS3Location_S3Key;
                requestSessionScriptS3LocationIsNull = false;
            }
             // determine if request.SessionScriptS3Location should be set to null
            if (requestSessionScriptS3LocationIsNull)
            {
                request.SessionScriptS3Location = null;
            }
            if (cmdletContext.StreamView != null)
            {
                request.StreamView = cmdletContext.StreamView;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UsbDeviceFilterString != null)
            {
                request.UsbDeviceFilterStrings = cmdletContext.UsbDeviceFilterString;
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
        
        private Amazon.AppStream.Model.CreateFleetResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateFleet");
            try
            {
                #if DESKTOP
                return client.CreateFleet(request);
                #elif CORECLR
                return client.CreateFleetAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ComputeCapacity_DesiredInstance { get; set; }
            public System.String Description { get; set; }
            public System.Int32? DisconnectTimeoutInSecond { get; set; }
            public System.String DisplayName { get; set; }
            public System.String DomainJoinInfo_DirectoryName { get; set; }
            public System.String DomainJoinInfo_OrganizationalUnitDistinguishedName { get; set; }
            public System.Boolean? EnableDefaultInternetAccess { get; set; }
            public Amazon.AppStream.FleetType FleetType { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.Int32? IdleDisconnectTimeoutInSecond { get; set; }
            public System.String ImageArn { get; set; }
            public System.String ImageName { get; set; }
            public System.String InstanceType { get; set; }
            public System.Int32? MaxConcurrentSession { get; set; }
            public System.Int32? MaxUserDurationInSecond { get; set; }
            public System.String Name { get; set; }
            public Amazon.AppStream.PlatformType Platform { get; set; }
            public System.String SessionScriptS3Location_S3Bucket { get; set; }
            public System.String SessionScriptS3Location_S3Key { get; set; }
            public Amazon.AppStream.StreamView StreamView { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> UsbDeviceFilterString { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateFleetResponse, NewAPSFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Fleet;
        }
        
    }
}
