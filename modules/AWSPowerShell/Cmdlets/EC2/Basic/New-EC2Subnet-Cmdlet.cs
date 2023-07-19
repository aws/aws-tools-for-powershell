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
    /// Creates a subnet in the specified VPC. For an IPv4 only subnet, specify an IPv4 CIDR
    /// block. If the VPC has an IPv6 CIDR block, you can create an IPv6 only subnet or a
    /// dual stack subnet instead. For an IPv6 only subnet, specify an IPv6 CIDR block. For
    /// a dual stack subnet, specify both an IPv4 CIDR block and an IPv6 CIDR block.
    /// 
    ///  
    /// <para>
    /// A subnet CIDR block must not overlap the CIDR block of an existing subnet in the VPC.
    /// After you create a subnet, you can't change its CIDR block.
    /// </para><para>
    /// The allowed size for an IPv4 subnet is between a /28 netmask (16 IP addresses) and
    /// a /16 netmask (65,536 IP addresses). Amazon Web Services reserves both the first four
    /// and the last IPv4 address in each subnet's CIDR block. They're not available for your
    /// use.
    /// </para><para>
    /// If you've associated an IPv6 CIDR block with your VPC, you can associate an IPv6 CIDR
    /// block with a subnet when you create it. The allowed block size for an IPv6 subnet
    /// is a /64 netmask.
    /// </para><para>
    /// If you add more than one subnet to a VPC, they're set up in a star topology with a
    /// logical router in the middle.
    /// </para><para>
    /// When you stop an instance in a subnet, it retains its private IPv4 address. It's therefore
    /// possible to have a subnet with no running instances (they're all stopped), but no
    /// remaining IP addresses available.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/configure-subnets.html">Subnets</a>
    /// in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Subnet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.Subnet")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateSubnet API operation.", Operation = new[] {"CreateSubnet"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateSubnetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Subnet or Amazon.EC2.Model.CreateSubnetResponse",
        "This cmdlet returns an Amazon.EC2.Model.Subnet object.",
        "The service call response (type Amazon.EC2.Model.CreateSubnetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2SubnetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone or Local Zone for the subnet.</para><para>Default: Amazon Web Services selects one for you. If you create more than one subnet
        /// in your VPC, we do not necessarily select a different zone for each subnet.</para><para>To create a subnet in a Local Zone, set this value to the Local Zone ID, for example
        /// <code>us-west-2-lax-1a</code>. For information about the Regions that support Local
        /// Zones, see <a href="http://aws.amazon.com/about-aws/global-infrastructure/localzones/locations/">Local
        /// Zones locations</a>.</para><para>To create a subnet in an Outpost, set this value to the Availability Zone for the
        /// Outpost and specify the Outpost ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The AZ ID or the Local Zone ID of the subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv4 network range for the subnet, in CIDR notation. For example, <code>10.0.0.0/24</code>.
        /// We modify the specified CIDR block to its canonical form; for example, if you specify
        /// <code>100.68.0.18/18</code>, we modify it to <code>100.68.0.0/18</code>.</para><para>This parameter is not supported for an IPv6 only subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String CidrBlock { get; set; }
        #endregion
        
        #region Parameter Ipv6CidrBlock
        /// <summary>
        /// <para>
        /// <para>The IPv6 network range for the subnet, in CIDR notation. The subnet size must use
        /// a /64 prefix length.</para><para>This parameter is required for an IPv6 only subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6CidrBlock { get; set; }
        #endregion
        
        #region Parameter Ipv6Native
        /// <summary>
        /// <para>
        /// <para>Indicates whether to create an IPv6 only subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Ipv6Native { get; set; }
        #endregion
        
        #region Parameter OutpostArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Outpost. If you specify an Outpost ARN, you
        /// must also specify the Availability Zone of the Outpost subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostArn { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Subnet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateSubnetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateSubnetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Subnet";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpcId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpcId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpcId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpcId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Subnet (CreateSubnet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateSubnetResponse, NewEC2SubnetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpcId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.CidrBlock = this.CidrBlock;
            context.Ipv6CidrBlock = this.Ipv6CidrBlock;
            context.Ipv6Native = this.Ipv6Native;
            context.OutpostArn = this.OutpostArn;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
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
            var request = new Amazon.EC2.Model.CreateSubnetRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.CidrBlock != null)
            {
                request.CidrBlock = cmdletContext.CidrBlock;
            }
            if (cmdletContext.Ipv6CidrBlock != null)
            {
                request.Ipv6CidrBlock = cmdletContext.Ipv6CidrBlock;
            }
            if (cmdletContext.Ipv6Native != null)
            {
                request.Ipv6Native = cmdletContext.Ipv6Native.Value;
            }
            if (cmdletContext.OutpostArn != null)
            {
                request.OutpostArn = cmdletContext.OutpostArn;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateSubnetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateSubnetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateSubnet");
            try
            {
                #if DESKTOP
                return client.CreateSubnet(request);
                #elif CORECLR
                return client.CreateSubnetAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public System.String CidrBlock { get; set; }
            public System.String Ipv6CidrBlock { get; set; }
            public System.Boolean? Ipv6Native { get; set; }
            public System.String OutpostArn { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateSubnetResponse, NewEC2SubnetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Subnet;
        }
        
    }
}
