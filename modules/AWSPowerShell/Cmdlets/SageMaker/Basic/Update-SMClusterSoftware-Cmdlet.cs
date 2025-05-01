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
    /// Updates the platform software of a SageMaker HyperPod cluster for security patching.
    /// To learn how to use this API, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/sagemaker-hyperpod-operate.html#sagemaker-hyperpod-operate-cli-command-update-cluster-software">Update
    /// the SageMaker HyperPod platform software of a cluster</a>.
    /// 
    ///  <important><para>
    /// The <c>UpgradeClusterSoftware</c> API call may impact your SageMaker HyperPod cluster
    /// uptime and availability. Plan accordingly to mitigate potential disruptions to your
    /// workloads.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "SMClusterSoftware", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateClusterSoftware API operation.", Operation = new[] {"UpdateClusterSoftware"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateClusterSoftwareResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateClusterSoftwareResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateClusterSoftwareResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMClusterSoftwareCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentConfig_AutoRollbackConfiguration
        /// <summary>
        /// <para>
        /// <para>An array that contains the alarms that SageMaker monitors to know whether to roll
        /// back the AMI update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMaker.Model.AlarmDetails[] DeploymentConfig_AutoRollbackConfiguration { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>Specify the name or the Amazon Resource Name (ARN) of the SageMaker HyperPod cluster
        /// you want to update for security patching.</para>
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
        
        #region Parameter InstanceGroup
        /// <summary>
        /// <para>
        /// <para>The array of instance groups for which to update AMI versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceGroups")]
        public Amazon.SageMaker.Model.UpdateClusterSoftwareInstanceGroupSpecification[] InstanceGroup { get; set; }
        #endregion
        
        #region Parameter MaximumBatchSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies whether SageMaker should process the update by amount or percentage of instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumBatchSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.NodeUnavailabilityType")]
        public Amazon.SageMaker.NodeUnavailabilityType MaximumBatchSize_Type { get; set; }
        #endregion
        
        #region Parameter RollbackMaximumBatchSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies whether SageMaker should process the update by amount or percentage of instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.NodeUnavailabilityType")]
        public Amazon.SageMaker.NodeUnavailabilityType RollbackMaximumBatchSize_Type { get; set; }
        #endregion
        
        #region Parameter MaximumBatchSize_Value
        /// <summary>
        /// <para>
        /// <para>Specifies the amount or percentage of instances SageMaker updates at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumBatchSize_Value")]
        public System.Int32? MaximumBatchSize_Value { get; set; }
        #endregion
        
        #region Parameter RollbackMaximumBatchSize_Value
        /// <summary>
        /// <para>
        /// <para>Specifies the amount or percentage of instances SageMaker updates at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_Value")]
        public System.Int32? RollbackMaximumBatchSize_Value { get; set; }
        #endregion
        
        #region Parameter DeploymentConfig_WaitIntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The duration in seconds that SageMaker waits before updating more instances in the
        /// cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_WaitIntervalInSeconds")]
        public System.Int32? DeploymentConfig_WaitIntervalInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClusterArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateClusterSoftwareResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateClusterSoftwareResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMClusterSoftware (UpdateClusterSoftware)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateClusterSoftwareResponse, UpdateSMClusterSoftwareCmdlet>(Select) ??
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
            if (this.DeploymentConfig_AutoRollbackConfiguration != null)
            {
                context.DeploymentConfig_AutoRollbackConfiguration = new List<Amazon.SageMaker.Model.AlarmDetails>(this.DeploymentConfig_AutoRollbackConfiguration);
            }
            context.MaximumBatchSize_Type = this.MaximumBatchSize_Type;
            context.MaximumBatchSize_Value = this.MaximumBatchSize_Value;
            context.RollbackMaximumBatchSize_Type = this.RollbackMaximumBatchSize_Type;
            context.RollbackMaximumBatchSize_Value = this.RollbackMaximumBatchSize_Value;
            context.DeploymentConfig_WaitIntervalInSecond = this.DeploymentConfig_WaitIntervalInSecond;
            if (this.InstanceGroup != null)
            {
                context.InstanceGroup = new List<Amazon.SageMaker.Model.UpdateClusterSoftwareInstanceGroupSpecification>(this.InstanceGroup);
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
            var request = new Amazon.SageMaker.Model.UpdateClusterSoftwareRequest();
            
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate DeploymentConfig
            var requestDeploymentConfigIsNull = true;
            request.DeploymentConfig = new Amazon.SageMaker.Model.DeploymentConfiguration();
            List<Amazon.SageMaker.Model.AlarmDetails> requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = null;
            if (cmdletContext.DeploymentConfig_AutoRollbackConfiguration != null)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = cmdletContext.DeploymentConfig_AutoRollbackConfiguration;
            }
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration != null)
            {
                request.DeploymentConfig.AutoRollbackConfiguration = requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration;
                requestDeploymentConfigIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_WaitIntervalInSecond = null;
            if (cmdletContext.DeploymentConfig_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_WaitIntervalInSecond = cmdletContext.DeploymentConfig_WaitIntervalInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_WaitIntervalInSecond != null)
            {
                request.DeploymentConfig.WaitIntervalInSeconds = requestDeploymentConfig_deploymentConfig_WaitIntervalInSecond.Value;
                requestDeploymentConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RollingDeploymentPolicy requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = null;
            
             // populate RollingUpdatePolicy
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = new Amazon.SageMaker.Model.RollingDeploymentPolicy();
            Amazon.SageMaker.Model.CapacitySizeConfig requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = null;
            
             // populate MaximumBatchSize
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = new Amazon.SageMaker.Model.CapacitySizeConfig();
            Amazon.SageMaker.NodeUnavailabilityType requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type = null;
            if (cmdletContext.MaximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type = cmdletContext.MaximumBatchSize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize.Type = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value = null;
            if (cmdletContext.MaximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value = cmdletContext.MaximumBatchSize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize.Value = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize should be set to null
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.MaximumBatchSize = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
            Amazon.SageMaker.Model.CapacitySizeConfig requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = null;
            
             // populate RollbackMaximumBatchSize
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = new Amazon.SageMaker.Model.CapacitySizeConfig();
            Amazon.SageMaker.NodeUnavailabilityType requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type = null;
            if (cmdletContext.RollbackMaximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type = cmdletContext.RollbackMaximumBatchSize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize.Type = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value = null;
            if (cmdletContext.RollbackMaximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value = cmdletContext.RollbackMaximumBatchSize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize.Value = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize should be set to null
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.RollbackMaximumBatchSize = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy should be set to null
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = null;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy != null)
            {
                request.DeploymentConfig.RollingUpdatePolicy = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy;
                requestDeploymentConfigIsNull = false;
            }
             // determine if request.DeploymentConfig should be set to null
            if (requestDeploymentConfigIsNull)
            {
                request.DeploymentConfig = null;
            }
            if (cmdletContext.InstanceGroup != null)
            {
                request.InstanceGroups = cmdletContext.InstanceGroup;
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
        
        private Amazon.SageMaker.Model.UpdateClusterSoftwareResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateClusterSoftwareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateClusterSoftware");
            try
            {
                #if DESKTOP
                return client.UpdateClusterSoftware(request);
                #elif CORECLR
                return client.UpdateClusterSoftwareAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.AlarmDetails> DeploymentConfig_AutoRollbackConfiguration { get; set; }
            public Amazon.SageMaker.NodeUnavailabilityType MaximumBatchSize_Type { get; set; }
            public System.Int32? MaximumBatchSize_Value { get; set; }
            public Amazon.SageMaker.NodeUnavailabilityType RollbackMaximumBatchSize_Type { get; set; }
            public System.Int32? RollbackMaximumBatchSize_Value { get; set; }
            public System.Int32? DeploymentConfig_WaitIntervalInSecond { get; set; }
            public List<Amazon.SageMaker.Model.UpdateClusterSoftwareInstanceGroupSpecification> InstanceGroup { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateClusterSoftwareResponse, UpdateSMClusterSoftwareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClusterArn;
        }
        
    }
}
