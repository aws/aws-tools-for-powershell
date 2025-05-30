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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates a launch configuration.
    /// 
    ///  
    /// <para>
    /// If you exceed your maximum limit of launch configurations, the call fails. To query
    /// this limit, call the <a href="https://docs.aws.amazon.com/autoscaling/ec2/APIReference/API_DescribeAccountLimits.html">DescribeAccountLimits</a>
    /// API. For information about updating this limit, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-quotas.html">Quotas
    /// for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/launch-configurations.html">Launch
    /// configurations</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><note><para>
    /// Amazon EC2 Auto Scaling configures instances launched as part of an Auto Scaling group
    /// using either a launch template or a launch configuration. We strongly recommend that
    /// you do not use launch configurations. They do not provide full functionality for Amazon
    /// EC2 Auto Scaling or Amazon EC2. For information about using launch templates, see
    /// <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/launch-templates.html">Launch
    /// templates</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "ASLaunchConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling CreateLaunchConfiguration API operation.", Operation = new[] {"CreateLaunchConfiguration"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewASLaunchConfigurationCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatePublicIpAddress
        /// <summary>
        /// <para>
        /// <para>Specifies whether to assign a public IPv4 address to the group's instances. If the
        /// instance is launched into a default subnet, the default is to assign a public IPv4
        /// address, unless you disabled the option to assign a public IPv4 address on the subnet.
        /// If the instance is launched into a nondefault subnet, the default is not to assign
        /// a public IPv4 address, unless you enabled the option to assign a public IPv4 address
        /// on the subnet.</para><para>If you specify <c>true</c>, each instance in the Auto Scaling group receives a unique
        /// public IPv4 address. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-in-vpc.html">Provide
        /// network connectivity for your Auto Scaling instances using Amazon VPC</a> in the <i>Amazon
        /// EC2 Auto Scaling User Guide</i>.</para><para>If you specify this property, you must specify at least one subnet for <c>VPCZoneIdentifier</c>
        /// when you create your group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssociatePublicIpAddress { get; set; }
        #endregion
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>The block device mapping entries that define the block devices to attach to the instances
        /// at launch. By default, the block devices specified in the block device mapping for
        /// the AMI are used. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html">Block
        /// device mappings</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockDeviceMappings")]
        public Amazon.AutoScaling.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter ClassicLinkVPCId
        /// <summary>
        /// <para>
        /// <para>Available for backward compatibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClassicLinkVPCId { get; set; }
        #endregion
        
        #region Parameter ClassicLinkVPCSecurityGroup
        /// <summary>
        /// <para>
        /// <para>Available for backward compatibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClassicLinkVPCSecurityGroups")]
        public System.String[] ClassicLinkVPCSecurityGroup { get; set; }
        #endregion
        
        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Specifies whether the launch configuration is optimized for EBS I/O (<c>true</c>)
        /// or not (<c>false</c>). The optimization provides dedicated throughput to Amazon EBS
        /// and an optimized configuration stack to provide optimal I/O performance. This optimization
        /// is not available with all instance types. Additional fees are incurred when you enable
        /// EBS optimization for an instance type that is not EBS-optimized by default. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ebs-optimized.html">Amazon
        /// EBS-optimized instances</a> in the <i>Amazon EC2 User Guide</i>.</para><para>The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EbsOptimized { get; set; }
        #endregion
        
        #region Parameter InstanceMonitoring_Enabled
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, detailed monitoring is enabled. Otherwise, basic monitoring is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceMonitoring_Enabled { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpEndpoint
        /// <summary>
        /// <para>
        /// <para>This parameter enables or disables the HTTP metadata endpoint on your instances. If
        /// the parameter is not specified, the default state is <c>enabled</c>.</para><note><para>If you specify a value of <c>disabled</c>, you will not be able to access your instance
        /// metadata. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AutoScaling.InstanceMetadataEndpointState")]
        public Amazon.AutoScaling.InstanceMetadataEndpointState MetadataOptions_HttpEndpoint { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpPutResponseHopLimit
        /// <summary>
        /// <para>
        /// <para>The desired HTTP PUT response hop limit for instance metadata requests. The larger
        /// the number, the further instance metadata requests can travel.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MetadataOptions_HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpToken
        /// <summary>
        /// <para>
        /// <para>The state of token usage for your instance metadata requests. If the parameter is
        /// not specified in the request, the default state is <c>optional</c>.</para><para>If the state is <c>optional</c>, you can choose to retrieve instance metadata with
        /// or without a signed token header on your request. If you retrieve the IAM role credentials
        /// without a token, the version 1.0 role credentials are returned. If you retrieve the
        /// IAM role credentials using a valid signed token, the version 2.0 role credentials
        /// are returned.</para><para>If the state is <c>required</c>, you must send a signed token header with any instance
        /// metadata retrieval requests. In this state, retrieving the IAM role credentials always
        /// returns the version 2.0 credentials; the version 1.0 credentials are not available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetadataOptions_HttpTokens")]
        [AWSConstantClassSource("Amazon.AutoScaling.InstanceMetadataHttpTokensState")]
        public Amazon.AutoScaling.InstanceMetadataHttpTokensState MetadataOptions_HttpToken { get; set; }
        #endregion
        
        #region Parameter IamInstanceProfile
        /// <summary>
        /// <para>
        /// <para>The name or the Amazon Resource Name (ARN) of the instance profile associated with
        /// the IAM role for the instance. The instance profile contains the IAM role. For more
        /// information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/us-iam-role.html">IAM
        /// role for applications that run on Amazon EC2 instances</a> in the <i>Amazon EC2 Auto
        /// Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamInstanceProfile { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Machine Image (AMI) that was assigned during registration. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/finding-an-ami.html">Find
        /// a Linux AMI</a> in the <i>Amazon EC2 User Guide</i>.</para><para>If you specify <c>InstanceId</c>, an <c>ImageId</c> is not required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance to use to create the launch configuration. The new launch configuration
        /// derives attributes from the instance, except for the block device mapping.</para><para>To create a launch configuration with a block device mapping or override any other
        /// instance attributes, specify them as part of the same request.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/create-launch-config.html">Create
        /// a launch configuration</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Specifies the instance type of the EC2 instance. For information about available instance
        /// types, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html#AvailableInstanceTypes">Available
        /// instance types</a> in the <i>Amazon EC2 User Guide</i>.</para><para>If you specify <c>InstanceId</c>, an <c>InstanceType</c> is not required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter KernelId
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel associated with the AMI.</para><note><para>We recommend that you use PV-GRUB instead of kernels and RAM disks. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedKernels.html">User
        /// provided kernels</a> in the <i>Amazon EC2 User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KernelId { get; set; }
        #endregion
        
        #region Parameter KeyName
        /// <summary>
        /// <para>
        /// <para>The name of the key pair. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Amazon
        /// EC2 key pairs and Amazon EC2 instances</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String KeyName { get; set; }
        #endregion
        
        #region Parameter LaunchConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the launch configuration. This name must be unique per Region per account.</para>
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
        public System.String LaunchConfigurationName { get; set; }
        #endregion
        
        #region Parameter PlacementTenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instance, either <c>default</c> or <c>dedicated</c>. An instance
        /// with <c>dedicated</c> tenancy runs on isolated, single-tenant hardware and can only
        /// be launched into a VPC. To launch dedicated instances into a shared tenancy VPC (a
        /// VPC with the instance placement tenancy attribute set to <c>default</c>), you must
        /// set the value of this property to <c>dedicated</c>.</para><para>If you specify <c>PlacementTenancy</c>, you must specify at least one subnet for <c>VPCZoneIdentifier</c>
        /// when you create your group.</para><para>Valid values: <c>default</c> | <c>dedicated</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlacementTenancy { get; set; }
        #endregion
        
        #region Parameter RamdiskId
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk to select.</para><note><para>We recommend that you use PV-GRUB instead of kernels and RAM disks. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedKernels.html">User
        /// provided kernels</a> in the <i>Amazon EC2 User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RamdiskId { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list that contains the security group IDs to assign to the instances in the Auto
        /// Scaling group. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-security-groups.html">Control
        /// traffic to your Amazon Web Services resources using security groups</a> in the <i>Amazon
        /// Virtual Private Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SpotPrice
        /// <summary>
        /// <para>
        /// <para>The maximum hourly price to be paid for any Spot Instance launched to fulfill the
        /// request. Spot Instances are launched when the price you specify exceeds the current
        /// Spot price. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/launch-template-spot-instances.html">Request
        /// Spot Instances for fault-tolerant and flexible applications</a> in the <i>Amazon EC2
        /// Auto Scaling User Guide</i>.</para><para>Valid Range: Minimum value of 0.001</para><note><para>When you change your maximum price by creating a new launch configuration, running
        /// instances will continue to run as long as the maximum price for those running instances
        /// is higher than the current Spot price.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SpotPrice { get; set; }
        #endregion
        
        #region Parameter UserData
        /// <summary>
        /// <para>
        /// <para>The user data to make available to the launched EC2 instances. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-metadata.html">Instance
        /// metadata and user data</a> (Linux) and <a href="https://docs.aws.amazon.com/AWSEC2/latest/WindowsGuide/ec2-instance-metadata.html">Instance
        /// metadata and user data</a> (Windows). If you are using a command line tool, base64-encoding
        /// is performed for you, and you can load the text from a file. Otherwise, you must provide
        /// base64-encoded text. User data is limited to 16 KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LaunchConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASLaunchConfiguration (CreateLaunchConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse, NewASLaunchConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociatePublicIpAddress = this.AssociatePublicIpAddress;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMapping = new List<Amazon.AutoScaling.Model.BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.ClassicLinkVPCId = this.ClassicLinkVPCId;
            if (this.ClassicLinkVPCSecurityGroup != null)
            {
                context.ClassicLinkVPCSecurityGroup = new List<System.String>(this.ClassicLinkVPCSecurityGroup);
            }
            context.EbsOptimized = this.EbsOptimized;
            context.IamInstanceProfile = this.IamInstanceProfile;
            context.ImageId = this.ImageId;
            context.InstanceId = this.InstanceId;
            context.InstanceMonitoring_Enabled = this.InstanceMonitoring_Enabled;
            context.InstanceType = this.InstanceType;
            context.KernelId = this.KernelId;
            context.KeyName = this.KeyName;
            context.LaunchConfigurationName = this.LaunchConfigurationName;
            #if MODULAR
            if (this.LaunchConfigurationName == null && ParameterWasBound(nameof(this.LaunchConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetadataOptions_HttpEndpoint = this.MetadataOptions_HttpEndpoint;
            context.MetadataOptions_HttpPutResponseHopLimit = this.MetadataOptions_HttpPutResponseHopLimit;
            context.MetadataOptions_HttpToken = this.MetadataOptions_HttpToken;
            context.PlacementTenancy = this.PlacementTenancy;
            context.RamdiskId = this.RamdiskId;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
            }
            context.SpotPrice = this.SpotPrice;
            context.UserData = this.UserData;
            
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
            var request = new Amazon.AutoScaling.Model.CreateLaunchConfigurationRequest();
            
            if (cmdletContext.AssociatePublicIpAddress != null)
            {
                request.AssociatePublicIpAddress = cmdletContext.AssociatePublicIpAddress.Value;
            }
            if (cmdletContext.BlockDeviceMapping != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMapping;
            }
            if (cmdletContext.ClassicLinkVPCId != null)
            {
                request.ClassicLinkVPCId = cmdletContext.ClassicLinkVPCId;
            }
            if (cmdletContext.ClassicLinkVPCSecurityGroup != null)
            {
                request.ClassicLinkVPCSecurityGroups = cmdletContext.ClassicLinkVPCSecurityGroup;
            }
            if (cmdletContext.EbsOptimized != null)
            {
                request.EbsOptimized = cmdletContext.EbsOptimized.Value;
            }
            if (cmdletContext.IamInstanceProfile != null)
            {
                request.IamInstanceProfile = cmdletContext.IamInstanceProfile;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate InstanceMonitoring
            var requestInstanceMonitoringIsNull = true;
            request.InstanceMonitoring = new Amazon.AutoScaling.Model.InstanceMonitoring();
            System.Boolean? requestInstanceMonitoring_instanceMonitoring_Enabled = null;
            if (cmdletContext.InstanceMonitoring_Enabled != null)
            {
                requestInstanceMonitoring_instanceMonitoring_Enabled = cmdletContext.InstanceMonitoring_Enabled.Value;
            }
            if (requestInstanceMonitoring_instanceMonitoring_Enabled != null)
            {
                request.InstanceMonitoring.Enabled = requestInstanceMonitoring_instanceMonitoring_Enabled.Value;
                requestInstanceMonitoringIsNull = false;
            }
             // determine if request.InstanceMonitoring should be set to null
            if (requestInstanceMonitoringIsNull)
            {
                request.InstanceMonitoring = null;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.KernelId != null)
            {
                request.KernelId = cmdletContext.KernelId;
            }
            if (cmdletContext.KeyName != null)
            {
                request.KeyName = cmdletContext.KeyName;
            }
            if (cmdletContext.LaunchConfigurationName != null)
            {
                request.LaunchConfigurationName = cmdletContext.LaunchConfigurationName;
            }
            
             // populate MetadataOptions
            var requestMetadataOptionsIsNull = true;
            request.MetadataOptions = new Amazon.AutoScaling.Model.InstanceMetadataOptions();
            Amazon.AutoScaling.InstanceMetadataEndpointState requestMetadataOptions_metadataOptions_HttpEndpoint = null;
            if (cmdletContext.MetadataOptions_HttpEndpoint != null)
            {
                requestMetadataOptions_metadataOptions_HttpEndpoint = cmdletContext.MetadataOptions_HttpEndpoint;
            }
            if (requestMetadataOptions_metadataOptions_HttpEndpoint != null)
            {
                request.MetadataOptions.HttpEndpoint = requestMetadataOptions_metadataOptions_HttpEndpoint;
                requestMetadataOptionsIsNull = false;
            }
            System.Int32? requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit = null;
            if (cmdletContext.MetadataOptions_HttpPutResponseHopLimit != null)
            {
                requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit = cmdletContext.MetadataOptions_HttpPutResponseHopLimit.Value;
            }
            if (requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit != null)
            {
                request.MetadataOptions.HttpPutResponseHopLimit = requestMetadataOptions_metadataOptions_HttpPutResponseHopLimit.Value;
                requestMetadataOptionsIsNull = false;
            }
            Amazon.AutoScaling.InstanceMetadataHttpTokensState requestMetadataOptions_metadataOptions_HttpToken = null;
            if (cmdletContext.MetadataOptions_HttpToken != null)
            {
                requestMetadataOptions_metadataOptions_HttpToken = cmdletContext.MetadataOptions_HttpToken;
            }
            if (requestMetadataOptions_metadataOptions_HttpToken != null)
            {
                request.MetadataOptions.HttpTokens = requestMetadataOptions_metadataOptions_HttpToken;
                requestMetadataOptionsIsNull = false;
            }
             // determine if request.MetadataOptions should be set to null
            if (requestMetadataOptionsIsNull)
            {
                request.MetadataOptions = null;
            }
            if (cmdletContext.PlacementTenancy != null)
            {
                request.PlacementTenancy = cmdletContext.PlacementTenancy;
            }
            if (cmdletContext.RamdiskId != null)
            {
                request.RamdiskId = cmdletContext.RamdiskId;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
            }
            if (cmdletContext.SpotPrice != null)
            {
                request.SpotPrice = cmdletContext.SpotPrice;
            }
            if (cmdletContext.UserData != null)
            {
                request.UserData = cmdletContext.UserData;
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
        
        private Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.CreateLaunchConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "CreateLaunchConfiguration");
            try
            {
                return client.CreateLaunchConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AssociatePublicIpAddress { get; set; }
            public List<Amazon.AutoScaling.Model.BlockDeviceMapping> BlockDeviceMapping { get; set; }
            public System.String ClassicLinkVPCId { get; set; }
            public List<System.String> ClassicLinkVPCSecurityGroup { get; set; }
            public System.Boolean? EbsOptimized { get; set; }
            public System.String IamInstanceProfile { get; set; }
            public System.String ImageId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Boolean? InstanceMonitoring_Enabled { get; set; }
            public System.String InstanceType { get; set; }
            public System.String KernelId { get; set; }
            public System.String KeyName { get; set; }
            public System.String LaunchConfigurationName { get; set; }
            public Amazon.AutoScaling.InstanceMetadataEndpointState MetadataOptions_HttpEndpoint { get; set; }
            public System.Int32? MetadataOptions_HttpPutResponseHopLimit { get; set; }
            public Amazon.AutoScaling.InstanceMetadataHttpTokensState MetadataOptions_HttpToken { get; set; }
            public System.String PlacementTenancy { get; set; }
            public System.String RamdiskId { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public System.String SpotPrice { get; set; }
            public System.String UserData { get; set; }
            public System.Func<Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse, NewASLaunchConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
