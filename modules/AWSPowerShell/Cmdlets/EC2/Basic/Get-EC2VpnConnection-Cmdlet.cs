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
    /// Describes one or more of your VPN connections.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpn/latest/s2svpn/VPC_VPN.html">Amazon
    /// Web Services Site-to-Site VPN</a> in the <i>Amazon Web Services Site-to-Site VPN User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2VpnConnection")]
    [OutputType("Amazon.EC2.Model.VpnConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeVpnConnections API operation.", Operation = new[] {"DescribeVpnConnections"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeVpnConnectionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnConnection or Amazon.EC2.Model.DescribeVpnConnectionsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.VpnConnection objects.",
        "The service call response (type Amazon.EC2.Model.DescribeVpnConnectionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2VpnConnectionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><c>customer-gateway-configuration</c> - The configuration information for the customer
        /// gateway.</para></li><li><para><c>customer-gateway-id</c> - The ID of a customer gateway associated with the VPN
        /// connection.</para></li><li><para><c>state</c> - The state of the VPN connection (<c>pending</c> | <c>available</c>
        /// | <c>deleting</c> | <c>deleted</c>).</para></li><li><para><c>option.static-routes-only</c> - Indicates whether the connection has static routes
        /// only. Used for devices that do not support Border Gateway Protocol (BGP).</para></li><li><para><c>route.destination-cidr-block</c> - The destination CIDR block. This corresponds
        /// to the subnet used in a customer data center.</para></li><li><para><c>bgp-asn</c> - The BGP Autonomous System Number (ASN) associated with a BGP device.</para></li><li><para><c>tag</c>:&lt;key&gt; - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><c>type</c> - The type of VPN connection. Currently the only supported type is <c>ipsec.1</c>.</para></li><li><para><c>vpn-connection-id</c> - The ID of the VPN connection.</para></li><li><para><c>vpn-gateway-id</c> - The ID of a virtual private gateway associated with the VPN
        /// connection.</para></li><li><para><c>transit-gateway-id</c> - The ID of a transit gateway associated with the VPN connection.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter VpnConnectionId
        /// <summary>
        /// <para>
        /// <para>One or more VPN connection IDs.</para><para>Default: Describes your VPN connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("VpnConnectionIds")]
        public System.String[] VpnConnectionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpnConnections'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeVpnConnectionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeVpnConnectionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpnConnections";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeVpnConnectionsResponse, GetEC2VpnConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.VpnConnectionId != null)
            {
                context.VpnConnectionId = new List<System.String>(this.VpnConnectionId);
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
            var request = new Amazon.EC2.Model.DescribeVpnConnectionsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.VpnConnectionId != null)
            {
                request.VpnConnectionIds = cmdletContext.VpnConnectionId;
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
        
        private Amazon.EC2.Model.DescribeVpnConnectionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeVpnConnectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeVpnConnections");
            try
            {
                #if DESKTOP
                return client.DescribeVpnConnections(request);
                #elif CORECLR
                return client.DescribeVpnConnectionsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> VpnConnectionId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeVpnConnectionsResponse, GetEC2VpnConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnections;
        }
        
    }
}
