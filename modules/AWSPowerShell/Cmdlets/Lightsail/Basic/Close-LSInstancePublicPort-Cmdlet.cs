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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Closes ports for a specific Amazon Lightsail instance.
    /// 
    ///  
    /// <para>
    /// The <c>CloseInstancePublicPorts</c> action supports tag-based access control via resource
    /// tags applied to the resource identified by <c>instanceName</c>. For more information,
    /// see the <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-controlling-access-using-tags">Amazon
    /// Lightsail Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Close", "LSInstancePublicPort", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.Operation")]
    [AWSCmdlet("Calls the Amazon Lightsail CloseInstancePublicPorts API operation.", Operation = new[] {"CloseInstancePublicPorts"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CloseInstancePublicPortsResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.Operation or Amazon.Lightsail.Model.CloseInstancePublicPortsResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.Operation object.",
        "The service call response (type Amazon.Lightsail.Model.CloseInstancePublicPortsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CloseLSInstancePublicPortCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PortInfo_CidrListAlias
        /// <summary>
        /// <para>
        /// <para>An alias that defines access for a preconfigured range of IP addresses.</para><para>The only alias currently supported is <c>lightsail-connect</c>, which allows IP addresses
        /// of the browser-based RDP/SSH client in the Lightsail console to connect to your instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortInfo_CidrListAliases")]
        public System.String[] PortInfo_CidrListAlias { get; set; }
        #endregion
        
        #region Parameter PortInfo_Cidr
        /// <summary>
        /// <para>
        /// <para>The IPv4 address, or range of IPv4 addresses (in CIDR notation) that are allowed to
        /// connect to an instance through the ports, and the protocol.</para><note><para>The <c>ipv6Cidrs</c> parameter lists the IPv6 addresses that are allowed to connect
        /// to an instance.</para></note><para>Examples:</para><ul><li><para>To allow the IP address <c>192.0.2.44</c>, specify <c>192.0.2.44</c> or <c>192.0.2.44/32</c>.
        /// </para></li><li><para>To allow the IP addresses <c>192.0.2.0</c> to <c>192.0.2.255</c>, specify <c>192.0.2.0/24</c>.</para></li></ul><para>For more information about CIDR block notation, see <a href="https://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing#CIDR_notation">Classless
        /// Inter-Domain Routing</a> on <i>Wikipedia</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortInfo_Cidrs")]
        public System.String[] PortInfo_Cidr { get; set; }
        #endregion
        
        #region Parameter PortInfo_FromPort
        /// <summary>
        /// <para>
        /// <para>The first port in a range of open ports on an instance.</para><para>Allowed ports:</para><ul><li><para>TCP and UDP - <c>0</c> to <c>65535</c></para></li><li><para>ICMP - The ICMP type for IPv4 addresses. For example, specify <c>8</c> as the <c>fromPort</c>
        /// (ICMP type), and <c>-1</c> as the <c>toPort</c> (ICMP code), to enable ICMP Ping.
        /// For more information, see <a href="https://en.wikipedia.org/wiki/Internet_Control_Message_Protocol#Control_messages">Control
        /// Messages</a> on <i>Wikipedia</i>.</para></li><li><para>ICMPv6 - The ICMP type for IPv6 addresses. For example, specify <c>128</c> as the
        /// <c>fromPort</c> (ICMPv6 type), and <c>0</c> as <c>toPort</c> (ICMPv6 code). For more
        /// information, see <a href="https://en.wikipedia.org/wiki/Internet_Control_Message_Protocol_for_IPv6">Internet
        /// Control Message Protocol for IPv6</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PortInfo_FromPort { get; set; }
        #endregion
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the instance for which to close ports.</para>
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
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter PortInfo_Ipv6Cidr
        /// <summary>
        /// <para>
        /// <para>The IPv6 address, or range of IPv6 addresses (in CIDR notation) that are allowed to
        /// connect to an instance through the ports, and the protocol. Only devices with an IPv6
        /// address can connect to an instance through IPv6; otherwise, IPv4 should be used.</para><note><para>The <c>cidrs</c> parameter lists the IPv4 addresses that are allowed to connect to
        /// an instance.</para></note><para>For more information about CIDR block notation, see <a href="https://en.wikipedia.org/wiki/Classless_Inter-Domain_Routing#CIDR_notation">Classless
        /// Inter-Domain Routing</a> on <i>Wikipedia</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortInfo_Ipv6Cidrs")]
        public System.String[] PortInfo_Ipv6Cidr { get; set; }
        #endregion
        
        #region Parameter PortInfo_Protocol
        /// <summary>
        /// <para>
        /// <para>The IP protocol name.</para><para>The name can be one of the following:</para><ul><li><para><c>tcp</c> - Transmission Control Protocol (TCP) provides reliable, ordered, and
        /// error-checked delivery of streamed data between applications running on hosts communicating
        /// by an IP network. If you have an application that doesn't require reliable data stream
        /// service, use UDP instead.</para></li><li><para><c>all</c> - All transport layer protocol types. For more general information, see
        /// <a href="https://en.wikipedia.org/wiki/Transport_layer">Transport layer</a> on <i>Wikipedia</i>.</para></li><li><para><c>udp</c> - With User Datagram Protocol (UDP), computer applications can send messages
        /// (or datagrams) to other hosts on an Internet Protocol (IP) network. Prior communications
        /// are not required to set up transmission channels or data paths. Applications that
        /// don't require reliable data stream service can use UDP, which provides a connectionless
        /// datagram service that emphasizes reduced latency over reliability. If you do require
        /// reliable data stream service, use TCP instead.</para></li><li><para><c>icmp</c> - Internet Control Message Protocol (ICMP) is used to send error messages
        /// and operational information indicating success or failure when communicating with
        /// an instance. For example, an error is indicated when an instance could not be reached.
        /// When you specify <c>icmp</c> as the <c>protocol</c>, you must specify the ICMP type
        /// using the <c>fromPort</c> parameter, and ICMP code using the <c>toPort</c> parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lightsail.NetworkProtocol")]
        public Amazon.Lightsail.NetworkProtocol PortInfo_Protocol { get; set; }
        #endregion
        
        #region Parameter PortInfo_ToPort
        /// <summary>
        /// <para>
        /// <para>The last port in a range of open ports on an instance.</para><para>Allowed ports:</para><ul><li><para>TCP and UDP - <c>0</c> to <c>65535</c></para></li><li><para>ICMP - The ICMP code for IPv4 addresses. For example, specify <c>8</c> as the <c>fromPort</c>
        /// (ICMP type), and <c>-1</c> as the <c>toPort</c> (ICMP code), to enable ICMP Ping.
        /// For more information, see <a href="https://en.wikipedia.org/wiki/Internet_Control_Message_Protocol#Control_messages">Control
        /// Messages</a> on <i>Wikipedia</i>.</para></li><li><para>ICMPv6 - The ICMP code for IPv6 addresses. For example, specify <c>128</c> as the
        /// <c>fromPort</c> (ICMPv6 type), and <c>0</c> as <c>toPort</c> (ICMPv6 code). For more
        /// information, see <a href="https://en.wikipedia.org/wiki/Internet_Control_Message_Protocol_for_IPv6">Internet
        /// Control Message Protocol for IPv6</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PortInfo_ToPort { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Operation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CloseInstancePublicPortsResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CloseInstancePublicPortsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Operation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Close-LSInstancePublicPort (CloseInstancePublicPorts)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CloseInstancePublicPortsResponse, CloseLSInstancePublicPortCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InstanceName = this.InstanceName;
            #if MODULAR
            if (this.InstanceName == null && ParameterWasBound(nameof(this.InstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PortInfo_CidrListAlias != null)
            {
                context.PortInfo_CidrListAlias = new List<System.String>(this.PortInfo_CidrListAlias);
            }
            if (this.PortInfo_Cidr != null)
            {
                context.PortInfo_Cidr = new List<System.String>(this.PortInfo_Cidr);
            }
            context.PortInfo_FromPort = this.PortInfo_FromPort;
            if (this.PortInfo_Ipv6Cidr != null)
            {
                context.PortInfo_Ipv6Cidr = new List<System.String>(this.PortInfo_Ipv6Cidr);
            }
            context.PortInfo_Protocol = this.PortInfo_Protocol;
            context.PortInfo_ToPort = this.PortInfo_ToPort;
            
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
            var request = new Amazon.Lightsail.Model.CloseInstancePublicPortsRequest();
            
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
            }
            
             // populate PortInfo
            var requestPortInfoIsNull = true;
            request.PortInfo = new Amazon.Lightsail.Model.PortInfo();
            List<System.String> requestPortInfo_portInfo_CidrListAlias = null;
            if (cmdletContext.PortInfo_CidrListAlias != null)
            {
                requestPortInfo_portInfo_CidrListAlias = cmdletContext.PortInfo_CidrListAlias;
            }
            if (requestPortInfo_portInfo_CidrListAlias != null)
            {
                request.PortInfo.CidrListAliases = requestPortInfo_portInfo_CidrListAlias;
                requestPortInfoIsNull = false;
            }
            List<System.String> requestPortInfo_portInfo_Cidr = null;
            if (cmdletContext.PortInfo_Cidr != null)
            {
                requestPortInfo_portInfo_Cidr = cmdletContext.PortInfo_Cidr;
            }
            if (requestPortInfo_portInfo_Cidr != null)
            {
                request.PortInfo.Cidrs = requestPortInfo_portInfo_Cidr;
                requestPortInfoIsNull = false;
            }
            System.Int32? requestPortInfo_portInfo_FromPort = null;
            if (cmdletContext.PortInfo_FromPort != null)
            {
                requestPortInfo_portInfo_FromPort = cmdletContext.PortInfo_FromPort.Value;
            }
            if (requestPortInfo_portInfo_FromPort != null)
            {
                request.PortInfo.FromPort = requestPortInfo_portInfo_FromPort.Value;
                requestPortInfoIsNull = false;
            }
            List<System.String> requestPortInfo_portInfo_Ipv6Cidr = null;
            if (cmdletContext.PortInfo_Ipv6Cidr != null)
            {
                requestPortInfo_portInfo_Ipv6Cidr = cmdletContext.PortInfo_Ipv6Cidr;
            }
            if (requestPortInfo_portInfo_Ipv6Cidr != null)
            {
                request.PortInfo.Ipv6Cidrs = requestPortInfo_portInfo_Ipv6Cidr;
                requestPortInfoIsNull = false;
            }
            Amazon.Lightsail.NetworkProtocol requestPortInfo_portInfo_Protocol = null;
            if (cmdletContext.PortInfo_Protocol != null)
            {
                requestPortInfo_portInfo_Protocol = cmdletContext.PortInfo_Protocol;
            }
            if (requestPortInfo_portInfo_Protocol != null)
            {
                request.PortInfo.Protocol = requestPortInfo_portInfo_Protocol;
                requestPortInfoIsNull = false;
            }
            System.Int32? requestPortInfo_portInfo_ToPort = null;
            if (cmdletContext.PortInfo_ToPort != null)
            {
                requestPortInfo_portInfo_ToPort = cmdletContext.PortInfo_ToPort.Value;
            }
            if (requestPortInfo_portInfo_ToPort != null)
            {
                request.PortInfo.ToPort = requestPortInfo_portInfo_ToPort.Value;
                requestPortInfoIsNull = false;
            }
             // determine if request.PortInfo should be set to null
            if (requestPortInfoIsNull)
            {
                request.PortInfo = null;
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
        
        private Amazon.Lightsail.Model.CloseInstancePublicPortsResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CloseInstancePublicPortsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CloseInstancePublicPorts");
            try
            {
                #if DESKTOP
                return client.CloseInstancePublicPorts(request);
                #elif CORECLR
                return client.CloseInstancePublicPortsAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceName { get; set; }
            public List<System.String> PortInfo_CidrListAlias { get; set; }
            public List<System.String> PortInfo_Cidr { get; set; }
            public System.Int32? PortInfo_FromPort { get; set; }
            public List<System.String> PortInfo_Ipv6Cidr { get; set; }
            public Amazon.Lightsail.NetworkProtocol PortInfo_Protocol { get; set; }
            public System.Int32? PortInfo_ToPort { get; set; }
            public System.Func<Amazon.Lightsail.Model.CloseInstancePublicPortsResponse, CloseLSInstancePublicPortCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Operation;
        }
        
    }
}
