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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Change the settings for a Cluster.
    /// </summary>
    [Cmdlet("Update", "EMLCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.UpdateClusterResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateCluster API operation.", Operation = new[] {"UpdateCluster"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateClusterResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.UpdateClusterResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.UpdateClusterResponse object containing multiple properties."
    )]
    public partial class UpdateEMLClusterCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// The ID of the cluster
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
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter NetworkSettings_DefaultRoute
        /// <summary>
        /// <para>
        /// Include this parameter only if you want to
        /// change the default route for the Cluster. Specify one network interface as the default
        /// route for traffic to and from the node. MediaLive Anywhere uses this default when
        /// the destination for the traffic isn't covered by the route table for any of the networks.
        /// Specify the value of the appropriate logicalInterfaceName parameter that you create
        /// in the interfaceMappings.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkSettings_DefaultRoute { get; set; }
        #endregion
        
        #region Parameter NetworkSettings_InterfaceMapping
        /// <summary>
        /// <para>
        /// An array of interfaceMapping objects
        /// for this Cluster. Include this parameter only if you want to change the interface
        /// mappings for the Cluster. Typically, you change the interface mappings only to fix
        /// an error you made when creating the mapping. In an update request, make sure that
        /// you enter the entire set of mappings again, not just the mappings that you want to
        /// add or change. You define this mapping so that the mapping can be used by all the
        /// Nodes. Each mapping logically connects one interface on the nodes with one Network.
        /// Each mapping consists of a pair of parameters. The logicalInterfaceName parameter
        /// creates a logical name for the Node interface that handles a specific type of traffic.
        /// For example, my-Inputs-Interface. The networkID parameter refers to the ID of the
        /// network. When you create the Nodes in this Cluster, you will associate the logicalInterfaceName
        /// with the appropriate physical interface.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkSettings_InterfaceMappings")]
        public Amazon.MediaLive.Model.InterfaceMappingUpdateRequest[] NetworkSettings_InterfaceMapping { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// Include this parameter only if you want to change
        /// the current name of the Cluster. Specify a name that is unique in the AWS account.
        /// You can't change the name. Names are case-sensitive.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateClusterResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateClusterResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLCluster (UpdateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateClusterResponse, UpdateEMLClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterId = this.ClusterId;
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.NetworkSettings_DefaultRoute = this.NetworkSettings_DefaultRoute;
            if (this.NetworkSettings_InterfaceMapping != null)
            {
                context.NetworkSettings_InterfaceMapping = new List<Amazon.MediaLive.Model.InterfaceMappingUpdateRequest>(this.NetworkSettings_InterfaceMapping);
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
            var request = new Amazon.MediaLive.Model.UpdateClusterRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkSettings
            var requestNetworkSettingsIsNull = true;
            request.NetworkSettings = new Amazon.MediaLive.Model.ClusterNetworkSettingsUpdateRequest();
            System.String requestNetworkSettings_networkSettings_DefaultRoute = null;
            if (cmdletContext.NetworkSettings_DefaultRoute != null)
            {
                requestNetworkSettings_networkSettings_DefaultRoute = cmdletContext.NetworkSettings_DefaultRoute;
            }
            if (requestNetworkSettings_networkSettings_DefaultRoute != null)
            {
                request.NetworkSettings.DefaultRoute = requestNetworkSettings_networkSettings_DefaultRoute;
                requestNetworkSettingsIsNull = false;
            }
            List<Amazon.MediaLive.Model.InterfaceMappingUpdateRequest> requestNetworkSettings_networkSettings_InterfaceMapping = null;
            if (cmdletContext.NetworkSettings_InterfaceMapping != null)
            {
                requestNetworkSettings_networkSettings_InterfaceMapping = cmdletContext.NetworkSettings_InterfaceMapping;
            }
            if (requestNetworkSettings_networkSettings_InterfaceMapping != null)
            {
                request.NetworkSettings.InterfaceMappings = requestNetworkSettings_networkSettings_InterfaceMapping;
                requestNetworkSettingsIsNull = false;
            }
             // determine if request.NetworkSettings should be set to null
            if (requestNetworkSettingsIsNull)
            {
                request.NetworkSettings = null;
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
        
        private Amazon.MediaLive.Model.UpdateClusterResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateCluster");
            try
            {
                return client.UpdateClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterId { get; set; }
            public System.String Name { get; set; }
            public System.String NetworkSettings_DefaultRoute { get; set; }
            public List<Amazon.MediaLive.Model.InterfaceMappingUpdateRequest> NetworkSettings_InterfaceMapping { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateClusterResponse, UpdateEMLClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
