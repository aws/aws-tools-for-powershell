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
    /// Assigns one or more secondary private IP addresses to the specified network interface.
    /// 
    ///  
    /// <para>
    /// You can specify one or more specific secondary IP addresses, or you can specify the
    /// number of secondary IP addresses to be automatically assigned within the subnet's
    /// CIDR block range. The number of secondary IP addresses that you can assign to an instance
    /// varies by instance type. For more information about Elastic IP addresses, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/elastic-ip-addresses-eip.html">Elastic
    /// IP Addresses</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// When you move a secondary private IP address to another network interface, any Elastic
    /// IP address that is associated with the IP address is also moved.
    /// </para><para>
    /// Remapping an IP address is an asynchronous operation. When you move an IP address
    /// from one network interface to another, check <c>network/interfaces/macs/mac/local-ipv4s</c>
    /// in the instance metadata to confirm that the remapping is complete.
    /// </para><para>
    /// You must specify either the IP addresses or the IP address count in the request.
    /// </para><para>
    /// You can optionally use Prefix Delegation on the network interface. You must specify
    /// either the IPv4 Prefix Delegation prefixes, or the IPv4 Prefix Delegation count. For
    /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-prefix-eni.html">
    /// Assigning prefixes to network interfaces</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2PrivateIpAddress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.AssignedPrivateIpAddress")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) AssignPrivateIpAddresses API operation.", Operation = new[] {"AssignPrivateIpAddresses"}, SelectReturnType = typeof(Amazon.EC2.Model.AssignPrivateIpAddressesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.AssignedPrivateIpAddress or Amazon.EC2.Model.AssignPrivateIpAddressesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.AssignedPrivateIpAddress objects.",
        "The service call response (type Amazon.EC2.Model.AssignPrivateIpAddressesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterEC2PrivateIpAddressCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowReassignment
        /// <summary>
        /// <para>
        /// <para>Indicates whether to allow an IP address that is already assigned to another network
        /// interface or instance to be reassigned to the specified network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowReassignment { get; set; }
        #endregion
        
        #region Parameter Ipv4PrefixCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv4 prefixes that Amazon Web Services automatically assigns to the
        /// network interface. You cannot use this option if you use the <c>Ipv4 Prefixes</c>
        /// option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv4PrefixCount { get; set; }
        #endregion
        
        #region Parameter Ipv4Prefix
        /// <summary>
        /// <para>
        /// <para>One or more IPv4 prefixes assigned to the network interface. You cannot use this option
        /// if you use the <c>Ipv4PrefixCount</c> option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv4Prefixes")]
        public System.String[] Ipv4Prefix { get; set; }
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
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>The IP addresses to be assigned as a secondary private IP address to the network interface.
        /// You can't specify this parameter when also specifying a number of secondary IP addresses.</para><para>If you don't specify an IP address, Amazon EC2 automatically selects an IP address
        /// within the subnet range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("PrivateIpAddresses")]
        public System.String[] PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter SecondaryPrivateIpAddressCount
        /// <summary>
        /// <para>
        /// <para>The number of secondary IP addresses to assign to the network interface. You can't
        /// specify this parameter when also specifying private IP addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssignedPrivateIpAddresses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.AssignPrivateIpAddressesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.AssignPrivateIpAddressesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssignedPrivateIpAddresses";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkInterfaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkInterfaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkInterfaceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkInterfaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2PrivateIpAddress (AssignPrivateIpAddresses)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.AssignPrivateIpAddressesResponse, RegisterEC2PrivateIpAddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkInterfaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowReassignment = this.AllowReassignment;
            context.Ipv4PrefixCount = this.Ipv4PrefixCount;
            if (this.Ipv4Prefix != null)
            {
                context.Ipv4Prefix = new List<System.String>(this.Ipv4Prefix);
            }
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PrivateIpAddress != null)
            {
                context.PrivateIpAddress = new List<System.String>(this.PrivateIpAddress);
            }
            context.SecondaryPrivateIpAddressCount = this.SecondaryPrivateIpAddressCount;
            
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
            var request = new Amazon.EC2.Model.AssignPrivateIpAddressesRequest();
            
            if (cmdletContext.AllowReassignment != null)
            {
                request.AllowReassignment = cmdletContext.AllowReassignment.Value;
            }
            if (cmdletContext.Ipv4PrefixCount != null)
            {
                request.Ipv4PrefixCount = cmdletContext.Ipv4PrefixCount.Value;
            }
            if (cmdletContext.Ipv4Prefix != null)
            {
                request.Ipv4Prefixes = cmdletContext.Ipv4Prefix;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddresses = cmdletContext.PrivateIpAddress;
            }
            if (cmdletContext.SecondaryPrivateIpAddressCount != null)
            {
                request.SecondaryPrivateIpAddressCount = cmdletContext.SecondaryPrivateIpAddressCount.Value;
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
        
        private Amazon.EC2.Model.AssignPrivateIpAddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssignPrivateIpAddressesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "AssignPrivateIpAddresses");
            try
            {
                #if DESKTOP
                return client.AssignPrivateIpAddresses(request);
                #elif CORECLR
                return client.AssignPrivateIpAddressesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowReassignment { get; set; }
            public System.Int32? Ipv4PrefixCount { get; set; }
            public List<System.String> Ipv4Prefix { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public List<System.String> PrivateIpAddress { get; set; }
            public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
            public System.Func<Amazon.EC2.Model.AssignPrivateIpAddressesResponse, RegisterEC2PrivateIpAddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssignedPrivateIpAddresses;
        }
        
    }
}
