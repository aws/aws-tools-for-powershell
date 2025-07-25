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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Accepts a proposal request to attach a virtual private gateway or transit gateway
    /// to a Direct Connect gateway.
    /// </summary>
    [Cmdlet("Confirm", "DCDirectConnectGatewayAssociationProposal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGatewayAssociation")]
    [AWSCmdlet("Calls the AWS Direct Connect AcceptDirectConnectGatewayAssociationProposal API operation.", Operation = new[] {"AcceptDirectConnectGatewayAssociationProposal"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGatewayAssociation or Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.DirectConnectGatewayAssociation object.",
        "The service call response (type Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConfirmDCDirectConnectGatewayAssociationProposalCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedGatewayOwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the virtual private gateway or
        /// transit gateway.</para>
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
        public System.String AssociatedGatewayOwnerAccount { get; set; }
        #endregion
        
        #region Parameter DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway.</para>
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
        public System.String DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter OverrideAllowedPrefixesToDirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>Overrides the Amazon VPC prefixes advertised to the Direct Connect gateway.</para><para>For information about how to set the prefixes, see <a href="https://docs.aws.amazon.com/directconnect/latest/UserGuide/multi-account-associate-vgw.html#allowed-prefixes">Allowed
        /// Prefixes</a> in the <i>Direct Connect User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] OverrideAllowedPrefixesToDirectConnectGateway { get; set; }
        #endregion
        
        #region Parameter ProposalId
        /// <summary>
        /// <para>
        /// <para>The ID of the request proposal.</para>
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
        public System.String ProposalId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectConnectGatewayAssociation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectConnectGatewayAssociation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProposalId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-DCDirectConnectGatewayAssociationProposal (AcceptDirectConnectGatewayAssociationProposal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse, ConfirmDCDirectConnectGatewayAssociationProposalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociatedGatewayOwnerAccount = this.AssociatedGatewayOwnerAccount;
            #if MODULAR
            if (this.AssociatedGatewayOwnerAccount == null && ParameterWasBound(nameof(this.AssociatedGatewayOwnerAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociatedGatewayOwnerAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DirectConnectGatewayId = this.DirectConnectGatewayId;
            #if MODULAR
            if (this.DirectConnectGatewayId == null && ParameterWasBound(nameof(this.DirectConnectGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectConnectGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OverrideAllowedPrefixesToDirectConnectGateway != null)
            {
                context.OverrideAllowedPrefixesToDirectConnectGateway = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.OverrideAllowedPrefixesToDirectConnectGateway);
            }
            context.ProposalId = this.ProposalId;
            #if MODULAR
            if (this.ProposalId == null && ParameterWasBound(nameof(this.ProposalId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProposalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalRequest();
            
            if (cmdletContext.AssociatedGatewayOwnerAccount != null)
            {
                request.AssociatedGatewayOwnerAccount = cmdletContext.AssociatedGatewayOwnerAccount;
            }
            if (cmdletContext.DirectConnectGatewayId != null)
            {
                request.DirectConnectGatewayId = cmdletContext.DirectConnectGatewayId;
            }
            if (cmdletContext.OverrideAllowedPrefixesToDirectConnectGateway != null)
            {
                request.OverrideAllowedPrefixesToDirectConnectGateway = cmdletContext.OverrideAllowedPrefixesToDirectConnectGateway;
            }
            if (cmdletContext.ProposalId != null)
            {
                request.ProposalId = cmdletContext.ProposalId;
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
        
        private Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "AcceptDirectConnectGatewayAssociationProposal");
            try
            {
                return client.AcceptDirectConnectGatewayAssociationProposalAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssociatedGatewayOwnerAccount { get; set; }
            public System.String DirectConnectGatewayId { get; set; }
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> OverrideAllowedPrefixesToDirectConnectGateway { get; set; }
            public System.String ProposalId { get; set; }
            public System.Func<Amazon.DirectConnect.Model.AcceptDirectConnectGatewayAssociationProposalResponse, ConfirmDCDirectConnectGatewayAssociationProposalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectConnectGatewayAssociation;
        }
        
    }
}
