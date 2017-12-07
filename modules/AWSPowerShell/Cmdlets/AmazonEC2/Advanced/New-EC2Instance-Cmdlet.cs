/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
using System.Linq;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// <para>
    /// Launches a specified number of instances of an AMI for which you have permissions.
    /// </para>
    /// <para>
    /// You can specify a number of options, or leave the default options. The following rules apply:
    /// <ul>
    /// <li>[EC2-VPC] If you don't specify a subnet ID, we choose a default subnet from your default VPC for you. If you don't have a default VPC, you must specify a subnet ID in the request.</li>
    /// <li>[EC2-Classic] If don't specify an Availability Zone, we choose one for you.</li>
    /// <li>Some instance types must be launched into a VPC. If you do not have a default VPC, or if you do not specify a subnet ID, the request fails. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-vpc.html#vpc-only-instance-types">Instance Types Available Only in a VPC</a>.</li>
    /// <li>[EC2-VPC] All instances have a network interface with a primary private IPv4 address. If you don't specify this address, we choose one from the IPv4 range of your subnet.</li>
    /// <li>Not all instance types support IPv6 addresses. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance Types</a>.</li>
    /// <li>If you don't specify a security group ID, we use the default security group. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-network-security.html">Security Groups</a>.</li>
    /// <li>If any of the AMIs have a product code attached for which the user has not subscribed, the request fails.</li>
    /// </ul>
    /// </para>
    /// <para>
    /// You can create a <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html">launch template</a>, which is a resource that 
    /// contains the parameters to launch an instance. When you launch an instance using the cmdlet you can specify the launch template instead of specifying 
    /// the launch parameters. 
    /// </para>
    /// <para>
    /// To ensure faster instance launches, break up large requests into smaller batches. For example, create five separate launch requests for 100 instances each 
    /// instead of one launch request for 500 instances.
    /// </para>
    /// <para>
    /// An instance is ready for you to use when it's in the running state. You can check the state of your instance using the Get-EC2Instance cmdlet. You can 
    /// tag instances and EBS volumes during launch, after launch, or both. For more information, see <a href="https://docs.aws.amazon.com/powershell/latest/reference/index.html?page=New-EC2Tag.html&tocid=New-EC2Tag">New-EC2Tag</a>
    /// and <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html">Tagging Your Amazon EC2 Resources</a>. 
    /// </para>
    /// <para>
    /// Linux instances have access to the public key of the key pair at boot. You can use this key to provide secure access to the instance. Amazon EC2 public 
    /// images use this feature to provide secure access without passwords. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Key Pairs</a>
    /// in the Amazon Elastic Compute Cloud User Guide. 
    /// </para>
    /// <para>
    /// For troubleshooting, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_InstanceStraightToTerminated.html">What To Do If An Instance Immediately Terminates</a>, and 
    /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/TroubleshootingInstancesConnecting.html">Troubleshooting Connecting to Your Instance</a> in the Amazon Elastic Compute Cloud User Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Instance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Reservation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud RunInstances API operation.", Operation = new[] { "RunInstances" })]
    [AWSCmdletOutput("Reservation",
        "This cmdlet returns an Amazon.EC2.Model.Reservation instance with the instances contained in the .Instances member.",
        "The service response (type Amazon.EC2.Model.RunInstancesResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        #region Parameter ImageId
        /// <summary>
        /// The ID of the AMI to launch. The set of available AMI IDs can be determined using the
        /// Get-EC2Image or Get-EC2ImageByName cmdlets.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String ImageId { get; set; }
        #endregion

        #region Parameter AssociatePublicIp
        /// <summary>
        /// Indicates whether to assign a public IP address to an instance in a VPC.      
        /// </summary>
        /// <remarks>
        /// <para>The public IP address is associated with a specific network interface. 
        /// If set to true, the following rules apply:</para>
        /// <ol>
        /// <li>
        /// <p>Can only be associated with a single network interface with
        /// the device index of 0. You can't associate a public IP address
        /// with a second network interface, and you can't associate a
        /// public IP address if you are launching more than one network
        /// interface.</p>
        /// </li>
        /// <li>
        /// <p>Can only be associated with a new network interface, 
        /// not an existing one.</p>
        /// </li>
        /// </ol>
        /// <p>
        /// Default: If launching into a default subnet, the default value is <b>true</b>.
        /// If launching into a nondefault subnet, the default value is <b>false</b>. 
        /// </p>
        /// </remarks>
        [Parameter]
        public System.Boolean? AssociatePublicIp { get; set; }
        #endregion

        #region Parameter MinCount
        /// <summary>
        /// <para>
        /// The minimum number of instances to launch. If you specify a minimum that is more instances than Amazon EC2 can launch in 
        /// the target Availability Zone, Amazon EC2 launches no instances. 
        /// </para>
        /// <para>
        /// Constraints: Between 1 and the maximum number you're allowed for the specified instance type. For more information about 
        /// the default limits, and how to request an increase, 
        /// see <a href="http://aws.amazon.com/ec2/faqs/#How_many_instances_can_I_run_in_Amazon_EC2">How many instances can I run in Amazon EC2</a> 
        /// in the Amazon EC2 General FAQ. 
        /// </para>
        /// <para>
        /// Default: 1.
        /// </para>
        /// </summary>
        [Parameter]
        public System.Int32 MinCount { get; set; }
        #endregion

        #region Parameter MaxCount
        /// <summary>
        /// <para>
        /// The maximum number of instances to launch. If you specify a maximum that is more instances than Amazon EC2 can launch in 
        /// the target Availability Zone EC2 will try to launch the maximum number for the target Availability Zone, but launches 
        /// no fewer than the minimum number. 
        /// </para>
        /// <para>
        /// Constraints: Between 1 and the maximum number you're allowed for the specified instance type. For more information about 
        /// the default limits, and how to request an increase, 
        /// see <a href="http://aws.amazon.com/ec2/faqs/#How_many_instances_can_I_run_in_Amazon_EC2">How many instances can I run in Amazon EC2</a> 
        /// in the Amazon EC2 General FAQ. 
        /// </para>
        /// <para>
        /// Default: 1.
        /// </para>
        /// </summary>
        [Parameter]
        public System.Int32 MaxCount { get; set; }
        #endregion

        #region Parameter KeyName
        /// <summary>
        /// The name of the key pair to use to connect to the instance using remote desktop or SSH.
        /// </summary>
        /// <remarks>
        /// <b>Important:</b> If you launch an instance without specifying a key pair, you can't connect to the instance.
        /// </remarks>
        [Parameter]
        public System.String KeyName { get; set; }
        #endregion

        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// The names of one or more security groups. Note that for a nondefault VPC, you must specify the security group by ID using
        /// the SecurityGroupIds parameter instead. For EC2-Classic or a default VPC, you can specify the security group by name or ID.
        /// </para>
        /// <para>
        /// Default: Amazon EC2 uses the default security group
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion

        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// The IDs of one or more security groups. Note that for a nondefault VPC, you must specify the security group by ID using
        /// this parameter. For EC2-Classic or a default VPC, you can specify the security group by name or ID.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion

        #region Parameter UserData
        /// <summary>
        /// The base64-encoded MIME user data for the instances. If the -EncodeUserData switch is also set, the value
        /// for this parameter can be supplied as normal ASCII text and will be base64-encoded by the cmdlet.
        /// </summary>
        [Parameter]
        public System.String UserData { get; set; }
        #endregion

        #region Parameter UserDataFile
        /// <summary>
        /// The name of a file containing base64-encoded MIME user data for the instances. 
        /// Using this parameter causes any value for the UserData parameter to be ignored. 
        /// If the -EncodeUserData switch is also set, the contents of the file can be normal 
        /// ASCII text and will be base64-encoded by the cmdlet.
        /// </summary>
        [Parameter]
        public System.String UserDataFile { get; set; }
        #endregion

        #region Parameter EncodeUserData
        /// <summary>
        /// If set and the -UserData or -UserDataFile parameters are specified, the specified
        /// user data is base64 encoded prior to submitting to EC2. By default the user data
        /// is assumed to be encoded prior to being supplied to the cmdlet.
        /// </summary>
        [Parameter]
        public SwitchParameter EncodeUserData { get; set; }
        #endregion

        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// The instance type. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance Types</a> 
        /// in the Amazon Elastic Compute Cloud User Guide.
        /// </para>
        /// <para>
        /// Default: Amazon EC2 will use an m1.small instance if not specified.
        /// </para>
        /// </summary>
        [Parameter]
        [AWSConstantClassSource("Amazon.EC2.InstanceType")]
        public Amazon.EC2.InstanceType InstanceType { get; set; }
        #endregion

        #region Parameter AvailabilityZone 
        /// <summary>
        /// The Availability Zone for the instance.
        /// </summary>
        [Alias("Placement_AvailabilityZone")]
        [Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion

        #region Parameter Affinity
        /// <summary>
        /// The affinity setting for the instance on the dedicated host.
        /// </summary>
        [Alias("Placement_Affinity")]
        [Parameter]
        public System.String Affinity { get; set; }
        #endregion

        #region Parameter PlacementGroup
        /// <summary>
        /// The name of an existing placement group.
        /// </summary>
        [Alias("Placement_GroupName")]
        [Parameter]
        public System.String PlacementGroup { get; set; }
        #endregion

        #region Parameter Tenancy 
        /// <summary>
        /// <para>
        /// The tenancy of the instance (if the instance is running in a VPC). An instance with a tenancy of dedicated runs on single-tenant hardware.
        /// </para>
        /// <para>
        /// Valid Values: default | dedicated | host
        /// </para>
        /// </summary>
        [Alias("Placement_Tenancy")]
        [Parameter]
        [AWSConstantClassSource("Amazon.EC2.Tenancy")]
        public Amazon.EC2.Tenancy Tenancy { get; set; }
        #endregion

        #region Parameter HostId
        /// <summary>
        /// The ID of the dedicted host on which the instance resides.
        /// </summary>
        [Alias("Placement_Host")]
        [Parameter]
        public System.String HostId { get; set; }
        #endregion

        #region Parameter KernelId
        /// <summary>
        /// <para>
        /// The ID of the kernel for the instance.
        /// </para>
        /// <para>
        /// <b>Important:</b> We recommend that you use PV-GRUB instead of kernels and RAM disks. For more information, 
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedKernels.html">PV-GRUB</a> 
        /// in the Amazon Elastic Compute Cloud User Guide.
        /// </para>
        /// </summary>
        [Parameter]
        public System.String KernelId { get; set; }
        #endregion

        #region Parameter RamdiskId
        /// <summary>
        /// <para>
        /// The ID of the RAM disk.
        /// </para>
        /// <para>
        /// <b>Important:</b> We recommend that you use PV-GRUB instead of kernels and RAM disks. For more information, 
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/UserProvidedKernels.html">PV-GRUB</a> 
        /// in the Amazon Elastic Compute Cloud User Guide.
        /// </para>
        /// </summary>
        [Parameter]
        public System.String RamdiskId { get; set; }
        #endregion

        #region Parameter BlockDeviceMapping
        /// <summary>
        /// The block device mapping for the instance. For more information, see 
        /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html">Block Device Mapping</a> 
        /// in the Amazon Elastic Compute Cloud User Guide.
        /// </summary>
        [Parameter]
        public Amazon.EC2.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion

        #region Parameter Monitoring_Enabled
        /// <summary>
        /// Enables monitoring for the instance.
        /// </summary>
        [Parameter]
        public System.Boolean? Monitoring_Enabled { get; set; }
        #endregion

        #region Parameter SubnetId
        /// <summary>
        /// [EC2-VPC] The ID of the subnet to launch the instance into.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        #endregion

        #region Parameter DisableApiTermination
        /// <summary>
        /// If you enable this option, you can't terminate the instance using the Amazon EC2 console, CLI, or API; otherwise, you can. 
        /// If you specify this option and then later want to be able to terminate the instance, you must first change the value of the 
        /// disableApiTermination attribute to false using Edit-EC2InstanceAttribute. Alternatively, if you set -InstanceInitiatedShutdownBehavior
        /// to 'terminate', you can terminate the instance by running the shutdown command from the instance.
        /// </summary>
        [Parameter]
        public System.Boolean? DisableApiTermination { get; set; }
        #endregion

        #region Parameter InstanceInitiatedShutdownBehavior
        /// <summary>
        /// <para>
        /// Indicates whether an instance stops or terminates when you initiate shutdown from the instance (using the operating system 
        /// command for system shutdown).
        /// </para>
        /// <para>
        /// Valid values: stop | terminate. Default: stop.
        /// </para>
        /// </summary>
        [Parameter]
        [AWSConstantClassSource("Amazon.EC2.ShutdownBehavior")]
        public Amazon.EC2.ShutdownBehavior InstanceInitiatedShutdownBehavior { get; set; }
        #endregion

        #region Parameter PrivateIpAddress 
        /// <summary>
        /// [EC2-VPC] The primary private IP address. You must specify a value from the IP address range of the subnet.
        /// If not specified EC2 will assign an IP address from the IP address range of the subnet.
        /// </summary>
        [Parameter]
        public System.String PrivateIpAddress { get; set; }
        #endregion

        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// Unique, case-sensitive identifier you provide to ensure idempotency of the request. For more information, see 
        /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Run_Instance_Idempotency.html">How to Ensure Idempotency</a> 
        /// in the Amazon Elastic Compute Cloud User Guide. 
        /// </para>
        /// <para>
        /// Constraints: Maximum 64 ASCII characters
        /// </para>
        /// </summary>
        [Parameter]
        public System.String ClientToken { get; set; }
        #endregion

        #region Parameter NetworkInterface
        /// <summary>
        /// <para>
        /// A set of one or more existing network interfaces to attach to the instance.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("NetworkInterfaceSet,NetworkInterfaces")]
        public Amazon.EC2.Model.InstanceNetworkInterfaceSpecification[] NetworkInterface { get; set; }
        #endregion

        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// Enables Amazon EBS optimization for the instance. This optimization provides dedicated throughput to Amazon EBS and an 
        /// optimized configuration stack to provide optimal Amazon EBS I/O performance. This option isn't available with all instance types. 
        /// Additional usage charge apply when using this option.
        /// </para>
        /// <para>
        /// Default: false (disabled)
        /// </para>
        /// </summary>
        [Parameter]
        public System.Boolean? EbsOptimized { get; set; }
        #endregion

        #region Parameter InstanceProfile_Arn
        /// <summary>
        /// The ARN of an IAM instance profile to associate with the instances. 
        /// </summary>
        [Parameter]
        public System.String InstanceProfile_Arn { get; set; }
        #endregion

        #region Parameter InstanceProfile_Name
        /// <summary>
        /// The name of an IAM instance profile to associate with the instances. 
        /// </summary>
        [Parameter]
        [Alias("InstanceProfile_Id")]
        public System.String InstanceProfile_Name { get; set; }
        #endregion

        #region Parameter AdditionalInfo
        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        [Parameter]
        public System.String AdditionalInfo { get; set; }
        #endregion

        #region Parameter TagSpecification
        /// <summary>
        /// The tags to apply to the resources during launch. You can tag instances and volumes. 
        /// The specified tags are applied to all instances or volumes that are created during launch.
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
        #endregion

        #region Parameter ElasticGpuSpecification
        /// <summary>
        /// An Elastic GPU to associate with the instance.
        /// </summary>
        [Parameter]
        public Amazon.EC2.Model.ElasticGpuSpecification[] ElasticGpuSpecification { get; set; }
        #endregion

        #region Parameter Ipv6AddressCount
        /// <summary>
        /// [EC2-VPC] A number of IPv6 addresses to associate with the primary network interface.
        /// Amazon EC2 chooses the IPv6 addresses from the range of your subnet. You cannot specify
        /// this option and the option to assign specific IPv6 addresses in the same request.
        /// You can specify this option if you've specified a minimum number of instances to launch.
        /// </summary>
        [Parameter]
        public int Ipv6AddressCount { get; set; }
        #endregion

        #region Parameter Ipv6Addresses
        /// <summary>
        /// An Elastic GPU to associate with the instance.
        /// </summary>
        [Parameter]
        public Amazon.EC2.Model.InstanceIpv6Address[] Ipv6Addresses { get; set; }
        #endregion

        #region Parameter LaunchTemplate
        /// <summary>
        /// The launch template to use to launch the instances. Any parameters that you specify to the cmdlet
        /// override the same parameters in the launch template
        /// </summary>
        [Parameter]
        public Amazon.EC2.Model.LaunchTemplateSpecification LaunchTemplate { get; set; }
        #endregion

        #region Parameter InstanceMarketOption
        /// <summary>
        /// The market (purchasing) option for the instances.
        /// </summary>
        [Parameter]
        public Amazon.EC2.Model.InstanceMarketOptionsRequest InstanceMarketOption { get; set; }
        #endregion

        #region Parameter CpuCredit
        /// <summary>
        /// <para>
        /// The credit option for CPU usage of the instance. Valid values are <code>standard</code> and <code>unlimited</code>. 
        /// To change this attribute after launch, use the Edit-EC2InstanceCreditSpecification cmdlet. For more information, see 
        /// <a href=\"http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/t2-instances.html\">T2 Instances</a> in the 
        /// <i>Amazon Elastic Compute Cloud User Guide</i>.
        /// </para>
        /// <para>
        /// The default value if not specified is <code>standard</code>.
        /// </para>
        /// </summary>
        [Parameter]
        public System.String CpuCredit { get; set; }
        #endregion

        public NewEC2InstanceCmdlet()
        {
            this.MinCount = this.MaxCount = 1;    
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.ImageId, "New-EC2Instance (RunInstances)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                ImageId = this.ImageId,
                AssociatePublicIp = this.AssociatePublicIp,
                MinCount = this.MinCount,
                MaxCount = this.MaxCount,
                KeyName = this.KeyName
            };

            if (this.SecurityGroup != null)
            {
                context.SecurityGroups = new List<String>(this.SecurityGroup);
            }
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<String>(this.SecurityGroupId);
            }
            context.InstanceType = this.InstanceType;
            context.Placement_AvailabilityZone = this.AvailabilityZone;
            context.Placement_GroupName = this.PlacementGroup;
            context.Placement_Tenancy = this.Tenancy;
            context.Placement_HostId = this.HostId;
            context.Placement_Affinity = this.Affinity;
            context.KernelId = this.KernelId;
            context.RamdiskId = this.RamdiskId;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMapping = new List<BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.Monitoring_Enabled = this.Monitoring_Enabled;
            context.SubnetId = this.SubnetId;
            context.DisableApiTermination = this.DisableApiTermination;
            context.InstanceInitiatedShutdownBehavior = this.InstanceInitiatedShutdownBehavior;
            context.PrivateIpAddress = this.PrivateIpAddress;
            context.ClientToken = this.ClientToken;
            if (this.NetworkInterface != null)
            {
                context.NetworkInterfaces = new List<InstanceNetworkInterfaceSpecification>(this.NetworkInterface);
            }
            context.EbsOptimized = this.EbsOptimized;
            context.InstanceProfile_Arn = this.InstanceProfile_Arn;
            context.InstanceProfile_Name = this.InstanceProfile_Name;
            if (this.TagSpecification != null)
            {
                context.TagSpecifications = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.AdditionalInfo = this.AdditionalInfo;

            if(this.ElasticGpuSpecification != null)
            {
                context.ElasticGpuSpecification = new List<Amazon.EC2.Model.ElasticGpuSpecification>(this.ElasticGpuSpecification);
            }

            if(this.Ipv6AddressCount > 0)
            {
                context.Ipv6AddressCount = this.Ipv6AddressCount;
            }

            if (this.Ipv6Addresses != null)
            {
                context.Ipv6Addresses = new List<Amazon.EC2.Model.InstanceIpv6Address>(this.Ipv6Addresses);
            }

            try
            {
                context.UserData = AmazonEC2Helper.LoadUserData(this.UserData, this.UserDataFile, this.EncodeUserData);
            }
            catch (IOException e)
            {
                ThrowArgumentError("Error attempting to access UserDataFile.", UserDataFile, e);
            }
            if (this.LaunchTemplate != null)
            {
                context.LaunchTemplate = this.LaunchTemplate;
            }
            if (this.InstanceMarketOption != null)
            {
                context.InstanceMarketOption = this.InstanceMarketOption;
            }
            if (!string.IsNullOrEmpty(this.CpuCredit))
            {
                context.CpuCredit = this.CpuCredit;
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RunInstancesRequest();
            
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }

            // Should execute this block of logic before processing AssociatePublicIp property.
            if (cmdletContext.NetworkInterfaces != null)
            {
                request.NetworkInterfaces = cmdletContext.NetworkInterfaces;
            }
            // Should execute this block of logic before SubnetId and PrivateIpAddress properties are processed.
            // If AssociatePublicIp parameter has been specified, set it in the NetwrokInterfaceSet.
            if (cmdletContext.AssociatePublicIp.HasValue)
            {
                if (cmdletContext.NetworkInterfaces == null)
                {
                    // Else initialize the NetworkInterfaceSet property,
                    // create an InstanceNetworkInterfaceSpecification with DeviceIndex 0 and
                    // set the flag.
                    var netInterface = new InstanceNetworkInterfaceSpecification
                    {
                        DeviceIndex = 0,
                        AssociatePublicIpAddress = cmdletContext.AssociatePublicIp.Value,
                        SubnetId = cmdletContext.SubnetId,
                        PrivateIpAddress = cmdletContext.PrivateIpAddress,
                    };

                    if (cmdletContext.SecurityGroupIds != null)
                        netInterface.Groups = cmdletContext.SecurityGroupIds;

                    request.NetworkInterfaces = new List<InstanceNetworkInterfaceSpecification>
                    {
                        netInterface
                    };

                    // Set SubnetId and PrivateIpAddress to null as we have processed these parameters
                    // at NIC level.
                    cmdletContext.SubnetId = null;
                    cmdletContext.PrivateIpAddress = null;
                    cmdletContext.SecurityGroupIds = null;
                }
                else
                {
                    // Set the flag on the Network Interface with Deviceindex 0 if Network Interfaces are specified.
                    var networkInterface0 = request.NetworkInterfaces.SingleOrDefault(
                        n => n.DeviceIndex == 0);
                    if (networkInterface0 != null)
                    {
                        networkInterface0.AssociatePublicIpAddress = cmdletContext.AssociatePublicIp.Value;
                    }
                }
            }

            if (cmdletContext.MinCount != null)
            {
                request.MinCount = cmdletContext.MinCount.Value;
            }
            if (cmdletContext.MaxCount != null)
            {
                request.MaxCount = cmdletContext.MaxCount.Value;
            }
            if (cmdletContext.KeyName != null)
            {
                request.KeyName = cmdletContext.KeyName;
            }
            if (cmdletContext.SecurityGroups != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroups;
            }
            if (cmdletContext.SecurityGroupIds != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupIds;
            }
            if (cmdletContext.UserData != null)
            {
                request.UserData = cmdletContext.UserData;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            
             // populate Placement
            bool requestPlacementIsNull = true;
            request.Placement = new Placement();

            String requestPlacement_placement_Affinity = null;
            if (cmdletContext.Placement_Affinity != null)
            {
                requestPlacement_placement_Affinity = cmdletContext.Placement_Affinity;
            }
            if (requestPlacement_placement_Affinity != null)
            {
                request.Placement.Affinity = requestPlacement_placement_Affinity;
                requestPlacementIsNull = false;
            }
            
            String requestPlacement_placement_AvailabilityZone = null;
            if (cmdletContext.Placement_AvailabilityZone != null)
            {
                requestPlacement_placement_AvailabilityZone = cmdletContext.Placement_AvailabilityZone;
            }
            if (requestPlacement_placement_AvailabilityZone != null)
            {
                request.Placement.AvailabilityZone = requestPlacement_placement_AvailabilityZone;
                requestPlacementIsNull = false;
            }

            String requestPlacement_placement_GroupName = null;
            if (cmdletContext.Placement_GroupName != null)
            {
                requestPlacement_placement_GroupName = cmdletContext.Placement_GroupName;
            }
            if (requestPlacement_placement_GroupName != null)
            {
                request.Placement.GroupName = requestPlacement_placement_GroupName;
                requestPlacementIsNull = false;
            }

            String requestPlacement_placement_HostId = null;
            if (cmdletContext.Placement_HostId != null)
            {
                requestPlacement_placement_HostId = cmdletContext.Placement_HostId;
            }
            if (requestPlacement_placement_HostId != null)
            {
                request.Placement.HostId = requestPlacement_placement_HostId;
                requestPlacementIsNull = false;
            }

            String requestPlacement_placement_Tenancy = null;
            if (cmdletContext.Placement_Tenancy != null)
            {
                requestPlacement_placement_Tenancy = cmdletContext.Placement_Tenancy;
            }
            if (requestPlacement_placement_Tenancy != null)
            {
                request.Placement.Tenancy = requestPlacement_placement_Tenancy;
                requestPlacementIsNull = false;
            }

             // determine if request.Placement should be set to null
            if (requestPlacementIsNull)
            {
                request.Placement = null;
            }
            if (cmdletContext.KernelId != null)
            {
                request.KernelId = cmdletContext.KernelId;
            }
            if (cmdletContext.RamdiskId != null)
            {
                request.RamdiskId = cmdletContext.RamdiskId;
            }
            if (cmdletContext.BlockDeviceMapping != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMapping;
            }
            
            if (cmdletContext.Monitoring_Enabled.HasValue)
                request.Monitoring = cmdletContext.Monitoring_Enabled.Value;

            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.DisableApiTermination != null)
            {
                request.DisableApiTermination = cmdletContext.DisableApiTermination.Value;
            }
            if (cmdletContext.InstanceInitiatedShutdownBehavior != null)
            {
                request.InstanceInitiatedShutdownBehavior = cmdletContext.InstanceInitiatedShutdownBehavior;
            }
            
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddress = cmdletContext.PrivateIpAddress;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EbsOptimized != null)
            {
                request.EbsOptimized = cmdletContext.EbsOptimized.Value;
            }
            
             // populate InstanceProfile
            bool requestInstanceProfileIsNull = true;
            request.IamInstanceProfile = new IamInstanceProfileSpecification();
            String requestInstanceProfile_instanceProfile_Arn = null;
            if (cmdletContext.InstanceProfile_Arn != null)
            {
                requestInstanceProfile_instanceProfile_Arn = cmdletContext.InstanceProfile_Arn;
            }
            if (requestInstanceProfile_instanceProfile_Arn != null)
            {
                request.IamInstanceProfile.Arn = requestInstanceProfile_instanceProfile_Arn;
                requestInstanceProfileIsNull = false;
            }
            String requestInstanceProfile_instanceProfile_Name = null;
            if (cmdletContext.InstanceProfile_Name != null)
            {
                requestInstanceProfile_instanceProfile_Name = cmdletContext.InstanceProfile_Name;
            }
            if (requestInstanceProfile_instanceProfile_Name != null)
            {
                request.IamInstanceProfile.Name = requestInstanceProfile_instanceProfile_Name;
                requestInstanceProfileIsNull = false;
            }
             // determine if request.InstanceProfile should be set to null
            if (requestInstanceProfileIsNull)
            {
                request.IamInstanceProfile = null;
            }
            if (cmdletContext.TagSpecifications != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecifications;
            }

            request.AdditionalInfo = cmdletContext.AdditionalInfo;

            if(cmdletContext.ElasticGpuSpecification != null)
            {
                request.ElasticGpuSpecification = cmdletContext.ElasticGpuSpecification;
            }

            if (cmdletContext.Ipv6Addresses != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Addresses;
            }

            if(cmdletContext.Ipv6AddressCount.HasValue)
            {
                request.Ipv6AddressCount = cmdletContext.Ipv6AddressCount.Value;
            }
            if (cmdletContext.LaunchTemplate != null)
            {
                request.LaunchTemplate = cmdletContext.LaunchTemplate;
            }
            if (cmdletContext.InstanceMarketOption != null)
            {
                request.InstanceMarketOptions = cmdletContext.InstanceMarketOption;
            }
            if (!string.IsNullOrEmpty(cmdletContext.CpuCredit))
            {
                request.CreditSpecification = new CreditSpecificationRequest
                {
                    CpuCredits = cmdletContext.CpuCredit
                };
            }

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            
            // issue call
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Reservation;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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

        private Amazon.EC2.Model.RunInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RunInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2", "RunInstances");

            try
            {
#if DESKTOP
                return client.RunInstances(request);
#elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RunInstancesAsync(request);
                return task.Result;
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

        internal class CmdletContext : ExecutorContext
        {
            public String ImageId { get; set; }
            public Boolean? AssociatePublicIp { get; set; }
            public int? MinCount { get; set; }
            public int? MaxCount { get; set; }
            public String KeyName { get; set; }
            public List<String> SecurityGroups { get; set; }
            public List<String> SecurityGroupIds { get; set; }
            public String UserData { get; set; }
            public String InstanceType { get; set; }
            public String Placement_Affinity { get; set; }
            public String Placement_AvailabilityZone { get; set; }
            public String Placement_GroupName { get; set; }
            public String Placement_Tenancy { get; set; }
            public String Placement_HostId { get; set; }
            public String KernelId { get; set; }
            public String RamdiskId { get; set; }
            public List<BlockDeviceMapping> BlockDeviceMapping { get; set; }
            public Boolean? Monitoring_Enabled { get; set; }
            public String SubnetId { get; set; }
            public Boolean? DisableApiTermination { get; set; }
            public String InstanceInitiatedShutdownBehavior { get; set; }
            public String PrivateIpAddress { get; set; }
            public String ClientToken { get; set; }
            public List<InstanceNetworkInterfaceSpecification> NetworkInterfaces { get; set; }
            public Boolean? EbsOptimized { get; set; }
            public String InstanceProfile_Arn { get; set; }
            public String InstanceProfile_Name { get; set; }
            public String AdditionalInfo { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecifications { get; set; }
            public List<Amazon.EC2.Model.ElasticGpuSpecification> ElasticGpuSpecification { get; set; }
            public List<Amazon.EC2.Model.InstanceIpv6Address> Ipv6Addresses { get; set; }
            public int? Ipv6AddressCount { get; set; }
            public Amazon.EC2.Model.LaunchTemplateSpecification LaunchTemplate { get; set; }
            public Amazon.EC2.Model.InstanceMarketOptionsRequest InstanceMarketOption { get; set; }
            public System.String CpuCredit { get; set; }
        }
        
    }
}
