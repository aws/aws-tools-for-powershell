/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a VPC with the specified IPv4 CIDR block. The smallest VPC you can create
    /// uses a /28 netmask (16 IPv4 addresses), and the largest uses a /16 netmask (65,536
    /// IPv4 addresses). For more information about how large to make your VPC, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_Subnets.html">Your
    /// VPC and Subnets</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can optionally request an Amazon-provided IPv6 CIDR block for the VPC. The IPv6
    /// CIDR block uses a /56 prefix length, and is allocated from Amazon's pool of IPv6 addresses.
    /// You cannot choose the IPv6 range for your VPC.
    /// </para><para>
    /// By default, each instance you launch in the VPC has the default DHCP options, which
    /// include only a default DNS server that we provide (AmazonProvidedDNS). For more information,
    /// see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_DHCP_Options.html">DHCP
    /// Options Sets</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para><para>
    /// You can specify the instance tenancy value for the VPC when you create it. You can't
    /// change this value for the VPC after you create it. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/dedicated-instance.html">Dedicated
    /// Instances</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Vpc", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Vpc")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateVpc API operation.", Operation = new[] {"CreateVpc"})]
    [AWSCmdletOutput("Amazon.EC2.Model.Vpc",
        "This cmdlet returns a Vpc object.",
        "The service call response (type Amazon.EC2.Model.CreateVpcResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2VpcCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AmazonProvidedIpv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>Requests an Amazon-provided IPv6 CIDR block with a /56 prefix length for the VPC.
        /// You cannot specify the range of IP addresses, or the size of the CIDR block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AmazonProvidedIpv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 network range for the VPC, in CIDR notation. For example, <code>10.0.0.0/16</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CidrBlock { get; set; }
        #endregion
        
        #region Parameter InstanceTenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy options for instances launched into the VPC. For <code>default</code>,
        /// instances are launched with shared tenancy by default. You can launch instances with
        /// any tenancy into a shared tenancy VPC. For <code>dedicated</code>, instances are launched
        /// as dedicated tenancy instances by default. You can only launch instances with a tenancy
        /// of <code>dedicated</code> or <code>host</code> into a dedicated tenancy VPC. </para><para><b>Important:</b> The <code>host</code> value cannot be used with this parameter.
        /// Use the <code>default</code> or <code>dedicated</code> values only.</para><para>Default: <code>default</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.EC2.Tenancy")]
        public Amazon.EC2.Tenancy InstanceTenancy { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CidrBlock", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Vpc (CreateVpc)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("AmazonProvidedIpv6CidrBlock"))
                context.AmazonProvidedIpv6CidrBlock = this.AmazonProvidedIpv6CidrBlock;
            context.CidrBlock = this.CidrBlock;
            context.InstanceTenancy = this.InstanceTenancy;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Vpc;
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
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.CreateVpcResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateVpcRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateVpc");
            try
            {
                #if DESKTOP
                return client.CreateVpc(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateVpcAsync(request);
                return task.Result;
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
        }
        
    }
}
