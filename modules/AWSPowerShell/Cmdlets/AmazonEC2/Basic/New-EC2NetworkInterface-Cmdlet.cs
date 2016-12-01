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
    /// Creates a network interface in the specified subnet.
    /// 
    ///  
    /// <para>
    /// For more information about network interfaces, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-eni.html">Elastic
    /// Network Interfaces</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2NetworkInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.NetworkInterface")]
    [AWSCmdlet("Invokes the CreateNetworkInterface operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateNetworkInterface"})]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInterface",
        "This cmdlet returns a NetworkInterface object.",
        "The service call response (type Amazon.EC2.Model.CreateNetworkInterfaceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2NetworkInterfaceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [Alias("GroupId","Groups")]
        public System.String[] Group { get; set; }
        #endregion
        
        #region Parameter Ipv6AddressCount
        /// <summary>
        /// <para>
        /// <para>The number of IPv6 addresses to assign to a network interface. Amazon EC2 automatically
        /// selects the IPv6 addresses from the subnet range. You can't use this option if specifying
        /// specific IPv6 addresses. If your subnet has the <code>AssignIpv6AddressOnCreation</code>
        /// attribute set to <code>true</code>, you can specify <code>0</code> to override this
        /// setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Ipv6AddressCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>One or more specific IPv6 addresses from the IPv6 CIDR block range of your subnet.
        /// You can't use this option if you're specifying a number of IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Ipv6Addresses")]
        public Amazon.EC2.Model.InstanceIpv6Address[] Ipv6Address { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>The primary private IPv4 address of the network interface. If you don't specify an
        /// IPv4 address, Amazon EC2 selects one for you from the subnet's IPv4 CIDR range. If
        /// you specify an IP address, you cannot indicate any IP addresses specified in <code>privateIpAddresses</code>
        /// as primary (only one IP address can be designated as primary).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddressSet
        /// <summary>
        /// <para>
        /// <para>One or more private IPv4 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PrivateIpAddresses")]
        public Amazon.EC2.Model.PrivateIpAddressSpecification[] PrivateIpAddressSet { get; set; }
        #endregion
        
        #region Parameter SecondaryPrivateIpAddressCount
        /// <summary>
        /// <para>
        /// <para>The number of secondary private IPv4 addresses to assign to a network interface. When
        /// you specify a number of secondary IPv4 addresses, Amazon EC2 selects these IP addresses
        /// within the subnet's IPv4 CIDR range. You can't specify this option and specify more
        /// than one private IP address using <code>privateIpAddresses</code>.</para><para>The number of IP addresses you can assign to a network interface varies by instance
        /// type. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-eni.html#AvailableIpPerENI">IP
        /// Addresses Per ENI Per Instance Type</a> in the <i>Amazon Virtual Private Cloud User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SecondaryPrivateIpAddressCount { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet to associate with the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SubnetId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SubnetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NetworkInterface (CreateNetworkInterface)"))
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
            
            context.Description = this.Description;
            if (this.Group != null)
            {
                context.Groups = new List<System.String>(this.Group);
            }
            if (ParameterWasBound("Ipv6AddressCount"))
                context.Ipv6AddressCount = this.Ipv6AddressCount;
            if (this.Ipv6Address != null)
            {
                context.Ipv6Addresses = new List<Amazon.EC2.Model.InstanceIpv6Address>(this.Ipv6Address);
            }
            context.PrivateIpAddress = this.PrivateIpAddress;
            if (this.PrivateIpAddressSet != null)
            {
                context.PrivateIpAddressSet = new List<Amazon.EC2.Model.PrivateIpAddressSpecification>(this.PrivateIpAddressSet);
            }
            if (ParameterWasBound("SecondaryPrivateIpAddressCount"))
                context.SecondaryPrivateIpAddressCount = this.SecondaryPrivateIpAddressCount;
            context.SubnetId = this.SubnetId;
            
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
            var request = new Amazon.EC2.Model.CreateNetworkInterfaceRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Groups != null)
            {
                request.Groups = cmdletContext.Groups;
            }
            if (cmdletContext.Ipv6AddressCount != null)
            {
                request.Ipv6AddressCount = cmdletContext.Ipv6AddressCount.Value;
            }
            if (cmdletContext.Ipv6Addresses != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Addresses;
            }
            if (cmdletContext.PrivateIpAddress != null)
            {
                request.PrivateIpAddress = cmdletContext.PrivateIpAddress;
            }
            if (cmdletContext.PrivateIpAddressSet != null)
            {
                request.PrivateIpAddresses = cmdletContext.PrivateIpAddressSet;
            }
            if (cmdletContext.SecondaryPrivateIpAddressCount != null)
            {
                request.SecondaryPrivateIpAddressCount = cmdletContext.SecondaryPrivateIpAddressCount.Value;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NetworkInterface;
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
        
        private static Amazon.EC2.Model.CreateNetworkInterfaceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNetworkInterfaceRequest request)
        {
            #if DESKTOP
            return client.CreateNetworkInterface(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateNetworkInterfaceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Description { get; set; }
            public List<System.String> Groups { get; set; }
            public System.Int32? Ipv6AddressCount { get; set; }
            public List<Amazon.EC2.Model.InstanceIpv6Address> Ipv6Addresses { get; set; }
            public System.String PrivateIpAddress { get; set; }
            public List<Amazon.EC2.Model.PrivateIpAddressSpecification> PrivateIpAddressSet { get; set; }
            public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
            public System.String SubnetId { get; set; }
        }
        
    }
}
