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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Creates a new public or private hosted zone. You create records in a public hosted
    /// zone to define how you want to route traffic on the internet for a domain, such as
    /// example.com, and its subdomains (apex.example.com, acme.example.com). You create records
    /// in a private hosted zone to define how you want to route traffic for a domain and
    /// its subdomains within one or more Amazon Virtual Private Clouds (Amazon VPCs). 
    /// 
    ///  <important><para>
    /// You can't convert a public hosted zone to a private hosted zone or vice versa. Instead,
    /// you must create a new hosted zone with the same name and create new resource record
    /// sets.
    /// </para></important><para>
    /// For more information about charges for hosted zones, see <a href="http://aws.amazon.com/route53/pricing/">Amazon
    /// Route 53 Pricing</a>.
    /// </para><para>
    /// Note the following:
    /// </para><ul><li><para>
    /// You can't create a hosted zone for a top-level domain (TLD) such as .com.
    /// </para></li><li><para>
    /// For public hosted zones, Route 53 automatically creates a default SOA record and four
    /// NS records for the zone. For more information about SOA and NS records, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/SOA-NSrecords.html">NS
    /// and SOA Records that Route 53 Creates for a Hosted Zone</a> in the <i>Amazon Route
    /// 53 Developer Guide</i>.
    /// </para><para>
    /// If you want to use the same name servers for multiple public hosted zones, you can
    /// optionally associate a reusable delegation set with the hosted zone. See the <code>DelegationSetId</code>
    /// element.
    /// </para></li><li><para>
    /// If your domain is registered with a registrar other than Route 53, you must update
    /// the name servers with your registrar to make Route 53 the DNS service for the domain.
    /// For more information, see <a href="https://docs.aws.amazon.com/Route53/latest/DeveloperGuide/MigratingDNS.html">Migrating
    /// DNS Service for an Existing Domain to Amazon Route 53</a> in the <i>Amazon Route 53
    /// Developer Guide</i>. 
    /// </para></li></ul><para>
    /// When you submit a <code>CreateHostedZone</code> request, the initial status of the
    /// hosted zone is <code>PENDING</code>. For public hosted zones, this means that the
    /// NS and SOA records are not yet available on all Route 53 DNS servers. When the NS
    /// and SOA records are available, the status of the zone changes to <code>INSYNC</code>.
    /// </para><para>
    /// The <code>CreateHostedZone</code> request requires the caller to have an <code>ec2:DescribeVpcs</code>
    /// permission.
    /// </para><note><para>
    /// When creating private hosted zones, the Amazon VPC must belong to the same partition
    /// where the hosted zone is created. A partition is a group of Amazon Web Services Regions.
    /// Each Amazon Web Services account is scoped to one partition.
    /// </para><para>
    /// The following are the supported partitions:
    /// </para><ul><li><para><code>aws</code> - Amazon Web Services Regions
    /// </para></li><li><para><code>aws-cn</code> - China Regions
    /// </para></li><li><para><code>aws-us-gov</code> - Amazon Web Services GovCloud (US) Region
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Access
    /// Management</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "R53HostedZone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateHostedZoneResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 CreateHostedZone API operation.", Operation = new[] {"CreateHostedZone"}, SelectReturnType = typeof(Amazon.Route53.Model.CreateHostedZoneResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateHostedZoneResponse",
        "This cmdlet returns an Amazon.Route53.Model.CreateHostedZoneResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53HostedZoneCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter CallerReference
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies the request and that allows failed <code>CreateHostedZone</code>
        /// requests to be retried without the risk of executing the operation twice. You must
        /// use a unique <code>CallerReference</code> string every time you submit a <code>CreateHostedZone</code>
        /// request. <code>CallerReference</code> can be any unique string, for example, a date/time
        /// stamp.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CallerReference { get; set; }
        #endregion
        
        #region Parameter HostedZoneConfig_Comment
        /// <summary>
        /// <para>
        /// <para>Any comments that you want to include about the hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String HostedZoneConfig_Comment { get; set; }
        #endregion
        
        #region Parameter DelegationSetId
        /// <summary>
        /// <para>
        /// <para>If you want to associate a reusable delegation set with this hosted zone, the ID that
        /// Amazon Route 53 assigned to the reusable delegation set when you created it. For more
        /// information about reusable delegation sets, see <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_CreateReusableDelegationSet.html">CreateReusableDelegationSet</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DelegationSetId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the domain. Specify a fully qualified domain name, for example, <i>www.example.com</i>.
        /// The trailing dot is optional; Amazon Route 53 assumes that the domain name is fully
        /// qualified. This means that Route 53 treats <i>www.example.com</i> (without a trailing
        /// dot) and <i>www.example.com.</i> (with a trailing dot) as identical.</para><para>If you're creating a public hosted zone, this is the name you have registered with
        /// your DNS registrar. If your domain name is registered with a registrar other than
        /// Route 53, change the name servers for your domain to the set of <code>NameServers</code>
        /// that <code>CreateHostedZone</code> returns in <code>DelegationSet</code>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter HostedZoneConfig_PrivateZone
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether this is a private hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HostedZoneConfig_PrivateZone { get; set; }
        #endregion
        
        #region Parameter VPC_VPCId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VPC_VPCId { get; set; }
        #endregion
        
        #region Parameter VPC_VPCRegion
        /// <summary>
        /// <para>
        /// <para>(Private hosted zones only) The region that an Amazon VPC was created in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53.VPCRegion")]
        public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.CreateHostedZoneResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.CreateHostedZoneResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53HostedZone (CreateHostedZone)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.CreateHostedZoneResponse, NewR53HostedZoneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VPC_VPCRegion = this.VPC_VPCRegion;
            context.VPC_VPCId = this.VPC_VPCId;
            context.CallerReference = this.CallerReference;
            #if MODULAR
            if (this.CallerReference == null && ParameterWasBound(nameof(this.CallerReference)))
            {
                WriteWarning("You are passing $null as a value for parameter CallerReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HostedZoneConfig_Comment = this.HostedZoneConfig_Comment;
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
            var requestVPCIsNull = true;
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
            var requestHostedZoneConfigIsNull = true;
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
        
        private Amazon.Route53.Model.CreateHostedZoneResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateHostedZoneRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "CreateHostedZone");
            try
            {
                #if DESKTOP
                return client.CreateHostedZone(request);
                #elif CORECLR
                return client.CreateHostedZoneAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public Amazon.Route53.VPCRegion VPC_VPCRegion { get; set; }
            public System.String VPC_VPCId { get; set; }
            public System.String CallerReference { get; set; }
            public System.String HostedZoneConfig_Comment { get; set; }
            public System.Boolean? HostedZoneConfig_PrivateZone { get; set; }
            public System.String DelegationSetId { get; set; }
            public System.Func<Amazon.Route53.Model.CreateHostedZoneResponse, NewR53HostedZoneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
