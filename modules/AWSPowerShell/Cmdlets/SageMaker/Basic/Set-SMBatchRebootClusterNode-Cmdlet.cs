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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Reboots specific nodes within a SageMaker HyperPod cluster using a soft recovery mechanism.
    /// <c>BatchRebootClusterNodes</c> performs a graceful reboot of the specified nodes by
    /// calling the Amazon Elastic Compute Cloud <c>RebootInstances</c> API, which attempts
    /// to cleanly shut down the operating system before restarting the instance.
    /// 
    ///  
    /// <para>
    /// This operation is useful for recovering from transient issues or applying certain
    /// configuration changes that require a restart.
    /// </para><note><ul><li><para>
    /// Rebooting a node may cause temporary service interruption for workloads running on
    /// that node. Ensure your workloads can handle node restarts or use appropriate scheduling
    /// to minimize impact.
    /// </para></li><li><para>
    /// You can reboot up to 25 nodes in a single request.
    /// </para></li><li><para>
    /// For SageMaker HyperPod clusters using the Slurm workload manager, ensure rebooting
    /// nodes will not disrupt critical cluster operations.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Set", "SMBatchRebootClusterNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.BatchRebootClusterNodesResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service BatchRebootClusterNodes API operation.", Operation = new[] {"BatchRebootClusterNodes"}, SelectReturnType = typeof(Amazon.SageMaker.Model.BatchRebootClusterNodesResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.BatchRebootClusterNodesResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.BatchRebootClusterNodesResponse object containing multiple properties."
    )]
    public partial class SetSMBatchRebootClusterNodeCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the SageMaker HyperPod cluster containing
        /// the nodes to reboot.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter NodeId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 instance IDs to reboot using soft recovery. You can specify between
        /// 1 and 25 instance IDs.</para><note><ul><li><para>Either <c>NodeIds</c> or <c>NodeLogicalIds</c> must be provided (or both), but at
        /// least one is required.</para></li><li><para>Each instance ID must follow the pattern <c>i-</c> followed by 17 hexadecimal characters
        /// (for example, <c>i-0123456789abcdef0</c>).</para></li></ul></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeIds")]
        public System.String[] NodeId { get; set; }
        #endregion
        
        #region Parameter NodeLogicalId
        /// <summary>
        /// <para>
        /// <para>A list of logical node IDs to reboot using soft recovery. You can specify between
        /// 1 and 25 logical node IDs.</para><para>The <c>NodeLogicalId</c> is a unique identifier that persists throughout the node's
        /// lifecycle and can be used to track nodes that are still being provisioned and don't
        /// yet have an EC2 instance ID assigned.</para><important><ul><li><para>This parameter is only supported for clusters using <c>Continuous</c> as the <c>NodeProvisioningMode</c>.
        /// For clusters using the default provisioning mode, use <c>NodeIds</c> instead.</para></li><li><para>Either <c>NodeIds</c> or <c>NodeLogicalIds</c> must be provided (or both), but at
        /// least one is required.</para></li></ul></important><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeLogicalIds")]
        public System.String[] NodeLogicalId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.BatchRebootClusterNodesResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.BatchRebootClusterNodesResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SMBatchRebootClusterNode (BatchRebootClusterNodes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.BatchRebootClusterNodesResponse, SetSMBatchRebootClusterNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NodeId != null)
            {
                context.NodeId = new List<System.String>(this.NodeId);
            }
            if (this.NodeLogicalId != null)
            {
                context.NodeLogicalId = new List<System.String>(this.NodeLogicalId);
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
            var request = new Amazon.SageMaker.Model.BatchRebootClusterNodesRequest();
            
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.NodeId != null)
            {
                request.NodeIds = cmdletContext.NodeId;
            }
            if (cmdletContext.NodeLogicalId != null)
            {
                request.NodeLogicalIds = cmdletContext.NodeLogicalId;
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
        
        private Amazon.SageMaker.Model.BatchRebootClusterNodesResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.BatchRebootClusterNodesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "BatchRebootClusterNodes");
            try
            {
                return client.BatchRebootClusterNodesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public List<System.String> NodeId { get; set; }
            public List<System.String> NodeLogicalId { get; set; }
            public System.Func<Amazon.SageMaker.Model.BatchRebootClusterNodesResponse, SetSMBatchRebootClusterNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
