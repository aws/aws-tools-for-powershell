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
    /// Modifies a subnet attribute. You can only modify one attribute at a time.
    /// 
    ///  
    /// <para>
    /// Use this action to modify subnets on Amazon Web Services Outposts.
    /// </para><ul><li><para>
    /// To modify a subnet on an Outpost rack, set both <c>MapCustomerOwnedIpOnLaunch</c>
    /// and <c>CustomerOwnedIpv4Pool</c>. These two parameters act as a single attribute.
    /// </para></li><li><para>
    /// To modify a subnet on an Outpost server, set either <c>EnableLniAtDeviceIndex</c>
    /// or <c>DisableLniAtDeviceIndex</c>.
    /// </para></li></ul><para>
    /// For more information about Amazon Web Services Outposts, see the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/outposts/latest/userguide/how-servers-work.html">Outpost
    /// servers</a></para></li><li><para><a href="https://docs.aws.amazon.com/outposts/latest/userguide/how-racks-work.html">Outpost
    /// racks</a></para></li></ul>
    /// </summary>
    [Cmdlet("Edit", "EC2SubnetAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifySubnetAttribute API operation.", Operation = new[] {"ModifySubnetAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifySubnetAttributeResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifySubnetAttributeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifySubnetAttributeResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditEC2SubnetAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssignIpv6AddressOnCreation
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to indicate that network interfaces created in the specified subnet
        /// should be assigned an IPv6 address. This includes a network interface that's created
        /// when launching an instance into the subnet (the instance therefore receives an IPv6
        /// address). </para><para>If you enable the IPv6 addressing feature for your subnet, your network interface
        /// or instance only receives an IPv6 address if it's created using version <c>2016-11-15</c>
        /// or later of the Amazon EC2 API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssignIpv6AddressOnCreation { get; set; }
        #endregion
        
        #region Parameter CustomerOwnedIpv4Pool
        /// <summary>
        /// <para>
        /// <para>The customer-owned IPv4 address pool associated with the subnet.</para><para>You must set this value when you specify <c>true</c> for <c>MapCustomerOwnedIpOnLaunch</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerOwnedIpv4Pool { get; set; }
        #endregion
        
        #region Parameter DisableLniAtDeviceIndex
        /// <summary>
        /// <para>
        /// <para> Specify <c>true</c> to indicate that local network interfaces at the current position
        /// should be disabled. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableLniAtDeviceIndex { get; set; }
        #endregion
        
        #region Parameter EnableDns64
        /// <summary>
        /// <para>
        /// <para>Indicates whether DNS queries made to the Amazon-provided DNS Resolver in this subnet
        /// should return synthetic IPv6 addresses for IPv4-only destinations.</para><para>You must first configure a NAT gateway in a public subnet (separate from the subnet
        /// containing the IPv6-only workloads). For example, the subnet containing the NAT gateway
        /// should have a <c>0.0.0.0/0</c> route pointing to the internet gateway. For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/nat-gateway-nat64-dns64.html#nat-gateway-nat64-dns64-walkthrough">Configure
        /// DNS64 and NAT64</a> in the <i>Amazon VPC User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableDns64 { get; set; }
        #endregion
        
        #region Parameter EnableLniAtDeviceIndex
        /// <summary>
        /// <para>
        /// <para> Indicates the device position for local network interfaces in this subnet. For example,
        /// <c>1</c> indicates local network interfaces in this subnet are the secondary network
        /// interface (eth1). A local network interface cannot be the primary network interface
        /// (eth0). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EnableLniAtDeviceIndex { get; set; }
        #endregion
        
        #region Parameter EnableResourceNameDnsAAAARecordOnLaunch
        /// <summary>
        /// <para>
        /// <para>Indicates whether to respond to DNS queries for instance hostnames with DNS AAAA records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableResourceNameDnsAAAARecordOnLaunch { get; set; }
        #endregion
        
        #region Parameter EnableResourceNameDnsARecordOnLaunch
        /// <summary>
        /// <para>
        /// <para>Indicates whether to respond to DNS queries for instance hostnames with DNS A records.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableResourceNameDnsARecordOnLaunch { get; set; }
        #endregion
        
        #region Parameter MapCustomerOwnedIpOnLaunch
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to indicate that network interfaces attached to instances created
        /// in the specified subnet should be assigned a customer-owned IPv4 address.</para><para>When this value is <c>true</c>, you must specify the customer-owned IP pool using
        /// <c>CustomerOwnedIpv4Pool</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MapCustomerOwnedIpOnLaunch { get; set; }
        #endregion
        
        #region Parameter MapPublicIpOnLaunch
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to indicate that network interfaces attached to instances created
        /// in the specified subnet should be assigned a public IPv4 address.</para><para>Amazon Web Services charges for all public IPv4 addresses, including public IPv4 addresses
        /// associated with running instances and Elastic IP addresses. For more information,
        /// see the <i>Public IPv4 Address</i> tab on the <a href="http://aws.amazon.com/vpc/pricing/">Amazon
        /// VPC pricing page</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MapPublicIpOnLaunch { get; set; }
        #endregion
        
        #region Parameter PrivateDnsHostnameTypeOnLaunch
        /// <summary>
        /// <para>
        /// <para>The type of hostname to assign to instances in the subnet at launch. For IPv4-only
        /// and dual-stack (IPv4 and IPv6) subnets, an instance DNS name can be based on the instance
        /// IPv4 address (ip-name) or the instance ID (resource-name). For IPv6 only subnets,
        /// an instance DNS name must be based on the instance ID (resource-name).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.HostnameType")]
        public Amazon.EC2.HostnameType PrivateDnsHostnameTypeOnLaunch { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet.</para>
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
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifySubnetAttributeResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubnetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2SubnetAttribute (ModifySubnetAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifySubnetAttributeResponse, EditEC2SubnetAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssignIpv6AddressOnCreation = this.AssignIpv6AddressOnCreation;
            context.CustomerOwnedIpv4Pool = this.CustomerOwnedIpv4Pool;
            context.DisableLniAtDeviceIndex = this.DisableLniAtDeviceIndex;
            context.EnableDns64 = this.EnableDns64;
            context.EnableLniAtDeviceIndex = this.EnableLniAtDeviceIndex;
            context.EnableResourceNameDnsAAAARecordOnLaunch = this.EnableResourceNameDnsAAAARecordOnLaunch;
            context.EnableResourceNameDnsARecordOnLaunch = this.EnableResourceNameDnsARecordOnLaunch;
            context.MapCustomerOwnedIpOnLaunch = this.MapCustomerOwnedIpOnLaunch;
            context.MapPublicIpOnLaunch = this.MapPublicIpOnLaunch;
            context.PrivateDnsHostnameTypeOnLaunch = this.PrivateDnsHostnameTypeOnLaunch;
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.EC2.Model.ModifySubnetAttributeRequest();
            
            if (cmdletContext.AssignIpv6AddressOnCreation != null)
            {
                request.AssignIpv6AddressOnCreation = cmdletContext.AssignIpv6AddressOnCreation.Value;
            }
            if (cmdletContext.CustomerOwnedIpv4Pool != null)
            {
                request.CustomerOwnedIpv4Pool = cmdletContext.CustomerOwnedIpv4Pool;
            }
            if (cmdletContext.DisableLniAtDeviceIndex != null)
            {
                request.DisableLniAtDeviceIndex = cmdletContext.DisableLniAtDeviceIndex.Value;
            }
            if (cmdletContext.EnableDns64 != null)
            {
                request.EnableDns64 = cmdletContext.EnableDns64.Value;
            }
            if (cmdletContext.EnableLniAtDeviceIndex != null)
            {
                request.EnableLniAtDeviceIndex = cmdletContext.EnableLniAtDeviceIndex.Value;
            }
            if (cmdletContext.EnableResourceNameDnsAAAARecordOnLaunch != null)
            {
                request.EnableResourceNameDnsAAAARecordOnLaunch = cmdletContext.EnableResourceNameDnsAAAARecordOnLaunch.Value;
            }
            if (cmdletContext.EnableResourceNameDnsARecordOnLaunch != null)
            {
                request.EnableResourceNameDnsARecordOnLaunch = cmdletContext.EnableResourceNameDnsARecordOnLaunch.Value;
            }
            if (cmdletContext.MapCustomerOwnedIpOnLaunch != null)
            {
                request.MapCustomerOwnedIpOnLaunch = cmdletContext.MapCustomerOwnedIpOnLaunch.Value;
            }
            if (cmdletContext.MapPublicIpOnLaunch != null)
            {
                request.MapPublicIpOnLaunch = cmdletContext.MapPublicIpOnLaunch.Value;
            }
            if (cmdletContext.PrivateDnsHostnameTypeOnLaunch != null)
            {
                request.PrivateDnsHostnameTypeOnLaunch = cmdletContext.PrivateDnsHostnameTypeOnLaunch;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
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
        
        private Amazon.EC2.Model.ModifySubnetAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifySubnetAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifySubnetAttribute");
            try
            {
                return client.ModifySubnetAttributeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AssignIpv6AddressOnCreation { get; set; }
            public System.String CustomerOwnedIpv4Pool { get; set; }
            public System.Boolean? DisableLniAtDeviceIndex { get; set; }
            public System.Boolean? EnableDns64 { get; set; }
            public System.Int32? EnableLniAtDeviceIndex { get; set; }
            public System.Boolean? EnableResourceNameDnsAAAARecordOnLaunch { get; set; }
            public System.Boolean? EnableResourceNameDnsARecordOnLaunch { get; set; }
            public System.Boolean? MapCustomerOwnedIpOnLaunch { get; set; }
            public System.Boolean? MapPublicIpOnLaunch { get; set; }
            public Amazon.EC2.HostnameType PrivateDnsHostnameTypeOnLaunch { get; set; }
            public System.String SubnetId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifySubnetAttributeResponse, EditEC2SubnetAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
