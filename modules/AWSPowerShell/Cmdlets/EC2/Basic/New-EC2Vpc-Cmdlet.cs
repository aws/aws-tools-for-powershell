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
    /// Creates a VPC with the specified CIDR blocks. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-ip-addressing.html">IP
    /// addressing for your VPCs and subnets</a> in the <i>Amazon VPC User Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can optionally request an IPv6 CIDR block for the VPC. You can request an Amazon-provided
    /// IPv6 CIDR block from Amazon's pool of IPv6 addresses or an IPv6 CIDR block from an
    /// IPv6 address pool that you provisioned through bring your own IP addresses (<a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-byoip.html">BYOIP</a>).
    /// </para><para>
    /// By default, each instance that you launch in the VPC has the default DHCP options,
    /// which include only a default DNS server that we provide (AmazonProvidedDNS). For more
    /// information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_DHCP_Options.html">DHCP
    /// option sets</a> in the <i>Amazon VPC User Guide</i>.
    /// </para><para>
    /// You can specify the instance tenancy value for the VPC when you create it. You can't
    /// change this value for the VPC after you create it. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-instance.html">Dedicated
    /// Instances</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Vpc", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Vpc")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateVpc API operation.", Operation = new[] {"CreateVpc"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateVpcResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Vpc or Amazon.EC2.Model.CreateVpcResponse",
        "This cmdlet returns an Amazon.EC2.Model.Vpc object.",
        "The service call response (type Amazon.EC2.Model.CreateVpcResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2VpcCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmazonProvidedIpv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>Requests an Amazon-provided IPv6 CIDR block with a /56 prefix length for the VPC.
        /// You cannot specify the range of IP addresses, or the size of the CIDR block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AmazonProvidedIpv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 network range for the VPC, in CIDR notation. For example, <c>10.0.0.0/16</c>.
        /// We modify the specified CIDR block to its canonical form; for example, if you specify
        /// <c>100.68.0.18/18</c>, we modify it to <c>100.68.0.0/18</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CidrBlock { get; set; }
        #endregion
        
        #region Parameter InstanceTenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy options for instances launched into the VPC. For <c>default</c>, instances
        /// are launched with shared tenancy by default. You can launch instances with any tenancy
        /// into a shared tenancy VPC. For <c>dedicated</c>, instances are launched as dedicated
        /// tenancy instances by default. You can only launch instances with a tenancy of <c>dedicated</c>
        /// or <c>host</c> into a dedicated tenancy VPC. </para><para><b>Important:</b> The <c>host</c> value cannot be used with this parameter. Use the
        /// <c>default</c> or <c>dedicated</c> values only.</para><para>Default: <c>default</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.Tenancy")]
        public Amazon.EC2.Tenancy InstanceTenancy { get; set; }
        #endregion
        
        #region Parameter Ipv4IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of an IPv4 IPAM pool you want to use for allocating this VPC's CIDR. For more
        /// information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv4IpamPoolId { get; set; }
        #endregion
        
        #region Parameter Ipv4NetmaskLength
        /// <summary>
        /// <para>
        /// <para>The netmask length of the IPv4 CIDR you want to allocate to this VPC from an Amazon
        /// VPC IP Address Manager (IPAM) pool. For more information about IPAM, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv4NetmaskLength { get; set; }
        #endregion
        
        #region Parameter Ipv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv6 CIDR block from the IPv6 address pool. You must also specify <c>Ipv6Pool</c>
        /// in the request.</para><para>To let Amazon choose the IPv6 CIDR block for you, omit this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter Ipv6CidrBlockNetworkBorderGroup
        /// <summary>
        /// <para>
        /// <para>The name of the location from which we advertise the IPV6 CIDR block. Use this parameter
        /// to limit the address to this location.</para><para> You must set <c>AmazonProvidedIpv6CidrBlock</c> to <c>true</c> to use this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6CidrBlockNetworkBorderGroup { get; set; }
        #endregion
        
        #region Parameter Ipv6IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of an IPv6 IPAM pool which will be used to allocate this VPC an IPv6 CIDR.
        /// IPAM is a VPC feature that you can use to automate your IP address management workflows
        /// including assigning, tracking, troubleshooting, and auditing IP addresses across Amazon
        /// Web Services Regions and accounts throughout your Amazon Web Services Organization.
        /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6IpamPoolId { get; set; }
        #endregion
        
        #region Parameter Ipv6NetmaskLength
        /// <summary>
        /// <para>
        /// <para>The netmask length of the IPv6 CIDR you want to allocate to this VPC from an Amazon
        /// VPC IP Address Manager (IPAM) pool. For more information about IPAM, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv6NetmaskLength { get; set; }
        #endregion
        
        #region Parameter Ipv6Pool
        /// <summary>
        /// <para>
        /// <para>The ID of an IPv6 address pool from which to allocate the IPv6 CIDR block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6Pool { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Vpc'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateVpcResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateVpcResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Vpc";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CidrBlock parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CidrBlock' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CidrBlock' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CidrBlock), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Vpc (CreateVpc)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateVpcResponse, NewEC2VpcCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CidrBlock;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AmazonProvidedIpv6CidrBlock = this.AmazonProvidedIpv6CidrBlock;
            context.CidrBlock = this.CidrBlock;
            context.InstanceTenancy = this.InstanceTenancy;
            context.Ipv4IpamPoolId = this.Ipv4IpamPoolId;
            context.Ipv4NetmaskLength = this.Ipv4NetmaskLength;
            context.Ipv6CidrBlock = this.Ipv6CidrBlock;
            context.Ipv6CidrBlockNetworkBorderGroup = this.Ipv6CidrBlockNetworkBorderGroup;
            context.Ipv6IpamPoolId = this.Ipv6IpamPoolId;
            context.Ipv6NetmaskLength = this.Ipv6NetmaskLength;
            context.Ipv6Pool = this.Ipv6Pool;
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
            var request = new Amazon.EC2.Model.CreateVpcRequest();
            
            if (cmdletContext.AmazonProvidedIpv6CidrBlock != null)
            {
                request.AmazonProvidedIpv6CidrBlock = cmdletContext.AmazonProvidedIpv6CidrBlock.Value;
            }
            if (cmdletContext.CidrBlock != null)
            {
                request.CidrBlock = cmdletContext.CidrBlock;
            }
            if (cmdletContext.InstanceTenancy != null)
            {
                request.InstanceTenancy = cmdletContext.InstanceTenancy;
            }
            if (cmdletContext.Ipv4IpamPoolId != null)
            {
                request.Ipv4IpamPoolId = cmdletContext.Ipv4IpamPoolId;
            }
            if (cmdletContext.Ipv4NetmaskLength != null)
            {
                request.Ipv4NetmaskLength = cmdletContext.Ipv4NetmaskLength.Value;
            }
            if (cmdletContext.Ipv6CidrBlock != null)
            {
                request.Ipv6CidrBlock = cmdletContext.Ipv6CidrBlock;
            }
            if (cmdletContext.Ipv6CidrBlockNetworkBorderGroup != null)
            {
                request.Ipv6CidrBlockNetworkBorderGroup = cmdletContext.Ipv6CidrBlockNetworkBorderGroup;
            }
            if (cmdletContext.Ipv6IpamPoolId != null)
            {
                request.Ipv6IpamPoolId = cmdletContext.Ipv6IpamPoolId;
            }
            if (cmdletContext.Ipv6NetmaskLength != null)
            {
                request.Ipv6NetmaskLength = cmdletContext.Ipv6NetmaskLength.Value;
            }
            if (cmdletContext.Ipv6Pool != null)
            {
                request.Ipv6Pool = cmdletContext.Ipv6Pool;
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
        
        private Amazon.EC2.Model.CreateVpcResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateVpc");
            try
            {
                #if DESKTOP
                return client.CreateVpc(request);
                #elif CORECLR
                return client.CreateVpcAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AmazonProvidedIpv6CidrBlock { get; set; }
            public System.String CidrBlock { get; set; }
            public Amazon.EC2.Tenancy InstanceTenancy { get; set; }
            public System.String Ipv4IpamPoolId { get; set; }
            public System.Int32? Ipv4NetmaskLength { get; set; }
            public System.String Ipv6CidrBlock { get; set; }
            public System.String Ipv6CidrBlockNetworkBorderGroup { get; set; }
            public System.String Ipv6IpamPoolId { get; set; }
            public System.Int32? Ipv6NetmaskLength { get; set; }
            public System.String Ipv6Pool { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateVpcResponse, NewEC2VpcCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Vpc;
        }
        
    }
}
