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
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    ///  Launches a specified number of instances of an AMI for which you have permissions.
    /// </summary>
    [Cmdlet("New", "EC2Instance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Reservation")]
    [AWSCmdlet("Invokes the RunInstances operation against Amazon Elastic Compute Cloud.", Operation = new [] {"RunInstances"})]
    [AWSCmdletOutput("Reservation",
        "This cmdlet returns an Amazon.EC2.Model.Reservation instance with the instances contained in the .Instances member.",
        "The service response (type Amazon.EC2.Model.RunInstancesResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// The ID of the AMI to launch. The set of available AMI IDs can be determined using the
        /// Get-EC2Image or Get-EC2ImageByName cmdlets.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ImageId { get; set; }

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
        
        /// <summary>
        /// The name of the key pair to use to connect to the instance using remote desktop or SSH.
        /// </summary>
        /// <remarks>
        /// <b>Important:</b> If you launch an instance without specifying a key pair, you can't connect to the instance.
        /// </remarks>
        [Parameter]
        public System.String KeyName { get; set; }
        
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
        
        /// <summary>
        /// <para>
        /// The IDs of one or more security groups. Note that for a nondefault VPC, you must specify the security group by ID using
        /// this parameter. For EC2-Classic or a default VPC, you can specify the security group by name or ID.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        
        /// <summary>
        /// The base64-encoded MIME user data for the instances. If the -EncodeUserData switch is also set, the value
        /// for this parameter can be supplied as normal ASCII text and will be base64-encoded by the cmdlet.
        /// </summary>
        [Parameter]
        public System.String UserData { get; set; }

        /// <summary>
        /// The name of a file containing base64-encoded MIME user data for the instances. 
        /// Using this parameter causes any value for the UserData parameter to be ignored. 
        /// If the -EncodeUserData switch is also set, the contents of the file can be normal 
        /// ASCII text and will be base64-encoded by the cmdlet.
        /// </summary>
        [Parameter]
        public System.String UserDataFile { get; set; }

        /// <summary>
        /// If set and the -UserData or -UserDataFile parameters are specified, the specified
        /// user data is base64 encoded prior to submitting to EC2. By default the user data
        /// is assumed to be encoded prior to being supplied to the cmdlet.
        /// </summary>
        [Parameter]
        public SwitchParameter EncodeUserData { get; set; }

        /// <summary>
        /// <para>
        ///  The instance type. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance Types</a> 
        /// in the Amazon Elastic Compute Cloud User Guide.
        /// </para>
        /// <para>
        ///  Valid values: 
        ///  t2.micro | t2.small | t2.medium | m3.medium | m3.large | m3.xlarge | m3.2xlarge | m1.small 
        /// | m1.medium | m1.large | m1.xlarge | c3.large | c3.xlarge | c3.2xlarge | c3.4xlarge | c3.8xlarge 
        /// | c1.medium | c1.xlarge | cc2.8xlarge | r3.large | r3.xlarge | r3.2xlarge | r3.4xlarge | r3.8xlarge 
        /// | m2.xlarge | m2.2xlarge | m2.4xlarge | cr1.8xlarge | i2.xlarge | i2.2xlarge | i2.4xlarge | i2.8xlarge 
        /// | hs1.8xlarge | hi1.4xlarge | t1.micro | g2.2xlarge | cg1.4xlarge
        /// </para>
        /// <para>
        ///  Default: Amazon EC2 will use an m1.small instance if not specified.
        /// </para>
        /// </summary>
        [Parameter]
        public System.String InstanceType { get; set; }
        
        /// <summary>
        /// The Availability Zone for the instance.
        /// </summary>
        [Alias("Placement_AvailabilityZone")]
        [Parameter]
        public System.String AvailabilityZone { get; set; }
        
        /// <summary>
        /// The name of an existing placement group.
        /// </summary>
        [Alias("Placement_GroupName")]
        [Parameter]
        public System.String PlacementGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// The tenancy of the instance. An instance with a tenancy of dedicated runs on single-tenant hardware and can only be launched into a VPC.
        /// </para>
        /// <para>
        /// Valid Values: default | dedicated
        /// </para>
        /// </summary>
        [Alias("Placement_Tenancy")]
        [Parameter]
        public System.String Tenancy { get; set; }
        
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
        
        /// <summary>
        /// The block device mapping for the instance. For more information, see 
        /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/block-device-mapping-concepts.html">Block Device Mapping</a> 
        /// in the Amazon Elastic Compute Cloud User Guide.
        /// </summary>
        [Parameter]
        public Amazon.EC2.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        
        /// <summary>
        /// Enables monitoring for the instance.
        /// </summary>
        [Parameter]
        public System.Boolean? Monitoring_Enabled { get; set; }
        
        /// <summary>
        /// [EC2-VPC] The ID of the subnet to launch the instance into.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        
        /// <summary>
        /// If you enable this option, you can't terminate the instance using the Amazon EC2 console, CLI, or API; otherwise, you can. 
        /// If you specify this option and then later want to be able to terminate the instance, you must first change the value of the 
        /// disableApiTermination attribute to false using Edit-EC2InstanceAttribute. Alternatively, if you set -InstanceInitiatedShutdownBehavior
        /// to 'terminate', you can terminate the instance by running the shutdown command from the instance.
        /// </summary>
        [Parameter]
        public System.Boolean? DisableApiTermination { get; set; }
        
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
        public System.String InstanceInitiatedShutdownBehavior { get; set; }
                
        /// <summary>
        /// [EC2-VPC] The primary private IP address. You must specify a value from the IP address range of the subnet.
        /// If not specified EC2 will assign an IP address from the IP address range of the subnet.
        /// </summary>
        [Parameter]
        public System.String PrivateIpAddress { get; set; }
        
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
        
        /// <summary>
        /// <para>
        /// A set of one or more existing network interfaces to attach to the instance.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("NetworkInterfaceSet,NetworkInterfaces")]
        public Amazon.EC2.Model.InstanceNetworkInterfaceSpecification[] NetworkInterface { get; set; }
        
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
        
        /// <summary>
        /// The ARN of an IAM instance profile to associate with the instances. 
        /// </summary>
        [Parameter]
        public System.String InstanceProfile_Arn { get; set; }
        
        /// <summary>
        /// The name of an IAM instance profile to associate with the instances. 
        /// </summary>
        [Parameter]
        [Alias("InstanceProfile_Id")]
        public System.String InstanceProfile_Name { get; set; }

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        [Parameter]
        public System.String AdditionalInfo { get; set; }

        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

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
            context.AdditionalInfo = this.AdditionalInfo;

            try
            {
                context.UserData = AmazonEC2Helper.LoadUserData(this.UserData, this.UserDataFile, this.EncodeUserData);
            }
            catch (IOException e)
            {
                ThrowArgumentError("Error attempting to access UserDataFile.", UserDataFile, e);
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

            request.AdditionalInfo = cmdletContext.AdditionalInfo;
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RunInstances(request);
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
            public String Placement_AvailabilityZone { get; set; }
            public String Placement_GroupName { get; set; }
            public String Placement_Tenancy { get; set; }
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
        }
        
    }
}
