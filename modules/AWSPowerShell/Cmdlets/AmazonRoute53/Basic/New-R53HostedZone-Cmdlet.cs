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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// This action creates a new hosted zone.
    /// 
    ///  
    /// <para>
    /// To create a new hosted zone, send a <code>POST</code> request to the <code>2013-04-01/hostedzone</code>
    /// resource. The request body must include an XML document with a <code>CreateHostedZoneRequest</code>
    /// element. The response returns the <code>CreateHostedZoneResponse</code> element that
    /// contains metadata about the hosted zone.
    /// </para><para>
    /// Route 53 automatically creates a default SOA record and four NS records for the zone.
    /// The NS records in the hosted zone are the name servers you give your registrar to
    /// delegate your domain to. For more information about SOA and NS records, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/SOA-NSrecords.html">NS
    /// and SOA Records that Route 53 Creates for a Hosted Zone</a> in the <i>Amazon Route
    /// 53 Developer Guide</i>.
    /// </para><para>
    /// When you create a zone, its initial status is <code>PENDING</code>. This means that
    /// it is not yet available on all DNS servers. The status of the zone changes to <code>INSYNC</code>
    /// when the NS and SOA records are available on all Route 53 DNS servers. 
    /// </para><para>
    /// When trying to create a hosted zone using a reusable delegation set, you could specify
    /// an optional DelegationSetId, and Route53 would assign those 4 NS records for the zone,
    /// instead of alloting a new one.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53HostedZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateHostedZoneResponse")]
    [AWSCmdlet("Invokes the CreateHostedZone operation against Amazon Route 53.", Operation = new[] {"CreateHostedZone"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateHostedZoneResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateHostedZoneResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewR53HostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <code>CreateHostedZone</code>
        /// requests to be retried without the risk of executing the operation twice. You must
        /// use a unique <code>CallerReference</code> string every time you create a hosted zone.
        /// <code>CallerReference</code> can be any unique string; you might choose to use a string
        /// that identifies your project, such as <code>DNSMigration_01</code>.</para><para>Valid characters are any Unicode code points that are legal in an XML 1.0 document.
        /// The UTF-8 encoding of the value must be less than 128 bytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String CallerReference { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An optional comment about your hosted zone. If you don't want to specify a comment,
        /// you can omit the <code>HostedZoneConfig</code> and <code>Comment</code> elements from
        /// the XML document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String HostedZoneConfig_Comment { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The delegation set id of the reusable delgation set whose NS records you want to assign
        /// to the new hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DelegationSetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the domain. This must be a fully-specified domain, for example, www.example.com.
        /// The trailing dot is optional; Route 53 assumes that the domain name is fully qualified.
        /// This means that Route 53 treats www.example.com (without a trailing dot) and www.example.com.
        /// (with a trailing dot) as identical.</para><para>This is the name you have registered with your DNS registrar. You should ask your
        /// registrar to change the authoritative name servers for your domain to the set of <code>NameServers</code>
        /// elements returned in <code>DelegationSet</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether this is a private hosted zone. The value is returned
        /// in the response; do not specify it in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HostedZoneConfig_PrivateZone { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VPC_VPCId { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53HostedZone (CreateHostedZone)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Name = this.Name;
            context.VPC_VPCRegion = this.VPC_VPCRegion;
            context.VPC_VPCId = this.VPC_VPCId;
            context.CallerReference = this.CallerReference;
            context.HostedZoneConfig_Comment = this.HostedZoneConfig_Comment;
            if (ParameterWasBound("HostedZoneConfig_PrivateZone"))
                context.HostedZoneConfig_PrivateZone = this.HostedZoneConfig_PrivateZone;
            context.DelegationSetId = this.DelegationSetId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.CreateHostedZoneRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate VPC
            bool requestVPCIsNull = true;
            request.VPC = new Amazon.Route53.Model.VPC();
            Amazon.Route53.VPCRegion requestVPC_vPC_VPCRegion = null;
            if (cmdletContext.VPC_VPCRegion != null)
            {
                requestVPC_vPC_VPCRegion = cmdletContext.VPC_VPCRegion;
            }
            if (requestVPC_vPC_VPCRegion != null)
            {
                request.VPC.VPCRegion = requestVPC_vPC_VPCRegion;
                requestVPCIsNull = false;
            }
            System.String requestVPC_vPC_VPCId = null;
            if (cmdletContext.VPC_VPCId != null)
            {
                requestVPC_vPC_VPCId = cmdletContext.VPC_VPCId;
            }
            if (requestVPC_vPC_VPCId != null)
            {
                request.VPC.VPCId = requestVPC_vPC_VPCId;
                requestVPCIsNull = false;
            }
             // determine if request.VPC should be set to null
            if (requestVPCIsNull)
            {
                request.VPC = null;
            }
            if (cmdletContext.CallerReference != null)
            {
                request.CallerReference = cmdletContext.CallerReference;
            }
            
             // populate HostedZoneConfig
            bool requestHostedZoneConfigIsNull = true;
            request.HostedZoneConfig = new Amazon.Route53.Model.HostedZoneConfig();
            System.String requestHostedZoneConfig_hostedZoneConfig_Comment = null;
            if (cmdletContext.HostedZoneConfig_Comment != null)
            {
                requestHostedZoneConfig_hostedZoneConfig_Comment = cmdletContext.HostedZoneConfig_Comment;
            }
            if (requestHostedZoneConfig_hostedZoneConfig_Comment != null)
            {
                request.HostedZoneConfig.Comment = requestHostedZoneConfig_hostedZoneConfig_Comment;
                requestHostedZoneConfigIsNull = false;
            }
            System.Boolean? requestHostedZoneConfig_hostedZoneConfig_PrivateZone = null;
            if (cmdletContext.HostedZoneConfig_PrivateZone != null)
            {
                requestHostedZoneConfig_hostedZoneConfig_PrivateZone = cmdletContext.HostedZoneConfig_PrivateZone.Value;
            }
            if (requestHostedZoneConfig_hostedZoneConfig_PrivateZone != null)
            {
                request.HostedZoneConfig.PrivateZone = requestHostedZoneConfig_hostedZoneConfig_PrivateZone.Value;
                requestHostedZoneConfigIsNull = false;
            }
             // determine if request.HostedZoneConfig should be set to null
            if (requestHostedZoneConfigIsNull)
            {
                request.HostedZoneConfig = null;
            }
            if (cmdletContext.DelegationSetId != null)
            {
                request.DelegationSetId = cmdletContext.DelegationSetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateHostedZone(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Name { get; set; }
            public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
            public System.String VPC_VPCId { get; set; }
            public System.String CallerReference { get; set; }
            public System.String HostedZoneConfig_Comment { get; set; }
            public System.Boolean? HostedZoneConfig_PrivateZone { get; set; }
            public System.String DelegationSetId { get; set; }
        }
        
    }
}
