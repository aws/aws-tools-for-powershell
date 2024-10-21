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
    /// Associates Elastic IP addresses (EIPs) and private IPv4 addresses with a public NAT
    /// gateway. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/nat-gateway-working-with.html">Work
    /// with NAT gateways</a> in the <i>Amazon VPC User Guide</i>.
    /// 
    ///  
    /// <para>
    /// By default, you can associate up to 2 Elastic IP addresses per public NAT gateway.
    /// You can increase the limit by requesting a quota adjustment. For more information,
    /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html#vpc-limits-eips">Elastic
    /// IP address quotas</a> in the <i>Amazon VPC User Guide</i>.
    /// </para><important><para>
    /// When you associate an EIP or secondary EIPs with a public NAT gateway, the network
    /// border group of the EIPs must match the network border group of the Availability Zone
    /// (AZ) that the public NAT gateway is in. If it's not the same, the EIP will fail to
    /// associate. You can see the network border group for the subnet's AZ by viewing the
    /// details of the subnet. Similarly, you can view the network border group of an EIP
    /// by viewing the details of the EIP address. For more information about network border
    /// groups and EIPs, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/WorkWithEIPs.html">Allocate
    /// an Elastic IP address</a> in the <i>Amazon VPC User Guide</i>. 
    /// </para></important>
    /// </summary>
    [Cmdlet("Register", "EC2NatGatewayAddress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.AssociateNatGatewayAddressResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AssociateNatGatewayAddress API operation.", Operation = new[] {"AssociateNatGatewayAddress"}, SelectReturnType = typeof(Amazon.EC2.Model.AssociateNatGatewayAddressResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AssociateNatGatewayAddressResponse",
        "This cmdlet returns an Amazon.EC2.Model.AssociateNatGatewayAddressResponse object containing multiple properties."
    )]
    public partial class RegisterEC2NatGatewayAddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocationId
        /// <summary>
        /// <para>
        /// <para>The allocation IDs of EIPs that you want to associate with your NAT gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AllocationIds")]
        public System.String[] AllocationId { get; set; }
        #endregion
        
        #region Parameter NatGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the NAT gateway.</para>
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
        public System.String NatGatewayId { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>The private IPv4 addresses that you want to assign to the NAT gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PrivateIpAddresses")]
        public System.String[] PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AssociateNatGatewayAddressResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AssociateNatGatewayAddressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NatGatewayId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NatGatewayId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NatGatewayId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NatGatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2NatGatewayAddress (AssociateNatGatewayAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AssociateNatGatewayAddressResponse, RegisterEC2NatGatewayAddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NatGatewayId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AllocationId != null)
            {
                context.AllocationId = new List<System.String>(this.AllocationId);
            }
            #if MODULAR
            if (this.AllocationId == null && ParameterWasBound(nameof(this.AllocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter AllocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NatGatewayId = this.NatGatewayId;
            #if MODULAR
            if (this.NatGatewayId == null && ParameterWasBound(nameof(this.NatGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter NatGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PrivateIpAddress != null)
            {
                context.PrivateIpAddress = new List<System.String>(this.PrivateIpAddress);
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
            var request = new Amazon.EC2.Model.AssociateNatGatewayAddressRequest();
            
            if (cmdletContext.AllocationId != null)
            {
                request.AllocationIds = cmdletContext.AllocationId;
            }
            if (cmdletContext.NatGatewayId != null)
            {
                request.NatGatewayId = cmdletContext.NatGatewayId;
            }
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddresses = cmdletContext.PrivateIpAddress;
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
        
        private Amazon.EC2.Model.AssociateNatGatewayAddressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssociateNatGatewayAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AssociateNatGatewayAddress");
            try
            {
                #if DESKTOP
                return client.AssociateNatGatewayAddress(request);
                #elif CORECLR
                return client.AssociateNatGatewayAddressAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllocationId { get; set; }
            public System.String NatGatewayId { get; set; }
            public List<System.String> PrivateIpAddress { get; set; }
            public System.Func<Amazon.EC2.Model.AssociateNatGatewayAddressResponse, RegisterEC2NatGatewayAddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
