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
    /// Unassigns one or more IPv6 addresses from a network interface.
    /// </summary>
    [Cmdlet("Unregister", "EC2Ipv6AddressList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.UnassignIpv6AddressesResponse")]
    [AWSCmdlet("Invokes the UnassignIpv6Addresses operation against Amazon Elastic Compute Cloud.", Operation = new[] {"UnassignIpv6Addresses"})]
    [AWSCmdletOutput("Amazon.EC2.Model.UnassignIpv6AddressesResponse",
        "This cmdlet returns a Amazon.EC2.Model.UnassignIpv6AddressesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterEC2Ipv6AddressListCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>The IPv6 addresses to unassign from the network interface.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-EC2Ipv6AddressList (UnassignIpv6Addresses)"))
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
            var request = new Amazon.EC2.Model.UnassignIpv6AddressesRequest();
            
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
        
        private static Amazon.EC2.Model.UnassignIpv6AddressesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.UnassignIpv6AddressesRequest request)
        {
            #if DESKTOP
            return client.UnassignIpv6Addresses(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UnassignIpv6AddressesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> Ipv6Addresses { get; set; }
            public System.String NetworkInterfaceId { get; set; }
        }
        
    }
}
