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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates a launch configuration.
    /// 
    ///  
    /// <para>
    /// If you exceed your maximum limit of launch configurations, the call fails. To query
    /// this limit, call the <a>DescribeAccountLimits</a> API. For information about updating
    /// this limit, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-account-limits.html">Amazon
    /// EC2 Auto Scaling Service Quotas</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/LaunchConfiguration.html">Launch
    /// Configurations</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ASLaunchConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling CreateLaunchConfiguration API operation.", Operation = new[] {"CreateLaunchConfiguration"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewASLaunchConfigurationCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AssociatePublicIpAddress
        /// <summary>
        /// <para>
        /// <para>For Auto Scaling groups that are running in a virtual private cloud (VPC), specifies
        /// whether to assign a public IP address to the group's instances. If you specify <code>true</code>,
        /// each instance in the Auto Scaling group receives a unique public IP address. For more
        /// information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-in-vpc.html">Launching
        /// Auto Scaling Instances in a VPC</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para><para>If you specify this parameter, you must specify at least one subnet for <code>VPCZoneIdentifier</code>
        /// when you create your group.</para><note><para>If the instance is launched into a default subnet, the default is to assign a public
        /// IP address, unless you disabled the option to assign a public IP address on the subnet.
        /// If the instance is launched into a nondefault subnet, the default is not to assign
        /// a public IP address, unless you enabled the option to assign a public IP address on
        /// the subnet.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssociatePublicIpAddress { get; set; }
        #endregion
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>A block device mapping, which specifies the block devices for the instance. You can
        /// specify virtual devices and EBS volumes. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html">Block
        /// Device Mapping</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockDeviceMappings")]
        public Amazon.AutoScaling.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter ClassicLinkVPCId
        /// <summary>
        /// <para>
        /// <para>The ID of a ClassicLink-enabled VPC to link your EC2-Classic instances to. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-classiclink.html">ClassicLink</a>
        /// in the <i>Amazon EC2 User Guide for Linux Instances</i> and <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-in-vpc.html#as-ClassicLink">Linking
        /// EC2-Classic Instances to a VPC</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para><para>This parameter can only be used if you are launching EC2-Classic instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClassicLinkVPCId { get; set; }
        #endregion
        
        #region Parameter ClassicLinkVPCSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more security groups for the specified ClassicLink-enabled VPC.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/vpc-classiclink.html">ClassicLink</a>
        /// in the <i>Amazon EC2 User Guide for Linux Instances</i> and <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-in-vpc.html#as-ClassicLink">Linking
        /// EC2-Classic Instances to a VPC</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para><para>If you specify the <code>ClassicLinkVPCId</code> parameter, you must specify this
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClassicLinkVPCSecurityGroups")]
        public System.String[] ClassicLinkVPCSecurityGroup { get; set; }
        #endregion
        
        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Specifies whether the launch configuration is optimized for EBS I/O (<code>true</code>)
        /// or not (<code>false</code>). The optimization provides dedicated throughput to Amazon
        /// EBS and an optimized configuration stack to provide optimal I/O performance. This
        /// optimization is not available with all instance types. Additional fees are incurred
        /// when you enable EBS optimization for an instance type that is not EBS-optimized by
        /// default. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/EBSOptimized.html">Amazon
        /// EBS-Optimized Instances</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para><para>The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EbsOptimized { get; set; }
        #endregion
        
        #region Parameter InstanceMonitoring_Enabled
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, detailed monitoring is enabled. Otherwise, basic monitoring
        /// is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InstanceMonitoring_Enabled { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpEndpoint
        /// <summary>
        /// <para>
        /// <para>This parameter enables or disables the HTTP metadata endpoint on your instances. If
        /// the parameter is not specified, the default state is <code>enabled</code>.</para><note><para>If you specify a value of <code>disabled</code>, you will not be able to access your
        /// instance metadata. </para></note>
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
        /// the number, the further instance metadata requests can travel.</para><para>Default: 1</para><para>Possible values: Integers from 1 to 64</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MetadataOptions_HttpPutResponseHopLimit { get; set; }
        #endregion
        
        #region Parameter MetadataOptions_HttpToken
        /// <summary>
        /// <para>
        /// <para>The state of token usage for your instance metadata requests. If the parameter is
        /// not specified in the request, the default state is <code>optional</code>.</para><para>If the state is <code>optional</code>, you can choose to retrieve instance metadata
        /// with or without a signed token header on your request. If you retrieve the IAM role
        /// credentials without a token, the version 1.0 role credentials are returned. If you
        /// retrieve the IAM role credentials using a valid signed token, the version 2.0 role
        /// credentials are returned.</para><para>If the state is <code>required</code>, you must send a signed token header with any
        /// instance metadata retrieval requests. In this state, retrieving the IAM role credentials
        /// always returns the version 2.0 credentials; the version 1.0 credentials are not available.</para>
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
        /// the IAM role for the instance. The instance profile contains the IAM role.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/us-iam-role.html">IAM
        /// Role for Applications That Run on Amazon EC2 Instances</a> in the <i>Amazon EC2 Auto
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
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/finding-an-ami.html">Finding
        /// an AMI</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para><para>If you do not specify <code>InstanceId</code>, you must specify <code>ImageId</code>.</para>
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
        /// instance attributes, specify them as part of the same request.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/create-lc-with-instanceID.html">Create
        /// a Launch Configuration Using an EC2 Instance</a> in the <i>Amazon EC2 Auto Scaling
        /// User Guide</i>.</para><para>If you do not specify <code>InstanceId</code>, you must specify both <code>ImageId</code>
        /// and <code>InstanceType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Specifies the instance type of the EC2 instance.</para><para>For information about available instance types, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html#AvailableInstanceTypes">Available
        /// Instance Types</a> in the <i>Amazon EC2 User Guide for Linux Instances.</i></para><para>If you do not specify <code>InstanceId</code>, you must specify <code>InstanceType</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter KernelId
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel associated with the AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KernelId { get; set; }
        #endregion
        
        #region Parameter KeyName
        /// <summary>
        /// <para>
        /// <para>The name of the key pair. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Amazon
        /// EC2 Key Pairs</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para>
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
        /// <para>The tenancy of the instance. An instance with <code>dedicated</code> tenancy runs
        /// on isolated, single-tenant hardware and can only be launched into a VPC.</para><para>To launch dedicated instances into a shared tenancy VPC (a VPC with the instance placement
        /// tenancy attribute set to <code>default</code>), you must set the value of this parameter
        /// to <code>dedicated</code>.</para><para>If you specify <code>PlacementTenancy</code>, you must specify at least one subnet
        /// for <code>VPCZoneIdentifier</code> when you create your group.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-in-vpc.html#as-vpc-tenancy">Instance
        /// Placement Tenancy</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para><para>Valid Values: <code>default</code> | <code>dedicated</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlacementTenancy { get; set; }
        #endregion
        
        #region Parameter RamdiskId
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk to select.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RamdiskId { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list that contains the security groups to assign to the instances in the Auto Scaling
        /// group.</para><para>[EC2-VPC] Specify the security group IDs. For more information, see <a href="https://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_SecurityGroups.html">Security
        /// Groups for Your VPC</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.</para><para>[EC2-Classic] Specify either the security group names or the security group IDs. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-network-security.html">Amazon
        /// EC2 Security Groups</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para>
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
        /// Spot price. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/asg-launch-spot-instances.html">Launching
        /// Spot Instances in Your Auto Scaling Group</a> in the <i>Amazon EC2 Auto Scaling User
        /// Guide</i>.</para><note><para>When you change your maximum price by creating a new launch configuration, running
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
        /// <para>The Base64-encoded user data to make available to the launched EC2 instances. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-instance-metadata.html">Instance
        /// Metadata and User Data</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LaunchConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LaunchConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LaunchConfigurationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LaunchConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASLaunchConfiguration (CreateLaunchConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.CreateLaunchConfigurationResponse, NewASLaunchConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LaunchConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.CreateLaunchConfiguration(request);
                #elif CORECLR
                return client.CreateLaunchConfigurationAsync(request).GetAwaiter().GetResult();
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
