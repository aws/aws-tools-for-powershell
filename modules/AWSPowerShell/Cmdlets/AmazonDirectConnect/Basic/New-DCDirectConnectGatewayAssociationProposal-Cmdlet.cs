/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a proposal to associate the specified virtual private gateway with the specified
    /// Direct Connect gateway.
    /// 
    ///  
    /// <para>
    /// You can only associate a Direct Connect gateway and virtual private gateway when the
    /// account that owns the Direct Connect gateway and the account that owns the virtual
    /// private gateway have the same payer ID.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCDirectConnectGatewayAssociationProposal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateDirectConnectGatewayAssociationProposal API operation.", Operation = new[] {"CreateDirectConnectGatewayAssociationProposal"})]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal",
        "This cmdlet returns a DirectConnectGatewayAssociationProposal object.",
        "The service call response (type Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDCDirectConnectGatewayAssociationProposalCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        #region Parameter AddAllowedPrefixesToDirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>The Amazon VPC prefixes to advertise to the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] AddAllowedPrefixesToDirectConnectGateway { get; set; }
        #endregion
        
        #region Parameter DirectConnectGatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectConnectGatewayId { get; set; }
        #endregion
        
        #region Parameter DirectConnectGatewayOwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS account that owns the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectConnectGatewayOwnerAccount { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter RemoveAllowedPrefixesToDirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>The Amazon VPC prefixes to no longer advertise to the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] RemoveAllowedPrefixesToDirectConnectGateway { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GatewayId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCDirectConnectGatewayAssociationProposal (CreateDirectConnectGatewayAssociationProposal)"))
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
            
            if (this.AddAllowedPrefixesToDirectConnectGateway != null)
            {
                context.AddAllowedPrefixesToDirectConnectGateway = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.AddAllowedPrefixesToDirectConnectGateway);
            }
            context.DirectConnectGatewayId = this.DirectConnectGatewayId;
            context.DirectConnectGatewayOwnerAccount = this.DirectConnectGatewayOwnerAccount;
            context.GatewayId = this.GatewayId;
            if (this.RemoveAllowedPrefixesToDirectConnectGateway != null)
            {
                context.RemoveAllowedPrefixesToDirectConnectGateway = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.RemoveAllowedPrefixesToDirectConnectGateway);
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
            var request = new Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalRequest();
            
            if (cmdletContext.AddAllowedPrefixesToDirectConnectGateway != null)
            {
                request.AddAllowedPrefixesToDirectConnectGateway = cmdletContext.AddAllowedPrefixesToDirectConnectGateway;
            }
            if (cmdletContext.DirectConnectGatewayId != null)
            {
                request.DirectConnectGatewayId = cmdletContext.DirectConnectGatewayId;
            }
            if (cmdletContext.DirectConnectGatewayOwnerAccount != null)
            {
                request.DirectConnectGatewayOwnerAccount = cmdletContext.DirectConnectGatewayOwnerAccount;
            }
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
            }
            if (cmdletContext.RemoveAllowedPrefixesToDirectConnectGateway != null)
            {
                request.RemoveAllowedPrefixesToDirectConnectGateway = cmdletContext.RemoveAllowedPrefixesToDirectConnectGateway;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DirectConnectGatewayAssociationProposal;
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
        
        private Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "CreateDirectConnectGatewayAssociationProposal");
            try
            {
                #if DESKTOP
                return client.CreateDirectConnectGatewayAssociationProposal(request);
                #elif CORECLR
                return client.CreateDirectConnectGatewayAssociationProposalAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> AddAllowedPrefixesToDirectConnectGateway { get; set; }
            public System.String DirectConnectGatewayId { get; set; }
            public System.String DirectConnectGatewayOwnerAccount { get; set; }
            public System.String GatewayId { get; set; }
            public List<Amazon.DirectConnect.Model.RouteFilterPrefix> RemoveAllowedPrefixesToDirectConnectGateway { get; set; }
        }
        
    }
}
