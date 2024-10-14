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
using Amazon.DirectConnect;
using Amazon.DirectConnect.Model;

namespace Amazon.PowerShell.Cmdlets.DC
{
    /// <summary>
    /// Deletes the association proposal request between the specified Direct Connect gateway
    /// and virtual private gateway or transit gateway.
    /// </summary>
    [Cmdlet("Remove", "DCDirectConnectGatewayAssociationProposal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal")]
    [AWSCmdlet("Calls the AWS Direct Connect DeleteDirectConnectGatewayAssociationProposal API operation.", Operation = new[] {"DeleteDirectConnectGatewayAssociationProposal"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal or Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal object.",
        "The service call response (type Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveDCDirectConnectGatewayAssociationProposalCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProposalId
        /// <summary>
        /// <para>
        /// <para>The ID of the proposal.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectConnectGatewayAssociationProposal'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectConnectGatewayAssociationProposal";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProposalId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProposalId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProposalId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProposalId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DCDirectConnectGatewayAssociationProposal (DeleteDirectConnectGatewayAssociationProposal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse, RemoveDCDirectConnectGatewayAssociationProposalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProposalId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalRequest();
            
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
        
        private Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DeleteDirectConnectGatewayAssociationProposal");
            try
            {
                #if DESKTOP
                return client.DeleteDirectConnectGatewayAssociationProposal(request);
                #elif CORECLR
                return client.DeleteDirectConnectGatewayAssociationProposalAsync(request).GetAwaiter().GetResult();
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
            public System.String ProposalId { get; set; }
            public System.Func<Amazon.DirectConnect.Model.DeleteDirectConnectGatewayAssociationProposalResponse, RemoveDCDirectConnectGatewayAssociationProposalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectConnectGatewayAssociationProposal;
        }
        
    }
}
