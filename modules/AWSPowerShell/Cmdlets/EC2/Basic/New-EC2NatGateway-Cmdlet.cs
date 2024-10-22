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
    /// Creates a NAT gateway in the specified subnet. This action creates a network interface
    /// in the specified subnet with a private IP address from the IP address range of the
    /// subnet. You can create either a public NAT gateway or a private NAT gateway.
    /// 
    ///  
    /// <para>
    /// With a public NAT gateway, internet-bound traffic from a private subnet can be routed
    /// to the NAT gateway, so that instances in a private subnet can connect to the internet.
    /// </para><para>
    /// With a private NAT gateway, private communication is routed across VPCs and on-premises
    /// networks through a transit gateway or virtual private gateway. Common use cases include
    /// running large workloads behind a small pool of allowlisted IPv4 addresses, preserving
    /// private IPv4 addresses, and communicating between overlapping networks.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-nat-gateway.html">NAT
    /// gateways</a> in the <i>Amazon VPC User Guide</i>.
    /// </para><important><para>
    /// When you create a public NAT gateway and assign it an EIP or secondary EIPs, the network
    /// border group of the EIPs must match the network border group of the Availability Zone
    /// (AZ) that the public NAT gateway is in. If it's not the same, the NAT gateway will
    /// fail to launch. You can see the network border group for the subnet's AZ by viewing
    /// the details of the subnet. Similarly, you can view the network border group of an
    /// EIP by viewing the details of the EIP address. For more information about network
    /// border groups and EIPs, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-eips.html#allocate-eip">Allocate
    /// an Elastic IP address</a> in the <i>Amazon VPC User Guide</i>. 
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "EC2NatGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateNatGatewayResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateNatGateway API operation.", Operation = new[] {"CreateNatGateway"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateNatGatewayResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateNatGatewayResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateNatGatewayResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2NatGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocationId
        /// <summary>
        /// <para>
        /// <para>[Public NAT gateways only] The allocation ID of an Elastic IP address to associate
        /// with the NAT gateway. You cannot specify an Elastic IP address with a private NAT
        /// gateway. If the Elastic IP address is associated with another resource, you must first
        /// disassociate it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AllocationId { get; set; }
        #endregion
        
        #region Parameter ConnectivityType
        /// <summary>
        /// <para>
        /// <para>Indicates whether the NAT gateway supports public or private connectivity. The default
        /// is public connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.ConnectivityType")]
        public Amazon.EC2.ConnectivityType ConnectivityType { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>The private IPv4 address to assign to the NAT gateway. If you don't provide an address,
        /// a private IPv4 address will be automatically assigned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter SecondaryAllocationId
        /// <summary>
        /// <para>
        /// <para>Secondary EIP allocation IDs. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-nat-gateway.html#nat-gateway-creating">Create
        /// a NAT gateway</a> in the <i>Amazon VPC User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondaryAllocationIds")]
        public System.String[] SecondaryAllocationId { get; set; }
        #endregion
        
        #region Parameter SecondaryPrivateIpAddressCount
        /// <summary>
        /// <para>
        /// <para>[Private NAT gateway only] The number of secondary private IPv4 addresses you want
        /// to assign to the NAT gateway. For more information about secondary addresses, see
        /// <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-nat-gateway.html#nat-gateway-creating">Create
        /// a NAT gateway</a> in the <i>Amazon VPC User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
        #endregion
        
        #region Parameter SecondaryPrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>Secondary private IPv4 addresses. For more information about secondary addresses,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-nat-gateway.html#nat-gateway-creating">Create
        /// a NAT gateway</a> in the <i>Amazon VPC User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondaryPrivateIpAddresses")]
        public System.String[] SecondaryPrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet in which to create the NAT gateway.</para>
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
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the NAT gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency</a>.</para><para>Constraint: Maximum 64 ASCII characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateNatGatewayResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateNatGatewayResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubnetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NatGateway (CreateNatGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateNatGatewayResponse, NewEC2NatGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllocationId = this.AllocationId;
            context.ClientToken = this.ClientToken;
            context.ConnectivityType = this.ConnectivityType;
            context.PrivateIpAddress = this.PrivateIpAddress;
            if (this.SecondaryAllocationId != null)
            {
                context.SecondaryAllocationId = new List<System.String>(this.SecondaryAllocationId);
            }
            context.SecondaryPrivateIpAddressCount = this.SecondaryPrivateIpAddressCount;
            if (this.SecondaryPrivateIpAddress != null)
            {
                context.SecondaryPrivateIpAddress = new List<System.String>(this.SecondaryPrivateIpAddress);
            }
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateNatGatewayRequest();
            
            if (cmdletContext.AllocationId != null)
            {
                request.AllocationId = cmdletContext.AllocationId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectivityType != null)
            {
                request.ConnectivityType = cmdletContext.ConnectivityType;
            }
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddress = cmdletContext.PrivateIpAddress;
            }
            if (cmdletContext.SecondaryAllocationId != null)
            {
                request.SecondaryAllocationIds = cmdletContext.SecondaryAllocationId;
            }
            if (cmdletContext.SecondaryPrivateIpAddressCount != null)
            {
                request.SecondaryPrivateIpAddressCount = cmdletContext.SecondaryPrivateIpAddressCount.Value;
            }
            if (cmdletContext.SecondaryPrivateIpAddress != null)
            {
                request.SecondaryPrivateIpAddresses = cmdletContext.SecondaryPrivateIpAddress;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateNatGatewayResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNatGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateNatGateway");
            try
            {
                #if DESKTOP
                return client.CreateNatGateway(request);
                #elif CORECLR
                return client.CreateNatGatewayAsync(request).GetAwaiter().GetResult();
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
            public System.String AllocationId { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.EC2.ConnectivityType ConnectivityType { get; set; }
            public System.String PrivateIpAddress { get; set; }
            public List<System.String> SecondaryAllocationId { get; set; }
            public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
            public List<System.String> SecondaryPrivateIpAddress { get; set; }
            public System.String SubnetId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateNatGatewayResponse, NewEC2NatGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
