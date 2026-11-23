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
using Amazon.FSx;
using Amazon.FSx.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Updates an Amazon FSx for NetApp ONTAP cluster peer relationship.
    /// </summary>
    [Cmdlet("Update", "FSXClusterPeer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.ClusterPeer")]
    [AWSCmdlet("Calls the Amazon FSx UpdateClusterPeer API operation.", Operation = new[] {"UpdateClusterPeer"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateClusterPeerResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.ClusterPeer or Amazon.FSx.Model.UpdateClusterPeerResponse",
        "This cmdlet returns an Amazon.FSx.Model.ClusterPeer object.",
        "The service call response (type Amazon.FSx.Model.UpdateClusterPeerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFSXClusterPeerCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterPeerId
        /// <summary>
        /// <para>
        /// <para>The ID of the cluster peer that you want to update.</para>
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
        public System.String ClusterPeerId { get; set; }
        #endregion
        
        #region Parameter PeerAddress
        /// <summary>
        /// <para>
        /// <para>Specifies the IP addresses of the intercluster logical interfaces (LIFs) on the peer
        /// cluster. The addresses that you specify replace the existing peer addresses.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PeerAddresses")]
        public System.String[] PeerAddress { get; set; }
        #endregion
        
        #region Parameter PeerClusterName
        /// <summary>
        /// <para>
        /// <para>Specifies the name that the file system uses to identify the peer cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PeerClusterName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClusterPeer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateClusterPeerResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateClusterPeerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClusterPeer";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterPeerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXClusterPeer (UpdateClusterPeer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateClusterPeerResponse, UpdateFSXClusterPeerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterPeerId = this.ClusterPeerId;
            #if MODULAR
            if (this.ClusterPeerId == null && ParameterWasBound(nameof(this.ClusterPeerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterPeerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PeerAddress != null)
            {
                context.PeerAddress = new List<System.String>(this.PeerAddress);
            }
            context.PeerClusterName = this.PeerClusterName;
            
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
            var request = new Amazon.FSx.Model.UpdateClusterPeerRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterPeerId != null)
            {
                request.ClusterPeerId = cmdletContext.ClusterPeerId;
            }
            if (cmdletContext.PeerAddress != null)
            {
                request.PeerAddresses = cmdletContext.PeerAddress;
            }
            if (cmdletContext.PeerClusterName != null)
            {
                request.PeerClusterName = cmdletContext.PeerClusterName;
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
        
        private Amazon.FSx.Model.UpdateClusterPeerResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateClusterPeerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateClusterPeer");
            try
            {
                return client.UpdateClusterPeerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterPeerId { get; set; }
            public List<System.String> PeerAddress { get; set; }
            public System.String PeerClusterName { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateClusterPeerResponse, UpdateFSXClusterPeerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClusterPeer;
        }
        
    }
}
