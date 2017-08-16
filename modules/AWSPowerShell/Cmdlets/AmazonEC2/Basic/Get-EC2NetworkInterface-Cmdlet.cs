/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Describes one or more of your network interfaces.
    /// </summary>
    [Cmdlet("Get", "EC2NetworkInterface")]
    [OutputType("Amazon.EC2.Model.NetworkInterface")]
    [AWSCmdlet("Invokes the DescribeNetworkInterfaces operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeNetworkInterfaces"})]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInterface",
        "This cmdlet returns a collection of NetworkInterface objects.",
        "The service call response (type Amazon.EC2.Model.DescribeNetworkInterfacesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2NetworkInterfaceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>addresses.private-ip-address</code> - The private IPv4 addresses associated
        /// with the network interface.</para></li><li><para><code>addresses.primary</code> - Whether the private IPv4 address is the primary
        /// IP address associated with the network interface. </para></li><li><para><code>addresses.association.public-ip</code> - The association ID returned when the
        /// network interface was associated with the Elastic IP address (IPv4).</para></li><li><para><code>addresses.association.owner-id</code> - The owner ID of the addresses associated
        /// with the network interface.</para></li><li><para><code>association.association-id</code> - The association ID returned when the network
        /// interface was associated with an IPv4 address.</para></li><li><para><code>association.allocation-id</code> - The allocation ID returned when you allocated
        /// the Elastic IP address (IPv4) for your network interface.</para></li><li><para><code>association.ip-owner-id</code> - The owner of the Elastic IP address (IPv4)
        /// associated with the network interface.</para></li><li><para><code>association.public-ip</code> - The address of the Elastic IP address (IPv4)
        /// bound to the network interface.</para></li><li><para><code>association.public-dns-name</code> - The public DNS name for the network interface
        /// (IPv4).</para></li><li><para><code>attachment.attachment-id</code> - The ID of the interface attachment.</para></li><li><para><code>attachment.attach.time</code> - The time that the network interface was attached
        /// to an instance.</para></li><li><para><code>attachment.delete-on-termination</code> - Indicates whether the attachment
        /// is deleted when an instance is terminated.</para></li><li><para><code>attachment.device-index</code> - The device index to which the network interface
        /// is attached.</para></li><li><para><code>attachment.instance-id</code> - The ID of the instance to which the network
        /// interface is attached.</para></li><li><para><code>attachment.instance-owner-id</code> - The owner ID of the instance to which
        /// the network interface is attached.</para></li><li><para><code>attachment.nat-gateway-id</code> - The ID of the NAT gateway to which the network
        /// interface is attached.</para></li><li><para><code>attachment.status</code> - The status of the attachment (<code>attaching</code>
        /// | <code>attached</code> | <code>detaching</code> | <code>detached</code>).</para></li><li><para><code>availability-zone</code> - The Availability Zone of the network interface.</para></li><li><para><code>description</code> - The description of the network interface.</para></li><li><para><code>group-id</code> - The ID of a security group associated with the network interface.</para></li><li><para><code>group-name</code> - The name of a security group associated with the network
        /// interface.</para></li><li><para><code>ipv6-addresses.ipv6-address</code> - An IPv6 address associated with the network
        /// interface.</para></li><li><para><code>mac-address</code> - The MAC address of the network interface.</para></li><li><para><code>network-interface-id</code> - The ID of the network interface.</para></li><li><para><code>owner-id</code> - The AWS account ID of the network interface owner.</para></li><li><para><code>private-ip-address</code> - The private IPv4 address or addresses of the network
        /// interface.</para></li><li><para><code>private-dns-name</code> - The private DNS name of the network interface (IPv4).</para></li><li><para><code>requester-id</code> - The ID of the entity that launched the instance on your
        /// behalf (for example, AWS Management Console, Auto Scaling, and so on).</para></li><li><para><code>requester-managed</code> - Indicates whether the network interface is being
        /// managed by an AWS service (for example, AWS Management Console, Auto Scaling, and
        /// so on).</para></li><li><para><code>source-desk-check</code> - Indicates whether the network interface performs
        /// source/destination checking. A value of <code>true</code> means checking is enabled,
        /// and <code>false</code> means checking is disabled. The value must be <code>false</code>
        /// for the network interface to perform network address translation (NAT) in your VPC.
        /// </para></li><li><para><code>status</code> - The status of the network interface. If the network interface
        /// is not attached to an instance, the status is <code>available</code>; if a network
        /// interface is attached to an instance the status is <code>in-use</code>.</para></li><li><para><code>subnet-id</code> - The ID of the subnet for the network interface.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource. Specify the key of the tag in the filter name and the value of the
        /// tag in the filter value. For example, for the tag Purpose=X, specify <code>tag:Purpose</code>
        /// for the filter name and <code>X</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is
        /// independent of the <code>tag-value</code> filter. For example, if you use both the
        /// filter "tag-key=Purpose" and the filter "tag-value=X", you get any resources assigned
        /// both the tag key Purpose (regardless of what the tag's value is), and the tag value
        /// X (regardless of what the tag's key is). If you want to list only resources where
        /// Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i> filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>vpc-id</code> - The ID of the VPC for the network interface.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>One or more network interface IDs.</para><para>Default: Describes all your network interfaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("NetworkInterfaceIds")]
        public System.String[] NetworkInterfaceId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.NetworkInterfaceId != null)
            {
                context.NetworkInterfaceIds = new List<System.String>(this.NetworkInterfaceId);
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
            var request = new Amazon.EC2.Model.DescribeNetworkInterfacesRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.NetworkInterfaceIds != null)
            {
                request.NetworkInterfaceIds = cmdletContext.NetworkInterfaceIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NetworkInterfaces;
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
        
        private Amazon.EC2.Model.DescribeNetworkInterfacesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeNetworkInterfacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeNetworkInterfaces");
            try
            {
                #if DESKTOP
                return client.DescribeNetworkInterfaces(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeNetworkInterfacesAsync(request);
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
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public List<System.String> NetworkInterfaceIds { get; set; }
        }
        
    }
}
