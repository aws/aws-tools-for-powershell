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
    /// Disassociates one or more connections from the specified resiliency group. This operation
    /// is atomic: either all of the specified connections are disassociated, or the operation
    /// fails and no changes are made.
    /// </summary>
    [Cmdlet("Remove", "DCConnectionsFromResiliencyGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.DirectConnect.Model.ResiliencyGroupAssociation")]
    [AWSCmdlet("Calls the AWS Direct Connect DisassociateConnectionsFromResiliencyGroup API operation.", Operation = new[] {"DisassociateConnectionsFromResiliencyGroup"}, SelectReturnType = typeof(Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse))]
    [AWSCmdletOutput("Amazon.DirectConnect.Model.ResiliencyGroupAssociation or Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse",
        "This cmdlet returns a collection of Amazon.DirectConnect.Model.ResiliencyGroupAssociation objects.",
        "The service call response (type Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveDCConnectionsFromResiliencyGroupCmdlet : AmazonDirectConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectionIdentifier
        /// <summary>
        /// <para>
        /// <para>The IDs or ARNs of the connections to disassociate from the resiliency group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("ConnectionIdentifiers")]
        public System.String[] ConnectionIdentifier { get; set; }
        #endregion
        
        #region Parameter ResiliencyGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the resiliency group.</para>
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
        public System.String ResiliencyGroupId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResiliencyGroupAssociations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse).
        /// Specifying the name of a property of type Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResiliencyGroupAssociations";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DCConnectionsFromResiliencyGroup (DisassociateConnectionsFromResiliencyGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse, RemoveDCConnectionsFromResiliencyGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ConnectionIdentifier != null)
            {
                context.ConnectionIdentifier = new List<System.String>(this.ConnectionIdentifier);
            }
            #if MODULAR
            if (this.ConnectionIdentifier == null && ParameterWasBound(nameof(this.ConnectionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResiliencyGroupId = this.ResiliencyGroupId;
            #if MODULAR
            if (this.ResiliencyGroupId == null && ParameterWasBound(nameof(this.ResiliencyGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResiliencyGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectionIdentifier != null)
            {
                request.ConnectionIdentifiers = cmdletContext.ConnectionIdentifier;
            }
            if (cmdletContext.ResiliencyGroupId != null)
            {
                request.ResiliencyGroupId = cmdletContext.ResiliencyGroupId;
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
        
        private Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse CallAWSServiceOperation(IAmazonDirectConnect client, Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Direct Connect", "DisassociateConnectionsFromResiliencyGroup");
            try
            {
                return client.DisassociateConnectionsFromResiliencyGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<System.String> ConnectionIdentifier { get; set; }
            public System.String ResiliencyGroupId { get; set; }
            public System.Func<Amazon.DirectConnect.Model.DisassociateConnectionsFromResiliencyGroupResponse, RemoveDCConnectionsFromResiliencyGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResiliencyGroupAssociations;
        }
        
    }
}
