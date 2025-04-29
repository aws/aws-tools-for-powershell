/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a new BGP peer for a specified route server endpoint.
    /// 
    ///  
    /// <para>
    /// A route server peer is a session between a route server endpoint and the device deployed
    /// in Amazon Web Services (such as a firewall appliance or other network security function
    /// running on an EC2 instance). The device must meet these requirements:
    /// </para><ul><li><para>
    /// Have an elastic network interface in the VPC
    /// </para></li><li><para>
    /// Support BGP (Border Gateway Protocol)
    /// </para></li><li><para>
    /// Can initiate BGP sessions
    /// </para></li></ul><para>
    /// For more information see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/dynamic-routing-route-server.html">Dynamic
    /// routing in your VPC with VPC Route Server</a> in the <i>Amazon VPC User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2RouteServerPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.RouteServerPeer")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateRouteServerPeer API operation.", Operation = new[] {"CreateRouteServerPeer"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateRouteServerPeerResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.RouteServerPeer or Amazon.EC2.Model.CreateRouteServerPeerResponse",
        "This cmdlet returns an Amazon.EC2.Model.RouteServerPeer object.",
        "The service call response (type Amazon.EC2.Model.CreateRouteServerPeerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2RouteServerPeerCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>A check for whether you have the required permissions for the action without actually
        /// making the request and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter PeerAddress
        /// <summary>
        /// <para>
        /// <para>The IPv4 address of the peer device.</para>
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
        public System.String PeerAddress { get; set; }
        #endregion
        
        #region Parameter BgpOptions_PeerAsn
        /// <summary>
        /// <para>
        /// <para>The Border Gateway Protocol (BGP) Autonomous System Number (ASN) for the appliance.
        /// Valid values are from 1 to 4294967295. We recommend using a private ASN in the 64512–65534
        /// (16-bit ASN) or 4200000000–4294967294 (32-bit ASN) range.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? BgpOptions_PeerAsn { get; set; }
        #endregion
        
        #region Parameter BgpOptions_PeerLivenessDetection
        /// <summary>
        /// <para>
        /// <para>The requested liveness detection protocol for the BGP peer.</para><ul><li><para><c>bgp-keepalive</c>: The standard BGP keep alive mechanism (<a href="https://www.rfc-editor.org/rfc/rfc4271#page-21">RFC4271</a>)
        /// that is stable but may take longer to fail-over in cases of network impact or router
        /// failure.</para></li><li><para><c>bfd</c>: An additional Bidirectional Forwarding Detection (BFD) protocol (<a href="https://www.rfc-editor.org/rfc/rfc5880">RFC5880</a>)
        /// that enables fast failover by using more sensitive liveness detection.</para></li></ul><para>Defaults to <c>bgp-keepalive</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.RouteServerPeerLivenessMode")]
        public Amazon.EC2.RouteServerPeerLivenessMode BgpOptions_PeerLivenessDetection { get; set; }
        #endregion
        
        #region Parameter RouteServerEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the route server endpoint for which to create a peer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RouteServerEndpointId { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the route server peer during creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RouteServerPeer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateRouteServerPeerResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateRouteServerPeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RouteServerPeer";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RouteServerEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2RouteServerPeer (CreateRouteServerPeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateRouteServerPeerResponse, NewEC2RouteServerPeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BgpOptions_PeerAsn = this.BgpOptions_PeerAsn;
            #if MODULAR
            if (this.BgpOptions_PeerAsn == null && ParameterWasBound(nameof(this.BgpOptions_PeerAsn)))
            {
                WriteWarning("You are passing $null as a value for parameter BgpOptions_PeerAsn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BgpOptions_PeerLivenessDetection = this.BgpOptions_PeerLivenessDetection;
            context.DryRun = this.DryRun;
            context.PeerAddress = this.PeerAddress;
            #if MODULAR
            if (this.PeerAddress == null && ParameterWasBound(nameof(this.PeerAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RouteServerEndpointId = this.RouteServerEndpointId;
            #if MODULAR
            if (this.RouteServerEndpointId == null && ParameterWasBound(nameof(this.RouteServerEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter RouteServerEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateRouteServerPeerRequest();
            
            
             // populate BgpOptions
            var requestBgpOptionsIsNull = true;
            request.BgpOptions = new Amazon.EC2.Model.RouteServerBgpOptionsRequest();
            System.Int64? requestBgpOptions_bgpOptions_PeerAsn = null;
            if (cmdletContext.BgpOptions_PeerAsn != null)
            {
                requestBgpOptions_bgpOptions_PeerAsn = cmdletContext.BgpOptions_PeerAsn.Value;
            }
            if (requestBgpOptions_bgpOptions_PeerAsn != null)
            {
                request.BgpOptions.PeerAsn = requestBgpOptions_bgpOptions_PeerAsn.Value;
                requestBgpOptionsIsNull = false;
            }
            Amazon.EC2.RouteServerPeerLivenessMode requestBgpOptions_bgpOptions_PeerLivenessDetection = null;
            if (cmdletContext.BgpOptions_PeerLivenessDetection != null)
            {
                requestBgpOptions_bgpOptions_PeerLivenessDetection = cmdletContext.BgpOptions_PeerLivenessDetection;
            }
            if (requestBgpOptions_bgpOptions_PeerLivenessDetection != null)
            {
                request.BgpOptions.PeerLivenessDetection = requestBgpOptions_bgpOptions_PeerLivenessDetection;
                requestBgpOptionsIsNull = false;
            }
             // determine if request.BgpOptions should be set to null
            if (requestBgpOptionsIsNull)
            {
                request.BgpOptions = null;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.PeerAddress != null)
            {
                request.PeerAddress = cmdletContext.PeerAddress;
            }
            if (cmdletContext.RouteServerEndpointId != null)
            {
                request.RouteServerEndpointId = cmdletContext.RouteServerEndpointId;
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
        
        private Amazon.EC2.Model.CreateRouteServerPeerResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateRouteServerPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateRouteServerPeer");
            try
            {
                return client.CreateRouteServerPeerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? BgpOptions_PeerAsn { get; set; }
            public Amazon.EC2.RouteServerPeerLivenessMode BgpOptions_PeerLivenessDetection { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String PeerAddress { get; set; }
            public System.String RouteServerEndpointId { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateRouteServerPeerResponse, NewEC2RouteServerPeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RouteServerPeer;
        }
        
    }
}
