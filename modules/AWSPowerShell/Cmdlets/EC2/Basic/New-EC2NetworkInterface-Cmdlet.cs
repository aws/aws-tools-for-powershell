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
    /// Creates a network interface in the specified subnet.
    /// 
    ///  
    /// <para>
    /// For more information about network interfaces, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-eni.html">Elastic
    /// Network Interfaces</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2NetworkInterface", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.NetworkInterface")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateNetworkInterface API operation.", Operation = new[] {"CreateNetworkInterface"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateNetworkInterfaceResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInterface or Amazon.EC2.Model.CreateNetworkInterfaceResponse",
        "This cmdlet returns an Amazon.EC2.Model.NetworkInterface object.",
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
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [Alias("GroupId","Groups")]
        public System.String[] Group { get; set; }
        #endregion
        
        #region Parameter InterfaceType
        /// <summary>
        /// <para>
        /// <para>Indicates the type of network interface. To create an Elastic Fabric Adapter (EFA),
        /// specify <code>efa</code>. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/efa.html">
        /// Elastic Fabric Adapter</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
        /// To create a trunk network interface, specify <code>efa</code>. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/eni-trunking.html">
        /// Network interface trunking</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.NetworkInterfaceCreationType")]
        public Amazon.EC2.NetworkInterfaceCreationType InterfaceType { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Ipv6AddressCount { get; set; }
        #endregion
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>One or more specific IPv6 addresses from the IPv6 CIDR block range of your subnet.
        /// You can't use this option if you're specifying a number of IPv6 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter PrivateIpAddressSet
        /// <summary>
        /// <para>
        /// <para>One or more private IPv4 addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// type. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-eni.html#AvailableIpPerENI">IP
        /// Addresses Per ENI Per Instance Type</a> in the <i>Amazon Virtual Private Cloud User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet to associate with the network interface.</para>
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
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the new network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkInterface'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateNetworkInterfaceResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateNetworkInterfaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkInterface";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubnetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubnetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubnetId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubnetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2NetworkInterface (CreateNetworkInterface)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateNetworkInterfaceResponse, NewEC2NetworkInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubnetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.Group != null)
            {
                context.Group = new List<System.String>(this.Group);
            }
            context.InterfaceType = this.InterfaceType;
            context.Ipv6AddressCount = this.Ipv6AddressCount;
            if (this.Ipv6Address != null)
            {
                context.Ipv6Address = new List<Amazon.EC2.Model.InstanceIpv6Address>(this.Ipv6Address);
            }
            context.PrivateIpAddress = this.PrivateIpAddress;
            if (this.PrivateIpAddressSet != null)
            {
                context.PrivateIpAddressSet = new List<Amazon.EC2.Model.PrivateIpAddressSpecification>(this.PrivateIpAddressSet);
            }
            context.SecondaryPrivateIpAddressCount = this.SecondaryPrivateIpAddressCount;
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateNetworkInterfaceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Group != null)
            {
                request.Groups = cmdletContext.Group;
            }
            if (cmdletContext.InterfaceType != null)
            {
                request.InterfaceType = cmdletContext.InterfaceType;
            }
            if (cmdletContext.Ipv6AddressCount != null)
            {
                request.Ipv6AddressCount = cmdletContext.Ipv6AddressCount.Value;
            }
            if (cmdletContext.Ipv6Address != null)
            {
                request.Ipv6Addresses = cmdletContext.Ipv6Address;
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
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateNetworkInterfaceResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateNetworkInterfaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateNetworkInterface");
            try
            {
                #if DESKTOP
                return client.CreateNetworkInterface(request);
                #elif CORECLR
                return client.CreateNetworkInterfaceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<System.String> Group { get; set; }
            public Amazon.EC2.NetworkInterfaceCreationType InterfaceType { get; set; }
            public System.Int32? Ipv6AddressCount { get; set; }
            public List<Amazon.EC2.Model.InstanceIpv6Address> Ipv6Address { get; set; }
            public System.String PrivateIpAddress { get; set; }
            public List<Amazon.EC2.Model.PrivateIpAddressSpecification> PrivateIpAddressSet { get; set; }
            public System.Int32? SecondaryPrivateIpAddressCount { get; set; }
            public System.String SubnetId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateNetworkInterfaceResponse, NewEC2NetworkInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkInterface;
        }
        
    }
}
