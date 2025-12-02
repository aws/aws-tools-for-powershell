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
    /// Creates an Amazon SageMaker HyperPod cluster. SageMaker HyperPod is a capability of
    /// SageMaker for creating and managing persistent clusters for developing large machine
    /// learning models, such as large language models (LLMs) and diffusion models. To learn
    /// more, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-hyperpod.html">Amazon
    /// SageMaker HyperPod</a> in the <i>Amazon SageMaker Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "SMCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateClusterResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateClusterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMClusterCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoScaling_AutoScalerType
        /// <summary>
        /// <para>
        /// <para>The type of autoscaler to use. Currently supported value is <c>Karpenter</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ClusterAutoScalerType")]
        public Amazon.SageMaker.ClusterAutoScalerType AutoScaling_AutoScalerType { get; set; }
        #endregion
        
        #region Parameter Eks_ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon EKS cluster associated with the SageMaker
        /// HyperPod cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Orchestrator_Eks_ClusterArn")]
        public System.String Eks_ClusterArn { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name for the new SageMaker HyperPod cluster.</para>
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
        
        #region Parameter ClusterRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that HyperPod assumes to perform cluster
        /// autoscaling operations. This role must have permissions for <c>sagemaker:BatchAddClusterNodes</c>
        /// and <c>sagemaker:BatchDeleteClusterNodes</c>. This is only required when autoscaling
        /// is enabled and when HyperPod is performing autoscaling operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterRole { get; set; }
        #endregion
        
        #region Parameter InstanceGroup
        /// <summary>
        /// <para>
        /// <para>The instance groups to be created in the SageMaker HyperPod cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceGroups")]
        public Amazon.SageMaker.Model.ClusterInstanceGroupSpecification[] InstanceGroup { get; set; }
        #endregion
        
        #region Parameter TieredStorageConfig_InstanceMemoryAllocationPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage (int) of cluster memory to allocate for checkpointing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TieredStorageConfig_InstanceMemoryAllocationPercentage { get; set; }
        #endregion
        
        #region Parameter AutoScaling_Mode
        /// <summary>
        /// <para>
        /// <para>Describes whether autoscaling is enabled or disabled for the cluster. Valid values
        /// are <c>Enable</c> and <c>Disable</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ClusterAutoScalingMode")]
        public Amazon.SageMaker.ClusterAutoScalingMode AutoScaling_Mode { get; set; }
        #endregion
        
        #region Parameter TieredStorageConfig_Mode
        /// <summary>
        /// <para>
        /// <para>Specifies whether managed tier checkpointing is enabled or disabled for the HyperPod
        /// cluster. When set to <c>Enable</c>, the system installs a memory management daemon
        /// that provides disaggregated memory as a service for checkpoint storage. When set to
        /// <c>Disable</c>, the feature is turned off and the memory management daemon is removed
        /// from the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ClusterConfigMode")]
        public Amazon.SageMaker.ClusterConfigMode TieredStorageConfig_Mode { get; set; }
        #endregion
        
        #region Parameter NodeProvisioningMode
        /// <summary>
        /// <para>
        /// <para>The mode for provisioning nodes in the cluster. You can specify the following modes:</para><ul><li><para><b>Continuous</b>: Scaling behavior that enables 1) concurrent operation execution
        /// within instance groups, 2) continuous retry mechanisms for failed operations, 3) enhanced
        /// customer visibility into cluster events through detailed event streams, 4) partial
        /// provisioning capabilities. Your clusters and instance groups remain <c>InService</c>
        /// while scaling. This mode is only supported for EKS orchestrated clusters.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ClusterNodeProvisioningMode")]
        public Amazon.SageMaker.ClusterNodeProvisioningMode NodeProvisioningMode { get; set; }
        #endregion
        
        #region Parameter NodeRecovery
        /// <summary>
        /// <para>
        /// <para>The node recovery mode for the SageMaker HyperPod cluster. When set to <c>Automatic</c>,
        /// SageMaker HyperPod will automatically reboot or replace faulty nodes when issues are
        /// detected. When set to <c>None</c>, cluster administrators will need to manually manage
        /// any faulty cluster instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ClusterNodeRecovery")]
        public Amazon.SageMaker.ClusterNodeRecovery NodeRecovery { get; set; }
        #endregion
        
        #region Parameter RestrictedInstanceGroup
        /// <summary>
        /// <para>
        /// <para>The specialized instance groups for training models like Amazon Nova to be created
        /// in the SageMaker HyperPod cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestrictedInstanceGroups")]
        public Amazon.SageMaker.Model.ClusterRestrictedInstanceGroupSpecification[] RestrictedInstanceGroup { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The VPC security group IDs, in the form <c>sg-xxxxxxxx</c>. Specify the security groups
        /// for the VPC that is specified in the <c>Subnets</c> field.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The ID of the subnets in the VPC to which you want to connect your training job or
        /// model. For information about the availability of specific instance types, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/instance-types-az.html">Supported
        /// Instance Types and Availability Zones</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Custom tags for managing the SageMaker HyperPod cluster as an Amazon Web Services
        /// resource. You can add tags to your cluster in the same way you add them in other Amazon
        /// Web Services services that support tagging. To learn more about tagging Amazon Web
        /// Services resources in general, see <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/tagging.html">Tagging
        /// Amazon Web Services Resources User Guide</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClusterArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClusterArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateClusterResponse, NewSMClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScaling_AutoScalerType = this.AutoScaling_AutoScalerType;
            context.AutoScaling_Mode = this.AutoScaling_Mode;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterRole = this.ClusterRole;
            if (this.InstanceGroup != null)
            {
                context.InstanceGroup = new List<Amazon.SageMaker.Model.ClusterInstanceGroupSpecification>(this.InstanceGroup);
            }
            context.NodeProvisioningMode = this.NodeProvisioningMode;
            context.NodeRecovery = this.NodeRecovery;
            context.Eks_ClusterArn = this.Eks_ClusterArn;
            if (this.RestrictedInstanceGroup != null)
            {
                context.RestrictedInstanceGroup = new List<Amazon.SageMaker.Model.ClusterRestrictedInstanceGroupSpecification>(this.RestrictedInstanceGroup);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
            }
            context.TieredStorageConfig_InstanceMemoryAllocationPercentage = this.TieredStorageConfig_InstanceMemoryAllocationPercentage;
            context.TieredStorageConfig_Mode = this.TieredStorageConfig_Mode;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
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
            var request = new Amazon.SageMaker.Model.CreateClusterRequest();
            
            
             // populate AutoScaling
            var requestAutoScalingIsNull = true;
            request.AutoScaling = new Amazon.SageMaker.Model.ClusterAutoScalingConfig();
            Amazon.SageMaker.ClusterAutoScalerType requestAutoScaling_autoScaling_AutoScalerType = null;
            if (cmdletContext.AutoScaling_AutoScalerType != null)
            {
                requestAutoScaling_autoScaling_AutoScalerType = cmdletContext.AutoScaling_AutoScalerType;
            }
            if (requestAutoScaling_autoScaling_AutoScalerType != null)
            {
                request.AutoScaling.AutoScalerType = requestAutoScaling_autoScaling_AutoScalerType;
                requestAutoScalingIsNull = false;
            }
            Amazon.SageMaker.ClusterAutoScalingMode requestAutoScaling_autoScaling_Mode = null;
            if (cmdletContext.AutoScaling_Mode != null)
            {
                requestAutoScaling_autoScaling_Mode = cmdletContext.AutoScaling_Mode;
            }
            if (requestAutoScaling_autoScaling_Mode != null)
            {
                request.AutoScaling.Mode = requestAutoScaling_autoScaling_Mode;
                requestAutoScalingIsNull = false;
            }
             // determine if request.AutoScaling should be set to null
            if (requestAutoScalingIsNull)
            {
                request.AutoScaling = null;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.ClusterRole != null)
            {
                request.ClusterRole = cmdletContext.ClusterRole;
            }
            if (cmdletContext.InstanceGroup != null)
            {
                request.InstanceGroups = cmdletContext.InstanceGroup;
            }
            if (cmdletContext.NodeProvisioningMode != null)
            {
                request.NodeProvisioningMode = cmdletContext.NodeProvisioningMode;
            }
            if (cmdletContext.NodeRecovery != null)
            {
                request.NodeRecovery = cmdletContext.NodeRecovery;
            }
            
             // populate Orchestrator
            var requestOrchestratorIsNull = true;
            request.Orchestrator = new Amazon.SageMaker.Model.ClusterOrchestrator();
            Amazon.SageMaker.Model.ClusterOrchestratorEksConfig requestOrchestrator_orchestrator_Eks = null;
            
             // populate Eks
            var requestOrchestrator_orchestrator_EksIsNull = true;
            requestOrchestrator_orchestrator_Eks = new Amazon.SageMaker.Model.ClusterOrchestratorEksConfig();
            System.String requestOrchestrator_orchestrator_Eks_eks_ClusterArn = null;
            if (cmdletContext.Eks_ClusterArn != null)
            {
                requestOrchestrator_orchestrator_Eks_eks_ClusterArn = cmdletContext.Eks_ClusterArn;
            }
            if (requestOrchestrator_orchestrator_Eks_eks_ClusterArn != null)
            {
                requestOrchestrator_orchestrator_Eks.ClusterArn = requestOrchestrator_orchestrator_Eks_eks_ClusterArn;
                requestOrchestrator_orchestrator_EksIsNull = false;
            }
             // determine if requestOrchestrator_orchestrator_Eks should be set to null
            if (requestOrchestrator_orchestrator_EksIsNull)
            {
                requestOrchestrator_orchestrator_Eks = null;
            }
            if (requestOrchestrator_orchestrator_Eks != null)
            {
                request.Orchestrator.Eks = requestOrchestrator_orchestrator_Eks;
                requestOrchestratorIsNull = false;
            }
             // determine if request.Orchestrator should be set to null
            if (requestOrchestratorIsNull)
            {
                request.Orchestrator = null;
            }
            if (cmdletContext.RestrictedInstanceGroup != null)
            {
                request.RestrictedInstanceGroups = cmdletContext.RestrictedInstanceGroup;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TieredStorageConfig
            var requestTieredStorageConfigIsNull = true;
            request.TieredStorageConfig = new Amazon.SageMaker.Model.ClusterTieredStorageConfig();
            System.Int32? requestTieredStorageConfig_tieredStorageConfig_InstanceMemoryAllocationPercentage = null;
            if (cmdletContext.TieredStorageConfig_InstanceMemoryAllocationPercentage != null)
            {
                requestTieredStorageConfig_tieredStorageConfig_InstanceMemoryAllocationPercentage = cmdletContext.TieredStorageConfig_InstanceMemoryAllocationPercentage.Value;
            }
            if (requestTieredStorageConfig_tieredStorageConfig_InstanceMemoryAllocationPercentage != null)
            {
                request.TieredStorageConfig.InstanceMemoryAllocationPercentage = requestTieredStorageConfig_tieredStorageConfig_InstanceMemoryAllocationPercentage.Value;
                requestTieredStorageConfigIsNull = false;
            }
            Amazon.SageMaker.ClusterConfigMode requestTieredStorageConfig_tieredStorageConfig_Mode = null;
            if (cmdletContext.TieredStorageConfig_Mode != null)
            {
                requestTieredStorageConfig_tieredStorageConfig_Mode = cmdletContext.TieredStorageConfig_Mode;
            }
            if (requestTieredStorageConfig_tieredStorageConfig_Mode != null)
            {
                request.TieredStorageConfig.Mode = requestTieredStorageConfig_tieredStorageConfig_Mode;
                requestTieredStorageConfigIsNull = false;
            }
             // determine if request.TieredStorageConfig should be set to null
            if (requestTieredStorageConfigIsNull)
            {
                request.TieredStorageConfig = null;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.SageMaker.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupId != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestVpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestVpcConfig_vpcConfig_Subnet != null)
            {
                request.VpcConfig.Subnets = requestVpcConfig_vpcConfig_Subnet;
                requestVpcConfigIsNull = false;
            }
             // determine if request.VpcConfig should be set to null
            if (requestVpcConfigIsNull)
            {
                request.VpcConfig = null;
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
        
        private Amazon.SageMaker.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateCluster");
            try
            {
                return client.CreateClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.ClusterAutoScalerType AutoScaling_AutoScalerType { get; set; }
            public Amazon.SageMaker.ClusterAutoScalingMode AutoScaling_Mode { get; set; }
            public System.String ClusterName { get; set; }
            public System.String ClusterRole { get; set; }
            public List<Amazon.SageMaker.Model.ClusterInstanceGroupSpecification> InstanceGroup { get; set; }
            public Amazon.SageMaker.ClusterNodeProvisioningMode NodeProvisioningMode { get; set; }
            public Amazon.SageMaker.ClusterNodeRecovery NodeRecovery { get; set; }
            public System.String Eks_ClusterArn { get; set; }
            public List<Amazon.SageMaker.Model.ClusterRestrictedInstanceGroupSpecification> RestrictedInstanceGroup { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Int32? TieredStorageConfig_InstanceMemoryAllocationPercentage { get; set; }
            public Amazon.SageMaker.ClusterConfigMode TieredStorageConfig_Mode { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateClusterResponse, NewSMClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClusterArn;
        }
        
    }
}
