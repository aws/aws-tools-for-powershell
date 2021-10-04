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
    /// Creates a proposal to associate the specified virtual private gateway or transit gateway
    /// with the specified Direct Connect gateway.
    /// 
    ///  
    /// <para>
    /// You can associate a Direct Connect gateway and virtual private gateway or transit
    /// gateway that is owned by any Amazon Web Services account. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "DCDirectConnectGatewayAssociationProposal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal")]
    [AWSCmdlet("Calls the AWS Direct Connect CreateDirectConnectGatewayAssociationProposal API operation.", Operation = new[] {"CreateDirectConnectGatewayAssociationProposal"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal or Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse",
        "This cmdlet returns an Amazon.DirectConnect.Model.DirectConnectGatewayAssociationProposal object.",
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] AddAllowedPrefixesToDirectConnectGateway { get; set; }
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
        
        #region Parameter DirectConnectGatewayOwnerAccount
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that owns the Direct Connect gateway.</para>
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
        public System.String DirectConnectGatewayOwnerAccount { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the virtual private gateway or transit gateway.</para>
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
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter RemoveAllowedPrefixesToDirectConnectGateway
        /// <summary>
        /// <para>
        /// <para>The Amazon VPC prefixes to no longer advertise to the Direct Connect gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DirectConnect.Model.RouteFilterPrefix[] RemoveAllowedPrefixesToDirectConnectGateway { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DirectConnectGatewayAssociationProposal'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DirectConnectGatewayAssociationProposal";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DCDirectConnectGatewayAssociationProposal (CreateDirectConnectGatewayAssociationProposal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse, NewDCDirectConnectGatewayAssociationProposalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddAllowedPrefixesToDirectConnectGateway != null)
            {
                context.AddAllowedPrefixesToDirectConnectGateway = new List<Amazon.DirectConnect.Model.RouteFilterPrefix>(this.AddAllowedPrefixesToDirectConnectGateway);
            }
            context.DirectConnectGatewayId = this.DirectConnectGatewayId;
            #if MODULAR
            if (this.DirectConnectGatewayId == null && ParameterWasBound(nameof(this.DirectConnectGatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectConnectGatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DirectConnectGatewayOwnerAccount = this.DirectConnectGatewayOwnerAccount;
            #if MODULAR
            if (this.DirectConnectGatewayOwnerAccount == null && ParameterWasBound(nameof(this.DirectConnectGatewayOwnerAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectConnectGatewayOwnerAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayId = this.GatewayId;
            #if MODULAR
            if (this.GatewayId == null && ParameterWasBound(nameof(this.GatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            public System.Func<Amazon.DirectConnect.Model.CreateDirectConnectGatewayAssociationProposalResponse, NewDCDirectConnectGatewayAssociationProposalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DirectConnectGatewayAssociationProposal;
        }
        
    }
}
