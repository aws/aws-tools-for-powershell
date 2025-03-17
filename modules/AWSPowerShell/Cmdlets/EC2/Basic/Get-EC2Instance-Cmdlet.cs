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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified instances or all instances.
    /// 
    ///  
    /// <para>
    /// If you specify instance IDs, the output includes information for only the specified
    /// instances. If you specify filters, the output includes information for only those
    /// instances that meet the filter criteria. If you do not specify instance IDs or filters,
    /// the output includes information for all instances, which can affect performance. We
    /// recommend that you use pagination to ensure that the operation returns quickly and
    /// successfully.
    /// </para><para>
    /// If you specify an instance ID that is not valid, an error is returned. If you specify
    /// an instance that you do not own, it is not included in the output.
    /// </para><para>
    /// Recently terminated instances might appear in the returned results. This interval
    /// is usually less than one hour.
    /// </para><para>
    /// If you describe instances in the rare case where an Availability Zone is experiencing
    /// a service disruption and you specify instance IDs that are in the affected zone, or
    /// do not specify any instance IDs at all, the call fails. If you describe instances
    /// and specify only instance IDs that are in an unaffected zone, the call works normally.
    /// </para><important><para>
    /// We strongly recommend using only paginated requests. Unpaginated requests are susceptible
    /// to throttling and timeouts.
    /// </para></important><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note><br/><br/>In the AWS.Tools.EC2 module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2Instance")]
    [OutputType("Amazon.EC2.Model.Reservation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeInstances API operation.", Operation = new[] {"DescribeInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Reservation or Amazon.EC2.Model.DescribeInstancesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Reservation objects.",
        "The service call response (type Amazon.EC2.Model.DescribeInstancesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the operation, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>affinity</c> - The affinity setting for an instance running on a Dedicated Host
        /// (<c>default</c> | <c>host</c>).</para></li><li><para><c>architecture</c> - The instance architecture (<c>i386</c> | <c>x86_64</c> | <c>arm64</c>).</para></li><li><para><c>availability-zone</c> - The Availability Zone of the instance.</para></li><li><para><c>block-device-mapping.attach-time</c> - The attach time for an EBS volume mapped
        /// to the instance, for example, <c>2022-09-15T17:15:20.000Z</c>.</para></li><li><para><c>block-device-mapping.delete-on-termination</c> - A Boolean that indicates whether
        /// the EBS volume is deleted on instance termination.</para></li><li><para><c>block-device-mapping.device-name</c> - The device name specified in the block
        /// device mapping (for example, <c>/dev/sdh</c> or <c>xvdh</c>).</para></li><li><para><c>block-device-mapping.status</c> - The status for the EBS volume (<c>attaching</c>
        /// | <c>attached</c> | <c>detaching</c> | <c>detached</c>).</para></li><li><para><c>block-device-mapping.volume-id</c> - The volume ID of the EBS volume.</para></li><li><para><c>boot-mode</c> - The boot mode that was specified by the AMI (<c>legacy-bios</c>
        /// | <c>uefi</c> | <c>uefi-preferred</c>).</para></li><li><para><c>capacity-reservation-id</c> - The ID of the Capacity Reservation into which the
        /// instance was launched.</para></li><li><para><c>capacity-reservation-specification.capacity-reservation-preference</c> - The instance's
        /// Capacity Reservation preference (<c>open</c> | <c>none</c>).</para></li><li><para><c>capacity-reservation-specification.capacity-reservation-target.capacity-reservation-id</c>
        /// - The ID of the targeted Capacity Reservation.</para></li><li><para><c>capacity-reservation-specification.capacity-reservation-target.capacity-reservation-resource-group-arn</c>
        /// - The ARN of the targeted Capacity Reservation group.</para></li><li><para><c>client-token</c> - The idempotency token you provided when you launched the instance.</para></li><li><para><c>current-instance-boot-mode</c> - The boot mode that is used to launch the instance
        /// at launch or start (<c>legacy-bios</c> | <c>uefi</c>).</para></li><li><para><c>dns-name</c> - The public DNS name of the instance.</para></li><li><para><c>ebs-optimized</c> - A Boolean that indicates whether the instance is optimized
        /// for Amazon EBS I/O.</para></li><li><para><c>ena-support</c> - A Boolean that indicates whether the instance is enabled for
        /// enhanced networking with ENA.</para></li><li><para><c>enclave-options.enabled</c> - A Boolean that indicates whether the instance is
        /// enabled for Amazon Web Services Nitro Enclaves.</para></li><li><para><c>hibernation-options.configured</c> - A Boolean that indicates whether the instance
        /// is enabled for hibernation. A value of <c>true</c> means that the instance is enabled
        /// for hibernation.</para></li><li><para><c>host-id</c> - The ID of the Dedicated Host on which the instance is running, if
        /// applicable.</para></li><li><para><c>hypervisor</c> - The hypervisor type of the instance (<c>ovm</c> | <c>xen</c>).
        /// The value <c>xen</c> is used for both Xen and Nitro hypervisors.</para></li><li><para><c>iam-instance-profile.arn</c> - The instance profile associated with the instance.
        /// Specified as an ARN.</para></li><li><para><c>iam-instance-profile.id</c> - The instance profile associated with the instance.
        /// Specified as an ID.</para></li><li><para><c>image-id</c> - The ID of the image used to launch the instance.</para></li><li><para><c>instance-id</c> - The ID of the instance.</para></li><li><para><c>instance-lifecycle</c> - Indicates whether this is a Spot Instance, a Scheduled
        /// Instance, or a Capacity Block (<c>spot</c> | <c>scheduled</c> | <c>capacity-block</c>).</para></li><li><para><c>instance-state-code</c> - The state of the instance, as a 16-bit unsigned integer.
        /// The high byte is used for internal purposes and should be ignored. The low byte is
        /// set based on the state represented. The valid values are: 0 (pending), 16 (running),
        /// 32 (shutting-down), 48 (terminated), 64 (stopping), and 80 (stopped).</para></li><li><para><c>instance-state-name</c> - The state of the instance (<c>pending</c> | <c>running</c>
        /// | <c>shutting-down</c> | <c>terminated</c> | <c>stopping</c> | <c>stopped</c>).</para></li><li><para><c>instance-type</c> - The type of instance (for example, <c>t2.micro</c>).</para></li><li><para><c>instance.group-id</c> - The ID of the security group for the instance. </para></li><li><para><c>instance.group-name</c> - The name of the security group for the instance. </para></li><li><para><c>ip-address</c> - The public IPv4 address of the instance.</para></li><li><para><c>ipv6-address</c> - The IPv6 address of the instance.</para></li><li><para><c>kernel-id</c> - The kernel ID.</para></li><li><para><c>key-name</c> - The name of the key pair used when the instance was launched.</para></li><li><para><c>launch-index</c> - When launching multiple instances, this is the index for the
        /// instance in the launch group (for example, 0, 1, 2, and so on). </para></li><li><para><c>launch-time</c> - The time when the instance was launched, in the ISO 8601 format
        /// in the UTC time zone (YYYY-MM-DDThh:mm:ss.sssZ), for example, <c>2021-09-29T11:04:43.305Z</c>.
        /// You can use a wildcard (<c>*</c>), for example, <c>2021-09-29T*</c>, which matches
        /// an entire day.</para></li><li><para><c>maintenance-options.auto-recovery</c> - The current automatic recovery behavior
        /// of the instance (<c>disabled</c> | <c>default</c>).</para></li><li><para><c>metadata-options.http-endpoint</c> - The status of access to the HTTP metadata
        /// endpoint on your instance (<c>enabled</c> | <c>disabled</c>)</para></li><li><para><c>metadata-options.http-protocol-ipv4</c> - Indicates whether the IPv4 endpoint
        /// is enabled (<c>disabled</c> | <c>enabled</c>).</para></li><li><para><c>metadata-options.http-protocol-ipv6</c> - Indicates whether the IPv6 endpoint
        /// is enabled (<c>disabled</c> | <c>enabled</c>).</para></li><li><para><c>metadata-options.http-put-response-hop-limit</c> - The HTTP metadata request put
        /// response hop limit (integer, possible values <c>1</c> to <c>64</c>)</para></li><li><para><c>metadata-options.http-tokens</c> - The metadata request authorization state (<c>optional</c>
        /// | <c>required</c>)</para></li><li><para><c>metadata-options.instance-metadata-tags</c> - The status of access to instance
        /// tags from the instance metadata (<c>enabled</c> | <c>disabled</c>)</para></li><li><para><c>metadata-options.state</c> - The state of the metadata option changes (<c>pending</c>
        /// | <c>applied</c>).</para></li><li><para><c>monitoring-state</c> - Indicates whether detailed monitoring is enabled (<c>disabled</c>
        /// | <c>enabled</c>).</para></li><li><para><c>network-interface.addresses.association.allocation-id</c> - The allocation ID.</para></li><li><para><c>network-interface.addresses.association.association-id</c> - The association ID.</para></li><li><para><c>network-interface.addresses.association.carrier-ip</c> - The carrier IP address.</para></li><li><para><c>network-interface.addresses.association.customer-owned-ip</c> - The customer-owned
        /// IP address.</para></li><li><para><c>network-interface.addresses.association.ip-owner-id</c> - The owner ID of the
        /// private IPv4 address associated with the network interface.</para></li><li><para><c>network-interface.addresses.association.public-dns-name</c> - The public DNS name.</para></li><li><para><c>network-interface.addresses.association.public-ip</c> - The ID of the association
        /// of an Elastic IP address (IPv4) with a network interface.</para></li><li><para><c>network-interface.addresses.primary</c> - Specifies whether the IPv4 address of
        /// the network interface is the primary private IPv4 address.</para></li><li><para><c>network-interface.addresses.private-dns-name</c> - The private DNS name.</para></li><li><para><c>network-interface.addresses.private-ip-address</c> - The private IPv4 address
        /// associated with the network interface.</para></li><li><para><c>network-interface.association.allocation-id</c> - The allocation ID returned when
        /// you allocated the Elastic IP address (IPv4) for your network interface.</para></li><li><para><c>network-interface.association.association-id</c> - The association ID returned
        /// when the network interface was associated with an IPv4 address.</para></li><li><para><c>network-interface.association.carrier-ip</c> - The customer-owned IP address.</para></li><li><para><c>network-interface.association.customer-owned-ip</c> - The customer-owned IP address.</para></li><li><para><c>network-interface.association.ip-owner-id</c> - The owner of the Elastic IP address
        /// (IPv4) associated with the network interface.</para></li><li><para><c>network-interface.association.public-dns-name</c> - The public DNS name.</para></li><li><para><c>network-interface.association.public-ip</c> - The address of the Elastic IP address
        /// (IPv4) bound to the network interface.</para></li><li><para><c>network-interface.attachment.attach-time</c> - The time that the network interface
        /// was attached to an instance.</para></li><li><para><c>network-interface.attachment.attachment-id</c> - The ID of the interface attachment.</para></li><li><para><c>network-interface.attachment.delete-on-termination</c> - Specifies whether the
        /// attachment is deleted when an instance is terminated.</para></li><li><para><c>network-interface.attachment.device-index</c> - The device index to which the
        /// network interface is attached.</para></li><li><para><c>network-interface.attachment.instance-id</c> - The ID of the instance to which
        /// the network interface is attached.</para></li><li><para><c>network-interface.attachment.instance-owner-id</c> - The owner ID of the instance
        /// to which the network interface is attached.</para></li><li><para><c>network-interface.attachment.network-card-index</c> - The index of the network
        /// card.</para></li><li><para><c>network-interface.attachment.status</c> - The status of the attachment (<c>attaching</c>
        /// | <c>attached</c> | <c>detaching</c> | <c>detached</c>).</para></li><li><para><c>network-interface.availability-zone</c> - The Availability Zone for the network
        /// interface.</para></li><li><para><c>network-interface.deny-all-igw-traffic</c> - A Boolean that indicates whether
        /// a network interface with an IPv6 address is unreachable from the public internet.</para></li><li><para><c>network-interface.description</c> - The description of the network interface.</para></li><li><para><c>network-interface.group-id</c> - The ID of a security group associated with the
        /// network interface.</para></li><li><para><c>network-interface.group-name</c> - The name of a security group associated with
        /// the network interface.</para></li><li><para><c>network-interface.ipv4-prefixes.ipv4-prefix</c> - The IPv4 prefixes that are assigned
        /// to the network interface.</para></li><li><para><c>network-interface.ipv6-address</c> - The IPv6 address associated with the network
        /// interface.</para></li><li><para><c>network-interface.ipv6-addresses.ipv6-address</c> - The IPv6 address associated
        /// with the network interface.</para></li><li><para><c>network-interface.ipv6-addresses.is-primary-ipv6</c> - A Boolean that indicates
        /// whether this is the primary IPv6 address.</para></li><li><para><c>network-interface.ipv6-native</c> - A Boolean that indicates whether this is an
        /// IPv6 only network interface.</para></li><li><para><c>network-interface.ipv6-prefixes.ipv6-prefix</c> - The IPv6 prefix assigned to
        /// the network interface.</para></li><li><para><c>network-interface.mac-address</c> - The MAC address of the network interface.</para></li><li><para><c>network-interface.network-interface-id</c> - The ID of the network interface.</para></li><li><para><c>network-interface.operator.managed</c> - A Boolean that indicates whether the
        /// instance has a managed network interface.</para></li><li><para><c>network-interface.operator.principal</c> - The principal that manages the network
        /// interface. Only valid for instances with managed network interfaces, where <c>managed</c>
        /// is <c>true</c>.</para></li><li><para><c>network-interface.outpost-arn</c> - The ARN of the Outpost.</para></li><li><para><c>network-interface.owner-id</c> - The ID of the owner of the network interface.</para></li><li><para><c>network-interface.private-dns-name</c> - The private DNS name of the network interface.</para></li><li><para><c>network-interface.private-ip-address</c> - The private IPv4 address.</para></li><li><para><c>network-interface.public-dns-name</c> - The public DNS name.</para></li><li><para><c>network-interface.requester-id</c> - The requester ID for the network interface.</para></li><li><para><c>network-interface.requester-managed</c> - Indicates whether the network interface
        /// is being managed by Amazon Web Services.</para></li><li><para><c>network-interface.status</c> - The status of the network interface (<c>available</c>)
        /// | <c>in-use</c>).</para></li><li><para><c>network-interface.source-dest-check</c> - Whether the network interface performs
        /// source/destination checking. A value of <c>true</c> means that checking is enabled,
        /// and <c>false</c> means that checking is disabled. The value must be <c>false</c> for
        /// the network interface to perform network address translation (NAT) in your VPC.</para></li><li><para><c>network-interface.subnet-id</c> - The ID of the subnet for the network interface.</para></li><li><para><c>network-interface.tag-key</c> - The key of a tag assigned to the network interface.</para></li><li><para><c>network-interface.tag-value</c> - The value of a tag assigned to the network interface.</para></li><li><para><c>network-interface.vpc-id</c> - The ID of the VPC for the network interface.</para></li><li><para><c>network-performance-options.bandwidth-weighting</c> - Where the performance boost
        /// is applied, if applicable. Valid values: <c>default</c>, <c>vpc-1</c>, <c>ebs-1</c>.</para></li><li><para><c>operator.managed</c> - A Boolean that indicates whether this is a managed instance.</para></li><li><para><c>operator.principal</c> - The principal that manages the instance. Only valid for
        /// managed instances, where <c>managed</c> is <c>true</c>.</para></li><li><para><c>outpost-arn</c> - The Amazon Resource Name (ARN) of the Outpost.</para></li><li><para><c>owner-id</c> - The Amazon Web Services account ID of the instance owner.</para></li><li><para><c>placement-group-name</c> - The name of the placement group for the instance.</para></li><li><para><c>placement-partition-number</c> - The partition in which the instance is located.</para></li><li><para><c>platform</c> - The platform. To list only Windows instances, use <c>windows</c>.</para></li><li><para><c>platform-details</c> - The platform (<c>Linux/UNIX</c> | <c>Red Hat BYOL Linux</c>
        /// | <c> Red Hat Enterprise Linux</c> | <c>Red Hat Enterprise Linux with HA</c> | <c>Red
        /// Hat Enterprise Linux with SQL Server Standard and HA</c> | <c>Red Hat Enterprise Linux
        /// with SQL Server Enterprise and HA</c> | <c>Red Hat Enterprise Linux with SQL Server
        /// Standard</c> | <c>Red Hat Enterprise Linux with SQL Server Web</c> | <c>Red Hat Enterprise
        /// Linux with SQL Server Enterprise</c> | <c>SQL Server Enterprise</c> | <c>SQL Server
        /// Standard</c> | <c>SQL Server Web</c> | <c>SUSE Linux</c> | <c>Ubuntu Pro</c> | <c>Windows</c>
        /// | <c>Windows BYOL</c> | <c>Windows with SQL Server Enterprise</c> | <c>Windows with
        /// SQL Server Standard</c> | <c>Windows with SQL Server Web</c>).</para></li><li><para><c>private-dns-name</c> - The private IPv4 DNS name of the instance.</para></li><li><para><c>private-dns-name-options.enable-resource-name-dns-a-record</c> - A Boolean that
        /// indicates whether to respond to DNS queries for instance hostnames with DNS A records.</para></li><li><para><c>private-dns-name-options.enable-resource-name-dns-aaaa-record</c> - A Boolean
        /// that indicates whether to respond to DNS queries for instance hostnames with DNS AAAA
        /// records.</para></li><li><para><c>private-dns-name-options.hostname-type</c> - The type of hostname (<c>ip-name</c>
        /// | <c>resource-name</c>).</para></li><li><para><c>private-ip-address</c> - The private IPv4 address of the instance. This can only
        /// be used to filter by the primary IP address of the network interface attached to the
        /// instance. To filter by additional IP addresses assigned to the network interface,
        /// use the filter <c>network-interface.addresses.private-ip-address</c>.</para></li><li><para><c>product-code</c> - The product code associated with the AMI used to launch the
        /// instance.</para></li><li><para><c>product-code.type</c> - The type of product code (<c>devpay</c> | <c>marketplace</c>).</para></li><li><para><c>ramdisk-id</c> - The RAM disk ID.</para></li><li><para><c>reason</c> - The reason for the current state of the instance (for example, shows
        /// "User Initiated [date]" when you stop or terminate the instance). Similar to the state-reason-code
        /// filter.</para></li><li><para><c>requester-id</c> - The ID of the entity that launched the instance on your behalf
        /// (for example, Amazon Web Services Management Console, Auto Scaling, and so on).</para></li><li><para><c>reservation-id</c> - The ID of the instance's reservation. A reservation ID is
        /// created any time you launch an instance. A reservation ID has a one-to-one relationship
        /// with an instance launch request, but can be associated with more than one instance
        /// if you launch multiple instances using the same launch request. For example, if you
        /// launch one instance, you get one reservation ID. If you launch ten instances using
        /// the same launch request, you also get one reservation ID.</para></li><li><para><c>root-device-name</c> - The device name of the root device volume (for example,
        /// <c>/dev/sda1</c>).</para></li><li><para><c>root-device-type</c> - The type of the root device volume (<c>ebs</c> | <c>instance-store</c>).</para></li><li><para><c>source-dest-check</c> - Indicates whether the instance performs source/destination
        /// checking. A value of <c>true</c> means that checking is enabled, and <c>false</c>
        /// means that checking is disabled. The value must be <c>false</c> for the instance to
        /// perform network address translation (NAT) in your VPC. </para></li><li><para><c>spot-instance-request-id</c> - The ID of the Spot Instance request.</para></li><li><para><c>state-reason-code</c> - The reason code for the state change.</para></li><li><para><c>state-reason-message</c> - A message that describes the state change.</para></li><li><para><c>subnet-id</c> - The ID of the subnet for the instance.</para></li><li><para><c>tag:&lt;key&gt;</c> - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources that have a tag with a specific key, regardless of the tag value.</para></li><li><para><c>tenancy</c> - The tenancy of an instance (<c>dedicated</c> | <c>default</c> |
        /// <c>host</c>).</para></li><li><para><c>tpm-support</c> - Indicates if the instance is configured for NitroTPM support
        /// (<c>v2.0</c>). </para></li><li><para><c>usage-operation</c> - The usage operation value for the instance (<c>RunInstances</c>
        /// | <c>RunInstances:00g0</c> | <c>RunInstances:0010</c> | <c>RunInstances:1010</c> |
        /// <c>RunInstances:1014</c> | <c>RunInstances:1110</c> | <c>RunInstances:0014</c> | <c>RunInstances:0210</c>
        /// | <c>RunInstances:0110</c> | <c>RunInstances:0100</c> | <c>RunInstances:0004</c> |
        /// <c>RunInstances:0200</c> | <c>RunInstances:000g</c> | <c>RunInstances:0g00</c> | <c>RunInstances:0002</c>
        /// | <c>RunInstances:0800</c> | <c>RunInstances:0102</c> | <c>RunInstances:0006</c> |
        /// <c>RunInstances:0202</c>).</para></li><li><para><c>usage-operation-update-time</c> - The time that the usage operation was last updated,
        /// for example, <c>2022-09-15T17:15:20.000Z</c>.</para></li><li><para><c>virtualization-type</c> - The virtualization type of the instance (<c>paravirtual</c>
        /// | <c>hvm</c>).</para></li><li><para><c>vpc-id</c> - The ID of the VPC that the instance is running in.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The instance IDs.</para><para>Default: Describes all your instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("InstanceIds")]
        public object[] InstanceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para><para>You cannot specify this parameter and the instance IDs parameter in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned from a previous paginated request. Pagination continues from the
        /// end of the items returned by the previous request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.EC2 module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Reservations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeInstancesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeInstancesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Reservations";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeInstancesResponse, GetEC2InstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.InstanceId != null)
            {
                context.InstanceId = AmazonEC2Helper.InstanceParamToIDs(this.InstanceId);
            }
            
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeInstancesRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DescribeInstancesRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceIds = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeInstancesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeInstancesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeInstances");
            try
            {
                return client.DescribeInstancesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeInstancesResponse, GetEC2InstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Reservations;
        }
        
    }
}
