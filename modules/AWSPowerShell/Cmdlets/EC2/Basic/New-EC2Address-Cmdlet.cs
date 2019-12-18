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
    /// Allocates an Elastic IP address to your AWS account. After you allocate the Elastic
    /// IP address you can associate it with an instance or network interface. After you release
    /// an Elastic IP address, it is released to the IP address pool and can be allocated
    /// to a different AWS account.
    /// 
    ///  
    /// <para>
    /// You can allocate an Elastic IP address from an address pool owned by AWS or from an
    /// address pool created from a public IPv4 address range that you have brought to AWS
    /// for use with your AWS resources using bring your own IP addresses (BYOIP). For more
    /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-byoip.html">Bring
    /// Your Own IP Addresses (BYOIP)</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// [EC2-VPC] If you release an Elastic IP address, you might be able to recover it. You
    /// cannot recover an Elastic IP address that you released after it is allocated to another
    /// AWS account. You cannot recover an Elastic IP address for EC2-Classic. To attempt
    /// to recover an Elastic IP address that you released, specify it in this operation.
    /// </para><para>
    /// An Elastic IP address is for use either in the EC2-Classic platform or in a VPC. By
    /// default, you can allocate 5 Elastic IP addresses for EC2-Classic per Region and 5
    /// Elastic IP addresses for EC2-VPC per Region.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
    /// IP Addresses</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2Address", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.AllocateAddressResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AllocateAddress API operation.", Operation = new[] {"AllocateAddress"}, SelectReturnType = typeof(Amazon.EC2.Model.AllocateAddressResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AllocateAddressResponse",
        "This cmdlet returns an Amazon.EC2.Model.AllocateAddressResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2AddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Address
        /// <summary>
        /// <para>
        /// <para>[EC2-VPC] The Elastic IP address to recover or an IPv4 address from an address pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address { get; set; }
        #endregion
        
        #region Parameter CustomerOwnedIpv4Pool
        /// <summary>
        /// <para>
        /// <para>The ID of a customer-owned address pool. Use this parameter to let Amazon EC2 select
        /// an address from the address pool. Alternatively, specify a specific address from the
        /// address pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerOwnedIpv4Pool { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>Set to <code>vpc</code> to allocate the address for use with instances in a VPC.</para><para>Default: The address is for use with instances in EC2-Classic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.DomainType")]
        public Amazon.EC2.DomainType Domain { get; set; }
        #endregion
        
        #region Parameter NetworkBorderGroup
        /// <summary>
        /// <para>
        /// <para>The location from which the IP address is advertised. Use this parameter to limit
        /// the address to this location.</para><para>Use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeVpcs.html">DescribeVpcs</a>
        /// to view the network border groups.</para><note><para>You cannot use a network border group with EC2 Classic. If you attempt this operation
        /// on EC2 classic, you will receive an <code>InvalidParameterCombination</code> error.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/errors-overview.html">Error
        /// Codes</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkBorderGroup { get; set; }
        #endregion
        
        #region Parameter PublicIpv4Pool
        /// <summary>
        /// <para>
        /// <para>The ID of an address pool that you own. Use this parameter to let Amazon EC2 select
        /// an address from the address pool. To specify a specific address from the address pool,
        /// use the <code>Address</code> parameter instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PublicIpv4Pool { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AllocateAddressResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AllocateAddressResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2Address (AllocateAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AllocateAddressResponse, NewEC2AddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Address = this.Address;
            context.CustomerOwnedIpv4Pool = this.CustomerOwnedIpv4Pool;
            context.Domain = this.Domain;
            context.NetworkBorderGroup = this.NetworkBorderGroup;
            context.PublicIpv4Pool = this.PublicIpv4Pool;
            
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
            var request = new Amazon.EC2.Model.AllocateAddressRequest();
            
            if (cmdletContext.Address != null)
            {
                request.Address = cmdletContext.Address;
            }
            if (cmdletContext.CustomerOwnedIpv4Pool != null)
            {
                request.CustomerOwnedIpv4Pool = cmdletContext.CustomerOwnedIpv4Pool;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.NetworkBorderGroup != null)
            {
                request.NetworkBorderGroup = cmdletContext.NetworkBorderGroup;
            }
            if (cmdletContext.PublicIpv4Pool != null)
            {
                request.PublicIpv4Pool = cmdletContext.PublicIpv4Pool;
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
        
        private Amazon.EC2.Model.AllocateAddressResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AllocateAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AllocateAddress");
            try
            {
                #if DESKTOP
                return client.AllocateAddress(request);
                #elif CORECLR
                return client.AllocateAddressAsync(request).GetAwaiter().GetResult();
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
            public System.String Address { get; set; }
            public System.String CustomerOwnedIpv4Pool { get; set; }
            public Amazon.EC2.DomainType Domain { get; set; }
            public System.String NetworkBorderGroup { get; set; }
            public System.String PublicIpv4Pool { get; set; }
            public System.Func<Amazon.EC2.Model.AllocateAddressResponse, NewEC2AddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
