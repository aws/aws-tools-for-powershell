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
    /// Provides information to AWS about your VPN customer gateway device. The customer gateway
    /// is the appliance at your end of the VPN connection. (The device on the AWS side of
    /// the VPN connection is the virtual private gateway.) You must provide the Internet-routable
    /// IP address of the customer gateway's external interface. The IP address must be static
    /// and can't be behind a device performing network address translation (NAT).
    /// 
    ///  
    /// <para>
    /// For devices that use Border Gateway Protocol (BGP), you can also provide the device's
    /// BGP Autonomous System Number (ASN). You can use an existing ASN assigned to your network.
    /// If you don't have an ASN already, you can use a private ASN (in the 64512 - 65534
    /// range).
    /// </para><note><para>
    /// Amazon EC2 supports all 2-byte ASN numbers in the range of 1 - 65534, with the exception
    /// of 7224, which is reserved in the <code>us-east-1</code> region, and 9059, which is
    /// reserved in the <code>eu-west-1</code> region.
    /// </para></note><para>
    /// For more information about VPN customer gateways, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_VPN.html">Adding
    /// a Hardware Virtual Private Gateway to Your VPC</a> in the <i>Amazon Virtual Private
    /// Cloud User Guide</i>.
    /// </para><important><para>
    /// You cannot create more than one customer gateway with the same VPN type, IP address,
    /// and BGP ASN parameter values. If you run an identical request more than one time,
    /// the first request creates the customer gateway, and subsequent requests return information
    /// about the existing customer gateway. The subsequent requests do not create new customer
    /// gateway resources. 
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "EC2CustomerGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CustomerGateway")]
    [AWSCmdlet("Invokes the CreateCustomerGateway operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateCustomerGateway"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CustomerGateway",
        "This cmdlet returns a CustomerGateway object.",
        "The service call response (type CreateCustomerGatewayResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2CustomerGatewayCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>For devices that support BGP, the customer gateway's BGP ASN.</para><para>Default: 65000</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public Int32 BgpAsn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Internet-routable IP address for the customer gateway's outside interface. The
        /// address must be static.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("IpAddress")]
        public String PublicIp { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The type of VPN connection that this customer gateway supports (<code>ipsec.1</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public GatewayType Type { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Type", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2CustomerGateway (CreateCustomerGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("BgpAsn"))
                context.BgpAsn = this.BgpAsn;
            context.PublicIp = this.PublicIp;
            context.Type = this.Type;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateCustomerGatewayRequest();
            
            if (cmdletContext.BgpAsn != null)
            {
                request.BgpAsn = cmdletContext.BgpAsn.Value;
            }
            if (cmdletContext.PublicIp != null)
            {
                request.PublicIp = cmdletContext.PublicIp;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateCustomerGateway(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CustomerGateway;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Int32? BgpAsn { get; set; }
            public String PublicIp { get; set; }
            public GatewayType Type { get; set; }
        }
        
    }
}
