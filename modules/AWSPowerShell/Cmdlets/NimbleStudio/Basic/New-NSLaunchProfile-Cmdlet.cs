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
using Amazon.NimbleStudio;
using Amazon.NimbleStudio.Model;

namespace Amazon.PowerShell.Cmdlets.NS
{
    /// <summary>
    /// Create a launch profile.
    /// </summary>
    [Cmdlet("New", "NSLaunchProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NimbleStudio.Model.LaunchProfile")]
    [AWSCmdlet("Calls the Amazon Nimble Studio CreateLaunchProfile API operation.", Operation = new[] {"CreateLaunchProfile"}, SelectReturnType = typeof(Amazon.NimbleStudio.Model.CreateLaunchProfileResponse))]
    [AWSCmdletOutput("Amazon.NimbleStudio.Model.LaunchProfile or Amazon.NimbleStudio.Model.CreateLaunchProfileResponse",
        "This cmdlet returns an Amazon.NimbleStudio.Model.LaunchProfile object.",
        "The service call response (type Amazon.NimbleStudio.Model.CreateLaunchProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewNSLaunchProfileCmdlet : AmazonNimbleStudioClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StreamConfiguration_AutomaticTerminationMode
        /// <summary>
        /// <para>
        /// <para>Indicates if a streaming session created from this launch profile should be terminated
        /// automatically or retained without termination after being in a <code>STOPPED</code>
        /// state.</para><ul><li><para>When <code>ACTIVATED</code>, the streaming session is scheduled for termination after
        /// being in the <code>STOPPED</code> state for the time specified in <code>maxStoppedSessionLengthInMinutes</code>.</para></li><li><para>When <code>DEACTIVATED</code>, the streaming session can remain in the <code>STOPPED</code>
        /// state indefinitely.</para></li></ul><para>This parameter is only allowed when <code>sessionPersistenceMode</code> is <code>ACTIVATED</code>.
        /// When allowed, the default value for this parameter is <code>DEACTIVATED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NimbleStudio.AutomaticTerminationMode")]
        public Amazon.NimbleStudio.AutomaticTerminationMode StreamConfiguration_AutomaticTerminationMode { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_ClipboardMode
        /// <summary>
        /// <para>
        /// <para>Allows or deactivates the use of the system clipboard to copy and paste between the
        /// streaming session and streaming client.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NimbleStudio.StreamingClipboardMode")]
        public Amazon.NimbleStudio.StreamingClipboardMode StreamConfiguration_ClipboardMode { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_Ec2InstanceType
        /// <summary>
        /// <para>
        /// <para>The EC2 instance types that users can select from when launching a streaming session
        /// with this launch profile.</para>
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
        [Alias("StreamConfiguration_Ec2InstanceTypes")]
        public System.String[] StreamConfiguration_Ec2InstanceType { get; set; }
        #endregion
        
        #region Parameter Ec2SubnetId
        /// <summary>
        /// <para>
        /// <para>Specifies the IDs of the EC2 subnets where streaming sessions will be accessible from.
        /// These subnets must support the specified instance types. </para>
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
        [Alias("Ec2SubnetIds")]
        public System.String[] Ec2SubnetId { get; set; }
        #endregion
        
        #region Parameter VolumeConfiguration_Iops
        /// <summary>
        /// <para>
        /// <para>The number of I/O operations per second for the root volume that is attached to streaming
        /// session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_VolumeConfiguration_Iops")]
        public System.Int32? VolumeConfiguration_Iops { get; set; }
        #endregion
        
        #region Parameter LaunchProfileProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the protocol that is used by the launch profile. The only valid
        /// version is "2021-03-31".</para>
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
        [Alias("LaunchProfileProtocolVersions")]
        public System.String[] LaunchProfileProtocolVersion { get; set; }
        #endregion
        
        #region Parameter Root_Linux
        /// <summary>
        /// <para>
        /// <para>The folder path in Linux workstations where files are uploaded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionStorage_Root_Linux")]
        public System.String Root_Linux { get; set; }
        #endregion
        
        #region Parameter SessionBackup_MaxBackupsToRetain
        /// <summary>
        /// <para>
        /// <para>The maximum number of backups that each streaming session created from this launch
        /// profile can have.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionBackup_MaxBackupsToRetain")]
        public System.Int32? SessionBackup_MaxBackupsToRetain { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_MaxSessionLengthInMinute
        /// <summary>
        /// <para>
        /// <para>The length of time, in minutes, that a streaming session can be active before it is
        /// stopped or terminated. After this point, Nimble Studio automatically terminates or
        /// stops the session. The default length of time is 690 minutes, and the maximum length
        /// of time is 30 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_MaxSessionLengthInMinutes")]
        public System.Int32? StreamConfiguration_MaxSessionLengthInMinute { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_MaxStoppedSessionLengthInMinute
        /// <summary>
        /// <para>
        /// <para>Integer that determines if you can start and stop your sessions and how long a session
        /// can stay in the <code>STOPPED</code> state. The default value is 0. The maximum value
        /// is 5760.</para><para>This field is allowed only when <code>sessionPersistenceMode</code> is <code>ACTIVATED</code>
        /// and <code>automaticTerminationMode</code> is <code>ACTIVATED</code>.</para><para>If the value is set to 0, your sessions can’t be <code>STOPPED</code>. If you then
        /// call <code>StopStreamingSession</code>, the session fails. If the time that a session
        /// stays in the <code>READY</code> state exceeds the <code>maxSessionLengthInMinutes</code>
        /// value, the session will automatically be terminated (instead of <code>STOPPED</code>).</para><para>If the value is set to a positive number, the session can be stopped. You can call
        /// <code>StopStreamingSession</code> to stop sessions in the <code>READY</code> state.
        /// If the time that a session stays in the <code>READY</code> state exceeds the <code>maxSessionLengthInMinutes</code>
        /// value, the session will automatically be stopped (instead of terminated).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_MaxStoppedSessionLengthInMinutes")]
        public System.Int32? StreamConfiguration_MaxStoppedSessionLengthInMinute { get; set; }
        #endregion
        
        #region Parameter SessionBackup_Mode
        /// <summary>
        /// <para>
        /// <para>Specifies how artists sessions are backed up.</para><para>Configures backups for streaming sessions launched with this launch profile. The default
        /// value is <code>DEACTIVATED</code>, which means that backups are deactivated. To allow
        /// backups, set this value to <code>AUTOMATIC</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionBackup_Mode")]
        [AWSConstantClassSource("Amazon.NimbleStudio.SessionBackupMode")]
        public Amazon.NimbleStudio.SessionBackupMode SessionBackup_Mode { get; set; }
        #endregion
        
        #region Parameter SessionStorage_Mode
        /// <summary>
        /// <para>
        /// <para>Allows artists to upload files to their workstations. The only valid option is <code>UPLOAD</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionStorage_Mode")]
        public System.String[] SessionStorage_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the launch profile.</para>
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
        
        #region Parameter StreamConfiguration_SessionPersistenceMode
        /// <summary>
        /// <para>
        /// <para>Determine if a streaming session created from this launch profile can configure persistent
        /// storage. This means that <code>volumeConfiguration</code> and <code>automaticTerminationMode</code>
        /// are configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NimbleStudio.SessionPersistenceMode")]
        public Amazon.NimbleStudio.SessionPersistenceMode StreamConfiguration_SessionPersistenceMode { get; set; }
        #endregion
        
        #region Parameter VolumeConfiguration_Size
        /// <summary>
        /// <para>
        /// <para>The size of the root volume that is attached to the streaming session. The root volume
        /// size is measured in GiBs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_VolumeConfiguration_Size")]
        public System.Int32? VolumeConfiguration_Size { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_StreamingImageId
        /// <summary>
        /// <para>
        /// <para>The streaming images that users can select from when launching a streaming session
        /// with this launch profile.</para>
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
        [Alias("StreamConfiguration_StreamingImageIds")]
        public System.String[] StreamConfiguration_StreamingImageId { get; set; }
        #endregion
        
        #region Parameter StudioComponentId
        /// <summary>
        /// <para>
        /// <para>Unique identifiers for a collection of studio components that can be used with this
        /// launch profile.</para>
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
        [Alias("StudioComponentIds")]
        public System.String[] StudioComponentId { get; set; }
        #endregion
        
        #region Parameter StudioId
        /// <summary>
        /// <para>
        /// <para>The studio ID. </para>
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
        public System.String StudioId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A collection of labels, in the form of key-value pairs, that apply to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VolumeConfiguration_Throughput
        /// <summary>
        /// <para>
        /// <para>The throughput to provision for the root volume that is attached to the streaming
        /// session. The throughput is measured in MiB/s.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_VolumeConfiguration_Throughput")]
        public System.Int32? VolumeConfiguration_Throughput { get; set; }
        #endregion
        
        #region Parameter Root_Window
        /// <summary>
        /// <para>
        /// <para>The folder path in Windows workstations where files are uploaded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionStorage_Root_Windows")]
        public System.String Root_Window { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If you don’t specify a client token, the Amazon Web Services SDK automatically
        /// generates a client token and uses it for the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LaunchProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NimbleStudio.Model.CreateLaunchProfileResponse).
        /// Specifying the name of a property of type Amazon.NimbleStudio.Model.CreateLaunchProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LaunchProfile";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StudioId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StudioId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StudioId' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NSLaunchProfile (CreateLaunchProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NimbleStudio.Model.CreateLaunchProfileResponse, NewNSLaunchProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StudioId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.Ec2SubnetId != null)
            {
                context.Ec2SubnetId = new List<System.String>(this.Ec2SubnetId);
            }
            #if MODULAR
            if (this.Ec2SubnetId == null && ParameterWasBound(nameof(this.Ec2SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter Ec2SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LaunchProfileProtocolVersion != null)
            {
                context.LaunchProfileProtocolVersion = new List<System.String>(this.LaunchProfileProtocolVersion);
            }
            #if MODULAR
            if (this.LaunchProfileProtocolVersion == null && ParameterWasBound(nameof(this.LaunchProfileProtocolVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchProfileProtocolVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamConfiguration_AutomaticTerminationMode = this.StreamConfiguration_AutomaticTerminationMode;
            context.StreamConfiguration_ClipboardMode = this.StreamConfiguration_ClipboardMode;
            #if MODULAR
            if (this.StreamConfiguration_ClipboardMode == null && ParameterWasBound(nameof(this.StreamConfiguration_ClipboardMode)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamConfiguration_ClipboardMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StreamConfiguration_Ec2InstanceType != null)
            {
                context.StreamConfiguration_Ec2InstanceType = new List<System.String>(this.StreamConfiguration_Ec2InstanceType);
            }
            #if MODULAR
            if (this.StreamConfiguration_Ec2InstanceType == null && ParameterWasBound(nameof(this.StreamConfiguration_Ec2InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamConfiguration_Ec2InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamConfiguration_MaxSessionLengthInMinute = this.StreamConfiguration_MaxSessionLengthInMinute;
            context.StreamConfiguration_MaxStoppedSessionLengthInMinute = this.StreamConfiguration_MaxStoppedSessionLengthInMinute;
            context.SessionBackup_MaxBackupsToRetain = this.SessionBackup_MaxBackupsToRetain;
            context.SessionBackup_Mode = this.SessionBackup_Mode;
            context.StreamConfiguration_SessionPersistenceMode = this.StreamConfiguration_SessionPersistenceMode;
            if (this.SessionStorage_Mode != null)
            {
                context.SessionStorage_Mode = new List<System.String>(this.SessionStorage_Mode);
            }
            context.Root_Linux = this.Root_Linux;
            context.Root_Window = this.Root_Window;
            if (this.StreamConfiguration_StreamingImageId != null)
            {
                context.StreamConfiguration_StreamingImageId = new List<System.String>(this.StreamConfiguration_StreamingImageId);
            }
            #if MODULAR
            if (this.StreamConfiguration_StreamingImageId == null && ParameterWasBound(nameof(this.StreamConfiguration_StreamingImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamConfiguration_StreamingImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VolumeConfiguration_Iops = this.VolumeConfiguration_Iops;
            context.VolumeConfiguration_Size = this.VolumeConfiguration_Size;
            context.VolumeConfiguration_Throughput = this.VolumeConfiguration_Throughput;
            if (this.StudioComponentId != null)
            {
                context.StudioComponentId = new List<System.String>(this.StudioComponentId);
            }
            #if MODULAR
            if (this.StudioComponentId == null && ParameterWasBound(nameof(this.StudioComponentId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioComponentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StudioId = this.StudioId;
            #if MODULAR
            if (this.StudioId == null && ParameterWasBound(nameof(this.StudioId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.NimbleStudio.Model.CreateLaunchProfileRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Ec2SubnetId != null)
            {
                request.Ec2SubnetIds = cmdletContext.Ec2SubnetId;
            }
            if (cmdletContext.LaunchProfileProtocolVersion != null)
            {
                request.LaunchProfileProtocolVersions = cmdletContext.LaunchProfileProtocolVersion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate StreamConfiguration
            var requestStreamConfigurationIsNull = true;
            request.StreamConfiguration = new Amazon.NimbleStudio.Model.StreamConfigurationCreate();
            Amazon.NimbleStudio.AutomaticTerminationMode requestStreamConfiguration_streamConfiguration_AutomaticTerminationMode = null;
            if (cmdletContext.StreamConfiguration_AutomaticTerminationMode != null)
            {
                requestStreamConfiguration_streamConfiguration_AutomaticTerminationMode = cmdletContext.StreamConfiguration_AutomaticTerminationMode;
            }
            if (requestStreamConfiguration_streamConfiguration_AutomaticTerminationMode != null)
            {
                request.StreamConfiguration.AutomaticTerminationMode = requestStreamConfiguration_streamConfiguration_AutomaticTerminationMode;
                requestStreamConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.StreamingClipboardMode requestStreamConfiguration_streamConfiguration_ClipboardMode = null;
            if (cmdletContext.StreamConfiguration_ClipboardMode != null)
            {
                requestStreamConfiguration_streamConfiguration_ClipboardMode = cmdletContext.StreamConfiguration_ClipboardMode;
            }
            if (requestStreamConfiguration_streamConfiguration_ClipboardMode != null)
            {
                request.StreamConfiguration.ClipboardMode = requestStreamConfiguration_streamConfiguration_ClipboardMode;
                requestStreamConfigurationIsNull = false;
            }
            List<System.String> requestStreamConfiguration_streamConfiguration_Ec2InstanceType = null;
            if (cmdletContext.StreamConfiguration_Ec2InstanceType != null)
            {
                requestStreamConfiguration_streamConfiguration_Ec2InstanceType = cmdletContext.StreamConfiguration_Ec2InstanceType;
            }
            if (requestStreamConfiguration_streamConfiguration_Ec2InstanceType != null)
            {
                request.StreamConfiguration.Ec2InstanceTypes = requestStreamConfiguration_streamConfiguration_Ec2InstanceType;
                requestStreamConfigurationIsNull = false;
            }
            System.Int32? requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute = null;
            if (cmdletContext.StreamConfiguration_MaxSessionLengthInMinute != null)
            {
                requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute = cmdletContext.StreamConfiguration_MaxSessionLengthInMinute.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute != null)
            {
                request.StreamConfiguration.MaxSessionLengthInMinutes = requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute.Value;
                requestStreamConfigurationIsNull = false;
            }
            System.Int32? requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute = null;
            if (cmdletContext.StreamConfiguration_MaxStoppedSessionLengthInMinute != null)
            {
                requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute = cmdletContext.StreamConfiguration_MaxStoppedSessionLengthInMinute.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute != null)
            {
                request.StreamConfiguration.MaxStoppedSessionLengthInMinutes = requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute.Value;
                requestStreamConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.SessionPersistenceMode requestStreamConfiguration_streamConfiguration_SessionPersistenceMode = null;
            if (cmdletContext.StreamConfiguration_SessionPersistenceMode != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionPersistenceMode = cmdletContext.StreamConfiguration_SessionPersistenceMode;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionPersistenceMode != null)
            {
                request.StreamConfiguration.SessionPersistenceMode = requestStreamConfiguration_streamConfiguration_SessionPersistenceMode;
                requestStreamConfigurationIsNull = false;
            }
            List<System.String> requestStreamConfiguration_streamConfiguration_StreamingImageId = null;
            if (cmdletContext.StreamConfiguration_StreamingImageId != null)
            {
                requestStreamConfiguration_streamConfiguration_StreamingImageId = cmdletContext.StreamConfiguration_StreamingImageId;
            }
            if (requestStreamConfiguration_streamConfiguration_StreamingImageId != null)
            {
                request.StreamConfiguration.StreamingImageIds = requestStreamConfiguration_streamConfiguration_StreamingImageId;
                requestStreamConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.Model.StreamConfigurationSessionBackup requestStreamConfiguration_streamConfiguration_SessionBackup = null;
            
             // populate SessionBackup
            var requestStreamConfiguration_streamConfiguration_SessionBackupIsNull = true;
            requestStreamConfiguration_streamConfiguration_SessionBackup = new Amazon.NimbleStudio.Model.StreamConfigurationSessionBackup();
            System.Int32? requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_MaxBackupsToRetain = null;
            if (cmdletContext.SessionBackup_MaxBackupsToRetain != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_MaxBackupsToRetain = cmdletContext.SessionBackup_MaxBackupsToRetain.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_MaxBackupsToRetain != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionBackup.MaxBackupsToRetain = requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_MaxBackupsToRetain.Value;
                requestStreamConfiguration_streamConfiguration_SessionBackupIsNull = false;
            }
            Amazon.NimbleStudio.SessionBackupMode requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_Mode = null;
            if (cmdletContext.SessionBackup_Mode != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_Mode = cmdletContext.SessionBackup_Mode;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_Mode != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionBackup.Mode = requestStreamConfiguration_streamConfiguration_SessionBackup_sessionBackup_Mode;
                requestStreamConfiguration_streamConfiguration_SessionBackupIsNull = false;
            }
             // determine if requestStreamConfiguration_streamConfiguration_SessionBackup should be set to null
            if (requestStreamConfiguration_streamConfiguration_SessionBackupIsNull)
            {
                requestStreamConfiguration_streamConfiguration_SessionBackup = null;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionBackup != null)
            {
                request.StreamConfiguration.SessionBackup = requestStreamConfiguration_streamConfiguration_SessionBackup;
                requestStreamConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.Model.StreamConfigurationSessionStorage requestStreamConfiguration_streamConfiguration_SessionStorage = null;
            
             // populate SessionStorage
            var requestStreamConfiguration_streamConfiguration_SessionStorageIsNull = true;
            requestStreamConfiguration_streamConfiguration_SessionStorage = new Amazon.NimbleStudio.Model.StreamConfigurationSessionStorage();
            List<System.String> requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode = null;
            if (cmdletContext.SessionStorage_Mode != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode = cmdletContext.SessionStorage_Mode;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage.Mode = requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode;
                requestStreamConfiguration_streamConfiguration_SessionStorageIsNull = false;
            }
            Amazon.NimbleStudio.Model.StreamingSessionStorageRoot requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root = null;
            
             // populate Root
            var requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull = true;
            requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root = new Amazon.NimbleStudio.Model.StreamingSessionStorageRoot();
            System.String requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux = null;
            if (cmdletContext.Root_Linux != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux = cmdletContext.Root_Linux;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root.Linux = requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux;
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull = false;
            }
            System.String requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window = null;
            if (cmdletContext.Root_Window != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window = cmdletContext.Root_Window;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root.Windows = requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window;
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull = false;
            }
             // determine if requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root should be set to null
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root = null;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage.Root = requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root;
                requestStreamConfiguration_streamConfiguration_SessionStorageIsNull = false;
            }
             // determine if requestStreamConfiguration_streamConfiguration_SessionStorage should be set to null
            if (requestStreamConfiguration_streamConfiguration_SessionStorageIsNull)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage = null;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage != null)
            {
                request.StreamConfiguration.SessionStorage = requestStreamConfiguration_streamConfiguration_SessionStorage;
                requestStreamConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.Model.VolumeConfiguration requestStreamConfiguration_streamConfiguration_VolumeConfiguration = null;
            
             // populate VolumeConfiguration
            var requestStreamConfiguration_streamConfiguration_VolumeConfigurationIsNull = true;
            requestStreamConfiguration_streamConfiguration_VolumeConfiguration = new Amazon.NimbleStudio.Model.VolumeConfiguration();
            System.Int32? requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Iops = null;
            if (cmdletContext.VolumeConfiguration_Iops != null)
            {
                requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Iops = cmdletContext.VolumeConfiguration_Iops.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Iops != null)
            {
                requestStreamConfiguration_streamConfiguration_VolumeConfiguration.Iops = requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Iops.Value;
                requestStreamConfiguration_streamConfiguration_VolumeConfigurationIsNull = false;
            }
            System.Int32? requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Size = null;
            if (cmdletContext.VolumeConfiguration_Size != null)
            {
                requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Size = cmdletContext.VolumeConfiguration_Size.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Size != null)
            {
                requestStreamConfiguration_streamConfiguration_VolumeConfiguration.Size = requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Size.Value;
                requestStreamConfiguration_streamConfiguration_VolumeConfigurationIsNull = false;
            }
            System.Int32? requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Throughput = null;
            if (cmdletContext.VolumeConfiguration_Throughput != null)
            {
                requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Throughput = cmdletContext.VolumeConfiguration_Throughput.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Throughput != null)
            {
                requestStreamConfiguration_streamConfiguration_VolumeConfiguration.Throughput = requestStreamConfiguration_streamConfiguration_VolumeConfiguration_volumeConfiguration_Throughput.Value;
                requestStreamConfiguration_streamConfiguration_VolumeConfigurationIsNull = false;
            }
             // determine if requestStreamConfiguration_streamConfiguration_VolumeConfiguration should be set to null
            if (requestStreamConfiguration_streamConfiguration_VolumeConfigurationIsNull)
            {
                requestStreamConfiguration_streamConfiguration_VolumeConfiguration = null;
            }
            if (requestStreamConfiguration_streamConfiguration_VolumeConfiguration != null)
            {
                request.StreamConfiguration.VolumeConfiguration = requestStreamConfiguration_streamConfiguration_VolumeConfiguration;
                requestStreamConfigurationIsNull = false;
            }
             // determine if request.StreamConfiguration should be set to null
            if (requestStreamConfigurationIsNull)
            {
                request.StreamConfiguration = null;
            }
            if (cmdletContext.StudioComponentId != null)
            {
                request.StudioComponentIds = cmdletContext.StudioComponentId;
            }
            if (cmdletContext.StudioId != null)
            {
                request.StudioId = cmdletContext.StudioId;
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
        
        private Amazon.NimbleStudio.Model.CreateLaunchProfileResponse CallAWSServiceOperation(IAmazonNimbleStudio client, Amazon.NimbleStudio.Model.CreateLaunchProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nimble Studio", "CreateLaunchProfile");
            try
            {
                #if DESKTOP
                return client.CreateLaunchProfile(request);
                #elif CORECLR
                return client.CreateLaunchProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<System.String> Ec2SubnetId { get; set; }
            public List<System.String> LaunchProfileProtocolVersion { get; set; }
            public System.String Name { get; set; }
            public Amazon.NimbleStudio.AutomaticTerminationMode StreamConfiguration_AutomaticTerminationMode { get; set; }
            public Amazon.NimbleStudio.StreamingClipboardMode StreamConfiguration_ClipboardMode { get; set; }
            public List<System.String> StreamConfiguration_Ec2InstanceType { get; set; }
            public System.Int32? StreamConfiguration_MaxSessionLengthInMinute { get; set; }
            public System.Int32? StreamConfiguration_MaxStoppedSessionLengthInMinute { get; set; }
            public System.Int32? SessionBackup_MaxBackupsToRetain { get; set; }
            public Amazon.NimbleStudio.SessionBackupMode SessionBackup_Mode { get; set; }
            public Amazon.NimbleStudio.SessionPersistenceMode StreamConfiguration_SessionPersistenceMode { get; set; }
            public List<System.String> SessionStorage_Mode { get; set; }
            public System.String Root_Linux { get; set; }
            public System.String Root_Window { get; set; }
            public List<System.String> StreamConfiguration_StreamingImageId { get; set; }
            public System.Int32? VolumeConfiguration_Iops { get; set; }
            public System.Int32? VolumeConfiguration_Size { get; set; }
            public System.Int32? VolumeConfiguration_Throughput { get; set; }
            public List<System.String> StudioComponentId { get; set; }
            public System.String StudioId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NimbleStudio.Model.CreateLaunchProfileResponse, NewNSLaunchProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchProfile;
        }
        
    }
}
