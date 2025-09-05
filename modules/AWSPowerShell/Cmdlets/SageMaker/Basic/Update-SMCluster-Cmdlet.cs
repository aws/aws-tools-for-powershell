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
    /// Updates a SageMaker HyperPod cluster.
    /// </summary>
    [Cmdlet("Update", "SMCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateCluster API operation.", Operation = new[] {"UpdateCluster"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateClusterResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateClusterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMClusterCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>Specify the name of the SageMaker HyperPod cluster you want to update.</para>
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
        /// <para>The Amazon Resource Name (ARN) of the IAM role that HyperPod assumes for cluster autoscaling
        /// operations. Cannot be updated while autoscaling is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterRole { get; set; }
        #endregion
        
        #region Parameter InstanceGroup
        /// <summary>
        /// <para>
        /// <para>Specify the instance groups to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceGroups")]
        public Amazon.SageMaker.Model.ClusterInstanceGroupSpecification[] InstanceGroup { get; set; }
        #endregion
        
        #region Parameter InstanceGroupsToDelete
        /// <summary>
        /// <para>
        /// <para>Specify the names of the instance groups to delete. Use a single <c>,</c> as the separator
        /// between multiple names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] InstanceGroupsToDelete { get; set; }
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
        
        #region Parameter NodeRecovery
        /// <summary>
        /// <para>
        /// <para>The node recovery mode to be applied to the SageMaker HyperPod cluster.</para>
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
        /// in the SageMaker HyperPod cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestrictedInstanceGroups")]
        public Amazon.SageMaker.Model.ClusterRestrictedInstanceGroupSpecification[] RestrictedInstanceGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClusterArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateClusterResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClusterArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMCluster (UpdateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateClusterResponse, UpdateSMClusterCmdlet>(Select) ??
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
            if (this.InstanceGroupsToDelete != null)
            {
                context.InstanceGroupsToDelete = new List<System.String>(this.InstanceGroupsToDelete);
            }
            context.NodeRecovery = this.NodeRecovery;
            if (this.RestrictedInstanceGroup != null)
            {
                context.RestrictedInstanceGroup = new List<Amazon.SageMaker.Model.ClusterRestrictedInstanceGroupSpecification>(this.RestrictedInstanceGroup);
            }
            context.TieredStorageConfig_InstanceMemoryAllocationPercentage = this.TieredStorageConfig_InstanceMemoryAllocationPercentage;
            context.TieredStorageConfig_Mode = this.TieredStorageConfig_Mode;
            
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
            var request = new Amazon.SageMaker.Model.UpdateClusterRequest();
            
            
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
            if (cmdletContext.InstanceGroupsToDelete != null)
            {
                request.InstanceGroupsToDelete = cmdletContext.InstanceGroupsToDelete;
            }
            if (cmdletContext.NodeRecovery != null)
            {
                request.NodeRecovery = cmdletContext.NodeRecovery;
            }
            if (cmdletContext.RestrictedInstanceGroup != null)
            {
                request.RestrictedInstanceGroups = cmdletContext.RestrictedInstanceGroup;
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
        
        private Amazon.SageMaker.Model.UpdateClusterResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateCluster");
            try
            {
                #if DESKTOP
                return client.UpdateCluster(request);
                #elif CORECLR
                return client.UpdateClusterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.ClusterAutoScalerType AutoScaling_AutoScalerType { get; set; }
            public Amazon.SageMaker.ClusterAutoScalingMode AutoScaling_Mode { get; set; }
            public System.String ClusterName { get; set; }
            public System.String ClusterRole { get; set; }
            public List<Amazon.SageMaker.Model.ClusterInstanceGroupSpecification> InstanceGroup { get; set; }
            public List<System.String> InstanceGroupsToDelete { get; set; }
            public Amazon.SageMaker.ClusterNodeRecovery NodeRecovery { get; set; }
            public List<Amazon.SageMaker.Model.ClusterRestrictedInstanceGroupSpecification> RestrictedInstanceGroup { get; set; }
            public System.Int32? TieredStorageConfig_InstanceMemoryAllocationPercentage { get; set; }
            public Amazon.SageMaker.ClusterConfigMode TieredStorageConfig_Mode { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateClusterResponse, UpdateSMClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClusterArn;
        }
        
    }
}
