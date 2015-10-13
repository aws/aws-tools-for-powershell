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
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;

namespace Amazon.PowerShell.Cmdlets.ELB
{
    /// <summary>
    /// Creates a load balancer.
    /// 
    ///  
    /// <para>
    /// If the call completes successfully, a new load balancer is created with a unique Domain
    /// Name Service (DNS) name. The DNS name includes the name of the AWS region in which
    /// the load balancer was created. For example, the DNS name might end with either of
    /// the following:
    /// </para><ul><li><code>us-east-1.elb.amazonaws.com</code></li><li><code>us-west-2.elb.amazonaws.com</code></li></ul><para>
    /// For information about the AWS regions supported by Elastic Load Balancing, see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html#elb_region">Regions
    /// and Endpoints</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para><para>
    /// You can create up to 20 load balancers per region per account. You can request an
    /// increase for the number of load balancers for your account. For more information,
    /// see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/elb-limits.html">Elastic
    /// Load Balancing Limits</a> in the <i>Elastic Load Balancing Developer Guide</i>.
    /// </para><para>
    /// Elastic Load Balancing supports load balancing your EC2 instances launched in either
    /// the EC2-Classic or EC2-VPC platform. For more information, see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/UserScenariosForEC2.html">Elastic
    /// Load Balancing in EC2-Classic</a> or <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/UserScenariosForVPC.html">Elastic
    /// Load Balancing in a VPC</a> in the <i>Elastic Load Balancing Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ELBLoadBalancer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateLoadBalancer operation against Elastic Load Balancing.", Operation = new[] {"CreateLoadBalancer"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewELBLoadBalancerCmdlet : AmazonElasticLoadBalancingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more Availability Zones from the same region as the load balancer. Traffic
        /// is equally distributed across all specified Availability Zones.</para><para>You must specify at least one Availability Zone.</para><para>You can add more Availability Zones after you create the load balancer using <a>EnableAvailabilityZonesForLoadBalancer</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The listeners.</para><para>For more information, see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/elb-listener-config.html">Listener
        /// Configurations for Elastic Load Balancing</a> in the <i>Elastic Load Balancing Developer
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Listeners")]
        public Amazon.ElasticLoadBalancing.Model.Listener[] Listener { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the load balancer.</para><para>This name must be unique within your AWS account, must have a maximum of 32 characters,
        /// must contain only alphanumeric characters or hyphens, and cannot begin or end with
        /// a hyphen.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LoadBalancerName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of a load balancer. Valid only for load balancers in a VPC.</para><para>By default, Elastic Load Balancing creates an Internet-facing load balancer with a
        /// publicly resolvable DNS name, which resolves to public IP addresses. For more information
        /// about Internet-facing and Internal load balancers, see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/vpc-loadbalancer-types.html">Internet-facing
        /// and Internal Load Balancers</a> in the <i>Elastic Load Balancing Developer Guide</i>.</para><para>Specify <code>internal</code> to create an internal load balancer with a DNS name
        /// that resolves to private IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Scheme { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups to assign to the load balancer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets in your VPC to attach to the load balancer. Specify one subnet
        /// per Availability Zone specified in <code>AvailabilityZones</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of tags to assign to the load balancer.</para><para>For more information about tagging your load balancer, see <a href="http://docs.aws.amazon.com/ElasticLoadBalancing/latest/DeveloperGuide/TerminologyandKeyConcepts.html#tagging-elb">Tagging</a>
        /// in the <i>Elastic Load Balancing Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ElasticLoadBalancing.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("LoadBalancerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELBLoadBalancer (CreateLoadBalancer)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<System.String>(this.AvailabilityZone);
            }
            if (this.Listener != null)
            {
                context.Listeners = new List<Amazon.ElasticLoadBalancing.Model.Listener>(this.Listener);
            }
            context.LoadBalancerName = this.LoadBalancerName;
            context.Scheme = this.Scheme;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroups = new List<System.String>(this.SecurityGroup);
            }
            if (this.Subnet != null)
            {
                context.Subnets = new List<System.String>(this.Subnet);
            }
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ElasticLoadBalancing.Model.Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerRequest();
            
            if (cmdletContext.AvailabilityZones != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZones;
            }
            if (cmdletContext.Listeners != null)
            {
                request.Listeners = cmdletContext.Listeners;
            }
            if (cmdletContext.LoadBalancerName != null)
            {
                request.LoadBalancerName = cmdletContext.LoadBalancerName;
            }
            if (cmdletContext.Scheme != null)
            {
                request.Scheme = cmdletContext.Scheme;
            }
            if (cmdletContext.SecurityGroups != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroups;
            }
            if (cmdletContext.Subnets != null)
            {
                request.Subnets = cmdletContext.Subnets;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateLoadBalancer(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DNSName;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AvailabilityZones { get; set; }
            public List<Amazon.ElasticLoadBalancing.Model.Listener> Listeners { get; set; }
            public System.String LoadBalancerName { get; set; }
            public System.String Scheme { get; set; }
            public List<System.String> SecurityGroups { get; set; }
            public List<System.String> Subnets { get; set; }
            public List<Amazon.ElasticLoadBalancing.Model.Tag> Tags { get; set; }
        }
        
    }
}
