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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Creates an Application Load Balancer, Network Load Balancer, or Gateway Load Balancer.
    /// 
    ///  
    /// <para>
    /// For more information, see the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/application-load-balancers.html">Application
    /// Load Balancers</a></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/network-load-balancers.html">Network
    /// Load Balancers</a></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/gateway/gateway-load-balancers.html">Gateway
    /// Load Balancers</a></para></li></ul><para>
    /// This operation is idempotent, which means that it completes at most one time. If you
    /// attempt to create multiple load balancers with the same settings, each call succeeds.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELB2LoadBalancer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.LoadBalancer")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 CreateLoadBalancer API operation.", Operation = new[] {"CreateLoadBalancer"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.LoadBalancer or Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.LoadBalancer objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewELB2LoadBalancerCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomerOwnedIpv4Pool
        /// <summary>
        /// <para>
        /// <para>[Application Load Balancers on Outposts] The ID of the customer-owned address pool
        /// (CoIP pool).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerOwnedIpv4Pool { get; set; }
        #endregion
        
        #region Parameter EnablePrefixForIpv6SourceNat
        /// <summary>
        /// <para>
        /// <para>[Network Load Balancers with UDP listeners] Indicates whether to use an IPv6 prefix
        /// from each subnet for source NAT. The IP address type must be <c>dualstack</c>. The
        /// default value is <c>off</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.EnablePrefixForIpv6SourceNatEnum")]
        public Amazon.ElasticLoadBalancingV2.EnablePrefixForIpv6SourceNatEnum EnablePrefixForIpv6SourceNat { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type. Internal load balancers must use <c>ipv4</c>.</para><para>[Application Load Balancers] The possible values are <c>ipv4</c> (IPv4 addresses),
        /// <c>dualstack</c> (IPv4 and IPv6 addresses), and <c>dualstack-without-public-ipv4</c>
        /// (public IPv6 addresses and private IPv4 and IPv6 addresses).</para><para>[Network Load Balancers and Gateway Load Balancers] The possible values are <c>ipv4</c>
        /// (IPv4 addresses) and <c>dualstack</c> (IPv4 and IPv6 addresses).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.IpAddressType")]
        public Amazon.ElasticLoadBalancingV2.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter IpamPools_Ipv4IpamPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the IPv4 IPAM pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IpamPools_Ipv4IpamPoolId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para><para>This name must be unique per region per account, can have a maximum of 32 characters,
        /// must contain only alphanumeric characters or hyphens, must not begin or end with a
        /// hyphen, and must not begin with "internal-".</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Scheme
        /// <summary>
        /// <para>
        /// <para>The nodes of an Internet-facing load balancer have public IP addresses. The DNS name
        /// of an Internet-facing load balancer is publicly resolvable to the public IP addresses
        /// of the nodes. Therefore, Internet-facing load balancers can route requests from clients
        /// over the internet.</para><para>The nodes of an internal load balancer have only private IP addresses. The DNS name
        /// of an internal load balancer is publicly resolvable to the private IP addresses of
        /// the nodes. Therefore, internal load balancers can route requests only from clients
        /// with access to the VPC for the load balancer.</para><para>The default is an Internet-facing load balancer.</para><para>You can't specify a scheme for a Gateway Load Balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum")]
        public Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum Scheme { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>[Application Load Balancers and Network Load Balancers] The IDs of the security groups
        /// for the load balancer.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SubnetMapping
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets. You can specify only one subnet per Availability Zone. You
        /// must specify either subnets or subnet mappings, but not both.</para><para>[Application Load Balancers] You must specify subnets from at least two Availability
        /// Zones. You can't specify Elastic IP addresses for your subnets.</para><para>[Application Load Balancers on Outposts] You must specify one Outpost subnet.</para><para>[Application Load Balancers on Local Zones] You can specify subnets from one or more
        /// Local Zones.</para><para>[Network Load Balancers] You can specify subnets from one or more Availability Zones.
        /// You can specify one Elastic IP address per subnet if you need static IP addresses
        /// for your internet-facing load balancer. For internal load balancers, you can specify
        /// one private IP address per subnet from the IPv4 range of the subnet. For internet-facing
        /// load balancer, you can specify one IPv6 address per subnet.</para><para>[Gateway Load Balancers] You can specify subnets from one or more Availability Zones.
        /// You can't specify Elastic IP addresses for your subnets.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetMappings")]
        public Amazon.ElasticLoadBalancingV2.Model.SubnetMapping[] SubnetMapping { get; set; }
        #endregion
        
        #region Parameter Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets. You can specify only one subnet per Availability Zone. You
        /// must specify either subnets or subnet mappings, but not both. To specify an Elastic
        /// IP address, specify subnet mappings instead of subnets.</para><para>[Application Load Balancers] You must specify subnets from at least two Availability
        /// Zones.</para><para>[Application Load Balancers on Outposts] You must specify one Outpost subnet.</para><para>[Application Load Balancers on Local Zones] You can specify subnets from one or more
        /// Local Zones.</para><para>[Network Load Balancers and Gateway Load Balancers] You can specify subnets from one
        /// or more Availability Zones.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the load balancer.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticLoadBalancingV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of load balancer. The default is <c>application</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.LoadBalancerTypeEnum")]
        public Amazon.ElasticLoadBalancingV2.LoadBalancerTypeEnum Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoadBalancers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoadBalancers";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELB2LoadBalancer (CreateLoadBalancer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse, NewELB2LoadBalancerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CustomerOwnedIpv4Pool = this.CustomerOwnedIpv4Pool;
            context.EnablePrefixForIpv6SourceNat = this.EnablePrefixForIpv6SourceNat;
            context.IpAddressType = this.IpAddressType;
            context.IpamPools_Ipv4IpamPoolId = this.IpamPools_Ipv4IpamPoolId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scheme = this.Scheme;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
            }
            if (this.SubnetMapping != null)
            {
                context.SubnetMapping = new List<Amazon.ElasticLoadBalancingV2.Model.SubnetMapping>(this.SubnetMapping);
            }
            if (this.Subnet != null)
            {
                context.Subnet = new List<System.String>(this.Subnet);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticLoadBalancingV2.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerRequest();
            
            if (cmdletContext.CustomerOwnedIpv4Pool != null)
            {
                request.CustomerOwnedIpv4Pool = cmdletContext.CustomerOwnedIpv4Pool;
            }
            if (cmdletContext.EnablePrefixForIpv6SourceNat != null)
            {
                request.EnablePrefixForIpv6SourceNat = cmdletContext.EnablePrefixForIpv6SourceNat;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            
             // populate IpamPools
            var requestIpamPoolsIsNull = true;
            request.IpamPools = new Amazon.ElasticLoadBalancingV2.Model.IpamPools();
            System.String requestIpamPools_ipamPools_Ipv4IpamPoolId = null;
            if (cmdletContext.IpamPools_Ipv4IpamPoolId != null)
            {
                requestIpamPools_ipamPools_Ipv4IpamPoolId = cmdletContext.IpamPools_Ipv4IpamPoolId;
            }
            if (requestIpamPools_ipamPools_Ipv4IpamPoolId != null)
            {
                request.IpamPools.Ipv4IpamPoolId = requestIpamPools_ipamPools_Ipv4IpamPoolId;
                requestIpamPoolsIsNull = false;
            }
             // determine if request.IpamPools should be set to null
            if (requestIpamPoolsIsNull)
            {
                request.IpamPools = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Scheme != null)
            {
                request.Scheme = cmdletContext.Scheme;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
            }
            if (cmdletContext.SubnetMapping != null)
            {
                request.SubnetMappings = cmdletContext.SubnetMapping;
            }
            if (cmdletContext.Subnet != null)
            {
                request.Subnets = cmdletContext.Subnet;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "CreateLoadBalancer");
            try
            {
                return client.CreateLoadBalancerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CustomerOwnedIpv4Pool { get; set; }
            public Amazon.ElasticLoadBalancingV2.EnablePrefixForIpv6SourceNatEnum EnablePrefixForIpv6SourceNat { get; set; }
            public Amazon.ElasticLoadBalancingV2.IpAddressType IpAddressType { get; set; }
            public System.String IpamPools_Ipv4IpamPoolId { get; set; }
            public System.String Name { get; set; }
            public Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum Scheme { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.SubnetMapping> SubnetMapping { get; set; }
            public List<System.String> Subnet { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.Tag> Tag { get; set; }
            public Amazon.ElasticLoadBalancingV2.LoadBalancerTypeEnum Type { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse, NewELB2LoadBalancerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoadBalancers;
        }
        
    }
}
