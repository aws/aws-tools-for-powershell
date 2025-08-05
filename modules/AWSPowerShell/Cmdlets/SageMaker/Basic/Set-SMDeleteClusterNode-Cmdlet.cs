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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Deletes specific nodes within a SageMaker HyperPod cluster. <c>BatchDeleteClusterNodes</c>
    /// accepts a cluster name and a list of node IDs.
    /// 
    ///  <important><ul><li><para>
    /// To safeguard your work, back up your data to Amazon S3 or an FSx for Lustre file system
    /// before invoking the API on a worker node group. This will help prevent any potential
    /// data loss from the instance root volume. For more information about backup, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-hyperpod-operate-cli-command.html#sagemaker-hyperpod-operate-cli-command-update-cluster-software-backup">Use
    /// the backup script provided by SageMaker HyperPod</a>. 
    /// </para></li><li><para>
    /// If you want to invoke this API on an existing cluster, you'll first need to patch
    /// the cluster by running the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_UpdateClusterSoftware.html">UpdateClusterSoftware
    /// API</a>. For more information about patching a cluster, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-hyperpod-operate-cli-command.html#sagemaker-hyperpod-operate-cli-command-update-cluster-software">Update
    /// the SageMaker HyperPod platform software of a cluster</a>.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("Set", "SMDeleteClusterNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service BatchDeleteClusterNodes API operation.", Operation = new[] {"BatchDeleteClusterNodes"}, SelectReturnType = typeof(Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse object containing multiple properties."
    )]
    public partial class SetSMDeleteClusterNodeCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the SageMaker HyperPod cluster from which to delete the specified nodes.</para>
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
        /// <para>A list of node IDs to be deleted from the specified cluster.</para><note><ul><li><para>For SageMaker HyperPod clusters using the Slurm workload manager, you cannot remove
        /// instances that are configured as Slurm controller nodes.</para></li><li><para>If you need to delete more than 99 instances, contact <a href="http://aws.amazon.com/contact-us/">Support</a>
        /// for assistance.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeIds")]
        public System.String[] NodeId { get; set; }
        #endregion
        
        #region Parameter NodeLogicalId
        /// <summary>
        /// <para>
        /// <para>A list of <c>NodeLogicalIds</c> identifying the nodes to be deleted. You can specify
        /// up to 50 <c>NodeLogicalIds</c>. You must specify either <c>NodeLogicalIds</c>, <c>InstanceIds</c>,
        /// or both, with a combined maximum of 50 identifiers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeLogicalIds")]
        public System.String[] NodeLogicalId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SMDeleteClusterNode (BatchDeleteClusterNodes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse, SetSMDeleteClusterNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.SageMaker.Model.BatchDeleteClusterNodesRequest();
            
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
        
        private Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.BatchDeleteClusterNodesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "BatchDeleteClusterNodes");
            try
            {
                #if DESKTOP
                return client.BatchDeleteClusterNodes(request);
                #elif CORECLR
                return client.BatchDeleteClusterNodesAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public List<System.String> NodeId { get; set; }
            public List<System.String> NodeLogicalId { get; set; }
            public System.Func<Amazon.SageMaker.Model.BatchDeleteClusterNodesResponse, SetSMDeleteClusterNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
