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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a Connect peer for a specified transit gateway Connect attachment between
    /// a transit gateway and an appliance.
    /// 
    ///  
    /// <para>
    /// The peer address and transit gateway address must be the same IP address family (IPv4
    /// or IPv6).
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/tgw/tgw-connect.html#tgw-connect-peer">Connect
    /// peers</a> in the <i>Amazon Web Services Transit Gateways Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2TransitGatewayConnectPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayConnectPeer")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTransitGatewayConnectPeer API operation.", Operation = new[] {"CreateTransitGatewayConnectPeer"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayConnectPeer or Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayConnectPeer object.",
        "The service call response (type Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TransitGatewayConnectPeerCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InsideCidrBlock
        /// <summary>
        /// <para>
        /// <para>The range of inside IP addresses that are used for BGP peering. You must specify a
        /// size /29 IPv4 CIDR block from the <c>169.254.0.0/16</c> range. The first address from
        /// the range must be configured on the appliance as the BGP IP address. You can also
        /// optionally specify a size /125 IPv6 CIDR block from the <c>fd00::/8</c> range.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InsideCidrBlocks")]
        public System.String[] InsideCidrBlock { get; set; }
        #endregion
        
        #region Parameter PeerAddress
        /// <summary>
        /// <para>
        /// <para>The peer IP address (GRE outer IP address) on the appliance side of the Connect peer.</para>
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
        public System.String PeerAddress { get; set; }
        #endregion
        
        #region Parameter BgpOptions_PeerAsn
        /// <summary>
        /// <para>
        /// <para>The peer Autonomous System Number (ASN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? BgpOptions_PeerAsn { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Connect peer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAddress
        /// <summary>
        /// <para>
        /// <para>The peer IP address (GRE outer IP address) on the transit gateway side of the Connect
        /// peer, which must be specified from a transit gateway CIDR block. If not specified,
        /// Amazon automatically assigns the first available IP address from the transit gateway
        /// CIDR block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayAddress { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the Connect attachment.</para>
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
        public System.String TransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayConnectPeer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayConnectPeer";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransitGatewayAttachmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransitGatewayAttachmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransitGatewayAttachmentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayAttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TransitGatewayConnectPeer (CreateTransitGatewayConnectPeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse, NewEC2TransitGatewayConnectPeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransitGatewayAttachmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BgpOptions_PeerAsn = this.BgpOptions_PeerAsn;
            if (this.InsideCidrBlock != null)
            {
                context.InsideCidrBlock = new List<System.String>(this.InsideCidrBlock);
            }
            #if MODULAR
            if (this.InsideCidrBlock == null && ParameterWasBound(nameof(this.InsideCidrBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter InsideCidrBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PeerAddress = this.PeerAddress;
            #if MODULAR
            if (this.PeerAddress == null && ParameterWasBound(nameof(this.PeerAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TransitGatewayAddress = this.TransitGatewayAddress;
            context.TransitGatewayAttachmentId = this.TransitGatewayAttachmentId;
            #if MODULAR
            if (this.TransitGatewayAttachmentId == null && ParameterWasBound(nameof(this.TransitGatewayAttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayAttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.EC2.Model.CreateTransitGatewayConnectPeerRequest();
            
            
             // populate BgpOptions
            var requestBgpOptionsIsNull = true;
            request.BgpOptions = new Amazon.EC2.Model.TransitGatewayConnectRequestBgpOptions();
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
             // determine if request.BgpOptions should be set to null
            if (requestBgpOptionsIsNull)
            {
                request.BgpOptions = null;
            }
            if (cmdletContext.InsideCidrBlock != null)
            {
                request.InsideCidrBlocks = cmdletContext.InsideCidrBlock;
            }
            if (cmdletContext.PeerAddress != null)
            {
                request.PeerAddress = cmdletContext.PeerAddress;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TransitGatewayAddress != null)
            {
                request.TransitGatewayAddress = cmdletContext.TransitGatewayAddress;
            }
            if (cmdletContext.TransitGatewayAttachmentId != null)
            {
                request.TransitGatewayAttachmentId = cmdletContext.TransitGatewayAttachmentId;
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
        
        private Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTransitGatewayConnectPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTransitGatewayConnectPeer");
            try
            {
                #if DESKTOP
                return client.CreateTransitGatewayConnectPeer(request);
                #elif CORECLR
                return client.CreateTransitGatewayConnectPeerAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? BgpOptions_PeerAsn { get; set; }
            public List<System.String> InsideCidrBlock { get; set; }
            public System.String PeerAddress { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String TransitGatewayAddress { get; set; }
            public System.String TransitGatewayAttachmentId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTransitGatewayConnectPeerResponse, NewEC2TransitGatewayConnectPeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayConnectPeer;
        }
        
    }
}
