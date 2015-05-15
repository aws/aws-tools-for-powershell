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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Returns information about instances that you own.
    /// 
    /// If you specify one or more instance IDs, Amazon EC2 returns
    /// information for those instances.
    /// 
    /// If you do not specify instance IDs, Amazon EC2 returns information
    /// for all relevant instances. If you
    /// specify an invalid instance ID, a fault is returned.
    /// 
    /// If you specify an instance that you do not own, it will not be
    /// included in the returned results.
    /// 
    /// Recently terminated instances might appear in the returned results.This
    /// interval is usually less than one hour.
    /// </summary>
    [Cmdlet("Get", "EC2Instance")]
    [OutputType("Amazon.EC2.Model.Reservation")]
    [AWSCmdlet("Invokes the DescribeInstances operation against Amazon Elastic Compute Cloud.", Operation = new [] {"DescribeInstances"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Reservation",
        "This cmdlet returns 0 or more Reservation instances.",
        "The service response (type DescribeInstancesResponse) is added to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// Identifies the set of instances to return, specified either a collection of string instance ids, 
        /// or a collection of RunningInstance objects. If not specified, all running instances are returned.
        /// </summary>
        [Parameter(Position = 0, ValueFromPipeline=true)]
        public object[] Instance { get; set; }
        
        /// <summary>
        /// <para>
        /// A set of filters used to match system-defined properties and user-defined tags associated with
        /// the specified instances.
        /// </para>
        /// <para>
        /// Available filters: 
        /// <ul>
        /// <li><c>architecture</c> - The instance architecture (<c>i386</c> | <c>x86_64</c>).</li> 
        /// <li><c>availability-zone</c> - The Availability Zone of the instance.</li>
        /// <li><c>block-device-mapping.attach-time</c> - The attach time for an Amazon EBS volume mapped to the instance.</li> 
        /// <li><c>block-device-mapping.delete-on-termination</c> - A Boolean that indicates whether the Amazon EBS volume is deleted on instance termination.</li> 
        /// <li><c>block-device-mapping.device-name</c> - The device name for the Amazon EBS volume (for example, <c>/dev/sdh</c>).</li>
        /// <li><c>block-device-mapping.status</c> - The status for the Amazon EBS volume (<c>attaching</c> | <c>attached</c> | <c>detaching</c> | <c>detached</c>). </li> <li> <c>block-device-mapping.volume-id</c> - The volume ID of the Amazon EBS volume.</li>
        /// <li><c>client-token</c> - The idempotency token you provided when you launched the instance.</li>
        /// <li><c>dns-name</c> - The public DNS name of the instance.</li> 
        /// <li><c>group-id</c> - The ID of the security group for the instance. If the instance is in EC2-Classic or a default VPC, you can use <c>group-name</c> instead.</li> 
        /// <li><c>group-name</c> - The name of the security group for the instance. If the instance is in a nondefault VPC, you must use <c>group-id</c> instead.</li> 
        /// <li><c>hypervisor</c> - The hypervisor type of the instance (<c>ovm</c> | <c>xen</c>).</li> 
        /// <li><c>image-id</c> - The ID of the image used to launch the instance.</li> 
        /// <li><c>instance-id</c> - The ID of the instance.</li> 
        /// <li><c>instance-lifecycle</c> - Indicates whether this is a Spot Instance (<c>spot</c>).</li> 
        /// <li><c>instance-state-code</c> - The state of the instance, as a 16-bit unsigned integer. The high byte is an opaque internal value and should be ignored. The low byte is set based on the state represented. The valid values are: 0 (pending), 16 (running), 32 (shutting-down), 48 (terminated), 64 (stopping), and 80 (stopped).</li> 
        /// <li><c>instance-state-name</c> - The state of the instance (<c>pending</c> | <c>running</c> | <c>shutting-down</c> | <c>terminated</c> | <c>stopping</c> | <c>stopped</c>).</li> 
        /// <li><c>instance-type</c> - The type of instance (for example, <c>m1.small</c>).</li> 
        /// <li><c>instance.group-id</c> - The ID of the security group for the instance. If the instance is in EC2-Classic or a default VPC, you can use <c>instance.group-name</c> instead.</li> 
        /// <li><c>instance.group-name</c> - The name of the security group for the instance. If the instance is in a nondefault VPC, you must use <c>instance.group-id</c> instead.</li> 
        /// <li><c>ip-address</c> - The public IP address of the instance.</li> 
        /// <li><c>kernel-id</c> - The kernel ID.</li> 
        /// <li><c>key-name</c> - The name of the key pair used when the instance was launched.</li> 
        /// <li><c>launch-index</c> - When launching multiple instances, this is the index for the instance in the launch group (for example, 0, 1, 2, and so on).</li> 
        /// <li><c>launch-time</c> - The time when the instance was launched.</li> 
        /// <li><c>monitoring-state</c> - Indicates whether monitoring is enabled for the instance (<c>disabled</c> | <c>enabled</c>).</li> 
        /// <li><c>owner-id</c> - The AWS account ID of the instance owner.</li>
        /// <li><c>placement-group-name</c> - The name of the placement group for the instance.</li> 
        /// <li><c>platform</c> - The platform. Use <c>windows</c> if you have Windows instances; otherwise, leave blank.</li> 
        /// <li><c>private-dns-name</c> - The private DNS name of the instance.</li> 
        /// <li><c>private-ip-address</c> - The private IP address of the instance.</li> 
        /// <li><c>product-code</c> - The product code associated with the AMI used to launch the instance.</li> 
        /// <li><c>product-code.type</c> - The type of product code (<c>devpay</c> | <c>marketplace</c>). </li> <li> <c>ramdisk-id</c> - The RAM disk ID.</li> 
        /// <li><c>reason</c> - The reason for the current state of the instance (for example, shows "User Initiated [date]" when you stop or terminate the instance). Similar to the state-reason-code filter.</li> 
        /// <li><c>requester-id</c> - The ID of the entity that launched the instance on your behalf (for example, AWS Management Console, Auto Scaling, and so on).</li> 
        /// <li><c>reservation-id</c> - The ID of the instance's reservation. A reservation ID is created any time you launch an instance. A reservation ID has a one-to-one relationship 
        /// with an instance launch request, but can be associated with more than one instance if you launch multiple instances using the same launch request. For example, if you launch one instance, you'll get one reservation
        /// ID. If you launch ten instances using the same launch request, you'll also get one reservation ID.</li> 
        /// <li><c>root-device-name</c> - The name of the root device for the instance (for example, <c>/dev/sda1</c>).</li> 
        /// <li><c>root-device-type</c> - The type of root device that the instance uses (<c>ebs</c> | <c>instance-store</c>).</li> 
        /// <li><c>source-dest-check</c> - Indicates whether the instance performs source/destination checking. A value of <c>true</c> means that checking is enabled, and <c>false</c> means checking is disabled. The value
        /// must be <c>false</c> for the instance to perform network address translation (NAT) in your VPC.</li> 
        /// <li><c>spot-instance-request-id</c> - The ID of the Spot Instance request.</li> 
        /// <li><c>state-reason-code</c> - The reason code for the state change.</li> 
        /// <li><c>state-reason-message</c> - A message that describes the state change.</li> 
        /// <li><c>subnet-id</c> - The ID of the subnet for the instance.</li> 
        /// <li><c>tag</c>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned to the resource, where <c>tag</c>:<i>key</i> is the tag's key.</li> 
        /// <li><c>tag-key</c> - The key of a tag assigned to the resource. This filter is independent of the <c>tag-value</c> filter. For example, if you use both the filter "tag-key=Purpose" and the filter "tag-value=X", you get any resources
        /// assigned both the tag key Purpose (regardless of what the tag's value is), and the tag value X (regardless of what the tag's key is). If you
        /// want to list only resources where Purpose is X, see the <c>tag</c>:<i>key</i>=<i>value</i> filter.</li> 
        /// <li><c>tag-value</c> - The value of a tag assigned to the resource. This filter is independent of the <c>tag-key</c> filter.</li> 
        /// <li><c>virtualization-type</c> - The virtualization type of the instance (<c>paravirtual</c> | <c>hvm</c>).</li> 
        /// <li><c>vpc-id</c> - The ID of the VPC that the instance is running in.</li> 
        /// <li><c>network-interface.description</c> - The description of the network interface.</li> 
        /// <li><c>network-interface.subnet-id</c> - The ID of the subnet for the network interface.</li> 
        /// <li><c>network-interface.vpc-id</c> - The ID of the VPC for the network interface.</li> 
        /// <li><c>network-interface.network-interface.id</c> - The ID of the network interface.</li> 
        /// <li><c>network-interface.owner-id</c> - The ID of the owner of the network interface.</li> 
        /// <li><c>network-interface.availability-zone</c> - The Availability Zone for the network interface.</li> 
        /// <li><c>network-interface.requester-id</c> - The requester ID for the network interface.</li> 
        /// <li><c>network-interface.requester-managed</c> - Indicates whether the network interface is being managed by AWS.</li>
        /// <li><c>network-interface.status</c> - The status of the network interface (<c>available</c>) | <c>in-use</c>).</li> 
        /// <li><c>network-interface.mac-address</c> - The MAC address of the network interface.</li> 
        /// <li><c>network-interface-private-dns-name</c> - The private DNS name of the network interface.</li> 
        /// <li><c>network-interface.source-destination-check</c> - Whether the network interface performs source/destination checking. A value of <c>true</c> means checking is enabled, and <c>false</c> means checking is disabled. The
        /// value must be <c>false</c> for the network interface to perform network address translation (NAT) in your VPC.</li> 
        /// <li><c>network-interface.group-id</c> - The ID of a security group associated with the network interface.</li> 
        /// <li><c>network-interface.group-name</c> - The name of a security group associated with the network interface.</li> 
        /// <li><c>network-interface.attachment.attachment-id</c> - The ID of the interface attachment.</li> 
        /// <li><c>network-interface.attachment.instance-id</c> - The ID of the instance to which the network interface is attached.</li> 
        /// <li><c>network-interface.attachment.instance-owner-id</c> - The owner ID of the instance to which the network interface is attached.</li> 
        /// <li><c>network-interface.addresses.private-ip-address</c> - The private IP address associated with the network interface.</li> 
        /// <li><c>network-interface.attachment.device-index</c> - The device index to which the network interface is attached.</li> 
        /// <li><c>network-interface.attachment.status</c> - The status of the attachment (<c>attaching</c> | <c>attached</c> | <c>detaching</c> |
        /// <c>detached</c>). </li> <li> <c>network-interface.attachment.attach-time</c> - The time that the network interface was attached to an
        /// instance.</li>
        /// <li><c>network-interface.attachment.delete-on-termination</c> - Specifies whether the attachment is deleted when an instance is terminated.</li> 
        /// <li><c>network-interface.addresses.primary</c> - Specifies whether the IP address of the network interface is the primary private IP address.</li> 
        /// <li><c>network-interface.addresses.association.public-ip</c> - The ID of the association of an Elastic IP address with a network interface.</li> 
        /// <li><c>network-interface.addresses.association.ip-owner-id</c> - The owner ID of the private IP address associated with the network interface.</li> 
        /// <li><c>association.public-ip</c> - The address of the Elastic IP address bound to the network interface.</li> 
        /// <li><c>association.ip-owner-id</c> - The owner of the Elastic IP address associated with the network interface.</li> 
        /// <li><c>association.allocation-id</c> - The allocation ID returned when you allocated the Elastic IP address for your network interface.</li> 
        /// <li><c>association.association-id</c> - The association ID returned when the network interface was associated with an IP address.</li> 
        /// </ul>
        /// </para>
        /// </summary>
        [Parameter(Position = 1)]
        public Filter[] Filter { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
                              {
                                  Region = this.Region,
                                  Credentials = this.CurrentCredentials,
                                  InstanceIds = AmazonEC2Helper.InstanceParamToIDs(this.Instance)
                              };

            // process standard parameters, if present

            if (this.Filter != null)
                context.Filter = new List<Filter>(this.Filter);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var request = new DescribeInstancesRequest();
            request.InstanceIds = cmdletContext.InstanceIds;
            if (cmdletContext.Filter != null)
                request.Filters = cmdletContext.Filter;

            var client = Client ?? CreateClient(context.Credentials, context.Region);
            CmdletOutput output;
            try
            {
                var response = client.DescribeInstances(request);
                output = new CmdletOutput
                {
                    PipelineOutput = response.Reservations,
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
        
        internal class CmdletContext : ExecutorContext
        {
            public List<string> InstanceIds { get; set; }
            public List<Filter> Filter { get; set; }
        }
        
    }
}
