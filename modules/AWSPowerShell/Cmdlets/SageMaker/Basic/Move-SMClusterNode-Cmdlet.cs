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
    /// Moves running nodes from one instance group to another instance group. The target
    /// instance group can be in the same HyperPod cluster or in a different HyperPod cluster
    /// in the same account and Region. The underlying instances aren't terminated.
    /// 
    ///  
    /// <para>
    /// Each node keeps its instance ID, its <c>NodeLogicalId</c>, its network interfaces
    /// and IP addresses, and its capacity. The node then joins the target instance group
    /// with the target's configuration and lifecycle scripts.
    /// </para><important><para>
    /// The move replaces the node's root Amazon Elastic Block Store (Amazon EBS) volume and
    /// secondary EBS volume, which deletes any data stored on them. Back up any data that
    /// you need before you move the node.
    /// </para></important><para>
    /// Specify the nodes to move with exactly one of <c>NodeIds</c>, <c>NodeLogicalIds</c>,
    /// or <c>InstanceCount</c>. The operation is asynchronous and returns after it accepts
    /// the nodes for the move. While a node moves, its status is <c>DetachInProgress</c>
    /// and then <c>AttachInProgress</c>. The node appears in the source cluster while it
    /// detaches. After HyperPod hands the node off to the target instance group, the node
    /// appears in the target cluster. To track the node, call <c>DescribeClusterNode</c>
    /// or <c>ListClusterNodes</c> on the source or target cluster.
    /// </para><note><para>
    /// Both clusters must be <c>InService</c>, use Amazon EKS orchestration, and use <c>Continuous</c>
    /// as the <c>NodeProvisioningMode</c>.
    /// </para><para>
    /// The source and target instance groups must also use compatible configurations.
    /// </para></note>
    /// </summary>
    [Cmdlet("Move", "SMClusterNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.MoveClusterNodesResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service MoveClusterNodes API operation.", Operation = new[] {"MoveClusterNodes"}, SelectReturnType = typeof(Amazon.SageMaker.Model.MoveClusterNodesResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.MoveClusterNodesResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.MoveClusterNodesResponse object containing multiple properties."
    )]
    public partial class MoveSMClusterNodeCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of nodes to move, from 1 to 50. HyperPod selects the nodes from the source
        /// instance group. If fewer than this number of nodes are eligible to move, the request
        /// fails and no nodes are moved. Specify exactly one of <c>NodeIds</c>, <c>NodeLogicalIds</c>,
        /// or <c>InstanceCount</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter NodeId
        /// <summary>
        /// <para>
        /// <para>A list of instance IDs of the nodes to move. You can specify up to 50 instance IDs.
        /// Each node is evaluated separately, so some nodes can be moved while others fail. The
        /// request fails if moving the eligible nodes would reduce the source instance group
        /// below its minimum instance count. Specify exactly one of <c>NodeIds</c>, <c>NodeLogicalIds</c>,
        /// or <c>InstanceCount</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
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
        /// <para>A list of <c>NodeLogicalIds</c> of the nodes to move. You can specify up to 50 <c>NodeLogicalIds</c>.
        /// Each node is evaluated separately, so some nodes can be moved while others fail. The
        /// request fails if moving the eligible nodes would reduce the source instance group
        /// below its minimum instance count. Specify exactly one of <c>NodeIds</c>, <c>NodeLogicalIds</c>,
        /// or <c>InstanceCount</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeLogicalIds")]
        public System.String[] NodeLogicalId { get; set; }
        #endregion
        
        #region Parameter SourceClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the HyperPod cluster that the nodes are moved from.</para>
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
        public System.String SourceClusterArn { get; set; }
        #endregion
        
        #region Parameter SourceInstanceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the instance group in the source cluster that the nodes are moved from.</para>
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
        public System.String SourceInstanceGroupName { get; set; }
        #endregion
        
        #region Parameter TargetClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the HyperPod cluster that the nodes are moved to.
        /// The target cluster must be in the same account and Region as the source cluster, and
        /// can be the same cluster as the source.</para>
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
        public System.String TargetClusterArn { get; set; }
        #endregion
        
        #region Parameter TargetInstanceGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the instance group in the target cluster that the nodes are moved to.
        /// If the target cluster is the same as the source cluster, the target instance group
        /// must be different from the source instance group.</para>
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
        public System.String TargetInstanceGroupName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If you retry the request with the same client token
        /// and the same parameters within 8 hours, the service returns the original response.
        /// It doesn't start a new move. If you reuse a client token with different parameters,
        /// the request fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.MoveClusterNodesResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.MoveClusterNodesResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Move-SMClusterNode (MoveClusterNodes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.MoveClusterNodesResponse, MoveSMClusterNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InstanceCount = this.InstanceCount;
            if (this.NodeId != null)
            {
                context.NodeId = new List<System.String>(this.NodeId);
            }
            if (this.NodeLogicalId != null)
            {
                context.NodeLogicalId = new List<System.String>(this.NodeLogicalId);
            }
            context.SourceClusterArn = this.SourceClusterArn;
            #if MODULAR
            if (this.SourceClusterArn == null && ParameterWasBound(nameof(this.SourceClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceInstanceGroupName = this.SourceInstanceGroupName;
            #if MODULAR
            if (this.SourceInstanceGroupName == null && ParameterWasBound(nameof(this.SourceInstanceGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceInstanceGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetClusterArn = this.TargetClusterArn;
            #if MODULAR
            if (this.TargetClusterArn == null && ParameterWasBound(nameof(this.TargetClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetInstanceGroupName = this.TargetInstanceGroupName;
            #if MODULAR
            if (this.TargetInstanceGroupName == null && ParameterWasBound(nameof(this.TargetInstanceGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetInstanceGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.MoveClusterNodesRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.NodeId != null)
            {
                request.NodeIds = cmdletContext.NodeId;
            }
            if (cmdletContext.NodeLogicalId != null)
            {
                request.NodeLogicalIds = cmdletContext.NodeLogicalId;
            }
            if (cmdletContext.SourceClusterArn != null)
            {
                request.SourceClusterArn = cmdletContext.SourceClusterArn;
            }
            if (cmdletContext.SourceInstanceGroupName != null)
            {
                request.SourceInstanceGroupName = cmdletContext.SourceInstanceGroupName;
            }
            if (cmdletContext.TargetClusterArn != null)
            {
                request.TargetClusterArn = cmdletContext.TargetClusterArn;
            }
            if (cmdletContext.TargetInstanceGroupName != null)
            {
                request.TargetInstanceGroupName = cmdletContext.TargetInstanceGroupName;
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
        
        private Amazon.SageMaker.Model.MoveClusterNodesResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.MoveClusterNodesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "MoveClusterNodes");
            try
            {
                return client.MoveClusterNodesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? InstanceCount { get; set; }
            public List<System.String> NodeId { get; set; }
            public List<System.String> NodeLogicalId { get; set; }
            public System.String SourceClusterArn { get; set; }
            public System.String SourceInstanceGroupName { get; set; }
            public System.String TargetClusterArn { get; set; }
            public System.String TargetInstanceGroupName { get; set; }
            public System.Func<Amazon.SageMaker.Model.MoveClusterNodesResponse, MoveSMClusterNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
