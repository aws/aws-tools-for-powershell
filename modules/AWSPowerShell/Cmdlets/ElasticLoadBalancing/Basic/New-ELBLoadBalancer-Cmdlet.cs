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
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;

namespace Amazon.PowerShell.Cmdlets.ELB
{
    /// <summary>
    /// Creates a Classic Load Balancer.
    /// 
    ///  
    /// <para>
    /// You can add listeners, security groups, subnets, and tags when you create your load
    /// balancer, or you can add them later using <a>CreateLoadBalancerListeners</a>, <a>ApplySecurityGroupsToLoadBalancer</a>,
    /// <a>AttachLoadBalancerToSubnets</a>, and <a>AddTags</a>.
    /// </para><para>
    /// To describe your current load balancers, see <a>DescribeLoadBalancers</a>. When you
    /// are finished with a load balancer, you can delete it using <a>DeleteLoadBalancer</a>.
    /// </para><para>
    /// You can create up to 20 load balancers per region per account. You can request an
    /// increase for the number of load balancers for your account. For more information,
    /// see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-limits.html">Limits
    /// for Your Classic Load Balancer</a> in the <i>Classic Load Balancers Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELBLoadBalancer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Elastic Load Balancing CreateLoadBalancer API operation.", Operation = new[] {"CreateLoadBalancer"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewELBLoadBalancerCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zones from the same region as the load balancer.</para><para>You must specify at least one Availability Zone.</para><para>You can add more Availability Zones after you create the load balancer using <a>EnableAvailabilityZonesForLoadBalancer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Listener
        /// <summary>
        /// <para>
        /// <para>The listeners.</para><para>For more information, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/elb-listener-config.html">Listeners
        /// for Your Classic Load Balancer</a> in the <i>Classic Load Balancers Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Listeners")]
        public Amazon.ElasticLoadBalancing.Model.Listener[] Listener { get; set; }
        #endregion
        
        #region Parameter LoadBalancerName
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para><para>This name must be unique within your set of load balancers for the region, must have
        /// a maximum of 32 characters, must contain only alphanumeric characters or hyphens,
        /// and cannot begin or end with a hyphen.</para>
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
        public System.String LoadBalancerName { get; set; }
        #endregion
        
        #region Parameter Scheme
        /// <summary>
        /// <para>
        /// <para>The type of a load balancer. Valid only for load balancers in a VPC.</para><para>By default, Elastic Load Balancing creates an Internet-facing load balancer with a
        /// DNS name that resolves to public IP addresses. For more information about Internet-facing
        /// and Internal load balancers, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/userguide/how-elastic-load-balancing-works.html#load-balancer-scheme">Load
        /// Balancer Scheme</a> in the <i>Elastic Load Balancing User Guide</i>.</para><para>Specify <c>internal</c> to create a load balancer with a DNS name that resolves to
        /// private IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Scheme { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups to assign to the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets in your VPC to attach to the load balancer. Specify one subnet
        /// per Availability Zone specified in <c>AvailabilityZones</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to assign to the load balancer.</para><para>For more information about tagging your load balancer, see <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/classic/add-remove-tags.html">Tag
        /// Your Classic Load Balancer</a> in the <i>Classic Load Balancers Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticLoadBalancing.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DNSName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DNSName";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoadBalancerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoadBalancerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELBLoadBalancer (CreateLoadBalancer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse, NewELBLoadBalancerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoadBalancerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            if (this.Listener != null)
            {
                context.Listener = new List<Amazon.ElasticLoadBalancing.Model.Listener>(this.Listener);
            }
            #if MODULAR
            if (this.Listener == null && ParameterWasBound(nameof(this.Listener)))
            {
                WriteWarning("You are passing $null as a value for parameter Listener which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoadBalancerName = this.LoadBalancerName;
            #if MODULAR
            if (this.LoadBalancerName == null && ParameterWasBound(nameof(this.LoadBalancerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scheme = this.Scheme;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
            }
            if (this.Subnet != null)
            {
                context.Subnet = new List<System.String>(this.Subnet);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticLoadBalancing.Model.Tag>(this.Tag);
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
            var request = new Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.Listener != null)
            {
                request.Listeners = cmdletContext.Listener;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
            }
            if (cmdletContext.Scheme != null)
            {
                request.Scheme = cmdletContext.Scheme;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
            }
            if (cmdletContext.Subnet != null)
            {
                request.Subnets = cmdletContext.Subnet;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse CallAWSServiceOperation(IAmazonElasticLoadBalancing client, Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing", "CreateLoadBalancer");
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
            public List<System.String> AvailabilityZone { get; set; }
            public List<Amazon.ElasticLoadBalancing.Model.Listener> Listener { get; set; }
            public System.String LoadBalancerName { get; set; }
            public System.String Scheme { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public List<System.String> Subnet { get; set; }
            public List<Amazon.ElasticLoadBalancing.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse, NewELBLoadBalancerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DNSName;
        }
        
    }
}
