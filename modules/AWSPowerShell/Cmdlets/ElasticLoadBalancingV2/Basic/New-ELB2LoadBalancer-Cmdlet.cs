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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Creates an Application Load Balancer or a Network Load Balancer.
    /// 
    ///  
    /// <para>
    /// When you create a load balancer, you can specify security groups, public subnets,
    /// IP address type, and tags. Otherwise, you could do so later using <a>SetSecurityGroups</a>,
    /// <a>SetSubnets</a>, <a>SetIpAddressType</a>, and <a>AddTags</a>.
    /// </para><para>
    /// To create listeners for your load balancer, use <a>CreateListener</a>. To describe
    /// your current load balancers, see <a>DescribeLoadBalancers</a>. When you are finished
    /// with a load balancer, you can delete it using <a>DeleteLoadBalancer</a>.
    /// </para><para>
    /// For limit information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-limits.html">Limits
    /// for Your Application Load Balancer</a> in the <i>Application Load Balancers Guide</i>
    /// and <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/load-balancer-limits.html">Limits
    /// for Your Network Load Balancer</a> in the <i>Network Load Balancers Guide</i>.
    /// </para><para>
    /// This operation is idempotent, which means that it completes at most one time. If you
    /// attempt to create multiple load balancers with the same settings, each call succeeds.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/application-load-balancers.html">Application
    /// Load Balancers</a> in the <i>Application Load Balancers Guide</i> and <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/network-load-balancers.html">Network
    /// Load Balancers</a> in the <i>Network Load Balancers Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELB2LoadBalancer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.LoadBalancer")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 CreateLoadBalancer API operation.", Operation = new[] {"CreateLoadBalancer"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.LoadBalancer or Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse",
        "This cmdlet returns a collection of Amazon.ElasticLoadBalancingV2.Model.LoadBalancer objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.CreateLoadBalancerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewELB2LoadBalancerCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>[Application Load Balancers] The type of IP addresses used by the subnets for your
        /// load balancer. The possible values are <code>ipv4</code> (for IPv4 addresses) and
        /// <code>dualstack</code> (for IPv4 and IPv6 addresses). Internal load balancers must
        /// use <code>ipv4</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.IpAddressType")]
        public Amazon.ElasticLoadBalancingV2.IpAddressType IpAddressType { get; set; }
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
        /// with access to the VPC for the load balancer.</para><para>The default is an Internet-facing load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum")]
        public Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum Scheme { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>[Application Load Balancers] The IDs of the security groups for the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SubnetMapping
        /// <summary>
        /// <para>
        /// <para>The IDs of the public subnets. You can specify only one subnet per Availability Zone.
        /// You must specify either subnets or subnet mappings.</para><para>[Application Load Balancers] You must specify subnets from at least two Availability
        /// Zones. You cannot specify Elastic IP addresses for your subnets.</para><para>[Network Load Balancers] You can specify subnets from one or more Availability Zones.
        /// You can specify one Elastic IP address per subnet if you need static IP addresses
        /// for your load balancer.</para>
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
        /// Zones.</para><para>[Network Load Balancers] You can specify subnets from one or more Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to assign to the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticLoadBalancingV2.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of load balancer. The default is <code>application</code>.</para>
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
            context.IpAddressType = this.IpAddressType;
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
            
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
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
                #if DESKTOP
                return client.CreateLoadBalancer(request);
                #elif CORECLR
                return client.CreateLoadBalancerAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ElasticLoadBalancingV2.IpAddressType IpAddressType { get; set; }
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
