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
    /// Creates a subnet in an existing VPC.
    /// 
    ///  
    /// <para>
    /// When you create each subnet, you provide the VPC ID and the CIDR block you want for
    /// the subnet. After you create a subnet, you can't change its CIDR block. The subnet's
    /// CIDR block can be the same as the VPC's CIDR block (assuming you want only a single
    /// subnet in the VPC), or a subset of the VPC's CIDR block. If you create more than one
    /// subnet in a VPC, the subnets' CIDR blocks must not overlap. The smallest subnet (and
    /// VPC) you can create uses a /28 netmask (16 IP addresses), and the largest uses a /16
    /// netmask (65,536 IP addresses).
    /// </para><important><para>
    /// AWS reserves both the first four and the last IP address in each subnet's CIDR block.
    /// They're not available for use.
    /// </para></important><para>
    /// If you add more than one subnet to a VPC, they're set up in a star topology with a
    /// logical router in the middle.
    /// </para><para>
    /// If you launch an instance in a VPC using an Amazon EBS-backed AMI, the IP address
    /// doesn't change if you stop and restart the instance (unlike a similar instance launched
    /// outside a VPC, which gets a new IP address when restarted). It's therefore possible
    /// to have a subnet with no running instances (they're all stopped), but no remaining
    /// IP addresses available.
    /// </para><para>
    /// For more information about subnets, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_Subnets.html">Your
    /// VPC and Subnets</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Subnet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Subnet")]
    [AWSCmdlet("Invokes the CreateSubnet operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateSubnet"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Subnet",
        "This cmdlet returns a Subnet object.",
        "The service call response (type Amazon.EC2.Model.CreateSubnetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2SubnetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The Availability Zone for the subnet.</para><para>Default: AWS selects one for you. If you create more than one subnet in your VPC,
        /// we may not necessarily select a different zone for each subnet. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The network range for the subnet, in CIDR notation. For example, <code>10.0.0.0/24</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String CidrBlock { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VpcId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VpcId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Subnet (CreateSubnet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AvailabilityZone = this.AvailabilityZone;
            context.CidrBlock = this.CidrBlock;
            context.VpcId = this.VpcId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.CreateSubnetRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.CidrBlock != null)
            {
                request.CidrBlock = cmdletContext.CidrBlock;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateSubnet(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Subnet;
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
            public System.String AvailabilityZone { get; set; }
            public System.String CidrBlock { get; set; }
            public System.String VpcId { get; set; }
        }
        
    }
}
