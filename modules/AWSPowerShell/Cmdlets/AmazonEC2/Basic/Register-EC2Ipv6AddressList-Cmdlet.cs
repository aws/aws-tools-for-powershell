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
    /// Assigns one or more IPv6 addresses to the specified network interface. You can specify
    /// one or more specific IPv6 addresses, or you can specify the number of IPv6 addresses
    /// to be automatically assigned from within the subnet's IPv6 CIDR block range. You can
    /// assign as many IPv6 addresses to a network interface as you can assign private IPv4
    /// addresses, and the limit varies per instance type. For information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-eni.html#AvailableIpPerENI">IP
    /// Addresses Per Network Interface Per Instance Type</a> in the <i>Amazon Elastic Compute
    /// Cloud User Guide</i>.
    /// </summary>
    [Cmdlet("Register", "EC2Ipv6AddressList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.AssignIpv6AddressesResponse")]
    [AWSCmdlet("Invokes the AssignIpv6Addresses operation against Amazon Elastic Compute Cloud.", Operation = new[] {"AssignIpv6Addresses"})]
    [AWSCmdletOutput("Amazon.EC2.Model.AssignIpv6AddressesResponse",
        "This cmdlet returns a Amazon.EC2.Model.AssignIpv6AddressesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterEC2Ipv6AddressListCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Ipv6AddressCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv6 addresses to assign to the network interface. Amazon EC2 automatically
        /// selects the IPv6 addresses from the subnet range. You can't use this option if specifying
        /// specific IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Ipv6AddressCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>One or more specific IPv6 addresses to be assigned to the network interface. You can't
        /// use this option if you're specifying a number of IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Ipv6Addresses")]
        public System.String[] Ipv6Address { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NetworkInterfaceId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("NetworkInterfaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2Ipv6AddressList (AssignIpv6Addresses)"))
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
            
            if (ParameterWasBound("Ipv6AddressCount"))
                context.Ipv6AddressCount = this.Ipv6AddressCount;
            if (this.Ipv6Address != null)
            {
                context.Ipv6Addresses = new List<System.String>(this.Ipv6Address);
            }
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            
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
            if (cmdletContext.Ipv6Addresses != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Addresses;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private static Amazon.EC2.Model.AssignIpv6AddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.AssignIpv6AddressesRequest request)
        {
            #if DESKTOP
            return client.AssignIpv6Addresses(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AssignIpv6AddressesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? Ipv6AddressCount { get; set; }
            public List<System.String> Ipv6Addresses { get; set; }
            public System.String NetworkInterfaceId { get; set; }
        }
        
    }
}
