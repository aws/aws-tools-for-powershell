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
    /// </para><br/><br/>In the AWS.Tools.EC2 module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2Instance")]
    [OutputType("Amazon.EC2.Model.Reservation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeInstances API operation.", Operation = new[] {"DescribeInstances"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeInstancesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Reservation or Amazon.EC2.Model.DescribeInstancesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Reservation objects.",
        "The service call response (type Amazon.EC2.Model.DescribeInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2InstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><code>affinity</code> - The affinity setting for an instance running on a Dedicated
        /// Host (<code>default</code> | <code>host</code>).</para></li><li><para><code>architecture</code> - The instance architecture (<code>i386</code> | <code>x86_64</code>
        /// | <code>arm64</code>).</para></li><li><para><code>availability-zone</code> - The Availability Zone of the instance.</para></li><li><para><code>block-device-mapping.attach-time</code> - The attach time for an EBS volume
        /// mapped to the instance, for example, <code>2010-09-15T17:15:20.000Z</code>.</para></li><li><para><code>block-device-mapping.delete-on-termination</code> - A Boolean that indicates
        /// whether the EBS volume is deleted on instance termination.</para></li><li><para><code>block-device-mapping.device-name</code> - The device name specified in the
        /// block device mapping (for example, <code>/dev/sdh</code> or <code>xvdh</code>).</para></li><li><para><code>block-device-mapping.status</code> - The status for the EBS volume (<code>attaching</code>
        /// | <code>attached</code> | <code>detaching</code> | <code>detached</code>).</para></li><li><para><code>block-device-mapping.volume-id</code> - The volume ID of the EBS volume.</para></li><li><para><code>client-token</code> - The idempotency token you provided when you launched
        /// the instance.</para></li><li><para><code>dns-name</code> - The public DNS name of the instance.</para></li><li><para><code>group-id</code> - The ID of the security group for the instance. EC2-Classic
        /// only.</para></li><li><para><code>group-name</code> - The name of the security group for the instance. EC2-Classic
        /// only.</para></li><li><para><code>hibernation-options.configured</code> - A Boolean that indicates whether the
        /// instance is enabled for hibernation. A value of <code>true</code> means that the instance
        /// is enabled for hibernation. </para></li><li><para><code>host-id</code> - The ID of the Dedicated Host on which the instance is running,
        /// if applicable.</para></li><li><para><code>hypervisor</code> - The hypervisor type of the instance (<code>ovm</code> |
        /// <code>xen</code>). The value <code>xen</code> is used for both Xen and Nitro hypervisors.</para></li><li><para><code>iam-instance-profile.arn</code> - The instance profile associated with the
        /// instance. Specified as an ARN.</para></li><li><para><code>image-id</code> - The ID of the image used to launch the instance.</para></li><li><para><code>instance-id</code> - The ID of the instance.</para></li><li><para><code>instance-lifecycle</code> - Indicates whether this is a Spot Instance or a
        /// Scheduled Instance (<code>spot</code> | <code>scheduled</code>).</para></li><li><para><code>instance-state-code</code> - The state of the instance, as a 16-bit unsigned
        /// integer. The high byte is used for internal purposes and should be ignored. The low
        /// byte is set based on the state represented. The valid values are: 0 (pending), 16
        /// (running), 32 (shutting-down), 48 (terminated), 64 (stopping), and 80 (stopped).</para></li><li><para><code>instance-state-name</code> - The state of the instance (<code>pending</code>
        /// | <code>running</code> | <code>shutting-down</code> | <code>terminated</code> | <code>stopping</code>
        /// | <code>stopped</code>).</para></li><li><para><code>instance-type</code> - The type of instance (for example, <code>t2.micro</code>).</para></li><li><para><code>instance.group-id</code> - The ID of the security group for the instance. </para></li><li><para><code>instance.group-name</code> - The name of the security group for the instance.
        /// </para></li><li><para><code>ip-address</code> - The public IPv4 address of the instance.</para></li><li><para><code>kernel-id</code> - The kernel ID.</para></li><li><para><code>key-name</code> - The name of the key pair used when the instance was launched.</para></li><li><para><code>launch-index</code> - When launching multiple instances, this is the index
        /// for the instance in the launch group (for example, 0, 1, 2, and so on). </para></li><li><para><code>launch-time</code> - The time when the instance was launched.</para></li><li><para><code>metadata-options.http-tokens</code> - The metadata request authorization state
        /// (<code>optional</code> | <code>required</code>)</para></li><li><para><code>metadata-options.http-put-response-hop-limit</code> - The http metadata request
        /// put response hop limit (integer, possible values <code>1</code> to <code>64</code>)</para></li><li><para><code>metadata-options.http-endpoint</code> - Enable or disable metadata access on
        /// http endpoint (<code>enabled</code> | <code>disabled</code>)</para></li><li><para><code>monitoring-state</code> - Indicates whether detailed monitoring is enabled
        /// (<code>disabled</code> | <code>enabled</code>).</para></li><li><para><code>network-interface.addresses.private-ip-address</code> - The private IPv4 address
        /// associated with the network interface.</para></li><li><para><code>network-interface.addresses.primary</code> - Specifies whether the IPv4 address
        /// of the network interface is the primary private IPv4 address.</para></li><li><para><code>network-interface.addresses.association.public-ip</code> - The ID of the association
        /// of an Elastic IP address (IPv4) with a network interface.</para></li><li><para><code>network-interface.addresses.association.ip-owner-id</code> - The owner ID of
        /// the private IPv4 address associated with the network interface.</para></li><li><para><code>network-interface.association.public-ip</code> - The address of the Elastic
        /// IP address (IPv4) bound to the network interface.</para></li><li><para><code>network-interface.association.ip-owner-id</code> - The owner of the Elastic
        /// IP address (IPv4) associated with the network interface.</para></li><li><para><code>network-interface.association.allocation-id</code> - The allocation ID returned
        /// when you allocated the Elastic IP address (IPv4) for your network interface.</para></li><li><para><code>network-interface.association.association-id</code> - The association ID returned
        /// when the network interface was associated with an IPv4 address.</para></li><li><para><code>network-interface.attachment.attachment-id</code> - The ID of the interface
        /// attachment.</para></li><li><para><code>network-interface.attachment.instance-id</code> - The ID of the instance to
        /// which the network interface is attached.</para></li><li><para><code>network-interface.attachment.instance-owner-id</code> - The owner ID of the
        /// instance to which the network interface is attached.</para></li><li><para><code>network-interface.attachment.device-index</code> - The device index to which
        /// the network interface is attached.</para></li><li><para><code>network-interface.attachment.status</code> - The status of the attachment (<code>attaching</code>
        /// | <code>attached</code> | <code>detaching</code> | <code>detached</code>).</para></li><li><para><code>network-interface.attachment.attach-time</code> - The time that the network
        /// interface was attached to an instance.</para></li><li><para><code>network-interface.attachment.delete-on-termination</code> - Specifies whether
        /// the attachment is deleted when an instance is terminated.</para></li><li><para><code>network-interface.availability-zone</code> - The Availability Zone for the
        /// network interface.</para></li><li><para><code>network-interface.description</code> - The description of the network interface.</para></li><li><para><code>network-interface.group-id</code> - The ID of a security group associated with
        /// the network interface.</para></li><li><para><code>network-interface.group-name</code> - The name of a security group associated
        /// with the network interface.</para></li><li><para><code>network-interface.ipv6-addresses.ipv6-address</code> - The IPv6 address associated
        /// with the network interface.</para></li><li><para><code>network-interface.mac-address</code> - The MAC address of the network interface.</para></li><li><para><code>network-interface.network-interface-id</code> - The ID of the network interface.</para></li><li><para><code>network-interface.owner-id</code> - The ID of the owner of the network interface.</para></li><li><para><code>network-interface.private-dns-name</code> - The private DNS name of the network
        /// interface.</para></li><li><para><code>network-interface.requester-id</code> - The requester ID for the network interface.</para></li><li><para><code>network-interface.requester-managed</code> - Indicates whether the network
        /// interface is being managed by AWS.</para></li><li><para><code>network-interface.status</code> - The status of the network interface (<code>available</code>)
        /// | <code>in-use</code>).</para></li><li><para><code>network-interface.source-dest-check</code> - Whether the network interface
        /// performs source/destination checking. A value of <code>true</code> means that checking
        /// is enabled, and <code>false</code> means that checking is disabled. The value must
        /// be <code>false</code> for the network interface to perform network address translation
        /// (NAT) in your VPC.</para></li><li><para><code>network-interface.subnet-id</code> - The ID of the subnet for the network interface.</para></li><li><para><code>network-interface.vpc-id</code> - The ID of the VPC for the network interface.</para></li><li><para><code>owner-id</code> - The AWS account ID of the instance owner.</para></li><li><para><code>placement-group-name</code> - The name of the placement group for the instance.</para></li><li><para><code>placement-partition-number</code> - The partition in which the instance is
        /// located.</para></li><li><para><code>platform</code> - The platform. To list only Windows instances, use <code>windows</code>.</para></li><li><para><code>private-dns-name</code> - The private IPv4 DNS name of the instance.</para></li><li><para><code>private-ip-address</code> - The private IPv4 address of the instance.</para></li><li><para><code>product-code</code> - The product code associated with the AMI used to launch
        /// the instance.</para></li><li><para><code>product-code.type</code> - The type of product code (<code>devpay</code> |
        /// <code>marketplace</code>).</para></li><li><para><code>ramdisk-id</code> - The RAM disk ID.</para></li><li><para><code>reason</code> - The reason for the current state of the instance (for example,
        /// shows "User Initiated [date]" when you stop or terminate the instance). Similar to
        /// the state-reason-code filter.</para></li><li><para><code>requester-id</code> - The ID of the entity that launched the instance on your
        /// behalf (for example, AWS Management Console, Auto Scaling, and so on).</para></li><li><para><code>reservation-id</code> - The ID of the instance's reservation. A reservation
        /// ID is created any time you launch an instance. A reservation ID has a one-to-one relationship
        /// with an instance launch request, but can be associated with more than one instance
        /// if you launch multiple instances using the same launch request. For example, if you
        /// launch one instance, you get one reservation ID. If you launch ten instances using
        /// the same launch request, you also get one reservation ID.</para></li><li><para><code>root-device-name</code> - The device name of the root device volume (for example,
        /// <code>/dev/sda1</code>).</para></li><li><para><code>root-device-type</code> - The type of the root device volume (<code>ebs</code>
        /// | <code>instance-store</code>).</para></li><li><para><code>source-dest-check</code> - Indicates whether the instance performs source/destination
        /// checking. A value of <code>true</code> means that checking is enabled, and <code>false</code>
        /// means that checking is disabled. The value must be <code>false</code> for the instance
        /// to perform network address translation (NAT) in your VPC. </para></li><li><para><code>spot-instance-request-id</code> - The ID of the Spot Instance request.</para></li><li><para><code>state-reason-code</code> - The reason code for the state change.</para></li><li><para><code>state-reason-message</code> - A message that describes the state change.</para></li><li><para><code>subnet-id</code> - The ID of the subnet for the instance.</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources that have a tag with a specific key, regardless of the tag value.</para></li><li><para><code>tenancy</code> - The tenancy of an instance (<code>dedicated</code> | <code>default</code>
        /// | <code>host</code>).</para></li><li><para><code>virtualization-type</code> - The virtualization type of the instance (<code>paravirtual</code>
        /// | <code>hvm</code>).</para></li><li><para><code>vpc-id</code> - The ID of the VPC that the instance is running in.</para></li></ul>
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
        /// <para>The maximum number of results to return in a single call. To retrieve the remaining
        /// results, make another call with the returned <code>NextToken</code> value. This value
        /// can be between 5 and 1000. You cannot specify this parameter and the instance IDs
        /// parameter in the same call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to request the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.EC2 module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeInstancesResponse, GetEC2InstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeInstancesRequest();
            
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
                #if DESKTOP
                return client.DescribeInstances(request);
                #elif CORECLR
                return client.DescribeInstancesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public List<System.String> InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeInstancesResponse, GetEC2InstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Reservations;
        }
        
    }
}
