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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Creates a core network Connect peer for a specified core network connect attachment
    /// between a core network and an appliance. The peer address and transit gateway address
    /// must be the same IP address family (IPv4 or IPv6).
    /// </summary>
    [Cmdlet("New", "NMGRConnectPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.ConnectPeer")]
    [AWSCmdlet("Calls the AWS Network Manager CreateConnectPeer API operation.", Operation = new[] {"CreateConnectPeer"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.CreateConnectPeerResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.ConnectPeer or Amazon.NetworkManager.Model.CreateConnectPeerResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.ConnectPeer object.",
        "The service call response (type Amazon.NetworkManager.Model.CreateConnectPeerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewNMGRConnectPeerCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConnectAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the connection attachment.</para>
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
        public System.String ConnectAttachmentId { get; set; }
        #endregion
        
        #region Parameter CoreNetworkAddress
        /// <summary>
        /// <para>
        /// <para>A Connect peer core network address. This only applies only when the protocol is <c>GRE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CoreNetworkAddress { get; set; }
        #endregion
        
        #region Parameter InsideCidrBlock
        /// <summary>
        /// <para>
        /// <para>The inside IP addresses used for BGP peering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InsideCidrBlocks")]
        public System.String[] InsideCidrBlock { get; set; }
        #endregion
        
        #region Parameter PeerAddress
        /// <summary>
        /// <para>
        /// <para>The Connect peer address.</para>
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
        /// <para>The Peer ASN of the BGP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? BgpOptions_PeerAsn { get; set; }
        #endregion
        
        #region Parameter SubnetArn
        /// <summary>
        /// <para>
        /// <para>The subnet ARN for the Connect peer. This only applies only when the protocol is NO_ENCAP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the peer request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token associated with the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectPeer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.CreateConnectPeerResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.CreateConnectPeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectPeer";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectAttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NMGRConnectPeer (CreateConnectPeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.CreateConnectPeerResponse, NewNMGRConnectPeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BgpOptions_PeerAsn = this.BgpOptions_PeerAsn;
            context.ClientToken = this.ClientToken;
            context.ConnectAttachmentId = this.ConnectAttachmentId;
            #if MODULAR
            if (this.ConnectAttachmentId == null && ParameterWasBound(nameof(this.ConnectAttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectAttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CoreNetworkAddress = this.CoreNetworkAddress;
            if (this.InsideCidrBlock != null)
            {
                context.InsideCidrBlock = new List<System.String>(this.InsideCidrBlock);
            }
            context.PeerAddress = this.PeerAddress;
            #if MODULAR
            if (this.PeerAddress == null && ParameterWasBound(nameof(this.PeerAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter PeerAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubnetArn = this.SubnetArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.NetworkManager.Model.CreateConnectPeerRequest();
            
            
             // populate BgpOptions
            var requestBgpOptionsIsNull = true;
            request.BgpOptions = new Amazon.NetworkManager.Model.BgpOptions();
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectAttachmentId != null)
            {
                request.ConnectAttachmentId = cmdletContext.ConnectAttachmentId;
            }
            if (cmdletContext.CoreNetworkAddress != null)
            {
                request.CoreNetworkAddress = cmdletContext.CoreNetworkAddress;
            }
            if (cmdletContext.InsideCidrBlock != null)
            {
                request.InsideCidrBlocks = cmdletContext.InsideCidrBlock;
            }
            if (cmdletContext.PeerAddress != null)
            {
                request.PeerAddress = cmdletContext.PeerAddress;
            }
            if (cmdletContext.SubnetArn != null)
            {
                request.SubnetArn = cmdletContext.SubnetArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.NetworkManager.Model.CreateConnectPeerResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.CreateConnectPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "CreateConnectPeer");
            try
            {
                #if DESKTOP
                return client.CreateConnectPeer(request);
                #elif CORECLR
                return client.CreateConnectPeerAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConnectAttachmentId { get; set; }
            public System.String CoreNetworkAddress { get; set; }
            public List<System.String> InsideCidrBlock { get; set; }
            public System.String PeerAddress { get; set; }
            public System.String SubnetArn { get; set; }
            public List<Amazon.NetworkManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.NetworkManager.Model.CreateConnectPeerResponse, NewNMGRConnectPeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectPeer;
        }
        
    }
}
