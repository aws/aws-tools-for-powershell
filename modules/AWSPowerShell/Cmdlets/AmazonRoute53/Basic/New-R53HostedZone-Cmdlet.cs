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
    /// Creates a new public hosted zone, used to specify how the Domain Name System (DNS)
    /// routes traffic on the Internet for a domain, such as example.com, and its subdomains.
    /// 
    /// 
    ///  <important><para>
    /// Public hosted zones cannot be converted to a private hosted zone or vice versa. Instead,
    /// create a new hosted zone with the same name and create new resource record sets.
    /// </para></important><para>
    /// Send a <code>POST</code> request to the <code>/<i>Amazon Route 53 API version</i>/hostedzone</code>
    /// resource. The request body must include an XML document with a <code>CreateHostedZoneRequest</code>
    /// element. The response returns the <code>CreateHostedZoneResponse</code> element containing
    /// metadata about the hosted zone.
    /// </para><para>
    /// Fore more information about charges for hosted zones, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/pricing/">AmazonAmazon
    /// Route 53 Pricing</a>.
    /// </para><para>
    /// Note the following:
    /// </para><ul><li><para>
    /// You cannot create a hosted zone for a top-level domain (TLD).
    /// </para></li><li><para>
    /// Amazon Route 53 automatically creates a default SOA record and four NS records for
    /// the zone. For more information about SOA and NS records, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/SOA-NSrecords.html">NS
    /// and SOA Records that Amazon Route 53 Creates for a Hosted Zone</a> in the <i>Amazon
    /// Route 53 Developer Guide</i>.
    /// </para></li><li><para>
    /// If your domain is registered with a registrar other than Amazon Route 53, you must
    /// update the name servers with your registrar to make Amazon Route 53 your DNS service.
    /// For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/creating-migrating.html">Configuring
    /// Amazon Route 53 as your DNS Service</a> in the <i>Amazon Route 53 Developer's Guide</i>.
    /// </para></li></ul><para>
    /// After creating a zone, its initial status is <code>PENDING</code>. This means that
    /// it is not yet available on all DNS servers. The status of the zone changes to <code>INSYNC</code>
    /// when the NS and SOA records are available on all Amazon Route 53 DNS servers. 
    /// </para><para>
    /// When trying to create a hosted zone using a reusable delegation set, specify an optional
    /// DelegationSetId, and Amazon Route 53 would assign those 4 NS records for the zone,
    /// instead of alloting a new one.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53HostedZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateHostedZoneResponse")]
    [AWSCmdlet("Invokes the CreateHostedZone operation against Amazon Route 53.", Operation = new[] {"CreateHostedZone"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateHostedZoneResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateHostedZoneResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53HostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <code>CreateHostedZone</code>
        /// requests to be retried without the risk of executing the operation twice. You must
        /// use a unique <code>CallerReference</code> string every time you create a hosted zone.
        /// <code>CallerReference</code> can be any unique string, for example, a date/time stamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HostedZoneConfig_Comment
        /// <summary>
        /// <para>
        /// <para>Any comments that you want to include about the hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String HostedZoneConfig_Comment { get; set; }
        #endregion
        
        #region Parameter DelegationSetId
        /// <summary>
        /// <para>
        /// <para>If you want to associate a reusable delegation set with this hosted zone, the ID that
        /// Amazon Route 53 assigned to the reusable delegation set when you created it. For more
        /// information about reusable delegation sets, see <a>CreateReusableDelegationSet</a>.</para><dl><dt>Type</dt><dd><para>String</para></dd><dt>Default</dt><dd><para>None</para></dd><dt>Parent</dt><dd><para><code>CreatedHostedZoneRequest</code></para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DelegationSetId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the domain. For resource record types that include a domain name, specify
        /// a fully qualified domain name, for example, <i>www.example.com</i>. The trailing dot
        /// is optional; Amazon Route 53 assumes that the domain name is fully qualified. This
        /// means that Amazon Route 53 treats <i>www.example.com</i> (without a trailing dot)
        /// and <i>www.example.com.</i> (with a trailing dot) as identical.</para><para>If you're creating a public hosted zone, this is the name you have registered with
        /// your DNS registrar. If your domain name is registered with a registrar other than
        /// Amazon Route 53, change the name servers for your domain to the set of <code>NameServers</code>
        /// that <code>CreateHostedZone</code> returns in the DelegationSet element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter HostedZoneConfig_PrivateZone
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether this is a private hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HostedZoneConfig_PrivateZone { get; set; }
        #endregion
        
        #region Parameter VPC_VPCId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VPC_VPCId { get; set; }
        #endregion
        
        #region Parameter VPC_VPCRegion
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Route53.VPCRegion")]
        public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Name = this.Name;
            context.VPC_VPCRegion = this.VPC_VPCRegion;
            context.VPC_VPCId = this.VPC_VPCId;
            context.CallerReference = this.CallerReference;
            context.HostedZoneConfig_Comment = this.HostedZoneConfig_Comment;
            if (ParameterWasBound("HostedZoneConfig_PrivateZone"))
                context.HostedZoneConfig_PrivateZone = this.HostedZoneConfig_PrivateZone;
            context.DelegationSetId = this.DelegationSetId;
            
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
        
        private static Amazon.Route53.Model.CreateHostedZoneResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateHostedZoneRequest request)
        {
            #if DESKTOP
            return client.CreateHostedZone(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateHostedZoneAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
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
