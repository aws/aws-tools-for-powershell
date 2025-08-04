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
    /// Attaches your Amazon Elastic Block Store (Amazon EBS) volume to a node in your EKS-orchestrated
    /// HyperPod cluster. 
    /// 
    ///  
    /// <para>
    ///  This API works with the Amazon Elastic Block Store (Amazon EBS) Container Storage
    /// Interface (CSI) driver to manage the lifecycle of persistent storage in your HyperPod
    /// EKS clusters. 
    /// </para>
    /// </summary>
    [Cmdlet("Mount", "SMClusterNodeVolume", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service AttachClusterNodeVolume API operation.", Operation = new[] {"AttachClusterNodeVolume"}, SelectReturnType = typeof(Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse object containing multiple properties."
    )]
    public partial class MountSMClusterNodeVolumeCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of your SageMaker HyperPod cluster containing the
        /// target node. Your cluster must use EKS as the orchestration and be in the <c>InService</c>
        /// state. </para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter NodeId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the cluster node to which you want to attach the volume.
        /// The node must belong to your specified HyperPod cluster and cannot be part of a Restricted
        /// Instance Group (RIG). </para>
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
        public System.String NodeId { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of your EBS volume to attach. The volume must be in the <c>available</c>
        /// state. </para>
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
        public System.String VolumeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VolumeId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Mount-SMClusterNodeVolume (AttachClusterNodeVolume)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse, MountSMClusterNodeVolumeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeId = this.NodeId;
            #if MODULAR
            if (this.NodeId == null && ParameterWasBound(nameof(this.NodeId)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VolumeId = this.VolumeId;
            #if MODULAR
            if (this.VolumeId == null && ParameterWasBound(nameof(this.VolumeId)))
            {
                WriteWarning("You are passing $null as a value for parameter VolumeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.AttachClusterNodeVolumeRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.NodeId != null)
            {
                request.NodeId = cmdletContext.NodeId;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeId = cmdletContext.VolumeId;
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
        
        private Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.AttachClusterNodeVolumeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "AttachClusterNodeVolume");
            try
            {
                return client.AttachClusterNodeVolumeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String NodeId { get; set; }
            public System.String VolumeId { get; set; }
            public System.Func<Amazon.SageMaker.Model.AttachClusterNodeVolumeResponse, MountSMClusterNodeVolumeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
