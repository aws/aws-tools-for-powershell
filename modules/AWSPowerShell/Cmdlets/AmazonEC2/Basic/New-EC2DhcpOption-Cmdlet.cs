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
    /// Creates a set of DHCP options for your VPC. After creating the set, you must associate
    /// it with the VPC, causing all existing and new instances that you launch in the VPC
    /// to use this set of DHCP options. The following are the individual DHCP options you
    /// can specify. For more information about the options, see <a href="http://www.ietf.org/rfc/rfc2132.txt">RFC
    /// 2132</a>.
    /// 
    ///  <ul><li><para><code>domain-name-servers</code> - The IP addresses of up to four domain name servers,
    /// or AmazonProvidedDNS. The default DHCP option set specifies AmazonProvidedDNS. If
    /// specifying more than one domain name server, specify the IP addresses in a single
    /// parameter, separated by commas. If you want your instance to receive a custom DNS
    /// hostname as specified in <code>domain-name</code>, you must set <code>domain-name-servers</code>
    /// to a custom DNS server.
    /// </para></li><li><para><code>domain-name</code> - If you're using AmazonProvidedDNS in <code>us-east-1</code>,
    /// specify <code>ec2.internal</code>. If you're using AmazonProvidedDNS in another region,
    /// specify <code>region.compute.internal</code> (for example, <code>ap-northeast-1.compute.internal</code>).
    /// Otherwise, specify a domain name (for example, <code>MyCompany.com</code>). This value
    /// is used to complete unqualified DNS hostnames. <b>Important</b>: Some Linux operating
    /// systems accept multiple domain names separated by spaces. However, Windows and other
    /// Linux operating systems treat the value as a single domain, which results in unexpected
    /// behavior. If your DHCP options set is associated with a VPC that has instances with
    /// multiple operating systems, specify only one domain name.
    /// </para></li><li><para><code>ntp-servers</code> - The IP addresses of up to four Network Time Protocol (NTP)
    /// servers.
    /// </para></li><li><para><code>netbios-name-servers</code> - The IP addresses of up to four NetBIOS name servers.
    /// </para></li><li><para><code>netbios-node-type</code> - The NetBIOS node type (1, 2, 4, or 8). We recommend
    /// that you specify 2 (broadcast and multicast are not currently supported). For more
    /// information about these node types, see <a href="http://www.ietf.org/rfc/rfc2132.txt">RFC
    /// 2132</a>.
    /// </para></li></ul><para>
    /// Your VPC automatically starts out with a set of DHCP options that includes only a
    /// DNS server that we provide (AmazonProvidedDNS). If you create a set of options, and
    /// if your VPC has an Internet gateway, make sure to set the <code>domain-name-servers</code>
    /// option either to <code>AmazonProvidedDNS</code> or to a domain name server of your
    /// choice. For more information about DHCP options, see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_DHCP_Options.html">DHCP
    /// Options Sets</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2DhcpOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.DhcpOptions")]
    [AWSCmdlet("Invokes the CreateDhcpOptions operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateDhcpOptions"})]
    [AWSCmdletOutput("Amazon.EC2.Model.DhcpOptions",
        "This cmdlet returns a DhcpOptions object.",
        "The service call response (type Amazon.EC2.Model.CreateDhcpOptionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2DhcpOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter DhcpConfiguration
        /// <summary>
        /// <para>
        /// <para>A DHCP configuration option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("DhcpConfigurations")]
        public Amazon.EC2.Model.DhcpConfiguration[] DhcpConfiguration { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DhcpConfiguration", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2DhcpOption (CreateDhcpOptions)"))
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
            
            if (this.DhcpConfiguration != null)
            {
                context.DhcpConfigurations = new List<Amazon.EC2.Model.DhcpConfiguration>(this.DhcpConfiguration);
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
            var request = new Amazon.EC2.Model.CreateDhcpOptionsRequest();
            
            if (cmdletContext.DhcpConfigurations != null)
            {
                request.DhcpConfigurations = cmdletContext.DhcpConfigurations;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DhcpOptions;
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
        
        private Amazon.EC2.Model.CreateDhcpOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateDhcpOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateDhcpOptions");
            #if DESKTOP
            return client.CreateDhcpOptions(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateDhcpOptionsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.DhcpConfiguration> DhcpConfigurations { get; set; }
        }
        
    }
}
