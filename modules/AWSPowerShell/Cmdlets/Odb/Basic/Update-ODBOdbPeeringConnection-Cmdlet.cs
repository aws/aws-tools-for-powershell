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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Modifies the settings of an Oracle Database@Amazon Web Services peering connection.
    /// You can update the display name and add or remove CIDR blocks from the peering connection.
    /// </summary>
    [Cmdlet("Update", "ODBOdbPeeringConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services UpdateOdbPeeringConnection API operation.", Operation = new[] {"UpdateOdbPeeringConnection"}, SelectReturnType = typeof(Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse",
        "This cmdlet returns an Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse object containing multiple properties."
    )]
    public partial class UpdateODBOdbPeeringConnectionCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A new display name for the peering connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter OdbPeeringConnectionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Oracle Database@Amazon Web Services peering connection to update.</para>
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
        public System.String OdbPeeringConnectionId { get; set; }
        #endregion
        
        #region Parameter PeerNetworkCidrsToBeAdded
        /// <summary>
        /// <para>
        /// <para>A list of CIDR blocks to add to the peering connection. These CIDR blocks define the
        /// IP address ranges that can communicate through the peering connection. The CIDR blocks
        /// must not overlap with existing CIDR blocks in the Oracle Database@Amazon Web Services
        /// network.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PeerNetworkCidrsToBeAdded { get; set; }
        #endregion
        
        #region Parameter PeerNetworkCidrsToBeRemoved
        /// <summary>
        /// <para>
        /// <para>A list of CIDR blocks to remove from the peering connection. The CIDR blocks must
        /// currently exist in the peering connection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PeerNetworkCidrsToBeRemoved { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OdbPeeringConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ODBOdbPeeringConnection (UpdateOdbPeeringConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse, UpdateODBOdbPeeringConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DisplayName = this.DisplayName;
            context.OdbPeeringConnectionId = this.OdbPeeringConnectionId;
            #if MODULAR
            if (this.OdbPeeringConnectionId == null && ParameterWasBound(nameof(this.OdbPeeringConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter OdbPeeringConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PeerNetworkCidrsToBeAdded != null)
            {
                context.PeerNetworkCidrsToBeAdded = new List<System.String>(this.PeerNetworkCidrsToBeAdded);
            }
            if (this.PeerNetworkCidrsToBeRemoved != null)
            {
                context.PeerNetworkCidrsToBeRemoved = new List<System.String>(this.PeerNetworkCidrsToBeRemoved);
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
            var request = new Amazon.Odb.Model.UpdateOdbPeeringConnectionRequest();
            
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.OdbPeeringConnectionId != null)
            {
                request.OdbPeeringConnectionId = cmdletContext.OdbPeeringConnectionId;
            }
            if (cmdletContext.PeerNetworkCidrsToBeAdded != null)
            {
                request.PeerNetworkCidrsToBeAdded = cmdletContext.PeerNetworkCidrsToBeAdded;
            }
            if (cmdletContext.PeerNetworkCidrsToBeRemoved != null)
            {
                request.PeerNetworkCidrsToBeRemoved = cmdletContext.PeerNetworkCidrsToBeRemoved;
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
        
        private Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.UpdateOdbPeeringConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "UpdateOdbPeeringConnection");
            try
            {
                return client.UpdateOdbPeeringConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DisplayName { get; set; }
            public System.String OdbPeeringConnectionId { get; set; }
            public List<System.String> PeerNetworkCidrsToBeAdded { get; set; }
            public List<System.String> PeerNetworkCidrsToBeRemoved { get; set; }
            public System.Func<Amazon.Odb.Model.UpdateOdbPeeringConnectionResponse, UpdateODBOdbPeeringConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
