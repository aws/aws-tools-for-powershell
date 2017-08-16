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
    /// Describes the Spot instance requests that belong to your account. Spot instances are
    /// instances that Amazon EC2 launches when the bid price that you specify exceeds the
    /// current Spot price. Amazon EC2 periodically sets the Spot price based on available
    /// Spot instance capacity and current Spot instance requests. For more information, see
    /// <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-requests.html">Spot
    /// Instance Requests</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can use <code>DescribeSpotInstanceRequests</code> to find a running Spot instance
    /// by examining the response. If the status of the Spot instance is <code>fulfilled</code>,
    /// the instance ID appears in the response and contains the identifier of the instance.
    /// Alternatively, you can use <a>DescribeInstances</a> with a filter to look for instances
    /// where the instance lifecycle is <code>spot</code>.
    /// </para><para>
    /// Spot instance requests are deleted 4 hours after they are canceled and their instances
    /// are terminated.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2SpotInstanceRequest")]
    [OutputType("Amazon.EC2.Model.SpotInstanceRequest")]
    [AWSCmdlet("Invokes the DescribeSpotInstanceRequests operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeSpotInstanceRequests"})]
    [AWSCmdletOutput("Amazon.EC2.Model.SpotInstanceRequest",
        "This cmdlet returns a collection of SpotInstanceRequest objects.",
        "The service call response (type Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2SpotInstanceRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone-group</code> - The Availability Zone group.</para></li><li><para><code>create-time</code> - The time stamp when the Spot instance request was created.</para></li><li><para><code>fault-code</code> - The fault code related to the request.</para></li><li><para><code>fault-message</code> - The fault message related to the request.</para></li><li><para><code>instance-id</code> - The ID of the instance that fulfilled the request.</para></li><li><para><code>launch-group</code> - The Spot instance launch group.</para></li><li><para><code>launch.block-device-mapping.delete-on-termination</code> - Indicates whether
        /// the Amazon EBS volume is deleted on instance termination.</para></li><li><para><code>launch.block-device-mapping.device-name</code> - The device name for the Amazon
        /// EBS volume (for example, <code>/dev/sdh</code>).</para></li><li><para><code>launch.block-device-mapping.snapshot-id</code> - The ID of the snapshot used
        /// for the Amazon EBS volume.</para></li><li><para><code>launch.block-device-mapping.volume-size</code> - The size of the Amazon EBS
        /// volume, in GiB.</para></li><li><para><code>launch.block-device-mapping.volume-type</code> - The type of the Amazon EBS
        /// volume: <code>gp2</code> for General Purpose SSD, <code>io1</code> for Provisioned
        /// IOPS SSD, <code>st1</code> for Throughput Optimized HDD, <code>sc1</code>for Cold
        /// HDD, or <code>standard</code> for Magnetic.</para></li><li><para><code>launch.group-id</code> - The security group for the instance.</para></li><li><para><code>launch.image-id</code> - The ID of the AMI.</para></li><li><para><code>launch.instance-type</code> - The type of instance (for example, <code>m3.medium</code>).</para></li><li><para><code>launch.kernel-id</code> - The kernel ID.</para></li><li><para><code>launch.key-name</code> - The name of the key pair the instance launched with.</para></li><li><para><code>launch.monitoring-enabled</code> - Whether monitoring is enabled for the Spot
        /// instance.</para></li><li><para><code>launch.ramdisk-id</code> - The RAM disk ID.</para></li><li><para><code>network-interface.network-interface-id</code> - The ID of the network interface.</para></li><li><para><code>network-interface.device-index</code> - The index of the device for the network
        /// interface attachment on the instance.</para></li><li><para><code>network-interface.subnet-id</code> - The ID of the subnet for the instance.</para></li><li><para><code>network-interface.description</code> - A description of the network interface.</para></li><li><para><code>network-interface.private-ip-address</code> - The primary private IP address
        /// of the network interface.</para></li><li><para><code>network-interface.delete-on-termination</code> - Indicates whether the network
        /// interface is deleted when the instance is terminated.</para></li><li><para><code>network-interface.group-id</code> - The ID of the security group associated
        /// with the network interface.</para></li><li><para><code>network-interface.group-name</code> - The name of the security group associated
        /// with the network interface.</para></li><li><para><code>network-interface.addresses.primary</code> - Indicates whether the IP address
        /// is the primary private IP address.</para></li><li><para><code>product-description</code> - The product description associated with the instance
        /// (<code>Linux/UNIX</code> | <code>Windows</code>).</para></li><li><para><code>spot-instance-request-id</code> - The Spot instance request ID.</para></li><li><para><code>spot-price</code> - The maximum hourly price for any Spot instance launched
        /// to fulfill the request.</para></li><li><para><code>state</code> - The state of the Spot instance request (<code>open</code> |
        /// <code>active</code> | <code>closed</code> | <code>cancelled</code> | <code>failed</code>).
        /// Spot bid status information can help you track your Amazon EC2 Spot instance requests.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-bid-status.html">Spot
        /// Bid Status</a> in the Amazon Elastic Compute Cloud User Guide.</para></li><li><para><code>status-code</code> - The short code describing the most recent evaluation of
        /// your Spot instance request.</para></li><li><para><code>status-message</code> - The message explaining the status of the Spot instance
        /// request.</para></li><li><para><code>tag</code>:<i>key</i>=<i>value</i> - The key/value combination of a tag assigned
        /// to the resource. Specify the key of the tag in the filter name and the value of the
        /// tag in the filter value. For example, for the tag Purpose=X, specify <code>tag:Purpose</code>
        /// for the filter name and <code>X</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. This filter is
        /// independent of the <code>tag-value</code> filter. For example, if you use both the
        /// filter "tag-key=Purpose" and the filter "tag-value=X", you get any resources assigned
        /// both the tag key Purpose (regardless of what the tag's value is), and the tag value
        /// X (regardless of what the tag's key is). If you want to list only resources where
        /// Purpose is X, see the <code>tag</code>:<i>key</i>=<i>value</i> filter.</para></li><li><para><code>tag-value</code> - The value of a tag assigned to the resource. This filter
        /// is independent of the <code>tag-key</code> filter.</para></li><li><para><code>type</code> - The type of Spot instance request (<code>one-time</code> | <code>persistent</code>).</para></li><li><para><code>launched-availability-zone</code> - The Availability Zone in which the bid
        /// is launched.</para></li><li><para><code>valid-from</code> - The start date of the request.</para></li><li><para><code>valid-until</code> - The end date of the request.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SpotInstanceRequestId
        /// <summary>
        /// <para>
        /// <para>One or more Spot instance request IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SpotInstanceRequestIds")]
        public System.String[] SpotInstanceRequestId { get; set; }
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
            if (this.SpotInstanceRequestId != null)
            {
                context.SpotInstanceRequestIds = new List<System.String>(this.SpotInstanceRequestId);
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
            var request = new Amazon.EC2.Model.DescribeSpotInstanceRequestsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.SpotInstanceRequestIds != null)
            {
                request.SpotInstanceRequestIds = cmdletContext.SpotInstanceRequestIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SpotInstanceRequests;
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
        
        private Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSpotInstanceRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "DescribeSpotInstanceRequests");
            try
            {
                #if DESKTOP
                return client.DescribeSpotInstanceRequests(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeSpotInstanceRequestsAsync(request);
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
            public List<System.String> SpotInstanceRequestIds { get; set; }
        }
        
    }
}
