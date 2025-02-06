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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Associates a CIDR block with your VPC. You can associate a secondary IPv4 CIDR block,
    /// an Amazon-provided IPv6 CIDR block, or an IPv6 CIDR block from an IPv6 address pool
    /// that you provisioned through bring your own IP addresses (<a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-byoip.html">BYOIP</a>).
    /// 
    ///  
    /// <para>
    /// You must specify one of the following in the request: an IPv4 CIDR block, an IPv6
    /// pool, or an Amazon-provided IPv6 CIDR block.
    /// </para><para>
    /// For more information about associating CIDR blocks with your VPC and applicable restrictions,
    /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/vpc-ip-addressing.html">IP
    /// addressing for your VPCs and subnets</a> in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2VpcCidrBlock", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.AssociateVpcCidrBlockResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AssociateVpcCidrBlock API operation.", Operation = new[] {"AssociateVpcCidrBlock"}, SelectReturnType = typeof(Amazon.EC2.Model.AssociateVpcCidrBlockResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AssociateVpcCidrBlockResponse",
        "This cmdlet returns an Amazon.EC2.Model.AssociateVpcCidrBlockResponse object containing multiple properties."
    )]
    public partial class RegisterEC2VpcCidrBlockCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmazonProvidedIpv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>Requests an Amazon-provided IPv6 CIDR block with a /56 prefix length for the VPC.
        /// You cannot specify the range of IPv6 addresses or the size of the CIDR block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AmazonProvidedIpv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter CidrBlock
        /// <summary>
        /// <para>
        /// <para>An IPv4 CIDR block to associate with the VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CidrBlock { get; set; }
        #endregion
        
        #region Parameter Ipv4IpamPoolId
        /// <summary>
        /// <para>
        /// <para>Associate a CIDR allocated from an IPv4 IPAM pool to a VPC. For more information about
        /// Amazon VPC IP Address Manager (IPAM), see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv4IpamPoolId { get; set; }
        #endregion
        
        #region Parameter Ipv4NetmaskLength
        /// <summary>
        /// <para>
        /// <para>The netmask length of the IPv4 CIDR you would like to associate from an Amazon VPC
        /// IP Address Manager (IPAM) pool. For more information about IPAM, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv4NetmaskLength { get; set; }
        #endregion
        
        #region Parameter Ipv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>An IPv6 CIDR block from the IPv6 address pool. You must also specify <c>Ipv6Pool</c>
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
        /// to limit the CIDR block to this location.</para><para> You must set <c>AmazonProvidedIpv6CidrBlock</c> to <c>true</c> to use this parameter.</para><para> You can have one IPv6 CIDR block association per network border group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6CidrBlockNetworkBorderGroup { get; set; }
        #endregion
        
        #region Parameter Ipv6IpamPoolId
        /// <summary>
        /// <para>
        /// <para>Associates a CIDR allocated from an IPv6 IPAM pool to a VPC. For more information
        /// about Amazon VPC IP Address Manager (IPAM), see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6IpamPoolId { get; set; }
        #endregion
        
        #region Parameter Ipv6NetmaskLength
        /// <summary>
        /// <para>
        /// <para>The netmask length of the IPv6 CIDR you would like to associate from an Amazon VPC
        /// IP Address Manager (IPAM) pool. For more information about IPAM, see <a href="https://docs.aws.amazon.com/vpc/latest/ipam/what-is-it-ipam.html">What
        /// is IPAM?</a> in the <i>Amazon VPC IPAM User Guide</i>. </para>
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
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC.</para>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AssociateVpcCidrBlockResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AssociateVpcCidrBlockResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2VpcCidrBlock (AssociateVpcCidrBlock)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AssociateVpcCidrBlockResponse, RegisterEC2VpcCidrBlockCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AmazonProvidedIpv6CidrBlock = this.AmazonProvidedIpv6CidrBlock;
            context.CidrBlock = this.CidrBlock;
            context.Ipv4IpamPoolId = this.Ipv4IpamPoolId;
            context.Ipv4NetmaskLength = this.Ipv4NetmaskLength;
            context.Ipv6CidrBlock = this.Ipv6CidrBlock;
            context.Ipv6CidrBlockNetworkBorderGroup = this.Ipv6CidrBlockNetworkBorderGroup;
            context.Ipv6IpamPoolId = this.Ipv6IpamPoolId;
            context.Ipv6NetmaskLength = this.Ipv6NetmaskLength;
            context.Ipv6Pool = this.Ipv6Pool;
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.AssociateVpcCidrBlockRequest();
            
            if (cmdletContext.AmazonProvidedIpv6CidrBlock != null)
            {
                request.AmazonProvidedIpv6CidrBlock = cmdletContext.AmazonProvidedIpv6CidrBlock.Value;
            }
            if (cmdletContext.CidrBlock != null)
            {
                request.CidrBlock = cmdletContext.CidrBlock;
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
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.EC2.Model.AssociateVpcCidrBlockResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssociateVpcCidrBlockRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AssociateVpcCidrBlock");
            try
            {
                #if DESKTOP
                return client.AssociateVpcCidrBlock(request);
                #elif CORECLR
                return client.AssociateVpcCidrBlockAsync(request).GetAwaiter().GetResult();
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
            public System.String Ipv4IpamPoolId { get; set; }
            public System.Int32? Ipv4NetmaskLength { get; set; }
            public System.String Ipv6CidrBlock { get; set; }
            public System.String Ipv6CidrBlockNetworkBorderGroup { get; set; }
            public System.String Ipv6IpamPoolId { get; set; }
            public System.Int32? Ipv6NetmaskLength { get; set; }
            public System.String Ipv6Pool { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.EC2.Model.AssociateVpcCidrBlockResponse, RegisterEC2VpcCidrBlockCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
