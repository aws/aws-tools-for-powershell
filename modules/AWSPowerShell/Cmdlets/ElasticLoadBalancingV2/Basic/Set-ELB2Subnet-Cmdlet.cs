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
    /// Enables the Availability Zones for the specified public subnets for the specified
    /// Application Load Balancer, Network Load Balancer or Gateway Load Balancer. The specified
    /// subnets replace the previously enabled subnets.
    /// 
    ///  
    /// <para>
    /// When you specify subnets for a Network Load Balancer, or Gateway Load Balancer you
    /// must include all subnets that were enabled previously, with their existing configurations,
    /// plus any additional subnets.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "ELB2Subnet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.AvailabilityZone")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 SetSubnets API operation.", Operation = new[] {"SetSubnets"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.AvailabilityZone or Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.AvailabilityZone objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetELB2SubnetCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>The IP address type.</para><para>[Application Load Balancers] The possible values are <c>ipv4</c> (IPv4 addresses),
        /// <c>dualstack</c> (IPv4 and IPv6 addresses), and <c>dualstack-without-public-ipv4</c>
        /// (public IPv6 addresses and private IPv4 and IPv6 addresses).</para><para>[Network Load Balancers and Gateway Load Balancers] The possible values are <c>ipv4</c>
        /// (IPv4 addresses) and <c>dualstack</c> (IPv4 and IPv6 addresses).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.IpAddressType")]
        public Amazon.ElasticLoadBalancingV2.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter LoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the load balancer.</para>
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
        public System.String LoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter SubnetMapping
        /// <summary>
        /// <para>
        /// <para>The IDs of the public subnets. You can specify only one subnet per Availability Zone.
        /// You must specify either subnets or subnet mappings.</para><para>[Application Load Balancers] You must specify subnets from at least two Availability
        /// Zones. You can't specify Elastic IP addresses for your subnets.</para><para>[Application Load Balancers on Outposts] You must specify one Outpost subnet.</para><para>[Application Load Balancers on Local Zones] You can specify subnets from one or more
        /// Local Zones.</para><para>[Network Load Balancers] You can specify subnets from one or more Availability Zones.
        /// You can specify one Elastic IP address per subnet if you need static IP addresses
        /// for your internet-facing load balancer. For internal load balancers, you can specify
        /// one private IP address per subnet from the IPv4 range of the subnet. For internet-facing
        /// load balancer, you can specify one IPv6 address per subnet.</para><para>[Gateway Load Balancers] You can specify subnets from one or more Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetMappings")]
        public Amazon.ElasticLoadBalancingV2.Model.SubnetMapping[] SubnetMapping { get; set; }
        #endregion
        
        #region Parameter Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the public subnets. You can specify only one subnet per Availability Zone.
        /// You must specify either subnets or subnet mappings.</para><para>[Application Load Balancers] You must specify subnets from at least two Availability
        /// Zones.</para><para>[Application Load Balancers on Outposts] You must specify one Outpost subnet.</para><para>[Application Load Balancers on Local Zones] You can specify subnets from one or more
        /// Local Zones.</para><para>[Network Load Balancers and Gateway Load Balancers] You can specify subnets from one
        /// or more Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AvailabilityZones'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AvailabilityZones";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-ELB2Subnet (SetSubnets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse, SetELB2SubnetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EnablePrefixForIpv6SourceNat = this.EnablePrefixForIpv6SourceNat;
            context.IpAddressType = this.IpAddressType;
            context.LoadBalancerArn = this.LoadBalancerArn;
            #if MODULAR
            if (this.LoadBalancerArn == null && ParameterWasBound(nameof(this.LoadBalancerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubnetMapping != null)
            {
                context.SubnetMapping = new List<Amazon.ElasticLoadBalancingV2.Model.SubnetMapping>(this.SubnetMapping);
            }
            if (this.Subnet != null)
            {
                context.Subnet = new List<System.String>(this.Subnet);
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.SetSubnetsRequest();
            
            if (cmdletContext.EnablePrefixForIpv6SourceNat != null)
            {
                request.EnablePrefixForIpv6SourceNat = cmdletContext.EnablePrefixForIpv6SourceNat;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.LoadBalancerArn != null)
            {
                request.LoadBalancerArn = cmdletContext.LoadBalancerArn;
            }
            if (cmdletContext.SubnetMapping != null)
            {
                request.SubnetMappings = cmdletContext.SubnetMapping;
            }
            if (cmdletContext.Subnet != null)
            {
                request.Subnets = cmdletContext.Subnet;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.SetSubnetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "SetSubnets");
            try
            {
                return client.SetSubnetsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ElasticLoadBalancingV2.EnablePrefixForIpv6SourceNatEnum EnablePrefixForIpv6SourceNat { get; set; }
            public Amazon.ElasticLoadBalancingV2.IpAddressType IpAddressType { get; set; }
            public System.String LoadBalancerArn { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.SubnetMapping> SubnetMapping { get; set; }
            public List<System.String> Subnet { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.SetSubnetsResponse, SetELB2SubnetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AvailabilityZones;
        }
        
    }
}
