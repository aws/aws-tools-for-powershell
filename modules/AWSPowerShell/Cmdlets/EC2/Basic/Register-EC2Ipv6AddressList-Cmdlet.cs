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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Assigns the specified IPv6 addresses to the specified network interface. You can specify
    /// specific IPv6 addresses, or you can specify the number of IPv6 addresses to be automatically
    /// assigned from the subnet's IPv6 CIDR block range. You can assign as many IPv6 addresses
    /// to a network interface as you can assign private IPv4 addresses, and the limit varies
    /// by instance type.
    /// 
    ///  
    /// <para>
    /// You must specify either the IPv6 addresses or the IPv6 address count in the request.
    /// 
    /// </para><para>
    /// You can optionally use Prefix Delegation on the network interface. You must specify
    /// either the IPV6 Prefix Delegation prefixes, or the IPv6 Prefix Delegation count. For
    /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-prefix-eni.html">
    /// Assigning prefixes to network interfaces</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2Ipv6AddressList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.AssignIpv6AddressesResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AssignIpv6Addresses API operation.", Operation = new[] {"AssignIpv6Addresses"}, SelectReturnType = typeof(Amazon.EC2.Model.AssignIpv6AddressesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AssignIpv6AddressesResponse",
        "This cmdlet returns an Amazon.EC2.Model.AssignIpv6AddressesResponse object containing multiple properties."
    )]
    public partial class RegisterEC2Ipv6AddressListCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Ipv6AddressCount
        /// <summary>
        /// <para>
        /// <para>The number of additional IPv6 addresses to assign to the network interface. The specified
        /// number of IPv6 addresses are assigned in addition to the existing IPv6 addresses that
        /// are already assigned to the network interface. Amazon EC2 automatically selects the
        /// IPv6 addresses from the subnet range. You can't use this option if specifying specific
        /// IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv6AddressCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>The IPv6 addresses to be assigned to the network interface. You can't use this option
        /// if you're specifying a number of IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv6Addresses")]
        public System.String[] Ipv6Address { get; set; }
        #endregion
        
        #region Parameter Ipv6PrefixCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv6 prefixes that Amazon Web Services automatically assigns to the
        /// network interface. You cannot use this option if you use the <c>Ipv6Prefixes</c> option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv6PrefixCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Prefix
        /// <summary>
        /// <para>
        /// <para>One or more IPv6 prefixes assigned to the network interface. You can't use this option
        /// if you use the <c>Ipv6PrefixCount</c> option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv6Prefixes")]
        public System.String[] Ipv6Prefix { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
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
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AssignIpv6AddressesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AssignIpv6AddressesResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkInterfaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2Ipv6AddressList (AssignIpv6Addresses)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AssignIpv6AddressesResponse, RegisterEC2Ipv6AddressListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Ipv6AddressCount = this.Ipv6AddressCount;
            if (this.Ipv6Address != null)
            {
                context.Ipv6Address = new List<System.String>(this.Ipv6Address);
            }
            context.Ipv6PrefixCount = this.Ipv6PrefixCount;
            if (this.Ipv6Prefix != null)
            {
                context.Ipv6Prefix = new List<System.String>(this.Ipv6Prefix);
            }
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.AssignIpv6AddressesRequest();
            
            if (cmdletContext.Ipv6AddressCount != null)
            {
                request.Ipv6AddressCount = cmdletContext.Ipv6AddressCount.Value;
            }
            if (cmdletContext.Ipv6Address != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Address;
            }
            if (cmdletContext.Ipv6PrefixCount != null)
            {
                request.Ipv6PrefixCount = cmdletContext.Ipv6PrefixCount.Value;
            }
            if (cmdletContext.Ipv6Prefix != null)
            {
                request.Ipv6Prefixes = cmdletContext.Ipv6Prefix;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
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
        
        private Amazon.EC2.Model.AssignIpv6AddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssignIpv6AddressesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AssignIpv6Addresses");
            try
            {
                return client.AssignIpv6AddressesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Ipv6AddressCount { get; set; }
            public List<System.String> Ipv6Address { get; set; }
            public System.Int32? Ipv6PrefixCount { get; set; }
            public List<System.String> Ipv6Prefix { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Func<Amazon.EC2.Model.AssignIpv6AddressesResponse, RegisterEC2Ipv6AddressListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
