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
    /// Unassigns the specified IPv6 addresses or Prefix Delegation prefixes from a network
    /// interface.
    /// </summary>
    [Cmdlet("Unregister", "EC2Ipv6AddressList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.UnassignIpv6AddressesResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) UnassignIpv6Addresses API operation.", Operation = new[] {"UnassignIpv6Addresses"}, SelectReturnType = typeof(Amazon.EC2.Model.UnassignIpv6AddressesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.UnassignIpv6AddressesResponse",
        "This cmdlet returns an Amazon.EC2.Model.UnassignIpv6AddressesResponse object containing multiple properties."
    )]
    public partial class UnregisterEC2Ipv6AddressListCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>The IPv6 addresses to unassign from the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ipv6Addresses")]
        public System.String[] Ipv6Address { get; set; }
        #endregion
        
        #region Parameter Ipv6Prefix
        /// <summary>
        /// <para>
        /// <para>The IPv6 prefixes to unassign from the network interface.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.UnassignIpv6AddressesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.UnassignIpv6AddressesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2Ipv6AddressList (UnassignIpv6Addresses)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.UnassignIpv6AddressesResponse, UnregisterEC2Ipv6AddressListCmdlet>(Select) ??
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
            if (this.Ipv6Address != null)
            {
                context.Ipv6Address = new List<System.String>(this.Ipv6Address);
            }
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
            var request = new Amazon.EC2.Model.UnassignIpv6AddressesRequest();
            
            if (cmdletContext.Ipv6Address != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Address;
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
        
        private Amazon.EC2.Model.UnassignIpv6AddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.UnassignIpv6AddressesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "UnassignIpv6Addresses");
            try
            {
                #if DESKTOP
                return client.UnassignIpv6Addresses(request);
                #elif CORECLR
                return client.UnassignIpv6AddressesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Ipv6Address { get; set; }
            public List<System.String> Ipv6Prefix { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Func<Amazon.EC2.Model.UnassignIpv6AddressesResponse, UnregisterEC2Ipv6AddressListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
